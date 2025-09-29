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
	/// 抽出条件入力画面（コンボボックス型）
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CF : Panel, IFreePrintUserControl
	{
		#region PrivateMember
		// 自由帳票抽出条件明細マスタリスト
		private List<FrePExCndD> _frePExCndDList;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08132CF()
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
			try
			{
				frePprECnd.StExtraNumCode = (int)this.cmbExtraCondDtlGrpCd.Value;
			}
			catch (Exception)
			{
				frePprECnd.StExtraNumCode = 0;
			}
		}

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// 初期設定
			if (_frePExCndDList != null && this.cmbExtraCondDtlGrpCd.Items.Count == 0)
			{
				this.cmbExtraCondDtlGrpCd.Items.Add(0, "　");
				foreach (FrePExCndD frePExCndD in _frePExCndDList)
				{
					if (frePprECnd.ExtraCondDetailGrpCd == frePExCndD.ExtraCondDetailGrpCd)
						this.cmbExtraCondDtlGrpCd.Items.Add(frePExCndD.ExtraCondDetailCode, frePExCndD.ExtraCondDetailName);
				}
			}

			// データの設定
			this.ulExtraConditionTitle.Text = frePprECnd.ExtraConditionTitle;
			this.cmbExtraCondDtlGrpCd.Value = frePprECnd.StExtraNumCode;

			// 必須条件の背景色を設定（共通仕様）
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.cmbExtraCondDtlGrpCd.Appearance.BackColor = Color.FromArgb(179, 219, 231);
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
