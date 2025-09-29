using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 MAMOK02123EA
	/// <summary>
	/// 					 目標データ
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 目標データファイル</br>
	/// <br>Programmer		 :	 NEPCO</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/04/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2007/11/21 30167 上野　弘貴</br>
	/// <br>					 流通.DC用に変更（項目追加）</br>
	/// <br></br>
	/// </remarks>
	public class MAMOK02123EA
	{
		#region Public Const
		/// <summary>売上目標設定マスタセット名</summary>
		public const string CT_CsSalesTargetDataTable	  = "CsSalesTargetDataTable";
		/// <summary>売上目標バッファデータテーブル名</summary>
		public const string CT_CsSalesTargetBuffDataTable = "CsSalesTargetBuffDataTable";

		/// <summary>拠点コード</summary>
		public const string CT_CsSalesTarget_SectionCode	   = "SectionCode";
		/// <summary>目標設定区分</summary>
		public const string CT_CsSalesTarget_TargetSetCd	   = "TargetSetCd";
		/// <summary>目標対比区分</summary>
		public const string CT_CsSalesTarget_TargetContrastCd  = "TargetContrastCd";
		/// <summary>目標区分コード</summary>
		public const string CT_CsSalesTarget_TargetDivideCode  = "TargetDivideCode";
		/// <summary>目標区分名称</summary>
		public const string CT_CsSalesTarget_TargetDivideName  = "TargetDivideName";
		/// <summary>適用開始日</summary>
		public const string CT_CsSalesTarget_ApplyStaDate	   = "ApplyStaDate";
		/// <summary>適用終了日</summary>
		public const string CT_CsSalesTarget_ApplyEndDate	   = "ApplyEndDate";

//----- ueno add---------- start 2007.11.21
		/// <summary>従業員区分</summary>
		public const string CT_CsSalesTarget_EmployeeDivCd     = "EmployeeDivCd";

		/// <summary>部門コード</summary>
		public const string CT_CsSalesTarget_SubSectionCode    = "SubSectionCode";

		/// <summary>課コード</summary>
		public const string CT_CsSalesTarget_MinSectionCode    = "MinSectionCode";

		/// <summary>業種コード</summary>
		public const string CT_CsSalesTarget_BusinessTypeCode  = "BusinessTypeCode";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
        /// <summary>業種名称ド</summary>
        public const string CT_CsSalesTarget_BusinessTypeName  = "BusinessTypeName";

        /// <summary>販売エリア名称</summary>
        public const string CT_CsSalesTarget_SalesAreaName     = "SalesAreaName";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

		/// <summary>販売エリアコード</summary>
		public const string CT_CsSalesTarget_SalesAreaCode     = "SalesAreaCode";

		/// <summary>得意先コード</summary>
		public const string CT_CsSalesTarget_CustomerCode      = "CustomerCode";
//----- ueno add---------- end   2007.11.21
// 不要項目については削除していません。
// あくまでも目標設定マスタの対応のため。
// 帳票対応の方が不要項目の対応願います。

		/// <summary>従業員コード</summary>
		public const string CT_CsSalesTarget_EmployeeCode	   = "EmployeeCode";
		/// <summary>従業員名称</summary>
		public const string CT_CsSalesTarget_EmployeeName	   = "EmployeeName";
		/// <summary>売上形式</summary>
		public const string CT_CsSalesTarget_SalesFormal	   = "SalesFormal";
		/// <summary>販売形態コード</summary>
		public const string CT_CsSalesTarget_SalesFormCode	   = "SalesFormCode";
		/// <summary>販売形態名称</summary>
		public const string CT_CsSalesTarget_SalesFormName	   = "SalesFormName";
		/// <summary>メーカーコード</summary>
		public const string CT_CsSalesTarget_MakerCode		   = "MakerCode";
		/// <summary>メーカー名称</summary>
		public const string CT_CsSalesTarget_MakerName		   = "MakerName";
		/// <summary>商品コード</summary>
		public const string CT_CsSalesTarget_GoodsCode = "GoodsCode";
		/// <summary>商品名称</summary>
		public const string CT_CsSalesTarget_GoodsName		   = "GoodsName";
		/// <summary>売上目標金額</summary>
		public const string CT_CsSalesTarget_SalesTargetMoney  = "SalesTargetMoney";
		/// <summary>売上目標粗利額</summary>
		public const string CT_CsSalesTarget_SalesTargetProfit = "SalesTargetProfit";
		/// <summary>売上目標数量</summary>
		public const string CT_CsSalesTarget_SalesTargetCount  = "SalesTargetCount";
		/// <summary>平日比率</summary>
		public const string CT_CsSalesTarget_WeekdayRatio	   = "WeekdayRatio";
		/// <summary>土日比率</summary>
		public const string CT_CsSalesTarget_SatSunRatio	   = "SatSunRatio";

		/// <summary>売上金額</summary>
		public const string CT_CsSalesTarget_SalesMoney 					= "SalesMoney";
		/// <summary>売上粗利額</summary>
		public const string CT_CsSalesTarget_SalesProfit					= "SalesProfit";
		/// <summary>売上数量</summary>
		public const string CT_CsSalesTarget_SalesCount 					= "SalesCount";
		/// <summary>売上過不足</summary>
		public const string CT_CsSalesTarget_Sales_Equally					= "Sales_Equally";
		/// <summary>粗利過不足</summary>
		public const string CT_CsSalesTarget_GrossMargin_Equally			= "GrossMargin_Equally";
		/// <summary>数量過不足</summary>
		public const string CT_CsSalesTarget_Amount_Equally 				= "Amount_Equally";
		/// <summary>売上達成率</summary>
		public const string CT_CsSalesTarget_Sales_AccomplishmentRate		= "Sales_AccomplishmentRate";
		/// <summary>粗利達成率</summary>
		public const string CT_CsSalesTarget_GrossMargin_AccomplishmentRate = "GrossMargin_AccomplishmentRate";
		/// <summary>数量達成率</summary>
		public const string CT_CsSalesTarget_Amount_AccomplishmentRate		= "Amount_AccomplishmentRate";
		/// <summary>売上進捗率</summary>
		public const string CT_CsSalesTarget_Sales_ProgressRate 			= "Sales_ProgressRate";
		/// <summary>粗利進捗率</summary>
		public const string CT_CsSalesTarget_GrossMargin_ProgressRate		= "GrossMargin_ProgressRate";
		/// <summary>数量進捗率</summary>
		public const string CT_CsSalesTarget_Amount_ProgressRate			= "Amount_ProgressRate";
		/// <summary>売上構成比</summary>
		public const string CT_CsSalesTarget_Sales_CompositionRatio 		= "Sales_CompositionRatio";
		/// <summary>粗利構成比</summary>
		public const string CT_CsSalesTarget_GrossMargin_CompositionRatio	= "GrossMargin_CompositionRatio";
		/// <summary>数量構成比</summary>
		public const string CT_CsSalesTarget_Amount_CompositionRatio		= "Amount_CompositionRatio";
		/// <summary>売上着地</summary>
		public const string CT_CsSalesTarget_Sales_Landing					= "Sales_Landing";
		/// <summary>粗利着地</summary>
		public const string CT_CsSalesTarget_GrossMargin_Landing			= "GrossMargin_Landing";
		/// <summary>数量着地</summary>
		public const string CT_CsSalesTarget_Amount_Landing 				= "Amount_Landing";

		/// <summary>拠点名</summary>
		public const string CT_CsSalesTarget_SectionName		 = "SectionName";

		/// <summary>売上形式名称</summary>
		public const string CT_CsSalesTarget_SalesFormalName	 = "SalesFormalName";

		/// <summary>メーカーコード + 商品コード</summary>
		public const string CT_CsSalesTarget_MakerCode_GoodsCode = "MakerCode_GoodsCode";
		#endregion Public Member

		#region コンストラクタ
		/// <summary>
		/// 目標データコンストラクタ
		/// </summary>
		/// <returns>SalesTargetAcsクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 SalesTargetAcsクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public MAMOK02123EA()
		{
		}

		#endregion コンストラクタ

		#region Public Method
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <param name="ds">データセット</param>
		/// <remarks>
		/// <br>Note	   : </br>
		/// <br>Programmer : ネプコ</br>
		/// <br>Date	   : 2006.01.21</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_CsSalesTargetDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_CsSalesTargetDataTable].Clear();
			}
			else
			{
				CreateSalesTargetDataTable(ref ds, 0);

			}

			// 売上チェックリストバッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_CsSalesTargetBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_CsSalesTargetBuffDataTable].Clear();
			}
			else
			{
				CreateSalesTargetDataTable(ref ds, 1);
			}
		}
		#endregion Public Method

		#region Private Methods
		/// <summary>
		/// 目標抽出結果作成処理
		/// </summary>
		/// <param name="ds">データセット</param>
		/// <param name="buffCheck">バッファチェック</param>
		/// <remarks>
		/// <br>Note	   : </br>
		/// <br>Programmer : ネプコ</br>
		/// <br>Date	   : 2007.04.13</br>
		/// </remarks>
		private static void CreateSalesTargetDataTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if (buffCheck == 0)
			{
				// スキーマ設定
				ds.Tables.Add(CT_CsSalesTargetDataTable);
				dt = ds.Tables[CT_CsSalesTargetDataTable];
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(CT_CsSalesTargetBuffDataTable);
				dt = ds.Tables[CT_CsSalesTargetBuffDataTable];
			}

			// 拠点コード
			dt.Columns.Add(CT_CsSalesTarget_SectionCode, typeof(String));
			dt.Columns[CT_CsSalesTarget_SectionCode].DefaultValue = "";
			// 目標設定区分
			dt.Columns.Add(CT_CsSalesTarget_TargetSetCd, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_TargetSetCd].DefaultValue = 0;
			// 目標対比区分
			dt.Columns.Add(CT_CsSalesTarget_TargetContrastCd, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_TargetContrastCd].DefaultValue = 0;
			// 目標区分コード
			dt.Columns.Add(CT_CsSalesTarget_TargetDivideCode, typeof(String));
			dt.Columns[CT_CsSalesTarget_TargetDivideCode].DefaultValue = "";
			// 目標区分名称
			dt.Columns.Add(CT_CsSalesTarget_TargetDivideName, typeof(String));
			dt.Columns[CT_CsSalesTarget_TargetDivideName].DefaultValue = "";
			// 適用開始日
			dt.Columns.Add(CT_CsSalesTarget_ApplyStaDate, typeof(DateTime));
			dt.Columns[CT_CsSalesTarget_ApplyStaDate].DefaultValue = DateTime.MinValue;
			// 適用終了日
			dt.Columns.Add(CT_CsSalesTarget_ApplyEndDate, typeof(DateTime));
			dt.Columns[CT_CsSalesTarget_ApplyEndDate].DefaultValue = DateTime.MinValue;

