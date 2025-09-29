//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ復旧処理ＵＩクラス
// プログラム概要   : ＵＯＥ復旧処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
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
			int index = -1;
			string selectText = sender.Text.Trim();

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if (sender.Items[i].DisplayText.Trim() == selectText)
				{
					index = (int)sender.Items[i].DataValue;
					break;
				}
			}

			return index;
		}

	}
}
