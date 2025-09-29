using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上月報年報抽出結果データテーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月報年報の抽出結果テーブルスキーマです。</br>
    /// <br>Programmer : 980035 金沢　貞義</br>
    /// <br>Date       : 2007.12.07</br>
    /// <br>Update Note: 2008.09.08 30452 上野 俊治</br>
    /// <br>			 ・PM.NS対応</br>
    /// <br>Update Note: 2008/10/17       照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009.02.06 30452 上野 俊治</br>
    /// <br>			 ・障害対応10943,10971,11113（拠点計の売上目標取得処理を追加）</br>
    /// <br>UpdateNote  : 2013/07/26 duzg</br>
    /// <br>管理番号    : 10801804-00 2013/06/18配信分</br>
    /// <br>            : redmine #38722 </br>
    /// <br>            : ・No.6得意先順の場合、明細と小計の売上・粗利目標値は印字不正</br>
    /// </remarks>
    public class DCHNB02074EA
    {
        #region Public Members
        /// <summary>売上月報年報データテーブル名</summary>
        public const string ct_Tbl_SalesMonthYearReportDtl = "Tbl_SalesMonthYearReportDtl";

        #region 売上月報年報カラム情報

        /// <summary>企業コード</summary>
        public const string CT_EnterpriseCode = "EnterpriseCode";

        /// <summary>拠点コード</summary>
        public const string CT_SectionCode = "SectionCode";
        /// <summary>拠点名称</summary>
        public const string CT_SectionName = "SectionName";

        /// <summary>部門コード</summary>
        public const string CT_SubSectionCode = "SubSectionCode";
        /// <summary>部門名称</summary>
        public const string CT_SubSectionName = "SubSectionName";

        /// <summary>課コード</summary>
        public const string CT_MinSectionCode = "MinSectionCode";
        /// <summary>課名称</summary>
        public const string CT_MinSectionName = "MinSectionName";

        /// <summary>従業員コード</summary>
        public const string CT_EmployeeCode = "EmployeeCode";
        /// <summary>従業員名称</summary>
        public const string CT_EmployeeName = "EmployeeName";

        /// <summary>得意先コード</summary>
        public const string CT_CustomerCode = "CustomerCode";
        /// <summary>得意先名称</summary>
        public const string CT_CustomerName = "CustomerName";

        /// <summary>商品メーカーコード</summary>
        public const string CT_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>メーカー名称</summary>
        public const string CT_MakerName = "MakerName";

        /// <summary>地区コード</summary>
        public const string CT_SalesAreaCode = "SalesAreaCode";
        /// <summary>地区名称</summary>
        public const string CT_SalesAreaName = "SalesAreaName";

        /// <summary>業種コード</summary>
        public const string CT_BusinessTypeCode = "BusinessTypeCode";
        /// <summary>業種名称</summary>
        public const string CT_BusinessTypeName = "BusinessTypeName";

        /// <summary>明細コード</summary>
        public const string CT_RecordCode = "RecordCode";
        /// <summary>明細名称</summary>
        public const string CT_RecordName = "RecordName";

        /// <summary>月間売上金額合計</summary>
        public const string CT_SalesTtlPrice = "SalesTtlPrice";
        /// <summary>月間返品額</summary>
        public const string CT_RetGoodsTtlPrice = "RetGoodsTtlPrice";
        /// <summary>月間返品率</summary>
        public const string CT_RetGoodsTtlRate = "RetGoodsTtlRate";
        /// <summary>月間値引額</summary>
        public const string CT_DiscountTtlPrice = "DiscountTtlPrice";
        /// <summary>月間値引率</summary>
        public const string CT_DiscountTtlRate = "DiscountTtlRate";
        /// <summary>月間純売上額</summary>
        public const string CT_PureSalesTtlPrice = "PureSalesTtlPrice";
        /// <summary>月間合計純売上額（構成比算出用）</summary>
        public const string CT_PureSalesTtlWork = "PureSalesTtlWork";

        /// <summary>月間純売上目標額</summary>
        public const string CT_TargetMoney = "TargetMoney";
        /// <summary>月間純売上目標達成率</summary>
        public const string CT_TargetMoneyRate = "TargetMoneyRate";
        /// <summary>月間売上構成比</summary>
        public const string CT_CmpPureSalesRatio = "CmpPureSalesRatio";

        /// <summary>月間粗利金額</summary>
        public const string CT_GrossProfitPrice = "GrossProfitPrice";
        /// <summary>月間合計粗利額（構成比算出用）</summary>
        public const string CT_GrossProfitWork = "GrossProfitWork";
        /// <summary>月間粗利率</summary>
        public const string CT_GrossProfitRate = "GrossProfitRate";
        /// <summary>月間粗利目標額</summary>
        public const string CT_TargetProfit = "TargetProfit";
        /// <summary>月間粗利目標達成率</summary>
        public const string CT_TargetProfitRate = "TargetProfitRate";
        /// <summary>月間粗利構成比</summary>
        public const string CT_CmpProfitRatio = "CmpProfitRatio";


        /// <summary>年間売上金額合計</summary>
        public const string CT_AnSalesTtlPrice = "AnSalesTtlPrice";
        /// <summary>年間返品額</summary>
        public const string CT_AnRetGoodsTtlPrice = "AnRetGoodsTtlPrice";
        /// <summary>年間返品率</summary>
        public const string CT_AnRetGoodsTtlRate = "AnRetGoodsTtlRate";
        /// <summary>年間値引額</summary>
        public const string CT_AnDiscountTtlPrice = "AnDiscountTtlPrice";
        /// <summary>年間値引率</summary>
        public const string CT_AnDiscountTtlRate = "AnDiscountTtlRate";
        /// <summary>年間純売上額</summary>
        public const string CT_AnPureSalesTtlPrice = "AnPureSalesTtlPrice";
        /// <summary>年間合計純売上額（構成比算出用）</summary>
        public const string CT_AnPureSalesTtlWork = "AnPureSalesTtlWork";

        /// <summary>年間純売上目標額</summary>
        public const string CT_AnTargetMoney = "AnTargetMoney";
        /// <summary>年間純売上目標達成率</summary>
        public const string CT_AnTargetMoneyRate = "AnTargetMoneyRate";
        /// <summary>年間売上構成比</summary>
        public const string CT_AnCmpPureSalesRatio = "AnCmpPureSalesRatio";

        /// <summary>年間粗利金額</summary>
        public const string CT_AnGrossProfitPrice = "AnGrossProfitPrice";
        /// <summary>年間合計粗利額（構成比算出用）</summary>
        public const string CT_AnGrossProfitWork = "AnGrossProfitWork";
        /// <summary>年間粗利率</summary>
        public const string CT_AnGrossProfitRate = "AnGrossProfitRate";
        /// <summary>年間粗利目標額</summary>
        public const string CT_AnTargetProfit = "AnTargetProfit";
        /// <summary>年間粗利目標達成率</summary>
        public const string CT_AnTargetProfitRate = "AnTargetProfitRate";
        /// <summary>年間粗利構成比</summary>
        public const string CT_AnCmpProfitRatio = "AnCmpProfitRatio";

        // --- DEL 2008/09/08 -------------------------------->>>>>
        // --- キーブレイク用 DataTable列名 --- //
        // /// <summary> 小計出力キーブレイク </summary>
        //public const string CT_MiniTotal_KeyBleak   = "MiniTotal_KeyBleak";
        // --- DEL 2008/09/08 --------------------------------<<<<<

        //--- ADD 2008.08.14 ---------->>>>>
        /// <summary>順位</summary>
        public const string CT_Order = "Order";
        //--- ADD 2008.08.14 ----------<<<<<

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>コード(集計単位に合わせたコード値)</summary>
        public const string CT_Code = "Code";
        /// <summary>コード名(集計単位に合わせたコード名)</summary>
        public const string CT_Name = "Name";
        // --- ADD 2008/09/08 --------------------------------<<<<< 

        // --- ADD 2008/10/17 -------------------------------->>>>>
        /// <summary>単位変換前月間合計純売上額</summary>
        public const string CT_PureSalesTtlPriceNoUnitChange = "PureSalesTtlPriceNoUnitChange";
        /// <summary>単位変換前月間合計粗利額</summary>
        public const string CT_GrossProfitPriceNoUnitChange = "GrossProfitPriceNoUnitChange";
        /// <summary>単位変換前年間合計純売上額</summary>
        public const string CT_AnPureSalesTtlPriceNoUnitChange = "AnPureSalesTtlPriceNoUnitChange";
        /// <summary>単位変換前年間合計粗利額</summary>
        public const string CT_AnGrossProfitPriceNoUnitChange = "CT_AnGrossProfitPriceNoUnitChange";
        // --- ADD 2008/10/17 --------------------------------<<<<<

        // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
        /// <summary>月間純売上目標額(小計)</summary>
        public const string CT_SubTtlTargetMoney = "SubTtlTargetMoney";
        /// <summary>月間粗利目標額(小計)</summary>
        public const string CT_SubTtlTargetProfit = "SubTtlTargetProfit";
        /// <summary>年間純売上目標額(小計)</summary>
        public const string CT_AnSubTtlTargetMoney = "AnSubTtlTargetMoney";
        /// <summary>年間粗利目標額(小計)</summary>
        public const string CT_AnSubTtlTargetProfit = "AnSubTtlTargetProfit";
        // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<

        // --- ADD 2009/02/06 -------------------------------->>>>>
        /// <summary>月間純売上目標額(拠点計用)</summary>
        public const string CT_SectionTargetMoney = "SectionTargetMoney";
        /// <summary>月間粗利目標額(拠点計)</summary>
        public const string CT_SectionTargetProfit = "SectionTargetProfit";
        /// <summary>年間純売上目標額(拠点計)</summary>
        public const string CT_AnSectionTargetMoney = "AnSectionTargetMoney";
        /// <summary>年間粗利目標額(拠点計)</summary>
        public const string CT_AnSectionTargetProfit = "AnSectionTargetProfit";
        // --- ADD 2009/02/06 --------------------------------<<<<<

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 売上月報年報抽出結果データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上月報年報抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        public DCHNB02074EA()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(ct_Tbl_SalesMonthYearReportDtl)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_SalesMonthYearReportDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 0);

            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 売上月報年報抽出結果作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_SalesMonthYearReportDtl);
                dt = ds.Tables[ct_Tbl_SalesMonthYearReportDtl];
            }

            // 企業コード
            dt.Columns.Add(CT_EnterpriseCode, typeof(string));
            dt.Columns[CT_EnterpriseCode].DefaultValue = "";

            // 拠点コード
            dt.Columns.Add(CT_SectionCode, typeof(string));
            dt.Columns[CT_SectionCode].DefaultValue = "";

            // 拠点ガイド名称
            dt.Columns.Add(CT_SectionName, typeof(string));
            dt.Columns[CT_SectionName].DefaultValue = "";

            // 部門コード
            dt.Columns.Add(CT_SubSectionCode, typeof(Int32));
            dt.Columns[CT_SubSectionCode].DefaultValue = 0;

            // 部門名称</summary>
            dt.Columns.Add(CT_SubSectionName, typeof(string));
            dt.Columns[CT_SubSectionName].DefaultValue = "";

            // 課コード
            dt.Columns.Add(CT_MinSectionCode, typeof(Int32));
            dt.Columns[CT_MinSectionCode].DefaultValue = 0;

            // 課名称
            dt.Columns.Add(CT_MinSectionName, typeof(string));
            dt.Columns[CT_MinSectionName].DefaultValue = "";

            // 従業員コード
            dt.Columns.Add(CT_EmployeeCode, typeof(string));
            dt.Columns[CT_EmployeeCode].DefaultValue = "";

            // 従業員名称
            dt.Columns.Add(CT_EmployeeName, typeof(string));
            dt.Columns[CT_EmployeeName].DefaultValue = "";

            // 得意先コード
            dt.Columns.Add(CT_CustomerCode, typeof(Int32));
            dt.Columns[CT_CustomerCode].DefaultValue = 0;

            // 得意先名称
            dt.Columns.Add(CT_CustomerName, typeof(string));
            dt.Columns[CT_CustomerName].DefaultValue = "";

            // 商品メーカーコード
            dt.Columns.Add(CT_GoodsMakerCd, typeof(Int32));
            dt.Columns[CT_GoodsMakerCd].DefaultValue = 0;

            // メーカー名称
            dt.Columns.Add(CT_MakerName, typeof(string));
            dt.Columns[CT_MakerName].DefaultValue = "";

            // 地区コード
            dt.Columns.Add(CT_SalesAreaCode, typeof(Int32));
            dt.Columns[CT_SalesAreaCode].DefaultValue = 0;
            // 地区名称
            dt.Columns.Add(CT_SalesAreaName, typeof(string));
            dt.Columns[CT_SalesAreaName].DefaultValue = "";

            // 業種コード
            dt.Columns.Add(CT_BusinessTypeCode, typeof(Int32));
            dt.Columns[CT_BusinessTypeCode].DefaultValue = 0;
            // 業種名称
            dt.Columns.Add(CT_BusinessTypeName, typeof(string));
            dt.Columns[CT_BusinessTypeName].DefaultValue = "";

            // 明細コード
            dt.Columns.Add(CT_RecordCode, typeof(string));
            dt.Columns[CT_RecordCode].DefaultValue = "";
            // 明細名称
            dt.Columns.Add(CT_RecordName, typeof(string));
            dt.Columns[CT_RecordName].DefaultValue = "";

            // 月間売上金額合計
            dt.Columns.Add(CT_SalesTtlPrice, typeof(Int64));
            dt.Columns[CT_SalesTtlPrice].DefaultValue = 0;
            // 月間返品額
            dt.Columns.Add(CT_RetGoodsTtlPrice, typeof(Int64));
            dt.Columns[CT_RetGoodsTtlPrice].DefaultValue = 0;
            // 月間返品率
            dt.Columns.Add(CT_RetGoodsTtlRate, typeof(double));
            dt.Columns[CT_RetGoodsTtlRate].DefaultValue = 0.00;
            // 月間値引額
            dt.Columns.Add(CT_DiscountTtlPrice, typeof(Int64));
            dt.Columns[CT_DiscountTtlPrice].DefaultValue = 0;
            // 月間値引率
            dt.Columns.Add(CT_DiscountTtlRate, typeof(double));
            dt.Columns[CT_DiscountTtlRate].DefaultValue = 0.00;
            // 月間純売上額
            dt.Columns.Add(CT_PureSalesTtlPrice, typeof(Int64));
            dt.Columns[CT_PureSalesTtlPrice].DefaultValue = 0;
            // 月間合計純売上額（構成比算出用）
            dt.Columns.Add(CT_PureSalesTtlWork, typeof(Int64));
            dt.Columns[CT_PureSalesTtlWork].DefaultValue = 0;

            // 月間純売上目標額
            dt.Columns.Add(CT_TargetMoney, typeof(Int64));
            dt.Columns[CT_TargetMoney].DefaultValue = 0;
            // 月間純売上目標達成率
            dt.Columns.Add(CT_TargetMoneyRate, typeof(double));
            dt.Columns[CT_TargetMoneyRate].DefaultValue = 0.00;
            // 月間売上構成比
            dt.Columns.Add(CT_CmpPureSalesRatio, typeof(double));
            dt.Columns[CT_CmpPureSalesRatio].DefaultValue = 0.00;

            // 月間粗利金額
            dt.Columns.Add(CT_GrossProfitPrice, typeof(Int64));
            dt.Columns[CT_GrossProfitPrice].DefaultValue = 0;
            // 月間合計粗利額（構成比算出用）</summary>
            dt.Columns.Add(CT_GrossProfitWork, typeof(Int64));
            dt.Columns[CT_GrossProfitWork].DefaultValue = 0;
            // 月間粗利率
            dt.Columns.Add(CT_GrossProfitRate, typeof(double));
            dt.Columns[CT_GrossProfitRate].DefaultValue = 0.00;
            // 月間粗利目標額
            dt.Columns.Add(CT_TargetProfit, typeof(Int64));
            dt.Columns[CT_TargetProfit].DefaultValue = 0;
            // 月間粗利目標達成率
            dt.Columns.Add(CT_TargetProfitRate, typeof(double));
            dt.Columns[CT_TargetProfitRate].DefaultValue = 0.00;
            // 月間粗利構成比
            dt.Columns.Add(CT_CmpProfitRatio, typeof(double));
            dt.Columns[CT_CmpProfitRatio].DefaultValue = 0.00;


            // 年間売上金額合計
            dt.Columns.Add(CT_AnSalesTtlPrice, typeof(Int64));
            dt.Columns[CT_AnSalesTtlPrice].DefaultValue = 0;
            // 年間返品額
            dt.Columns.Add(CT_AnRetGoodsTtlPrice, typeof(Int64));
            dt.Columns[CT_AnRetGoodsTtlPrice].DefaultValue = 0;
            // 年間返品率
            dt.Columns.Add(CT_AnRetGoodsTtlRate, typeof(double));
            dt.Columns[CT_AnRetGoodsTtlRate].DefaultValue = 0.00;
            // 年間値引額
            dt.Columns.Add(CT_AnDiscountTtlPrice, typeof(Int64));
            dt.Columns[CT_AnDiscountTtlPrice].DefaultValue = 0;
            // 年間値引率
            dt.Columns.Add(CT_AnDiscountTtlRate, typeof(double));
            dt.Columns[CT_AnDiscountTtlRate].DefaultValue = 0.00;
            // 年間純売上額
            dt.Columns.Add(CT_AnPureSalesTtlPrice, typeof(Int64));
            dt.Columns[CT_AnPureSalesTtlPrice].DefaultValue = 0;
            // 年間合計純売上額（構成比算出用）
            dt.Columns.Add(CT_AnPureSalesTtlWork, typeof(Int64));
            dt.Columns[CT_AnPureSalesTtlWork].DefaultValue = 0;

            // 年間純売上目標額
            dt.Columns.Add(CT_AnTargetMoney, typeof(Int64));
            dt.Columns[CT_AnTargetMoney].DefaultValue = 0;
            // 年間純売上目標達成率
            dt.Columns.Add(CT_AnTargetMoneyRate, typeof(double));
            dt.Columns[CT_AnTargetMoneyRate].DefaultValue = 0.00;
            // 年間売上構成比
            dt.Columns.Add(CT_AnCmpPureSalesRatio, typeof(double));
            dt.Columns[CT_AnCmpPureSalesRatio].DefaultValue = 0.00;

            // 年間粗利金額
            dt.Columns.Add(CT_AnGrossProfitPrice, typeof(Int64));
            dt.Columns[CT_AnGrossProfitPrice].DefaultValue = 0;
            // 年間合計粗利額（構成比算出用）</summary>
            dt.Columns.Add(CT_AnGrossProfitWork, typeof(Int64));
            dt.Columns[CT_AnGrossProfitWork].DefaultValue = 0;
            // 年間粗利率
            dt.Columns.Add(CT_AnGrossProfitRate, typeof(double));
            dt.Columns[CT_AnGrossProfitRate].DefaultValue = 0.00;
            // 年間粗利目標額
            dt.Columns.Add(CT_AnTargetProfit, typeof(Int64));
            dt.Columns[CT_AnTargetProfit].DefaultValue = 0;
            // 年間粗利目標達成率
            dt.Columns.Add(CT_AnTargetProfitRate, typeof(double));
            dt.Columns[CT_AnTargetProfitRate].DefaultValue = 0.00;
            // 年間粗利構成比
            dt.Columns.Add(CT_AnCmpProfitRatio, typeof(double));
            dt.Columns[CT_AnCmpProfitRatio].DefaultValue = 0.00;

            // --- DEL 2008/09/08 -------------------------------->>>>>
            // --- キーブレイク用 DataTable列名 --- //
            // キーブレイク
            //dt.Columns.Add(CT_MiniTotal_KeyBleak, typeof(string));
            //dt.Columns[CT_MiniTotal_KeyBleak].DefaultValue = "";
            // --- DEL 2008/09/08 --------------------------------<<<<<

            // --- DEL 2008/09/08 -------------------------------->>>>>
            // 順位
            //dt.Columns.Add(CT_Order, typeof(Int32));
            //dt.Columns[CT_Order].DefaultValue = 0;
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            // --- ADD 2008/09/08 --------------------------------<<<<< 
            // 順位
            dt.Columns.Add(CT_Order, typeof(Int32));
            dt.Columns[CT_Order].DefaultValue = "10000000"; // ソート用に最大値+1をDefaultとする。
            // --- ADD 2008/09/08 -------------------------------->>>>>

            // コード
            dt.Columns.Add(CT_Code, typeof(string));
            dt.Columns[CT_Code].DefaultValue = "";

            // コード名
            dt.Columns.Add(CT_Name, typeof(string));
            dt.Columns[CT_Name].DefaultValue = "";
            // --- ADD 2008/09/08 --------------------------------<<<<<

            // --- ADD 2008/10/17 -------------------------------->>>>>
            // 単位変換前月間合計純売上額
            dt.Columns.Add(CT_PureSalesTtlPriceNoUnitChange, typeof(Int64));
            dt.Columns[CT_PureSalesTtlPriceNoUnitChange].DefaultValue = 0;
            // 単位変換前月間合計粗利額
            dt.Columns.Add(CT_GrossProfitPriceNoUnitChange, typeof(Int64));
            dt.Columns[CT_GrossProfitPriceNoUnitChange].DefaultValue = 0;
            // 単位変換前年間合計純売上額
            dt.Columns.Add(CT_AnPureSalesTtlPriceNoUnitChange, typeof(Int64));
            dt.Columns[CT_AnPureSalesTtlPriceNoUnitChange].DefaultValue = 0;
            // 単位変換前年間合計粗利額
            dt.Columns.Add(CT_AnGrossProfitPriceNoUnitChange, typeof(Int64));
            dt.Columns[CT_AnGrossProfitPriceNoUnitChange].DefaultValue = 0;
            // --- ADD 2008/10/17 --------------------------------<<<<<

            // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
            // 月間純売上目標額(小計)
            dt.Columns.Add(CT_SubTtlTargetMoney, typeof(Int64));
            dt.Columns[CT_SubTtlTargetMoney].DefaultValue = 0;
            // 月間粗利目標額(小計)
            dt.Columns.Add(CT_SubTtlTargetProfit, typeof(Int64));
            dt.Columns[CT_SubTtlTargetProfit].DefaultValue = 0;
            // 年間純売上目標額(小計)
            dt.Columns.Add(CT_AnSubTtlTargetMoney, typeof(Int64));
            dt.Columns[CT_AnSubTtlTargetMoney].DefaultValue = 0;
            // 年間粗利目標額(小計)
            dt.Columns.Add(CT_AnSubTtlTargetProfit, typeof(Int64));
            dt.Columns[CT_AnSubTtlTargetProfit].DefaultValue = 0;
            // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<

            // --- ADD 2009/02/06 -------------------------------->>>>>
            /// <summary>月間純売上目標額(拠点計用)</summary>
            dt.Columns.Add(CT_SectionTargetMoney, typeof(Int64));
            dt.Columns[CT_SectionTargetMoney].DefaultValue = 0;
            /// <summary>月間粗利目標額(拠点計)</summary>
            dt.Columns.Add(CT_SectionTargetProfit, typeof(Int64));
            dt.Columns[CT_SectionTargetProfit].DefaultValue = 0;
            /// <summary>年間純売上目標額(拠点計)</summary>
            dt.Columns.Add(CT_AnSectionTargetMoney, typeof(Int64));
            dt.Columns[CT_AnSectionTargetMoney].DefaultValue = 0;
            /// <summary>年間粗利目標額(拠点計)</summary>
            dt.Columns.Add(CT_AnSectionTargetProfit, typeof(Int64));
            dt.Columns[CT_AnSectionTargetProfit].DefaultValue = 0;
            // --- ADD 2009/02/06 --------------------------------<<<<<
        }

        #endregion
    }
}