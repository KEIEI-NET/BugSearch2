using Broadleaf.Library.ComponentModel;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTabs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	[DefaultEvent("ChangeFocus"), ToolboxBitmap(typeof(TArrowKeyControl), "TArrowKeyControl.bmp")]
	public class TArrowKeyControl : TbsBaseComponent
	{
		private Container components;
		private bool FAlwaysEvent;
		private bool FCatchMouse = true;
		private emAllowStyle FStyleH;
		private emAllowStyle FStyleV = emAllowStyle.ByDist;
		private TbsMessageFilter FMessageFilter;
        public event ChangeFocusEventHandler ChangeFocus;
		[Category("Behavior"), DefaultValue(false), Description("移動先がない場合でもChangeFocusイベントを発生させるかを指定します")]
		public bool AlwaysEvent
		{
			get
			{
				return this.FAlwaysEvent;
			}
			set
			{
				this.FAlwaysEvent = value;
			}
		}
		[Category("Behavior"), DefaultValue(true), Description("マウス左クリック、及び左ダブルクリックによるフォーカス移動時にChangeFocusイベントを発生させるかを取得、設定します。")]
		public bool CatchMouse
		{
			get
			{
				return this.FCatchMouse;
			}
			set
			{
				this.FCatchMouse = value;
			}
		}
		[Category("Behavior"), DefaultValue(emAllowStyle.ByAxis), Description("Ｘ方向の移動方法を指定します")]
		public emAllowStyle StyleH
		{
			get
			{
				return this.FStyleH;
			}
			set
			{
				this.FStyleH = value;
			}
		}
		[Category("Behavior"), DefaultValue(emAllowStyle.ByDist), Description("Ｙ方向の移動方法を指定します")]
		public emAllowStyle StyleV
		{
			get
			{
				return this.FStyleV;
			}
			set
			{
				this.FStyleV = value;
			}
		}
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
					if (value == null || value is Form || value is Control)
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
		public TArrowKeyControl(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			this.FMessageFilter = TbsMessageFilter.Instance;
			this.FMessageFilter.KeyDown += new KeyEventHandler(this.Owner_KeyDown);
			this.FMessageFilter.MouseDown += new MouseEventHandlerEx(this.Owner_MouseDownEx);
			this.FMessageFilter.MouseDoubleClick += new MouseEventHandlerEx(this.Owner_MouseDoubleClickEx);
		}
		public TArrowKeyControl()
		{
			this.InitializeComponent();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
				if (this.FMessageFilter != null)
				{
					this.FMessageFilter.KeyDown -= new KeyEventHandler(this.Owner_KeyDown);
					this.FMessageFilter.MouseDown -= new MouseEventHandlerEx(this.Owner_MouseDownEx);
					this.FMessageFilter.MouseDoubleClick -= new MouseEventHandlerEx(this.Owner_MouseDoubleClickEx);
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		private void RemovedHockControl()
		{
			if (base.OwnerForm != null)
			{
				if (base.OwnerForm is Form)
				{
					Form arg_20_0 = (Form)base.OwnerForm;
					return;
				}
				if (base.OwnerForm is Control)
				{
					Control control = (Control)base.OwnerForm;
					control.ParentChanged -= new EventHandler(this.Owner_ParentChanged);
				}
			}
		}
		private void AddedHockControl()
		{
			if (base.OwnerForm != null)
			{
				if (base.OwnerForm is Form)
				{
					Form arg_20_0 = (Form)base.OwnerForm;
					return;
				}
				if (base.OwnerForm is Control)
				{
					Control control = (Control)base.OwnerForm;
					control.ParentChanged += new EventHandler(this.Owner_ParentChanged);
				}
			}
		}
		private bool CheckControl(Control iCtrl)
		{
			Control iParent = (Control)base.OwnerForm;
			return this.CheckControlSub(iCtrl, iParent);
		}
		private bool CheckControlSub(Control iCtrl, Control iParent)
		{
			for (int i = 0; i < iParent.Controls.Count; i++)
			{
				if (iCtrl == iParent.Controls[i])
				{
					return true;
				}
				if (!(iParent.Controls[i] is Form) && this.CheckControlSub(iCtrl, iParent.Controls[i]))
				{
					return true;
				}
			}
			return false;
		}
		private bool CanExit(Control iCtrl, KeyEventArgs e, out bool iKeyCancel)
		{
			iKeyCancel = false;
			stSHIFTSTAT shiftstat;
			shiftstat.bAlt = e.Alt;
			shiftstat.bCtrl = e.Control;
			shiftstat.bShift = e.Shift;
			if (iCtrl == null)
			{
				return true;
			}
			if (e.Shift || e.KeyCode == Keys.Menu || e.Control)
			{
				return false;
			}
			if (iCtrl.Parent is TDateEdit)
			{
				return ((TDateEdit)iCtrl.Parent).CanExit(e.KeyCode, shiftstat);
			}
			if (iCtrl is TNedit)
			{
				return ((TNedit)iCtrl).CanExit(e.KeyCode, shiftstat);
			}
			if (iCtrl is TEdit)
			{
				return ((TEdit)iCtrl).CanExit(e.KeyCode, shiftstat);
			}
			if (iCtrl is TComboEditor)
			{
				TComboEditor tComboEditor = (TComboEditor)iCtrl;
				Keys keyCode = e.KeyCode;
				switch (keyCode)
				{
				case Keys.None:
				case Keys.LButton:
				case Keys.RButton:
					return true;
				default:
					switch (keyCode)
					{
					case Keys.Left:
						return !tComboEditor.DroppedDown && (tComboEditor.DropDownStyle != DropDownStyle.DropDown || (tComboEditor.SelectionLength <= 0 && tComboEditor.SelectionStart == 0));
					case Keys.Up:
					case Keys.Down:
						return !tComboEditor.DroppedDown;
					case Keys.Right:
						return !tComboEditor.DroppedDown && (tComboEditor.DropDownStyle != DropDownStyle.DropDown || (tComboEditor.SelectionLength <= 0 && tComboEditor.SelectionStart == tComboEditor.TextLength));
					default:
						return true;
					}
				}
			}
			else
			{
				if (iCtrl is TextBox)
				{
					TextBox textBox = (TextBox)iCtrl;
					Keys keyCode2 = e.KeyCode;
					switch (keyCode2)
					{
					case Keys.None:
					case Keys.LButton:
					case Keys.RButton:
						return true;
					default:
						switch (keyCode2)
						{
						case Keys.Left:
							return textBox.SelectionLength <= 0 && textBox.SelectionStart == 0;
						case Keys.Up:
						case Keys.Down:
							return true;
						case Keys.Right:
							return textBox.SelectionLength <= 0 && textBox.SelectionStart == textBox.Text.Length;
						default:
							return true;
						}
					}
				}
				else
				{
					if (iCtrl is UltraComboEditor)
					{
						UltraComboEditor ultraComboEditor = (UltraComboEditor)iCtrl;
						Keys keyCode3 = e.KeyCode;
						switch (keyCode3)
						{
						case Keys.None:
						case Keys.LButton:
						case Keys.RButton:
							return true;
						default:
							switch (keyCode3)
							{
							case Keys.Left:
								return ultraComboEditor.DropDownStyle != DropDownStyle.DropDown || (ultraComboEditor.SelectionLength <= 0 && ultraComboEditor.SelectionStart == 0);
							case Keys.Up:
							case Keys.Down:
								return true;
							case Keys.Right:
								return ultraComboEditor.DropDownStyle != DropDownStyle.DropDown || (ultraComboEditor.SelectionLength <= 0 && ultraComboEditor.SelectionStart == ultraComboEditor.TextLength);
							default:
								return true;
							}
						}
					}
					else
					{
						if (iCtrl is UltraCombo)
						{
							UltraCombo ultraCombo = (UltraCombo)iCtrl;
							Keys keyCode4 = e.KeyCode;
							switch (keyCode4)
							{
							case Keys.None:
							case Keys.LButton:
							case Keys.RButton:
								return true;
							default:
								switch (keyCode4)
								{
								case Keys.Left:
									return !ultraCombo.IsDroppedDown && (ultraCombo.DropDownStyle != UltraComboStyle.DropDown || (ultraCombo.Textbox.SelectionLength <= 0 && ultraCombo.Textbox.SelectionStart == 0));
								case Keys.Up:
								case Keys.Down:
									return !ultraCombo.IsDroppedDown;
								case Keys.Right:
									return !ultraCombo.IsDroppedDown && (ultraCombo.DropDownStyle != UltraComboStyle.DropDown || (ultraCombo.Textbox.SelectionLength <= 0 && ultraCombo.Textbox.SelectionStart == ultraCombo.Textbox.TextLength));
								default:
									return true;
								}
							}
						}
						else
						{
							if (iCtrl is TextEditorControlBase)
							{
								TextEditorControlBase textEditorControlBase = (TextEditorControlBase)iCtrl;
								Keys keyCode5 = e.KeyCode;
								switch (keyCode5)
								{
								case Keys.None:
								case Keys.LButton:
								case Keys.RButton:
									return true;
								default:
									switch (keyCode5)
									{
									case Keys.Left:
										return textEditorControlBase.SelectionLength <= 0 && textEditorControlBase.SelectionStart == 0;
									case Keys.Up:
									case Keys.Down:
										return true;
									case Keys.Right:
										return textEditorControlBase.SelectionLength <= 0 && textEditorControlBase.SelectionStart == textEditorControlBase.Text.Length;
									default:
										return true;
									}
								}
							}
							else
							{
								if (iCtrl is UltraMaskedEdit)
								{
									UltraMaskedEdit ultraMaskedEdit = (UltraMaskedEdit)iCtrl;
									Keys keyCode6 = e.KeyCode;
									switch (keyCode6)
									{
									case Keys.None:
									case Keys.LButton:
									case Keys.RButton:
										return true;
									default:
										switch (keyCode6)
										{
										case Keys.Left:
											return ultraMaskedEdit.SelectionLength <= 0 && ultraMaskedEdit.SelectionStart == 0;
										case Keys.Up:
										case Keys.Down:
											return true;
										case Keys.Right:
											return ultraMaskedEdit.SelectionLength <= 0 && ultraMaskedEdit.SelectionStart == ultraMaskedEdit.Text.Length;
										default:
											return true;
										}
									}
								}
								else
								{
									if (iCtrl is UltraWinEditorMaskedControlBase)
									{
										UltraWinEditorMaskedControlBase ultraWinEditorMaskedControlBase = (UltraWinEditorMaskedControlBase)iCtrl;
										Keys keyCode7 = e.KeyCode;
										switch (keyCode7)
										{
										case Keys.None:
										case Keys.LButton:
										case Keys.RButton:
											return true;
										default:
											switch (keyCode7)
											{
											case Keys.Left:
												return ultraWinEditorMaskedControlBase.SelectionLength <= 0 && ultraWinEditorMaskedControlBase.SelectionStart == 0;
											case Keys.Up:
											case Keys.Down:
												return true;
											case Keys.Right:
												return ultraWinEditorMaskedControlBase.SelectionLength <= 0 && ultraWinEditorMaskedControlBase.SelectionStart == ultraWinEditorMaskedControlBase.Text.Length;
											default:
												return true;
											}
										}
									}
									else
									{
										if (iCtrl is UltraCalendarCombo)
										{
											UltraCalendarCombo ultraCalendarCombo = (UltraCalendarCombo)iCtrl;
											switch (e.KeyCode)
											{
											case Keys.Left:
											case Keys.Up:
											case Keys.Right:
											case Keys.Down:
												return !ultraCalendarCombo.DroppedDown;
											default:
												return true;
											}
										}
										else
										{
											if (iCtrl is ComboBox)
											{
												ComboBox comboBox = (ComboBox)iCtrl;
												Keys keyCode8 = e.KeyCode;
												switch (keyCode8)
												{
												case Keys.None:
												case Keys.LButton:
												case Keys.RButton:
													return true;
												default:
													switch (keyCode8)
													{
													case Keys.Left:
														return !comboBox.DroppedDown && ((comboBox.DropDownStyle != ComboBoxStyle.DropDown && comboBox.DropDownStyle != ComboBoxStyle.Simple) || (comboBox.SelectionLength <= 0 && comboBox.SelectionStart == 0));
													case Keys.Up:
													case Keys.Down:
														return !comboBox.DroppedDown;
													case Keys.Right:
														return !comboBox.DroppedDown && ((comboBox.DropDownStyle != ComboBoxStyle.DropDown && comboBox.DropDownStyle != ComboBoxStyle.Simple) || (comboBox.SelectionLength <= 0 && comboBox.SelectionStart == comboBox.Text.Length));
													default:
														return true;
													}
												}
											}
											else
											{
												if (iCtrl is ListBox)
												{
													return e.KeyCode != Keys.Up && e.KeyCode != Keys.Down;
												}
												if (iCtrl is UltraButton || iCtrl is UltraCheckEditor)
												{
													return true;
												}
												if (iCtrl is UltraOptionSet)
												{
													UltraOptionSet ultraOptionSet = (UltraOptionSet)iCtrl;
													switch (e.KeyCode)
													{
													case Keys.Left:
													case Keys.Up:
														if (ultraOptionSet.Items.Count > 0 && ultraOptionSet.FocusedIndex != 0)
														{
															return false;
														}
														break;
													case Keys.Right:
													case Keys.Down:
														if (ultraOptionSet.Items.Count > 0 && ultraOptionSet.FocusedIndex != ultraOptionSet.Items.Count - 1)
														{
															return false;
														}
														break;
													}
													return true;
												}
												return iCtrl is ButtonBase || iCtrl is NumericUpDown || iCtrl is UltraTabControl || (e.KeyCode == Keys.None || e.KeyCode == Keys.LButton || e.KeyCode == Keys.RButton);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void Owner_ParentChanged(object sender, EventArgs e)
		{
		}
		private void Owner_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Handled)
			{
				return;
			}
			if (base.OwnerForm == null)
			{
				return;
			}
			Form form;
			if (base.OwnerForm is Form)
			{
				form = (Form)base.OwnerForm;
			}
			else
			{
				form = ((Control)base.OwnerForm).FindForm();
			}
			if (form == null)
			{
				return;
			}
			if (sender == null)
			{
				if (form.ActiveControl == null)
				{
					return;
				}
				sender = form.ActiveControl;
			}
			if (this.CheckControl((Control)sender))
			{
				if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
				{
					Control control = (Control)sender;
					if (control.Parent is NumericUpDown)
					{
						control = control.Parent;
					}
					bool handled = false;
					if (!this.CanExit(control, e, out handled))
					{
						e.Handled = handled;
						return;
					}
					Control control2 = null;
					Control parent = control.Parent;
					if (parent is TDateEdit && parent.Parent != null)
					{
						parent = parent.Parent;
					}
					int num = 0;
					while (num < 3 && control2 == null)
					{
						switch (num)
						{
						case 1:
							if ((parent == null || (!(parent is Form) && !(parent is UltraTabPageControl))) && parent.Parent != null)
							{
								parent = parent.Parent;
							}
							break;
						case 2:
							while ((parent == null || (!(parent is Form) && !(parent is UltraTabPageControl))) && parent.Parent != null)
							{
								parent = parent.Parent;
							}
							break;
						}
						switch (e.KeyCode)
						{
						case Keys.Left:
							if (control2 == null)
							{
								if (control is UltraTabControl)
								{
									UltraTabControl ultraTabControl = (UltraTabControl)control;
									switch (ultraTabControl.TabOrientation)
									{
									case TabOrientation.Default:
									case TabOrientation.TopLeft:
									case TabOrientation.TopRight:
									case TabOrientation.BottomLeft:
									case TabOrientation.BottomRight:
										return;
									case TabOrientation.RightTop:
									case TabOrientation.RightBottom:
										if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
										{
											TLib.GetMostRightCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
										}
										break;
									}
								}
								if (control2 == null)
								{
									TLib.GetLeftCtrl(ref control2, control, parent, this.FStyleH);
									if (control2 == null)
									{
										if (parent is UltraTabPageControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)parent.Parent;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.LeftTop:
											case TabOrientation.LeftBottom:
												control2 = ultraTabControl;
												break;
											default:
												TLib.GetLeftCtrl(ref control2, ultraTabControl, form, this.FStyleH);
												break;
											}
										}
									}
									else
									{
										if (control2 != null && control2 is UltraTabControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)control2;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.LeftTop:
											case TabOrientation.LeftBottom:
												break;
											default:
												control2 = null;
												if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
												{
													TLib.GetMostRightCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
												}
												if (control2 == null)
												{
													control2 = ultraTabControl;
												}
												break;
											}
										}
									}
								}
							}
							break;
						case Keys.Up:
							if (control2 == null)
							{
								if (control is UltraTabControl)
								{
									UltraTabControl ultraTabControl = (UltraTabControl)control;
									switch (ultraTabControl.TabOrientation)
									{
									case TabOrientation.BottomLeft:
									case TabOrientation.BottomRight:
										if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
										{
											TLib.GetMostLowerCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
										}
										break;
									case TabOrientation.LeftTop:
									case TabOrientation.LeftBottom:
									case TabOrientation.RightTop:
									case TabOrientation.RightBottom:
										return;
									}
								}
								if (control2 == null)
								{
									TLib.GetUpperCtrl(ref control2, control, parent, this.FStyleV);
									if (control2 == null)
									{
										if (parent is UltraTabPageControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)parent.Parent;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.Default:
											case TabOrientation.TopLeft:
											case TabOrientation.TopRight:
												control2 = ultraTabControl;
												break;
											default:
												TLib.GetUpperCtrl(ref control2, ultraTabControl, form, this.FStyleV);
												break;
											}
										}
									}
									else
									{
										if (control2 != null && control2 is UltraTabControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)control2;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.BottomLeft:
											case TabOrientation.BottomRight:
												break;
											default:
												control2 = null;
												if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
												{
													TLib.GetMostLowerCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
												}
												if (control2 == null)
												{
													control2 = ultraTabControl;
												}
												break;
											}
										}
									}
								}
							}
							break;
						case Keys.Right:
							if (control2 == null)
							{
								if (control is UltraTabControl)
								{
									UltraTabControl ultraTabControl = (UltraTabControl)control;
									switch (ultraTabControl.TabOrientation)
									{
									case TabOrientation.Default:
									case TabOrientation.TopLeft:
									case TabOrientation.TopRight:
									case TabOrientation.BottomLeft:
									case TabOrientation.BottomRight:
										return;
									case TabOrientation.LeftTop:
									case TabOrientation.LeftBottom:
										if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
										{
											TLib.GetMostLeftCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
										}
										break;
									}
								}
								if (control2 == null)
								{
									TLib.GetRightCtrl(ref control2, control, parent, this.FStyleH);
									if (control2 == null)
									{
										if (parent is UltraTabPageControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)parent.Parent;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.RightTop:
											case TabOrientation.RightBottom:
												control2 = ultraTabControl;
												break;
											default:
												TLib.GetRightCtrl(ref control2, ultraTabControl, form, this.FStyleH);
												break;
											}
										}
									}
									else
									{
										if (control2 != null && control2 is UltraTabControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)control2;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.RightTop:
											case TabOrientation.RightBottom:
												break;
											default:
												control2 = null;
												if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
												{
													TLib.GetMostLeftCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
												}
												if (control2 == null)
												{
													control2 = ultraTabControl;
												}
												break;
											}
										}
									}
								}
							}
							break;
						case Keys.Down:
							if (control2 == null)
							{
								if (control is UltraTabControl)
								{
									UltraTabControl ultraTabControl = (UltraTabControl)control;
									switch (ultraTabControl.TabOrientation)
									{
									case TabOrientation.Default:
									case TabOrientation.TopLeft:
									case TabOrientation.TopRight:
										if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
										{
											TLib.GetMostUpperCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
										}
										break;
									case TabOrientation.LeftTop:
									case TabOrientation.LeftBottom:
									case TabOrientation.RightTop:
									case TabOrientation.RightBottom:
										return;
									}
								}
								if (control2 == null)
								{
									TLib.GetLowerCtrl(ref control2, control, parent, this.FStyleV);
									if (control2 == null)
									{
										if (parent is UltraTabPageControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)parent.Parent;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.BottomLeft:
											case TabOrientation.BottomRight:
												control2 = ultraTabControl;
												break;
											default:
												TLib.GetLowerCtrl(ref control2, ultraTabControl, form, this.FStyleV);
												break;
											}
										}
									}
									else
									{
										if (control2 != null && control2 is UltraTabControl)
										{
											UltraTabControl ultraTabControl = (UltraTabControl)control2;
											switch (ultraTabControl.TabOrientation)
											{
											case TabOrientation.Default:
											case TabOrientation.TopLeft:
											case TabOrientation.TopRight:
												break;
											default:
												control2 = null;
												if (ultraTabControl.Tabs.Count > 0 && ultraTabControl.ActiveTab != null)
												{
													TLib.GetMostUpperCtrl(ref control2, ultraTabControl.ActiveTab.TabPage);
												}
												if (control2 == null)
												{
													control2 = ultraTabControl;
												}
												break;
											}
										}
									}
								}
							}
							break;
						}
						num++;
					}
					if (this.FAlwaysEvent || control2 != null)
					{
						ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(e.Shift, e.Alt, e.Control, e.KeyCode, control, control2);
						this.OnChangeFocus(changeFocusEventArgs);
						if (changeFocusEventArgs.NextCtrl != null && changeFocusEventArgs.NextCtrl.Visible && !changeFocusEventArgs.NextCtrl.Focused)
						{
							changeFocusEventArgs.NextCtrl.Focus();
						}
						e.Handled = true;
					}
					else
					{
						if (control2 == null)
						{
							e.Handled = true;
						}
					}
				}
				Control arg_73B_0 = form.ActiveControl;
			}
		}
		private void Owner_MouseDownEx(object sender, MouseEventArgsEx e)
		{
			if (e.Handled)
			{
				return;
			}
			if (this.CheckControl((Control)sender) && this.FCatchMouse && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
			{
				if (base.OwnerForm == null)
				{
					return;
				}
				Form form;
				if (base.OwnerForm is Form)
				{
					form = (Form)base.OwnerForm;
				}
				else
				{
					form = ((Control)base.OwnerForm).FindForm();
				}
				Control control = (Control)sender;
				if (TLib.IsMouseFocusControl(control) && (TLib.GetBaseControl(control) != TLib.GetBaseControl(form.ActiveControl) || TLib.GetBaseControl(control) is TDateEdit))
				{
					if (TLib.IsReadOnly(control) || !control.CanFocus)
					{
						e.Handled = true;
						return;
					}
					bool flag = false;
					KeyEventArgs keyEventArgs;
					if (e.Button == MouseButtons.Left)
					{
						keyEventArgs = new KeyEventArgs(Keys.LButton);
					}
					else
					{
						keyEventArgs = new KeyEventArgs(Keys.RButton);
					}
					if (!this.CanExit(form.ActiveControl, keyEventArgs, out flag))
					{
						e.Handled = true;
						return;
					}
					Control control2 = form.ActiveControl;
					if (control2 is EmbeddableTextBoxWithUIPermissions && TLib.GetBaseControl(control2).Parent is TDateEdit)
					{
						control2 = TLib.GetBaseControl(control2);
					}
					ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, keyEventArgs.KeyCode, control2, control);
					this.OnChangeFocus(changeFocusEventArgs);
					if (changeFocusEventArgs.NextCtrl == null)
					{
						if (!control.Focused)
						{
							control.Focus();
						}
						e.Handled = true;
						return;
					}
					if (!changeFocusEventArgs.NextCtrl.Visible)
					{
						e.Handled = true;
						return;
					}
					if (changeFocusEventArgs.NextCtrl != null && control != changeFocusEventArgs.NextCtrl)
					{
						changeFocusEventArgs.NextCtrl.Focus();
						e.Handled = true;
					}
				}
			}
		}
		private void Owner_MouseDoubleClickEx(object sender, MouseEventArgsEx e)
		{
			if (e.Handled)
			{
				return;
			}
			if (this.CheckControl((Control)sender) && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
			{
				Control baseControl = TLib.GetBaseControl((Control)sender);
				if (TLib.IsReadOnly(baseControl))
				{
					e.Handled = true;
				}
			}
		}
		protected virtual void OnChangeFocus(ChangeFocusEventArgs e)
		{
			Control control = null;
			Control control2 = null;
			if (e.PrevCtrl != null)
			{
				control = TLib.GetBaseControl(e.PrevCtrl);
			}
			if (e.NextCtrl != null)
			{
				control2 = TLib.GetBaseControl(e.NextCtrl);
			}
			if (control != control2)
			{
				if (control is TDateEdit)
				{
					Control control3 = ((TDateEdit)control).CheckInputDataForKeyCtrl();
					if (control3 != null)
					{
						e.NextCtrl = control3;
						return;
					}
				}
				if (!this.FAlwaysEvent && control2 == null)
				{
					e.NextCtrl = null;
					return;
				}
				if (this.ChangeFocus != null)
				{
					IntPtr intPtr = IntPtr.Zero;
					bool flag = false;
					if (control != null)
					{
						intPtr = SafeNativeMethods.ImmGetContext(control.Handle);
						try
						{
							if (intPtr != IntPtr.Zero)
							{
								flag = SafeNativeMethods.ImmGetOpenStatus(intPtr);
							}
						}
						finally
						{
							SafeNativeMethods.ImmReleaseContext(control.Handle, intPtr);
						}
					}
					if (this.FAlwaysEvent || control2 != null)
					{
						Control control4 = control2;
						ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(e.ShiftKey, e.AltKey, e.ControlKey, e.Key, control, control2);
						this.ChangeFocus(this, changeFocusEventArgs);
						if (changeFocusEventArgs.NextCtrl != control4)
						{
							e.NextCtrl = changeFocusEventArgs.NextCtrl;
						}
						if (e.PrevCtrl != null && e.NextCtrl == e.PrevCtrl && flag)
						{
							intPtr = SafeNativeMethods.ImmGetContext(e.PrevCtrl.Handle);
							try
							{
								if (intPtr != IntPtr.Zero)
								{
									SafeNativeMethods.ImmSetOpenStatus(intPtr, true);
								}
							}
							finally
							{
								SafeNativeMethods.ImmReleaseContext(control.Handle, intPtr);
							}
						}
					}
				}
			}
		}
	}
}
