using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 抽出条件入力画面（期間型）
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CE : Panel, IFreePrintUserControl
	{
		#region PrivateMember
		// 起動基準（3:開始日基準,4:終了日基準）
		private int _extraConditionTypeCd = 0;
		// 開始日基準、終了日基準時の座標位置変更用
		private const int ctStPoint1 = 35;
		private const int ctStPoint2 = 65;
		private const int ctEdPoint1 = 112;
		private const int ctEdPoint2 = 142;
		// 数値変更チェック用バッファ
		private int _numBuff = 0;
		#endregion

		#region Const
		private const string ctStartDateBaseComment = "開始日から　　　　　　後";
		private const string ctEndDateBaseComment	= "終了日から　　　　　　前";
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08132CE()
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

			int startDate	= 0;
			int endDate		= 0;
			if (_extraConditionTypeCd == 3)
			{
				startDate	= this.dateExtraDate.GetLongDate();
				endDate		= this.dateExtraDateTerm.GetLongDate();
			}
			else
			{
				startDate	= this.dateExtraDateTerm.GetLongDate();
				endDate		= this.dateExtraDate.GetLongDate();
			}

			// 必須項目チェック
			if (isNecessaryExtraCondCheck)
			{
				if ((startDate == 10101 || startDate == 0) &&
					(endDate == 10101 || endDate == 0))
				{
					message = this.ulExtraConditionTitle.Text + "が入力されていません。";
					if (_extraConditionTypeCd == 3)
						control = this.cmbExtraDateBaseCd;
					else
						control = this.nedExtraDateNumTerm;
					return false;
				}
			}

			// 大小チェック
			if (startDate > 10101 && endDate > 10101)
			{
				if (startDate > endDate)
				{
					message = this.ulExtraConditionTitle.Text + "の範囲指定が不正です。";
					if (_extraConditionTypeCd == 3)
						control = this.cmbExtraDateBaseCd;
					else
						control = this.nedExtraDateNumTerm;
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
			if (frePprECnd.ExtraConditionTypeCd == 3)
			{
				// ☆☆☆ 期間（開始日基準） ☆☆☆
				frePprECnd.StExtraDateSignCd	= (int)this.cmbExtraDateSignCd.Value;
				frePprECnd.StExtraDateNum		= this.nedExtraDateNum.GetInt();
				frePprECnd.StExtraDateUnitCd	= (int)this.cmbExtraDateUnitCd.Value;
				frePprECnd.StExtraDateBaseCd	= (int)this.cmbExtraDateBaseCd.Value;
				frePprECnd.StartExtraDate		= this.dateExtraDate.GetLongDate();

				frePprECnd.EdExtraDateBaseCd	= 2;
				frePprECnd.EdExtraDateSignCd	= 0;
				frePprECnd.EdExtraDateNum		= this.nedExtraDateNumTerm.GetInt();
				frePprECnd.EdExtraDateUnitCd	= (int)this.cmbExtraDateUnitCdTerm.Value;
				frePprECnd.EndExtraDate			= this.dateExtraDateTerm.GetLongDate();
			}
			else
			{
				// ☆☆☆ 期間（終了日基準） ☆☆☆
				frePprECnd.EdExtraDateSignCd	= (int)this.cmbExtraDateSignCd.Value;
				frePprECnd.EdExtraDateNum		= this.nedExtraDateNum.GetInt();
				frePprECnd.EdExtraDateUnitCd	= (int)this.cmbExtraDateUnitCd.Value;
				frePprECnd.EdExtraDateBaseCd	= (int)this.cmbExtraDateBaseCd.Value;
				frePprECnd.EndExtraDate			= this.dateExtraDate.GetLongDate();

				frePprECnd.StExtraDateBaseCd	= 2;
				frePprECnd.StExtraDateSignCd	= 0;
				frePprECnd.StExtraDateNum		= this.nedExtraDateNumTerm.GetInt();
				frePprECnd.StExtraDateUnitCd	= (int)this.cmbExtraDateUnitCdTerm.Value;
				frePprECnd.StartExtraDate		= this.dateExtraDateTerm.GetLongDate();
			}
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			_extraConditionTypeCd = frePprECnd.ExtraConditionTypeCd;

			// 抽出条件タイプ
			if (frePprECnd.ExtraConditionTypeCd == 3)
			{
				// ☆☆☆ 期間（開始日基準） ☆☆☆
				// 画面レイアウトを設定
				this.cmbExtraDateBaseCd.Top				= ctStPoint1;
				this.cmbExtraDateSignCd.Top				= ctStPoint1;
				this.nedExtraDateNum.Top				= ctStPoint1;
				this.cmbExtraDateUnitCd.Top				= ctStPoint1;
				this.dateExtraDate.Top					= ctStPoint2;
				this.cmbExtraDateBaseCd.TabIndex		= 1;
				this.cmbExtraDateSignCd.TabIndex		= 2;
				this.nedExtraDateNum.TabIndex			= 3;
				this.cmbExtraDateUnitCd.TabIndex		= 4;
				this.dateExtraDate.TabIndex				= 5;

				this.ulTermComment.Top					= ctEdPoint1;
				this.nedExtraDateNumTerm.Top			= ctEdPoint1;
				this.cmbExtraDateUnitCdTerm.Top 		= ctEdPoint1;
				this.dateExtraDateTerm.Top				= ctEdPoint2;
				this.ulTermComment.TabIndex				= 6;
				this.nedExtraDateNumTerm.TabIndex		= 7;
				this.cmbExtraDateUnitCdTerm.TabIndex	= 8;
				this.dateExtraDateTerm.TabIndex			= 9;

				this.ulExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
				this.ulTermComment.Text			= ctStartDateBaseComment;

				// 抽出開始日付（基準）
				this.cmbExtraDateBaseCd.Value = frePprECnd.StExtraDateBaseCd;
				if (frePprECnd.StExtraDateBaseCd == 5)	// 5:日付指定
				{
					this.dateExtraDate.SetDateTime(TDateTime.LongDateToDateTime(frePprECnd.StartExtraDate));
				}
				else
				{
					this.cmbExtraDateSignCd.Value	= frePprECnd.StExtraDateSignCd;
					this.nedExtraDateNum.SetInt(frePprECnd.StExtraDateNum);
					this.cmbExtraDateUnitCd.Value	= frePprECnd.StExtraDateUnitCd;
				}

				this.nedExtraDateNumTerm.SetInt(frePprECnd.EdExtraDateNum);
				this.cmbExtraDateUnitCdTerm.Value = frePprECnd.EdExtraDateUnitCd;
			}
			else
			{
				// ☆☆☆ 期間（終了日基準） ☆☆☆
				// 画面レイアウトを設定
				this.cmbExtraDateBaseCd.Top				= ctEdPoint1;
				this.cmbExtraDateSignCd.Top				= ctEdPoint1;
				this.nedExtraDateNum.Top				= ctEdPoint1;
				this.cmbExtraDateUnitCd.Top				= ctEdPoint1;
				this.dateExtraDate.Top					= ctEdPoint2;
				this.cmbExtraDateBaseCd.TabIndex		= 5;
				this.cmbExtraDateSignCd.TabIndex		= 6;
				this.nedExtraDateNum.TabIndex			= 7;
				this.cmbExtraDateUnitCd.TabIndex		= 8;
				this.dateExtraDate.TabIndex				= 9;

				this.ulTermComment.Top					= ctStPoint1;
				this.nedExtraDateNumTerm.Top			= ctStPoint1;
				this.cmbExtraDateUnitCdTerm.Top 		= ctStPoint1;
				this.dateExtraDateTerm.Top				= ctStPoint2;
				this.ulTermComment.TabIndex				= 1;
				this.nedExtraDateNumTerm.TabIndex		= 2;
				this.cmbExtraDateUnitCdTerm.TabIndex	= 3;
				this.dateExtraDateTerm.TabIndex			= 4;

				this.ulExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
				this.ulTermComment.Text			= ctEndDateBaseComment;

				this.cmbExtraDateBaseCd.Value = frePprECnd.EdExtraDateBaseCd;
				// 抽出開始日付（基準）
				if (frePprECnd.EdExtraDateBaseCd == 5)	// 5:日付指定
				{
					this.dateExtraDate.SetDateTime(TDateTime.LongDateToDateTime(frePprECnd.EndExtraDate));
				}
				else
				{
					this.cmbExtraDateSignCd.Value	= frePprECnd.EdExtraDateSignCd;
					this.nedExtraDateNum.SetInt(frePprECnd.EdExtraDateNum);
					this.cmbExtraDateUnitCd.Value	= frePprECnd.EdExtraDateUnitCd;
				}

				this.nedExtraDateNumTerm.SetInt(frePprECnd.StExtraDateNum);
				this.cmbExtraDateUnitCdTerm.Value = frePprECnd.StExtraDateUnitCd;
			}

			// 必須条件の背景色を設定（共通仕様）
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.dateExtraDate.EditAppearance.BackColor			= Color.FromArgb(179, 219, 231);
				this.dateExtraDateTerm.EditAppearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.cmbExtraDateSignCd.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.nedExtraDateNum.Appearance.BackColor			= Color.FromArgb(179, 219, 231);
				this.cmbExtraDateUnitCd.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.nedExtraDateNumTerm.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.cmbExtraDateUnitCdTerm.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
			}

			// 抽出期間を算定
			CalculateTerm();
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 抽出期間算定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面に入力されたデータを元に抽出期間を算定します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void CalculateTerm()
		{
			if (this.cmbExtraDateBaseCd.Value == null ||
				this.cmbExtraDateSignCd.Value == null ||
				this.cmbExtraDateUnitCd.Value == null ||
				this.cmbExtraDateUnitCdTerm.Value == null)
				return;

			int extraDateBaseCd = (int)this.cmbExtraDateBaseCd.Value;
			if (extraDateBaseCd != 5)
			{
				int extraDateSignCd	= (int)this.cmbExtraDateSignCd.Value;
				int extraDateNum	= this.nedExtraDateNum.GetInt();
				int extraDateUnitCd	= (int)this.cmbExtraDateUnitCd.Value;
				// 抽出基準日を計算
				DateTime wkDateTime = CalculateDate(DateTime.Today
					, extraDateBaseCd
					, extraDateSignCd
					, extraDateNum
					, extraDateUnitCd);
				this.dateExtraDate.SetDateTime(wkDateTime);
			}

			DateTime baseDate = this.dateExtraDate.GetDateTime();

			int extraDateNumTerm	= this.nedExtraDateNumTerm.GetInt();
			int extraDateUnitCdTerm	= (int)this.cmbExtraDateUnitCdTerm.Value;
			// 期間を算定
			DateTime termDate = DateTime.MinValue;
			if (baseDate != DateTime.MinValue)
			{
				if (_extraConditionTypeCd == 3)
					termDate = CalculateDate(baseDate, 2, 0, extraDateNumTerm, extraDateUnitCdTerm);
				else
					termDate = CalculateDate(baseDate, 2, 1, extraDateNumTerm, extraDateUnitCdTerm);
			}
			this.dateExtraDateTerm.SetDateTime(termDate);
		}

		/// <summary>
		/// 日付算定処理
		/// </summary>
		/// <param name="baseDate">計算基準日</param>
		/// <param name="baseCd">基準(0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定)</param>
		/// <param name="sign">符号（0:＋,1:－）</param>
		/// <param name="num">数値</param>
		/// <param name="unit">単位（0:日,1:週,2:月,3:年）</param>
		/// <returns>算定結果日付</returns>
		/// <remarks>
		/// <br>Note		: 日付の算定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private DateTime CalculateDate(DateTime baseDate, int baseCd, int sign, int num, int unit)
		{
			DateTime retDate = baseDate;

			// 基準日を算定
			switch (baseCd)
			{
				case 0: retDate = retDate.AddDays(-2); break;
				case 1: retDate = retDate.AddDays(-1); break;
				case 3: retDate = retDate.AddDays(1); break;
				case 4: retDate = retDate.AddDays(2); break;
			}

			if (sign == 1)
				num *= -1;

			switch (unit)
			{
				case 0: retDate = retDate.AddDays(num); break;
				case 1: retDate = retDate.AddDays(num * 7); break;
				case 2: retDate = retDate.AddMonths(num); break;
				case 3: retDate = retDate.AddYears(num); break;
			}

			return retDate;
		}
		#endregion

		#region Event
		/// <summary>
		/// 期間項目SelectionChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 選択が変更された場合に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void ExtrTerm_SelectionChanged(object sender, EventArgs e)
		{
			if (sender == this.cmbExtraDateBaseCd)
			{
				if ((int)this.cmbExtraDateBaseCd.Value == 5)
				{
					// データをクリア
					this.cmbExtraDateSignCd.SelectedIndex	= 0;
					this.nedExtraDateNum.Clear();
					this.cmbExtraDateUnitCd.SelectedIndex	= 0;
					// 入力制御
					this.cmbExtraDateSignCd.Enabled	= false;
					this.nedExtraDateNum.Enabled	= false;
					this.cmbExtraDateUnitCd.Enabled	= false;
					this.dateExtraDate.ReadOnly		= false;
				}
				else
				{
					// 入力制御
					this.cmbExtraDateSignCd.Enabled	= true;
					this.nedExtraDateNum.Enabled	= true;
					this.cmbExtraDateUnitCd.Enabled	= true;
					this.dateExtraDate.ReadOnly		= true;
				}
			}

			// 抽出期間を算定
			CalculateTerm();
		}

		/// <summary>
		/// 数値項目Enterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールに</br>
		/// <br>			: なったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void ExtrTerm_Enter(object sender, EventArgs e)
		{
			if (sender is TNedit)
				_numBuff = ((TNedit)sender).GetInt();
			else if (sender is TDateEdit)
				_numBuff = ((TDateEdit)sender).GetLongDate();
		}

		/// <summary>
		/// 数値項目Leaveイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールで</br>
		/// <br>			: なくなったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void ExtrTerm_Leave(object sender, EventArgs e)
		{
			if (sender is TNedit)
			{
				TNedit wkTNedit = (TNedit)sender;
				// 抽出期間を算定
				if (!_numBuff.Equals(wkTNedit.GetInt()))
					CalculateTerm();
			}
			else if (sender is TDateEdit)
			{
				TDateEdit wkTDateEdit = (TDateEdit)sender;
				// 抽出期間を算定
				if (!_numBuff.Equals(wkTDateEdit.GetLongDate()))
					CalculateTerm();
			}
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
