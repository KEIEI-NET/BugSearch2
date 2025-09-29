using System;
using System.Runtime.InteropServices;
using System.Text;
namespace Broadleaf.Library.Windows.Forms
{
	internal static class SafeNativeMethods
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct INPUT
		{
			[FieldOffset(0)]
			public int type;
			[FieldOffset(4)]
			public SafeNativeMethods.MOUSEINPUT mi;
			[FieldOffset(4)]
			public SafeNativeMethods.KEYBDINPUT ki;
			[FieldOffset(4)]
			public SafeNativeMethods.HARDWAREINPUT hi;
		}
		public struct MOUSEINPUT
		{
			public int dx;
			public int dy;
			public uint mouseData;
			public uint dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}
		public struct KEYBDINPUT
		{
			public ushort wVk;
			public ushort wScan;
			public uint dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}
		public struct HARDWAREINPUT
		{
			public uint uMsg;
			public ushort wParamL;
			public ushort wParamH;
		}
		public const int GCS_RESULTREADSTR = 512;
		public const int NI_COMPOSITIONSTR = 21;
		public const int CPS_COMPLETE = 1;
		public const int CPS_CONVERT = 2;
		public const int CPS_REVERT = 3;
		public const int CPS_CANCEL = 4;
		public const int INPUT_MOUSE = 0;
		public const int INPUT_KEYBOARD = 1;
		public const int INPUT_HARDWARE = 2;
		public const int KEYEVENTF_KEYUP = 2;
		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr ImmGetContext(IntPtr hWnd);
		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);
		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmSetOpenStatus(IntPtr hIMC, bool fOpen);
		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmGetOpenStatus(IntPtr hIMC);
		[DllImport("imm32.dll")]
		public static extern int ImmNotifyIME(IntPtr hIMC, uint dwAction, uint dwIndex, uint dwValue);
		[DllImport("imm32.dll", CharSet = CharSet.Ansi)]
		public static extern int ImmGetCompositionString(IntPtr hIMC, int dwIndex, StringBuilder lpBuf, int dwBufLen);
		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern int ImmGetVirtualKey(IntPtr hWnd);
		[DllImport("user32.dll")]
		public static extern short GetAsyncKeyState(int vkey);
		[DllImport("user32.dll")]
		public static extern short GetKeyState(int vkey);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern uint SendInput(uint nInputs, ref SafeNativeMethods.INPUT pInputs, int cbSize);
		[DllImport("user32.dll")]
		public static extern IntPtr GetMessageExtraInfo();
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);
	}
}