//----- ueno add---------- start 2007.11.21
			// 従業員区分
			dt.Columns.Add(CT_CsSalesTarget_EmployeeDivCd, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_EmployeeDivCd].DefaultValue = 0;
			// 部門コード
			dt.Columns.Add(CT_CsSalesTarget_SubSectionCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_SubSectionCode].DefaultValue = 0;
			// 課コード
			dt.Columns.Add(CT_CsSalesTarget_MinSectionCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_MinSectionCode].DefaultValue = 0;
			// 業種コード
			dt.Columns.Add(CT_CsSalesTarget_BusinessTypeCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_BusinessTypeCode].DefaultValue = 0;
			// 販売エリアコード
			dt.Columns.Add(CT_CsSalesTarget_SalesAreaCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_SalesAreaCode].DefaultValue = 0;
			// 得意先コード
			dt.Columns.Add(CT_CsSalesTarget_CustomerCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_CustomerCode].DefaultValue = 0;
			
//----- ueno add---------- end   2007.11.21

			// 従業員コード
			dt.Columns.Add(CT_CsSalesTarget_EmployeeCode, typeof(String));
			dt.Columns[CT_CsSalesTarget_EmployeeCode].DefaultValue = 0;
			// 従業員名称
			dt.Columns.Add(CT_CsSalesTarget_EmployeeName, typeof(String));
			dt.Columns[CT_CsSalesTarget_EmployeeName].DefaultValue = "";
			// 売上形式
			dt.Columns.Add(CT_CsSalesTarget_SalesFormal, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_SalesFormal].DefaultValue = 0;
			// 販売形態コード
			dt.Columns.Add(CT_CsSalesTarget_SalesFormCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_SalesFormCode].DefaultValue = 0;
			// 販売形態名称
			dt.Columns.Add(CT_CsSalesTarget_SalesFormName, typeof(String));
			dt.Columns[CT_CsSalesTarget_SalesFormName].DefaultValue = "";
			// メーカーコード
			dt.Columns.Add(CT_CsSalesTarget_MakerCode, typeof(Int32));
			dt.Columns[CT_CsSalesTarget_MakerCode].DefaultValue = 0;
			// メーカー名称
			dt.Columns.Add(CT_CsSalesTarget_MakerName, typeof(String));
			dt.Columns[CT_CsSalesTarget_MakerName].DefaultValue = "";
			// 商品コード
			dt.Columns.Add(CT_CsSalesTarget_GoodsCode, typeof(String));
			dt.Columns[CT_CsSalesTarget_GoodsCode].DefaultValue = "";
			// 商品名称
			dt.Columns.Add(CT_CsSalesTarget_GoodsName, typeof(String));
			dt.Columns[CT_CsSalesTarget_GoodsName].DefaultValue = "";
			// 売上目標金額
			dt.Columns.Add(CT_CsSalesTarget_SalesTargetMoney, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_SalesTargetMoney].DefaultValue = 0;
			// 売上目標粗利額
			dt.Columns.Add(CT_CsSalesTarget_SalesTargetProfit, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_SalesTargetProfit].DefaultValue = 0;
			// 売上目標数量
			dt.Columns.Add(CT_CsSalesTarget_SalesTargetCount, typeof(Double));
			dt.Columns[CT_CsSalesTarget_SalesTargetCount].DefaultValue = 0.0;
			// 平日比率
			dt.Columns.Add(CT_CsSalesTarget_WeekdayRatio, typeof(Double));
			dt.Columns[CT_CsSalesTarget_WeekdayRatio].DefaultValue = 0.0;
			// 土日比率
			dt.Columns.Add(CT_CsSalesTarget_SatSunRatio, typeof(Double));
			dt.Columns[CT_CsSalesTarget_SatSunRatio].DefaultValue = 0.0;

			// 売上金額
			dt.Columns.Add(CT_CsSalesTarget_SalesMoney, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_SalesMoney].DefaultValue = 0;
			// 売上粗利額
			dt.Columns.Add(CT_CsSalesTarget_SalesProfit, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_SalesProfit].DefaultValue = 0;
			// 売上数量
			dt.Columns.Add(CT_CsSalesTarget_SalesCount, typeof(Double));
			dt.Columns[CT_CsSalesTarget_SalesCount].DefaultValue = 0.0;

			// 売上過不足
			dt.Columns.Add(CT_CsSalesTarget_Sales_Equally, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_Sales_Equally].DefaultValue = 0;
			// 粗利過不足
			dt.Columns.Add(CT_CsSalesTarget_GrossMargin_Equally, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_GrossMargin_Equally].DefaultValue = 0;
			// 数量過不足
			dt.Columns.Add(CT_CsSalesTarget_Amount_Equally, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Amount_Equally].DefaultValue = 0.0;
			// 売上達成率
			dt.Columns.Add(CT_CsSalesTarget_Sales_AccomplishmentRate, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Sales_AccomplishmentRate].DefaultValue = 0.0;
			// 粗利達成率
			dt.Columns.Add(CT_CsSalesTarget_GrossMargin_AccomplishmentRate, typeof(Double));
			dt.Columns[CT_CsSalesTarget_GrossMargin_AccomplishmentRate].DefaultValue = 0.0;
			// 数量達成率
			dt.Columns.Add(CT_CsSalesTarget_Amount_AccomplishmentRate, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Amount_AccomplishmentRate].DefaultValue = 0.0;
			// 売上進捗率
			dt.Columns.Add(CT_CsSalesTarget_Sales_ProgressRate, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Sales_ProgressRate].DefaultValue = 0.0;
			// 粗利進捗率
			dt.Columns.Add(CT_CsSalesTarget_GrossMargin_ProgressRate, typeof(Double));
			dt.Columns[CT_CsSalesTarget_GrossMargin_ProgressRate].DefaultValue = 0.0;
			// 数量進捗率
			dt.Columns.Add(CT_CsSalesTarget_Amount_ProgressRate, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Amount_ProgressRate].DefaultValue = 0.0;
			// 売上構成比
			dt.Columns.Add(CT_CsSalesTarget_Sales_CompositionRatio, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Sales_CompositionRatio].DefaultValue = 0.0;
			// 粗利構成比
			dt.Columns.Add(CT_CsSalesTarget_GrossMargin_CompositionRatio, typeof(Double));
			dt.Columns[CT_CsSalesTarget_GrossMargin_CompositionRatio].DefaultValue = 0.0;
			// 数量構成比
			dt.Columns.Add(CT_CsSalesTarget_Amount_CompositionRatio, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Amount_CompositionRatio].DefaultValue = 0.0;
			// 売上着地
			dt.Columns.Add(CT_CsSalesTarget_Sales_Landing, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_Sales_Landing].DefaultValue = 0;
			// 粗利着地
			dt.Columns.Add(CT_CsSalesTarget_GrossMargin_Landing, typeof(Int64));
			dt.Columns[CT_CsSalesTarget_GrossMargin_Landing].DefaultValue = 0;
			// 数量着地
			dt.Columns.Add(CT_CsSalesTarget_Amount_Landing, typeof(Double));
			dt.Columns[CT_CsSalesTarget_Amount_Landing].DefaultValue = 0.0;

			// 拠点名
			dt.Columns.Add(CT_CsSalesTarget_SectionName, typeof(String));
			dt.Columns[CT_CsSalesTarget_SectionName].DefaultValue = "";
			// 売上形式名称
			dt.Columns.Add(CT_CsSalesTarget_SalesFormalName, typeof(String));
			dt.Columns[CT_CsSalesTarget_SalesFormalName].DefaultValue = "";

			// メーカーコード + 商品コード
			dt.Columns.Add(CT_CsSalesTarget_MakerCode_GoodsCode, typeof(String));
			dt.Columns[CT_CsSalesTarget_MakerCode_GoodsCode].DefaultValue = "";
		}
		#endregion Private Methods
	}
}
