//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書一覧表
// プログラム概要   : 請求書一覧表の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/09/04  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : MANTIS【13600】総合計のKeepTogetherをTrueに修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2010/03/11  修正内容 : MANTIS【15130】回収率印字区分が「なし」の場合、「%」を印字しない
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当：yangmj
// 修正日    2011/03/14  修正内容：印字制御の区分の追加
// ---------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当：22018 鈴木 正臣
// 修正日    2011/04/07  修正内容：フォントサイズを大きくする変更。(全体的に印字位置を微調整)
// ---------------------------------------------------------------------------//
// 管理番号  11570208-00    作成担当：陳艶丹
// 修正日    2020/04/13     修正内容：PMKOBETSU-2912 軽減税率の対応
// ---------------------------------------------------------------------------//
// 管理番号  11800255-00    作成担当：陳艶丹
// 修正日    2020/08/05     修正内容：11800255-00　インボイス対応（税率別合計金額不具合修正）
// ---------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Controller;
// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----->>>>>
using System.Reflection;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
// --- ADD 2020/04/13 陳艶丹 軽減税率対応 -----<<<<<

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 請求書一覧表詳細タイプフォーム印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求書一覧表詳細タイプの印刷を行います。</br>
    /// <br>Programmer : 980023 飯谷 耕平</br>
    /// <br>Date       : 2007.06.19</br>
    /// <br>Update Note: 20081 疋田 勇人
    /// <br>           : 2007.10.15 DC.NS用に変更</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 犬飼</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br>UpdateNote : 印字制御の区分の追加対応</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date	   : 2011/03/14</br> 
    /// <br></br>
    /// <br>UpdateNote : 2011/04/07  22018  鈴木 正臣</br>
    /// <br>           : フォントサイズを大きくする変更。(全体的に印字位置を微調整)</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/04/13</br>
    /// </remarks>
	public class MAKAU02020P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeCommon, IPrintActiveReportTypeList	
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public MAKAU02020P_01A4C()
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
		
		// 抽出条件オブジェクト
		private ExtrInfo_DemandTotal _dmdExtraInfo;
		
		// 関連データオブジェクト
		private ArrayList _otherDataList;
		
		// 背景透かしモード(無し)
        private int _watermarkMode = 0;
        private Label Lb_Name1;
        private Line Line19;
        private TextBox Em_Name;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private TextBox tb_SumTitle;
        private TextBox s_SaleslSlipCount;
        private TextBox MONEYKINDNAME13;
        private Label Label109;
        private TextBox g_DemandBalance;
        private TextBox g_ThisTimeDmdNrml;
        private TextBox g_ThisTimeTtlBlcDmd;
        private TextBox g_OfsThisTimeSales;
        private TextBox g_ThisSalesPricRgdsDis;
        private TextBox g_NetSales;
        private TextBox g_OfsThisSalesTax;
        private TextBox g_OfsThisSalesSum;
        private TextBox g_AfCalDemandPrice;
        private TextBox g_SaleslSlipCount;
        private Line line2;
        private TextBox Em_Code;
        private TextBox ThisSalesPricRgdsDis;
        private TextBox NetSales;
        private TextBox CollectRate;
        private Label Lb_CollectRate;
        private TextBox title_AcpOdrTtl3;
        private TextBox title_AcpOdrTtl2;
        private TextBox title_LastTimeDemand;
        private TextBox title_MoneyKindDiv101;
        private TextBox title_MoneyKindDiv102;
        private TextBox title_MoneyKindDiv107;
        private TextBox title_MoneyKindDiv105;
        private TextBox title_MoneyKindDiv106;
        private TextBox title_MoneyKindDiv109;
        private TextBox title_MoneyKindDiv112;
        private TextBox title_ThisTimeFeeDmdNrml;
        private TextBox title_ThisTimeDisDmdNrml;
        private TextBox AcpOdrTtl3TmBfBlDmd;
        private TextBox AcpOdrTtl2TmBfBlDmd;
        private TextBox MoneyKindDiv101;
        private TextBox MoneyKindDiv102;
        private TextBox MoneyKindDiv107;
        private TextBox MoneyKindDiv105;
        private TextBox MoneyKindDiv106;
        private TextBox MoneyKindDiv109;
        private TextBox MoneyKindDiv112;
        private TextBox LastTimeDemand;
        private TextBox ThisTimeFeeDmdNrml;
        private TextBox ThisTimeDisDmdNrml;
        private TextBox s_AcpOdrTtl3TmBfBlDmd;
        private TextBox s_MoneyKindDiv109;
        private TextBox s_MoneyKindDiv106;
        private TextBox s_MoneyKindDiv105;
        private TextBox s_MoneyKindDiv101;
        private TextBox s_LastTimeDemand;
        private TextBox s_AcpOdrTtl2TmBfBlDmd;
        private TextBox s_MoneyKindDiv102;
        private TextBox s_MoneyKindDiv107;
        private TextBox s_MoneyKindDiv112;
        private TextBox s_ThisTimeFeeDmdNrml;
        private TextBox s_ThisTimeDisDmdNrml;
        private TextBox e_AcpOdrTtl3TmBfBlDmd;
        private TextBox e_MoneyKindDiv109;
        private TextBox e_MoneyKindDiv106;
        private TextBox e_MoneyKindDiv105;
        private TextBox e_MoneyKindDiv101;
        private TextBox e_LastTimeDemand;
        private TextBox e_AcpOdrTtl2TmBfBlDmd;
        private TextBox e_MoneyKindDiv102;
        private TextBox e_MoneyKindDiv107;
        private TextBox e_MoneyKindDiv112;
        private TextBox e_ThisTimeFeeDmdNrml;
        private TextBox e_ThisTimeDisDmdNrml;
        private TextBox g_AcpOdrTtl3TmBfBlDmd;
        private TextBox g_AcpOdrTtl2TmBfBlDmd;
        private TextBox g_LastTimeDemand;
        private TextBox g_MoneyKindDiv101;
        private TextBox g_MoneyKindDiv102;
        private TextBox g_MoneyKindDiv107;
        private TextBox g_MoneyKindDiv105;
        private TextBox g_MoneyKindDiv106;
        private TextBox g_MoneyKindDiv109;
        private TextBox g_MoneyKindDiv112;
        private TextBox g_ThisTimeFeeDmdNrml;
        private TextBox g_ThisTimeDisDmdNrml;
        private TextBox s_CollectRate;
        private TextBox e_CollectRate;
        private TextBox g_CollectRate;
        private Line line3;
        private TextBox CollectDemand;
        private TextBox s_CollectDemand;
        private TextBox e_CollectDemand;
        private TextBox g_CollectDemand;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox AddUpSecCode;
        private TextBox AddUpSecName;
        private Label label4;
        private TextBox ResultsSectCd;
        private TextBox textBox_Null;
        private TextBox textBox_sec;
        private TextBox textBox_emp;
        private Line line_head;
        private GroupHeader EmployeeHeader2;
        private GroupFooter EmployeeFooter2;
        private TextBox e_ThisSalesPricRgdsDis2;
        private TextBox e_AfCalDemandPrice2;
        private TextBox e_OfsThisSalesSum2;
        private TextBox e_OfsThisSalesTax2;
        private TextBox e_OfsThisTimeSales2;
        private TextBox e_ThisTimeTtlBlcDmd2;
        private TextBox e_ThisTimeDmdNrml2;
        private TextBox e_DemandBalance2;
        private TextBox e_SaleslSlipCount2;
        private TextBox e_NetSales2;
        private TextBox textBox16;
        private TextBox e_AcpOdrTtl3TmBfBlDmd2;
        private TextBox e_MoneyKindDiv1092;
        private TextBox e_MoneyKindDiv1062;
        private TextBox e_MoneyKindDiv1052;
        private TextBox e_MoneyKindDiv1012;
        private TextBox e_LastTimeDemand2;
        private TextBox e_AcpOdrTtl2TmBfBlDmd2;
        private TextBox e_MoneyKindDiv1022;
        private TextBox e_MoneyKindDiv1072;
        private TextBox e_MoneyKindDiv1122;
        private TextBox e_ThisTimeFeeDmdNrml2;
        private TextBox e_ThisTimeDisDmdNrml2;
        private TextBox e_CollectRate2;
        private TextBox e_CollectDemand2;
        private TextBox textBox39;
        private TextBox textBox_emp2;
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
        private TextBox textBox58;
        private GroupHeader SectionHeader2;
        private GroupFooter SectionFooter2;
        private Label s_TaxTotalTitleTaxRate1;
        private Label s_TaxTotalTitleTaxRate2;
        private Label s_TaxTotalTitleOther;
        private TextBox s_ThisSalesPricRgdsDis2;
        private TextBox s_AfCalDemandPrice2;
        private TextBox s_OfsThisSalesSum2;
        private TextBox s_OfsThisSalesTax2;
        private TextBox s_OfsThisTimeSales2;
        private TextBox s_ThisTimeTtlBlcDmd2;
        private TextBox s_ThisTimeDmdNrml2;
        private TextBox s_DemandBalance2;
        private TextBox s_NetSales2;
        private TextBox s_SaleslSlipCount2;
        private TextBox textBox69;
        private TextBox s_AcpOdrTtl3TmBfBlDmd2;
        private TextBox s_MoneyKindDiv1092;
        private TextBox s_MoneyKindDiv1062;
        private TextBox s_MoneyKindDiv1052;
        private TextBox s_MoneyKindDiv1012;
        private TextBox s_LastTimeDemand2;
        private TextBox s_AcpOdrTtl2TmBfBlDmd2;
        private TextBox s_MoneyKindDiv1022;
        private TextBox s_MoneyKindDiv1072;
        private TextBox s_MoneyKindDiv1122;
        private TextBox s_ThisTimeFeeDmdNrml2;
        private TextBox s_ThisTimeDisDmdNrml2;
        private TextBox s_CollectRate2;
        private TextBox s_CollectDemand2;
        private TextBox textBox84;
        private TextBox textBox_sec2;
        private Label label5;
        private Label label6;
        private Label label7;
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
        private TextBox textBox96;
        private TextBox textBox97;
        private TextBox textBox98;
        private TextBox textBox99;
        private TextBox textBox100;
        private TextBox textBox101;
        private TextBox textBox102;
        private TextBox textBox103;
        private GroupHeader GrandTotalHeader2;
        private GroupFooter GrandTotalFooter2;
        private Label label8;
        private TextBox g_DemandBalance2;
        private TextBox g_ThisTimeDmdNrml2;
        private TextBox g_ThisTimeTtlBlcDmd2;
        private TextBox g_OfsThisTimeSales2;
        private TextBox g_ThisSalesPricRgdsDis2;
        private TextBox g_NetSales2;
        private TextBox g_OfsThisSalesTax2;
        private TextBox g_OfsThisSalesSum2;
        private TextBox g_AfCalDemandPrice2;
        private TextBox g_SaleslSlipCount2;
        private TextBox g_AcpOdrTtl3TmBfBlDmd2;
        private TextBox g_AcpOdrTtl2TmBfBlDmd2;
        private TextBox g_LastTimeDemand2;
        private TextBox g_MoneyKindDiv1012;
        private TextBox g_MoneyKindDiv1022;
        private TextBox g_MoneyKindDiv1072;
        private TextBox g_MoneyKindDiv1052;
        private TextBox g_MoneyKindDiv1062;
        private TextBox g_MoneyKindDiv1092;
        private TextBox g_MoneyKindDiv1122;
        private TextBox g_ThisTimeFeeDmdNrml2;
        private TextBox g_ThisTimeDisDmdNrml2;
        private TextBox g_CollectRate2;
        private TextBox g_CollectDemand2;
        private TextBox textBox124;
        private Label label9;
        private Label label12;
        private Label label13;
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
        private TextBox textBox136;
        private TextBox textBox137;
        private TextBox textBox138;
        private TextBox textBox139;
        private TextBox textBox140;
        private TextBox textBox141;
        private TextBox textBox142;
        private Line line6;
        private Line line4;
        private Line line7;
        // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
        private Label label14;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label15;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox17;
        private TextBox textBox18;
        private Label label16;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
       
