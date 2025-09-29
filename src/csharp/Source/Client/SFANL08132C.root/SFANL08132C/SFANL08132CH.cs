using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 抽出条件入力画面（チェックボックス型）
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.07.05</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CH : Panel, IFreePrintUserControl
	{
		#region PrivateMember
		// 自由帳票抽出条件明細マスタリスト
		private List<FrePExCndD> _frePExCndDList;
		// サイズ変更中フラグ
		private bool _isNowSizeChange;
		#endregion

		#region Const
		// チェックボックスLocation基準値
		private const int ctCheckEditorDefTop	= 6;
		private const int ctCheckEditorDefLeft	= 6;
		// チェック欄幅
		private const int ctCheckAreaWidth	= 30;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08132CH()
		{
			InitializeComponent();
		}
		#endregion

		#region IFreePrintUserControl メンバ
		/// <summary>自由帳票抽出条件明細マスタリスト</summary>
		public List<FrePExCndD> FrePExCndDList
		{
			set { _frePExCndDList = value; }
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="control">不正時のコントロール</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		public bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			control = null;
			return true;
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <returns>ステータス</returns>
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			frePprECnd.CheckItemCode1	= -1;
			frePprECnd.CheckItemCode2	= -1;
			frePprECnd.CheckItemCode3	= -1;
			frePprECnd.CheckItemCode4	= -1;
			frePprECnd.CheckItemCode5	= -1;
			frePprECnd.CheckItemCode6	= -1;
			frePprECnd.CheckItemCode7	= -1;
			frePprECnd.CheckItemCode8	= -1;
			frePprECnd.CheckItemCode9	= -1;
			frePprECnd.CheckItemCode10	= -1;

			foreach (Control control in this.ugbCheckBoxArea.Controls)
			{
				if (control is UltraCheckEditor)
				{
					UltraCheckEditor uceItem = (UltraCheckEditor)control;
					string propertyName = "CheckItemCode" + uceItem.TabIndex;
					PropertyInfo propertyInfo = typeof(FrePprECnd).GetProperty(propertyName);

					int extraCondDetailCode = -1;
					if (uceItem.Tag != null)
						int.TryParse(uceItem.Tag.ToString(), out extraCondDetailCode);

					if (propertyInfo != null && uceItem.Checked)
						propertyInfo.SetValue(frePprECnd, extraCondDetailCode, null);
					else
						propertyInfo.SetValue(frePprECnd, -1, null);
				}
			}
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			this.ulExtraConditionTitle.Text = frePprECnd.ExtraConditionTitle;

			if (_frePExCndDList != null)
			{
				List<FrePExCndD> getFrePExCndDList
					= _frePExCndDList.FindAll(
						delegate(FrePExCndD frePExCndD)
						{
							if (frePExCndD.ExtraCondDetailGrpCd == frePprECnd.ExtraCondDetailGrpCd)
								return true;
							else
								return false;
						}
					);

				for (int ix = 1 ; ix <= getFrePExCndDList.Count ; ix++)
				{
					FrePExCndD frePExCndD = getFrePExCndDList[ix - 1];

					UltraCheckEditor uceItem = new UltraCheckEditor();
					uceItem.Style		= EditCheckStyle.Check;
					uceItem.Tag			= frePExCndD.ExtraCondDetailCode;
					uceItem.Text		= frePExCndD.ExtraCondDetailName;
					uceItem.Font		= this.Font;
					uceItem.TabIndex	= ix;
					uceItem.Width		= FrePrtSettingController.GetStringWidth(uceItem) + ctCheckAreaWidth;

					// チェックデータを取得
					int checkItemCode = -1;
					string propertyName = "CheckItemCode" + ix;
					PropertyInfo propertyInfo = typeof(FrePprECnd).GetProperty(propertyName);
					if (propertyInfo != null) checkItemCode = (int)propertyInfo.GetValue(frePprECnd, null);
					if (checkItemCode >= 0)
						uceItem.Checked = true;
					else
						uceItem.Checked = false;
					
					this.ugbCheckBoxArea.Controls.Add(uceItem);
				}

				LayOutCheckEditor();
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// チェックエディター配置処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グループボックスに含まれるチェックボックスを</br>
		/// <br>			: 画面内に収まるように配置します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void LayOutCheckEditor()
		{
			int defHeight = this.ugbCheckBoxArea.Height;

			Control prevControl = null;
			int itemMaxHeight = 0;
			foreach (Control control in this.ugbCheckBoxArea.Controls)
			{
				if (control is UltraCheckEditor)
				{
					UltraCheckEditor uceItem = (UltraCheckEditor)control;
					if (prevControl == null)
					{
						uceItem.Location	= new Point(ctCheckEditorDefLeft, ctCheckEditorDefTop);
					}
					else
					{
						int startLeft = prevControl.Left + prevControl.Width;
						if (startLeft + uceItem.Width < this.ugbCheckBoxArea.Width)
						{
							uceItem.Left	= startLeft;
							uceItem.Top		= prevControl.Top;
						}
						else
						{
							uceItem.Left	= ctCheckEditorDefLeft;
							uceItem.Top		= prevControl.Top + prevControl.Height;
						}
					}
					prevControl = uceItem;
					itemMaxHeight = Math.Max(itemMaxHeight, uceItem.Top + uceItem.Height);
				}
			}

			_isNowSizeChange = true;
			try
			{
				// グループBOXのラインに重なって消える為、微調整
				itemMaxHeight += 2;
				// サイズ調整
				if (defHeight > itemMaxHeight)
					this.Height -= defHeight - itemMaxHeight;
				else
					this.Height += itemMaxHeight - defHeight;
			}
			finally
			{
				_isNowSizeChange = false;
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// SizeChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: Size プロパティの値がコントロールで変更されたときに</br>
		/// <br>			: 発生するイベントです。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ugbCheckBoxArea_SizeChanged(object sender, EventArgs e)
		{
			if (!_isNowSizeChange)
				LayOutCheckEditor();
		}

		/// <summary>
		/// SizeChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: Size プロパティの値がコントロールで変更されたときに</br>
		/// <br>			: 発生するイベントです。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ulExtraConditionTitle_SizeChanged(object sender, EventArgs e)
		{
			FrePrtSettingController.AdjustControlFontSize(this.ulExtraConditionTitle, 11);
		}

		/// <summary>
		/// TextChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: TextChanged プロパティの値がコントロールで変更されたときに</br>
		/// <br>			: 発生するイベントです。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ulExtraConditionTitle_TextChanged(object sender, EventArgs e)
		{
			FrePrtSettingController.AdjustControlFontSize(this.ulExtraConditionTitle, 11);
		}
		#endregion
	}
}
