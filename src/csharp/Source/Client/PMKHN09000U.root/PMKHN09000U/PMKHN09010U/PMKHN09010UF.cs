//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先マスタ
// プログラム概要   ：得意先の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/04/30     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/18     修正内容：Mantis【13400、13455】対応
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// コンボエディタデータ取得タイプ
	/// </summary>
	internal enum ComboEditorGetDataType : int
	{
		VALUE = 0,
		TAG = 1
	}

	internal class ComboEditorItemControl
	{
		/// <summary>
		/// コンボエディタアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <param name="dataValue">設定値</param>
		/// <param name="nonDataClear">データ無し時クリア</param>
		internal static bool SetComboEditorItemIndex(TComboEditor sender, int dataValue, bool nonDataClear)
		{
			int index = -1;

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.SelectedIndex = index;

			if (index == -1)
			{
				if (nonDataClear)
				{
					sender.Text = "";
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// コンボエディタ選択アイテムテキスト取得処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <param name="dataValue">設定値</param>
		/// <returns></returns>
		internal static string GetComboEditorText(TComboEditor sender, int dataValue)
		{
			int index = -1;
			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			if (index == -1)
			{
				return "";
			}
			else
			{
				return sender.Items[index].DisplayText.Trim();
			}
		}

		/// <summary>
		/// コンボエディタ選択値取得処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
        /// <param name="getDataType"></param>
		/// <returns>選択値</returns>
		internal static int GetComboEditorValue(TComboEditor sender, ComboEditorGetDataType getDataType)
		{
			int index = -1;

			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
			if (regex.IsMatch(sender.Text.Trim()))
			{
				// 数値のみが入力されている場合は、入力値とTagを比較する。
				int dataValue = 0;

				try
				{
					dataValue = Convert.ToInt32(sender.Text.Trim());
				}
				catch (OverflowException)
				{
					// 
				}

				switch (getDataType)
				{
					case ComboEditorGetDataType.TAG:
					{
						for (int i = 0; i < sender.Items.Count; i++)
						{
							if ((sender.Items[i].Tag is Int32) && ((Int32)sender.Items[i].Tag == dataValue))
							{
								index = i;
								break;
							}
						}

						break;
					}
					case ComboEditorGetDataType.VALUE:
					{
						for (int i = 0; i < sender.Items.Count; i++)
						{
							if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
							{
								index = i;
								break;
							}
						}

						break;
					}
				}
			}
			else
			{
				// コンボエディタ選択値取得処理（テキストから）
				int selectedIndex = GetComboEditorValueFromText(sender);
				return selectedIndex;
			}

			// 上記の比較で該当データが存在しなかった場合は、入力値とDisplayTextを比較する。
			if (index == -1)
			{
				string selectText = sender.Text.Trim();

				for (int i = 0; i < sender.Items.Count; i++)
				{
					if (sender.Items[i].DisplayText.Trim() == selectText)
					{
						index = i;
						break;
					}
				}
			}

			// 該当データが存在しない場合は-1とする。
			if (index == -1)
			{
				return -1;
			}
			else
			{
				return (int)sender.Items[index].DataValue;
			}
		}

		/// <summary>
		/// コンボエディタ選択値取得処理（テキストから）
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <returns>選択値</returns>
		internal static int GetComboEditorValueFromText(TComboEditor sender)
		{
            // DEL 2009/06/18 ------>>>
            //int index = 0;
            //string selectText = sender.Text.Trim();

            //for (int i = 0; i < sender.Items.Count; i++)
            //{
            //    if (sender.Items[i].DisplayText.Trim() == selectText)
            //    {
            //        index = (int)sender.Items[i].DataValue;
            //        break;
            //    }
            //}

            //return index;
            // DEL 2009/06/18 ------<<<

            // ADD 2009/06/18 ------>>>
            // 表示テキスト比較ではなく、選択アイテムの値を返す
            if (sender.SelectedIndex >= 0)
            {
                return (int)sender.SelectedItem.DataValue;
            }
            
            return 0;
            // ADD 2009/06/18 ------<<<
        }

		/// <summary>
		/// コンボエディタアイテム追加処理
		/// </summary>
		/// <param name="sender">対象コンボエディタ</param>
		/// <param name="dataValue">アイテムデータ</param>
		/// <param name="displayText">アイテム表示テキスト</param>
		/// <param name="tag">アイテムタグ</param>
		internal static void AddComboEditorItem(TComboEditor sender, object dataValue, string displayText, object tag)
		{
			Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
			item.DataValue = dataValue;
			item.DisplayText = displayText;
			item.Tag = tag;

			sender.Items.Add(item);
		}

		/// <summary>
		/// オプションセットアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象となるオプションセット</param>
		/// <param name="dataValue">設定値</param>
		internal static void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
		{
			int index = -1;
			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.CheckedIndex = index;
		}

		/// <summary>
		/// オプションセット選択値取得処理
		/// </summary>
		/// <param name="sender">対象となるオプションセット</param>
		/// <returns>選択値</returns>
		internal static int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
		{
			if (sender.CheckedIndex >= 0)
			{
				return (int)sender.CheckedItem.DataValue;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// チェックエディタチェック数値設定処理
		/// </summary>
		/// <param name="sender">対象となるチェックエディタ</param>
		/// <param name="checkedValue">チェック有り時設定値</param>
		/// <param name="unCheckedValue">チェック無し時設定値</param>
		/// <returns>設定値</returns>
		internal static int GetCheckEditorValue(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int unCheckedValue)
		{
			if (sender.Checked)
			{
				return checkedValue;
			}
			else
			{
				return unCheckedValue;
			}
		}

		/// <summary>
		/// チェックエディタチェック設定処理
		/// </summary>
		/// <param name="sender">対象となるチェックエディタ</param>
		/// <param name="checkedValue">チェックを付ける再の値</param>
		/// <param name="dataValue">設定値</param>
		internal static void SetCheckEditorChecked(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int dataValue)
		{
			if (checkedValue == dataValue)
			{
				sender.Checked = true;
			}
			else
			{
				sender.Checked = false;
			}
		}
	}
}
