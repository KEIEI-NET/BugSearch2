//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上日報月報
// プログラム概要   ：売上日報月報を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/08/26     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：照田 貴志
// 修正日    2009/02/06     修正内容：不具合対応[10783]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/05/20     修正内容：Mantis【13309】拠点計の売上目標を追加
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：李亜博
// 修 正 日  2012/05/22  　 修正内容：06/27配信分、Redmine#29898
//                                    売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫・倉庫移動確認表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫・倉庫移動確認表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 96186 立花 裕輔</br>
	/// <br>Date       : 2007.03.14</br>
	/// <br></br>
	/// <br>Update Note: 2009/02/06 照田 貴志　不具合対応[10783]</br>
    /// <br>Update Note: 2012/05/22 李亜博</br>
    /// <br>管理番号   : 10801804-00 06/27配信分</br>
    /// <br>             Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
	/// </remarks>
	public class DCTOK02014EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_SalesDayMonthReportData = "Tbl_SalesDayMonthReportData";

        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> XXXコード(担当者/受注者/発行者/地区/業種/販売区分) </summary>
        public const string ct_Col_Code = "Code";
        /// <summary> XXX名称(担当者/受注者/発行者/地区/業種/販売区分)  </summary>
        public const string ct_Col_Name = "Name";
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
        /// <summary> 拠点コード </summary>
		public const string ct_Col_SectionCode = "SectionCode";
		/// <summary> 拠点ガイド名称 </summary>
		public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        // 2008.08.19 30413 犬飼 テーブルスキーマ削除 >>>>>>START
        ///// <summary> 部門コード </summary>
        //public const string ct_Col_SubSectionCode = "SubSectionCode";
        ///// <summary> 部門名称 </summary>
        //public const string ct_Col_SubSectionName = "SubSectionName";
        ///// <summary> 課コード </summary>
        //public const string ct_Col_MinSectionCode = "MinSectionCode";
        ///// <summary> 課名称 </summary>
        //public const string ct_Col_MinSectionName = "MinSectionName";
        ///// <summary> 販売エリアコード </summary>
        //public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        ///// <summary> 販売エリア名称 </summary>
        //public const string ct_Col_SalesAreaName = "SalesAreaName";
        ///// <summary> 業種コード </summary>
        //public const string ct_Col_BusinessTypeCode = "BusinessTypeCode";
        ///// <summary> 業種名称 </summary>
        //public const string ct_Col_BusinessTypeName = "BusinessTypeName";
        ///// <summary> 販売従業員コード </summary>
        //public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        ///// <summary> 販売従業員名称 </summary>
        //public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        ///// <summary> 受付従業員コード </summary>
        //public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        ///// <summary> 受付従業員名称 </summary>
        //public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        ///// <summary> 売上入力者コード </summary>
        //public const string ct_Col_SalesInputCode = "SalesInputCode";
        ///// <summary> 売上入力者名称 </summary>
        //public const string ct_Col_SalesInputName = "SalesInputName";
		/// <summary> 得意先コード </summary>
		public const string ct_Col_CustomerCode = "CustomerCode";
        ///// <summary> 得意先名称 </summary>
        //public const string ct_Col_CustomerName = "CustomerName";
        ///// <summary> 得意先名称2 </summary>
        //public const string ct_Col_CustomerName2 = "CustomerName2";
        // 2008.08.19 30413 犬飼 テーブルスキーマ削除 <<<<<<END
        /// <summary> 得意先略称 </summary>
		public const string ct_Col_CustomerSnm = "CustomerSnm";
		/// <summary> 期間伝票枚数 </summary>
		public const string ct_Col_TermSalesSlipCount = "TermSalesSlipCount";
		/// <summary> 期間売上合計（税抜き） </summary>
		public const string ct_Col_TermSalesTotalTaxExc = "TermSalesTotalTaxExc";
		/// <summary> 期間返品合計（税抜き） </summary>
		public const string ct_Col_TermSalesBackTotalTaxExc = "TermSalesBackTotalTaxExc";
		/// <summary> 期間値引合計（税抜き） </summary>
		public const string ct_Col_TermSalesDisTtlTaxExc = "TermSalesDisTtlTaxExc";
		/// <summary> 期間原価合計 </summary>
		public const string ct_Col_TermTotalCost = "TermTotalCost";
        /// <summary> 月次伝票枚数 </summary>
		public const string ct_Col_MonthSalesSlipCount = "MonthSalesSlipCount";
		/// <summary> 月次売上合計（税抜き） </summary>
		public const string ct_Col_MonthSalesTotalTaxExc = "MonthSalesTotalTaxExc";
		/// <summary> 月次返品合計（税抜き） </summary>
		public const string ct_Col_MonthSalesBackTotalTaxExc = "MonthSalesBackTotalTaxExc";
		/// <summary> 月次値引合計（税抜き） </summary>
		public const string ct_Col_MonthSalesDisTtlTaxExc = "MonthSalesDisTtlTaxExc";
		/// <summary> 月次原価合計 </summary>
		public const string ct_Col_MonthTotalCost = "MonthTotalCost";
        // 2008.08.19 30413 犬飼 テーブルスキーマ削除 >>>>>>START
        ///// <summary> 売上目標金額 </summary>
        //public const string ct_Col_SalesTargetMoney = "SalesTargetMoney";
        ///// <summary> 売上目標粗利額 </summary>
        //public const string ct_Col_SalesTargetProfit = "SalesTargetProfit";
        // 2008.08.19 30413 犬飼 テーブルスキーマ削除 <<<<<<END
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> 月次売上目標 </summary>
        public const string ct_Col_MonthSalesTargetMoney = "MonthSalesTargetMoney";
        /// <summary> 月次粗利目標 </summary>
        public const string ct_Col_MonthSalesTargetProfit = "MonthSalesTargetProfit";
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
        
		/// <summary> 期間返品率 </summary>
		public const string ct_Col_TermSalesBackTotalTaxRate = "TermSalesBackTotalTaxRate";
		/// <summary> 月次返品率 </summary>
		public const string ct_Col_MonthSalesBackTotalTaxRate = "MonthSalesBackTotalTaxRate";
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> 月次売上進捗率 </summary>
        public const string ct_Col_MonthProgressSalesRate = "MonthProgressSalesRate";
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
        /// <summary> 月次売上達成率 </summary>
        public const string ct_Col_MonthTargetSalesRate = "MonthTargetSalesRate";
        /// <summary> 期間粗利益 </summary>
		public const string ct_Col_TermProfit = "TermProfit";
		/// <summary> 月次粗利益 </summary>
		public const string ct_Col_MonthProfit = "MonthProfit";
		/// <summary> 期間粗利率 </summary>
		public const string ct_Col_TermProfitRate = "TermProfitRate";
		/// <summary> 月次粗利率 </summary>
		public const string ct_Col_MonthProfitRate = "MonthProfitRate";
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> 月次粗利進捗率 </summary>
        public const string ct_Col_MonthProgressProfitRate = "MonthProgressProfitRate";
        // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
        /// <summary> 月次粗利達成率 </summary>
		public const string ct_Col_MonthTargetProfitRate = "MonthTargetProfitRate";

		/// <summary> 期間売上正価金額 </summary>
		public const string ct_Col_TermSalesNetPrice = "TermSalesNetPrice";
		/// <summary> 期間返品正価金額 </summary>
		public const string ct_Col_TermSalesBackNetPrice = "TermSalesBackNetPrice";
		/// <summary> 月次売上正価金額 </summary>
		public const string ct_Col_MonthSalesNetPrice = "MonthSalesNetPrice";
		/// <summary> 月次返品正価金額 </summary>
		public const string ct_Col_MonthSalesBackNetPrice = "MonthSalesBackNetPrice";
		/// <summary> 期間純売上額 </summary>
		public const string ct_Col_TermPureSalesTotalCost = "TermPureSalesTotalCost";
		/// <summary> 月次純売上額 </summary>
		public const string ct_Col_MonthPureSalesTotalCost = "MonthPureSalesTotalCost";


		/// <summary> DailyHeaderField </summary>
		public const string ct_Col_DailyHeaderField = "DailyHeaderField";
		/// <summary> WareHouseHeaderField </summary>
		public const string ct_Col_WareHouseHeaderField = "WareHouseHeaderField";
		/// <summary> SectionHeaderField </summary>
		public const string ct_Col_SectionHeaderField = "SectionHeaderField";

		/// <summary> SectionHeaderLine </summary>
		public const string ct_Col_SectionHeaderLine = "SectionHeaderLine";
		/// <summary> WareHouseHeaderLine </summary>
		public const string ct_Col_WareHouseHeaderLine = "WareHouseHeaderLine";
		/// <summary> DailyHeaderLine </summary>
		public const string ct_Col_DailyHeaderLine = "DailyHeaderLine";
		/// <summary> DetailLine </summary>
		public const string ct_Col_DetailLine = "DetailLine";

		/// <summary> SectionHeaderLineName </summary>
		public const string ct_Col_SectionHeaderLineName = "SectionHeaderLineName";
		/// <summary> WareHouseHeaderLineName </summary>
		public const string ct_Col_WareHouseHeaderLineName = "WareHouseHeaderLineName";
		/// <summary> DailyHeaderLineName </summary>
		public const string ct_Col_DailyHeaderLineName = "DailyHeaderLineName";
		/// <summary> DetailLineName </summary>
		public const string ct_Col_DetailLineName = "DetailLineName";

        // 2008.08.26 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> WareHouseHeaderTypeLineTitle </summary>
        public const string ct_Col_WareHouseHeaderTypeLineTitle = "WareHouseHeaderTypeLineTitle";
        /// <summary> WareHouseHeaderTypeLine </summary>
        public const string ct_Col_WareHouseHeaderTypeLine = "WareHouseHeaderTypeLine";
        /// <summary> WareHouseHeaderTypeLineName </summary>
        public const string ct_Col_WareHouseHeaderTypeLineName = "WareHouseHeaderTypeLineName";
        // 2008.08.26 30413 犬飼 テーブルスキーマ追加 <<<<<<END

        // 2008.08.27 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> 当月営業日数 </summary>
        public const string ct_Col_WorkDays = "WorkDays";
        /// <summary> 対象営業日数 </summary>
        public const string ct_Col_ProgressDays = "ProgressDays";
        // 2008.08.27 30413 犬飼 テーブルスキーマ追加 <<<<<<END

        // 2008.08.28 30413 犬飼 テーブルスキーマ追加 >>>>>>START
        /// <summary> 自拠点当月営業日数 </summary>
        public const string ct_Col_SelfSectionWorkDays = "SelfSectionWorkDays";
        /// <summary> 自拠点対象営業日数 </summary>
        public const string ct_Col_SelfSectionProgressDays = "SelfSectionProgressDays";
        // 2008.08.28 30413 犬飼 テーブルスキーマ追加 <<<<<<END

        // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
        /// <summary> 管理拠点当月営業日数 </summary>
        public const string ct_Col_MngSectionWorkDays = "MngSectionWorkDays";
        /// <summary> 管理拠点対象営業日数 </summary>
        public const string ct_Col_MngSectionProgressDays = "MngSectionProgressDays";
        // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<

        // ---ADD 2009/02/06 不具合対応[10783] -------------------------------------------->>>>>
        public const string ct_Col_SortSectionCode = "SortSectionCode";         // ソート用拠点
        public const string ct_Col_SortCustomerCode = "SortCustomerCode";       // ソート用得意先
        public const string ct_Col_SortCode = "SortCode";                       // ソート用汎用コード
        // ---ADD 2009/02/06 不具合対応[10783] --------------------------------------------<<<<<

        // ADD 2009/05/20 ------>>>
        /// <summary>月間純売上目標額(拠点計用)</summary>
        public const string CT_SectionTargetMoney = "SectionTargetMoney";
        /// <summary>月間粗利目標額(拠点計)</summary>
        public const string CT_SectionTargetProfit = "SectionTargetProfit";
        // ADD 2009/05/20 ------<<<
        
		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫・倉庫移動確認表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動確認表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public DCTOK02014EA()
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
        /// <br>Update Note: 2012/05/22 李亜博</br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        /// </remarks>
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
				dt = new DataTable(ct_Tbl_SalesDayMonthReportData);

                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //XXXコード(担当者/受注者/発行者/地区/業種/販売区分)
                dt.Columns.Add(ct_Col_Code, typeof(string));
                dt.Columns[ct_Col_Code].DefaultValue = "";
                //XXX名称(担当者/受注者/発行者/地区/業種/販売区分)
                dt.Columns.Add(ct_Col_Name, typeof(string));
                dt.Columns[ct_Col_Name].DefaultValue = "";
                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
                //拠点コード
				dt.Columns.Add(ct_Col_SectionCode, typeof(string));
				dt.Columns[ct_Col_SectionCode].DefaultValue = "";
				//拠点ガイド名称
				dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
				dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                // 2008.08.19 30413 犬飼 テーブルスキーマ削除 >>>>>>START
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
                ////販売エリアコード
                //dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
                //dt.Columns[ct_Col_SalesAreaCode].DefaultValue = 0;
                ////販売エリア名称
                //dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
                //dt.Columns[ct_Col_SalesAreaName].DefaultValue = "";
                ////業種コード
                //dt.Columns.Add(ct_Col_BusinessTypeCode, typeof(Int32));
                //dt.Columns[ct_Col_BusinessTypeCode].DefaultValue = 0;
                ////業種名称
                //dt.Columns.Add(ct_Col_BusinessTypeName, typeof(string));
                //dt.Columns[ct_Col_BusinessTypeName].DefaultValue = "";
                ////販売従業員コード
                //dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
                //dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = "";
                ////販売従業員名称
                //dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
                //dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = "";
                ////受付従業員コード
                //dt.Columns.Add(ct_Col_FrontEmployeeCd, typeof(string));
                //dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = "";
                ////受付従業員名称
                //dt.Columns.Add(ct_Col_FrontEmployeeNm, typeof(string));
                //dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = "";
                ////売上入力者コード
                //dt.Columns.Add(ct_Col_SalesInputCode, typeof(string));
                //dt.Columns[ct_Col_SalesInputCode].DefaultValue = "";
                ////売上入力者名称
                //dt.Columns.Add(ct_Col_SalesInputName, typeof(string));
                //dt.Columns[ct_Col_SalesInputName].DefaultValue = "";
				//得意先コード
				dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
				dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                ////得意先名称
                //dt.Columns.Add(ct_Col_CustomerName, typeof(string));
                //dt.Columns[ct_Col_CustomerName].DefaultValue = "";
                ////得意先名称2
                //dt.Columns.Add(ct_Col_CustomerName2, typeof(string));
                //dt.Columns[ct_Col_CustomerName2].DefaultValue = "";
                // 2008.08.19 30413 犬飼 テーブルスキーマ削除 <<<<<<END
                //得意先略称
				dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
				dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";
				//期間伝票枚数
				dt.Columns.Add(ct_Col_TermSalesSlipCount, typeof(Int32));
				dt.Columns[ct_Col_TermSalesSlipCount].DefaultValue = 0;
				//期間売上合計（税抜き）
				dt.Columns.Add(ct_Col_TermSalesTotalTaxExc, typeof(Int64));
				dt.Columns[ct_Col_TermSalesTotalTaxExc].DefaultValue = 0;
				//期間返品合計（税抜き）
				dt.Columns.Add(ct_Col_TermSalesBackTotalTaxExc, typeof(Int64));
				dt.Columns[ct_Col_TermSalesBackTotalTaxExc].DefaultValue = 0;
				//期間値引合計（税抜き）
				dt.Columns.Add(ct_Col_TermSalesDisTtlTaxExc, typeof(Int64));
				dt.Columns[ct_Col_TermSalesDisTtlTaxExc].DefaultValue = 0;
				//期間原価合計
				dt.Columns.Add(ct_Col_TermTotalCost, typeof(Int64));
				dt.Columns[ct_Col_TermTotalCost].DefaultValue = 0;
                //月次伝票枚数
				dt.Columns.Add(ct_Col_MonthSalesSlipCount, typeof(Int32));
				dt.Columns[ct_Col_MonthSalesSlipCount].DefaultValue = 0;
				//月次売上合計（税抜き）
				dt.Columns.Add(ct_Col_MonthSalesTotalTaxExc, typeof(Int64));
				dt.Columns[ct_Col_MonthSalesTotalTaxExc].DefaultValue = 0;
				//月次返品合計（税抜き）
				dt.Columns.Add(ct_Col_MonthSalesBackTotalTaxExc, typeof(Int64));
				dt.Columns[ct_Col_MonthSalesBackTotalTaxExc].DefaultValue = 0;
				//月次値引合計（税抜き）
				dt.Columns.Add(ct_Col_MonthSalesDisTtlTaxExc, typeof(Int64));
				dt.Columns[ct_Col_MonthSalesDisTtlTaxExc].DefaultValue = 0;
				//月次原価合計
				dt.Columns.Add(ct_Col_MonthTotalCost, typeof(Int64));
				dt.Columns[ct_Col_MonthTotalCost].DefaultValue = 0;
                // 2008.08.19 30413 犬飼 テーブルスキーマ削除 >>>>>>START
                ////売上目標金額
                //dt.Columns.Add(ct_Col_SalesTargetMoney, typeof(Int64));
                //dt.Columns[ct_Col_SalesTargetMoney].DefaultValue = 0;
                ////売上目標粗利額
                //dt.Columns.Add(ct_Col_SalesTargetProfit, typeof(Int64));
                //dt.Columns[ct_Col_SalesTargetProfit].DefaultValue = 0;
                // 2008.08.19 30413 犬飼 テーブルスキーマ削除 <<<<<<END
                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //月次売上目標
                dt.Columns.Add(ct_Col_MonthSalesTargetMoney, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesTargetMoney].DefaultValue = 0;
                //月次粗利目標
                dt.Columns.Add(ct_Col_MonthSalesTargetProfit, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesTargetProfit].DefaultValue = 0;
                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END

				//期間返品率
				dt.Columns.Add(ct_Col_TermSalesBackTotalTaxRate, typeof(double));
				dt.Columns[ct_Col_TermSalesBackTotalTaxRate].DefaultValue = 0;
				//月次返品率
				dt.Columns.Add(ct_Col_MonthSalesBackTotalTaxRate, typeof(double));
				dt.Columns[ct_Col_MonthSalesBackTotalTaxRate].DefaultValue = 0;

                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //月次売上進捗率
                dt.Columns.Add(ct_Col_MonthProgressSalesRate, typeof(double));
                dt.Columns[ct_Col_MonthProgressSalesRate].DefaultValue = 0;
                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
                //月次売上達成率
				dt.Columns.Add(ct_Col_MonthTargetSalesRate, typeof(double));
				dt.Columns[ct_Col_MonthTargetSalesRate].DefaultValue = 0;
				//期間粗利益
				dt.Columns.Add(ct_Col_TermProfit, typeof(Int64));
				dt.Columns[ct_Col_TermProfit].DefaultValue = 0;
				//月次粗利益
				dt.Columns.Add(ct_Col_MonthProfit, typeof(Int64));
				dt.Columns[ct_Col_MonthProfit].DefaultValue = 0;
				//期間粗利率
				dt.Columns.Add(ct_Col_TermProfitRate, typeof(double));
				dt.Columns[ct_Col_TermProfitRate].DefaultValue = 0;
				//月次粗利率
				dt.Columns.Add(ct_Col_MonthProfitRate, typeof(double));
				dt.Columns[ct_Col_MonthProfitRate].DefaultValue = 0;
                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //月次粗利進捗率
                dt.Columns.Add(ct_Col_MonthProgressProfitRate, typeof(double));
                dt.Columns[ct_Col_MonthProgressProfitRate].DefaultValue = 0;
                // 2008.08.19 30413 犬飼 テーブルスキーマ追加 <<<<<<END
                //月次粗利達成率
				dt.Columns.Add(ct_Col_MonthTargetProfitRate, typeof(double));
				dt.Columns[ct_Col_MonthTargetProfitRate].DefaultValue = 0;

				//期間売上正価金額
				dt.Columns.Add(ct_Col_TermSalesNetPrice, typeof(Int64));
				dt.Columns[ct_Col_TermSalesNetPrice].DefaultValue = 0;
				//期間返品正価金額
				dt.Columns.Add(ct_Col_TermSalesBackNetPrice, typeof(Int64));
				dt.Columns[ct_Col_TermSalesBackNetPrice].DefaultValue = 0;
				//月次売上正価金額
				dt.Columns.Add(ct_Col_MonthSalesNetPrice, typeof(Int64));
				dt.Columns[ct_Col_MonthSalesNetPrice].DefaultValue = 0;
				//月次返品正価金額
				dt.Columns.Add(ct_Col_MonthSalesBackNetPrice, typeof(Int64));
				dt.Columns[ct_Col_MonthSalesBackNetPrice].DefaultValue = 0;

				//期間純売上額
				dt.Columns.Add(ct_Col_TermPureSalesTotalCost, typeof(Int64));
				dt.Columns[ct_Col_TermPureSalesTotalCost].DefaultValue = 0;
				//月次純売上額
				dt.Columns.Add(ct_Col_MonthPureSalesTotalCost, typeof(Int64));
				dt.Columns[ct_Col_MonthPureSalesTotalCost].DefaultValue = 0;

				//DailyHeaderField
				dt.Columns.Add(ct_Col_DailyHeaderField, typeof(string));
				dt.Columns[ct_Col_DailyHeaderField].DefaultValue = "";
				//WareHouseHeaderField
				dt.Columns.Add(ct_Col_WareHouseHeaderField, typeof(string));
				dt.Columns[ct_Col_WareHouseHeaderField].DefaultValue = "";
				//SectionHeaderField
				dt.Columns.Add(ct_Col_SectionHeaderField, typeof(string));
				dt.Columns[ct_Col_SectionHeaderField].DefaultValue = "";

				//DailyHeaderLine
				dt.Columns.Add(ct_Col_DailyHeaderLine, typeof(string));
				dt.Columns[ct_Col_DailyHeaderLine].DefaultValue = "";
				//DailyHeaderLineName
				dt.Columns.Add(ct_Col_DailyHeaderLineName, typeof(string));
				dt.Columns[ct_Col_DailyHeaderLineName].DefaultValue = "";
				//WareHouseHeaderLine
				dt.Columns.Add(ct_Col_WareHouseHeaderLine, typeof(string));
				dt.Columns[ct_Col_WareHouseHeaderLine].DefaultValue = "";
				//WareHouseHeaderLineName
				dt.Columns.Add(ct_Col_WareHouseHeaderLineName, typeof(string));
				dt.Columns[ct_Col_WareHouseHeaderLineName].DefaultValue = "";
				//SectionHeaderLine
				dt.Columns.Add(ct_Col_SectionHeaderLine, typeof(string));
				dt.Columns[ct_Col_SectionHeaderLine].DefaultValue = "";
				//SectionHeaderLineName
				dt.Columns.Add(ct_Col_SectionHeaderLineName, typeof(string));
				dt.Columns[ct_Col_SectionHeaderLineName].DefaultValue = "";
				//DetailLine
				dt.Columns.Add(ct_Col_DetailLine, typeof(string));
				dt.Columns[ct_Col_DetailLine].DefaultValue = "";
				//DetailLineName
				dt.Columns.Add(ct_Col_DetailLineName, typeof(string));
				dt.Columns[ct_Col_DetailLineName].DefaultValue = "";

                // 2008.08.26 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //WareHouseHeaderTypeLineTitle
                dt.Columns.Add(ct_Col_WareHouseHeaderTypeLineTitle, typeof(string));
                dt.Columns[ct_Col_WareHouseHeaderTypeLineTitle].DefaultValue = "";
                //WareHouseHeaderTypeLineTitle
                dt.Columns.Add(ct_Col_WareHouseHeaderTypeLine, typeof(string));
                dt.Columns[ct_Col_WareHouseHeaderTypeLine].DefaultValue = "";
                //WareHouseHeaderTypeLineTitle
                dt.Columns.Add(ct_Col_WareHouseHeaderTypeLineName, typeof(string));
                dt.Columns[ct_Col_WareHouseHeaderTypeLineName].DefaultValue = "";
                // 2008.08.26 30413 犬飼 テーブルスキーマ追加 <<<<<<END

                // 2008.08.27 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //当月営業日数
                dt.Columns.Add(ct_Col_WorkDays, typeof(Int32));
                dt.Columns[ct_Col_WorkDays].DefaultValue = 0;
                //対象営業日数
                dt.Columns.Add(ct_Col_ProgressDays, typeof(Int32));
                dt.Columns[ct_Col_ProgressDays].DefaultValue = 0;
                // 2008.08.27 30413 犬飼 テーブルスキーマ追加 <<<<<<END

                // 2008.08.28 30413 犬飼 テーブルスキーマ追加 >>>>>>START
                //自拠点当月営業日数
                dt.Columns.Add(ct_Col_SelfSectionWorkDays, typeof(Int32));
                dt.Columns[ct_Col_SelfSectionWorkDays].DefaultValue = 0;
                //自拠点対象営業日数
                dt.Columns.Add(ct_Col_SelfSectionProgressDays, typeof(Int32));
                dt.Columns[ct_Col_SelfSectionProgressDays].DefaultValue = 0;
                // 2008.08.28 30413 犬飼 テーブルスキーマ追加 <<<<<<END

                // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
                //管理拠点当月営業日数
                dt.Columns.Add(ct_Col_MngSectionWorkDays, typeof(Int32));
                dt.Columns[ct_Col_MngSectionWorkDays].DefaultValue = 0;
                //管理拠点対象営業日数
                dt.Columns.Add(ct_Col_MngSectionProgressDays, typeof(Int32));
                dt.Columns[ct_Col_MngSectionProgressDays].DefaultValue = 0;
                // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<

                // ---ADD 2009/02/06 不具合対応[10783] ----------------------------------->>>>>
                //ソート用拠点
                dt.Columns.Add(ct_Col_SortSectionCode, typeof(string));
                dt.Columns[ct_Col_SortSectionCode].DefaultValue = "";
                //ソート用得意先
                dt.Columns.Add(ct_Col_SortCustomerCode, typeof(string));
                dt.Columns[ct_Col_SortCustomerCode].DefaultValue = "";
                //ソート用汎用コード
                dt.Columns.Add(ct_Col_SortCode, typeof(string));
                dt.Columns[ct_Col_SortCode].DefaultValue = "";
                // ---ADD 2009/02/06 不具合対応[10783] ----------------------------------->>>>>

                // ADD 2009/05/20 ------>>>
                /// <summary>月間純売上目標額(拠点計用)</summary>
                dt.Columns.Add(CT_SectionTargetMoney, typeof(Int64));
                dt.Columns[CT_SectionTargetMoney].DefaultValue = 0;
                /// <summary>月間粗利目標額(拠点計)</summary>
                dt.Columns.Add(CT_SectionTargetProfit, typeof(Int64));
                dt.Columns[CT_SectionTargetProfit].DefaultValue = 0;
                // ADD 2009/05/20 ------<<<
            }
		}
		#endregion
		#endregion
	}
}
