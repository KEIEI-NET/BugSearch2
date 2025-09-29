using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 簡易マスメンマルチフォーム編集インターフェース
	/// </summary>
	public interface ISimpleMasterMaintenanceMulti
	{
		/// <summary>
		/// 選択データインデックスプロパティ
		/// </summary>
		int DataIndex
		{
			get;
			set;
		}

		/// <summary>
		/// 新規追加許可プロパティ
		/// </summary>
		bool AllowNew
		{
			get;
		}

		/// <summary>
		/// 削除許可プロパティ
		/// </summary>
		bool AllowDelete
		{
			get;
		}

		/// <summary>
		/// クローズ可否プロパティ
		/// </summary>
		bool CanClose
		{
			get;
			set;
		}

		/// <summary>
		/// データセット取得処理
		/// </summary>
		/// <param name="dataSet">データセット</param>
		/// <param name="dataMember">データメンバー</param>
		void GetDataSet( ref DataSet dataSet, ref string dataMember );

		/// <summary>
		/// オプションツール取得処理
		/// </summary>
		/// <param name="optionTools">オプションツール</param>
		void GetOptionTools( ref SortedList<string,ToolStripItem> optionTools );

		/// <summary>
		/// グリッド列外観設定取得処理
		/// </summary>
		/// <returns>グリッド列外観設定ディクショナリー</returns>
		Dictionary<string,GridColAppearance> GetGridColAppearance();

		/// <summary>
		/// 検索処理
		/// </summary>
		/// <returns>STATUS</returns>
		int Search();

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		int Delete();

		/// <summary>
		/// オプションツールコマンド処理
		/// </summary>
		/// <param name="key">コマンドキー</param>
		/// <param name="owner">System.Forms.IWin32Window を実装し、このフォームを所有するトップレベル ウィンドウを表すオブジェクト。</param>
		void OptionToolCommand( string key, IWin32Window owner );
	}
}
