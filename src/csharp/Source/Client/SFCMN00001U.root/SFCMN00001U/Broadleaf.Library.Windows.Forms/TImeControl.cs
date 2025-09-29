using Broadleaf.Library.ComponentModel;
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TImeControl), "TImeControl.bmp")]
	public class TImeControl : TbsBaseComponent
	{
		private Container components;
		private TImeMessageFilter imeMessageFilter;
		private Control _inControl;
		private Control _outControl;
		private string _outString = "";
		private bool _onceOutString;
		private bool _practice;
		private bool _spaceChg;
		private int _putLength;
		[Category("Behavior"), DefaultValue(true), Description("true=OutControlプロパティで指定されたコントロールへふりがなを出力する")]
		public bool Practice
		{
			get
			{
				return this._practice;
			}
			set
			{
				this._practice = value;
			}
		}
		[Category("Behavior"), DefaultValue(false), Description("true=OutStringプロパティを一度しか参照出来ないようにする")]
		public bool OnceOutString
		{
			get
			{
				return this._onceOutString;
			}
			set
			{
				this._onceOutString = value;
			}
		}
		[Browsable(false), Category("Behavior"), Description("取得したふりがな")]
		public string OutString
		{
			get
			{
				if (this._onceOutString)
				{
					string outString = this._outString;
					this._outString = "";
					return outString;
				}
				return this._outString;
			}
		}
		[Browsable(false), Category("Behavior"), Description("ふりがなの文字数")]
		public int OutLength
		{
			get
			{
				return this._outString.Length;
			}
		}
		[Category("Behavior"), DefaultValue(false), Description("true=空白を有効としふりがなに含める。\u3000false=空白を有効としない。")]
		public bool SpaceChg
		{
			get
			{
				return this._spaceChg;
			}
			set
			{
				this._spaceChg = value;
			}
		}
		[Category("Behavior"), DefaultValue(0), Description("出力するふりがなの最大文字数（0指定時は制限無し）")]
		public int PutLength
		{
			get
			{
				return this._putLength;
			}
			set
			{
				this._putLength = value;
			}
		}
		[Category("Behavior"), Description("ＩＭＥ入力を行う入力系コントロールを指定")]
		public Control InControl
		{
			get
			{
				return this._inControl;
			}
			set
			{
				this._inControl = value;
			}
		}
		[Category("Behavior"), Description("ＩＭＥ入力を行った際のふりがなを出力するコントロールを指定")]
		public Control OutControl
		{
			get
			{
				return this._outControl;
			}
			set
			{
				this._outControl = value;
			}
		}
		public TImeControl(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			this._practice = true;
			this.imeMessageFilter = new TImeMessageFilter();
			TImeMessageFilter expr_36 = this.imeMessageFilter;
			expr_36.ImeComposition = (TImeMessageFilter.ImeMessage)Delegate.Combine(expr_36.ImeComposition, new TImeMessageFilter.ImeMessage(this.ImeHookProc));
            System.Windows.Forms.Application.AddMessageFilter(this.imeMessageFilter);
		}
		public TImeControl()
		{
			this.InitializeComponent();
			this._practice = true;
			this.imeMessageFilter = new TImeMessageFilter();
			TImeMessageFilter expr_2F = this.imeMessageFilter;
			expr_2F.ImeComposition = (TImeMessageFilter.ImeMessage)Delegate.Combine(expr_2F.ImeComposition, new TImeMessageFilter.ImeMessage(this.ImeHookProc));
            System.Windows.Forms.Application.AddMessageFilter(this.imeMessageFilter);
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
                System.Windows.Forms.Application.RemoveMessageFilter(this.imeMessageFilter);
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		private void ImeHookProc(Message msg)
		{
			if ((msg.LParam.ToInt32() & 512) != 0)
			{
				Control control = Control.FromHandle(msg.HWnd);
				if (control.Focused)
				{
					Control control2 = null;
					if (control is EmbeddableTextBoxWithUIPermissions)
					{
						control2 = control.Parent;
					}
					if (control == this._inControl || control2 == this._inControl)
					{
						this.GetFurigana(control);
					}
				}
			}
		}
		private int GetFurigana(Control target)
		{
			IntPtr hIMC = new IntPtr(0);
			int num = 0;
			StringBuilder stringBuilder;
			try
			{
				hIMC = SafeNativeMethods.ImmGetContext(target.Handle);
				num = SafeNativeMethods.ImmGetCompositionString(hIMC, 512, null, 0);
				stringBuilder = new StringBuilder(num);
				SafeNativeMethods.ImmGetCompositionString(hIMC, 512, stringBuilder, stringBuilder.Capacity);
			}
			catch
			{
				return -1;
			}
			finally
			{
				SafeNativeMethods.ImmReleaseContext(target.Handle, hIMC);
			}
			if (!TLib.IsWord(stringBuilder[0]))
			{
				this._outString = stringBuilder.ToString().Substring(0, num);
			}
			else
			{
				this._outString = stringBuilder.ToString().Substring(0, num / 2);
			}
			if (this._putLength != 0 && this._putLength < this._outString.Length)
			{
				this._outString = this._outString.Substring(0, this._putLength);
			}
			if (!this._spaceChg)
			{
				this._outString = this._outString.Trim();
			}
			this._outString = TLib.HankanaToZenkana(this._outString);
			this._outString = TLib.HiraToKana(this._outString);
			if (this._practice && this._outControl != null)
			{
				int num2 = this._outString.Length;
				if (this._outControl is TEdit)
				{
					TEdit tEdit = (TEdit)this._outControl;
					num2 = tEdit.ExtEdit.Column - tEdit.DataText.Length;
				}
				else
				{
					if (this._outControl is TextBox)
					{
						TextBox textBox = (TextBox)this._outControl;
						num2 = textBox.MaxLength - textBox.Text.Length;
					}
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num2 > this._outString.Length)
				{
					num2 = this._outString.Length;
				}
				if (num2 > 0)
				{
					Control expr_1B0 = this._outControl;
					expr_1B0.Text += this._outString.Substring(0, num2);
				}
			}
			return 0;
		}
	}
}
