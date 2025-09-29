using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���o�������͉�ʁi���t�^�j
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o��������͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CD : Panel, IFreePrintUserControl
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08132CD()
		{
			InitializeComponent();
		}
		#endregion

		#region IFreePrintUserControl �����o
		/// <summary>���R���[���o�������׃}�X�^���X�g</summary>
		public List<FrePExCndD> FrePExCndDList { set { } }

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="control">�s�����̃R���g���[��</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		public bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			control = null;

			int startDate	= this.dateStartExtraDate.GetLongDate();
			int endDate		= this.dateEndExtraDate.GetLongDate();

			// �K�{���ڃ`�F�b�N
			if (isNecessaryExtraCondCheck)
			{
				if (this.dateEndExtraDate.Visible)
				{
					if ((startDate == 10101 || startDate == 0) &&
						(endDate == 10101 || endDate == 0))
					{
						message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
						control = this.dateStartExtraDate;
						return false;
					}
				}
				else
				{
					if (startDate == 0 || startDate == 10101)
					{
						message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
						control = this.dateStartExtraDate;
						return false;
					}
				}
			}

			if (this.dateEndExtraDate.Visible)
			{
				if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
				{
					message = this.ulExtraConditionTitle.Text + "�i�J�n���j�̓��͂��s���ł��B";
					control = this.dateStartExtraDate;
					return false;
				}

				if (endDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(endDate)))
				{
					message = this.ulExtraConditionTitle.Text + "�i�I�����j�̓��͂��s���ł��B";
					control = this.dateEndExtraDate;
					return false;
				}

				// �召�`�F�b�N
				if (startDate > 10101 && endDate > 10101)
				{
					if (startDate > endDate)
					{
						message = this.ulExtraConditionTitle.Text + "�͈͎̔w�肪�s���ł��B";
						control = this.dateStartExtraDate;
						return false;
					}
				}
			}
			else
			{
				if (startDate != 0 && !TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(startDate)))
				{
					message = this.ulExtraConditionTitle.Text + "�̓��͂��s���ł��B";
					control = this.dateStartExtraDate;
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			frePprECnd.StartExtraDate = this.dateStartExtraDate.GetLongDate();
			if (this.dateEndExtraDate.Visible)
				frePprECnd.EndExtraDate = this.dateEndExtraDate.GetLongDate();
			else
				frePprECnd.EndExtraDate = 0;

			if (this.uceStaSystemDateDiv.Checked) frePprECnd.StExtraNumCode = 1;
			else frePprECnd.StExtraNumCode = 0;

			if (this.uceEndSystemDateDiv.Checked) frePprECnd.EdExtraNumCode = 1;
			else frePprECnd.EdExtraNumCode = 0;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// �f�[�^�̐ݒ�
			this.ulExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
			if (frePprECnd.StExtraNumCode == 0)
			{
				this.uceStaSystemDateDiv.Checked = false;
				this.dateStartExtraDate.SetLongDate(frePprECnd.StartExtraDate);
			}
			else
			{
				this.uceStaSystemDateDiv.Checked = true;
				this.dateStartExtraDate.SetToday();
			}
			if (frePprECnd.EdExtraNumCode == 0)
			{
				this.uceEndSystemDateDiv.Checked = false;
				this.dateEndExtraDate.SetLongDate(frePprECnd.EndExtraDate);
			}
			else
			{
				this.uceEndSystemDateDiv.Checked = true;
				this.dateEndExtraDate.SetToday();
			}

			// ���o�����^�C�v(0:��v)�̎��͏I���������\��
			if (frePprECnd.ExtraConditionTypeCd == 0)
			{
				this.ulRange.Visible				= false;
				this.dateEndExtraDate.Visible		= false;
				this.uceEndSystemDateDiv.Visible	= false;
				this.Height							= 81;
			}

			// �K�{�����̔w�i�F��ݒ�i���ʎd�l�j
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.dateStartExtraDate.EditAppearance.BackColor	= Color.FromArgb(179, 219, 231);
				this.dateEndExtraDate.EditAppearance.BackColor		= Color.FromArgb(179, 219, 231);
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// SizeChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: Size �v���p�e�B�̒l���R���g���[���ŕύX���ꂽ�Ƃ���</br>
		/// <br>			: ��������C�x���g�ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ulExtraConditionTitle_SizeChanged(object sender, EventArgs e)
		{
			FrePrtSettingController.AdjustControlFontSize(this.ulExtraConditionTitle, 11);
		}

		/// <summary>
		/// TextChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: TextChanged �v���p�e�B�̒l���R���g���[���ŕύX���ꂽ�Ƃ���</br>
		/// <br>			: ��������C�x���g�ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ulExtraConditionTitle_TextChanged(object sender, EventArgs e)
		{
			FrePrtSettingController.AdjustControlFontSize(this.ulExtraConditionTitle, 11);
		}

		/// <summary>
		/// CheckedChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: Checked �v���p�e�B�̒l���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void uceStaSystemDateDiv_CheckedChanged(object sender, EventArgs e)
		{
			this.dateStartExtraDate.ReadOnly = this.uceStaSystemDateDiv.Checked;
			if (this.uceStaSystemDateDiv.Checked) this.dateStartExtraDate.SetToday();
		}

		/// <summary>
		/// CheckedChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: Checked �v���p�e�B�̒l���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void uceEndSystemDateDiv_CheckedChanged(object sender, EventArgs e)
		{
			this.dateEndExtraDate.ReadOnly = this.uceEndSystemDateDiv.Checked;
			if (this.uceEndSystemDateDiv.Checked) this.dateEndExtraDate.SetToday();
		}
		#endregion
	}
}
