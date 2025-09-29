using Broadleaf.Library.Diagnostics;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	public class TMsgDisp
	{
		public static string OPE_START = "START";
		public static string OPE_LOGIN = "LOGIN";
		public static string OPE_CONNECT = "CONNECT";
		public static string OPE_DISCONNECT = "DISCONCT";
		public static string OPE_INIT = "INIT";
		public static string OPE_OPEN = "OPEN";
		public static string OPE_GET = "GET";
		public static string OPE_READ = "GET";
		public static string OPE_INSERT = "INS";
		public static string OPE_UPDATE = "UPDT";
		public static string OPE_HIDE = "HIDE";
		public static string OPE_DELETE = "DEL";
		public static string OPE_LOCK = "LOCK";
		public static string OPE_UNLOCK = "UNLOCK";
		public static string OPE_CLOSE = "CLOSE";
		public static string OPE_PRINT = "PRINT";
		public static string OPE_COMMT = "COMM";
		public static string OPE_CALL = "CALL";
		public static string OPE_SEND = "SEND";
		public static string OPE_RECIEVE = "RECV";
		public static string OPE_TIMEOUT = "TIMEOUT";
		public static string OPE_EXIT = "EXIT";
		public static string OPE_LOAD = "LOAD";
		public static string OPE_UNLOAD = "UNLOAD";
		internal static string GetMainFormCaption()
		{
			Form form = Form.ActiveForm;
			if (form != null)
			{
				while (!form.IsMdiChild || form.ParentForm == null)
				{
					if (form.Owner == null)
					{
						return form.Text;
					}
					form = form.Owner;
				}
				return form.ParentForm.Text;
			}
			return "";
		}
		public static DialogResult Show(IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iPgNm, string iProcNm, string iOperation, string iMsg, int iSt, object iObj, Exception iException, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			string text = Process.GetCurrentProcess().MainWindowTitle;
			if (text == "")
			{
                if (System.Windows.Forms.Application.OpenForms.Count > 0 && !System.Windows.Forms.Application.OpenForms[0].InvokeRequired)
				{
                    text = System.Windows.Forms.Application.OpenForms[0].Text;
				}
				else
				{
					IntPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
					if (mainWindowHandle != IntPtr.Zero)
					{
						StringBuilder stringBuilder = new StringBuilder();
						if (SafeNativeMethods.GetWindowText(mainWindowHandle, stringBuilder, 4096) > 0 && stringBuilder.Length > 0)
						{
							text = stringBuilder.ToString();
						}
					}
				}
			}
			if (text == "")
			{
				text = "Application";
			}
			MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
			string text2 = iMsg;
			MessageBoxIcon icon;
			switch (iLevel)
			{
			case emErrorLevel.ERR_LEVEL_STOP:
			case emErrorLevel.ERR_LEVEL_STOPDISP:
				break;
			case emErrorLevel.ERR_LEVEL_EXCLAMATION:
				icon = MessageBoxIcon.Exclamation;
				text = "注意 - ＜" + text + "＞";
				goto IL_224;
			case emErrorLevel.ERR_LEVEL_INFO:
				icon = MessageBoxIcon.Asterisk;
				text = "情報 - ＜" + text + "＞";
				goto IL_224;
			case emErrorLevel.ERR_LEVEL_QUESTION:
				icon = MessageBoxIcon.Question;
				text = "確認 - ＜" + text + "＞";
				goto IL_224;
			case emErrorLevel.ERR_LEVEL_CONFIRM:
				icon = MessageBoxIcon.Question;
				text = "確認 - ＜" + text + "＞";
				text2 = "現在、編集中のデータが存在します\n\n" + iMsg + "終了してもよろしいですか？";
				messageBoxButtons = MessageBoxButtons.YesNo;
				goto IL_224;
			case emErrorLevel.ERR_LEVEL_SAVECONFIRM:
				icon = MessageBoxIcon.Question;
				text = "確認 - ＜" + text + "＞";
				text2 = "現在、編集中のデータが存在します\n\n" + iMsg + "登録してもよろしいですか？";
				messageBoxButtons = MessageBoxButtons.YesNoCancel;
				goto IL_224;
			default:
				if (iLevel != emErrorLevel.ERR_LEVEL_NODISP)
				{
					return DialogResult.OK;
				}
				break;
			}
            string[] array = System.Windows.Forms.Application.ExecutablePath.Split(new char[]
			{
				'\\'
			});
			icon = MessageBoxIcon.Hand;
			text = "エラー発生 - ＜" + text + "＞";
			text2 = string.Concat(new string[]
			{
				array[array.Length - 1],
				"(",
				iPgid,
				") にてエラーが発生しました\n\n",
				iMsg,
				" ST = ",
				iSt.ToString()
			});
			ClientLogTextOut clientLogTextOut = new ClientLogTextOut();
			if (iException != null)
			{
				clientLogTextOut.Output(iPgid, iMsg, iSt, iException);
			}
			else
			{
				clientLogTextOut.Output(iPgid, iMsg, iSt);
			}
			if (iLevel == emErrorLevel.ERR_LEVEL_NODISP)
			{
				return DialogResult.OK;
			}
			IL_224:
			if (messageBoxButtons == MessageBoxButtons.OK)
			{
				messageBoxButtons = iButton;
			}
			if (iWin == null)
			{
				iWin = Form.ActiveForm;
				if (iWin == null)
				{
					IntPtr mainWindowHandle2 = Process.GetCurrentProcess().MainWindowHandle;
					if (mainWindowHandle2 != IntPtr.Zero)
					{
						Control control = Control.FromHandle(mainWindowHandle2);
						if (control != null && !control.IsDisposed)
						{
							iWin = control;
						}
					}
					if (iWin == null)
					{
                        if (System.Windows.Forms.Application.OpenForms.Count > 0)
						{
                            iWin = System.Windows.Forms.Application.OpenForms[0];
						}
						if (iWin == null)
						{
                            System.Windows.Forms.Application.DoEvents();
							iWin = Form.ActiveForm;
						}
					}
				}
			}
			return MessageBox.Show(iWin, text2, text, messageBoxButtons, icon, iDefButton);
		}
		public static DialogResult Show(IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iPgNm, string iProcNm, string iOperation, string iMsg, int iSt, object iObj, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iWin, iLevel, iPgid, iPgNm, iProcNm, iOperation, iMsg, iSt, iObj, null, iButton, iDefButton);
		}
		public static DialogResult Show(emErrorLevel iLevel, string iPgid, string iPgNm, string iProcNm, string iOperation, string iMsg, int iSt, object iObj, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(null, iLevel, iPgid, iPgNm, iProcNm, iOperation, iMsg, iSt, iObj, null, iButton, iDefButton);
		}
		public static DialogResult Show(emErrorLevel iLevel, string iPgid, string iPgNm, string iProcNm, string iOperation, string iMsg, int iSt, object iObj, Exception iException, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(null, iLevel, iPgid, iPgNm, iProcNm, iOperation, iMsg, iSt, iObj, iException, iButton, iDefButton);
		}
		public static DialogResult Show(IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iWin, iLevel, iPgid, "", "", "", iMsg, iSt, null, null, iButton, iDefButton);
		}
		public static DialogResult Show(IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iMsg, int iSt, Exception iException, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iWin, iLevel, iPgid, "", "", "", iMsg, iSt, null, iException, iButton, iDefButton);
		}
		public static DialogResult Show(emErrorLevel iLevel, string iPgid, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(null, iLevel, iPgid, "", "", "", iMsg, iSt, null, null, iButton, iDefButton);
		}
		public static DialogResult Show(emErrorLevel iLevel, string iPgid, string iMsg, int iSt, Exception iException, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(null, iLevel, iPgid, "", "", "", iMsg, iSt, null, iException, iButton, iDefButton);
		}
		public static DialogResult Show(IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iMsg, int iSt, MessageBoxButtons iButton)
		{
			return TMsgDisp.Show(iWin, iLevel, iPgid, iMsg, iSt, iButton, MessageBoxDefaultButton.Button1);
		}
		public static DialogResult Show(emErrorLevel iLevel, string iPgid, string iMsg, int iSt, MessageBoxButtons iButton)
		{
			return TMsgDisp.Show(null, iLevel, iPgid, iMsg, iSt, iButton, MessageBoxDefaultButton.Button1);
		}
	}
}
