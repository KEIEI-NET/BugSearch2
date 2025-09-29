using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 抽出条件入力画面インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出条件入力画面用インターフェースです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public interface IFreePrintUserControl
	{
		/// <summary>自由帳票抽出条件明細マスタリスト</summary>
		List<FrePExCndD> FrePExCndDList { set; }

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="control">不正箇所のコントロール</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck);

		/// <summary>
		/// 自由帳票抽出条件設定情報取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <returns>ステータス</returns>
		void GetFrePprECndInfo(ref FrePprECnd frePprECnd);

		/// <summary>
		/// 自由帳票抽出条件設定情報設定処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		void SetFrePprECndInfo(FrePprECnd frePprECnd);
	}

	/// <summary>
	/// 抽出条件コントロール生成クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票で使用する抽出条件画面生成用クラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class SFANL08132CA
	{
		#region PublicStaticMethod
		/// <summary>
		/// 抽出条件コントロール取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="frePExCndDList">自由帳票抽出条件明細マスタリスト</param>
		/// <returns>取得コントロール</returns>
		public static Control GetExtrSettingControl(FrePprECnd frePprECnd, List<FrePExCndD> frePExCndDList)
		{
			Control retControl = null;

			// 抽出条件区分(0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボボックス型)
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 1:
				{
					retControl = new SFANL08132CB();
					break;
				}
				case 2:
				case 3:
				{
					retControl = new SFANL08132CC();
					break;
				}
				case 4:
				{
					// 抽出条件タイプ(0:一致,1:範囲,2:あいまい,3:期間（開始日基準）,4:期間（終了日基準）)
					switch (frePprECnd.ExtraConditionTypeCd)
					{
						case 0:
						case 1:
						{
							retControl = new SFANL08132CD();
							break;
						}
						case 3:
						case 4:
						{
							retControl = new SFANL08132CE();
							break;
						}
					}
					break;
				}
				case 5:
				{
					retControl = new SFANL08132CF();
					break;
				}
				case 6:
				{
					retControl = new SFANL08132CH();
					break;
				}
				default:
				{
					return null;
				}
			}

			retControl.Name		= GetControlName(frePprECnd);
			retControl.TabIndex	= frePprECnd.DisplayOrder;

			IFreePrintUserControl iFreePrintUserControl = retControl as IFreePrintUserControl;
			if (iFreePrintUserControl != null)
			{
				iFreePrintUserControl.FrePExCndDList = frePExCndDList;
				iFreePrintUserControl.SetFrePprECndInfo(frePprECnd);
			}

			return retControl;
		}

		/// <summary>
		/// 抽出条件コントロール取得処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
		/// <param name="frePExCndDList">自由帳票抽出条件明細マスタリスト</param>
		/// <returns>取得コントロールリスト</returns>
		public static List<Control> GetExtrSettingControl(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList)
		{
			List<Control> userControlList = new List<Control>();

			foreach (FrePprECnd frePprECnd in frePprECndList)
			{
				Control control = GetExtrSettingControl(frePprECnd, frePExCndDList);
				if (control != null)
					userControlList.Add(control);
			}

			return userControlList;
		}

		/// <summary>
		/// コントロール名取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <returns>コントロール名</returns>
		public static string GetControlName(FrePprECnd frePprECnd)
		{
			return frePprECnd.OutputFormFileName + "_" + frePprECnd.UserPrtPprIdDerivNo + "_" + frePprECnd.DDName;
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定LIST</param>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <param name="errIndex">不正となる項目のListIndex</param>
		/// <returns>チェック結果</returns>
		public static bool InputCheck(List<FrePprECnd> frePprECndList, bool isNecessaryExtraCondCheck, out string message, out int errIndex)
		{
			message		= string.Empty;
			errIndex	= -1;

			bool checkRet = true;

			for (int ix = 0 ; ix != frePprECndList.Count ; ix++)
			{
				if (frePprECndList[ix].UsedFlg == 1)
				{
					checkRet = InputCheck(frePprECndList[ix], isNecessaryExtraCondCheck, out message);
					if (!checkRet)
					{
						errIndex = ix;
						break;
					}
				}
			}

			return checkRet;
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		public static bool InputCheck(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			bool checkRet = true;

			// 抽出条件区分(0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型)
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 1:
				{
					checkRet = CheckNumType(frePprECnd, isNecessaryExtraCondCheck, out message);
					break;
				}
				case 2:
				case 3:
				{
					checkRet = CheckCharType(frePprECnd, isNecessaryExtraCondCheck, out message);
					break;
				}
				case 4:
				{
					checkRet = CheckDateType(frePprECnd, isNecessaryExtraCondCheck, out message);
					break;
				}
				case 5:
				case 6:
				{
					// チェック無し
					break;
				}
			}

			return checkRet;
		}
		#endregion

		#region PrivateStaticMethod
		/// <summary>
		/// 入力チェック処理（数値タイプ）
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		private static bool CheckNumType(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			// 抽出条件タイプ(0:一致,1:範囲,2:あいまい,3:期間（開始日基準）,4:期間（終了日基準）)
			switch (frePprECnd.ExtraConditionTypeCd)
			{
				case 0:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (frePprECnd.StExtraNumCode == 0)
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}
					break;
				}
				case 1:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (frePprECnd.StExtraNumCode == 0 && frePprECnd.EdExtraNumCode == 0)
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}

					if (frePprECnd.StExtraNumCode != 0 && frePprECnd.EdExtraNumCode != 0)
					{
						if (frePprECnd.StExtraNumCode > frePprECnd.EdExtraNumCode)
						{
							message = frePprECnd.ExtraConditionTitle + "の範囲指定が不正です。";
							return false;
						}
					}
					break;
				}
			}

			return true;
		}

		/// <summary>
		/// 入力チェック処理（文字タイプ）
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		private static bool CheckCharType(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			// 抽出条件タイプ(0:一致,1:範囲,2:あいまい,3:期間（開始日基準）,4:期間（終了日基準）)
			switch (frePprECnd.ExtraConditionTypeCd)
			{
				case 0:
				case 2:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (string.IsNullOrEmpty(frePprECnd.StExtraCharCode))
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}
					break;
				}
				case 1:
				{
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (string.IsNullOrEmpty(frePprECnd.StExtraCharCode) && string.IsNullOrEmpty(frePprECnd.EdExtraCharCode))
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}

					if (!string.IsNullOrEmpty(frePprECnd.StExtraCharCode) && !string.IsNullOrEmpty(frePprECnd.EdExtraCharCode))
					{
						if (string.Compare(frePprECnd.StExtraCharCode, frePprECnd.EdExtraCharCode) > 0)
						{
							message = frePprECnd.ExtraConditionTitle + "の範囲指定が不正です。";
							return false;
						}
					}
					break;
				}
			}

			return true;
		}

		/// <summary>
		/// 入力チェック処理（日付タイプ）
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="isNecessaryExtraCondCheck">必須条件チェック</param>
		/// <returns>チェック結果</returns>
		private static bool CheckDateType(FrePprECnd frePprECnd, bool isNecessaryExtraCondCheck, out string message)
		{
			message = string.Empty;

			if (frePprECnd.StExtraNumCode != 0)
				frePprECnd.StartExtraDate = TDateTime.DateTimeToLongDate(DateTime.Today);
			if (frePprECnd.EdExtraNumCode != 0)
				frePprECnd.EndExtraDate = TDateTime.DateTimeToLongDate(DateTime.Today);

			int startDate	= frePprECnd.StartExtraDate;
			int endDate		= frePprECnd.EndExtraDate;
			// 抽出条件タイプ(0:一致,1:範囲,2:あいまい,3:期間（開始日基準）,4:期間（終了日基準）)
			switch (frePprECnd.ExtraConditionTypeCd)
			{
				case 0:
				{
					// 必須項目チェック
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if (startDate == 0 || startDate == 10101)
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}

					if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
					{
						message = frePprECnd.ExtraConditionTitle + "の入力が不正です。";
						return false;
					}
					break;
				}
				case 1:
				{
					// 必須項目チェック
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if ((startDate == 10101 || startDate == 0) && (endDate == 10101 || endDate == 0))
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}

					if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
					{
						message = frePprECnd.ExtraConditionTitle + "（開始日）の入力が不正です。";
						return false;
					}

					if (endDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)))
					{
						message = frePprECnd.ExtraConditionTitle + "（終了日）の入力が不正です。";
						return false;
					}

					// 大小チェック
					if (startDate > 10101 && endDate > 10101)
					{
						if (startDate > endDate)
						{
							message = frePprECnd.ExtraConditionTitle + "の範囲指定が不正です。";
							return false;
						}
					}
					break;
				}
				case 3:
				case 4:
				{
					// 必須項目チェック
					if (frePprECnd.NecessaryExtraCondCd == 1 && isNecessaryExtraCondCheck)
					{
						if ((startDate == 10101 || startDate == 0) && (endDate == 10101 || endDate == 0))
						{
							message = frePprECnd.ExtraConditionTitle + "が入力されていません。";
							return false;
						}
					}

					// 大小チェック
					if (startDate > 10101 && endDate > 10101)
					{
						if (startDate > endDate)
						{
							message = frePprECnd.ExtraConditionTitle + "の範囲指定が不正です。";
							return false;
						}
					}
					break;
				}
			}

			return true;
		}
		#endregion
	}
}
