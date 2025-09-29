using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTabControl;
using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	internal class TLib
	{
		internal class ordercmp : IComparer
		{
			public int Compare(object x, object y)
			{
				return ((Control)x).TabIndex - ((Control)y).TabIndex;
			}
		}
		public enum TCheckDateStat
		{
			cdsOk,
			cdsIllegalYear,
			cdsIllegalMonth,
			cdsIllegalDay
		}
		private const int kMinYear = 1;
		private const int kMaxYear = 9999;
		private const int kMinMonth = 1;
		private const int kMaxMonth = 12;
		private const int kMinDay = 1;
		private const int kMaxDay = 31;
		private static int[] kNormalYear = new int[]
		{
			31,
			28,
			31,
			30,
			31,
			30,
			31,
			31,
			30,
			31,
			30,
			31
		};
		private static int[] kLeepYear = new int[]
		{
			31,
			29,
			31,
			30,
			31,
			30,
			31,
			31,
			30,
			31,
			30,
			31
		};
		public static void DelStrChar(ref string iStr, char Chk)
		{
			for (int i = iStr.Length - 1; i >= 0; i--)
			{
				if (iStr[i] == Chk)
				{
					iStr = iStr.Remove(i, 1);
				}
			}
		}
		public static int CountChar(string iStr, char Chk)
		{
			int num = 0;
			if (iStr != null)
			{
				for (int i = 0; i < iStr.Length; i++)
				{
					if (iStr[i] == Chk)
					{
						num++;
					}
				}
			}
			return num;
		}
		public static bool GetNumStrAttr(string iStr, out stNumStrAttr iAttr)
		{
			CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
			string numberDecimalSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator;
			string negativeSign = cultureInfo.NumberFormat.NegativeSign;
			string positiveSign = cultureInfo.NumberFormat.PositiveSign;
			iAttr.Sign = false;
			iAttr.HiColumn = 0;
			iAttr.piriod = false;
			iAttr.LoColumn = 0;
			if (iStr == null)
			{
				return true;
			}
			try
			{
				float.Parse(iStr);
			}
			catch
			{
				if (!iStr.EndsWith(numberDecimalSeparator) || TLib.CountChar(iStr, numberDecimalSeparator[0]) != 1)
				{
					return false;
				}
			}
			for (int i = 0; i < iStr.Length; i++)
			{
				if (iStr[i] == negativeSign[0] || iStr[i] == positiveSign[0])
				{
					iAttr.Sign = true;
				}
				else
				{
					if (iStr[i] == numberDecimalSeparator[0])
					{
						iAttr.piriod = true;
					}
					else
					{
						if (!iAttr.piriod)
						{
							iAttr.HiColumn++;
						}
						else
						{
							iAttr.LoColumn++;
						}
					}
				}
			}
			return true;
		}
		private static bool IsCharCheck(char key, char[] arChk)
		{
			if (arChk != null)
			{
				for (int i = 0; i < arChk.Length; i++)
				{
					if (arChk[i] == key)
					{
						return true;
					}
				}
			}
			return false;
		}
		public static bool IsSign(char key)
		{
			char[] arChk = new char[]
			{
				'!',
				'"',
				'#',
				'$',
				'%',
				'&',
				'\'',
				'(',
				')',
				':',
				';',
				'<',
				'>',
				'?',
				'@',
				'[',
				'\\',
				']',
				'^',
				'{',
				'|',
				'}',
				'~',
				'_'
			};
			return TLib.IsCharCheck(key, arChk);
		}
		public static bool IsKana(char key)
		{
			char[] arChk = new char[]
			{
				'｡',
				'｢',
				'｣',
				'､',
				'･',
				'ｦ',
				'ｧ',
				'ｨ',
				'ｩ',
				'ｪ',
				'ｫ',
				'ｬ',
				'ｭ',
				'ｮ',
				'ｯ',
				'ｰ',
				'ｱ',
				'ｲ',
				'ｳ',
				'ｴ',
				'ｵ',
				'ｶ',
				'ｷ',
				'ｸ',
				'ｹ',
				'ｺ',
				'ｻ',
				'ｼ',
				'ｽ',
				'ｾ',
				'ｿ',
				'ﾀ',
				'ﾁ',
				'ﾂ',
				'ﾃ',
				'ﾄ',
				'ﾅ',
				'ﾆ',
				'ﾇ',
				'ﾈ',
				'ﾉ',
				'ﾊ',
				'ﾋ',
				'ﾌ',
				'ﾍ',
				'ﾎ',
				'ﾏ',
				'ﾐ',
				'ﾑ',
				'ﾒ',
				'ﾓ',
				'ﾔ',
				'ﾕ',
				'ﾖ',
				'ﾗ',
				'ﾘ',
				'ﾙ',
				'ﾚ',
				'ﾛ',
				'ﾜ',
				'ﾝ',
				'ﾞ',
				'ﾟ'
			};
			return TLib.IsCharCheck(key, arChk);
		}
		public static bool IsAlpha(char key)
		{
			char[] arChk = new char[]
			{
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'I',
				'J',
				'K',
				'L',
				'M',
				'N',
				'O',
				'P',
				'Q',
				'R',
				'S',
				'T',
				'U',
				'V',
				'W',
				'X',
				'Y',
				'Z',
				'a',
				'b',
				'c',
				'd',
				'e',
				'f',
				'g',
				'h',
				'i',
				'j',
				'k',
				'l',
				'm',
				'n',
				'o',
				'p',
				'q',
				'r',
				's',
				't',
				'u',
				'v',
				'w',
				'x',
				'y',
				'z'
			};
			return TLib.IsCharCheck(key, arChk);
		}
		public static bool IsNumSign(char key)
		{
			char[] arChk = new char[]
			{
				'-',
				'/',
				'*',
				'+',
				'=',
				'.',
				','
			};
			return TLib.IsCharCheck(key, arChk);
		}
		public static bool IsNum(char key)
		{
			char[] arChk = new char[]
			{
				'0',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9'
			};
			return TLib.IsCharCheck(key, arChk);
		}
		public static bool IsCtrl(char key)
		{
			return char.IsControl(key);
		}
		public static bool IsWord(char key)
		{
			return !TLib.IsSign(key) && key != ' ' && !TLib.IsKana(key) && !TLib.IsAlpha(key) && !TLib.IsNumSign(key) && !TLib.IsNum(key) && !TLib.IsCtrl(key);
		}
		public static string HankanaToZenkana(string instr)
		{
			string[] array = new string[]
			{
				"ｶﾞ",
				"ｷﾞ",
				"ｸﾞ",
				"ｹﾞ",
				"ｺﾞ",
				"ｻﾞ",
				"ｼﾞ",
				"ｽﾞ",
				"ｾﾞ",
				"ｿﾞ",
				"ﾀﾞ",
				"ﾁﾞ",
				"ﾂﾞ",
				"ﾃﾞ",
				"ﾄﾞ",
				"ﾊﾞ",
				"ﾋﾞ",
				"ﾌﾞ",
				"ﾍﾞ",
				"ﾎﾞ",
				"ﾊﾟ",
				"ﾋﾟ",
				"ﾌﾟ",
				"ﾍﾟ",
				"ﾎﾟ",
				"ｳﾞ"
			};
			string[] array2 = new string[]
			{
				"ガ",
				"ギ",
				"グ",
				"ゲ",
				"ゴ",
				"ザ",
				"ジ",
				"ズ",
				"ゼ",
				"ゾ",
				"ダ",
				"ヂ",
				"ヅ",
				"デ",
				"ド",
				"バ",
				"ビ",
				"ブ",
				"ベ",
				"ボ",
				"パ",
				"ピ",
				"プ",
				"ペ",
				"ポ",
				"ヴ"
			};
			char[] array3 = new char[]
			{
				'｡',
				'｢',
				'｣',
				'､',
				'･',
				'ｦ',
				'ｧ',
				'ｨ',
				'ｩ',
				'ｪ',
				'ｫ',
				'ｬ',
				'ｭ',
				'ｮ',
				'ｯ',
				'ｰ',
				'ｱ',
				'ｲ',
				'ｳ',
				'ｴ',
				'ｵ',
				'ｶ',
				'ｷ',
				'ｸ',
				'ｹ',
				'ｺ',
				'ｻ',
				'ｼ',
				'ｽ',
				'ｾ',
				'ｿ',
				'ﾀ',
				'ﾁ',
				'ﾂ',
				'ﾃ',
				'ﾄ',
				'ﾅ',
				'ﾆ',
				'ﾇ',
				'ﾈ',
				'ﾉ',
				'ﾊ',
				'ﾋ',
				'ﾌ',
				'ﾍ',
				'ﾎ',
				'ﾏ',
				'ﾐ',
				'ﾑ',
				'ﾒ',
				'ﾓ',
				'ﾔ',
				'ﾕ',
				'ﾖ',
				'ﾗ',
				'ﾘ',
				'ﾙ',
				'ﾚ',
				'ﾛ',
				'ﾜ',
				'ﾝ',
				'ﾞ',
				'ﾟ'
			};
			char[] array4 = new char[]
			{
				'。',
				'「',
				'」',
				'、',
				'・',
				'ヲ',
				'ァ',
				'ィ',
				'ゥ',
				'ェ',
				'ォ',
				'ャ',
				'ュ',
				'ョ',
				'ッ',
				'ー',
				'ア',
				'イ',
				'ウ',
				'エ',
				'オ',
				'カ',
				'キ',
				'ク',
				'ケ',
				'コ',
				'サ',
				'シ',
				'ス',
				'セ',
				'ソ',
				'タ',
				'チ',
				'ツ',
				'テ',
				'ト',
				'ナ',
				'ニ',
				'ヌ',
				'ネ',
				'ノ',
				'ハ',
				'ヒ',
				'フ',
				'ヘ',
				'ホ',
				'マ',
				'ミ',
				'ム',
				'メ',
				'モ',
				'ヤ',
				'ユ',
				'ヨ',
				'ラ',
				'リ',
				'ル',
				'レ',
				'ロ',
				'ワ',
				'ン',
				'゛',
				'゜'
			};
			for (int i = 0; i < array.Length; i++)
			{
				instr = instr.Replace(array[i], array2[i]);
			}
			for (int j = 0; j < array3.Length; j++)
			{
				instr = instr.Replace(array3[j], array4[j]);
			}
			return instr;
		}
		public static string HiraToKana(string instr)
		{
			char[] array = new char[]
			{
				'を',
				'ぁ',
				'ぃ',
				'ぅ',
				'ぇ',
				'ぉ',
				'ゃ',
				'ゅ',
				'ょ',
				'っ',
				'ー',
				'あ',
				'い',
				'う',
				'え',
				'お',
				'か',
				'き',
				'く',
				'け',
				'こ',
				'さ',
				'し',
				'す',
				'せ',
				'そ',
				'た',
				'ち',
				'つ',
				'て',
				'と',
				'な',
				'に',
				'ぬ',
				'ね',
				'の',
				'は',
				'ひ',
				'ふ',
				'へ',
				'ほ',
				'ま',
				'み',
				'む',
				'め',
				'も',
				'や',
				'ゆ',
				'よ',
				'ら',
				'り',
				'る',
				'れ',
				'ろ',
				'わ',
				'ん',
				'が',
				'ぎ',
				'ぐ',
				'げ',
				'ご',
				'ざ',
				'じ',
				'ず',
				'ぜ',
				'ぞ',
				'だ',
				'ぢ',
				'づ',
				'で',
				'ど',
				'ば',
				'び',
				'ぶ',
				'べ',
				'ぼ',
				'ぱ',
				'ぴ',
				'ぷ',
				'ぺ',
				'ぽ',
				'ゐ',
				'ゑ',
				'！',
				'”',
				'＃',
				'＄',
				'％',
				'＆',
				'’',
				'（',
				'）',
				'＊',
				'，',
				'－',
				'．',
				'／',
				'０',
				'１',
				'２',
				'３',
				'４',
				'５',
				'６',
				'７',
				'８',
				'９',
				'：',
				'；',
				'＜',
				'＝',
				'＞',
				'？',
				'＠',
				'～'
			};
			char[] array2 = new char[]
			{
				'ヲ',
				'ァ',
				'ィ',
				'ゥ',
				'ェ',
				'ォ',
				'ャ',
				'ュ',
				'ョ',
				'ッ',
				'ー',
				'ア',
				'イ',
				'ウ',
				'エ',
				'オ',
				'カ',
				'キ',
				'ク',
				'ケ',
				'コ',
				'サ',
				'シ',
				'ス',
				'セ',
				'ソ',
				'タ',
				'チ',
				'ツ',
				'テ',
				'ト',
				'ナ',
				'ニ',
				'ヌ',
				'ネ',
				'ノ',
				'ハ',
				'ヒ',
				'フ',
				'ヘ',
				'ホ',
				'マ',
				'ミ',
				'ム',
				'メ',
				'モ',
				'ヤ',
				'ユ',
				'ヨ',
				'ラ',
				'リ',
				'ル',
				'レ',
				'ロ',
				'ワ',
				'ン',
				'ガ',
				'ギ',
				'グ',
				'ゲ',
				'ゴ',
				'ザ',
				'ジ',
				'ズ',
				'ゼ',
				'ゾ',
				'ダ',
				'ヂ',
				'ヅ',
				'デ',
				'ド',
				'バ',
				'ビ',
				'ブ',
				'ベ',
				'ボ',
				'パ',
				'ピ',
				'プ',
				'ペ',
				'ポ',
				'ヰ',
				'ヱ',
				'!',
				'"',
				'#',
				'$',
				'%',
				'&',
				'\'',
				'(',
				')',
				'*',
				',',
				'-',
				'.',
				'/',
				'0',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				':',
				';',
				'<',
				'=',
				'>',
				'?',
				'@',
				'~'
			};
			for (int i = 0; i < array.Length; i++)
			{
				instr = instr.Replace(array[i], array2[i]);
			}
			return instr;
		}
		public static int CmpPosV(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			if (point.Y + iCtrl1.Height - 1 < point2.Y)
			{
				return -1;
			}
			if (point.Y > point2.Y + iCtrl2.Height - 1)
			{
				return 1;
			}
			return 0;
		}
		public static int CmpPosH(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			if (point.X + iCtrl1.Width - 1 < point2.X)
			{
				return -1;
			}
			if (point.X > point2.X + iCtrl2.Width - 1)
			{
				return 1;
			}
			return 0;
		}
		public static int GetPosDefV(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			int num = (point.Y + (point.Y + iCtrl1.Height - 1)) / 2;
			int num2 = (point2.Y + (point2.Y + iCtrl2.Height - 1)) / 2;
			return Math.Abs(num - num2);
		}
		public static int GetPosDefH(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			int num = (point.X + (point.X + iCtrl1.Width - 1)) / 2;
			int num2 = (point2.X + (point2.X + iCtrl2.Width - 1)) / 2;
			return Math.Abs(num - num2);
		}
		public static int CmpStartV(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			if (point.Y == point2.Y)
			{
				return point.X - point2.X;
			}
			return point.Y - point2.Y;
		}
		public static int CmpStartH(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			if (point.X == point2.X)
			{
				return point.Y - point2.Y;
			}
			return point.X - point2.X;
		}
		public static int CmpUpper(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			return point.Y - point2.Y;
		}
		public static int CmpLower(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X + iCtrl1.Width - 1, iCtrl1.Location.Y + iCtrl1.Height - 1));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X + iCtrl2.Width - 1, iCtrl2.Location.Y + iCtrl2.Height - 1));
			return point.Y - point2.Y;
		}
		public static int CmpLeft(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X, iCtrl1.Location.Y));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X, iCtrl2.Location.Y));
			return point.X - point2.X;
		}
		public static int CmpRight(Control iCtrl1, Control iCtrl2)
		{
			Point point = iCtrl1.Parent.PointToScreen(new Point(iCtrl1.Location.X + iCtrl1.Width - 1, iCtrl1.Location.Y + iCtrl1.Height - 1));
			Point point2 = iCtrl2.Parent.PointToScreen(new Point(iCtrl2.Location.X + iCtrl2.Width - 1, iCtrl2.Location.Y + iCtrl2.Height - 1));
			return point.X - point2.X;
		}
		public static void GetJustUpperCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetJustUpperCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i]);
				if (TLib.CmpPosH(iParent.Controls[i], iCurCtrl) == 0 && TLib.CmpUpper(iParent.Controls[i], iCurCtrl) < 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpLower(iParent.Controls[i], iNextCtrl) > 0 || (TLib.CmpLower(iParent.Controls[i], iNextCtrl) == 0 && TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl))))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetJustLowerCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetJustLowerCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i]);
				if (TLib.CmpPosH(iParent.Controls[i], iCurCtrl) == 0 && TLib.CmpLower(iParent.Controls[i], iCurCtrl) > 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpUpper(iParent.Controls[i], iNextCtrl) < 0 || (TLib.CmpUpper(iParent.Controls[i], iNextCtrl) == 0 && TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl))))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetJustLeftCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetJustLeftCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i]);
				if (!(iParent.Controls[i] is UserControl) && !(iParent.Controls[i] is TDateEdit) && TLib.CmpPosV(iParent.Controls[i], iCurCtrl) == 0 && TLib.CmpLeft(iParent.Controls[i], iCurCtrl) < 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpRight(iParent.Controls[i], iNextCtrl) > 0 || (TLib.CmpRight(iParent.Controls[i], iNextCtrl) == 0 && TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl))))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetJustRightCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetJustRightCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i]);
				if (!(iParent.Controls[i] is UserControl) && !(iParent.Controls[i] is TDateEdit) && TLib.CmpPosV(iParent.Controls[i], iCurCtrl) == 0 && TLib.CmpRight(iParent.Controls[i], iCurCtrl) > 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpLeft(iParent.Controls[i], iNextCtrl) < 0 || (TLib.CmpLeft(iParent.Controls[i], iNextCtrl) == 0 && TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl))))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetUpperCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent, emAllowStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			TLib.GetJustUpperCtrl(ref iNextCtrl, iCurCtrl, iParent);
			if (iNextCtrl != null)
			{
				return;
			}
			switch (iStyle)
			{
			case emAllowStyle.ByAxis:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetUpperCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i], iStyle);
					if (TLib.CmpPosV(iParent.Controls[i], iCurCtrl) < 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl) || (TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) == TLib.GetPosDefH(iNextCtrl, iCurCtrl) && TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[i];
					}
				}
				return;
			case emAllowStyle.ByDist:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetUpperCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[j], iStyle);
					if (TLib.CmpPosV(iParent.Controls[j], iCurCtrl) < 0 && TLib.IsFocusEnable(iParent.Controls[j]) && (iNextCtrl == null || TLib.GetPosDefV(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl) || (TLib.GetPosDefV(iParent.Controls[j], iCurCtrl) == TLib.GetPosDefV(iNextCtrl, iCurCtrl) && TLib.GetPosDefH(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[j];
					}
				}
				return;
			default:
				return;
			}
		}
		public static void GetLowerCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent, emAllowStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			TLib.GetJustLowerCtrl(ref iNextCtrl, iCurCtrl, iParent);
			if (iNextCtrl != null)
			{
				return;
			}
			switch (iStyle)
			{
			case emAllowStyle.ByAxis:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetLowerCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i], iStyle);
					if (TLib.CmpPosV(iParent.Controls[i], iCurCtrl) > 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl) || (TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) == TLib.GetPosDefH(iNextCtrl, iCurCtrl) && TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[i];
					}
				}
				return;
			case emAllowStyle.ByDist:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetLowerCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[j], iStyle);
					if (TLib.CmpPosV(iParent.Controls[j], iCurCtrl) > 0 && TLib.IsFocusEnable(iParent.Controls[j]) && (iNextCtrl == null || TLib.GetPosDefV(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl) || (TLib.GetPosDefV(iParent.Controls[j], iCurCtrl) == TLib.GetPosDefV(iNextCtrl, iCurCtrl) && TLib.GetPosDefH(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[j];
					}
				}
				return;
			default:
				return;
			}
		}
		public static void GetLeftCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent, emAllowStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			TLib.GetJustLeftCtrl(ref iNextCtrl, iCurCtrl, iParent);
			if (iNextCtrl != null)
			{
				return;
			}
			switch (iStyle)
			{
			case emAllowStyle.ByAxis:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetLeftCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i], iStyle);
					if (TLib.CmpPosH(iParent.Controls[i], iCurCtrl) < 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl) || (TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) == TLib.GetPosDefV(iNextCtrl, iCurCtrl) && TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[i];
					}
				}
				return;
			case emAllowStyle.ByDist:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetLeftCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[j], iStyle);
					if (TLib.CmpPosH(iParent.Controls[j], iCurCtrl) < 0 && TLib.IsFocusEnable(iParent.Controls[j]) && (iNextCtrl == null || TLib.GetPosDefH(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl) || (TLib.GetPosDefH(iParent.Controls[j], iCurCtrl) == TLib.GetPosDefH(iNextCtrl, iCurCtrl) && TLib.GetPosDefV(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[j];
					}
				}
				return;
			default:
				return;
			}
		}
		public static void GetRightCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent, emAllowStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			TLib.GetJustRightCtrl(ref iNextCtrl, iCurCtrl, iParent);
			if (iNextCtrl != null)
			{
				return;
			}
			switch (iStyle)
			{
			case emAllowStyle.ByAxis:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetRightCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i], iStyle);
					if (TLib.CmpPosH(iParent.Controls[i], iCurCtrl) > 0 && TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl) || (TLib.GetPosDefV(iParent.Controls[i], iCurCtrl) == TLib.GetPosDefV(iNextCtrl, iCurCtrl) && TLib.GetPosDefH(iParent.Controls[i], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[i];
					}
				}
				return;
			case emAllowStyle.ByDist:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetRightCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[j], iStyle);
					if (TLib.CmpPosH(iParent.Controls[j], iCurCtrl) > 0 && TLib.IsFocusEnable(iParent.Controls[j]) && (iNextCtrl == null || TLib.GetPosDefH(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefH(iNextCtrl, iCurCtrl) || (TLib.GetPosDefH(iParent.Controls[j], iCurCtrl) == TLib.GetPosDefH(iNextCtrl, iCurCtrl) && TLib.GetPosDefV(iParent.Controls[j], iCurCtrl) < TLib.GetPosDefV(iNextCtrl, iCurCtrl))))
					{
						iNextCtrl = iParent.Controls[j];
					}
				}
				return;
			default:
				return;
			}
		}
		public static void GetNextCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent, emFocusStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			if (iParent is UltraTabPageControl)
			{
				UltraTabControl ultraTabControl = iParent.Parent as UltraTabControl;
				if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null && ultraTabControl.ActiveTab.TabPage != iParent)
				{
					return;
				}
			}
			switch (iStyle)
			{
			case emFocusStyle.ByPosX:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetNextCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[i]) && TLib.CmpStartH(iParent.Controls[i], iCurCtrl) > 0 && (iNextCtrl == null || TLib.CmpStartH(iParent.Controls[i], iNextCtrl) < 0))
					{
						iNextCtrl = iParent.Controls[i];
					}
				}
				return;
			case emFocusStyle.ByPosY:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetNextCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[j], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[j]) && TLib.CmpStartV(iParent.Controls[j], iCurCtrl) > 0 && (iNextCtrl == null || TLib.CmpStartV(iParent.Controls[j], iNextCtrl) < 0))
					{
						iNextCtrl = iParent.Controls[j];
					}
				}
				return;
			case emFocusStyle.ByTab:
			{
				Control control;
				while (true)
				{
					if (iCurCtrl is UltraTabControl)
					{
						UltraTabControl ultraTabControl2 = iCurCtrl as UltraTabControl;
						if (ultraTabControl2.Tabs.Count > 0 && ultraTabControl2.ActiveTab != null)
						{
							ArrayList arrayList = new ArrayList();
							TLib.GetTabOrderList(ultraTabControl2.ActiveTab.TabPage, ref arrayList);
							if (arrayList.Count > 0)
							{
								control = (Control)arrayList[0];
							}
							else
							{
								control = iParent.GetNextControl(iCurCtrl, true);
							}
						}
						else
						{
							control = iParent.GetNextControl(iCurCtrl, true);
						}
					}
					else
					{
						control = iParent.GetNextControl(iCurCtrl, true);
					}
					if (control == null)
					{
						break;
					}
					if (TLib.IsFocusEnable(control))
					{
						goto IL_E3;
					}
					iCurCtrl = control;
				}
				return;
				IL_E3:
				iNextCtrl = control;
				return;
			}
			default:
				return;
			}
		}
		public static void GetPrevCtrl(ref Control iNextCtrl, Control iCurCtrl, Control iParent, emFocusStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			if (iParent is UltraTabPageControl)
			{
				UltraTabControl ultraTabControl = iParent.Parent as UltraTabControl;
				if (ultraTabControl.ActiveTab != null && ultraTabControl.ActiveTab.TabPage != iParent)
				{
					return;
				}
			}
			switch (iStyle)
			{
			case emFocusStyle.ByPosX:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetPrevCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[i], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[i]) && TLib.CmpStartH(iParent.Controls[i], iCurCtrl) < 0 && (iNextCtrl == null || TLib.CmpStartH(iParent.Controls[i], iNextCtrl) > 0))
					{
						iNextCtrl = iParent.Controls[i];
					}
				}
				return;
			case emFocusStyle.ByPosY:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetPrevCtrl(ref iNextCtrl, iCurCtrl, iParent.Controls[j], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[j]) && TLib.CmpStartV(iParent.Controls[j], iCurCtrl) < 0 && (iNextCtrl == null || TLib.CmpStartV(iParent.Controls[j], iNextCtrl) > 0))
					{
						iNextCtrl = iParent.Controls[j];
					}
				}
				return;
			case emFocusStyle.ByTab:
			{
				Control nextControl;
				while (true)
				{
					nextControl = iParent.GetNextControl(iCurCtrl, false);
					if (nextControl == null)
					{
						break;
					}
					if (iCurCtrl.Parent is TDateEdit && iCurCtrl.Parent.Equals(nextControl))
					{
						iCurCtrl = nextControl;
					}
					else
					{
						if (TLib.IsFocusEnable(nextControl))
						{
							goto IL_87;
						}
						iCurCtrl = nextControl;
					}
				}
				return;
				IL_87:
				iNextCtrl = nextControl;
				return;
			}
			default:
				return;
			}
		}
		public static void GetTabOrderList(Control iParent, ref ArrayList list)
		{
			TLib.GetTabOrderListSub(iParent, ref list);
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (!TLib.IsFocusEnable((Control)list[i]))
				{
					list.RemoveAt(i);
				}
			}
		}
		public static void GetTabOrderListSub(Control iParent, ref ArrayList list)
		{
			if (iParent == null)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			foreach (Control value in iParent.Controls)
			{
				arrayList.Add(value);
			}
			TLib.ordercmp comparer = new TLib.ordercmp();
			arrayList.Sort(comparer);
			foreach (Control control in arrayList)
			{
				if (!(control is MdiClient))
				{
					list.Add(control);
					TLib.GetTabOrderListSub(control, ref list);
				}
			}
		}
		public static void GetTopCtrl(ref Control iCtrl, Control iParent, emFocusStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			switch (iStyle)
			{
			case emFocusStyle.ByPosX:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetTopCtrl(ref iCtrl, iParent.Controls[i], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[i]) && (iCtrl == null || TLib.CmpStartH(iParent.Controls[i], iCtrl) < 0))
					{
						iCtrl = iParent.Controls[i];
					}
				}
				break;
			case emFocusStyle.ByPosY:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetTopCtrl(ref iCtrl, iParent.Controls[j], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[j]) && (iCtrl == null || TLib.CmpStartV(iParent.Controls[j], iCtrl) < 0))
					{
						iCtrl = iParent.Controls[j];
					}
				}
				return;
			case emFocusStyle.ByTab:
			{
				ArrayList arrayList = new ArrayList();
				TLib.GetTabOrderList(iParent, ref arrayList);
				if (arrayList.Count > 0)
				{
					iCtrl = (Control)arrayList[0];
					return;
				}
				break;
			}
			default:
				return;
			}
		}
		public static void GetBtmCtrl(ref Control iCtrl, Control iParent, emFocusStyle iStyle)
		{
			if (iParent is MdiClient)
			{
				return;
			}
			switch (iStyle)
			{
			case emFocusStyle.ByPosX:
				for (int i = 0; i < iParent.Controls.Count; i++)
				{
					TLib.GetBtmCtrl(ref iCtrl, iParent.Controls[i], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[i]) && (iCtrl == null || TLib.CmpStartH(iParent.Controls[i], iCtrl) > 0))
					{
						iCtrl = iParent.Controls[i];
					}
				}
				break;
			case emFocusStyle.ByPosY:
				for (int j = 0; j < iParent.Controls.Count; j++)
				{
					TLib.GetBtmCtrl(ref iCtrl, iParent.Controls[j], iStyle);
					if (TLib.IsFocusEnable(iParent.Controls[j]) && (iCtrl == null || TLib.CmpStartV(iParent.Controls[j], iCtrl) > 0))
					{
						iCtrl = iParent.Controls[j];
					}
				}
				return;
			case emFocusStyle.ByTab:
			{
				ArrayList arrayList = new ArrayList();
				TLib.GetTabOrderList(iParent, ref arrayList);
				if (arrayList.Count > 0)
				{
					iCtrl = (Control)arrayList[arrayList.Count - 1];
					return;
				}
				break;
			}
			default:
				return;
			}
		}
		public static void GetMostUpperCtrl(ref Control iNextCtrl, Control iParent)
		{
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetMostUpperCtrl(ref iNextCtrl, iParent.Controls[i]);
				if (TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpPosV(iParent.Controls[i], iNextCtrl) < 0 || (TLib.CmpPosV(iParent.Controls[i], iNextCtrl) == 0 && TLib.CmpPosH(iParent.Controls[i], iNextCtrl) < 0)))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetMostLowerCtrl(ref Control iNextCtrl, Control iParent)
		{
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetMostLowerCtrl(ref iNextCtrl, iParent.Controls[i]);
				if (TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpPosV(iParent.Controls[i], iNextCtrl) > 0 || (TLib.CmpPosV(iParent.Controls[i], iNextCtrl) == 0 && TLib.CmpPosH(iParent.Controls[i], iNextCtrl) > 0)))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetMostLeftCtrl(ref Control iNextCtrl, Control iParent)
		{
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetMostLeftCtrl(ref iNextCtrl, iParent.Controls[i]);
				if (TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpPosH(iParent.Controls[i], iNextCtrl) < 0 || (TLib.CmpPosH(iParent.Controls[i], iNextCtrl) == 0 && TLib.CmpPosV(iParent.Controls[i], iNextCtrl) < 0)))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static void GetMostRightCtrl(ref Control iNextCtrl, Control iParent)
		{
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				TLib.GetMostRightCtrl(ref iNextCtrl, iParent.Controls[i]);
				if (TLib.IsFocusEnable(iParent.Controls[i]) && (iNextCtrl == null || TLib.CmpPosH(iParent.Controls[i], iNextCtrl) > 0 || (TLib.CmpPosH(iParent.Controls[i], iNextCtrl) == 0 && TLib.CmpPosV(iParent.Controls[i], iNextCtrl) > 0)))
				{
					iNextCtrl = iParent.Controls[i];
				}
			}
		}
		public static bool IsFocusEnable(Control iCtrl)
		{
			if (iCtrl is Form)
			{
				return false;
			}
			if (iCtrl is MdiClient)
			{
				return false;
			}
			if (iCtrl is TDateEdit)
			{
				TDateEdit tDateEdit = iCtrl as TDateEdit;
				if (!tDateEdit.EnableEditors.deeDay && !tDateEdit.EnableEditors.deeJpn && !tDateEdit.EnableEditors.deeMonth && !tDateEdit.EnableEditors.deeYear)
				{
					return false;
				}
			}
			return !(iCtrl is TGraphicControl) && !(iCtrl is UltraExplorerBar) && !(iCtrl is UnpinnedTabArea) && !(iCtrl is WindowDockingArea) && !(iCtrl is DockableWindow) && iCtrl.CanFocus && !TLib.IsReadOnly(iCtrl) && iCtrl.TabStop;
		}
		public static Control GetBaseControl(Control iCtrl)
		{
			if (iCtrl == null)
			{
				return null;
			}
			if (iCtrl.Parent is TDateEdit)
			{
				return iCtrl.Parent;
			}
			if (iCtrl is EmbeddableTextBoxWithUIPermissions)
			{
				return iCtrl.Parent;
			}
			return iCtrl;
		}
		public static bool IsMouseFocusControl(Control iCtrl)
		{
			return !(iCtrl is Form) && !(iCtrl is GroupBox) && !(iCtrl is Panel) && !(iCtrl is UserControl) && !(iCtrl is TGraphicControl) && !(iCtrl is Label);
		}
		public static bool IsReadOnly(Control iCtrl)
		{
			bool result;
			try
			{
				Type type = iCtrl.GetType();
				if (type.GetProperty("ReadOnly", typeof(bool)) == null)
				{
					result = false;
				}
				else
				{
					result = (bool)type.InvokeMember("ReadOnly", BindingFlags.GetProperty, null, iCtrl, null);
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static TLib.TCheckDateStat CheckDate(int yy, int mm, int dd)
		{
			if (yy != 0 && !TLib.CheckYear(yy))
			{
				return TLib.TCheckDateStat.cdsIllegalYear;
			}
			if (mm != 0 && !TLib.CheckMonth(mm))
			{
				return TLib.TCheckDateStat.cdsIllegalMonth;
			}
			if (dd != 0)
			{
				if (yy != 0 && mm != 0)
				{
					if (dd < 1 || TLib.GetMonthDay(yy, mm) < dd)
					{
						return TLib.TCheckDateStat.cdsIllegalDay;
					}
				}
				else
				{
					if (dd < 1 || 31 < dd)
					{
						return TLib.TCheckDateStat.cdsIllegalDay;
					}
				}
			}
			return TLib.TCheckDateStat.cdsOk;
		}
		public static TLib.TCheckDateStat CheckLongDate(int value)
		{
			int yy;
			int mm;
			int dd;
			TLib.DecodeLongDate(value, out yy, out mm, out dd);
			return TLib.CheckDate(yy, mm, dd);
		}
		public static bool CheckYear(int yy)
		{
			return 1 <= yy && yy <= 9999;
		}
		public static bool CheckMonth(int mm)
		{
			return 1 <= mm && mm <= 12;
		}
		public static int GetMonthDay(int yy, int mm)
		{
			if (DateTime.IsLeapYear(yy))
			{
				return TLib.kLeepYear[mm - 1];
			}
			return TLib.kNormalYear[mm - 1];
		}
		public static void DecodeLongDate(int value, out int yy, out int mm, out int dd)
		{
			yy = value / 10000;
			mm = (value - yy * 10000) / 100;
			dd = value - yy * 10000 - mm * 100;
		}
	}
}
