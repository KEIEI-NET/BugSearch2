using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 明細パターンデータテーブル スキーマクラス
	/// </summary>
	internal class DetailPatternTable
	{
		public DetailPatternTable()
		{
		}

		public const string ctTableName = "DetailPatternTable";

		public const string ctColName_RowNo = "RowNo";
		public const string ctColName_PatternOrder = "PatternOrder";
		public const string ctColName_PatternGuid = "PatternGuid";
		public const string ctColName_PatternName = "PatternName";
		public const string ctColName_SearchMode = "SearchMode";
		public const string ctColName_EstimateDetailColInfoList = "EstimateDetailColInfoList";

		static public void CreateTable( ref DataTable dt )
		{
			if (dt == null)
			{
				dt = new DataTable(ctTableName);
			}
			dt.Rows.Clear();

			// カラム生成
			dt.Columns.Add(ctColName_RowNo, typeof(int));
			dt.Columns[ctColName_RowNo].DefaultValue = 0;

			dt.Columns.Add(ctColName_PatternOrder, typeof(int));
			dt.Columns[ctColName_PatternOrder].DefaultValue = 0;

			dt.Columns.Add(ctColName_PatternGuid, typeof(Guid));
			dt.Columns[ctColName_PatternGuid].DefaultValue = Guid.Empty;

			dt.Columns.Add(ctColName_PatternName, typeof(string));
			dt.Columns[ctColName_PatternName].DefaultValue = "";

			dt.Columns.Add(ctColName_SearchMode, typeof(EstmDtlPtnInfo.SearchType));
			dt.Columns[ctColName_SearchMode].DefaultValue = EstmDtlPtnInfo.SearchType.Pure;

			dt.Columns.Add(ctColName_EstimateDetailColInfoList, typeof(List<EstmDtlColInfo>));
			dt.Columns[ctColName_SearchMode].DefaultValue = null;

			// プライマリキー生成
			DataColumn[] keyColumnArray = new DataColumn[1];
			keyColumnArray[0] = dt.Columns[ctColName_PatternGuid];
			dt.PrimaryKey = keyColumnArray;
		}
	}

	/// <summary>
	/// 明細パターン設定データテーブル スキーマクラス
	/// </summary>
	internal class DetailPatternSettingTable
	{
		public DetailPatternSettingTable()
		{
		}

		public const string ctTableName = "DetailPatternSettingTable";

		public const string ctColName_RowNo = "RowNo";
		public const string ctColName_Key = "Key";
		public const string ctColName_ColCaption = "ColCaption";
		public const string ctColName_VisiblePosition = "VisiblePosition";
		public const string ctColName_FixedCol = "FixedCol";
		public const string ctColName_FixedColControl = "FixedColControl";
		public const string ctColName_Visible = "Visible";
		public const string ctColName_EnterStop = "EnterStop";
		public const string ctColName_EnterStopControl = "EnterStopControl";
		public const string ctColName_VisibleControl = "VisibleControl";
		public const string ctColName_ReadOnlyCol = "ReadOnlyCol";

		static public void CreateTable( ref DataTable dt )
		{
			if (dt == null)
			{
				dt = new DataTable(ctTableName);
			}
			dt.Rows.Clear();

			// カラム生成
			dt.Columns.Add(new DataColumn(ctColName_RowNo, typeof(int)));
			dt.Columns[ctColName_RowNo].DefaultValue = 0;

			dt.Columns.Add(new DataColumn(ctColName_Key, typeof(string)));
			dt.Columns[ctColName_Key].DefaultValue = "";

			dt.Columns.Add(new DataColumn(ctColName_ColCaption, typeof(string)));
			dt.Columns[ctColName_ColCaption].DefaultValue = "";

			dt.Columns.Add(new DataColumn(ctColName_VisiblePosition, typeof(int)));
			dt.Columns[ctColName_VisiblePosition].DefaultValue = 0;

			dt.Columns.Add(new DataColumn(ctColName_Visible, typeof(bool)));
			dt.Columns[ctColName_Visible].DefaultValue = false;

			dt.Columns.Add(new DataColumn(ctColName_VisibleControl, typeof(bool)));
			dt.Columns[ctColName_VisibleControl].DefaultValue = false;

			dt.Columns.Add(new DataColumn(ctColName_FixedCol, typeof(bool)));
			dt.Columns[ctColName_FixedCol].DefaultValue = false;

			dt.Columns.Add(new DataColumn(ctColName_FixedColControl, typeof(bool)));
			dt.Columns[ctColName_FixedColControl].DefaultValue = false;

			dt.Columns.Add(new DataColumn(ctColName_EnterStop, typeof(bool)));
			dt.Columns[ctColName_EnterStop].DefaultValue = false;

			dt.Columns.Add(new DataColumn(ctColName_EnterStopControl, typeof(bool)));
			dt.Columns[ctColName_EnterStopControl].DefaultValue = false;


			dt.Columns.Add(new DataColumn(ctColName_ReadOnlyCol, typeof(bool)));
			dt.Columns[ctColName_ReadOnlyCol].DefaultValue = false;

			// プライマリキー生成
			DataColumn[] keyColumnArray = new DataColumn[1];
			keyColumnArray[0] = dt.Columns[ctColName_Key];
			dt.PrimaryKey = keyColumnArray;
		}
	}
}
