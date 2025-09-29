using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 抽出条件入力画面（日付型）
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CD : Panel, IFreePrintUserControl
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08132CD()
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

			int startDate	= this.dateStartExtraDate.GetLongDate();
			int endDate		= this.dateEndExtraDate.GetLongDate();

			// 必須項目チェック
			if (isNecessaryExtraCondCheck)
			{
				if (this.dateEndExtraDate.Visible)
				{
					if ((startDate == 10101 || startDate == 0) &&
						(endDate == 10101 || endDate == 0))
					{
						message = this.ulExtraConditionTitle.Text + "が入力されていません。";
						control = this.dateStartExtraDate;
						return false;
					}
				}
				else
				{
					if (startDate == 0 || startDate == 10101)
					{
						message = this.ulExtraConditionTitle.Text + "が入力されていません。";
						control = this.dateStartExtraDate;
						return false;
					}
				}
			}

			if (this.dateEndExtraDate.Visible)
			{
				if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
				{
					message = this.ulExtraConditionTitle.Text + "（開始日）の入力が不正です。";
					control = this.dateStartExtraDate;
					return false;
				}

				if (endDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)))
				{
					message = this.ulExtraConditionTitle.Text + "（終了日）の入力が不正です。";
					control = this.dateEndExtraDate;
					return false;
				}

				// 大小チェック
				if (startDate > 10101 && endDate > 10101)
				{
					if (startDate > endDate)
					{
						message = this.ulExtraConditionTitle.Text + "の範囲指定が不正です。";
						control = this.dateStartExtraDate;
						return false;
					}
				}
			}
			else
			{
				if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
				{
					message = this.ulExtraConditionTitle.Text + "の入力が不正です。";
					control = this.dateStartExtraDate;
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <returns>ステータス</returns>
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			frePprECnd.StartExtraDate = this.dateStartExtraDate.GetLongDate();
			if (this.dateEndExtraDate.Visible)
				frePprECnd.EndExtraDate = this.dateEndExtraDate.GetLongDate();
			else
				frePprECnd.EndExtraDate = 0;

			if (this.uceStaSystemDateDiv.Checked) frePprECnd.StExtraNumCode = 1;
			else frePprECnd.StExtraNumCode = 0;

			if (this.uceEndSystemDateDiv.Checked) frePprECnd.EdExtraNumCode = 1;
			else frePprECnd.EdExtraNumCode = 0;
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// データの設定
			this.ulExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
			if (frePprECnd.StExtraNumCode == 0)
			{
				this.uceStaSystemDateDiv.Checked = false;
				this.dateStartExtraDate.SetLongDate(frePprECnd.StartExtraDate);
			}
			else
			{
				this.uceStaSystemDateDiv.Checked = true;
				this.dateStartExtraDate.SetToday();
			}
			if (frePprECnd.EdExtraNumCode == 0)
			{
				this.uceEndSystemDateDiv.Checked = false;
				this.dateEndExtraDate.SetLongDate(frePprECnd.EndExtraDate);
			}
			else
			{
				this.uceEndSystemDateDiv.Checked = true;
				this.dateEndExtraDate.SetToday();
			}

			// 抽出条件タイプ(0:一致)の時は終了条件を非表示
			if (frePprECnd.ExtraConditionTypeCd == 0)
			{
				this.ulRange.Visible				= false;
				this.dateEndExtraDate.Visible		= false;
				this.uceEndSystemDateDiv.Visible	= false;
				this.Height							= 81;
			}

			// 必須条件の背景色を設定（共通仕様）
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.dateStartExtraDate.EditAppearance.BackColor	= Color.FromArgb(179, 219, 231);
				this.dateEndExtraDate.EditAppearance.BackColor		= Color.FromArgb(179, 219, 231);
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

		/// <summary>
		/// CheckedChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: Checked プロパティの値が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void uceStaSystemDateDiv_CheckedChanged(object sender, EventArgs e)
		{
			this.dateStartExtraDate.ReadOnly = this.uceStaSystemDateDiv.Checked;
			if (this.uceStaSystemDateDiv.Checked) this.dateStartExtraDate.SetToday();
		}

		/// <summary>
		/// CheckedChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: Checked プロパティの値が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void uceEndSystemDateDiv_CheckedChanged(object sender, EventArgs e)
		{
			this.dateEndExtraDate.ReadOnly = this.uceEndSystemDateDiv.Checked;
			if (this.uceEndSystemDateDiv.Checked) this.dateEndExtraDate.SetToday();
		}
		#endregion
	}
}
