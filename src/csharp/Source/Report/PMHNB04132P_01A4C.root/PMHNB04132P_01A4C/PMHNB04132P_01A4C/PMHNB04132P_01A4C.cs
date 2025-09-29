using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 得意先別過年度統計表帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 得意先別過年度統計表帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.10.31</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMHNB04132P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB04132P_01A4C()
        {
            InitializeComponent();
        }

        #endregion

        #region ■ private変数

        private int _printCount;						// 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;		// 抽出条件
        private int _pageFooterOutCode;				    // フッター出力区分
        private StringCollection _pageFooters;			// フッターメッセージ
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        private CustFinancialListCndtn _custFinancialListCndtn;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        #region ■ ActiveReport生成
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
        private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox tb_PrintDate;
        private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        private DataDynamics.ActiveReports.Label Lb_Year8;
        private DataDynamics.ActiveReports.TextBox uYear8;
        private DataDynamics.ActiveReports.TextBox uYear7;
        private DataDynamics.ActiveReports.TextBox uYear1;
        private DataDynamics.ActiveReports.TextBox uYear2;
        private DataDynamics.ActiveReports.TextBox uYear3;
        private DataDynamics.ActiveReports.TextBox uYear4;
        private DataDynamics.ActiveReports.TextBox uYear5;
        private DataDynamics.ActiveReports.TextBox uYear6;
        private DataDynamics.ActiveReports.TextBox CodeName;
        private DataDynamics.ActiveReports.TextBox Code;
        private DataDynamics.ActiveReports.Label Lb_Year1;
        private DataDynamics.ActiveReports.Label Lb_Year2;
        private DataDynamics.ActiveReports.Label Lb_Year3;
        private DataDynamics.ActiveReports.Label Lb_Year4;
        private DataDynamics.ActiveReports.Label Lb_Year5;
        private DataDynamics.ActiveReports.Label Lb_Year6;
        private DataDynamics.ActiveReports.Label Lb_Year7;
        private DataDynamics.ActiveReports.Label Lb_SectionTitle;
        private DataDynamics.ActiveReports.Label Lb_CustomerTitle;
        private DataDynamics.ActiveReports.TextBox dYear8;
        private DataDynamics.ActiveReports.TextBox dYear7;
        private DataDynamics.ActiveReports.TextBox dYear1;
        private DataDynamics.ActiveReports.TextBox dYear2;
        private DataDynamics.ActiveReports.TextBox dYear3;
        private DataDynamics.ActiveReports.TextBox dYear4;
        private DataDynamics.ActiveReports.TextBox dYear5;
        private DataDynamics.ActiveReports.TextBox dYear6;
        private DataDynamics.ActiveReports.TextBox SecHd_SectionCode;
        private DataDynamics.ActiveReports.TextBox SecHd_SectionName;
        private DataDynamics.ActiveReports.Line SecHd_line;
        private DataDynamics.ActiveReports.TextBox CusHd_CustomerCode;
        private DataDynamics.ActiveReports.TextBox CusHd_CustomerName;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.Label GrandTotalTitle;
        private DataDynamics.ActiveReports.TextBox SectionTitle;
        private DataDynamics.ActiveReports.TextBox textBox98;
        private DataDynamics.ActiveReports.TextBox Cus_uYear8;
        private DataDynamics.ActiveReports.TextBox Cus_uYear7;
        private DataDynamics.ActiveReports.TextBox Cus_uYear1;
        private DataDynamics.ActiveReports.TextBox Cus_uYear2;
        private DataDynamics.ActiveReports.TextBox Cus_uYear3;
        private DataDynamics.ActiveReports.TextBox Cus_uYear4;
        private DataDynamics.ActiveReports.TextBox Cus_uYear5;
        private DataDynamics.ActiveReports.TextBox Cus_uYear6;
        private DataDynamics.ActiveReports.TextBox Cus_dYear8;
        private DataDynamics.ActiveReports.TextBox Cus_dYear7;
        private DataDynamics.ActiveReports.TextBox Cus_dYear1;
        private DataDynamics.ActiveReports.TextBox Cus_dYear2;
        private DataDynamics.ActiveReports.TextBox Cus_dYear3;
        private DataDynamics.ActiveReports.TextBox Cus_dYear4;
        private DataDynamics.ActiveReports.TextBox Cus_dYear5;
        private DataDynamics.ActiveReports.TextBox Cus_dYear6;
        private DataDynamics.ActiveReports.TextBox Gra_uYear8;
        private DataDynamics.ActiveReports.TextBox Gra_uYear7;
        private DataDynamics.ActiveReports.TextBox Gra_uYear1;
        private DataDynamics.ActiveReports.TextBox Gra_uYear2;
        private DataDynamics.ActiveReports.TextBox Gra_uYear3;
        private DataDynamics.ActiveReports.TextBox Gra_uYear4;
        private DataDynamics.ActiveReports.TextBox Gra_uYear5;
        private DataDynamics.ActiveReports.TextBox Gra_uYear6;
        private DataDynamics.ActiveReports.TextBox Gra_dYear8;
        private DataDynamics.ActiveReports.TextBox Gra_dYear7;
        private DataDynamics.ActiveReports.TextBox Gra_dYear1;
        private DataDynamics.ActiveReports.TextBox Gra_dYear2;
        private DataDynamics.ActiveReports.TextBox Gra_dYear3;
        private DataDynamics.ActiveReports.TextBox Gra_dYear4;
        private DataDynamics.ActiveReports.TextBox Gra_dYear5;
        private DataDynamics.ActiveReports.TextBox Gra_dYear6;
        private DataDynamics.ActiveReports.TextBox Sec_uYear8;
        private DataDynamics.ActiveReports.TextBox Sec_uYear7;
        private DataDynamics.ActiveReports.TextBox Sec_uYear1;
        private DataDynamics.ActiveReports.TextBox Sec_uYear2;
        private DataDynamics.ActiveReports.TextBox Sec_uYear3;
        private DataDynamics.ActiveReports.TextBox Sec_uYear4;
        private DataDynamics.ActiveReports.TextBox Sec_uYear5;
        private DataDynamics.ActiveReports.TextBox Sec_uYear6;
        private DataDynamics.ActiveReports.TextBox Sec_dYear8;
        private DataDynamics.ActiveReports.TextBox Sec_dYear7;
        private DataDynamics.ActiveReports.TextBox Sec_dYear1;
        private DataDynamics.ActiveReports.TextBox Sec_dYear2;
        private DataDynamics.ActiveReports.TextBox Sec_dYear3;
        private DataDynamics.ActiveReports.TextBox Sec_dYear4;
        private DataDynamics.ActiveReports.TextBox Sec_dYear5;
        private Line line6;
        private Line line5;
        private Line line8;
        private Line line7;
        private DataDynamics.ActiveReports.TextBox Sec_dYear6;
        #endregion
        #endregion

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
                this._custFinancialListCndtn = (CustFinancialListCndtn)this._printInfo.jyoken;
            }
        }

        /// <summary>
        /// その他データ
        /// </summary>
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>
        /// 帳票サブタイトル
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
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
                // TODO:  MAZAI02032P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  MAZAI02032P_01A4C.WatermarkMode setter 実装を追加します。
            }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■ privateメソッド
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //-------------------------------------------------------
            // 年度の設定（指定された期間のみ表示）
            //-------------------------------------------------------
            #region [年度範囲の適用]
            // 作業用にリスト生成
            #region [作業用リスト生成]
            ArrayList[] ctrlList = new ArrayList[8];

            // 年度1
            ctrlList[0] = new ArrayList();
            ctrlList[0].AddRange(new object[] { Lb_Year1 });
            ctrlList[0].AddRange(new object[] { Gra_uYear1, Sec_uYear1, Cus_uYear1, uYear1 });
            ctrlList[0].AddRange(new object[] { Gra_dYear1, Sec_dYear1, Cus_dYear1, dYear1 });

            // 年度2
            ctrlList[1] = new ArrayList();
            ctrlList[1].AddRange(new object[] { Lb_Year2 });
            ctrlList[1].AddRange(new object[] { Gra_uYear2, Sec_uYear2, Cus_uYear2, uYear2 });
            ctrlList[1].AddRange(new object[] { Gra_dYear2, Sec_dYear2, Cus_dYear2, dYear2 });

            // 年度3
            ctrlList[2] = new ArrayList();
            ctrlList[2].AddRange(new object[] { Lb_Year3 });
            ctrlList[2].AddRange(new object[] { Gra_uYear3, Sec_uYear3, Cus_uYear3, uYear3 });
            ctrlList[2].AddRange(new object[] { Gra_dYear3, Sec_dYear3, Cus_dYear3, dYear3 });

            // 年度4
            ctrlList[3] = new ArrayList();
            ctrlList[3].AddRange(new object[] { Lb_Year4 });
            ctrlList[3].AddRange(new object[] { Gra_uYear4, Sec_uYear4, Cus_uYear4, uYear4 });
            ctrlList[3].AddRange(new object[] { Gra_dYear4, Sec_dYear4, Cus_dYear4, dYear4 });

            // 年度5
            ctrlList[4] = new ArrayList();
            ctrlList[4].AddRange(new object[] { Lb_Year5 });
            ctrlList[4].AddRange(new object[] { Gra_uYear5, Sec_uYear5, Cus_uYear5, uYear5 });
            ctrlList[4].AddRange(new object[] { Gra_dYear5, Sec_dYear5, Cus_dYear5, dYear5 });

            // 年度6
            ctrlList[5] = new ArrayList();
            ctrlList[5].AddRange(new object[] { Lb_Year6 });
            ctrlList[5].AddRange(new object[] { Gra_uYear6, Sec_uYear6, Cus_uYear6, uYear6 });
            ctrlList[5].AddRange(new object[] { Gra_dYear6, Sec_dYear6, Cus_dYear6, dYear6 });

            // 年度7
            ctrlList[6] = new ArrayList();
            ctrlList[6].AddRange(new object[] { Lb_Year7 });
            ctrlList[6].AddRange(new object[] { Gra_uYear7, Sec_uYear7, Cus_uYear7, uYear7 });
            ctrlList[6].AddRange(new object[] { Gra_dYear7, Sec_dYear7, Cus_dYear7, dYear7 });

            // 年度8
            ctrlList[7] = new ArrayList();
            ctrlList[7].AddRange(new object[] { Lb_Year8 });
            ctrlList[7].AddRange(new object[] { Gra_uYear8, Sec_uYear8, Cus_uYear8, uYear8 });
            ctrlList[7].AddRange(new object[] { Gra_dYear8, Sec_dYear8, Cus_dYear8, dYear8 });

            // 年度タイトルリスト
            // (※注意：年度タイトルラベルはこのリストにも、上記の年度毎のコントロールリストにも格納されます)
            List<Label> yearTitleList = new List<Label>();
            yearTitleList.AddRange(new Label[] { Lb_Year1, Lb_Year2, Lb_Year3, Lb_Year4, Lb_Year5, Lb_Year6, Lb_Year7, Lb_Year8 });

            #endregion

            // 月数の取得
            int yearRange = GetYearRange(this._custFinancialListCndtn.St_Year, this._custFinancialListCndtn.Ed_Year);


            if ((yearRange > 8) || (yearRange <= 0))
            {
                yearRange = 8;
            }

            // 印字有無を設定
            for (int index = 0; index < ctrlList.Length; index++)
            {
                // 月タイトル設定
                if (index < yearTitleList.Count)
                {
                    yearTitleList[index].Text = GetYearTitle(this._custFinancialListCndtn.St_Year, index);
                }

                // 印字有無設定
                foreach (object ctrl in ctrlList[index])
                {
                    if (ctrl is TextBox)
                    {
                        (ctrl as TextBox).Visible = (index < yearRange);   // 範囲内のみtrue
                    }
                    else if (ctrl is Label)
                    {
                        (ctrl as Label).Visible = (index < yearRange);     // 範囲内のみtrue
                    }
                }
            }
            #endregion

            //-------------------------------------------------------
            // 印字タイプ（上段・下段）の適用
            //-------------------------------------------------------
            #region [印刷タイプ（上段・下段）の適用]
            // 0:売上＆粗利 1:売上 2:粗利
            #region [作業用のリストを生成]
            // 上段項目リスト
            List<TextBox> uList = new List<TextBox>();
            uList.AddRange(new TextBox[] { uYear1, uYear2, uYear3, uYear4, uYear5, uYear6, uYear7, uYear8 });

            List<TextBox> Cus_uList = new List<TextBox>();
            Cus_uList.AddRange(new TextBox[] { Cus_uYear1, Cus_uYear2, Cus_uYear3, Cus_uYear4, Cus_uYear5, Cus_uYear6, Cus_uYear7, Cus_uYear8 });

            List<TextBox> Sec_uList = new List<TextBox>();
            Sec_uList.AddRange(new TextBox[] { Sec_uYear1, Sec_uYear2, Sec_uYear3, Sec_uYear4, Sec_uYear5, Sec_uYear6, Sec_uYear7, Sec_uYear8 });

            List<TextBox> Gra_uList = new List<TextBox>();
            Gra_uList.AddRange(new TextBox[] { Gra_uYear1, Gra_uYear2, Gra_uYear3, Gra_uYear4, Gra_uYear5, Gra_uYear6, Gra_uYear7, Gra_uYear8 });

            // 下段項目リスト
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { dYear1, dYear2, dYear3, dYear4, dYear5, dYear6, dYear7, dYear8 });

            List<TextBox> Cus_dList = new List<TextBox>();
            Cus_dList.AddRange(new TextBox[] { Cus_dYear1, Cus_dYear2, Cus_dYear3, Cus_dYear4, Cus_dYear5, Cus_dYear6, Cus_dYear7, Cus_dYear8 });

            List<TextBox> Sec_dList = new List<TextBox>();
            Sec_dList.AddRange(new TextBox[] { Sec_dYear1, Sec_dYear2, Sec_dYear3, Sec_dYear4, Sec_dYear5, Sec_dYear6, Sec_dYear7, Sec_dYear8 });

            List<TextBox> Gra_dList = new List<TextBox>();
            Gra_dList.AddRange(new TextBox[] { Gra_dYear1, Gra_dYear2, Gra_dYear3, Gra_dYear4, Gra_dYear5, Gra_dYear6, Gra_dYear7, Gra_dYear8 });

            #endregion

            // visible設定
            if ((this._custFinancialListCndtn.PrintMoneyDiv == CustFinancialListCndtn.PrintMoneyDivState.SalesMoney)
            || (this._custFinancialListCndtn.PrintMoneyDiv == CustFinancialListCndtn.PrintMoneyDivState.GrossProfit))
            {
                // 上段のみ　→　全ての下段を非印字にする
                for (int index = 0; index < dList.Count; index++)
                {
                    // 数量非印字
                    dList[index].Visible = false;
                    Cus_dList[index].Visible = false;
                    Sec_dList[index].Visible = false;
                    Gra_dList[index].Visible = false;
                }
            }
            else
            {
            }
            #endregion

            //-------------------------------------------------------
            // 印字Fieldの適用
            //-------------------------------------------------------
            #region [印字Fieldの適用]
            // 0:売上＆粗利 1:売上 2:粗利
            #region [作業用のリストを生成]
            // 売上金額
            List<string> SalesMoneyList = new List<string>();
            SalesMoneyList.AddRange(new string[] { "SalesMoney1", "SalesMoney2", "SalesMoney3", "SalesMoney4", "SalesMoney5", "SalesMoney6", "SalesMoney7", "SalesMoney8" });

            // 粗利金額
            List<string> GrossProfitList = new List<string>();
            GrossProfitList.AddRange(new string[] { "GrossProfit1", "GrossProfit2", "GrossProfit3", "GrossProfit4", "GrossProfit5", "GrossProfit6", "GrossProfit7", "GrossProfit8"});

            #endregion

            switch (_custFinancialListCndtn.PrintMoneyDiv)
            {
                //0:売上＆粗利
                case CustFinancialListCndtn.PrintMoneyDivState.SalesAndGross:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = SalesMoneyList[index];
                        Cus_uList[index].DataField = SalesMoneyList[index];
                        Sec_uList[index].DataField = SalesMoneyList[index];
                        Gra_uList[index].DataField = SalesMoneyList[index];
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = GrossProfitList[index];
                        Cus_dList[index].DataField = GrossProfitList[index];
                        Sec_dList[index].DataField = GrossProfitList[index];
                        Gra_dList[index].DataField = GrossProfitList[index];
                    }
                    break;
                //1:売上
                case CustFinancialListCndtn.PrintMoneyDivState.SalesMoney:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = SalesMoneyList[index];
                        Cus_uList[index].DataField = SalesMoneyList[index];
                        Sec_uList[index].DataField = SalesMoneyList[index];
                        Gra_uList[index].DataField = SalesMoneyList[index];
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = string.Empty;
                        Cus_dList[index].DataField = string.Empty;
                        Sec_dList[index].DataField = string.Empty;
                        Gra_dList[index].DataField = string.Empty;
                    }
                    break;
                //2:粗利
                case CustFinancialListCndtn.PrintMoneyDivState.GrossProfit:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = GrossProfitList[index];
                        Cus_uList[index].DataField = GrossProfitList[index];
                        Sec_uList[index].DataField = GrossProfitList[index];
                        Gra_uList[index].DataField = GrossProfitList[index];
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = string.Empty;
                        Cus_dList[index].DataField = string.Empty;
                        Sec_dList[index].DataField = string.Empty;
                        Gra_dList[index].DataField = string.Empty;
                    }
                    break;
                
            }

            #endregion

            //-------------------------------------------------------
            // TitleHeader設定
            //-------------------------------------------------------
            #region [TitleHeader設定]
            if (_custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Customer
                || _custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Clame)
            {
                // レイアウト通り
            }
            else if (_custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Section
                || _custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.ManageSection)
            {
                this.Lb_SectionTitle.Location = this.Lb_CustomerTitle.Location;
                this.Lb_CustomerTitle.Visible = false;
            }
            else // 得意先別拠点別
            {
                PointF point = this.Lb_SectionTitle.Location;
                this.Lb_SectionTitle.Location = this.Lb_CustomerTitle.Location;
                this.Lb_CustomerTitle.Location = point;
            }
            #endregion

            //-------------------------------------------------------
            // グループヘッダ表示・DataField設定
            //-------------------------------------------------------
            #region [グループヘッダ設定]
            if (_custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Customer
                || _custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Clame)
            {
                this.SectionHeader.Visible = true;
                this.SectionFooter.Visible = true;
                this.SectionHeader.DataField = "SectionCode";

                this.CustomerHeader.Visible = false;
                this.CustomerFooter.Visible = false;
                this.CustomerHeader.DataField = string.Empty;
            }
            else if (_custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Section
                || _custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.ManageSection)
            {
                // 拠点は1行ずつ改頁可能とする
                this.SectionHeader.Visible = true;
                this.SecHd_SectionCode.Visible = false;
                this.SecHd_SectionName.Visible = false;
                this.SecHd_line.Visible = false;
                this.SectionHeader.Height = 0F;

                this.SectionFooter.Visible = false;
                this.SectionHeader.DataField = "SectionCode";

                this.CustomerHeader.Visible = false;
                this.CustomerFooter.Visible = false;
                this.CustomerHeader.DataField = string.Empty;
            }
            else // 得意先別拠点別
            {
                this.SectionHeader.Visible = false;
                this.SectionFooter.Visible = false;
                this.SectionHeader.DataField = string.Empty;

                this.CustomerHeader.Visible = true;
                this.CustomerFooter.Visible = true;
                this.CustomerHeader.DataField = "CustomerCode";
            }
            #endregion

            //-------------------------------------------------------
            // 改頁設定
            // 0:しない 1:拠点毎 2:得意先毎
            //-------------------------------------------------------
            #region [改頁設定]
            switch (_custFinancialListCndtn.NewPageDiv)
            {
                case CustFinancialListCndtn.NewPageDivState.Section:
                    {
                        SectionHeader.NewPage = NewPage.Before;
                        break;
                    }
                case CustFinancialListCndtn.NewPageDivState.Customer:
                    {
                        CustomerHeader.NewPage = NewPage.Before;
                        break;
                    }
            }
            #endregion

            //-------------------------------------------------------
            // 明細設定
            //-------------------------------------------------------
            #region [明細設定]
            if (_custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Customer
                || _custFinancialListCndtn.PrintDiv == CustFinancialListCndtn.PrintDivState.Clame)
            {
                this.Code.DataField = "CustomerCode";
                this.Code.OutputFormat = "00000000";

                this.CodeName.DataField = "CustomerName";
            }
            else
            {
                this.Code.DataField = "SectionCode";
                this.Code.OutputFormat = "00";

                this.CodeName.DataField = "SectionName";
            }
            #endregion
        }

        /// <summary>
        /// 年度範囲の取得処理
        /// </summary>
        /// <returns>年度範囲</returns>
        private int GetYearRange(DateTime stYear, DateTime edYear)
        {
            return (edYear.Year - stYear.Year + 1);
        }

        /// <summary>
        /// 年度タイトル取得
        /// </summary>
        /// <returns>年度名称</returns>
        private string GetYearTitle(DateTime stYear, int index)
        {
            int year = stYear.Year + index;

            return (year.ToString() + "年");
        }
        #endregion

        #region ■ コントロールイベント

        private void PMHNB04132P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.tb_PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// ExtraHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
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

        /// <summary>
        /// SectionHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_BeforePrint(object sender, EventArgs e)
        {
            // 拠点コードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.SecHd_SectionCode.Text)
                || this.SecHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SecHd_SectionCode.Text = string.Empty;
                this.SecHd_SectionName.Text = string.Empty;
            }
        }

        /// <summary>
        /// CustomerHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerHeader_BeforePrint(object sender, EventArgs e)
        {
            // 得意先コードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.CusHd_CustomerCode.Text)
                || this.CusHd_CustomerCode.Text.PadLeft(8, '0') == "00000000")
            {
                this.CusHd_CustomerCode.Text = string.Empty;
                this.CusHd_CustomerName.Text = string.Empty;
            }
        }

        /// <summary>
        /// detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // コード値が0の場合、表示しない
            if (string.IsNullOrEmpty(this.Code.Text)
                || Convert.ToInt32(this.Code.Text) == 0)
            {
                this.Code.Text = string.Empty;
                this.CodeName.Text = string.Empty;
            }
        }

        /// <summary>
        /// Detail_AfterPrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
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

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMHNB04132P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.uYear8 = new DataDynamics.ActiveReports.TextBox();
            this.uYear7 = new DataDynamics.ActiveReports.TextBox();
            this.uYear1 = new DataDynamics.ActiveReports.TextBox();
            this.uYear2 = new DataDynamics.ActiveReports.TextBox();
            this.uYear3 = new DataDynamics.ActiveReports.TextBox();
            this.uYear4 = new DataDynamics.ActiveReports.TextBox();
            this.uYear5 = new DataDynamics.ActiveReports.TextBox();
            this.uYear6 = new DataDynamics.ActiveReports.TextBox();
            this.CodeName = new DataDynamics.ActiveReports.TextBox();
            this.Code = new DataDynamics.ActiveReports.TextBox();
            this.dYear8 = new DataDynamics.ActiveReports.TextBox();
            this.dYear7 = new DataDynamics.ActiveReports.TextBox();
            this.dYear1 = new DataDynamics.ActiveReports.TextBox();
            this.dYear2 = new DataDynamics.ActiveReports.TextBox();
            this.dYear3 = new DataDynamics.ActiveReports.TextBox();
            this.dYear4 = new DataDynamics.ActiveReports.TextBox();
            this.dYear5 = new DataDynamics.ActiveReports.TextBox();
            this.dYear6 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_Year8 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year1 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year2 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year3 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year4 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year5 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year6 = new DataDynamics.ActiveReports.Label();
            this.Lb_Year7 = new DataDynamics.ActiveReports.Label();
            this.Lb_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.Lb_CustomerTitle = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Gra_uYear8 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear7 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear1 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear2 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear3 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear4 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear5 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_uYear6 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear8 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear7 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear1 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear2 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear3 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear4 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear5 = new DataDynamics.ActiveReports.TextBox();
            this.Gra_dYear6 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_line = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear8 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear7 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear1 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear2 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear3 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear4 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear5 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_uYear6 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear8 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear7 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear1 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear2 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear3 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear4 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear5 = new DataDynamics.ActiveReports.TextBox();
            this.Sec_dYear6 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CusHd_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear8 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear7 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear1 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear2 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear3 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear4 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear5 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_uYear6 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear8 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear7 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear1 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear2 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear3 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear4 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear5 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_dYear6 = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CustomerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.Label3,
            this.tb_PrintDate,
            this.tb_PrintTime,
            this.Label2,
            this.tb_PrintPage});
            this.PageHeader.Height = 0.271F;
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
            this.tb_ReportTitle.Left = 0.219F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "過年度統計表（得意先別拠点別）";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
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
            this.Line1.Top = 0.21F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.21F;
            this.Line1.Y2 = 0.21F;
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
            this.Label3.Left = 7.938F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.063F;
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
            this.tb_PrintDate.Top = 0.063F;
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
            this.tb_PrintTime.Left = 9.438F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.063F;
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
            this.Label2.Left = 9.938F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.063F;
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
            this.tb_PrintPage.Left = 10.438F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.063F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.uYear8,
            this.uYear7,
            this.uYear1,
            this.uYear2,
            this.uYear3,
            this.uYear4,
            this.uYear5,
            this.uYear6,
            this.CodeName,
            this.Code,
            this.dYear8,
            this.dYear7,
            this.dYear1,
            this.dYear2,
            this.dYear3,
            this.dYear4,
            this.dYear5,
            this.dYear6});
            this.detail.Height = 0.4375F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // uYear8
            // 
            this.uYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear8.Border.RightColor = System.Drawing.Color.Black;
            this.uYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear8.Border.TopColor = System.Drawing.Color.Black;
            this.uYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear8.DataField = "";
            this.uYear8.Height = 0.156F;
            this.uYear8.Left = 9.8125F;
            this.uYear8.MultiLine = false;
            this.uYear8.Name = "uYear8";
            this.uYear8.OutputFormat = resources.GetString("uYear8.OutputFormat");
            this.uYear8.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear8.Text = "123,456,789,012";
            this.uYear8.Top = 0.0625F;
            this.uYear8.Width = 0.9F;
            // 
            // uYear7
            // 
            this.uYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear7.Border.RightColor = System.Drawing.Color.Black;
            this.uYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear7.Border.TopColor = System.Drawing.Color.Black;
            this.uYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear7.DataField = "";
            this.uYear7.Height = 0.156F;
            this.uYear7.Left = 8.7875F;
            this.uYear7.MultiLine = false;
            this.uYear7.Name = "uYear7";
            this.uYear7.OutputFormat = resources.GetString("uYear7.OutputFormat");
            this.uYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear7.Text = "123,456,789,012";
            this.uYear7.Top = 0.0625F;
            this.uYear7.Width = 0.9F;
            // 
            // uYear1
            // 
            this.uYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear1.Border.RightColor = System.Drawing.Color.Black;
            this.uYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear1.Border.TopColor = System.Drawing.Color.Black;
            this.uYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear1.Height = 0.156F;
            this.uYear1.Left = 2.6375F;
            this.uYear1.MultiLine = false;
            this.uYear1.Name = "uYear1";
            this.uYear1.OutputFormat = resources.GetString("uYear1.OutputFormat");
            this.uYear1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear1.Text = "123,456,789,012";
            this.uYear1.Top = 0.0625F;
            this.uYear1.Width = 0.9F;
            // 
            // uYear2
            // 
            this.uYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear2.Border.RightColor = System.Drawing.Color.Black;
            this.uYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear2.Border.TopColor = System.Drawing.Color.Black;
            this.uYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear2.DataField = "";
            this.uYear2.Height = 0.156F;
            this.uYear2.Left = 3.6625F;
            this.uYear2.MultiLine = false;
            this.uYear2.Name = "uYear2";
            this.uYear2.OutputFormat = resources.GetString("uYear2.OutputFormat");
            this.uYear2.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear2.Text = "123,456,789,012";
            this.uYear2.Top = 0.0625F;
            this.uYear2.Width = 0.9F;
            // 
            // uYear3
            // 
            this.uYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear3.Border.RightColor = System.Drawing.Color.Black;
            this.uYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear3.Border.TopColor = System.Drawing.Color.Black;
            this.uYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear3.DataField = "";
            this.uYear3.Height = 0.156F;
            this.uYear3.Left = 4.6875F;
            this.uYear3.MultiLine = false;
            this.uYear3.Name = "uYear3";
            this.uYear3.OutputFormat = resources.GetString("uYear3.OutputFormat");
            this.uYear3.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear3.Text = "123,456,789,012";
            this.uYear3.Top = 0.0625F;
            this.uYear3.Width = 0.9F;
            // 
            // uYear4
            // 
            this.uYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear4.Border.RightColor = System.Drawing.Color.Black;
            this.uYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear4.Border.TopColor = System.Drawing.Color.Black;
            this.uYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear4.DataField = "";
            this.uYear4.Height = 0.156F;
            this.uYear4.Left = 5.712501F;
            this.uYear4.MultiLine = false;
            this.uYear4.Name = "uYear4";
            this.uYear4.OutputFormat = resources.GetString("uYear4.OutputFormat");
            this.uYear4.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear4.Text = "123,456,789,012";
            this.uYear4.Top = 0.0625F;
            this.uYear4.Width = 0.9F;
            // 
            // uYear5
            // 
            this.uYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear5.Border.RightColor = System.Drawing.Color.Black;
            this.uYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear5.Border.TopColor = System.Drawing.Color.Black;
            this.uYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear5.DataField = "";
            this.uYear5.Height = 0.156F;
            this.uYear5.Left = 6.737501F;
            this.uYear5.MultiLine = false;
            this.uYear5.Name = "uYear5";
            this.uYear5.OutputFormat = resources.GetString("uYear5.OutputFormat");
            this.uYear5.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear5.Text = "123,456,789,012";
            this.uYear5.Top = 0.0625F;
            this.uYear5.Width = 0.9F;
            // 
            // uYear6
            // 
            this.uYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.uYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.uYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear6.Border.RightColor = System.Drawing.Color.Black;
            this.uYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear6.Border.TopColor = System.Drawing.Color.Black;
            this.uYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uYear6.DataField = "";
            this.uYear6.Height = 0.156F;
            this.uYear6.Left = 7.762501F;
            this.uYear6.MultiLine = false;
            this.uYear6.Name = "uYear6";
            this.uYear6.OutputFormat = resources.GetString("uYear6.OutputFormat");
            this.uYear6.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.uYear6.Text = "123,456,789,012";
            this.uYear6.Top = 0.0625F;
            this.uYear6.Width = 0.9F;
            // 
            // CodeName
            // 
            this.CodeName.Border.BottomColor = System.Drawing.Color.Black;
            this.CodeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Border.LeftColor = System.Drawing.Color.Black;
            this.CodeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Border.RightColor = System.Drawing.Color.Black;
            this.CodeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Border.TopColor = System.Drawing.Color.Black;
            this.CodeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Height = 0.156F;
            this.CodeName.Left = 0.9375F;
            this.CodeName.MultiLine = false;
            this.CodeName.Name = "CodeName";
            this.CodeName.OutputFormat = resources.GetString("CodeName.OutputFormat");
            this.CodeName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CodeName.Text = "あいうえおかきくけこ";
            this.CodeName.Top = 0.0625F;
            this.CodeName.Width = 1.2F;
            // 
            // Code
            // 
            this.Code.Border.BottomColor = System.Drawing.Color.Black;
            this.Code.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Border.LeftColor = System.Drawing.Color.Black;
            this.Code.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Border.RightColor = System.Drawing.Color.Black;
            this.Code.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Border.TopColor = System.Drawing.Color.Black;
            this.Code.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Height = 0.16F;
            this.Code.Left = 0.375F;
            this.Code.MultiLine = false;
            this.Code.Name = "Code";
            this.Code.OutputFormat = resources.GetString("Code.OutputFormat");
            this.Code.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Code.Text = "12345678";
            this.Code.Top = 0.0625F;
            this.Code.Width = 0.5F;
            // 
            // dYear8
            // 
            this.dYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear8.Border.RightColor = System.Drawing.Color.Black;
            this.dYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear8.Border.TopColor = System.Drawing.Color.Black;
            this.dYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear8.DataField = "";
            this.dYear8.Height = 0.156F;
            this.dYear8.Left = 9.8125F;
            this.dYear8.MultiLine = false;
            this.dYear8.Name = "dYear8";
            this.dYear8.OutputFormat = resources.GetString("dYear8.OutputFormat");
            this.dYear8.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear8.Text = "123,456,789,012";
            this.dYear8.Top = 0.25F;
            this.dYear8.Width = 0.9F;
            // 
            // dYear7
            // 
            this.dYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear7.Border.RightColor = System.Drawing.Color.Black;
            this.dYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear7.Border.TopColor = System.Drawing.Color.Black;
            this.dYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear7.DataField = "";
            this.dYear7.Height = 0.156F;
            this.dYear7.Left = 8.7875F;
            this.dYear7.MultiLine = false;
            this.dYear7.Name = "dYear7";
            this.dYear7.OutputFormat = resources.GetString("dYear7.OutputFormat");
            this.dYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear7.Text = "123,456,789,012";
            this.dYear7.Top = 0.25F;
            this.dYear7.Width = 0.9F;
            // 
            // dYear1
            // 
            this.dYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear1.Border.RightColor = System.Drawing.Color.Black;
            this.dYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear1.Border.TopColor = System.Drawing.Color.Black;
            this.dYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear1.DataField = "";
            this.dYear1.Height = 0.156F;
            this.dYear1.Left = 2.6375F;
            this.dYear1.MultiLine = false;
            this.dYear1.Name = "dYear1";
            this.dYear1.OutputFormat = resources.GetString("dYear1.OutputFormat");
            this.dYear1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear1.Text = "123,456,789,012";
            this.dYear1.Top = 0.25F;
            this.dYear1.Width = 0.9F;
            // 
            // dYear2
            // 
            this.dYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear2.Border.RightColor = System.Drawing.Color.Black;
            this.dYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear2.Border.TopColor = System.Drawing.Color.Black;
            this.dYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear2.DataField = "";
            this.dYear2.Height = 0.156F;
            this.dYear2.Left = 3.6625F;
            this.dYear2.MultiLine = false;
            this.dYear2.Name = "dYear2";
            this.dYear2.OutputFormat = resources.GetString("dYear2.OutputFormat");
            this.dYear2.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear2.Text = "123,456,789,012";
            this.dYear2.Top = 0.25F;
            this.dYear2.Width = 0.9F;
            // 
            // dYear3
            // 
            this.dYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear3.Border.RightColor = System.Drawing.Color.Black;
            this.dYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear3.Border.TopColor = System.Drawing.Color.Black;
            this.dYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear3.DataField = "";
            this.dYear3.Height = 0.156F;
            this.dYear3.Left = 4.6875F;
            this.dYear3.MultiLine = false;
            this.dYear3.Name = "dYear3";
            this.dYear3.OutputFormat = resources.GetString("dYear3.OutputFormat");
            this.dYear3.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear3.Text = "123,456,789,012";
            this.dYear3.Top = 0.25F;
            this.dYear3.Width = 0.9F;
            // 
            // dYear4
            // 
            this.dYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear4.Border.RightColor = System.Drawing.Color.Black;
            this.dYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear4.Border.TopColor = System.Drawing.Color.Black;
            this.dYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear4.DataField = "";
            this.dYear4.Height = 0.156F;
            this.dYear4.Left = 5.712501F;
            this.dYear4.MultiLine = false;
            this.dYear4.Name = "dYear4";
            this.dYear4.OutputFormat = resources.GetString("dYear4.OutputFormat");
            this.dYear4.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear4.Text = "123,456,789,012";
            this.dYear4.Top = 0.25F;
            this.dYear4.Width = 0.9F;
            // 
            // dYear5
            // 
            this.dYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear5.Border.RightColor = System.Drawing.Color.Black;
            this.dYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear5.Border.TopColor = System.Drawing.Color.Black;
            this.dYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear5.DataField = "";
            this.dYear5.Height = 0.156F;
            this.dYear5.Left = 6.737501F;
            this.dYear5.MultiLine = false;
            this.dYear5.Name = "dYear5";
            this.dYear5.OutputFormat = resources.GetString("dYear5.OutputFormat");
            this.dYear5.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear5.Text = "123,456,789,012";
            this.dYear5.Top = 0.25F;
            this.dYear5.Width = 0.9F;
            // 
            // dYear6
            // 
            this.dYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.dYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.dYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear6.Border.RightColor = System.Drawing.Color.Black;
            this.dYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear6.Border.TopColor = System.Drawing.Color.Black;
            this.dYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dYear6.DataField = "";
            this.dYear6.Height = 0.156F;
            this.dYear6.Left = 7.762501F;
            this.dYear6.MultiLine = false;
            this.dYear6.Name = "dYear6";
            this.dYear6.OutputFormat = resources.GetString("dYear6.OutputFormat");
            this.dYear6.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dYear6.Text = "123,456,789,012";
            this.dYear6.Top = 0.25F;
            this.dYear6.Width = 0.9F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Visible = false;
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
            this.Line2,
            this.Lb_Year8,
            this.Lb_Year1,
            this.Lb_Year2,
            this.Lb_Year3,
            this.Lb_Year4,
            this.Lb_Year5,
            this.Lb_Year6,
            this.Lb_Year7,
            this.Lb_SectionTitle,
            this.Lb_CustomerTitle,
            this.line7});
            this.TitleHeader.Height = 0.40625F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 2F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 10.8F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.8F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
            // 
            // Lb_Year8
            // 
            this.Lb_Year8.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year8.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year8.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year8.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year8.Height = 0.156F;
            this.Lb_Year8.HyperLink = "";
            this.Lb_Year8.Left = 10.2025F;
            this.Lb_Year8.MultiLine = false;
            this.Lb_Year8.Name = "Lb_Year8";
            this.Lb_Year8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year8.Text = "8888年";
            this.Lb_Year8.Top = 0.1875F;
            this.Lb_Year8.Width = 0.51F;
            // 
            // Lb_Year1
            // 
            this.Lb_Year1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year1.Height = 0.156F;
            this.Lb_Year1.HyperLink = "";
            this.Lb_Year1.Left = 3.0275F;
            this.Lb_Year1.MultiLine = false;
            this.Lb_Year1.Name = "Lb_Year1";
            this.Lb_Year1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year1.Text = "8888年";
            this.Lb_Year1.Top = 0.1875F;
            this.Lb_Year1.Width = 0.51F;
            // 
            // Lb_Year2
            // 
            this.Lb_Year2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year2.Height = 0.156F;
            this.Lb_Year2.HyperLink = "";
            this.Lb_Year2.Left = 4.0525F;
            this.Lb_Year2.MultiLine = false;
            this.Lb_Year2.Name = "Lb_Year2";
            this.Lb_Year2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year2.Text = "8888年";
            this.Lb_Year2.Top = 0.1875F;
            this.Lb_Year2.Width = 0.51F;
            // 
            // Lb_Year3
            // 
            this.Lb_Year3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year3.Height = 0.156F;
            this.Lb_Year3.HyperLink = "";
            this.Lb_Year3.Left = 5.0775F;
            this.Lb_Year3.MultiLine = false;
            this.Lb_Year3.Name = "Lb_Year3";
            this.Lb_Year3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year3.Text = "8888年";
            this.Lb_Year3.Top = 0.1875F;
            this.Lb_Year3.Width = 0.51F;
            // 
            // Lb_Year4
            // 
            this.Lb_Year4.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year4.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year4.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year4.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year4.Height = 0.156F;
            this.Lb_Year4.HyperLink = "";
            this.Lb_Year4.Left = 6.1025F;
            this.Lb_Year4.MultiLine = false;
            this.Lb_Year4.Name = "Lb_Year4";
            this.Lb_Year4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year4.Text = "8888年";
            this.Lb_Year4.Top = 0.1875F;
            this.Lb_Year4.Width = 0.51F;
            // 
            // Lb_Year5
            // 
            this.Lb_Year5.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year5.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year5.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year5.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year5.Height = 0.156F;
            this.Lb_Year5.HyperLink = "";
            this.Lb_Year5.Left = 7.127501F;
            this.Lb_Year5.MultiLine = false;
            this.Lb_Year5.Name = "Lb_Year5";
            this.Lb_Year5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year5.Text = "8888年";
            this.Lb_Year5.Top = 0.1875F;
            this.Lb_Year5.Width = 0.51F;
            // 
            // Lb_Year6
            // 
            this.Lb_Year6.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year6.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year6.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year6.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year6.Height = 0.156F;
            this.Lb_Year6.HyperLink = "";
            this.Lb_Year6.Left = 8.152501F;
            this.Lb_Year6.MultiLine = false;
            this.Lb_Year6.Name = "Lb_Year6";
            this.Lb_Year6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year6.Text = "8888年";
            this.Lb_Year6.Top = 0.1875F;
            this.Lb_Year6.Width = 0.51F;
            // 
            // Lb_Year7
            // 
            this.Lb_Year7.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Year7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year7.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Year7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year7.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Year7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year7.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Year7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Year7.Height = 0.156F;
            this.Lb_Year7.HyperLink = "";
            this.Lb_Year7.Left = 9.177501F;
            this.Lb_Year7.MultiLine = false;
            this.Lb_Year7.Name = "Lb_Year7";
            this.Lb_Year7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Year7.Text = "8888年";
            this.Lb_Year7.Top = 0.1875F;
            this.Lb_Year7.Width = 0.51F;
            // 
            // Lb_SectionTitle
            // 
            this.Lb_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Height = 0.156F;
            this.Lb_SectionTitle.HyperLink = "";
            this.Lb_SectionTitle.Left = 0.063F;
            this.Lb_SectionTitle.MultiLine = false;
            this.Lb_SectionTitle.Name = "Lb_SectionTitle";
            this.Lb_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SectionTitle.Text = "拠点";
            this.Lb_SectionTitle.Top = 0.01F;
            this.Lb_SectionTitle.Width = 0.4375F;
            // 
            // Lb_CustomerTitle
            // 
            this.Lb_CustomerTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CustomerTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CustomerTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CustomerTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CustomerTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerTitle.Height = 0.156F;
            this.Lb_CustomerTitle.HyperLink = "";
            this.Lb_CustomerTitle.Left = 0.375F;
            this.Lb_CustomerTitle.MultiLine = false;
            this.Lb_CustomerTitle.Name = "Lb_CustomerTitle";
            this.Lb_CustomerTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CustomerTitle.Text = "得意先";
            this.Lb_CustomerTitle.Top = 0.1875F;
            this.Lb_CustomerTitle.Width = 0.4375F;
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
            this.line7.Top = 0.3435F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0.3435F;
            this.line7.Y2 = 0.3435F;
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
            this.Gra_uYear8,
            this.Gra_uYear7,
            this.Gra_uYear1,
            this.Gra_uYear2,
            this.Gra_uYear3,
            this.Gra_uYear4,
            this.Gra_uYear5,
            this.Gra_uYear6,
            this.Gra_dYear8,
            this.Gra_dYear7,
            this.Gra_dYear1,
            this.Gra_dYear2,
            this.Gra_dYear3,
            this.Gra_dYear4,
            this.Gra_dYear5,
            this.Gra_dYear6,
            this.line6});
            this.GrandTotalFooter.Height = 0.5208333F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.GrandTotalTitle.Height = 0.219F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 1.75F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.063F;
            this.GrandTotalTitle.Width = 0.8F;
            // 
            // Gra_uYear8
            // 
            this.Gra_uYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear8.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear8.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear8.DataField = "";
            this.Gra_uYear8.Height = 0.156F;
            this.Gra_uYear8.Left = 9.8125F;
            this.Gra_uYear8.MultiLine = false;
            this.Gra_uYear8.Name = "Gra_uYear8";
            this.Gra_uYear8.OutputFormat = resources.GetString("Gra_uYear8.OutputFormat");
            this.Gra_uYear8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear8.Text = "123,456,789,012";
            this.Gra_uYear8.Top = 0.0625F;
            this.Gra_uYear8.Width = 0.9F;
            // 
            // Gra_uYear7
            // 
            this.Gra_uYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear7.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear7.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear7.DataField = "";
            this.Gra_uYear7.Height = 0.156F;
            this.Gra_uYear7.Left = 8.7875F;
            this.Gra_uYear7.MultiLine = false;
            this.Gra_uYear7.Name = "Gra_uYear7";
            this.Gra_uYear7.OutputFormat = resources.GetString("Gra_uYear7.OutputFormat");
            this.Gra_uYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear7.Text = "123,456,789,012";
            this.Gra_uYear7.Top = 0.0625F;
            this.Gra_uYear7.Width = 0.9F;
            // 
            // Gra_uYear1
            // 
            this.Gra_uYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear1.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear1.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear1.DataField = "";
            this.Gra_uYear1.Height = 0.156F;
            this.Gra_uYear1.Left = 2.6375F;
            this.Gra_uYear1.MultiLine = false;
            this.Gra_uYear1.Name = "Gra_uYear1";
            this.Gra_uYear1.OutputFormat = resources.GetString("Gra_uYear1.OutputFormat");
            this.Gra_uYear1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear1.Text = "123,456,789,012";
            this.Gra_uYear1.Top = 0.0625F;
            this.Gra_uYear1.Width = 0.9F;
            // 
            // Gra_uYear2
            // 
            this.Gra_uYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear2.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear2.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear2.DataField = "";
            this.Gra_uYear2.Height = 0.156F;
            this.Gra_uYear2.Left = 3.6625F;
            this.Gra_uYear2.MultiLine = false;
            this.Gra_uYear2.Name = "Gra_uYear2";
            this.Gra_uYear2.OutputFormat = resources.GetString("Gra_uYear2.OutputFormat");
            this.Gra_uYear2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear2.Text = "123,456,789,012";
            this.Gra_uYear2.Top = 0.0625F;
            this.Gra_uYear2.Width = 0.9F;
            // 
            // Gra_uYear3
            // 
            this.Gra_uYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear3.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear3.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear3.DataField = "";
            this.Gra_uYear3.Height = 0.156F;
            this.Gra_uYear3.Left = 4.6875F;
            this.Gra_uYear3.MultiLine = false;
            this.Gra_uYear3.Name = "Gra_uYear3";
            this.Gra_uYear3.OutputFormat = resources.GetString("Gra_uYear3.OutputFormat");
            this.Gra_uYear3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear3.Text = "123,456,789,012";
            this.Gra_uYear3.Top = 0.0625F;
            this.Gra_uYear3.Width = 0.9F;
            // 
            // Gra_uYear4
            // 
            this.Gra_uYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear4.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear4.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear4.DataField = "";
            this.Gra_uYear4.Height = 0.156F;
            this.Gra_uYear4.Left = 5.712501F;
            this.Gra_uYear4.MultiLine = false;
            this.Gra_uYear4.Name = "Gra_uYear4";
            this.Gra_uYear4.OutputFormat = resources.GetString("Gra_uYear4.OutputFormat");
            this.Gra_uYear4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear4.Text = "123,456,789,012";
            this.Gra_uYear4.Top = 0.0625F;
            this.Gra_uYear4.Width = 0.9F;
            // 
            // Gra_uYear5
            // 
            this.Gra_uYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear5.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear5.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear5.DataField = "";
            this.Gra_uYear5.Height = 0.156F;
            this.Gra_uYear5.Left = 6.737501F;
            this.Gra_uYear5.MultiLine = false;
            this.Gra_uYear5.Name = "Gra_uYear5";
            this.Gra_uYear5.OutputFormat = resources.GetString("Gra_uYear5.OutputFormat");
            this.Gra_uYear5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear5.Text = "123,456,789,012";
            this.Gra_uYear5.Top = 0.0625F;
            this.Gra_uYear5.Width = 0.9F;
            // 
            // Gra_uYear6
            // 
            this.Gra_uYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_uYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_uYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear6.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_uYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear6.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_uYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_uYear6.DataField = "";
            this.Gra_uYear6.Height = 0.156F;
            this.Gra_uYear6.Left = 7.762501F;
            this.Gra_uYear6.MultiLine = false;
            this.Gra_uYear6.Name = "Gra_uYear6";
            this.Gra_uYear6.OutputFormat = resources.GetString("Gra_uYear6.OutputFormat");
            this.Gra_uYear6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_uYear6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_uYear6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_uYear6.Text = "123,456,789,012";
            this.Gra_uYear6.Top = 0.0625F;
            this.Gra_uYear6.Width = 0.9F;
            // 
            // Gra_dYear8
            // 
            this.Gra_dYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear8.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear8.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear8.DataField = "";
            this.Gra_dYear8.Height = 0.156F;
            this.Gra_dYear8.Left = 9.8125F;
            this.Gra_dYear8.MultiLine = false;
            this.Gra_dYear8.Name = "Gra_dYear8";
            this.Gra_dYear8.OutputFormat = resources.GetString("Gra_dYear8.OutputFormat");
            this.Gra_dYear8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear8.Text = "123,456,789,012";
            this.Gra_dYear8.Top = 0.25F;
            this.Gra_dYear8.Width = 0.9F;
            // 
            // Gra_dYear7
            // 
            this.Gra_dYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear7.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear7.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear7.DataField = "";
            this.Gra_dYear7.Height = 0.156F;
            this.Gra_dYear7.Left = 8.7875F;
            this.Gra_dYear7.MultiLine = false;
            this.Gra_dYear7.Name = "Gra_dYear7";
            this.Gra_dYear7.OutputFormat = resources.GetString("Gra_dYear7.OutputFormat");
            this.Gra_dYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear7.Text = "123,456,789,012";
            this.Gra_dYear7.Top = 0.25F;
            this.Gra_dYear7.Width = 0.9F;
            // 
            // Gra_dYear1
            // 
            this.Gra_dYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear1.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear1.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear1.DataField = "";
            this.Gra_dYear1.Height = 0.156F;
            this.Gra_dYear1.Left = 2.6375F;
            this.Gra_dYear1.MultiLine = false;
            this.Gra_dYear1.Name = "Gra_dYear1";
            this.Gra_dYear1.OutputFormat = resources.GetString("Gra_dYear1.OutputFormat");
            this.Gra_dYear1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear1.Text = "123,456,789,012";
            this.Gra_dYear1.Top = 0.25F;
            this.Gra_dYear1.Width = 0.9F;
            // 
            // Gra_dYear2
            // 
            this.Gra_dYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear2.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear2.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear2.DataField = "";
            this.Gra_dYear2.Height = 0.156F;
            this.Gra_dYear2.Left = 3.6625F;
            this.Gra_dYear2.MultiLine = false;
            this.Gra_dYear2.Name = "Gra_dYear2";
            this.Gra_dYear2.OutputFormat = resources.GetString("Gra_dYear2.OutputFormat");
            this.Gra_dYear2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear2.Text = "123,456,789,012";
            this.Gra_dYear2.Top = 0.25F;
            this.Gra_dYear2.Width = 0.9F;
            // 
            // Gra_dYear3
            // 
            this.Gra_dYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear3.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear3.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear3.DataField = "";
            this.Gra_dYear3.Height = 0.156F;
            this.Gra_dYear3.Left = 4.6875F;
            this.Gra_dYear3.MultiLine = false;
            this.Gra_dYear3.Name = "Gra_dYear3";
            this.Gra_dYear3.OutputFormat = resources.GetString("Gra_dYear3.OutputFormat");
            this.Gra_dYear3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear3.Text = "123,456,789,012";
            this.Gra_dYear3.Top = 0.25F;
            this.Gra_dYear3.Width = 0.9F;
            // 
            // Gra_dYear4
            // 
            this.Gra_dYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear4.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear4.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear4.DataField = "";
            this.Gra_dYear4.Height = 0.156F;
            this.Gra_dYear4.Left = 5.712501F;
            this.Gra_dYear4.MultiLine = false;
            this.Gra_dYear4.Name = "Gra_dYear4";
            this.Gra_dYear4.OutputFormat = resources.GetString("Gra_dYear4.OutputFormat");
            this.Gra_dYear4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear4.Text = "123,456,789,012";
            this.Gra_dYear4.Top = 0.25F;
            this.Gra_dYear4.Width = 0.9F;
            // 
            // Gra_dYear5
            // 
            this.Gra_dYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear5.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear5.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear5.DataField = "";
            this.Gra_dYear5.Height = 0.156F;
            this.Gra_dYear5.Left = 6.737501F;
            this.Gra_dYear5.MultiLine = false;
            this.Gra_dYear5.Name = "Gra_dYear5";
            this.Gra_dYear5.OutputFormat = resources.GetString("Gra_dYear5.OutputFormat");
            this.Gra_dYear5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear5.Text = "123,456,789,012";
            this.Gra_dYear5.Top = 0.25F;
            this.Gra_dYear5.Width = 0.9F;
            // 
            // Gra_dYear6
            // 
            this.Gra_dYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gra_dYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gra_dYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear6.Border.RightColor = System.Drawing.Color.Black;
            this.Gra_dYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear6.Border.TopColor = System.Drawing.Color.Black;
            this.Gra_dYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gra_dYear6.DataField = "";
            this.Gra_dYear6.Height = 0.156F;
            this.Gra_dYear6.Left = 7.762501F;
            this.Gra_dYear6.MultiLine = false;
            this.Gra_dYear6.Name = "Gra_dYear6";
            this.Gra_dYear6.OutputFormat = resources.GetString("Gra_dYear6.OutputFormat");
            this.Gra_dYear6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Gra_dYear6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Gra_dYear6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Gra_dYear6.Text = "123,456,789,012";
            this.Gra_dYear6.Top = 0.25F;
            this.Gra_dYear6.Width = 0.9F;
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
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_SectionCode,
            this.SecHd_SectionName,
            this.SecHd_line});
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.21875F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
            // 
            // SecHd_SectionCode
            // 
            this.SecHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.DataField = "SectionCode";
            this.SecHd_SectionCode.Height = 0.16F;
            this.SecHd_SectionCode.Left = 0.0625F;
            this.SecHd_SectionCode.MultiLine = false;
            this.SecHd_SectionCode.Name = "SecHd_SectionCode";
            this.SecHd_SectionCode.OutputFormat = resources.GetString("SecHd_SectionCode.OutputFormat");
            this.SecHd_SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SecHd_SectionCode.Text = "12";
            this.SecHd_SectionCode.Top = 0F;
            this.SecHd_SectionCode.Width = 0.2F;
            // 
            // SecHd_SectionName
            // 
            this.SecHd_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.DataField = "SectionName";
            this.SecHd_SectionName.Height = 0.16F;
            this.SecHd_SectionName.Left = 0.3125F;
            this.SecHd_SectionName.MultiLine = false;
            this.SecHd_SectionName.Name = "SecHd_SectionName";
            this.SecHd_SectionName.OutputFormat = resources.GetString("SecHd_SectionName.OutputFormat");
            this.SecHd_SectionName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SecHd_SectionName.Text = "あいうえおかきくけこ";
            this.SecHd_SectionName.Top = 0F;
            this.SecHd_SectionName.Width = 1.2F;
            // 
            // SecHd_line
            // 
            this.SecHd_line.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Height = 0F;
            this.SecHd_line.Left = 0F;
            this.SecHd_line.LineWeight = 2F;
            this.SecHd_line.Name = "SecHd_line";
            this.SecHd_line.Top = 0.16F;
            this.SecHd_line.Width = 10.8F;
            this.SecHd_line.X1 = 0F;
            this.SecHd_line.X2 = 10.8F;
            this.SecHd_line.Y1 = 0.16F;
            this.SecHd_line.Y2 = 0.16F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionTitle,
            this.Sec_uYear8,
            this.Sec_uYear7,
            this.Sec_uYear1,
            this.Sec_uYear2,
            this.Sec_uYear3,
            this.Sec_uYear4,
            this.Sec_uYear5,
            this.Sec_uYear6,
            this.Sec_dYear8,
            this.Sec_dYear7,
            this.Sec_dYear1,
            this.Sec_dYear2,
            this.Sec_dYear3,
            this.Sec_dYear4,
            this.Sec_dYear5,
            this.Sec_dYear6,
            this.line5});
            this.SectionFooter.Height = 0.4479167F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // SectionTitle
            // 
            this.SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Height = 0.219F;
            this.SectionTitle.Left = 1.75F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0.063F;
            this.SectionTitle.Width = 0.8F;
            // 
            // Sec_uYear8
            // 
            this.Sec_uYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear8.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear8.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear8.DataField = "";
            this.Sec_uYear8.Height = 0.156F;
            this.Sec_uYear8.Left = 9.8125F;
            this.Sec_uYear8.MultiLine = false;
            this.Sec_uYear8.Name = "Sec_uYear8";
            this.Sec_uYear8.OutputFormat = resources.GetString("Sec_uYear8.OutputFormat");
            this.Sec_uYear8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear8.SummaryGroup = "SectionHeader";
            this.Sec_uYear8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear8.Text = "123,456,789,012";
            this.Sec_uYear8.Top = 0.0625F;
            this.Sec_uYear8.Width = 0.9F;
            // 
            // Sec_uYear7
            // 
            this.Sec_uYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear7.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear7.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear7.DataField = "";
            this.Sec_uYear7.Height = 0.156F;
            this.Sec_uYear7.Left = 8.7875F;
            this.Sec_uYear7.MultiLine = false;
            this.Sec_uYear7.Name = "Sec_uYear7";
            this.Sec_uYear7.OutputFormat = resources.GetString("Sec_uYear7.OutputFormat");
            this.Sec_uYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear7.SummaryGroup = "SectionHeader";
            this.Sec_uYear7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear7.Text = "123,456,789,012";
            this.Sec_uYear7.Top = 0.0625F;
            this.Sec_uYear7.Width = 0.9F;
            // 
            // Sec_uYear1
            // 
            this.Sec_uYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear1.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear1.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear1.DataField = "";
            this.Sec_uYear1.Height = 0.156F;
            this.Sec_uYear1.Left = 2.6375F;
            this.Sec_uYear1.MultiLine = false;
            this.Sec_uYear1.Name = "Sec_uYear1";
            this.Sec_uYear1.OutputFormat = resources.GetString("Sec_uYear1.OutputFormat");
            this.Sec_uYear1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear1.SummaryGroup = "SectionHeader";
            this.Sec_uYear1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear1.Text = "123,456,789,012";
            this.Sec_uYear1.Top = 0.0625F;
            this.Sec_uYear1.Width = 0.9F;
            // 
            // Sec_uYear2
            // 
            this.Sec_uYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear2.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear2.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear2.DataField = "";
            this.Sec_uYear2.Height = 0.156F;
            this.Sec_uYear2.Left = 3.6625F;
            this.Sec_uYear2.MultiLine = false;
            this.Sec_uYear2.Name = "Sec_uYear2";
            this.Sec_uYear2.OutputFormat = resources.GetString("Sec_uYear2.OutputFormat");
            this.Sec_uYear2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear2.SummaryGroup = "SectionHeader";
            this.Sec_uYear2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear2.Text = "123,456,789,012";
            this.Sec_uYear2.Top = 0.0625F;
            this.Sec_uYear2.Width = 0.9F;
            // 
            // Sec_uYear3
            // 
            this.Sec_uYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear3.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear3.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear3.DataField = "";
            this.Sec_uYear3.Height = 0.156F;
            this.Sec_uYear3.Left = 4.6875F;
            this.Sec_uYear3.MultiLine = false;
            this.Sec_uYear3.Name = "Sec_uYear3";
            this.Sec_uYear3.OutputFormat = resources.GetString("Sec_uYear3.OutputFormat");
            this.Sec_uYear3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear3.SummaryGroup = "SectionHeader";
            this.Sec_uYear3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear3.Text = "123,456,789,012";
            this.Sec_uYear3.Top = 0.0625F;
            this.Sec_uYear3.Width = 0.9F;
            // 
            // Sec_uYear4
            // 
            this.Sec_uYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear4.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear4.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear4.DataField = "";
            this.Sec_uYear4.Height = 0.156F;
            this.Sec_uYear4.Left = 5.712501F;
            this.Sec_uYear4.MultiLine = false;
            this.Sec_uYear4.Name = "Sec_uYear4";
            this.Sec_uYear4.OutputFormat = resources.GetString("Sec_uYear4.OutputFormat");
            this.Sec_uYear4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear4.SummaryGroup = "SectionHeader";
            this.Sec_uYear4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear4.Text = "123,456,789,012";
            this.Sec_uYear4.Top = 0.0625F;
            this.Sec_uYear4.Width = 0.9F;
            // 
            // Sec_uYear5
            // 
            this.Sec_uYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear5.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear5.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear5.DataField = "";
            this.Sec_uYear5.Height = 0.156F;
            this.Sec_uYear5.Left = 6.737501F;
            this.Sec_uYear5.MultiLine = false;
            this.Sec_uYear5.Name = "Sec_uYear5";
            this.Sec_uYear5.OutputFormat = resources.GetString("Sec_uYear5.OutputFormat");
            this.Sec_uYear5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear5.SummaryGroup = "SectionHeader";
            this.Sec_uYear5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear5.Text = "123,456,789,012";
            this.Sec_uYear5.Top = 0.0625F;
            this.Sec_uYear5.Width = 0.9F;
            // 
            // Sec_uYear6
            // 
            this.Sec_uYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_uYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_uYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear6.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_uYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear6.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_uYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_uYear6.DataField = "";
            this.Sec_uYear6.Height = 0.156F;
            this.Sec_uYear6.Left = 7.762501F;
            this.Sec_uYear6.MultiLine = false;
            this.Sec_uYear6.Name = "Sec_uYear6";
            this.Sec_uYear6.OutputFormat = resources.GetString("Sec_uYear6.OutputFormat");
            this.Sec_uYear6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_uYear6.SummaryGroup = "SectionHeader";
            this.Sec_uYear6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_uYear6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_uYear6.Text = "123,456,789,012";
            this.Sec_uYear6.Top = 0.0625F;
            this.Sec_uYear6.Width = 0.9F;
            // 
            // Sec_dYear8
            // 
            this.Sec_dYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear8.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear8.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear8.DataField = "";
            this.Sec_dYear8.Height = 0.156F;
            this.Sec_dYear8.Left = 9.8125F;
            this.Sec_dYear8.MultiLine = false;
            this.Sec_dYear8.Name = "Sec_dYear8";
            this.Sec_dYear8.OutputFormat = resources.GetString("Sec_dYear8.OutputFormat");
            this.Sec_dYear8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear8.SummaryGroup = "SectionHeader";
            this.Sec_dYear8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear8.Text = "123,456,789,012";
            this.Sec_dYear8.Top = 0.25F;
            this.Sec_dYear8.Width = 0.9F;
            // 
            // Sec_dYear7
            // 
            this.Sec_dYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear7.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear7.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear7.DataField = "";
            this.Sec_dYear7.Height = 0.156F;
            this.Sec_dYear7.Left = 8.7875F;
            this.Sec_dYear7.MultiLine = false;
            this.Sec_dYear7.Name = "Sec_dYear7";
            this.Sec_dYear7.OutputFormat = resources.GetString("Sec_dYear7.OutputFormat");
            this.Sec_dYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear7.SummaryGroup = "SectionHeader";
            this.Sec_dYear7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear7.Text = "123,456,789,012";
            this.Sec_dYear7.Top = 0.25F;
            this.Sec_dYear7.Width = 0.9F;
            // 
            // Sec_dYear1
            // 
            this.Sec_dYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear1.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear1.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear1.DataField = "";
            this.Sec_dYear1.Height = 0.156F;
            this.Sec_dYear1.Left = 2.6375F;
            this.Sec_dYear1.MultiLine = false;
            this.Sec_dYear1.Name = "Sec_dYear1";
            this.Sec_dYear1.OutputFormat = resources.GetString("Sec_dYear1.OutputFormat");
            this.Sec_dYear1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear1.SummaryGroup = "SectionHeader";
            this.Sec_dYear1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear1.Text = "123,456,789,012";
            this.Sec_dYear1.Top = 0.25F;
            this.Sec_dYear1.Width = 0.9F;
            // 
            // Sec_dYear2
            // 
            this.Sec_dYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear2.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear2.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear2.DataField = "";
            this.Sec_dYear2.Height = 0.156F;
            this.Sec_dYear2.Left = 3.6625F;
            this.Sec_dYear2.MultiLine = false;
            this.Sec_dYear2.Name = "Sec_dYear2";
            this.Sec_dYear2.OutputFormat = resources.GetString("Sec_dYear2.OutputFormat");
            this.Sec_dYear2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear2.SummaryGroup = "SectionHeader";
            this.Sec_dYear2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear2.Text = "123,456,789,012";
            this.Sec_dYear2.Top = 0.25F;
            this.Sec_dYear2.Width = 0.9F;
            // 
            // Sec_dYear3
            // 
            this.Sec_dYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear3.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear3.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear3.DataField = "";
            this.Sec_dYear3.Height = 0.156F;
            this.Sec_dYear3.Left = 4.6875F;
            this.Sec_dYear3.MultiLine = false;
            this.Sec_dYear3.Name = "Sec_dYear3";
            this.Sec_dYear3.OutputFormat = resources.GetString("Sec_dYear3.OutputFormat");
            this.Sec_dYear3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear3.SummaryGroup = "SectionHeader";
            this.Sec_dYear3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear3.Text = "123,456,789,012";
            this.Sec_dYear3.Top = 0.25F;
            this.Sec_dYear3.Width = 0.9F;
            // 
            // Sec_dYear4
            // 
            this.Sec_dYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear4.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear4.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear4.DataField = "";
            this.Sec_dYear4.Height = 0.156F;
            this.Sec_dYear4.Left = 5.712501F;
            this.Sec_dYear4.MultiLine = false;
            this.Sec_dYear4.Name = "Sec_dYear4";
            this.Sec_dYear4.OutputFormat = resources.GetString("Sec_dYear4.OutputFormat");
            this.Sec_dYear4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear4.SummaryGroup = "SectionHeader";
            this.Sec_dYear4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear4.Text = "123,456,789,012";
            this.Sec_dYear4.Top = 0.25F;
            this.Sec_dYear4.Width = 0.9F;
            // 
            // Sec_dYear5
            // 
            this.Sec_dYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear5.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear5.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear5.DataField = "";
            this.Sec_dYear5.Height = 0.156F;
            this.Sec_dYear5.Left = 6.737501F;
            this.Sec_dYear5.MultiLine = false;
            this.Sec_dYear5.Name = "Sec_dYear5";
            this.Sec_dYear5.OutputFormat = resources.GetString("Sec_dYear5.OutputFormat");
            this.Sec_dYear5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear5.SummaryGroup = "SectionHeader";
            this.Sec_dYear5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear5.Text = "123,456,789,012";
            this.Sec_dYear5.Top = 0.25F;
            this.Sec_dYear5.Width = 0.9F;
            // 
            // Sec_dYear6
            // 
            this.Sec_dYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_dYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_dYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear6.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_dYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear6.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_dYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_dYear6.DataField = "";
            this.Sec_dYear6.Height = 0.156F;
            this.Sec_dYear6.Left = 7.762501F;
            this.Sec_dYear6.MultiLine = false;
            this.Sec_dYear6.Name = "Sec_dYear6";
            this.Sec_dYear6.OutputFormat = resources.GetString("Sec_dYear6.OutputFormat");
            this.Sec_dYear6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_dYear6.SummaryGroup = "SectionHeader";
            this.Sec_dYear6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_dYear6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_dYear6.Text = "123,456,789,012";
            this.Sec_dYear6.Top = 0.25F;
            this.Sec_dYear6.Width = 0.9F;
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
            this.line5.Width = 10.8125F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8125F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CusHd_CustomerCode,
            this.CusHd_CustomerName,
            this.line4});
            this.CustomerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.CustomerHeader.Height = 0.2291667F;
            this.CustomerHeader.KeepTogether = true;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.CustomerHeader.BeforePrint += new System.EventHandler(this.CustomerHeader_BeforePrint);
            // 
            // CusHd_CustomerCode
            // 
            this.CusHd_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.DataField = "CustomerCode";
            this.CusHd_CustomerCode.Height = 0.16F;
            this.CusHd_CustomerCode.Left = 0.0625F;
            this.CusHd_CustomerCode.MultiLine = false;
            this.CusHd_CustomerCode.Name = "CusHd_CustomerCode";
            this.CusHd_CustomerCode.OutputFormat = resources.GetString("CusHd_CustomerCode.OutputFormat");
            this.CusHd_CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CusHd_CustomerCode.Text = "12345678";
            this.CusHd_CustomerCode.Top = 0F;
            this.CusHd_CustomerCode.Width = 0.5F;
            // 
            // CusHd_CustomerName
            // 
            this.CusHd_CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.DataField = "CustomerName";
            this.CusHd_CustomerName.Height = 0.16F;
            this.CusHd_CustomerName.Left = 0.625F;
            this.CusHd_CustomerName.MultiLine = false;
            this.CusHd_CustomerName.Name = "CusHd_CustomerName";
            this.CusHd_CustomerName.OutputFormat = resources.GetString("CusHd_CustomerName.OutputFormat");
            this.CusHd_CustomerName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.CusHd_CustomerName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CusHd_CustomerName.Top = 0F;
            this.CusHd_CustomerName.Width = 2.3F;
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
            this.line4.Top = 0.16F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0.16F;
            this.line4.Y2 = 0.16F;
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox98,
            this.Cus_uYear8,
            this.Cus_uYear7,
            this.Cus_uYear1,
            this.Cus_uYear2,
            this.Cus_uYear3,
            this.Cus_uYear4,
            this.Cus_uYear5,
            this.Cus_uYear6,
            this.Cus_dYear8,
            this.Cus_dYear7,
            this.Cus_dYear1,
            this.Cus_dYear2,
            this.Cus_dYear3,
            this.Cus_dYear4,
            this.Cus_dYear5,
            this.Cus_dYear6,
            this.line8});
            this.CustomerFooter.Height = 0.4583333F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
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
            this.textBox98.Height = 0.219F;
            this.textBox98.Left = 1.75F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox98.Text = "得意先計";
            this.textBox98.Top = 0.0625F;
            this.textBox98.Width = 0.8F;
            // 
            // Cus_uYear8
            // 
            this.Cus_uYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear8.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear8.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear8.DataField = "";
            this.Cus_uYear8.Height = 0.156F;
            this.Cus_uYear8.Left = 9.8125F;
            this.Cus_uYear8.MultiLine = false;
            this.Cus_uYear8.Name = "Cus_uYear8";
            this.Cus_uYear8.OutputFormat = resources.GetString("Cus_uYear8.OutputFormat");
            this.Cus_uYear8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear8.SummaryGroup = "CustomerHeader";
            this.Cus_uYear8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear8.Text = "123,456,789,012";
            this.Cus_uYear8.Top = 0.0625F;
            this.Cus_uYear8.Width = 0.9F;
            // 
            // Cus_uYear7
            // 
            this.Cus_uYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear7.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear7.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear7.DataField = "";
            this.Cus_uYear7.Height = 0.156F;
            this.Cus_uYear7.Left = 8.7875F;
            this.Cus_uYear7.MultiLine = false;
            this.Cus_uYear7.Name = "Cus_uYear7";
            this.Cus_uYear7.OutputFormat = resources.GetString("Cus_uYear7.OutputFormat");
            this.Cus_uYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear7.SummaryGroup = "CustomerHeader";
            this.Cus_uYear7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear7.Text = "123,456,789,012";
            this.Cus_uYear7.Top = 0.0625F;
            this.Cus_uYear7.Width = 0.9F;
            // 
            // Cus_uYear1
            // 
            this.Cus_uYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear1.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear1.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear1.DataField = "";
            this.Cus_uYear1.Height = 0.156F;
            this.Cus_uYear1.Left = 2.6375F;
            this.Cus_uYear1.MultiLine = false;
            this.Cus_uYear1.Name = "Cus_uYear1";
            this.Cus_uYear1.OutputFormat = resources.GetString("Cus_uYear1.OutputFormat");
            this.Cus_uYear1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear1.SummaryGroup = "CustomerHeader";
            this.Cus_uYear1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear1.Text = "123,456,789,012";
            this.Cus_uYear1.Top = 0.0625F;
            this.Cus_uYear1.Width = 0.9F;
            // 
            // Cus_uYear2
            // 
            this.Cus_uYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear2.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear2.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear2.DataField = "";
            this.Cus_uYear2.Height = 0.156F;
            this.Cus_uYear2.Left = 3.6625F;
            this.Cus_uYear2.MultiLine = false;
            this.Cus_uYear2.Name = "Cus_uYear2";
            this.Cus_uYear2.OutputFormat = resources.GetString("Cus_uYear2.OutputFormat");
            this.Cus_uYear2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear2.SummaryGroup = "CustomerHeader";
            this.Cus_uYear2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear2.Text = "123,456,789,012";
            this.Cus_uYear2.Top = 0.0625F;
            this.Cus_uYear2.Width = 0.9F;
            // 
            // Cus_uYear3
            // 
            this.Cus_uYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear3.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear3.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear3.DataField = "";
            this.Cus_uYear3.Height = 0.156F;
            this.Cus_uYear3.Left = 4.6875F;
            this.Cus_uYear3.MultiLine = false;
            this.Cus_uYear3.Name = "Cus_uYear3";
            this.Cus_uYear3.OutputFormat = resources.GetString("Cus_uYear3.OutputFormat");
            this.Cus_uYear3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear3.SummaryGroup = "CustomerHeader";
            this.Cus_uYear3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear3.Text = "123,456,789,012";
            this.Cus_uYear3.Top = 0.0625F;
            this.Cus_uYear3.Width = 0.9F;
            // 
            // Cus_uYear4
            // 
            this.Cus_uYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear4.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear4.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear4.DataField = "";
            this.Cus_uYear4.Height = 0.156F;
            this.Cus_uYear4.Left = 5.712501F;
            this.Cus_uYear4.MultiLine = false;
            this.Cus_uYear4.Name = "Cus_uYear4";
            this.Cus_uYear4.OutputFormat = resources.GetString("Cus_uYear4.OutputFormat");
            this.Cus_uYear4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear4.SummaryGroup = "CustomerHeader";
            this.Cus_uYear4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear4.Text = "123,456,789,012";
            this.Cus_uYear4.Top = 0.0625F;
            this.Cus_uYear4.Width = 0.9F;
            // 
            // Cus_uYear5
            // 
            this.Cus_uYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear5.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear5.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear5.DataField = "";
            this.Cus_uYear5.Height = 0.156F;
            this.Cus_uYear5.Left = 6.737501F;
            this.Cus_uYear5.MultiLine = false;
            this.Cus_uYear5.Name = "Cus_uYear5";
            this.Cus_uYear5.OutputFormat = resources.GetString("Cus_uYear5.OutputFormat");
            this.Cus_uYear5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear5.SummaryGroup = "CustomerHeader";
            this.Cus_uYear5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear5.Text = "123,456,789,012";
            this.Cus_uYear5.Top = 0.0625F;
            this.Cus_uYear5.Width = 0.9F;
            // 
            // Cus_uYear6
            // 
            this.Cus_uYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_uYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_uYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear6.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_uYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear6.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_uYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_uYear6.DataField = "";
            this.Cus_uYear6.Height = 0.156F;
            this.Cus_uYear6.Left = 7.762501F;
            this.Cus_uYear6.MultiLine = false;
            this.Cus_uYear6.Name = "Cus_uYear6";
            this.Cus_uYear6.OutputFormat = resources.GetString("Cus_uYear6.OutputFormat");
            this.Cus_uYear6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_uYear6.SummaryGroup = "CustomerHeader";
            this.Cus_uYear6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_uYear6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_uYear6.Text = "123,456,789,012";
            this.Cus_uYear6.Top = 0.0625F;
            this.Cus_uYear6.Width = 0.9F;
            // 
            // Cus_dYear8
            // 
            this.Cus_dYear8.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear8.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear8.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear8.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear8.DataField = "";
            this.Cus_dYear8.Height = 0.156F;
            this.Cus_dYear8.Left = 9.8125F;
            this.Cus_dYear8.MultiLine = false;
            this.Cus_dYear8.Name = "Cus_dYear8";
            this.Cus_dYear8.OutputFormat = resources.GetString("Cus_dYear8.OutputFormat");
            this.Cus_dYear8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear8.SummaryGroup = "CustomerHeader";
            this.Cus_dYear8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear8.Text = "123,456,789,012";
            this.Cus_dYear8.Top = 0.25F;
            this.Cus_dYear8.Width = 0.9F;
            // 
            // Cus_dYear7
            // 
            this.Cus_dYear7.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear7.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear7.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear7.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear7.DataField = "";
            this.Cus_dYear7.Height = 0.156F;
            this.Cus_dYear7.Left = 8.7875F;
            this.Cus_dYear7.MultiLine = false;
            this.Cus_dYear7.Name = "Cus_dYear7";
            this.Cus_dYear7.OutputFormat = resources.GetString("Cus_dYear7.OutputFormat");
            this.Cus_dYear7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear7.SummaryGroup = "CustomerHeader";
            this.Cus_dYear7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear7.Text = "123,456,789,012";
            this.Cus_dYear7.Top = 0.25F;
            this.Cus_dYear7.Width = 0.9F;
            // 
            // Cus_dYear1
            // 
            this.Cus_dYear1.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear1.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear1.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear1.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear1.DataField = "";
            this.Cus_dYear1.Height = 0.156F;
            this.Cus_dYear1.Left = 2.6375F;
            this.Cus_dYear1.MultiLine = false;
            this.Cus_dYear1.Name = "Cus_dYear1";
            this.Cus_dYear1.OutputFormat = resources.GetString("Cus_dYear1.OutputFormat");
            this.Cus_dYear1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear1.SummaryGroup = "CustomerHeader";
            this.Cus_dYear1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear1.Text = "123,456,789,012";
            this.Cus_dYear1.Top = 0.25F;
            this.Cus_dYear1.Width = 0.9F;
            // 
            // Cus_dYear2
            // 
            this.Cus_dYear2.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear2.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear2.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear2.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear2.DataField = "";
            this.Cus_dYear2.Height = 0.156F;
            this.Cus_dYear2.Left = 3.6625F;
            this.Cus_dYear2.MultiLine = false;
            this.Cus_dYear2.Name = "Cus_dYear2";
            this.Cus_dYear2.OutputFormat = resources.GetString("Cus_dYear2.OutputFormat");
            this.Cus_dYear2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear2.SummaryGroup = "CustomerHeader";
            this.Cus_dYear2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear2.Text = "123,456,789,012";
            this.Cus_dYear2.Top = 0.25F;
            this.Cus_dYear2.Width = 0.9F;
            // 
            // Cus_dYear3
            // 
            this.Cus_dYear3.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear3.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear3.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear3.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear3.DataField = "";
            this.Cus_dYear3.Height = 0.156F;
            this.Cus_dYear3.Left = 4.6875F;
            this.Cus_dYear3.MultiLine = false;
            this.Cus_dYear3.Name = "Cus_dYear3";
            this.Cus_dYear3.OutputFormat = resources.GetString("Cus_dYear3.OutputFormat");
            this.Cus_dYear3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear3.SummaryGroup = "CustomerHeader";
            this.Cus_dYear3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear3.Text = "123,456,789,012";
            this.Cus_dYear3.Top = 0.25F;
            this.Cus_dYear3.Width = 0.9F;
            // 
            // Cus_dYear4
            // 
            this.Cus_dYear4.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear4.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear4.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear4.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear4.DataField = "";
            this.Cus_dYear4.Height = 0.156F;
            this.Cus_dYear4.Left = 5.712501F;
            this.Cus_dYear4.MultiLine = false;
            this.Cus_dYear4.Name = "Cus_dYear4";
            this.Cus_dYear4.OutputFormat = resources.GetString("Cus_dYear4.OutputFormat");
            this.Cus_dYear4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear4.SummaryGroup = "CustomerHeader";
            this.Cus_dYear4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear4.Text = "123,456,789,012";
            this.Cus_dYear4.Top = 0.25F;
            this.Cus_dYear4.Width = 0.9F;
            // 
            // Cus_dYear5
            // 
            this.Cus_dYear5.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear5.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear5.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear5.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear5.DataField = "";
            this.Cus_dYear5.Height = 0.156F;
            this.Cus_dYear5.Left = 6.737501F;
            this.Cus_dYear5.MultiLine = false;
            this.Cus_dYear5.Name = "Cus_dYear5";
            this.Cus_dYear5.OutputFormat = resources.GetString("Cus_dYear5.OutputFormat");
            this.Cus_dYear5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear5.SummaryGroup = "CustomerHeader";
            this.Cus_dYear5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear5.Text = "123,456,789,012";
            this.Cus_dYear5.Top = 0.25F;
            this.Cus_dYear5.Width = 0.9F;
            // 
            // Cus_dYear6
            // 
            this.Cus_dYear6.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_dYear6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear6.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_dYear6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear6.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_dYear6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear6.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_dYear6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_dYear6.DataField = "";
            this.Cus_dYear6.Height = 0.156F;
            this.Cus_dYear6.Left = 7.762501F;
            this.Cus_dYear6.MultiLine = false;
            this.Cus_dYear6.Name = "Cus_dYear6";
            this.Cus_dYear6.OutputFormat = resources.GetString("Cus_dYear6.OutputFormat");
            this.Cus_dYear6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_dYear6.SummaryGroup = "CustomerHeader";
            this.Cus_dYear6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_dYear6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_dYear6.Text = "123,456,789,012";
            this.Cus_dYear6.Top = 0.25F;
            this.Cus_dYear6.Width = 0.9F;
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
            this.line8.Width = 10.8125F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8125F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // PMHNB04132P_01A4C
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
            this.PrintWidth = 10.875F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMHNB04132P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Year7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CustomerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_uYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gra_dYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_uYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_dYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_uYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_dYear6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
       
    }
}
