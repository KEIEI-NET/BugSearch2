using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;

using DataDynamics.ActiveReports;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票印字位置設定画面用各種共通制御部品
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置設定画面で使用する共通部品です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal static class SFANL08105UH
	{
		#region Const
		public const string ctASSEMBLY_ID = "SFANL08105U";	// アセンブリID
		#endregion

		#region PublicMethod
		/// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
		/// <remarks>
		/// <br>Note		: 数値入力値の妥当性チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.04.18</br>
		/// </remarks>
		public static bool KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key) == true)
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (Char.IsNumber(key) == false)
			{
				// 小数点または、マイナス以外
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string strResult = "";
			if (sellength > 0)
			{
				strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック！
			if (strResult.Length > keta)
			{
				if (strResult[0] == '-')
				{
					if (strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int pointPos = strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (pointPos != -1)
				{
					if (pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (pointPos != -1)
				{
					// 小数部の桁数を計算
					int priketa = strResult.Length - pointPos - 1;
					if (priod < priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion
	}
}
