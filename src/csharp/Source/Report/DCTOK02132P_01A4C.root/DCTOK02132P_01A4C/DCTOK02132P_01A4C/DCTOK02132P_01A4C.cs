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
    /// <br></br>
    /// <br>Update Note  : 2008.10.16 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
    /// <br>             :</br>
    /// <br>UpdateNote   : 2008/11/04 30462 行澤仁美　バグ修正</br>
    /// <br>Update Note  : 2008.10.16 30452 上野 俊治</br>
    /// <br>              ・担当者別の場合の障害対応(ID:8965,8966)</br>
    /// <br>              ・集計方法「全社」の場合、拠点を表示しない(ID:8964)</br>
    /// <br>Update Note  : 2009/04/15 張莉莉</br>
    /// <br>              ・売上推移表（仕入先別）の追加</br>
    /// <br>Update Note  : 2009/06/24 張莉莉</br>
    /// <br>              ・仕入コードは「0」の場合、仕入名は「未登録」へ変更</br>
    /// <br>Update Note  : 2013/10/25 鄭慕鈞</br>
    /// <br>              ・Redmine#40089【神姫産業】№2105　売上推移表 桁あふれの不具合の対応</br>
    /// <br>Update Note  : 2013/11/06 鄭慕鈞</br>
    /// <br>              ・Redmine#40089 システムテスト障害№20の対応</br>
    /// </remarks>
    public class DCTOK02132P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
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
        public DCTOK02132P_01A4C ()
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

        private SalesTransListCndtn _salesTransListCndtn;				// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private TextBox SecHd_AddUpSecCode;
        private TextBox SecHd_SectionGuideNm;
        private Label Lb_BLGoodsCode;
        private TextBox SalesMoney1;
        private TextBox GoodsLGroupCode;
        private TextBox GoodsMGroupCode;
        private TextBox BLGroupCode;
        private TextBox BLGoodsCode;
        private Label Lb_BLGroupCode;
        private Label Lb_Month1;
        private TextBox Ttl_SalesMoney1;
        private TextBox SecFt_SalesMoney1;
        private TextBox CusFt_SalesMoney1;
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
        private TextBox BlFt_SalesMoney1;
        private TextBox MggFt_SalesMoney1;
        private TextBox DggFt_SalesMoney1;
        private TextBox LggFt_SalesMoney1;
        private TextBox MakFt_SalesMoney1;
        private GroupHeader EmployeeHeader;
        private GroupFooter EmployeeFooter;
        private Line line21;
        private TextBox textBox36;
        private TextBox EmpFt_SalesMoney1;
        private TextBox BlFt_BLGoodsCode;
        private TextBox BlFt_BLGoodsFullName;
        private TextBox MggFt_GoodsMGroupCode;
        private TextBox MggFt_GoodsMGroupName;
        private TextBox DggFt_BLGroupCode;
        private TextBox DggFt_BLGroupCodeName;
        private TextBox LggFt_GoodsLGroupCode;
        private TextBox LggFt_GoodsLGroupName;
        private TextBox MakFt_GoodsMakerCd;
        private TextBox MakFt_MakerName;
        private Line Line_DetailHead;

        // Disposeチェック用フラグ
        bool disposed = false;
        private TextBox SalesMoney2;
        private TextBox SalesMoney3;
        private TextBox SalesMoney4;
        private TextBox SalesMoney5;
        private TextBox SalesMoney6;
        private TextBox SalesMoney7;
        private TextBox SalesMoney8;
        private TextBox SalesMoney10;
        private TextBox SalesMoney9;
        private TextBox SalesMoney11;
        private TextBox SalesMoney12;
        private TextBox TotalSalesCount1;
        private TextBox TotalSalesCount12;
        private TextBox TotalSalesCount2;
        private TextBox TotalSalesCount3;
        private TextBox TotalSalesCount4;
        private TextBox TotalSalesCount5;
        private TextBox TotalSalesCount6;
        private TextBox TotalSalesCount7;
        private TextBox TotalSalesCount8;
        private TextBox TotalSalesCount9;
        private TextBox TotalSalesCount10;
        private TextBox TotalSalesCount11;
        private Label Lb_Month2;
        private Label Lb_Month3;
        private Label Lb_Month4;
        private Label Lb_Month7;
        private Label Lb_Month5;
        private Label Lb_Month6;
        private Label Lb_Month11;
        private Label Lb_Month8;
        private Label Lb_Month9;
        private Label Lb_Month10;
        private Label Lb_Month12;
        private TextBox BlFt_SalesMoney2;
        private TextBox BlFt_SalesMoney3;
        private TextBox BlFt_SalesMoney4;
        private TextBox BlFt_SalesMoney5;
        private TextBox BlFt_SalesMoney6;
        private TextBox BlFt_SalesMoney7;
        private TextBox BlFt_SalesMoney8;
        private TextBox BlFt_SalesMoney9;
        private TextBox BlFt_SalesMoney10;
        private TextBox BlFt_SalesMoney11;
        private TextBox BlFt_SalesMoney12;
        private TextBox BlFt_TotalSalesCount1;
        private TextBox BlFt_TotalSalesCount2;
        private TextBox BlFt_TotalSalesCount3;
        private TextBox BlFt_TotalSalesCount4;
        private TextBox BlFt_TotalSalesCount5;
        private TextBox BlFt_TotalSalesCount6;
        private TextBox BlFt_TotalSalesCount7;
        private TextBox BlFt_TotalSalesCount8;
        private TextBox BlFt_TotalSalesCount9;
        private TextBox BlFt_TotalSalesCount10;
        private TextBox BlFt_TotalSalesCount11;
        private TextBox BlFt_TotalSalesCount12;
        private TextBox MggFt_SalesMoney2;
        private TextBox MggFt_SalesMoney3;
        private TextBox MggFt_SalesMoney4;
        private TextBox MggFt_SalesMoney5;
        private TextBox MggFt_SalesMoney6;
        private TextBox MggFt_SalesMoney7;
        private TextBox MggFt_SalesMoney11;
        private TextBox MggFt_SalesMoney10;
        private TextBox MggFt_SalesMoney9;
        private TextBox MggFt_SalesMoney8;
        private TextBox MggFt_SalesMoney12;
        private TextBox DggFt_SalesMoney2;
        private TextBox DggFt_SalesMoney3;
        private TextBox DggFt_SalesMoney4;
        private TextBox DggFt_SalesMoney5;
        private TextBox DggFt_SalesMoney6;
        private TextBox DggFt_SalesMoney11;
        private TextBox DggFt_SalesMoney8;
        private TextBox DggFt_SalesMoney9;
        private TextBox DggFt_SalesMoney10;
        private TextBox DggFt_SalesMoney12;
        private TextBox DggFt_SalesMoney7;
        private TextBox DggFt_TotalSalesCount1;
        private TextBox DggFt_TotalSalesCount2;
        private TextBox DggFt_TotalSalesCount3;
        private TextBox DggFt_TotalSalesCount4;
        private TextBox DggFt_TotalSalesCount5;
        private TextBox DggFt_TotalSalesCount6;
        private TextBox DggFt_TotalSalesCount7;
        private TextBox DggFt_TotalSalesCount8;
        private TextBox DggFt_TotalSalesCount9;
        private TextBox DggFt_TotalSalesCount10;
        private TextBox DggFt_TotalSalesCount11;
        private TextBox DggFt_TotalSalesCount12;
        private TextBox MggFt_TotalSalesCount1;
        private TextBox MggFt_TotalSalesCount2;
        private TextBox MggFt_TotalSalesCount3;
        private TextBox MggFt_TotalSalesCount4;
        private TextBox MggFt_TotalSalesCount5;
        private TextBox MggFt_TotalSalesCount6;
        private TextBox MggFt_TotalSalesCount7;
        private TextBox MggFt_TotalSalesCount8;
        private TextBox MggFt_TotalSalesCount9;
        private TextBox MggFt_TotalSalesCount10;
        private TextBox MggFt_TotalSalesCount11;
        private TextBox MggFt_TotalSalesCount12;
        private TextBox LggFt_SalesMoney2;
        private TextBox LggFt_SalesMoney3;
        private TextBox LggFt_SalesMoney5;
        private TextBox LggFt_SalesMoney4;
        private TextBox LggFt_SalesMoney6;
        private TextBox LggFt_SalesMoney7;
        private TextBox LggFt_SalesMoney8;
        private TextBox LggFt_SalesMoney9;
        private TextBox LggFt_SalesMoney10;
        private TextBox LggFt_SalesMoney11;
        private TextBox LggFt_SalesMoney12;
        private TextBox LggFt_TotalSalesCount1;
        private TextBox LggFt_TotalSalesCount2;
        private TextBox LggFt_TotalSalesCount3;
        private TextBox LggFt_TotalSalesCount5;
        private TextBox LggFt_TotalSalesCount4;
        private TextBox LggFt_TotalSalesCount6;
        private TextBox LggFt_TotalSalesCount7;
        private TextBox LggFt_TotalSalesCount8;
        private TextBox LggFt_TotalSalesCount9;
        private TextBox LggFt_TotalSalesCount10;
        private TextBox LggFt_TotalSalesCount11;
        private TextBox LggFt_TotalSalesCount12;
        private TextBox MakFt_SalesMoney2;
        private TextBox MakFt_SalesMoney4;
        private TextBox MakFt_SalesMoney3;
        private TextBox MakFt_SalesMoney5;
        private TextBox MakFt_SalesMoney6;
        private TextBox MakFt_SalesMoney7;
        private TextBox MakFt_SalesMoney8;
        private TextBox MakFt_SalesMoney9;
        private TextBox MakFt_SalesMoney10;
        private TextBox MakFt_SalesMoney11;
        private TextBox MakFt_SalesMoney12;
        private TextBox MakFt_TotalSalesCount1;
        private TextBox MakFt_TotalSalesCount2;
        private TextBox MakFt_TotalSalesCount4;
        private TextBox MakFt_TotalSalesCount3;
        private TextBox MakFt_TotalSalesCount5;
        private TextBox MakFt_TotalSalesCount6;
        private TextBox MakFt_TotalSalesCount7;
        private TextBox MakFt_TotalSalesCount8;
        private TextBox MakFt_TotalSalesCount9;
        private TextBox MakFt_TotalSalesCount10;
        private TextBox MakFt_TotalSalesCount11;
        private TextBox MakFt_TotalSalesCount12;
        private TextBox Ttl_SalesMoney3;
        private TextBox Ttl_SalesMoney2;
        private TextBox SecFt_SalesMoney2;
        private TextBox SecFt_SalesMoney3;
        private TextBox SecFt_SalesMoney5;
        private TextBox SecFt_SalesMoney4;
        private TextBox SecFt_SalesMoney6;
        private TextBox SecFt_SalesMoney7;
        private TextBox SecFt_SalesMoney8;
        private TextBox SecFt_SalesMoney9;
        private TextBox SecFt_SalesMoney10;
        private TextBox SecFt_SalesMoney11;
        private TextBox SecFt_SalesMoney12;
        private TextBox SecFt_TotalSalesCount1;
        private TextBox SecFt_TotalSalesCount2;
        private TextBox SecFt_TotalSalesCount3;
        private TextBox SecFt_TotalSalesCount5;
        private TextBox SecFt_TotalSalesCount4;
        private TextBox SecFt_TotalSalesCount6;
        private TextBox SecFt_TotalSalesCount7;
        private TextBox SecFt_TotalSalesCount8;
        private TextBox SecFt_TotalSalesCount9;
        private TextBox SecFt_TotalSalesCount10;
        private TextBox SecFt_TotalSalesCount11;
        private TextBox SecFt_TotalSalesCount12;
        private TextBox CusFt_SalesMoney2;
        private TextBox CusFt_SalesMoney3;
        private TextBox CusFt_SalesMoney5;
        private TextBox CusFt_SalesMoney6;
        private TextBox CusFt_SalesMoney4;
        private TextBox CusFt_SalesMoney7;
        private TextBox CusFt_SalesMoney8;
        private TextBox CusFt_SalesMoney9;
        private TextBox CusFt_SalesMoney11;
        private TextBox CusFt_SalesMoney12;
        private TextBox CusFt_SalesMoney10;
        private TextBox CusFt_TotalSalesCount1;
        private TextBox CusFt_TotalSalesCount2;
        private TextBox CusFt_TotalSalesCount3;
        private TextBox CusFt_TotalSalesCount5;
        private TextBox CusFt_TotalSalesCount6;
        private TextBox CusFt_TotalSalesCount4;
        private TextBox CusFt_TotalSalesCount7;
        private TextBox CusFt_TotalSalesCount8;
        private TextBox CusFt_TotalSalesCount9;
        private TextBox CusFt_TotalSalesCount11;
        private TextBox CusFt_TotalSalesCount12;
        private TextBox CusFt_TotalSalesCount10;
        private TextBox EmpFt_SalesMoney2;
        private TextBox EmpFt_SalesMoney3;
        private TextBox EmpFt_SalesMoney4;
        private TextBox EmpFt_SalesMoney5;
        private TextBox EmpFt_SalesMoney6;
        private TextBox EmpFt_SalesMoney7;
        private TextBox EmpFt_SalesMoney8;
        private TextBox EmpFt_SalesMoney9;
        private TextBox EmpFt_SalesMoney10;
        private TextBox EmpFt_SalesMoney11;
        private TextBox EmpFt_SalesMoney12;
        private TextBox EmpFt_TotalSalesCount1;
        private TextBox EmpFt_TotalSalesCount2;
        private TextBox EmpFt_TotalSalesCount3;
        private TextBox EmpFt_TotalSalesCount4;
        private TextBox EmpFt_TotalSalesCount5;
        private TextBox EmpFt_TotalSalesCount6;
        private TextBox EmpFt_TotalSalesCount7;
        private TextBox EmpFt_TotalSalesCount8;
        private TextBox EmpFt_TotalSalesCount9;
        private TextBox EmpFt_TotalSalesCount10;
        private TextBox EmpFt_TotalSalesCount11;
        private TextBox EmpFt_TotalSalesCount12;
        private TextBox Ttl_SalesMoney4;
        private TextBox Ttl_SalesMoney5;
        private TextBox Ttl_SalesMoney6;
        private TextBox Ttl_SalesMoney7;
        private TextBox Ttl_SalesMoney8;
        private TextBox Ttl_SalesMoney9;
        private TextBox Ttl_SalesMoney10;
        private TextBox Ttl_SalesMoney11;
        private TextBox Ttl_SalesMoney12;
        private TextBox Ttl_TotalSalesCount1;
        private TextBox Ttl_TotalSalesCount2;
        private TextBox Ttl_TotalSalesCount3;
        private TextBox Ttl_TotalSalesCount4;
        private TextBox Ttl_TotalSalesCount5;
        private TextBox Ttl_TotalSalesCount6;
        private TextBox Ttl_TotalSalesCount7;
        private TextBox Ttl_TotalSalesCount8;
        private TextBox Ttl_TotalSalesCount9;
        private TextBox Ttl_TotalSalesCount10;
        private TextBox Ttl_TotalSalesCount11;
        private TextBox Ttl_TotalSalesCount12;
        private TextBox CodeNameHalf20;
        private TextBox TtlSalesMoney;
        private TextBox TtlTotalSalesCount;
        private TextBox BlFt_TtlSalesMoney;
        private Label Lb_Total;
        private TextBox Ttl_TtlTotalSalesCount;
        private TextBox Ttl_TtlSalesMoney;
        private TextBox SecFt_TtlTotalSalesCount;
        private TextBox SecFt_TtlSalesMoney;
        private TextBox CusFt_TtlTotalSalesCount;
        private TextBox CusFt_TtlSalesMoney;
        private TextBox BlFt_TtlTotalSalesCount;
        private TextBox MggFt_TtlTotalSalesCount;
        private TextBox MggFt_TtlSalesMoney;
        private TextBox DggFt_TtlSalesMoney;
        private TextBox DggFt_TtlTotalSalesCount;
        private TextBox LggFt_TtlTotalSalesCount;
        private TextBox LggFt_TtlSalesMoney;
        private TextBox MakFt_TtlTotalSalesCount;
        private TextBox MakFt_TtlSalesMoney;
        private TextBox EmpFt_TtlTotalSalesCount;
        private TextBox EmpFt_TtlSalesMoney;
        private TextBox GoodsNo;
        private TextBox GoodsNameKana;
        private TextBox CodeNameFull20;
        private Label SecHd_SectionTitle;
        private TextBox CusHd_AddUpSecCode;
        private TextBox CusHd_SectionGuideNm;
        private Label CusHd_SectionTitle;
        private TextBox CusHd_CustomerCode;
        private TextBox CusHd_CustomerSnm;
        private Label CusHd_CustomerTitle;
        private TextBox EmpHd_AddUpSecCode;
        private TextBox EmpHd_SectionGuideNm;
        private Label EmpHd_SectionTitle;
        private TextBox EmpHd_EmployeeCode;
        private TextBox EmpHd_EmployeeName;
        private Label EmpHd_EmployeeTitle;
        private Label Lb_GoodsLGroup;
        private Label Lb_GoodsMGroup;
        private Label Lb_Customer;
        private Label Lb_Employee;
        private Label Lb_Section;
        private TextBox CustomerCode;
        private TextBox EmployeeCode;
        private TextBox SectionCode;
        private TextBox SortTitle;
        private Line line3;
        private Line line4;
        private Line line5;
        private GroupHeader SupplierHeader;
        private GroupFooter SupplierFooter;
        private TextBox SupHd_AddUpSecCode;
        private TextBox SupHd_SectionGuideNm;
        private Label SupHd_SectionTitle;
        private TextBox SupHd_SupplierCode;
        private TextBox SupHd_SupplierSnm;
        private Label SupHd_SupplierTitle;
        private Line line6;
        private Line line7;
        private TextBox Sup_Title;
        private TextBox SupFt_SalesMoney1;
        private TextBox SupFt_SalesMoney2;
        private TextBox SupFt_SalesMoney3;
        private TextBox SupFt_SalesMoney5;
        private TextBox SupFt_SalesMoney6;
        private TextBox SupFt_SalesMoney4;
        private TextBox SupFt_SalesMoney7;
        private TextBox SupFt_SalesMoney8;
        private TextBox SupFt_SalesMoney9;
        private TextBox SupFt_SalesMoney11;
        private TextBox SupFt_SalesMoney12;
        private TextBox SupFt_SalesMoney10;
        private TextBox SupFt_TotalSalesCount1;
        private TextBox SupFt_TotalSalesCount2;
        private TextBox SupFt_TotalSalesCount3;
        private TextBox SupFt_TotalSalesCount5;
        private TextBox SupFt_TotalSalesCount6;
        private TextBox SupFt_TotalSalesCount4;
        private TextBox SupFt_TotalSalesCount7;
        private TextBox SupFt_TotalSalesCount8;
        private TextBox SupFt_TotalSalesCount9;
        private TextBox SupFt_TotalSalesCount11;
        private TextBox SupFt_TotalSalesCount12;
        private TextBox SupFt_TotalSalesCount10;
        private TextBox SupFt_TtlTotalSalesCount;
        private TextBox SupFt_TtlSalesMoney;
        private Label Lb_Supplier;
        private TextBox SupplierCode;

        // 率(%)フォーマット文字列
        private const string _rateFormat = "##0.00"; 

        //-----DEL 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応----->>>>>
        //-----ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応----->>>>>
        //private const string TTLSALESMONEYFORMAT = "************";
        //private const string SALESMONEYFORMAT = "*********";
        //-----ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応-----<<<<<
        //-----DEL 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応-----<<<<<
        //-----ADD 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応----->>>>>
        private const string TTLSALESMONEYFORMAT = "*************";
        private const string SALESMONEYFORMAT = "**********";
        //-----ADD 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応-----<<<<<
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
                this._salesTransListCndtn = (SalesTransListCndtn)this._printInfo.jyoken;
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
                // TODO:  DCTOK02132P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  DCTOK02132P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;				// サブタイトル

            // ソート条件
            SortTitle.Text = this._pageHeaderSortOderTitle; // ADD 2008/10/16

            // 位置調整用
            System.Drawing.PointF point;

            //-------------------------------------------------------
            // 全社集計・拠点別切り替え
            //-------------------------------------------------------
            #region [全社集計・拠点別切り替え]
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._salesTransListCndtn.GroupBySectionDiv == SalesTransListCndtn.GroupBySectionDivState.All )
            //{
            //    // 全社集計
            //    SectionFooter.Visible = false;
            //}
            //else
            //{
            //    // 拠点別
            //    SectionFooter.Visible = true;
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/12/09 -------------------------------->>>>>
            if (this._salesTransListCndtn.TtlType == SalesTransListCndtn.TtlTypeState.All)
            {
                // 集計方法「全社」の場合、拠点を表示しない
                // SectionHeader
                this.SecHd_SectionTitle.Visible = false;
                this.SecHd_AddUpSecCode.Visible = false;
                this.SecHd_SectionGuideNm.Visible = false;

                // CustomerHeader
                this.CusHd_SectionTitle.Visible = false;
                this.CusHd_AddUpSecCode.Visible = false;
                this.CusHd_SectionGuideNm.Visible = false;
                // 位置調整
                this.CusHd_CustomerTitle.Location = this.CusHd_SectionTitle.Location;

                point = this.CusHd_CustomerTitle.Location;
                point.X += this.CusHd_CustomerTitle.Width;

                this.CusHd_CustomerCode.Location = point;
                point.X += this.CusHd_CustomerCode.Width;

                this.CusHd_CustomerSnm.Location = point;

                // EmployeeHeader
                this.EmpHd_SectionTitle.Visible = false;
                this.EmpHd_AddUpSecCode.Visible = false;
                this.EmpHd_SectionGuideNm.Visible = false;
                // 位置調整
                this.EmpHd_EmployeeTitle.Location = this.EmpHd_SectionTitle.Location;

                point = this.EmpHd_EmployeeTitle.Location;
                point.X += this.EmpHd_EmployeeTitle.Width;

                this.EmpHd_EmployeeCode.Location = point;
                point.X += this.EmpHd_EmployeeCode.Width;

                this.EmpHd_EmployeeName.Location = point;

                // --- ADD 2009/04/15 ---------------------------->>>>>
                // SupplierHeader
                this.SupHd_SectionTitle.Visible = false;
                this.SupHd_AddUpSecCode.Visible = false;
                this.SupHd_SectionGuideNm.Visible = false;
                // 位置調整
                this.SupHd_SupplierTitle.Location = this.SupHd_SectionTitle.Location;

                point = this.SupHd_SupplierTitle.Location;
                point.X += this.SupHd_SupplierTitle.Width;

                this.SupHd_SupplierCode.Location = point;
                point.X += this.SupHd_SupplierCode.Width;

                this.SupHd_SupplierSnm.Location = point;
                // --- ADD 2009/04/15 ----------------------------<<<<<

            }
            // --- ADD 2008/12/09 --------------------------------<<<<<
            #endregion [全社集計・拠点別切り替え]

            //-------------------------------------------------------
            // 帳票タイプ別切り替え
            //-------------------------------------------------------
            #region [帳票タイプ別切り替え]
            //switch ( this._salesTransListCndtn.PrintSelectDiv ) // DEL 2008/10/16
            switch (this._salesTransListCndtn.TotalType) // ADD 2008/10/16
            {
                // 得意先別
                //case SalesTransListCndtn.PrintSelectDivState.EachCustomer: // DEL 2008/10/16
                case SalesTransListCndtn.TotalTypeState.EachCustomer: // ADD 2008/10/16
                    {
                        // 拠点
                        SectionHeader.DataField = DCTOK02134EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true; // ADD 2008/10/16

                        // --- ADD 2008/10/16 -------------------------------->>>>>
                        // 表示しない
                        if (this._salesTransListCndtn.DetailDataValue != SalesTransListCndtn.DetailDataValueState.Customer)
                        {
                            SecHd_SectionTitle.Visible = false;
                            SecHd_AddUpSecCode.Visible = false;
                            SecHd_SectionGuideNm.Visible = false;

                            SectionHeader.Height = 0F;
                        }
                        // --- ADD 2008/10/16 --------------------------------<<<<<

                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //// 得意先
                        //CustomerHeader.DataField = string.Empty;
                        //CustomerHeader.Visible = false;
                        //CustomerFooter.Visible = false;

                        //// 担当者
                        //EmployeeHeader.DataField = string.Empty;
                        //EmployeeHeader.Visible = false;
                        //EmployeeFooter.Visible = false;

                        //// メーカー
                        //MakerHeader.DataField = string.Empty;
                        //MakerHeader.Visible = false;
                        //MakerFooter.Visible = false;
                        //// 商品区分グループ
                        //GoodsLGroupHeader.DataField = string.Empty;
                        //GoodsLGroupHeader.Visible = false;
                        //GoodsLGroupFooter.Visible = false;
                        //// 商品区分
                        //GoodsMGroupHeader.DataField = string.Empty;
                        //GoodsMGroupHeader.Visible = false;
                        //GoodsMGroupFooter.Visible = false;
                        //// 商品区分詳細
                        //BLGroupCodeHeader.DataField = string.Empty;
                        //BLGroupCodeHeader.Visible = false;
                        //BLGroupCodeFooter.Visible = false;
                        //// 自社分類
                        //EnterpriseGanreHeader.DataField = string.Empty;
                        //EnterpriseGanreHeader.Visible = false;
                        //EnterpriseGanreFooter.Visible = false;
                        //// ＢＬコード
                        //BLGoodsCodeHeader.DataField = string.Empty;
                        //BLGoodsCodeHeader.Visible = false;
                        //BLGoodsCodeFooter.Visible = false;
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                        // --- ADD 2008/10/16 -------------------------------->>>>>
                        // 得意先
                        CustomerHeader.DataField = DCTOK02134EA.ct_Col_CustomerCode;
                        CustomerHeader.Visible = true;
                        CustomerFooter.Visible = true;

                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // --- ADD 2009/04/15 ----------------->>>>>
                        // 仕入先
                        SupplierHeader.DataField = string.Empty;
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;
                        // --- ADD 2009/04/15 -----------------<<<<<

                        // メーカー
                        MakerHeader.DataField = DCTOK02134EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;
                        // 商品大分類
                        GoodsLGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsLGroup;
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;
                        // 商品中分類
                        GoodsMGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsMGroup;
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;
                        // ＢＬグループコード
                        BLGroupCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGroupCode;
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;
                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;
                        // --- ADD 2008/10/16 --------------------------------<<<<<

                        // 画面の小計印刷チェックによる制御
                        if (this._salesTransListCndtn.SectionSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) SectionFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.CustomerSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None)
                        {
                            //CustomerHeader.DataField = string.Empty; // DEL 2008/10/16
                            CustomerFooter.Visible = false;
                        }
                        if (this._salesTransListCndtn.MakerSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None)
                        {
                            //MakerHeader.DataField = string.Empty; // DEL 2008/10/16
                            MakerFooter.Visible = false;
                        }
                        if (this._salesTransListCndtn.GoodsLGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.GoodsMGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.BLGroupCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.BLGoodsCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false; // ADD 2008/10/16

                        // レイアウト制御
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //GoodsMakerCd.Visible = false;
                        //GoodsLGroupCode.Visible = false;
                        //GoodsMGroupCode.Visible = false;
                        //BLGroupCode.Visible = false;
                        //BLGoodsCode.Visible = false;
                        //EnterpriseGanreCode.Visible = false;
                        //GoodsNo.Visible = false;
                        //GoodsName.Visible = false;
                        //CustomerCode.Visible = true;
                        //CustomerSnm.Visible = true;
                        //EmployeeCode.Visible = false;
                        //EmployeeName.Visible = false;
                        //CustomerCode.Top = GoodsMakerCd.Top;
                        //CustomerSnm.Top = CustomerCode.Top;
                        
                        // タイトル印字・非印字制御
                        //Lb_MakerName.Visible = false;
                        //Lb_BLGroupCode.Visible = false;
                        //Lb_GoodsNo.Visible = false;
                        //Lb_GoodsName.Visible = false;
                        //Lb_BLGoodsCode.Visible = false;
                        //Lb_EnterpriseGanre.Visible = false;
                        //Lb_Customer.Visible = true;
                        //Lb_Employee.Visible = false;
                        //Lb_Customer.Top = Lb_MakerName.Top;
                        //Lb_Customer.Left = Lb_MakerName.Left;
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                    }
                    break;
                // 担当者別
                // case SalesTransListCndtn.PrintSelectDivState.EachEmployee: // DEL 2008/10/16
                case SalesTransListCndtn.TotalTypeState.EachEmployee: // ADD 2008/10/16
                    {
                        // 拠点
                        SectionHeader.DataField = DCTOK02134EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true; // ADD 2008/10/16

                        // --- ADD 2008/10/16 -------------------------------->>>>>
                        // 表示しない
                        //if (this._salesTransListCndtn.DetailDataValue != SalesTransListCndtn.DetailDataValueState.Customer) // DEL 2008/12/09
                        if (this._salesTransListCndtn.DetailDataValue != SalesTransListCndtn.DetailDataValueState.Employee) // ADD 2008/12/09
                        {
                            SecHd_SectionTitle.Visible = false;
                            SecHd_AddUpSecCode.Visible = false;
                            SecHd_SectionGuideNm.Visible = false;

                            SectionHeader.Height = 0F;
                        }
                        // --- ADD 2008/10/16 --------------------------------<<<<<

                        // 得意先
                        CustomerHeader.DataField = string.Empty;
                        CustomerHeader.Visible = false;
                        CustomerFooter.Visible = false;

                        // --- ADD 2009/04/15 ----------------->>>>>
                        // 仕入先
                        SupplierHeader.DataField = string.Empty;
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;
                        // --- ADD 2009/04/15 -----------------<<<<<

                        // 担当者
                        //EmployeeHeader.DataField = string.Empty; // DEL 2008/12/09
                        EmployeeHeader.DataField = DCTOK02134EA.ct_Col_EmployeeCode; // ADD 2008/12/09
                        EmployeeHeader.Visible = true;
                        EmployeeFooter.Visible = true;

                        // メーカー
                        MakerHeader.DataField = DCTOK02134EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;

                        // 商品大分類
                        GoodsLGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsLGroup;
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;
                        // 商品中分類
                        GoodsMGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsMGroup;
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;
                        // ＢＬグループコード
                        BLGroupCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGroupCode;
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //// 自社分類
                        //EnterpriseGanreHeader.DataField = string.Empty;
                        //EnterpriseGanreHeader.Visible = false;
                        //EnterpriseGanreFooter.Visible = false;
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;

                        // 画面の計印刷チェックによる制御
                        if (this._salesTransListCndtn.SectionSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) SectionFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.EmployeeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None)
                        {
                            //EmployeeHeader.DataField = string.Empty; // DEL 2008/10/16
                            EmployeeFooter.Visible = false;
                        }
                        if (this._salesTransListCndtn.MakerSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None)
                        {
                            //MakerHeader.DataField = string.Empty; // DEL 2008/10/16
                            MakerFooter.Visible = false;
                        }
                        if (this._salesTransListCndtn.GoodsLGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.GoodsMGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.BLGroupCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false; // ADD 2008/10/16
                        if (this._salesTransListCndtn.BLGoodsCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false; // ADD 2008/10/16

                        // レイアウト制御
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //GoodsMakerCd.Visible = false;
                        //GoodsLGroupCode.Visible = false;
                        //GoodsMGroupCode.Visible = false;
                        //BLGroupCode.Visible = false;
                        //EnterpriseGanreCode.Visible = false;
                        //BLGoodsCode.Visible = false;
                        //GoodsNo.Visible = false;
                        //GoodsName.Visible = false;
                        //CustomerCode.Visible = false;
                        //CustomerSnm.Visible = false;
                        //EmployeeCode.Visible = true;
                        //EmployeeName.Visible = true;
                        //EmployeeCode.Top = GoodsMakerCd.Top;
                        //EmployeeName.Top = EmployeeCode.Top;
                        

                        //// タイトル印字・非印字制御
                        //Lb_MakerName.Visible = false;
                        //Lb_BLGroupCode.Visible = false;
                        //Lb_GoodsNo.Visible = false;
                        //Lb_GoodsName.Visible = false;
                        //Lb_EnterpriseGanre.Visible = false;
                        //Lb_BLGoodsCode.Visible = false;
                        //Lb_Customer.Visible = false;
                        //Lb_Employee.Visible = true;
                        //Lb_Employee.Top = Lb_MakerName.Top;
                        //Lb_Employee.Left = Lb_MakerName.Left;
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                    }
                    break;
                // 商品別
                //case SalesTransListCndtn.PrintSelectDivState.EachGoods: // DEL 2008/10/16
                case SalesTransListCndtn.TotalTypeState.EachGoods: // ADD 2008/10/16
                    {
                        // 拠点
                        SectionHeader.DataField = DCTOK02134EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        // 得意先
                        CustomerHeader.DataField = string.Empty;
                        CustomerHeader.Visible = false;
                        CustomerFooter.Visible = false;
                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // --- ADD 2009/04/15 ----------------->>>>>
                        // 仕入先
                        SupplierHeader.DataField = string.Empty;
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;
                        // --- ADD 2009/04/15 -----------------<<<<<

                        // メーカー
                        MakerHeader.DataField = DCTOK02134EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;
                        // 商品区分グループ
                        GoodsLGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsLGroup;
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;
                        // 商品区分
                        GoodsMGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsMGroup;
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;
                        // 商品区分詳細
                        BLGroupCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGroupCode;
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //// 自社分類
                        //EnterpriseGanreHeader.DataField = DCTOK02134EA.ct_Col_EnterpriseGanreCode;
                        //EnterpriseGanreHeader.Visible = true;
                        //EnterpriseGanreFooter.Visible = true;
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;

                        // 画面の計印刷チェックによる制御
                        if (this._salesTransListCndtn.SectionSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) SectionFooter.Visible = false; // ADD 2008/10/16
                        if ( this._salesTransListCndtn.MakerSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None )
                        {
                            //MakerHeader.DataField = string.Empty; // DEL 2008/10/16
                            MakerFooter.Visible = false;
                        }
                        //if ( this._salesTransListCndtn.LGoodsGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None ) // DEL 2008/10/16
                        if (this._salesTransListCndtn.GoodsLGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) // ADD 2008/10/16
                        {
                            //GoodsLGroupHeader.DataField = string.Empty; // DEL 2008/10/16
                            GoodsLGroupFooter.Visible = false;
                        }
                        //if ( this._salesTransListCndtn.MGoodsGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None ) // DEL 2008/10/16
                        if (this._salesTransListCndtn.GoodsMGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) // ADD 2008/10/16
                        {
                            //GoodsMGroupHeader.DataField = string.Empty; // DEL 2008/10/16
                            GoodsMGroupFooter.Visible = false;
                        }
                        //if ( this._salesTransListCndtn.DGoodsGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None ) // DEL 2008/10/16
                        if (this._salesTransListCndtn.BLGroupCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) // ADD 2008/10/16
                        {
                            //BLGroupCodeHeader.DataField = string.Empty; // DEL 2008/10/16
                            BLGroupCodeFooter.Visible = false;
                        }
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //if ( this._salesTransListCndtn.EnterpriseGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None )
                        //{
                        //    EnterpriseGanreHeader.DataField = string.Empty;
                        //    EnterpriseGanreFooter.Visible = false;
                        //}
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                        //if ( this._salesTransListCndtn.BLCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None ) // DEL 2008/10/16
                        if (this._salesTransListCndtn.BLGoodsCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) // ADD 2008/10/16
                        {
                            //BLGoodsCodeHeader.DataField = string.Empty; // DEL 2008/10/16
                            BLGoodsCodeFooter.Visible = false;
                        }

                        // レイアウト制御
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //GoodsMakerCd.Visible = true;
                        //GoodsLGroupCode.Visible = true;
                        //GoodsMGroupCode.Visible = true;
                        //BLGroupCode.Visible = true;
                        //EnterpriseGanreCode.Visible = true;
                        //BLGoodsCode.Visible = true;
                        //GoodsNo.Visible = true;
                        //GoodsName.Visible = true;
                        //CustomerCode.Visible = false;
                        //CustomerSnm.Visible = false;
                        //EmployeeCode.Visible = false;
                        //EmployeeName.Visible = false;
                        

                        // タイトル印字・非印字制御
                        //Lb_MakerName.Visible = true;
                        //Lb_BLGroupCode.Visible = true;
                        //Lb_EnterpriseGanre.Visible = true;
                        //Lb_GoodsNo.Visible = true;
                        //Lb_GoodsName.Visible = true;
                        //Lb_BLGoodsCode.Visible = true;
                        //Lb_Customer.Visible = false;
                        //Lb_Employee.Visible = false;
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                    }
                    break;
                // --- ADD 2009/04/15 ------------------------->>>>>
                // 仕入先別
                case SalesTransListCndtn.TotalTypeState.EachSupplier:
                    {
                        // 拠点
                        SectionHeader.DataField = DCTOK02134EA.ct_Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true;

                        // 表示しない
                        if (this._salesTransListCndtn.DetailDataValue != SalesTransListCndtn.DetailDataValueState.Supplier)
                        {
                            SecHd_SectionTitle.Visible = false;
                            SecHd_AddUpSecCode.Visible = false;
                            SecHd_SectionGuideNm.Visible = false;

                            SectionHeader.Height = 0F;
                        }
                        // 得意先
                        CustomerHeader.DataField = string.Empty;
                        CustomerHeader.Visible = false;
                        CustomerFooter.Visible = false;
                        // 担当者
                        EmployeeHeader.DataField = string.Empty;
                        EmployeeHeader.Visible = false;
                        EmployeeFooter.Visible = false;

                        // 仕入先
                        SupplierHeader.DataField = DCTOK02134EA.ct_Col_SupplierCode;
                        SupplierHeader.Visible = true;
                        SupplierFooter.Visible = true;

                        // メーカー
                        MakerHeader.DataField = DCTOK02134EA.ct_Col_GoodsMakerCd;
                        MakerHeader.Visible = true;
                        MakerFooter.Visible = true;
                        // 商品区分グループ
                        GoodsLGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsLGroup;
                        GoodsLGroupHeader.Visible = true;
                        GoodsLGroupFooter.Visible = true;
                        // 商品区分
                        GoodsMGroupHeader.DataField = DCTOK02134EA.ct_Col_GoodsMGroup;
                        GoodsMGroupHeader.Visible = true;
                        GoodsMGroupFooter.Visible = true;
                        // 商品区分詳細
                        BLGroupCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGroupCode;
                        BLGroupCodeHeader.Visible = true;
                        BLGroupCodeFooter.Visible = true;
                        // ＢＬコード
                        BLGoodsCodeHeader.DataField = DCTOK02134EA.ct_Col_BLGoodsCode;
                        BLGoodsCodeHeader.Visible = true;
                        BLGoodsCodeFooter.Visible = true;

                        // 画面の小計印刷チェックによる制御
                        if (this._salesTransListCndtn.SectionSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) SectionFooter.Visible = false;
                        if (this._salesTransListCndtn.SupplierSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None)
                        {
                            SupplierFooter.Visible = false;
                        }
                        if (this._salesTransListCndtn.MakerSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None)
                        {
                            MakerFooter.Visible = false;
                        }
                        if (this._salesTransListCndtn.GoodsLGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) GoodsLGroupFooter.Visible = false; 
                        if (this._salesTransListCndtn.GoodsMGroupSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) GoodsMGroupFooter.Visible = false; 
                        if (this._salesTransListCndtn.BLGroupCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) BLGroupCodeFooter.Visible = false; 
                        if (this._salesTransListCndtn.BLGoodsCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.None) BLGoodsCodeFooter.Visible = false; 

                    }
                    break;
                // --- ADD 2009/04/15 -------------------------<<<<<
                default:
                    break;
            }
            #endregion [帳票タイプ別切り替え]

            // --- ADD 2008/10/16 -------------------------------->>>>>
            //-------------------------------------------------------
            // 明細単位設定適用
            //-------------------------------------------------------
            #region 明細単位設定
            switch (this._salesTransListCndtn.DetailDataValue)
            {
                case SalesTransListCndtn.DetailDataValueState.GoosNo:
                    break;
                case SalesTransListCndtn.DetailDataValueState.BLGoodsCode:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;

                        this.Lb_GoodsLGroup.Visible = true;
                        this.Lb_GoodsMGroup.Visible = true;

                        point = this.Lb_BLGroupCode.Location;
                        this.Lb_GoodsLGroup.Location = point;

                        point.X += this.Lb_GoodsLGroup.Width;
                        this.Lb_GoodsMGroup.Location = point;

                        point.X += this.Lb_GoodsMGroup.Width;
                        this.Lb_BLGroupCode.Location = point;

                        point.X += this.Lb_BLGroupCode.Width;
                        this.Lb_BLGoodsCode.Location = point;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;

                        this.GoodsLGroupCode.Visible = true;
                        this.GoodsMGroupCode.Visible = true;
                        this.CodeNameHalf20.Visible = true;

                        point = this.BLGroupCode.Location;
                        this.GoodsLGroupCode.Location = point;

                        point.X += this.GoodsLGroupCode.Width;
                        this.GoodsMGroupCode.Location = point;

                        point.X += this.GoodsMGroupCode.Width;
                        this.BLGroupCode.Location = point;

                        point.X += this.BLGroupCode.Width;
                        this.BLGoodsCode.Location = point;

                        point.X += this.BLGoodsCode.Width;
                        this.CodeNameHalf20.Location = point;

                        // 名称のDataField設定
                        this.CodeNameHalf20.DataField = DCTOK02134EA.ct_Col_BLGoodsHalfName;
                    }
                    break;
                case SalesTransListCndtn.DetailDataValueState.BLGroupCode:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;

                        this.Lb_GoodsLGroup.Visible = true;
                        this.Lb_GoodsMGroup.Visible = true;

                        point = this.Lb_BLGroupCode.Location;
                        this.Lb_GoodsLGroup.Location = point;

                        point.X += this.Lb_GoodsLGroup.Width;
                        this.Lb_GoodsMGroup.Location = point;

                        point.X += this.Lb_GoodsMGroup.Width;
                        this.Lb_BLGroupCode.Location = point;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;

                        this.GoodsLGroupCode.Visible = true;
                        this.GoodsMGroupCode.Visible = true;
                        this.CodeNameHalf20.Visible = true;

                        point = this.BLGroupCode.Location;
                        this.GoodsLGroupCode.Location = point;

                        point.X += this.GoodsLGroupCode.Width;
                        this.GoodsMGroupCode.Location = point;

                        point.X += this.GoodsMGroupCode.Width;
                        this.BLGroupCode.Location = point;

                        point.X += this.BLGroupCode.Width;
                        this.CodeNameHalf20.Location = point;

                        // 名称のDataField設定
                        this.CodeNameHalf20.DataField = DCTOK02134EA.ct_Col_BLGroupKanaName;
                    }
                    break;
                case SalesTransListCndtn.DetailDataValueState.GoodsMGroup:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;

                        this.Lb_GoodsLGroup.Visible = true;
                        this.Lb_GoodsMGroup.Visible = true;

                        point = this.Lb_BLGroupCode.Location;
                        this.Lb_GoodsLGroup.Location = point;

                        point.X += this.Lb_GoodsLGroup.Width;
                        this.Lb_GoodsMGroup.Location = point;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;

                        this.GoodsLGroupCode.Visible = true;
                        this.GoodsMGroupCode.Visible = true;
                        this.CodeNameHalf20.Visible = true;

                        point = this.BLGroupCode.Location;
                        this.GoodsLGroupCode.Location = point;

                        point.X += this.GoodsLGroupCode.Width;
                        this.GoodsMGroupCode.Location = point;

                        point.X += this.GoodsMGroupCode.Width;
                        this.CodeNameHalf20.Location = point;

                        // 名称のDataField設定
                        this.CodeNameHalf20.DataField = DCTOK02134EA.ct_Col_GoodsMGroupName;
                    }
                    break;
                case SalesTransListCndtn.DetailDataValueState.GoodsLGroup:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;
                        this.Lb_GoodsMGroup.Visible = false;

                        this.Lb_GoodsLGroup.Visible = true;

                        point = this.Lb_BLGroupCode.Location;
                        this.Lb_GoodsLGroup.Location = point;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;

                        this.GoodsLGroupCode.Visible = true;
                        this.CodeNameHalf20.Visible = true;

                        point = this.BLGroupCode.Location;
                        this.GoodsLGroupCode.Location = point;

                        point.X += this.GoodsLGroupCode.Width;
                        this.CodeNameHalf20.Location = point;

                        // 名称のDataField設定
                        this.CodeNameHalf20.DataField = DCTOK02134EA.ct_Col_GoodsLGroupName;
                    }
                    break;
                case SalesTransListCndtn.DetailDataValueState.GoodsMaker:
                    {
                        if (this._salesTransListCndtn.TotalType
                            == SalesTransListCndtn.TotalTypeState.EachGoods)
                        {
                            // 商品別の場合、メーカーで改行させない
                            this.MakerHeader.Visible = false;
                        }

                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;
                        this.Lb_GoodsMGroup.Visible = false;
                        this.Lb_GoodsLGroup.Visible = false;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;

                        this.CodeNameHalf20.Visible = true;

                        point = this.BLGroupCode.Location;
                        this.CodeNameHalf20.Location = point;

                        // 名称のDataField設定
                        this.CodeNameHalf20.DataField = DCTOK02134EA.ct_Col_MakerShortName;
                    }
                    break;
                case SalesTransListCndtn.DetailDataValueState.Customer:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;
                        this.Lb_GoodsMGroup.Visible = false;
                        this.Lb_GoodsLGroup.Visible = false;
                        this.Lb_MakerName.Visible = false;

                        this.Lb_Customer.Visible = true;
                        this.Lb_Customer.Location = this.Lb_MakerName.Location;

                        // 明細ヘッダ
                        this.CustomerHeader.Visible = false;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        this.CustomerCode.Visible = true;
                        this.CodeNameFull20.Visible = true;

                        point = this.GoodsMakerCd.Location;
                        this.CustomerCode.Location = point;

                        point.X += this.CustomerCode.Width;
                        this.CodeNameFull20.Location = point;

                        this.CodeNameFull20.DataField = DCTOK02134EA.ct_Col_CustomerSnm;
                    }
                    break;
                // --- ADD 2009/04/15 ------------------------------------>>>>>
                case SalesTransListCndtn.DetailDataValueState.Supplier:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;
                        this.Lb_GoodsMGroup.Visible = false;
                        this.Lb_GoodsLGroup.Visible = false;
                        this.Lb_MakerName.Visible = false;

                        this.Lb_Supplier.Visible = true;
                        this.Lb_Supplier.Location = this.Lb_MakerName.Location;

                        // 明細ヘッダ
                        this.SupplierHeader.Visible = false;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        this.SupplierCode.Visible = true;
                        this.CodeNameFull20.Visible = true;

                        point = this.GoodsMakerCd.Location;
                        this.SupplierCode.Location = point;

                        point.X += this.SupplierCode.Width;
                        this.CodeNameFull20.Location = point;

                        this.CodeNameFull20.DataField = DCTOK02134EA.ct_Col_SupplierSnm;
                    }
                    break;
                // --- ADD 2009/04/15 ------------------------------------<<<<<
                case SalesTransListCndtn.DetailDataValueState.Employee:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;
                        this.Lb_GoodsMGroup.Visible = false;
                        this.Lb_GoodsLGroup.Visible = false;
                        this.Lb_MakerName.Visible = false;

                        this.Lb_Employee.Visible = true;
                        this.Lb_Employee.Location = this.Lb_MakerName.Location;

                        // 明細ヘッダ
                        this.EmployeeHeader.Visible = false;

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        this.EmployeeCode.Visible = true;
                        this.CodeNameFull20.Visible = true;

                        point = this.GoodsMakerCd.Location;
                        this.EmployeeCode.Location = point;

                        point.X += this.EmployeeCode.Width;
                        this.CodeNameFull20.Location = point;

                        this.CodeNameFull20.DataField = DCTOK02134EA.ct_Col_EmployeeName;
                    }
                    break;
                case SalesTransListCndtn.DetailDataValueState.Section:
                    {
                        // ヘッダレイアウト調整
                        this.Lb_GoodsNo.Visible = false;
                        this.Lb_GoodsName.Visible = false;
                        this.Lb_BLGoodsCode.Visible = false;
                        this.Lb_BLGroupCode.Visible = false;
                        this.Lb_GoodsMGroup.Visible = false;
                        this.Lb_GoodsLGroup.Visible = false;
                        this.Lb_MakerName.Visible = false;

                        this.Lb_Section.Visible = true;
                        this.Lb_Section.Location = this.Lb_MakerName.Location;

                        // 明細ヘッダ
                        this.CustomerHeader.Visible = false;
                        this.EmployeeHeader.Visible = false;
                        this.SectionHeader.Visible = false;
                        this.SupplierHeader.Visible = false; // ADD 2009/04/15

                        // 明細レイアウト調整
                        this.GoodsNo.Visible = false;
                        this.GoodsNameKana.Visible = false;
                        this.BLGoodsCode.Visible = false;
                        this.BLGroupCode.Visible = false;
                        this.GoodsMGroupCode.Visible = false;
                        this.GoodsLGroupCode.Visible = false;
                        this.GoodsMakerCd.Visible = false;

                        this.SectionCode.Visible = true;
                        this.CodeNameFull20.Visible = true;

                        point = this.GoodsMakerCd.Location;
                        this.SectionCode.Location = point;

                        point.X += this.SectionCode.Width;
                        this.CodeNameFull20.Location = point;

                        this.CodeNameFull20.DataField = DCTOK02134EA.ct_Col_CompanyName1;
                    }
                    break;
            }
            #endregion
            // --- ADD 2008/10/16 --------------------------------<<<<<

            //-------------------------------------------------------
            // 改ページ設定適用
            //-------------------------------------------------------
            #region [改ページ設定適用]
            CustomerHeader.NewPage = NewPage.None;
            EmployeeHeader.NewPage = NewPage.None;
            MakerHeader.NewPage = NewPage.None;
            SectionHeader.NewPage = NewPage.None;
            SupplierHeader.NewPage = NewPage.None;  // ADD 2009/04/15

            switch ( this._salesTransListCndtn.NewPageDiv )
            {
                case SalesTransListCndtn.NewPageDivState.EachCustomer:
                    CustomerHeader.NewPage = NewPage.Before;
                    break;
                case SalesTransListCndtn.NewPageDivState.EachSupplier: // ADD 2009/04/15
                    SupplierHeader.NewPage = NewPage.Before;
                    break;
                case SalesTransListCndtn.NewPageDivState.EachEmployee:
                    EmployeeHeader.NewPage = NewPage.Before;
                    break;
                case SalesTransListCndtn.NewPageDivState.EachMaker:
                    MakerHeader.NewPage = NewPage.Before;
                    break;
                case SalesTransListCndtn.NewPageDivState.EachSection:
                    SectionHeader.NewPage = NewPage.Before;
                    break;
                case SalesTransListCndtn.NewPageDivState.None:
                    break;
                default:
                    break;
            }
            #endregion [改ページ設定適用]

            //-------------------------------------------------------
            // 月範囲の適用（抽出された範囲内で処理する）
            //-------------------------------------------------------
            #region [月範囲の適用]

            // 作業用にリスト生成
            #region [作業用リスト生成]
            ArrayList[] ctrlList = new ArrayList[12];

            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// 月1
            //ctrlList[0] = new ArrayList();
            //ctrlList[0].AddRange( new object[] { Lb_Month1 } );
            //ctrlList[0].AddRange( new object[] { SalesMoney1, BlFt_SalesMoney1, Eng_SalesMoney1, DggFt_SalesMoney1, MggFt_SalesMoney1, LggFt_SalesMoney1, MakFt_SalesMoney1, EmpFt_SalesMoney1, CusFt_SalesMoney1, SecFt_SalesMoney1, Ttl_SalesMoney1 } );
            //ctrlList[0].AddRange( new object[] { TotalSalesCount1, BlFt_TotalSalesCount1, Eng_TotalSalesCount1, DggFt_TotalSalesCount1, MggFt_TotalSalesCount1, LggFt_TotalSalesCount1, MakFt_TotalSalesCount1, EmpFt_TotalSalesCount1, CusFt_TotalSalesCount1, SecFt_TotalSalesCount1, Ttl_TotalSalesCount1 } );
            //// 月2
            //ctrlList[1] = new ArrayList();
            //ctrlList[1].AddRange( new object[] { Lb_Month2 } );
            //ctrlList[1].AddRange( new object[] { SalesMoney2, BlFt_SalesMoney2, Eng_SalesMoney2, DggFt_SalesMoney2, MggFt_SalesMoney2, LggFt_SalesMoney2, MakFt_SalesMoney2, EmpFt_SalesMoney2, CusFt_SalesMoney2, SecFt_SalesMoney2, Ttl_SalesMoney2 } );
            //ctrlList[1].AddRange( new object[] { TotalSalesCount2, BlFt_TotalSalesCount2, Eng_TotalSalesCount2, DggFt_TotalSalesCount2, MggFt_TotalSalesCount2, LggFt_TotalSalesCount2, MakFt_TotalSalesCount2, EmpFt_TotalSalesCount2, CusFt_TotalSalesCount2, SecFt_TotalSalesCount2, Ttl_TotalSalesCount2 } );
            //// 月3
            //ctrlList[2] = new ArrayList();
            //ctrlList[2].AddRange( new object[] { Lb_Month3 } );
            //ctrlList[2].AddRange( new object[] { SalesMoney3, BlFt_SalesMoney3, Eng_SalesMoney3, DggFt_SalesMoney3, MggFt_SalesMoney3, LggFt_SalesMoney3, MakFt_SalesMoney3, EmpFt_SalesMoney3, CusFt_SalesMoney3, SecFt_SalesMoney3, Ttl_SalesMoney3 } );
            //ctrlList[2].AddRange( new object[] { TotalSalesCount3, BlFt_TotalSalesCount3, Eng_TotalSalesCount3, DggFt_TotalSalesCount3, MggFt_TotalSalesCount3, LggFt_TotalSalesCount3, MakFt_TotalSalesCount3, EmpFt_TotalSalesCount3, CusFt_TotalSalesCount3, SecFt_TotalSalesCount3, Ttl_TotalSalesCount3 } );
            //// 月4
            //ctrlList[3] = new ArrayList();
            //ctrlList[3].AddRange( new object[] { Lb_Month4 } );
            //ctrlList[3].AddRange( new object[] { SalesMoney4, BlFt_SalesMoney4, Eng_SalesMoney4, DggFt_SalesMoney4, MggFt_SalesMoney4, LggFt_SalesMoney4, MakFt_SalesMoney4, EmpFt_SalesMoney4, CusFt_SalesMoney4, SecFt_SalesMoney4, Ttl_SalesMoney4 } );
            //ctrlList[3].AddRange( new object[] { TotalSalesCount4, BlFt_TotalSalesCount4, Eng_TotalSalesCount4, DggFt_TotalSalesCount4, MggFt_TotalSalesCount4, LggFt_TotalSalesCount4, MakFt_TotalSalesCount4, EmpFt_TotalSalesCount4, CusFt_TotalSalesCount4, SecFt_TotalSalesCount4, Ttl_TotalSalesCount4 } );
            //// 月5
            //ctrlList[4] = new ArrayList();
            //ctrlList[4].AddRange( new object[] { Lb_Month5 } );
            //ctrlList[4].AddRange( new object[] { SalesMoney5, BlFt_SalesMoney5, Eng_SalesMoney5, DggFt_SalesMoney5, MggFt_SalesMoney5, LggFt_SalesMoney5, MakFt_SalesMoney5, EmpFt_SalesMoney5, CusFt_SalesMoney5, SecFt_SalesMoney5, Ttl_SalesMoney5 } );
            //ctrlList[4].AddRange( new object[] { TotalSalesCount5, BlFt_TotalSalesCount5, Eng_TotalSalesCount5, DggFt_TotalSalesCount5, MggFt_TotalSalesCount5, LggFt_TotalSalesCount5, MakFt_TotalSalesCount5, EmpFt_TotalSalesCount5, CusFt_TotalSalesCount5, SecFt_TotalSalesCount5, Ttl_TotalSalesCount5 } );
            //// 月6
            //ctrlList[5] = new ArrayList();
            //ctrlList[5].AddRange( new object[] { Lb_Month6 } );
            //ctrlList[5].AddRange( new object[] { SalesMoney6, BlFt_SalesMoney6, Eng_SalesMoney6, DggFt_SalesMoney6, MggFt_SalesMoney6, LggFt_SalesMoney6, MakFt_SalesMoney6, EmpFt_SalesMoney6, CusFt_SalesMoney6, SecFt_SalesMoney6, Ttl_SalesMoney6 } );
            //ctrlList[5].AddRange( new object[] { TotalSalesCount6, BlFt_TotalSalesCount6, Eng_TotalSalesCount6, DggFt_TotalSalesCount6, MggFt_TotalSalesCount6, LggFt_TotalSalesCount6, MakFt_TotalSalesCount6, EmpFt_TotalSalesCount6, CusFt_TotalSalesCount6, SecFt_TotalSalesCount6, Ttl_TotalSalesCount6 } );
            //// 月7
            //ctrlList[6] = new ArrayList();
            //ctrlList[6].AddRange( new object[] { Lb_Month7 } );
            //ctrlList[6].AddRange( new object[] { SalesMoney7, BlFt_SalesMoney7, Eng_SalesMoney7, DggFt_SalesMoney7, MggFt_SalesMoney7, LggFt_SalesMoney7, MakFt_SalesMoney7, EmpFt_SalesMoney7, CusFt_SalesMoney7, SecFt_SalesMoney7, Ttl_SalesMoney7 } );
            //ctrlList[6].AddRange( new object[] { TotalSalesCount7, BlFt_TotalSalesCount7, Eng_TotalSalesCount7, DggFt_TotalSalesCount7, MggFt_TotalSalesCount7, LggFt_TotalSalesCount7, MakFt_TotalSalesCount7, EmpFt_TotalSalesCount7, CusFt_TotalSalesCount7, SecFt_TotalSalesCount7, Ttl_TotalSalesCount7 } );
            //// 月8
            //ctrlList[7] = new ArrayList();
            //ctrlList[7].AddRange( new object[] { Lb_Month8 } );
            //ctrlList[7].AddRange( new object[] { SalesMoney8, BlFt_SalesMoney8, Eng_SalesMoney8, DggFt_SalesMoney8, MggFt_SalesMoney8, LggFt_SalesMoney8, MakFt_SalesMoney8, EmpFt_SalesMoney8, CusFt_SalesMoney8, SecFt_SalesMoney8, Ttl_SalesMoney8 } );
            //ctrlList[7].AddRange( new object[] { TotalSalesCount8, BlFt_TotalSalesCount8, Eng_TotalSalesCount8, DggFt_TotalSalesCount8, MggFt_TotalSalesCount8, LggFt_TotalSalesCount8, MakFt_TotalSalesCount8, EmpFt_TotalSalesCount8, CusFt_TotalSalesCount8, SecFt_TotalSalesCount8, Ttl_TotalSalesCount8 } );
            //// 月9
            //ctrlList[8] = new ArrayList();
            //ctrlList[8].AddRange( new object[] { Lb_Month9 } );
            //ctrlList[8].AddRange( new object[] { SalesMoney9, BlFt_SalesMoney9, Eng_SalesMoney9, DggFt_SalesMoney9, MggFt_SalesMoney9, LggFt_SalesMoney9, MakFt_SalesMoney9, EmpFt_SalesMoney9, CusFt_SalesMoney9, SecFt_SalesMoney9, Ttl_SalesMoney9 } );
            //ctrlList[8].AddRange( new object[] { TotalSalesCount9, BlFt_TotalSalesCount9, Eng_TotalSalesCount9, DggFt_TotalSalesCount9, MggFt_TotalSalesCount9, LggFt_TotalSalesCount9, MakFt_TotalSalesCount9, EmpFt_TotalSalesCount9, CusFt_TotalSalesCount9, SecFt_TotalSalesCount9, Ttl_TotalSalesCount9 } );
            //// 月10
            //ctrlList[9] = new ArrayList();
            //ctrlList[9].AddRange( new object[] { Lb_Month10 } );
            //ctrlList[9].AddRange( new object[] { SalesMoney10, BlFt_SalesMoney10, Eng_SalesMoney10, DggFt_SalesMoney10, MggFt_SalesMoney10, LggFt_SalesMoney10, MakFt_SalesMoney10, EmpFt_SalesMoney10, CusFt_SalesMoney10, SecFt_SalesMoney10, Ttl_SalesMoney10 } );
            //ctrlList[9].AddRange( new object[] { TotalSalesCount10, BlFt_TotalSalesCount10, Eng_TotalSalesCount10, DggFt_TotalSalesCount10, MggFt_TotalSalesCount10, LggFt_TotalSalesCount10, MakFt_TotalSalesCount10, EmpFt_TotalSalesCount10, CusFt_TotalSalesCount10, SecFt_TotalSalesCount10, Ttl_TotalSalesCount10 } );
            //// 月11
            //ctrlList[10] = new ArrayList();
            //ctrlList[10].AddRange( new object[] { Lb_Month11 } );
            //ctrlList[10].AddRange( new object[] { SalesMoney11, BlFt_SalesMoney11, Eng_SalesMoney11, DggFt_SalesMoney11, MggFt_SalesMoney11, LggFt_SalesMoney11, MakFt_SalesMoney11, EmpFt_SalesMoney11, CusFt_SalesMoney11, SecFt_SalesMoney11, Ttl_SalesMoney11 } );
            //ctrlList[10].AddRange( new object[] { TotalSalesCount11, BlFt_TotalSalesCount11, Eng_TotalSalesCount11, DggFt_TotalSalesCount11, MggFt_TotalSalesCount11, LggFt_TotalSalesCount11, MakFt_TotalSalesCount11, EmpFt_TotalSalesCount11, CusFt_TotalSalesCount11, SecFt_TotalSalesCount11, Ttl_TotalSalesCount11 } );
            //// 月12
            //ctrlList[11] = new ArrayList();
            //ctrlList[11].AddRange( new object[] { Lb_Month12 } );
            //ctrlList[11].AddRange( new object[] { SalesMoney12, BlFt_SalesMoney12, Eng_SalesMoney12, DggFt_SalesMoney12, MggFt_SalesMoney12, LggFt_SalesMoney12, MakFt_SalesMoney12, EmpFt_SalesMoney12, CusFt_SalesMoney12, SecFt_SalesMoney12, Ttl_SalesMoney12 } );
            //ctrlList[11].AddRange( new object[] { TotalSalesCount12, BlFt_TotalSalesCount12, Eng_TotalSalesCount12, DggFt_TotalSalesCount12, MggFt_TotalSalesCount12, LggFt_TotalSalesCount12, MakFt_TotalSalesCount12, EmpFt_TotalSalesCount12, CusFt_TotalSalesCount12, SecFt_TotalSalesCount12, Ttl_TotalSalesCount12 } );
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // 月1
            ctrlList[0] = new ArrayList();
            ctrlList[0].AddRange(new object[] { Lb_Month1 });
            ctrlList[0].AddRange(new object[] { SalesMoney1, BlFt_SalesMoney1, DggFt_SalesMoney1, MggFt_SalesMoney1, LggFt_SalesMoney1, MakFt_SalesMoney1, EmpFt_SalesMoney1,SupFt_SalesMoney1, CusFt_SalesMoney1, SecFt_SalesMoney1, Ttl_SalesMoney1 });
            ctrlList[0].AddRange(new object[] { TotalSalesCount1, BlFt_TotalSalesCount1, DggFt_TotalSalesCount1, MggFt_TotalSalesCount1, LggFt_TotalSalesCount1, MakFt_TotalSalesCount1, EmpFt_TotalSalesCount1, SupFt_TotalSalesCount1, CusFt_TotalSalesCount1, SecFt_TotalSalesCount1, Ttl_TotalSalesCount1 });
            // 月2
            ctrlList[1] = new ArrayList();
            ctrlList[1].AddRange(new object[] { Lb_Month2 });
            ctrlList[1].AddRange(new object[] { SalesMoney2, BlFt_SalesMoney2, DggFt_SalesMoney2, MggFt_SalesMoney2, LggFt_SalesMoney2, MakFt_SalesMoney2, EmpFt_SalesMoney2, SupFt_SalesMoney2, CusFt_SalesMoney2, SecFt_SalesMoney2, Ttl_SalesMoney2 });
            ctrlList[1].AddRange(new object[] { TotalSalesCount2, BlFt_TotalSalesCount2, DggFt_TotalSalesCount2, MggFt_TotalSalesCount2, LggFt_TotalSalesCount2, MakFt_TotalSalesCount2, EmpFt_TotalSalesCount2, SupFt_TotalSalesCount2, CusFt_TotalSalesCount2, SecFt_TotalSalesCount2, Ttl_TotalSalesCount2 });
            // 月3
            ctrlList[2] = new ArrayList();
            ctrlList[2].AddRange(new object[] { Lb_Month3 });
            ctrlList[2].AddRange(new object[] { SalesMoney3, BlFt_SalesMoney3, DggFt_SalesMoney3, MggFt_SalesMoney3, LggFt_SalesMoney3, MakFt_SalesMoney3, EmpFt_SalesMoney3, SupFt_SalesMoney3, CusFt_SalesMoney3, SecFt_SalesMoney3, Ttl_SalesMoney3 });
            ctrlList[2].AddRange(new object[] { TotalSalesCount3, BlFt_TotalSalesCount3, DggFt_TotalSalesCount3, MggFt_TotalSalesCount3, LggFt_TotalSalesCount3, MakFt_TotalSalesCount3, EmpFt_TotalSalesCount3, SupFt_TotalSalesCount3, CusFt_TotalSalesCount3, SecFt_TotalSalesCount3, Ttl_TotalSalesCount3 });
            // 月4
            ctrlList[3] = new ArrayList();
            ctrlList[3].AddRange(new object[] { Lb_Month4 });
            ctrlList[3].AddRange(new object[] { SalesMoney4, BlFt_SalesMoney4, DggFt_SalesMoney4, MggFt_SalesMoney4, LggFt_SalesMoney4, MakFt_SalesMoney4, EmpFt_SalesMoney4, SupFt_SalesMoney4, CusFt_SalesMoney4, SecFt_SalesMoney4, Ttl_SalesMoney4 });
            ctrlList[3].AddRange(new object[] { TotalSalesCount4, BlFt_TotalSalesCount4, DggFt_TotalSalesCount4, MggFt_TotalSalesCount4, LggFt_TotalSalesCount4, MakFt_TotalSalesCount4, EmpFt_TotalSalesCount4, SupFt_TotalSalesCount4, CusFt_TotalSalesCount4, SecFt_TotalSalesCount4, Ttl_TotalSalesCount4 });
            // 月5
            ctrlList[4] = new ArrayList();
            ctrlList[4].AddRange(new object[] { Lb_Month5 });
            ctrlList[4].AddRange(new object[] { SalesMoney5, BlFt_SalesMoney5, DggFt_SalesMoney5, MggFt_SalesMoney5, LggFt_SalesMoney5, MakFt_SalesMoney5, EmpFt_SalesMoney5, SupFt_SalesMoney5, CusFt_SalesMoney5, SecFt_SalesMoney5, Ttl_SalesMoney5 });
            ctrlList[4].AddRange(new object[] { TotalSalesCount5, BlFt_TotalSalesCount5, DggFt_TotalSalesCount5, MggFt_TotalSalesCount5, LggFt_TotalSalesCount5, MakFt_TotalSalesCount5, EmpFt_TotalSalesCount5, SupFt_TotalSalesCount5, CusFt_TotalSalesCount5, SecFt_TotalSalesCount5, Ttl_TotalSalesCount5 });
            // 月6
            ctrlList[5] = new ArrayList();
            ctrlList[5].AddRange(new object[] { Lb_Month6 });
            ctrlList[5].AddRange(new object[] { SalesMoney6, BlFt_SalesMoney6, DggFt_SalesMoney6, MggFt_SalesMoney6, LggFt_SalesMoney6, MakFt_SalesMoney6, EmpFt_SalesMoney6, SupFt_SalesMoney6, CusFt_SalesMoney6, SecFt_SalesMoney6, Ttl_SalesMoney6 });
            ctrlList[5].AddRange(new object[] { TotalSalesCount6, BlFt_TotalSalesCount6, DggFt_TotalSalesCount6, MggFt_TotalSalesCount6, LggFt_TotalSalesCount6, MakFt_TotalSalesCount6, EmpFt_TotalSalesCount6, SupFt_TotalSalesCount6, CusFt_TotalSalesCount6, SecFt_TotalSalesCount6, Ttl_TotalSalesCount6 });
            // 月7
            ctrlList[6] = new ArrayList();
            ctrlList[6].AddRange(new object[] { Lb_Month7 });
            ctrlList[6].AddRange(new object[] { SalesMoney7, BlFt_SalesMoney7, DggFt_SalesMoney7, MggFt_SalesMoney7, LggFt_SalesMoney7, MakFt_SalesMoney7, EmpFt_SalesMoney7, SupFt_SalesMoney7, CusFt_SalesMoney7, SecFt_SalesMoney7, Ttl_SalesMoney7 });
            ctrlList[6].AddRange(new object[] { TotalSalesCount7, BlFt_TotalSalesCount7, DggFt_TotalSalesCount7, MggFt_TotalSalesCount7, LggFt_TotalSalesCount7, MakFt_TotalSalesCount7, EmpFt_TotalSalesCount7, SupFt_TotalSalesCount7, CusFt_TotalSalesCount7, SecFt_TotalSalesCount7, Ttl_TotalSalesCount7 });
            // 月8
            ctrlList[7] = new ArrayList();
            ctrlList[7].AddRange(new object[] { Lb_Month8 });
            ctrlList[7].AddRange(new object[] { SalesMoney8, BlFt_SalesMoney8, DggFt_SalesMoney8, MggFt_SalesMoney8, LggFt_SalesMoney8, MakFt_SalesMoney8, EmpFt_SalesMoney8, SupFt_SalesMoney8, CusFt_SalesMoney8, SecFt_SalesMoney8, Ttl_SalesMoney8 });
            ctrlList[7].AddRange(new object[] { TotalSalesCount8, BlFt_TotalSalesCount8, DggFt_TotalSalesCount8, MggFt_TotalSalesCount8, LggFt_TotalSalesCount8, MakFt_TotalSalesCount8, EmpFt_TotalSalesCount8, SupFt_TotalSalesCount8, CusFt_TotalSalesCount8, SecFt_TotalSalesCount8, Ttl_TotalSalesCount8 });
            // 月9
            ctrlList[8] = new ArrayList();
            ctrlList[8].AddRange(new object[] { Lb_Month9 });
            ctrlList[8].AddRange(new object[] { SalesMoney9, BlFt_SalesMoney9, DggFt_SalesMoney9, MggFt_SalesMoney9, LggFt_SalesMoney9, MakFt_SalesMoney9, EmpFt_SalesMoney9, SupFt_SalesMoney9, CusFt_SalesMoney9, SecFt_SalesMoney9, Ttl_SalesMoney9 });
            ctrlList[8].AddRange(new object[] { TotalSalesCount9, BlFt_TotalSalesCount9, DggFt_TotalSalesCount9, MggFt_TotalSalesCount9, LggFt_TotalSalesCount9, MakFt_TotalSalesCount9, EmpFt_TotalSalesCount9, SupFt_TotalSalesCount9, CusFt_TotalSalesCount9, SecFt_TotalSalesCount9, Ttl_TotalSalesCount9 });
            // 月10
            ctrlList[9] = new ArrayList();
            ctrlList[9].AddRange(new object[] { Lb_Month10 });
            ctrlList[9].AddRange(new object[] { SalesMoney10, BlFt_SalesMoney10, DggFt_SalesMoney10, MggFt_SalesMoney10, LggFt_SalesMoney10, MakFt_SalesMoney10, EmpFt_SalesMoney10, SupFt_SalesMoney10, CusFt_SalesMoney10, SecFt_SalesMoney10, Ttl_SalesMoney10 });
            ctrlList[9].AddRange(new object[] { TotalSalesCount10, BlFt_TotalSalesCount10, DggFt_TotalSalesCount10, MggFt_TotalSalesCount10, LggFt_TotalSalesCount10, MakFt_TotalSalesCount10, EmpFt_TotalSalesCount10, SupFt_TotalSalesCount10, CusFt_TotalSalesCount10, SecFt_TotalSalesCount10, Ttl_TotalSalesCount10 });
            // 月11
            ctrlList[10] = new ArrayList();
            ctrlList[10].AddRange(new object[] { Lb_Month11 });
            ctrlList[10].AddRange(new object[] { SalesMoney11, BlFt_SalesMoney11, DggFt_SalesMoney11, MggFt_SalesMoney11, LggFt_SalesMoney11, MakFt_SalesMoney11, EmpFt_SalesMoney11, SupFt_SalesMoney11, CusFt_SalesMoney11, SecFt_SalesMoney11, Ttl_SalesMoney11 });
            ctrlList[10].AddRange(new object[] { TotalSalesCount11, BlFt_TotalSalesCount11, DggFt_TotalSalesCount11, MggFt_TotalSalesCount11, LggFt_TotalSalesCount11, MakFt_TotalSalesCount11, EmpFt_TotalSalesCount11, SupFt_TotalSalesCount11, CusFt_TotalSalesCount11, SecFt_TotalSalesCount11, Ttl_TotalSalesCount11 });
            // 月12
            ctrlList[11] = new ArrayList();
            ctrlList[11].AddRange(new object[] { Lb_Month12 });
            ctrlList[11].AddRange(new object[] { SalesMoney12, BlFt_SalesMoney12, DggFt_SalesMoney12, MggFt_SalesMoney12, LggFt_SalesMoney12, MakFt_SalesMoney12, EmpFt_SalesMoney12, SupFt_SalesMoney12, CusFt_SalesMoney12, SecFt_SalesMoney12, Ttl_SalesMoney12 });
            ctrlList[11].AddRange(new object[] { TotalSalesCount12, BlFt_TotalSalesCount12, DggFt_TotalSalesCount12, MggFt_TotalSalesCount12, LggFt_TotalSalesCount12, MakFt_TotalSalesCount12, EmpFt_TotalSalesCount12, SupFt_TotalSalesCount12, CusFt_TotalSalesCount12, SecFt_TotalSalesCount12, Ttl_TotalSalesCount12 });
            // --- ADD 2008/10/16 --------------------------------<<<<<

            // 月タイトルリスト
            // (※注意：月タイトルラベルはこのリストにも、上記の月毎コントロールリストにも格納されます)
            List<Label> monthTitleList = new List<Label>();
            monthTitleList.AddRange( new Label[] { Lb_Month1, Lb_Month2, Lb_Month3, Lb_Month4, Lb_Month5, Lb_Month6, Lb_Month7, Lb_Month8, Lb_Month9, Lb_Month10, Lb_Month11, Lb_Month12} );

            #endregion

            // 月数の取得
            int monthRange = GetMonthRange( this._salesTransListCndtn.St_ThisYearMonth, this._salesTransListCndtn.Ed_ThisYearMonth );

            // 印字有無を設定
            for ( int index = 0; index < ctrlList.Length; index++ )
            {
                // 月タイトル設定
                if ( index < monthTitleList.Count )
                {
                    monthTitleList[index].Text = GetMonthTitle( this._salesTransListCndtn.St_ThisYearMonth, index );
                }

                // 印字有無設定
                foreach ( object ctrl in ctrlList[index] )
                {
                    if ( ctrl is TextBox )
                    {
                        ( ctrl as TextBox ).Visible = ( index < monthRange );   // 範囲内のみtrue
                    }
                    else if ( ctrl is Label )
                    {
                        ( ctrl as Label ).Visible = ( index < monthRange );     // 範囲内のみtrue
                    }
                }
            }

            #endregion

            //-------------------------------------------------------
            // 印字タイプ（金額・数量）の適用
            //-------------------------------------------------------
            #region [印字タイプ（金額・数量）の適用]

            #region [作業用のリストを生成]

            // 金額項目リスト
            List<TextBox> tbPriceList = new List<TextBox>();
            tbPriceList.AddRange( new TextBox[] { SalesMoney1, SalesMoney2, SalesMoney3, SalesMoney4, SalesMoney5, SalesMoney6, SalesMoney7, SalesMoney8, SalesMoney9, SalesMoney10, SalesMoney11, SalesMoney12, TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { BlFt_SalesMoney1, BlFt_SalesMoney2, BlFt_SalesMoney3, BlFt_SalesMoney4, BlFt_SalesMoney5, BlFt_SalesMoney6, BlFt_SalesMoney7, BlFt_SalesMoney8, BlFt_SalesMoney9, BlFt_SalesMoney10, BlFt_SalesMoney11, BlFt_SalesMoney12, BlFt_TtlSalesMoney } );
            //tbPriceList.AddRange( new TextBox[] { Eng_SalesMoney1, Eng_SalesMoney2, Eng_SalesMoney3, Eng_SalesMoney4, Eng_SalesMoney5, Eng_SalesMoney6, Eng_SalesMoney7, Eng_SalesMoney8, Eng_SalesMoney9, Eng_SalesMoney10, Eng_SalesMoney11, Eng_SalesMoney12, Eng_TtlSalesMoney } ); // DEL 2008/10/16
            tbPriceList.AddRange( new TextBox[] { DggFt_SalesMoney1, DggFt_SalesMoney2, DggFt_SalesMoney3, DggFt_SalesMoney4, DggFt_SalesMoney5, DggFt_SalesMoney6, DggFt_SalesMoney7, DggFt_SalesMoney8, DggFt_SalesMoney9, DggFt_SalesMoney10, DggFt_SalesMoney11, DggFt_SalesMoney12, DggFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { MggFt_SalesMoney1, MggFt_SalesMoney2, MggFt_SalesMoney3, MggFt_SalesMoney4, MggFt_SalesMoney5, MggFt_SalesMoney6, MggFt_SalesMoney7, MggFt_SalesMoney8, MggFt_SalesMoney9, MggFt_SalesMoney10, MggFt_SalesMoney11, MggFt_SalesMoney12, MggFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { LggFt_SalesMoney1, LggFt_SalesMoney2, LggFt_SalesMoney3, LggFt_SalesMoney4, LggFt_SalesMoney5, LggFt_SalesMoney6, LggFt_SalesMoney7, LggFt_SalesMoney8, LggFt_SalesMoney9, LggFt_SalesMoney10, LggFt_SalesMoney11, LggFt_SalesMoney12, LggFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { MakFt_SalesMoney1, MakFt_SalesMoney2, MakFt_SalesMoney3, MakFt_SalesMoney4, MakFt_SalesMoney5, MakFt_SalesMoney6, MakFt_SalesMoney7, MakFt_SalesMoney8, MakFt_SalesMoney9, MakFt_SalesMoney10, MakFt_SalesMoney11, MakFt_SalesMoney12, MakFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { EmpFt_SalesMoney1, EmpFt_SalesMoney2, EmpFt_SalesMoney3, EmpFt_SalesMoney4, EmpFt_SalesMoney5, EmpFt_SalesMoney6, EmpFt_SalesMoney7, EmpFt_SalesMoney8, EmpFt_SalesMoney9, EmpFt_SalesMoney10, EmpFt_SalesMoney11, EmpFt_SalesMoney12, EmpFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { CusFt_SalesMoney1, CusFt_SalesMoney2, CusFt_SalesMoney3, CusFt_SalesMoney4, CusFt_SalesMoney5, CusFt_SalesMoney6, CusFt_SalesMoney7, CusFt_SalesMoney8, CusFt_SalesMoney9, CusFt_SalesMoney10, CusFt_SalesMoney11, CusFt_SalesMoney12, CusFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { SupFt_SalesMoney1, SupFt_SalesMoney2, SupFt_SalesMoney3, SupFt_SalesMoney4, SupFt_SalesMoney5, SupFt_SalesMoney6, SupFt_SalesMoney7, SupFt_SalesMoney8, SupFt_SalesMoney9, SupFt_SalesMoney10, SupFt_SalesMoney11, SupFt_SalesMoney12, SupFt_TtlSalesMoney } ); // ADD 2009/04/15
            tbPriceList.AddRange( new TextBox[] { SecFt_SalesMoney1, SecFt_SalesMoney2, SecFt_SalesMoney3, SecFt_SalesMoney4, SecFt_SalesMoney5, SecFt_SalesMoney6, SecFt_SalesMoney7, SecFt_SalesMoney8, SecFt_SalesMoney9, SecFt_SalesMoney10, SecFt_SalesMoney11, SecFt_SalesMoney12, SecFt_TtlSalesMoney } );
            tbPriceList.AddRange( new TextBox[] { Ttl_SalesMoney1, Ttl_SalesMoney2, Ttl_SalesMoney3, Ttl_SalesMoney4, Ttl_SalesMoney5, Ttl_SalesMoney6, Ttl_SalesMoney7, Ttl_SalesMoney8, Ttl_SalesMoney9, Ttl_SalesMoney10, Ttl_SalesMoney11, Ttl_SalesMoney12, Ttl_TtlSalesMoney } );
            // 数量項目リスト
            List<TextBox> tbCountList = new List<TextBox>();
            tbCountList.AddRange( new TextBox[] { TotalSalesCount1, TotalSalesCount2, TotalSalesCount3, TotalSalesCount4, TotalSalesCount5, TotalSalesCount6, TotalSalesCount7, TotalSalesCount8, TotalSalesCount9, TotalSalesCount10, TotalSalesCount11, TotalSalesCount12, TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { BlFt_TotalSalesCount1, BlFt_TotalSalesCount2, BlFt_TotalSalesCount3, BlFt_TotalSalesCount4, BlFt_TotalSalesCount5, BlFt_TotalSalesCount6, BlFt_TotalSalesCount7, BlFt_TotalSalesCount8, BlFt_TotalSalesCount9, BlFt_TotalSalesCount10, BlFt_TotalSalesCount11, BlFt_TotalSalesCount12, BlFt_TtlTotalSalesCount } );
            //tbCountList.AddRange( new TextBox[] { Eng_TotalSalesCount1, Eng_TotalSalesCount2, Eng_TotalSalesCount3, Eng_TotalSalesCount4, Eng_TotalSalesCount5, Eng_TotalSalesCount6, Eng_TotalSalesCount7, Eng_TotalSalesCount8, Eng_TotalSalesCount9, Eng_TotalSalesCount10, Eng_TotalSalesCount11, Eng_TotalSalesCount12, Eng_TtlTotalSalesCount } ); // DEL 2008/10/16
            tbCountList.AddRange( new TextBox[] { DggFt_TotalSalesCount1, DggFt_TotalSalesCount2, DggFt_TotalSalesCount3, DggFt_TotalSalesCount4, DggFt_TotalSalesCount5, DggFt_TotalSalesCount6, DggFt_TotalSalesCount7, DggFt_TotalSalesCount8, DggFt_TotalSalesCount9, DggFt_TotalSalesCount10, DggFt_TotalSalesCount11, DggFt_TotalSalesCount12, DggFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { MggFt_TotalSalesCount1, MggFt_TotalSalesCount2, MggFt_TotalSalesCount3, MggFt_TotalSalesCount4, MggFt_TotalSalesCount5, MggFt_TotalSalesCount6, MggFt_TotalSalesCount7, MggFt_TotalSalesCount8, MggFt_TotalSalesCount9, MggFt_TotalSalesCount10, MggFt_TotalSalesCount11, MggFt_TotalSalesCount12, MggFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { LggFt_TotalSalesCount1, LggFt_TotalSalesCount2, LggFt_TotalSalesCount3, LggFt_TotalSalesCount4, LggFt_TotalSalesCount5, LggFt_TotalSalesCount6, LggFt_TotalSalesCount7, LggFt_TotalSalesCount8, LggFt_TotalSalesCount9, LggFt_TotalSalesCount10, LggFt_TotalSalesCount11, LggFt_TotalSalesCount12, LggFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { MakFt_TotalSalesCount1, MakFt_TotalSalesCount2, MakFt_TotalSalesCount3, MakFt_TotalSalesCount4, MakFt_TotalSalesCount5, MakFt_TotalSalesCount6, MakFt_TotalSalesCount7, MakFt_TotalSalesCount8, MakFt_TotalSalesCount9, MakFt_TotalSalesCount10, MakFt_TotalSalesCount11, MakFt_TotalSalesCount12, MakFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { EmpFt_TotalSalesCount1, EmpFt_TotalSalesCount2, EmpFt_TotalSalesCount3, EmpFt_TotalSalesCount4, EmpFt_TotalSalesCount5, EmpFt_TotalSalesCount6, EmpFt_TotalSalesCount7, EmpFt_TotalSalesCount8, EmpFt_TotalSalesCount9, EmpFt_TotalSalesCount10, EmpFt_TotalSalesCount11, EmpFt_TotalSalesCount12, EmpFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { CusFt_TotalSalesCount1, CusFt_TotalSalesCount2, CusFt_TotalSalesCount3, CusFt_TotalSalesCount4, CusFt_TotalSalesCount5, CusFt_TotalSalesCount6, CusFt_TotalSalesCount7, CusFt_TotalSalesCount8, CusFt_TotalSalesCount9, CusFt_TotalSalesCount10, CusFt_TotalSalesCount11, CusFt_TotalSalesCount12, CusFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { SupFt_TotalSalesCount1, SupFt_TotalSalesCount2, SupFt_TotalSalesCount3, SupFt_TotalSalesCount4, SupFt_TotalSalesCount5, SupFt_TotalSalesCount6, SupFt_TotalSalesCount7, SupFt_TotalSalesCount8, SupFt_TotalSalesCount9, SupFt_TotalSalesCount10, SupFt_TotalSalesCount11, SupFt_TotalSalesCount12, SupFt_TtlTotalSalesCount } ); // ADD 2009/04/15
            tbCountList.AddRange( new TextBox[] { SecFt_TotalSalesCount1, SecFt_TotalSalesCount2, SecFt_TotalSalesCount3, SecFt_TotalSalesCount4, SecFt_TotalSalesCount5, SecFt_TotalSalesCount6, SecFt_TotalSalesCount7, SecFt_TotalSalesCount8, SecFt_TotalSalesCount9, SecFt_TotalSalesCount10, SecFt_TotalSalesCount11, SecFt_TotalSalesCount12, SecFt_TtlTotalSalesCount } );
            tbCountList.AddRange( new TextBox[] { Ttl_TotalSalesCount1, Ttl_TotalSalesCount2, Ttl_TotalSalesCount3, Ttl_TotalSalesCount4, Ttl_TotalSalesCount5, Ttl_TotalSalesCount6, Ttl_TotalSalesCount7, Ttl_TotalSalesCount8, Ttl_TotalSalesCount9, Ttl_TotalSalesCount10, Ttl_TotalSalesCount11, Ttl_TotalSalesCount12, Ttl_TtlTotalSalesCount } );
            #endregion

            // visible設定と印字位置調整
            if ( this._salesTransListCndtn.PrintTypeDiv == SalesTransListCndtn.PrintTypeDivState.PriceOnly )
            {
                // 金額のみ　→　全ての数量を非印字にする
                for ( int index = 0; index < tbCountList.Count; index++ )
                {
                    // 数量非印字
                    tbCountList[index].Visible = false;
                }
            }
            else if ( this._salesTransListCndtn.PrintTypeDiv == SalesTransListCndtn.PrintTypeDivState.CountOnly )
            {
                // 数量のみ　→　全ての金額を非印字にする　＋　全ての数量の印字位置を金額に合わせる
                for ( int index = 0; index < tbPriceList.Count; index++ )
                {
                    // 金額非印字
                    tbPriceList[index].Visible = false;
                    
                    // 数量の印字位置調整
                    if ( index < tbCountList.Count )
                    {
                        tbCountList[index].Top = tbPriceList[index].Top;
                    }
                }
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
        #endregion

        #region ■ Control Event

        #region ◎ DCTOK02132P_01A4C_ReportStart Event
        /// <summary>
        /// DCTOK02132P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCTOK02132P_01A4C_ReportStart ( object sender, System.EventArgs eArgs )
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ DCTOK02132P_01A4C_PageEnd Event
        /// <summary>
        /// DCTOK02132P_01A4C_PageEnd Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DCTOK02132P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCTOK02132P_01A4C_PageEnd ( object sender, System.EventArgs eArgs )
        {
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
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
            this.tb_PrintDate.Text = TDateTime.DateTimeToString( SalesTransListCndtn.ct_DateFomat, DateTime.Now );
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
        /// </remarks>
        private void Detail_Format ( object sender, System.EventArgs eArgs )
        {
            // ADD 2008/11/04 不具合対応[7296] ---------->>>>>
            if ((int)this.GoodsMakerCd.Value == 0)
            {
                this.GoodsMakerCd.Text = "";
            }
            if ((int)this.BLGroupCode.Value == 0)
            {
                this.BLGroupCode.Text = "";
            }
            if ((int)this.BLGoodsCode.Value == 0)
            {
                this.BLGoodsCode.Text = "";
            }
            if ((int)this.GoodsLGroupCode.Value == 0)
            {
                this.GoodsLGroupCode.Text = "";
            }
            if ((int)this.GoodsMGroupCode.Value == 0)
            {
                this.GoodsMGroupCode.Text = "";
            }
            
            if ((int)this.CustomerCode.Value == 0)
            {
                this.CustomerCode.Text = "";
            }

            // DEL 2009/06/24
            //if ((int)this.SupplierCode.Value == 0)  // ADD 2009/04/15
            //{
            //    this.SupplierCode.Text = "000000";
            //    this.CodeNameFull20.Text = "未登録";
            //}

            // ADD 2008/11/04 不具合対応[7296] ----------<<<<<
            // --- ADD 2008/12/09 -------------------------------->>>>>
            if (this._salesTransListCndtn.TtlType == SalesTransListCndtn.TtlTypeState.All
                && this._salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.Section)
            {
                // 集計方法「全社」、明細単位「拠点」の場合、「全社」を表示
                this.SectionCode.Text = string.Empty;
                this.CodeNameFull20.Text = "全社";
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<
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
            // グループサプレスの判断
            this.CheckGroupSuppression();
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString( this.Detail );
            SetTextFormat(this.Detail);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
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

            //// 罫線制御
            //Line_DetailHead.Visible = false;    //2明細目以降は印字しない

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
            // フッター出力する？
            if ( this._pageFooterOutCode == 0 )
            {
                // インスタンスが作成されていなければ作成
                if ( _rptPageFooter == null )
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
                if ( this._pageFooters[0] != null )
                {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if ( this._pageFooters[1] != null )
                {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }
        #endregion

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
        private DataDynamics.ActiveReports.Label Lb_GoodsNo;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_MakerName;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
        private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
        private DataDynamics.ActiveReports.Line Line44;
        private DataDynamics.ActiveReports.TextBox Cus_Title;
        private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.TextBox Sec_Title;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Label Ttl_Title;
        private DataDynamics.ActiveReports.Line Line43;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02132P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.Line_DetailHead = new DataDynamics.ActiveReports.Line();
            this.SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.CodeNameHalf20 = new DataDynamics.ActiveReports.TextBox();
            this.TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana = new DataDynamics.ActiveReports.TextBox();
            this.CodeNameFull20 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCode = new DataDynamics.ActiveReports.TextBox();
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
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGroupCode = new DataDynamics.ActiveReports.Label();
            this.Lb_Month1 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month2 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month3 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month4 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month7 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month5 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month6 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month11 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month8 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month9 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month10 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month12 = new DataDynamics.ActiveReports.Label();
            this.Lb_Total = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsLGroup = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMGroup = new DataDynamics.ActiveReports.Label();
            this.Lb_Customer = new DataDynamics.ActiveReports.Label();
            this.Lb_Employee = new DataDynamics.ActiveReports.Label();
            this.Lb_Section = new DataDynamics.ActiveReports.Label();
            this.Lb_Supplier = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Ttl_Title = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Sec_Title = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.SecFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CusHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.CusHd_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerTitle = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.Cus_Title = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.CusFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCodeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGoodsCodeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_BLGoodsFullName = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.BlFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line18 = new DataDynamics.ActiveReports.Line();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_GoodsMGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_GoodsMGroupName = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MggFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCodeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGroupCodeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_BLGroupCodeName = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.DggFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_GoodsLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_GoodsLGroupName = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.LggFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line20 = new DataDynamics.ActiveReports.Line();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_MakerName = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.EmpHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.EmpHd_EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeName = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeTitle = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.EmployeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line21 = new DataDynamics.ActiveReports.Line();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.EmpFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_SupplierCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierTitle = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.Sup_Title = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney1 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney2 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney3 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney5 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney6 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney4 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney7 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney8 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney9 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney11 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney12 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_SalesMoney10 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount1 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount2 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount3 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount5 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount6 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount4 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount7 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount8 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount9 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount11 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount12 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalSalesCount10 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TtlTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TtlSalesMoney = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeNameHalf20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeNameFull20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsLGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Section)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Supplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GoodsMGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GoodsMGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_BLGroupCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GoodsLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GoodsLGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsMakerCd,
            this.SalesMoney1,
            this.GoodsLGroupCode,
            this.GoodsMGroupCode,
            this.BLGroupCode,
            this.BLGoodsCode,
            this.Line_DetailHead,
            this.SalesMoney2,
            this.SalesMoney3,
            this.SalesMoney4,
            this.SalesMoney5,
            this.SalesMoney6,
            this.SalesMoney7,
            this.SalesMoney8,
            this.SalesMoney10,
            this.SalesMoney9,
            this.SalesMoney11,
            this.SalesMoney12,
            this.TotalSalesCount1,
            this.TotalSalesCount12,
            this.TotalSalesCount2,
            this.TotalSalesCount3,
            this.TotalSalesCount4,
            this.TotalSalesCount5,
            this.TotalSalesCount6,
            this.TotalSalesCount7,
            this.TotalSalesCount8,
            this.TotalSalesCount9,
            this.TotalSalesCount10,
            this.TotalSalesCount11,
            this.CodeNameHalf20,
            this.TtlSalesMoney,
            this.TtlTotalSalesCount,
            this.GoodsNo,
            this.GoodsNameKana,
            this.CodeNameFull20,
            this.CustomerCode,
            this.EmployeeCode,
            this.SectionCode,
            this.SupplierCode});
            this.Detail.Height = 0.688F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.03125F;
            this.GoodsMakerCd.Width = 0.3F;
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
            this.SalesMoney1.DataField = "SalesMoney1";
            this.SalesMoney1.Height = 0.156F;
            this.SalesMoney1.Left = 3.3125F;
            this.SalesMoney1.MultiLine = false;
            this.SalesMoney1.Name = "SalesMoney1";
            this.SalesMoney1.OutputFormat = resources.GetString("SalesMoney1.OutputFormat");
            this.SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney1.Text = "12,345,678";
            this.SalesMoney1.Top = 0.031F;
            this.SalesMoney1.Width = 0.55F;
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
            this.GoodsLGroupCode.Height = 0.156F;
            this.GoodsLGroupCode.Left = 0.3125F;
            this.GoodsLGroupCode.MultiLine = false;
            this.GoodsLGroupCode.Name = "GoodsLGroupCode";
            this.GoodsLGroupCode.OutputFormat = resources.GetString("GoodsLGroupCode.OutputFormat");
            this.GoodsLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsLGroupCode.Text = "1234";
            this.GoodsLGroupCode.Top = 0.25F;
            this.GoodsLGroupCode.Visible = false;
            this.GoodsLGroupCode.Width = 0.38F;
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
            this.GoodsMGroupCode.Height = 0.156F;
            this.GoodsMGroupCode.Left = 0.6875F;
            this.GoodsMGroupCode.MultiLine = false;
            this.GoodsMGroupCode.Name = "GoodsMGroupCode";
            this.GoodsMGroupCode.OutputFormat = resources.GetString("GoodsMGroupCode.OutputFormat");
            this.GoodsMGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMGroupCode.Text = "1234";
            this.GoodsMGroupCode.Top = 0.25F;
            this.GoodsMGroupCode.Visible = false;
            this.GoodsMGroupCode.Width = 0.38F;
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
            this.BLGroupCode.Left = 0.313F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0.031F;
            this.BLGroupCode.Width = 0.38F;
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
            this.BLGoodsCode.Left = 0.688F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0.031F;
            this.BLGoodsCode.Width = 0.37F;
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
            this.SalesMoney2.DataField = "SalesMoney2";
            this.SalesMoney2.Height = 0.156F;
            this.SalesMoney2.Left = 3.875F;
            this.SalesMoney2.MultiLine = false;
            this.SalesMoney2.Name = "SalesMoney2";
            this.SalesMoney2.OutputFormat = resources.GetString("SalesMoney2.OutputFormat");
            this.SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney2.Text = "12,345,678";
            this.SalesMoney2.Top = 0.031F;
            this.SalesMoney2.Width = 0.55F;
            // 
            // SalesMoney3
            // 
            this.SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney3.DataField = "SalesMoney3";
            this.SalesMoney3.Height = 0.156F;
            this.SalesMoney3.Left = 4.4375F;
            this.SalesMoney3.MultiLine = false;
            this.SalesMoney3.Name = "SalesMoney3";
            this.SalesMoney3.OutputFormat = resources.GetString("SalesMoney3.OutputFormat");
            this.SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney3.Text = "12,345,678";
            this.SalesMoney3.Top = 0.031F;
            this.SalesMoney3.Width = 0.55F;
            // 
            // SalesMoney4
            // 
            this.SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney4.DataField = "SalesMoney4";
            this.SalesMoney4.Height = 0.156F;
            this.SalesMoney4.Left = 5F;
            this.SalesMoney4.MultiLine = false;
            this.SalesMoney4.Name = "SalesMoney4";
            this.SalesMoney4.OutputFormat = resources.GetString("SalesMoney4.OutputFormat");
            this.SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney4.Text = "12,345,678";
            this.SalesMoney4.Top = 0.031F;
            this.SalesMoney4.Width = 0.55F;
            // 
            // SalesMoney5
            // 
            this.SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney5.DataField = "SalesMoney5";
            this.SalesMoney5.Height = 0.156F;
            this.SalesMoney5.Left = 5.5625F;
            this.SalesMoney5.MultiLine = false;
            this.SalesMoney5.Name = "SalesMoney5";
            this.SalesMoney5.OutputFormat = resources.GetString("SalesMoney5.OutputFormat");
            this.SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney5.Text = "12,345,678";
            this.SalesMoney5.Top = 0.031F;
            this.SalesMoney5.Width = 0.55F;
            // 
            // SalesMoney6
            // 
            this.SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney6.DataField = "SalesMoney6";
            this.SalesMoney6.Height = 0.156F;
            this.SalesMoney6.Left = 6.125F;
            this.SalesMoney6.MultiLine = false;
            this.SalesMoney6.Name = "SalesMoney6";
            this.SalesMoney6.OutputFormat = resources.GetString("SalesMoney6.OutputFormat");
            this.SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney6.Text = "12,345,678";
            this.SalesMoney6.Top = 0.031F;
            this.SalesMoney6.Width = 0.55F;
            // 
            // SalesMoney7
            // 
            this.SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney7.DataField = "SalesMoney7";
            this.SalesMoney7.Height = 0.156F;
            this.SalesMoney7.Left = 6.6875F;
            this.SalesMoney7.MultiLine = false;
            this.SalesMoney7.Name = "SalesMoney7";
            this.SalesMoney7.OutputFormat = resources.GetString("SalesMoney7.OutputFormat");
            this.SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney7.Text = "12,345,678";
            this.SalesMoney7.Top = 0.031F;
            this.SalesMoney7.Width = 0.55F;
            // 
            // SalesMoney8
            // 
            this.SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney8.DataField = "SalesMoney8";
            this.SalesMoney8.Height = 0.156F;
            this.SalesMoney8.Left = 7.25F;
            this.SalesMoney8.MultiLine = false;
            this.SalesMoney8.Name = "SalesMoney8";
            this.SalesMoney8.OutputFormat = resources.GetString("SalesMoney8.OutputFormat");
            this.SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney8.Text = "12,345,678";
            this.SalesMoney8.Top = 0.031F;
            this.SalesMoney8.Width = 0.55F;
            // 
            // SalesMoney10
            // 
            this.SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney10.DataField = "SalesMoney10";
            this.SalesMoney10.Height = 0.156F;
            this.SalesMoney10.Left = 8.375F;
            this.SalesMoney10.MultiLine = false;
            this.SalesMoney10.Name = "SalesMoney10";
            this.SalesMoney10.OutputFormat = resources.GetString("SalesMoney10.OutputFormat");
            this.SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney10.Text = "12,345,678";
            this.SalesMoney10.Top = 0.031F;
            this.SalesMoney10.Width = 0.55F;
            // 
            // SalesMoney9
            // 
            this.SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney9.DataField = "SalesMoney9";
            this.SalesMoney9.Height = 0.156F;
            this.SalesMoney9.Left = 7.8125F;
            this.SalesMoney9.MultiLine = false;
            this.SalesMoney9.Name = "SalesMoney9";
            this.SalesMoney9.OutputFormat = resources.GetString("SalesMoney9.OutputFormat");
            this.SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney9.Text = "12,345,678";
            this.SalesMoney9.Top = 0.031F;
            this.SalesMoney9.Width = 0.55F;
            // 
            // SalesMoney11
            // 
            this.SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney11.DataField = "SalesMoney11";
            this.SalesMoney11.Height = 0.156F;
            this.SalesMoney11.Left = 8.9375F;
            this.SalesMoney11.MultiLine = false;
            this.SalesMoney11.Name = "SalesMoney11";
            this.SalesMoney11.OutputFormat = resources.GetString("SalesMoney11.OutputFormat");
            this.SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney11.Text = "12,345,678";
            this.SalesMoney11.Top = 0.031F;
            this.SalesMoney11.Width = 0.55F;
            // 
            // SalesMoney12
            // 
            this.SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney12.DataField = "SalesMoney12";
            this.SalesMoney12.Height = 0.156F;
            this.SalesMoney12.Left = 9.5F;
            this.SalesMoney12.MultiLine = false;
            this.SalesMoney12.Name = "SalesMoney12";
            this.SalesMoney12.OutputFormat = resources.GetString("SalesMoney12.OutputFormat");
            this.SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoney12.Text = "12,345,678";
            this.SalesMoney12.Top = 0.031F;
            this.SalesMoney12.Width = 0.55F;
            // 
            // TotalSalesCount1
            // 
            this.TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount1.DataField = "TotalSalesCount1";
            this.TotalSalesCount1.Height = 0.156F;
            this.TotalSalesCount1.Left = 3.3125F;
            this.TotalSalesCount1.MultiLine = false;
            this.TotalSalesCount1.Name = "TotalSalesCount1";
            this.TotalSalesCount1.OutputFormat = resources.GetString("TotalSalesCount1.OutputFormat");
            this.TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount1.Text = "12,345,678";
            this.TotalSalesCount1.Top = 0.1875F;
            this.TotalSalesCount1.Width = 0.55F;
            // 
            // TotalSalesCount12
            // 
            this.TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount12.DataField = "TotalSalesCount12";
            this.TotalSalesCount12.Height = 0.156F;
            this.TotalSalesCount12.Left = 9.5F;
            this.TotalSalesCount12.MultiLine = false;
            this.TotalSalesCount12.Name = "TotalSalesCount12";
            this.TotalSalesCount12.OutputFormat = resources.GetString("TotalSalesCount12.OutputFormat");
            this.TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount12.Text = "12,345,678";
            this.TotalSalesCount12.Top = 0.1875F;
            this.TotalSalesCount12.Width = 0.55F;
            // 
            // TotalSalesCount2
            // 
            this.TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount2.DataField = "TotalSalesCount2";
            this.TotalSalesCount2.Height = 0.156F;
            this.TotalSalesCount2.Left = 3.875F;
            this.TotalSalesCount2.MultiLine = false;
            this.TotalSalesCount2.Name = "TotalSalesCount2";
            this.TotalSalesCount2.OutputFormat = resources.GetString("TotalSalesCount2.OutputFormat");
            this.TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount2.Text = "12,345,678";
            this.TotalSalesCount2.Top = 0.1875F;
            this.TotalSalesCount2.Width = 0.55F;
            // 
            // TotalSalesCount3
            // 
            this.TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount3.DataField = "TotalSalesCount3";
            this.TotalSalesCount3.Height = 0.156F;
            this.TotalSalesCount3.Left = 4.4375F;
            this.TotalSalesCount3.MultiLine = false;
            this.TotalSalesCount3.Name = "TotalSalesCount3";
            this.TotalSalesCount3.OutputFormat = resources.GetString("TotalSalesCount3.OutputFormat");
            this.TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount3.Text = "12,345,678";
            this.TotalSalesCount3.Top = 0.1875F;
            this.TotalSalesCount3.Width = 0.55F;
            // 
            // TotalSalesCount4
            // 
            this.TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount4.DataField = "TotalSalesCount4";
            this.TotalSalesCount4.Height = 0.156F;
            this.TotalSalesCount4.Left = 5F;
            this.TotalSalesCount4.MultiLine = false;
            this.TotalSalesCount4.Name = "TotalSalesCount4";
            this.TotalSalesCount4.OutputFormat = resources.GetString("TotalSalesCount4.OutputFormat");
            this.TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount4.Text = "12,345,678";
            this.TotalSalesCount4.Top = 0.1875F;
            this.TotalSalesCount4.Width = 0.55F;
            // 
            // TotalSalesCount5
            // 
            this.TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount5.DataField = "TotalSalesCount5";
            this.TotalSalesCount5.Height = 0.156F;
            this.TotalSalesCount5.Left = 5.5625F;
            this.TotalSalesCount5.MultiLine = false;
            this.TotalSalesCount5.Name = "TotalSalesCount5";
            this.TotalSalesCount5.OutputFormat = resources.GetString("TotalSalesCount5.OutputFormat");
            this.TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount5.Text = "12,345,678";
            this.TotalSalesCount5.Top = 0.1875F;
            this.TotalSalesCount5.Width = 0.55F;
            // 
            // TotalSalesCount6
            // 
            this.TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount6.DataField = "TotalSalesCount6";
            this.TotalSalesCount6.Height = 0.156F;
            this.TotalSalesCount6.Left = 6.125F;
            this.TotalSalesCount6.MultiLine = false;
            this.TotalSalesCount6.Name = "TotalSalesCount6";
            this.TotalSalesCount6.OutputFormat = resources.GetString("TotalSalesCount6.OutputFormat");
            this.TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount6.Text = "12,345,678";
            this.TotalSalesCount6.Top = 0.1875F;
            this.TotalSalesCount6.Width = 0.55F;
            // 
            // TotalSalesCount7
            // 
            this.TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount7.DataField = "TotalSalesCount7";
            this.TotalSalesCount7.Height = 0.156F;
            this.TotalSalesCount7.Left = 6.6875F;
            this.TotalSalesCount7.MultiLine = false;
            this.TotalSalesCount7.Name = "TotalSalesCount7";
            this.TotalSalesCount7.OutputFormat = resources.GetString("TotalSalesCount7.OutputFormat");
            this.TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount7.Text = "12,345,678";
            this.TotalSalesCount7.Top = 0.1875F;
            this.TotalSalesCount7.Width = 0.55F;
            // 
            // TotalSalesCount8
            // 
            this.TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount8.DataField = "TotalSalesCount8";
            this.TotalSalesCount8.Height = 0.156F;
            this.TotalSalesCount8.Left = 7.25F;
            this.TotalSalesCount8.MultiLine = false;
            this.TotalSalesCount8.Name = "TotalSalesCount8";
            this.TotalSalesCount8.OutputFormat = resources.GetString("TotalSalesCount8.OutputFormat");
            this.TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount8.Text = "12,345,678";
            this.TotalSalesCount8.Top = 0.1875F;
            this.TotalSalesCount8.Width = 0.55F;
            // 
            // TotalSalesCount9
            // 
            this.TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount9.DataField = "TotalSalesCount9";
            this.TotalSalesCount9.Height = 0.156F;
            this.TotalSalesCount9.Left = 7.8125F;
            this.TotalSalesCount9.MultiLine = false;
            this.TotalSalesCount9.Name = "TotalSalesCount9";
            this.TotalSalesCount9.OutputFormat = resources.GetString("TotalSalesCount9.OutputFormat");
            this.TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount9.Text = "12,345,678";
            this.TotalSalesCount9.Top = 0.1875F;
            this.TotalSalesCount9.Width = 0.55F;
            // 
            // TotalSalesCount10
            // 
            this.TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount10.DataField = "TotalSalesCount10";
            this.TotalSalesCount10.Height = 0.156F;
            this.TotalSalesCount10.Left = 8.375F;
            this.TotalSalesCount10.MultiLine = false;
            this.TotalSalesCount10.Name = "TotalSalesCount10";
            this.TotalSalesCount10.OutputFormat = resources.GetString("TotalSalesCount10.OutputFormat");
            this.TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount10.Text = "12,345,678";
            this.TotalSalesCount10.Top = 0.1875F;
            this.TotalSalesCount10.Width = 0.55F;
            // 
            // TotalSalesCount11
            // 
            this.TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount11.DataField = "TotalSalesCount11";
            this.TotalSalesCount11.Height = 0.156F;
            this.TotalSalesCount11.Left = 8.9375F;
            this.TotalSalesCount11.MultiLine = false;
            this.TotalSalesCount11.Name = "TotalSalesCount11";
            this.TotalSalesCount11.OutputFormat = resources.GetString("TotalSalesCount11.OutputFormat");
            this.TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalSalesCount11.Text = "12,345,678";
            this.TotalSalesCount11.Top = 0.1875F;
            this.TotalSalesCount11.Width = 0.55F;
            // 
            // CodeNameHalf20
            // 
            this.CodeNameHalf20.Border.BottomColor = System.Drawing.Color.Black;
            this.CodeNameHalf20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameHalf20.Border.LeftColor = System.Drawing.Color.Black;
            this.CodeNameHalf20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameHalf20.Border.RightColor = System.Drawing.Color.Black;
            this.CodeNameHalf20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameHalf20.Border.TopColor = System.Drawing.Color.Black;
            this.CodeNameHalf20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeNameHalf20.Height = 0.15625F;
            this.CodeNameHalf20.Left = 1.0625F;
            this.CodeNameHalf20.MultiLine = false;
            this.CodeNameHalf20.Name = "CodeNameHalf20";
            this.CodeNameHalf20.OutputFormat = resources.GetString("CodeNameHalf20.OutputFormat");
            this.CodeNameHalf20.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CodeNameHalf20.Text = "あいうえおかきくけこ";
            this.CodeNameHalf20.Top = 0.25F;
            this.CodeNameHalf20.Visible = false;
            this.CodeNameHalf20.Width = 1.1875F;
            // 
            // TtlSalesMoney
            // 
            this.TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlSalesMoney.DataField = "TtlSalesMoney";
            this.TtlSalesMoney.Height = 0.156F;
            this.TtlSalesMoney.Left = 10.0625F;
            this.TtlSalesMoney.MultiLine = false;
            this.TtlSalesMoney.Name = "TtlSalesMoney";
            this.TtlSalesMoney.OutputFormat = resources.GetString("TtlSalesMoney.OutputFormat");
            this.TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TtlSalesMoney.Text = "1,234,567,890";
            this.TtlSalesMoney.Top = 0.031F;
            this.TtlSalesMoney.Width = 0.6875F;
            // 
            // TtlTotalSalesCount
            // 
            this.TtlTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.TtlTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.TtlTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.TtlTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.TtlTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.TtlTotalSalesCount.Height = 0.156F;
            this.TtlTotalSalesCount.Left = 10.0625F;
            this.TtlTotalSalesCount.MultiLine = false;
            this.TtlTotalSalesCount.Name = "TtlTotalSalesCount";
            this.TtlTotalSalesCount.OutputFormat = resources.GetString("TtlTotalSalesCount.OutputFormat");
            this.TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TtlTotalSalesCount.Text = "1,234,567,890";
            this.TtlTotalSalesCount.Top = 0.1875F;
            this.TtlTotalSalesCount.Width = 0.688F;
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
            this.GoodsNo.Left = 1.0625F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.031F;
            this.GoodsNo.Width = 1.25F;
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
            this.GoodsNameKana.Left = 2.3125F;
            this.GoodsNameKana.MultiLine = false;
            this.GoodsNameKana.Name = "GoodsNameKana";
            this.GoodsNameKana.OutputFormat = resources.GetString("GoodsNameKana.OutputFormat");
            this.GoodsNameKana.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNameKana.Text = "12345678901234567890";
            this.GoodsNameKana.Top = 0.031F;
            this.GoodsNameKana.Width = 1F;
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
            this.CodeNameFull20.Left = 1.0625F;
            this.CodeNameFull20.MultiLine = false;
            this.CodeNameFull20.Name = "CodeNameFull20";
            this.CodeNameFull20.OutputFormat = resources.GetString("CodeNameFull20.OutputFormat");
            this.CodeNameFull20.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CodeNameFull20.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CodeNameFull20.Top = 0.469F;
            this.CodeNameFull20.Visible = false;
            this.CodeNameFull20.Width = 2.25F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.156F;
            this.CustomerCode.Left = 0.1875F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CustomerCode.Text = "12345678";
            this.CustomerCode.Top = 0.46875F;
            this.CustomerCode.Visible = false;
            this.CustomerCode.Width = 0.5F;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.DataField = "EmployeeCode";
            this.EmployeeCode.Height = 0.156F;
            this.EmployeeCode.Left = 0.6875F;
            this.EmployeeCode.MultiLine = false;
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.OutputFormat = resources.GetString("EmployeeCode.OutputFormat");
            this.EmployeeCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.EmployeeCode.Text = "1234";
            this.EmployeeCode.Top = 0.46875F;
            this.EmployeeCode.Visible = false;
            this.EmployeeCode.Width = 0.38F;
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
            this.SectionCode.DataField = "AddUpSecCode";
            this.SectionCode.Height = 0.156F;
            this.SectionCode.Left = 0F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SectionCode.Text = "12";
            this.SectionCode.Top = 0.46875F;
            this.SectionCode.Visible = false;
            this.SectionCode.Width = 0.2F;
            // 
            // SupplierCode
            // 
            this.SupplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCode.DataField = "SupplierCode";
            this.SupplierCode.Height = 0.156F;
            this.SupplierCode.Left = 3.3125F;
            this.SupplierCode.MultiLine = false;
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.OutputFormat = resources.GetString("SupplierCode.OutputFormat");
            this.SupplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupplierCode.Text = "123456";
            this.SupplierCode.Top = 0.46875F;
            this.SupplierCode.Visible = false;
            this.SupplierCode.Width = 0.38F;
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
            this.tb_ReportTitle.Text = "売上推移表";
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
            this.SortTitle.Left = 4.6875F;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "font-size: 8pt; vertical-align: top; ";
            this.SortTitle.Text = "[拠点 コード順/カナ順]";
            this.SortTitle.Top = 0.0625F;
            this.SortTitle.Width = 3.15F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.28125F;
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
            this.Lb_GoodsNo,
            this.Lb_BLGoodsCode,
            this.Lb_BLGroupCode,
            this.Lb_Month1,
            this.Lb_Month2,
            this.Lb_Month3,
            this.Lb_Month4,
            this.Lb_Month7,
            this.Lb_Month5,
            this.Lb_Month6,
            this.Lb_Month11,
            this.Lb_Month8,
            this.Lb_Month9,
            this.Lb_Month10,
            this.Lb_Month12,
            this.Lb_Total,
            this.Lb_GoodsLGroup,
            this.Lb_GoodsMGroup,
            this.Lb_Customer,
            this.Lb_Employee,
            this.Lb_Section,
            this.Lb_Supplier});
            this.TitleHeader.Height = 0.646F;
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
            this.Line42.Width = 10.8125F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8125F;
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
            this.Lb_GoodsName.Left = 2.313F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.03099999F;
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
            this.Lb_MakerName.Top = 0.03125F;
            this.Lb_MakerName.Width = 0.3F;
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
            this.Lb_GoodsNo.Left = 1.063F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.031F;
            this.Lb_GoodsNo.Width = 0.75F;
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
            this.Lb_BLGoodsCode.Height = 0.156F;
            this.Lb_BLGoodsCode.HyperLink = "";
            this.Lb_BLGoodsCode.Left = 0.688F;
            this.Lb_BLGoodsCode.MultiLine = false;
            this.Lb_BLGoodsCode.Name = "Lb_BLGoodsCode";
            this.Lb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode.Text = "BLｺｰﾄﾞ";
            this.Lb_BLGoodsCode.Top = 0.031F;
            this.Lb_BLGoodsCode.Width = 0.37F;
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
            this.Lb_BLGroupCode.Left = 0.313F;
            this.Lb_BLGroupCode.MultiLine = false;
            this.Lb_BLGroupCode.Name = "Lb_BLGroupCode";
            this.Lb_BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGroupCode.Text = "ｸﾞﾙｰﾌﾟ";
            this.Lb_BLGroupCode.Top = 0.031F;
            this.Lb_BLGroupCode.Width = 0.38F;
            // 
            // Lb_Month1
            // 
            this.Lb_Month1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month1.Height = 0.156F;
            this.Lb_Month1.HyperLink = "";
            this.Lb_Month1.Left = 3.3125F;
            this.Lb_Month1.MultiLine = false;
            this.Lb_Month1.Name = "Lb_Month1";
            this.Lb_Month1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month1.Text = "x1月";
            this.Lb_Month1.Top = 0.031F;
            this.Lb_Month1.Width = 0.55F;
            // 
            // Lb_Month2
            // 
            this.Lb_Month2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month2.Height = 0.156F;
            this.Lb_Month2.HyperLink = "";
            this.Lb_Month2.Left = 3.875F;
            this.Lb_Month2.MultiLine = false;
            this.Lb_Month2.Name = "Lb_Month2";
            this.Lb_Month2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month2.Text = "x2月";
            this.Lb_Month2.Top = 0.031F;
            this.Lb_Month2.Width = 0.55F;
            // 
            // Lb_Month3
            // 
            this.Lb_Month3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month3.Height = 0.156F;
            this.Lb_Month3.HyperLink = "";
            this.Lb_Month3.Left = 4.4375F;
            this.Lb_Month3.MultiLine = false;
            this.Lb_Month3.Name = "Lb_Month3";
            this.Lb_Month3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month3.Text = "x3月";
            this.Lb_Month3.Top = 0.031F;
            this.Lb_Month3.Width = 0.55F;
            // 
            // Lb_Month4
            // 
            this.Lb_Month4.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month4.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month4.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month4.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month4.Height = 0.156F;
            this.Lb_Month4.HyperLink = "";
            this.Lb_Month4.Left = 5F;
            this.Lb_Month4.MultiLine = false;
            this.Lb_Month4.Name = "Lb_Month4";
            this.Lb_Month4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month4.Text = "x4月";
            this.Lb_Month4.Top = 0.031F;
            this.Lb_Month4.Width = 0.55F;
            // 
            // Lb_Month7
            // 
            this.Lb_Month7.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month7.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month7.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month7.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month7.Height = 0.156F;
            this.Lb_Month7.HyperLink = "";
            this.Lb_Month7.Left = 6.6875F;
            this.Lb_Month7.MultiLine = false;
            this.Lb_Month7.Name = "Lb_Month7";
            this.Lb_Month7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month7.Text = "x7月";
            this.Lb_Month7.Top = 0.031F;
            this.Lb_Month7.Width = 0.55F;
            // 
            // Lb_Month5
            // 
            this.Lb_Month5.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month5.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month5.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month5.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month5.Height = 0.156F;
            this.Lb_Month5.HyperLink = "";
            this.Lb_Month5.Left = 5.5625F;
            this.Lb_Month5.MultiLine = false;
            this.Lb_Month5.Name = "Lb_Month5";
            this.Lb_Month5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month5.Text = "x5月";
            this.Lb_Month5.Top = 0.031F;
            this.Lb_Month5.Width = 0.55F;
            // 
            // Lb_Month6
            // 
            this.Lb_Month6.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month6.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month6.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month6.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month6.Height = 0.156F;
            this.Lb_Month6.HyperLink = "";
            this.Lb_Month6.Left = 6.125F;
            this.Lb_Month6.MultiLine = false;
            this.Lb_Month6.Name = "Lb_Month6";
            this.Lb_Month6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month6.Text = "x6月";
            this.Lb_Month6.Top = 0.031F;
            this.Lb_Month6.Width = 0.55F;
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
            this.Lb_Month11.Left = 8.9375F;
            this.Lb_Month11.MultiLine = false;
            this.Lb_Month11.Name = "Lb_Month11";
            this.Lb_Month11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month11.Text = "11月";
            this.Lb_Month11.Top = 0.031F;
            this.Lb_Month11.Width = 0.55F;
            // 
            // Lb_Month8
            // 
            this.Lb_Month8.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month8.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month8.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month8.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month8.Height = 0.156F;
            this.Lb_Month8.HyperLink = "";
            this.Lb_Month8.Left = 7.25F;
            this.Lb_Month8.MultiLine = false;
            this.Lb_Month8.Name = "Lb_Month8";
            this.Lb_Month8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month8.Text = "x8月";
            this.Lb_Month8.Top = 0.031F;
            this.Lb_Month8.Width = 0.55F;
            // 
            // Lb_Month9
            // 
            this.Lb_Month9.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month9.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month9.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month9.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month9.Height = 0.156F;
            this.Lb_Month9.HyperLink = "";
            this.Lb_Month9.Left = 7.8125F;
            this.Lb_Month9.MultiLine = false;
            this.Lb_Month9.Name = "Lb_Month9";
            this.Lb_Month9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month9.Text = "x9月";
            this.Lb_Month9.Top = 0.031F;
            this.Lb_Month9.Width = 0.55F;
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
            this.Lb_Month10.Left = 8.375F;
            this.Lb_Month10.MultiLine = false;
            this.Lb_Month10.Name = "Lb_Month10";
            this.Lb_Month10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month10.Text = "10月";
            this.Lb_Month10.Top = 0.031F;
            this.Lb_Month10.Width = 0.55F;
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
            this.Lb_Month12.Left = 9.5F;
            this.Lb_Month12.MultiLine = false;
            this.Lb_Month12.Name = "Lb_Month12";
            this.Lb_Month12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month12.Text = "12月";
            this.Lb_Month12.Top = 0.031F;
            this.Lb_Month12.Width = 0.55F;
            // 
            // Lb_Total
            // 
            this.Lb_Total.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Total.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Total.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Total.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Total.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Total.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Total.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Total.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Total.Height = 0.156F;
            this.Lb_Total.HyperLink = "";
            this.Lb_Total.Left = 10.0625F;
            this.Lb_Total.MultiLine = false;
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Total.Text = "合計";
            this.Lb_Total.Top = 0.031F;
            this.Lb_Total.Width = 0.688F;
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
            this.Lb_GoodsLGroup.Left = 0.313F;
            this.Lb_GoodsLGroup.MultiLine = false;
            this.Lb_GoodsLGroup.Name = "Lb_GoodsLGroup";
            this.Lb_GoodsLGroup.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsLGroup.Text = "大分類";
            this.Lb_GoodsLGroup.Top = 0.2495F;
            this.Lb_GoodsLGroup.Visible = false;
            this.Lb_GoodsLGroup.Width = 0.38F;
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
            this.Lb_GoodsMGroup.Left = 0.688F;
            this.Lb_GoodsMGroup.MultiLine = false;
            this.Lb_GoodsMGroup.Name = "Lb_GoodsMGroup";
            this.Lb_GoodsMGroup.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMGroup.Text = "中分類";
            this.Lb_GoodsMGroup.Top = 0.25F;
            this.Lb_GoodsMGroup.Visible = false;
            this.Lb_GoodsMGroup.Width = 0.38F;
            // 
            // Lb_Customer
            // 
            this.Lb_Customer.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Height = 0.156F;
            this.Lb_Customer.HyperLink = "";
            this.Lb_Customer.Left = 0.3125F;
            this.Lb_Customer.MultiLine = false;
            this.Lb_Customer.Name = "Lb_Customer";
            this.Lb_Customer.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer.Text = "得意先";
            this.Lb_Customer.Top = 0.4375F;
            this.Lb_Customer.Visible = false;
            this.Lb_Customer.Width = 0.38F;
            // 
            // Lb_Employee
            // 
            this.Lb_Employee.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Height = 0.156F;
            this.Lb_Employee.HyperLink = "";
            this.Lb_Employee.Left = 0.6875F;
            this.Lb_Employee.MultiLine = false;
            this.Lb_Employee.Name = "Lb_Employee";
            this.Lb_Employee.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Employee.Text = "担当者";
            this.Lb_Employee.Top = 0.4375F;
            this.Lb_Employee.Visible = false;
            this.Lb_Employee.Width = 0.38F;
            // 
            // Lb_Section
            // 
            this.Lb_Section.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Section.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Section.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Section.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Section.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Section.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Section.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Section.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Section.Height = 0.156F;
            this.Lb_Section.HyperLink = "";
            this.Lb_Section.Left = 1.0625F;
            this.Lb_Section.MultiLine = false;
            this.Lb_Section.Name = "Lb_Section";
            this.Lb_Section.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Section.Text = "拠点";
            this.Lb_Section.Top = 0.4375F;
            this.Lb_Section.Visible = false;
            this.Lb_Section.Width = 0.38F;
            // 
            // Lb_Supplier
            // 
            this.Lb_Supplier.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Supplier.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Supplier.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Supplier.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Supplier.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Supplier.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Supplier.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Supplier.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Supplier.Height = 0.156F;
            this.Lb_Supplier.HyperLink = "";
            this.Lb_Supplier.Left = 1.4375F;
            this.Lb_Supplier.MultiLine = false;
            this.Lb_Supplier.Name = "Lb_Supplier";
            this.Lb_Supplier.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Supplier.Text = "仕入先";
            this.Lb_Supplier.Top = 0.4375F;
            this.Lb_Supplier.Visible = false;
            this.Lb_Supplier.Width = 0.38F;
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
            this.Line41.Visible = false;
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
            this.Ttl_SalesMoney1,
            this.Ttl_SalesMoney2,
            this.Ttl_SalesMoney3,
            this.Ttl_SalesMoney4,
            this.Ttl_SalesMoney5,
            this.Ttl_SalesMoney6,
            this.Ttl_SalesMoney7,
            this.Ttl_SalesMoney8,
            this.Ttl_SalesMoney9,
            this.Ttl_SalesMoney10,
            this.Ttl_SalesMoney11,
            this.Ttl_SalesMoney12,
            this.Ttl_TotalSalesCount1,
            this.Ttl_TotalSalesCount2,
            this.Ttl_TotalSalesCount3,
            this.Ttl_TotalSalesCount4,
            this.Ttl_TotalSalesCount5,
            this.Ttl_TotalSalesCount6,
            this.Ttl_TotalSalesCount7,
            this.Ttl_TotalSalesCount8,
            this.Ttl_TotalSalesCount9,
            this.Ttl_TotalSalesCount10,
            this.Ttl_TotalSalesCount11,
            this.Ttl_TotalSalesCount12,
            this.Ttl_TtlTotalSalesCount,
            this.Ttl_TtlSalesMoney});
            this.GrandTotalFooter.Height = 0.406F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.Ttl_Title.Left = 0.4375F;
            this.Ttl_Title.MultiLine = false;
            this.Ttl_Title.Name = "Ttl_Title";
            this.Ttl_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Ttl_Title.Text = "総合計";
            this.Ttl_Title.Top = 0.0625F;
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
            // Ttl_SalesMoney1
            // 
            this.Ttl_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney1.DataField = "SalesMoney1";
            this.Ttl_SalesMoney1.Height = 0.156F;
            this.Ttl_SalesMoney1.Left = 3.3125F;
            this.Ttl_SalesMoney1.MultiLine = false;
            this.Ttl_SalesMoney1.Name = "Ttl_SalesMoney1";
            this.Ttl_SalesMoney1.OutputFormat = resources.GetString("Ttl_SalesMoney1.OutputFormat");
            this.Ttl_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney1.Text = "12,345,678";
            this.Ttl_SalesMoney1.Top = 0.0625F;
            this.Ttl_SalesMoney1.Width = 0.55F;
            // 
            // Ttl_SalesMoney2
            // 
            this.Ttl_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney2.DataField = "SalesMoney2";
            this.Ttl_SalesMoney2.Height = 0.156F;
            this.Ttl_SalesMoney2.Left = 3.875F;
            this.Ttl_SalesMoney2.MultiLine = false;
            this.Ttl_SalesMoney2.Name = "Ttl_SalesMoney2";
            this.Ttl_SalesMoney2.OutputFormat = resources.GetString("Ttl_SalesMoney2.OutputFormat");
            this.Ttl_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney2.Text = "12,345,678";
            this.Ttl_SalesMoney2.Top = 0.0625F;
            this.Ttl_SalesMoney2.Width = 0.55F;
            // 
            // Ttl_SalesMoney3
            // 
            this.Ttl_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney3.DataField = "SalesMoney3";
            this.Ttl_SalesMoney3.Height = 0.156F;
            this.Ttl_SalesMoney3.Left = 4.4375F;
            this.Ttl_SalesMoney3.MultiLine = false;
            this.Ttl_SalesMoney3.Name = "Ttl_SalesMoney3";
            this.Ttl_SalesMoney3.OutputFormat = resources.GetString("Ttl_SalesMoney3.OutputFormat");
            this.Ttl_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney3.Text = "12,345,678";
            this.Ttl_SalesMoney3.Top = 0.0625F;
            this.Ttl_SalesMoney3.Width = 0.55F;
            // 
            // Ttl_SalesMoney4
            // 
            this.Ttl_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney4.DataField = "SalesMoney4";
            this.Ttl_SalesMoney4.Height = 0.156F;
            this.Ttl_SalesMoney4.Left = 5F;
            this.Ttl_SalesMoney4.MultiLine = false;
            this.Ttl_SalesMoney4.Name = "Ttl_SalesMoney4";
            this.Ttl_SalesMoney4.OutputFormat = resources.GetString("Ttl_SalesMoney4.OutputFormat");
            this.Ttl_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney4.Text = "12,345,678";
            this.Ttl_SalesMoney4.Top = 0.0625F;
            this.Ttl_SalesMoney4.Width = 0.55F;
            // 
            // Ttl_SalesMoney5
            // 
            this.Ttl_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney5.DataField = "SalesMoney5";
            this.Ttl_SalesMoney5.Height = 0.156F;
            this.Ttl_SalesMoney5.Left = 5.5625F;
            this.Ttl_SalesMoney5.MultiLine = false;
            this.Ttl_SalesMoney5.Name = "Ttl_SalesMoney5";
            this.Ttl_SalesMoney5.OutputFormat = resources.GetString("Ttl_SalesMoney5.OutputFormat");
            this.Ttl_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney5.Text = "12,345,678";
            this.Ttl_SalesMoney5.Top = 0.0625F;
            this.Ttl_SalesMoney5.Width = 0.55F;
            // 
            // Ttl_SalesMoney6
            // 
            this.Ttl_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney6.DataField = "SalesMoney6";
            this.Ttl_SalesMoney6.Height = 0.156F;
            this.Ttl_SalesMoney6.Left = 6.125F;
            this.Ttl_SalesMoney6.MultiLine = false;
            this.Ttl_SalesMoney6.Name = "Ttl_SalesMoney6";
            this.Ttl_SalesMoney6.OutputFormat = resources.GetString("Ttl_SalesMoney6.OutputFormat");
            this.Ttl_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney6.Text = "12,345,678";
            this.Ttl_SalesMoney6.Top = 0.0625F;
            this.Ttl_SalesMoney6.Width = 0.55F;
            // 
            // Ttl_SalesMoney7
            // 
            this.Ttl_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney7.DataField = "SalesMoney7";
            this.Ttl_SalesMoney7.Height = 0.156F;
            this.Ttl_SalesMoney7.Left = 6.6875F;
            this.Ttl_SalesMoney7.MultiLine = false;
            this.Ttl_SalesMoney7.Name = "Ttl_SalesMoney7";
            this.Ttl_SalesMoney7.OutputFormat = resources.GetString("Ttl_SalesMoney7.OutputFormat");
            this.Ttl_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney7.Text = "12,345,678";
            this.Ttl_SalesMoney7.Top = 0.0625F;
            this.Ttl_SalesMoney7.Width = 0.55F;
            // 
            // Ttl_SalesMoney8
            // 
            this.Ttl_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney8.DataField = "SalesMoney8";
            this.Ttl_SalesMoney8.Height = 0.156F;
            this.Ttl_SalesMoney8.Left = 7.25F;
            this.Ttl_SalesMoney8.MultiLine = false;
            this.Ttl_SalesMoney8.Name = "Ttl_SalesMoney8";
            this.Ttl_SalesMoney8.OutputFormat = resources.GetString("Ttl_SalesMoney8.OutputFormat");
            this.Ttl_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney8.Text = "12,345,678";
            this.Ttl_SalesMoney8.Top = 0.0625F;
            this.Ttl_SalesMoney8.Width = 0.55F;
            // 
            // Ttl_SalesMoney9
            // 
            this.Ttl_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney9.DataField = "SalesMoney9";
            this.Ttl_SalesMoney9.Height = 0.156F;
            this.Ttl_SalesMoney9.Left = 7.8125F;
            this.Ttl_SalesMoney9.MultiLine = false;
            this.Ttl_SalesMoney9.Name = "Ttl_SalesMoney9";
            this.Ttl_SalesMoney9.OutputFormat = resources.GetString("Ttl_SalesMoney9.OutputFormat");
            this.Ttl_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney9.Text = "12,345,678";
            this.Ttl_SalesMoney9.Top = 0.0625F;
            this.Ttl_SalesMoney9.Width = 0.55F;
            // 
            // Ttl_SalesMoney10
            // 
            this.Ttl_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney10.DataField = "SalesMoney10";
            this.Ttl_SalesMoney10.Height = 0.156F;
            this.Ttl_SalesMoney10.Left = 8.375F;
            this.Ttl_SalesMoney10.MultiLine = false;
            this.Ttl_SalesMoney10.Name = "Ttl_SalesMoney10";
            this.Ttl_SalesMoney10.OutputFormat = resources.GetString("Ttl_SalesMoney10.OutputFormat");
            this.Ttl_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney10.Text = "12,345,678";
            this.Ttl_SalesMoney10.Top = 0.0625F;
            this.Ttl_SalesMoney10.Width = 0.55F;
            // 
            // Ttl_SalesMoney11
            // 
            this.Ttl_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney11.DataField = "SalesMoney11";
            this.Ttl_SalesMoney11.Height = 0.156F;
            this.Ttl_SalesMoney11.Left = 8.9375F;
            this.Ttl_SalesMoney11.MultiLine = false;
            this.Ttl_SalesMoney11.Name = "Ttl_SalesMoney11";
            this.Ttl_SalesMoney11.OutputFormat = resources.GetString("Ttl_SalesMoney11.OutputFormat");
            this.Ttl_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney11.Text = "12,345,678";
            this.Ttl_SalesMoney11.Top = 0.0625F;
            this.Ttl_SalesMoney11.Width = 0.55F;
            // 
            // Ttl_SalesMoney12
            // 
            this.Ttl_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoney12.DataField = "SalesMoney12";
            this.Ttl_SalesMoney12.Height = 0.156F;
            this.Ttl_SalesMoney12.Left = 9.5F;
            this.Ttl_SalesMoney12.MultiLine = false;
            this.Ttl_SalesMoney12.Name = "Ttl_SalesMoney12";
            this.Ttl_SalesMoney12.OutputFormat = resources.GetString("Ttl_SalesMoney12.OutputFormat");
            this.Ttl_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoney12.Text = "12,345,678";
            this.Ttl_SalesMoney12.Top = 0.0625F;
            this.Ttl_SalesMoney12.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount1
            // 
            this.Ttl_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.Ttl_TotalSalesCount1.Height = 0.156F;
            this.Ttl_TotalSalesCount1.Left = 3.3125F;
            this.Ttl_TotalSalesCount1.MultiLine = false;
            this.Ttl_TotalSalesCount1.Name = "Ttl_TotalSalesCount1";
            this.Ttl_TotalSalesCount1.OutputFormat = resources.GetString("Ttl_TotalSalesCount1.OutputFormat");
            this.Ttl_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount1.Text = "12,345,678";
            this.Ttl_TotalSalesCount1.Top = 0.219F;
            this.Ttl_TotalSalesCount1.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount2
            // 
            this.Ttl_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.Ttl_TotalSalesCount2.Height = 0.156F;
            this.Ttl_TotalSalesCount2.Left = 3.875F;
            this.Ttl_TotalSalesCount2.MultiLine = false;
            this.Ttl_TotalSalesCount2.Name = "Ttl_TotalSalesCount2";
            this.Ttl_TotalSalesCount2.OutputFormat = resources.GetString("Ttl_TotalSalesCount2.OutputFormat");
            this.Ttl_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount2.Text = "12,345,678";
            this.Ttl_TotalSalesCount2.Top = 0.219F;
            this.Ttl_TotalSalesCount2.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount3
            // 
            this.Ttl_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.Ttl_TotalSalesCount3.Height = 0.156F;
            this.Ttl_TotalSalesCount3.Left = 4.4375F;
            this.Ttl_TotalSalesCount3.MultiLine = false;
            this.Ttl_TotalSalesCount3.Name = "Ttl_TotalSalesCount3";
            this.Ttl_TotalSalesCount3.OutputFormat = resources.GetString("Ttl_TotalSalesCount3.OutputFormat");
            this.Ttl_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount3.Text = "12,345,678";
            this.Ttl_TotalSalesCount3.Top = 0.219F;
            this.Ttl_TotalSalesCount3.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount4
            // 
            this.Ttl_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.Ttl_TotalSalesCount4.Height = 0.156F;
            this.Ttl_TotalSalesCount4.Left = 5F;
            this.Ttl_TotalSalesCount4.MultiLine = false;
            this.Ttl_TotalSalesCount4.Name = "Ttl_TotalSalesCount4";
            this.Ttl_TotalSalesCount4.OutputFormat = resources.GetString("Ttl_TotalSalesCount4.OutputFormat");
            this.Ttl_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount4.Text = "12,345,678";
            this.Ttl_TotalSalesCount4.Top = 0.219F;
            this.Ttl_TotalSalesCount4.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount5
            // 
            this.Ttl_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.Ttl_TotalSalesCount5.Height = 0.156F;
            this.Ttl_TotalSalesCount5.Left = 5.5625F;
            this.Ttl_TotalSalesCount5.MultiLine = false;
            this.Ttl_TotalSalesCount5.Name = "Ttl_TotalSalesCount5";
            this.Ttl_TotalSalesCount5.OutputFormat = resources.GetString("Ttl_TotalSalesCount5.OutputFormat");
            this.Ttl_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount5.Text = "12,345,678";
            this.Ttl_TotalSalesCount5.Top = 0.219F;
            this.Ttl_TotalSalesCount5.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount6
            // 
            this.Ttl_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.Ttl_TotalSalesCount6.Height = 0.156F;
            this.Ttl_TotalSalesCount6.Left = 6.125F;
            this.Ttl_TotalSalesCount6.MultiLine = false;
            this.Ttl_TotalSalesCount6.Name = "Ttl_TotalSalesCount6";
            this.Ttl_TotalSalesCount6.OutputFormat = resources.GetString("Ttl_TotalSalesCount6.OutputFormat");
            this.Ttl_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount6.Text = "12,345,678";
            this.Ttl_TotalSalesCount6.Top = 0.219F;
            this.Ttl_TotalSalesCount6.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount7
            // 
            this.Ttl_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.Ttl_TotalSalesCount7.Height = 0.156F;
            this.Ttl_TotalSalesCount7.Left = 6.6875F;
            this.Ttl_TotalSalesCount7.MultiLine = false;
            this.Ttl_TotalSalesCount7.Name = "Ttl_TotalSalesCount7";
            this.Ttl_TotalSalesCount7.OutputFormat = resources.GetString("Ttl_TotalSalesCount7.OutputFormat");
            this.Ttl_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount7.Text = "12,345,678";
            this.Ttl_TotalSalesCount7.Top = 0.219F;
            this.Ttl_TotalSalesCount7.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount8
            // 
            this.Ttl_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.Ttl_TotalSalesCount8.Height = 0.156F;
            this.Ttl_TotalSalesCount8.Left = 7.25F;
            this.Ttl_TotalSalesCount8.MultiLine = false;
            this.Ttl_TotalSalesCount8.Name = "Ttl_TotalSalesCount8";
            this.Ttl_TotalSalesCount8.OutputFormat = resources.GetString("Ttl_TotalSalesCount8.OutputFormat");
            this.Ttl_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount8.Text = "12,345,678";
            this.Ttl_TotalSalesCount8.Top = 0.219F;
            this.Ttl_TotalSalesCount8.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount9
            // 
            this.Ttl_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.Ttl_TotalSalesCount9.Height = 0.156F;
            this.Ttl_TotalSalesCount9.Left = 7.8125F;
            this.Ttl_TotalSalesCount9.MultiLine = false;
            this.Ttl_TotalSalesCount9.Name = "Ttl_TotalSalesCount9";
            this.Ttl_TotalSalesCount9.OutputFormat = resources.GetString("Ttl_TotalSalesCount9.OutputFormat");
            this.Ttl_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount9.Text = "12,345,678";
            this.Ttl_TotalSalesCount9.Top = 0.219F;
            this.Ttl_TotalSalesCount9.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount10
            // 
            this.Ttl_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.Ttl_TotalSalesCount10.Height = 0.156F;
            this.Ttl_TotalSalesCount10.Left = 8.375F;
            this.Ttl_TotalSalesCount10.MultiLine = false;
            this.Ttl_TotalSalesCount10.Name = "Ttl_TotalSalesCount10";
            this.Ttl_TotalSalesCount10.OutputFormat = resources.GetString("Ttl_TotalSalesCount10.OutputFormat");
            this.Ttl_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount10.Text = "12,345,678";
            this.Ttl_TotalSalesCount10.Top = 0.219F;
            this.Ttl_TotalSalesCount10.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount11
            // 
            this.Ttl_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.Ttl_TotalSalesCount11.Height = 0.156F;
            this.Ttl_TotalSalesCount11.Left = 8.9375F;
            this.Ttl_TotalSalesCount11.MultiLine = false;
            this.Ttl_TotalSalesCount11.Name = "Ttl_TotalSalesCount11";
            this.Ttl_TotalSalesCount11.OutputFormat = resources.GetString("Ttl_TotalSalesCount11.OutputFormat");
            this.Ttl_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount11.Text = "12,345,678";
            this.Ttl_TotalSalesCount11.Top = 0.219F;
            this.Ttl_TotalSalesCount11.Width = 0.55F;
            // 
            // Ttl_TotalSalesCount12
            // 
            this.Ttl_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.Ttl_TotalSalesCount12.Height = 0.156F;
            this.Ttl_TotalSalesCount12.Left = 9.5F;
            this.Ttl_TotalSalesCount12.MultiLine = false;
            this.Ttl_TotalSalesCount12.Name = "Ttl_TotalSalesCount12";
            this.Ttl_TotalSalesCount12.OutputFormat = resources.GetString("Ttl_TotalSalesCount12.OutputFormat");
            this.Ttl_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalSalesCount12.Text = "12,345,678";
            this.Ttl_TotalSalesCount12.Top = 0.219F;
            this.Ttl_TotalSalesCount12.Width = 0.55F;
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
            this.Ttl_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.Ttl_TtlTotalSalesCount.Height = 0.156F;
            this.Ttl_TtlTotalSalesCount.Left = 10.0625F;
            this.Ttl_TtlTotalSalesCount.MultiLine = false;
            this.Ttl_TtlTotalSalesCount.Name = "Ttl_TtlTotalSalesCount";
            this.Ttl_TtlTotalSalesCount.OutputFormat = resources.GetString("Ttl_TtlTotalSalesCount.OutputFormat");
            this.Ttl_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TtlTotalSalesCount.Text = "1,234,567,890";
            this.Ttl_TtlTotalSalesCount.Top = 0.219F;
            this.Ttl_TtlTotalSalesCount.Width = 0.688F;
            // 
            // Ttl_TtlSalesMoney
            // 
            this.Ttl_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.Ttl_TtlSalesMoney.Height = 0.156F;
            this.Ttl_TtlSalesMoney.Left = 10.0625F;
            this.Ttl_TtlSalesMoney.MultiLine = false;
            this.Ttl_TtlSalesMoney.Name = "Ttl_TtlSalesMoney";
            this.Ttl_TtlSalesMoney.OutputFormat = resources.GetString("Ttl_TtlSalesMoney.OutputFormat");
            this.Ttl_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TtlSalesMoney.Text = "1,234,567,890";
            this.Ttl_TtlSalesMoney.Top = 0.0625F;
            this.Ttl_TtlSalesMoney.Width = 0.688F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_AddUpSecCode,
            this.SecHd_SectionGuideNm,
            this.SecHd_SectionTitle,
            this.line3});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0.2708333F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.SecHd_AddUpSecCode.Left = 0.5F;
            this.SecHd_AddUpSecCode.MultiLine = false;
            this.SecHd_AddUpSecCode.Name = "SecHd_AddUpSecCode";
            this.SecHd_AddUpSecCode.OutputFormat = resources.GetString("SecHd_AddUpSecCode.OutputFormat");
            this.SecHd_AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SecHd_AddUpSecCode.Text = "12";
            this.SecHd_AddUpSecCode.Top = 0.03125F;
            this.SecHd_AddUpSecCode.Width = 0.2F;
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
            this.SecHd_SectionGuideNm.Left = 0.6875F;
            this.SecHd_SectionGuideNm.MultiLine = false;
            this.SecHd_SectionGuideNm.Name = "SecHd_SectionGuideNm";
            this.SecHd_SectionGuideNm.OutputFormat = resources.GetString("SecHd_SectionGuideNm.OutputFormat");
            this.SecHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SecHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SecHd_SectionGuideNm.Top = 0.03125F;
            this.SecHd_SectionGuideNm.Width = 1.1875F;
            // 
            // SecHd_SectionTitle
            // 
            this.SecHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Height = 0.156F;
            this.SecHd_SectionTitle.HyperLink = "";
            this.SecHd_SectionTitle.Left = 0.1875F;
            this.SecHd_SectionTitle.MultiLine = false;
            this.SecHd_SectionTitle.Name = "SecHd_SectionTitle";
            this.SecHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SecHd_SectionTitle.Text = "拠点";
            this.SecHd_SectionTitle.Top = 0.03125F;
            this.SecHd_SectionTitle.Width = 0.313F;
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
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Sec_Title,
            this.Line2,
            this.SecFt_SalesMoney1,
            this.SecFt_SalesMoney2,
            this.SecFt_SalesMoney3,
            this.SecFt_SalesMoney5,
            this.SecFt_SalesMoney4,
            this.SecFt_SalesMoney6,
            this.SecFt_SalesMoney7,
            this.SecFt_SalesMoney8,
            this.SecFt_SalesMoney9,
            this.SecFt_SalesMoney10,
            this.SecFt_SalesMoney11,
            this.SecFt_SalesMoney12,
            this.SecFt_TotalSalesCount1,
            this.SecFt_TotalSalesCount2,
            this.SecFt_TotalSalesCount3,
            this.SecFt_TotalSalesCount5,
            this.SecFt_TotalSalesCount4,
            this.SecFt_TotalSalesCount6,
            this.SecFt_TotalSalesCount7,
            this.SecFt_TotalSalesCount8,
            this.SecFt_TotalSalesCount9,
            this.SecFt_TotalSalesCount10,
            this.SecFt_TotalSalesCount11,
            this.SecFt_TotalSalesCount12,
            this.SecFt_TtlTotalSalesCount,
            this.SecFt_TtlSalesMoney});
            this.SectionFooter.Height = 0.406F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
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
            this.Sec_Title.Left = 0.4375F;
            this.Sec_Title.MultiLine = false;
            this.Sec_Title.Name = "Sec_Title";
            this.Sec_Title.OutputFormat = resources.GetString("Sec_Title.OutputFormat");
            this.Sec_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Sec_Title.Text = "拠点計";
            this.Sec_Title.Top = 0.0625F;
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
            // SecFt_SalesMoney1
            // 
            this.SecFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney1.DataField = "SalesMoney1";
            this.SecFt_SalesMoney1.Height = 0.156F;
            this.SecFt_SalesMoney1.Left = 3.3125F;
            this.SecFt_SalesMoney1.MultiLine = false;
            this.SecFt_SalesMoney1.Name = "SecFt_SalesMoney1";
            this.SecFt_SalesMoney1.OutputFormat = resources.GetString("SecFt_SalesMoney1.OutputFormat");
            this.SecFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney1.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney1.Text = "12,345,678";
            this.SecFt_SalesMoney1.Top = 0.0625F;
            this.SecFt_SalesMoney1.Width = 0.55F;
            // 
            // SecFt_SalesMoney2
            // 
            this.SecFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney2.DataField = "SalesMoney2";
            this.SecFt_SalesMoney2.Height = 0.156F;
            this.SecFt_SalesMoney2.Left = 3.875F;
            this.SecFt_SalesMoney2.MultiLine = false;
            this.SecFt_SalesMoney2.Name = "SecFt_SalesMoney2";
            this.SecFt_SalesMoney2.OutputFormat = resources.GetString("SecFt_SalesMoney2.OutputFormat");
            this.SecFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney2.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney2.Text = "12,345,678";
            this.SecFt_SalesMoney2.Top = 0.0625F;
            this.SecFt_SalesMoney2.Width = 0.55F;
            // 
            // SecFt_SalesMoney3
            // 
            this.SecFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney3.DataField = "SalesMoney3";
            this.SecFt_SalesMoney3.Height = 0.156F;
            this.SecFt_SalesMoney3.Left = 4.4375F;
            this.SecFt_SalesMoney3.MultiLine = false;
            this.SecFt_SalesMoney3.Name = "SecFt_SalesMoney3";
            this.SecFt_SalesMoney3.OutputFormat = resources.GetString("SecFt_SalesMoney3.OutputFormat");
            this.SecFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney3.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney3.Text = "12,345,678";
            this.SecFt_SalesMoney3.Top = 0.0625F;
            this.SecFt_SalesMoney3.Width = 0.55F;
            // 
            // SecFt_SalesMoney5
            // 
            this.SecFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney5.DataField = "SalesMoney5";
            this.SecFt_SalesMoney5.Height = 0.156F;
            this.SecFt_SalesMoney5.Left = 5.5625F;
            this.SecFt_SalesMoney5.MultiLine = false;
            this.SecFt_SalesMoney5.Name = "SecFt_SalesMoney5";
            this.SecFt_SalesMoney5.OutputFormat = resources.GetString("SecFt_SalesMoney5.OutputFormat");
            this.SecFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney5.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney5.Text = "12,345,678";
            this.SecFt_SalesMoney5.Top = 0.0625F;
            this.SecFt_SalesMoney5.Width = 0.55F;
            // 
            // SecFt_SalesMoney4
            // 
            this.SecFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney4.DataField = "SalesMoney4";
            this.SecFt_SalesMoney4.Height = 0.156F;
            this.SecFt_SalesMoney4.Left = 5F;
            this.SecFt_SalesMoney4.MultiLine = false;
            this.SecFt_SalesMoney4.Name = "SecFt_SalesMoney4";
            this.SecFt_SalesMoney4.OutputFormat = resources.GetString("SecFt_SalesMoney4.OutputFormat");
            this.SecFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney4.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney4.Text = "12,345,678";
            this.SecFt_SalesMoney4.Top = 0.0625F;
            this.SecFt_SalesMoney4.Width = 0.55F;
            // 
            // SecFt_SalesMoney6
            // 
            this.SecFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney6.DataField = "SalesMoney6";
            this.SecFt_SalesMoney6.Height = 0.156F;
            this.SecFt_SalesMoney6.Left = 6.125F;
            this.SecFt_SalesMoney6.MultiLine = false;
            this.SecFt_SalesMoney6.Name = "SecFt_SalesMoney6";
            this.SecFt_SalesMoney6.OutputFormat = resources.GetString("SecFt_SalesMoney6.OutputFormat");
            this.SecFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney6.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney6.Text = "12,345,678";
            this.SecFt_SalesMoney6.Top = 0.0625F;
            this.SecFt_SalesMoney6.Width = 0.55F;
            // 
            // SecFt_SalesMoney7
            // 
            this.SecFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney7.DataField = "SalesMoney7";
            this.SecFt_SalesMoney7.Height = 0.156F;
            this.SecFt_SalesMoney7.Left = 6.6875F;
            this.SecFt_SalesMoney7.MultiLine = false;
            this.SecFt_SalesMoney7.Name = "SecFt_SalesMoney7";
            this.SecFt_SalesMoney7.OutputFormat = resources.GetString("SecFt_SalesMoney7.OutputFormat");
            this.SecFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney7.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney7.Text = "12,345,678";
            this.SecFt_SalesMoney7.Top = 0.0625F;
            this.SecFt_SalesMoney7.Width = 0.55F;
            // 
            // SecFt_SalesMoney8
            // 
            this.SecFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney8.DataField = "SalesMoney8";
            this.SecFt_SalesMoney8.Height = 0.156F;
            this.SecFt_SalesMoney8.Left = 7.25F;
            this.SecFt_SalesMoney8.MultiLine = false;
            this.SecFt_SalesMoney8.Name = "SecFt_SalesMoney8";
            this.SecFt_SalesMoney8.OutputFormat = resources.GetString("SecFt_SalesMoney8.OutputFormat");
            this.SecFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney8.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney8.Text = "12,345,678";
            this.SecFt_SalesMoney8.Top = 0.0625F;
            this.SecFt_SalesMoney8.Width = 0.55F;
            // 
            // SecFt_SalesMoney9
            // 
            this.SecFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney9.DataField = "SalesMoney9";
            this.SecFt_SalesMoney9.Height = 0.156F;
            this.SecFt_SalesMoney9.Left = 7.8125F;
            this.SecFt_SalesMoney9.MultiLine = false;
            this.SecFt_SalesMoney9.Name = "SecFt_SalesMoney9";
            this.SecFt_SalesMoney9.OutputFormat = resources.GetString("SecFt_SalesMoney9.OutputFormat");
            this.SecFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney9.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney9.Text = "12,345,678";
            this.SecFt_SalesMoney9.Top = 0.0625F;
            this.SecFt_SalesMoney9.Width = 0.55F;
            // 
            // SecFt_SalesMoney10
            // 
            this.SecFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney10.DataField = "SalesMoney10";
            this.SecFt_SalesMoney10.Height = 0.156F;
            this.SecFt_SalesMoney10.Left = 8.375F;
            this.SecFt_SalesMoney10.MultiLine = false;
            this.SecFt_SalesMoney10.Name = "SecFt_SalesMoney10";
            this.SecFt_SalesMoney10.OutputFormat = resources.GetString("SecFt_SalesMoney10.OutputFormat");
            this.SecFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney10.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney10.Text = "12,345,678";
            this.SecFt_SalesMoney10.Top = 0.0625F;
            this.SecFt_SalesMoney10.Width = 0.55F;
            // 
            // SecFt_SalesMoney11
            // 
            this.SecFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney11.DataField = "SalesMoney11";
            this.SecFt_SalesMoney11.Height = 0.156F;
            this.SecFt_SalesMoney11.Left = 8.9375F;
            this.SecFt_SalesMoney11.MultiLine = false;
            this.SecFt_SalesMoney11.Name = "SecFt_SalesMoney11";
            this.SecFt_SalesMoney11.OutputFormat = resources.GetString("SecFt_SalesMoney11.OutputFormat");
            this.SecFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney11.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney11.Text = "12,345,678";
            this.SecFt_SalesMoney11.Top = 0.0625F;
            this.SecFt_SalesMoney11.Width = 0.55F;
            // 
            // SecFt_SalesMoney12
            // 
            this.SecFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoney12.DataField = "SalesMoney12";
            this.SecFt_SalesMoney12.Height = 0.156F;
            this.SecFt_SalesMoney12.Left = 9.5F;
            this.SecFt_SalesMoney12.MultiLine = false;
            this.SecFt_SalesMoney12.Name = "SecFt_SalesMoney12";
            this.SecFt_SalesMoney12.OutputFormat = resources.GetString("SecFt_SalesMoney12.OutputFormat");
            this.SecFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoney12.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoney12.Text = "12,345,678";
            this.SecFt_SalesMoney12.Top = 0.0625F;
            this.SecFt_SalesMoney12.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount1
            // 
            this.SecFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.SecFt_TotalSalesCount1.Height = 0.156F;
            this.SecFt_TotalSalesCount1.Left = 3.3125F;
            this.SecFt_TotalSalesCount1.MultiLine = false;
            this.SecFt_TotalSalesCount1.Name = "SecFt_TotalSalesCount1";
            this.SecFt_TotalSalesCount1.OutputFormat = resources.GetString("SecFt_TotalSalesCount1.OutputFormat");
            this.SecFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount1.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount1.Text = "12,345,678";
            this.SecFt_TotalSalesCount1.Top = 0.219F;
            this.SecFt_TotalSalesCount1.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount2
            // 
            this.SecFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.SecFt_TotalSalesCount2.Height = 0.156F;
            this.SecFt_TotalSalesCount2.Left = 3.875F;
            this.SecFt_TotalSalesCount2.MultiLine = false;
            this.SecFt_TotalSalesCount2.Name = "SecFt_TotalSalesCount2";
            this.SecFt_TotalSalesCount2.OutputFormat = resources.GetString("SecFt_TotalSalesCount2.OutputFormat");
            this.SecFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount2.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount2.Text = "12,345,678";
            this.SecFt_TotalSalesCount2.Top = 0.219F;
            this.SecFt_TotalSalesCount2.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount3
            // 
            this.SecFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.SecFt_TotalSalesCount3.Height = 0.156F;
            this.SecFt_TotalSalesCount3.Left = 4.4375F;
            this.SecFt_TotalSalesCount3.MultiLine = false;
            this.SecFt_TotalSalesCount3.Name = "SecFt_TotalSalesCount3";
            this.SecFt_TotalSalesCount3.OutputFormat = resources.GetString("SecFt_TotalSalesCount3.OutputFormat");
            this.SecFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount3.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount3.Text = "12,345,678";
            this.SecFt_TotalSalesCount3.Top = 0.219F;
            this.SecFt_TotalSalesCount3.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount5
            // 
            this.SecFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.SecFt_TotalSalesCount5.Height = 0.156F;
            this.SecFt_TotalSalesCount5.Left = 5.5625F;
            this.SecFt_TotalSalesCount5.MultiLine = false;
            this.SecFt_TotalSalesCount5.Name = "SecFt_TotalSalesCount5";
            this.SecFt_TotalSalesCount5.OutputFormat = resources.GetString("SecFt_TotalSalesCount5.OutputFormat");
            this.SecFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount5.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount5.Text = "12,345,678";
            this.SecFt_TotalSalesCount5.Top = 0.219F;
            this.SecFt_TotalSalesCount5.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount4
            // 
            this.SecFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.SecFt_TotalSalesCount4.Height = 0.156F;
            this.SecFt_TotalSalesCount4.Left = 5F;
            this.SecFt_TotalSalesCount4.MultiLine = false;
            this.SecFt_TotalSalesCount4.Name = "SecFt_TotalSalesCount4";
            this.SecFt_TotalSalesCount4.OutputFormat = resources.GetString("SecFt_TotalSalesCount4.OutputFormat");
            this.SecFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount4.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount4.Text = "12,345,678";
            this.SecFt_TotalSalesCount4.Top = 0.219F;
            this.SecFt_TotalSalesCount4.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount6
            // 
            this.SecFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.SecFt_TotalSalesCount6.Height = 0.156F;
            this.SecFt_TotalSalesCount6.Left = 6.125F;
            this.SecFt_TotalSalesCount6.MultiLine = false;
            this.SecFt_TotalSalesCount6.Name = "SecFt_TotalSalesCount6";
            this.SecFt_TotalSalesCount6.OutputFormat = resources.GetString("SecFt_TotalSalesCount6.OutputFormat");
            this.SecFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount6.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount6.Text = "12,345,678";
            this.SecFt_TotalSalesCount6.Top = 0.219F;
            this.SecFt_TotalSalesCount6.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount7
            // 
            this.SecFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.SecFt_TotalSalesCount7.Height = 0.156F;
            this.SecFt_TotalSalesCount7.Left = 6.6875F;
            this.SecFt_TotalSalesCount7.MultiLine = false;
            this.SecFt_TotalSalesCount7.Name = "SecFt_TotalSalesCount7";
            this.SecFt_TotalSalesCount7.OutputFormat = resources.GetString("SecFt_TotalSalesCount7.OutputFormat");
            this.SecFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount7.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount7.Text = "12,345,678";
            this.SecFt_TotalSalesCount7.Top = 0.219F;
            this.SecFt_TotalSalesCount7.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount8
            // 
            this.SecFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.SecFt_TotalSalesCount8.Height = 0.156F;
            this.SecFt_TotalSalesCount8.Left = 7.25F;
            this.SecFt_TotalSalesCount8.MultiLine = false;
            this.SecFt_TotalSalesCount8.Name = "SecFt_TotalSalesCount8";
            this.SecFt_TotalSalesCount8.OutputFormat = resources.GetString("SecFt_TotalSalesCount8.OutputFormat");
            this.SecFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount8.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount8.Text = "12,345,678";
            this.SecFt_TotalSalesCount8.Top = 0.219F;
            this.SecFt_TotalSalesCount8.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount9
            // 
            this.SecFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.SecFt_TotalSalesCount9.Height = 0.156F;
            this.SecFt_TotalSalesCount9.Left = 7.8125F;
            this.SecFt_TotalSalesCount9.MultiLine = false;
            this.SecFt_TotalSalesCount9.Name = "SecFt_TotalSalesCount9";
            this.SecFt_TotalSalesCount9.OutputFormat = resources.GetString("SecFt_TotalSalesCount9.OutputFormat");
            this.SecFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount9.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount9.Text = "12,345,678";
            this.SecFt_TotalSalesCount9.Top = 0.219F;
            this.SecFt_TotalSalesCount9.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount10
            // 
            this.SecFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.SecFt_TotalSalesCount10.Height = 0.156F;
            this.SecFt_TotalSalesCount10.Left = 8.375F;
            this.SecFt_TotalSalesCount10.MultiLine = false;
            this.SecFt_TotalSalesCount10.Name = "SecFt_TotalSalesCount10";
            this.SecFt_TotalSalesCount10.OutputFormat = resources.GetString("SecFt_TotalSalesCount10.OutputFormat");
            this.SecFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount10.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount10.Text = "12,345,678";
            this.SecFt_TotalSalesCount10.Top = 0.219F;
            this.SecFt_TotalSalesCount10.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount11
            // 
            this.SecFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.SecFt_TotalSalesCount11.Height = 0.156F;
            this.SecFt_TotalSalesCount11.Left = 8.9375F;
            this.SecFt_TotalSalesCount11.MultiLine = false;
            this.SecFt_TotalSalesCount11.Name = "SecFt_TotalSalesCount11";
            this.SecFt_TotalSalesCount11.OutputFormat = resources.GetString("SecFt_TotalSalesCount11.OutputFormat");
            this.SecFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount11.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount11.Text = "12,345,678";
            this.SecFt_TotalSalesCount11.Top = 0.219F;
            this.SecFt_TotalSalesCount11.Width = 0.55F;
            // 
            // SecFt_TotalSalesCount12
            // 
            this.SecFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.SecFt_TotalSalesCount12.Height = 0.156F;
            this.SecFt_TotalSalesCount12.Left = 9.5F;
            this.SecFt_TotalSalesCount12.MultiLine = false;
            this.SecFt_TotalSalesCount12.Name = "SecFt_TotalSalesCount12";
            this.SecFt_TotalSalesCount12.OutputFormat = resources.GetString("SecFt_TotalSalesCount12.OutputFormat");
            this.SecFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TotalSalesCount12.SummaryGroup = "SectionHeader";
            this.SecFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TotalSalesCount12.Text = "12,345,678";
            this.SecFt_TotalSalesCount12.Top = 0.219F;
            this.SecFt_TotalSalesCount12.Width = 0.55F;
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
            this.SecFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.SecFt_TtlTotalSalesCount.Height = 0.156F;
            this.SecFt_TtlTotalSalesCount.Left = 10.0625F;
            this.SecFt_TtlTotalSalesCount.MultiLine = false;
            this.SecFt_TtlTotalSalesCount.Name = "SecFt_TtlTotalSalesCount";
            this.SecFt_TtlTotalSalesCount.OutputFormat = resources.GetString("SecFt_TtlTotalSalesCount.OutputFormat");
            this.SecFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TtlTotalSalesCount.SummaryGroup = "SectionHeader";
            this.SecFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.SecFt_TtlTotalSalesCount.Top = 0.219F;
            this.SecFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // SecFt_TtlSalesMoney
            // 
            this.SecFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.SecFt_TtlSalesMoney.Height = 0.156F;
            this.SecFt_TtlSalesMoney.Left = 10.0625F;
            this.SecFt_TtlSalesMoney.MultiLine = false;
            this.SecFt_TtlSalesMoney.Name = "SecFt_TtlSalesMoney";
            this.SecFt_TtlSalesMoney.OutputFormat = resources.GetString("SecFt_TtlSalesMoney.OutputFormat");
            this.SecFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_TtlSalesMoney.SummaryGroup = "SectionHeader";
            this.SecFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_TtlSalesMoney.Text = "1,234,567,890";
            this.SecFt_TtlSalesMoney.Top = 0.0625F;
            this.SecFt_TtlSalesMoney.Width = 0.688F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CusHd_AddUpSecCode,
            this.CusHd_SectionGuideNm,
            this.CusHd_SectionTitle,
            this.CusHd_CustomerCode,
            this.CusHd_CustomerSnm,
            this.CusHd_CustomerTitle,
            this.line4});
            this.CustomerHeader.DataField = "CustomerCode";
            this.CustomerHeader.Height = 0.25F;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.BeforePrint += new System.EventHandler(this.CustomerHeader_BeforePrint);
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
            this.CusHd_AddUpSecCode.Left = 0.5F;
            this.CusHd_AddUpSecCode.MultiLine = false;
            this.CusHd_AddUpSecCode.Name = "CusHd_AddUpSecCode";
            this.CusHd_AddUpSecCode.OutputFormat = resources.GetString("CusHd_AddUpSecCode.OutputFormat");
            this.CusHd_AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CusHd_AddUpSecCode.Text = "12";
            this.CusHd_AddUpSecCode.Top = 0.03125F;
            this.CusHd_AddUpSecCode.Width = 0.2F;
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
            this.CusHd_SectionGuideNm.Left = 0.6875F;
            this.CusHd_SectionGuideNm.MultiLine = false;
            this.CusHd_SectionGuideNm.Name = "CusHd_SectionGuideNm";
            this.CusHd_SectionGuideNm.OutputFormat = resources.GetString("CusHd_SectionGuideNm.OutputFormat");
            this.CusHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CusHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.CusHd_SectionGuideNm.Top = 0.03125F;
            this.CusHd_SectionGuideNm.Width = 1.1875F;
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
            this.CusHd_SectionTitle.HyperLink = "";
            this.CusHd_SectionTitle.Left = 0.1875F;
            this.CusHd_SectionTitle.MultiLine = false;
            this.CusHd_SectionTitle.Name = "CusHd_SectionTitle";
            this.CusHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_SectionTitle.Text = "拠点";
            this.CusHd_SectionTitle.Top = 0.03125F;
            this.CusHd_SectionTitle.Width = 0.313F;
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
            this.CusHd_CustomerCode.Left = 2.4375F;
            this.CusHd_CustomerCode.MultiLine = false;
            this.CusHd_CustomerCode.Name = "CusHd_CustomerCode";
            this.CusHd_CustomerCode.OutputFormat = resources.GetString("CusHd_CustomerCode.OutputFormat");
            this.CusHd_CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CusHd_CustomerCode.Text = "12345678";
            this.CusHd_CustomerCode.Top = 0.03125F;
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
            this.CusHd_CustomerSnm.Left = 2.9375F;
            this.CusHd_CustomerSnm.MultiLine = false;
            this.CusHd_CustomerSnm.Name = "CusHd_CustomerSnm";
            this.CusHd_CustomerSnm.OutputFormat = resources.GetString("CusHd_CustomerSnm.OutputFormat");
            this.CusHd_CustomerSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CusHd_CustomerSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CusHd_CustomerSnm.Top = 0.03125F;
            this.CusHd_CustomerSnm.Width = 2.4F;
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
            this.CusHd_CustomerTitle.HyperLink = "";
            this.CusHd_CustomerTitle.Left = 2.0625F;
            this.CusHd_CustomerTitle.MultiLine = false;
            this.CusHd_CustomerTitle.Name = "CusHd_CustomerTitle";
            this.CusHd_CustomerTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_CustomerTitle.Text = "得意先";
            this.CusHd_CustomerTitle.Top = 0.03125F;
            this.CusHd_CustomerTitle.Width = 0.4F;
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
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.Cus_Title,
            this.CusFt_SalesMoney1,
            this.CusFt_SalesMoney2,
            this.CusFt_SalesMoney3,
            this.CusFt_SalesMoney5,
            this.CusFt_SalesMoney6,
            this.CusFt_SalesMoney4,
            this.CusFt_SalesMoney7,
            this.CusFt_SalesMoney8,
            this.CusFt_SalesMoney9,
            this.CusFt_SalesMoney11,
            this.CusFt_SalesMoney12,
            this.CusFt_SalesMoney10,
            this.CusFt_TotalSalesCount1,
            this.CusFt_TotalSalesCount2,
            this.CusFt_TotalSalesCount3,
            this.CusFt_TotalSalesCount5,
            this.CusFt_TotalSalesCount6,
            this.CusFt_TotalSalesCount4,
            this.CusFt_TotalSalesCount7,
            this.CusFt_TotalSalesCount8,
            this.CusFt_TotalSalesCount9,
            this.CusFt_TotalSalesCount11,
            this.CusFt_TotalSalesCount12,
            this.CusFt_TotalSalesCount10,
            this.CusFt_TtlTotalSalesCount,
            this.CusFt_TtlSalesMoney});
            this.CustomerFooter.Height = 0.4F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
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
            this.Cus_Title.Left = 0.4375F;
            this.Cus_Title.MultiLine = false;
            this.Cus_Title.Name = "Cus_Title";
            this.Cus_Title.OutputFormat = resources.GetString("Cus_Title.OutputFormat");
            this.Cus_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Cus_Title.Text = "得意先計";
            this.Cus_Title.Top = 0.0625F;
            this.Cus_Title.Width = 0.65625F;
            // 
            // CusFt_SalesMoney1
            // 
            this.CusFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney1.DataField = "SalesMoney1";
            this.CusFt_SalesMoney1.Height = 0.156F;
            this.CusFt_SalesMoney1.Left = 3.3125F;
            this.CusFt_SalesMoney1.MultiLine = false;
            this.CusFt_SalesMoney1.Name = "CusFt_SalesMoney1";
            this.CusFt_SalesMoney1.OutputFormat = resources.GetString("CusFt_SalesMoney1.OutputFormat");
            this.CusFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney1.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney1.Text = "12,345,678";
            this.CusFt_SalesMoney1.Top = 0.0625F;
            this.CusFt_SalesMoney1.Width = 0.55F;
            // 
            // CusFt_SalesMoney2
            // 
            this.CusFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney2.DataField = "SalesMoney2";
            this.CusFt_SalesMoney2.Height = 0.156F;
            this.CusFt_SalesMoney2.Left = 3.875F;
            this.CusFt_SalesMoney2.MultiLine = false;
            this.CusFt_SalesMoney2.Name = "CusFt_SalesMoney2";
            this.CusFt_SalesMoney2.OutputFormat = resources.GetString("CusFt_SalesMoney2.OutputFormat");
            this.CusFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney2.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney2.Text = "12,345,678";
            this.CusFt_SalesMoney2.Top = 0.0625F;
            this.CusFt_SalesMoney2.Width = 0.55F;
            // 
            // CusFt_SalesMoney3
            // 
            this.CusFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney3.DataField = "SalesMoney3";
            this.CusFt_SalesMoney3.Height = 0.156F;
            this.CusFt_SalesMoney3.Left = 4.4375F;
            this.CusFt_SalesMoney3.MultiLine = false;
            this.CusFt_SalesMoney3.Name = "CusFt_SalesMoney3";
            this.CusFt_SalesMoney3.OutputFormat = resources.GetString("CusFt_SalesMoney3.OutputFormat");
            this.CusFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney3.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney3.Text = "12,345,678";
            this.CusFt_SalesMoney3.Top = 0.0625F;
            this.CusFt_SalesMoney3.Width = 0.55F;
            // 
            // CusFt_SalesMoney5
            // 
            this.CusFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney5.DataField = "SalesMoney5";
            this.CusFt_SalesMoney5.Height = 0.156F;
            this.CusFt_SalesMoney5.Left = 5.5625F;
            this.CusFt_SalesMoney5.MultiLine = false;
            this.CusFt_SalesMoney5.Name = "CusFt_SalesMoney5";
            this.CusFt_SalesMoney5.OutputFormat = resources.GetString("CusFt_SalesMoney5.OutputFormat");
            this.CusFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney5.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney5.Text = "12,345,678";
            this.CusFt_SalesMoney5.Top = 0.0625F;
            this.CusFt_SalesMoney5.Width = 0.55F;
            // 
            // CusFt_SalesMoney6
            // 
            this.CusFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney6.DataField = "SalesMoney6";
            this.CusFt_SalesMoney6.Height = 0.156F;
            this.CusFt_SalesMoney6.Left = 6.125F;
            this.CusFt_SalesMoney6.MultiLine = false;
            this.CusFt_SalesMoney6.Name = "CusFt_SalesMoney6";
            this.CusFt_SalesMoney6.OutputFormat = resources.GetString("CusFt_SalesMoney6.OutputFormat");
            this.CusFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney6.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney6.Text = "12,345,678";
            this.CusFt_SalesMoney6.Top = 0.0625F;
            this.CusFt_SalesMoney6.Width = 0.55F;
            // 
            // CusFt_SalesMoney4
            // 
            this.CusFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney4.DataField = "SalesMoney4";
            this.CusFt_SalesMoney4.Height = 0.156F;
            this.CusFt_SalesMoney4.Left = 5F;
            this.CusFt_SalesMoney4.MultiLine = false;
            this.CusFt_SalesMoney4.Name = "CusFt_SalesMoney4";
            this.CusFt_SalesMoney4.OutputFormat = resources.GetString("CusFt_SalesMoney4.OutputFormat");
            this.CusFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney4.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney4.Text = "12,345,678";
            this.CusFt_SalesMoney4.Top = 0.0625F;
            this.CusFt_SalesMoney4.Width = 0.55F;
            // 
            // CusFt_SalesMoney7
            // 
            this.CusFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney7.DataField = "SalesMoney7";
            this.CusFt_SalesMoney7.Height = 0.156F;
            this.CusFt_SalesMoney7.Left = 6.6875F;
            this.CusFt_SalesMoney7.MultiLine = false;
            this.CusFt_SalesMoney7.Name = "CusFt_SalesMoney7";
            this.CusFt_SalesMoney7.OutputFormat = resources.GetString("CusFt_SalesMoney7.OutputFormat");
            this.CusFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney7.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney7.Text = "12,345,678";
            this.CusFt_SalesMoney7.Top = 0.0625F;
            this.CusFt_SalesMoney7.Width = 0.55F;
            // 
            // CusFt_SalesMoney8
            // 
            this.CusFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney8.DataField = "SalesMoney8";
            this.CusFt_SalesMoney8.Height = 0.156F;
            this.CusFt_SalesMoney8.Left = 7.25F;
            this.CusFt_SalesMoney8.MultiLine = false;
            this.CusFt_SalesMoney8.Name = "CusFt_SalesMoney8";
            this.CusFt_SalesMoney8.OutputFormat = resources.GetString("CusFt_SalesMoney8.OutputFormat");
            this.CusFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney8.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney8.Text = "12,345,678";
            this.CusFt_SalesMoney8.Top = 0.0625F;
            this.CusFt_SalesMoney8.Width = 0.55F;
            // 
            // CusFt_SalesMoney9
            // 
            this.CusFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney9.DataField = "SalesMoney9";
            this.CusFt_SalesMoney9.Height = 0.156F;
            this.CusFt_SalesMoney9.Left = 7.8125F;
            this.CusFt_SalesMoney9.MultiLine = false;
            this.CusFt_SalesMoney9.Name = "CusFt_SalesMoney9";
            this.CusFt_SalesMoney9.OutputFormat = resources.GetString("CusFt_SalesMoney9.OutputFormat");
            this.CusFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney9.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney9.Text = "12,345,678";
            this.CusFt_SalesMoney9.Top = 0.0625F;
            this.CusFt_SalesMoney9.Width = 0.55F;
            // 
            // CusFt_SalesMoney11
            // 
            this.CusFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney11.DataField = "SalesMoney11";
            this.CusFt_SalesMoney11.Height = 0.156F;
            this.CusFt_SalesMoney11.Left = 8.9375F;
            this.CusFt_SalesMoney11.MultiLine = false;
            this.CusFt_SalesMoney11.Name = "CusFt_SalesMoney11";
            this.CusFt_SalesMoney11.OutputFormat = resources.GetString("CusFt_SalesMoney11.OutputFormat");
            this.CusFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney11.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney11.Text = "12,345,678";
            this.CusFt_SalesMoney11.Top = 0.0625F;
            this.CusFt_SalesMoney11.Width = 0.55F;
            // 
            // CusFt_SalesMoney12
            // 
            this.CusFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney12.DataField = "SalesMoney12";
            this.CusFt_SalesMoney12.Height = 0.156F;
            this.CusFt_SalesMoney12.Left = 9.5F;
            this.CusFt_SalesMoney12.MultiLine = false;
            this.CusFt_SalesMoney12.Name = "CusFt_SalesMoney12";
            this.CusFt_SalesMoney12.OutputFormat = resources.GetString("CusFt_SalesMoney12.OutputFormat");
            this.CusFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney12.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney12.Text = "12,345,678";
            this.CusFt_SalesMoney12.Top = 0.0625F;
            this.CusFt_SalesMoney12.Width = 0.55F;
            // 
            // CusFt_SalesMoney10
            // 
            this.CusFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_SalesMoney10.DataField = "SalesMoney10";
            this.CusFt_SalesMoney10.Height = 0.156F;
            this.CusFt_SalesMoney10.Left = 8.375F;
            this.CusFt_SalesMoney10.MultiLine = false;
            this.CusFt_SalesMoney10.Name = "CusFt_SalesMoney10";
            this.CusFt_SalesMoney10.OutputFormat = resources.GetString("CusFt_SalesMoney10.OutputFormat");
            this.CusFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_SalesMoney10.SummaryGroup = "CustomerHeader";
            this.CusFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_SalesMoney10.Text = "12,345,678";
            this.CusFt_SalesMoney10.Top = 0.0625F;
            this.CusFt_SalesMoney10.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount1
            // 
            this.CusFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.CusFt_TotalSalesCount1.Height = 0.156F;
            this.CusFt_TotalSalesCount1.Left = 3.3125F;
            this.CusFt_TotalSalesCount1.MultiLine = false;
            this.CusFt_TotalSalesCount1.Name = "CusFt_TotalSalesCount1";
            this.CusFt_TotalSalesCount1.OutputFormat = resources.GetString("CusFt_TotalSalesCount1.OutputFormat");
            this.CusFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount1.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount1.Text = "12,345,678";
            this.CusFt_TotalSalesCount1.Top = 0.219F;
            this.CusFt_TotalSalesCount1.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount2
            // 
            this.CusFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.CusFt_TotalSalesCount2.Height = 0.156F;
            this.CusFt_TotalSalesCount2.Left = 3.875F;
            this.CusFt_TotalSalesCount2.MultiLine = false;
            this.CusFt_TotalSalesCount2.Name = "CusFt_TotalSalesCount2";
            this.CusFt_TotalSalesCount2.OutputFormat = resources.GetString("CusFt_TotalSalesCount2.OutputFormat");
            this.CusFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount2.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount2.Text = "12,345,678";
            this.CusFt_TotalSalesCount2.Top = 0.219F;
            this.CusFt_TotalSalesCount2.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount3
            // 
            this.CusFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.CusFt_TotalSalesCount3.Height = 0.156F;
            this.CusFt_TotalSalesCount3.Left = 4.4375F;
            this.CusFt_TotalSalesCount3.MultiLine = false;
            this.CusFt_TotalSalesCount3.Name = "CusFt_TotalSalesCount3";
            this.CusFt_TotalSalesCount3.OutputFormat = resources.GetString("CusFt_TotalSalesCount3.OutputFormat");
            this.CusFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount3.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount3.Text = "12,345,678";
            this.CusFt_TotalSalesCount3.Top = 0.219F;
            this.CusFt_TotalSalesCount3.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount5
            // 
            this.CusFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.CusFt_TotalSalesCount5.Height = 0.156F;
            this.CusFt_TotalSalesCount5.Left = 5.5625F;
            this.CusFt_TotalSalesCount5.MultiLine = false;
            this.CusFt_TotalSalesCount5.Name = "CusFt_TotalSalesCount5";
            this.CusFt_TotalSalesCount5.OutputFormat = resources.GetString("CusFt_TotalSalesCount5.OutputFormat");
            this.CusFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount5.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount5.Text = "12,345,678";
            this.CusFt_TotalSalesCount5.Top = 0.219F;
            this.CusFt_TotalSalesCount5.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount6
            // 
            this.CusFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.CusFt_TotalSalesCount6.Height = 0.156F;
            this.CusFt_TotalSalesCount6.Left = 6.125F;
            this.CusFt_TotalSalesCount6.MultiLine = false;
            this.CusFt_TotalSalesCount6.Name = "CusFt_TotalSalesCount6";
            this.CusFt_TotalSalesCount6.OutputFormat = resources.GetString("CusFt_TotalSalesCount6.OutputFormat");
            this.CusFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount6.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount6.Text = "12,345,678";
            this.CusFt_TotalSalesCount6.Top = 0.219F;
            this.CusFt_TotalSalesCount6.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount4
            // 
            this.CusFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.CusFt_TotalSalesCount4.Height = 0.156F;
            this.CusFt_TotalSalesCount4.Left = 5F;
            this.CusFt_TotalSalesCount4.MultiLine = false;
            this.CusFt_TotalSalesCount4.Name = "CusFt_TotalSalesCount4";
            this.CusFt_TotalSalesCount4.OutputFormat = resources.GetString("CusFt_TotalSalesCount4.OutputFormat");
            this.CusFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount4.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount4.Text = "12,345,678";
            this.CusFt_TotalSalesCount4.Top = 0.219F;
            this.CusFt_TotalSalesCount4.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount7
            // 
            this.CusFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.CusFt_TotalSalesCount7.Height = 0.156F;
            this.CusFt_TotalSalesCount7.Left = 6.6875F;
            this.CusFt_TotalSalesCount7.MultiLine = false;
            this.CusFt_TotalSalesCount7.Name = "CusFt_TotalSalesCount7";
            this.CusFt_TotalSalesCount7.OutputFormat = resources.GetString("CusFt_TotalSalesCount7.OutputFormat");
            this.CusFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount7.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount7.Text = "12,345,678";
            this.CusFt_TotalSalesCount7.Top = 0.219F;
            this.CusFt_TotalSalesCount7.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount8
            // 
            this.CusFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.CusFt_TotalSalesCount8.Height = 0.156F;
            this.CusFt_TotalSalesCount8.Left = 7.25F;
            this.CusFt_TotalSalesCount8.MultiLine = false;
            this.CusFt_TotalSalesCount8.Name = "CusFt_TotalSalesCount8";
            this.CusFt_TotalSalesCount8.OutputFormat = resources.GetString("CusFt_TotalSalesCount8.OutputFormat");
            this.CusFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount8.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount8.Text = "12,345,678";
            this.CusFt_TotalSalesCount8.Top = 0.219F;
            this.CusFt_TotalSalesCount8.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount9
            // 
            this.CusFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.CusFt_TotalSalesCount9.Height = 0.156F;
            this.CusFt_TotalSalesCount9.Left = 7.8125F;
            this.CusFt_TotalSalesCount9.MultiLine = false;
            this.CusFt_TotalSalesCount9.Name = "CusFt_TotalSalesCount9";
            this.CusFt_TotalSalesCount9.OutputFormat = resources.GetString("CusFt_TotalSalesCount9.OutputFormat");
            this.CusFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount9.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount9.Text = "12,345,678";
            this.CusFt_TotalSalesCount9.Top = 0.219F;
            this.CusFt_TotalSalesCount9.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount11
            // 
            this.CusFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.CusFt_TotalSalesCount11.Height = 0.156F;
            this.CusFt_TotalSalesCount11.Left = 8.9375F;
            this.CusFt_TotalSalesCount11.MultiLine = false;
            this.CusFt_TotalSalesCount11.Name = "CusFt_TotalSalesCount11";
            this.CusFt_TotalSalesCount11.OutputFormat = resources.GetString("CusFt_TotalSalesCount11.OutputFormat");
            this.CusFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount11.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount11.Text = "12,345,678";
            this.CusFt_TotalSalesCount11.Top = 0.219F;
            this.CusFt_TotalSalesCount11.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount12
            // 
            this.CusFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.CusFt_TotalSalesCount12.Height = 0.156F;
            this.CusFt_TotalSalesCount12.Left = 9.5F;
            this.CusFt_TotalSalesCount12.MultiLine = false;
            this.CusFt_TotalSalesCount12.Name = "CusFt_TotalSalesCount12";
            this.CusFt_TotalSalesCount12.OutputFormat = resources.GetString("CusFt_TotalSalesCount12.OutputFormat");
            this.CusFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount12.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount12.Text = "12,345,678";
            this.CusFt_TotalSalesCount12.Top = 0.219F;
            this.CusFt_TotalSalesCount12.Width = 0.55F;
            // 
            // CusFt_TotalSalesCount10
            // 
            this.CusFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.CusFt_TotalSalesCount10.Height = 0.156F;
            this.CusFt_TotalSalesCount10.Left = 8.375F;
            this.CusFt_TotalSalesCount10.MultiLine = false;
            this.CusFt_TotalSalesCount10.Name = "CusFt_TotalSalesCount10";
            this.CusFt_TotalSalesCount10.OutputFormat = resources.GetString("CusFt_TotalSalesCount10.OutputFormat");
            this.CusFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TotalSalesCount10.SummaryGroup = "CustomerHeader";
            this.CusFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TotalSalesCount10.Text = "12,345,678";
            this.CusFt_TotalSalesCount10.Top = 0.219F;
            this.CusFt_TotalSalesCount10.Width = 0.55F;
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
            this.CusFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.CusFt_TtlTotalSalesCount.Height = 0.156F;
            this.CusFt_TtlTotalSalesCount.Left = 10.0625F;
            this.CusFt_TtlTotalSalesCount.MultiLine = false;
            this.CusFt_TtlTotalSalesCount.Name = "CusFt_TtlTotalSalesCount";
            this.CusFt_TtlTotalSalesCount.OutputFormat = resources.GetString("CusFt_TtlTotalSalesCount.OutputFormat");
            this.CusFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TtlTotalSalesCount.SummaryGroup = "CustomerHeader";
            this.CusFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.CusFt_TtlTotalSalesCount.Top = 0.219F;
            this.CusFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // CusFt_TtlSalesMoney
            // 
            this.CusFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.CusFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.CusFt_TtlSalesMoney.Height = 0.156F;
            this.CusFt_TtlSalesMoney.Left = 10.0625F;
            this.CusFt_TtlSalesMoney.MultiLine = false;
            this.CusFt_TtlSalesMoney.Name = "CusFt_TtlSalesMoney";
            this.CusFt_TtlSalesMoney.OutputFormat = resources.GetString("CusFt_TtlSalesMoney.OutputFormat");
            this.CusFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.CusFt_TtlSalesMoney.SummaryGroup = "CustomerHeader";
            this.CusFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CusFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CusFt_TtlSalesMoney.Text = "1,234,567,890";
            this.CusFt_TtlSalesMoney.Top = 0.0625F;
            this.CusFt_TtlSalesMoney.Width = 0.688F;
            // 
            // BLGoodsCodeHeader
            // 
            this.BLGoodsCodeHeader.CanShrink = true;
            this.BLGoodsCodeHeader.DataField = "BLGoodsCode";
            this.BLGoodsCodeHeader.Height = 0F;
            this.BLGoodsCodeHeader.Name = "BLGoodsCodeHeader";
            // 
            // BLGoodsCodeFooter
            // 
            this.BLGoodsCodeFooter.CanShrink = true;
            this.BLGoodsCodeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line16,
            this.textBox31,
            this.BlFt_SalesMoney1,
            this.BlFt_BLGoodsCode,
            this.BlFt_BLGoodsFullName,
            this.BlFt_SalesMoney2,
            this.BlFt_SalesMoney3,
            this.BlFt_SalesMoney4,
            this.BlFt_SalesMoney5,
            this.BlFt_SalesMoney6,
            this.BlFt_SalesMoney7,
            this.BlFt_SalesMoney8,
            this.BlFt_SalesMoney9,
            this.BlFt_SalesMoney10,
            this.BlFt_SalesMoney11,
            this.BlFt_SalesMoney12,
            this.BlFt_TotalSalesCount1,
            this.BlFt_TotalSalesCount2,
            this.BlFt_TotalSalesCount3,
            this.BlFt_TotalSalesCount4,
            this.BlFt_TotalSalesCount5,
            this.BlFt_TotalSalesCount6,
            this.BlFt_TotalSalesCount7,
            this.BlFt_TotalSalesCount8,
            this.BlFt_TotalSalesCount9,
            this.BlFt_TotalSalesCount10,
            this.BlFt_TotalSalesCount11,
            this.BlFt_TotalSalesCount12,
            this.BlFt_TtlSalesMoney,
            this.BlFt_TtlTotalSalesCount});
            this.BLGoodsCodeFooter.Height = 0.40625F;
            this.BLGoodsCodeFooter.KeepTogether = true;
            this.BLGoodsCodeFooter.Name = "BLGoodsCodeFooter";
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
            this.textBox31.Left = 0.4375F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox31.Text = "ＢＬコード計";
            this.textBox31.Top = 0.0625F;
            this.textBox31.Width = 1.09375F;
            // 
            // BlFt_SalesMoney1
            // 
            this.BlFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney1.DataField = "SalesMoney1";
            this.BlFt_SalesMoney1.Height = 0.156F;
            this.BlFt_SalesMoney1.Left = 3.3125F;
            this.BlFt_SalesMoney1.MultiLine = false;
            this.BlFt_SalesMoney1.Name = "BlFt_SalesMoney1";
            this.BlFt_SalesMoney1.OutputFormat = resources.GetString("BlFt_SalesMoney1.OutputFormat");
            this.BlFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney1.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney1.Text = "12,345,678";
            this.BlFt_SalesMoney1.Top = 0.0625F;
            this.BlFt_SalesMoney1.Width = 0.55F;
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
            this.BlFt_BLGoodsCode.Height = 0.156F;
            this.BlFt_BLGoodsCode.Left = 1.75F;
            this.BlFt_BLGoodsCode.MultiLine = false;
            this.BlFt_BLGoodsCode.Name = "BlFt_BLGoodsCode";
            this.BlFt_BLGoodsCode.OutputFormat = resources.GetString("BlFt_BLGoodsCode.OutputFormat");
            this.BlFt_BLGoodsCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_BLGoodsCode.Text = "12345";
            this.BlFt_BLGoodsCode.Top = 0.0625F;
            this.BlFt_BLGoodsCode.Width = 0.35F;
            // 
            // BlFt_BLGoodsFullName
            // 
            this.BlFt_BLGoodsFullName.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsFullName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsFullName.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsFullName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsFullName.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsFullName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsFullName.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_BLGoodsFullName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_BLGoodsFullName.DataField = "BLGoodsHalfName";
            this.BlFt_BLGoodsFullName.Height = 0.156F;
            this.BlFt_BLGoodsFullName.Left = 2.125F;
            this.BlFt_BLGoodsFullName.MultiLine = false;
            this.BlFt_BLGoodsFullName.Name = "BlFt_BLGoodsFullName";
            this.BlFt_BLGoodsFullName.OutputFormat = resources.GetString("BlFt_BLGoodsFullName.OutputFormat");
            this.BlFt_BLGoodsFullName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.BlFt_BLGoodsFullName.Text = "あいうえおかきくけこ";
            this.BlFt_BLGoodsFullName.Top = 0.0625F;
            this.BlFt_BLGoodsFullName.Width = 1.188F;
            // 
            // BlFt_SalesMoney2
            // 
            this.BlFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney2.DataField = "SalesMoney2";
            this.BlFt_SalesMoney2.Height = 0.156F;
            this.BlFt_SalesMoney2.Left = 3.875F;
            this.BlFt_SalesMoney2.MultiLine = false;
            this.BlFt_SalesMoney2.Name = "BlFt_SalesMoney2";
            this.BlFt_SalesMoney2.OutputFormat = resources.GetString("BlFt_SalesMoney2.OutputFormat");
            this.BlFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney2.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney2.Text = "12,345,678";
            this.BlFt_SalesMoney2.Top = 0.0625F;
            this.BlFt_SalesMoney2.Width = 0.55F;
            // 
            // BlFt_SalesMoney3
            // 
            this.BlFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney3.DataField = "SalesMoney3";
            this.BlFt_SalesMoney3.Height = 0.156F;
            this.BlFt_SalesMoney3.Left = 4.4375F;
            this.BlFt_SalesMoney3.MultiLine = false;
            this.BlFt_SalesMoney3.Name = "BlFt_SalesMoney3";
            this.BlFt_SalesMoney3.OutputFormat = resources.GetString("BlFt_SalesMoney3.OutputFormat");
            this.BlFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney3.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney3.Text = "12,345,678";
            this.BlFt_SalesMoney3.Top = 0.0625F;
            this.BlFt_SalesMoney3.Width = 0.55F;
            // 
            // BlFt_SalesMoney4
            // 
            this.BlFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney4.DataField = "SalesMoney4";
            this.BlFt_SalesMoney4.Height = 0.156F;
            this.BlFt_SalesMoney4.Left = 5F;
            this.BlFt_SalesMoney4.MultiLine = false;
            this.BlFt_SalesMoney4.Name = "BlFt_SalesMoney4";
            this.BlFt_SalesMoney4.OutputFormat = resources.GetString("BlFt_SalesMoney4.OutputFormat");
            this.BlFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney4.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney4.Text = "12,345,678";
            this.BlFt_SalesMoney4.Top = 0.0625F;
            this.BlFt_SalesMoney4.Width = 0.55F;
            // 
            // BlFt_SalesMoney5
            // 
            this.BlFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney5.DataField = "SalesMoney5";
            this.BlFt_SalesMoney5.Height = 0.156F;
            this.BlFt_SalesMoney5.Left = 5.5625F;
            this.BlFt_SalesMoney5.MultiLine = false;
            this.BlFt_SalesMoney5.Name = "BlFt_SalesMoney5";
            this.BlFt_SalesMoney5.OutputFormat = resources.GetString("BlFt_SalesMoney5.OutputFormat");
            this.BlFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney5.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney5.Text = "12,345,678";
            this.BlFt_SalesMoney5.Top = 0.0625F;
            this.BlFt_SalesMoney5.Width = 0.55F;
            // 
            // BlFt_SalesMoney6
            // 
            this.BlFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney6.DataField = "SalesMoney6";
            this.BlFt_SalesMoney6.Height = 0.156F;
            this.BlFt_SalesMoney6.Left = 6.125F;
            this.BlFt_SalesMoney6.MultiLine = false;
            this.BlFt_SalesMoney6.Name = "BlFt_SalesMoney6";
            this.BlFt_SalesMoney6.OutputFormat = resources.GetString("BlFt_SalesMoney6.OutputFormat");
            this.BlFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney6.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney6.Text = "12,345,678";
            this.BlFt_SalesMoney6.Top = 0.0625F;
            this.BlFt_SalesMoney6.Width = 0.55F;
            // 
            // BlFt_SalesMoney7
            // 
            this.BlFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney7.DataField = "SalesMoney7";
            this.BlFt_SalesMoney7.Height = 0.156F;
            this.BlFt_SalesMoney7.Left = 6.6875F;
            this.BlFt_SalesMoney7.MultiLine = false;
            this.BlFt_SalesMoney7.Name = "BlFt_SalesMoney7";
            this.BlFt_SalesMoney7.OutputFormat = resources.GetString("BlFt_SalesMoney7.OutputFormat");
            this.BlFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney7.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney7.Text = "12,345,678";
            this.BlFt_SalesMoney7.Top = 0.0625F;
            this.BlFt_SalesMoney7.Width = 0.55F;
            // 
            // BlFt_SalesMoney8
            // 
            this.BlFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney8.DataField = "SalesMoney8";
            this.BlFt_SalesMoney8.Height = 0.156F;
            this.BlFt_SalesMoney8.Left = 7.25F;
            this.BlFt_SalesMoney8.MultiLine = false;
            this.BlFt_SalesMoney8.Name = "BlFt_SalesMoney8";
            this.BlFt_SalesMoney8.OutputFormat = resources.GetString("BlFt_SalesMoney8.OutputFormat");
            this.BlFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney8.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney8.Text = "12,345,678";
            this.BlFt_SalesMoney8.Top = 0.0625F;
            this.BlFt_SalesMoney8.Width = 0.55F;
            // 
            // BlFt_SalesMoney9
            // 
            this.BlFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney9.DataField = "SalesMoney9";
            this.BlFt_SalesMoney9.Height = 0.156F;
            this.BlFt_SalesMoney9.Left = 7.8125F;
            this.BlFt_SalesMoney9.MultiLine = false;
            this.BlFt_SalesMoney9.Name = "BlFt_SalesMoney9";
            this.BlFt_SalesMoney9.OutputFormat = resources.GetString("BlFt_SalesMoney9.OutputFormat");
            this.BlFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney9.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney9.Text = "12,345,678";
            this.BlFt_SalesMoney9.Top = 0.0625F;
            this.BlFt_SalesMoney9.Width = 0.55F;
            // 
            // BlFt_SalesMoney10
            // 
            this.BlFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney10.DataField = "SalesMoney10";
            this.BlFt_SalesMoney10.Height = 0.156F;
            this.BlFt_SalesMoney10.Left = 8.375F;
            this.BlFt_SalesMoney10.MultiLine = false;
            this.BlFt_SalesMoney10.Name = "BlFt_SalesMoney10";
            this.BlFt_SalesMoney10.OutputFormat = resources.GetString("BlFt_SalesMoney10.OutputFormat");
            this.BlFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney10.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney10.Text = "12,345,678";
            this.BlFt_SalesMoney10.Top = 0.0625F;
            this.BlFt_SalesMoney10.Width = 0.55F;
            // 
            // BlFt_SalesMoney11
            // 
            this.BlFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney11.DataField = "SalesMoney11";
            this.BlFt_SalesMoney11.Height = 0.156F;
            this.BlFt_SalesMoney11.Left = 8.9375F;
            this.BlFt_SalesMoney11.MultiLine = false;
            this.BlFt_SalesMoney11.Name = "BlFt_SalesMoney11";
            this.BlFt_SalesMoney11.OutputFormat = resources.GetString("BlFt_SalesMoney11.OutputFormat");
            this.BlFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney11.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney11.Text = "12,345,678";
            this.BlFt_SalesMoney11.Top = 0.0625F;
            this.BlFt_SalesMoney11.Width = 0.55F;
            // 
            // BlFt_SalesMoney12
            // 
            this.BlFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_SalesMoney12.DataField = "SalesMoney12";
            this.BlFt_SalesMoney12.Height = 0.156F;
            this.BlFt_SalesMoney12.Left = 9.5F;
            this.BlFt_SalesMoney12.MultiLine = false;
            this.BlFt_SalesMoney12.Name = "BlFt_SalesMoney12";
            this.BlFt_SalesMoney12.OutputFormat = resources.GetString("BlFt_SalesMoney12.OutputFormat");
            this.BlFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_SalesMoney12.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_SalesMoney12.Text = "12,345,678";
            this.BlFt_SalesMoney12.Top = 0.0625F;
            this.BlFt_SalesMoney12.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount1
            // 
            this.BlFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.BlFt_TotalSalesCount1.Height = 0.156F;
            this.BlFt_TotalSalesCount1.Left = 3.3125F;
            this.BlFt_TotalSalesCount1.MultiLine = false;
            this.BlFt_TotalSalesCount1.Name = "BlFt_TotalSalesCount1";
            this.BlFt_TotalSalesCount1.OutputFormat = resources.GetString("BlFt_TotalSalesCount1.OutputFormat");
            this.BlFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount1.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount1.Text = "12,345,678";
            this.BlFt_TotalSalesCount1.Top = 0.219F;
            this.BlFt_TotalSalesCount1.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount2
            // 
            this.BlFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.BlFt_TotalSalesCount2.Height = 0.156F;
            this.BlFt_TotalSalesCount2.Left = 3.875F;
            this.BlFt_TotalSalesCount2.MultiLine = false;
            this.BlFt_TotalSalesCount2.Name = "BlFt_TotalSalesCount2";
            this.BlFt_TotalSalesCount2.OutputFormat = resources.GetString("BlFt_TotalSalesCount2.OutputFormat");
            this.BlFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount2.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount2.Text = "12,345,678";
            this.BlFt_TotalSalesCount2.Top = 0.219F;
            this.BlFt_TotalSalesCount2.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount3
            // 
            this.BlFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.BlFt_TotalSalesCount3.Height = 0.156F;
            this.BlFt_TotalSalesCount3.Left = 4.4375F;
            this.BlFt_TotalSalesCount3.MultiLine = false;
            this.BlFt_TotalSalesCount3.Name = "BlFt_TotalSalesCount3";
            this.BlFt_TotalSalesCount3.OutputFormat = resources.GetString("BlFt_TotalSalesCount3.OutputFormat");
            this.BlFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount3.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount3.Text = "12,345,678";
            this.BlFt_TotalSalesCount3.Top = 0.219F;
            this.BlFt_TotalSalesCount3.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount4
            // 
            this.BlFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.BlFt_TotalSalesCount4.Height = 0.156F;
            this.BlFt_TotalSalesCount4.Left = 5F;
            this.BlFt_TotalSalesCount4.MultiLine = false;
            this.BlFt_TotalSalesCount4.Name = "BlFt_TotalSalesCount4";
            this.BlFt_TotalSalesCount4.OutputFormat = resources.GetString("BlFt_TotalSalesCount4.OutputFormat");
            this.BlFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount4.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount4.Text = "12,345,678";
            this.BlFt_TotalSalesCount4.Top = 0.219F;
            this.BlFt_TotalSalesCount4.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount5
            // 
            this.BlFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.BlFt_TotalSalesCount5.Height = 0.156F;
            this.BlFt_TotalSalesCount5.Left = 5.5625F;
            this.BlFt_TotalSalesCount5.MultiLine = false;
            this.BlFt_TotalSalesCount5.Name = "BlFt_TotalSalesCount5";
            this.BlFt_TotalSalesCount5.OutputFormat = resources.GetString("BlFt_TotalSalesCount5.OutputFormat");
            this.BlFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount5.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount5.Text = "12,345,678";
            this.BlFt_TotalSalesCount5.Top = 0.219F;
            this.BlFt_TotalSalesCount5.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount6
            // 
            this.BlFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.BlFt_TotalSalesCount6.Height = 0.156F;
            this.BlFt_TotalSalesCount6.Left = 6.125F;
            this.BlFt_TotalSalesCount6.MultiLine = false;
            this.BlFt_TotalSalesCount6.Name = "BlFt_TotalSalesCount6";
            this.BlFt_TotalSalesCount6.OutputFormat = resources.GetString("BlFt_TotalSalesCount6.OutputFormat");
            this.BlFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount6.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount6.Text = "12,345,678";
            this.BlFt_TotalSalesCount6.Top = 0.219F;
            this.BlFt_TotalSalesCount6.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount7
            // 
            this.BlFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.BlFt_TotalSalesCount7.Height = 0.156F;
            this.BlFt_TotalSalesCount7.Left = 6.6875F;
            this.BlFt_TotalSalesCount7.MultiLine = false;
            this.BlFt_TotalSalesCount7.Name = "BlFt_TotalSalesCount7";
            this.BlFt_TotalSalesCount7.OutputFormat = resources.GetString("BlFt_TotalSalesCount7.OutputFormat");
            this.BlFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount7.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount7.Text = "12,345,678";
            this.BlFt_TotalSalesCount7.Top = 0.219F;
            this.BlFt_TotalSalesCount7.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount8
            // 
            this.BlFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.BlFt_TotalSalesCount8.Height = 0.156F;
            this.BlFt_TotalSalesCount8.Left = 7.25F;
            this.BlFt_TotalSalesCount8.MultiLine = false;
            this.BlFt_TotalSalesCount8.Name = "BlFt_TotalSalesCount8";
            this.BlFt_TotalSalesCount8.OutputFormat = resources.GetString("BlFt_TotalSalesCount8.OutputFormat");
            this.BlFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount8.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount8.Text = "12,345,678";
            this.BlFt_TotalSalesCount8.Top = 0.219F;
            this.BlFt_TotalSalesCount8.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount9
            // 
            this.BlFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.BlFt_TotalSalesCount9.Height = 0.156F;
            this.BlFt_TotalSalesCount9.Left = 7.8125F;
            this.BlFt_TotalSalesCount9.MultiLine = false;
            this.BlFt_TotalSalesCount9.Name = "BlFt_TotalSalesCount9";
            this.BlFt_TotalSalesCount9.OutputFormat = resources.GetString("BlFt_TotalSalesCount9.OutputFormat");
            this.BlFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount9.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount9.Text = "12,345,678";
            this.BlFt_TotalSalesCount9.Top = 0.219F;
            this.BlFt_TotalSalesCount9.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount10
            // 
            this.BlFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.BlFt_TotalSalesCount10.Height = 0.156F;
            this.BlFt_TotalSalesCount10.Left = 8.375F;
            this.BlFt_TotalSalesCount10.MultiLine = false;
            this.BlFt_TotalSalesCount10.Name = "BlFt_TotalSalesCount10";
            this.BlFt_TotalSalesCount10.OutputFormat = resources.GetString("BlFt_TotalSalesCount10.OutputFormat");
            this.BlFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount10.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount10.Text = "12,345,678";
            this.BlFt_TotalSalesCount10.Top = 0.219F;
            this.BlFt_TotalSalesCount10.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount11
            // 
            this.BlFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.BlFt_TotalSalesCount11.Height = 0.156F;
            this.BlFt_TotalSalesCount11.Left = 8.9375F;
            this.BlFt_TotalSalesCount11.MultiLine = false;
            this.BlFt_TotalSalesCount11.Name = "BlFt_TotalSalesCount11";
            this.BlFt_TotalSalesCount11.OutputFormat = resources.GetString("BlFt_TotalSalesCount11.OutputFormat");
            this.BlFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount11.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount11.Text = "12,345,678";
            this.BlFt_TotalSalesCount11.Top = 0.219F;
            this.BlFt_TotalSalesCount11.Width = 0.55F;
            // 
            // BlFt_TotalSalesCount12
            // 
            this.BlFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.BlFt_TotalSalesCount12.Height = 0.156F;
            this.BlFt_TotalSalesCount12.Left = 9.5F;
            this.BlFt_TotalSalesCount12.MultiLine = false;
            this.BlFt_TotalSalesCount12.Name = "BlFt_TotalSalesCount12";
            this.BlFt_TotalSalesCount12.OutputFormat = resources.GetString("BlFt_TotalSalesCount12.OutputFormat");
            this.BlFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TotalSalesCount12.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TotalSalesCount12.Text = "12,345,678";
            this.BlFt_TotalSalesCount12.Top = 0.219F;
            this.BlFt_TotalSalesCount12.Width = 0.55F;
            // 
            // BlFt_TtlSalesMoney
            // 
            this.BlFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.BlFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.BlFt_TtlSalesMoney.Height = 0.156F;
            this.BlFt_TtlSalesMoney.Left = 10.0625F;
            this.BlFt_TtlSalesMoney.MultiLine = false;
            this.BlFt_TtlSalesMoney.Name = "BlFt_TtlSalesMoney";
            this.BlFt_TtlSalesMoney.OutputFormat = resources.GetString("BlFt_TtlSalesMoney.OutputFormat");
            this.BlFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TtlSalesMoney.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TtlSalesMoney.Text = "1,234,567,890";
            this.BlFt_TtlSalesMoney.Top = 0.0625F;
            this.BlFt_TtlSalesMoney.Width = 0.688F;
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
            this.BlFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.BlFt_TtlTotalSalesCount.Height = 0.156F;
            this.BlFt_TtlTotalSalesCount.Left = 10.0625F;
            this.BlFt_TtlTotalSalesCount.MultiLine = false;
            this.BlFt_TtlTotalSalesCount.Name = "BlFt_TtlTotalSalesCount";
            this.BlFt_TtlTotalSalesCount.OutputFormat = resources.GetString("BlFt_TtlTotalSalesCount.OutputFormat");
            this.BlFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.BlFt_TtlTotalSalesCount.SummaryGroup = "BLGoodsCodeHeader";
            this.BlFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.BlFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BlFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.BlFt_TtlTotalSalesCount.Top = 0.219F;
            this.BlFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // GoodsMGroupHeader
            // 
            this.GoodsMGroupHeader.CanShrink = true;
            this.GoodsMGroupHeader.DataField = "GoodsMGroup";
            this.GoodsMGroupHeader.Height = 0F;
            this.GoodsMGroupHeader.Name = "GoodsMGroupHeader";
            // 
            // GoodsMGroupFooter
            // 
            this.GoodsMGroupFooter.CanShrink = true;
            this.GoodsMGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line18,
            this.textBox33,
            this.MggFt_SalesMoney1,
            this.MggFt_GoodsMGroupCode,
            this.MggFt_GoodsMGroupName,
            this.MggFt_SalesMoney2,
            this.MggFt_SalesMoney3,
            this.MggFt_SalesMoney4,
            this.MggFt_SalesMoney5,
            this.MggFt_SalesMoney6,
            this.MggFt_SalesMoney7,
            this.MggFt_SalesMoney11,
            this.MggFt_SalesMoney10,
            this.MggFt_SalesMoney9,
            this.MggFt_SalesMoney8,
            this.MggFt_SalesMoney12,
            this.MggFt_TotalSalesCount1,
            this.MggFt_TotalSalesCount2,
            this.MggFt_TotalSalesCount3,
            this.MggFt_TotalSalesCount4,
            this.MggFt_TotalSalesCount5,
            this.MggFt_TotalSalesCount6,
            this.MggFt_TotalSalesCount7,
            this.MggFt_TotalSalesCount8,
            this.MggFt_TotalSalesCount9,
            this.MggFt_TotalSalesCount10,
            this.MggFt_TotalSalesCount11,
            this.MggFt_TotalSalesCount12,
            this.MggFt_TtlTotalSalesCount,
            this.MggFt_TtlSalesMoney});
            this.GoodsMGroupFooter.Height = 0.4F;
            this.GoodsMGroupFooter.KeepTogether = true;
            this.GoodsMGroupFooter.Name = "GoodsMGroupFooter";
            this.GoodsMGroupFooter.BeforePrint += new System.EventHandler(this.GoodsMGroupFooter_BeforePrint);
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
            this.textBox33.Left = 0.4375F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox33.Text = "商品中分類計";
            this.textBox33.Top = 0.0625F;
            this.textBox33.Width = 1F;
            // 
            // MggFt_SalesMoney1
            // 
            this.MggFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney1.DataField = "SalesMoney1";
            this.MggFt_SalesMoney1.Height = 0.156F;
            this.MggFt_SalesMoney1.Left = 3.3125F;
            this.MggFt_SalesMoney1.MultiLine = false;
            this.MggFt_SalesMoney1.Name = "MggFt_SalesMoney1";
            this.MggFt_SalesMoney1.OutputFormat = resources.GetString("MggFt_SalesMoney1.OutputFormat");
            this.MggFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney1.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney1.Text = "12,345,678";
            this.MggFt_SalesMoney1.Top = 0.0625F;
            this.MggFt_SalesMoney1.Width = 0.55F;
            // 
            // MggFt_GoodsMGroupCode
            // 
            this.MggFt_GoodsMGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupCode.DataField = "GoodsMGroup";
            this.MggFt_GoodsMGroupCode.Height = 0.15625F;
            this.MggFt_GoodsMGroupCode.Left = 1.75F;
            this.MggFt_GoodsMGroupCode.MultiLine = false;
            this.MggFt_GoodsMGroupCode.Name = "MggFt_GoodsMGroupCode";
            this.MggFt_GoodsMGroupCode.OutputFormat = resources.GetString("MggFt_GoodsMGroupCode.OutputFormat");
            this.MggFt_GoodsMGroupCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_GoodsMGroupCode.Text = "1234";
            this.MggFt_GoodsMGroupCode.Top = 0.0625F;
            this.MggFt_GoodsMGroupCode.Width = 0.3125F;
            // 
            // MggFt_GoodsMGroupName
            // 
            this.MggFt_GoodsMGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_GoodsMGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_GoodsMGroupName.DataField = "GoodsMGroupName";
            this.MggFt_GoodsMGroupName.Height = 0.15625F;
            this.MggFt_GoodsMGroupName.Left = 2.125F;
            this.MggFt_GoodsMGroupName.MultiLine = false;
            this.MggFt_GoodsMGroupName.Name = "MggFt_GoodsMGroupName";
            this.MggFt_GoodsMGroupName.OutputFormat = resources.GetString("MggFt_GoodsMGroupName.OutputFormat");
            this.MggFt_GoodsMGroupName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.MggFt_GoodsMGroupName.Text = "あいうえおかきくけこ";
            this.MggFt_GoodsMGroupName.Top = 0.0625F;
            this.MggFt_GoodsMGroupName.Width = 1.1875F;
            // 
            // MggFt_SalesMoney2
            // 
            this.MggFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney2.DataField = "SalesMoney2";
            this.MggFt_SalesMoney2.Height = 0.156F;
            this.MggFt_SalesMoney2.Left = 3.875F;
            this.MggFt_SalesMoney2.MultiLine = false;
            this.MggFt_SalesMoney2.Name = "MggFt_SalesMoney2";
            this.MggFt_SalesMoney2.OutputFormat = resources.GetString("MggFt_SalesMoney2.OutputFormat");
            this.MggFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney2.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney2.Text = "12,345,678";
            this.MggFt_SalesMoney2.Top = 0.0625F;
            this.MggFt_SalesMoney2.Width = 0.55F;
            // 
            // MggFt_SalesMoney3
            // 
            this.MggFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney3.DataField = "SalesMoney3";
            this.MggFt_SalesMoney3.Height = 0.156F;
            this.MggFt_SalesMoney3.Left = 4.4375F;
            this.MggFt_SalesMoney3.MultiLine = false;
            this.MggFt_SalesMoney3.Name = "MggFt_SalesMoney3";
            this.MggFt_SalesMoney3.OutputFormat = resources.GetString("MggFt_SalesMoney3.OutputFormat");
            this.MggFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney3.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney3.Text = "12,345,678";
            this.MggFt_SalesMoney3.Top = 0.0625F;
            this.MggFt_SalesMoney3.Width = 0.55F;
            // 
            // MggFt_SalesMoney4
            // 
            this.MggFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney4.DataField = "SalesMoney4";
            this.MggFt_SalesMoney4.Height = 0.156F;
            this.MggFt_SalesMoney4.Left = 5F;
            this.MggFt_SalesMoney4.MultiLine = false;
            this.MggFt_SalesMoney4.Name = "MggFt_SalesMoney4";
            this.MggFt_SalesMoney4.OutputFormat = resources.GetString("MggFt_SalesMoney4.OutputFormat");
            this.MggFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney4.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney4.Text = "12,345,678";
            this.MggFt_SalesMoney4.Top = 0.0625F;
            this.MggFt_SalesMoney4.Width = 0.55F;
            // 
            // MggFt_SalesMoney5
            // 
            this.MggFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney5.DataField = "SalesMoney5";
            this.MggFt_SalesMoney5.Height = 0.156F;
            this.MggFt_SalesMoney5.Left = 5.5625F;
            this.MggFt_SalesMoney5.MultiLine = false;
            this.MggFt_SalesMoney5.Name = "MggFt_SalesMoney5";
            this.MggFt_SalesMoney5.OutputFormat = resources.GetString("MggFt_SalesMoney5.OutputFormat");
            this.MggFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney5.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney5.Text = "12,345,678";
            this.MggFt_SalesMoney5.Top = 0.0625F;
            this.MggFt_SalesMoney5.Width = 0.55F;
            // 
            // MggFt_SalesMoney6
            // 
            this.MggFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney6.DataField = "SalesMoney6";
            this.MggFt_SalesMoney6.Height = 0.156F;
            this.MggFt_SalesMoney6.Left = 6.125F;
            this.MggFt_SalesMoney6.MultiLine = false;
            this.MggFt_SalesMoney6.Name = "MggFt_SalesMoney6";
            this.MggFt_SalesMoney6.OutputFormat = resources.GetString("MggFt_SalesMoney6.OutputFormat");
            this.MggFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney6.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney6.Text = "12,345,678";
            this.MggFt_SalesMoney6.Top = 0.0625F;
            this.MggFt_SalesMoney6.Width = 0.55F;
            // 
            // MggFt_SalesMoney7
            // 
            this.MggFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney7.DataField = "SalesMoney7";
            this.MggFt_SalesMoney7.Height = 0.156F;
            this.MggFt_SalesMoney7.Left = 6.6875F;
            this.MggFt_SalesMoney7.MultiLine = false;
            this.MggFt_SalesMoney7.Name = "MggFt_SalesMoney7";
            this.MggFt_SalesMoney7.OutputFormat = resources.GetString("MggFt_SalesMoney7.OutputFormat");
            this.MggFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney7.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney7.Text = "12,345,678";
            this.MggFt_SalesMoney7.Top = 0.0625F;
            this.MggFt_SalesMoney7.Width = 0.55F;
            // 
            // MggFt_SalesMoney11
            // 
            this.MggFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney11.DataField = "SalesMoney11";
            this.MggFt_SalesMoney11.Height = 0.156F;
            this.MggFt_SalesMoney11.Left = 8.9375F;
            this.MggFt_SalesMoney11.MultiLine = false;
            this.MggFt_SalesMoney11.Name = "MggFt_SalesMoney11";
            this.MggFt_SalesMoney11.OutputFormat = resources.GetString("MggFt_SalesMoney11.OutputFormat");
            this.MggFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney11.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney11.Text = "12,345,678";
            this.MggFt_SalesMoney11.Top = 0.0625F;
            this.MggFt_SalesMoney11.Width = 0.55F;
            // 
            // MggFt_SalesMoney10
            // 
            this.MggFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney10.DataField = "SalesMoney10";
            this.MggFt_SalesMoney10.Height = 0.156F;
            this.MggFt_SalesMoney10.Left = 8.375F;
            this.MggFt_SalesMoney10.MultiLine = false;
            this.MggFt_SalesMoney10.Name = "MggFt_SalesMoney10";
            this.MggFt_SalesMoney10.OutputFormat = resources.GetString("MggFt_SalesMoney10.OutputFormat");
            this.MggFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney10.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney10.Text = "12,345,678";
            this.MggFt_SalesMoney10.Top = 0.0625F;
            this.MggFt_SalesMoney10.Width = 0.55F;
            // 
            // MggFt_SalesMoney9
            // 
            this.MggFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney9.DataField = "SalesMoney9";
            this.MggFt_SalesMoney9.Height = 0.156F;
            this.MggFt_SalesMoney9.Left = 7.8125F;
            this.MggFt_SalesMoney9.MultiLine = false;
            this.MggFt_SalesMoney9.Name = "MggFt_SalesMoney9";
            this.MggFt_SalesMoney9.OutputFormat = resources.GetString("MggFt_SalesMoney9.OutputFormat");
            this.MggFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney9.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney9.Text = "12,345,678";
            this.MggFt_SalesMoney9.Top = 0.0625F;
            this.MggFt_SalesMoney9.Width = 0.55F;
            // 
            // MggFt_SalesMoney8
            // 
            this.MggFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney8.DataField = "SalesMoney8";
            this.MggFt_SalesMoney8.Height = 0.156F;
            this.MggFt_SalesMoney8.Left = 7.25F;
            this.MggFt_SalesMoney8.MultiLine = false;
            this.MggFt_SalesMoney8.Name = "MggFt_SalesMoney8";
            this.MggFt_SalesMoney8.OutputFormat = resources.GetString("MggFt_SalesMoney8.OutputFormat");
            this.MggFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney8.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney8.Text = "12,345,678";
            this.MggFt_SalesMoney8.Top = 0.0625F;
            this.MggFt_SalesMoney8.Width = 0.55F;
            // 
            // MggFt_SalesMoney12
            // 
            this.MggFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_SalesMoney12.DataField = "SalesMoney12";
            this.MggFt_SalesMoney12.Height = 0.156F;
            this.MggFt_SalesMoney12.Left = 9.5F;
            this.MggFt_SalesMoney12.MultiLine = false;
            this.MggFt_SalesMoney12.Name = "MggFt_SalesMoney12";
            this.MggFt_SalesMoney12.OutputFormat = resources.GetString("MggFt_SalesMoney12.OutputFormat");
            this.MggFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_SalesMoney12.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_SalesMoney12.Text = "12,345,678";
            this.MggFt_SalesMoney12.Top = 0.0625F;
            this.MggFt_SalesMoney12.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount1
            // 
            this.MggFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.MggFt_TotalSalesCount1.Height = 0.156F;
            this.MggFt_TotalSalesCount1.Left = 3.3125F;
            this.MggFt_TotalSalesCount1.MultiLine = false;
            this.MggFt_TotalSalesCount1.Name = "MggFt_TotalSalesCount1";
            this.MggFt_TotalSalesCount1.OutputFormat = resources.GetString("MggFt_TotalSalesCount1.OutputFormat");
            this.MggFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount1.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount1.Text = "12,345,678";
            this.MggFt_TotalSalesCount1.Top = 0.219F;
            this.MggFt_TotalSalesCount1.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount2
            // 
            this.MggFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.MggFt_TotalSalesCount2.Height = 0.156F;
            this.MggFt_TotalSalesCount2.Left = 3.875F;
            this.MggFt_TotalSalesCount2.MultiLine = false;
            this.MggFt_TotalSalesCount2.Name = "MggFt_TotalSalesCount2";
            this.MggFt_TotalSalesCount2.OutputFormat = resources.GetString("MggFt_TotalSalesCount2.OutputFormat");
            this.MggFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount2.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount2.Text = "12,345,678";
            this.MggFt_TotalSalesCount2.Top = 0.219F;
            this.MggFt_TotalSalesCount2.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount3
            // 
            this.MggFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.MggFt_TotalSalesCount3.Height = 0.156F;
            this.MggFt_TotalSalesCount3.Left = 4.4375F;
            this.MggFt_TotalSalesCount3.MultiLine = false;
            this.MggFt_TotalSalesCount3.Name = "MggFt_TotalSalesCount3";
            this.MggFt_TotalSalesCount3.OutputFormat = resources.GetString("MggFt_TotalSalesCount3.OutputFormat");
            this.MggFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount3.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount3.Text = "12,345,678";
            this.MggFt_TotalSalesCount3.Top = 0.219F;
            this.MggFt_TotalSalesCount3.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount4
            // 
            this.MggFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.MggFt_TotalSalesCount4.Height = 0.156F;
            this.MggFt_TotalSalesCount4.Left = 5F;
            this.MggFt_TotalSalesCount4.MultiLine = false;
            this.MggFt_TotalSalesCount4.Name = "MggFt_TotalSalesCount4";
            this.MggFt_TotalSalesCount4.OutputFormat = resources.GetString("MggFt_TotalSalesCount4.OutputFormat");
            this.MggFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount4.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount4.Text = "12,345,678";
            this.MggFt_TotalSalesCount4.Top = 0.219F;
            this.MggFt_TotalSalesCount4.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount5
            // 
            this.MggFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.MggFt_TotalSalesCount5.Height = 0.156F;
            this.MggFt_TotalSalesCount5.Left = 5.5625F;
            this.MggFt_TotalSalesCount5.MultiLine = false;
            this.MggFt_TotalSalesCount5.Name = "MggFt_TotalSalesCount5";
            this.MggFt_TotalSalesCount5.OutputFormat = resources.GetString("MggFt_TotalSalesCount5.OutputFormat");
            this.MggFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount5.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount5.Text = "12,345,678";
            this.MggFt_TotalSalesCount5.Top = 0.219F;
            this.MggFt_TotalSalesCount5.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount6
            // 
            this.MggFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.MggFt_TotalSalesCount6.Height = 0.156F;
            this.MggFt_TotalSalesCount6.Left = 6.125F;
            this.MggFt_TotalSalesCount6.MultiLine = false;
            this.MggFt_TotalSalesCount6.Name = "MggFt_TotalSalesCount6";
            this.MggFt_TotalSalesCount6.OutputFormat = resources.GetString("MggFt_TotalSalesCount6.OutputFormat");
            this.MggFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount6.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount6.Text = "12,345,678";
            this.MggFt_TotalSalesCount6.Top = 0.219F;
            this.MggFt_TotalSalesCount6.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount7
            // 
            this.MggFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.MggFt_TotalSalesCount7.Height = 0.156F;
            this.MggFt_TotalSalesCount7.Left = 6.6875F;
            this.MggFt_TotalSalesCount7.MultiLine = false;
            this.MggFt_TotalSalesCount7.Name = "MggFt_TotalSalesCount7";
            this.MggFt_TotalSalesCount7.OutputFormat = resources.GetString("MggFt_TotalSalesCount7.OutputFormat");
            this.MggFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount7.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount7.Text = "12,345,678";
            this.MggFt_TotalSalesCount7.Top = 0.219F;
            this.MggFt_TotalSalesCount7.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount8
            // 
            this.MggFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.MggFt_TotalSalesCount8.Height = 0.156F;
            this.MggFt_TotalSalesCount8.Left = 7.25F;
            this.MggFt_TotalSalesCount8.MultiLine = false;
            this.MggFt_TotalSalesCount8.Name = "MggFt_TotalSalesCount8";
            this.MggFt_TotalSalesCount8.OutputFormat = resources.GetString("MggFt_TotalSalesCount8.OutputFormat");
            this.MggFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount8.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount8.Text = "12,345,678";
            this.MggFt_TotalSalesCount8.Top = 0.219F;
            this.MggFt_TotalSalesCount8.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount9
            // 
            this.MggFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.MggFt_TotalSalesCount9.Height = 0.156F;
            this.MggFt_TotalSalesCount9.Left = 7.8125F;
            this.MggFt_TotalSalesCount9.MultiLine = false;
            this.MggFt_TotalSalesCount9.Name = "MggFt_TotalSalesCount9";
            this.MggFt_TotalSalesCount9.OutputFormat = resources.GetString("MggFt_TotalSalesCount9.OutputFormat");
            this.MggFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount9.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount9.Text = "12,345,678";
            this.MggFt_TotalSalesCount9.Top = 0.219F;
            this.MggFt_TotalSalesCount9.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount10
            // 
            this.MggFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.MggFt_TotalSalesCount10.Height = 0.156F;
            this.MggFt_TotalSalesCount10.Left = 8.375F;
            this.MggFt_TotalSalesCount10.MultiLine = false;
            this.MggFt_TotalSalesCount10.Name = "MggFt_TotalSalesCount10";
            this.MggFt_TotalSalesCount10.OutputFormat = resources.GetString("MggFt_TotalSalesCount10.OutputFormat");
            this.MggFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount10.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount10.Text = "12,345,678";
            this.MggFt_TotalSalesCount10.Top = 0.219F;
            this.MggFt_TotalSalesCount10.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount11
            // 
            this.MggFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.MggFt_TotalSalesCount11.Height = 0.156F;
            this.MggFt_TotalSalesCount11.Left = 8.9375F;
            this.MggFt_TotalSalesCount11.MultiLine = false;
            this.MggFt_TotalSalesCount11.Name = "MggFt_TotalSalesCount11";
            this.MggFt_TotalSalesCount11.OutputFormat = resources.GetString("MggFt_TotalSalesCount11.OutputFormat");
            this.MggFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount11.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount11.Text = "12,345,678";
            this.MggFt_TotalSalesCount11.Top = 0.219F;
            this.MggFt_TotalSalesCount11.Width = 0.55F;
            // 
            // MggFt_TotalSalesCount12
            // 
            this.MggFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.MggFt_TotalSalesCount12.Height = 0.156F;
            this.MggFt_TotalSalesCount12.Left = 9.5F;
            this.MggFt_TotalSalesCount12.MultiLine = false;
            this.MggFt_TotalSalesCount12.Name = "MggFt_TotalSalesCount12";
            this.MggFt_TotalSalesCount12.OutputFormat = resources.GetString("MggFt_TotalSalesCount12.OutputFormat");
            this.MggFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TotalSalesCount12.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TotalSalesCount12.Text = "12,345,678";
            this.MggFt_TotalSalesCount12.Top = 0.219F;
            this.MggFt_TotalSalesCount12.Width = 0.55F;
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
            this.MggFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.MggFt_TtlTotalSalesCount.Height = 0.156F;
            this.MggFt_TtlTotalSalesCount.Left = 10.0625F;
            this.MggFt_TtlTotalSalesCount.MultiLine = false;
            this.MggFt_TtlTotalSalesCount.Name = "MggFt_TtlTotalSalesCount";
            this.MggFt_TtlTotalSalesCount.OutputFormat = resources.GetString("MggFt_TtlTotalSalesCount.OutputFormat");
            this.MggFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TtlTotalSalesCount.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.MggFt_TtlTotalSalesCount.Top = 0.219F;
            this.MggFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // MggFt_TtlSalesMoney
            // 
            this.MggFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MggFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MggFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.MggFt_TtlSalesMoney.Height = 0.156F;
            this.MggFt_TtlSalesMoney.Left = 10.0625F;
            this.MggFt_TtlSalesMoney.MultiLine = false;
            this.MggFt_TtlSalesMoney.Name = "MggFt_TtlSalesMoney";
            this.MggFt_TtlSalesMoney.OutputFormat = resources.GetString("MggFt_TtlSalesMoney.OutputFormat");
            this.MggFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MggFt_TtlSalesMoney.SummaryGroup = "GoodsMGroupHeader";
            this.MggFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MggFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MggFt_TtlSalesMoney.Text = "1,234,567,890";
            this.MggFt_TtlSalesMoney.Top = 0.0625F;
            this.MggFt_TtlSalesMoney.Width = 0.688F;
            // 
            // BLGroupCodeHeader
            // 
            this.BLGroupCodeHeader.CanShrink = true;
            this.BLGroupCodeHeader.DataField = "BLGroupCode";
            this.BLGroupCodeHeader.Height = 0F;
            this.BLGroupCodeHeader.Name = "BLGroupCodeHeader";
            // 
            // BLGroupCodeFooter
            // 
            this.BLGroupCodeFooter.CanShrink = true;
            this.BLGroupCodeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line17,
            this.textBox32,
            this.DggFt_SalesMoney1,
            this.DggFt_BLGroupCode,
            this.DggFt_BLGroupCodeName,
            this.DggFt_SalesMoney2,
            this.DggFt_SalesMoney3,
            this.DggFt_SalesMoney4,
            this.DggFt_SalesMoney5,
            this.DggFt_SalesMoney6,
            this.DggFt_SalesMoney11,
            this.DggFt_SalesMoney8,
            this.DggFt_SalesMoney9,
            this.DggFt_SalesMoney10,
            this.DggFt_SalesMoney12,
            this.DggFt_SalesMoney7,
            this.DggFt_TotalSalesCount1,
            this.DggFt_TotalSalesCount2,
            this.DggFt_TotalSalesCount3,
            this.DggFt_TotalSalesCount4,
            this.DggFt_TotalSalesCount5,
            this.DggFt_TotalSalesCount6,
            this.DggFt_TotalSalesCount7,
            this.DggFt_TotalSalesCount8,
            this.DggFt_TotalSalesCount9,
            this.DggFt_TotalSalesCount10,
            this.DggFt_TotalSalesCount11,
            this.DggFt_TotalSalesCount12,
            this.DggFt_TtlSalesMoney,
            this.DggFt_TtlTotalSalesCount});
            this.BLGroupCodeFooter.Height = 0.4F;
            this.BLGroupCodeFooter.KeepTogether = true;
            this.BLGroupCodeFooter.Name = "BLGroupCodeFooter";
            this.BLGroupCodeFooter.BeforePrint += new System.EventHandler(this.BLGroupCodeFooter_BeforePrint);
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
            this.textBox32.Left = 0.4375F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox32.Text = "グループコード計";
            this.textBox32.Top = 0.0625F;
            this.textBox32.Width = 1.3F;
            // 
            // DggFt_SalesMoney1
            // 
            this.DggFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney1.DataField = "SalesMoney1";
            this.DggFt_SalesMoney1.Height = 0.156F;
            this.DggFt_SalesMoney1.Left = 3.3125F;
            this.DggFt_SalesMoney1.MultiLine = false;
            this.DggFt_SalesMoney1.Name = "DggFt_SalesMoney1";
            this.DggFt_SalesMoney1.OutputFormat = resources.GetString("DggFt_SalesMoney1.OutputFormat");
            this.DggFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney1.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney1.Text = "12,345,678";
            this.DggFt_SalesMoney1.Top = 0.0625F;
            this.DggFt_SalesMoney1.Width = 0.55F;
            // 
            // DggFt_BLGroupCode
            // 
            this.DggFt_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCode.DataField = "BLGroupCode";
            this.DggFt_BLGroupCode.Height = 0.156F;
            this.DggFt_BLGroupCode.Left = 1.75F;
            this.DggFt_BLGroupCode.MultiLine = false;
            this.DggFt_BLGroupCode.Name = "DggFt_BLGroupCode";
            this.DggFt_BLGroupCode.OutputFormat = resources.GetString("DggFt_BLGroupCode.OutputFormat");
            this.DggFt_BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_BLGroupCode.Text = "12345";
            this.DggFt_BLGroupCode.Top = 0.0625F;
            this.DggFt_BLGroupCode.Width = 0.35F;
            // 
            // DggFt_BLGroupCodeName
            // 
            this.DggFt_BLGroupCodeName.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCodeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCodeName.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCodeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCodeName.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCodeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCodeName.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_BLGroupCodeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_BLGroupCodeName.DataField = "BLGroupKanaName";
            this.DggFt_BLGroupCodeName.Height = 0.15625F;
            this.DggFt_BLGroupCodeName.Left = 2.125F;
            this.DggFt_BLGroupCodeName.MultiLine = false;
            this.DggFt_BLGroupCodeName.Name = "DggFt_BLGroupCodeName";
            this.DggFt_BLGroupCodeName.OutputFormat = resources.GetString("DggFt_BLGroupCodeName.OutputFormat");
            this.DggFt_BLGroupCodeName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.DggFt_BLGroupCodeName.Text = "あいうえおかきくけこ";
            this.DggFt_BLGroupCodeName.Top = 0.0625F;
            this.DggFt_BLGroupCodeName.Width = 1.1875F;
            // 
            // DggFt_SalesMoney2
            // 
            this.DggFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney2.DataField = "SalesMoney2";
            this.DggFt_SalesMoney2.Height = 0.156F;
            this.DggFt_SalesMoney2.Left = 3.875F;
            this.DggFt_SalesMoney2.MultiLine = false;
            this.DggFt_SalesMoney2.Name = "DggFt_SalesMoney2";
            this.DggFt_SalesMoney2.OutputFormat = resources.GetString("DggFt_SalesMoney2.OutputFormat");
            this.DggFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney2.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney2.Text = "12,345,678";
            this.DggFt_SalesMoney2.Top = 0.0625F;
            this.DggFt_SalesMoney2.Width = 0.55F;
            // 
            // DggFt_SalesMoney3
            // 
            this.DggFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney3.DataField = "SalesMoney3";
            this.DggFt_SalesMoney3.Height = 0.156F;
            this.DggFt_SalesMoney3.Left = 4.4375F;
            this.DggFt_SalesMoney3.MultiLine = false;
            this.DggFt_SalesMoney3.Name = "DggFt_SalesMoney3";
            this.DggFt_SalesMoney3.OutputFormat = resources.GetString("DggFt_SalesMoney3.OutputFormat");
            this.DggFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney3.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney3.Text = "12,345,678";
            this.DggFt_SalesMoney3.Top = 0.0625F;
            this.DggFt_SalesMoney3.Width = 0.55F;
            // 
            // DggFt_SalesMoney4
            // 
            this.DggFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney4.DataField = "SalesMoney4";
            this.DggFt_SalesMoney4.Height = 0.156F;
            this.DggFt_SalesMoney4.Left = 5F;
            this.DggFt_SalesMoney4.MultiLine = false;
            this.DggFt_SalesMoney4.Name = "DggFt_SalesMoney4";
            this.DggFt_SalesMoney4.OutputFormat = resources.GetString("DggFt_SalesMoney4.OutputFormat");
            this.DggFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney4.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney4.Text = "12,345,678";
            this.DggFt_SalesMoney4.Top = 0.0625F;
            this.DggFt_SalesMoney4.Width = 0.55F;
            // 
            // DggFt_SalesMoney5
            // 
            this.DggFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney5.DataField = "SalesMoney5";
            this.DggFt_SalesMoney5.Height = 0.156F;
            this.DggFt_SalesMoney5.Left = 5.5625F;
            this.DggFt_SalesMoney5.MultiLine = false;
            this.DggFt_SalesMoney5.Name = "DggFt_SalesMoney5";
            this.DggFt_SalesMoney5.OutputFormat = resources.GetString("DggFt_SalesMoney5.OutputFormat");
            this.DggFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney5.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney5.Text = "12,345,678";
            this.DggFt_SalesMoney5.Top = 0.0625F;
            this.DggFt_SalesMoney5.Width = 0.55F;
            // 
            // DggFt_SalesMoney6
            // 
            this.DggFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney6.DataField = "SalesMoney6";
            this.DggFt_SalesMoney6.Height = 0.156F;
            this.DggFt_SalesMoney6.Left = 6.125F;
            this.DggFt_SalesMoney6.MultiLine = false;
            this.DggFt_SalesMoney6.Name = "DggFt_SalesMoney6";
            this.DggFt_SalesMoney6.OutputFormat = resources.GetString("DggFt_SalesMoney6.OutputFormat");
            this.DggFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney6.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney6.Text = "12,345,678";
            this.DggFt_SalesMoney6.Top = 0.0625F;
            this.DggFt_SalesMoney6.Width = 0.55F;
            // 
            // DggFt_SalesMoney11
            // 
            this.DggFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney11.DataField = "SalesMoney11";
            this.DggFt_SalesMoney11.Height = 0.156F;
            this.DggFt_SalesMoney11.Left = 8.9375F;
            this.DggFt_SalesMoney11.MultiLine = false;
            this.DggFt_SalesMoney11.Name = "DggFt_SalesMoney11";
            this.DggFt_SalesMoney11.OutputFormat = resources.GetString("DggFt_SalesMoney11.OutputFormat");
            this.DggFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney11.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney11.Text = "12,345,678";
            this.DggFt_SalesMoney11.Top = 0.0625F;
            this.DggFt_SalesMoney11.Width = 0.55F;
            // 
            // DggFt_SalesMoney8
            // 
            this.DggFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney8.DataField = "SalesMoney8";
            this.DggFt_SalesMoney8.Height = 0.156F;
            this.DggFt_SalesMoney8.Left = 7.25F;
            this.DggFt_SalesMoney8.MultiLine = false;
            this.DggFt_SalesMoney8.Name = "DggFt_SalesMoney8";
            this.DggFt_SalesMoney8.OutputFormat = resources.GetString("DggFt_SalesMoney8.OutputFormat");
            this.DggFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney8.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney8.Text = "12,345,678";
            this.DggFt_SalesMoney8.Top = 0.0625F;
            this.DggFt_SalesMoney8.Width = 0.55F;
            // 
            // DggFt_SalesMoney9
            // 
            this.DggFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney9.DataField = "SalesMoney9";
            this.DggFt_SalesMoney9.Height = 0.156F;
            this.DggFt_SalesMoney9.Left = 7.8125F;
            this.DggFt_SalesMoney9.MultiLine = false;
            this.DggFt_SalesMoney9.Name = "DggFt_SalesMoney9";
            this.DggFt_SalesMoney9.OutputFormat = resources.GetString("DggFt_SalesMoney9.OutputFormat");
            this.DggFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney9.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney9.Text = "12,345,678";
            this.DggFt_SalesMoney9.Top = 0.0625F;
            this.DggFt_SalesMoney9.Width = 0.55F;
            // 
            // DggFt_SalesMoney10
            // 
            this.DggFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney10.DataField = "SalesMoney10";
            this.DggFt_SalesMoney10.Height = 0.156F;
            this.DggFt_SalesMoney10.Left = 8.375F;
            this.DggFt_SalesMoney10.MultiLine = false;
            this.DggFt_SalesMoney10.Name = "DggFt_SalesMoney10";
            this.DggFt_SalesMoney10.OutputFormat = resources.GetString("DggFt_SalesMoney10.OutputFormat");
            this.DggFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney10.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney10.Text = "12,345,678";
            this.DggFt_SalesMoney10.Top = 0.0625F;
            this.DggFt_SalesMoney10.Width = 0.55F;
            // 
            // DggFt_SalesMoney12
            // 
            this.DggFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney12.DataField = "SalesMoney12";
            this.DggFt_SalesMoney12.Height = 0.156F;
            this.DggFt_SalesMoney12.Left = 9.5F;
            this.DggFt_SalesMoney12.MultiLine = false;
            this.DggFt_SalesMoney12.Name = "DggFt_SalesMoney12";
            this.DggFt_SalesMoney12.OutputFormat = resources.GetString("DggFt_SalesMoney12.OutputFormat");
            this.DggFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney12.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney12.Text = "12,345,678";
            this.DggFt_SalesMoney12.Top = 0.0625F;
            this.DggFt_SalesMoney12.Width = 0.55F;
            // 
            // DggFt_SalesMoney7
            // 
            this.DggFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_SalesMoney7.DataField = "SalesMoney7";
            this.DggFt_SalesMoney7.Height = 0.156F;
            this.DggFt_SalesMoney7.Left = 6.6875F;
            this.DggFt_SalesMoney7.MultiLine = false;
            this.DggFt_SalesMoney7.Name = "DggFt_SalesMoney7";
            this.DggFt_SalesMoney7.OutputFormat = resources.GetString("DggFt_SalesMoney7.OutputFormat");
            this.DggFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_SalesMoney7.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_SalesMoney7.Text = "12,345,678";
            this.DggFt_SalesMoney7.Top = 0.0625F;
            this.DggFt_SalesMoney7.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount1
            // 
            this.DggFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.DggFt_TotalSalesCount1.Height = 0.156F;
            this.DggFt_TotalSalesCount1.Left = 3.3125F;
            this.DggFt_TotalSalesCount1.MultiLine = false;
            this.DggFt_TotalSalesCount1.Name = "DggFt_TotalSalesCount1";
            this.DggFt_TotalSalesCount1.OutputFormat = resources.GetString("DggFt_TotalSalesCount1.OutputFormat");
            this.DggFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount1.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount1.Text = "12,345,678";
            this.DggFt_TotalSalesCount1.Top = 0.219F;
            this.DggFt_TotalSalesCount1.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount2
            // 
            this.DggFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.DggFt_TotalSalesCount2.Height = 0.156F;
            this.DggFt_TotalSalesCount2.Left = 3.875F;
            this.DggFt_TotalSalesCount2.MultiLine = false;
            this.DggFt_TotalSalesCount2.Name = "DggFt_TotalSalesCount2";
            this.DggFt_TotalSalesCount2.OutputFormat = resources.GetString("DggFt_TotalSalesCount2.OutputFormat");
            this.DggFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount2.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount2.Text = "12,345,678";
            this.DggFt_TotalSalesCount2.Top = 0.219F;
            this.DggFt_TotalSalesCount2.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount3
            // 
            this.DggFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.DggFt_TotalSalesCount3.Height = 0.156F;
            this.DggFt_TotalSalesCount3.Left = 4.4375F;
            this.DggFt_TotalSalesCount3.MultiLine = false;
            this.DggFt_TotalSalesCount3.Name = "DggFt_TotalSalesCount3";
            this.DggFt_TotalSalesCount3.OutputFormat = resources.GetString("DggFt_TotalSalesCount3.OutputFormat");
            this.DggFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount3.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount3.Text = "12,345,678";
            this.DggFt_TotalSalesCount3.Top = 0.219F;
            this.DggFt_TotalSalesCount3.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount4
            // 
            this.DggFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.DggFt_TotalSalesCount4.Height = 0.156F;
            this.DggFt_TotalSalesCount4.Left = 5F;
            this.DggFt_TotalSalesCount4.MultiLine = false;
            this.DggFt_TotalSalesCount4.Name = "DggFt_TotalSalesCount4";
            this.DggFt_TotalSalesCount4.OutputFormat = resources.GetString("DggFt_TotalSalesCount4.OutputFormat");
            this.DggFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount4.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount4.Text = "12,345,678";
            this.DggFt_TotalSalesCount4.Top = 0.219F;
            this.DggFt_TotalSalesCount4.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount5
            // 
            this.DggFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.DggFt_TotalSalesCount5.Height = 0.156F;
            this.DggFt_TotalSalesCount5.Left = 5.5625F;
            this.DggFt_TotalSalesCount5.MultiLine = false;
            this.DggFt_TotalSalesCount5.Name = "DggFt_TotalSalesCount5";
            this.DggFt_TotalSalesCount5.OutputFormat = resources.GetString("DggFt_TotalSalesCount5.OutputFormat");
            this.DggFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount5.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount5.Text = "12,345,678";
            this.DggFt_TotalSalesCount5.Top = 0.219F;
            this.DggFt_TotalSalesCount5.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount6
            // 
            this.DggFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.DggFt_TotalSalesCount6.Height = 0.156F;
            this.DggFt_TotalSalesCount6.Left = 6.125F;
            this.DggFt_TotalSalesCount6.MultiLine = false;
            this.DggFt_TotalSalesCount6.Name = "DggFt_TotalSalesCount6";
            this.DggFt_TotalSalesCount6.OutputFormat = resources.GetString("DggFt_TotalSalesCount6.OutputFormat");
            this.DggFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount6.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount6.Text = "12,345,678";
            this.DggFt_TotalSalesCount6.Top = 0.219F;
            this.DggFt_TotalSalesCount6.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount7
            // 
            this.DggFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.DggFt_TotalSalesCount7.Height = 0.156F;
            this.DggFt_TotalSalesCount7.Left = 6.6875F;
            this.DggFt_TotalSalesCount7.MultiLine = false;
            this.DggFt_TotalSalesCount7.Name = "DggFt_TotalSalesCount7";
            this.DggFt_TotalSalesCount7.OutputFormat = resources.GetString("DggFt_TotalSalesCount7.OutputFormat");
            this.DggFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount7.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount7.Text = "12,345,678";
            this.DggFt_TotalSalesCount7.Top = 0.219F;
            this.DggFt_TotalSalesCount7.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount8
            // 
            this.DggFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.DggFt_TotalSalesCount8.Height = 0.156F;
            this.DggFt_TotalSalesCount8.Left = 7.25F;
            this.DggFt_TotalSalesCount8.MultiLine = false;
            this.DggFt_TotalSalesCount8.Name = "DggFt_TotalSalesCount8";
            this.DggFt_TotalSalesCount8.OutputFormat = resources.GetString("DggFt_TotalSalesCount8.OutputFormat");
            this.DggFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount8.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount8.Text = "12,345,678";
            this.DggFt_TotalSalesCount8.Top = 0.219F;
            this.DggFt_TotalSalesCount8.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount9
            // 
            this.DggFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.DggFt_TotalSalesCount9.Height = 0.156F;
            this.DggFt_TotalSalesCount9.Left = 7.8125F;
            this.DggFt_TotalSalesCount9.MultiLine = false;
            this.DggFt_TotalSalesCount9.Name = "DggFt_TotalSalesCount9";
            this.DggFt_TotalSalesCount9.OutputFormat = resources.GetString("DggFt_TotalSalesCount9.OutputFormat");
            this.DggFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount9.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount9.Text = "12,345,678";
            this.DggFt_TotalSalesCount9.Top = 0.219F;
            this.DggFt_TotalSalesCount9.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount10
            // 
            this.DggFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.DggFt_TotalSalesCount10.Height = 0.156F;
            this.DggFt_TotalSalesCount10.Left = 8.375F;
            this.DggFt_TotalSalesCount10.MultiLine = false;
            this.DggFt_TotalSalesCount10.Name = "DggFt_TotalSalesCount10";
            this.DggFt_TotalSalesCount10.OutputFormat = resources.GetString("DggFt_TotalSalesCount10.OutputFormat");
            this.DggFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount10.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount10.Text = "12,345,678";
            this.DggFt_TotalSalesCount10.Top = 0.219F;
            this.DggFt_TotalSalesCount10.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount11
            // 
            this.DggFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.DggFt_TotalSalesCount11.Height = 0.156F;
            this.DggFt_TotalSalesCount11.Left = 8.9375F;
            this.DggFt_TotalSalesCount11.MultiLine = false;
            this.DggFt_TotalSalesCount11.Name = "DggFt_TotalSalesCount11";
            this.DggFt_TotalSalesCount11.OutputFormat = resources.GetString("DggFt_TotalSalesCount11.OutputFormat");
            this.DggFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount11.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount11.Text = "12,345,678";
            this.DggFt_TotalSalesCount11.Top = 0.219F;
            this.DggFt_TotalSalesCount11.Width = 0.55F;
            // 
            // DggFt_TotalSalesCount12
            // 
            this.DggFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.DggFt_TotalSalesCount12.Height = 0.156F;
            this.DggFt_TotalSalesCount12.Left = 9.5F;
            this.DggFt_TotalSalesCount12.MultiLine = false;
            this.DggFt_TotalSalesCount12.Name = "DggFt_TotalSalesCount12";
            this.DggFt_TotalSalesCount12.OutputFormat = resources.GetString("DggFt_TotalSalesCount12.OutputFormat");
            this.DggFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TotalSalesCount12.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TotalSalesCount12.Text = "12,345,678";
            this.DggFt_TotalSalesCount12.Top = 0.219F;
            this.DggFt_TotalSalesCount12.Width = 0.55F;
            // 
            // DggFt_TtlSalesMoney
            // 
            this.DggFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.DggFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DggFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.DggFt_TtlSalesMoney.Height = 0.156F;
            this.DggFt_TtlSalesMoney.Left = 10.0625F;
            this.DggFt_TtlSalesMoney.MultiLine = false;
            this.DggFt_TtlSalesMoney.Name = "DggFt_TtlSalesMoney";
            this.DggFt_TtlSalesMoney.OutputFormat = resources.GetString("DggFt_TtlSalesMoney.OutputFormat");
            this.DggFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TtlSalesMoney.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TtlSalesMoney.Text = "1,234,567,890";
            this.DggFt_TtlSalesMoney.Top = 0.0625F;
            this.DggFt_TtlSalesMoney.Width = 0.688F;
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
            this.DggFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.DggFt_TtlTotalSalesCount.Height = 0.156F;
            this.DggFt_TtlTotalSalesCount.Left = 10.0625F;
            this.DggFt_TtlTotalSalesCount.MultiLine = false;
            this.DggFt_TtlTotalSalesCount.Name = "DggFt_TtlTotalSalesCount";
            this.DggFt_TtlTotalSalesCount.OutputFormat = resources.GetString("DggFt_TtlTotalSalesCount.OutputFormat");
            this.DggFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DggFt_TtlTotalSalesCount.SummaryGroup = "BLGroupCodeHeader";
            this.DggFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DggFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DggFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.DggFt_TtlTotalSalesCount.Top = 0.219F;
            this.DggFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // GoodsLGroupHeader
            // 
            this.GoodsLGroupHeader.CanShrink = true;
            this.GoodsLGroupHeader.DataField = "GoodsLGroup";
            this.GoodsLGroupHeader.Height = 0F;
            this.GoodsLGroupHeader.Name = "GoodsLGroupHeader";
            // 
            // GoodsLGroupFooter
            // 
            this.GoodsLGroupFooter.CanShrink = true;
            this.GoodsLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line19,
            this.textBox34,
            this.LggFt_SalesMoney1,
            this.LggFt_GoodsLGroupCode,
            this.LggFt_GoodsLGroupName,
            this.LggFt_SalesMoney2,
            this.LggFt_SalesMoney3,
            this.LggFt_SalesMoney5,
            this.LggFt_SalesMoney4,
            this.LggFt_SalesMoney6,
            this.LggFt_SalesMoney7,
            this.LggFt_SalesMoney8,
            this.LggFt_SalesMoney9,
            this.LggFt_SalesMoney10,
            this.LggFt_SalesMoney11,
            this.LggFt_SalesMoney12,
            this.LggFt_TotalSalesCount1,
            this.LggFt_TotalSalesCount2,
            this.LggFt_TotalSalesCount3,
            this.LggFt_TotalSalesCount5,
            this.LggFt_TotalSalesCount4,
            this.LggFt_TotalSalesCount6,
            this.LggFt_TotalSalesCount7,
            this.LggFt_TotalSalesCount8,
            this.LggFt_TotalSalesCount9,
            this.LggFt_TotalSalesCount10,
            this.LggFt_TotalSalesCount11,
            this.LggFt_TotalSalesCount12,
            this.LggFt_TtlTotalSalesCount,
            this.LggFt_TtlSalesMoney});
            this.GoodsLGroupFooter.Height = 0.4F;
            this.GoodsLGroupFooter.KeepTogether = true;
            this.GoodsLGroupFooter.Name = "GoodsLGroupFooter";
            this.GoodsLGroupFooter.BeforePrint += new System.EventHandler(this.GoodsLGroupFooter_BeforePrint);
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
            this.textBox34.Left = 0.4375F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox34.Text = "商品大分類計";
            this.textBox34.Top = 0.0625F;
            this.textBox34.Width = 1F;
            // 
            // LggFt_SalesMoney1
            // 
            this.LggFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney1.DataField = "SalesMoney1";
            this.LggFt_SalesMoney1.Height = 0.156F;
            this.LggFt_SalesMoney1.Left = 3.3125F;
            this.LggFt_SalesMoney1.MultiLine = false;
            this.LggFt_SalesMoney1.Name = "LggFt_SalesMoney1";
            this.LggFt_SalesMoney1.OutputFormat = resources.GetString("LggFt_SalesMoney1.OutputFormat");
            this.LggFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney1.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney1.Text = "12,345,678";
            this.LggFt_SalesMoney1.Top = 0.0625F;
            this.LggFt_SalesMoney1.Width = 0.55F;
            // 
            // LggFt_GoodsLGroupCode
            // 
            this.LggFt_GoodsLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupCode.DataField = "GoodsLGroup";
            this.LggFt_GoodsLGroupCode.Height = 0.15625F;
            this.LggFt_GoodsLGroupCode.Left = 1.75F;
            this.LggFt_GoodsLGroupCode.MultiLine = false;
            this.LggFt_GoodsLGroupCode.Name = "LggFt_GoodsLGroupCode";
            this.LggFt_GoodsLGroupCode.OutputFormat = resources.GetString("LggFt_GoodsLGroupCode.OutputFormat");
            this.LggFt_GoodsLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_GoodsLGroupCode.Text = "12345";
            this.LggFt_GoodsLGroupCode.Top = 0.0625F;
            this.LggFt_GoodsLGroupCode.Width = 0.3125F;
            // 
            // LggFt_GoodsLGroupName
            // 
            this.LggFt_GoodsLGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_GoodsLGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_GoodsLGroupName.DataField = "GoodsLGroupName";
            this.LggFt_GoodsLGroupName.Height = 0.15625F;
            this.LggFt_GoodsLGroupName.Left = 2.125F;
            this.LggFt_GoodsLGroupName.MultiLine = false;
            this.LggFt_GoodsLGroupName.Name = "LggFt_GoodsLGroupName";
            this.LggFt_GoodsLGroupName.OutputFormat = resources.GetString("LggFt_GoodsLGroupName.OutputFormat");
            this.LggFt_GoodsLGroupName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.LggFt_GoodsLGroupName.Text = "あいうえおかきくけこ";
            this.LggFt_GoodsLGroupName.Top = 0.0625F;
            this.LggFt_GoodsLGroupName.Width = 1.1875F;
            // 
            // LggFt_SalesMoney2
            // 
            this.LggFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney2.DataField = "SalesMoney2";
            this.LggFt_SalesMoney2.Height = 0.156F;
            this.LggFt_SalesMoney2.Left = 3.875F;
            this.LggFt_SalesMoney2.MultiLine = false;
            this.LggFt_SalesMoney2.Name = "LggFt_SalesMoney2";
            this.LggFt_SalesMoney2.OutputFormat = resources.GetString("LggFt_SalesMoney2.OutputFormat");
            this.LggFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney2.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney2.Text = "12,345,678";
            this.LggFt_SalesMoney2.Top = 0.0625F;
            this.LggFt_SalesMoney2.Width = 0.55F;
            // 
            // LggFt_SalesMoney3
            // 
            this.LggFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney3.DataField = "SalesMoney3";
            this.LggFt_SalesMoney3.Height = 0.156F;
            this.LggFt_SalesMoney3.Left = 4.4375F;
            this.LggFt_SalesMoney3.MultiLine = false;
            this.LggFt_SalesMoney3.Name = "LggFt_SalesMoney3";
            this.LggFt_SalesMoney3.OutputFormat = resources.GetString("LggFt_SalesMoney3.OutputFormat");
            this.LggFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney3.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney3.Text = "12,345,678";
            this.LggFt_SalesMoney3.Top = 0.0625F;
            this.LggFt_SalesMoney3.Width = 0.55F;
            // 
            // LggFt_SalesMoney5
            // 
            this.LggFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney5.DataField = "SalesMoney5";
            this.LggFt_SalesMoney5.Height = 0.156F;
            this.LggFt_SalesMoney5.Left = 5.5625F;
            this.LggFt_SalesMoney5.MultiLine = false;
            this.LggFt_SalesMoney5.Name = "LggFt_SalesMoney5";
            this.LggFt_SalesMoney5.OutputFormat = resources.GetString("LggFt_SalesMoney5.OutputFormat");
            this.LggFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney5.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney5.Text = "12,345,678";
            this.LggFt_SalesMoney5.Top = 0.0625F;
            this.LggFt_SalesMoney5.Width = 0.55F;
            // 
            // LggFt_SalesMoney4
            // 
            this.LggFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney4.DataField = "SalesMoney4";
            this.LggFt_SalesMoney4.Height = 0.156F;
            this.LggFt_SalesMoney4.Left = 5F;
            this.LggFt_SalesMoney4.MultiLine = false;
            this.LggFt_SalesMoney4.Name = "LggFt_SalesMoney4";
            this.LggFt_SalesMoney4.OutputFormat = resources.GetString("LggFt_SalesMoney4.OutputFormat");
            this.LggFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney4.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney4.Text = "12,345,678";
            this.LggFt_SalesMoney4.Top = 0.0625F;
            this.LggFt_SalesMoney4.Width = 0.55F;
            // 
            // LggFt_SalesMoney6
            // 
            this.LggFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney6.DataField = "SalesMoney6";
            this.LggFt_SalesMoney6.Height = 0.156F;
            this.LggFt_SalesMoney6.Left = 6.125F;
            this.LggFt_SalesMoney6.MultiLine = false;
            this.LggFt_SalesMoney6.Name = "LggFt_SalesMoney6";
            this.LggFt_SalesMoney6.OutputFormat = resources.GetString("LggFt_SalesMoney6.OutputFormat");
            this.LggFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney6.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney6.Text = "12,345,678";
            this.LggFt_SalesMoney6.Top = 0.0625F;
            this.LggFt_SalesMoney6.Width = 0.55F;
            // 
            // LggFt_SalesMoney7
            // 
            this.LggFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney7.DataField = "SalesMoney7";
            this.LggFt_SalesMoney7.Height = 0.156F;
            this.LggFt_SalesMoney7.Left = 6.6875F;
            this.LggFt_SalesMoney7.MultiLine = false;
            this.LggFt_SalesMoney7.Name = "LggFt_SalesMoney7";
            this.LggFt_SalesMoney7.OutputFormat = resources.GetString("LggFt_SalesMoney7.OutputFormat");
            this.LggFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney7.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney7.Text = "12,345,678";
            this.LggFt_SalesMoney7.Top = 0.0625F;
            this.LggFt_SalesMoney7.Width = 0.55F;
            // 
            // LggFt_SalesMoney8
            // 
            this.LggFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney8.DataField = "SalesMoney8";
            this.LggFt_SalesMoney8.Height = 0.156F;
            this.LggFt_SalesMoney8.Left = 7.25F;
            this.LggFt_SalesMoney8.MultiLine = false;
            this.LggFt_SalesMoney8.Name = "LggFt_SalesMoney8";
            this.LggFt_SalesMoney8.OutputFormat = resources.GetString("LggFt_SalesMoney8.OutputFormat");
            this.LggFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney8.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney8.Text = "12,345,678";
            this.LggFt_SalesMoney8.Top = 0.0625F;
            this.LggFt_SalesMoney8.Width = 0.55F;
            // 
            // LggFt_SalesMoney9
            // 
            this.LggFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney9.DataField = "SalesMoney9";
            this.LggFt_SalesMoney9.Height = 0.156F;
            this.LggFt_SalesMoney9.Left = 7.8125F;
            this.LggFt_SalesMoney9.MultiLine = false;
            this.LggFt_SalesMoney9.Name = "LggFt_SalesMoney9";
            this.LggFt_SalesMoney9.OutputFormat = resources.GetString("LggFt_SalesMoney9.OutputFormat");
            this.LggFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney9.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney9.Text = "12,345,678";
            this.LggFt_SalesMoney9.Top = 0.0625F;
            this.LggFt_SalesMoney9.Width = 0.55F;
            // 
            // LggFt_SalesMoney10
            // 
            this.LggFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney10.DataField = "SalesMoney10";
            this.LggFt_SalesMoney10.Height = 0.156F;
            this.LggFt_SalesMoney10.Left = 8.375F;
            this.LggFt_SalesMoney10.MultiLine = false;
            this.LggFt_SalesMoney10.Name = "LggFt_SalesMoney10";
            this.LggFt_SalesMoney10.OutputFormat = resources.GetString("LggFt_SalesMoney10.OutputFormat");
            this.LggFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney10.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney10.Text = "12,345,678";
            this.LggFt_SalesMoney10.Top = 0.0625F;
            this.LggFt_SalesMoney10.Width = 0.55F;
            // 
            // LggFt_SalesMoney11
            // 
            this.LggFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney11.DataField = "SalesMoney11";
            this.LggFt_SalesMoney11.Height = 0.156F;
            this.LggFt_SalesMoney11.Left = 8.9375F;
            this.LggFt_SalesMoney11.MultiLine = false;
            this.LggFt_SalesMoney11.Name = "LggFt_SalesMoney11";
            this.LggFt_SalesMoney11.OutputFormat = resources.GetString("LggFt_SalesMoney11.OutputFormat");
            this.LggFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney11.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney11.Text = "12,345,678";
            this.LggFt_SalesMoney11.Top = 0.0625F;
            this.LggFt_SalesMoney11.Width = 0.55F;
            // 
            // LggFt_SalesMoney12
            // 
            this.LggFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_SalesMoney12.DataField = "SalesMoney12";
            this.LggFt_SalesMoney12.Height = 0.156F;
            this.LggFt_SalesMoney12.Left = 9.5F;
            this.LggFt_SalesMoney12.MultiLine = false;
            this.LggFt_SalesMoney12.Name = "LggFt_SalesMoney12";
            this.LggFt_SalesMoney12.OutputFormat = resources.GetString("LggFt_SalesMoney12.OutputFormat");
            this.LggFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_SalesMoney12.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_SalesMoney12.Text = "12,345,678";
            this.LggFt_SalesMoney12.Top = 0.0625F;
            this.LggFt_SalesMoney12.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount1
            // 
            this.LggFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.LggFt_TotalSalesCount1.Height = 0.156F;
            this.LggFt_TotalSalesCount1.Left = 3.3125F;
            this.LggFt_TotalSalesCount1.MultiLine = false;
            this.LggFt_TotalSalesCount1.Name = "LggFt_TotalSalesCount1";
            this.LggFt_TotalSalesCount1.OutputFormat = resources.GetString("LggFt_TotalSalesCount1.OutputFormat");
            this.LggFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount1.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount1.Text = "12,345,678";
            this.LggFt_TotalSalesCount1.Top = 0.219F;
            this.LggFt_TotalSalesCount1.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount2
            // 
            this.LggFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.LggFt_TotalSalesCount2.Height = 0.156F;
            this.LggFt_TotalSalesCount2.Left = 3.875F;
            this.LggFt_TotalSalesCount2.MultiLine = false;
            this.LggFt_TotalSalesCount2.Name = "LggFt_TotalSalesCount2";
            this.LggFt_TotalSalesCount2.OutputFormat = resources.GetString("LggFt_TotalSalesCount2.OutputFormat");
            this.LggFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount2.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount2.Text = "12,345,678";
            this.LggFt_TotalSalesCount2.Top = 0.219F;
            this.LggFt_TotalSalesCount2.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount3
            // 
            this.LggFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.LggFt_TotalSalesCount3.Height = 0.156F;
            this.LggFt_TotalSalesCount3.Left = 4.4375F;
            this.LggFt_TotalSalesCount3.MultiLine = false;
            this.LggFt_TotalSalesCount3.Name = "LggFt_TotalSalesCount3";
            this.LggFt_TotalSalesCount3.OutputFormat = resources.GetString("LggFt_TotalSalesCount3.OutputFormat");
            this.LggFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount3.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount3.Text = "12,345,678";
            this.LggFt_TotalSalesCount3.Top = 0.219F;
            this.LggFt_TotalSalesCount3.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount5
            // 
            this.LggFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.LggFt_TotalSalesCount5.Height = 0.156F;
            this.LggFt_TotalSalesCount5.Left = 5.5625F;
            this.LggFt_TotalSalesCount5.MultiLine = false;
            this.LggFt_TotalSalesCount5.Name = "LggFt_TotalSalesCount5";
            this.LggFt_TotalSalesCount5.OutputFormat = resources.GetString("LggFt_TotalSalesCount5.OutputFormat");
            this.LggFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount5.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount5.Text = "12,345,678";
            this.LggFt_TotalSalesCount5.Top = 0.219F;
            this.LggFt_TotalSalesCount5.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount4
            // 
            this.LggFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.LggFt_TotalSalesCount4.Height = 0.156F;
            this.LggFt_TotalSalesCount4.Left = 5F;
            this.LggFt_TotalSalesCount4.MultiLine = false;
            this.LggFt_TotalSalesCount4.Name = "LggFt_TotalSalesCount4";
            this.LggFt_TotalSalesCount4.OutputFormat = resources.GetString("LggFt_TotalSalesCount4.OutputFormat");
            this.LggFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount4.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount4.Text = "12,345,678";
            this.LggFt_TotalSalesCount4.Top = 0.219F;
            this.LggFt_TotalSalesCount4.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount6
            // 
            this.LggFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.LggFt_TotalSalesCount6.Height = 0.156F;
            this.LggFt_TotalSalesCount6.Left = 6.125F;
            this.LggFt_TotalSalesCount6.MultiLine = false;
            this.LggFt_TotalSalesCount6.Name = "LggFt_TotalSalesCount6";
            this.LggFt_TotalSalesCount6.OutputFormat = resources.GetString("LggFt_TotalSalesCount6.OutputFormat");
            this.LggFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount6.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount6.Text = "12,345,678";
            this.LggFt_TotalSalesCount6.Top = 0.219F;
            this.LggFt_TotalSalesCount6.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount7
            // 
            this.LggFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.LggFt_TotalSalesCount7.Height = 0.156F;
            this.LggFt_TotalSalesCount7.Left = 6.6875F;
            this.LggFt_TotalSalesCount7.MultiLine = false;
            this.LggFt_TotalSalesCount7.Name = "LggFt_TotalSalesCount7";
            this.LggFt_TotalSalesCount7.OutputFormat = resources.GetString("LggFt_TotalSalesCount7.OutputFormat");
            this.LggFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount7.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount7.Text = "12,345,678";
            this.LggFt_TotalSalesCount7.Top = 0.219F;
            this.LggFt_TotalSalesCount7.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount8
            // 
            this.LggFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.LggFt_TotalSalesCount8.Height = 0.156F;
            this.LggFt_TotalSalesCount8.Left = 7.25F;
            this.LggFt_TotalSalesCount8.MultiLine = false;
            this.LggFt_TotalSalesCount8.Name = "LggFt_TotalSalesCount8";
            this.LggFt_TotalSalesCount8.OutputFormat = resources.GetString("LggFt_TotalSalesCount8.OutputFormat");
            this.LggFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount8.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount8.Text = "12,345,678";
            this.LggFt_TotalSalesCount8.Top = 0.219F;
            this.LggFt_TotalSalesCount8.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount9
            // 
            this.LggFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.LggFt_TotalSalesCount9.Height = 0.156F;
            this.LggFt_TotalSalesCount9.Left = 7.8125F;
            this.LggFt_TotalSalesCount9.MultiLine = false;
            this.LggFt_TotalSalesCount9.Name = "LggFt_TotalSalesCount9";
            this.LggFt_TotalSalesCount9.OutputFormat = resources.GetString("LggFt_TotalSalesCount9.OutputFormat");
            this.LggFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount9.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount9.Text = "12,345,678";
            this.LggFt_TotalSalesCount9.Top = 0.219F;
            this.LggFt_TotalSalesCount9.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount10
            // 
            this.LggFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.LggFt_TotalSalesCount10.Height = 0.156F;
            this.LggFt_TotalSalesCount10.Left = 8.375F;
            this.LggFt_TotalSalesCount10.MultiLine = false;
            this.LggFt_TotalSalesCount10.Name = "LggFt_TotalSalesCount10";
            this.LggFt_TotalSalesCount10.OutputFormat = resources.GetString("LggFt_TotalSalesCount10.OutputFormat");
            this.LggFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount10.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount10.Text = "12,345,678";
            this.LggFt_TotalSalesCount10.Top = 0.219F;
            this.LggFt_TotalSalesCount10.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount11
            // 
            this.LggFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.LggFt_TotalSalesCount11.Height = 0.156F;
            this.LggFt_TotalSalesCount11.Left = 8.9375F;
            this.LggFt_TotalSalesCount11.MultiLine = false;
            this.LggFt_TotalSalesCount11.Name = "LggFt_TotalSalesCount11";
            this.LggFt_TotalSalesCount11.OutputFormat = resources.GetString("LggFt_TotalSalesCount11.OutputFormat");
            this.LggFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount11.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount11.Text = "12,345,678";
            this.LggFt_TotalSalesCount11.Top = 0.219F;
            this.LggFt_TotalSalesCount11.Width = 0.55F;
            // 
            // LggFt_TotalSalesCount12
            // 
            this.LggFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.LggFt_TotalSalesCount12.Height = 0.156F;
            this.LggFt_TotalSalesCount12.Left = 9.5F;
            this.LggFt_TotalSalesCount12.MultiLine = false;
            this.LggFt_TotalSalesCount12.Name = "LggFt_TotalSalesCount12";
            this.LggFt_TotalSalesCount12.OutputFormat = resources.GetString("LggFt_TotalSalesCount12.OutputFormat");
            this.LggFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TotalSalesCount12.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TotalSalesCount12.Text = "12,345,678";
            this.LggFt_TotalSalesCount12.Top = 0.219F;
            this.LggFt_TotalSalesCount12.Width = 0.55F;
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
            this.LggFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.LggFt_TtlTotalSalesCount.Height = 0.156F;
            this.LggFt_TtlTotalSalesCount.Left = 10.0625F;
            this.LggFt_TtlTotalSalesCount.MultiLine = false;
            this.LggFt_TtlTotalSalesCount.Name = "LggFt_TtlTotalSalesCount";
            this.LggFt_TtlTotalSalesCount.OutputFormat = resources.GetString("LggFt_TtlTotalSalesCount.OutputFormat");
            this.LggFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TtlTotalSalesCount.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.LggFt_TtlTotalSalesCount.Top = 0.219F;
            this.LggFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // LggFt_TtlSalesMoney
            // 
            this.LggFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.LggFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LggFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.LggFt_TtlSalesMoney.Height = 0.156F;
            this.LggFt_TtlSalesMoney.Left = 10.0625F;
            this.LggFt_TtlSalesMoney.MultiLine = false;
            this.LggFt_TtlSalesMoney.Name = "LggFt_TtlSalesMoney";
            this.LggFt_TtlSalesMoney.OutputFormat = resources.GetString("LggFt_TtlSalesMoney.OutputFormat");
            this.LggFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.LggFt_TtlSalesMoney.SummaryGroup = "GoodsLGroupHeader";
            this.LggFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LggFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LggFt_TtlSalesMoney.Text = "1,234,567,890";
            this.LggFt_TtlSalesMoney.Top = 0.0625F;
            this.LggFt_TtlSalesMoney.Width = 0.688F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.CanShrink = true;
            this.MakerHeader.DataField = "GoodsMakerCd";
            this.MakerHeader.Height = 0F;
            this.MakerHeader.Name = "MakerHeader";
            // 
            // MakerFooter
            // 
            this.MakerFooter.CanShrink = true;
            this.MakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line20,
            this.textBox35,
            this.MakFt_SalesMoney1,
            this.MakFt_GoodsMakerCd,
            this.MakFt_MakerName,
            this.MakFt_SalesMoney2,
            this.MakFt_SalesMoney4,
            this.MakFt_SalesMoney3,
            this.MakFt_SalesMoney5,
            this.MakFt_SalesMoney6,
            this.MakFt_SalesMoney7,
            this.MakFt_SalesMoney8,
            this.MakFt_SalesMoney9,
            this.MakFt_SalesMoney10,
            this.MakFt_SalesMoney11,
            this.MakFt_SalesMoney12,
            this.MakFt_TotalSalesCount1,
            this.MakFt_TotalSalesCount2,
            this.MakFt_TotalSalesCount4,
            this.MakFt_TotalSalesCount3,
            this.MakFt_TotalSalesCount5,
            this.MakFt_TotalSalesCount6,
            this.MakFt_TotalSalesCount7,
            this.MakFt_TotalSalesCount8,
            this.MakFt_TotalSalesCount9,
            this.MakFt_TotalSalesCount10,
            this.MakFt_TotalSalesCount11,
            this.MakFt_TotalSalesCount12,
            this.MakFt_TtlTotalSalesCount,
            this.MakFt_TtlSalesMoney});
            this.MakerFooter.Height = 0.40625F;
            this.MakerFooter.KeepTogether = true;
            this.MakerFooter.Name = "MakerFooter";
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
            this.textBox35.Left = 0.4375F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox35.Text = "メーカー計";
            this.textBox35.Top = 0.0625F;
            this.textBox35.Width = 0.84375F;
            // 
            // MakFt_SalesMoney1
            // 
            this.MakFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney1.DataField = "SalesMoney1";
            this.MakFt_SalesMoney1.Height = 0.156F;
            this.MakFt_SalesMoney1.Left = 3.3125F;
            this.MakFt_SalesMoney1.MultiLine = false;
            this.MakFt_SalesMoney1.Name = "MakFt_SalesMoney1";
            this.MakFt_SalesMoney1.OutputFormat = resources.GetString("MakFt_SalesMoney1.OutputFormat");
            this.MakFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney1.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney1.Text = "12,345,678";
            this.MakFt_SalesMoney1.Top = 0.0625F;
            this.MakFt_SalesMoney1.Width = 0.55F;
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
            this.MakFt_GoodsMakerCd.Height = 0.156F;
            this.MakFt_GoodsMakerCd.Left = 1.75F;
            this.MakFt_GoodsMakerCd.MultiLine = false;
            this.MakFt_GoodsMakerCd.Name = "MakFt_GoodsMakerCd";
            this.MakFt_GoodsMakerCd.OutputFormat = resources.GetString("MakFt_GoodsMakerCd.OutputFormat");
            this.MakFt_GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GoodsMakerCd.Text = "1234";
            this.MakFt_GoodsMakerCd.Top = 0.0625F;
            this.MakFt_GoodsMakerCd.Width = 0.35F;
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
            this.MakFt_MakerName.Left = 2.125F;
            this.MakFt_MakerName.MultiLine = false;
            this.MakFt_MakerName.Name = "MakFt_MakerName";
            this.MakFt_MakerName.OutputFormat = resources.GetString("MakFt_MakerName.OutputFormat");
            this.MakFt_MakerName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.MakFt_MakerName.Text = "あいうえおかきくけこ";
            this.MakFt_MakerName.Top = 0.0625F;
            this.MakFt_MakerName.Width = 1.1875F;
            // 
            // MakFt_SalesMoney2
            // 
            this.MakFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney2.DataField = "SalesMoney2";
            this.MakFt_SalesMoney2.Height = 0.156F;
            this.MakFt_SalesMoney2.Left = 3.875F;
            this.MakFt_SalesMoney2.MultiLine = false;
            this.MakFt_SalesMoney2.Name = "MakFt_SalesMoney2";
            this.MakFt_SalesMoney2.OutputFormat = resources.GetString("MakFt_SalesMoney2.OutputFormat");
            this.MakFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney2.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney2.Text = "12,345,678";
            this.MakFt_SalesMoney2.Top = 0.0625F;
            this.MakFt_SalesMoney2.Width = 0.55F;
            // 
            // MakFt_SalesMoney4
            // 
            this.MakFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney4.DataField = "SalesMoney4";
            this.MakFt_SalesMoney4.Height = 0.156F;
            this.MakFt_SalesMoney4.Left = 5F;
            this.MakFt_SalesMoney4.MultiLine = false;
            this.MakFt_SalesMoney4.Name = "MakFt_SalesMoney4";
            this.MakFt_SalesMoney4.OutputFormat = resources.GetString("MakFt_SalesMoney4.OutputFormat");
            this.MakFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney4.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney4.Text = "12,345,678";
            this.MakFt_SalesMoney4.Top = 0.0625F;
            this.MakFt_SalesMoney4.Width = 0.55F;
            // 
            // MakFt_SalesMoney3
            // 
            this.MakFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney3.DataField = "SalesMoney3";
            this.MakFt_SalesMoney3.Height = 0.156F;
            this.MakFt_SalesMoney3.Left = 4.4375F;
            this.MakFt_SalesMoney3.MultiLine = false;
            this.MakFt_SalesMoney3.Name = "MakFt_SalesMoney3";
            this.MakFt_SalesMoney3.OutputFormat = resources.GetString("MakFt_SalesMoney3.OutputFormat");
            this.MakFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney3.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney3.Text = "12,345,678";
            this.MakFt_SalesMoney3.Top = 0.0625F;
            this.MakFt_SalesMoney3.Width = 0.55F;
            // 
            // MakFt_SalesMoney5
            // 
            this.MakFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney5.DataField = "SalesMoney5";
            this.MakFt_SalesMoney5.Height = 0.156F;
            this.MakFt_SalesMoney5.Left = 5.5625F;
            this.MakFt_SalesMoney5.MultiLine = false;
            this.MakFt_SalesMoney5.Name = "MakFt_SalesMoney5";
            this.MakFt_SalesMoney5.OutputFormat = resources.GetString("MakFt_SalesMoney5.OutputFormat");
            this.MakFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney5.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney5.Text = "12,345,678";
            this.MakFt_SalesMoney5.Top = 0.0625F;
            this.MakFt_SalesMoney5.Width = 0.55F;
            // 
            // MakFt_SalesMoney6
            // 
            this.MakFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney6.DataField = "SalesMoney6";
            this.MakFt_SalesMoney6.Height = 0.156F;
            this.MakFt_SalesMoney6.Left = 6.125F;
            this.MakFt_SalesMoney6.MultiLine = false;
            this.MakFt_SalesMoney6.Name = "MakFt_SalesMoney6";
            this.MakFt_SalesMoney6.OutputFormat = resources.GetString("MakFt_SalesMoney6.OutputFormat");
            this.MakFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney6.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney6.Text = "12,345,678";
            this.MakFt_SalesMoney6.Top = 0.0625F;
            this.MakFt_SalesMoney6.Width = 0.55F;
            // 
            // MakFt_SalesMoney7
            // 
            this.MakFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney7.DataField = "SalesMoney7";
            this.MakFt_SalesMoney7.Height = 0.156F;
            this.MakFt_SalesMoney7.Left = 6.6875F;
            this.MakFt_SalesMoney7.MultiLine = false;
            this.MakFt_SalesMoney7.Name = "MakFt_SalesMoney7";
            this.MakFt_SalesMoney7.OutputFormat = resources.GetString("MakFt_SalesMoney7.OutputFormat");
            this.MakFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney7.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney7.Text = "12,345,678";
            this.MakFt_SalesMoney7.Top = 0.0625F;
            this.MakFt_SalesMoney7.Width = 0.55F;
            // 
            // MakFt_SalesMoney8
            // 
            this.MakFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney8.DataField = "SalesMoney8";
            this.MakFt_SalesMoney8.Height = 0.156F;
            this.MakFt_SalesMoney8.Left = 7.25F;
            this.MakFt_SalesMoney8.MultiLine = false;
            this.MakFt_SalesMoney8.Name = "MakFt_SalesMoney8";
            this.MakFt_SalesMoney8.OutputFormat = resources.GetString("MakFt_SalesMoney8.OutputFormat");
            this.MakFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney8.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney8.Text = "12,345,678";
            this.MakFt_SalesMoney8.Top = 0.0625F;
            this.MakFt_SalesMoney8.Width = 0.55F;
            // 
            // MakFt_SalesMoney9
            // 
            this.MakFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney9.DataField = "SalesMoney9";
            this.MakFt_SalesMoney9.Height = 0.156F;
            this.MakFt_SalesMoney9.Left = 7.8125F;
            this.MakFt_SalesMoney9.MultiLine = false;
            this.MakFt_SalesMoney9.Name = "MakFt_SalesMoney9";
            this.MakFt_SalesMoney9.OutputFormat = resources.GetString("MakFt_SalesMoney9.OutputFormat");
            this.MakFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney9.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney9.Text = "12,345,678";
            this.MakFt_SalesMoney9.Top = 0.0625F;
            this.MakFt_SalesMoney9.Width = 0.55F;
            // 
            // MakFt_SalesMoney10
            // 
            this.MakFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney10.DataField = "SalesMoney10";
            this.MakFt_SalesMoney10.Height = 0.156F;
            this.MakFt_SalesMoney10.Left = 8.375F;
            this.MakFt_SalesMoney10.MultiLine = false;
            this.MakFt_SalesMoney10.Name = "MakFt_SalesMoney10";
            this.MakFt_SalesMoney10.OutputFormat = resources.GetString("MakFt_SalesMoney10.OutputFormat");
            this.MakFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney10.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney10.Text = "12,345,678";
            this.MakFt_SalesMoney10.Top = 0.0625F;
            this.MakFt_SalesMoney10.Width = 0.55F;
            // 
            // MakFt_SalesMoney11
            // 
            this.MakFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney11.DataField = "SalesMoney11";
            this.MakFt_SalesMoney11.Height = 0.156F;
            this.MakFt_SalesMoney11.Left = 8.9375F;
            this.MakFt_SalesMoney11.MultiLine = false;
            this.MakFt_SalesMoney11.Name = "MakFt_SalesMoney11";
            this.MakFt_SalesMoney11.OutputFormat = resources.GetString("MakFt_SalesMoney11.OutputFormat");
            this.MakFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney11.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney11.Text = "12,345,678";
            this.MakFt_SalesMoney11.Top = 0.0625F;
            this.MakFt_SalesMoney11.Width = 0.55F;
            // 
            // MakFt_SalesMoney12
            // 
            this.MakFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_SalesMoney12.DataField = "SalesMoney12";
            this.MakFt_SalesMoney12.Height = 0.156F;
            this.MakFt_SalesMoney12.Left = 9.5F;
            this.MakFt_SalesMoney12.MultiLine = false;
            this.MakFt_SalesMoney12.Name = "MakFt_SalesMoney12";
            this.MakFt_SalesMoney12.OutputFormat = resources.GetString("MakFt_SalesMoney12.OutputFormat");
            this.MakFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_SalesMoney12.SummaryGroup = "MakerHeader";
            this.MakFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_SalesMoney12.Text = "12,345,678";
            this.MakFt_SalesMoney12.Top = 0.0625F;
            this.MakFt_SalesMoney12.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount1
            // 
            this.MakFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.MakFt_TotalSalesCount1.Height = 0.156F;
            this.MakFt_TotalSalesCount1.Left = 3.3125F;
            this.MakFt_TotalSalesCount1.MultiLine = false;
            this.MakFt_TotalSalesCount1.Name = "MakFt_TotalSalesCount1";
            this.MakFt_TotalSalesCount1.OutputFormat = resources.GetString("MakFt_TotalSalesCount1.OutputFormat");
            this.MakFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount1.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount1.Text = "12,345,678";
            this.MakFt_TotalSalesCount1.Top = 0.219F;
            this.MakFt_TotalSalesCount1.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount2
            // 
            this.MakFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.MakFt_TotalSalesCount2.Height = 0.156F;
            this.MakFt_TotalSalesCount2.Left = 3.875F;
            this.MakFt_TotalSalesCount2.MultiLine = false;
            this.MakFt_TotalSalesCount2.Name = "MakFt_TotalSalesCount2";
            this.MakFt_TotalSalesCount2.OutputFormat = resources.GetString("MakFt_TotalSalesCount2.OutputFormat");
            this.MakFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount2.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount2.Text = "12,345,678";
            this.MakFt_TotalSalesCount2.Top = 0.219F;
            this.MakFt_TotalSalesCount2.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount4
            // 
            this.MakFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.MakFt_TotalSalesCount4.Height = 0.156F;
            this.MakFt_TotalSalesCount4.Left = 5F;
            this.MakFt_TotalSalesCount4.MultiLine = false;
            this.MakFt_TotalSalesCount4.Name = "MakFt_TotalSalesCount4";
            this.MakFt_TotalSalesCount4.OutputFormat = resources.GetString("MakFt_TotalSalesCount4.OutputFormat");
            this.MakFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount4.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount4.Text = "12,345,678";
            this.MakFt_TotalSalesCount4.Top = 0.219F;
            this.MakFt_TotalSalesCount4.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount3
            // 
            this.MakFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.MakFt_TotalSalesCount3.Height = 0.156F;
            this.MakFt_TotalSalesCount3.Left = 4.4375F;
            this.MakFt_TotalSalesCount3.MultiLine = false;
            this.MakFt_TotalSalesCount3.Name = "MakFt_TotalSalesCount3";
            this.MakFt_TotalSalesCount3.OutputFormat = resources.GetString("MakFt_TotalSalesCount3.OutputFormat");
            this.MakFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount3.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount3.Text = "12,345,678";
            this.MakFt_TotalSalesCount3.Top = 0.219F;
            this.MakFt_TotalSalesCount3.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount5
            // 
            this.MakFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.MakFt_TotalSalesCount5.Height = 0.156F;
            this.MakFt_TotalSalesCount5.Left = 5.5625F;
            this.MakFt_TotalSalesCount5.MultiLine = false;
            this.MakFt_TotalSalesCount5.Name = "MakFt_TotalSalesCount5";
            this.MakFt_TotalSalesCount5.OutputFormat = resources.GetString("MakFt_TotalSalesCount5.OutputFormat");
            this.MakFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount5.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount5.Text = "12,345,678";
            this.MakFt_TotalSalesCount5.Top = 0.219F;
            this.MakFt_TotalSalesCount5.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount6
            // 
            this.MakFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.MakFt_TotalSalesCount6.Height = 0.156F;
            this.MakFt_TotalSalesCount6.Left = 6.125F;
            this.MakFt_TotalSalesCount6.MultiLine = false;
            this.MakFt_TotalSalesCount6.Name = "MakFt_TotalSalesCount6";
            this.MakFt_TotalSalesCount6.OutputFormat = resources.GetString("MakFt_TotalSalesCount6.OutputFormat");
            this.MakFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount6.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount6.Text = "12,345,678";
            this.MakFt_TotalSalesCount6.Top = 0.219F;
            this.MakFt_TotalSalesCount6.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount7
            // 
            this.MakFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.MakFt_TotalSalesCount7.Height = 0.156F;
            this.MakFt_TotalSalesCount7.Left = 6.6875F;
            this.MakFt_TotalSalesCount7.MultiLine = false;
            this.MakFt_TotalSalesCount7.Name = "MakFt_TotalSalesCount7";
            this.MakFt_TotalSalesCount7.OutputFormat = resources.GetString("MakFt_TotalSalesCount7.OutputFormat");
            this.MakFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount7.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount7.Text = "12,345,678";
            this.MakFt_TotalSalesCount7.Top = 0.219F;
            this.MakFt_TotalSalesCount7.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount8
            // 
            this.MakFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.MakFt_TotalSalesCount8.Height = 0.156F;
            this.MakFt_TotalSalesCount8.Left = 7.25F;
            this.MakFt_TotalSalesCount8.MultiLine = false;
            this.MakFt_TotalSalesCount8.Name = "MakFt_TotalSalesCount8";
            this.MakFt_TotalSalesCount8.OutputFormat = resources.GetString("MakFt_TotalSalesCount8.OutputFormat");
            this.MakFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount8.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount8.Text = "12,345,678";
            this.MakFt_TotalSalesCount8.Top = 0.219F;
            this.MakFt_TotalSalesCount8.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount9
            // 
            this.MakFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.MakFt_TotalSalesCount9.Height = 0.156F;
            this.MakFt_TotalSalesCount9.Left = 7.8125F;
            this.MakFt_TotalSalesCount9.MultiLine = false;
            this.MakFt_TotalSalesCount9.Name = "MakFt_TotalSalesCount9";
            this.MakFt_TotalSalesCount9.OutputFormat = resources.GetString("MakFt_TotalSalesCount9.OutputFormat");
            this.MakFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount9.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount9.Text = "12,345,678";
            this.MakFt_TotalSalesCount9.Top = 0.219F;
            this.MakFt_TotalSalesCount9.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount10
            // 
            this.MakFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.MakFt_TotalSalesCount10.Height = 0.156F;
            this.MakFt_TotalSalesCount10.Left = 8.375F;
            this.MakFt_TotalSalesCount10.MultiLine = false;
            this.MakFt_TotalSalesCount10.Name = "MakFt_TotalSalesCount10";
            this.MakFt_TotalSalesCount10.OutputFormat = resources.GetString("MakFt_TotalSalesCount10.OutputFormat");
            this.MakFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount10.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount10.Text = "12,345,678";
            this.MakFt_TotalSalesCount10.Top = 0.219F;
            this.MakFt_TotalSalesCount10.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount11
            // 
            this.MakFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.MakFt_TotalSalesCount11.Height = 0.156F;
            this.MakFt_TotalSalesCount11.Left = 8.9375F;
            this.MakFt_TotalSalesCount11.MultiLine = false;
            this.MakFt_TotalSalesCount11.Name = "MakFt_TotalSalesCount11";
            this.MakFt_TotalSalesCount11.OutputFormat = resources.GetString("MakFt_TotalSalesCount11.OutputFormat");
            this.MakFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount11.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount11.Text = "12,345,678";
            this.MakFt_TotalSalesCount11.Top = 0.219F;
            this.MakFt_TotalSalesCount11.Width = 0.55F;
            // 
            // MakFt_TotalSalesCount12
            // 
            this.MakFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.MakFt_TotalSalesCount12.Height = 0.156F;
            this.MakFt_TotalSalesCount12.Left = 9.5F;
            this.MakFt_TotalSalesCount12.MultiLine = false;
            this.MakFt_TotalSalesCount12.Name = "MakFt_TotalSalesCount12";
            this.MakFt_TotalSalesCount12.OutputFormat = resources.GetString("MakFt_TotalSalesCount12.OutputFormat");
            this.MakFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalSalesCount12.SummaryGroup = "MakerHeader";
            this.MakFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalSalesCount12.Text = "12,345,678";
            this.MakFt_TotalSalesCount12.Top = 0.219F;
            this.MakFt_TotalSalesCount12.Width = 0.55F;
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
            this.MakFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.MakFt_TtlTotalSalesCount.Height = 0.156F;
            this.MakFt_TtlTotalSalesCount.Left = 10.0625F;
            this.MakFt_TtlTotalSalesCount.MultiLine = false;
            this.MakFt_TtlTotalSalesCount.Name = "MakFt_TtlTotalSalesCount";
            this.MakFt_TtlTotalSalesCount.OutputFormat = resources.GetString("MakFt_TtlTotalSalesCount.OutputFormat");
            this.MakFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TtlTotalSalesCount.SummaryGroup = "MakerHeader";
            this.MakFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.MakFt_TtlTotalSalesCount.Top = 0.219F;
            this.MakFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // MakFt_TtlSalesMoney
            // 
            this.MakFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.MakFt_TtlSalesMoney.Height = 0.156F;
            this.MakFt_TtlSalesMoney.Left = 10.0625F;
            this.MakFt_TtlSalesMoney.MultiLine = false;
            this.MakFt_TtlSalesMoney.Name = "MakFt_TtlSalesMoney";
            this.MakFt_TtlSalesMoney.OutputFormat = resources.GetString("MakFt_TtlSalesMoney.OutputFormat");
            this.MakFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TtlSalesMoney.SummaryGroup = "MakerHeader";
            this.MakFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TtlSalesMoney.Text = "1,234,567,890";
            this.MakFt_TtlSalesMoney.Top = 0.0625F;
            this.MakFt_TtlSalesMoney.Width = 0.688F;
            // 
            // EmployeeHeader
            // 
            this.EmployeeHeader.CanShrink = true;
            this.EmployeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.EmpHd_AddUpSecCode,
            this.EmpHd_SectionGuideNm,
            this.EmpHd_SectionTitle,
            this.EmpHd_EmployeeCode,
            this.EmpHd_EmployeeName,
            this.EmpHd_EmployeeTitle,
            this.line5});
            this.EmployeeHeader.DataField = "EmployeeCode";
            this.EmployeeHeader.Height = 0.2395833F;
            this.EmployeeHeader.Name = "EmployeeHeader";
            this.EmployeeHeader.BeforePrint += new System.EventHandler(this.EmployeeHeader_BeforePrint);
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
            this.EmpHd_AddUpSecCode.Left = 0.5F;
            this.EmpHd_AddUpSecCode.MultiLine = false;
            this.EmpHd_AddUpSecCode.Name = "EmpHd_AddUpSecCode";
            this.EmpHd_AddUpSecCode.OutputFormat = resources.GetString("EmpHd_AddUpSecCode.OutputFormat");
            this.EmpHd_AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.EmpHd_AddUpSecCode.Text = "12";
            this.EmpHd_AddUpSecCode.Top = 0.03125F;
            this.EmpHd_AddUpSecCode.Width = 0.2F;
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
            this.EmpHd_SectionGuideNm.Left = 0.6875F;
            this.EmpHd_SectionGuideNm.MultiLine = false;
            this.EmpHd_SectionGuideNm.Name = "EmpHd_SectionGuideNm";
            this.EmpHd_SectionGuideNm.OutputFormat = resources.GetString("EmpHd_SectionGuideNm.OutputFormat");
            this.EmpHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.EmpHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.EmpHd_SectionGuideNm.Top = 0.03125F;
            this.EmpHd_SectionGuideNm.Width = 1.1875F;
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
            this.EmpHd_SectionTitle.HyperLink = "";
            this.EmpHd_SectionTitle.Left = 0.1875F;
            this.EmpHd_SectionTitle.MultiLine = false;
            this.EmpHd_SectionTitle.Name = "EmpHd_SectionTitle";
            this.EmpHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.EmpHd_SectionTitle.Text = "拠点";
            this.EmpHd_SectionTitle.Top = 0.03125F;
            this.EmpHd_SectionTitle.Width = 0.313F;
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
            this.EmpHd_EmployeeCode.Left = 2.4375F;
            this.EmpHd_EmployeeCode.MultiLine = false;
            this.EmpHd_EmployeeCode.Name = "EmpHd_EmployeeCode";
            this.EmpHd_EmployeeCode.OutputFormat = resources.GetString("EmpHd_EmployeeCode.OutputFormat");
            this.EmpHd_EmployeeCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.EmpHd_EmployeeCode.Text = "1234";
            this.EmpHd_EmployeeCode.Top = 0.03125F;
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
            this.EmpHd_EmployeeName.Height = 0.156F;
            this.EmpHd_EmployeeName.Left = 2.75F;
            this.EmpHd_EmployeeName.MultiLine = false;
            this.EmpHd_EmployeeName.Name = "EmpHd_EmployeeName";
            this.EmpHd_EmployeeName.OutputFormat = resources.GetString("EmpHd_EmployeeName.OutputFormat");
            this.EmpHd_EmployeeName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.EmpHd_EmployeeName.Text = "あいうえおかきくけこ";
            this.EmpHd_EmployeeName.Top = 0.03125F;
            this.EmpHd_EmployeeName.Width = 1.2F;
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
            this.EmpHd_EmployeeTitle.HyperLink = "";
            this.EmpHd_EmployeeTitle.Left = 2.0625F;
            this.EmpHd_EmployeeTitle.MultiLine = false;
            this.EmpHd_EmployeeTitle.Name = "EmpHd_EmployeeTitle";
            this.EmpHd_EmployeeTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.EmpHd_EmployeeTitle.Text = "担当者";
            this.EmpHd_EmployeeTitle.Top = 0.03125F;
            this.EmpHd_EmployeeTitle.Width = 0.4F;
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
            // EmployeeFooter
            // 
            this.EmployeeFooter.CanShrink = true;
            this.EmployeeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line21,
            this.textBox36,
            this.EmpFt_SalesMoney1,
            this.EmpFt_SalesMoney2,
            this.EmpFt_SalesMoney3,
            this.EmpFt_SalesMoney4,
            this.EmpFt_SalesMoney5,
            this.EmpFt_SalesMoney6,
            this.EmpFt_SalesMoney7,
            this.EmpFt_SalesMoney8,
            this.EmpFt_SalesMoney9,
            this.EmpFt_SalesMoney10,
            this.EmpFt_SalesMoney11,
            this.EmpFt_SalesMoney12,
            this.EmpFt_TotalSalesCount1,
            this.EmpFt_TotalSalesCount2,
            this.EmpFt_TotalSalesCount3,
            this.EmpFt_TotalSalesCount4,
            this.EmpFt_TotalSalesCount5,
            this.EmpFt_TotalSalesCount6,
            this.EmpFt_TotalSalesCount7,
            this.EmpFt_TotalSalesCount8,
            this.EmpFt_TotalSalesCount9,
            this.EmpFt_TotalSalesCount10,
            this.EmpFt_TotalSalesCount11,
            this.EmpFt_TotalSalesCount12,
            this.EmpFt_TtlTotalSalesCount,
            this.EmpFt_TtlSalesMoney});
            this.EmployeeFooter.Height = 0.4F;
            this.EmployeeFooter.KeepTogether = true;
            this.EmployeeFooter.Name = "EmployeeFooter";
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
            this.textBox36.Left = 0.4375F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox36.Text = "担当者計";
            this.textBox36.Top = 0.0625F;
            this.textBox36.Width = 0.65625F;
            // 
            // EmpFt_SalesMoney1
            // 
            this.EmpFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney1.DataField = "SalesMoney1";
            this.EmpFt_SalesMoney1.Height = 0.156F;
            this.EmpFt_SalesMoney1.Left = 3.3125F;
            this.EmpFt_SalesMoney1.MultiLine = false;
            this.EmpFt_SalesMoney1.Name = "EmpFt_SalesMoney1";
            this.EmpFt_SalesMoney1.OutputFormat = resources.GetString("EmpFt_SalesMoney1.OutputFormat");
            this.EmpFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney1.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney1.Text = "12,345,678";
            this.EmpFt_SalesMoney1.Top = 0.0625F;
            this.EmpFt_SalesMoney1.Width = 0.55F;
            // 
            // EmpFt_SalesMoney2
            // 
            this.EmpFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney2.DataField = "SalesMoney2";
            this.EmpFt_SalesMoney2.Height = 0.156F;
            this.EmpFt_SalesMoney2.Left = 3.875F;
            this.EmpFt_SalesMoney2.MultiLine = false;
            this.EmpFt_SalesMoney2.Name = "EmpFt_SalesMoney2";
            this.EmpFt_SalesMoney2.OutputFormat = resources.GetString("EmpFt_SalesMoney2.OutputFormat");
            this.EmpFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney2.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney2.Text = "12,345,678";
            this.EmpFt_SalesMoney2.Top = 0.0625F;
            this.EmpFt_SalesMoney2.Width = 0.55F;
            // 
            // EmpFt_SalesMoney3
            // 
            this.EmpFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney3.DataField = "SalesMoney3";
            this.EmpFt_SalesMoney3.Height = 0.156F;
            this.EmpFt_SalesMoney3.Left = 4.4375F;
            this.EmpFt_SalesMoney3.MultiLine = false;
            this.EmpFt_SalesMoney3.Name = "EmpFt_SalesMoney3";
            this.EmpFt_SalesMoney3.OutputFormat = resources.GetString("EmpFt_SalesMoney3.OutputFormat");
            this.EmpFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney3.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney3.Text = "12,345,678";
            this.EmpFt_SalesMoney3.Top = 0.0625F;
            this.EmpFt_SalesMoney3.Width = 0.55F;
            // 
            // EmpFt_SalesMoney4
            // 
            this.EmpFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney4.DataField = "SalesMoney4";
            this.EmpFt_SalesMoney4.Height = 0.156F;
            this.EmpFt_SalesMoney4.Left = 5F;
            this.EmpFt_SalesMoney4.MultiLine = false;
            this.EmpFt_SalesMoney4.Name = "EmpFt_SalesMoney4";
            this.EmpFt_SalesMoney4.OutputFormat = resources.GetString("EmpFt_SalesMoney4.OutputFormat");
            this.EmpFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney4.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney4.Text = "12,345,678";
            this.EmpFt_SalesMoney4.Top = 0.0625F;
            this.EmpFt_SalesMoney4.Width = 0.55F;
            // 
            // EmpFt_SalesMoney5
            // 
            this.EmpFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney5.DataField = "SalesMoney5";
            this.EmpFt_SalesMoney5.Height = 0.156F;
            this.EmpFt_SalesMoney5.Left = 5.5625F;
            this.EmpFt_SalesMoney5.MultiLine = false;
            this.EmpFt_SalesMoney5.Name = "EmpFt_SalesMoney5";
            this.EmpFt_SalesMoney5.OutputFormat = resources.GetString("EmpFt_SalesMoney5.OutputFormat");
            this.EmpFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney5.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney5.Text = "12,345,678";
            this.EmpFt_SalesMoney5.Top = 0.0625F;
            this.EmpFt_SalesMoney5.Width = 0.55F;
            // 
            // EmpFt_SalesMoney6
            // 
            this.EmpFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney6.DataField = "SalesMoney6";
            this.EmpFt_SalesMoney6.Height = 0.156F;
            this.EmpFt_SalesMoney6.Left = 6.125F;
            this.EmpFt_SalesMoney6.MultiLine = false;
            this.EmpFt_SalesMoney6.Name = "EmpFt_SalesMoney6";
            this.EmpFt_SalesMoney6.OutputFormat = resources.GetString("EmpFt_SalesMoney6.OutputFormat");
            this.EmpFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney6.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney6.Text = "12,345,678";
            this.EmpFt_SalesMoney6.Top = 0.0625F;
            this.EmpFt_SalesMoney6.Width = 0.55F;
            // 
            // EmpFt_SalesMoney7
            // 
            this.EmpFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney7.DataField = "SalesMoney7";
            this.EmpFt_SalesMoney7.Height = 0.156F;
            this.EmpFt_SalesMoney7.Left = 6.6875F;
            this.EmpFt_SalesMoney7.MultiLine = false;
            this.EmpFt_SalesMoney7.Name = "EmpFt_SalesMoney7";
            this.EmpFt_SalesMoney7.OutputFormat = resources.GetString("EmpFt_SalesMoney7.OutputFormat");
            this.EmpFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney7.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney7.Text = "12,345,678";
            this.EmpFt_SalesMoney7.Top = 0.0625F;
            this.EmpFt_SalesMoney7.Width = 0.55F;
            // 
            // EmpFt_SalesMoney8
            // 
            this.EmpFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney8.DataField = "SalesMoney8";
            this.EmpFt_SalesMoney8.Height = 0.156F;
            this.EmpFt_SalesMoney8.Left = 7.25F;
            this.EmpFt_SalesMoney8.MultiLine = false;
            this.EmpFt_SalesMoney8.Name = "EmpFt_SalesMoney8";
            this.EmpFt_SalesMoney8.OutputFormat = resources.GetString("EmpFt_SalesMoney8.OutputFormat");
            this.EmpFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney8.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney8.Text = "12,345,678";
            this.EmpFt_SalesMoney8.Top = 0.0625F;
            this.EmpFt_SalesMoney8.Width = 0.55F;
            // 
            // EmpFt_SalesMoney9
            // 
            this.EmpFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney9.DataField = "SalesMoney9";
            this.EmpFt_SalesMoney9.Height = 0.156F;
            this.EmpFt_SalesMoney9.Left = 7.8125F;
            this.EmpFt_SalesMoney9.MultiLine = false;
            this.EmpFt_SalesMoney9.Name = "EmpFt_SalesMoney9";
            this.EmpFt_SalesMoney9.OutputFormat = resources.GetString("EmpFt_SalesMoney9.OutputFormat");
            this.EmpFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney9.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney9.Text = "12,345,678";
            this.EmpFt_SalesMoney9.Top = 0.0625F;
            this.EmpFt_SalesMoney9.Width = 0.55F;
            // 
            // EmpFt_SalesMoney10
            // 
            this.EmpFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney10.DataField = "SalesMoney10";
            this.EmpFt_SalesMoney10.Height = 0.156F;
            this.EmpFt_SalesMoney10.Left = 8.375F;
            this.EmpFt_SalesMoney10.MultiLine = false;
            this.EmpFt_SalesMoney10.Name = "EmpFt_SalesMoney10";
            this.EmpFt_SalesMoney10.OutputFormat = resources.GetString("EmpFt_SalesMoney10.OutputFormat");
            this.EmpFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney10.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney10.Text = "12,345,678";
            this.EmpFt_SalesMoney10.Top = 0.0625F;
            this.EmpFt_SalesMoney10.Width = 0.55F;
            // 
            // EmpFt_SalesMoney11
            // 
            this.EmpFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney11.DataField = "SalesMoney11";
            this.EmpFt_SalesMoney11.Height = 0.156F;
            this.EmpFt_SalesMoney11.Left = 8.9375F;
            this.EmpFt_SalesMoney11.MultiLine = false;
            this.EmpFt_SalesMoney11.Name = "EmpFt_SalesMoney11";
            this.EmpFt_SalesMoney11.OutputFormat = resources.GetString("EmpFt_SalesMoney11.OutputFormat");
            this.EmpFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney11.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney11.Text = "12,345,678";
            this.EmpFt_SalesMoney11.Top = 0.0625F;
            this.EmpFt_SalesMoney11.Width = 0.55F;
            // 
            // EmpFt_SalesMoney12
            // 
            this.EmpFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_SalesMoney12.DataField = "SalesMoney12";
            this.EmpFt_SalesMoney12.Height = 0.156F;
            this.EmpFt_SalesMoney12.Left = 9.5F;
            this.EmpFt_SalesMoney12.MultiLine = false;
            this.EmpFt_SalesMoney12.Name = "EmpFt_SalesMoney12";
            this.EmpFt_SalesMoney12.OutputFormat = resources.GetString("EmpFt_SalesMoney12.OutputFormat");
            this.EmpFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_SalesMoney12.SummaryGroup = "EmployeeHeader";
            this.EmpFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_SalesMoney12.Text = "12,345,678";
            this.EmpFt_SalesMoney12.Top = 0.0625F;
            this.EmpFt_SalesMoney12.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount1
            // 
            this.EmpFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.EmpFt_TotalSalesCount1.Height = 0.156F;
            this.EmpFt_TotalSalesCount1.Left = 3.3125F;
            this.EmpFt_TotalSalesCount1.MultiLine = false;
            this.EmpFt_TotalSalesCount1.Name = "EmpFt_TotalSalesCount1";
            this.EmpFt_TotalSalesCount1.OutputFormat = resources.GetString("EmpFt_TotalSalesCount1.OutputFormat");
            this.EmpFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount1.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount1.Text = "12,345,678";
            this.EmpFt_TotalSalesCount1.Top = 0.219F;
            this.EmpFt_TotalSalesCount1.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount2
            // 
            this.EmpFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.EmpFt_TotalSalesCount2.Height = 0.156F;
            this.EmpFt_TotalSalesCount2.Left = 3.875F;
            this.EmpFt_TotalSalesCount2.MultiLine = false;
            this.EmpFt_TotalSalesCount2.Name = "EmpFt_TotalSalesCount2";
            this.EmpFt_TotalSalesCount2.OutputFormat = resources.GetString("EmpFt_TotalSalesCount2.OutputFormat");
            this.EmpFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount2.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount2.Text = "12,345,678";
            this.EmpFt_TotalSalesCount2.Top = 0.219F;
            this.EmpFt_TotalSalesCount2.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount3
            // 
            this.EmpFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.EmpFt_TotalSalesCount3.Height = 0.156F;
            this.EmpFt_TotalSalesCount3.Left = 4.4375F;
            this.EmpFt_TotalSalesCount3.MultiLine = false;
            this.EmpFt_TotalSalesCount3.Name = "EmpFt_TotalSalesCount3";
            this.EmpFt_TotalSalesCount3.OutputFormat = resources.GetString("EmpFt_TotalSalesCount3.OutputFormat");
            this.EmpFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount3.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount3.Text = "12,345,678";
            this.EmpFt_TotalSalesCount3.Top = 0.219F;
            this.EmpFt_TotalSalesCount3.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount4
            // 
            this.EmpFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.EmpFt_TotalSalesCount4.Height = 0.156F;
            this.EmpFt_TotalSalesCount4.Left = 5F;
            this.EmpFt_TotalSalesCount4.MultiLine = false;
            this.EmpFt_TotalSalesCount4.Name = "EmpFt_TotalSalesCount4";
            this.EmpFt_TotalSalesCount4.OutputFormat = resources.GetString("EmpFt_TotalSalesCount4.OutputFormat");
            this.EmpFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount4.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount4.Text = "12,345,678";
            this.EmpFt_TotalSalesCount4.Top = 0.219F;
            this.EmpFt_TotalSalesCount4.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount5
            // 
            this.EmpFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.EmpFt_TotalSalesCount5.Height = 0.156F;
            this.EmpFt_TotalSalesCount5.Left = 5.5625F;
            this.EmpFt_TotalSalesCount5.MultiLine = false;
            this.EmpFt_TotalSalesCount5.Name = "EmpFt_TotalSalesCount5";
            this.EmpFt_TotalSalesCount5.OutputFormat = resources.GetString("EmpFt_TotalSalesCount5.OutputFormat");
            this.EmpFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount5.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount5.Text = "12,345,678";
            this.EmpFt_TotalSalesCount5.Top = 0.219F;
            this.EmpFt_TotalSalesCount5.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount6
            // 
            this.EmpFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.EmpFt_TotalSalesCount6.Height = 0.156F;
            this.EmpFt_TotalSalesCount6.Left = 6.125F;
            this.EmpFt_TotalSalesCount6.MultiLine = false;
            this.EmpFt_TotalSalesCount6.Name = "EmpFt_TotalSalesCount6";
            this.EmpFt_TotalSalesCount6.OutputFormat = resources.GetString("EmpFt_TotalSalesCount6.OutputFormat");
            this.EmpFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount6.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount6.Text = "12,345,678";
            this.EmpFt_TotalSalesCount6.Top = 0.219F;
            this.EmpFt_TotalSalesCount6.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount7
            // 
            this.EmpFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.EmpFt_TotalSalesCount7.Height = 0.156F;
            this.EmpFt_TotalSalesCount7.Left = 6.6875F;
            this.EmpFt_TotalSalesCount7.MultiLine = false;
            this.EmpFt_TotalSalesCount7.Name = "EmpFt_TotalSalesCount7";
            this.EmpFt_TotalSalesCount7.OutputFormat = resources.GetString("EmpFt_TotalSalesCount7.OutputFormat");
            this.EmpFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount7.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount7.Text = "12,345,678";
            this.EmpFt_TotalSalesCount7.Top = 0.219F;
            this.EmpFt_TotalSalesCount7.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount8
            // 
            this.EmpFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.EmpFt_TotalSalesCount8.Height = 0.156F;
            this.EmpFt_TotalSalesCount8.Left = 7.25F;
            this.EmpFt_TotalSalesCount8.MultiLine = false;
            this.EmpFt_TotalSalesCount8.Name = "EmpFt_TotalSalesCount8";
            this.EmpFt_TotalSalesCount8.OutputFormat = resources.GetString("EmpFt_TotalSalesCount8.OutputFormat");
            this.EmpFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount8.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount8.Text = "12,345,678";
            this.EmpFt_TotalSalesCount8.Top = 0.219F;
            this.EmpFt_TotalSalesCount8.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount9
            // 
            this.EmpFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.EmpFt_TotalSalesCount9.Height = 0.156F;
            this.EmpFt_TotalSalesCount9.Left = 7.8125F;
            this.EmpFt_TotalSalesCount9.MultiLine = false;
            this.EmpFt_TotalSalesCount9.Name = "EmpFt_TotalSalesCount9";
            this.EmpFt_TotalSalesCount9.OutputFormat = resources.GetString("EmpFt_TotalSalesCount9.OutputFormat");
            this.EmpFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount9.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount9.Text = "12,345,678";
            this.EmpFt_TotalSalesCount9.Top = 0.219F;
            this.EmpFt_TotalSalesCount9.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount10
            // 
            this.EmpFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.EmpFt_TotalSalesCount10.Height = 0.156F;
            this.EmpFt_TotalSalesCount10.Left = 8.375F;
            this.EmpFt_TotalSalesCount10.MultiLine = false;
            this.EmpFt_TotalSalesCount10.Name = "EmpFt_TotalSalesCount10";
            this.EmpFt_TotalSalesCount10.OutputFormat = resources.GetString("EmpFt_TotalSalesCount10.OutputFormat");
            this.EmpFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount10.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount10.Text = "12,345,678";
            this.EmpFt_TotalSalesCount10.Top = 0.219F;
            this.EmpFt_TotalSalesCount10.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount11
            // 
            this.EmpFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.EmpFt_TotalSalesCount11.Height = 0.156F;
            this.EmpFt_TotalSalesCount11.Left = 8.9375F;
            this.EmpFt_TotalSalesCount11.MultiLine = false;
            this.EmpFt_TotalSalesCount11.Name = "EmpFt_TotalSalesCount11";
            this.EmpFt_TotalSalesCount11.OutputFormat = resources.GetString("EmpFt_TotalSalesCount11.OutputFormat");
            this.EmpFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount11.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount11.Text = "12,345,678";
            this.EmpFt_TotalSalesCount11.Top = 0.219F;
            this.EmpFt_TotalSalesCount11.Width = 0.55F;
            // 
            // EmpFt_TotalSalesCount12
            // 
            this.EmpFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.EmpFt_TotalSalesCount12.Height = 0.156F;
            this.EmpFt_TotalSalesCount12.Left = 9.5F;
            this.EmpFt_TotalSalesCount12.MultiLine = false;
            this.EmpFt_TotalSalesCount12.Name = "EmpFt_TotalSalesCount12";
            this.EmpFt_TotalSalesCount12.OutputFormat = resources.GetString("EmpFt_TotalSalesCount12.OutputFormat");
            this.EmpFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TotalSalesCount12.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TotalSalesCount12.Text = "12,345,678";
            this.EmpFt_TotalSalesCount12.Top = 0.219F;
            this.EmpFt_TotalSalesCount12.Width = 0.55F;
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
            this.EmpFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.EmpFt_TtlTotalSalesCount.Height = 0.156F;
            this.EmpFt_TtlTotalSalesCount.Left = 10.0625F;
            this.EmpFt_TtlTotalSalesCount.MultiLine = false;
            this.EmpFt_TtlTotalSalesCount.Name = "EmpFt_TtlTotalSalesCount";
            this.EmpFt_TtlTotalSalesCount.OutputFormat = resources.GetString("EmpFt_TtlTotalSalesCount.OutputFormat");
            this.EmpFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TtlTotalSalesCount.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.EmpFt_TtlTotalSalesCount.Top = 0.219F;
            this.EmpFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // EmpFt_TtlSalesMoney
            // 
            this.EmpFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.EmpFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.EmpFt_TtlSalesMoney.Height = 0.156F;
            this.EmpFt_TtlSalesMoney.Left = 10.0625F;
            this.EmpFt_TtlSalesMoney.MultiLine = false;
            this.EmpFt_TtlSalesMoney.Name = "EmpFt_TtlSalesMoney";
            this.EmpFt_TtlSalesMoney.OutputFormat = resources.GetString("EmpFt_TtlSalesMoney.OutputFormat");
            this.EmpFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.EmpFt_TtlSalesMoney.SummaryGroup = "EmployeeHeader";
            this.EmpFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.EmpFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.EmpFt_TtlSalesMoney.Text = "1,234,567,890";
            this.EmpFt_TtlSalesMoney.Top = 0.0625F;
            this.EmpFt_TtlSalesMoney.Width = 0.688F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.CanShrink = true;
            this.SupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupHd_AddUpSecCode,
            this.SupHd_SectionGuideNm,
            this.SupHd_SectionTitle,
            this.SupHd_SupplierCode,
            this.SupHd_SupplierSnm,
            this.SupHd_SupplierTitle,
            this.line6});
            this.SupplierHeader.DataField = "SupplierCode";
            this.SupplierHeader.Height = 0.25F;
            this.SupplierHeader.Name = "SupplierHeader";
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
            this.SupHd_AddUpSecCode.Left = 0.5F;
            this.SupHd_AddUpSecCode.MultiLine = false;
            this.SupHd_AddUpSecCode.Name = "SupHd_AddUpSecCode";
            this.SupHd_AddUpSecCode.OutputFormat = resources.GetString("SupHd_AddUpSecCode.OutputFormat");
            this.SupHd_AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupHd_AddUpSecCode.Text = "12";
            this.SupHd_AddUpSecCode.Top = 0.03125F;
            this.SupHd_AddUpSecCode.Width = 0.2F;
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
            this.SupHd_SectionGuideNm.Left = 0.6875F;
            this.SupHd_SectionGuideNm.MultiLine = false;
            this.SupHd_SectionGuideNm.Name = "SupHd_SectionGuideNm";
            this.SupHd_SectionGuideNm.OutputFormat = resources.GetString("SupHd_SectionGuideNm.OutputFormat");
            this.SupHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SupHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SupHd_SectionGuideNm.Top = 0.03125F;
            this.SupHd_SectionGuideNm.Width = 1.1875F;
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
            this.SupHd_SectionTitle.HyperLink = "";
            this.SupHd_SectionTitle.Left = 0.1875F;
            this.SupHd_SectionTitle.MultiLine = false;
            this.SupHd_SectionTitle.Name = "SupHd_SectionTitle";
            this.SupHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SectionTitle.Text = "拠点";
            this.SupHd_SectionTitle.Top = 0.03125F;
            this.SupHd_SectionTitle.Width = 0.313F;
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
            this.SupHd_SupplierCode.Left = 2.4375F;
            this.SupHd_SupplierCode.MultiLine = false;
            this.SupHd_SupplierCode.Name = "SupHd_SupplierCode";
            this.SupHd_SupplierCode.OutputFormat = resources.GetString("SupHd_SupplierCode.OutputFormat");
            this.SupHd_SupplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_SupplierCode.Text = "123456";
            this.SupHd_SupplierCode.Top = 0.03125F;
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
            this.SupHd_SupplierSnm.Left = 2.9375F;
            this.SupHd_SupplierSnm.MultiLine = false;
            this.SupHd_SupplierSnm.Name = "SupHd_SupplierSnm";
            this.SupHd_SupplierSnm.OutputFormat = resources.GetString("SupHd_SupplierSnm.OutputFormat");
            this.SupHd_SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SupHd_SupplierSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupHd_SupplierSnm.Top = 0.03125F;
            this.SupHd_SupplierSnm.Width = 2.4F;
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
            this.SupHd_SupplierTitle.HyperLink = "";
            this.SupHd_SupplierTitle.Left = 2.0625F;
            this.SupHd_SupplierTitle.MultiLine = false;
            this.SupHd_SupplierTitle.Name = "SupHd_SupplierTitle";
            this.SupHd_SupplierTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SupplierTitle.Text = "仕入先";
            this.SupHd_SupplierTitle.Top = 0.03125F;
            this.SupHd_SupplierTitle.Width = 0.4F;
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
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line7,
            this.Sup_Title,
            this.SupFt_SalesMoney1,
            this.SupFt_SalesMoney2,
            this.SupFt_SalesMoney3,
            this.SupFt_SalesMoney5,
            this.SupFt_SalesMoney6,
            this.SupFt_SalesMoney4,
            this.SupFt_SalesMoney7,
            this.SupFt_SalesMoney8,
            this.SupFt_SalesMoney9,
            this.SupFt_SalesMoney11,
            this.SupFt_SalesMoney12,
            this.SupFt_SalesMoney10,
            this.SupFt_TotalSalesCount1,
            this.SupFt_TotalSalesCount2,
            this.SupFt_TotalSalesCount3,
            this.SupFt_TotalSalesCount5,
            this.SupFt_TotalSalesCount6,
            this.SupFt_TotalSalesCount4,
            this.SupFt_TotalSalesCount7,
            this.SupFt_TotalSalesCount8,
            this.SupFt_TotalSalesCount9,
            this.SupFt_TotalSalesCount11,
            this.SupFt_TotalSalesCount12,
            this.SupFt_TotalSalesCount10,
            this.SupFt_TtlTotalSalesCount,
            this.SupFt_TtlSalesMoney});
            this.SupplierFooter.Height = 0.4F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            this.SupplierFooter.BeforePrint += new System.EventHandler(this.SupplierFooter_BeforePrint);
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
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // Sup_Title
            // 
            this.Sup_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Title.Height = 0.21875F;
            this.Sup_Title.Left = 0.4375F;
            this.Sup_Title.MultiLine = false;
            this.Sup_Title.Name = "Sup_Title";
            this.Sup_Title.OutputFormat = resources.GetString("Sup_Title.OutputFormat");
            this.Sup_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Sup_Title.Text = "仕入先計";
            this.Sup_Title.Top = 0.0625F;
            this.Sup_Title.Width = 0.65625F;
            // 
            // SupFt_SalesMoney1
            // 
            this.SupFt_SalesMoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney1.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney1.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney1.DataField = "SalesMoney1";
            this.SupFt_SalesMoney1.Height = 0.156F;
            this.SupFt_SalesMoney1.Left = 3.3125F;
            this.SupFt_SalesMoney1.MultiLine = false;
            this.SupFt_SalesMoney1.Name = "SupFt_SalesMoney1";
            this.SupFt_SalesMoney1.OutputFormat = resources.GetString("SupFt_SalesMoney1.OutputFormat");
            this.SupFt_SalesMoney1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney1.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney1.Text = "12,345,678";
            this.SupFt_SalesMoney1.Top = 0.0625F;
            this.SupFt_SalesMoney1.Width = 0.55F;
            // 
            // SupFt_SalesMoney2
            // 
            this.SupFt_SalesMoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney2.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney2.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney2.DataField = "SalesMoney2";
            this.SupFt_SalesMoney2.Height = 0.156F;
            this.SupFt_SalesMoney2.Left = 3.875F;
            this.SupFt_SalesMoney2.MultiLine = false;
            this.SupFt_SalesMoney2.Name = "SupFt_SalesMoney2";
            this.SupFt_SalesMoney2.OutputFormat = resources.GetString("SupFt_SalesMoney2.OutputFormat");
            this.SupFt_SalesMoney2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney2.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney2.Text = "12,345,678";
            this.SupFt_SalesMoney2.Top = 0.0625F;
            this.SupFt_SalesMoney2.Width = 0.55F;
            // 
            // SupFt_SalesMoney3
            // 
            this.SupFt_SalesMoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney3.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney3.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney3.DataField = "SalesMoney3";
            this.SupFt_SalesMoney3.Height = 0.156F;
            this.SupFt_SalesMoney3.Left = 4.4375F;
            this.SupFt_SalesMoney3.MultiLine = false;
            this.SupFt_SalesMoney3.Name = "SupFt_SalesMoney3";
            this.SupFt_SalesMoney3.OutputFormat = resources.GetString("SupFt_SalesMoney3.OutputFormat");
            this.SupFt_SalesMoney3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney3.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney3.Text = "12,345,678";
            this.SupFt_SalesMoney3.Top = 0.0625F;
            this.SupFt_SalesMoney3.Width = 0.55F;
            // 
            // SupFt_SalesMoney5
            // 
            this.SupFt_SalesMoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney5.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney5.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney5.DataField = "SalesMoney5";
            this.SupFt_SalesMoney5.Height = 0.156F;
            this.SupFt_SalesMoney5.Left = 5.5625F;
            this.SupFt_SalesMoney5.MultiLine = false;
            this.SupFt_SalesMoney5.Name = "SupFt_SalesMoney5";
            this.SupFt_SalesMoney5.OutputFormat = resources.GetString("SupFt_SalesMoney5.OutputFormat");
            this.SupFt_SalesMoney5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney5.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney5.Text = "12,345,678";
            this.SupFt_SalesMoney5.Top = 0.0625F;
            this.SupFt_SalesMoney5.Width = 0.55F;
            // 
            // SupFt_SalesMoney6
            // 
            this.SupFt_SalesMoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney6.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney6.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney6.DataField = "SalesMoney6";
            this.SupFt_SalesMoney6.Height = 0.156F;
            this.SupFt_SalesMoney6.Left = 6.125F;
            this.SupFt_SalesMoney6.MultiLine = false;
            this.SupFt_SalesMoney6.Name = "SupFt_SalesMoney6";
            this.SupFt_SalesMoney6.OutputFormat = resources.GetString("SupFt_SalesMoney6.OutputFormat");
            this.SupFt_SalesMoney6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney6.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney6.Text = "12,345,678";
            this.SupFt_SalesMoney6.Top = 0.0625F;
            this.SupFt_SalesMoney6.Width = 0.55F;
            // 
            // SupFt_SalesMoney4
            // 
            this.SupFt_SalesMoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney4.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney4.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney4.DataField = "SalesMoney4";
            this.SupFt_SalesMoney4.Height = 0.156F;
            this.SupFt_SalesMoney4.Left = 5F;
            this.SupFt_SalesMoney4.MultiLine = false;
            this.SupFt_SalesMoney4.Name = "SupFt_SalesMoney4";
            this.SupFt_SalesMoney4.OutputFormat = resources.GetString("SupFt_SalesMoney4.OutputFormat");
            this.SupFt_SalesMoney4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney4.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney4.Text = "12,345,678";
            this.SupFt_SalesMoney4.Top = 0.0625F;
            this.SupFt_SalesMoney4.Width = 0.55F;
            // 
            // SupFt_SalesMoney7
            // 
            this.SupFt_SalesMoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney7.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney7.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney7.DataField = "SalesMoney7";
            this.SupFt_SalesMoney7.Height = 0.156F;
            this.SupFt_SalesMoney7.Left = 6.6875F;
            this.SupFt_SalesMoney7.MultiLine = false;
            this.SupFt_SalesMoney7.Name = "SupFt_SalesMoney7";
            this.SupFt_SalesMoney7.OutputFormat = resources.GetString("SupFt_SalesMoney7.OutputFormat");
            this.SupFt_SalesMoney7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney7.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney7.Text = "12,345,678";
            this.SupFt_SalesMoney7.Top = 0.0625F;
            this.SupFt_SalesMoney7.Width = 0.55F;
            // 
            // SupFt_SalesMoney8
            // 
            this.SupFt_SalesMoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney8.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney8.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney8.DataField = "SalesMoney8";
            this.SupFt_SalesMoney8.Height = 0.156F;
            this.SupFt_SalesMoney8.Left = 7.25F;
            this.SupFt_SalesMoney8.MultiLine = false;
            this.SupFt_SalesMoney8.Name = "SupFt_SalesMoney8";
            this.SupFt_SalesMoney8.OutputFormat = resources.GetString("SupFt_SalesMoney8.OutputFormat");
            this.SupFt_SalesMoney8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney8.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney8.Text = "12,345,678";
            this.SupFt_SalesMoney8.Top = 0.0625F;
            this.SupFt_SalesMoney8.Width = 0.55F;
            // 
            // SupFt_SalesMoney9
            // 
            this.SupFt_SalesMoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney9.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney9.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney9.DataField = "SalesMoney9";
            this.SupFt_SalesMoney9.Height = 0.156F;
            this.SupFt_SalesMoney9.Left = 7.8125F;
            this.SupFt_SalesMoney9.MultiLine = false;
            this.SupFt_SalesMoney9.Name = "SupFt_SalesMoney9";
            this.SupFt_SalesMoney9.OutputFormat = resources.GetString("SupFt_SalesMoney9.OutputFormat");
            this.SupFt_SalesMoney9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney9.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney9.Text = "12,345,678";
            this.SupFt_SalesMoney9.Top = 0.0625F;
            this.SupFt_SalesMoney9.Width = 0.55F;
            // 
            // SupFt_SalesMoney11
            // 
            this.SupFt_SalesMoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney11.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney11.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney11.DataField = "SalesMoney11";
            this.SupFt_SalesMoney11.Height = 0.156F;
            this.SupFt_SalesMoney11.Left = 8.9375F;
            this.SupFt_SalesMoney11.MultiLine = false;
            this.SupFt_SalesMoney11.Name = "SupFt_SalesMoney11";
            this.SupFt_SalesMoney11.OutputFormat = resources.GetString("SupFt_SalesMoney11.OutputFormat");
            this.SupFt_SalesMoney11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney11.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney11.Text = "12,345,678";
            this.SupFt_SalesMoney11.Top = 0.0625F;
            this.SupFt_SalesMoney11.Width = 0.55F;
            // 
            // SupFt_SalesMoney12
            // 
            this.SupFt_SalesMoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney12.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney12.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney12.DataField = "SalesMoney12";
            this.SupFt_SalesMoney12.Height = 0.156F;
            this.SupFt_SalesMoney12.Left = 9.5F;
            this.SupFt_SalesMoney12.MultiLine = false;
            this.SupFt_SalesMoney12.Name = "SupFt_SalesMoney12";
            this.SupFt_SalesMoney12.OutputFormat = resources.GetString("SupFt_SalesMoney12.OutputFormat");
            this.SupFt_SalesMoney12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney12.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney12.Text = "12,345,678";
            this.SupFt_SalesMoney12.Top = 0.0625F;
            this.SupFt_SalesMoney12.Width = 0.55F;
            // 
            // SupFt_SalesMoney10
            // 
            this.SupFt_SalesMoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney10.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney10.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_SalesMoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_SalesMoney10.DataField = "SalesMoney10";
            this.SupFt_SalesMoney10.Height = 0.156F;
            this.SupFt_SalesMoney10.Left = 8.375F;
            this.SupFt_SalesMoney10.MultiLine = false;
            this.SupFt_SalesMoney10.Name = "SupFt_SalesMoney10";
            this.SupFt_SalesMoney10.OutputFormat = resources.GetString("SupFt_SalesMoney10.OutputFormat");
            this.SupFt_SalesMoney10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_SalesMoney10.SummaryGroup = "SupplierHeader";
            this.SupFt_SalesMoney10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_SalesMoney10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_SalesMoney10.Text = "12,345,678";
            this.SupFt_SalesMoney10.Top = 0.0625F;
            this.SupFt_SalesMoney10.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount1
            // 
            this.SupFt_TotalSalesCount1.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount1.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount1.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount1.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount1.DataField = "TotalSalesCount1";
            this.SupFt_TotalSalesCount1.Height = 0.156F;
            this.SupFt_TotalSalesCount1.Left = 3.3125F;
            this.SupFt_TotalSalesCount1.MultiLine = false;
            this.SupFt_TotalSalesCount1.Name = "SupFt_TotalSalesCount1";
            this.SupFt_TotalSalesCount1.OutputFormat = resources.GetString("SupFt_TotalSalesCount1.OutputFormat");
            this.SupFt_TotalSalesCount1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount1.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount1.Text = "12,345,678";
            this.SupFt_TotalSalesCount1.Top = 0.219F;
            this.SupFt_TotalSalesCount1.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount2
            // 
            this.SupFt_TotalSalesCount2.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount2.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount2.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount2.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount2.DataField = "TotalSalesCount2";
            this.SupFt_TotalSalesCount2.Height = 0.156F;
            this.SupFt_TotalSalesCount2.Left = 3.875F;
            this.SupFt_TotalSalesCount2.MultiLine = false;
            this.SupFt_TotalSalesCount2.Name = "SupFt_TotalSalesCount2";
            this.SupFt_TotalSalesCount2.OutputFormat = resources.GetString("SupFt_TotalSalesCount2.OutputFormat");
            this.SupFt_TotalSalesCount2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount2.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount2.Text = "12,345,678";
            this.SupFt_TotalSalesCount2.Top = 0.219F;
            this.SupFt_TotalSalesCount2.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount3
            // 
            this.SupFt_TotalSalesCount3.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount3.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount3.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount3.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount3.DataField = "TotalSalesCount3";
            this.SupFt_TotalSalesCount3.Height = 0.156F;
            this.SupFt_TotalSalesCount3.Left = 4.4375F;
            this.SupFt_TotalSalesCount3.MultiLine = false;
            this.SupFt_TotalSalesCount3.Name = "SupFt_TotalSalesCount3";
            this.SupFt_TotalSalesCount3.OutputFormat = resources.GetString("SupFt_TotalSalesCount3.OutputFormat");
            this.SupFt_TotalSalesCount3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount3.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount3.Text = "12,345,678";
            this.SupFt_TotalSalesCount3.Top = 0.219F;
            this.SupFt_TotalSalesCount3.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount5
            // 
            this.SupFt_TotalSalesCount5.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount5.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount5.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount5.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount5.DataField = "TotalSalesCount5";
            this.SupFt_TotalSalesCount5.Height = 0.156F;
            this.SupFt_TotalSalesCount5.Left = 5.5625F;
            this.SupFt_TotalSalesCount5.MultiLine = false;
            this.SupFt_TotalSalesCount5.Name = "SupFt_TotalSalesCount5";
            this.SupFt_TotalSalesCount5.OutputFormat = resources.GetString("SupFt_TotalSalesCount5.OutputFormat");
            this.SupFt_TotalSalesCount5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount5.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount5.Text = "12,345,678";
            this.SupFt_TotalSalesCount5.Top = 0.219F;
            this.SupFt_TotalSalesCount5.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount6
            // 
            this.SupFt_TotalSalesCount6.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount6.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount6.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount6.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount6.DataField = "TotalSalesCount6";
            this.SupFt_TotalSalesCount6.Height = 0.156F;
            this.SupFt_TotalSalesCount6.Left = 6.125F;
            this.SupFt_TotalSalesCount6.MultiLine = false;
            this.SupFt_TotalSalesCount6.Name = "SupFt_TotalSalesCount6";
            this.SupFt_TotalSalesCount6.OutputFormat = resources.GetString("SupFt_TotalSalesCount6.OutputFormat");
            this.SupFt_TotalSalesCount6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount6.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount6.Text = "12,345,678";
            this.SupFt_TotalSalesCount6.Top = 0.219F;
            this.SupFt_TotalSalesCount6.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount4
            // 
            this.SupFt_TotalSalesCount4.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount4.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount4.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount4.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount4.DataField = "TotalSalesCount4";
            this.SupFt_TotalSalesCount4.Height = 0.156F;
            this.SupFt_TotalSalesCount4.Left = 5F;
            this.SupFt_TotalSalesCount4.MultiLine = false;
            this.SupFt_TotalSalesCount4.Name = "SupFt_TotalSalesCount4";
            this.SupFt_TotalSalesCount4.OutputFormat = resources.GetString("SupFt_TotalSalesCount4.OutputFormat");
            this.SupFt_TotalSalesCount4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount4.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount4.Text = "12,345,678";
            this.SupFt_TotalSalesCount4.Top = 0.219F;
            this.SupFt_TotalSalesCount4.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount7
            // 
            this.SupFt_TotalSalesCount7.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount7.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount7.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount7.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount7.DataField = "TotalSalesCount7";
            this.SupFt_TotalSalesCount7.Height = 0.156F;
            this.SupFt_TotalSalesCount7.Left = 6.6875F;
            this.SupFt_TotalSalesCount7.MultiLine = false;
            this.SupFt_TotalSalesCount7.Name = "SupFt_TotalSalesCount7";
            this.SupFt_TotalSalesCount7.OutputFormat = resources.GetString("SupFt_TotalSalesCount7.OutputFormat");
            this.SupFt_TotalSalesCount7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount7.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount7.Text = "12,345,678";
            this.SupFt_TotalSalesCount7.Top = 0.219F;
            this.SupFt_TotalSalesCount7.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount8
            // 
            this.SupFt_TotalSalesCount8.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount8.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount8.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount8.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount8.DataField = "TotalSalesCount8";
            this.SupFt_TotalSalesCount8.Height = 0.156F;
            this.SupFt_TotalSalesCount8.Left = 7.25F;
            this.SupFt_TotalSalesCount8.MultiLine = false;
            this.SupFt_TotalSalesCount8.Name = "SupFt_TotalSalesCount8";
            this.SupFt_TotalSalesCount8.OutputFormat = resources.GetString("SupFt_TotalSalesCount8.OutputFormat");
            this.SupFt_TotalSalesCount8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount8.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount8.Text = "12,345,678";
            this.SupFt_TotalSalesCount8.Top = 0.219F;
            this.SupFt_TotalSalesCount8.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount9
            // 
            this.SupFt_TotalSalesCount9.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount9.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount9.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount9.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount9.DataField = "TotalSalesCount9";
            this.SupFt_TotalSalesCount9.Height = 0.156F;
            this.SupFt_TotalSalesCount9.Left = 7.8125F;
            this.SupFt_TotalSalesCount9.MultiLine = false;
            this.SupFt_TotalSalesCount9.Name = "SupFt_TotalSalesCount9";
            this.SupFt_TotalSalesCount9.OutputFormat = resources.GetString("SupFt_TotalSalesCount9.OutputFormat");
            this.SupFt_TotalSalesCount9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount9.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount9.Text = "12,345,678";
            this.SupFt_TotalSalesCount9.Top = 0.219F;
            this.SupFt_TotalSalesCount9.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount11
            // 
            this.SupFt_TotalSalesCount11.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount11.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount11.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount11.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount11.DataField = "TotalSalesCount11";
            this.SupFt_TotalSalesCount11.Height = 0.156F;
            this.SupFt_TotalSalesCount11.Left = 8.9375F;
            this.SupFt_TotalSalesCount11.MultiLine = false;
            this.SupFt_TotalSalesCount11.Name = "SupFt_TotalSalesCount11";
            this.SupFt_TotalSalesCount11.OutputFormat = resources.GetString("SupFt_TotalSalesCount11.OutputFormat");
            this.SupFt_TotalSalesCount11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount11.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount11.Text = "12,345,678";
            this.SupFt_TotalSalesCount11.Top = 0.219F;
            this.SupFt_TotalSalesCount11.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount12
            // 
            this.SupFt_TotalSalesCount12.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount12.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount12.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount12.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount12.DataField = "TotalSalesCount12";
            this.SupFt_TotalSalesCount12.Height = 0.156F;
            this.SupFt_TotalSalesCount12.Left = 9.5F;
            this.SupFt_TotalSalesCount12.MultiLine = false;
            this.SupFt_TotalSalesCount12.Name = "SupFt_TotalSalesCount12";
            this.SupFt_TotalSalesCount12.OutputFormat = resources.GetString("SupFt_TotalSalesCount12.OutputFormat");
            this.SupFt_TotalSalesCount12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount12.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount12.Text = "12,345,678";
            this.SupFt_TotalSalesCount12.Top = 0.219F;
            this.SupFt_TotalSalesCount12.Width = 0.55F;
            // 
            // SupFt_TotalSalesCount10
            // 
            this.SupFt_TotalSalesCount10.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount10.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount10.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount10.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalSalesCount10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalSalesCount10.DataField = "TotalSalesCount10";
            this.SupFt_TotalSalesCount10.Height = 0.156F;
            this.SupFt_TotalSalesCount10.Left = 8.375F;
            this.SupFt_TotalSalesCount10.MultiLine = false;
            this.SupFt_TotalSalesCount10.Name = "SupFt_TotalSalesCount10";
            this.SupFt_TotalSalesCount10.OutputFormat = resources.GetString("SupFt_TotalSalesCount10.OutputFormat");
            this.SupFt_TotalSalesCount10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalSalesCount10.SummaryGroup = "SupplierHeader";
            this.SupFt_TotalSalesCount10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalSalesCount10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalSalesCount10.Text = "12,345,678";
            this.SupFt_TotalSalesCount10.Top = 0.219F;
            this.SupFt_TotalSalesCount10.Width = 0.55F;
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
            this.SupFt_TtlTotalSalesCount.DataField = "TtlTotalSalesCount";
            this.SupFt_TtlTotalSalesCount.Height = 0.156F;
            this.SupFt_TtlTotalSalesCount.Left = 10.0625F;
            this.SupFt_TtlTotalSalesCount.MultiLine = false;
            this.SupFt_TtlTotalSalesCount.Name = "SupFt_TtlTotalSalesCount";
            this.SupFt_TtlTotalSalesCount.OutputFormat = resources.GetString("SupFt_TtlTotalSalesCount.OutputFormat");
            this.SupFt_TtlTotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TtlTotalSalesCount.SummaryGroup = "SupplierHeader";
            this.SupFt_TtlTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TtlTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TtlTotalSalesCount.Text = "1,234,567,890";
            this.SupFt_TtlTotalSalesCount.Top = 0.219F;
            this.SupFt_TtlTotalSalesCount.Width = 0.688F;
            // 
            // SupFt_TtlSalesMoney
            // 
            this.SupFt_TtlSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TtlSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TtlSalesMoney.DataField = "TtlSalesMoney";
            this.SupFt_TtlSalesMoney.Height = 0.156F;
            this.SupFt_TtlSalesMoney.Left = 10.0625F;
            this.SupFt_TtlSalesMoney.MultiLine = false;
            this.SupFt_TtlSalesMoney.Name = "SupFt_TtlSalesMoney";
            this.SupFt_TtlSalesMoney.OutputFormat = resources.GetString("SupFt_TtlSalesMoney.OutputFormat");
            this.SupFt_TtlSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TtlSalesMoney.SummaryGroup = "SupplierHeader";
            this.SupFt_TtlSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TtlSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TtlSalesMoney.Text = "1,234,567,890";
            this.SupFt_TtlSalesMoney.Top = 0.0625F;
            this.SupFt_TtlSalesMoney.Width = 0.688F;
            // 
            // DCTOK02132P_01A4C
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
            this.PrintWidth = 10.825F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.SupplierHeader);
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
            this.Sections.Add(this.SupplierFooter);
            this.Sections.Add(this.CustomerFooter);
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
            this.PageEnd += new System.EventHandler(this.DCTOK02132P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCTOK02132P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeNameHalf20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeNameFull20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsLGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Section)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Supplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_BLGoodsFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GoodsMGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_GoodsMGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MggFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_BLGroupCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DggFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GoodsLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_GoodsLGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LggFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_SalesMoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalSalesCount10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TtlSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion


        # region ■ 小計　印刷前処理 ■
        /// <summary>
        /// ＢＬコード計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGoodsCodeFooter_BeforePrint ( object sender, EventArgs e )
        {
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this.BlFt_BLGoodsCode.Text == ""
                || this.BlFt_BLGoodsCode.Text.PadLeft(5, '0') == "00000")
            {
                this.BlFt_BLGoodsCode.Text = "";
                this.BlFt_BLGoodsFullName.Text = "";
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.BLGoodsCodeFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary>
        ///// 自社分類計
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void EnterpriseGanreFooter_BeforePrint( object sender, EventArgs e )
        //{
        //    // 罫線制御
        //    Line_DetailHead.Visible = true;
        //}
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// <summary>
        /// グループコード計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupCodeFooter_BeforePrint ( object sender, EventArgs e )
        {
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this.DggFt_BLGroupCode.Text == ""
                || this.DggFt_BLGroupCode.Text.PadLeft(5, '0') == "00000")
            {
                this.DggFt_BLGroupCode.Text = "";
                this.DggFt_BLGroupCodeName.Text = "";
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.BLGroupCodeFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        /// <summary>
        /// 商品中分類計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMGroupFooter_BeforePrint ( object sender, EventArgs e )
        {
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this.MggFt_GoodsMGroupCode.Text == ""
                || this.MggFt_GoodsMGroupCode.Text.PadLeft(4, '0') == "0000")
            {
                this.MggFt_GoodsMGroupCode.Text = "";
                this.MggFt_GoodsMGroupName.Text = "";
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.GoodsMGroupFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        /// <summary>
        /// 商品大分類計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsLGroupFooter_BeforePrint ( object sender, EventArgs e )
        {
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this.LggFt_GoodsLGroupCode.Text == ""
                || this.LggFt_GoodsLGroupCode.Text.PadLeft(4, '0') == "0000")
            {
                this.LggFt_GoodsLGroupCode.Text = "";
                this.LggFt_GoodsLGroupName.Text = "";
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.GoodsLGroupFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        /// <summary>
        /// メーカー計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerFooter_BeforePrint ( object sender, EventArgs e )
        {
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this.MakFt_GoodsMakerCd.Text == ""
                || this.MakFt_GoodsMakerCd.Text.PadLeft(4, '0') == "0000")
            {
                this.MakFt_GoodsMakerCd.Text = "";
                this.MakFt_MakerName.Text = "";
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.MakerFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        /// <summary>
        /// 担当者計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeFooter_BeforePrint ( object sender, EventArgs e )
        {
            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.EmployeeFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        /// <summary>
        /// 得意先計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerFooter_BeforePrint ( object sender, EventArgs e )
        {
            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.CustomerFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }

        // --- ADD 2009/04/15 ------------------------>>>>>
        /// <summary>
        /// 仕入先計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierFooter_BeforePrint(object sender, EventArgs e)
        {
            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.SupplierFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        // --- ADD 2009/04/15 ------------------------>>>>>

        /// <summary>
        /// 拠点計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint ( object sender, EventArgs e )
        {
            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.SectionFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }
        /// <summary>
        /// 総合計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint ( object sender, EventArgs e )
        {
            // 罫線制御
            Line_DetailHead.Visible = true;
            SetTextFormat(this.GrandTotalFooter);//ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応
        }

        /// <summary>
        /// 粗利率算出処理（テキストボックスTextから取得する）
        /// </summary>
        /// <param name="tbGrossProfit">粗利のテキストボックス</param>
        /// <param name="tbSalesPrice">純売上のテキストボックス</param>
        /// <returns>粗利率(%)</returns>
        private decimal GetGrossProfitRate ( TextBox tbGrossProfit, TextBox tbSalesPrice )
        {
            Int64 grossProfit = GetValueFromLabel( tbGrossProfit );
            Int64 salesPrice = GetValueFromLabel( tbSalesPrice );

            if ( salesPrice == 0 || grossProfit == 0 )
            {
                return 0m;
            }
            else
            {
                return (decimal)grossProfit / (decimal)salesPrice * 100.00m;
            }
        }
        /// <summary>
        /// テキストボックスからの数値取得処理
        /// </summary>
        /// <param name="targetTextBox"></param>
        /// <returns></returns>
        private Int64 GetValueFromLabel ( TextBox targetTextBox )
        {
            try
            {
                return Int64.Parse( targetTextBox.Text );
            }
            catch
            {
                return 0;
            }
        }
        # endregion ■ 小計　印刷前処理 ■

        # region ■ ヘッダ　BeforePrint ■
        /// <summary>
        /// 拠点ヘッダ BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_BeforePrint ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._salesTransListCndtn.GroupBySectionDiv == SalesTransListCndtn.GroupBySectionDivState.All )
            //{
            //    SecHd_AddUpSecCode.Visible = false;
            //    SecHd_SectionGuideNm.Text = "全社集計";
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this.SecHd_AddUpSecCode.Text == null
                || this.SecHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.SecHd_AddUpSecCode.Text = "";
                this.SecHd_SectionGuideNm.Text = "";
            }
            // --- ADD 2008/10/16 -------------------------------->>>>>

            // 罫線制御
            Line_DetailHead.Visible = true;
        }

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>
        /// 得意先ヘッダ BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerHeader_BeforePrint(object sender, EventArgs e)
        {
            if (this.CusHd_AddUpSecCode.Text == null
                || this.CusHd_AddUpSecCode.Text.PadLeft(2, '0') == "00")
            {
                this.CusHd_AddUpSecCode.Text = "";
                this.CusHd_SectionGuideNm.Text = "";
            }

            if (this.CusHd_CustomerCode.Text == null
                || this.CusHd_CustomerCode.Text.PadLeft(8, '0') == "00000000")
            {
                this.CusHd_AddUpSecCode.Text = "";
                this.CusHd_SectionGuideNm.Text = "";
            }

            // 罫線制御
            Line_DetailHead.Visible = true;
        }

        /// <summary>
        /// 担当者ヘッダ BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeHeader_BeforePrint(object sender, EventArgs e)
        {
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

            // 罫線制御
            Line_DetailHead.Visible = true;
        }
        // --- ADD 2008/10/16 --------------------------------<<<<<
        # endregion ■ ヘッダ　拠点コード名称設定 ■

        //-----ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応----->>>>>
        /// <summary>
        /// 売上推移表 桁あふれの不具合の対応
        /// </summary>
        /// <param name="section"></param>
        /// <remarks>
        /// <br>Note        : 売上推移表 桁あふれの不具合の対応</br>
        /// <br>Programmer	: 鄭慕鈞</br>
        /// <br>Date        : 2013/10/25</br>
        /// <br></br>
        /// </remarks>
        private void SetTextFormat(Section section)
        {
            //セクション内一つ一つ項目で判定します
            foreach (ARControl control in section.Controls)
            {
                if (control is TextBox)
                {
                    //初期化
                    string textWithoutFormat = string.Empty;
                    //　項目は明細行又は集計行の集計項目かの判定
                    if (control.Name.EndsWith("TtlSalesMoney"))
                    {
                        //TextBox値を取得します
                        textWithoutFormat = ((TextBox)control).Value.ToString();
                        //満桁数の場合、*************で出力します
                        if (textWithoutFormat.Length > 10)
                        {
                            ((TextBox)control).Value = TTLSALESMONEYFORMAT;
                        }
                        continue;
                    }// 項目は月次別売上金額項目かの判定
                    else if (control.Name.Contains("SalesMoney"))
                    {
                        //TextBox値を取得します
                        textWithoutFormat = ((TextBox)control).Value.ToString();
                        //-----DEL 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応----->>>>>
                        ////明細部に11桁数が表示できる
                        //if (section.Name.Contains("Detail"))
                        //{
                        //    //満桁数の場合、*********で出力します
                        //    if (textWithoutFormat.Length > 9)
                        //    {
                        //        ((TextBox)control).Value = SALESMONEYFORMAT;
                        //    }
                        //}
                        ////footer部に太字を設定して、10桁数が表示できる
                        //else
                        //{
                        //    //満桁数の場合、*********で出力します
                        //    if (textWithoutFormat.Length > 8)
                        //    {
                        //        ((TextBox)control).Value = SALESMONEYFORMAT;
                        //    }
                        //}
                        //-----DEL 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応-----<<<<<
                        //-----ADD 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応----->>>>>
                        //満桁数の場合、**********で出力します
                        if (textWithoutFormat.Length > 8)
                        {
                            ((TextBox)control).Value = SALESMONEYFORMAT;
                        }
                        //-----ADD 鄭慕鈞　2013/11/06 Redmine#40089 システムテスト障害№20の対応-----<<<<<
                        continue;
                    }
                    else
                    {
                        //無し
                    }
                }
            }
        }
        //-----ADD 鄭慕鈞　2013/10/25 Redmine#40089 【神姫産業】№2105　売上推移表 桁あふれの不具合の対応-----<<<<<
    }
}
