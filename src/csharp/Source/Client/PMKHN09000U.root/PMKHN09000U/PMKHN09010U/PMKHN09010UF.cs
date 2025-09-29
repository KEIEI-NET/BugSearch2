//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�}�X�^
// �v���O�����T�v   �F���Ӑ�̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2008/04/30     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/18     �C�����e�FMantis�y13400�A13455�z�Ή�
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="getDataType"></param>
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
            // DEL 2009/06/18 ------>>>
            //int index = 0;
            //string selectText = sender.Text.Trim();

            //for (int i = 0; i < sender.Items.Count; i++)
            //{
            //    if (sender.Items[i].DisplayText.Trim() == selectText)
            //    {
            //        index = (int)sender.Items[i].DataValue;
            //        break;
            //    }
            //}

            //return index;
            // DEL 2009/06/18 ------<<<

            // ADD 2009/06/18 ------>>>
            // �\���e�L�X�g��r�ł͂Ȃ��A�I���A�C�e���̒l��Ԃ�
            if (sender.SelectedIndex >= 0)
            {
                return (int)sender.SelectedItem.DataValue;
            }
            
            return 0;
            // ADD 2009/06/18 ------<<<
        }

		/// <summary>
		/// �R���{�G�f�B�^�A�C�e���ǉ�����
		/// </summary>
		/// <param name="sender">�ΏۃR���{�G�f�B�^</param>
		/// <param name="dataValue">�A�C�e���f�[�^</param>
		/// <param name="displayText">�A�C�e���\���e�L�X�g</param>
		/// <param name="tag">�A�C�e���^�O</param>
		internal static void AddComboEditorItem(TComboEditor sender, object dataValue, string displayText, object tag)
		{
			Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
			item.DataValue = dataValue;
			item.DisplayText = displayText;
			item.Tag = tag;

			sender.Items.Add(item);
		}

		/// <summary>
		/// �I�v�V�����Z�b�g�A�C�e���C���f�b�N�X�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�I�v�V�����Z�b�g</param>
		/// <param name="dataValue">�ݒ�l</param>
		internal static void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
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

			sender.CheckedIndex = index;
		}

		/// <summary>
		/// �I�v�V�����Z�b�g�I��l�擾����
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�I�v�V�����Z�b�g</param>
		/// <returns>�I��l</returns>
		internal static int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
		{
			if (sender.CheckedIndex >= 0)
			{
				return (int)sender.CheckedItem.DataValue;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// �`�F�b�N�G�f�B�^�`�F�b�N���l�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�`�F�b�N�G�f�B�^</param>
		/// <param name="checkedValue">�`�F�b�N�L�莞�ݒ�l</param>
		/// <param name="unCheckedValue">�`�F�b�N�������ݒ�l</param>
		/// <returns>�ݒ�l</returns>
		internal static int GetCheckEditorValue(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int unCheckedValue)
		{
			if (sender.Checked)
			{
				return checkedValue;
			}
			else
			{
				return unCheckedValue;
			}
		}

		/// <summary>
		/// �`�F�b�N�G�f�B�^�`�F�b�N�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�`�F�b�N�G�f�B�^</param>
		/// <param name="checkedValue">�`�F�b�N��t����Ă̒l</param>
		/// <param name="dataValue">�ݒ�l</param>
		internal static void SetCheckEditorChecked(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int dataValue)
		{
			if (checkedValue == dataValue)
			{
				sender.Checked = true;
			}
			else
			{
				sender.Checked = false;
			}
		}
	}
}
