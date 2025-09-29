//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;


namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// キャンペーン実績表(BLコード別)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: キャンペーン実績表のフォームクラスです。</br>
	/// <br>Programmer	: 田建委</br>
	/// <br>Date		: 2011/05/19</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN02052P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// キャンペーン実績表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: キャンペーン実績表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		public PMKHN02052P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									// 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderTitle;				// フォームタイトル
		private string				_pageHeaderSortOderTitle;		// ソート順

        private CampaignRsltList _campaignRsltList;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Line line3;
        private TextBox textBox13;
        private TextBox textBox49;
        private TextBox textBox50;
        private TextBox textBox51;
        private TextBox textBox58;
        private TextBox textBox59;
        private TextBox textBox68;
        private TextBox textBox69;
        private TextBox textBox70;
        private TextBox textBox71;
        private TextBox textBox72;
        private TextBox textBox73;
        private TextBox textBox74;
        private TextBox textBox75;
        private TextBox textBox76;
        private TextBox textBox77;
        private TextBox textBox78;
        private TextBox textBox79;
        private TextBox textBox80;
        private TextBox textBox81;
        private TextBox textBox82;
        private TextBox textBox83;
        private TextBox textBox84;
        private TextBox textBox85;
        private TextBox textBox86;
        private TextBox textBox87;
        private TextBox textBox90;
        private TextBox textBox92;
        private TextBox textBox93;
        private TextBox textBox94;
        private TextBox textBox95;
        private TextBox textBox96;
        private TextBox textBox97;
        private TextBox textBox98;
        private TextBox textBox99;
        private TextBox textBox100;
        private TextBox textBox101;
        private Label label14;
        private TextBox textBox102;
        private TextBox textBox103;
        private GroupHeader AreaHeader;
        private GroupFooter AreaFooter;
        private TextBox ArHd_AddUpSecCode;
        private TextBox ArHd_SectionGuideNm;
        private TextBox ArHd_AreaCd;
        private TextBox ArHd_AreaNm;
        private Label ArHd_SectionTitle;
        private Label ArHd_AreaTitle;
        private Line line7;             
        private TextBox textBox60;
        private TextBox textBox63;
        private Label label15;
        private Line line10;
        private Label label17;
        private TextBox textBox91;
        private TextBox textBox120;
        private Line line11;
        private Line line12;
        private Label label18;
        private TextBox textBox122;
        private TextBox textBox123;
        private TextBox textBox124;
        private TextBox textBox125;
        private TextBox textBox126;
        private TextBox textBox127;
        private TextBox textBox128;
        private TextBox textBox129;
        private TextBox textBox130;
        private TextBox textBox131;
        private TextBox textBox132;
        private TextBox textBox133;
        private TextBox textBox134;
        private TextBox textBox135;
        private GroupHeader empHeader;
        private GroupFooter empFooter;
        private Line line4;
        private TextBox suTotalSalesCount;
        private TextBox suCmpPureSalesRatio;
        private TextBox suProfitRatio;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox25;
        private TextBox textBox9;
        private TextBox textBox12;
        private TextBox textBox3;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox grGoalsCount;
        private TextBox textBox35;
        private TextBox textBox44;
        private TextBox textBox45;
        private TextBox textBox46;
        private TextBox textBox47;
        private TextBox textBox52;
        private TextBox textBox53;
        private Label Lb_EmpTotal;
        private TextBox textBox48;
        private GroupHeader arHeader;
        private GroupFooter arFooter;
        private Label Lb_AreaTotal;
        private TextBox arCmpPureSalesRatio;
        private TextBox arProfitRatio;
        private TextBox textBox104;
        private TextBox textBox105;
        private TextBox textBox106;
        private TextBox textBox107;
        private TextBox textBox108;
        private TextBox textBox109;
        private TextBox textBox110;
        private TextBox textBox111;
        private TextBox textBox112;
        private TextBox textBox113;
        private TextBox textBox114;
        private TextBox textBox115;
        private TextBox textBox116;
        private TextBox textBox117;
        private TextBox textBox118;
        private TextBox textBox119;
        private TextBox arTotalSalesCount;
        private TextBox textBox121;
        private Line line9;
        private Line line14;
        private Line line15;
        private Line line16;
        private Line line13;             

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
                this._campaignRsltList = (CampaignRsltList)this._printInfo.jyoken;
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
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			
			// タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;
            			
            #region 
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    {
                        #region 商品別
                        this.CustomerHeader.Visible = false;
                        this.empHeader.Visible = false;
                        this.tb_Sort.Text = string.Empty;
                        // 拠点計
                        this.SectionHeader.Visible = true;
                        this.line12.Visible = true;
                        this.label14.Visible = true;
                        this.textBox102.Visible = true;
                        this.textBox103.Visible = true;
                        // 得意先計
                        this.CustomerHeader.Visible = false;
                        this.CustomerFooter.Visible = false;
                        // 担当者計
                        this.EmployeeHeader.Visible = false;
                        this.EmployeeFooter.Visible = false;
                        this.arHeader.Visible = false;

                        #region 改頁
                        if (this._campaignRsltList.CrModeSec == 0)
                        {
                            this.SectionHeader.NewPage = NewPage.None;
                        }
                        #endregion

                        #region 印字パターン
                        

                        // 明細単位
                        switch (this._campaignRsltList.Detail)
                        {
                            case 0: // 品番
                                {
                                    if (this._campaignRsltList.Total == 0)
                                    {
                                        this.CustomerHeader.Visible = false;
                                        this.CustomerHeader.DataField = "";
                                        this.EmployeeHeader.Visible = false;
                                        this.EmployeeHeader.DataField = "";
                                        // 印字パターン１
                                        // 品番
                                        this.Lb_GoodsNo.Visible = true;
                                        // 品名
                                        this.Lb_GoodsName.Visible = true;
                                        // BLｺｰﾄﾞ
                                        this.Tt_GroupCode.Visible = false;
                                        this.Lb_GroupCode.Text = "ｸﾞﾙｰﾌﾟ";
                                        this.Lb_BLTotal.Text = "ｸﾞﾙｰﾌﾟ計";
                                        this.GroupCode.Visible = true;
                                        this.GroupName.Visible = true;
                                        this.BLGoodsCode.Visible = false;
                                        this.BLGoodsName.Visible = false;
                                        // 品番
                                        this.GoodsNo.Visible = true;
                                        // 品名
                                        this.GoodsName.Visible = true;
                                        // BLｺｰﾄﾞ
                                        this.tb_BLGoodsCd.Visible = false;
                                        this.tb_BLGoodsNm.Visible = false;
                                        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                        this.tb_GroupCd.Visible = false;
                                        this.tb_GroupNm.Visible = false;
                                        this.BLGroupHeader.DataField = "BLGroupCode";
                                    }
                                    else
                                    {
                                        this.CustomerHeader.Visible = false;
                                        this.CustomerHeader.DataField = "";
                                        this.EmployeeHeader.Visible = false;
                                        this.EmployeeHeader.DataField = "";
                                        // 印字パターン２
                                        // 品番
                                        this.Lb_GoodsNo.Visible = true;
                                        // 品名
                                        this.Lb_GoodsName.Visible = true;
                                        // BLｺｰﾄﾞ
                                        this.Tt_GroupCode.Visible = false;
                                        this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                        this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                        this.GroupCode.Visible = false;
                                        this.GroupName.Visible = false;
                                        this.BLGoodsCode.Visible = true;
                                        this.BLGoodsName.Visible = true;
                                        this.BLGoodsCode.Left = this.GroupCode.Left;
                                        this.BLGoodsName.Left = this.GroupName.Left;
                                        // 品番
                                        this.GoodsNo.Visible = true;
                                        // 品名
                                        this.GoodsName.Visible = true;
                                        // BLｺｰﾄﾞ
                                        this.tb_BLGoodsCd.Visible = false;
                                        this.tb_BLGoodsNm.Visible = false;
                                        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                        this.tb_GroupCd.Visible = false;
                                        this.tb_GroupNm.Visible = false;
                                        // BLｺｰﾄﾞ計のDataField
                                        this.BLGroupHeader.DataField = "BLGoodsCode";
                                    }
                                    // BLｺｰﾄﾞ計
                                    this.BLGroupHeader.Visible = true;
                                    this.BLGroupFooter.Visible = true;
                                    break;
                                }
                            case 1: // BLｺｰﾄﾞ
                                {
                                    this.CustomerHeader.Visible = false;
                                    this.CustomerHeader.DataField = "";
                                    this.EmployeeHeader.Visible = false;
                                    this.EmployeeHeader.DataField = "";
                                    // 印字パターン４
                                    this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                    // 品番
                                    this.Lb_GoodsNo.Visible = false;
                                    // 品名
                                    this.Lb_GoodsName.Visible = false;
                                    // BLｺｰﾄﾞ
                                    this.Tt_GroupCode.Visible = true;
                                    this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                    this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                    // 品番
                                    this.GoodsNo.Visible = false;
                                    // 品名
                                    this.GoodsName.Visible = false;
                                    // BLｺｰﾄﾞ
                                    this.tb_BLGoodsCd.Visible = true;
                                    this.tb_BLGoodsNm.Visible = true;
                                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                    this.tb_GroupCd.Visible = false;
                                    this.tb_GroupCd.Visible = false;
                                    this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                    this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                    // BLｺｰﾄﾞ計
                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                    this.line15.Visible = true;
                                    break;
                                }
                            case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                {
                                    this.CustomerHeader.Visible = false;
                                    this.CustomerHeader.DataField = "";
                                    this.EmployeeHeader.Visible = false;
                                    this.EmployeeHeader.DataField = "";

                                    // 印字パターン３
                                    this.Tt_GroupCode.Text = "ｸﾞﾙｰﾌﾟ";
                                    // 品番
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                    this.Tt_GroupCode.Visible = true;
                                    this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                    this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                    // 品番
                                    this.GoodsNo.Visible = false;
                                    // 品名
                                    this.GoodsName.Visible = false;
                                    // BLｺｰﾄﾞ
                                    this.tb_BLGoodsCd.Visible = false;
                                    this.tb_BLGoodsNm.Visible = false;
                                    //  ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                    this.tb_GroupCd.Visible = true;
                                    this.tb_GroupNm.Visible = true;
                                    this.tb_GroupCd.Top = this.GoodsNo.Top;
                                    this.tb_GroupNm.Top = this.GoodsNo.Top;
                                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ計
                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line15.Visible = true;
                                    break;
                                }
                        }
                        #endregion

                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                    {
                        #region 得意先別
                        this.arFooter.Visible = false;
                        this.empFooter.Visible = false;
                        // 担当者計
                        this.EmployeeHeader.Visible = false;
                        this.empHeader.Visible = false;
                        this.empFooter.Visible = false;
                        // 地区計
                        this.arFooter.Visible = false;
                        // 得意先計
                        this.CustomerHeader.Visible = true;
                        this.CustomerFooter.Visible = true;
                        this.CustomerHeader.DataField = "HeaderKey1";
                        this.label18.Visible = false;
                        this.arHeader.Visible = false;

                        #region 改頁
                        if (this._campaignRsltList.CrModeSec == 0)
                        {
                            this.SectionHeader.NewPage = NewPage.None;
                        }
                        else
                        {
                            this.SectionHeader.NewPage = NewPage.Before;
                        }
                        if (this._campaignRsltList.CrModeEmp == 0)
                        {
                            this.CustomerHeader.NewPage = NewPage.None;
                        }
                        else
                        {
                            this.CustomerHeader.NewPage = NewPage.Before;
                        }
                        #endregion                        

                        #region 印字パターン
                        // 出力順
                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 得意先、管理拠点
                            case 3:
                                {
                                    this.tb_Sort.Text = "[得意先順]";
                                    if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.textBox60.DataField = "ManageSectionCode";
                                        this.textBox63.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }
                                    // 明細単位
                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                // 小計単位
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１
                                                    this.GroupCode.Visible = true;
                                                    this.GroupName.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン２
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン４
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン３
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1: // 拠点
                                {
                                    this.CustomerHeader.Visible = false;
                                    this.CustomerFooter.Visible = false;
                                    this.SectionHeader.DataField = "AddUpSecCode";
                                    this.CustomerHeader.DataField = "AddUpSecCode";
                                    this.AreaHeader.DataField = string.Empty;
                                    this.EmployeeHeader.DataField = string.Empty;
                                    this.CustomerHeader.DataField = string.Empty;

                                    // 拠点 
                                    this.line12.Visible = true;
                                    this.label14.Visible = true;
                                    this.textBox102.Visible = true;
                                    this.textBox103.Visible = true;
                                    // 得意先
                                    this.label18.Visible = false;
                                    this.textBox122.Visible = false;
                                    this.textBox123.Visible = false;
                                    this.label14.Left = 0f;
                                    this.textBox102.Left = 0.375f;
                                    this.textBox103.Left = 0.625f;

                                    this.tb_Sort.Text = "[拠点順]";
                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン５
                                                    this.BLGroupHeader.DataField = "BLGroupCode";
                                                    this.textBox49.Visible = true;
                                                    this.textBox50.Visible = true;
                                                    this.textBox51.Visible = true;
                                                    this.textBox58.Visible = true;
                                                    this.textBox59.Visible = true;
                                                    this.textBox68.Visible = true;
                                                    this.textBox69.Visible = true;
                                                    this.textBox70.Visible = true;
                                                    this.textBox71.Visible = true;
                                                    this.textBox72.Visible = true;
                                                    this.textBox73.Visible = true;
                                                    this.textBox74.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン６
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                    this.textBox49.Visible = true;
                                                    this.textBox50.Visible = true;
                                                    this.textBox51.Visible = true;
                                                    this.textBox58.Visible = true;
                                                    this.textBox59.Visible = true;
                                                    this.textBox68.Visible = true;
                                                    this.textBox69.Visible = true;
                                                    this.textBox70.Visible = true;
                                                    this.textBox71.Visible = true;
                                                    this.textBox72.Visible = true;
                                                    this.textBox73.Visible = true;
                                                    this.textBox74.Visible = true;
                                                }
                                                this.BLGroupHeader.Visible = true;
                                                this.BLGroupFooter.Visible = true;
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン８
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン７
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2: // 得意先－拠点
                                {
                                    this.tb_Sort.Text = "[得意先－拠点順]";
                                    this.empHeader.Visible = false;
                                    this.EmployeeHeader.Visible = false;
                                    this.empFooter.Visible = false;
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerFooter.Visible = true;

                                    this.CustomerHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "CustomerCode";
                                    // CustomerFooter
                                    this.textBox124.DataField = "MonthlySalesTargetCount2";
                                    this.textBox126.DataField = "TermSalesTargetCount2";
                                    this.textBox128.DataField = "MonthlySalesTarget2";
                                    this.textBox129.DataField = "TermSalesTarget2";
                                    this.textBox132.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox133.DataField = "TermSalesTargetProfit2";

                                    this.label15.Left = this.label17.Left + 0.2f;
                                    this.textBox60.Left = this.textBox91.Left;
                                    this.textBox63.Left = this.textBox120.Left - 0.4f;
                                    this.label17.Left = 0f;
                                    this.textBox91.Left = 0.43f;
                                    this.textBox120.Left = 0.92f;

                                    this.SupHd_EmployeeTitle.Visible = false;
                                    this.SupHd_EmployeeCd.Visible = false;
                                    this.SupHd_EmployeeNm.Visible = false;
                                    this.SupHd_SectionTitle.Visible = false;
                                    this.SupHd_AddUpSecCode.Visible = false;
                                    this.SupHd_SectionGuideNm.Visible = false;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.CustomerHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.CustomerHeader.NewPage = NewPage.Before;
                                    }
                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン９
                                                    this.BLGroupHeader.DataField = "BLGroupCode";
                                                }
                                                else
                                                {
                                                    // 印字パターン１０
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }

                                                this.Lb_CusTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "得意先計";
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン１２
                                                this.Lb_CusTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "得意先計";
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１１
                                                this.Lb_CusTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "得意先計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        #endregion

                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                    {
                        #region 担当者別

                        this.arFooter.Visible = false;
                        this.CustomerHeader.Visible = false;
						this.empFooter.Visible = true;
                        this.arHeader.Visible = false;
                        
                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 担当者、管理拠点
                            case 3:
                                {
                                    this.CustomerHeader.Visible = false;
                                    
                                    this.tb_Sort.Text = "[担当者順]";
                                    if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１
                                                }
                                                else
                                                {
                                                    // 印字パターン２
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン４
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line13.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン３
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line13.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1: // 得意先
                                {
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 拠点
                                    this.label15.Visible = false;
                                    this.textBox60.Visible = false;
                                    this.textBox63.Visible = false;
                                    // 得意先
                                    this.label17.Left = 0F;
                                    this.textBox91.Left = 0.458F;
                                    this.textBox120.Left = 1.021F;

                                    this.tb_Sort.Text = "[得意先順]";

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン５
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン６
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン８
                                                this.CustomerFooter.Visible = true;
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン７
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2: // 担当者－拠点
                                {
                                    this.tb_Sort.Text = "[担当者－拠点順]";
                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "EmployeeCode";
                                    this.CustomerHeader.Visible = false;
                                    // empFooter
                                    this.textBox10.DataField = "MonthlySalesTargetCount2";
                                    this.textBox11.DataField = "TermSalesTargetCount2";
                                    this.grGoalsCount.DataField = "MonthlySalesTarget2";
                                    this.suTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox47.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox46.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox15.DataField = "MonthlySalesTargetCount2";
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox32.DataField = "MonthlySalesTarget2";
                                    this.seTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox29.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox27.DataField = "TermSalesTargetProfit2";
                                    
                                    this.SupHd_EmployeeTitle.Left = 0F; 
                                    this.SupHd_EmployeeCd.Left = 0.438F;
                                    this.SupHd_EmployeeNm.Left = 0.75F;
                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.813F;
                                    this.SupHd_SectionGuideNm.Left = 3F;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {  
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン９
                                                    this.Lb_EmpTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "担当者計";
                                                }
                                                else
                                                {
                                                    // 印字パターン１０
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.Lb_EmpTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "担当者計";
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン１２
                                                this.Lb_EmpTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "担当者計";
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line13.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１１
                                                this.Lb_EmpTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "担当者計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line13.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachPrinter:// 発行者別
                    {
                        #region 発行者別
                        this.SupHd_EmployeeTitle.Text = "発行者";
                        this.Lb_EmpTotal.Text = "発行者計";
                        // 得意先計
                        this.CustomerHeader.Visible = false;
                        this.CustomerFooter.Visible = false;
                        this.arFooter.Visible = false;
                        this.empFooter.Visible = true;
                        this.arHeader.Visible = false;
                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 発行者、管理拠点
                            case 3:
                                {
                                    this.tb_Sort.Text = "[発行者順]";
                                    if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１
                                                }
                                                else
                                                {
                                                    // 印字パターン２
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン４
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line13.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン３
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line13.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1: // 得意先
                                {
                                    this.tb_Sort.Text = "[得意先順]";
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 拠点
                                    this.label15.Visible = false;
                                    this.textBox60.Visible = false;
                                    this.textBox63.Visible = false;
                                    // 得意先
                                    this.label17.Left = 0F;
                                    this.textBox91.Left = 0.458F;
                                    this.textBox120.Left = 1.021F;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン５
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン６
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン８
                                                this.CustomerFooter.Visible = true;
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン７
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2: // 発行者－拠点
                                {
                                    this.tb_Sort.Text = "[発行者－拠点順]";

                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "EmployeeCode";
                                    this.CustomerHeader.Visible = false;
                                    // empFooter
                                    this.textBox10.DataField = "MonthlySalesTargetCount2";
                                    this.textBox11.DataField = "TermSalesTargetCount2";
                                    this.grGoalsCount.DataField = "MonthlySalesTarget2";
                                    this.suTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox47.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox46.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox15.DataField = "MonthlySalesTargetCount2";
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox32.DataField = "MonthlySalesTarget2";
                                    this.seTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox29.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox27.DataField = "TermSalesTargetProfit2";

                                    this.SupHd_EmployeeTitle.Left = 0F;
                                    this.SupHd_EmployeeCd.Left = 0.438F;
                                    this.SupHd_EmployeeNm.Left = 0.75F;
                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.813F;
                                    this.SupHd_SectionGuideNm.Left = 3F;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン９
                                                    this.Lb_EmpTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "発行者計";
                                                }
                                                else
                                                {
                                                    // 印字パターン１０
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.Lb_EmpTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "発行者計";
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン１２
                                                this.Lb_EmpTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "発行者計";
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line13.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１１
                                                this.Lb_EmpTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "発行者計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line13.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        #endregion
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachAcceptOdr:// 受注者別
                    {
                        #region 受注者別
                        this.SupHd_EmployeeTitle.Text = "受注者";
                        this.Lb_EmpTotal.Text = "受注者計";
                        this.arFooter.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.empFooter.Visible = true;
                        this.arHeader.Visible = false;                        

                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 受注者、管理拠点
                            case 3:
                                {
                                	this.CustomerHeader.Visible = false;
                                	
                                    this.tb_Sort.Text = "[受注者順]";
                                    if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１
                                                }
                                                else
                                                {
                                                    // 印字パターン２
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン４
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line13.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン３
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line13.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1: // 得意先
                                {
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 拠点
                                    this.label15.Visible = false;
                                    this.textBox60.Visible = false;
                                    this.textBox63.Visible = false;
                                    // 得意先
                                    this.label17.Left = 0F;
                                    this.textBox91.Left = 0.458F;
                                    this.textBox120.Left = 1.021F;
                                    this.tb_Sort.Text = "[得意先順]";

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン５
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン６
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン８
                                                this.CustomerFooter.Visible = true;
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン７
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2: // 受注者－拠点
                                {
                                	this.CustomerHeader.Visible = false;
                                	
                                    this.tb_Sort.Text = "[受注者－拠点順]";
                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "EmployeeCode";
                                    this.CustomerHeader.Visible = false;
                                    // empFooter
                                    this.textBox10.DataField = "MonthlySalesTargetCount2";
                                    this.textBox11.DataField = "TermSalesTargetCount2";
                                    this.grGoalsCount.DataField = "MonthlySalesTarget2";
                                    this.suTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox47.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox46.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox15.DataField = "MonthlySalesTargetCount2";
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox32.DataField = "MonthlySalesTarget2";
                                    this.seTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox29.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox27.DataField = "TermSalesTargetProfit2";

                                    this.SupHd_EmployeeTitle.Left = 0F;
                                    this.SupHd_EmployeeCd.Left = 0.438F;
                                    this.SupHd_EmployeeNm.Left = 0.75F;
                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.813F;
                                    this.SupHd_SectionGuideNm.Left = 3F;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.empHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.empHeader.NewPage = NewPage.Before;
                                    }

                                    if (this._campaignRsltList.CrModeEmp == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン９
                                                    this.Lb_EmpTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "受注者計";
                                                }
                                                else
                                                {
                                                    // 印字パターン１０
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.Lb_EmpTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "受注者計";
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン１２
                                                this.Lb_EmpTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "受注者計";
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line13.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１１
                                                this.Lb_EmpTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "受注者計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line13.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachArea:// 地区別
                    {
                        #region 地区別
                        // 得意先計
                        this.CustomerHeader.Visible = false;
                        this.CustomerFooter.Visible = false;
                        // 担当者計
                        this.EmployeeHeader.Visible = false;
                        this.empHeader.Visible = false;
                        this.empFooter.Visible = false;
                        // 地区
                        this.AreaHeader.Visible = true;
                        this.arFooter.Visible = true;                        

                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 地区、管理拠点
                            case 3:
                                {
                                    this.tb_Sort.Text = "[地区順]";
                                    if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.ArHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.ArHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    if (this._campaignRsltList.CrModeArea == 0)
                                    {
                                        this.arHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.arHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１
                                                }
                                                else
                                                {
                                                    // 印字パターン２
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン４
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line14.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン３
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 1: // 得意先
                                {
                                    this.tb_Sort.Text = "[得意先順]"; 
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 拠点
                                    this.label15.Visible = false;
                                    this.textBox60.Visible = false;
                                    this.textBox63.Visible = false;
                                    // 得意先
                                    this.label17.Left = 0F;
                                    this.textBox91.Left = 0.458F;
                                    this.textBox120.Left = 1.021F;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    if (this._campaignRsltList.CrModeArea == 0)
                                    {
                                        this.arHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.arHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン５
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン６
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン８
                                                this.CustomerFooter.Visible = true;
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン７
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line16.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2: // 地区－拠点
                                {
                                    this.tb_Sort.Text = "[地区－拠点順]";
                                    this.arHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "AreaCode";
                                    // AreaFooter
                                    this.textBox104.DataField = "MonthlySalesTargetCount2";
                                    this.textBox121.DataField = "TermSalesTargetCount2";
                                    this.textBox112.DataField = "MonthlySalesTarget2";
                                    this.arTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox117.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox116.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox15.DataField = "MonthlySalesTargetCount2";
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox32.DataField = "MonthlySalesTarget2";
                                    this.seTotalSalesCount.DataField = "TermSalesTarget2";
                                    this.textBox29.DataField = "MonthlySalesTargetProfit2";
                                    this.textBox27.DataField = "TermSalesTargetProfit2";

                                    this.ArHd_AreaTitle.Left = 0F;
                                    this.ArHd_AreaTitle.Alignment = TextAlignment.Left;
                                    this.ArHd_AreaCd.Left = 0.33F;
                                    this.ArHd_AreaNm.Left = 0.643F;
                                    this.ArHd_SectionTitle.Left = 2.5F;
                                    this.ArHd_AddUpSecCode.Left = 2.875F;
                                    this.ArHd_SectionGuideNm.Left = 3.125F;

                                    #region 改頁
                                    if (this._campaignRsltList.CrModeSec == 0)
                                    {
                                        this.arHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.arHeader.NewPage = NewPage.Before;
                                    }
                                    if (this._campaignRsltList.CrModeArea == 0)
                                    {
                                        this.SectionHeader.NewPage = NewPage.None;
                                    }
                                    else
                                    {
                                        this.SectionHeader.NewPage = NewPage.Before;
                                    }
                                    #endregion

                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン９
                                                    this.Lb_AreaTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "地区計";
                                                }
                                                else
                                                {
                                                    // 印字パターン１０
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                                    this.GroupCode.Visible = false;
                                                    this.GroupName.Visible = false;
                                                    this.BLGoodsCode.Visible = true;
                                                    this.BLGoodsName.Visible = true;
                                                    this.BLGoodsCode.Left = this.GroupCode.Left;
                                                    this.BLGoodsName.Left = this.GroupName.Left;
                                                    this.Lb_AreaTotal.Text = "拠点計";
                                                    this.Lb_SecTotal.Text = "地区計";
                                                    this.BLGroupHeader.DataField = "BLGoodsCode";
                                                }
                                                break;
                                            }
                                        case 1: // BLｺｰﾄﾞ
                                            {
                                                // 印字パターン１２
                                                this.Lb_AreaTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "地区計";
                                                this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                                this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１１
                                                this.Lb_AreaTotal.Text = "拠点計";
                                                this.Lb_SecTotal.Text = "地区計";
                                                this.Lb_GoodsNo.Visible = false;
                                                this.Lb_GoodsName.Visible = false;
                                                this.Tt_GroupCode.Visible = true;
                                                this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                                this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = this.GoodsNo.Top;
                                                this.tb_GroupNm.Top = this.GoodsNo.Top;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        #endregion
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                    {
                        #region [販売区分別]
                        this.empFooter.Visible = true;
                        this.arFooter.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.arHeader.Visible = false;

                        this.tb_Sort.Text = string.Empty;

                        this.SupHd_EmployeeTitle.Text = "販売区分";
                        this.SupHd_EmployeeTitle.Width = 0.48F;
                        this.SupHd_EmployeeTitle.Left = 1.82F;
                        this.Lb_EmpTotal.Text = "販売区分計";

                        if (this._campaignRsltList.CrModeSec == 0)
                        {
                            this.SectionHeader.NewPage = NewPage.None;
                        }
                        this.empHeader.NewPage = NewPage.None;                        

                        switch (this._campaignRsltList.Detail)
                        {
                            case 0: // 品番
                                {
                                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                    if (this._campaignRsltList.Total == 0)
                                    {
                                        // 印字パターン１
                                    }
                                    else
                                    {
                                        // 印字パターン２
                                        this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                        this.Lb_BLTotal.Text = "BLｺｰﾄﾞ計";
                                        this.GroupCode.Visible = false;
                                        this.GroupName.Visible = false;
                                        this.BLGoodsCode.Visible = true;
                                        this.BLGoodsName.Visible = true;
                                        this.BLGoodsCode.Left = this.GroupCode.Left;
                                        this.BLGoodsName.Left = this.GroupName.Left;
                                    }
                                    break;
                                }
                            case 1: // BLｺｰﾄﾞ
                                {
                                    // 印字パターン４
                                    this.Tt_GroupCode.Text = "BLｺｰﾄﾞ";
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Tt_GroupCode.Visible = true;
                                    this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                    this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                    this.GoodsNo.Visible = false;
                                    this.GoodsName.Visible = false;
                                    this.tb_BLGoodsCd.Visible = true;
                                    this.tb_BLGoodsNm.Visible = true;
                                    this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                    this.tb_BLGoodsNm.Top = this.GoodsNo.Top;
                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line13.Visible = true;
                                    break;
                                }
                            case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                {
                                    // 印字パターン３
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Tt_GroupCode.Visible = true;
                                    this.Tt_GroupCode.Left = this.Lb_GoodsNo.Left;
                                    this.Tt_GroupCode.Top = this.Lb_GoodsNo.Top;
                                    this.GoodsNo.Visible = false;
                                    this.GoodsName.Visible = false;
                                    this.tb_GroupCd.Visible = true;
                                    this.tb_GroupNm.Visible = true;
                                    this.tb_GroupCd.Top = this.GoodsNo.Top;
                                    this.tb_GroupNm.Top = this.GoodsNo.Top;
                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line13.Visible = true;
                                    break;
                                }
                        }
                        
                        #endregion
                    }
                    break;

                default:
                    break;
            }
            #endregion

            #region 印刷タイプ
            if (this._campaignRsltList.PrintType == 2)
            {
                this.label1.Text = "[上段：対象日付期間/下段：期間累計]";

                switch (this._campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                        {
                            if (this._campaignRsltList.Detail != 0)
                            {
                                // 数量目標と達成率
                                this.textBox75.Visible = false;
                                this.textBox77.Visible = false;
                                this.textBox79.Visible = false;
                                this.textBox81.Visible = false;
                                this.textBox83.Visible = false;
                                this.textBox85.Visible = false;
                                this.textBox76.Visible = true;
                                this.textBox78.Visible = true;
                                this.textBox80.Visible = true;
                                this.textBox82.Visible = true;
                                this.textBox84.Visible = true;
                                this.textBox86.Visible = true;
                            }
                            else
                            {
                                // 数量目標と達成率
                                this.textBox75.Visible = false;
                                this.textBox77.Visible = false;
                                this.textBox79.Visible = false;
                                this.textBox81.Visible = false;
                                this.textBox83.Visible = false;
                                this.textBox85.Visible = false;
                                this.textBox76.Visible = false;
                                this.textBox78.Visible = false;
                                this.textBox80.Visible = false;
                                this.textBox82.Visible = false;
                                this.textBox84.Visible = false;
                                this.textBox86.Visible = false;
                            }
                            // ｸﾞﾙｰﾌﾟ計
                            this.textBox49.Visible = false;
                            this.textBox50.Visible = false;
                            this.textBox59.Visible = false;
                            this.textBox69.Visible = false;
                            this.textBox71.Visible = false;
                            this.textBox73.Visible = false;
                            this.textBox51.Visible = true;
                            this.textBox58.Visible = true;
                            this.textBox68.Visible = true;
                            this.textBox70.Visible = true;
                            this.textBox72.Visible = true;
                            this.textBox74.Visible = true;
                            // 拠点計
                            this.textBox15.Visible = false;
                            this.textBox5.Visible = false;
                            this.textBox32.Visible = false;
                            this.textBox34.Visible = false;
                            this.textBox29.Visible = false;
                            this.textBox57.Visible = false;
                            // 総合計
                            this.textBox22.Visible = false;
                            this.textBox4.Visible = false;
                            this.textBox31.Visible = false;
                            this.textBox33.Visible = false;
                            this.textBox26.Visible = false;
                            this.textBox54.Visible = false;
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                        {
                            if (this._campaignRsltList.OutputSort == 1 && this._campaignRsltList.Detail != 0)
                            {
                                // 数量目標と達成率
                                this.textBox75.Visible = false;
                                this.textBox77.Visible = false;
                                this.textBox79.Visible = false;
                                this.textBox81.Visible = false;
                                this.textBox83.Visible = false;
                                this.textBox85.Visible = false;
                                this.textBox76.Visible = true;
                                this.textBox78.Visible = true;
                                this.textBox80.Visible = true;
                                this.textBox82.Visible = true;
                                this.textBox84.Visible = true;
                                this.textBox86.Visible = true;
                            }
                            else if (this._campaignRsltList.OutputSort == 1 && this._campaignRsltList.Detail == 0)
                            {
                                // 数量目標と達成率
                                this.textBox75.Visible = false;
                                this.textBox77.Visible = false;
                                this.textBox79.Visible = false;
                                this.textBox81.Visible = false;
                                this.textBox83.Visible = false;
                                this.textBox85.Visible = false;
                                this.textBox76.Visible = false;
                                this.textBox78.Visible = false;
                                this.textBox80.Visible = false;
                                this.textBox82.Visible = false;
                                this.textBox84.Visible = false;
                                this.textBox86.Visible = false;

                                // ｸﾞﾙｰﾌﾟ計
                                this.textBox49.Visible = false;
                                this.textBox50.Visible = false;
                                this.textBox59.Visible = false;
                                this.textBox69.Visible = false;
                                this.textBox71.Visible = false;
                                this.textBox73.Visible = false;
                                this.textBox51.Visible = true;
                                this.textBox58.Visible = true;
                                this.textBox68.Visible = true;
                                this.textBox70.Visible = true;
                                this.textBox72.Visible = true;
                                this.textBox74.Visible = true;
                            }
                            else
                            {
                                // 数量目標と達成率
                                this.textBox75.Visible = false;
                                this.textBox77.Visible = false;
                                this.textBox79.Visible = false;
                                this.textBox81.Visible = false;
                                this.textBox83.Visible = false;
                                this.textBox85.Visible = false;
                                this.textBox76.Visible = false;
                                this.textBox78.Visible = false;
                                this.textBox80.Visible = false;
                                this.textBox82.Visible = false;
                                this.textBox84.Visible = false;
                                this.textBox86.Visible = false;
                                // ｸﾞﾙｰﾌﾟ計
                                this.textBox49.Visible = false;
                                this.textBox50.Visible = false;
                                this.textBox59.Visible = false;
                                this.textBox69.Visible = false;
                                this.textBox71.Visible = false;
                                this.textBox73.Visible = false;
                                this.textBox51.Visible = false;
                                this.textBox58.Visible = false;
                                this.textBox68.Visible = false;
                                this.textBox70.Visible = false;
                                this.textBox72.Visible = false;
                                this.textBox74.Visible = false;
                            }
                            // 得意先計
                            this.textBox124.Visible = false;
                            this.textBox125.Visible = false;
                            this.textBox128.Visible = false;
                            this.textBox130.Visible = false;
                            this.textBox132.Visible = false;
                            this.textBox135.Visible = false;
                            this.textBox126.Visible = true;
                            this.textBox127.Visible = true;
                            this.textBox129.Visible = true;
                            this.textBox131.Visible = true;
                            this.textBox133.Visible = true;
                            this.textBox134.Visible = true;
                            // 拠点計
                            this.textBox15.Visible = false;
                            this.textBox5.Visible = false;
                            this.textBox32.Visible = false;
                            this.textBox34.Visible = false;
                            this.textBox29.Visible = false;
                            this.textBox57.Visible = false;
                            // 総合計
                            this.textBox22.Visible = false;
                            this.textBox4.Visible = false;
                            this.textBox31.Visible = false;
                            this.textBox33.Visible = false;
                            this.textBox26.Visible = false;
                            this.textBox54.Visible = false;
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachEmployee:// 担当者別
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr:// 受注者別
                    case CampaignRsltList.TotalTypeState.EachPrinter:// 発行者別
                        {
                            this.textBox10.Visible = false;
                            this.textBox48.Visible = false;
                            this.grGoalsCount.Visible = false;
                            this.textBox35.Visible = false;
                            this.textBox47.Visible = false;
                            this.textBox52.Visible = false;
                            this.textBox15.Visible = false;
                            this.textBox5.Visible = false;
                            this.textBox32.Visible = false;
                            this.textBox34.Visible = false;
                            this.textBox29.Visible = false;
                            this.textBox57.Visible = false;
                            this.textBox22.Visible = false;
                            this.textBox4.Visible = false;
                            this.textBox31.Visible = false;
                            this.textBox33.Visible = false;
                            this.textBox26.Visible = false;
                            this.textBox54.Visible = false;
                        }
                        break;

                    case CampaignRsltList.TotalTypeState.EachArea:// 地区別
                        {
                            // 地区計
                            textBox104.Visible = false;
                            textBox109.Visible = false;
                            textBox112.Visible = false;
                            textBox113.Visible = false;
                            textBox117.Visible = false;
                            textBox119.Visible = false;

                            // 拠点計
                            textBox15.Visible = false;
                            textBox5.Visible = false;
                            textBox32.Visible = false;
                            textBox34.Visible = false;
                            textBox29.Visible = false;
                            textBox57.Visible = false;

                            // 総合計
                            textBox22.Visible = false;
                            textBox4.Visible = false;
                            textBox31.Visible = false;
                            textBox33.Visible = false;
                            textBox26.Visible = false;
                            textBox54.Visible = false;
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                        {
                            this.textBox10.Visible = false;
                            this.textBox48.Visible = false;
                            this.grGoalsCount.Visible = false;
                            this.textBox35.Visible = false;
                            this.textBox47.Visible = false;
                            this.textBox52.Visible = false;
                            this.textBox15.Visible = false;
                            this.textBox5.Visible = false;
                            this.textBox32.Visible = false;
                            this.textBox34.Visible = false;
                            this.textBox29.Visible = false;
                            this.textBox57.Visible = false;
                            this.textBox22.Visible = false;
                            this.textBox4.Visible = false;
                            this.textBox31.Visible = false;
                            this.textBox33.Visible = false;
                            this.textBox26.Visible = false;
                            this.textBox54.Visible = false;
                        }
                        break;
                }  
            }
            else
            {
            	this.label1.Text = "[上段：当月/下段：期間累計]";
                switch (this._campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                        {
                            // 印刷タイプ:当月、かつ明細単位「品番」以外
                            if (this._campaignRsltList.PrintType == 0 && this._campaignRsltList.Detail != 0)
                            {
                                // 拠点用数量目標と達成率
                                this.textBox75.Visible = true;
                                this.textBox77.Visible = true;
                                this.textBox79.Visible = true;
                                this.textBox81.Visible = true;
                                this.textBox83.Visible = true;
                                this.textBox85.Visible = true;
                                this.textBox76.Visible = true;
                                this.textBox78.Visible = true;
                                this.textBox80.Visible = true;
                                this.textBox82.Visible = true;
                                this.textBox84.Visible = true;
                                this.textBox86.Visible = true;
                            }
                            else 
                            {
                                // 数量目標と達成率
                                this.textBox75.Visible = false;
                                this.textBox77.Visible = false;
                                this.textBox79.Visible = false;
                                this.textBox81.Visible = false;
                                this.textBox83.Visible = false;
                                this.textBox85.Visible = false;
                                this.textBox76.Visible = false;
                                this.textBox78.Visible = false;
                                this.textBox80.Visible = false;
                                this.textBox82.Visible = false;
                                this.textBox84.Visible = false;
                                this.textBox86.Visible = false;
                            }
                            // ｸﾞﾙｰﾌﾟ計
                            this.textBox49.Visible = true;
                            this.textBox50.Visible = true;
                            this.textBox59.Visible = true;
                            this.textBox69.Visible = true;
                            this.textBox71.Visible = true;
                            this.textBox73.Visible = true;
                            this.textBox51.Visible = true;
                            this.textBox58.Visible = true;
                            this.textBox68.Visible = true;
                            this.textBox70.Visible = true;
                            this.textBox72.Visible = true;
                            this.textBox74.Visible = true;
                            // 拠点計
                            this.textBox15.Visible = true;
                            this.textBox5.Visible = true;
                            this.textBox32.Visible = true;
                            this.textBox34.Visible = true;
                            this.textBox29.Visible = true;
                            this.textBox57.Visible = true;
                            // 総合計
                            this.textBox22.Visible = true;
                            this.textBox4.Visible = true;
                            this.textBox31.Visible = true;
                            this.textBox33.Visible = true;
                            this.textBox26.Visible = true;
                            this.textBox54.Visible = true;
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                        {
                            if (this._campaignRsltList.OutputSort == 1)
                            {
                                // 印刷タイプ:当月、かつ明細単位「品番」以外
                                if (this._campaignRsltList.PrintType == 0 && this._campaignRsltList.Detail != 0)
                                {
                                    // 拠点用数量目標と達成率
                                    this.textBox75.Visible = true;
                                    this.textBox77.Visible = true;
                                    this.textBox79.Visible = true;
                                    this.textBox81.Visible = true;
                                    this.textBox83.Visible = true;
                                    this.textBox85.Visible = true;
                                    this.textBox76.Visible = true;
                                    this.textBox78.Visible = true;
                                    this.textBox80.Visible = true;
                                    this.textBox82.Visible = true;
                                    this.textBox84.Visible = true;
                                    this.textBox86.Visible = true;
                                }
                                else
                                {
                                    // 数量目標と達成率
                                    this.textBox75.Visible = false;
                                    this.textBox77.Visible = false;
                                    this.textBox79.Visible = false;
                                    this.textBox81.Visible = false;
                                    this.textBox83.Visible = false;
                                    this.textBox85.Visible = false;
                                    this.textBox76.Visible = false;
                                    this.textBox78.Visible = false;
                                    this.textBox80.Visible = false;
                                    this.textBox82.Visible = false;
                                    this.textBox84.Visible = false;
                                    this.textBox86.Visible = false;
                                }
                            }
                            // 得意先計
                            this.textBox124.Visible = true;
                            this.textBox125.Visible = true;
                            this.textBox128.Visible = true;
                            this.textBox130.Visible = true;
                            this.textBox132.Visible = true;
                            this.textBox135.Visible = true;
                            this.textBox126.Visible = true;
                            this.textBox127.Visible = true;
                            this.textBox129.Visible = true;
                            this.textBox131.Visible = true;
                            this.textBox133.Visible = true;
                            this.textBox134.Visible = true;
                        }
                        break;
                }
            }
            #endregion
        }

		#endregion ◆ レポート要素出力設定

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        /// <remarks>
        /// <br>Note		: 率取得処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// <br></br>
        /// </remarks>
        private double GetRatio(object numerator, object denominator)
        {
            double workRate;
            double numeratorD = Convert.ToDouble(numerator);
            double denominatorD = Convert.ToDouble(denominator);

            if (denominatorD == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numeratorD / denominatorD) * 100;
            }

            return workRate;
        }


		#endregion

		#region ■ Control Event

		#region ◎ MAZAI02032P_01A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
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
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
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
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            this.Detail.Height = 0.40f;
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
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
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
		/// <br>Programmer  : 田建委</br>
		/// <br>Date		: 2011/05/19</br>
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
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
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

        /// <summary>
        /// BLGroupFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void BLGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率
            this.grProfitRatio1.Value = this.GetRatio(this.textBox38.Value, this.grSalesMoney1.Value);
            this.grProfitRatio2.Value = this.GetRatio(this.textBox39.Value, this.grSalesMoney2.Value);

            // 数量達成率
            this.textBox50.Value = this.GetRatio(this.grSalesCount1.Value, this.textBox49.Value);
            this.textBox58.Value = this.GetRatio(this.grSalesCount2.Value, this.textBox51.Value);
            
            // 売上達成率
            this.textBox69.Value = this.GetRatio(this.grSalesMoney1.Value, this.textBox59.Value);
            this.textBox70.Value = this.GetRatio(this.grSalesMoney2.Value, this.textBox68.Value);
            
            // 粗利達成率
            this.textBox73.Value = this.GetRatio(this.textBox38.Value, this.textBox71.Value);
            this.textBox74.Value = this.GetRatio(this.textBox39.Value, this.textBox72.Value);
            
        }

        /// <summary>
        /// CustomerFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: CustomerFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void CustomerFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率
            this.cuProfitRatio1.Value = this.GetRatio(this.textBox66.Value, this.textBox61.Value);
            this.cuProfitRatio2.Value = this.GetRatio(this.textBox67.Value, this.textBox62.Value);
            // 数量達成率
            this.textBox125.Value = this.GetRatio(this.textBox64.Value, this.textBox124.Value);
            this.textBox127.Value = this.GetRatio(this.textBox65.Value, this.textBox126.Value);
            
            // 売上達成率
            this.textBox130.Value = this.GetRatio(this.textBox61.Value, this.textBox128.Value);
            this.textBox131.Value = this.GetRatio(this.textBox62.Value, this.textBox129.Value);
            
            // 粗利達成率
            this.textBox135.Value = this.GetRatio(this.textBox66.Value, this.textBox132.Value);
            this.textBox134.Value = this.GetRatio(this.textBox67.Value, this.textBox133.Value);
            
        }

        /// <summary>
        /// empFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: empFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void empFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率
            this.suProfitRatio.Value = this.GetRatio(this.textBox45.Value, this.textBox6.Value);
            this.textBox25.Value = this.GetRatio(this.textBox44.Value, this.textBox7.Value);
            // 数量達成率
            this.textBox48.Value = this.GetRatio(this.textBox9.Value, this.textBox10.Value);
            this.textBox3.Value = this.GetRatio(this.textBox12.Value, this.textBox11.Value);
            
            // 売上達成率
            this.textBox35.Value = this.GetRatio(this.textBox6.Value, this.grGoalsCount.Value);
            this.suCmpPureSalesRatio.Value = this.GetRatio(this.textBox7.Value, this.suTotalSalesCount.Value);
            
            // 粗利達成率
            this.textBox52.Value = this.GetRatio(this.textBox45.Value, this.textBox47.Value);
            this.textBox53.Value = this.GetRatio(this.textBox44.Value, this.textBox46.Value);
            
        }

        /// <summary>
        /// SectionFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: SectionFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率
            this.seProfitRatio.Value = this.GetRatio(this.textBox43.Value, this.textBox8.Value);
            this.textBox28.Value = this.GetRatio(this.textBox42.Value, this.textBox21.Value);
            // 数量達成率
            this.textBox5.Value = this.GetRatio(this.textBox14.Value, this.textBox15.Value);
            this.textBox2.Value = this.GetRatio(this.textBox17.Value, this.textBox13.Value);
            
            // 売上達成率
            this.textBox34.Value = this.GetRatio(this.textBox8.Value, this.textBox32.Value);
            this.seCmpPureSalesRatio.Value = this.GetRatio(this.textBox21.Value, this.seTotalSalesCount.Value);
            
            // 粗利達成率
            this.textBox57.Value = this.GetRatio(this.textBox43.Value, this.textBox29.Value);
            this.textBox56.Value = this.GetRatio(this.textBox42.Value, this.textBox27.Value);
            
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: GrandTotalFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率
            this.toProfitRatio.Value = this.GetRatio(this.textBox41.Value, this.textBox23.Value);
            this.textBox30.Value = this.GetRatio(this.textBox40.Value, this.textBox24.Value);
            // 数量達成率
            this.textBox4.Value = this.GetRatio(this.textBox19.Value, this.textBox22.Value);
            this.textBox1.Value = this.GetRatio(this.textBox20.Value, this.textBox18.Value);
            
            // 売上達成率
            this.textBox33.Value = this.GetRatio(this.textBox23.Value, this.textBox31.Value);
            this.toCmpPureSalesRatio.Value = this.GetRatio(this.textBox24.Value, this.toTotalSalesCount.Value);
            
            // 粗利達成率
            this.textBox54.Value = this.GetRatio(this.textBox41.Value, this.textBox26.Value);
            this.textBox55.Value = this.GetRatio(this.textBox40.Value, this.textBox16.Value);
            
        }

        /// <summary>
        /// AreaFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: AreaFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 丁建雄</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void AreaFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率
            this.arProfitRatio.Value = this.GetRatio(this.textBox115.Value, this.textBox110.Value);
            this.textBox105.Value = this.GetRatio(this.textBox114.Value, this.textBox111.Value);

            // 数量達成率
            this.textBox109.Value = this.GetRatio(this.textBox106.Value, this.textBox104.Value);
            this.textBox108.Value = this.GetRatio(this.textBox107.Value, this.textBox121.Value);            

            // 売上達成率
            this.textBox113.Value = this.GetRatio(this.textBox110.Value, this.textBox112.Value);
            this.arCmpPureSalesRatio.Value = this.GetRatio(this.textBox111.Value, this.arTotalSalesCount.Value);            

            // 粗利達成率
            this.textBox119.Value = this.GetRatio(this.textBox115.Value, this.textBox117.Value);
            this.textBox118.Value = this.GetRatio(this.textBox114.Value, this.textBox116.Value);            
        }
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
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox GroupName;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotalTitle;
        private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        private Label Lb_MakerCode;
        private TextBox GroupCode;
        private Label Lb_SalesCount;
        private TextBox GoodsNo;
        private Label Lb_GoodsNo;
        private GroupHeader EmployeeHeader;
        private GroupFooter EmployeeFooter;
        private TextBox MakerCode;
        private TextBox SalesCount1;
        private Label Lb_GoodsName;
        private TextBox BLGoodsCode;
        private TextBox BLGoodsName;
        private TextBox SalesMoney1;
        private TextBox ProfitRatio1;
        private TextBox MakerName;
        private TextBox GoodsName;
        private Label Lb_SalesMoney;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox seTotalSalesCount;
        private TextBox seCmpPureSalesRatio;
        private TextBox seProfitRatio;
        private TextBox toTotalSalesCount;
        private TextBox toCmpPureSalesRatio;
        private TextBox toProfitRatio;
        private GroupHeader BLGroupHeader;
        private GroupFooter BLGroupFooter;
        private Line line8;
        private TextBox grProfitRatio1;
        private TextBox SupHd_AddUpSecCode;
        private TextBox SupHd_SectionGuideNm;
        private TextBox SupHd_EmployeeCd;
        private TextBox SupHd_EmployeeNm;
        private Label SupHd_SectionTitle;
        private Label SupHd_EmployeeTitle;
        private Line line5;
        private TextBox SalesCount2;
        private TextBox SalesMoney2;
        private TextBox ProfitRatio2;
        private TextBox textBox18;
        private TextBox textBox22;
        private TextBox textBox30;
        private TextBox textBox15;
        private TextBox textBox28;
        private TextBox grSalesMoney1;
        private TextBox grSalesMoney2;
        private TextBox grProfitRatio2;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox14;
        private TextBox textBox17;
        private TextBox grSalesCount1;
        private TextBox grSalesCount2;
        private Line line6;
        private Label label4;
        private TextBox CampaignCode;
        private TextBox CampaignName;
        private Label label5;
        private TextBox ApplyDate;
        private Label label1;
        private Label Lb_GroupCode;
        private Label label6;
        private Label label7;
        private Label label13;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox31;
        private TextBox textBox8;
        private TextBox textBox21;
        private TextBox textBox32;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox33;
        private TextBox textBox40;
        private TextBox textBox41;
        private TextBox textBox34;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox textBox38;
        private TextBox textBox39;
        private TextBox textBox16;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox29;
        private TextBox textBox54;
        private TextBox textBox55;
        private TextBox textBox56;
        private TextBox textBox57;
        private TextBox tb_Sort;
        private TextBox tb_GroupCd;
        private TextBox tb_GroupNm;
        private TextBox tb_BLGoodsCd;
        private TextBox tb_BLGoodsNm;
        private Label Tt_GroupCode;
        private GroupHeader CustomerHeader;
        private GroupFooter CustomerFooter;
        private Line line2;
        private TextBox cuProfitRatio1;
        private TextBox textBox61;
        private TextBox textBox62;
        private TextBox cuProfitRatio2;
        private TextBox textBox64;
        private TextBox textBox65;
        private TextBox textBox66;
        private TextBox textBox67;
        private Label Lb_SecTotal;
        private Label Lb_BLTotal;
        private Label Lb_CusTotal;   

        /// <summary>
        /// InitializeComponent
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN02052P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.MakerCode = new DataDynamics.ActiveReports.TextBox();
            this.SalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.ProfitRatio1 = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.SalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.ProfitRatio2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.tb_GroupCd = new DataDynamics.ActiveReports.TextBox();
            this.tb_GroupNm = new DataDynamics.ActiveReports.TextBox();
            this.tb_BLGoodsCd = new DataDynamics.ActiveReports.TextBox();
            this.tb_BLGoodsNm = new DataDynamics.ActiveReports.TextBox();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.textBox76 = new DataDynamics.ActiveReports.TextBox();
            this.textBox77 = new DataDynamics.ActiveReports.TextBox();
            this.textBox78 = new DataDynamics.ActiveReports.TextBox();
            this.textBox79 = new DataDynamics.ActiveReports.TextBox();
            this.textBox80 = new DataDynamics.ActiveReports.TextBox();
            this.textBox81 = new DataDynamics.ActiveReports.TextBox();
            this.textBox82 = new DataDynamics.ActiveReports.TextBox();
            this.textBox83 = new DataDynamics.ActiveReports.TextBox();
            this.textBox84 = new DataDynamics.ActiveReports.TextBox();
            this.textBox85 = new DataDynamics.ActiveReports.TextBox();
            this.textBox86 = new DataDynamics.ActiveReports.TextBox();
            this.textBox87 = new DataDynamics.ActiveReports.TextBox();
            this.textBox90 = new DataDynamics.ActiveReports.TextBox();
            this.textBox92 = new DataDynamics.ActiveReports.TextBox();
            this.textBox93 = new DataDynamics.ActiveReports.TextBox();
            this.textBox94 = new DataDynamics.ActiveReports.TextBox();
            this.textBox95 = new DataDynamics.ActiveReports.TextBox();
            this.textBox96 = new DataDynamics.ActiveReports.TextBox();
            this.textBox97 = new DataDynamics.ActiveReports.TextBox();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.textBox99 = new DataDynamics.ActiveReports.TextBox();
            this.textBox100 = new DataDynamics.ActiveReports.TextBox();
            this.textBox101 = new DataDynamics.ActiveReports.TextBox();
            this.GroupName = new DataDynamics.ActiveReports.TextBox();
            this.GroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsName = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_Sort = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_MakerCode = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesCount = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoney = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.CampaignCode = new DataDynamics.ActiveReports.TextBox();
            this.CampaignName = new DataDynamics.ActiveReports.TextBox();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.ApplyDate = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.Tt_GroupCode = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.toTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.toCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.toProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox54 = new DataDynamics.ActiveReports.TextBox();
            this.textBox55 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.textBox102 = new DataDynamics.ActiveReports.TextBox();
            this.textBox103 = new DataDynamics.ActiveReports.TextBox();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.textBox122 = new DataDynamics.ActiveReports.TextBox();
            this.textBox123 = new DataDynamics.ActiveReports.TextBox();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.seTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.seCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.seProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox56 = new DataDynamics.ActiveReports.TextBox();
            this.textBox57 = new DataDynamics.ActiveReports.TextBox();
            this.Lb_SecTotal = new DataDynamics.ActiveReports.Label();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_EmployeeCd = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_EmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_EmployeeTitle = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.EmployeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.BLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_GroupCode = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.BLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.grProfitRatio1 = new DataDynamics.ActiveReports.TextBox();
            this.grSalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.grSalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.grProfitRatio2 = new DataDynamics.ActiveReports.TextBox();
            this.grSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.grSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.Lb_BLTotal = new DataDynamics.ActiveReports.Label();
            this.textBox49 = new DataDynamics.ActiveReports.TextBox();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox51 = new DataDynamics.ActiveReports.TextBox();
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.textBox68 = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.textBox70 = new DataDynamics.ActiveReports.TextBox();
            this.textBox71 = new DataDynamics.ActiveReports.TextBox();
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.textBox73 = new DataDynamics.ActiveReports.TextBox();
            this.textBox74 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.textBox91 = new DataDynamics.ActiveReports.TextBox();
            this.textBox120 = new DataDynamics.ActiveReports.TextBox();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.cuProfitRatio1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.cuProfitRatio2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.textBox65 = new DataDynamics.ActiveReports.TextBox();
            this.textBox66 = new DataDynamics.ActiveReports.TextBox();
            this.textBox67 = new DataDynamics.ActiveReports.TextBox();
            this.Lb_CusTotal = new DataDynamics.ActiveReports.Label();
            this.textBox124 = new DataDynamics.ActiveReports.TextBox();
            this.textBox125 = new DataDynamics.ActiveReports.TextBox();
            this.textBox126 = new DataDynamics.ActiveReports.TextBox();
            this.textBox127 = new DataDynamics.ActiveReports.TextBox();
            this.textBox128 = new DataDynamics.ActiveReports.TextBox();
            this.textBox129 = new DataDynamics.ActiveReports.TextBox();
            this.textBox130 = new DataDynamics.ActiveReports.TextBox();
            this.textBox131 = new DataDynamics.ActiveReports.TextBox();
            this.textBox132 = new DataDynamics.ActiveReports.TextBox();
            this.textBox133 = new DataDynamics.ActiveReports.TextBox();
            this.textBox134 = new DataDynamics.ActiveReports.TextBox();
            this.textBox135 = new DataDynamics.ActiveReports.TextBox();
            this.AreaHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.ArHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_AreaCd = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_AreaNm = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.ArHd_AreaTitle = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.AreaFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.empHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.empFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.suTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.suCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.suProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.grGoalsCount = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox45 = new DataDynamics.ActiveReports.TextBox();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.textBox47 = new DataDynamics.ActiveReports.TextBox();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.textBox53 = new DataDynamics.ActiveReports.TextBox();
            this.Lb_EmpTotal = new DataDynamics.ActiveReports.Label();
            this.textBox48 = new DataDynamics.ActiveReports.TextBox();
            this.arHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.arFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Lb_AreaTotal = new DataDynamics.ActiveReports.Label();
            this.arCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.arProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.textBox104 = new DataDynamics.ActiveReports.TextBox();
            this.textBox105 = new DataDynamics.ActiveReports.TextBox();
            this.textBox106 = new DataDynamics.ActiveReports.TextBox();
            this.textBox107 = new DataDynamics.ActiveReports.TextBox();
            this.textBox108 = new DataDynamics.ActiveReports.TextBox();
            this.textBox109 = new DataDynamics.ActiveReports.TextBox();
            this.textBox110 = new DataDynamics.ActiveReports.TextBox();
            this.textBox111 = new DataDynamics.ActiveReports.TextBox();
            this.textBox112 = new DataDynamics.ActiveReports.TextBox();
            this.textBox113 = new DataDynamics.ActiveReports.TextBox();
            this.textBox114 = new DataDynamics.ActiveReports.TextBox();
            this.textBox115 = new DataDynamics.ActiveReports.TextBox();
            this.textBox116 = new DataDynamics.ActiveReports.TextBox();
            this.textBox117 = new DataDynamics.ActiveReports.TextBox();
            this.textBox118 = new DataDynamics.ActiveReports.TextBox();
            this.textBox119 = new DataDynamics.ActiveReports.TextBox();
            this.arTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.textBox121 = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitRatio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitRatio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tt_GroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SecTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grProfitRatio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grProfitRatio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuProfitRatio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuProfitRatio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CusTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGoalsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_EmpTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AreaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.MakerCode,
            this.SalesCount1,
            this.SalesMoney1,
            this.ProfitRatio1,
            this.MakerName,
            this.GoodsName,
            this.line5,
            this.SalesCount2,
            this.SalesMoney2,
            this.ProfitRatio2,
            this.textBox36,
            this.textBox37,
            this.tb_GroupCd,
            this.tb_GroupNm,
            this.tb_BLGoodsCd,
            this.tb_BLGoodsNm,
            this.textBox75,
            this.textBox76,
            this.textBox77,
            this.textBox78,
            this.textBox79,
            this.textBox80,
            this.textBox81,
            this.textBox82,
            this.textBox83,
            this.textBox84,
            this.textBox85,
            this.textBox86,
            this.textBox87,
            this.textBox90,
            this.textBox92,
            this.textBox93,
            this.textBox94,
            this.textBox95,
            this.textBox96,
            this.textBox97,
            this.textBox98,
            this.textBox99,
            this.textBox100,
            this.textBox101});
            this.Detail.Height = 0.7395833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.GoodsNo.Height = 0.16F;
            this.GoodsNo.Left = 0.125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "XXXXXXXXXXXXXXXXXXXXXXXX";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.4F;
            // 
            // MakerCode
            // 
            this.MakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.MakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.MakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode.DataField = "GoodsMakerCd";
            this.MakerCode.Height = 0.16F;
            this.MakerCode.Left = 2.75F;
            this.MakerCode.MultiLine = false;
            this.MakerCode.Name = "MakerCode";
            this.MakerCode.OutputFormat = resources.GetString("MakerCode.OutputFormat");
            this.MakerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.MakerCode.Text = "1234";
            this.MakerCode.Top = 0F;
            this.MakerCode.Width = 0.26F;
            // 
            // SalesCount1
            // 
            this.SalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount1.DataField = "MonthlySalesCount";
            this.SalesCount1.Height = 0.16F;
            this.SalesCount1.Left = 3.7475F;
            this.SalesCount1.MultiLine = false;
            this.SalesCount1.Name = "SalesCount1";
            this.SalesCount1.OutputFormat = resources.GetString("SalesCount1.OutputFormat");
            this.SalesCount1.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesCount1.Text = "ZZZ,ZZZ,ZZ9";
            this.SalesCount1.Top = 0F;
            this.SalesCount1.Width = 0.64F;
            // 
            // SalesMoney1
            // 
            this.SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney1.CanShrink = true;
            this.SalesMoney1.DataField = "MonthlySalesMoney";
            this.SalesMoney1.Height = 0.16F;
            this.SalesMoney1.Left = 5.625F;
            this.SalesMoney1.MultiLine = false;
            this.SalesMoney1.Name = "SalesMoney1";
            this.SalesMoney1.OutputFormat = resources.GetString("SalesMoney1.OutputFormat");
            this.SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoney1.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.SalesMoney1.Top = 0F;
            this.SalesMoney1.Width = 0.9F;
            // 
            // ProfitRatio1
            // 
            this.ProfitRatio1.Border.BottomColor = System.Drawing.Color.Black;
            this.ProfitRatio1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio1.Border.LeftColor = System.Drawing.Color.Black;
            this.ProfitRatio1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio1.Border.RightColor = System.Drawing.Color.Black;
            this.ProfitRatio1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio1.Border.TopColor = System.Drawing.Color.Black;
            this.ProfitRatio1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio1.CanShrink = true;
            this.ProfitRatio1.DataField = "MonthlySalesProfitRate";
            this.ProfitRatio1.Height = 0.16F;
            this.ProfitRatio1.Left = 8.9375F;
            this.ProfitRatio1.MultiLine = false;
            this.ProfitRatio1.Name = "ProfitRatio1";
            this.ProfitRatio1.OutputFormat = resources.GetString("ProfitRatio1.OutputFormat");
            this.ProfitRatio1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.ProfitRatio1.Text = "ZZZ9.99";
            this.ProfitRatio1.Top = 0F;
            this.ProfitRatio1.Width = 0.45F;
            // 
            // MakerName
            // 
            this.MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.DataField = "MakerShortName";
            this.MakerName.Height = 0.16F;
            this.MakerName.Left = 3.0625F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "XXXXXXXXXX";
            this.MakerName.Top = 0F;
            this.MakerName.Width = 0.6F;
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
            this.GoodsName.Height = 0.16F;
            this.GoodsName.Left = 1.5625F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.15F;
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
            this.line5.Top = 0F;
            this.line5.Width = 10.85F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.85F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // SalesCount2
            // 
            this.SalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount2.DataField = "TermSalesCount";
            this.SalesCount2.Height = 0.16F;
            this.SalesCount2.Left = 3.7475F;
            this.SalesCount2.MultiLine = false;
            this.SalesCount2.Name = "SalesCount2";
            this.SalesCount2.OutputFormat = resources.GetString("SalesCount2.OutputFormat");
            this.SalesCount2.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesCount2.Text = "ZZZ,ZZZ,ZZ9";
            this.SalesCount2.Top = 0.1875F;
            this.SalesCount2.Width = 0.64F;
            // 
            // SalesMoney2
            // 
            this.SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney2.CanShrink = true;
            this.SalesMoney2.DataField = "TermSalesMoney";
            this.SalesMoney2.Height = 0.16F;
            this.SalesMoney2.Left = 5.625F;
            this.SalesMoney2.MultiLine = false;
            this.SalesMoney2.Name = "SalesMoney2";
            this.SalesMoney2.OutputFormat = resources.GetString("SalesMoney2.OutputFormat");
            this.SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoney2.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.SalesMoney2.Top = 0.1875F;
            this.SalesMoney2.Width = 0.9F;
            // 
            // ProfitRatio2
            // 
            this.ProfitRatio2.Border.BottomColor = System.Drawing.Color.Black;
            this.ProfitRatio2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio2.Border.LeftColor = System.Drawing.Color.Black;
            this.ProfitRatio2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio2.Border.RightColor = System.Drawing.Color.Black;
            this.ProfitRatio2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio2.Border.TopColor = System.Drawing.Color.Black;
            this.ProfitRatio2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio2.CanShrink = true;
            this.ProfitRatio2.DataField = "TermSalesProfitRate";
            this.ProfitRatio2.Height = 0.16F;
            this.ProfitRatio2.Left = 8.9375F;
            this.ProfitRatio2.MultiLine = false;
            this.ProfitRatio2.Name = "ProfitRatio2";
            this.ProfitRatio2.OutputFormat = resources.GetString("ProfitRatio2.OutputFormat");
            this.ProfitRatio2.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.ProfitRatio2.Text = "ZZZ9.99";
            this.ProfitRatio2.Top = 0.1875F;
            this.ProfitRatio2.Width = 0.45F;
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
            this.textBox36.CanShrink = true;
            this.textBox36.DataField = "MonthlySalesProfit";
            this.textBox36.Height = 0.16F;
            this.textBox36.Left = 8F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox36.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox36.Top = 0F;
            this.textBox36.Width = 0.9F;
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
            this.textBox37.CanShrink = true;
            this.textBox37.DataField = "TermSalesProfit";
            this.textBox37.Height = 0.16F;
            this.textBox37.Left = 8F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox37.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox37.Top = 0.1875F;
            this.textBox37.Width = 0.9F;
            // 
            // tb_GroupCd
            // 
            this.tb_GroupCd.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_GroupCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupCd.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_GroupCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupCd.Border.RightColor = System.Drawing.Color.Black;
            this.tb_GroupCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupCd.Border.TopColor = System.Drawing.Color.Black;
            this.tb_GroupCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupCd.DataField = "BLGroupCode";
            this.tb_GroupCd.Height = 0.16F;
            this.tb_GroupCd.Left = 0.125F;
            this.tb_GroupCd.MultiLine = false;
            this.tb_GroupCd.Name = "tb_GroupCd";
            this.tb_GroupCd.OutputFormat = resources.GetString("tb_GroupCd.OutputFormat");
            this.tb_GroupCd.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.tb_GroupCd.Text = "12345";
            this.tb_GroupCd.Top = 0.1875F;
            this.tb_GroupCd.Visible = false;
            this.tb_GroupCd.Width = 0.375F;
            // 
            // tb_GroupNm
            // 
            this.tb_GroupNm.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_GroupNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupNm.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_GroupNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupNm.Border.RightColor = System.Drawing.Color.Black;
            this.tb_GroupNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupNm.Border.TopColor = System.Drawing.Color.Black;
            this.tb_GroupNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_GroupNm.DataField = "BLGroupKanaName";
            this.tb_GroupNm.Height = 0.16F;
            this.tb_GroupNm.Left = 0.5625F;
            this.tb_GroupNm.MultiLine = false;
            this.tb_GroupNm.Name = "tb_GroupNm";
            this.tb_GroupNm.OutputFormat = resources.GetString("tb_GroupNm.OutputFormat");
            this.tb_GroupNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_GroupNm.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.tb_GroupNm.Top = 0.1875F;
            this.tb_GroupNm.Visible = false;
            this.tb_GroupNm.Width = 1.15F;
            // 
            // tb_BLGoodsCd
            // 
            this.tb_BLGoodsCd.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_BLGoodsCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsCd.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_BLGoodsCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsCd.Border.RightColor = System.Drawing.Color.Black;
            this.tb_BLGoodsCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsCd.Border.TopColor = System.Drawing.Color.Black;
            this.tb_BLGoodsCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsCd.DataField = "BLGoodsCode";
            this.tb_BLGoodsCd.Height = 0.16F;
            this.tb_BLGoodsCd.Left = 0.125F;
            this.tb_BLGoodsCd.MultiLine = false;
            this.tb_BLGoodsCd.Name = "tb_BLGoodsCd";
            this.tb_BLGoodsCd.OutputFormat = resources.GetString("tb_BLGoodsCd.OutputFormat");
            this.tb_BLGoodsCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_BLGoodsCd.Text = "12345";
            this.tb_BLGoodsCd.Top = 0.375F;
            this.tb_BLGoodsCd.Visible = false;
            this.tb_BLGoodsCd.Width = 0.35F;
            // 
            // tb_BLGoodsNm
            // 
            this.tb_BLGoodsNm.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_BLGoodsNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsNm.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_BLGoodsNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsNm.Border.RightColor = System.Drawing.Color.Black;
            this.tb_BLGoodsNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsNm.Border.TopColor = System.Drawing.Color.Black;
            this.tb_BLGoodsNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_BLGoodsNm.DataField = "BLGoodsHalfName";
            this.tb_BLGoodsNm.Height = 0.16F;
            this.tb_BLGoodsNm.Left = 0.5625F;
            this.tb_BLGoodsNm.MultiLine = false;
            this.tb_BLGoodsNm.Name = "tb_BLGoodsNm";
            this.tb_BLGoodsNm.OutputFormat = resources.GetString("tb_BLGoodsNm.OutputFormat");
            this.tb_BLGoodsNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_BLGoodsNm.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.tb_BLGoodsNm.Top = 0.375F;
            this.tb_BLGoodsNm.Visible = false;
            this.tb_BLGoodsNm.Width = 1.15F;
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
            this.textBox75.CanShrink = true;
            this.textBox75.DataField = "MonthlySalesTargetCount1";
            this.textBox75.Height = 0.16F;
            this.textBox75.Left = 4.47F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
            this.textBox75.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox75.SummaryGroup = "";
            this.textBox75.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox75.Top = 0F;
            this.textBox75.Visible = false;
            this.textBox75.Width = 0.64F;
            // 
            // textBox76
            // 
            this.textBox76.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.Border.RightColor = System.Drawing.Color.Black;
            this.textBox76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.Border.TopColor = System.Drawing.Color.Black;
            this.textBox76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.CanShrink = true;
            this.textBox76.DataField = "TermSalesTargetCount1";
            this.textBox76.Height = 0.16F;
            this.textBox76.Left = 4.47F;
            this.textBox76.MultiLine = false;
            this.textBox76.Name = "textBox76";
            this.textBox76.OutputFormat = resources.GetString("textBox76.OutputFormat");
            this.textBox76.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox76.SummaryGroup = "";
            this.textBox76.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox76.Top = 0.1875F;
            this.textBox76.Visible = false;
            this.textBox76.Width = 0.64F;
            // 
            // textBox77
            // 
            this.textBox77.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.RightColor = System.Drawing.Color.Black;
            this.textBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.TopColor = System.Drawing.Color.Black;
            this.textBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.CanShrink = true;
            this.textBox77.DataField = "MonthlySalesCountAchivRate1";
            this.textBox77.Height = 0.16F;
            this.textBox77.Left = 5.125F;
            this.textBox77.MultiLine = false;
            this.textBox77.Name = "textBox77";
            this.textBox77.OutputFormat = resources.GetString("textBox77.OutputFormat");
            this.textBox77.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox77.Text = "ZZZ9.99";
            this.textBox77.Top = 0F;
            this.textBox77.Visible = false;
            this.textBox77.Width = 0.45F;
            // 
            // textBox78
            // 
            this.textBox78.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.Border.RightColor = System.Drawing.Color.Black;
            this.textBox78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.Border.TopColor = System.Drawing.Color.Black;
            this.textBox78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.CanShrink = true;
            this.textBox78.DataField = "TermSalesCountAchivRate1";
            this.textBox78.Height = 0.16F;
            this.textBox78.Left = 5.125F;
            this.textBox78.MultiLine = false;
            this.textBox78.Name = "textBox78";
            this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
            this.textBox78.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox78.Text = "ZZZ9.99";
            this.textBox78.Top = 0.1875F;
            this.textBox78.Visible = false;
            this.textBox78.Width = 0.45F;
            // 
            // textBox79
            // 
            this.textBox79.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.Border.RightColor = System.Drawing.Color.Black;
            this.textBox79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.Border.TopColor = System.Drawing.Color.Black;
            this.textBox79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.CanShrink = true;
            this.textBox79.DataField = "MonthlySalesTarget1";
            this.textBox79.Height = 0.16F;
            this.textBox79.Left = 6.5625F;
            this.textBox79.MultiLine = false;
            this.textBox79.Name = "textBox79";
            this.textBox79.OutputFormat = resources.GetString("textBox79.OutputFormat");
            this.textBox79.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox79.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox79.Top = 0F;
            this.textBox79.Visible = false;
            this.textBox79.Width = 0.9F;
            // 
            // textBox80
            // 
            this.textBox80.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.RightColor = System.Drawing.Color.Black;
            this.textBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.TopColor = System.Drawing.Color.Black;
            this.textBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.CanShrink = true;
            this.textBox80.DataField = "TermSalesTarget1";
            this.textBox80.Height = 0.16F;
            this.textBox80.Left = 6.5625F;
            this.textBox80.MultiLine = false;
            this.textBox80.Name = "textBox80";
            this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
            this.textBox80.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox80.SummaryGroup = "";
            this.textBox80.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox80.Top = 0.1875F;
            this.textBox80.Visible = false;
            this.textBox80.Width = 0.9F;
            // 
            // textBox81
            // 
            this.textBox81.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Border.RightColor = System.Drawing.Color.Black;
            this.textBox81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Border.TopColor = System.Drawing.Color.Black;
            this.textBox81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.CanShrink = true;
            this.textBox81.DataField = "MonthlySalesMoneyAchivRate1";
            this.textBox81.Height = 0.16F;
            this.textBox81.Left = 7.5F;
            this.textBox81.MultiLine = false;
            this.textBox81.Name = "textBox81";
            this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
            this.textBox81.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox81.Text = "ZZZ9.99";
            this.textBox81.Top = 0F;
            this.textBox81.Visible = false;
            this.textBox81.Width = 0.45F;
            // 
            // textBox82
            // 
            this.textBox82.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.Border.RightColor = System.Drawing.Color.Black;
            this.textBox82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.Border.TopColor = System.Drawing.Color.Black;
            this.textBox82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.CanShrink = true;
            this.textBox82.DataField = "TermSalesMoneyAchivRate1";
            this.textBox82.Height = 0.16F;
            this.textBox82.Left = 7.5F;
            this.textBox82.MultiLine = false;
            this.textBox82.Name = "textBox82";
            this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
            this.textBox82.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox82.Text = "ZZZ9.99";
            this.textBox82.Top = 0.1875F;
            this.textBox82.Visible = false;
            this.textBox82.Width = 0.45F;
            // 
            // textBox83
            // 
            this.textBox83.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.RightColor = System.Drawing.Color.Black;
            this.textBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.TopColor = System.Drawing.Color.Black;
            this.textBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.CanShrink = true;
            this.textBox83.DataField = "MonthlySalesTargetProfit1";
            this.textBox83.Height = 0.16F;
            this.textBox83.Left = 9.4375F;
            this.textBox83.MultiLine = false;
            this.textBox83.Name = "textBox83";
            this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
            this.textBox83.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox83.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox83.Top = 0F;
            this.textBox83.Visible = false;
            this.textBox83.Width = 0.9F;
            // 
            // textBox84
            // 
            this.textBox84.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.Border.RightColor = System.Drawing.Color.Black;
            this.textBox84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.Border.TopColor = System.Drawing.Color.Black;
            this.textBox84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.CanShrink = true;
            this.textBox84.DataField = "TermSalesTargetProfit1";
            this.textBox84.Height = 0.16F;
            this.textBox84.Left = 9.4375F;
            this.textBox84.MultiLine = false;
            this.textBox84.Name = "textBox84";
            this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
            this.textBox84.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox84.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox84.Top = 0.1875F;
            this.textBox84.Visible = false;
            this.textBox84.Width = 0.9F;
            // 
            // textBox85
            // 
            this.textBox85.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.RightColor = System.Drawing.Color.Black;
            this.textBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.TopColor = System.Drawing.Color.Black;
            this.textBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.CanShrink = true;
            this.textBox85.DataField = "MonthlySalesProfitAchivRate1";
            this.textBox85.Height = 0.16F;
            this.textBox85.Left = 10.375F;
            this.textBox85.MultiLine = false;
            this.textBox85.Name = "textBox85";
            this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
            this.textBox85.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox85.Text = "ZZZ9.99";
            this.textBox85.Top = 0F;
            this.textBox85.Visible = false;
            this.textBox85.Width = 0.45F;
            // 
            // textBox86
            // 
            this.textBox86.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.RightColor = System.Drawing.Color.Black;
            this.textBox86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.TopColor = System.Drawing.Color.Black;
            this.textBox86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.CanShrink = true;
            this.textBox86.DataField = "TermSalesProfitAchivRat1";
            this.textBox86.Height = 0.16F;
            this.textBox86.Left = 10.375F;
            this.textBox86.MultiLine = false;
            this.textBox86.Name = "textBox86";
            this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
            this.textBox86.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox86.Text = "ZZZ9.99";
            this.textBox86.Top = 0.1875F;
            this.textBox86.Visible = false;
            this.textBox86.Width = 0.45F;
            // 
            // textBox87
            // 
            this.textBox87.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.Border.RightColor = System.Drawing.Color.Black;
            this.textBox87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.Border.TopColor = System.Drawing.Color.Black;
            this.textBox87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.CanShrink = true;
            this.textBox87.DataField = "MonthlySalesTargetCount1";
            this.textBox87.Height = 0.16F;
            this.textBox87.Left = 4.47F;
            this.textBox87.MultiLine = false;
            this.textBox87.Name = "textBox87";
            this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
            this.textBox87.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox87.SummaryGroup = "";
            this.textBox87.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox87.Top = 0.375F;
            this.textBox87.Visible = false;
            this.textBox87.Width = 0.64F;
            // 
            // textBox90
            // 
            this.textBox90.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Border.RightColor = System.Drawing.Color.Black;
            this.textBox90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Border.TopColor = System.Drawing.Color.Black;
            this.textBox90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.CanShrink = true;
            this.textBox90.DataField = "TermSalesTargetCount1";
            this.textBox90.Height = 0.16F;
            this.textBox90.Left = 4.47F;
            this.textBox90.MultiLine = false;
            this.textBox90.Name = "textBox90";
            this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
            this.textBox90.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox90.SummaryGroup = "";
            this.textBox90.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox90.Top = 0.5625F;
            this.textBox90.Visible = false;
            this.textBox90.Width = 0.64F;
            // 
            // textBox92
            // 
            this.textBox92.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.Border.RightColor = System.Drawing.Color.Black;
            this.textBox92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.Border.TopColor = System.Drawing.Color.Black;
            this.textBox92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.CanShrink = true;
            this.textBox92.DataField = "MonthlySalesCountAchivRate1";
            this.textBox92.Height = 0.16F;
            this.textBox92.Left = 5.125F;
            this.textBox92.MultiLine = false;
            this.textBox92.Name = "textBox92";
            this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
            this.textBox92.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox92.Text = "ZZZ9.99";
            this.textBox92.Top = 0.375F;
            this.textBox92.Visible = false;
            this.textBox92.Width = 0.45F;
            // 
            // textBox93
            // 
            this.textBox93.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox93.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox93.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.Border.RightColor = System.Drawing.Color.Black;
            this.textBox93.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.Border.TopColor = System.Drawing.Color.Black;
            this.textBox93.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.CanShrink = true;
            this.textBox93.DataField = "TermSalesCountAchivRate1";
            this.textBox93.Height = 0.16F;
            this.textBox93.Left = 5.125F;
            this.textBox93.MultiLine = false;
            this.textBox93.Name = "textBox93";
            this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
            this.textBox93.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox93.Text = "ZZZ9.99";
            this.textBox93.Top = 0.5625F;
            this.textBox93.Visible = false;
            this.textBox93.Width = 0.45F;
            // 
            // textBox94
            // 
            this.textBox94.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.Border.RightColor = System.Drawing.Color.Black;
            this.textBox94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.Border.TopColor = System.Drawing.Color.Black;
            this.textBox94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.CanShrink = true;
            this.textBox94.DataField = "TermSalesTarget1";
            this.textBox94.Height = 0.16F;
            this.textBox94.Left = 6.5625F;
            this.textBox94.MultiLine = false;
            this.textBox94.Name = "textBox94";
            this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
            this.textBox94.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox94.SummaryGroup = "";
            this.textBox94.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox94.Top = 0.5625F;
            this.textBox94.Visible = false;
            this.textBox94.Width = 0.9F;
            // 
            // textBox95
            // 
            this.textBox95.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.Border.RightColor = System.Drawing.Color.Black;
            this.textBox95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.Border.TopColor = System.Drawing.Color.Black;
            this.textBox95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.CanShrink = true;
            this.textBox95.DataField = "MonthlySalesTarget1";
            this.textBox95.Height = 0.16F;
            this.textBox95.Left = 6.5625F;
            this.textBox95.MultiLine = false;
            this.textBox95.Name = "textBox95";
            this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
            this.textBox95.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox95.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox95.Top = 0.375F;
            this.textBox95.Visible = false;
            this.textBox95.Width = 0.9F;
            // 
            // textBox96
            // 
            this.textBox96.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.Border.RightColor = System.Drawing.Color.Black;
            this.textBox96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.Border.TopColor = System.Drawing.Color.Black;
            this.textBox96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.CanShrink = true;
            this.textBox96.DataField = "MonthlySalesMoneyAchivRate1";
            this.textBox96.Height = 0.16F;
            this.textBox96.Left = 7.5F;
            this.textBox96.MultiLine = false;
            this.textBox96.Name = "textBox96";
            this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
            this.textBox96.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox96.Text = "ZZZ9.99";
            this.textBox96.Top = 0.375F;
            this.textBox96.Visible = false;
            this.textBox96.Width = 0.45F;
            // 
            // textBox97
            // 
            this.textBox97.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.Border.RightColor = System.Drawing.Color.Black;
            this.textBox97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.Border.TopColor = System.Drawing.Color.Black;
            this.textBox97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.CanShrink = true;
            this.textBox97.DataField = "TermSalesMoneyAchivRate1";
            this.textBox97.Height = 0.16F;
            this.textBox97.Left = 7.5F;
            this.textBox97.MultiLine = false;
            this.textBox97.Name = "textBox97";
            this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
            this.textBox97.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox97.Text = "ZZZ9.99";
            this.textBox97.Top = 0.5625F;
            this.textBox97.Visible = false;
            this.textBox97.Width = 0.45F;
            // 
            // textBox98
            // 
            this.textBox98.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.RightColor = System.Drawing.Color.Black;
            this.textBox98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.TopColor = System.Drawing.Color.Black;
            this.textBox98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.CanShrink = true;
            this.textBox98.DataField = "TermSalesProfitAchivRate1";
            this.textBox98.Height = 0.16F;
            this.textBox98.Left = 10.375F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox98.Text = "ZZZ9.99";
            this.textBox98.Top = 0.5625F;
            this.textBox98.Visible = false;
            this.textBox98.Width = 0.45F;
            // 
            // textBox99
            // 
            this.textBox99.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.Border.RightColor = System.Drawing.Color.Black;
            this.textBox99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.Border.TopColor = System.Drawing.Color.Black;
            this.textBox99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.CanShrink = true;
            this.textBox99.DataField = "MonthlySalesProfitAchivRate1";
            this.textBox99.Height = 0.16F;
            this.textBox99.Left = 10.375F;
            this.textBox99.MultiLine = false;
            this.textBox99.Name = "textBox99";
            this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
            this.textBox99.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox99.Text = "ZZZ9.99";
            this.textBox99.Top = 0.375F;
            this.textBox99.Visible = false;
            this.textBox99.Width = 0.45F;
            // 
            // textBox100
            // 
            this.textBox100.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.RightColor = System.Drawing.Color.Black;
            this.textBox100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.TopColor = System.Drawing.Color.Black;
            this.textBox100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.CanShrink = true;
            this.textBox100.DataField = "TermSalesTargetProfit1";
            this.textBox100.Height = 0.16F;
            this.textBox100.Left = 9.4375F;
            this.textBox100.MultiLine = false;
            this.textBox100.Name = "textBox100";
            this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
            this.textBox100.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox100.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox100.Top = 0.5625F;
            this.textBox100.Visible = false;
            this.textBox100.Width = 0.9F;
            // 
            // textBox101
            // 
            this.textBox101.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.Border.RightColor = System.Drawing.Color.Black;
            this.textBox101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.Border.TopColor = System.Drawing.Color.Black;
            this.textBox101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.CanShrink = true;
            this.textBox101.DataField = "MonthlySalesTargetProfit1";
            this.textBox101.Height = 0.16F;
            this.textBox101.Left = 9.4375F;
            this.textBox101.MultiLine = false;
            this.textBox101.Name = "textBox101";
            this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
            this.textBox101.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox101.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox101.Top = 0.375F;
            this.textBox101.Visible = false;
            this.textBox101.Width = 0.9F;
            // 
            // GroupName
            // 
            this.GroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.GroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.GroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupName.Border.RightColor = System.Drawing.Color.Black;
            this.GroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupName.Border.TopColor = System.Drawing.Color.Black;
            this.GroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupName.DataField = "BLGroupKanaName";
            this.GroupName.Height = 0.16F;
            this.GroupName.Left = 1F;
            this.GroupName.MultiLine = false;
            this.GroupName.Name = "GroupName";
            this.GroupName.OutputFormat = resources.GetString("GroupName.OutputFormat");
            this.GroupName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: bottom; ";
            this.GroupName.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.GroupName.Top = 0F;
            this.GroupName.Width = 1.15F;
            // 
            // GroupCode
            // 
            this.GroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.GroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.GroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroupCode.DataField = "BLGroupCode";
            this.GroupCode.Height = 0.16F;
            this.GroupCode.Left = 0.5625F;
            this.GroupCode.MultiLine = false;
            this.GroupCode.Name = "GroupCode";
            this.GroupCode.OutputFormat = resources.GetString("GroupCode.OutputFormat");
            this.GroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: bottom; ";
            this.GroupCode.Text = "12345";
            this.GroupCode.Top = 0F;
            this.GroupCode.Width = 0.375F;
            // 
            // BLGoodsCode
            // 
            this.BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.DataField = "BLGoodsCode";
            this.BLGoodsCode.Height = 0.16F;
            this.BLGoodsCode.Left = 2.25F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: bottom; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0F;
            this.BLGoodsCode.Visible = false;
            this.BLGoodsCode.Width = 0.35F;
            // 
            // BLGoodsName
            // 
            this.BLGoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsName.DataField = "BLGoodsHalfName";
            this.BLGoodsName.Height = 0.16F;
            this.BLGoodsName.Left = 2.6875F;
            this.BLGoodsName.MultiLine = false;
            this.BLGoodsName.Name = "BLGoodsName";
            this.BLGoodsName.OutputFormat = resources.GetString("BLGoodsName.OutputFormat");
            this.BLGoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: bottom; ";
            this.BLGoodsName.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.BLGoodsName.Top = 0F;
            this.BLGoodsName.Visible = false;
            this.BLGoodsName.Width = 1.15F;
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
            this.tb_Sort});
            this.PageHeader.Height = 0.2291667F;
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
            this.Label3.Left = 8F;
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
            this.tb_PrintDate.Left = 8.5625F;
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
            this.Label2.Left = 10F;
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
            this.tb_PrintPage.Left = 10.5F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "1234";
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
            this.Line1.Width = 10.85F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.85F;
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
            this.tb_PrintTime.Left = 9.5F;
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
            this.tb_ReportTitle.Height = 0.219F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "キャンペーン実績表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 3.5F;
            // 
            // tb_Sort
            // 
            this.tb_Sort.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_Sort.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Sort.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_Sort.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Sort.Border.RightColor = System.Drawing.Color.Black;
            this.tb_Sort.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Sort.Border.TopColor = System.Drawing.Color.Black;
            this.tb_Sort.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_Sort.CanShrink = true;
            this.tb_Sort.Height = 0.15625F;
            this.tb_Sort.Left = 3.875F;
            this.tb_Sort.MultiLine = false;
            this.tb_Sort.Name = "tb_Sort";
            this.tb_Sort.OutputFormat = resources.GetString("tb_Sort.OutputFormat");
            this.tb_Sort.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_Sort.Text = "[担当者順]";
            this.tb_Sort.Top = 0.0625F;
            this.tb_Sort.Width = 0.9375F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport,
            this.line11});
            this.PageFooter.Height = 0.3153889F;
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
            this.Footer_SubReport.Width = 10.85F;
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
            this.line11.Height = 0F;
            this.line11.Left = 0F;
            this.line11.LineWeight = 2F;
            this.line11.Name = "line11";
            this.line11.Top = 0F;
            this.line11.Width = 10.85F;
            this.line11.X1 = 0F;
            this.line11.X2 = 10.85F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0F;
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
            this.Header_SubReport.Width = 10.85F;
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
            this.Line42,
            this.Lb_MakerCode,
            this.Lb_SalesCount,
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.Lb_SalesMoney,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label4,
            this.CampaignCode,
            this.CampaignName,
            this.label5,
            this.ApplyDate,
            this.label1,
            this.label6,
            this.label7,
            this.label13,
            this.Tt_GroupCode});
            this.TitleHeader.Height = 0.5833333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Line42.Width = 10.85F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.85F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // Lb_MakerCode
            // 
            this.Lb_MakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerCode.Height = 0.16F;
            this.Lb_MakerCode.HyperLink = "";
            this.Lb_MakerCode.Left = 2.75F;
            this.Lb_MakerCode.MultiLine = false;
            this.Lb_MakerCode.Name = "Lb_MakerCode";
            this.Lb_MakerCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_MakerCode.Text = "メーカー";
            this.Lb_MakerCode.Top = 0.22F;
            this.Lb_MakerCode.Width = 0.875F;
            // 
            // Lb_SalesCount
            // 
            this.Lb_SalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Height = 0.156F;
            this.Lb_SalesCount.HyperLink = "";
            this.Lb_SalesCount.Left = 3.9075F;
            this.Lb_SalesCount.MultiLine = false;
            this.Lb_SalesCount.Name = "Lb_SalesCount";
            this.Lb_SalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_SalesCount.Text = "売上数";
            this.Lb_SalesCount.Top = 0.22F;
            this.Lb_SalesCount.Width = 0.48F;
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
            this.Lb_GoodsNo.Height = 0.16F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 0.125F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.22F;
            this.Lb_GoodsNo.Width = 1.08F;
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
            this.Lb_GoodsName.Height = 0.16F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 1.5625F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.22F;
            this.Lb_GoodsName.Width = 1.08F;
            // 
            // Lb_SalesMoney
            // 
            this.Lb_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Height = 0.16F;
            this.Lb_SalesMoney.HyperLink = "";
            this.Lb_SalesMoney.Left = 6.087F;
            this.Lb_SalesMoney.MultiLine = false;
            this.Lb_SalesMoney.Name = "Lb_SalesMoney";
            this.Lb_SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_SalesMoney.Text = "売上額";
            this.Lb_SalesMoney.Top = 0.22F;
            this.Lb_SalesMoney.Width = 0.438F;
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
            this.label8.Height = 0.16F;
            this.label8.HyperLink = "";
            this.label8.Left = 4.61F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label8.Text = "数量目標";
            this.label8.Top = 0.22F;
            this.label8.Width = 0.5F;
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
            this.label9.Height = 0.16F;
            this.label9.HyperLink = "";
            this.label9.Left = 6.9625F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label9.Text = "売上目標";
            this.label9.Top = 0.22F;
            this.label9.Width = 0.5F;
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
            this.label10.Height = 0.16F;
            this.label10.HyperLink = "";
            this.label10.Left = 7.577F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label10.Text = "達成率";
            this.label10.Top = 0.22F;
            this.label10.Width = 0.373F;
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
            this.label11.Height = 0.16F;
            this.label11.HyperLink = "";
            this.label11.Left = 8.1F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label11.Text = "粗利額";
            this.label11.Top = 0.22F;
            this.label11.Width = 0.8F;
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
            this.label12.Height = 0.16F;
            this.label12.HyperLink = "";
            this.label12.Left = 9.0145F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label12.Text = "粗利率";
            this.label12.Top = 0.22F;
            this.label12.Width = 0.373F;
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
            this.label4.Height = 0.2F;
            this.label4.HyperLink = "";
            this.label4.Left = 0F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label4.Text = "ｷｬﾝﾍﾟｰﾝ：";
            this.label4.Top = 0F;
            this.label4.Width = 0.53F;
            // 
            // CampaignCode
            // 
            this.CampaignCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CampaignCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CampaignCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignCode.Border.RightColor = System.Drawing.Color.Black;
            this.CampaignCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignCode.Border.TopColor = System.Drawing.Color.Black;
            this.CampaignCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignCode.DataField = "CampaignCode";
            this.CampaignCode.Height = 0.2F;
            this.CampaignCode.Left = 0.54F;
            this.CampaignCode.MultiLine = false;
            this.CampaignCode.Name = "CampaignCode";
            this.CampaignCode.OutputFormat = resources.GetString("CampaignCode.OutputFormat");
            this.CampaignCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: bottom; ";
            this.CampaignCode.Text = "123456";
            this.CampaignCode.Top = 0F;
            this.CampaignCode.Width = 0.4F;
            // 
            // CampaignName
            // 
            this.CampaignName.Border.BottomColor = System.Drawing.Color.Black;
            this.CampaignName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignName.Border.LeftColor = System.Drawing.Color.Black;
            this.CampaignName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignName.Border.RightColor = System.Drawing.Color.Black;
            this.CampaignName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignName.Border.TopColor = System.Drawing.Color.Black;
            this.CampaignName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CampaignName.DataField = "CampaignName";
            this.CampaignName.Height = 0.2F;
            this.CampaignName.Left = 0.96F;
            this.CampaignName.MultiLine = false;
            this.CampaignName.Name = "CampaignName";
            this.CampaignName.OutputFormat = resources.GetString("CampaignName.OutputFormat");
            this.CampaignName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 11pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: bottom; ";
            this.CampaignName.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.CampaignName.Top = 0F;
            this.CampaignName.Width = 3.1F;
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
            this.label5.Height = 0.2F;
            this.label5.HyperLink = "";
            this.label5.Left = 4.15F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label5.Text = "ｷｬﾝﾍﾟｰﾝ適用日";
            this.label5.Top = 0F;
            this.label5.Width = 0.8F;
            // 
            // ApplyDate
            // 
            this.ApplyDate.Border.BottomColor = System.Drawing.Color.Black;
            this.ApplyDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ApplyDate.Border.LeftColor = System.Drawing.Color.Black;
            this.ApplyDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ApplyDate.Border.RightColor = System.Drawing.Color.Black;
            this.ApplyDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ApplyDate.Border.TopColor = System.Drawing.Color.Black;
            this.ApplyDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ApplyDate.DataField = "ApplyDate";
            this.ApplyDate.Height = 0.2F;
            this.ApplyDate.Left = 4.965F;
            this.ApplyDate.MultiLine = false;
            this.ApplyDate.Name = "ApplyDate";
            this.ApplyDate.OutputFormat = resources.GetString("ApplyDate.OutputFormat");
            this.ApplyDate.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 11pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: bottom; ";
            this.ApplyDate.Text = "[ 9999/99/99 ～ 9999/99/99 ]";
            this.ApplyDate.Top = 0F;
            this.ApplyDate.Width = 2.2F;
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
            this.label1.Height = 0.2F;
            this.label1.HyperLink = "";
            this.label1.Left = 8.625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label1.Text = "[上段：対象日付期間/下段：期間累計]";
            this.label1.Top = 0F;
            this.label1.Width = 2.125F;
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
            this.label6.Height = 0.16F;
            this.label6.HyperLink = "";
            this.label6.Left = 5.202F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label6.Text = "達成率";
            this.label6.Top = 0.22F;
            this.label6.Width = 0.373F;
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
            this.label7.Height = 0.16F;
            this.label7.HyperLink = "";
            this.label7.Left = 10.452F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label7.Text = "達成率";
            this.label7.Top = 0.22F;
            this.label7.Width = 0.373F;
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
            this.label13.Height = 0.16F;
            this.label13.HyperLink = "";
            this.label13.Left = 9.8375F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.label13.Text = "粗利目標";
            this.label13.Top = 0.22F;
            this.label13.Width = 0.5F;
            // 
            // Tt_GroupCode
            // 
            this.Tt_GroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tt_GroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tt_GroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tt_GroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tt_GroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tt_GroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tt_GroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tt_GroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tt_GroupCode.Height = 0.16F;
            this.Tt_GroupCode.HyperLink = "";
            this.Tt_GroupCode.Left = 0.25F;
            this.Tt_GroupCode.MultiLine = false;
            this.Tt_GroupCode.Name = "Tt_GroupCode";
            this.Tt_GroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Tt_GroupCode.Text = "グループ";
            this.Tt_GroupCode.Top = 0.375F;
            this.Tt_GroupCode.Visible = false;
            this.Tt_GroupCode.Width = 0.5F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
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
            this.GrandTotalTitle,
            this.Line43,
            this.toTotalSalesCount,
            this.toCmpPureSalesRatio,
            this.toProfitRatio,
            this.textBox18,
            this.textBox22,
            this.textBox30,
            this.textBox19,
            this.textBox20,
            this.textBox1,
            this.textBox4,
            this.textBox23,
            this.textBox24,
            this.textBox31,
            this.textBox33,
            this.textBox40,
            this.textBox41,
            this.textBox16,
            this.textBox26,
            this.textBox54,
            this.textBox55});
            this.GrandTotalFooter.Height = 0.40625F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GrandTotalTitle
            // 
            this.GrandTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Height = 0.2F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 2.75F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0F;
            this.GrandTotalTitle.Width = 0.875F;
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
            this.Line43.Width = 10.85F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.85F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // toTotalSalesCount
            // 
            this.toTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.CanShrink = true;
            this.toTotalSalesCount.DataField = "TermSalesTarget2";
            this.toTotalSalesCount.Height = 0.16F;
            this.toTotalSalesCount.Left = 6.5625F;
            this.toTotalSalesCount.MultiLine = false;
            this.toTotalSalesCount.Name = "toTotalSalesCount";
            this.toTotalSalesCount.OutputFormat = resources.GetString("toTotalSalesCount.OutputFormat");
            this.toTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toTotalSalesCount.SummaryGroup = "GrandTotalHeader";
            this.toTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toTotalSalesCount.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.toTotalSalesCount.Top = 0.1875F;
            this.toTotalSalesCount.Width = 0.9F;
            // 
            // toCmpPureSalesRatio
            // 
            this.toCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.CanShrink = true;
            this.toCmpPureSalesRatio.Height = 0.16F;
            this.toCmpPureSalesRatio.Left = 7.5F;
            this.toCmpPureSalesRatio.MultiLine = false;
            this.toCmpPureSalesRatio.Name = "toCmpPureSalesRatio";
            this.toCmpPureSalesRatio.OutputFormat = resources.GetString("toCmpPureSalesRatio.OutputFormat");
            this.toCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toCmpPureSalesRatio.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.toCmpPureSalesRatio.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.toCmpPureSalesRatio.Text = "ZZZ9.99";
            this.toCmpPureSalesRatio.Top = 0.1875F;
            this.toCmpPureSalesRatio.Width = 0.45F;
            // 
            // toProfitRatio
            // 
            this.toProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.CanShrink = true;
            this.toProfitRatio.Height = 0.16F;
            this.toProfitRatio.Left = 8.9375F;
            this.toProfitRatio.MultiLine = false;
            this.toProfitRatio.Name = "toProfitRatio";
            this.toProfitRatio.OutputFormat = resources.GetString("toProfitRatio.OutputFormat");
            this.toProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toProfitRatio.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.toProfitRatio.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.toProfitRatio.Text = "ZZZ9.99";
            this.toProfitRatio.Top = 0F;
            this.toProfitRatio.Width = 0.45F;
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
            this.textBox18.CanShrink = true;
            this.textBox18.DataField = "TermSalesTargetCount2";
            this.textBox18.Height = 0.16F;
            this.textBox18.Left = 4.41F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox18.SummaryGroup = "GrandTotalHeader";
            this.textBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox18.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox18.Top = 0.188F;
            this.textBox18.Width = 0.7F;
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
            this.textBox22.CanShrink = true;
            this.textBox22.DataField = "MonthlySalesTargetCount2";
            this.textBox22.Height = 0.16F;
            this.textBox22.Left = 4.41F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox22.SummaryGroup = "GrandTotalHeader";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox22.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox22.Top = 0F;
            this.textBox22.Width = 0.7F;
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
            this.textBox30.CanShrink = true;
            this.textBox30.Height = 0.16F;
            this.textBox30.Left = 8.9375F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox30.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox30.Text = "ZZZ9.99";
            this.textBox30.Top = 0.1875F;
            this.textBox30.Width = 0.45F;
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
            this.textBox19.DataField = "MonthlySalesCount";
            this.textBox19.Height = 0.16F;
            this.textBox19.Left = 3.6875F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox19.SummaryGroup = "GrandTotalHeader";
            this.textBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox19.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox19.Top = 0F;
            this.textBox19.Width = 0.7F;
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
            this.textBox20.DataField = "TermSalesCount";
            this.textBox20.Height = 0.16F;
            this.textBox20.Left = 3.6875F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox20.SummaryGroup = "GrandTotalHeader";
            this.textBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox20.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox20.Top = 0.1875F;
            this.textBox20.Width = 0.7F;
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
            this.textBox1.CanShrink = true;
            this.textBox1.Height = 0.16F;
            this.textBox1.Left = 5.125F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox1.Text = "ZZZ9.99";
            this.textBox1.Top = 0.1875F;
            this.textBox1.Width = 0.45F;
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
            this.textBox4.CanShrink = true;
            this.textBox4.Height = 0.16F;
            this.textBox4.Left = 5.125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox4.Text = "ZZZ9.99";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.45F;
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
            this.textBox23.CanShrink = true;
            this.textBox23.DataField = "MonthlySalesMoney";
            this.textBox23.Height = 0.16F;
            this.textBox23.Left = 5.625F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox23.SummaryGroup = "GrandTotalHeader";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox23.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox23.Top = 0F;
            this.textBox23.Width = 0.9F;
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
            this.textBox24.CanShrink = true;
            this.textBox24.DataField = "TermSalesMoney";
            this.textBox24.Height = 0.16F;
            this.textBox24.Left = 5.625F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox24.SummaryGroup = "GrandTotalHeader";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox24.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox24.Top = 0.1875F;
            this.textBox24.Width = 0.9F;
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
            this.textBox31.CanShrink = true;
            this.textBox31.DataField = "MonthlySalesTarget2";
            this.textBox31.Height = 0.16F;
            this.textBox31.Left = 6.5625F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox31.SummaryGroup = "GrandTotalHeader";
            this.textBox31.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox31.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox31.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox31.Top = 0F;
            this.textBox31.Width = 0.9F;
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
            this.textBox33.CanShrink = true;
            this.textBox33.Height = 0.16F;
            this.textBox33.Left = 7.5F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox33.Text = "ZZZ9.99";
            this.textBox33.Top = 0F;
            this.textBox33.Width = 0.45F;
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
            this.textBox40.CanShrink = true;
            this.textBox40.DataField = "TermSalesProfit";
            this.textBox40.Height = 0.16F;
            this.textBox40.Left = 8F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.SummaryGroup = "GrandTotalHeader";
            this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox40.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox40.Top = 0.1875F;
            this.textBox40.Width = 0.9F;
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
            this.textBox41.CanShrink = true;
            this.textBox41.DataField = "MonthlySalesProfit";
            this.textBox41.Height = 0.16F;
            this.textBox41.Left = 8F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox41.SummaryGroup = "GrandTotalHeader";
            this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox41.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox41.Top = 0F;
            this.textBox41.Width = 0.9F;
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
            this.textBox16.CanShrink = true;
            this.textBox16.DataField = "TermSalesTargetProfit2";
            this.textBox16.Height = 0.16F;
            this.textBox16.Left = 9.4375F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox16.SummaryGroup = "GrandTotalHeader";
            this.textBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox16.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox16.Top = 0.1875F;
            this.textBox16.Width = 0.9F;
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
            this.textBox26.CanShrink = true;
            this.textBox26.DataField = "MonthlySalesTargetProfit2";
            this.textBox26.Height = 0.16F;
            this.textBox26.Left = 9.4375F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox26.SummaryGroup = "GrandTotalHeader";
            this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox26.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox26.Top = 0F;
            this.textBox26.Width = 0.9F;
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
            this.textBox54.CanShrink = true;
            this.textBox54.Height = 0.16F;
            this.textBox54.Left = 10.375F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox54.Text = "ZZZ9.99";
            this.textBox54.Top = 0F;
            this.textBox54.Width = 0.45F;
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
            this.textBox55.CanShrink = true;
            this.textBox55.Height = 0.16F;
            this.textBox55.Left = 10.375F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox55.Text = "ZZZ9.99";
            this.textBox55.Top = 0.1875F;
            this.textBox55.Width = 0.45F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label14,
            this.textBox102,
            this.textBox103,
            this.line12,
            this.label18,
            this.textBox122,
            this.textBox123,
            this.line15});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.2083333F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.label14.Height = 0.16F;
            this.label14.HyperLink = "";
            this.label14.Left = 0F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label14.Text = "拠点";
            this.label14.Top = 0F;
            this.label14.Visible = false;
            this.label14.Width = 0.313F;
            // 
            // textBox102
            // 
            this.textBox102.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Border.RightColor = System.Drawing.Color.Black;
            this.textBox102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Border.TopColor = System.Drawing.Color.Black;
            this.textBox102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.DataField = "AddUpSecCode";
            this.textBox102.Height = 0.16F;
            this.textBox102.Left = 0.3125F;
            this.textBox102.MultiLine = false;
            this.textBox102.Name = "textBox102";
            this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
            this.textBox102.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.textBox102.Text = "12";
            this.textBox102.Top = 0F;
            this.textBox102.Visible = false;
            this.textBox102.Width = 0.2F;
            // 
            // textBox103
            // 
            this.textBox103.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.RightColor = System.Drawing.Color.Black;
            this.textBox103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.TopColor = System.Drawing.Color.Black;
            this.textBox103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.DataField = "SectionGuideNm";
            this.textBox103.Height = 0.16F;
            this.textBox103.Left = 0.5F;
            this.textBox103.MultiLine = false;
            this.textBox103.Name = "textBox103";
            this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
            this.textBox103.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.textBox103.Text = "あいうえおかきくけこ";
            this.textBox103.Top = 0F;
            this.textBox103.Visible = false;
            this.textBox103.Width = 1.2F;
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
            this.line12.Visible = false;
            this.line12.Width = 10.85F;
            this.line12.X1 = 0F;
            this.line12.X2 = 10.85F;
            this.line12.Y1 = 0F;
            this.line12.Y2 = 0F;
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
            this.label18.Height = 0.16F;
            this.label18.HyperLink = "";
            this.label18.Left = 1.92F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; ddo-char-set: 128; text-align: right; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; white-space: inherit; vertical-align: bottom; ";
            this.label18.Text = "得意先";
            this.label18.Top = 0F;
            this.label18.Visible = false;
            this.label18.Width = 0.37F;
            // 
            // textBox122
            // 
            this.textBox122.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.RightColor = System.Drawing.Color.Black;
            this.textBox122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.TopColor = System.Drawing.Color.Black;
            this.textBox122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.DataField = "CustomerCode";
            this.textBox122.Height = 0.16F;
            this.textBox122.Left = 2.3125F;
            this.textBox122.MultiLine = false;
            this.textBox122.Name = "textBox122";
            this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
            this.textBox122.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-sp" +
                "ace: inherit; vertical-align: bottom; ";
            this.textBox122.Text = "12345678";
            this.textBox122.Top = 0F;
            this.textBox122.Visible = false;
            this.textBox122.Width = 0.475F;
            // 
            // textBox123
            // 
            this.textBox123.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox123.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox123.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Border.RightColor = System.Drawing.Color.Black;
            this.textBox123.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Border.TopColor = System.Drawing.Color.Black;
            this.textBox123.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.DataField = "CustomerSnm";
            this.textBox123.Height = 0.16F;
            this.textBox123.Left = 2.8125F;
            this.textBox123.MultiLine = false;
            this.textBox123.Name = "textBox123";
            this.textBox123.OutputFormat = resources.GetString("textBox123.OutputFormat");
            this.textBox123.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; white-spac" +
                "e: inherit; vertical-align: bottom; ";
            this.textBox123.Text = "あいうえおかきくけこ";
            this.textBox123.Top = 0F;
            this.textBox123.Visible = false;
            this.textBox123.Width = 1.2F;
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
            this.line15.Height = 0F;
            this.line15.Left = 0F;
            this.line15.LineWeight = 1.5F;
            this.line15.Name = "line15";
            this.line15.Top = 0.16F;
            this.line15.Visible = false;
            this.line15.Width = 10.85F;
            this.line15.X1 = 0F;
            this.line15.X2 = 10.85F;
            this.line15.Y1 = 0.16F;
            this.line15.Y2 = 0.16F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.seTotalSalesCount,
            this.seCmpPureSalesRatio,
            this.seProfitRatio,
            this.textBox15,
            this.textBox28,
            this.textBox14,
            this.textBox17,
            this.textBox2,
            this.textBox5,
            this.textBox8,
            this.textBox21,
            this.textBox32,
            this.textBox34,
            this.textBox42,
            this.textBox43,
            this.textBox27,
            this.textBox29,
            this.textBox56,
            this.textBox57,
            this.Lb_SecTotal,
            this.textBox13});
            this.SectionFooter.Height = 0.41F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
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
            this.Line45.Width = 10.85F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.85F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // seTotalSalesCount
            // 
            this.seTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.CanShrink = true;
            this.seTotalSalesCount.DataField = "TermSalesTarget2";
            this.seTotalSalesCount.Height = 0.16F;
            this.seTotalSalesCount.Left = 6.5625F;
            this.seTotalSalesCount.MultiLine = false;
            this.seTotalSalesCount.Name = "seTotalSalesCount";
            this.seTotalSalesCount.OutputFormat = resources.GetString("seTotalSalesCount.OutputFormat");
            this.seTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seTotalSalesCount.SummaryGroup = "SectionHeader";
            this.seTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seTotalSalesCount.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.seTotalSalesCount.Top = 0.1875F;
            this.seTotalSalesCount.Width = 0.9F;
            // 
            // seCmpPureSalesRatio
            // 
            this.seCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.CanShrink = true;
            this.seCmpPureSalesRatio.Height = 0.16F;
            this.seCmpPureSalesRatio.Left = 7.5F;
            this.seCmpPureSalesRatio.MultiLine = false;
            this.seCmpPureSalesRatio.Name = "seCmpPureSalesRatio";
            this.seCmpPureSalesRatio.OutputFormat = resources.GetString("seCmpPureSalesRatio.OutputFormat");
            this.seCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seCmpPureSalesRatio.Text = "ZZZ9.99";
            this.seCmpPureSalesRatio.Top = 0.1875F;
            this.seCmpPureSalesRatio.Width = 0.45F;
            // 
            // seProfitRatio
            // 
            this.seProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.CanShrink = true;
            this.seProfitRatio.DataField = "MonthlySalesProfitRate";
            this.seProfitRatio.Height = 0.16F;
            this.seProfitRatio.Left = 8.9375F;
            this.seProfitRatio.MultiLine = false;
            this.seProfitRatio.Name = "seProfitRatio";
            this.seProfitRatio.OutputFormat = resources.GetString("seProfitRatio.OutputFormat");
            this.seProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seProfitRatio.Text = "ZZZ9.99";
            this.seProfitRatio.Top = 0F;
            this.seProfitRatio.Width = 0.45F;
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
            this.textBox15.CanShrink = true;
            this.textBox15.DataField = "MonthlySalesTargetCount2";
            this.textBox15.Height = 0.16F;
            this.textBox15.Left = 4.41F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox15.SummaryGroup = "SectionHeader";
            this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox15.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.7F;
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
            this.textBox28.CanShrink = true;
            this.textBox28.DataField = "TermSalesProfitRate";
            this.textBox28.Height = 0.16F;
            this.textBox28.Left = 8.9375F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox28.Text = "ZZZ9.99";
            this.textBox28.Top = 0.1875F;
            this.textBox28.Width = 0.45F;
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
            this.textBox14.DataField = "MonthlySalesCount";
            this.textBox14.Height = 0.16F;
            this.textBox14.Left = 3.6875F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox14.SummaryGroup = "SectionHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.7F;
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
            this.textBox17.DataField = "TermSalesCount";
            this.textBox17.Height = 0.16F;
            this.textBox17.Left = 3.6875F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox17.SummaryGroup = "SectionHeader";
            this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox17.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox17.Top = 0.1875F;
            this.textBox17.Width = 0.7F;
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
            this.textBox2.CanShrink = true;
            this.textBox2.Height = 0.16F;
            this.textBox2.Left = 5.125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.Text = "ZZZ9.99";
            this.textBox2.Top = 0.1875F;
            this.textBox2.Width = 0.45F;
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
            this.textBox5.CanShrink = true;
            this.textBox5.Height = 0.16F;
            this.textBox5.Left = 5.125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox5.Text = "ZZZ9.99";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.45F;
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
            this.textBox8.CanShrink = true;
            this.textBox8.DataField = "MonthlySalesMoney";
            this.textBox8.Height = 0.16F;
            this.textBox8.Left = 5.625F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.SummaryGroup = "SectionHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.9F;
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
            this.textBox21.CanShrink = true;
            this.textBox21.DataField = "TermSalesMoney";
            this.textBox21.Height = 0.16F;
            this.textBox21.Left = 5.625F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox21.SummaryGroup = "SectionHeader";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox21.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox21.Top = 0.1875F;
            this.textBox21.Width = 0.9F;
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
            this.textBox32.CanShrink = true;
            this.textBox32.DataField = "MonthlySalesTarget2";
            this.textBox32.Height = 0.16F;
            this.textBox32.Left = 6.5625F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox32.SummaryGroup = "SectionHeader";
            this.textBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox32.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox32.Top = 0F;
            this.textBox32.Width = 0.9F;
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
            this.textBox34.CanShrink = true;
            this.textBox34.Height = 0.16F;
            this.textBox34.Left = 7.5F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox34.Text = "ZZZ9.99";
            this.textBox34.Top = 0F;
            this.textBox34.Width = 0.45F;
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
            this.textBox42.CanShrink = true;
            this.textBox42.DataField = "TermSalesProfit";
            this.textBox42.Height = 0.16F;
            this.textBox42.Left = 8F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox42.SummaryGroup = "SectionHeader";
            this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox42.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox42.Top = 0.1875F;
            this.textBox42.Width = 0.9F;
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
            this.textBox43.CanShrink = true;
            this.textBox43.DataField = "MonthlySalesProfit";
            this.textBox43.Height = 0.16F;
            this.textBox43.Left = 8F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox43.SummaryGroup = "SectionHeader";
            this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox43.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox43.Top = 0F;
            this.textBox43.Width = 0.9F;
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
            this.textBox27.CanShrink = true;
            this.textBox27.DataField = "TermSalesTargetProfit2";
            this.textBox27.Height = 0.16F;
            this.textBox27.Left = 9.4375F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox27.SummaryGroup = "SectionHeader";
            this.textBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox27.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox27.Top = 0.1875F;
            this.textBox27.Width = 0.9F;
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
            this.textBox29.CanShrink = true;
            this.textBox29.DataField = "MonthlySalesTargetProfit2";
            this.textBox29.Height = 0.16F;
            this.textBox29.Left = 9.4375F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.SummaryGroup = "SectionHeader";
            this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox29.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox29.Top = 0F;
            this.textBox29.Width = 0.9F;
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
            this.textBox56.CanShrink = true;
            this.textBox56.Height = 0.16F;
            this.textBox56.Left = 10.375F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox56.Text = "ZZZ9.99";
            this.textBox56.Top = 0.1875F;
            this.textBox56.Width = 0.45F;
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
            this.textBox57.CanShrink = true;
            this.textBox57.Height = 0.16F;
            this.textBox57.Left = 10.375F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox57.Text = "ZZZ9.99";
            this.textBox57.Top = 0F;
            this.textBox57.Width = 0.45F;
            // 
            // Lb_SecTotal
            // 
            this.Lb_SecTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SecTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SecTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SecTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SecTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SecTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SecTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SecTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SecTotal.Height = 0.2F;
            this.Lb_SecTotal.HyperLink = "";
            this.Lb_SecTotal.Left = 2.75F;
            this.Lb_SecTotal.MultiLine = false;
            this.Lb_SecTotal.Name = "Lb_SecTotal";
            this.Lb_SecTotal.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SecTotal.Text = "拠点計";
            this.Lb_SecTotal.Top = 0F;
            this.Lb_SecTotal.Width = 0.875F;
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
            this.textBox13.CanShrink = true;
            this.textBox13.DataField = "TermSalesTargetCount2";
            this.textBox13.Height = 0.16F;
            this.textBox13.Left = 4.41F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.SummaryGroup = "SectionHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox13.Top = 0.1875F;
            this.textBox13.Width = 0.7F;
            // 
            // EmployeeHeader
            // 
            this.EmployeeHeader.CanShrink = true;
            this.EmployeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupHd_AddUpSecCode,
            this.SupHd_SectionGuideNm,
            this.SupHd_EmployeeCd,
            this.SupHd_EmployeeNm,
            this.SupHd_SectionTitle,
            this.SupHd_EmployeeTitle,
            this.line6,
            this.line13});
            this.EmployeeHeader.DataField = "HeaderKey1";
            this.EmployeeHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.EmployeeHeader.Height = 0.25F;
            this.EmployeeHeader.KeepTogether = true;
            this.EmployeeHeader.Name = "EmployeeHeader";
            this.EmployeeHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SupHd_AddUpSecCode
            // 
            this.SupHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.SupHd_AddUpSecCode.Height = 0.16F;
            this.SupHd_AddUpSecCode.Left = 0.3125F;
            this.SupHd_AddUpSecCode.MultiLine = false;
            this.SupHd_AddUpSecCode.Name = "SupHd_AddUpSecCode";
            this.SupHd_AddUpSecCode.OutputFormat = resources.GetString("SupHd_AddUpSecCode.OutputFormat");
            this.SupHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.SupHd_AddUpSecCode.Text = "12";
            this.SupHd_AddUpSecCode.Top = 0F;
            this.SupHd_AddUpSecCode.Width = 0.15F;
            // 
            // SupHd_SectionGuideNm
            // 
            this.SupHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.DataField = "SectionGuideNm";
            this.SupHd_SectionGuideNm.Height = 0.16F;
            this.SupHd_SectionGuideNm.Left = 0.5F;
            this.SupHd_SectionGuideNm.MultiLine = false;
            this.SupHd_SectionGuideNm.Name = "SupHd_SectionGuideNm";
            this.SupHd_SectionGuideNm.OutputFormat = resources.GetString("SupHd_SectionGuideNm.OutputFormat");
            this.SupHd_SectionGuideNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.SupHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SupHd_SectionGuideNm.Top = 0F;
            this.SupHd_SectionGuideNm.Width = 1.2F;
            // 
            // SupHd_EmployeeCd
            // 
            this.SupHd_EmployeeCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeCd.DataField = "EmployeeCode";
            this.SupHd_EmployeeCd.Height = 0.16F;
            this.SupHd_EmployeeCd.Left = 2.3125F;
            this.SupHd_EmployeeCd.MultiLine = false;
            this.SupHd_EmployeeCd.Name = "SupHd_EmployeeCd";
            this.SupHd_EmployeeCd.OutputFormat = resources.GetString("SupHd_EmployeeCd.OutputFormat");
            this.SupHd_EmployeeCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.SupHd_EmployeeCd.Text = "1234";
            this.SupHd_EmployeeCd.Top = 0F;
            this.SupHd_EmployeeCd.Width = 0.25F;
            // 
            // SupHd_EmployeeNm
            // 
            this.SupHd_EmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeNm.DataField = "EmployeeName";
            this.SupHd_EmployeeNm.Height = 0.16F;
            this.SupHd_EmployeeNm.Left = 2.625F;
            this.SupHd_EmployeeNm.MultiLine = false;
            this.SupHd_EmployeeNm.Name = "SupHd_EmployeeNm";
            this.SupHd_EmployeeNm.OutputFormat = resources.GetString("SupHd_EmployeeNm.OutputFormat");
            this.SupHd_EmployeeNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.SupHd_EmployeeNm.Text = "あいうえおかきくけこ";
            this.SupHd_EmployeeNm.Top = 0F;
            this.SupHd_EmployeeNm.Width = 1.2F;
            // 
            // SupHd_SectionTitle
            // 
            this.SupHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Height = 0.16F;
            this.SupHd_SectionTitle.HyperLink = "";
            this.SupHd_SectionTitle.Left = 0F;
            this.SupHd_SectionTitle.MultiLine = false;
            this.SupHd_SectionTitle.Name = "SupHd_SectionTitle";
            this.SupHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.SupHd_SectionTitle.Text = "拠点";
            this.SupHd_SectionTitle.Top = 0F;
            this.SupHd_SectionTitle.Width = 0.28F;
            // 
            // SupHd_EmployeeTitle
            // 
            this.SupHd_EmployeeTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_EmployeeTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_EmployeeTitle.Height = 0.16F;
            this.SupHd_EmployeeTitle.HyperLink = "";
            this.SupHd_EmployeeTitle.Left = 1.92F;
            this.SupHd_EmployeeTitle.MultiLine = false;
            this.SupHd_EmployeeTitle.Name = "SupHd_EmployeeTitle";
            this.SupHd_EmployeeTitle.Style = "color: Black; ddo-char-set: 128; text-align: left; font-weight: bold; font-size: " +
                "8pt; font-family: ＭＳ 明朝; vertical-align: bottom; ";
            this.SupHd_EmployeeTitle.Text = "担当者";
            this.SupHd_EmployeeTitle.Top = 0F;
            this.SupHd_EmployeeTitle.Width = 0.38F;
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
            this.line6.Top = 0F;
            this.line6.Width = 10.85F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.85F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.line13.LineWeight = 1.5F;
            this.line13.Name = "line13";
            this.line13.Top = 0.16F;
            this.line13.Visible = false;
            this.line13.Width = 10.85F;
            this.line13.X1 = 0F;
            this.line13.X2 = 10.85F;
            this.line13.Y1 = 0.16F;
            this.line13.Y2 = 0.16F;
            // 
            // EmployeeFooter
            // 
            this.EmployeeFooter.CanShrink = true;
            this.EmployeeFooter.Height = 0F;
            this.EmployeeFooter.KeepTogether = true;
            this.EmployeeFooter.Name = "EmployeeFooter";
            this.EmployeeFooter.Visible = false;
            // 
            // BLGroupHeader
            // 
            this.BLGroupHeader.CanShrink = true;
            this.BLGroupHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Lb_GroupCode,
            this.GroupName,
            this.GroupCode,
            this.BLGoodsName,
            this.BLGoodsCode,
            this.line3});
            this.BLGroupHeader.DataField = "BLGroupCode";
            this.BLGroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.BLGroupHeader.Height = 0.21875F;
            this.BLGroupHeader.KeepTogether = true;
            this.BLGroupHeader.Name = "BLGroupHeader";
            this.BLGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // Lb_GroupCode
            // 
            this.Lb_GroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GroupCode.Height = 0.16F;
            this.Lb_GroupCode.HyperLink = "";
            this.Lb_GroupCode.Left = 0F;
            this.Lb_GroupCode.MultiLine = false;
            this.Lb_GroupCode.Name = "Lb_GroupCode";
            this.Lb_GroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_GroupCode.Text = "グループ";
            this.Lb_GroupCode.Top = 0F;
            this.Lb_GroupCode.Width = 0.5F;
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
            this.line3.Width = 10.85F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.85F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // BLGroupFooter
            // 
            this.BLGroupFooter.CanShrink = true;
            this.BLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line8,
            this.grProfitRatio1,
            this.grSalesMoney1,
            this.grSalesMoney2,
            this.grProfitRatio2,
            this.grSalesCount1,
            this.grSalesCount2,
            this.textBox38,
            this.textBox39,
            this.Lb_BLTotal,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox58,
            this.textBox59,
            this.textBox68,
            this.textBox69,
            this.textBox70,
            this.textBox71,
            this.textBox72,
            this.textBox73,
            this.textBox74});
            this.BLGroupFooter.Height = 0.375F;
            this.BLGroupFooter.KeepTogether = true;
            this.BLGroupFooter.Name = "BLGroupFooter";
            this.BLGroupFooter.BeforePrint += new System.EventHandler(this.BLGroupFooter_BeforePrint);
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
            this.line8.Height = 0F;
            this.line8.Left = 0F;
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0F;
            this.line8.Width = 10.85F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.85F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // grProfitRatio1
            // 
            this.grProfitRatio1.Border.BottomColor = System.Drawing.Color.Black;
            this.grProfitRatio1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio1.Border.LeftColor = System.Drawing.Color.Black;
            this.grProfitRatio1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio1.Border.RightColor = System.Drawing.Color.Black;
            this.grProfitRatio1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio1.Border.TopColor = System.Drawing.Color.Black;
            this.grProfitRatio1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio1.CanShrink = true;
            this.grProfitRatio1.DataField = "MonthlySalesProfitRate";
            this.grProfitRatio1.Height = 0.16F;
            this.grProfitRatio1.Left = 8.9375F;
            this.grProfitRatio1.MultiLine = false;
            this.grProfitRatio1.Name = "grProfitRatio1";
            this.grProfitRatio1.OutputFormat = resources.GetString("grProfitRatio1.OutputFormat");
            this.grProfitRatio1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grProfitRatio1.SummaryGroup = "BLGroupHeader";
            this.grProfitRatio1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grProfitRatio1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grProfitRatio1.Text = "ZZZ9.99";
            this.grProfitRatio1.Top = 0F;
            this.grProfitRatio1.Width = 0.45F;
            // 
            // grSalesMoney1
            // 
            this.grSalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.grSalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.grSalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.grSalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.grSalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney1.CanShrink = true;
            this.grSalesMoney1.DataField = "MonthlySalesMoney";
            this.grSalesMoney1.Height = 0.16F;
            this.grSalesMoney1.Left = 5.625F;
            this.grSalesMoney1.MultiLine = false;
            this.grSalesMoney1.Name = "grSalesMoney1";
            this.grSalesMoney1.OutputFormat = resources.GetString("grSalesMoney1.OutputFormat");
            this.grSalesMoney1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grSalesMoney1.SummaryGroup = "BLGroupHeader";
            this.grSalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grSalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grSalesMoney1.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.grSalesMoney1.Top = 0F;
            this.grSalesMoney1.Width = 0.9F;
            // 
            // grSalesMoney2
            // 
            this.grSalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.grSalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.grSalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.grSalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.grSalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesMoney2.CanShrink = true;
            this.grSalesMoney2.DataField = "TermSalesMoney";
            this.grSalesMoney2.Height = 0.16F;
            this.grSalesMoney2.Left = 5.625F;
            this.grSalesMoney2.MultiLine = false;
            this.grSalesMoney2.Name = "grSalesMoney2";
            this.grSalesMoney2.OutputFormat = resources.GetString("grSalesMoney2.OutputFormat");
            this.grSalesMoney2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grSalesMoney2.SummaryGroup = "BLGroupHeader";
            this.grSalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grSalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grSalesMoney2.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.grSalesMoney2.Top = 0.1875F;
            this.grSalesMoney2.Width = 0.9F;
            // 
            // grProfitRatio2
            // 
            this.grProfitRatio2.Border.BottomColor = System.Drawing.Color.Black;
            this.grProfitRatio2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio2.Border.LeftColor = System.Drawing.Color.Black;
            this.grProfitRatio2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio2.Border.RightColor = System.Drawing.Color.Black;
            this.grProfitRatio2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio2.Border.TopColor = System.Drawing.Color.Black;
            this.grProfitRatio2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio2.CanShrink = true;
            this.grProfitRatio2.DataField = "TermSalesProfitRate";
            this.grProfitRatio2.Height = 0.16F;
            this.grProfitRatio2.Left = 8.9375F;
            this.grProfitRatio2.MultiLine = false;
            this.grProfitRatio2.Name = "grProfitRatio2";
            this.grProfitRatio2.OutputFormat = resources.GetString("grProfitRatio2.OutputFormat");
            this.grProfitRatio2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grProfitRatio2.SummaryGroup = "BLGroupHeader";
            this.grProfitRatio2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grProfitRatio2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grProfitRatio2.Text = "ZZZ9.99";
            this.grProfitRatio2.Top = 0.1875F;
            this.grProfitRatio2.Width = 0.45F;
            // 
            // grSalesCount1
            // 
            this.grSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.grSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.grSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.grSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.grSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount1.DataField = "MonthlySalesCount";
            this.grSalesCount1.Height = 0.16F;
            this.grSalesCount1.Left = 3.6875F;
            this.grSalesCount1.MultiLine = false;
            this.grSalesCount1.Name = "grSalesCount1";
            this.grSalesCount1.OutputFormat = resources.GetString("grSalesCount1.OutputFormat");
            this.grSalesCount1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grSalesCount1.SummaryGroup = "BLGroupHeader";
            this.grSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grSalesCount1.Text = "ZZZ,ZZZ,ZZ9";
            this.grSalesCount1.Top = 0F;
            this.grSalesCount1.Width = 0.7F;
            // 
            // grSalesCount2
            // 
            this.grSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.grSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.grSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.grSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.grSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grSalesCount2.DataField = "TermSalesCount";
            this.grSalesCount2.Height = 0.16F;
            this.grSalesCount2.Left = 3.6875F;
            this.grSalesCount2.MultiLine = false;
            this.grSalesCount2.Name = "grSalesCount2";
            this.grSalesCount2.OutputFormat = resources.GetString("grSalesCount2.OutputFormat");
            this.grSalesCount2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grSalesCount2.SummaryGroup = "BLGroupHeader";
            this.grSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grSalesCount2.Text = "ZZZ,ZZZ,ZZ9";
            this.grSalesCount2.Top = 0.1875F;
            this.grSalesCount2.Width = 0.7F;
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
            this.textBox38.CanShrink = true;
            this.textBox38.DataField = "MonthlySalesProfit";
            this.textBox38.Height = 0.16F;
            this.textBox38.Left = 8F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox38.SummaryGroup = "BLGroupHeader";
            this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox38.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox38.Top = 0F;
            this.textBox38.Width = 0.9F;
            // 
            // textBox39
            // 
            this.textBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.RightColor = System.Drawing.Color.Black;
            this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.TopColor = System.Drawing.Color.Black;
            this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.CanShrink = true;
            this.textBox39.DataField = "TermSalesProfit";
            this.textBox39.Height = 0.16F;
            this.textBox39.Left = 8F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox39.SummaryGroup = "BLGroupHeader";
            this.textBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox39.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox39.Top = 0.1875F;
            this.textBox39.Width = 0.9F;
            // 
            // Lb_BLTotal
            // 
            this.Lb_BLTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLTotal.Height = 0.2F;
            this.Lb_BLTotal.HyperLink = "";
            this.Lb_BLTotal.Left = 2.75F;
            this.Lb_BLTotal.MultiLine = false;
            this.Lb_BLTotal.Name = "Lb_BLTotal";
            this.Lb_BLTotal.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLTotal.Text = "グループ計";
            this.Lb_BLTotal.Top = 0F;
            this.Lb_BLTotal.Width = 0.875F;
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
            this.textBox49.CanShrink = true;
            this.textBox49.DataField = "MonthlySalesTargetCount1";
            this.textBox49.Height = 0.16F;
            this.textBox49.Left = 4.41F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox49.SummaryGroup = "BLGroupHeader";
            this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox49.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox49.Top = 0F;
            this.textBox49.Visible = false;
            this.textBox49.Width = 0.7F;
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
            this.textBox50.CanShrink = true;
            this.textBox50.DataField = "MonthlySalesCountAchivRate1";
            this.textBox50.Height = 0.16F;
            this.textBox50.Left = 5.125F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox50.SummaryGroup = "BLGroupHeader";
            this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox50.Text = "ZZZ9.99";
            this.textBox50.Top = 0F;
            this.textBox50.Visible = false;
            this.textBox50.Width = 0.45F;
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
            this.textBox51.CanShrink = true;
            this.textBox51.DataField = "TermSalesTargetCount1";
            this.textBox51.Height = 0.16F;
            this.textBox51.Left = 4.41F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox51.SummaryGroup = "BLGroupHeader";
            this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox51.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox51.Top = 0.1875F;
            this.textBox51.Visible = false;
            this.textBox51.Width = 0.7F;
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
            this.textBox58.CanShrink = true;
            this.textBox58.DataField = "TermSalesCountAchivRate1";
            this.textBox58.Height = 0.16F;
            this.textBox58.Left = 5.125F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox58.SummaryGroup = "BLGroupHeader";
            this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox58.Text = "ZZZ9.99";
            this.textBox58.Top = 0.1875F;
            this.textBox58.Visible = false;
            this.textBox58.Width = 0.45F;
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
            this.textBox59.CanShrink = true;
            this.textBox59.DataField = "MonthlySalesTarget1";
            this.textBox59.Height = 0.16F;
            this.textBox59.Left = 6.5625F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox59.SummaryGroup = "BLGroupHeader";
            this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox59.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox59.Top = 0F;
            this.textBox59.Visible = false;
            this.textBox59.Width = 0.9F;
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
            this.textBox68.CanShrink = true;
            this.textBox68.DataField = "TermSalesTarget1";
            this.textBox68.Height = 0.16F;
            this.textBox68.Left = 6.5625F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
            this.textBox68.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox68.SummaryGroup = "BLGroupHeader";
            this.textBox68.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox68.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox68.Top = 0.1875F;
            this.textBox68.Visible = false;
            this.textBox68.Width = 0.9F;
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
            this.textBox69.CanShrink = true;
            this.textBox69.DataField = "MonthlySalesMoneyAchivRate1";
            this.textBox69.Height = 0.16F;
            this.textBox69.Left = 7.5F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox69.SummaryGroup = "BLGroupHeader";
            this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox69.Text = "ZZZ9.99";
            this.textBox69.Top = 0F;
            this.textBox69.Visible = false;
            this.textBox69.Width = 0.45F;
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
            this.textBox70.CanShrink = true;
            this.textBox70.DataField = "TermSalesMoneyAchivRate1";
            this.textBox70.Height = 0.16F;
            this.textBox70.Left = 7.5F;
            this.textBox70.MultiLine = false;
            this.textBox70.Name = "textBox70";
            this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
            this.textBox70.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox70.SummaryGroup = "BLGroupHeader";
            this.textBox70.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox70.Text = "ZZZ9.99";
            this.textBox70.Top = 0.1875F;
            this.textBox70.Visible = false;
            this.textBox70.Width = 0.45F;
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
            this.textBox71.CanShrink = true;
            this.textBox71.DataField = "MonthlySalesTargetProfit1";
            this.textBox71.Height = 0.16F;
            this.textBox71.Left = 9.4375F;
            this.textBox71.MultiLine = false;
            this.textBox71.Name = "textBox71";
            this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
            this.textBox71.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox71.SummaryGroup = "BLGroupHeader";
            this.textBox71.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox71.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox71.Top = 0F;
            this.textBox71.Visible = false;
            this.textBox71.Width = 0.9F;
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
            this.textBox72.CanShrink = true;
            this.textBox72.DataField = "TermSalesTargetProfit1";
            this.textBox72.Height = 0.16F;
            this.textBox72.Left = 9.4375F;
            this.textBox72.MultiLine = false;
            this.textBox72.Name = "textBox72";
            this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
            this.textBox72.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox72.SummaryGroup = "BLGroupHeader";
            this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox72.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox72.Top = 0.1875F;
            this.textBox72.Visible = false;
            this.textBox72.Width = 0.9F;
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
            this.textBox73.CanShrink = true;
            this.textBox73.DataField = "MonthlySalesProfitAchivRate1";
            this.textBox73.Height = 0.16F;
            this.textBox73.Left = 10.375F;
            this.textBox73.MultiLine = false;
            this.textBox73.Name = "textBox73";
            this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
            this.textBox73.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox73.SummaryGroup = "BLGroupHeader";
            this.textBox73.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox73.Text = "ZZZ9.99";
            this.textBox73.Top = 0F;
            this.textBox73.Visible = false;
            this.textBox73.Width = 0.45F;
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
            this.textBox74.CanShrink = true;
            this.textBox74.DataField = "TermSalesProfitAchivRat1";
            this.textBox74.Height = 0.16F;
            this.textBox74.Left = 10.375F;
            this.textBox74.MultiLine = false;
            this.textBox74.Name = "textBox74";
            this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
            this.textBox74.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox74.SummaryGroup = "BLGroupHeader";
            this.textBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox74.Text = "ZZZ9.99";
            this.textBox74.Top = 0.1875F;
            this.textBox74.Visible = false;
            this.textBox74.Width = 0.45F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox60,
            this.textBox63,
            this.label15,
            this.line10,
            this.label17,
            this.textBox91,
            this.textBox120,
            this.line16});
            this.CustomerHeader.DataField = "CustomerCode";
            this.CustomerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.CustomerHeader.Height = 0.2F;
            this.CustomerHeader.KeepTogether = true;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.CustomerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.textBox60.DataField = "AddUpSecCode";
            this.textBox60.Height = 0.16F;
            this.textBox60.Left = 0.3125F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ " +
                "ゴシック; vertical-align: bottom; ";
            this.textBox60.Text = "12";
            this.textBox60.Top = 0F;
            this.textBox60.Width = 0.2F;
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
            this.textBox63.DataField = "SectionGuideNm";
            this.textBox63.Height = 0.16F;
            this.textBox63.Left = 0.5F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.textBox63.Text = "あいうえおかきくけこ";
            this.textBox63.Top = 0F;
            this.textBox63.Width = 1.2F;
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
            this.label15.Height = 0.16F;
            this.label15.HyperLink = "";
            this.label15.Left = 0F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label15.Text = "拠点";
            this.label15.Top = 0F;
            this.label15.Width = 0.313F;
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
            this.line10.Width = 10.85F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.85F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
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
            this.label17.Height = 0.16F;
            this.label17.HyperLink = "";
            this.label17.Left = 1.92F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label17.Text = "得意先";
            this.label17.Top = 0F;
            this.label17.Width = 0.37F;
            // 
            // textBox91
            // 
            this.textBox91.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.RightColor = System.Drawing.Color.Black;
            this.textBox91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.TopColor = System.Drawing.Color.Black;
            this.textBox91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.DataField = "CustomerCode";
            this.textBox91.Height = 0.16F;
            this.textBox91.Left = 2.3125F;
            this.textBox91.MultiLine = false;
            this.textBox91.Name = "textBox91";
            this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
            this.textBox91.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.textBox91.Text = "12345678";
            this.textBox91.Top = 0F;
            this.textBox91.Width = 0.475F;
            // 
            // textBox120
            // 
            this.textBox120.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.RightColor = System.Drawing.Color.Black;
            this.textBox120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.TopColor = System.Drawing.Color.Black;
            this.textBox120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.DataField = "CustomerSnm";
            this.textBox120.Height = 0.16F;
            this.textBox120.Left = 2.8125F;
            this.textBox120.MultiLine = false;
            this.textBox120.Name = "textBox120";
            this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
            this.textBox120.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.textBox120.Text = "あいうえおかきくけこ";
            this.textBox120.Top = 0F;
            this.textBox120.Width = 1.2F;
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
            this.line16.Height = 0F;
            this.line16.Left = 0F;
            this.line16.LineWeight = 1.5F;
            this.line16.Name = "line16";
            this.line16.Top = 0.16F;
            this.line16.Visible = false;
            this.line16.Width = 10.85F;
            this.line16.X1 = 0F;
            this.line16.X2 = 10.85F;
            this.line16.Y1 = 0.16F;
            this.line16.Y2 = 0.16F;
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.cuProfitRatio1,
            this.textBox61,
            this.textBox62,
            this.cuProfitRatio2,
            this.textBox64,
            this.textBox65,
            this.textBox66,
            this.textBox67,
            this.Lb_CusTotal,
            this.textBox124,
            this.textBox125,
            this.textBox126,
            this.textBox127,
            this.textBox128,
            this.textBox129,
            this.textBox130,
            this.textBox131,
            this.textBox132,
            this.textBox133,
            this.textBox134,
            this.textBox135});
            this.CustomerFooter.Height = 0.375F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
            this.CustomerFooter.Visible = false;
            this.CustomerFooter.BeforePrint += new System.EventHandler(this.CustomerFooter_BeforePrint);
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
            this.line2.Width = 10.85F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.85F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // cuProfitRatio1
            // 
            this.cuProfitRatio1.Border.BottomColor = System.Drawing.Color.Black;
            this.cuProfitRatio1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio1.Border.LeftColor = System.Drawing.Color.Black;
            this.cuProfitRatio1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio1.Border.RightColor = System.Drawing.Color.Black;
            this.cuProfitRatio1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio1.Border.TopColor = System.Drawing.Color.Black;
            this.cuProfitRatio1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio1.CanShrink = true;
            this.cuProfitRatio1.Height = 0.16F;
            this.cuProfitRatio1.Left = 8.9375F;
            this.cuProfitRatio1.MultiLine = false;
            this.cuProfitRatio1.Name = "cuProfitRatio1";
            this.cuProfitRatio1.OutputFormat = resources.GetString("cuProfitRatio1.OutputFormat");
            this.cuProfitRatio1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cuProfitRatio1.Text = "ZZZ9.99";
            this.cuProfitRatio1.Top = 0F;
            this.cuProfitRatio1.Width = 0.45F;
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
            this.textBox61.CanShrink = true;
            this.textBox61.DataField = "MonthlySalesMoney";
            this.textBox61.Height = 0.16F;
            this.textBox61.Left = 5.625F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox61.SummaryGroup = "CustomerHeader";
            this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox61.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox61.Top = 0F;
            this.textBox61.Width = 0.9F;
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
            this.textBox62.CanShrink = true;
            this.textBox62.DataField = "TermSalesMoney";
            this.textBox62.Height = 0.16F;
            this.textBox62.Left = 5.625F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox62.SummaryGroup = "CustomerHeader";
            this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox62.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox62.Top = 0.1875F;
            this.textBox62.Width = 0.9F;
            // 
            // cuProfitRatio2
            // 
            this.cuProfitRatio2.Border.BottomColor = System.Drawing.Color.Black;
            this.cuProfitRatio2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio2.Border.LeftColor = System.Drawing.Color.Black;
            this.cuProfitRatio2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio2.Border.RightColor = System.Drawing.Color.Black;
            this.cuProfitRatio2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio2.Border.TopColor = System.Drawing.Color.Black;
            this.cuProfitRatio2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cuProfitRatio2.CanShrink = true;
            this.cuProfitRatio2.Height = 0.16F;
            this.cuProfitRatio2.Left = 8.9375F;
            this.cuProfitRatio2.MultiLine = false;
            this.cuProfitRatio2.Name = "cuProfitRatio2";
            this.cuProfitRatio2.OutputFormat = resources.GetString("cuProfitRatio2.OutputFormat");
            this.cuProfitRatio2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cuProfitRatio2.Text = "ZZZ9.99";
            this.cuProfitRatio2.Top = 0.1875F;
            this.cuProfitRatio2.Width = 0.45F;
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
            this.textBox64.DataField = "MonthlySalesCount";
            this.textBox64.Height = 0.16F;
            this.textBox64.Left = 3.6875F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.SummaryGroup = "CustomerHeader";
            this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox64.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox64.Top = 0F;
            this.textBox64.Width = 0.7F;
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
            this.textBox65.DataField = "TermSalesCount";
            this.textBox65.Height = 0.16F;
            this.textBox65.Left = 3.6875F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
            this.textBox65.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox65.SummaryGroup = "CustomerHeader";
            this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox65.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox65.Top = 0.1875F;
            this.textBox65.Width = 0.7F;
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
            this.textBox66.CanShrink = true;
            this.textBox66.DataField = "MonthlySalesProfit";
            this.textBox66.Height = 0.16F;
            this.textBox66.Left = 8F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
            this.textBox66.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox66.SummaryGroup = "CustomerHeader";
            this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox66.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox66.Top = 0F;
            this.textBox66.Width = 0.9F;
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
            this.textBox67.CanShrink = true;
            this.textBox67.DataField = "TermSalesProfit";
            this.textBox67.Height = 0.16F;
            this.textBox67.Left = 8F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
            this.textBox67.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox67.SummaryGroup = "CustomerHeader";
            this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox67.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox67.Top = 0.1875F;
            this.textBox67.Width = 0.9F;
            // 
            // Lb_CusTotal
            // 
            this.Lb_CusTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CusTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CusTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CusTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CusTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CusTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CusTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CusTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CusTotal.Height = 0.2F;
            this.Lb_CusTotal.HyperLink = "";
            this.Lb_CusTotal.Left = 2.75F;
            this.Lb_CusTotal.MultiLine = false;
            this.Lb_CusTotal.Name = "Lb_CusTotal";
            this.Lb_CusTotal.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CusTotal.Text = "得意先計";
            this.Lb_CusTotal.Top = 0F;
            this.Lb_CusTotal.Width = 0.875F;
            // 
            // textBox124
            // 
            this.textBox124.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox124.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox124.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.Border.RightColor = System.Drawing.Color.Black;
            this.textBox124.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.Border.TopColor = System.Drawing.Color.Black;
            this.textBox124.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.CanShrink = true;
            this.textBox124.DataField = "MonthlySalesTargetCount3";
            this.textBox124.Height = 0.16F;
            this.textBox124.Left = 4.41F;
            this.textBox124.MultiLine = false;
            this.textBox124.Name = "textBox124";
            this.textBox124.OutputFormat = resources.GetString("textBox124.OutputFormat");
            this.textBox124.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox124.SummaryGroup = "CustomerHeader";
            this.textBox124.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox124.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox124.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox124.Top = 0F;
            this.textBox124.Visible = false;
            this.textBox124.Width = 0.7F;
            // 
            // textBox125
            // 
            this.textBox125.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox125.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox125.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Border.RightColor = System.Drawing.Color.Black;
            this.textBox125.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Border.TopColor = System.Drawing.Color.Black;
            this.textBox125.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.CanShrink = true;
            this.textBox125.Height = 0.16F;
            this.textBox125.Left = 5.125F;
            this.textBox125.MultiLine = false;
            this.textBox125.Name = "textBox125";
            this.textBox125.OutputFormat = resources.GetString("textBox125.OutputFormat");
            this.textBox125.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox125.Text = "ZZZ9.99";
            this.textBox125.Top = 0F;
            this.textBox125.Visible = false;
            this.textBox125.Width = 0.45F;
            // 
            // textBox126
            // 
            this.textBox126.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox126.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox126.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Border.RightColor = System.Drawing.Color.Black;
            this.textBox126.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Border.TopColor = System.Drawing.Color.Black;
            this.textBox126.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.CanShrink = true;
            this.textBox126.DataField = "TermSalesTargetCount3";
            this.textBox126.Height = 0.16F;
            this.textBox126.Left = 4.41F;
            this.textBox126.MultiLine = false;
            this.textBox126.Name = "textBox126";
            this.textBox126.OutputFormat = resources.GetString("textBox126.OutputFormat");
            this.textBox126.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox126.SummaryGroup = "CustomerHeader";
            this.textBox126.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox126.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox126.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox126.Top = 0.1875F;
            this.textBox126.Visible = false;
            this.textBox126.Width = 0.7F;
            // 
            // textBox127
            // 
            this.textBox127.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox127.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox127.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.Border.RightColor = System.Drawing.Color.Black;
            this.textBox127.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.Border.TopColor = System.Drawing.Color.Black;
            this.textBox127.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.CanShrink = true;
            this.textBox127.Height = 0.16F;
            this.textBox127.Left = 5.125F;
            this.textBox127.MultiLine = false;
            this.textBox127.Name = "textBox127";
            this.textBox127.OutputFormat = resources.GetString("textBox127.OutputFormat");
            this.textBox127.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox127.Text = "ZZZ9.99";
            this.textBox127.Top = 0.1875F;
            this.textBox127.Visible = false;
            this.textBox127.Width = 0.45F;
            // 
            // textBox128
            // 
            this.textBox128.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox128.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox128.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.Border.RightColor = System.Drawing.Color.Black;
            this.textBox128.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.Border.TopColor = System.Drawing.Color.Black;
            this.textBox128.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.CanShrink = true;
            this.textBox128.DataField = "MonthlySalesTarget3";
            this.textBox128.Height = 0.16F;
            this.textBox128.Left = 6.5625F;
            this.textBox128.MultiLine = false;
            this.textBox128.Name = "textBox128";
            this.textBox128.OutputFormat = resources.GetString("textBox128.OutputFormat");
            this.textBox128.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox128.SummaryGroup = "CustomerHeader";
            this.textBox128.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox128.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox128.Top = 0F;
            this.textBox128.Visible = false;
            this.textBox128.Width = 0.9F;
            // 
            // textBox129
            // 
            this.textBox129.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox129.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox129.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Border.RightColor = System.Drawing.Color.Black;
            this.textBox129.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Border.TopColor = System.Drawing.Color.Black;
            this.textBox129.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.CanShrink = true;
            this.textBox129.DataField = "TermSalesTarget3";
            this.textBox129.Height = 0.16F;
            this.textBox129.Left = 6.5625F;
            this.textBox129.MultiLine = false;
            this.textBox129.Name = "textBox129";
            this.textBox129.OutputFormat = resources.GetString("textBox129.OutputFormat");
            this.textBox129.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox129.SummaryGroup = "CustomerHeader";
            this.textBox129.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox129.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox129.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox129.Top = 0.1875F;
            this.textBox129.Visible = false;
            this.textBox129.Width = 0.9F;
            // 
            // textBox130
            // 
            this.textBox130.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.Border.RightColor = System.Drawing.Color.Black;
            this.textBox130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.Border.TopColor = System.Drawing.Color.Black;
            this.textBox130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.CanShrink = true;
            this.textBox130.Height = 0.16F;
            this.textBox130.Left = 7.5F;
            this.textBox130.MultiLine = false;
            this.textBox130.Name = "textBox130";
            this.textBox130.OutputFormat = resources.GetString("textBox130.OutputFormat");
            this.textBox130.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox130.Text = "ZZZ9.99";
            this.textBox130.Top = 0F;
            this.textBox130.Visible = false;
            this.textBox130.Width = 0.45F;
            // 
            // textBox131
            // 
            this.textBox131.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.RightColor = System.Drawing.Color.Black;
            this.textBox131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.TopColor = System.Drawing.Color.Black;
            this.textBox131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.CanShrink = true;
            this.textBox131.Height = 0.16F;
            this.textBox131.Left = 7.5F;
            this.textBox131.MultiLine = false;
            this.textBox131.Name = "textBox131";
            this.textBox131.OutputFormat = resources.GetString("textBox131.OutputFormat");
            this.textBox131.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox131.Text = "ZZZ9.99";
            this.textBox131.Top = 0.1875F;
            this.textBox131.Visible = false;
            this.textBox131.Width = 0.45F;
            // 
            // textBox132
            // 
            this.textBox132.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Border.RightColor = System.Drawing.Color.Black;
            this.textBox132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Border.TopColor = System.Drawing.Color.Black;
            this.textBox132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.CanShrink = true;
            this.textBox132.DataField = "MonthlySalesTargetProfit3";
            this.textBox132.Height = 0.16F;
            this.textBox132.Left = 9.4375F;
            this.textBox132.MultiLine = false;
            this.textBox132.Name = "textBox132";
            this.textBox132.OutputFormat = resources.GetString("textBox132.OutputFormat");
            this.textBox132.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox132.SummaryGroup = "CustomerHeader";
            this.textBox132.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox132.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox132.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox132.Top = 0F;
            this.textBox132.Visible = false;
            this.textBox132.Width = 0.9F;
            // 
            // textBox133
            // 
            this.textBox133.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox133.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox133.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.Border.RightColor = System.Drawing.Color.Black;
            this.textBox133.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.Border.TopColor = System.Drawing.Color.Black;
            this.textBox133.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.CanShrink = true;
            this.textBox133.DataField = "TermSalesTargetProfit3";
            this.textBox133.Height = 0.16F;
            this.textBox133.Left = 9.4375F;
            this.textBox133.MultiLine = false;
            this.textBox133.Name = "textBox133";
            this.textBox133.OutputFormat = resources.GetString("textBox133.OutputFormat");
            this.textBox133.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox133.SummaryGroup = "CustomerHeader";
            this.textBox133.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox133.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox133.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox133.Top = 0.1875F;
            this.textBox133.Visible = false;
            this.textBox133.Width = 0.9F;
            // 
            // textBox134
            // 
            this.textBox134.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.RightColor = System.Drawing.Color.Black;
            this.textBox134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.TopColor = System.Drawing.Color.Black;
            this.textBox134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.CanShrink = true;
            this.textBox134.Height = 0.16F;
            this.textBox134.Left = 10.375F;
            this.textBox134.MultiLine = false;
            this.textBox134.Name = "textBox134";
            this.textBox134.OutputFormat = resources.GetString("textBox134.OutputFormat");
            this.textBox134.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox134.Text = "ZZZ9.99";
            this.textBox134.Top = 0.1875F;
            this.textBox134.Visible = false;
            this.textBox134.Width = 0.45F;
            // 
            // textBox135
            // 
            this.textBox135.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox135.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox135.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Border.RightColor = System.Drawing.Color.Black;
            this.textBox135.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Border.TopColor = System.Drawing.Color.Black;
            this.textBox135.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.CanShrink = true;
            this.textBox135.Height = 0.16F;
            this.textBox135.Left = 10.375F;
            this.textBox135.MultiLine = false;
            this.textBox135.Name = "textBox135";
            this.textBox135.OutputFormat = resources.GetString("textBox135.OutputFormat");
            this.textBox135.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox135.Text = "ZZZ9.99";
            this.textBox135.Top = 0F;
            this.textBox135.Visible = false;
            this.textBox135.Width = 0.45F;
            // 
            // AreaHeader
            // 
            this.AreaHeader.CanShrink = true;
            this.AreaHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ArHd_AddUpSecCode,
            this.ArHd_SectionGuideNm,
            this.ArHd_AreaCd,
            this.ArHd_AreaNm,
            this.ArHd_SectionTitle,
            this.ArHd_AreaTitle,
            this.line7,
            this.line14});
            this.AreaHeader.DataField = "HeaderKey1";
            this.AreaHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.AreaHeader.Height = 0.25F;
            this.AreaHeader.KeepTogether = true;
            this.AreaHeader.Name = "AreaHeader";
            this.AreaHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.AreaHeader.Visible = false;
            // 
            // ArHd_AddUpSecCode
            // 
            this.ArHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.ArHd_AddUpSecCode.Height = 0.16F;
            this.ArHd_AddUpSecCode.Left = 0.3125F;
            this.ArHd_AddUpSecCode.MultiLine = false;
            this.ArHd_AddUpSecCode.Name = "ArHd_AddUpSecCode";
            this.ArHd_AddUpSecCode.OutputFormat = resources.GetString("ArHd_AddUpSecCode.OutputFormat");
            this.ArHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.ArHd_AddUpSecCode.Text = "12";
            this.ArHd_AddUpSecCode.Top = 0F;
            this.ArHd_AddUpSecCode.Width = 0.2F;
            // 
            // ArHd_SectionGuideNm
            // 
            this.ArHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionGuideNm.DataField = "SectionGuideNm";
            this.ArHd_SectionGuideNm.Height = 0.16F;
            this.ArHd_SectionGuideNm.Left = 0.5F;
            this.ArHd_SectionGuideNm.MultiLine = false;
            this.ArHd_SectionGuideNm.Name = "ArHd_SectionGuideNm";
            this.ArHd_SectionGuideNm.OutputFormat = resources.GetString("ArHd_SectionGuideNm.OutputFormat");
            this.ArHd_SectionGuideNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.ArHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.ArHd_SectionGuideNm.Top = 0F;
            this.ArHd_SectionGuideNm.Width = 1.2F;
            // 
            // ArHd_AreaCd
            // 
            this.ArHd_AreaCd.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_AreaCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaCd.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_AreaCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaCd.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_AreaCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaCd.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_AreaCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaCd.DataField = "AreaCode";
            this.ArHd_AreaCd.Height = 0.16F;
            this.ArHd_AreaCd.Left = 2.21F;
            this.ArHd_AreaCd.MultiLine = false;
            this.ArHd_AreaCd.Name = "ArHd_AreaCd";
            this.ArHd_AreaCd.OutputFormat = resources.GetString("ArHd_AreaCd.OutputFormat");
            this.ArHd_AreaCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.ArHd_AreaCd.Text = "1234";
            this.ArHd_AreaCd.Top = 0F;
            this.ArHd_AreaCd.Width = 0.25F;
            // 
            // ArHd_AreaNm
            // 
            this.ArHd_AreaNm.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_AreaNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaNm.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_AreaNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaNm.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_AreaNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaNm.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_AreaNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaNm.DataField = "AreaName";
            this.ArHd_AreaNm.Height = 0.16F;
            this.ArHd_AreaNm.Left = 2.5F;
            this.ArHd_AreaNm.MultiLine = false;
            this.ArHd_AreaNm.Name = "ArHd_AreaNm";
            this.ArHd_AreaNm.OutputFormat = resources.GetString("ArHd_AreaNm.OutputFormat");
            this.ArHd_AreaNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.ArHd_AreaNm.Text = "あいうえおかきくけこ";
            this.ArHd_AreaNm.Top = 0F;
            this.ArHd_AreaNm.Width = 1.2F;
            // 
            // ArHd_SectionTitle
            // 
            this.ArHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_SectionTitle.Height = 0.16F;
            this.ArHd_SectionTitle.HyperLink = "";
            this.ArHd_SectionTitle.Left = 0F;
            this.ArHd_SectionTitle.MultiLine = false;
            this.ArHd_SectionTitle.Name = "ArHd_SectionTitle";
            this.ArHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.ArHd_SectionTitle.Text = "拠点";
            this.ArHd_SectionTitle.Top = 0F;
            this.ArHd_SectionTitle.Width = 0.313F;
            // 
            // ArHd_AreaTitle
            // 
            this.ArHd_AreaTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_AreaTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_AreaTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaTitle.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_AreaTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaTitle.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_AreaTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_AreaTitle.Height = 0.16F;
            this.ArHd_AreaTitle.HyperLink = "";
            this.ArHd_AreaTitle.Left = 1.92F;
            this.ArHd_AreaTitle.MultiLine = false;
            this.ArHd_AreaTitle.Name = "ArHd_AreaTitle";
            this.ArHd_AreaTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.ArHd_AreaTitle.Text = "地区";
            this.ArHd_AreaTitle.Top = 0F;
            this.ArHd_AreaTitle.Width = 0.28F;
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
            this.line7.Top = 0F;
            this.line7.Width = 10.85F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.85F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
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
            this.line14.Height = 0F;
            this.line14.Left = 0F;
            this.line14.LineWeight = 1.5F;
            this.line14.Name = "line14";
            this.line14.Top = 0.16F;
            this.line14.Visible = false;
            this.line14.Width = 10.85F;
            this.line14.X1 = 0F;
            this.line14.X2 = 10.85F;
            this.line14.Y1 = 0.16F;
            this.line14.Y2 = 0.16F;
            // 
            // AreaFooter
            // 
            this.AreaFooter.CanShrink = true;
            this.AreaFooter.Height = 0F;
            this.AreaFooter.KeepTogether = true;
            this.AreaFooter.Name = "AreaFooter";
            this.AreaFooter.Visible = false;
            // 
            // empHeader
            // 
            this.empHeader.DataField = "EmployeeCode";
            this.empHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.empHeader.Height = 0F;
            this.empHeader.KeepTogether = true;
            this.empHeader.Name = "empHeader";
            this.empHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.empHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // empFooter
            // 
            this.empFooter.CanShrink = true;
            this.empFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line4,
            this.suTotalSalesCount,
            this.suCmpPureSalesRatio,
            this.suProfitRatio,
            this.textBox10,
            this.textBox11,
            this.textBox25,
            this.textBox9,
            this.textBox12,
            this.textBox3,
            this.textBox6,
            this.textBox7,
            this.grGoalsCount,
            this.textBox35,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox52,
            this.textBox53,
            this.Lb_EmpTotal,
            this.textBox48});
            this.empFooter.Height = 0.4166667F;
            this.empFooter.KeepTogether = true;
            this.empFooter.Name = "empFooter";
            this.empFooter.Visible = false;
            this.empFooter.BeforePrint += new System.EventHandler(this.empFooter_BeforePrint);
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
            this.line4.Width = 10.85F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.85F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // suTotalSalesCount
            // 
            this.suTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.CanShrink = true;
            this.suTotalSalesCount.DataField = "TermSalesTarget1";
            this.suTotalSalesCount.Height = 0.16F;
            this.suTotalSalesCount.Left = 6.5625F;
            this.suTotalSalesCount.MultiLine = false;
            this.suTotalSalesCount.Name = "suTotalSalesCount";
            this.suTotalSalesCount.OutputFormat = resources.GetString("suTotalSalesCount.OutputFormat");
            this.suTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suTotalSalesCount.SummaryGroup = "empHeader";
            this.suTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suTotalSalesCount.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.suTotalSalesCount.Top = 0.1875F;
            this.suTotalSalesCount.Width = 0.9F;
            // 
            // suCmpPureSalesRatio
            // 
            this.suCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.CanShrink = true;
            this.suCmpPureSalesRatio.Height = 0.16F;
            this.suCmpPureSalesRatio.Left = 7.5F;
            this.suCmpPureSalesRatio.MultiLine = false;
            this.suCmpPureSalesRatio.Name = "suCmpPureSalesRatio";
            this.suCmpPureSalesRatio.OutputFormat = resources.GetString("suCmpPureSalesRatio.OutputFormat");
            this.suCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suCmpPureSalesRatio.Text = "ZZZ9.99";
            this.suCmpPureSalesRatio.Top = 0.1875F;
            this.suCmpPureSalesRatio.Width = 0.45F;
            // 
            // suProfitRatio
            // 
            this.suProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.CanShrink = true;
            this.suProfitRatio.Height = 0.16F;
            this.suProfitRatio.Left = 8.9375F;
            this.suProfitRatio.MultiLine = false;
            this.suProfitRatio.Name = "suProfitRatio";
            this.suProfitRatio.OutputFormat = resources.GetString("suProfitRatio.OutputFormat");
            this.suProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suProfitRatio.Text = "ZZZ9.99";
            this.suProfitRatio.Top = 0F;
            this.suProfitRatio.Width = 0.45F;
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
            this.textBox10.CanShrink = true;
            this.textBox10.DataField = "MonthlySalesTargetCount1";
            this.textBox10.Height = 0.16F;
            this.textBox10.Left = 4.41F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox10.SummaryGroup = "empHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.7F;
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
            this.textBox11.CanShrink = true;
            this.textBox11.DataField = "TermSalesTargetCount1";
            this.textBox11.Height = 0.16F;
            this.textBox11.Left = 4.41F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox11.SummaryGroup = "empHeader";
            this.textBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox11.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox11.Top = 0.1875F;
            this.textBox11.Width = 0.7F;
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
            this.textBox25.CanShrink = true;
            this.textBox25.Height = 0.16F;
            this.textBox25.Left = 8.9375F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox25.Text = "ZZZ9.99";
            this.textBox25.Top = 0.1875F;
            this.textBox25.Width = 0.45F;
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
            this.textBox9.DataField = "MonthlySalesCount";
            this.textBox9.Height = 0.16F;
            this.textBox9.Left = 3.6875F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox9.SummaryGroup = "empHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox9.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.7F;
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
            this.textBox12.DataField = "TermSalesCount";
            this.textBox12.Height = 0.16F;
            this.textBox12.Left = 3.6875F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox12.SummaryGroup = "empHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox12.Top = 0.1875F;
            this.textBox12.Width = 0.7F;
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
            this.textBox3.CanShrink = true;
            this.textBox3.Height = 0.16F;
            this.textBox3.Left = 5.125F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox3.Text = "ZZZ9.99";
            this.textBox3.Top = 0.1875F;
            this.textBox3.Width = 0.45F;
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
            this.textBox6.CanShrink = true;
            this.textBox6.DataField = "MonthlySalesMoney";
            this.textBox6.Height = 0.16F;
            this.textBox6.Left = 5.625F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.SummaryGroup = "empHeader";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.9F;
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
            this.textBox7.CanShrink = true;
            this.textBox7.DataField = "TermSalesMoney";
            this.textBox7.Height = 0.16F;
            this.textBox7.Left = 5.625F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox7.SummaryGroup = "empHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox7.Top = 0.1875F;
            this.textBox7.Width = 0.9F;
            // 
            // grGoalsCount
            // 
            this.grGoalsCount.Border.BottomColor = System.Drawing.Color.Black;
            this.grGoalsCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGoalsCount.Border.LeftColor = System.Drawing.Color.Black;
            this.grGoalsCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGoalsCount.Border.RightColor = System.Drawing.Color.Black;
            this.grGoalsCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGoalsCount.Border.TopColor = System.Drawing.Color.Black;
            this.grGoalsCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGoalsCount.CanShrink = true;
            this.grGoalsCount.DataField = "MonthlySalesTarget1";
            this.grGoalsCount.Height = 0.16F;
            this.grGoalsCount.Left = 6.5625F;
            this.grGoalsCount.MultiLine = false;
            this.grGoalsCount.Name = "grGoalsCount";
            this.grGoalsCount.OutputFormat = resources.GetString("grGoalsCount.OutputFormat");
            this.grGoalsCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grGoalsCount.SummaryGroup = "empHeader";
            this.grGoalsCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grGoalsCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grGoalsCount.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.grGoalsCount.Top = 0F;
            this.grGoalsCount.Width = 0.9F;
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
            this.textBox35.CanShrink = true;
            this.textBox35.Height = 0.16F;
            this.textBox35.Left = 7.5F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox35.Text = "ZZZ9.99";
            this.textBox35.Top = 0F;
            this.textBox35.Width = 0.45F;
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
            this.textBox44.CanShrink = true;
            this.textBox44.DataField = "TermSalesProfit";
            this.textBox44.Height = 0.16F;
            this.textBox44.Left = 8F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.SummaryGroup = "empHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox44.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox44.Top = 0.1875F;
            this.textBox44.Width = 0.9F;
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
            this.textBox45.CanShrink = true;
            this.textBox45.DataField = "MonthlySalesProfit";
            this.textBox45.Height = 0.16F;
            this.textBox45.Left = 8F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox45.SummaryGroup = "empHeader";
            this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox45.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox45.Top = 0F;
            this.textBox45.Width = 0.9F;
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
            this.textBox46.CanShrink = true;
            this.textBox46.DataField = "TermSalesTargetProfit1";
            this.textBox46.Height = 0.16F;
            this.textBox46.Left = 9.4375F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryGroup = "empHeader";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox46.Top = 0.1875F;
            this.textBox46.Width = 0.9F;
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
            this.textBox47.CanShrink = true;
            this.textBox47.DataField = "MonthlySalesTargetProfit1";
            this.textBox47.Height = 0.16F;
            this.textBox47.Left = 9.4375F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox47.SummaryGroup = "empHeader";
            this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox47.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox47.Top = 0F;
            this.textBox47.Width = 0.9F;
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
            this.textBox52.CanShrink = true;
            this.textBox52.Height = 0.16F;
            this.textBox52.Left = 10.375F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox52.Text = "ZZZ9.99";
            this.textBox52.Top = 0F;
            this.textBox52.Width = 0.45F;
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
            this.textBox53.CanShrink = true;
            this.textBox53.Height = 0.16F;
            this.textBox53.Left = 10.375F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox53.Text = "ZZZ9.99";
            this.textBox53.Top = 0.1875F;
            this.textBox53.Width = 0.45F;
            // 
            // Lb_EmpTotal
            // 
            this.Lb_EmpTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_EmpTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EmpTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_EmpTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EmpTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_EmpTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EmpTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_EmpTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EmpTotal.Height = 0.2F;
            this.Lb_EmpTotal.HyperLink = "";
            this.Lb_EmpTotal.Left = 2.75F;
            this.Lb_EmpTotal.MultiLine = false;
            this.Lb_EmpTotal.Name = "Lb_EmpTotal";
            this.Lb_EmpTotal.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_EmpTotal.Text = "担当者計";
            this.Lb_EmpTotal.Top = 0F;
            this.Lb_EmpTotal.Width = 0.875F;
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
            this.textBox48.CanShrink = true;
            this.textBox48.Height = 0.16F;
            this.textBox48.Left = 5.125F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox48.Text = "ZZZ9.99";
            this.textBox48.Top = 0F;
            this.textBox48.Width = 0.45F;
            // 
            // arHeader
            // 
            this.arHeader.DataField = "AreaCode";
            this.arHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.arHeader.Height = 0F;
            this.arHeader.KeepTogether = true;
            this.arHeader.Name = "arHeader";
            this.arHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.arHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // arFooter
            // 
            this.arFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Lb_AreaTotal,
            this.arCmpPureSalesRatio,
            this.arProfitRatio,
            this.textBox104,
            this.textBox105,
            this.textBox106,
            this.textBox107,
            this.textBox108,
            this.textBox109,
            this.textBox110,
            this.textBox111,
            this.textBox112,
            this.textBox113,
            this.textBox114,
            this.textBox115,
            this.textBox116,
            this.textBox117,
            this.textBox118,
            this.textBox119,
            this.arTotalSalesCount,
            this.textBox121,
            this.line9});
            this.arFooter.Height = 0.41F;
            this.arFooter.KeepTogether = true;
            this.arFooter.Name = "arFooter";
            this.arFooter.Visible = false;
            this.arFooter.BeforePrint += new System.EventHandler(this.AreaFooter_BeforePrint);
            // 
            // Lb_AreaTotal
            // 
            this.Lb_AreaTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AreaTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AreaTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AreaTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AreaTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AreaTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AreaTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AreaTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AreaTotal.Height = 0.2F;
            this.Lb_AreaTotal.HyperLink = "";
            this.Lb_AreaTotal.Left = 2.75F;
            this.Lb_AreaTotal.MultiLine = false;
            this.Lb_AreaTotal.Name = "Lb_AreaTotal";
            this.Lb_AreaTotal.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AreaTotal.Text = "地区計";
            this.Lb_AreaTotal.Top = 0F;
            this.Lb_AreaTotal.Width = 0.875F;
            // 
            // arCmpPureSalesRatio
            // 
            this.arCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.arCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.arCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.arCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.arCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arCmpPureSalesRatio.CanShrink = true;
            this.arCmpPureSalesRatio.Height = 0.16F;
            this.arCmpPureSalesRatio.Left = 7.5F;
            this.arCmpPureSalesRatio.MultiLine = false;
            this.arCmpPureSalesRatio.Name = "arCmpPureSalesRatio";
            this.arCmpPureSalesRatio.OutputFormat = resources.GetString("arCmpPureSalesRatio.OutputFormat");
            this.arCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.arCmpPureSalesRatio.Text = "ZZZ9.99";
            this.arCmpPureSalesRatio.Top = 0.1875F;
            this.arCmpPureSalesRatio.Width = 0.45F;
            // 
            // arProfitRatio
            // 
            this.arProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.arProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.arProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.arProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.arProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arProfitRatio.CanShrink = true;
            this.arProfitRatio.DataField = "MonthlySalesProfitRate";
            this.arProfitRatio.Height = 0.16F;
            this.arProfitRatio.Left = 8.9375F;
            this.arProfitRatio.MultiLine = false;
            this.arProfitRatio.Name = "arProfitRatio";
            this.arProfitRatio.OutputFormat = resources.GetString("arProfitRatio.OutputFormat");
            this.arProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.arProfitRatio.Text = "ZZZ9.99";
            this.arProfitRatio.Top = 0F;
            this.arProfitRatio.Width = 0.45F;
            // 
            // textBox104
            // 
            this.textBox104.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.Border.RightColor = System.Drawing.Color.Black;
            this.textBox104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.Border.TopColor = System.Drawing.Color.Black;
            this.textBox104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.CanShrink = true;
            this.textBox104.DataField = "MonthlySalesTargetCount1";
            this.textBox104.Height = 0.16F;
            this.textBox104.Left = 4.41F;
            this.textBox104.MultiLine = false;
            this.textBox104.Name = "textBox104";
            this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
            this.textBox104.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox104.SummaryGroup = "arHeader";
            this.textBox104.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox104.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox104.Top = 0F;
            this.textBox104.Width = 0.7F;
            // 
            // textBox105
            // 
            this.textBox105.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.Border.RightColor = System.Drawing.Color.Black;
            this.textBox105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.Border.TopColor = System.Drawing.Color.Black;
            this.textBox105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.CanShrink = true;
            this.textBox105.DataField = "TermSalesProfitRate";
            this.textBox105.Height = 0.16F;
            this.textBox105.Left = 8.9375F;
            this.textBox105.MultiLine = false;
            this.textBox105.Name = "textBox105";
            this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
            this.textBox105.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox105.Text = "ZZZ9.99";
            this.textBox105.Top = 0.1875F;
            this.textBox105.Width = 0.45F;
            // 
            // textBox106
            // 
            this.textBox106.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.RightColor = System.Drawing.Color.Black;
            this.textBox106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.TopColor = System.Drawing.Color.Black;
            this.textBox106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.DataField = "MonthlySalesCount";
            this.textBox106.Height = 0.16F;
            this.textBox106.Left = 3.6875F;
            this.textBox106.MultiLine = false;
            this.textBox106.Name = "textBox106";
            this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
            this.textBox106.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox106.SummaryGroup = "arHeader";
            this.textBox106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox106.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox106.Top = 0F;
            this.textBox106.Width = 0.7F;
            // 
            // textBox107
            // 
            this.textBox107.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.Border.RightColor = System.Drawing.Color.Black;
            this.textBox107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.Border.TopColor = System.Drawing.Color.Black;
            this.textBox107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.DataField = "TermSalesCount";
            this.textBox107.Height = 0.16F;
            this.textBox107.Left = 3.6875F;
            this.textBox107.MultiLine = false;
            this.textBox107.Name = "textBox107";
            this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
            this.textBox107.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox107.SummaryGroup = "arHeader";
            this.textBox107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox107.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox107.Top = 0.1875F;
            this.textBox107.Width = 0.7F;
            // 
            // textBox108
            // 
            this.textBox108.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Border.RightColor = System.Drawing.Color.Black;
            this.textBox108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Border.TopColor = System.Drawing.Color.Black;
            this.textBox108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.CanShrink = true;
            this.textBox108.Height = 0.16F;
            this.textBox108.Left = 5.125F;
            this.textBox108.MultiLine = false;
            this.textBox108.Name = "textBox108";
            this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
            this.textBox108.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox108.Text = "ZZZ9.99";
            this.textBox108.Top = 0.1875F;
            this.textBox108.Width = 0.45F;
            // 
            // textBox109
            // 
            this.textBox109.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.Border.RightColor = System.Drawing.Color.Black;
            this.textBox109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.Border.TopColor = System.Drawing.Color.Black;
            this.textBox109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.CanShrink = true;
            this.textBox109.Height = 0.16F;
            this.textBox109.Left = 5.125F;
            this.textBox109.MultiLine = false;
            this.textBox109.Name = "textBox109";
            this.textBox109.OutputFormat = resources.GetString("textBox109.OutputFormat");
            this.textBox109.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox109.Text = "ZZZ9.99";
            this.textBox109.Top = 0F;
            this.textBox109.Width = 0.45F;
            // 
            // textBox110
            // 
            this.textBox110.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.Border.RightColor = System.Drawing.Color.Black;
            this.textBox110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.Border.TopColor = System.Drawing.Color.Black;
            this.textBox110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.CanShrink = true;
            this.textBox110.DataField = "MonthlySalesMoney";
            this.textBox110.Height = 0.16F;
            this.textBox110.Left = 5.625F;
            this.textBox110.MultiLine = false;
            this.textBox110.Name = "textBox110";
            this.textBox110.OutputFormat = resources.GetString("textBox110.OutputFormat");
            this.textBox110.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox110.SummaryGroup = "arHeader";
            this.textBox110.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox110.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox110.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox110.Top = 0F;
            this.textBox110.Width = 0.9F;
            // 
            // textBox111
            // 
            this.textBox111.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox111.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox111.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Border.RightColor = System.Drawing.Color.Black;
            this.textBox111.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Border.TopColor = System.Drawing.Color.Black;
            this.textBox111.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.CanShrink = true;
            this.textBox111.DataField = "TermSalesMoney";
            this.textBox111.Height = 0.16F;
            this.textBox111.Left = 5.625F;
            this.textBox111.MultiLine = false;
            this.textBox111.Name = "textBox111";
            this.textBox111.OutputFormat = resources.GetString("textBox111.OutputFormat");
            this.textBox111.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox111.SummaryGroup = "arHeader";
            this.textBox111.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox111.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox111.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox111.Top = 0.1875F;
            this.textBox111.Width = 0.9F;
            // 
            // textBox112
            // 
            this.textBox112.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.Border.RightColor = System.Drawing.Color.Black;
            this.textBox112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.Border.TopColor = System.Drawing.Color.Black;
            this.textBox112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.CanShrink = true;
            this.textBox112.DataField = "MonthlySalesTarget1";
            this.textBox112.Height = 0.16F;
            this.textBox112.Left = 6.5625F;
            this.textBox112.MultiLine = false;
            this.textBox112.Name = "textBox112";
            this.textBox112.OutputFormat = resources.GetString("textBox112.OutputFormat");
            this.textBox112.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox112.SummaryGroup = "arHeader";
            this.textBox112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox112.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox112.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox112.Top = 0F;
            this.textBox112.Width = 0.9F;
            // 
            // textBox113
            // 
            this.textBox113.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox113.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox113.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.Border.RightColor = System.Drawing.Color.Black;
            this.textBox113.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.Border.TopColor = System.Drawing.Color.Black;
            this.textBox113.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.CanShrink = true;
            this.textBox113.Height = 0.16F;
            this.textBox113.Left = 7.5F;
            this.textBox113.MultiLine = false;
            this.textBox113.Name = "textBox113";
            this.textBox113.OutputFormat = resources.GetString("textBox113.OutputFormat");
            this.textBox113.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox113.Text = "ZZZ9.99";
            this.textBox113.Top = 0F;
            this.textBox113.Width = 0.45F;
            // 
            // textBox114
            // 
            this.textBox114.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.Border.RightColor = System.Drawing.Color.Black;
            this.textBox114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.Border.TopColor = System.Drawing.Color.Black;
            this.textBox114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.CanShrink = true;
            this.textBox114.DataField = "TermSalesProfit";
            this.textBox114.Height = 0.16F;
            this.textBox114.Left = 8F;
            this.textBox114.MultiLine = false;
            this.textBox114.Name = "textBox114";
            this.textBox114.OutputFormat = resources.GetString("textBox114.OutputFormat");
            this.textBox114.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox114.SummaryGroup = "arHeader";
            this.textBox114.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox114.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox114.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox114.Top = 0.1875F;
            this.textBox114.Width = 0.9F;
            // 
            // textBox115
            // 
            this.textBox115.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox115.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox115.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Border.RightColor = System.Drawing.Color.Black;
            this.textBox115.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Border.TopColor = System.Drawing.Color.Black;
            this.textBox115.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.CanShrink = true;
            this.textBox115.DataField = "MonthlySalesProfit";
            this.textBox115.Height = 0.16F;
            this.textBox115.Left = 8F;
            this.textBox115.MultiLine = false;
            this.textBox115.Name = "textBox115";
            this.textBox115.OutputFormat = resources.GetString("textBox115.OutputFormat");
            this.textBox115.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox115.SummaryGroup = "arHeader";
            this.textBox115.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox115.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox115.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox115.Top = 0F;
            this.textBox115.Width = 0.9F;
            // 
            // textBox116
            // 
            this.textBox116.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.RightColor = System.Drawing.Color.Black;
            this.textBox116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.TopColor = System.Drawing.Color.Black;
            this.textBox116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.CanShrink = true;
            this.textBox116.DataField = "TermSalesTargetProfit1";
            this.textBox116.Height = 0.16F;
            this.textBox116.Left = 9.4375F;
            this.textBox116.MultiLine = false;
            this.textBox116.Name = "textBox116";
            this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
            this.textBox116.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox116.SummaryGroup = "arHeader";
            this.textBox116.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox116.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox116.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox116.Top = 0.1875F;
            this.textBox116.Width = 0.9F;
            // 
            // textBox117
            // 
            this.textBox117.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox117.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox117.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Border.RightColor = System.Drawing.Color.Black;
            this.textBox117.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Border.TopColor = System.Drawing.Color.Black;
            this.textBox117.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.CanShrink = true;
            this.textBox117.DataField = "MonthlySalesTargetProfit1";
            this.textBox117.Height = 0.16F;
            this.textBox117.Left = 9.4375F;
            this.textBox117.MultiLine = false;
            this.textBox117.Name = "textBox117";
            this.textBox117.OutputFormat = resources.GetString("textBox117.OutputFormat");
            this.textBox117.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox117.SummaryGroup = "arHeader";
            this.textBox117.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox117.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox117.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox117.Top = 0F;
            this.textBox117.Width = 0.9F;
            // 
            // textBox118
            // 
            this.textBox118.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox118.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox118.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.Border.RightColor = System.Drawing.Color.Black;
            this.textBox118.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.Border.TopColor = System.Drawing.Color.Black;
            this.textBox118.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.CanShrink = true;
            this.textBox118.Height = 0.16F;
            this.textBox118.Left = 10.375F;
            this.textBox118.MultiLine = false;
            this.textBox118.Name = "textBox118";
            this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
            this.textBox118.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox118.Text = "ZZZ9.99";
            this.textBox118.Top = 0.1875F;
            this.textBox118.Width = 0.45F;
            // 
            // textBox119
            // 
            this.textBox119.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.RightColor = System.Drawing.Color.Black;
            this.textBox119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.TopColor = System.Drawing.Color.Black;
            this.textBox119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.CanShrink = true;
            this.textBox119.Height = 0.16F;
            this.textBox119.Left = 10.375F;
            this.textBox119.MultiLine = false;
            this.textBox119.Name = "textBox119";
            this.textBox119.OutputFormat = resources.GetString("textBox119.OutputFormat");
            this.textBox119.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox119.Text = "ZZZ9.99";
            this.textBox119.Top = 0F;
            this.textBox119.Width = 0.45F;
            // 
            // arTotalSalesCount
            // 
            this.arTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.arTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.arTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.arTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.arTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.arTotalSalesCount.CanShrink = true;
            this.arTotalSalesCount.DataField = "TermSalesTarget1";
            this.arTotalSalesCount.Height = 0.16F;
            this.arTotalSalesCount.Left = 6.5625F;
            this.arTotalSalesCount.MultiLine = false;
            this.arTotalSalesCount.Name = "arTotalSalesCount";
            this.arTotalSalesCount.OutputFormat = resources.GetString("arTotalSalesCount.OutputFormat");
            this.arTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.arTotalSalesCount.SummaryGroup = "arHeader";
            this.arTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.arTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.arTotalSalesCount.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.arTotalSalesCount.Top = 0.1875F;
            this.arTotalSalesCount.Width = 0.9F;
            // 
            // textBox121
            // 
            this.textBox121.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Border.RightColor = System.Drawing.Color.Black;
            this.textBox121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Border.TopColor = System.Drawing.Color.Black;
            this.textBox121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.CanShrink = true;
            this.textBox121.DataField = "TermSalesTargetCount1";
            this.textBox121.Height = 0.16F;
            this.textBox121.Left = 4.41F;
            this.textBox121.MultiLine = false;
            this.textBox121.Name = "textBox121";
            this.textBox121.OutputFormat = resources.GetString("textBox121.OutputFormat");
            this.textBox121.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox121.SummaryGroup = "arHeader";
            this.textBox121.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox121.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox121.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox121.Top = 0.1875F;
            this.textBox121.Width = 0.7F;
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
            this.line9.Height = 0F;
            this.line9.Left = 0F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0F;
            this.line9.Width = 10.85F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.85F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // PMKHN02052P_01A4C
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
            this.PrintWidth = 10.85F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.arHeader);
            this.Sections.Add(this.AreaHeader);
            this.Sections.Add(this.empHeader);
            this.Sections.Add(this.EmployeeHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.BLGroupHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.BLGroupFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.EmployeeFooter);
            this.Sections.Add(this.empFooter);
            this.Sections.Add(this.AreaFooter);
            this.Sections.Add(this.arFooter);
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
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitRatio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitRatio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tt_GroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SecTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grProfitRatio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grProfitRatio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuProfitRatio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuProfitRatio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CusTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGoalsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_EmpTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AreaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion                    
      
	}
}
