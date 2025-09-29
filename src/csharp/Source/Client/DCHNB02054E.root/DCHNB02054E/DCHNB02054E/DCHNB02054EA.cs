using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 売上仕入対比表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上仕入対比表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 96186 立花 裕輔</br>
	/// <br>Date       : 2007.03.14</br>
    /// <br>Update Note: 2008.09.24 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
	/// </remarks>
	public class DCHNB02054EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_ShipmGoodsOdrReportData = "Tbl_ShipmGoodsOdrReportData";

        # region 抽出結果
        /// <summary> 計上拠点コード </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> 拠点名称 </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd"; // ADD 2008/09/24
        /// <summary> 仕入先名称 </summary>
        public const string ct_Col_SupplierNm = "SupplierNm";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 従業員コード </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> 従業員名称 </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 品番名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName"; // ADD 2008/09/24
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（半角） </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName";
        /// <summary> 商品大分類コード </summary>
        public const string ct_Col_GoodsLGroup = "GoodsLGroup"; // ADD 2008/09/24
        /// <summary> 商品大分類名称 </summary>
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName"; // ADD 2008/09/24
        /// <summary> 商品中分類コード </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup"; // ADD 2008/09/24
        /// <summary> 商品中分類名称 </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName"; // ADD 2008/09/24
        /// <summary> BLグループコード </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode"; // ADD 2008/09/24
        /// <summary> BLグループ名称 </summary>
        public const string ct_Col_BLGroupKanaName = "BLGroupKanaName"; // ADD 2008/09/24
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー略称</summary>
        public const string ct_Col_MakerShortName = "MakerShortName"; // ADD 2008/09/24
        /// <summary> 売上数計（BLコード別用） </summary>
        public const string ct_Col_TotalSalesCount = "TotalSalesCount"; // ADD 2008/09/24
        /// <summary> 純売上（BLコード別用） </summary>
        public const string ct_Col_TotalSalesMoney = "TotalSalesMoney"; // ADD 2008/09/24
        /// <summary> 粗利金額（BLコード別用） </summary>
        public const string ct_Col_GrossProfit = "GrossProfit"; // ADD 2008/09/24
        /// <summary> 売上数計1 出荷数(返品は減算)</summary>
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
        /// <summary> 売上回数1 出荷回数(売上時のみ）</summary>
        public const string ct_Col_SalesTimes1 = "SalesTimes1";
        /// <summary> 売上回数2 </summary>
        public const string ct_Col_SalesTimes2 = "SalesTimes2";
        /// <summary> 売上回数3 </summary>
        public const string ct_Col_SalesTimes3 = "SalesTimes3";
        /// <summary> 売上回数4 </summary>
        public const string ct_Col_SalesTimes4 = "SalesTimes4";
        /// <summary> 売上回数5 </summary>
        public const string ct_Col_SalesTimes5 = "SalesTimes5";
        /// <summary> 売上回数6 </summary>
        public const string ct_Col_SalesTimes6 = "SalesTimes6";
        /// <summary> 売上回数7 </summary>
        public const string ct_Col_SalesTimes7 = "SalesTimes7";
        /// <summary> 売上回数8 </summary>
        public const string ct_Col_SalesTimes8 = "SalesTimes8";
        /// <summary> 売上回数9 </summary>
        public const string ct_Col_SalesTimes9 = "SalesTimes9";
        /// <summary> 売上回数10 </summary>
        public const string ct_Col_SalesTimes10 = "SalesTimes10";
        /// <summary> 売上回数11 </summary>
        public const string ct_Col_SalesTimes11 = "SalesTimes11";
        /// <summary> 売上回数12 </summary>
        public const string ct_Col_SalesTimes12 = "SalesTimes12";
        // --- ADD 2008/09/24 -------------------------------->>>>>
        /// <summary> 売上金額1 税抜き（値引,返品含まず） </summary>
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
        // --- ADD 2008/09/24 --------------------------------<<<<<
        #endregion

        #region 印刷用
        // 合計
        /// <summary> 売上数計 </summary>
        public const string ct_Col_TotalSalesCountSum = "TotalSalesCountSum";

        /// <summary> 売上回数計 </summary>
        public const string ct_Col_SalesTimesSum = "SalesTimesSum";

        /// <summary> 売上金額計 </summary>
        public const string ct_Col_SalesMoneySum = "SalesMoneySum";

        // 平均
        /// <summary> 売上数計平均 </summary>
        public const string ct_Col_TotalSalesCountAve = "TotalSalesCountAve";

        /// <summary> 売上回数平均 </summary>
        public const string ct_Col_SalesTimesAve = "SalesTimesAve";

        /// <summary> 売上金額平均 </summary>
        public const string ct_Col_SalesMoneyAve = "SalesMoneyAve";

        // 小計フィールド値
        /// <summary> 拠点Field </summary>
        public const string ct_Col_SectionHeaderField = "SectionHeaderField";
        /// <summary> 仕入先Field </summary>
        public const string ct_Col_SuplierField = "SuplierField";
        /// <summary> メーカーField </summary>
        public const string ct_Col_MakerField = "MakerField";
        /// <summary> 商品大分類Field </summary>
        public const string ct_Col_GoodsLGroupField = "GoodsLGroupField";
        /// <summary> 商品中分類Field </summary>
        public const string ct_Col_GoodsMGroupField = "GoodsMGroupField";
        /// <summary> BLコードField </summary>
        public const string ct_Col_BLGoodsField = "BLGoodsField";
        /// <summary> BLグループField </summary>
        public const string ct_Col_BLGroupField = "BLGroupField";
        /// <summary> 得意先Field </summary>
        public const string ct_Col_CustomerField = "CustomerField";
        /// <summary> 担当者Field </summary>
        public const string ct_Col_SalesEmployeeField = "SalesEmployeeField";

        //算出値
        /// <summary> 順位 </summary>
        public const string ct_Col_OrderNo = "OrderNo";
        /// <summary>粗利率</summary>
        public const string ct_Col_ProfitRatio = "ProfitRatio";
        /// <summary>売上構成比</summary>
        public const string ct_Col_CmpPureSalesRatio = "CmpPureSalesRatio";
        /// <summary>粗利構成比</summary>
        public const string ct_Col_CmpProfitRatio = "CmpProfitRatio";

        // 帳票の小計毎の構成比算出用（率計算のため、金額単位の換算なしで使用）
        // 売上合計
        public const string ct_Col_TotalSalesMoneySum = "TotalSalesMoneySum";
        // 粗利合計
        public const string ct_Col_GrossProfitSum = "GrossProfitSum";
        // 純売上
        public const string ct_Col_TotalSalesMoneyOrg = "TotalSalesMoneyOrg";
        // 粗利
        public const string ct_Col_GrossProfitOrg = "GrossProfitOrg";
        // 売上金額計
        public const string ct_Col_SalesMoneySumOrg = "SalesMoneySumOrg";

        #endregion
     
        // --- DEL 2008/10/08 -------------------------------->>>>>
        ///// <summary> 従業員名称 </summary>
        //public const string ct_Col_EmployeeName = "EmployeeName";
        ///// <summary> 自社名称1 </summary>
        //public const string ct_Col_CompanyName1 = "CompanyName1";
        ///// <summary> 自社名称2 </summary>
        //public const string ct_Col_CompanyName2 = "CompanyName2";
        ///// <summary> 拠点ガイド名称 </summary>
        //public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        ///// <summary> 部門コード </summary>
        //public const string ct_Col_SubSectionCode = "SubSectionCode";
        ///// <summary> 部門名称 </summary>
        //public const string ct_Col_SubSectionName = "SubSectionName";
        ///// <summary> 課コード </summary>
        //public const string ct_Col_MinSectionCode = "MinSectionCode";
        ///// <summary> 課名称 </summary>
        //public const string ct_Col_MinSectionName = "MinSectionName";
		
        ///// <summary> 得意先略称 </summary>
        //public const string ct_Col_CustomerSnm = "CustomerSnm";
		
        ///// <summary> メーカー名称 </summary>
        //public const string ct_Col_MakerName = "MakerName";
        ///// <summary> 商品区分グループコード </summary>
        //public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary> 商品区分グループ名称 </summary>
        //public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary> 商品区分コード </summary>
        //public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary> 商品区分名称 </summary>
        //public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName";
        ///// <summary> 商品区分詳細コード </summary>
        //public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary> 商品区分詳細名称 </summary>
        //public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName";
		
		
        ///// <summary> 商品名略称 </summary>
        //public const string ct_Col_GoodsShortName = "GoodsShortName";
		
        ///// <summary> 売上数計合計 </summary>
        //public const string ct_Col_TotalSalesCountTotal = "TotalSalesCountTotal";
        ///// <summary> 売上数計平均 </summary>
        //public const string ct_Col_TotalSalesCountAve = "TotalSalesCountAve";

		
        ///// <summary> 売上回数合計 </summary>
        //public const string ct_Col_SalesTimesTotal = "SalesTimesTotal";
        ///// <summary> 売上回数平均 </summary>
        //public const string ct_Col_SalesTimesAve = "SalesTimesAve";

        ///// <summary> 純売上合計1（税抜き） </summary>
        //public const string ct_Col_TotalProceeds1 = "TotalProceeds1";
        ///// <summary> 純売上合計2（税抜き） </summary>
        //public const string ct_Col_TotalProceeds2 = "TotalProceeds2";
        ///// <summary> 純売上合計3（税抜き） </summary>
        //public const string ct_Col_TotalProceeds3 = "TotalProceeds3";
        ///// <summary> 純売上合計4（税抜き） </summary>
        //public const string ct_Col_TotalProceeds4 = "TotalProceeds4";
        ///// <summary> 純売上合計5（税抜き） </summary>
        //public const string ct_Col_TotalProceeds5 = "TotalProceeds5";
        ///// <summary> 純売上合計6（税抜き） </summary>
        //public const string ct_Col_TotalProceeds6 = "TotalProceeds6";
        ///// <summary> 純売上合計7（税抜き） </summary>
        //public const string ct_Col_TotalProceeds7 = "TotalProceeds7";
        ///// <summary> 純売上合計8（税抜き） </summary>
        //public const string ct_Col_TotalProceeds8 = "TotalProceeds8";
        ///// <summary> 純売上合計9（税抜き） </summary>
        //public const string ct_Col_TotalProceeds9 = "TotalProceeds9";
        ///// <summary> 純売上合計10（税抜き） </summary>
        //public const string ct_Col_TotalProceeds10 = "TotalProceeds10";
        ///// <summary> 純売上合計11（税抜き） </summary>
        //public const string ct_Col_TotalProceeds11 = "TotalProceeds11";
        ///// <summary> 純売上合計12（税抜き） </summary>
        //public const string ct_Col_TotalProceeds12 = "TotalProceeds12";
        ///// <summary> 純売上合計合計（税抜き） </summary>
        //public const string ct_Col_TotalProceedsTotal = "TotalProceedsTotal";
        ///// <summary> 純売上合計平均（税抜き） </summary>
        //public const string ct_Col_TotalProceedsAve = "TotalProceedsAve";

        ///// <summary> 粗利金額1（税抜き） </summary>
        //public const string ct_Col_GrossProfit1 = "GrossProfit1";
        ///// <summary> 粗利金額2（税抜き） </summary>
        //public const string ct_Col_GrossProfit2 = "GrossProfit2";
        ///// <summary> 粗利金額3（税抜き） </summary>
        //public const string ct_Col_GrossProfit3 = "GrossProfit3";
        ///// <summary> 粗利金額4（税抜き） </summary>
        //public const string ct_Col_GrossProfit4 = "GrossProfit4";
        ///// <summary> 粗利金額5（税抜き） </summary>
        //public const string ct_Col_GrossProfit5 = "GrossProfit5";
        ///// <summary> 粗利金額6（税抜き） </summary>
        //public const string ct_Col_GrossProfit6 = "GrossProfit6";
        ///// <summary> 粗利金額7（税抜き） </summary>
        //public const string ct_Col_GrossProfit7 = "GrossProfit7";
        ///// <summary> 粗利金額8（税抜き） </summary>
        //public const string ct_Col_GrossProfit8 = "GrossProfit8";
        ///// <summary> 粗利金額9（税抜き） </summary>
        //public const string ct_Col_GrossProfit9 = "GrossProfit9";
        ///// <summary> 粗利金額10（税抜き） </summary>
        //public const string ct_Col_GrossProfit10 = "GrossProfit10";
        ///// <summary> 粗利金額11（税抜き） </summary>
        //public const string ct_Col_GrossProfit11 = "GrossProfit11";
        ///// <summary> 粗利金額12（税抜き） </summary>
        //public const string ct_Col_GrossProfit12 = "GrossProfit12";
        ///// <summary> 粗利金額合計（税抜き） </summary>
        //public const string ct_Col_GrossProfitTotal = "GrossProfitTotal";
        ///// <summary> 粗利金額平均（税抜き） </summary>
        //public const string ct_Col_GrossProfitAve = "GrossProfitAve";

        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot1 = "AveLot1";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot2 = "AveLot2";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot3 = "AveLot3";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot4 = "AveLot4";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot5 = "AveLot5";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot6 = "AveLot6";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot7 = "AveLot7";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot8 = "AveLot8";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot9 = "AveLot9";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot10 = "AveLot10";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot11 = "AveLot11";
        ///// <summary> 出荷平均ロット1 </summary>
        //public const string ct_Col_AveLot12 = "AveLot12";
        ///// <summary> 出荷平均ロット合計 </summary>
        //public const string ct_Col_AveLotTotal = "AveLotTotal";
        ///// <summary> 出荷平均ロット平均 </summary>
        //public const string ct_Col_AveLotAve = "AveLotAve";
		
        ///// <summary> タグ </summary>
        //public const string ct_Col_Tag = "Tag";

        ////算出値
        ///// <summary> 順位 </summary>
        //public const string ct_Col_OrderNo = "OrderNo";

        ///// <summary> 拠点Field </summary>
        //public const string ct_Col_SectionHeaderField = "SectionHeaderField";
        ///// <summary> メーカーField </summary>
        //public const string ct_Col_MakerField = "MakerField";
        ///// <summary> 商品区分Field </summary>
        //public const string ct_Col_GoodsField = "GoodsField";
        ///// <summary> BL商品Field </summary>
        //public const string ct_Col_BlField = "BlField";
        ///// <summary> 得意先Field </summary>
        //public const string ct_Col_CustomerField = "CustomerField";
        ///// <summary> 担当者Field </summary>
        //public const string ct_Col_SalesEmployeeField = "SalesEmployeeField";

        ///// <summary> SectionHeaderLine </summary>
        //public const string ct_Col_SectionHeaderLine = "SectionHeaderLine";
        ///// <summary> SectionHeaderLineName </summary>
        //public const string ct_Col_SectionHeaderLineName = "SectionHeaderLineName";
        // --- DEL 2008/10/08 --------------------------------<<<<<

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
		/// 売上仕入対比表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上仕入対比表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public DCHNB02054EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// <summary>
		/// 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.03.14</br>
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
				dt = new DataTable(ct_Tbl_ShipmGoodsOdrReportData);

				//計上拠点コード
				dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
				dt.Columns[ct_Col_AddUpSecCode].DefaultValue = "";
                //仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32)); // ADD 2008/09/24
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0; // ADD 2008/09/24
                //得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                //従業員コード
                dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
                dt.Columns[ct_Col_EmployeeCode].DefaultValue = "";
                //商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                // 商品名称
                dt.Columns.Add(ct_Col_GoodsName, typeof(string)); // ADD 2008/09/24
                dt.Columns[ct_Col_GoodsName].DefaultValue = ""; // ADD 2008/09/24
                //BL商品コード
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                //BL商品コード名称（全角）
                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = "";
                //商品大分類コード
                dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32));
                dt.Columns[ct_Col_GoodsLGroup].DefaultValue = 0;
                //商品大分類名称
                dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string));
                dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = "";
                //商品中分類コード
                dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32)); // ADD 2008/09/24
                dt.Columns[ct_Col_GoodsMGroup].DefaultValue = 0; // ADD 2008/09/24
                //商品中分類名称
                dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string)); // ADD 2008/09/24
                dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = ""; // ADD 2008/09/24
                //BLグループコード
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32)); // ADD 2008/09/24
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0; // ADD 2008/09/24
                //BLグループコード名称
                dt.Columns.Add(ct_Col_BLGroupKanaName, typeof(string)); // ADD 2008/09/24
                dt.Columns[ct_Col_BLGroupKanaName].DefaultValue = ""; // ADD 2008/09/24
                //商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                //商品メーカー略称
                dt.Columns.Add(ct_Col_MakerShortName, typeof(string)); // ADD 2008/09/24
                dt.Columns[ct_Col_MakerShortName].DefaultValue = ""; // ADD 2008/09/24
                //売上数計(BLコード別用)
                dt.Columns.Add(ct_Col_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_TotalSalesCount].DefaultValue = 0;
                //純利益(BLコード別用)
                dt.Columns.Add(ct_Col_TotalSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_TotalSalesMoney].DefaultValue = 0;
                //粗利金額(BLコード別用)
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
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
                //売上回数1
                dt.Columns.Add(ct_Col_SalesTimes1, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes1].DefaultValue = 0;
                //売上回数2
                dt.Columns.Add(ct_Col_SalesTimes2, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes2].DefaultValue = 0;
                //売上回数3
                dt.Columns.Add(ct_Col_SalesTimes3, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes3].DefaultValue = 0;
                //売上回数4
                dt.Columns.Add(ct_Col_SalesTimes4, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes4].DefaultValue = 0;
                //売上回数5
                dt.Columns.Add(ct_Col_SalesTimes5, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes5].DefaultValue = 0;
                //売上回数6
                dt.Columns.Add(ct_Col_SalesTimes6, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes6].DefaultValue = 0;
                //売上回数7
                dt.Columns.Add(ct_Col_SalesTimes7, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes7].DefaultValue = 0;
                //売上回数8
                dt.Columns.Add(ct_Col_SalesTimes8, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes8].DefaultValue = 0;
                //売上回数9
                dt.Columns.Add(ct_Col_SalesTimes9, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes9].DefaultValue = 0;
                //売上回数10
                dt.Columns.Add(ct_Col_SalesTimes10, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes10].DefaultValue = 0;
                //売上回数11
                dt.Columns.Add(ct_Col_SalesTimes11, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes11].DefaultValue = 0;
                //売上回数12
                dt.Columns.Add(ct_Col_SalesTimes12, typeof(Int32));
                dt.Columns[ct_Col_SalesTimes12].DefaultValue = 0;
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


                //拠点ガイド名称
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

                //仕入先名称
                dt.Columns.Add(ct_Col_SupplierNm, typeof(string));
                dt.Columns[ct_Col_SupplierNm].DefaultValue = "";

                //得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                //従業員名称
                dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
                dt.Columns[ct_Col_EmployeeName].DefaultValue = "";

                //売上数計
                dt.Columns.Add(ct_Col_TotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_TotalSalesCountSum].DefaultValue = 0;

                //売上回数計
                dt.Columns.Add(ct_Col_SalesTimesSum, typeof(double));
                dt.Columns[ct_Col_SalesTimesSum].DefaultValue = 0;

                //売上金額計
                dt.Columns.Add(ct_Col_SalesMoneySum, typeof(double));
                dt.Columns[ct_Col_SalesMoneySum].DefaultValue = 0;

                //平均
                //売上数計平均
                dt.Columns.Add(ct_Col_TotalSalesCountAve, typeof(double));
                dt.Columns[ct_Col_TotalSalesCountAve].DefaultValue = 0;

                //売上回数平均
                dt.Columns.Add(ct_Col_SalesTimesAve, typeof(double));
                dt.Columns[ct_Col_SalesTimesAve].DefaultValue = 0;

                //売上金額平均
                dt.Columns.Add(ct_Col_SalesMoneyAve, typeof(double));
                dt.Columns[ct_Col_SalesMoneyAve].DefaultValue = 0;

                //順位
                dt.Columns.Add(ct_Col_OrderNo, typeof(Int32));
                dt.Columns[ct_Col_OrderNo].DefaultValue = 0;

                //粗利率
                dt.Columns.Add(ct_Col_ProfitRatio, typeof(double));
                dt.Columns[ct_Col_ProfitRatio].DefaultValue = 0;

                //売上構成比
                dt.Columns.Add(ct_Col_CmpPureSalesRatio, typeof(double));
                dt.Columns[ct_Col_CmpPureSalesRatio].DefaultValue = 0;

                //粗利構成比
                dt.Columns.Add(ct_Col_CmpProfitRatio, typeof(double));
                dt.Columns[ct_Col_CmpProfitRatio].DefaultValue = 0;

                // 売上合計
                dt.Columns.Add(ct_Col_TotalSalesMoneySum, typeof(double));
                dt.Columns[ct_Col_TotalSalesMoneySum].DefaultValue = 0;

                // 粗利合計
                dt.Columns.Add(ct_Col_GrossProfitSum, typeof(double));
                dt.Columns[ct_Col_GrossProfitSum].DefaultValue = 0;

                //純利益(金額単位換算なし)
                dt.Columns.Add(ct_Col_TotalSalesMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalSalesMoney].DefaultValue = 0;
                
                //粗利金額(金額単位換算なし)
                dt.Columns.Add(ct_Col_GrossProfitOrg, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;

                //売上金額計(金額単位換算なし)
                dt.Columns.Add(ct_Col_SalesMoneySumOrg, typeof(double));
                dt.Columns[ct_Col_SalesMoneySumOrg].DefaultValue = 0;

                //拠点Field
                dt.Columns.Add(ct_Col_SectionHeaderField, typeof(string));
                dt.Columns[ct_Col_SectionHeaderField].DefaultValue = "";
                //仕入先Field
                dt.Columns.Add(ct_Col_SuplierField, typeof(string));
                dt.Columns[ct_Col_SuplierField].DefaultValue = "";
                //メーカーField
                dt.Columns.Add(ct_Col_MakerField, typeof(string));
                dt.Columns[ct_Col_MakerField].DefaultValue = "";
                //商品大分類Field
                dt.Columns.Add(ct_Col_GoodsLGroupField, typeof(string));
                dt.Columns[ct_Col_GoodsLGroupField].DefaultValue = "";
                //商品中分類Field
                dt.Columns.Add(ct_Col_GoodsMGroupField, typeof(string));
                dt.Columns[ct_Col_GoodsMGroupField].DefaultValue = "";
                //BLコードField
                dt.Columns.Add(ct_Col_BLGoodsField, typeof(string));
                dt.Columns[ct_Col_BLGoodsField].DefaultValue = "";
                //BLグループコードField
                dt.Columns.Add(ct_Col_BLGroupField, typeof(string));
                dt.Columns[ct_Col_BLGroupField].DefaultValue = "";
                //得意先Field
                dt.Columns.Add(ct_Col_CustomerField, typeof(string));
                dt.Columns[ct_Col_CustomerField].DefaultValue = "";
                //担当者Field
                dt.Columns.Add(ct_Col_SalesEmployeeField, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeField].DefaultValue = "";

                // --- DEL 2008/10/08 -------------------------------->>>>>
                ////自社名称1
                //dt.Columns.Add(ct_Col_CompanyName1, typeof(string));
                //dt.Columns[ct_Col_CompanyName1].DefaultValue = "";
                ////自社名称2
                //dt.Columns.Add(ct_Col_CompanyName2, typeof(string));
                //dt.Columns[ct_Col_CompanyName2].DefaultValue = "";
                ////拠点ガイド名称
                //dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
                //dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                ////部門コード
                //dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
                //dt.Columns[ct_Col_SubSectionCode].DefaultValue = 0;
                ////部門名称
                //dt.Columns.Add(ct_Col_SubSectionName, typeof(string));
                //dt.Columns[ct_Col_SubSectionName].DefaultValue = "";
                ////課コード
                //dt.Columns.Add(ct_Col_MinSectionCode, typeof(Int32));
                //dt.Columns[ct_Col_MinSectionCode].DefaultValue = 0;
                ////課名称
                //dt.Columns.Add(ct_Col_MinSectionName, typeof(string));
                //dt.Columns[ct_Col_MinSectionName].DefaultValue = "";
				
                ////従業員名称
                //dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
                //dt.Columns[ct_Col_EmployeeName].DefaultValue = "";
				
                ////得意先略称
                //dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                //dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";
				
                ////メーカー名称
                //dt.Columns.Add(ct_Col_MakerName, typeof(string));
                //dt.Columns[ct_Col_MakerName].DefaultValue = "";
                ////商品区分グループコード
                //dt.Columns.Add(ct_Col_LargeGoodsGanreCode, typeof(string));
                //dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = "";
                ////商品区分グループ名称
                //dt.Columns.Add(ct_Col_LargeGoodsGanreName, typeof(string));
                //dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = "";
                ////商品区分コード
                //dt.Columns.Add(ct_Col_MediumGoodsGanreCode, typeof(string));
                //dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = "";
                ////商品区分名称
                //dt.Columns.Add(ct_Col_MediumGoodsGanreName, typeof(string));
                //dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = "";
                ////商品区分詳細コード
                //dt.Columns.Add(ct_Col_DetailGoodsGanreCode, typeof(string));
                //dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = "";
                ////商品区分詳細名称
                //dt.Columns.Add(ct_Col_DetailGoodsGanreName, typeof(string));
                //dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = "";
				
				
                ////商品名略称
                //dt.Columns.Add(ct_Col_GoodsShortName, typeof(string));
                //dt.Columns[ct_Col_GoodsShortName].DefaultValue = "";
				
                ////売上数計合計
                //dt.Columns.Add(ct_Col_TotalSalesCountTotal, typeof(double));
                //dt.Columns[ct_Col_TotalSalesCountTotal].DefaultValue = 0;
                ////売上数計平均
                //dt.Columns.Add(ct_Col_TotalSalesCountAve, typeof(double));
                //dt.Columns[ct_Col_TotalSalesCountAve].DefaultValue = 0;

				
                ////売上回数合計
                //dt.Columns.Add(ct_Col_SalesTimesTotal, typeof(Int32));
                //dt.Columns[ct_Col_SalesTimesTotal].DefaultValue = 0;
                ////売上回数平均
                //dt.Columns.Add(ct_Col_SalesTimesAve, typeof(double));
                //dt.Columns[ct_Col_SalesTimesAve].DefaultValue = 0;

                ////純売上合計1（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds1, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds1].DefaultValue = 0;
                ////純売上合計2（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds2, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds2].DefaultValue = 0;
                ////純売上合計3（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds3, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds3].DefaultValue = 0;
                ////純売上合計4（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds4, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds4].DefaultValue = 0;
                ////純売上合計5（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds5, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds5].DefaultValue = 0;
                ////純売上合計6（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds6, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds6].DefaultValue = 0;
                ////純売上合計7（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds7, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds7].DefaultValue = 0;
                ////純売上合計8（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds8, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds8].DefaultValue = 0;
                ////純売上合計9（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds9, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds9].DefaultValue = 0;
                ////純売上合計10（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds10, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds10].DefaultValue = 0;
                ////純売上合計11（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds11, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds11].DefaultValue = 0;
                ////純売上合計12（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceeds12, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceeds12].DefaultValue = 0;
                ////純売上合計合計（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceedsTotal, typeof(Int64));
                //dt.Columns[ct_Col_TotalProceedsTotal].DefaultValue = 0;
                ////純売上合計平均（税抜き）
                //dt.Columns.Add(ct_Col_TotalProceedsAve, typeof(double));
                //dt.Columns[ct_Col_TotalProceedsAve].DefaultValue = 0;

                ////粗利金額1
                //dt.Columns.Add(ct_Col_GrossProfit1, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit1].DefaultValue = 0;
                ////粗利金額2
                //dt.Columns.Add(ct_Col_GrossProfit2, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit2].DefaultValue = 0;
                ////粗利金額3
                //dt.Columns.Add(ct_Col_GrossProfit3, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit3].DefaultValue = 0;
                ////粗利金額4
                //dt.Columns.Add(ct_Col_GrossProfit4, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit4].DefaultValue = 0;
                ////粗利金額5
                //dt.Columns.Add(ct_Col_GrossProfit5, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit5].DefaultValue = 0;
                ////粗利金額6
                //dt.Columns.Add(ct_Col_GrossProfit6, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit6].DefaultValue = 0;
                ////粗利金額7
                //dt.Columns.Add(ct_Col_GrossProfit7, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit7].DefaultValue = 0;
                ////粗利金額8
                //dt.Columns.Add(ct_Col_GrossProfit8, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit8].DefaultValue = 0;
                ////粗利金額9
                //dt.Columns.Add(ct_Col_GrossProfit9, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit9].DefaultValue = 0;
                ////粗利金額10
                //dt.Columns.Add(ct_Col_GrossProfit10, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit10].DefaultValue = 0;
                ////粗利金額11
                //dt.Columns.Add(ct_Col_GrossProfit11, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit11].DefaultValue = 0;
                ////粗利金額12
                //dt.Columns.Add(ct_Col_GrossProfit12, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfit12].DefaultValue = 0;
                ////粗利金額合計
                //dt.Columns.Add(ct_Col_GrossProfitTotal, typeof(Int64));
                //dt.Columns[ct_Col_GrossProfitTotal].DefaultValue = 0;
                ////粗利金額平均
                //dt.Columns.Add(ct_Col_GrossProfitAve, typeof(double));
                //dt.Columns[ct_Col_GrossProfitAve].DefaultValue = 0;

                ////出荷平均ロット1
                //dt.Columns.Add(ct_Col_AveLot1, typeof(double));
                //dt.Columns[ct_Col_AveLot1].DefaultValue = 0;
                ////出荷平均ロット2
                //dt.Columns.Add(ct_Col_AveLot2, typeof(double));
                //dt.Columns[ct_Col_AveLot2].DefaultValue = 0;
                ////出荷平均ロット3
                //dt.Columns.Add(ct_Col_AveLot3, typeof(double));
                //dt.Columns[ct_Col_AveLot3].DefaultValue = 0;
                ////出荷平均ロット4
                //dt.Columns.Add(ct_Col_AveLot4, typeof(double));
                //dt.Columns[ct_Col_AveLot4].DefaultValue = 0;
                ////出荷平均ロット5
                //dt.Columns.Add(ct_Col_AveLot5, typeof(double));
                //dt.Columns[ct_Col_AveLot5].DefaultValue = 0;
                ////出荷平均ロット6
                //dt.Columns.Add(ct_Col_AveLot6, typeof(double));
                //dt.Columns[ct_Col_AveLot6].DefaultValue = 0;
                ////出荷平均ロット7
                //dt.Columns.Add(ct_Col_AveLot7, typeof(double));
                //dt.Columns[ct_Col_AveLot7].DefaultValue = 0;
                ////出荷平均ロット8
                //dt.Columns.Add(ct_Col_AveLot8, typeof(double));
                //dt.Columns[ct_Col_AveLot8].DefaultValue = 0;
                ////出荷平均ロット9
                //dt.Columns.Add(ct_Col_AveLot9, typeof(double));
                //dt.Columns[ct_Col_AveLot9].DefaultValue = 0;
                ////出荷平均ロット10
                //dt.Columns.Add(ct_Col_AveLot10, typeof(double));
                //dt.Columns[ct_Col_AveLot10].DefaultValue = 0;
                ////出荷平均ロット11
                //dt.Columns.Add(ct_Col_AveLot11, typeof(double));
                //dt.Columns[ct_Col_AveLot11].DefaultValue = 0;
                ////出荷平均ロット12
                //dt.Columns.Add(ct_Col_AveLot12, typeof(double));
                //dt.Columns[ct_Col_AveLot12].DefaultValue = 0;
                ////出荷平均ロット合計
                //dt.Columns.Add(ct_Col_AveLotTotal, typeof(double));
                //dt.Columns[ct_Col_AveLotTotal].DefaultValue = 0;
                ////出荷平均ロット平均
                //dt.Columns.Add(ct_Col_AveLotAve, typeof(double));
                //dt.Columns[ct_Col_AveLotAve].DefaultValue = 0;

                ////タグ
                //dt.Columns.Add(ct_Col_Tag, typeof(Int32));
                //dt.Columns[ct_Col_Tag].DefaultValue = 0;

                ////順位
                //dt.Columns.Add(ct_Col_OrderNo, typeof(Int32));
                //dt.Columns[ct_Col_OrderNo].DefaultValue = 0;

                ////拠点Field
                //dt.Columns.Add(ct_Col_SectionHeaderField, typeof(string));
                //dt.Columns[ct_Col_SectionHeaderField].DefaultValue = "";
                ////メーカーField
                //dt.Columns.Add(ct_Col_MakerField, typeof(string));
                //dt.Columns[ct_Col_MakerField].DefaultValue = "";
                ////商品区分Field
                //dt.Columns.Add(ct_Col_GoodsField, typeof(string));
                //dt.Columns[ct_Col_GoodsField].DefaultValue = "";
                ////BL商品Field
                //dt.Columns.Add(ct_Col_BlField, typeof(string));
                //dt.Columns[ct_Col_BlField].DefaultValue = "";
                ////得意先Field
                //dt.Columns.Add(ct_Col_CustomerField, typeof(string));
                //dt.Columns[ct_Col_CustomerField].DefaultValue = "";
                ////担当者Field
                //dt.Columns.Add(ct_Col_SalesEmployeeField, typeof(string));
                //dt.Columns[ct_Col_SalesEmployeeField].DefaultValue = "";

                ////SectionHeaderLine
                //dt.Columns.Add(ct_Col_SectionHeaderLine, typeof(string));
                //dt.Columns[ct_Col_SectionHeaderLine].DefaultValue = "";
                ////SectionHeaderLineName
                //dt.Columns.Add(ct_Col_SectionHeaderLineName, typeof(string));
                //dt.Columns[ct_Col_SectionHeaderLineName].DefaultValue = "";
                // --- DEL 2008/10/08 --------------------------------<<<<<
			}
		}
		#endregion
		#endregion
	}
}
