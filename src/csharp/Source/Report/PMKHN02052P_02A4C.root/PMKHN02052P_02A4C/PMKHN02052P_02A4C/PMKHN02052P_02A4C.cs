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
using System.Drawing;
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
	/// キャンペーン実績表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: キャンペーン実績表のフォームクラスです。</br>
	/// <br>Programmer	: 田建委</br>
	/// <br>Date		: 2011/05/19</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN02052P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
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
		public PMKHN02052P_02A4C()
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
        private TextBox textBox21;
        private TextBox textBox31;
        private Label label41;
        private TextBox textBox32;
        private TextBox textBox33;
        private Label label42;
        private Label label43;
        private Label label44;
        private TextBox textBox34;
        private Label label45;
        private TextBox textBox35;
        private Label label46;
        private TextBox textBox36;
        private Label label47;
        private Label label48;
        private TextBox textBox37;
        private Label label49;
        private Label label50;
        private TextBox textBox38;
        private Label label51;
        private TextBox textBox39;
        private TextBox textBox40;
        private TextBox textBox41;
        private Label label53;
        private Label label54;
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
        private TextBox textBox58;
        private GroupHeader AreaHeader;
        private GroupFooter AreaFooter;
        private Line line4;
        private Label ArHd_SectionTitle;
        private TextBox ArHd_AddUpSecCode;
        private TextBox ArHd_SectionGuideNm;
        private Label ArHd_AreaTitle;
        private TextBox ArHd_AreaCd;
        private TextBox ArHd_AreaNm;
        private Label ArHd_CustomerTitle;
        private TextBox ArHd_CustomerName;
        private TextBox ArHd_CustomerCode;
        private Label label67;
        private Line line7;
        private Line line9;
        private GroupHeader empHeader;
        private GroupFooter empFooter;
        private Line line6;
        private Label label8;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label20;
        private Label label21;
        private Label label22;
        private TextBox textBox11;
        private Label label23;
        private TextBox textBox12;
        private Label label24;
        private TextBox textBox13;
        private Label label25;
        private Label label26;
        private TextBox textBox14;
        private Label label27;
        private Label label28;
        private TextBox textBox15;
        private Label label29;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private Label label52;
        private GroupHeader arHeader;
        private GroupFooter arFooter;
        private Label label55;
        private Label label56;
        private TextBox textBox59;
        private Label label57;
        private TextBox textBox60;
        private Label label58;
        private TextBox textBox61;
        private Label label59;
        private TextBox textBox62;
        private Label label60;
        private TextBox textBox63;
        private Label label61;
        private TextBox textBox64;
        private Label label62;
        private TextBox textBox65;
        private Label label63;
        private TextBox textBox66;
        private Label label64;
        private TextBox textBox67;
        private Label label65;
        private TextBox textBox68;
        private Label label66;
        private Line line5;
        private Label label40;
        private Line line15;
        private Line line10;
        private Line line12;
        private Label label68;
        private TextBox textBox69;
        private TextBox textBox70;
        private Line line13;
        private Line line14;

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

            // 項目の名称をセット

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;


            //-------------------------------------------------------
            // 月範囲の適用（抽出された範囲内で処理する）
            //-------------------------------------------------------
            #region [月範囲の適用]
            // 作業用にリスト生成
            #region [作業用リスト生成]
            ArrayList[] ctrlList = new ArrayList[12];

            // 月01
            ctrlList[0] = new ArrayList();
            ctrlList[0].AddRange(new object[] { Lb_Month01 });
            ctrlList[0].AddRange(new object[] { mMonth01, cMonth01, pMonth01 });
            ctrlList[0].AddRange(new object[] { gr_mMonth01, gr_cMonth01, gr_pMonth01 });
            ctrlList[0].AddRange(new object[] { cu_mMonth01, cu_cMonth01, cu_pMonth01 });

            // 月02
            ctrlList[1] = new ArrayList();
            ctrlList[1].AddRange(new object[] { Lb_Month02 });
            ctrlList[1].AddRange(new object[] { mMonth02, cMonth02, pMonth02 });
            ctrlList[1].AddRange(new object[] { gr_mMonth02, gr_cMonth02, gr_pMonth02 });
            ctrlList[1].AddRange(new object[] { cu_mMonth02, cu_cMonth02, cu_pMonth02 });


            // 月03
            ctrlList[2] = new ArrayList();
            ctrlList[2].AddRange(new object[] { Lb_Month03 });
            ctrlList[2].AddRange(new object[] { mMonth03, cMonth03, pMonth03 });
            ctrlList[2].AddRange(new object[] { gr_mMonth03, gr_cMonth03, gr_pMonth03 });
            ctrlList[2].AddRange(new object[] { cu_mMonth03, cu_cMonth03, cu_pMonth03 });

            // 月04
            ctrlList[3] = new ArrayList();
            ctrlList[3].AddRange(new object[] { Lb_Month04 });
            ctrlList[3].AddRange(new object[] { mMonth04, cMonth04, pMonth04 });
            ctrlList[3].AddRange(new object[] { gr_mMonth04, gr_cMonth04, gr_pMonth04 });
            ctrlList[3].AddRange(new object[] { cu_mMonth04, cu_cMonth04, cu_pMonth04 });

            // 月05
            ctrlList[4] = new ArrayList();
            ctrlList[4].AddRange(new object[] { Lb_Month05 });
            ctrlList[4].AddRange(new object[] { mMonth05, cMonth05, pMonth05 });
            ctrlList[4].AddRange(new object[] { gr_mMonth05, gr_cMonth05, gr_pMonth05 });
            ctrlList[4].AddRange(new object[] { cu_mMonth05, cu_cMonth05, cu_pMonth05 });

            // 月06
            ctrlList[5] = new ArrayList();
            ctrlList[5].AddRange(new object[] { Lb_Month06 });
            ctrlList[5].AddRange(new object[] { mMonth06, cMonth06, pMonth06 });
            ctrlList[5].AddRange(new object[] { gr_mMonth06, gr_cMonth06, gr_pMonth06 });
            ctrlList[5].AddRange(new object[] { cu_mMonth06, cu_cMonth06, cu_pMonth06 });

            // 月07
            ctrlList[6] = new ArrayList();
            ctrlList[6].AddRange(new object[] { Lb_Month07 });
            ctrlList[6].AddRange(new object[] { mMonth07, cMonth07, pMonth07 });
            ctrlList[6].AddRange(new object[] { gr_mMonth07, gr_cMonth07, gr_pMonth07 });
            ctrlList[6].AddRange(new object[] { cu_mMonth07, cu_cMonth07, cu_pMonth07 });

            // 月08
            ctrlList[7] = new ArrayList();
            ctrlList[7].AddRange(new object[] { Lb_Month08 });
            ctrlList[7].AddRange(new object[] { mMonth08, cMonth08, pMonth08 });
            ctrlList[7].AddRange(new object[] { gr_mMonth08, gr_cMonth08, gr_pMonth08 });
            ctrlList[7].AddRange(new object[] { cu_mMonth08, cu_cMonth08, cu_pMonth08 });

            // 月09
            ctrlList[8] = new ArrayList();
            ctrlList[8].AddRange(new object[] { Lb_Month09 });
            ctrlList[8].AddRange(new object[] { mMonth09, cMonth09, pMonth09 });
            ctrlList[8].AddRange(new object[] { gr_mMonth09, gr_cMonth09, gr_pMonth09 });
            ctrlList[8].AddRange(new object[] { cu_mMonth09, cu_cMonth09, cu_pMonth09 });

            // 月10
            ctrlList[9] = new ArrayList();
            ctrlList[9].AddRange(new object[] { Lb_Month10 });
            ctrlList[9].AddRange(new object[] { mMonth10, cMonth10, pMonth10 });
            ctrlList[9].AddRange(new object[] { gr_mMonth10, gr_cMonth10, gr_pMonth10 });
            ctrlList[9].AddRange(new object[] { cu_mMonth10, cu_cMonth10, cu_pMonth10 });

            // 月11
            ctrlList[10] = new ArrayList();
            ctrlList[10].AddRange(new object[] { Lb_Month11 });
            ctrlList[10].AddRange(new object[] { mMonth11, cMonth11, pMonth11 });
            ctrlList[10].AddRange(new object[] { gr_mMonth11, gr_cMonth11, gr_pMonth11 });
            ctrlList[10].AddRange(new object[] { cu_mMonth11, cu_cMonth11, cu_pMonth11 });

            // 月12
            ctrlList[11] = new ArrayList();
            ctrlList[11].AddRange(new object[] { Lb_Month12 });
            ctrlList[11].AddRange(new object[] { mMonth12, cMonth12, pMonth12 });
            ctrlList[11].AddRange(new object[] { gr_mMonth12, gr_cMonth12, gr_pMonth12 });
            ctrlList[11].AddRange(new object[] { cu_mMonth12, cu_cMonth12, cu_pMonth12 });

            // 月タイトルリスト
            // (※注意：月タイトルラベルはこのリストにも、上記の月毎コントロールリストにも格納されます)
            List<Label> monthTitleList = new List<Label>();
            monthTitleList.AddRange(new Label[] { Lb_Month01, Lb_Month02, Lb_Month03, Lb_Month04, Lb_Month05, Lb_Month06, Lb_Month07, Lb_Month08, Lb_Month09, Lb_Month10, Lb_Month11, Lb_Month12 });

            #endregion

            // 月数の取得
            int monthRange = GetMonthRange(this._campaignRsltList.AddUpYearMonthSt, this._campaignRsltList.AddUpYearMonthEd);


            if ((monthRange > 12) || (monthRange <= 0))
            {
                monthRange = 12;
            }

            // 印字有無を設定
            for (int index = 0; index < ctrlList.Length; index++)
            {
                // 月タイトル設定
                if (index < monthTitleList.Count)
                {
                    monthTitleList[index].Text = GetMonthTitle(this._campaignRsltList.AddUpYearMonthSt, index);
                }

                // 印字有無設定
                foreach (object ctrl in ctrlList[index])
                {
                    if (ctrl is TextBox)
                    {
                        (ctrl as TextBox).Visible = (index < monthRange);   // 範囲内のみtrue
                    }
                    else if (ctrl is Label)
                    {
                        (ctrl as Label).Visible = (index < monthRange);     // 範囲内のみtrue
                    }
                }
            }
            #endregion
                       
            #endregion                       
           
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    {
                        #region 商品別
                        this.SectionHeader.Visible = true;
                        this.arHeader.Visible = false;
                        this.EmployeeHeader.Visible = false;
                        this.empHeader.Visible = false;
                        this.empFooter.Visible = false;

                        this.CustomerHeader.Visible = false;
                        #region [改頁設定]
                        if (this._campaignRsltList.CrModeSec == 0)
                        {
                            this.SectionHeader.NewPage = NewPage.None;
                        }
                        #endregion

                        #region [印字パターン]
                        this.tb_Sort.Text =string.Empty;
                        
                        this.EmployeeHeader.Visible = false;
                        this.EmployeeFooter.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.CustomerFooter.Visible = false;
                        // 明細単位
                        switch (this._campaignRsltList.Detail)
                        {
                            case 0: // 品番
                                {
                                    if (this._campaignRsltList.Total == 0)
                                    {
                                        // 印字パターン５
                                        this.Lb_GroupCode.Text = "ｸﾞﾙｰﾌﾟ";
                                        this.label41.Text = "ｸﾞﾙｰﾌﾟ計";
                                        this.GroupCode.Visible = true;
                                        this.GroupName.Visible = true;
                                        this.BLGoodsCode.Visible = false;
                                        this.BLGoodsName.Visible = false;
                                        // ｸﾞﾙｰﾌﾟ計のDataField
                                        this.BLGroupHeader.DataField = PMKHN02054EA.ct_Col_BLGroupCode;
                                    }
                                    else
                                    {
                                        // 印字パターン６
                                        this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                        this.label41.Text = "BLｺｰﾄﾞ計";
                                        this.GroupCode.Visible = false;
                                        this.GroupName.Visible = false;
                                        this.BLGoodsCode.Visible = true;
                                        this.BLGoodsName.Visible = true;
                                        this.BLGoodsCode.Left = this.GroupCode.Left;
                                        this.BLGoodsName.Left = this.GroupName.Left;
                                        // BLｺｰﾄﾞ計のDataField
                                        this.BLGroupHeader.DataField = PMKHN02054EA.ct_Col_BLGoodsCode;
                                    }
                                    // ｸﾞﾙｰﾌﾟ
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_Goods.Visible = true;
                                    //Detailの品番／品名
                                    this.GoodsNo.Visible = true;
                                    this.GoodsName.Visible = true;
                                    //DetailのｸﾞﾙｰﾌﾟとBLｺｰﾄﾞ
                                    this.tb_GroupCd.Visible = false;
                                    this.tb_GroupNm.Visible = false;
                                    this.tb_BLGoodsCd.Visible = false;
                                    this.tb_BLGoodsNm.Visible = false;
                                    // ｸﾞﾙｰﾌﾟ計
                                    this.BLGroupHeader.Visible = true;
                                    this.BLGroupFooter.Visible = true;
                                    
                                    this.label41.Visible = true;
                                    this.label41.Top = this.label6.Top;
                                    // 売上額
                                    this.label48.Visible = true;
                                    this.textBox32.Visible = true;
                                    this.label48.Top = this.label6.Top;
                                    this.textBox32.Top = this.label6.Top;
                                    // 売上目標
                                    this.label43.Visible = true;
                                    this.textBox33.Visible = true;
                                    this.label43.Top = this.label6.Top;
                                    this.textBox33.Top = this.label6.Top;
                                    // 達成率
                                    this.label44.Visible = true;
                                    this.textBox34.Visible = true;
                                    this.label44.Top = this.label6.Top;
                                    this.textBox34.Top = this.label6.Top;
                                    // 売上数
                                    this.label45.Visible = true;
                                    this.textBox35.Visible = true;
                                    this.label45.Top = this.label6.Top;
                                    this.textBox35.Top = this.label6.Top;
                                    // 数量目標
                                    this.label46.Visible = true;
                                    this.textBox36.Visible = true;
                                    this.label46.Top = this.label6.Top;
                                    this.textBox36.Top = this.label6.Top;
                                    // 達成率
                                    this.label47.Visible = true;
                                    this.textBox39.Visible = true;
                                    this.label47.Top = this.label6.Top;
                                    this.textBox39.Top = this.label6.Top;
                                    // 粗利額
                                    this.label42.Visible = true;
                                    this.textBox37.Visible = true;
                                    this.label42.Top = this.label6.Top;
                                    this.textBox37.Top = this.label6.Top;
                                    // 粗利率
                                    this.label49.Visible = true;
                                    this.textBox40.Visible = true;
                                    this.label49.Top = this.label6.Top;
                                    this.textBox40.Top = this.label6.Top;
                                    // 粗利目標
                                    this.label50.Visible = true;
                                    this.textBox38.Visible = true;
                                    this.label50.Top = this.label6.Top;
                                    this.textBox38.Top = this.label6.Top;
                                    // 達成率
                                    this.label51.Visible = true;
                                    this.textBox41.Visible = true;
                                    this.label51.Top = this.label6.Top;
                                    this.textBox41.Top = this.label6.Top;
                                    this.label67.Visible = true;
                                    this.label67.Top = this.label6.Top;

                                    this.label6.Visible = false;
                                    foreach (ARControl aRControl in this.BLGroupFooter.Controls) 
                                    {
                                        if (aRControl is TextBox) 
                                        {
                                            TextBox textBox = (TextBox)aRControl;
                                            if (textBox.Name.StartsWith("gr_mMonth") || textBox.Name.StartsWith("gr_cMonth") || textBox.Name.StartsWith("gr_pMonth")) 
                                            {
                                                textBox.Visible = false;
                                            }
                                        }
                                    }

                                }
                                break;
                            case 1: // BLｺｰﾄ
                                {
                                    // 印字パターン８
                                    // Title
                                    this.Lb_Goods.Visible = false;
                                    this.Lb_BLGroupCode.Visible = true;
                                    this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                    this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";

                                    //Detailの品番／品名
                                    this.GoodsNo.Visible = false;
                                    this.GoodsName.Visible = false;
                                    //DetailのｸﾞﾙｰﾌﾟとBLｺｰﾄﾞ
                                    this.tb_GroupCd.Visible = false;
                                    this.tb_GroupNm.Visible = false;
                                    this.tb_BLGoodsCd.Visible = true;
                                    this.tb_BLGoodsNm.Visible = true;
                                    this.tb_BLGoodsCd.Top = this.GoodsNo.Top;
                                    this.tb_BLGoodsNm.Top = this.GoodsNo.Top;

                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line10.Visible = true;
                                    
                                }
                                break;
                            case 2: // ｸﾞﾙｰﾌﾟ
                                {
                                    // 印字パターン７
                                    // Title
                                    this.Lb_Goods.Visible = false;
                                    this.Lb_BLGroupCode.Visible = true;
                                    this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                    //Detailの品番／品名
                                    this.GoodsNo.Visible = false;
                                    this.GoodsName.Visible = false;
                                    //DetailのｸﾞﾙｰﾌﾟとBLｺｰﾄﾞ
                                    this.tb_GroupCd.Visible = true;
                                    this.tb_GroupNm.Visible = true;
                                    this.tb_BLGoodsCd.Visible = false;
                                    this.tb_BLGoodsNm.Visible = false;
                                    this.tb_GroupCd.Top = this.GoodsNo.Top;
                                    this.tb_GroupNm.Top = this.GoodsNo.Top;

                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line10.Visible = true;
                                }
                                break;
                        }
                        #endregion

                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                    {
                        #region 得意先別

                        this.empHeader.DataField = "CustomerCode";
                        this.arHeader.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.CustomerFooter.Visible = false;
                        this.EmployeeHeader.DataField = "HeaderKey1";
                        this.textBox10.DataField = "TermSalesTarget3";
                        this.textBox13.DataField = "TermSalesTargetCount3";
                        this.textBox15.DataField = "TermSalesTargetProfit3";

                        this.SectionHeader.Visible = true;
                        this.label40.Visible = false;
                        this.textBox21.Visible = false;
                        this.textBox31.Visible = false;
                        this.SupHd_EmployeeTitle.Visible = false;
                        this.SupHd_EmployeeCd.Visible = false;
                        this.SupHd_EmployeeNm.Visible = false;
                        this.SupHd_CustomerTitle.Visible = true;
                        this.SupHd_CustomerCode.Visible = true;
                        this.SupHd_CustomerName.Visible = true;

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

                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 得意先、管理拠点
                            case 3:
                                {
                                    this.SupHd_CustomerTitle.Left = 2F;
                                    this.SupHd_CustomerCode.Left = 2.5F;
                                    this.SupHd_CustomerName.Left = 3.062F;

                                    this.label8.Text = "得意先計";

                                    if (this._campaignRsltList.OutputSort == 0)
                                    {
                                        this.tb_Sort.Text = "[得意先順]";
                                    }
                                    else if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }
                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１３
                                                }
                                                else
                                                {
                                                    // 印字パターン１４
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン１６
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１５
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 1: // 拠点
                                {
                                    this.SupHd_CustomerTitle.Visible = false;
                                    this.SupHd_CustomerCode.Visible = false;
                                    this.SupHd_CustomerName.Visible = false;

                                    this.empFooter.Visible = false;
                                    this.label8.Text = "得意先計";

                                    this.tb_Sort.Text = "[拠点順]";
                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン１７
                                                }
                                                else
                                                {
                                                    // 印字パターン１８
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label41.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２０
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label41.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１９
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }

                                    this.label41.Visible = true;
                                    this.label41.Top = this.label6.Top;
                                    // 売上額
                                    this.label48.Visible = true;
                                    this.textBox32.Visible = true;
                                    this.label48.Top = this.label6.Top;
                                    this.textBox32.Top = this.label6.Top;
                                    // 売上目標
                                    this.label43.Visible = true;
                                    this.textBox33.Visible = true;
                                    this.label43.Top = this.label6.Top;
                                    this.textBox33.Top = this.label6.Top;
                                    // 達成率
                                    this.label44.Visible = true;
                                    this.textBox34.Visible = true;
                                    this.label44.Top = this.label6.Top;
                                    this.textBox34.Top = this.label6.Top;
                                    // 売上数
                                    this.label45.Visible = true;
                                    this.textBox35.Visible = true;
                                    this.label45.Top = this.label6.Top;
                                    this.textBox35.Top = this.label6.Top;
                                    // 数量目標
                                    this.label46.Visible = true;
                                    this.textBox36.Visible = true;
                                    this.label46.Top = this.label6.Top;
                                    this.textBox36.Top = this.label6.Top;
                                    // 達成率
                                    this.label47.Visible = true;
                                    this.textBox39.Visible = true;
                                    this.label47.Top = this.label6.Top;
                                    this.textBox39.Top = this.label6.Top;
                                    // 粗利額
                                    this.label42.Visible = true;
                                    this.textBox37.Visible = true;
                                    this.label42.Top = this.label6.Top;
                                    this.textBox37.Top = this.label6.Top;
                                    // 粗利率
                                    this.label49.Visible = true;
                                    this.textBox40.Visible = true;
                                    this.label49.Top = this.label6.Top;
                                    this.textBox40.Top = this.label6.Top;
                                    // 粗利目標
                                    this.label50.Visible = true;
                                    this.textBox38.Visible = true;
                                    this.label50.Top = this.label6.Top;
                                    this.textBox38.Top = this.label6.Top;
                                    // 達成率
                                    this.label51.Visible = true;
                                    this.textBox41.Visible = true;
                                    this.label51.Top = this.label6.Top;
                                    this.textBox41.Top = this.label6.Top;
                                    this.label67.Visible = true;
                                    this.label67.Top = this.label6.Top;

                                    this.label6.Visible = false;
                                    foreach (ARControl aRControl in this.BLGroupFooter.Controls)
                                    {
                                        if (aRControl is TextBox)
                                        {
                                            TextBox textBox = (TextBox)aRControl;
                                            if (textBox.Name.StartsWith("gr_mMonth") || textBox.Name.StartsWith("gr_cMonth") || textBox.Name.StartsWith("gr_pMonth"))
                                            {
                                                textBox.Visible = false;
                                            }
                                        }
                                    }

                                }
                                break;
                            case 2: // 得意先－拠点
                                {
                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "CustomerCode";

                                    // empFooter
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox10.DataField = "TermSalesTarget2";
                                    this.textBox15.DataField = "TermSalesTargetProfit2";

                                    this.SupHd_CustomerTitle.Left = 0F;
                                    this.SupHd_CustomerCode.Left = 0.5F;
                                    this.SupHd_CustomerName.Left = 1.062F;

                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.875F;
                                    this.SupHd_SectionGuideNm.Left = 3.125F;

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

                                    this.tb_Sort.Text = "[得意先－拠点順]";
                                    switch (this._campaignRsltList.Detail)
                                    {
                                        case 0: // 品番
                                            {
                                                if (this._campaignRsltList.Total == 0)
                                                {
                                                    // 印字パターン２１
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "得意先計";
                                                }
                                                else
                                                {
                                                    // 印字パターン２２
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "得意先計";
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２４
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "得意先計";
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.BLGroupHeader.DataField = "BLGoodsCode";
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン２３
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "得意先計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                        }

                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachEmployee:// 担当者別
                    {
                        #region 担当者別

                        this.SectionHeader.Visible = true;
                        this.label40.Visible = false;
                        this.textBox21.Visible = false;
                        this.textBox31.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.arHeader.Visible = false;                        
                        
                        switch (this._campaignRsltList.OutputSort)
                        {
            	            case 0: // 担当者、管理拠点
                            case 3:
                                {
                                    if (this._campaignRsltList.OutputSort == 0)
                                    {
                                        this.tb_Sort.Text = "[担当者順]";
                                    } else if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region [改頁設定]
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
                                                    // 印字パターン１３
                                                }
                                                else
                                                {
                                                    // 印字パターン１４
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン１６
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１５
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 1: // 得意先
                                {
                    	            this.tb_Sort.Text = "[得意先順]";
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 得意先
                                    this.label68.Visible = true;
                                    this.textBox69.Visible = true;
                                    this.textBox70.Visible = true;

                                    #region [改頁設定]
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
                                                    // 印字パターン１７
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン１８
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２０
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１９
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 2: // 担当者－拠点
                                {
                                    this.tb_Sort.Text = "[担当者－拠点順]";
                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "EmployeeCode";

									// empFooter
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox10.DataField = "TermSalesTarget2";
                                    this.textBox15.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox3.DataField = "TermSalesTargetCount2";
                                    this.textBox1.DataField = "TermSalesTarget2";
                                    this.textBox7.DataField = "TermSalesTargetProfit2";
                                    
                                    this.SupHd_EmployeeTitle.Left = 0F;
                                    this.SupHd_EmployeeCd.Left = 0.438F;
                                    this.SupHd_EmployeeNm.Left = 0.75F;
                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.813F;
                                    this.SupHd_SectionGuideNm.Left = 3F;

                                    #region [改頁設定]
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
                                                    // 印字パターン２１
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "担当者計";
                                                }
                                                else
                                                {
                                                    // 印字パターン２２
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "担当者計";
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                this.BLGroupFooter.Visible = false;
                                                // 印字パターン２４
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "担当者計";
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                this.BLGroupFooter.Visible = false;
                                                // 印字パターン２３
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "担当者計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                        }
                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachAcceptOdr:// 受注者別
                    {
                        #region 受注者別
                        this.SectionHeader.Visible = true;
                        this.label40.Visible = false;
                        this.textBox21.Visible = false;
                        this.textBox31.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.arHeader.Visible = false;                        
                        
                        this.SupHd_EmployeeTitle.Text = "受注者";
                        this.label8.Text = "受注者計";

                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 受注者、管理拠点
                            case 3:
                                {
                                    if (this._campaignRsltList.OutputSort == 0)
                                    {
                                        this.tb_Sort.Text = "[受注者順]";
                                    }
                                    else if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region [改頁設定]
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
                                                    // 印字パターン１３
                                                }
                                                else
                                                {
                                                    // 印字パターン１４
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン１６
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１５
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 1: // 得意先
                                {
                                    this.tb_Sort.Text = "[得意先順]";
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 得意先
                                    this.label68.Visible = true;
                                    this.textBox69.Visible = true;
                                    this.textBox70.Visible = true;

                                    #region [改頁設定]
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
                                                    // 印字パターン１７
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン１８
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２０
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１９
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 2: // 受注者－拠点
                                {
                                    this.tb_Sort.Text = "[受注者－拠点順]";

                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "EmployeeCode";

                                    // empFooter
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox10.DataField = "TermSalesTarget2";
                                    this.textBox15.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox3.DataField = "TermSalesTargetCount2";
                                    this.textBox1.DataField = "TermSalesTarget2";
                                    this.textBox7.DataField = "TermSalesTargetProfit2";

                                    this.SupHd_EmployeeTitle.Left = 0F;
                                    this.SupHd_EmployeeCd.Left = 0.438F;
                                    this.SupHd_EmployeeNm.Left = 0.75F;
                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.813F;
                                    this.SupHd_SectionGuideNm.Left = 3F;

                                    #region [改頁設定]
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
                                                    // 印字パターン２１
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "受注者計";
                                                }
                                                else
                                                {
                                                    // 印字パターン２２
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "受注者計";
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２４
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "受注者計";
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン２３
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "受注者計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                        }
                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                    {
                        #region [販売区分別]

                        this.SectionHeader.Visible = true;
                        this.label40.Visible = false;
                        this.textBox21.Visible = false;
                        this.textBox31.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.arHeader.Visible = false;

                        #region [改頁設定]
                        this.empHeader.NewPage = NewPage.None;
                        this.arHeader.Visible = false;
                        if (this._campaignRsltList.CrModeSec == 0)
                        {
                            this.SectionHeader.NewPage = NewPage.None;
                        }
                        else
                        {
                            this.SectionHeader.NewPage = NewPage.Before;
                        }
                        #endregion

                        this.tb_Sort.Text = string.Empty;

                        this.SupHd_EmployeeTitle.Width = 0.48F;
                        this.SupHd_EmployeeTitle.Left = 1.9F;
                        this.SupHd_EmployeeTitle.Text = "販売区分";
                        this.label8.Text = "販売区分計";

                        switch (this._campaignRsltList.Detail)
                        {
                            case 0: // 品番
                                {
                                    if (this._campaignRsltList.Total == 0)
                                    {
                                        // 印字パターン１３
                                    }
                                    else
                                    {
                                        // 印字パターン１４
                                        this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                        this.label6.Text = "BLｺｰﾄﾞ計";
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
                                    // 印字パターン１６
                                    this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                    this.label6.Text = "BLｺｰﾄﾞ計";
                                    this.Lb_Goods.Visible = false;
                                    this.Lb_BLGroupCode.Visible = true;
                                    this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                    this.GoodsNo.Visible = false;
                                    this.GoodsName.Visible = false;
                                    this.tb_BLGoodsCd.Visible = true;
                                    this.tb_BLGoodsNm.Visible = true;
                                    this.tb_BLGoodsCd.Top = 0F;
                                    this.tb_BLGoodsNm.Top = 0F;
                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line15.Visible = true;
                                    break;
                                }
                            case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                {
                                    // 印字パターン１５
                                    this.Lb_Goods.Visible = false;
                                    this.Lb_BLGroupCode.Visible = true;
                                    this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                    this.GoodsNo.Visible = false;
                                    this.GoodsName.Visible = false;
                                    this.tb_GroupCd.Visible = true;
                                    this.tb_GroupNm.Visible = true;
                                    this.tb_GroupCd.Top = 0F;
                                    this.tb_GroupNm.Top = 0F;
                                    this.BLGroupHeader.Visible = false;
                                    this.BLGroupFooter.Visible = false;
                                    this.line15.Visible = true;
                                    break;
                                }
                        }
                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachArea:// 地区別
                    {
                        #region 地区別

                        this.SectionHeader.Visible = true;
                        this.label40.Visible = false;
                        this.textBox21.Visible = false;
                        this.textBox31.Visible = false;
                        this.AreaHeader.Visible = true;
                        this.arFooter.Visible = true;
                        // 得意先計
                        this.CustomerHeader.Visible = false;
                        this.CustomerFooter.Visible = false;

                        this.EmployeeHeader.Visible = false;
                        this.empHeader.Visible = false;
                        this.empFooter.Visible = false;                        
                        
                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 地区、管理拠点
                            case 3:
                                {
                                    if (this._campaignRsltList.OutputSort == 0)
                                    {
                                        this.tb_Sort.Text = "[地区順]";
                                    }
                                    else if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.ArHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.ArHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region [改頁設定]
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
                                                    // 印字パターン１３
                                                }
                                                else
                                                {
                                                    // 印字パターン１４
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン１６
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line12.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１５
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line12.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 1: // 得意先
                                {
                                    this.tb_Sort.Text = "[得意先順]";
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 得意先
                                    this.label68.Visible = true;
                                    this.textBox69.Visible = true;
                                    this.textBox70.Visible = true;

                                    #region [改頁設定]
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
                                                    // 印字パターン１７
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン１８
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２０
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１９
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 2: // 地区－拠点
                                {
                                    this.tb_Sort.Text = "[地区－拠点順]";
                                    this.arHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "AreaCode";
                                    // arFooter
                                    this.textBox63.DataField = "TermSalesTargetCount2";
                                    this.textBox60.DataField = "TermSalesTarget2";
                                    this.textBox67.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox3.DataField = "TermSalesTargetCount2";
                                    this.textBox1.DataField = "TermSalesTarget2";
                                    this.textBox7.DataField = "TermSalesTargetProfit2";

                                    this.ArHd_AreaTitle.Left = 0F;
                                    this.ArHd_AreaTitle.Alignment = TextAlignment.Left;
                                    this.ArHd_AreaCd.Left = 0.33F;
                                    this.ArHd_AreaNm.Left = 0.643F;
                                    this.ArHd_SectionTitle.Left = 2.5F;
                                    this.ArHd_AddUpSecCode.Left = 2.875F;
                                    this.ArHd_SectionGuideNm.Left = 3.125F;

                                    #region [改頁設定]
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
                                                    // 印字パターン２１
                                                    this.label55.Text = "拠点計";
                                                    this.label9.Text = "地区計";
                                                }
                                                else
                                                {
                                                    // 印字パターン２２
                                                    this.label55.Text = "拠点計";
                                                    this.label9.Text = "地区計";
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２４
                                                this.label55.Text = "拠点計";
                                                this.label9.Text = "地区計";
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line12.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン２３
                                                this.label55.Text = "拠点計";
                                                this.label9.Text = "地区計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line12.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                        }
                        #endregion
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                    {
                        #region 発行者別

                        this.SectionHeader.Visible = true;
                        this.label40.Visible = false;
                        this.textBox21.Visible = false;
                        this.textBox31.Visible = false;
                        this.CustomerHeader.Visible = false;
                        this.arHeader.Visible = false;                        
                        
                        this.tb_Sort.Text = string.Empty;
                        this.SupHd_EmployeeTitle.Text = "発行者";
                        this.label8.Text = "発行者計";
                        switch (this._campaignRsltList.OutputSort)
                        {
                            case 0: // 発行者、管理拠点
                            case 3:
                                {
                                    if (this._campaignRsltList.OutputSort == 0)
                                    {
                                        this.tb_Sort.Text = "[発行者順]";
                                    }
                                    else if (this._campaignRsltList.OutputSort == 3)
                                    {
                                        this.SupHd_AddUpSecCode.DataField = "ManageSectionCode";
                                        this.SupHd_SectionGuideNm.DataField = "ManageSectionNm";
                                        this.SectionHeader.DataField = "ManageSectionCode";
                                        this.tb_Sort.Text = "[管理拠点順]";
                                    }

                                    #region [改頁設定]
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
                                                    // 印字パターン１３
                                                }
                                                else
                                                {
                                                    // 印字パターン１４
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン１６
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１５
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 1: // 得意先
                                {
                                    this.tb_Sort.Text = "[得意先順]";
                                    this.CustomerHeader.Visible = true;
                                    this.CustomerHeader.DataField = "CustomerCode";
                                    this.CustomerHeader.NewPage = NewPage.None;
                                    // 得意先
                                    this.label68.Visible = true;
                                    this.textBox69.Visible = true;
                                    this.textBox70.Visible = true;

                                    #region [改頁設定]
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
                                                    // 印字パターン１７
                                                    this.CustomerFooter.Visible = true;
                                                }
                                                else
                                                {
                                                    // 印字パターン１８
                                                    this.CustomerFooter.Visible = true;
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２０
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン１９
                                                this.CustomerFooter.Visible = true;
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line14.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                            case 2: // 発行者－拠点
                                {
                                    this.tb_Sort.Text = "[発行者－拠点順]";

                                    this.empHeader.DataField = "AddUpSecCode";
                                    this.SectionHeader.DataField = "EmployeeCode";

                                    // empFooter
                                    this.textBox13.DataField = "TermSalesTargetCount2";
                                    this.textBox10.DataField = "TermSalesTarget2";
                                    this.textBox15.DataField = "TermSalesTargetProfit2";
                                    // SectionFooter
                                    this.textBox3.DataField = "TermSalesTargetCount2";
                                    this.textBox1.DataField = "TermSalesTarget2";
                                    this.textBox7.DataField = "TermSalesTargetProfit2";

                                    this.SupHd_EmployeeTitle.Left = 0F;
                                    this.SupHd_EmployeeCd.Left = 0.438F;
                                    this.SupHd_EmployeeNm.Left = 0.75F;
                                    this.SupHd_SectionTitle.Left = 2.5F;
                                    this.SupHd_AddUpSecCode.Left = 2.813F;
                                    this.SupHd_SectionGuideNm.Left = 3F;

                                    #region [改頁設定]
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
                                                    // 印字パターン２１
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "発行者計";
                                                }
                                                else
                                                {
                                                    // 印字パターン２２
                                                    this.label8.Text = "拠点計";
                                                    this.label9.Text = "発行者計";
                                                    this.Lb_GroupCode.Text = "BLｺｰﾄﾞ";
                                                    this.label6.Text = "BLｺｰﾄﾞ計";
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
                                                // 印字パターン２４
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "発行者計";
                                                this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
                                                this.label6.Text = "BLｺｰﾄﾞ計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_BLGoodsCd.Visible = true;
                                                this.tb_BLGoodsNm.Visible = true;
                                                this.tb_BLGoodsCd.Top = 0F;
                                                this.tb_BLGoodsNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                        case 2: // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                            {
                                                // 印字パターン２３
                                                this.label8.Text = "拠点計";
                                                this.label9.Text = "発行者計";
                                                this.Lb_Goods.Visible = false;
                                                this.Lb_BLGroupCode.Visible = true;
                                                this.Lb_BLGroupCode.Left = this.Lb_Goods.Left;
                                                this.GoodsNo.Visible = false;
                                                this.GoodsName.Visible = false;
                                                this.tb_GroupCd.Visible = true;
                                                this.tb_GroupNm.Visible = true;
                                                this.tb_GroupCd.Top = 0F;
                                                this.tb_GroupNm.Top = 0F;
                                                this.BLGroupHeader.Visible = false;
                                                this.BLGroupFooter.Visible = false;
                                                this.line15.Visible = true;
                                                break;
                                            }
                                    }
                                }
                                break;
                        }
                        #endregion
                    }
                    break;
                default:
                    break;
            }
        }


		/// <summary>
		/// 範囲月数の取得処理
		/// </summary>
        /// <returns>範囲月数（ex.４月～６月ならば３）</returns>
        /// <remarks>
        /// <br>Note		: 範囲月数の取得処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		private int GetMonthRange(DateTime stYearMonth, DateTime edYearMonth)
		{
			int stMonth = stYearMonth.Month;
			int edMonth = edYearMonth.Month;

			if (edYearMonth.Year > stYearMonth.Year)
			{
				edMonth += 12;
			}

			return (edMonth - stMonth + 1);
		}
		/// <summary>
		/// 月タイトル取得
		/// </summary>
		/// <param name="stYearMonth"></param>
		/// <param name="index"></param>
        /// <returns>月タイトル(ex.１月,２月…)</returns>
        /// <remarks>
        /// <br>Note		: 月タイトル取得処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		private string GetMonthTitle(DateTime stYearMonth, int index)
		{
			int month = stYearMonth.Month + index;

			if (month > 12) month -= 12;

			return (month.ToString() + "月");
		}

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        /// <remarks>
        /// <br>Note		: 率取得処理を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
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

		#endregion ◆ レポート要素出力設定

		#region ■ Control Event

		#region ◎ MAZAI02032P_02A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_02A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 田建委</br>
		/// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private void MAZAI02032P_02A4C_ReportStart(object sender, System.EventArgs eArgs)
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
            this.Detail.Height = 0.49f;
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

        #region ◎ BLGroupFooter_Format Event
        /// <summary>
        /// BLGroupFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: BLGroupFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void BLGroupFooter_Format(object sender, EventArgs e)
        {
            switch (this._campaignRsltList.TotalType) 
            {
                case CampaignRsltList.TotalTypeState.EachGoods://商品別
                    {
                        // 明細単位「品番」
                        if (this._campaignRsltList.Detail == 0) 
                        {
                            this.BLGroupFooter.Height = 0.188f;
                        }
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachEmployee://担当者別
                    {
                        this.BLGroupFooter.Height = 0.535f;
                    }
                    break;
                default:
                    {
                        this.BLGroupFooter.Height = 0.535f;
                    }
                    break;
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
		#endregion

        /// <summary>
        /// BLGroupFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: BLGroupFooterグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void BLGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // 売上達成率
            this.textBox34.Value = this.GetRatio(this.textBox32.Value, this.textBox33.Value);
            
            // 数量達成率
            this.textBox39.Value = this.GetRatio(this.textBox35.Value, this.textBox36.Value);
            
            // 粗利率
            this.textBox40.Value = this.GetRatio(this.textBox37.Value, this.textBox32.Value);
            // 粗利達成率
            this.textBox41.Value = this.GetRatio(this.textBox37.Value, this.textBox38.Value);           
        }

        /// <summary>
        /// empFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: empFooter_BeforePrintグループのBeforePrintイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void empFooter_BeforePrint(object sender, EventArgs e)
        {
            // 売上達成率
            this.textBox11.Value = this.GetRatio(this.textBox9.Value, this.textBox10.Value);
            
            // 数量達成率
            this.textBox16.Value = this.GetRatio(this.textBox12.Value, this.textBox13.Value);
            
            // 粗利率
            this.textBox17.Value = this.GetRatio(this.textBox14.Value, this.textBox9.Value);
            // 粗利達成率
            this.textBox18.Value = this.GetRatio(this.textBox14.Value, this.textBox15.Value);            
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
            // 売上達成率
            this.suCmpPureSalesRatio.Value = this.GetRatio(this.textBox29.Value, this.textBox1.Value);
            
            // 数量達成率
            this.textBox4.Value = this.GetRatio(this.textBox2.Value, this.textBox3.Value);
            
            // 粗利率
            this.textBox6.Value = this.GetRatio(this.textBox5.Value, this.textBox29.Value);
            // 粗利達成率
            this.textBox8.Value = this.GetRatio(this.textBox5.Value, this.textBox7.Value);            
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
            // 売上達成率
            this.textBox22.Value = this.GetRatio(this.textBox19.Value, this.textBox20.Value);
            
            // 数量達成率
            this.textBox27.Value = this.GetRatio(this.textBox23.Value, this.textBox24.Value);
            
            // 粗利率
            this.textBox28.Value = this.GetRatio(this.textBox25.Value, this.textBox19.Value);
            // 粗利達成率
            this.textBox30.Value = this.GetRatio(this.textBox25.Value, this.textBox26.Value);            
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
            // 売上達成率
            this.textBox61.Value = this.GetRatio(this.textBox59.Value, this.textBox60.Value);
            
            // 数量達成率
            this.textBox64.Value = this.GetRatio(this.textBox62.Value, this.textBox63.Value);
            
            // 粗利率
            this.textBox66.Value = this.GetRatio(this.textBox65.Value, this.textBox59.Value);
            // 粗利達成率
            this.textBox68.Value = this.GetRatio(this.textBox65.Value, this.textBox67.Value);
            
        }
		#endregion ■ Control Event

		#region ActiveReports Designer generated code

		private PageHeader PageHeader;
		private Label Label3;
		private TextBox tb_PrintDate;
		private Label Label2;
		private TextBox tb_PrintPage;
		private Line Line1;
		private TextBox tb_PrintTime;
        private Label tb_ReportTitle;
		private GroupHeader ExtraHeader;
		private SubReport Header_SubReport;
		private GroupHeader TitleHeader;
		private Line Line42;
		private Label Lb_Month11;
		private Label Lb_Month04;
		private Label Lb_Month02;
		private Label Lb_Month03;
		private GroupHeader GrandTotalHeader;
        private GroupHeader SectionHeader;
        private Detail Detail;
		private GroupFooter SectionFooter;
        private Line Line45;
		private GroupFooter GrandTotalFooter;
		private Label GrandTotalTitle;
        private Line Line43;
        private GroupFooter TitleFooter;
		private GroupFooter ExtraFooter;
        private PageFooter PageFooter;
        private Label Lb_Month01;
        private Label Lb_Month07;
        private Label Lb_Month09;
        private Label Lb_Month10;
        private Label Lb_Month12;
        private Label Lb_Goods;
        private Label Lb_Month05;
        private Label Lb_Month06;
        private Label Lb_Month08;
        private GroupHeader EmployeeHeader;
        private GroupFooter EmployeeFooter;
        private GroupHeader BLGroupHeader;
        private GroupFooter BLGroupFooter;
        private Line line8;
        private SubReport Footer_SubReport;
        private Line Line_DetailHead;
        private Line line11;
        private Label Lb_BLGroupCode;
        private TextBox textBox29;
        private Line line2;
        private TextBox tb_Sort;
        private Label label4;
        private TextBox CampaignCode;
        private TextBox CampaignName;
        private Label label5;
        private TextBox ApplyDate;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private Label label1;
        private Label SupHd_SectionTitle;
        private TextBox SupHd_AddUpSecCode;
        private TextBox SupHd_SectionGuideNm;
        private Label SupHd_EmployeeTitle;
        private TextBox SupHd_EmployeeCd;
        private TextBox SupHd_EmployeeNm;
        private Label SupHd_CustomerTitle;
        private TextBox SupHd_CustomerName;
        private TextBox SupHd_CustomerCode;
        private TextBox mMonth01;
        private TextBox mMonth04;
        private TextBox mMonth03;
        private TextBox mMonth02;
        private TextBox mMonth07;
        private TextBox mMonth06;
        private TextBox mMonth05;
        private TextBox mMonth10;
        private TextBox mMonth09;
        private TextBox mMonth08;
        private TextBox mMonth12;
        private TextBox mMonth11;
        private Label Lb_GroupCode;
        private TextBox GroupCode;
        private TextBox GroupName;
        private TextBox BLGoodsCode;
        private TextBox BLGoodsName;
        private TextBox cMonth01;
        private TextBox cMonth02;
        private TextBox cMonth03;
        private TextBox cMonth04;
        private TextBox cMonth05;
        private TextBox cMonth06;
        private TextBox cMonth07;
        private TextBox cMonth08;
        private TextBox cMonth09;
        private TextBox cMonth10;
        private TextBox cMonth11;
        private TextBox cMonth12;
        private TextBox pMonth01;
        private TextBox pMonth02;
        private TextBox pMonth03;
        private TextBox pMonth04;
        private TextBox pMonth05;
        private TextBox pMonth06;
        private TextBox pMonth07;
        private TextBox pMonth08;
        private TextBox pMonth09;
        private TextBox pMonth10;
        private TextBox pMonth11;
        private TextBox pMonth12;
        private TextBox gr_mMonth01;
        private TextBox gr_mMonth04;
        private TextBox gr_mMonth03;
        private TextBox gr_mMonth02;
        private TextBox gr_mMonth07;
        private TextBox gr_mMonth06;
        private TextBox gr_mMonth05;
        private TextBox gr_mMonth10;
        private TextBox gr_mMonth09;
        private TextBox gr_mMonth08;
        private TextBox gr_mMonth12;
        private TextBox gr_mMonth11;
        private GroupHeader CustomerHeader;
        private GroupFooter CustomerFooter;
        private Label label9;
        private TextBox gr_cMonth05;
        private TextBox gr_cMonth06;
        private TextBox gr_cMonth07;
        private TextBox gr_cMonth08;
        private TextBox gr_cMonth09;
        private TextBox gr_cMonth10;
        private TextBox gr_cMonth11;
        private TextBox gr_cMonth12;
        private TextBox gr_cMonth01;
        private TextBox gr_cMonth02;
        private TextBox gr_cMonth03;
        private TextBox gr_cMonth04;
        private TextBox gr_pMonth01;
        private TextBox gr_pMonth02;
        private TextBox gr_pMonth03;
        private TextBox gr_pMonth04;
        private TextBox gr_pMonth05;
        private TextBox gr_pMonth06;
        private TextBox gr_pMonth07;
        private TextBox gr_pMonth08;
        private TextBox gr_pMonth09;
        private TextBox gr_pMonth10;
        private TextBox gr_pMonth11;
        private TextBox gr_pMonth12;
        private Label label6;
        private Line line3;
        private TextBox cu_mMonth01;
        private TextBox cu_mMonth04;
        private TextBox cu_mMonth03;
        private TextBox cu_mMonth02;
        private TextBox cu_mMonth07;
        private TextBox cu_mMonth06;
        private TextBox cu_mMonth05;
        private TextBox cu_mMonth10;
        private TextBox cu_mMonth09;
        private TextBox cu_mMonth08;
        private TextBox cu_mMonth12;
        private TextBox cu_mMonth11;
        private TextBox cu_cMonth05;
        private TextBox cu_cMonth06;
        private TextBox cu_cMonth07;
        private TextBox cu_cMonth08;
        private TextBox cu_cMonth09;
        private TextBox cu_cMonth10;
        private TextBox cu_cMonth11;
        private TextBox cu_cMonth12;
        private TextBox cu_cMonth01;
        private TextBox cu_cMonth02;
        private TextBox cu_cMonth03;
        private TextBox cu_cMonth04;
        private TextBox cu_pMonth01;
        private TextBox cu_pMonth02;
        private TextBox cu_pMonth03;
        private TextBox cu_pMonth04;
        private TextBox cu_pMonth05;
        private TextBox cu_pMonth06;
        private TextBox cu_pMonth07;
        private TextBox cu_pMonth08;
        private TextBox cu_pMonth09;
        private TextBox cu_pMonth10;
        private TextBox cu_pMonth11;
        private TextBox cu_pMonth12;
        private Label label7;
        private TextBox textBox1;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox suCmpPureSalesRatio;
        private Label label13;
        private TextBox textBox2;
        private Label label14;
        private TextBox textBox3;
        private Label label15;
        private Label label16;
        private TextBox textBox5;
        private Label label17;
        private Label label18;
        private TextBox textBox7;
        private Label label19;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox8;
        private TextBox textBox19;
        private TextBox textBox20;
        private Label label30;
        private Label label31;
        private Label label32;
        private TextBox textBox22;
        private Label label33;
        private TextBox textBox23;
        private Label label34;
        private TextBox textBox24;
        private Label label35;
        private Label label36;
        private TextBox textBox25;
        private Label label37;
        private Label label38;
        private TextBox textBox26;
        private Label label39;
        private TextBox textBox27;
        private TextBox textBox28;
        private TextBox textBox30;
        private TextBox tb_GroupCd;
        private TextBox tb_GroupNm;
        private TextBox tb_BLGoodsNm;
        private TextBox tb_BLGoodsCd;

        /// <summary>
        /// InitializeComponent
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN02052P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line_DetailHead = new DataDynamics.ActiveReports.Line();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.mMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.mMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.pMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.tb_GroupCd = new DataDynamics.ActiveReports.TextBox();
            this.tb_GroupNm = new DataDynamics.ActiveReports.TextBox();
            this.tb_BLGoodsNm = new DataDynamics.ActiveReports.TextBox();
            this.tb_BLGoodsCd = new DataDynamics.ActiveReports.TextBox();
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
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
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
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_Month11 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month04 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month02 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month03 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month01 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month07 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month09 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month10 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month12 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month05 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month06 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month08 = new DataDynamics.ActiveReports.Label();
            this.Lb_Goods = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGroupCode = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.CampaignCode = new DataDynamics.ActiveReports.TextBox();
            this.CampaignName = new DataDynamics.ActiveReports.TextBox();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.ApplyDate = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.label33 = new DataDynamics.ActiveReports.Label();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.label37 = new DataDynamics.ActiveReports.Label();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.label39 = new DataDynamics.ActiveReports.Label();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.label53 = new DataDynamics.ActiveReports.Label();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.suCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.label54 = new DataDynamics.ActiveReports.Label();
            this.EmployeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.SupHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_EmployeeTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_EmployeeCd = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_EmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_CustomerTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.EmployeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.BLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_GroupCode = new DataDynamics.ActiveReports.Label();
            this.GroupCode = new DataDynamics.ActiveReports.TextBox();
            this.GroupName = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsName = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.gr_mMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.gr_mMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.gr_cMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.gr_pMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label41 = new DataDynamics.ActiveReports.Label();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.label42 = new DataDynamics.ActiveReports.Label();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.label44 = new DataDynamics.ActiveReports.Label();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.label45 = new DataDynamics.ActiveReports.Label();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.label46 = new DataDynamics.ActiveReports.Label();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.label47 = new DataDynamics.ActiveReports.Label();
            this.label48 = new DataDynamics.ActiveReports.Label();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.label49 = new DataDynamics.ActiveReports.Label();
            this.label50 = new DataDynamics.ActiveReports.Label();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.label51 = new DataDynamics.ActiveReports.Label();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.label67 = new DataDynamics.ActiveReports.Label();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label68 = new DataDynamics.ActiveReports.Label();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.textBox70 = new DataDynamics.ActiveReports.TextBox();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.cu_mMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.cu_mMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.cu_cMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cu_pMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.AreaHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.ArHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.ArHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_AreaTitle = new DataDynamics.ActiveReports.Label();
            this.ArHd_AreaCd = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_AreaNm = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_CustomerTitle = new DataDynamics.ActiveReports.Label();
            this.ArHd_CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.ArHd_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.AreaFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.empHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.empFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.label52 = new DataDynamics.ActiveReports.Label();
            this.arHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.arFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label55 = new DataDynamics.ActiveReports.Label();
            this.label56 = new DataDynamics.ActiveReports.Label();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.label57 = new DataDynamics.ActiveReports.Label();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.label58 = new DataDynamics.ActiveReports.Label();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.label59 = new DataDynamics.ActiveReports.Label();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.label60 = new DataDynamics.ActiveReports.Label();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.label61 = new DataDynamics.ActiveReports.Label();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.label62 = new DataDynamics.ActiveReports.Label();
            this.textBox65 = new DataDynamics.ActiveReports.TextBox();
            this.label63 = new DataDynamics.ActiveReports.Label();
            this.textBox66 = new DataDynamics.ActiveReports.TextBox();
            this.label64 = new DataDynamics.ActiveReports.Label();
            this.textBox67 = new DataDynamics.ActiveReports.TextBox();
            this.label65 = new DataDynamics.ActiveReports.Label();
            this.textBox68 = new DataDynamics.ActiveReports.TextBox();
            this.label66 = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsCd)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Goods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_CustomerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_CustomerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line_DetailHead,
            this.GoodsNo,
            this.GoodsName,
            this.mMonth01,
            this.mMonth04,
            this.mMonth03,
            this.mMonth02,
            this.mMonth07,
            this.mMonth06,
            this.mMonth05,
            this.mMonth10,
            this.mMonth09,
            this.mMonth08,
            this.mMonth12,
            this.mMonth11,
            this.cMonth01,
            this.cMonth02,
            this.cMonth03,
            this.cMonth04,
            this.cMonth05,
            this.cMonth06,
            this.cMonth07,
            this.cMonth08,
            this.cMonth09,
            this.cMonth10,
            this.cMonth11,
            this.cMonth12,
            this.pMonth01,
            this.pMonth02,
            this.pMonth03,
            this.pMonth04,
            this.pMonth05,
            this.pMonth06,
            this.pMonth07,
            this.pMonth08,
            this.pMonth09,
            this.pMonth10,
            this.pMonth11,
            this.pMonth12,
            this.tb_GroupCd,
            this.tb_GroupNm,
            this.tb_BLGoodsNm,
            this.tb_BLGoodsCd,
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
            this.textBox58});
            this.Detail.Height = 0.875F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // Line_DetailHead
            // 
            this.Line_DetailHead.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.RightColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.TopColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Height = 0F;
            this.Line_DetailHead.Left = 0F;
            this.Line_DetailHead.LineWeight = 1F;
            this.Line_DetailHead.Name = "Line_DetailHead";
            this.Line_DetailHead.Top = 0F;
            this.Line_DetailHead.Width = 10.88F;
            this.Line_DetailHead.X1 = 0F;
            this.Line_DetailHead.X2 = 10.88F;
            this.Line_DetailHead.Y1 = 0F;
            this.Line_DetailHead.Y2 = 0F;
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
            this.GoodsNo.Left = 0.1875F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "XXXXXXXXXXXXXXXXXXXXXXXX";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.4F;
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
            this.GoodsName.Left = 0.1875F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.GoodsName.Top = 0.15625F;
            this.GoodsName.Width = 1.15F;
            // 
            // mMonth01
            // 
            this.mMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth01.DataField = "SalesMoney1";
            this.mMonth01.Height = 0.16F;
            this.mMonth01.Left = 1.9375F;
            this.mMonth01.MultiLine = false;
            this.mMonth01.Name = "mMonth01";
            this.mMonth01.OutputFormat = resources.GetString("mMonth01.OutputFormat");
            this.mMonth01.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth01.Top = 0F;
            this.mMonth01.Width = 0.65F;
            // 
            // mMonth04
            // 
            this.mMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth04.DataField = "SalesMoney4";
            this.mMonth04.Height = 0.16F;
            this.mMonth04.Left = 4.1875F;
            this.mMonth04.MultiLine = false;
            this.mMonth04.Name = "mMonth04";
            this.mMonth04.OutputFormat = resources.GetString("mMonth04.OutputFormat");
            this.mMonth04.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth04.Top = 0F;
            this.mMonth04.Width = 0.65F;
            // 
            // mMonth03
            // 
            this.mMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth03.DataField = "SalesMoney3";
            this.mMonth03.Height = 0.16F;
            this.mMonth03.Left = 3.4375F;
            this.mMonth03.MultiLine = false;
            this.mMonth03.Name = "mMonth03";
            this.mMonth03.OutputFormat = resources.GetString("mMonth03.OutputFormat");
            this.mMonth03.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth03.Top = 0F;
            this.mMonth03.Width = 0.65F;
            // 
            // mMonth02
            // 
            this.mMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth02.DataField = "SalesMoney2";
            this.mMonth02.Height = 0.16F;
            this.mMonth02.Left = 2.6875F;
            this.mMonth02.MultiLine = false;
            this.mMonth02.Name = "mMonth02";
            this.mMonth02.OutputFormat = resources.GetString("mMonth02.OutputFormat");
            this.mMonth02.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth02.Top = 0F;
            this.mMonth02.Width = 0.65F;
            // 
            // mMonth07
            // 
            this.mMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth07.DataField = "SalesMoney7";
            this.mMonth07.Height = 0.16F;
            this.mMonth07.Left = 6.4375F;
            this.mMonth07.MultiLine = false;
            this.mMonth07.Name = "mMonth07";
            this.mMonth07.OutputFormat = resources.GetString("mMonth07.OutputFormat");
            this.mMonth07.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth07.Top = 0F;
            this.mMonth07.Width = 0.65F;
            // 
            // mMonth06
            // 
            this.mMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth06.DataField = "SalesMoney6";
            this.mMonth06.Height = 0.16F;
            this.mMonth06.Left = 5.6875F;
            this.mMonth06.MultiLine = false;
            this.mMonth06.Name = "mMonth06";
            this.mMonth06.OutputFormat = resources.GetString("mMonth06.OutputFormat");
            this.mMonth06.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth06.Top = 0F;
            this.mMonth06.Width = 0.65F;
            // 
            // mMonth05
            // 
            this.mMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth05.DataField = "SalesMoney5";
            this.mMonth05.Height = 0.16F;
            this.mMonth05.Left = 4.9375F;
            this.mMonth05.MultiLine = false;
            this.mMonth05.Name = "mMonth05";
            this.mMonth05.OutputFormat = resources.GetString("mMonth05.OutputFormat");
            this.mMonth05.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth05.Top = 0F;
            this.mMonth05.Width = 0.65F;
            // 
            // mMonth10
            // 
            this.mMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth10.DataField = "SalesMoney10";
            this.mMonth10.Height = 0.16F;
            this.mMonth10.Left = 8.6875F;
            this.mMonth10.MultiLine = false;
            this.mMonth10.Name = "mMonth10";
            this.mMonth10.OutputFormat = resources.GetString("mMonth10.OutputFormat");
            this.mMonth10.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth10.Top = 0F;
            this.mMonth10.Width = 0.65F;
            // 
            // mMonth09
            // 
            this.mMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth09.DataField = "SalesMoney9";
            this.mMonth09.Height = 0.16F;
            this.mMonth09.Left = 7.9375F;
            this.mMonth09.MultiLine = false;
            this.mMonth09.Name = "mMonth09";
            this.mMonth09.OutputFormat = resources.GetString("mMonth09.OutputFormat");
            this.mMonth09.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth09.Top = 0F;
            this.mMonth09.Width = 0.65F;
            // 
            // mMonth08
            // 
            this.mMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth08.DataField = "SalesMoney8";
            this.mMonth08.Height = 0.16F;
            this.mMonth08.Left = 7.1875F;
            this.mMonth08.MultiLine = false;
            this.mMonth08.Name = "mMonth08";
            this.mMonth08.OutputFormat = resources.GetString("mMonth08.OutputFormat");
            this.mMonth08.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth08.Top = 0F;
            this.mMonth08.Width = 0.65F;
            // 
            // mMonth12
            // 
            this.mMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth12.DataField = "SalesMoney12";
            this.mMonth12.Height = 0.16F;
            this.mMonth12.Left = 10.1875F;
            this.mMonth12.MultiLine = false;
            this.mMonth12.Name = "mMonth12";
            this.mMonth12.OutputFormat = resources.GetString("mMonth12.OutputFormat");
            this.mMonth12.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth12.Top = 0F;
            this.mMonth12.Width = 0.65F;
            // 
            // mMonth11
            // 
            this.mMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.mMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.mMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.mMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.mMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mMonth11.DataField = "SalesMoney11";
            this.mMonth11.Height = 0.16F;
            this.mMonth11.Left = 9.4375F;
            this.mMonth11.MultiLine = false;
            this.mMonth11.Name = "mMonth11";
            this.mMonth11.OutputFormat = resources.GetString("mMonth11.OutputFormat");
            this.mMonth11.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.mMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.mMonth11.Top = 0F;
            this.mMonth11.Width = 0.65F;
            // 
            // cMonth01
            // 
            this.cMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth01.DataField = "TotalSalesCount1";
            this.cMonth01.Height = 0.16F;
            this.cMonth01.Left = 1.9375F;
            this.cMonth01.MultiLine = false;
            this.cMonth01.Name = "cMonth01";
            this.cMonth01.OutputFormat = resources.GetString("cMonth01.OutputFormat");
            this.cMonth01.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth01.Top = 0.15625F;
            this.cMonth01.Width = 0.65F;
            // 
            // cMonth02
            // 
            this.cMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth02.DataField = "TotalSalesCount2";
            this.cMonth02.Height = 0.16F;
            this.cMonth02.Left = 2.6875F;
            this.cMonth02.MultiLine = false;
            this.cMonth02.Name = "cMonth02";
            this.cMonth02.OutputFormat = resources.GetString("cMonth02.OutputFormat");
            this.cMonth02.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth02.Top = 0.15625F;
            this.cMonth02.Width = 0.65F;
            // 
            // cMonth03
            // 
            this.cMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth03.DataField = "TotalSalesCount3";
            this.cMonth03.Height = 0.16F;
            this.cMonth03.Left = 3.4375F;
            this.cMonth03.MultiLine = false;
            this.cMonth03.Name = "cMonth03";
            this.cMonth03.OutputFormat = resources.GetString("cMonth03.OutputFormat");
            this.cMonth03.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth03.Top = 0.15625F;
            this.cMonth03.Width = 0.65F;
            // 
            // cMonth04
            // 
            this.cMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth04.DataField = "TotalSalesCount4";
            this.cMonth04.Height = 0.16F;
            this.cMonth04.Left = 4.1875F;
            this.cMonth04.MultiLine = false;
            this.cMonth04.Name = "cMonth04";
            this.cMonth04.OutputFormat = resources.GetString("cMonth04.OutputFormat");
            this.cMonth04.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth04.Top = 0.15625F;
            this.cMonth04.Width = 0.65F;
            // 
            // cMonth05
            // 
            this.cMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth05.DataField = "TotalSalesCount5";
            this.cMonth05.Height = 0.16F;
            this.cMonth05.Left = 4.9375F;
            this.cMonth05.MultiLine = false;
            this.cMonth05.Name = "cMonth05";
            this.cMonth05.OutputFormat = resources.GetString("cMonth05.OutputFormat");
            this.cMonth05.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth05.Top = 0.15625F;
            this.cMonth05.Width = 0.65F;
            // 
            // cMonth06
            // 
            this.cMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth06.DataField = "TotalSalesCount6";
            this.cMonth06.Height = 0.16F;
            this.cMonth06.Left = 5.6875F;
            this.cMonth06.MultiLine = false;
            this.cMonth06.Name = "cMonth06";
            this.cMonth06.OutputFormat = resources.GetString("cMonth06.OutputFormat");
            this.cMonth06.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth06.Top = 0.15625F;
            this.cMonth06.Width = 0.65F;
            // 
            // cMonth07
            // 
            this.cMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth07.DataField = "TotalSalesCount7";
            this.cMonth07.Height = 0.16F;
            this.cMonth07.Left = 6.4375F;
            this.cMonth07.MultiLine = false;
            this.cMonth07.Name = "cMonth07";
            this.cMonth07.OutputFormat = resources.GetString("cMonth07.OutputFormat");
            this.cMonth07.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth07.Top = 0.15625F;
            this.cMonth07.Width = 0.65F;
            // 
            // cMonth08
            // 
            this.cMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth08.DataField = "TotalSalesCount8";
            this.cMonth08.Height = 0.16F;
            this.cMonth08.Left = 7.1875F;
            this.cMonth08.MultiLine = false;
            this.cMonth08.Name = "cMonth08";
            this.cMonth08.OutputFormat = resources.GetString("cMonth08.OutputFormat");
            this.cMonth08.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth08.Top = 0.15625F;
            this.cMonth08.Width = 0.65F;
            // 
            // cMonth09
            // 
            this.cMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth09.DataField = "TotalSalesCount9";
            this.cMonth09.Height = 0.16F;
            this.cMonth09.Left = 7.9375F;
            this.cMonth09.MultiLine = false;
            this.cMonth09.Name = "cMonth09";
            this.cMonth09.OutputFormat = resources.GetString("cMonth09.OutputFormat");
            this.cMonth09.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth09.Top = 0.15625F;
            this.cMonth09.Width = 0.65F;
            // 
            // cMonth10
            // 
            this.cMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth10.DataField = "TotalSalesCount10";
            this.cMonth10.Height = 0.16F;
            this.cMonth10.Left = 8.6875F;
            this.cMonth10.MultiLine = false;
            this.cMonth10.Name = "cMonth10";
            this.cMonth10.OutputFormat = resources.GetString("cMonth10.OutputFormat");
            this.cMonth10.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth10.Top = 0.15625F;
            this.cMonth10.Width = 0.65F;
            // 
            // cMonth11
            // 
            this.cMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth11.DataField = "TotalSalesCount11";
            this.cMonth11.Height = 0.16F;
            this.cMonth11.Left = 9.4375F;
            this.cMonth11.MultiLine = false;
            this.cMonth11.Name = "cMonth11";
            this.cMonth11.OutputFormat = resources.GetString("cMonth11.OutputFormat");
            this.cMonth11.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth11.Top = 0.15625F;
            this.cMonth11.Width = 0.65F;
            // 
            // cMonth12
            // 
            this.cMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.cMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.cMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.cMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.cMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cMonth12.DataField = "TotalSalesCount12";
            this.cMonth12.Height = 0.16F;
            this.cMonth12.Left = 10.1875F;
            this.cMonth12.MultiLine = false;
            this.cMonth12.Name = "cMonth12";
            this.cMonth12.OutputFormat = resources.GetString("cMonth12.OutputFormat");
            this.cMonth12.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.cMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.cMonth12.Top = 0.15625F;
            this.cMonth12.Width = 0.65F;
            // 
            // pMonth01
            // 
            this.pMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth01.DataField = "GrossProfit1";
            this.pMonth01.Height = 0.16F;
            this.pMonth01.Left = 1.9375F;
            this.pMonth01.MultiLine = false;
            this.pMonth01.Name = "pMonth01";
            this.pMonth01.OutputFormat = resources.GetString("pMonth01.OutputFormat");
            this.pMonth01.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth01.Top = 0.3125F;
            this.pMonth01.Width = 0.65F;
            // 
            // pMonth02
            // 
            this.pMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth02.DataField = "GrossProfit2";
            this.pMonth02.Height = 0.16F;
            this.pMonth02.Left = 2.6875F;
            this.pMonth02.MultiLine = false;
            this.pMonth02.Name = "pMonth02";
            this.pMonth02.OutputFormat = resources.GetString("pMonth02.OutputFormat");
            this.pMonth02.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth02.Top = 0.3125F;
            this.pMonth02.Width = 0.65F;
            // 
            // pMonth03
            // 
            this.pMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth03.DataField = "GrossProfit3";
            this.pMonth03.Height = 0.16F;
            this.pMonth03.Left = 3.4375F;
            this.pMonth03.MultiLine = false;
            this.pMonth03.Name = "pMonth03";
            this.pMonth03.OutputFormat = resources.GetString("pMonth03.OutputFormat");
            this.pMonth03.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth03.Top = 0.3125F;
            this.pMonth03.Width = 0.65F;
            // 
            // pMonth04
            // 
            this.pMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth04.DataField = "GrossProfit4";
            this.pMonth04.Height = 0.16F;
            this.pMonth04.Left = 4.1875F;
            this.pMonth04.MultiLine = false;
            this.pMonth04.Name = "pMonth04";
            this.pMonth04.OutputFormat = resources.GetString("pMonth04.OutputFormat");
            this.pMonth04.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth04.Top = 0.3125F;
            this.pMonth04.Width = 0.65F;
            // 
            // pMonth05
            // 
            this.pMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth05.DataField = "GrossProfit5";
            this.pMonth05.Height = 0.16F;
            this.pMonth05.Left = 4.9375F;
            this.pMonth05.MultiLine = false;
            this.pMonth05.Name = "pMonth05";
            this.pMonth05.OutputFormat = resources.GetString("pMonth05.OutputFormat");
            this.pMonth05.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth05.Top = 0.3125F;
            this.pMonth05.Width = 0.65F;
            // 
            // pMonth06
            // 
            this.pMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth06.DataField = "GrossProfit6";
            this.pMonth06.Height = 0.16F;
            this.pMonth06.Left = 5.6875F;
            this.pMonth06.MultiLine = false;
            this.pMonth06.Name = "pMonth06";
            this.pMonth06.OutputFormat = resources.GetString("pMonth06.OutputFormat");
            this.pMonth06.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth06.Top = 0.3125F;
            this.pMonth06.Width = 0.65F;
            // 
            // pMonth07
            // 
            this.pMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth07.DataField = "GrossProfit7";
            this.pMonth07.Height = 0.16F;
            this.pMonth07.Left = 6.4375F;
            this.pMonth07.MultiLine = false;
            this.pMonth07.Name = "pMonth07";
            this.pMonth07.OutputFormat = resources.GetString("pMonth07.OutputFormat");
            this.pMonth07.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth07.Top = 0.3125F;
            this.pMonth07.Width = 0.65F;
            // 
            // pMonth08
            // 
            this.pMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth08.DataField = "GrossProfit8";
            this.pMonth08.Height = 0.16F;
            this.pMonth08.Left = 7.1875F;
            this.pMonth08.MultiLine = false;
            this.pMonth08.Name = "pMonth08";
            this.pMonth08.OutputFormat = resources.GetString("pMonth08.OutputFormat");
            this.pMonth08.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth08.Top = 0.3125F;
            this.pMonth08.Width = 0.65F;
            // 
            // pMonth09
            // 
            this.pMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth09.DataField = "GrossProfit9";
            this.pMonth09.Height = 0.16F;
            this.pMonth09.Left = 7.9375F;
            this.pMonth09.MultiLine = false;
            this.pMonth09.Name = "pMonth09";
            this.pMonth09.OutputFormat = resources.GetString("pMonth09.OutputFormat");
            this.pMonth09.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth09.Top = 0.3125F;
            this.pMonth09.Width = 0.65F;
            // 
            // pMonth10
            // 
            this.pMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth10.DataField = "GrossProfit10";
            this.pMonth10.Height = 0.16F;
            this.pMonth10.Left = 8.6875F;
            this.pMonth10.MultiLine = false;
            this.pMonth10.Name = "pMonth10";
            this.pMonth10.OutputFormat = resources.GetString("pMonth10.OutputFormat");
            this.pMonth10.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth10.Top = 0.3125F;
            this.pMonth10.Width = 0.65F;
            // 
            // pMonth11
            // 
            this.pMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth11.DataField = "GrossProfit11";
            this.pMonth11.Height = 0.16F;
            this.pMonth11.Left = 9.4375F;
            this.pMonth11.MultiLine = false;
            this.pMonth11.Name = "pMonth11";
            this.pMonth11.OutputFormat = resources.GetString("pMonth11.OutputFormat");
            this.pMonth11.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth11.Top = 0.3125F;
            this.pMonth11.Width = 0.65F;
            // 
            // pMonth12
            // 
            this.pMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.pMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.pMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.pMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.pMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pMonth12.DataField = "GrossProfit12";
            this.pMonth12.Height = 0.16F;
            this.pMonth12.Left = 10.1875F;
            this.pMonth12.MultiLine = false;
            this.pMonth12.Name = "pMonth12";
            this.pMonth12.OutputFormat = resources.GetString("pMonth12.OutputFormat");
            this.pMonth12.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.pMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.pMonth12.Top = 0.3125F;
            this.pMonth12.Width = 0.65F;
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
            this.tb_GroupCd.Left = 0.1875F;
            this.tb_GroupCd.MultiLine = false;
            this.tb_GroupCd.Name = "tb_GroupCd";
            this.tb_GroupCd.OutputFormat = resources.GetString("tb_GroupCd.OutputFormat");
            this.tb_GroupCd.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.tb_GroupCd.Text = "12345";
            this.tb_GroupCd.Top = 0.375F;
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
            this.tb_GroupNm.Left = 0.625F;
            this.tb_GroupNm.MultiLine = false;
            this.tb_GroupNm.Name = "tb_GroupNm";
            this.tb_GroupNm.OutputFormat = resources.GetString("tb_GroupNm.OutputFormat");
            this.tb_GroupNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_GroupNm.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.tb_GroupNm.Top = 0.375F;
            this.tb_GroupNm.Visible = false;
            this.tb_GroupNm.Width = 1.15F;
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
            this.tb_BLGoodsNm.Left = 0.625F;
            this.tb_BLGoodsNm.MultiLine = false;
            this.tb_BLGoodsNm.Name = "tb_BLGoodsNm";
            this.tb_BLGoodsNm.OutputFormat = resources.GetString("tb_BLGoodsNm.OutputFormat");
            this.tb_BLGoodsNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_BLGoodsNm.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.tb_BLGoodsNm.Top = 0.5625F;
            this.tb_BLGoodsNm.Visible = false;
            this.tb_BLGoodsNm.Width = 1.15F;
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
            this.tb_BLGoodsCd.Left = 0.1875F;
            this.tb_BLGoodsCd.MultiLine = false;
            this.tb_BLGoodsCd.Name = "tb_BLGoodsCd";
            this.tb_BLGoodsCd.OutputFormat = resources.GetString("tb_BLGoodsCd.OutputFormat");
            this.tb_BLGoodsCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_BLGoodsCd.Text = "12345";
            this.tb_BLGoodsCd.Top = 0.5625F;
            this.tb_BLGoodsCd.Visible = false;
            this.tb_BLGoodsCd.Width = 0.35F;
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
            this.textBox42.DataField = "TermSalesCount";
            this.textBox42.Height = 0.16F;
            this.textBox42.Left = 4.3125F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.textBox42.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox42.Top = 0.5F;
            this.textBox42.Visible = false;
            this.textBox42.Width = 0.7F;
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
            this.textBox43.DataField = "TermSalesMoney";
            this.textBox43.Height = 0.16F;
            this.textBox43.Left = 1.9375F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox43.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox43.Top = 0.5F;
            this.textBox43.Visible = false;
            this.textBox43.Width = 0.9F;
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
            this.textBox44.DataField = "TermSalesProfitRate";
            this.textBox44.Height = 0.16F;
            this.textBox44.Left = 7.25F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.Text = "ZZZ9.99";
            this.textBox44.Top = 0.5F;
            this.textBox44.Visible = false;
            this.textBox44.Width = 0.45F;
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
            this.textBox45.DataField = "TermSalesProfit";
            this.textBox45.Height = 0.16F;
            this.textBox45.Left = 6.3125F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox45.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox45.Top = 0.5F;
            this.textBox45.Visible = false;
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
            this.textBox46.DataField = "TermSalesTargetCount1";
            this.textBox46.Height = 0.16F;
            this.textBox46.Left = 5.0625F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryGroup = "";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox46.Top = 0.5F;
            this.textBox46.Width = 0.7F;
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
            this.textBox47.DataField = "TermSalesCountAchivRate1";
            this.textBox47.Height = 0.16F;
            this.textBox47.Left = 5.8125F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox47.Text = "ZZZ9.99";
            this.textBox47.Top = 0.5F;
            this.textBox47.Visible = false;
            this.textBox47.Width = 0.45F;
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
            this.textBox48.DataField = "TermSalesTarget1";
            this.textBox48.Height = 0.16F;
            this.textBox48.Left = 2.875F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox48.SummaryGroup = "";
            this.textBox48.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox48.Top = 0.5F;
            this.textBox48.Visible = false;
            this.textBox48.Width = 0.9F;
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
            this.textBox49.DataField = "TermSalesMoneyAchivRate1";
            this.textBox49.Height = 0.16F;
            this.textBox49.Left = 3.8125F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox49.Text = "ZZZ9.99";
            this.textBox49.Top = 0.5F;
            this.textBox49.Visible = false;
            this.textBox49.Width = 0.45F;
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
            this.textBox50.DataField = "TermSalesTargetProfit1";
            this.textBox50.Height = 0.16F;
            this.textBox50.Left = 7.75F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox50.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox50.Top = 0.5F;
            this.textBox50.Visible = false;
            this.textBox50.Width = 0.9F;
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
            this.textBox51.DataField = "TermSalesProfitAchivRate1";
            this.textBox51.Height = 0.16F;
            this.textBox51.Left = 8.6875F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox51.Text = "ZZZ9.99";
            this.textBox51.Top = 0.5F;
            this.textBox51.Visible = false;
            this.textBox51.Width = 0.45F;
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
            this.textBox52.DataField = "TermSalesTargetCount1";
            this.textBox52.Height = 0.16F;
            this.textBox52.Left = 5.0625F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox52.SummaryGroup = "";
            this.textBox52.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox52.Top = 0.5F;
            this.textBox52.Visible = false;
            this.textBox52.Width = 0.7F;
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
            this.textBox53.DataField = "TermSalesTarget2";
            this.textBox53.Height = 0.16F;
            this.textBox53.Left = 2.875F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox53.SummaryGroup = "";
            this.textBox53.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox53.Top = 0.6875F;
            this.textBox53.Visible = false;
            this.textBox53.Width = 0.9F;
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
            this.textBox54.DataField = "TermSalesMoneyAchivRate2";
            this.textBox54.Height = 0.16F;
            this.textBox54.Left = 3.8125F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.Text = "ZZZ9.99";
            this.textBox54.Top = 0.6875F;
            this.textBox54.Visible = false;
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
            this.textBox55.DataField = "TermSalesTargetCount2";
            this.textBox55.Height = 0.16F;
            this.textBox55.Left = 5.0625F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox55.SummaryGroup = "";
            this.textBox55.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox55.Top = 0.6875F;
            this.textBox55.Visible = false;
            this.textBox55.Width = 0.7F;
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
            this.textBox56.DataField = "TermSalesCountAchivRate2";
            this.textBox56.Height = 0.16F;
            this.textBox56.Left = 5.8125F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox56.Text = "ZZZ9.99";
            this.textBox56.Top = 0.6875F;
            this.textBox56.Visible = false;
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
            this.textBox57.DataField = "TermSalesTargetProfit2";
            this.textBox57.Height = 0.16F;
            this.textBox57.Left = 7.75F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox57.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox57.Top = 0.6875F;
            this.textBox57.Visible = false;
            this.textBox57.Width = 0.9F;
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
            this.textBox58.DataField = "TermSalesProfitAchivRate2";
            this.textBox58.Height = 0.16F;
            this.textBox58.Left = 8.6875F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox58.Text = "ZZZ9.99";
            this.textBox58.Top = 0.6875F;
            this.textBox58.Visible = false;
            this.textBox58.Width = 0.45F;
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
            this.Line1.Width = 10.88F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.88F;
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
            this.tb_Sort.Top = 0.063F;
            this.tb_Sort.Width = 0.9375F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport,
            this.line7});
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
            this.line7.Width = 10.88F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.88F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
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
            this.Header_SubReport.Width = 10.88F;
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
            this.Lb_Month11,
            this.Lb_Month04,
            this.Lb_Month02,
            this.Lb_Month03,
            this.Lb_Month01,
            this.Lb_Month07,
            this.Lb_Month09,
            this.Lb_Month10,
            this.Lb_Month12,
            this.Lb_Month05,
            this.Lb_Month06,
            this.Lb_Month08,
            this.Lb_Goods,
            this.Lb_BLGroupCode,
            this.label4,
            this.CampaignCode,
            this.CampaignName,
            this.label5,
            this.ApplyDate,
            this.label1});
            this.TitleHeader.Height = 0.40625F;
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
            this.Line42.Width = 10.88F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.88F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // Lb_Month11
            // 
            this.Lb_Month11.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Height = 0.156F;
            this.Lb_Month11.HyperLink = "";
            this.Lb_Month11.Left = 9.5625F;
            this.Lb_Month11.MultiLine = false;
            this.Lb_Month11.Name = "Lb_Month11";
            this.Lb_Month11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month11.Text = "11月";
            this.Lb_Month11.Top = 0.22F;
            this.Lb_Month11.Width = 0.51F;
            // 
            // Lb_Month04
            // 
            this.Lb_Month04.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Height = 0.156F;
            this.Lb_Month04.HyperLink = "";
            this.Lb_Month04.Left = 4.3125F;
            this.Lb_Month04.MultiLine = false;
            this.Lb_Month04.Name = "Lb_Month04";
            this.Lb_Month04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month04.Text = "4月";
            this.Lb_Month04.Top = 0.22F;
            this.Lb_Month04.Width = 0.51F;
            // 
            // Lb_Month02
            // 
            this.Lb_Month02.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Height = 0.156F;
            this.Lb_Month02.HyperLink = "";
            this.Lb_Month02.Left = 2.8125F;
            this.Lb_Month02.MultiLine = false;
            this.Lb_Month02.Name = "Lb_Month02";
            this.Lb_Month02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month02.Text = "2月";
            this.Lb_Month02.Top = 0.22F;
            this.Lb_Month02.Width = 0.51F;
            // 
            // Lb_Month03
            // 
            this.Lb_Month03.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Height = 0.156F;
            this.Lb_Month03.HyperLink = "";
            this.Lb_Month03.Left = 3.5625F;
            this.Lb_Month03.MultiLine = false;
            this.Lb_Month03.Name = "Lb_Month03";
            this.Lb_Month03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month03.Text = "3月";
            this.Lb_Month03.Top = 0.22F;
            this.Lb_Month03.Width = 0.51F;
            // 
            // Lb_Month01
            // 
            this.Lb_Month01.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Height = 0.156F;
            this.Lb_Month01.HyperLink = "";
            this.Lb_Month01.Left = 2.125F;
            this.Lb_Month01.MultiLine = false;
            this.Lb_Month01.Name = "Lb_Month01";
            this.Lb_Month01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month01.Text = "1月";
            this.Lb_Month01.Top = 0.22F;
            this.Lb_Month01.Width = 0.45F;
            // 
            // Lb_Month07
            // 
            this.Lb_Month07.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Height = 0.156F;
            this.Lb_Month07.HyperLink = "";
            this.Lb_Month07.Left = 6.5625F;
            this.Lb_Month07.MultiLine = false;
            this.Lb_Month07.Name = "Lb_Month07";
            this.Lb_Month07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month07.Text = "7月";
            this.Lb_Month07.Top = 0.22F;
            this.Lb_Month07.Width = 0.51F;
            // 
            // Lb_Month09
            // 
            this.Lb_Month09.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Height = 0.156F;
            this.Lb_Month09.HyperLink = "";
            this.Lb_Month09.Left = 8.0625F;
            this.Lb_Month09.MultiLine = false;
            this.Lb_Month09.Name = "Lb_Month09";
            this.Lb_Month09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month09.Text = "9月";
            this.Lb_Month09.Top = 0.22F;
            this.Lb_Month09.Width = 0.51F;
            // 
            // Lb_Month10
            // 
            this.Lb_Month10.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Height = 0.156F;
            this.Lb_Month10.HyperLink = "";
            this.Lb_Month10.Left = 8.8125F;
            this.Lb_Month10.MultiLine = false;
            this.Lb_Month10.Name = "Lb_Month10";
            this.Lb_Month10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month10.Text = "10月";
            this.Lb_Month10.Top = 0.22F;
            this.Lb_Month10.Width = 0.51F;
            // 
            // Lb_Month12
            // 
            this.Lb_Month12.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Height = 0.156F;
            this.Lb_Month12.HyperLink = "";
            this.Lb_Month12.Left = 10.3125F;
            this.Lb_Month12.MultiLine = false;
            this.Lb_Month12.Name = "Lb_Month12";
            this.Lb_Month12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month12.Text = "12月";
            this.Lb_Month12.Top = 0.22F;
            this.Lb_Month12.Width = 0.51F;
            // 
            // Lb_Month05
            // 
            this.Lb_Month05.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Height = 0.156F;
            this.Lb_Month05.HyperLink = "";
            this.Lb_Month05.Left = 5.0625F;
            this.Lb_Month05.MultiLine = false;
            this.Lb_Month05.Name = "Lb_Month05";
            this.Lb_Month05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month05.Text = "5月";
            this.Lb_Month05.Top = 0.22F;
            this.Lb_Month05.Width = 0.51F;
            // 
            // Lb_Month06
            // 
            this.Lb_Month06.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Height = 0.156F;
            this.Lb_Month06.HyperLink = "";
            this.Lb_Month06.Left = 5.8125F;
            this.Lb_Month06.MultiLine = false;
            this.Lb_Month06.Name = "Lb_Month06";
            this.Lb_Month06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month06.Text = "6月";
            this.Lb_Month06.Top = 0.22F;
            this.Lb_Month06.Width = 0.51F;
            // 
            // Lb_Month08
            // 
            this.Lb_Month08.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Height = 0.156F;
            this.Lb_Month08.HyperLink = "";
            this.Lb_Month08.Left = 7.3125F;
            this.Lb_Month08.MultiLine = false;
            this.Lb_Month08.Name = "Lb_Month08";
            this.Lb_Month08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Month08.Text = "8月";
            this.Lb_Month08.Top = 0.22F;
            this.Lb_Month08.Width = 0.51F;
            // 
            // Lb_Goods
            // 
            this.Lb_Goods.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Goods.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Goods.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Goods.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Goods.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Goods.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Goods.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Goods.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Goods.Height = 0.16F;
            this.Lb_Goods.HyperLink = "";
            this.Lb_Goods.Left = 0.1875F;
            this.Lb_Goods.MultiLine = false;
            this.Lb_Goods.Name = "Lb_Goods";
            this.Lb_Goods.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_Goods.Text = "品番/品名";
            this.Lb_Goods.Top = 0.22F;
            this.Lb_Goods.Width = 0.688F;
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
            this.Lb_BLGroupCode.Height = 0.16F;
            this.Lb_BLGroupCode.HyperLink = "";
            this.Lb_BLGroupCode.Left = 1.125F;
            this.Lb_BLGroupCode.MultiLine = false;
            this.Lb_BLGroupCode.Name = "Lb_BLGroupCode";
            this.Lb_BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.Lb_BLGroupCode.Text = "グループ";
            this.Lb_BLGroupCode.Top = 0.22F;
            this.Lb_BLGroupCode.Visible = false;
            this.Lb_BLGroupCode.Width = 0.563F;
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
            this.label1.Left = 8.5F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8.25pt; fon" +
                "t-family: ＭＳ 明朝; vertical-align: bottom; ";
            this.label1.Text = "[上段：金額／中段：数量／下段：粗利]";
            this.label1.Top = 0F;
            this.label1.Width = 2.3F;
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
            this.textBox19,
            this.textBox20,
            this.label30,
            this.label31,
            this.label32,
            this.textBox22,
            this.label33,
            this.textBox23,
            this.label34,
            this.textBox24,
            this.label35,
            this.label36,
            this.textBox25,
            this.label37,
            this.label38,
            this.textBox26,
            this.label39,
            this.textBox27,
            this.textBox28,
            this.textBox30,
            this.label53});
            this.GrandTotalFooter.Height = 0.2083333F;
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
            this.GrandTotalTitle.Height = 0.16F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 0F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0F;
            this.GrandTotalTitle.Width = 0.5F;
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
            this.Line43.Width = 10.88F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.88F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
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
            this.textBox19.DataField = "TermSalesMoney";
            this.textBox19.Height = 0.16F;
            this.textBox19.Left = 1.01F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox19.Text = "[ZZZZ,ZZZ,ZZ9]";
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
            this.textBox20.DataField = "TermSalesTarget2";
            this.textBox20.Height = 0.16F;
            this.textBox20.Left = 2.0625F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox20.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox20.Top = 0F;
            this.textBox20.Width = 0.7F;
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
            this.label30.Height = 0.16F;
            this.label30.HyperLink = "";
            this.label30.Left = 6.676667F;
            this.label30.MultiLine = false;
            this.label30.Name = "label30";
            this.label30.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label30.Text = "]粗利額[";
            this.label30.Top = 0F;
            this.label30.Width = 0.48F;
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
            this.label31.Height = 0.16F;
            this.label31.HyperLink = "";
            this.label31.Left = 1.687083F;
            this.label31.MultiLine = false;
            this.label31.Name = "label31";
            this.label31.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label31.Text = "]目標[";
            this.label31.Top = 0F;
            this.label31.Width = 0.38F;
            // 
            // label32
            // 
            this.label32.Border.BottomColor = System.Drawing.Color.Black;
            this.label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.LeftColor = System.Drawing.Color.Black;
            this.label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.RightColor = System.Drawing.Color.Black;
            this.label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.TopColor = System.Drawing.Color.Black;
            this.label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Height = 0.16F;
            this.label32.HyperLink = "";
            this.label32.Left = 2.72875F;
            this.label32.MultiLine = false;
            this.label32.Name = "label32";
            this.label32.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label32.Text = "]達成率[";
            this.label32.Top = 0F;
            this.label32.Width = 0.48F;
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
            this.textBox22.Height = 0.16F;
            this.textBox22.Left = 3.16625F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox22.Text = "ZZZ9.99";
            this.textBox22.Top = 0F;
            this.textBox22.Width = 0.45F;
            // 
            // label33
            // 
            this.label33.Border.BottomColor = System.Drawing.Color.Black;
            this.label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.LeftColor = System.Drawing.Color.Black;
            this.label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.RightColor = System.Drawing.Color.Black;
            this.label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.TopColor = System.Drawing.Color.Black;
            this.label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Height = 0.16F;
            this.label33.HyperLink = "";
            this.label33.Left = 3.614166F;
            this.label33.MultiLine = false;
            this.label33.Name = "label33";
            this.label33.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label33.Text = "]売上数[";
            this.label33.Top = 0F;
            this.label33.Width = 0.48F;
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
            this.textBox23.DataField = "TermSalesCount";
            this.textBox23.Height = 0.16F;
            this.textBox23.Left = 4.094166F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox23.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox23.Top = 0F;
            this.textBox23.Width = 0.65F;
            // 
            // label34
            // 
            this.label34.Border.BottomColor = System.Drawing.Color.Black;
            this.label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.LeftColor = System.Drawing.Color.Black;
            this.label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.RightColor = System.Drawing.Color.Black;
            this.label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.TopColor = System.Drawing.Color.Black;
            this.label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Height = 0.16F;
            this.label34.HyperLink = "";
            this.label34.Left = 4.718833F;
            this.label34.MultiLine = false;
            this.label34.Name = "label34";
            this.label34.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label34.Text = "]目標[";
            this.label34.Top = 0F;
            this.label34.Width = 0.37F;
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
            this.textBox24.DataField = "TermSalesTargetCount2";
            this.textBox24.Height = 0.16F;
            this.textBox24.Left = 5.083416F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox24.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox24.Top = 0F;
            this.textBox24.Width = 0.65F;
            // 
            // label35
            // 
            this.label35.Border.BottomColor = System.Drawing.Color.Black;
            this.label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.LeftColor = System.Drawing.Color.Black;
            this.label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.RightColor = System.Drawing.Color.Black;
            this.label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.TopColor = System.Drawing.Color.Black;
            this.label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Height = 0.16F;
            this.label35.HyperLink = "";
            this.label35.Left = 5.708084F;
            this.label35.MultiLine = false;
            this.label35.Name = "label35";
            this.label35.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label35.Text = "]達成率[";
            this.label35.Top = 0F;
            this.label35.Width = 0.48F;
            // 
            // label36
            // 
            this.label36.Border.BottomColor = System.Drawing.Color.Black;
            this.label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.LeftColor = System.Drawing.Color.Black;
            this.label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.RightColor = System.Drawing.Color.Black;
            this.label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.TopColor = System.Drawing.Color.Black;
            this.label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Height = 0.16F;
            this.label36.HyperLink = "";
            this.label36.Left = 0.625F;
            this.label36.MultiLine = false;
            this.label36.Name = "label36";
            this.label36.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label36.Text = "売上額[";
            this.label36.Top = 0F;
            this.label36.Width = 0.42F;
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
            this.textBox25.DataField = "TermSalesProfit";
            this.textBox25.Height = 0.16F;
            this.textBox25.Left = 7.156666F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox25.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox25.Top = 0F;
            this.textBox25.Width = 0.7F;
            // 
            // label37
            // 
            this.label37.Border.BottomColor = System.Drawing.Color.Black;
            this.label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.LeftColor = System.Drawing.Color.Black;
            this.label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.RightColor = System.Drawing.Color.Black;
            this.label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.TopColor = System.Drawing.Color.Black;
            this.label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Height = 0.16F;
            this.label37.HyperLink = "";
            this.label37.Left = 7.83375F;
            this.label37.MultiLine = false;
            this.label37.Name = "label37";
            this.label37.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label37.Text = "]粗利率[";
            this.label37.Top = 0F;
            this.label37.Width = 0.48F;
            // 
            // label38
            // 
            this.label38.Border.BottomColor = System.Drawing.Color.Black;
            this.label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.LeftColor = System.Drawing.Color.Black;
            this.label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.RightColor = System.Drawing.Color.Black;
            this.label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.TopColor = System.Drawing.Color.Black;
            this.label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Height = 0.16F;
            this.label38.HyperLink = "";
            this.label38.Left = 8.802333F;
            this.label38.MultiLine = false;
            this.label38.Name = "label38";
            this.label38.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label38.Text = "]目標[";
            this.label38.Top = 0F;
            this.label38.Width = 0.37F;
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
            this.textBox26.DataField = "TermSalesTargetProfit2";
            this.textBox26.Height = 0.16F;
            this.textBox26.Left = 9.177333F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox26.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox26.Top = 0F;
            this.textBox26.Width = 0.7F;
            // 
            // label39
            // 
            this.label39.Border.BottomColor = System.Drawing.Color.Black;
            this.label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.LeftColor = System.Drawing.Color.Black;
            this.label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.RightColor = System.Drawing.Color.Black;
            this.label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.TopColor = System.Drawing.Color.Black;
            this.label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Height = 0.16F;
            this.label39.HyperLink = "";
            this.label39.Left = 9.843666F;
            this.label39.MultiLine = false;
            this.label39.Name = "label39";
            this.label39.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label39.Text = "]達成率[";
            this.label39.Top = 0F;
            this.label39.Width = 0.48F;
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
            this.textBox27.Height = 0.16F;
            this.textBox27.Left = 6.24F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox27.Text = "ZZZ9.99";
            this.textBox27.Top = 0F;
            this.textBox27.Width = 0.45F;
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
            this.textBox28.Height = 0.16F;
            this.textBox28.Left = 8.32F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox28.Text = "[ZZZ9.99]";
            this.textBox28.Top = 0F;
            this.textBox28.Width = 0.5F;
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
            this.textBox30.Left = 10.29F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox30.Text = "[ZZZ9.99]";
            this.textBox30.Top = 0F;
            this.textBox30.Width = 0.5F;
            // 
            // label53
            // 
            this.label53.Border.BottomColor = System.Drawing.Color.Black;
            this.label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.LeftColor = System.Drawing.Color.Black;
            this.label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.RightColor = System.Drawing.Color.Black;
            this.label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.TopColor = System.Drawing.Color.Black;
            this.label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Height = 0.16F;
            this.label53.HyperLink = "";
            this.label53.Left = 10.78125F;
            this.label53.MultiLine = false;
            this.label53.Name = "label53";
            this.label53.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label53.Text = "]";
            this.label53.Top = 0F;
            this.label53.Width = 0.05F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox21,
            this.textBox31,
            this.line9,
            this.label40,
            this.line10});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.21875F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Visible = false;
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
            this.textBox21.DataField = "AddUpSecCode";
            this.textBox21.Height = 0.16F;
            this.textBox21.Left = 0.3125F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.textBox21.Text = "12";
            this.textBox21.Top = 0F;
            this.textBox21.Width = 0.2F;
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
            this.textBox31.DataField = "SectionGuideNm";
            this.textBox31.Height = 0.16F;
            this.textBox31.Left = 0.5F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.textBox31.Text = "あいうえおかきくけこ";
            this.textBox31.Top = 0F;
            this.textBox31.Width = 1.2F;
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
            this.line9.Width = 10.88F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.88F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // label40
            // 
            this.label40.Border.BottomColor = System.Drawing.Color.Black;
            this.label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.LeftColor = System.Drawing.Color.Black;
            this.label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.RightColor = System.Drawing.Color.Black;
            this.label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.TopColor = System.Drawing.Color.Black;
            this.label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Height = 0.16F;
            this.label40.HyperLink = "";
            this.label40.Left = 0F;
            this.label40.MultiLine = false;
            this.label40.Name = "label40";
            this.label40.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label40.Text = "拠点";
            this.label40.Top = 0F;
            this.label40.Width = 0.28F;
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
            this.line10.LineWeight = 1.5F;
            this.line10.Name = "line10";
            this.line10.Top = 0.16F;
            this.line10.Visible = false;
            this.line10.Width = 10.875F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.875F;
            this.line10.Y1 = 0.16F;
            this.line10.Y2 = 0.16F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.label9,
            this.textBox29,
            this.textBox1,
            this.label10,
            this.label11,
            this.label12,
            this.suCmpPureSalesRatio,
            this.label13,
            this.textBox2,
            this.label14,
            this.textBox3,
            this.label15,
            this.label16,
            this.textBox5,
            this.label17,
            this.label18,
            this.textBox7,
            this.label19,
            this.textBox4,
            this.textBox6,
            this.textBox8,
            this.label54});
            this.SectionFooter.Height = 0.1875F;
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
            this.Line45.Width = 10.88F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.88F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
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
            this.label9.Left = 0F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "拠点計";
            this.label9.Top = 0F;
            this.label9.Width = 0.5F;
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
            this.textBox29.DataField = "TermSalesMoney";
            this.textBox29.Height = 0.16F;
            this.textBox29.Left = 1.01F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.SummaryGroup = "SectionHeader";
            this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox29.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox29.Top = 0F;
            this.textBox29.Width = 0.7F;
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
            this.textBox1.DataField = "TermSalesTarget2";
            this.textBox1.Height = 0.16F;
            this.textBox1.Left = 2.0625F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox1.SummaryGroup = "SectionHeader";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox1.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.7F;
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
            this.label10.Left = 6.676667F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "]粗利額[";
            this.label10.Top = 0F;
            this.label10.Width = 0.48F;
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
            this.label11.Left = 1.687083F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "]目標[";
            this.label11.Top = 0F;
            this.label11.Width = 0.38F;
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
            this.label12.Left = 2.72875F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "]達成率[";
            this.label12.Top = 0F;
            this.label12.Width = 0.48F;
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
            this.suCmpPureSalesRatio.Left = 3.16625F;
            this.suCmpPureSalesRatio.MultiLine = false;
            this.suCmpPureSalesRatio.Name = "suCmpPureSalesRatio";
            this.suCmpPureSalesRatio.OutputFormat = resources.GetString("suCmpPureSalesRatio.OutputFormat");
            this.suCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suCmpPureSalesRatio.Text = "[ZZZ9.99]";
            this.suCmpPureSalesRatio.Top = 0F;
            this.suCmpPureSalesRatio.Width = 0.45F;
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
            this.label13.Left = 3.614166F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "]売上数[";
            this.label13.Top = 0F;
            this.label13.Width = 0.48F;
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
            this.textBox2.DataField = "TermSalesCount";
            this.textBox2.Height = 0.16F;
            this.textBox2.Left = 4.094166F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryGroup = "SectionHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.65F;
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
            this.label14.Left = 4.718833F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "]目標[";
            this.label14.Top = 0F;
            this.label14.Width = 0.37F;
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
            this.textBox3.DataField = "TermSalesTargetCount2";
            this.textBox3.Height = 0.16F;
            this.textBox3.Left = 5.083416F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox3.SummaryGroup = "SectionHeader";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.65F;
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
            this.label15.Left = 5.708084F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "]達成率[";
            this.label15.Top = 0F;
            this.label15.Width = 0.48F;
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
            this.label16.Height = 0.16F;
            this.label16.HyperLink = "";
            this.label16.Left = 0.625F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "売上額[";
            this.label16.Top = 0F;
            this.label16.Width = 0.42F;
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
            this.textBox5.DataField = "TermSalesProfit";
            this.textBox5.Height = 0.16F;
            this.textBox5.Left = 7.156666F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox5.SummaryGroup = "SectionHeader";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.7F;
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
            this.label17.Left = 7.83375F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "]粗利率[";
            this.label17.Top = 0F;
            this.label17.Width = 0.48F;
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
            this.label18.Left = 8.802333F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "]目標[";
            this.label18.Top = 0F;
            this.label18.Width = 0.37F;
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
            this.textBox7.DataField = "TermSalesTargetProfit2";
            this.textBox7.Height = 0.16F;
            this.textBox7.Left = 9.177333F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox7.SummaryGroup = "SectionHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.7F;
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
            this.label19.Height = 0.16F;
            this.label19.HyperLink = "";
            this.label19.Left = 9.843666F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "]達成率[";
            this.label19.Top = 0F;
            this.label19.Width = 0.48F;
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
            this.textBox4.Left = 6.24F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox4.Text = "[ZZZ9.99]";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.45F;
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
            this.textBox6.Height = 0.16F;
            this.textBox6.Left = 8.32F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.Text = "[ZZZ9.99]";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.5F;
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
            this.textBox8.Height = 0.16F;
            this.textBox8.Left = 10.29F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.Text = "[ZZZ9.99]";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.5F;
            // 
            // label54
            // 
            this.label54.Border.BottomColor = System.Drawing.Color.Black;
            this.label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.LeftColor = System.Drawing.Color.Black;
            this.label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.RightColor = System.Drawing.Color.Black;
            this.label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.TopColor = System.Drawing.Color.Black;
            this.label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Height = 0.16F;
            this.label54.HyperLink = "";
            this.label54.Left = 10.78125F;
            this.label54.MultiLine = false;
            this.label54.Name = "label54";
            this.label54.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label54.Text = "]";
            this.label54.Top = 0F;
            this.label54.Width = 0.05F;
            // 
            // EmployeeHeader
            // 
            this.EmployeeHeader.CanShrink = true;
            this.EmployeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line11,
            this.SupHd_SectionTitle,
            this.SupHd_AddUpSecCode,
            this.SupHd_SectionGuideNm,
            this.SupHd_EmployeeTitle,
            this.SupHd_EmployeeCd,
            this.SupHd_EmployeeNm,
            this.SupHd_CustomerTitle,
            this.SupHd_CustomerName,
            this.SupHd_CustomerCode,
            this.line15});
            this.EmployeeHeader.DataField = "HeaderKey1";
            this.EmployeeHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.EmployeeHeader.Height = 0.25F;
            this.EmployeeHeader.KeepTogether = true;
            this.EmployeeHeader.Name = "EmployeeHeader";
            this.EmployeeHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.line11.Width = 10.88F;
            this.line11.X1 = 0F;
            this.line11.X2 = 10.88F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0F;
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
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SectionTitle.Text = "拠点";
            this.SupHd_SectionTitle.Top = 0F;
            this.SupHd_SectionTitle.Width = 0.28F;
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
                "-align: top; ";
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
                "lign: top; ";
            this.SupHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SupHd_SectionGuideNm.Top = 0F;
            this.SupHd_SectionGuideNm.Width = 1.2F;
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
            this.SupHd_EmployeeTitle.Left = 1.9375F;
            this.SupHd_EmployeeTitle.MultiLine = false;
            this.SupHd_EmployeeTitle.Name = "SupHd_EmployeeTitle";
            this.SupHd_EmployeeTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.SupHd_EmployeeTitle.Text = "担当者";
            this.SupHd_EmployeeTitle.Top = 0F;
            this.SupHd_EmployeeTitle.Width = 0.4F;
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
            this.SupHd_EmployeeCd.Left = 2.375F;
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
            this.SupHd_EmployeeNm.Left = 2.6875F;
            this.SupHd_EmployeeNm.MultiLine = false;
            this.SupHd_EmployeeNm.Name = "SupHd_EmployeeNm";
            this.SupHd_EmployeeNm.OutputFormat = resources.GetString("SupHd_EmployeeNm.OutputFormat");
            this.SupHd_EmployeeNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.SupHd_EmployeeNm.Text = "あいうえおかきくけこ";
            this.SupHd_EmployeeNm.Top = 0F;
            this.SupHd_EmployeeNm.Width = 1.2F;
            // 
            // SupHd_CustomerTitle
            // 
            this.SupHd_CustomerTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_CustomerTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_CustomerTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_CustomerTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_CustomerTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerTitle.Height = 0.16F;
            this.SupHd_CustomerTitle.HyperLink = "";
            this.SupHd_CustomerTitle.Left = 4.1875F;
            this.SupHd_CustomerTitle.MultiLine = false;
            this.SupHd_CustomerTitle.Name = "SupHd_CustomerTitle";
            this.SupHd_CustomerTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.SupHd_CustomerTitle.Text = "得意先";
            this.SupHd_CustomerTitle.Top = 0F;
            this.SupHd_CustomerTitle.Visible = false;
            this.SupHd_CustomerTitle.Width = 0.438F;
            // 
            // SupHd_CustomerName
            // 
            this.SupHd_CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerName.DataField = "CustomerSnm";
            this.SupHd_CustomerName.Height = 0.16F;
            this.SupHd_CustomerName.Left = 5.125F;
            this.SupHd_CustomerName.MultiLine = false;
            this.SupHd_CustomerName.Name = "SupHd_CustomerName";
            this.SupHd_CustomerName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.SupHd_CustomerName.Text = "あいうえおかきくけこ";
            this.SupHd_CustomerName.Top = 0F;
            this.SupHd_CustomerName.Visible = false;
            this.SupHd_CustomerName.Width = 1.2F;
            // 
            // SupHd_CustomerCode
            // 
            this.SupHd_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_CustomerCode.DataField = "CustomerCode";
            this.SupHd_CustomerCode.Height = 0.16F;
            this.SupHd_CustomerCode.Left = 4.625F;
            this.SupHd_CustomerCode.MultiLine = false;
            this.SupHd_CustomerCode.Name = "SupHd_CustomerCode";
            this.SupHd_CustomerCode.OutputFormat = resources.GetString("SupHd_CustomerCode.OutputFormat");
            this.SupHd_CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.SupHd_CustomerCode.Text = "12345678";
            this.SupHd_CustomerCode.Top = 0F;
            this.SupHd_CustomerCode.Visible = false;
            this.SupHd_CustomerCode.Width = 0.5F;
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
            this.line15.Width = 10.875F;
            this.line15.X1 = 0F;
            this.line15.X2 = 10.875F;
            this.line15.Y1 = 0.16F;
            this.line15.Y2 = 0.16F;
            // 
            // EmployeeFooter
            // 
            this.EmployeeFooter.CanShrink = true;
            this.EmployeeFooter.Height = 0F;
            this.EmployeeFooter.KeepTogether = true;
            this.EmployeeFooter.Name = "EmployeeFooter";
            // 
            // BLGroupHeader
            // 
            this.BLGroupHeader.CanShrink = true;
            this.BLGroupHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.Lb_GroupCode,
            this.GroupCode,
            this.GroupName,
            this.BLGoodsCode,
            this.BLGoodsName});
            this.BLGroupHeader.DataField = "BLGroupCode";
            this.BLGroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.BLGroupHeader.Height = 0.21875F;
            this.BLGroupHeader.KeepTogether = true;
            this.BLGroupHeader.Name = "BLGroupHeader";
            this.BLGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.line2.Width = 10.88F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.88F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.BLGoodsCode.Left = 2.1875F;
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
            this.BLGoodsName.Left = 2.625F;
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
            // BLGroupFooter
            // 
            this.BLGroupFooter.CanShrink = true;
            this.BLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line8,
            this.gr_mMonth01,
            this.gr_mMonth04,
            this.gr_mMonth03,
            this.gr_mMonth02,
            this.gr_mMonth07,
            this.gr_mMonth06,
            this.gr_mMonth05,
            this.gr_mMonth10,
            this.gr_mMonth09,
            this.gr_mMonth08,
            this.gr_mMonth12,
            this.gr_mMonth11,
            this.gr_cMonth05,
            this.gr_cMonth06,
            this.gr_cMonth07,
            this.gr_cMonth08,
            this.gr_cMonth09,
            this.gr_cMonth10,
            this.gr_cMonth11,
            this.gr_cMonth12,
            this.gr_cMonth01,
            this.gr_cMonth02,
            this.gr_cMonth03,
            this.gr_cMonth04,
            this.gr_pMonth01,
            this.gr_pMonth02,
            this.gr_pMonth03,
            this.gr_pMonth04,
            this.gr_pMonth05,
            this.gr_pMonth06,
            this.gr_pMonth07,
            this.gr_pMonth08,
            this.gr_pMonth09,
            this.gr_pMonth10,
            this.gr_pMonth11,
            this.gr_pMonth12,
            this.label6,
            this.label41,
            this.textBox32,
            this.textBox33,
            this.label42,
            this.label43,
            this.label44,
            this.textBox34,
            this.label45,
            this.textBox35,
            this.label46,
            this.textBox36,
            this.label47,
            this.label48,
            this.textBox37,
            this.label49,
            this.label50,
            this.textBox38,
            this.label51,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.label67});
            this.BLGroupFooter.Height = 0.7395833F;
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
            this.line8.Width = 10.88F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.88F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // gr_mMonth01
            // 
            this.gr_mMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth01.DataField = "SalesMoney1";
            this.gr_mMonth01.Height = 0.16F;
            this.gr_mMonth01.Left = 1.9375F;
            this.gr_mMonth01.MultiLine = false;
            this.gr_mMonth01.Name = "gr_mMonth01";
            this.gr_mMonth01.OutputFormat = resources.GetString("gr_mMonth01.OutputFormat");
            this.gr_mMonth01.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth01.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth01.Top = 0F;
            this.gr_mMonth01.Width = 0.65F;
            // 
            // gr_mMonth04
            // 
            this.gr_mMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth04.DataField = "SalesMoney4";
            this.gr_mMonth04.Height = 0.16F;
            this.gr_mMonth04.Left = 4.1875F;
            this.gr_mMonth04.MultiLine = false;
            this.gr_mMonth04.Name = "gr_mMonth04";
            this.gr_mMonth04.OutputFormat = resources.GetString("gr_mMonth04.OutputFormat");
            this.gr_mMonth04.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth04.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth04.Top = 0F;
            this.gr_mMonth04.Width = 0.65F;
            // 
            // gr_mMonth03
            // 
            this.gr_mMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth03.DataField = "SalesMoney3";
            this.gr_mMonth03.Height = 0.16F;
            this.gr_mMonth03.Left = 3.4375F;
            this.gr_mMonth03.MultiLine = false;
            this.gr_mMonth03.Name = "gr_mMonth03";
            this.gr_mMonth03.OutputFormat = resources.GetString("gr_mMonth03.OutputFormat");
            this.gr_mMonth03.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth03.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth03.Top = 0F;
            this.gr_mMonth03.Width = 0.65F;
            // 
            // gr_mMonth02
            // 
            this.gr_mMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth02.DataField = "SalesMoney2";
            this.gr_mMonth02.Height = 0.16F;
            this.gr_mMonth02.Left = 2.6875F;
            this.gr_mMonth02.MultiLine = false;
            this.gr_mMonth02.Name = "gr_mMonth02";
            this.gr_mMonth02.OutputFormat = resources.GetString("gr_mMonth02.OutputFormat");
            this.gr_mMonth02.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth02.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth02.Top = 0F;
            this.gr_mMonth02.Width = 0.65F;
            // 
            // gr_mMonth07
            // 
            this.gr_mMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth07.DataField = "SalesMoney7";
            this.gr_mMonth07.Height = 0.16F;
            this.gr_mMonth07.Left = 6.4375F;
            this.gr_mMonth07.MultiLine = false;
            this.gr_mMonth07.Name = "gr_mMonth07";
            this.gr_mMonth07.OutputFormat = resources.GetString("gr_mMonth07.OutputFormat");
            this.gr_mMonth07.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth07.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth07.Top = 0F;
            this.gr_mMonth07.Width = 0.65F;
            // 
            // gr_mMonth06
            // 
            this.gr_mMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth06.DataField = "SalesMoney6";
            this.gr_mMonth06.Height = 0.16F;
            this.gr_mMonth06.Left = 5.6875F;
            this.gr_mMonth06.MultiLine = false;
            this.gr_mMonth06.Name = "gr_mMonth06";
            this.gr_mMonth06.OutputFormat = resources.GetString("gr_mMonth06.OutputFormat");
            this.gr_mMonth06.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth06.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth06.Top = 0F;
            this.gr_mMonth06.Width = 0.65F;
            // 
            // gr_mMonth05
            // 
            this.gr_mMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth05.DataField = "SalesMoney5";
            this.gr_mMonth05.Height = 0.16F;
            this.gr_mMonth05.Left = 4.9375F;
            this.gr_mMonth05.MultiLine = false;
            this.gr_mMonth05.Name = "gr_mMonth05";
            this.gr_mMonth05.OutputFormat = resources.GetString("gr_mMonth05.OutputFormat");
            this.gr_mMonth05.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth05.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth05.Top = 0F;
            this.gr_mMonth05.Width = 0.65F;
            // 
            // gr_mMonth10
            // 
            this.gr_mMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth10.DataField = "SalesMoney10";
            this.gr_mMonth10.Height = 0.16F;
            this.gr_mMonth10.Left = 8.6875F;
            this.gr_mMonth10.MultiLine = false;
            this.gr_mMonth10.Name = "gr_mMonth10";
            this.gr_mMonth10.OutputFormat = resources.GetString("gr_mMonth10.OutputFormat");
            this.gr_mMonth10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth10.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth10.Top = 0F;
            this.gr_mMonth10.Width = 0.65F;
            // 
            // gr_mMonth09
            // 
            this.gr_mMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth09.DataField = "SalesMoney9";
            this.gr_mMonth09.Height = 0.16F;
            this.gr_mMonth09.Left = 7.9375F;
            this.gr_mMonth09.MultiLine = false;
            this.gr_mMonth09.Name = "gr_mMonth09";
            this.gr_mMonth09.OutputFormat = resources.GetString("gr_mMonth09.OutputFormat");
            this.gr_mMonth09.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth09.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth09.Top = 0F;
            this.gr_mMonth09.Width = 0.65F;
            // 
            // gr_mMonth08
            // 
            this.gr_mMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth08.DataField = "SalesMoney8";
            this.gr_mMonth08.Height = 0.16F;
            this.gr_mMonth08.Left = 7.1875F;
            this.gr_mMonth08.MultiLine = false;
            this.gr_mMonth08.Name = "gr_mMonth08";
            this.gr_mMonth08.OutputFormat = resources.GetString("gr_mMonth08.OutputFormat");
            this.gr_mMonth08.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth08.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth08.Top = 0F;
            this.gr_mMonth08.Width = 0.65F;
            // 
            // gr_mMonth12
            // 
            this.gr_mMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth12.DataField = "SalesMoney12";
            this.gr_mMonth12.Height = 0.16F;
            this.gr_mMonth12.Left = 10.1875F;
            this.gr_mMonth12.MultiLine = false;
            this.gr_mMonth12.Name = "gr_mMonth12";
            this.gr_mMonth12.OutputFormat = resources.GetString("gr_mMonth12.OutputFormat");
            this.gr_mMonth12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth12.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth12.Top = 0F;
            this.gr_mMonth12.Width = 0.65F;
            // 
            // gr_mMonth11
            // 
            this.gr_mMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_mMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_mMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.gr_mMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.gr_mMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_mMonth11.DataField = "SalesMoney11";
            this.gr_mMonth11.Height = 0.16F;
            this.gr_mMonth11.Left = 9.4375F;
            this.gr_mMonth11.MultiLine = false;
            this.gr_mMonth11.Name = "gr_mMonth11";
            this.gr_mMonth11.OutputFormat = resources.GetString("gr_mMonth11.OutputFormat");
            this.gr_mMonth11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_mMonth11.SummaryGroup = "BLGroupHeader";
            this.gr_mMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_mMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_mMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_mMonth11.Top = 0F;
            this.gr_mMonth11.Width = 0.65F;
            // 
            // gr_cMonth05
            // 
            this.gr_cMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth05.DataField = "TotalSalesCount5";
            this.gr_cMonth05.Height = 0.16F;
            this.gr_cMonth05.Left = 4.9375F;
            this.gr_cMonth05.MultiLine = false;
            this.gr_cMonth05.Name = "gr_cMonth05";
            this.gr_cMonth05.OutputFormat = resources.GetString("gr_cMonth05.OutputFormat");
            this.gr_cMonth05.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth05.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth05.Top = 0.15625F;
            this.gr_cMonth05.Width = 0.65F;
            // 
            // gr_cMonth06
            // 
            this.gr_cMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth06.DataField = "TotalSalesCount6";
            this.gr_cMonth06.Height = 0.16F;
            this.gr_cMonth06.Left = 5.6875F;
            this.gr_cMonth06.MultiLine = false;
            this.gr_cMonth06.Name = "gr_cMonth06";
            this.gr_cMonth06.OutputFormat = resources.GetString("gr_cMonth06.OutputFormat");
            this.gr_cMonth06.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth06.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth06.Top = 0.15625F;
            this.gr_cMonth06.Width = 0.65F;
            // 
            // gr_cMonth07
            // 
            this.gr_cMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth07.DataField = "TotalSalesCount7";
            this.gr_cMonth07.Height = 0.16F;
            this.gr_cMonth07.Left = 6.4375F;
            this.gr_cMonth07.MultiLine = false;
            this.gr_cMonth07.Name = "gr_cMonth07";
            this.gr_cMonth07.OutputFormat = resources.GetString("gr_cMonth07.OutputFormat");
            this.gr_cMonth07.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth07.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth07.Top = 0.15625F;
            this.gr_cMonth07.Width = 0.65F;
            // 
            // gr_cMonth08
            // 
            this.gr_cMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth08.DataField = "TotalSalesCount8";
            this.gr_cMonth08.Height = 0.16F;
            this.gr_cMonth08.Left = 7.1875F;
            this.gr_cMonth08.MultiLine = false;
            this.gr_cMonth08.Name = "gr_cMonth08";
            this.gr_cMonth08.OutputFormat = resources.GetString("gr_cMonth08.OutputFormat");
            this.gr_cMonth08.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth08.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth08.Top = 0.15625F;
            this.gr_cMonth08.Width = 0.65F;
            // 
            // gr_cMonth09
            // 
            this.gr_cMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth09.DataField = "TotalSalesCount9";
            this.gr_cMonth09.Height = 0.16F;
            this.gr_cMonth09.Left = 7.9375F;
            this.gr_cMonth09.MultiLine = false;
            this.gr_cMonth09.Name = "gr_cMonth09";
            this.gr_cMonth09.OutputFormat = resources.GetString("gr_cMonth09.OutputFormat");
            this.gr_cMonth09.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth09.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth09.Top = 0.15625F;
            this.gr_cMonth09.Width = 0.65F;
            // 
            // gr_cMonth10
            // 
            this.gr_cMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth10.DataField = "TotalSalesCount10";
            this.gr_cMonth10.Height = 0.16F;
            this.gr_cMonth10.Left = 8.6875F;
            this.gr_cMonth10.MultiLine = false;
            this.gr_cMonth10.Name = "gr_cMonth10";
            this.gr_cMonth10.OutputFormat = resources.GetString("gr_cMonth10.OutputFormat");
            this.gr_cMonth10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth10.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth10.Top = 0.15625F;
            this.gr_cMonth10.Width = 0.65F;
            // 
            // gr_cMonth11
            // 
            this.gr_cMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth11.DataField = "TotalSalesCount11";
            this.gr_cMonth11.Height = 0.16F;
            this.gr_cMonth11.Left = 9.4375F;
            this.gr_cMonth11.MultiLine = false;
            this.gr_cMonth11.Name = "gr_cMonth11";
            this.gr_cMonth11.OutputFormat = resources.GetString("gr_cMonth11.OutputFormat");
            this.gr_cMonth11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth11.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth11.Top = 0.15625F;
            this.gr_cMonth11.Width = 0.65F;
            // 
            // gr_cMonth12
            // 
            this.gr_cMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth12.DataField = "TotalSalesCount12";
            this.gr_cMonth12.Height = 0.16F;
            this.gr_cMonth12.Left = 10.1875F;
            this.gr_cMonth12.MultiLine = false;
            this.gr_cMonth12.Name = "gr_cMonth12";
            this.gr_cMonth12.OutputFormat = resources.GetString("gr_cMonth12.OutputFormat");
            this.gr_cMonth12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth12.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth12.Top = 0.15625F;
            this.gr_cMonth12.Width = 0.65F;
            // 
            // gr_cMonth01
            // 
            this.gr_cMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth01.DataField = "TotalSalesCount1";
            this.gr_cMonth01.Height = 0.16F;
            this.gr_cMonth01.Left = 1.9375F;
            this.gr_cMonth01.MultiLine = false;
            this.gr_cMonth01.Name = "gr_cMonth01";
            this.gr_cMonth01.OutputFormat = resources.GetString("gr_cMonth01.OutputFormat");
            this.gr_cMonth01.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth01.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth01.Top = 0.15625F;
            this.gr_cMonth01.Width = 0.65F;
            // 
            // gr_cMonth02
            // 
            this.gr_cMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth02.DataField = "TotalSalesCount2";
            this.gr_cMonth02.Height = 0.16F;
            this.gr_cMonth02.Left = 2.6875F;
            this.gr_cMonth02.MultiLine = false;
            this.gr_cMonth02.Name = "gr_cMonth02";
            this.gr_cMonth02.OutputFormat = resources.GetString("gr_cMonth02.OutputFormat");
            this.gr_cMonth02.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth02.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth02.Top = 0.15625F;
            this.gr_cMonth02.Width = 0.65F;
            // 
            // gr_cMonth03
            // 
            this.gr_cMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth03.DataField = "TotalSalesCount3";
            this.gr_cMonth03.Height = 0.16F;
            this.gr_cMonth03.Left = 3.4375F;
            this.gr_cMonth03.MultiLine = false;
            this.gr_cMonth03.Name = "gr_cMonth03";
            this.gr_cMonth03.OutputFormat = resources.GetString("gr_cMonth03.OutputFormat");
            this.gr_cMonth03.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth03.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth03.Top = 0.15625F;
            this.gr_cMonth03.Width = 0.65F;
            // 
            // gr_cMonth04
            // 
            this.gr_cMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_cMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_cMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.gr_cMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.gr_cMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_cMonth04.DataField = "TotalSalesCount4";
            this.gr_cMonth04.Height = 0.16F;
            this.gr_cMonth04.Left = 4.1875F;
            this.gr_cMonth04.MultiLine = false;
            this.gr_cMonth04.Name = "gr_cMonth04";
            this.gr_cMonth04.OutputFormat = resources.GetString("gr_cMonth04.OutputFormat");
            this.gr_cMonth04.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_cMonth04.SummaryGroup = "BLGroupHeader";
            this.gr_cMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_cMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_cMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_cMonth04.Top = 0.15625F;
            this.gr_cMonth04.Width = 0.65F;
            // 
            // gr_pMonth01
            // 
            this.gr_pMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth01.DataField = "GrossProfit1";
            this.gr_pMonth01.Height = 0.16F;
            this.gr_pMonth01.Left = 1.9375F;
            this.gr_pMonth01.MultiLine = false;
            this.gr_pMonth01.Name = "gr_pMonth01";
            this.gr_pMonth01.OutputFormat = resources.GetString("gr_pMonth01.OutputFormat");
            this.gr_pMonth01.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth01.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth01.Top = 0.3125F;
            this.gr_pMonth01.Width = 0.65F;
            // 
            // gr_pMonth02
            // 
            this.gr_pMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth02.DataField = "GrossProfit2";
            this.gr_pMonth02.Height = 0.16F;
            this.gr_pMonth02.Left = 2.6875F;
            this.gr_pMonth02.MultiLine = false;
            this.gr_pMonth02.Name = "gr_pMonth02";
            this.gr_pMonth02.OutputFormat = resources.GetString("gr_pMonth02.OutputFormat");
            this.gr_pMonth02.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth02.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth02.Top = 0.3125F;
            this.gr_pMonth02.Width = 0.65F;
            // 
            // gr_pMonth03
            // 
            this.gr_pMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth03.DataField = "GrossProfit3";
            this.gr_pMonth03.Height = 0.16F;
            this.gr_pMonth03.Left = 3.4375F;
            this.gr_pMonth03.MultiLine = false;
            this.gr_pMonth03.Name = "gr_pMonth03";
            this.gr_pMonth03.OutputFormat = resources.GetString("gr_pMonth03.OutputFormat");
            this.gr_pMonth03.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth03.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth03.Top = 0.3125F;
            this.gr_pMonth03.Width = 0.65F;
            // 
            // gr_pMonth04
            // 
            this.gr_pMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth04.DataField = "GrossProfit4";
            this.gr_pMonth04.Height = 0.16F;
            this.gr_pMonth04.Left = 4.1875F;
            this.gr_pMonth04.MultiLine = false;
            this.gr_pMonth04.Name = "gr_pMonth04";
            this.gr_pMonth04.OutputFormat = resources.GetString("gr_pMonth04.OutputFormat");
            this.gr_pMonth04.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth04.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth04.Top = 0.3125F;
            this.gr_pMonth04.Width = 0.65F;
            // 
            // gr_pMonth05
            // 
            this.gr_pMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth05.DataField = "GrossProfit5";
            this.gr_pMonth05.Height = 0.16F;
            this.gr_pMonth05.Left = 4.9375F;
            this.gr_pMonth05.MultiLine = false;
            this.gr_pMonth05.Name = "gr_pMonth05";
            this.gr_pMonth05.OutputFormat = resources.GetString("gr_pMonth05.OutputFormat");
            this.gr_pMonth05.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth05.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth05.Top = 0.3125F;
            this.gr_pMonth05.Width = 0.65F;
            // 
            // gr_pMonth06
            // 
            this.gr_pMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth06.DataField = "GrossProfit6";
            this.gr_pMonth06.Height = 0.16F;
            this.gr_pMonth06.Left = 5.6875F;
            this.gr_pMonth06.MultiLine = false;
            this.gr_pMonth06.Name = "gr_pMonth06";
            this.gr_pMonth06.OutputFormat = resources.GetString("gr_pMonth06.OutputFormat");
            this.gr_pMonth06.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth06.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth06.Top = 0.3125F;
            this.gr_pMonth06.Width = 0.65F;
            // 
            // gr_pMonth07
            // 
            this.gr_pMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth07.DataField = "GrossProfit7";
            this.gr_pMonth07.Height = 0.16F;
            this.gr_pMonth07.Left = 6.4375F;
            this.gr_pMonth07.MultiLine = false;
            this.gr_pMonth07.Name = "gr_pMonth07";
            this.gr_pMonth07.OutputFormat = resources.GetString("gr_pMonth07.OutputFormat");
            this.gr_pMonth07.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth07.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth07.Top = 0.3125F;
            this.gr_pMonth07.Width = 0.65F;
            // 
            // gr_pMonth08
            // 
            this.gr_pMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth08.DataField = "GrossProfit8";
            this.gr_pMonth08.Height = 0.16F;
            this.gr_pMonth08.Left = 7.1875F;
            this.gr_pMonth08.MultiLine = false;
            this.gr_pMonth08.Name = "gr_pMonth08";
            this.gr_pMonth08.OutputFormat = resources.GetString("gr_pMonth08.OutputFormat");
            this.gr_pMonth08.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth08.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth08.Top = 0.3125F;
            this.gr_pMonth08.Width = 0.65F;
            // 
            // gr_pMonth09
            // 
            this.gr_pMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth09.DataField = "GrossProfit9";
            this.gr_pMonth09.Height = 0.16F;
            this.gr_pMonth09.Left = 7.9375F;
            this.gr_pMonth09.MultiLine = false;
            this.gr_pMonth09.Name = "gr_pMonth09";
            this.gr_pMonth09.OutputFormat = resources.GetString("gr_pMonth09.OutputFormat");
            this.gr_pMonth09.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth09.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth09.Top = 0.3125F;
            this.gr_pMonth09.Width = 0.65F;
            // 
            // gr_pMonth10
            // 
            this.gr_pMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth10.DataField = "GrossProfit10";
            this.gr_pMonth10.Height = 0.16F;
            this.gr_pMonth10.Left = 8.6875F;
            this.gr_pMonth10.MultiLine = false;
            this.gr_pMonth10.Name = "gr_pMonth10";
            this.gr_pMonth10.OutputFormat = resources.GetString("gr_pMonth10.OutputFormat");
            this.gr_pMonth10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth10.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth10.Top = 0.3125F;
            this.gr_pMonth10.Width = 0.65F;
            // 
            // gr_pMonth11
            // 
            this.gr_pMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth11.DataField = "GrossProfit11";
            this.gr_pMonth11.Height = 0.16F;
            this.gr_pMonth11.Left = 9.4375F;
            this.gr_pMonth11.MultiLine = false;
            this.gr_pMonth11.Name = "gr_pMonth11";
            this.gr_pMonth11.OutputFormat = resources.GetString("gr_pMonth11.OutputFormat");
            this.gr_pMonth11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth11.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth11.Top = 0.3125F;
            this.gr_pMonth11.Width = 0.65F;
            // 
            // gr_pMonth12
            // 
            this.gr_pMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_pMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_pMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.gr_pMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.gr_pMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_pMonth12.DataField = "GrossProfit12";
            this.gr_pMonth12.Height = 0.16F;
            this.gr_pMonth12.Left = 10.1875F;
            this.gr_pMonth12.MultiLine = false;
            this.gr_pMonth12.Name = "gr_pMonth12";
            this.gr_pMonth12.OutputFormat = resources.GetString("gr_pMonth12.OutputFormat");
            this.gr_pMonth12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_pMonth12.SummaryGroup = "BLGroupHeader";
            this.gr_pMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_pMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_pMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.gr_pMonth12.Top = 0.3125F;
            this.gr_pMonth12.Width = 0.65F;
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
            this.label6.Left = 0.9375F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "ｸﾞﾙｰﾌﾟ計";
            this.label6.Top = 0F;
            this.label6.Width = 0.7F;
            // 
            // label41
            // 
            this.label41.Border.BottomColor = System.Drawing.Color.Black;
            this.label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.LeftColor = System.Drawing.Color.Black;
            this.label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.RightColor = System.Drawing.Color.Black;
            this.label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.TopColor = System.Drawing.Color.Black;
            this.label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Height = 0.16F;
            this.label41.HyperLink = "";
            this.label41.Left = 0F;
            this.label41.MultiLine = false;
            this.label41.Name = "label41";
            this.label41.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label41.Text = "ｸﾞﾙｰﾌﾟ計";
            this.label41.Top = 0.5625F;
            this.label41.Visible = false;
            this.label41.Width = 0.5F;
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
            this.textBox32.DataField = "TermSalesMoney";
            this.textBox32.Height = 0.16F;
            this.textBox32.Left = 1.01F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox32.SummaryGroup = "BLGroupHeader";
            this.textBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox32.Text = "ZZZZ,ZZZ,ZZ91";
            this.textBox32.Top = 0.563F;
            this.textBox32.Visible = false;
            this.textBox32.Width = 0.7F;
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
            this.textBox33.DataField = "TermSalesTarget1";
            this.textBox33.Height = 0.16F;
            this.textBox33.Left = 2.0625F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox33.SummaryGroup = "BLGroupHeader";
            this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox33.Text = "ZZZZ,ZZZ,ZZ9";
            this.textBox33.Top = 0.563F;
            this.textBox33.Visible = false;
            this.textBox33.Width = 0.7F;
            // 
            // label42
            // 
            this.label42.Border.BottomColor = System.Drawing.Color.Black;
            this.label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.LeftColor = System.Drawing.Color.Black;
            this.label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.RightColor = System.Drawing.Color.Black;
            this.label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.TopColor = System.Drawing.Color.Black;
            this.label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Height = 0.16F;
            this.label42.HyperLink = "";
            this.label42.Left = 6.676667F;
            this.label42.MultiLine = false;
            this.label42.Name = "label42";
            this.label42.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label42.Text = "]粗利額[";
            this.label42.Top = 0.563F;
            this.label42.Visible = false;
            this.label42.Width = 0.48F;
            // 
            // label43
            // 
            this.label43.Border.BottomColor = System.Drawing.Color.Black;
            this.label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Border.LeftColor = System.Drawing.Color.Black;
            this.label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Border.RightColor = System.Drawing.Color.Black;
            this.label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Border.TopColor = System.Drawing.Color.Black;
            this.label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Height = 0.16F;
            this.label43.HyperLink = "";
            this.label43.Left = 1.687083F;
            this.label43.MultiLine = false;
            this.label43.Name = "label43";
            this.label43.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label43.Text = "]目標[";
            this.label43.Top = 0.563F;
            this.label43.Visible = false;
            this.label43.Width = 0.38F;
            // 
            // label44
            // 
            this.label44.Border.BottomColor = System.Drawing.Color.Black;
            this.label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Border.LeftColor = System.Drawing.Color.Black;
            this.label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Border.RightColor = System.Drawing.Color.Black;
            this.label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Border.TopColor = System.Drawing.Color.Black;
            this.label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Height = 0.16F;
            this.label44.HyperLink = "";
            this.label44.Left = 2.72875F;
            this.label44.MultiLine = false;
            this.label44.Name = "label44";
            this.label44.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label44.Text = "]達成率[";
            this.label44.Top = 0.563F;
            this.label44.Visible = false;
            this.label44.Width = 0.48F;
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
            this.textBox34.Left = 3.16625F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox34.Text = "ZZZ9.991";
            this.textBox34.Top = 0.563F;
            this.textBox34.Visible = false;
            this.textBox34.Width = 0.45F;
            // 
            // label45
            // 
            this.label45.Border.BottomColor = System.Drawing.Color.Black;
            this.label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Border.LeftColor = System.Drawing.Color.Black;
            this.label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Border.RightColor = System.Drawing.Color.Black;
            this.label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Border.TopColor = System.Drawing.Color.Black;
            this.label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Height = 0.16F;
            this.label45.HyperLink = "";
            this.label45.Left = 3.614166F;
            this.label45.MultiLine = false;
            this.label45.Name = "label45";
            this.label45.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label45.Text = "]売上数[";
            this.label45.Top = 0.563F;
            this.label45.Visible = false;
            this.label45.Width = 0.48F;
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
            this.textBox35.DataField = "TermSalesCount";
            this.textBox35.Height = 0.16F;
            this.textBox35.Left = 4.094166F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox35.SummaryGroup = "BLGroupHeader";
            this.textBox35.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox35.Text = "ZZZ,ZZZ,ZZ91";
            this.textBox35.Top = 0.563F;
            this.textBox35.Visible = false;
            this.textBox35.Width = 0.65F;
            // 
            // label46
            // 
            this.label46.Border.BottomColor = System.Drawing.Color.Black;
            this.label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.LeftColor = System.Drawing.Color.Black;
            this.label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.RightColor = System.Drawing.Color.Black;
            this.label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.TopColor = System.Drawing.Color.Black;
            this.label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Height = 0.16F;
            this.label46.HyperLink = "";
            this.label46.Left = 4.718833F;
            this.label46.MultiLine = false;
            this.label46.Name = "label46";
            this.label46.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label46.Text = "]目標[";
            this.label46.Top = 0.563F;
            this.label46.Visible = false;
            this.label46.Width = 0.37F;
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
            this.textBox36.DataField = "TermSalesTargetCount1";
            this.textBox36.Height = 0.16F;
            this.textBox36.Left = 5.083416F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox36.SummaryGroup = "BLGroupHeader";
            this.textBox36.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox36.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox36.Top = 0.563F;
            this.textBox36.Visible = false;
            this.textBox36.Width = 0.65F;
            // 
            // label47
            // 
            this.label47.Border.BottomColor = System.Drawing.Color.Black;
            this.label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Border.LeftColor = System.Drawing.Color.Black;
            this.label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Border.RightColor = System.Drawing.Color.Black;
            this.label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Border.TopColor = System.Drawing.Color.Black;
            this.label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Height = 0.16F;
            this.label47.HyperLink = "";
            this.label47.Left = 5.708084F;
            this.label47.MultiLine = false;
            this.label47.Name = "label47";
            this.label47.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label47.Text = "]達成率[";
            this.label47.Top = 0.563F;
            this.label47.Visible = false;
            this.label47.Width = 0.48F;
            // 
            // label48
            // 
            this.label48.Border.BottomColor = System.Drawing.Color.Black;
            this.label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.LeftColor = System.Drawing.Color.Black;
            this.label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.RightColor = System.Drawing.Color.Black;
            this.label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.TopColor = System.Drawing.Color.Black;
            this.label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Height = 0.16F;
            this.label48.HyperLink = "";
            this.label48.Left = 0.625F;
            this.label48.MultiLine = false;
            this.label48.Name = "label48";
            this.label48.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label48.Text = "売上額[";
            this.label48.Top = 0.563F;
            this.label48.Visible = false;
            this.label48.Width = 0.42F;
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
            this.textBox37.DataField = "TermSalesProfit";
            this.textBox37.Height = 0.16F;
            this.textBox37.Left = 7.156666F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox37.SummaryGroup = "BLGroupHeader";
            this.textBox37.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox37.Text = "ZZZZ,ZZZ,ZZ9";
            this.textBox37.Top = 0.563F;
            this.textBox37.Visible = false;
            this.textBox37.Width = 0.7F;
            // 
            // label49
            // 
            this.label49.Border.BottomColor = System.Drawing.Color.Black;
            this.label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Border.LeftColor = System.Drawing.Color.Black;
            this.label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Border.RightColor = System.Drawing.Color.Black;
            this.label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Border.TopColor = System.Drawing.Color.Black;
            this.label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Height = 0.16F;
            this.label49.HyperLink = "";
            this.label49.Left = 7.83375F;
            this.label49.MultiLine = false;
            this.label49.Name = "label49";
            this.label49.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label49.Text = "]粗利率[";
            this.label49.Top = 0.563F;
            this.label49.Visible = false;
            this.label49.Width = 0.48F;
            // 
            // label50
            // 
            this.label50.Border.BottomColor = System.Drawing.Color.Black;
            this.label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.LeftColor = System.Drawing.Color.Black;
            this.label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.RightColor = System.Drawing.Color.Black;
            this.label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.TopColor = System.Drawing.Color.Black;
            this.label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Height = 0.16F;
            this.label50.HyperLink = "";
            this.label50.Left = 8.802333F;
            this.label50.MultiLine = false;
            this.label50.Name = "label50";
            this.label50.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label50.Text = "]目標[";
            this.label50.Top = 0.563F;
            this.label50.Visible = false;
            this.label50.Width = 0.37F;
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
            this.textBox38.DataField = "TermSalesTargetProfit1";
            this.textBox38.Height = 0.16F;
            this.textBox38.Left = 9.177333F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox38.SummaryGroup = "BLGroupHeader";
            this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox38.Text = "ZZZ,ZZZ,ZZ9]";
            this.textBox38.Top = 0.563F;
            this.textBox38.Visible = false;
            this.textBox38.Width = 0.7F;
            // 
            // label51
            // 
            this.label51.Border.BottomColor = System.Drawing.Color.Black;
            this.label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.LeftColor = System.Drawing.Color.Black;
            this.label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.RightColor = System.Drawing.Color.Black;
            this.label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.TopColor = System.Drawing.Color.Black;
            this.label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Height = 0.16F;
            this.label51.HyperLink = "";
            this.label51.Left = 9.843666F;
            this.label51.MultiLine = false;
            this.label51.Name = "label51";
            this.label51.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label51.Text = "]達成率[";
            this.label51.Top = 0.563F;
            this.label51.Visible = false;
            this.label51.Width = 0.48F;
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
            this.textBox39.Height = 0.16F;
            this.textBox39.Left = 6.24F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox39.Text = "ZZZ9.99";
            this.textBox39.Top = 0.563F;
            this.textBox39.Visible = false;
            this.textBox39.Width = 0.45F;
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
            this.textBox40.Height = 0.16F;
            this.textBox40.Left = 8.32F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.Text = "ZZZ9.99]";
            this.textBox40.Top = 0.563F;
            this.textBox40.Visible = false;
            this.textBox40.Width = 0.5F;
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
            this.textBox41.Height = 0.16F;
            this.textBox41.Left = 10.29F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox41.Text = "ZZZ9.99]";
            this.textBox41.Top = 0.563F;
            this.textBox41.Visible = false;
            this.textBox41.Width = 0.5F;
            // 
            // label67
            // 
            this.label67.Border.BottomColor = System.Drawing.Color.Black;
            this.label67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label67.Border.LeftColor = System.Drawing.Color.Black;
            this.label67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label67.Border.RightColor = System.Drawing.Color.Black;
            this.label67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label67.Border.TopColor = System.Drawing.Color.Black;
            this.label67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label67.Height = 0.16F;
            this.label67.HyperLink = "";
            this.label67.Left = 10.781F;
            this.label67.MultiLine = false;
            this.label67.Name = "label67";
            this.label67.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label67.Text = "]";
            this.label67.Top = 0.563F;
            this.label67.Visible = false;
            this.label67.Width = 0.05F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label68,
            this.textBox69,
            this.textBox70,
            this.line13,
            this.line14});
            this.CustomerHeader.DataField = "CustomerCode";
            this.CustomerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.CustomerHeader.Height = 0.1875F;
            this.CustomerHeader.KeepTogether = true;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.CustomerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // label68
            // 
            this.label68.Border.BottomColor = System.Drawing.Color.Black;
            this.label68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label68.Border.LeftColor = System.Drawing.Color.Black;
            this.label68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label68.Border.RightColor = System.Drawing.Color.Black;
            this.label68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label68.Border.TopColor = System.Drawing.Color.Black;
            this.label68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label68.Height = 0.16F;
            this.label68.HyperLink = "";
            this.label68.Left = 0F;
            this.label68.MultiLine = false;
            this.label68.Name = "label68";
            this.label68.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.label68.Text = "得意先";
            this.label68.Top = 0F;
            this.label68.Visible = false;
            this.label68.Width = 0.438F;
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
            this.textBox69.DataField = "CustomerCode";
            this.textBox69.Height = 0.16F;
            this.textBox69.Left = 0.4375F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.textBox69.Text = "12345678";
            this.textBox69.Top = 0F;
            this.textBox69.Visible = false;
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
            this.textBox70.DataField = "CustomerSnm";
            this.textBox70.Height = 0.16F;
            this.textBox70.Left = 0.95F;
            this.textBox70.MultiLine = false;
            this.textBox70.Name = "textBox70";
            this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
            this.textBox70.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.textBox70.Text = "あいうえおかきくけこ";
            this.textBox70.Top = 0F;
            this.textBox70.Visible = false;
            this.textBox70.Width = 1.2F;
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
            this.line13.LineWeight = 2F;
            this.line13.Name = "line13";
            this.line13.Top = 0F;
            this.line13.Width = 10.88F;
            this.line13.X1 = 0F;
            this.line13.X2 = 10.88F;
            this.line13.Y1 = 0F;
            this.line13.Y2 = 0F;
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
            this.line14.Width = 10.875F;
            this.line14.X1 = 0F;
            this.line14.X2 = 10.875F;
            this.line14.Y1 = 0.16F;
            this.line14.Y2 = 0.16F;
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.cu_mMonth01,
            this.cu_mMonth04,
            this.cu_mMonth03,
            this.cu_mMonth02,
            this.cu_mMonth07,
            this.cu_mMonth06,
            this.cu_mMonth05,
            this.cu_mMonth10,
            this.cu_mMonth09,
            this.cu_mMonth08,
            this.cu_mMonth12,
            this.cu_mMonth11,
            this.cu_cMonth05,
            this.cu_cMonth06,
            this.cu_cMonth07,
            this.cu_cMonth08,
            this.cu_cMonth09,
            this.cu_cMonth10,
            this.cu_cMonth11,
            this.cu_cMonth12,
            this.cu_cMonth01,
            this.cu_cMonth02,
            this.cu_cMonth03,
            this.cu_cMonth04,
            this.cu_pMonth01,
            this.cu_pMonth02,
            this.cu_pMonth03,
            this.cu_pMonth04,
            this.cu_pMonth05,
            this.cu_pMonth06,
            this.cu_pMonth07,
            this.cu_pMonth08,
            this.cu_pMonth09,
            this.cu_pMonth10,
            this.cu_pMonth11,
            this.cu_pMonth12,
            this.label7});
            this.CustomerFooter.Height = 0.5F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
            this.CustomerFooter.Visible = false;
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
            this.line3.Width = 10.88F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.88F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // cu_mMonth01
            // 
            this.cu_mMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth01.DataField = "SalesMoney1";
            this.cu_mMonth01.Height = 0.16F;
            this.cu_mMonth01.Left = 1.9375F;
            this.cu_mMonth01.MultiLine = false;
            this.cu_mMonth01.Name = "cu_mMonth01";
            this.cu_mMonth01.OutputFormat = resources.GetString("cu_mMonth01.OutputFormat");
            this.cu_mMonth01.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth01.SummaryGroup = "CustomerHeader";
            this.cu_mMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth01.Top = 0F;
            this.cu_mMonth01.Width = 0.65F;
            // 
            // cu_mMonth04
            // 
            this.cu_mMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth04.DataField = "SalesMoney4";
            this.cu_mMonth04.Height = 0.16F;
            this.cu_mMonth04.Left = 4.1875F;
            this.cu_mMonth04.MultiLine = false;
            this.cu_mMonth04.Name = "cu_mMonth04";
            this.cu_mMonth04.OutputFormat = resources.GetString("cu_mMonth04.OutputFormat");
            this.cu_mMonth04.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth04.SummaryGroup = "CustomerHeader";
            this.cu_mMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth04.Top = 0F;
            this.cu_mMonth04.Width = 0.65F;
            // 
            // cu_mMonth03
            // 
            this.cu_mMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth03.DataField = "SalesMoney3";
            this.cu_mMonth03.Height = 0.16F;
            this.cu_mMonth03.Left = 3.4375F;
            this.cu_mMonth03.MultiLine = false;
            this.cu_mMonth03.Name = "cu_mMonth03";
            this.cu_mMonth03.OutputFormat = resources.GetString("cu_mMonth03.OutputFormat");
            this.cu_mMonth03.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth03.SummaryGroup = "CustomerHeader";
            this.cu_mMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth03.Top = 0F;
            this.cu_mMonth03.Width = 0.65F;
            // 
            // cu_mMonth02
            // 
            this.cu_mMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth02.DataField = "SalesMoney2";
            this.cu_mMonth02.Height = 0.16F;
            this.cu_mMonth02.Left = 2.6875F;
            this.cu_mMonth02.MultiLine = false;
            this.cu_mMonth02.Name = "cu_mMonth02";
            this.cu_mMonth02.OutputFormat = resources.GetString("cu_mMonth02.OutputFormat");
            this.cu_mMonth02.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth02.SummaryGroup = "CustomerHeader";
            this.cu_mMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth02.Top = 0F;
            this.cu_mMonth02.Width = 0.65F;
            // 
            // cu_mMonth07
            // 
            this.cu_mMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth07.DataField = "SalesMoney7";
            this.cu_mMonth07.Height = 0.16F;
            this.cu_mMonth07.Left = 6.4375F;
            this.cu_mMonth07.MultiLine = false;
            this.cu_mMonth07.Name = "cu_mMonth07";
            this.cu_mMonth07.OutputFormat = resources.GetString("cu_mMonth07.OutputFormat");
            this.cu_mMonth07.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth07.SummaryGroup = "CustomerHeader";
            this.cu_mMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth07.Top = 0F;
            this.cu_mMonth07.Width = 0.65F;
            // 
            // cu_mMonth06
            // 
            this.cu_mMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth06.DataField = "SalesMoney6";
            this.cu_mMonth06.Height = 0.16F;
            this.cu_mMonth06.Left = 5.6875F;
            this.cu_mMonth06.MultiLine = false;
            this.cu_mMonth06.Name = "cu_mMonth06";
            this.cu_mMonth06.OutputFormat = resources.GetString("cu_mMonth06.OutputFormat");
            this.cu_mMonth06.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth06.SummaryGroup = "CustomerHeader";
            this.cu_mMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth06.Top = 0F;
            this.cu_mMonth06.Width = 0.65F;
            // 
            // cu_mMonth05
            // 
            this.cu_mMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth05.DataField = "SalesMoney5";
            this.cu_mMonth05.Height = 0.16F;
            this.cu_mMonth05.Left = 4.9375F;
            this.cu_mMonth05.MultiLine = false;
            this.cu_mMonth05.Name = "cu_mMonth05";
            this.cu_mMonth05.OutputFormat = resources.GetString("cu_mMonth05.OutputFormat");
            this.cu_mMonth05.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth05.SummaryGroup = "CustomerHeader";
            this.cu_mMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth05.Top = 0F;
            this.cu_mMonth05.Width = 0.65F;
            // 
            // cu_mMonth10
            // 
            this.cu_mMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth10.DataField = "SalesMoney10";
            this.cu_mMonth10.Height = 0.16F;
            this.cu_mMonth10.Left = 8.6875F;
            this.cu_mMonth10.MultiLine = false;
            this.cu_mMonth10.Name = "cu_mMonth10";
            this.cu_mMonth10.OutputFormat = resources.GetString("cu_mMonth10.OutputFormat");
            this.cu_mMonth10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth10.SummaryGroup = "CustomerHeader";
            this.cu_mMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth10.Top = 0F;
            this.cu_mMonth10.Width = 0.65F;
            // 
            // cu_mMonth09
            // 
            this.cu_mMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth09.DataField = "SalesMoney9";
            this.cu_mMonth09.Height = 0.16F;
            this.cu_mMonth09.Left = 7.9375F;
            this.cu_mMonth09.MultiLine = false;
            this.cu_mMonth09.Name = "cu_mMonth09";
            this.cu_mMonth09.OutputFormat = resources.GetString("cu_mMonth09.OutputFormat");
            this.cu_mMonth09.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth09.SummaryGroup = "CustomerHeader";
            this.cu_mMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth09.Top = 0F;
            this.cu_mMonth09.Width = 0.65F;
            // 
            // cu_mMonth08
            // 
            this.cu_mMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth08.DataField = "SalesMoney8";
            this.cu_mMonth08.Height = 0.16F;
            this.cu_mMonth08.Left = 7.1875F;
            this.cu_mMonth08.MultiLine = false;
            this.cu_mMonth08.Name = "cu_mMonth08";
            this.cu_mMonth08.OutputFormat = resources.GetString("cu_mMonth08.OutputFormat");
            this.cu_mMonth08.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth08.SummaryGroup = "CustomerHeader";
            this.cu_mMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth08.Top = 0F;
            this.cu_mMonth08.Width = 0.65F;
            // 
            // cu_mMonth12
            // 
            this.cu_mMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth12.DataField = "SalesMoney12";
            this.cu_mMonth12.Height = 0.16F;
            this.cu_mMonth12.Left = 10.1875F;
            this.cu_mMonth12.MultiLine = false;
            this.cu_mMonth12.Name = "cu_mMonth12";
            this.cu_mMonth12.OutputFormat = resources.GetString("cu_mMonth12.OutputFormat");
            this.cu_mMonth12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth12.SummaryGroup = "CustomerHeader";
            this.cu_mMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth12.Top = 0F;
            this.cu_mMonth12.Width = 0.65F;
            // 
            // cu_mMonth11
            // 
            this.cu_mMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_mMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_mMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.cu_mMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.cu_mMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_mMonth11.DataField = "SalesMoney11";
            this.cu_mMonth11.Height = 0.16F;
            this.cu_mMonth11.Left = 9.4375F;
            this.cu_mMonth11.MultiLine = false;
            this.cu_mMonth11.Name = "cu_mMonth11";
            this.cu_mMonth11.OutputFormat = resources.GetString("cu_mMonth11.OutputFormat");
            this.cu_mMonth11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_mMonth11.SummaryGroup = "CustomerHeader";
            this.cu_mMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_mMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_mMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_mMonth11.Top = 0F;
            this.cu_mMonth11.Width = 0.65F;
            // 
            // cu_cMonth05
            // 
            this.cu_cMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth05.DataField = "TotalSalesCount5";
            this.cu_cMonth05.Height = 0.16F;
            this.cu_cMonth05.Left = 4.9375F;
            this.cu_cMonth05.MultiLine = false;
            this.cu_cMonth05.Name = "cu_cMonth05";
            this.cu_cMonth05.OutputFormat = resources.GetString("cu_cMonth05.OutputFormat");
            this.cu_cMonth05.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth05.SummaryGroup = "CustomerHeader";
            this.cu_cMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth05.Top = 0.15625F;
            this.cu_cMonth05.Width = 0.65F;
            // 
            // cu_cMonth06
            // 
            this.cu_cMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth06.DataField = "TotalSalesCount6";
            this.cu_cMonth06.Height = 0.16F;
            this.cu_cMonth06.Left = 5.6875F;
            this.cu_cMonth06.MultiLine = false;
            this.cu_cMonth06.Name = "cu_cMonth06";
            this.cu_cMonth06.OutputFormat = resources.GetString("cu_cMonth06.OutputFormat");
            this.cu_cMonth06.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth06.SummaryGroup = "CustomerHeader";
            this.cu_cMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth06.Top = 0.15625F;
            this.cu_cMonth06.Width = 0.65F;
            // 
            // cu_cMonth07
            // 
            this.cu_cMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth07.DataField = "TotalSalesCount7";
            this.cu_cMonth07.Height = 0.16F;
            this.cu_cMonth07.Left = 6.4375F;
            this.cu_cMonth07.MultiLine = false;
            this.cu_cMonth07.Name = "cu_cMonth07";
            this.cu_cMonth07.OutputFormat = resources.GetString("cu_cMonth07.OutputFormat");
            this.cu_cMonth07.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth07.SummaryGroup = "CustomerHeader";
            this.cu_cMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth07.Top = 0.15625F;
            this.cu_cMonth07.Width = 0.65F;
            // 
            // cu_cMonth08
            // 
            this.cu_cMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth08.DataField = "TotalSalesCount8";
            this.cu_cMonth08.Height = 0.16F;
            this.cu_cMonth08.Left = 7.1875F;
            this.cu_cMonth08.MultiLine = false;
            this.cu_cMonth08.Name = "cu_cMonth08";
            this.cu_cMonth08.OutputFormat = resources.GetString("cu_cMonth08.OutputFormat");
            this.cu_cMonth08.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth08.SummaryGroup = "CustomerHeader";
            this.cu_cMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth08.Top = 0.15625F;
            this.cu_cMonth08.Width = 0.65F;
            // 
            // cu_cMonth09
            // 
            this.cu_cMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth09.DataField = "TotalSalesCount9";
            this.cu_cMonth09.Height = 0.16F;
            this.cu_cMonth09.Left = 7.9375F;
            this.cu_cMonth09.MultiLine = false;
            this.cu_cMonth09.Name = "cu_cMonth09";
            this.cu_cMonth09.OutputFormat = resources.GetString("cu_cMonth09.OutputFormat");
            this.cu_cMonth09.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth09.SummaryGroup = "CustomerHeader";
            this.cu_cMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth09.Top = 0.15625F;
            this.cu_cMonth09.Width = 0.65F;
            // 
            // cu_cMonth10
            // 
            this.cu_cMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth10.DataField = "TotalSalesCount10";
            this.cu_cMonth10.Height = 0.16F;
            this.cu_cMonth10.Left = 8.6875F;
            this.cu_cMonth10.MultiLine = false;
            this.cu_cMonth10.Name = "cu_cMonth10";
            this.cu_cMonth10.OutputFormat = resources.GetString("cu_cMonth10.OutputFormat");
            this.cu_cMonth10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth10.SummaryGroup = "CustomerHeader";
            this.cu_cMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth10.Top = 0.15625F;
            this.cu_cMonth10.Width = 0.65F;
            // 
            // cu_cMonth11
            // 
            this.cu_cMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth11.DataField = "TotalSalesCount11";
            this.cu_cMonth11.Height = 0.16F;
            this.cu_cMonth11.Left = 9.4375F;
            this.cu_cMonth11.MultiLine = false;
            this.cu_cMonth11.Name = "cu_cMonth11";
            this.cu_cMonth11.OutputFormat = resources.GetString("cu_cMonth11.OutputFormat");
            this.cu_cMonth11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth11.SummaryGroup = "CustomerHeader";
            this.cu_cMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth11.Top = 0.15625F;
            this.cu_cMonth11.Width = 0.65F;
            // 
            // cu_cMonth12
            // 
            this.cu_cMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth12.DataField = "TotalSalesCount12";
            this.cu_cMonth12.Height = 0.16F;
            this.cu_cMonth12.Left = 10.1875F;
            this.cu_cMonth12.MultiLine = false;
            this.cu_cMonth12.Name = "cu_cMonth12";
            this.cu_cMonth12.OutputFormat = resources.GetString("cu_cMonth12.OutputFormat");
            this.cu_cMonth12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth12.SummaryGroup = "CustomerHeader";
            this.cu_cMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth12.Top = 0.15625F;
            this.cu_cMonth12.Width = 0.65F;
            // 
            // cu_cMonth01
            // 
            this.cu_cMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth01.DataField = "TotalSalesCount1";
            this.cu_cMonth01.Height = 0.16F;
            this.cu_cMonth01.Left = 1.9375F;
            this.cu_cMonth01.MultiLine = false;
            this.cu_cMonth01.Name = "cu_cMonth01";
            this.cu_cMonth01.OutputFormat = resources.GetString("cu_cMonth01.OutputFormat");
            this.cu_cMonth01.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth01.SummaryGroup = "CustomerHeader";
            this.cu_cMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth01.Top = 0.15625F;
            this.cu_cMonth01.Width = 0.65F;
            // 
            // cu_cMonth02
            // 
            this.cu_cMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth02.DataField = "TotalSalesCount2";
            this.cu_cMonth02.Height = 0.16F;
            this.cu_cMonth02.Left = 2.6875F;
            this.cu_cMonth02.MultiLine = false;
            this.cu_cMonth02.Name = "cu_cMonth02";
            this.cu_cMonth02.OutputFormat = resources.GetString("cu_cMonth02.OutputFormat");
            this.cu_cMonth02.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth02.SummaryGroup = "CustomerHeader";
            this.cu_cMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth02.Top = 0.15625F;
            this.cu_cMonth02.Width = 0.65F;
            // 
            // cu_cMonth03
            // 
            this.cu_cMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth03.DataField = "TotalSalesCount3";
            this.cu_cMonth03.Height = 0.16F;
            this.cu_cMonth03.Left = 3.4375F;
            this.cu_cMonth03.MultiLine = false;
            this.cu_cMonth03.Name = "cu_cMonth03";
            this.cu_cMonth03.OutputFormat = resources.GetString("cu_cMonth03.OutputFormat");
            this.cu_cMonth03.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth03.SummaryGroup = "CustomerHeader";
            this.cu_cMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth03.Top = 0.15625F;
            this.cu_cMonth03.Width = 0.65F;
            // 
            // cu_cMonth04
            // 
            this.cu_cMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_cMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_cMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.cu_cMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.cu_cMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_cMonth04.DataField = "TotalSalesCount4";
            this.cu_cMonth04.Height = 0.16F;
            this.cu_cMonth04.Left = 4.1875F;
            this.cu_cMonth04.MultiLine = false;
            this.cu_cMonth04.Name = "cu_cMonth04";
            this.cu_cMonth04.OutputFormat = resources.GetString("cu_cMonth04.OutputFormat");
            this.cu_cMonth04.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_cMonth04.SummaryGroup = "CustomerHeader";
            this.cu_cMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_cMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_cMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_cMonth04.Top = 0.15625F;
            this.cu_cMonth04.Width = 0.65F;
            // 
            // cu_pMonth01
            // 
            this.cu_pMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth01.DataField = "GrossProfit1";
            this.cu_pMonth01.Height = 0.16F;
            this.cu_pMonth01.Left = 1.9375F;
            this.cu_pMonth01.MultiLine = false;
            this.cu_pMonth01.Name = "cu_pMonth01";
            this.cu_pMonth01.OutputFormat = resources.GetString("cu_pMonth01.OutputFormat");
            this.cu_pMonth01.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth01.SummaryGroup = "CustomerHeader";
            this.cu_pMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth01.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth01.Top = 0.3125F;
            this.cu_pMonth01.Width = 0.65F;
            // 
            // cu_pMonth02
            // 
            this.cu_pMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth02.DataField = "GrossProfit2";
            this.cu_pMonth02.Height = 0.16F;
            this.cu_pMonth02.Left = 2.6875F;
            this.cu_pMonth02.MultiLine = false;
            this.cu_pMonth02.Name = "cu_pMonth02";
            this.cu_pMonth02.OutputFormat = resources.GetString("cu_pMonth02.OutputFormat");
            this.cu_pMonth02.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth02.SummaryGroup = "CustomerHeader";
            this.cu_pMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth02.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth02.Top = 0.3125F;
            this.cu_pMonth02.Width = 0.65F;
            // 
            // cu_pMonth03
            // 
            this.cu_pMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth03.DataField = "GrossProfit3";
            this.cu_pMonth03.Height = 0.16F;
            this.cu_pMonth03.Left = 3.4375F;
            this.cu_pMonth03.MultiLine = false;
            this.cu_pMonth03.Name = "cu_pMonth03";
            this.cu_pMonth03.OutputFormat = resources.GetString("cu_pMonth03.OutputFormat");
            this.cu_pMonth03.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth03.SummaryGroup = "CustomerHeader";
            this.cu_pMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth03.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth03.Top = 0.3125F;
            this.cu_pMonth03.Width = 0.65F;
            // 
            // cu_pMonth04
            // 
            this.cu_pMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth04.DataField = "GrossProfit4";
            this.cu_pMonth04.Height = 0.16F;
            this.cu_pMonth04.Left = 4.1875F;
            this.cu_pMonth04.MultiLine = false;
            this.cu_pMonth04.Name = "cu_pMonth04";
            this.cu_pMonth04.OutputFormat = resources.GetString("cu_pMonth04.OutputFormat");
            this.cu_pMonth04.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth04.SummaryGroup = "CustomerHeader";
            this.cu_pMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth04.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth04.Top = 0.3125F;
            this.cu_pMonth04.Width = 0.65F;
            // 
            // cu_pMonth05
            // 
            this.cu_pMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth05.DataField = "GrossProfit5";
            this.cu_pMonth05.Height = 0.16F;
            this.cu_pMonth05.Left = 4.9375F;
            this.cu_pMonth05.MultiLine = false;
            this.cu_pMonth05.Name = "cu_pMonth05";
            this.cu_pMonth05.OutputFormat = resources.GetString("cu_pMonth05.OutputFormat");
            this.cu_pMonth05.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth05.SummaryGroup = "CustomerHeader";
            this.cu_pMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth05.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth05.Top = 0.3125F;
            this.cu_pMonth05.Width = 0.65F;
            // 
            // cu_pMonth06
            // 
            this.cu_pMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth06.DataField = "GrossProfit6";
            this.cu_pMonth06.Height = 0.16F;
            this.cu_pMonth06.Left = 5.6875F;
            this.cu_pMonth06.MultiLine = false;
            this.cu_pMonth06.Name = "cu_pMonth06";
            this.cu_pMonth06.OutputFormat = resources.GetString("cu_pMonth06.OutputFormat");
            this.cu_pMonth06.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth06.SummaryGroup = "CustomerHeader";
            this.cu_pMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth06.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth06.Top = 0.3125F;
            this.cu_pMonth06.Width = 0.65F;
            // 
            // cu_pMonth07
            // 
            this.cu_pMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth07.DataField = "GrossProfit7";
            this.cu_pMonth07.Height = 0.16F;
            this.cu_pMonth07.Left = 6.4375F;
            this.cu_pMonth07.MultiLine = false;
            this.cu_pMonth07.Name = "cu_pMonth07";
            this.cu_pMonth07.OutputFormat = resources.GetString("cu_pMonth07.OutputFormat");
            this.cu_pMonth07.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth07.SummaryGroup = "CustomerHeader";
            this.cu_pMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth07.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth07.Top = 0.3125F;
            this.cu_pMonth07.Width = 0.65F;
            // 
            // cu_pMonth08
            // 
            this.cu_pMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth08.DataField = "GrossProfit8";
            this.cu_pMonth08.Height = 0.16F;
            this.cu_pMonth08.Left = 7.1875F;
            this.cu_pMonth08.MultiLine = false;
            this.cu_pMonth08.Name = "cu_pMonth08";
            this.cu_pMonth08.OutputFormat = resources.GetString("cu_pMonth08.OutputFormat");
            this.cu_pMonth08.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth08.SummaryGroup = "CustomerHeader";
            this.cu_pMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth08.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth08.Top = 0.3125F;
            this.cu_pMonth08.Width = 0.65F;
            // 
            // cu_pMonth09
            // 
            this.cu_pMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth09.DataField = "GrossProfit9";
            this.cu_pMonth09.Height = 0.16F;
            this.cu_pMonth09.Left = 7.9375F;
            this.cu_pMonth09.MultiLine = false;
            this.cu_pMonth09.Name = "cu_pMonth09";
            this.cu_pMonth09.OutputFormat = resources.GetString("cu_pMonth09.OutputFormat");
            this.cu_pMonth09.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth09.SummaryGroup = "CustomerHeader";
            this.cu_pMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth09.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth09.Top = 0.3125F;
            this.cu_pMonth09.Width = 0.65F;
            // 
            // cu_pMonth10
            // 
            this.cu_pMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth10.DataField = "GrossProfit10";
            this.cu_pMonth10.Height = 0.16F;
            this.cu_pMonth10.Left = 8.6875F;
            this.cu_pMonth10.MultiLine = false;
            this.cu_pMonth10.Name = "cu_pMonth10";
            this.cu_pMonth10.OutputFormat = resources.GetString("cu_pMonth10.OutputFormat");
            this.cu_pMonth10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth10.SummaryGroup = "CustomerHeader";
            this.cu_pMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth10.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth10.Top = 0.3125F;
            this.cu_pMonth10.Width = 0.65F;
            // 
            // cu_pMonth11
            // 
            this.cu_pMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth11.DataField = "GrossProfit11";
            this.cu_pMonth11.Height = 0.16F;
            this.cu_pMonth11.Left = 9.4375F;
            this.cu_pMonth11.MultiLine = false;
            this.cu_pMonth11.Name = "cu_pMonth11";
            this.cu_pMonth11.OutputFormat = resources.GetString("cu_pMonth11.OutputFormat");
            this.cu_pMonth11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth11.SummaryGroup = "CustomerHeader";
            this.cu_pMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth11.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth11.Top = 0.3125F;
            this.cu_pMonth11.Width = 0.65F;
            // 
            // cu_pMonth12
            // 
            this.cu_pMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_pMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_pMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.cu_pMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.cu_pMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_pMonth12.DataField = "GrossProfit12";
            this.cu_pMonth12.Height = 0.16F;
            this.cu_pMonth12.Left = 10.1875F;
            this.cu_pMonth12.MultiLine = false;
            this.cu_pMonth12.Name = "cu_pMonth12";
            this.cu_pMonth12.OutputFormat = resources.GetString("cu_pMonth12.OutputFormat");
            this.cu_pMonth12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_pMonth12.SummaryGroup = "CustomerHeader";
            this.cu_pMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_pMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_pMonth12.Text = "ZZZ,ZZZ,ZZ9";
            this.cu_pMonth12.Top = 0.3125F;
            this.cu_pMonth12.Width = 0.65F;
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
            this.label7.Left = 0.9375F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "得意先計";
            this.label7.Top = 0F;
            this.label7.Width = 0.7F;
            // 
            // AreaHeader
            // 
            this.AreaHeader.CanShrink = true;
            this.AreaHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line4,
            this.ArHd_SectionTitle,
            this.ArHd_AddUpSecCode,
            this.ArHd_SectionGuideNm,
            this.ArHd_AreaTitle,
            this.ArHd_AreaCd,
            this.ArHd_AreaNm,
            this.ArHd_CustomerTitle,
            this.ArHd_CustomerName,
            this.ArHd_CustomerCode,
            this.line12});
            this.AreaHeader.DataField = "HeaderKey1";
            this.AreaHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.AreaHeader.Height = 0.25F;
            this.AreaHeader.KeepTogether = true;
            this.AreaHeader.Name = "AreaHeader";
            this.AreaHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.AreaHeader.Visible = false;
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
            this.line4.Width = 10.88F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.88F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
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
            this.ArHd_AreaTitle.Left = 1.9375F;
            this.ArHd_AreaTitle.MultiLine = false;
            this.ArHd_AreaTitle.Name = "ArHd_AreaTitle";
            this.ArHd_AreaTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.ArHd_AreaTitle.Text = "地区";
            this.ArHd_AreaTitle.Top = 0F;
            this.ArHd_AreaTitle.Width = 0.28F;
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
            this.ArHd_AreaCd.Left = 2.25F;
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
            this.ArHd_AreaNm.Left = 2.5625F;
            this.ArHd_AreaNm.MultiLine = false;
            this.ArHd_AreaNm.Name = "ArHd_AreaNm";
            this.ArHd_AreaNm.OutputFormat = resources.GetString("ArHd_AreaNm.OutputFormat");
            this.ArHd_AreaNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.ArHd_AreaNm.Text = "あいうえおかきくけこ";
            this.ArHd_AreaNm.Top = 0F;
            this.ArHd_AreaNm.Width = 1.2F;
            // 
            // ArHd_CustomerTitle
            // 
            this.ArHd_CustomerTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_CustomerTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_CustomerTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerTitle.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_CustomerTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerTitle.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_CustomerTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerTitle.Height = 0.16F;
            this.ArHd_CustomerTitle.HyperLink = "";
            this.ArHd_CustomerTitle.Left = 4.1875F;
            this.ArHd_CustomerTitle.MultiLine = false;
            this.ArHd_CustomerTitle.Name = "ArHd_CustomerTitle";
            this.ArHd_CustomerTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: bottom; ";
            this.ArHd_CustomerTitle.Text = "得意先";
            this.ArHd_CustomerTitle.Top = 0F;
            this.ArHd_CustomerTitle.Visible = false;
            this.ArHd_CustomerTitle.Width = 0.438F;
            // 
            // ArHd_CustomerName
            // 
            this.ArHd_CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerName.DataField = "CustomerSnm";
            this.ArHd_CustomerName.Height = 0.16F;
            this.ArHd_CustomerName.Left = 5.125F;
            this.ArHd_CustomerName.MultiLine = false;
            this.ArHd_CustomerName.Name = "ArHd_CustomerName";
            this.ArHd_CustomerName.OutputFormat = resources.GetString("ArHd_CustomerName.OutputFormat");
            this.ArHd_CustomerName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: bottom; ";
            this.ArHd_CustomerName.Text = "あいうえおかきくけこ";
            this.ArHd_CustomerName.Top = 0F;
            this.ArHd_CustomerName.Visible = false;
            this.ArHd_CustomerName.Width = 1.2F;
            // 
            // ArHd_CustomerCode
            // 
            this.ArHd_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ArHd_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ArHd_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.ArHd_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.ArHd_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArHd_CustomerCode.DataField = "CustomerCode";
            this.ArHd_CustomerCode.Height = 0.16F;
            this.ArHd_CustomerCode.Left = 4.625F;
            this.ArHd_CustomerCode.MultiLine = false;
            this.ArHd_CustomerCode.Name = "ArHd_CustomerCode";
            this.ArHd_CustomerCode.OutputFormat = resources.GetString("ArHd_CustomerCode.OutputFormat");
            this.ArHd_CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: bottom; ";
            this.ArHd_CustomerCode.Text = "12345678";
            this.ArHd_CustomerCode.Top = 0F;
            this.ArHd_CustomerCode.Visible = false;
            this.ArHd_CustomerCode.Width = 0.5F;
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
            this.line12.LineWeight = 1.5F;
            this.line12.Name = "line12";
            this.line12.Top = 0.16F;
            this.line12.Visible = false;
            this.line12.Width = 10.875F;
            this.line12.X1 = 0F;
            this.line12.X2 = 10.875F;
            this.line12.Y1 = 0.16F;
            this.line12.Y2 = 0.16F;
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
            this.empHeader.CanShrink = true;
            this.empHeader.DataField = "EmployeeCode";
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
            this.line6,
            this.label8,
            this.textBox9,
            this.textBox10,
            this.label20,
            this.label21,
            this.label22,
            this.textBox11,
            this.label23,
            this.textBox12,
            this.label24,
            this.textBox13,
            this.label25,
            this.label26,
            this.textBox14,
            this.label27,
            this.label28,
            this.textBox15,
            this.label29,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.label52});
            this.empFooter.Height = 0.25F;
            this.empFooter.KeepTogether = true;
            this.empFooter.Name = "empFooter";
            this.empFooter.Format += new System.EventHandler(this.empFooter_BeforePrint);
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
            this.line6.Width = 10.88F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.88F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.label8.Left = 0F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "担当者計";
            this.label8.Top = 0F;
            this.label8.Width = 0.59F;
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
            this.textBox9.DataField = "TermSalesMoney";
            this.textBox9.Height = 0.16F;
            this.textBox9.Left = 1.01F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox9.SummaryGroup = "empHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox9.Text = "ZZZZ,ZZZ,ZZ91";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.7F;
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
            this.textBox10.DataField = "TermSalesTarget1";
            this.textBox10.Height = 0.16F;
            this.textBox10.Left = 2.0625F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox10.SummaryGroup = "empHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "ZZZZ,ZZZ,ZZ9";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.7F;
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
            this.label20.Height = 0.16F;
            this.label20.HyperLink = "";
            this.label20.Left = 6.676667F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label20.Text = "]粗利額[";
            this.label20.Top = 0F;
            this.label20.Width = 0.48F;
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
            this.label21.Height = 0.16F;
            this.label21.HyperLink = "";
            this.label21.Left = 1.687083F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label21.Text = "]目標[";
            this.label21.Top = 0F;
            this.label21.Width = 0.38F;
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
            this.label22.Height = 0.16F;
            this.label22.HyperLink = "";
            this.label22.Left = 2.72875F;
            this.label22.MultiLine = false;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label22.Text = "]達成率[";
            this.label22.Top = 0F;
            this.label22.Width = 0.48F;
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
            this.textBox11.Height = 0.16F;
            this.textBox11.Left = 3.16625F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox11.Text = "ZZZ9.991";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.45F;
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
            this.label23.Height = 0.16F;
            this.label23.HyperLink = "";
            this.label23.Left = 3.614166F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label23.Text = "]売上数[";
            this.label23.Top = 0F;
            this.label23.Width = 0.48F;
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
            this.textBox12.Left = 4.094166F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox12.SummaryGroup = "empHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "ZZZ,ZZZ,ZZ91";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.65F;
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
            this.label24.Height = 0.16F;
            this.label24.HyperLink = "";
            this.label24.Left = 4.718833F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label24.Text = "]目標[";
            this.label24.Top = 0F;
            this.label24.Width = 0.37F;
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
            this.textBox13.DataField = "TermSalesTargetCount1";
            this.textBox13.Height = 0.16F;
            this.textBox13.Left = 5.083416F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.SummaryGroup = "empHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.65F;
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
            this.label25.Height = 0.16F;
            this.label25.HyperLink = "";
            this.label25.Left = 5.708084F;
            this.label25.MultiLine = false;
            this.label25.Name = "label25";
            this.label25.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label25.Text = "]達成率[";
            this.label25.Top = 0F;
            this.label25.Width = 0.48F;
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
            this.label26.Height = 0.16F;
            this.label26.HyperLink = "";
            this.label26.Left = 0.625F;
            this.label26.MultiLine = false;
            this.label26.Name = "label26";
            this.label26.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label26.Text = "売上額[";
            this.label26.Top = 0F;
            this.label26.Width = 0.42F;
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
            this.textBox14.DataField = "TermSalesProfit";
            this.textBox14.Height = 0.16F;
            this.textBox14.Left = 7.156666F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox14.SummaryGroup = "empHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "ZZZZ,ZZZ,ZZ9]";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.7F;
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
            this.label27.Height = 0.16F;
            this.label27.HyperLink = "";
            this.label27.Left = 7.83375F;
            this.label27.MultiLine = false;
            this.label27.Name = "label27";
            this.label27.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label27.Text = "]粗利率[";
            this.label27.Top = 0F;
            this.label27.Width = 0.48F;
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
            this.label28.Height = 0.16F;
            this.label28.HyperLink = "";
            this.label28.Left = 8.802333F;
            this.label28.MultiLine = false;
            this.label28.Name = "label28";
            this.label28.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label28.Text = "]目標[";
            this.label28.Top = 0F;
            this.label28.Width = 0.37F;
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
            this.textBox15.DataField = "TermSalesTargetProfit1";
            this.textBox15.Height = 0.16F;
            this.textBox15.Left = 9.177333F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox15.SummaryGroup = "empHeader";
            this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox15.Text = "ZZZ,ZZZ,ZZ9]";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.7F;
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
            this.label29.Height = 0.16F;
            this.label29.HyperLink = "";
            this.label29.Left = 9.843666F;
            this.label29.MultiLine = false;
            this.label29.Name = "label29";
            this.label29.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label29.Text = "]達成率[";
            this.label29.Top = 0F;
            this.label29.Width = 0.48F;
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
            this.textBox16.Height = 0.16F;
            this.textBox16.Left = 6.24F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox16.Text = "ZZZ9.99";
            this.textBox16.Top = 0F;
            this.textBox16.Width = 0.45F;
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
            this.textBox17.CanShrink = true;
            this.textBox17.Height = 0.16F;
            this.textBox17.Left = 8.32F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox17.Text = "ZZZ9.99]";
            this.textBox17.Top = 0F;
            this.textBox17.Width = 0.5F;
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
            this.textBox18.Height = 0.16F;
            this.textBox18.Left = 10.29F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox18.Text = "ZZZ9.99]";
            this.textBox18.Top = 0F;
            this.textBox18.Width = 0.5F;
            // 
            // label52
            // 
            this.label52.Border.BottomColor = System.Drawing.Color.Black;
            this.label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.LeftColor = System.Drawing.Color.Black;
            this.label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.RightColor = System.Drawing.Color.Black;
            this.label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.TopColor = System.Drawing.Color.Black;
            this.label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Height = 0.16F;
            this.label52.HyperLink = "";
            this.label52.Left = 10.78125F;
            this.label52.MultiLine = false;
            this.label52.Name = "label52";
            this.label52.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label52.Text = "]";
            this.label52.Top = 0F;
            this.label52.Width = 0.05F;
            // 
            // arHeader
            // 
            this.arHeader.CanShrink = true;
            this.arHeader.DataField = "AreaCode";
            this.arHeader.Height = 0F;
            this.arHeader.KeepTogether = true;
            this.arHeader.Name = "arHeader";
            this.arHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.arHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // arFooter
            // 
            this.arFooter.CanShrink = true;
            this.arFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label55,
            this.label56,
            this.textBox59,
            this.label57,
            this.textBox60,
            this.label58,
            this.textBox61,
            this.label59,
            this.textBox62,
            this.label60,
            this.textBox63,
            this.label61,
            this.textBox64,
            this.label62,
            this.textBox65,
            this.label63,
            this.textBox66,
            this.label64,
            this.textBox67,
            this.label65,
            this.textBox68,
            this.label66,
            this.line5});
            this.arFooter.Height = 0.25F;
            this.arFooter.KeepTogether = true;
            this.arFooter.Name = "arFooter";
            this.arFooter.Visible = false;
            this.arFooter.BeforePrint += new System.EventHandler(this.AreaFooter_BeforePrint);
            // 
            // label55
            // 
            this.label55.Border.BottomColor = System.Drawing.Color.Black;
            this.label55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.LeftColor = System.Drawing.Color.Black;
            this.label55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.RightColor = System.Drawing.Color.Black;
            this.label55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.TopColor = System.Drawing.Color.Black;
            this.label55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Height = 0.16F;
            this.label55.HyperLink = "";
            this.label55.Left = 0F;
            this.label55.MultiLine = false;
            this.label55.Name = "label55";
            this.label55.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label55.Text = "地区計";
            this.label55.Top = 0F;
            this.label55.Width = 0.5F;
            // 
            // label56
            // 
            this.label56.Border.BottomColor = System.Drawing.Color.Black;
            this.label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.LeftColor = System.Drawing.Color.Black;
            this.label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.RightColor = System.Drawing.Color.Black;
            this.label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.TopColor = System.Drawing.Color.Black;
            this.label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Height = 0.16F;
            this.label56.HyperLink = "";
            this.label56.Left = 0.625F;
            this.label56.MultiLine = false;
            this.label56.Name = "label56";
            this.label56.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label56.Text = "売上額[";
            this.label56.Top = 0F;
            this.label56.Width = 0.42F;
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
            this.textBox59.DataField = "TermSalesMoney";
            this.textBox59.Height = 0.16F;
            this.textBox59.Left = 1.01F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox59.SummaryGroup = "arHeader";
            this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox59.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox59.Top = 0F;
            this.textBox59.Width = 0.7F;
            // 
            // label57
            // 
            this.label57.Border.BottomColor = System.Drawing.Color.Black;
            this.label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.LeftColor = System.Drawing.Color.Black;
            this.label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.RightColor = System.Drawing.Color.Black;
            this.label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.TopColor = System.Drawing.Color.Black;
            this.label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Height = 0.16F;
            this.label57.HyperLink = "";
            this.label57.Left = 1.687083F;
            this.label57.MultiLine = false;
            this.label57.Name = "label57";
            this.label57.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label57.Text = "]目標[";
            this.label57.Top = 0F;
            this.label57.Width = 0.38F;
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
            this.textBox60.DataField = "TermSalesTarget1";
            this.textBox60.Height = 0.16F;
            this.textBox60.Left = 2.0625F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox60.SummaryGroup = "arHeader";
            this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox60.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox60.Top = 0F;
            this.textBox60.Width = 0.7F;
            // 
            // label58
            // 
            this.label58.Border.BottomColor = System.Drawing.Color.Black;
            this.label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.LeftColor = System.Drawing.Color.Black;
            this.label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.RightColor = System.Drawing.Color.Black;
            this.label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.TopColor = System.Drawing.Color.Black;
            this.label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Height = 0.16F;
            this.label58.HyperLink = "";
            this.label58.Left = 2.72875F;
            this.label58.MultiLine = false;
            this.label58.Name = "label58";
            this.label58.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label58.Text = "]達成率[";
            this.label58.Top = 0F;
            this.label58.Width = 0.48F;
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
            this.textBox61.Height = 0.16F;
            this.textBox61.Left = 3.16625F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox61.Text = "[ZZZ9.99]";
            this.textBox61.Top = 0F;
            this.textBox61.Width = 0.45F;
            // 
            // label59
            // 
            this.label59.Border.BottomColor = System.Drawing.Color.Black;
            this.label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.LeftColor = System.Drawing.Color.Black;
            this.label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.RightColor = System.Drawing.Color.Black;
            this.label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.TopColor = System.Drawing.Color.Black;
            this.label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Height = 0.16F;
            this.label59.HyperLink = "";
            this.label59.Left = 3.614166F;
            this.label59.MultiLine = false;
            this.label59.Name = "label59";
            this.label59.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label59.Text = "]売上数[";
            this.label59.Top = 0F;
            this.label59.Width = 0.48F;
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
            this.textBox62.DataField = "TermSalesCount";
            this.textBox62.Height = 0.16F;
            this.textBox62.Left = 4.094166F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox62.SummaryGroup = "arHeader";
            this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox62.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox62.Top = 0F;
            this.textBox62.Width = 0.65F;
            // 
            // label60
            // 
            this.label60.Border.BottomColor = System.Drawing.Color.Black;
            this.label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.LeftColor = System.Drawing.Color.Black;
            this.label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.RightColor = System.Drawing.Color.Black;
            this.label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.TopColor = System.Drawing.Color.Black;
            this.label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Height = 0.16F;
            this.label60.HyperLink = "";
            this.label60.Left = 4.718833F;
            this.label60.MultiLine = false;
            this.label60.Name = "label60";
            this.label60.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label60.Text = "]目標[";
            this.label60.Top = 0F;
            this.label60.Width = 0.37F;
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
            this.textBox63.DataField = "TermSalesTargetCount1";
            this.textBox63.Height = 0.16F;
            this.textBox63.Left = 5.083416F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox63.SummaryGroup = "arHeader";
            this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox63.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox63.Top = 0F;
            this.textBox63.Width = 0.65F;
            // 
            // label61
            // 
            this.label61.Border.BottomColor = System.Drawing.Color.Black;
            this.label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.LeftColor = System.Drawing.Color.Black;
            this.label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.RightColor = System.Drawing.Color.Black;
            this.label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.TopColor = System.Drawing.Color.Black;
            this.label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Height = 0.16F;
            this.label61.HyperLink = "";
            this.label61.Left = 5.708084F;
            this.label61.MultiLine = false;
            this.label61.Name = "label61";
            this.label61.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label61.Text = "]達成率[";
            this.label61.Top = 0F;
            this.label61.Width = 0.48F;
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
            this.textBox64.CanShrink = true;
            this.textBox64.Height = 0.16F;
            this.textBox64.Left = 6.24F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.Text = "[ZZZ9.99]";
            this.textBox64.Top = 0F;
            this.textBox64.Width = 0.45F;
            // 
            // label62
            // 
            this.label62.Border.BottomColor = System.Drawing.Color.Black;
            this.label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.LeftColor = System.Drawing.Color.Black;
            this.label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.RightColor = System.Drawing.Color.Black;
            this.label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.TopColor = System.Drawing.Color.Black;
            this.label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Height = 0.16F;
            this.label62.HyperLink = "";
            this.label62.Left = 6.676667F;
            this.label62.MultiLine = false;
            this.label62.Name = "label62";
            this.label62.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label62.Text = "]粗利額[";
            this.label62.Top = 0F;
            this.label62.Width = 0.48F;
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
            this.textBox65.DataField = "TermSalesProfit";
            this.textBox65.Height = 0.16F;
            this.textBox65.Left = 7.156666F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
            this.textBox65.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox65.SummaryGroup = "arHeader";
            this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox65.Text = "[ZZZZ,ZZZ,ZZ9]";
            this.textBox65.Top = 0F;
            this.textBox65.Width = 0.7F;
            // 
            // label63
            // 
            this.label63.Border.BottomColor = System.Drawing.Color.Black;
            this.label63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Border.LeftColor = System.Drawing.Color.Black;
            this.label63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Border.RightColor = System.Drawing.Color.Black;
            this.label63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Border.TopColor = System.Drawing.Color.Black;
            this.label63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Height = 0.16F;
            this.label63.HyperLink = "";
            this.label63.Left = 7.83375F;
            this.label63.MultiLine = false;
            this.label63.Name = "label63";
            this.label63.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label63.Text = "]粗利率[";
            this.label63.Top = 0F;
            this.label63.Width = 0.48F;
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
            this.textBox66.Height = 0.16F;
            this.textBox66.Left = 8.32F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
            this.textBox66.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox66.Text = "[ZZZ9.99]";
            this.textBox66.Top = 0F;
            this.textBox66.Width = 0.5F;
            // 
            // label64
            // 
            this.label64.Border.BottomColor = System.Drawing.Color.Black;
            this.label64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Border.LeftColor = System.Drawing.Color.Black;
            this.label64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Border.RightColor = System.Drawing.Color.Black;
            this.label64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Border.TopColor = System.Drawing.Color.Black;
            this.label64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Height = 0.16F;
            this.label64.HyperLink = "";
            this.label64.Left = 8.802333F;
            this.label64.MultiLine = false;
            this.label64.Name = "label64";
            this.label64.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label64.Text = "]目標[";
            this.label64.Top = 0F;
            this.label64.Width = 0.37F;
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
            this.textBox67.DataField = "TermSalesTargetProfit1";
            this.textBox67.Height = 0.16F;
            this.textBox67.Left = 9.177333F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
            this.textBox67.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox67.SummaryGroup = "arHeader";
            this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox67.Text = "[ZZZ,ZZZ,ZZ9]";
            this.textBox67.Top = 0F;
            this.textBox67.Width = 0.7F;
            // 
            // label65
            // 
            this.label65.Border.BottomColor = System.Drawing.Color.Black;
            this.label65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Border.LeftColor = System.Drawing.Color.Black;
            this.label65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Border.RightColor = System.Drawing.Color.Black;
            this.label65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Border.TopColor = System.Drawing.Color.Black;
            this.label65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Height = 0.16F;
            this.label65.HyperLink = "";
            this.label65.Left = 9.843666F;
            this.label65.MultiLine = false;
            this.label65.Name = "label65";
            this.label65.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label65.Text = "]達成率[";
            this.label65.Top = 0F;
            this.label65.Width = 0.48F;
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
            this.textBox68.Height = 0.16F;
            this.textBox68.Left = 10.29F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
            this.textBox68.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox68.Text = "[ZZZ9.99]";
            this.textBox68.Top = 0F;
            this.textBox68.Width = 0.5F;
            // 
            // label66
            // 
            this.label66.Border.BottomColor = System.Drawing.Color.Black;
            this.label66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label66.Border.LeftColor = System.Drawing.Color.Black;
            this.label66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label66.Border.RightColor = System.Drawing.Color.Black;
            this.label66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label66.Border.TopColor = System.Drawing.Color.Black;
            this.label66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label66.Height = 0.16F;
            this.label66.HyperLink = "";
            this.label66.Left = 10.781F;
            this.label66.MultiLine = false;
            this.label66.Name = "label66";
            this.label66.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label66.Text = "]";
            this.label66.Top = 0F;
            this.label66.Width = 0.05F;
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
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.88F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.88F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // PMKHN02052P_02A4C
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
            this.PrintWidth = 10.88F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.empHeader);
            this.Sections.Add(this.EmployeeHeader);
            this.Sections.Add(this.arHeader);
            this.Sections.Add(this.AreaHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.BLGroupHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.BLGroupFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.AreaFooter);
            this.Sections.Add(this.arFooter);
            this.Sections.Add(this.EmployeeFooter);
            this.Sections.Add(this.empFooter);
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
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GroupNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BLGoodsCd)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Goods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_EmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_CustomerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_mMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_cMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_pMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_mMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_cMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_pMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_AreaNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_CustomerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArHd_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion       

	}
}
