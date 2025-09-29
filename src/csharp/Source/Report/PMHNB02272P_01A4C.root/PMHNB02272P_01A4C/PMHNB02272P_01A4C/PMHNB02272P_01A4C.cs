//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売掛残高一覧表(総括)
// プログラム概要   : 売掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/03/10     修正内容：Mantis.15088 拠点名のDataField名を変更（AddUpSecName ⇒ SectionGuideSnm）
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：liyp
// 修正日    2010/12/20     修正内容：月次更新未処理月を印刷時の印字メッセージが修正
// ---------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11800255-00 作成担当 : 陳艶丹
// 修 正 日  2022/10/13  修正内容 : インボイス対応（税率別合計金額不具合修正）
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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
    /// 売掛残高一覧表(総括)印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 売掛残高一覧表(総括)のフォームクラスです。</br>
	/// <br></br>
    /// <br>UpdateNote  : 11570208-00 軽減税率対応</br>
    /// <br>Programmer  : 3H 劉星光</br>
    /// <br>Date        : 2020/04/10</br>
    /// </remarks>
	public class PMHNB02272P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表(総括)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 売掛残高一覧表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
		public PMHNB02272P_01A4C()
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

        private SumExtrInfo_BillBalance _sumExtrInfo_BillBalance;	// 抽出条件クラス

		// その他データ格納項目
		private string				 _detailAddupSecNameTtl;		// 明細拠点名称タイトル

		private int					 _printCount;					// ページ数カウント用

		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
		ListCommon_PageFooter _rptPageFooter	= null;
        private TextBox SalesPricTax;
        private Label label3;
        private TextBox Total_SalesPricTax;
        private TextBox Section_SalesPricTax;
        private TextBox AfCalTMonthAccRec;
        private Label label6;
        private TextBox Total_AfCalTMonthAccRec;
        private TextBox Section_AfCalTMonthAccRec;
        private GroupHeader AgentHeader;
        private GroupFooter AgentFooter;
        private TextBox tb_SumTitle;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox a_ThisTimeSales;
        private TextBox a_ThisRgdsDisPric;
        private TextBox a_PureSales;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox CustomerAgentCd;
        private TextBox CustomerAgentNm;
        private GroupHeader SalesAreaHeader;
        private GroupFooter SalesAreaFooter;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox t_ThisTimeSales;
        private TextBox t_ThisRgdsDisPric;
        private TextBox t_PureSales;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox21;
        private Label SalesArea_Label;
        private TextBox SalesAreaCode;
        private TextBox SalesAreaName;
        private Label label11;
        private Label Label_Payee1;
        private Label Label_Payee2;
        private Label Label_Payee3;
        private Label Label_Payee4;
        private Label Label_Payee5;
        private Label Label_Payee6;
        private Label Label_Payee7;
        private Label Label_Payee8;
        private Label Label_Payee9;
        private TextBox CashDeposit;
        private TextBox TrfrDeposit;
        private TextBox CheckDeposit;
        private TextBox DraftDeposit;
        private TextBox OffsetDeposit;
        private TextBox FundTransferDeposit;
        private TextBox OthsDeposit;
        private TextBox ThisTimeFeeDmdNrml;
        private TextBox ThisTimeDisDmdNrml;
        private TextBox g_CashDeposit;
        private TextBox g_TrfrDeposit;
        private TextBox g_CheckDeposit;
        private TextBox g_DraftDeposit;
        private TextBox g_OffsetDeposit;
        private TextBox g_FundTransferDeposit;
        private TextBox g_OthsDeposit;
        private TextBox g_ThisTimeFeeDmdNrml;
        private TextBox g_ThisTimeDisDmdNrml;
        private TextBox s_CashDeposit;
        private TextBox s_TrfrDeposit;
        private TextBox s_CheckDeposit;
        private TextBox s_DraftDeposit;
        private TextBox s_OffsetDeposit;
        private TextBox s_FundTransferDeposit;
        private TextBox s_OthsDeposit;
        private TextBox s_ThisTimeFeeDmdNrml;
        private TextBox s_ThisTimeDisDmdNrml;
        private TextBox t_CashDeposit;
        private TextBox t_TrfrDeposit;
        private TextBox t_CheckDeposit;
        private TextBox t_DraftDeposit;
        private TextBox t_OffsetDeposit;
        private TextBox t_FundTransferDeposit;
        private TextBox t_OthsDeposit;
        private TextBox t_ThisTimeFeeDmdNrml;
        private TextBox t_ThisTimeDisDmdNrml;
        private TextBox a_CashDeposit;
        private TextBox a_TrfrDeposit;
        private TextBox a_CheckDeposit;
        private TextBox a_DraftDeposit;
        private TextBox a_OffsetDeposit;
        private TextBox a_FundTransferDeposit;
        private TextBox a_OthsDeposit;
        private TextBox a_ThisTimeFeeDmdNrml;
        private TextBox a_ThisTimeDisDmdNrml;
        private Label Label_Tax;
        private Label label9;
        private TextBox AddUpSecCode;
        private TextBox AddUpSecName;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox15;
        private Line line2;
        private Line line3;
        private Line line4;
        private Line line5;
        private TextBox MonAddUpNonProc;
        private GroupHeader GrandTotalHeader2;
        private GroupFooter GrandTotalFooter2;
        private GroupHeader SectionHeader2;
        private GroupFooter SectionFooter2;
        private GroupHeader AgentHeader2;
        private GroupFooter AgentFooter2;
        private GroupHeader SalesAreaHeader2;
        private GroupFooter SalesAreaFooter2;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox28;
        private TextBox textBox29;
        private TextBox textBox30;
        private Line line6;
        private TextBox t_CashDeposit2;
        private TextBox t_TrfrDeposit2;
        private TextBox t_CheckDeposit2;
        private TextBox t_DraftDeposit2;
        private TextBox t_OffsetDeposit2;
        private TextBox t_FundTransferDeposit2;
        private TextBox t_OthsDeposit2;
        private TextBox t_ThisTimeFeeDmdNrml2;
        private TextBox t_ThisTimeDisDmdNrml2;
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
        private Label s_TaxTotalTitleTaxRate1;
        private Label s_TaxTotalTitleTaxRate2;
        private Label s_TaxTotalTitleOther;
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
        private TextBox a_CashDeposit2;
        private TextBox a_TrfrDeposit2;
        private TextBox a_CheckDeposit2;
        private TextBox a_DraftDeposit2;
        private TextBox a_OffsetDeposit2;
        private TextBox a_FundTransferDeposit2;
        private TextBox a_OthsDeposit2;
        private TextBox a_ThisTimeFeeDmdNrml2;
        private TextBox a_ThisTimeDisDmdNrml2;
        private Line line7;
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
        private TextBox textBox88;
        private TextBox textBox89;
        private TextBox textBox90;
        private TextBox textBox91;
        private TextBox textBox92;
        private TextBox textBox93;
        private TextBox textBox94;
        private TextBox textBox95;
        private Label label10;
        private Label label12;
        private Label label13;
        private Line line8;
        private TextBox textBox31;
        private TextBox textBox32;
        private TextBox textBox33;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox38;
        private TextBox textBox39;
        private TextBox textBox69;
        private TextBox textBox70;
        private TextBox s_CashDeposit2;
        private TextBox s_TrfrDeposit2;
        private TextBox s_CheckDeposit2;
        private TextBox s_DraftDeposit2;
        private TextBox s_OffsetDeposit2;
        private TextBox s_FundTransferDeposit2;
        private TextBox s_OthsDeposit2;
        private TextBox s_ThisTimeFeeDmdNrml2;
        private TextBox s_ThisTimeDisDmdNrml2;
        private TextBox textBox71;
        private TextBox textBox72;
        private TextBox textBox73;
        private TextBox textBox74;
        private TextBox textBox75;
        private TextBox textBox76;
        private TextBox textBox77;
        private TextBox textBox96;
        private TextBox textBox97;
        private TextBox textBox98;
        private TextBox textBox99;
        private TextBox textBox100;
        private TextBox textBox101;
        private TextBox textBox102;
        private TextBox textBox103;
        private TextBox textBox104;
        private TextBox textBox105;
        private TextBox textBox106;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Line line9;
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
        private TextBox g_CashDeposit2;
        private TextBox g_TrfrDeposit2;
        private TextBox g_CheckDeposit2;
        private TextBox g_DraftDeposit2;
        private TextBox g_OffsetDeposit2;
        private TextBox g_FundTransferDeposit2;
        private TextBox g_OthsDeposit2;
        private TextBox g_ThisTimeFeeDmdNrml2;
        private TextBox g_ThisTimeDisDmdNrml2;
        private TextBox textBox117;
        private TextBox textBox118;
        private TextBox textBox119;
        private TextBox textBox120;
        private TextBox textBox121;
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
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private TextBox textBox135;
        private TextBox textBox136;
        private TextBox textBox137;
        private TextBox textBox138;
        private TextBox textBox139;
        private TextBox textBox140;
        private Label label22;
        private TextBox textBox141;
        private TextBox textBox142;
        private TextBox textBox143;
        private TextBox textBox144;
        private TextBox textBox145;
        private TextBox textBox146;
        private Label label23;
        private TextBox textBox147;
        private TextBox textBox148;
        private TextBox textBox149;
        private TextBox textBox150;
        private TextBox textBox151;
        private TextBox textBox152;
        private Label label24;
        private TextBox textBox153;
        private TextBox textBox154;
        private TextBox textBox155;
        private TextBox textBox156;
        private TextBox textBox157;
        private TextBox textBox158;

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
                this._sumExtrInfo_BillBalance = (SumExtrInfo_BillBalance)this._printInfo.jyoken;
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
				// TODO:  MAHNB02012P_03A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAHNB02012P_03A4C.WatermarkMode setter 実装を追加します。
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
        /// <br></br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{
            // 改頁の制御
            if (this._sumExtrInfo_BillBalance.NewPageType == 2)
            {
                // しない
                SectionHeader.NewPage = NewPage.None;
            }
            else if (this._sumExtrInfo_BillBalance.NewPageType == 1)
            {
                // 小計
                AgentHeader.NewPage = NewPage.Before;
                SalesAreaHeader.NewPage = NewPage.Before;
            }

            // 得意先順
            if (this._sumExtrInfo_BillBalance.SortOrderDiv == (int)SumExtrInfo_BillBalance.SortOrderDivState.CustomerCode)
            {
                // 拠点の印字
                AddUpSecCode.Visible = true;
                AddUpSecName.Visible = true;
            }
            // 地区計印字設定
            if (this._sumExtrInfo_BillBalance.SortOrderDiv == (int)SumExtrInfo_BillBalance.SortOrderDivState.SalesAreaCode)
            {
                SalesAreaHeader.DataField = PMHNB02274EA.Col_SalesAreaCode;
                SalesAreaHeader.Visible   = true;
                SalesAreaFooter.Visible   = true;
                SalesArea_Label.Visible = true;
            }
            else
            {
                SalesAreaHeader.DataField = "";
                SalesAreaHeader.Visible = false;
                SalesAreaFooter.Visible = false;
                SalesArea_Label.Visible = false;
            }

            // 担当者計印字設定
            if (this._sumExtrInfo_BillBalance.SortOrderDiv == (int)SumExtrInfo_BillBalance.SortOrderDivState.EmployeeCode)
            {
                AgentHeader.DataField = PMHNB02274EA.Col_AgentCd;
                CustomerAgentCd.DataField = PMHNB02274EA.Col_AgentCd;
                CustomerAgentNm.DataField = PMHNB02274EA.Col_Name;

                AgentHeader.Visible = true;
                AgentFooter.Visible = true;
                SalesArea_Label.Visible = true;
                SalesArea_Label.Text = "担当者";
            }
            else
            {
                AgentHeader.DataField = "";
                AgentHeader.Visible = false;
                AgentFooter.Visible = false;
            }
            
            // 入金内訳印字設定
            SetDepositDtl();
            
			// 項目の名称をセット
			tb_ReportTitle.Text			= this._pageHeaderSubtitle;				// サブタイトル
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;		// ソート条件

            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            // 税別内訳印字区分
            if (this._sumExtrInfo_BillBalance.TaxPrintDiv == 0)
            {
                SalesAreaFooter2.Visible = SalesAreaFooter.Visible;
                SalesAreaFooter.Visible = false;

                AgentFooter2.Visible = AgentFooter.Visible;
                AgentFooter.Visible = false;

                GrandTotalFooter2.Visible = GrandTotalFooter.Visible;
                GrandTotalFooter.Visible = false;

                SectionFooter2.Visible = SectionFooter.Visible;
                SectionFooter.Visible = false;
            }
            else
            {
                SalesAreaFooter2.Visible = false;
                AgentFooter2.Visible = false;
                GrandTotalFooter2.Visible = false;
                SectionFooter2.Visible = false;
            }
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
		}
		#endregion

        #region ◆ 入金内訳印字設定
        /// <summary>
        /// 入金内訳印字設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入金内訳から印字設定行う</br>
        /// <br></br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        private void SetDepositDtl()
        {
            // 入金内訳
            if (this._sumExtrInfo_BillBalance.DepoDtlDiv == 1)
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
                CashDeposit.Visible = false;
                TrfrDeposit.Visible = false;
                CheckDeposit.Visible = false;
                DraftDeposit.Visible = false;
                OffsetDeposit.Visible = false;
                FundTransferDeposit.Visible = false;
                OthsDeposit.Visible = false;
                ThisTimeFeeDmdNrml.Visible = false;
                ThisTimeDisDmdNrml.Visible = false;
                // 地区計
                t_CashDeposit.Visible = false;
                t_TrfrDeposit.Visible = false;
                t_CheckDeposit.Visible = false;
                t_DraftDeposit.Visible = false;
                t_OffsetDeposit.Visible = false;
                t_FundTransferDeposit.Visible = false;
                t_OthsDeposit.Visible = false;
                t_ThisTimeFeeDmdNrml.Visible = false;
                t_ThisTimeDisDmdNrml.Visible = false;
                // 担当者計
                a_CashDeposit.Visible = false;
                a_TrfrDeposit.Visible = false;
                a_CheckDeposit.Visible = false;
                a_DraftDeposit.Visible = false;
                a_OffsetDeposit.Visible = false;
                a_FundTransferDeposit.Visible = false;
                a_OthsDeposit.Visible = false;
                a_ThisTimeFeeDmdNrml.Visible = false;
                a_ThisTimeDisDmdNrml.Visible = false;
                // 拠点計
                s_CashDeposit.Visible = false;
                s_TrfrDeposit.Visible = false;
                s_CheckDeposit.Visible = false;
                s_DraftDeposit.Visible = false;
                s_OffsetDeposit.Visible = false;
                s_FundTransferDeposit.Visible = false;
                s_OthsDeposit.Visible = false;
                s_ThisTimeFeeDmdNrml.Visible = false;
                s_ThisTimeDisDmdNrml.Visible = false;
                // 総合計
                g_CashDeposit.Visible = false;
                g_TrfrDeposit.Visible = false;
                g_CheckDeposit.Visible = false;
                g_DraftDeposit.Visible = false;
                g_OffsetDeposit.Visible = false;
                g_FundTransferDeposit.Visible = false;
                g_OthsDeposit.Visible = false;
                g_ThisTimeFeeDmdNrml.Visible = false;
                g_ThisTimeDisDmdNrml.Visible = false;

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 地区計(税別内訳印字)
                t_CashDeposit2.Visible = false;
                t_TrfrDeposit2.Visible = false;
                t_CheckDeposit2.Visible = false;
                t_DraftDeposit2.Visible = false;
                t_OffsetDeposit2.Visible = false;
                t_FundTransferDeposit2.Visible = false;
                t_OthsDeposit2.Visible = false;
                t_ThisTimeFeeDmdNrml2.Visible = false;
                t_ThisTimeDisDmdNrml2.Visible = false;
                // 担当者計(税別内訳印字)
                a_CashDeposit2.Visible = false;
                a_TrfrDeposit2.Visible = false;
                a_CheckDeposit2.Visible = false;
                a_DraftDeposit2.Visible = false;
                a_OffsetDeposit2.Visible = false;
                a_FundTransferDeposit2.Visible = false;
                a_OthsDeposit2.Visible = false;
                a_ThisTimeFeeDmdNrml2.Visible = false;
                a_ThisTimeDisDmdNrml2.Visible = false;
                // 拠点計(税別内訳印字)
                s_CashDeposit2.Visible = false;
                s_TrfrDeposit2.Visible = false;
                s_CheckDeposit2.Visible = false;
                s_DraftDeposit2.Visible = false;
                s_OffsetDeposit2.Visible = false;
                s_FundTransferDeposit2.Visible = false;
                s_OthsDeposit2.Visible = false;
                s_ThisTimeFeeDmdNrml2.Visible = false;
                s_ThisTimeDisDmdNrml2.Visible = false;
                // 総合計(税別内訳印字)
                g_CashDeposit2.Visible = false;
                g_TrfrDeposit2.Visible = false;
                g_CheckDeposit2.Visible = false;
                g_DraftDeposit2.Visible = false;
                g_OffsetDeposit2.Visible = false;
                g_FundTransferDeposit2.Visible = false;
                g_OthsDeposit2.Visible = false;
                g_ThisTimeFeeDmdNrml2.Visible = false;
                g_ThisTimeDisDmdNrml2.Visible = false;
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
            }
        }
        #endregion

		#endregion

		#region ■ Control Event
        #region ◆ PMHNB02272P_01A4C_ReportStart Event
        /// <summary>
        /// PMHNB02272P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : レポートの設定をするイベントです。</br>
        /// <br></br>
        /// </remarks>
        private void PMHNB02272P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();
        }
        #endregion ◆ PMHNB02272P_01A4C_ReportStart Event

        #region ◆ PageHeader_Format Event
        /// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ページヘッダーグループの初期化イベントです。</br>
        /// <br></br>
        /// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString(SumExtrInfo_BillBalance.ct_DateFomat, DateTime.Now);
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
		/// <br>Note		: ExtraHeaderグループの初期化イベントです。</br>
        /// <br></br>
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

            // 拠点毎に暫定消費税の文言を表示制御
            if (this._sumExtrInfo_BillBalance.NewPageType != 2)
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

		#region ◆ Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br></br>
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
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
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

        #region ◆ SalesAreaHeader_Format Event
        /// <summary>
        /// SalesAreaHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 地区グループヘッダーの印刷フォーマットイベントです。</br>
        /// <br></br>
        /// </remarks>
        private void SalesAreaHeader_Format(object sender, EventArgs e)
        {
            string salesAreaCode = SalesAreaCode.Value.ToString().TrimEnd();
            if (salesAreaCode == "0")
            {
                // 地区コードが"0"の場合は非印字
                SalesAreaCode.Visible = false;
                SalesAreaName.Visible = false;
            }
            else
            {
                // 上記以外の場合は印字
                SalesAreaCode.Visible = true;
                SalesAreaName.Visible = true;
            }
        }
        #endregion ◆ SalesAreaHeader_Format Event

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
		private DataDynamics.ActiveReports.Label Claim_Label;
		private DataDynamics.ActiveReports.Label Label105;
		private DataDynamics.ActiveReports.Label Label106;
        private DataDynamics.ActiveReports.Label Label107;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label7;
        private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.Line Line13;
		private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.TextBox LastTimeAccRec;
		private DataDynamics.ActiveReports.TextBox ThisTimeDmdNrml;
		private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcAcc;
		private DataDynamics.ActiveReports.TextBox ThisTimeSales;
        private DataDynamics.ActiveReports.TextBox ThisRgdsDisPric;
		private DataDynamics.ActiveReports.TextBox ClaimCode;
        private DataDynamics.ActiveReports.TextBox ClaimSnm;
		private DataDynamics.ActiveReports.TextBox PureSales;
        private DataDynamics.ActiveReports.TextBox OfsThisSalesTax;
        private DataDynamics.ActiveReports.TextBox SalesSlipCount;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox MONEYKINDNAME13;
		private DataDynamics.ActiveReports.TextBox Section_LastTimeAccRec;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimeDmdNrml;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimeTtlBlcAcc;
        private DataDynamics.ActiveReports.TextBox Section_OfsThisSalesTax;
        private DataDynamics.ActiveReports.TextBox s_ThisTimeSales;
        private DataDynamics.ActiveReports.TextBox s_ThisRgdsDisPric;
		private DataDynamics.ActiveReports.TextBox s_PureSales;
		private DataDynamics.ActiveReports.TextBox Section_SalesSlipCount;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label Label109;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Total_LastTimeAccRec;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimeDmdNrml;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimeTtlBlcAcc;
        private DataDynamics.ActiveReports.TextBox g_PureSales;
        private DataDynamics.ActiveReports.TextBox g_ThisTimeSales;
		private DataDynamics.ActiveReports.TextBox g_ThisRgdsDisPric;
		private DataDynamics.ActiveReports.TextBox Total_OfsThisSalesTax;
		private DataDynamics.ActiveReports.TextBox Total_SalesSlipCount;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHNB02272P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.LastTimeAccRec = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcAcc = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.ClaimCode = new DataDynamics.ActiveReports.TextBox();
            this.ClaimSnm = new DataDynamics.ActiveReports.TextBox();
            this.PureSales = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.SalesPricTax = new DataDynamics.ActiveReports.TextBox();
            this.AfCalTMonthAccRec = new DataDynamics.ActiveReports.TextBox();
            this.CashDeposit = new DataDynamics.ActiveReports.TextBox();
            this.TrfrDeposit = new DataDynamics.ActiveReports.TextBox();
            this.CheckDeposit = new DataDynamics.ActiveReports.TextBox();
            this.DraftDeposit = new DataDynamics.ActiveReports.TextBox();
            this.OffsetDeposit = new DataDynamics.ActiveReports.TextBox();
            this.FundTransferDeposit = new DataDynamics.ActiveReports.TextBox();
            this.OthsDeposit = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.Line13 = new DataDynamics.ActiveReports.Line();
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
            this.Claim_Label = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.SalesArea_Label = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
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
            this.Total_LastTimeAccRec = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimeTtlBlcAcc = new DataDynamics.ActiveReports.TextBox();
            this.g_PureSales = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.Total_OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.Total_SalesSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.Total_SalesPricTax = new DataDynamics.ActiveReports.TextBox();
            this.Total_AfCalTMonthAccRec = new DataDynamics.ActiveReports.TextBox();
            this.g_CashDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_TrfrDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_CheckDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_DraftDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_OffsetDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_FundTransferDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_OthsDeposit = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.MonAddUpNonProc = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.Section_LastTimeAccRec = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimeTtlBlcAcc = new DataDynamics.ActiveReports.TextBox();
            this.Section_OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.s_PureSales = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesPricTax = new DataDynamics.ActiveReports.TextBox();
            this.Section_AfCalTMonthAccRec = new DataDynamics.ActiveReports.TextBox();
            this.s_CashDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_TrfrDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_CheckDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_DraftDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_OffsetDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_FundTransferDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_OthsDeposit = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.AgentHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CustomerAgentCd = new DataDynamics.ActiveReports.TextBox();
            this.CustomerAgentNm = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.AgentFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.tb_SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.a_ThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.a_ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.a_PureSales = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.a_CashDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_TrfrDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_CheckDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_DraftDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_OffsetDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_FundTransferDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_OthsDeposit = new DataDynamics.ActiveReports.TextBox();
            this.a_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.a_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.SalesAreaHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SalesAreaCode = new DataDynamics.ActiveReports.TextBox();
            this.SalesAreaName = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SalesAreaFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.t_PureSales = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.t_CashDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_TrfrDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_CheckDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_DraftDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_OffsetDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_FundTransferDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_OthsDeposit = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.line9 = new DataDynamics.ActiveReports.Line();
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
            this.g_CashDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_TrfrDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_CheckDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_DraftDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OffsetDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_FundTransferDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OthsDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox117 = new DataDynamics.ActiveReports.TextBox();
            this.textBox118 = new DataDynamics.ActiveReports.TextBox();
            this.textBox119 = new DataDynamics.ActiveReports.TextBox();
            this.textBox120 = new DataDynamics.ActiveReports.TextBox();
            this.textBox121 = new DataDynamics.ActiveReports.TextBox();
            this.textBox122 = new DataDynamics.ActiveReports.TextBox();
            this.textBox123 = new DataDynamics.ActiveReports.TextBox();
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
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.SectionHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.textBox70 = new DataDynamics.ActiveReports.TextBox();
            this.s_CashDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_TrfrDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_CheckDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_DraftDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OffsetDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_FundTransferDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OthsDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox71 = new DataDynamics.ActiveReports.TextBox();
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.textBox73 = new DataDynamics.ActiveReports.TextBox();
            this.textBox74 = new DataDynamics.ActiveReports.TextBox();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.textBox76 = new DataDynamics.ActiveReports.TextBox();
            this.textBox77 = new DataDynamics.ActiveReports.TextBox();
            this.textBox96 = new DataDynamics.ActiveReports.TextBox();
            this.textBox97 = new DataDynamics.ActiveReports.TextBox();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.textBox99 = new DataDynamics.ActiveReports.TextBox();
            this.textBox100 = new DataDynamics.ActiveReports.TextBox();
            this.textBox101 = new DataDynamics.ActiveReports.TextBox();
            this.textBox102 = new DataDynamics.ActiveReports.TextBox();
            this.textBox103 = new DataDynamics.ActiveReports.TextBox();
            this.textBox104 = new DataDynamics.ActiveReports.TextBox();
            this.textBox105 = new DataDynamics.ActiveReports.TextBox();
            this.textBox106 = new DataDynamics.ActiveReports.TextBox();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.AgentHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.AgentFooter2 = new DataDynamics.ActiveReports.GroupFooter();
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
            this.a_CashDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_TrfrDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_CheckDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_DraftDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_OffsetDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_FundTransferDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_OthsDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.a_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.a_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
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
            this.textBox88 = new DataDynamics.ActiveReports.TextBox();
            this.textBox89 = new DataDynamics.ActiveReports.TextBox();
            this.textBox90 = new DataDynamics.ActiveReports.TextBox();
            this.textBox91 = new DataDynamics.ActiveReports.TextBox();
            this.textBox92 = new DataDynamics.ActiveReports.TextBox();
            this.textBox93 = new DataDynamics.ActiveReports.TextBox();
            this.textBox94 = new DataDynamics.ActiveReports.TextBox();
            this.textBox95 = new DataDynamics.ActiveReports.TextBox();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.SalesAreaHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.SalesAreaFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.t_CashDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_TrfrDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_CheckDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_DraftDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_OffsetDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_FundTransferDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_OthsDeposit2 = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
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
            this.s_TaxTotalTitleTaxRate1 = new DataDynamics.ActiveReports.Label();
            this.s_TaxTotalTitleTaxRate2 = new DataDynamics.ActiveReports.Label();
            this.s_TaxTotalTitleOther = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.textBox135 = new DataDynamics.ActiveReports.TextBox();
            this.textBox136 = new DataDynamics.ActiveReports.TextBox();
            this.textBox137 = new DataDynamics.ActiveReports.TextBox();
            this.textBox138 = new DataDynamics.ActiveReports.TextBox();
            this.textBox139 = new DataDynamics.ActiveReports.TextBox();
            this.textBox140 = new DataDynamics.ActiveReports.TextBox();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.textBox141 = new DataDynamics.ActiveReports.TextBox();
            this.textBox142 = new DataDynamics.ActiveReports.TextBox();
            this.textBox143 = new DataDynamics.ActiveReports.TextBox();
            this.textBox144 = new DataDynamics.ActiveReports.TextBox();
            this.textBox145 = new DataDynamics.ActiveReports.TextBox();
            this.textBox146 = new DataDynamics.ActiveReports.TextBox();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.textBox147 = new DataDynamics.ActiveReports.TextBox();
            this.textBox148 = new DataDynamics.ActiveReports.TextBox();
            this.textBox149 = new DataDynamics.ActiveReports.TextBox();
            this.textBox150 = new DataDynamics.ActiveReports.TextBox();
            this.textBox151 = new DataDynamics.ActiveReports.TextBox();
            this.textBox152 = new DataDynamics.ActiveReports.TextBox();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.textBox153 = new DataDynamics.ActiveReports.TextBox();
            this.textBox154 = new DataDynamics.ActiveReports.TextBox();
            this.textBox155 = new DataDynamics.ActiveReports.TextBox();
            this.textBox156 = new DataDynamics.ActiveReports.TextBox();
            this.textBox157 = new DataDynamics.ActiveReports.TextBox();
            this.textBox158 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeAccRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalTMonthAccRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Tax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Claim_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesArea_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Total_LastTimeAccRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeTtlBlcAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PureSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_SalesSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_SalesPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AfCalTMonthAccRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonAddUpNonProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_LastTimeAccRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeTtlBlcAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_PureSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AfCalTMonthAccRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAgentCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAgentNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_PureSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_TrfrDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OffsetDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_FundTransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OthsDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAreaName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_PureSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TrfrDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OffsetDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_FundTransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OthsDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.g_CashDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.a_CashDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_TrfrDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_CheckDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_DraftDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OffsetDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_FundTransferDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OthsDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeDisDmdNrml2)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CashDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TrfrDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CheckDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_DraftDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OffsetDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_FundTransferDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OthsDeposit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeDisDmdNrml2)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line37,
            this.LastTimeAccRec,
            this.ThisTimeDmdNrml,
            this.ThisTimeTtlBlcAcc,
            this.ThisTimeSales,
            this.ThisRgdsDisPric,
            this.ClaimCode,
            this.ClaimSnm,
            this.PureSales,
            this.OfsThisSalesTax,
            this.SalesSlipCount,
            this.SalesPricTax,
            this.AfCalTMonthAccRec,
            this.CashDeposit,
            this.TrfrDeposit,
            this.CheckDeposit,
            this.DraftDeposit,
            this.OffsetDeposit,
            this.FundTransferDeposit,
            this.OthsDeposit,
            this.ThisTimeFeeDmdNrml,
            this.ThisTimeDisDmdNrml});
            this.Detail.Height = 0.40625F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            // LastTimeAccRec
            // 
            this.LastTimeAccRec.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeAccRec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccRec.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeAccRec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccRec.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeAccRec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccRec.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeAccRec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccRec.DataField = "LastTimeAccRec";
            this.LastTimeAccRec.Height = 0.125F;
            this.LastTimeAccRec.Left = 2.9375F;
            this.LastTimeAccRec.MultiLine = false;
            this.LastTimeAccRec.Name = "LastTimeAccRec";
            this.LastTimeAccRec.OutputFormat = resources.GetString("LastTimeAccRec.OutputFormat");
            this.LastTimeAccRec.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.LastTimeAccRec.Text = "1,234,567,890";
            this.LastTimeAccRec.Top = 0F;
            this.LastTimeAccRec.Width = 0.8125F;
            // 
            // ThisTimeDmdNrml
            // 
            this.ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.Height = 0.125F;
            this.ThisTimeDmdNrml.Left = 3.75F;
            this.ThisTimeDmdNrml.MultiLine = false;
            this.ThisTimeDmdNrml.Name = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.OutputFormat = resources.GetString("ThisTimeDmdNrml.OutputFormat");
            this.ThisTimeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeDmdNrml.Text = "1,234,567,890";
            this.ThisTimeDmdNrml.Top = 0F;
            this.ThisTimeDmdNrml.Width = 0.8125F;
            // 
            // ThisTimeTtlBlcAcc
            // 
            this.ThisTimeTtlBlcAcc.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcc.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcc.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcc.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcc.DataField = "ThisTimeTtlBlcAcc";
            this.ThisTimeTtlBlcAcc.Height = 0.125F;
            this.ThisTimeTtlBlcAcc.Left = 4.5625F;
            this.ThisTimeTtlBlcAcc.MultiLine = false;
            this.ThisTimeTtlBlcAcc.Name = "ThisTimeTtlBlcAcc";
            this.ThisTimeTtlBlcAcc.OutputFormat = resources.GetString("ThisTimeTtlBlcAcc.OutputFormat");
            this.ThisTimeTtlBlcAcc.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeTtlBlcAcc.Text = "1,234,567,890";
            this.ThisTimeTtlBlcAcc.Top = 0F;
            this.ThisTimeTtlBlcAcc.Width = 0.8125F;
            // 
            // ThisTimeSales
            // 
            this.ThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.DataField = "ThisTimeSales";
            this.ThisTimeSales.Height = 0.125F;
            this.ThisTimeSales.Left = 5.375F;
            this.ThisTimeSales.MultiLine = false;
            this.ThisTimeSales.Name = "ThisTimeSales";
            this.ThisTimeSales.OutputFormat = resources.GetString("ThisTimeSales.OutputFormat");
            this.ThisTimeSales.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeSales.Text = "1,234,567,890";
            this.ThisTimeSales.Top = 0F;
            this.ThisTimeSales.Width = 0.8125F;
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
            this.ThisRgdsDisPric.Left = 6.1875F;
            this.ThisRgdsDisPric.MultiLine = false;
            this.ThisRgdsDisPric.Name = "ThisRgdsDisPric";
            this.ThisRgdsDisPric.OutputFormat = resources.GetString("ThisRgdsDisPric.OutputFormat");
            this.ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisRgdsDisPric.Text = "123456789012";
            this.ThisRgdsDisPric.Top = 0F;
            this.ThisRgdsDisPric.Width = 0.8125F;
            // 
            // ClaimCode
            // 
            this.ClaimCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.DataField = "ClaimCode";
            this.ClaimCode.Height = 0.125F;
            this.ClaimCode.Left = 0F;
            this.ClaimCode.MultiLine = false;
            this.ClaimCode.Name = "ClaimCode";
            this.ClaimCode.OutputFormat = resources.GetString("ClaimCode.OutputFormat");
            this.ClaimCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.ClaimCode.Text = "12345678";
            this.ClaimCode.Top = 0F;
            this.ClaimCode.Width = 0.5625F;
            // 
            // ClaimSnm
            // 
            this.ClaimSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.DataField = "ClaimSnm";
            this.ClaimSnm.Height = 0.125F;
            this.ClaimSnm.Left = 0.625F;
            this.ClaimSnm.MultiLine = false;
            this.ClaimSnm.Name = "ClaimSnm";
            this.ClaimSnm.OutputFormat = resources.GetString("ClaimSnm.OutputFormat");
            this.ClaimSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ClaimSnm.Text = "請求名称５６７８９０１２３４５６７８９０";
            this.ClaimSnm.Top = 0F;
            this.ClaimSnm.Width = 2.25F;
            // 
            // PureSales
            // 
            this.PureSales.Border.BottomColor = System.Drawing.Color.Black;
            this.PureSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSales.Border.LeftColor = System.Drawing.Color.Black;
            this.PureSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSales.Border.RightColor = System.Drawing.Color.Black;
            this.PureSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSales.Border.TopColor = System.Drawing.Color.Black;
            this.PureSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSales.DataField = "PureSales";
            this.PureSales.Height = 0.125F;
            this.PureSales.Left = 7F;
            this.PureSales.MultiLine = false;
            this.PureSales.Name = "PureSales";
            this.PureSales.OutputFormat = resources.GetString("PureSales.OutputFormat");
            this.PureSales.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PureSales.Text = "123456789012";
            this.PureSales.Top = 0F;
            this.PureSales.Width = 0.8125F;
            // 
            // OfsThisSalesTax
            // 
            this.OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.OfsThisSalesTax.Height = 0.125F;
            this.OfsThisSalesTax.Left = 7.8125F;
            this.OfsThisSalesTax.MultiLine = false;
            this.OfsThisSalesTax.Name = "OfsThisSalesTax";
            this.OfsThisSalesTax.OutputFormat = resources.GetString("OfsThisSalesTax.OutputFormat");
            this.OfsThisSalesTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OfsThisSalesTax.Text = "123456789012";
            this.OfsThisSalesTax.Top = 0F;
            this.OfsThisSalesTax.Width = 0.8125F;
            // 
            // SalesSlipCount
            // 
            this.SalesSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCount.DataField = "SalesSlipCount";
            this.SalesSlipCount.Height = 0.125F;
            this.SalesSlipCount.Left = 10.25F;
            this.SalesSlipCount.MultiLine = false;
            this.SalesSlipCount.Name = "SalesSlipCount";
            this.SalesSlipCount.OutputFormat = resources.GetString("SalesSlipCount.OutputFormat");
            this.SalesSlipCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesSlipCount.Text = "123,456";
            this.SalesSlipCount.Top = 0F;
            this.SalesSlipCount.Width = 0.5F;
            // 
            // SalesPricTax
            // 
            this.SalesPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.SalesPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.SalesPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesPricTax.DataField = "SalesPricTax";
            this.SalesPricTax.Height = 0.125F;
            this.SalesPricTax.Left = 8.625F;
            this.SalesPricTax.MultiLine = false;
            this.SalesPricTax.Name = "SalesPricTax";
            this.SalesPricTax.OutputFormat = resources.GetString("SalesPricTax.OutputFormat");
            this.SalesPricTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesPricTax.Text = "123456789012";
            this.SalesPricTax.Top = 0F;
            this.SalesPricTax.Width = 0.8125F;
            // 
            // AfCalTMonthAccRec
            // 
            this.AfCalTMonthAccRec.Border.BottomColor = System.Drawing.Color.Black;
            this.AfCalTMonthAccRec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalTMonthAccRec.Border.LeftColor = System.Drawing.Color.Black;
            this.AfCalTMonthAccRec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalTMonthAccRec.Border.RightColor = System.Drawing.Color.Black;
            this.AfCalTMonthAccRec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalTMonthAccRec.Border.TopColor = System.Drawing.Color.Black;
            this.AfCalTMonthAccRec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalTMonthAccRec.DataField = "AfCalTMonthAccRec";
            this.AfCalTMonthAccRec.Height = 0.125F;
            this.AfCalTMonthAccRec.Left = 9.4375F;
            this.AfCalTMonthAccRec.MultiLine = false;
            this.AfCalTMonthAccRec.Name = "AfCalTMonthAccRec";
            this.AfCalTMonthAccRec.OutputFormat = resources.GetString("AfCalTMonthAccRec.OutputFormat");
            this.AfCalTMonthAccRec.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AfCalTMonthAccRec.Text = "123456789012";
            this.AfCalTMonthAccRec.Top = 0F;
            this.AfCalTMonthAccRec.Width = 0.8125F;
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
            this.CashDeposit.Height = 0.125F;
            this.CashDeposit.Left = 2.9375F;
            this.CashDeposit.MultiLine = false;
            this.CashDeposit.Name = "CashDeposit";
            this.CashDeposit.OutputFormat = resources.GetString("CashDeposit.OutputFormat");
            this.CashDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CashDeposit.Text = "11,234,567,890";
            this.CashDeposit.Top = 0.125F;
            this.CashDeposit.Width = 0.8125F;
            // 
            // TrfrDeposit
            // 
            this.TrfrDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.TrfrDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.TrfrDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.TrfrDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.TrfrDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrDeposit.DataField = "TrfrDeposit";
            this.TrfrDeposit.Height = 0.125F;
            this.TrfrDeposit.Left = 3.75F;
            this.TrfrDeposit.MultiLine = false;
            this.TrfrDeposit.Name = "TrfrDeposit";
            this.TrfrDeposit.OutputFormat = resources.GetString("TrfrDeposit.OutputFormat");
            this.TrfrDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TrfrDeposit.Text = "11,234,567,890";
            this.TrfrDeposit.Top = 0.125F;
            this.TrfrDeposit.Width = 0.8125F;
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
            this.CheckDeposit.Height = 0.125F;
            this.CheckDeposit.Left = 4.5625F;
            this.CheckDeposit.MultiLine = false;
            this.CheckDeposit.Name = "CheckDeposit";
            this.CheckDeposit.OutputFormat = resources.GetString("CheckDeposit.OutputFormat");
            this.CheckDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CheckDeposit.Text = "11,234,567,890";
            this.CheckDeposit.Top = 0.125F;
            this.CheckDeposit.Width = 0.8125F;
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
            this.DraftDeposit.Height = 0.125F;
            this.DraftDeposit.Left = 5.375F;
            this.DraftDeposit.MultiLine = false;
            this.DraftDeposit.Name = "DraftDeposit";
            this.DraftDeposit.OutputFormat = resources.GetString("DraftDeposit.OutputFormat");
            this.DraftDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DraftDeposit.Text = "11,234,567,890";
            this.DraftDeposit.Top = 0.125F;
            this.DraftDeposit.Width = 0.8125F;
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
            this.OffsetDeposit.Height = 0.125F;
            this.OffsetDeposit.Left = 6.1875F;
            this.OffsetDeposit.MultiLine = false;
            this.OffsetDeposit.Name = "OffsetDeposit";
            this.OffsetDeposit.OutputFormat = resources.GetString("OffsetDeposit.OutputFormat");
            this.OffsetDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OffsetDeposit.Text = "11,234,567,890";
            this.OffsetDeposit.Top = 0.125F;
            this.OffsetDeposit.Width = 0.8125F;
            // 
            // FundTransferDeposit
            // 
            this.FundTransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.FundTransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.FundTransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.FundTransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.FundTransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferDeposit.DataField = "FundTransferDeposit";
            this.FundTransferDeposit.Height = 0.125F;
            this.FundTransferDeposit.Left = 7.8125F;
            this.FundTransferDeposit.MultiLine = false;
            this.FundTransferDeposit.Name = "FundTransferDeposit";
            this.FundTransferDeposit.OutputFormat = resources.GetString("FundTransferDeposit.OutputFormat");
            this.FundTransferDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.FundTransferDeposit.Text = "11,234,567,890";
            this.FundTransferDeposit.Top = 0.125F;
            this.FundTransferDeposit.Width = 0.8125F;
            // 
            // OthsDeposit
            // 
            this.OthsDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.OthsDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.OthsDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.OthsDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.OthsDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsDeposit.DataField = "OthsDeposit";
            this.OthsDeposit.Height = 0.125F;
            this.OthsDeposit.Left = 7F;
            this.OthsDeposit.MultiLine = false;
            this.OthsDeposit.Name = "OthsDeposit";
            this.OthsDeposit.OutputFormat = resources.GetString("OthsDeposit.OutputFormat");
            this.OthsDeposit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OthsDeposit.Text = "11,234,567,890";
            this.OthsDeposit.Top = 0.125F;
            this.OthsDeposit.Width = 0.8125F;
            // 
            // ThisTimeFeeDmdNrml
            // 
            this.ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.ThisTimeFeeDmdNrml.Height = 0.125F;
            this.ThisTimeFeeDmdNrml.Left = 8.625F;
            this.ThisTimeFeeDmdNrml.MultiLine = false;
            this.ThisTimeFeeDmdNrml.Name = "ThisTimeFeeDmdNrml";
            this.ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("ThisTimeFeeDmdNrml.OutputFormat");
            this.ThisTimeFeeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeFeeDmdNrml.Text = "11,234,567,890";
            this.ThisTimeFeeDmdNrml.Top = 0.125F;
            this.ThisTimeFeeDmdNrml.Width = 0.8125F;
            // 
            // ThisTimeDisDmdNrml
            // 
            this.ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.ThisTimeDisDmdNrml.Height = 0.125F;
            this.ThisTimeDisDmdNrml.Left = 9.4375F;
            this.ThisTimeDisDmdNrml.MultiLine = false;
            this.ThisTimeDisDmdNrml.Name = "ThisTimeDisDmdNrml";
            this.ThisTimeDisDmdNrml.OutputFormat = resources.GetString("ThisTimeDisDmdNrml.OutputFormat");
            this.ThisTimeDisDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeDisDmdNrml.Text = "11,234,567,890";
            this.ThisTimeDisDmdNrml.Top = 0.125F;
            this.ThisTimeDisDmdNrml.Width = 0.8125F;
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
            this.Line13.Width = 10.8F;
            this.Line13.X1 = 0F;
            this.Line13.X2 = 10.8F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0F;
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
            this.tb_ReportTitle.Text = "売掛残高一覧表(総括)";
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
            this.tb_SortOrderName.Text = "[ソート条件]";
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
            this.ExtraHeader.Height = 0.3229167F;
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
            this.Label_Tax.Left = 7.3125F;
            this.Label_Tax.MultiLine = false;
            this.Label_Tax.Name = "Label_Tax";
            this.Label_Tax.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.Label_Tax.Text = "「当該月は、月次更新未処理です」";
            this.Label_Tax.Top = 0.125F;
            this.Label_Tax.Visible = false;
            this.Label_Tax.Width = 1.8125F;
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
            this.Claim_Label,
            this.Label105,
            this.Label106,
            this.Label107,
            this.Line42,
            this.Label2,
            this.Label5,
            this.Label7,
            this.Label8,
            this.label3,
            this.label6,
            this.SalesArea_Label,
            this.label11,
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
            this.TitleHeader.Height = 0.46875F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Claim_Label
            // 
            this.Claim_Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Claim_Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Claim_Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Claim_Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Claim_Label.Border.RightColor = System.Drawing.Color.Black;
            this.Claim_Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Claim_Label.Border.TopColor = System.Drawing.Color.Black;
            this.Claim_Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Claim_Label.Height = 0.1875F;
            this.Claim_Label.HyperLink = "";
            this.Claim_Label.Left = 0F;
            this.Claim_Label.MultiLine = false;
            this.Claim_Label.Name = "Claim_Label";
            this.Claim_Label.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Claim_Label.Text = "得意先";
            this.Claim_Label.Top = 0.1875F;
            this.Claim_Label.Width = 0.5625F;
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
            this.Label105.Left = 3.125F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label105.Text = "前月末残高";
            this.Label105.Top = 0F;
            this.Label105.Width = 0.625F;
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
            this.Label106.Left = 3.875F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label106.Text = "当月入金";
            this.Label106.Top = 0F;
            this.Label106.Width = 0.6875F;
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
            this.Label107.Left = 4.6875F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label107.Text = "繰越額";
            this.Label107.Top = 0F;
            this.Label107.Width = 0.6875F;
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
            this.Label2.Left = 5.5F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label2.Text = "売上額";
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
            this.Label5.Left = 6.3125F;
            this.Label5.MultiLine = false;
            this.Label5.Name = "Label5";
            this.Label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label5.Text = "返品値引";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.6875F;
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
            this.Label7.Left = 7.1875F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label7.Text = "純売上額";
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
            this.Label8.Left = 8F;
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
            this.label3.Left = 8.75F;
            this.label3.MultiLine = false;
            this.label3.Name = "label3";
            this.label3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label3.Text = "当月合計";
            this.label3.Top = 0F;
            this.label3.Width = 0.6875F;
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
            this.label6.Left = 9.5625F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label6.Text = "当月末残高";
            this.label6.Top = 0F;
            this.label6.Width = 0.6875F;
            // 
            // SalesArea_Label
            // 
            this.SalesArea_Label.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesArea_Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesArea_Label.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesArea_Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesArea_Label.Border.RightColor = System.Drawing.Color.Black;
            this.SalesArea_Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesArea_Label.Border.TopColor = System.Drawing.Color.Black;
            this.SalesArea_Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesArea_Label.Height = 0.1875F;
            this.SalesArea_Label.HyperLink = "";
            this.SalesArea_Label.Left = 2F;
            this.SalesArea_Label.MultiLine = false;
            this.SalesArea_Label.Name = "SalesArea_Label";
            this.SalesArea_Label.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.SalesArea_Label.Text = "地区";
            this.SalesArea_Label.Top = 0F;
            this.SalesArea_Label.Width = 0.5625F;
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
            this.label11.Height = 0.1875F;
            this.label11.HyperLink = "";
            this.label11.Left = 10.3125F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label11.Text = "枚数";
            this.label11.Top = 0F;
            this.label11.Width = 0.4375F;
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
            this.Label_Payee1.Left = 3.125F;
            this.Label_Payee1.MultiLine = false;
            this.Label_Payee1.Name = "Label_Payee1";
            this.Label_Payee1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee1.Text = "現金";
            this.Label_Payee1.Top = 0.1875F;
            this.Label_Payee1.Width = 0.625F;
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
            this.Label_Payee2.Left = 3.875F;
            this.Label_Payee2.MultiLine = false;
            this.Label_Payee2.Name = "Label_Payee2";
            this.Label_Payee2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee2.Text = "振込";
            this.Label_Payee2.Top = 0.1875F;
            this.Label_Payee2.Width = 0.6875F;
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
            this.Label_Payee3.Left = 4.6875F;
            this.Label_Payee3.MultiLine = false;
            this.Label_Payee3.Name = "Label_Payee3";
            this.Label_Payee3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee3.Text = "小切手";
            this.Label_Payee3.Top = 0.1875F;
            this.Label_Payee3.Width = 0.6875F;
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
            this.Label_Payee4.Left = 5.5F;
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
            this.Label_Payee5.Left = 6.3125F;
            this.Label_Payee5.MultiLine = false;
            this.Label_Payee5.Name = "Label_Payee5";
            this.Label_Payee5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee5.Text = "相殺";
            this.Label_Payee5.Top = 0.1875F;
            this.Label_Payee5.Width = 0.6875F;
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
            this.Label_Payee6.Left = 7.1875F;
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
            this.Label_Payee7.Left = 8F;
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
            this.Label_Payee8.Left = 8.8125F;
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
            this.Label_Payee9.Left = 9.5625F;
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
            this.GrandTotalHeader.Height = 0.01041667F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label109,
            this.Line43,
            this.Total_LastTimeAccRec,
            this.Total_ThisTimeDmdNrml,
            this.Total_ThisTimeTtlBlcAcc,
            this.g_PureSales,
            this.g_ThisTimeSales,
            this.g_ThisRgdsDisPric,
            this.Total_OfsThisSalesTax,
            this.Total_SalesSlipCount,
            this.Total_SalesPricTax,
            this.Total_AfCalTMonthAccRec,
            this.g_CashDeposit,
            this.g_TrfrDeposit,
            this.g_CheckDeposit,
            this.g_DraftDeposit,
            this.g_OffsetDeposit,
            this.g_FundTransferDeposit,
            this.g_OthsDeposit,
            this.g_ThisTimeFeeDmdNrml,
            this.g_ThisTimeDisDmdNrml});
            this.GrandTotalFooter.Height = 0.3541667F;
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
            // Total_LastTimeAccRec
            // 
            this.Total_LastTimeAccRec.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccRec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccRec.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccRec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccRec.Border.RightColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccRec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccRec.Border.TopColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccRec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccRec.DataField = "LastTimeAccRec";
            this.Total_LastTimeAccRec.Height = 0.125F;
            this.Total_LastTimeAccRec.Left = 2.9375F;
            this.Total_LastTimeAccRec.MultiLine = false;
            this.Total_LastTimeAccRec.Name = "Total_LastTimeAccRec";
            this.Total_LastTimeAccRec.OutputFormat = resources.GetString("Total_LastTimeAccRec.OutputFormat");
            this.Total_LastTimeAccRec.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_LastTimeAccRec.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_LastTimeAccRec.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_LastTimeAccRec.Text = "1,234,567,890";
            this.Total_LastTimeAccRec.Top = 0F;
            this.Total_LastTimeAccRec.Width = 0.8125F;
            // 
            // Total_ThisTimeDmdNrml
            // 
            this.Total_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.Total_ThisTimeDmdNrml.Height = 0.125F;
            this.Total_ThisTimeDmdNrml.Left = 3.75F;
            this.Total_ThisTimeDmdNrml.MultiLine = false;
            this.Total_ThisTimeDmdNrml.Name = "Total_ThisTimeDmdNrml";
            this.Total_ThisTimeDmdNrml.OutputFormat = resources.GetString("Total_ThisTimeDmdNrml.OutputFormat");
            this.Total_ThisTimeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimeDmdNrml.Text = "1,234,567,890";
            this.Total_ThisTimeDmdNrml.Top = 0F;
            this.Total_ThisTimeDmdNrml.Width = 0.8125F;
            // 
            // Total_ThisTimeTtlBlcAcc
            // 
            this.Total_ThisTimeTtlBlcAcc.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcc.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcc.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcc.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcc.DataField = "ThisTimeTtlBlcAcc";
            this.Total_ThisTimeTtlBlcAcc.Height = 0.125F;
            this.Total_ThisTimeTtlBlcAcc.Left = 4.5625F;
            this.Total_ThisTimeTtlBlcAcc.MultiLine = false;
            this.Total_ThisTimeTtlBlcAcc.Name = "Total_ThisTimeTtlBlcAcc";
            this.Total_ThisTimeTtlBlcAcc.OutputFormat = resources.GetString("Total_ThisTimeTtlBlcAcc.OutputFormat");
            this.Total_ThisTimeTtlBlcAcc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimeTtlBlcAcc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimeTtlBlcAcc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimeTtlBlcAcc.Text = "1,234,567,890";
            this.Total_ThisTimeTtlBlcAcc.Top = 0F;
            this.Total_ThisTimeTtlBlcAcc.Width = 0.8125F;
            // 
            // g_PureSales
            // 
            this.g_PureSales.Border.BottomColor = System.Drawing.Color.Black;
            this.g_PureSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureSales.Border.LeftColor = System.Drawing.Color.Black;
            this.g_PureSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureSales.Border.RightColor = System.Drawing.Color.Black;
            this.g_PureSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureSales.Border.TopColor = System.Drawing.Color.Black;
            this.g_PureSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureSales.DataField = "PureSales";
            this.g_PureSales.Height = 0.125F;
            this.g_PureSales.Left = 7F;
            this.g_PureSales.MultiLine = false;
            this.g_PureSales.Name = "g_PureSales";
            this.g_PureSales.OutputFormat = resources.GetString("g_PureSales.OutputFormat");
            this.g_PureSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_PureSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_PureSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_PureSales.Text = "1,234,567,890";
            this.g_PureSales.Top = 0F;
            this.g_PureSales.Width = 0.8125F;
            // 
            // g_ThisTimeSales
            // 
            this.g_ThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeSales.DataField = "ThisTimeSales";
            this.g_ThisTimeSales.Height = 0.125F;
            this.g_ThisTimeSales.Left = 5.375F;
            this.g_ThisTimeSales.MultiLine = false;
            this.g_ThisTimeSales.Name = "g_ThisTimeSales";
            this.g_ThisTimeSales.OutputFormat = resources.GetString("g_ThisTimeSales.OutputFormat");
            this.g_ThisTimeSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeSales.Text = "1,234,567,890";
            this.g_ThisTimeSales.Top = 0F;
            this.g_ThisTimeSales.Width = 0.8125F;
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
            this.g_ThisRgdsDisPric.Left = 6.1875F;
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
            // Total_OfsThisSalesTax
            // 
            this.Total_OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.Total_OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.Total_OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.Total_OfsThisSalesTax.Height = 0.125F;
            this.Total_OfsThisSalesTax.Left = 7.8125F;
            this.Total_OfsThisSalesTax.MultiLine = false;
            this.Total_OfsThisSalesTax.Name = "Total_OfsThisSalesTax";
            this.Total_OfsThisSalesTax.OutputFormat = resources.GetString("Total_OfsThisSalesTax.OutputFormat");
            this.Total_OfsThisSalesTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_OfsThisSalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_OfsThisSalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_OfsThisSalesTax.Text = "1,234,567,890";
            this.Total_OfsThisSalesTax.Top = 0F;
            this.Total_OfsThisSalesTax.Width = 0.8125F;
            // 
            // Total_SalesSlipCount
            // 
            this.Total_SalesSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_SalesSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_SalesSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.Total_SalesSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.Total_SalesSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesSlipCount.DataField = "SalesSlipCount";
            this.Total_SalesSlipCount.Height = 0.125F;
            this.Total_SalesSlipCount.Left = 10.25F;
            this.Total_SalesSlipCount.MultiLine = false;
            this.Total_SalesSlipCount.Name = "Total_SalesSlipCount";
            this.Total_SalesSlipCount.OutputFormat = resources.GetString("Total_SalesSlipCount.OutputFormat");
            this.Total_SalesSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_SalesSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_SalesSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_SalesSlipCount.Text = "123,456";
            this.Total_SalesSlipCount.Top = 0F;
            this.Total_SalesSlipCount.Width = 0.5F;
            // 
            // Total_SalesPricTax
            // 
            this.Total_SalesPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_SalesPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_SalesPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.Total_SalesPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.Total_SalesPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_SalesPricTax.DataField = "SalesPricTax";
            this.Total_SalesPricTax.Height = 0.125F;
            this.Total_SalesPricTax.Left = 8.625F;
            this.Total_SalesPricTax.MultiLine = false;
            this.Total_SalesPricTax.Name = "Total_SalesPricTax";
            this.Total_SalesPricTax.OutputFormat = resources.GetString("Total_SalesPricTax.OutputFormat");
            this.Total_SalesPricTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_SalesPricTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_SalesPricTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_SalesPricTax.Text = "1,234,567,890";
            this.Total_SalesPricTax.Top = 0F;
            this.Total_SalesPricTax.Width = 0.8125F;
            // 
            // Total_AfCalTMonthAccRec
            // 
            this.Total_AfCalTMonthAccRec.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_AfCalTMonthAccRec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfCalTMonthAccRec.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_AfCalTMonthAccRec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfCalTMonthAccRec.Border.RightColor = System.Drawing.Color.Black;
            this.Total_AfCalTMonthAccRec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfCalTMonthAccRec.Border.TopColor = System.Drawing.Color.Black;
            this.Total_AfCalTMonthAccRec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfCalTMonthAccRec.DataField = "AfCalTMonthAccRec";
            this.Total_AfCalTMonthAccRec.Height = 0.125F;
            this.Total_AfCalTMonthAccRec.Left = 9.4375F;
            this.Total_AfCalTMonthAccRec.MultiLine = false;
            this.Total_AfCalTMonthAccRec.Name = "Total_AfCalTMonthAccRec";
            this.Total_AfCalTMonthAccRec.OutputFormat = resources.GetString("Total_AfCalTMonthAccRec.OutputFormat");
            this.Total_AfCalTMonthAccRec.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_AfCalTMonthAccRec.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_AfCalTMonthAccRec.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_AfCalTMonthAccRec.Text = "1,234,567,890";
            this.Total_AfCalTMonthAccRec.Top = 0F;
            this.Total_AfCalTMonthAccRec.Width = 0.8125F;
            // 
            // g_CashDeposit
            // 
            this.g_CashDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CashDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CashDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_CashDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_CashDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit.DataField = "CashDeposit";
            this.g_CashDeposit.Height = 0.125F;
            this.g_CashDeposit.Left = 2.9375F;
            this.g_CashDeposit.MultiLine = false;
            this.g_CashDeposit.Name = "g_CashDeposit";
            this.g_CashDeposit.OutputFormat = resources.GetString("g_CashDeposit.OutputFormat");
            this.g_CashDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CashDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CashDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CashDeposit.Text = "1,234,567,890";
            this.g_CashDeposit.Top = 0.125F;
            this.g_CashDeposit.Width = 0.8125F;
            // 
            // g_TrfrDeposit
            // 
            this.g_TrfrDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit.DataField = "TrfrDeposit";
            this.g_TrfrDeposit.Height = 0.125F;
            this.g_TrfrDeposit.Left = 3.75F;
            this.g_TrfrDeposit.MultiLine = false;
            this.g_TrfrDeposit.Name = "g_TrfrDeposit";
            this.g_TrfrDeposit.OutputFormat = resources.GetString("g_TrfrDeposit.OutputFormat");
            this.g_TrfrDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TrfrDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TrfrDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TrfrDeposit.Text = "1,234,567,890";
            this.g_TrfrDeposit.Top = 0.125F;
            this.g_TrfrDeposit.Width = 0.8125F;
            // 
            // g_CheckDeposit
            // 
            this.g_CheckDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CheckDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CheckDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_CheckDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_CheckDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit.DataField = "CheckDeposit";
            this.g_CheckDeposit.Height = 0.125F;
            this.g_CheckDeposit.Left = 4.5625F;
            this.g_CheckDeposit.MultiLine = false;
            this.g_CheckDeposit.Name = "g_CheckDeposit";
            this.g_CheckDeposit.OutputFormat = resources.GetString("g_CheckDeposit.OutputFormat");
            this.g_CheckDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CheckDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CheckDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CheckDeposit.Text = "1,234,567,890";
            this.g_CheckDeposit.Top = 0.125F;
            this.g_CheckDeposit.Width = 0.8125F;
            // 
            // g_DraftDeposit
            // 
            this.g_DraftDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_DraftDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_DraftDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_DraftDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_DraftDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit.DataField = "DraftDeposit";
            this.g_DraftDeposit.Height = 0.125F;
            this.g_DraftDeposit.Left = 5.375F;
            this.g_DraftDeposit.MultiLine = false;
            this.g_DraftDeposit.Name = "g_DraftDeposit";
            this.g_DraftDeposit.OutputFormat = resources.GetString("g_DraftDeposit.OutputFormat");
            this.g_DraftDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_DraftDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_DraftDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_DraftDeposit.Text = "1,234,567,890";
            this.g_DraftDeposit.Top = 0.125F;
            this.g_DraftDeposit.Width = 0.8125F;
            // 
            // g_OffsetDeposit
            // 
            this.g_OffsetDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit.DataField = "OffsetDeposit";
            this.g_OffsetDeposit.Height = 0.125F;
            this.g_OffsetDeposit.Left = 6.1875F;
            this.g_OffsetDeposit.MultiLine = false;
            this.g_OffsetDeposit.Name = "g_OffsetDeposit";
            this.g_OffsetDeposit.OutputFormat = resources.GetString("g_OffsetDeposit.OutputFormat");
            this.g_OffsetDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OffsetDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OffsetDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OffsetDeposit.Text = "1,234,567,890";
            this.g_OffsetDeposit.Top = 0.125F;
            this.g_OffsetDeposit.Width = 0.8125F;
            // 
            // g_FundTransferDeposit
            // 
            this.g_FundTransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit.DataField = "FundTransferDeposit";
            this.g_FundTransferDeposit.Height = 0.125F;
            this.g_FundTransferDeposit.Left = 7.8125F;
            this.g_FundTransferDeposit.MultiLine = false;
            this.g_FundTransferDeposit.Name = "g_FundTransferDeposit";
            this.g_FundTransferDeposit.OutputFormat = resources.GetString("g_FundTransferDeposit.OutputFormat");
            this.g_FundTransferDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_FundTransferDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_FundTransferDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_FundTransferDeposit.Text = "1,234,567,890";
            this.g_FundTransferDeposit.Top = 0.125F;
            this.g_FundTransferDeposit.Width = 0.8125F;
            // 
            // g_OthsDeposit
            // 
            this.g_OthsDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OthsDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OthsDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.g_OthsDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.g_OthsDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit.DataField = "OthsDeposit";
            this.g_OthsDeposit.Height = 0.125F;
            this.g_OthsDeposit.Left = 7F;
            this.g_OthsDeposit.MultiLine = false;
            this.g_OthsDeposit.Name = "g_OthsDeposit";
            this.g_OthsDeposit.OutputFormat = resources.GetString("g_OthsDeposit.OutputFormat");
            this.g_OthsDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OthsDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OthsDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OthsDeposit.Text = "1,234,567,890";
            this.g_OthsDeposit.Top = 0.125F;
            this.g_OthsDeposit.Width = 0.8125F;
            // 
            // g_ThisTimeFeeDmdNrml
            // 
            this.g_ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.g_ThisTimeFeeDmdNrml.Height = 0.125F;
            this.g_ThisTimeFeeDmdNrml.Left = 8.625F;
            this.g_ThisTimeFeeDmdNrml.MultiLine = false;
            this.g_ThisTimeFeeDmdNrml.Name = "g_ThisTimeFeeDmdNrml";
            this.g_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("g_ThisTimeFeeDmdNrml.OutputFormat");
            this.g_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeFeeDmdNrml.Text = "1,234,567,890";
            this.g_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.g_ThisTimeFeeDmdNrml.Width = 0.8125F;
            // 
            // g_ThisTimeDisDmdNrml
            // 
            this.g_ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.g_ThisTimeDisDmdNrml.Height = 0.125F;
            this.g_ThisTimeDisDmdNrml.Left = 9.4375F;
            this.g_ThisTimeDisDmdNrml.MultiLine = false;
            this.g_ThisTimeDisDmdNrml.Name = "g_ThisTimeDisDmdNrml";
            this.g_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("g_ThisTimeDisDmdNrml.OutputFormat");
            this.g_ThisTimeDisDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDisDmdNrml.Text = "1,234,567,890";
            this.g_ThisTimeDisDmdNrml.Top = 0.125F;
            this.g_ThisTimeDisDmdNrml.Width = 0.8125F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.AddUpSecCode,
            this.AddUpSecName,
            this.line2,
            this.MonAddUpNonProc});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0.1979167F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.DataField = "AddUpSecCode";
            this.AddUpSecCode.Height = 0.125F;
            this.AddUpSecCode.Left = 0F;
            this.AddUpSecCode.MultiLine = false;
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.OutputFormat = resources.GetString("AddUpSecCode.OutputFormat");
            this.AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-" +
                "space: inherit; vertical-align: top; ";
            this.AddUpSecCode.Text = "00";
            this.AddUpSecCode.Top = 0F;
            this.AddUpSecCode.Visible = false;
            this.AddUpSecCode.Width = 0.1875F;
            // 
            // AddUpSecName
            // 
            this.AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.DataField = "SectionGuideSnm";
            this.AddUpSecName.Height = 0.125F;
            this.AddUpSecName.Left = 0.25F;
            this.AddUpSecName.MultiLine = false;
            this.AddUpSecName.Name = "AddUpSecName";
            this.AddUpSecName.Style = "text-align: left; font-size: 8pt; white-space: inherit; vertical-align: top; ";
            this.AddUpSecName.Text = "拠点３４５６７８９０";
            this.AddUpSecName.Top = 0F;
            this.AddUpSecName.Visible = false;
            this.AddUpSecName.Width = 1.1875F;
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
            this.Section_LastTimeAccRec,
            this.Section_ThisTimeDmdNrml,
            this.Section_ThisTimeTtlBlcAcc,
            this.Section_OfsThisSalesTax,
            this.s_ThisTimeSales,
            this.s_ThisRgdsDisPric,
            this.s_PureSales,
            this.Section_SalesSlipCount,
            this.Section_SalesPricTax,
            this.Section_AfCalTMonthAccRec,
            this.s_CashDeposit,
            this.s_TrfrDeposit,
            this.s_CheckDeposit,
            this.s_DraftDeposit,
            this.s_OffsetDeposit,
            this.s_FundTransferDeposit,
            this.s_OthsDeposit,
            this.s_ThisTimeFeeDmdNrml,
            this.s_ThisTimeDisDmdNrml});
            this.SectionFooter.Height = 0.3541667F;
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
            this.MONEYKINDNAME13.Height = 0.1875F;
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
            // Section_LastTimeAccRec
            // 
            this.Section_LastTimeAccRec.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccRec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccRec.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccRec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccRec.Border.RightColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccRec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccRec.Border.TopColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccRec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccRec.DataField = "LastTimeAccRec";
            this.Section_LastTimeAccRec.Height = 0.125F;
            this.Section_LastTimeAccRec.Left = 2.9375F;
            this.Section_LastTimeAccRec.MultiLine = false;
            this.Section_LastTimeAccRec.Name = "Section_LastTimeAccRec";
            this.Section_LastTimeAccRec.OutputFormat = resources.GetString("Section_LastTimeAccRec.OutputFormat");
            this.Section_LastTimeAccRec.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_LastTimeAccRec.SummaryGroup = "SectionHeader";
            this.Section_LastTimeAccRec.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_LastTimeAccRec.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_LastTimeAccRec.Text = "1,234,567,890";
            this.Section_LastTimeAccRec.Top = 0F;
            this.Section_LastTimeAccRec.Width = 0.8125F;
            // 
            // Section_ThisTimeDmdNrml
            // 
            this.Section_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.Section_ThisTimeDmdNrml.Height = 0.125F;
            this.Section_ThisTimeDmdNrml.Left = 3.75F;
            this.Section_ThisTimeDmdNrml.MultiLine = false;
            this.Section_ThisTimeDmdNrml.Name = "Section_ThisTimeDmdNrml";
            this.Section_ThisTimeDmdNrml.OutputFormat = resources.GetString("Section_ThisTimeDmdNrml.OutputFormat");
            this.Section_ThisTimeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimeDmdNrml.SummaryGroup = "SectionHeader";
            this.Section_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimeDmdNrml.Text = "1,234,567,890";
            this.Section_ThisTimeDmdNrml.Top = 0F;
            this.Section_ThisTimeDmdNrml.Width = 0.8125F;
            // 
            // Section_ThisTimeTtlBlcAcc
            // 
            this.Section_ThisTimeTtlBlcAcc.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcc.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcc.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcc.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcc.DataField = "ThisTimeTtlBlcAcc";
            this.Section_ThisTimeTtlBlcAcc.Height = 0.125F;
            this.Section_ThisTimeTtlBlcAcc.Left = 4.5625F;
            this.Section_ThisTimeTtlBlcAcc.MultiLine = false;
            this.Section_ThisTimeTtlBlcAcc.Name = "Section_ThisTimeTtlBlcAcc";
            this.Section_ThisTimeTtlBlcAcc.OutputFormat = resources.GetString("Section_ThisTimeTtlBlcAcc.OutputFormat");
            this.Section_ThisTimeTtlBlcAcc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimeTtlBlcAcc.SummaryGroup = "SectionHeader";
            this.Section_ThisTimeTtlBlcAcc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimeTtlBlcAcc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimeTtlBlcAcc.Text = "1,234,567,890";
            this.Section_ThisTimeTtlBlcAcc.Top = 0F;
            this.Section_ThisTimeTtlBlcAcc.Width = 0.8125F;
            // 
            // Section_OfsThisSalesTax
            // 
            this.Section_OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.Section_OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.Section_OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.Section_OfsThisSalesTax.Height = 0.125F;
            this.Section_OfsThisSalesTax.Left = 7.8125F;
            this.Section_OfsThisSalesTax.MultiLine = false;
            this.Section_OfsThisSalesTax.Name = "Section_OfsThisSalesTax";
            this.Section_OfsThisSalesTax.OutputFormat = resources.GetString("Section_OfsThisSalesTax.OutputFormat");
            this.Section_OfsThisSalesTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_OfsThisSalesTax.SummaryGroup = "SectionHeader";
            this.Section_OfsThisSalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_OfsThisSalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_OfsThisSalesTax.Text = "1,234,567,890";
            this.Section_OfsThisSalesTax.Top = 0F;
            this.Section_OfsThisSalesTax.Width = 0.8125F;
            // 
            // s_ThisTimeSales
            // 
            this.s_ThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeSales.DataField = "ThisTimeSales";
            this.s_ThisTimeSales.Height = 0.125F;
            this.s_ThisTimeSales.Left = 5.375F;
            this.s_ThisTimeSales.MultiLine = false;
            this.s_ThisTimeSales.Name = "s_ThisTimeSales";
            this.s_ThisTimeSales.OutputFormat = resources.GetString("s_ThisTimeSales.OutputFormat");
            this.s_ThisTimeSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeSales.SummaryGroup = "SectionHeader";
            this.s_ThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeSales.Text = "1,234,567,890";
            this.s_ThisTimeSales.Top = 0F;
            this.s_ThisTimeSales.Width = 0.8125F;
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
            this.s_ThisRgdsDisPric.Left = 6.1875F;
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
            // s_PureSales
            // 
            this.s_PureSales.Border.BottomColor = System.Drawing.Color.Black;
            this.s_PureSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureSales.Border.LeftColor = System.Drawing.Color.Black;
            this.s_PureSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureSales.Border.RightColor = System.Drawing.Color.Black;
            this.s_PureSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureSales.Border.TopColor = System.Drawing.Color.Black;
            this.s_PureSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureSales.DataField = "PureSales";
            this.s_PureSales.Height = 0.125F;
            this.s_PureSales.Left = 7F;
            this.s_PureSales.MultiLine = false;
            this.s_PureSales.Name = "s_PureSales";
            this.s_PureSales.OutputFormat = resources.GetString("s_PureSales.OutputFormat");
            this.s_PureSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_PureSales.SummaryGroup = "SectionHeader";
            this.s_PureSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_PureSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_PureSales.Text = "1,234,567,890";
            this.s_PureSales.Top = 0F;
            this.s_PureSales.Width = 0.8125F;
            // 
            // Section_SalesSlipCount
            // 
            this.Section_SalesSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesSlipCount.DataField = "SalesSlipCount";
            this.Section_SalesSlipCount.Height = 0.125F;
            this.Section_SalesSlipCount.Left = 10.25F;
            this.Section_SalesSlipCount.MultiLine = false;
            this.Section_SalesSlipCount.Name = "Section_SalesSlipCount";
            this.Section_SalesSlipCount.OutputFormat = resources.GetString("Section_SalesSlipCount.OutputFormat");
            this.Section_SalesSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_SalesSlipCount.SummaryGroup = "SectionHeader";
            this.Section_SalesSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesSlipCount.Text = "123,456";
            this.Section_SalesSlipCount.Top = 0F;
            this.Section_SalesSlipCount.Width = 0.5F;
            // 
            // Section_SalesPricTax
            // 
            this.Section_SalesPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPricTax.DataField = "SalesPricTax";
            this.Section_SalesPricTax.Height = 0.125F;
            this.Section_SalesPricTax.Left = 8.625F;
            this.Section_SalesPricTax.MultiLine = false;
            this.Section_SalesPricTax.Name = "Section_SalesPricTax";
            this.Section_SalesPricTax.OutputFormat = resources.GetString("Section_SalesPricTax.OutputFormat");
            this.Section_SalesPricTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_SalesPricTax.SummaryGroup = "SectionHeader";
            this.Section_SalesPricTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesPricTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesPricTax.Text = "1,234,567,890";
            this.Section_SalesPricTax.Top = 0F;
            this.Section_SalesPricTax.Width = 0.8125F;
            // 
            // Section_AfCalTMonthAccRec
            // 
            this.Section_AfCalTMonthAccRec.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_AfCalTMonthAccRec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfCalTMonthAccRec.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_AfCalTMonthAccRec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfCalTMonthAccRec.Border.RightColor = System.Drawing.Color.Black;
            this.Section_AfCalTMonthAccRec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfCalTMonthAccRec.Border.TopColor = System.Drawing.Color.Black;
            this.Section_AfCalTMonthAccRec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfCalTMonthAccRec.DataField = "AfCalTMonthAccRec";
            this.Section_AfCalTMonthAccRec.Height = 0.125F;
            this.Section_AfCalTMonthAccRec.Left = 9.4375F;
            this.Section_AfCalTMonthAccRec.MultiLine = false;
            this.Section_AfCalTMonthAccRec.Name = "Section_AfCalTMonthAccRec";
            this.Section_AfCalTMonthAccRec.OutputFormat = resources.GetString("Section_AfCalTMonthAccRec.OutputFormat");
            this.Section_AfCalTMonthAccRec.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_AfCalTMonthAccRec.SummaryGroup = "SectionHeader";
            this.Section_AfCalTMonthAccRec.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_AfCalTMonthAccRec.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_AfCalTMonthAccRec.Text = "1,234,567,890";
            this.Section_AfCalTMonthAccRec.Top = 0F;
            this.Section_AfCalTMonthAccRec.Width = 0.8125F;
            // 
            // s_CashDeposit
            // 
            this.s_CashDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CashDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CashDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_CashDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_CashDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit.DataField = "CashDeposit";
            this.s_CashDeposit.Height = 0.125F;
            this.s_CashDeposit.Left = 2.9375F;
            this.s_CashDeposit.MultiLine = false;
            this.s_CashDeposit.Name = "s_CashDeposit";
            this.s_CashDeposit.OutputFormat = resources.GetString("s_CashDeposit.OutputFormat");
            this.s_CashDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CashDeposit.SummaryGroup = "SectionHeader";
            this.s_CashDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CashDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CashDeposit.Text = "1,234,567,890";
            this.s_CashDeposit.Top = 0.125F;
            this.s_CashDeposit.Width = 0.8125F;
            // 
            // s_TrfrDeposit
            // 
            this.s_TrfrDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit.DataField = "TrfrDeposit";
            this.s_TrfrDeposit.Height = 0.125F;
            this.s_TrfrDeposit.Left = 3.75F;
            this.s_TrfrDeposit.MultiLine = false;
            this.s_TrfrDeposit.Name = "s_TrfrDeposit";
            this.s_TrfrDeposit.OutputFormat = resources.GetString("s_TrfrDeposit.OutputFormat");
            this.s_TrfrDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TrfrDeposit.SummaryGroup = "SectionHeader";
            this.s_TrfrDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TrfrDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TrfrDeposit.Text = "1,234,567,890";
            this.s_TrfrDeposit.Top = 0.125F;
            this.s_TrfrDeposit.Width = 0.8125F;
            // 
            // s_CheckDeposit
            // 
            this.s_CheckDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CheckDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CheckDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_CheckDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_CheckDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit.DataField = "CheckDeposit";
            this.s_CheckDeposit.Height = 0.125F;
            this.s_CheckDeposit.Left = 4.5625F;
            this.s_CheckDeposit.MultiLine = false;
            this.s_CheckDeposit.Name = "s_CheckDeposit";
            this.s_CheckDeposit.OutputFormat = resources.GetString("s_CheckDeposit.OutputFormat");
            this.s_CheckDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CheckDeposit.SummaryGroup = "SectionHeader";
            this.s_CheckDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CheckDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CheckDeposit.Text = "1,234,567,890";
            this.s_CheckDeposit.Top = 0.125F;
            this.s_CheckDeposit.Width = 0.8125F;
            // 
            // s_DraftDeposit
            // 
            this.s_DraftDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_DraftDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_DraftDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_DraftDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_DraftDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit.DataField = "DraftDeposit";
            this.s_DraftDeposit.Height = 0.125F;
            this.s_DraftDeposit.Left = 5.375F;
            this.s_DraftDeposit.MultiLine = false;
            this.s_DraftDeposit.Name = "s_DraftDeposit";
            this.s_DraftDeposit.OutputFormat = resources.GetString("s_DraftDeposit.OutputFormat");
            this.s_DraftDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_DraftDeposit.SummaryGroup = "SectionHeader";
            this.s_DraftDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DraftDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DraftDeposit.Text = "1,234,567,890";
            this.s_DraftDeposit.Top = 0.125F;
            this.s_DraftDeposit.Width = 0.8125F;
            // 
            // s_OffsetDeposit
            // 
            this.s_OffsetDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit.DataField = "OffsetDeposit";
            this.s_OffsetDeposit.Height = 0.125F;
            this.s_OffsetDeposit.Left = 6.1875F;
            this.s_OffsetDeposit.MultiLine = false;
            this.s_OffsetDeposit.Name = "s_OffsetDeposit";
            this.s_OffsetDeposit.OutputFormat = resources.GetString("s_OffsetDeposit.OutputFormat");
            this.s_OffsetDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OffsetDeposit.SummaryGroup = "SectionHeader";
            this.s_OffsetDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OffsetDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OffsetDeposit.Text = "1,234,567,890";
            this.s_OffsetDeposit.Top = 0.125F;
            this.s_OffsetDeposit.Width = 0.8125F;
            // 
            // s_FundTransferDeposit
            // 
            this.s_FundTransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit.DataField = "FundTransferDeposit";
            this.s_FundTransferDeposit.Height = 0.125F;
            this.s_FundTransferDeposit.Left = 7.8125F;
            this.s_FundTransferDeposit.MultiLine = false;
            this.s_FundTransferDeposit.Name = "s_FundTransferDeposit";
            this.s_FundTransferDeposit.OutputFormat = resources.GetString("s_FundTransferDeposit.OutputFormat");
            this.s_FundTransferDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_FundTransferDeposit.SummaryGroup = "SectionHeader";
            this.s_FundTransferDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_FundTransferDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_FundTransferDeposit.Text = "1,234,567,890";
            this.s_FundTransferDeposit.Top = 0.125F;
            this.s_FundTransferDeposit.Width = 0.8125F;
            // 
            // s_OthsDeposit
            // 
            this.s_OthsDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OthsDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OthsDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.s_OthsDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.s_OthsDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit.DataField = "OthsDeposit";
            this.s_OthsDeposit.Height = 0.125F;
            this.s_OthsDeposit.Left = 7F;
            this.s_OthsDeposit.MultiLine = false;
            this.s_OthsDeposit.Name = "s_OthsDeposit";
            this.s_OthsDeposit.OutputFormat = resources.GetString("s_OthsDeposit.OutputFormat");
            this.s_OthsDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OthsDeposit.SummaryGroup = "SectionHeader";
            this.s_OthsDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OthsDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OthsDeposit.Text = "1,234,567,890";
            this.s_OthsDeposit.Top = 0.125F;
            this.s_OthsDeposit.Width = 0.8125F;
            // 
            // s_ThisTimeFeeDmdNrml
            // 
            this.s_ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.s_ThisTimeFeeDmdNrml.Height = 0.125F;
            this.s_ThisTimeFeeDmdNrml.Left = 8.625F;
            this.s_ThisTimeFeeDmdNrml.MultiLine = false;
            this.s_ThisTimeFeeDmdNrml.Name = "s_ThisTimeFeeDmdNrml";
            this.s_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("s_ThisTimeFeeDmdNrml.OutputFormat");
            this.s_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeFeeDmdNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeeDmdNrml.Text = "1,234,567,890";
            this.s_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.s_ThisTimeFeeDmdNrml.Width = 0.8125F;
            // 
            // s_ThisTimeDisDmdNrml
            // 
            this.s_ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.s_ThisTimeDisDmdNrml.Height = 0.125F;
            this.s_ThisTimeDisDmdNrml.Left = 9.4375F;
            this.s_ThisTimeDisDmdNrml.MultiLine = false;
            this.s_ThisTimeDisDmdNrml.Name = "s_ThisTimeDisDmdNrml";
            this.s_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("s_ThisTimeDisDmdNrml.OutputFormat");
            this.s_ThisTimeDisDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeDisDmdNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisDmdNrml.Text = "1,234,567,890";
            this.s_ThisTimeDisDmdNrml.Top = 0.125F;
            this.s_ThisTimeDisDmdNrml.Width = 0.8125F;
            // 
            // AgentHeader
            // 
            this.AgentHeader.CanShrink = true;
            this.AgentHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CustomerAgentCd,
            this.CustomerAgentNm,
            this.textBox6,
            this.textBox15,
            this.line3});
            this.AgentHeader.Height = 0.2083333F;
            this.AgentHeader.Name = "AgentHeader";
            this.AgentHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // CustomerAgentCd
            // 
            this.CustomerAgentCd.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerAgentCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentCd.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerAgentCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentCd.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerAgentCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentCd.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerAgentCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentCd.DataField = "CustomerAgentCd";
            this.CustomerAgentCd.Height = 0.125F;
            this.CustomerAgentCd.Left = 2F;
            this.CustomerAgentCd.MultiLine = false;
            this.CustomerAgentCd.Name = "CustomerAgentCd";
            this.CustomerAgentCd.OutputFormat = resources.GetString("CustomerAgentCd.OutputFormat");
            this.CustomerAgentCd.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.CustomerAgentCd.Text = "1234";
            this.CustomerAgentCd.Top = 0F;
            this.CustomerAgentCd.Width = 0.3125F;
            // 
            // CustomerAgentNm
            // 
            this.CustomerAgentNm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerAgentNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentNm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerAgentNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentNm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerAgentNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentNm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerAgentNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerAgentNm.DataField = "CustomerAgentNm";
            this.CustomerAgentNm.Height = 0.125F;
            this.CustomerAgentNm.Left = 2.375F;
            this.CustomerAgentNm.MultiLine = false;
            this.CustomerAgentNm.Name = "CustomerAgentNm";
            this.CustomerAgentNm.OutputFormat = resources.GetString("CustomerAgentNm.OutputFormat");
            this.CustomerAgentNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerAgentNm.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.CustomerAgentNm.Top = 0F;
            this.CustomerAgentNm.Width = 3.375F;
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
            this.textBox6.DataField = "AddUpSecCode";
            this.textBox6.Height = 0.125F;
            this.textBox6.Left = 0F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.textBox6.Text = "00";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.1875F;
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
            this.textBox15.DataField = "SectionGuideSnm";
            this.textBox15.Height = 0.125F;
            this.textBox15.Left = 0.25F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.textBox15.Text = "拠点３４５６７８９０";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 1.1875F;
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
            // AgentFooter
            // 
            this.AgentFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_SumTitle,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.a_ThisTimeSales,
            this.a_ThisRgdsDisPric,
            this.a_PureSales,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.a_CashDeposit,
            this.a_TrfrDeposit,
            this.a_CheckDeposit,
            this.a_DraftDeposit,
            this.a_OffsetDeposit,
            this.a_FundTransferDeposit,
            this.a_OthsDeposit,
            this.a_ThisTimeFeeDmdNrml,
            this.a_ThisTimeDisDmdNrml,
            this.line5});
            this.AgentFooter.Height = 0.34375F;
            this.AgentFooter.Name = "AgentFooter";
            // 
            // tb_SumTitle
            // 
            this.tb_SumTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Height = 0.1875F;
            this.tb_SumTitle.Left = 0.1875F;
            this.tb_SumTitle.MultiLine = false;
            this.tb_SumTitle.Name = "tb_SumTitle";
            this.tb_SumTitle.OutputFormat = resources.GetString("tb_SumTitle.OutputFormat");
            this.tb_SumTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SumTitle.Text = "担当者計";
            this.tb_SumTitle.Top = 0.0625F;
            this.tb_SumTitle.Width = 0.6875F;
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
            this.textBox1.DataField = "LastTimeAccRec";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 2.9375F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox1.SummaryGroup = "AgentHeader";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox1.Text = "1,234,567,890";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.8125F;
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
            this.textBox2.DataField = "ThisTimeDmdNrml";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 3.75F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryGroup = "AgentHeader";
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
            this.textBox3.DataField = "ThisTimeTtlBlcAcc";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 4.5625F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox3.SummaryGroup = "AgentHeader";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "1,234,567,890";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.8125F;
            // 
            // a_ThisTimeSales
            // 
            this.a_ThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.a_ThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.a_ThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.a_ThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.a_ThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeSales.DataField = "ThisTimeSales";
            this.a_ThisTimeSales.Height = 0.125F;
            this.a_ThisTimeSales.Left = 5.375F;
            this.a_ThisTimeSales.MultiLine = false;
            this.a_ThisTimeSales.Name = "a_ThisTimeSales";
            this.a_ThisTimeSales.OutputFormat = resources.GetString("a_ThisTimeSales.OutputFormat");
            this.a_ThisTimeSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_ThisTimeSales.SummaryGroup = "AgentHeader";
            this.a_ThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_ThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_ThisTimeSales.Text = "1,234,567,890";
            this.a_ThisTimeSales.Top = 0F;
            this.a_ThisTimeSales.Width = 0.8125F;
            // 
            // a_ThisRgdsDisPric
            // 
            this.a_ThisRgdsDisPric.Border.BottomColor = System.Drawing.Color.Black;
            this.a_ThisRgdsDisPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisRgdsDisPric.Border.LeftColor = System.Drawing.Color.Black;
            this.a_ThisRgdsDisPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisRgdsDisPric.Border.RightColor = System.Drawing.Color.Black;
            this.a_ThisRgdsDisPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisRgdsDisPric.Border.TopColor = System.Drawing.Color.Black;
            this.a_ThisRgdsDisPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisRgdsDisPric.DataField = "ThisRgdsDisPric";
            this.a_ThisRgdsDisPric.Height = 0.125F;
            this.a_ThisRgdsDisPric.Left = 6.1875F;
            this.a_ThisRgdsDisPric.MultiLine = false;
            this.a_ThisRgdsDisPric.Name = "a_ThisRgdsDisPric";
            this.a_ThisRgdsDisPric.OutputFormat = resources.GetString("a_ThisRgdsDisPric.OutputFormat");
            this.a_ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_ThisRgdsDisPric.SummaryGroup = "AgentHeader";
            this.a_ThisRgdsDisPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_ThisRgdsDisPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_ThisRgdsDisPric.Text = "1,234,567,890";
            this.a_ThisRgdsDisPric.Top = 0F;
            this.a_ThisRgdsDisPric.Width = 0.8125F;
            // 
            // a_PureSales
            // 
            this.a_PureSales.Border.BottomColor = System.Drawing.Color.Black;
            this.a_PureSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_PureSales.Border.LeftColor = System.Drawing.Color.Black;
            this.a_PureSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_PureSales.Border.RightColor = System.Drawing.Color.Black;
            this.a_PureSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_PureSales.Border.TopColor = System.Drawing.Color.Black;
            this.a_PureSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_PureSales.DataField = "PureSales";
            this.a_PureSales.Height = 0.125F;
            this.a_PureSales.Left = 7F;
            this.a_PureSales.MultiLine = false;
            this.a_PureSales.Name = "a_PureSales";
            this.a_PureSales.OutputFormat = resources.GetString("a_PureSales.OutputFormat");
            this.a_PureSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_PureSales.SummaryGroup = "AgentHeader";
            this.a_PureSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_PureSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_PureSales.Text = "1,234,567,890";
            this.a_PureSales.Top = 0F;
            this.a_PureSales.Width = 0.8125F;
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
            this.textBox7.DataField = "OfsThisSalesTax";
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 7.8125F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox7.SummaryGroup = "AgentHeader";
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
            this.textBox8.DataField = "SalesPricTax";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 8.625F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.SummaryGroup = "AgentHeader";
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
            this.textBox9.DataField = "AfCalTMonthAccRec";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 9.4375F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox9.SummaryGroup = "AgentHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox9.Text = "1,234,567,890";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.8125F;
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
            this.textBox10.DataField = "SalesSlipCount";
            this.textBox10.Height = 0.125F;
            this.textBox10.Left = 10.25F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox10.SummaryGroup = "AgentHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "123,456";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.5F;
            // 
            // a_CashDeposit
            // 
            this.a_CashDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_CashDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_CashDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_CashDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_CashDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit.DataField = "CashDeposit";
            this.a_CashDeposit.Height = 0.125F;
            this.a_CashDeposit.Left = 2.9375F;
            this.a_CashDeposit.MultiLine = false;
            this.a_CashDeposit.Name = "a_CashDeposit";
            this.a_CashDeposit.OutputFormat = resources.GetString("a_CashDeposit.OutputFormat");
            this.a_CashDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_CashDeposit.SummaryGroup = "SectionHeader";
            this.a_CashDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_CashDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_CashDeposit.Text = "1,234,567,890";
            this.a_CashDeposit.Top = 0.125F;
            this.a_CashDeposit.Width = 0.8125F;
            // 
            // a_TrfrDeposit
            // 
            this.a_TrfrDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit.DataField = "TrfrDeposit";
            this.a_TrfrDeposit.Height = 0.125F;
            this.a_TrfrDeposit.Left = 3.75F;
            this.a_TrfrDeposit.MultiLine = false;
            this.a_TrfrDeposit.Name = "a_TrfrDeposit";
            this.a_TrfrDeposit.OutputFormat = resources.GetString("a_TrfrDeposit.OutputFormat");
            this.a_TrfrDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_TrfrDeposit.SummaryGroup = "SectionHeader";
            this.a_TrfrDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_TrfrDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_TrfrDeposit.Text = "1,234,567,890";
            this.a_TrfrDeposit.Top = 0.125F;
            this.a_TrfrDeposit.Width = 0.8125F;
            // 
            // a_CheckDeposit
            // 
            this.a_CheckDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_CheckDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_CheckDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_CheckDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_CheckDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit.DataField = "CheckDeposit";
            this.a_CheckDeposit.Height = 0.125F;
            this.a_CheckDeposit.Left = 4.5625F;
            this.a_CheckDeposit.MultiLine = false;
            this.a_CheckDeposit.Name = "a_CheckDeposit";
            this.a_CheckDeposit.OutputFormat = resources.GetString("a_CheckDeposit.OutputFormat");
            this.a_CheckDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_CheckDeposit.SummaryGroup = "SectionHeader";
            this.a_CheckDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_CheckDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_CheckDeposit.Text = "1,234,567,890";
            this.a_CheckDeposit.Top = 0.125F;
            this.a_CheckDeposit.Width = 0.8125F;
            // 
            // a_DraftDeposit
            // 
            this.a_DraftDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_DraftDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_DraftDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_DraftDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_DraftDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit.DataField = "DraftDeposit";
            this.a_DraftDeposit.Height = 0.125F;
            this.a_DraftDeposit.Left = 5.375F;
            this.a_DraftDeposit.MultiLine = false;
            this.a_DraftDeposit.Name = "a_DraftDeposit";
            this.a_DraftDeposit.OutputFormat = resources.GetString("a_DraftDeposit.OutputFormat");
            this.a_DraftDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_DraftDeposit.SummaryGroup = "SectionHeader";
            this.a_DraftDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_DraftDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_DraftDeposit.Text = "1,234,567,890";
            this.a_DraftDeposit.Top = 0.125F;
            this.a_DraftDeposit.Width = 0.8125F;
            // 
            // a_OffsetDeposit
            // 
            this.a_OffsetDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit.DataField = "OffsetDeposit";
            this.a_OffsetDeposit.Height = 0.125F;
            this.a_OffsetDeposit.Left = 6.1875F;
            this.a_OffsetDeposit.MultiLine = false;
            this.a_OffsetDeposit.Name = "a_OffsetDeposit";
            this.a_OffsetDeposit.OutputFormat = resources.GetString("a_OffsetDeposit.OutputFormat");
            this.a_OffsetDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_OffsetDeposit.SummaryGroup = "SectionHeader";
            this.a_OffsetDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_OffsetDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_OffsetDeposit.Text = "1,234,567,890";
            this.a_OffsetDeposit.Top = 0.125F;
            this.a_OffsetDeposit.Width = 0.8125F;
            // 
            // a_FundTransferDeposit
            // 
            this.a_FundTransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit.DataField = "FundTransferDeposit";
            this.a_FundTransferDeposit.Height = 0.125F;
            this.a_FundTransferDeposit.Left = 7.8125F;
            this.a_FundTransferDeposit.MultiLine = false;
            this.a_FundTransferDeposit.Name = "a_FundTransferDeposit";
            this.a_FundTransferDeposit.OutputFormat = resources.GetString("a_FundTransferDeposit.OutputFormat");
            this.a_FundTransferDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_FundTransferDeposit.SummaryGroup = "SectionHeader";
            this.a_FundTransferDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_FundTransferDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_FundTransferDeposit.Text = "1,234,567,890";
            this.a_FundTransferDeposit.Top = 0.125F;
            this.a_FundTransferDeposit.Width = 0.8125F;
            // 
            // a_OthsDeposit
            // 
            this.a_OthsDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.a_OthsDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.a_OthsDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.a_OthsDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.a_OthsDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit.DataField = "OthsDeposit";
            this.a_OthsDeposit.Height = 0.125F;
            this.a_OthsDeposit.Left = 7F;
            this.a_OthsDeposit.MultiLine = false;
            this.a_OthsDeposit.Name = "a_OthsDeposit";
            this.a_OthsDeposit.OutputFormat = resources.GetString("a_OthsDeposit.OutputFormat");
            this.a_OthsDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_OthsDeposit.SummaryGroup = "SectionHeader";
            this.a_OthsDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_OthsDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_OthsDeposit.Text = "1,234,567,890";
            this.a_OthsDeposit.Top = 0.125F;
            this.a_OthsDeposit.Width = 0.8125F;
            // 
            // a_ThisTimeFeeDmdNrml
            // 
            this.a_ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.a_ThisTimeFeeDmdNrml.Height = 0.125F;
            this.a_ThisTimeFeeDmdNrml.Left = 8.625F;
            this.a_ThisTimeFeeDmdNrml.MultiLine = false;
            this.a_ThisTimeFeeDmdNrml.Name = "a_ThisTimeFeeDmdNrml";
            this.a_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("a_ThisTimeFeeDmdNrml.OutputFormat");
            this.a_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_ThisTimeFeeDmdNrml.SummaryGroup = "SectionHeader";
            this.a_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_ThisTimeFeeDmdNrml.Text = "1,234,567,890";
            this.a_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.a_ThisTimeFeeDmdNrml.Width = 0.8125F;
            // 
            // a_ThisTimeDisDmdNrml
            // 
            this.a_ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.a_ThisTimeDisDmdNrml.Height = 0.125F;
            this.a_ThisTimeDisDmdNrml.Left = 9.4375F;
            this.a_ThisTimeDisDmdNrml.MultiLine = false;
            this.a_ThisTimeDisDmdNrml.Name = "a_ThisTimeDisDmdNrml";
            this.a_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("a_ThisTimeDisDmdNrml.OutputFormat");
            this.a_ThisTimeDisDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_ThisTimeDisDmdNrml.SummaryGroup = "SectionHeader";
            this.a_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_ThisTimeDisDmdNrml.Text = "1,234,567,890";
            this.a_ThisTimeDisDmdNrml.Top = 0.125F;
            this.a_ThisTimeDisDmdNrml.Width = 0.8125F;
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
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // SalesAreaHeader
            // 
            this.SalesAreaHeader.CanShrink = true;
            this.SalesAreaHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SalesAreaCode,
            this.SalesAreaName,
            this.textBox4,
            this.textBox5,
            this.line4});
            this.SalesAreaHeader.DataField = "SalesAreaCode";
            this.SalesAreaHeader.Height = 0.25F;
            this.SalesAreaHeader.Name = "SalesAreaHeader";
            this.SalesAreaHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SalesAreaHeader.Format += new System.EventHandler(this.SalesAreaHeader_Format);
            // 
            // SalesAreaCode
            // 
            this.SalesAreaCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesAreaCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesAreaCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaCode.Border.RightColor = System.Drawing.Color.Black;
            this.SalesAreaCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaCode.Border.TopColor = System.Drawing.Color.Black;
            this.SalesAreaCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaCode.DataField = "SalesAreaCode";
            this.SalesAreaCode.Height = 0.125F;
            this.SalesAreaCode.Left = 2F;
            this.SalesAreaCode.MultiLine = false;
            this.SalesAreaCode.Name = "SalesAreaCode";
            this.SalesAreaCode.OutputFormat = resources.GetString("SalesAreaCode.OutputFormat");
            this.SalesAreaCode.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesAreaCode.Text = "1234";
            this.SalesAreaCode.Top = 0F;
            this.SalesAreaCode.Width = 0.3125F;
            // 
            // SalesAreaName
            // 
            this.SalesAreaName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesAreaName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesAreaName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesAreaName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesAreaName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAreaName.DataField = "SalesAreaName";
            this.SalesAreaName.Height = 0.125F;
            this.SalesAreaName.Left = 2.375F;
            this.SalesAreaName.MultiLine = false;
            this.SalesAreaName.Name = "SalesAreaName";
            this.SalesAreaName.OutputFormat = resources.GetString("SalesAreaName.OutputFormat");
            this.SalesAreaName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SalesAreaName.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.SalesAreaName.Top = 0F;
            this.SalesAreaName.Width = 3.375F;
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
            this.textBox4.DataField = "AddUpSecCode";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 0F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.textBox4.Text = "00";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.1875F;
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
            this.textBox5.DataField = "SectionGuideSnm";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 0.25F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.textBox5.Text = "拠点３４５６７８９０";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 1.1875F;
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
            // SalesAreaFooter
            // 
            this.SalesAreaFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.t_ThisTimeSales,
            this.t_ThisRgdsDisPric,
            this.t_PureSales,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.Line13,
            this.t_CashDeposit,
            this.t_TrfrDeposit,
            this.t_CheckDeposit,
            this.t_DraftDeposit,
            this.t_OffsetDeposit,
            this.t_FundTransferDeposit,
            this.t_OthsDeposit,
            this.t_ThisTimeFeeDmdNrml,
            this.t_ThisTimeDisDmdNrml});
            this.SalesAreaFooter.Height = 0.34375F;
            this.SalesAreaFooter.Name = "SalesAreaFooter";
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
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 0.1875F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox11.Text = "地区計";
            this.textBox11.Top = 0.0625F;
            this.textBox11.Width = 0.6875F;
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
            this.textBox12.DataField = "LastTimeAccRec";
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 2.9375F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox12.SummaryGroup = "SalesAreaHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "1,234,567,890";
            this.textBox12.Top = 0F;
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
            this.textBox13.DataField = "ThisTimeDmdNrml";
            this.textBox13.Height = 0.125F;
            this.textBox13.Left = 3.75F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.SummaryGroup = "SalesAreaHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "1,234,567,890";
            this.textBox13.Top = 0F;
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
            this.textBox14.DataField = "ThisTimeTtlBlcAcc";
            this.textBox14.Height = 0.125F;
            this.textBox14.Left = 4.5625F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox14.SummaryGroup = "SalesAreaHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "1,234,567,890";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.8125F;
            // 
            // t_ThisTimeSales
            // 
            this.t_ThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeSales.DataField = "ThisTimeSales";
            this.t_ThisTimeSales.Height = 0.125F;
            this.t_ThisTimeSales.Left = 5.375F;
            this.t_ThisTimeSales.MultiLine = false;
            this.t_ThisTimeSales.Name = "t_ThisTimeSales";
            this.t_ThisTimeSales.OutputFormat = resources.GetString("t_ThisTimeSales.OutputFormat");
            this.t_ThisTimeSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeSales.SummaryGroup = "SalesAreaHeader";
            this.t_ThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_ThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_ThisTimeSales.Text = "1,234,567,890";
            this.t_ThisTimeSales.Top = 0F;
            this.t_ThisTimeSales.Width = 0.8125F;
            // 
            // t_ThisRgdsDisPric
            // 
            this.t_ThisRgdsDisPric.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisRgdsDisPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisRgdsDisPric.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisRgdsDisPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisRgdsDisPric.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisRgdsDisPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisRgdsDisPric.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisRgdsDisPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisRgdsDisPric.DataField = "ThisRgdsDisPric";
            this.t_ThisRgdsDisPric.Height = 0.125F;
            this.t_ThisRgdsDisPric.Left = 6.1875F;
            this.t_ThisRgdsDisPric.MultiLine = false;
            this.t_ThisRgdsDisPric.Name = "t_ThisRgdsDisPric";
            this.t_ThisRgdsDisPric.OutputFormat = resources.GetString("t_ThisRgdsDisPric.OutputFormat");
            this.t_ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisRgdsDisPric.SummaryGroup = "SalesAreaHeader";
            this.t_ThisRgdsDisPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_ThisRgdsDisPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_ThisRgdsDisPric.Text = "1,234,567,890";
            this.t_ThisRgdsDisPric.Top = 0F;
            this.t_ThisRgdsDisPric.Width = 0.8125F;
            // 
            // t_PureSales
            // 
            this.t_PureSales.Border.BottomColor = System.Drawing.Color.Black;
            this.t_PureSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_PureSales.Border.LeftColor = System.Drawing.Color.Black;
            this.t_PureSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_PureSales.Border.RightColor = System.Drawing.Color.Black;
            this.t_PureSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_PureSales.Border.TopColor = System.Drawing.Color.Black;
            this.t_PureSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_PureSales.DataField = "PureSales";
            this.t_PureSales.Height = 0.125F;
            this.t_PureSales.Left = 7F;
            this.t_PureSales.MultiLine = false;
            this.t_PureSales.Name = "t_PureSales";
            this.t_PureSales.OutputFormat = resources.GetString("t_PureSales.OutputFormat");
            this.t_PureSales.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_PureSales.SummaryGroup = "SalesAreaHeader";
            this.t_PureSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_PureSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_PureSales.Text = "1,234,567,890";
            this.t_PureSales.Top = 0F;
            this.t_PureSales.Width = 0.8125F;
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
            this.textBox18.DataField = "OfsThisSalesTax";
            this.textBox18.Height = 0.125F;
            this.textBox18.Left = 7.8125F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox18.SummaryGroup = "SalesAreaHeader";
            this.textBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox18.Text = "1,234,567,890";
            this.textBox18.Top = 0F;
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
            this.textBox19.DataField = "SalesPricTax";
            this.textBox19.Height = 0.125F;
            this.textBox19.Left = 8.625F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox19.SummaryGroup = "SalesAreaHeader";
            this.textBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox19.Text = "1,234,567,890";
            this.textBox19.Top = 0F;
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
            this.textBox20.DataField = "AfCalTMonthAccRec";
            this.textBox20.Height = 0.125F;
            this.textBox20.Left = 9.4375F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox20.SummaryGroup = "SalesAreaHeader";
            this.textBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox20.Text = "1,234,567,890";
            this.textBox20.Top = 0F;
            this.textBox20.Width = 0.8125F;
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
            this.textBox21.DataField = "SalesSlipCount";
            this.textBox21.Height = 0.125F;
            this.textBox21.Left = 10.25F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox21.SummaryGroup = "SalesAreaHeader";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox21.Text = "123,456";
            this.textBox21.Top = 0F;
            this.textBox21.Width = 0.5F;
            // 
            // t_CashDeposit
            // 
            this.t_CashDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_CashDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_CashDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_CashDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_CashDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit.DataField = "CashDeposit";
            this.t_CashDeposit.Height = 0.125F;
            this.t_CashDeposit.Left = 2.9375F;
            this.t_CashDeposit.MultiLine = false;
            this.t_CashDeposit.Name = "t_CashDeposit";
            this.t_CashDeposit.OutputFormat = resources.GetString("t_CashDeposit.OutputFormat");
            this.t_CashDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_CashDeposit.SummaryGroup = "SectionHeader";
            this.t_CashDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_CashDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_CashDeposit.Text = "1,234,567,890";
            this.t_CashDeposit.Top = 0.125F;
            this.t_CashDeposit.Width = 0.8125F;
            // 
            // t_TrfrDeposit
            // 
            this.t_TrfrDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit.DataField = "TrfrDeposit";
            this.t_TrfrDeposit.Height = 0.125F;
            this.t_TrfrDeposit.Left = 3.75F;
            this.t_TrfrDeposit.MultiLine = false;
            this.t_TrfrDeposit.Name = "t_TrfrDeposit";
            this.t_TrfrDeposit.OutputFormat = resources.GetString("t_TrfrDeposit.OutputFormat");
            this.t_TrfrDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_TrfrDeposit.SummaryGroup = "SectionHeader";
            this.t_TrfrDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_TrfrDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_TrfrDeposit.Text = "1,234,567,890";
            this.t_TrfrDeposit.Top = 0.125F;
            this.t_TrfrDeposit.Width = 0.8125F;
            // 
            // t_CheckDeposit
            // 
            this.t_CheckDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_CheckDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_CheckDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_CheckDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_CheckDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit.DataField = "CheckDeposit";
            this.t_CheckDeposit.Height = 0.125F;
            this.t_CheckDeposit.Left = 4.5625F;
            this.t_CheckDeposit.MultiLine = false;
            this.t_CheckDeposit.Name = "t_CheckDeposit";
            this.t_CheckDeposit.OutputFormat = resources.GetString("t_CheckDeposit.OutputFormat");
            this.t_CheckDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_CheckDeposit.SummaryGroup = "SectionHeader";
            this.t_CheckDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_CheckDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_CheckDeposit.Text = "1,234,567,890";
            this.t_CheckDeposit.Top = 0.125F;
            this.t_CheckDeposit.Width = 0.8125F;
            // 
            // t_DraftDeposit
            // 
            this.t_DraftDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_DraftDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_DraftDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_DraftDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_DraftDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit.DataField = "DraftDeposit";
            this.t_DraftDeposit.Height = 0.125F;
            this.t_DraftDeposit.Left = 5.375F;
            this.t_DraftDeposit.MultiLine = false;
            this.t_DraftDeposit.Name = "t_DraftDeposit";
            this.t_DraftDeposit.OutputFormat = resources.GetString("t_DraftDeposit.OutputFormat");
            this.t_DraftDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_DraftDeposit.SummaryGroup = "SectionHeader";
            this.t_DraftDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_DraftDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_DraftDeposit.Text = "1,234,567,890";
            this.t_DraftDeposit.Top = 0.125F;
            this.t_DraftDeposit.Width = 0.8125F;
            // 
            // t_OffsetDeposit
            // 
            this.t_OffsetDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit.DataField = "OffsetDeposit";
            this.t_OffsetDeposit.Height = 0.125F;
            this.t_OffsetDeposit.Left = 6.1875F;
            this.t_OffsetDeposit.MultiLine = false;
            this.t_OffsetDeposit.Name = "t_OffsetDeposit";
            this.t_OffsetDeposit.OutputFormat = resources.GetString("t_OffsetDeposit.OutputFormat");
            this.t_OffsetDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_OffsetDeposit.SummaryGroup = "SectionHeader";
            this.t_OffsetDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_OffsetDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_OffsetDeposit.Text = "1,234,567,890";
            this.t_OffsetDeposit.Top = 0.125F;
            this.t_OffsetDeposit.Width = 0.8125F;
            // 
            // t_FundTransferDeposit
            // 
            this.t_FundTransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit.DataField = "FundTransferDeposit";
            this.t_FundTransferDeposit.Height = 0.125F;
            this.t_FundTransferDeposit.Left = 7.8125F;
            this.t_FundTransferDeposit.MultiLine = false;
            this.t_FundTransferDeposit.Name = "t_FundTransferDeposit";
            this.t_FundTransferDeposit.OutputFormat = resources.GetString("t_FundTransferDeposit.OutputFormat");
            this.t_FundTransferDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_FundTransferDeposit.SummaryGroup = "SectionHeader";
            this.t_FundTransferDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_FundTransferDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_FundTransferDeposit.Text = "1,234,567,890";
            this.t_FundTransferDeposit.Top = 0.125F;
            this.t_FundTransferDeposit.Width = 0.8125F;
            // 
            // t_OthsDeposit
            // 
            this.t_OthsDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.t_OthsDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.t_OthsDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.t_OthsDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.t_OthsDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit.DataField = "OthsDeposit";
            this.t_OthsDeposit.Height = 0.125F;
            this.t_OthsDeposit.Left = 7F;
            this.t_OthsDeposit.MultiLine = false;
            this.t_OthsDeposit.Name = "t_OthsDeposit";
            this.t_OthsDeposit.OutputFormat = resources.GetString("t_OthsDeposit.OutputFormat");
            this.t_OthsDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_OthsDeposit.SummaryGroup = "SectionHeader";
            this.t_OthsDeposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_OthsDeposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_OthsDeposit.Text = "1,234,567,890";
            this.t_OthsDeposit.Top = 0.125F;
            this.t_OthsDeposit.Width = 0.8125F;
            // 
            // t_ThisTimeFeeDmdNrml
            // 
            this.t_ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.t_ThisTimeFeeDmdNrml.Height = 0.125F;
            this.t_ThisTimeFeeDmdNrml.Left = 8.625F;
            this.t_ThisTimeFeeDmdNrml.MultiLine = false;
            this.t_ThisTimeFeeDmdNrml.Name = "t_ThisTimeFeeDmdNrml";
            this.t_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("t_ThisTimeFeeDmdNrml.OutputFormat");
            this.t_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeFeeDmdNrml.SummaryGroup = "SectionHeader";
            this.t_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_ThisTimeFeeDmdNrml.Text = "1,234,567,890";
            this.t_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.t_ThisTimeFeeDmdNrml.Width = 0.8125F;
            // 
            // t_ThisTimeDisDmdNrml
            // 
            this.t_ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.t_ThisTimeDisDmdNrml.Height = 0.125F;
            this.t_ThisTimeDisDmdNrml.Left = 9.4375F;
            this.t_ThisTimeDisDmdNrml.MultiLine = false;
            this.t_ThisTimeDisDmdNrml.Name = "t_ThisTimeDisDmdNrml";
            this.t_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("t_ThisTimeDisDmdNrml.OutputFormat");
            this.t_ThisTimeDisDmdNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeDisDmdNrml.SummaryGroup = "SectionHeader";
            this.t_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_ThisTimeDisDmdNrml.Text = "1,234,567,890";
            this.t_ThisTimeDisDmdNrml.Top = 0.125F;
            this.t_ThisTimeDisDmdNrml.Width = 0.8125F;
            // 
            // GrandTotalHeader2
            // 
            this.GrandTotalHeader2.CanShrink = true;
            this.GrandTotalHeader2.Height = 0F;
            this.GrandTotalHeader2.Name = "GrandTotalHeader2";
            this.GrandTotalHeader2.Visible = false;
            // 
            // GrandTotalFooter2
            // 
            this.GrandTotalFooter2.CanShrink = true;
            this.GrandTotalFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label17,
            this.line9,
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
            this.g_CashDeposit2,
            this.g_TrfrDeposit2,
            this.g_CheckDeposit2,
            this.g_DraftDeposit2,
            this.g_OffsetDeposit2,
            this.g_FundTransferDeposit2,
            this.g_OthsDeposit2,
            this.g_ThisTimeFeeDmdNrml2,
            this.g_ThisTimeDisDmdNrml2,
            this.textBox117,
            this.textBox118,
            this.textBox119,
            this.textBox120,
            this.textBox121,
            this.textBox122,
            this.textBox123,
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
            this.label18,
            this.label19,
            this.label20,
            this.label24,
            this.textBox153,
            this.textBox154,
            this.textBox155,
            this.textBox156,
            this.textBox157,
            this.textBox158});
            this.GrandTotalFooter2.Height = 0.8229167F;
            this.GrandTotalFooter2.KeepTogether = true;
            this.GrandTotalFooter2.Name = "GrandTotalFooter2";
            this.GrandTotalFooter2.Visible = false;
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
            this.label17.Height = 0.1875F;
            this.label17.HyperLink = "";
            this.label17.Left = 0.1875F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "総合計";
            this.label17.Top = 0.0625F;
            this.label17.Width = 0.5625F;
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
            this.line9.Width = 10.8F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.8F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
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
            this.textBox107.DataField = "LastTimeAccRec";
            this.textBox107.Height = 0.125F;
            this.textBox107.Left = 2.9375F;
            this.textBox107.MultiLine = false;
            this.textBox107.Name = "textBox107";
            this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
            this.textBox107.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox107.Text = "1,234,567,890";
            this.textBox107.Top = 0F;
            this.textBox107.Width = 0.8125F;
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
            this.textBox108.DataField = "ThisTimeDmdNrml";
            this.textBox108.Height = 0.125F;
            this.textBox108.Left = 3.75F;
            this.textBox108.MultiLine = false;
            this.textBox108.Name = "textBox108";
            this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
            this.textBox108.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox108.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox108.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox108.Text = "1,234,567,890";
            this.textBox108.Top = 0F;
            this.textBox108.Width = 0.8125F;
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
            this.textBox109.DataField = "ThisTimeTtlBlcAcc";
            this.textBox109.Height = 0.125F;
            this.textBox109.Left = 4.5625F;
            this.textBox109.MultiLine = false;
            this.textBox109.Name = "textBox109";
            this.textBox109.OutputFormat = resources.GetString("textBox109.OutputFormat");
            this.textBox109.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox109.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox109.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox109.Text = "1,234,567,890";
            this.textBox109.Top = 0F;
            this.textBox109.Width = 0.8125F;
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
            this.textBox110.DataField = "PureSales";
            this.textBox110.Height = 0.125F;
            this.textBox110.Left = 7F;
            this.textBox110.MultiLine = false;
            this.textBox110.Name = "textBox110";
            this.textBox110.OutputFormat = resources.GetString("textBox110.OutputFormat");
            this.textBox110.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox110.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox110.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox110.Text = "1,234,567,890";
            this.textBox110.Top = 0F;
            this.textBox110.Width = 0.8125F;
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
            this.textBox111.DataField = "ThisTimeSales";
            this.textBox111.Height = 0.125F;
            this.textBox111.Left = 5.375F;
            this.textBox111.MultiLine = false;
            this.textBox111.Name = "textBox111";
            this.textBox111.OutputFormat = resources.GetString("textBox111.OutputFormat");
            this.textBox111.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox111.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox111.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox111.Text = "1,234,567,890";
            this.textBox111.Top = 0F;
            this.textBox111.Width = 0.8125F;
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
            this.textBox112.DataField = "ThisRgdsDisPric";
            this.textBox112.Height = 0.125F;
            this.textBox112.Left = 6.1875F;
            this.textBox112.MultiLine = false;
            this.textBox112.Name = "textBox112";
            this.textBox112.OutputFormat = resources.GetString("textBox112.OutputFormat");
            this.textBox112.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox112.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox112.Text = "1,234,567,890";
            this.textBox112.Top = 0F;
            this.textBox112.Width = 0.8125F;
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
            this.textBox113.DataField = "OfsThisSalesTax";
            this.textBox113.Height = 0.125F;
            this.textBox113.Left = 7.8125F;
            this.textBox113.MultiLine = false;
            this.textBox113.Name = "textBox113";
            this.textBox113.OutputFormat = resources.GetString("textBox113.OutputFormat");
            this.textBox113.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox113.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox113.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox113.Text = "1,234,567,890";
            this.textBox113.Top = 0F;
            this.textBox113.Width = 0.8125F;
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
            this.textBox114.DataField = "SalesSlipCount";
            this.textBox114.Height = 0.125F;
            this.textBox114.Left = 10.25F;
            this.textBox114.MultiLine = false;
            this.textBox114.Name = "textBox114";
            this.textBox114.OutputFormat = resources.GetString("textBox114.OutputFormat");
            this.textBox114.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox114.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox114.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox114.Text = "123,456";
            this.textBox114.Top = 0F;
            this.textBox114.Width = 0.5F;
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
            this.textBox115.DataField = "SalesPricTax";
            this.textBox115.Height = 0.125F;
            this.textBox115.Left = 8.625F;
            this.textBox115.MultiLine = false;
            this.textBox115.Name = "textBox115";
            this.textBox115.OutputFormat = resources.GetString("textBox115.OutputFormat");
            this.textBox115.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox115.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox115.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox115.Text = "1,234,567,890";
            this.textBox115.Top = 0F;
            this.textBox115.Width = 0.8125F;
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
            this.textBox116.DataField = "AfCalTMonthAccRec";
            this.textBox116.Height = 0.125F;
            this.textBox116.Left = 9.4375F;
            this.textBox116.MultiLine = false;
            this.textBox116.Name = "textBox116";
            this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
            this.textBox116.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox116.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox116.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox116.Text = "1,234,567,890";
            this.textBox116.Top = 0F;
            this.textBox116.Width = 0.8125F;
            // 
            // g_CashDeposit2
            // 
            this.g_CashDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CashDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CashDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_CashDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_CashDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashDeposit2.DataField = "CashDeposit";
            this.g_CashDeposit2.Height = 0.125F;
            this.g_CashDeposit2.Left = 2.9375F;
            this.g_CashDeposit2.MultiLine = false;
            this.g_CashDeposit2.Name = "g_CashDeposit2";
            this.g_CashDeposit2.OutputFormat = resources.GetString("g_CashDeposit2.OutputFormat");
            this.g_CashDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CashDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CashDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CashDeposit2.Text = "1,234,567,890";
            this.g_CashDeposit2.Top = 0.625F;
            this.g_CashDeposit2.Width = 0.8125F;
            // 
            // g_TrfrDeposit2
            // 
            this.g_TrfrDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_TrfrDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrDeposit2.DataField = "TrfrDeposit";
            this.g_TrfrDeposit2.Height = 0.125F;
            this.g_TrfrDeposit2.Left = 3.75F;
            this.g_TrfrDeposit2.MultiLine = false;
            this.g_TrfrDeposit2.Name = "g_TrfrDeposit2";
            this.g_TrfrDeposit2.OutputFormat = resources.GetString("g_TrfrDeposit2.OutputFormat");
            this.g_TrfrDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TrfrDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TrfrDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TrfrDeposit2.Text = "1,234,567,890";
            this.g_TrfrDeposit2.Top = 0.625F;
            this.g_TrfrDeposit2.Width = 0.8125F;
            // 
            // g_CheckDeposit2
            // 
            this.g_CheckDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CheckDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CheckDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_CheckDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_CheckDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckDeposit2.DataField = "CheckDeposit";
            this.g_CheckDeposit2.Height = 0.125F;
            this.g_CheckDeposit2.Left = 4.5625F;
            this.g_CheckDeposit2.MultiLine = false;
            this.g_CheckDeposit2.Name = "g_CheckDeposit2";
            this.g_CheckDeposit2.OutputFormat = resources.GetString("g_CheckDeposit2.OutputFormat");
            this.g_CheckDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CheckDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CheckDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CheckDeposit2.Text = "1,234,567,890";
            this.g_CheckDeposit2.Top = 0.625F;
            this.g_CheckDeposit2.Width = 0.8125F;
            // 
            // g_DraftDeposit2
            // 
            this.g_DraftDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_DraftDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_DraftDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_DraftDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_DraftDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftDeposit2.DataField = "DraftDeposit";
            this.g_DraftDeposit2.Height = 0.125F;
            this.g_DraftDeposit2.Left = 5.375F;
            this.g_DraftDeposit2.MultiLine = false;
            this.g_DraftDeposit2.Name = "g_DraftDeposit2";
            this.g_DraftDeposit2.OutputFormat = resources.GetString("g_DraftDeposit2.OutputFormat");
            this.g_DraftDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_DraftDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_DraftDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_DraftDeposit2.Text = "1,234,567,890";
            this.g_DraftDeposit2.Top = 0.625F;
            this.g_DraftDeposit2.Width = 0.8125F;
            // 
            // g_OffsetDeposit2
            // 
            this.g_OffsetDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OffsetDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetDeposit2.DataField = "OffsetDeposit";
            this.g_OffsetDeposit2.Height = 0.125F;
            this.g_OffsetDeposit2.Left = 6.1875F;
            this.g_OffsetDeposit2.MultiLine = false;
            this.g_OffsetDeposit2.Name = "g_OffsetDeposit2";
            this.g_OffsetDeposit2.OutputFormat = resources.GetString("g_OffsetDeposit2.OutputFormat");
            this.g_OffsetDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OffsetDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OffsetDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OffsetDeposit2.Text = "1,234,567,890";
            this.g_OffsetDeposit2.Top = 0.625F;
            this.g_OffsetDeposit2.Width = 0.8125F;
            // 
            // g_FundTransferDeposit2
            // 
            this.g_FundTransferDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_FundTransferDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferDeposit2.DataField = "FundTransferDeposit";
            this.g_FundTransferDeposit2.Height = 0.125F;
            this.g_FundTransferDeposit2.Left = 7.8125F;
            this.g_FundTransferDeposit2.MultiLine = false;
            this.g_FundTransferDeposit2.Name = "g_FundTransferDeposit2";
            this.g_FundTransferDeposit2.OutputFormat = resources.GetString("g_FundTransferDeposit2.OutputFormat");
            this.g_FundTransferDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_FundTransferDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_FundTransferDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_FundTransferDeposit2.Text = "1,234,567,890";
            this.g_FundTransferDeposit2.Top = 0.625F;
            this.g_FundTransferDeposit2.Width = 0.8125F;
            // 
            // g_OthsDeposit2
            // 
            this.g_OthsDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OthsDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OthsDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OthsDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OthsDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsDeposit2.DataField = "OthsDeposit";
            this.g_OthsDeposit2.Height = 0.125F;
            this.g_OthsDeposit2.Left = 7F;
            this.g_OthsDeposit2.MultiLine = false;
            this.g_OthsDeposit2.Name = "g_OthsDeposit2";
            this.g_OthsDeposit2.OutputFormat = resources.GetString("g_OthsDeposit2.OutputFormat");
            this.g_OthsDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OthsDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OthsDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OthsDeposit2.Text = "1,234,567,890";
            this.g_OthsDeposit2.Top = 0.625F;
            this.g_OthsDeposit2.Width = 0.8125F;
            // 
            // g_ThisTimeFeeDmdNrml2
            // 
            this.g_ThisTimeFeeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeeDmdNrml2.DataField = "ThisTimeFeeDmdNrml";
            this.g_ThisTimeFeeDmdNrml2.Height = 0.125F;
            this.g_ThisTimeFeeDmdNrml2.Left = 8.625F;
            this.g_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.g_ThisTimeFeeDmdNrml2.Name = "g_ThisTimeFeeDmdNrml2";
            this.g_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("g_ThisTimeFeeDmdNrml2.OutputFormat");
            this.g_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeFeeDmdNrml2.Text = "1,234,567,890";
            this.g_ThisTimeFeeDmdNrml2.Top = 0.625F;
            this.g_ThisTimeFeeDmdNrml2.Width = 0.8125F;
            // 
            // g_ThisTimeDisDmdNrml2
            // 
            this.g_ThisTimeDisDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisDmdNrml2.DataField = "ThisTimeDisDmdNrml";
            this.g_ThisTimeDisDmdNrml2.Height = 0.125F;
            this.g_ThisTimeDisDmdNrml2.Left = 9.4375F;
            this.g_ThisTimeDisDmdNrml2.MultiLine = false;
            this.g_ThisTimeDisDmdNrml2.Name = "g_ThisTimeDisDmdNrml2";
            this.g_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("g_ThisTimeDisDmdNrml2.OutputFormat");
            this.g_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDisDmdNrml2.Text = "1,234,567,890";
            this.g_ThisTimeDisDmdNrml2.Top = 0.625F;
            this.g_ThisTimeDisDmdNrml2.Width = 0.8125F;
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
            this.textBox117.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox117.Height = 0.125F;
            this.textBox117.Left = 5.375F;
            this.textBox117.MultiLine = false;
            this.textBox117.Name = "textBox117";
            this.textBox117.OutputFormat = resources.GetString("textBox117.OutputFormat");
            this.textBox117.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox117.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox117.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox117.Text = "1,234,567,890";
            this.textBox117.Top = 0.125F;
            this.textBox117.Width = 0.8125F;
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
            this.textBox118.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox118.Height = 0.125F;
            this.textBox118.Left = 6.1875F;
            this.textBox118.MultiLine = false;
            this.textBox118.Name = "textBox118";
            this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
            this.textBox118.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox118.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox118.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox118.Text = "1,234,567,890";
            this.textBox118.Top = 0.125F;
            this.textBox118.Width = 0.8125F;
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
            this.textBox119.DataField = "TotalPureSalesTaxRate1";
            this.textBox119.Height = 0.125F;
            this.textBox119.Left = 7F;
            this.textBox119.MultiLine = false;
            this.textBox119.Name = "textBox119";
            this.textBox119.OutputFormat = resources.GetString("textBox119.OutputFormat");
            this.textBox119.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox119.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox119.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox119.Text = "1,234,567,890";
            this.textBox119.Top = 0.125F;
            this.textBox119.Width = 0.8125F;
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
            this.textBox120.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox120.Height = 0.125F;
            this.textBox120.Left = 7.8125F;
            this.textBox120.MultiLine = false;
            this.textBox120.Name = "textBox120";
            this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
            this.textBox120.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox120.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox120.Text = "1,234,567,890";
            this.textBox120.Top = 0.125F;
            this.textBox120.Width = 0.8125F;
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
            this.textBox121.DataField = "TotalAfCalTMonthAccRecTaxRate1";
            this.textBox121.Height = 0.125F;
            this.textBox121.Left = 8.625F;
            this.textBox121.MultiLine = false;
            this.textBox121.Name = "textBox121";
            this.textBox121.OutputFormat = resources.GetString("textBox121.OutputFormat");
            this.textBox121.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox121.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox121.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox121.Text = "1,234,567,890";
            this.textBox121.Top = 0.125F;
            this.textBox121.Width = 0.8125F;
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
            this.textBox122.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox122.Height = 0.125F;
            this.textBox122.Left = 10.25F;
            this.textBox122.MultiLine = false;
            this.textBox122.Name = "textBox122";
            this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
            this.textBox122.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox122.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox122.Text = "123,456";
            this.textBox122.Top = 0.125F;
            this.textBox122.Width = 0.5F;
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
            this.textBox123.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox123.Height = 0.125F;
            this.textBox123.Left = 5.375F;
            this.textBox123.MultiLine = false;
            this.textBox123.Name = "textBox123";
            this.textBox123.OutputFormat = resources.GetString("textBox123.OutputFormat");
            this.textBox123.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox123.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox123.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox123.Text = "1,234,567,890";
            this.textBox123.Top = 0.25F;
            this.textBox123.Width = 0.8125F;
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
            this.textBox124.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox124.Height = 0.125F;
            this.textBox124.Left = 6.1875F;
            this.textBox124.MultiLine = false;
            this.textBox124.Name = "textBox124";
            this.textBox124.OutputFormat = resources.GetString("textBox124.OutputFormat");
            this.textBox124.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox124.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox124.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox124.Text = "1,234,567,890";
            this.textBox124.Top = 0.25F;
            this.textBox124.Width = 0.8125F;
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
            this.textBox125.DataField = "TotalPureSalesTaxRate2";
            this.textBox125.Height = 0.125F;
            this.textBox125.Left = 7F;
            this.textBox125.MultiLine = false;
            this.textBox125.Name = "textBox125";
            this.textBox125.OutputFormat = resources.GetString("textBox125.OutputFormat");
            this.textBox125.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox125.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox125.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox125.Text = "1,234,567,890";
            this.textBox125.Top = 0.25F;
            this.textBox125.Width = 0.8125F;
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
            this.textBox126.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox126.Height = 0.125F;
            this.textBox126.Left = 7.8125F;
            this.textBox126.MultiLine = false;
            this.textBox126.Name = "textBox126";
            this.textBox126.OutputFormat = resources.GetString("textBox126.OutputFormat");
            this.textBox126.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox126.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox126.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox126.Text = "1,234,567,890";
            this.textBox126.Top = 0.25F;
            this.textBox126.Width = 0.8125F;
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
            this.textBox127.DataField = "TotalAfCalTMonthAccRecTaxRate2";
            this.textBox127.Height = 0.125F;
            this.textBox127.Left = 8.625F;
            this.textBox127.MultiLine = false;
            this.textBox127.Name = "textBox127";
            this.textBox127.OutputFormat = resources.GetString("textBox127.OutputFormat");
            this.textBox127.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox127.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox127.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox127.Text = "1,234,567,890";
            this.textBox127.Top = 0.25F;
            this.textBox127.Width = 0.8125F;
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
            this.textBox128.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox128.Height = 0.125F;
            this.textBox128.Left = 10.25F;
            this.textBox128.MultiLine = false;
            this.textBox128.Name = "textBox128";
            this.textBox128.OutputFormat = resources.GetString("textBox128.OutputFormat");
            this.textBox128.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox128.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox128.Text = "123,456";
            this.textBox128.Top = 0.25F;
            this.textBox128.Width = 0.5F;
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
            this.textBox129.DataField = "TotalThisTimeSalesOther";
            this.textBox129.Height = 0.125F;
            this.textBox129.Left = 5.375F;
            this.textBox129.MultiLine = false;
            this.textBox129.Name = "textBox129";
            this.textBox129.OutputFormat = resources.GetString("textBox129.OutputFormat");
            this.textBox129.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox129.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox129.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox129.Text = "1,234,567,890";
            this.textBox129.Top = 0.375F;
            this.textBox129.Width = 0.8125F;
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
            this.textBox130.DataField = "TotalThisRgdsDisPricOther";
            this.textBox130.Height = 0.125F;
            this.textBox130.Left = 6.1875F;
            this.textBox130.MultiLine = false;
            this.textBox130.Name = "textBox130";
            this.textBox130.OutputFormat = resources.GetString("textBox130.OutputFormat");
            this.textBox130.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox130.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox130.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox130.Text = "1,234,567,890";
            this.textBox130.Top = 0.375F;
            this.textBox130.Width = 0.8125F;
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
            this.textBox131.DataField = "TotalPureSalesOther";
            this.textBox131.Height = 0.125F;
            this.textBox131.Left = 7F;
            this.textBox131.MultiLine = false;
            this.textBox131.Name = "textBox131";
            this.textBox131.OutputFormat = resources.GetString("textBox131.OutputFormat");
            this.textBox131.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox131.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox131.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox131.Text = "1,234,567,890";
            this.textBox131.Top = 0.375F;
            this.textBox131.Width = 0.8125F;
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
            this.textBox132.DataField = "TotalSalesPricTaxOther";
            this.textBox132.Height = 0.125F;
            this.textBox132.Left = 7.8125F;
            this.textBox132.MultiLine = false;
            this.textBox132.Name = "textBox132";
            this.textBox132.OutputFormat = resources.GetString("textBox132.OutputFormat");
            this.textBox132.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox132.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox132.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox132.Text = "1,234,567,890";
            this.textBox132.Top = 0.375F;
            this.textBox132.Width = 0.8125F;
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
            this.textBox133.DataField = "TotalAfCalTMonthAccRecOther";
            this.textBox133.Height = 0.125F;
            this.textBox133.Left = 8.625F;
            this.textBox133.MultiLine = false;
            this.textBox133.Name = "textBox133";
            this.textBox133.OutputFormat = resources.GetString("textBox133.OutputFormat");
            this.textBox133.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox133.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox133.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox133.Text = "1,234,567,890";
            this.textBox133.Top = 0.375F;
            this.textBox133.Width = 0.8125F;
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
            this.textBox134.DataField = "TotalSalesSlipCountOther";
            this.textBox134.Height = 0.125F;
            this.textBox134.Left = 10.25F;
            this.textBox134.MultiLine = false;
            this.textBox134.Name = "textBox134";
            this.textBox134.OutputFormat = resources.GetString("textBox134.OutputFormat");
            this.textBox134.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox134.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox134.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox134.Text = "123,456";
            this.textBox134.Top = 0.375F;
            this.textBox134.Width = 0.5F;
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
            this.label18.DataField = "TitleTaxRate1";
            this.label18.Height = 0.125F;
            this.label18.HyperLink = null;
            this.label18.Left = 4.625F;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "10%";
            this.label18.Top = 0.125F;
            this.label18.Width = 0.75F;
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
            this.label19.DataField = "TitleTaxRate2";
            this.label19.Height = 0.125F;
            this.label19.HyperLink = null;
            this.label19.Left = 4.625F;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "8%";
            this.label19.Top = 0.25F;
            this.label19.Width = 0.75F;
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
            this.label20.Height = 0.125F;
            this.label20.HyperLink = null;
            this.label20.Left = 4.625F;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label20.Text = "その他";
            this.label20.Top = 0.375F;
            this.label20.Width = 0.75F;
            // 
            // SectionHeader2
            // 
            this.SectionHeader2.CanShrink = true;
            this.SectionHeader2.Height = 0F;
            this.SectionHeader2.Name = "SectionHeader2";
            this.SectionHeader2.Visible = false;
            // 
            // SectionFooter2
            // 
            this.SectionFooter2.CanShrink = true;
            this.SectionFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line8,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox34,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textBox69,
            this.textBox70,
            this.s_CashDeposit2,
            this.s_TrfrDeposit2,
            this.s_CheckDeposit2,
            this.s_DraftDeposit2,
            this.s_OffsetDeposit2,
            this.s_FundTransferDeposit2,
            this.s_OthsDeposit2,
            this.s_ThisTimeFeeDmdNrml2,
            this.s_ThisTimeDisDmdNrml2,
            this.textBox71,
            this.textBox72,
            this.textBox73,
            this.textBox74,
            this.textBox75,
            this.textBox76,
            this.textBox77,
            this.textBox96,
            this.textBox97,
            this.textBox98,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textBox102,
            this.textBox103,
            this.textBox104,
            this.textBox105,
            this.textBox106,
            this.label14,
            this.label15,
            this.label16,
            this.label23,
            this.textBox147,
            this.textBox148,
            this.textBox149,
            this.textBox150,
            this.textBox151,
            this.textBox152});
            this.SectionFooter2.Height = 0.8541667F;
            this.SectionFooter2.KeepTogether = true;
            this.SectionFooter2.Name = "SectionFooter2";
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
            this.line8.Width = 10.8F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
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
            this.textBox31.DataField = "MONEYKINDNAME";
            this.textBox31.Height = 0.1875F;
            this.textBox31.Left = 0.1875F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox31.Text = "拠点計";
            this.textBox31.Top = 0.0625F;
            this.textBox31.Width = 0.5625F;
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
            this.textBox32.DataField = "LastTimeAccRec";
            this.textBox32.Height = 0.125F;
            this.textBox32.Left = 2.9375F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox32.SummaryGroup = "SectionHeader";
            this.textBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox32.Text = "1,234,567,890";
            this.textBox32.Top = 0F;
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
            this.textBox33.DataField = "ThisTimeDmdNrml";
            this.textBox33.Height = 0.125F;
            this.textBox33.Left = 3.75F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox33.SummaryGroup = "SectionHeader";
            this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox33.Text = "1,234,567,890";
            this.textBox33.Top = 0F;
            this.textBox33.Width = 0.8125F;
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
            this.textBox34.DataField = "ThisTimeTtlBlcAcc";
            this.textBox34.Height = 0.125F;
            this.textBox34.Left = 4.5625F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox34.SummaryGroup = "SectionHeader";
            this.textBox34.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox34.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox34.Text = "1,234,567,890";
            this.textBox34.Top = 0F;
            this.textBox34.Width = 0.8125F;
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
            this.textBox35.DataField = "OfsThisSalesTax";
            this.textBox35.Height = 0.125F;
            this.textBox35.Left = 7.8125F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox35.SummaryGroup = "SectionHeader";
            this.textBox35.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox35.Text = "1,234,567,890";
            this.textBox35.Top = 0F;
            this.textBox35.Width = 0.8125F;
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
            this.textBox36.DataField = "ThisTimeSales";
            this.textBox36.Height = 0.125F;
            this.textBox36.Left = 5.375F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox36.SummaryGroup = "SectionHeader";
            this.textBox36.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox36.Text = "1,234,567,890";
            this.textBox36.Top = 0F;
            this.textBox36.Width = 0.8125F;
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
            this.textBox37.DataField = "ThisRgdsDisPric";
            this.textBox37.Height = 0.125F;
            this.textBox37.Left = 6.1875F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox37.SummaryGroup = "SectionHeader";
            this.textBox37.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox37.Text = "1,234,567,890";
            this.textBox37.Top = 0F;
            this.textBox37.Width = 0.8125F;
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
            this.textBox38.DataField = "PureSales";
            this.textBox38.Height = 0.125F;
            this.textBox38.Left = 7F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox38.SummaryGroup = "SectionHeader";
            this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox38.Text = "1,234,567,890";
            this.textBox38.Top = 0F;
            this.textBox38.Width = 0.8125F;
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
            this.textBox39.DataField = "SalesSlipCount";
            this.textBox39.Height = 0.125F;
            this.textBox39.Left = 10.25F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox39.SummaryGroup = "SectionHeader";
            this.textBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox39.Text = "123,456";
            this.textBox39.Top = 0F;
            this.textBox39.Width = 0.5F;
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
            this.textBox69.DataField = "SalesPricTax";
            this.textBox69.Height = 0.125F;
            this.textBox69.Left = 8.625F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox69.SummaryGroup = "SectionHeader";
            this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox69.Text = "1,234,567,890";
            this.textBox69.Top = 0F;
            this.textBox69.Width = 0.8125F;
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
            this.textBox70.DataField = "AfCalTMonthAccRec";
            this.textBox70.Height = 0.125F;
            this.textBox70.Left = 9.4375F;
            this.textBox70.MultiLine = false;
            this.textBox70.Name = "textBox70";
            this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
            this.textBox70.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox70.SummaryGroup = "SectionHeader";
            this.textBox70.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox70.Text = "1,234,567,890";
            this.textBox70.Top = 0F;
            this.textBox70.Width = 0.8125F;
            // 
            // s_CashDeposit2
            // 
            this.s_CashDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CashDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CashDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_CashDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_CashDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashDeposit2.DataField = "CashDeposit";
            this.s_CashDeposit2.Height = 0.125F;
            this.s_CashDeposit2.Left = 2.9375F;
            this.s_CashDeposit2.MultiLine = false;
            this.s_CashDeposit2.Name = "s_CashDeposit2";
            this.s_CashDeposit2.OutputFormat = resources.GetString("s_CashDeposit2.OutputFormat");
            this.s_CashDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CashDeposit2.SummaryGroup = "SectionHeader";
            this.s_CashDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CashDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CashDeposit2.Text = "1,234,567,890";
            this.s_CashDeposit2.Top = 0.625F;
            this.s_CashDeposit2.Width = 0.8125F;
            // 
            // s_TrfrDeposit2
            // 
            this.s_TrfrDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_TrfrDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrDeposit2.DataField = "TrfrDeposit";
            this.s_TrfrDeposit2.Height = 0.125F;
            this.s_TrfrDeposit2.Left = 3.75F;
            this.s_TrfrDeposit2.MultiLine = false;
            this.s_TrfrDeposit2.Name = "s_TrfrDeposit2";
            this.s_TrfrDeposit2.OutputFormat = resources.GetString("s_TrfrDeposit2.OutputFormat");
            this.s_TrfrDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TrfrDeposit2.SummaryGroup = "SectionHeader";
            this.s_TrfrDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TrfrDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TrfrDeposit2.Text = "1,234,567,890";
            this.s_TrfrDeposit2.Top = 0.625F;
            this.s_TrfrDeposit2.Width = 0.8125F;
            // 
            // s_CheckDeposit2
            // 
            this.s_CheckDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CheckDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CheckDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_CheckDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_CheckDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckDeposit2.DataField = "CheckDeposit";
            this.s_CheckDeposit2.Height = 0.125F;
            this.s_CheckDeposit2.Left = 4.5625F;
            this.s_CheckDeposit2.MultiLine = false;
            this.s_CheckDeposit2.Name = "s_CheckDeposit2";
            this.s_CheckDeposit2.OutputFormat = resources.GetString("s_CheckDeposit2.OutputFormat");
            this.s_CheckDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CheckDeposit2.SummaryGroup = "SectionHeader";
            this.s_CheckDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CheckDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CheckDeposit2.Text = "1,234,567,890";
            this.s_CheckDeposit2.Top = 0.625F;
            this.s_CheckDeposit2.Width = 0.8125F;
            // 
            // s_DraftDeposit2
            // 
            this.s_DraftDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_DraftDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_DraftDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_DraftDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_DraftDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftDeposit2.DataField = "DraftDeposit";
            this.s_DraftDeposit2.Height = 0.125F;
            this.s_DraftDeposit2.Left = 5.375F;
            this.s_DraftDeposit2.MultiLine = false;
            this.s_DraftDeposit2.Name = "s_DraftDeposit2";
            this.s_DraftDeposit2.OutputFormat = resources.GetString("s_DraftDeposit2.OutputFormat");
            this.s_DraftDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_DraftDeposit2.SummaryGroup = "SectionHeader";
            this.s_DraftDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DraftDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DraftDeposit2.Text = "1,234,567,890";
            this.s_DraftDeposit2.Top = 0.625F;
            this.s_DraftDeposit2.Width = 0.8125F;
            // 
            // s_OffsetDeposit2
            // 
            this.s_OffsetDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OffsetDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetDeposit2.DataField = "OffsetDeposit";
            this.s_OffsetDeposit2.Height = 0.125F;
            this.s_OffsetDeposit2.Left = 6.1875F;
            this.s_OffsetDeposit2.MultiLine = false;
            this.s_OffsetDeposit2.Name = "s_OffsetDeposit2";
            this.s_OffsetDeposit2.OutputFormat = resources.GetString("s_OffsetDeposit2.OutputFormat");
            this.s_OffsetDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OffsetDeposit2.SummaryGroup = "SectionHeader";
            this.s_OffsetDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OffsetDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OffsetDeposit2.Text = "1,234,567,890";
            this.s_OffsetDeposit2.Top = 0.625F;
            this.s_OffsetDeposit2.Width = 0.8125F;
            // 
            // s_FundTransferDeposit2
            // 
            this.s_FundTransferDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_FundTransferDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferDeposit2.DataField = "FundTransferDeposit";
            this.s_FundTransferDeposit2.Height = 0.125F;
            this.s_FundTransferDeposit2.Left = 7.8125F;
            this.s_FundTransferDeposit2.MultiLine = false;
            this.s_FundTransferDeposit2.Name = "s_FundTransferDeposit2";
            this.s_FundTransferDeposit2.OutputFormat = resources.GetString("s_FundTransferDeposit2.OutputFormat");
            this.s_FundTransferDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_FundTransferDeposit2.SummaryGroup = "SectionHeader";
            this.s_FundTransferDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_FundTransferDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_FundTransferDeposit2.Text = "1,234,567,890";
            this.s_FundTransferDeposit2.Top = 0.625F;
            this.s_FundTransferDeposit2.Width = 0.8125F;
            // 
            // s_OthsDeposit2
            // 
            this.s_OthsDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OthsDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OthsDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OthsDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OthsDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsDeposit2.DataField = "OthsDeposit";
            this.s_OthsDeposit2.Height = 0.125F;
            this.s_OthsDeposit2.Left = 7F;
            this.s_OthsDeposit2.MultiLine = false;
            this.s_OthsDeposit2.Name = "s_OthsDeposit2";
            this.s_OthsDeposit2.OutputFormat = resources.GetString("s_OthsDeposit2.OutputFormat");
            this.s_OthsDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OthsDeposit2.SummaryGroup = "SectionHeader";
            this.s_OthsDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OthsDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OthsDeposit2.Text = "1,234,567,890";
            this.s_OthsDeposit2.Top = 0.625F;
            this.s_OthsDeposit2.Width = 0.8125F;
            // 
            // s_ThisTimeFeeDmdNrml2
            // 
            this.s_ThisTimeFeeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeeDmdNrml2.DataField = "ThisTimeFeeDmdNrml";
            this.s_ThisTimeFeeDmdNrml2.Height = 0.125F;
            this.s_ThisTimeFeeDmdNrml2.Left = 8.625F;
            this.s_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.s_ThisTimeFeeDmdNrml2.Name = "s_ThisTimeFeeDmdNrml2";
            this.s_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("s_ThisTimeFeeDmdNrml2.OutputFormat");
            this.s_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeFeeDmdNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeeDmdNrml2.Text = "1,234,567,890";
            this.s_ThisTimeFeeDmdNrml2.Top = 0.625F;
            this.s_ThisTimeFeeDmdNrml2.Width = 0.8125F;
            // 
            // s_ThisTimeDisDmdNrml2
            // 
            this.s_ThisTimeDisDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisDmdNrml2.DataField = "ThisTimeDisDmdNrml";
            this.s_ThisTimeDisDmdNrml2.Height = 0.125F;
            this.s_ThisTimeDisDmdNrml2.Left = 9.4375F;
            this.s_ThisTimeDisDmdNrml2.MultiLine = false;
            this.s_ThisTimeDisDmdNrml2.Name = "s_ThisTimeDisDmdNrml2";
            this.s_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("s_ThisTimeDisDmdNrml2.OutputFormat");
            this.s_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeDisDmdNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisDmdNrml2.Text = "1,234,567,890";
            this.s_ThisTimeDisDmdNrml2.Top = 0.625F;
            this.s_ThisTimeDisDmdNrml2.Width = 0.8125F;
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
            this.textBox71.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox71.Height = 0.125F;
            this.textBox71.Left = 5.375F;
            this.textBox71.MultiLine = false;
            this.textBox71.Name = "textBox71";
            this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
            this.textBox71.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox71.SummaryGroup = "SectionHeader";
            this.textBox71.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox71.Text = "1,234,567,890";
            this.textBox71.Top = 0.125F;
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
            this.textBox72.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox72.Height = 0.125F;
            this.textBox72.Left = 6.1875F;
            this.textBox72.MultiLine = false;
            this.textBox72.Name = "textBox72";
            this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
            this.textBox72.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox72.SummaryGroup = "SectionHeader";
            this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox72.Text = "1,234,567,890";
            this.textBox72.Top = 0.125F;
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
            this.textBox73.DataField = "TotalPureSalesTaxRate1";
            this.textBox73.Height = 0.125F;
            this.textBox73.Left = 7F;
            this.textBox73.MultiLine = false;
            this.textBox73.Name = "textBox73";
            this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
            this.textBox73.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox73.SummaryGroup = "SectionHeader";
            this.textBox73.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox73.Text = "1,234,567,890";
            this.textBox73.Top = 0.125F;
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
            this.textBox74.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox74.Height = 0.125F;
            this.textBox74.Left = 7.8125F;
            this.textBox74.MultiLine = false;
            this.textBox74.Name = "textBox74";
            this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
            this.textBox74.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox74.SummaryGroup = "SectionHeader";
            this.textBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox74.Text = "1,234,567,890";
            this.textBox74.Top = 0.125F;
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
            this.textBox75.DataField = "TotalAfCalTMonthAccRecTaxRate1";
            this.textBox75.Height = 0.125F;
            this.textBox75.Left = 8.625F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
            this.textBox75.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox75.SummaryGroup = "SectionHeader";
            this.textBox75.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox75.Text = "1,234,567,890";
            this.textBox75.Top = 0.125F;
            this.textBox75.Width = 0.8125F;
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
            this.textBox76.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox76.Height = 0.125F;
            this.textBox76.Left = 10.25F;
            this.textBox76.MultiLine = false;
            this.textBox76.Name = "textBox76";
            this.textBox76.OutputFormat = resources.GetString("textBox76.OutputFormat");
            this.textBox76.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox76.SummaryGroup = "SectionHeader";
            this.textBox76.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox76.Text = "123,456";
            this.textBox76.Top = 0.125F;
            this.textBox76.Width = 0.5F;
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
            this.textBox77.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox77.Height = 0.125F;
            this.textBox77.Left = 5.375F;
            this.textBox77.MultiLine = false;
            this.textBox77.Name = "textBox77";
            this.textBox77.OutputFormat = resources.GetString("textBox77.OutputFormat");
            this.textBox77.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox77.SummaryGroup = "SectionHeader";
            this.textBox77.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox77.Text = "1,234,567,890";
            this.textBox77.Top = 0.25F;
            this.textBox77.Width = 0.8125F;
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
            this.textBox96.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox96.Height = 0.125F;
            this.textBox96.Left = 6.1875F;
            this.textBox96.MultiLine = false;
            this.textBox96.Name = "textBox96";
            this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
            this.textBox96.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox96.SummaryGroup = "SectionHeader";
            this.textBox96.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox96.Text = "1,234,567,890";
            this.textBox96.Top = 0.25F;
            this.textBox96.Width = 0.8125F;
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
            this.textBox97.DataField = "TotalPureSalesTaxRate2";
            this.textBox97.Height = 0.125F;
            this.textBox97.Left = 7F;
            this.textBox97.MultiLine = false;
            this.textBox97.Name = "textBox97";
            this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
            this.textBox97.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox97.SummaryGroup = "SectionHeader";
            this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox97.Text = "1,234,567,890";
            this.textBox97.Top = 0.25F;
            this.textBox97.Width = 0.8125F;
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
            this.textBox98.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox98.Height = 0.125F;
            this.textBox98.Left = 7.8125F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox98.SummaryGroup = "SectionHeader";
            this.textBox98.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox98.Text = "1,234,567,890";
            this.textBox98.Top = 0.25F;
            this.textBox98.Width = 0.8125F;
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
            this.textBox99.DataField = "TotalAfCalTMonthAccRecTaxRate2";
            this.textBox99.Height = 0.125F;
            this.textBox99.Left = 8.625F;
            this.textBox99.MultiLine = false;
            this.textBox99.Name = "textBox99";
            this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
            this.textBox99.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox99.SummaryGroup = "SectionHeader";
            this.textBox99.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox99.Text = "1,234,567,890";
            this.textBox99.Top = 0.25F;
            this.textBox99.Width = 0.8125F;
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
            this.textBox100.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox100.Height = 0.125F;
            this.textBox100.Left = 10.25F;
            this.textBox100.MultiLine = false;
            this.textBox100.Name = "textBox100";
            this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
            this.textBox100.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox100.SummaryGroup = "SectionHeader";
            this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox100.Text = "123,456";
            this.textBox100.Top = 0.25F;
            this.textBox100.Width = 0.5F;
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
            this.textBox101.DataField = "TotalThisTimeSalesOther";
            this.textBox101.Height = 0.125F;
            this.textBox101.Left = 5.375F;
            this.textBox101.MultiLine = false;
            this.textBox101.Name = "textBox101";
            this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
            this.textBox101.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox101.SummaryGroup = "SectionHeader";
            this.textBox101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox101.Text = "1,234,567,890";
            this.textBox101.Top = 0.375F;
            this.textBox101.Width = 0.8125F;
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
            this.textBox102.DataField = "TotalThisRgdsDisPricOther";
            this.textBox102.Height = 0.125F;
            this.textBox102.Left = 6.1875F;
            this.textBox102.MultiLine = false;
            this.textBox102.Name = "textBox102";
            this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
            this.textBox102.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox102.SummaryGroup = "SectionHeader";
            this.textBox102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox102.Text = "1,234,567,890";
            this.textBox102.Top = 0.375F;
            this.textBox102.Width = 0.8125F;
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
            this.textBox103.DataField = "TotalPureSalesOther";
            this.textBox103.Height = 0.125F;
            this.textBox103.Left = 7F;
            this.textBox103.MultiLine = false;
            this.textBox103.Name = "textBox103";
            this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
            this.textBox103.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox103.SummaryGroup = "SectionHeader";
            this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox103.Text = "1,234,567,890";
            this.textBox103.Top = 0.375F;
            this.textBox103.Width = 0.8125F;
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
            this.textBox104.DataField = "TotalSalesPricTaxOther";
            this.textBox104.Height = 0.125F;
            this.textBox104.Left = 7.8125F;
            this.textBox104.MultiLine = false;
            this.textBox104.Name = "textBox104";
            this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
            this.textBox104.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox104.SummaryGroup = "SectionHeader";
            this.textBox104.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox104.Text = "1,234,567,890";
            this.textBox104.Top = 0.375F;
            this.textBox104.Width = 0.8125F;
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
            this.textBox105.DataField = "TotalAfCalTMonthAccRecOther";
            this.textBox105.Height = 0.125F;
            this.textBox105.Left = 8.625F;
            this.textBox105.MultiLine = false;
            this.textBox105.Name = "textBox105";
            this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
            this.textBox105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox105.SummaryGroup = "SectionHeader";
            this.textBox105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox105.Text = "1,234,567,890";
            this.textBox105.Top = 0.375F;
            this.textBox105.Width = 0.8125F;
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
            this.textBox106.DataField = "TotalSalesSlipCountOther";
            this.textBox106.Height = 0.125F;
            this.textBox106.Left = 10.25F;
            this.textBox106.MultiLine = false;
            this.textBox106.Name = "textBox106";
            this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
            this.textBox106.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox106.SummaryGroup = "SectionHeader";
            this.textBox106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox106.Text = "123,456";
            this.textBox106.Top = 0.375F;
            this.textBox106.Width = 0.5F;
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
            this.label14.Left = 4.625F;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
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
            this.label15.Left = 4.625F;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
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
            this.label16.Left = 4.625F;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "その他";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.75F;
            // 
            // AgentHeader2
            // 
            this.AgentHeader2.CanShrink = true;
            this.AgentHeader2.Height = 0F;
            this.AgentHeader2.Name = "AgentHeader2";
            this.AgentHeader2.Visible = false;
            // 
            // AgentFooter2
            // 
            this.AgentFooter2.CanShrink = true;
            this.AgentFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.a_CashDeposit2,
            this.a_TrfrDeposit2,
            this.a_CheckDeposit2,
            this.a_DraftDeposit2,
            this.a_OffsetDeposit2,
            this.a_FundTransferDeposit2,
            this.a_OthsDeposit2,
            this.a_ThisTimeFeeDmdNrml2,
            this.a_ThisTimeDisDmdNrml2,
            this.line7,
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
            this.textBox88,
            this.textBox89,
            this.textBox90,
            this.textBox91,
            this.textBox92,
            this.textBox93,
            this.textBox94,
            this.textBox95,
            this.label10,
            this.label12,
            this.label13,
            this.label22,
            this.textBox141,
            this.textBox142,
            this.textBox143,
            this.textBox144,
            this.textBox145,
            this.textBox146});
            this.AgentFooter2.Height = 0.8333333F;
            this.AgentFooter2.KeepTogether = true;
            this.AgentFooter2.Name = "AgentFooter2";
            this.AgentFooter2.Visible = false;
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
            this.textBox58.Height = 0.1875F;
            this.textBox58.Left = 0.1875F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox58.Text = "担当者計";
            this.textBox58.Top = 0.0625F;
            this.textBox58.Width = 0.6875F;
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
            this.textBox59.DataField = "LastTimeAccRec";
            this.textBox59.Height = 0.125F;
            this.textBox59.Left = 2.9375F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox59.SummaryGroup = "AgentHeader";
            this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox59.Text = "1,234,567,890";
            this.textBox59.Top = 0F;
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
            this.textBox60.DataField = "ThisTimeDmdNrml";
            this.textBox60.Height = 0.125F;
            this.textBox60.Left = 3.75F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox60.SummaryGroup = "AgentHeader";
            this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox60.Text = "1,234,567,890";
            this.textBox60.Top = 0F;
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
            this.textBox61.DataField = "ThisTimeTtlBlcAcc";
            this.textBox61.Height = 0.125F;
            this.textBox61.Left = 4.5625F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox61.SummaryGroup = "AgentHeader";
            this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox61.Text = "1,234,567,890";
            this.textBox61.Top = 0F;
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
            this.textBox62.DataField = "ThisTimeSales";
            this.textBox62.Height = 0.125F;
            this.textBox62.Left = 5.375F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox62.SummaryGroup = "AgentHeader";
            this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox62.Text = "1,234,567,890";
            this.textBox62.Top = 0F;
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
            this.textBox63.DataField = "ThisRgdsDisPric";
            this.textBox63.Height = 0.125F;
            this.textBox63.Left = 6.1875F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox63.SummaryGroup = "AgentHeader";
            this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox63.Text = "1,234,567,890";
            this.textBox63.Top = 0F;
            this.textBox63.Width = 0.8125F;
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
            this.textBox64.DataField = "PureSales";
            this.textBox64.Height = 0.125F;
            this.textBox64.Left = 7F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.SummaryGroup = "AgentHeader";
            this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox64.Text = "1,234,567,890";
            this.textBox64.Top = 0F;
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
            this.textBox65.DataField = "OfsThisSalesTax";
            this.textBox65.Height = 0.125F;
            this.textBox65.Left = 7.8125F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
            this.textBox65.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox65.SummaryGroup = "AgentHeader";
            this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox65.Text = "1,234,567,890";
            this.textBox65.Top = 0F;
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
            this.textBox66.DataField = "SalesPricTax";
            this.textBox66.Height = 0.125F;
            this.textBox66.Left = 8.625F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
            this.textBox66.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox66.SummaryGroup = "AgentHeader";
            this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox66.Text = "1,234,567,890";
            this.textBox66.Top = 0F;
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
            this.textBox67.DataField = "AfCalTMonthAccRec";
            this.textBox67.Height = 0.125F;
            this.textBox67.Left = 9.4375F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
            this.textBox67.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox67.SummaryGroup = "AgentHeader";
            this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox67.Text = "1,234,567,890";
            this.textBox67.Top = 0F;
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
            this.textBox68.DataField = "SalesSlipCount";
            this.textBox68.Height = 0.125F;
            this.textBox68.Left = 10.25F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
            this.textBox68.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox68.SummaryGroup = "AgentHeader";
            this.textBox68.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox68.Text = "123,456";
            this.textBox68.Top = 0F;
            this.textBox68.Width = 0.5F;
            // 
            // a_CashDeposit2
            // 
            this.a_CashDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_CashDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_CashDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_CashDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_CashDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CashDeposit2.DataField = "CashDeposit";
            this.a_CashDeposit2.Height = 0.125F;
            this.a_CashDeposit2.Left = 2.9375F;
            this.a_CashDeposit2.MultiLine = false;
            this.a_CashDeposit2.Name = "a_CashDeposit2";
            this.a_CashDeposit2.OutputFormat = resources.GetString("a_CashDeposit2.OutputFormat");
            this.a_CashDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_CashDeposit2.SummaryGroup = "SectionHeader";
            this.a_CashDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_CashDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_CashDeposit2.Text = "1,234,567,890";
            this.a_CashDeposit2.Top = 0.625F;
            this.a_CashDeposit2.Width = 0.8125F;
            // 
            // a_TrfrDeposit2
            // 
            this.a_TrfrDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_TrfrDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_TrfrDeposit2.DataField = "TrfrDeposit";
            this.a_TrfrDeposit2.Height = 0.125F;
            this.a_TrfrDeposit2.Left = 3.75F;
            this.a_TrfrDeposit2.MultiLine = false;
            this.a_TrfrDeposit2.Name = "a_TrfrDeposit2";
            this.a_TrfrDeposit2.OutputFormat = resources.GetString("a_TrfrDeposit2.OutputFormat");
            this.a_TrfrDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_TrfrDeposit2.SummaryGroup = "SectionHeader";
            this.a_TrfrDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_TrfrDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_TrfrDeposit2.Text = "1,234,567,890";
            this.a_TrfrDeposit2.Top = 0.625F;
            this.a_TrfrDeposit2.Width = 0.8125F;
            // 
            // a_CheckDeposit2
            // 
            this.a_CheckDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_CheckDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_CheckDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_CheckDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_CheckDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_CheckDeposit2.DataField = "CheckDeposit";
            this.a_CheckDeposit2.Height = 0.125F;
            this.a_CheckDeposit2.Left = 4.5625F;
            this.a_CheckDeposit2.MultiLine = false;
            this.a_CheckDeposit2.Name = "a_CheckDeposit2";
            this.a_CheckDeposit2.OutputFormat = resources.GetString("a_CheckDeposit2.OutputFormat");
            this.a_CheckDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_CheckDeposit2.SummaryGroup = "SectionHeader";
            this.a_CheckDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_CheckDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_CheckDeposit2.Text = "1,234,567,890";
            this.a_CheckDeposit2.Top = 0.625F;
            this.a_CheckDeposit2.Width = 0.8125F;
            // 
            // a_DraftDeposit2
            // 
            this.a_DraftDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_DraftDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_DraftDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_DraftDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_DraftDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_DraftDeposit2.DataField = "DraftDeposit";
            this.a_DraftDeposit2.Height = 0.125F;
            this.a_DraftDeposit2.Left = 5.375F;
            this.a_DraftDeposit2.MultiLine = false;
            this.a_DraftDeposit2.Name = "a_DraftDeposit2";
            this.a_DraftDeposit2.OutputFormat = resources.GetString("a_DraftDeposit2.OutputFormat");
            this.a_DraftDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_DraftDeposit2.SummaryGroup = "SectionHeader";
            this.a_DraftDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_DraftDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_DraftDeposit2.Text = "1,234,567,890";
            this.a_DraftDeposit2.Top = 0.625F;
            this.a_DraftDeposit2.Width = 0.8125F;
            // 
            // a_OffsetDeposit2
            // 
            this.a_OffsetDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_OffsetDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OffsetDeposit2.DataField = "OffsetDeposit";
            this.a_OffsetDeposit2.Height = 0.125F;
            this.a_OffsetDeposit2.Left = 6.1875F;
            this.a_OffsetDeposit2.MultiLine = false;
            this.a_OffsetDeposit2.Name = "a_OffsetDeposit2";
            this.a_OffsetDeposit2.OutputFormat = resources.GetString("a_OffsetDeposit2.OutputFormat");
            this.a_OffsetDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_OffsetDeposit2.SummaryGroup = "SectionHeader";
            this.a_OffsetDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_OffsetDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_OffsetDeposit2.Text = "1,234,567,890";
            this.a_OffsetDeposit2.Top = 0.625F;
            this.a_OffsetDeposit2.Width = 0.8125F;
            // 
            // a_FundTransferDeposit2
            // 
            this.a_FundTransferDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_FundTransferDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_FundTransferDeposit2.DataField = "FundTransferDeposit";
            this.a_FundTransferDeposit2.Height = 0.125F;
            this.a_FundTransferDeposit2.Left = 7.8125F;
            this.a_FundTransferDeposit2.MultiLine = false;
            this.a_FundTransferDeposit2.Name = "a_FundTransferDeposit2";
            this.a_FundTransferDeposit2.OutputFormat = resources.GetString("a_FundTransferDeposit2.OutputFormat");
            this.a_FundTransferDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_FundTransferDeposit2.SummaryGroup = "SectionHeader";
            this.a_FundTransferDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_FundTransferDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_FundTransferDeposit2.Text = "1,234,567,890";
            this.a_FundTransferDeposit2.Top = 0.625F;
            this.a_FundTransferDeposit2.Width = 0.8125F;
            // 
            // a_OthsDeposit2
            // 
            this.a_OthsDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_OthsDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_OthsDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.a_OthsDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.a_OthsDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_OthsDeposit2.DataField = "OthsDeposit";
            this.a_OthsDeposit2.Height = 0.125F;
            this.a_OthsDeposit2.Left = 7F;
            this.a_OthsDeposit2.MultiLine = false;
            this.a_OthsDeposit2.Name = "a_OthsDeposit2";
            this.a_OthsDeposit2.OutputFormat = resources.GetString("a_OthsDeposit2.OutputFormat");
            this.a_OthsDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_OthsDeposit2.SummaryGroup = "SectionHeader";
            this.a_OthsDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_OthsDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_OthsDeposit2.Text = "1,234,567,890";
            this.a_OthsDeposit2.Top = 0.625F;
            this.a_OthsDeposit2.Width = 0.8125F;
            // 
            // a_ThisTimeFeeDmdNrml2
            // 
            this.a_ThisTimeFeeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.a_ThisTimeFeeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeFeeDmdNrml2.DataField = "ThisTimeFeeDmdNrml";
            this.a_ThisTimeFeeDmdNrml2.Height = 0.125F;
            this.a_ThisTimeFeeDmdNrml2.Left = 8.625F;
            this.a_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.a_ThisTimeFeeDmdNrml2.Name = "a_ThisTimeFeeDmdNrml2";
            this.a_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("a_ThisTimeFeeDmdNrml2.OutputFormat");
            this.a_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_ThisTimeFeeDmdNrml2.SummaryGroup = "SectionHeader";
            this.a_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_ThisTimeFeeDmdNrml2.Text = "1,234,567,890";
            this.a_ThisTimeFeeDmdNrml2.Top = 0.625F;
            this.a_ThisTimeFeeDmdNrml2.Width = 0.8125F;
            // 
            // a_ThisTimeDisDmdNrml2
            // 
            this.a_ThisTimeDisDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.a_ThisTimeDisDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.a_ThisTimeDisDmdNrml2.DataField = "ThisTimeDisDmdNrml";
            this.a_ThisTimeDisDmdNrml2.Height = 0.125F;
            this.a_ThisTimeDisDmdNrml2.Left = 9.4375F;
            this.a_ThisTimeDisDmdNrml2.MultiLine = false;
            this.a_ThisTimeDisDmdNrml2.Name = "a_ThisTimeDisDmdNrml2";
            this.a_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("a_ThisTimeDisDmdNrml2.OutputFormat");
            this.a_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.a_ThisTimeDisDmdNrml2.SummaryGroup = "SectionHeader";
            this.a_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.a_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.a_ThisTimeDisDmdNrml2.Text = "1,234,567,890";
            this.a_ThisTimeDisDmdNrml2.Top = 0.625F;
            this.a_ThisTimeDisDmdNrml2.Width = 0.8125F;
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
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
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
            this.textBox78.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox78.Height = 0.125F;
            this.textBox78.Left = 5.375F;
            this.textBox78.MultiLine = false;
            this.textBox78.Name = "textBox78";
            this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
            this.textBox78.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox78.SummaryGroup = "AgentHeader";
            this.textBox78.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox78.Text = "1,234,567,890";
            this.textBox78.Top = 0.125F;
            this.textBox78.Width = 0.8125F;
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
            this.textBox79.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox79.Height = 0.125F;
            this.textBox79.Left = 6.1875F;
            this.textBox79.MultiLine = false;
            this.textBox79.Name = "textBox79";
            this.textBox79.OutputFormat = resources.GetString("textBox79.OutputFormat");
            this.textBox79.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox79.SummaryGroup = "AgentHeader";
            this.textBox79.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox79.Text = "1,234,567,890";
            this.textBox79.Top = 0.125F;
            this.textBox79.Width = 0.8125F;
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
            this.textBox80.DataField = "TotalPureSalesTaxRate1";
            this.textBox80.Height = 0.125F;
            this.textBox80.Left = 7F;
            this.textBox80.MultiLine = false;
            this.textBox80.Name = "textBox80";
            this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
            this.textBox80.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox80.SummaryGroup = "AgentHeader";
            this.textBox80.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox80.Text = "1,234,567,890";
            this.textBox80.Top = 0.125F;
            this.textBox80.Width = 0.8125F;
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
            this.textBox81.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox81.Height = 0.125F;
            this.textBox81.Left = 7.8125F;
            this.textBox81.MultiLine = false;
            this.textBox81.Name = "textBox81";
            this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
            this.textBox81.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox81.SummaryGroup = "AgentHeader";
            this.textBox81.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox81.Text = "1,234,567,890";
            this.textBox81.Top = 0.125F;
            this.textBox81.Width = 0.8125F;
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
            this.textBox82.DataField = "TotalAfCalTMonthAccRecTaxRate1";
            this.textBox82.Height = 0.125F;
            this.textBox82.Left = 8.625F;
            this.textBox82.MultiLine = false;
            this.textBox82.Name = "textBox82";
            this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
            this.textBox82.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox82.SummaryGroup = "AgentHeader";
            this.textBox82.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox82.Text = "1,234,567,890";
            this.textBox82.Top = 0.125F;
            this.textBox82.Width = 0.8125F;
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
            this.textBox83.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox83.Height = 0.125F;
            this.textBox83.Left = 10.25F;
            this.textBox83.MultiLine = false;
            this.textBox83.Name = "textBox83";
            this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
            this.textBox83.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox83.SummaryGroup = "AgentHeader";
            this.textBox83.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox83.Text = "123,456";
            this.textBox83.Top = 0.125F;
            this.textBox83.Width = 0.5F;
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
            this.textBox84.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox84.Height = 0.125F;
            this.textBox84.Left = 5.375F;
            this.textBox84.MultiLine = false;
            this.textBox84.Name = "textBox84";
            this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
            this.textBox84.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox84.SummaryGroup = "AgentHeader";
            this.textBox84.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox84.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox84.Text = "1,234,567,890";
            this.textBox84.Top = 0.25F;
            this.textBox84.Width = 0.8125F;
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
            this.textBox85.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox85.Height = 0.125F;
            this.textBox85.Left = 6.1875F;
            this.textBox85.MultiLine = false;
            this.textBox85.Name = "textBox85";
            this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
            this.textBox85.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox85.SummaryGroup = "AgentHeader";
            this.textBox85.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox85.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox85.Text = "1,234,567,890";
            this.textBox85.Top = 0.25F;
            this.textBox85.Width = 0.8125F;
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
            this.textBox86.DataField = "TotalPureSalesTaxRate2";
            this.textBox86.Height = 0.125F;
            this.textBox86.Left = 7F;
            this.textBox86.MultiLine = false;
            this.textBox86.Name = "textBox86";
            this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
            this.textBox86.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox86.SummaryGroup = "AgentHeader";
            this.textBox86.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox86.Text = "1,234,567,890";
            this.textBox86.Top = 0.25F;
            this.textBox86.Width = 0.8125F;
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
            this.textBox87.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox87.Height = 0.125F;
            this.textBox87.Left = 7.8125F;
            this.textBox87.MultiLine = false;
            this.textBox87.Name = "textBox87";
            this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
            this.textBox87.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox87.SummaryGroup = "AgentHeader";
            this.textBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox87.Text = "1,234,567,890";
            this.textBox87.Top = 0.25F;
            this.textBox87.Width = 0.8125F;
            // 
            // textBox88
            // 
            this.textBox88.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.RightColor = System.Drawing.Color.Black;
            this.textBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.TopColor = System.Drawing.Color.Black;
            this.textBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.DataField = "TotalAfCalTMonthAccRecTaxRate2";
            this.textBox88.Height = 0.125F;
            this.textBox88.Left = 8.625F;
            this.textBox88.MultiLine = false;
            this.textBox88.Name = "textBox88";
            this.textBox88.OutputFormat = resources.GetString("textBox88.OutputFormat");
            this.textBox88.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox88.SummaryGroup = "AgentHeader";
            this.textBox88.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox88.Text = "1,234,567,890";
            this.textBox88.Top = 0.25F;
            this.textBox88.Width = 0.8125F;
            // 
            // textBox89
            // 
            this.textBox89.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.RightColor = System.Drawing.Color.Black;
            this.textBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.TopColor = System.Drawing.Color.Black;
            this.textBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox89.Height = 0.125F;
            this.textBox89.Left = 10.25F;
            this.textBox89.MultiLine = false;
            this.textBox89.Name = "textBox89";
            this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
            this.textBox89.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox89.SummaryGroup = "AgentHeader";
            this.textBox89.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox89.Text = "123,456";
            this.textBox89.Top = 0.25F;
            this.textBox89.Width = 0.5F;
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
            this.textBox90.DataField = "TotalThisTimeSalesOther";
            this.textBox90.Height = 0.125F;
            this.textBox90.Left = 5.375F;
            this.textBox90.MultiLine = false;
            this.textBox90.Name = "textBox90";
            this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
            this.textBox90.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox90.SummaryGroup = "AgentHeader";
            this.textBox90.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox90.Text = "1,234,567,890";
            this.textBox90.Top = 0.375F;
            this.textBox90.Width = 0.8125F;
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
            this.textBox91.DataField = "TotalThisRgdsDisPricOther";
            this.textBox91.Height = 0.125F;
            this.textBox91.Left = 6.1875F;
            this.textBox91.MultiLine = false;
            this.textBox91.Name = "textBox91";
            this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
            this.textBox91.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox91.SummaryGroup = "AgentHeader";
            this.textBox91.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox91.Text = "1,234,567,890";
            this.textBox91.Top = 0.375F;
            this.textBox91.Width = 0.8125F;
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
            this.textBox92.DataField = "TotalPureSalesOther";
            this.textBox92.Height = 0.125F;
            this.textBox92.Left = 7F;
            this.textBox92.MultiLine = false;
            this.textBox92.Name = "textBox92";
            this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
            this.textBox92.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox92.SummaryGroup = "AgentHeader";
            this.textBox92.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox92.Text = "1,234,567,890";
            this.textBox92.Top = 0.375F;
            this.textBox92.Width = 0.8125F;
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
            this.textBox93.DataField = "TotalSalesPricTaxOther";
            this.textBox93.Height = 0.125F;
            this.textBox93.Left = 7.8125F;
            this.textBox93.MultiLine = false;
            this.textBox93.Name = "textBox93";
            this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
            this.textBox93.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox93.SummaryGroup = "AgentHeader";
            this.textBox93.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox93.Text = "1,234,567,890";
            this.textBox93.Top = 0.375F;
            this.textBox93.Width = 0.8125F;
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
            this.textBox94.DataField = "TotalAfCalTMonthAccRecOther";
            this.textBox94.Height = 0.125F;
            this.textBox94.Left = 8.625F;
            this.textBox94.MultiLine = false;
            this.textBox94.Name = "textBox94";
            this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
            this.textBox94.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox94.SummaryGroup = "AgentHeader";
            this.textBox94.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox94.Text = "1,234,567,890";
            this.textBox94.Top = 0.375F;
            this.textBox94.Width = 0.8125F;
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
            this.textBox95.DataField = "TotalSalesSlipCountOther";
            this.textBox95.Height = 0.125F;
            this.textBox95.Left = 10.25F;
            this.textBox95.MultiLine = false;
            this.textBox95.Name = "textBox95";
            this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
            this.textBox95.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox95.SummaryGroup = "AgentHeader";
            this.textBox95.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox95.Text = "123,456";
            this.textBox95.Top = 0.375F;
            this.textBox95.Width = 0.5F;
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
            this.label10.DataField = "TitleTaxRate1";
            this.label10.Height = 0.125F;
            this.label10.HyperLink = null;
            this.label10.Left = 4.6275F;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "10%";
            this.label10.Top = 0.125F;
            this.label10.Width = 0.75F;
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
            this.label12.Left = 4.625F;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
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
            this.label13.Left = 4.625F;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "その他";
            this.label13.Top = 0.375F;
            this.label13.Width = 0.75F;
            // 
            // SalesAreaHeader2
            // 
            this.SalesAreaHeader2.CanShrink = true;
            this.SalesAreaHeader2.Height = 0F;
            this.SalesAreaHeader2.Name = "SalesAreaHeader2";
            this.SalesAreaHeader2.Visible = false;
            // 
            // SalesAreaFooter2
            // 
            this.SalesAreaFooter2.CanShrink = true;
            this.SalesAreaFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox16,
            this.textBox17,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.line6,
            this.t_CashDeposit2,
            this.t_TrfrDeposit2,
            this.t_CheckDeposit2,
            this.t_DraftDeposit2,
            this.t_OffsetDeposit2,
            this.t_FundTransferDeposit2,
            this.t_OthsDeposit2,
            this.t_ThisTimeFeeDmdNrml2,
            this.t_ThisTimeDisDmdNrml2,
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
            this.s_TaxTotalTitleTaxRate1,
            this.s_TaxTotalTitleTaxRate2,
            this.s_TaxTotalTitleOther,
            this.label21,
            this.textBox135,
            this.textBox136,
            this.textBox137,
            this.textBox138,
            this.textBox139,
            this.textBox140});
            this.SalesAreaFooter2.Height = 0.8645833F;
            this.SalesAreaFooter2.Name = "SalesAreaFooter2";
            this.SalesAreaFooter2.Visible = false;
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
            this.textBox16.Height = 0.1875F;
            this.textBox16.Left = 0.1875F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox16.Text = "地区計";
            this.textBox16.Top = 0.0625F;
            this.textBox16.Width = 0.6875F;
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
            this.textBox17.DataField = "LastTimeAccRec";
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 2.9375F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox17.SummaryGroup = "SalesAreaHeader";
            this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox17.Text = "1,234,567,890";
            this.textBox17.Top = 0F;
            this.textBox17.Width = 0.8125F;
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
            this.textBox22.DataField = "ThisTimeDmdNrml";
            this.textBox22.Height = 0.125F;
            this.textBox22.Left = 3.75F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox22.SummaryGroup = "SalesAreaHeader";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox23.DataField = "ThisTimeTtlBlcAcc";
            this.textBox23.Height = 0.125F;
            this.textBox23.Left = 4.5625F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox23.SummaryGroup = "SalesAreaHeader";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox24.DataField = "ThisTimeSales";
            this.textBox24.Height = 0.125F;
            this.textBox24.Left = 5.375F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox24.SummaryGroup = "SalesAreaHeader";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox25.DataField = "ThisRgdsDisPric";
            this.textBox25.Height = 0.125F;
            this.textBox25.Left = 6.1875F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox25.SummaryGroup = "SalesAreaHeader";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox26.DataField = "PureSales";
            this.textBox26.Height = 0.125F;
            this.textBox26.Left = 7F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox26.SummaryGroup = "SalesAreaHeader";
            this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox27.DataField = "OfsThisSalesTax";
            this.textBox27.Height = 0.125F;
            this.textBox27.Left = 7.8125F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox27.SummaryGroup = "SalesAreaHeader";
            this.textBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox28.DataField = "SalesPricTax";
            this.textBox28.Height = 0.125F;
            this.textBox28.Left = 8.625F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox28.SummaryGroup = "SalesAreaHeader";
            this.textBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox28.Text = "1,234,567,890";
            this.textBox28.Top = 0F;
            this.textBox28.Width = 0.8125F;
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
            this.textBox29.DataField = "AfCalTMonthAccRec";
            this.textBox29.Height = 0.125F;
            this.textBox29.Left = 9.4375F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.SummaryGroup = "SalesAreaHeader";
            this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
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
            this.textBox30.DataField = "SalesSlipCount";
            this.textBox30.Height = 0.125F;
            this.textBox30.Left = 10.25F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox30.SummaryGroup = "SalesAreaHeader";
            this.textBox30.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox30.Text = "123,456";
            this.textBox30.Top = 0F;
            this.textBox30.Width = 0.5F;
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
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // t_CashDeposit2
            // 
            this.t_CashDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_CashDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_CashDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_CashDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_CashDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashDeposit2.DataField = "CashDeposit";
            this.t_CashDeposit2.Height = 0.125F;
            this.t_CashDeposit2.Left = 2.9375F;
            this.t_CashDeposit2.MultiLine = false;
            this.t_CashDeposit2.Name = "t_CashDeposit2";
            this.t_CashDeposit2.OutputFormat = resources.GetString("t_CashDeposit2.OutputFormat");
            this.t_CashDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_CashDeposit2.SummaryGroup = "SectionHeader";
            this.t_CashDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_CashDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_CashDeposit2.Text = "1,234,567,890";
            this.t_CashDeposit2.Top = 0.625F;
            this.t_CashDeposit2.Width = 0.8125F;
            // 
            // t_TrfrDeposit2
            // 
            this.t_TrfrDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_TrfrDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrDeposit2.DataField = "TrfrDeposit";
            this.t_TrfrDeposit2.Height = 0.125F;
            this.t_TrfrDeposit2.Left = 3.75F;
            this.t_TrfrDeposit2.MultiLine = false;
            this.t_TrfrDeposit2.Name = "t_TrfrDeposit2";
            this.t_TrfrDeposit2.OutputFormat = resources.GetString("t_TrfrDeposit2.OutputFormat");
            this.t_TrfrDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_TrfrDeposit2.SummaryGroup = "SectionHeader";
            this.t_TrfrDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_TrfrDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_TrfrDeposit2.Text = "1,234,567,890";
            this.t_TrfrDeposit2.Top = 0.625F;
            this.t_TrfrDeposit2.Width = 0.8125F;
            // 
            // t_CheckDeposit2
            // 
            this.t_CheckDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_CheckDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_CheckDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_CheckDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_CheckDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckDeposit2.DataField = "CheckDeposit";
            this.t_CheckDeposit2.Height = 0.125F;
            this.t_CheckDeposit2.Left = 4.5625F;
            this.t_CheckDeposit2.MultiLine = false;
            this.t_CheckDeposit2.Name = "t_CheckDeposit2";
            this.t_CheckDeposit2.OutputFormat = resources.GetString("t_CheckDeposit2.OutputFormat");
            this.t_CheckDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_CheckDeposit2.SummaryGroup = "SectionHeader";
            this.t_CheckDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_CheckDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_CheckDeposit2.Text = "1,234,567,890";
            this.t_CheckDeposit2.Top = 0.625F;
            this.t_CheckDeposit2.Width = 0.8125F;
            // 
            // t_DraftDeposit2
            // 
            this.t_DraftDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_DraftDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_DraftDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_DraftDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_DraftDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftDeposit2.DataField = "DraftDeposit";
            this.t_DraftDeposit2.Height = 0.125F;
            this.t_DraftDeposit2.Left = 5.375F;
            this.t_DraftDeposit2.MultiLine = false;
            this.t_DraftDeposit2.Name = "t_DraftDeposit2";
            this.t_DraftDeposit2.OutputFormat = resources.GetString("t_DraftDeposit2.OutputFormat");
            this.t_DraftDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_DraftDeposit2.SummaryGroup = "SectionHeader";
            this.t_DraftDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_DraftDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_DraftDeposit2.Text = "1,234,567,890";
            this.t_DraftDeposit2.Top = 0.625F;
            this.t_DraftDeposit2.Width = 0.8125F;
            // 
            // t_OffsetDeposit2
            // 
            this.t_OffsetDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_OffsetDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetDeposit2.DataField = "OffsetDeposit";
            this.t_OffsetDeposit2.Height = 0.125F;
            this.t_OffsetDeposit2.Left = 6.1875F;
            this.t_OffsetDeposit2.MultiLine = false;
            this.t_OffsetDeposit2.Name = "t_OffsetDeposit2";
            this.t_OffsetDeposit2.OutputFormat = resources.GetString("t_OffsetDeposit2.OutputFormat");
            this.t_OffsetDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_OffsetDeposit2.SummaryGroup = "SectionHeader";
            this.t_OffsetDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_OffsetDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_OffsetDeposit2.Text = "1,234,567,890";
            this.t_OffsetDeposit2.Top = 0.625F;
            this.t_OffsetDeposit2.Width = 0.8125F;
            // 
            // t_FundTransferDeposit2
            // 
            this.t_FundTransferDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_FundTransferDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferDeposit2.DataField = "FundTransferDeposit";
            this.t_FundTransferDeposit2.Height = 0.125F;
            this.t_FundTransferDeposit2.Left = 7.8125F;
            this.t_FundTransferDeposit2.MultiLine = false;
            this.t_FundTransferDeposit2.Name = "t_FundTransferDeposit2";
            this.t_FundTransferDeposit2.OutputFormat = resources.GetString("t_FundTransferDeposit2.OutputFormat");
            this.t_FundTransferDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_FundTransferDeposit2.SummaryGroup = "SectionHeader";
            this.t_FundTransferDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_FundTransferDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_FundTransferDeposit2.Text = "1,234,567,890";
            this.t_FundTransferDeposit2.Top = 0.625F;
            this.t_FundTransferDeposit2.Width = 0.8125F;
            // 
            // t_OthsDeposit2
            // 
            this.t_OthsDeposit2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_OthsDeposit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_OthsDeposit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit2.Border.RightColor = System.Drawing.Color.Black;
            this.t_OthsDeposit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit2.Border.TopColor = System.Drawing.Color.Black;
            this.t_OthsDeposit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsDeposit2.DataField = "OthsDeposit";
            this.t_OthsDeposit2.Height = 0.125F;
            this.t_OthsDeposit2.Left = 7F;
            this.t_OthsDeposit2.MultiLine = false;
            this.t_OthsDeposit2.Name = "t_OthsDeposit2";
            this.t_OthsDeposit2.OutputFormat = resources.GetString("t_OthsDeposit2.OutputFormat");
            this.t_OthsDeposit2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_OthsDeposit2.SummaryGroup = "SectionHeader";
            this.t_OthsDeposit2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_OthsDeposit2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_OthsDeposit2.Text = "1,234,567,890";
            this.t_OthsDeposit2.Top = 0.625F;
            this.t_OthsDeposit2.Width = 0.8125F;
            // 
            // t_ThisTimeFeeDmdNrml2
            // 
            this.t_ThisTimeFeeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeeDmdNrml2.DataField = "ThisTimeFeeDmdNrml";
            this.t_ThisTimeFeeDmdNrml2.Height = 0.125F;
            this.t_ThisTimeFeeDmdNrml2.Left = 8.625F;
            this.t_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.t_ThisTimeFeeDmdNrml2.Name = "t_ThisTimeFeeDmdNrml2";
            this.t_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("t_ThisTimeFeeDmdNrml2.OutputFormat");
            this.t_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeFeeDmdNrml2.SummaryGroup = "SectionHeader";
            this.t_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_ThisTimeFeeDmdNrml2.Text = "1,234,567,890";
            this.t_ThisTimeFeeDmdNrml2.Top = 0.625F;
            this.t_ThisTimeFeeDmdNrml2.Width = 0.8125F;
            // 
            // t_ThisTimeDisDmdNrml2
            // 
            this.t_ThisTimeDisDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisDmdNrml2.DataField = "ThisTimeDisDmdNrml";
            this.t_ThisTimeDisDmdNrml2.Height = 0.125F;
            this.t_ThisTimeDisDmdNrml2.Left = 9.4375F;
            this.t_ThisTimeDisDmdNrml2.MultiLine = false;
            this.t_ThisTimeDisDmdNrml2.Name = "t_ThisTimeDisDmdNrml2";
            this.t_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("t_ThisTimeDisDmdNrml2.OutputFormat");
            this.t_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeDisDmdNrml2.SummaryGroup = "SectionHeader";
            this.t_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.t_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.t_ThisTimeDisDmdNrml2.Text = "1,234,567,890";
            this.t_ThisTimeDisDmdNrml2.Top = 0.625F;
            this.t_ThisTimeDisDmdNrml2.Width = 0.8125F;
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
            this.textBox40.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox40.Height = 0.125F;
            this.textBox40.Left = 5.375F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.SummaryGroup = "SalesAreaHeader";
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
            this.textBox41.Left = 6.1875F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox41.SummaryGroup = "SalesAreaHeader";
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
            this.textBox42.DataField = "TotalPureSalesTaxRate1";
            this.textBox42.Height = 0.125F;
            this.textBox42.Left = 7F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox42.SummaryGroup = "SalesAreaHeader";
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
            this.textBox43.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox43.Height = 0.125F;
            this.textBox43.Left = 7.8125F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox43.SummaryGroup = "SalesAreaHeader";
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
            this.textBox44.DataField = "TotalAfCalTMonthAccRecTaxRate1";
            this.textBox44.Height = 0.125F;
            this.textBox44.Left = 8.625F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.SummaryGroup = "SalesAreaHeader";
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
            this.textBox45.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox45.Height = 0.125F;
            this.textBox45.Left = 10.25F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox45.SummaryGroup = "SalesAreaHeader";
            this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox45.Text = "123,456";
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
            this.textBox46.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox46.Height = 0.125F;
            this.textBox46.Left = 5.375F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryGroup = "SalesAreaHeader";
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
            this.textBox47.Left = 6.1875F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox47.SummaryGroup = "SalesAreaHeader";
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
            this.textBox48.DataField = "TotalPureSalesTaxRate2";
            this.textBox48.Height = 0.125F;
            this.textBox48.Left = 7F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox48.SummaryGroup = "SalesAreaHeader";
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
            this.textBox49.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox49.Height = 0.125F;
            this.textBox49.Left = 7.8125F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox49.SummaryGroup = "SalesAreaHeader";
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
            this.textBox50.DataField = "TotalAfCalTMonthAccRecTaxRate2";
            this.textBox50.Height = 0.125F;
            this.textBox50.Left = 8.625F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox50.SummaryGroup = "SalesAreaHeader";
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
            this.textBox51.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox51.Height = 0.125F;
            this.textBox51.Left = 10.25F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox51.SummaryGroup = "SalesAreaHeader";
            this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox51.Text = "123,456";
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
            this.textBox52.DataField = "TotalThisTimeSalesOther";
            this.textBox52.Height = 0.125F;
            this.textBox52.Left = 5.375F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox52.SummaryGroup = "SalesAreaHeader";
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
            this.textBox53.Left = 6.1875F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox53.SummaryGroup = "SalesAreaHeader";
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
            this.textBox54.DataField = "TotalPureSalesOther";
            this.textBox54.Height = 0.125F;
            this.textBox54.Left = 7F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.SummaryGroup = "SalesAreaHeader";
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
            this.textBox55.DataField = "TotalSalesPricTaxOther";
            this.textBox55.Height = 0.125F;
            this.textBox55.Left = 7.8125F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox55.SummaryGroup = "SalesAreaHeader";
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
            this.textBox56.DataField = "TotalAfCalTMonthAccRecOther";
            this.textBox56.Height = 0.125F;
            this.textBox56.Left = 8.625F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox56.SummaryGroup = "SalesAreaHeader";
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
            this.textBox57.DataField = "TotalSalesSlipCountOther";
            this.textBox57.Height = 0.125F;
            this.textBox57.Left = 10.25F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox57.SummaryGroup = "SalesAreaHeader";
            this.textBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox57.Text = "123,456";
            this.textBox57.Top = 0.375F;
            this.textBox57.Width = 0.5F;
            // 
            // s_TaxTotalTitleTaxRate1
            // 
            this.s_TaxTotalTitleTaxRate1.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate1.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate1.Border.RightColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate1.Border.TopColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate1.DataField = "TitleTaxRate1";
            this.s_TaxTotalTitleTaxRate1.Height = 0.125F;
            this.s_TaxTotalTitleTaxRate1.HyperLink = null;
            this.s_TaxTotalTitleTaxRate1.Left = 4.625F;
            this.s_TaxTotalTitleTaxRate1.Name = "s_TaxTotalTitleTaxRate1";
            this.s_TaxTotalTitleTaxRate1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.s_TaxTotalTitleTaxRate1.Text = "10%";
            this.s_TaxTotalTitleTaxRate1.Top = 0.125F;
            this.s_TaxTotalTitleTaxRate1.Width = 0.75F;
            // 
            // s_TaxTotalTitleTaxRate2
            // 
            this.s_TaxTotalTitleTaxRate2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate2.Border.RightColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate2.Border.TopColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleTaxRate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleTaxRate2.DataField = "TitleTaxRate2";
            this.s_TaxTotalTitleTaxRate2.Height = 0.125F;
            this.s_TaxTotalTitleTaxRate2.HyperLink = null;
            this.s_TaxTotalTitleTaxRate2.Left = 4.625F;
            this.s_TaxTotalTitleTaxRate2.Name = "s_TaxTotalTitleTaxRate2";
            this.s_TaxTotalTitleTaxRate2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.s_TaxTotalTitleTaxRate2.Text = "8%";
            this.s_TaxTotalTitleTaxRate2.Top = 0.25F;
            this.s_TaxTotalTitleTaxRate2.Width = 0.75F;
            // 
            // s_TaxTotalTitleOther
            // 
            this.s_TaxTotalTitleOther.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleOther.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleOther.Border.RightColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleOther.Border.TopColor = System.Drawing.Color.Black;
            this.s_TaxTotalTitleOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TaxTotalTitleOther.Height = 0.125F;
            this.s_TaxTotalTitleOther.HyperLink = null;
            this.s_TaxTotalTitleOther.Left = 4.625F;
            this.s_TaxTotalTitleOther.Name = "s_TaxTotalTitleOther";
            this.s_TaxTotalTitleOther.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.s_TaxTotalTitleOther.Text = "その他";
            this.s_TaxTotalTitleOther.Top = 0.375F;
            this.s_TaxTotalTitleOther.Width = 0.75F;
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
            this.label21.Height = 0.125F;
            this.label21.HyperLink = null;
            this.label21.Left = 4.625F;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label21.Text = "非課税";
            this.label21.Top = 0.5F;
            this.label21.Width = 0.75F;
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
            this.textBox135.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox135.Height = 0.125F;
            this.textBox135.Left = 5.375F;
            this.textBox135.MultiLine = false;
            this.textBox135.Name = "textBox135";
            this.textBox135.OutputFormat = resources.GetString("textBox135.OutputFormat");
            this.textBox135.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox135.SummaryGroup = "SalesAreaHeader";
            this.textBox135.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox135.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox135.Text = "1,234,567,890";
            this.textBox135.Top = 0.5F;
            this.textBox135.Width = 0.8125F;
            // 
            // textBox136
            // 
            this.textBox136.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.Border.RightColor = System.Drawing.Color.Black;
            this.textBox136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.Border.TopColor = System.Drawing.Color.Black;
            this.textBox136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox136.Height = 0.125F;
            this.textBox136.Left = 6.1875F;
            this.textBox136.MultiLine = false;
            this.textBox136.Name = "textBox136";
            this.textBox136.OutputFormat = resources.GetString("textBox136.OutputFormat");
            this.textBox136.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox136.SummaryGroup = "SalesAreaHeader";
            this.textBox136.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox136.Text = "1,234,567,890";
            this.textBox136.Top = 0.5F;
            this.textBox136.Width = 0.8125F;
            // 
            // textBox137
            // 
            this.textBox137.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.RightColor = System.Drawing.Color.Black;
            this.textBox137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.TopColor = System.Drawing.Color.Black;
            this.textBox137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.DataField = "TotalPureSalesTaxFree";
            this.textBox137.Height = 0.125F;
            this.textBox137.Left = 7F;
            this.textBox137.MultiLine = false;
            this.textBox137.Name = "textBox137";
            this.textBox137.OutputFormat = resources.GetString("textBox137.OutputFormat");
            this.textBox137.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox137.SummaryGroup = "SalesAreaHeader";
            this.textBox137.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox137.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox137.Text = "1,234,567,890";
            this.textBox137.Top = 0.5F;
            this.textBox137.Width = 0.8125F;
            // 
            // textBox138
            // 
            this.textBox138.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Border.RightColor = System.Drawing.Color.Black;
            this.textBox138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Border.TopColor = System.Drawing.Color.Black;
            this.textBox138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox138.Height = 0.125F;
            this.textBox138.Left = 7.8125F;
            this.textBox138.MultiLine = false;
            this.textBox138.Name = "textBox138";
            this.textBox138.OutputFormat = resources.GetString("textBox138.OutputFormat");
            this.textBox138.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox138.SummaryGroup = "SalesAreaHeader";
            this.textBox138.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox138.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox138.Text = "1,234,567,890";
            this.textBox138.Top = 0.5F;
            this.textBox138.Width = 0.8125F;
            // 
            // textBox139
            // 
            this.textBox139.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox139.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox139.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.Border.RightColor = System.Drawing.Color.Black;
            this.textBox139.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.Border.TopColor = System.Drawing.Color.Black;
            this.textBox139.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.DataField = "TotalAfCalTMonthAccRecTaxFree";
            this.textBox139.Height = 0.125F;
            this.textBox139.Left = 8.625F;
            this.textBox139.MultiLine = false;
            this.textBox139.Name = "textBox139";
            this.textBox139.OutputFormat = resources.GetString("textBox139.OutputFormat");
            this.textBox139.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox139.SummaryGroup = "SalesAreaHeader";
            this.textBox139.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox139.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox139.Text = "1,234,567,890";
            this.textBox139.Top = 0.5F;
            this.textBox139.Width = 0.8125F;
            // 
            // textBox140
            // 
            this.textBox140.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.Border.RightColor = System.Drawing.Color.Black;
            this.textBox140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.Border.TopColor = System.Drawing.Color.Black;
            this.textBox140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox140.Height = 0.125F;
            this.textBox140.Left = 10.25F;
            this.textBox140.MultiLine = false;
            this.textBox140.Name = "textBox140";
            this.textBox140.OutputFormat = resources.GetString("textBox140.OutputFormat");
            this.textBox140.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox140.SummaryGroup = "SalesAreaHeader";
            this.textBox140.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox140.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox140.Text = "123,456";
            this.textBox140.Top = 0.5F;
            this.textBox140.Width = 0.5F;
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
            this.label22.Height = 0.125F;
            this.label22.HyperLink = null;
            this.label22.Left = 4.625F;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label22.Text = "非課税";
            this.label22.Top = 0.5F;
            this.label22.Width = 0.75F;
            // 
            // textBox141
            // 
            this.textBox141.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Border.RightColor = System.Drawing.Color.Black;
            this.textBox141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Border.TopColor = System.Drawing.Color.Black;
            this.textBox141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox141.Height = 0.125F;
            this.textBox141.Left = 5.375F;
            this.textBox141.MultiLine = false;
            this.textBox141.Name = "textBox141";
            this.textBox141.OutputFormat = resources.GetString("textBox141.OutputFormat");
            this.textBox141.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox141.SummaryGroup = "AgentHeader";
            this.textBox141.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox141.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox141.Text = "1,234,567,890";
            this.textBox141.Top = 0.5F;
            this.textBox141.Width = 0.8125F;
            // 
            // textBox142
            // 
            this.textBox142.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.Border.RightColor = System.Drawing.Color.Black;
            this.textBox142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.Border.TopColor = System.Drawing.Color.Black;
            this.textBox142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox142.Height = 0.125F;
            this.textBox142.Left = 6.1875F;
            this.textBox142.MultiLine = false;
            this.textBox142.Name = "textBox142";
            this.textBox142.OutputFormat = resources.GetString("textBox142.OutputFormat");
            this.textBox142.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox142.SummaryGroup = "AgentHeader";
            this.textBox142.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox142.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox142.Text = "1,234,567,890";
            this.textBox142.Top = 0.5F;
            this.textBox142.Width = 0.8125F;
            // 
            // textBox143
            // 
            this.textBox143.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.Border.RightColor = System.Drawing.Color.Black;
            this.textBox143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.Border.TopColor = System.Drawing.Color.Black;
            this.textBox143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.DataField = "TotalPureSalesTaxFree";
            this.textBox143.Height = 0.125F;
            this.textBox143.Left = 7F;
            this.textBox143.MultiLine = false;
            this.textBox143.Name = "textBox143";
            this.textBox143.OutputFormat = resources.GetString("textBox143.OutputFormat");
            this.textBox143.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox143.SummaryGroup = "AgentHeader";
            this.textBox143.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox143.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox143.Text = "1,234,567,890";
            this.textBox143.Top = 0.5F;
            this.textBox143.Width = 0.8125F;
            // 
            // textBox144
            // 
            this.textBox144.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Border.RightColor = System.Drawing.Color.Black;
            this.textBox144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Border.TopColor = System.Drawing.Color.Black;
            this.textBox144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox144.Height = 0.125F;
            this.textBox144.Left = 7.8125F;
            this.textBox144.MultiLine = false;
            this.textBox144.Name = "textBox144";
            this.textBox144.OutputFormat = resources.GetString("textBox144.OutputFormat");
            this.textBox144.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox144.SummaryGroup = "AgentHeader";
            this.textBox144.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox144.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox144.Text = "1,234,567,890";
            this.textBox144.Top = 0.5F;
            this.textBox144.Width = 0.8125F;
            // 
            // textBox145
            // 
            this.textBox145.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.Border.RightColor = System.Drawing.Color.Black;
            this.textBox145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.Border.TopColor = System.Drawing.Color.Black;
            this.textBox145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.DataField = "TotalAfCalTMonthAccRecTaxFree";
            this.textBox145.Height = 0.125F;
            this.textBox145.Left = 8.625F;
            this.textBox145.MultiLine = false;
            this.textBox145.Name = "textBox145";
            this.textBox145.OutputFormat = resources.GetString("textBox145.OutputFormat");
            this.textBox145.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox145.SummaryGroup = "AgentHeader";
            this.textBox145.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox145.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox145.Text = "1,234,567,890";
            this.textBox145.Top = 0.5F;
            this.textBox145.Width = 0.8125F;
            // 
            // textBox146
            // 
            this.textBox146.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.Border.RightColor = System.Drawing.Color.Black;
            this.textBox146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.Border.TopColor = System.Drawing.Color.Black;
            this.textBox146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox146.Height = 0.125F;
            this.textBox146.Left = 10.25F;
            this.textBox146.MultiLine = false;
            this.textBox146.Name = "textBox146";
            this.textBox146.OutputFormat = resources.GetString("textBox146.OutputFormat");
            this.textBox146.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox146.SummaryGroup = "AgentHeader";
            this.textBox146.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox146.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox146.Text = "123,456";
            this.textBox146.Top = 0.5F;
            this.textBox146.Width = 0.5F;
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
            this.label23.Height = 0.125F;
            this.label23.HyperLink = null;
            this.label23.Left = 4.625F;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label23.Text = "非課税";
            this.label23.Top = 0.5F;
            this.label23.Width = 0.75F;
            // 
            // textBox147
            // 
            this.textBox147.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.RightColor = System.Drawing.Color.Black;
            this.textBox147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.TopColor = System.Drawing.Color.Black;
            this.textBox147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox147.Height = 0.125F;
            this.textBox147.Left = 5.375F;
            this.textBox147.MultiLine = false;
            this.textBox147.Name = "textBox147";
            this.textBox147.OutputFormat = resources.GetString("textBox147.OutputFormat");
            this.textBox147.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox147.SummaryGroup = "SectionHeader";
            this.textBox147.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox147.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox147.Text = "1,234,567,890";
            this.textBox147.Top = 0.5F;
            this.textBox147.Width = 0.8125F;
            // 
            // textBox148
            // 
            this.textBox148.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Border.RightColor = System.Drawing.Color.Black;
            this.textBox148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Border.TopColor = System.Drawing.Color.Black;
            this.textBox148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox148.Height = 0.125F;
            this.textBox148.Left = 6.1875F;
            this.textBox148.MultiLine = false;
            this.textBox148.Name = "textBox148";
            this.textBox148.OutputFormat = resources.GetString("textBox148.OutputFormat");
            this.textBox148.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox148.SummaryGroup = "SectionHeader";
            this.textBox148.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox148.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox148.Text = "1,234,567,890";
            this.textBox148.Top = 0.5F;
            this.textBox148.Width = 0.8125F;
            // 
            // textBox149
            // 
            this.textBox149.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Border.RightColor = System.Drawing.Color.Black;
            this.textBox149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Border.TopColor = System.Drawing.Color.Black;
            this.textBox149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.DataField = "TotalPureSalesTaxFree";
            this.textBox149.Height = 0.125F;
            this.textBox149.Left = 7F;
            this.textBox149.MultiLine = false;
            this.textBox149.Name = "textBox149";
            this.textBox149.OutputFormat = resources.GetString("textBox149.OutputFormat");
            this.textBox149.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox149.SummaryGroup = "SectionHeader";
            this.textBox149.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox149.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox149.Text = "1,234,567,890";
            this.textBox149.Top = 0.5F;
            this.textBox149.Width = 0.8125F;
            // 
            // textBox150
            // 
            this.textBox150.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.RightColor = System.Drawing.Color.Black;
            this.textBox150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.TopColor = System.Drawing.Color.Black;
            this.textBox150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox150.Height = 0.125F;
            this.textBox150.Left = 7.8125F;
            this.textBox150.MultiLine = false;
            this.textBox150.Name = "textBox150";
            this.textBox150.OutputFormat = resources.GetString("textBox150.OutputFormat");
            this.textBox150.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox150.SummaryGroup = "SectionHeader";
            this.textBox150.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox150.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox150.Text = "1,234,567,890";
            this.textBox150.Top = 0.5F;
            this.textBox150.Width = 0.8125F;
            // 
            // textBox151
            // 
            this.textBox151.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.Border.RightColor = System.Drawing.Color.Black;
            this.textBox151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.Border.TopColor = System.Drawing.Color.Black;
            this.textBox151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.DataField = "TotalAfCalTMonthAccRecTaxFree";
            this.textBox151.Height = 0.125F;
            this.textBox151.Left = 8.625F;
            this.textBox151.MultiLine = false;
            this.textBox151.Name = "textBox151";
            this.textBox151.OutputFormat = resources.GetString("textBox151.OutputFormat");
            this.textBox151.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox151.SummaryGroup = "SectionHeader";
            this.textBox151.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox151.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox151.Text = "1,234,567,890";
            this.textBox151.Top = 0.5F;
            this.textBox151.Width = 0.8125F;
            // 
            // textBox152
            // 
            this.textBox152.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.Border.RightColor = System.Drawing.Color.Black;
            this.textBox152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.Border.TopColor = System.Drawing.Color.Black;
            this.textBox152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox152.Height = 0.125F;
            this.textBox152.Left = 10.25F;
            this.textBox152.MultiLine = false;
            this.textBox152.Name = "textBox152";
            this.textBox152.OutputFormat = resources.GetString("textBox152.OutputFormat");
            this.textBox152.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox152.SummaryGroup = "SectionHeader";
            this.textBox152.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox152.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox152.Text = "123,456";
            this.textBox152.Top = 0.5F;
            this.textBox152.Width = 0.5F;
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
            this.label24.Height = 0.125F;
            this.label24.HyperLink = null;
            this.label24.Left = 4.625F;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label24.Text = "非課税";
            this.label24.Top = 0.5F;
            this.label24.Width = 0.75F;
            // 
            // textBox153
            // 
            this.textBox153.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.RightColor = System.Drawing.Color.Black;
            this.textBox153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.TopColor = System.Drawing.Color.Black;
            this.textBox153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox153.Height = 0.125F;
            this.textBox153.Left = 5.375F;
            this.textBox153.MultiLine = false;
            this.textBox153.Name = "textBox153";
            this.textBox153.OutputFormat = resources.GetString("textBox153.OutputFormat");
            this.textBox153.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox153.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox153.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox153.Text = "1,234,567,890";
            this.textBox153.Top = 0.5F;
            this.textBox153.Width = 0.8125F;
            // 
            // textBox154
            // 
            this.textBox154.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Border.RightColor = System.Drawing.Color.Black;
            this.textBox154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Border.TopColor = System.Drawing.Color.Black;
            this.textBox154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox154.Height = 0.125F;
            this.textBox154.Left = 6.1875F;
            this.textBox154.MultiLine = false;
            this.textBox154.Name = "textBox154";
            this.textBox154.OutputFormat = resources.GetString("textBox154.OutputFormat");
            this.textBox154.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox154.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox154.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox154.Text = "1,234,567,890";
            this.textBox154.Top = 0.5F;
            this.textBox154.Width = 0.8125F;
            // 
            // textBox155
            // 
            this.textBox155.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.Border.RightColor = System.Drawing.Color.Black;
            this.textBox155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.Border.TopColor = System.Drawing.Color.Black;
            this.textBox155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.DataField = "TotalPureSalesTaxFree";
            this.textBox155.Height = 0.125F;
            this.textBox155.Left = 7F;
            this.textBox155.MultiLine = false;
            this.textBox155.Name = "textBox155";
            this.textBox155.OutputFormat = resources.GetString("textBox155.OutputFormat");
            this.textBox155.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox155.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox155.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox155.Text = "1,234,567,890";
            this.textBox155.Top = 0.5F;
            this.textBox155.Width = 0.8125F;
            // 
            // textBox156
            // 
            this.textBox156.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Border.RightColor = System.Drawing.Color.Black;
            this.textBox156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Border.TopColor = System.Drawing.Color.Black;
            this.textBox156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox156.Height = 0.125F;
            this.textBox156.Left = 7.8125F;
            this.textBox156.MultiLine = false;
            this.textBox156.Name = "textBox156";
            this.textBox156.OutputFormat = resources.GetString("textBox156.OutputFormat");
            this.textBox156.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox156.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox156.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox156.Text = "1,234,567,890";
            this.textBox156.Top = 0.5F;
            this.textBox156.Width = 0.8125F;
            // 
            // textBox157
            // 
            this.textBox157.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.Border.RightColor = System.Drawing.Color.Black;
            this.textBox157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.Border.TopColor = System.Drawing.Color.Black;
            this.textBox157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.DataField = "TotalAfCalTMonthAccRecTaxFree";
            this.textBox157.Height = 0.125F;
            this.textBox157.Left = 8.625F;
            this.textBox157.MultiLine = false;
            this.textBox157.Name = "textBox157";
            this.textBox157.OutputFormat = resources.GetString("textBox157.OutputFormat");
            this.textBox157.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox157.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox157.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox157.Text = "1,234,567,890";
            this.textBox157.Top = 0.5F;
            this.textBox157.Width = 0.8125F;
            // 
            // textBox158
            // 
            this.textBox158.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Border.RightColor = System.Drawing.Color.Black;
            this.textBox158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Border.TopColor = System.Drawing.Color.Black;
            this.textBox158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox158.Height = 0.125F;
            this.textBox158.Left = 10.25F;
            this.textBox158.MultiLine = false;
            this.textBox158.Name = "textBox158";
            this.textBox158.OutputFormat = resources.GetString("textBox158.OutputFormat");
            this.textBox158.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox158.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox158.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox158.Text = "123,456";
            this.textBox158.Top = 0.5F;
            this.textBox158.Width = 0.5F;
            // 
            // PMHNB02272P_01A4C
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
            this.PrintWidth = 10.93542F;
            this.Script = "public void ActiveReport_ReportStart()\n{\n\n}";
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.GrandTotalHeader2);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SectionHeader2);
            this.Sections.Add(this.AgentHeader);
            this.Sections.Add(this.AgentHeader2);
            this.Sections.Add(this.SalesAreaHeader);
            this.Sections.Add(this.SalesAreaHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SalesAreaFooter2);
            this.Sections.Add(this.SalesAreaFooter);
            this.Sections.Add(this.AgentFooter2);
            this.Sections.Add(this.AgentFooter);
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
            this.ReportStart += new System.EventHandler(this.PMHNB02272P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeAccRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalTMonthAccRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Tax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Claim_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesArea_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Total_LastTimeAccRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeTtlBlcAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PureSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_SalesSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_SalesPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AfCalTMonthAccRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonAddUpNonProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_LastTimeAccRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeTtlBlcAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_PureSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AfCalTMonthAccRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAgentCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerAgentNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_PureSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_TrfrDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OffsetDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_FundTransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OthsDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAreaName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_PureSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TrfrDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OffsetDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_FundTransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OthsDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.g_CashDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.a_CashDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_TrfrDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_CheckDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_DraftDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OffsetDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_FundTransferDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_OthsDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_ThisTimeDisDmdNrml2)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CashDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TrfrDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CheckDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_DraftDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OffsetDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_FundTransferDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OthsDeposit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeDisDmdNrml2)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
