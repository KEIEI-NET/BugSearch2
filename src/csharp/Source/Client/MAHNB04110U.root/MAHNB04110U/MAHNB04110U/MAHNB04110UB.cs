using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����`�[�����p���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����`�[�����p�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2007.06.18</br>
	/// <br>Update Note: </br>
	/// </remarks>
	public partial class SalesSearchSetup : Form
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		public SalesSearchSetup()
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._salesSearchConstructionAcs = SalesSearchConstructionAcs.GetInstance();
			this._controlScreenSkin = new ControlScreenSkin();

			this.SetComboEditorItemIndex(this.tComboEditor_SearchSlipDateStartRange, this._salesSearchConstructionAcs.SearchSlipDateStartRangeValue, 0);
			this.SetComboEditorItemIndex(this.tComboEditor_AddUpADateStartRange, this._salesSearchConstructionAcs.AddUpADateStartRangeValue, 0);
			this.SetComboEditorItemIndex(this.tComboEditor_RegiProcDateStartRange, this._salesSearchConstructionAcs.RegiProcDateStartRangeValue, 0);
			this.SetOptionSetItemIndex(this.uOptionSet_DetailConditionOpen, this._salesSearchConstructionAcs.DetailConditionOpenValue);
			this.SetOptionSetItemIndex(this.uOptionSet_DataChangedAutoSearch, this._salesSearchConstructionAcs.DataChangedAutoSearchValue);
			this.SetOptionSetItemIndex(this.uOptionSet_ExecAutoSearch, this._salesSearchConstructionAcs.ExecAutoSearchValue);
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private SalesSearchConstructionAcs _salesSearchConstructionAcs;
		private ControlScreenSkin _controlScreenSkin;
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Method
		/// <summary>
		/// �R���{�G�f�B�^�A�C�e���C���f�b�N�X�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <param name="dataValue">�ݒ�l</param>
		/// <param name="defaultIndex">�����l</param>
		private void SetComboEditorItemIndex(TComboEditor sender, int dataValue, int defaultIndex)
		{
			int index = defaultIndex;

			for (int i = 0; i < sender.Items.Count; i++)
			{
				if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
				{
					index = i;
					break;
				}
			}

			sender.SelectedIndex = index;

			if ((index == -1) && (sender.DropDownStyle == Infragistics.Win.DropDownStyle.DropDown))
			{
				sender.Text = dataValue.ToString();
			}
		}

		/// <summary>
		/// �I�v�V�����Z�b�g�A�C�e���C���f�b�N�X�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�I�v�V�����Z�b�g</param>
		/// <param name="dataValue">�ݒ�l</param>
		private void SetOptionSetItemIndex(Infragistics.Win.UltraWinEditors.UltraOptionSet sender, int dataValue)
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
		private int GetOptionSetValue(Infragistics.Win.UltraWinEditors.UltraOptionSet sender)
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
		/// �R���{�G�f�B�^�I��l�擾����
		/// </summary>
		/// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
		/// <returns>�I��l</returns>
		private int GetComboEditorValue(TComboEditor sender)
		{
			if (sender.SelectedIndex >= 0)
			{
				return (int)sender.SelectedItem.DataValue;
			}
			else
			{
				int index = -1;

				// ���l�݂̂����͂���Ă���ꍇ�́A���͒l��value���r����B
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
				if (regex.IsMatch(sender.Text.Trim()))
				{
					int dataValue = 0;

					try
					{
						dataValue = Convert.ToInt32(sender.Text.Trim());
					}
					catch (OverflowException)
					{
						// 
					}

					for (int i = 0; i < sender.Items.Count; i++)
					{
						if ((sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue))
						{
							index = i;
							break;
						}
					}
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

				// �Y���f�[�^�����݂��Ȃ��ꍇ��0�Ƃ���B
				if (index == -1)
				{
					return 0;
				}
				else
				{
					return (int)sender.Items[index].DataValue;
				}
			}
		}

		/// <summary>
		/// ���̓f�[�^�`�F�b�N����
		/// </summary>
		/// <returns>true:�`�F�b�NOK false:�`�F�b�NNG</returns>
		private bool InputDataCheck()
		{
			bool check = true;

			return check;
		}
		# endregion

		// ===================================================================================== //
		// �e��R���|�[�l���g�C�x���g�����S
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// Form.Load �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		private void StockInputSetup_Load(object sender, EventArgs e)
		{
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.uButton_Ok.ImageList = this._imageList16;
			this.uButton_Cancel.ImageList = this._imageList16;

			this.uButton_Ok.Appearance.Image = (int)Size16_Index.DECISION;
			this.uButton_Cancel.Appearance.Image = (int)Size16_Index.BEFORE;

			this.timer_Initial.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(uButton_Ok)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		private void uButton_Ok_Click(object sender, EventArgs e)
		{
			if (!this.InputDataCheck())
			{
				this.DialogResult = DialogResult.Retry;
				return;
			}

			this._salesSearchConstructionAcs.SearchSlipDateStartRangeValue = this.GetComboEditorValue(this.tComboEditor_SearchSlipDateStartRange);
			this._salesSearchConstructionAcs.AddUpADateStartRangeValue = this.GetComboEditorValue(this.tComboEditor_AddUpADateStartRange);
			this._salesSearchConstructionAcs.RegiProcDateStartRangeValue = this.GetComboEditorValue(this.tComboEditor_RegiProcDateStartRange);

			this._salesSearchConstructionAcs.DetailConditionOpenValue = this.GetOptionSetValue(this.uOptionSet_DetailConditionOpen);
			this._salesSearchConstructionAcs.DataChangedAutoSearchValue = this.GetOptionSetValue(this.uOptionSet_DataChangedAutoSearch);
			this._salesSearchConstructionAcs.ExecAutoSearchValue = this.GetOptionSetValue(this.uOptionSet_ExecAutoSearch);

			this._salesSearchConstructionAcs.Serialize();
		}

		/// <summary>
		/// ���������^�C�}�[�N������
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_Initial_Tick(object sender, EventArgs e)
		{
			this.timer_Initial.Enabled = false;

			this.tComboEditor_SearchSlipDateStartRange.Focus();
		}

		/// <summary>
		/// �t�H�[���N���[�W���O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void StockInputSetup_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Retry)
			{
				e.Cancel = true;
			}
		}
		# endregion
	}
}