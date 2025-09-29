//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上月報年報
// プログラム概要   : 売上月報年報の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/12/04  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/12/08  修正内容 : 拠点ラベルの表示・非表示制御追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/01/23  修正内容 : 障害対応8832（帳票フッタを実装）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/02/06  修正内容 : 障害対応10943,10971,11113（拠点計の売上目標取得処理を追加）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/03/24  修正内容 : 障害対応12682
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/09  修正内容 : 障害対応13403
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh  
// 修 正 日  2012/12/28  修正内容 : 2013/03/13配信分 
//                                  Redmine#34098 罫線印字制御を追加する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : duzg
// 修 正 日  2013/07/26  修正内容 : 2013/06/18配信分
//                                  redmine #38722
//                                 ・No.6得意先順の場合、明細と小計の売上・粗利目標値は印字不正
//----------------------------------------------------------------------------//
using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 売上月報年報印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上月報年報のフォームクラスです。</br>
    /// <br>Programmer  : 980035 金沢　貞義</br>
    /// <br>Date	    : 2007.12.07</br>
    /// <br>Update Note : 2008.03.05 980035 金沢 貞義</br>
    /// <br>			  ・不具合修正（DC.NS対応）</br>
    /// <br>Update Note : 2008.12.04 30452 上野 俊治</br>
    /// <br>			  ・不具合修正（PM.NS対応）</br>
    /// <br>Update Note : 2008.12.08 30452 上野 俊治</br>
    /// <br>			  ・拠点ラベルの表示・非表示制御追加</br>
    /// <br>Update Note : 2009.01.23 30452 上野 俊治</br>
    /// <br>			  ・障害対応8832（帳票フッタを実装）</br>
    /// <br>Update Note : 2009.02.06 30452 上野 俊治</br>
    /// <br>			  ・障害対応10943,10971,11113（拠点計の売上目標取得処理を追加）</br>
    /// <br>Update Note : 2009/03/24 30452 上野 俊治</br>
    /// <br>			  ・障害対応12682</br>
    /// <br>UpdateNote  : 2012/12/28 zhuhh</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>            : redmine #34098 罫線印字制御を追加する</br>
    /// <br>UpdateNote  : 2013/07/26 duzg</br>
    /// <br>管理番号    : 10801804-00 2013/06/18配信分</br>
    /// <br>            : redmine #38722 </br>
    /// <br>            : ・No.6得意先順の場合、明細と小計の売上・粗利目標値は印字不正</br>
    /// </remarks>
    public class DCHNB02072P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        /// <summary>
        /// 売上月報年報フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 売上月報年報フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
        public DCHNB02072P_01A4C()
        {
            InitializeComponent();
        }

        #region Private Member
        private string _pageHeaderSortOderTitle;		// ソート順
        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;				// 抽出条件
        private int _pageFooterOutCode;			// フッター出力区分
        private StringCollection _pageFooters;					// フッターメッセージ
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private string _pageHeaderSubtitle;			// フォームサブタイトル
        private ArrayList _otherDataList;				// その他データ

        private SalesMonthYearReportCndtn _extrInfo;                // 抽出条件クラス

        // その他データ格納項目		
        private int _printCount;					// ページ数カウント用

        // ヘッダーサブレポート作成
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート作成
        ListCommon_PageFooter _rptPageFooter = null;
        private TextBox SalesTtlPrice_TextBox;
        private TextBox RetGoodsTtlPrice_TextBox;
        private TextBox DiscountTtlPrice_TextBox;
        private TextBox PureSalesTtlPrice_TextBox;
        private TextBox RetGoodsTtlRate_TextBox;
        private Label RecordTitle;
        private Label Label8;
        private Label Label9;
        private Label Label17;
        private Label Label;
        private Label label4;
        private Label TargetMoneyRate_Title;
        private TextBox GrandSalesTtlPrice_TextBox;
        private TextBox GrandRetGoodsTtlPrice_TextBox;
        private TextBox GrandDiscountTtlPrice_TextBox;
        private TextBox GrandPureSalesTtlPrice_TextBox;
        private TextBox GrandRetGoodsTtlRate_TextBox;
        private TextBox SectionAnSalesTtlPrice_TextBox;
        private TextBox SectionAnRetGoodsTtlPrice_TextBox;
        private TextBox SectionAnDiscountTtlPrice_TextBox;
        private TextBox SectionAnPureSalesTtlPrice_TextBox;
        private TextBox SectionAnRetGoodsTtlRate_TextBox;
        private Label SectionHeaderT;
        private TextBox SectionCode;
        private TextBox SectionName; // detailの2つめの項目(数値表示用)
        private TextBox RecordName_TextBox;
        private TextBox AnSalesTtlPrice_TextBox;
        private TextBox AnRetGoodsTtlPrice_TextBox;
        private TextBox AnDiscountTtlPrice_TextBox;
        private TextBox AnPureSalesTtlPrice_TextBox;
        private TextBox AnRetGoodsTtlRate_TextBox;
        private TextBox SectionSalesTtlPrice_TextBox;
        private TextBox SectionRetGoodsTtlPrice_TextBox;
        private TextBox SectionDiscountTtlPrice_TextBox;
        private TextBox SectionPureSalesTtlPrice_TextBox;
        private TextBox SectionRetGoodsTtlRate_TextBox;
        private TextBox GrandAnSalesTtlPrice_TextBox;
        private TextBox GrandAnRetGoodsTtlPrice_TextBox;
        private TextBox GrandAnDiscountTtlPrice_TextBox;
        private TextBox GrandAnPureSalesTtlPrice_TextBox;
        private TextBox GrandAnRetGoodsTtlRate_TextBox;
        private GroupHeader ReportHeader;
        private GroupFooter ReportFooter;
        private TextBox MinAnSalesTtlPrice_TextBox;
        private TextBox MinAnRetGoodsTtlPrice_TextBox;
        private TextBox MinAnDiscountTtlPrice_TextBox;
        private TextBox MinAnPureSalesTtlPrice_TextBox;
        private TextBox MinAnRetGoodsTtlRate_TextBox;
        private TextBox MinSalesTtlPrice_TextBox;
        private TextBox MinRetGoodsTtlPrice_TextBox;
        private TextBox MinDiscountTtlPrice_TextBox;
        private TextBox MinPureSalesTtlPrice_TextBox;
        private TextBox MinRetGoodsTtlRate_TextBox;
        private TextBox MinTotal_Title; // xx計(小計)
        private Label label1;
        private TextBox TargetMoneyRate_TextBox;
        private TextBox AnTargetMoneyRate_TextBox;
        private TextBox CmpPureSalesRatio_TextBox;
        private TextBox AnCmpPureSalesRatio_TextBox;
        private TextBox MinTargetMoneyRate_TextBox;
        private TextBox GrandTargetMoneyRate_TextBox;
        private TextBox GrandCmpPureSalesRatio_TextBox;
        private TextBox GrandAnTargetMoneyRate_TextBox;
        private TextBox GrandAnCmpPureSalesRatio_TextBox;
        private TextBox SectionTargetMoneyRate_TextBox;
        private TextBox SectionCmpPureSalesRatio_TextBox;
        private TextBox SectionAnTargetMoneyRate_TextBox;
        private TextBox SectionAnCmpPureSalesRatio_TextBox;
        private TextBox MinAnTargetMoneyRate_TextBox;
        private TextBox MinCmpPureSalesRatio_TextBox;
        private TextBox MinAnCmpPureSalesRatio_TextBox;
        private Line line2;
        private TextBox MinPureSalesTtlWork_TextBox;
        private TextBox MinAnPureSalesTtlWork_TextBox;
        private TextBox GrandPureSalesTtlWork_TextBox;
        private TextBox GrandAnPureSalesTtlWork_TextBox;
        private TextBox SectionPureSalesTtlWork_TextBox;
        private TextBox SectionAnPureSalesTtlWork_TextBox;
        private Label TargetMoney_Title;
        private Label label7;
        private Label TargetProfit_Title;
        private Label TargetProfitRate_Title;
        private Label label12;
        private Label label13;
        private TextBox TargetProfitRate_TextBox;
        private TextBox AnTargetProfitRate_TextBox;
        private TextBox CmpProfitRatio_TextBox;
        private TextBox AnCmpProfitRatio_TextBox;
        private TextBox GrandTargetProfitRate_TextBox;
        private TextBox GrandCmpProfitRatio_TextBox;
        private TextBox GrandAnTargetProfitRate_TextBox;
        private TextBox GrandAnCmpProfitRatio_TextBox;
        private TextBox SectionTargetProfitRate_TextBox;
        private TextBox SectionCmpProfitRatio_TextBox;
        private TextBox SectionAnTargetProfitRate_TextBox;
        private TextBox SectionAnCmpProfitRatio_TextBox;
        private TextBox MinTargetProfitRate_TextBox;
        private TextBox MinAnTargetProfitRate_TextBox;
        private TextBox MinCmpProfitRatio_TextBox;
        private TextBox MinAnCmpProfitRatio_TextBox;
        private TextBox TargetMoney_TextBox;
        private TextBox AnTargetMoney_TextBox;
        private TextBox GrandTargetMoney_TextBox;
        private TextBox GrandAnTargetMoney_TextBox;
        private TextBox SectionAnTargetMoney_TextBox;
        private TextBox SectionTargetMoney_TextBox;
        private TextBox MinAnTargetMoney_TextBox;
        private TextBox MinTargetMoney_TextBox;
        private TextBox GrossProfitPrice_TextBox;
        private TextBox AnGrossProfitPrice_TextBox;
        private TextBox TargetProfit_TextBox;
        private TextBox AnTargetProfit_TextBox;
        private TextBox GrandAnGrossProfitPrice_TextBox;
        private TextBox GrandGrossProfitPrice_TextBox;
        private TextBox GrandAnTargetProfit_TextBox;
        private TextBox GrandTargetProfit_TextBox;
        private TextBox SectionAnGrossProfitPrice_TextBox;
        private TextBox SectionGrossProfitPrice_TextBox;
        private TextBox SectionAnTargetProfit_TextBox;
        private TextBox SectionTargetProfit_TextBox;
        private TextBox MinGrossProfitPrice_TextBox;
        private TextBox MinAnGrossProfitPrice_TextBox;
        private TextBox MinTargetProfit_TextBox;
        private TextBox MinAnTargetProfit_TextBox;
        private TextBox GrossProfitRate_TextBox;
        private TextBox AnGrossProfitRate_TextBox;
        private TextBox GrandGrossProfitRate_TextBox;
        private TextBox GrandAnGrossProfitRate_TextBox;
        private TextBox SectionGrossProfitRate_TextBox;
        private TextBox SectionAnGrossProfitRate_TextBox;
        private TextBox MinGrossProfitRate_TextBox;
        private TextBox MinAnGrossProfitRate_TextBox;
        private TextBox GrandGrossProfitWork_TextBox;
        private TextBox GrandAnGrossProfitWork_TextBox;
        private TextBox SectionGrossProfitWork_TextBox;
        private TextBox SectionAnGrossProfitWork_TextBox;
        private TextBox MinGrossProfitWork_TextBox;
        private TextBox MinAnGrossProfitWork_TextBox;
        private TextBox RecordCode_TextBox; // detailの2つめの項目(文字表示用)
        private TextBox Order_TextBox;
        private Label label5;
        private TextBox ReportCodeName;
        private TextBox ReportCode;
        private Label ReportHeaderTitle;
        private TextBox ReportSectionName;
        private TextBox ReportSectionCode;
        private Label ReportSectionTitle;
        private TextBox ReportCodeN;
        private Line Line_PageFooter;
        private TextBox PageFooters0;
        private TextBox PageFooters1;

        // Disposeチェック用フラグ
        bool disposed = false;

        #endregion PrivateMembers

        #region Dispose(override)
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
        #endregion

        #region Public Property
        #region IPrintActiveReportTypeList メンバ
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
                this._extrInfo = (SalesMonthYearReportCndtn)this._printInfo.jyoken;
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
        ///	印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion
        #region IPrintActiveReportTypeCommon メンバ

        /// <summary>
        /// 背景透過設定値プロパティ
        /// </summary>
        public int WatermarkMode
        {
            get { return 0; }
            set { }
        }

        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// <br>UpdateNote  : 2012/12/28 zhuhh</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : redmine #34098 罫線印字制御を追加する</br>
        /// <br>UpdateNote  : 2013/07/26 duzg</br>
        /// <br>管理番号    : 10801804-00 2013/06/18配信分</br>
        /// <br>            : redmine #38722</br>
        /// <br>            : ・No.6得意先順の場合、明細と小計の売上・粗利目標値は印字不正</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            // --- DEL 2008/09/08 -------------------------------->>>>>
            // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
            System.Drawing.PointF location = new System.Drawing.PointF();
            //System.Drawing.SizeF size = new System.Drawing.SizeF();
            // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<
            // --- DEL 2008/09/08 --------------------------------<<<<<

            // 拠点別の時は、拠点計レコードは出力しない
            //--- DEL 2008.08.14 ---------->>>>>
            //if (this._extrInfo.TotalType == 0)
            //{
            //    SectionHeader.DataField = "";
            //    SectionHeader.Height = 0F;
            //    SectionFooter.Height = 0F;
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}
            //else
            //{
            //    SectionHeader.DataField = DCHNB02074EA.CT_MiniTotal_KeyBleak;
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = true;
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            if (this._extrInfo.PrintingPattern == 1)
            {
                SectionHeader.DataField = "";
                SectionHeader.Height = 0F;
                SectionFooter.Height = 0F;
                SectionHeader.Visible = false;
                SectionFooter.Visible = false;
            }
            else
            {
                SectionHeader.DataField = DCHNB02074EA.CT_MiniTotal_KeyBleak;
                SectionHeader.Visible = true;
                SectionFooter.Visible = true;
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */

            //--- ADD 2008.08.14 ----------<<<<<

            #region 集計単位制御（小計）
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
            // コード表示形式を変更
            size.Width = MinTotalCode.Size.Width - 0.25F - 0.125F;
            size.Height = MinTotalCode.Size.Height;
            location.X = MinTotalName.Location.X - 0.25F - 0.125F;
            location.Y = MinTotalName.Location.Y;
            // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<

            // 集計単位制御（SortDiv1 小計）
            switch (this._extrInfo.TotalType)
            {
                case SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                    {
                        if (this._extrInfo.PrintingPattern == 2) // 得意先-拠点
                        {
                            SortDiv1Footer.Visible = true;
                            MinTotal_Title.Visible = true;
                            MinTotal_Title.Text = "得意先計";

                            SortDiv1Header.DataField = DCHNB02074EA.CT_CustomerCode;
                            SortDiv1Header.Visible = true;

                            MinTotalHeaderTitle.Visible = false;
                            MinTotalCode.Visible = false;
                            MinTotalName.Visible = false;

                            SectionHeader.Visible = false;
                            SectionFooter.Visible = false;
                        }
                        break;
                    }
                case 2:
                    {
                        // 2:地区別得意先別
                        SortDiv1Header.DataField = DCHNB02074EA.CT_SalesAreaCode;
                        SortDiv1Header.Visible = true;
                        SortDiv1Footer.Visible = true;
                        MinTotal_Title.Visible = true;
                        MinTotal_Title.Text = "地区計";

                        MinTotalHeaderTitle.Visible = true;
                        MinTotalHeaderTitle.Text = "地区";
                        MinTotalCode.Visible = true;
                        MinTotalCode.DataField = DCHNB02074EA.CT_SalesAreaCode;
                        MinTotalCode.Alignment = TextAlignment.Right;
                        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                        MinTotalCode.OutputFormat = "00";
                        MinTotalCode.Size = size;
                        MinTotalName.Location = location;
                        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                        MinTotalName.Visible = true;
                        MinTotalName.DataField = DCHNB02074EA.CT_SalesAreaName;
                        break;
                    }
                case 3:
                    {
                        // 3:業種別得意先別
                        SortDiv1Header.DataField = DCHNB02074EA.CT_BusinessTypeCode;
                        SortDiv1Header.Visible = true;
                        SortDiv1Footer.Visible = true;
                        MinTotal_Title.Visible = true;
                        MinTotal_Title.Text = "業種計";

                        MinTotalHeaderTitle.Visible = true;
                        MinTotalHeaderTitle.Text = "業種";
                        MinTotalCode.Visible = true;
                        MinTotalCode.DataField = DCHNB02074EA.CT_BusinessTypeCode;
                        MinTotalCode.Alignment = TextAlignment.Right;
                        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                        MinTotalCode.OutputFormat = "00";
                        MinTotalCode.Size = size;
                        MinTotalName.Location = location;
                        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                        MinTotalName.Visible = true;
                        MinTotalName.DataField = DCHNB02074EA.CT_BusinessTypeName;
                        break;
                    }
                case 7:
                    {
                        // 7:部署別
                        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //SortDiv1Header.DataField = DCHNB02074EA.CT_SubSectionCode;
                        //SortDiv1Header.Visible = true;
                        //SortDiv1Footer.Visible = true;
                        //MinTotal_Title.Visible = true;
                        //MinTotal_Title.Text = "部門計";

                        //MinTotalHeaderTitle.Visible = true;
                        //MinTotalHeaderTitle.Text = "部門";
                        //MinTotalCode.Visible = true;
                        //MinTotalCode.DataField = DCHNB02074EA.CT_SubSectionCode;
                        //MinTotalCode.Alignment = TextAlignment.Right;
                        //MinTotalName.Visible = true;
                        //MinTotalName.DataField = DCHNB02074EA.CT_SubSectionName;
                        //--- DEL 2008.08.14 ---------->>>>>
                        //if (this._extrInfo.SectionDiv == 2)
                        //{
                        //    SortDiv1Header.DataField = DCHNB02074EA.CT_SubSectionCode;
                        //    SortDiv1Header.Visible = true;
                        //    SortDiv1Footer.Visible = true;
                        //    MinTotal_Title.Visible = true;
                        //    MinTotal_Title.Text    = "部署計";

                        //    MinTotalHeaderTitle.Visible = true;
                        //    MinTotalHeaderTitle.Text = "部署";
                        //    MinTotalCode.Visible = true;
                        //    MinTotalCode.DataField = DCHNB02074EA.CT_SubSectionCode;
                        //    MinTotalCode.Alignment = TextAlignment.Right;
                        //    MinTotalCode.OutputFormat = "00";
                        //    MinTotalCode.Size = size;
                        //    MinTotalName.Location = location;
                        //    MinTotalName.Visible = true;
                        //    MinTotalName.DataField = DCHNB02074EA.CT_SubSectionName;
                        //}
                        //--- DEL 2008.08.14 ----------<<<<<
                        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                        break;
                    }
                case 9:
                    {
                        // 9:得意先別メーカー別
                        SortDiv1Header.DataField = DCHNB02074EA.CT_CustomerCode;
                        SortDiv1Header.Visible = true;
                        SortDiv1Footer.Visible = true;
                        MinTotal_Title.Visible = true;
                        MinTotal_Title.Text = "得意先計";

                        MinTotalHeaderTitle.Visible = true;
                        MinTotalHeaderTitle.Text = "得意先";
                        MinTotalCode.Visible = true;
                        MinTotalCode.DataField = DCHNB02074EA.CT_CustomerCode;
                        MinTotalCode.Alignment = TextAlignment.Right;
                        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                        MinTotalCode.OutputFormat = "000000000";
                        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                        MinTotalName.Visible = true;
                        MinTotalName.DataField = DCHNB02074EA.CT_CustomerName;
                        break;
                    }
                default:
                    {
                        // 0:拠点, 1:得意先別, 4:地区別, 5:業種別, 6:担当者別, 8:メーカー別
                        SortDiv1Header.DataField = "";
                        SortDiv1Header.Visible = false;
                        SortDiv1Footer.Visible = false;
                        MinTotal_Title.Visible = false;

                        MinTotalHeaderTitle.Visible = false;
                        MinTotalCode.Visible = false;
                        MinTotalCode.DataField = "";
                        MinTotalName.Visible = false;
                        MinTotalName.DataField = "";
                        break;
                    }
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */
            #endregion

            // --- ADD 2008/09/08 -------------------------------->>>>>
            #region ヘッダ、フッタ表示、非表示制御

            switch (this._extrInfo.TotalType)
            {
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先別
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 得意先、管理拠点、請求先
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 拠点
                        {
                            // 高さ調整
                            this.TitleHeader.Height = 0.31F;
                        }
                        else if (this._extrInfo.PrintingPattern == 2) // 得意先-拠点
                        {
                            // 拠点で小計を取らないよう制御
                            this.SectionHeader.DataField = "";

                            this.ReportHeader.Visible = true;
                            this.ReportFooter.Visible = true;
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者 
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 担当者、管理拠点
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            this.SectionHeader.Visible = true;
                            this.ReportHeader.Visible = true;
                            this.SectionHeader.Height = 0F;

                            // 表示制御
                            this.SectionHeaderT.Visible = false;
                            this.SectionCode.Visible = false;
                            this.SectionName.Visible = false;

                            this.ReportSectionTitle.Visible = true;
                            this.ReportSectionCode.Visible = true;
                            this.ReportSectionName.Visible = true;

                            // 表示位置調整

                            this.ReportSectionTitle.Location = new System.Drawing.PointF(0.063F, 0.012F);
                            this.ReportSectionCode.Location = new System.Drawing.PointF(0.438F, 0.012F);
                            this.ReportSectionName.Location = new System.Drawing.PointF(0.698F, 0.012F);

                            this.ReportHeaderTitle.Location = new System.Drawing.PointF(3.25F, 0.012F);
                            this.ReportCodeN.Location = new System.Drawing.PointF(3.69F, 0.012F);
                            this.ReportCodeName.Location = new System.Drawing.PointF(4.31F, 0.012F);

                            this.ReportFooter.Visible = true;
                            this.SectionFooter.Visible = true;
                        }
                        else if (this._extrInfo.PrintingPattern == 2) // 担当者-拠点
                        {
                            // 拠点で小計を取らないよう制御
                            this.SectionHeader.DataField = "";

                            this.ReportHeader.Visible = true;
                            this.ReportFooter.Visible = true;
                        }
                        // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>
                        if ((this._extrInfo.TtlType == 0)
                            && (this._extrInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area // 地区
                                || this._extrInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType // 業種
                               )) // 集計方法 全社
                        {
                            this.SectionHeader.Visible = false;
                            this.SectionFooter.Visible = false;
                        }
                        // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                    {
                        if (this._extrInfo.TtlType == 0) // 集計方法 全社
                        {
                            // 高さ調整
                            this.TitleHeader.Height = 0.3F;
                        }
                        else
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                        }
                        break;
                    }
            }

            #endregion
            // --- ADD 2008/09/08 --------------------------------<<<<<
            // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
            if ((this._extrInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area            // 地区
                || this._extrInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType)   // 業種
                && this._extrInfo.OutType == 1)     // 1:得意先順
            {
                this.MinTargetMoney_TextBox.DataField = DCHNB02074EA.CT_SubTtlTargetMoney;
                this.MinTargetProfit_TextBox.DataField = DCHNB02074EA.CT_SubTtlTargetProfit;
                this.MinAnTargetMoney_TextBox.DataField = DCHNB02074EA.CT_AnSubTtlTargetMoney;
                this.MinAnTargetProfit_TextBox.DataField = DCHNB02074EA.CT_AnSubTtlTargetProfit;
            }
            // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<

            #region titleheader項目名称設定
            // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
            // コード表示形式を変更
            //System.Drawing.PointF location = new System.Drawing.PointF();

            // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<

            // 集計単位制御（行タイトル）
            switch (this._extrInfo.TotalType)
            {
                #region 削除
                //--- DEL 2008.08.14 ---------->>>>> 
                //case 0: // 0:拠点
                //    {
                //        RecordTitle.Text = "拠点";
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Left;
                //        RecordCodeN_TextBox.Visible = false;
                //        RecordCode_TextBox.Visible = true;
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //case 1: // 1:得意先別
                //case 2: // 2:地区別得意先別
                //case 3: // 3:業種別得意先別
                //    {
                //        RecordTitle.Text = "得意先";
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Right;
                //        RecordCodeN_TextBox.OutputFormat = "000000000";
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //case 4: // 4:地区別
                //    {
                //        RecordTitle.Text = "地区";
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Right;
                //        RecordCodeN_TextBox.OutputFormat = "00";
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //case 5: // 5:業種別
                //    {
                //        RecordTitle.Text = "業種";
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Right;
                //        RecordCodeN_TextBox.OutputFormat = "00";
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //case 6: // 6:担当者別
                //    {
                //        RecordTitle.Text = "担当者";
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Left;
                //        RecordCodeN_TextBox.Visible = false;
                //        RecordCode_TextBox.Visible = true;
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //case 7: // 7:部署別
                //    {
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordTitle.Text = "課";
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Right;
                //        //--- DEL 2008.08.14 ---------->>>>>
                //        //if (this._extrInfo.SectionDiv == 2)
                //        //{
                //        //    RecordTitle.Text = "課";
                //        //    RecordCodeN_TextBox.OutputFormat = "00";
                //        //}
                //        //else if (this._extrInfo.SectionDiv == 1)
                //        //{
                //        //    RecordTitle.Text = "部署";
                //        //    RecordCodeN_TextBox.OutputFormat = "00";
                //        //}
                //        //else if (this._extrInfo.SectionDiv == 0)
                //        //{
                //        //    RecordTitle.Text = string.Empty;
                //        //    RecordCodeN_TextBox.OutputFormat = string.Empty;
                //        //}
                //        //--- DEL 2008.08.14 ----------<<<<<
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //case 8: // 8:メーカー別
                //case 9: // 9:得意先別メーカー別
                //    {
                //        RecordTitle.Text = "メーカー";
                //        // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //        //RecordCodeN_TextBox.Alignment = TextAlignment.Right;
                //        RecordCodeN_TextBox.OutputFormat = "000000";
                //        // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                //--- DEL 2008.08.14 ----------<<<<<
                /* --- DEL 2008/09/08 -------------------------------->>>>>
                //--- ADD 2008.08.14 ---------->>>>>
                case 0: // 0:得意先別
                    {
                        if (this._extrInfo.PrintingPattern == 0)
                        {
                            RecordTitle.Text = "得意先";
                            RecordCodeN_TextBox.OutputFormat = "000000000";
                        }
                        else
                        {
                            RecordTitle.Text = "拠点";
                            RecordCodeN_TextBox.Visible = false;
                            RecordCode_TextBox.Visible = true;
                        }
                        break;
                    }
                //--- ADD 2008.08.14 ----------<<<<<
                --- DEL 2008/09/08 -------------------------------->>>>> */
                #endregion
                // --- ADD 2008/09/08 -------------------------------->>>>>
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 得意先、管理拠点、請求先
                        {
                            RecordTitle.Text = "得意先";
                        }
                        else // 拠点、管理拠点
                        {
                            RecordTitle.Text = "拠点";
                        }
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 担当者、管理拠点
                        {
                            RecordTitle.Text = "担当者";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            RecordTitle.Text = "得意先";
                        }
                        else // 担当者-拠点
                        {
                            RecordTitle.Text = "拠点";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 受注者、管理拠点
                        {
                            RecordTitle.Text = "受注者";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            RecordTitle.Text = "得意先";
                        }
                        else // 受注者-拠点
                        {
                            RecordTitle.Text = "拠点";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 発行者、管理拠点
                        {
                            RecordTitle.Text = "発行者";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            RecordTitle.Text = "得意先";
                        }
                        else // 発行者-拠点
                        {
                            RecordTitle.Text = "拠点";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 地区、管理拠点
                        {
                            RecordTitle.Text = "地区";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            RecordTitle.Text = "得意先";
                        }
                        else // 地区-拠点
                        {
                            RecordTitle.Text = "拠点";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 業種、管理拠点
                        {
                            RecordTitle.Text = "業種";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            RecordTitle.Text = "得意先";
                        }
                        else // 業種-拠点
                        {
                            RecordTitle.Text = "拠点";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                    {
                        RecordTitle.Text = "販売区分";

                        break;
                    }
                // --- ADD 2008/09/08 --------------------------------<<<<<
            }
            #endregion

            // --- ADD 2008/12/08 -------------------------------->>>>>
            #region SectionHeader項目名称、表示形式設定
            if (this._extrInfo.TtlType == 0) // 全社
            {
                this.SectionHeaderT.Visible = false;
                this.SectionCode.Visible = false;
                this.SectionName.Visible = false;
            }
            else
            {
                this.SectionHeaderT.Visible = true;
                this.SectionCode.Visible = true;
                this.SectionName.Visible = true;
            }
            #endregion
            // --- ADD 2008/12/08 --------------------------------<<<<<

            // --- ADD 2008/09/08 -------------------------------->>>>>
            #region ReportHeader、Reportfooter項目名称、表示形式設定

            // ReportCodeN ゴシック、右詰、数値用
            // ReportCode  明朝、左詰、文字用
            location.X = ReportCodeN.Location.X;
            location.Y = ReportCodeN.Location.Y;
            ReportCode.Location = location;

            switch (this._extrInfo.TotalType)
            {
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                    {
                        this.ReportHeaderTitle.Text = "得意先";
                        this.MinTotal_Title.Text = "得意先計";

                        // 得意先コード
                        this.ReportCodeN.OutputFormat = "00000000";

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    {
                        this.ReportHeaderTitle.Text = "担当者";
                        this.MinTotal_Title.Text = "担当者計";

                        this.ReportCodeN.Visible = false;
                        this.ReportCode.Visible = true;
                        this.ReportCode.OutputFormat = "0000";

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    {
                        this.ReportHeaderTitle.Text = "受注者";
                        this.MinTotal_Title.Text = "受注者計";

                        this.ReportCodeN.Visible = false;
                        this.ReportCode.Visible = true;
                        this.ReportCode.OutputFormat = "0000";

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                    {
                        this.ReportHeaderTitle.Text = "発行者";
                        this.MinTotal_Title.Text = "発行者計";

                        this.ReportCodeN.Visible = false;
                        this.ReportCode.Visible = true;
                        this.ReportCode.OutputFormat = "0000";

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    {
                        this.ReportHeaderTitle.Text = "地区";
                        this.MinTotal_Title.Text = "地区計";

                        this.ReportCodeN.OutputFormat = "0000";

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    {
                        this.ReportHeaderTitle.Text = "業種";
                        this.MinTotal_Title.Text = "業種計";

                        this.ReportCodeN.OutputFormat = "0000";

                        break;
                    }
            }

            #endregion
            // --- ADD 2008/09/08 --------------------------------<<<<<

            // --- ADD 2008/09/08 -------------------------------->>>>>
            #region Detail表示形式設定
            // RecordCodeN_TextBox ゴシック、右詰、数値用
            // RecordCode_TextBox  明朝、左詰、文字用
            //location.X = RecordCodeN_TextBox.Location.X; // DEL 2008/10/06
            //location.Y = RecordCodeN_TextBox.Location.Y; // DEL 2008/10/06
            //RecordCode_TextBox.Location = location; // DEL 2008/10/06

            switch (this._extrInfo.TotalType)
            {
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 得意先、管理拠点、請求先
                        {
                            // 得意先コード
                            RecordCode_TextBox.OutputFormat = "00000000";
                        }
                        else // 拠点、管理拠点
                        {
                            // 拠点コード
                            //RecordCodeN_TextBox.Visible = false; // DEL 2008/10/06
                            //RecordCode_TextBox.Visible = true; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "00";
                        }
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                    {
                        if (this._extrInfo.PrintingPattern == 0) // xx者、管理拠点
                        {
                            // 担当者、受注者、発行者(従業員コード)
                            //RecordCodeN_TextBox.Visible = false; // DEL 2008/10/06
                            //RecordCode_TextBox.Visible = true; // DEL 2008/10/06
                            //RecordCodeN_TextBox.OutputFormat = "0000"; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "0000";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            // 得意先コード
                            //RecordCodeN_TextBox.OutputFormat = "000000000"; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "00000000";
                        }
                        else // 担当者-拠点
                        {
                            // 拠点コード
                            //RecordCodeN_TextBox.Visible = false; // DEL 2008/10/06
                            //RecordCode_TextBox.Visible = true; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "00";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    {
                        if (this._extrInfo.PrintingPattern == 0) // 地区、管理拠点
                        {
                            // 地区、業種コード
                            //RecordCodeN_TextBox.OutputFormat = "0000"; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "0000";
                        }
                        else if (this._extrInfo.PrintingPattern == 1) // 得意先
                        {
                            // 得意先コード
                            //RecordCodeN_TextBox.OutputFormat = "000000000"; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "00000000";
                        }
                        else // 地区-拠点
                        {
                            // 拠点コード
                            //RecordCodeN_TextBox.Visible = false; // DEL 2008/10/06
                            //RecordCode_TextBox.Visible = true; // DEL 2008/10/06
                            RecordCode_TextBox.OutputFormat = "00";
                        }

                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                    {
                        // 販売区分コード
                        //RecordCodeN_TextBox.OutputFormat = "0000"; // DEL 2008/10/06
                        RecordCode_TextBox.OutputFormat = "0000";
                        break;
                    }
            }
            #endregion
            // --- ADD 2008/09/08 --------------------------------<<<<<

            #region 集計単位制御（改頁）
            // 集計単位制御（改頁）
            /*
                        if (this._extrInfo.CrMode >= 10)
                        {
                            if (this._extrInfo.TotalType == 0)
                            {
                                if (this._extrInfo.OutType != 2)
                                {
                                    SectionHeader.DataField = DCHNB02074EA.CT_MiniTotal_KeyBleak;
                                    SectionHeader.Visible = true;
                                    SectionHeader.NewPage = NewPage.Before;
                                }
                                else
                                {
                                    ReportHeader.DataField = DCHNB02074EA.CT_CustomerCode;
                                    ReportHeader.Visible = true;
                                    ReportHeader.NewPage = NewPage.Before;
                                }
                            }
                            else
                            {
                                if ((this._extrInfo.CrMode % 10) > 0)
                                {
                                    SectionHeader.DataField = DCHNB02074EA.CT_SectionCode;
                                    ReportHeader.DataField = DCHNB02074EA.CT_MiniTotal_KeyBleak;
                                    ReportHeader.NewPage = NewPage.Before;

                                    SectionHeader.Visible = false;
                                    SectionTitle_Sub.Visible = true;
                                    SectionCode_Sub.Visible = true;
                                    SectionName_Sub.Visible = true;
                                }
                                else
                                {
                                    SectionHeader.NewPage = NewPage.Before;

                                    System.Drawing.PointF point = new System.Drawing.PointF();
                                    point.Y = 0.012F;
                                    point.X = MinTotalHeaderTitle.Location.X;
                                    MinTotalHeaderTitle.Location = point;
                                    point.X = MinTotalCode.Location.X;
                                    MinTotalCode.Location = point;
                                    point.X = MinTotalName.Location.X;
                                    MinTotalName.Location = point;
                                }
                            }
                        }
                        else
                        {
                            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                            //SectionHeader.NewPage = NewPage.None;
                            if (this._extrInfo.CrMode > 0)
                            {
                                ReportHeader.DataField = DCHNB02074EA.CT_MiniTotal_KeyBleak;
                                ReportHeader.NewPage = NewPage.Before;

                                SectionHeader.Visible = false;

                                System.Drawing.PointF point = new System.Drawing.PointF();
                                point.Y = 0.012F;
                                point.X = MinTotalHeaderTitle.Location.X;
                                MinTotalHeaderTitle.Location = point;
                                point.X = MinTotalCode.Location.X;
                                MinTotalCode.Location = point;
                                point.X = MinTotalName.Location.X;
                                MinTotalName.Location = point;
                            }
                            else
                            {
                                SectionHeader.NewPage = NewPage.None;
                            }
                            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                        }
             */
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (!this._extrInfo.CrMode1)
            {
                this.SectionHeader.NewPage = NewPage.None;
            }

            if (!this._extrInfo.CrMode2)
            {
                this.ReportHeader.NewPage = NewPage.None;
            }
            // --- ADD 2008/09/08 --------------------------------<<<<<

            #endregion

            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
            #region 罫線印字制御
            if (this._extrInfo.LineMaSqOfChDiv == 1)
            {
                Line37.Visible = false;
                line2.Visible = false;
                Line45.Visible = false;
                Line.Visible = false;
            }
            else
            {
                Line37.Visible = true;
                line2.Visible = true;
                Line45.Visible = true;
                Line.Visible = true;
            }
            #endregion
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

            #region 明細内行数制御
            // 明細内行数制御
            if (this._extrInfo.PrintType != 2)
            {
                // 当期項目を非表示
                this.AnSalesTtlPrice_TextBox.Visible = false;
                this.AnRetGoodsTtlPrice_TextBox.Visible = false;
                this.AnRetGoodsTtlRate_TextBox.Visible = false;
                this.AnDiscountTtlPrice_TextBox.Visible = false;
                this.AnPureSalesTtlPrice_TextBox.Visible = false;
                this.AnTargetMoney_TextBox.Visible = false;
                this.AnTargetMoneyRate_TextBox.Visible = false;
                this.AnCmpPureSalesRatio_TextBox.Visible = false;
                this.AnGrossProfitPrice_TextBox.Visible = false;
                this.AnGrossProfitRate_TextBox.Visible = false;
                this.AnTargetProfit_TextBox.Visible = false;
                this.AnTargetProfitRate_TextBox.Visible = false;
                this.AnCmpProfitRatio_TextBox.Visible = false;

                this.MinAnSalesTtlPrice_TextBox.Visible = false;
                this.MinAnRetGoodsTtlPrice_TextBox.Visible = false;
                this.MinAnRetGoodsTtlRate_TextBox.Visible = false;
                this.MinAnDiscountTtlPrice_TextBox.Visible = false;
                this.MinAnPureSalesTtlPrice_TextBox.Visible = false;
                this.MinAnTargetMoney_TextBox.Visible = false;
                this.MinAnTargetMoneyRate_TextBox.Visible = false;
                this.MinAnCmpPureSalesRatio_TextBox.Visible = false;
                this.MinAnGrossProfitPrice_TextBox.Visible = false;
                this.MinAnGrossProfitRate_TextBox.Visible = false;
                this.MinAnTargetProfit_TextBox.Visible = false;
                this.MinAnTargetProfitRate_TextBox.Visible = false;
                this.MinAnCmpProfitRatio_TextBox.Visible = false;

                this.SectionAnSalesTtlPrice_TextBox.Visible = false;
                this.SectionAnRetGoodsTtlPrice_TextBox.Visible = false;
                this.SectionAnRetGoodsTtlRate_TextBox.Visible = false;
                this.SectionAnDiscountTtlPrice_TextBox.Visible = false;
                this.SectionAnPureSalesTtlPrice_TextBox.Visible = false;
                this.SectionAnTargetMoney_TextBox.Visible = false;
                this.SectionAnTargetMoneyRate_TextBox.Visible = false;
                this.SectionAnCmpPureSalesRatio_TextBox.Visible = false;
                this.SectionAnGrossProfitPrice_TextBox.Visible = false;
                this.SectionAnGrossProfitRate_TextBox.Visible = false;
                this.SectionAnTargetProfit_TextBox.Visible = false;
                this.SectionAnTargetProfitRate_TextBox.Visible = false;
                this.SectionAnCmpProfitRatio_TextBox.Visible = false;

                this.GrandAnSalesTtlPrice_TextBox.Visible = false;
                this.GrandAnRetGoodsTtlPrice_TextBox.Visible = false;
                this.GrandAnRetGoodsTtlRate_TextBox.Visible = false;
                this.GrandAnDiscountTtlPrice_TextBox.Visible = false;
                this.GrandAnPureSalesTtlPrice_TextBox.Visible = false;
                this.GrandAnTargetMoney_TextBox.Visible = false;
                this.GrandAnTargetMoneyRate_TextBox.Visible = false;
                this.GrandAnCmpPureSalesRatio_TextBox.Visible = false;
                this.GrandAnGrossProfitPrice_TextBox.Visible = false;
                this.GrandAnGrossProfitRate_TextBox.Visible = false;
                this.GrandAnTargetProfit_TextBox.Visible = false;
                this.GrandAnTargetProfitRate_TextBox.Visible = false;
                this.GrandAnCmpProfitRatio_TextBox.Visible = false;
            }
            if (this._extrInfo.PrintType == 1)
            {
                // 当月項目と当期項目の置き換え
                this.SalesTtlPrice_TextBox.DataField = this.AnSalesTtlPrice_TextBox.DataField;
                this.RetGoodsTtlPrice_TextBox.DataField = this.AnRetGoodsTtlPrice_TextBox.DataField;
                this.RetGoodsTtlRate_TextBox.DataField = this.AnRetGoodsTtlRate_TextBox.DataField;
                this.DiscountTtlPrice_TextBox.DataField = this.AnDiscountTtlPrice_TextBox.DataField;
                this.PureSalesTtlPrice_TextBox.DataField = this.AnPureSalesTtlPrice_TextBox.DataField;
                this.TargetMoney_TextBox.DataField = this.AnTargetMoney_TextBox.DataField;
                this.TargetMoneyRate_TextBox.DataField = this.AnTargetMoneyRate_TextBox.DataField;
                this.CmpPureSalesRatio_TextBox.DataField = this.AnCmpPureSalesRatio_TextBox.DataField;
                this.GrossProfitPrice_TextBox.DataField = this.AnGrossProfitPrice_TextBox.DataField;
                this.GrossProfitRate_TextBox.DataField = this.AnGrossProfitRate_TextBox.DataField;
                this.TargetProfit_TextBox.DataField = this.AnTargetProfit_TextBox.DataField;
                this.TargetProfitRate_TextBox.DataField = this.AnTargetProfitRate_TextBox.DataField;
                this.CmpProfitRatio_TextBox.DataField = this.AnCmpProfitRatio_TextBox.DataField;

                this.MinSalesTtlPrice_TextBox.DataField = this.MinAnSalesTtlPrice_TextBox.DataField;
                this.MinRetGoodsTtlPrice_TextBox.DataField = this.MinAnRetGoodsTtlPrice_TextBox.DataField;
                this.MinRetGoodsTtlRate_TextBox.DataField = this.MinAnRetGoodsTtlRate_TextBox.DataField;
                this.MinDiscountTtlPrice_TextBox.DataField = this.MinAnDiscountTtlPrice_TextBox.DataField;
                this.MinPureSalesTtlPrice_TextBox.DataField = this.MinAnPureSalesTtlPrice_TextBox.DataField;
                this.MinPureSalesTtlWork_TextBox.DataField = this.MinAnPureSalesTtlWork_TextBox.DataField;
                this.MinTargetMoney_TextBox.DataField = this.MinAnTargetMoney_TextBox.DataField;
                this.MinTargetMoneyRate_TextBox.DataField = this.MinAnTargetMoneyRate_TextBox.DataField;
                this.MinGrossProfitPrice_TextBox.DataField = this.MinAnGrossProfitPrice_TextBox.DataField;
                this.MinGrossProfitRate_TextBox.DataField = this.MinAnGrossProfitRate_TextBox.DataField;
                this.MinGrossProfitWork_TextBox.DataField = this.MinAnGrossProfitWork_TextBox.DataField;
                this.MinTargetProfit_TextBox.DataField = this.MinAnTargetProfit_TextBox.DataField;
                this.MinTargetProfitRate_TextBox.DataField = this.MinAnTargetProfitRate_TextBox.DataField;

                this.SectionSalesTtlPrice_TextBox.DataField = this.SectionAnSalesTtlPrice_TextBox.DataField;
                this.SectionRetGoodsTtlPrice_TextBox.DataField = this.SectionAnRetGoodsTtlPrice_TextBox.DataField;
                this.SectionRetGoodsTtlRate_TextBox.DataField = this.SectionAnRetGoodsTtlRate_TextBox.DataField;
                this.SectionDiscountTtlPrice_TextBox.DataField = this.SectionAnDiscountTtlPrice_TextBox.DataField;
                this.SectionPureSalesTtlPrice_TextBox.DataField = this.SectionAnPureSalesTtlPrice_TextBox.DataField;
                this.SectionPureSalesTtlWork_TextBox.DataField = this.SectionAnPureSalesTtlWork_TextBox.DataField;
                this.SectionTargetMoney_TextBox.DataField = this.SectionAnTargetMoney_TextBox.DataField;
                this.SectionTargetMoneyRate_TextBox.DataField = this.SectionAnTargetMoneyRate_TextBox.DataField;
                this.SectionGrossProfitPrice_TextBox.DataField = this.SectionAnGrossProfitPrice_TextBox.DataField;
                this.SectionGrossProfitRate_TextBox.DataField = this.SectionAnGrossProfitRate_TextBox.DataField;
                this.SectionGrossProfitWork_TextBox.DataField = this.SectionAnGrossProfitWork_TextBox.DataField;
                this.SectionTargetProfit_TextBox.DataField = this.SectionAnTargetProfit_TextBox.DataField;
                this.SectionTargetProfitRate_TextBox.DataField = this.SectionAnTargetProfitRate_TextBox.DataField;

                this.GrandSalesTtlPrice_TextBox.DataField = this.GrandAnSalesTtlPrice_TextBox.DataField;
                this.GrandRetGoodsTtlPrice_TextBox.DataField = this.GrandAnRetGoodsTtlPrice_TextBox.DataField;
                this.GrandRetGoodsTtlRate_TextBox.DataField = this.GrandAnRetGoodsTtlRate_TextBox.DataField;
                this.GrandDiscountTtlPrice_TextBox.DataField = this.GrandAnDiscountTtlPrice_TextBox.DataField;
                this.GrandPureSalesTtlPrice_TextBox.DataField = this.GrandAnPureSalesTtlPrice_TextBox.DataField;
                this.GrandPureSalesTtlWork_TextBox.DataField = this.GrandAnPureSalesTtlWork_TextBox.DataField;
                this.GrandTargetMoney_TextBox.DataField = this.GrandAnTargetMoney_TextBox.DataField;
                this.GrandTargetMoneyRate_TextBox.DataField = this.GrandAnTargetMoneyRate_TextBox.DataField;
                this.GrandGrossProfitPrice_TextBox.DataField = this.GrandAnGrossProfitPrice_TextBox.DataField;
                this.GrandGrossProfitRate_TextBox.DataField = this.GrandAnGrossProfitRate_TextBox.DataField;
                this.GrandGrossProfitWork_TextBox.DataField = this.GrandAnGrossProfitWork_TextBox.DataField;
                this.GrandTargetProfit_TextBox.DataField = this.GrandAnTargetProfit_TextBox.DataField;
                this.GrandTargetProfitRate_TextBox.DataField = this.GrandAnTargetProfitRate_TextBox.DataField;
            }
            #endregion

            #region 目標金額表示制御
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            // 目標金額表示制御
            if ((this._extrInfo.TotalType == 8) || (this._extrInfo.TotalType == 9))
            {
                // 目標関連項目を非表示
                this.TargetMoney_Title.Visible = false;
                this.TargetMoneyRate_Title.Visible = false;
                this.TargetProfit_Title.Visible = false;
                this.TargetProfitRate_Title.Visible = false;

                this.TargetMoney_TextBox.Visible = false;
                this.TargetMoneyRate_TextBox.Visible = false;
                this.TargetProfit_TextBox.Visible = false;
                this.TargetProfitRate_TextBox.Visible = false;
                this.AnTargetMoney_TextBox.Visible = false;
                this.AnTargetMoneyRate_TextBox.Visible = false;
                this.AnTargetProfit_TextBox.Visible = false;
                this.AnTargetProfitRate_TextBox.Visible = false;

                this.MinTargetMoney_TextBox.Visible = false;
                this.MinTargetMoneyRate_TextBox.Visible = false;
                this.MinTargetProfit_TextBox.Visible = false;
                this.MinTargetProfitRate_TextBox.Visible = false;
                this.MinAnTargetMoney_TextBox.Visible = false;
                this.MinAnTargetMoneyRate_TextBox.Visible = false;
                this.MinAnTargetProfit_TextBox.Visible = false;
                this.MinAnTargetProfitRate_TextBox.Visible = false;

                this.SectionTargetMoney_TextBox.Visible = false;
                this.SectionTargetMoneyRate_TextBox.Visible = false;
                this.SectionTargetProfit_TextBox.Visible = false;
                this.SectionTargetProfitRate_TextBox.Visible = false;
                this.SectionAnTargetMoney_TextBox.Visible = false;
                this.SectionAnTargetMoneyRate_TextBox.Visible = false;
                this.SectionAnTargetProfit_TextBox.Visible = false;
                this.SectionAnTargetProfitRate_TextBox.Visible = false;

                this.GrandTargetMoney_TextBox.Visible = false;
                this.GrandTargetMoneyRate_TextBox.Visible = false;
                this.GrandTargetProfit_TextBox.Visible = false;
                this.GrandTargetProfitRate_TextBox.Visible = false;
                this.GrandAnTargetMoney_TextBox.Visible = false;
                this.GrandAnTargetMoneyRate_TextBox.Visible = false;
                this.GrandAnTargetProfit_TextBox.Visible = false;
                this.GrandAnTargetProfitRate_TextBox.Visible = false;
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */
            #endregion

            #region 構成比項目制御
            // 構成比項目制御
            //if ((this._extrInfo.TotalType != 0) && (this._extrInfo.ConstUnit != 0))
            if (this._extrInfo.ConstUnit != 0)
            {
                // --- DEL 2008/09/08 -------------------------------->>>>>
                //this.GrandCmpPureSalesRatio_TextBox.Visible = false;
                //this.GrandAnCmpPureSalesRatio_TextBox.Visible = false;
                //this.GrandCmpProfitRatio_TextBox.Visible = false;
                //this.GrandAnCmpProfitRatio_TextBox.Visible = false;

                //if ((this._extrInfo.TotalType == 2) ||
                //    (this._extrInfo.TotalType == 3) ||
                //    (this._extrInfo.TotalType == 7) ||
                //    (this._extrInfo.TotalType == 9))
                //{
                //    this.SectionCmpPureSalesRatio_TextBox.Visible = false;
                //    this.SectionAnCmpPureSalesRatio_TextBox.Visible = false;
                //    this.SectionCmpProfitRatio_TextBox.Visible = false;
                //    this.SectionAnCmpProfitRatio_TextBox.Visible = false;
                //}
                // --- DEL 2008/09/08 --------------------------------<<<<< 
                // --- ADD 2008/09/08 -------------------------------->>>>>
                if (!(this._extrInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer
                    && this._extrInfo.PrintingPattern == 1)
                    && !(this._extrInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision
                    && this._extrInfo.PrintingPattern == 1))
                {
                    // 上記以外は小計が存在するので総合計の構成比を表示しない
                    this.GrandCmpPureSalesRatio_TextBox.Visible = false;
                    this.GrandAnCmpPureSalesRatio_TextBox.Visible = false;
                    this.GrandCmpProfitRatio_TextBox.Visible = false;
                    this.GrandAnCmpProfitRatio_TextBox.Visible = false;

                    if (this._extrInfo.TotalType != (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer
                        && this._extrInfo.TotalType != (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision)
                    {
                        if (_extrInfo.PrintingPattern == 1)
                        {
                            // 小計が2つあるケースは拠点計の構成比を表示しない
                            this.SectionCmpPureSalesRatio_TextBox.Visible = false;
                            this.SectionAnCmpPureSalesRatio_TextBox.Visible = false;
                            this.SectionCmpProfitRatio_TextBox.Visible = false;
                            this.SectionAnCmpProfitRatio_TextBox.Visible = false;
                        }
                    }
                }
                // --- ADD 2008/09/08 --------------------------------<<<<<
            }
            #endregion

            #region 項目の名称セット
            // 項目の名称をセット
            SortTitle.Text = this._pageHeaderSortOderTitle;	// ソート条件    

            ListTitle_Title.Text = ListTitle_Title.Text + "（" + this._extrInfo.TotalTypeName + "）"; // タイトル

            /* --- DEL 2008/09/08 -------------------------------->>>>>
            if ((this._extrInfo.TtlType == 0) && (this._extrInfo.TotalType != 0))   // 全社集計
            {
                SectionCode.DataField = "";
                SectionCode.Text = "";
                SectionName.DataField = "";
                SectionName.Text = "全社集計";
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */
            #endregion

            // --- ADD 2009/02/06 -------------------------------->>>>>
            #region 総合計の売上、粗利目標設定
            // 売上目標、粗利目標の設定
            // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>
            // 集計方法が拠点毎の場合
            if (this._extrInfo.TtlType == 1)
            {
                // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<
                switch (this._extrInfo.TotalType)
                {
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先別
                        {
                            if (this._extrInfo.PrintingPattern == 0) // 得意先、管理拠点、請求先
                            {
                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            // ADD 2009/06/09 ------>>>
                            else if (this._extrInfo.PrintingPattern == 1)   // 拠点順
                            {
                                this.TargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.TargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.AnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.AnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";

                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            // ADD 2009/06/09 ------<<<
                            else
                            {
                                this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
                            }

                            break;
                        }
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者 
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                        {
                            if (this._extrInfo.PrintingPattern == 0
                                || this._extrInfo.PrintingPattern == 1) // 担当者、管理拠点、得意先
                            {
                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            else
                            {
                                this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
                            }
                            break;
                        }
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                        {
                            if (this._extrInfo.TtlType != 0) // 集計方法 拠点
                            {
                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            else
                            {
                                this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
                            }

                            break;
                        }
                }
                // --- Add duzg　2013/07/26  for  Redmine#38722 ------->>>>>>>>>>>
            }
            // 集計方法が全社の場合
            else
            {
                switch (this._extrInfo.TotalType)
                {
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                        {
                            if (this._extrInfo.PrintingPattern == 1) // 得意先
                            {
                                this.GrandTargetMoney_TextBox.DataField = DCHNB02074EA.CT_SubTtlTargetMoney;
                                this.GrandTargetProfit_TextBox.DataField = DCHNB02074EA.CT_SubTtlTargetProfit;
                                this.GrandAnTargetMoney_TextBox.DataField = DCHNB02074EA.CT_AnSubTtlTargetMoney;
                                this.GrandAnTargetProfit_TextBox.DataField = DCHNB02074EA.CT_AnSubTtlTargetProfit;
                            }
                            break;
                        }
                    //集計方法が全社は拠点毎同じ
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先別
                        {
                            if (this._extrInfo.PrintingPattern == 0) // 得意先、管理拠点、請求先
                            {
                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            else if (this._extrInfo.PrintingPattern == 1)   // 拠点順
                            {
                                this.TargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.TargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.AnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.AnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";

                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            else
                            {
                                this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
                            }

                            break;
                        }
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                        {
                            if (this._extrInfo.PrintingPattern == 0
                                || this._extrInfo.PrintingPattern == 1) // 担当者、管理拠点、得意先
                            {
                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            else
                            {
                                this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
                            }
                            break;
                        }
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                        {
                            if (this._extrInfo.TtlType != 0) // 集計方法 拠点
                            {
                                this.GrandTargetMoney_TextBox.DataField = "SectionTargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "SectionTargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
                            }
                            else
                            {
                                this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
                                this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
                                this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
                                this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
                            }

                            break;
                        }
                }
            }
            // --- Add duzg　2013/07/26  for  Redmine#38722 -------<<<<<<<<<<<
            #endregion
            // --- ADD 2009/02/06 --------------------------------<<<<<
        }

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(double numerator, double denominator)
        {
            double workRate;

            if (denominator == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            //if (workRate < 0) workRate = workRate * -1; // DEL 2009/03/24

            return workRate;
        }

        #endregion

        // --- ADD 2008/10/06 -------------------------------->>>>>
        /// <summary>
        /// ReportHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Reportヘッダの印刷前に発生するイベントです。</br>
        /// <br>Programmer : 30452 上野　俊治</br>
        /// <br>Date	   : 2008.10.06</br>
        /// </remarks>
        private void ReportHeader_BeforePrint(object sender, EventArgs e)
        {
            // 各コードのゼロ値の場合、コード値、名称は表示しない。
            if (this.ReportCodeN.Visible)
            {
                if (string.IsNullOrEmpty(this.ReportCodeN.Text) ||  // ADD 2008/12/04
                    Convert.ToInt32(this.ReportCodeN.Text) == 0)
                {
                    this.ReportCodeN.Text = "";
                    this.ReportCodeName.Text = "";
                }
            }

            if (this.ReportCode.Visible)
            {
                if (string.IsNullOrEmpty(this.ReportCode.Text) || // ADD 2008/12/04
                    Convert.ToInt32(this.ReportCode.Text) == 0)
                {
                    this.ReportCode.Text = "";
                    this.ReportCodeName.Text = "";
                }
            }
        }
        // --- ADD 2008/10/06 --------------------------------<<<<<

        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);

            // 順位列の初期値は表示しない
            if (this.Order_TextBox.Value.ToString() == "10000000")
            {
                this.Order_TextBox.Value = null;
            }

            // --- ADD 2008/10/06 -------------------------------->>>>>
            // 各コードのゼロ値の場合、コードと名称を表示しない。
            if (string.IsNullOrEmpty(this.RecordCode_TextBox.Text) || // ADD 2008/12/04
                Convert.ToInt32(this.RecordCode_TextBox.Text) == 0)
            {
                this.RecordCode_TextBox.Text = "";
                this.RecordName_TextBox.Text = "";
            }
            // --- ADD 2008/10/06 --------------------------------<<<<<
        }

        /// <summary>
        /// MAZAI02072P_02A4C_PageEndイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : １ページの出力が終了したときに発生するイベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
        private void MAZAI02072P_02A4C_PageEnd(object sender, System.EventArgs eArgs)
        {
        }

        /// <summary>
        /// ExtraHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
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


            if (this._rptExtraHeader == null)
            {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else
            {
                this._rptExtraHeader.DataSource = null;
            }
            // --- DEL 2008/12/11 -------------------------------->>>>>
            ////全社選択のときは、固定で「全社」と設定する
            //if (this._extrInfo.SectionCodes == null)
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "拠点： 全社";
            //}
            //else
            //{
            //    //this._rptExtraHeader.SectionCondition.Text = "拠点： " + this.SectionName.Text;
            //}
            // --- DEL 2008/12/11 --------------------------------<<<<<

            // 抽出条件印字項目設定
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
        }

        /// <summary>
        /// PageFooter_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            /*
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// インスタンスが作成されていなければ作成
				if ( this._rptPageFooter == null)
				{
					this._rptPageFooter = new ListCommon_PageFooter();
				}
				else
				{
					// インスタンスが作成されていれば、データソースを初期化する
					// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
					this._rptPageFooter.DataSource = null;
				}

				// フッター印字項目設定
				if (this._pageFooters[0] != null)
				{
					this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
				}
				if (this._pageFooters[1] != null)
				{
					this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
				}
			
				this.Footer_SubReport.Report = this._rptPageFooter;				
			}
            */
            // --- ADD 2009/01/23 -------------------------------->>>>>
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッター罫線印字設定
                Line_PageFooter.Visible = true;

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    PageFooters0.Visible = true;
                    PageFooters0.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    PageFooters1.Visible = true;
                    PageFooters1.Value = this._pageFooters[1];
                }
            }
            else
            {
                // フッター罫線印字設定
                Line_PageFooter.Visible = false;

                PageFooters0.Visible = false;
                PageFooters1.Visible = false;
            }
            // --- ADD 2009/01/23 --------------------------------<<<<<
        }

        /// <summary>
        /// MAZAI02072P_02A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : MAZAI02072P_02A4C_ReportStartの初期化イベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
        private void MAZAI02072P_02A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // レポート要素出力設定
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 作成日付           
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            //作成日(西暦で表示)
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                //this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// 小計BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 小計がページに描画される前に発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.11.08</br>
        /// </remarks>
        private void ReportFooter_BeforePrint(object sender, EventArgs e)
        {
            double TotalMoney;
            double TargetMoney;

            // 月間 返品率
            TotalMoney = (double)this.MinSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.MinRetGoodsTtlPrice_TextBox.Value;
            this.MinRetGoodsTtlRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 売上達成率
            TotalMoney = (double)this.MinTargetMoney_TextBox.Value;
            TargetMoney = (double)this.MinPureSalesTtlPrice_TextBox.Value;
            this.MinTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 売上構成比
            TotalMoney = (double)((Int64)this.MinPureSalesTtlWork_TextBox.Value);
            this.MinCmpPureSalesRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利率
            TotalMoney = (double)this.MinPureSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.MinGrossProfitPrice_TextBox.Value;
            this.MinGrossProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利達成率
            TotalMoney = (double)this.MinTargetProfit_TextBox.Value;
            this.MinTargetProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利構成比
            TotalMoney = (double)((Int64)this.MinGrossProfitWork_TextBox.Value);
            this.MinCmpProfitRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);


            // 年間 返品率
            TotalMoney = (double)this.MinAnSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.MinAnRetGoodsTtlPrice_TextBox.Value;
            this.MinAnRetGoodsTtlRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 売上達成率
            TotalMoney = (double)this.MinAnTargetMoney_TextBox.Value;
            TargetMoney = (double)this.MinAnPureSalesTtlPrice_TextBox.Value;
            this.MinAnTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 売上構成比
            TotalMoney = (double)((Int64)this.MinAnPureSalesTtlWork_TextBox.Value);
            this.MinAnCmpPureSalesRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利率
            TotalMoney = (double)this.MinAnPureSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.MinAnGrossProfitPrice_TextBox.Value;
            this.MinAnGrossProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利達成率
            TotalMoney = (double)this.MinAnTargetProfit_TextBox.Value;
            this.MinAnTargetProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利構成比
            TotalMoney = (double)((Int64)this.MinAnGrossProfitWork_TextBox.Value);
            this.MinAnCmpProfitRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);
        }

        /// <summary>
        /// 拠点計BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 拠点がページに描画される前に発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            double TotalMoney;
            double TargetMoney;

            // 月間 返品率
            TotalMoney = (double)this.SectionSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.SectionRetGoodsTtlPrice_TextBox.Value;
            this.SectionRetGoodsTtlRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 売上達成率
            TotalMoney = (double)this.SectionTargetMoney_TextBox.Value;
            TargetMoney = (double)this.SectionPureSalesTtlPrice_TextBox.Value;
            this.SectionTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 売上構成比
            TotalMoney = (double)((Int64)this.SectionPureSalesTtlWork_TextBox.Value);
            this.SectionCmpPureSalesRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利率
            TotalMoney = (double)this.SectionPureSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.SectionGrossProfitPrice_TextBox.Value;
            this.SectionGrossProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利達成率
            TotalMoney = (double)this.SectionTargetProfit_TextBox.Value;
            this.SectionTargetProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利構成比
            TotalMoney = (double)((Int64)this.SectionGrossProfitWork_TextBox.Value);
            this.SectionCmpProfitRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);


            // 年間 返品率
            TotalMoney = (double)this.SectionAnSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.SectionAnRetGoodsTtlPrice_TextBox.Value;
            this.SectionAnRetGoodsTtlRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 売上達成率
            TotalMoney = (double)this.SectionAnTargetMoney_TextBox.Value;
            TargetMoney = (double)this.SectionAnPureSalesTtlPrice_TextBox.Value;
            this.SectionAnTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 売上構成比
            TotalMoney = (double)((Int64)this.SectionAnPureSalesTtlWork_TextBox.Value);
            this.SectionAnCmpPureSalesRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利率
            TotalMoney = (double)this.SectionAnPureSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.SectionAnGrossProfitPrice_TextBox.Value;
            this.SectionAnGrossProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利達成率
            TotalMoney = (double)this.SectionAnTargetProfit_TextBox.Value;
            this.SectionAnTargetProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利構成比
            TotalMoney = (double)((Int64)this.SectionAnGrossProfitWork_TextBox.Value);
            this.SectionAnCmpProfitRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);
        }

        /// <summary>
        /// 総合計BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 総合計がページに描画される前に発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            double TotalMoney;
            double TargetMoney;

            // 月間 返品率
            TotalMoney = (double)this.GrandSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.GrandRetGoodsTtlPrice_TextBox.Value;
            this.GrandRetGoodsTtlRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 売上達成率
            TotalMoney = (double)this.GrandTargetMoney_TextBox.Value;
            TargetMoney = (double)this.GrandPureSalesTtlPrice_TextBox.Value;
            this.GrandTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);





            // 月間 売上構成比
            TotalMoney = (double)((Int64)this.GrandPureSalesTtlWork_TextBox.Value);
            this.GrandCmpPureSalesRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利率
            TotalMoney = (double)this.GrandPureSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.GrandGrossProfitPrice_TextBox.Value;
            this.GrandGrossProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利達成率
            TotalMoney = (double)this.GrandTargetProfit_TextBox.Value;
            this.GrandTargetProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 月間 粗利構成比
            TotalMoney = (double)((Int64)this.GrandGrossProfitWork_TextBox.Value);
            this.GrandCmpProfitRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);


            // 年間 返品率
            TotalMoney = (double)this.GrandAnSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.GrandAnRetGoodsTtlPrice_TextBox.Value;
            this.GrandAnRetGoodsTtlRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 売上達成率
            TotalMoney = (double)this.GrandAnTargetMoney_TextBox.Value;
            TargetMoney = (double)this.GrandAnPureSalesTtlPrice_TextBox.Value;
            //this.SectionAnTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);
            this.GrandAnTargetMoneyRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 売上構成比
            TotalMoney = (double)((Int64)this.GrandAnPureSalesTtlWork_TextBox.Value);
            this.GrandAnCmpPureSalesRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利率
            TotalMoney = (double)this.GrandAnPureSalesTtlPrice_TextBox.Value;
            TargetMoney = (double)this.GrandAnGrossProfitPrice_TextBox.Value;
            this.GrandAnGrossProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利達成率
            TotalMoney = (double)this.GrandAnTargetProfit_TextBox.Value;
            this.GrandAnTargetProfitRate_TextBox.Value = GetRatio(TargetMoney, TotalMoney);

            // 年間 粗利構成比
            TotalMoney = (double)((Int64)this.GrandAnGrossProfitWork_TextBox.Value);
            this.GrandAnCmpProfitRatio_TextBox.Value = GetRatio(TargetMoney, TotalMoney);


        }


        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label ListTitle_Title;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox PrintDate;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox PRINTPAGE;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.TextBox SortTitle;
        private DataDynamics.ActiveReports.TextBox PrintTime;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line4;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.Line Line37;
        private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.TextBox SectionTotal_Title;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Label GrandTotal_Title;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Line Line41;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        /// <summary>
        /// 
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHNB02072P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.RecordName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.SalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.DiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.CmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.CmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.RecordCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Order_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.ListTitle_Title = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PRINTPAGE = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Line_PageFooter = new DataDynamics.ActiveReports.Line();
            this.PageFooters0 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooters1 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.RecordTitle = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.TargetMoneyRate_Title = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.TargetMoney_Title = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.TargetProfit_Title = new DataDynamics.ActiveReports.Label();
            this.TargetProfitRate_Title = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotal_Title = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.GrandSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandPureSalesTtlWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnPureSalesTtlWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandGrossProfitWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GrandAnGrossProfitWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionHeaderT = new DataDynamics.ActiveReports.Label();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionName = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionPureSalesTtlWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnPureSalesTtlWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionGrossProfitWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionAnGrossProfitWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.ReportCodeName = new DataDynamics.ActiveReports.TextBox();
            this.ReportCode = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeaderTitle = new DataDynamics.ActiveReports.Label();
            this.ReportSectionName = new DataDynamics.ActiveReports.TextBox();
            this.ReportSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.ReportSectionTitle = new DataDynamics.ActiveReports.Label();
            this.ReportCodeN = new DataDynamics.ActiveReports.TextBox();
            this.ReportFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.MinAnSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinRetGoodsTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinDiscountTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinPureSalesTtlPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinRetGoodsTtlRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.MinTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnTargetMoneyRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnCmpPureSalesRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.MinPureSalesTtlWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnPureSalesTtlWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnTargetProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnCmpProfitRatio_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinTargetMoney_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnGrossProfitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnTargetProfit_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnGrossProfitRate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinGrossProfitWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MinAnGrossProfitWork_TextBox = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RecordName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTitle_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoneyRate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoney_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfit_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfitRate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandPureSalesTtlWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnPureSalesTtlWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandGrossProfitWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnGrossProfitWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionPureSalesTtlWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnPureSalesTtlWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGrossProfitWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnGrossProfitWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHeaderTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportSectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCodeN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRetGoodsTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinDiscountTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPureSalesTtlPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRetGoodsTtlRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetMoneyRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnCmpPureSalesRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPureSalesTtlWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnPureSalesTtlWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnCmpProfitRatio_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetMoney_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnGrossProfitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetProfit_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnGrossProfitRate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGrossProfitWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnGrossProfitWork_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.RecordName_TextBox,
            this.Line37,
            this.SalesTtlPrice_TextBox,
            this.RetGoodsTtlPrice_TextBox,
            this.DiscountTtlPrice_TextBox,
            this.PureSalesTtlPrice_TextBox,
            this.RetGoodsTtlRate_TextBox,
            this.AnSalesTtlPrice_TextBox,
            this.AnRetGoodsTtlPrice_TextBox,
            this.AnDiscountTtlPrice_TextBox,
            this.AnPureSalesTtlPrice_TextBox,
            this.AnRetGoodsTtlRate_TextBox,
            this.TargetMoneyRate_TextBox,
            this.AnTargetMoneyRate_TextBox,
            this.CmpPureSalesRatio_TextBox,
            this.AnCmpPureSalesRatio_TextBox,
            this.TargetProfitRate_TextBox,
            this.AnTargetProfitRate_TextBox,
            this.CmpProfitRatio_TextBox,
            this.AnCmpProfitRatio_TextBox,
            this.TargetMoney_TextBox,
            this.AnTargetMoney_TextBox,
            this.GrossProfitPrice_TextBox,
            this.AnGrossProfitPrice_TextBox,
            this.TargetProfit_TextBox,
            this.AnTargetProfit_TextBox,
            this.GrossProfitRate_TextBox,
            this.AnGrossProfitRate_TextBox,
            this.RecordCode_TextBox,
            this.Order_TextBox});
            this.Detail.Height = 0.4479167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // RecordName_TextBox
            // 
            this.RecordName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RecordName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RecordName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RecordName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RecordName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordName_TextBox.CanGrow = false;
            this.RecordName_TextBox.DataField = "RecordName";
            this.RecordName_TextBox.Height = 0.156F;
            this.RecordName_TextBox.Left = 1.114583F;
            this.RecordName_TextBox.MultiLine = false;
            this.RecordName_TextBox.Name = "RecordName_TextBox";
            this.RecordName_TextBox.Style = "font-size: 8pt; ";
            this.RecordName_TextBox.Text = "あいうえおかきくけこさしすせそ";
            this.RecordName_TextBox.Top = 0.031F;
            this.RecordName_TextBox.Width = 1.8F;
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
            // SalesTtlPrice_TextBox
            // 
            this.SalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTtlPrice_TextBox.CanShrink = true;
            this.SalesTtlPrice_TextBox.DataField = "SalesTtlPrice";
            this.SalesTtlPrice_TextBox.Height = 0.156F;
            this.SalesTtlPrice_TextBox.Left = 3.11F;
            this.SalesTtlPrice_TextBox.MultiLine = false;
            this.SalesTtlPrice_TextBox.Name = "SalesTtlPrice_TextBox";
            this.SalesTtlPrice_TextBox.OutputFormat = resources.GetString("SalesTtlPrice_TextBox.OutputFormat");
            this.SalesTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SalesTtlPrice_TextBox.Top = 0.031F;
            this.SalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // RetGoodsTtlPrice_TextBox
            // 
            this.RetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlPrice_TextBox.CanShrink = true;
            this.RetGoodsTtlPrice_TextBox.DataField = "RetGoodsTtlPrice";
            this.RetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.RetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.RetGoodsTtlPrice_TextBox.MultiLine = false;
            this.RetGoodsTtlPrice_TextBox.Name = "RetGoodsTtlPrice_TextBox";
            this.RetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("RetGoodsTtlPrice_TextBox.OutputFormat");
            this.RetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.RetGoodsTtlPrice_TextBox.Top = 0.031F;
            this.RetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // DiscountTtlPrice_TextBox
            // 
            this.DiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.DiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.DiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.DiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.DiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountTtlPrice_TextBox.CanShrink = true;
            this.DiscountTtlPrice_TextBox.DataField = "DiscountTtlPrice";
            this.DiscountTtlPrice_TextBox.Height = 0.156F;
            this.DiscountTtlPrice_TextBox.Left = 5.025F;
            this.DiscountTtlPrice_TextBox.MultiLine = false;
            this.DiscountTtlPrice_TextBox.Name = "DiscountTtlPrice_TextBox";
            this.DiscountTtlPrice_TextBox.OutputFormat = resources.GetString("DiscountTtlPrice_TextBox.OutputFormat");
            this.DiscountTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.DiscountTtlPrice_TextBox.Top = 0.031F;
            this.DiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // PureSalesTtlPrice_TextBox
            // 
            this.PureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.PureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.PureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.PureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.PureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesTtlPrice_TextBox.CanShrink = true;
            this.PureSalesTtlPrice_TextBox.DataField = "PureSalesTtlPrice";
            this.PureSalesTtlPrice_TextBox.Height = 0.156F;
            this.PureSalesTtlPrice_TextBox.Left = 5.796F;
            this.PureSalesTtlPrice_TextBox.MultiLine = false;
            this.PureSalesTtlPrice_TextBox.Name = "PureSalesTtlPrice_TextBox";
            this.PureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("PureSalesTtlPrice_TextBox.OutputFormat");
            this.PureSalesTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.PureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.PureSalesTtlPrice_TextBox.Top = 0.031F;
            this.PureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // RetGoodsTtlRate_TextBox
            // 
            this.RetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsTtlRate_TextBox.CanShrink = true;
            this.RetGoodsTtlRate_TextBox.DataField = "RetGoodsTtlRate";
            this.RetGoodsTtlRate_TextBox.Height = 0.156F;
            this.RetGoodsTtlRate_TextBox.Left = 4.65F;
            this.RetGoodsTtlRate_TextBox.MultiLine = false;
            this.RetGoodsTtlRate_TextBox.Name = "RetGoodsTtlRate_TextBox";
            this.RetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("RetGoodsTtlRate_TextBox.OutputFormat");
            this.RetGoodsTtlRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGoodsTtlRate_TextBox.Text = "999.99";
            this.RetGoodsTtlRate_TextBox.Top = 0.031F;
            this.RetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // AnSalesTtlPrice_TextBox
            // 
            this.AnSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnSalesTtlPrice_TextBox.CanShrink = true;
            this.AnSalesTtlPrice_TextBox.DataField = "AnSalesTtlPrice";
            this.AnSalesTtlPrice_TextBox.Height = 0.156F;
            this.AnSalesTtlPrice_TextBox.Left = 3.11F;
            this.AnSalesTtlPrice_TextBox.MultiLine = false;
            this.AnSalesTtlPrice_TextBox.Name = "AnSalesTtlPrice_TextBox";
            this.AnSalesTtlPrice_TextBox.OutputFormat = resources.GetString("AnSalesTtlPrice_TextBox.OutputFormat");
            this.AnSalesTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnSalesTtlPrice_TextBox.Top = 0.187F;
            this.AnSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // AnRetGoodsTtlPrice_TextBox
            // 
            this.AnRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.AnRetGoodsTtlPrice_TextBox.DataField = "AnRetGoodsTtlPrice";
            this.AnRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.AnRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.AnRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.AnRetGoodsTtlPrice_TextBox.Name = "AnRetGoodsTtlPrice_TextBox";
            this.AnRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("AnRetGoodsTtlPrice_TextBox.OutputFormat");
            this.AnRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnRetGoodsTtlPrice_TextBox.Top = 0.187F;
            this.AnRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // AnDiscountTtlPrice_TextBox
            // 
            this.AnDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnDiscountTtlPrice_TextBox.CanShrink = true;
            this.AnDiscountTtlPrice_TextBox.DataField = "AnDiscountTtlPrice";
            this.AnDiscountTtlPrice_TextBox.Height = 0.156F;
            this.AnDiscountTtlPrice_TextBox.Left = 5.025F;
            this.AnDiscountTtlPrice_TextBox.MultiLine = false;
            this.AnDiscountTtlPrice_TextBox.Name = "AnDiscountTtlPrice_TextBox";
            this.AnDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("AnDiscountTtlPrice_TextBox.OutputFormat");
            this.AnDiscountTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnDiscountTtlPrice_TextBox.Top = 0.187F;
            this.AnDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // AnPureSalesTtlPrice_TextBox
            // 
            this.AnPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnPureSalesTtlPrice_TextBox.CanShrink = true;
            this.AnPureSalesTtlPrice_TextBox.DataField = "AnPureSalesTtlPrice";
            this.AnPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.AnPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.AnPureSalesTtlPrice_TextBox.MultiLine = false;
            this.AnPureSalesTtlPrice_TextBox.Name = "AnPureSalesTtlPrice_TextBox";
            this.AnPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("AnPureSalesTtlPrice_TextBox.OutputFormat");
            this.AnPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnPureSalesTtlPrice_TextBox.Top = 0.187F;
            this.AnPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // AnRetGoodsTtlRate_TextBox
            // 
            this.AnRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnRetGoodsTtlRate_TextBox.CanShrink = true;
            this.AnRetGoodsTtlRate_TextBox.DataField = "AnRetGoodsTtlRate";
            this.AnRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.AnRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.AnRetGoodsTtlRate_TextBox.MultiLine = false;
            this.AnRetGoodsTtlRate_TextBox.Name = "AnRetGoodsTtlRate_TextBox";
            this.AnRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("AnRetGoodsTtlRate_TextBox.OutputFormat");
            this.AnRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnRetGoodsTtlRate_TextBox.Text = "999.99";
            this.AnRetGoodsTtlRate_TextBox.Top = 0.187F;
            this.AnRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // TargetMoneyRate_TextBox
            // 
            this.TargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_TextBox.CanShrink = true;
            this.TargetMoneyRate_TextBox.DataField = "TargetMoneyRate";
            this.TargetMoneyRate_TextBox.Height = 0.156F;
            this.TargetMoneyRate_TextBox.Left = 7.335F;
            this.TargetMoneyRate_TextBox.MultiLine = false;
            this.TargetMoneyRate_TextBox.Name = "TargetMoneyRate_TextBox";
            this.TargetMoneyRate_TextBox.OutputFormat = resources.GetString("TargetMoneyRate_TextBox.OutputFormat");
            this.TargetMoneyRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TargetMoneyRate_TextBox.Text = "999.99";
            this.TargetMoneyRate_TextBox.Top = 0.031F;
            this.TargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // AnTargetMoneyRate_TextBox
            // 
            this.AnTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoneyRate_TextBox.CanShrink = true;
            this.AnTargetMoneyRate_TextBox.DataField = "AnTargetMoneyRate";
            this.AnTargetMoneyRate_TextBox.Height = 0.156F;
            this.AnTargetMoneyRate_TextBox.Left = 7.335F;
            this.AnTargetMoneyRate_TextBox.MultiLine = false;
            this.AnTargetMoneyRate_TextBox.Name = "AnTargetMoneyRate_TextBox";
            this.AnTargetMoneyRate_TextBox.OutputFormat = resources.GetString("AnTargetMoneyRate_TextBox.OutputFormat");
            this.AnTargetMoneyRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnTargetMoneyRate_TextBox.Text = "999.99";
            this.AnTargetMoneyRate_TextBox.Top = 0.187F;
            this.AnTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // CmpPureSalesRatio_TextBox
            // 
            this.CmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio_TextBox.CanShrink = true;
            this.CmpPureSalesRatio_TextBox.DataField = "CmpPureSalesRatio";
            this.CmpPureSalesRatio_TextBox.Height = 0.156F;
            this.CmpPureSalesRatio_TextBox.Left = 7.711F;
            this.CmpPureSalesRatio_TextBox.MultiLine = false;
            this.CmpPureSalesRatio_TextBox.Name = "CmpPureSalesRatio_TextBox";
            this.CmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("CmpPureSalesRatio_TextBox.OutputFormat");
            this.CmpPureSalesRatio_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.CmpPureSalesRatio_TextBox.Text = "999.99";
            this.CmpPureSalesRatio_TextBox.Top = 0.031F;
            this.CmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // AnCmpPureSalesRatio_TextBox
            // 
            this.AnCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpPureSalesRatio_TextBox.CanShrink = true;
            this.AnCmpPureSalesRatio_TextBox.DataField = "AnCmpPureSalesRatio";
            this.AnCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.AnCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.AnCmpPureSalesRatio_TextBox.MultiLine = false;
            this.AnCmpPureSalesRatio_TextBox.Name = "AnCmpPureSalesRatio_TextBox";
            this.AnCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("AnCmpPureSalesRatio_TextBox.OutputFormat");
            this.AnCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnCmpPureSalesRatio_TextBox.Text = "999.99";
            this.AnCmpPureSalesRatio_TextBox.Top = 0.187F;
            this.AnCmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // TargetProfitRate_TextBox
            // 
            this.TargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_TextBox.CanShrink = true;
            this.TargetProfitRate_TextBox.DataField = "TargetProfitRate";
            this.TargetProfitRate_TextBox.Height = 0.156F;
            this.TargetProfitRate_TextBox.Left = 10.0005F;
            this.TargetProfitRate_TextBox.MultiLine = false;
            this.TargetProfitRate_TextBox.Name = "TargetProfitRate_TextBox";
            this.TargetProfitRate_TextBox.OutputFormat = resources.GetString("TargetProfitRate_TextBox.OutputFormat");
            this.TargetProfitRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TargetProfitRate_TextBox.Text = "999.99";
            this.TargetProfitRate_TextBox.Top = 0.031F;
            this.TargetProfitRate_TextBox.Width = 0.375F;
            // 
            // AnTargetProfitRate_TextBox
            // 
            this.AnTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfitRate_TextBox.CanShrink = true;
            this.AnTargetProfitRate_TextBox.DataField = "AnTargetProfitRate";
            this.AnTargetProfitRate_TextBox.Height = 0.156F;
            this.AnTargetProfitRate_TextBox.Left = 10.0005F;
            this.AnTargetProfitRate_TextBox.MultiLine = false;
            this.AnTargetProfitRate_TextBox.Name = "AnTargetProfitRate_TextBox";
            this.AnTargetProfitRate_TextBox.OutputFormat = resources.GetString("AnTargetProfitRate_TextBox.OutputFormat");
            this.AnTargetProfitRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnTargetProfitRate_TextBox.Text = "999.99";
            this.AnTargetProfitRate_TextBox.Top = 0.187F;
            this.AnTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // CmpProfitRatio_TextBox
            // 
            this.CmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.CmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.CmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.CmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.CmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio_TextBox.CanShrink = true;
            this.CmpProfitRatio_TextBox.DataField = "CmpProfitRatio";
            this.CmpProfitRatio_TextBox.Height = 0.156F;
            this.CmpProfitRatio_TextBox.Left = 10.375F;
            this.CmpProfitRatio_TextBox.MultiLine = false;
            this.CmpProfitRatio_TextBox.Name = "CmpProfitRatio_TextBox";
            this.CmpProfitRatio_TextBox.OutputFormat = resources.GetString("CmpProfitRatio_TextBox.OutputFormat");
            this.CmpProfitRatio_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.CmpProfitRatio_TextBox.Text = "999.99";
            this.CmpProfitRatio_TextBox.Top = 0.031F;
            this.CmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // AnCmpProfitRatio_TextBox
            // 
            this.AnCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnCmpProfitRatio_TextBox.CanShrink = true;
            this.AnCmpProfitRatio_TextBox.DataField = "AnCmpProfitRatio";
            this.AnCmpProfitRatio_TextBox.Height = 0.156F;
            this.AnCmpProfitRatio_TextBox.Left = 10.375F;
            this.AnCmpProfitRatio_TextBox.MultiLine = false;
            this.AnCmpProfitRatio_TextBox.Name = "AnCmpProfitRatio_TextBox";
            this.AnCmpProfitRatio_TextBox.OutputFormat = resources.GetString("AnCmpProfitRatio_TextBox.OutputFormat");
            this.AnCmpProfitRatio_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnCmpProfitRatio_TextBox.Text = "999.99";
            this.AnCmpProfitRatio_TextBox.Top = 0.187F;
            this.AnCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // TargetMoney_TextBox
            // 
            this.TargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_TextBox.CanShrink = true;
            this.TargetMoney_TextBox.DataField = "TargetMoney";
            this.TargetMoney_TextBox.Height = 0.156F;
            this.TargetMoney_TextBox.Left = 6.565F;
            this.TargetMoney_TextBox.MultiLine = false;
            this.TargetMoney_TextBox.Name = "TargetMoney_TextBox";
            this.TargetMoney_TextBox.OutputFormat = resources.GetString("TargetMoney_TextBox.OutputFormat");
            this.TargetMoney_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.TargetMoney_TextBox.Top = 0.031F;
            this.TargetMoney_TextBox.Width = 0.77F;
            // 
            // AnTargetMoney_TextBox
            // 
            this.AnTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetMoney_TextBox.CanShrink = true;
            this.AnTargetMoney_TextBox.DataField = "AnTargetMoney";
            this.AnTargetMoney_TextBox.Height = 0.156F;
            this.AnTargetMoney_TextBox.Left = 6.565F;
            this.AnTargetMoney_TextBox.MultiLine = false;
            this.AnTargetMoney_TextBox.Name = "AnTargetMoney_TextBox";
            this.AnTargetMoney_TextBox.OutputFormat = resources.GetString("AnTargetMoney_TextBox.OutputFormat");
            this.AnTargetMoney_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnTargetMoney_TextBox.Top = 0.187F;
            this.AnTargetMoney_TextBox.Width = 0.77F;
            // 
            // GrossProfitPrice_TextBox
            // 
            this.GrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrice_TextBox.CanShrink = true;
            this.GrossProfitPrice_TextBox.DataField = "GrossProfitPrice";
            this.GrossProfitPrice_TextBox.Height = 0.156F;
            this.GrossProfitPrice_TextBox.Left = 8.086F;
            this.GrossProfitPrice_TextBox.MultiLine = false;
            this.GrossProfitPrice_TextBox.Name = "GrossProfitPrice_TextBox";
            this.GrossProfitPrice_TextBox.OutputFormat = resources.GetString("GrossProfitPrice_TextBox.OutputFormat");
            this.GrossProfitPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrossProfitPrice_TextBox.Top = 0.031F;
            this.GrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // AnGrossProfitPrice_TextBox
            // 
            this.AnGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitPrice_TextBox.CanShrink = true;
            this.AnGrossProfitPrice_TextBox.DataField = "AnGrossProfitPrice";
            this.AnGrossProfitPrice_TextBox.Height = 0.156F;
            this.AnGrossProfitPrice_TextBox.Left = 8.086F;
            this.AnGrossProfitPrice_TextBox.MultiLine = false;
            this.AnGrossProfitPrice_TextBox.Name = "AnGrossProfitPrice_TextBox";
            this.AnGrossProfitPrice_TextBox.OutputFormat = resources.GetString("AnGrossProfitPrice_TextBox.OutputFormat");
            this.AnGrossProfitPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnGrossProfitPrice_TextBox.Top = 0.187F;
            this.AnGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // TargetProfit_TextBox
            // 
            this.TargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_TextBox.CanShrink = true;
            this.TargetProfit_TextBox.DataField = "TargetProfit";
            this.TargetProfit_TextBox.Height = 0.156F;
            this.TargetProfit_TextBox.Left = 9.231F;
            this.TargetProfit_TextBox.MultiLine = false;
            this.TargetProfit_TextBox.Name = "TargetProfit_TextBox";
            this.TargetProfit_TextBox.OutputFormat = resources.GetString("TargetProfit_TextBox.OutputFormat");
            this.TargetProfit_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.TargetProfit_TextBox.Top = 0.031F;
            this.TargetProfit_TextBox.Width = 0.77F;
            // 
            // AnTargetProfit_TextBox
            // 
            this.AnTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnTargetProfit_TextBox.CanShrink = true;
            this.AnTargetProfit_TextBox.DataField = "AnTargetProfit";
            this.AnTargetProfit_TextBox.Height = 0.156F;
            this.AnTargetProfit_TextBox.Left = 9.231F;
            this.AnTargetProfit_TextBox.MultiLine = false;
            this.AnTargetProfit_TextBox.Name = "AnTargetProfit_TextBox";
            this.AnTargetProfit_TextBox.OutputFormat = resources.GetString("AnTargetProfit_TextBox.OutputFormat");
            this.AnTargetProfit_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.AnTargetProfit_TextBox.Top = 0.187F;
            this.AnTargetProfit_TextBox.Width = 0.77F;
            // 
            // GrossProfitRate_TextBox
            // 
            this.GrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate_TextBox.CanShrink = true;
            this.GrossProfitRate_TextBox.DataField = "GrossProfitRate";
            this.GrossProfitRate_TextBox.Height = 0.156F;
            this.GrossProfitRate_TextBox.Left = 8.856F;
            this.GrossProfitRate_TextBox.MultiLine = false;
            this.GrossProfitRate_TextBox.Name = "GrossProfitRate_TextBox";
            this.GrossProfitRate_TextBox.OutputFormat = resources.GetString("GrossProfitRate_TextBox.OutputFormat");
            this.GrossProfitRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitRate_TextBox.Text = "999.99";
            this.GrossProfitRate_TextBox.Top = 0.031F;
            this.GrossProfitRate_TextBox.Width = 0.375F;
            // 
            // AnGrossProfitRate_TextBox
            // 
            this.AnGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnGrossProfitRate_TextBox.CanShrink = true;
            this.AnGrossProfitRate_TextBox.DataField = "AnGrossProfitRate";
            this.AnGrossProfitRate_TextBox.Height = 0.156F;
            this.AnGrossProfitRate_TextBox.Left = 8.856F;
            this.AnGrossProfitRate_TextBox.MultiLine = false;
            this.AnGrossProfitRate_TextBox.Name = "AnGrossProfitRate_TextBox";
            this.AnGrossProfitRate_TextBox.OutputFormat = resources.GetString("AnGrossProfitRate_TextBox.OutputFormat");
            this.AnGrossProfitRate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.AnGrossProfitRate_TextBox.Text = "999.99";
            this.AnGrossProfitRate_TextBox.Top = 0.187F;
            this.AnGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // RecordCode_TextBox
            // 
            this.RecordCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RecordCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RecordCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RecordCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RecordCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordCode_TextBox.DataField = "RecordCode";
            this.RecordCode_TextBox.Height = 0.156F;
            this.RecordCode_TextBox.Left = 0.531F;
            this.RecordCode_TextBox.MultiLine = false;
            this.RecordCode_TextBox.Name = "RecordCode_TextBox";
            this.RecordCode_TextBox.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.RecordCode_TextBox.Text = "123456789";
            this.RecordCode_TextBox.Top = 0.031F;
            this.RecordCode_TextBox.Width = 0.563F;
            // 
            // Order_TextBox
            // 
            this.Order_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.Order_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.Order_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.Order_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.Order_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order_TextBox.DataField = "Order";
            this.Order_TextBox.Height = 0.156F;
            this.Order_TextBox.Left = 0F;
            this.Order_TextBox.MultiLine = false;
            this.Order_TextBox.Name = "Order_TextBox";
            this.Order_TextBox.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.Order_TextBox.Text = "12345678";
            this.Order_TextBox.Top = 0.03125F;
            this.Order_TextBox.Width = 0.5F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ListTitle_Title,
            this.Label3,
            this.PrintDate,
            this.Label2,
            this.PRINTPAGE,
            this.Line1,
            this.SortTitle,
            this.PrintTime});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // ListTitle_Title
            // 
            this.ListTitle_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.DataField = "ListTitle";
            this.ListTitle_Title.Height = 0.219F;
            this.ListTitle_Title.HyperLink = "";
            this.ListTitle_Title.Left = 0.21875F;
            this.ListTitle_Title.MultiLine = false;
            this.ListTitle_Title.Name = "ListTitle_Title";
            this.ListTitle_Title.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.ListTitle_Title.Text = "売上月報年報";
            this.ListTitle_Title.Top = 0F;
            this.ListTitle_Title.Width = 4.3F;
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
            // PRINTPAGE
            // 
            this.PRINTPAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.CanShrink = true;
            this.PRINTPAGE.Height = 0.15625F;
            this.PRINTPAGE.Left = 10.4375F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.0625F;
            this.PRINTPAGE.Width = 0.28125F;
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
            // SortTitle
            // 
            this.SortTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SortTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SortTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SortTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SortTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.CanShrink = true;
            this.SortTitle.Height = 0.15625F;
            this.SortTitle.Left = 4.5625F;
            this.SortTitle.MultiLine = false;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SortTitle.Text = "[ソート条件]";
            this.SortTitle.Top = 0.0625F;
            this.SortTitle.Width = 2.1875F;
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
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line_PageFooter,
            this.PageFooters0,
            this.PageFooters1});
            this.PageFooter.Height = 0.2291667F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Line_PageFooter
            // 
            this.Line_PageFooter.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.RightColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.TopColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Height = 0F;
            this.Line_PageFooter.Left = 0F;
            this.Line_PageFooter.LineWeight = 2F;
            this.Line_PageFooter.Name = "Line_PageFooter";
            this.Line_PageFooter.Top = 0F;
            this.Line_PageFooter.Width = 10.8F;
            this.Line_PageFooter.X1 = 0F;
            this.Line_PageFooter.X2 = 10.8F;
            this.Line_PageFooter.Y1 = 0F;
            this.Line_PageFooter.Y2 = 0F;
            // 
            // PageFooters0
            // 
            this.PageFooters0.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Height = 0.125F;
            this.PageFooters0.Left = 0F;
            this.PageFooters0.MultiLine = false;
            this.PageFooters0.Name = "PageFooters0";
            this.PageFooters0.OutputFormat = resources.GetString("PageFooters0.OutputFormat");
            this.PageFooters0.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.PageFooters0.Text = null;
            this.PageFooters0.Top = 0F;
            this.PageFooters0.Width = 3F;
            // 
            // PageFooters1
            // 
            this.PageFooters1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Height = 0.125F;
            this.PageFooters1.Left = 7.775F;
            this.PageFooters1.MultiLine = false;
            this.PageFooters1.Name = "PageFooters1";
            this.PageFooters1.OutputFormat = resources.GetString("PageFooters1.OutputFormat");
            this.PageFooters1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PageFooters1.Text = null;
            this.PageFooters1.Top = 0F;
            this.PageFooters1.Width = 3F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
            this.ExtraHeader.KeepTogether = true;
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
            this.Line4,
            this.RecordTitle,
            this.Label8,
            this.Label9,
            this.Label17,
            this.Label,
            this.label4,
            this.TargetMoneyRate_Title,
            this.label1,
            this.TargetMoney_Title,
            this.label7,
            this.TargetProfit_Title,
            this.TargetProfitRate_Title,
            this.label12,
            this.label13,
            this.label5});
            this.TitleHeader.Height = 0.2604167F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0F;
            this.Line4.Left = 0F;
            this.Line4.LineWeight = 2F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 10.8F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 10.8F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0F;
            // 
            // RecordTitle
            // 
            this.RecordTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.RecordTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.RecordTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordTitle.Border.RightColor = System.Drawing.Color.Black;
            this.RecordTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordTitle.Border.TopColor = System.Drawing.Color.Black;
            this.RecordTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RecordTitle.DataField = "RecordTitle";
            this.RecordTitle.Height = 0.156F;
            this.RecordTitle.HyperLink = "";
            this.RecordTitle.Left = 0.53125F;
            this.RecordTitle.Name = "RecordTitle";
            this.RecordTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.RecordTitle.Text = "ＸＸＸ";
            this.RecordTitle.Top = 0.031F;
            this.RecordTitle.Width = 0.626F;
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
            this.Label8.Height = 0.156F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 3.88F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.Label8.Text = "返品";
            this.Label8.Top = 0.031F;
            this.Label8.Width = 0.77F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.156F;
            this.Label9.HyperLink = "";
            this.Label9.Left = 5.025F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.Label9.Text = "値引";
            this.Label9.Top = 0.031F;
            this.Label9.Width = 0.77F;
            // 
            // Label17
            // 
            this.Label17.Border.BottomColor = System.Drawing.Color.Black;
            this.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.LeftColor = System.Drawing.Color.Black;
            this.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.RightColor = System.Drawing.Color.Black;
            this.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.TopColor = System.Drawing.Color.Black;
            this.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Height = 0.156F;
            this.Label17.HyperLink = "";
            this.Label17.Left = 5.796F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.Label17.Text = "純売上";
            this.Label17.Top = 0.031F;
            this.Label17.Width = 0.77F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.156F;
            this.Label.HyperLink = "";
            this.Label.Left = 3.11F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: right; font-weight: bold; font-size: 8pt; white-space: nowrap; vertic" +
                "al-align: top; ";
            this.Label.Text = "売上";
            this.Label.Top = 0.031F;
            this.Label.Width = 0.77F;
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
            this.label4.Height = 0.156F;
            this.label4.HyperLink = "";
            this.label4.Left = 4.65F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.label4.Text = "返品率";
            this.label4.Top = 0.031F;
            this.label4.Width = 0.375F;
            // 
            // TargetMoneyRate_Title
            // 
            this.TargetMoneyRate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.TargetMoneyRate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoneyRate_Title.Height = 0.156F;
            this.TargetMoneyRate_Title.HyperLink = "";
            this.TargetMoneyRate_Title.Left = 7.335F;
            this.TargetMoneyRate_Title.Name = "TargetMoneyRate_Title";
            this.TargetMoneyRate_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.TargetMoneyRate_Title.Text = "達成率";
            this.TargetMoneyRate_Title.Top = 0.031F;
            this.TargetMoneyRate_Title.Width = 0.375F;
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
            this.label1.Height = 0.156F;
            this.label1.HyperLink = "";
            this.label1.Left = 10.375F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.label1.Text = "構成比";
            this.label1.Top = 0.031F;
            this.label1.Width = 0.375F;
            // 
            // TargetMoney_Title
            // 
            this.TargetMoney_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetMoney_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetMoney_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_Title.Border.RightColor = System.Drawing.Color.Black;
            this.TargetMoney_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_Title.Border.TopColor = System.Drawing.Color.Black;
            this.TargetMoney_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetMoney_Title.Height = 0.156F;
            this.TargetMoney_Title.HyperLink = "";
            this.TargetMoney_Title.Left = 6.565F;
            this.TargetMoney_Title.Name = "TargetMoney_Title";
            this.TargetMoney_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.TargetMoney_Title.Text = "売上目標";
            this.TargetMoney_Title.Top = 0.031F;
            this.TargetMoney_Title.Width = 0.77F;
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
            this.label7.Left = 7.711F;
            this.label7.Name = "label7";
            this.label7.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.label7.Text = "構成比";
            this.label7.Top = 0.031F;
            this.label7.Width = 0.375F;
            // 
            // TargetProfit_Title
            // 
            this.TargetProfit_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetProfit_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetProfit_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_Title.Border.RightColor = System.Drawing.Color.Black;
            this.TargetProfit_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_Title.Border.TopColor = System.Drawing.Color.Black;
            this.TargetProfit_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfit_Title.Height = 0.156F;
            this.TargetProfit_Title.HyperLink = "";
            this.TargetProfit_Title.Left = 9.231F;
            this.TargetProfit_Title.Name = "TargetProfit_Title";
            this.TargetProfit_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.TargetProfit_Title.Text = "粗利目標";
            this.TargetProfit_Title.Top = 0.031F;
            this.TargetProfit_Title.Width = 0.77F;
            // 
            // TargetProfitRate_Title
            // 
            this.TargetProfitRate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.TargetProfitRate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.TargetProfitRate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.TargetProfitRate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.TargetProfitRate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TargetProfitRate_Title.Height = 0.156F;
            this.TargetProfitRate_Title.HyperLink = "";
            this.TargetProfitRate_Title.Left = 10.001F;
            this.TargetProfitRate_Title.Name = "TargetProfitRate_Title";
            this.TargetProfitRate_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.TargetProfitRate_Title.Text = "達成率";
            this.TargetProfitRate_Title.Top = 0.031F;
            this.TargetProfitRate_Title.Width = 0.375F;
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
            this.label12.Left = 8.856F;
            this.label12.Name = "label12";
            this.label12.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.label12.Text = "粗利率";
            this.label12.Top = 0.031F;
            this.label12.Width = 0.375F;
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
            this.label13.Left = 8.086F;
            this.label13.Name = "label13";
            this.label13.Style = "text-align: right; font-weight: bold; font-size: 8pt; white-space: nowrap; vertic" +
                "al-align: top; ";
            this.label13.Text = "粗利";
            this.label13.Top = 0.031F;
            this.label13.Width = 0.77F;
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
            this.label5.Left = 0F;
            this.label5.Name = "label5";
            this.label5.Style = "text-align: right; font-weight: bold; font-size: 8pt; white-space: nowrap; vertic" +
                "al-align: top; ";
            this.label5.Text = "順位";
            this.label5.Top = 0.03125F;
            this.label5.Width = 0.5F;
            // 
            // TitleFooter
            // 
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
            this.GrandTotalHeader.KeepTogether = true;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GrandTotal_Title,
            this.Line,
            this.GrandSalesTtlPrice_TextBox,
            this.GrandRetGoodsTtlPrice_TextBox,
            this.GrandDiscountTtlPrice_TextBox,
            this.GrandPureSalesTtlPrice_TextBox,
            this.GrandRetGoodsTtlRate_TextBox,
            this.GrandAnSalesTtlPrice_TextBox,
            this.GrandAnRetGoodsTtlPrice_TextBox,
            this.GrandAnDiscountTtlPrice_TextBox,
            this.GrandAnPureSalesTtlPrice_TextBox,
            this.GrandAnRetGoodsTtlRate_TextBox,
            this.GrandTargetMoneyRate_TextBox,
            this.GrandCmpPureSalesRatio_TextBox,
            this.GrandAnTargetMoneyRate_TextBox,
            this.GrandAnCmpPureSalesRatio_TextBox,
            this.GrandPureSalesTtlWork_TextBox,
            this.GrandAnPureSalesTtlWork_TextBox,
            this.GrandTargetProfitRate_TextBox,
            this.GrandCmpProfitRatio_TextBox,
            this.GrandAnTargetProfitRate_TextBox,
            this.GrandAnCmpProfitRatio_TextBox,
            this.GrandTargetMoney_TextBox,
            this.GrandAnTargetMoney_TextBox,
            this.GrandAnGrossProfitPrice_TextBox,
            this.GrandGrossProfitPrice_TextBox,
            this.GrandAnTargetProfit_TextBox,
            this.GrandTargetProfit_TextBox,
            this.GrandGrossProfitRate_TextBox,
            this.GrandAnGrossProfitRate_TextBox,
            this.GrandGrossProfitWork_TextBox,
            this.GrandAnGrossProfitWork_TextBox});
            this.GrandTotalFooter.Height = 0.4270833F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GrandTotal_Title
            // 
            this.GrandTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Height = 0.2F;
            this.GrandTotal_Title.HyperLink = "";
            this.GrandTotal_Title.Left = 1.688F;
            this.GrandTotal_Title.MultiLine = false;
            this.GrandTotal_Title.Name = "GrandTotal_Title";
            this.GrandTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotal_Title.Text = "総合計";
            this.GrandTotal_Title.Top = 0.025F;
            this.GrandTotal_Title.Width = 0.563F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 10.8F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.8F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // GrandSalesTtlPrice_TextBox
            // 
            this.GrandSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandSalesTtlPrice_TextBox.CanShrink = true;
            this.GrandSalesTtlPrice_TextBox.DataField = "SalesTtlPrice";
            this.GrandSalesTtlPrice_TextBox.Height = 0.156F;
            this.GrandSalesTtlPrice_TextBox.Left = 3.11F;
            this.GrandSalesTtlPrice_TextBox.MultiLine = false;
            this.GrandSalesTtlPrice_TextBox.Name = "GrandSalesTtlPrice_TextBox";
            this.GrandSalesTtlPrice_TextBox.OutputFormat = resources.GetString("GrandSalesTtlPrice_TextBox.OutputFormat");
            this.GrandSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandSalesTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandSalesTtlPrice_TextBox.Top = 0.031F;
            this.GrandSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandRetGoodsTtlPrice_TextBox
            // 
            this.GrandRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.GrandRetGoodsTtlPrice_TextBox.DataField = "RetGoodsTtlPrice";
            this.GrandRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.GrandRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.GrandRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.GrandRetGoodsTtlPrice_TextBox.Name = "GrandRetGoodsTtlPrice_TextBox";
            this.GrandRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("GrandRetGoodsTtlPrice_TextBox.OutputFormat");
            this.GrandRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandRetGoodsTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandRetGoodsTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandRetGoodsTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandRetGoodsTtlPrice_TextBox.Top = 0.031F;
            this.GrandRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandDiscountTtlPrice_TextBox
            // 
            this.GrandDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandDiscountTtlPrice_TextBox.CanShrink = true;
            this.GrandDiscountTtlPrice_TextBox.DataField = "DiscountTtlPrice";
            this.GrandDiscountTtlPrice_TextBox.Height = 0.156F;
            this.GrandDiscountTtlPrice_TextBox.Left = 5.025F;
            this.GrandDiscountTtlPrice_TextBox.MultiLine = false;
            this.GrandDiscountTtlPrice_TextBox.Name = "GrandDiscountTtlPrice_TextBox";
            this.GrandDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("GrandDiscountTtlPrice_TextBox.OutputFormat");
            this.GrandDiscountTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandDiscountTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandDiscountTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandDiscountTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandDiscountTtlPrice_TextBox.Top = 0.031F;
            this.GrandDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandPureSalesTtlPrice_TextBox
            // 
            this.GrandPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlPrice_TextBox.CanShrink = true;
            this.GrandPureSalesTtlPrice_TextBox.DataField = "PureSalesTtlPrice";
            this.GrandPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.GrandPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.GrandPureSalesTtlPrice_TextBox.MultiLine = false;
            this.GrandPureSalesTtlPrice_TextBox.Name = "GrandPureSalesTtlPrice_TextBox";
            this.GrandPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("GrandPureSalesTtlPrice_TextBox.OutputFormat");
            this.GrandPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandPureSalesTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandPureSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandPureSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandPureSalesTtlPrice_TextBox.Top = 0.031F;
            this.GrandPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandRetGoodsTtlRate_TextBox
            // 
            this.GrandRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandRetGoodsTtlRate_TextBox.CanShrink = true;
            this.GrandRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.GrandRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.GrandRetGoodsTtlRate_TextBox.MultiLine = false;
            this.GrandRetGoodsTtlRate_TextBox.Name = "GrandRetGoodsTtlRate_TextBox";
            this.GrandRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("GrandRetGoodsTtlRate_TextBox.OutputFormat");
            this.GrandRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandRetGoodsTtlRate_TextBox.Text = "999.99";
            this.GrandRetGoodsTtlRate_TextBox.Top = 0.031F;
            this.GrandRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // GrandAnSalesTtlPrice_TextBox
            // 
            this.GrandAnSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnSalesTtlPrice_TextBox.CanShrink = true;
            this.GrandAnSalesTtlPrice_TextBox.DataField = "AnSalesTtlPrice";
            this.GrandAnSalesTtlPrice_TextBox.Height = 0.156F;
            this.GrandAnSalesTtlPrice_TextBox.Left = 3.11F;
            this.GrandAnSalesTtlPrice_TextBox.MultiLine = false;
            this.GrandAnSalesTtlPrice_TextBox.Name = "GrandAnSalesTtlPrice_TextBox";
            this.GrandAnSalesTtlPrice_TextBox.OutputFormat = resources.GetString("GrandAnSalesTtlPrice_TextBox.OutputFormat");
            this.GrandAnSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnSalesTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnSalesTtlPrice_TextBox.Top = 0.187F;
            this.GrandAnSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandAnRetGoodsTtlPrice_TextBox
            // 
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.GrandAnRetGoodsTtlPrice_TextBox.DataField = "AnRetGoodsTtlPrice";
            this.GrandAnRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.GrandAnRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.GrandAnRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.GrandAnRetGoodsTtlPrice_TextBox.Name = "GrandAnRetGoodsTtlPrice_TextBox";
            this.GrandAnRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("GrandAnRetGoodsTtlPrice_TextBox.OutputFormat");
            this.GrandAnRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnRetGoodsTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnRetGoodsTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnRetGoodsTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnRetGoodsTtlPrice_TextBox.Top = 0.187F;
            this.GrandAnRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandAnDiscountTtlPrice_TextBox
            // 
            this.GrandAnDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnDiscountTtlPrice_TextBox.CanShrink = true;
            this.GrandAnDiscountTtlPrice_TextBox.DataField = "AnDiscountTtlPrice";
            this.GrandAnDiscountTtlPrice_TextBox.Height = 0.156F;
            this.GrandAnDiscountTtlPrice_TextBox.Left = 5.025F;
            this.GrandAnDiscountTtlPrice_TextBox.MultiLine = false;
            this.GrandAnDiscountTtlPrice_TextBox.Name = "GrandAnDiscountTtlPrice_TextBox";
            this.GrandAnDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("GrandAnDiscountTtlPrice_TextBox.OutputFormat");
            this.GrandAnDiscountTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnDiscountTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnDiscountTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnDiscountTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnDiscountTtlPrice_TextBox.Top = 0.187F;
            this.GrandAnDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandAnPureSalesTtlPrice_TextBox
            // 
            this.GrandAnPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlPrice_TextBox.CanShrink = true;
            this.GrandAnPureSalesTtlPrice_TextBox.DataField = "AnPureSalesTtlPrice";
            this.GrandAnPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.GrandAnPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.GrandAnPureSalesTtlPrice_TextBox.MultiLine = false;
            this.GrandAnPureSalesTtlPrice_TextBox.Name = "GrandAnPureSalesTtlPrice_TextBox";
            this.GrandAnPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("GrandAnPureSalesTtlPrice_TextBox.OutputFormat");
            this.GrandAnPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnPureSalesTtlPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnPureSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnPureSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnPureSalesTtlPrice_TextBox.Top = 0.187F;
            this.GrandAnPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // GrandAnRetGoodsTtlRate_TextBox
            // 
            this.GrandAnRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnRetGoodsTtlRate_TextBox.CanShrink = true;
            this.GrandAnRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.GrandAnRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.GrandAnRetGoodsTtlRate_TextBox.MultiLine = false;
            this.GrandAnRetGoodsTtlRate_TextBox.Name = "GrandAnRetGoodsTtlRate_TextBox";
            this.GrandAnRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("GrandAnRetGoodsTtlRate_TextBox.OutputFormat");
            this.GrandAnRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnRetGoodsTtlRate_TextBox.Text = "999.99";
            this.GrandAnRetGoodsTtlRate_TextBox.Top = 0.187F;
            this.GrandAnRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // GrandTargetMoneyRate_TextBox
            // 
            this.GrandTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoneyRate_TextBox.CanShrink = true;
            this.GrandTargetMoneyRate_TextBox.Height = 0.156F;
            this.GrandTargetMoneyRate_TextBox.Left = 7.335F;
            this.GrandTargetMoneyRate_TextBox.MultiLine = false;
            this.GrandTargetMoneyRate_TextBox.Name = "GrandTargetMoneyRate_TextBox";
            this.GrandTargetMoneyRate_TextBox.OutputFormat = resources.GetString("GrandTargetMoneyRate_TextBox.OutputFormat");
            this.GrandTargetMoneyRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTargetMoneyRate_TextBox.Text = "999.99";
            this.GrandTargetMoneyRate_TextBox.Top = 0.031F;
            this.GrandTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // GrandCmpPureSalesRatio_TextBox
            // 
            this.GrandCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpPureSalesRatio_TextBox.CanShrink = true;
            this.GrandCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.GrandCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.GrandCmpPureSalesRatio_TextBox.MultiLine = false;
            this.GrandCmpPureSalesRatio_TextBox.Name = "GrandCmpPureSalesRatio_TextBox";
            this.GrandCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("GrandCmpPureSalesRatio_TextBox.OutputFormat");
            this.GrandCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandCmpPureSalesRatio_TextBox.Text = "999.99";
            this.GrandCmpPureSalesRatio_TextBox.Top = 0.031F;
            this.GrandCmpPureSalesRatio_TextBox.Visible = false;
            this.GrandCmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // GrandAnTargetMoneyRate_TextBox
            // 
            this.GrandAnTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoneyRate_TextBox.CanShrink = true;
            this.GrandAnTargetMoneyRate_TextBox.Height = 0.156F;
            this.GrandAnTargetMoneyRate_TextBox.Left = 7.335F;
            this.GrandAnTargetMoneyRate_TextBox.MultiLine = false;
            this.GrandAnTargetMoneyRate_TextBox.Name = "GrandAnTargetMoneyRate_TextBox";
            this.GrandAnTargetMoneyRate_TextBox.OutputFormat = resources.GetString("GrandAnTargetMoneyRate_TextBox.OutputFormat");
            this.GrandAnTargetMoneyRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnTargetMoneyRate_TextBox.Text = "999.99";
            this.GrandAnTargetMoneyRate_TextBox.Top = 0.187F;
            this.GrandAnTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // GrandAnCmpPureSalesRatio_TextBox
            // 
            this.GrandAnCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpPureSalesRatio_TextBox.CanShrink = true;
            this.GrandAnCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.GrandAnCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.GrandAnCmpPureSalesRatio_TextBox.MultiLine = false;
            this.GrandAnCmpPureSalesRatio_TextBox.Name = "GrandAnCmpPureSalesRatio_TextBox";
            this.GrandAnCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("GrandAnCmpPureSalesRatio_TextBox.OutputFormat");
            this.GrandAnCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnCmpPureSalesRatio_TextBox.Text = "999.99";
            this.GrandAnCmpPureSalesRatio_TextBox.Top = 0.187F;
            this.GrandAnCmpPureSalesRatio_TextBox.Visible = false;
            this.GrandAnCmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // GrandPureSalesTtlWork_TextBox
            // 
            this.GrandPureSalesTtlWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandPureSalesTtlWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandPureSalesTtlWork_TextBox.CanShrink = true;
            this.GrandPureSalesTtlWork_TextBox.DataField = "PureSalesTtlWork";
            this.GrandPureSalesTtlWork_TextBox.Height = 0.125F;
            this.GrandPureSalesTtlWork_TextBox.Left = 0F;
            this.GrandPureSalesTtlWork_TextBox.MultiLine = false;
            this.GrandPureSalesTtlWork_TextBox.Name = "GrandPureSalesTtlWork_TextBox";
            this.GrandPureSalesTtlWork_TextBox.OutputFormat = resources.GetString("GrandPureSalesTtlWork_TextBox.OutputFormat");
            this.GrandPureSalesTtlWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandPureSalesTtlWork_TextBox.Text = "10,234,567,890";
            this.GrandPureSalesTtlWork_TextBox.Top = 0.031F;
            this.GrandPureSalesTtlWork_TextBox.Visible = false;
            this.GrandPureSalesTtlWork_TextBox.Width = 0.813F;
            // 
            // GrandAnPureSalesTtlWork_TextBox
            // 
            this.GrandAnPureSalesTtlWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnPureSalesTtlWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnPureSalesTtlWork_TextBox.CanShrink = true;
            this.GrandAnPureSalesTtlWork_TextBox.DataField = "AnPureSalesTtlWork";
            this.GrandAnPureSalesTtlWork_TextBox.Height = 0.125F;
            this.GrandAnPureSalesTtlWork_TextBox.Left = 0F;
            this.GrandAnPureSalesTtlWork_TextBox.MultiLine = false;
            this.GrandAnPureSalesTtlWork_TextBox.Name = "GrandAnPureSalesTtlWork_TextBox";
            this.GrandAnPureSalesTtlWork_TextBox.OutputFormat = resources.GetString("GrandAnPureSalesTtlWork_TextBox.OutputFormat");
            this.GrandAnPureSalesTtlWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnPureSalesTtlWork_TextBox.Text = "10,234,567,890";
            this.GrandAnPureSalesTtlWork_TextBox.Top = 0.156F;
            this.GrandAnPureSalesTtlWork_TextBox.Visible = false;
            this.GrandAnPureSalesTtlWork_TextBox.Width = 0.813F;
            // 
            // GrandTargetProfitRate_TextBox
            // 
            this.GrandTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfitRate_TextBox.CanShrink = true;
            this.GrandTargetProfitRate_TextBox.Height = 0.156F;
            this.GrandTargetProfitRate_TextBox.Left = 10.011F;
            this.GrandTargetProfitRate_TextBox.MultiLine = false;
            this.GrandTargetProfitRate_TextBox.Name = "GrandTargetProfitRate_TextBox";
            this.GrandTargetProfitRate_TextBox.OutputFormat = resources.GetString("GrandTargetProfitRate_TextBox.OutputFormat");
            this.GrandTargetProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTargetProfitRate_TextBox.Text = "999.99";
            this.GrandTargetProfitRate_TextBox.Top = 0.031F;
            this.GrandTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // GrandCmpProfitRatio_TextBox
            // 
            this.GrandCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandCmpProfitRatio_TextBox.CanShrink = true;
            this.GrandCmpProfitRatio_TextBox.Height = 0.156F;
            this.GrandCmpProfitRatio_TextBox.Left = 10.385F;
            this.GrandCmpProfitRatio_TextBox.MultiLine = false;
            this.GrandCmpProfitRatio_TextBox.Name = "GrandCmpProfitRatio_TextBox";
            this.GrandCmpProfitRatio_TextBox.OutputFormat = resources.GetString("GrandCmpProfitRatio_TextBox.OutputFormat");
            this.GrandCmpProfitRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandCmpProfitRatio_TextBox.Text = "999.99";
            this.GrandCmpProfitRatio_TextBox.Top = 0.031F;
            this.GrandCmpProfitRatio_TextBox.Visible = false;
            this.GrandCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // GrandAnTargetProfitRate_TextBox
            // 
            this.GrandAnTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfitRate_TextBox.CanShrink = true;
            this.GrandAnTargetProfitRate_TextBox.Height = 0.156F;
            this.GrandAnTargetProfitRate_TextBox.Left = 10.011F;
            this.GrandAnTargetProfitRate_TextBox.MultiLine = false;
            this.GrandAnTargetProfitRate_TextBox.Name = "GrandAnTargetProfitRate_TextBox";
            this.GrandAnTargetProfitRate_TextBox.OutputFormat = resources.GetString("GrandAnTargetProfitRate_TextBox.OutputFormat");
            this.GrandAnTargetProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnTargetProfitRate_TextBox.Text = "999.99";
            this.GrandAnTargetProfitRate_TextBox.Top = 0.187F;
            this.GrandAnTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // GrandAnCmpProfitRatio_TextBox
            // 
            this.GrandAnCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnCmpProfitRatio_TextBox.CanShrink = true;
            this.GrandAnCmpProfitRatio_TextBox.Height = 0.156F;
            this.GrandAnCmpProfitRatio_TextBox.Left = 10.385F;
            this.GrandAnCmpProfitRatio_TextBox.MultiLine = false;
            this.GrandAnCmpProfitRatio_TextBox.Name = "GrandAnCmpProfitRatio_TextBox";
            this.GrandAnCmpProfitRatio_TextBox.OutputFormat = resources.GetString("GrandAnCmpProfitRatio_TextBox.OutputFormat");
            this.GrandAnCmpProfitRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnCmpProfitRatio_TextBox.Text = "999.99";
            this.GrandAnCmpProfitRatio_TextBox.Top = 0.187F;
            this.GrandAnCmpProfitRatio_TextBox.Visible = false;
            this.GrandAnCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // GrandTargetMoney_TextBox
            // 
            this.GrandTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetMoney_TextBox.CanShrink = true;
            this.GrandTargetMoney_TextBox.DataField = "TargetMoney";
            this.GrandTargetMoney_TextBox.Height = 0.156F;
            this.GrandTargetMoney_TextBox.Left = 6.565F;
            this.GrandTargetMoney_TextBox.MultiLine = false;
            this.GrandTargetMoney_TextBox.Name = "GrandTargetMoney_TextBox";
            this.GrandTargetMoney_TextBox.OutputFormat = resources.GetString("GrandTargetMoney_TextBox.OutputFormat");
            this.GrandTargetMoney_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTargetMoney_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandTargetMoney_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTargetMoney_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandTargetMoney_TextBox.Top = 0.031F;
            this.GrandTargetMoney_TextBox.Width = 0.77F;
            // 
            // GrandAnTargetMoney_TextBox
            // 
            this.GrandAnTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetMoney_TextBox.CanShrink = true;
            this.GrandAnTargetMoney_TextBox.DataField = "AnTargetMoney";
            this.GrandAnTargetMoney_TextBox.Height = 0.156F;
            this.GrandAnTargetMoney_TextBox.Left = 6.565F;
            this.GrandAnTargetMoney_TextBox.MultiLine = false;
            this.GrandAnTargetMoney_TextBox.Name = "GrandAnTargetMoney_TextBox";
            this.GrandAnTargetMoney_TextBox.OutputFormat = resources.GetString("GrandAnTargetMoney_TextBox.OutputFormat");
            this.GrandAnTargetMoney_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnTargetMoney_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnTargetMoney_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnTargetMoney_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnTargetMoney_TextBox.Top = 0.187F;
            this.GrandAnTargetMoney_TextBox.Width = 0.77F;
            // 
            // GrandAnGrossProfitPrice_TextBox
            // 
            this.GrandAnGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitPrice_TextBox.CanShrink = true;
            this.GrandAnGrossProfitPrice_TextBox.DataField = "AnGrossProfitPrice";
            this.GrandAnGrossProfitPrice_TextBox.Height = 0.156F;
            this.GrandAnGrossProfitPrice_TextBox.Left = 8.086F;
            this.GrandAnGrossProfitPrice_TextBox.MultiLine = false;
            this.GrandAnGrossProfitPrice_TextBox.Name = "GrandAnGrossProfitPrice_TextBox";
            this.GrandAnGrossProfitPrice_TextBox.OutputFormat = resources.GetString("GrandAnGrossProfitPrice_TextBox.OutputFormat");
            this.GrandAnGrossProfitPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnGrossProfitPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnGrossProfitPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnGrossProfitPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnGrossProfitPrice_TextBox.Top = 0.187F;
            this.GrandAnGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // GrandGrossProfitPrice_TextBox
            // 
            this.GrandGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitPrice_TextBox.CanShrink = true;
            this.GrandGrossProfitPrice_TextBox.DataField = "GrossProfitPrice";
            this.GrandGrossProfitPrice_TextBox.Height = 0.156F;
            this.GrandGrossProfitPrice_TextBox.Left = 8.086F;
            this.GrandGrossProfitPrice_TextBox.MultiLine = false;
            this.GrandGrossProfitPrice_TextBox.Name = "GrandGrossProfitPrice_TextBox";
            this.GrandGrossProfitPrice_TextBox.OutputFormat = resources.GetString("GrandGrossProfitPrice_TextBox.OutputFormat");
            this.GrandGrossProfitPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandGrossProfitPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandGrossProfitPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandGrossProfitPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandGrossProfitPrice_TextBox.Top = 0.031F;
            this.GrandGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // GrandAnTargetProfit_TextBox
            // 
            this.GrandAnTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnTargetProfit_TextBox.CanShrink = true;
            this.GrandAnTargetProfit_TextBox.DataField = "AnTargetProfit";
            this.GrandAnTargetProfit_TextBox.Height = 0.156F;
            this.GrandAnTargetProfit_TextBox.Left = 9.231F;
            this.GrandAnTargetProfit_TextBox.MultiLine = false;
            this.GrandAnTargetProfit_TextBox.Name = "GrandAnTargetProfit_TextBox";
            this.GrandAnTargetProfit_TextBox.OutputFormat = resources.GetString("GrandAnTargetProfit_TextBox.OutputFormat");
            this.GrandAnTargetProfit_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnTargetProfit_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandAnTargetProfit_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandAnTargetProfit_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandAnTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandAnTargetProfit_TextBox.Top = 0.187F;
            this.GrandAnTargetProfit_TextBox.Width = 0.77F;
            // 
            // GrandTargetProfit_TextBox
            // 
            this.GrandTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTargetProfit_TextBox.CanShrink = true;
            this.GrandTargetProfit_TextBox.DataField = "TargetProfit";
            this.GrandTargetProfit_TextBox.Height = 0.156F;
            this.GrandTargetProfit_TextBox.Left = 9.231F;
            this.GrandTargetProfit_TextBox.MultiLine = false;
            this.GrandTargetProfit_TextBox.Name = "GrandTargetProfit_TextBox";
            this.GrandTargetProfit_TextBox.OutputFormat = resources.GetString("GrandTargetProfit_TextBox.OutputFormat");
            this.GrandTargetProfit_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTargetProfit_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandTargetProfit_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTargetProfit_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.GrandTargetProfit_TextBox.Top = 0.031F;
            this.GrandTargetProfit_TextBox.Width = 0.77F;
            // 
            // GrandGrossProfitRate_TextBox
            // 
            this.GrandGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitRate_TextBox.CanShrink = true;
            this.GrandGrossProfitRate_TextBox.Height = 0.156F;
            this.GrandGrossProfitRate_TextBox.Left = 8.856F;
            this.GrandGrossProfitRate_TextBox.MultiLine = false;
            this.GrandGrossProfitRate_TextBox.Name = "GrandGrossProfitRate_TextBox";
            this.GrandGrossProfitRate_TextBox.OutputFormat = resources.GetString("GrandGrossProfitRate_TextBox.OutputFormat");
            this.GrandGrossProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandGrossProfitRate_TextBox.Text = "999.99";
            this.GrandGrossProfitRate_TextBox.Top = 0.031F;
            this.GrandGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // GrandAnGrossProfitRate_TextBox
            // 
            this.GrandAnGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitRate_TextBox.CanShrink = true;
            this.GrandAnGrossProfitRate_TextBox.Height = 0.156F;
            this.GrandAnGrossProfitRate_TextBox.Left = 8.856F;
            this.GrandAnGrossProfitRate_TextBox.MultiLine = false;
            this.GrandAnGrossProfitRate_TextBox.Name = "GrandAnGrossProfitRate_TextBox";
            this.GrandAnGrossProfitRate_TextBox.OutputFormat = resources.GetString("GrandAnGrossProfitRate_TextBox.OutputFormat");
            this.GrandAnGrossProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnGrossProfitRate_TextBox.Text = "999.99";
            this.GrandAnGrossProfitRate_TextBox.Top = 0.187F;
            this.GrandAnGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // GrandGrossProfitWork_TextBox
            // 
            this.GrandGrossProfitWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandGrossProfitWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandGrossProfitWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandGrossProfitWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandGrossProfitWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandGrossProfitWork_TextBox.CanShrink = true;
            this.GrandGrossProfitWork_TextBox.DataField = "GrossProfitWork";
            this.GrandGrossProfitWork_TextBox.Height = 0.125F;
            this.GrandGrossProfitWork_TextBox.Left = 0.813F;
            this.GrandGrossProfitWork_TextBox.MultiLine = false;
            this.GrandGrossProfitWork_TextBox.Name = "GrandGrossProfitWork_TextBox";
            this.GrandGrossProfitWork_TextBox.OutputFormat = resources.GetString("GrandGrossProfitWork_TextBox.OutputFormat");
            this.GrandGrossProfitWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandGrossProfitWork_TextBox.Text = "10,234,567,890";
            this.GrandGrossProfitWork_TextBox.Top = 0.031F;
            this.GrandGrossProfitWork_TextBox.Visible = false;
            this.GrandGrossProfitWork_TextBox.Width = 0.813F;
            // 
            // GrandAnGrossProfitWork_TextBox
            // 
            this.GrandAnGrossProfitWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandAnGrossProfitWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandAnGrossProfitWork_TextBox.CanShrink = true;
            this.GrandAnGrossProfitWork_TextBox.DataField = "AnGrossProfitWork";
            this.GrandAnGrossProfitWork_TextBox.Height = 0.125F;
            this.GrandAnGrossProfitWork_TextBox.Left = 0.813F;
            this.GrandAnGrossProfitWork_TextBox.MultiLine = false;
            this.GrandAnGrossProfitWork_TextBox.Name = "GrandAnGrossProfitWork_TextBox";
            this.GrandAnGrossProfitWork_TextBox.OutputFormat = resources.GetString("GrandAnGrossProfitWork_TextBox.OutputFormat");
            this.GrandAnGrossProfitWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandAnGrossProfitWork_TextBox.Text = "10,234,567,890";
            this.GrandAnGrossProfitWork_TextBox.Top = 0.156F;
            this.GrandAnGrossProfitWork_TextBox.Visible = false;
            this.GrandAnGrossProfitWork_TextBox.Width = 0.813F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionHeaderT,
            this.SectionCode,
            this.SectionName});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.1979167F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Visible = false;
            // 
            // SectionHeaderT
            // 
            this.SectionHeaderT.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionHeaderT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderT.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionHeaderT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderT.Border.RightColor = System.Drawing.Color.Black;
            this.SectionHeaderT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderT.Border.TopColor = System.Drawing.Color.Black;
            this.SectionHeaderT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderT.DataField = "SectionTitle";
            this.SectionHeaderT.Height = 0.156F;
            this.SectionHeaderT.HyperLink = "";
            this.SectionHeaderT.Left = 0.063F;
            this.SectionHeaderT.MultiLine = false;
            this.SectionHeaderT.Name = "SectionHeaderT";
            this.SectionHeaderT.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.SectionHeaderT.Text = "拠点";
            this.SectionHeaderT.Top = 0.012F;
            this.SectionHeaderT.Width = 0.313F;
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
            this.SectionCode.Height = 0.156F;
            this.SectionCode.Left = 0.438F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.SectionCode.Text = "12";
            this.SectionCode.Top = 0.012F;
            this.SectionCode.Width = 0.2F;
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
            this.SectionName.Height = 0.156F;
            this.SectionName.Left = 0.6979167F;
            this.SectionName.MultiLine = false;
            this.SectionName.Name = "SectionName";
            this.SectionName.Style = "font-size: 8pt; ";
            this.SectionName.Text = "あいうえおか";
            this.SectionName.Top = 0.012F;
            this.SectionName.Width = 2F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SectionTotal_Title,
            this.SectionAnSalesTtlPrice_TextBox,
            this.SectionAnRetGoodsTtlPrice_TextBox,
            this.SectionAnDiscountTtlPrice_TextBox,
            this.SectionAnPureSalesTtlPrice_TextBox,
            this.SectionAnRetGoodsTtlRate_TextBox,
            this.SectionSalesTtlPrice_TextBox,
            this.SectionRetGoodsTtlPrice_TextBox,
            this.SectionDiscountTtlPrice_TextBox,
            this.SectionPureSalesTtlPrice_TextBox,
            this.SectionRetGoodsTtlRate_TextBox,
            this.SectionTargetMoneyRate_TextBox,
            this.SectionCmpPureSalesRatio_TextBox,
            this.SectionAnTargetMoneyRate_TextBox,
            this.SectionAnCmpPureSalesRatio_TextBox,
            this.SectionPureSalesTtlWork_TextBox,
            this.SectionAnPureSalesTtlWork_TextBox,
            this.SectionTargetProfitRate_TextBox,
            this.SectionCmpProfitRatio_TextBox,
            this.SectionAnTargetProfitRate_TextBox,
            this.SectionAnCmpProfitRatio_TextBox,
            this.SectionAnTargetMoney_TextBox,
            this.SectionTargetMoney_TextBox,
            this.SectionAnGrossProfitPrice_TextBox,
            this.SectionGrossProfitPrice_TextBox,
            this.SectionAnTargetProfit_TextBox,
            this.SectionTargetProfit_TextBox,
            this.SectionGrossProfitRate_TextBox,
            this.SectionAnGrossProfitRate_TextBox,
            this.SectionGrossProfitWork_TextBox,
            this.SectionAnGrossProfitWork_TextBox});
            this.SectionFooter.Height = 0.4791667F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
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
            this.Line45.Width = 10.8F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // SectionTotal_Title
            // 
            this.SectionTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTotal_Title.Height = 0.2F;
            this.SectionTotal_Title.Left = 1.688F;
            this.SectionTotal_Title.MultiLine = false;
            this.SectionTotal_Title.Name = "SectionTotal_Title";
            this.SectionTotal_Title.OutputFormat = resources.GetString("SectionTotal_Title.OutputFormat");
            this.SectionTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTotal_Title.Text = "拠点計";
            this.SectionTotal_Title.Top = 0.025F;
            this.SectionTotal_Title.Width = 0.563F;
            // 
            // SectionAnSalesTtlPrice_TextBox
            // 
            this.SectionAnSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnSalesTtlPrice_TextBox.CanShrink = true;
            this.SectionAnSalesTtlPrice_TextBox.DataField = "AnSalesTtlPrice";
            this.SectionAnSalesTtlPrice_TextBox.Height = 0.156F;
            this.SectionAnSalesTtlPrice_TextBox.Left = 3.11F;
            this.SectionAnSalesTtlPrice_TextBox.MultiLine = false;
            this.SectionAnSalesTtlPrice_TextBox.Name = "SectionAnSalesTtlPrice_TextBox";
            this.SectionAnSalesTtlPrice_TextBox.OutputFormat = resources.GetString("SectionAnSalesTtlPrice_TextBox.OutputFormat");
            this.SectionAnSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnSalesTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnSalesTtlPrice_TextBox.Top = 0.187F;
            this.SectionAnSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionAnRetGoodsTtlPrice_TextBox
            // 
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.SectionAnRetGoodsTtlPrice_TextBox.DataField = "AnRetGoodsTtlPrice";
            this.SectionAnRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.SectionAnRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.SectionAnRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.SectionAnRetGoodsTtlPrice_TextBox.Name = "SectionAnRetGoodsTtlPrice_TextBox";
            this.SectionAnRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("SectionAnRetGoodsTtlPrice_TextBox.OutputFormat");
            this.SectionAnRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnRetGoodsTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnRetGoodsTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnRetGoodsTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnRetGoodsTtlPrice_TextBox.Top = 0.187F;
            this.SectionAnRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionAnDiscountTtlPrice_TextBox
            // 
            this.SectionAnDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnDiscountTtlPrice_TextBox.CanShrink = true;
            this.SectionAnDiscountTtlPrice_TextBox.DataField = "AnDiscountTtlPrice";
            this.SectionAnDiscountTtlPrice_TextBox.Height = 0.156F;
            this.SectionAnDiscountTtlPrice_TextBox.Left = 5.025F;
            this.SectionAnDiscountTtlPrice_TextBox.MultiLine = false;
            this.SectionAnDiscountTtlPrice_TextBox.Name = "SectionAnDiscountTtlPrice_TextBox";
            this.SectionAnDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("SectionAnDiscountTtlPrice_TextBox.OutputFormat");
            this.SectionAnDiscountTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnDiscountTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnDiscountTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnDiscountTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnDiscountTtlPrice_TextBox.Top = 0.187F;
            this.SectionAnDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionAnPureSalesTtlPrice_TextBox
            // 
            this.SectionAnPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlPrice_TextBox.CanShrink = true;
            this.SectionAnPureSalesTtlPrice_TextBox.DataField = "AnPureSalesTtlPrice";
            this.SectionAnPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.SectionAnPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.SectionAnPureSalesTtlPrice_TextBox.MultiLine = false;
            this.SectionAnPureSalesTtlPrice_TextBox.Name = "SectionAnPureSalesTtlPrice_TextBox";
            this.SectionAnPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("SectionAnPureSalesTtlPrice_TextBox.OutputFormat");
            this.SectionAnPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnPureSalesTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnPureSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnPureSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnPureSalesTtlPrice_TextBox.Top = 0.187F;
            this.SectionAnPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionAnRetGoodsTtlRate_TextBox
            // 
            this.SectionAnRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnRetGoodsTtlRate_TextBox.CanShrink = true;
            this.SectionAnRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.SectionAnRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.SectionAnRetGoodsTtlRate_TextBox.MultiLine = false;
            this.SectionAnRetGoodsTtlRate_TextBox.Name = "SectionAnRetGoodsTtlRate_TextBox";
            this.SectionAnRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("SectionAnRetGoodsTtlRate_TextBox.OutputFormat");
            this.SectionAnRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnRetGoodsTtlRate_TextBox.Text = "999.99";
            this.SectionAnRetGoodsTtlRate_TextBox.Top = 0.187F;
            this.SectionAnRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // SectionSalesTtlPrice_TextBox
            // 
            this.SectionSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionSalesTtlPrice_TextBox.CanShrink = true;
            this.SectionSalesTtlPrice_TextBox.DataField = "SalesTtlPrice";
            this.SectionSalesTtlPrice_TextBox.Height = 0.156F;
            this.SectionSalesTtlPrice_TextBox.Left = 3.11F;
            this.SectionSalesTtlPrice_TextBox.MultiLine = false;
            this.SectionSalesTtlPrice_TextBox.Name = "SectionSalesTtlPrice_TextBox";
            this.SectionSalesTtlPrice_TextBox.OutputFormat = resources.GetString("SectionSalesTtlPrice_TextBox.OutputFormat");
            this.SectionSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionSalesTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionSalesTtlPrice_TextBox.Top = 0.031F;
            this.SectionSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionRetGoodsTtlPrice_TextBox
            // 
            this.SectionRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.SectionRetGoodsTtlPrice_TextBox.DataField = "RetGoodsTtlPrice";
            this.SectionRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.SectionRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.SectionRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.SectionRetGoodsTtlPrice_TextBox.Name = "SectionRetGoodsTtlPrice_TextBox";
            this.SectionRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("SectionRetGoodsTtlPrice_TextBox.OutputFormat");
            this.SectionRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionRetGoodsTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionRetGoodsTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionRetGoodsTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionRetGoodsTtlPrice_TextBox.Top = 0.031F;
            this.SectionRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionDiscountTtlPrice_TextBox
            // 
            this.SectionDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionDiscountTtlPrice_TextBox.CanShrink = true;
            this.SectionDiscountTtlPrice_TextBox.DataField = "DiscountTtlPrice";
            this.SectionDiscountTtlPrice_TextBox.Height = 0.156F;
            this.SectionDiscountTtlPrice_TextBox.Left = 5.025F;
            this.SectionDiscountTtlPrice_TextBox.MultiLine = false;
            this.SectionDiscountTtlPrice_TextBox.Name = "SectionDiscountTtlPrice_TextBox";
            this.SectionDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("SectionDiscountTtlPrice_TextBox.OutputFormat");
            this.SectionDiscountTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionDiscountTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionDiscountTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionDiscountTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionDiscountTtlPrice_TextBox.Top = 0.031F;
            this.SectionDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionPureSalesTtlPrice_TextBox
            // 
            this.SectionPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlPrice_TextBox.CanShrink = true;
            this.SectionPureSalesTtlPrice_TextBox.DataField = "PureSalesTtlPrice";
            this.SectionPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.SectionPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.SectionPureSalesTtlPrice_TextBox.MultiLine = false;
            this.SectionPureSalesTtlPrice_TextBox.Name = "SectionPureSalesTtlPrice_TextBox";
            this.SectionPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("SectionPureSalesTtlPrice_TextBox.OutputFormat");
            this.SectionPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionPureSalesTtlPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionPureSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionPureSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionPureSalesTtlPrice_TextBox.Top = 0.031F;
            this.SectionPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // SectionRetGoodsTtlRate_TextBox
            // 
            this.SectionRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionRetGoodsTtlRate_TextBox.CanShrink = true;
            this.SectionRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.SectionRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.SectionRetGoodsTtlRate_TextBox.MultiLine = false;
            this.SectionRetGoodsTtlRate_TextBox.Name = "SectionRetGoodsTtlRate_TextBox";
            this.SectionRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("SectionRetGoodsTtlRate_TextBox.OutputFormat");
            this.SectionRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionRetGoodsTtlRate_TextBox.Text = "999.99";
            this.SectionRetGoodsTtlRate_TextBox.Top = 0.031F;
            this.SectionRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // SectionTargetMoneyRate_TextBox
            // 
            this.SectionTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoneyRate_TextBox.CanShrink = true;
            this.SectionTargetMoneyRate_TextBox.Height = 0.156F;
            this.SectionTargetMoneyRate_TextBox.Left = 7.335F;
            this.SectionTargetMoneyRate_TextBox.MultiLine = false;
            this.SectionTargetMoneyRate_TextBox.Name = "SectionTargetMoneyRate_TextBox";
            this.SectionTargetMoneyRate_TextBox.OutputFormat = resources.GetString("SectionTargetMoneyRate_TextBox.OutputFormat");
            this.SectionTargetMoneyRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionTargetMoneyRate_TextBox.Text = "999.99";
            this.SectionTargetMoneyRate_TextBox.Top = 0.031F;
            this.SectionTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // SectionCmpPureSalesRatio_TextBox
            // 
            this.SectionCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpPureSalesRatio_TextBox.CanShrink = true;
            this.SectionCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.SectionCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.SectionCmpPureSalesRatio_TextBox.MultiLine = false;
            this.SectionCmpPureSalesRatio_TextBox.Name = "SectionCmpPureSalesRatio_TextBox";
            this.SectionCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("SectionCmpPureSalesRatio_TextBox.OutputFormat");
            this.SectionCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionCmpPureSalesRatio_TextBox.Text = "999.99";
            this.SectionCmpPureSalesRatio_TextBox.Top = 0.031F;
            this.SectionCmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // SectionAnTargetMoneyRate_TextBox
            // 
            this.SectionAnTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoneyRate_TextBox.CanShrink = true;
            this.SectionAnTargetMoneyRate_TextBox.Height = 0.156F;
            this.SectionAnTargetMoneyRate_TextBox.Left = 7.335F;
            this.SectionAnTargetMoneyRate_TextBox.MultiLine = false;
            this.SectionAnTargetMoneyRate_TextBox.Name = "SectionAnTargetMoneyRate_TextBox";
            this.SectionAnTargetMoneyRate_TextBox.OutputFormat = resources.GetString("SectionAnTargetMoneyRate_TextBox.OutputFormat");
            this.SectionAnTargetMoneyRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnTargetMoneyRate_TextBox.Text = "999.99";
            this.SectionAnTargetMoneyRate_TextBox.Top = 0.187F;
            this.SectionAnTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // SectionAnCmpPureSalesRatio_TextBox
            // 
            this.SectionAnCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpPureSalesRatio_TextBox.CanShrink = true;
            this.SectionAnCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.SectionAnCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.SectionAnCmpPureSalesRatio_TextBox.MultiLine = false;
            this.SectionAnCmpPureSalesRatio_TextBox.Name = "SectionAnCmpPureSalesRatio_TextBox";
            this.SectionAnCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("SectionAnCmpPureSalesRatio_TextBox.OutputFormat");
            this.SectionAnCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnCmpPureSalesRatio_TextBox.Text = "999.99";
            this.SectionAnCmpPureSalesRatio_TextBox.Top = 0.187F;
            this.SectionAnCmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // SectionPureSalesTtlWork_TextBox
            // 
            this.SectionPureSalesTtlWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionPureSalesTtlWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionPureSalesTtlWork_TextBox.CanShrink = true;
            this.SectionPureSalesTtlWork_TextBox.DataField = "PureSalesTtlWork";
            this.SectionPureSalesTtlWork_TextBox.Height = 0.125F;
            this.SectionPureSalesTtlWork_TextBox.Left = 0F;
            this.SectionPureSalesTtlWork_TextBox.MultiLine = false;
            this.SectionPureSalesTtlWork_TextBox.Name = "SectionPureSalesTtlWork_TextBox";
            this.SectionPureSalesTtlWork_TextBox.OutputFormat = resources.GetString("SectionPureSalesTtlWork_TextBox.OutputFormat");
            this.SectionPureSalesTtlWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionPureSalesTtlWork_TextBox.Text = "10,234,567,890";
            this.SectionPureSalesTtlWork_TextBox.Top = 0.031F;
            this.SectionPureSalesTtlWork_TextBox.Visible = false;
            this.SectionPureSalesTtlWork_TextBox.Width = 0.813F;
            // 
            // SectionAnPureSalesTtlWork_TextBox
            // 
            this.SectionAnPureSalesTtlWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnPureSalesTtlWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnPureSalesTtlWork_TextBox.CanShrink = true;
            this.SectionAnPureSalesTtlWork_TextBox.DataField = "AnPureSalesTtlWork";
            this.SectionAnPureSalesTtlWork_TextBox.Height = 0.125F;
            this.SectionAnPureSalesTtlWork_TextBox.Left = 0F;
            this.SectionAnPureSalesTtlWork_TextBox.MultiLine = false;
            this.SectionAnPureSalesTtlWork_TextBox.Name = "SectionAnPureSalesTtlWork_TextBox";
            this.SectionAnPureSalesTtlWork_TextBox.OutputFormat = resources.GetString("SectionAnPureSalesTtlWork_TextBox.OutputFormat");
            this.SectionAnPureSalesTtlWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnPureSalesTtlWork_TextBox.Text = "10,234,567,890";
            this.SectionAnPureSalesTtlWork_TextBox.Top = 0.156F;
            this.SectionAnPureSalesTtlWork_TextBox.Visible = false;
            this.SectionAnPureSalesTtlWork_TextBox.Width = 0.813F;
            // 
            // SectionTargetProfitRate_TextBox
            // 
            this.SectionTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfitRate_TextBox.CanShrink = true;
            this.SectionTargetProfitRate_TextBox.Height = 0.156F;
            this.SectionTargetProfitRate_TextBox.Left = 10.011F;
            this.SectionTargetProfitRate_TextBox.MultiLine = false;
            this.SectionTargetProfitRate_TextBox.Name = "SectionTargetProfitRate_TextBox";
            this.SectionTargetProfitRate_TextBox.OutputFormat = resources.GetString("SectionTargetProfitRate_TextBox.OutputFormat");
            this.SectionTargetProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionTargetProfitRate_TextBox.Text = "999.99";
            this.SectionTargetProfitRate_TextBox.Top = 0.031F;
            this.SectionTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // SectionCmpProfitRatio_TextBox
            // 
            this.SectionCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCmpProfitRatio_TextBox.CanShrink = true;
            this.SectionCmpProfitRatio_TextBox.Height = 0.156F;
            this.SectionCmpProfitRatio_TextBox.Left = 10.385F;
            this.SectionCmpProfitRatio_TextBox.MultiLine = false;
            this.SectionCmpProfitRatio_TextBox.Name = "SectionCmpProfitRatio_TextBox";
            this.SectionCmpProfitRatio_TextBox.OutputFormat = resources.GetString("SectionCmpProfitRatio_TextBox.OutputFormat");
            this.SectionCmpProfitRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionCmpProfitRatio_TextBox.Text = "999.99";
            this.SectionCmpProfitRatio_TextBox.Top = 0.031F;
            this.SectionCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // SectionAnTargetProfitRate_TextBox
            // 
            this.SectionAnTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfitRate_TextBox.CanShrink = true;
            this.SectionAnTargetProfitRate_TextBox.Height = 0.156F;
            this.SectionAnTargetProfitRate_TextBox.Left = 10.011F;
            this.SectionAnTargetProfitRate_TextBox.MultiLine = false;
            this.SectionAnTargetProfitRate_TextBox.Name = "SectionAnTargetProfitRate_TextBox";
            this.SectionAnTargetProfitRate_TextBox.OutputFormat = resources.GetString("SectionAnTargetProfitRate_TextBox.OutputFormat");
            this.SectionAnTargetProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnTargetProfitRate_TextBox.Text = "999.99";
            this.SectionAnTargetProfitRate_TextBox.Top = 0.187F;
            this.SectionAnTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // SectionAnCmpProfitRatio_TextBox
            // 
            this.SectionAnCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnCmpProfitRatio_TextBox.CanShrink = true;
            this.SectionAnCmpProfitRatio_TextBox.Height = 0.156F;
            this.SectionAnCmpProfitRatio_TextBox.Left = 10.385F;
            this.SectionAnCmpProfitRatio_TextBox.MultiLine = false;
            this.SectionAnCmpProfitRatio_TextBox.Name = "SectionAnCmpProfitRatio_TextBox";
            this.SectionAnCmpProfitRatio_TextBox.OutputFormat = resources.GetString("SectionAnCmpProfitRatio_TextBox.OutputFormat");
            this.SectionAnCmpProfitRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnCmpProfitRatio_TextBox.Text = "999.99";
            this.SectionAnCmpProfitRatio_TextBox.Top = 0.187F;
            this.SectionAnCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // SectionAnTargetMoney_TextBox
            // 
            this.SectionAnTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetMoney_TextBox.CanShrink = true;
            this.SectionAnTargetMoney_TextBox.DataField = "AnSectionTargetMoney";
            this.SectionAnTargetMoney_TextBox.Height = 0.156F;
            this.SectionAnTargetMoney_TextBox.Left = 6.565F;
            this.SectionAnTargetMoney_TextBox.MultiLine = false;
            this.SectionAnTargetMoney_TextBox.Name = "SectionAnTargetMoney_TextBox";
            this.SectionAnTargetMoney_TextBox.OutputFormat = resources.GetString("SectionAnTargetMoney_TextBox.OutputFormat");
            this.SectionAnTargetMoney_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnTargetMoney_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnTargetMoney_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnTargetMoney_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnTargetMoney_TextBox.Top = 0.187F;
            this.SectionAnTargetMoney_TextBox.Width = 0.77F;
            // 
            // SectionTargetMoney_TextBox
            // 
            this.SectionTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetMoney_TextBox.CanShrink = true;
            this.SectionTargetMoney_TextBox.DataField = "SectionTargetMoney";
            this.SectionTargetMoney_TextBox.Height = 0.156F;
            this.SectionTargetMoney_TextBox.Left = 6.565F;
            this.SectionTargetMoney_TextBox.MultiLine = false;
            this.SectionTargetMoney_TextBox.Name = "SectionTargetMoney_TextBox";
            this.SectionTargetMoney_TextBox.OutputFormat = resources.GetString("SectionTargetMoney_TextBox.OutputFormat");
            this.SectionTargetMoney_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionTargetMoney_TextBox.SummaryGroup = "SectionHeader";
            this.SectionTargetMoney_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionTargetMoney_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionTargetMoney_TextBox.Top = 0.031F;
            this.SectionTargetMoney_TextBox.Width = 0.77F;
            // 
            // SectionAnGrossProfitPrice_TextBox
            // 
            this.SectionAnGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitPrice_TextBox.CanShrink = true;
            this.SectionAnGrossProfitPrice_TextBox.DataField = "AnGrossProfitPrice";
            this.SectionAnGrossProfitPrice_TextBox.Height = 0.156F;
            this.SectionAnGrossProfitPrice_TextBox.Left = 8.086F;
            this.SectionAnGrossProfitPrice_TextBox.MultiLine = false;
            this.SectionAnGrossProfitPrice_TextBox.Name = "SectionAnGrossProfitPrice_TextBox";
            this.SectionAnGrossProfitPrice_TextBox.OutputFormat = resources.GetString("SectionAnGrossProfitPrice_TextBox.OutputFormat");
            this.SectionAnGrossProfitPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnGrossProfitPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnGrossProfitPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnGrossProfitPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnGrossProfitPrice_TextBox.Top = 0.187F;
            this.SectionAnGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // SectionGrossProfitPrice_TextBox
            // 
            this.SectionGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitPrice_TextBox.CanShrink = true;
            this.SectionGrossProfitPrice_TextBox.DataField = "GrossProfitPrice";
            this.SectionGrossProfitPrice_TextBox.Height = 0.156F;
            this.SectionGrossProfitPrice_TextBox.Left = 8.086F;
            this.SectionGrossProfitPrice_TextBox.MultiLine = false;
            this.SectionGrossProfitPrice_TextBox.Name = "SectionGrossProfitPrice_TextBox";
            this.SectionGrossProfitPrice_TextBox.OutputFormat = resources.GetString("SectionGrossProfitPrice_TextBox.OutputFormat");
            this.SectionGrossProfitPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionGrossProfitPrice_TextBox.SummaryGroup = "SectionHeader";
            this.SectionGrossProfitPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionGrossProfitPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionGrossProfitPrice_TextBox.Top = 0.031F;
            this.SectionGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // SectionAnTargetProfit_TextBox
            // 
            this.SectionAnTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnTargetProfit_TextBox.CanShrink = true;
            this.SectionAnTargetProfit_TextBox.DataField = "AnSectionTargetProfit";
            this.SectionAnTargetProfit_TextBox.Height = 0.156F;
            this.SectionAnTargetProfit_TextBox.Left = 9.231F;
            this.SectionAnTargetProfit_TextBox.MultiLine = false;
            this.SectionAnTargetProfit_TextBox.Name = "SectionAnTargetProfit_TextBox";
            this.SectionAnTargetProfit_TextBox.OutputFormat = resources.GetString("SectionAnTargetProfit_TextBox.OutputFormat");
            this.SectionAnTargetProfit_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnTargetProfit_TextBox.SummaryGroup = "SectionHeader";
            this.SectionAnTargetProfit_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionAnTargetProfit_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionAnTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionAnTargetProfit_TextBox.Top = 0.187F;
            this.SectionAnTargetProfit_TextBox.Width = 0.77F;
            // 
            // SectionTargetProfit_TextBox
            // 
            this.SectionTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTargetProfit_TextBox.CanShrink = true;
            this.SectionTargetProfit_TextBox.DataField = "SectionTargetProfit";
            this.SectionTargetProfit_TextBox.Height = 0.156F;
            this.SectionTargetProfit_TextBox.Left = 9.231F;
            this.SectionTargetProfit_TextBox.MultiLine = false;
            this.SectionTargetProfit_TextBox.Name = "SectionTargetProfit_TextBox";
            this.SectionTargetProfit_TextBox.OutputFormat = resources.GetString("SectionTargetProfit_TextBox.OutputFormat");
            this.SectionTargetProfit_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionTargetProfit_TextBox.SummaryGroup = "SectionHeader";
            this.SectionTargetProfit_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SectionTargetProfit_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SectionTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.SectionTargetProfit_TextBox.Top = 0.031F;
            this.SectionTargetProfit_TextBox.Width = 0.77F;
            // 
            // SectionGrossProfitRate_TextBox
            // 
            this.SectionGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitRate_TextBox.CanShrink = true;
            this.SectionGrossProfitRate_TextBox.Height = 0.156F;
            this.SectionGrossProfitRate_TextBox.Left = 8.856F;
            this.SectionGrossProfitRate_TextBox.MultiLine = false;
            this.SectionGrossProfitRate_TextBox.Name = "SectionGrossProfitRate_TextBox";
            this.SectionGrossProfitRate_TextBox.OutputFormat = resources.GetString("SectionGrossProfitRate_TextBox.OutputFormat");
            this.SectionGrossProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionGrossProfitRate_TextBox.Text = "999.99";
            this.SectionGrossProfitRate_TextBox.Top = 0.031F;
            this.SectionGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // SectionAnGrossProfitRate_TextBox
            // 
            this.SectionAnGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitRate_TextBox.CanShrink = true;
            this.SectionAnGrossProfitRate_TextBox.Height = 0.156F;
            this.SectionAnGrossProfitRate_TextBox.Left = 8.856F;
            this.SectionAnGrossProfitRate_TextBox.MultiLine = false;
            this.SectionAnGrossProfitRate_TextBox.Name = "SectionAnGrossProfitRate_TextBox";
            this.SectionAnGrossProfitRate_TextBox.OutputFormat = resources.GetString("SectionAnGrossProfitRate_TextBox.OutputFormat");
            this.SectionAnGrossProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnGrossProfitRate_TextBox.Text = "999.99";
            this.SectionAnGrossProfitRate_TextBox.Top = 0.187F;
            this.SectionAnGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // SectionGrossProfitWork_TextBox
            // 
            this.SectionGrossProfitWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGrossProfitWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGrossProfitWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGrossProfitWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGrossProfitWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGrossProfitWork_TextBox.CanShrink = true;
            this.SectionGrossProfitWork_TextBox.DataField = "GrossProfitWork";
            this.SectionGrossProfitWork_TextBox.Height = 0.125F;
            this.SectionGrossProfitWork_TextBox.Left = 0.813F;
            this.SectionGrossProfitWork_TextBox.MultiLine = false;
            this.SectionGrossProfitWork_TextBox.Name = "SectionGrossProfitWork_TextBox";
            this.SectionGrossProfitWork_TextBox.OutputFormat = resources.GetString("SectionGrossProfitWork_TextBox.OutputFormat");
            this.SectionGrossProfitWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionGrossProfitWork_TextBox.Text = "10,234,567,890";
            this.SectionGrossProfitWork_TextBox.Top = 0.031F;
            this.SectionGrossProfitWork_TextBox.Visible = false;
            this.SectionGrossProfitWork_TextBox.Width = 0.813F;
            // 
            // SectionAnGrossProfitWork_TextBox
            // 
            this.SectionAnGrossProfitWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionAnGrossProfitWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionAnGrossProfitWork_TextBox.CanShrink = true;
            this.SectionAnGrossProfitWork_TextBox.DataField = "AnGrossProfitWork";
            this.SectionAnGrossProfitWork_TextBox.Height = 0.125F;
            this.SectionAnGrossProfitWork_TextBox.Left = 0.813F;
            this.SectionAnGrossProfitWork_TextBox.MultiLine = false;
            this.SectionAnGrossProfitWork_TextBox.Name = "SectionAnGrossProfitWork_TextBox";
            this.SectionAnGrossProfitWork_TextBox.OutputFormat = resources.GetString("SectionAnGrossProfitWork_TextBox.OutputFormat");
            this.SectionAnGrossProfitWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SectionAnGrossProfitWork_TextBox.Text = "10,234,567,890";
            this.SectionAnGrossProfitWork_TextBox.Top = 0.156F;
            this.SectionAnGrossProfitWork_TextBox.Visible = false;
            this.SectionAnGrossProfitWork_TextBox.Width = 0.813F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.CanShrink = true;
            this.ReportHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ReportCodeName,
            this.ReportCode,
            this.ReportHeaderTitle,
            this.ReportSectionName,
            this.ReportSectionCode,
            this.ReportSectionTitle,
            this.ReportCodeN});
            this.ReportHeader.DataField = "Code";
            this.ReportHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.ReportHeader.Height = 0.3854167F;
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.ReportHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.ReportHeader.Visible = false;
            this.ReportHeader.BeforePrint += new System.EventHandler(this.ReportHeader_BeforePrint);
            // 
            // ReportCodeName
            // 
            this.ReportCodeName.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportCodeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeName.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportCodeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeName.Border.RightColor = System.Drawing.Color.Black;
            this.ReportCodeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeName.Border.TopColor = System.Drawing.Color.Black;
            this.ReportCodeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeName.DataField = "Name";
            this.ReportCodeName.Height = 0.156F;
            this.ReportCodeName.Left = 1.125F;
            this.ReportCodeName.MultiLine = false;
            this.ReportCodeName.Name = "ReportCodeName";
            this.ReportCodeName.Style = "font-size: 8pt; ";
            this.ReportCodeName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.ReportCodeName.Top = 0.012F;
            this.ReportCodeName.Width = 2.313F;
            // 
            // ReportCode
            // 
            this.ReportCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCode.Border.RightColor = System.Drawing.Color.Black;
            this.ReportCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCode.Border.TopColor = System.Drawing.Color.Black;
            this.ReportCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCode.DataField = "Code";
            this.ReportCode.Height = 0.156F;
            this.ReportCode.Left = 0.5F;
            this.ReportCode.MultiLine = false;
            this.ReportCode.Name = "ReportCode";
            this.ReportCode.OutputFormat = resources.GetString("ReportCode.OutputFormat");
            this.ReportCode.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.ReportCode.Text = "123456789";
            this.ReportCode.Top = 0.1875F;
            this.ReportCode.Visible = false;
            this.ReportCode.Width = 0.563F;
            // 
            // ReportHeaderTitle
            // 
            this.ReportHeaderTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportHeaderTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportHeaderTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportHeaderTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportHeaderTitle.Border.RightColor = System.Drawing.Color.Black;
            this.ReportHeaderTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportHeaderTitle.Border.TopColor = System.Drawing.Color.Black;
            this.ReportHeaderTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportHeaderTitle.Height = 0.156F;
            this.ReportHeaderTitle.HyperLink = "";
            this.ReportHeaderTitle.Left = 0.063F;
            this.ReportHeaderTitle.MultiLine = false;
            this.ReportHeaderTitle.Name = "ReportHeaderTitle";
            this.ReportHeaderTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.ReportHeaderTitle.Text = "得意先";
            this.ReportHeaderTitle.Top = 0.012F;
            this.ReportHeaderTitle.Width = 0.375F;
            // 
            // ReportSectionName
            // 
            this.ReportSectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportSectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportSectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionName.Border.RightColor = System.Drawing.Color.Black;
            this.ReportSectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionName.Border.TopColor = System.Drawing.Color.Black;
            this.ReportSectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionName.DataField = "SectionName";
            this.ReportSectionName.Height = 0.156F;
            this.ReportSectionName.Left = 4.188F;
            this.ReportSectionName.MultiLine = false;
            this.ReportSectionName.Name = "ReportSectionName";
            this.ReportSectionName.Style = "font-size: 8pt; ";
            this.ReportSectionName.Text = "あいうえおか";
            this.ReportSectionName.Top = 0.012F;
            this.ReportSectionName.Visible = false;
            this.ReportSectionName.Width = 2F;
            // 
            // ReportSectionCode
            // 
            this.ReportSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.ReportSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.ReportSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionCode.DataField = "SectionCode";
            this.ReportSectionCode.Height = 0.156F;
            this.ReportSectionCode.Left = 3.938F;
            this.ReportSectionCode.MultiLine = false;
            this.ReportSectionCode.Name = "ReportSectionCode";
            this.ReportSectionCode.OutputFormat = resources.GetString("ReportSectionCode.OutputFormat");
            this.ReportSectionCode.Style = "font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.ReportSectionCode.Text = "12";
            this.ReportSectionCode.Top = 0.012F;
            this.ReportSectionCode.Visible = false;
            this.ReportSectionCode.Width = 0.2F;
            // 
            // ReportSectionTitle
            // 
            this.ReportSectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportSectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportSectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.ReportSectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.ReportSectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportSectionTitle.DataField = "SectionTitle";
            this.ReportSectionTitle.Height = 0.156F;
            this.ReportSectionTitle.HyperLink = "";
            this.ReportSectionTitle.Left = 3.563F;
            this.ReportSectionTitle.MultiLine = false;
            this.ReportSectionTitle.Name = "ReportSectionTitle";
            this.ReportSectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" +
                "ign: top; ";
            this.ReportSectionTitle.Text = "拠点";
            this.ReportSectionTitle.Top = 0.012F;
            this.ReportSectionTitle.Visible = false;
            this.ReportSectionTitle.Width = 0.313F;
            // 
            // ReportCodeN
            // 
            this.ReportCodeN.Border.BottomColor = System.Drawing.Color.Black;
            this.ReportCodeN.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeN.Border.LeftColor = System.Drawing.Color.Black;
            this.ReportCodeN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeN.Border.RightColor = System.Drawing.Color.Black;
            this.ReportCodeN.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeN.Border.TopColor = System.Drawing.Color.Black;
            this.ReportCodeN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReportCodeN.DataField = "Code";
            this.ReportCodeN.Height = 0.156F;
            this.ReportCodeN.Left = 0.5F;
            this.ReportCodeN.MultiLine = false;
            this.ReportCodeN.Name = "ReportCodeN";
            this.ReportCodeN.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.ReportCodeN.Text = "123456789";
            this.ReportCodeN.Top = 0.012F;
            this.ReportCodeN.Width = 0.563F;
            // 
            // ReportFooter
            // 
            this.ReportFooter.CanShrink = true;
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.MinAnSalesTtlPrice_TextBox,
            this.MinAnRetGoodsTtlPrice_TextBox,
            this.MinAnDiscountTtlPrice_TextBox,
            this.MinAnPureSalesTtlPrice_TextBox,
            this.MinAnRetGoodsTtlRate_TextBox,
            this.MinSalesTtlPrice_TextBox,
            this.MinRetGoodsTtlPrice_TextBox,
            this.MinDiscountTtlPrice_TextBox,
            this.MinPureSalesTtlPrice_TextBox,
            this.MinRetGoodsTtlRate_TextBox,
            this.MinTotal_Title,
            this.MinTargetMoneyRate_TextBox,
            this.MinAnTargetMoneyRate_TextBox,
            this.MinCmpPureSalesRatio_TextBox,
            this.MinAnCmpPureSalesRatio_TextBox,
            this.line2,
            this.MinPureSalesTtlWork_TextBox,
            this.MinAnPureSalesTtlWork_TextBox,
            this.MinTargetProfitRate_TextBox,
            this.MinAnTargetProfitRate_TextBox,
            this.MinCmpProfitRatio_TextBox,
            this.MinAnCmpProfitRatio_TextBox,
            this.MinAnTargetMoney_TextBox,
            this.MinTargetMoney_TextBox,
            this.MinGrossProfitPrice_TextBox,
            this.MinAnGrossProfitPrice_TextBox,
            this.MinTargetProfit_TextBox,
            this.MinAnTargetProfit_TextBox,
            this.MinGrossProfitRate_TextBox,
            this.MinAnGrossProfitRate_TextBox,
            this.MinGrossProfitWork_TextBox,
            this.MinAnGrossProfitWork_TextBox});
            this.ReportFooter.Height = 0.4270833F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Visible = false;
            this.ReportFooter.BeforePrint += new System.EventHandler(this.ReportFooter_BeforePrint);
            // 
            // MinAnSalesTtlPrice_TextBox
            // 
            this.MinAnSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnSalesTtlPrice_TextBox.CanShrink = true;
            this.MinAnSalesTtlPrice_TextBox.DataField = "AnSalesTtlPrice";
            this.MinAnSalesTtlPrice_TextBox.Height = 0.156F;
            this.MinAnSalesTtlPrice_TextBox.Left = 3.11F;
            this.MinAnSalesTtlPrice_TextBox.MultiLine = false;
            this.MinAnSalesTtlPrice_TextBox.Name = "MinAnSalesTtlPrice_TextBox";
            this.MinAnSalesTtlPrice_TextBox.OutputFormat = resources.GetString("MinAnSalesTtlPrice_TextBox.OutputFormat");
            this.MinAnSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnSalesTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnSalesTtlPrice_TextBox.Top = 0.187F;
            this.MinAnSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinAnRetGoodsTtlPrice_TextBox
            // 
            this.MinAnRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.MinAnRetGoodsTtlPrice_TextBox.DataField = "AnRetGoodsTtlPrice";
            this.MinAnRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.MinAnRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.MinAnRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.MinAnRetGoodsTtlPrice_TextBox.Name = "MinAnRetGoodsTtlPrice_TextBox";
            this.MinAnRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("MinAnRetGoodsTtlPrice_TextBox.OutputFormat");
            this.MinAnRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnRetGoodsTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnRetGoodsTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnRetGoodsTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnRetGoodsTtlPrice_TextBox.Top = 0.187F;
            this.MinAnRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinAnDiscountTtlPrice_TextBox
            // 
            this.MinAnDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnDiscountTtlPrice_TextBox.CanShrink = true;
            this.MinAnDiscountTtlPrice_TextBox.DataField = "AnDiscountTtlPrice";
            this.MinAnDiscountTtlPrice_TextBox.Height = 0.156F;
            this.MinAnDiscountTtlPrice_TextBox.Left = 5.025F;
            this.MinAnDiscountTtlPrice_TextBox.MultiLine = false;
            this.MinAnDiscountTtlPrice_TextBox.Name = "MinAnDiscountTtlPrice_TextBox";
            this.MinAnDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("MinAnDiscountTtlPrice_TextBox.OutputFormat");
            this.MinAnDiscountTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnDiscountTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnDiscountTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnDiscountTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnDiscountTtlPrice_TextBox.Top = 0.187F;
            this.MinAnDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinAnPureSalesTtlPrice_TextBox
            // 
            this.MinAnPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlPrice_TextBox.CanShrink = true;
            this.MinAnPureSalesTtlPrice_TextBox.DataField = "AnPureSalesTtlPrice";
            this.MinAnPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.MinAnPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.MinAnPureSalesTtlPrice_TextBox.MultiLine = false;
            this.MinAnPureSalesTtlPrice_TextBox.Name = "MinAnPureSalesTtlPrice_TextBox";
            this.MinAnPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("MinAnPureSalesTtlPrice_TextBox.OutputFormat");
            this.MinAnPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnPureSalesTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnPureSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnPureSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnPureSalesTtlPrice_TextBox.Top = 0.187F;
            this.MinAnPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinAnRetGoodsTtlRate_TextBox
            // 
            this.MinAnRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnRetGoodsTtlRate_TextBox.CanShrink = true;
            this.MinAnRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.MinAnRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.MinAnRetGoodsTtlRate_TextBox.MultiLine = false;
            this.MinAnRetGoodsTtlRate_TextBox.Name = "MinAnRetGoodsTtlRate_TextBox";
            this.MinAnRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("MinAnRetGoodsTtlRate_TextBox.OutputFormat");
            this.MinAnRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnRetGoodsTtlRate_TextBox.Text = "999.99";
            this.MinAnRetGoodsTtlRate_TextBox.Top = 0.187F;
            this.MinAnRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // MinSalesTtlPrice_TextBox
            // 
            this.MinSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinSalesTtlPrice_TextBox.CanShrink = true;
            this.MinSalesTtlPrice_TextBox.DataField = "SalesTtlPrice";
            this.MinSalesTtlPrice_TextBox.Height = 0.156F;
            this.MinSalesTtlPrice_TextBox.Left = 3.11F;
            this.MinSalesTtlPrice_TextBox.MultiLine = false;
            this.MinSalesTtlPrice_TextBox.Name = "MinSalesTtlPrice_TextBox";
            this.MinSalesTtlPrice_TextBox.OutputFormat = resources.GetString("MinSalesTtlPrice_TextBox.OutputFormat");
            this.MinSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinSalesTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinSalesTtlPrice_TextBox.Top = 0.031F;
            this.MinSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinRetGoodsTtlPrice_TextBox
            // 
            this.MinRetGoodsTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlPrice_TextBox.CanShrink = true;
            this.MinRetGoodsTtlPrice_TextBox.DataField = "RetGoodsTtlPrice";
            this.MinRetGoodsTtlPrice_TextBox.Height = 0.156F;
            this.MinRetGoodsTtlPrice_TextBox.Left = 3.88F;
            this.MinRetGoodsTtlPrice_TextBox.MultiLine = false;
            this.MinRetGoodsTtlPrice_TextBox.Name = "MinRetGoodsTtlPrice_TextBox";
            this.MinRetGoodsTtlPrice_TextBox.OutputFormat = resources.GetString("MinRetGoodsTtlPrice_TextBox.OutputFormat");
            this.MinRetGoodsTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinRetGoodsTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinRetGoodsTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinRetGoodsTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinRetGoodsTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinRetGoodsTtlPrice_TextBox.Top = 0.031F;
            this.MinRetGoodsTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinDiscountTtlPrice_TextBox
            // 
            this.MinDiscountTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinDiscountTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinDiscountTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinDiscountTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinDiscountTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinDiscountTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinDiscountTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinDiscountTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinDiscountTtlPrice_TextBox.CanShrink = true;
            this.MinDiscountTtlPrice_TextBox.DataField = "DiscountTtlPrice";
            this.MinDiscountTtlPrice_TextBox.Height = 0.156F;
            this.MinDiscountTtlPrice_TextBox.Left = 5.025F;
            this.MinDiscountTtlPrice_TextBox.MultiLine = false;
            this.MinDiscountTtlPrice_TextBox.Name = "MinDiscountTtlPrice_TextBox";
            this.MinDiscountTtlPrice_TextBox.OutputFormat = resources.GetString("MinDiscountTtlPrice_TextBox.OutputFormat");
            this.MinDiscountTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinDiscountTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinDiscountTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinDiscountTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinDiscountTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinDiscountTtlPrice_TextBox.Top = 0.031F;
            this.MinDiscountTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinPureSalesTtlPrice_TextBox
            // 
            this.MinPureSalesTtlPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlPrice_TextBox.CanShrink = true;
            this.MinPureSalesTtlPrice_TextBox.DataField = "PureSalesTtlPrice";
            this.MinPureSalesTtlPrice_TextBox.Height = 0.156F;
            this.MinPureSalesTtlPrice_TextBox.Left = 5.796F;
            this.MinPureSalesTtlPrice_TextBox.MultiLine = false;
            this.MinPureSalesTtlPrice_TextBox.Name = "MinPureSalesTtlPrice_TextBox";
            this.MinPureSalesTtlPrice_TextBox.OutputFormat = resources.GetString("MinPureSalesTtlPrice_TextBox.OutputFormat");
            this.MinPureSalesTtlPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinPureSalesTtlPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinPureSalesTtlPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinPureSalesTtlPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinPureSalesTtlPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinPureSalesTtlPrice_TextBox.Top = 0.031F;
            this.MinPureSalesTtlPrice_TextBox.Width = 0.77F;
            // 
            // MinRetGoodsTtlRate_TextBox
            // 
            this.MinRetGoodsTtlRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinRetGoodsTtlRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinRetGoodsTtlRate_TextBox.CanShrink = true;
            this.MinRetGoodsTtlRate_TextBox.Height = 0.156F;
            this.MinRetGoodsTtlRate_TextBox.Left = 4.65F;
            this.MinRetGoodsTtlRate_TextBox.MultiLine = false;
            this.MinRetGoodsTtlRate_TextBox.Name = "MinRetGoodsTtlRate_TextBox";
            this.MinRetGoodsTtlRate_TextBox.OutputFormat = resources.GetString("MinRetGoodsTtlRate_TextBox.OutputFormat");
            this.MinRetGoodsTtlRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinRetGoodsTtlRate_TextBox.Text = "999.99";
            this.MinRetGoodsTtlRate_TextBox.Top = 0.031F;
            this.MinRetGoodsTtlRate_TextBox.Width = 0.375F;
            // 
            // MinTotal_Title
            // 
            this.MinTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.MinTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.MinTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.MinTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.MinTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTotal_Title.Height = 0.2F;
            this.MinTotal_Title.Left = 1.688F;
            this.MinTotal_Title.MultiLine = false;
            this.MinTotal_Title.Name = "MinTotal_Title";
            this.MinTotal_Title.OutputFormat = resources.GetString("MinTotal_Title.OutputFormat");
            this.MinTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.MinTotal_Title.Text = "ＸＸＸ計";
            this.MinTotal_Title.Top = 0.025F;
            this.MinTotal_Title.Width = 0.688F;
            // 
            // MinTargetMoneyRate_TextBox
            // 
            this.MinTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoneyRate_TextBox.CanShrink = true;
            this.MinTargetMoneyRate_TextBox.Height = 0.156F;
            this.MinTargetMoneyRate_TextBox.Left = 7.335F;
            this.MinTargetMoneyRate_TextBox.MultiLine = false;
            this.MinTargetMoneyRate_TextBox.Name = "MinTargetMoneyRate_TextBox";
            this.MinTargetMoneyRate_TextBox.OutputFormat = resources.GetString("MinTargetMoneyRate_TextBox.OutputFormat");
            this.MinTargetMoneyRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinTargetMoneyRate_TextBox.Text = "999.99";
            this.MinTargetMoneyRate_TextBox.Top = 0.031F;
            this.MinTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // MinAnTargetMoneyRate_TextBox
            // 
            this.MinAnTargetMoneyRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnTargetMoneyRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoneyRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnTargetMoneyRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoneyRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnTargetMoneyRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoneyRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnTargetMoneyRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoneyRate_TextBox.CanShrink = true;
            this.MinAnTargetMoneyRate_TextBox.Height = 0.156F;
            this.MinAnTargetMoneyRate_TextBox.Left = 7.335F;
            this.MinAnTargetMoneyRate_TextBox.MultiLine = false;
            this.MinAnTargetMoneyRate_TextBox.Name = "MinAnTargetMoneyRate_TextBox";
            this.MinAnTargetMoneyRate_TextBox.OutputFormat = resources.GetString("MinAnTargetMoneyRate_TextBox.OutputFormat");
            this.MinAnTargetMoneyRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnTargetMoneyRate_TextBox.Text = "999.99";
            this.MinAnTargetMoneyRate_TextBox.Top = 0.187F;
            this.MinAnTargetMoneyRate_TextBox.Width = 0.375F;
            // 
            // MinCmpPureSalesRatio_TextBox
            // 
            this.MinCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpPureSalesRatio_TextBox.CanShrink = true;
            this.MinCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.MinCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.MinCmpPureSalesRatio_TextBox.MultiLine = false;
            this.MinCmpPureSalesRatio_TextBox.Name = "MinCmpPureSalesRatio_TextBox";
            this.MinCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("MinCmpPureSalesRatio_TextBox.OutputFormat");
            this.MinCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinCmpPureSalesRatio_TextBox.Text = "999.99";
            this.MinCmpPureSalesRatio_TextBox.Top = 0.031F;
            this.MinCmpPureSalesRatio_TextBox.Width = 0.375F;
            // 
            // MinAnCmpPureSalesRatio_TextBox
            // 
            this.MinAnCmpPureSalesRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnCmpPureSalesRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpPureSalesRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnCmpPureSalesRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpPureSalesRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnCmpPureSalesRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpPureSalesRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnCmpPureSalesRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpPureSalesRatio_TextBox.CanShrink = true;
            this.MinAnCmpPureSalesRatio_TextBox.Height = 0.156F;
            this.MinAnCmpPureSalesRatio_TextBox.Left = 7.711F;
            this.MinAnCmpPureSalesRatio_TextBox.MultiLine = false;
            this.MinAnCmpPureSalesRatio_TextBox.Name = "MinAnCmpPureSalesRatio_TextBox";
            this.MinAnCmpPureSalesRatio_TextBox.OutputFormat = resources.GetString("MinAnCmpPureSalesRatio_TextBox.OutputFormat");
            this.MinAnCmpPureSalesRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnCmpPureSalesRatio_TextBox.Text = "999.99";
            this.MinAnCmpPureSalesRatio_TextBox.Top = 0.187F;
            this.MinAnCmpPureSalesRatio_TextBox.Width = 0.375F;
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
            // MinPureSalesTtlWork_TextBox
            // 
            this.MinPureSalesTtlWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinPureSalesTtlWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinPureSalesTtlWork_TextBox.CanShrink = true;
            this.MinPureSalesTtlWork_TextBox.DataField = "PureSalesTtlWork";
            this.MinPureSalesTtlWork_TextBox.Height = 0.125F;
            this.MinPureSalesTtlWork_TextBox.Left = 0F;
            this.MinPureSalesTtlWork_TextBox.MultiLine = false;
            this.MinPureSalesTtlWork_TextBox.Name = "MinPureSalesTtlWork_TextBox";
            this.MinPureSalesTtlWork_TextBox.OutputFormat = resources.GetString("MinPureSalesTtlWork_TextBox.OutputFormat");
            this.MinPureSalesTtlWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinPureSalesTtlWork_TextBox.Text = "10,234,567,890";
            this.MinPureSalesTtlWork_TextBox.Top = 0.031F;
            this.MinPureSalesTtlWork_TextBox.Visible = false;
            this.MinPureSalesTtlWork_TextBox.Width = 0.813F;
            // 
            // MinAnPureSalesTtlWork_TextBox
            // 
            this.MinAnPureSalesTtlWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnPureSalesTtlWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnPureSalesTtlWork_TextBox.CanShrink = true;
            this.MinAnPureSalesTtlWork_TextBox.DataField = "AnPureSalesTtlWork";
            this.MinAnPureSalesTtlWork_TextBox.Height = 0.125F;
            this.MinAnPureSalesTtlWork_TextBox.Left = 0F;
            this.MinAnPureSalesTtlWork_TextBox.MultiLine = false;
            this.MinAnPureSalesTtlWork_TextBox.Name = "MinAnPureSalesTtlWork_TextBox";
            this.MinAnPureSalesTtlWork_TextBox.OutputFormat = resources.GetString("MinAnPureSalesTtlWork_TextBox.OutputFormat");
            this.MinAnPureSalesTtlWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnPureSalesTtlWork_TextBox.Text = "10,234,567,890";
            this.MinAnPureSalesTtlWork_TextBox.Top = 0.156F;
            this.MinAnPureSalesTtlWork_TextBox.Visible = false;
            this.MinAnPureSalesTtlWork_TextBox.Width = 0.813F;
            // 
            // MinTargetProfitRate_TextBox
            // 
            this.MinTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfitRate_TextBox.CanShrink = true;
            this.MinTargetProfitRate_TextBox.Height = 0.156F;
            this.MinTargetProfitRate_TextBox.Left = 10.01092F;
            this.MinTargetProfitRate_TextBox.MultiLine = false;
            this.MinTargetProfitRate_TextBox.Name = "MinTargetProfitRate_TextBox";
            this.MinTargetProfitRate_TextBox.OutputFormat = resources.GetString("MinTargetProfitRate_TextBox.OutputFormat");
            this.MinTargetProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinTargetProfitRate_TextBox.Text = "999.99";
            this.MinTargetProfitRate_TextBox.Top = 0.031F;
            this.MinTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // MinAnTargetProfitRate_TextBox
            // 
            this.MinAnTargetProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnTargetProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnTargetProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnTargetProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnTargetProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfitRate_TextBox.CanShrink = true;
            this.MinAnTargetProfitRate_TextBox.Height = 0.156F;
            this.MinAnTargetProfitRate_TextBox.Left = 10.01092F;
            this.MinAnTargetProfitRate_TextBox.MultiLine = false;
            this.MinAnTargetProfitRate_TextBox.Name = "MinAnTargetProfitRate_TextBox";
            this.MinAnTargetProfitRate_TextBox.OutputFormat = resources.GetString("MinAnTargetProfitRate_TextBox.OutputFormat");
            this.MinAnTargetProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnTargetProfitRate_TextBox.Text = "999.99";
            this.MinAnTargetProfitRate_TextBox.Top = 0.187F;
            this.MinAnTargetProfitRate_TextBox.Width = 0.375F;
            // 
            // MinCmpProfitRatio_TextBox
            // 
            this.MinCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinCmpProfitRatio_TextBox.CanShrink = true;
            this.MinCmpProfitRatio_TextBox.Height = 0.156F;
            this.MinCmpProfitRatio_TextBox.Left = 10.38542F;
            this.MinCmpProfitRatio_TextBox.MultiLine = false;
            this.MinCmpProfitRatio_TextBox.Name = "MinCmpProfitRatio_TextBox";
            this.MinCmpProfitRatio_TextBox.OutputFormat = resources.GetString("MinCmpProfitRatio_TextBox.OutputFormat");
            this.MinCmpProfitRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinCmpProfitRatio_TextBox.Text = "999.99";
            this.MinCmpProfitRatio_TextBox.Top = 0.031F;
            this.MinCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // MinAnCmpProfitRatio_TextBox
            // 
            this.MinAnCmpProfitRatio_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnCmpProfitRatio_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpProfitRatio_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnCmpProfitRatio_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpProfitRatio_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnCmpProfitRatio_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpProfitRatio_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnCmpProfitRatio_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnCmpProfitRatio_TextBox.CanShrink = true;
            this.MinAnCmpProfitRatio_TextBox.Height = 0.156F;
            this.MinAnCmpProfitRatio_TextBox.Left = 10.38542F;
            this.MinAnCmpProfitRatio_TextBox.MultiLine = false;
            this.MinAnCmpProfitRatio_TextBox.Name = "MinAnCmpProfitRatio_TextBox";
            this.MinAnCmpProfitRatio_TextBox.OutputFormat = resources.GetString("MinAnCmpProfitRatio_TextBox.OutputFormat");
            this.MinAnCmpProfitRatio_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnCmpProfitRatio_TextBox.Text = "999.99";
            this.MinAnCmpProfitRatio_TextBox.Top = 0.187F;
            this.MinAnCmpProfitRatio_TextBox.Width = 0.375F;
            // 
            // MinAnTargetMoney_TextBox
            // 
            this.MinAnTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetMoney_TextBox.CanShrink = true;
            this.MinAnTargetMoney_TextBox.DataField = "AnTargetMoney";
            this.MinAnTargetMoney_TextBox.Height = 0.156F;
            this.MinAnTargetMoney_TextBox.Left = 6.565F;
            this.MinAnTargetMoney_TextBox.MultiLine = false;
            this.MinAnTargetMoney_TextBox.Name = "MinAnTargetMoney_TextBox";
            this.MinAnTargetMoney_TextBox.OutputFormat = resources.GetString("MinAnTargetMoney_TextBox.OutputFormat");
            this.MinAnTargetMoney_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnTargetMoney_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnTargetMoney_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnTargetMoney_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnTargetMoney_TextBox.Top = 0.187F;
            this.MinAnTargetMoney_TextBox.Width = 0.77F;
            // 
            // MinTargetMoney_TextBox
            // 
            this.MinTargetMoney_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinTargetMoney_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoney_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinTargetMoney_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoney_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinTargetMoney_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoney_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinTargetMoney_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetMoney_TextBox.CanShrink = true;
            this.MinTargetMoney_TextBox.DataField = "TargetMoney";
            this.MinTargetMoney_TextBox.Height = 0.156F;
            this.MinTargetMoney_TextBox.Left = 6.565F;
            this.MinTargetMoney_TextBox.MultiLine = false;
            this.MinTargetMoney_TextBox.Name = "MinTargetMoney_TextBox";
            this.MinTargetMoney_TextBox.OutputFormat = resources.GetString("MinTargetMoney_TextBox.OutputFormat");
            this.MinTargetMoney_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinTargetMoney_TextBox.SummaryGroup = "ReportHeader";
            this.MinTargetMoney_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinTargetMoney_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinTargetMoney_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinTargetMoney_TextBox.Top = 0.031F;
            this.MinTargetMoney_TextBox.Width = 0.77F;
            // 
            // MinGrossProfitPrice_TextBox
            // 
            this.MinGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitPrice_TextBox.CanShrink = true;
            this.MinGrossProfitPrice_TextBox.DataField = "GrossProfitPrice";
            this.MinGrossProfitPrice_TextBox.Height = 0.156F;
            this.MinGrossProfitPrice_TextBox.Left = 8.086F;
            this.MinGrossProfitPrice_TextBox.MultiLine = false;
            this.MinGrossProfitPrice_TextBox.Name = "MinGrossProfitPrice_TextBox";
            this.MinGrossProfitPrice_TextBox.OutputFormat = resources.GetString("MinGrossProfitPrice_TextBox.OutputFormat");
            this.MinGrossProfitPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinGrossProfitPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinGrossProfitPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinGrossProfitPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinGrossProfitPrice_TextBox.Top = 0.031F;
            this.MinGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // MinAnGrossProfitPrice_TextBox
            // 
            this.MinAnGrossProfitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitPrice_TextBox.CanShrink = true;
            this.MinAnGrossProfitPrice_TextBox.DataField = "AnGrossProfitPrice";
            this.MinAnGrossProfitPrice_TextBox.Height = 0.156F;
            this.MinAnGrossProfitPrice_TextBox.Left = 8.086F;
            this.MinAnGrossProfitPrice_TextBox.MultiLine = false;
            this.MinAnGrossProfitPrice_TextBox.Name = "MinAnGrossProfitPrice_TextBox";
            this.MinAnGrossProfitPrice_TextBox.OutputFormat = resources.GetString("MinAnGrossProfitPrice_TextBox.OutputFormat");
            this.MinAnGrossProfitPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnGrossProfitPrice_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnGrossProfitPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnGrossProfitPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnGrossProfitPrice_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnGrossProfitPrice_TextBox.Top = 0.187F;
            this.MinAnGrossProfitPrice_TextBox.Width = 0.77F;
            // 
            // MinTargetProfit_TextBox
            // 
            this.MinTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinTargetProfit_TextBox.CanShrink = true;
            this.MinTargetProfit_TextBox.DataField = "TargetProfit";
            this.MinTargetProfit_TextBox.Height = 0.156F;
            this.MinTargetProfit_TextBox.Left = 9.231F;
            this.MinTargetProfit_TextBox.MultiLine = false;
            this.MinTargetProfit_TextBox.Name = "MinTargetProfit_TextBox";
            this.MinTargetProfit_TextBox.OutputFormat = resources.GetString("MinTargetProfit_TextBox.OutputFormat");
            this.MinTargetProfit_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinTargetProfit_TextBox.SummaryGroup = "ReportHeader";
            this.MinTargetProfit_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinTargetProfit_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinTargetProfit_TextBox.Top = 0.031F;
            this.MinTargetProfit_TextBox.Width = 0.77F;
            // 
            // MinAnTargetProfit_TextBox
            // 
            this.MinAnTargetProfit_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnTargetProfit_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfit_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnTargetProfit_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfit_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnTargetProfit_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfit_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnTargetProfit_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnTargetProfit_TextBox.CanShrink = true;
            this.MinAnTargetProfit_TextBox.DataField = "AnTargetProfit";
            this.MinAnTargetProfit_TextBox.Height = 0.156F;
            this.MinAnTargetProfit_TextBox.Left = 9.231F;
            this.MinAnTargetProfit_TextBox.MultiLine = false;
            this.MinAnTargetProfit_TextBox.Name = "MinAnTargetProfit_TextBox";
            this.MinAnTargetProfit_TextBox.OutputFormat = resources.GetString("MinAnTargetProfit_TextBox.OutputFormat");
            this.MinAnTargetProfit_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnTargetProfit_TextBox.SummaryGroup = "ReportHeader";
            this.MinAnTargetProfit_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MinAnTargetProfit_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MinAnTargetProfit_TextBox.Text = "ZZZZ,ZZZ,ZZ9";
            this.MinAnTargetProfit_TextBox.Top = 0.187F;
            this.MinAnTargetProfit_TextBox.Width = 0.77F;
            // 
            // MinGrossProfitRate_TextBox
            // 
            this.MinGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitRate_TextBox.CanShrink = true;
            this.MinGrossProfitRate_TextBox.Height = 0.156F;
            this.MinGrossProfitRate_TextBox.Left = 8.856F;
            this.MinGrossProfitRate_TextBox.MultiLine = false;
            this.MinGrossProfitRate_TextBox.Name = "MinGrossProfitRate_TextBox";
            this.MinGrossProfitRate_TextBox.OutputFormat = resources.GetString("MinGrossProfitRate_TextBox.OutputFormat");
            this.MinGrossProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinGrossProfitRate_TextBox.Text = "999.99";
            this.MinGrossProfitRate_TextBox.Top = 0.031F;
            this.MinGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // MinAnGrossProfitRate_TextBox
            // 
            this.MinAnGrossProfitRate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitRate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitRate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitRate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitRate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitRate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitRate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitRate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitRate_TextBox.CanShrink = true;
            this.MinAnGrossProfitRate_TextBox.Height = 0.156F;
            this.MinAnGrossProfitRate_TextBox.Left = 8.856F;
            this.MinAnGrossProfitRate_TextBox.MultiLine = false;
            this.MinAnGrossProfitRate_TextBox.Name = "MinAnGrossProfitRate_TextBox";
            this.MinAnGrossProfitRate_TextBox.OutputFormat = resources.GetString("MinAnGrossProfitRate_TextBox.OutputFormat");
            this.MinAnGrossProfitRate_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnGrossProfitRate_TextBox.Text = "999.99";
            this.MinAnGrossProfitRate_TextBox.Top = 0.187F;
            this.MinAnGrossProfitRate_TextBox.Width = 0.375F;
            // 
            // MinGrossProfitWork_TextBox
            // 
            this.MinGrossProfitWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinGrossProfitWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinGrossProfitWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinGrossProfitWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinGrossProfitWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinGrossProfitWork_TextBox.CanShrink = true;
            this.MinGrossProfitWork_TextBox.DataField = "GrossProfitWork";
            this.MinGrossProfitWork_TextBox.Height = 0.125F;
            this.MinGrossProfitWork_TextBox.Left = 0.813F;
            this.MinGrossProfitWork_TextBox.MultiLine = false;
            this.MinGrossProfitWork_TextBox.Name = "MinGrossProfitWork_TextBox";
            this.MinGrossProfitWork_TextBox.OutputFormat = resources.GetString("MinGrossProfitWork_TextBox.OutputFormat");
            this.MinGrossProfitWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinGrossProfitWork_TextBox.Text = "10,234,567,890";
            this.MinGrossProfitWork_TextBox.Top = 0.031F;
            this.MinGrossProfitWork_TextBox.Visible = false;
            this.MinGrossProfitWork_TextBox.Width = 0.813F;
            // 
            // MinAnGrossProfitWork_TextBox
            // 
            this.MinAnGrossProfitWork_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitWork_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitWork_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitWork_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitWork_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitWork_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitWork_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MinAnGrossProfitWork_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinAnGrossProfitWork_TextBox.CanShrink = true;
            this.MinAnGrossProfitWork_TextBox.DataField = "AnGrossProfitWork";
            this.MinAnGrossProfitWork_TextBox.Height = 0.125F;
            this.MinAnGrossProfitWork_TextBox.Left = 0.813F;
            this.MinAnGrossProfitWork_TextBox.MultiLine = false;
            this.MinAnGrossProfitWork_TextBox.Name = "MinAnGrossProfitWork_TextBox";
            this.MinAnGrossProfitWork_TextBox.OutputFormat = resources.GetString("MinAnGrossProfitWork_TextBox.OutputFormat");
            this.MinAnGrossProfitWork_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MinAnGrossProfitWork_TextBox.Text = "10,234,567,890";
            this.MinAnGrossProfitWork_TextBox.Top = 0.156F;
            this.MinAnGrossProfitWork_TextBox.Visible = false;
            this.MinAnGrossProfitWork_TextBox.Width = 0.813F;
            // 
            // DCHNB02072P_01A4C
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
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.ReportFooter);
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
            this.ReportStart += new System.EventHandler(this.MAZAI02072P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.RecordName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTitle_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoneyRate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetMoney_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfit_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetProfitRate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandPureSalesTtlWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnPureSalesTtlWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandGrossProfitWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandAnGrossProfitWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionPureSalesTtlWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnPureSalesTtlWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGrossProfitWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionAnGrossProfitWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHeaderTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportSectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportCodeN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRetGoodsTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinDiscountTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPureSalesTtlPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRetGoodsTtlRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetMoneyRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnCmpPureSalesRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPureSalesTtlWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnPureSalesTtlWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnCmpProfitRatio_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetMoney_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnGrossProfitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnTargetProfit_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnGrossProfitRate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGrossProfitWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAnGrossProfitWork_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

    }
}
