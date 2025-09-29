using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 抽出条件入力画面（文字型）
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CC : Panel, IFreePrintUserControl
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08132CC()
		{
			InitializeComponent();
		}
		#endregion

		#region IFreePrintUserControl メンバ
		/// <summary>自由帳票抽出条件明細マスタリスト</summary>
		public List<FrePExCndD> FrePExCndDList { set { } }

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

			string startCode	= this.tedStExtraCharCode.Text;
			string endCode		= this.tedEdExtraCharCode.Text;

			// 必須項目チェック
			if (isNecessaryExtraCondCheck)
			{
				if (this.tedEdExtraCharCode.Visible)
				{
					if (string.IsNullOrEmpty(startCode) && string.IsNullOrEmpty(endCode))
					{
						message = this.ulExtraConditionTitle.Text + "が入力されていません。";
						control = this.tedStExtraCharCode;
						return false;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(startCode))
					{
						message = this.ulExtraConditionTitle.Text + "が入力されていません。";
						control = this.tedStExtraCharCode;
						return false;
					}
				}
			}

			// 大小チェック
			if (this.tedEdExtraCharCode.Visible)
			{
				if (!startCode.Equals(string.Empty) && !endCode.Equals(string.Empty))
				{
					if (string.Compare(startCode, endCode) > 0)
					{
						message = this.ulExtraConditionTitle.Text + "の範囲指定が不正です。";
						control = this.tedStExtraCharCode;
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <returns>ステータス</returns>
		public void GetFrePprECndInfo(ref Broadleaf.Application.UIData.FrePprECnd frePprECnd)
		{
			frePprECnd.StExtraCharCode = this.tedStExtraCharCode.Text;
			if (this.tedEdExtraCharCode.Visible)
				frePprECnd.EdExtraCharCode = this.tedEdExtraCharCode.Text;
			else
				frePprECnd.EdExtraCharCode = string.Empty;
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// データの設定
			this.ulExtraConditionTitle.Text			= frePprECnd.ExtraConditionTitle;
			this.tedStExtraCharCode.Text			= frePprECnd.StExtraCharCode;
			this.tedStExtraCharCode.ExtEdit.Column	= frePprECnd.InputCharCnt;
			this.tedEdExtraCharCode.Text			= frePprECnd.EdExtraCharCode;
			this.tedEdExtraCharCode.ExtEdit.Column	= frePprECnd.InputCharCnt;
			// 抽出条件区分(2:文字型（半角）,3:文字型（全角）)
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 2:
				{
					this.tedStExtraCharCode.ImeMode			= ImeMode.Off;
					this.tedStExtraCharCode.CharacterCasing	= CharacterCasing.Upper;
					this.tedStExtraCharCode.ExtEdit.EnableChars.Word = false;
					this.tedEdExtraCharCode.ImeMode			= ImeMode.Off;
					this.tedEdExtraCharCode.CharacterCasing	= CharacterCasing.Upper;
					this.tedEdExtraCharCode.ExtEdit.EnableChars.Word = false;
					break;
				}
				case 3:
				{
					this.tedStExtraCharCode.ImeMode			= ImeMode.Katakana;
					this.tedStExtraCharCode.CharacterCasing	= CharacterCasing.Normal;
					this.tedStExtraCharCode.ExtEdit.EnableChars.Word = true;
					this.tedEdExtraCharCode.ImeMode			= ImeMode.Katakana;
					this.tedEdExtraCharCode.CharacterCasing	= CharacterCasing.Normal;
					this.tedEdExtraCharCode.ExtEdit.EnableChars.Word = true;
					break;
				}
			}

			// 抽出条件タイプ(1:範囲)以外の時は終了条件を非表示
			if (frePprECnd.ExtraConditionTypeCd != 1)
			{
				this.ulRange.Visible			= false;
				this.tedEdExtraCharCode.Visible	= false;
				this.Height						= 70;
			}

			// 必須条件の背景色を設定（共通仕様）
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.tedStExtraCharCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
				this.tedEdExtraCharCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
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
