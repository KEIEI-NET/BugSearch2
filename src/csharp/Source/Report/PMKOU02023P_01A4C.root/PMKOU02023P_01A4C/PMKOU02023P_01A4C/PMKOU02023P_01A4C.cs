//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入分析表
// プログラム概要   : 仕入分析表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/11/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13156
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13136】残案件No.19 端数処理
//----------------------------------------------------------------------------//

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
    /// 仕入分析表帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 仕入分析表帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.10</br>
    /// <br>Update Note  : 2009/04/07 30452 上野 俊治</br>
    /// <br>              ・障害対応13156</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMKOU02023P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKOU02023P_01A4C()
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

        private SlipHistAnalyzeParam _slipHistAnalyzeParam;	// 抽出条件クラス

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
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.GroupHeader SupplierHeader;
        private DataDynamics.ActiveReports.GroupFooter SupplierFooter;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox tb_PrintDate;
        private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.Label Lb_Title1;
        private DataDynamics.ActiveReports.Label Lb_Title2;
        private DataDynamics.ActiveReports.Line SecHd_line;
        private DataDynamics.ActiveReports.TextBox SecHd_SectionCode;
        private DataDynamics.ActiveReports.TextBox SecHd_SectionName;
        private DataDynamics.ActiveReports.TextBox SupHd_SuplierCode;
        private DataDynamics.ActiveReports.TextBox SupHd_SuplierName;
        private DataDynamics.ActiveReports.TextBox CodeName;
        private DataDynamics.ActiveReports.TextBox Code;
        private DataDynamics.ActiveReports.TextBox TotalPrice;
        private DataDynamics.ActiveReports.TextBox RetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox RetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox TotalDiscount;
        private DataDynamics.ActiveReports.TextBox PureTotalPrice;
        private DataDynamics.ActiveReports.TextBox ConstUnitRate;
        private DataDynamics.ActiveReports.TextBox StockPrice;
        private DataDynamics.ActiveReports.TextBox OrderPrice;
        private DataDynamics.ActiveReports.TextBox StockPriceRate;
        private DataDynamics.ActiveReports.TextBox ySeparator;
        private DataDynamics.ActiveReports.TextBox OrderPriceRate;
        private DataDynamics.ActiveReports.TextBox AnnualTotalPrice;
        private DataDynamics.ActiveReports.TextBox AnnualRetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox AnnualRetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox AnnualTotalDiscount;
        private DataDynamics.ActiveReports.TextBox AnnualPureTotalPrice;
        private DataDynamics.ActiveReports.TextBox AnnualConstUnitRate;
        private DataDynamics.ActiveReports.TextBox AnnualStockPrice;
        private DataDynamics.ActiveReports.TextBox AnnualOrderPrice;
        private DataDynamics.ActiveReports.TextBox AnnualStockPriceRate;
        private DataDynamics.ActiveReports.TextBox dSeparator;
        private DataDynamics.ActiveReports.TextBox AnnualOrderPriceRate;
        private DataDynamics.ActiveReports.TextBox SupFt_TotalPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_RetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_RetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox SupFt_TotalDiscount;
        private DataDynamics.ActiveReports.TextBox SupFt_PureTotalPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_ConstUnitRate;
        private DataDynamics.ActiveReports.TextBox SupFt_StockPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_OrderPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_StockPriceRate;
        private DataDynamics.ActiveReports.TextBox SupFt_ySeparator;
        private DataDynamics.ActiveReports.TextBox SupFt_OrderPriceRate;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualTotalPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualRetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualRetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualTotalDiscount;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualPureTotalPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualConstUnitRate;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualStockPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualOrderPrice;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualStockPriceRate;
        private DataDynamics.ActiveReports.TextBox SupFt_dSeparator;
        private DataDynamics.ActiveReports.TextBox SupFt_AnnualOrderPriceRate;
        private DataDynamics.ActiveReports.TextBox SecFt_TotalPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_RetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_RetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox SecFt_TotalDiscount;
        private DataDynamics.ActiveReports.TextBox SecFt_PureTotalPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_ConstUnitRate;
        private DataDynamics.ActiveReports.TextBox SecFt_StockPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_OrderPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_StockPriceRate;
        private DataDynamics.ActiveReports.TextBox SecFt_ySeparator;
        private DataDynamics.ActiveReports.TextBox SecFt_OrderPriceRate;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualTotalPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualRetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualRetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualTotalDiscount;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualPureTotalPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualConstUnitRate;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualStockPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualOrderPrice;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualStockPriceRate;
        private DataDynamics.ActiveReports.TextBox SecFt_dSeparator;
        private DataDynamics.ActiveReports.TextBox SecFt_AnnualOrderPriceRate;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.TextBox GraFt_TotalPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_RetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_RetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox GraFt_TotalDiscount;
        private DataDynamics.ActiveReports.TextBox GraFt_PureTotalPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_StockPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_OrderPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_StockPriceRate;
        private DataDynamics.ActiveReports.TextBox GraFt_ySeparator;
        private DataDynamics.ActiveReports.TextBox GraFt_OrderPriceRate;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualTotalPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualRetGoodsPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualRetGoodsPriceRate;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualTotalDiscount;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualPureTotalPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualStockPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualOrderPrice;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualStockPriceRate;
        private DataDynamics.ActiveReports.TextBox GraFt_dSeparator;
        private DataDynamics.ActiveReports.TextBox GraFt_AnnualOrderPriceRate;
        private DataDynamics.ActiveReports.Label GrandTotalTitle;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.Line line5;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label label9;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Label label13;
        private DataDynamics.ActiveReports.Label label14;
        private TextBox GraFt_ConstUnitRate;
        private TextBox GraFt_AnnualConstUnitRate;
        private TextBox TotalPriceOrg;
        private TextBox RetGoodsPriceOrg;
        private TextBox AnnualTotalPriceOrg;
        private TextBox AnnualRetGoodsPriceOrg;
        private TextBox TotalDiscountOrg;
        private TextBox PureTotalPriceOrg;
        private TextBox AnnualTotalDiscountOrg;
        private TextBox AnnualPureTotalPriceOrg;
        private TextBox StockPriceOrg;
        private TextBox OrderPriceOrg;
        private TextBox AnnualStockPriceOrg;
        private TextBox AnnualOrderPriceOrg;
        private TextBox SupFt_TotalPriceOrg;
        private TextBox SupFt_RetGoodsPriceOrg;
        private TextBox SupFt_AnnualTotalPriceOrg;
        private TextBox SupFt_AnnualRetGoodsPriceOrg;
        private TextBox SupFt_TotalDiscountOrg;
        private TextBox SupFt_PureTotalPriceOrg;
        private TextBox SupFt_AnnualTotalDiscountOrg;
        private TextBox SupFt_AnnualPureTotalPriceOrg;
        private TextBox SupFt_StockPriceOrg;
        private TextBox SupFt_OrderPriceOrg;
        private TextBox SupFt_AnnualStockPriceOrg;
        private TextBox SupFt_AnnualOrderPriceOrg;
        private TextBox SecFt_TotalPriceOrg;
        private TextBox SecFt_RetGoodsPriceOrg;
        private TextBox SecFt_AnnualTotalPriceOrg;
        private TextBox SecFt_AnnualRetGoodsPriceOrg;
        private TextBox SecFt_TotalDiscountOrg;
        private TextBox SecFt_PureTotalPriceOrg;
        private TextBox SecFt_AnnualTotalDiscountOrg;
        private TextBox SecFt_AnnualPureTotalPriceOrg;
        private TextBox SecFt_StockPriceOrg;
        private TextBox SecFt_OrderPriceOrg;
        private TextBox SecFt_AnnualStockPriceOrg;
        private TextBox SecFt_AnnualOrderPriceOrg;
        private TextBox GraFt_TotalPriceOrg;
        private TextBox GraFt_RetGoodsPriceOrg;
        private TextBox GraFt_AnnualTotalPriceOrg;
        private TextBox GraFt_AnnualRetGoodsPriceOrg;
        private TextBox GraFt_StockPriceOrg;
        private TextBox GraFt_OrderPriceOrg;
        private TextBox GraFt_AnnualStockPriceOrg;
        private TextBox GraFt_AnnualOrderPriceOrg;
        private TextBox PureTotalPriceSum;
        private TextBox AnnualPureTotalPriceSum;
        private TextBox SupFt_PureTotalPriceSum;
        private TextBox SupFt_AnnualPureTotalPriceSum;
        private TextBox SecFt_PureTotalPriceSum;
        private TextBox SecFt_AnnualPureTotalPriceSum;
        private TextBox GraFt_PureTotalPriceOrg;
        private TextBox GraFt_AnnualPureTotalPriceOrg;
        private Line line6;
        private Line line2;
        private Line line8;
        private DataDynamics.ActiveReports.Label label15;
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
                this._slipHistAnalyzeParam = (SlipHistAnalyzeParam)this._printInfo.jyoken;
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

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //-------------------------------------------------------
            // 印字タイプ（上段・下段）の適用
            //-------------------------------------------------------
            #region [印刷タイプ（上段・下段）の適用]
            // 0:当月＆当期 1:当月 2:当期
            #region [作業用のリストを生成]
            // 上段項目リスト
            List<TextBox> uList = new List<TextBox>();
            uList.AddRange(new TextBox[] { TotalPrice, RetGoodsPrice, RetGoodsPriceRate, TotalDiscount, PureTotalPrice, ConstUnitRate, StockPrice, OrderPrice, StockPriceRate, ySeparator, OrderPriceRate });

            List<TextBox> SupFt_uList = new List<TextBox>();
            SupFt_uList.AddRange(new TextBox[] { SupFt_TotalPrice, SupFt_RetGoodsPrice, SupFt_RetGoodsPriceRate, SupFt_TotalDiscount, SupFt_PureTotalPrice, SupFt_ConstUnitRate, SupFt_StockPrice, SupFt_OrderPrice, SupFt_StockPriceRate, SupFt_ySeparator, SupFt_OrderPriceRate });

            List<TextBox> SecFt_uList = new List<TextBox>();
            SecFt_uList.AddRange(new TextBox[] { SecFt_TotalPrice, SecFt_RetGoodsPrice, SecFt_RetGoodsPriceRate, SecFt_TotalDiscount, SecFt_PureTotalPrice, SecFt_ConstUnitRate, SecFt_StockPrice, SecFt_OrderPrice, SecFt_StockPriceRate, SecFt_ySeparator, SecFt_OrderPriceRate });

            List<TextBox> GraFt_uList = new List<TextBox>();
            GraFt_uList.AddRange(new TextBox[] { GraFt_TotalPrice, GraFt_RetGoodsPrice, GraFt_RetGoodsPriceRate, GraFt_TotalDiscount, GraFt_PureTotalPrice, GraFt_ConstUnitRate, GraFt_StockPrice, GraFt_OrderPrice, GraFt_StockPriceRate, GraFt_ySeparator, GraFt_OrderPriceRate });

            // 下段項目リスト
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { AnnualTotalPrice, AnnualRetGoodsPrice, AnnualRetGoodsPriceRate, AnnualTotalDiscount, AnnualPureTotalPrice, AnnualConstUnitRate, AnnualStockPrice, AnnualOrderPrice, AnnualStockPriceRate, dSeparator, AnnualOrderPriceRate });

            List<TextBox> SupFt_dList = new List<TextBox>();
            SupFt_dList.AddRange(new TextBox[] { SupFt_AnnualTotalPrice, SupFt_AnnualRetGoodsPrice, SupFt_AnnualRetGoodsPriceRate, SupFt_AnnualTotalDiscount, SupFt_AnnualPureTotalPrice, SupFt_AnnualConstUnitRate, SupFt_AnnualStockPrice, SupFt_AnnualOrderPrice, SupFt_AnnualStockPriceRate, SupFt_dSeparator, SupFt_AnnualOrderPriceRate });

            List<TextBox> SecFt_dList = new List<TextBox>();
            SecFt_dList.AddRange(new TextBox[] { SecFt_AnnualTotalPrice, SecFt_AnnualRetGoodsPrice, SecFt_AnnualRetGoodsPriceRate, SecFt_AnnualTotalDiscount, SecFt_AnnualPureTotalPrice, SecFt_AnnualConstUnitRate, SecFt_AnnualStockPrice, SecFt_AnnualOrderPrice, SecFt_AnnualStockPriceRate, SecFt_dSeparator, SecFt_AnnualOrderPriceRate });

            List<TextBox> GraFt_dList = new List<TextBox>();
            GraFt_dList.AddRange(new TextBox[] { GraFt_AnnualTotalPrice, GraFt_AnnualRetGoodsPrice, GraFt_AnnualRetGoodsPriceRate, GraFt_AnnualTotalDiscount, GraFt_AnnualPureTotalPrice, GraFt_AnnualConstUnitRate, GraFt_AnnualStockPrice, GraFt_AnnualOrderPrice, GraFt_AnnualStockPriceRate, GraFt_dSeparator, GraFt_AnnualOrderPriceRate });

            #endregion

            // visible設定
            if (this._slipHistAnalyzeParam.PrintTermType != SlipHistAnalyzeParam.PrintTermTypeState.MonthAndTerm)
            {
                // 上段のみ　→　全ての下段を非印字にする
                for (int index = 0; index < dList.Count; index++)
                {
                    // 数量非印字
                    dList[index].Visible = false;
                    SupFt_dList[index].Visible = false;
                    SecFt_dList[index].Visible = false;
                    GraFt_dList[index].Visible = false;
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
            // 0:当月＆当期 1:当月 2:当期
            #region [作業用のリストを生成]
            // 売上金額
            List<string> MonthList = new List<string>();
            MonthList.AddRange(new string[] { "TotalPrice", "RetGoodsPrice", "", "TotalDiscount", "PureTotalPrice", "", "StockPrice", "OrderPrice", "", "", "" });

            //// 粗利金額
            List<string> TermList = new List<string>();
            TermList.AddRange(new string[] { "AnnualTotalPrice", "AnnualRetGoodsPrice", "", "AnnualTotalDiscount", "AnnualPureTotalPrice", "", "AnnualStockPrice", "AnnualOrderPrice", "", "", "" });

            #endregion

            switch (_slipHistAnalyzeParam.PrintTermType)
            {
                //0:売上＆粗利
                case SlipHistAnalyzeParam.PrintTermTypeState.MonthAndTerm:
                    //上段 (当月)
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = MonthList[index];
                        SupFt_uList[index].DataField = MonthList[index];
                        SecFt_uList[index].DataField = MonthList[index];
                        GraFt_uList[index].DataField = MonthList[index];
                    }
                    //下段 (当期)
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = TermList[index];
                        SupFt_dList[index].DataField = TermList[index];
                        SecFt_dList[index].DataField = TermList[index];
                        GraFt_dList[index].DataField = TermList[index];
                    }
                    break;
                //1:当月
                case SlipHistAnalyzeParam.PrintTermTypeState.Month:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = MonthList[index];
                        SupFt_uList[index].DataField = MonthList[index];
                        SecFt_uList[index].DataField = MonthList[index];
                        GraFt_uList[index].DataField = MonthList[index];
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = string.Empty;
                        SupFt_dList[index].DataField = string.Empty;
                        SecFt_dList[index].DataField = string.Empty;
                        GraFt_dList[index].DataField = string.Empty;
                    }
                    break;
                //2:当期
                case SlipHistAnalyzeParam.PrintTermTypeState.Term:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = TermList[index];
                        SupFt_uList[index].DataField = TermList[index];
                        SecFt_uList[index].DataField = TermList[index];
                        GraFt_uList[index].DataField = TermList[index];
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = string.Empty;
                        SupFt_dList[index].DataField = string.Empty;
                        SecFt_dList[index].DataField = string.Empty;
                        GraFt_dList[index].DataField = string.Empty;
                    }
                    break;

            }

            #endregion

            //-------------------------------------------------------
            // TitleHeader設定
            //-------------------------------------------------------
            #region [TitleHeader設定]
            if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
            {
                // レイアウト通り
            }
            else if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Supplier)
            {
                this.Lb_Title1.Text = "仕入先";
                this.Lb_Title2.Text = "拠点";
            }

            #endregion

            //-------------------------------------------------------
            // グループヘッダ表示・DataField設定
            //-------------------------------------------------------
            #region [グループヘッダ設定]
            if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
            {
                this.SectionHeader.Visible = true;
                this.SectionFooter.Visible = true;
                this.SectionHeader.DataField = PMKOU02025EA.ct_Col_AddUpSecCode;

                this.SupplierHeader.Visible = false;
                this.SupplierFooter.Visible = false;
                this.SupplierHeader.DataField = string.Empty;
            }
            else if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Supplier)
            {
                this.SectionHeader.Visible = false;
                this.SectionFooter.Visible = false;
                this.SectionHeader.DataField = string.Empty;

                this.SupplierHeader.Visible = true;
                this.SupplierFooter.Visible = true;
                this.SupplierHeader.DataField = PMKOU02025EA.ct_Col_SupplierCd;
            }
            #endregion

            //-------------------------------------------------------
            // 改頁設定
            // 0:する(小計毎) 1:しない
            //-------------------------------------------------------
            #region [改頁設定]
            if (_slipHistAnalyzeParam.NewPageDiv == SlipHistAnalyzeParam.NewPageDivState.Do)
            {
                if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
                {
                    SectionHeader.NewPage = NewPage.Before;
                }
                else if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Supplier)
                {
                    SupplierHeader.NewPage = NewPage.Before;
                }
            }
            #endregion

            //-------------------------------------------------------
            // 明細設定
            //-------------------------------------------------------
            #region [明細設定]
            if (_slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
            {
                this.Code.DataField = PMKOU02025EA.ct_Col_SupplierCd;
                this.Code.OutputFormat = "000000";

                this.CodeName.DataField = PMKOU02025EA.ct_Col_SupplierSnm;
            }
            else
            {
                this.Code.DataField = PMKOU02025EA.ct_Col_AddUpSecCode;
                this.Code.OutputFormat = "00";

                this.CodeName.DataField = PMKOU02025EA.ct_Col_SectionGuideSnm;
            }
            #endregion

            // 総合計の構成比は表示しない
            this.GraFt_ConstUnitRate.Visible = false;
            this.GraFt_AnnualConstUnitRate.Visible = false;
        }

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="num">分子</param>
        /// <param name="den">分母</param>
        private double GetRatio(Int64 num, Int64 den)
        {
            decimal workRate;

            decimal numerator = Convert.ToDecimal(num);
            decimal denominator = Convert.ToDecimal(den);

            if (denominator == 0)
            {
                workRate = 0.00M;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            if (workRate < 0) workRate = workRate * -1;

            return Convert.ToDouble(workRate);
        }
        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMKOU02023P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU02023P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageHeader_Format(object sender, EventArgs e)
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
        /// <param name="e"></param>
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
        /// SupplierHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierHeader_BeforePrint(object sender, EventArgs e)
        {
            // 仕入先コードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.SupHd_SuplierCode.Text)
                || this.SupHd_SuplierCode.Text.PadLeft(6, '0') == "000000")
            {
                this.SupHd_SuplierCode.Text = string.Empty;
                this.SupHd_SuplierName.Text = string.Empty;
            }
        }

        /// <summary>
        /// detail_AfterPrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // 拠点コードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.Code.Text)
                || Convert.ToInt32(this.Code.Text) == 0)
            {
                this.Code.Text = string.Empty;
                this.CodeName.Text = string.Empty;
            }

            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { TotalPrice, RetGoodsPrice, TotalDiscount, PureTotalPrice, StockPrice, OrderPrice,
                                           AnnualTotalPrice, AnnualRetGoodsPrice, AnnualTotalDiscount, AnnualPureTotalPrice, AnnualStockPrice, AnnualOrderPrice });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.MonthAndTerm)
            {
                // 返品率(当月)
                this.RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.RetGoodsPriceOrg.Value), Convert.ToInt64(this.TotalPriceOrg.Value));
                // 構成比(当月)
                this.ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.PureTotalPriceOrg.Value), Convert.ToInt64(this.PureTotalPriceSum.Value));
                // 在庫比(当月)
                this.StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.StockPriceOrg.Value), Convert.ToInt64(this.PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.OrderPriceOrg.Value), Convert.ToInt64(this.PureTotalPriceOrg.Value));

                // 返品率(当期)
                this.AnnualRetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.AnnualTotalPriceOrg.Value));
                // 構成比(当期)
                this.AnnualConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualPureTotalPriceOrg.Value), Convert.ToInt64(this.AnnualPureTotalPriceSum.Value));
                // 在庫比(当期)
                this.AnnualStockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualStockPriceOrg.Value), Convert.ToInt64(this.AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.AnnualOrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualOrderPriceOrg.Value), Convert.ToInt64(this.AnnualPureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Month)
            {
                // 返品率(当月)
                this.RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.RetGoodsPriceOrg.Value), Convert.ToInt64(this.TotalPriceOrg.Value));
                // 構成比(当月)
                this.ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.PureTotalPriceOrg.Value), Convert.ToInt64(this.PureTotalPriceSum.Value));
                // 在庫比(当月)
                this.StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.StockPriceOrg.Value), Convert.ToInt64(this.PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.OrderPriceOrg.Value), Convert.ToInt64(this.PureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Term)
            {
                // 返品率(当期)
                this.RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.AnnualTotalPriceOrg.Value));
                // 構成比(当期)
                this.ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualPureTotalPriceOrg.Value), Convert.ToInt64(this.AnnualPureTotalPriceSum.Value));
                // 在庫比(当期)
                this.StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualStockPriceOrg.Value), Convert.ToInt64(this.AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.AnnualOrderPriceOrg.Value), Convert.ToInt64(this.AnnualPureTotalPriceOrg.Value));
            }

            // "%"の設定
            this.RetGoodsPriceRate.Text = this.RetGoodsPriceRate.Text + "%";
            this.ConstUnitRate.Text = this.ConstUnitRate.Text + "%";
            this.StockPriceRate.Text = this.StockPriceRate.Text + "%";
            this.OrderPriceRate.Text = this.OrderPriceRate.Text + "%";
            this.AnnualRetGoodsPriceRate.Text = this.AnnualRetGoodsPriceRate.Text + "%";
            this.AnnualConstUnitRate.Text = this.AnnualConstUnitRate.Text + "%";
            this.AnnualStockPriceRate.Text = this.AnnualStockPriceRate.Text + "%";
            this.AnnualOrderPriceRate.Text = this.AnnualOrderPriceRate.Text + "%";
        }

        /// <summary>
        /// SupplierFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { SupFt_TotalPrice, SupFt_RetGoodsPrice, SupFt_TotalDiscount, SupFt_PureTotalPrice, SupFt_StockPrice, SupFt_OrderPrice,
                                           SupFt_AnnualTotalPrice, SupFt_AnnualRetGoodsPrice, SupFt_AnnualTotalDiscount, SupFt_AnnualPureTotalPrice, SupFt_AnnualStockPrice, SupFt_AnnualOrderPrice });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.MonthAndTerm)
            {
                // 返品率(当月)
                this.SupFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_RetGoodsPriceOrg.Value), Convert.ToInt64(this.SupFt_TotalPriceOrg.Value));
                // 構成比(当月)
                this.SupFt_ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_PureTotalPriceOrg.Value), Convert.ToInt64(this.SupFt_PureTotalPriceSum.Value));
                // 在庫比(当月)
                this.SupFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_StockPriceOrg.Value), Convert.ToInt64(this.SupFt_PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.SupFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_OrderPriceOrg.Value), Convert.ToInt64(this.SupFt_PureTotalPriceOrg.Value));

                // 返品率(当期)
                this.SupFt_AnnualRetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualTotalPriceOrg.Value));
                // 構成比(当期)
                this.SupFt_AnnualConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualPureTotalPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualPureTotalPriceSum.Value));
                // 在庫比(当期)
                this.SupFt_AnnualStockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualStockPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.SupFt_AnnualOrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualOrderPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualPureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Month)
            {
                // 返品率(当月)
                this.SupFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_RetGoodsPriceOrg.Value), Convert.ToInt64(this.SupFt_TotalPriceOrg.Value));
                // 構成比(当月)
                this.SupFt_ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_PureTotalPriceOrg.Value), Convert.ToInt64(this.SupFt_PureTotalPriceSum.Value));
                // 在庫比(当月)
                this.SupFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_StockPriceOrg.Value), Convert.ToInt64(this.SupFt_PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.SupFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_OrderPriceOrg.Value), Convert.ToInt64(this.SupFt_PureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Term)
            {
                // 返品率(当期)
                this.SupFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualTotalPriceOrg.Value));
                // 構成比(当期)
                this.SupFt_ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualPureTotalPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualPureTotalPriceSum.Value));
                // 在庫比(当期)
                this.SupFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualStockPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.SupFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SupFt_AnnualOrderPriceOrg.Value), Convert.ToInt64(this.SupFt_AnnualPureTotalPriceOrg.Value));
            }

            // "%"の設定
            this.SupFt_RetGoodsPriceRate.Text = this.SupFt_RetGoodsPriceRate.Text + "%";
            this.SupFt_ConstUnitRate.Text = this.SupFt_ConstUnitRate.Text + "%";
            this.SupFt_StockPriceRate.Text = this.SupFt_StockPriceRate.Text + "%";
            this.SupFt_OrderPriceRate.Text = this.SupFt_OrderPriceRate.Text + "%";
            this.SupFt_AnnualRetGoodsPriceRate.Text = this.SupFt_AnnualRetGoodsPriceRate.Text + "%";
            this.SupFt_AnnualConstUnitRate.Text = this.SupFt_AnnualConstUnitRate.Text + "%";
            this.SupFt_AnnualStockPriceRate.Text = this.SupFt_AnnualStockPriceRate.Text + "%";
            this.SupFt_AnnualOrderPriceRate.Text = this.SupFt_AnnualOrderPriceRate.Text + "%";
        }

        /// <summary>
        /// SectionFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { SecFt_TotalPrice, SecFt_RetGoodsPrice, SecFt_TotalDiscount, SecFt_PureTotalPrice, SecFt_StockPrice, SecFt_OrderPrice,
                                           SecFt_AnnualTotalPrice, SecFt_AnnualRetGoodsPrice, SecFt_AnnualTotalDiscount, SecFt_AnnualPureTotalPrice, SecFt_AnnualStockPrice, SecFt_AnnualOrderPrice });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.MonthAndTerm)
            {
                // 返品率(当月)
                this.SecFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_RetGoodsPriceOrg.Value), Convert.ToInt64(this.SecFt_TotalPriceOrg.Value));
                // 構成比(当月)
                this.SecFt_ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_PureTotalPriceOrg.Value), Convert.ToInt64(this.SecFt_PureTotalPriceSum.Value));
                // 在庫比(当月)
                this.SecFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_StockPriceOrg.Value), Convert.ToInt64(this.SecFt_PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.SecFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_OrderPriceOrg.Value), Convert.ToInt64(this.SecFt_PureTotalPriceOrg.Value));

                // 返品率(当期)
                this.SecFt_AnnualRetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualTotalPriceOrg.Value));
                // 構成比(当期)
                this.SecFt_AnnualConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualPureTotalPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualPureTotalPriceSum.Value));
                // 在庫比(当期)
                this.SecFt_AnnualStockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualStockPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.SecFt_AnnualOrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualOrderPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualPureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Month)
            {
                // 返品率(当月)
                this.SecFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_RetGoodsPriceOrg.Value), Convert.ToInt64(this.SecFt_TotalPriceOrg.Value));
                // 構成比(当月)
                this.SecFt_ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_PureTotalPriceOrg.Value), Convert.ToInt64(this.SecFt_PureTotalPriceSum.Value));
                // 在庫比(当月)
                this.SecFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_StockPriceOrg.Value), Convert.ToInt64(this.SecFt_PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.SecFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_OrderPriceOrg.Value), Convert.ToInt64(this.SecFt_PureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Term)
            {
                // 返品率(当期)
                this.SecFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualTotalPriceOrg.Value));
                // 構成比(当期)
                this.SecFt_ConstUnitRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualPureTotalPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualPureTotalPriceSum.Value));
                // 在庫比(当期)
                this.SecFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualStockPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.SecFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.SecFt_AnnualOrderPriceOrg.Value), Convert.ToInt64(this.SecFt_AnnualPureTotalPriceOrg.Value));
            }

            // "%"の設定
            this.SecFt_RetGoodsPriceRate.Text = this.SecFt_RetGoodsPriceRate.Text + "%";
            this.SecFt_ConstUnitRate.Text = this.SecFt_ConstUnitRate.Text + "%";
            this.SecFt_StockPriceRate.Text = this.SecFt_StockPriceRate.Text + "%";
            this.SecFt_OrderPriceRate.Text = this.SecFt_OrderPriceRate.Text + "%";
            this.SecFt_AnnualRetGoodsPriceRate.Text = this.SecFt_AnnualRetGoodsPriceRate.Text + "%";
            this.SecFt_AnnualConstUnitRate.Text = this.SecFt_AnnualConstUnitRate.Text + "%";
            this.SecFt_AnnualStockPriceRate.Text = this.SecFt_AnnualStockPriceRate.Text + "%";
            this.SecFt_AnnualOrderPriceRate.Text = this.SecFt_AnnualOrderPriceRate.Text + "%";
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { GraFt_TotalPrice, GraFt_RetGoodsPrice, GraFt_TotalDiscount, GraFt_PureTotalPrice, GraFt_StockPrice, GraFt_OrderPrice,
                                           GraFt_AnnualTotalPrice, GraFt_AnnualRetGoodsPrice, GraFt_AnnualTotalDiscount, GraFt_AnnualPureTotalPrice, GraFt_AnnualStockPrice, GraFt_AnnualOrderPrice });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.MonthAndTerm)
            {
                // 返品率(当月)
                this.GraFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_RetGoodsPriceOrg.Value), Convert.ToInt64(this.GraFt_TotalPriceOrg.Value));
                // 在庫比(当月)
                this.GraFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_StockPriceOrg.Value), Convert.ToInt64(this.GraFt_PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.GraFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_OrderPriceOrg.Value), Convert.ToInt64(this.GraFt_PureTotalPriceOrg.Value));

                // 返品率(当期)
                this.GraFt_AnnualRetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.GraFt_AnnualTotalPriceOrg.Value));
                // 在庫比(当期)
                this.GraFt_AnnualStockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_AnnualStockPriceOrg.Value), Convert.ToInt64(this.GraFt_AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.GraFt_AnnualOrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_AnnualOrderPriceOrg.Value), Convert.ToInt64(this.GraFt_AnnualPureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Month)
            {
                // 返品率(当月)
                this.GraFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_RetGoodsPriceOrg.Value), Convert.ToInt64(this.GraFt_TotalPriceOrg.Value));
                // 在庫比(当月)
                this.GraFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_StockPriceOrg.Value), Convert.ToInt64(this.GraFt_PureTotalPriceOrg.Value));
                // 取寄比(当月)
                this.GraFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_OrderPriceOrg.Value), Convert.ToInt64(this.GraFt_PureTotalPriceOrg.Value));
            }
            else if (this._slipHistAnalyzeParam.PrintTermType == SlipHistAnalyzeParam.PrintTermTypeState.Term)
            {
                // 返品率(当期)
                this.GraFt_RetGoodsPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_AnnualRetGoodsPriceOrg.Value), Convert.ToInt64(this.GraFt_AnnualTotalPriceOrg.Value));
                // 在庫比(当期)
                this.GraFt_StockPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_AnnualStockPriceOrg.Value), Convert.ToInt64(this.GraFt_AnnualPureTotalPriceOrg.Value));
                // 取寄比(当期)
                this.GraFt_OrderPriceRate.Value = this.GetRatio(Convert.ToInt64(this.GraFt_AnnualOrderPriceOrg.Value), Convert.ToInt64(this.GraFt_AnnualPureTotalPriceOrg.Value));
            }

            // "%"の設定
            this.GraFt_RetGoodsPriceRate.Text = this.GraFt_RetGoodsPriceRate.Text + "%";
            this.GraFt_ConstUnitRate.Text = this.GraFt_ConstUnitRate.Text + "%";
            this.GraFt_StockPriceRate.Text = this.GraFt_StockPriceRate.Text + "%";
            this.GraFt_OrderPriceRate.Text = this.GraFt_OrderPriceRate.Text + "%";
            this.GraFt_AnnualRetGoodsPriceRate.Text = this.GraFt_AnnualRetGoodsPriceRate.Text + "%";
            this.GraFt_AnnualConstUnitRate.Text = this.GraFt_AnnualConstUnitRate.Text + "%";
            this.GraFt_AnnualStockPriceRate.Text = this.GraFt_AnnualStockPriceRate.Text + "%";
            this.GraFt_AnnualOrderPriceRate.Text = this.GraFt_AnnualOrderPriceRate.Text + "%";
        }

        /// <summary>
        /// ページフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.03.17</br>
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
        #endregion

        // ADD 2009/04/13 ------>>>
        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._slipHistAnalyzeParam.MoneyUnitDiv == SlipHistAnalyzeParam.MoneyUnitDivState.Thousand)
            {
                int priceUnit = 1000;

                for (int index = 0; index < calcList.Count; index++)
                {
                    if (!calcList[index].Visible)
                    {
                        continue;
                    }

                    decimal unitCalc = 0;
                    if (calcList[index].Value is long)
                    {
                        unitCalc = (decimal)((long)calcList[index].Value / (decimal)priceUnit);
                    }
                    else if (calcList[index].Value is double)
                    {
                        unitCalc = (decimal)((double)calcList[index].Value / (double)priceUnit);
                    }
                    else
                    {
                        continue;
                    }
                    calcList[index].Value = unitCalc;
                }
            }
        }
        // ADD 2009/04/13 ------<<<

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMKOU02023P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.CodeName = new DataDynamics.ActiveReports.TextBox();
            this.Code = new DataDynamics.ActiveReports.TextBox();
            this.TotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.TotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.PureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.ConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.OrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.ySeparator = new DataDynamics.ActiveReports.TextBox();
            this.OrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.AnnualTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnnualRetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnnualRetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.AnnualTotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.AnnualPureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnnualConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.AnnualStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnnualOrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnnualStockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.dSeparator = new DataDynamics.ActiveReports.TextBox();
            this.AnnualOrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.TotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.AnnualTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.AnnualRetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.TotalDiscountOrg = new DataDynamics.ActiveReports.TextBox();
            this.PureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.AnnualTotalDiscountOrg = new DataDynamics.ActiveReports.TextBox();
            this.AnnualPureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.OrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.AnnualStockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.AnnualOrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.PureTotalPriceSum = new DataDynamics.ActiveReports.TextBox();
            this.AnnualPureTotalPriceSum = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_line = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SecFt_TotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_RetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_RetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_PureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_ConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_OrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_StockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_ySeparator = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_OrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualRetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualRetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualTotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualPureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualOrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualStockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_dSeparator = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualOrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SecFt_TotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_RetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualRetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalDiscountOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_PureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualTotalDiscountOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualPureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_StockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_OrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualStockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualOrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_PureTotalPriceSum = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualPureTotalPriceSum = new DataDynamics.ActiveReports.TextBox();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupHd_SuplierCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SuplierName = new DataDynamics.ActiveReports.TextBox();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SupFt_TotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_RetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_RetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_PureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_ConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_OrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_StockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_ySeparator = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_OrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualRetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualRetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualTotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualPureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualOrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualStockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_dSeparator = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualOrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SupFt_TotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_RetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualRetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalDiscountOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_PureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualTotalDiscountOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualPureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_StockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_OrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualStockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualOrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_PureTotalPriceSum = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualPureTotalPriceSum = new DataDynamics.ActiveReports.TextBox();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_Title1 = new DataDynamics.ActiveReports.Label();
            this.Lb_Title2 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GraFt_TotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_RetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_RetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_TotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_PureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_ConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_OrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_StockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_ySeparator = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_OrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualRetGoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualRetGoodsPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualTotalDiscount = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualPureTotalPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualConstUnitRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualOrderPrice = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualStockPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_dSeparator = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualOrderPriceRate = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.GraFt_TotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_RetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualRetGoodsPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_StockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_OrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualStockPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualOrderPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_PureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_AnnualPureTotalPriceOrg = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualRetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualRetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualPureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualOrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualStockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualOrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualRetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDiscountOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalDiscountOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualPureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualStockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualOrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureTotalPriceSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualPureTotalPriceSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_RetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_RetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_ConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_OrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_StockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_ySeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_OrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualRetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualRetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualOrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualStockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_dSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualOrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_RetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualRetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalDiscountOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalDiscountOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_StockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_OrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualStockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualOrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureTotalPriceSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureTotalPriceSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SuplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SuplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_RetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_RetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_ConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_ySeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualRetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualRetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualOrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualStockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_dSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualOrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_RetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualRetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalDiscountOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalDiscountOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualStockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualOrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureTotalPriceSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureTotalPriceSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_TotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_RetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_RetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_TotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_PureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_ConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_OrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_StockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_ySeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_OrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualRetGoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualRetGoodsPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualTotalDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualPureTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualConstUnitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualOrderPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualStockPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_dSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualOrderPriceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_TotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_RetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualRetGoodsPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_StockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_OrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualStockPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualOrderPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_PureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualPureTotalPriceOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line1,
            this.tb_ReportTitle,
            this.Label3,
            this.tb_PrintDate,
            this.tb_PrintTime,
            this.Label2,
            this.tb_PrintPage});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.tb_ReportTitle.Text = "仕入分析表（拠点別）";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
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
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
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
            this.CodeName,
            this.Code,
            this.TotalPrice,
            this.RetGoodsPrice,
            this.RetGoodsPriceRate,
            this.TotalDiscount,
            this.PureTotalPrice,
            this.ConstUnitRate,
            this.StockPrice,
            this.OrderPrice,
            this.StockPriceRate,
            this.ySeparator,
            this.OrderPriceRate,
            this.AnnualTotalPrice,
            this.AnnualRetGoodsPrice,
            this.AnnualRetGoodsPriceRate,
            this.AnnualTotalDiscount,
            this.AnnualPureTotalPrice,
            this.AnnualConstUnitRate,
            this.AnnualStockPrice,
            this.AnnualOrderPrice,
            this.AnnualStockPriceRate,
            this.dSeparator,
            this.AnnualOrderPriceRate,
            this.TotalPriceOrg,
            this.RetGoodsPriceOrg,
            this.AnnualTotalPriceOrg,
            this.AnnualRetGoodsPriceOrg,
            this.TotalDiscountOrg,
            this.PureTotalPriceOrg,
            this.AnnualTotalDiscountOrg,
            this.AnnualPureTotalPriceOrg,
            this.StockPriceOrg,
            this.OrderPriceOrg,
            this.AnnualStockPriceOrg,
            this.AnnualOrderPriceOrg,
            this.PureTotalPriceSum,
            this.AnnualPureTotalPriceSum,
            this.line2});
            this.detail.Height = 1.34375F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.AfterPrint += new System.EventHandler(this.detail_AfterPrint);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
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
            this.CodeName.Left = 0.8125F;
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
            this.Code.Text = "123456";
            this.Code.Top = 0.063F;
            this.Code.Width = 0.4F;
            // 
            // TotalPrice
            // 
            this.TotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.TotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.TotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPrice.DataField = "TotalPrice";
            this.TotalPrice.Height = 0.156F;
            this.TotalPrice.Left = 2.5875F;
            this.TotalPrice.MultiLine = false;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.OutputFormat = resources.GetString("TotalPrice.OutputFormat");
            this.TotalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalPrice.Text = "1,234,567,890";
            this.TotalPrice.Top = 0.0625F;
            this.TotalPrice.Width = 0.8F;
            // 
            // RetGoodsPrice
            // 
            this.RetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPrice.DataField = "RetGoodsPrice";
            this.RetGoodsPrice.Height = 0.156F;
            this.RetGoodsPrice.Left = 3.5125F;
            this.RetGoodsPrice.MultiLine = false;
            this.RetGoodsPrice.Name = "RetGoodsPrice";
            this.RetGoodsPrice.OutputFormat = resources.GetString("RetGoodsPrice.OutputFormat");
            this.RetGoodsPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGoodsPrice.Text = "1,234,567,890";
            this.RetGoodsPrice.Top = 0.0625F;
            this.RetGoodsPrice.Width = 0.8F;
            // 
            // RetGoodsPriceRate
            // 
            this.RetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceRate.Height = 0.156F;
            this.RetGoodsPriceRate.Left = 4.4375F;
            this.RetGoodsPriceRate.MultiLine = false;
            this.RetGoodsPriceRate.Name = "RetGoodsPriceRate";
            this.RetGoodsPriceRate.OutputFormat = resources.GetString("RetGoodsPriceRate.OutputFormat");
            this.RetGoodsPriceRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.RetGoodsPriceRate.Text = "100.00%";
            this.RetGoodsPriceRate.Top = 0.0625F;
            this.RetGoodsPriceRate.Width = 0.42F;
            // 
            // TotalDiscount
            // 
            this.TotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.TotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.TotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscount.DataField = "TotalDiscount";
            this.TotalDiscount.Height = 0.156F;
            this.TotalDiscount.Left = 5.0625F;
            this.TotalDiscount.MultiLine = false;
            this.TotalDiscount.Name = "TotalDiscount";
            this.TotalDiscount.OutputFormat = resources.GetString("TotalDiscount.OutputFormat");
            this.TotalDiscount.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalDiscount.Text = "1,234,567,890";
            this.TotalDiscount.Top = 0.0625F;
            this.TotalDiscount.Width = 0.8F;
            // 
            // PureTotalPrice
            // 
            this.PureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.PureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.PureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.PureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.PureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPrice.DataField = "PureTotalPrice";
            this.PureTotalPrice.Height = 0.156F;
            this.PureTotalPrice.Left = 6F;
            this.PureTotalPrice.MultiLine = false;
            this.PureTotalPrice.Name = "PureTotalPrice";
            this.PureTotalPrice.OutputFormat = resources.GetString("PureTotalPrice.OutputFormat");
            this.PureTotalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.PureTotalPrice.Text = "1,234,567,890";
            this.PureTotalPrice.Top = 0.0625F;
            this.PureTotalPrice.Width = 0.8F;
            // 
            // ConstUnitRate
            // 
            this.ConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.ConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.ConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.ConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.ConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConstUnitRate.Height = 0.156F;
            this.ConstUnitRate.Left = 6.9375F;
            this.ConstUnitRate.MultiLine = false;
            this.ConstUnitRate.Name = "ConstUnitRate";
            this.ConstUnitRate.OutputFormat = resources.GetString("ConstUnitRate.OutputFormat");
            this.ConstUnitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ConstUnitRate.Text = "100.00%";
            this.ConstUnitRate.Top = 0.0625F;
            this.ConstUnitRate.Width = 0.42F;
            // 
            // StockPrice
            // 
            this.StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.DataField = "StockPrice";
            this.StockPrice.Height = 0.156F;
            this.StockPrice.Left = 7.5625F;
            this.StockPrice.MultiLine = false;
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.OutputFormat = resources.GetString("StockPrice.OutputFormat");
            this.StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockPrice.Text = "1,234,567,890";
            this.StockPrice.Top = 0.0625F;
            this.StockPrice.Width = 0.8F;
            // 
            // OrderPrice
            // 
            this.OrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.OrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.OrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPrice.DataField = "OrderPrice";
            this.OrderPrice.Height = 0.156F;
            this.OrderPrice.Left = 8.4375F;
            this.OrderPrice.MultiLine = false;
            this.OrderPrice.Name = "OrderPrice";
            this.OrderPrice.OutputFormat = resources.GetString("OrderPrice.OutputFormat");
            this.OrderPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.OrderPrice.Text = "1,234,567,890";
            this.OrderPrice.Top = 0.0625F;
            this.OrderPrice.Width = 0.8F;
            // 
            // StockPriceRate
            // 
            this.StockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceRate.DataField = "StockPriceRate";
            this.StockPriceRate.Height = 0.156F;
            this.StockPriceRate.Left = 9.355F;
            this.StockPriceRate.MultiLine = false;
            this.StockPriceRate.Name = "StockPriceRate";
            this.StockPriceRate.OutputFormat = resources.GetString("StockPriceRate.OutputFormat");
            this.StockPriceRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockPriceRate.Text = "100.00%";
            this.StockPriceRate.Top = 0.0625F;
            this.StockPriceRate.Width = 0.42F;
            // 
            // ySeparator
            // 
            this.ySeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.ySeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ySeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.ySeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ySeparator.Border.RightColor = System.Drawing.Color.Black;
            this.ySeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ySeparator.Border.TopColor = System.Drawing.Color.Black;
            this.ySeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ySeparator.Height = 0.156F;
            this.ySeparator.Left = 9.9F;
            this.ySeparator.MultiLine = false;
            this.ySeparator.Name = "ySeparator";
            this.ySeparator.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.ySeparator.Text = "/";
            this.ySeparator.Top = 0.0625F;
            this.ySeparator.Width = 0.1F;
            // 
            // OrderPriceRate
            // 
            this.OrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.OrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.OrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceRate.DataField = "OrderPriceRate";
            this.OrderPriceRate.Height = 0.156F;
            this.OrderPriceRate.Left = 10.125F;
            this.OrderPriceRate.MultiLine = false;
            this.OrderPriceRate.Name = "OrderPriceRate";
            this.OrderPriceRate.OutputFormat = resources.GetString("OrderPriceRate.OutputFormat");
            this.OrderPriceRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OrderPriceRate.Text = "100.00%";
            this.OrderPriceRate.Top = 0.0625F;
            this.OrderPriceRate.Width = 0.42F;
            // 
            // AnnualTotalPrice
            // 
            this.AnnualTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPrice.DataField = "AnnualTotalPrice";
            this.AnnualTotalPrice.Height = 0.156F;
            this.AnnualTotalPrice.Left = 2.5875F;
            this.AnnualTotalPrice.MultiLine = false;
            this.AnnualTotalPrice.Name = "AnnualTotalPrice";
            this.AnnualTotalPrice.OutputFormat = resources.GetString("AnnualTotalPrice.OutputFormat");
            this.AnnualTotalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualTotalPrice.Text = "1,234,567,890";
            this.AnnualTotalPrice.Top = 0.25F;
            this.AnnualTotalPrice.Width = 0.8F;
            // 
            // AnnualRetGoodsPrice
            // 
            this.AnnualRetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPrice.DataField = "AnnualRetGoodsPrice";
            this.AnnualRetGoodsPrice.Height = 0.156F;
            this.AnnualRetGoodsPrice.Left = 3.5125F;
            this.AnnualRetGoodsPrice.MultiLine = false;
            this.AnnualRetGoodsPrice.Name = "AnnualRetGoodsPrice";
            this.AnnualRetGoodsPrice.OutputFormat = resources.GetString("AnnualRetGoodsPrice.OutputFormat");
            this.AnnualRetGoodsPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualRetGoodsPrice.Text = "1,234,567,890";
            this.AnnualRetGoodsPrice.Top = 0.25F;
            this.AnnualRetGoodsPrice.Width = 0.8F;
            // 
            // AnnualRetGoodsPriceRate
            // 
            this.AnnualRetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceRate.Height = 0.156F;
            this.AnnualRetGoodsPriceRate.Left = 4.4375F;
            this.AnnualRetGoodsPriceRate.MultiLine = false;
            this.AnnualRetGoodsPriceRate.Name = "AnnualRetGoodsPriceRate";
            this.AnnualRetGoodsPriceRate.OutputFormat = resources.GetString("AnnualRetGoodsPriceRate.OutputFormat");
            this.AnnualRetGoodsPriceRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualRetGoodsPriceRate.Text = "100.00%";
            this.AnnualRetGoodsPriceRate.Top = 0.25F;
            this.AnnualRetGoodsPriceRate.Width = 0.42F;
            // 
            // AnnualTotalDiscount
            // 
            this.AnnualTotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscount.DataField = "AnnualTotalDiscount";
            this.AnnualTotalDiscount.Height = 0.156F;
            this.AnnualTotalDiscount.Left = 5.0625F;
            this.AnnualTotalDiscount.MultiLine = false;
            this.AnnualTotalDiscount.Name = "AnnualTotalDiscount";
            this.AnnualTotalDiscount.OutputFormat = resources.GetString("AnnualTotalDiscount.OutputFormat");
            this.AnnualTotalDiscount.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualTotalDiscount.Text = "1,234,567,890";
            this.AnnualTotalDiscount.Top = 0.25F;
            this.AnnualTotalDiscount.Width = 0.8F;
            // 
            // AnnualPureTotalPrice
            // 
            this.AnnualPureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPrice.DataField = "AnnualPureTotalPrice";
            this.AnnualPureTotalPrice.Height = 0.156F;
            this.AnnualPureTotalPrice.Left = 6F;
            this.AnnualPureTotalPrice.MultiLine = false;
            this.AnnualPureTotalPrice.Name = "AnnualPureTotalPrice";
            this.AnnualPureTotalPrice.OutputFormat = resources.GetString("AnnualPureTotalPrice.OutputFormat");
            this.AnnualPureTotalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualPureTotalPrice.Text = "1,234,567,890";
            this.AnnualPureTotalPrice.Top = 0.25F;
            this.AnnualPureTotalPrice.Width = 0.8F;
            // 
            // AnnualConstUnitRate
            // 
            this.AnnualConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualConstUnitRate.Height = 0.156F;
            this.AnnualConstUnitRate.Left = 6.9375F;
            this.AnnualConstUnitRate.MultiLine = false;
            this.AnnualConstUnitRate.Name = "AnnualConstUnitRate";
            this.AnnualConstUnitRate.OutputFormat = resources.GetString("AnnualConstUnitRate.OutputFormat");
            this.AnnualConstUnitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualConstUnitRate.Text = "100.00%";
            this.AnnualConstUnitRate.Top = 0.25F;
            this.AnnualConstUnitRate.Width = 0.42F;
            // 
            // AnnualStockPrice
            // 
            this.AnnualStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPrice.DataField = "AnnualStockPrice";
            this.AnnualStockPrice.Height = 0.156F;
            this.AnnualStockPrice.Left = 7.5625F;
            this.AnnualStockPrice.MultiLine = false;
            this.AnnualStockPrice.Name = "AnnualStockPrice";
            this.AnnualStockPrice.OutputFormat = resources.GetString("AnnualStockPrice.OutputFormat");
            this.AnnualStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualStockPrice.Text = "1,234,567,890";
            this.AnnualStockPrice.Top = 0.25F;
            this.AnnualStockPrice.Width = 0.8F;
            // 
            // AnnualOrderPrice
            // 
            this.AnnualOrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualOrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualOrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualOrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualOrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPrice.DataField = "AnnualOrderPrice";
            this.AnnualOrderPrice.Height = 0.156F;
            this.AnnualOrderPrice.Left = 8.4375F;
            this.AnnualOrderPrice.MultiLine = false;
            this.AnnualOrderPrice.Name = "AnnualOrderPrice";
            this.AnnualOrderPrice.OutputFormat = resources.GetString("AnnualOrderPrice.OutputFormat");
            this.AnnualOrderPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualOrderPrice.Text = "1,234,567,890";
            this.AnnualOrderPrice.Top = 0.25F;
            this.AnnualOrderPrice.Width = 0.8F;
            // 
            // AnnualStockPriceRate
            // 
            this.AnnualStockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualStockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualStockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualStockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualStockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceRate.DataField = "AnnualStockPriceRate";
            this.AnnualStockPriceRate.Height = 0.156F;
            this.AnnualStockPriceRate.Left = 9.355F;
            this.AnnualStockPriceRate.MultiLine = false;
            this.AnnualStockPriceRate.Name = "AnnualStockPriceRate";
            this.AnnualStockPriceRate.OutputFormat = resources.GetString("AnnualStockPriceRate.OutputFormat");
            this.AnnualStockPriceRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualStockPriceRate.Text = "100.00%";
            this.AnnualStockPriceRate.Top = 0.25F;
            this.AnnualStockPriceRate.Width = 0.42F;
            // 
            // dSeparator
            // 
            this.dSeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.dSeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dSeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.dSeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dSeparator.Border.RightColor = System.Drawing.Color.Black;
            this.dSeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dSeparator.Border.TopColor = System.Drawing.Color.Black;
            this.dSeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dSeparator.Height = 0.156F;
            this.dSeparator.Left = 9.9F;
            this.dSeparator.MultiLine = false;
            this.dSeparator.Name = "dSeparator";
            this.dSeparator.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dSeparator.Text = "/";
            this.dSeparator.Top = 0.25F;
            this.dSeparator.Width = 0.1F;
            // 
            // AnnualOrderPriceRate
            // 
            this.AnnualOrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceRate.DataField = "AnnualOrderPriceRate";
            this.AnnualOrderPriceRate.Height = 0.156F;
            this.AnnualOrderPriceRate.Left = 10.125F;
            this.AnnualOrderPriceRate.MultiLine = false;
            this.AnnualOrderPriceRate.Name = "AnnualOrderPriceRate";
            this.AnnualOrderPriceRate.OutputFormat = resources.GetString("AnnualOrderPriceRate.OutputFormat");
            this.AnnualOrderPriceRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualOrderPriceRate.Text = "100.00%";
            this.AnnualOrderPriceRate.Top = 0.25F;
            this.AnnualOrderPriceRate.Width = 0.42F;
            // 
            // TotalPriceOrg
            // 
            this.TotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.TotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.TotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalPriceOrg.DataField = "TotalPriceOrg";
            this.TotalPriceOrg.Height = 0.156F;
            this.TotalPriceOrg.Left = 2.5875F;
            this.TotalPriceOrg.MultiLine = false;
            this.TotalPriceOrg.Name = "TotalPriceOrg";
            this.TotalPriceOrg.OutputFormat = resources.GetString("TotalPriceOrg.OutputFormat");
            this.TotalPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalPriceOrg.Text = "1,234,567,890";
            this.TotalPriceOrg.Top = 0.4685F;
            this.TotalPriceOrg.Visible = false;
            this.TotalPriceOrg.Width = 0.8F;
            // 
            // RetGoodsPriceOrg
            // 
            this.RetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsPriceOrg.DataField = "RetGoodsPriceOrg";
            this.RetGoodsPriceOrg.Height = 0.156F;
            this.RetGoodsPriceOrg.Left = 3.5125F;
            this.RetGoodsPriceOrg.MultiLine = false;
            this.RetGoodsPriceOrg.Name = "RetGoodsPriceOrg";
            this.RetGoodsPriceOrg.OutputFormat = resources.GetString("RetGoodsPriceOrg.OutputFormat");
            this.RetGoodsPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGoodsPriceOrg.Text = "1,234,567,890";
            this.RetGoodsPriceOrg.Top = 0.4685F;
            this.RetGoodsPriceOrg.Visible = false;
            this.RetGoodsPriceOrg.Width = 0.8F;
            // 
            // AnnualTotalPriceOrg
            // 
            this.AnnualTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalPriceOrg.DataField = "AnnualTotalPriceOrg";
            this.AnnualTotalPriceOrg.Height = 0.156F;
            this.AnnualTotalPriceOrg.Left = 2.5875F;
            this.AnnualTotalPriceOrg.MultiLine = false;
            this.AnnualTotalPriceOrg.Name = "AnnualTotalPriceOrg";
            this.AnnualTotalPriceOrg.OutputFormat = resources.GetString("AnnualTotalPriceOrg.OutputFormat");
            this.AnnualTotalPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualTotalPriceOrg.Text = "1,234,567,890";
            this.AnnualTotalPriceOrg.Top = 0.656F;
            this.AnnualTotalPriceOrg.Visible = false;
            this.AnnualTotalPriceOrg.Width = 0.8F;
            // 
            // AnnualRetGoodsPriceOrg
            // 
            this.AnnualRetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualRetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualRetGoodsPriceOrg.DataField = "AnnualRetGoodsPriceOrg";
            this.AnnualRetGoodsPriceOrg.Height = 0.156F;
            this.AnnualRetGoodsPriceOrg.Left = 3.5125F;
            this.AnnualRetGoodsPriceOrg.MultiLine = false;
            this.AnnualRetGoodsPriceOrg.Name = "AnnualRetGoodsPriceOrg";
            this.AnnualRetGoodsPriceOrg.OutputFormat = resources.GetString("AnnualRetGoodsPriceOrg.OutputFormat");
            this.AnnualRetGoodsPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualRetGoodsPriceOrg.Text = "1,234,567,890";
            this.AnnualRetGoodsPriceOrg.Top = 0.656F;
            this.AnnualRetGoodsPriceOrg.Visible = false;
            this.AnnualRetGoodsPriceOrg.Width = 0.8F;
            // 
            // TotalDiscountOrg
            // 
            this.TotalDiscountOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalDiscountOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscountOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalDiscountOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscountOrg.Border.RightColor = System.Drawing.Color.Black;
            this.TotalDiscountOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscountOrg.Border.TopColor = System.Drawing.Color.Black;
            this.TotalDiscountOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDiscountOrg.DataField = "TotalDiscountOrg";
            this.TotalDiscountOrg.Height = 0.156F;
            this.TotalDiscountOrg.Left = 5.0625F;
            this.TotalDiscountOrg.MultiLine = false;
            this.TotalDiscountOrg.Name = "TotalDiscountOrg";
            this.TotalDiscountOrg.OutputFormat = resources.GetString("TotalDiscountOrg.OutputFormat");
            this.TotalDiscountOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalDiscountOrg.Text = "1,234,567,890";
            this.TotalDiscountOrg.Top = 0.4685F;
            this.TotalDiscountOrg.Visible = false;
            this.TotalDiscountOrg.Width = 0.8F;
            // 
            // PureTotalPriceOrg
            // 
            this.PureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.PureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.PureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.PureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.PureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceOrg.DataField = "PureTotalPriceOrg";
            this.PureTotalPriceOrg.Height = 0.156F;
            this.PureTotalPriceOrg.Left = 6F;
            this.PureTotalPriceOrg.MultiLine = false;
            this.PureTotalPriceOrg.Name = "PureTotalPriceOrg";
            this.PureTotalPriceOrg.OutputFormat = resources.GetString("PureTotalPriceOrg.OutputFormat");
            this.PureTotalPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.PureTotalPriceOrg.Text = "1,234,567,890";
            this.PureTotalPriceOrg.Top = 0.4685F;
            this.PureTotalPriceOrg.Visible = false;
            this.PureTotalPriceOrg.Width = 0.8F;
            // 
            // AnnualTotalDiscountOrg
            // 
            this.AnnualTotalDiscountOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscountOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscountOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscountOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscountOrg.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscountOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscountOrg.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualTotalDiscountOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalDiscountOrg.DataField = "AnnualTotalDiscountOrg";
            this.AnnualTotalDiscountOrg.Height = 0.156F;
            this.AnnualTotalDiscountOrg.Left = 5.0625F;
            this.AnnualTotalDiscountOrg.MultiLine = false;
            this.AnnualTotalDiscountOrg.Name = "AnnualTotalDiscountOrg";
            this.AnnualTotalDiscountOrg.OutputFormat = resources.GetString("AnnualTotalDiscountOrg.OutputFormat");
            this.AnnualTotalDiscountOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualTotalDiscountOrg.Text = "1,234,567,890";
            this.AnnualTotalDiscountOrg.Top = 0.656F;
            this.AnnualTotalDiscountOrg.Visible = false;
            this.AnnualTotalDiscountOrg.Width = 0.8F;
            // 
            // AnnualPureTotalPriceOrg
            // 
            this.AnnualPureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceOrg.DataField = "AnnualPureTotalPriceOrg";
            this.AnnualPureTotalPriceOrg.Height = 0.156F;
            this.AnnualPureTotalPriceOrg.Left = 6F;
            this.AnnualPureTotalPriceOrg.MultiLine = false;
            this.AnnualPureTotalPriceOrg.Name = "AnnualPureTotalPriceOrg";
            this.AnnualPureTotalPriceOrg.OutputFormat = resources.GetString("AnnualPureTotalPriceOrg.OutputFormat");
            this.AnnualPureTotalPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualPureTotalPriceOrg.Text = "1,234,567,890";
            this.AnnualPureTotalPriceOrg.Top = 0.656F;
            this.AnnualPureTotalPriceOrg.Visible = false;
            this.AnnualPureTotalPriceOrg.Width = 0.8F;
            // 
            // StockPriceOrg
            // 
            this.StockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceOrg.DataField = "StockPriceOrg";
            this.StockPriceOrg.Height = 0.156F;
            this.StockPriceOrg.Left = 7.5625F;
            this.StockPriceOrg.MultiLine = false;
            this.StockPriceOrg.Name = "StockPriceOrg";
            this.StockPriceOrg.OutputFormat = resources.GetString("StockPriceOrg.OutputFormat");
            this.StockPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockPriceOrg.Text = "1,234,567,890";
            this.StockPriceOrg.Top = 0.4685F;
            this.StockPriceOrg.Visible = false;
            this.StockPriceOrg.Width = 0.8F;
            // 
            // OrderPriceOrg
            // 
            this.OrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.OrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.OrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderPriceOrg.DataField = "OrderPriceOrg";
            this.OrderPriceOrg.Height = 0.156F;
            this.OrderPriceOrg.Left = 8.4375F;
            this.OrderPriceOrg.MultiLine = false;
            this.OrderPriceOrg.Name = "OrderPriceOrg";
            this.OrderPriceOrg.OutputFormat = resources.GetString("OrderPriceOrg.OutputFormat");
            this.OrderPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.OrderPriceOrg.Text = "1,234,567,890";
            this.OrderPriceOrg.Top = 0.4685F;
            this.OrderPriceOrg.Visible = false;
            this.OrderPriceOrg.Width = 0.8F;
            // 
            // AnnualStockPriceOrg
            // 
            this.AnnualStockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualStockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualStockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualStockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualStockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualStockPriceOrg.DataField = "AnnualStockPriceOrg";
            this.AnnualStockPriceOrg.Height = 0.156F;
            this.AnnualStockPriceOrg.Left = 7.5625F;
            this.AnnualStockPriceOrg.MultiLine = false;
            this.AnnualStockPriceOrg.Name = "AnnualStockPriceOrg";
            this.AnnualStockPriceOrg.OutputFormat = resources.GetString("AnnualStockPriceOrg.OutputFormat");
            this.AnnualStockPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualStockPriceOrg.Text = "1,234,567,890";
            this.AnnualStockPriceOrg.Top = 0.656F;
            this.AnnualStockPriceOrg.Visible = false;
            this.AnnualStockPriceOrg.Width = 0.8F;
            // 
            // AnnualOrderPriceOrg
            // 
            this.AnnualOrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualOrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualOrderPriceOrg.DataField = "AnnualOrderPriceOrg";
            this.AnnualOrderPriceOrg.Height = 0.156F;
            this.AnnualOrderPriceOrg.Left = 8.4375F;
            this.AnnualOrderPriceOrg.MultiLine = false;
            this.AnnualOrderPriceOrg.Name = "AnnualOrderPriceOrg";
            this.AnnualOrderPriceOrg.OutputFormat = resources.GetString("AnnualOrderPriceOrg.OutputFormat");
            this.AnnualOrderPriceOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualOrderPriceOrg.Text = "1,234,567,890";
            this.AnnualOrderPriceOrg.Top = 0.656F;
            this.AnnualOrderPriceOrg.Visible = false;
            this.AnnualOrderPriceOrg.Width = 0.8F;
            // 
            // PureTotalPriceSum
            // 
            this.PureTotalPriceSum.Border.BottomColor = System.Drawing.Color.Black;
            this.PureTotalPriceSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceSum.Border.LeftColor = System.Drawing.Color.Black;
            this.PureTotalPriceSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceSum.Border.RightColor = System.Drawing.Color.Black;
            this.PureTotalPriceSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceSum.Border.TopColor = System.Drawing.Color.Black;
            this.PureTotalPriceSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureTotalPriceSum.DataField = "PureTotalPriceSum";
            this.PureTotalPriceSum.Height = 0.156F;
            this.PureTotalPriceSum.Left = 6F;
            this.PureTotalPriceSum.MultiLine = false;
            this.PureTotalPriceSum.Name = "PureTotalPriceSum";
            this.PureTotalPriceSum.OutputFormat = resources.GetString("PureTotalPriceSum.OutputFormat");
            this.PureTotalPriceSum.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.PureTotalPriceSum.Text = "1,234,567,890";
            this.PureTotalPriceSum.Top = 0.875F;
            this.PureTotalPriceSum.Visible = false;
            this.PureTotalPriceSum.Width = 0.8F;
            // 
            // AnnualPureTotalPriceSum
            // 
            this.AnnualPureTotalPriceSum.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceSum.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceSum.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceSum.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualPureTotalPriceSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualPureTotalPriceSum.DataField = "AnnualPureTotalPriceSum";
            this.AnnualPureTotalPriceSum.Height = 0.156F;
            this.AnnualPureTotalPriceSum.Left = 6F;
            this.AnnualPureTotalPriceSum.MultiLine = false;
            this.AnnualPureTotalPriceSum.Name = "AnnualPureTotalPriceSum";
            this.AnnualPureTotalPriceSum.OutputFormat = resources.GetString("AnnualPureTotalPriceSum.OutputFormat");
            this.AnnualPureTotalPriceSum.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnnualPureTotalPriceSum.Text = "1,234,567,890";
            this.AnnualPureTotalPriceSum.Top = 1.0625F;
            this.AnnualPureTotalPriceSum.Visible = false;
            this.AnnualPureTotalPriceSum.Width = 0.8F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3020833F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_SectionCode,
            this.SecHd_SectionName,
            this.SecHd_line});
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.25F;
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
            this.SecHd_SectionCode.DataField = "AddUpSecCode";
            this.SecHd_SectionCode.Height = 0.16F;
            this.SecHd_SectionCode.Left = 0.063F;
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
            this.SecHd_SectionName.DataField = "SectionGuideSnm";
            this.SecHd_SectionName.Height = 0.16F;
            this.SecHd_SectionName.Left = 0.313F;
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
            this.SecHd_line.Top = 0F;
            this.SecHd_line.Width = 10.8F;
            this.SecHd_line.X1 = 0F;
            this.SecHd_line.X2 = 10.8F;
            this.SecHd_line.Y1 = 0F;
            this.SecHd_line.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecFt_TotalPrice,
            this.SecFt_RetGoodsPrice,
            this.SecFt_RetGoodsPriceRate,
            this.SecFt_TotalDiscount,
            this.SecFt_PureTotalPrice,
            this.SecFt_ConstUnitRate,
            this.SecFt_StockPrice,
            this.SecFt_OrderPrice,
            this.SecFt_StockPriceRate,
            this.SecFt_ySeparator,
            this.SecFt_OrderPriceRate,
            this.SecFt_AnnualTotalPrice,
            this.SecFt_AnnualRetGoodsPrice,
            this.SecFt_AnnualRetGoodsPriceRate,
            this.SecFt_AnnualTotalDiscount,
            this.SecFt_AnnualPureTotalPrice,
            this.SecFt_AnnualConstUnitRate,
            this.SecFt_AnnualStockPrice,
            this.SecFt_AnnualOrderPrice,
            this.SecFt_AnnualStockPriceRate,
            this.SecFt_dSeparator,
            this.SecFt_AnnualOrderPriceRate,
            this.label1,
            this.line3,
            this.SecFt_TotalPriceOrg,
            this.SecFt_RetGoodsPriceOrg,
            this.SecFt_AnnualTotalPriceOrg,
            this.SecFt_AnnualRetGoodsPriceOrg,
            this.SecFt_TotalDiscountOrg,
            this.SecFt_PureTotalPriceOrg,
            this.SecFt_AnnualTotalDiscountOrg,
            this.SecFt_AnnualPureTotalPriceOrg,
            this.SecFt_StockPriceOrg,
            this.SecFt_OrderPriceOrg,
            this.SecFt_AnnualStockPriceOrg,
            this.SecFt_AnnualOrderPriceOrg,
            this.SecFt_PureTotalPriceSum,
            this.SecFt_AnnualPureTotalPriceSum});
            this.SectionFooter.Height = 1.291667F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // SecFt_TotalPrice
            // 
            this.SecFt_TotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPrice.DataField = "TotalPrice";
            this.SecFt_TotalPrice.Height = 0.156F;
            this.SecFt_TotalPrice.Left = 2.5625F;
            this.SecFt_TotalPrice.MultiLine = false;
            this.SecFt_TotalPrice.Name = "SecFt_TotalPrice";
            this.SecFt_TotalPrice.OutputFormat = resources.GetString("SecFt_TotalPrice.OutputFormat");
            this.SecFt_TotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalPrice.SummaryGroup = "SectionHeader";
            this.SecFt_TotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalPrice.Text = "1,234,567,890";
            this.SecFt_TotalPrice.Top = 0.0625F;
            this.SecFt_TotalPrice.Width = 0.8F;
            // 
            // SecFt_RetGoodsPrice
            // 
            this.SecFt_RetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPrice.DataField = "RetGoodsPrice";
            this.SecFt_RetGoodsPrice.Height = 0.156F;
            this.SecFt_RetGoodsPrice.Left = 3.5F;
            this.SecFt_RetGoodsPrice.MultiLine = false;
            this.SecFt_RetGoodsPrice.Name = "SecFt_RetGoodsPrice";
            this.SecFt_RetGoodsPrice.OutputFormat = resources.GetString("SecFt_RetGoodsPrice.OutputFormat");
            this.SecFt_RetGoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_RetGoodsPrice.SummaryGroup = "SectionHeader";
            this.SecFt_RetGoodsPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_RetGoodsPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_RetGoodsPrice.Text = "1,234,567,890";
            this.SecFt_RetGoodsPrice.Top = 0.0625F;
            this.SecFt_RetGoodsPrice.Width = 0.8F;
            // 
            // SecFt_RetGoodsPriceRate
            // 
            this.SecFt_RetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceRate.Height = 0.156F;
            this.SecFt_RetGoodsPriceRate.Left = 4.4375F;
            this.SecFt_RetGoodsPriceRate.MultiLine = false;
            this.SecFt_RetGoodsPriceRate.Name = "SecFt_RetGoodsPriceRate";
            this.SecFt_RetGoodsPriceRate.OutputFormat = resources.GetString("SecFt_RetGoodsPriceRate.OutputFormat");
            this.SecFt_RetGoodsPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_RetGoodsPriceRate.Text = "100.00%";
            this.SecFt_RetGoodsPriceRate.Top = 0.063F;
            this.SecFt_RetGoodsPriceRate.Width = 0.42F;
            // 
            // SecFt_TotalDiscount
            // 
            this.SecFt_TotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscount.DataField = "TotalDiscount";
            this.SecFt_TotalDiscount.Height = 0.156F;
            this.SecFt_TotalDiscount.Left = 5.0625F;
            this.SecFt_TotalDiscount.MultiLine = false;
            this.SecFt_TotalDiscount.Name = "SecFt_TotalDiscount";
            this.SecFt_TotalDiscount.OutputFormat = resources.GetString("SecFt_TotalDiscount.OutputFormat");
            this.SecFt_TotalDiscount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalDiscount.SummaryGroup = "SectionHeader";
            this.SecFt_TotalDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalDiscount.Text = "1,234,567,890";
            this.SecFt_TotalDiscount.Top = 0.063F;
            this.SecFt_TotalDiscount.Width = 0.8F;
            // 
            // SecFt_PureTotalPrice
            // 
            this.SecFt_PureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPrice.DataField = "PureTotalPrice";
            this.SecFt_PureTotalPrice.Height = 0.156F;
            this.SecFt_PureTotalPrice.Left = 6F;
            this.SecFt_PureTotalPrice.MultiLine = false;
            this.SecFt_PureTotalPrice.Name = "SecFt_PureTotalPrice";
            this.SecFt_PureTotalPrice.OutputFormat = resources.GetString("SecFt_PureTotalPrice.OutputFormat");
            this.SecFt_PureTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_PureTotalPrice.SummaryGroup = "SectionHeader";
            this.SecFt_PureTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_PureTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_PureTotalPrice.Text = "1,234,567,890";
            this.SecFt_PureTotalPrice.Top = 0.063F;
            this.SecFt_PureTotalPrice.Width = 0.8F;
            // 
            // SecFt_ConstUnitRate
            // 
            this.SecFt_ConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_ConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_ConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_ConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_ConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ConstUnitRate.Height = 0.156F;
            this.SecFt_ConstUnitRate.Left = 6.9375F;
            this.SecFt_ConstUnitRate.MultiLine = false;
            this.SecFt_ConstUnitRate.Name = "SecFt_ConstUnitRate";
            this.SecFt_ConstUnitRate.OutputFormat = resources.GetString("SecFt_ConstUnitRate.OutputFormat");
            this.SecFt_ConstUnitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_ConstUnitRate.Text = "100.00%";
            this.SecFt_ConstUnitRate.Top = 0.063F;
            this.SecFt_ConstUnitRate.Width = 0.42F;
            // 
            // SecFt_StockPrice
            // 
            this.SecFt_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPrice.DataField = "StockPrice";
            this.SecFt_StockPrice.Height = 0.156F;
            this.SecFt_StockPrice.Left = 7.5625F;
            this.SecFt_StockPrice.MultiLine = false;
            this.SecFt_StockPrice.Name = "SecFt_StockPrice";
            this.SecFt_StockPrice.OutputFormat = resources.GetString("SecFt_StockPrice.OutputFormat");
            this.SecFt_StockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_StockPrice.SummaryGroup = "SectionHeader";
            this.SecFt_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_StockPrice.Text = "1,234,567,890";
            this.SecFt_StockPrice.Top = 0.063F;
            this.SecFt_StockPrice.Width = 0.8F;
            // 
            // SecFt_OrderPrice
            // 
            this.SecFt_OrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_OrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_OrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_OrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_OrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPrice.DataField = "OrderPrice";
            this.SecFt_OrderPrice.Height = 0.156F;
            this.SecFt_OrderPrice.Left = 8.4375F;
            this.SecFt_OrderPrice.MultiLine = false;
            this.SecFt_OrderPrice.Name = "SecFt_OrderPrice";
            this.SecFt_OrderPrice.OutputFormat = resources.GetString("SecFt_OrderPrice.OutputFormat");
            this.SecFt_OrderPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_OrderPrice.SummaryGroup = "SectionHeader";
            this.SecFt_OrderPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_OrderPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_OrderPrice.Text = "1,234,567,890";
            this.SecFt_OrderPrice.Top = 0.063F;
            this.SecFt_OrderPrice.Width = 0.8F;
            // 
            // SecFt_StockPriceRate
            // 
            this.SecFt_StockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceRate.Height = 0.156F;
            this.SecFt_StockPriceRate.Left = 9.355F;
            this.SecFt_StockPriceRate.MultiLine = false;
            this.SecFt_StockPriceRate.Name = "SecFt_StockPriceRate";
            this.SecFt_StockPriceRate.OutputFormat = resources.GetString("SecFt_StockPriceRate.OutputFormat");
            this.SecFt_StockPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_StockPriceRate.Text = "100.00%";
            this.SecFt_StockPriceRate.Top = 0.063F;
            this.SecFt_StockPriceRate.Width = 0.42F;
            // 
            // SecFt_ySeparator
            // 
            this.SecFt_ySeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_ySeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ySeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_ySeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ySeparator.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_ySeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ySeparator.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_ySeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_ySeparator.Height = 0.156F;
            this.SecFt_ySeparator.Left = 9.9F;
            this.SecFt_ySeparator.MultiLine = false;
            this.SecFt_ySeparator.Name = "SecFt_ySeparator";
            this.SecFt_ySeparator.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_ySeparator.Text = "/";
            this.SecFt_ySeparator.Top = 0.063F;
            this.SecFt_ySeparator.Width = 0.1F;
            // 
            // SecFt_OrderPriceRate
            // 
            this.SecFt_OrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceRate.Height = 0.156F;
            this.SecFt_OrderPriceRate.Left = 10.125F;
            this.SecFt_OrderPriceRate.MultiLine = false;
            this.SecFt_OrderPriceRate.Name = "SecFt_OrderPriceRate";
            this.SecFt_OrderPriceRate.OutputFormat = resources.GetString("SecFt_OrderPriceRate.OutputFormat");
            this.SecFt_OrderPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_OrderPriceRate.Text = "100.00%";
            this.SecFt_OrderPriceRate.Top = 0.063F;
            this.SecFt_OrderPriceRate.Width = 0.42F;
            // 
            // SecFt_AnnualTotalPrice
            // 
            this.SecFt_AnnualTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPrice.DataField = "AnnualTotalPrice";
            this.SecFt_AnnualTotalPrice.Height = 0.156F;
            this.SecFt_AnnualTotalPrice.Left = 2.5625F;
            this.SecFt_AnnualTotalPrice.MultiLine = false;
            this.SecFt_AnnualTotalPrice.Name = "SecFt_AnnualTotalPrice";
            this.SecFt_AnnualTotalPrice.OutputFormat = resources.GetString("SecFt_AnnualTotalPrice.OutputFormat");
            this.SecFt_AnnualTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualTotalPrice.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualTotalPrice.Text = "1,234,567,890";
            this.SecFt_AnnualTotalPrice.Top = 0.25F;
            this.SecFt_AnnualTotalPrice.Width = 0.8F;
            // 
            // SecFt_AnnualRetGoodsPrice
            // 
            this.SecFt_AnnualRetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPrice.DataField = "AnnualRetGoodsPrice";
            this.SecFt_AnnualRetGoodsPrice.Height = 0.156F;
            this.SecFt_AnnualRetGoodsPrice.Left = 3.5F;
            this.SecFt_AnnualRetGoodsPrice.MultiLine = false;
            this.SecFt_AnnualRetGoodsPrice.Name = "SecFt_AnnualRetGoodsPrice";
            this.SecFt_AnnualRetGoodsPrice.OutputFormat = resources.GetString("SecFt_AnnualRetGoodsPrice.OutputFormat");
            this.SecFt_AnnualRetGoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualRetGoodsPrice.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualRetGoodsPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualRetGoodsPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualRetGoodsPrice.Text = "1,234,567,890";
            this.SecFt_AnnualRetGoodsPrice.Top = 0.25F;
            this.SecFt_AnnualRetGoodsPrice.Width = 0.8F;
            // 
            // SecFt_AnnualRetGoodsPriceRate
            // 
            this.SecFt_AnnualRetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceRate.Height = 0.156F;
            this.SecFt_AnnualRetGoodsPriceRate.Left = 4.4375F;
            this.SecFt_AnnualRetGoodsPriceRate.MultiLine = false;
            this.SecFt_AnnualRetGoodsPriceRate.Name = "SecFt_AnnualRetGoodsPriceRate";
            this.SecFt_AnnualRetGoodsPriceRate.OutputFormat = resources.GetString("SecFt_AnnualRetGoodsPriceRate.OutputFormat");
            this.SecFt_AnnualRetGoodsPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualRetGoodsPriceRate.Text = "100.00%";
            this.SecFt_AnnualRetGoodsPriceRate.Top = 0.25F;
            this.SecFt_AnnualRetGoodsPriceRate.Width = 0.42F;
            // 
            // SecFt_AnnualTotalDiscount
            // 
            this.SecFt_AnnualTotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscount.DataField = "AnnualTotalDiscount";
            this.SecFt_AnnualTotalDiscount.Height = 0.156F;
            this.SecFt_AnnualTotalDiscount.Left = 5.0625F;
            this.SecFt_AnnualTotalDiscount.MultiLine = false;
            this.SecFt_AnnualTotalDiscount.Name = "SecFt_AnnualTotalDiscount";
            this.SecFt_AnnualTotalDiscount.OutputFormat = resources.GetString("SecFt_AnnualTotalDiscount.OutputFormat");
            this.SecFt_AnnualTotalDiscount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualTotalDiscount.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualTotalDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualTotalDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualTotalDiscount.Text = "1,234,567,890";
            this.SecFt_AnnualTotalDiscount.Top = 0.25F;
            this.SecFt_AnnualTotalDiscount.Width = 0.8F;
            // 
            // SecFt_AnnualPureTotalPrice
            // 
            this.SecFt_AnnualPureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPrice.DataField = "AnnualPureTotalPrice";
            this.SecFt_AnnualPureTotalPrice.Height = 0.156F;
            this.SecFt_AnnualPureTotalPrice.Left = 6F;
            this.SecFt_AnnualPureTotalPrice.MultiLine = false;
            this.SecFt_AnnualPureTotalPrice.Name = "SecFt_AnnualPureTotalPrice";
            this.SecFt_AnnualPureTotalPrice.OutputFormat = resources.GetString("SecFt_AnnualPureTotalPrice.OutputFormat");
            this.SecFt_AnnualPureTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualPureTotalPrice.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualPureTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualPureTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualPureTotalPrice.Text = "1,234,567,890";
            this.SecFt_AnnualPureTotalPrice.Top = 0.25F;
            this.SecFt_AnnualPureTotalPrice.Width = 0.8F;
            // 
            // SecFt_AnnualConstUnitRate
            // 
            this.SecFt_AnnualConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualConstUnitRate.Height = 0.156F;
            this.SecFt_AnnualConstUnitRate.Left = 6.9375F;
            this.SecFt_AnnualConstUnitRate.MultiLine = false;
            this.SecFt_AnnualConstUnitRate.Name = "SecFt_AnnualConstUnitRate";
            this.SecFt_AnnualConstUnitRate.OutputFormat = resources.GetString("SecFt_AnnualConstUnitRate.OutputFormat");
            this.SecFt_AnnualConstUnitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualConstUnitRate.Text = "100.00%";
            this.SecFt_AnnualConstUnitRate.Top = 0.25F;
            this.SecFt_AnnualConstUnitRate.Width = 0.42F;
            // 
            // SecFt_AnnualStockPrice
            // 
            this.SecFt_AnnualStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPrice.DataField = "AnnualStockPrice";
            this.SecFt_AnnualStockPrice.Height = 0.156F;
            this.SecFt_AnnualStockPrice.Left = 7.5625F;
            this.SecFt_AnnualStockPrice.MultiLine = false;
            this.SecFt_AnnualStockPrice.Name = "SecFt_AnnualStockPrice";
            this.SecFt_AnnualStockPrice.OutputFormat = resources.GetString("SecFt_AnnualStockPrice.OutputFormat");
            this.SecFt_AnnualStockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualStockPrice.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualStockPrice.Text = "1,234,567,890";
            this.SecFt_AnnualStockPrice.Top = 0.25F;
            this.SecFt_AnnualStockPrice.Width = 0.8F;
            // 
            // SecFt_AnnualOrderPrice
            // 
            this.SecFt_AnnualOrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPrice.DataField = "AnnualOrderPrice";
            this.SecFt_AnnualOrderPrice.Height = 0.156F;
            this.SecFt_AnnualOrderPrice.Left = 8.4375F;
            this.SecFt_AnnualOrderPrice.MultiLine = false;
            this.SecFt_AnnualOrderPrice.Name = "SecFt_AnnualOrderPrice";
            this.SecFt_AnnualOrderPrice.OutputFormat = resources.GetString("SecFt_AnnualOrderPrice.OutputFormat");
            this.SecFt_AnnualOrderPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualOrderPrice.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualOrderPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualOrderPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualOrderPrice.Text = "1,234,567,890";
            this.SecFt_AnnualOrderPrice.Top = 0.25F;
            this.SecFt_AnnualOrderPrice.Width = 0.8F;
            // 
            // SecFt_AnnualStockPriceRate
            // 
            this.SecFt_AnnualStockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceRate.Height = 0.156F;
            this.SecFt_AnnualStockPriceRate.Left = 9.355F;
            this.SecFt_AnnualStockPriceRate.MultiLine = false;
            this.SecFt_AnnualStockPriceRate.Name = "SecFt_AnnualStockPriceRate";
            this.SecFt_AnnualStockPriceRate.OutputFormat = resources.GetString("SecFt_AnnualStockPriceRate.OutputFormat");
            this.SecFt_AnnualStockPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualStockPriceRate.Text = "100.00%";
            this.SecFt_AnnualStockPriceRate.Top = 0.25F;
            this.SecFt_AnnualStockPriceRate.Width = 0.42F;
            // 
            // SecFt_dSeparator
            // 
            this.SecFt_dSeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_dSeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dSeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_dSeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dSeparator.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_dSeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dSeparator.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_dSeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dSeparator.Height = 0.156F;
            this.SecFt_dSeparator.Left = 9.9F;
            this.SecFt_dSeparator.MultiLine = false;
            this.SecFt_dSeparator.Name = "SecFt_dSeparator";
            this.SecFt_dSeparator.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_dSeparator.Text = "/";
            this.SecFt_dSeparator.Top = 0.25F;
            this.SecFt_dSeparator.Width = 0.1F;
            // 
            // SecFt_AnnualOrderPriceRate
            // 
            this.SecFt_AnnualOrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceRate.Height = 0.156F;
            this.SecFt_AnnualOrderPriceRate.Left = 10.125F;
            this.SecFt_AnnualOrderPriceRate.MultiLine = false;
            this.SecFt_AnnualOrderPriceRate.Name = "SecFt_AnnualOrderPriceRate";
            this.SecFt_AnnualOrderPriceRate.OutputFormat = resources.GetString("SecFt_AnnualOrderPriceRate.OutputFormat");
            this.SecFt_AnnualOrderPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualOrderPriceRate.Text = "100.00%";
            this.SecFt_AnnualOrderPriceRate.Top = 0.25F;
            this.SecFt_AnnualOrderPriceRate.Width = 0.42F;
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
            this.label1.Height = 0.25F;
            this.label1.HyperLink = "";
            this.label1.Left = 1.875F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "拠点計";
            this.label1.Top = 0.063F;
            this.label1.Width = 0.5625F;
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
            // SecFt_TotalPriceOrg
            // 
            this.SecFt_TotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalPriceOrg.DataField = "TotalPriceOrg";
            this.SecFt_TotalPriceOrg.Height = 0.156F;
            this.SecFt_TotalPriceOrg.Left = 2.5625F;
            this.SecFt_TotalPriceOrg.MultiLine = false;
            this.SecFt_TotalPriceOrg.Name = "SecFt_TotalPriceOrg";
            this.SecFt_TotalPriceOrg.OutputFormat = resources.GetString("SecFt_TotalPriceOrg.OutputFormat");
            this.SecFt_TotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_TotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalPriceOrg.Text = "1,234,567,890";
            this.SecFt_TotalPriceOrg.Top = 0.4685F;
            this.SecFt_TotalPriceOrg.Visible = false;
            this.SecFt_TotalPriceOrg.Width = 0.8F;
            // 
            // SecFt_RetGoodsPriceOrg
            // 
            this.SecFt_RetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_RetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_RetGoodsPriceOrg.DataField = "RetGoodsPriceOrg";
            this.SecFt_RetGoodsPriceOrg.Height = 0.156F;
            this.SecFt_RetGoodsPriceOrg.Left = 3.5F;
            this.SecFt_RetGoodsPriceOrg.MultiLine = false;
            this.SecFt_RetGoodsPriceOrg.Name = "SecFt_RetGoodsPriceOrg";
            this.SecFt_RetGoodsPriceOrg.OutputFormat = resources.GetString("SecFt_RetGoodsPriceOrg.OutputFormat");
            this.SecFt_RetGoodsPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_RetGoodsPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_RetGoodsPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_RetGoodsPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_RetGoodsPriceOrg.Text = "1,234,567,890";
            this.SecFt_RetGoodsPriceOrg.Top = 0.4685F;
            this.SecFt_RetGoodsPriceOrg.Visible = false;
            this.SecFt_RetGoodsPriceOrg.Width = 0.8F;
            // 
            // SecFt_AnnualTotalPriceOrg
            // 
            this.SecFt_AnnualTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalPriceOrg.DataField = "AnnualTotalPriceOrg";
            this.SecFt_AnnualTotalPriceOrg.Height = 0.156F;
            this.SecFt_AnnualTotalPriceOrg.Left = 2.5625F;
            this.SecFt_AnnualTotalPriceOrg.MultiLine = false;
            this.SecFt_AnnualTotalPriceOrg.Name = "SecFt_AnnualTotalPriceOrg";
            this.SecFt_AnnualTotalPriceOrg.OutputFormat = resources.GetString("SecFt_AnnualTotalPriceOrg.OutputFormat");
            this.SecFt_AnnualTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualTotalPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualTotalPriceOrg.Text = "1,234,567,890";
            this.SecFt_AnnualTotalPriceOrg.Top = 0.656F;
            this.SecFt_AnnualTotalPriceOrg.Visible = false;
            this.SecFt_AnnualTotalPriceOrg.Width = 0.8F;
            // 
            // SecFt_AnnualRetGoodsPriceOrg
            // 
            this.SecFt_AnnualRetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualRetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualRetGoodsPriceOrg.DataField = "AnnualRetGoodsPriceOrg";
            this.SecFt_AnnualRetGoodsPriceOrg.Height = 0.156F;
            this.SecFt_AnnualRetGoodsPriceOrg.Left = 3.5F;
            this.SecFt_AnnualRetGoodsPriceOrg.MultiLine = false;
            this.SecFt_AnnualRetGoodsPriceOrg.Name = "SecFt_AnnualRetGoodsPriceOrg";
            this.SecFt_AnnualRetGoodsPriceOrg.OutputFormat = resources.GetString("SecFt_AnnualRetGoodsPriceOrg.OutputFormat");
            this.SecFt_AnnualRetGoodsPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualRetGoodsPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualRetGoodsPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualRetGoodsPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualRetGoodsPriceOrg.Text = "1,234,567,890";
            this.SecFt_AnnualRetGoodsPriceOrg.Top = 0.656F;
            this.SecFt_AnnualRetGoodsPriceOrg.Visible = false;
            this.SecFt_AnnualRetGoodsPriceOrg.Width = 0.8F;
            // 
            // SecFt_TotalDiscountOrg
            // 
            this.SecFt_TotalDiscountOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscountOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscountOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscountOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscountOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscountOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscountOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalDiscountOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalDiscountOrg.DataField = "TotalDiscountOrg";
            this.SecFt_TotalDiscountOrg.Height = 0.156F;
            this.SecFt_TotalDiscountOrg.Left = 5.0625F;
            this.SecFt_TotalDiscountOrg.MultiLine = false;
            this.SecFt_TotalDiscountOrg.Name = "SecFt_TotalDiscountOrg";
            this.SecFt_TotalDiscountOrg.OutputFormat = resources.GetString("SecFt_TotalDiscountOrg.OutputFormat");
            this.SecFt_TotalDiscountOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalDiscountOrg.SummaryGroup = "SectionHeader";
            this.SecFt_TotalDiscountOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalDiscountOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalDiscountOrg.Text = "1,234,567,890";
            this.SecFt_TotalDiscountOrg.Top = 0.4685F;
            this.SecFt_TotalDiscountOrg.Visible = false;
            this.SecFt_TotalDiscountOrg.Width = 0.8F;
            // 
            // SecFt_PureTotalPriceOrg
            // 
            this.SecFt_PureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceOrg.DataField = "PureTotalPriceOrg";
            this.SecFt_PureTotalPriceOrg.Height = 0.156F;
            this.SecFt_PureTotalPriceOrg.Left = 6F;
            this.SecFt_PureTotalPriceOrg.MultiLine = false;
            this.SecFt_PureTotalPriceOrg.Name = "SecFt_PureTotalPriceOrg";
            this.SecFt_PureTotalPriceOrg.OutputFormat = resources.GetString("SecFt_PureTotalPriceOrg.OutputFormat");
            this.SecFt_PureTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_PureTotalPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_PureTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_PureTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_PureTotalPriceOrg.Text = "1,234,567,890";
            this.SecFt_PureTotalPriceOrg.Top = 0.4685F;
            this.SecFt_PureTotalPriceOrg.Visible = false;
            this.SecFt_PureTotalPriceOrg.Width = 0.8F;
            // 
            // SecFt_AnnualTotalDiscountOrg
            // 
            this.SecFt_AnnualTotalDiscountOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscountOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscountOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscountOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscountOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscountOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscountOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualTotalDiscountOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualTotalDiscountOrg.DataField = "AnnualTotalDiscountOrg";
            this.SecFt_AnnualTotalDiscountOrg.Height = 0.156F;
            this.SecFt_AnnualTotalDiscountOrg.Left = 5.0625F;
            this.SecFt_AnnualTotalDiscountOrg.MultiLine = false;
            this.SecFt_AnnualTotalDiscountOrg.Name = "SecFt_AnnualTotalDiscountOrg";
            this.SecFt_AnnualTotalDiscountOrg.OutputFormat = resources.GetString("SecFt_AnnualTotalDiscountOrg.OutputFormat");
            this.SecFt_AnnualTotalDiscountOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualTotalDiscountOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualTotalDiscountOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualTotalDiscountOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualTotalDiscountOrg.Text = "1,234,567,890";
            this.SecFt_AnnualTotalDiscountOrg.Top = 0.6555F;
            this.SecFt_AnnualTotalDiscountOrg.Visible = false;
            this.SecFt_AnnualTotalDiscountOrg.Width = 0.8F;
            // 
            // SecFt_AnnualPureTotalPriceOrg
            // 
            this.SecFt_AnnualPureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceOrg.DataField = "AnnualPureTotalPriceOrg";
            this.SecFt_AnnualPureTotalPriceOrg.Height = 0.156F;
            this.SecFt_AnnualPureTotalPriceOrg.Left = 6F;
            this.SecFt_AnnualPureTotalPriceOrg.MultiLine = false;
            this.SecFt_AnnualPureTotalPriceOrg.Name = "SecFt_AnnualPureTotalPriceOrg";
            this.SecFt_AnnualPureTotalPriceOrg.OutputFormat = resources.GetString("SecFt_AnnualPureTotalPriceOrg.OutputFormat");
            this.SecFt_AnnualPureTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualPureTotalPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualPureTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualPureTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualPureTotalPriceOrg.Text = "1,234,567,890";
            this.SecFt_AnnualPureTotalPriceOrg.Top = 0.6555F;
            this.SecFt_AnnualPureTotalPriceOrg.Visible = false;
            this.SecFt_AnnualPureTotalPriceOrg.Width = 0.8F;
            // 
            // SecFt_StockPriceOrg
            // 
            this.SecFt_StockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_StockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_StockPriceOrg.DataField = "StockPriceOrg";
            this.SecFt_StockPriceOrg.Height = 0.156F;
            this.SecFt_StockPriceOrg.Left = 7.5625F;
            this.SecFt_StockPriceOrg.MultiLine = false;
            this.SecFt_StockPriceOrg.Name = "SecFt_StockPriceOrg";
            this.SecFt_StockPriceOrg.OutputFormat = resources.GetString("SecFt_StockPriceOrg.OutputFormat");
            this.SecFt_StockPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_StockPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_StockPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_StockPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_StockPriceOrg.Text = "1,234,567,890";
            this.SecFt_StockPriceOrg.Top = 0.4685F;
            this.SecFt_StockPriceOrg.Visible = false;
            this.SecFt_StockPriceOrg.Width = 0.8F;
            // 
            // SecFt_OrderPriceOrg
            // 
            this.SecFt_OrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_OrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_OrderPriceOrg.DataField = "OrderPriceOrg";
            this.SecFt_OrderPriceOrg.Height = 0.156F;
            this.SecFt_OrderPriceOrg.Left = 8.4375F;
            this.SecFt_OrderPriceOrg.MultiLine = false;
            this.SecFt_OrderPriceOrg.Name = "SecFt_OrderPriceOrg";
            this.SecFt_OrderPriceOrg.OutputFormat = resources.GetString("SecFt_OrderPriceOrg.OutputFormat");
            this.SecFt_OrderPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_OrderPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_OrderPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_OrderPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_OrderPriceOrg.Text = "1,234,567,890";
            this.SecFt_OrderPriceOrg.Top = 0.4685F;
            this.SecFt_OrderPriceOrg.Visible = false;
            this.SecFt_OrderPriceOrg.Width = 0.8F;
            // 
            // SecFt_AnnualStockPriceOrg
            // 
            this.SecFt_AnnualStockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualStockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualStockPriceOrg.DataField = "AnnualStockPriceOrg";
            this.SecFt_AnnualStockPriceOrg.Height = 0.156F;
            this.SecFt_AnnualStockPriceOrg.Left = 7.5625F;
            this.SecFt_AnnualStockPriceOrg.MultiLine = false;
            this.SecFt_AnnualStockPriceOrg.Name = "SecFt_AnnualStockPriceOrg";
            this.SecFt_AnnualStockPriceOrg.OutputFormat = resources.GetString("SecFt_AnnualStockPriceOrg.OutputFormat");
            this.SecFt_AnnualStockPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualStockPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualStockPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualStockPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualStockPriceOrg.Text = "1,234,567,890";
            this.SecFt_AnnualStockPriceOrg.Top = 0.6555F;
            this.SecFt_AnnualStockPriceOrg.Visible = false;
            this.SecFt_AnnualStockPriceOrg.Width = 0.8F;
            // 
            // SecFt_AnnualOrderPriceOrg
            // 
            this.SecFt_AnnualOrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualOrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualOrderPriceOrg.DataField = "AnnualOrderPriceOrg";
            this.SecFt_AnnualOrderPriceOrg.Height = 0.156F;
            this.SecFt_AnnualOrderPriceOrg.Left = 8.4375F;
            this.SecFt_AnnualOrderPriceOrg.MultiLine = false;
            this.SecFt_AnnualOrderPriceOrg.Name = "SecFt_AnnualOrderPriceOrg";
            this.SecFt_AnnualOrderPriceOrg.OutputFormat = resources.GetString("SecFt_AnnualOrderPriceOrg.OutputFormat");
            this.SecFt_AnnualOrderPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualOrderPriceOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualOrderPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualOrderPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualOrderPriceOrg.Text = "1,234,567,890";
            this.SecFt_AnnualOrderPriceOrg.Top = 0.6555F;
            this.SecFt_AnnualOrderPriceOrg.Visible = false;
            this.SecFt_AnnualOrderPriceOrg.Width = 0.8F;
            // 
            // SecFt_PureTotalPriceSum
            // 
            this.SecFt_PureTotalPriceSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceSum.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceSum.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_PureTotalPriceSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureTotalPriceSum.DataField = "PureTotalPriceSum";
            this.SecFt_PureTotalPriceSum.Height = 0.156F;
            this.SecFt_PureTotalPriceSum.Left = 6F;
            this.SecFt_PureTotalPriceSum.MultiLine = false;
            this.SecFt_PureTotalPriceSum.Name = "SecFt_PureTotalPriceSum";
            this.SecFt_PureTotalPriceSum.OutputFormat = resources.GetString("SecFt_PureTotalPriceSum.OutputFormat");
            this.SecFt_PureTotalPriceSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_PureTotalPriceSum.Text = "1,234,567,890";
            this.SecFt_PureTotalPriceSum.Top = 0.874F;
            this.SecFt_PureTotalPriceSum.Visible = false;
            this.SecFt_PureTotalPriceSum.Width = 0.8F;
            // 
            // SecFt_AnnualPureTotalPriceSum
            // 
            this.SecFt_AnnualPureTotalPriceSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceSum.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceSum.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureTotalPriceSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureTotalPriceSum.DataField = "AnnualPureTotalPriceSum";
            this.SecFt_AnnualPureTotalPriceSum.Height = 0.156F;
            this.SecFt_AnnualPureTotalPriceSum.Left = 6F;
            this.SecFt_AnnualPureTotalPriceSum.MultiLine = false;
            this.SecFt_AnnualPureTotalPriceSum.Name = "SecFt_AnnualPureTotalPriceSum";
            this.SecFt_AnnualPureTotalPriceSum.OutputFormat = resources.GetString("SecFt_AnnualPureTotalPriceSum.OutputFormat");
            this.SecFt_AnnualPureTotalPriceSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualPureTotalPriceSum.Text = "1,234,567,890";
            this.SecFt_AnnualPureTotalPriceSum.Top = 1.061F;
            this.SecFt_AnnualPureTotalPriceSum.Visible = false;
            this.SecFt_AnnualPureTotalPriceSum.Width = 0.8F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.CanShrink = true;
            this.SupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupHd_SuplierCode,
            this.SupHd_SuplierName,
            this.line8});
            this.SupplierHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SupplierHeader.Height = 0.25F;
            this.SupplierHeader.KeepTogether = true;
            this.SupplierHeader.Name = "SupplierHeader";
            this.SupplierHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SupplierHeader.BeforePrint += new System.EventHandler(this.SupplierHeader_BeforePrint);
            // 
            // SupHd_SuplierCode
            // 
            this.SupHd_SuplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SuplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SuplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SuplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SuplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierCode.DataField = "SupplierCd";
            this.SupHd_SuplierCode.Height = 0.16F;
            this.SupHd_SuplierCode.Left = 0.063F;
            this.SupHd_SuplierCode.MultiLine = false;
            this.SupHd_SuplierCode.Name = "SupHd_SuplierCode";
            this.SupHd_SuplierCode.OutputFormat = resources.GetString("SupHd_SuplierCode.OutputFormat");
            this.SupHd_SuplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_SuplierCode.Text = "123456";
            this.SupHd_SuplierCode.Top = 0F;
            this.SupHd_SuplierCode.Width = 0.4F;
            // 
            // SupHd_SuplierName
            // 
            this.SupHd_SuplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SuplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SuplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierName.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SuplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierName.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SuplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SuplierName.DataField = "SupplierSnm";
            this.SupHd_SuplierName.Height = 0.16F;
            this.SupHd_SuplierName.Left = 0.5F;
            this.SupHd_SuplierName.MultiLine = false;
            this.SupHd_SuplierName.Name = "SupHd_SuplierName";
            this.SupHd_SuplierName.OutputFormat = resources.GetString("SupHd_SuplierName.OutputFormat");
            this.SupHd_SuplierName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SupHd_SuplierName.Text = "あいうえおかきくけこ";
            this.SupHd_SuplierName.Top = 0F;
            this.SupHd_SuplierName.Width = 1.2F;
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupFt_TotalPrice,
            this.SupFt_RetGoodsPrice,
            this.SupFt_RetGoodsPriceRate,
            this.SupFt_TotalDiscount,
            this.SupFt_PureTotalPrice,
            this.SupFt_ConstUnitRate,
            this.SupFt_StockPrice,
            this.SupFt_OrderPrice,
            this.SupFt_StockPriceRate,
            this.SupFt_ySeparator,
            this.SupFt_OrderPriceRate,
            this.SupFt_AnnualTotalPrice,
            this.SupFt_AnnualRetGoodsPrice,
            this.SupFt_AnnualRetGoodsPriceRate,
            this.SupFt_AnnualTotalDiscount,
            this.SupFt_AnnualPureTotalPrice,
            this.SupFt_AnnualConstUnitRate,
            this.SupFt_AnnualStockPrice,
            this.SupFt_AnnualOrderPrice,
            this.SupFt_AnnualStockPriceRate,
            this.SupFt_dSeparator,
            this.SupFt_AnnualOrderPriceRate,
            this.label4,
            this.line4,
            this.SupFt_TotalPriceOrg,
            this.SupFt_RetGoodsPriceOrg,
            this.SupFt_AnnualTotalPriceOrg,
            this.SupFt_AnnualRetGoodsPriceOrg,
            this.SupFt_TotalDiscountOrg,
            this.SupFt_PureTotalPriceOrg,
            this.SupFt_AnnualTotalDiscountOrg,
            this.SupFt_AnnualPureTotalPriceOrg,
            this.SupFt_StockPriceOrg,
            this.SupFt_OrderPriceOrg,
            this.SupFt_AnnualStockPriceOrg,
            this.SupFt_AnnualOrderPriceOrg,
            this.SupFt_PureTotalPriceSum,
            this.SupFt_AnnualPureTotalPriceSum});
            this.SupplierFooter.Height = 1.322917F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            this.SupplierFooter.BeforePrint += new System.EventHandler(this.SupplierFooter_BeforePrint);
            // 
            // SupFt_TotalPrice
            // 
            this.SupFt_TotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPrice.DataField = "TotalPrice";
            this.SupFt_TotalPrice.Height = 0.156F;
            this.SupFt_TotalPrice.Left = 2.5875F;
            this.SupFt_TotalPrice.MultiLine = false;
            this.SupFt_TotalPrice.Name = "SupFt_TotalPrice";
            this.SupFt_TotalPrice.OutputFormat = resources.GetString("SupFt_TotalPrice.OutputFormat");
            this.SupFt_TotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalPrice.Text = "1,234,567,890";
            this.SupFt_TotalPrice.Top = 0.0625F;
            this.SupFt_TotalPrice.Width = 0.8F;
            // 
            // SupFt_RetGoodsPrice
            // 
            this.SupFt_RetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPrice.DataField = "RetGoodsPrice";
            this.SupFt_RetGoodsPrice.Height = 0.156F;
            this.SupFt_RetGoodsPrice.Left = 3.5125F;
            this.SupFt_RetGoodsPrice.MultiLine = false;
            this.SupFt_RetGoodsPrice.Name = "SupFt_RetGoodsPrice";
            this.SupFt_RetGoodsPrice.OutputFormat = resources.GetString("SupFt_RetGoodsPrice.OutputFormat");
            this.SupFt_RetGoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_RetGoodsPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_RetGoodsPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_RetGoodsPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_RetGoodsPrice.Text = "1,234,567,890";
            this.SupFt_RetGoodsPrice.Top = 0.0625F;
            this.SupFt_RetGoodsPrice.Width = 0.8F;
            // 
            // SupFt_RetGoodsPriceRate
            // 
            this.SupFt_RetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceRate.Height = 0.156F;
            this.SupFt_RetGoodsPriceRate.Left = 4.4375F;
            this.SupFt_RetGoodsPriceRate.MultiLine = false;
            this.SupFt_RetGoodsPriceRate.Name = "SupFt_RetGoodsPriceRate";
            this.SupFt_RetGoodsPriceRate.OutputFormat = resources.GetString("SupFt_RetGoodsPriceRate.OutputFormat");
            this.SupFt_RetGoodsPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_RetGoodsPriceRate.Text = "100.00%";
            this.SupFt_RetGoodsPriceRate.Top = 0.0625F;
            this.SupFt_RetGoodsPriceRate.Width = 0.42F;
            // 
            // SupFt_TotalDiscount
            // 
            this.SupFt_TotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscount.DataField = "TotalDiscount";
            this.SupFt_TotalDiscount.Height = 0.156F;
            this.SupFt_TotalDiscount.Left = 5.0625F;
            this.SupFt_TotalDiscount.MultiLine = false;
            this.SupFt_TotalDiscount.Name = "SupFt_TotalDiscount";
            this.SupFt_TotalDiscount.OutputFormat = resources.GetString("SupFt_TotalDiscount.OutputFormat");
            this.SupFt_TotalDiscount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalDiscount.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalDiscount.Text = "1,234,567,890";
            this.SupFt_TotalDiscount.Top = 0.0625F;
            this.SupFt_TotalDiscount.Width = 0.8F;
            // 
            // SupFt_PureTotalPrice
            // 
            this.SupFt_PureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPrice.DataField = "PureTotalPrice";
            this.SupFt_PureTotalPrice.Height = 0.156F;
            this.SupFt_PureTotalPrice.Left = 6F;
            this.SupFt_PureTotalPrice.MultiLine = false;
            this.SupFt_PureTotalPrice.Name = "SupFt_PureTotalPrice";
            this.SupFt_PureTotalPrice.OutputFormat = resources.GetString("SupFt_PureTotalPrice.OutputFormat");
            this.SupFt_PureTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_PureTotalPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_PureTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_PureTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_PureTotalPrice.Text = "1,234,567,890";
            this.SupFt_PureTotalPrice.Top = 0.0625F;
            this.SupFt_PureTotalPrice.Width = 0.8F;
            // 
            // SupFt_ConstUnitRate
            // 
            this.SupFt_ConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_ConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_ConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_ConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_ConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ConstUnitRate.Height = 0.156F;
            this.SupFt_ConstUnitRate.Left = 6.9375F;
            this.SupFt_ConstUnitRate.MultiLine = false;
            this.SupFt_ConstUnitRate.Name = "SupFt_ConstUnitRate";
            this.SupFt_ConstUnitRate.OutputFormat = resources.GetString("SupFt_ConstUnitRate.OutputFormat");
            this.SupFt_ConstUnitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_ConstUnitRate.Text = "100.00%";
            this.SupFt_ConstUnitRate.Top = 0.0625F;
            this.SupFt_ConstUnitRate.Width = 0.42F;
            // 
            // SupFt_StockPrice
            // 
            this.SupFt_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPrice.DataField = "StockPrice";
            this.SupFt_StockPrice.Height = 0.156F;
            this.SupFt_StockPrice.Left = 7.5625F;
            this.SupFt_StockPrice.MultiLine = false;
            this.SupFt_StockPrice.Name = "SupFt_StockPrice";
            this.SupFt_StockPrice.OutputFormat = resources.GetString("SupFt_StockPrice.OutputFormat");
            this.SupFt_StockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_StockPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_StockPrice.Text = "1,234,567,890";
            this.SupFt_StockPrice.Top = 0.0625F;
            this.SupFt_StockPrice.Width = 0.8F;
            // 
            // SupFt_OrderPrice
            // 
            this.SupFt_OrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_OrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_OrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_OrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_OrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPrice.DataField = "OrderPrice";
            this.SupFt_OrderPrice.Height = 0.156F;
            this.SupFt_OrderPrice.Left = 8.4375F;
            this.SupFt_OrderPrice.MultiLine = false;
            this.SupFt_OrderPrice.Name = "SupFt_OrderPrice";
            this.SupFt_OrderPrice.OutputFormat = resources.GetString("SupFt_OrderPrice.OutputFormat");
            this.SupFt_OrderPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_OrderPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_OrderPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_OrderPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_OrderPrice.Text = "1,234,567,890";
            this.SupFt_OrderPrice.Top = 0.0625F;
            this.SupFt_OrderPrice.Width = 0.8F;
            // 
            // SupFt_StockPriceRate
            // 
            this.SupFt_StockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceRate.Height = 0.156F;
            this.SupFt_StockPriceRate.Left = 9.355F;
            this.SupFt_StockPriceRate.MultiLine = false;
            this.SupFt_StockPriceRate.Name = "SupFt_StockPriceRate";
            this.SupFt_StockPriceRate.OutputFormat = resources.GetString("SupFt_StockPriceRate.OutputFormat");
            this.SupFt_StockPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_StockPriceRate.Text = "100.00%";
            this.SupFt_StockPriceRate.Top = 0.0625F;
            this.SupFt_StockPriceRate.Width = 0.42F;
            // 
            // SupFt_ySeparator
            // 
            this.SupFt_ySeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_ySeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ySeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_ySeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ySeparator.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_ySeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ySeparator.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_ySeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_ySeparator.Height = 0.156F;
            this.SupFt_ySeparator.Left = 9.9F;
            this.SupFt_ySeparator.MultiLine = false;
            this.SupFt_ySeparator.Name = "SupFt_ySeparator";
            this.SupFt_ySeparator.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_ySeparator.Text = "/";
            this.SupFt_ySeparator.Top = 0.0625F;
            this.SupFt_ySeparator.Width = 0.1F;
            // 
            // SupFt_OrderPriceRate
            // 
            this.SupFt_OrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceRate.Height = 0.156F;
            this.SupFt_OrderPriceRate.Left = 10.125F;
            this.SupFt_OrderPriceRate.MultiLine = false;
            this.SupFt_OrderPriceRate.Name = "SupFt_OrderPriceRate";
            this.SupFt_OrderPriceRate.OutputFormat = resources.GetString("SupFt_OrderPriceRate.OutputFormat");
            this.SupFt_OrderPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_OrderPriceRate.Text = "100.00%";
            this.SupFt_OrderPriceRate.Top = 0.0625F;
            this.SupFt_OrderPriceRate.Width = 0.42F;
            // 
            // SupFt_AnnualTotalPrice
            // 
            this.SupFt_AnnualTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPrice.DataField = "AnnualTotalPrice";
            this.SupFt_AnnualTotalPrice.Height = 0.156F;
            this.SupFt_AnnualTotalPrice.Left = 2.5875F;
            this.SupFt_AnnualTotalPrice.MultiLine = false;
            this.SupFt_AnnualTotalPrice.Name = "SupFt_AnnualTotalPrice";
            this.SupFt_AnnualTotalPrice.OutputFormat = resources.GetString("SupFt_AnnualTotalPrice.OutputFormat");
            this.SupFt_AnnualTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualTotalPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualTotalPrice.Text = "1,234,567,890";
            this.SupFt_AnnualTotalPrice.Top = 0.25F;
            this.SupFt_AnnualTotalPrice.Width = 0.8F;
            // 
            // SupFt_AnnualRetGoodsPrice
            // 
            this.SupFt_AnnualRetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPrice.DataField = "AnnualRetGoodsPrice";
            this.SupFt_AnnualRetGoodsPrice.Height = 0.156F;
            this.SupFt_AnnualRetGoodsPrice.Left = 3.5125F;
            this.SupFt_AnnualRetGoodsPrice.MultiLine = false;
            this.SupFt_AnnualRetGoodsPrice.Name = "SupFt_AnnualRetGoodsPrice";
            this.SupFt_AnnualRetGoodsPrice.OutputFormat = resources.GetString("SupFt_AnnualRetGoodsPrice.OutputFormat");
            this.SupFt_AnnualRetGoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualRetGoodsPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualRetGoodsPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualRetGoodsPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualRetGoodsPrice.Text = "1,234,567,890";
            this.SupFt_AnnualRetGoodsPrice.Top = 0.25F;
            this.SupFt_AnnualRetGoodsPrice.Width = 0.8F;
            // 
            // SupFt_AnnualRetGoodsPriceRate
            // 
            this.SupFt_AnnualRetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceRate.Height = 0.156F;
            this.SupFt_AnnualRetGoodsPriceRate.Left = 4.4375F;
            this.SupFt_AnnualRetGoodsPriceRate.MultiLine = false;
            this.SupFt_AnnualRetGoodsPriceRate.Name = "SupFt_AnnualRetGoodsPriceRate";
            this.SupFt_AnnualRetGoodsPriceRate.OutputFormat = resources.GetString("SupFt_AnnualRetGoodsPriceRate.OutputFormat");
            this.SupFt_AnnualRetGoodsPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualRetGoodsPriceRate.Text = "100.00%";
            this.SupFt_AnnualRetGoodsPriceRate.Top = 0.25F;
            this.SupFt_AnnualRetGoodsPriceRate.Width = 0.42F;
            // 
            // SupFt_AnnualTotalDiscount
            // 
            this.SupFt_AnnualTotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscount.DataField = "AnnualTotalDiscount";
            this.SupFt_AnnualTotalDiscount.Height = 0.156F;
            this.SupFt_AnnualTotalDiscount.Left = 5.0625F;
            this.SupFt_AnnualTotalDiscount.MultiLine = false;
            this.SupFt_AnnualTotalDiscount.Name = "SupFt_AnnualTotalDiscount";
            this.SupFt_AnnualTotalDiscount.OutputFormat = resources.GetString("SupFt_AnnualTotalDiscount.OutputFormat");
            this.SupFt_AnnualTotalDiscount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualTotalDiscount.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualTotalDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualTotalDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualTotalDiscount.Text = "1,234,567,890";
            this.SupFt_AnnualTotalDiscount.Top = 0.25F;
            this.SupFt_AnnualTotalDiscount.Width = 0.8F;
            // 
            // SupFt_AnnualPureTotalPrice
            // 
            this.SupFt_AnnualPureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPrice.DataField = "AnnualPureTotalPrice";
            this.SupFt_AnnualPureTotalPrice.Height = 0.156F;
            this.SupFt_AnnualPureTotalPrice.Left = 6F;
            this.SupFt_AnnualPureTotalPrice.MultiLine = false;
            this.SupFt_AnnualPureTotalPrice.Name = "SupFt_AnnualPureTotalPrice";
            this.SupFt_AnnualPureTotalPrice.OutputFormat = resources.GetString("SupFt_AnnualPureTotalPrice.OutputFormat");
            this.SupFt_AnnualPureTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualPureTotalPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualPureTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualPureTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualPureTotalPrice.Text = "1,234,567,890";
            this.SupFt_AnnualPureTotalPrice.Top = 0.25F;
            this.SupFt_AnnualPureTotalPrice.Width = 0.8F;
            // 
            // SupFt_AnnualConstUnitRate
            // 
            this.SupFt_AnnualConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualConstUnitRate.Height = 0.156F;
            this.SupFt_AnnualConstUnitRate.Left = 6.9375F;
            this.SupFt_AnnualConstUnitRate.MultiLine = false;
            this.SupFt_AnnualConstUnitRate.Name = "SupFt_AnnualConstUnitRate";
            this.SupFt_AnnualConstUnitRate.OutputFormat = resources.GetString("SupFt_AnnualConstUnitRate.OutputFormat");
            this.SupFt_AnnualConstUnitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualConstUnitRate.Text = "100.00%";
            this.SupFt_AnnualConstUnitRate.Top = 0.25F;
            this.SupFt_AnnualConstUnitRate.Width = 0.42F;
            // 
            // SupFt_AnnualStockPrice
            // 
            this.SupFt_AnnualStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPrice.DataField = "AnnualStockPrice";
            this.SupFt_AnnualStockPrice.Height = 0.156F;
            this.SupFt_AnnualStockPrice.Left = 7.5625F;
            this.SupFt_AnnualStockPrice.MultiLine = false;
            this.SupFt_AnnualStockPrice.Name = "SupFt_AnnualStockPrice";
            this.SupFt_AnnualStockPrice.OutputFormat = resources.GetString("SupFt_AnnualStockPrice.OutputFormat");
            this.SupFt_AnnualStockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualStockPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualStockPrice.Text = "1,234,567,890";
            this.SupFt_AnnualStockPrice.Top = 0.25F;
            this.SupFt_AnnualStockPrice.Width = 0.8F;
            // 
            // SupFt_AnnualOrderPrice
            // 
            this.SupFt_AnnualOrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPrice.DataField = "AnnualOrderPrice";
            this.SupFt_AnnualOrderPrice.Height = 0.156F;
            this.SupFt_AnnualOrderPrice.Left = 8.4375F;
            this.SupFt_AnnualOrderPrice.MultiLine = false;
            this.SupFt_AnnualOrderPrice.Name = "SupFt_AnnualOrderPrice";
            this.SupFt_AnnualOrderPrice.OutputFormat = resources.GetString("SupFt_AnnualOrderPrice.OutputFormat");
            this.SupFt_AnnualOrderPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualOrderPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualOrderPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualOrderPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualOrderPrice.Text = "1,234,567,890";
            this.SupFt_AnnualOrderPrice.Top = 0.25F;
            this.SupFt_AnnualOrderPrice.Width = 0.8F;
            // 
            // SupFt_AnnualStockPriceRate
            // 
            this.SupFt_AnnualStockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceRate.Height = 0.156F;
            this.SupFt_AnnualStockPriceRate.Left = 9.355F;
            this.SupFt_AnnualStockPriceRate.MultiLine = false;
            this.SupFt_AnnualStockPriceRate.Name = "SupFt_AnnualStockPriceRate";
            this.SupFt_AnnualStockPriceRate.OutputFormat = resources.GetString("SupFt_AnnualStockPriceRate.OutputFormat");
            this.SupFt_AnnualStockPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualStockPriceRate.Text = "100.00%";
            this.SupFt_AnnualStockPriceRate.Top = 0.25F;
            this.SupFt_AnnualStockPriceRate.Width = 0.42F;
            // 
            // SupFt_dSeparator
            // 
            this.SupFt_dSeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_dSeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_dSeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_dSeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_dSeparator.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_dSeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_dSeparator.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_dSeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_dSeparator.Height = 0.156F;
            this.SupFt_dSeparator.Left = 9.9F;
            this.SupFt_dSeparator.MultiLine = false;
            this.SupFt_dSeparator.Name = "SupFt_dSeparator";
            this.SupFt_dSeparator.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_dSeparator.Text = "/";
            this.SupFt_dSeparator.Top = 0.25F;
            this.SupFt_dSeparator.Width = 0.1F;
            // 
            // SupFt_AnnualOrderPriceRate
            // 
            this.SupFt_AnnualOrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceRate.Height = 0.156F;
            this.SupFt_AnnualOrderPriceRate.Left = 10.125F;
            this.SupFt_AnnualOrderPriceRate.MultiLine = false;
            this.SupFt_AnnualOrderPriceRate.Name = "SupFt_AnnualOrderPriceRate";
            this.SupFt_AnnualOrderPriceRate.OutputFormat = resources.GetString("SupFt_AnnualOrderPriceRate.OutputFormat");
            this.SupFt_AnnualOrderPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualOrderPriceRate.Text = "100.00%";
            this.SupFt_AnnualOrderPriceRate.Top = 0.25F;
            this.SupFt_AnnualOrderPriceRate.Width = 0.42F;
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
            this.label4.Height = 0.25F;
            this.label4.HyperLink = "";
            this.label4.Left = 1.875F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "仕入先計";
            this.label4.Top = 0.0625F;
            this.label4.Width = 0.7F;
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
            // SupFt_TotalPriceOrg
            // 
            this.SupFt_TotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalPriceOrg.DataField = "TotalPriceOrg";
            this.SupFt_TotalPriceOrg.Height = 0.156F;
            this.SupFt_TotalPriceOrg.Left = 2.5875F;
            this.SupFt_TotalPriceOrg.MultiLine = false;
            this.SupFt_TotalPriceOrg.Name = "SupFt_TotalPriceOrg";
            this.SupFt_TotalPriceOrg.OutputFormat = resources.GetString("SupFt_TotalPriceOrg.OutputFormat");
            this.SupFt_TotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalPriceOrg.Text = "1,234,567,890";
            this.SupFt_TotalPriceOrg.Top = 0.4685F;
            this.SupFt_TotalPriceOrg.Visible = false;
            this.SupFt_TotalPriceOrg.Width = 0.8F;
            // 
            // SupFt_RetGoodsPriceOrg
            // 
            this.SupFt_RetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_RetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_RetGoodsPriceOrg.DataField = "RetGoodsPriceOrg";
            this.SupFt_RetGoodsPriceOrg.Height = 0.156F;
            this.SupFt_RetGoodsPriceOrg.Left = 3.5125F;
            this.SupFt_RetGoodsPriceOrg.MultiLine = false;
            this.SupFt_RetGoodsPriceOrg.Name = "SupFt_RetGoodsPriceOrg";
            this.SupFt_RetGoodsPriceOrg.OutputFormat = resources.GetString("SupFt_RetGoodsPriceOrg.OutputFormat");
            this.SupFt_RetGoodsPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_RetGoodsPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_RetGoodsPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_RetGoodsPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_RetGoodsPriceOrg.Text = "1,234,567,890";
            this.SupFt_RetGoodsPriceOrg.Top = 0.4685F;
            this.SupFt_RetGoodsPriceOrg.Visible = false;
            this.SupFt_RetGoodsPriceOrg.Width = 0.8F;
            // 
            // SupFt_AnnualTotalPriceOrg
            // 
            this.SupFt_AnnualTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalPriceOrg.DataField = "AnnualTotalPriceOrg";
            this.SupFt_AnnualTotalPriceOrg.Height = 0.156F;
            this.SupFt_AnnualTotalPriceOrg.Left = 2.5875F;
            this.SupFt_AnnualTotalPriceOrg.MultiLine = false;
            this.SupFt_AnnualTotalPriceOrg.Name = "SupFt_AnnualTotalPriceOrg";
            this.SupFt_AnnualTotalPriceOrg.OutputFormat = resources.GetString("SupFt_AnnualTotalPriceOrg.OutputFormat");
            this.SupFt_AnnualTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualTotalPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualTotalPriceOrg.Text = "1,234,567,890";
            this.SupFt_AnnualTotalPriceOrg.Top = 0.656F;
            this.SupFt_AnnualTotalPriceOrg.Visible = false;
            this.SupFt_AnnualTotalPriceOrg.Width = 0.8F;
            // 
            // SupFt_AnnualRetGoodsPriceOrg
            // 
            this.SupFt_AnnualRetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualRetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualRetGoodsPriceOrg.DataField = "AnnualRetGoodsPriceOrg";
            this.SupFt_AnnualRetGoodsPriceOrg.Height = 0.156F;
            this.SupFt_AnnualRetGoodsPriceOrg.Left = 3.5125F;
            this.SupFt_AnnualRetGoodsPriceOrg.MultiLine = false;
            this.SupFt_AnnualRetGoodsPriceOrg.Name = "SupFt_AnnualRetGoodsPriceOrg";
            this.SupFt_AnnualRetGoodsPriceOrg.OutputFormat = resources.GetString("SupFt_AnnualRetGoodsPriceOrg.OutputFormat");
            this.SupFt_AnnualRetGoodsPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualRetGoodsPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualRetGoodsPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualRetGoodsPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualRetGoodsPriceOrg.Text = "1,234,567,890";
            this.SupFt_AnnualRetGoodsPriceOrg.Top = 0.656F;
            this.SupFt_AnnualRetGoodsPriceOrg.Visible = false;
            this.SupFt_AnnualRetGoodsPriceOrg.Width = 0.8F;
            // 
            // SupFt_TotalDiscountOrg
            // 
            this.SupFt_TotalDiscountOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscountOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscountOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscountOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscountOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscountOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscountOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalDiscountOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalDiscountOrg.DataField = "TotalDiscountOrg";
            this.SupFt_TotalDiscountOrg.Height = 0.156F;
            this.SupFt_TotalDiscountOrg.Left = 5.0625F;
            this.SupFt_TotalDiscountOrg.MultiLine = false;
            this.SupFt_TotalDiscountOrg.Name = "SupFt_TotalDiscountOrg";
            this.SupFt_TotalDiscountOrg.OutputFormat = resources.GetString("SupFt_TotalDiscountOrg.OutputFormat");
            this.SupFt_TotalDiscountOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalDiscountOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalDiscountOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalDiscountOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalDiscountOrg.Text = "1,234,567,890";
            this.SupFt_TotalDiscountOrg.Top = 0.4685F;
            this.SupFt_TotalDiscountOrg.Visible = false;
            this.SupFt_TotalDiscountOrg.Width = 0.8F;
            // 
            // SupFt_PureTotalPriceOrg
            // 
            this.SupFt_PureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceOrg.DataField = "PureTotalPriceOrg";
            this.SupFt_PureTotalPriceOrg.Height = 0.156F;
            this.SupFt_PureTotalPriceOrg.Left = 6F;
            this.SupFt_PureTotalPriceOrg.MultiLine = false;
            this.SupFt_PureTotalPriceOrg.Name = "SupFt_PureTotalPriceOrg";
            this.SupFt_PureTotalPriceOrg.OutputFormat = resources.GetString("SupFt_PureTotalPriceOrg.OutputFormat");
            this.SupFt_PureTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_PureTotalPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_PureTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_PureTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_PureTotalPriceOrg.Text = "1,234,567,890";
            this.SupFt_PureTotalPriceOrg.Top = 0.4685F;
            this.SupFt_PureTotalPriceOrg.Visible = false;
            this.SupFt_PureTotalPriceOrg.Width = 0.8F;
            // 
            // SupFt_AnnualTotalDiscountOrg
            // 
            this.SupFt_AnnualTotalDiscountOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscountOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscountOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscountOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscountOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscountOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscountOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualTotalDiscountOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualTotalDiscountOrg.DataField = "AnnualTotalDiscountOrg";
            this.SupFt_AnnualTotalDiscountOrg.Height = 0.156F;
            this.SupFt_AnnualTotalDiscountOrg.Left = 5.0625F;
            this.SupFt_AnnualTotalDiscountOrg.MultiLine = false;
            this.SupFt_AnnualTotalDiscountOrg.Name = "SupFt_AnnualTotalDiscountOrg";
            this.SupFt_AnnualTotalDiscountOrg.OutputFormat = resources.GetString("SupFt_AnnualTotalDiscountOrg.OutputFormat");
            this.SupFt_AnnualTotalDiscountOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualTotalDiscountOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualTotalDiscountOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualTotalDiscountOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualTotalDiscountOrg.Text = "1,234,567,890";
            this.SupFt_AnnualTotalDiscountOrg.Top = 0.656F;
            this.SupFt_AnnualTotalDiscountOrg.Visible = false;
            this.SupFt_AnnualTotalDiscountOrg.Width = 0.8F;
            // 
            // SupFt_AnnualPureTotalPriceOrg
            // 
            this.SupFt_AnnualPureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceOrg.DataField = "AnnualPureTotalPriceOrg";
            this.SupFt_AnnualPureTotalPriceOrg.Height = 0.156F;
            this.SupFt_AnnualPureTotalPriceOrg.Left = 6F;
            this.SupFt_AnnualPureTotalPriceOrg.MultiLine = false;
            this.SupFt_AnnualPureTotalPriceOrg.Name = "SupFt_AnnualPureTotalPriceOrg";
            this.SupFt_AnnualPureTotalPriceOrg.OutputFormat = resources.GetString("SupFt_AnnualPureTotalPriceOrg.OutputFormat");
            this.SupFt_AnnualPureTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualPureTotalPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualPureTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualPureTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualPureTotalPriceOrg.Text = "1,234,567,890";
            this.SupFt_AnnualPureTotalPriceOrg.Top = 0.656F;
            this.SupFt_AnnualPureTotalPriceOrg.Visible = false;
            this.SupFt_AnnualPureTotalPriceOrg.Width = 0.8F;
            // 
            // SupFt_StockPriceOrg
            // 
            this.SupFt_StockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_StockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockPriceOrg.DataField = "StockPriceOrg";
            this.SupFt_StockPriceOrg.Height = 0.156F;
            this.SupFt_StockPriceOrg.Left = 7.5625F;
            this.SupFt_StockPriceOrg.MultiLine = false;
            this.SupFt_StockPriceOrg.Name = "SupFt_StockPriceOrg";
            this.SupFt_StockPriceOrg.OutputFormat = resources.GetString("SupFt_StockPriceOrg.OutputFormat");
            this.SupFt_StockPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_StockPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_StockPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_StockPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_StockPriceOrg.Text = "1,234,567,890";
            this.SupFt_StockPriceOrg.Top = 0.4685F;
            this.SupFt_StockPriceOrg.Visible = false;
            this.SupFt_StockPriceOrg.Width = 0.8F;
            // 
            // SupFt_OrderPriceOrg
            // 
            this.SupFt_OrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_OrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderPriceOrg.DataField = "OrderPriceOrg";
            this.SupFt_OrderPriceOrg.Height = 0.156F;
            this.SupFt_OrderPriceOrg.Left = 8.4375F;
            this.SupFt_OrderPriceOrg.MultiLine = false;
            this.SupFt_OrderPriceOrg.Name = "SupFt_OrderPriceOrg";
            this.SupFt_OrderPriceOrg.OutputFormat = resources.GetString("SupFt_OrderPriceOrg.OutputFormat");
            this.SupFt_OrderPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_OrderPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_OrderPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_OrderPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_OrderPriceOrg.Text = "1,234,567,890";
            this.SupFt_OrderPriceOrg.Top = 0.4685F;
            this.SupFt_OrderPriceOrg.Visible = false;
            this.SupFt_OrderPriceOrg.Width = 0.8F;
            // 
            // SupFt_AnnualStockPriceOrg
            // 
            this.SupFt_AnnualStockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualStockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualStockPriceOrg.DataField = "AnnualStockPriceOrg";
            this.SupFt_AnnualStockPriceOrg.Height = 0.156F;
            this.SupFt_AnnualStockPriceOrg.Left = 7.5625F;
            this.SupFt_AnnualStockPriceOrg.MultiLine = false;
            this.SupFt_AnnualStockPriceOrg.Name = "SupFt_AnnualStockPriceOrg";
            this.SupFt_AnnualStockPriceOrg.OutputFormat = resources.GetString("SupFt_AnnualStockPriceOrg.OutputFormat");
            this.SupFt_AnnualStockPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualStockPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualStockPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualStockPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualStockPriceOrg.Text = "1,234,567,890";
            this.SupFt_AnnualStockPriceOrg.Top = 0.656F;
            this.SupFt_AnnualStockPriceOrg.Visible = false;
            this.SupFt_AnnualStockPriceOrg.Width = 0.8F;
            // 
            // SupFt_AnnualOrderPriceOrg
            // 
            this.SupFt_AnnualOrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualOrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualOrderPriceOrg.DataField = "AnnualOrderPriceOrg";
            this.SupFt_AnnualOrderPriceOrg.Height = 0.156F;
            this.SupFt_AnnualOrderPriceOrg.Left = 8.4375F;
            this.SupFt_AnnualOrderPriceOrg.MultiLine = false;
            this.SupFt_AnnualOrderPriceOrg.Name = "SupFt_AnnualOrderPriceOrg";
            this.SupFt_AnnualOrderPriceOrg.OutputFormat = resources.GetString("SupFt_AnnualOrderPriceOrg.OutputFormat");
            this.SupFt_AnnualOrderPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualOrderPriceOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualOrderPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualOrderPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualOrderPriceOrg.Text = "1,234,567,890";
            this.SupFt_AnnualOrderPriceOrg.Top = 0.656F;
            this.SupFt_AnnualOrderPriceOrg.Visible = false;
            this.SupFt_AnnualOrderPriceOrg.Width = 0.8F;
            // 
            // SupFt_PureTotalPriceSum
            // 
            this.SupFt_PureTotalPriceSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceSum.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceSum.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_PureTotalPriceSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureTotalPriceSum.DataField = "PureTotalPriceSum";
            this.SupFt_PureTotalPriceSum.Height = 0.156F;
            this.SupFt_PureTotalPriceSum.Left = 6F;
            this.SupFt_PureTotalPriceSum.MultiLine = false;
            this.SupFt_PureTotalPriceSum.Name = "SupFt_PureTotalPriceSum";
            this.SupFt_PureTotalPriceSum.OutputFormat = resources.GetString("SupFt_PureTotalPriceSum.OutputFormat");
            this.SupFt_PureTotalPriceSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_PureTotalPriceSum.Text = "1,234,567,890";
            this.SupFt_PureTotalPriceSum.Top = 0.8745F;
            this.SupFt_PureTotalPriceSum.Visible = false;
            this.SupFt_PureTotalPriceSum.Width = 0.8F;
            // 
            // SupFt_AnnualPureTotalPriceSum
            // 
            this.SupFt_AnnualPureTotalPriceSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceSum.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceSum.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureTotalPriceSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureTotalPriceSum.DataField = "AnnualPureTotalPriceSum";
            this.SupFt_AnnualPureTotalPriceSum.Height = 0.156F;
            this.SupFt_AnnualPureTotalPriceSum.Left = 6F;
            this.SupFt_AnnualPureTotalPriceSum.MultiLine = false;
            this.SupFt_AnnualPureTotalPriceSum.Name = "SupFt_AnnualPureTotalPriceSum";
            this.SupFt_AnnualPureTotalPriceSum.OutputFormat = resources.GetString("SupFt_AnnualPureTotalPriceSum.OutputFormat");
            this.SupFt_AnnualPureTotalPriceSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualPureTotalPriceSum.Text = "1,234,567,890";
            this.SupFt_AnnualPureTotalPriceSum.Top = 1.0625F;
            this.SupFt_AnnualPureTotalPriceSum.Visible = false;
            this.SupFt_AnnualPureTotalPriceSum.Width = 0.8F;
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
            this.Lb_Title1,
            this.Lb_Title2,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.line6});
            this.TitleHeader.Height = 0.3958333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_Title1
            // 
            this.Lb_Title1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Title1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Title1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Title1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Title1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title1.Height = 0.156F;
            this.Lb_Title1.HyperLink = "";
            this.Lb_Title1.Left = 0.063F;
            this.Lb_Title1.MultiLine = false;
            this.Lb_Title1.Name = "Lb_Title1";
            this.Lb_Title1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Title1.Text = "拠点";
            this.Lb_Title1.Top = 0.01F;
            this.Lb_Title1.Width = 0.4375F;
            // 
            // Lb_Title2
            // 
            this.Lb_Title2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Title2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Title2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Title2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Title2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title2.Height = 0.156F;
            this.Lb_Title2.HyperLink = "";
            this.Lb_Title2.Left = 0.375F;
            this.Lb_Title2.MultiLine = false;
            this.Lb_Title2.Name = "Lb_Title2";
            this.Lb_Title2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Title2.Text = "仕入先";
            this.Lb_Title2.Top = 0.188F;
            this.Lb_Title2.Width = 0.4375F;
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
            this.label5.Height = 0.156F;
            this.label5.HyperLink = "";
            this.label5.Left = 2.95F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "仕入";
            this.label5.Top = 0.188F;
            this.label5.Width = 0.4375F;
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
            this.label6.Height = 0.156F;
            this.label6.HyperLink = "";
            this.label6.Left = 3.875F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "返品";
            this.label6.Top = 0.188F;
            this.label6.Width = 0.4375F;
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
            this.label7.Height = 0.156F;
            this.label7.HyperLink = "";
            this.label7.Left = 5.425F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "値引";
            this.label7.Top = 0.188F;
            this.label7.Width = 0.4375F;
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
            this.label8.Height = 0.156F;
            this.label8.HyperLink = "";
            this.label8.Left = 6.3625F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "純仕入";
            this.label8.Top = 0.188F;
            this.label8.Width = 0.4375F;
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
            this.label9.Height = 0.156F;
            this.label9.HyperLink = "";
            this.label9.Left = 7.925F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "在庫額";
            this.label9.Top = 0.188F;
            this.label9.Width = 0.4375F;
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
            this.label10.Height = 0.156F;
            this.label10.HyperLink = "";
            this.label10.Left = 8.8F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "取寄額";
            this.label10.Top = 0.188F;
            this.label10.Width = 0.4375F;
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
            this.label11.Height = 0.156F;
            this.label11.HyperLink = "";
            this.label11.Left = 9.3375F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "在庫";
            this.label11.Top = 0.188F;
            this.label11.Width = 0.4375F;
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
            this.label12.Height = 0.156F;
            this.label12.HyperLink = "";
            this.label12.Left = 10.1075F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "取寄比";
            this.label12.Top = 0.188F;
            this.label12.Width = 0.4375F;
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
            this.label13.Height = 0.156F;
            this.label13.HyperLink = "";
            this.label13.Left = 9.9F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "/";
            this.label13.Top = 0.188F;
            this.label13.Width = 0.1F;
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
            this.label14.Height = 0.156F;
            this.label14.HyperLink = "";
            this.label14.Left = 6.92F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "構成比";
            this.label14.Top = 0.188F;
            this.label14.Width = 0.4375F;
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
            this.label15.Height = 0.156F;
            this.label15.HyperLink = "";
            this.label15.Left = 4.42F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "返品率";
            this.label15.Top = 0.188F;
            this.label15.Width = 0.4375F;
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
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.GraFt_TotalPrice,
            this.GraFt_RetGoodsPrice,
            this.GraFt_RetGoodsPriceRate,
            this.GraFt_TotalDiscount,
            this.GraFt_PureTotalPrice,
            this.GraFt_ConstUnitRate,
            this.GraFt_StockPrice,
            this.GraFt_OrderPrice,
            this.GraFt_StockPriceRate,
            this.GraFt_ySeparator,
            this.GraFt_OrderPriceRate,
            this.GraFt_AnnualTotalPrice,
            this.GraFt_AnnualRetGoodsPrice,
            this.GraFt_AnnualRetGoodsPriceRate,
            this.GraFt_AnnualTotalDiscount,
            this.GraFt_AnnualPureTotalPrice,
            this.GraFt_AnnualConstUnitRate,
            this.GraFt_AnnualStockPrice,
            this.GraFt_AnnualOrderPrice,
            this.GraFt_AnnualStockPriceRate,
            this.GraFt_dSeparator,
            this.GraFt_AnnualOrderPriceRate,
            this.GrandTotalTitle,
            this.line5,
            this.GraFt_TotalPriceOrg,
            this.GraFt_RetGoodsPriceOrg,
            this.GraFt_AnnualTotalPriceOrg,
            this.GraFt_AnnualRetGoodsPriceOrg,
            this.GraFt_StockPriceOrg,
            this.GraFt_OrderPriceOrg,
            this.GraFt_AnnualStockPriceOrg,
            this.GraFt_AnnualOrderPriceOrg,
            this.GraFt_PureTotalPriceOrg,
            this.GraFt_AnnualPureTotalPriceOrg});
            this.GrandTotalFooter.Height = 0.90625F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GraFt_TotalPrice
            // 
            this.GraFt_TotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_TotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_TotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_TotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_TotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPrice.DataField = "TotalPrice";
            this.GraFt_TotalPrice.Height = 0.156F;
            this.GraFt_TotalPrice.Left = 2.5625F;
            this.GraFt_TotalPrice.MultiLine = false;
            this.GraFt_TotalPrice.Name = "GraFt_TotalPrice";
            this.GraFt_TotalPrice.OutputFormat = resources.GetString("GraFt_TotalPrice.OutputFormat");
            this.GraFt_TotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_TotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_TotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_TotalPrice.Text = "1,234,567,890";
            this.GraFt_TotalPrice.Top = 0.0625F;
            this.GraFt_TotalPrice.Width = 0.8F;
            // 
            // GraFt_RetGoodsPrice
            // 
            this.GraFt_RetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPrice.DataField = "RetGoodsPrice";
            this.GraFt_RetGoodsPrice.Height = 0.156F;
            this.GraFt_RetGoodsPrice.Left = 3.5F;
            this.GraFt_RetGoodsPrice.MultiLine = false;
            this.GraFt_RetGoodsPrice.Name = "GraFt_RetGoodsPrice";
            this.GraFt_RetGoodsPrice.OutputFormat = resources.GetString("GraFt_RetGoodsPrice.OutputFormat");
            this.GraFt_RetGoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_RetGoodsPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_RetGoodsPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_RetGoodsPrice.Text = "1,234,567,890";
            this.GraFt_RetGoodsPrice.Top = 0.0625F;
            this.GraFt_RetGoodsPrice.Width = 0.8F;
            // 
            // GraFt_RetGoodsPriceRate
            // 
            this.GraFt_RetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceRate.Height = 0.156F;
            this.GraFt_RetGoodsPriceRate.Left = 4.4375F;
            this.GraFt_RetGoodsPriceRate.MultiLine = false;
            this.GraFt_RetGoodsPriceRate.Name = "GraFt_RetGoodsPriceRate";
            this.GraFt_RetGoodsPriceRate.OutputFormat = resources.GetString("GraFt_RetGoodsPriceRate.OutputFormat");
            this.GraFt_RetGoodsPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_RetGoodsPriceRate.Text = "100.00%";
            this.GraFt_RetGoodsPriceRate.Top = 0.0625F;
            this.GraFt_RetGoodsPriceRate.Width = 0.42F;
            // 
            // GraFt_TotalDiscount
            // 
            this.GraFt_TotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_TotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_TotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_TotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_TotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalDiscount.DataField = "TotalDiscount";
            this.GraFt_TotalDiscount.Height = 0.156F;
            this.GraFt_TotalDiscount.Left = 5.0625F;
            this.GraFt_TotalDiscount.MultiLine = false;
            this.GraFt_TotalDiscount.Name = "GraFt_TotalDiscount";
            this.GraFt_TotalDiscount.OutputFormat = resources.GetString("GraFt_TotalDiscount.OutputFormat");
            this.GraFt_TotalDiscount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_TotalDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_TotalDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_TotalDiscount.Text = "1,234,567,890";
            this.GraFt_TotalDiscount.Top = 0.0625F;
            this.GraFt_TotalDiscount.Width = 0.8F;
            // 
            // GraFt_PureTotalPrice
            // 
            this.GraFt_PureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPrice.DataField = "PureTotalPrice";
            this.GraFt_PureTotalPrice.Height = 0.156F;
            this.GraFt_PureTotalPrice.Left = 6F;
            this.GraFt_PureTotalPrice.MultiLine = false;
            this.GraFt_PureTotalPrice.Name = "GraFt_PureTotalPrice";
            this.GraFt_PureTotalPrice.OutputFormat = resources.GetString("GraFt_PureTotalPrice.OutputFormat");
            this.GraFt_PureTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_PureTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_PureTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_PureTotalPrice.Text = "1,234,567,890";
            this.GraFt_PureTotalPrice.Top = 0.0625F;
            this.GraFt_PureTotalPrice.Width = 0.8F;
            // 
            // GraFt_ConstUnitRate
            // 
            this.GraFt_ConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_ConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_ConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_ConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_ConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ConstUnitRate.Height = 0.156F;
            this.GraFt_ConstUnitRate.Left = 6.9375F;
            this.GraFt_ConstUnitRate.MultiLine = false;
            this.GraFt_ConstUnitRate.Name = "GraFt_ConstUnitRate";
            this.GraFt_ConstUnitRate.OutputFormat = resources.GetString("GraFt_ConstUnitRate.OutputFormat");
            this.GraFt_ConstUnitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_ConstUnitRate.Text = "100.00%";
            this.GraFt_ConstUnitRate.Top = 0.0625F;
            this.GraFt_ConstUnitRate.Width = 0.42F;
            // 
            // GraFt_StockPrice
            // 
            this.GraFt_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPrice.DataField = "StockPrice";
            this.GraFt_StockPrice.Height = 0.156F;
            this.GraFt_StockPrice.Left = 7.5625F;
            this.GraFt_StockPrice.MultiLine = false;
            this.GraFt_StockPrice.Name = "GraFt_StockPrice";
            this.GraFt_StockPrice.OutputFormat = resources.GetString("GraFt_StockPrice.OutputFormat");
            this.GraFt_StockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_StockPrice.Text = "1,234,567,890";
            this.GraFt_StockPrice.Top = 0.0625F;
            this.GraFt_StockPrice.Width = 0.8F;
            // 
            // GraFt_OrderPrice
            // 
            this.GraFt_OrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_OrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_OrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_OrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_OrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPrice.DataField = "OrderPrice";
            this.GraFt_OrderPrice.Height = 0.156F;
            this.GraFt_OrderPrice.Left = 8.4375F;
            this.GraFt_OrderPrice.MultiLine = false;
            this.GraFt_OrderPrice.Name = "GraFt_OrderPrice";
            this.GraFt_OrderPrice.OutputFormat = resources.GetString("GraFt_OrderPrice.OutputFormat");
            this.GraFt_OrderPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_OrderPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_OrderPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_OrderPrice.Text = "1,234,567,890";
            this.GraFt_OrderPrice.Top = 0.0625F;
            this.GraFt_OrderPrice.Width = 0.8F;
            // 
            // GraFt_StockPriceRate
            // 
            this.GraFt_StockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceRate.Height = 0.156F;
            this.GraFt_StockPriceRate.Left = 9.355F;
            this.GraFt_StockPriceRate.MultiLine = false;
            this.GraFt_StockPriceRate.Name = "GraFt_StockPriceRate";
            this.GraFt_StockPriceRate.OutputFormat = resources.GetString("GraFt_StockPriceRate.OutputFormat");
            this.GraFt_StockPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_StockPriceRate.Text = "100.00%";
            this.GraFt_StockPriceRate.Top = 0.0625F;
            this.GraFt_StockPriceRate.Width = 0.42F;
            // 
            // GraFt_ySeparator
            // 
            this.GraFt_ySeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_ySeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ySeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_ySeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ySeparator.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_ySeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ySeparator.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_ySeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_ySeparator.Height = 0.156F;
            this.GraFt_ySeparator.Left = 9.9F;
            this.GraFt_ySeparator.MultiLine = false;
            this.GraFt_ySeparator.Name = "GraFt_ySeparator";
            this.GraFt_ySeparator.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_ySeparator.Text = "/";
            this.GraFt_ySeparator.Top = 0.0625F;
            this.GraFt_ySeparator.Width = 0.1F;
            // 
            // GraFt_OrderPriceRate
            // 
            this.GraFt_OrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceRate.Height = 0.156F;
            this.GraFt_OrderPriceRate.Left = 10.125F;
            this.GraFt_OrderPriceRate.MultiLine = false;
            this.GraFt_OrderPriceRate.Name = "GraFt_OrderPriceRate";
            this.GraFt_OrderPriceRate.OutputFormat = resources.GetString("GraFt_OrderPriceRate.OutputFormat");
            this.GraFt_OrderPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_OrderPriceRate.Text = "100.00%";
            this.GraFt_OrderPriceRate.Top = 0.0625F;
            this.GraFt_OrderPriceRate.Width = 0.42F;
            // 
            // GraFt_AnnualTotalPrice
            // 
            this.GraFt_AnnualTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPrice.DataField = "AnnualTotalPrice";
            this.GraFt_AnnualTotalPrice.Height = 0.156F;
            this.GraFt_AnnualTotalPrice.Left = 2.5625F;
            this.GraFt_AnnualTotalPrice.MultiLine = false;
            this.GraFt_AnnualTotalPrice.Name = "GraFt_AnnualTotalPrice";
            this.GraFt_AnnualTotalPrice.OutputFormat = resources.GetString("GraFt_AnnualTotalPrice.OutputFormat");
            this.GraFt_AnnualTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualTotalPrice.Text = "1,234,567,890";
            this.GraFt_AnnualTotalPrice.Top = 0.25F;
            this.GraFt_AnnualTotalPrice.Width = 0.8F;
            // 
            // GraFt_AnnualRetGoodsPrice
            // 
            this.GraFt_AnnualRetGoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPrice.DataField = "AnnualRetGoodsPrice";
            this.GraFt_AnnualRetGoodsPrice.Height = 0.156F;
            this.GraFt_AnnualRetGoodsPrice.Left = 3.5F;
            this.GraFt_AnnualRetGoodsPrice.MultiLine = false;
            this.GraFt_AnnualRetGoodsPrice.Name = "GraFt_AnnualRetGoodsPrice";
            this.GraFt_AnnualRetGoodsPrice.OutputFormat = resources.GetString("GraFt_AnnualRetGoodsPrice.OutputFormat");
            this.GraFt_AnnualRetGoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualRetGoodsPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualRetGoodsPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualRetGoodsPrice.Text = "1,234,567,890";
            this.GraFt_AnnualRetGoodsPrice.Top = 0.25F;
            this.GraFt_AnnualRetGoodsPrice.Width = 0.8F;
            // 
            // GraFt_AnnualRetGoodsPriceRate
            // 
            this.GraFt_AnnualRetGoodsPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceRate.Height = 0.156F;
            this.GraFt_AnnualRetGoodsPriceRate.Left = 4.4375F;
            this.GraFt_AnnualRetGoodsPriceRate.MultiLine = false;
            this.GraFt_AnnualRetGoodsPriceRate.Name = "GraFt_AnnualRetGoodsPriceRate";
            this.GraFt_AnnualRetGoodsPriceRate.OutputFormat = resources.GetString("GraFt_AnnualRetGoodsPriceRate.OutputFormat");
            this.GraFt_AnnualRetGoodsPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualRetGoodsPriceRate.Text = "100.00%";
            this.GraFt_AnnualRetGoodsPriceRate.Top = 0.25F;
            this.GraFt_AnnualRetGoodsPriceRate.Width = 0.42F;
            // 
            // GraFt_AnnualTotalDiscount
            // 
            this.GraFt_AnnualTotalDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalDiscount.DataField = "AnnualTotalDiscount";
            this.GraFt_AnnualTotalDiscount.Height = 0.156F;
            this.GraFt_AnnualTotalDiscount.Left = 5.0625F;
            this.GraFt_AnnualTotalDiscount.MultiLine = false;
            this.GraFt_AnnualTotalDiscount.Name = "GraFt_AnnualTotalDiscount";
            this.GraFt_AnnualTotalDiscount.OutputFormat = resources.GetString("GraFt_AnnualTotalDiscount.OutputFormat");
            this.GraFt_AnnualTotalDiscount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualTotalDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualTotalDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualTotalDiscount.Text = "1,234,567,890";
            this.GraFt_AnnualTotalDiscount.Top = 0.25F;
            this.GraFt_AnnualTotalDiscount.Width = 0.8F;
            // 
            // GraFt_AnnualPureTotalPrice
            // 
            this.GraFt_AnnualPureTotalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPrice.DataField = "AnnualPureTotalPrice";
            this.GraFt_AnnualPureTotalPrice.Height = 0.156F;
            this.GraFt_AnnualPureTotalPrice.Left = 6F;
            this.GraFt_AnnualPureTotalPrice.MultiLine = false;
            this.GraFt_AnnualPureTotalPrice.Name = "GraFt_AnnualPureTotalPrice";
            this.GraFt_AnnualPureTotalPrice.OutputFormat = resources.GetString("GraFt_AnnualPureTotalPrice.OutputFormat");
            this.GraFt_AnnualPureTotalPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualPureTotalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualPureTotalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualPureTotalPrice.Text = "1,234,567,890";
            this.GraFt_AnnualPureTotalPrice.Top = 0.25F;
            this.GraFt_AnnualPureTotalPrice.Width = 0.8F;
            // 
            // GraFt_AnnualConstUnitRate
            // 
            this.GraFt_AnnualConstUnitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualConstUnitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualConstUnitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualConstUnitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualConstUnitRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualConstUnitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualConstUnitRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualConstUnitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualConstUnitRate.Height = 0.156F;
            this.GraFt_AnnualConstUnitRate.Left = 6.9375F;
            this.GraFt_AnnualConstUnitRate.MultiLine = false;
            this.GraFt_AnnualConstUnitRate.Name = "GraFt_AnnualConstUnitRate";
            this.GraFt_AnnualConstUnitRate.OutputFormat = resources.GetString("GraFt_AnnualConstUnitRate.OutputFormat");
            this.GraFt_AnnualConstUnitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualConstUnitRate.Text = "100.00%";
            this.GraFt_AnnualConstUnitRate.Top = 0.25F;
            this.GraFt_AnnualConstUnitRate.Width = 0.42F;
            // 
            // GraFt_AnnualStockPrice
            // 
            this.GraFt_AnnualStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPrice.DataField = "AnnualStockPrice";
            this.GraFt_AnnualStockPrice.Height = 0.156F;
            this.GraFt_AnnualStockPrice.Left = 7.5625F;
            this.GraFt_AnnualStockPrice.MultiLine = false;
            this.GraFt_AnnualStockPrice.Name = "GraFt_AnnualStockPrice";
            this.GraFt_AnnualStockPrice.OutputFormat = resources.GetString("GraFt_AnnualStockPrice.OutputFormat");
            this.GraFt_AnnualStockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualStockPrice.Text = "1,234,567,890";
            this.GraFt_AnnualStockPrice.Top = 0.25F;
            this.GraFt_AnnualStockPrice.Width = 0.8F;
            // 
            // GraFt_AnnualOrderPrice
            // 
            this.GraFt_AnnualOrderPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPrice.DataField = "AnnualOrderPrice";
            this.GraFt_AnnualOrderPrice.Height = 0.156F;
            this.GraFt_AnnualOrderPrice.Left = 8.4375F;
            this.GraFt_AnnualOrderPrice.MultiLine = false;
            this.GraFt_AnnualOrderPrice.Name = "GraFt_AnnualOrderPrice";
            this.GraFt_AnnualOrderPrice.OutputFormat = resources.GetString("GraFt_AnnualOrderPrice.OutputFormat");
            this.GraFt_AnnualOrderPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualOrderPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualOrderPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualOrderPrice.Text = "1,234,567,890";
            this.GraFt_AnnualOrderPrice.Top = 0.25F;
            this.GraFt_AnnualOrderPrice.Width = 0.8F;
            // 
            // GraFt_AnnualStockPriceRate
            // 
            this.GraFt_AnnualStockPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceRate.Height = 0.156F;
            this.GraFt_AnnualStockPriceRate.Left = 9.355F;
            this.GraFt_AnnualStockPriceRate.MultiLine = false;
            this.GraFt_AnnualStockPriceRate.Name = "GraFt_AnnualStockPriceRate";
            this.GraFt_AnnualStockPriceRate.OutputFormat = resources.GetString("GraFt_AnnualStockPriceRate.OutputFormat");
            this.GraFt_AnnualStockPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualStockPriceRate.Text = "100.00%";
            this.GraFt_AnnualStockPriceRate.Top = 0.25F;
            this.GraFt_AnnualStockPriceRate.Width = 0.42F;
            // 
            // GraFt_dSeparator
            // 
            this.GraFt_dSeparator.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_dSeparator.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dSeparator.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_dSeparator.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dSeparator.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_dSeparator.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dSeparator.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_dSeparator.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dSeparator.Height = 0.156F;
            this.GraFt_dSeparator.Left = 9.9F;
            this.GraFt_dSeparator.MultiLine = false;
            this.GraFt_dSeparator.Name = "GraFt_dSeparator";
            this.GraFt_dSeparator.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_dSeparator.Text = "/";
            this.GraFt_dSeparator.Top = 0.25F;
            this.GraFt_dSeparator.Width = 0.1F;
            // 
            // GraFt_AnnualOrderPriceRate
            // 
            this.GraFt_AnnualOrderPriceRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceRate.Height = 0.156F;
            this.GraFt_AnnualOrderPriceRate.Left = 10.125F;
            this.GraFt_AnnualOrderPriceRate.MultiLine = false;
            this.GraFt_AnnualOrderPriceRate.Name = "GraFt_AnnualOrderPriceRate";
            this.GraFt_AnnualOrderPriceRate.OutputFormat = resources.GetString("GraFt_AnnualOrderPriceRate.OutputFormat");
            this.GraFt_AnnualOrderPriceRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualOrderPriceRate.Text = "100.00%";
            this.GraFt_AnnualOrderPriceRate.Top = 0.25F;
            this.GraFt_AnnualOrderPriceRate.Width = 0.42F;
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
            this.GrandTotalTitle.Height = 0.25F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 1.875F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.0625F;
            this.GrandTotalTitle.Width = 0.5625F;
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
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // GraFt_TotalPriceOrg
            // 
            this.GraFt_TotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_TotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_TotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_TotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_TotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_TotalPriceOrg.DataField = "TotalPriceOrg";
            this.GraFt_TotalPriceOrg.Height = 0.156F;
            this.GraFt_TotalPriceOrg.Left = 2.5625F;
            this.GraFt_TotalPriceOrg.MultiLine = false;
            this.GraFt_TotalPriceOrg.Name = "GraFt_TotalPriceOrg";
            this.GraFt_TotalPriceOrg.OutputFormat = resources.GetString("GraFt_TotalPriceOrg.OutputFormat");
            this.GraFt_TotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_TotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_TotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_TotalPriceOrg.Text = "1,234,567,890";
            this.GraFt_TotalPriceOrg.Top = 0.4685F;
            this.GraFt_TotalPriceOrg.Visible = false;
            this.GraFt_TotalPriceOrg.Width = 0.8F;
            // 
            // GraFt_RetGoodsPriceOrg
            // 
            this.GraFt_RetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_RetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_RetGoodsPriceOrg.DataField = "RetGoodsPriceOrg";
            this.GraFt_RetGoodsPriceOrg.Height = 0.156F;
            this.GraFt_RetGoodsPriceOrg.Left = 3.5F;
            this.GraFt_RetGoodsPriceOrg.MultiLine = false;
            this.GraFt_RetGoodsPriceOrg.Name = "GraFt_RetGoodsPriceOrg";
            this.GraFt_RetGoodsPriceOrg.OutputFormat = resources.GetString("GraFt_RetGoodsPriceOrg.OutputFormat");
            this.GraFt_RetGoodsPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_RetGoodsPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_RetGoodsPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_RetGoodsPriceOrg.Text = "1,234,567,890";
            this.GraFt_RetGoodsPriceOrg.Top = 0.4685F;
            this.GraFt_RetGoodsPriceOrg.Visible = false;
            this.GraFt_RetGoodsPriceOrg.Width = 0.8F;
            // 
            // GraFt_AnnualTotalPriceOrg
            // 
            this.GraFt_AnnualTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualTotalPriceOrg.DataField = "AnnualTotalPriceOrg";
            this.GraFt_AnnualTotalPriceOrg.Height = 0.156F;
            this.GraFt_AnnualTotalPriceOrg.Left = 2.5625F;
            this.GraFt_AnnualTotalPriceOrg.MultiLine = false;
            this.GraFt_AnnualTotalPriceOrg.Name = "GraFt_AnnualTotalPriceOrg";
            this.GraFt_AnnualTotalPriceOrg.OutputFormat = resources.GetString("GraFt_AnnualTotalPriceOrg.OutputFormat");
            this.GraFt_AnnualTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualTotalPriceOrg.Text = "1,234,567,890";
            this.GraFt_AnnualTotalPriceOrg.Top = 0.656F;
            this.GraFt_AnnualTotalPriceOrg.Visible = false;
            this.GraFt_AnnualTotalPriceOrg.Width = 0.8F;
            // 
            // GraFt_AnnualRetGoodsPriceOrg
            // 
            this.GraFt_AnnualRetGoodsPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualRetGoodsPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualRetGoodsPriceOrg.DataField = "AnnualRetGoodsPriceOrg";
            this.GraFt_AnnualRetGoodsPriceOrg.Height = 0.156F;
            this.GraFt_AnnualRetGoodsPriceOrg.Left = 3.5F;
            this.GraFt_AnnualRetGoodsPriceOrg.MultiLine = false;
            this.GraFt_AnnualRetGoodsPriceOrg.Name = "GraFt_AnnualRetGoodsPriceOrg";
            this.GraFt_AnnualRetGoodsPriceOrg.OutputFormat = resources.GetString("GraFt_AnnualRetGoodsPriceOrg.OutputFormat");
            this.GraFt_AnnualRetGoodsPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualRetGoodsPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualRetGoodsPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualRetGoodsPriceOrg.Text = "1,234,567,890";
            this.GraFt_AnnualRetGoodsPriceOrg.Top = 0.656F;
            this.GraFt_AnnualRetGoodsPriceOrg.Visible = false;
            this.GraFt_AnnualRetGoodsPriceOrg.Width = 0.8F;
            // 
            // GraFt_StockPriceOrg
            // 
            this.GraFt_StockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_StockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_StockPriceOrg.DataField = "StockPriceOrg";
            this.GraFt_StockPriceOrg.Height = 0.156F;
            this.GraFt_StockPriceOrg.Left = 7.5625F;
            this.GraFt_StockPriceOrg.MultiLine = false;
            this.GraFt_StockPriceOrg.Name = "GraFt_StockPriceOrg";
            this.GraFt_StockPriceOrg.OutputFormat = resources.GetString("GraFt_StockPriceOrg.OutputFormat");
            this.GraFt_StockPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_StockPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_StockPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_StockPriceOrg.Text = "1,234,567,890";
            this.GraFt_StockPriceOrg.Top = 0.4685F;
            this.GraFt_StockPriceOrg.Visible = false;
            this.GraFt_StockPriceOrg.Width = 0.8F;
            // 
            // GraFt_OrderPriceOrg
            // 
            this.GraFt_OrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_OrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_OrderPriceOrg.DataField = "OrderPriceOrg";
            this.GraFt_OrderPriceOrg.Height = 0.156F;
            this.GraFt_OrderPriceOrg.Left = 8.4375F;
            this.GraFt_OrderPriceOrg.MultiLine = false;
            this.GraFt_OrderPriceOrg.Name = "GraFt_OrderPriceOrg";
            this.GraFt_OrderPriceOrg.OutputFormat = resources.GetString("GraFt_OrderPriceOrg.OutputFormat");
            this.GraFt_OrderPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_OrderPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_OrderPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_OrderPriceOrg.Text = "1,234,567,890";
            this.GraFt_OrderPriceOrg.Top = 0.4685F;
            this.GraFt_OrderPriceOrg.Visible = false;
            this.GraFt_OrderPriceOrg.Width = 0.8F;
            // 
            // GraFt_AnnualStockPriceOrg
            // 
            this.GraFt_AnnualStockPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualStockPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualStockPriceOrg.DataField = "AnnualStockPriceOrg";
            this.GraFt_AnnualStockPriceOrg.Height = 0.156F;
            this.GraFt_AnnualStockPriceOrg.Left = 7.5625F;
            this.GraFt_AnnualStockPriceOrg.MultiLine = false;
            this.GraFt_AnnualStockPriceOrg.Name = "GraFt_AnnualStockPriceOrg";
            this.GraFt_AnnualStockPriceOrg.OutputFormat = resources.GetString("GraFt_AnnualStockPriceOrg.OutputFormat");
            this.GraFt_AnnualStockPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualStockPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualStockPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualStockPriceOrg.Text = "1,234,567,890";
            this.GraFt_AnnualStockPriceOrg.Top = 0.656F;
            this.GraFt_AnnualStockPriceOrg.Visible = false;
            this.GraFt_AnnualStockPriceOrg.Width = 0.8F;
            // 
            // GraFt_AnnualOrderPriceOrg
            // 
            this.GraFt_AnnualOrderPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualOrderPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualOrderPriceOrg.DataField = "AnnualOrderPriceOrg";
            this.GraFt_AnnualOrderPriceOrg.Height = 0.156F;
            this.GraFt_AnnualOrderPriceOrg.Left = 8.4375F;
            this.GraFt_AnnualOrderPriceOrg.MultiLine = false;
            this.GraFt_AnnualOrderPriceOrg.Name = "GraFt_AnnualOrderPriceOrg";
            this.GraFt_AnnualOrderPriceOrg.OutputFormat = resources.GetString("GraFt_AnnualOrderPriceOrg.OutputFormat");
            this.GraFt_AnnualOrderPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualOrderPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualOrderPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualOrderPriceOrg.Text = "1,234,567,890";
            this.GraFt_AnnualOrderPriceOrg.Top = 0.656F;
            this.GraFt_AnnualOrderPriceOrg.Visible = false;
            this.GraFt_AnnualOrderPriceOrg.Width = 0.8F;
            // 
            // GraFt_PureTotalPriceOrg
            // 
            this.GraFt_PureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_PureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_PureTotalPriceOrg.DataField = "PureTotalPriceOrg";
            this.GraFt_PureTotalPriceOrg.Height = 0.156F;
            this.GraFt_PureTotalPriceOrg.Left = 6F;
            this.GraFt_PureTotalPriceOrg.MultiLine = false;
            this.GraFt_PureTotalPriceOrg.Name = "GraFt_PureTotalPriceOrg";
            this.GraFt_PureTotalPriceOrg.OutputFormat = resources.GetString("GraFt_PureTotalPriceOrg.OutputFormat");
            this.GraFt_PureTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_PureTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_PureTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_PureTotalPriceOrg.Text = "1,234,567,890";
            this.GraFt_PureTotalPriceOrg.Top = 0.4685F;
            this.GraFt_PureTotalPriceOrg.Visible = false;
            this.GraFt_PureTotalPriceOrg.Width = 0.8F;
            // 
            // GraFt_AnnualPureTotalPriceOrg
            // 
            this.GraFt_AnnualPureTotalPriceOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPriceOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPriceOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPriceOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPriceOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPriceOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPriceOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_AnnualPureTotalPriceOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_AnnualPureTotalPriceOrg.DataField = "AnnualPureTotalPriceOrg";
            this.GraFt_AnnualPureTotalPriceOrg.Height = 0.156F;
            this.GraFt_AnnualPureTotalPriceOrg.Left = 6F;
            this.GraFt_AnnualPureTotalPriceOrg.MultiLine = false;
            this.GraFt_AnnualPureTotalPriceOrg.Name = "GraFt_AnnualPureTotalPriceOrg";
            this.GraFt_AnnualPureTotalPriceOrg.OutputFormat = resources.GetString("GraFt_AnnualPureTotalPriceOrg.OutputFormat");
            this.GraFt_AnnualPureTotalPriceOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_AnnualPureTotalPriceOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_AnnualPureTotalPriceOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_AnnualPureTotalPriceOrg.Text = "1,234,567,890";
            this.GraFt_AnnualPureTotalPriceOrg.Top = 0.656F;
            this.GraFt_AnnualPureTotalPriceOrg.Visible = false;
            this.GraFt_AnnualPureTotalPriceOrg.Width = 0.8F;
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
            // PMKOU02023P_01A4C
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
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.SupplierFooter);
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
            this.ReportStart += new System.EventHandler(this.PMKOU02023P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualRetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualRetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualPureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualOrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualStockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualOrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualRetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDiscountOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalDiscountOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualPureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualStockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualOrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureTotalPriceSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualPureTotalPriceSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_RetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_RetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_ConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_OrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_StockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_ySeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_OrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualRetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualRetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualOrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualStockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_dSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualOrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_RetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualRetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalDiscountOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualTotalDiscountOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_StockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_OrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualStockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualOrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureTotalPriceSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureTotalPriceSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SuplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SuplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_RetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_RetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_ConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_ySeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualRetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualRetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualOrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualStockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_dSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualOrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_RetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualRetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalDiscountOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualTotalDiscountOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualStockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualOrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureTotalPriceSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureTotalPriceSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_TotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_RetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_RetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_TotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_PureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_ConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_OrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_StockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_ySeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_OrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualRetGoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualRetGoodsPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualTotalDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualPureTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualConstUnitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualOrderPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualStockPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_dSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualOrderPriceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_TotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_RetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualRetGoodsPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_StockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_OrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualStockPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualOrderPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_PureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_AnnualPureTotalPriceOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion


    }
}
