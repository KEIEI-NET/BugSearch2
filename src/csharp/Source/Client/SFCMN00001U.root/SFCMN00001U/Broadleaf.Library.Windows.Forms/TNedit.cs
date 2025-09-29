using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(TNedit), "TNedit.bmp")]
	public class TNedit : TEdit
	{
		private const string CDropTagValue = "NEditCalculator";
        private Container components = null;
		private UltraCalculator FCalculator;
		private TNumEdit FNumEdit = new TNumEdit();
		private string FCommaSign;
		private string FDecPointSign;
		private string FMinusSign;
		private string FPlusSign;
		private bool _calcTextEventFlg = true;
		private DropDownEditorButton FCalcBtn;
		private emCalcDisp FCalcDisp;
		private bool _mouseInput;
		[Category("Layout"), Description("表示される電卓のサイズを設定、取得できます")]
		public Size CalcSize
		{
			get
			{
				return this.FCalculator.Size;
			}
			set
			{
				this.FCalculator.Size = value;
			}
		}
		[Category("Action"), DefaultValue(emCalcDisp.nclcNone), Description("電卓を表示するためのボタンの配置位置を設定、取得できます")]
		public emCalcDisp CalcDisp
		{
			get
			{
				return this.FCalcDisp;
			}
			set
			{
				if (this.FCalcDisp != value)
				{
					for (int i = 0; i < base.ButtonsLeft.Count; i++)
					{
						EditorButtonBase editorButtonBase = (EditorButtonBase)base.ButtonsLeft.GetItem(i);
						if (string.Compare((string)editorButtonBase.Tag, "NEditCalculator") == 0)
						{
							base.ButtonsLeft.RemoveAt(i);
						}
					}
					for (int j = 0; j < base.ButtonsRight.Count; j++)
					{
						EditorButtonBase editorButtonBase2 = (EditorButtonBase)base.ButtonsRight.GetItem(j);
						if (string.Compare((string)editorButtonBase2.Tag, "NEditCalculator") == 0)
						{
							base.ButtonsRight.RemoveAt(j);
						}
					}
					this.FCalcDisp = value;
					switch (this.FCalcDisp)
					{
					case emCalcDisp.nclcLeft:
						base.ButtonsLeft.Insert(0, this.FCalcBtn);
						return;
					case emCalcDisp.nclcRight:
						base.ButtonsRight.Insert(0, this.FCalcBtn);
						break;
					default:
						return;
					}
				}
			}
		}
		public new string DataText
		{
			get
			{
				string dataText = base.DataText;
				if (this.FNumEdit.CommaEdit)
				{
					TLib.DelStrChar(ref dataText, this.FCommaSign[0]);
				}
				return dataText;
			}
			set
			{
				string text = value;
				if (this.Focused || this.Editor.Focused || this.FCalculator.Visible)
				{
					if (this.FNumEdit.CommaEdit)
					{
						TLib.DelStrChar(ref text, this.FCommaSign[0]);
					}
					text = text.Trim();
					if (this.FNumEdit.ZeroSupp == emZeroSupp.zsON)
					{
						int length = text.Length;
						if (length > 1 && text[0] == '0')
						{
							do
							{
								text = text.Remove(0, 1);
							}
							while (text.Length != 1 && text[0] == '0');
						}
					}
					double num = 0.0;
					if (double.TryParse(text, out num) && !this.FNumEdit.ZeroDisp && num == 0.0)
					{
						text = "";
					}
					this.Text = text;
					if (base.AutoSelect || this.FNumEdit.CalcInput)
					{
						base.SelectAll();
						return;
					}
				}
				else
				{
					if (text.Length > 0)
					{
						if (text == this.FMinusSign)
						{
							text = "";
						}
						else
						{
							this.EditNumStr(ref text);
						}
					}
					this.Text = text;
				}
			}
		}
		[Category("Behavior")]
		public TNumEdit NumEdit
		{
			get
			{
				return this.FNumEdit;
			}
			set
			{
				this.FNumEdit = value;
			}
		}
		[Category("Action"), DefaultValue(false), Description("マウスのダブルクリックによる電卓起動可否を取得、設定します。")]
		public bool MouseInput
		{
			get
			{
				return this._mouseInput;
			}
			set
			{
				this._mouseInput = value;
			}
		}
		public TNedit()
		{
			this.InitializeComponent();
			CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
			this.FCommaSign = cultureInfo.NumberFormat.NumberGroupSeparator;
			this.FDecPointSign = cultureInfo.NumberFormat.NumberDecimalSeparator;
			this.FMinusSign = cultureInfo.NumberFormat.NegativeSign;
			this.FPlusSign = cultureInfo.NumberFormat.PositiveSign;
			base.ExtEdit.EnableChars.Alpha = false;
			base.ExtEdit.EnableChars.Kana = false;
			base.ExtEdit.EnableChars.Sign = false;
			base.ExtEdit.EnableChars.Space = false;
			base.ExtEdit.EnableChars.Word = false;
			base.ImeMode = ImeMode.Off;
			this.FCalcBtn = new DropDownEditorButton();
			this.FCalcBtn.Tag = "NEditCalculator";
			this.FCalcBtn.Control = this.FCalculator;
			this.FCalcBtn.BeforeDropDown += new BeforeEditorButtonDropDownEventHandler(this.FCalcBtn_BeforeDropDown);
			this.FCalcBtn.AfterCloseUp += new EditorButtonEventHandler(this.FCalcBtn_AfterCloseUp);
			base.ControlAdded += new ControlEventHandler(this.TNedit_ControlAdded);
			base.ControlRemoved += new ControlEventHandler(this.TNedit_ControlRemoved);
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
			CalculatorButton calculatorButton = new CalculatorButton(32);
			this.FCalculator = new UltraCalculator();
			((ISupportInitialize)this.FCalculator).BeginInit();
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.FCalculator.BorderStyle = UIElementBorderStyle.RaisedSoft;
			calculatorButton.Key = "Backspace";
			calculatorButton.KeyCodeAlternateValue = 0;
			calculatorButton.KeyCodeValue = 8;
			calculatorButton.Text = "Back";
			this.FCalculator.Buttons.AddRange(new CalculatorButton[]
			{
				calculatorButton
			});
			this.FCalculator.Location = new Point(17, 17);
			this.FCalculator.Name = "FCalculator";
			this.FCalculator.ShowMemoryButtons = false;
			this.FCalculator.Size = new Size(172, 200);
			this.FCalculator.TabIndex = 0;
			this.FCalculator.Text = "0.";
			this.FCalculator.TextChanged += new EventHandler(this.FCalculator_TextChanged);
			this.FCalculator.KeyDown += new KeyEventHandler(this.FCalculator_KeyDown);
			((ISupportInitialize)this.FCalculator).EndInit();
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (this.FNumEdit.DecLen > 0 && e.KeyCode == Keys.Delete)
			{
				int selectionStart = base.SelectionStart;
				int num = this.Text.Length - selectionStart;
				int num2 = this.FNumEdit.DecLen + 1;
				if (num == num2 && this.Text[selectionStart + 1] == this.FDecPointSign[0])
				{
					e.Handled = true;
					return;
				}
			}
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				base.OnKeyDown(e);
				if (base.AutoSelect || this.FNumEdit.CalcInput)
				{
					base.SelectAll();
				}
				return;
			}
			if (!this.FNumEdit.CalcInput || base.ReadOnly || base.DesignMode)
			{
				base.OnKeyDown(e);
				return;
			}
			Keys keyCode = e.KeyCode;
			switch (keyCode)
			{
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				base.OnKeyDown(e);
				base.SelectionStart = this.Text.Length;
				return;
			default:
				if (keyCode == Keys.Delete)
				{
					this.DataText = "";
					e.Handled = true;
					return;
				}
				base.OnKeyDown(e);
				return;
			}
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (base.ReadOnly || base.DesignMode)
			{
				e.Handled = true;
				base.OnKeyPress(e);
				return;
			}
			if (!base.IsInEditMode)
			{
				e.Handled = true;
				base.OnKeyPress(e);
				return;
			}
			if (this.FNumEdit.DecLen > 0 && e.KeyChar == '\b')
			{
				int selectionStart = base.SelectionStart;
				int num = this.Text.Length - selectionStart + 1;
				int num2 = this.FNumEdit.DecLen + 1;
				if (num == num2 && this.Text[selectionStart] == this.FDecPointSign[0])
				{
					e.Handled = true;
					base.OnKeyPress(e);
					return;
				}
			}
			if (!char.IsControl(e.KeyChar))
			{
				string text;
				if (base.SelectionLength > 0)
				{
					text = this.Text.Remove(base.SelectionStart, base.SelectionLength);
				}
				else
				{
					text = this.Text;
				}
				text = text.Insert(base.SelectionStart, e.KeyChar.ToString());
				if (this.FNumEdit.CalcInput)
				{
					text = text.Trim();
				}
				int num3 = base.ExtEdit.Column - this.FNumEdit.DecLen;
				if (this.FNumEdit.DecLen > 0)
				{
					num3--;
				}
				int num4 = base.ExtEdit.Column - this.FNumEdit.DecLen;
				if (this.FNumEdit.DecLen > 0)
				{
					num4--;
				}
				stNumStrAttr stNumStrAttr = default(stNumStrAttr);
				if (text.Length != 0 && ((this.FNumEdit.MinusSupp && e.KeyChar == this.FMinusSign[0]) || (!(text == this.FMinusSign) && (!TLib.GetNumStrAttr(text, out stNumStrAttr) || (this.FNumEdit.DecLen == 0 && e.KeyChar == this.FDecPointSign[0]) || stNumStrAttr.LoColumn > this.FNumEdit.DecLen || this.EditNumStr(ref text) > base.ExtEdit.Column || stNumStrAttr.HiColumn > num4 || stNumStrAttr.HiColumn > num3))))
				{
					e.Handled = true;
					base.OnKeyPress(e);
					return;
				}
			}
			if (this.FNumEdit.CalcInput && !e.Handled && (!char.IsControl(e.KeyChar) || e.KeyChar == '\b'))
			{
				string text2;
				if (e.KeyChar == '\b')
				{
					text2 = this.Text.Remove(this.Text.Length - 1, 1).TrimStart(new char[]
					{
						' '
					});
				}
				else
				{
					if (base.SelectionLength == 0)
					{
						text2 = this.Text + e.KeyChar;
						text2 = text2.TrimStart(new char[]
						{
							' '
						});
					}
					else
					{
						text2 = e.KeyChar.ToString();
					}
				}
				this.Text = text2;
				e.Handled = true;
			}
			base.OnKeyPress(e);
		}
		protected override void OnEnter(EventArgs e)
		{
			this.FNowEditing = true;
			string text = this.Text;
			if (this.FNumEdit.CommaEdit)
			{
				TLib.DelStrChar(ref text, this.FCommaSign[0]);
			}
			text = text.Trim();
			this.Text = text;
			if (base.AutoSelect || this.FNumEdit.CalcInput)
			{
				base.SelectAll();
			}
			base.OnEnter(e);
		}
		protected override void OnLeave(EventArgs e)
		{
			string text = this.Text;
			this.FNowEditing = true;
			if (this.FNumEdit.ZeroSupp == emZeroSupp.zsON)
			{
				int length = text.Length;
				if (length > 1 && text[0] == '0')
				{
					do
					{
						text = text.Remove(0, 1);
					}
					while (text.Length != 1 && text[0] == '0');
				}
			}
			if (text.Length > 0)
			{
				if (text == this.FMinusSign)
				{
					text = "";
				}
				else
				{
					this.EditNumStr(ref text);
				}
			}
			this.Text = text;
			base.OnLeave(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (this.FNumEdit.CalcInput)
			{
				base.SelectAll();
			}
		}
		protected int EditNumStr(ref string istr)
		{
			double num = 0.0;
			long num2 = 0L;
			if (istr.StartsWith(this.FPlusSign))
			{
				istr = istr.Remove(0, 1);
			}
			if (istr.EndsWith(this.FDecPointSign))
			{
				istr += "0";
			}
			try
			{
				num = double.Parse(istr);
			}
			catch
			{
				return istr.Length;
			}
			try
			{
				num2 = long.Parse(istr);
			}
			catch (OverflowException)
			{
				string text = istr.Replace(this.FCommaSign, "");
				int num3 = istr.IndexOf(this.FDecPointSign);
				if (num3 != -1)
				{
					text = ((num3 - 18 >= 0) ? istr.Substring(num3 - 18, 18) : istr.Substring(0, num3));
				}
				else
				{
					text = ((text.Length - 18 >= 0) ? istr.Substring(text.Length - 18, 18) : istr);
				}
				long.TryParse(text, out num2);
			}
			catch
			{
				num2 = (long)num;
			}
			if (!this.FNumEdit.ZeroDisp && num == 0.0)
			{
				istr = "";
			}
			else
			{
				switch (this.FNumEdit.ZeroSupp)
				{
				case emZeroSupp.zsFILL:
				case emZeroSupp.zsON:
				{
					string text2;
					if (this.FNumEdit.CommaEdit)
					{
						text2 = "#,##0";
					}
					else
					{
						text2 = "#0";
					}
					if (this.FNumEdit.DecLen > 0)
					{
						text2 = text2 + this.FDecPointSign + new string('0', this.FNumEdit.DecLen);
						istr = num.ToString(text2);
					}
					else
					{
						istr = num2.ToString(text2);
					}
					if (this.FNumEdit.ZeroSupp == emZeroSupp.zsFILL && istr.Length < base.ExtEdit.Column)
					{
						istr = new string('0', base.ExtEdit.Column - istr.Length) + istr;
					}
					break;
				}
				case emZeroSupp.zsOFF:
				{
					int num4 = istr.IndexOf(this.FDecPointSign[0]);
					if (num4 == -1)
					{
						num4 = istr.Length;
					}
					if (istr.StartsWith(this.FMinusSign))
					{
						num4--;
					}
					if (base.ExtEdit.Column - (this.FNumEdit.DecLen + ((this.FNumEdit.DecLen == 0) ? 0 : 1)) < num4)
					{
						num4 = base.ExtEdit.Column - (this.FNumEdit.DecLen + ((this.FNumEdit.DecLen == 0) ? 0 : 1));
					}
					string text2;
					if (this.FNumEdit.CommaEdit)
					{
						text2 = "";
						for (int i = 0; i < num4 / 3; i++)
						{
							text2 += ((i != 0) ? (this.FCommaSign + "000") : "000");
						}
						if (num4 < 3)
						{
							text2 = new string('0', num4 % 3);
						}
						else
						{
							text2 = new string('0', num4 % 3) + this.FCommaSign + text2;
						}
					}
					else
					{
						text2 = new string('0', num4);
					}
					if (this.FNumEdit.DecLen > 0)
					{
						text2 = text2 + this.FDecPointSign + new string('0', this.FNumEdit.DecLen);
						istr = num.ToString(text2);
					}
					else
					{
						istr = num2.ToString(text2);
					}
					break;
				}
				}
			}
			return istr.Length;
		}
		public double GetValue()
		{
			double result;
			try
			{
				result = double.Parse(this.DataText);
			}
			catch
			{
				return 0.0;
			}
			return result;
		}
		public void SetValue(double value)
		{
			string format = (this.FNumEdit.DecLen == 0) ? "#0" : string.Format("#0{0}{1}", this.FDecPointSign, new string('0', this.FNumEdit.DecLen));
			this.DataText = value.ToString(format);
		}
		public int GetInt()
		{
			int result;
			try
			{
				result = int.Parse(this.DataText);
			}
			catch
			{
				return 0;
			}
			return result;
		}
		public void SetInt(int value)
		{
			this.DataText = value.ToString("#0");
		}
		private void FCalcBtn_BeforeDropDown(object sender, BeforeEditorButtonDropDownEventArgs e)
		{
			this._calcTextEventFlg = false;
			this.FCalculator.Clear();
			string dataText = this.DataText;
			if (dataText.StartsWith(this.FMinusSign))
			{
				this.FCalculator.ParseString(dataText.Remove(0, 1));
				this.FCalculator.PushButton("+/-");
			}
			else
			{
				this.FCalculator.ParseString(dataText);
			}
			this._calcTextEventFlg = true;
		}
		private void FCalcBtn_AfterCloseUp(object sender, EditorButtonEventArgs e)
		{
			string text = this.FCalculator.DisplayValue.ToString();
			if (this.NumEdit.MinusSupp && text.StartsWith(this.FMinusSign))
			{
				text = text.Remove(0, 1);
			}
			this.EditNumStr(ref text);
			int num = text.IndexOf(this.FDecPointSign);
			string text2;
			if (num == -1)
			{
				text2 = text;
			}
			else
			{
				text2 = text.Substring(0, num);
			}
			int num2 = (this.FNumEdit.DecLen == 0) ? base.ExtEdit.Column : (base.ExtEdit.Column - this.FNumEdit.DecLen - 1);
			if (text2.Length > num2)
			{
				text2 = text2.Substring(((num == -1) ? text2.Length : num) - num2, num2);
				if (text2.StartsWith(this.FCommaSign))
				{
					text2 = text2.Remove(0, 1);
				}
			}
			this.Text = text2 + ((num == -1) ? "" : text.Substring(num, text.Length - num));
		}
		private void FCalculator_TextChanged(object sender, EventArgs e)
		{
			if (this._calcTextEventFlg && !base.DesignMode)
			{
				string text = this.FCalculator.DisplayValue.ToString();
				this.EditNumStr(ref text);
				int num = text.IndexOf(this.FDecPointSign);
				string text2;
				if (num == -1)
				{
					text2 = text;
				}
				else
				{
					text2 = text.Substring(0, num);
				}
				int num2 = (this.FNumEdit.DecLen == 0) ? base.ExtEdit.Column : (base.ExtEdit.Column - this.FNumEdit.DecLen - 1);
				if (text2.Length > num2)
				{
					text2 = text2.Substring(((num == -1) ? text2.Length : num) - num2, num2);
					if (text2.StartsWith(this.FCommaSign))
					{
						text2 = text2.Remove(0, 1);
					}
				}
				this.Text = text2 + ((num == -1) ? "" : text.Substring(num, text.Length - num));
			}
		}
		private void FCalculator_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return)
			{
				if (this.FCalculator.Parent is Form)
				{
					((Form)this.FCalculator.Parent).Visible = false;
					return;
				}
				this.FCalculator.Visible = false;
			}
		}
		private void TNedit_ControlAdded(object sender, ControlEventArgs e)
		{
			if (e.Control is EmbeddableTextBoxWithUIPermissions)
			{
				e.Control.MouseDoubleClick += new MouseEventHandler(this.AddedControl_MouseDoubleClick);
			}
		}
		private void TNedit_ControlRemoved(object sender, ControlEventArgs e)
		{
			if (e.Control is EmbeddableTextBoxWithUIPermissions)
			{
				e.Control.MouseDoubleClick -= new MouseEventHandler(this.AddedControl_MouseDoubleClick);
			}
		}
		private void AddedControl_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.OnMouseDoubleClick(e);
		}
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (this._mouseInput && base.IsInEditMode)
			{
				if (this.CalcDisp == emCalcDisp.nclcNone)
				{
					this.FCalcBtn.Visible = false;
					base.ButtonsRight.Add(this.FCalcBtn);
				}
				this.FCalcBtn.DropDown();
				if (this.CalcDisp == emCalcDisp.nclcNone)
				{
					this.FCalcBtn.Visible = true;
					base.ButtonsRight.Remove(this.FCalcBtn);
				}
			}
			base.OnMouseDoubleClick(e);
		}
	}
}
