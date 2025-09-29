using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Reflection;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �R���{�G�f�B�^�f�[�^�擾�^�C�v
	/// </summary>
	internal enum ComboEditorGetDataType : int
	{
		VALUE = 0,
		TAG = 1
	}

    /// <summary>
    /// �I�y���[�V�����R�[�h
    /// </summary>
    internal enum OperationCode : int
    {
        /// <summary>�C��</summary>
        Revision = 10,
        /// <summary>�폜</summary>
        Delete = 11,
        /// <summary>�P���ύX</summary>
        UnitPriceChange = 12,
        /// <summary>���z�ύX</summary>
        PriceChange = 13,
        /// <summary>�ԓ`���s</summary>
        RedSlip = 14
    }

	internal class ComboEditorItemControl
	{
		/// <summary>
		/// �R���{�G�f�B�^�A�C�e���C���f�b�N�X�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <param name="dataValue">�ݒ�l</param>
		/// <param name="nonDataClear">�f�[�^�������N���A</param>
		internal static bool SetComboEditorItemIndex(TComboEditor sender, int dataValue, bool nonDataClear)
		{
			int index = -1;

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.SelectedIndex = index;

			if (index == -1)
			{
				if (nonDataClear)
				{
					sender.Text = "";
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// �R���{�G�f�B�^�I���A�C�e���e�L�X�g�擾����
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <param name="dataValue">�ݒ�l</param>
		/// <returns></returns>
		internal static string GetComboEditorText(TComboEditor sender, int dataValue)
		{
			int index = -1;
			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			if (index == -1)
			{
				return "";
			}
			else
			{
				return sender.Items[index].DisplayText.Trim();
			}
		}

		/// <summary>
		/// �R���{�G�f�B�^�I��l�擾����
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <returns>�I��l</returns>
		internal static int GetComboEditorValue(TComboEditor sender, ComboEditorGetDataType getDataType)
		{
			int index = -1;

			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
			if (regex.IsMatch(sender.Text.Trim()))
			{
				// ���l�݂̂����͂���Ă���ꍇ�́A���͒l��Tag���r����B
				int dataValue = 0;

				try
				{
					dataValue = Convert.ToInt32(sender.Text.Trim());
				}
				catch (OverflowException)
				{
					// 
				}

				switch (getDataType)
				{
					case ComboEditorGetDataType.TAG:
					{
						for (int i = 0; i < sender.Items.Count; i++)
						{
							if ((sender.Items[i].Tag is Int32) && ((Int32)sender.Items[i].Tag == dataValue))
							{
								index = i;
								break;
							}
						}

						break;
					}
					case ComboEditorGetDataType.VALUE:
					{
						for (int i = 0; i < sender.Items.Count; i++)
						{
							if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
							{
								index = i;
								break;
							}
						}

						break;
					}
				}
			}
			else
			{
				// �R���{�G�f�B�^�I��l�擾�����i�e�L�X�g����j
				int selectedIndex = GetComboEditorValueFromText(sender);
				return selectedIndex;
			}

			// ��L�̔�r�ŊY���f�[�^�����݂��Ȃ������ꍇ�́A���͒l��DisplayText���r����B
			if (index == -1)
			{
				string selectText = sender.Text.Trim();

				for (int i = 0; i < sender.Items.Count; i++)
				{
					if (sender.Items[i].DisplayText.Trim() == selectText)
					{
						index = i;
						break;
					}
				}
			}

			// �Y���f�[�^�����݂��Ȃ��ꍇ��-1�Ƃ���B
			if (index == -1)
			{
				return -1;
			}
			else
			{
				return (int)sender.Items[index].DataValue;
			}
		}

		/// <summary>
		/// �R���{�G�f�B�^�I��l�擾�����i�e�L�X�g����j
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <returns>�I��l</returns>
		internal static int GetComboEditorValueFromText(TComboEditor sender)
		{
			int index = -1;
			string selectText = sender.Text.Trim();

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if (sender.Items[i].DisplayText.Trim() == selectText)
				{
					index = (int)sender.Items[i].DataValue;
					break;
				}
			}

			return index;
		}

	}

	/// <summary>
	/// �R���|�[�l���g�ꊇ����
	/// </summary>
	internal class ComponentBlanketControl
	{
		/// <summary>
		/// BeginUpdate�ꊇ���s
		/// </summary>
		/// <param name="?"></param>
		internal static void BeginUpdate( List<Control> controlList )
		{
			foreach (Control target in controlList)
			{
				MethodInfo method = target.GetType().GetMethod("BeginUpdate",new Type[0]);

				if (method != null)
				{
					method.Invoke(target, null);
				}
			}
		}

		/// <summary>
		/// EndUpdate�ꊇ���s
		/// </summary>
		/// <param name="?"></param>
		internal static void EndUpdate( List<Control> controlList )
		{
			foreach (Control target in controlList)
			{
				MethodInfo method = target.GetType().GetMethod("EndUpdate",new Type[0]);

				if (method != null)
				{
					method.Invoke(target, null);
				}
			}
		}

		/// <summary>
		/// �ꊇ�N���A
		/// </summary>
		/// <param name="?"></param>
		internal static void Clear( List<Control> controlList )
		{
			foreach (Control target in controlList)
			{
				if (target is TEdit)
				{
					( (TEdit)target ).Text = "";
				}
				else if (target is TNedit)
				{
					( (TNedit)target ).SetValue(0);
				}
				else if (target is TDateEdit)
				{
					( (TDateEdit)target ).SetDateTime(DateTime.MinValue);
				}
				else if (target is Infragistics.Win.Misc.UltraLabel)
				{
					( (Infragistics.Win.Misc.UltraLabel)target ).Text = "";
				}
				else if (target is TComboEditor)
				{
					( (TComboEditor)target ).SelectedIndex = -1;
				}

			}
		}

		/// <summary>
		/// Enable�v���p�e�B�ꊇ����
		/// </summary>
		/// <param name="?"></param>
		internal static void SetEnabled( List<Control> controlList ,bool enabled)
		{
			foreach (Control target in controlList)
			{
				PropertyInfo property = target.GetType().GetProperty("Enabled", typeof(bool));

				if (property != null)
				{
					property.SetValue(target, enabled, null);
				}
			}
		}
	}
}
