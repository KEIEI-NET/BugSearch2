using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TMemPos), "TMemPos.bmp")]
	public class TMemPos : TbsBaseComponent
	{
		public enum emSetType
		{
			None,
			Position,
			Rect,
			Both
		}
		public class FormInfoData
		{
			private string _formID = string.Empty;
			private int _top;
			private int _left;
			private int _height = 768;
			private int _width = 1024;
			private FormWindowState _windowState;
			public string FormID
			{
				get
				{
					return this._formID;
				}
				set
				{
					this._formID = value;
				}
			}
			public int Top
			{
				get
				{
					return this._top;
				}
				set
				{
					this._top = value;
				}
			}
			public int Left
			{
				get
				{
					return this._left;
				}
				set
				{
					this._left = value;
				}
			}
			public int Height
			{
				get
				{
					return this._height;
				}
				set
				{
					this._height = value;
				}
			}
			public int Width
			{
				get
				{
					return this._width;
				}
				set
				{
					this._width = value;
				}
			}
			public FormWindowState WindowState
			{
				get
				{
					return this._windowState;
				}
				set
				{
					this._windowState = value;
				}
			}
			public FormInfoData()
			{
			}
			public FormInfoData(string formID, Rectangle bounds, FormWindowState windowsState)
			{
				this._formID = formID;
				this._top = bounds.Top;
				this._left = bounds.Left;
				this._height = bounds.Height;
				this._width = bounds.Width;
				this._windowState = windowsState;
			}
			public FormInfoData(string formID, int top, int left, int height, int width, FormWindowState windowsState)
			{
				this._formID = formID;
				this._top = top;
				this._left = left;
				this._height = height;
				this._width = width;
				this._windowState = windowsState;
			}
		}
		private const string ctEXT_InfoFileExtension = ".pos";
		private static int instanceCount;
		private static bool readInfoData;
		private static object syncRoot;
		private static string infoDataFileName;
		private static Dictionary<string, TMemPos.FormInfoData> formInfoDic;
		private TMemPos.emSetType _setType = TMemPos.emSetType.Both;
		private Container components;
		public override ISynchronizeInvoke OwnerForm
		{
			get
			{
				return base.OwnerForm;
			}
			set
			{
				if (!base.DesignMode)
				{
					if (value == null || value is Form)
					{
						this.RemovedHockControl();
						base.OwnerForm = value;
						this.AddedHockControl();
						return;
					}
				}
				else
				{
					base.OwnerForm = value;
				}
			}
		}
		[Category("Behavior"), DefaultValue(TMemPos.emSetType.Both), Description("画面情報のセットタイプを取得、設定します。")]
		public TMemPos.emSetType SetType
		{
			get
			{
				return this._setType;
			}
			set
			{
				this._setType = value;
			}
		}
		static TMemPos()
		{
			TMemPos.instanceCount = 0;
			TMemPos.readInfoData = false;
			TMemPos.syncRoot = new object();
			TMemPos.formInfoDic = new Dictionary<string, TMemPos.FormInfoData>();
            TMemPos.infoDataFileName = ConstantManagement_ClientDirectory.UISettings_FormPos + "\\" + Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath) + ".pos";
		}
		public TMemPos(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			TMemPos.instanceCount++;
		}
		public TMemPos()
		{
			this.InitializeComponent();
			TMemPos.instanceCount++;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			TMemPos.instanceCount--;
			if (!base.DesignMode)
			{
				this.SaveFormInfoProc();
			}
			base.Dispose(disposing);
		}
		public static void SaveFormInfo(Form ownerForm)
		{
			if (ownerForm != null)
			{
				Rectangle bounds = ownerForm.Bounds;
				FormWindowState windowsState = ownerForm.WindowState;
				switch (ownerForm.WindowState)
				{
				case FormWindowState.Minimized:
					bounds = ownerForm.RestoreBounds;
					windowsState = FormWindowState.Normal;
					break;
				case FormWindowState.Maximized:
					bounds = ownerForm.RestoreBounds;
					break;
				}
				object obj;
				Monitor.Enter(obj = TMemPos.syncRoot);
				try
				{
					TMemPos.formInfoDic[ownerForm.GetType().Name] = new TMemPos.FormInfoData(ownerForm.GetType().Name, bounds, windowsState);
				}
				finally
				{
					Monitor.Exit(obj);
				}
			}
			if (TMemPos.instanceCount == 0)
			{
				List<TMemPos.FormInfoData> list = new List<TMemPos.FormInfoData>(TMemPos.formInfoDic.Values);
				UserSettingController.SerializeUserSetting(list.ToArray(), TMemPos.infoDataFileName);
			}
		}
		public static void SettingFormInfo(Form ownerForm, TMemPos.emSetType setType)
		{
			if (!TMemPos.readInfoData)
			{
				if (UserSettingController.ExistUserSetting(TMemPos.infoDataFileName))
				{
					TMemPos.FormInfoData[] array = null;
					try
					{
						array = UserSettingController.DeserializeUserSetting<TMemPos.FormInfoData[]>(TMemPos.infoDataFileName);
					}
					catch (Exception)
					{
						return;
					}
					if (array != null)
					{
						object obj;
						Monitor.Enter(obj = TMemPos.syncRoot);
						try
						{
							for (int i = 0; i < array.Length; i++)
							{
								TMemPos.formInfoDic.Add(array[i].FormID, array[i]);
							}
						}
						finally
						{
							Monitor.Exit(obj);
						}
					}
				}
				TMemPos.readInfoData = true;
			}
			if (ownerForm != null)
			{
				TMemPos.FormInfoData formInfoData = null;
				object obj2;
				Monitor.Enter(obj2 = TMemPos.syncRoot);
				try
				{
					if (TMemPos.formInfoDic.ContainsKey(ownerForm.GetType().Name))
					{
						formInfoData = TMemPos.formInfoDic[ownerForm.GetType().Name];
					}
				}
				finally
				{
					Monitor.Exit(obj2);
				}
				if (formInfoData != null)
				{
					switch (setType)
					{
					case TMemPos.emSetType.None:
						break;
					case TMemPos.emSetType.Position:
						ownerForm.Top = formInfoData.Top;
						ownerForm.Left = formInfoData.Left;
						return;
					case TMemPos.emSetType.Rect:
						ownerForm.Height = formInfoData.Height;
						ownerForm.Width = formInfoData.Width;
						ownerForm.WindowState = formInfoData.WindowState;
						return;
					case TMemPos.emSetType.Both:
						ownerForm.Top = formInfoData.Top;
						ownerForm.Left = formInfoData.Left;
						ownerForm.Height = formInfoData.Height;
						ownerForm.Width = formInfoData.Width;
						ownerForm.WindowState = formInfoData.WindowState;
						break;
					default:
						return;
					}
				}
			}
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		private void SaveFormInfoProc()
		{
			if (base.OwnerForm != null)
			{
				Form form = base.OwnerForm as Form;
				if (form != null)
				{
					Rectangle bounds = form.Bounds;
					FormWindowState windowsState = form.WindowState;
					switch (form.WindowState)
					{
					case FormWindowState.Minimized:
						bounds = form.RestoreBounds;
						windowsState = FormWindowState.Normal;
						break;
					case FormWindowState.Maximized:
						bounds = form.RestoreBounds;
						break;
					}
					object obj;
					Monitor.Enter(obj = TMemPos.syncRoot);
					try
					{
						TMemPos.formInfoDic[base.OwnerForm.GetType().Name] = new TMemPos.FormInfoData(base.OwnerForm.GetType().Name, bounds, windowsState);
					}
					finally
					{
						Monitor.Exit(obj);
					}
				}
			}
			if (TMemPos.instanceCount == 0)
			{
				List<TMemPos.FormInfoData> list = new List<TMemPos.FormInfoData>(TMemPos.formInfoDic.Values);
				UserSettingController.SerializeUserSetting(list.ToArray(), TMemPos.infoDataFileName);
			}
		}
		private void SetFormInfoProc()
		{
			if (!TMemPos.readInfoData)
			{
				if (UserSettingController.ExistUserSetting(TMemPos.infoDataFileName))
				{
					TMemPos.FormInfoData[] array = null;
					try
					{
						array = UserSettingController.DeserializeUserSetting<TMemPos.FormInfoData[]>(TMemPos.infoDataFileName);
					}
					catch
					{
						return;
					}
					if (array != null)
					{
						object obj;
						Monitor.Enter(obj = TMemPos.syncRoot);
						try
						{
							for (int i = 0; i < array.Length; i++)
							{
								TMemPos.formInfoDic.Add(array[i].FormID, array[i]);
							}
						}
						finally
						{
							Monitor.Exit(obj);
						}
					}
				}
				TMemPos.readInfoData = true;
			}
			if (base.OwnerForm != null)
			{
				TMemPos.FormInfoData formInfoData = null;
				object obj2;
				Monitor.Enter(obj2 = TMemPos.syncRoot);
				try
				{
					if (TMemPos.formInfoDic.ContainsKey(base.OwnerForm.GetType().Name))
					{
						formInfoData = TMemPos.formInfoDic[base.OwnerForm.GetType().Name];
					}
				}
				finally
				{
					Monitor.Exit(obj2);
				}
				if (formInfoData != null)
				{
					Form form = base.OwnerForm as Form;
					switch (this._setType)
					{
					case TMemPos.emSetType.None:
						break;
					case TMemPos.emSetType.Position:
						if (this.CheckFormPosition(formInfoData.Top, formInfoData.Left, form.Height, form.Width))
						{
							form.Top = formInfoData.Top;
							form.Left = formInfoData.Left;
							return;
						}
						form.Top = 0;
						form.Left = 0;
						return;
					case TMemPos.emSetType.Rect:
						if (this.CheckFormPosition(form.Top, form.Left, formInfoData.Height, formInfoData.Width))
						{
							form.Height = formInfoData.Height;
							form.Width = formInfoData.Width;
							form.WindowState = formInfoData.WindowState;
							return;
						}
						form.Top = 0;
						form.Left = 0;
						form.Height = formInfoData.Height;
						form.Width = formInfoData.Width;
						form.WindowState = formInfoData.WindowState;
						return;
					case TMemPos.emSetType.Both:
						if (this.CheckFormPosition(formInfoData.Top, formInfoData.Left, formInfoData.Height, formInfoData.Width))
						{
							form.Top = formInfoData.Top;
							form.Left = formInfoData.Left;
							form.Height = formInfoData.Height;
							form.Width = formInfoData.Width;
							form.WindowState = formInfoData.WindowState;
							return;
						}
						form.Top = 0;
						form.Left = 0;
						form.Height = formInfoData.Height;
						form.Width = formInfoData.Width;
						form.WindowState = formInfoData.WindowState;
						break;
					default:
						return;
					}
				}
			}
		}
		private bool CheckFormPosition(int top, int left, int height, int width)
		{
			int num = 30;
			bool flag = false;
			bool flag2 = false;
			Screen[] allScreens = Screen.AllScreens;
			for (int i = 0; i < allScreens.Length; i++)
			{
				Screen screen = allScreens[i];
				flag = (left >= width * -1 + num && left <= screen.WorkingArea.X + screen.WorkingArea.Width - num);
				flag2 = (top >= 0 && top <= screen.WorkingArea.Y + screen.WorkingArea.Height - num);
				if (flag && flag2)
				{
					break;
				}
			}
			return flag && flag2;
		}
		private void RemovedHockControl()
		{
			if (base.OwnerForm != null && base.OwnerForm is Form)
			{
				((Form)base.OwnerForm).Load -= new EventHandler(this.OwnerForm_Load);
				((Form)base.OwnerForm).FormClosed -= new FormClosedEventHandler(this.OwnerForm_Closed);
			}
		}
		private void OwnerForm_Load(object sender, EventArgs e)
		{
			this.SetFormInfoProc();
		}
		private void OwnerForm_Closed(object sender, FormClosedEventArgs e)
		{
			this.SaveFormInfoProc();
		}
		private void AddedHockControl()
		{
			if (base.OwnerForm != null && base.OwnerForm is Form)
			{
				((Form)base.OwnerForm).Load += new EventHandler(this.OwnerForm_Load);
				((Form)base.OwnerForm).FormClosed += new FormClosedEventHandler(this.OwnerForm_Closed);
			}
		}
	}
}
