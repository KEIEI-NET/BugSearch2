//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　テーブルスキーマ情報クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// キャンペーン実績表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : キャンペーン実績表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 田建委</br>
	/// <br>Date       : 2011/05/19</br>
	/// </remarks>
	public class PMKHN02054EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string ct_Tbl_CampaignData = "Tbl_CampaignData";

        /// <summary> ｷｬﾝﾍﾟｰﾝコード </summary>
        public const string ct_Col_CampaignCode = "CampaignCode";
        /// <summary> ｷｬﾝﾍﾟｰﾝ名称 </summary>
        public const string ct_Col_CampaignName = "CampaignName";
        /// <summary> ｷｬﾝﾍﾟｰﾝ適用日 </summary>
        public const string ct_Col_ApplyDate = "ApplyDate";
        /// <summary> 実績計上拠点コード </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> 拠点名称 </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 管理拠点コード </summary>
        public const string ct_Col_ManageSectionCode = "ManageSectionCode";
        /// <summary> 管理拠点名称 </summary>
        public const string ct_Col_ManageSectionNm = "ManageSectionNm";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 従業員コード </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> 従業員名称 </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> 地区コード </summary>
        public const string ct_Col_AreaCode = "AreaCode";
        /// <summary> 地区名称 </summary>
        public const string ct_Col_AreaName = "AreaName";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（半角） </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName";
        /// <summary> BLグループコード </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BLグループ名称 </summary>
        public const string ct_Col_BLGroupKanaName = "BLGroupKanaName";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー略称</summary>
        public const string ct_Col_MakerShortName = "MakerShortName";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_TotalSalesCount = "TotalSalesCount";
        /// <summary> 売上金額</summary>
        public const string ct_Col_TotalSalesMoney = "TotalSalesMoney";
        /// <summary> 目標数</summary>
        public const string ct_Col_GoalsCount = "GoalsCount";
        /// <summary> 目標額</summary>
        public const string ct_Col_GoalsMoney = "GoalsMoney";
        /// <summary> 粗利金額</summary>
        public const string ct_Col_GrossProfit = "GrossProfit";
        /// <summary> 粗利率</summary>
        public const string ct_Col_GrossRate = "GrossRate";

        /// <summary> 売上数計1 </summary>
        public const string ct_Col_TotalSalesCount1 = "TotalSalesCount1";
        /// <summary> 売上数計2 </summary>
        public const string ct_Col_TotalSalesCount2 = "TotalSalesCount2";
        /// <summary> 売上数計3 </summary>
        public const string ct_Col_TotalSalesCount3 = "TotalSalesCount3";
        /// <summary> 売上数計4 </summary>
        public const string ct_Col_TotalSalesCount4 = "TotalSalesCount4";
        /// <summary> 売上数計5 </summary>
        public const string ct_Col_TotalSalesCount5 = "TotalSalesCount5";
        /// <summary> 売上数計6 </summary>
        public const string ct_Col_TotalSalesCount6 = "TotalSalesCount6";
        /// <summary> 売上数計7 </summary>
        public const string ct_Col_TotalSalesCount7 = "TotalSalesCount7";
        /// <summary> 売上数計8 </summary>
        public const string ct_Col_TotalSalesCount8 = "TotalSalesCount8";
        /// <summary> 売上数計9 </summary>
        public const string ct_Col_TotalSalesCount9 = "TotalSalesCount9";
        /// <summary> 売上数計10 </summary>
        public const string ct_Col_TotalSalesCount10 = "TotalSalesCount10";
        /// <summary> 売上数計11 </summary>
        public const string ct_Col_TotalSalesCount11 = "TotalSalesCount11";
        /// <summary> 売上数計12 </summary>
        public const string ct_Col_TotalSalesCount12 = "TotalSalesCount12";
        /// <summary> 売上金額1 税抜き </summary>
        public const string ct_Col_SalesMoney1 = "SalesMoney1";
        /// <summary> 売上金額2</summary>
        public const string ct_Col_SalesMoney2 = "SalesMoney2";
        /// <summary> 売上金額3</summary>
        public const string ct_Col_SalesMoney3 = "SalesMoney3";
        /// <summary> 売上金額4</summary>
        public const string ct_Col_SalesMoney4 = "SalesMoney4";
        /// <summary> 売上金額5</summary>
        public const string ct_Col_SalesMoney5 = "SalesMoney5";
        /// <summary> 売上金額6</summary>
        public const string ct_Col_SalesMoney6 = "SalesMoney6";
        /// <summary> 売上金額7</summary>
        public const string ct_Col_SalesMoney7 = "SalesMoney7";
        /// <summary> 売上金額8</summary>
        public const string ct_Col_SalesMoney8 = "SalesMoney8";
        /// <summary> 売上金額9</summary>
        public const string ct_Col_SalesMoney9 = "SalesMoney9";
        /// <summary> 売上金額10</summary>
        public const string ct_Col_SalesMoney10 = "SalesMoney10";
        /// <summary> 売上金額11</summary>
        public const string ct_Col_SalesMoney11 = "SalesMoney11";
        /// <summary> 売上金額12</summary>
        public const string ct_Col_SalesMoney12 = "SalesMoney12";
        /// <summary> 粗利額1</summary>
        public const string ct_Col_GrossProfit1 = "GrossProfit1";
        /// <summary> 粗利額2</summary>
        public const string ct_Col_GrossProfit2 = "GrossProfit2";
        /// <summary> 粗利額3</summary>
        public const string ct_Col_GrossProfit3 = "GrossProfit3";
        /// <summary> 粗利額4</summary>
        public const string ct_Col_GrossProfit4 = "GrossProfit4";
        /// <summary> 粗利額5</summary>
        public const string ct_Col_GrossProfit5 = "GrossProfit5";
        /// <summary> 粗利額6</summary>
        public const string ct_Col_GrossProfit6 = "GrossProfit6";
        /// <summary> 粗利額7</summary>
        public const string ct_Col_GrossProfit7 = "GrossProfit7";
        /// <summary> 粗利額8</summary>
        public const string ct_Col_GrossProfit8 = "GrossProfit8";
        /// <summary> 粗利額9</summary>
        public const string ct_Col_GrossProfit9 = "GrossProfit9";
        /// <summary> 粗利額10</summary>
        public const string ct_Col_GrossProfit10 = "GrossProfit10";
        /// <summary> 粗利額11</summary>
        public const string ct_Col_GrossProfit11 = "GrossProfit11";
        /// <summary> 粗利額12</summary>
        public const string ct_Col_GrossProfit12 = "GrossProfit12";

        /// <summary> 当月売上数</summary>
        public const string ct_Col_MonthlySalesCount = "MonthlySalesCount";
        /// <summary> 期間累計売上数</summary>
        public const string ct_Col_TermSalesCount = "TermSalesCount";
        /// <summary> 当月数量目標1</summary>
        public const string ct_Col_MonthlySalesTargetCount1 = "MonthlySalesTargetCount1";
        /// <summary> 期間累計数量目標1</summary>
        public const string ct_Col_TermSalesTargetCount1 = "TermSalesTargetCount1";
        /// <summary> 当月数量目標2</summary>
        public const string ct_Col_MonthlySalesTargetCount2 = "MonthlySalesTargetCount2";
        /// <summary> 期間累計数量目標2</summary>
        public const string ct_Col_TermSalesTargetCount2 = "TermSalesTargetCount2";
        /// <summary> 当月数量目標3</summary>
        public const string ct_Col_MonthlySalesTargetCount3 = "MonthlySalesTargetCount3";
        /// <summary> 期間累計数量目標3</summary>
        public const string ct_Col_TermSalesTargetCount3 = "TermSalesTargetCount3";
        /// <summary> 当月数量達成率1</summary>
        public const string ct_Col_MonthlySalesCountAchivRate1 = "MonthlySalesCountAchivRate1";
        /// <summary> 期間累計数量達成率1</summary>
        public const string ct_Col_TermSalesCountAchivRate1 = "TermSalesCountAchivRate1";
        /// <summary> 当月数量達成率2</summary>
        public const string ct_Col_MonthlySalesCountAchivRate2 = "MonthlySalesCountAchivRate2";
        /// <summary> 期間累計数量達成率2</summary>
        public const string ct_Col_TermSalesCountAchivRate2 = "TermSalesCountAchivRate2";
        /// <summary> 当月数量達成率3</summary>
        public const string ct_Col_MonthlySalesCountAchivRate3 = "MonthlySalesCountAchivRate3";
        /// <summary> 期間累計数量達成率3</summary>
        public const string ct_Col_TermSalesCountAchivRate3 = "TermSalesCountAchivRate3";
        /// <summary> 当月売上額</summary>
        public const string ct_Col_MonthlySalesMoney = "MonthlySalesMoney";
        /// <summary> 期間累計売上額</summary>
        public const string ct_Col_TermSalesMoney = "TermSalesMoney";
        /// <summary> 当月売上目標1</summary>
        public const string ct_Col_MonthlySalesTarget1 = "MonthlySalesTarget1";
        /// <summary> 期間累計売上目標1</summary>
        public const string ct_Col_TermSalesTarget1 = "TermSalesTarget1";
        /// <summary> 当月売上目標2</summary>
        public const string ct_Col_MonthlySalesTarget2 = "MonthlySalesTarget2";
        /// <summary> 期間累計売上目標2</summary>
        public const string ct_Col_TermSalesTarget2 = "TermSalesTarget2";
        /// <summary> 当月売上目標3</summary>
        public const string ct_Col_MonthlySalesTarget3 = "MonthlySalesTarget3";
        /// <summary> 期間累計売上目標3</summary>
        public const string ct_Col_TermSalesTarget3 = "TermSalesTarget3";
        /// <summary> 当月売上達成率1</summary>
        public const string ct_Col_MonthlySalesMoneyAchivRate1 = "MonthlySalesMoneyAchivRate1";
        /// <summary> 期間累計売上達成率1</summary>
        public const string ct_Col_TermSalesMoneyAchivRate1 = "TermSalesMoneyAchivRate1";
        /// <summary> 当月売上達成率2</summary>
        public const string ct_Col_MonthlySalesMoneyAchivRate2 = "MonthlySalesMoneyAchivRate2";
        /// <summary> 期間累計売上達成率2</summary>
        public const string ct_Col_TermSalesMoneyAchivRate2 = "TermSalesMoneyAchivRate2";
        /// <summary> 当月売上達成率3</summary>
        public const string ct_Col_MonthlySalesMoneyAchivRate3 = "MonthlySalesMoneyAchivRate3";
        /// <summary> 期間累計売上達成率3</summary>
        public const string ct_Col_TermSalesMoneyAchivRate3 = "TermSalesMoneyAchivRate3";
        /// <summary> 当月粗利額</summary>
        public const string ct_Col_MonthlySalesProfit = "MonthlySalesProfit";
        /// <summary> 期間累計粗利額</summary>
        public const string ct_Col_TermSalesProfit = "TermSalesProfit";
        /// <summary> 当月粗利率</summary>
        public const string ct_Col_MonthlySalesProfitRate = "MonthlySalesProfitRate";
        /// <summary> 期間累計粗利率</summary>
        public const string ct_Col_TermSalesProfitRate = "TermSalesProfitRate";
        /// <summary> 当月粗利目標1</summary>
        public const string ct_Col_MonthlySalesTargetProfit1 = "MonthlySalesTargetProfit1";
        /// <summary> 期間累計粗利目標1</summary>
        public const string ct_Col_TermSalesTargetProfit1 = "TermSalesTargetProfit1";
        /// <summary> 当月粗利目標2</summary>
        public const string ct_Col_MonthlySalesTargetProfit2 = "MonthlySalesTargetProfit2";
        /// <summary> 期間累計粗利目標2</summary>
        public const string ct_Col_TermSalesTargetProfit2 = "TermSalesTargetProfit2";
        /// <summary> 当月粗利目標3</summary>
        public const string ct_Col_MonthlySalesTargetProfit3 = "MonthlySalesTargetProfit3";
        /// <summary> 期間累計粗利目標3</summary>
        public const string ct_Col_TermSalesTargetProfit3 = "TermSalesTargetProfit3";
        /// <summary> 当月粗利達成率1</summary>
        public const string ct_Col_MonthlySalesProfitAchivRate1 = "MonthlySalesProfitAchivRate1";
        /// <summary> 期間累計粗利達成率1</summary>
        public const string ct_Col_TermSalesProfitAchivRate1 = "TermSalesProfitAchivRat1";
        /// <summary> 当月粗利達成率2</summary>
        public const string ct_Col_MonthlySalesProfitAchivRate2 = "MonthlySalesProfitAchivRate2";
        /// <summary> 期間累計粗利達成率2</summary>
        public const string ct_Col_TermSalesProfitAchivRate2 = "TermSalesProfitAchivRat2";
        /// <summary> 当月粗利達成率3</summary>
        public const string ct_Col_MonthlySalesProfitAchivRate3 = "MonthlySalesProfitAchivRate3";
        /// <summary> 期間累計粗利達成率3</summary>
        public const string ct_Col_TermSalesProfitAchivRate3 = "TermSalesProfitAchivRat3";

        #region 印刷用
        /// <summary> HeaderKey1 (拠点＋担当者)</summary>
        public const string ct_Col_HeaderKey1 = "HeaderKey1";
        #endregion

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
		/// キャンペーン実績表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : キャンペーン実績表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public PMKHN02054EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ キャンペーン実績表DataSetテーブルスキーマ設定
		/// <summary>
		/// キャンペーン実績表DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : キャンペーン実績表データセットのスキーマを設定する。</br>
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
				// スキーマ設定
                dt = new DataTable(ct_Tbl_CampaignData);

                //ｷｬﾝﾍﾟｰﾝコード
                dt.Columns.Add(ct_Col_CampaignCode, typeof(string));
                dt.Columns[ct_Col_CampaignCode].DefaultValue = "";
                //ｷｬﾝﾍﾟｰﾝ名称
                dt.Columns.Add(ct_Col_CampaignName, typeof(string));
                dt.Columns[ct_Col_CampaignName].DefaultValue = "";
                //ｷｬﾝﾍﾟｰﾝ適用日
                dt.Columns.Add(ct_Col_ApplyDate, typeof(string));
                dt.Columns[ct_Col_ApplyDate].DefaultValue = "";

                //実績計上拠点コード
				dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = "";
                //拠点ガイド名称
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                //管理拠点コード 
                dt.Columns.Add(ct_Col_ManageSectionCode, typeof(string));
                dt.Columns[ct_Col_ManageSectionCode].DefaultValue = "";
                //管理拠点名称 
                dt.Columns.Add(ct_Col_ManageSectionNm, typeof(string));
                dt.Columns[ct_Col_ManageSectionNm].DefaultValue = "";
                //得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                //得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";
                //従業員コード
                dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
                dt.Columns[ct_Col_EmployeeCode].DefaultValue = "";
                //従業員名称
                dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
                dt.Columns[ct_Col_EmployeeName].DefaultValue = "";
                //地区コード
                dt.Columns.Add(ct_Col_AreaCode, typeof(Int32));
                dt.Columns[ct_Col_AreaCode].DefaultValue = 0;
                //地区名称
                dt.Columns.Add(ct_Col_AreaName, typeof(string));
                dt.Columns[ct_Col_AreaName].DefaultValue = "";
                //商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                // 商品名称
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                //BL商品コード
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                //BL商品コード名称（半角）
                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = "";
                //BLグループコード
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32)); 
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;
                //BLグループコード名称
                dt.Columns.Add(ct_Col_BLGroupKanaName, typeof(string));
                dt.Columns[ct_Col_BLGroupKanaName].DefaultValue = "";
                //商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                //商品メーカー略称
                dt.Columns.Add(ct_Col_MakerShortName, typeof(string));
                dt.Columns[ct_Col_MakerShortName].DefaultValue = "";
                //売上数計
                dt.Columns.Add(ct_Col_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount].DefaultValue = 0;
                //売上金額
                dt.Columns.Add(ct_Col_TotalSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_TotalSalesMoney].DefaultValue = 0;
                //目標数
                dt.Columns.Add(ct_Col_GoalsCount, typeof(double));
                dt.Columns[ct_Col_GoalsCount].DefaultValue = 0;
                //目標額
                dt.Columns.Add(ct_Col_GoalsMoney, typeof(Int64));
                dt.Columns[ct_Col_GoalsMoney].DefaultValue = 0;
                //粗利金額
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
                //粗利率
                dt.Columns.Add(ct_Col_GrossRate, typeof(double));
                dt.Columns[ct_Col_GrossRate].DefaultValue = 0;

                //売上数計1
                dt.Columns.Add(ct_Col_TotalSalesCount1, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount1].DefaultValue = 0;
                //売上数計2
                dt.Columns.Add(ct_Col_TotalSalesCount2, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount2].DefaultValue = 0;
                //売上数計3
                dt.Columns.Add(ct_Col_TotalSalesCount3, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount3].DefaultValue = 0;
                //売上数計4
                dt.Columns.Add(ct_Col_TotalSalesCount4, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount4].DefaultValue = 0;
                //売上数計5
                dt.Columns.Add(ct_Col_TotalSalesCount5, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount5].DefaultValue = 0;
                //売上数計6
                dt.Columns.Add(ct_Col_TotalSalesCount6, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount6].DefaultValue = 0;
                //売上数計7
                dt.Columns.Add(ct_Col_TotalSalesCount7, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount7].DefaultValue = 0;
                //売上数計8
                dt.Columns.Add(ct_Col_TotalSalesCount8, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount8].DefaultValue = 0;
                //売上数計9
                dt.Columns.Add(ct_Col_TotalSalesCount9, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount9].DefaultValue = 0;
                //売上数計10
                dt.Columns.Add(ct_Col_TotalSalesCount10, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount10].DefaultValue = 0;
                //売上数計11
                dt.Columns.Add(ct_Col_TotalSalesCount11, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount11].DefaultValue = 0;
                //売上数計12
                dt.Columns.Add(ct_Col_TotalSalesCount12, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount12].DefaultValue = 0;
                //売上金額1
                dt.Columns.Add(ct_Col_SalesMoney1, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney1].DefaultValue = 0;
                //売上金額2
                dt.Columns.Add(ct_Col_SalesMoney2, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney2].DefaultValue = 0;
                //売上金額3
                dt.Columns.Add(ct_Col_SalesMoney3, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney3].DefaultValue = 0;
                //売上金額4
                dt.Columns.Add(ct_Col_SalesMoney4, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney4].DefaultValue = 0;
                //売上金額5
                dt.Columns.Add(ct_Col_SalesMoney5, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney5].DefaultValue = 0;
                //売上金額6
                dt.Columns.Add(ct_Col_SalesMoney6, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney6].DefaultValue = 0;
                //売上金額7
                dt.Columns.Add(ct_Col_SalesMoney7, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney7].DefaultValue = 0;
                //売上金額8
                dt.Columns.Add(ct_Col_SalesMoney8, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney8].DefaultValue = 0;
                //売上金額9
                dt.Columns.Add(ct_Col_SalesMoney9, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney9].DefaultValue = 0;
                //売上金額10
                dt.Columns.Add(ct_Col_SalesMoney10, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney10].DefaultValue = 0;
                //売上金額11
                dt.Columns.Add(ct_Col_SalesMoney11, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney11].DefaultValue = 0;
                //売上金額12
                dt.Columns.Add(ct_Col_SalesMoney12, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney12].DefaultValue = 0;
                //粗利額1
                dt.Columns.Add(ct_Col_GrossProfit1, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit1].DefaultValue = 0;
                //粗利額2
                dt.Columns.Add(ct_Col_GrossProfit2, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit2].DefaultValue = 0;
                //粗利額3
                dt.Columns.Add(ct_Col_GrossProfit3, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit3].DefaultValue = 0;
                //粗利額4
                dt.Columns.Add(ct_Col_GrossProfit4, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit4].DefaultValue = 0;
                //粗利額5
                dt.Columns.Add(ct_Col_GrossProfit5, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit5].DefaultValue = 0;
                //粗利額6
                dt.Columns.Add(ct_Col_GrossProfit6, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit6].DefaultValue = 0;
                //粗利額7
                dt.Columns.Add(ct_Col_GrossProfit7, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit7].DefaultValue = 0;
                //粗利額8
                dt.Columns.Add(ct_Col_GrossProfit8, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit8].DefaultValue = 0;
                //粗利額9
                dt.Columns.Add(ct_Col_GrossProfit9, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit9].DefaultValue = 0;
                //粗利額10
                dt.Columns.Add(ct_Col_GrossProfit10, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit10].DefaultValue = 0;
                //粗利額11
                dt.Columns.Add(ct_Col_GrossProfit11, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit11].DefaultValue = 0;
                //粗利額12
                dt.Columns.Add(ct_Col_GrossProfit12, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit12].DefaultValue = 0;
                
                // 当月売上数
                dt.Columns.Add(ct_Col_MonthlySalesCount, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCount].DefaultValue = 0;
                // 期間累計売上数
                dt.Columns.Add(ct_Col_TermSalesCount, typeof(double));
                dt.Columns[ct_Col_TermSalesCount].DefaultValue = 0;
                // 当月数量目標1
                dt.Columns.Add(ct_Col_MonthlySalesTargetCount1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesTargetCount1].DefaultValue = 0;
                // 期間累計数量目標1
                dt.Columns.Add(ct_Col_TermSalesTargetCount1, typeof(double));
                dt.Columns[ct_Col_TermSalesTargetCount1].DefaultValue = 0;
                // 当月数量目標2
                dt.Columns.Add(ct_Col_MonthlySalesTargetCount2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesTargetCount2].DefaultValue = 0;
                // 期間累計数量目標2
                dt.Columns.Add(ct_Col_TermSalesTargetCount2, typeof(double));
                dt.Columns[ct_Col_TermSalesTargetCount2].DefaultValue = 0;
                // 当月数量目標3
                dt.Columns.Add(ct_Col_MonthlySalesTargetCount3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesTargetCount3].DefaultValue = 0;
                // 期間累計数量目標3
                dt.Columns.Add(ct_Col_TermSalesTargetCount3, typeof(double));
                dt.Columns[ct_Col_TermSalesTargetCount3].DefaultValue = 0;
                // 当月数量達成率1
                dt.Columns.Add(ct_Col_MonthlySalesCountAchivRate1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCountAchivRate1].DefaultValue = 0;
                // 期間累計数量達成率1
                dt.Columns.Add(ct_Col_TermSalesCountAchivRate1, typeof(double));
                dt.Columns[ct_Col_TermSalesCountAchivRate1].DefaultValue = 0;
                // 当月数量達成率2
                dt.Columns.Add(ct_Col_MonthlySalesCountAchivRate2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCountAchivRate2].DefaultValue = 0;
                // 期間累計数量達成率2
                dt.Columns.Add(ct_Col_TermSalesCountAchivRate2, typeof(double));
                dt.Columns[ct_Col_TermSalesCountAchivRate2].DefaultValue = 0;
                // 当月数量達成率3
                dt.Columns.Add(ct_Col_MonthlySalesCountAchivRate3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesCountAchivRate3].DefaultValue = 0;
                // 期間累計数量達成率3
                dt.Columns.Add(ct_Col_TermSalesCountAchivRate3, typeof(double));
                dt.Columns[ct_Col_TermSalesCountAchivRate3].DefaultValue = 0;
                // 当月売上額
                dt.Columns.Add(ct_Col_MonthlySalesMoney, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesMoney].DefaultValue = 0;
                // 期間累計売上額
                dt.Columns.Add(ct_Col_TermSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_TermSalesMoney].DefaultValue = 0;
                // 当月売上目標1
                dt.Columns.Add(ct_Col_MonthlySalesTarget1, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTarget1].DefaultValue = 0;
                // 期間累計売上目標1
                dt.Columns.Add(ct_Col_TermSalesTarget1, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTarget1].DefaultValue = 0;
                // 当月売上達成率1
                dt.Columns.Add(ct_Col_MonthlySalesMoneyAchivRate1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesMoneyAchivRate1].DefaultValue = 0;
                // 期間累計売上達成率1
                dt.Columns.Add(ct_Col_TermSalesMoneyAchivRate1, typeof(double));
                dt.Columns[ct_Col_TermSalesMoneyAchivRate1].DefaultValue = 0;
                // 当月売上目標2
                dt.Columns.Add(ct_Col_MonthlySalesTarget2, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTarget2].DefaultValue = 0;
                // 期間累計売上目標2
                dt.Columns.Add(ct_Col_TermSalesTarget2, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTarget2].DefaultValue = 0;
                // 当月売上達成率2
                dt.Columns.Add(ct_Col_MonthlySalesMoneyAchivRate2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesMoneyAchivRate2].DefaultValue = 0;
                // 期間累計売上達成率2
                dt.Columns.Add(ct_Col_TermSalesMoneyAchivRate2, typeof(double));
                dt.Columns[ct_Col_TermSalesMoneyAchivRate2].DefaultValue = 0;
                // 当月売上目標3
                dt.Columns.Add(ct_Col_MonthlySalesTarget3, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTarget3].DefaultValue = 0;
                // 期間累計売上目標3
                dt.Columns.Add(ct_Col_TermSalesTarget3, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTarget3].DefaultValue = 0;
                // 当月売上達成率3
                dt.Columns.Add(ct_Col_MonthlySalesMoneyAchivRate3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesMoneyAchivRate3].DefaultValue = 0;
                // 期間累計売上達成率3
                dt.Columns.Add(ct_Col_TermSalesMoneyAchivRate3, typeof(double));
                dt.Columns[ct_Col_TermSalesMoneyAchivRate3].DefaultValue = 0;
                // 当月粗利額
                dt.Columns.Add(ct_Col_MonthlySalesProfit, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesProfit].DefaultValue = 0;
                // 期間累計粗利額
                dt.Columns.Add(ct_Col_TermSalesProfit, typeof(Int64));
                dt.Columns[ct_Col_TermSalesProfit].DefaultValue = 0;
                // 当月粗利率
                dt.Columns.Add(ct_Col_MonthlySalesProfitRate, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitRate].DefaultValue = 0;
                // 期間累計粗利率
                dt.Columns.Add(ct_Col_TermSalesProfitRate, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitRate].DefaultValue = 0;
                // 当月粗利目標1
                dt.Columns.Add(ct_Col_MonthlySalesTargetProfit1, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTargetProfit1].DefaultValue = 0;
                // 期間累計粗利目標1
                dt.Columns.Add(ct_Col_TermSalesTargetProfit1, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTargetProfit1].DefaultValue = 0;
                // 当月粗利達成率1
                dt.Columns.Add(ct_Col_MonthlySalesProfitAchivRate1, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitAchivRate1].DefaultValue = 0;
                // 期間累計粗利達成率1
                dt.Columns.Add(ct_Col_TermSalesProfitAchivRate1, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitAchivRate1].DefaultValue = 0;
                // 当月粗利目標2
                dt.Columns.Add(ct_Col_MonthlySalesTargetProfit2, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTargetProfit2].DefaultValue = 0;
                // 期間累計粗利目標2
                dt.Columns.Add(ct_Col_TermSalesTargetProfit2, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTargetProfit2].DefaultValue = 0;
                // 当月粗利達成率2
                dt.Columns.Add(ct_Col_MonthlySalesProfitAchivRate2, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitAchivRate2].DefaultValue = 0;
                // 期間累計粗利達成率2
                dt.Columns.Add(ct_Col_TermSalesProfitAchivRate2, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitAchivRate2].DefaultValue = 0;
                // 当月粗利目標3
                dt.Columns.Add(ct_Col_MonthlySalesTargetProfit3, typeof(Int64));
                dt.Columns[ct_Col_MonthlySalesTargetProfit3].DefaultValue = 0;
                // 期間累計粗利目標3
                dt.Columns.Add(ct_Col_TermSalesTargetProfit3, typeof(Int64));
                dt.Columns[ct_Col_TermSalesTargetProfit3].DefaultValue = 0;
                // 当月粗利達成率3
                dt.Columns.Add(ct_Col_MonthlySalesProfitAchivRate3, typeof(double));
                dt.Columns[ct_Col_MonthlySalesProfitAchivRate3].DefaultValue = 0;
                // 期間累計粗利達成率3
                dt.Columns.Add(ct_Col_TermSalesProfitAchivRate3, typeof(double));
                dt.Columns[ct_Col_TermSalesProfitAchivRate3].DefaultValue = 0;

                // HeaderKey1 (拠点＋担当者)</summary>
                dt.Columns.Add(ct_Col_HeaderKey1, typeof(string));
                dt.Columns[ct_Col_HeaderKey1].DefaultValue = "";
			}
		}
		#endregion
		#endregion
	}
}
