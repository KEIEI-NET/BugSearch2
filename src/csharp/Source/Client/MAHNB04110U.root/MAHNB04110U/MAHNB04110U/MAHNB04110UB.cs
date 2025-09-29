using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上伝票検索用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上伝票検索用のユーザー設定フォームクラスです。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2007.06.18</br>
	/// <br>Update Note: </br>
	/// </remarks>
	public partial class SalesSearchSetup : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		public SalesSearchSetup()
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._salesSearchConstructionAcs = SalesSearchConstructionAcs.GetInstance();
			this._controlScreenSkin = new ControlScreenSkin();

			this.SetComboEditorItemIndex(this.tComboEditor_SearchSlipDateStartRange, this._salesSearchConstructionAcs.SearchSlipDateStartRangeValue, 0);
			this.SetComboEditorItemIndex(this.tComboEditor_AddUpADateStartRange, this._salesSearchConstructionAcs.AddUpADateStartRangeValue, 0);
			this.SetComboEditorItemIndex(this.tComboEditor_RegiProcDateStartRange, this._salesSearchConstructionAcs.RegiProcDateStartRangeValue, 0);
			this.SetOptionSetItemIndex(this.uOptionSet_DetailConditionOpen, this._salesSearchConstructionAcs.DetailConditionOpenValue);
			this.SetOptionSetItemIndex(this.uOptionSet_DataChangedAutoSearch, this._salesSearchConstructionAcs.DataChangedAutoSearchValue);
			this.SetOptionSetItemIndex(this.uOptionSet_ExecAutoSearch, this._salesSearchConstructionAcs.ExecAutoSearchValue);
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private SalesSearchConstructionAcs _salesSearchConstructionAcs;
		private ControlScreenSkin _controlScreenSkin;
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Method
		/// <summary>
		/// コンボエディタアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <param name="dataValue">設定値</param>
		/// <param name="defaultIndex">初期値</param>
		private void SetComboEditorItemIndex(TComboEditor sender, int dataValue, int defaultIndex)
		{
			int index = defaultIndex;

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.SelectedIndex = index;

			if ((index == -1) && (sender.DropDownStyle == Infragistics.Win.DropDownStyle.DropDown))
			{
				sender.Text = dataValue.ToString();
			}
		}

		/// <summary>
		/// オプションセットアイテムインデックス設定処理
		/// </summary>
		/// <param name="sender">対象となるオプションセット</param>
		/// <param name="dataValue">設定値</param>
		private void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
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
		private int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
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
		/// コンボエディタ選択値取得処理
		/// </summary>
		/// <param name="sender">対象となるコンボエディタ</param>
		/// <returns>選択値</returns>
		private int GetComboEditorValue(TComboEditor sender)
		{
			if (sender.SelectedIndex >= 0)
			{
				return (int)sender.SelectedItem.DataValue;
			}
			else
			{
				int index = -1;

				// 数値のみが入力されている場合は、入力値とvalueを比較する。
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
				if (regex.IsMatch(sender.Text.Trim()))
				{
					int dataValue = 0;

					try
					{
						dataValue = Convert.ToInt32(sender.Text.Trim());
					}
					catch (OverflowException)
					{
						// 
					}

					for (int i = 0; i < sender.Items.Count; i++)
					{
						if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
						{
							index = i;
							break;
						}
					}
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

				// 該当データが存在しない場合は0とする。
				if (index == -1)
				{
					return 0;
				}
				else
				{
					return (int)sender.Items[index].DataValue;
				}
			}
		}

		/// <summary>
		/// 入力データチェック処理
		/// </summary>
		/// <returns>true:チェックOK false:チェックNG</returns>
		private bool InputDataCheck()
		{
			bool check = true;

			return check;
		}
		# endregion

		// ===================================================================================== //
		// 各種コンポーネントイベント処理郡
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		private void StockInputSetup_Load(object sender, EventArgs e)
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.uButton_Ok.ImageList = this._imageList16;
			this.uButton_Cancel.ImageList = this._imageList16;

			this.uButton_Ok.Appearance.Image = (int)Size16_Index.DECISION;
			this.uButton_Cancel.Appearance.Image = (int)Size16_Index.BEFORE;

			this.timer_Initial.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(uButton_Ok)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		private void uButton_Ok_Click(object sender, EventArgs e)
		{
			if (!this.InputDataCheck())
			{
				this.DialogResult = DialogResult.Retry;
				return;
			}

			this._salesSearchConstructionAcs.SearchSlipDateStartRangeValue = this.GetComboEditorValue(this.tComboEditor_SearchSlipDateStartRange);
			this._salesSearchConstructionAcs.AddUpADateStartRangeValue = this.GetComboEditorValue(this.tComboEditor_AddUpADateStartRange);
			this._salesSearchConstructionAcs.RegiProcDateStartRangeValue = this.GetComboEditorValue(this.tComboEditor_RegiProcDateStartRange);

			this._salesSearchConstructionAcs.DetailConditionOpenValue = this.GetOptionSetValue(this.uOptionSet_DetailConditionOpen);
			this._salesSearchConstructionAcs.DataChangedAutoSearchValue = this.GetOptionSetValue(this.uOptionSet_DataChangedAutoSearch);
			this._salesSearchConstructionAcs.ExecAutoSearchValue = this.GetOptionSetValue(this.uOptionSet_ExecAutoSearch);

			this._salesSearchConstructionAcs.Serialize();
		}

		/// <summary>
		/// 初期処理タイマー起動処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Initial_Tick(object sender, EventArgs e)
		{
			this.timer_Initial.Enabled = false;

			this.tComboEditor_SearchSlipDateStartRange.Focus();
		}

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockInputSetup_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Retry)
			{
				e.Cancel = true;
			}
		}
		# endregion
	}
}