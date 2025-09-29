using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 回収予定表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 回収予定表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 20081 疋田　勇人</br>
	/// <br>Date       : 2007.10.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class DCKAU02524EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_RsltInfo_CollectPlan = "Tbl_RsltInfo_CollectPlan";

        /// <summary> 計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 計上拠点名称 </summary>
        public const string Col_AddUpSecName = "AddUpSecName";

        /// <summary> 計上拠点名称(明細用) </summary>
        public const string Col_AddUpSecName_Detail = "AddUpSecName_Detail";

        /// <summary>請求先コード</summary>
        public const string Col_ClaimCode = "ClaimCode";

        /// <summary>請求先名称</summary>
        public const string Col_ClaimName = "ClaimName";

        /// <summary>請求先名称2</summary>
        public const string Col_ClaimName2 = "ClaimName2";

        /// <summary>請求先略称</summary>
        public const string Col_ClaimSnm = "ClaimSnm";

        /// <summary> 計上年月日 </summary>
        public const string Col_AddUpDate = "AddUpDate";

        /// <summary> ソート用計上年月日 </summary>
        public const string Col_Sort_AddUpDate = "Sort_AddUpDate";

        /// <summary> 計上年月 </summary>
        public const string Col_AddUpYearMonth = "AddUpYearMonth";

        /// <summary> ソート用計上年月 </summary>
        public const string Col_Sort_AddUpYearMonth = "Sort_AddUpYearMonth";

        /// <summary> 前回請求金額 </summary>
        public const string Col_LastTimeDemand = "LastTimeDemand";

        ///// <summary> 今回手数料額（通常入金）</summary>
        //public const string Col_ThisTimeFeeDmdNrml = "ThisTimeFeeDmdNrml";

        ///// <summary> 今回値引額（通常入金） </summary>
        //public const string Col_ThisTimeDisDmdNrml = "ThisTimeDisDmdNrml";

        /// <summary> 今回入金金額（通常入金） </summary>
        public const string Col_ThisTimeDmdNrml = "ThisTimeDmdNrml";

        ///// <summary> 今回繰越残高（請求計） </summary>
        //public const string Col_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";

        /// <summary> 相殺後今回売上金額 </summary>
        public const string Col_OfsThisTimeSales = "OfsThisTimeSales";

        /// <summary> 相殺後今回売上消費税 </summary>
        public const string Col_OfsThisSalesTax = "OfsThisSalesTax";

        ///// <summary> 消費税調整額</summary>
        //public const string Col_TaxAdjust = "TaxAdjust";

        ///// <summary> 残高調整額</summary>
        //public const string Col_BalanceAdjust = "BalanceAdjust";

        ///// <summary> 計算後請求金額</summary>
        //public const string Col_AfCalDemandPrice = "AfCalDemandPrice";

        /// <summary> 受注2回前残高（請求計）</summary>
        public const string Col_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";

        /// <summary> 受注3回前残高（請求計）</summary>
        public const string Col_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";

        ///// <summary> 入金予定日 </summary>
        //public const string Col_ExpectedDepositDate = "ExpectedDepositDate";

        /// <summary> 回収条件 </summary>
        public const string Col_CollectCond = "CollectCond";

        /// <summary> 回収サイト </summary>
        public const string Col_CollectSight = "CollectSight";

        /// <summary> 集金担当従業員コード </summary>
        public const string Col_BillCollecterCd = "BillCollecterCd";

        /// <summary> 集金担当従業員名称 </summary>
        public const string Col_BillCollecterNm = "BillCollecterNm";

        /// <summary> 顧客担当従業員コード </summary>
        public const string Col_CustomerAgentCd = "CustomerAgentCd";

        /// <summary> 顧客担当従業員名称 </summary>
        public const string Col_CustomerAgentNm = "CustomerAgentNm";

        /// <summary> 販売エリアコード </summary>
        public const string Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> 販売エリア名称 </summary>
        public const string Col_SalesAreaName = "SalesAreaName";

        ///// <summary> 回収対象 </summary>
        //public const string Col_CollectTarget = "CollectTarget";

        /// <summary> 締後入金額 </summary>
        public const string Col_AfterCloseDemand = "AfterCloseDemand";

        /// <summary> 残高合計 </summary>
        public const string Col_TotalAdjust = "TotalAdjust";

        /// <summary> 予定額 </summary>
        public const string Col_TotalExpct = "TotalExpct";

        /// <summary> 回収率 </summary>
        public const string Col_CollectRate = "CollectRate";

        /// <summary> 回収実績(集金日以降に入金した金額を集計) </summary>
        public const string Col_AfterScheduleDemand = "AfterScheduleDemand";

        /// <summary> 未回収額 </summary>
        public const string Col_NonCollect = "NonCollect";

        // 2008.11.11 30413 犬飼 追加 >>>>>>START
        /// <summary> 今回売上返品金額 </summary>
        public const string Col_ThisSalesPricRgds = "ThisSalesPricRgds";

        /// <summary> 今回売上値引金額 </summary>
        public const string Col_ThisSalesPricDis = "ThisSalesPricDis";

        /// <summary> 集金月区分コード </summary>
        public const string Col_CollectMoneyCode = "CollectMoneyCode";

        /// <summary> 集金月区分名称 </summary>
        public const string Col_CollectMoneyName = "CollectMoneyName";

        /// <summary> 集金日 </summary>
        public const string Col_CollectMoneyDay = "CollectMoneyDay";

        /// <summary> 回収予定区分 </summary>
        public const string Col_CollectPlnDiv = "CollectPlnDiv";

        /// <summary> 今回売上額(計算用) </summary>
        public const string Col_CalcThisTimeSales = "CalcThisTimeSales";

        /// <summary> 対象額(計算用) </summary>
        public const string Col_CalcObjPric = "CalcObjPric";

        /// <summary> マーク </summary>
        public const string Col_CollectMark = "CollectMark";
        
        /// <summary> 締後回収日 </summary>
        public const string Col_CalcCollectDay = "CalcCollectDay";

        /// <summary> 地区コード(印刷用) </summary>
        public const string Col_SalesAreaCodePrint = "SalesAreaCodePrint";

        /// <summary> 回収条件名称 </summary>
        public const string Col_CollectCondName = "CollectCondName";
        // 2008.11.11 30413 犬飼 追加 <<<<<<END
        

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 回収予定表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 回収予定表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
        public DCKAU02524EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
        static public void CreateDataTableCollectPlanMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_RsltInfo_CollectPlan))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_RsltInfo_CollectPlan].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_RsltInfo_CollectPlan);

                DataTable dt = ds.Tables[Col_Tbl_RsltInfo_CollectPlan];

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));		            // 計上拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName, typeof(string));	            	// 計上拠点名称
                dt.Columns[Col_AddUpSecName].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName_Detail, typeof(string));		    // 計上拠点名称(明細)
                dt.Columns[Col_AddUpSecName_Detail].DefaultValue = "";

                dt.Columns.Add(Col_ClaimCode, typeof(int));  			            // 請求先コード
                dt.Columns[Col_ClaimCode].DefaultValue = 0;

                dt.Columns.Add(Col_ClaimName, typeof(string));		                // 請求先名称
                dt.Columns[Col_ClaimName].DefaultValue = "";

                dt.Columns.Add(Col_ClaimName2, typeof(string));		                // 請求先名称2
                dt.Columns[Col_ClaimName2].DefaultValue = "";

                dt.Columns.Add(Col_ClaimSnm, typeof(string));		                // 請求先略称
                dt.Columns[Col_ClaimSnm].DefaultValue = "";

                dt.Columns.Add(Col_AddUpDate, typeof(string));		                // 計上年月日
                dt.Columns[Col_AddUpDate].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpDate, typeof(long));		            // ソート用計上年月日
                dt.Columns[Col_Sort_AddUpDate].DefaultValue = 0;

                dt.Columns.Add(Col_AddUpYearMonth, typeof(string));		            // 計上年月
                dt.Columns[Col_AddUpYearMonth].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpYearMonth, typeof(long));		        // ソート用計上年月
                dt.Columns[Col_Sort_AddUpYearMonth].DefaultValue = 0;

                dt.Columns.Add(Col_LastTimeDemand, typeof(long));		            // 前回請求金額
                dt.Columns[Col_LastTimeDemand].DefaultValue = 0;

                //dt.Columns.Add(Col_ThisTimeFeeDmdNrml, typeof(long));		        // 今回手数料額（通常入金）
                //dt.Columns[Col_ThisTimeFeeDmdNrml].DefaultValue = 0;

                //dt.Columns.Add(Col_ThisTimeDisDmdNrml, typeof(long));		        // 今回値引額（通常入金）
                //dt.Columns[Col_ThisTimeDisDmdNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDmdNrml, typeof(long));		            // 今回入金金額（通常入金）
                dt.Columns[Col_ThisTimeDmdNrml].DefaultValue = 0;

                //dt.Columns.Add(Col_ThisTimeTtlBlcDmd, typeof(long));		        // 今回繰越残高（請求計）
                //dt.Columns[Col_ThisTimeTtlBlcDmd].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisTimeSales, typeof(long));		            // 相殺後今回売上金額
                dt.Columns[Col_OfsThisTimeSales].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisSalesTax, typeof(long));		            // 相殺後今回売上消費税
                dt.Columns[Col_OfsThisSalesTax].DefaultValue = 0;

                //dt.Columns.Add(Col_TaxAdjust, typeof(long));		                // 消費税調整額
                //dt.Columns[Col_TaxAdjust].DefaultValue = 0;

                //dt.Columns.Add(Col_BalanceAdjust, typeof(long));		            // 残高調整額
                //dt.Columns[Col_BalanceAdjust].DefaultValue = 0;

                //dt.Columns.Add(Col_AfCalDemandPrice, typeof(long));		            // 計算後請求金額
                //dt.Columns[Col_AfCalDemandPrice].DefaultValue = 0;

                dt.Columns.Add(Col_AcpOdrTtl2TmBfBlDmd, typeof(long));		        // 受注2回前残高（請求計）
                dt.Columns[Col_AcpOdrTtl2TmBfBlDmd].DefaultValue = 0;

                dt.Columns.Add(Col_AcpOdrTtl3TmBfBlDmd, typeof(long));		        // 受注3回前残高（請求計）
                dt.Columns[Col_AcpOdrTtl3TmBfBlDmd].DefaultValue = 0;

                //dt.Columns.Add(Col_ExpectedDepositDate, typeof(string));		    // 入金予定日
                //dt.Columns[Col_ExpectedDepositDate].DefaultValue = "";

                dt.Columns.Add(Col_CollectCond, typeof(string));		            // 回収条件
                dt.Columns[Col_CollectCond].DefaultValue = "";

                dt.Columns.Add(Col_CollectSight, typeof(string));		            // 回収サイト
                dt.Columns[Col_CollectSight].DefaultValue = "";

                dt.Columns.Add(Col_BillCollecterCd, typeof(string));			    // 集金担当従業員コード
                dt.Columns[Col_BillCollecterCd].DefaultValue = "";

                dt.Columns.Add(Col_BillCollecterNm, typeof(string));		        // 集金担当従業員名称
                dt.Columns[Col_BillCollecterNm].DefaultValue = "";

                dt.Columns.Add(Col_CustomerAgentCd, typeof(string));			    // 顧客担当従業員コード
                dt.Columns[Col_CustomerAgentCd].DefaultValue = "";

                dt.Columns.Add(Col_CustomerAgentNm, typeof(string));		        // 顧客担当従業員名称
                dt.Columns[Col_CustomerAgentNm].DefaultValue = "";

                dt.Columns.Add(Col_SalesAreaCode, typeof(int));			            // 販売エリアコード
                dt.Columns[Col_CustomerAgentCd].DefaultValue = 0;

                dt.Columns.Add(Col_SalesAreaName, typeof(string));		            // 販売エリア名称
                dt.Columns[Col_SalesAreaName].DefaultValue = "";

                //dt.Columns.Add(Col_CollectTarget, typeof(long));		            // 回収対象
                //dt.Columns[Col_CollectTarget].DefaultValue = 0;

                dt.Columns.Add(Col_AfterCloseDemand, typeof(long));		            // 締後入金額
                dt.Columns[Col_AfterCloseDemand].DefaultValue = 0;

                dt.Columns.Add(Col_TotalAdjust, typeof(long));		                // 残高合計
                dt.Columns[Col_TotalAdjust].DefaultValue = 0;

                dt.Columns.Add(Col_TotalExpct, typeof(long));		                // 予定額
                dt.Columns[Col_TotalExpct].DefaultValue = 0;

                dt.Columns.Add(Col_CollectRate, typeof(double));		            // 回収率
                dt.Columns[Col_CollectRate].DefaultValue = 0;

                dt.Columns.Add(Col_AfterScheduleDemand, typeof(long));		        // 回収実績(集金日以降に入金した金額を集計)
                dt.Columns[Col_AfterScheduleDemand].DefaultValue = 0;

                dt.Columns.Add(Col_NonCollect, typeof(long));		                // 未回収額
                dt.Columns[Col_NonCollect].DefaultValue = 0;

                // 2008.11.11 30413 犬飼 追加 >>>>>>START
                dt.Columns.Add(Col_ThisSalesPricRgds, typeof(Int64));               // 今回売上返品金額
                dt.Columns[Col_ThisSalesPricRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisSalesPricDis, typeof(Int64));                // 今回売上値引金額
                dt.Columns[Col_ThisSalesPricDis].DefaultValue = 0;

                dt.Columns.Add(Col_CollectMoneyCode, typeof(Int32));                // 集金月区分コード
                dt.Columns[Col_CollectMoneyCode].DefaultValue = 0;

                dt.Columns.Add(Col_CollectMoneyName, typeof(string));               // 集金月区分名称
                dt.Columns[Col_CollectMoneyName].DefaultValue = "";

                dt.Columns.Add(Col_CollectMoneyDay, typeof(Int32));                 // 集金日
                dt.Columns[Col_CollectMoneyDay].DefaultValue = 0;

                dt.Columns.Add(Col_CollectPlnDiv, typeof(Int32));                   // 回収予定区分
                dt.Columns[Col_CollectPlnDiv].DefaultValue = 0;

                dt.Columns.Add(Col_CalcThisTimeSales, typeof(long));		        // 今回売上額(計算用)
                dt.Columns[Col_CalcThisTimeSales].DefaultValue = 0;

                dt.Columns.Add(Col_CalcObjPric, typeof(long));		                // 対象額(計算用)
                dt.Columns[Col_CalcObjPric].DefaultValue = 0;

                dt.Columns.Add(Col_CollectMark, typeof(string));                    // マーク
                dt.Columns[Col_CollectMark].DefaultValue = "";

                dt.Columns.Add(Col_CalcCollectDay, typeof(string));                 // 締後回収日
                dt.Columns[Col_CalcCollectDay].DefaultValue = "";

                dt.Columns.Add(Col_SalesAreaCodePrint, typeof(string));			    // 地区コード(印刷用)
                dt.Columns[Col_SalesAreaCodePrint].DefaultValue = "";

                dt.Columns.Add(Col_CollectCondName, typeof(string));		        // 回収条件名称
                dt.Columns[Col_CollectCondName].DefaultValue = "";
                // 2008.11.11 30413 犬飼 追加 <<<<<<END
        
            }
		}
		#endregion
		#endregion
	}
}
