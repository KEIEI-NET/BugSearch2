using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TEdit), "TEdit.bmp")]
	public class TEdit : UltraTextEditor, ISupportInitialize
	{
		private Container components = null;
		private TExtCase FExtCase = new TExtCase();
		private TExtEdit FExtEdit = new TExtEdit();
		private bool FOnFocused;
		private AppearanceHolder FActAppearanceHolder;
		private AppearanceBase FNorAppearance;
		private bool FCheckEmpty;
		private bool FAutoSelect = true;
		protected int FWMSizeCount;
		protected bool FNowEditing;
		protected bool FNowFontChanging;
		private int FColToWidthChanging;
		private string FFontName;
		private bool FBold;
		private bool FItalic;
		private bool FUnderline;
		private bool FStrikeout;
		private float FSizeInPoints;
		private bool FInitializing;
		[Category("Behavior"), Description("エディットから脱出可能なキーの取得、設定を行います。"), TypeConverter(typeof(TExtCase.TExtCaseConverter))]
		public TExtCase ExtCase
		{
			get
			{
				return this.FExtCase;
			}
			set
			{
				this.FExtCase = value;
			}
		}
		[Category("Behavior"), Description("拡張情報の取得、設定を行います。"), TypeConverter(typeof(TExtEdit.TExtEditConverter))]
		public TExtEdit ExtEdit
		{
			get
			{
				return this.FExtEdit;
			}
			set
			{
				bool flag = (value.AutoWidth != this.FExtEdit.AutoWidth || value.Column != this.FExtEdit.Column) && value.AutoWidth;
				if (this.FExtEdit.Column != value.Column)
				{
					base.MaxLength = value.Column;
				}
				this.FExtEdit = value;
				this.FExtEdit.AutoWidthChange += new EventHandler(this.AutoWidth_Change);
				this.FExtEdit.ColumnChange += new EventHandler(this.AutoWidth_Change);
				this.FExtEdit.EnableCharsChange += new EventHandler(this.AutoWidth_Change);
				if (flag)
				{
					this.FColToWidthChanging++;
					try
					{
						base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
					}
					finally
					{
						this.FColToWidthChanging--;
					}
				}
			}
		}
		[Browsable(false)]
		public new int MaxLength
		{
			get
			{
				return base.MaxLength;
			}
			set
			{
				base.MaxLength = value;
			}
		}
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AppearanceBase NormalAppearance
		{
			get
			{
				if (this.FOnFocused)
				{
					return this.FNorAppearance;
				}
				return base.Appearance;
			}
			set
			{
				if (this.FOnFocused)
				{
					this.FNorAppearance = value;
					return;
				}
				base.Appearance = value;
			}
		}
		[Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), TypeConverter(typeof(Infragistics.Win.Appearance.AppearanceTypeConverter))]
		public AppearanceBase ActiveAppearance
		{
			get
			{
				if (this.FActAppearanceHolder == null)
				{
					this.FActAppearanceHolder = new AppearanceHolder();
					this.FActAppearanceHolder.SubObjectPropChanged += base.SubObjectPropChangeHandler;
				}
				return this.FActAppearanceHolder.Appearance;
			}
			set
			{
				if (this.FActAppearanceHolder == null || !this.FActAppearanceHolder.HasAppearance || value != this.FActAppearanceHolder.Appearance)
				{
					if (this.FActAppearanceHolder == null)
					{
						this.FActAppearanceHolder = new AppearanceHolder();
						this.FActAppearanceHolder.SubObjectPropChanged += base.SubObjectPropChangeHandler;
					}
					this.FActAppearanceHolder.Appearance = value;
					base.NotifyPropChange(PropertyID.Appearance);
					if (this.FOnFocused)
					{
						this.FNowFontChanging = true;
						base.Appearance = this.FActAppearanceHolder.Appearance;
						this.FNowFontChanging = false;
					}
				}
			}
		}
		[Category("Behavior"), Description("フォーカスを得た時にコントロールのすべてのテキストを自動的に選択するかどうかを決定します。")]
		public bool AutoSelect
		{
			get
			{
				return this.FAutoSelect;
			}
			set
			{
				if (this.FAutoSelect != value)
				{
					this.FAutoSelect = value;
				}
			}
		}
		[Category("Data"), DefaultValue(true), Description("実際のデータの取得、設定を行います。")]
		public string DataText
		{
			get
			{
				return this.Text;
			}
			set
			{
				bool flag = this.Focused || this.Editor.Focused;
				EventArgs e = new EventArgs();
				if (flag)
				{
					this.OnLeave(e);
				}
				this.Text = value;
				if (flag)
				{
					this.OnEnter(e);
				}
			}
		}
		[Category("Behavior"), DefaultValue(false), Description("空文字列の場合に脱出可能か不可能かのチェックを取得、指定します。")]
		public bool CheckEmpty
		{
			get
			{
				return this.FCheckEmpty;
			}
			set
			{
				if (this.FCheckEmpty != value)
				{
					this.FCheckEmpty = value;
				}
			}
		}
		public TEdit()
		{
			this.InitializeComponent();
			this.FExtEdit.AutoWidthChange += new EventHandler(this.AutoWidth_Change);
			this.FExtEdit.ColumnChange += new EventHandler(this.AutoWidth_Change);
			this.FExtEdit.EnableCharsChange += new EventHandler(this.AutoWidth_Change);
			base.ButtonsLeft.ItemAdded += new EditorButtonEventHandler(this.EditorButtonAdded);
			base.ButtonsLeft.ItemRemoved += new EditorButtonEventHandler(this.EditorButtonRemoved);
			base.ButtonsLeft.CollectionCleared += new EventHandler(this.ButtonsCollectionCleared);
			base.ButtonsRight.ItemAdded += new EditorButtonEventHandler(this.EditorButtonAdded);
			base.ButtonsRight.ItemRemoved += new EditorButtonEventHandler(this.EditorButtonRemoved);
			base.ButtonsRight.CollectionCleared += new EventHandler(this.ButtonsCollectionCleared);
			this.FFontName = this.Font.FontFamily.Name;
			this.FSizeInPoints = this.Font.SizeInPoints;
			this.FBold = this.Font.Bold;
			this.FItalic = this.Font.Italic;
			this.FUnderline = this.Font.Underline;
			this.FStrikeout = this.Font.Strikeout;
			base.MaxLength = this.FExtEdit.Column;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			base.Name = "TEdit1";
		}
		private void AutoWidth_Change(object sender, EventArgs e)
		{
			base.MaxLength = this.FExtEdit.Column;
			if (this.FExtEdit.AutoWidth)
			{
				this.FColToWidthChanging++;
				try
				{
					base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
				}
				finally
				{
					this.FColToWidthChanging--;
				}
			}
		}
		private void EditorButtonAdded(object sender, EditorButtonEventArgs e)
		{
			if (this.FExtEdit.AutoWidth)
			{
				this.FColToWidthChanging++;
				try
				{
					base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
				}
				finally
				{
					this.FColToWidthChanging--;
				}
			}
		}
		private void EditorButtonRemoved(object sender, EditorButtonEventArgs e)
		{
			if (this.FExtEdit.AutoWidth)
			{
				this.FColToWidthChanging++;
				try
				{
					base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
				}
				finally
				{
					this.FColToWidthChanging--;
				}
			}
		}
		private void ButtonsCollectionCleared(object sender, EventArgs e)
		{
			if (this.FExtEdit.AutoWidth)
			{
				this.FColToWidthChanging++;
				try
				{
					base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
				}
				finally
				{
					this.FColToWidthChanging--;
				}
			}
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (!(this is TNedit) && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) && this.FAutoSelect)
			{
				base.SelectAll();
			}
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			IntPtr hIMC = new IntPtr(0);
			bool flag = false;
			hIMC = SafeNativeMethods.ImmGetContext(base.Handle);
			if (SafeNativeMethods.ImmGetOpenStatus(hIMC))
			{
				flag = true;
			}
			SafeNativeMethods.ImmReleaseContext(base.Handle, hIMC);
			if ((!e.Handled || flag) && !TLib.IsCtrl(e.KeyChar))
			{
				if (this.MaxLength == 0)
				{
					e.Handled = true;
				}
				if (!this.CheckCharactor(e.KeyChar, this.FExtEdit.EnableChars))
				{
					e.Handled = true;
				}
			}
			base.OnKeyPress(e);
		}
		protected override void OnEnter(EventArgs e)
		{
			if (this.FNowFontChanging)
			{
				return;
			}
			this.FNowEditing = true;
			try
			{
				this.Modified = false;
				this.FNowFontChanging = true;
				try
				{
					if (!this.FOnFocused)
					{
						this.FOnFocused = true;
						if (base.Appearance != null)
						{
							this.FNorAppearance = (Infragistics.Win.Appearance)base.Appearance.Clone();
						}
						if (this.FActAppearanceHolder != null)
						{
							base.Appearance = (Infragistics.Win.Appearance)this.FActAppearanceHolder.Appearance.Clone();
						}
					}
				}
				finally
				{
					this.FNowFontChanging = false;
				}
				if (!(this is TNedit))
				{
					if (!this.FAutoSelect)
					{
						switch (this.FExtEdit.CursorPos)
						{
						case emCursorPosition.Top:
							base.Select(0, 0);
							break;
						case emCursorPosition.End:
							base.Select(base.TextLength, 0);
							break;
						default:
						{
							int start = 0;
							TextBox textBox = this.GetTextBox(base.Controls);
							if (textBox != null)
							{
								start = textBox.SelectionStart;
							}
							base.Select(start, 0);
							break;
						}
						}
					}
					else
					{
						base.SelectAll();
					}
				}
			}
			finally
			{
				this.FNowEditing = false;
			}
			base.OnEnter(e);
		}
		private TextBox GetTextBox(Control.ControlCollection _controls)
		{
			foreach (Control control in _controls)
			{
				if (control is TextBox)
				{
					TextBox result = (TextBox)control;
					return result;
				}
				TextBox textBox = this.GetTextBox(control.Controls);
				if (textBox != null)
				{
					TextBox result = textBox;
					return result;
				}
			}
			return null;
		}
		protected override void OnLeave(EventArgs e)
		{
			if (this.FNowFontChanging)
			{
				return;
			}
			base.OnLeave(e);
			this.FNowEditing = true;
			try
			{
				this.FNowFontChanging = true;
				try
				{
					if (this.FOnFocused)
					{
						this.FOnFocused = false;
						if (this.FNorAppearance != null)
						{
							base.Appearance = (Infragistics.Win.Appearance)this.FNorAppearance.Clone();
						}
					}
				}
				finally
				{
					this.FNowFontChanging = false;
				}
			}
			finally
			{
				this.FNowEditing = false;
			}
		}
		protected override void OnFontChanged(EventArgs e)
		{
			this.FFontName = this.Font.FontFamily.Name;
			this.FSizeInPoints = this.Font.SizeInPoints;
			this.FBold = this.Font.Bold;
			this.FItalic = this.Font.Italic;
			this.FUnderline = this.Font.Underline;
			this.FStrikeout = this.Font.Strikeout;
			if (!this.FNowFontChanging)
			{
				this.FNowFontChanging = true;
				try
				{
					if (this.FExtEdit.AutoWidth)
					{
						this.FColToWidthChanging++;
						try
						{
							base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
						}
						finally
						{
							this.FColToWidthChanging--;
						}
					}
				}
				finally
				{
					this.FNowFontChanging = false;
				}
			}
			base.OnFontChanged(e);
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			if (this.FFontName != this.Font.FontFamily.Name || this.FSizeInPoints != this.Font.SizeInPoints || this.FBold != this.Font.Bold || this.FItalic != this.Font.Italic || this.FUnderline != this.Font.Underline || this.FStrikeout != this.Font.Strikeout)
			{
				this.OnFontChanged(e);
				return;
			}
			this.FWMSizeCount++;
			try
			{
				if (this.FWMSizeCount == 1 && this.FColToWidthChanging == 0)
				{
					int num;
					if (!this.FNowFontChanging)
					{
						num = this.GetClientWidthToColumn(base.ClientSize.Width);
						if (this.FExtEdit.AutoWidth)
						{
							this.FExtEdit.Column = num;
						}
					}
					else
					{
						num = this.FExtEdit.Column;
					}
					base.ClientSize = new Size(this.GetColumnToWidth(num), base.ClientSize.Height);
				}
			}
			finally
			{
				this.FWMSizeCount--;
			}
			base.OnSizeChanged(e);
		}
		protected override void OnPropChanged(Infragistics.Win.PropertyChangedEventArgs args)
		{
			if (!this.FNowFontChanging)
			{
				this.FNowFontChanging = true;
				try
				{
					if (this.FExtEdit.AutoWidth)
					{
						this.FColToWidthChanging++;
						try
						{
							base.ClientSize = new Size(this.GetColumnToWidth(this.FExtEdit.Column), base.ClientSize.Height);
						}
						finally
						{
							this.FColToWidthChanging--;
						}
					}
				}
				finally
				{
					this.FNowFontChanging = false;
				}
			}
			base.OnPropChanged(args);
		}
		protected float GetAveCharWidth()
		{
			Graphics graphics = base.CreateGraphics();
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			FontStyle fontStyle = FontStyle.Regular;
			Font font;
			if (base.HasAppearance)
			{
				string name;
				if (base.Appearance.FontData.Name == "" || base.Appearance.FontData.Name == null)
				{
					name = this.Font.Name;
				}
				else
				{
					name = base.Appearance.FontData.Name;
				}
				float sizeInPoints;
				if ((double)base.Appearance.FontData.SizeInPoints == 0.0)
				{
					sizeInPoints = this.Font.SizeInPoints;
				}
				else
				{
					sizeInPoints = base.Appearance.FontData.SizeInPoints;
				}
				if (base.Appearance.FontData.Bold == DefaultableBoolean.Default)
				{
					if (this.Font.Bold)
					{
						fontStyle |= FontStyle.Bold;
					}
				}
				else
				{
					if (base.Appearance.FontData.Bold == DefaultableBoolean.True)
					{
						fontStyle |= FontStyle.Bold;
					}
				}
				if (base.Appearance.FontData.Italic == DefaultableBoolean.Default)
				{
					if (this.Font.Italic)
					{
						fontStyle |= FontStyle.Italic;
					}
				}
				else
				{
					if (base.Appearance.FontData.Italic == DefaultableBoolean.True)
					{
						fontStyle |= FontStyle.Italic;
					}
				}
				if (base.Appearance.FontData.Strikeout == DefaultableBoolean.Default)
				{
					if (this.Font.Strikeout)
					{
						fontStyle |= FontStyle.Strikeout;
					}
				}
				else
				{
					if (base.Appearance.FontData.Strikeout == DefaultableBoolean.True)
					{
						fontStyle |= FontStyle.Strikeout;
					}
				}
				if (base.Appearance.FontData.Underline == DefaultableBoolean.Default)
				{
					if (this.Font.Underline)
					{
						fontStyle |= FontStyle.Underline;
					}
				}
				else
				{
					if (base.Appearance.FontData.Underline == DefaultableBoolean.True)
					{
						fontStyle |= FontStyle.Underline;
					}
				}
				font = new Font(name, sizeInPoints, fontStyle);
			}
			else
			{
				font = (Font)this.Font.Clone();
			}
			StringFormat stringFormat = new StringFormat();
			stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
			stringFormat.Alignment = StringAlignment.Near;
			stringFormat.LineAlignment = StringAlignment.Near;
			float result = graphics.MeasureString(text, font, 640, stringFormat).Width / 26f;
			font.Dispose();
			graphics.Dispose();
			return result;
		}
		protected int GetClientWidthToColumn(int wWidth)
		{
			if (this.FInitializing && !base.DesignMode)
			{
				return this.FExtEdit.Column;
			}
			bool flag = false;
			for (int i = 0; i < base.ButtonsLeft.Count; i++)
			{
				EditorButtonBase editorButtonBase = (EditorButtonBase)base.ButtonsLeft.GetItem(i);
				if (editorButtonBase.Width != 0)
				{
					wWidth -= editorButtonBase.Width + 1;
				}
				else
				{
					if (editorButtonBase.WidthResolved != 0)
					{
						wWidth -= editorButtonBase.WidthResolved + 1;
					}
					else
					{
						flag = true;
					}
				}
			}
			for (int j = 0; j < base.ButtonsRight.Count; j++)
			{
				EditorButtonBase editorButtonBase2 = (EditorButtonBase)base.ButtonsRight.GetItem(j);
				if (editorButtonBase2.Width != 0)
				{
					wWidth -= editorButtonBase2.Width + 1;
				}
				else
				{
					if (editorButtonBase2.WidthResolved != 0)
					{
						wWidth -= editorButtonBase2.WidthResolved + 1;
					}
					else
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				return this.FExtEdit.Column;
			}
			if (this.FExtEdit.EnableChars.Word)
			{
				return (int)((float)(wWidth - 4) / (this.GetAveCharWidth() * 2f)) - 1;
			}
			return (int)((float)(wWidth - 4) / this.GetAveCharWidth()) - 1;
		}
		protected int GetColumnToWidth(int Col)
		{
			if (this.FInitializing && !base.DesignMode)
			{
				return base.ClientSize.Width;
			}
			int num = 0;
			bool flag = false;
			for (int i = 0; i < base.ButtonsLeft.Count; i++)
			{
				EditorButtonBase editorButtonBase = (EditorButtonBase)base.ButtonsLeft.GetItem(i);
				if (editorButtonBase.Width != 0)
				{
					num += editorButtonBase.Width + 1;
				}
				else
				{
					if (editorButtonBase.WidthResolved != 0)
					{
						num += editorButtonBase.WidthResolved + 1;
					}
					else
					{
						flag = true;
					}
				}
			}
			for (int j = 0; j < base.ButtonsRight.Count; j++)
			{
				EditorButtonBase editorButtonBase2 = (EditorButtonBase)base.ButtonsRight.GetItem(j);
				if (editorButtonBase2.Width != 0)
				{
					num += editorButtonBase2.Width + 1;
				}
				else
				{
					if (editorButtonBase2.WidthResolved != 0)
					{
						num += editorButtonBase2.WidthResolved + 1;
					}
					else
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				return base.ClientSize.Width;
			}
			if (this.FExtEdit.EnableChars.Word)
			{
				return (int)Math.Ceiling((double)((float)(Col + 1) * this.GetAveCharWidth() * 2f)) + num + 4;
			}
			return (int)Math.Ceiling((double)((float)(Col + 1) * this.GetAveCharWidth())) + num + 4;
		}
		protected virtual bool CheckCharactor(char key, TEnableChars echar)
		{
			return (echar.Space || key != ' ') && (echar.Sign || !TLib.IsSign(key)) && (echar.Alpha || !TLib.IsAlpha(key)) && (echar.Kana || !TLib.IsKana(key)) && (echar.Num || !TLib.IsNum(key)) && (echar.NumSign || !TLib.IsNumSign(key)) && (echar.Word || !TLib.IsWord(key)) && key != '\'';
		}
		protected bool IsDataEmpty()
		{
			string text = this.Text;
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsWhiteSpace(text[i]))
				{
					return false;
				}
			}
			return true;
		}
		public bool CheckExitCase(Keys keycode, stSHIFTSTAT shiftstat)
		{
			if (this.FExtCase.Necessary && this.IsDataEmpty())
			{
				return false;
			}
			if (keycode != Keys.Tab)
			{
				if (keycode != Keys.Return)
				{
					switch (keycode)
					{
					case Keys.Left:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.LeftKey)
						{
							return false;
						}
						break;
					case Keys.Up:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.UpKey)
						{
							return false;
						}
						break;
					case Keys.Right:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.RightKey)
						{
							return false;
						}
						break;
					case Keys.Down:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.DownKey)
						{
							return false;
						}
						break;
					}
				}
				else
				{
					if (shiftstat.bAlt || shiftstat.bCtrl)
					{
						return false;
					}
					if (!shiftstat.bShift && !this.FExtCase.RetKey)
					{
						return false;
					}
					if (shiftstat.bShift && !this.FExtCase.ShiftRetKey)
					{
						return false;
					}
				}
			}
			else
			{
				if (shiftstat.bAlt || shiftstat.bCtrl)
				{
					return false;
				}
				if (!shiftstat.bShift && !this.FExtCase.TabKey)
				{
					return false;
				}
				if (shiftstat.bShift && !this.FExtCase.ShiftTabKey)
				{
					return false;
				}
			}
			return true;
		}
		public virtual bool CanExit(Keys keycode, stSHIFTSTAT shiftstat)
		{
			if (this.FCheckEmpty && this.IsDataEmpty())
			{
				return false;
			}
			if (!this.CheckExitCase(keycode, shiftstat))
			{
				return false;
			}
			bool result = true;
			if (keycode <= Keys.Tab)
			{
				switch (keycode)
				{
				case Keys.None:
				case Keys.LButton:
					return result;
				default:
					if (keycode != Keys.Tab)
					{
						goto IL_B0;
					}
					break;
				}
			}
			else
			{
				if (keycode != Keys.Return)
				{
					switch (keycode)
					{
					case Keys.Left:
						if (base.SelectionLength > 0)
						{
							result = false;
							return result;
						}
						if (base.SelectionStart > 0)
						{
							result = false;
							return result;
						}
						return result;
					case Keys.Up:
					case Keys.Down:
						return result;
					case Keys.Right:
						if (base.SelectionLength > 0)
						{
							result = false;
							return result;
						}
						if (base.SelectionStart != this.Text.Length)
						{
							result = false;
							return result;
						}
						return result;
					default:
						goto IL_B0;
					}
				}
			}
			if (shiftstat.bAlt || shiftstat.bCtrl)
			{
				result = false;
				return result;
			}
			return result;
			IL_B0:
			result = false;
			return result;
		}
		public void BeginInit()
		{
			this.FInitializing = true;
		}
		public void EndInit()
		{
			this.FInitializing = false;
		}
	}
}
