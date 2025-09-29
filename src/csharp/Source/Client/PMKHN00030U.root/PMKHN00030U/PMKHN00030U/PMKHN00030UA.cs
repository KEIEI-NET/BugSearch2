using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// アプリケーション最前面化クラス
	/// </summary>
	/// <remarks>
	/// Note       : 指定されたアプリケーションを最前面化します。<br />
	/// Programmer : 30182 R.Tachiya<br />
	/// Date       : 2012.06.18<br />
	/// Update Note: <br />
	///            : <br />
	/// </remarks>
	public class ApplicationWakeuper
	{
		#region // -- Const Members --

		/// <summary>
		/// メインプログラムID
		/// </summary>
		public const string PG_ID = "PMKHN00030U";

		/// <summary>
		/// 最前面化対象プロセスID
		/// </summary>
		public const string WAKEUPID_ARGNAME = "TargetProcessId";

		#endregion

		#region // -- Public Methods --

		/// <summary>
		/// メインエントリ
		/// </summary>
		/// <param name="args">起動引数</param>
		/// <remarks>
		/// Note       : アプリケーションウェイクアッパーのメインエントリです。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		public static void Main(string[] args)
		{
			try
			{
				//最前面化対象のプロセスID
				int targetId = 0;

				//引数から対象のプロセスIDを取得
				foreach (string arg in args)
				{
					if (arg.Contains(ApplicationWakeuper.WAKEUPID_ARGNAME))
					{
						string strId = arg.Replace(ApplicationWakeuper.WAKEUPID_ARGNAME, "");
						targetId = Convert.ToInt32(strId);
					}
				}

				//IDからプロセスを取得
				Process process = Process.GetProcessById(targetId);

				if ((process != null) && (process.MainWindowHandle != IntPtr.Zero))
				{
					//対象のアプリケーションを最前面に表示
					ApplicationWakeuper.WakeupWindow(process.MainWindowHandle);
				}
			}
			catch (Exception e)
			{
				ClientLogTextOut clientLogTextOut = new ClientLogTextOut();
				clientLogTextOut.Output(ApplicationWakeuper.PG_ID, e.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR, e);
			}
			finally
			{
			}

			return;
		}

		#endregion

		#region // -- Private Methods --

		/// <summary>
		/// ウインドウ表示・最前面化処理
		/// </summary>
		/// <param name="hWnd">対象のウインドウハンドル</param>
		/// <remarks>
		/// Note       : 引数で指定されたウインドウを表示し、最前面に移動します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		private static void WakeupWindow(IntPtr targethWnd)
		{
			//対象のプロセスIDを取得
			int targetId;
			ApplicationWakeuper.GetWindowThreadProcessId(targethWnd, out targetId);

			//現在ユーザーが作業しているスレッドIDを取得
			IntPtr wakeuphWnd = ApplicationWakeuper.GetForegroundWindow();
			int wakeupId;
			ApplicationWakeuper.GetWindowThreadProcessId(wakeuphWnd, out wakeupId);

			//現在の入力状態をターゲットプロセスにアタッチ
			ApplicationWakeuper.AttachThreadInput(wakeupId, targetId, true);

			//[FOREGROUND LOCK TIMEOUT]の設定を取得
			//設定を 0ms に変更
			IntPtr oldLockTime = IntPtr.Zero;
			ApplicationWakeuper.GetForeGroundLockTimeout(out oldLockTime);
			ApplicationWakeuper.SetForeGroundLockTimeout(IntPtr.Zero);//0ms
			try
			{
				#region //ターゲットを最前面に表示

				// SetForegroundWindow()が成功するまで処理を行う	//
				//  →1回のみに変更									//

				int outTime = 5 * 1000;//ms
				int sleepTime = 100;//ms
				int maxLoopCount = outTime / sleepTime;//回

				bool status = false;
				//for (int count = 0; count < maxLoopCount; count++)// ComentOut
				{
					//ForegroundWindowの操作を解除
					ApplicationWakeuper.LockSetForegroundWindow(ApplicationWakeuper.LSFW_UNLOCK);

					//ターゲットが最小化されていれば元に戻す
					if (ApplicationWakeuper.IsIconic(targethWnd))
					{
						ApplicationWakeuper.ShowWindowAsync(targethWnd, ApplicationWakeuper.SW_RESTORE);
					}
					//ターゲットを表示
					ApplicationWakeuper.ShowWindowAsync(targethWnd, ApplicationWakeuper.SW_SHOW);

					//ForegroundWindowが可能となるように設定
					ApplicationWakeuper.AllowSetForegroundWindow(targetId);
					//ApplicationWakeuper.AllowSetForegroundWindow(ApplicationControlObject.ASFW_ANY);

					//ウインドウを前面に表示
					status = ApplicationWakeuper.SetForegroundWindow(targethWnd);

					//if (status) break;// ComentOut

					//Thread.Sleep(sleepTime);// ComentOut
				}

				#endregion
			}
			finally
			{
				//[FOREGROUND LOCK TIMEOUT]の設定を元に戻す
				ApplicationWakeuper.SetForeGroundLockTimeout(oldLockTime);

				//入力状態を元のスレッドIDにデタッチ
				ApplicationWakeuper.AttachThreadInput(targetId, wakeupId, false);
			}
		}

		/// <summary>
		/// ForGroundLockタイムアウト取得処理
		/// </summary>
		/// <param name="getTimeout">取得タイムアウト時間</param>
		/// <remarks>
		/// Note       : ForGroundLockタイムアウト時間を取得します。失敗する可能性があります。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		private static bool GetForeGroundLockTimeout(out IntPtr getTimeout)
		{
			getTimeout = IntPtr.Zero;

			// SystemParametersInfo()が成功するまで処理を行う	//
			//  →1回のみに変更									//

			int outTime = 5 * 1000;//ms
			int sleepTime = 5;//ms
			int maxLoopCount = outTime / sleepTime;//回
			int errorCode = 0;

			bool status = false;
			//for (int count = 0; count < maxLoopCount; count++)// ComentOut
			{
				//ForeGroundLockTimeout値を取得
				status = ApplicationWakeuper.SystemParametersInfo(ApplicationWakeuper.SPI_GETFOREGROUNDLOCKTIMEOUT, 0, out getTimeout, 0);

				//エラーコード取得
				if (!status) errorCode = Marshal.GetLastWin32Error();

				//成功 0以外(1) true
				//失敗 0 false
				//if (status) break;// ComentOut

				//Thread.Sleep(sleepTime);// ComentOut
			}

			//エラーコード出力
			if (!status)
			{
				Console.WriteLine("GetForeGroundLockTimeout ErrorCode {0}", errorCode);
			}

			return status;
		}

		/// <summary>
		/// ForGroundLockタイムアウト設定処理
		/// </summary>
		/// <param name="setTimeout">設定タイムアウト時間</param>
		/// <remarks>
		/// Note       : ForGroundLockタイムアウト時間を設定します。失敗する可能性があります。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.06.18<br />
		/// </remarks>
		private static bool SetForeGroundLockTimeout(IntPtr setTimeout)
		{
			// SystemParametersInfo()が成功するまで処理を行う	//
			//  →1回のみに変更									//

			int outTime = 5 * 1000;//ms
			int sleepTime = 5;//ms
			int maxLoopCount = outTime / sleepTime;//回
			int errorCode = 0;

			bool status = false;
			//for (int count = 0; count < maxLoopCount; count++)// ComentOut
			{
				//ForeGroundLockTimeout値を設定
				status = ApplicationWakeuper.SystemParametersInfo(ApplicationWakeuper.SPI_SETFOREGROUNDLOCKTIMEOUT, 0, setTimeout, 0);

				//エラーコード取得
				if (!status) errorCode = Marshal.GetLastWin32Error();

				//成功 0以外(1) true
				//失敗 0 false
				//if (status) break;// ComentOut

				//Thread.Sleep(sleepTime);// ComentOut
			}

			//エラーコード出力
			if (!status)
			{
				Console.WriteLine("SetForeGroundLockTimeout ErrorCode {0}", errorCode);
			}

			return status;
		}

		#endregion

		#region // -- 外部参照 --

		//Win32 API 参照
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
		[DllImport("user32.dll")]
		private static extern bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, out IntPtr pvParam, uint fWinIni);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);
		[DllImport("user32.dll")]
		private static extern bool LockSetForegroundWindow(uint uLockCode);
		[DllImport("user32.dll")]
		private static extern bool IsIconic(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern bool AllowSetForegroundWindow(int dwProcessId);
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		//ShowWindowAsync()のパラメータ定義値
		private const int SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
		private const int SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
		private const int LSFW_LOCK = 1;
		private const int LSFW_UNLOCK = 2;
		private const int SW_HIDE = 0;
		private const int SW_SHOW = 5;
		private const int SW_RESTORE = 9;
		private const int ASFW_ANY = -1;

		#endregion
	}

	/// <summary>
	/// ウインドウハンドル取得クラス
	/// </summary>
	/// <remarks>
	/// Note       : 指定したウインドウハンドルを取得するクラスです。※現在、使用されていません<br />
	/// Programmer : 30182 R.Tachiya<br />
	/// Date       : 2012.05.14<br />
	/// </remarks>
	internal class WindowHandle
	{
		#region // -- Private Members --

		/// <summary>
		/// 取得ウインドウハンドル
		/// </summary>
		private static IntPtr _hWnd;

		/// <summary>
		/// 検索プロセスID
		/// </summary>
		private static int _id;

		/// <summary>
		/// 検索ウインドウキャプション
		/// </summary>
		private static string _caption;

		#endregion

		#region // -- Public Methods --

		/// <summary>
		/// ウインドウハンドル取得処理
		/// </summary>
		/// <param name="targetProcessID">対象プロセスID</param>
		/// <param name="targetCaption">対象ウインドウキャプション</param>
		/// <returns>ウインドウハンドル</returns>
		/// <remarks>
		/// Note       : 引数のプロセスIDに対するウインドウハンドルを取得します。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		public static IntPtr GetWindowHandle(int targetProcessID, string targetCaption)
		{
			//メンバ設定
			WindowHandle._hWnd = IntPtr.Zero;
			WindowHandle._id = targetProcessID;
			WindowHandle._caption = targetCaption;

			//ウインドウ列挙
			WindowHandle.EnumWindows(new EnumerateWindowsCallback(WindowHandle.EnumWindowsProc), 0);

			//メンバで選択されているハンドルを返却
			return WindowHandle._hWnd;
		}

		#endregion

		#region // -- Private Methods --

		/// <summary>
		/// ウインドウ列挙コールバック処理
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		/// <remarks>
		/// Note       : ウインドウ列挙処理のコールバックメソッドです。<br />
		/// Programmer : 30182 R.Tachiya<br />
		/// Date       : 2012.05.14<br />
		/// </remarks>
		private static bool EnumWindowsProc(IntPtr hWnd, int lParam)
		{
			//ウインドウハンドルからプロセスIDを取得
			int getProcessId = 0;
			WindowHandle.GetWindowThreadProcessId(hWnd, out getProcessId);

			//取得したプロセスIDとメンバ（検索対象）のIDと比較
			if (getProcessId == WindowHandle._id)
			{
				// 同じIDで複数のウィンドウが見つかる場合がある //
				// ウインドウ列挙の際、クリックなどでウインドウがアクティブになると	//
				// 正しくウインドウ列挙がされない場合がある							//

				//取得精度を上げるためにキャプションを検証
				StringBuilder sb = new StringBuilder(WindowHandle._caption.Length + 100);
				WindowHandle.GetWindowText(hWnd, sb, sb.Capacity);
				if (sb.ToString().Contains(WindowHandle._caption))
				{
					//ハンドル取得
					WindowHandle._hWnd = hWnd;

					//ウインドウ列挙を終了するには0(false)を返す必要がある
					return false;
				}
			}

			//ウインドウ列挙を継続するには0以外(true)を返す必要がある
			return true;
		}

		/// <summary>
		/// ウインドウ列挙コールバックデリゲート
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		private delegate bool EnumerateWindowsCallback(IntPtr hWnd, int lParam);

		#endregion

		#region // -- 外部参照 --

		//Win32 API 参照
		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumerateWindowsCallback lpEnumFunc, int lParam);
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
		[DllImport("user32.dll")]
		private extern static IntPtr GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		#endregion
	}

}
