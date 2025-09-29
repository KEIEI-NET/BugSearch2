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
	/// 抽出条件入力画面（数値型）
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CB : Panel, IFreePrintUserControl
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08132CB()
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
		/// <param name="control">不正箇所のコントロール</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		public bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			control = null;

			long startCode	= (long)this.nedStExtraNumCode.GetValue();
			long endCode	= (long)this.nedEdExtraNumCode.GetValue();

			// 必須項目チェック
			if (isNecessaryExtraCondCheck)
			{
				if (this.nedEdExtraNumCode.Visible)
				{
					if (startCode == 0 && endCode == 0)
					{
						message = this.ulExtraConditionTitle.Text + "が入力されていません。";
						control = this.nedStExtraNumCode;
						return false;
					}
				}
				else
				{
					if (startCode == 0)
					{
						message = this.ulExtraConditionTitle.Text + "が入力されていません。";
						control = this.nedStExtraNumCode;
						return false;
					}
				}
			}

			// 大小チェック
			if (this.nedEdExtraNumCode.Visible)
			{
				if (startCode != 0 && endCode != 0)
				{
					if (startCode > endCode)
					{
						message = this.ulExtraConditionTitle.Text + "の範囲指定が不正です。";
						control = this.nedStExtraNumCode;
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
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			frePprECnd.StExtraNumCode = (long)this.nedStExtraNumCode.GetValue();
			if (this.nedEdExtraNumCode.Visible)
				frePprECnd.EdExtraNumCode = (long)this.nedEdExtraNumCode.GetValue();
			else
				frePprECnd.EdExtraNumCode = 0;
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// データの設定
			this.ulExtraConditionTitle.Text			= frePprECnd.ExtraConditionTitle;
			this.nedStExtraNumCode.SetValue(frePprECnd.StExtraNumCode);
			this.nedStExtraNumCode.ExtEdit.Column	= frePprECnd.InputCharCnt;
			this.nedEdExtraNumCode.SetValue(frePprECnd.EdExtraNumCode);
			this.nedEdExtraNumCode.ExtEdit.Column	= frePprECnd.InputCharCnt;

			// 抽出条件タイプ(0:一致)の時は終了条件を非表示
			if (frePprECnd.ExtraConditionTypeCd == 0)
			{
				this.ulRange.Visible			= false;
				this.nedEdExtraNumCode.Visible	= false;
				this.Height						= 70;
			}

			// 必須条件の背景色を設定（共通仕様）
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.nedStExtraNumCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
				this.nedEdExtraNumCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
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
