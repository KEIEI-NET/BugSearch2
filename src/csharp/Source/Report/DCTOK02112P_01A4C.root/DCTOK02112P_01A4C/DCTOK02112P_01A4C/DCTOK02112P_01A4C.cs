//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上実績表
// プログラム概要   : 売上実績表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木　正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/10/08  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/23  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/12/04  修正内容 : 項目位置の微調整
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/12/04  修正内容 : 拠点ラベルの表示・非表示制御追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/12/11  修正内容 : 余分な縦罫線を削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/12  修正内容 : 障害対応11291,11319,11340(明細部をグループ化して表示するよう修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13154
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/04/11  修正内容 : 売上実績表（仕入先別）の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/06/24  修正内容 : 仕入コードは「0」の場合、仕入名は「未登録」へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 周洋
// 修 正 日  2014/12/04  修正内容 : 仕掛一覧№2591 Redmine#43991 金額桁数が10億と100億まで印刷されないの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 周洋
// 修 正 日  2014/12/09  修正内容 : 仕掛一覧№2591 Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
//----------------------------------------------------------------------------//
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
    /// 売上実績表印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 売上実績表のフォームクラスです。</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2007.09.19</br>
    /// <br>Update Note  : 2008.10.08 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
    /// <br>             : 2008/10/23       照田 貴志</br>
    /// <br>              ・バグ修正、仕様変更対応</br>
    /// <br>             : 2008/12/04 30452 上野 俊治</br>
    /// <br>              ・項目位置の微調整</br>
    /// <br>             : 2008/12/04 30452 上野 俊治</br>
    /// <br>              ・拠点ラベルの表示・非表示制御追加</br>
    /// <br>             : 2008/12/11 30452 上野 俊治</br>
    /// <br>              ・余分な縦罫線を削除</br>
    /// <br>             : 2009/02/12 30452 上野 俊治</br>
    /// <br>              ・障害対応11291,11319,11340(明細部をグループ化して表示するよう修正)</br>
    /// <br>             : 2009/04/07 30452 上野 俊治</br>
    /// <br>              ・障害対応13154</br>
    /// <br>             : 2009/04/11 張莉莉</br>
    /// <br>              ・売上実績表（仕入先別）の追加</br>
    /// <br>             : 2009/06/24 張莉莉</br>
    /// <br>              ・仕入コードは「0」の場合、仕入名は「未登録」へ変更</br>
    /// <br>Update Note  : 2014/12/04 周洋</br>
    /// <br>               仕掛一覧№2591 Redmine#43991</br>
    /// <br>               金額桁数が10億と100億まで印刷されないの対応</br>
    /// <br>Update Note  : 2014/12/09 周洋</br>
    /// <br>               仕掛一覧№2591 Redmine#43991の#43</br>
    /// <br>               1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
    /// <br>             :</br>
    /// </remarks>
    public class DCTOK02112P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 売上実績表フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : 売上実績表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 22018　鈴木　正臣</br>
        /// <br>Date         : 2007.09.19</br>
        /// </remarks>
        public DCTOK02112P_01A4C ()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        private int _printCount;									// 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;				// 抽出条件
        private int _pageFooterOutCode;				// フッター出力区分
        private StringCollection _pageFooters;					// フッターメッセージ
        private SFCMN06002C _printInfo;						// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        private SalesRsltListCndtn _salesRsltListCndtn;				// 抽出条件クラス

        private bool _groupFirstRowVisibleFlg = true; // グループ開始行フラグ(falseの場合、印字しない) // ADD 2009/02/12

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        #region ActiveReport項目
        private Label Lb_BLGoodsCode;
        private TextBox MonthSalesMoney;
        private TextBox GoodsLGroupCode;
        private TextBox GoodsMGroupCode;
        private TextBox BLGroupCode;
        private TextBox BLGoodsCode;
        private TextBox MonthGrossProfit;
        private TextBox MonthGrossProfitRate;
        private TextBox AnnualTotalSalesCount;
        private TextBox AnnualSalesMoney;
        private TextBox AnnualGrossProfit;
        private TextBox AnnualGrossProfitRate;
        private Label Lb_BLGroupCode;
        private Label label4;
        private Label label5;
        private Label label6;
        private Line line6;
        private Line line7;
        private Label Lb_AnnualSalesCount;
        private Label Lb_AnnualSalesMoney;
        private Label Lb_AnnualGrossProfit;
        private Label Lb_AnnualGrossProfitRate;
        private Line line4;
        private Line line5;
        private Label LB_Month;
        private Label Lb_AnnualTitle;
        private TextBox Ttl_SalesPrice;
        private TextBox Ttl_TotalSalesCount;
        private TextBox SecFt_SalesPrice;
        private TextBox SecFt_TotalSalesCount;
        private TextBox CusFt_SalesPrice;
        private TextBox CusFt_TotalSalesCount;
        private TextBox CusFt_GrossProfitRate;
        private TextBox Ttl_GrossProfitRate;
        private TextBox Ttl_TtlGrossProfit;
        private TextBox Ttl_TtlSalesPrice;
        private TextBox Ttl_TtlTotalSalesCount;
        private TextBox Ttl_TtlGrossProfitRate;
        private TextBox SecFt_GrossProfitRate;
        private TextBox SecFt_TtlGrossProfit;
        private TextBox SecFt_TtlSalesPrice;
        private TextBox SecFt_TtlTotalSalesCount;
        private TextBox SecFt_TtlGrossProfitRate;
        private TextBox CusFt_TtlGrossProfit;
        private TextBox CusFt_TtlSalesPrice;
        private TextBox CusFt_TtlTotalSalesCount;
        private TextBox CusFt_TtlGrossProfitRate;
        private Line line12;
        private Line line15;
        private Line line11;
        private Line line14;
        private Line line10;
        private Line line13;
        private TextBox MakerName;
        private GroupHeader BLGoodsCodeHeader;
        private GroupFooter BLGoodsCodeFooter;
        private GroupHeader GoodsMGroupHeader;
        private GroupFooter GoodsMGroupFooter;
        private GroupHeader BLGroupCodeHeader;
        private GroupFooter BLGroupCodeFooter;
        private GroupHeader GoodsLGroupHeader;
        private GroupFooter GoodsLGroupFooter;
        private GroupHeader MakerHeader;
        private GroupFooter MakerFooter;
        private Line line16;
        private TextBox textBox31;
        private Line line18;
        private TextBox textBox33;
        private Line line17;
        private TextBox textBox32;
        private Line line19;
        private TextBox textBox34;
        private Line line20;
        private TextBox textBox35;
        private TextBox BlFt_GrossProfit;
        private TextBox BlFt_SalesPrice;
        private TextBox BlFt_TotalSalesCount;
        private TextBox BlFt_GrossProfitRate;
        private TextBox BlFt_TtlGrossProfit;
        private TextBox BlFt_TtlSalesPrice;
        private TextBox BlFt_TtlTotalSalesCount;
        private TextBox BlFt_TtlGrossProfitRate;
        private Line line32;
        private Line line33;
        private TextBox MggFt_GrossProfit;
        private TextBox MggFt_SalesPrice;
        private TextBox MggFt_TotalSalesCount;
        private TextBox MggFt_GrossProfitRate;
        private TextBox MggFt_TtlGrossProfit;
        private TextBox MggFt_TtlSalesPrice;
        private TextBox MggFt_TtlTotalSalesCount;
        private TextBox MggFt_TtlGrossProfitRate;
        private Line line28;
        private Line line29;
        private TextBox DggFt_GrossProfit;
        private TextBox DggFt_SalesPrice;
        private TextBox DggFt_TotalSalesCount;
        private TextBox DggFt_GrossProfitRate;
        private TextBox DggFt_TtlGrossProfit;
        private TextBox DggFt_TtlSalesPrice;
        private TextBox DggFt_TtlTotalSalesCount;
        private TextBox DggFt_TtlGrossProfitRate;
        private Line line30;
        private Line line31;
        private TextBox LggFt_GrossProfit;
        private TextBox LggFt_SalesPrice;
        private TextBox LggFt_TotalSalesCount;
        private TextBox LggFt_GrossProfitRate;
        private TextBox LggFt_TtlGrossProfit;
        private TextBox LggFt_TtlSalesPrice;
        private TextBox LggFt_TtlTotalSalesCount;
        private TextBox LggFt_TtlGrossProfitRate;
        private Line line26;
        private Line line27;
        private TextBox MakFt_GrossProfit;
        private TextBox MakFt_SalesPrice;
        private TextBox MakFt_TotalSalesCount;
        private TextBox MakFt_GrossProfitRate;
        private TextBox MakFt_TtlGrossProfit;
        private TextBox MakFt_TtlSalesPrice;
        private TextBox MakFt_TtlTotalSalesCount;
        private TextBox MakFt_TtlGrossProfitRate;
        private Line line24;
        private Line line25;
        private GroupHeader EmployeeHeader;
        private GroupFooter EmployeeFooter;
        private Line line21;
        private TextBox textBox36;
        private TextBox EmpFt_GrossProfit;
        private TextBox EmpFt_SalesPrice;
        private TextBox EmpFt_TotalSalesCount;
        private TextBox EmpFt_GrossProfitRate;
        private TextBox EmpFt_TtlGrossProfit;
        private TextBox EmpFt_TtlSalesPrice;
        private TextBox EmpFt_TtlTotalSalesCount;
        private TextBox EmpFt_TtlGrossProfitRate;
        private Line line22;
        private Line line23;
        private TextBox CusFt_CustomerCode;
        private TextBox BlFt_BLGoodsCode;
        private TextBox BlFt_BLGoodsHalfName;
        private TextBox MggFt_MediumGoodsGanreCode;
        private TextBox MggFt_MediumGoodsGanreName;
        private TextBox DggFt_DetailGoodsGanreCode;
        private TextBox DggFt_DetailGoodsGanreName;
        private TextBox LggFt_LargeGoodsGanreCode;
        private TextBox LggFt_LargeGoodsGanreName;
        private TextBox MakFt_GoodsMakerCd;
        private TextBox MakFt_MakerName;
        private TextBox EmpFt_EmployeeCode;
        private TextBox EmpFt_EmployeeName;
        private TextBox CusFt_CustomerSnm;
        private Line CusHd_line1;
        private Line CusHd_line2;
        private TextBox CusHd_AddUpSecCode;
        private TextBox CusHd_SectionGuideNm;
        private TextBox CusHd_CustomerCode;
        private TextBox CusHd_CustomerSnm;
        private Line EmpHd_line1;
        private Line EmpHd_line2;
        private TextBox EmpHd_AddUpSecCode;
        private TextBox EmpHd_SectionGuideNm;
        private TextBox EmpHd_EmployeeCode;
        private TextBox EmpHd_EmployeeName;
        private Line Line_DetailHead;

        // Disposeチェック用フラグ
        bool disposed = false;
        private TextBox DggFt_MonthPureSalesMoney;
        private TextBox DggFt_AnnualPureSalesMoney;
        private TextBox BlFt_MonthPureSalesMoney;
        private TextBox BlFt_AnnualPureSalesMoney;
        private TextBox MggFt_MonthPureSalesMoney;
        private TextBox MggFt_AnnualPureSalesMoney;
        private TextBox LggFt_MonthPureSalesMoney;
        private TextBox LggFt_AnnualPureSalesMoney;
        private TextBox SecFt_MonthPureSalesMoney;
        private TextBox SecFt_AnnualPureSalesMoney;
        private TextBox CusFt_MonthPureSalesMoney;
        private TextBox CusFt_AnnualPureSalesMoney;
        private TextBox MakFt_MonthPureSalesMoney;
        private TextBox MakFt_AnnualPureSalesMoney;
        private TextBox EmpFt_MonthPureSalesMoney;
        private TextBox EmpFt_AnnualPureSalesMoney;
        private TextBox Ttl_MonthPureSalesMoney;
        private TextBox Ttl_AnnualPureSalesMoney;

        // 率(%)フォーマット文字列
        private const string _rateFormat = "##0.00";
        private Label Lb_GoodsMGroup;
        private Label Lb_GoodsLGroup;
        private GroupHeader WarehouseHeader;
        private Line WarHd_line1;
        private Line WarHd_line2;
        private GroupFooter WarehouseFooter;
        private Line line48;
        private Line line49;
        private Line line50;
        private SubReport Header_SubReport;
        private TextBox CodeNameFull20;
        private TextBox DetailTitleCode;
        private TextBox DetailTitleName;
        private Label Lb_DetailTitleCode;
        private TextBox CusHd_SectionTitle;
        private TextBox CusHd_CustomerTitle;
        private TextBox EmpHd_SectionTitle;
        private TextBox EmpHd_EmployeeTitle;
        private TextBox WarHd_AddUpSecCode;
        private TextBox WarHd_SectionGuideNm;
        private TextBox WarHd_SectionTitle;
        private TextBox WarHd_WarehouseCode;
        private TextBox WarHd_WarehouseName;
        private TextBox WarHd_WarehouseTitle;
        private TextBox SecHd_AddUpSecCode;
        private TextBox SecHd_SectionGuideNm;
        private Line SecHd_Line1;
        private Line SecHd_line2;
        private TextBox SecHd_Title;
        private GroupHeader WarehouseHeader2;
        private GroupFooter WarehouseFooter2;
        private TextBox SecHd_WarehouseCode;
        private TextBox SecHd_WarehouseName;
        private TextBox SecHd_WarehouseTitle;
        private TextBox CusHd_WarehouseCode;
        private TextBox CusHd_WarehouseName;
        private TextBox CusHd_WarehouseTitle;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Line line3;
        private Line line8;
        private Line line9;
        private TextBox WarFt_GrossProfitRate;
        private TextBox WarFt_GrossProfit;
        private TextBox WarFt_SalesPrice;
        private TextBox WarFt_TotalSalesCount;
        private TextBox WarFt_MonthPureSalesMoney;
        private TextBox War2Ft_GrossProfitRate;
        private TextBox War2Ft_GrossProfit;
        private TextBox War2Ft_SalesPrice;
        private TextBox War2Ft_TotalSalesCount;
        private TextBox War2Ft_MonthPureSalesMoney;
        private TextBox War2Ft_TtlGrossProfit;
        private TextBox War2Ft_TtlSalesPrice;
        private TextBox War2Ft_TtlTotalSalesCount;
        private TextBox War2Ft_TtlGrossProfitRate;
        private TextBox War2Ft_AnnualPureSalesMoney;
        private TextBox WarFt_TtlGrossProfit;
        private TextBox WarFt_TtlSalesPrice;
        private TextBox WarFt_TtlTotalSalesCount;
        private TextBox WarFt_TtlGrossProfitRate;
        private TextBox WarFt_AnnualPureSalesMoney;
        private TextBox SortTitle;
        private TextBox BlFt_MonthGrossProfitOrg;
        private TextBox BlFt_AnnualGrossProfitOrg;
        private TextBox DggFt_MonthGrossProfitOrg;
        private TextBox DggFt_AnnualGrossProfitOrg;
        private TextBox MggFt_MonthGrossProfitOrg;
        private TextBox MggFt_AnnualGrossProfitOrg;
        private TextBox LggFt_MonthGrossProfitOrg;
        private TextBox LggFt_AnnualGrossProfitOrg;
        private TextBox MakFt_MonthGrossProfitOrg;
        private TextBox MakFt_AnnualGrossProfitOrg;
        private TextBox EmpFt_MonthGrossProfitOrg;
        private TextBox EmpFt_AnnualGrossProfitOrg;
        private TextBox CusFt_MonthGrossProfitOrg;
        private TextBox CusFt_AnnualGrossProfitOrg;
        private TextBox WarFt_MonthGrossProfitOrg;
        private TextBox WarFt_AnnualGrossProfitOrg;
        private TextBox SecFt_MonthGrossProfitOrg;
        private TextBox SecFt_AnnualGrossProfitOrg;
        private TextBox War2Ft_MonthGrossProfitOrg;
        private TextBox War2Ft_AnnualGrossProfitOrg;
        private TextBox Ttl_MonthGrossProfitOrg;
        private TextBox Ttl_AnnualGrossProfitOrg;
        private TextBox War2Hd_WarehouseTitle;
        private TextBox War2Hd_WarehouseCode;
        private TextBox War2Hd_WarehouseName;
        private Line War2Hd_Line1;
        private Line War2Hd_Line2;
        private Line line34;
        private Line SecHd_Line3;
        private Line CusHd_line3;
        private Line EmpHd_line3;
        private Line WarHd_line3;
        private Line War2Hd_Line3;
        private GroupHeader SupplierHeader;
        private TextBox SupHd_SectionTitle;
        private TextBox SupHd_AddUpSecCode;
        private TextBox SupHd_SectionGuideNm;
        private TextBox SupHd_SupplierTitle;
        private TextBox SupHd_SupplierCode;
        private TextBox SupHd_SupplierSnm;
        private Line line35;
        private Line line36;
        private Line line38;
        private GroupFooter SupplierFooter;
        private Line line39;
        private TextBox textBox5;
        private TextBox SupFt_GrossProfit;
        private TextBox SupFt_SalesPrice;
        private TextBox SupFt_TotalSalesCount;
        private TextBox SupFt_GrossProfitRate;
        private TextBox SupFt_TtlGrossProfit;
        private TextBox SupFt_TtlSalesPrice;
        private TextBox SupFt_TtlTotalSalesCount;
        private TextBox SupFt_TtlGrossProfitRate;
        private Line line40;
        private Line line45;
        private TextBox SupFt_SupplierCode;
        private TextBox SupFt_SupplierSnm;
        private TextBox SupFt_MonthPureSalesMoney;
        private TextBox SupFt_AnnualPureSalesMoney;
        private TextBox SupFt_MonthGrossProfitOrg;
        private TextBox SupFt_AnnualGrossProfitOrg;
        private Line line37;
        #endregion

        // 明細開始ライン印字
        //private bool Line_DetailHead_Visible = true; // DEL 2009/04/07

        #endregion ■ Private Member

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose ( bool disposing )
        {
            if ( !this.disposed )
            {
                try
                {
                    if ( disposing )
                    {
                        // ヘッダ用サブレポート後処理実行
                        if ( this._rptExtraHeader != null )
                        {
                            this._rptExtraHeader.Dispose();
                        }

                        // フッタ用サブレポート後処理実行
                        if ( this._rptPageFooter != null )
                        {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally
                {
                    base.Dispose( disposing );
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
                this._salesRsltListCndtn = (SalesRsltListCndtn)this._printInfo.jyoken;
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
                // TODO:  DCZAI02103P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>Update Note : 2008.10.08 30452 上野 俊治</br>
        /// <br>            ・PM.NS対応</br> 
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;				// サブタイトル

            // ソート条件
            SortTitle.Text = this._pageHeaderSortOderTitle;

            // ラベル名称
            if (this._salesRsltListCndtn.TotalType == SalesRsltListCndtn.TotalTypeState.EachWareHouse)
            {
                //this.LB_Month.Text = "―――――　　期　　間　　―――――";          //DEL 2008/10/23 フォーマット変更の為
                this.LB_Month.Text = "<============　　期　　間　　============>";      //ADD 2008/10/23
            }

            //-------------------------------------------------------
            // 全社集計・拠点別切り替え
            //-------------------------------------------------------
            #region [全社集計・拠点別切り替え]
            // 小計で制御
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //if ( this._salesRsltListCndtn.GroupBySectionDiv == SalesRsltListCndtn.GroupBySectionDivState.All )
            //{
            //    // 全社集計
            //    SectionFooter.Visible = false;
            //}
            //else
            //{
            //    // 拠点別
            //    SectionFooter.Visible = true;
            //}
            // --- DEL 2008/10/08 --------------------------------<<<<<
            #endregion [全社集計・拠点別切り替え]

            //-------------------------------------------------------
            // 帳票タイプ別切り替え
            //-------------------------------------------------------
            #region [帳票タイプ別切り替え]
            // 注記
            // Warehouseheader2は倉庫別、拠点別のみで使用。
            // 機能別、発行タイプ別の使用明細ヘッダは以下の通り
            // 商品別　　　　　　　　:SectionHeader
            // 得意先別　　　　　　　:CustomerHaeder
            // 担当者別　　　　　　　:EmployeeHeader
            // 仕入先別　　　　　　　:SupplierHeader
            // 倉庫別（拠点―倉庫）  :WareHouseHeader
            // 倉庫別（倉庫―得意先）:CustomerHeader
            // 倉庫別（倉庫―拠点）  :SectionHeader

            // 位置調整用
            System.Drawing.PointF point;
            switch ( this._salesRsltListCndtn.TotalType )
            {
                // 得意先別
                # region 得意先別
                case SalesRsltListCndtn.TotalTypeState.EachCustomer:
                    {
                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 倉庫2
                        WarehouseHeader2.DataField = string.Empty;
                        WarehouseHeader2.Visible = false;
                        WarehouseHeader2.Visible = false;
                        // --- ADD 2008/10/08 --------------------------------<<<<<

                        // 拠点
                        SectionHeader.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true;

                        if (this._salesRsltListCndtn.DetailDataValue != SalesRsltListCndtn.DetailDataValueState.Customer)
                        {
                            // コントロールは表示しない
                            SecHd_Title.Visible = false;
                            SecHd_AddUpSecCode.Visible = false;
                            SecHd_SectionGuideNm.Visible = false;
                            SecHd_Line1.Visible = false;
                            SecHd_line2.Visible = false;
                            SecHd_Line3.Visible = false; // ADD 2009/04/07

                            SectionHeader.Height = 0F;
                        }

                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 倉庫
                        WarehouseHeader.DataField = string.Empty;
                        WarehouseHeader.Visible = false;
                        WarehouseFooter.Visible = false;
                        // --- ADD 2008/10/08 --------------------------------<<<<<

                        // --- ADD 2009/04/11 -------------------------------->>>>>
                        // 仕入先
                        SupplierHeader.DataField = string.Empty;
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;
                        // --- ADD 2009/04/11 --------------------------------<<<<<

                        // 得意先
                        CustomerHeader.DataField = DCTOK02114EA.ct_Col_CustomerCode;
                        CustomerHeader.Visible = true;
                        CustomerFooter.Visible = true;

                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // メーカー
                        MakerHeader.DataField = DCTOK02114EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;

                        // 商品大分類
                        //GoodsLGroupHeader.DataField = string.Empty; // DEL 2008/10/08
                        //GoodsLGroupHeader.Visible = false; // DEL 2008/10/08
                        //GoodsLGroupFooter.Visible = false; // DEL 2008/10/08
                        GoodsLGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsLGroup; // ADD 2008/10/08
                        GoodsLGroupHeader.Visible = true; // ADD 2008/10/08
                        GoodsLGroupFooter.Visible = true; // ADD 2008/10/08
                        
                        // 商品中分類
                        //GoodsMGroupHeader.DataField = string.Empty; // DEL 2008/10/08
                        //GoodsMGroupHeader.Visible = false; // DEL 2008/10/08
                        //GoodsMGroupFooter.Visible = false; // DEL 2008/10/08
                        GoodsMGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsMGroup; // ADD 2008/10/08
                        GoodsMGroupHeader.Visible = true; // ADD 2008/10/08
                        GoodsMGroupFooter.Visible = true; // ADD 2008/10/08
                        
                        // グループコード
                        //BLGroupCodeHeader.DataField = string.Empty; // DEL 2008/10/08
                        //BLGroupCodeHeader.Visible = false; // DEL 2008/10/08
                        //BLGroupCodeFooter.Visible = false; // DEL 2008/10/08
                        BLGroupCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGroupCode; // ADD 2008/10/08
                        BLGroupCodeHeader.Visible = true; // ADD 2008/10/08
                        BLGroupCodeFooter.Visible = true; // ADD 2008/10/08

                        // ＢＬコード
                        //BLGoodsCodeHeader.DataField = string.Empty; // DEL 2008/10/08
                        //BLGoodsCodeHeader.Visible = false; // DEL 2008/10/08
                        //BLGoodsCodeFooter.Visible = false; // DEL 2008/10/08
                        BLGoodsCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGoodsCode; // ADD 2008/10/08
                        BLGoodsCodeHeader.Visible = true; // ADD 2008/10/08
                        BLGoodsCodeFooter.Visible = true; // ADD 2008/10/08

                        // 画面の計印刷チェックによる制御
                        if (this._salesRsltListCndtn.SectionSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) SectionFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.CustomerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) CustomerFooter.Visible = false;
                        if (this._salesRsltListCndtn.MakerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) MakerFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsLGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.GoodsMGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.BLGroupCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.BLGoodsCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false; // ADD 2008/10/08

                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        // 全社集計の場合、拠点を表示しない
                        if (this._salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.All)
                        {
                            // 明細単位 得意先用
                            this.SecHd_Title.Visible = false;
                            this.SecHd_AddUpSecCode.Visible = false;
                            this.SecHd_SectionGuideNm.Visible = false;

                            // その他
                            this.CusHd_SectionTitle.Visible = false;
                            this.CusHd_AddUpSecCode.Visible = false;
                            this.CusHd_SectionGuideNm.Visible = false;

                            this.CusHd_CustomerTitle.Location = this.CusHd_SectionTitle.Location;

                            point = this.CusHd_CustomerTitle.Location;
                            point.X += this.CusHd_CustomerTitle.Width;

                            this.CusHd_CustomerCode.Location = point;

                            point.X += this.CusHd_CustomerCode.Width;

                            this.CusHd_CustomerSnm.Location = point;
                        }
                        // --- ADD 2008/12/05 --------------------------------<<<<<

                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 明細単位による明細行制御
                        // グループ化が必要になったため、ヘッダのvisible制御を追加 // ADD 2009/02/12
                        switch (this._salesRsltListCndtn.DetailDataValue)
                        {
                            case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                                {
                                    // 品名
                                    this.GoodsNameKana.DataField = DCTOK02114EA.ct_Col_GoodsNameKana;

                                    this.CodeNameFull20.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                                {
                                    // BLコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGoodsHalfName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsNo.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                                {
                                    // グループコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGroupKanaName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGoodsCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                                {
                                    // 商品中分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsMGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                                {
                                    // 商品大分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsLGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsMGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsLGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMaker:
                                {
                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Customer:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "得意先";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 明細ヘッダ
                                    this.CustomerHeader.Visible = false;


                                    // 倉庫は表示しない
                                    this.SecHd_WarehouseTitle.Visible = false;
                                    this.SecHd_WarehouseCode.Visible = false;
                                    this.SecHd_WarehouseName.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_CustomerCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CustomerSnm;

                                    this.DetailTitleCode.OutputFormat = "00000000";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Section:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "拠点";

                                    //this.line36.Visible = true;     //ADD 2008/10/23// DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23// DEL 2008/12/11

                                    // 明細ヘッダ
                                    this.CustomerHeader.Visible = false;
                                    this.SectionHeader.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CompanyName1;

                                    this.DetailTitleCode.OutputFormat = "00";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                        }

                        // --- ADD 2008/10/08 --------------------------------<<<<<
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //// 得意先別レイアウト制御
                        //MakerName.Visible = true;
                        //MakerName.Top = GoodsMakerCd.Top;
                        ////BLGoodsHalfName.Visible = true; // DEL 2008/10/08
                        ////BLGoodsHalfName.Top = BLGoodsCode.Top; // DEL 2008/10/08
                        //GoodsLGroupCode.Visible = false;
                        //GoodsMGroupCode.Visible = false;
                        //BLGroupCode.Visible = false;
                        //GoodsNo.Visible = false;
                        //GoodsNameKana.Visible = false;

                        //// タイトル印字・非印字制御
                        ////Lb_Customer.Visible = true; // DEL 2008/10/08
                        ////Lb_Employee.Visible = false; // DEL 2008/10/08
                        //Lb_BLGroupCode.Visible = false;
                        //Lb_GoodsNo.Visible = false;
                        //Lb_GoodsName.Visible = false;
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                    }
                    break;
                #endregion
                // --- ADD 2009/04/11 ------------------------------->>>>>
                // 仕入先別
                # region 仕入先別
                case SalesRsltListCndtn.TotalTypeState.EachSupplier:
                    {
                        // 倉庫2
                        WarehouseHeader2.DataField = string.Empty;
                        WarehouseHeader2.Visible = false;
                        WarehouseHeader2.Visible = false;

                        // 拠点
                        SectionHeader.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true;

                        if (this._salesRsltListCndtn.DetailDataValue != SalesRsltListCndtn.DetailDataValueState.Supplier)
                        {
                            // コントロールは表示しない
                            SecHd_Title.Visible = false;
                            SecHd_AddUpSecCode.Visible = false;
                            SecHd_SectionGuideNm.Visible = false;
                            SecHd_Line1.Visible = false;
                            SecHd_line2.Visible = false;
                            SecHd_Line3.Visible = false;

                            SectionHeader.Height = 0F;
                        }

                        // 倉庫
                        WarehouseHeader.DataField = string.Empty;
                        WarehouseHeader.Visible = false;
                        WarehouseFooter.Visible = false;

                        // 得意先
                        CustomerHeader.DataField = string.Empty;
                        CustomerHeader.Visible = false;
                        CustomerFooter.Visible = false;

                        // 仕入先
                        SupplierHeader.DataField = DCTOK02114EA.ct_Col_SupplierCode;
                        SupplierHeader.Visible = true;
                        SupplierFooter.Visible = true;

                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // メーカー
                        MakerHeader.DataField = DCTOK02114EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;

                        // 商品大分類
                        GoodsLGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsLGroup;
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;

                        // 商品中分類
                        GoodsMGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsMGroup;
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;

                        // グループコード
                        BLGroupCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGroupCode;
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;

                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;

                        // 画面の計印刷チェックによる制御
                        if (this._salesRsltListCndtn.SectionSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) SectionFooter.Visible = false;
                        if (this._salesRsltListCndtn.SupplierSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) SupplierFooter.Visible = false;
                        if (this._salesRsltListCndtn.MakerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) MakerFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsLGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsMGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false;
                        if (this._salesRsltListCndtn.BLGroupCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false;
                        if (this._salesRsltListCndtn.BLGoodsCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false;

                        // 全社集計の場合、拠点を表示しない
                        if (this._salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.All)
                        {
                            // 明細単位 得意先用
                            this.SecHd_Title.Visible = false;
                            this.SecHd_AddUpSecCode.Visible = false;
                            this.SecHd_SectionGuideNm.Visible = false;

                            // その他
                            this.SupHd_SectionTitle.Visible = false;
                            this.SupHd_AddUpSecCode.Visible = false;
                            this.SupHd_SectionGuideNm.Visible = false;

                            this.SupHd_SupplierTitle.Location = this.SupHd_SectionTitle.Location;

                            point = this.SupHd_SupplierTitle.Location;
                            point.X += this.SupHd_SupplierTitle.Width;

                            this.SupHd_SupplierCode.Location = point;

                            point.X += this.SupHd_SupplierCode.Width;

                            this.SupHd_SupplierSnm.Location = point;
                        }
                        // 明細単位による明細行制御
                        // グループ化が必要になったため、ヘッダのvisible制御を追加
                        switch (this._salesRsltListCndtn.DetailDataValue)
                        {
                            case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                                {
                                    // 品名
                                    this.GoodsNameKana.DataField = DCTOK02114EA.ct_Col_GoodsNameKana;

                                    this.CodeNameFull20.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                                {
                                    // BLコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGoodsHalfName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsNo.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                                {
                                    // グループコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGroupKanaName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGoodsCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false;
                                    this.BLGroupCodeHeader.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                                {
                                    // 商品中分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsMGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false;
                                    this.BLGroupCodeHeader.Visible = false;
                                    this.GoodsMGroupHeader.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                                {
                                    // 商品大分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsLGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsMGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false;
                                    this.BLGroupCodeHeader.Visible = false;
                                    this.GoodsMGroupHeader.Visible = false;
                                    this.GoodsLGroupHeader.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMaker:
                                {
                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Supplier:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "仕入先";

                                    // 明細ヘッダ
                                    this.SupplierHeader.Visible = false;


                                    // 倉庫は表示しない
                                    this.SecHd_WarehouseTitle.Visible = false;
                                    this.SecHd_WarehouseCode.Visible = false;
                                    this.SecHd_WarehouseName.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_SupplierCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_SupplierSnm;

                                    this.DetailTitleCode.OutputFormat = "000000";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Section:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "拠点";

                                    // 明細ヘッダ
                                    this.SupplierHeader.Visible = false;
                                    this.SectionHeader.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CompanyName1;

                                    this.DetailTitleCode.OutputFormat = "00";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                        }
                    }
                    break;
                #endregion
                // --- ADD 2009/04/11 -------------------------------<<<<<
                // 担当者別
                #region 担当者別
                case SalesRsltListCndtn.TotalTypeState.EachEmployee:
                    {
                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 倉庫2
                        WarehouseHeader2.DataField = string.Empty;
                        WarehouseHeader2.Visible = false;
                        WarehouseHeader2.Visible = false;
                        // --- ADD 2008/10/08 --------------------------------<<<<<

                        // 拠点
                        SectionHeader.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true;

                        if (this._salesRsltListCndtn.DetailDataValue != SalesRsltListCndtn.DetailDataValueState.Employee)
                        {
                            // コントロールは表示しない
                            SecHd_Title.Visible = false;
                            SecHd_AddUpSecCode.Visible = false;
                            SecHd_SectionGuideNm.Visible = false;
                            SecHd_Line1.Visible = false;
                            SecHd_line2.Visible = false;
                            SecHd_Line3.Visible = false; // ADD 2009/04/07

                            SectionHeader.Height = 0F;
                        }

                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 倉庫
                        WarehouseHeader.DataField = string.Empty;
                        WarehouseHeader.Visible = false;
                        WarehouseFooter.Visible = false;
                        // --- ADD 2008/10/08 --------------------------------<<<<<

                        // --- ADD 2009/04/11 -------------------------------->>>>>
                        // 仕入先
                        SupplierHeader.DataField = string.Empty;
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;
                        // --- ADD 2009/04/11 --------------------------------<<<<<

                        // 得意先
                        CustomerHeader.DataField = string.Empty;
                        CustomerHeader.Visible = false;
                        CustomerFooter.Visible = false;

                        // 担当者
                        EmployeeHeader.DataField = DCTOK02114EA.ct_Col_EmployeeCode;
                        EmployeeHeader.Visible = true;
                        EmployeeFooter.Visible = true;

                        // メーカー
                        MakerHeader.DataField = DCTOK02114EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;

                        // 商品大分類
                        //GoodsLGroupHeader.DataField = string.Empty; // DEL 2008/10/08
                        //GoodsLGroupHeader.Visible = false; // DEL 2008/10/08
                        //GoodsLGroupFooter.Visible = false; // DEL 2008/10/08
                        GoodsLGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsLGroup; // ADD 2008/10/08
                        GoodsLGroupHeader.Visible = true; // ADD 2008/10/08
                        GoodsLGroupFooter.Visible = true; // ADD 2008/10/08

                        // 商品中分類
                        //GoodsMGroupHeader.DataField = string.Empty; // DEL 2008/10/08
                        //GoodsMGroupHeader.Visible = false; // DEL 2008/10/08
                        //GoodsMGroupFooter.Visible = false; // DEL 2008/10/08
                        GoodsMGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsMGroup; // ADD 2008/10/08
                        GoodsMGroupHeader.Visible = true; // ADD 2008/10/08
                        GoodsMGroupFooter.Visible = true; // ADD 2008/10/08

                        // グループコード
                        //BLGroupCodeHeader.DataField = string.Empty; // DEL 2008/10/08
                        //BLGroupCodeHeader.Visible = false; // DEL 2008/10/08
                        //BLGroupCodeFooter.Visible = false; // DEL 2008/10/08
                        BLGroupCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGroupCode; // ADD 2008/10/08
                        BLGroupCodeHeader.Visible = true; // ADD 2008/10/08
                        BLGroupCodeFooter.Visible = true; // ADD 2008/10/08

                        // ＢＬコード
                        //BLGoodsCodeHeader.DataField = string.Empty; // DEL 2008/10/08
                        //BLGoodsCodeHeader.Visible = false; // DEL 2008/10/08
                        //BLGoodsCodeFooter.Visible = false; // DEL 2008/10/08
                        BLGoodsCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGoodsCode; // ADD 2008/10/08
                        BLGoodsCodeHeader.Visible = true; // ADD 2008/10/08
                        BLGoodsCodeFooter.Visible = true; // ADD 2008/10/08

                        // 画面の計印刷チェックによる制御
                        if (this._salesRsltListCndtn.SectionSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) SectionFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.EmployeeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) EmployeeFooter.Visible = false;
                        if (this._salesRsltListCndtn.MakerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) MakerFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsLGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.GoodsMGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.BLGroupCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false; // ADD 2008/10/08
                        if (this._salesRsltListCndtn.BLGoodsCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false; // ADD 2008/10/08

                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        // 全社集計の場合、拠点を表示しない
                        if (this._salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.All)
                        {
                            // 明細単位 担当者用
                            this.SecHd_Title.Visible = false;
                            this.SecHd_AddUpSecCode.Visible = false;
                            this.SecHd_SectionGuideNm.Visible = false;

                            // その他
                            this.EmpHd_SectionTitle.Visible = false;
                            this.EmpHd_AddUpSecCode.Visible = false;
                            this.EmpHd_SectionGuideNm.Visible = false;

                            this.EmpHd_EmployeeTitle.Location = this.EmpHd_SectionTitle.Location;

                            point = this.EmpHd_EmployeeTitle.Location;
                            point.X += this.EmpHd_EmployeeTitle.Width;

                            this.EmpHd_EmployeeCode.Location = point;

                            point.X += this.EmpHd_EmployeeCode.Width;

                            this.EmpHd_EmployeeName.Location = point;
                        }
                        // --- ADD 2008/12/05 --------------------------------<<<<<

                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 明細単位による明細行制御
                        // グループ化が必要になったため、ヘッダのvisible制御を追加 // ADD 2009/02/12
                        switch (this._salesRsltListCndtn.DetailDataValue)
                        {
                            case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                                {
                                    // 品名
                                    this.GoodsNameKana.DataField = DCTOK02114EA.ct_Col_GoodsNameKana;

                                    this.CodeNameFull20.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                                {
                                    // BLコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGoodsHalfName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsNo.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                                {
                                    // グループコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGroupKanaName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGoodsCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                                {
                                    // 商品中分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsMGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                                {
                                    // 商品大分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsLGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsMGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsLGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMaker:
                                {
                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Employee:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "担当者";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 明細ヘッダ
                                    this.EmployeeHeader.Visible = false;

                                    // 倉庫は表示しない
                                    this.SecHd_WarehouseTitle.Visible = false;
                                    this.SecHd_WarehouseCode.Visible = false;
                                    this.SecHd_WarehouseName.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_EmployeeCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_EmployeeName;

                                    this.DetailTitleCode.OutputFormat = "0000";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Section:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "拠点";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 明細ヘッダ
                                    this.EmployeeHeader.Visible = false;
                                    this.SectionHeader.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CompanyName1;

                                    this.DetailTitleCode.OutputFormat = "00";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                        }

                        // --- ADD 2008/10/08 --------------------------------<<<<<
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //// 担当者別レイアウト制御
                        //MakerName.Visible = true;
                        //MakerName.Top = GoodsMakerCd.Top;
                        ////BLGoodsHalfName.Visible = true; // DEL 2008/10/08
                        ////BLGoodsHalfName.Top = BLGoodsCode.Top; // DEL 2008/10/08
                        //GoodsLGroupCode.Visible = false;
                        //GoodsMGroupCode.Visible = false;
                        //BLGroupCode.Visible = false;
                        //GoodsNo.Visible = false;
                        //GoodsNameKana.Visible = false;

                        //// タイトル印字・非印字制御
                        ////Lb_Customer.Visible = false; // DEL 2008/10/08
                        ////Lb_Employee.Visible = true; // DEL 2008/10/08
                        ////Lb_Employee.Left = Lb_Customer.Left; // DEL 2008/10/08
                        //Lb_BLGroupCode.Visible = false;
                        //Lb_GoodsNo.Visible = false;
                        //Lb_GoodsName.Visible = false;
                        // --- DEL 2008/10/08 --------------------------------<<<<<
                    }
                    break;
                #endregion
                // 商品別
                #region 商品別
                case SalesRsltListCndtn.TotalTypeState.EachGoods:
                    {
                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 倉庫2
                        WarehouseHeader2.DataField = string.Empty;
                        WarehouseHeader2.Visible = false;
                        WarehouseHeader2.Visible = false;
                        // --- ADD 2008/10/08 --------------------------------<<<<<

                        // 拠点
                        SectionHeader.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true; // ADD 2008/10/08

                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 倉庫
                        WarehouseHeader.DataField = string.Empty;
                        WarehouseHeader.Visible = false;
                        WarehouseFooter.Visible = false;
                        // --- ADD 2008/10/08 --------------------------------<<<<<

                        // --- ADD 2009/04/11 -------------------------------->>>>>
                        // 仕入先
                        SupplierHeader.DataField = string.Empty;
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;
                        // --- ADD 2009/04/11 --------------------------------<<<<<

                        // 得意先
                        CustomerHeader.DataField = string.Empty;
                        CustomerHeader.Visible = false;
                        CustomerFooter.Visible = false;
                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // メーカー
                        MakerHeader.DataField = DCTOK02114EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;

                        // 商品大分類
                        //GoodsLGroupHeader.DataField = DCTOK02114EA.ct_Col_LargeGoodsGanreCode; // DEL 2008/10/08
                        GoodsLGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsLGroup; // ADD 2008/10/08
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;
                        // 商品中分類
                        //GoodsMGroupHeader.DataField = DCTOK02114EA.ct_Col_MediumGoodsGanreCode; // DEL 2008/10/08
                        GoodsMGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsMGroup; // ADD 2008/10/08
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;
                        // グループコード
                        //BLGroupCodeHeader.DataField = DCTOK02114EA.ct_Col_DetailGoodsGanreCode; // DEL 2008/10/08
                        BLGroupCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGroupCode; // ADD 2008/10/08
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;
                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;

                        // 画面の計印刷チェックによる制御
                        if (this._salesRsltListCndtn.SectionSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) SectionFooter.Visible = false;
                        if (this._salesRsltListCndtn.MakerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) MakerFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsLGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsMGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false;
                        if (this._salesRsltListCndtn.BLGroupCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false;
                        if (this._salesRsltListCndtn.BLGoodsCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false;
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //if ( this._salesRsltListCndtn.LGoodsGanreSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) GoodsLGroupFooter.Visible = false;
                        //if ( this._salesRsltListCndtn.MGoodsGanreSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) GoodsMGroupFooter.Visible = false;
                        //if ( this._salesRsltListCndtn.DGoodsGanreSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) BLGroupCodeFooter.Visible = false; 
                        //if ( this._salesRsltListCndtn.BLCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None ) BLGoodsCodeFooter.Visible = false;
                        // --- DEL 2008/10/08 --------------------------------<<<<<

                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        // 全社集計の場合、拠点を表示しない
                        if (this._salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.All)
                        {
                            this.SecHd_Title.Visible = false;
                            this.SecHd_AddUpSecCode.Visible = false;
                            this.SecHd_SectionGuideNm.Visible = false;
                        }
                        // --- ADD 2008/12/05 --------------------------------<<<<<

                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // 明細単位による明細行制御
                        // グループ化が必要になったため、ヘッダのvisible制御を追加 // ADD 2009/02/12
                        switch (this._salesRsltListCndtn.DetailDataValue)
                        {
                            case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                                {
                                    // 品名
                                    this.GoodsNameKana.DataField = DCTOK02114EA.ct_Col_GoodsNameKana;

                                    this.CodeNameFull20.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                                {
                                    // BLコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGoodsHalfName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsNo.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                                {
                                    // グループコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGroupKanaName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGoodsCode.Location;
                                    
                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                                {
                                    // 商品中分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsMGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                                {
                                    // 商品大分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsLGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsMGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsLGroupHeader.Visible = false; // ADD 2009/02/12
                                    
                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMaker:
                                {
                                    // メーカーで改行させない
                                    this.MakerHeader.Visible = false;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Section:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "拠点";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 明細ヘッダ
                                    this.MakerHeader.Visible = false;
                                    this.SectionHeader.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CompanyName1;

                                    this.DetailTitleCode.OutputFormat = "00";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;

                                    break;
                                }
                        }

                        // --- ADD 2008/10/08 --------------------------------<<<<<
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //// 商品別レイアウト制御
                        //MakerName.Visible = false;
                        //BLGoodsHalfName.Visible = false;
                        //GoodsLGroupCode.Visible = true;
                        //GoodsMGroupCode.Visible = true;
                        //BLGroupCode.Visible = true;
                        //GoodsNo.Visible = true;
                        //GoodsShortName.Visible = true;

                        //// タイトル印字・非印字制御
                        //Lb_Customer.Visible = false;
                        //Lb_Employee.Visible = false;
                        //Lb_BLGroupCode.Visible = true;
                        //Lb_GoodsNo.Visible = true;
                        //Lb_GoodsName.Visible = true;
                        // --- DEL 2008/10/08 --------------------------------<<<<<
                    }
                    break;
                #endregion
                // --- ADD 2008/10/08 -------------------------------->>>>>
                // 倉庫別
                #region 倉庫別
                case SalesRsltListCndtn.TotalTypeState.EachWareHouse:
                    {
                        // 明細ヘッダ制御とコントロール位置調整
                        if (this._salesRsltListCndtn.PrintType
                            == SalesRsltListCndtn.PrintTypeState.SectionWarehouse)
                        {
                            // 倉庫2
                            WarehouseHeader2.DataField = string.Empty;
                            WarehouseHeader2.Visible = false;
                            WarehouseHeader2.Visible = false;

                            // 拠点
                            SectionHeader.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                            SectionHeader.Visible = true;
                            SectionFooter.Visible = true;

                            if (this._salesRsltListCndtn.DetailDataValue
                                != SalesRsltListCndtn.DetailDataValueState.Warehouse)
                            {
                                SecHd_Title.Visible = false;
                                SecHd_AddUpSecCode.Visible = false;
                                SecHd_SectionGuideNm.Visible = false;
                                SecHd_Line1.Visible = false;
                                SecHd_line2.Visible = false;
                                SecHd_Line3.Visible = false; // ADD 2009/04/07

                                SectionHeader.Height = 0F;
                            }

                            // --- ADD 2008/12/05 -------------------------------->>>>>
                            // 全社集計の場合、拠点を表示しない
                            if (this._salesRsltListCndtn.TtlType
                            == SalesRsltListCndtn.TtlTypeState.All)
                            {
                                // 明細単位 拠点用
                                this.SecHd_Title.Visible = false;
                                this.SecHd_AddUpSecCode.Visible = false;
                                this.SecHd_SectionGuideNm.Visible = false;

                                // その他
                                this.WarHd_SectionTitle.Visible = false;
                                this.WarHd_AddUpSecCode.Visible = false;
                                this.WarHd_SectionGuideNm.Visible = false;

                                this.WarHd_WarehouseTitle.Location = this.WarHd_SectionTitle.Location;

                                point = this.WarHd_WarehouseTitle.Location;
                                point.X += this.WarHd_WarehouseTitle.Width;

                                this.WarHd_WarehouseCode.Location = point;

                                point.X += this.WarHd_WarehouseCode.Width;

                                this.WarHd_WarehouseName.Location = point;
                            }
                            // --- ADD 2008/12/05 --------------------------------<<<<<

                            // 倉庫
                            WarehouseHeader.DataField = DCTOK02114EA.ct_Col_WarehouseCode;
                            WarehouseHeader.Visible = true;
                            WarehouseFooter.Visible = true;

                            // --- ADD 2009/04/11 -------------------------------->>>>>
                            // 仕入先
                            SupplierHeader.DataField = string.Empty;
                            SupplierHeader.Visible = false;
                            SupplierFooter.Visible = false;
                            // --- ADD 2009/04/11 --------------------------------<<<<<

                            // 得意先
                            CustomerHeader.DataField = string.Empty;
                            CustomerHeader.Visible = false;
                            CustomerFooter.Visible = false;
                        }
                        else if (this._salesRsltListCndtn.PrintType
                            == SalesRsltListCndtn.PrintTypeState.WarehouseCustomer)
                        {
                            // 倉庫2
                            WarehouseHeader2.DataField = string.Empty;
                            WarehouseHeader2.Visible = false;
                            WarehouseHeader2.Visible = false;

                            // 拠点
                            SectionHeader.DataField = string.Empty;
                            SectionHeader.Visible = false;
                            SectionFooter.Visible = false;

                            // 倉庫
                            WarehouseHeader.DataField = DCTOK02114EA.ct_Col_WarehouseCode;
                            WarehouseHeader.Visible = true;
                            WarehouseFooter.Visible = true;

                            // コントロールは表示しない
                            if (this._salesRsltListCndtn.DetailDataValue
                                != SalesRsltListCndtn.DetailDataValueState.Customer)
                            {
                                this.WarHd_SectionTitle.Visible = false;
                                this.WarHd_AddUpSecCode.Visible = false;
                                this.WarHd_SectionGuideNm.Visible = false;
                                this.WarHd_WarehouseTitle.Visible = false;
                                this.WarHd_WarehouseCode.Visible = false;
                                this.WarHd_WarehouseName.Visible = false;
                                this.WarHd_line1.Visible = false;
                                this.WarHd_line2.Visible = false;
                                this.WarHd_line3.Visible = false; // ADD 2009/04/07

                                this.WarehouseHeader.Height = 0F;
                            }
                            else
                            {
                                // 拠点は表示しない
                                this.WarHd_SectionTitle.Visible = false;
                                this.WarHd_AddUpSecCode.Visible = false;
                                this.WarHd_SectionGuideNm.Visible = false;
                            }

                            // 得意先
                            CustomerHeader.DataField = DCTOK02114EA.ct_Col_CustomerCode;
                            CustomerHeader.Visible = true;
                            CustomerFooter.Visible = true;

                            // 位置調整
                            this.CusHd_SectionTitle.Visible = false;
                            this.CusHd_AddUpSecCode.Visible = false;
                            this.CusHd_SectionGuideNm.Visible = false;

                            this.CusHd_WarehouseTitle.Visible = true;
                            this.CusHd_WarehouseCode.Visible = true;
                            this.CusHd_WarehouseName.Visible = true;

                            //this.line35.Visible = true;         //ADD 2008/10/23 // DEL 2008/12/11
                            //this.line39.Visible = true;         //ADD 2008/10/23 // DEL 2008/12/11

                            this.CusHd_WarehouseTitle.Location = this.CusHd_SectionTitle.Location;
                            this.CusHd_WarehouseCode.Location = this.CusHd_AddUpSecCode.Location;

                            point = this.WarHd_SectionTitle.Location;
                            this.WarHd_WarehouseTitle.Location = point;

                            point.X += this.WarHd_WarehouseTitle.Width;
                            this.WarHd_WarehouseCode.Location = point;

                            point.X += this.WarHd_WarehouseCode.Width;
                            this.WarHd_WarehouseName.Location = point;
                            

                            point = this.CusHd_WarehouseCode.Location;
                            point.X += this.CusHd_WarehouseCode.Width + 0.25F;

                            this.CusHd_WarehouseName.Location = point;
                        }
                        else if (this._salesRsltListCndtn.PrintType
                            == SalesRsltListCndtn.PrintTypeState.WarehouseSection)
                        {
                            // 倉庫2
                            WarehouseHeader2.DataField = DCTOK02114EA.ct_Col_WarehouseCode;
                            WarehouseHeader2.Visible = true;
                            WarehouseFooter2.Visible = true;

                            // コントロールは表示しない
                            if (this._salesRsltListCndtn.DetailDataValue
                                != SalesRsltListCndtn.DetailDataValueState.Section)
                            {
                                this.War2Hd_WarehouseTitle.Visible = false;
                                this.War2Hd_WarehouseCode.Visible = false;
                                this.War2Hd_WarehouseName.Visible = false;
                                this.War2Hd_Line1.Visible = false;
                                this.War2Hd_Line2.Visible = false;
                                this.War2Hd_Line3.Visible = false; // ADD 2009/04/07

                                this.WarehouseHeader2.Height = 0F;
                            }

                            // 拠点
                            SectionHeader.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                            SectionHeader.Visible = true;
                            SectionFooter.Visible = true;

                            // 明細ヘッダ調整
                            SecHd_WarehouseTitle.Visible = true;
                            SecHd_WarehouseCode.Visible = true;
                            SecHd_WarehouseName.Visible = true;

                            point = this.SecHd_Title.Location;
                            this.SecHd_Title.Location = this.SecHd_WarehouseTitle.Location;
                            this.SecHd_WarehouseTitle.Location = point;

                            point = this.SecHd_Title.Location;

                            point.X += this.SecHd_Title.Width;
                            this.SecHd_AddUpSecCode.Location = point;

                            point.X += this.SecHd_AddUpSecCode.Width;
                            this.SecHd_SectionGuideNm.Location = point;

                            point = this.SecHd_WarehouseTitle.Location;

                            point.X += this.SecHd_WarehouseTitle.Width;
                            this.SecHd_WarehouseCode.Location = point;

                            point.X += this.SecHd_WarehouseCode.Width;
                            this.SecHd_WarehouseName.Location = point;

                            // --- ADD 2008/12/05 -------------------------------->>>>>
                            // 全社集計の場合、拠点を表示しない
                            if (this._salesRsltListCndtn.TtlType
                            == SalesRsltListCndtn.TtlTypeState.All)
                            {
                                this.SecHd_Title.Visible = false;
                                this.SecHd_AddUpSecCode.Visible = false;
                                this.SecHd_SectionGuideNm.Visible = false;
                            }
                            // --- ADD 2008/12/05 --------------------------------<<<<<

                            // 倉庫
                            WarehouseHeader.DataField = string.Empty;
                            WarehouseHeader.Visible = false;
                            WarehouseFooter.Visible = false;

                            // 得意先
                            CustomerHeader.DataField = string.Empty;
                            CustomerHeader.Visible = false;
                            CustomerFooter.Visible = false;
                        }

                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // メーカー
                        MakerHeader.DataField = DCTOK02114EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;

                        // 商品大分類
                        GoodsLGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsLGroup;
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;
                        // 商品中分類
                        GoodsMGroupHeader.DataField = DCTOK02114EA.ct_Col_GoodsMGroup;
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;
                        // グループコード
                        BLGroupCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGroupCode;
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;
                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02114EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;

                        // 画面の計印刷チェックによる制御
                        if (this._salesRsltListCndtn.SectionSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) SectionFooter.Visible = false;
                        if (this._salesRsltListCndtn.WarehouseSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None)
                        {
                            WarehouseFooter.Visible = false;
                            WarehouseFooter2.Visible = false;
                        }
                        if (this._salesRsltListCndtn.CustomerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) CustomerFooter.Visible = false;
                        if (this._salesRsltListCndtn.MakerSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) MakerFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsLGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false;
                        if (this._salesRsltListCndtn.GoodsMGroupSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false;
                        if (this._salesRsltListCndtn.BLGroupCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false; 
                        if (this._salesRsltListCndtn.BLGoodsCodeSumPrintDiv == SalesRsltListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false;

                        // 明細単位による明細行制御
                        // グループ化が必要になったため、ヘッダのvisible制御を追加 // ADD 2009/02/12
                        switch (this._salesRsltListCndtn.DetailDataValue)
                        {
                            case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                                {
                                    // 品名
                                    this.GoodsNameKana.DataField = DCTOK02114EA.ct_Col_GoodsNameKana;

                                    this.CodeNameFull20.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                                {
                                    // BLコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGoodsHalfName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsNo.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                                {
                                    // グループコード名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_BLGroupKanaName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGoodsCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                                {
                                    // 商品中分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsMGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.BLGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                                {
                                    // 商品大分類名称
                                    this.CodeNameFull20.DataField = DCTOK02114EA.ct_Col_GoodsLGroupName;

                                    // 位置調整
                                    this.CodeNameFull20.Location = this.GoodsMGroupCode.Location;

                                    // 表示調整
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;

                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;

                                    this.BLGoodsCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.BLGroupCodeHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsMGroupHeader.Visible = false; // ADD 2009/02/12
                                    this.GoodsLGroupHeader.Visible = false; // ADD 2009/02/12

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.GoodsMaker:
                                {
                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;

                                    break;
                                }
                            case SalesRsltListCndtn.DetailDataValueState.Section:
                                {
                                    if (this._salesRsltListCndtn.PrintType
                                        == SalesRsltListCndtn.PrintTypeState.SectionWarehouse)
                                    {
                                        // 明細ヘッダ
                                        this.WarehouseHeader.Visible = false;
                                        this.SectionHeader.Visible = false;
                                    }
                                    else if (this._salesRsltListCndtn.PrintType
                                        == SalesRsltListCndtn.PrintTypeState.WarehouseSection)
                                    {
                                        // 明細ヘッダ
                                        this.SectionHeader.Visible = false;
                                    }

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_AddUpSecCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CompanyName1;

                                    this.DetailTitleCode.OutputFormat = "00";

                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "拠点";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;
                                }
                                break;
                            case SalesRsltListCndtn.DetailDataValueState.Customer:
                                {
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "得意先";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 明細ヘッダ
                                    this.CustomerHeader.Visible = false;

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_CustomerCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_CustomerSnm;

                                    this.DetailTitleCode.OutputFormat = "00000000";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;
                                }
                                break;
                            case SalesRsltListCndtn.DetailDataValueState.Warehouse:
                                {
                                    if (this._salesRsltListCndtn.PrintType
                                        == SalesRsltListCndtn.PrintTypeState.SectionWarehouse)
                                    {
                                        // 明細ヘッダ
                                        this.WarehouseHeader.Visible = false;

                                    }
                                    else if (this._salesRsltListCndtn.PrintType
                                        == SalesRsltListCndtn.PrintTypeState.WarehouseCustomer)
                                    {
                                        this.CustomerHeader.Visible = false;
                                        this.WarehouseHeader.Visible = false;
                                    }
                                    else if (this._salesRsltListCndtn.PrintType
                                        == SalesRsltListCndtn.PrintTypeState.WarehouseSection)
                                    {
                                        // 明細ヘッダ
                                        this.SectionHeader.Visible = false;
                                        this.WarehouseHeader2.Visible = false;
                                    }
                                    // ラベル
                                    this.Lb_DetailTitleCode.Visible = true;
                                    this.Lb_DetailTitleCode.Location = this.Lb_MakerName.Location;
                                    this.Lb_DetailTitleCode.Text = "倉庫";

                                    //this.line36.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11
                                    //this.line38.Visible = true;     //ADD 2008/10/23 // DEL 2008/12/11

                                    // 明細部
                                    this.DetailTitleCode.Visible = true;
                                    this.DetailTitleName.Visible = true;

                                    this.DetailTitleCode.DataField = DCTOK02114EA.ct_Col_WarehouseCode;
                                    this.DetailTitleName.DataField = DCTOK02114EA.ct_Col_WarehouseName;

                                    this.DetailTitleCode.OutputFormat = "0000";

                                    // 位置調整
                                    point = this.GoodsMakerCd.Location;
                                    this.DetailTitleCode.Location = point;

                                    point.X += DetailTitleCode.Width + 0.25F;

                                    this.DetailTitleName.Location = point;

                                    // 表示調整
                                    this.CodeNameFull20.Visible = false;
                                    this.GoodsNameKana.Visible = false;
                                    this.GoodsNo.Visible = false;
                                    this.BLGoodsCode.Visible = false;
                                    this.BLGroupCode.Visible = false;
                                    this.GoodsMGroupCode.Visible = false;
                                    this.GoodsLGroupCode.Visible = false;
                                    this.GoodsMakerCd.Visible = false;
                                    this.MakerName.Visible = false;

                                    this.Lb_GoodsNo.Visible = false;
                                    this.Lb_GoodsName.Visible = false;
                                    this.Lb_BLGoodsCode.Visible = false;
                                    this.Lb_BLGroupCode.Visible = false;
                                    this.Lb_GoodsMGroup.Visible = false;
                                    this.Lb_GoodsLGroup.Visible = false;
                                    this.Lb_MakerName.Visible = false;
                                }
                                break;
                        }
                    }
                    break;
                #endregion
                // --- ADD 2008/10/08 -------------------------------->>>>>
                default:
                    break;
            }
            #endregion [帳票タイプ別切り替え]

            //-------------------------------------------------------
            // 改頁設定適用
            //-------------------------------------------------------
            #region [改ページ設定適用]
            CustomerHeader.NewPage = NewPage.None;
            EmployeeHeader.NewPage = NewPage.None;
            MakerHeader.NewPage = NewPage.None;
            SectionHeader.NewPage = NewPage.None;
            WarehouseHeader.NewPage = NewPage.None; // ADD 2008/10/08
            WarehouseHeader2.NewPage = NewPage.None; // ADD 2008/10/08
            SupplierHeader.NewPage = NewPage.None; //ADD 2009/04/11

            switch ( this._salesRsltListCndtn.NewPageDiv )
            {
                case SalesRsltListCndtn.NewPageDivState.EachCustomer:
                    CustomerHeader.NewPage = NewPage.Before;
                    break;
                case SalesRsltListCndtn.NewPageDivState.EachEmployee:
                    EmployeeHeader.NewPage = NewPage.Before;
                    break;
                case SalesRsltListCndtn.NewPageDivState.EachSupplier:  // ADD 2009/04/11
                    SupplierHeader.NewPage = NewPage.Before;
                    break;
                case SalesRsltListCndtn.NewPageDivState.EachMaker:
                    MakerHeader.NewPage = NewPage.Before;
                    break;
                case SalesRsltListCndtn.NewPageDivState.EachSection:
                    SectionHeader.NewPage = NewPage.Before;
                    break;
                case SalesRsltListCndtn.NewPageDivState.None:
                    break;
                case SalesRsltListCndtn.NewPageDivState.EachWareHouse: // ADD 2008/10/08
                    if (this._salesRsltListCndtn.PrintType == SalesRsltListCndtn.PrintTypeState.WarehouseSection)
                    {
                        WarehouseHeader2.NewPage = NewPage.Before;
                    }
                    else
                    {
                        WarehouseHeader.NewPage = NewPage.Before;
                    }
                    break;
                default:
                    break;
            }
            #endregion [改ページ設定適用]

            //-------------------------------------------------------
            // 当期印刷
            //-------------------------------------------------------
            #region [当月・当期切替]
            if (this._salesRsltListCndtn.TotalType == SalesRsltListCndtn.TotalTypeState.EachWareHouse
                && this._salesRsltListCndtn.AnnualPrintDiv == SalesRsltListCndtn.AnnualPrintDivState.None)
            {
                // 当期項目を全て非表示にする。
                this.Lb_AnnualTitle.Visible = false;
                this.Lb_AnnualSalesCount.Visible = false;
                this.Lb_AnnualSalesMoney.Visible = false;
                this.Lb_AnnualGrossProfit.Visible = false;
                this.Lb_AnnualGrossProfitRate.Visible = false;

                this.AnnualTotalSalesCount.Visible = false;
                this.AnnualSalesMoney.Visible = false;
                this.AnnualGrossProfit.Visible = false;
                this.AnnualGrossProfitRate.Visible = false;

                this.BlFt_TtlTotalSalesCount.Visible = false;
                this.BlFt_TtlSalesPrice.Visible = false;
                this.BlFt_TtlGrossProfit.Visible = false;
                this.BlFt_TtlGrossProfitRate.Visible = false;

                this.DggFt_TtlTotalSalesCount.Visible = false;
                this.DggFt_TtlSalesPrice.Visible = false;
                this.DggFt_TtlGrossProfit.Visible = false;
                this.DggFt_TtlGrossProfitRate.Visible = false;

                this.MggFt_TtlTotalSalesCount.Visible = false;
                this.MggFt_TtlSalesPrice.Visible = false;
                this.MggFt_TtlGrossProfit.Visible = false;
                this.MggFt_TtlGrossProfitRate.Visible = false;

                this.LggFt_TtlTotalSalesCount.Visible = false;
                this.LggFt_TtlSalesPrice.Visible = false;
                this.LggFt_TtlGrossProfit.Visible = false;
                this.LggFt_TtlGrossProfitRate.Visible = false;

                this.MakFt_TtlTotalSalesCount.Visible = false;
                this.MakFt_TtlSalesPrice.Visible = false;
                this.MakFt_TtlGrossProfit.Visible = false;
                this.MakFt_TtlGrossProfitRate.Visible = false;

                this.EmpFt_TtlTotalSalesCount.Visible = false;
                this.EmpFt_TtlSalesPrice.Visible = false;
                this.EmpFt_TtlGrossProfit.Visible = false;
                this.EmpFt_TtlGrossProfitRate.Visible = false;

                this.CusFt_TtlTotalSalesCount.Visible = false;
                this.CusFt_TtlSalesPrice.Visible = false;
                this.CusFt_TtlGrossProfit.Visible = false;
                this.CusFt_TtlGrossProfitRate.Visible = false;

                this.WarFt_TtlTotalSalesCount.Visible = false;
                this.WarFt_TtlSalesPrice.Visible = false;
                this.WarFt_TtlGrossProfit.Visible = false;
                this.WarFt_TtlGrossProfitRate.Visible = false;

                this.SecFt_TtlTotalSalesCount.Visible = false;
                this.SecFt_TtlSalesPrice.Visible = false;
                this.SecFt_TtlGrossProfit.Visible = false;
                this.SecFt_TtlGrossProfitRate.Visible = false;

                this.War2Ft_TtlTotalSalesCount.Visible = false;
                this.War2Ft_TtlSalesPrice.Visible = false;
                this.War2Ft_TtlGrossProfit.Visible = false;
                this.War2Ft_TtlGrossProfitRate.Visible = false;

                this.Ttl_TtlTotalSalesCount.Visible = false;
                this.Ttl_TtlSalesPrice.Visible = false;
                this.Ttl_TtlGrossProfit.Visible = false;
                this.Ttl_TtlGrossProfitRate.Visible = false;

                // --- ADD 2009/04/11 --------------------------->>>>>
                this.SupFt_TtlTotalSalesCount.Visible = false; 
                this.SupFt_TtlSalesPrice.Visible = false; 
                this.SupFt_TtlGrossProfit.Visible = false; 
                this.SupFt_TtlGrossProfitRate.Visible = false;
                // --- ADD 2009/04/11 ---------------------------<<<<<
            }
            #endregion

            //-------------------------------------------------------
            // メーカー別印刷切替
            //-------------------------------------------------------
            #region メーカー別印刷
            if (this._salesRsltListCndtn.MakerPrintDiv == SalesRsltListCndtn.MakerPrintDivState.None)
            {
                // メーカーを表示しない
                this.GoodsMakerCd.Visible = false;
                this.MakerName.Visible = false;
            }
            #endregion
        }
        /// <summary>
        /// 範囲月数の取得処理
        /// </summary>
        /// <returns>範囲月数（ex.４月～６月ならば３）</returns>
        private int GetMonthRange ( DateTime stYearMonth, DateTime edYearMonth )
        {
            int stMonth = stYearMonth.Month;
            int edMonth = edYearMonth.Month;

            if ( edYearMonth.Year > stYearMonth.Year )
            {
                edMonth += 12;
            }

            return ( edMonth - stMonth + 1 );
        }
        /// <summary>
        /// 月タイトル取得
        /// </summary>
        /// <param name="stYearMonth"></param>
        /// <param name="index"></param>
        /// <returns>月タイトル(ex.１月,２月…)</returns>
        private string GetMonthTitle ( DateTime stYearMonth, int index )
        {
            int month = stYearMonth.Month + index;

            if ( month > 12 ) month -= 12;

            return ( month.ToString() + "月" );
        }
        #endregion ◆ レポート要素出力設定

        #region ◆ グループサプレス関係
        #region ◎ グループサプレス判断
        /// <summary>
        /// グループサプレス判断
        /// </summary>
        private void CheckGroupSuppression ()
        {
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
        }
        #endregion
        #endregion

        #region ◆ 明細部グループ化(項目visible制御)
        /// <summary>
        /// 明細部のグループ化(明細1行目のみ表示する)
        /// </summary>
        private void SetGroupByDetail()
        {
            switch (this._salesRsltListCndtn.DetailDataValue)
            {
                case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                    {
                        this.BLGoodsCode.Visible = true;
                        this.BLGroupCode.Visible = true;
                        this.GoodsMGroupCode.Visible = true;
                        this.GoodsLGroupCode.Visible = true;
                        this.MakerName.Visible = true;
                        this.GoodsMakerCd.Visible = true;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                    {
                        this.BLGroupCode.Visible = true;
                        this.GoodsMGroupCode.Visible = true;
                        this.GoodsLGroupCode.Visible = true;
                        this.MakerName.Visible = true;
                        this.GoodsMakerCd.Visible = true;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                    {
                        this.GoodsMGroupCode.Visible = true;
                        this.GoodsLGroupCode.Visible = true;
                        this.MakerName.Visible = true;
                        this.GoodsMakerCd.Visible = true;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                    {
                        this.GoodsLGroupCode.Visible = true;
                        this.MakerName.Visible = true;
                        this.GoodsMakerCd.Visible = true;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                    {
                        this.MakerName.Visible = true;
                        this.GoodsMakerCd.Visible = true;

                        break;
                    }
            }
        }
        #endregion
        #endregion

        #region ■ Control Event

        #region ◎ DCZAI02103P_01A4C_ReportStart Event
        /// <summary>
        /// DCZAI02103P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCZAI02103P_01A4C_ReportStart ( object sender, System.EventArgs eArgs )
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ DCZAI02103P_01A4C_PageEnd Event
        /// <summary>
        /// DCZAI02103P_01A4C_PageEnd Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DCZAI02103P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCZAI02103P_01A4C_PageEnd ( object sender, System.EventArgs eArgs )
        {
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）

            this._groupFirstRowVisibleFlg = true; // ADD 2009/02/12
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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void PageHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString( SalesRsltListCndtn.ct_DateFomat, DateTime.Now );
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString( "HH:mm" );

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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 抽出条件設定
            // ヘッダ出力制御
            if ( this._extraCondHeadOutDiv == 0 )
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
            if ( this._rptExtraHeader == null )
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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>Update Note : 2014/12/04 周洋</br>
        /// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void Detail_Format ( object sender, System.EventArgs eArgs )
        {
            // -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
            TextBox[] arrDetail = new TextBox[] { MonthSalesMoney, MonthGrossProfit, AnnualSalesMoney, AnnualGrossProfit };
            foreach (TextBox i in arrDetail)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top;  ";
                }
            }
            // -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
        {
            //Line_DetailHead.Visible = Line_DetailHead_Visible; // DEL 2009/04/07

            // グループサプレスの判断
            this.CheckGroupSuppression();
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString( this.Detail );

            // --- ADD 2008/10/23 -------------------------------------->>>>>
            // ALL0は表示しない
            if (this.GoodsMakerCd.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.GoodsMakerCd.Text = string.Empty;
            }
            if (this.GoodsLGroupCode.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.GoodsLGroupCode.Text = string.Empty;
            }
            if (this.GoodsMGroupCode.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.GoodsMGroupCode.Text = string.Empty;
            }
            if (this.BLGroupCode.Text.PadLeft(5, '0').Equals("00000"))
            {
                this.BLGroupCode.Text = string.Empty;
            }
            if (this.BLGoodsCode.Text.PadLeft(5, '0').Equals("00000"))
            {
                this.BLGoodsCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 --------------------------------------<<<<<
            // --- ADD 2008/12/11 -------------------------------->>>>>
            if (this._salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.All
                && this._salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Section)
            {
                // 集計方法「全社」、明細単位「拠点」の場合、全社を表示。
                this.DetailTitleName.Text = "全社";
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<

            // --- ADD 2009/02/12 -------------------------------->>>>>
            if (this._groupFirstRowVisibleFlg)
            {
                this.SetGroupByDetail();
            }
            // --- ADD 2009/02/12 --------------------------------<<<<<
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
        /// <br>Programmer  : 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // 印刷件数カウントアップ
            this._printCount++;

            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = false;    //2明細目以降は印字しない
            //Line_DetailHead_Visible = false;    //2明細目以降は印字しない // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- DEL 2009/02/12 -------------------------------->>>>>
            // グループ化のため、1行目の印字後は非表示
            // 各Detailでグループ化最後のコード、名称は消さない
            switch (this._salesRsltListCndtn.DetailDataValue)
            {
                case SalesRsltListCndtn.DetailDataValueState.GoosNo:
                    {
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.MakerName.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.BLGoodsCode:
                    {
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.MakerName.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.BLGroupCode:
                    {
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.MakerName.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.GoodsMGroup:
                    {
                        this.GoodsLGroupCode.Visible = false;
                        this.MakerName.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        break;
                    }
                case SalesRsltListCndtn.DetailDataValueState.GoodsLGroup:
                    {
                        this.MakerName.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        break;
                    }
            }

            this._groupFirstRowVisibleFlg = false;
            // --- ADD 2009/02/12 --------------------------------<<<<<

#if DEBUG
            return;
#endif

            if ( this.ProgressBarUpEvent != null )
            {
                this.ProgressBarUpEvent( this, this._printCount );
            }

        }
        #endregion

        #region ◎ DailyFooter_Format Event
        /// <summary>
        /// DailyFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DailyFooter_Format Event</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DailyFooter_Format ( object sender, System.EventArgs eArgs )
        {
            // TODO : 前行KEY退避をクリア（次明細はサプレス解除）
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
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
        {
            // 2009.03.17 30413 犬飼 フッター部の印字対応 >>>>>>START
            // --- DEL 2008/10/08 -------------------------------->>>>>
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
            // --- DEL 2008/10/08 --------------------------------<<<<<
            // 2009.03.17 30413 犬飼 フッター部の印字対応 <<<<<<END
        }
        #endregion

        # region ■ 小計フッタ　印刷前処理 ■
        /// <summary>
        /// ＢＬコード計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGoodsCodeFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //BlFt_GrossProfitRate.Text = GetGrossProfitRate(BlFt_GrossProfitOrg, BlFt_MonthPureSalesMoney).ToString(_rateFormat); // DEL 2008/10/08
            //BlFt_TtlGrossProfitRate.Text = GetGrossProfitRate(BlFt_TtlGrossProfitOrg, BlFt_AnnualPureSalesMoney).ToString(_rateFormat); // DEL 2008/10/08
            BlFt_GrossProfitRate.Text = GetGrossProfitRate(BlFt_MonthGrossProfitOrg, BlFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            BlFt_TtlGrossProfitRate.Text = GetGrossProfitRate(BlFt_AnnualGrossProfitOrg, BlFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.BlFt_BLGoodsCode.Text.PadLeft(5, '0').Equals("00000"))
            {
                this.BlFt_BLGoodsCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        /// <summary>
        /// グループコード計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGoodsGanreFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //DggFt_GrossProfitRate.Text = GetGrossProfitRate(DggFt_GrossProfitOrg, DggFt_MonthPureSalesMoney).ToString(_rateFormat); // DEL 2008/10/08
            //DggFt_TtlGrossProfitRate.Text = GetGrossProfitRate(DggFt_TtlGrossProfitOrg, DggFt_AnnualPureSalesMoney).ToString(_rateFormat); // DEL 2008/10/08
            DggFt_GrossProfitRate.Text = GetGrossProfitRate(DggFt_MonthGrossProfitOrg, DggFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            DggFt_TtlGrossProfitRate.Text = GetGrossProfitRate(DggFt_AnnualGrossProfitOrg, DggFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.DggFt_DetailGoodsGanreCode.Text.PadLeft(5, '0').Equals("00000"))
            {
                this.DggFt_DetailGoodsGanreCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        /// <summary>
        /// 商品中分類計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MGoodsGanreFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //MggFt_GrossProfitRate.Text = GetGrossProfitRate( MggFt_GrossProfitOrg, MggFt_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //MggFt_TtlGrossProfitRate.Text = GetGrossProfitRate( MggFt_TtlGrossProfitOrg, MggFt_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            MggFt_GrossProfitRate.Text = GetGrossProfitRate(MggFt_MonthGrossProfitOrg, MggFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            MggFt_TtlGrossProfitRate.Text = GetGrossProfitRate(MggFt_AnnualGrossProfitOrg, MggFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.MggFt_MediumGoodsGanreCode.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.MggFt_MediumGoodsGanreCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        /// <summary>
        /// 商品大分類計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LGoodsGanreFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //LggFt_GrossProfitRate.Text = GetGrossProfitRate( LggFt_GrossProfitOrg, LggFt_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //LggFt_TtlGrossProfitRate.Text = GetGrossProfitRate( LggFt_TtlGrossProfitOrg, LggFt_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            LggFt_GrossProfitRate.Text = GetGrossProfitRate(LggFt_MonthGrossProfitOrg, LggFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            LggFt_TtlGrossProfitRate.Text = GetGrossProfitRate(LggFt_AnnualGrossProfitOrg, LggFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            //Line_DetailHead.Visible = true; // DEL 2009/04/07

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.LggFt_LargeGoodsGanreCode.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.LggFt_LargeGoodsGanreCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        /// <summary>
        /// メーカー計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //MakFt_GrossProfitRate.Text = GetGrossProfitRate( MakFt_GrossProfitOrg, MakFt_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //MakFt_TtlGrossProfitRate.Text = GetGrossProfitRate( MakFt_TtlGrossProfitOrg, MakFt_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            MakFt_GrossProfitRate.Text = GetGrossProfitRate(MakFt_MonthGrossProfitOrg, MakFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            MakFt_TtlGrossProfitRate.Text = GetGrossProfitRate(MakFt_AnnualGrossProfitOrg, MakFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.MakFt_GoodsMakerCd.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.MakFt_GoodsMakerCd.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        /// <summary>
        /// 担当者計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //EmpFt_GrossProfitRate.Text = GetGrossProfitRate( EmpFt_GrossProfitOrg, EmpFt_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //EmpFt_TtlGrossProfitRate.Text = GetGrossProfitRate( EmpFt_TtlGrossProfitOrg, EmpFt_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            EmpFt_GrossProfitRate.Text = GetGrossProfitRate(EmpFt_MonthGrossProfitOrg, EmpFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            EmpFt_TtlGrossProfitRate.Text = GetGrossProfitRate(EmpFt_AnnualGrossProfitOrg, EmpFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.EmpFt_EmployeeCode.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.EmpFt_EmployeeCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        /// <summary>
        /// 得意先計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //CusFt_GrossProfitRate.Text = GetGrossProfitRate( CusFt_GrossProfitOrg, CusFt_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //CusFt_TtlGrossProfitRate.Text = GetGrossProfitRate( CusFt_TtlGrossProfitOrg, CusFt_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            CusFt_GrossProfitRate.Text = GetGrossProfitRate(CusFt_MonthGrossProfitOrg, CusFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            CusFt_TtlGrossProfitRate.Text = GetGrossProfitRate(CusFt_AnnualGrossProfitOrg, CusFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.CusFt_CustomerCode.Text.PadLeft(8, '0').Equals("00000000"))
            {
                this.CusFt_CustomerCode.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }

        // --- ADD 2009/04/11 -------------------------------->>>>>
        /// <summary>
        /// 仕入先計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            SupFt_GrossProfitRate.Text = GetGrossProfitRate(SupFt_MonthGrossProfitOrg, SupFt_MonthPureSalesMoney).ToString(_rateFormat);
            SupFt_TtlGrossProfitRate.Text = GetGrossProfitRate(SupFt_AnnualGrossProfitOrg, SupFt_AnnualPureSalesMoney).ToString(_rateFormat);

            // del 2009/06/24
            //// ALL0は表示しない
            //if (this.SupFt_SupplierCode.Text.PadLeft(6, '0').Equals("000000"))
            //{
            //    this.SupFt_SupplierCode.Text = string.Empty;
            //}
        }
        // --- ADD 2009/04/11 --------------------------------<<<<<

        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>
        /// 倉庫計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            WarFt_GrossProfitRate.Text = GetGrossProfitRate(WarFt_MonthGrossProfitOrg, WarFt_MonthPureSalesMoney).ToString(_rateFormat);
            WarFt_TtlGrossProfitRate.Text = GetGrossProfitRate(WarFt_AnnualGrossProfitOrg, WarFt_AnnualPureSalesMoney).ToString(_rateFormat);
            // 罫線制御
            //Line_DetailHead_Visible = true; // DEL 2009/04/07

            // --- ADD 2008/10/23 --------------------------------------------->>>>>
            // ALL0は表示しない
            if (this.textBox2.Text.PadLeft(4, '0').Equals("0000"))
            {
                this.textBox2.Text = string.Empty;
            }
            // --- ADD 2008/10/23 ---------------------------------------------<<<<<
        }
        // --- ADD 2008/10/08 --------------------------------<<<<<
        /// <summary>
        /// 拠点計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            //SecFt_GrossProfitRate.Text = GetGrossProfitRate( SecFt_GrossProfitOrg, SecFt_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //SecFt_TtlGrossProfitRate.Text = GetGrossProfitRate( SecFt_TtlGrossProfitOrg, SecFt_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            SecFt_GrossProfitRate.Text = GetGrossProfitRate(SecFt_MonthGrossProfitOrg, SecFt_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            SecFt_TtlGrossProfitRate.Text = GetGrossProfitRate(SecFt_AnnualGrossProfitOrg, SecFt_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>
        /// 倉庫計2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseFooter2_BeforePrint(object sender, EventArgs e)
        {
            // 粗利率算出と印字
            War2Ft_GrossProfitRate.Text = GetGrossProfitRate(War2Ft_MonthGrossProfitOrg, War2Ft_MonthPureSalesMoney).ToString(_rateFormat);
            War2Ft_TtlGrossProfitRate.Text = GetGrossProfitRate(War2Ft_AnnualGrossProfitOrg, War2Ft_AnnualPureSalesMoney).ToString(_rateFormat);
            // 罫線制御
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
        }
        // --- ADD 2008/10/08 --------------------------------<<<<<
        /// <summary>
        /// 総合計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            //decimal grate = GetGrossProfitRate( Ttl_GrossProfitOrg, Ttl_MonthPureSalesMoney );

            // 粗利率算出と印字
            //Ttl_GrossProfitRate.Text = GetGrossProfitRate( Ttl_GrossProfitOrg, Ttl_MonthPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            //Ttl_TtlGrossProfitRate.Text = GetGrossProfitRate( Ttl_TtlGrossProfitOrg, Ttl_AnnualPureSalesMoney ).ToString( _rateFormat ); // DEL 2008/10/08
            Ttl_GrossProfitRate.Text = GetGrossProfitRate(Ttl_MonthGrossProfitOrg, Ttl_MonthPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            Ttl_TtlGrossProfitRate.Text = GetGrossProfitRate(Ttl_AnnualGrossProfitOrg, Ttl_AnnualPureSalesMoney).ToString(_rateFormat); // ADD 2008/10/08
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// 粗利率算出処理（テキストボックスTextから取得する）
        /// </summary>
        /// <param name="tbGrossProfit">粗利のテキストボックス</param>
        /// <param name="tbSalesPrice">純売上のテキストボックス</param>
        /// <returns>粗利率(%)</returns>
        private decimal GetGrossProfitRate(TextBox tbGrossProfit, TextBox tbSalesPrice)
        {
            Int64 grossProfit = GetValueFromTextBox(tbGrossProfit);
            Int64 salesPrice = GetValueFromTextBox(tbSalesPrice);
            decimal grossProfitRate;

            if (salesPrice == 0 || grossProfit == 0)
            {
                return 0m;
            }
            else
            {
                grossProfitRate = (decimal)grossProfit / (decimal)salesPrice * 100.00m;

                /* --- DEL 2008/10/23 マイナス時はマイナス値を印字 -------------->>>>>
                if (grossProfitRate < 0)
                {
                    grossProfitRate = grossProfitRate * -1;
                }
                   --- DEL 2008/10/23 -------------------------------------------<<<<< */

                return grossProfitRate;
            }
        }
        /// <summary>
        /// テキストボックスからの数値取得処理
        /// </summary>
        /// <param name="targetTextBox"></param>
        /// <returns></returns>
        private Int64 GetValueFromTextBox(TextBox targetTextBox)
        {
            try
            {
                return Int64.Parse(targetTextBox.Text.Replace(",", ""));
            }
            catch
            {
                return 0;
            }
        }
        # endregion ■ 小計　印刷前処理 ■

        # region ■ ヘッダ　拠点コード名称設定 ■
        /// <summary>
        /// 拠点ヘッダ印刷前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_BeforePrint(object sender, EventArgs e)
        {
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //if (this._salesRsltListCndtn.GroupBySectionDiv == SalesRsltListCndtn.GroupBySectionDivState.All) // DEL 2008/10/08
            //{
            //    SecHd_AddUpSecCode.Visible = false;
            //    SecHd_SectionGuideNm.Text = "全社集計";
            //}
            // --- DEL 2008/10/08 --------------------------------<<<<<
            //// 罫線制御
            //Line_DetailHead.Visible = true;
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 各コード値が0の場合は表示しない
            if (this.SecHd_AddUpSecCode.Text == null
                || this.SecHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.SecHd_AddUpSecCode.Text = "";
                this.SecHd_SectionGuideNm.Text = "";
            }

            if (this.SecHd_WarehouseCode.Text == null
                || this.SecHd_WarehouseCode.Text.PadLeft(4, '0') == "0000")
            {
                this.SecHd_WarehouseCode.Text = "";
                this.SecHd_WarehouseName.Text = "";
            }
            // --- ADD 2008/10/08 --------------------------------<<<<< 

            this._groupFirstRowVisibleFlg = true; // ADD 2009/02/12
        }
        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>
        /// 倉庫ヘッダ2印刷後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader2_AfterPrint(object sender, EventArgs e)
        {
            // 罫線制御
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
        }
        /// <summary>
        /// 倉庫ヘッダ印刷後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader_AfterPrint(object sender, EventArgs e)
        {
            // 罫線制御
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
        }
        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>
        /// 拠点ヘッダ印刷後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_AfterPrint(object sender, EventArgs e)
        {
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// 得意先ヘッダ（拠点・得意先）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerHeader_BeforePrint(object sender, EventArgs e)
        {
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //if ( this._salesRsltListCndtn.GroupBySectionDiv == SalesRsltListCndtn.GroupBySectionDivState.All )
            //{
            //    CusHd_AddUpSecCode.Visible = false;
            //    CusHd_SectionGuideNm.Text = "全社集計";
            //}
            // --- DEL 2008/10/08 --------------------------------<<<<<
            //// 罫線制御
            //Line_DetailHead.Visible = true;
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 各コード値が0の場合は表示しない
            if (this.CusHd_AddUpSecCode.Text == null
                || this.CusHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.CusHd_AddUpSecCode.Text = "";
                this.CusHd_SectionGuideNm.Text = "";
            }

            if (this.CusHd_WarehouseCode.Text == null
                || this.CusHd_WarehouseCode.Text.PadLeft(4, '0') == "0000")
            {
                this.CusHd_WarehouseCode.Text = "";
                this.CusHd_WarehouseName.Text = "";
            }

            if (Convert.ToInt32(this.CusHd_CustomerCode.Text) == 0)
            {
                this.CusHd_CustomerCode.Text = "";
                this.CusHd_CustomerSnm.Text = "";
            }
            // --- ADD 2008/10/08 --------------------------------<<<<< 

            this._groupFirstRowVisibleFlg = true; // ADD 2009/02/12
        }
        /// <summary>
        /// 得意先ヘッダ（拠点・得意先）印刷後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerHeader_AfterPrint(object sender, EventArgs e)
        {
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        // --- ADD 2009/04/11 -------------------------->>>>>
        /// <summary>
        /// 仕入先ヘッダ（拠点・仕入先）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierHeader_BeforePrint(object sender, EventArgs e)
        {
            // 各コード値が0の場合は表示しない
            if (this.SupHd_AddUpSecCode.Text == null
                || this.SupHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.SupHd_AddUpSecCode.Text = "";
                this.SupHd_SectionGuideNm.Text = "";
            }

            //if (Convert.ToInt32(this.SupHd_SupplierCode.Text) == 0)
            //{
            //    this.SupHd_SupplierCode.Text = "";
            //    this.SupHd_SupplierSnm.Text = "";
            //}

            this._groupFirstRowVisibleFlg = true;
        }
        /// <summary>
        /// 仕入先ヘッダ（拠点・仕入先）印刷後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierHeader_AfterPrint(object sender, EventArgs e)
        {
            // 罫線制御
            //  Line_DetailHead_Visible = true;
        }
        // --- ADD 2009/04/11 --------------------------<<<<<
        /// <summary>
        /// 担当者ヘッダ（拠点・担当者）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeHeader_BeforePrint(object sender, EventArgs e)
        {
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //if ( this._salesRsltListCndtn.GroupBySectionDiv == SalesRsltListCndtn.GroupBySectionDivState.All )
            //{
            //    EmpHd_AddUpSecCode.Visible = false;
            //    EmpHd_SectionGuideNm.Text = "全社集計";
            //}
            // --- DEL 2008/10/08 --------------------------------<<<<<
            //// 罫線制御
            //Line_DetailHead.Visible = true;
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 各コード値が0の場合は表示しない
            if (this.EmpHd_AddUpSecCode.Text == null
                || this.EmpHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.EmpHd_AddUpSecCode.Text = "";
                this.EmpHd_SectionGuideNm.Text = "";
            }

            if (this.EmpHd_EmployeeCode.Text == null
                || this.EmpHd_EmployeeCode.Text.PadLeft(4, '0') == "0000")
            {
                this.EmpHd_EmployeeCode.Text = "";
                this.EmpHd_EmployeeName.Text = "";
            }
            // --- ADD 2008/10/08 --------------------------------<<<<< 

            this._groupFirstRowVisibleFlg = true; // ADD 2009/02/12
        }
        /// <summary>
        /// 担当者ヘッダ（拠点・担当者）印刷後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeHeader_AfterPrint(object sender, EventArgs e)
        {
            // 罫線制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Line_DetailHead.Visible = true;
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// 倉庫ヘッダ　印刷前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader_BeforePrint(object sender, EventArgs e)
        {
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 各コード値が0の場合は表示しない
            if (this.WarHd_AddUpSecCode.Text == null
                || this.WarHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.WarHd_AddUpSecCode.Text = "";
                this.WarHd_SectionGuideNm.Text = "";
            }

            if (this.WarHd_WarehouseCode.Text == null
                || this.WarHd_WarehouseCode.Text.PadLeft(4, '0') == "0000")
            {
                this.WarHd_WarehouseCode.Text = "";
                this.WarHd_WarehouseName.Text = "";
            }
            // --- ADD 2008/10/08 --------------------------------<<<<< 

            this._groupFirstRowVisibleFlg = true; // ADD 2009/02/12
        }
        /// <summary>
        /// 倉庫ヘッダ２　印刷前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader2_BeforePrint(object sender, EventArgs e)
        {
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 各コード値が0の場合は表示しない
            if (this.War2Hd_WarehouseCode.Text == null
                || this.War2Hd_WarehouseCode.Text.PadLeft(4, '0') == "0000")
            {
                this.War2Hd_WarehouseCode.Text = "";
                this.War2Hd_WarehouseName.Text = "";
            }
            // --- ADD 2008/10/08 --------------------------------<<<<<

            this._groupFirstRowVisibleFlg = true; // ADD 2009/02/12
        }
        # endregion ■ ヘッダ　拠点コード名称設定 ■

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>
        /// BLGoodsCodeHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGoodsCodeHeader_BeforePrint(object sender, EventArgs e)
        {
            this._groupFirstRowVisibleFlg = true;
        }

        /// <summary>
        /// BLGroupCodeHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupCodeHeader_BeforePrint(object sender, EventArgs e)
        {
            this._groupFirstRowVisibleFlg = true;
        }

        /// <summary>
        /// GoodsMGroupHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMGroupHeader_BeforePrint(object sender, EventArgs e)
        {
            this._groupFirstRowVisibleFlg = true;
        }

        /// <summary>
        /// GoodsLGroupHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsLGroupHeader_BeforePrint(object sender, EventArgs e)
        {
            this._groupFirstRowVisibleFlg = true;
        }

        /// <summary>
        /// MakerHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerHeader_BeforePrint(object sender, EventArgs e)
        {
            this._groupFirstRowVisibleFlg = true;
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<

        #region Format Event

        // -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
        /// <summary>
        /// BLGoodsCodeFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void BLGoodsCodeFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrBLGoods = new TextBox[] { BlFt_SalesPrice, BlFt_GrossProfit, BlFt_TtlSalesPrice, BlFt_TtlGrossProfit };
            foreach (TextBox i in arrBLGoods)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// BLGroupCodeFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void BLGroupCodeFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrBLGroup = new TextBox[] { DggFt_SalesPrice, DggFt_GrossProfit, DggFt_TtlSalesPrice, DggFt_TtlGrossProfit };
            foreach (TextBox i in arrBLGroup)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// GoodsMGroupFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void GoodsMGroupFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrGoodsMGroup = new TextBox[] { MggFt_SalesPrice, MggFt_GrossProfit, MggFt_TtlSalesPrice, MggFt_TtlGrossProfit };
            foreach (TextBox i in arrGoodsMGroup)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// GoodsLGroupFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void GoodsLGroupFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrGoodsLGroup = new TextBox[] { LggFt_SalesPrice, LggFt_GrossProfit, LggFt_TtlSalesPrice, LggFt_TtlGrossProfit };
            foreach (TextBox i in arrGoodsLGroup)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// MakerFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void MakerFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrMaker = new TextBox[] { MakFt_SalesPrice, MakFt_GrossProfit, MakFt_TtlSalesPrice, MakFt_TtlGrossProfit };
            foreach (TextBox i in arrMaker)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// EmployeeFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void EmployeeFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrEmployee = new TextBox[] { EmpFt_SalesPrice, EmpFt_GrossProfit, EmpFt_TtlSalesPrice, EmpFt_TtlGrossProfit };
            foreach (TextBox i in arrEmployee)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// CustomerFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void CustomerFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrCustomer = new TextBox[] { CusFt_SalesPrice, CusFt_GrossProfit, CusFt_TtlSalesPrice, CusFt_TtlGrossProfit };
            foreach (TextBox i in arrCustomer)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// SupplierFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void SupplierFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrSupplier = new TextBox[] { SupFt_SalesPrice, SupFt_GrossProfit, SupFt_TtlSalesPrice, SupFt_TtlGrossProfit };
            foreach (TextBox i in arrSupplier)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// WarehouseFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void WarehouseFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrWarehouse = new TextBox[] { WarFt_SalesPrice, WarFt_GrossProfit, WarFt_TtlSalesPrice, WarFt_TtlGrossProfit };
            foreach (TextBox i in arrWarehouse)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// SectionFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrSection = new TextBox[] { SecFt_SalesPrice, SecFt_GrossProfit, SecFt_TtlSalesPrice, SecFt_TtlGrossProfit };
            foreach (TextBox i in arrSection)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// WarehouseFooter2_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void WarehouseFooter2_Format(object sender, EventArgs e)
        {
            TextBox[] arrWarehouse2 = new TextBox[] { War2Ft_SalesPrice, War2Ft_GrossProfit, War2Ft_TtlSalesPrice, War2Ft_TtlGrossProfit };
            foreach (TextBox i in arrWarehouse2)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }

        /// <summary>
        /// GrandTotalFooter_Format
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Programmer	: 周洋</br>
        /// <br>Date		: 2014/12/04</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// </remarks>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            TextBox[] arrTotal = new TextBox[] { Ttl_SalesPrice, Ttl_GrossProfit, Ttl_TtlSalesPrice, Ttl_TtlGrossProfit };
            foreach (TextBox i in arrTotal)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.1pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.6pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
                }
            }
        }
        // -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
        #endregion Format Event

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
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Label Lb_GoodsNo;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_MakerName;
        private DataDynamics.ActiveReports.Label Lb_ShipmentCnt;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox GoodsNameKana;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
        private DataDynamics.ActiveReports.TextBox MonthTotalSalesCount;
        private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
        private DataDynamics.ActiveReports.Line Line44;
        private DataDynamics.ActiveReports.TextBox Cus_Title;
        private DataDynamics.ActiveReports.TextBox CusFt_GrossProfit;
        private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.TextBox Sec_Title;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.TextBox SecFt_GrossProfit;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Label Ttl_Title;
        private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.TextBox Ttl_GrossProfit;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Line Line41;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
        public void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02112P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MonthTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.AnnualTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.AnnualSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.AnnualGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.AnnualGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.Line_DetailHead = new DataDynamics.ActiveReports.Line();
            this.CodeNameFull20 = new DataDynamics.ActiveReports.TextBox();
            this.DetailTitleCode = new DataDynamics.ActiveReports.TextBox();
            this.DetailTitleName = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGroupCode = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.Lb_AnnualSalesCount = new DataDynamics.ActiveReports.Label();
            this.Lb_AnnualSalesMoney = new DataDynamics.ActiveReports.Label();
            this.Lb_AnnualGrossProfit = new DataDynamics.ActiveReports.Label();
            this.Lb_AnnualGrossProfitRate = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.LB_Month = new DataDynamics.ActiveReports.Label();
            this.Lb_AnnualTitle = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMGroup = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsLGroup = new DataDynamics.ActiveReports.Label();
            this.Lb_DetailTitleCode = new DataDynamics.ActiveReports.Label();
            this.line34 = new DataDynamics.ActiveReports.Line();
            this.line37 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Ttl_Title = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.Ttl_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_Line1 = new DataDynamics.ActiveReports.Line();
            this.SecHd_line2 = new DataDynamics.ActiveReports.Line();
            this.SecHd_Title = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_WarehouseTitle = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_Line3 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Sec_Title = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.SecFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.SecFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CusHd_line1 = new DataDynamics.ActiveReports.Line();
            this.CusHd_line2 = new DataDynamics.ActiveReports.Line();
            this.CusHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerTitle = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_WarehouseTitle = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_line3 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.Cus_Title = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.CusFt_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCodeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGoodsCodeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line32 = new DataDynamics.ActiveReports.Line();
            this.line33 = new DataDynamics.ActiveReports.Line();
            this.BlFt_BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_BLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line18 = new DataDynamics.ActiveReports.Line();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line28 = new DataDynamics.ActiveReports.Line();
            this.line29 = new DataDynamics.ActiveReports.Line();
            this.MggFt_MediumGoodsGanreCode = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_MediumGoodsGanreName = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCodeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGroupCodeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line30 = new DataDynamics.ActiveReports.Line();
            this.line31 = new DataDynamics.ActiveReports.Line();
            this.DggFt_DetailGoodsGanreCode = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_DetailGoodsGanreName = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line26 = new DataDynamics.ActiveReports.Line();
            this.line27 = new DataDynamics.ActiveReports.Line();
            this.LggFt_LargeGoodsGanreCode = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_LargeGoodsGanreName = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line20 = new DataDynamics.ActiveReports.Line();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line24 = new DataDynamics.ActiveReports.Line();
            this.line25 = new DataDynamics.ActiveReports.Line();
            this.MakFt_GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_MakerName = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.EmpHd_line1 = new DataDynamics.ActiveReports.Line();
            this.EmpHd_line2 = new DataDynamics.ActiveReports.Line();
            this.EmpHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeName = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeTitle = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_line3 = new DataDynamics.ActiveReports.Line();
            this.EmployeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line21 = new DataDynamics.ActiveReports.Line();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line22 = new DataDynamics.ActiveReports.Line();
            this.line23 = new DataDynamics.ActiveReports.Line();
            this.EmpFt_EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_EmployeeName = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarHd_line1 = new DataDynamics.ActiveReports.Line();
            this.WarHd_line2 = new DataDynamics.ActiveReports.Line();
            this.WarHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.WarHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.WarHd_SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.WarHd_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.WarHd_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.WarHd_WarehouseTitle = new DataDynamics.ActiveReports.TextBox();
            this.WarHd_line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WarFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.line48 = new DataDynamics.ActiveReports.Line();
            this.line50 = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.line49 = new DataDynamics.ActiveReports.Line();
            this.WarFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.WarFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.War2Hd_WarehouseTitle = new DataDynamics.ActiveReports.TextBox();
            this.War2Hd_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.War2Hd_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.War2Hd_Line1 = new DataDynamics.ActiveReports.Line();
            this.War2Hd_Line2 = new DataDynamics.ActiveReports.Line();
            this.War2Hd_Line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.War2Ft_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.War2Ft_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.War2Ft_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.War2Ft_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupHd_SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierTitle = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.line35 = new DataDynamics.ActiveReports.Line();
            this.line36 = new DataDynamics.ActiveReports.Line();
            this.line38 = new DataDynamics.ActiveReports.Line();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line39 = new DataDynamics.ActiveReports.Line();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TtlGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TtlSalesPrice = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TtlGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line40 = new DataDynamics.ActiveReports.Line();
            this.line45 = new DataDynamics.ActiveReports.Line();
            this.SupFt_SupplierCode = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_MonthPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualPureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_MonthGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_AnnualGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeNameFull20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailTitleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailTitleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LB_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsLGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DetailTitleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_WarehouseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_WarehouseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MediumGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MediumGoodsGanreName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_DetailGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_DetailGoodsGanreName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_LargeGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_LargeGoodsGanreName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_WarehouseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Hd_WarehouseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Hd_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Hd_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlSalesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_MonthPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_MonthGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.GoodsNameKana,
            this.GoodsMakerCd,
            this.MonthTotalSalesCount,
            this.MonthSalesMoney,
            this.GoodsLGroupCode,
            this.GoodsMGroupCode,
            this.BLGroupCode,
            this.BLGoodsCode,
            this.MonthGrossProfit,
            this.MonthGrossProfitRate,
            this.AnnualTotalSalesCount,
            this.AnnualSalesMoney,
            this.AnnualGrossProfit,
            this.AnnualGrossProfitRate,
            this.line6,
            this.line7,
            this.MakerName,
            this.Line_DetailHead,
            this.CodeNameFull20,
            this.DetailTitleCode,
            this.DetailTitleName});
            this.Detail.Height = 0.5104167F;
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
            this.GoodsNo.Height = 0.156F;
            this.GoodsNo.Left = 3.188F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.01F;
            this.GoodsNo.Width = 1.4F;
            // 
            // GoodsNameKana
            // 
            this.GoodsNameKana.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.DataField = "GoodsNameKana";
            this.GoodsNameKana.Height = 0.156F;
            this.GoodsNameKana.Left = 4.563F;
            this.GoodsNameKana.MultiLine = false;
            this.GoodsNameKana.Name = "GoodsNameKana";
            this.GoodsNameKana.OutputFormat = resources.GetString("GoodsNameKana.OutputFormat");
            this.GoodsNameKana.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNameKana.Text = "12345678901234567890";
            this.GoodsNameKana.Top = 0.01F;
            this.GoodsNameKana.Width = 1.15F;
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
            this.GoodsMakerCd.Height = 0.156F;
            this.GoodsMakerCd.Left = 0F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.01F;
            this.GoodsMakerCd.Width = 0.4F;
            // 
            // MonthTotalSalesCount
            // 
            this.MonthTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.MonthTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.MonthTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalSalesCount.DataField = "MonthTotalSalesCount";
            this.MonthTotalSalesCount.Height = 0.156F;
            this.MonthTotalSalesCount.Left = 5.75F;
            this.MonthTotalSalesCount.MultiLine = false;
            this.MonthTotalSalesCount.Name = "MonthTotalSalesCount";
            this.MonthTotalSalesCount.OutputFormat = resources.GetString("MonthTotalSalesCount.OutputFormat");
            this.MonthTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthTotalSalesCount.Text = "123,456,789";
            this.MonthTotalSalesCount.Top = 0.01F;
            this.MonthTotalSalesCount.Width = 0.7F;
            // 
            // MonthSalesMoney
            // 
            this.MonthSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.DataField = "MonthPureSalesMoney";
            this.MonthSalesMoney.Height = 0.156F;
            this.MonthSalesMoney.Left = 6.438F;
            this.MonthSalesMoney.MultiLine = false;
            this.MonthSalesMoney.Name = "MonthSalesMoney";
            this.MonthSalesMoney.OutputFormat = resources.GetString("MonthSalesMoney.OutputFormat");
            this.MonthSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoney.Text = "123,456,789";
            this.MonthSalesMoney.Top = 0.01F;
            this.MonthSalesMoney.Width = 0.7F;
            // 
            // GoodsLGroupCode
            // 
            this.GoodsLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.DataField = "GoodsLGroup";
            this.GoodsLGroupCode.Height = 0.15625F;
            this.GoodsLGroupCode.Left = 1.625F;
            this.GoodsLGroupCode.MultiLine = false;
            this.GoodsLGroupCode.Name = "GoodsLGroupCode";
            this.GoodsLGroupCode.OutputFormat = resources.GetString("GoodsLGroupCode.OutputFormat");
            this.GoodsLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsLGroupCode.Text = "1234";
            this.GoodsLGroupCode.Top = 0.01F;
            this.GoodsLGroupCode.Width = 0.3125F;
            // 
            // GoodsMGroupCode
            // 
            this.GoodsMGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.DataField = "GoodsMGroup";
            this.GoodsMGroupCode.Height = 0.15625F;
            this.GoodsMGroupCode.Left = 2F;
            this.GoodsMGroupCode.MultiLine = false;
            this.GoodsMGroupCode.Name = "GoodsMGroupCode";
            this.GoodsMGroupCode.OutputFormat = resources.GetString("GoodsMGroupCode.OutputFormat");
            this.GoodsMGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMGroupCode.Text = "1234";
            this.GoodsMGroupCode.Top = 0.01F;
            this.GoodsMGroupCode.Width = 0.3125F;
            // 
            // BLGroupCode
            // 
            this.BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.DataField = "BLGroupCode";
            this.BLGroupCode.Height = 0.156F;
            this.BLGroupCode.Left = 2.375F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0.01F;
            this.BLGroupCode.Width = 0.35F;
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
            this.BLGoodsCode.Height = 0.156F;
            this.BLGoodsCode.Left = 2.75F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0.01F;
            this.BLGoodsCode.Width = 0.35F;
            // 
            // MonthGrossProfit
            // 
            this.MonthGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.DataField = "MonthGrossProfit";
            this.MonthGrossProfit.Height = 0.156F;
            this.MonthGrossProfit.Left = 7.125F;
            this.MonthGrossProfit.MultiLine = false;
            this.MonthGrossProfit.Name = "MonthGrossProfit";
            this.MonthGrossProfit.OutputFormat = resources.GetString("MonthGrossProfit.OutputFormat");
            this.MonthGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfit.Text = "123,456,789";
            this.MonthGrossProfit.Top = 0.01F;
            this.MonthGrossProfit.Width = 0.7F;
            // 
            // MonthGrossProfitRate
            // 
            this.MonthGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.DataField = "MonthGrossProfitRate";
            this.MonthGrossProfitRate.Height = 0.156F;
            this.MonthGrossProfitRate.Left = 7.813F;
            this.MonthGrossProfitRate.MultiLine = false;
            this.MonthGrossProfitRate.Name = "MonthGrossProfitRate";
            this.MonthGrossProfitRate.OutputFormat = resources.GetString("MonthGrossProfitRate.OutputFormat");
            this.MonthGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitRate.Text = "123.00";
            this.MonthGrossProfitRate.Top = 0.01F;
            this.MonthGrossProfitRate.Width = 0.42F;
            // 
            // AnnualTotalSalesCount
            // 
            this.AnnualTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.AnnualTotalSalesCount.Height = 0.156F;
            this.AnnualTotalSalesCount.Left = 8.25F;
            this.AnnualTotalSalesCount.MultiLine = false;
            this.AnnualTotalSalesCount.Name = "AnnualTotalSalesCount";
            this.AnnualTotalSalesCount.OutputFormat = resources.GetString("AnnualTotalSalesCount.OutputFormat");
            this.AnnualTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualTotalSalesCount.Text = "123,456,789";
            this.AnnualTotalSalesCount.Top = 0.01F;
            this.AnnualTotalSalesCount.Width = 0.7F;
            // 
            // AnnualSalesMoney
            // 
            this.AnnualSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualSalesMoney.DataField = "AnnualPureSalesMoney";
            this.AnnualSalesMoney.Height = 0.156F;
            this.AnnualSalesMoney.Left = 8.938F;
            this.AnnualSalesMoney.MultiLine = false;
            this.AnnualSalesMoney.Name = "AnnualSalesMoney";
            this.AnnualSalesMoney.OutputFormat = resources.GetString("AnnualSalesMoney.OutputFormat");
            this.AnnualSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualSalesMoney.Text = "123,456,789";
            this.AnnualSalesMoney.Top = 0.01F;
            this.AnnualSalesMoney.Width = 0.7F;
            // 
            // AnnualGrossProfit
            // 
            this.AnnualGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfit.DataField = "AnnualGrossProfit";
            this.AnnualGrossProfit.Height = 0.156F;
            this.AnnualGrossProfit.Left = 9.625F;
            this.AnnualGrossProfit.MultiLine = false;
            this.AnnualGrossProfit.Name = "AnnualGrossProfit";
            this.AnnualGrossProfit.OutputFormat = resources.GetString("AnnualGrossProfit.OutputFormat");
            this.AnnualGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualGrossProfit.Text = "123,456,789";
            this.AnnualGrossProfit.Top = 0.01F;
            this.AnnualGrossProfit.Width = 0.7F;
            // 
            // AnnualGrossProfitRate
            // 
            this.AnnualGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.AnnualGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.AnnualGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.AnnualGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.AnnualGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnnualGrossProfitRate.DataField = "AnnualGrossProfitRate";
            this.AnnualGrossProfitRate.Height = 0.156F;
            this.AnnualGrossProfitRate.Left = 10.313F;
            this.AnnualGrossProfitRate.MultiLine = false;
            this.AnnualGrossProfitRate.Name = "AnnualGrossProfitRate";
            this.AnnualGrossProfitRate.OutputFormat = resources.GetString("AnnualGrossProfitRate.OutputFormat");
            this.AnnualGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnnualGrossProfitRate.Text = "123.00";
            this.AnnualGrossProfitRate.Top = 0.01F;
            this.AnnualGrossProfitRate.Width = 0.42F;
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
            this.line6.Height = 0.11F;
            this.line6.Left = 5.75F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.03F;
            this.line6.Width = 0F;
            this.line6.X1 = 5.75F;
            this.line6.X2 = 5.75F;
            this.line6.Y1 = 0.03F;
            this.line6.Y2 = 0.14F;
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
            this.line7.Height = 0.11F;
            this.line7.Left = 8.25F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0.03F;
            this.line7.Width = 0F;
            this.line7.X1 = 8.25F;
            this.line7.X2 = 8.25F;
            this.line7.Y1 = 0.03F;
            this.line7.Y2 = 0.14F;
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
            this.MakerName.Height = 0.15625F;
            this.MakerName.Left = 0.438F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこ";
            this.MakerName.Top = 0.01F;
            this.MakerName.Width = 1.1875F;
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
            this.Line_DetailHead.LineWeight = 2F;
            this.Line_DetailHead.Name = "Line_DetailHead";
            this.Line_DetailHead.Top = 0F;
            this.Line_DetailHead.Width = 10.8F;
            this.Line_DetailHead.X1 = 0F;
            this.Line_DetailHead.X2 = 10.8F;
            this.Line_DetailHead.Y1 = 0F;
            this.Line_DetailHead.Y2 = 0F;
            // 
            // CodeNameFull20
            // 
            this.CodeNameFull20.Border.BottomColor = System.Drawing.Color.Black;
            this.CodeNameFull20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameFull20.Border.LeftColor = System.Drawing.Color.Black;
            this.CodeNameFull20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameFull20.Border.RightColor = System.Drawing.Color.Black;
            this.CodeNameFull20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameFull20.Border.TopColor = System.Drawing.Color.Black;
            this.CodeNameFull20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameFull20.Height = 0.156F;
            this.CodeNameFull20.Left = 3.1875F;
            this.CodeNameFull20.MultiLine = false;
            this.CodeNameFull20.Name = "CodeNameFull20";
            this.CodeNameFull20.OutputFormat = resources.GetString("CodeNameFull20.OutputFormat");
            this.CodeNameFull20.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CodeNameFull20.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CodeNameFull20.Top = 0.1875F;
            this.CodeNameFull20.Width = 2.3F;
            // 
            // DetailTitleCode
            // 
            this.DetailTitleCode.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailTitleCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleCode.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailTitleCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleCode.Border.RightColor = System.Drawing.Color.Black;
            this.DetailTitleCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleCode.Border.TopColor = System.Drawing.Color.Black;
            this.DetailTitleCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleCode.Height = 0.156F;
            this.DetailTitleCode.Left = 0F;
            this.DetailTitleCode.MultiLine = false;
            this.DetailTitleCode.Name = "DetailTitleCode";
            this.DetailTitleCode.OutputFormat = resources.GetString("DetailTitleCode.OutputFormat");
            this.DetailTitleCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DetailTitleCode.Text = "12345678";
            this.DetailTitleCode.Top = 0.1875F;
            this.DetailTitleCode.Visible = false;
            this.DetailTitleCode.Width = 0.6F;
            // 
            // DetailTitleName
            // 
            this.DetailTitleName.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailTitleName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleName.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailTitleName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleName.Border.RightColor = System.Drawing.Color.Black;
            this.DetailTitleName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleName.Border.TopColor = System.Drawing.Color.Black;
            this.DetailTitleName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailTitleName.Height = 0.156F;
            this.DetailTitleName.Left = 0.625F;
            this.DetailTitleName.MultiLine = false;
            this.DetailTitleName.Name = "DetailTitleName";
            this.DetailTitleName.OutputFormat = resources.GetString("DetailTitleName.OutputFormat");
            this.DetailTitleName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.DetailTitleName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.DetailTitleName.Top = 0.1875F;
            this.DetailTitleName.Visible = false;
            this.DetailTitleName.Width = 2.4F;
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
            this.SortTitle});
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
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "売上実績表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.40625F;
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
            this.SortTitle.Height = 0.125F;
            this.SortTitle.Left = 4.75F;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "font-size: 8pt; vertical-align: top; ";
            this.SortTitle.Text = "[拠点 コード順/カナ順]";
            this.SortTitle.Top = 0.063F;
            this.SortTitle.Width = 3.15F;
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
            this.Line42,
            this.Lb_GoodsName,
            this.Lb_MakerName,
            this.Lb_ShipmentCnt,
            this.Lb_GoodsNo,
            this.Lb_BLGroupCode,
            this.label4,
            this.label5,
            this.label6,
            this.Lb_AnnualSalesCount,
            this.Lb_AnnualSalesMoney,
            this.Lb_AnnualGrossProfit,
            this.Lb_AnnualGrossProfitRate,
            this.line4,
            this.line5,
            this.LB_Month,
            this.Lb_AnnualTitle,
            this.Lb_BLGoodsCode,
            this.Lb_GoodsMGroup,
            this.Lb_GoodsLGroup,
            this.Lb_DetailTitleCode,
            this.line34,
            this.line37});
            this.TitleHeader.Height = 0.5305F;
            this.TitleHeader.KeepTogether = true;
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
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
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
            this.Lb_GoodsName.Height = 0.15625F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 4.563F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.156F;
            this.Lb_GoodsName.Width = 0.75F;
            // 
            // Lb_MakerName
            // 
            this.Lb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Height = 0.156F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 0F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MakerName.Text = "ﾒｰｶｰ";
            this.Lb_MakerName.Top = 0.156F;
            this.Lb_MakerName.Width = 0.4F;
            // 
            // Lb_ShipmentCnt
            // 
            this.Lb_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Height = 0.156F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 5.75F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCnt.Text = "出荷数";
            this.Lb_ShipmentCnt.Top = 0.15625F;
            this.Lb_ShipmentCnt.Width = 0.7F;
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
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 3.188F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.156F;
            this.Lb_GoodsNo.Width = 0.75F;
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
            this.Lb_BLGroupCode.Height = 0.156F;
            this.Lb_BLGroupCode.HyperLink = "";
            this.Lb_BLGroupCode.Left = 2.375F;
            this.Lb_BLGroupCode.MultiLine = false;
            this.Lb_BLGroupCode.Name = "Lb_BLGroupCode";
            this.Lb_BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGroupCode.Text = "ｸﾞﾙｰﾌﾟ";
            this.Lb_BLGroupCode.Top = 0.156F;
            this.Lb_BLGroupCode.Width = 0.4F;
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
            this.label4.Left = 6.438F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "売上";
            this.label4.Top = 0.156F;
            this.label4.Width = 0.7F;
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
            this.label5.Left = 7.125F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "粗利";
            this.label5.Top = 0.156F;
            this.label5.Width = 0.7F;
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
            this.label6.Left = 7.813F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "粗利率";
            this.label6.Top = 0.156F;
            this.label6.Width = 0.42F;
            // 
            // Lb_AnnualSalesCount
            // 
            this.Lb_AnnualSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesCount.Height = 0.156F;
            this.Lb_AnnualSalesCount.HyperLink = "";
            this.Lb_AnnualSalesCount.Left = 8.25F;
            this.Lb_AnnualSalesCount.MultiLine = false;
            this.Lb_AnnualSalesCount.Name = "Lb_AnnualSalesCount";
            this.Lb_AnnualSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnnualSalesCount.Text = "出荷数";
            this.Lb_AnnualSalesCount.Top = 0.15625F;
            this.Lb_AnnualSalesCount.Width = 0.7F;
            // 
            // Lb_AnnualSalesMoney
            // 
            this.Lb_AnnualSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnnualSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualSalesMoney.Height = 0.156F;
            this.Lb_AnnualSalesMoney.HyperLink = "";
            this.Lb_AnnualSalesMoney.Left = 8.938F;
            this.Lb_AnnualSalesMoney.MultiLine = false;
            this.Lb_AnnualSalesMoney.Name = "Lb_AnnualSalesMoney";
            this.Lb_AnnualSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnnualSalesMoney.Text = "売上";
            this.Lb_AnnualSalesMoney.Top = 0.156F;
            this.Lb_AnnualSalesMoney.Width = 0.7F;
            // 
            // Lb_AnnualGrossProfit
            // 
            this.Lb_AnnualGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfit.Height = 0.156F;
            this.Lb_AnnualGrossProfit.HyperLink = "";
            this.Lb_AnnualGrossProfit.Left = 9.625F;
            this.Lb_AnnualGrossProfit.MultiLine = false;
            this.Lb_AnnualGrossProfit.Name = "Lb_AnnualGrossProfit";
            this.Lb_AnnualGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnnualGrossProfit.Text = "粗利";
            this.Lb_AnnualGrossProfit.Top = 0.156F;
            this.Lb_AnnualGrossProfit.Width = 0.7F;
            // 
            // Lb_AnnualGrossProfitRate
            // 
            this.Lb_AnnualGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnnualGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualGrossProfitRate.Height = 0.156F;
            this.Lb_AnnualGrossProfitRate.HyperLink = "";
            this.Lb_AnnualGrossProfitRate.Left = 10.313F;
            this.Lb_AnnualGrossProfitRate.MultiLine = false;
            this.Lb_AnnualGrossProfitRate.Name = "Lb_AnnualGrossProfitRate";
            this.Lb_AnnualGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnnualGrossProfitRate.Text = "粗利率";
            this.Lb_AnnualGrossProfitRate.Top = 0.156F;
            this.Lb_AnnualGrossProfitRate.Width = 0.42F;
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
            this.line4.Height = 0.09999999F;
            this.line4.Left = 5.75F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.18F;
            this.line4.Width = 0F;
            this.line4.X1 = 5.75F;
            this.line4.X2 = 5.75F;
            this.line4.Y1 = 0.18F;
            this.line4.Y2 = 0.28F;
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
            this.line5.Height = 0.09999999F;
            this.line5.Left = 8.25F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.03F;
            this.line5.Width = 0F;
            this.line5.X1 = 8.25F;
            this.line5.X2 = 8.25F;
            this.line5.Y1 = 0.03F;
            this.line5.Y2 = 0.13F;
            // 
            // LB_Month
            // 
            this.LB_Month.Border.BottomColor = System.Drawing.Color.Black;
            this.LB_Month.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LB_Month.Border.LeftColor = System.Drawing.Color.Black;
            this.LB_Month.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LB_Month.Border.RightColor = System.Drawing.Color.Black;
            this.LB_Month.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LB_Month.Border.TopColor = System.Drawing.Color.Black;
            this.LB_Month.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LB_Month.Height = 0.1875F;
            this.LB_Month.HyperLink = "";
            this.LB_Month.Left = 5.75F;
            this.LB_Month.MultiLine = false;
            this.LB_Month.Name = "LB_Month";
            this.LB_Month.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.LB_Month.Text = "<============　　当　　月　　============>";
            this.LB_Month.Top = 0.031F;
            this.LB_Month.Width = 2.5F;
            // 
            // Lb_AnnualTitle
            // 
            this.Lb_AnnualTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnnualTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnnualTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnnualTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnnualTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnnualTitle.Height = 0.1875F;
            this.Lb_AnnualTitle.HyperLink = "";
            this.Lb_AnnualTitle.Left = 8.25F;
            this.Lb_AnnualTitle.MultiLine = false;
            this.Lb_AnnualTitle.Name = "Lb_AnnualTitle";
            this.Lb_AnnualTitle.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnnualTitle.Text = "<============　　当　　期　　============>";
            this.Lb_AnnualTitle.Top = 0.031F;
            this.Lb_AnnualTitle.Width = 2.5F;
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
            this.Lb_BLGoodsCode.Height = 0.15625F;
            this.Lb_BLGoodsCode.HyperLink = "";
            this.Lb_BLGoodsCode.Left = 2.75F;
            this.Lb_BLGoodsCode.MultiLine = false;
            this.Lb_BLGoodsCode.Name = "Lb_BLGoodsCode";
            this.Lb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode.Text = "BLｺｰﾄﾞ";
            this.Lb_BLGoodsCode.Top = 0.156F;
            this.Lb_BLGoodsCode.Width = 0.46875F;
            // 
            // Lb_GoodsMGroup
            // 
            this.Lb_GoodsMGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMGroup.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMGroup.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMGroup.Height = 0.156F;
            this.Lb_GoodsMGroup.HyperLink = "";
            this.Lb_GoodsMGroup.Left = 2F;
            this.Lb_GoodsMGroup.MultiLine = false;
            this.Lb_GoodsMGroup.Name = "Lb_GoodsMGroup";
            this.Lb_GoodsMGroup.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMGroup.Text = "中分類";
            this.Lb_GoodsMGroup.Top = 0.156F;
            this.Lb_GoodsMGroup.Width = 0.4F;
            // 
            // Lb_GoodsLGroup
            // 
            this.Lb_GoodsLGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsLGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsLGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsLGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsLGroup.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsLGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsLGroup.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsLGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsLGroup.Height = 0.156F;
            this.Lb_GoodsLGroup.HyperLink = "";
            this.Lb_GoodsLGroup.Left = 1.625F;
            this.Lb_GoodsLGroup.MultiLine = false;
            this.Lb_GoodsLGroup.Name = "Lb_GoodsLGroup";
            this.Lb_GoodsLGroup.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsLGroup.Text = "大分類";
            this.Lb_GoodsLGroup.Top = 0.156F;
            this.Lb_GoodsLGroup.Width = 0.4F;
            // 
            // Lb_DetailTitleCode
            // 
            this.Lb_DetailTitleCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DetailTitleCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailTitleCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DetailTitleCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailTitleCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DetailTitleCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailTitleCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DetailTitleCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailTitleCode.Height = 0.156F;
            this.Lb_DetailTitleCode.HyperLink = "";
            this.Lb_DetailTitleCode.Left = 0F;
            this.Lb_DetailTitleCode.MultiLine = false;
            this.Lb_DetailTitleCode.Name = "Lb_DetailTitleCode";
            this.Lb_DetailTitleCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DetailTitleCode.Text = "得意先";
            this.Lb_DetailTitleCode.Top = 0.3125F;
            this.Lb_DetailTitleCode.Visible = false;
            this.Lb_DetailTitleCode.Width = 0.6F;
            // 
            // line34
            // 
            this.line34.Border.BottomColor = System.Drawing.Color.Black;
            this.line34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.LeftColor = System.Drawing.Color.Black;
            this.line34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.RightColor = System.Drawing.Color.Black;
            this.line34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.TopColor = System.Drawing.Color.Black;
            this.line34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Height = 0.095F;
            this.line34.Left = 5.75F;
            this.line34.LineWeight = 1F;
            this.line34.Name = "line34";
            this.line34.Top = 0.03F;
            this.line34.Width = 0F;
            this.line34.X1 = 5.75F;
            this.line34.X2 = 5.75F;
            this.line34.Y1 = 0.03F;
            this.line34.Y2 = 0.125F;
            // 
            // line37
            // 
            this.line37.Border.BottomColor = System.Drawing.Color.Black;
            this.line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.LeftColor = System.Drawing.Color.Black;
            this.line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.RightColor = System.Drawing.Color.Black;
            this.line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.TopColor = System.Drawing.Color.Black;
            this.line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Height = 0.09999999F;
            this.line37.Left = 8.25F;
            this.line37.LineWeight = 1F;
            this.line37.Name = "line37";
            this.line37.Top = 0.18F;
            this.line37.Width = 0F;
            this.line37.X1 = 8.25F;
            this.line37.X2 = 8.25F;
            this.line37.Y1 = 0.18F;
            this.line37.Y2 = 0.28F;
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
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Ttl_Title,
            this.Line43,
            this.Ttl_GrossProfit,
            this.Ttl_SalesPrice,
            this.Ttl_TotalSalesCount,
            this.Ttl_GrossProfitRate,
            this.Ttl_TtlGrossProfit,
            this.Ttl_TtlSalesPrice,
            this.Ttl_TtlTotalSalesCount,
            this.Ttl_TtlGrossProfitRate,
            this.line12,
            this.line15,
            this.Ttl_MonthPureSalesMoney,
            this.Ttl_AnnualPureSalesMoney,
            this.Ttl_MonthGrossProfitOrg,
            this.Ttl_AnnualGrossProfitOrg});
            this.GrandTotalFooter.Height = 0.625F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // Ttl_Title
            // 
            this.Ttl_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Title.Height = 0.219F;
            this.Ttl_Title.HyperLink = "";
            this.Ttl_Title.Left = 1.313F;
            this.Ttl_Title.MultiLine = false;
            this.Ttl_Title.Name = "Ttl_Title";
            this.Ttl_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Ttl_Title.Text = "総合計";
            this.Ttl_Title.Top = 0.04F;
            this.Ttl_Title.Width = 0.5625F;
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
            // Ttl_GrossProfit
            // 
            this.Ttl_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.DataField = "MonthGrossProfit";
            this.Ttl_GrossProfit.Height = 0.156F;
            this.Ttl_GrossProfit.Left = 7.125F;
            this.Ttl_GrossProfit.MultiLine = false;
            this.Ttl_GrossProfit.Name = "Ttl_GrossProfit";
            this.Ttl_GrossProfit.OutputFormat = resources.GetString("Ttl_GrossProfit.OutputFormat");
            this.Ttl_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_GrossProfit.Text = "123,456,789";
            this.Ttl_GrossProfit.Top = 0.063F;
            this.Ttl_GrossProfit.Width = 0.7F;
            // 
            // Ttl_SalesPrice
            // 
            this.Ttl_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesPrice.DataField = "MonthPureSalesMoney";
            this.Ttl_SalesPrice.Height = 0.156F;
            this.Ttl_SalesPrice.Left = 6.438F;
            this.Ttl_SalesPrice.MultiLine = false;
            this.Ttl_SalesPrice.Name = "Ttl_SalesPrice";
            this.Ttl_SalesPrice.OutputFormat = resources.GetString("Ttl_SalesPrice.OutputFormat");
            this.Ttl_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesPrice.Text = "123,456,789";
            this.Ttl_SalesPrice.Top = 0.063F;
            this.Ttl_SalesPrice.Width = 0.7F;
            // 
            // Ttl_TotalSalesCount
            // 
            this.Ttl_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.Ttl_TotalSalesCount.Height = 0.156F;
            this.Ttl_TotalSalesCount.Left = 5.75F;
            this.Ttl_TotalSalesCount.MultiLine = false;
            this.Ttl_TotalSalesCount.Name = "Ttl_TotalSalesCount";
            this.Ttl_TotalSalesCount.OutputFormat = resources.GetString("Ttl_TotalSalesCount.OutputFormat");
            this.Ttl_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount.Text = "123,456,789";
            this.Ttl_TotalSalesCount.Top = 0.063F;
            this.Ttl_TotalSalesCount.Width = 0.7F;
            // 
            // Ttl_GrossProfitRate
            // 
            this.Ttl_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Height = 0.156F;
            this.Ttl_GrossProfitRate.Left = 7.813F;
            this.Ttl_GrossProfitRate.MultiLine = false;
            this.Ttl_GrossProfitRate.Name = "Ttl_GrossProfitRate";
            this.Ttl_GrossProfitRate.OutputFormat = resources.GetString("Ttl_GrossProfitRate.OutputFormat");
            this.Ttl_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossProfitRate.Text = "123.00";
            this.Ttl_GrossProfitRate.Top = 0.063F;
            this.Ttl_GrossProfitRate.Width = 0.42F;
            // 
            // Ttl_TtlGrossProfit
            // 
            this.Ttl_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.Ttl_TtlGrossProfit.Height = 0.156F;
            this.Ttl_TtlGrossProfit.Left = 9.625F;
            this.Ttl_TtlGrossProfit.MultiLine = false;
            this.Ttl_TtlGrossProfit.Name = "Ttl_TtlGrossProfit";
            this.Ttl_TtlGrossProfit.OutputFormat = resources.GetString("Ttl_TtlGrossProfit.OutputFormat");
            this.Ttl_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TtlGrossProfit.Text = "123,456,789";
            this.Ttl_TtlGrossProfit.Top = 0.063F;
            this.Ttl_TtlGrossProfit.Width = 0.7F;
            // 
            // Ttl_TtlSalesPrice
            // 
            this.Ttl_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.Ttl_TtlSalesPrice.Height = 0.156F;
            this.Ttl_TtlSalesPrice.Left = 8.938F;
            this.Ttl_TtlSalesPrice.MultiLine = false;
            this.Ttl_TtlSalesPrice.Name = "Ttl_TtlSalesPrice";
            this.Ttl_TtlSalesPrice.OutputFormat = resources.GetString("Ttl_TtlSalesPrice.OutputFormat");
            this.Ttl_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TtlSalesPrice.Text = "123,456,789";
            this.Ttl_TtlSalesPrice.Top = 0.063F;
            this.Ttl_TtlSalesPrice.Width = 0.7F;
            // 
            // Ttl_TtlTotalSalesCount
            // 
            this.Ttl_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.Ttl_TtlTotalSalesCount.Height = 0.156F;
            this.Ttl_TtlTotalSalesCount.Left = 8.25F;
            this.Ttl_TtlTotalSalesCount.MultiLine = false;
            this.Ttl_TtlTotalSalesCount.Name = "Ttl_TtlTotalSalesCount";
            this.Ttl_TtlTotalSalesCount.OutputFormat = resources.GetString("Ttl_TtlTotalSalesCount.OutputFormat");
            this.Ttl_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TtlTotalSalesCount.Text = "123,456,789";
            this.Ttl_TtlTotalSalesCount.Top = 0.063F;
            this.Ttl_TtlTotalSalesCount.Width = 0.7F;
            // 
            // Ttl_TtlGrossProfitRate
            // 
            this.Ttl_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlGrossProfitRate.Height = 0.156F;
            this.Ttl_TtlGrossProfitRate.Left = 10.313F;
            this.Ttl_TtlGrossProfitRate.MultiLine = false;
            this.Ttl_TtlGrossProfitRate.Name = "Ttl_TtlGrossProfitRate";
            this.Ttl_TtlGrossProfitRate.OutputFormat = resources.GetString("Ttl_TtlGrossProfitRate.OutputFormat");
            this.Ttl_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TtlGrossProfitRate.Text = "123.00";
            this.Ttl_TtlGrossProfitRate.Top = 0.063F;
            this.Ttl_TtlGrossProfitRate.Width = 0.42F;
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
            this.line12.Height = 0.125F;
            this.line12.Left = 5.75F;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.Top = 0.0625F;
            this.line12.Width = 0F;
            this.line12.X1 = 5.75F;
            this.line12.X2 = 5.75F;
            this.line12.Y1 = 0.0625F;
            this.line12.Y2 = 0.1875F;
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
            this.line15.Height = 0.13F;
            this.line15.Left = 8.25F;
            this.line15.LineWeight = 1F;
            this.line15.Name = "line15";
            this.line15.Top = 0.06F;
            this.line15.Width = 0F;
            this.line15.X1 = 8.25F;
            this.line15.X2 = 8.25F;
            this.line15.Y1 = 0.06F;
            this.line15.Y2 = 0.19F;
            // 
            // Ttl_MonthPureSalesMoney
            // 
            this.Ttl_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.Ttl_MonthPureSalesMoney.Height = 0.15625F;
            this.Ttl_MonthPureSalesMoney.Left = 6.125F;
            this.Ttl_MonthPureSalesMoney.MultiLine = false;
            this.Ttl_MonthPureSalesMoney.Name = "Ttl_MonthPureSalesMoney";
            this.Ttl_MonthPureSalesMoney.OutputFormat = resources.GetString("Ttl_MonthPureSalesMoney.OutputFormat");
            this.Ttl_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_MonthPureSalesMoney.SummaryGroup = "GrandTotalHeader";
            this.Ttl_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_MonthPureSalesMoney.Text = "1234,567,890";
            this.Ttl_MonthPureSalesMoney.Top = 0.25F;
            this.Ttl_MonthPureSalesMoney.Visible = false;
            this.Ttl_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // Ttl_AnnualPureSalesMoney
            // 
            this.Ttl_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.Ttl_AnnualPureSalesMoney.Height = 0.15625F;
            this.Ttl_AnnualPureSalesMoney.Left = 8.625F;
            this.Ttl_AnnualPureSalesMoney.MultiLine = false;
            this.Ttl_AnnualPureSalesMoney.Name = "Ttl_AnnualPureSalesMoney";
            this.Ttl_AnnualPureSalesMoney.OutputFormat = resources.GetString("Ttl_AnnualPureSalesMoney.OutputFormat");
            this.Ttl_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_AnnualPureSalesMoney.SummaryGroup = "GrandTotalHeader";
            this.Ttl_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_AnnualPureSalesMoney.Text = "1234,567,890";
            this.Ttl_AnnualPureSalesMoney.Top = 0.25F;
            this.Ttl_AnnualPureSalesMoney.Visible = false;
            this.Ttl_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // Ttl_MonthGrossProfitOrg
            // 
            this.Ttl_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.Ttl_MonthGrossProfitOrg.Height = 0.15625F;
            this.Ttl_MonthGrossProfitOrg.Left = 6.875F;
            this.Ttl_MonthGrossProfitOrg.MultiLine = false;
            this.Ttl_MonthGrossProfitOrg.Name = "Ttl_MonthGrossProfitOrg";
            this.Ttl_MonthGrossProfitOrg.OutputFormat = resources.GetString("Ttl_MonthGrossProfitOrg.OutputFormat");
            this.Ttl_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_MonthGrossProfitOrg.SummaryGroup = "GrandTotalHeader";
            this.Ttl_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_MonthGrossProfitOrg.Text = "1234,567,890";
            this.Ttl_MonthGrossProfitOrg.Top = 0.25F;
            this.Ttl_MonthGrossProfitOrg.Visible = false;
            this.Ttl_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // Ttl_AnnualGrossProfitOrg
            // 
            this.Ttl_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.Ttl_AnnualGrossProfitOrg.Height = 0.15625F;
            this.Ttl_AnnualGrossProfitOrg.Left = 9.375F;
            this.Ttl_AnnualGrossProfitOrg.MultiLine = false;
            this.Ttl_AnnualGrossProfitOrg.Name = "Ttl_AnnualGrossProfitOrg";
            this.Ttl_AnnualGrossProfitOrg.OutputFormat = resources.GetString("Ttl_AnnualGrossProfitOrg.OutputFormat");
            this.Ttl_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_AnnualGrossProfitOrg.SummaryGroup = "GrandTotalHeader";
            this.Ttl_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.Ttl_AnnualGrossProfitOrg.Top = 0.25F;
            this.Ttl_AnnualGrossProfitOrg.Visible = false;
            this.Ttl_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_AddUpSecCode,
            this.SecHd_SectionGuideNm,
            this.SecHd_Line1,
            this.SecHd_line2,
            this.SecHd_Title,
            this.SecHd_WarehouseCode,
            this.SecHd_WarehouseName,
            this.SecHd_WarehouseTitle,
            this.SecHd_Line3});
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.2395833F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.AfterPrint += new System.EventHandler(this.SectionHeader_AfterPrint);
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
            // 
            // SecHd_AddUpSecCode
            // 
            this.SecHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.SecHd_AddUpSecCode.Height = 0.156F;
            this.SecHd_AddUpSecCode.Left = 0.563F;
            this.SecHd_AddUpSecCode.MultiLine = false;
            this.SecHd_AddUpSecCode.Name = "SecHd_AddUpSecCode";
            this.SecHd_AddUpSecCode.OutputFormat = resources.GetString("SecHd_AddUpSecCode.OutputFormat");
            this.SecHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SecHd_AddUpSecCode.Text = "12";
            this.SecHd_AddUpSecCode.Top = 0.031F;
            this.SecHd_AddUpSecCode.Width = 0.15F;
            // 
            // SecHd_SectionGuideNm
            // 
            this.SecHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.DataField = "CompanyName1";
            this.SecHd_SectionGuideNm.Height = 0.15625F;
            this.SecHd_SectionGuideNm.Left = 0.72F;
            this.SecHd_SectionGuideNm.MultiLine = false;
            this.SecHd_SectionGuideNm.Name = "SecHd_SectionGuideNm";
            this.SecHd_SectionGuideNm.OutputFormat = resources.GetString("SecHd_SectionGuideNm.OutputFormat");
            this.SecHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SecHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SecHd_SectionGuideNm.Top = 0.031F;
            this.SecHd_SectionGuideNm.Width = 1.1875F;
            // 
            // SecHd_Line1
            // 
            this.SecHd_Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line1.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line1.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line1.Height = 0.095F;
            this.SecHd_Line1.Left = 5.75F;
            this.SecHd_Line1.LineWeight = 1F;
            this.SecHd_Line1.Name = "SecHd_Line1";
            this.SecHd_Line1.Top = 0.03F;
            this.SecHd_Line1.Width = 0F;
            this.SecHd_Line1.X1 = 5.75F;
            this.SecHd_Line1.X2 = 5.75F;
            this.SecHd_Line1.Y1 = 0.03F;
            this.SecHd_Line1.Y2 = 0.125F;
            // 
            // SecHd_line2
            // 
            this.SecHd_line2.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line2.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line2.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line2.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line2.Height = 0.09999999F;
            this.SecHd_line2.Left = 8.25F;
            this.SecHd_line2.LineWeight = 1F;
            this.SecHd_line2.Name = "SecHd_line2";
            this.SecHd_line2.Top = 0.03F;
            this.SecHd_line2.Width = 0F;
            this.SecHd_line2.X1 = 8.25F;
            this.SecHd_line2.X2 = 8.25F;
            this.SecHd_line2.Y1 = 0.03F;
            this.SecHd_line2.Y2 = 0.13F;
            // 
            // SecHd_Title
            // 
            this.SecHd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Title.Height = 0.156F;
            this.SecHd_Title.Left = 0.25F;
            this.SecHd_Title.MultiLine = false;
            this.SecHd_Title.Name = "SecHd_Title";
            this.SecHd_Title.OutputFormat = resources.GetString("SecHd_Title.OutputFormat");
            this.SecHd_Title.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.SecHd_Title.Text = "拠点";
            this.SecHd_Title.Top = 0.031F;
            this.SecHd_Title.Width = 0.3F;
            // 
            // SecHd_WarehouseCode
            // 
            this.SecHd_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseCode.DataField = "WarehouseCode";
            this.SecHd_WarehouseCode.Height = 0.156F;
            this.SecHd_WarehouseCode.Left = 2.5F;
            this.SecHd_WarehouseCode.MultiLine = false;
            this.SecHd_WarehouseCode.Name = "SecHd_WarehouseCode";
            this.SecHd_WarehouseCode.OutputFormat = resources.GetString("SecHd_WarehouseCode.OutputFormat");
            this.SecHd_WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SecHd_WarehouseCode.Text = "1234";
            this.SecHd_WarehouseCode.Top = 0.031F;
            this.SecHd_WarehouseCode.Visible = false;
            this.SecHd_WarehouseCode.Width = 0.3F;
            // 
            // SecHd_WarehouseName
            // 
            this.SecHd_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseName.DataField = "WarehouseName";
            this.SecHd_WarehouseName.Height = 0.15625F;
            this.SecHd_WarehouseName.Left = 2.813F;
            this.SecHd_WarehouseName.MultiLine = false;
            this.SecHd_WarehouseName.Name = "SecHd_WarehouseName";
            this.SecHd_WarehouseName.OutputFormat = resources.GetString("SecHd_WarehouseName.OutputFormat");
            this.SecHd_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SecHd_WarehouseName.Text = "あいうえおかきくけこ";
            this.SecHd_WarehouseName.Top = 0.031F;
            this.SecHd_WarehouseName.Visible = false;
            this.SecHd_WarehouseName.Width = 1.1875F;
            // 
            // SecHd_WarehouseTitle
            // 
            this.SecHd_WarehouseTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_WarehouseTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_WarehouseTitle.Height = 0.156F;
            this.SecHd_WarehouseTitle.Left = 2.188F;
            this.SecHd_WarehouseTitle.MultiLine = false;
            this.SecHd_WarehouseTitle.Name = "SecHd_WarehouseTitle";
            this.SecHd_WarehouseTitle.OutputFormat = resources.GetString("SecHd_WarehouseTitle.OutputFormat");
            this.SecHd_WarehouseTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.SecHd_WarehouseTitle.Text = "倉庫";
            this.SecHd_WarehouseTitle.Top = 0.031F;
            this.SecHd_WarehouseTitle.Visible = false;
            this.SecHd_WarehouseTitle.Width = 0.3F;
            // 
            // SecHd_Line3
            // 
            this.SecHd_Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line3.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line3.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_Line3.Height = 0F;
            this.SecHd_Line3.Left = 0F;
            this.SecHd_Line3.LineWeight = 2F;
            this.SecHd_Line3.Name = "SecHd_Line3";
            this.SecHd_Line3.Top = 0F;
            this.SecHd_Line3.Width = 10.8F;
            this.SecHd_Line3.X1 = 0F;
            this.SecHd_Line3.X2 = 10.8F;
            this.SecHd_Line3.Y1 = 0F;
            this.SecHd_Line3.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Sec_Title,
            this.Line2,
            this.SecFt_GrossProfit,
            this.SecFt_SalesPrice,
            this.SecFt_TotalSalesCount,
            this.SecFt_GrossProfitRate,
            this.SecFt_TtlGrossProfit,
            this.SecFt_TtlSalesPrice,
            this.SecFt_TtlTotalSalesCount,
            this.SecFt_TtlGrossProfitRate,
            this.line11,
            this.line14,
            this.SecFt_MonthPureSalesMoney,
            this.SecFt_AnnualPureSalesMoney,
            this.SecFt_MonthGrossProfitOrg,
            this.SecFt_AnnualGrossProfitOrg});
            this.SectionFooter.Height = 0.625F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // Sec_Title
            // 
            this.Sec_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_Title.Height = 0.219F;
            this.Sec_Title.Left = 1.313F;
            this.Sec_Title.MultiLine = false;
            this.Sec_Title.Name = "Sec_Title";
            this.Sec_Title.OutputFormat = resources.GetString("Sec_Title.OutputFormat");
            this.Sec_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Sec_Title.Text = "拠点計";
            this.Sec_Title.Top = 0.04F;
            this.Sec_Title.Width = 0.5625F;
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
            // SecFt_GrossProfit
            // 
            this.SecFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.DataField = "MonthGrossProfit";
            this.SecFt_GrossProfit.Height = 0.156F;
            this.SecFt_GrossProfit.Left = 7.125F;
            this.SecFt_GrossProfit.MultiLine = false;
            this.SecFt_GrossProfit.Name = "SecFt_GrossProfit";
            this.SecFt_GrossProfit.OutputFormat = resources.GetString("SecFt_GrossProfit.OutputFormat");
            this.SecFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfit.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfit.Text = "123,456,789";
            this.SecFt_GrossProfit.Top = 0.063F;
            this.SecFt_GrossProfit.Width = 0.7F;
            // 
            // SecFt_SalesPrice
            // 
            this.SecFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.SecFt_SalesPrice.Height = 0.156F;
            this.SecFt_SalesPrice.Left = 6.438F;
            this.SecFt_SalesPrice.MultiLine = false;
            this.SecFt_SalesPrice.Name = "SecFt_SalesPrice";
            this.SecFt_SalesPrice.OutputFormat = resources.GetString("SecFt_SalesPrice.OutputFormat");
            this.SecFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesPrice.SummaryGroup = "SectionHeader";
            this.SecFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesPrice.Text = "123,456,789";
            this.SecFt_SalesPrice.Top = 0.063F;
            this.SecFt_SalesPrice.Width = 0.7F;
            // 
            // SecFt_TotalSalesCount
            // 
            this.SecFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.SecFt_TotalSalesCount.Height = 0.156F;
            this.SecFt_TotalSalesCount.Left = 5.75F;
            this.SecFt_TotalSalesCount.MultiLine = false;
            this.SecFt_TotalSalesCount.Name = "SecFt_TotalSalesCount";
            this.SecFt_TotalSalesCount.OutputFormat = resources.GetString("SecFt_TotalSalesCount.OutputFormat");
            this.SecFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount.Text = "123,456,789";
            this.SecFt_TotalSalesCount.Top = 0.063F;
            this.SecFt_TotalSalesCount.Width = 0.7F;
            // 
            // SecFt_GrossProfitRate
            // 
            this.SecFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Height = 0.156F;
            this.SecFt_GrossProfitRate.Left = 7.813F;
            this.SecFt_GrossProfitRate.MultiLine = false;
            this.SecFt_GrossProfitRate.Name = "SecFt_GrossProfitRate";
            this.SecFt_GrossProfitRate.OutputFormat = resources.GetString("SecFt_GrossProfitRate.OutputFormat");
            this.SecFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitRate.Text = "123.00";
            this.SecFt_GrossProfitRate.Top = 0.063F;
            this.SecFt_GrossProfitRate.Width = 0.42F;
            // 
            // SecFt_TtlGrossProfit
            // 
            this.SecFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.SecFt_TtlGrossProfit.Height = 0.156F;
            this.SecFt_TtlGrossProfit.Left = 9.625F;
            this.SecFt_TtlGrossProfit.MultiLine = false;
            this.SecFt_TtlGrossProfit.Name = "SecFt_TtlGrossProfit";
            this.SecFt_TtlGrossProfit.OutputFormat = resources.GetString("SecFt_TtlGrossProfit.OutputFormat");
            this.SecFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TtlGrossProfit.SummaryGroup = "SectionHeader";
            this.SecFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TtlGrossProfit.Text = "123,456,789";
            this.SecFt_TtlGrossProfit.Top = 0.063F;
            this.SecFt_TtlGrossProfit.Width = 0.7F;
            // 
            // SecFt_TtlSalesPrice
            // 
            this.SecFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.SecFt_TtlSalesPrice.Height = 0.156F;
            this.SecFt_TtlSalesPrice.Left = 8.938F;
            this.SecFt_TtlSalesPrice.MultiLine = false;
            this.SecFt_TtlSalesPrice.Name = "SecFt_TtlSalesPrice";
            this.SecFt_TtlSalesPrice.OutputFormat = resources.GetString("SecFt_TtlSalesPrice.OutputFormat");
            this.SecFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TtlSalesPrice.SummaryGroup = "SectionHeader";
            this.SecFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TtlSalesPrice.Text = "123,456,789";
            this.SecFt_TtlSalesPrice.Top = 0.063F;
            this.SecFt_TtlSalesPrice.Width = 0.7F;
            // 
            // SecFt_TtlTotalSalesCount
            // 
            this.SecFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.SecFt_TtlTotalSalesCount.Height = 0.156F;
            this.SecFt_TtlTotalSalesCount.Left = 8.25F;
            this.SecFt_TtlTotalSalesCount.MultiLine = false;
            this.SecFt_TtlTotalSalesCount.Name = "SecFt_TtlTotalSalesCount";
            this.SecFt_TtlTotalSalesCount.OutputFormat = resources.GetString("SecFt_TtlTotalSalesCount.OutputFormat");
            this.SecFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TtlTotalSalesCount.SummaryGroup = "SectionHeader";
            this.SecFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TtlTotalSalesCount.Text = "123,456,789";
            this.SecFt_TtlTotalSalesCount.Top = 0.063F;
            this.SecFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // SecFt_TtlGrossProfitRate
            // 
            this.SecFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlGrossProfitRate.Height = 0.156F;
            this.SecFt_TtlGrossProfitRate.Left = 10.313F;
            this.SecFt_TtlGrossProfitRate.MultiLine = false;
            this.SecFt_TtlGrossProfitRate.Name = "SecFt_TtlGrossProfitRate";
            this.SecFt_TtlGrossProfitRate.OutputFormat = resources.GetString("SecFt_TtlGrossProfitRate.OutputFormat");
            this.SecFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TtlGrossProfitRate.SummaryGroup = "SectionHeader";
            this.SecFt_TtlGrossProfitRate.Text = "123.00";
            this.SecFt_TtlGrossProfitRate.Top = 0.063F;
            this.SecFt_TtlGrossProfitRate.Width = 0.42F;
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
            this.line11.Height = 0.125F;
            this.line11.Left = 5.75F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0.0625F;
            this.line11.Width = 0F;
            this.line11.X1 = 5.75F;
            this.line11.X2 = 5.75F;
            this.line11.Y1 = 0.0625F;
            this.line11.Y2 = 0.1875F;
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
            this.line14.Height = 0.13F;
            this.line14.Left = 8.25F;
            this.line14.LineWeight = 1F;
            this.line14.Name = "line14";
            this.line14.Top = 0.06F;
            this.line14.Width = 0F;
            this.line14.X1 = 8.25F;
            this.line14.X2 = 8.25F;
            this.line14.Y1 = 0.06F;
            this.line14.Y2 = 0.19F;
            // 
            // SecFt_MonthPureSalesMoney
            // 
            this.SecFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.SecFt_MonthPureSalesMoney.Height = 0.15625F;
            this.SecFt_MonthPureSalesMoney.Left = 6.125F;
            this.SecFt_MonthPureSalesMoney.MultiLine = false;
            this.SecFt_MonthPureSalesMoney.Name = "SecFt_MonthPureSalesMoney";
            this.SecFt_MonthPureSalesMoney.OutputFormat = resources.GetString("SecFt_MonthPureSalesMoney.OutputFormat");
            this.SecFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthPureSalesMoney.SummaryGroup = "SectionHeader";
            this.SecFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.SecFt_MonthPureSalesMoney.Top = 0.25F;
            this.SecFt_MonthPureSalesMoney.Visible = false;
            this.SecFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // SecFt_AnnualPureSalesMoney
            // 
            this.SecFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.SecFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.SecFt_AnnualPureSalesMoney.Left = 8.625F;
            this.SecFt_AnnualPureSalesMoney.MultiLine = false;
            this.SecFt_AnnualPureSalesMoney.Name = "SecFt_AnnualPureSalesMoney";
            this.SecFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("SecFt_AnnualPureSalesMoney.OutputFormat");
            this.SecFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualPureSalesMoney.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.SecFt_AnnualPureSalesMoney.Top = 0.25F;
            this.SecFt_AnnualPureSalesMoney.Visible = false;
            this.SecFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // SecFt_MonthGrossProfitOrg
            // 
            this.SecFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.SecFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.SecFt_MonthGrossProfitOrg.Left = 6.875F;
            this.SecFt_MonthGrossProfitOrg.MultiLine = false;
            this.SecFt_MonthGrossProfitOrg.Name = "SecFt_MonthGrossProfitOrg";
            this.SecFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOrg.OutputFormat");
            this.SecFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOrg.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.SecFt_MonthGrossProfitOrg.Top = 0.25F;
            this.SecFt_MonthGrossProfitOrg.Visible = false;
            this.SecFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // SecFt_AnnualGrossProfitOrg
            // 
            this.SecFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.SecFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.SecFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.SecFt_AnnualGrossProfitOrg.MultiLine = false;
            this.SecFt_AnnualGrossProfitOrg.Name = "SecFt_AnnualGrossProfitOrg";
            this.SecFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("SecFt_AnnualGrossProfitOrg.OutputFormat");
            this.SecFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_AnnualGrossProfitOrg.SummaryGroup = "SectionHeader";
            this.SecFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.SecFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.SecFt_AnnualGrossProfitOrg.Visible = false;
            this.SecFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CusHd_line1,
            this.CusHd_line2,
            this.CusHd_AddUpSecCode,
            this.CusHd_SectionGuideNm,
            this.CusHd_CustomerCode,
            this.CusHd_CustomerSnm,
            this.CusHd_SectionTitle,
            this.CusHd_CustomerTitle,
            this.CusHd_WarehouseCode,
            this.CusHd_WarehouseName,
            this.CusHd_WarehouseTitle,
            this.CusHd_line3});
            this.CustomerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.CustomerHeader.Height = 0.4270833F;
            this.CustomerHeader.KeepTogether = true;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.AfterPrint += new System.EventHandler(this.CustomerHeader_AfterPrint);
            this.CustomerHeader.BeforePrint += new System.EventHandler(this.CustomerHeader_BeforePrint);
            // 
            // CusHd_line1
            // 
            this.CusHd_line1.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line1.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line1.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line1.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line1.Height = 0.095F;
            this.CusHd_line1.Left = 5.75F;
            this.CusHd_line1.LineWeight = 1F;
            this.CusHd_line1.Name = "CusHd_line1";
            this.CusHd_line1.Top = 0.03F;
            this.CusHd_line1.Width = 0F;
            this.CusHd_line1.X1 = 5.75F;
            this.CusHd_line1.X2 = 5.75F;
            this.CusHd_line1.Y1 = 0.03F;
            this.CusHd_line1.Y2 = 0.125F;
            // 
            // CusHd_line2
            // 
            this.CusHd_line2.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line2.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line2.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line2.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line2.Height = 0.09999999F;
            this.CusHd_line2.Left = 8.25F;
            this.CusHd_line2.LineWeight = 1F;
            this.CusHd_line2.Name = "CusHd_line2";
            this.CusHd_line2.Top = 0.03F;
            this.CusHd_line2.Width = 0F;
            this.CusHd_line2.X1 = 8.25F;
            this.CusHd_line2.X2 = 8.25F;
            this.CusHd_line2.Y1 = 0.03F;
            this.CusHd_line2.Y2 = 0.13F;
            // 
            // CusHd_AddUpSecCode
            // 
            this.CusHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.CusHd_AddUpSecCode.Height = 0.156F;
            this.CusHd_AddUpSecCode.Left = 0.563F;
            this.CusHd_AddUpSecCode.MultiLine = false;
            this.CusHd_AddUpSecCode.Name = "CusHd_AddUpSecCode";
            this.CusHd_AddUpSecCode.OutputFormat = resources.GetString("CusHd_AddUpSecCode.OutputFormat");
            this.CusHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CusHd_AddUpSecCode.Text = "12";
            this.CusHd_AddUpSecCode.Top = 0.031F;
            this.CusHd_AddUpSecCode.Width = 0.15F;
            // 
            // CusHd_SectionGuideNm
            // 
            this.CusHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionGuideNm.DataField = "CompanyName1";
            this.CusHd_SectionGuideNm.Height = 0.15625F;
            this.CusHd_SectionGuideNm.Left = 0.72F;
            this.CusHd_SectionGuideNm.MultiLine = false;
            this.CusHd_SectionGuideNm.Name = "CusHd_SectionGuideNm";
            this.CusHd_SectionGuideNm.OutputFormat = resources.GetString("CusHd_SectionGuideNm.OutputFormat");
            this.CusHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CusHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.CusHd_SectionGuideNm.Top = 0.031F;
            this.CusHd_SectionGuideNm.Width = 1.1875F;
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
            this.CusHd_CustomerCode.Height = 0.156F;
            this.CusHd_CustomerCode.Left = 2.563F;
            this.CusHd_CustomerCode.MultiLine = false;
            this.CusHd_CustomerCode.Name = "CusHd_CustomerCode";
            this.CusHd_CustomerCode.OutputFormat = resources.GetString("CusHd_CustomerCode.OutputFormat");
            this.CusHd_CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CusHd_CustomerCode.Text = "12345678";
            this.CusHd_CustomerCode.Top = 0.031F;
            this.CusHd_CustomerCode.Width = 0.5F;
            // 
            // CusHd_CustomerSnm
            // 
            this.CusHd_CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerSnm.DataField = "CustomerSnm";
            this.CusHd_CustomerSnm.Height = 0.156F;
            this.CusHd_CustomerSnm.Left = 3.063F;
            this.CusHd_CustomerSnm.MultiLine = false;
            this.CusHd_CustomerSnm.Name = "CusHd_CustomerSnm";
            this.CusHd_CustomerSnm.OutputFormat = resources.GetString("CusHd_CustomerSnm.OutputFormat");
            this.CusHd_CustomerSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CusHd_CustomerSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CusHd_CustomerSnm.Top = 0.031F;
            this.CusHd_CustomerSnm.Width = 2.3F;
            // 
            // CusHd_SectionTitle
            // 
            this.CusHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Height = 0.156F;
            this.CusHd_SectionTitle.Left = 0.25F;
            this.CusHd_SectionTitle.MultiLine = false;
            this.CusHd_SectionTitle.Name = "CusHd_SectionTitle";
            this.CusHd_SectionTitle.OutputFormat = resources.GetString("CusHd_SectionTitle.OutputFormat");
            this.CusHd_SectionTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_SectionTitle.Text = "拠点";
            this.CusHd_SectionTitle.Top = 0.031F;
            this.CusHd_SectionTitle.Width = 0.3F;
            // 
            // CusHd_CustomerTitle
            // 
            this.CusHd_CustomerTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Height = 0.156F;
            this.CusHd_CustomerTitle.Left = 2.188F;
            this.CusHd_CustomerTitle.MultiLine = false;
            this.CusHd_CustomerTitle.Name = "CusHd_CustomerTitle";
            this.CusHd_CustomerTitle.OutputFormat = resources.GetString("CusHd_CustomerTitle.OutputFormat");
            this.CusHd_CustomerTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_CustomerTitle.Text = "得意先";
            this.CusHd_CustomerTitle.Top = 0.031F;
            this.CusHd_CustomerTitle.Width = 0.4F;
            // 
            // CusHd_WarehouseCode
            // 
            this.CusHd_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseCode.DataField = "WarehouseCode";
            this.CusHd_WarehouseCode.Height = 0.156F;
            this.CusHd_WarehouseCode.Left = 0.5625F;
            this.CusHd_WarehouseCode.MultiLine = false;
            this.CusHd_WarehouseCode.Name = "CusHd_WarehouseCode";
            this.CusHd_WarehouseCode.OutputFormat = resources.GetString("CusHd_WarehouseCode.OutputFormat");
            this.CusHd_WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CusHd_WarehouseCode.Text = "1234";
            this.CusHd_WarehouseCode.Top = 0.25F;
            this.CusHd_WarehouseCode.Visible = false;
            this.CusHd_WarehouseCode.Width = 0.3F;
            // 
            // CusHd_WarehouseName
            // 
            this.CusHd_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseName.DataField = "WarehouseName";
            this.CusHd_WarehouseName.Height = 0.15625F;
            this.CusHd_WarehouseName.Left = 0.875F;
            this.CusHd_WarehouseName.MultiLine = false;
            this.CusHd_WarehouseName.Name = "CusHd_WarehouseName";
            this.CusHd_WarehouseName.OutputFormat = resources.GetString("CusHd_WarehouseName.OutputFormat");
            this.CusHd_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CusHd_WarehouseName.Text = "あいうえおかきくけこ";
            this.CusHd_WarehouseName.Top = 0.25F;
            this.CusHd_WarehouseName.Visible = false;
            this.CusHd_WarehouseName.Width = 1.1875F;
            // 
            // CusHd_WarehouseTitle
            // 
            this.CusHd_WarehouseTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseTitle.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseTitle.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_WarehouseTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_WarehouseTitle.Height = 0.156F;
            this.CusHd_WarehouseTitle.Left = 0.25F;
            this.CusHd_WarehouseTitle.MultiLine = false;
            this.CusHd_WarehouseTitle.Name = "CusHd_WarehouseTitle";
            this.CusHd_WarehouseTitle.OutputFormat = resources.GetString("CusHd_WarehouseTitle.OutputFormat");
            this.CusHd_WarehouseTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_WarehouseTitle.Text = "倉庫";
            this.CusHd_WarehouseTitle.Top = 0.25F;
            this.CusHd_WarehouseTitle.Visible = false;
            this.CusHd_WarehouseTitle.Width = 0.3F;
            // 
            // CusHd_line3
            // 
            this.CusHd_line3.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line3.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line3.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line3.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_line3.Height = 0F;
            this.CusHd_line3.Left = 0F;
            this.CusHd_line3.LineWeight = 2F;
            this.CusHd_line3.Name = "CusHd_line3";
            this.CusHd_line3.Top = 0F;
            this.CusHd_line3.Width = 10.8F;
            this.CusHd_line3.X1 = 0F;
            this.CusHd_line3.X2 = 10.8F;
            this.CusHd_line3.Y1 = 0F;
            this.CusHd_line3.Y2 = 0F;
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.Cus_Title,
            this.CusFt_GrossProfit,
            this.CusFt_SalesPrice,
            this.CusFt_TotalSalesCount,
            this.CusFt_GrossProfitRate,
            this.CusFt_TtlGrossProfit,
            this.CusFt_TtlSalesPrice,
            this.CusFt_TtlTotalSalesCount,
            this.CusFt_TtlGrossProfitRate,
            this.line10,
            this.line13,
            this.CusFt_CustomerCode,
            this.CusFt_CustomerSnm,
            this.CusFt_MonthPureSalesMoney,
            this.CusFt_AnnualPureSalesMoney,
            this.CusFt_MonthGrossProfitOrg,
            this.CusFt_AnnualGrossProfitOrg});
            this.CustomerFooter.Height = 0.625F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
            this.CustomerFooter.Format += new System.EventHandler(this.CustomerFooter_Format);
            this.CustomerFooter.BeforePrint += new System.EventHandler(this.CustomerFooter_BeforePrint);
            // 
            // Line44
            // 
            this.Line44.Border.BottomColor = System.Drawing.Color.Black;
            this.Line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.LeftColor = System.Drawing.Color.Black;
            this.Line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.RightColor = System.Drawing.Color.Black;
            this.Line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.TopColor = System.Drawing.Color.Black;
            this.Line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Height = 0F;
            this.Line44.Left = 0F;
            this.Line44.LineWeight = 2F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 0F;
            this.Line44.Width = 10.8F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 10.8F;
            this.Line44.Y1 = 0F;
            this.Line44.Y2 = 0F;
            // 
            // Cus_Title
            // 
            this.Cus_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Title.Height = 0.21875F;
            this.Cus_Title.Left = 1.313F;
            this.Cus_Title.MultiLine = false;
            this.Cus_Title.Name = "Cus_Title";
            this.Cus_Title.OutputFormat = resources.GetString("Cus_Title.OutputFormat");
            this.Cus_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Cus_Title.Text = "得意先計";
            this.Cus_Title.Top = 0.04F;
            this.Cus_Title.Width = 0.65625F;
            // 
            // CusFt_GrossProfit
            // 
            this.CusFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfit.DataField = "MonthGrossProfit";
            this.CusFt_GrossProfit.Height = 0.156F;
            this.CusFt_GrossProfit.Left = 7.125F;
            this.CusFt_GrossProfit.MultiLine = false;
            this.CusFt_GrossProfit.Name = "CusFt_GrossProfit";
            this.CusFt_GrossProfit.OutputFormat = resources.GetString("CusFt_GrossProfit.OutputFormat");
            this.CusFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_GrossProfit.SummaryGroup = "CustomerHeader";
            this.CusFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_GrossProfit.Text = "123,456,789";
            this.CusFt_GrossProfit.Top = 0.063F;
            this.CusFt_GrossProfit.Width = 0.7F;
            // 
            // CusFt_SalesPrice
            // 
            this.CusFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.CusFt_SalesPrice.Height = 0.156F;
            this.CusFt_SalesPrice.Left = 6.438F;
            this.CusFt_SalesPrice.MultiLine = false;
            this.CusFt_SalesPrice.Name = "CusFt_SalesPrice";
            this.CusFt_SalesPrice.OutputFormat = resources.GetString("CusFt_SalesPrice.OutputFormat");
            this.CusFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesPrice.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesPrice.Text = "123,456,789";
            this.CusFt_SalesPrice.Top = 0.063F;
            this.CusFt_SalesPrice.Width = 0.7F;
            // 
            // CusFt_TotalSalesCount
            // 
            this.CusFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.CusFt_TotalSalesCount.Height = 0.156F;
            this.CusFt_TotalSalesCount.Left = 5.75F;
            this.CusFt_TotalSalesCount.MultiLine = false;
            this.CusFt_TotalSalesCount.Name = "CusFt_TotalSalesCount";
            this.CusFt_TotalSalesCount.OutputFormat = resources.GetString("CusFt_TotalSalesCount.OutputFormat");
            this.CusFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount.Text = "123,456,789";
            this.CusFt_TotalSalesCount.Top = 0.063F;
            this.CusFt_TotalSalesCount.Width = 0.7F;
            // 
            // CusFt_GrossProfitRate
            // 
            this.CusFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_GrossProfitRate.Height = 0.156F;
            this.CusFt_GrossProfitRate.Left = 7.813F;
            this.CusFt_GrossProfitRate.MultiLine = false;
            this.CusFt_GrossProfitRate.Name = "CusFt_GrossProfitRate";
            this.CusFt_GrossProfitRate.OutputFormat = resources.GetString("CusFt_GrossProfitRate.OutputFormat");
            this.CusFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_GrossProfitRate.Text = "123.00";
            this.CusFt_GrossProfitRate.Top = 0.063F;
            this.CusFt_GrossProfitRate.Width = 0.42F;
            // 
            // CusFt_TtlGrossProfit
            // 
            this.CusFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.CusFt_TtlGrossProfit.Height = 0.156F;
            this.CusFt_TtlGrossProfit.Left = 9.625F;
            this.CusFt_TtlGrossProfit.MultiLine = false;
            this.CusFt_TtlGrossProfit.Name = "CusFt_TtlGrossProfit";
            this.CusFt_TtlGrossProfit.OutputFormat = resources.GetString("CusFt_TtlGrossProfit.OutputFormat");
            this.CusFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TtlGrossProfit.SummaryGroup = "CustomerHeader";
            this.CusFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TtlGrossProfit.Text = "123,456,789";
            this.CusFt_TtlGrossProfit.Top = 0.063F;
            this.CusFt_TtlGrossProfit.Width = 0.7F;
            // 
            // CusFt_TtlSalesPrice
            // 
            this.CusFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.CusFt_TtlSalesPrice.Height = 0.156F;
            this.CusFt_TtlSalesPrice.Left = 8.938F;
            this.CusFt_TtlSalesPrice.MultiLine = false;
            this.CusFt_TtlSalesPrice.Name = "CusFt_TtlSalesPrice";
            this.CusFt_TtlSalesPrice.OutputFormat = resources.GetString("CusFt_TtlSalesPrice.OutputFormat");
            this.CusFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TtlSalesPrice.SummaryGroup = "CustomerHeader";
            this.CusFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TtlSalesPrice.Text = "123,456,789";
            this.CusFt_TtlSalesPrice.Top = 0.063F;
            this.CusFt_TtlSalesPrice.Width = 0.7F;
            // 
            // CusFt_TtlTotalSalesCount
            // 
            this.CusFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.CusFt_TtlTotalSalesCount.Height = 0.156F;
            this.CusFt_TtlTotalSalesCount.Left = 8.25F;
            this.CusFt_TtlTotalSalesCount.MultiLine = false;
            this.CusFt_TtlTotalSalesCount.Name = "CusFt_TtlTotalSalesCount";
            this.CusFt_TtlTotalSalesCount.OutputFormat = resources.GetString("CusFt_TtlTotalSalesCount.OutputFormat");
            this.CusFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TtlTotalSalesCount.SummaryGroup = "CustomerHeader";
            this.CusFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TtlTotalSalesCount.Text = "123,456,789";
            this.CusFt_TtlTotalSalesCount.Top = 0.063F;
            this.CusFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // CusFt_TtlGrossProfitRate
            // 
            this.CusFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlGrossProfitRate.Height = 0.156F;
            this.CusFt_TtlGrossProfitRate.Left = 10.313F;
            this.CusFt_TtlGrossProfitRate.MultiLine = false;
            this.CusFt_TtlGrossProfitRate.Name = "CusFt_TtlGrossProfitRate";
            this.CusFt_TtlGrossProfitRate.OutputFormat = resources.GetString("CusFt_TtlGrossProfitRate.OutputFormat");
            this.CusFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TtlGrossProfitRate.SummaryGroup = "CustomerHeader";
            this.CusFt_TtlGrossProfitRate.Text = "123.00";
            this.CusFt_TtlGrossProfitRate.Top = 0.063F;
            this.CusFt_TtlGrossProfitRate.Width = 0.42F;
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
            this.line10.Height = 0.125F;
            this.line10.Left = 5.75F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0.0625F;
            this.line10.Width = 0F;
            this.line10.X1 = 5.75F;
            this.line10.X2 = 5.75F;
            this.line10.Y1 = 0.0625F;
            this.line10.Y2 = 0.1875F;
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
            this.line13.Height = 0.13F;
            this.line13.Left = 8.25F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0.06F;
            this.line13.Width = 0F;
            this.line13.X1 = 8.25F;
            this.line13.X2 = 8.25F;
            this.line13.Y1 = 0.06F;
            this.line13.Y2 = 0.19F;
            // 
            // CusFt_CustomerCode
            // 
            this.CusFt_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerCode.DataField = "CustomerCode";
            this.CusFt_CustomerCode.Height = 0.15625F;
            this.CusFt_CustomerCode.Left = 2.6875F;
            this.CusFt_CustomerCode.MultiLine = false;
            this.CusFt_CustomerCode.Name = "CusFt_CustomerCode";
            this.CusFt_CustomerCode.OutputFormat = resources.GetString("CusFt_CustomerCode.OutputFormat");
            this.CusFt_CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_CustomerCode.Text = "12345678";
            this.CusFt_CustomerCode.Top = 0.0625F;
            this.CusFt_CustomerCode.Width = 0.53125F;
            // 
            // CusFt_CustomerSnm
            // 
            this.CusFt_CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_CustomerSnm.DataField = "CustomerSnm";
            this.CusFt_CustomerSnm.Height = 0.156F;
            this.CusFt_CustomerSnm.Left = 3.25F;
            this.CusFt_CustomerSnm.MultiLine = false;
            this.CusFt_CustomerSnm.Name = "CusFt_CustomerSnm";
            this.CusFt_CustomerSnm.OutputFormat = resources.GetString("CusFt_CustomerSnm.OutputFormat");
            this.CusFt_CustomerSnm.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.CusFt_CustomerSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CusFt_CustomerSnm.Top = 0.0625F;
            this.CusFt_CustomerSnm.Width = 2.3F;
            // 
            // CusFt_MonthPureSalesMoney
            // 
            this.CusFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.CusFt_MonthPureSalesMoney.Height = 0.15625F;
            this.CusFt_MonthPureSalesMoney.Left = 6.125F;
            this.CusFt_MonthPureSalesMoney.MultiLine = false;
            this.CusFt_MonthPureSalesMoney.Name = "CusFt_MonthPureSalesMoney";
            this.CusFt_MonthPureSalesMoney.OutputFormat = resources.GetString("CusFt_MonthPureSalesMoney.OutputFormat");
            this.CusFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_MonthPureSalesMoney.SummaryGroup = "CustomerHeader";
            this.CusFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.CusFt_MonthPureSalesMoney.Top = 0.25F;
            this.CusFt_MonthPureSalesMoney.Visible = false;
            this.CusFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // CusFt_AnnualPureSalesMoney
            // 
            this.CusFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.CusFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.CusFt_AnnualPureSalesMoney.Left = 8.625F;
            this.CusFt_AnnualPureSalesMoney.MultiLine = false;
            this.CusFt_AnnualPureSalesMoney.Name = "CusFt_AnnualPureSalesMoney";
            this.CusFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("CusFt_AnnualPureSalesMoney.OutputFormat");
            this.CusFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_AnnualPureSalesMoney.SummaryGroup = "CustomerHeader";
            this.CusFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.CusFt_AnnualPureSalesMoney.Top = 0.25F;
            this.CusFt_AnnualPureSalesMoney.Visible = false;
            this.CusFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // CusFt_MonthGrossProfitOrg
            // 
            this.CusFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.CusFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.CusFt_MonthGrossProfitOrg.Left = 6.875F;
            this.CusFt_MonthGrossProfitOrg.MultiLine = false;
            this.CusFt_MonthGrossProfitOrg.Name = "CusFt_MonthGrossProfitOrg";
            this.CusFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("CusFt_MonthGrossProfitOrg.OutputFormat");
            this.CusFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_MonthGrossProfitOrg.SummaryGroup = "CustomerHeader";
            this.CusFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.CusFt_MonthGrossProfitOrg.Top = 0.25F;
            this.CusFt_MonthGrossProfitOrg.Visible = false;
            this.CusFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // CusFt_AnnualGrossProfitOrg
            // 
            this.CusFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.CusFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.CusFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.CusFt_AnnualGrossProfitOrg.MultiLine = false;
            this.CusFt_AnnualGrossProfitOrg.Name = "CusFt_AnnualGrossProfitOrg";
            this.CusFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("CusFt_AnnualGrossProfitOrg.OutputFormat");
            this.CusFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_AnnualGrossProfitOrg.SummaryGroup = "CustomerHeader";
            this.CusFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.CusFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.CusFt_AnnualGrossProfitOrg.Visible = false;
            this.CusFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // BLGoodsCodeHeader
            // 
            this.BLGoodsCodeHeader.CanShrink = true;
            this.BLGoodsCodeHeader.Height = 0F;
            this.BLGoodsCodeHeader.KeepTogether = true;
            this.BLGoodsCodeHeader.Name = "BLGoodsCodeHeader";
            this.BLGoodsCodeHeader.BeforePrint += new System.EventHandler(this.BLGoodsCodeHeader_BeforePrint);
            // 
            // BLGoodsCodeFooter
            // 
            this.BLGoodsCodeFooter.CanShrink = true;
            this.BLGoodsCodeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line16,
            this.textBox31,
            this.BlFt_GrossProfit,
            this.BlFt_SalesPrice,
            this.BlFt_TotalSalesCount,
            this.BlFt_GrossProfitRate,
            this.BlFt_TtlGrossProfit,
            this.BlFt_TtlSalesPrice,
            this.BlFt_TtlTotalSalesCount,
            this.BlFt_TtlGrossProfitRate,
            this.line32,
            this.line33,
            this.BlFt_BLGoodsCode,
            this.BlFt_BLGoodsHalfName,
            this.BlFt_MonthPureSalesMoney,
            this.BlFt_AnnualPureSalesMoney,
            this.BlFt_MonthGrossProfitOrg,
            this.BlFt_AnnualGrossProfitOrg});
            this.BLGoodsCodeFooter.Height = 0.4583333F;
            this.BLGoodsCodeFooter.KeepTogether = true;
            this.BLGoodsCodeFooter.Name = "BLGoodsCodeFooter";
            this.BLGoodsCodeFooter.Format += new System.EventHandler(this.BLGoodsCodeFooter_Format);
            this.BLGoodsCodeFooter.BeforePrint += new System.EventHandler(this.BLGoodsCodeFooter_BeforePrint);
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
            this.line16.LineWeight = 2F;
            this.line16.Name = "line16";
            this.line16.Top = 0F;
            this.line16.Width = 10.8F;
            this.line16.X1 = 0F;
            this.line16.X2 = 10.8F;
            this.line16.Y1 = 0F;
            this.line16.Y2 = 0F;
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
            this.textBox31.Height = 0.21875F;
            this.textBox31.Left = 1.313F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox31.Text = "ＢＬコード計";
            this.textBox31.Top = 0.04F;
            this.textBox31.Width = 1.09375F;
            // 
            // BlFt_GrossProfit
            // 
            this.BlFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfit.DataField = "MonthGrossProfit";
            this.BlFt_GrossProfit.Height = 0.156F;
            this.BlFt_GrossProfit.Left = 7.125F;
            this.BlFt_GrossProfit.MultiLine = false;
            this.BlFt_GrossProfit.Name = "BlFt_GrossProfit";
            this.BlFt_GrossProfit.OutputFormat = resources.GetString("BlFt_GrossProfit.OutputFormat");
            this.BlFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_GrossProfit.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_GrossProfit.Text = "123,456,789";
            this.BlFt_GrossProfit.Top = 0.0625F;
            this.BlFt_GrossProfit.Width = 0.7F;
            // 
            // BlFt_SalesPrice
            // 
            this.BlFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.BlFt_SalesPrice.Height = 0.156F;
            this.BlFt_SalesPrice.Left = 6.4375F;
            this.BlFt_SalesPrice.MultiLine = false;
            this.BlFt_SalesPrice.Name = "BlFt_SalesPrice";
            this.BlFt_SalesPrice.OutputFormat = resources.GetString("BlFt_SalesPrice.OutputFormat");
            this.BlFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesPrice.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesPrice.Text = "123,456,789";
            this.BlFt_SalesPrice.Top = 0.0625F;
            this.BlFt_SalesPrice.Width = 0.7F;
            // 
            // BlFt_TotalSalesCount
            // 
            this.BlFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.BlFt_TotalSalesCount.Height = 0.156F;
            this.BlFt_TotalSalesCount.Left = 5.75F;
            this.BlFt_TotalSalesCount.MultiLine = false;
            this.BlFt_TotalSalesCount.Name = "BlFt_TotalSalesCount";
            this.BlFt_TotalSalesCount.OutputFormat = resources.GetString("BlFt_TotalSalesCount.OutputFormat");
            this.BlFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount.Text = "123,456,789";
            this.BlFt_TotalSalesCount.Top = 0.0625F;
            this.BlFt_TotalSalesCount.Width = 0.7F;
            // 
            // BlFt_GrossProfitRate
            // 
            this.BlFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_GrossProfitRate.Height = 0.156F;
            this.BlFt_GrossProfitRate.Left = 7.8125F;
            this.BlFt_GrossProfitRate.MultiLine = false;
            this.BlFt_GrossProfitRate.Name = "BlFt_GrossProfitRate";
            this.BlFt_GrossProfitRate.OutputFormat = resources.GetString("BlFt_GrossProfitRate.OutputFormat");
            this.BlFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_GrossProfitRate.Text = "123.00";
            this.BlFt_GrossProfitRate.Top = 0.0625F;
            this.BlFt_GrossProfitRate.Width = 0.42F;
            // 
            // BlFt_TtlGrossProfit
            // 
            this.BlFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.BlFt_TtlGrossProfit.Height = 0.156F;
            this.BlFt_TtlGrossProfit.Left = 9.625F;
            this.BlFt_TtlGrossProfit.MultiLine = false;
            this.BlFt_TtlGrossProfit.Name = "BlFt_TtlGrossProfit";
            this.BlFt_TtlGrossProfit.OutputFormat = resources.GetString("BlFt_TtlGrossProfit.OutputFormat");
            this.BlFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TtlGrossProfit.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TtlGrossProfit.Text = "123,456,789";
            this.BlFt_TtlGrossProfit.Top = 0.0625F;
            this.BlFt_TtlGrossProfit.Width = 0.7F;
            // 
            // BlFt_TtlSalesPrice
            // 
            this.BlFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.BlFt_TtlSalesPrice.Height = 0.156F;
            this.BlFt_TtlSalesPrice.Left = 8.9375F;
            this.BlFt_TtlSalesPrice.MultiLine = false;
            this.BlFt_TtlSalesPrice.Name = "BlFt_TtlSalesPrice";
            this.BlFt_TtlSalesPrice.OutputFormat = resources.GetString("BlFt_TtlSalesPrice.OutputFormat");
            this.BlFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TtlSalesPrice.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TtlSalesPrice.Text = "123,456,789";
            this.BlFt_TtlSalesPrice.Top = 0.0625F;
            this.BlFt_TtlSalesPrice.Width = 0.7F;
            // 
            // BlFt_TtlTotalSalesCount
            // 
            this.BlFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.BlFt_TtlTotalSalesCount.Height = 0.156F;
            this.BlFt_TtlTotalSalesCount.Left = 8.25F;
            this.BlFt_TtlTotalSalesCount.MultiLine = false;
            this.BlFt_TtlTotalSalesCount.Name = "BlFt_TtlTotalSalesCount";
            this.BlFt_TtlTotalSalesCount.OutputFormat = resources.GetString("BlFt_TtlTotalSalesCount.OutputFormat");
            this.BlFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TtlTotalSalesCount.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TtlTotalSalesCount.Text = "123,456,789";
            this.BlFt_TtlTotalSalesCount.Top = 0.0625F;
            this.BlFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // BlFt_TtlGrossProfitRate
            // 
            this.BlFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlGrossProfitRate.Height = 0.156F;
            this.BlFt_TtlGrossProfitRate.Left = 10.3125F;
            this.BlFt_TtlGrossProfitRate.MultiLine = false;
            this.BlFt_TtlGrossProfitRate.Name = "BlFt_TtlGrossProfitRate";
            this.BlFt_TtlGrossProfitRate.OutputFormat = resources.GetString("BlFt_TtlGrossProfitRate.OutputFormat");
            this.BlFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TtlGrossProfitRate.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TtlGrossProfitRate.Text = "123.00";
            this.BlFt_TtlGrossProfitRate.Top = 0.0625F;
            this.BlFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line32
            // 
            this.line32.Border.BottomColor = System.Drawing.Color.Black;
            this.line32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Border.LeftColor = System.Drawing.Color.Black;
            this.line32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Border.RightColor = System.Drawing.Color.Black;
            this.line32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Border.TopColor = System.Drawing.Color.Black;
            this.line32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Height = 0.125F;
            this.line32.Left = 5.75F;
            this.line32.LineWeight = 1F;
            this.line32.Name = "line32";
            this.line32.Top = 0.0625F;
            this.line32.Width = 0F;
            this.line32.X1 = 5.75F;
            this.line32.X2 = 5.75F;
            this.line32.Y1 = 0.0625F;
            this.line32.Y2 = 0.1875F;
            // 
            // line33
            // 
            this.line33.Border.BottomColor = System.Drawing.Color.Black;
            this.line33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.LeftColor = System.Drawing.Color.Black;
            this.line33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.RightColor = System.Drawing.Color.Black;
            this.line33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.TopColor = System.Drawing.Color.Black;
            this.line33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Height = 0.13F;
            this.line33.Left = 8.25F;
            this.line33.LineWeight = 1F;
            this.line33.Name = "line33";
            this.line33.Top = 0.06F;
            this.line33.Width = 0F;
            this.line33.X1 = 8.25F;
            this.line33.X2 = 8.25F;
            this.line33.Y1 = 0.06F;
            this.line33.Y2 = 0.19F;
            // 
            // BlFt_BLGoodsCode
            // 
            this.BlFt_BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsCode.DataField = "BLGoodsCode";
            this.BlFt_BLGoodsCode.Height = 0.15625F;
            this.BlFt_BLGoodsCode.Left = 2.6875F;
            this.BlFt_BLGoodsCode.MultiLine = false;
            this.BlFt_BLGoodsCode.Name = "BlFt_BLGoodsCode";
            this.BlFt_BLGoodsCode.OutputFormat = resources.GetString("BlFt_BLGoodsCode.OutputFormat");
            this.BlFt_BLGoodsCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_BLGoodsCode.Text = "12345";
            this.BlFt_BLGoodsCode.Top = 0.0625F;
            this.BlFt_BLGoodsCode.Width = 0.5F;
            // 
            // BlFt_BLGoodsHalfName
            // 
            this.BlFt_BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsHalfName.DataField = "BLGoodsHalfName";
            this.BlFt_BLGoodsHalfName.Height = 0.15625F;
            this.BlFt_BLGoodsHalfName.Left = 3.25F;
            this.BlFt_BLGoodsHalfName.MultiLine = false;
            this.BlFt_BLGoodsHalfName.Name = "BlFt_BLGoodsHalfName";
            this.BlFt_BLGoodsHalfName.OutputFormat = resources.GetString("BlFt_BLGoodsHalfName.OutputFormat");
            this.BlFt_BLGoodsHalfName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.BlFt_BLGoodsHalfName.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉ";
            this.BlFt_BLGoodsHalfName.Top = 0.063F;
            this.BlFt_BLGoodsHalfName.Width = 1.13F;
            // 
            // BlFt_MonthPureSalesMoney
            // 
            this.BlFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.BlFt_MonthPureSalesMoney.Height = 0.15625F;
            this.BlFt_MonthPureSalesMoney.Left = 6.125F;
            this.BlFt_MonthPureSalesMoney.MultiLine = false;
            this.BlFt_MonthPureSalesMoney.Name = "BlFt_MonthPureSalesMoney";
            this.BlFt_MonthPureSalesMoney.OutputFormat = resources.GetString("BlFt_MonthPureSalesMoney.OutputFormat");
            this.BlFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_MonthPureSalesMoney.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.BlFt_MonthPureSalesMoney.Top = 0.25F;
            this.BlFt_MonthPureSalesMoney.Visible = false;
            this.BlFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // BlFt_AnnualPureSalesMoney
            // 
            this.BlFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.BlFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.BlFt_AnnualPureSalesMoney.Left = 8.6875F;
            this.BlFt_AnnualPureSalesMoney.MultiLine = false;
            this.BlFt_AnnualPureSalesMoney.Name = "BlFt_AnnualPureSalesMoney";
            this.BlFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("BlFt_AnnualPureSalesMoney.OutputFormat");
            this.BlFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_AnnualPureSalesMoney.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.BlFt_AnnualPureSalesMoney.Top = 0.25F;
            this.BlFt_AnnualPureSalesMoney.Visible = false;
            this.BlFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // BlFt_MonthGrossProfitOrg
            // 
            this.BlFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.BlFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.BlFt_MonthGrossProfitOrg.Left = 6.875F;
            this.BlFt_MonthGrossProfitOrg.MultiLine = false;
            this.BlFt_MonthGrossProfitOrg.Name = "BlFt_MonthGrossProfitOrg";
            this.BlFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("BlFt_MonthGrossProfitOrg.OutputFormat");
            this.BlFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_MonthGrossProfitOrg.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.BlFt_MonthGrossProfitOrg.Top = 0.25F;
            this.BlFt_MonthGrossProfitOrg.Visible = false;
            this.BlFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // BlFt_AnnualGrossProfitOrg
            // 
            this.BlFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.BlFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.BlFt_AnnualGrossProfitOrg.Left = 9.4375F;
            this.BlFt_AnnualGrossProfitOrg.MultiLine = false;
            this.BlFt_AnnualGrossProfitOrg.Name = "BlFt_AnnualGrossProfitOrg";
            this.BlFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("BlFt_AnnualGrossProfitOrg.OutputFormat");
            this.BlFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_AnnualGrossProfitOrg.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.BlFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.BlFt_AnnualGrossProfitOrg.Visible = false;
            this.BlFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // GoodsMGroupHeader
            // 
            this.GoodsMGroupHeader.CanShrink = true;
            this.GoodsMGroupHeader.Height = 0F;
            this.GoodsMGroupHeader.KeepTogether = true;
            this.GoodsMGroupHeader.Name = "GoodsMGroupHeader";
            this.GoodsMGroupHeader.BeforePrint += new System.EventHandler(this.GoodsMGroupHeader_BeforePrint);
            // 
            // GoodsMGroupFooter
            // 
            this.GoodsMGroupFooter.CanShrink = true;
            this.GoodsMGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line18,
            this.textBox33,
            this.MggFt_GrossProfit,
            this.MggFt_SalesPrice,
            this.MggFt_TotalSalesCount,
            this.MggFt_GrossProfitRate,
            this.MggFt_TtlGrossProfit,
            this.MggFt_TtlSalesPrice,
            this.MggFt_TtlTotalSalesCount,
            this.MggFt_TtlGrossProfitRate,
            this.line28,
            this.line29,
            this.MggFt_MediumGoodsGanreCode,
            this.MggFt_MediumGoodsGanreName,
            this.MggFt_MonthPureSalesMoney,
            this.MggFt_AnnualPureSalesMoney,
            this.MggFt_MonthGrossProfitOrg,
            this.MggFt_AnnualGrossProfitOrg});
            this.GoodsMGroupFooter.Height = 0.625F;
            this.GoodsMGroupFooter.KeepTogether = true;
            this.GoodsMGroupFooter.Name = "GoodsMGroupFooter";
            this.GoodsMGroupFooter.Format += new System.EventHandler(this.GoodsMGroupFooter_Format);
            this.GoodsMGroupFooter.BeforePrint += new System.EventHandler(this.MGoodsGanreFooter_BeforePrint);
            // 
            // line18
            // 
            this.line18.Border.BottomColor = System.Drawing.Color.Black;
            this.line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.LeftColor = System.Drawing.Color.Black;
            this.line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.RightColor = System.Drawing.Color.Black;
            this.line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.TopColor = System.Drawing.Color.Black;
            this.line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Height = 0F;
            this.line18.Left = 0F;
            this.line18.LineWeight = 2F;
            this.line18.Name = "line18";
            this.line18.Top = 0F;
            this.line18.Width = 10.8F;
            this.line18.X1 = 0F;
            this.line18.X2 = 10.8F;
            this.line18.Y1 = 0F;
            this.line18.Y2 = 0F;
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
            this.textBox33.Height = 0.219F;
            this.textBox33.Left = 1.313F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox33.Text = "商品中分類計";
            this.textBox33.Top = 0.04F;
            this.textBox33.Width = 1F;
            // 
            // MggFt_GrossProfit
            // 
            this.MggFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfit.DataField = "MonthGrossProfit";
            this.MggFt_GrossProfit.Height = 0.156F;
            this.MggFt_GrossProfit.Left = 7.125F;
            this.MggFt_GrossProfit.MultiLine = false;
            this.MggFt_GrossProfit.Name = "MggFt_GrossProfit";
            this.MggFt_GrossProfit.OutputFormat = resources.GetString("MggFt_GrossProfit.OutputFormat");
            this.MggFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_GrossProfit.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_GrossProfit.Text = "123,456,789";
            this.MggFt_GrossProfit.Top = 0.063F;
            this.MggFt_GrossProfit.Width = 0.7F;
            // 
            // MggFt_SalesPrice
            // 
            this.MggFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.MggFt_SalesPrice.Height = 0.156F;
            this.MggFt_SalesPrice.Left = 6.438F;
            this.MggFt_SalesPrice.MultiLine = false;
            this.MggFt_SalesPrice.Name = "MggFt_SalesPrice";
            this.MggFt_SalesPrice.OutputFormat = resources.GetString("MggFt_SalesPrice.OutputFormat");
            this.MggFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesPrice.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesPrice.Text = "123,456,789";
            this.MggFt_SalesPrice.Top = 0.063F;
            this.MggFt_SalesPrice.Width = 0.7F;
            // 
            // MggFt_TotalSalesCount
            // 
            this.MggFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.MggFt_TotalSalesCount.Height = 0.156F;
            this.MggFt_TotalSalesCount.Left = 5.75F;
            this.MggFt_TotalSalesCount.MultiLine = false;
            this.MggFt_TotalSalesCount.Name = "MggFt_TotalSalesCount";
            this.MggFt_TotalSalesCount.OutputFormat = resources.GetString("MggFt_TotalSalesCount.OutputFormat");
            this.MggFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount.Text = "123,456,789";
            this.MggFt_TotalSalesCount.Top = 0.063F;
            this.MggFt_TotalSalesCount.Width = 0.7F;
            // 
            // MggFt_GrossProfitRate
            // 
            this.MggFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GrossProfitRate.Height = 0.156F;
            this.MggFt_GrossProfitRate.Left = 7.813F;
            this.MggFt_GrossProfitRate.MultiLine = false;
            this.MggFt_GrossProfitRate.Name = "MggFt_GrossProfitRate";
            this.MggFt_GrossProfitRate.OutputFormat = resources.GetString("MggFt_GrossProfitRate.OutputFormat");
            this.MggFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_GrossProfitRate.Text = "123.00";
            this.MggFt_GrossProfitRate.Top = 0.063F;
            this.MggFt_GrossProfitRate.Width = 0.42F;
            // 
            // MggFt_TtlGrossProfit
            // 
            this.MggFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.MggFt_TtlGrossProfit.Height = 0.156F;
            this.MggFt_TtlGrossProfit.Left = 9.625F;
            this.MggFt_TtlGrossProfit.MultiLine = false;
            this.MggFt_TtlGrossProfit.Name = "MggFt_TtlGrossProfit";
            this.MggFt_TtlGrossProfit.OutputFormat = resources.GetString("MggFt_TtlGrossProfit.OutputFormat");
            this.MggFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TtlGrossProfit.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TtlGrossProfit.Text = "123,456,789";
            this.MggFt_TtlGrossProfit.Top = 0.063F;
            this.MggFt_TtlGrossProfit.Width = 0.7F;
            // 
            // MggFt_TtlSalesPrice
            // 
            this.MggFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.MggFt_TtlSalesPrice.Height = 0.156F;
            this.MggFt_TtlSalesPrice.Left = 8.938F;
            this.MggFt_TtlSalesPrice.MultiLine = false;
            this.MggFt_TtlSalesPrice.Name = "MggFt_TtlSalesPrice";
            this.MggFt_TtlSalesPrice.OutputFormat = resources.GetString("MggFt_TtlSalesPrice.OutputFormat");
            this.MggFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TtlSalesPrice.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TtlSalesPrice.Text = "123,456,789";
            this.MggFt_TtlSalesPrice.Top = 0.063F;
            this.MggFt_TtlSalesPrice.Width = 0.7F;
            // 
            // MggFt_TtlTotalSalesCount
            // 
            this.MggFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.MggFt_TtlTotalSalesCount.Height = 0.156F;
            this.MggFt_TtlTotalSalesCount.Left = 8.25F;
            this.MggFt_TtlTotalSalesCount.MultiLine = false;
            this.MggFt_TtlTotalSalesCount.Name = "MggFt_TtlTotalSalesCount";
            this.MggFt_TtlTotalSalesCount.OutputFormat = resources.GetString("MggFt_TtlTotalSalesCount.OutputFormat");
            this.MggFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TtlTotalSalesCount.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TtlTotalSalesCount.Text = "123,456,789";
            this.MggFt_TtlTotalSalesCount.Top = 0.063F;
            this.MggFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // MggFt_TtlGrossProfitRate
            // 
            this.MggFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlGrossProfitRate.Height = 0.156F;
            this.MggFt_TtlGrossProfitRate.Left = 10.313F;
            this.MggFt_TtlGrossProfitRate.MultiLine = false;
            this.MggFt_TtlGrossProfitRate.Name = "MggFt_TtlGrossProfitRate";
            this.MggFt_TtlGrossProfitRate.OutputFormat = resources.GetString("MggFt_TtlGrossProfitRate.OutputFormat");
            this.MggFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TtlGrossProfitRate.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TtlGrossProfitRate.Text = "123.00";
            this.MggFt_TtlGrossProfitRate.Top = 0.063F;
            this.MggFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line28
            // 
            this.line28.Border.BottomColor = System.Drawing.Color.Black;
            this.line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.LeftColor = System.Drawing.Color.Black;
            this.line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.RightColor = System.Drawing.Color.Black;
            this.line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.TopColor = System.Drawing.Color.Black;
            this.line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Height = 0.125F;
            this.line28.Left = 5.75F;
            this.line28.LineWeight = 1F;
            this.line28.Name = "line28";
            this.line28.Top = 0.0625F;
            this.line28.Width = 0F;
            this.line28.X1 = 5.75F;
            this.line28.X2 = 5.75F;
            this.line28.Y1 = 0.0625F;
            this.line28.Y2 = 0.1875F;
            // 
            // line29
            // 
            this.line29.Border.BottomColor = System.Drawing.Color.Black;
            this.line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.LeftColor = System.Drawing.Color.Black;
            this.line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.RightColor = System.Drawing.Color.Black;
            this.line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.TopColor = System.Drawing.Color.Black;
            this.line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Height = 0.13F;
            this.line29.Left = 8.25F;
            this.line29.LineWeight = 1F;
            this.line29.Name = "line29";
            this.line29.Top = 0.06F;
            this.line29.Width = 0F;
            this.line29.X1 = 8.25F;
            this.line29.X2 = 8.25F;
            this.line29.Y1 = 0.06F;
            this.line29.Y2 = 0.19F;
            // 
            // MggFt_MediumGoodsGanreCode
            // 
            this.MggFt_MediumGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreCode.DataField = "GoodsMGroup";
            this.MggFt_MediumGoodsGanreCode.Height = 0.15625F;
            this.MggFt_MediumGoodsGanreCode.Left = 2.688F;
            this.MggFt_MediumGoodsGanreCode.MultiLine = false;
            this.MggFt_MediumGoodsGanreCode.Name = "MggFt_MediumGoodsGanreCode";
            this.MggFt_MediumGoodsGanreCode.OutputFormat = resources.GetString("MggFt_MediumGoodsGanreCode.OutputFormat");
            this.MggFt_MediumGoodsGanreCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_MediumGoodsGanreCode.Text = "1234";
            this.MggFt_MediumGoodsGanreCode.Top = 0.063F;
            this.MggFt_MediumGoodsGanreCode.Width = 0.3125F;
            // 
            // MggFt_MediumGoodsGanreName
            // 
            this.MggFt_MediumGoodsGanreName.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreName.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreName.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreName.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_MediumGoodsGanreName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MediumGoodsGanreName.DataField = "GoodsMGroupName";
            this.MggFt_MediumGoodsGanreName.Height = 0.15625F;
            this.MggFt_MediumGoodsGanreName.Left = 3.25F;
            this.MggFt_MediumGoodsGanreName.MultiLine = false;
            this.MggFt_MediumGoodsGanreName.Name = "MggFt_MediumGoodsGanreName";
            this.MggFt_MediumGoodsGanreName.OutputFormat = resources.GetString("MggFt_MediumGoodsGanreName.OutputFormat");
            this.MggFt_MediumGoodsGanreName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.MggFt_MediumGoodsGanreName.Text = "あいうえおかきくけこ";
            this.MggFt_MediumGoodsGanreName.Top = 0.063F;
            this.MggFt_MediumGoodsGanreName.Width = 1.1875F;
            // 
            // MggFt_MonthPureSalesMoney
            // 
            this.MggFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.MggFt_MonthPureSalesMoney.Height = 0.15625F;
            this.MggFt_MonthPureSalesMoney.Left = 6.125F;
            this.MggFt_MonthPureSalesMoney.MultiLine = false;
            this.MggFt_MonthPureSalesMoney.Name = "MggFt_MonthPureSalesMoney";
            this.MggFt_MonthPureSalesMoney.OutputFormat = resources.GetString("MggFt_MonthPureSalesMoney.OutputFormat");
            this.MggFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_MonthPureSalesMoney.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.MggFt_MonthPureSalesMoney.Top = 0.25F;
            this.MggFt_MonthPureSalesMoney.Visible = false;
            this.MggFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // MggFt_AnnualPureSalesMoney
            // 
            this.MggFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.MggFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.MggFt_AnnualPureSalesMoney.Left = 8.625F;
            this.MggFt_AnnualPureSalesMoney.MultiLine = false;
            this.MggFt_AnnualPureSalesMoney.Name = "MggFt_AnnualPureSalesMoney";
            this.MggFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("MggFt_AnnualPureSalesMoney.OutputFormat");
            this.MggFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_AnnualPureSalesMoney.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.MggFt_AnnualPureSalesMoney.Top = 0.25F;
            this.MggFt_AnnualPureSalesMoney.Visible = false;
            this.MggFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // MggFt_MonthGrossProfitOrg
            // 
            this.MggFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.MggFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.MggFt_MonthGrossProfitOrg.Left = 6.875F;
            this.MggFt_MonthGrossProfitOrg.MultiLine = false;
            this.MggFt_MonthGrossProfitOrg.Name = "MggFt_MonthGrossProfitOrg";
            this.MggFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("MggFt_MonthGrossProfitOrg.OutputFormat");
            this.MggFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_MonthGrossProfitOrg.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.MggFt_MonthGrossProfitOrg.Top = 0.25F;
            this.MggFt_MonthGrossProfitOrg.Visible = false;
            this.MggFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // MggFt_AnnualGrossProfitOrg
            // 
            this.MggFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.MggFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.MggFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.MggFt_AnnualGrossProfitOrg.MultiLine = false;
            this.MggFt_AnnualGrossProfitOrg.Name = "MggFt_AnnualGrossProfitOrg";
            this.MggFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("MggFt_AnnualGrossProfitOrg.OutputFormat");
            this.MggFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_AnnualGrossProfitOrg.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.MggFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.MggFt_AnnualGrossProfitOrg.Visible = false;
            this.MggFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // BLGroupCodeHeader
            // 
            this.BLGroupCodeHeader.CanShrink = true;
            this.BLGroupCodeHeader.Height = 0F;
            this.BLGroupCodeHeader.KeepTogether = true;
            this.BLGroupCodeHeader.Name = "BLGroupCodeHeader";
            this.BLGroupCodeHeader.BeforePrint += new System.EventHandler(this.BLGroupCodeHeader_BeforePrint);
            // 
            // BLGroupCodeFooter
            // 
            this.BLGroupCodeFooter.CanShrink = true;
            this.BLGroupCodeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line17,
            this.textBox32,
            this.DggFt_GrossProfit,
            this.DggFt_SalesPrice,
            this.DggFt_TotalSalesCount,
            this.DggFt_GrossProfitRate,
            this.DggFt_TtlGrossProfit,
            this.DggFt_TtlSalesPrice,
            this.DggFt_TtlTotalSalesCount,
            this.DggFt_TtlGrossProfitRate,
            this.line30,
            this.line31,
            this.DggFt_DetailGoodsGanreCode,
            this.DggFt_DetailGoodsGanreName,
            this.DggFt_MonthPureSalesMoney,
            this.DggFt_AnnualPureSalesMoney,
            this.DggFt_MonthGrossProfitOrg,
            this.DggFt_AnnualGrossProfitOrg});
            this.BLGroupCodeFooter.Height = 0.6875F;
            this.BLGroupCodeFooter.KeepTogether = true;
            this.BLGroupCodeFooter.Name = "BLGroupCodeFooter";
            this.BLGroupCodeFooter.Format += new System.EventHandler(this.BLGroupCodeFooter_Format);
            this.BLGroupCodeFooter.BeforePrint += new System.EventHandler(this.DGoodsGanreFooter_BeforePrint);
            // 
            // line17
            // 
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0F;
            this.line17.Left = 0F;
            this.line17.LineWeight = 2F;
            this.line17.Name = "line17";
            this.line17.Top = 0F;
            this.line17.Width = 10.8F;
            this.line17.X1 = 0F;
            this.line17.X2 = 10.8F;
            this.line17.Y1 = 0F;
            this.line17.Y2 = 0F;
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
            this.textBox32.Height = 0.219F;
            this.textBox32.Left = 1.3125F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox32.Text = "グループコード計";
            this.textBox32.Top = 0.04F;
            this.textBox32.Width = 1.3F;
            // 
            // DggFt_GrossProfit
            // 
            this.DggFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfit.DataField = "MonthGrossProfit";
            this.DggFt_GrossProfit.Height = 0.156F;
            this.DggFt_GrossProfit.Left = 7.125F;
            this.DggFt_GrossProfit.MultiLine = false;
            this.DggFt_GrossProfit.Name = "DggFt_GrossProfit";
            this.DggFt_GrossProfit.OutputFormat = resources.GetString("DggFt_GrossProfit.OutputFormat");
            this.DggFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_GrossProfit.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_GrossProfit.Text = "123,456,789";
            this.DggFt_GrossProfit.Top = 0.063F;
            this.DggFt_GrossProfit.Width = 0.7F;
            // 
            // DggFt_SalesPrice
            // 
            this.DggFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.DggFt_SalesPrice.Height = 0.156F;
            this.DggFt_SalesPrice.Left = 6.438F;
            this.DggFt_SalesPrice.MultiLine = false;
            this.DggFt_SalesPrice.Name = "DggFt_SalesPrice";
            this.DggFt_SalesPrice.OutputFormat = resources.GetString("DggFt_SalesPrice.OutputFormat");
            this.DggFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesPrice.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesPrice.Text = "123,456,789";
            this.DggFt_SalesPrice.Top = 0.063F;
            this.DggFt_SalesPrice.Width = 0.7F;
            // 
            // DggFt_TotalSalesCount
            // 
            this.DggFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.DggFt_TotalSalesCount.Height = 0.156F;
            this.DggFt_TotalSalesCount.Left = 5.75F;
            this.DggFt_TotalSalesCount.MultiLine = false;
            this.DggFt_TotalSalesCount.Name = "DggFt_TotalSalesCount";
            this.DggFt_TotalSalesCount.OutputFormat = resources.GetString("DggFt_TotalSalesCount.OutputFormat");
            this.DggFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount.Text = "123,456,789";
            this.DggFt_TotalSalesCount.Top = 0.063F;
            this.DggFt_TotalSalesCount.Width = 0.7F;
            // 
            // DggFt_GrossProfitRate
            // 
            this.DggFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_GrossProfitRate.Height = 0.156F;
            this.DggFt_GrossProfitRate.Left = 7.813F;
            this.DggFt_GrossProfitRate.MultiLine = false;
            this.DggFt_GrossProfitRate.Name = "DggFt_GrossProfitRate";
            this.DggFt_GrossProfitRate.OutputFormat = resources.GetString("DggFt_GrossProfitRate.OutputFormat");
            this.DggFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_GrossProfitRate.Text = "123.00";
            this.DggFt_GrossProfitRate.Top = 0.063F;
            this.DggFt_GrossProfitRate.Width = 0.42F;
            // 
            // DggFt_TtlGrossProfit
            // 
            this.DggFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.DggFt_TtlGrossProfit.Height = 0.156F;
            this.DggFt_TtlGrossProfit.Left = 9.625F;
            this.DggFt_TtlGrossProfit.MultiLine = false;
            this.DggFt_TtlGrossProfit.Name = "DggFt_TtlGrossProfit";
            this.DggFt_TtlGrossProfit.OutputFormat = resources.GetString("DggFt_TtlGrossProfit.OutputFormat");
            this.DggFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TtlGrossProfit.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TtlGrossProfit.Text = "123,456,789";
            this.DggFt_TtlGrossProfit.Top = 0.063F;
            this.DggFt_TtlGrossProfit.Width = 0.7F;
            // 
            // DggFt_TtlSalesPrice
            // 
            this.DggFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.DggFt_TtlSalesPrice.Height = 0.156F;
            this.DggFt_TtlSalesPrice.Left = 8.938F;
            this.DggFt_TtlSalesPrice.MultiLine = false;
            this.DggFt_TtlSalesPrice.Name = "DggFt_TtlSalesPrice";
            this.DggFt_TtlSalesPrice.OutputFormat = resources.GetString("DggFt_TtlSalesPrice.OutputFormat");
            this.DggFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TtlSalesPrice.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TtlSalesPrice.Text = "123,456,789";
            this.DggFt_TtlSalesPrice.Top = 0.063F;
            this.DggFt_TtlSalesPrice.Width = 0.7F;
            // 
            // DggFt_TtlTotalSalesCount
            // 
            this.DggFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.DggFt_TtlTotalSalesCount.Height = 0.156F;
            this.DggFt_TtlTotalSalesCount.Left = 8.25F;
            this.DggFt_TtlTotalSalesCount.MultiLine = false;
            this.DggFt_TtlTotalSalesCount.Name = "DggFt_TtlTotalSalesCount";
            this.DggFt_TtlTotalSalesCount.OutputFormat = resources.GetString("DggFt_TtlTotalSalesCount.OutputFormat");
            this.DggFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TtlTotalSalesCount.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TtlTotalSalesCount.Text = "123,456,789";
            this.DggFt_TtlTotalSalesCount.Top = 0.063F;
            this.DggFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // DggFt_TtlGrossProfitRate
            // 
            this.DggFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlGrossProfitRate.Height = 0.156F;
            this.DggFt_TtlGrossProfitRate.Left = 10.313F;
            this.DggFt_TtlGrossProfitRate.MultiLine = false;
            this.DggFt_TtlGrossProfitRate.Name = "DggFt_TtlGrossProfitRate";
            this.DggFt_TtlGrossProfitRate.OutputFormat = resources.GetString("DggFt_TtlGrossProfitRate.OutputFormat");
            this.DggFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TtlGrossProfitRate.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TtlGrossProfitRate.Text = "123.00";
            this.DggFt_TtlGrossProfitRate.Top = 0.063F;
            this.DggFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line30
            // 
            this.line30.Border.BottomColor = System.Drawing.Color.Black;
            this.line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.LeftColor = System.Drawing.Color.Black;
            this.line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.RightColor = System.Drawing.Color.Black;
            this.line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.TopColor = System.Drawing.Color.Black;
            this.line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Height = 0.125F;
            this.line30.Left = 5.75F;
            this.line30.LineWeight = 1F;
            this.line30.Name = "line30";
            this.line30.Top = 0.0625F;
            this.line30.Width = 0F;
            this.line30.X1 = 5.75F;
            this.line30.X2 = 5.75F;
            this.line30.Y1 = 0.0625F;
            this.line30.Y2 = 0.1875F;
            // 
            // line31
            // 
            this.line31.Border.BottomColor = System.Drawing.Color.Black;
            this.line31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.LeftColor = System.Drawing.Color.Black;
            this.line31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.RightColor = System.Drawing.Color.Black;
            this.line31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.TopColor = System.Drawing.Color.Black;
            this.line31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Height = 0.13F;
            this.line31.Left = 8.25F;
            this.line31.LineWeight = 1F;
            this.line31.Name = "line31";
            this.line31.Top = 0.06F;
            this.line31.Width = 0F;
            this.line31.X1 = 8.25F;
            this.line31.X2 = 8.25F;
            this.line31.Y1 = 0.06F;
            this.line31.Y2 = 0.19F;
            // 
            // DggFt_DetailGoodsGanreCode
            // 
            this.DggFt_DetailGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreCode.DataField = "BLGroupCode";
            this.DggFt_DetailGoodsGanreCode.Height = 0.156F;
            this.DggFt_DetailGoodsGanreCode.Left = 2.688F;
            this.DggFt_DetailGoodsGanreCode.MultiLine = false;
            this.DggFt_DetailGoodsGanreCode.Name = "DggFt_DetailGoodsGanreCode";
            this.DggFt_DetailGoodsGanreCode.OutputFormat = resources.GetString("DggFt_DetailGoodsGanreCode.OutputFormat");
            this.DggFt_DetailGoodsGanreCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_DetailGoodsGanreCode.Text = "12345";
            this.DggFt_DetailGoodsGanreCode.Top = 0.063F;
            this.DggFt_DetailGoodsGanreCode.Width = 0.5F;
            // 
            // DggFt_DetailGoodsGanreName
            // 
            this.DggFt_DetailGoodsGanreName.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreName.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreName.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreName.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_DetailGoodsGanreName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_DetailGoodsGanreName.DataField = "BLGroupKanaName";
            this.DggFt_DetailGoodsGanreName.Height = 0.15625F;
            this.DggFt_DetailGoodsGanreName.Left = 3.25F;
            this.DggFt_DetailGoodsGanreName.MultiLine = false;
            this.DggFt_DetailGoodsGanreName.Name = "DggFt_DetailGoodsGanreName";
            this.DggFt_DetailGoodsGanreName.OutputFormat = resources.GetString("DggFt_DetailGoodsGanreName.OutputFormat");
            this.DggFt_DetailGoodsGanreName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.DggFt_DetailGoodsGanreName.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉ";
            this.DggFt_DetailGoodsGanreName.Top = 0.063F;
            this.DggFt_DetailGoodsGanreName.Width = 1.13F;
            // 
            // DggFt_MonthPureSalesMoney
            // 
            this.DggFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.DggFt_MonthPureSalesMoney.Height = 0.15625F;
            this.DggFt_MonthPureSalesMoney.Left = 6.125F;
            this.DggFt_MonthPureSalesMoney.MultiLine = false;
            this.DggFt_MonthPureSalesMoney.Name = "DggFt_MonthPureSalesMoney";
            this.DggFt_MonthPureSalesMoney.OutputFormat = resources.GetString("DggFt_MonthPureSalesMoney.OutputFormat");
            this.DggFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_MonthPureSalesMoney.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.DggFt_MonthPureSalesMoney.Top = 0.25F;
            this.DggFt_MonthPureSalesMoney.Visible = false;
            this.DggFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // DggFt_AnnualPureSalesMoney
            // 
            this.DggFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.DggFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.DggFt_AnnualPureSalesMoney.Left = 8.625F;
            this.DggFt_AnnualPureSalesMoney.MultiLine = false;
            this.DggFt_AnnualPureSalesMoney.Name = "DggFt_AnnualPureSalesMoney";
            this.DggFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("DggFt_AnnualPureSalesMoney.OutputFormat");
            this.DggFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_AnnualPureSalesMoney.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.DggFt_AnnualPureSalesMoney.Top = 0.25F;
            this.DggFt_AnnualPureSalesMoney.Visible = false;
            this.DggFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // DggFt_MonthGrossProfitOrg
            // 
            this.DggFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.DggFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.DggFt_MonthGrossProfitOrg.Left = 6.875F;
            this.DggFt_MonthGrossProfitOrg.MultiLine = false;
            this.DggFt_MonthGrossProfitOrg.Name = "DggFt_MonthGrossProfitOrg";
            this.DggFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("DggFt_MonthGrossProfitOrg.OutputFormat");
            this.DggFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_MonthGrossProfitOrg.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.DggFt_MonthGrossProfitOrg.Top = 0.25F;
            this.DggFt_MonthGrossProfitOrg.Visible = false;
            this.DggFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // DggFt_AnnualGrossProfitOrg
            // 
            this.DggFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.DggFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.DggFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.DggFt_AnnualGrossProfitOrg.MultiLine = false;
            this.DggFt_AnnualGrossProfitOrg.Name = "DggFt_AnnualGrossProfitOrg";
            this.DggFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("DggFt_AnnualGrossProfitOrg.OutputFormat");
            this.DggFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_AnnualGrossProfitOrg.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.DggFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.DggFt_AnnualGrossProfitOrg.Visible = false;
            this.DggFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // GoodsLGroupHeader
            // 
            this.GoodsLGroupHeader.CanShrink = true;
            this.GoodsLGroupHeader.Height = 0F;
            this.GoodsLGroupHeader.KeepTogether = true;
            this.GoodsLGroupHeader.Name = "GoodsLGroupHeader";
            this.GoodsLGroupHeader.BeforePrint += new System.EventHandler(this.GoodsLGroupHeader_BeforePrint);
            // 
            // GoodsLGroupFooter
            // 
            this.GoodsLGroupFooter.CanShrink = true;
            this.GoodsLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line19,
            this.textBox34,
            this.LggFt_GrossProfit,
            this.LggFt_SalesPrice,
            this.LggFt_TotalSalesCount,
            this.LggFt_GrossProfitRate,
            this.LggFt_TtlGrossProfit,
            this.LggFt_TtlSalesPrice,
            this.LggFt_TtlTotalSalesCount,
            this.LggFt_TtlGrossProfitRate,
            this.line26,
            this.line27,
            this.LggFt_LargeGoodsGanreCode,
            this.LggFt_LargeGoodsGanreName,
            this.LggFt_MonthPureSalesMoney,
            this.LggFt_AnnualPureSalesMoney,
            this.LggFt_MonthGrossProfitOrg,
            this.LggFt_AnnualGrossProfitOrg});
            this.GoodsLGroupFooter.Height = 0.625F;
            this.GoodsLGroupFooter.KeepTogether = true;
            this.GoodsLGroupFooter.Name = "GoodsLGroupFooter";
            this.GoodsLGroupFooter.Format += new System.EventHandler(this.GoodsLGroupFooter_Format);
            this.GoodsLGroupFooter.BeforePrint += new System.EventHandler(this.LGoodsGanreFooter_BeforePrint);
            // 
            // line19
            // 
            this.line19.Border.BottomColor = System.Drawing.Color.Black;
            this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.LeftColor = System.Drawing.Color.Black;
            this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.RightColor = System.Drawing.Color.Black;
            this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.TopColor = System.Drawing.Color.Black;
            this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Height = 0F;
            this.line19.Left = 0F;
            this.line19.LineWeight = 2F;
            this.line19.Name = "line19";
            this.line19.Top = 0F;
            this.line19.Width = 10.8F;
            this.line19.X1 = 0F;
            this.line19.X2 = 10.8F;
            this.line19.Y1 = 0F;
            this.line19.Y2 = 0F;
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
            this.textBox34.Height = 0.219F;
            this.textBox34.Left = 1.313F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox34.Text = "商品大分類計";
            this.textBox34.Top = 0.04F;
            this.textBox34.Width = 1.2F;
            // 
            // LggFt_GrossProfit
            // 
            this.LggFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfit.DataField = "MonthGrossProfit";
            this.LggFt_GrossProfit.Height = 0.156F;
            this.LggFt_GrossProfit.Left = 7.125F;
            this.LggFt_GrossProfit.MultiLine = false;
            this.LggFt_GrossProfit.Name = "LggFt_GrossProfit";
            this.LggFt_GrossProfit.OutputFormat = resources.GetString("LggFt_GrossProfit.OutputFormat");
            this.LggFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_GrossProfit.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_GrossProfit.Text = "123,456,789";
            this.LggFt_GrossProfit.Top = 0.063F;
            this.LggFt_GrossProfit.Width = 0.7F;
            // 
            // LggFt_SalesPrice
            // 
            this.LggFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.LggFt_SalesPrice.Height = 0.156F;
            this.LggFt_SalesPrice.Left = 6.438F;
            this.LggFt_SalesPrice.MultiLine = false;
            this.LggFt_SalesPrice.Name = "LggFt_SalesPrice";
            this.LggFt_SalesPrice.OutputFormat = resources.GetString("LggFt_SalesPrice.OutputFormat");
            this.LggFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesPrice.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesPrice.Text = "123,456,789";
            this.LggFt_SalesPrice.Top = 0.063F;
            this.LggFt_SalesPrice.Width = 0.7F;
            // 
            // LggFt_TotalSalesCount
            // 
            this.LggFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.LggFt_TotalSalesCount.Height = 0.156F;
            this.LggFt_TotalSalesCount.Left = 5.75F;
            this.LggFt_TotalSalesCount.MultiLine = false;
            this.LggFt_TotalSalesCount.Name = "LggFt_TotalSalesCount";
            this.LggFt_TotalSalesCount.OutputFormat = resources.GetString("LggFt_TotalSalesCount.OutputFormat");
            this.LggFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount.Text = "123,456,789";
            this.LggFt_TotalSalesCount.Top = 0.063F;
            this.LggFt_TotalSalesCount.Width = 0.7F;
            // 
            // LggFt_GrossProfitRate
            // 
            this.LggFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GrossProfitRate.Height = 0.156F;
            this.LggFt_GrossProfitRate.Left = 7.813F;
            this.LggFt_GrossProfitRate.MultiLine = false;
            this.LggFt_GrossProfitRate.Name = "LggFt_GrossProfitRate";
            this.LggFt_GrossProfitRate.OutputFormat = resources.GetString("LggFt_GrossProfitRate.OutputFormat");
            this.LggFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_GrossProfitRate.Text = "123.00";
            this.LggFt_GrossProfitRate.Top = 0.063F;
            this.LggFt_GrossProfitRate.Width = 0.42F;
            // 
            // LggFt_TtlGrossProfit
            // 
            this.LggFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.LggFt_TtlGrossProfit.Height = 0.156F;
            this.LggFt_TtlGrossProfit.Left = 9.625F;
            this.LggFt_TtlGrossProfit.MultiLine = false;
            this.LggFt_TtlGrossProfit.Name = "LggFt_TtlGrossProfit";
            this.LggFt_TtlGrossProfit.OutputFormat = resources.GetString("LggFt_TtlGrossProfit.OutputFormat");
            this.LggFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TtlGrossProfit.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TtlGrossProfit.Text = "123,456,789";
            this.LggFt_TtlGrossProfit.Top = 0.063F;
            this.LggFt_TtlGrossProfit.Width = 0.7F;
            // 
            // LggFt_TtlSalesPrice
            // 
            this.LggFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.LggFt_TtlSalesPrice.Height = 0.156F;
            this.LggFt_TtlSalesPrice.Left = 8.938F;
            this.LggFt_TtlSalesPrice.MultiLine = false;
            this.LggFt_TtlSalesPrice.Name = "LggFt_TtlSalesPrice";
            this.LggFt_TtlSalesPrice.OutputFormat = resources.GetString("LggFt_TtlSalesPrice.OutputFormat");
            this.LggFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TtlSalesPrice.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TtlSalesPrice.Text = "123,456,789";
            this.LggFt_TtlSalesPrice.Top = 0.063F;
            this.LggFt_TtlSalesPrice.Width = 0.7F;
            // 
            // LggFt_TtlTotalSalesCount
            // 
            this.LggFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.LggFt_TtlTotalSalesCount.Height = 0.156F;
            this.LggFt_TtlTotalSalesCount.Left = 8.25F;
            this.LggFt_TtlTotalSalesCount.MultiLine = false;
            this.LggFt_TtlTotalSalesCount.Name = "LggFt_TtlTotalSalesCount";
            this.LggFt_TtlTotalSalesCount.OutputFormat = resources.GetString("LggFt_TtlTotalSalesCount.OutputFormat");
            this.LggFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TtlTotalSalesCount.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TtlTotalSalesCount.Text = "123,456,789";
            this.LggFt_TtlTotalSalesCount.Top = 0.063F;
            this.LggFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // LggFt_TtlGrossProfitRate
            // 
            this.LggFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlGrossProfitRate.Height = 0.156F;
            this.LggFt_TtlGrossProfitRate.Left = 10.313F;
            this.LggFt_TtlGrossProfitRate.MultiLine = false;
            this.LggFt_TtlGrossProfitRate.Name = "LggFt_TtlGrossProfitRate";
            this.LggFt_TtlGrossProfitRate.OutputFormat = resources.GetString("LggFt_TtlGrossProfitRate.OutputFormat");
            this.LggFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TtlGrossProfitRate.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TtlGrossProfitRate.Text = "123.00";
            this.LggFt_TtlGrossProfitRate.Top = 0.063F;
            this.LggFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line26
            // 
            this.line26.Border.BottomColor = System.Drawing.Color.Black;
            this.line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.LeftColor = System.Drawing.Color.Black;
            this.line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.RightColor = System.Drawing.Color.Black;
            this.line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.TopColor = System.Drawing.Color.Black;
            this.line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Height = 0.125F;
            this.line26.Left = 5.75F;
            this.line26.LineWeight = 1F;
            this.line26.Name = "line26";
            this.line26.Top = 0.0625F;
            this.line26.Width = 0F;
            this.line26.X1 = 5.75F;
            this.line26.X2 = 5.75F;
            this.line26.Y1 = 0.0625F;
            this.line26.Y2 = 0.1875F;
            // 
            // line27
            // 
            this.line27.Border.BottomColor = System.Drawing.Color.Black;
            this.line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.LeftColor = System.Drawing.Color.Black;
            this.line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.RightColor = System.Drawing.Color.Black;
            this.line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.TopColor = System.Drawing.Color.Black;
            this.line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Height = 0.13F;
            this.line27.Left = 8.25F;
            this.line27.LineWeight = 1F;
            this.line27.Name = "line27";
            this.line27.Top = 0.06F;
            this.line27.Width = 0F;
            this.line27.X1 = 8.25F;
            this.line27.X2 = 8.25F;
            this.line27.Y1 = 0.06F;
            this.line27.Y2 = 0.19F;
            // 
            // LggFt_LargeGoodsGanreCode
            // 
            this.LggFt_LargeGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreCode.DataField = "GoodsLGroup";
            this.LggFt_LargeGoodsGanreCode.Height = 0.15625F;
            this.LggFt_LargeGoodsGanreCode.Left = 2.688F;
            this.LggFt_LargeGoodsGanreCode.MultiLine = false;
            this.LggFt_LargeGoodsGanreCode.Name = "LggFt_LargeGoodsGanreCode";
            this.LggFt_LargeGoodsGanreCode.OutputFormat = resources.GetString("LggFt_LargeGoodsGanreCode.OutputFormat");
            this.LggFt_LargeGoodsGanreCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_LargeGoodsGanreCode.Text = "1234";
            this.LggFt_LargeGoodsGanreCode.Top = 0.063F;
            this.LggFt_LargeGoodsGanreCode.Width = 0.3125F;
            // 
            // LggFt_LargeGoodsGanreName
            // 
            this.LggFt_LargeGoodsGanreName.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreName.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreName.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreName.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_LargeGoodsGanreName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_LargeGoodsGanreName.DataField = "GoodsLGroupName";
            this.LggFt_LargeGoodsGanreName.Height = 0.15625F;
            this.LggFt_LargeGoodsGanreName.Left = 3.25F;
            this.LggFt_LargeGoodsGanreName.MultiLine = false;
            this.LggFt_LargeGoodsGanreName.Name = "LggFt_LargeGoodsGanreName";
            this.LggFt_LargeGoodsGanreName.OutputFormat = resources.GetString("LggFt_LargeGoodsGanreName.OutputFormat");
            this.LggFt_LargeGoodsGanreName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.LggFt_LargeGoodsGanreName.Text = "あいうえおかきくけこ";
            this.LggFt_LargeGoodsGanreName.Top = 0.063F;
            this.LggFt_LargeGoodsGanreName.Width = 1.1875F;
            // 
            // LggFt_MonthPureSalesMoney
            // 
            this.LggFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.LggFt_MonthPureSalesMoney.Height = 0.15625F;
            this.LggFt_MonthPureSalesMoney.Left = 6.125F;
            this.LggFt_MonthPureSalesMoney.MultiLine = false;
            this.LggFt_MonthPureSalesMoney.Name = "LggFt_MonthPureSalesMoney";
            this.LggFt_MonthPureSalesMoney.OutputFormat = resources.GetString("LggFt_MonthPureSalesMoney.OutputFormat");
            this.LggFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_MonthPureSalesMoney.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.LggFt_MonthPureSalesMoney.Top = 0.25F;
            this.LggFt_MonthPureSalesMoney.Visible = false;
            this.LggFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // LggFt_AnnualPureSalesMoney
            // 
            this.LggFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.LggFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.LggFt_AnnualPureSalesMoney.Left = 8.625F;
            this.LggFt_AnnualPureSalesMoney.MultiLine = false;
            this.LggFt_AnnualPureSalesMoney.Name = "LggFt_AnnualPureSalesMoney";
            this.LggFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("LggFt_AnnualPureSalesMoney.OutputFormat");
            this.LggFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_AnnualPureSalesMoney.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.LggFt_AnnualPureSalesMoney.Top = 0.25F;
            this.LggFt_AnnualPureSalesMoney.Visible = false;
            this.LggFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // LggFt_MonthGrossProfitOrg
            // 
            this.LggFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.LggFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.LggFt_MonthGrossProfitOrg.Left = 6.875F;
            this.LggFt_MonthGrossProfitOrg.MultiLine = false;
            this.LggFt_MonthGrossProfitOrg.Name = "LggFt_MonthGrossProfitOrg";
            this.LggFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("LggFt_MonthGrossProfitOrg.OutputFormat");
            this.LggFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_MonthGrossProfitOrg.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.LggFt_MonthGrossProfitOrg.Top = 0.25F;
            this.LggFt_MonthGrossProfitOrg.Visible = false;
            this.LggFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // LggFt_AnnualGrossProfitOrg
            // 
            this.LggFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.LggFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.LggFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.LggFt_AnnualGrossProfitOrg.MultiLine = false;
            this.LggFt_AnnualGrossProfitOrg.Name = "LggFt_AnnualGrossProfitOrg";
            this.LggFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("LggFt_AnnualGrossProfitOrg.OutputFormat");
            this.LggFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_AnnualGrossProfitOrg.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.LggFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.LggFt_AnnualGrossProfitOrg.Visible = false;
            this.LggFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.CanShrink = true;
            this.MakerHeader.Height = 0F;
            this.MakerHeader.KeepTogether = true;
            this.MakerHeader.Name = "MakerHeader";
            this.MakerHeader.BeforePrint += new System.EventHandler(this.MakerHeader_BeforePrint);
            // 
            // MakerFooter
            // 
            this.MakerFooter.CanShrink = true;
            this.MakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line20,
            this.textBox35,
            this.MakFt_GrossProfit,
            this.MakFt_SalesPrice,
            this.MakFt_TotalSalesCount,
            this.MakFt_GrossProfitRate,
            this.MakFt_TtlGrossProfit,
            this.MakFt_TtlSalesPrice,
            this.MakFt_TtlTotalSalesCount,
            this.MakFt_TtlGrossProfitRate,
            this.line24,
            this.line25,
            this.MakFt_GoodsMakerCd,
            this.MakFt_MakerName,
            this.MakFt_MonthPureSalesMoney,
            this.MakFt_AnnualPureSalesMoney,
            this.MakFt_MonthGrossProfitOrg,
            this.MakFt_AnnualGrossProfitOrg});
            this.MakerFooter.Height = 0.625F;
            this.MakerFooter.KeepTogether = true;
            this.MakerFooter.Name = "MakerFooter";
            this.MakerFooter.Format += new System.EventHandler(this.MakerFooter_Format);
            this.MakerFooter.BeforePrint += new System.EventHandler(this.MakerFooter_BeforePrint);
            // 
            // line20
            // 
            this.line20.Border.BottomColor = System.Drawing.Color.Black;
            this.line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.LeftColor = System.Drawing.Color.Black;
            this.line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.RightColor = System.Drawing.Color.Black;
            this.line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.TopColor = System.Drawing.Color.Black;
            this.line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Height = 0F;
            this.line20.Left = 0F;
            this.line20.LineWeight = 2F;
            this.line20.Name = "line20";
            this.line20.Top = 0F;
            this.line20.Width = 10.8F;
            this.line20.X1 = 0F;
            this.line20.X2 = 10.8F;
            this.line20.Y1 = 0F;
            this.line20.Y2 = 0F;
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
            this.textBox35.Height = 0.21875F;
            this.textBox35.Left = 1.313F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox35.Text = "メーカー計";
            this.textBox35.Top = 0.04F;
            this.textBox35.Width = 0.84375F;
            // 
            // MakFt_GrossProfit
            // 
            this.MakFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfit.DataField = "MonthGrossProfit";
            this.MakFt_GrossProfit.Height = 0.156F;
            this.MakFt_GrossProfit.Left = 7.125F;
            this.MakFt_GrossProfit.MultiLine = false;
            this.MakFt_GrossProfit.Name = "MakFt_GrossProfit";
            this.MakFt_GrossProfit.OutputFormat = resources.GetString("MakFt_GrossProfit.OutputFormat");
            this.MakFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GrossProfit.SummaryGroup = "MakerHeader";
            this.MakFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_GrossProfit.Text = "123,456,789";
            this.MakFt_GrossProfit.Top = 0.063F;
            this.MakFt_GrossProfit.Width = 0.7F;
            // 
            // MakFt_SalesPrice
            // 
            this.MakFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.MakFt_SalesPrice.Height = 0.156F;
            this.MakFt_SalesPrice.Left = 6.438F;
            this.MakFt_SalesPrice.MultiLine = false;
            this.MakFt_SalesPrice.Name = "MakFt_SalesPrice";
            this.MakFt_SalesPrice.OutputFormat = resources.GetString("MakFt_SalesPrice.OutputFormat");
            this.MakFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesPrice.SummaryGroup = "MakerHeader";
            this.MakFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesPrice.Text = "123,456,789";
            this.MakFt_SalesPrice.Top = 0.063F;
            this.MakFt_SalesPrice.Width = 0.7F;
            // 
            // MakFt_TotalSalesCount
            // 
            this.MakFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.MakFt_TotalSalesCount.Height = 0.156F;
            this.MakFt_TotalSalesCount.Left = 5.75F;
            this.MakFt_TotalSalesCount.MultiLine = false;
            this.MakFt_TotalSalesCount.Name = "MakFt_TotalSalesCount";
            this.MakFt_TotalSalesCount.OutputFormat = resources.GetString("MakFt_TotalSalesCount.OutputFormat");
            this.MakFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount.Text = "123,456,789";
            this.MakFt_TotalSalesCount.Top = 0.063F;
            this.MakFt_TotalSalesCount.Width = 0.7F;
            // 
            // MakFt_GrossProfitRate
            // 
            this.MakFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossProfitRate.Height = 0.156F;
            this.MakFt_GrossProfitRate.Left = 7.813F;
            this.MakFt_GrossProfitRate.MultiLine = false;
            this.MakFt_GrossProfitRate.Name = "MakFt_GrossProfitRate";
            this.MakFt_GrossProfitRate.OutputFormat = resources.GetString("MakFt_GrossProfitRate.OutputFormat");
            this.MakFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GrossProfitRate.Text = "123.00";
            this.MakFt_GrossProfitRate.Top = 0.063F;
            this.MakFt_GrossProfitRate.Width = 0.42F;
            // 
            // MakFt_TtlGrossProfit
            // 
            this.MakFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.MakFt_TtlGrossProfit.Height = 0.156F;
            this.MakFt_TtlGrossProfit.Left = 9.625F;
            this.MakFt_TtlGrossProfit.MultiLine = false;
            this.MakFt_TtlGrossProfit.Name = "MakFt_TtlGrossProfit";
            this.MakFt_TtlGrossProfit.OutputFormat = resources.GetString("MakFt_TtlGrossProfit.OutputFormat");
            this.MakFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TtlGrossProfit.SummaryGroup = "MakerHeader";
            this.MakFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TtlGrossProfit.Text = "123,456,789";
            this.MakFt_TtlGrossProfit.Top = 0.063F;
            this.MakFt_TtlGrossProfit.Width = 0.7F;
            // 
            // MakFt_TtlSalesPrice
            // 
            this.MakFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.MakFt_TtlSalesPrice.Height = 0.156F;
            this.MakFt_TtlSalesPrice.Left = 8.938F;
            this.MakFt_TtlSalesPrice.MultiLine = false;
            this.MakFt_TtlSalesPrice.Name = "MakFt_TtlSalesPrice";
            this.MakFt_TtlSalesPrice.OutputFormat = resources.GetString("MakFt_TtlSalesPrice.OutputFormat");
            this.MakFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TtlSalesPrice.SummaryGroup = "MakerHeader";
            this.MakFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TtlSalesPrice.Text = "123,456,789";
            this.MakFt_TtlSalesPrice.Top = 0.063F;
            this.MakFt_TtlSalesPrice.Width = 0.7F;
            // 
            // MakFt_TtlTotalSalesCount
            // 
            this.MakFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.MakFt_TtlTotalSalesCount.Height = 0.156F;
            this.MakFt_TtlTotalSalesCount.Left = 8.25F;
            this.MakFt_TtlTotalSalesCount.MultiLine = false;
            this.MakFt_TtlTotalSalesCount.Name = "MakFt_TtlTotalSalesCount";
            this.MakFt_TtlTotalSalesCount.OutputFormat = resources.GetString("MakFt_TtlTotalSalesCount.OutputFormat");
            this.MakFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TtlTotalSalesCount.SummaryGroup = "MakerHeader";
            this.MakFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TtlTotalSalesCount.Text = "123,456,789";
            this.MakFt_TtlTotalSalesCount.Top = 0.063F;
            this.MakFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // MakFt_TtlGrossProfitRate
            // 
            this.MakFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlGrossProfitRate.Height = 0.156F;
            this.MakFt_TtlGrossProfitRate.Left = 10.313F;
            this.MakFt_TtlGrossProfitRate.MultiLine = false;
            this.MakFt_TtlGrossProfitRate.Name = "MakFt_TtlGrossProfitRate";
            this.MakFt_TtlGrossProfitRate.OutputFormat = resources.GetString("MakFt_TtlGrossProfitRate.OutputFormat");
            this.MakFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TtlGrossProfitRate.SummaryGroup = "MakerHeader";
            this.MakFt_TtlGrossProfitRate.Text = "123.00";
            this.MakFt_TtlGrossProfitRate.Top = 0.063F;
            this.MakFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line24
            // 
            this.line24.Border.BottomColor = System.Drawing.Color.Black;
            this.line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.LeftColor = System.Drawing.Color.Black;
            this.line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.RightColor = System.Drawing.Color.Black;
            this.line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.TopColor = System.Drawing.Color.Black;
            this.line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Height = 0.125F;
            this.line24.Left = 5.75F;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 0.0625F;
            this.line24.Width = 0F;
            this.line24.X1 = 5.75F;
            this.line24.X2 = 5.75F;
            this.line24.Y1 = 0.0625F;
            this.line24.Y2 = 0.1875F;
            // 
            // line25
            // 
            this.line25.Border.BottomColor = System.Drawing.Color.Black;
            this.line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.LeftColor = System.Drawing.Color.Black;
            this.line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.RightColor = System.Drawing.Color.Black;
            this.line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.TopColor = System.Drawing.Color.Black;
            this.line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Height = 0.13F;
            this.line25.Left = 8.25F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 0.06F;
            this.line25.Width = 0F;
            this.line25.X1 = 8.25F;
            this.line25.X2 = 8.25F;
            this.line25.Y1 = 0.06F;
            this.line25.Y2 = 0.19F;
            // 
            // MakFt_GoodsMakerCd
            // 
            this.MakFt_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GoodsMakerCd.DataField = "GoodsMakerCd";
            this.MakFt_GoodsMakerCd.Height = 0.15625F;
            this.MakFt_GoodsMakerCd.Left = 2.6875F;
            this.MakFt_GoodsMakerCd.MultiLine = false;
            this.MakFt_GoodsMakerCd.Name = "MakFt_GoodsMakerCd";
            this.MakFt_GoodsMakerCd.OutputFormat = resources.GetString("MakFt_GoodsMakerCd.OutputFormat");
            this.MakFt_GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GoodsMakerCd.Text = "1234";
            this.MakFt_GoodsMakerCd.Top = 0.0625F;
            this.MakFt_GoodsMakerCd.Width = 0.375F;
            // 
            // MakFt_MakerName
            // 
            this.MakFt_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MakerName.DataField = "MakerShortName";
            this.MakFt_MakerName.Height = 0.15625F;
            this.MakFt_MakerName.Left = 3.25F;
            this.MakFt_MakerName.MultiLine = false;
            this.MakFt_MakerName.Name = "MakFt_MakerName";
            this.MakFt_MakerName.OutputFormat = resources.GetString("MakFt_MakerName.OutputFormat");
            this.MakFt_MakerName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.MakFt_MakerName.Text = "あいうえおかきくけこ";
            this.MakFt_MakerName.Top = 0.063F;
            this.MakFt_MakerName.Width = 1.1875F;
            // 
            // MakFt_MonthPureSalesMoney
            // 
            this.MakFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.MakFt_MonthPureSalesMoney.Height = 0.15625F;
            this.MakFt_MonthPureSalesMoney.Left = 6.125F;
            this.MakFt_MonthPureSalesMoney.MultiLine = false;
            this.MakFt_MonthPureSalesMoney.Name = "MakFt_MonthPureSalesMoney";
            this.MakFt_MonthPureSalesMoney.OutputFormat = resources.GetString("MakFt_MonthPureSalesMoney.OutputFormat");
            this.MakFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_MonthPureSalesMoney.SummaryGroup = "MakerHeader";
            this.MakFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.MakFt_MonthPureSalesMoney.Top = 0.25F;
            this.MakFt_MonthPureSalesMoney.Visible = false;
            this.MakFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // MakFt_AnnualPureSalesMoney
            // 
            this.MakFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.MakFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.MakFt_AnnualPureSalesMoney.Left = 8.625F;
            this.MakFt_AnnualPureSalesMoney.MultiLine = false;
            this.MakFt_AnnualPureSalesMoney.Name = "MakFt_AnnualPureSalesMoney";
            this.MakFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("MakFt_AnnualPureSalesMoney.OutputFormat");
            this.MakFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_AnnualPureSalesMoney.SummaryGroup = "MakerHeader";
            this.MakFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.MakFt_AnnualPureSalesMoney.Top = 0.25F;
            this.MakFt_AnnualPureSalesMoney.Visible = false;
            this.MakFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // MakFt_MonthGrossProfitOrg
            // 
            this.MakFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.MakFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.MakFt_MonthGrossProfitOrg.Left = 6.875F;
            this.MakFt_MonthGrossProfitOrg.MultiLine = false;
            this.MakFt_MonthGrossProfitOrg.Name = "MakFt_MonthGrossProfitOrg";
            this.MakFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("MakFt_MonthGrossProfitOrg.OutputFormat");
            this.MakFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_MonthGrossProfitOrg.SummaryGroup = "MakerHeader";
            this.MakFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.MakFt_MonthGrossProfitOrg.Top = 0.25F;
            this.MakFt_MonthGrossProfitOrg.Visible = false;
            this.MakFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // MakFt_AnnualGrossProfitOrg
            // 
            this.MakFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.MakFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.MakFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.MakFt_AnnualGrossProfitOrg.MultiLine = false;
            this.MakFt_AnnualGrossProfitOrg.Name = "MakFt_AnnualGrossProfitOrg";
            this.MakFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("MakFt_AnnualGrossProfitOrg.OutputFormat");
            this.MakFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_AnnualGrossProfitOrg.SummaryGroup = "MakerHeader";
            this.MakFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.MakFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.MakFt_AnnualGrossProfitOrg.Visible = false;
            this.MakFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // EmployeeHeader
            // 
            this.EmployeeHeader.CanShrink = true;
            this.EmployeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.EmpHd_line1,
            this.EmpHd_line2,
            this.EmpHd_AddUpSecCode,
            this.EmpHd_SectionGuideNm,
            this.EmpHd_EmployeeCode,
            this.EmpHd_EmployeeName,
            this.EmpHd_SectionTitle,
            this.EmpHd_EmployeeTitle,
            this.EmpHd_line3});
            this.EmployeeHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.EmployeeHeader.Height = 0.1944444F;
            this.EmployeeHeader.KeepTogether = true;
            this.EmployeeHeader.Name = "EmployeeHeader";
            this.EmployeeHeader.AfterPrint += new System.EventHandler(this.EmployeeHeader_AfterPrint);
            this.EmployeeHeader.BeforePrint += new System.EventHandler(this.EmployeeHeader_BeforePrint);
            // 
            // EmpHd_line1
            // 
            this.EmpHd_line1.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line1.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line1.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line1.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line1.Height = 0.095F;
            this.EmpHd_line1.Left = 5.75F;
            this.EmpHd_line1.LineWeight = 1F;
            this.EmpHd_line1.Name = "EmpHd_line1";
            this.EmpHd_line1.Top = 0.03F;
            this.EmpHd_line1.Width = 0F;
            this.EmpHd_line1.X1 = 5.75F;
            this.EmpHd_line1.X2 = 5.75F;
            this.EmpHd_line1.Y1 = 0.03F;
            this.EmpHd_line1.Y2 = 0.125F;
            // 
            // EmpHd_line2
            // 
            this.EmpHd_line2.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line2.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line2.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line2.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line2.Height = 0.09999999F;
            this.EmpHd_line2.Left = 8.25F;
            this.EmpHd_line2.LineWeight = 1F;
            this.EmpHd_line2.Name = "EmpHd_line2";
            this.EmpHd_line2.Top = 0.03F;
            this.EmpHd_line2.Width = 0F;
            this.EmpHd_line2.X1 = 8.25F;
            this.EmpHd_line2.X2 = 8.25F;
            this.EmpHd_line2.Y1 = 0.03F;
            this.EmpHd_line2.Y2 = 0.13F;
            // 
            // EmpHd_AddUpSecCode
            // 
            this.EmpHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.EmpHd_AddUpSecCode.Height = 0.156F;
            this.EmpHd_AddUpSecCode.Left = 0.563F;
            this.EmpHd_AddUpSecCode.MultiLine = false;
            this.EmpHd_AddUpSecCode.Name = "EmpHd_AddUpSecCode";
            this.EmpHd_AddUpSecCode.OutputFormat = resources.GetString("EmpHd_AddUpSecCode.OutputFormat");
            this.EmpHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.EmpHd_AddUpSecCode.Text = "12";
            this.EmpHd_AddUpSecCode.Top = 0.031F;
            this.EmpHd_AddUpSecCode.Width = 0.15F;
            // 
            // EmpHd_SectionGuideNm
            // 
            this.EmpHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionGuideNm.DataField = "CompanyName1";
            this.EmpHd_SectionGuideNm.Height = 0.15625F;
            this.EmpHd_SectionGuideNm.Left = 0.72F;
            this.EmpHd_SectionGuideNm.MultiLine = false;
            this.EmpHd_SectionGuideNm.Name = "EmpHd_SectionGuideNm";
            this.EmpHd_SectionGuideNm.OutputFormat = resources.GetString("EmpHd_SectionGuideNm.OutputFormat");
            this.EmpHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.EmpHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.EmpHd_SectionGuideNm.Top = 0.031F;
            this.EmpHd_SectionGuideNm.Width = 1.1875F;
            // 
            // EmpHd_EmployeeCode
            // 
            this.EmpHd_EmployeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.DataField = "EmployeeCode";
            this.EmpHd_EmployeeCode.Height = 0.156F;
            this.EmpHd_EmployeeCode.Left = 2.375F;
            this.EmpHd_EmployeeCode.MultiLine = false;
            this.EmpHd_EmployeeCode.Name = "EmpHd_EmployeeCode";
            this.EmpHd_EmployeeCode.OutputFormat = resources.GetString("EmpHd_EmployeeCode.OutputFormat");
            this.EmpHd_EmployeeCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.EmpHd_EmployeeCode.Text = "1234";
            this.EmpHd_EmployeeCode.Top = 0.031F;
            this.EmpHd_EmployeeCode.Width = 0.3F;
            // 
            // EmpHd_EmployeeName
            // 
            this.EmpHd_EmployeeName.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.DataField = "Name";
            this.EmpHd_EmployeeName.Height = 0.15625F;
            this.EmpHd_EmployeeName.Left = 2.688F;
            this.EmpHd_EmployeeName.MultiLine = false;
            this.EmpHd_EmployeeName.Name = "EmpHd_EmployeeName";
            this.EmpHd_EmployeeName.OutputFormat = resources.GetString("EmpHd_EmployeeName.OutputFormat");
            this.EmpHd_EmployeeName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.EmpHd_EmployeeName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.EmpHd_EmployeeName.Top = 0.031F;
            this.EmpHd_EmployeeName.Width = 1.1875F;
            // 
            // EmpHd_SectionTitle
            // 
            this.EmpHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Height = 0.156F;
            this.EmpHd_SectionTitle.Left = 0.25F;
            this.EmpHd_SectionTitle.MultiLine = false;
            this.EmpHd_SectionTitle.Name = "EmpHd_SectionTitle";
            this.EmpHd_SectionTitle.OutputFormat = resources.GetString("EmpHd_SectionTitle.OutputFormat");
            this.EmpHd_SectionTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.EmpHd_SectionTitle.Text = "拠点";
            this.EmpHd_SectionTitle.Top = 0.031F;
            this.EmpHd_SectionTitle.Width = 0.3F;
            // 
            // EmpHd_EmployeeTitle
            // 
            this.EmpHd_EmployeeTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Height = 0.156F;
            this.EmpHd_EmployeeTitle.Left = 1.98F;
            this.EmpHd_EmployeeTitle.MultiLine = false;
            this.EmpHd_EmployeeTitle.Name = "EmpHd_EmployeeTitle";
            this.EmpHd_EmployeeTitle.OutputFormat = resources.GetString("EmpHd_EmployeeTitle.OutputFormat");
            this.EmpHd_EmployeeTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.EmpHd_EmployeeTitle.Text = "担当者";
            this.EmpHd_EmployeeTitle.Top = 0.031F;
            this.EmpHd_EmployeeTitle.Width = 0.4F;
            // 
            // EmpHd_line3
            // 
            this.EmpHd_line3.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line3.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line3.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line3.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_line3.Height = 0F;
            this.EmpHd_line3.Left = 0F;
            this.EmpHd_line3.LineWeight = 2F;
            this.EmpHd_line3.Name = "EmpHd_line3";
            this.EmpHd_line3.Top = 0F;
            this.EmpHd_line3.Width = 10.8F;
            this.EmpHd_line3.X1 = 0F;
            this.EmpHd_line3.X2 = 10.8F;
            this.EmpHd_line3.Y1 = 0F;
            this.EmpHd_line3.Y2 = 0F;
            // 
            // EmployeeFooter
            // 
            this.EmployeeFooter.CanShrink = true;
            this.EmployeeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line21,
            this.textBox36,
            this.EmpFt_GrossProfit,
            this.EmpFt_SalesPrice,
            this.EmpFt_TotalSalesCount,
            this.EmpFt_GrossProfitRate,
            this.EmpFt_TtlGrossProfit,
            this.EmpFt_TtlSalesPrice,
            this.EmpFt_TtlTotalSalesCount,
            this.EmpFt_TtlGrossProfitRate,
            this.line22,
            this.line23,
            this.EmpFt_EmployeeCode,
            this.EmpFt_EmployeeName,
            this.EmpFt_MonthPureSalesMoney,
            this.EmpFt_AnnualPureSalesMoney,
            this.EmpFt_MonthGrossProfitOrg,
            this.EmpFt_AnnualGrossProfitOrg});
            this.EmployeeFooter.Height = 0.625F;
            this.EmployeeFooter.KeepTogether = true;
            this.EmployeeFooter.Name = "EmployeeFooter";
            this.EmployeeFooter.Format += new System.EventHandler(this.EmployeeFooter_Format);
            this.EmployeeFooter.BeforePrint += new System.EventHandler(this.EmployeeFooter_BeforePrint);
            // 
            // line21
            // 
            this.line21.Border.BottomColor = System.Drawing.Color.Black;
            this.line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.LeftColor = System.Drawing.Color.Black;
            this.line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.RightColor = System.Drawing.Color.Black;
            this.line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.TopColor = System.Drawing.Color.Black;
            this.line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Height = 0F;
            this.line21.Left = 0F;
            this.line21.LineWeight = 2F;
            this.line21.Name = "line21";
            this.line21.Top = 0F;
            this.line21.Width = 10.8F;
            this.line21.X1 = 0F;
            this.line21.X2 = 10.8F;
            this.line21.Y1 = 0F;
            this.line21.Y2 = 0F;
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
            this.textBox36.Height = 0.21875F;
            this.textBox36.Left = 1.313F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox36.Text = "担当者計";
            this.textBox36.Top = 0.04F;
            this.textBox36.Width = 0.65625F;
            // 
            // EmpFt_GrossProfit
            // 
            this.EmpFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfit.DataField = "MonthGrossProfit";
            this.EmpFt_GrossProfit.Height = 0.156F;
            this.EmpFt_GrossProfit.Left = 7.125F;
            this.EmpFt_GrossProfit.MultiLine = false;
            this.EmpFt_GrossProfit.Name = "EmpFt_GrossProfit";
            this.EmpFt_GrossProfit.OutputFormat = resources.GetString("EmpFt_GrossProfit.OutputFormat");
            this.EmpFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_GrossProfit.SummaryGroup = "EmployeeHeader";
            this.EmpFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_GrossProfit.Text = "123,456,789";
            this.EmpFt_GrossProfit.Top = 0.063F;
            this.EmpFt_GrossProfit.Width = 0.7F;
            // 
            // EmpFt_SalesPrice
            // 
            this.EmpFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.EmpFt_SalesPrice.Height = 0.156F;
            this.EmpFt_SalesPrice.Left = 6.438F;
            this.EmpFt_SalesPrice.MultiLine = false;
            this.EmpFt_SalesPrice.Name = "EmpFt_SalesPrice";
            this.EmpFt_SalesPrice.OutputFormat = resources.GetString("EmpFt_SalesPrice.OutputFormat");
            this.EmpFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesPrice.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesPrice.Text = "123,456,789";
            this.EmpFt_SalesPrice.Top = 0.063F;
            this.EmpFt_SalesPrice.Width = 0.7F;
            // 
            // EmpFt_TotalSalesCount
            // 
            this.EmpFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.EmpFt_TotalSalesCount.Height = 0.156F;
            this.EmpFt_TotalSalesCount.Left = 5.75F;
            this.EmpFt_TotalSalesCount.MultiLine = false;
            this.EmpFt_TotalSalesCount.Name = "EmpFt_TotalSalesCount";
            this.EmpFt_TotalSalesCount.OutputFormat = resources.GetString("EmpFt_TotalSalesCount.OutputFormat");
            this.EmpFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount.Text = "123,456,789";
            this.EmpFt_TotalSalesCount.Top = 0.063F;
            this.EmpFt_TotalSalesCount.Width = 0.7F;
            // 
            // EmpFt_GrossProfitRate
            // 
            this.EmpFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_GrossProfitRate.Height = 0.156F;
            this.EmpFt_GrossProfitRate.Left = 7.813F;
            this.EmpFt_GrossProfitRate.MultiLine = false;
            this.EmpFt_GrossProfitRate.Name = "EmpFt_GrossProfitRate";
            this.EmpFt_GrossProfitRate.OutputFormat = resources.GetString("EmpFt_GrossProfitRate.OutputFormat");
            this.EmpFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_GrossProfitRate.Text = "123.00";
            this.EmpFt_GrossProfitRate.Top = 0.063F;
            this.EmpFt_GrossProfitRate.Width = 0.42F;
            // 
            // EmpFt_TtlGrossProfit
            // 
            this.EmpFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.EmpFt_TtlGrossProfit.Height = 0.156F;
            this.EmpFt_TtlGrossProfit.Left = 9.625F;
            this.EmpFt_TtlGrossProfit.MultiLine = false;
            this.EmpFt_TtlGrossProfit.Name = "EmpFt_TtlGrossProfit";
            this.EmpFt_TtlGrossProfit.OutputFormat = resources.GetString("EmpFt_TtlGrossProfit.OutputFormat");
            this.EmpFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TtlGrossProfit.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TtlGrossProfit.Text = "123,456,789";
            this.EmpFt_TtlGrossProfit.Top = 0.063F;
            this.EmpFt_TtlGrossProfit.Width = 0.7F;
            // 
            // EmpFt_TtlSalesPrice
            // 
            this.EmpFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.EmpFt_TtlSalesPrice.Height = 0.156F;
            this.EmpFt_TtlSalesPrice.Left = 8.938F;
            this.EmpFt_TtlSalesPrice.MultiLine = false;
            this.EmpFt_TtlSalesPrice.Name = "EmpFt_TtlSalesPrice";
            this.EmpFt_TtlSalesPrice.OutputFormat = resources.GetString("EmpFt_TtlSalesPrice.OutputFormat");
            this.EmpFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TtlSalesPrice.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TtlSalesPrice.Text = "123,456,789";
            this.EmpFt_TtlSalesPrice.Top = 0.063F;
            this.EmpFt_TtlSalesPrice.Width = 0.7F;
            // 
            // EmpFt_TtlTotalSalesCount
            // 
            this.EmpFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.EmpFt_TtlTotalSalesCount.Height = 0.156F;
            this.EmpFt_TtlTotalSalesCount.Left = 8.25F;
            this.EmpFt_TtlTotalSalesCount.MultiLine = false;
            this.EmpFt_TtlTotalSalesCount.Name = "EmpFt_TtlTotalSalesCount";
            this.EmpFt_TtlTotalSalesCount.OutputFormat = resources.GetString("EmpFt_TtlTotalSalesCount.OutputFormat");
            this.EmpFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TtlTotalSalesCount.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TtlTotalSalesCount.Text = "123,456,789";
            this.EmpFt_TtlTotalSalesCount.Top = 0.063F;
            this.EmpFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // EmpFt_TtlGrossProfitRate
            // 
            this.EmpFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlGrossProfitRate.Height = 0.156F;
            this.EmpFt_TtlGrossProfitRate.Left = 10.313F;
            this.EmpFt_TtlGrossProfitRate.MultiLine = false;
            this.EmpFt_TtlGrossProfitRate.Name = "EmpFt_TtlGrossProfitRate";
            this.EmpFt_TtlGrossProfitRate.OutputFormat = resources.GetString("EmpFt_TtlGrossProfitRate.OutputFormat");
            this.EmpFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TtlGrossProfitRate.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TtlGrossProfitRate.Text = "123.00";
            this.EmpFt_TtlGrossProfitRate.Top = 0.063F;
            this.EmpFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line22
            // 
            this.line22.Border.BottomColor = System.Drawing.Color.Black;
            this.line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.LeftColor = System.Drawing.Color.Black;
            this.line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.RightColor = System.Drawing.Color.Black;
            this.line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.TopColor = System.Drawing.Color.Black;
            this.line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Height = 0.125F;
            this.line22.Left = 5.75F;
            this.line22.LineWeight = 1F;
            this.line22.Name = "line22";
            this.line22.Top = 0.0625F;
            this.line22.Width = 0F;
            this.line22.X1 = 5.75F;
            this.line22.X2 = 5.75F;
            this.line22.Y1 = 0.0625F;
            this.line22.Y2 = 0.1875F;
            // 
            // line23
            // 
            this.line23.Border.BottomColor = System.Drawing.Color.Black;
            this.line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.LeftColor = System.Drawing.Color.Black;
            this.line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.RightColor = System.Drawing.Color.Black;
            this.line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.TopColor = System.Drawing.Color.Black;
            this.line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Height = 0.13F;
            this.line23.Left = 8.25F;
            this.line23.LineWeight = 1F;
            this.line23.Name = "line23";
            this.line23.Top = 0.06F;
            this.line23.Width = 0F;
            this.line23.X1 = 8.25F;
            this.line23.X2 = 8.25F;
            this.line23.Y1 = 0.06F;
            this.line23.Y2 = 0.19F;
            // 
            // EmpFt_EmployeeCode
            // 
            this.EmpFt_EmployeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeCode.DataField = "EmployeeCode";
            this.EmpFt_EmployeeCode.Height = 0.15625F;
            this.EmpFt_EmployeeCode.Left = 2.6875F;
            this.EmpFt_EmployeeCode.MultiLine = false;
            this.EmpFt_EmployeeCode.Name = "EmpFt_EmployeeCode";
            this.EmpFt_EmployeeCode.OutputFormat = resources.GetString("EmpFt_EmployeeCode.OutputFormat");
            this.EmpFt_EmployeeCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_EmployeeCode.Text = "1234";
            this.EmpFt_EmployeeCode.Top = 0.0625F;
            this.EmpFt_EmployeeCode.Width = 0.53125F;
            // 
            // EmpFt_EmployeeName
            // 
            this.EmpFt_EmployeeName.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeName.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeName.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeName.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_EmployeeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_EmployeeName.DataField = "Name";
            this.EmpFt_EmployeeName.Height = 0.15625F;
            this.EmpFt_EmployeeName.Left = 3.25F;
            this.EmpFt_EmployeeName.MultiLine = false;
            this.EmpFt_EmployeeName.Name = "EmpFt_EmployeeName";
            this.EmpFt_EmployeeName.OutputFormat = resources.GetString("EmpFt_EmployeeName.OutputFormat");
            this.EmpFt_EmployeeName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.EmpFt_EmployeeName.Text = "あいうえおかきくけこ";
            this.EmpFt_EmployeeName.Top = 0.063F;
            this.EmpFt_EmployeeName.Width = 1.1875F;
            // 
            // EmpFt_MonthPureSalesMoney
            // 
            this.EmpFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.EmpFt_MonthPureSalesMoney.Height = 0.15625F;
            this.EmpFt_MonthPureSalesMoney.Left = 6.125F;
            this.EmpFt_MonthPureSalesMoney.MultiLine = false;
            this.EmpFt_MonthPureSalesMoney.Name = "EmpFt_MonthPureSalesMoney";
            this.EmpFt_MonthPureSalesMoney.OutputFormat = resources.GetString("EmpFt_MonthPureSalesMoney.OutputFormat");
            this.EmpFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_MonthPureSalesMoney.SummaryGroup = "EmployeeHeader";
            this.EmpFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.EmpFt_MonthPureSalesMoney.Top = 0.25F;
            this.EmpFt_MonthPureSalesMoney.Visible = false;
            this.EmpFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // EmpFt_AnnualPureSalesMoney
            // 
            this.EmpFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.EmpFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.EmpFt_AnnualPureSalesMoney.Left = 8.625F;
            this.EmpFt_AnnualPureSalesMoney.MultiLine = false;
            this.EmpFt_AnnualPureSalesMoney.Name = "EmpFt_AnnualPureSalesMoney";
            this.EmpFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("EmpFt_AnnualPureSalesMoney.OutputFormat");
            this.EmpFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_AnnualPureSalesMoney.SummaryGroup = "EmployeeHeader";
            this.EmpFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.EmpFt_AnnualPureSalesMoney.Top = 0.25F;
            this.EmpFt_AnnualPureSalesMoney.Visible = false;
            this.EmpFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // EmpFt_MonthGrossProfitOrg
            // 
            this.EmpFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.EmpFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.EmpFt_MonthGrossProfitOrg.Left = 6.875F;
            this.EmpFt_MonthGrossProfitOrg.MultiLine = false;
            this.EmpFt_MonthGrossProfitOrg.Name = "EmpFt_MonthGrossProfitOrg";
            this.EmpFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("EmpFt_MonthGrossProfitOrg.OutputFormat");
            this.EmpFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_MonthGrossProfitOrg.SummaryGroup = "EmployeeHeader";
            this.EmpFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.EmpFt_MonthGrossProfitOrg.Top = 0.25F;
            this.EmpFt_MonthGrossProfitOrg.Visible = false;
            this.EmpFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // EmpFt_AnnualGrossProfitOrg
            // 
            this.EmpFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.EmpFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.EmpFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.EmpFt_AnnualGrossProfitOrg.MultiLine = false;
            this.EmpFt_AnnualGrossProfitOrg.Name = "EmpFt_AnnualGrossProfitOrg";
            this.EmpFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("EmpFt_AnnualGrossProfitOrg.OutputFormat");
            this.EmpFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_AnnualGrossProfitOrg.SummaryGroup = "EmployeeHeader";
            this.EmpFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.EmpFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.EmpFt_AnnualGrossProfitOrg.Visible = false;
            this.EmpFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarHd_line1,
            this.WarHd_line2,
            this.WarHd_AddUpSecCode,
            this.WarHd_SectionGuideNm,
            this.WarHd_SectionTitle,
            this.WarHd_WarehouseCode,
            this.WarHd_WarehouseName,
            this.WarHd_WarehouseTitle,
            this.WarHd_line3});
            this.WarehouseHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.WarehouseHeader.Height = 0.28125F;
            this.WarehouseHeader.KeepTogether = true;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.AfterPrint += new System.EventHandler(this.WarehouseHeader_AfterPrint);
            this.WarehouseHeader.BeforePrint += new System.EventHandler(this.WarehouseHeader_BeforePrint);
            // 
            // WarHd_line1
            // 
            this.WarHd_line1.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line1.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line1.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line1.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line1.Height = 0.095F;
            this.WarHd_line1.Left = 5.75F;
            this.WarHd_line1.LineWeight = 1F;
            this.WarHd_line1.Name = "WarHd_line1";
            this.WarHd_line1.Top = 0.03F;
            this.WarHd_line1.Width = 0F;
            this.WarHd_line1.X1 = 5.75F;
            this.WarHd_line1.X2 = 5.75F;
            this.WarHd_line1.Y1 = 0.03F;
            this.WarHd_line1.Y2 = 0.125F;
            // 
            // WarHd_line2
            // 
            this.WarHd_line2.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line2.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line2.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line2.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line2.Height = 0.09999999F;
            this.WarHd_line2.Left = 8.25F;
            this.WarHd_line2.LineWeight = 1F;
            this.WarHd_line2.Name = "WarHd_line2";
            this.WarHd_line2.Top = 0.03F;
            this.WarHd_line2.Width = 0F;
            this.WarHd_line2.X1 = 8.25F;
            this.WarHd_line2.X2 = 8.25F;
            this.WarHd_line2.Y1 = 0.03F;
            this.WarHd_line2.Y2 = 0.13F;
            // 
            // WarHd_AddUpSecCode
            // 
            this.WarHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.WarHd_AddUpSecCode.Height = 0.156F;
            this.WarHd_AddUpSecCode.Left = 0.563F;
            this.WarHd_AddUpSecCode.MultiLine = false;
            this.WarHd_AddUpSecCode.Name = "WarHd_AddUpSecCode";
            this.WarHd_AddUpSecCode.OutputFormat = resources.GetString("WarHd_AddUpSecCode.OutputFormat");
            this.WarHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.WarHd_AddUpSecCode.Text = "12";
            this.WarHd_AddUpSecCode.Top = 0.031F;
            this.WarHd_AddUpSecCode.Width = 0.15F;
            // 
            // WarHd_SectionGuideNm
            // 
            this.WarHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionGuideNm.DataField = "CompanyName1";
            this.WarHd_SectionGuideNm.Height = 0.15625F;
            this.WarHd_SectionGuideNm.Left = 0.72F;
            this.WarHd_SectionGuideNm.MultiLine = false;
            this.WarHd_SectionGuideNm.Name = "WarHd_SectionGuideNm";
            this.WarHd_SectionGuideNm.OutputFormat = resources.GetString("WarHd_SectionGuideNm.OutputFormat");
            this.WarHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.WarHd_SectionGuideNm.Top = 0.031F;
            this.WarHd_SectionGuideNm.Width = 1.1875F;
            // 
            // WarHd_SectionTitle
            // 
            this.WarHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_SectionTitle.Height = 0.156F;
            this.WarHd_SectionTitle.Left = 0.25F;
            this.WarHd_SectionTitle.MultiLine = false;
            this.WarHd_SectionTitle.Name = "WarHd_SectionTitle";
            this.WarHd_SectionTitle.OutputFormat = resources.GetString("WarHd_SectionTitle.OutputFormat");
            this.WarHd_SectionTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.WarHd_SectionTitle.Text = "拠点";
            this.WarHd_SectionTitle.Top = 0.031F;
            this.WarHd_SectionTitle.Width = 0.3F;
            // 
            // WarHd_WarehouseCode
            // 
            this.WarHd_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseCode.DataField = "WarehouseCode";
            this.WarHd_WarehouseCode.Height = 0.156F;
            this.WarHd_WarehouseCode.Left = 2.5F;
            this.WarHd_WarehouseCode.MultiLine = false;
            this.WarHd_WarehouseCode.Name = "WarHd_WarehouseCode";
            this.WarHd_WarehouseCode.OutputFormat = resources.GetString("WarHd_WarehouseCode.OutputFormat");
            this.WarHd_WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.WarHd_WarehouseCode.Text = "1234";
            this.WarHd_WarehouseCode.Top = 0.031F;
            this.WarHd_WarehouseCode.Width = 0.3F;
            // 
            // WarHd_WarehouseName
            // 
            this.WarHd_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseName.DataField = "WarehouseName";
            this.WarHd_WarehouseName.Height = 0.15625F;
            this.WarHd_WarehouseName.Left = 2.813F;
            this.WarHd_WarehouseName.MultiLine = false;
            this.WarHd_WarehouseName.Name = "WarHd_WarehouseName";
            this.WarHd_WarehouseName.OutputFormat = resources.GetString("WarHd_WarehouseName.OutputFormat");
            this.WarHd_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarHd_WarehouseName.Text = "あいうえおかきくけこ";
            this.WarHd_WarehouseName.Top = 0.031F;
            this.WarHd_WarehouseName.Width = 1.1875F;
            // 
            // WarHd_WarehouseTitle
            // 
            this.WarHd_WarehouseTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseTitle.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseTitle.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_WarehouseTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_WarehouseTitle.Height = 0.156F;
            this.WarHd_WarehouseTitle.Left = 2.188F;
            this.WarHd_WarehouseTitle.MultiLine = false;
            this.WarHd_WarehouseTitle.Name = "WarHd_WarehouseTitle";
            this.WarHd_WarehouseTitle.OutputFormat = resources.GetString("WarHd_WarehouseTitle.OutputFormat");
            this.WarHd_WarehouseTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.WarHd_WarehouseTitle.Text = "倉庫";
            this.WarHd_WarehouseTitle.Top = 0.031F;
            this.WarHd_WarehouseTitle.Width = 0.3F;
            // 
            // WarHd_line3
            // 
            this.WarHd_line3.Border.BottomColor = System.Drawing.Color.Black;
            this.WarHd_line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line3.Border.LeftColor = System.Drawing.Color.Black;
            this.WarHd_line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line3.Border.RightColor = System.Drawing.Color.Black;
            this.WarHd_line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line3.Border.TopColor = System.Drawing.Color.Black;
            this.WarHd_line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarHd_line3.Height = 0F;
            this.WarHd_line3.Left = 0F;
            this.WarHd_line3.LineWeight = 2F;
            this.WarHd_line3.Name = "WarHd_line3";
            this.WarHd_line3.Top = 0F;
            this.WarHd_line3.Width = 10.8F;
            this.WarHd_line3.X1 = 0F;
            this.WarHd_line3.X2 = 10.8F;
            this.WarHd_line3.Y1 = 0F;
            this.WarHd_line3.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarFt_TtlTotalSalesCount,
            this.line48,
            this.line50,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.WarFt_GrossProfitRate,
            this.WarFt_GrossProfit,
            this.WarFt_SalesPrice,
            this.WarFt_TotalSalesCount,
            this.WarFt_MonthPureSalesMoney,
            this.WarFt_TtlGrossProfit,
            this.WarFt_TtlSalesPrice,
            this.WarFt_TtlGrossProfitRate,
            this.WarFt_AnnualPureSalesMoney,
            this.line49,
            this.WarFt_MonthGrossProfitOrg,
            this.WarFt_AnnualGrossProfitOrg});
            this.WarehouseFooter.Height = 0.625F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.Format += new System.EventHandler(this.WarehouseFooter_Format);
            this.WarehouseFooter.BeforePrint += new System.EventHandler(this.WarehouseFooter_BeforePrint);
            // 
            // WarFt_TtlTotalSalesCount
            // 
            this.WarFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.WarFt_TtlTotalSalesCount.Height = 0.156F;
            this.WarFt_TtlTotalSalesCount.Left = 8.25F;
            this.WarFt_TtlTotalSalesCount.MultiLine = false;
            this.WarFt_TtlTotalSalesCount.Name = "WarFt_TtlTotalSalesCount";
            this.WarFt_TtlTotalSalesCount.OutputFormat = resources.GetString("WarFt_TtlTotalSalesCount.OutputFormat");
            this.WarFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_TtlTotalSalesCount.SummaryGroup = "WarehouseHeader";
            this.WarFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_TtlTotalSalesCount.Text = "123,456,789";
            this.WarFt_TtlTotalSalesCount.Top = 0.063F;
            this.WarFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // line48
            // 
            this.line48.Border.BottomColor = System.Drawing.Color.Black;
            this.line48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.LeftColor = System.Drawing.Color.Black;
            this.line48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.RightColor = System.Drawing.Color.Black;
            this.line48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.TopColor = System.Drawing.Color.Black;
            this.line48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Height = 0F;
            this.line48.Left = 0F;
            this.line48.LineWeight = 2F;
            this.line48.Name = "line48";
            this.line48.Top = 0F;
            this.line48.Width = 10.8F;
            this.line48.X1 = 0F;
            this.line48.X2 = 10.8F;
            this.line48.Y1 = 0F;
            this.line48.Y2 = 0F;
            // 
            // line50
            // 
            this.line50.Border.BottomColor = System.Drawing.Color.Black;
            this.line50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line50.Border.LeftColor = System.Drawing.Color.Black;
            this.line50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line50.Border.RightColor = System.Drawing.Color.Black;
            this.line50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line50.Border.TopColor = System.Drawing.Color.Black;
            this.line50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line50.Height = 0.13F;
            this.line50.Left = 8.25F;
            this.line50.LineWeight = 1F;
            this.line50.Name = "line50";
            this.line50.Top = 0.06F;
            this.line50.Width = 0F;
            this.line50.X1 = 8.25F;
            this.line50.X2 = 8.25F;
            this.line50.Y1 = 0.06F;
            this.line50.Y2 = 0.19F;
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
            this.textBox1.Height = 0.21875F;
            this.textBox1.Left = 1.313F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox1.Text = "倉庫計";
            this.textBox1.Top = 0.04F;
            this.textBox1.Width = 0.65625F;
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
            this.textBox2.DataField = "WarehouseCode";
            this.textBox2.Height = 0.15625F;
            this.textBox2.Left = 2.688F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.Text = "1234";
            this.textBox2.Top = 0.063F;
            this.textBox2.Width = 0.53125F;
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
            this.textBox3.DataField = "WarehouseName";
            this.textBox3.Height = 0.15625F;
            this.textBox3.Left = 3.25F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox3.Text = "あいうえおかきくけこ";
            this.textBox3.Top = 0.063F;
            this.textBox3.Width = 1.1875F;
            // 
            // WarFt_GrossProfitRate
            // 
            this.WarFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfitRate.Height = 0.156F;
            this.WarFt_GrossProfitRate.Left = 7.813F;
            this.WarFt_GrossProfitRate.MultiLine = false;
            this.WarFt_GrossProfitRate.Name = "WarFt_GrossProfitRate";
            this.WarFt_GrossProfitRate.OutputFormat = resources.GetString("WarFt_GrossProfitRate.OutputFormat");
            this.WarFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_GrossProfitRate.Text = "123.00";
            this.WarFt_GrossProfitRate.Top = 0.063F;
            this.WarFt_GrossProfitRate.Width = 0.42F;
            // 
            // WarFt_GrossProfit
            // 
            this.WarFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_GrossProfit.DataField = "MonthGrossProfit";
            this.WarFt_GrossProfit.Height = 0.156F;
            this.WarFt_GrossProfit.Left = 7.125F;
            this.WarFt_GrossProfit.MultiLine = false;
            this.WarFt_GrossProfit.Name = "WarFt_GrossProfit";
            this.WarFt_GrossProfit.OutputFormat = resources.GetString("WarFt_GrossProfit.OutputFormat");
            this.WarFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_GrossProfit.SummaryGroup = "WarehouseHeader";
            this.WarFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_GrossProfit.Text = "123,456,789";
            this.WarFt_GrossProfit.Top = 0.063F;
            this.WarFt_GrossProfit.Width = 0.7F;
            // 
            // WarFt_SalesPrice
            // 
            this.WarFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.WarFt_SalesPrice.Height = 0.156F;
            this.WarFt_SalesPrice.Left = 6.438F;
            this.WarFt_SalesPrice.MultiLine = false;
            this.WarFt_SalesPrice.Name = "WarFt_SalesPrice";
            this.WarFt_SalesPrice.OutputFormat = resources.GetString("WarFt_SalesPrice.OutputFormat");
            this.WarFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_SalesPrice.SummaryGroup = "WarehouseHeader";
            this.WarFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_SalesPrice.Text = "123,456,789";
            this.WarFt_SalesPrice.Top = 0.063F;
            this.WarFt_SalesPrice.Width = 0.7F;
            // 
            // WarFt_TotalSalesCount
            // 
            this.WarFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.WarFt_TotalSalesCount.Height = 0.156F;
            this.WarFt_TotalSalesCount.Left = 5.75F;
            this.WarFt_TotalSalesCount.MultiLine = false;
            this.WarFt_TotalSalesCount.Name = "WarFt_TotalSalesCount";
            this.WarFt_TotalSalesCount.OutputFormat = resources.GetString("WarFt_TotalSalesCount.OutputFormat");
            this.WarFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_TotalSalesCount.SummaryGroup = "WarehouseHeader";
            this.WarFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_TotalSalesCount.Text = "123,456,789";
            this.WarFt_TotalSalesCount.Top = 0.063F;
            this.WarFt_TotalSalesCount.Width = 0.7F;
            // 
            // WarFt_MonthPureSalesMoney
            // 
            this.WarFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.WarFt_MonthPureSalesMoney.Height = 0.15625F;
            this.WarFt_MonthPureSalesMoney.Left = 6.125F;
            this.WarFt_MonthPureSalesMoney.MultiLine = false;
            this.WarFt_MonthPureSalesMoney.Name = "WarFt_MonthPureSalesMoney";
            this.WarFt_MonthPureSalesMoney.OutputFormat = resources.GetString("WarFt_MonthPureSalesMoney.OutputFormat");
            this.WarFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_MonthPureSalesMoney.SummaryGroup = "WarehouseHeader";
            this.WarFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.WarFt_MonthPureSalesMoney.Top = 0.25F;
            this.WarFt_MonthPureSalesMoney.Visible = false;
            this.WarFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // WarFt_TtlGrossProfit
            // 
            this.WarFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.WarFt_TtlGrossProfit.Height = 0.156F;
            this.WarFt_TtlGrossProfit.Left = 9.625F;
            this.WarFt_TtlGrossProfit.MultiLine = false;
            this.WarFt_TtlGrossProfit.Name = "WarFt_TtlGrossProfit";
            this.WarFt_TtlGrossProfit.OutputFormat = resources.GetString("WarFt_TtlGrossProfit.OutputFormat");
            this.WarFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_TtlGrossProfit.SummaryGroup = "WarehouseHeader";
            this.WarFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_TtlGrossProfit.Text = "123,456,789";
            this.WarFt_TtlGrossProfit.Top = 0.063F;
            this.WarFt_TtlGrossProfit.Width = 0.7F;
            // 
            // WarFt_TtlSalesPrice
            // 
            this.WarFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.WarFt_TtlSalesPrice.Height = 0.156F;
            this.WarFt_TtlSalesPrice.Left = 8.938F;
            this.WarFt_TtlSalesPrice.MultiLine = false;
            this.WarFt_TtlSalesPrice.Name = "WarFt_TtlSalesPrice";
            this.WarFt_TtlSalesPrice.OutputFormat = resources.GetString("WarFt_TtlSalesPrice.OutputFormat");
            this.WarFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_TtlSalesPrice.SummaryGroup = "WarehouseHeader";
            this.WarFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_TtlSalesPrice.Text = "123,456,789";
            this.WarFt_TtlSalesPrice.Top = 0.063F;
            this.WarFt_TtlSalesPrice.Width = 0.7F;
            // 
            // WarFt_TtlGrossProfitRate
            // 
            this.WarFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_TtlGrossProfitRate.Height = 0.156F;
            this.WarFt_TtlGrossProfitRate.Left = 10.313F;
            this.WarFt_TtlGrossProfitRate.MultiLine = false;
            this.WarFt_TtlGrossProfitRate.Name = "WarFt_TtlGrossProfitRate";
            this.WarFt_TtlGrossProfitRate.OutputFormat = resources.GetString("WarFt_TtlGrossProfitRate.OutputFormat");
            this.WarFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_TtlGrossProfitRate.SummaryGroup = "WarehouseHeader";
            this.WarFt_TtlGrossProfitRate.Text = "123.00";
            this.WarFt_TtlGrossProfitRate.Top = 0.063F;
            this.WarFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // WarFt_AnnualPureSalesMoney
            // 
            this.WarFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.WarFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.WarFt_AnnualPureSalesMoney.Left = 8.625F;
            this.WarFt_AnnualPureSalesMoney.MultiLine = false;
            this.WarFt_AnnualPureSalesMoney.Name = "WarFt_AnnualPureSalesMoney";
            this.WarFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("WarFt_AnnualPureSalesMoney.OutputFormat");
            this.WarFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_AnnualPureSalesMoney.SummaryGroup = "WarehouseHeader";
            this.WarFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.WarFt_AnnualPureSalesMoney.Top = 0.25F;
            this.WarFt_AnnualPureSalesMoney.Visible = false;
            this.WarFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // line49
            // 
            this.line49.Border.BottomColor = System.Drawing.Color.Black;
            this.line49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Border.LeftColor = System.Drawing.Color.Black;
            this.line49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Border.RightColor = System.Drawing.Color.Black;
            this.line49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Border.TopColor = System.Drawing.Color.Black;
            this.line49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Height = 0.125F;
            this.line49.Left = 5.75F;
            this.line49.LineWeight = 1F;
            this.line49.Name = "line49";
            this.line49.Top = 0.0625F;
            this.line49.Width = 0F;
            this.line49.X1 = 5.75F;
            this.line49.X2 = 5.75F;
            this.line49.Y1 = 0.0625F;
            this.line49.Y2 = 0.1875F;
            // 
            // WarFt_MonthGrossProfitOrg
            // 
            this.WarFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.WarFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.WarFt_MonthGrossProfitOrg.Left = 6.875F;
            this.WarFt_MonthGrossProfitOrg.MultiLine = false;
            this.WarFt_MonthGrossProfitOrg.Name = "WarFt_MonthGrossProfitOrg";
            this.WarFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("WarFt_MonthGrossProfitOrg.OutputFormat");
            this.WarFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_MonthGrossProfitOrg.SummaryGroup = "WarehouseHeader";
            this.WarFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.WarFt_MonthGrossProfitOrg.Top = 0.25F;
            this.WarFt_MonthGrossProfitOrg.Visible = false;
            this.WarFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // WarFt_AnnualGrossProfitOrg
            // 
            this.WarFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.WarFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.WarFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.WarFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.WarFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.WarFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.WarFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.WarFt_AnnualGrossProfitOrg.MultiLine = false;
            this.WarFt_AnnualGrossProfitOrg.Name = "WarFt_AnnualGrossProfitOrg";
            this.WarFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("WarFt_AnnualGrossProfitOrg.OutputFormat");
            this.WarFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.WarFt_AnnualGrossProfitOrg.SummaryGroup = "WarehouseHeader";
            this.WarFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.WarFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.WarFt_AnnualGrossProfitOrg.Visible = false;
            this.WarFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // WarehouseHeader2
            // 
            this.WarehouseHeader2.CanShrink = true;
            this.WarehouseHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.War2Hd_WarehouseTitle,
            this.War2Hd_WarehouseCode,
            this.War2Hd_WarehouseName,
            this.War2Hd_Line1,
            this.War2Hd_Line2,
            this.War2Hd_Line3});
            this.WarehouseHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.WarehouseHeader2.Height = 0.21875F;
            this.WarehouseHeader2.KeepTogether = true;
            this.WarehouseHeader2.Name = "WarehouseHeader2";
            this.WarehouseHeader2.Visible = false;
            this.WarehouseHeader2.AfterPrint += new System.EventHandler(this.WarehouseHeader2_AfterPrint);
            this.WarehouseHeader2.BeforePrint += new System.EventHandler(this.WarehouseHeader2_BeforePrint);
            // 
            // War2Hd_WarehouseTitle
            // 
            this.War2Hd_WarehouseTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseTitle.Border.RightColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseTitle.Border.TopColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseTitle.Height = 0.156F;
            this.War2Hd_WarehouseTitle.Left = 0.25F;
            this.War2Hd_WarehouseTitle.MultiLine = false;
            this.War2Hd_WarehouseTitle.Name = "War2Hd_WarehouseTitle";
            this.War2Hd_WarehouseTitle.OutputFormat = resources.GetString("War2Hd_WarehouseTitle.OutputFormat");
            this.War2Hd_WarehouseTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.War2Hd_WarehouseTitle.Text = "倉庫";
            this.War2Hd_WarehouseTitle.Top = 0.031F;
            this.War2Hd_WarehouseTitle.Width = 0.3F;
            // 
            // War2Hd_WarehouseCode
            // 
            this.War2Hd_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseCode.DataField = "WarehouseCode";
            this.War2Hd_WarehouseCode.Height = 0.156F;
            this.War2Hd_WarehouseCode.Left = 0.563F;
            this.War2Hd_WarehouseCode.MultiLine = false;
            this.War2Hd_WarehouseCode.Name = "War2Hd_WarehouseCode";
            this.War2Hd_WarehouseCode.OutputFormat = resources.GetString("War2Hd_WarehouseCode.OutputFormat");
            this.War2Hd_WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.War2Hd_WarehouseCode.Text = "1234";
            this.War2Hd_WarehouseCode.Top = 0.031F;
            this.War2Hd_WarehouseCode.Width = 0.3F;
            // 
            // War2Hd_WarehouseName
            // 
            this.War2Hd_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.War2Hd_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_WarehouseName.DataField = "WarehouseName";
            this.War2Hd_WarehouseName.Height = 0.15625F;
            this.War2Hd_WarehouseName.Left = 0.875F;
            this.War2Hd_WarehouseName.MultiLine = false;
            this.War2Hd_WarehouseName.Name = "War2Hd_WarehouseName";
            this.War2Hd_WarehouseName.OutputFormat = resources.GetString("War2Hd_WarehouseName.OutputFormat");
            this.War2Hd_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.War2Hd_WarehouseName.Text = "あいうえおかきくけこ";
            this.War2Hd_WarehouseName.Top = 0.031F;
            this.War2Hd_WarehouseName.Width = 1.1875F;
            // 
            // War2Hd_Line1
            // 
            this.War2Hd_Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Hd_Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Hd_Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line1.Border.RightColor = System.Drawing.Color.Black;
            this.War2Hd_Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line1.Border.TopColor = System.Drawing.Color.Black;
            this.War2Hd_Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line1.Height = 0.095F;
            this.War2Hd_Line1.Left = 5.75F;
            this.War2Hd_Line1.LineWeight = 1F;
            this.War2Hd_Line1.Name = "War2Hd_Line1";
            this.War2Hd_Line1.Top = 0.03F;
            this.War2Hd_Line1.Width = 0F;
            this.War2Hd_Line1.X1 = 5.75F;
            this.War2Hd_Line1.X2 = 5.75F;
            this.War2Hd_Line1.Y1 = 0.03F;
            this.War2Hd_Line1.Y2 = 0.125F;
            // 
            // War2Hd_Line2
            // 
            this.War2Hd_Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Hd_Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Hd_Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line2.Border.RightColor = System.Drawing.Color.Black;
            this.War2Hd_Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line2.Border.TopColor = System.Drawing.Color.Black;
            this.War2Hd_Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line2.Height = 0.09999999F;
            this.War2Hd_Line2.Left = 8.25F;
            this.War2Hd_Line2.LineWeight = 1F;
            this.War2Hd_Line2.Name = "War2Hd_Line2";
            this.War2Hd_Line2.Top = 0.03F;
            this.War2Hd_Line2.Width = 0F;
            this.War2Hd_Line2.X1 = 8.25F;
            this.War2Hd_Line2.X2 = 8.25F;
            this.War2Hd_Line2.Y1 = 0.03F;
            this.War2Hd_Line2.Y2 = 0.13F;
            // 
            // War2Hd_Line3
            // 
            this.War2Hd_Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Hd_Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Hd_Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line3.Border.RightColor = System.Drawing.Color.Black;
            this.War2Hd_Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line3.Border.TopColor = System.Drawing.Color.Black;
            this.War2Hd_Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Hd_Line3.Height = 0F;
            this.War2Hd_Line3.Left = 0F;
            this.War2Hd_Line3.LineWeight = 2F;
            this.War2Hd_Line3.Name = "War2Hd_Line3";
            this.War2Hd_Line3.Top = 0F;
            this.War2Hd_Line3.Width = 10.8F;
            this.War2Hd_Line3.X1 = 0F;
            this.War2Hd_Line3.X2 = 10.8F;
            this.War2Hd_Line3.Y1 = 0F;
            this.War2Hd_Line3.Y2 = 0F;
            // 
            // WarehouseFooter2
            // 
            this.WarehouseFooter2.CanShrink = true;
            this.WarehouseFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.War2Ft_TtlTotalSalesCount,
            this.textBox4,
            this.line3,
            this.line9,
            this.War2Ft_GrossProfit,
            this.War2Ft_SalesPrice,
            this.War2Ft_TotalSalesCount,
            this.War2Ft_MonthPureSalesMoney,
            this.War2Ft_TtlGrossProfit,
            this.War2Ft_TtlSalesPrice,
            this.War2Ft_TtlGrossProfitRate,
            this.War2Ft_AnnualPureSalesMoney,
            this.line8,
            this.War2Ft_GrossProfitRate,
            this.War2Ft_MonthGrossProfitOrg,
            this.War2Ft_AnnualGrossProfitOrg});
            this.WarehouseFooter2.Height = 0.625F;
            this.WarehouseFooter2.KeepTogether = true;
            this.WarehouseFooter2.Name = "WarehouseFooter2";
            this.WarehouseFooter2.Visible = false;
            this.WarehouseFooter2.Format += new System.EventHandler(this.WarehouseFooter2_Format);
            this.WarehouseFooter2.BeforePrint += new System.EventHandler(this.WarehouseFooter2_BeforePrint);
            // 
            // War2Ft_TtlTotalSalesCount
            // 
            this.War2Ft_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.War2Ft_TtlTotalSalesCount.Height = 0.156F;
            this.War2Ft_TtlTotalSalesCount.Left = 8.25F;
            this.War2Ft_TtlTotalSalesCount.MultiLine = false;
            this.War2Ft_TtlTotalSalesCount.Name = "War2Ft_TtlTotalSalesCount";
            this.War2Ft_TtlTotalSalesCount.OutputFormat = resources.GetString("War2Ft_TtlTotalSalesCount.OutputFormat");
            this.War2Ft_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_TtlTotalSalesCount.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_TtlTotalSalesCount.Text = "123,456,789";
            this.War2Ft_TtlTotalSalesCount.Top = 0.063F;
            this.War2Ft_TtlTotalSalesCount.Width = 0.7F;
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
            this.textBox4.Height = 0.21875F;
            this.textBox4.Left = 1.313F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox4.Text = "倉庫計";
            this.textBox4.Top = 0.04F;
            this.textBox4.Width = 0.65625F;
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
            this.line9.Height = 0.13F;
            this.line9.Left = 8.25F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 0.06F;
            this.line9.Width = 0F;
            this.line9.X1 = 8.25F;
            this.line9.X2 = 8.25F;
            this.line9.Y1 = 0.06F;
            this.line9.Y2 = 0.19F;
            // 
            // War2Ft_GrossProfit
            // 
            this.War2Ft_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfit.DataField = "MonthGrossProfit";
            this.War2Ft_GrossProfit.Height = 0.156F;
            this.War2Ft_GrossProfit.Left = 7.125F;
            this.War2Ft_GrossProfit.MultiLine = false;
            this.War2Ft_GrossProfit.Name = "War2Ft_GrossProfit";
            this.War2Ft_GrossProfit.OutputFormat = resources.GetString("War2Ft_GrossProfit.OutputFormat");
            this.War2Ft_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_GrossProfit.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_GrossProfit.Text = "123,456,789";
            this.War2Ft_GrossProfit.Top = 0.063F;
            this.War2Ft_GrossProfit.Width = 0.7F;
            // 
            // War2Ft_SalesPrice
            // 
            this.War2Ft_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_SalesPrice.DataField = "MonthPureSalesMoney";
            this.War2Ft_SalesPrice.Height = 0.156F;
            this.War2Ft_SalesPrice.Left = 6.438F;
            this.War2Ft_SalesPrice.MultiLine = false;
            this.War2Ft_SalesPrice.Name = "War2Ft_SalesPrice";
            this.War2Ft_SalesPrice.OutputFormat = resources.GetString("War2Ft_SalesPrice.OutputFormat");
            this.War2Ft_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_SalesPrice.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_SalesPrice.Text = "123,456,789";
            this.War2Ft_SalesPrice.Top = 0.063F;
            this.War2Ft_SalesPrice.Width = 0.7F;
            // 
            // War2Ft_TotalSalesCount
            // 
            this.War2Ft_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.War2Ft_TotalSalesCount.Height = 0.156F;
            this.War2Ft_TotalSalesCount.Left = 5.75F;
            this.War2Ft_TotalSalesCount.MultiLine = false;
            this.War2Ft_TotalSalesCount.Name = "War2Ft_TotalSalesCount";
            this.War2Ft_TotalSalesCount.OutputFormat = resources.GetString("War2Ft_TotalSalesCount.OutputFormat");
            this.War2Ft_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_TotalSalesCount.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_TotalSalesCount.Text = "123,456,789";
            this.War2Ft_TotalSalesCount.Top = 0.063F;
            this.War2Ft_TotalSalesCount.Width = 0.7F;
            // 
            // War2Ft_MonthPureSalesMoney
            // 
            this.War2Ft_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.War2Ft_MonthPureSalesMoney.Height = 0.15625F;
            this.War2Ft_MonthPureSalesMoney.Left = 6.125F;
            this.War2Ft_MonthPureSalesMoney.MultiLine = false;
            this.War2Ft_MonthPureSalesMoney.Name = "War2Ft_MonthPureSalesMoney";
            this.War2Ft_MonthPureSalesMoney.OutputFormat = resources.GetString("War2Ft_MonthPureSalesMoney.OutputFormat");
            this.War2Ft_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_MonthPureSalesMoney.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_MonthPureSalesMoney.Text = "1234,567,890";
            this.War2Ft_MonthPureSalesMoney.Top = 0.25F;
            this.War2Ft_MonthPureSalesMoney.Visible = false;
            this.War2Ft_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // War2Ft_TtlGrossProfit
            // 
            this.War2Ft_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.War2Ft_TtlGrossProfit.Height = 0.156F;
            this.War2Ft_TtlGrossProfit.Left = 9.625F;
            this.War2Ft_TtlGrossProfit.MultiLine = false;
            this.War2Ft_TtlGrossProfit.Name = "War2Ft_TtlGrossProfit";
            this.War2Ft_TtlGrossProfit.OutputFormat = resources.GetString("War2Ft_TtlGrossProfit.OutputFormat");
            this.War2Ft_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_TtlGrossProfit.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_TtlGrossProfit.Text = "123,456,789";
            this.War2Ft_TtlGrossProfit.Top = 0.063F;
            this.War2Ft_TtlGrossProfit.Width = 0.7F;
            // 
            // War2Ft_TtlSalesPrice
            // 
            this.War2Ft_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.War2Ft_TtlSalesPrice.Height = 0.156F;
            this.War2Ft_TtlSalesPrice.Left = 8.938F;
            this.War2Ft_TtlSalesPrice.MultiLine = false;
            this.War2Ft_TtlSalesPrice.Name = "War2Ft_TtlSalesPrice";
            this.War2Ft_TtlSalesPrice.OutputFormat = resources.GetString("War2Ft_TtlSalesPrice.OutputFormat");
            this.War2Ft_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_TtlSalesPrice.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_TtlSalesPrice.Text = "123,456,789";
            this.War2Ft_TtlSalesPrice.Top = 0.063F;
            this.War2Ft_TtlSalesPrice.Width = 0.7F;
            // 
            // War2Ft_TtlGrossProfitRate
            // 
            this.War2Ft_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_TtlGrossProfitRate.Height = 0.156F;
            this.War2Ft_TtlGrossProfitRate.Left = 10.313F;
            this.War2Ft_TtlGrossProfitRate.MultiLine = false;
            this.War2Ft_TtlGrossProfitRate.Name = "War2Ft_TtlGrossProfitRate";
            this.War2Ft_TtlGrossProfitRate.OutputFormat = resources.GetString("War2Ft_TtlGrossProfitRate.OutputFormat");
            this.War2Ft_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_TtlGrossProfitRate.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_TtlGrossProfitRate.Text = "123.00";
            this.War2Ft_TtlGrossProfitRate.Top = 0.063F;
            this.War2Ft_TtlGrossProfitRate.Width = 0.42F;
            // 
            // War2Ft_AnnualPureSalesMoney
            // 
            this.War2Ft_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.War2Ft_AnnualPureSalesMoney.Height = 0.15625F;
            this.War2Ft_AnnualPureSalesMoney.Left = 8.625F;
            this.War2Ft_AnnualPureSalesMoney.MultiLine = false;
            this.War2Ft_AnnualPureSalesMoney.Name = "War2Ft_AnnualPureSalesMoney";
            this.War2Ft_AnnualPureSalesMoney.OutputFormat = resources.GetString("War2Ft_AnnualPureSalesMoney.OutputFormat");
            this.War2Ft_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_AnnualPureSalesMoney.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_AnnualPureSalesMoney.Text = "1234,567,890";
            this.War2Ft_AnnualPureSalesMoney.Top = 0.25F;
            this.War2Ft_AnnualPureSalesMoney.Visible = false;
            this.War2Ft_AnnualPureSalesMoney.Width = 0.71875F;
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
            this.line8.Height = 0.125F;
            this.line8.Left = 5.75F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 0.0625F;
            this.line8.Width = 0F;
            this.line8.X1 = 5.75F;
            this.line8.X2 = 5.75F;
            this.line8.Y1 = 0.0625F;
            this.line8.Y2 = 0.1875F;
            // 
            // War2Ft_GrossProfitRate
            // 
            this.War2Ft_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_GrossProfitRate.Height = 0.156F;
            this.War2Ft_GrossProfitRate.Left = 7.813F;
            this.War2Ft_GrossProfitRate.MultiLine = false;
            this.War2Ft_GrossProfitRate.Name = "War2Ft_GrossProfitRate";
            this.War2Ft_GrossProfitRate.OutputFormat = resources.GetString("War2Ft_GrossProfitRate.OutputFormat");
            this.War2Ft_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_GrossProfitRate.Text = "123.00";
            this.War2Ft_GrossProfitRate.Top = 0.063F;
            this.War2Ft_GrossProfitRate.Width = 0.42F;
            // 
            // War2Ft_MonthGrossProfitOrg
            // 
            this.War2Ft_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.War2Ft_MonthGrossProfitOrg.Height = 0.15625F;
            this.War2Ft_MonthGrossProfitOrg.Left = 6.875F;
            this.War2Ft_MonthGrossProfitOrg.MultiLine = false;
            this.War2Ft_MonthGrossProfitOrg.Name = "War2Ft_MonthGrossProfitOrg";
            this.War2Ft_MonthGrossProfitOrg.OutputFormat = resources.GetString("War2Ft_MonthGrossProfitOrg.OutputFormat");
            this.War2Ft_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_MonthGrossProfitOrg.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_MonthGrossProfitOrg.Text = "1234,567,890";
            this.War2Ft_MonthGrossProfitOrg.Top = 0.25F;
            this.War2Ft_MonthGrossProfitOrg.Visible = false;
            this.War2Ft_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // War2Ft_AnnualGrossProfitOrg
            // 
            this.War2Ft_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.War2Ft_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.War2Ft_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.War2Ft_AnnualGrossProfitOrg.Height = 0.15625F;
            this.War2Ft_AnnualGrossProfitOrg.Left = 9.375F;
            this.War2Ft_AnnualGrossProfitOrg.MultiLine = false;
            this.War2Ft_AnnualGrossProfitOrg.Name = "War2Ft_AnnualGrossProfitOrg";
            this.War2Ft_AnnualGrossProfitOrg.OutputFormat = resources.GetString("War2Ft_AnnualGrossProfitOrg.OutputFormat");
            this.War2Ft_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.War2Ft_AnnualGrossProfitOrg.SummaryGroup = "WarehouseHeader2";
            this.War2Ft_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.War2Ft_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.War2Ft_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.War2Ft_AnnualGrossProfitOrg.Top = 0.25F;
            this.War2Ft_AnnualGrossProfitOrg.Visible = false;
            this.War2Ft_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.CanShrink = true;
            this.SupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupHd_SectionTitle,
            this.SupHd_AddUpSecCode,
            this.SupHd_SectionGuideNm,
            this.SupHd_SupplierTitle,
            this.SupHd_SupplierCode,
            this.SupHd_SupplierSnm,
            this.line35,
            this.line36,
            this.line38});
            this.SupplierHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SupplierHeader.Height = 0.25F;
            this.SupplierHeader.KeepTogether = true;
            this.SupplierHeader.Name = "SupplierHeader";
            this.SupplierHeader.AfterPrint += new System.EventHandler(this.SupplierHeader_AfterPrint);
            this.SupplierHeader.BeforePrint += new System.EventHandler(this.SupplierHeader_BeforePrint);
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
            this.SupHd_SectionTitle.Height = 0.156F;
            this.SupHd_SectionTitle.Left = 0.25F;
            this.SupHd_SectionTitle.MultiLine = false;
            this.SupHd_SectionTitle.Name = "SupHd_SectionTitle";
            this.SupHd_SectionTitle.OutputFormat = resources.GetString("SupHd_SectionTitle.OutputFormat");
            this.SupHd_SectionTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SectionTitle.Text = "拠点";
            this.SupHd_SectionTitle.Top = 0.031F;
            this.SupHd_SectionTitle.Width = 0.3F;
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
            this.SupHd_AddUpSecCode.Height = 0.156F;
            this.SupHd_AddUpSecCode.Left = 0.563F;
            this.SupHd_AddUpSecCode.MultiLine = false;
            this.SupHd_AddUpSecCode.Name = "SupHd_AddUpSecCode";
            this.SupHd_AddUpSecCode.OutputFormat = resources.GetString("SupHd_AddUpSecCode.OutputFormat");
            this.SupHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_AddUpSecCode.Text = "12";
            this.SupHd_AddUpSecCode.Top = 0.031F;
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
            this.SupHd_SectionGuideNm.DataField = "CompanyName1";
            this.SupHd_SectionGuideNm.Height = 0.15625F;
            this.SupHd_SectionGuideNm.Left = 0.72F;
            this.SupHd_SectionGuideNm.MultiLine = false;
            this.SupHd_SectionGuideNm.Name = "SupHd_SectionGuideNm";
            this.SupHd_SectionGuideNm.OutputFormat = resources.GetString("SupHd_SectionGuideNm.OutputFormat");
            this.SupHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SupHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SupHd_SectionGuideNm.Top = 0.031F;
            this.SupHd_SectionGuideNm.Width = 1.1875F;
            // 
            // SupHd_SupplierTitle
            // 
            this.SupHd_SupplierTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Height = 0.156F;
            this.SupHd_SupplierTitle.Left = 2.188F;
            this.SupHd_SupplierTitle.MultiLine = false;
            this.SupHd_SupplierTitle.Name = "SupHd_SupplierTitle";
            this.SupHd_SupplierTitle.OutputFormat = resources.GetString("SupHd_SupplierTitle.OutputFormat");
            this.SupHd_SupplierTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SupplierTitle.Text = "仕入先";
            this.SupHd_SupplierTitle.Top = 0.031F;
            this.SupHd_SupplierTitle.Width = 0.4F;
            // 
            // SupHd_SupplierCode
            // 
            this.SupHd_SupplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.DataField = "SupplierCode";
            this.SupHd_SupplierCode.Height = 0.156F;
            this.SupHd_SupplierCode.Left = 2.635917F;
            this.SupHd_SupplierCode.MultiLine = false;
            this.SupHd_SupplierCode.Name = "SupHd_SupplierCode";
            this.SupHd_SupplierCode.OutputFormat = resources.GetString("SupHd_SupplierCode.OutputFormat");
            this.SupHd_SupplierCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupHd_SupplierCode.Text = "123456";
            this.SupHd_SupplierCode.Top = 0.031F;
            this.SupHd_SupplierCode.Width = 0.38F;
            // 
            // SupHd_SupplierSnm
            // 
            this.SupHd_SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierSnm.DataField = "SupplierSnm";
            this.SupHd_SupplierSnm.Height = 0.156F;
            this.SupHd_SupplierSnm.Left = 3.063F;
            this.SupHd_SupplierSnm.MultiLine = false;
            this.SupHd_SupplierSnm.Name = "SupHd_SupplierSnm";
            this.SupHd_SupplierSnm.OutputFormat = resources.GetString("SupHd_SupplierSnm.OutputFormat");
            this.SupHd_SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SupHd_SupplierSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupHd_SupplierSnm.Top = 0.031F;
            this.SupHd_SupplierSnm.Width = 2.3F;
            // 
            // line35
            // 
            this.line35.Border.BottomColor = System.Drawing.Color.Black;
            this.line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.LeftColor = System.Drawing.Color.Black;
            this.line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.RightColor = System.Drawing.Color.Black;
            this.line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.TopColor = System.Drawing.Color.Black;
            this.line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Height = 0.09999999F;
            this.line35.Left = 5.75F;
            this.line35.LineWeight = 1F;
            this.line35.Name = "line35";
            this.line35.Top = 0.03F;
            this.line35.Width = 0F;
            this.line35.X1 = 5.75F;
            this.line35.X2 = 5.75F;
            this.line35.Y1 = 0.03F;
            this.line35.Y2 = 0.13F;
            // 
            // line36
            // 
            this.line36.Border.BottomColor = System.Drawing.Color.Black;
            this.line36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.LeftColor = System.Drawing.Color.Black;
            this.line36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.RightColor = System.Drawing.Color.Black;
            this.line36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.TopColor = System.Drawing.Color.Black;
            this.line36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Height = 0.09999999F;
            this.line36.Left = 8.25F;
            this.line36.LineWeight = 1F;
            this.line36.Name = "line36";
            this.line36.Top = 0.03F;
            this.line36.Width = 0F;
            this.line36.X1 = 8.25F;
            this.line36.X2 = 8.25F;
            this.line36.Y1 = 0.03F;
            this.line36.Y2 = 0.13F;
            // 
            // line38
            // 
            this.line38.Border.BottomColor = System.Drawing.Color.Black;
            this.line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.LeftColor = System.Drawing.Color.Black;
            this.line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.RightColor = System.Drawing.Color.Black;
            this.line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.TopColor = System.Drawing.Color.Black;
            this.line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Height = 0F;
            this.line38.Left = 0F;
            this.line38.LineWeight = 2F;
            this.line38.Name = "line38";
            this.line38.Top = 0F;
            this.line38.Width = 10.8F;
            this.line38.X1 = 0F;
            this.line38.X2 = 10.8F;
            this.line38.Y1 = 0F;
            this.line38.Y2 = 0F;
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line39,
            this.textBox5,
            this.SupFt_GrossProfit,
            this.SupFt_SalesPrice,
            this.SupFt_TotalSalesCount,
            this.SupFt_GrossProfitRate,
            this.SupFt_TtlGrossProfit,
            this.SupFt_TtlSalesPrice,
            this.SupFt_TtlTotalSalesCount,
            this.SupFt_TtlGrossProfitRate,
            this.line40,
            this.line45,
            this.SupFt_SupplierCode,
            this.SupFt_SupplierSnm,
            this.SupFt_MonthPureSalesMoney,
            this.SupFt_AnnualPureSalesMoney,
            this.SupFt_MonthGrossProfitOrg,
            this.SupFt_AnnualGrossProfitOrg});
            this.SupplierFooter.Height = 0.625F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            this.SupplierFooter.Format += new System.EventHandler(this.SupplierFooter_Format);
            this.SupplierFooter.BeforePrint += new System.EventHandler(this.SupplierFooter_BeforePrint);
            // 
            // line39
            // 
            this.line39.Border.BottomColor = System.Drawing.Color.Black;
            this.line39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.LeftColor = System.Drawing.Color.Black;
            this.line39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.RightColor = System.Drawing.Color.Black;
            this.line39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.TopColor = System.Drawing.Color.Black;
            this.line39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Height = 0F;
            this.line39.Left = 0F;
            this.line39.LineWeight = 2F;
            this.line39.Name = "line39";
            this.line39.Top = 0F;
            this.line39.Width = 10.8F;
            this.line39.X1 = 0F;
            this.line39.X2 = 10.8F;
            this.line39.Y1 = 0F;
            this.line39.Y2 = 0F;
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
            this.textBox5.Height = 0.21875F;
            this.textBox5.Left = 1.313F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox5.Text = "仕入先計";
            this.textBox5.Top = 0.04F;
            this.textBox5.Width = 0.65625F;
            // 
            // SupFt_GrossProfit
            // 
            this.SupFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfit.DataField = "MonthGrossProfit";
            this.SupFt_GrossProfit.Height = 0.156F;
            this.SupFt_GrossProfit.Left = 7.125F;
            this.SupFt_GrossProfit.MultiLine = false;
            this.SupFt_GrossProfit.Name = "SupFt_GrossProfit";
            this.SupFt_GrossProfit.OutputFormat = resources.GetString("SupFt_GrossProfit.OutputFormat");
            this.SupFt_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_GrossProfit.SummaryGroup = "SupplierHeader";
            this.SupFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_GrossProfit.Text = "123,456,789";
            this.SupFt_GrossProfit.Top = 0.063F;
            this.SupFt_GrossProfit.Width = 0.7F;
            // 
            // SupFt_SalesPrice
            // 
            this.SupFt_SalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesPrice.DataField = "MonthPureSalesMoney";
            this.SupFt_SalesPrice.Height = 0.156F;
            this.SupFt_SalesPrice.Left = 6.438F;
            this.SupFt_SalesPrice.MultiLine = false;
            this.SupFt_SalesPrice.Name = "SupFt_SalesPrice";
            this.SupFt_SalesPrice.OutputFormat = resources.GetString("SupFt_SalesPrice.OutputFormat");
            this.SupFt_SalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesPrice.Text = "123,456,789";
            this.SupFt_SalesPrice.Top = 0.063F;
            this.SupFt_SalesPrice.Width = 0.7F;
            // 
            // SupFt_TotalSalesCount
            // 
            this.SupFt_TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount.DataField = "MonthTotalSalesCount";
            this.SupFt_TotalSalesCount.Height = 0.156F;
            this.SupFt_TotalSalesCount.Left = 5.75F;
            this.SupFt_TotalSalesCount.MultiLine = false;
            this.SupFt_TotalSalesCount.Name = "SupFt_TotalSalesCount";
            this.SupFt_TotalSalesCount.OutputFormat = resources.GetString("SupFt_TotalSalesCount.OutputFormat");
            this.SupFt_TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount.Text = "123,456,789";
            this.SupFt_TotalSalesCount.Top = 0.063F;
            this.SupFt_TotalSalesCount.Width = 0.7F;
            // 
            // SupFt_GrossProfitRate
            // 
            this.SupFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossProfitRate.Height = 0.156F;
            this.SupFt_GrossProfitRate.Left = 7.813F;
            this.SupFt_GrossProfitRate.MultiLine = false;
            this.SupFt_GrossProfitRate.Name = "SupFt_GrossProfitRate";
            this.SupFt_GrossProfitRate.OutputFormat = resources.GetString("SupFt_GrossProfitRate.OutputFormat");
            this.SupFt_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_GrossProfitRate.Text = "123.00";
            this.SupFt_GrossProfitRate.Top = 0.063F;
            this.SupFt_GrossProfitRate.Width = 0.42F;
            // 
            // SupFt_TtlGrossProfit
            // 
            this.SupFt_TtlGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfit.DataField = "AnnualGrossProfit";
            this.SupFt_TtlGrossProfit.Height = 0.156F;
            this.SupFt_TtlGrossProfit.Left = 9.625F;
            this.SupFt_TtlGrossProfit.MultiLine = false;
            this.SupFt_TtlGrossProfit.Name = "SupFt_TtlGrossProfit";
            this.SupFt_TtlGrossProfit.OutputFormat = resources.GetString("SupFt_TtlGrossProfit.OutputFormat");
            this.SupFt_TtlGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TtlGrossProfit.SummaryGroup = "SupplierHeader";
            this.SupFt_TtlGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TtlGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TtlGrossProfit.Text = "123,456,789";
            this.SupFt_TtlGrossProfit.Top = 0.063F;
            this.SupFt_TtlGrossProfit.Width = 0.7F;
            // 
            // SupFt_TtlSalesPrice
            // 
            this.SupFt_TtlSalesPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesPrice.DataField = "AnnualPureSalesMoney";
            this.SupFt_TtlSalesPrice.Height = 0.156F;
            this.SupFt_TtlSalesPrice.Left = 8.938F;
            this.SupFt_TtlSalesPrice.MultiLine = false;
            this.SupFt_TtlSalesPrice.Name = "SupFt_TtlSalesPrice";
            this.SupFt_TtlSalesPrice.OutputFormat = resources.GetString("SupFt_TtlSalesPrice.OutputFormat");
            this.SupFt_TtlSalesPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TtlSalesPrice.SummaryGroup = "SupplierHeader";
            this.SupFt_TtlSalesPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TtlSalesPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TtlSalesPrice.Text = "123,456,789";
            this.SupFt_TtlSalesPrice.Top = 0.063F;
            this.SupFt_TtlSalesPrice.Width = 0.7F;
            // 
            // SupFt_TtlTotalSalesCount
            // 
            this.SupFt_TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlTotalSalesCount.DataField = "AnnualTotalSalesCount";
            this.SupFt_TtlTotalSalesCount.Height = 0.156F;
            this.SupFt_TtlTotalSalesCount.Left = 8.25F;
            this.SupFt_TtlTotalSalesCount.MultiLine = false;
            this.SupFt_TtlTotalSalesCount.Name = "SupFt_TtlTotalSalesCount";
            this.SupFt_TtlTotalSalesCount.OutputFormat = resources.GetString("SupFt_TtlTotalSalesCount.OutputFormat");
            this.SupFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TtlTotalSalesCount.SummaryGroup = "SupplierHeader";
            this.SupFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TtlTotalSalesCount.Text = "123,456,789";
            this.SupFt_TtlTotalSalesCount.Top = 0.063F;
            this.SupFt_TtlTotalSalesCount.Width = 0.7F;
            // 
            // SupFt_TtlGrossProfitRate
            // 
            this.SupFt_TtlGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TtlGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlGrossProfitRate.Height = 0.156F;
            this.SupFt_TtlGrossProfitRate.Left = 10.313F;
            this.SupFt_TtlGrossProfitRate.MultiLine = false;
            this.SupFt_TtlGrossProfitRate.Name = "SupFt_TtlGrossProfitRate";
            this.SupFt_TtlGrossProfitRate.OutputFormat = resources.GetString("SupFt_TtlGrossProfitRate.OutputFormat");
            this.SupFt_TtlGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TtlGrossProfitRate.SummaryGroup = "SupplierHeader";
            this.SupFt_TtlGrossProfitRate.Text = "123.00";
            this.SupFt_TtlGrossProfitRate.Top = 0.063F;
            this.SupFt_TtlGrossProfitRate.Width = 0.42F;
            // 
            // line40
            // 
            this.line40.Border.BottomColor = System.Drawing.Color.Black;
            this.line40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Border.LeftColor = System.Drawing.Color.Black;
            this.line40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Border.RightColor = System.Drawing.Color.Black;
            this.line40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Border.TopColor = System.Drawing.Color.Black;
            this.line40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Height = 0.125F;
            this.line40.Left = 5.75F;
            this.line40.LineWeight = 1F;
            this.line40.Name = "line40";
            this.line40.Top = 0.0625F;
            this.line40.Width = 0F;
            this.line40.X1 = 5.75F;
            this.line40.X2 = 5.75F;
            this.line40.Y1 = 0.0625F;
            this.line40.Y2 = 0.1875F;
            // 
            // line45
            // 
            this.line45.Border.BottomColor = System.Drawing.Color.Black;
            this.line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Border.LeftColor = System.Drawing.Color.Black;
            this.line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Border.RightColor = System.Drawing.Color.Black;
            this.line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Border.TopColor = System.Drawing.Color.Black;
            this.line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Height = 0.13F;
            this.line45.Left = 8.25F;
            this.line45.LineWeight = 1F;
            this.line45.Name = "line45";
            this.line45.Top = 0.06F;
            this.line45.Width = 0F;
            this.line45.X1 = 8.25F;
            this.line45.X2 = 8.25F;
            this.line45.Y1 = 0.06F;
            this.line45.Y2 = 0.19F;
            // 
            // SupFt_SupplierCode
            // 
            this.SupFt_SupplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SupplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SupplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SupplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SupplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierCode.DataField = "SupplierCode";
            this.SupFt_SupplierCode.Height = 0.15625F;
            this.SupFt_SupplierCode.Left = 2.6875F;
            this.SupFt_SupplierCode.MultiLine = false;
            this.SupFt_SupplierCode.Name = "SupFt_SupplierCode";
            this.SupFt_SupplierCode.OutputFormat = resources.GetString("SupFt_SupplierCode.OutputFormat");
            this.SupFt_SupplierCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SupplierCode.Text = "123456";
            this.SupFt_SupplierCode.Top = 0.0625F;
            this.SupFt_SupplierCode.Width = 0.53125F;
            // 
            // SupFt_SupplierSnm
            // 
            this.SupFt_SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SupplierSnm.DataField = "SupplierSnm";
            this.SupFt_SupplierSnm.Height = 0.156F;
            this.SupFt_SupplierSnm.Left = 3.25F;
            this.SupFt_SupplierSnm.MultiLine = false;
            this.SupFt_SupplierSnm.Name = "SupFt_SupplierSnm";
            this.SupFt_SupplierSnm.OutputFormat = resources.GetString("SupFt_SupplierSnm.OutputFormat");
            this.SupFt_SupplierSnm.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SupFt_SupplierSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupFt_SupplierSnm.Top = 0.0625F;
            this.SupFt_SupplierSnm.Width = 2.3F;
            // 
            // SupFt_MonthPureSalesMoney
            // 
            this.SupFt_MonthPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_MonthPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_MonthPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_MonthPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_MonthPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthPureSalesMoney.DataField = "MonthPureSalesMoneyOrg";
            this.SupFt_MonthPureSalesMoney.Height = 0.15625F;
            this.SupFt_MonthPureSalesMoney.Left = 6.125F;
            this.SupFt_MonthPureSalesMoney.MultiLine = false;
            this.SupFt_MonthPureSalesMoney.Name = "SupFt_MonthPureSalesMoney";
            this.SupFt_MonthPureSalesMoney.OutputFormat = resources.GetString("SupFt_MonthPureSalesMoney.OutputFormat");
            this.SupFt_MonthPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_MonthPureSalesMoney.SummaryGroup = "SupplierHeader";
            this.SupFt_MonthPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_MonthPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_MonthPureSalesMoney.Text = "1234,567,890";
            this.SupFt_MonthPureSalesMoney.Top = 0.25F;
            this.SupFt_MonthPureSalesMoney.Visible = false;
            this.SupFt_MonthPureSalesMoney.Width = 0.71875F;
            // 
            // SupFt_AnnualPureSalesMoney
            // 
            this.SupFt_AnnualPureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualPureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualPureSalesMoney.DataField = "AnnualPureSalesMoneyOrg";
            this.SupFt_AnnualPureSalesMoney.Height = 0.15625F;
            this.SupFt_AnnualPureSalesMoney.Left = 8.625F;
            this.SupFt_AnnualPureSalesMoney.MultiLine = false;
            this.SupFt_AnnualPureSalesMoney.Name = "SupFt_AnnualPureSalesMoney";
            this.SupFt_AnnualPureSalesMoney.OutputFormat = resources.GetString("SupFt_AnnualPureSalesMoney.OutputFormat");
            this.SupFt_AnnualPureSalesMoney.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualPureSalesMoney.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualPureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualPureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualPureSalesMoney.Text = "1234,567,890";
            this.SupFt_AnnualPureSalesMoney.Top = 0.25F;
            this.SupFt_AnnualPureSalesMoney.Visible = false;
            this.SupFt_AnnualPureSalesMoney.Width = 0.71875F;
            // 
            // SupFt_MonthGrossProfitOrg
            // 
            this.SupFt_MonthGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_MonthGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_MonthGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_MonthGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_MonthGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_MonthGrossProfitOrg.DataField = "MonthGrossProfitOrg";
            this.SupFt_MonthGrossProfitOrg.Height = 0.15625F;
            this.SupFt_MonthGrossProfitOrg.Left = 6.875F;
            this.SupFt_MonthGrossProfitOrg.MultiLine = false;
            this.SupFt_MonthGrossProfitOrg.Name = "SupFt_MonthGrossProfitOrg";
            this.SupFt_MonthGrossProfitOrg.OutputFormat = resources.GetString("SupFt_MonthGrossProfitOrg.OutputFormat");
            this.SupFt_MonthGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_MonthGrossProfitOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_MonthGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_MonthGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_MonthGrossProfitOrg.Text = "1234,567,890";
            this.SupFt_MonthGrossProfitOrg.Top = 0.25F;
            this.SupFt_MonthGrossProfitOrg.Visible = false;
            this.SupFt_MonthGrossProfitOrg.Width = 0.71875F;
            // 
            // SupFt_AnnualGrossProfitOrg
            // 
            this.SupFt_AnnualGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_AnnualGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_AnnualGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_AnnualGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_AnnualGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_AnnualGrossProfitOrg.DataField = "AnnualGrossProfitOrg";
            this.SupFt_AnnualGrossProfitOrg.Height = 0.15625F;
            this.SupFt_AnnualGrossProfitOrg.Left = 9.375F;
            this.SupFt_AnnualGrossProfitOrg.MultiLine = false;
            this.SupFt_AnnualGrossProfitOrg.Name = "SupFt_AnnualGrossProfitOrg";
            this.SupFt_AnnualGrossProfitOrg.OutputFormat = resources.GetString("SupFt_AnnualGrossProfitOrg.OutputFormat");
            this.SupFt_AnnualGrossProfitOrg.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-weight: bold; font-size" +
                ": 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_AnnualGrossProfitOrg.SummaryGroup = "SupplierHeader";
            this.SupFt_AnnualGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_AnnualGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_AnnualGrossProfitOrg.Text = "1234,567,890";
            this.SupFt_AnnualGrossProfitOrg.Top = 0.25F;
            this.SupFt_AnnualGrossProfitOrg.Visible = false;
            this.SupFt_AnnualGrossProfitOrg.Width = 0.71875F;
            // 
            // DCTOK02112P_01A4C
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
            this.PrintWidth = 10.81F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.WarehouseHeader2);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.EmployeeHeader);
            this.Sections.Add(this.MakerHeader);
            this.Sections.Add(this.GoodsLGroupHeader);
            this.Sections.Add(this.GoodsMGroupHeader);
            this.Sections.Add(this.BLGroupCodeHeader);
            this.Sections.Add(this.BLGoodsCodeHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.BLGoodsCodeFooter);
            this.Sections.Add(this.BLGroupCodeFooter);
            this.Sections.Add(this.GoodsMGroupFooter);
            this.Sections.Add(this.GoodsLGroupFooter);
            this.Sections.Add(this.MakerFooter);
            this.Sections.Add(this.EmployeeFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.SupplierFooter);
            this.Sections.Add(this.WarehouseFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.WarehouseFooter2);
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
            this.PageEnd += new System.EventHandler(this.DCZAI02103P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCZAI02103P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeNameFull20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailTitleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailTitleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LB_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnnualTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsLGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DetailTitleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_WarehouseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_WarehouseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MediumGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MediumGoodsGanreName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_DetailGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_DetailGoodsGanreName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_LargeGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_LargeGoodsGanreName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarHd_WarehouseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Hd_WarehouseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Hd_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Hd_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.War2Ft_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlSalesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_MonthPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualPureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_MonthGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_AnnualGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion


        
    }
}
