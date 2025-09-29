using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票検索条件UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票検索条件UIです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08131UA : Panel
	{
		#region PrivateMember
		// エラーメッセージ
		private StringBuilder _errorStr;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08131UA()
		{
			InitializeComponent();

			_errorStr = new StringBuilder();
		}
		#endregion

		#region Property
		/// <summary>
		/// エラーメッセージ取得処理
		/// </summary>
		/// <returns></returns>
		public string GetErrorMessage
		{
			get { return _errorStr.ToString(); }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 自由帳票検索条件画面表示処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
		/// <param name="frePExCndDList">自由帳票抽出条件明細マスタリスト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票検索条件画面の表示処理です。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public int FreePrintExtrUIShow(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			frePprECndList.Sort(new FrePprECndComparer());

			List<FrePprECnd> wkFrePprECndList = frePprECndList.FindAll(
				delegate(FrePprECnd frePprECnd)
				{
					if (frePprECnd.UsedFlg == 1)
						return true;
					else
						return false;
				}
			);

			this.Show();

			this.SuspendLayout();
			try
			{
				List<Control> addControlList = SFANL08132CA.GetExtrSettingControl(wkFrePprECndList, frePExCndDList);
				if (addControlList != null && addControlList.Count > 0)
				{
					while (this.Controls.Count > 0)
						this.Controls[0].Dispose();

					foreach (Control addControl in addControlList)
					{
						if (addControl is IFreePrintUserControl)
						{
							this.Controls.Add(addControl);
							addControl.Dock = DockStyle.Top;
							addControl.BringToFront();
						}
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr.Append("自由帳票検索条件画面表示処理にて例外が発生しました。");
				_errorStr.Append("\r\n").Append(ex.Message);

				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				this.ResumeLayout(true);
			}

			return status;
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="errorControl">不正時のコントロール</param>
		/// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票検索条件画面の入力チェック処理です。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public bool InputCheck(List<FrePprECnd> frePprECndList, out string message, out Control errorControl, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			errorControl = null;

			for (int ix = 0 ; ix != frePprECndList.Count ; ix++)
			{
				FrePprECnd frePprECnd = frePprECndList[ix];
				if (frePprECnd.UsedFlg == 1)
				{
					string controlName = SFANL08132CA.GetControlName(frePprECnd);
					if (this.Controls.ContainsKey(controlName))
					{
						IFreePrintUserControl iFreePrintUserControl = this.Controls[controlName] as IFreePrintUserControl;
						if (iFreePrintUserControl != null)
						{
							if (isNecessaryExtraCondCheck && frePprECnd.NecessaryExtraCondCd == 1)
							{
								if (!iFreePrintUserControl.InputCheck(out message, out errorControl, true))
									return false;
							}
							else
							{
								if (!iFreePrintUserControl.InputCheck(out message, out errorControl, false))
									return false;
							}
						}
					}
				}
			}
			return true;
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタ取得処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
		/// <remarks>
		/// <br>Note		: 画面より自由帳票抽出条件設定マスタを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		public void GetFrePprECndList(ref List<FrePprECnd> frePprECndList)
		{
			for (int ix = 0 ; ix != frePprECndList.Count ; ix++)
			{
				FrePprECnd frePprECnd = frePprECndList[ix];
				if (frePprECnd.UsedFlg == 1)
				{
					string controlName = SFANL08132CA.GetControlName(frePprECnd);
					if (this.Controls.ContainsKey(controlName))
					{
						IFreePrintUserControl iFreePrintUserControl = this.Controls[controlName] as IFreePrintUserControl;
						if (iFreePrintUserControl != null)
							iFreePrintUserControl.GetFrePprECndInfo(ref frePprECnd);
					}
				}
			}
		}
		#endregion
	}

	/// <summary>
	/// 自由帳票抽出条件比較クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票抽出条件LIST用の比較クラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class FrePprECndComparer : IComparer<FrePprECnd>
	{
		#region IComparer<FrePprECnd> メンバ
		/// <summary>
		/// 比較処理
		/// </summary>
		/// <param name="x">比較対象1</param>
		/// <param name="y">比較対象2</param>
		/// <returns>比較結果</returns>
		public int Compare(FrePprECnd x, FrePprECnd y)
		{
			int retInt = x.DisplayOrder.CompareTo(y.DisplayOrder);
			if (retInt != 0)
				return retInt;
			else
				return x.FrePrtPprExtraCondCd.CompareTo(y.FrePrtPprExtraCondCd);
		}
		#endregion
	}
}