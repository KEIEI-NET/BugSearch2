using System;
using System.Data;
using System.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 品番検索サブクラス
	/// </summary>
	public class PartsSerchSub
	{
		# region コンストラクター
		/// <summary>
		///	部品検索コントローラー コンストラクター
		/// </summary>
		public PartsSerchSub()
		{
		}
		# endregion

		# region データテーブルの列を作成
		/// <summary>
		/// データテーブルの列を作成
		/// </summary>
		/// <param name="columnName">列名</param>
		/// <param name="type">型</param>
		/// <param name="caption">キャプション</param>
		/// <returns></returns>
		public static DataColumn CreateColumn(string columnName, Type type, string caption)
		{
			DataColumn dc = new DataColumn();

			dc.ColumnName = columnName;
			dc.DataType = type;
			dc.Caption = caption;

			return dc;
		}
		# endregion

	}
}