　　　　　　// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
        // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
        private Label label17;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox35;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox38;
        // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
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
				this._dmdExtraInfo = (ExtrInfo_DemandTotal)this._printInfo.jyoken;
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// <br>UpdateNote : 印字制御の区分の追加対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date	   : 2011/03/14</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
		private void MAKAU02020P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// 印刷件数初期化
			this._printCount = 0;

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            // 税別内訳印字区分
            int taxPrintDivObj = 1;
            // 税率1
            double taxRate1Obj = 0;
            // 税率2
            double taxRate2Obj = 0;

            if (IsTaxReductionDone())
            {
                // 税別内訳印字区分
                taxPrintDivObj = (int)GetPropertyValue(this._dmdExtraInfo, "TaxPrintDiv");
                // 税率1
                taxRate1Obj = (double)GetPropertyValue(this._dmdExtraInfo, "TaxRate1");
                // 税率2
                taxRate2Obj = (double)GetPropertyValue(this._dmdExtraInfo, "TaxRate2");
            }
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

            // 2008.09.08 30413 犬飼 削除項目 >>>>>>START
            //// 印字設定 --------------------------------------------------------------------------------------
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断      
            //if (this._dmdExtraInfo.IsOptSection) // 拠点オプション導入区分
            //{
            //    // 全社がチェックされていない時で拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ((this._dmdExtraInfo.ResultsAddUpSecList.Count < 2) && (this._dmdExtraInfo.IsSelectAllSection == false))
            //    {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else
            //    {
            //        SectionHeader.DataField = DemandPrintAcs.CT_CsDmd_AddUpSecCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else
            //{
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}

            //// 担当者計印字設定
            //if ((this._dmdExtraInfo.SortOrder == 2) || (this._dmdExtraInfo.SortOrder == 3))
            //{
            //    // 担当者情報設定
            //    if (this._dmdExtraInfo.CustomerAgentDivCd == 0)  // 顧客担当
            //    {
            //        EmployeeHeader.DataField  = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
            //        CustomerAgentCd.DataField = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
            //        CustomerAgentNm.DataField = DemandPrintAcs.CT_CsDmd_CustomerAgentNm;
            //    }
            //    else
            //    {
            //        EmployeeHeader.DataField  = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
            //        CustomerAgentCd.DataField = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
            //        CustomerAgentNm.DataField = DemandPrintAcs.CT_CsDmd_BillCollecterNm;
            //    }
            //    EmployeeHeader.Visible = true;
            //    EmployeeFooter.Visible = true;
            //    label4.Visible = true;
            //}
            //else
            //{
            //    EmployeeHeader.DataField = "";
            //    EmployeeFooter.Visible = false;
            //    EmployeeFooter.Visible = false;
            //    label4.Visible = false;
            //}

            //// 担当者改ページ有無設定
            //if (this._dmdExtraInfo.IsEmployeeNextPage == false)
            //{
            //    EmployeeHeader.NewPage = 0;
            //}
            // 2008.09.08 30413 犬飼 削除項目 <<<<<<END

            // 2008.09.09 30413 犬飼 改頁の制御 >>>>>>START
            if (this._dmdExtraInfo.NewPageDiv == 2)
            {
                // しない
                SectionHeader.NewPage = NewPage.None;
                EmployeeHeader.NewPage = NewPage.None;
                //SectionHeader.DataField = "";
                //SectionHeader.Visible = false;
                //SectionFooter.Visible = false;
                //EmployeeHeader.DataField = "";
                //EmployeeHeader.Visible = false;
                //EmployeeFooter.Visible = false;
            }
            else
            {
                if (this._dmdExtraInfo.NewPageDiv == 0)
                {
                    // 拠点
                    EmployeeHeader.NewPage = NewPage.None;
                }
            }
            // 2008.09.09 30413 犬飼 改頁の制御 <<<<<<END

            // 2008.09.09 30413 犬飼 出力順の制御 >>>>>>START
            if (this._dmdExtraInfo.SortOrder == 0)
            {
                // 得意先順
                //Lb_Name1.Text = "得意先";
                //Lb_Name2.Visible = false;
                Lb_Name1.Visible = false;

                EmployeeHeader.Visible = true;
            }
            else if (this._dmdExtraInfo.SortOrder == 1)
            {
                // 担当者順
                Lb_Name1.Text = "担当者";
                //Lb_Name2.Text = "得意先";

                EmployeeHeader.Visible = true;
                EmployeeFooter.Visible = true;

                if (this._dmdExtraInfo.CustomerAgentDivCd == 0)
                {
                    // 得意先担当者
                    EmployeeHeader.DataField = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;

                    Em_Code.DataField = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
                    Em_Name.DataField = DemandPrintAcs.CT_CsDmd_CustomerAgentNm;
                }
                else
                {
                    // 集金担当者
                    EmployeeHeader.DataField = DemandPrintAcs.CT_CsDmd_BillCollecterCd;

                    Em_Code.DataField = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                    Em_Name.DataField = DemandPrintAcs.CT_CsDmd_BillCollecterNm;
                }
                Em_Code.Visible = true;
                Em_Name.Visible = true;
            }
            else
            {
                // 地区順
                EmployeeHeader.DataField = DemandPrintAcs.CT_CsDmd_SalesAreaCode;
                tb_SumTitle.Text = "地区計";

                Lb_Name1.Text = "地区";
                //Lb_Name2.Text = "得意先";

                EmployeeHeader.Visible = true;
                EmployeeFooter.Visible = true;

                Em_Code.DataField = DemandPrintAcs.CT_CsDmd_SalesAreaCode;
                Em_Code.Visible = true;
                Em_Name.DataField = DemandPrintAcs.CT_CsDmd_SalesAreaName;
                Em_Name.Visible = true;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                if (taxPrintDivObj == 0)
                {
                    // 地区順
                    textBox16.Text = "地区計";
                }
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            }
            // 2008.09.09 30413 犬飼 出力順の制御 <<<<<<END

            // 2008.11.14 30413 犬飼 請求内訳の請求先と得意先印字制御 >>>>>>START
            if (this._dmdExtraInfo.DmdDtl == 2)
            {
                // 請求内訳が得意先
                ClaimCode.DataField = DemandPrintAcs.CT_SaleDepo_CustomerCode;      // 得意先コード
                ClaimSnm.DataField = DemandPrintAcs.CT_SaleDepo_CustomerSnm;        // 得意先略称

                // 2009.01.21 30413 犬飼 実績拠点の追加 >>>>>>START
                ResultsSectCd.Visible = true;
                ResultsSectCd.Top = 0.00F;
                ResultsSectCd.Left = 0.125F;
                ClaimCode.Left = 0.25F;
                ClaimSnm.Left = 0.813F;
                // 2009.01.21 30413 犬飼 実績拠点の追加 <<<<<<END
                
                // 2009.01.19 30413 犬飼 印字制御を変更 >>>>>>START
                // 明細部
                DemandBalance.Visible = false;
                ThisTimeDmdNrml.Visible = false;
                ThisTimeTtlBlcDmd.Visible = false;
                OfsThisSalesTax.Visible = false;
                OfsThisSalesSum.Visible = false;
                AfCalDemandPrice.Visible = false;
                CollectRate.Visible = false;
                textBox2.Visible = false;
                AcpOdrTtl3TmBfBlDmd.Visible = false;
                AcpOdrTtl2TmBfBlDmd.Visible = false;
                LastTimeDemand.Visible = false;
                MoneyKindDiv101.Visible = false;
                MoneyKindDiv102.Visible = false;
                MoneyKindDiv107.Visible = false;
                MoneyKindDiv105.Visible = false;
                MoneyKindDiv106.Visible = false;
                MoneyKindDiv109.Visible = false;
                MoneyKindDiv112.Visible = false;
                ThisTimeFeeDmdNrml.Visible = false;
                ThisTimeDisDmdNrml.Visible = false;
                // 担当者／地区計
                e_DemandBalance.Visible = false;
                e_ThisTimeDmdNrml.Visible = false;
                e_ThisTimeTtlBlcDmd.Visible = false;
                e_OfsThisSalesTax.Visible = false;
                e_OfsThisSalesSum.Visible = false;
                e_AfCalDemandPrice.Visible = false;
                e_CollectRate.Visible = false;
                textBox3.Visible = false;
                e_AcpOdrTtl3TmBfBlDmd.Visible = false;
                e_AcpOdrTtl2TmBfBlDmd.Visible = false;
                e_LastTimeDemand.Visible = false;
                e_MoneyKindDiv101.Visible = false;
                e_MoneyKindDiv102.Visible = false;
                e_MoneyKindDiv107.Visible = false;
                e_MoneyKindDiv105.Visible = false;
                e_MoneyKindDiv106.Visible = false;
                e_MoneyKindDiv109.Visible = false;
                e_MoneyKindDiv112.Visible = false;
                e_ThisTimeFeeDmdNrml.Visible = false;
                e_ThisTimeDisDmdNrml.Visible = false;
                // 拠点計
                s_DemandBalance.Visible = false;
                s_ThisTimeDmdNrml.Visible = false;
                s_ThisTimeTtlBlcDmd.Visible = false;
                s_OfsThisSalesTax.Visible = false;
                s_OfsThisSalesSum.Visible = false;
                s_AfCalDemandPrice.Visible = false;
                s_CollectRate.Visible = false;
                textBox4.Visible = false;
                s_AcpOdrTtl3TmBfBlDmd.Visible = false;
                s_AcpOdrTtl2TmBfBlDmd.Visible = false;
                s_LastTimeDemand.Visible = false;
                s_MoneyKindDiv101.Visible = false;
                s_MoneyKindDiv102.Visible = false;
                s_MoneyKindDiv107.Visible = false;
                s_MoneyKindDiv105.Visible = false;
                s_MoneyKindDiv106.Visible = false;
                s_MoneyKindDiv109.Visible = false;
                s_MoneyKindDiv112.Visible = false;
                s_ThisTimeFeeDmdNrml.Visible = false;
                s_ThisTimeDisDmdNrml.Visible = false;
                // 総合計
                g_DemandBalance.Visible = false;
                g_ThisTimeDmdNrml.Visible = false;
                g_ThisTimeTtlBlcDmd.Visible = false;
                g_OfsThisSalesTax.Visible = false;
                g_OfsThisSalesSum.Visible = false;
                g_AfCalDemandPrice.Visible = false;
                g_CollectRate.Visible = false;
                textBox5.Visible = false;
                g_AcpOdrTtl3TmBfBlDmd.Visible = false;
                g_AcpOdrTtl2TmBfBlDmd.Visible = false;
                g_LastTimeDemand.Visible = false;
                g_MoneyKindDiv101.Visible = false;
                g_MoneyKindDiv102.Visible = false;
                g_MoneyKindDiv107.Visible = false;
                g_MoneyKindDiv105.Visible = false;
                g_MoneyKindDiv106.Visible = false;
                g_MoneyKindDiv109.Visible = false;
                g_MoneyKindDiv112.Visible = false;
                g_ThisTimeFeeDmdNrml.Visible = false;
                g_ThisTimeDisDmdNrml.Visible = false;
                // 2009.01.19 30413 犬飼 印字制御を変更 <<<<<<END

                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                // 税別内訳印字区分
                if (taxPrintDivObj == 0)
                {
                    // 担当者／地区計
                    e_DemandBalance2.Visible = false;
                    e_ThisTimeDmdNrml2.Visible = false;
                    e_ThisTimeTtlBlcDmd2.Visible = false;
                    e_OfsThisSalesTax2.Visible = false;
                    e_OfsThisSalesSum2.Visible = false;
                    e_AfCalDemandPrice2.Visible = false;
                    e_CollectRate2.Visible = false;
                    textBox39.Visible = false;
                    e_AcpOdrTtl3TmBfBlDmd2.Visible = false;
                    e_AcpOdrTtl2TmBfBlDmd2.Visible = false;
                    e_LastTimeDemand2.Visible = false;
                    e_MoneyKindDiv1012.Visible = false;
                    e_MoneyKindDiv1022.Visible = false;
                    e_MoneyKindDiv1072.Visible = false;
                    e_MoneyKindDiv1052.Visible = false;
                    e_MoneyKindDiv1062.Visible = false;
                    e_MoneyKindDiv1092.Visible = false;
                    e_MoneyKindDiv1122.Visible = false;
                    e_ThisTimeFeeDmdNrml2.Visible = false;
                    e_ThisTimeDisDmdNrml2.Visible = false;
                    textBox44.Visible = false;
                    textBox50.Visible = false;
                    textBox56.Visible = false;
                    textBox45.Visible = false;
                    textBox51.Visible = false;
                    textBox57.Visible = false;
                    // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    textBox36.Visible = false;
                    textBox37.Visible = false;
                    // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    // 拠点計
                    s_DemandBalance2.Visible = false;
                    s_ThisTimeDmdNrml2.Visible = false;
                    s_ThisTimeTtlBlcDmd2.Visible = false;
                    s_OfsThisSalesTax2.Visible = false;
                    s_OfsThisSalesSum2.Visible = false;
                    s_AfCalDemandPrice2.Visible = false;
                    s_CollectRate2.Visible = false;
                    textBox84.Visible = false;
                    s_AcpOdrTtl3TmBfBlDmd2.Visible = false;
                    s_AcpOdrTtl2TmBfBlDmd2.Visible = false;
                    s_LastTimeDemand2.Visible = false;
                    s_MoneyKindDiv1012.Visible = false;
                    s_MoneyKindDiv1022.Visible = false;
                    s_MoneyKindDiv1072.Visible = false;
                    s_MoneyKindDiv1052.Visible = false;
                    s_MoneyKindDiv1062.Visible = false;
                    s_MoneyKindDiv1092.Visible = false;
                    s_MoneyKindDiv1122.Visible = false;
                    s_ThisTimeFeeDmdNrml2.Visible = false;
                    s_ThisTimeDisDmdNrml2.Visible = false;
                    // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    textBox15.Visible = false;
                    textBox17.Visible = false;
                    // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    textBox89.Visible = false;
                    textBox95.Visible = false;
                    textBox101.Visible = false;
                    textBox90.Visible = false;
                    textBox96.Visible = false;
                    textBox102.Visible = false;
                    // 総合計
                    g_DemandBalance2.Visible = false;
                    g_ThisTimeDmdNrml2.Visible = false;
                    g_ThisTimeTtlBlcDmd2.Visible = false;
                    g_OfsThisSalesTax2.Visible = false;
                    g_OfsThisSalesSum2.Visible = false;
                    g_AfCalDemandPrice2.Visible = false;
                    g_CollectRate2.Visible = false;
                    textBox124.Visible = false;
                    g_AcpOdrTtl3TmBfBlDmd2.Visible = false;
                    g_AcpOdrTtl2TmBfBlDmd2.Visible = false;
                    g_LastTimeDemand2.Visible = false;
                    g_MoneyKindDiv1012.Visible = false;
                    g_MoneyKindDiv1022.Visible = false;
                    g_MoneyKindDiv1072.Visible = false;
                    g_MoneyKindDiv1052.Visible = false;
                    g_MoneyKindDiv1062.Visible = false;
                    g_MoneyKindDiv1092.Visible = false;
                    g_MoneyKindDiv1122.Visible = false;
                    g_ThisTimeFeeDmdNrml2.Visible = false;
                    g_ThisTimeDisDmdNrml2.Visible = false;
                    textBox128.Visible = false;
                    textBox134.Visible = false;
                    textBox140.Visible = false;
                    textBox129.Visible = false;
                    textBox135.Visible = false;
                    textBox141.Visible = false;
                    // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    textBox22.Visible = false;
                    textBox23.Visible = false;
                    // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                }
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

            }
            // 2008.11.14 30413 犬飼 請求内訳の請求先と得意先印字制御 <<<<<<END

            // 2008.09.09 30413 犬飼 回収率印字の制御 >>>>>>START
            if (this._dmdExtraInfo.CollectRatePrtDiv == 2)
            {
                // 印字しない
                Lb_CollectRate.Visible = false;
                CollectRate.Visible = false;
                e_CollectRate.Visible = false;
                s_CollectRate.Visible = false;
                g_CollectRate.Visible = false;
                // ADD 2010/03/11 MANTIS対応[15130]：回収率印字区分が「なし」の場合、「%」を印字しない ---------->>>>>
                this.textBox2.Visible = false;
                this.textBox3.Visible = false;
                this.textBox4.Visible = false;
                this.textBox5.Visible = false;
                // ADD 2010/03/11 MANTIS対応[15130]：回収率印字区分が「なし」の場合、「%」を印字しない ----------<<<<<
            }
            // 2008.09.09 30413 犬飼 回収率印字の制御 <<<<<<END
            
            // 2008.09.09 30413 犬飼 印字パターンの制御 >>>>>>START
            if (this._dmdExtraInfo.BalanceDepositDtl == 1)
            {
                // 残高入金内訳を印字しない
                // タイトル
                title_AcpOdrTtl3.Visible = false;
                title_AcpOdrTtl2.Visible = false;
                title_LastTimeDemand.Visible = false;
                title_MoneyKindDiv101.Visible = false;
                title_MoneyKindDiv102.Visible = false;
                title_MoneyKindDiv107.Visible = false;
                title_MoneyKindDiv105.Visible = false;
                title_MoneyKindDiv106.Visible = false;
                title_MoneyKindDiv109.Visible = false;
                title_MoneyKindDiv112.Visible = false;
                title_ThisTimeFeeDmdNrml.Visible = false;
                title_ThisTimeDisDmdNrml.Visible = false;

                // 2009.03.11 30413 犬飼 印字修正 >>>>>>START
                // タイトル印字位置設定
                TextBox27.Top = 0.188F;             // 請求残高
                TextBox28.Top = 0.188F;             // 今回入金
                TextBox29.Top = 0.188F;             // 繰越額
                TextBox30.Top = 0.188F;             // 売上額
                TextBox34.Top = 0.188F;             // 返品値引
                TextBox1.Top = 0.188F;              // 純売上額
                TextBox31.Top = 0.188F;             // 消費税
                TextBox32.Top = 0.188F;             // 今回合計
                TextBox33.Top = 0.188F;             // 今回請求額
                Lb_CollectRate.Top = 0.188F;        // 回収率
                Label11.Top = 0.188F;               // 伝票枚数
                Label10.Top = 0.188F;               // 集金日
                // 2009.03.11 30413 犬飼 印字修正 <<<<<<END
                
                // 明細
                AcpOdrTtl3TmBfBlDmd.Visible = false;
                AcpOdrTtl2TmBfBlDmd.Visible = false;
                LastTimeDemand.Visible = false;
                MoneyKindDiv101.Visible = false;
                MoneyKindDiv102.Visible = false;
                MoneyKindDiv107.Visible = false;
                MoneyKindDiv105.Visible = false;
                MoneyKindDiv106.Visible = false;
                MoneyKindDiv109.Visible = false;
                MoneyKindDiv112.Visible = false;
                ThisTimeFeeDmdNrml.Visible = false;
                ThisTimeDisDmdNrml.Visible = false;

                // 担当者計
                e_AcpOdrTtl3TmBfBlDmd.Visible = false;
                e_AcpOdrTtl2TmBfBlDmd.Visible = false;
                e_LastTimeDemand.Visible = false;
                e_MoneyKindDiv101.Visible = false;
                e_MoneyKindDiv102.Visible = false;
                e_MoneyKindDiv107.Visible = false;
                e_MoneyKindDiv105.Visible = false;
                e_MoneyKindDiv106.Visible = false;
                e_MoneyKindDiv109.Visible = false;
                e_MoneyKindDiv112.Visible = false;
                e_ThisTimeFeeDmdNrml.Visible = false;
                e_ThisTimeDisDmdNrml.Visible = false;

                // 拠点計
                s_AcpOdrTtl3TmBfBlDmd.Visible = false;
                s_AcpOdrTtl2TmBfBlDmd.Visible = false;
                s_LastTimeDemand.Visible = false;
                s_MoneyKindDiv101.Visible = false;
                s_MoneyKindDiv102.Visible = false;
                s_MoneyKindDiv107.Visible = false;
                s_MoneyKindDiv105.Visible = false;
                s_MoneyKindDiv106.Visible = false;
                s_MoneyKindDiv109.Visible = false;
                s_MoneyKindDiv112.Visible = false;
                s_ThisTimeFeeDmdNrml.Visible = false;
                s_ThisTimeDisDmdNrml.Visible = false;

                // 総合計
                g_AcpOdrTtl3TmBfBlDmd.Visible = false;
                g_AcpOdrTtl2TmBfBlDmd.Visible = false;
                g_LastTimeDemand.Visible = false;
                g_MoneyKindDiv101.Visible = false;
                g_MoneyKindDiv102.Visible = false;
                g_MoneyKindDiv107.Visible = false;
                g_MoneyKindDiv105.Visible = false;
                g_MoneyKindDiv106.Visible = false;
                g_MoneyKindDiv109.Visible = false;
                g_MoneyKindDiv112.Visible = false;
                g_ThisTimeFeeDmdNrml.Visible = false;
                g_ThisTimeDisDmdNrml.Visible = false;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                 // 税別内訳印字区分
                if (taxPrintDivObj == 0)
                {
                    // 担当者計
                    e_AcpOdrTtl3TmBfBlDmd2.Visible = false;
                    e_AcpOdrTtl2TmBfBlDmd2.Visible = false;
                    e_LastTimeDemand2.Visible = false;
                    e_MoneyKindDiv1012.Visible = false;
                    e_MoneyKindDiv1022.Visible = false;
                    e_MoneyKindDiv1072.Visible = false;
                    e_MoneyKindDiv1052.Visible = false;
                    e_MoneyKindDiv1062.Visible = false;
                    e_MoneyKindDiv1092.Visible = false;
                    e_MoneyKindDiv1122.Visible = false;
                    e_ThisTimeFeeDmdNrml2.Visible = false;
                    e_ThisTimeDisDmdNrml2.Visible = false;

                    // 拠点計
                    s_AcpOdrTtl3TmBfBlDmd2.Visible = false;
                    s_AcpOdrTtl2TmBfBlDmd2.Visible = false;
                    s_LastTimeDemand2.Visible = false;
                    s_MoneyKindDiv1012.Visible = false;
                    s_MoneyKindDiv1022.Visible = false;
                    s_MoneyKindDiv1072.Visible = false;
                    s_MoneyKindDiv1052.Visible = false;
                    s_MoneyKindDiv1062.Visible = false;
                    s_MoneyKindDiv1092.Visible = false;
                    s_MoneyKindDiv1122.Visible = false;
                    s_ThisTimeFeeDmdNrml2.Visible = false;
                    s_ThisTimeDisDmdNrml2.Visible = false;

                    // 総合計
                    g_AcpOdrTtl3TmBfBlDmd2.Visible = false;
                    g_AcpOdrTtl2TmBfBlDmd2.Visible = false;
                    g_LastTimeDemand2.Visible = false;
                    g_MoneyKindDiv1012.Visible = false;
                    g_MoneyKindDiv1022.Visible = false;
                    g_MoneyKindDiv1072.Visible = false;
                    g_MoneyKindDiv1052.Visible = false;
                    g_MoneyKindDiv1062.Visible = false;
                    g_MoneyKindDiv1092.Visible = false;
                    g_MoneyKindDiv1122.Visible = false;
                    g_ThisTimeFeeDmdNrml2.Visible = false;
                    g_ThisTimeDisDmdNrml2.Visible = false;
                }
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            }
            //---2011/03/14----->>>>>
            // 空白行印字
            if (this._dmdExtraInfo.PrintBlLiDiv == 0)
            {
                this.textBox_Null.Visible = true;
                this.textBox_emp.Visible = true;
                this.textBox_sec.Visible = true;
                // 残高入金内訳を印字しない
                if (this._dmdExtraInfo.BalanceDepositDtl == 1)
                {
                    this.textBox_Null.Top = 0.125F;
                    this.textBox_emp.Top = 0.125F;
                    this.textBox_sec.Top = 0.125F;
                }
                else
                {
                    if (this._dmdExtraInfo.DmdDtl == 2)
                    {
                        this.textBox_Null.Top = 0.125F;
                        this.textBox_emp.Top = 0.125F;
                        this.textBox_sec.Top = 0.125F;
                    }
                }
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                // 税別内訳印字区分
                if ((taxPrintDivObj == 0))
                {
                    this.textBox_emp2.Visible = true;
                    this.textBox_sec2.Visible = true;
                    // 残高入金内訳を印字しない
                    if (this._dmdExtraInfo.BalanceDepositDtl == 1)
                    {
                        this.textBox_emp2.Top = 0.125F;
                        this.textBox_sec2.Top = 0.125F;
                    }
                    else
                    {
                        if (this._dmdExtraInfo.DmdDtl == 2)
                        {
                            this.textBox_emp2.Top = 0.125F;
                            this.textBox_sec2.Top = 0.125F;
                        }
                    }
                }
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            }
            else
            {
                this.textBox_Null.Visible = false;
                this.textBox_emp.Visible = false;
                this.textBox_sec.Visible = false;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                this.textBox_emp2.Visible = false;
                this.textBox_sec2.Visible = false;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            }
            // 罫線印字
            if (this._dmdExtraInfo.LineMaSqOfChDiv == 1)
            {
                this.line_head.Visible = true;
                this.Line19.Visible = false;
                this.line3.Visible = false;
                this.Line53.Visible = false;
                this.Line50.Visible = false;
                this.line2.Visible = false;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                this.line4.Visible = false;
                this.line7.Visible = false;
                this.line6.Visible = false;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            }
            else
            {
                this.line_head.Visible = false;
                this.Line19.Visible = true;
                this.line3.Visible = true;
                this.Line53.Visible = true;
                this.Line50.Visible = true;
                this.line2.Visible = true;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                this.line4.Visible = true;
                this.line7.Visible = true;
                this.line6.Visible = true;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            }
            //---2011/03/14-----<<<<<
            // 2008.09.09 30413 犬飼 印字パターンの制御 <<<<<<END

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            // 税別内訳印字区分
            if (taxPrintDivObj == 0)
            {
                EmployeeFooter2.Visible = EmployeeFooter.Visible;
                EmployeeFooter.Visible = false;

                SectionFooter2.Visible = SectionFooter.Visible;
                SectionFooter.Visible = false;

                GrandTotalFooter2.Visible = GrandTotalFooter.Visible;
                GrandTotalFooter.Visible = false;
                s_TaxTotalTitleTaxRate1.Text = Convert.ToInt32(taxRate1Obj * 100) + "%";
                s_TaxTotalTitleTaxRate2.Text = Convert.ToInt32(taxRate2Obj * 100) + "%";
                label5.Text = Convert.ToInt32(taxRate1Obj * 100) + "%";
                label6.Text = Convert.ToInt32(taxRate2Obj * 100) + "%";
                label9.Text = Convert.ToInt32(taxRate1Obj * 100) + "%";
                label12.Text = Convert.ToInt32(taxRate2Obj * 100) + "%";
            }
            else
            {
                EmployeeFooter2.Visible = false;
                SectionFooter2.Visible = false;
                GrandTotalFooter2.Visible = false;
            }
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<


            // 2009.02.06 30413 犬飼 不要な処理なので削除 >>>>>>START
            //// 合計のデータセット
            //if (this._dmdExtraInfo.DmdDtl == 0)
            //{
            //    e_DemandBalance.DataField = DemandPrintAcs.CT_CsDmd_ClaimLastTimeDemand;
            //    e_ThisTimeDmdNrml.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeDmdNrml;
            //    e_ThisTimeTtlBlcDmd.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeTtlBlcDmd;
            //    e_OfsThisTimeSales.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeSales;
            //    e_ThisSalesPricRgdsDis.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisSalesPricRgdsDis;
            //    e_NetSales.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisTimeSales;
            //    e_OfsThisSalesTax.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisSalesTax;
            //    e_OfsThisSalesSum.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisSalesSum;
            //    e_AfCalDemandPrice.DataField = DemandPrintAcs.CT_CsDmd_ClaimAfCalDemandPrice;
            //    e_SaleslSlipCount.DataField = DemandPrintAcs.CT_CsDmd_ClaimSaleslSlipCount;

            //    s_DemandBalance.DataField = DemandPrintAcs.CT_CsDmd_ClaimLastTimeDemand;
            //    s_ThisTimeDmdNrml.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeDmdNrml;
            //    s_ThisTimeTtlBlcDmd.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeTtlBlcDmd;
            //    s_OfsThisTimeSales.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeSales;
            //    s_ThisSalesPricRgdsDis.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisSalesPricRgdsDis;
            //    s_NetSales.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisTimeSales;
            //    s_OfsThisSalesTax.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisSalesTax;
            //    s_OfsThisSalesSum.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisSalesSum;
            //    s_AfCalDemandPrice.DataField = DemandPrintAcs.CT_CsDmd_ClaimAfCalDemandPrice;
            //    s_SaleslSlipCount.DataField = DemandPrintAcs.CT_CsDmd_ClaimSaleslSlipCount;

            //    g_DemandBalance.DataField = DemandPrintAcs.CT_CsDmd_ClaimLastTimeDemand;
            //    g_ThisTimeDmdNrml.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeDmdNrml;
            //    g_ThisTimeTtlBlcDmd.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeTtlBlcDmd;
            //    g_OfsThisTimeSales.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisTimeSales;
            //    g_ThisSalesPricRgdsDis.DataField = DemandPrintAcs.CT_CsDmd_ClaimThisSalesPricRgdsDis;
            //    g_NetSales.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisTimeSales;
            //    g_OfsThisSalesTax.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisSalesTax;
            //    g_OfsThisSalesSum.DataField = DemandPrintAcs.CT_CsDmd_ClaimOfsThisSalesSum;
            //    g_AfCalDemandPrice.DataField = DemandPrintAcs.CT_CsDmd_ClaimAfCalDemandPrice;
            //    g_SaleslSlipCount.DataField = DemandPrintAcs.CT_CsDmd_ClaimSaleslSlipCount;
            //}
            // 2009.02.06 30413 犬飼 不要な処理なので削除 <<<<<<END
        }

		/// <summary>
		/// ページヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
        /// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// ソート順
			this.SORTTITLE.Text = this._pageHeaderSortOderTitle;
			
			// 作成日付
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);

			// 作成時間
            this.TIME.Text = DateTime.Now.ToString("HH:mm");
		}

		/// <summary>
		/// 拠点ヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
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

            // 2008.11.14 30413 犬飼 抽出条件の印字エリアに拠点を印字しない >>>>>>START
            //// 拠点オプション有無判定
            //if (this._isSection)
            //{
            //    rpt.SectionCondition.Text = "計上拠点：" + this.tb_AddUpSecCode.Text + " " + this.HideSectionName.Text;
            //} 
            //else 
            //{
            //    rpt.SectionCondition.Text = "";
            //}
            // 2008.11.14 30413 犬飼 抽出条件の印字エリアに拠点を印字しない <<<<<<END
			
			// 抽出条件印字項目設定
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
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
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.19</br>
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
		private void EmployeeHeader_Format(object sender, System.EventArgs eArgs)
		{
		}

        /// <summary>
        /// 担当者計の回収率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 担当者計の回収率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.10</br>
        /// </remarks>
        private void EmployeeFooter_BeforePrint(object sender, EventArgs e)
        {
            double rate = new double();

            string thisThisTimeDmdNrml = e_ThisTimeDmdNrml.Text;
            string collectDemand = e_CollectDemand.Text;

            // カンマの除去
            thisThisTimeDmdNrml = thisThisTimeDmdNrml.Replace(",", "");         // 今回入金額
            collectDemand = collectDemand.Replace(",", "");                     // 回収残高

            double d_ThisThisTimeDmdNrml = double.Parse(thisThisTimeDmdNrml);
            double d_CollectDemand = double.Parse(collectDemand);

            // 今回入金額または回収残高が"0"の場合、回収率は"0.00"を返す
            if ((d_ThisThisTimeDmdNrml == 0.0) || (d_CollectDemand == 0.0))
            {
                e_CollectRate.Text = "0.00";
            }
            // 上記以外は回収率を計算
            else
            {
                rate = d_ThisThisTimeDmdNrml * 100 / d_CollectDemand;
                e_CollectRate.Text = String.Format("{0:F2}", rate);
            }
        }

        /// <summary>
        /// 拠点計の回収率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点計の回収率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.10</br>
        /// </remarks>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            double rate = new double();

            string thisThisTimeDmdNrml = s_ThisTimeDmdNrml.Text;
            string collectDemand = s_CollectDemand.Text;

            // カンマの除去
            thisThisTimeDmdNrml = thisThisTimeDmdNrml.Replace(",", "");         // 今回入金額
            collectDemand = collectDemand.Replace(",", "");                     // 回収残高

            double d_ThisThisTimeDmdNrml = double.Parse(thisThisTimeDmdNrml);
            double d_CollectDemand = double.Parse(collectDemand);

            // 今回入金額または回収残高が"0"の場合、回収率は"0.00"を返す
            if ((d_ThisThisTimeDmdNrml == 0.0) || (d_CollectDemand == 0.0))
            {
                s_CollectRate.Text = "0.00";
            }
            // 上記以外は回収率を計算
            else
            {
                rate = d_ThisThisTimeDmdNrml * 100 / d_CollectDemand;
                s_CollectRate.Text = String.Format("{0:F2}", rate);
            }
        }

        /// <summary>
        /// 総合計の回収率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 総合計の回収率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.10</br>
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            double rate = new double();

            string thisThisTimeDmdNrml = g_ThisTimeDmdNrml.Text;
            string collectDemand = g_CollectDemand.Text;

            // カンマの除去
            thisThisTimeDmdNrml = thisThisTimeDmdNrml.Replace(",", "");         // 今回入金額
            collectDemand = collectDemand.Replace(",", "");                     // 回収残高

            double d_ThisThisTimeDmdNrml = double.Parse(thisThisTimeDmdNrml);
            double d_CollectDemand = double.Parse(collectDemand);

            // 今回入金額または回収残高が"0"の場合、回収率は"0.00"を返す
            if ((d_ThisThisTimeDmdNrml == 0.0) || (d_CollectDemand == 0.0))
            {
                g_CollectRate.Text = "0.00";
            }
            // 上記以外は回収率を計算
            else
            {
                rate = d_ThisThisTimeDmdNrml * 100 / d_CollectDemand;
                g_CollectRate.Text = String.Format("{0:F2}", rate);
            }
        }

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----->>>>>
        /// <summary>
        /// 担当者計の回収率を出力処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 担当者計の回収率を出力します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/04/13</br>
        /// </remarks>
        private void EmployeeFooter2_BeforePrint(object sender, EventArgs e)
        {
            double rate = new double();

            string thisThisTimeDmdNrml = e_ThisTimeDmdNrml2.Text;
            string collectDemand = e_CollectDemand2.Text;

            // カンマの除去
            thisThisTimeDmdNrml = thisThisTimeDmdNrml.Replace(",", "");         // 今回入金額
            collectDemand = collectDemand.Replace(",", "");                     // 回収残高

            double d_ThisThisTimeDmdNrml = double.Parse(thisThisTimeDmdNrml);
            double d_CollectDemand = double.Parse(collectDemand);

            // 今回入金額または回収残高が"0"の場合、回収率は"0.00"を返す
            if ((d_ThisThisTimeDmdNrml == 0.0) || (d_CollectDemand == 0.0))
            {
                e_CollectRate2.Text = "0.00";
            }
            // 上記以外は回収率を計算
            else
            {
                rate = d_ThisThisTimeDmdNrml * 100 / d_CollectDemand;
                e_CollectRate2.Text = String.Format("{0:F2}", rate);
            }
        }

        /// <summary>
        /// 拠点計の回収率を出力処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 拠点計の回収率を出力します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/04/13</br>
        /// </remarks>
        private void SectionFooter2_BeforePrint(object sender, EventArgs e)
        {
            double rate = new double();

            string thisThisTimeDmdNrml = s_ThisTimeDmdNrml2.Text;
            string collectDemand = s_CollectDemand2.Text;

            // カンマの除去
            thisThisTimeDmdNrml = thisThisTimeDmdNrml.Replace(",", "");         // 今回入金額
            collectDemand = collectDemand.Replace(",", "");                     // 回収残高

            double d_ThisThisTimeDmdNrml = double.Parse(thisThisTimeDmdNrml);
            double d_CollectDemand = double.Parse(collectDemand);

            // 今回入金額または回収残高が"0"の場合、回収率は"0.00"を返す
            if ((d_ThisThisTimeDmdNrml == 0.0) || (d_CollectDemand == 0.0))
            {
                s_CollectRate2.Text = "0.00";
            }
            // 上記以外は回収率を計算
            else
            {
                rate = d_ThisThisTimeDmdNrml * 100 / d_CollectDemand;
                s_CollectRate2.Text = String.Format("{0:F2}", rate);
            }
        }

        /// <summary>
        /// 総合計の回収率を出力処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 総合計の回収率を出力します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/04/13</br>
        /// </remarks>
        private void GrandTotalFooter2_BeforePrint(object sender, EventArgs e)
        {
            double rate = new double();

            string thisThisTimeDmdNrml = g_ThisTimeDmdNrml2.Text;
            string collectDemand = g_CollectDemand2.Text;

            // カンマの除去
            thisThisTimeDmdNrml = thisThisTimeDmdNrml.Replace(",", "");         // 今回入金額
            collectDemand = collectDemand.Replace(",", "");                     // 回収残高

            double d_ThisThisTimeDmdNrml = double.Parse(thisThisTimeDmdNrml);
            double d_CollectDemand = double.Parse(collectDemand);

            // 今回入金額または回収残高が"0"の場合、回収率は"0.00"を返す
            if ((d_ThisThisTimeDmdNrml == 0.0) || (d_CollectDemand == 0.0))
            {
                g_CollectRate2.Text = "0.00";
            }
            // 上記以外は回収率を計算
            else
            {
                rate = d_ThisThisTimeDmdNrml * 100 / d_CollectDemand;
                g_CollectRate2.Text = String.Format("{0:F2}", rate);
            }
        }

        #region 軽減税率対応済か
        /// <summary>
        /// 軽減税率対応したか判定処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool IsTaxReductionDone()
        {
            // 軽減税率対応したか
            bool doneFlag = false;

            // Uクラス
            MAKAU02012UA uiObj = new MAKAU02012UA();
            doneFlag = ContainMember(uiObj, "TaxReductionUIDone");
            if (!doneFlag) return doneFlag;

            // Aクラス
            DemandPrintAcs demandPrintAcsObj = new DemandPrintAcs();
            doneFlag = ContainMember(demandPrintAcsObj, "TaxReductionAccessDone");
            if (!doneFlag) return doneFlag;

            // Eクラス
            doneFlag = ContainProperty(this._dmdExtraInfo, "TaxPrintDiv");
            if (!doneFlag) return doneFlag;

            // Dクラス
            ExtrInfo_DemandTotalWork demandTotalWork = new ExtrInfo_DemandTotalWork();
            doneFlag = ContainProperty(demandTotalWork, "TaxPrintDiv");

            return doneFlag;
        }

        /// <summary>
        /// ワークにパラメータが存在するか判定処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool ContainProperty(object instance, string propertyName)
        {
            // ワークにパラメータが存在するかフラグ
            bool existFlag = false;

            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo findedPropertyInfo = instance.GetType().GetProperty(propertyName);

                if (findedPropertyInfo != null)
                {
                    existFlag = true;
                }
            }

            return existFlag;
        }

        /// <summary>
        /// クラスにメンバーが存在するか判定処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool ContainMember(object instance, string propertyName)
        {
            // ワークにパラメータが存在するかフラグ
            bool existFlag = false;

            if (instance != null)
            {
                MemberInfo[] findedMemberInfo = instance.GetType().GetMember(propertyName);

                // 変数がある場合、最新バジョーンとする
                if (findedMemberInfo != null && findedMemberInfo.Length > 0)
                {
                    existFlag = true;
                }
            }

            return existFlag;
        }

        /// <summary>
        /// パラメータ値を取得する処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private object GetPropertyValue(object instance, string propertyName)
        {
            // パラメータ設定値
            object propertyValue = null;

            foreach (PropertyInfo p in instance.GetType().GetProperties())
            {
                if (propertyName.Equals(p.Name))
                {
                    propertyValue = p.GetValue(instance, null);
                    break;
                }
            }

            return propertyValue;
        }
        #endregion
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 -----<<<<<

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
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.TextBox TextBox34;
		private DataDynamics.ActiveReports.TextBox TextBox33;
		private DataDynamics.ActiveReports.TextBox TextBox32;
		private DataDynamics.ActiveReports.TextBox TextBox31;
		private DataDynamics.ActiveReports.TextBox TextBox30;
		private DataDynamics.ActiveReports.TextBox TextBox29;
		private DataDynamics.ActiveReports.TextBox TextBox28;
		private DataDynamics.ActiveReports.TextBox TextBox27;
		private DataDynamics.ActiveReports.Label Label11;
        private DataDynamics.ActiveReports.Label Label10;
        private DataDynamics.ActiveReports.Label Lb_Name2;
        private DataDynamics.ActiveReports.Line Line35;
		private DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader EmployeeHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox ClaimCode;
        private DataDynamics.ActiveReports.TextBox ClaimSnm;
		private DataDynamics.ActiveReports.TextBox CollectMoneyName;
		private DataDynamics.ActiveReports.TextBox CollectMoneyDayNm;
		private DataDynamics.ActiveReports.TextBox SaleslSlipCount;
		private DataDynamics.ActiveReports.TextBox DemandBalance;
		private DataDynamics.ActiveReports.TextBox ThisTimeDmdNrml;
		private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcDmd;
		private DataDynamics.ActiveReports.TextBox OfsThisTimeSales;
		private DataDynamics.ActiveReports.TextBox OfsThisSalesTax;
		private DataDynamics.ActiveReports.TextBox OfsThisSalesSum;
        private DataDynamics.ActiveReports.TextBox AfCalDemandPrice;
        private DataDynamics.ActiveReports.GroupFooter EmployeeFooter;
		private DataDynamics.ActiveReports.TextBox e_ThisSalesPricRgdsDis;
		private DataDynamics.ActiveReports.TextBox e_AfCalDemandPrice;
		private DataDynamics.ActiveReports.TextBox e_OfsThisSalesSum;
		private DataDynamics.ActiveReports.TextBox e_OfsThisSalesTax;
		private DataDynamics.ActiveReports.TextBox e_OfsThisTimeSales;
		private DataDynamics.ActiveReports.TextBox e_ThisTimeTtlBlcDmd;
		private DataDynamics.ActiveReports.TextBox e_ThisTimeDmdNrml;
        private DataDynamics.ActiveReports.TextBox e_DemandBalance;
        private DataDynamics.ActiveReports.Line Line53;
		private DataDynamics.ActiveReports.TextBox e_SaleslSlipCount;
		private DataDynamics.ActiveReports.TextBox e_NetSales;
        private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.TextBox s_ThisSalesPricRgdsDis;
		private DataDynamics.ActiveReports.TextBox s_AfCalDemandPrice;
		private DataDynamics.ActiveReports.TextBox s_OfsThisSalesSum;
		private DataDynamics.ActiveReports.TextBox s_OfsThisSalesTax;
		private DataDynamics.ActiveReports.TextBox s_OfsThisTimeSales;
		private DataDynamics.ActiveReports.TextBox s_ThisTimeTtlBlcDmd;
		private DataDynamics.ActiveReports.TextBox s_ThisTimeDmdNrml;
        private DataDynamics.ActiveReports.TextBox s_DemandBalance;
        private DataDynamics.ActiveReports.Line Line50;
		private DataDynamics.ActiveReports.TextBox s_NetSales;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU02020P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.CollectDemand = new DataDynamics.ActiveReports.TextBox();
            this.ClaimCode = new DataDynamics.ActiveReports.TextBox();
            this.CollectMoneyName = new DataDynamics.ActiveReports.TextBox();
            this.CollectMoneyDayNm = new DataDynamics.ActiveReports.TextBox();
            this.SaleslSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.DemandBalance = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcDmd = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisSalesSum = new DataDynamics.ActiveReports.TextBox();
            this.AfCalDemandPrice = new DataDynamics.ActiveReports.TextBox();
            this.ThisSalesPricRgdsDis = new DataDynamics.ActiveReports.TextBox();
            this.NetSales = new DataDynamics.ActiveReports.TextBox();
            this.CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv101 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv102 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv107 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv105 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv106 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv109 = new DataDynamics.ActiveReports.TextBox();
            this.MoneyKindDiv112 = new DataDynamics.ActiveReports.TextBox();
            this.LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.ResultsSectCd = new DataDynamics.ActiveReports.TextBox();
            this.textBox_Null = new DataDynamics.ActiveReports.TextBox();
            this.ClaimSnm = new DataDynamics.ActiveReports.TextBox();
            this.Line19 = new DataDynamics.ActiveReports.Line();
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
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.TextBox34 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox31 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox30 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox29 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Lb_Name2 = new DataDynamics.ActiveReports.Label();
            this.Line35 = new DataDynamics.ActiveReports.Line();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.Lb_Name1 = new DataDynamics.ActiveReports.Label();
            this.Lb_CollectRate = new DataDynamics.ActiveReports.Label();
            this.title_AcpOdrTtl3 = new DataDynamics.ActiveReports.TextBox();
            this.title_AcpOdrTtl2 = new DataDynamics.ActiveReports.TextBox();
            this.title_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv101 = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv102 = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv107 = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv105 = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv106 = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv109 = new DataDynamics.ActiveReports.TextBox();
            this.title_MoneyKindDiv112 = new DataDynamics.ActiveReports.TextBox();
            this.title_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.title_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.line_head = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.s_ThisSalesPricRgdsDis = new DataDynamics.ActiveReports.TextBox();
            this.s_AfCalDemandPrice = new DataDynamics.ActiveReports.TextBox();
            this.s_OfsThisSalesSum = new DataDynamics.ActiveReports.TextBox();
            this.s_OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.s_OfsThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeTtlBlcDmd = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.s_DemandBalance = new DataDynamics.ActiveReports.TextBox();
            this.Line50 = new DataDynamics.ActiveReports.Line();
            this.s_NetSales = new DataDynamics.ActiveReports.TextBox();
            this.s_SaleslSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.s_AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv109 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv106 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv105 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv101 = new DataDynamics.ActiveReports.TextBox();
            this.s_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.s_AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv102 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv107 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv112 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.s_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.s_CollectDemand = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox_sec = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Em_Name = new DataDynamics.ActiveReports.TextBox();
            this.Em_Code = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.e_ThisSalesPricRgdsDis = new DataDynamics.ActiveReports.TextBox();
            this.e_AfCalDemandPrice = new DataDynamics.ActiveReports.TextBox();
            this.e_OfsThisSalesSum = new DataDynamics.ActiveReports.TextBox();
            this.e_OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.e_OfsThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeTtlBlcDmd = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.e_DemandBalance = new DataDynamics.ActiveReports.TextBox();
            this.Line53 = new DataDynamics.ActiveReports.Line();
            this.e_SaleslSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.e_NetSales = new DataDynamics.ActiveReports.TextBox();
            this.tb_SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.e_AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv109 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv106 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv105 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv101 = new DataDynamics.ActiveReports.TextBox();
            this.e_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.e_AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv102 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv107 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv112 = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.e_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.e_CollectDemand = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox_emp = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.g_DemandBalance = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeTtlBlcDmd = new DataDynamics.ActiveReports.TextBox();
            this.g_OfsThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisSalesPricRgdsDis = new DataDynamics.ActiveReports.TextBox();
            this.g_NetSales = new DataDynamics.ActiveReports.TextBox();
            this.g_OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.g_OfsThisSalesSum = new DataDynamics.ActiveReports.TextBox();
            this.g_AfCalDemandPrice = new DataDynamics.ActiveReports.TextBox();
            this.g_SaleslSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.g_AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.g_AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.g_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv101 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv102 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv107 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv105 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv106 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv109 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv112 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeFeeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDisDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.g_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.g_CollectDemand = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.EmployeeFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.e_ThisSalesPricRgdsDis2 = new DataDynamics.ActiveReports.TextBox();
            this.e_AfCalDemandPrice2 = new DataDynamics.ActiveReports.TextBox();
            this.e_OfsThisSalesSum2 = new DataDynamics.ActiveReports.TextBox();
            this.e_OfsThisSalesTax2 = new DataDynamics.ActiveReports.TextBox();
            this.e_OfsThisTimeSales2 = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeTtlBlcDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.e_DemandBalance2 = new DataDynamics.ActiveReports.TextBox();
            this.e_SaleslSlipCount2 = new DataDynamics.ActiveReports.TextBox();
            this.e_NetSales2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.e_AcpOdrTtl3TmBfBlDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1092 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1062 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1052 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1012 = new DataDynamics.ActiveReports.TextBox();
            this.e_LastTimeDemand2 = new DataDynamics.ActiveReports.TextBox();
            this.e_AcpOdrTtl2TmBfBlDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1022 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1072 = new DataDynamics.ActiveReports.TextBox();
            this.e_MoneyKindDiv1122 = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.e_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.e_CollectRate2 = new DataDynamics.ActiveReports.TextBox();
            this.e_CollectDemand2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox_emp2 = new DataDynamics.ActiveReports.TextBox();
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
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.s_TaxTotalTitleTaxRate1 = new DataDynamics.ActiveReports.Label();
            this.s_TaxTotalTitleTaxRate2 = new DataDynamics.ActiveReports.Label();
            this.s_TaxTotalTitleOther = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            this.SectionHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.s_ThisSalesPricRgdsDis2 = new DataDynamics.ActiveReports.TextBox();
            this.s_AfCalDemandPrice2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OfsThisSalesSum2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OfsThisSalesTax2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OfsThisTimeSales2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeTtlBlcDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.s_DemandBalance2 = new DataDynamics.ActiveReports.TextBox();
            this.s_NetSales2 = new DataDynamics.ActiveReports.TextBox();
            this.s_SaleslSlipCount2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.s_AcpOdrTtl3TmBfBlDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1092 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1062 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1052 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1012 = new DataDynamics.ActiveReports.TextBox();
            this.s_LastTimeDemand2 = new DataDynamics.ActiveReports.TextBox();
            this.s_AcpOdrTtl2TmBfBlDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1022 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1072 = new DataDynamics.ActiveReports.TextBox();
            this.s_MoneyKindDiv1122 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.s_CollectRate2 = new DataDynamics.ActiveReports.TextBox();
            this.s_CollectDemand2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox84 = new DataDynamics.ActiveReports.TextBox();
            this.textBox_sec2 = new DataDynamics.ActiveReports.TextBox();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
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
            this.textBox96 = new DataDynamics.ActiveReports.TextBox();
            this.textBox97 = new DataDynamics.ActiveReports.TextBox();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.textBox99 = new DataDynamics.ActiveReports.TextBox();
            this.textBox100 = new DataDynamics.ActiveReports.TextBox();
            this.textBox101 = new DataDynamics.ActiveReports.TextBox();
            this.textBox102 = new DataDynamics.ActiveReports.TextBox();
            this.textBox103 = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.g_DemandBalance2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeTtlBlcDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OfsThisTimeSales2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisSalesPricRgdsDis2 = new DataDynamics.ActiveReports.TextBox();
            this.g_NetSales2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OfsThisSalesTax2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OfsThisSalesSum2 = new DataDynamics.ActiveReports.TextBox();
            this.g_AfCalDemandPrice2 = new DataDynamics.ActiveReports.TextBox();
            this.g_SaleslSlipCount2 = new DataDynamics.ActiveReports.TextBox();
            this.g_AcpOdrTtl3TmBfBlDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.g_AcpOdrTtl2TmBfBlDmd2 = new DataDynamics.ActiveReports.TextBox();
            this.g_LastTimeDemand2 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1012 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1022 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1072 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1052 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1062 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1092 = new DataDynamics.ActiveReports.TextBox();
            this.g_MoneyKindDiv1122 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeFeeDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDisDmdNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.g_CollectRate2 = new DataDynamics.ActiveReports.TextBox();
            this.g_CollectDemand2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox124 = new DataDynamics.ActiveReports.TextBox();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
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
            this.textBox136 = new DataDynamics.ActiveReports.TextBox();
            this.textBox137 = new DataDynamics.ActiveReports.TextBox();
            this.textBox138 = new DataDynamics.ActiveReports.TextBox();
            this.textBox139 = new DataDynamics.ActiveReports.TextBox();
            this.textBox140 = new DataDynamics.ActiveReports.TextBox();
            this.textBox141 = new DataDynamics.ActiveReports.TextBox();
            this.textBox142 = new DataDynamics.ActiveReports.TextBox();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this.CollectDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectMoneyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectMoneyDayNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleslSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalDemandPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisSalesPricRgdsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Null)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Name2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Name1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_AcpOdrTtl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_AcpOdrTtl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisSalesPricRgdsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AfCalDemandPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeTtlBlcDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DemandBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_NetSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SaleslSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_sec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisSalesPricRgdsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AfCalDemandPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeTtlBlcDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_DemandBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_SaleslSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_NetSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_emp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DemandBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeTtlBlcDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisSalesPricRgdsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_NetSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AfCalDemandPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SaleslSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisSalesPricRgdsDis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AfCalDemandPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesSum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesTax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisTimeSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeTtlBlcDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_DemandBalance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_SaleslSlipCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_NetSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl3TmBfBlDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1092)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1062)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1052)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1012)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_LastTimeDemand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl2TmBfBlDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1022)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1072)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDisDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectDemand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_emp2)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleOther)).BeginInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisSalesPricRgdsDis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AfCalDemandPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesSum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesTax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisTimeSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeTtlBlcDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DemandBalance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_NetSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SaleslSlipCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl3TmBfBlDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1092)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1062)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1052)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1012)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_LastTimeDemand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl2TmBfBlDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1022)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1072)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectDemand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_sec2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DemandBalance2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeTtlBlcDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisTimeSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisSalesPricRgdsDis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_NetSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesTax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesSum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AfCalDemandPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SaleslSlipCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl3TmBfBlDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl2TmBfBlDmd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_LastTimeDemand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1012)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1022)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1072)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1052)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1062)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1092)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectDemand2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox142)).BeginInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CollectDemand,
            this.ClaimCode,
            this.CollectMoneyName,
            this.CollectMoneyDayNm,
            this.SaleslSlipCount,
            this.DemandBalance,
            this.ThisTimeDmdNrml,
            this.ThisTimeTtlBlcDmd,
            this.OfsThisTimeSales,
            this.OfsThisSalesTax,
            this.OfsThisSalesSum,
            this.AfCalDemandPrice,
            this.ThisSalesPricRgdsDis,
            this.NetSales,
            this.CollectRate,
            this.AcpOdrTtl3TmBfBlDmd,
            this.AcpOdrTtl2TmBfBlDmd,
            this.MoneyKindDiv101,
            this.MoneyKindDiv102,
            this.MoneyKindDiv107,
            this.MoneyKindDiv105,
            this.MoneyKindDiv106,
            this.MoneyKindDiv109,
            this.MoneyKindDiv112,
            this.LastTimeDemand,
            this.ThisTimeFeeDmdNrml,
            this.ThisTimeDisDmdNrml,
            this.line3,
            this.textBox2,
            this.ResultsSectCd,
            this.textBox_Null,
            this.ClaimSnm});
            this.Detail.Height = 0.4375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            // 
            // CollectDemand
            // 
            this.CollectDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectDemand.Border.RightColor = System.Drawing.Color.Black;
            this.CollectDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectDemand.Border.TopColor = System.Drawing.Color.Black;
            this.CollectDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectDemand.DataField = "CollectDemand";
            this.CollectDemand.Height = 0.125F;
            this.CollectDemand.Left = 0F;
            this.CollectDemand.Name = "CollectDemand";
            this.CollectDemand.OutputFormat = resources.GetString("CollectDemand.OutputFormat");
            this.CollectDemand.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.CollectDemand.Text = null;
            this.CollectDemand.Top = 0.125F;
            this.CollectDemand.Visible = false;
            this.CollectDemand.Width = 0.375F;
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
            this.ClaimCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.ClaimCode.Text = "12345678";
            this.ClaimCode.Top = 0F;
            this.ClaimCode.Width = 0.4928921F;
            // 
            // CollectMoneyName
            // 
            this.CollectMoneyName.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectMoneyName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyName.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectMoneyName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyName.Border.RightColor = System.Drawing.Color.Black;
            this.CollectMoneyName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyName.Border.TopColor = System.Drawing.Color.Black;
            this.CollectMoneyName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyName.DataField = "CollectMoneyName";
            this.CollectMoneyName.Height = 0.125F;
            this.CollectMoneyName.Left = 10.125F;
            this.CollectMoneyName.Name = "CollectMoneyName";
            this.CollectMoneyName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; vertical-align: top; ";
            this.CollectMoneyName.Text = "ＮＮＮＮ";
            this.CollectMoneyName.Top = 0F;
            this.CollectMoneyName.Width = 0.4821429F;
            // 
            // CollectMoneyDayNm
            // 
            this.CollectMoneyDayNm.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectMoneyDayNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyDayNm.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectMoneyDayNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyDayNm.Border.RightColor = System.Drawing.Color.Black;
            this.CollectMoneyDayNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyDayNm.Border.TopColor = System.Drawing.Color.Black;
            this.CollectMoneyDayNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMoneyDayNm.DataField = "CollectMoneyDayNm";
            this.CollectMoneyDayNm.Height = 0.125F;
            this.CollectMoneyDayNm.Left = 10.5625F;
            this.CollectMoneyDayNm.Name = "CollectMoneyDayNm";
            this.CollectMoneyDayNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; vertical-align: top; ";
            this.CollectMoneyDayNm.Text = "99日";
            this.CollectMoneyDayNm.Top = 0F;
            this.CollectMoneyDayNm.Width = 0.25F;
            // 
            // SaleslSlipCount
            // 
            this.SaleslSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.SaleslSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SaleslSlipCount.DataField = "SaleslSlipCount";
            this.SaleslSlipCount.Height = 0.125F;
            this.SaleslSlipCount.Left = 9.509257F;
            this.SaleslSlipCount.MultiLine = false;
            this.SaleslSlipCount.Name = "SaleslSlipCount";
            this.SaleslSlipCount.OutputFormat = resources.GetString("SaleslSlipCount.OutputFormat");
            this.SaleslSlipCount.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.SaleslSlipCount.Text = "00,123,456";
            this.SaleslSlipCount.Top = 0F;
            this.SaleslSlipCount.Width = 0.59F;
            // 
            // DemandBalance
            // 
            this.DemandBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.Border.RightColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.Border.TopColor = System.Drawing.Color.Black;
            this.DemandBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DemandBalance.DataField = "DemandBalance";
            this.DemandBalance.Height = 0.125F;
            this.DemandBalance.Left = 2.53F;
            this.DemandBalance.MultiLine = false;
            this.DemandBalance.Name = "DemandBalance";
            this.DemandBalance.OutputFormat = resources.GetString("DemandBalance.OutputFormat");
            this.DemandBalance.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.DemandBalance.Text = "2345,678,901";
            this.DemandBalance.Top = 0F;
            this.DemandBalance.Width = 0.695F;
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
            this.ThisTimeDmdNrml.Left = 3.21875F;
            this.ThisTimeDmdNrml.MultiLine = false;
            this.ThisTimeDmdNrml.Name = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.OutputFormat = resources.GetString("ThisTimeDmdNrml.OutputFormat");
            this.ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeDmdNrml.Text = "2,345,678,901";
            this.ThisTimeDmdNrml.Top = 0F;
            this.ThisTimeDmdNrml.Width = 0.695F;
            // 
            // ThisTimeTtlBlcDmd
            // 
            this.ThisTimeTtlBlcDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.DataField = "ThisTimeTtlBlcDmd";
            this.ThisTimeTtlBlcDmd.Height = 0.125F;
            this.ThisTimeTtlBlcDmd.Left = 3.90625F;
            this.ThisTimeTtlBlcDmd.MultiLine = false;
            this.ThisTimeTtlBlcDmd.Name = "ThisTimeTtlBlcDmd";
            this.ThisTimeTtlBlcDmd.OutputFormat = resources.GetString("ThisTimeTtlBlcDmd.OutputFormat");
            this.ThisTimeTtlBlcDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeTtlBlcDmd.Text = "2,345,678,901";
            this.ThisTimeTtlBlcDmd.Top = 0F;
            this.ThisTimeTtlBlcDmd.Width = 0.695F;
            // 
            // OfsThisTimeSales
            // 
            this.OfsThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.DataField = "ThisTimeSales";
            this.OfsThisTimeSales.Height = 0.125F;
            this.OfsThisTimeSales.Left = 4.59375F;
            this.OfsThisTimeSales.MultiLine = false;
            this.OfsThisTimeSales.Name = "OfsThisTimeSales";
            this.OfsThisTimeSales.OutputFormat = resources.GetString("OfsThisTimeSales.OutputFormat");
            this.OfsThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.OfsThisTimeSales.Text = "2,345,678,901";
            this.OfsThisTimeSales.Top = 0F;
            this.OfsThisTimeSales.Width = 0.695F;
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
            this.OfsThisSalesTax.Left = 6.656249F;
            this.OfsThisSalesTax.MultiLine = false;
            this.OfsThisSalesTax.Name = "OfsThisSalesTax";
            this.OfsThisSalesTax.OutputFormat = resources.GetString("OfsThisSalesTax.OutputFormat");
            this.OfsThisSalesTax.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.OfsThisSalesTax.Text = "2,345,678,901";
            this.OfsThisSalesTax.Top = 0F;
            this.OfsThisSalesTax.Width = 0.695F;
            // 
            // OfsThisSalesSum
            // 
            this.OfsThisSalesSum.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisSalesSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesSum.DataField = "OfsThisSalesSum";
            this.OfsThisSalesSum.Height = 0.125F;
            this.OfsThisSalesSum.Left = 7.343751F;
            this.OfsThisSalesSum.MultiLine = false;
            this.OfsThisSalesSum.Name = "OfsThisSalesSum";
            this.OfsThisSalesSum.OutputFormat = resources.GetString("OfsThisSalesSum.OutputFormat");
            this.OfsThisSalesSum.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.OfsThisSalesSum.Text = "2,345,678,901";
            this.OfsThisSalesSum.Top = 0F;
            this.OfsThisSalesSum.Width = 0.695F;
            // 
            // AfCalDemandPrice
            // 
            this.AfCalDemandPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.DataField = "AfCalDemandPrice";
            this.AfCalDemandPrice.Height = 0.125F;
            this.AfCalDemandPrice.Left = 8.031249F;
            this.AfCalDemandPrice.MultiLine = false;
            this.AfCalDemandPrice.Name = "AfCalDemandPrice";
            this.AfCalDemandPrice.OutputFormat = resources.GetString("AfCalDemandPrice.OutputFormat");
            this.AfCalDemandPrice.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.AfCalDemandPrice.Text = "2,345,678,901";
            this.AfCalDemandPrice.Top = 0F;
            this.AfCalDemandPrice.Width = 0.695F;
            // 
            // ThisSalesPricRgdsDis
            // 
            this.ThisSalesPricRgdsDis.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisSalesPricRgdsDis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesPricRgdsDis.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisSalesPricRgdsDis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesPricRgdsDis.Border.RightColor = System.Drawing.Color.Black;
            this.ThisSalesPricRgdsDis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesPricRgdsDis.Border.TopColor = System.Drawing.Color.Black;
            this.ThisSalesPricRgdsDis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesPricRgdsDis.DataField = "ThisSalesPricRgdsDis";
            this.ThisSalesPricRgdsDis.Height = 0.125F;
            this.ThisSalesPricRgdsDis.Left = 5.281249F;
            this.ThisSalesPricRgdsDis.MultiLine = false;
            this.ThisSalesPricRgdsDis.Name = "ThisSalesPricRgdsDis";
            this.ThisSalesPricRgdsDis.OutputFormat = resources.GetString("ThisSalesPricRgdsDis.OutputFormat");
            this.ThisSalesPricRgdsDis.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisSalesPricRgdsDis.Text = "2,345,678,901";
            this.ThisSalesPricRgdsDis.Top = 0F;
            this.ThisSalesPricRgdsDis.Width = 0.695F;
            // 
            // NetSales
            // 
            this.NetSales.Border.BottomColor = System.Drawing.Color.Black;
            this.NetSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetSales.Border.LeftColor = System.Drawing.Color.Black;
            this.NetSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetSales.Border.RightColor = System.Drawing.Color.Black;
            this.NetSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetSales.Border.TopColor = System.Drawing.Color.Black;
            this.NetSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetSales.DataField = "NetSales";
            this.NetSales.Height = 0.125F;
            this.NetSales.Left = 5.96875F;
            this.NetSales.MultiLine = false;
            this.NetSales.Name = "NetSales";
            this.NetSales.OutputFormat = resources.GetString("NetSales.OutputFormat");
            this.NetSales.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.NetSales.Text = "2,345,678,901";
            this.NetSales.Top = 0F;
            this.NetSales.Width = 0.695F;
            // 
            // CollectRate
            // 
            this.CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.DataField = "CollectRate";
            this.CollectRate.Height = 0.125F;
            this.CollectRate.Left = 8.791668F;
            this.CollectRate.MultiLine = false;
            this.CollectRate.Name = "CollectRate";
            this.CollectRate.OutputFormat = resources.GetString("CollectRate.OutputFormat");
            this.CollectRate.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.CollectRate.Text = "123.00";
            this.CollectRate.Top = 0F;
            this.CollectRate.Width = 0.5F;
            // 
            // AcpOdrTtl3TmBfBlDmd
            // 
            this.AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.AcpOdrTtl3TmBfBlDmd.Left = 2.53F;
            this.AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.AcpOdrTtl3TmBfBlDmd.Name = "AcpOdrTtl3TmBfBlDmd";
            this.AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.AcpOdrTtl3TmBfBlDmd.Text = "2345,678,901";
            this.AcpOdrTtl3TmBfBlDmd.Top = 0.125F;
            this.AcpOdrTtl3TmBfBlDmd.Width = 0.695F;
            // 
            // AcpOdrTtl2TmBfBlDmd
            // 
            this.AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.AcpOdrTtl2TmBfBlDmd.Left = 3.21875F;
            this.AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.AcpOdrTtl2TmBfBlDmd.Name = "AcpOdrTtl2TmBfBlDmd";
            this.AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.AcpOdrTtl2TmBfBlDmd.Text = "2,345,678,901";
            this.AcpOdrTtl2TmBfBlDmd.Top = 0.125F;
            this.AcpOdrTtl2TmBfBlDmd.Width = 0.695F;
            // 
            // MoneyKindDiv101
            // 
            this.MoneyKindDiv101.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv101.DataField = "MoneyKindDiv101";
            this.MoneyKindDiv101.Height = 0.125F;
            this.MoneyKindDiv101.Left = 4.59375F;
            this.MoneyKindDiv101.MultiLine = false;
            this.MoneyKindDiv101.Name = "MoneyKindDiv101";
            this.MoneyKindDiv101.OutputFormat = resources.GetString("MoneyKindDiv101.OutputFormat");
            this.MoneyKindDiv101.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv101.Text = "2,345,678,901";
            this.MoneyKindDiv101.Top = 0.125F;
            this.MoneyKindDiv101.Width = 0.695F;
            // 
            // MoneyKindDiv102
            // 
            this.MoneyKindDiv102.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv102.DataField = "MoneyKindDiv102";
            this.MoneyKindDiv102.Height = 0.125F;
            this.MoneyKindDiv102.Left = 5.281249F;
            this.MoneyKindDiv102.MultiLine = false;
            this.MoneyKindDiv102.Name = "MoneyKindDiv102";
            this.MoneyKindDiv102.OutputFormat = resources.GetString("MoneyKindDiv102.OutputFormat");
            this.MoneyKindDiv102.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv102.Text = "2,345,678,901";
            this.MoneyKindDiv102.Top = 0.125F;
            this.MoneyKindDiv102.Width = 0.695F;
            // 
            // MoneyKindDiv107
            // 
            this.MoneyKindDiv107.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv107.DataField = "MoneyKindDiv107";
            this.MoneyKindDiv107.Height = 0.125F;
            this.MoneyKindDiv107.Left = 5.96875F;
            this.MoneyKindDiv107.MultiLine = false;
            this.MoneyKindDiv107.Name = "MoneyKindDiv107";
            this.MoneyKindDiv107.OutputFormat = resources.GetString("MoneyKindDiv107.OutputFormat");
            this.MoneyKindDiv107.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv107.Text = "2,345,678,901";
            this.MoneyKindDiv107.Top = 0.125F;
            this.MoneyKindDiv107.Width = 0.695F;
            // 
            // MoneyKindDiv105
            // 
            this.MoneyKindDiv105.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv105.DataField = "MoneyKindDiv105";
            this.MoneyKindDiv105.Height = 0.125F;
            this.MoneyKindDiv105.Left = 6.656249F;
            this.MoneyKindDiv105.MultiLine = false;
            this.MoneyKindDiv105.Name = "MoneyKindDiv105";
            this.MoneyKindDiv105.OutputFormat = resources.GetString("MoneyKindDiv105.OutputFormat");
            this.MoneyKindDiv105.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv105.Text = "2,345,678,901";
            this.MoneyKindDiv105.Top = 0.125F;
            this.MoneyKindDiv105.Width = 0.695F;
            // 
            // MoneyKindDiv106
            // 
            this.MoneyKindDiv106.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv106.DataField = "MoneyKindDiv106";
            this.MoneyKindDiv106.Height = 0.125F;
            this.MoneyKindDiv106.Left = 7.343751F;
            this.MoneyKindDiv106.MultiLine = false;
            this.MoneyKindDiv106.Name = "MoneyKindDiv106";
            this.MoneyKindDiv106.OutputFormat = resources.GetString("MoneyKindDiv106.OutputFormat");
            this.MoneyKindDiv106.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv106.Text = "2,345,678,901";
            this.MoneyKindDiv106.Top = 0.125F;
            this.MoneyKindDiv106.Width = 0.695F;
            // 
            // MoneyKindDiv109
            // 
            this.MoneyKindDiv109.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv109.DataField = "MoneyKindDiv109";
            this.MoneyKindDiv109.Height = 0.125F;
            this.MoneyKindDiv109.Left = 8.031249F;
            this.MoneyKindDiv109.MultiLine = false;
            this.MoneyKindDiv109.Name = "MoneyKindDiv109";
            this.MoneyKindDiv109.OutputFormat = resources.GetString("MoneyKindDiv109.OutputFormat");
            this.MoneyKindDiv109.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv109.Text = "2,345,678,901";
            this.MoneyKindDiv109.Top = 0.125F;
            this.MoneyKindDiv109.Width = 0.695F;
            // 
            // MoneyKindDiv112
            // 
            this.MoneyKindDiv112.Border.BottomColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.Border.LeftColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.Border.RightColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.Border.TopColor = System.Drawing.Color.Black;
            this.MoneyKindDiv112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoneyKindDiv112.DataField = "MoneyKindDiv112";
            this.MoneyKindDiv112.Height = 0.125F;
            this.MoneyKindDiv112.Left = 8.718751F;
            this.MoneyKindDiv112.MultiLine = false;
            this.MoneyKindDiv112.Name = "MoneyKindDiv112";
            this.MoneyKindDiv112.OutputFormat = resources.GetString("MoneyKindDiv112.OutputFormat");
            this.MoneyKindDiv112.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.MoneyKindDiv112.Text = "2,345,678,901";
            this.MoneyKindDiv112.Top = 0.125F;
            this.MoneyKindDiv112.Width = 0.695F;
            // 
            // LastTimeDemand
            // 
            this.LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.DataField = "LastTimeDemand";
            this.LastTimeDemand.Height = 0.125F;
            this.LastTimeDemand.Left = 3.90625F;
            this.LastTimeDemand.MultiLine = false;
            this.LastTimeDemand.Name = "LastTimeDemand";
            this.LastTimeDemand.OutputFormat = resources.GetString("LastTimeDemand.OutputFormat");
            this.LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.LastTimeDemand.Text = "2,345,678,901";
            this.LastTimeDemand.Top = 0.125F;
            this.LastTimeDemand.Width = 0.695F;
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
            this.ThisTimeFeeDmdNrml.Left = 9.406251F;
            this.ThisTimeFeeDmdNrml.MultiLine = false;
            this.ThisTimeFeeDmdNrml.Name = "ThisTimeFeeDmdNrml";
            this.ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("ThisTimeFeeDmdNrml.OutputFormat");
            this.ThisTimeFeeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeFeeDmdNrml.Text = "2,345,678,901";
            this.ThisTimeFeeDmdNrml.Top = 0.125F;
            this.ThisTimeFeeDmdNrml.Width = 0.695F;
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
            this.ThisTimeDisDmdNrml.Left = 10.09375F;
            this.ThisTimeDisDmdNrml.MultiLine = false;
            this.ThisTimeDisDmdNrml.Name = "ThisTimeDisDmdNrml";
            this.ThisTimeDisDmdNrml.OutputFormat = resources.GetString("ThisTimeDisDmdNrml.OutputFormat");
            this.ThisTimeDisDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.ThisTimeDisDmdNrml.Text = "2,345,678,901";
            this.ThisTimeDisDmdNrml.Top = 0.125F;
            this.ThisTimeDisDmdNrml.Width = 0.695F;
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
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
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
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 9.281251F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; vertical-" +
                "align: top; ";
            this.textBox2.Text = "%";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.125F;
            // 
            // ResultsSectCd
            // 
            this.ResultsSectCd.Border.BottomColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.LeftColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.RightColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.TopColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.DataField = "ResultsSectCd";
            this.ResultsSectCd.Height = 0.125F;
            this.ResultsSectCd.Left = 0.4375F;
            this.ResultsSectCd.MultiLine = false;
            this.ResultsSectCd.Name = "ResultsSectCd";
            this.ResultsSectCd.OutputFormat = resources.GetString("ResultsSectCd.OutputFormat");
            this.ResultsSectCd.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ ゴシック; ver" +
                "tical-align: top; ";
            this.ResultsSectCd.Text = "00";
            this.ResultsSectCd.Top = 0.125F;
            this.ResultsSectCd.Visible = false;
            this.ResultsSectCd.Width = 0.125F;
            // 
            // textBox_Null
            // 
            this.textBox_Null.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_Null.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Null.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_Null.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Null.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_Null.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Null.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_Null.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Null.Height = 0.125F;
            this.textBox_Null.Left = 0F;
            this.textBox_Null.Name = "textBox_Null";
            this.textBox_Null.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox_Null.Text = null;
            this.textBox_Null.Top = 0.25F;
            this.textBox_Null.Visible = false;
            this.textBox_Null.Width = 0.375F;
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
            this.ClaimSnm.Left = 0.4479167F;
            this.ClaimSnm.MultiLine = false;
            this.ClaimSnm.Name = "ClaimSnm";
            this.ClaimSnm.Style = "ddo-char-set: 1; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.ClaimSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.ClaimSnm.Top = 0F;
            this.ClaimSnm.Width = 2.13174F;
            // 
            // Line19
            // 
            this.Line19.Border.BottomColor = System.Drawing.Color.Black;
            this.Line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.LeftColor = System.Drawing.Color.Black;
            this.Line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.RightColor = System.Drawing.Color.Black;
            this.Line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.TopColor = System.Drawing.Color.Black;
            this.Line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Height = 0F;
            this.Line19.Left = 0F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 0F;
            this.Line19.Width = 10.8F;
            this.Line19.X1 = 0F;
            this.Line19.X2 = 10.8F;
            this.Line19.Y1 = 0F;
            this.Line19.Y2 = 0F;
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
            this.Label1.Text = "請求一覧表";
            this.Label1.Top = 0F;
            this.Label1.Width = 1.281F;
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
            this.SORTTITLE.Left = 1.625F;
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
            this.TextBox34,
            this.TextBox33,
            this.TextBox32,
            this.TextBox31,
            this.TextBox30,
            this.TextBox29,
            this.TextBox28,
            this.TextBox27,
            this.Label11,
            this.Label10,
            this.Lb_Name2,
            this.Line35,
            this.TextBox1,
            this.Lb_Name1,
            this.Lb_CollectRate,
            this.title_AcpOdrTtl3,
            this.title_AcpOdrTtl2,
            this.title_LastTimeDemand,
            this.title_MoneyKindDiv101,
            this.title_MoneyKindDiv102,
            this.title_MoneyKindDiv107,
            this.title_MoneyKindDiv105,
            this.title_MoneyKindDiv106,
            this.title_MoneyKindDiv109,
            this.title_MoneyKindDiv112,
            this.title_ThisTimeFeeDmdNrml,
            this.title_ThisTimeDisDmdNrml,
            this.label4,
            this.line_head});
            this.TitleHeader.Height = 0.4583333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // TextBox34
            // 
            this.TextBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Height = 0.1875F;
            this.TextBox34.Left = 5.34375F;
            this.TextBox34.Name = "TextBox34";
            this.TextBox34.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox34.Text = "返品値引";
            this.TextBox34.Top = 0F;
            this.TextBox34.Width = 0.625F;
            // 
            // TextBox33
            // 
            this.TextBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Height = 0.1875F;
            this.TextBox33.Left = 8.09375F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox33.Text = "今回請求額";
            this.TextBox33.Top = 0F;
            this.TextBox33.Width = 0.625F;
            // 
            // TextBox32
            // 
            this.TextBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Height = 0.1875F;
            this.TextBox32.Left = 7.40625F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox32.Text = "今回合計";
            this.TextBox32.Top = 0F;
            this.TextBox32.Width = 0.625F;
            // 
            // TextBox31
            // 
            this.TextBox31.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Height = 0.1875F;
            this.TextBox31.Left = 6.718751F;
            this.TextBox31.Name = "TextBox31";
            this.TextBox31.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox31.Text = "消費税";
            this.TextBox31.Top = 0F;
            this.TextBox31.Width = 0.625F;
            // 
            // TextBox30
            // 
            this.TextBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Height = 0.1875F;
            this.TextBox30.Left = 4.65625F;
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox30.Text = "売上額";
            this.TextBox30.Top = 0F;
            this.TextBox30.Width = 0.625F;
            // 
            // TextBox29
            // 
            this.TextBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox29.Height = 0.1875F;
            this.TextBox29.Left = 3.96875F;
            this.TextBox29.Name = "TextBox29";
            this.TextBox29.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox29.Text = "繰越額";
            this.TextBox29.Top = 0F;
            this.TextBox29.Width = 0.625F;
            // 
            // TextBox28
            // 
            this.TextBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox28.Height = 0.1875F;
            this.TextBox28.Left = 3.28125F;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox28.Text = "今回入金";
            this.TextBox28.Top = 0F;
            this.TextBox28.Width = 0.625F;
            // 
            // TextBox27
            // 
            this.TextBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox27.Height = 0.1875F;
            this.TextBox27.Left = 2.59375F;
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox27.Text = "請求残高";
            this.TextBox27.Top = 0F;
            this.TextBox27.Width = 0.625F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.1875F;
            this.Label11.HyperLink = "";
            this.Label11.Left = 9.614584F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: center; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.Label11.Text = "伝票枚数";
            this.Label11.Top = 0F;
            this.Label11.Width = 0.5F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.1875F;
            this.Label10.HyperLink = "";
            this.Label10.Left = 10.125F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.Label10.Text = "集金日";
            this.Label10.Top = 0F;
            this.Label10.Width = 0.5F;
            // 
            // Lb_Name2
            // 
            this.Lb_Name2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Name2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Name2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Name2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Name2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name2.Height = 0.1875F;
            this.Lb_Name2.HyperLink = "";
            this.Lb_Name2.Left = 0F;
            this.Lb_Name2.Name = "Lb_Name2";
            this.Lb_Name2.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.Lb_Name2.Text = "得意先";
            this.Lb_Name2.Top = 0.1875F;
            this.Lb_Name2.Width = 0.5F;
            // 
            // Line35
            // 
            this.Line35.Border.BottomColor = System.Drawing.Color.Black;
            this.Line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Border.LeftColor = System.Drawing.Color.Black;
            this.Line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Border.RightColor = System.Drawing.Color.Black;
            this.Line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Border.TopColor = System.Drawing.Color.Black;
            this.Line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Height = 0F;
            this.Line35.Left = 0F;
            this.Line35.LineWeight = 2F;
            this.Line35.Name = "Line35";
            this.Line35.Top = 0F;
            this.Line35.Width = 10.8F;
            this.Line35.X1 = 0F;
            this.Line35.X2 = 10.8F;
            this.Line35.Y1 = 0F;
            this.Line35.Y2 = 0F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 6.03125F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.TextBox1.Text = "純売上額";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 0.625F;
            // 
            // Lb_Name1
            // 
            this.Lb_Name1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Name1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Name1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Name1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Name1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Name1.Height = 0.1875F;
            this.Lb_Name1.HyperLink = "";
            this.Lb_Name1.Left = 1.625F;
            this.Lb_Name1.Name = "Lb_Name1";
            this.Lb_Name1.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.Lb_Name1.Text = "担当者";
            this.Lb_Name1.Top = 0F;
            this.Lb_Name1.Width = 0.4375F;
            // 
            // Lb_CollectRate
            // 
            this.Lb_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CollectRate.Height = 0.1875F;
            this.Lb_CollectRate.HyperLink = "";
            this.Lb_CollectRate.Left = 8.843751F;
            this.Lb_CollectRate.Name = "Lb_CollectRate";
            this.Lb_CollectRate.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.Lb_CollectRate.Text = "回収率";
            this.Lb_CollectRate.Top = 0F;
            this.Lb_CollectRate.Width = 0.5F;
            // 
            // title_AcpOdrTtl3
            // 
            this.title_AcpOdrTtl3.Border.BottomColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl3.Border.LeftColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl3.Border.RightColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl3.Border.TopColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl3.Height = 0.1875F;
            this.title_AcpOdrTtl3.Left = 2.59375F;
            this.title_AcpOdrTtl3.Name = "title_AcpOdrTtl3";
            this.title_AcpOdrTtl3.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_AcpOdrTtl3.Text = "前々々回";
            this.title_AcpOdrTtl3.Top = 0.1875F;
            this.title_AcpOdrTtl3.Width = 0.625F;
            // 
            // title_AcpOdrTtl2
            // 
            this.title_AcpOdrTtl2.Border.BottomColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl2.Border.LeftColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl2.Border.RightColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl2.Border.TopColor = System.Drawing.Color.Black;
            this.title_AcpOdrTtl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_AcpOdrTtl2.Height = 0.1875F;
            this.title_AcpOdrTtl2.Left = 3.28125F;
            this.title_AcpOdrTtl2.Name = "title_AcpOdrTtl2";
            this.title_AcpOdrTtl2.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_AcpOdrTtl2.Text = "前々回";
            this.title_AcpOdrTtl2.Top = 0.1875F;
            this.title_AcpOdrTtl2.Width = 0.625F;
            // 
            // title_LastTimeDemand
            // 
            this.title_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.title_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.title_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.title_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.title_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_LastTimeDemand.Height = 0.1875F;
            this.title_LastTimeDemand.Left = 3.96875F;
            this.title_LastTimeDemand.Name = "title_LastTimeDemand";
            this.title_LastTimeDemand.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_LastTimeDemand.Text = "前回";
            this.title_LastTimeDemand.Top = 0.1875F;
            this.title_LastTimeDemand.Width = 0.625F;
            // 
            // title_MoneyKindDiv101
            // 
            this.title_MoneyKindDiv101.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv101.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv101.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv101.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv101.Height = 0.1875F;
            this.title_MoneyKindDiv101.Left = 4.65625F;
            this.title_MoneyKindDiv101.Name = "title_MoneyKindDiv101";
            this.title_MoneyKindDiv101.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv101.Text = "現金";
            this.title_MoneyKindDiv101.Top = 0.1875F;
            this.title_MoneyKindDiv101.Width = 0.625F;
            // 
            // title_MoneyKindDiv102
            // 
            this.title_MoneyKindDiv102.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv102.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv102.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv102.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv102.Height = 0.1875F;
            this.title_MoneyKindDiv102.Left = 5.34375F;
            this.title_MoneyKindDiv102.Name = "title_MoneyKindDiv102";
            this.title_MoneyKindDiv102.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv102.Text = "振込";
            this.title_MoneyKindDiv102.Top = 0.1875F;
            this.title_MoneyKindDiv102.Width = 0.625F;
            // 
            // title_MoneyKindDiv107
            // 
            this.title_MoneyKindDiv107.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv107.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv107.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv107.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv107.Height = 0.1875F;
            this.title_MoneyKindDiv107.Left = 6.03125F;
            this.title_MoneyKindDiv107.Name = "title_MoneyKindDiv107";
            this.title_MoneyKindDiv107.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv107.Text = "小切手";
            this.title_MoneyKindDiv107.Top = 0.1875F;
            this.title_MoneyKindDiv107.Width = 0.625F;
            // 
            // title_MoneyKindDiv105
            // 
            this.title_MoneyKindDiv105.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv105.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv105.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv105.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv105.Height = 0.1875F;
            this.title_MoneyKindDiv105.Left = 6.718751F;
            this.title_MoneyKindDiv105.Name = "title_MoneyKindDiv105";
            this.title_MoneyKindDiv105.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv105.Text = "手形";
            this.title_MoneyKindDiv105.Top = 0.1875F;
            this.title_MoneyKindDiv105.Width = 0.625F;
            // 
            // title_MoneyKindDiv106
            // 
            this.title_MoneyKindDiv106.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv106.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv106.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv106.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv106.Height = 0.1875F;
            this.title_MoneyKindDiv106.Left = 7.40625F;
            this.title_MoneyKindDiv106.Name = "title_MoneyKindDiv106";
            this.title_MoneyKindDiv106.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv106.Text = "相殺";
            this.title_MoneyKindDiv106.Top = 0.1875F;
            this.title_MoneyKindDiv106.Width = 0.625F;
            // 
            // title_MoneyKindDiv109
            // 
            this.title_MoneyKindDiv109.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv109.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv109.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv109.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv109.Height = 0.1875F;
            this.title_MoneyKindDiv109.Left = 8.09375F;
            this.title_MoneyKindDiv109.Name = "title_MoneyKindDiv109";
            this.title_MoneyKindDiv109.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv109.Text = "その他";
            this.title_MoneyKindDiv109.Top = 0.1875F;
            this.title_MoneyKindDiv109.Width = 0.625F;
            // 
            // title_MoneyKindDiv112
            // 
            this.title_MoneyKindDiv112.Border.BottomColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv112.Border.LeftColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv112.Border.RightColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv112.Border.TopColor = System.Drawing.Color.Black;
            this.title_MoneyKindDiv112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_MoneyKindDiv112.Height = 0.1875F;
            this.title_MoneyKindDiv112.Left = 8.781251F;
            this.title_MoneyKindDiv112.Name = "title_MoneyKindDiv112";
            this.title_MoneyKindDiv112.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_MoneyKindDiv112.Text = "口座振替";
            this.title_MoneyKindDiv112.Top = 0.1875F;
            this.title_MoneyKindDiv112.Width = 0.625F;
            // 
            // title_ThisTimeFeeDmdNrml
            // 
            this.title_ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.title_ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.title_ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.title_ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.title_ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeFeeDmdNrml.Height = 0.1875F;
            this.title_ThisTimeFeeDmdNrml.Left = 9.479168F;
            this.title_ThisTimeFeeDmdNrml.Name = "title_ThisTimeFeeDmdNrml";
            this.title_ThisTimeFeeDmdNrml.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_ThisTimeFeeDmdNrml.Text = "手数料";
            this.title_ThisTimeFeeDmdNrml.Top = 0.1875F;
            this.title_ThisTimeFeeDmdNrml.Width = 0.625F;
            // 
            // title_ThisTimeDisDmdNrml
            // 
            this.title_ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.title_ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.title_ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.title_ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.title_ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.title_ThisTimeDisDmdNrml.Height = 0.1875F;
            this.title_ThisTimeDisDmdNrml.Left = 10.15625F;
            this.title_ThisTimeDisDmdNrml.Name = "title_ThisTimeDisDmdNrml";
            this.title_ThisTimeDisDmdNrml.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.title_ThisTimeDisDmdNrml.Text = "値引";
            this.title_ThisTimeDisDmdNrml.Top = 0.1875F;
            this.title_ThisTimeDisDmdNrml.Width = 0.625F;
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
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = "";
            this.label4.Left = 0F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: middle; ";
            this.label4.Text = "拠点";
            this.label4.Top = 0F;
            this.label4.Width = 0.5F;
            // 
            // line_head
            // 
            this.line_head.Border.BottomColor = System.Drawing.Color.Black;
            this.line_head.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_head.Border.LeftColor = System.Drawing.Color.Black;
            this.line_head.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_head.Border.RightColor = System.Drawing.Color.Black;
            this.line_head.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_head.Border.TopColor = System.Drawing.Color.Black;
            this.line_head.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_head.Height = 0F;
            this.line_head.Left = 0F;
            this.line_head.LineWeight = 1F;
            this.line_head.Name = "line_head";
            this.line_head.Top = 0.375F;
            this.line_head.Width = 10.8F;
            this.line_head.X1 = 0F;
            this.line_head.X2 = 10.8F;
            this.line_head.Y1 = 0.375F;
            this.line_head.Y2 = 0.375F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.s_ThisSalesPricRgdsDis,
            this.s_AfCalDemandPrice,
            this.s_OfsThisSalesSum,
            this.s_OfsThisSalesTax,
            this.s_OfsThisTimeSales,
            this.s_ThisTimeTtlBlcDmd,
            this.s_ThisTimeDmdNrml,
            this.s_DemandBalance,
            this.Line50,
            this.s_NetSales,
            this.s_SaleslSlipCount,
            this.MONEYKINDNAME13,
            this.s_AcpOdrTtl3TmBfBlDmd,
            this.s_MoneyKindDiv109,
            this.s_MoneyKindDiv106,
            this.s_MoneyKindDiv105,
            this.s_MoneyKindDiv101,
            this.s_LastTimeDemand,
            this.s_AcpOdrTtl2TmBfBlDmd,
            this.s_MoneyKindDiv102,
            this.s_MoneyKindDiv107,
            this.s_MoneyKindDiv112,
            this.s_ThisTimeFeeDmdNrml,
            this.s_ThisTimeDisDmdNrml,
            this.s_CollectRate,
            this.s_CollectDemand,
            this.textBox4,
            this.textBox_sec});
            this.SectionFooter.Height = 0.3854167F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // s_ThisSalesPricRgdsDis
            // 
            this.s_ThisSalesPricRgdsDis.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis.DataField = "ThisSalesPricRgdsDis";
            this.s_ThisSalesPricRgdsDis.Height = 0.125F;
            this.s_ThisSalesPricRgdsDis.Left = 5.255F;
            this.s_ThisSalesPricRgdsDis.MultiLine = false;
            this.s_ThisSalesPricRgdsDis.Name = "s_ThisSalesPricRgdsDis";
            this.s_ThisSalesPricRgdsDis.OutputFormat = resources.GetString("s_ThisSalesPricRgdsDis.OutputFormat");
            this.s_ThisSalesPricRgdsDis.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisSalesPricRgdsDis.SummaryGroup = "SectionHeader";
            this.s_ThisSalesPricRgdsDis.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisSalesPricRgdsDis.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisSalesPricRgdsDis.Text = "1,123,456,789";
            this.s_ThisSalesPricRgdsDis.Top = 0F;
            this.s_ThisSalesPricRgdsDis.Width = 0.72F;
            // 
            // s_AfCalDemandPrice
            // 
            this.s_AfCalDemandPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice.Border.RightColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice.Border.TopColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice.DataField = "AfCalDemandPrice";
            this.s_AfCalDemandPrice.Height = 0.125F;
            this.s_AfCalDemandPrice.Left = 8.010417F;
            this.s_AfCalDemandPrice.MultiLine = false;
            this.s_AfCalDemandPrice.Name = "s_AfCalDemandPrice";
            this.s_AfCalDemandPrice.OutputFormat = resources.GetString("s_AfCalDemandPrice.OutputFormat");
            this.s_AfCalDemandPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_AfCalDemandPrice.SummaryGroup = "SectionHeader";
            this.s_AfCalDemandPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_AfCalDemandPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_AfCalDemandPrice.Text = "1,123,456,789";
            this.s_AfCalDemandPrice.Top = 0F;
            this.s_AfCalDemandPrice.Width = 0.72F;
            // 
            // s_OfsThisSalesSum
            // 
            this.s_OfsThisSalesSum.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum.Border.RightColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum.Border.TopColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum.DataField = "OfsThisSalesSum";
            this.s_OfsThisSalesSum.Height = 0.125F;
            this.s_OfsThisSalesSum.Left = 7.3125F;
            this.s_OfsThisSalesSum.MultiLine = false;
            this.s_OfsThisSalesSum.Name = "s_OfsThisSalesSum";
            this.s_OfsThisSalesSum.OutputFormat = resources.GetString("s_OfsThisSalesSum.OutputFormat");
            this.s_OfsThisSalesSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_OfsThisSalesSum.SummaryGroup = "SectionHeader";
            this.s_OfsThisSalesSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OfsThisSalesSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OfsThisSalesSum.Text = "1,123,456,789";
            this.s_OfsThisSalesSum.Top = 0F;
            this.s_OfsThisSalesSum.Width = 0.72F;
            // 
            // s_OfsThisSalesTax
            // 
            this.s_OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.s_OfsThisSalesTax.Height = 0.125F;
            this.s_OfsThisSalesTax.Left = 6.625F;
            this.s_OfsThisSalesTax.MultiLine = false;
            this.s_OfsThisSalesTax.Name = "s_OfsThisSalesTax";
            this.s_OfsThisSalesTax.OutputFormat = resources.GetString("s_OfsThisSalesTax.OutputFormat");
            this.s_OfsThisSalesTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_OfsThisSalesTax.SummaryGroup = "SectionHeader";
            this.s_OfsThisSalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OfsThisSalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OfsThisSalesTax.Text = "1,123,456,789";
            this.s_OfsThisSalesTax.Top = 0F;
            this.s_OfsThisSalesTax.Width = 0.72F;
            // 
            // s_OfsThisTimeSales
            // 
            this.s_OfsThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales.DataField = "ThisTimeSales";
            this.s_OfsThisTimeSales.Height = 0.125F;
            this.s_OfsThisTimeSales.Left = 4.5625F;
            this.s_OfsThisTimeSales.MultiLine = false;
            this.s_OfsThisTimeSales.Name = "s_OfsThisTimeSales";
            this.s_OfsThisTimeSales.OutputFormat = resources.GetString("s_OfsThisTimeSales.OutputFormat");
            this.s_OfsThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_OfsThisTimeSales.SummaryGroup = "SectionHeader";
            this.s_OfsThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OfsThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OfsThisTimeSales.Text = "1,123,456,789";
            this.s_OfsThisTimeSales.Top = 0F;
            this.s_OfsThisTimeSales.Width = 0.72F;
            // 
            // s_ThisTimeTtlBlcDmd
            // 
            this.s_ThisTimeTtlBlcDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd.DataField = "ThisTimeTtlBlcDmd";
            this.s_ThisTimeTtlBlcDmd.Height = 0.125F;
            this.s_ThisTimeTtlBlcDmd.Left = 3.875F;
            this.s_ThisTimeTtlBlcDmd.MultiLine = false;
            this.s_ThisTimeTtlBlcDmd.Name = "s_ThisTimeTtlBlcDmd";
            this.s_ThisTimeTtlBlcDmd.OutputFormat = resources.GetString("s_ThisTimeTtlBlcDmd.OutputFormat");
            this.s_ThisTimeTtlBlcDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeTtlBlcDmd.SummaryGroup = "SectionHeader";
            this.s_ThisTimeTtlBlcDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeTtlBlcDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeTtlBlcDmd.Text = "1,123,456,789";
            this.s_ThisTimeTtlBlcDmd.Top = 0F;
            this.s_ThisTimeTtlBlcDmd.Width = 0.72F;
            // 
            // s_ThisTimeDmdNrml
            // 
            this.s_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.s_ThisTimeDmdNrml.Height = 0.125F;
            this.s_ThisTimeDmdNrml.Left = 3.1875F;
            this.s_ThisTimeDmdNrml.MultiLine = false;
            this.s_ThisTimeDmdNrml.Name = "s_ThisTimeDmdNrml";
            this.s_ThisTimeDmdNrml.OutputFormat = resources.GetString("s_ThisTimeDmdNrml.OutputFormat");
            this.s_ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeDmdNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDmdNrml.Text = "1,123,456,789";
            this.s_ThisTimeDmdNrml.Top = 0F;
            this.s_ThisTimeDmdNrml.Width = 0.72F;
            // 
            // s_DemandBalance
            // 
            this.s_DemandBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.s_DemandBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.s_DemandBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance.Border.RightColor = System.Drawing.Color.Black;
            this.s_DemandBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance.Border.TopColor = System.Drawing.Color.Black;
            this.s_DemandBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance.DataField = "DemandBalance";
            this.s_DemandBalance.Height = 0.125F;
            this.s_DemandBalance.Left = 2.5F;
            this.s_DemandBalance.MultiLine = false;
            this.s_DemandBalance.Name = "s_DemandBalance";
            this.s_DemandBalance.OutputFormat = resources.GetString("s_DemandBalance.OutputFormat");
            this.s_DemandBalance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_DemandBalance.SummaryGroup = "SectionHeader";
            this.s_DemandBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DemandBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DemandBalance.Text = "1,123,456,789";
            this.s_DemandBalance.Top = 0F;
            this.s_DemandBalance.Width = 0.72F;
            // 
            // Line50
            // 
            this.Line50.Border.BottomColor = System.Drawing.Color.Black;
            this.Line50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line50.Border.LeftColor = System.Drawing.Color.Black;
            this.Line50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line50.Border.RightColor = System.Drawing.Color.Black;
            this.Line50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line50.Border.TopColor = System.Drawing.Color.Black;
            this.Line50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line50.Height = 0F;
            this.Line50.Left = 0F;
            this.Line50.LineWeight = 1F;
            this.Line50.Name = "Line50";
            this.Line50.Top = 0F;
            this.Line50.Width = 10.8F;
            this.Line50.X1 = 0F;
            this.Line50.X2 = 10.8F;
            this.Line50.Y1 = 0F;
            this.Line50.Y2 = 0F;
            // 
            // s_NetSales
            // 
            this.s_NetSales.Border.BottomColor = System.Drawing.Color.Black;
            this.s_NetSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales.Border.LeftColor = System.Drawing.Color.Black;
            this.s_NetSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales.Border.RightColor = System.Drawing.Color.Black;
            this.s_NetSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales.Border.TopColor = System.Drawing.Color.Black;
            this.s_NetSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales.DataField = "NetSales";
            this.s_NetSales.Height = 0.125F;
            this.s_NetSales.Left = 5.9375F;
            this.s_NetSales.MultiLine = false;
            this.s_NetSales.Name = "s_NetSales";
            this.s_NetSales.OutputFormat = resources.GetString("s_NetSales.OutputFormat");
            this.s_NetSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_NetSales.SummaryGroup = "SectionHeader";
            this.s_NetSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_NetSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_NetSales.Text = "1,123,456,789";
            this.s_NetSales.Top = 0F;
            this.s_NetSales.Width = 0.72F;
            // 
            // s_SaleslSlipCount
            // 
            this.s_SaleslSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount.DataField = "SaleslSlipCount";
            this.s_SaleslSlipCount.Height = 0.125F;
            this.s_SaleslSlipCount.Left = 9.499F;
            this.s_SaleslSlipCount.MultiLine = false;
            this.s_SaleslSlipCount.Name = "s_SaleslSlipCount";
            this.s_SaleslSlipCount.OutputFormat = resources.GetString("s_SaleslSlipCount.OutputFormat");
            this.s_SaleslSlipCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_SaleslSlipCount.SummaryGroup = "SectionHeader";
            this.s_SaleslSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_SaleslSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_SaleslSlipCount.Text = "123,456";
            this.s_SaleslSlipCount.Top = 0F;
            this.s_SaleslSlipCount.Width = 0.605F;
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
            this.MONEYKINDNAME13.Left = 1.0625F;
            this.MONEYKINDNAME13.MultiLine = false;
            this.MONEYKINDNAME13.Name = "MONEYKINDNAME13";
            this.MONEYKINDNAME13.OutputFormat = resources.GetString("MONEYKINDNAME13.OutputFormat");
            this.MONEYKINDNAME13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.MONEYKINDNAME13.Text = "拠点計";
            this.MONEYKINDNAME13.Top = 0F;
            this.MONEYKINDNAME13.Width = 0.5625F;
            // 
            // s_AcpOdrTtl3TmBfBlDmd
            // 
            this.s_AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.s_AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.s_AcpOdrTtl3TmBfBlDmd.Left = 2.5F;
            this.s_AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.s_AcpOdrTtl3TmBfBlDmd.Name = "s_AcpOdrTtl3TmBfBlDmd";
            this.s_AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("s_AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.s_AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_AcpOdrTtl3TmBfBlDmd.SummaryGroup = "SectionHeader";
            this.s_AcpOdrTtl3TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_AcpOdrTtl3TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_AcpOdrTtl3TmBfBlDmd.Text = "1,123,456,789";
            this.s_AcpOdrTtl3TmBfBlDmd.Top = 0.125F;
            this.s_AcpOdrTtl3TmBfBlDmd.Width = 0.72F;
            // 
            // s_MoneyKindDiv109
            // 
            this.s_MoneyKindDiv109.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv109.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv109.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv109.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv109.DataField = "MoneyKindDiv109";
            this.s_MoneyKindDiv109.Height = 0.125F;
            this.s_MoneyKindDiv109.Left = 8.010417F;
            this.s_MoneyKindDiv109.MultiLine = false;
            this.s_MoneyKindDiv109.Name = "s_MoneyKindDiv109";
            this.s_MoneyKindDiv109.OutputFormat = resources.GetString("s_MoneyKindDiv109.OutputFormat");
            this.s_MoneyKindDiv109.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv109.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv109.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv109.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv109.Text = "1,123,456,789";
            this.s_MoneyKindDiv109.Top = 0.125F;
            this.s_MoneyKindDiv109.Width = 0.72F;
            // 
            // s_MoneyKindDiv106
            // 
            this.s_MoneyKindDiv106.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv106.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv106.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv106.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv106.DataField = "MoneyKindDiv106";
            this.s_MoneyKindDiv106.Height = 0.125F;
            this.s_MoneyKindDiv106.Left = 7.3125F;
            this.s_MoneyKindDiv106.MultiLine = false;
            this.s_MoneyKindDiv106.Name = "s_MoneyKindDiv106";
            this.s_MoneyKindDiv106.OutputFormat = resources.GetString("s_MoneyKindDiv106.OutputFormat");
            this.s_MoneyKindDiv106.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv106.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv106.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv106.Text = "1,123,456,789";
            this.s_MoneyKindDiv106.Top = 0.125F;
            this.s_MoneyKindDiv106.Width = 0.72F;
            // 
            // s_MoneyKindDiv105
            // 
            this.s_MoneyKindDiv105.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv105.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv105.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv105.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv105.DataField = "MoneyKindDiv105";
            this.s_MoneyKindDiv105.Height = 0.125F;
            this.s_MoneyKindDiv105.Left = 6.625F;
            this.s_MoneyKindDiv105.MultiLine = false;
            this.s_MoneyKindDiv105.Name = "s_MoneyKindDiv105";
            this.s_MoneyKindDiv105.OutputFormat = resources.GetString("s_MoneyKindDiv105.OutputFormat");
            this.s_MoneyKindDiv105.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv105.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv105.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv105.Text = "1,123,456,789";
            this.s_MoneyKindDiv105.Top = 0.125F;
            this.s_MoneyKindDiv105.Width = 0.72F;
            // 
            // s_MoneyKindDiv101
            // 
            this.s_MoneyKindDiv101.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv101.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv101.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv101.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv101.DataField = "MoneyKindDiv101";
            this.s_MoneyKindDiv101.Height = 0.125F;
            this.s_MoneyKindDiv101.Left = 4.5625F;
            this.s_MoneyKindDiv101.MultiLine = false;
            this.s_MoneyKindDiv101.Name = "s_MoneyKindDiv101";
            this.s_MoneyKindDiv101.OutputFormat = resources.GetString("s_MoneyKindDiv101.OutputFormat");
            this.s_MoneyKindDiv101.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv101.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv101.Text = "1,123,456,789";
            this.s_MoneyKindDiv101.Top = 0.125F;
            this.s_MoneyKindDiv101.Width = 0.72F;
            // 
            // s_LastTimeDemand
            // 
            this.s_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand.DataField = "LastTimeDemand";
            this.s_LastTimeDemand.Height = 0.125F;
            this.s_LastTimeDemand.Left = 3.875F;
            this.s_LastTimeDemand.MultiLine = false;
            this.s_LastTimeDemand.Name = "s_LastTimeDemand";
            this.s_LastTimeDemand.OutputFormat = resources.GetString("s_LastTimeDemand.OutputFormat");
            this.s_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_LastTimeDemand.SummaryGroup = "SectionHeader";
            this.s_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_LastTimeDemand.Text = "1,123,456,789";
            this.s_LastTimeDemand.Top = 0.125F;
            this.s_LastTimeDemand.Width = 0.72F;
            // 
            // s_AcpOdrTtl2TmBfBlDmd
            // 
            this.s_AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.s_AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.s_AcpOdrTtl2TmBfBlDmd.Left = 3.1875F;
            this.s_AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.s_AcpOdrTtl2TmBfBlDmd.Name = "s_AcpOdrTtl2TmBfBlDmd";
            this.s_AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("s_AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.s_AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_AcpOdrTtl2TmBfBlDmd.SummaryGroup = "SectionHeader";
            this.s_AcpOdrTtl2TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_AcpOdrTtl2TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_AcpOdrTtl2TmBfBlDmd.Text = "1,123,456,789";
            this.s_AcpOdrTtl2TmBfBlDmd.Top = 0.125F;
            this.s_AcpOdrTtl2TmBfBlDmd.Width = 0.72F;
            // 
            // s_MoneyKindDiv102
            // 
            this.s_MoneyKindDiv102.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv102.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv102.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv102.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv102.DataField = "MoneyKindDiv102";
            this.s_MoneyKindDiv102.Height = 0.125F;
            this.s_MoneyKindDiv102.Left = 5.255F;
            this.s_MoneyKindDiv102.MultiLine = false;
            this.s_MoneyKindDiv102.Name = "s_MoneyKindDiv102";
            this.s_MoneyKindDiv102.OutputFormat = resources.GetString("s_MoneyKindDiv102.OutputFormat");
            this.s_MoneyKindDiv102.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv102.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv102.Text = "1,123,456,789";
            this.s_MoneyKindDiv102.Top = 0.125F;
            this.s_MoneyKindDiv102.Width = 0.72F;
            // 
            // s_MoneyKindDiv107
            // 
            this.s_MoneyKindDiv107.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv107.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv107.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv107.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv107.DataField = "MoneyKindDiv107";
            this.s_MoneyKindDiv107.Height = 0.125F;
            this.s_MoneyKindDiv107.Left = 5.9375F;
            this.s_MoneyKindDiv107.MultiLine = false;
            this.s_MoneyKindDiv107.Name = "s_MoneyKindDiv107";
            this.s_MoneyKindDiv107.OutputFormat = resources.GetString("s_MoneyKindDiv107.OutputFormat");
            this.s_MoneyKindDiv107.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv107.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv107.Text = "1,123,456,789";
            this.s_MoneyKindDiv107.Top = 0.125F;
            this.s_MoneyKindDiv107.Width = 0.72F;
            // 
            // s_MoneyKindDiv112
            // 
            this.s_MoneyKindDiv112.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv112.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv112.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv112.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv112.DataField = "MoneyKindDiv112";
            this.s_MoneyKindDiv112.Height = 0.125F;
            this.s_MoneyKindDiv112.Left = 8.6875F;
            this.s_MoneyKindDiv112.MultiLine = false;
            this.s_MoneyKindDiv112.Name = "s_MoneyKindDiv112";
            this.s_MoneyKindDiv112.OutputFormat = resources.GetString("s_MoneyKindDiv112.OutputFormat");
            this.s_MoneyKindDiv112.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv112.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv112.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv112.Text = "1,123,456,789";
            this.s_MoneyKindDiv112.Top = 0.125F;
            this.s_MoneyKindDiv112.Width = 0.72F;
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
            this.s_ThisTimeFeeDmdNrml.Left = 9.375F;
            this.s_ThisTimeFeeDmdNrml.MultiLine = false;
            this.s_ThisTimeFeeDmdNrml.Name = "s_ThisTimeFeeDmdNrml";
            this.s_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("s_ThisTimeFeeDmdNrml.OutputFormat");
            this.s_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeFeeDmdNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeeDmdNrml.Text = "1,123,456,789";
            this.s_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.s_ThisTimeFeeDmdNrml.Width = 0.72F;
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
            this.s_ThisTimeDisDmdNrml.Left = 10.0625F;
            this.s_ThisTimeDisDmdNrml.MultiLine = false;
            this.s_ThisTimeDisDmdNrml.Name = "s_ThisTimeDisDmdNrml";
            this.s_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("s_ThisTimeDisDmdNrml.OutputFormat");
            this.s_ThisTimeDisDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeDisDmdNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisDmdNrml.Text = "1,123,456,789";
            this.s_ThisTimeDisDmdNrml.Top = 0.125F;
            this.s_ThisTimeDisDmdNrml.Width = 0.72F;
            // 
            // s_CollectRate
            // 
            this.s_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate.Height = 0.125F;
            this.s_CollectRate.Left = 8.791668F;
            this.s_CollectRate.MultiLine = false;
            this.s_CollectRate.Name = "s_CollectRate";
            this.s_CollectRate.OutputFormat = resources.GetString("s_CollectRate.OutputFormat");
            this.s_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_CollectRate.Text = "123.00";
            this.s_CollectRate.Top = 0F;
            this.s_CollectRate.Width = 0.5F;
            // 
            // s_CollectDemand
            // 
            this.s_CollectDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CollectDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CollectDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand.Border.RightColor = System.Drawing.Color.Black;
            this.s_CollectDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand.Border.TopColor = System.Drawing.Color.Black;
            this.s_CollectDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand.DataField = "CollectDemand";
            this.s_CollectDemand.Height = 0.125F;
            this.s_CollectDemand.Left = 0F;
            this.s_CollectDemand.Name = "s_CollectDemand";
            this.s_CollectDemand.OutputFormat = resources.GetString("s_CollectDemand.OutputFormat");
            this.s_CollectDemand.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.s_CollectDemand.SummaryGroup = "SectionHeader";
            this.s_CollectDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CollectDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CollectDemand.Text = null;
            this.s_CollectDemand.Top = 0F;
            this.s_CollectDemand.Visible = false;
            this.s_CollectDemand.Width = 0.375F;
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
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 9.281251F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.textBox4.Text = "%";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.125F;
            // 
            // textBox_sec
            // 
            this.textBox_sec.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Height = 0.125F;
            this.textBox_sec.Left = 2.5625F;
            this.textBox_sec.Name = "textBox_sec";
            this.textBox_sec.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox_sec.Text = null;
            this.textBox_sec.Top = 0.25F;
            this.textBox_sec.Visible = false;
            this.textBox_sec.Width = 0.375F;
            // 
            // EmployeeHeader
            // 
            this.EmployeeHeader.CanShrink = true;
            this.EmployeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Em_Name,
            this.Em_Code,
            this.Line19,
            this.AddUpSecCode,
            this.AddUpSecName});
            this.EmployeeHeader.Height = 0.2291667F;
            this.EmployeeHeader.Name = "EmployeeHeader";
            this.EmployeeHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.EmployeeHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.EmployeeHeader.Visible = false;
            this.EmployeeHeader.Format += new System.EventHandler(this.EmployeeHeader_Format);
            // 
            // Em_Name
            // 
            this.Em_Name.Border.BottomColor = System.Drawing.Color.Black;
            this.Em_Name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Border.LeftColor = System.Drawing.Color.Black;
            this.Em_Name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Border.RightColor = System.Drawing.Color.Black;
            this.Em_Name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Border.TopColor = System.Drawing.Color.Black;
            this.Em_Name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Height = 0.125F;
            this.Em_Name.Left = 1.874999F;
            this.Em_Name.MultiLine = false;
            this.Em_Name.Name = "Em_Name";
            this.Em_Name.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; vertical-align: top; ";
            this.Em_Name.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.Em_Name.Top = 0F;
            this.Em_Name.Visible = false;
            this.Em_Name.Width = 3.26847F;
            // 
            // Em_Code
            // 
            this.Em_Code.Border.BottomColor = System.Drawing.Color.Black;
            this.Em_Code.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Border.LeftColor = System.Drawing.Color.Black;
            this.Em_Code.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Border.RightColor = System.Drawing.Color.Black;
            this.Em_Code.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Border.TopColor = System.Drawing.Color.Black;
            this.Em_Code.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Height = 0.125F;
            this.Em_Code.Left = 1.625F;
            this.Em_Code.MultiLine = false;
            this.Em_Code.Name = "Em_Code";
            this.Em_Code.OutputFormat = resources.GetString("Em_Code.OutputFormat");
            this.Em_Code.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.Em_Code.Text = "1234";
            this.Em_Code.Top = 0F;
            this.Em_Code.Visible = false;
            this.Em_Code.Width = 0.2806373F;
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
            this.AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.AddUpSecCode.Text = "00";
            this.AddUpSecCode.Top = 0F;
            this.AddUpSecCode.Width = 0.1433824F;
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
            this.AddUpSecName.DataField = "AddUpSecName";
            this.AddUpSecName.Height = 0.125F;
            this.AddUpSecName.Left = 0.1415441F;
            this.AddUpSecName.MultiLine = false;
            this.AddUpSecName.Name = "AddUpSecName";
            this.AddUpSecName.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; vertical-align: top; ";
            this.AddUpSecName.Text = "拠点３４５６７８９０";
            this.AddUpSecName.Top = 0F;
            this.AddUpSecName.Width = 1.121324F;
            // 
            // EmployeeFooter
            // 
            this.EmployeeFooter.CanShrink = true;
            this.EmployeeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.e_ThisSalesPricRgdsDis,
            this.e_AfCalDemandPrice,
            this.e_OfsThisSalesSum,
            this.e_OfsThisSalesTax,
            this.e_OfsThisTimeSales,
            this.e_ThisTimeTtlBlcDmd,
            this.e_ThisTimeDmdNrml,
            this.e_DemandBalance,
            this.Line53,
            this.e_SaleslSlipCount,
            this.e_NetSales,
            this.tb_SumTitle,
            this.e_AcpOdrTtl3TmBfBlDmd,
            this.e_MoneyKindDiv109,
            this.e_MoneyKindDiv106,
            this.e_MoneyKindDiv105,
            this.e_MoneyKindDiv101,
            this.e_LastTimeDemand,
            this.e_AcpOdrTtl2TmBfBlDmd,
            this.e_MoneyKindDiv102,
            this.e_MoneyKindDiv107,
            this.e_MoneyKindDiv112,
            this.e_ThisTimeFeeDmdNrml,
            this.e_ThisTimeDisDmdNrml,
            this.e_CollectRate,
            this.e_CollectDemand,
            this.textBox3,
            this.textBox_emp});
            this.EmployeeFooter.Height = 0.3958333F;
            this.EmployeeFooter.KeepTogether = true;
            this.EmployeeFooter.Name = "EmployeeFooter";
            this.EmployeeFooter.Visible = false;
            this.EmployeeFooter.BeforePrint += new System.EventHandler(this.EmployeeFooter_BeforePrint);
            // 
            // e_ThisSalesPricRgdsDis
            // 
            this.e_ThisSalesPricRgdsDis.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis.DataField = "ThisSalesPricRgdsDis";
            this.e_ThisSalesPricRgdsDis.Height = 0.125F;
            this.e_ThisSalesPricRgdsDis.Left = 5.255F;
            this.e_ThisSalesPricRgdsDis.MultiLine = false;
            this.e_ThisSalesPricRgdsDis.Name = "e_ThisSalesPricRgdsDis";
            this.e_ThisSalesPricRgdsDis.OutputFormat = resources.GetString("e_ThisSalesPricRgdsDis.OutputFormat");
            this.e_ThisSalesPricRgdsDis.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisSalesPricRgdsDis.SummaryGroup = "EmployeeHeader";
            this.e_ThisSalesPricRgdsDis.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisSalesPricRgdsDis.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisSalesPricRgdsDis.Text = "1,123,456,789";
            this.e_ThisSalesPricRgdsDis.Top = 0F;
            this.e_ThisSalesPricRgdsDis.Width = 0.72F;
            // 
            // e_AfCalDemandPrice
            // 
            this.e_AfCalDemandPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice.Border.RightColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice.Border.TopColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice.DataField = "AfCalDemandPrice";
            this.e_AfCalDemandPrice.Height = 0.125F;
            this.e_AfCalDemandPrice.Left = 8.010417F;
            this.e_AfCalDemandPrice.MultiLine = false;
            this.e_AfCalDemandPrice.Name = "e_AfCalDemandPrice";
            this.e_AfCalDemandPrice.OutputFormat = resources.GetString("e_AfCalDemandPrice.OutputFormat");
            this.e_AfCalDemandPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_AfCalDemandPrice.SummaryGroup = "EmployeeHeader";
            this.e_AfCalDemandPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_AfCalDemandPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_AfCalDemandPrice.Text = "1,123,456,789";
            this.e_AfCalDemandPrice.Top = 0F;
            this.e_AfCalDemandPrice.Width = 0.72F;
            // 
            // e_OfsThisSalesSum
            // 
            this.e_OfsThisSalesSum.Border.BottomColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum.Border.LeftColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum.Border.RightColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum.Border.TopColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum.DataField = "OfsThisSalesSum";
            this.e_OfsThisSalesSum.Height = 0.125F;
            this.e_OfsThisSalesSum.Left = 7.3125F;
            this.e_OfsThisSalesSum.MultiLine = false;
            this.e_OfsThisSalesSum.Name = "e_OfsThisSalesSum";
            this.e_OfsThisSalesSum.OutputFormat = resources.GetString("e_OfsThisSalesSum.OutputFormat");
            this.e_OfsThisSalesSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_OfsThisSalesSum.SummaryGroup = "EmployeeHeader";
            this.e_OfsThisSalesSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_OfsThisSalesSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_OfsThisSalesSum.Text = "1,123,456,789";
            this.e_OfsThisSalesSum.Top = 0F;
            this.e_OfsThisSalesSum.Width = 0.72F;
            // 
            // e_OfsThisSalesTax
            // 
            this.e_OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.e_OfsThisSalesTax.Height = 0.125F;
            this.e_OfsThisSalesTax.Left = 6.625F;
            this.e_OfsThisSalesTax.MultiLine = false;
            this.e_OfsThisSalesTax.Name = "e_OfsThisSalesTax";
            this.e_OfsThisSalesTax.OutputFormat = resources.GetString("e_OfsThisSalesTax.OutputFormat");
            this.e_OfsThisSalesTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_OfsThisSalesTax.SummaryGroup = "EmployeeHeader";
            this.e_OfsThisSalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_OfsThisSalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_OfsThisSalesTax.Text = "1,123,456,789";
            this.e_OfsThisSalesTax.Top = 0F;
            this.e_OfsThisSalesTax.Width = 0.72F;
            // 
            // e_OfsThisTimeSales
            // 
            this.e_OfsThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales.DataField = "ThisTimeSales";
            this.e_OfsThisTimeSales.Height = 0.125F;
            this.e_OfsThisTimeSales.Left = 4.5625F;
            this.e_OfsThisTimeSales.MultiLine = false;
            this.e_OfsThisTimeSales.Name = "e_OfsThisTimeSales";
            this.e_OfsThisTimeSales.OutputFormat = resources.GetString("e_OfsThisTimeSales.OutputFormat");
            this.e_OfsThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_OfsThisTimeSales.SummaryGroup = "EmployeeHeader";
            this.e_OfsThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_OfsThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_OfsThisTimeSales.Text = "1,123,456,789";
            this.e_OfsThisTimeSales.Top = 0F;
            this.e_OfsThisTimeSales.Width = 0.72F;
            // 
            // e_ThisTimeTtlBlcDmd
            // 
            this.e_ThisTimeTtlBlcDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd.DataField = "ThisTimeTtlBlcDmd";
            this.e_ThisTimeTtlBlcDmd.Height = 0.125F;
            this.e_ThisTimeTtlBlcDmd.Left = 3.875F;
            this.e_ThisTimeTtlBlcDmd.MultiLine = false;
            this.e_ThisTimeTtlBlcDmd.Name = "e_ThisTimeTtlBlcDmd";
            this.e_ThisTimeTtlBlcDmd.OutputFormat = resources.GetString("e_ThisTimeTtlBlcDmd.OutputFormat");
            this.e_ThisTimeTtlBlcDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeTtlBlcDmd.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeTtlBlcDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeTtlBlcDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeTtlBlcDmd.Text = "1,123,456,789";
            this.e_ThisTimeTtlBlcDmd.Top = 0F;
            this.e_ThisTimeTtlBlcDmd.Width = 0.72F;
            // 
            // e_ThisTimeDmdNrml
            // 
            this.e_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.e_ThisTimeDmdNrml.Height = 0.125F;
            this.e_ThisTimeDmdNrml.Left = 3.1875F;
            this.e_ThisTimeDmdNrml.MultiLine = false;
            this.e_ThisTimeDmdNrml.Name = "e_ThisTimeDmdNrml";
            this.e_ThisTimeDmdNrml.OutputFormat = resources.GetString("e_ThisTimeDmdNrml.OutputFormat");
            this.e_ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeDmdNrml.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeDmdNrml.Text = "1,123,456,789";
            this.e_ThisTimeDmdNrml.Top = 0F;
            this.e_ThisTimeDmdNrml.Width = 0.72F;
            // 
            // e_DemandBalance
            // 
            this.e_DemandBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.e_DemandBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.e_DemandBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance.Border.RightColor = System.Drawing.Color.Black;
            this.e_DemandBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance.Border.TopColor = System.Drawing.Color.Black;
            this.e_DemandBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance.DataField = "DemandBalance";
            this.e_DemandBalance.Height = 0.125F;
            this.e_DemandBalance.Left = 2.5F;
            this.e_DemandBalance.MultiLine = false;
            this.e_DemandBalance.Name = "e_DemandBalance";
            this.e_DemandBalance.OutputFormat = resources.GetString("e_DemandBalance.OutputFormat");
            this.e_DemandBalance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_DemandBalance.SummaryGroup = "EmployeeHeader";
            this.e_DemandBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_DemandBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_DemandBalance.Text = "1,123,456,789";
            this.e_DemandBalance.Top = 0F;
            this.e_DemandBalance.Width = 0.72F;
            // 
            // Line53
            // 
            this.Line53.Border.BottomColor = System.Drawing.Color.Black;
            this.Line53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line53.Border.LeftColor = System.Drawing.Color.Black;
            this.Line53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line53.Border.RightColor = System.Drawing.Color.Black;
            this.Line53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line53.Border.TopColor = System.Drawing.Color.Black;
            this.Line53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line53.Height = 0F;
            this.Line53.Left = 0F;
            this.Line53.LineWeight = 1F;
            this.Line53.Name = "Line53";
            this.Line53.Top = 0F;
            this.Line53.Width = 10.8F;
            this.Line53.X1 = 0F;
            this.Line53.X2 = 10.8F;
            this.Line53.Y1 = 0F;
            this.Line53.Y2 = 0F;
            // 
            // e_SaleslSlipCount
            // 
            this.e_SaleslSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount.DataField = "SaleslSlipCount";
            this.e_SaleslSlipCount.Height = 0.125F;
            this.e_SaleslSlipCount.Left = 9.499F;
            this.e_SaleslSlipCount.MultiLine = false;
            this.e_SaleslSlipCount.Name = "e_SaleslSlipCount";
            this.e_SaleslSlipCount.OutputFormat = resources.GetString("e_SaleslSlipCount.OutputFormat");
            this.e_SaleslSlipCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_SaleslSlipCount.SummaryGroup = "EmployeeHeader";
            this.e_SaleslSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_SaleslSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_SaleslSlipCount.Text = "123,456";
            this.e_SaleslSlipCount.Top = 0F;
            this.e_SaleslSlipCount.Width = 0.605F;
            // 
            // e_NetSales
            // 
            this.e_NetSales.Border.BottomColor = System.Drawing.Color.Black;
            this.e_NetSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales.Border.LeftColor = System.Drawing.Color.Black;
            this.e_NetSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales.Border.RightColor = System.Drawing.Color.Black;
            this.e_NetSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales.Border.TopColor = System.Drawing.Color.Black;
            this.e_NetSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales.DataField = "NetSales";
            this.e_NetSales.Height = 0.125F;
            this.e_NetSales.Left = 5.9375F;
            this.e_NetSales.MultiLine = false;
            this.e_NetSales.Name = "e_NetSales";
            this.e_NetSales.OutputFormat = resources.GetString("e_NetSales.OutputFormat");
            this.e_NetSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_NetSales.SummaryGroup = "EmployeeHeader";
            this.e_NetSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_NetSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_NetSales.Text = "1,123,456,789";
            this.e_NetSales.Top = 0F;
            this.e_NetSales.Width = 0.72F;
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
            this.tb_SumTitle.Left = 1.0625F;
            this.tb_SumTitle.MultiLine = false;
            this.tb_SumTitle.Name = "tb_SumTitle";
            this.tb_SumTitle.OutputFormat = resources.GetString("tb_SumTitle.OutputFormat");
            this.tb_SumTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SumTitle.Text = "担当者計";
            this.tb_SumTitle.Top = 0F;
            this.tb_SumTitle.Width = 0.6875F;
            // 
            // e_AcpOdrTtl3TmBfBlDmd
            // 
            this.e_AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.e_AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.e_AcpOdrTtl3TmBfBlDmd.Left = 2.5F;
            this.e_AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.e_AcpOdrTtl3TmBfBlDmd.Name = "e_AcpOdrTtl3TmBfBlDmd";
            this.e_AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("e_AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.e_AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_AcpOdrTtl3TmBfBlDmd.SummaryGroup = "EmployeeHeader";
            this.e_AcpOdrTtl3TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_AcpOdrTtl3TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_AcpOdrTtl3TmBfBlDmd.Text = "1,123,456,789";
            this.e_AcpOdrTtl3TmBfBlDmd.Top = 0.125F;
            this.e_AcpOdrTtl3TmBfBlDmd.Width = 0.72F;
            // 
            // e_MoneyKindDiv109
            // 
            this.e_MoneyKindDiv109.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv109.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv109.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv109.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv109.DataField = "MoneyKindDiv109";
            this.e_MoneyKindDiv109.Height = 0.125F;
            this.e_MoneyKindDiv109.Left = 8.010417F;
            this.e_MoneyKindDiv109.MultiLine = false;
            this.e_MoneyKindDiv109.Name = "e_MoneyKindDiv109";
            this.e_MoneyKindDiv109.OutputFormat = resources.GetString("e_MoneyKindDiv109.OutputFormat");
            this.e_MoneyKindDiv109.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv109.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv109.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv109.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv109.Text = "1,123,456,789";
            this.e_MoneyKindDiv109.Top = 0.125F;
            this.e_MoneyKindDiv109.Width = 0.72F;
            // 
            // e_MoneyKindDiv106
            // 
            this.e_MoneyKindDiv106.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv106.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv106.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv106.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv106.DataField = "MoneyKindDiv106";
            this.e_MoneyKindDiv106.Height = 0.125F;
            this.e_MoneyKindDiv106.Left = 7.3125F;
            this.e_MoneyKindDiv106.MultiLine = false;
            this.e_MoneyKindDiv106.Name = "e_MoneyKindDiv106";
            this.e_MoneyKindDiv106.OutputFormat = resources.GetString("e_MoneyKindDiv106.OutputFormat");
            this.e_MoneyKindDiv106.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv106.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv106.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv106.Text = "1,123,456,789";
            this.e_MoneyKindDiv106.Top = 0.125F;
            this.e_MoneyKindDiv106.Width = 0.72F;
            // 
            // e_MoneyKindDiv105
            // 
            this.e_MoneyKindDiv105.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv105.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv105.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv105.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv105.DataField = "MoneyKindDiv105";
            this.e_MoneyKindDiv105.Height = 0.125F;
            this.e_MoneyKindDiv105.Left = 6.625F;
            this.e_MoneyKindDiv105.MultiLine = false;
            this.e_MoneyKindDiv105.Name = "e_MoneyKindDiv105";
            this.e_MoneyKindDiv105.OutputFormat = resources.GetString("e_MoneyKindDiv105.OutputFormat");
            this.e_MoneyKindDiv105.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv105.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv105.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv105.Text = "1,123,456,789";
            this.e_MoneyKindDiv105.Top = 0.125F;
            this.e_MoneyKindDiv105.Width = 0.72F;
            // 
            // e_MoneyKindDiv101
            // 
            this.e_MoneyKindDiv101.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv101.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv101.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv101.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv101.DataField = "MoneyKindDiv101";
            this.e_MoneyKindDiv101.Height = 0.125F;
            this.e_MoneyKindDiv101.Left = 4.5625F;
            this.e_MoneyKindDiv101.MultiLine = false;
            this.e_MoneyKindDiv101.Name = "e_MoneyKindDiv101";
            this.e_MoneyKindDiv101.OutputFormat = resources.GetString("e_MoneyKindDiv101.OutputFormat");
            this.e_MoneyKindDiv101.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv101.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv101.Text = "1,123,456,789";
            this.e_MoneyKindDiv101.Top = 0.125F;
            this.e_MoneyKindDiv101.Width = 0.72F;
            // 
            // e_LastTimeDemand
            // 
            this.e_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand.DataField = "LastTimeDemand";
            this.e_LastTimeDemand.Height = 0.125F;
            this.e_LastTimeDemand.Left = 3.875F;
            this.e_LastTimeDemand.MultiLine = false;
            this.e_LastTimeDemand.Name = "e_LastTimeDemand";
            this.e_LastTimeDemand.OutputFormat = resources.GetString("e_LastTimeDemand.OutputFormat");
            this.e_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_LastTimeDemand.SummaryGroup = "EmployeeHeader";
            this.e_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_LastTimeDemand.Text = "1,123,456,789";
            this.e_LastTimeDemand.Top = 0.125F;
            this.e_LastTimeDemand.Width = 0.72F;
            // 
            // e_AcpOdrTtl2TmBfBlDmd
            // 
            this.e_AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.e_AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.e_AcpOdrTtl2TmBfBlDmd.Left = 3.1875F;
            this.e_AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.e_AcpOdrTtl2TmBfBlDmd.Name = "e_AcpOdrTtl2TmBfBlDmd";
            this.e_AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("e_AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.e_AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_AcpOdrTtl2TmBfBlDmd.SummaryGroup = "EmployeeHeader";
            this.e_AcpOdrTtl2TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_AcpOdrTtl2TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_AcpOdrTtl2TmBfBlDmd.Text = "1,123,456,789";
            this.e_AcpOdrTtl2TmBfBlDmd.Top = 0.125F;
            this.e_AcpOdrTtl2TmBfBlDmd.Width = 0.72F;
            // 
            // e_MoneyKindDiv102
            // 
            this.e_MoneyKindDiv102.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv102.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv102.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv102.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv102.DataField = "MoneyKindDiv102";
            this.e_MoneyKindDiv102.Height = 0.125F;
            this.e_MoneyKindDiv102.Left = 5.255F;
            this.e_MoneyKindDiv102.MultiLine = false;
            this.e_MoneyKindDiv102.Name = "e_MoneyKindDiv102";
            this.e_MoneyKindDiv102.OutputFormat = resources.GetString("e_MoneyKindDiv102.OutputFormat");
            this.e_MoneyKindDiv102.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv102.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv102.Text = "1,123,456,789";
            this.e_MoneyKindDiv102.Top = 0.125F;
            this.e_MoneyKindDiv102.Width = 0.72F;
            // 
            // e_MoneyKindDiv107
            // 
            this.e_MoneyKindDiv107.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv107.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv107.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv107.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv107.DataField = "MoneyKindDiv107";
            this.e_MoneyKindDiv107.Height = 0.125F;
            this.e_MoneyKindDiv107.Left = 5.9375F;
            this.e_MoneyKindDiv107.MultiLine = false;
            this.e_MoneyKindDiv107.Name = "e_MoneyKindDiv107";
            this.e_MoneyKindDiv107.OutputFormat = resources.GetString("e_MoneyKindDiv107.OutputFormat");
            this.e_MoneyKindDiv107.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv107.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv107.Text = "1,123,456,789";
            this.e_MoneyKindDiv107.Top = 0.125F;
            this.e_MoneyKindDiv107.Width = 0.72F;
            // 
            // e_MoneyKindDiv112
            // 
            this.e_MoneyKindDiv112.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv112.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv112.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv112.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv112.DataField = "MoneyKindDiv112";
            this.e_MoneyKindDiv112.Height = 0.125F;
            this.e_MoneyKindDiv112.Left = 8.6875F;
            this.e_MoneyKindDiv112.MultiLine = false;
            this.e_MoneyKindDiv112.Name = "e_MoneyKindDiv112";
            this.e_MoneyKindDiv112.OutputFormat = resources.GetString("e_MoneyKindDiv112.OutputFormat");
            this.e_MoneyKindDiv112.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv112.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv112.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv112.Text = "1,123,456,789";
            this.e_MoneyKindDiv112.Top = 0.125F;
            this.e_MoneyKindDiv112.Width = 0.72F;
            // 
            // e_ThisTimeFeeDmdNrml
            // 
            this.e_ThisTimeFeeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml.DataField = "ThisTimeFeeDmdNrml";
            this.e_ThisTimeFeeDmdNrml.Height = 0.125F;
            this.e_ThisTimeFeeDmdNrml.Left = 9.375F;
            this.e_ThisTimeFeeDmdNrml.MultiLine = false;
            this.e_ThisTimeFeeDmdNrml.Name = "e_ThisTimeFeeDmdNrml";
            this.e_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("e_ThisTimeFeeDmdNrml.OutputFormat");
            this.e_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeFeeDmdNrml.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeFeeDmdNrml.Text = "1,123,456,789";
            this.e_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.e_ThisTimeFeeDmdNrml.Width = 0.72F;
            // 
            // e_ThisTimeDisDmdNrml
            // 
            this.e_ThisTimeDisDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml.DataField = "ThisTimeDisDmdNrml";
            this.e_ThisTimeDisDmdNrml.Height = 0.125F;
            this.e_ThisTimeDisDmdNrml.Left = 10.0625F;
            this.e_ThisTimeDisDmdNrml.MultiLine = false;
            this.e_ThisTimeDisDmdNrml.Name = "e_ThisTimeDisDmdNrml";
            this.e_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("e_ThisTimeDisDmdNrml.OutputFormat");
            this.e_ThisTimeDisDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeDisDmdNrml.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeDisDmdNrml.Text = "1,123,456,789";
            this.e_ThisTimeDisDmdNrml.Top = 0.125F;
            this.e_ThisTimeDisDmdNrml.Width = 0.72F;
            // 
            // e_CollectRate
            // 
            this.e_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.e_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.e_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.e_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.e_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate.Height = 0.125F;
            this.e_CollectRate.Left = 8.791668F;
            this.e_CollectRate.MultiLine = false;
            this.e_CollectRate.Name = "e_CollectRate";
            this.e_CollectRate.OutputFormat = resources.GetString("e_CollectRate.OutputFormat");
            this.e_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_CollectRate.Text = "123.00";
            this.e_CollectRate.Top = 0F;
            this.e_CollectRate.Width = 0.5F;
            // 
            // e_CollectDemand
            // 
            this.e_CollectDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.e_CollectDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.e_CollectDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand.Border.RightColor = System.Drawing.Color.Black;
            this.e_CollectDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand.Border.TopColor = System.Drawing.Color.Black;
            this.e_CollectDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand.DataField = "CollectDemand";
            this.e_CollectDemand.Height = 0.125F;
            this.e_CollectDemand.Left = 0F;
            this.e_CollectDemand.Name = "e_CollectDemand";
            this.e_CollectDemand.OutputFormat = resources.GetString("e_CollectDemand.OutputFormat");
            this.e_CollectDemand.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.e_CollectDemand.SummaryGroup = "EmployeeHeader";
            this.e_CollectDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_CollectDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_CollectDemand.Text = null;
            this.e_CollectDemand.Top = 0F;
            this.e_CollectDemand.Visible = false;
            this.e_CollectDemand.Width = 0.375F;
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
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 9.281251F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.textBox3.Text = "%";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.125F;
            // 
            // textBox_emp
            // 
            this.textBox_emp.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Height = 0.125F;
            this.textBox_emp.Left = 2.5625F;
            this.textBox_emp.Name = "textBox_emp";
            this.textBox_emp.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox_emp.Text = null;
            this.textBox_emp.Top = 0.25F;
            this.textBox_emp.Visible = false;
            this.textBox_emp.Width = 0.375F;
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
            this.g_DemandBalance,
            this.g_ThisTimeDmdNrml,
            this.g_ThisTimeTtlBlcDmd,
            this.g_OfsThisTimeSales,
            this.g_ThisSalesPricRgdsDis,
            this.g_NetSales,
            this.g_OfsThisSalesTax,
            this.g_OfsThisSalesSum,
            this.g_AfCalDemandPrice,
            this.g_SaleslSlipCount,
            this.line2,
            this.g_AcpOdrTtl3TmBfBlDmd,
            this.g_AcpOdrTtl2TmBfBlDmd,
            this.g_LastTimeDemand,
            this.g_MoneyKindDiv101,
            this.g_MoneyKindDiv102,
            this.g_MoneyKindDiv107,
            this.g_MoneyKindDiv105,
            this.g_MoneyKindDiv106,
            this.g_MoneyKindDiv109,
            this.g_MoneyKindDiv112,
            this.g_ThisTimeFeeDmdNrml,
            this.g_ThisTimeDisDmdNrml,
            this.g_CollectRate,
            this.g_CollectDemand,
            this.textBox5});
            this.GrandTotalFooter.Height = 0.3645833F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.Label109.Left = 1.0625F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label109.Text = "総合計";
            this.Label109.Top = 0F;
            this.Label109.Width = 0.5625F;
            // 
            // g_DemandBalance
            // 
            this.g_DemandBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.g_DemandBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.g_DemandBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance.Border.RightColor = System.Drawing.Color.Black;
            this.g_DemandBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance.Border.TopColor = System.Drawing.Color.Black;
            this.g_DemandBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance.DataField = "DemandBalance";
            this.g_DemandBalance.Height = 0.125F;
            this.g_DemandBalance.Left = 2.5F;
            this.g_DemandBalance.MultiLine = false;
            this.g_DemandBalance.Name = "g_DemandBalance";
            this.g_DemandBalance.OutputFormat = resources.GetString("g_DemandBalance.OutputFormat");
            this.g_DemandBalance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_DemandBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_DemandBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_DemandBalance.Text = "1,123,456,789";
            this.g_DemandBalance.Top = 0F;
            this.g_DemandBalance.Width = 0.72F;
            // 
            // g_ThisTimeDmdNrml
            // 
            this.g_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.g_ThisTimeDmdNrml.Height = 0.125F;
            this.g_ThisTimeDmdNrml.Left = 3.1875F;
            this.g_ThisTimeDmdNrml.MultiLine = false;
            this.g_ThisTimeDmdNrml.Name = "g_ThisTimeDmdNrml";
            this.g_ThisTimeDmdNrml.OutputFormat = resources.GetString("g_ThisTimeDmdNrml.OutputFormat");
            this.g_ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDmdNrml.Text = "1,123,456,789";
            this.g_ThisTimeDmdNrml.Top = 0F;
            this.g_ThisTimeDmdNrml.Width = 0.72F;
            // 
            // g_ThisTimeTtlBlcDmd
            // 
            this.g_ThisTimeTtlBlcDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd.DataField = "ThisTimeTtlBlcDmd";
            this.g_ThisTimeTtlBlcDmd.Height = 0.125F;
            this.g_ThisTimeTtlBlcDmd.Left = 3.875F;
            this.g_ThisTimeTtlBlcDmd.MultiLine = false;
            this.g_ThisTimeTtlBlcDmd.Name = "g_ThisTimeTtlBlcDmd";
            this.g_ThisTimeTtlBlcDmd.OutputFormat = resources.GetString("g_ThisTimeTtlBlcDmd.OutputFormat");
            this.g_ThisTimeTtlBlcDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeTtlBlcDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeTtlBlcDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeTtlBlcDmd.Text = "1,123,456,789";
            this.g_ThisTimeTtlBlcDmd.Top = 0F;
            this.g_ThisTimeTtlBlcDmd.Width = 0.72F;
            // 
            // g_OfsThisTimeSales
            // 
            this.g_OfsThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales.DataField = "ThisTimeSales";
            this.g_OfsThisTimeSales.Height = 0.125F;
            this.g_OfsThisTimeSales.Left = 4.5625F;
            this.g_OfsThisTimeSales.MultiLine = false;
            this.g_OfsThisTimeSales.Name = "g_OfsThisTimeSales";
            this.g_OfsThisTimeSales.OutputFormat = resources.GetString("g_OfsThisTimeSales.OutputFormat");
            this.g_OfsThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_OfsThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OfsThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OfsThisTimeSales.Text = "1,123,456,789";
            this.g_OfsThisTimeSales.Top = 0F;
            this.g_OfsThisTimeSales.Width = 0.72F;
            // 
            // g_ThisSalesPricRgdsDis
            // 
            this.g_ThisSalesPricRgdsDis.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis.DataField = "ThisSalesPricRgdsDis";
            this.g_ThisSalesPricRgdsDis.Height = 0.125F;
            this.g_ThisSalesPricRgdsDis.Left = 5.255F;
            this.g_ThisSalesPricRgdsDis.MultiLine = false;
            this.g_ThisSalesPricRgdsDis.Name = "g_ThisSalesPricRgdsDis";
            this.g_ThisSalesPricRgdsDis.OutputFormat = resources.GetString("g_ThisSalesPricRgdsDis.OutputFormat");
            this.g_ThisSalesPricRgdsDis.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisSalesPricRgdsDis.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisSalesPricRgdsDis.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisSalesPricRgdsDis.Text = "1,123,456,789";
            this.g_ThisSalesPricRgdsDis.Top = 0F;
            this.g_ThisSalesPricRgdsDis.Width = 0.72F;
            // 
            // g_NetSales
            // 
            this.g_NetSales.Border.BottomColor = System.Drawing.Color.Black;
            this.g_NetSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales.Border.LeftColor = System.Drawing.Color.Black;
            this.g_NetSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales.Border.RightColor = System.Drawing.Color.Black;
            this.g_NetSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales.Border.TopColor = System.Drawing.Color.Black;
            this.g_NetSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales.DataField = "NetSales";
            this.g_NetSales.Height = 0.125F;
            this.g_NetSales.Left = 5.9375F;
            this.g_NetSales.MultiLine = false;
            this.g_NetSales.Name = "g_NetSales";
            this.g_NetSales.OutputFormat = resources.GetString("g_NetSales.OutputFormat");
            this.g_NetSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_NetSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_NetSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_NetSales.Text = "1,123,456,789";
            this.g_NetSales.Top = 0F;
            this.g_NetSales.Width = 0.72F;
            // 
            // g_OfsThisSalesTax
            // 
            this.g_OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.g_OfsThisSalesTax.Height = 0.125F;
            this.g_OfsThisSalesTax.Left = 6.625F;
            this.g_OfsThisSalesTax.MultiLine = false;
            this.g_OfsThisSalesTax.Name = "g_OfsThisSalesTax";
            this.g_OfsThisSalesTax.OutputFormat = resources.GetString("g_OfsThisSalesTax.OutputFormat");
            this.g_OfsThisSalesTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_OfsThisSalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OfsThisSalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OfsThisSalesTax.Text = "1,123,456,789";
            this.g_OfsThisSalesTax.Top = 0F;
            this.g_OfsThisSalesTax.Width = 0.72F;
            // 
            // g_OfsThisSalesSum
            // 
            this.g_OfsThisSalesSum.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum.Border.RightColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum.Border.TopColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum.DataField = "OfsThisSalesSum";
            this.g_OfsThisSalesSum.Height = 0.125F;
            this.g_OfsThisSalesSum.Left = 7.3125F;
            this.g_OfsThisSalesSum.MultiLine = false;
            this.g_OfsThisSalesSum.Name = "g_OfsThisSalesSum";
            this.g_OfsThisSalesSum.OutputFormat = resources.GetString("g_OfsThisSalesSum.OutputFormat");
            this.g_OfsThisSalesSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_OfsThisSalesSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OfsThisSalesSum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OfsThisSalesSum.Text = "1,123,456,789";
            this.g_OfsThisSalesSum.Top = 0F;
            this.g_OfsThisSalesSum.Width = 0.72F;
            // 
            // g_AfCalDemandPrice
            // 
            this.g_AfCalDemandPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice.Border.RightColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice.Border.TopColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice.DataField = "AfCalDemandPrice";
            this.g_AfCalDemandPrice.Height = 0.125F;
            this.g_AfCalDemandPrice.Left = 8.010417F;
            this.g_AfCalDemandPrice.MultiLine = false;
            this.g_AfCalDemandPrice.Name = "g_AfCalDemandPrice";
            this.g_AfCalDemandPrice.OutputFormat = resources.GetString("g_AfCalDemandPrice.OutputFormat");
            this.g_AfCalDemandPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_AfCalDemandPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_AfCalDemandPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_AfCalDemandPrice.Text = "1,123,456,789";
            this.g_AfCalDemandPrice.Top = 0F;
            this.g_AfCalDemandPrice.Width = 0.72F;
            // 
            // g_SaleslSlipCount
            // 
            this.g_SaleslSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount.DataField = "SaleslSlipCount";
            this.g_SaleslSlipCount.Height = 0.125F;
            this.g_SaleslSlipCount.Left = 9.499F;
            this.g_SaleslSlipCount.MultiLine = false;
            this.g_SaleslSlipCount.Name = "g_SaleslSlipCount";
            this.g_SaleslSlipCount.OutputFormat = resources.GetString("g_SaleslSlipCount.OutputFormat");
            this.g_SaleslSlipCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_SaleslSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_SaleslSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_SaleslSlipCount.Text = "123,456";
            this.g_SaleslSlipCount.Top = 0F;
            this.g_SaleslSlipCount.Width = 0.605F;
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
            // g_AcpOdrTtl3TmBfBlDmd
            // 
            this.g_AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.g_AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.g_AcpOdrTtl3TmBfBlDmd.Left = 2.5F;
            this.g_AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.g_AcpOdrTtl3TmBfBlDmd.Name = "g_AcpOdrTtl3TmBfBlDmd";
            this.g_AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("g_AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.g_AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_AcpOdrTtl3TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_AcpOdrTtl3TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_AcpOdrTtl3TmBfBlDmd.Text = "1,123,456,789";
            this.g_AcpOdrTtl3TmBfBlDmd.Top = 0.125F;
            this.g_AcpOdrTtl3TmBfBlDmd.Width = 0.72F;
            // 
            // g_AcpOdrTtl2TmBfBlDmd
            // 
            this.g_AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.g_AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.g_AcpOdrTtl2TmBfBlDmd.Left = 3.1875F;
            this.g_AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.g_AcpOdrTtl2TmBfBlDmd.Name = "g_AcpOdrTtl2TmBfBlDmd";
            this.g_AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("g_AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.g_AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_AcpOdrTtl2TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_AcpOdrTtl2TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_AcpOdrTtl2TmBfBlDmd.Text = "1,123,456,789";
            this.g_AcpOdrTtl2TmBfBlDmd.Top = 0.125F;
            this.g_AcpOdrTtl2TmBfBlDmd.Width = 0.72F;
            // 
            // g_LastTimeDemand
            // 
            this.g_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand.DataField = "LastTimeDemand";
            this.g_LastTimeDemand.Height = 0.125F;
            this.g_LastTimeDemand.Left = 3.875F;
            this.g_LastTimeDemand.MultiLine = false;
            this.g_LastTimeDemand.Name = "g_LastTimeDemand";
            this.g_LastTimeDemand.OutputFormat = resources.GetString("g_LastTimeDemand.OutputFormat");
            this.g_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_LastTimeDemand.Text = "1,123,456,789";
            this.g_LastTimeDemand.Top = 0.125F;
            this.g_LastTimeDemand.Width = 0.72F;
            // 
            // g_MoneyKindDiv101
            // 
            this.g_MoneyKindDiv101.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv101.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv101.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv101.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv101.DataField = "MoneyKindDiv101";
            this.g_MoneyKindDiv101.Height = 0.125F;
            this.g_MoneyKindDiv101.Left = 4.5625F;
            this.g_MoneyKindDiv101.MultiLine = false;
            this.g_MoneyKindDiv101.Name = "g_MoneyKindDiv101";
            this.g_MoneyKindDiv101.OutputFormat = resources.GetString("g_MoneyKindDiv101.OutputFormat");
            this.g_MoneyKindDiv101.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv101.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv101.Text = "1,123,456,789";
            this.g_MoneyKindDiv101.Top = 0.125F;
            this.g_MoneyKindDiv101.Width = 0.72F;
            // 
            // g_MoneyKindDiv102
            // 
            this.g_MoneyKindDiv102.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv102.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv102.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv102.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv102.DataField = "MoneyKindDiv102";
            this.g_MoneyKindDiv102.Height = 0.125F;
            this.g_MoneyKindDiv102.Left = 5.255F;
            this.g_MoneyKindDiv102.MultiLine = false;
            this.g_MoneyKindDiv102.Name = "g_MoneyKindDiv102";
            this.g_MoneyKindDiv102.OutputFormat = resources.GetString("g_MoneyKindDiv102.OutputFormat");
            this.g_MoneyKindDiv102.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv102.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv102.Text = "1,123,456,789";
            this.g_MoneyKindDiv102.Top = 0.125F;
            this.g_MoneyKindDiv102.Width = 0.72F;
            // 
            // g_MoneyKindDiv107
            // 
            this.g_MoneyKindDiv107.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv107.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv107.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv107.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv107.DataField = "MoneyKindDiv107";
            this.g_MoneyKindDiv107.Height = 0.125F;
            this.g_MoneyKindDiv107.Left = 5.9375F;
            this.g_MoneyKindDiv107.MultiLine = false;
            this.g_MoneyKindDiv107.Name = "g_MoneyKindDiv107";
            this.g_MoneyKindDiv107.OutputFormat = resources.GetString("g_MoneyKindDiv107.OutputFormat");
            this.g_MoneyKindDiv107.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv107.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv107.Text = "1,123,456,789";
            this.g_MoneyKindDiv107.Top = 0.125F;
            this.g_MoneyKindDiv107.Width = 0.72F;
            // 
            // g_MoneyKindDiv105
            // 
            this.g_MoneyKindDiv105.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv105.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv105.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv105.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv105.DataField = "MoneyKindDiv105";
            this.g_MoneyKindDiv105.Height = 0.125F;
            this.g_MoneyKindDiv105.Left = 6.625F;
            this.g_MoneyKindDiv105.MultiLine = false;
            this.g_MoneyKindDiv105.Name = "g_MoneyKindDiv105";
            this.g_MoneyKindDiv105.OutputFormat = resources.GetString("g_MoneyKindDiv105.OutputFormat");
            this.g_MoneyKindDiv105.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv105.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv105.Text = "1,123,456,789";
            this.g_MoneyKindDiv105.Top = 0.125F;
            this.g_MoneyKindDiv105.Width = 0.72F;
            // 
            // g_MoneyKindDiv106
            // 
            this.g_MoneyKindDiv106.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv106.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv106.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv106.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv106.DataField = "MoneyKindDiv106";
            this.g_MoneyKindDiv106.Height = 0.125F;
            this.g_MoneyKindDiv106.Left = 7.3125F;
            this.g_MoneyKindDiv106.MultiLine = false;
            this.g_MoneyKindDiv106.Name = "g_MoneyKindDiv106";
            this.g_MoneyKindDiv106.OutputFormat = resources.GetString("g_MoneyKindDiv106.OutputFormat");
            this.g_MoneyKindDiv106.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv106.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv106.Text = "1,123,456,789";
            this.g_MoneyKindDiv106.Top = 0.125F;
            this.g_MoneyKindDiv106.Width = 0.72F;
            // 
            // g_MoneyKindDiv109
            // 
            this.g_MoneyKindDiv109.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv109.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv109.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv109.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv109.DataField = "MoneyKindDiv109";
            this.g_MoneyKindDiv109.Height = 0.125F;
            this.g_MoneyKindDiv109.Left = 8.010417F;
            this.g_MoneyKindDiv109.MultiLine = false;
            this.g_MoneyKindDiv109.Name = "g_MoneyKindDiv109";
            this.g_MoneyKindDiv109.OutputFormat = resources.GetString("g_MoneyKindDiv109.OutputFormat");
            this.g_MoneyKindDiv109.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv109.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv109.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv109.Text = "1,123,456,789";
            this.g_MoneyKindDiv109.Top = 0.125F;
            this.g_MoneyKindDiv109.Width = 0.72F;
            // 
            // g_MoneyKindDiv112
            // 
            this.g_MoneyKindDiv112.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv112.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv112.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv112.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv112.DataField = "MoneyKindDiv112";
            this.g_MoneyKindDiv112.Height = 0.125F;
            this.g_MoneyKindDiv112.Left = 8.6875F;
            this.g_MoneyKindDiv112.MultiLine = false;
            this.g_MoneyKindDiv112.Name = "g_MoneyKindDiv112";
            this.g_MoneyKindDiv112.OutputFormat = resources.GetString("g_MoneyKindDiv112.OutputFormat");
            this.g_MoneyKindDiv112.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv112.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv112.Text = "1,123,456,789";
            this.g_MoneyKindDiv112.Top = 0.125F;
            this.g_MoneyKindDiv112.Width = 0.72F;
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
            this.g_ThisTimeFeeDmdNrml.Left = 9.375F;
            this.g_ThisTimeFeeDmdNrml.MultiLine = false;
            this.g_ThisTimeFeeDmdNrml.Name = "g_ThisTimeFeeDmdNrml";
            this.g_ThisTimeFeeDmdNrml.OutputFormat = resources.GetString("g_ThisTimeFeeDmdNrml.OutputFormat");
            this.g_ThisTimeFeeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeFeeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeFeeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeFeeDmdNrml.Text = "1,123,456,789";
            this.g_ThisTimeFeeDmdNrml.Top = 0.125F;
            this.g_ThisTimeFeeDmdNrml.Width = 0.72F;
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
            this.g_ThisTimeDisDmdNrml.Left = 10.0625F;
            this.g_ThisTimeDisDmdNrml.MultiLine = false;
            this.g_ThisTimeDisDmdNrml.Name = "g_ThisTimeDisDmdNrml";
            this.g_ThisTimeDisDmdNrml.OutputFormat = resources.GetString("g_ThisTimeDisDmdNrml.OutputFormat");
            this.g_ThisTimeDisDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeDisDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDisDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDisDmdNrml.Text = "1,123,456,789";
            this.g_ThisTimeDisDmdNrml.Top = 0.125F;
            this.g_ThisTimeDisDmdNrml.Width = 0.72F;
            // 
            // g_CollectRate
            // 
            this.g_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate.Height = 0.125F;
            this.g_CollectRate.Left = 8.791668F;
            this.g_CollectRate.MultiLine = false;
            this.g_CollectRate.Name = "g_CollectRate";
            this.g_CollectRate.OutputFormat = resources.GetString("g_CollectRate.OutputFormat");
            this.g_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_CollectRate.Text = "123.00";
            this.g_CollectRate.Top = 0F;
            this.g_CollectRate.Width = 0.5F;
            // 
            // g_CollectDemand
            // 
            this.g_CollectDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CollectDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CollectDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand.Border.RightColor = System.Drawing.Color.Black;
            this.g_CollectDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand.Border.TopColor = System.Drawing.Color.Black;
            this.g_CollectDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand.DataField = "CollectDemand";
            this.g_CollectDemand.Height = 0.125F;
            this.g_CollectDemand.Left = 0F;
            this.g_CollectDemand.Name = "g_CollectDemand";
            this.g_CollectDemand.OutputFormat = resources.GetString("g_CollectDemand.OutputFormat");
            this.g_CollectDemand.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.g_CollectDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CollectDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CollectDemand.Text = null;
            this.g_CollectDemand.Top = 0F;
            this.g_CollectDemand.Visible = false;
            this.g_CollectDemand.Width = 0.4375F;
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
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 9.281251F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.textBox5.Text = "%";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.125F;
            // 
            // EmployeeHeader2
            // 
            this.EmployeeHeader2.Height = 0F;
            this.EmployeeHeader2.Name = "EmployeeHeader2";
            this.EmployeeHeader2.Visible = false;
            // 
            // EmployeeFooter2
            // 
            this.EmployeeFooter2.CanShrink = true;
            this.EmployeeFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.e_ThisSalesPricRgdsDis2,
            this.e_AfCalDemandPrice2,
            this.e_OfsThisSalesSum2,
            this.e_OfsThisSalesTax2,
            this.e_OfsThisTimeSales2,
            this.e_ThisTimeTtlBlcDmd2,
            this.e_ThisTimeDmdNrml2,
            this.e_DemandBalance2,
            this.e_SaleslSlipCount2,
            this.e_NetSales2,
            this.textBox16,
            this.e_AcpOdrTtl3TmBfBlDmd2,
            this.e_MoneyKindDiv1092,
            this.e_MoneyKindDiv1062,
            this.e_MoneyKindDiv1052,
            this.e_MoneyKindDiv1012,
            this.e_LastTimeDemand2,
            this.e_AcpOdrTtl2TmBfBlDmd2,
            this.e_MoneyKindDiv1022,
            this.e_MoneyKindDiv1072,
            this.e_MoneyKindDiv1122,
            this.e_ThisTimeFeeDmdNrml2,
            this.e_ThisTimeDisDmdNrml2,
            this.e_CollectRate2,
            this.e_CollectDemand2,
            this.textBox39,
            this.textBox_emp2,
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
            this.textBox58,
            this.s_TaxTotalTitleTaxRate1,
            this.s_TaxTotalTitleTaxRate2,
            this.s_TaxTotalTitleOther,
            this.line4,
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            this.label17,
            this.textBox25,
            this.textBox26,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38});
            this.EmployeeFooter2.Height = 0.875F;
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            this.EmployeeFooter2.KeepTogether = true;
            this.EmployeeFooter2.Name = "EmployeeFooter2";
            this.EmployeeFooter2.Visible = false;
            this.EmployeeFooter2.BeforePrint += new System.EventHandler(this.EmployeeFooter2_BeforePrint);
            // 
            // e_ThisSalesPricRgdsDis2
            // 
            this.e_ThisSalesPricRgdsDis2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis2.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis2.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisSalesPricRgdsDis2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisSalesPricRgdsDis2.DataField = "ThisSalesPricRgdsDis";
            this.e_ThisSalesPricRgdsDis2.Height = 0.125F;
            this.e_ThisSalesPricRgdsDis2.Left = 5.255F;
            this.e_ThisSalesPricRgdsDis2.MultiLine = false;
            this.e_ThisSalesPricRgdsDis2.Name = "e_ThisSalesPricRgdsDis2";
            this.e_ThisSalesPricRgdsDis2.OutputFormat = resources.GetString("e_ThisSalesPricRgdsDis2.OutputFormat");
            this.e_ThisSalesPricRgdsDis2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisSalesPricRgdsDis2.SummaryGroup = "EmployeeHeader";
            this.e_ThisSalesPricRgdsDis2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisSalesPricRgdsDis2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisSalesPricRgdsDis2.Text = "1,123,456,789";
            this.e_ThisSalesPricRgdsDis2.Top = 0F;
            this.e_ThisSalesPricRgdsDis2.Width = 0.72F;
            // 
            // e_AfCalDemandPrice2
            // 
            this.e_AfCalDemandPrice2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice2.Border.RightColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice2.Border.TopColor = System.Drawing.Color.Black;
            this.e_AfCalDemandPrice2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AfCalDemandPrice2.DataField = "AfCalDemandPrice";
            this.e_AfCalDemandPrice2.Height = 0.125F;
            this.e_AfCalDemandPrice2.Left = 8F;
            this.e_AfCalDemandPrice2.MultiLine = false;
            this.e_AfCalDemandPrice2.Name = "e_AfCalDemandPrice2";
            this.e_AfCalDemandPrice2.OutputFormat = resources.GetString("e_AfCalDemandPrice2.OutputFormat");
            this.e_AfCalDemandPrice2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_AfCalDemandPrice2.SummaryGroup = "EmployeeHeader";
            this.e_AfCalDemandPrice2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_AfCalDemandPrice2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_AfCalDemandPrice2.Text = "1,123,456,789";
            this.e_AfCalDemandPrice2.Top = 0F;
            this.e_AfCalDemandPrice2.Width = 0.72F;
            // 
            // e_OfsThisSalesSum2
            // 
            this.e_OfsThisSalesSum2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum2.Border.RightColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum2.Border.TopColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesSum2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesSum2.DataField = "OfsThisSalesSum";
            this.e_OfsThisSalesSum2.Height = 0.125F;
            this.e_OfsThisSalesSum2.Left = 7.3125F;
            this.e_OfsThisSalesSum2.MultiLine = false;
            this.e_OfsThisSalesSum2.Name = "e_OfsThisSalesSum2";
            this.e_OfsThisSalesSum2.OutputFormat = resources.GetString("e_OfsThisSalesSum2.OutputFormat");
            this.e_OfsThisSalesSum2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_OfsThisSalesSum2.SummaryGroup = "EmployeeHeader";
            this.e_OfsThisSalesSum2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_OfsThisSalesSum2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_OfsThisSalesSum2.Text = "1,123,456,789";
            this.e_OfsThisSalesSum2.Top = 0F;
            this.e_OfsThisSalesSum2.Width = 0.72F;
            // 
            // e_OfsThisSalesTax2
            // 
            this.e_OfsThisSalesTax2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax2.Border.RightColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax2.Border.TopColor = System.Drawing.Color.Black;
            this.e_OfsThisSalesTax2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisSalesTax2.DataField = "OfsThisSalesTax";
            this.e_OfsThisSalesTax2.Height = 0.125F;
            this.e_OfsThisSalesTax2.Left = 6.625F;
            this.e_OfsThisSalesTax2.MultiLine = false;
            this.e_OfsThisSalesTax2.Name = "e_OfsThisSalesTax2";
            this.e_OfsThisSalesTax2.OutputFormat = resources.GetString("e_OfsThisSalesTax2.OutputFormat");
            this.e_OfsThisSalesTax2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_OfsThisSalesTax2.SummaryGroup = "EmployeeHeader";
            this.e_OfsThisSalesTax2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_OfsThisSalesTax2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_OfsThisSalesTax2.Text = "1,123,456,789";
            this.e_OfsThisSalesTax2.Top = 0F;
            this.e_OfsThisSalesTax2.Width = 0.72F;
            // 
            // e_OfsThisTimeSales2
            // 
            this.e_OfsThisTimeSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales2.Border.RightColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales2.Border.TopColor = System.Drawing.Color.Black;
            this.e_OfsThisTimeSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_OfsThisTimeSales2.DataField = "ThisTimeSales";
            this.e_OfsThisTimeSales2.Height = 0.125F;
            this.e_OfsThisTimeSales2.Left = 4.5625F;
            this.e_OfsThisTimeSales2.MultiLine = false;
            this.e_OfsThisTimeSales2.Name = "e_OfsThisTimeSales2";
            this.e_OfsThisTimeSales2.OutputFormat = resources.GetString("e_OfsThisTimeSales2.OutputFormat");
            this.e_OfsThisTimeSales2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_OfsThisTimeSales2.SummaryGroup = "EmployeeHeader";
            this.e_OfsThisTimeSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_OfsThisTimeSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_OfsThisTimeSales2.Text = "1,123,456,789";
            this.e_OfsThisTimeSales2.Top = 0F;
            this.e_OfsThisTimeSales2.Width = 0.72F;
            // 
            // e_ThisTimeTtlBlcDmd2
            // 
            this.e_ThisTimeTtlBlcDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeTtlBlcDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeTtlBlcDmd2.DataField = "ThisTimeTtlBlcDmd";
            this.e_ThisTimeTtlBlcDmd2.Height = 0.125F;
            this.e_ThisTimeTtlBlcDmd2.Left = 3.875F;
            this.e_ThisTimeTtlBlcDmd2.MultiLine = false;
            this.e_ThisTimeTtlBlcDmd2.Name = "e_ThisTimeTtlBlcDmd2";
            this.e_ThisTimeTtlBlcDmd2.OutputFormat = resources.GetString("e_ThisTimeTtlBlcDmd2.OutputFormat");
            this.e_ThisTimeTtlBlcDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeTtlBlcDmd2.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeTtlBlcDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeTtlBlcDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeTtlBlcDmd2.Text = "1,123,456,789";
            this.e_ThisTimeTtlBlcDmd2.Top = 0F;
            this.e_ThisTimeTtlBlcDmd2.Width = 0.72F;
            // 
            // e_ThisTimeDmdNrml2
            // 
            this.e_ThisTimeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDmdNrml2.DataField = "ThisTimeDmdNrml";
            this.e_ThisTimeDmdNrml2.Height = 0.125F;
            this.e_ThisTimeDmdNrml2.Left = 3.1875F;
            this.e_ThisTimeDmdNrml2.MultiLine = false;
            this.e_ThisTimeDmdNrml2.Name = "e_ThisTimeDmdNrml2";
            this.e_ThisTimeDmdNrml2.OutputFormat = resources.GetString("e_ThisTimeDmdNrml2.OutputFormat");
            this.e_ThisTimeDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeDmdNrml2.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeDmdNrml2.Text = "1,123,456,789";
            this.e_ThisTimeDmdNrml2.Top = 0F;
            this.e_ThisTimeDmdNrml2.Width = 0.72F;
            // 
            // e_DemandBalance2
            // 
            this.e_DemandBalance2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_DemandBalance2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_DemandBalance2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance2.Border.RightColor = System.Drawing.Color.Black;
            this.e_DemandBalance2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance2.Border.TopColor = System.Drawing.Color.Black;
            this.e_DemandBalance2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_DemandBalance2.DataField = "DemandBalance";
            this.e_DemandBalance2.Height = 0.125F;
            this.e_DemandBalance2.Left = 2.5F;
            this.e_DemandBalance2.MultiLine = false;
            this.e_DemandBalance2.Name = "e_DemandBalance2";
            this.e_DemandBalance2.OutputFormat = resources.GetString("e_DemandBalance2.OutputFormat");
            this.e_DemandBalance2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_DemandBalance2.SummaryGroup = "EmployeeHeader";
            this.e_DemandBalance2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_DemandBalance2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_DemandBalance2.Text = "1,123,456,789";
            this.e_DemandBalance2.Top = 0F;
            this.e_DemandBalance2.Width = 0.72F;
            // 
            // e_SaleslSlipCount2
            // 
            this.e_SaleslSlipCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount2.Border.RightColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount2.Border.TopColor = System.Drawing.Color.Black;
            this.e_SaleslSlipCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_SaleslSlipCount2.DataField = "SaleslSlipCount";
            this.e_SaleslSlipCount2.Height = 0.125F;
            this.e_SaleslSlipCount2.Left = 9.499F;
            this.e_SaleslSlipCount2.MultiLine = false;
            this.e_SaleslSlipCount2.Name = "e_SaleslSlipCount2";
            this.e_SaleslSlipCount2.OutputFormat = resources.GetString("e_SaleslSlipCount2.OutputFormat");
            this.e_SaleslSlipCount2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_SaleslSlipCount2.SummaryGroup = "EmployeeHeader";
            this.e_SaleslSlipCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_SaleslSlipCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_SaleslSlipCount2.Text = "123,456";
            this.e_SaleslSlipCount2.Top = 0F;
            this.e_SaleslSlipCount2.Width = 0.605F;
            // 
            // e_NetSales2
            // 
            this.e_NetSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_NetSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_NetSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales2.Border.RightColor = System.Drawing.Color.Black;
            this.e_NetSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales2.Border.TopColor = System.Drawing.Color.Black;
            this.e_NetSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_NetSales2.DataField = "NetSales";
            this.e_NetSales2.Height = 0.125F;
            this.e_NetSales2.Left = 5.9375F;
            this.e_NetSales2.MultiLine = false;
            this.e_NetSales2.Name = "e_NetSales2";
            this.e_NetSales2.OutputFormat = resources.GetString("e_NetSales2.OutputFormat");
            this.e_NetSales2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_NetSales2.SummaryGroup = "EmployeeHeader";
            this.e_NetSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_NetSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_NetSales2.Text = "1,123,456,789";
            this.e_NetSales2.Top = 0F;
            this.e_NetSales2.Width = 0.72F;
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
            this.textBox16.Left = 1.0625F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox16.Text = "担当者計";
            this.textBox16.Top = 0F;
            this.textBox16.Width = 0.6875F;
            // 
            // e_AcpOdrTtl3TmBfBlDmd2
            // 
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl3TmBfBlDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl3TmBfBlDmd2.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.e_AcpOdrTtl3TmBfBlDmd2.Height = 0.125F;
            this.e_AcpOdrTtl3TmBfBlDmd2.Left = 2.5F;
            this.e_AcpOdrTtl3TmBfBlDmd2.MultiLine = false;
            this.e_AcpOdrTtl3TmBfBlDmd2.Name = "e_AcpOdrTtl3TmBfBlDmd2";
            this.e_AcpOdrTtl3TmBfBlDmd2.OutputFormat = resources.GetString("e_AcpOdrTtl3TmBfBlDmd2.OutputFormat");
            this.e_AcpOdrTtl3TmBfBlDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_AcpOdrTtl3TmBfBlDmd2.SummaryGroup = "EmployeeHeader";
            this.e_AcpOdrTtl3TmBfBlDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_AcpOdrTtl3TmBfBlDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_AcpOdrTtl3TmBfBlDmd2.Text = "1,123,456,789";
            this.e_AcpOdrTtl3TmBfBlDmd2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_AcpOdrTtl3TmBfBlDmd2.Width = 0.72F;
            // 
            // e_MoneyKindDiv1092
            // 
            this.e_MoneyKindDiv1092.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1092.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1092.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1092.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1092.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1092.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1092.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1092.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1092.DataField = "MoneyKindDiv109";
            this.e_MoneyKindDiv1092.Height = 0.125F;
            this.e_MoneyKindDiv1092.Left = 8F;
            this.e_MoneyKindDiv1092.MultiLine = false;
            this.e_MoneyKindDiv1092.Name = "e_MoneyKindDiv1092";
            this.e_MoneyKindDiv1092.OutputFormat = "#,##0";
            this.e_MoneyKindDiv1092.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1092.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1092.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1092.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1092.Text = "1,123,456,789";
            this.e_MoneyKindDiv1092.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1092.Width = 0.72F;
            // 
            // e_MoneyKindDiv1062
            // 
            this.e_MoneyKindDiv1062.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1062.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1062.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1062.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1062.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1062.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1062.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1062.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1062.DataField = "MoneyKindDiv106";
            this.e_MoneyKindDiv1062.Height = 0.125F;
            this.e_MoneyKindDiv1062.Left = 7.3125F;
            this.e_MoneyKindDiv1062.MultiLine = false;
            this.e_MoneyKindDiv1062.Name = "e_MoneyKindDiv1062";
            this.e_MoneyKindDiv1062.OutputFormat = resources.GetString("e_MoneyKindDiv1062.OutputFormat");
            this.e_MoneyKindDiv1062.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1062.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1062.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1062.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1062.Text = "1,123,456,789";
            this.e_MoneyKindDiv1062.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1062.Width = 0.72F;
            // 
            // e_MoneyKindDiv1052
            // 
            this.e_MoneyKindDiv1052.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1052.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1052.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1052.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1052.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1052.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1052.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1052.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1052.DataField = "MoneyKindDiv105";
            this.e_MoneyKindDiv1052.Height = 0.125F;
            this.e_MoneyKindDiv1052.Left = 6.625F;
            this.e_MoneyKindDiv1052.MultiLine = false;
            this.e_MoneyKindDiv1052.Name = "e_MoneyKindDiv1052";
            this.e_MoneyKindDiv1052.OutputFormat = resources.GetString("e_MoneyKindDiv1052.OutputFormat");
            this.e_MoneyKindDiv1052.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1052.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1052.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1052.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1052.Text = "1,123,456,789";
            this.e_MoneyKindDiv1052.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1052.Width = 0.72F;
            // 
            // e_MoneyKindDiv1012
            // 
            this.e_MoneyKindDiv1012.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1012.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1012.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1012.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1012.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1012.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1012.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1012.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1012.DataField = "MoneyKindDiv101";
            this.e_MoneyKindDiv1012.Height = 0.125F;
            this.e_MoneyKindDiv1012.Left = 4.5625F;
            this.e_MoneyKindDiv1012.MultiLine = false;
            this.e_MoneyKindDiv1012.Name = "e_MoneyKindDiv1012";
            this.e_MoneyKindDiv1012.OutputFormat = resources.GetString("e_MoneyKindDiv1012.OutputFormat");
            this.e_MoneyKindDiv1012.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1012.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1012.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1012.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1012.Text = "1,123,456,789";
            this.e_MoneyKindDiv1012.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1012.Width = 0.72F;
            // 
            // e_LastTimeDemand2
            // 
            this.e_LastTimeDemand2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand2.Border.RightColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand2.Border.TopColor = System.Drawing.Color.Black;
            this.e_LastTimeDemand2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_LastTimeDemand2.DataField = "LastTimeDemand";
            this.e_LastTimeDemand2.Height = 0.125F;
            this.e_LastTimeDemand2.Left = 3.875F;
            this.e_LastTimeDemand2.MultiLine = false;
            this.e_LastTimeDemand2.Name = "e_LastTimeDemand2";
            this.e_LastTimeDemand2.OutputFormat = resources.GetString("e_LastTimeDemand2.OutputFormat");
            this.e_LastTimeDemand2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_LastTimeDemand2.SummaryGroup = "EmployeeHeader";
            this.e_LastTimeDemand2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_LastTimeDemand2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_LastTimeDemand2.Text = "1,123,456,789";
            this.e_LastTimeDemand2.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_LastTimeDemand2.Width = 0.72F;
            // 
            // e_AcpOdrTtl2TmBfBlDmd2
            // 
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.e_AcpOdrTtl2TmBfBlDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_AcpOdrTtl2TmBfBlDmd2.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.e_AcpOdrTtl2TmBfBlDmd2.Height = 0.125F;
            this.e_AcpOdrTtl2TmBfBlDmd2.Left = 3.1875F;
            this.e_AcpOdrTtl2TmBfBlDmd2.MultiLine = false;
            this.e_AcpOdrTtl2TmBfBlDmd2.Name = "e_AcpOdrTtl2TmBfBlDmd2";
            this.e_AcpOdrTtl2TmBfBlDmd2.OutputFormat = resources.GetString("e_AcpOdrTtl2TmBfBlDmd2.OutputFormat");
            this.e_AcpOdrTtl2TmBfBlDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_AcpOdrTtl2TmBfBlDmd2.SummaryGroup = "EmployeeHeader";
            this.e_AcpOdrTtl2TmBfBlDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_AcpOdrTtl2TmBfBlDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_AcpOdrTtl2TmBfBlDmd2.Text = "1,123,456,789";
            this.e_AcpOdrTtl2TmBfBlDmd2.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_AcpOdrTtl2TmBfBlDmd2.Width = 0.72F;
            // 
            // e_MoneyKindDiv1022
            // 
            this.e_MoneyKindDiv1022.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1022.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1022.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1022.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1022.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1022.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1022.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1022.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1022.DataField = "MoneyKindDiv102";
            this.e_MoneyKindDiv1022.Height = 0.125F;
            this.e_MoneyKindDiv1022.Left = 5.25F;
            this.e_MoneyKindDiv1022.MultiLine = false;
            this.e_MoneyKindDiv1022.Name = "e_MoneyKindDiv1022";
            this.e_MoneyKindDiv1022.OutputFormat = resources.GetString("e_MoneyKindDiv1022.OutputFormat");
            this.e_MoneyKindDiv1022.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1022.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1022.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1022.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1022.Text = "1,123,456,789";
            this.e_MoneyKindDiv1022.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1022.Width = 0.72F;
            // 
            // e_MoneyKindDiv1072
            // 
            this.e_MoneyKindDiv1072.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1072.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1072.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1072.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1072.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1072.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1072.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1072.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1072.DataField = "MoneyKindDiv107";
            this.e_MoneyKindDiv1072.Height = 0.125F;
            this.e_MoneyKindDiv1072.Left = 5.9375F;
            this.e_MoneyKindDiv1072.MultiLine = false;
            this.e_MoneyKindDiv1072.Name = "e_MoneyKindDiv1072";
            this.e_MoneyKindDiv1072.OutputFormat = resources.GetString("e_MoneyKindDiv1072.OutputFormat");
            this.e_MoneyKindDiv1072.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1072.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1072.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1072.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1072.Text = "1,123,456,789";
            this.e_MoneyKindDiv1072.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1072.Width = 0.72F;
            // 
            // e_MoneyKindDiv1122
            // 
            this.e_MoneyKindDiv1122.Border.BottomColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1122.Border.LeftColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1122.Border.RightColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1122.Border.TopColor = System.Drawing.Color.Black;
            this.e_MoneyKindDiv1122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_MoneyKindDiv1122.DataField = "MoneyKindDiv112";
            this.e_MoneyKindDiv1122.Height = 0.125F;
            this.e_MoneyKindDiv1122.Left = 8.6875F;
            this.e_MoneyKindDiv1122.MultiLine = false;
            this.e_MoneyKindDiv1122.Name = "e_MoneyKindDiv1122";
            this.e_MoneyKindDiv1122.OutputFormat = resources.GetString("e_MoneyKindDiv1122.OutputFormat");
            this.e_MoneyKindDiv1122.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_MoneyKindDiv1122.SummaryGroup = "EmployeeHeader";
            this.e_MoneyKindDiv1122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_MoneyKindDiv1122.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_MoneyKindDiv1122.Text = "1,123,456,789";
            this.e_MoneyKindDiv1122.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_MoneyKindDiv1122.Width = 0.72F;
            // 
            // e_ThisTimeFeeDmdNrml2
            // 
            this.e_ThisTimeFeeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeFeeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeFeeDmdNrml2.DataField = "ThisTimeFeeDmdNrml";
            this.e_ThisTimeFeeDmdNrml2.Height = 0.125F;
            this.e_ThisTimeFeeDmdNrml2.Left = 9.375F;
            this.e_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.e_ThisTimeFeeDmdNrml2.Name = "e_ThisTimeFeeDmdNrml2";
            this.e_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("e_ThisTimeFeeDmdNrml2.OutputFormat");
            this.e_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeFeeDmdNrml2.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeFeeDmdNrml2.Text = "1,123,456,789";
            this.e_ThisTimeFeeDmdNrml2.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_ThisTimeFeeDmdNrml2.Width = 0.72F;
            // 
            // e_ThisTimeDisDmdNrml2
            // 
            this.e_ThisTimeDisDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.e_ThisTimeDisDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_ThisTimeDisDmdNrml2.DataField = "ThisTimeDisDmdNrml";
            this.e_ThisTimeDisDmdNrml2.Height = 0.125F;
            this.e_ThisTimeDisDmdNrml2.Left = 10.0625F;
            this.e_ThisTimeDisDmdNrml2.MultiLine = false;
            this.e_ThisTimeDisDmdNrml2.Name = "e_ThisTimeDisDmdNrml2";
            this.e_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("e_ThisTimeDisDmdNrml2.OutputFormat");
            this.e_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_ThisTimeDisDmdNrml2.SummaryGroup = "EmployeeHeader";
            this.e_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_ThisTimeDisDmdNrml2.Text = "1,123,456,789";
            this.e_ThisTimeDisDmdNrml2.Top = 0.625F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.e_ThisTimeDisDmdNrml2.Width = 0.72F;
            // 
            // e_CollectRate2
            // 
            this.e_CollectRate2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_CollectRate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_CollectRate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate2.Border.RightColor = System.Drawing.Color.Black;
            this.e_CollectRate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate2.Border.TopColor = System.Drawing.Color.Black;
            this.e_CollectRate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectRate2.Height = 0.125F;
            this.e_CollectRate2.Left = 8.791668F;
            this.e_CollectRate2.MultiLine = false;
            this.e_CollectRate2.Name = "e_CollectRate2";
            this.e_CollectRate2.OutputFormat = resources.GetString("e_CollectRate2.OutputFormat");
            this.e_CollectRate2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.e_CollectRate2.Text = "123.00";
            this.e_CollectRate2.Top = 0F;
            this.e_CollectRate2.Width = 0.5F;
            // 
            // e_CollectDemand2
            // 
            this.e_CollectDemand2.Border.BottomColor = System.Drawing.Color.Black;
            this.e_CollectDemand2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand2.Border.LeftColor = System.Drawing.Color.Black;
            this.e_CollectDemand2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand2.Border.RightColor = System.Drawing.Color.Black;
            this.e_CollectDemand2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand2.Border.TopColor = System.Drawing.Color.Black;
            this.e_CollectDemand2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.e_CollectDemand2.DataField = "CollectDemand";
            this.e_CollectDemand2.Height = 0.125F;
            this.e_CollectDemand2.Left = 0F;
            this.e_CollectDemand2.Name = "e_CollectDemand2";
            this.e_CollectDemand2.OutputFormat = resources.GetString("e_CollectDemand2.OutputFormat");
            this.e_CollectDemand2.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.e_CollectDemand2.SummaryGroup = "EmployeeHeader";
            this.e_CollectDemand2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.e_CollectDemand2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.e_CollectDemand2.Text = null;
            this.e_CollectDemand2.Top = 0F;
            this.e_CollectDemand2.Visible = false;
            this.e_CollectDemand2.Width = 0.375F;
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
            this.textBox39.Height = 0.125F;
            this.textBox39.Left = 9.281251F;
            this.textBox39.Name = "textBox39";
            this.textBox39.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.textBox39.Text = "%";
            this.textBox39.Top = 0F;
            this.textBox39.Width = 0.125F;
            // 
            // textBox_emp2
            // 
            this.textBox_emp2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_emp2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_emp2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_emp2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_emp2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp2.Height = 0.125F;
            this.textBox_emp2.Left = 2.5625F;
            this.textBox_emp2.Name = "textBox_emp2";
            this.textBox_emp2.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox_emp2.Text = null;
            this.textBox_emp2.Top = 0.75F;// ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox_emp2.Visible = false;
            this.textBox_emp2.Width = 0.375F;
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
            this.textBox41.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox41.Height = 0.125F;
            this.textBox41.Left = 4.563F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox41.SummaryGroup = "EmployeeHeader";
            this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox41.Text = "1,234,567,890";
            this.textBox41.Top = 0.125F;
            this.textBox41.Width = 0.72F;
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
            this.textBox42.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox42.Height = 0.125F;
            this.textBox42.Left = 5.25F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox42.SummaryGroup = "EmployeeHeader";
            this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox42.Text = "1,234,567,890";
            this.textBox42.Top = 0.125F;
            this.textBox42.Width = 0.72F;
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
            this.textBox43.DataField = "TotalPureSalesTaxRate1";
            this.textBox43.Height = 0.125F;
            this.textBox43.Left = 5.938F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox43.SummaryGroup = "EmployeeHeader";
            this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox43.Text = "1,234,567,890";
            this.textBox43.Top = 0.125F;
            this.textBox43.Width = 0.72F;
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
            this.textBox44.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox44.Height = 0.125F;
            this.textBox44.Left = 6.625F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox44.SummaryGroup = "EmployeeHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox44.Text = "1,234,567,890";
            this.textBox44.Top = 0.125F;
            this.textBox44.Width = 0.72F;
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
            this.textBox45.DataField = "TotalThisSalesSumTaxRate1";
            this.textBox45.Height = 0.125F;
            this.textBox45.Left = 7.313F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox45.SummaryGroup = "EmployeeHeader";
            this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox45.Text = "1,234,567,890";
            this.textBox45.Top = 0.125F;
            this.textBox45.Width = 0.72F;
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
            this.textBox46.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox46.Height = 0.125F;
            this.textBox46.Left = 9.499F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox46.SummaryGroup = "EmployeeHeader";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "123,456";
            this.textBox46.Top = 0.125F;
            this.textBox46.Width = 0.605F;
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
            this.textBox47.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox47.Height = 0.125F;
            this.textBox47.Left = 4.563F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox47.SummaryGroup = "EmployeeHeader";
            this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox47.Text = "1,234,567,890";
            this.textBox47.Top = 0.25F;
            this.textBox47.Width = 0.72F;
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
            this.textBox48.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox48.Height = 0.125F;
            this.textBox48.Left = 5.25F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox48.SummaryGroup = "EmployeeHeader";
            this.textBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox48.Text = "1,234,567,890";
            this.textBox48.Top = 0.25F;
            this.textBox48.Width = 0.72F;
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
            this.textBox49.DataField = "TotalPureSalesTaxRate2";
            this.textBox49.Height = 0.125F;
            this.textBox49.Left = 5.938F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox49.SummaryGroup = "EmployeeHeader";
            this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox49.Text = "1,234,567,890";
            this.textBox49.Top = 0.25F;
            this.textBox49.Width = 0.72F;
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
            this.textBox50.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox50.Height = 0.125F;
            this.textBox50.Left = 6.625F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox50.SummaryGroup = "EmployeeHeader";
            this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox50.Text = "1,234,567,890";
            this.textBox50.Top = 0.25F;
            this.textBox50.Width = 0.72F;
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
            this.textBox51.DataField = "TotalThisSalesSumTaxRate2";
            this.textBox51.Height = 0.125F;
            this.textBox51.Left = 7.313F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox51.SummaryGroup = "EmployeeHeader";
            this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox51.Text = "1,234,567,890";
            this.textBox51.Top = 0.25F;
            this.textBox51.Width = 0.72F;
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
            this.textBox52.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox52.Height = 0.125F;
            this.textBox52.Left = 9.499F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox52.SummaryGroup = "EmployeeHeader";
            this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox52.Text = "123,456";
            this.textBox52.Top = 0.25F;
            this.textBox52.Width = 0.605F;
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
            this.textBox53.DataField = "TotalThisTimeSalesOther";
            this.textBox53.Height = 0.125F;
            this.textBox53.Left = 4.5625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox53.SummaryGroup = "EmployeeHeader";
            this.textBox53.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox53.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox53.Text = "1,234,567,890";
            this.textBox53.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox53.Width = 0.72F;
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
            this.textBox54.DataField = "TotalThisRgdsDisPricOther";
            this.textBox54.Height = 0.125F;
            this.textBox54.Left = 5.25F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox54.SummaryGroup = "EmployeeHeader";
            this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox54.Text = "1,234,567,890";
            this.textBox54.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox54.Width = 0.72F;
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
            this.textBox55.DataField = "TotalPureSalesOther";
            this.textBox55.Height = 0.125F;
            this.textBox55.Left = 5.9375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox55.SummaryGroup = "EmployeeHeader";
            this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox55.Text = "1,234,567,890";
            this.textBox55.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox55.Width = 0.72F;
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
            this.textBox56.DataField = "TotalSalesPricTaxOther";
            this.textBox56.Height = 0.125F;
            this.textBox56.Left = 6.625F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox56.SummaryGroup = "EmployeeHeader";
            this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox56.Text = "1,234,567,890";
            this.textBox56.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox56.Width = 0.72F;
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
            this.textBox57.DataField = "TotalThisSalesSumTaxOther";
            this.textBox57.Height = 0.125F;
            this.textBox57.Left = 7.3125F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox57.SummaryGroup = "EmployeeHeader";
            this.textBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox57.Text = "1,234,567,890";
            this.textBox57.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox57.Width = 0.72F;
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
            this.textBox58.DataField = "TotalSalesSlipCountOther";
            this.textBox58.Height = 0.125F;
            this.textBox58.Left = 9.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox58.SummaryGroup = "EmployeeHeader";
            this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox58.Text = "123,456";
            this.textBox58.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox58.Width = 0.605F;
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
            this.s_TaxTotalTitleTaxRate1.Height = 0.125F;
            this.s_TaxTotalTitleTaxRate1.HyperLink = null;
            this.s_TaxTotalTitleTaxRate1.Left = 4F;
            this.s_TaxTotalTitleTaxRate1.Name = "s_TaxTotalTitleTaxRate1";
            this.s_TaxTotalTitleTaxRate1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.s_TaxTotalTitleTaxRate1.Text = "10%";
            this.s_TaxTotalTitleTaxRate1.Top = 0.125F;
            this.s_TaxTotalTitleTaxRate1.Width = 0.5625F;
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
            this.s_TaxTotalTitleTaxRate2.Height = 0.125F;
            this.s_TaxTotalTitleTaxRate2.HyperLink = null;
            this.s_TaxTotalTitleTaxRate2.Left = 4F;
            this.s_TaxTotalTitleTaxRate2.Name = "s_TaxTotalTitleTaxRate2";
            this.s_TaxTotalTitleTaxRate2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.s_TaxTotalTitleTaxRate2.Text = "8%";
            this.s_TaxTotalTitleTaxRate2.Top = 0.25F;
            this.s_TaxTotalTitleTaxRate2.Width = 0.5625F;
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
            this.s_TaxTotalTitleOther.Left = 4F;
            this.s_TaxTotalTitleOther.Name = "s_TaxTotalTitleOther";
            this.s_TaxTotalTitleOther.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.s_TaxTotalTitleOther.Text = "その他";
            this.s_TaxTotalTitleOther.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_TaxTotalTitleOther.Width = 0.5625F;
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
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
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
            this.label17.Left = 4F;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "非課税";
            this.label17.Top = 0.5F;
            this.label17.Width = 0.5625F;
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
            this.textBox25.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox25.Height = 0.125F;
            this.textBox25.Left = 4.5625F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = "#,##0";
            this.textBox25.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox25.SummaryGroup = "EmployeeHeader";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox25.Text = "1,234,567,890";
            this.textBox25.Top = 0.5F;
            this.textBox25.Width = 0.72F;
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
            this.textBox26.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox26.Height = 0.125F;
            this.textBox26.Left = 5.25F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = "#,##0";
            this.textBox26.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox26.SummaryGroup = "EmployeeHeader";
            this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox26.Text = "1,234,567,890";
            this.textBox26.Top = 0.5F;
            this.textBox26.Width = 0.72F;
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
            this.textBox35.DataField = "TotalPureSalesTaxFree";
            this.textBox35.Height = 0.125F;
            this.textBox35.Left = 5.9375F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = "#,##0";
            this.textBox35.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox35.SummaryGroup = "EmployeeHeader";
            this.textBox35.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox35.Text = "1,234,567,890";
            this.textBox35.Top = 0.5F;
            this.textBox35.Width = 0.72F;
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
            this.textBox36.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox36.Height = 0.125F;
            this.textBox36.Left = 6.625F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = "#,##0";
            this.textBox36.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox36.SummaryGroup = "EmployeeHeader";
            this.textBox36.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox36.Text = "1,234,567,890";
            this.textBox36.Top = 0.5F;
            this.textBox36.Width = 0.72F;
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
            this.textBox37.DataField = "TotalThisSalesSumTaxFree";
            this.textBox37.Height = 0.125F;
            this.textBox37.Left = 7.3125F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = "#,##0";
            this.textBox37.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox37.SummaryGroup = "EmployeeHeader";
            this.textBox37.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox37.Text = "1,234,567,890";
            this.textBox37.Top = 0.5F;
            this.textBox37.Width = 0.72F;
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
            this.textBox38.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox38.Height = 0.125F;
            this.textBox38.Left = 9.5F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = "#,##0";
            this.textBox38.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox38.SummaryGroup = "EmployeeHeader";
            this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox38.Text = "123,456";
            this.textBox38.Top = 0.5F;
            this.textBox38.Width = 0.605F;
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
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
            this.s_ThisSalesPricRgdsDis2,
            this.s_AfCalDemandPrice2,
            this.s_OfsThisSalesSum2,
            this.s_OfsThisSalesTax2,
            this.s_OfsThisTimeSales2,
            this.s_ThisTimeTtlBlcDmd2,
            this.s_ThisTimeDmdNrml2,
            this.s_DemandBalance2,
            this.s_NetSales2,
            this.s_SaleslSlipCount2,
            this.textBox69,
            this.s_AcpOdrTtl3TmBfBlDmd2,
            this.s_MoneyKindDiv1092,
            this.s_MoneyKindDiv1062,
            this.s_MoneyKindDiv1052,
            this.s_MoneyKindDiv1012,
            this.s_LastTimeDemand2,
            this.s_AcpOdrTtl2TmBfBlDmd2,
            this.s_MoneyKindDiv1022,
            this.s_MoneyKindDiv1072,
            this.s_MoneyKindDiv1122,
            this.s_ThisTimeFeeDmdNrml2,
            this.s_ThisTimeDisDmdNrml2,
            this.s_CollectRate2,
            this.s_CollectDemand2,
            this.textBox84,
            this.textBox_sec2,
            this.label5,
            this.label6,
            this.label7,
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
            this.textBox96,
            this.textBox97,
            this.textBox98,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textBox102,
            this.textBox103,
            this.line7,
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            this.label15,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox17,
            this.textBox18});
            this.SectionFooter2.Height = 0.8854167F;
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            this.SectionFooter2.KeepTogether = true;
            this.SectionFooter2.Name = "SectionFooter2";
            this.SectionFooter2.BeforePrint += new System.EventHandler(this.SectionFooter2_BeforePrint);
            // 
            // s_ThisSalesPricRgdsDis2
            // 
            this.s_ThisSalesPricRgdsDis2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisSalesPricRgdsDis2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisSalesPricRgdsDis2.DataField = "ThisSalesPricRgdsDis";
            this.s_ThisSalesPricRgdsDis2.Height = 0.125F;
            this.s_ThisSalesPricRgdsDis2.Left = 5.255F;
            this.s_ThisSalesPricRgdsDis2.MultiLine = false;
            this.s_ThisSalesPricRgdsDis2.Name = "s_ThisSalesPricRgdsDis2";
            this.s_ThisSalesPricRgdsDis2.OutputFormat = resources.GetString("s_ThisSalesPricRgdsDis2.OutputFormat");
            this.s_ThisSalesPricRgdsDis2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisSalesPricRgdsDis2.SummaryGroup = "SectionHeader";
            this.s_ThisSalesPricRgdsDis2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisSalesPricRgdsDis2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisSalesPricRgdsDis2.Text = "1,123,456,789";
            this.s_ThisSalesPricRgdsDis2.Top = 0F;
            this.s_ThisSalesPricRgdsDis2.Width = 0.72F;
            // 
            // s_AfCalDemandPrice2
            // 
            this.s_AfCalDemandPrice2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice2.Border.RightColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice2.Border.TopColor = System.Drawing.Color.Black;
            this.s_AfCalDemandPrice2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AfCalDemandPrice2.DataField = "AfCalDemandPrice";
            this.s_AfCalDemandPrice2.Height = 0.125F;
            this.s_AfCalDemandPrice2.Left = 8.010417F;
            this.s_AfCalDemandPrice2.MultiLine = false;
            this.s_AfCalDemandPrice2.Name = "s_AfCalDemandPrice2";
            this.s_AfCalDemandPrice2.OutputFormat = resources.GetString("s_AfCalDemandPrice2.OutputFormat");
            this.s_AfCalDemandPrice2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_AfCalDemandPrice2.SummaryGroup = "SectionHeader";
            this.s_AfCalDemandPrice2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_AfCalDemandPrice2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_AfCalDemandPrice2.Text = "1,123,456,789";
            this.s_AfCalDemandPrice2.Top = 0F;
            this.s_AfCalDemandPrice2.Width = 0.72F;
            // 
            // s_OfsThisSalesSum2
            // 
            this.s_OfsThisSalesSum2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesSum2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesSum2.DataField = "OfsThisSalesSum";
            this.s_OfsThisSalesSum2.Height = 0.125F;
            this.s_OfsThisSalesSum2.Left = 7.3125F;
            this.s_OfsThisSalesSum2.MultiLine = false;
            this.s_OfsThisSalesSum2.Name = "s_OfsThisSalesSum2";
            this.s_OfsThisSalesSum2.OutputFormat = resources.GetString("s_OfsThisSalesSum2.OutputFormat");
            this.s_OfsThisSalesSum2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_OfsThisSalesSum2.SummaryGroup = "SectionHeader";
            this.s_OfsThisSalesSum2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OfsThisSalesSum2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OfsThisSalesSum2.Text = "1,123,456,789";
            this.s_OfsThisSalesSum2.Top = 0F;
            this.s_OfsThisSalesSum2.Width = 0.72F;
            // 
            // s_OfsThisSalesTax2
            // 
            this.s_OfsThisSalesTax2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OfsThisSalesTax2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisSalesTax2.DataField = "OfsThisSalesTax";
            this.s_OfsThisSalesTax2.Height = 0.125F;
            this.s_OfsThisSalesTax2.Left = 6.625F;
            this.s_OfsThisSalesTax2.MultiLine = false;
            this.s_OfsThisSalesTax2.Name = "s_OfsThisSalesTax2";
            this.s_OfsThisSalesTax2.OutputFormat = resources.GetString("s_OfsThisSalesTax2.OutputFormat");
            this.s_OfsThisSalesTax2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_OfsThisSalesTax2.SummaryGroup = "SectionHeader";
            this.s_OfsThisSalesTax2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OfsThisSalesTax2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OfsThisSalesTax2.Text = "1,123,456,789";
            this.s_OfsThisSalesTax2.Top = 0F;
            this.s_OfsThisSalesTax2.Width = 0.72F;
            // 
            // s_OfsThisTimeSales2
            // 
            this.s_OfsThisTimeSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OfsThisTimeSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OfsThisTimeSales2.DataField = "ThisTimeSales";
            this.s_OfsThisTimeSales2.Height = 0.125F;
            this.s_OfsThisTimeSales2.Left = 4.5625F;
            this.s_OfsThisTimeSales2.MultiLine = false;
            this.s_OfsThisTimeSales2.Name = "s_OfsThisTimeSales2";
            this.s_OfsThisTimeSales2.OutputFormat = resources.GetString("s_OfsThisTimeSales2.OutputFormat");
            this.s_OfsThisTimeSales2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_OfsThisTimeSales2.SummaryGroup = "SectionHeader";
            this.s_OfsThisTimeSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OfsThisTimeSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OfsThisTimeSales2.Text = "1,123,456,789";
            this.s_OfsThisTimeSales2.Top = 0F;
            this.s_OfsThisTimeSales2.Width = 0.72F;
            // 
            // s_ThisTimeTtlBlcDmd2
            // 
            this.s_ThisTimeTtlBlcDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeTtlBlcDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeTtlBlcDmd2.DataField = "ThisTimeTtlBlcDmd";
            this.s_ThisTimeTtlBlcDmd2.Height = 0.125F;
            this.s_ThisTimeTtlBlcDmd2.Left = 3.875F;
            this.s_ThisTimeTtlBlcDmd2.MultiLine = false;
            this.s_ThisTimeTtlBlcDmd2.Name = "s_ThisTimeTtlBlcDmd2";
            this.s_ThisTimeTtlBlcDmd2.OutputFormat = resources.GetString("s_ThisTimeTtlBlcDmd2.OutputFormat");
            this.s_ThisTimeTtlBlcDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeTtlBlcDmd2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeTtlBlcDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeTtlBlcDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeTtlBlcDmd2.Text = "1,123,456,789";
            this.s_ThisTimeTtlBlcDmd2.Top = 0F;
            this.s_ThisTimeTtlBlcDmd2.Width = 0.72F;
            // 
            // s_ThisTimeDmdNrml2
            // 
            this.s_ThisTimeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDmdNrml2.DataField = "ThisTimeDmdNrml";
            this.s_ThisTimeDmdNrml2.Height = 0.125F;
            this.s_ThisTimeDmdNrml2.Left = 3.1875F;
            this.s_ThisTimeDmdNrml2.MultiLine = false;
            this.s_ThisTimeDmdNrml2.Name = "s_ThisTimeDmdNrml2";
            this.s_ThisTimeDmdNrml2.OutputFormat = resources.GetString("s_ThisTimeDmdNrml2.OutputFormat");
            this.s_ThisTimeDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeDmdNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDmdNrml2.Text = "1,123,456,789";
            this.s_ThisTimeDmdNrml2.Top = 0F;
            this.s_ThisTimeDmdNrml2.Width = 0.72F;
            // 
            // s_DemandBalance2
            // 
            this.s_DemandBalance2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_DemandBalance2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_DemandBalance2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance2.Border.RightColor = System.Drawing.Color.Black;
            this.s_DemandBalance2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance2.Border.TopColor = System.Drawing.Color.Black;
            this.s_DemandBalance2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DemandBalance2.DataField = "DemandBalance";
            this.s_DemandBalance2.Height = 0.125F;
            this.s_DemandBalance2.Left = 2.5F;
            this.s_DemandBalance2.MultiLine = false;
            this.s_DemandBalance2.Name = "s_DemandBalance2";
            this.s_DemandBalance2.OutputFormat = resources.GetString("s_DemandBalance2.OutputFormat");
            this.s_DemandBalance2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_DemandBalance2.SummaryGroup = "SectionHeader";
            this.s_DemandBalance2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DemandBalance2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DemandBalance2.Text = "1,123,456,789";
            this.s_DemandBalance2.Top = 0F;
            this.s_DemandBalance2.Width = 0.72F;
            // 
            // s_NetSales2
            // 
            this.s_NetSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_NetSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_NetSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales2.Border.RightColor = System.Drawing.Color.Black;
            this.s_NetSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales2.Border.TopColor = System.Drawing.Color.Black;
            this.s_NetSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_NetSales2.DataField = "NetSales";
            this.s_NetSales2.Height = 0.125F;
            this.s_NetSales2.Left = 5.9375F;
            this.s_NetSales2.MultiLine = false;
            this.s_NetSales2.Name = "s_NetSales2";
            this.s_NetSales2.OutputFormat = resources.GetString("s_NetSales2.OutputFormat");
            this.s_NetSales2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_NetSales2.SummaryGroup = "SectionHeader";
            this.s_NetSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_NetSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_NetSales2.Text = "1,123,456,789";
            this.s_NetSales2.Top = 0F;
            this.s_NetSales2.Width = 0.72F;
            // 
            // s_SaleslSlipCount2
            // 
            this.s_SaleslSlipCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount2.Border.RightColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount2.Border.TopColor = System.Drawing.Color.Black;
            this.s_SaleslSlipCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SaleslSlipCount2.DataField = "SaleslSlipCount";
            this.s_SaleslSlipCount2.Height = 0.125F;
            this.s_SaleslSlipCount2.Left = 9.499F;
            this.s_SaleslSlipCount2.MultiLine = false;
            this.s_SaleslSlipCount2.Name = "s_SaleslSlipCount2";
            this.s_SaleslSlipCount2.OutputFormat = resources.GetString("s_SaleslSlipCount2.OutputFormat");
            this.s_SaleslSlipCount2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_SaleslSlipCount2.SummaryGroup = "SectionHeader";
            this.s_SaleslSlipCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_SaleslSlipCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_SaleslSlipCount2.Text = "123,456";
            this.s_SaleslSlipCount2.Top = 0F;
            this.s_SaleslSlipCount2.Width = 0.605F;
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
            this.textBox69.DataField = "MONEYKINDNAME";
            this.textBox69.Height = 0.1875F;
            this.textBox69.Left = 1.0625F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox69.Text = "拠点計";
            this.textBox69.Top = 0F;
            this.textBox69.Width = 0.5625F;
            // 
            // s_AcpOdrTtl3TmBfBlDmd2
            // 
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl3TmBfBlDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl3TmBfBlDmd2.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.s_AcpOdrTtl3TmBfBlDmd2.Height = 0.125F;
            this.s_AcpOdrTtl3TmBfBlDmd2.Left = 2.5F;
            this.s_AcpOdrTtl3TmBfBlDmd2.MultiLine = false;
            this.s_AcpOdrTtl3TmBfBlDmd2.Name = "s_AcpOdrTtl3TmBfBlDmd2";
            this.s_AcpOdrTtl3TmBfBlDmd2.OutputFormat = resources.GetString("s_AcpOdrTtl3TmBfBlDmd2.OutputFormat");
            this.s_AcpOdrTtl3TmBfBlDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_AcpOdrTtl3TmBfBlDmd2.SummaryGroup = "SectionHeader";
            this.s_AcpOdrTtl3TmBfBlDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_AcpOdrTtl3TmBfBlDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_AcpOdrTtl3TmBfBlDmd2.Text = "1,123,456,789";
            this.s_AcpOdrTtl3TmBfBlDmd2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_AcpOdrTtl3TmBfBlDmd2.Width = 0.72F;
            // 
            // s_MoneyKindDiv1092
            // 
            this.s_MoneyKindDiv1092.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1092.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1092.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1092.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1092.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1092.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1092.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1092.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1092.DataField = "MoneyKindDiv109";
            this.s_MoneyKindDiv1092.Height = 0.125F;
            this.s_MoneyKindDiv1092.Left = 8F;
            this.s_MoneyKindDiv1092.MultiLine = false;
            this.s_MoneyKindDiv1092.Name = "s_MoneyKindDiv1092";
            this.s_MoneyKindDiv1092.OutputFormat = resources.GetString("s_MoneyKindDiv1092.OutputFormat");
            this.s_MoneyKindDiv1092.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1092.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1092.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1092.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1092.Text = "1,123,456,789";
            this.s_MoneyKindDiv1092.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1092.Width = 0.72F;
            // 
            // s_MoneyKindDiv1062
            // 
            this.s_MoneyKindDiv1062.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1062.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1062.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1062.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1062.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1062.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1062.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1062.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1062.DataField = "MoneyKindDiv106";
            this.s_MoneyKindDiv1062.Height = 0.125F;
            this.s_MoneyKindDiv1062.Left = 7.3125F;
            this.s_MoneyKindDiv1062.MultiLine = false;
            this.s_MoneyKindDiv1062.Name = "s_MoneyKindDiv1062";
            this.s_MoneyKindDiv1062.OutputFormat = resources.GetString("s_MoneyKindDiv1062.OutputFormat");
            this.s_MoneyKindDiv1062.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1062.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1062.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1062.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1062.Text = "1,123,456,789";
            this.s_MoneyKindDiv1062.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1062.Width = 0.72F;
            // 
            // s_MoneyKindDiv1052
            // 
            this.s_MoneyKindDiv1052.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1052.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1052.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1052.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1052.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1052.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1052.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1052.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1052.DataField = "MoneyKindDiv105";
            this.s_MoneyKindDiv1052.Height = 0.125F;
            this.s_MoneyKindDiv1052.Left = 6.625F;
            this.s_MoneyKindDiv1052.MultiLine = false;
            this.s_MoneyKindDiv1052.Name = "s_MoneyKindDiv1052";
            this.s_MoneyKindDiv1052.OutputFormat = resources.GetString("s_MoneyKindDiv1052.OutputFormat");
            this.s_MoneyKindDiv1052.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1052.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1052.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1052.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1052.Text = "1,123,456,789";
            this.s_MoneyKindDiv1052.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1052.Width = 0.72F;
            // 
            // s_MoneyKindDiv1012
            // 
            this.s_MoneyKindDiv1012.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1012.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1012.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1012.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1012.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1012.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1012.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1012.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1012.DataField = "MoneyKindDiv101";
            this.s_MoneyKindDiv1012.Height = 0.125F;
            this.s_MoneyKindDiv1012.Left = 4.5625F;
            this.s_MoneyKindDiv1012.MultiLine = false;
            this.s_MoneyKindDiv1012.Name = "s_MoneyKindDiv1012";
            this.s_MoneyKindDiv1012.OutputFormat = resources.GetString("s_MoneyKindDiv1012.OutputFormat");
            this.s_MoneyKindDiv1012.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1012.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1012.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1012.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1012.Text = "1,123,456,789";
            this.s_MoneyKindDiv1012.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1012.Width = 0.72F;
            // 
            // s_LastTimeDemand2
            // 
            this.s_LastTimeDemand2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand2.Border.RightColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand2.Border.TopColor = System.Drawing.Color.Black;
            this.s_LastTimeDemand2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimeDemand2.DataField = "LastTimeDemand";
            this.s_LastTimeDemand2.Height = 0.125F;
            this.s_LastTimeDemand2.Left = 3.875F;
            this.s_LastTimeDemand2.MultiLine = false;
            this.s_LastTimeDemand2.Name = "s_LastTimeDemand2";
            this.s_LastTimeDemand2.OutputFormat = resources.GetString("s_LastTimeDemand2.OutputFormat");
            this.s_LastTimeDemand2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_LastTimeDemand2.SummaryGroup = "SectionHeader";
            this.s_LastTimeDemand2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_LastTimeDemand2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_LastTimeDemand2.Text = "1,123,456,789";
            this.s_LastTimeDemand2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_LastTimeDemand2.Width = 0.72F;
            // 
            // s_AcpOdrTtl2TmBfBlDmd2
            // 
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.s_AcpOdrTtl2TmBfBlDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_AcpOdrTtl2TmBfBlDmd2.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.s_AcpOdrTtl2TmBfBlDmd2.Height = 0.125F;
            this.s_AcpOdrTtl2TmBfBlDmd2.Left = 3.1875F;
            this.s_AcpOdrTtl2TmBfBlDmd2.MultiLine = false;
            this.s_AcpOdrTtl2TmBfBlDmd2.Name = "s_AcpOdrTtl2TmBfBlDmd2";
            this.s_AcpOdrTtl2TmBfBlDmd2.OutputFormat = resources.GetString("s_AcpOdrTtl2TmBfBlDmd2.OutputFormat");
            this.s_AcpOdrTtl2TmBfBlDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_AcpOdrTtl2TmBfBlDmd2.SummaryGroup = "SectionHeader";
            this.s_AcpOdrTtl2TmBfBlDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_AcpOdrTtl2TmBfBlDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_AcpOdrTtl2TmBfBlDmd2.Text = "1,123,456,789";
            this.s_AcpOdrTtl2TmBfBlDmd2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_AcpOdrTtl2TmBfBlDmd2.Width = 0.72F;
            // 
            // s_MoneyKindDiv1022
            // 
            this.s_MoneyKindDiv1022.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1022.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1022.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1022.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1022.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1022.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1022.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1022.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1022.DataField = "MoneyKindDiv102";
            this.s_MoneyKindDiv1022.Height = 0.125F;
            this.s_MoneyKindDiv1022.Left = 5.25F;
            this.s_MoneyKindDiv1022.MultiLine = false;
            this.s_MoneyKindDiv1022.Name = "s_MoneyKindDiv1022";
            this.s_MoneyKindDiv1022.OutputFormat = resources.GetString("s_MoneyKindDiv1022.OutputFormat");
            this.s_MoneyKindDiv1022.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1022.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1022.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1022.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1022.Text = "1,123,456,789";
            this.s_MoneyKindDiv1022.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1022.Width = 0.72F;
            // 
            // s_MoneyKindDiv1072
            // 
            this.s_MoneyKindDiv1072.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1072.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1072.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1072.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1072.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1072.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1072.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1072.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1072.DataField = "MoneyKindDiv107";
            this.s_MoneyKindDiv1072.Height = 0.125F;
            this.s_MoneyKindDiv1072.Left = 5.9375F;
            this.s_MoneyKindDiv1072.MultiLine = false;
            this.s_MoneyKindDiv1072.Name = "s_MoneyKindDiv1072";
            this.s_MoneyKindDiv1072.OutputFormat = resources.GetString("s_MoneyKindDiv1072.OutputFormat");
            this.s_MoneyKindDiv1072.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1072.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1072.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1072.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1072.Text = "1,123,456,789";
            this.s_MoneyKindDiv1072.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1072.Width = 0.72F;
            // 
            // s_MoneyKindDiv1122
            // 
            this.s_MoneyKindDiv1122.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1122.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1122.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1122.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoneyKindDiv1122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoneyKindDiv1122.DataField = "MoneyKindDiv112";
            this.s_MoneyKindDiv1122.Height = 0.125F;
            this.s_MoneyKindDiv1122.Left = 8.6875F;
            this.s_MoneyKindDiv1122.MultiLine = false;
            this.s_MoneyKindDiv1122.Name = "s_MoneyKindDiv1122";
            this.s_MoneyKindDiv1122.OutputFormat = resources.GetString("s_MoneyKindDiv1122.OutputFormat");
            this.s_MoneyKindDiv1122.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MoneyKindDiv1122.SummaryGroup = "SectionHeader";
            this.s_MoneyKindDiv1122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoneyKindDiv1122.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoneyKindDiv1122.Text = "1,123,456,789";
            this.s_MoneyKindDiv1122.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_MoneyKindDiv1122.Width = 0.72F;
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
            this.s_ThisTimeFeeDmdNrml2.Left = 9.375F;
            this.s_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.s_ThisTimeFeeDmdNrml2.Name = "s_ThisTimeFeeDmdNrml2";
            this.s_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("s_ThisTimeFeeDmdNrml2.OutputFormat");
            this.s_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeFeeDmdNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeeDmdNrml2.Text = "1,123,456,789";
            this.s_ThisTimeFeeDmdNrml2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_ThisTimeFeeDmdNrml2.Width = 0.72F;
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
            this.s_ThisTimeDisDmdNrml2.Left = 10.0625F;
            this.s_ThisTimeDisDmdNrml2.MultiLine = false;
            this.s_ThisTimeDisDmdNrml2.Name = "s_ThisTimeDisDmdNrml2";
            this.s_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("s_ThisTimeDisDmdNrml2.OutputFormat");
            this.s_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_ThisTimeDisDmdNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisDmdNrml2.Text = "1,123,456,789";
            this.s_ThisTimeDisDmdNrml2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.s_ThisTimeDisDmdNrml2.Width = 0.72F;
            // 
            // s_CollectRate2
            // 
            this.s_CollectRate2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CollectRate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CollectRate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate2.Border.RightColor = System.Drawing.Color.Black;
            this.s_CollectRate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate2.Border.TopColor = System.Drawing.Color.Black;
            this.s_CollectRate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectRate2.Height = 0.125F;
            this.s_CollectRate2.Left = 8.791668F;
            this.s_CollectRate2.MultiLine = false;
            this.s_CollectRate2.Name = "s_CollectRate2";
            this.s_CollectRate2.OutputFormat = resources.GetString("s_CollectRate2.OutputFormat");
            this.s_CollectRate2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_CollectRate2.Text = "123.00";
            this.s_CollectRate2.Top = 0F;
            this.s_CollectRate2.Width = 0.5F;
            // 
            // s_CollectDemand2
            // 
            this.s_CollectDemand2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CollectDemand2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CollectDemand2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand2.Border.RightColor = System.Drawing.Color.Black;
            this.s_CollectDemand2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand2.Border.TopColor = System.Drawing.Color.Black;
            this.s_CollectDemand2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CollectDemand2.DataField = "CollectDemand";
            this.s_CollectDemand2.Height = 0.125F;
            this.s_CollectDemand2.Left = 0F;
            this.s_CollectDemand2.Name = "s_CollectDemand2";
            this.s_CollectDemand2.OutputFormat = resources.GetString("s_CollectDemand2.OutputFormat");
            this.s_CollectDemand2.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.s_CollectDemand2.SummaryGroup = "SectionHeader";
            this.s_CollectDemand2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CollectDemand2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CollectDemand2.Text = null;
            this.s_CollectDemand2.Top = 0F;
            this.s_CollectDemand2.Visible = false;
            this.s_CollectDemand2.Width = 0.375F;
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
            this.textBox84.Height = 0.125F;
            this.textBox84.Left = 9.281251F;
            this.textBox84.Name = "textBox84";
            this.textBox84.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.textBox84.Text = "%";
            this.textBox84.Top = 0F;
            this.textBox84.Width = 0.125F;
            // 
            // textBox_sec2
            // 
            this.textBox_sec2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_sec2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_sec2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_sec2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_sec2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec2.Height = 0.125F;
            this.textBox_sec2.Left = 2.5625F;
            this.textBox_sec2.Name = "textBox_sec2";
            this.textBox_sec2.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox_sec2.Text = null;
            this.textBox_sec2.Top = 0.75F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox_sec2.Visible = false;
            this.textBox_sec2.Width = 0.375F;
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
            this.label5.Height = 0.125F;
            this.label5.HyperLink = null;
            this.label5.Left = 4F;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "10%";
            this.label5.Top = 0.125F;
            this.label5.Width = 0.563F;
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
            this.label6.Height = 0.125F;
            this.label6.HyperLink = null;
            this.label6.Left = 4F;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "8%";
            this.label6.Top = 0.25F;
            this.label6.Width = 0.563F;
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
            this.label7.Height = 0.125F;
            this.label7.HyperLink = null;
            this.label7.Left = 4F;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "その他";
            this.label7.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.label7.Width = 0.563F;
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
            this.textBox86.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox86.Height = 0.125F;
            this.textBox86.Left = 4.5625F;
            this.textBox86.MultiLine = false;
            this.textBox86.Name = "textBox86";
            this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
            this.textBox86.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox86.SummaryGroup = "SectionHeader";
            this.textBox86.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox86.Text = "1,234,567,890";
            this.textBox86.Top = 0.125F;
            this.textBox86.Width = 0.72F;
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
            this.textBox87.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox87.Height = 0.125F;
            this.textBox87.Left = 5.25F;
            this.textBox87.MultiLine = false;
            this.textBox87.Name = "textBox87";
            this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
            this.textBox87.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox87.SummaryGroup = "SectionHeader";
            this.textBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox87.Text = "1,234,567,890";
            this.textBox87.Top = 0.125F;
            this.textBox87.Width = 0.72F;
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
            this.textBox88.DataField = "TotalPureSalesTaxRate1";
            this.textBox88.Height = 0.125F;
            this.textBox88.Left = 5.9375F;
            this.textBox88.MultiLine = false;
            this.textBox88.Name = "textBox88";
            this.textBox88.OutputFormat = resources.GetString("textBox88.OutputFormat");
            this.textBox88.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox88.SummaryGroup = "SectionHeader";
            this.textBox88.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox88.Text = "1,234,567,890";
            this.textBox88.Top = 0.125F;
            this.textBox88.Width = 0.72F;
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
            this.textBox89.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox89.Height = 0.125F;
            this.textBox89.Left = 6.625F;
            this.textBox89.MultiLine = false;
            this.textBox89.Name = "textBox89";
            this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
            this.textBox89.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox89.SummaryGroup = "SectionHeader";
            this.textBox89.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox89.Text = "1,234,567,890";
            this.textBox89.Top = 0.125F;
            this.textBox89.Width = 0.72F;
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
            this.textBox90.DataField = "TotalThisSalesSumTaxRate1";
            this.textBox90.Height = 0.125F;
            this.textBox90.Left = 7.3125F;
            this.textBox90.MultiLine = false;
            this.textBox90.Name = "textBox90";
            this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
            this.textBox90.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox90.SummaryGroup = "SectionHeader";
            this.textBox90.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox90.Text = "1,234,567,890";
            this.textBox90.Top = 0.125F;
            this.textBox90.Width = 0.72F;
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
            this.textBox91.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox91.Height = 0.125F;
            this.textBox91.Left = 9.5F;
            this.textBox91.MultiLine = false;
            this.textBox91.Name = "textBox91";
            this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
            this.textBox91.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox91.SummaryGroup = "SectionHeader";
            this.textBox91.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox91.Text = "123,456";
            this.textBox91.Top = 0.125F;
            this.textBox91.Width = 0.605F;
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
            this.textBox92.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox92.Height = 0.125F;
            this.textBox92.Left = 4.5625F;
            this.textBox92.MultiLine = false;
            this.textBox92.Name = "textBox92";
            this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
            this.textBox92.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox92.SummaryGroup = "SectionHeader";
            this.textBox92.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox92.Text = "1,234,567,890";
            this.textBox92.Top = 0.25F;
            this.textBox92.Width = 0.72F;
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
            this.textBox93.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox93.Height = 0.125F;
            this.textBox93.Left = 5.25F;
            this.textBox93.MultiLine = false;
            this.textBox93.Name = "textBox93";
            this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
            this.textBox93.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox93.SummaryGroup = "SectionHeader";
            this.textBox93.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox93.Text = "1,234,567,890";
            this.textBox93.Top = 0.25F;
            this.textBox93.Width = 0.72F;
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
            this.textBox94.DataField = "TotalPureSalesTaxRate2";
            this.textBox94.Height = 0.125F;
            this.textBox94.Left = 5.9375F;
            this.textBox94.MultiLine = false;
            this.textBox94.Name = "textBox94";
            this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
            this.textBox94.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox94.SummaryGroup = "SectionHeader";
            this.textBox94.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox94.Text = "1,234,567,890";
            this.textBox94.Top = 0.25F;
            this.textBox94.Width = 0.72F;
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
            this.textBox95.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox95.Height = 0.125F;
            this.textBox95.Left = 6.625F;
            this.textBox95.MultiLine = false;
            this.textBox95.Name = "textBox95";
            this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
            this.textBox95.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox95.SummaryGroup = "SectionHeader";
            this.textBox95.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox95.Text = "1,234,567,890";
            this.textBox95.Top = 0.25F;
            this.textBox95.Width = 0.72F;
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
            this.textBox96.DataField = "TotalThisSalesSumTaxRate2";
            this.textBox96.Height = 0.125F;
            this.textBox96.Left = 7.3125F;
            this.textBox96.MultiLine = false;
            this.textBox96.Name = "textBox96";
            this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
            this.textBox96.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox96.SummaryGroup = "SectionHeader";
            this.textBox96.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox96.Text = "1,234,567,890";
            this.textBox96.Top = 0.25F;
            this.textBox96.Width = 0.72F;
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
            this.textBox97.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox97.Height = 0.125F;
            this.textBox97.Left = 9.5F;
            this.textBox97.MultiLine = false;
            this.textBox97.Name = "textBox97";
            this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
            this.textBox97.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox97.SummaryGroup = "SectionHeader";
            this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox97.Text = "123,456";
            this.textBox97.Top = 0.25F;
            this.textBox97.Width = 0.605F;
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
            this.textBox98.DataField = "TotalThisTimeSalesOther";
            this.textBox98.Height = 0.125F;
            this.textBox98.Left = 4.5625F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox98.SummaryGroup = "SectionHeader";
            this.textBox98.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox98.Text = "1,234,567,890";
            this.textBox98.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox98.Width = 0.72F;
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
            this.textBox99.DataField = "TotalThisRgdsDisPricOther";
            this.textBox99.Height = 0.125F;
            this.textBox99.Left = 5.25F;
            this.textBox99.MultiLine = false;
            this.textBox99.Name = "textBox99";
            this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
            this.textBox99.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox99.SummaryGroup = "SectionHeader";
            this.textBox99.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox99.Text = "1,234,567,890";
            this.textBox99.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox99.Width = 0.72F;
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
            this.textBox100.DataField = "TotalPureSalesOther";
            this.textBox100.Height = 0.125F;
            this.textBox100.Left = 5.9375F;
            this.textBox100.MultiLine = false;
            this.textBox100.Name = "textBox100";
            this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
            this.textBox100.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox100.SummaryGroup = "SectionHeader";
            this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox100.Text = "1,234,567,890";
            this.textBox100.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox100.Width = 0.72F;
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
            this.textBox101.DataField = "TotalSalesPricTaxOther";
            this.textBox101.Height = 0.125F;
            this.textBox101.Left = 6.625F;
            this.textBox101.MultiLine = false;
            this.textBox101.Name = "textBox101";
            this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
            this.textBox101.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox101.SummaryGroup = "SectionHeader";
            this.textBox101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox101.Text = "1,234,567,890";
            this.textBox101.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox101.Width = 0.72F;
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
            this.textBox102.DataField = "TotalThisSalesSumTaxOther";
            this.textBox102.Height = 0.125F;
            this.textBox102.Left = 7.3125F;
            this.textBox102.MultiLine = false;
            this.textBox102.Name = "textBox102";
            this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
            this.textBox102.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox102.SummaryGroup = "SectionHeader";
            this.textBox102.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox102.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox102.Text = "1,234,567,890";
            this.textBox102.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox102.Width = 0.72F;
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
            this.textBox103.DataField = "TotalSalesSlipCountOther";
            this.textBox103.Height = 0.125F;
            this.textBox103.Left = 9.5F;
            this.textBox103.MultiLine = false;
            this.textBox103.Name = "textBox103";
            this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
            this.textBox103.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox103.SummaryGroup = "SectionHeader";
            this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox103.Text = "123,456";
            this.textBox103.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox103.Width = 0.605F;
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
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
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
            this.label15.Height = 0.125F;
            this.label15.HyperLink = null;
            this.label15.Left = 4F;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "非課税";
            this.label15.Top = 0.5F;
            this.label15.Width = 0.563F;
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
            this.textBox12.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 4.5625F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = "#,##0";
            this.textBox12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox12.SummaryGroup = "SectionHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "1,234,567,890";
            this.textBox12.Top = 0.5F;
            this.textBox12.Width = 0.72F;
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
            this.textBox13.Left = 5.25F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = "#,##0";
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox13.SummaryGroup = "SectionHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "1,234,567,890";
            this.textBox13.Top = 0.5F;
            this.textBox13.Width = 0.72F;
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
            this.textBox14.DataField = "TotalPureSalesTaxFree";
            this.textBox14.Height = 0.125F;
            this.textBox14.Left = 5.9375F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = "#,##0";
            this.textBox14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox14.SummaryGroup = "SectionHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "1,234,567,890";
            this.textBox14.Top = 0.5F;
            this.textBox14.Width = 0.72F;
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
            this.textBox15.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox15.Height = 0.125F;
            this.textBox15.Left = 6.625F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = "#,##0";
            this.textBox15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox15.SummaryGroup = "SectionHeader";
            this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox15.Text = "1,234,567,890";
            this.textBox15.Top = 0.5F;
            this.textBox15.Width = 0.72F;
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
            this.textBox17.DataField = "TotalThisSalesSumTaxFree";
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 7.3125F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = "#,##0";
            this.textBox17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox17.SummaryGroup = "SectionHeader";
            this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox17.Text = "1,234,567,890";
            this.textBox17.Top = 0.5F;
            this.textBox17.Width = 0.72F;
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
            this.textBox18.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox18.Height = 0.125F;
            this.textBox18.Left = 9.5F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = "#,##0";
            this.textBox18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox18.SummaryGroup = "SectionHeader";
            this.textBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox18.Text = "123,456";
            this.textBox18.Top = 0.5F;
            this.textBox18.Width = 0.605F;
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
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
            this.line6.Left = 0.0625F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 10.75F;
            this.line6.X1 = 0.0625F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.label8,
            this.g_DemandBalance2,
            this.g_ThisTimeDmdNrml2,
            this.g_ThisTimeTtlBlcDmd2,
            this.g_OfsThisTimeSales2,
            this.g_ThisSalesPricRgdsDis2,
            this.g_NetSales2,
            this.g_OfsThisSalesTax2,
            this.g_OfsThisSalesSum2,
            this.g_AfCalDemandPrice2,
            this.g_SaleslSlipCount2,
            this.g_AcpOdrTtl3TmBfBlDmd2,
            this.g_AcpOdrTtl2TmBfBlDmd2,
            this.g_LastTimeDemand2,
            this.g_MoneyKindDiv1012,
            this.g_MoneyKindDiv1022,
            this.g_MoneyKindDiv1072,
            this.g_MoneyKindDiv1052,
            this.g_MoneyKindDiv1062,
            this.g_MoneyKindDiv1092,
            this.g_MoneyKindDiv1122,
            this.g_ThisTimeFeeDmdNrml2,
            this.g_ThisTimeDisDmdNrml2,
            this.g_CollectRate2,
            this.g_CollectDemand2,
            this.textBox124,
            this.label9,
            this.label12,
            this.label13,
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
            this.textBox135,
            this.textBox136,
            this.textBox137,
            this.textBox138,
            this.textBox139,
            this.textBox140,
            this.textBox141,
            this.textBox142,
            this.line6,
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            this.label16,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24});
            this.GrandTotalFooter2.Height = 0.8541667F;
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            this.GrandTotalFooter2.KeepTogether = true;
            this.GrandTotalFooter2.Name = "GrandTotalFooter2";
            this.GrandTotalFooter2.BeforePrint += new System.EventHandler(this.GrandTotalFooter2_BeforePrint);
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
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 1.0625F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "総合計";
            this.label8.Top = 0F;
            this.label8.Width = 0.5625F;
            // 
            // g_DemandBalance2
            // 
            this.g_DemandBalance2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_DemandBalance2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_DemandBalance2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance2.Border.RightColor = System.Drawing.Color.Black;
            this.g_DemandBalance2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance2.Border.TopColor = System.Drawing.Color.Black;
            this.g_DemandBalance2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DemandBalance2.DataField = "DemandBalance";
            this.g_DemandBalance2.Height = 0.125F;
            this.g_DemandBalance2.Left = 2.5F;
            this.g_DemandBalance2.MultiLine = false;
            this.g_DemandBalance2.Name = "g_DemandBalance2";
            this.g_DemandBalance2.OutputFormat = resources.GetString("g_DemandBalance2.OutputFormat");
            this.g_DemandBalance2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_DemandBalance2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_DemandBalance2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_DemandBalance2.Text = "1,123,456,789";
            this.g_DemandBalance2.Top = 0F;
            this.g_DemandBalance2.Width = 0.72F;
            // 
            // g_ThisTimeDmdNrml2
            // 
            this.g_ThisTimeDmdNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeDmdNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDmdNrml2.DataField = "ThisTimeDmdNrml";
            this.g_ThisTimeDmdNrml2.Height = 0.125F;
            this.g_ThisTimeDmdNrml2.Left = 3.1875F;
            this.g_ThisTimeDmdNrml2.MultiLine = false;
            this.g_ThisTimeDmdNrml2.Name = "g_ThisTimeDmdNrml2";
            this.g_ThisTimeDmdNrml2.OutputFormat = resources.GetString("g_ThisTimeDmdNrml2.OutputFormat");
            this.g_ThisTimeDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDmdNrml2.Text = "1,123,456,789";
            this.g_ThisTimeDmdNrml2.Top = 0F;
            this.g_ThisTimeDmdNrml2.Width = 0.72F;
            // 
            // g_ThisTimeTtlBlcDmd2
            // 
            this.g_ThisTimeTtlBlcDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeTtlBlcDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeTtlBlcDmd2.DataField = "ThisTimeTtlBlcDmd";
            this.g_ThisTimeTtlBlcDmd2.Height = 0.125F;
            this.g_ThisTimeTtlBlcDmd2.Left = 3.875F;
            this.g_ThisTimeTtlBlcDmd2.MultiLine = false;
            this.g_ThisTimeTtlBlcDmd2.Name = "g_ThisTimeTtlBlcDmd2";
            this.g_ThisTimeTtlBlcDmd2.OutputFormat = resources.GetString("g_ThisTimeTtlBlcDmd2.OutputFormat");
            this.g_ThisTimeTtlBlcDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeTtlBlcDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeTtlBlcDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeTtlBlcDmd2.Text = "1,123,456,789";
            this.g_ThisTimeTtlBlcDmd2.Top = 0F;
            this.g_ThisTimeTtlBlcDmd2.Width = 0.72F;
            // 
            // g_OfsThisTimeSales2
            // 
            this.g_OfsThisTimeSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OfsThisTimeSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisTimeSales2.DataField = "ThisTimeSales";
            this.g_OfsThisTimeSales2.Height = 0.125F;
            this.g_OfsThisTimeSales2.Left = 4.5625F;
            this.g_OfsThisTimeSales2.MultiLine = false;
            this.g_OfsThisTimeSales2.Name = "g_OfsThisTimeSales2";
            this.g_OfsThisTimeSales2.OutputFormat = resources.GetString("g_OfsThisTimeSales2.OutputFormat");
            this.g_OfsThisTimeSales2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_OfsThisTimeSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OfsThisTimeSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OfsThisTimeSales2.Text = "1,123,456,789";
            this.g_OfsThisTimeSales2.Top = 0F;
            this.g_OfsThisTimeSales2.Width = 0.72F;
            // 
            // g_ThisSalesPricRgdsDis2
            // 
            this.g_ThisSalesPricRgdsDis2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisSalesPricRgdsDis2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisSalesPricRgdsDis2.DataField = "ThisSalesPricRgdsDis";
            this.g_ThisSalesPricRgdsDis2.Height = 0.125F;
            this.g_ThisSalesPricRgdsDis2.Left = 5.255F;
            this.g_ThisSalesPricRgdsDis2.MultiLine = false;
            this.g_ThisSalesPricRgdsDis2.Name = "g_ThisSalesPricRgdsDis2";
            this.g_ThisSalesPricRgdsDis2.OutputFormat = resources.GetString("g_ThisSalesPricRgdsDis2.OutputFormat");
            this.g_ThisSalesPricRgdsDis2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisSalesPricRgdsDis2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisSalesPricRgdsDis2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisSalesPricRgdsDis2.Text = "1,123,456,789";
            this.g_ThisSalesPricRgdsDis2.Top = 0F;
            this.g_ThisSalesPricRgdsDis2.Width = 0.72F;
            // 
            // g_NetSales2
            // 
            this.g_NetSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_NetSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_NetSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales2.Border.RightColor = System.Drawing.Color.Black;
            this.g_NetSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales2.Border.TopColor = System.Drawing.Color.Black;
            this.g_NetSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_NetSales2.DataField = "NetSales";
            this.g_NetSales2.Height = 0.125F;
            this.g_NetSales2.Left = 5.9375F;
            this.g_NetSales2.MultiLine = false;
            this.g_NetSales2.Name = "g_NetSales2";
            this.g_NetSales2.OutputFormat = resources.GetString("g_NetSales2.OutputFormat");
            this.g_NetSales2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_NetSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_NetSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_NetSales2.Text = "1,123,456,789";
            this.g_NetSales2.Top = 0F;
            this.g_NetSales2.Width = 0.72F;
            // 
            // g_OfsThisSalesTax2
            // 
            this.g_OfsThisSalesTax2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesTax2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesTax2.DataField = "OfsThisSalesTax";
            this.g_OfsThisSalesTax2.Height = 0.125F;
            this.g_OfsThisSalesTax2.Left = 6.625F;
            this.g_OfsThisSalesTax2.MultiLine = false;
            this.g_OfsThisSalesTax2.Name = "g_OfsThisSalesTax2";
            this.g_OfsThisSalesTax2.OutputFormat = resources.GetString("g_OfsThisSalesTax2.OutputFormat");
            this.g_OfsThisSalesTax2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_OfsThisSalesTax2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OfsThisSalesTax2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OfsThisSalesTax2.Text = "1,123,456,789";
            this.g_OfsThisSalesTax2.Top = 0F;
            this.g_OfsThisSalesTax2.Width = 0.72F;
            // 
            // g_OfsThisSalesSum2
            // 
            this.g_OfsThisSalesSum2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OfsThisSalesSum2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OfsThisSalesSum2.DataField = "OfsThisSalesSum";
            this.g_OfsThisSalesSum2.Height = 0.125F;
            this.g_OfsThisSalesSum2.Left = 7.3125F;
            this.g_OfsThisSalesSum2.MultiLine = false;
            this.g_OfsThisSalesSum2.Name = "g_OfsThisSalesSum2";
            this.g_OfsThisSalesSum2.OutputFormat = resources.GetString("g_OfsThisSalesSum2.OutputFormat");
            this.g_OfsThisSalesSum2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_OfsThisSalesSum2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OfsThisSalesSum2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OfsThisSalesSum2.Text = "1,123,456,789";
            this.g_OfsThisSalesSum2.Top = 0F;
            this.g_OfsThisSalesSum2.Width = 0.72F;
            // 
            // g_AfCalDemandPrice2
            // 
            this.g_AfCalDemandPrice2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice2.Border.RightColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice2.Border.TopColor = System.Drawing.Color.Black;
            this.g_AfCalDemandPrice2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AfCalDemandPrice2.DataField = "AfCalDemandPrice";
            this.g_AfCalDemandPrice2.Height = 0.125F;
            this.g_AfCalDemandPrice2.Left = 8.010417F;
            this.g_AfCalDemandPrice2.MultiLine = false;
            this.g_AfCalDemandPrice2.Name = "g_AfCalDemandPrice2";
            this.g_AfCalDemandPrice2.OutputFormat = resources.GetString("g_AfCalDemandPrice2.OutputFormat");
            this.g_AfCalDemandPrice2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_AfCalDemandPrice2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_AfCalDemandPrice2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_AfCalDemandPrice2.Text = "1,123,456,789";
            this.g_AfCalDemandPrice2.Top = 0F;
            this.g_AfCalDemandPrice2.Width = 0.72F;
            // 
            // g_SaleslSlipCount2
            // 
            this.g_SaleslSlipCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount2.Border.RightColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount2.Border.TopColor = System.Drawing.Color.Black;
            this.g_SaleslSlipCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SaleslSlipCount2.DataField = "SaleslSlipCount";
            this.g_SaleslSlipCount2.Height = 0.125F;
            this.g_SaleslSlipCount2.Left = 9.499F;
            this.g_SaleslSlipCount2.MultiLine = false;
            this.g_SaleslSlipCount2.Name = "g_SaleslSlipCount2";
            this.g_SaleslSlipCount2.OutputFormat = resources.GetString("g_SaleslSlipCount2.OutputFormat");
            this.g_SaleslSlipCount2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_SaleslSlipCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_SaleslSlipCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_SaleslSlipCount2.Text = "123,456";
            this.g_SaleslSlipCount2.Top = 0F;
            this.g_SaleslSlipCount2.Width = 0.605F;
            // 
            // g_AcpOdrTtl3TmBfBlDmd2
            // 
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl3TmBfBlDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl3TmBfBlDmd2.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.g_AcpOdrTtl3TmBfBlDmd2.Height = 0.125F;
            this.g_AcpOdrTtl3TmBfBlDmd2.Left = 2.5F;
            this.g_AcpOdrTtl3TmBfBlDmd2.MultiLine = false;
            this.g_AcpOdrTtl3TmBfBlDmd2.Name = "g_AcpOdrTtl3TmBfBlDmd2";
            this.g_AcpOdrTtl3TmBfBlDmd2.OutputFormat = resources.GetString("g_AcpOdrTtl3TmBfBlDmd2.OutputFormat");
            this.g_AcpOdrTtl3TmBfBlDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_AcpOdrTtl3TmBfBlDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_AcpOdrTtl3TmBfBlDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_AcpOdrTtl3TmBfBlDmd2.Text = "1,123,456,789";
            this.g_AcpOdrTtl3TmBfBlDmd2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_AcpOdrTtl3TmBfBlDmd2.Width = 0.72F;
            // 
            // g_AcpOdrTtl2TmBfBlDmd2
            // 
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.RightColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.TopColor = System.Drawing.Color.Black;
            this.g_AcpOdrTtl2TmBfBlDmd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AcpOdrTtl2TmBfBlDmd2.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.g_AcpOdrTtl2TmBfBlDmd2.Height = 0.125F;
            this.g_AcpOdrTtl2TmBfBlDmd2.Left = 3.1875F;
            this.g_AcpOdrTtl2TmBfBlDmd2.MultiLine = false;
            this.g_AcpOdrTtl2TmBfBlDmd2.Name = "g_AcpOdrTtl2TmBfBlDmd2";
            this.g_AcpOdrTtl2TmBfBlDmd2.OutputFormat = resources.GetString("g_AcpOdrTtl2TmBfBlDmd2.OutputFormat");
            this.g_AcpOdrTtl2TmBfBlDmd2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_AcpOdrTtl2TmBfBlDmd2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_AcpOdrTtl2TmBfBlDmd2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_AcpOdrTtl2TmBfBlDmd2.Text = "1,123,456,789";
            this.g_AcpOdrTtl2TmBfBlDmd2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_AcpOdrTtl2TmBfBlDmd2.Width = 0.72F;
            // 
            // g_LastTimeDemand2
            // 
            this.g_LastTimeDemand2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand2.Border.RightColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand2.Border.TopColor = System.Drawing.Color.Black;
            this.g_LastTimeDemand2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_LastTimeDemand2.DataField = "LastTimeDemand";
            this.g_LastTimeDemand2.Height = 0.125F;
            this.g_LastTimeDemand2.Left = 3.875F;
            this.g_LastTimeDemand2.MultiLine = false;
            this.g_LastTimeDemand2.Name = "g_LastTimeDemand2";
            this.g_LastTimeDemand2.OutputFormat = resources.GetString("g_LastTimeDemand2.OutputFormat");
            this.g_LastTimeDemand2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_LastTimeDemand2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_LastTimeDemand2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_LastTimeDemand2.Text = "1,123,456,789";
            this.g_LastTimeDemand2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_LastTimeDemand2.Width = 0.72F;
            // 
            // g_MoneyKindDiv1012
            // 
            this.g_MoneyKindDiv1012.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1012.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1012.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1012.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1012.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1012.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1012.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1012.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1012.DataField = "MoneyKindDiv101";
            this.g_MoneyKindDiv1012.Height = 0.125F;
            this.g_MoneyKindDiv1012.Left = 4.5625F;
            this.g_MoneyKindDiv1012.MultiLine = false;
            this.g_MoneyKindDiv1012.Name = "g_MoneyKindDiv1012";
            this.g_MoneyKindDiv1012.OutputFormat = resources.GetString("g_MoneyKindDiv1012.OutputFormat");
            this.g_MoneyKindDiv1012.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1012.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1012.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1012.Text = "1,123,456,789";
            this.g_MoneyKindDiv1012.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1012.Width = 0.72F;
            // 
            // g_MoneyKindDiv1022
            // 
            this.g_MoneyKindDiv1022.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1022.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1022.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1022.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1022.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1022.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1022.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1022.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1022.DataField = "MoneyKindDiv102";
            this.g_MoneyKindDiv1022.Height = 0.125F;
            this.g_MoneyKindDiv1022.Left = 5.25F;
            this.g_MoneyKindDiv1022.MultiLine = false;
            this.g_MoneyKindDiv1022.Name = "g_MoneyKindDiv1022";
            this.g_MoneyKindDiv1022.OutputFormat = resources.GetString("g_MoneyKindDiv1022.OutputFormat");
            this.g_MoneyKindDiv1022.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1022.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1022.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1022.Text = "1,123,456,789";
            this.g_MoneyKindDiv1022.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1022.Width = 0.72F;
            // 
            // g_MoneyKindDiv1072
            // 
            this.g_MoneyKindDiv1072.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1072.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1072.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1072.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1072.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1072.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1072.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1072.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1072.DataField = "MoneyKindDiv107";
            this.g_MoneyKindDiv1072.Height = 0.125F;
            this.g_MoneyKindDiv1072.Left = 5.9375F;
            this.g_MoneyKindDiv1072.MultiLine = false;
            this.g_MoneyKindDiv1072.Name = "g_MoneyKindDiv1072";
            this.g_MoneyKindDiv1072.OutputFormat = resources.GetString("g_MoneyKindDiv1072.OutputFormat");
            this.g_MoneyKindDiv1072.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1072.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1072.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1072.Text = "1,123,456,789";
            this.g_MoneyKindDiv1072.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1072.Width = 0.72F;
            // 
            // g_MoneyKindDiv1052
            // 
            this.g_MoneyKindDiv1052.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1052.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1052.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1052.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1052.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1052.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1052.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1052.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1052.DataField = "MoneyKindDiv105";
            this.g_MoneyKindDiv1052.Height = 0.125F;
            this.g_MoneyKindDiv1052.Left = 6.625F;
            this.g_MoneyKindDiv1052.MultiLine = false;
            this.g_MoneyKindDiv1052.Name = "g_MoneyKindDiv1052";
            this.g_MoneyKindDiv1052.OutputFormat = resources.GetString("g_MoneyKindDiv1052.OutputFormat");
            this.g_MoneyKindDiv1052.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1052.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1052.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1052.Text = "1,123,456,789";
            this.g_MoneyKindDiv1052.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1052.Width = 0.72F;
            // 
            // g_MoneyKindDiv1062
            // 
            this.g_MoneyKindDiv1062.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1062.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1062.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1062.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1062.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1062.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1062.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1062.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1062.DataField = "MoneyKindDiv106";
            this.g_MoneyKindDiv1062.Height = 0.125F;
            this.g_MoneyKindDiv1062.Left = 7.3125F;
            this.g_MoneyKindDiv1062.MultiLine = false;
            this.g_MoneyKindDiv1062.Name = "g_MoneyKindDiv1062";
            this.g_MoneyKindDiv1062.OutputFormat = resources.GetString("g_MoneyKindDiv1062.OutputFormat");
            this.g_MoneyKindDiv1062.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1062.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1062.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1062.Text = "1,123,456,789";
            this.g_MoneyKindDiv1062.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1062.Width = 0.72F;
            // 
            // g_MoneyKindDiv1092
            // 
            this.g_MoneyKindDiv1092.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1092.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1092.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1092.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1092.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1092.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1092.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1092.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1092.DataField = "MoneyKindDiv109";
            this.g_MoneyKindDiv1092.Height = 0.125F;
            this.g_MoneyKindDiv1092.Left = 8F;
            this.g_MoneyKindDiv1092.MultiLine = false;
            this.g_MoneyKindDiv1092.Name = "g_MoneyKindDiv1092";
            this.g_MoneyKindDiv1092.OutputFormat = resources.GetString("g_MoneyKindDiv1092.OutputFormat");
            this.g_MoneyKindDiv1092.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1092.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1092.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1092.Text = "1,123,456,789";
            this.g_MoneyKindDiv1092.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1092.Width = 0.72F;
            // 
            // g_MoneyKindDiv1122
            // 
            this.g_MoneyKindDiv1122.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1122.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1122.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1122.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoneyKindDiv1122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoneyKindDiv1122.DataField = "MoneyKindDiv112";
            this.g_MoneyKindDiv1122.Height = 0.125F;
            this.g_MoneyKindDiv1122.Left = 8.6875F;
            this.g_MoneyKindDiv1122.MultiLine = false;
            this.g_MoneyKindDiv1122.Name = "g_MoneyKindDiv1122";
            this.g_MoneyKindDiv1122.OutputFormat = resources.GetString("g_MoneyKindDiv1122.OutputFormat");
            this.g_MoneyKindDiv1122.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MoneyKindDiv1122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoneyKindDiv1122.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoneyKindDiv1122.Text = "1,123,456,789";
            this.g_MoneyKindDiv1122.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_MoneyKindDiv1122.Width = 0.72F;
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
            this.g_ThisTimeFeeDmdNrml2.Left = 9.375F;
            this.g_ThisTimeFeeDmdNrml2.MultiLine = false;
            this.g_ThisTimeFeeDmdNrml2.Name = "g_ThisTimeFeeDmdNrml2";
            this.g_ThisTimeFeeDmdNrml2.OutputFormat = resources.GetString("g_ThisTimeFeeDmdNrml2.OutputFormat");
            this.g_ThisTimeFeeDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeFeeDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeFeeDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeFeeDmdNrml2.Text = "1,123,456,789";
            this.g_ThisTimeFeeDmdNrml2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_ThisTimeFeeDmdNrml2.Width = 0.72F;
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
            this.g_ThisTimeDisDmdNrml2.Left = 10.0625F;
            this.g_ThisTimeDisDmdNrml2.MultiLine = false;
            this.g_ThisTimeDisDmdNrml2.Name = "g_ThisTimeDisDmdNrml2";
            this.g_ThisTimeDisDmdNrml2.OutputFormat = resources.GetString("g_ThisTimeDisDmdNrml2.OutputFormat");
            this.g_ThisTimeDisDmdNrml2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_ThisTimeDisDmdNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDisDmdNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDisDmdNrml2.Text = "1,123,456,789";
            this.g_ThisTimeDisDmdNrml2.Top = 0.625F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.g_ThisTimeDisDmdNrml2.Width = 0.72F;
            // 
            // g_CollectRate2
            // 
            this.g_CollectRate2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CollectRate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CollectRate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate2.Border.RightColor = System.Drawing.Color.Black;
            this.g_CollectRate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate2.Border.TopColor = System.Drawing.Color.Black;
            this.g_CollectRate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectRate2.Height = 0.125F;
            this.g_CollectRate2.Left = 8.791668F;
            this.g_CollectRate2.MultiLine = false;
            this.g_CollectRate2.Name = "g_CollectRate2";
            this.g_CollectRate2.OutputFormat = resources.GetString("g_CollectRate2.OutputFormat");
            this.g_CollectRate2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_CollectRate2.Text = "123.00";
            this.g_CollectRate2.Top = 0F;
            this.g_CollectRate2.Width = 0.5F;
            // 
            // g_CollectDemand2
            // 
            this.g_CollectDemand2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CollectDemand2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CollectDemand2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand2.Border.RightColor = System.Drawing.Color.Black;
            this.g_CollectDemand2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand2.Border.TopColor = System.Drawing.Color.Black;
            this.g_CollectDemand2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectDemand2.DataField = "CollectDemand";
            this.g_CollectDemand2.Height = 0.125F;
            this.g_CollectDemand2.Left = 0F;
            this.g_CollectDemand2.Name = "g_CollectDemand2";
            this.g_CollectDemand2.OutputFormat = resources.GetString("g_CollectDemand2.OutputFormat");
            this.g_CollectDemand2.Style = "text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.g_CollectDemand2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CollectDemand2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CollectDemand2.Text = null;
            this.g_CollectDemand2.Top = 0F;
            this.g_CollectDemand2.Visible = false;
            this.g_CollectDemand2.Width = 0.4375F;
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
            this.textBox124.Height = 0.125F;
            this.textBox124.Left = 9.281251F;
            this.textBox124.Name = "textBox124";
            this.textBox124.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.textBox124.Text = "%";
            this.textBox124.Top = 0F;
            this.textBox124.Width = 0.125F;
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
            this.label9.Height = 0.125F;
            this.label9.HyperLink = null;
            this.label9.Left = 4F;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "10%";
            this.label9.Top = 0.125F;
            this.label9.Width = 0.563F;
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
            this.label12.Height = 0.125F;
            this.label12.HyperLink = null;
            this.label12.Left = 4F;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "8%";
            this.label12.Top = 0.25F;
            this.label12.Width = 0.563F;
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
            this.label13.Left = 4F;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "その他";
            this.label13.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.label13.Width = 0.563F;
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
            this.textBox125.DataField = "TotalThisTimeSalesTaxRate1";
            this.textBox125.Height = 0.125F;
            this.textBox125.Left = 4.5625F;
            this.textBox125.MultiLine = false;
            this.textBox125.Name = "textBox125";
            this.textBox125.OutputFormat = resources.GetString("textBox125.OutputFormat");
            this.textBox125.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox125.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox125.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox125.Text = "1,234,567,890";
            this.textBox125.Top = 0.125F;
            this.textBox125.Width = 0.72F;
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
            this.textBox126.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox126.Height = 0.125F;
            this.textBox126.Left = 5.25F;
            this.textBox126.MultiLine = false;
            this.textBox126.Name = "textBox126";
            this.textBox126.OutputFormat = resources.GetString("textBox126.OutputFormat");
            this.textBox126.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox126.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox126.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox126.Text = "1,234,567,890";
            this.textBox126.Top = 0.125F;
            this.textBox126.Width = 0.72F;
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
            this.textBox127.DataField = "TotalPureSalesTaxRate1";
            this.textBox127.Height = 0.125F;
            this.textBox127.Left = 5.9375F;
            this.textBox127.MultiLine = false;
            this.textBox127.Name = "textBox127";
            this.textBox127.OutputFormat = resources.GetString("textBox127.OutputFormat");
            this.textBox127.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox127.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox127.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox127.Text = "1,234,567,890";
            this.textBox127.Top = 0.125F;
            this.textBox127.Width = 0.72F;
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
            this.textBox128.DataField = "TotalSalesPricTaxTaxRate1";
            this.textBox128.Height = 0.125F;
            this.textBox128.Left = 6.625F;
            this.textBox128.MultiLine = false;
            this.textBox128.Name = "textBox128";
            this.textBox128.OutputFormat = resources.GetString("textBox128.OutputFormat");
            this.textBox128.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox128.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox128.Text = "1,234,567,890";
            this.textBox128.Top = 0.125F;
            this.textBox128.Width = 0.72F;
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
            this.textBox129.DataField = "TotalThisSalesSumTaxRate1";
            this.textBox129.Height = 0.125F;
            this.textBox129.Left = 7.3125F;
            this.textBox129.MultiLine = false;
            this.textBox129.Name = "textBox129";
            this.textBox129.OutputFormat = resources.GetString("textBox129.OutputFormat");
            this.textBox129.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox129.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox129.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox129.Text = "1,234,567,890";
            this.textBox129.Top = 0.125F;
            this.textBox129.Width = 0.72F;
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
            this.textBox130.DataField = "TotalSalesSlipCountTaxRate1";
            this.textBox130.Height = 0.125F;
            this.textBox130.Left = 9.5F;
            this.textBox130.MultiLine = false;
            this.textBox130.Name = "textBox130";
            this.textBox130.OutputFormat = resources.GetString("textBox130.OutputFormat");
            this.textBox130.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox130.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox130.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox130.Text = "123,456";
            this.textBox130.Top = 0.125F;
            this.textBox130.Width = 0.605F;
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
            this.textBox131.DataField = "TotalThisTimeSalesTaxRate2";
            this.textBox131.Height = 0.125F;
            this.textBox131.Left = 4.5625F;
            this.textBox131.MultiLine = false;
            this.textBox131.Name = "textBox131";
            this.textBox131.OutputFormat = resources.GetString("textBox131.OutputFormat");
            this.textBox131.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox131.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox131.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox131.Text = "1,234,567,890";
            this.textBox131.Top = 0.25F;
            this.textBox131.Width = 0.72F;
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
            this.textBox132.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox132.Height = 0.125F;
            this.textBox132.Left = 5.25F;
            this.textBox132.MultiLine = false;
            this.textBox132.Name = "textBox132";
            this.textBox132.OutputFormat = resources.GetString("textBox132.OutputFormat");
            this.textBox132.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox132.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox132.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox132.Text = "1,234,567,890";
            this.textBox132.Top = 0.25F;
            this.textBox132.Width = 0.72F;
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
            this.textBox133.DataField = "TotalPureSalesTaxRate2";
            this.textBox133.Height = 0.125F;
            this.textBox133.Left = 5.9375F;
            this.textBox133.MultiLine = false;
            this.textBox133.Name = "textBox133";
            this.textBox133.OutputFormat = resources.GetString("textBox133.OutputFormat");
            this.textBox133.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox133.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox133.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox133.Text = "1,234,567,890";
            this.textBox133.Top = 0.25F;
            this.textBox133.Width = 0.72F;
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
            this.textBox134.DataField = "TotalSalesPricTaxTaxRate2";
            this.textBox134.Height = 0.125F;
            this.textBox134.Left = 6.625F;
            this.textBox134.MultiLine = false;
            this.textBox134.Name = "textBox134";
            this.textBox134.OutputFormat = resources.GetString("textBox134.OutputFormat");
            this.textBox134.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox134.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox134.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox134.Text = "1,234,567,890";
            this.textBox134.Top = 0.25F;
            this.textBox134.Width = 0.72F;
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
            this.textBox135.DataField = "TotalThisSalesSumTaxRate2";
            this.textBox135.Height = 0.125F;
            this.textBox135.Left = 7.3125F;
            this.textBox135.MultiLine = false;
            this.textBox135.Name = "textBox135";
            this.textBox135.OutputFormat = resources.GetString("textBox135.OutputFormat");
            this.textBox135.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox135.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox135.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox135.Text = "1,234,567,890";
            this.textBox135.Top = 0.25F;
            this.textBox135.Width = 0.72F;
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
            this.textBox136.DataField = "TotalSalesSlipCountTaxRate2";
            this.textBox136.Height = 0.125F;
            this.textBox136.Left = 9.5F;
            this.textBox136.MultiLine = false;
            this.textBox136.Name = "textBox136";
            this.textBox136.OutputFormat = resources.GetString("textBox136.OutputFormat");
            this.textBox136.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox136.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox136.Text = "123,456";
            this.textBox136.Top = 0.25F;
            this.textBox136.Width = 0.605F;
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
            this.textBox137.DataField = "TotalThisTimeSalesOther";
            this.textBox137.Height = 0.125F;
            this.textBox137.Left = 4.5625F;
            this.textBox137.MultiLine = false;
            this.textBox137.Name = "textBox137";
            this.textBox137.OutputFormat = resources.GetString("textBox137.OutputFormat");
            this.textBox137.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox137.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox137.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox137.Text = "1,234,567,890";
            this.textBox137.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox137.Width = 0.72F;
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
            this.textBox138.DataField = "TotalThisRgdsDisPricOther";
            this.textBox138.Height = 0.125F;
            this.textBox138.Left = 5.25F;
            this.textBox138.MultiLine = false;
            this.textBox138.Name = "textBox138";
            this.textBox138.OutputFormat = resources.GetString("textBox138.OutputFormat");
            this.textBox138.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox138.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox138.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox138.Text = "1,234,567,890";
            this.textBox138.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox138.Width = 0.72F;
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
            this.textBox139.DataField = "TotalPureSalesOther";
            this.textBox139.Height = 0.125F;
            this.textBox139.Left = 5.9375F;
            this.textBox139.MultiLine = false;
            this.textBox139.Name = "textBox139";
            this.textBox139.OutputFormat = resources.GetString("textBox139.OutputFormat");
            this.textBox139.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox139.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox139.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox139.Text = "1,234,567,890";
            this.textBox139.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox139.Width = 0.72F;
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
            this.textBox140.DataField = "TotalSalesPricTaxOther";
            this.textBox140.Height = 0.125F;
            this.textBox140.Left = 6.625F;
            this.textBox140.MultiLine = false;
            this.textBox140.Name = "textBox140";
            this.textBox140.OutputFormat = resources.GetString("textBox140.OutputFormat");
            this.textBox140.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox140.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox140.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox140.Text = "1,234,567,890";
            this.textBox140.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox140.Width = 0.72F;
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
            this.textBox141.DataField = "TotalThisSalesSumTaxOther";
            this.textBox141.Height = 0.125F;
            this.textBox141.Left = 7.3125F;
            this.textBox141.MultiLine = false;
            this.textBox141.Name = "textBox141";
            this.textBox141.OutputFormat = resources.GetString("textBox141.OutputFormat");
            this.textBox141.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox141.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox141.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox141.Text = "1,234,567,890";
            this.textBox141.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox141.Width = 0.72F;
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
            this.textBox142.DataField = "TotalSalesSlipCountOther";
            this.textBox142.Height = 0.125F;
            this.textBox142.Left = 9.5F;
            this.textBox142.MultiLine = false;
            this.textBox142.Name = "textBox142";
            this.textBox142.OutputFormat = resources.GetString("textBox142.OutputFormat");
            this.textBox142.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox142.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox142.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox142.Text = "123,456";
            this.textBox142.Top = 0.375F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox142.Width = 0.605F;
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
            this.label16.Left = 4F;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "非課税";
            this.label16.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.label16.Width = 0.563F;
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
            this.textBox19.DataField = "TotalThisTimeSalesTaxFree";
            this.textBox19.Height = 0.125F;
            this.textBox19.Left = 4.5625F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = "#,##0";
            this.textBox19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox19.Text = "1,234,567,890";
            this.textBox19.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox19.Width = 0.72F;
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
            this.textBox20.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox20.Height = 0.125F;
            this.textBox20.Left = 5.25F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = "#,##0";
            this.textBox20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox20.Text = "1,234,567,890";
            this.textBox20.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox20.Width = 0.72F;
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
            this.textBox21.DataField = "TotalPureSalesTaxFree";
            this.textBox21.Height = 0.125F;
            this.textBox21.Left = 5.9375F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = "#,##0";
            this.textBox21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox21.Text = "1,234,567,890";
            this.textBox21.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox21.Width = 0.72F;
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
            this.textBox22.DataField = "TotalSalesPricTaxTaxFree";
            this.textBox22.Height = 0.125F;
            this.textBox22.Left = 6.625F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = "#,##0";
            this.textBox22.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox22.Text = "1,234,567,890";
            this.textBox22.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox22.Width = 0.72F;
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
            this.textBox23.DataField = "TotalThisSalesSumTaxFree";
            this.textBox23.Height = 0.125F;
            this.textBox23.Left = 7.3125F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = "#,##0";
            this.textBox23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox23.Text = "1,234,567,890";
            this.textBox23.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox23.Width = 0.72F;
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
            this.textBox24.DataField = "TotalSalesSlipCountTaxFree";
            this.textBox24.Height = 0.125F;
            this.textBox24.Left = 9.5F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = "#,##0";
            this.textBox24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox24.Text = "123,456";
            this.textBox24.Top = 0.5F;// --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            this.textBox24.Width = 0.605F;
            // 
            // MAKAU02020P_01A4C
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
            this.PrintWidth = 10.9375F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.GrandTotalHeader2);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SectionHeader2);
            this.Sections.Add(this.EmployeeHeader);
            this.Sections.Add(this.EmployeeHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.EmployeeFooter2);
            this.Sections.Add(this.EmployeeFooter);
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
            this.ReportStart += new System.EventHandler(this.MAKAU02020P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.CollectDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectMoneyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectMoneyDayNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleslSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemandBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalDemandPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisSalesPricRgdsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyKindDiv112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Null)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Name2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Name1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_AcpOdrTtl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_AcpOdrTtl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_MoneyKindDiv112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisSalesPricRgdsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AfCalDemandPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeTtlBlcDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DemandBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_NetSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SaleslSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_sec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisSalesPricRgdsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AfCalDemandPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeTtlBlcDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_DemandBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_SaleslSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_NetSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_emp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DemandBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeTtlBlcDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisSalesPricRgdsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_NetSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AfCalDemandPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SaleslSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisSalesPricRgdsDis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AfCalDemandPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesSum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisSalesTax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_OfsThisTimeSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeTtlBlcDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_DemandBalance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_SaleslSlipCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_NetSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl3TmBfBlDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1092)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1062)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1052)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1012)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_LastTimeDemand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_AcpOdrTtl2TmBfBlDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1022)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1072)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_MoneyKindDiv1122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_ThisTimeDisDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_CollectDemand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_emp2)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleTaxRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TaxTotalTitleOther)).EndInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisSalesPricRgdsDis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AfCalDemandPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesSum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisSalesTax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OfsThisTimeSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeTtlBlcDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DemandBalance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_NetSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SaleslSlipCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl3TmBfBlDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1092)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1062)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1052)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1012)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_LastTimeDemand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_AcpOdrTtl2TmBfBlDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1022)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1072)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoneyKindDiv1122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CollectDemand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_sec2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DemandBalance2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeTtlBlcDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisTimeSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisSalesPricRgdsDis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_NetSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesTax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OfsThisSalesSum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AfCalDemandPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SaleslSlipCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl3TmBfBlDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AcpOdrTtl2TmBfBlDmd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_LastTimeDemand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1012)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1022)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1072)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1052)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1062)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1092)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoneyKindDiv1122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeeDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisDmdNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectDemand2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox142)).EndInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            // --- ADD 2022/08/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
