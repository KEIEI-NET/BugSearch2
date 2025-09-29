using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���o�������͉�ʁi���l�^�j
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o��������͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CB : Panel, IFreePrintUserControl
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08132CB()
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
		/// <param name="control">�s���ӏ��̃R���g���[��</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		public bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			control = null;

			long startCode	= (long)this.nedStExtraNumCode.GetValue();
			long endCode	= (long)this.nedEdExtraNumCode.GetValue();

			// �K�{���ڃ`�F�b�N
			if (isNecessaryExtraCondCheck)
			{
				if (this.nedEdExtraNumCode.Visible)
				{
					if (startCode == 0 && endCode == 0)
					{
						message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
						control = this.nedStExtraNumCode;
						return false;
					}
				}
				else
				{
					if (startCode == 0)
					{
						message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
						control = this.nedStExtraNumCode;
						return false;
					}
				}
			}

			// �召�`�F�b�N
			if (this.nedEdExtraNumCode.Visible)
			{
				if (startCode != 0 && endCode != 0)
				{
					if (startCode > endCode)
					{
						message = this.ulExtraConditionTitle.Text + "�͈͎̔w�肪�s���ł��B";
						control = this.nedStExtraNumCode;
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			frePprECnd.StExtraNumCode = (long)this.nedStExtraNumCode.GetValue();
			if (this.nedEdExtraNumCode.Visible)
				frePprECnd.EdExtraNumCode = (long)this.nedEdExtraNumCode.GetValue();
			else
				frePprECnd.EdExtraNumCode = 0;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// �f�[�^�̐ݒ�
			this.ulExtraConditionTitle.Text			= frePprECnd.ExtraConditionTitle;
			this.nedStExtraNumCode.SetValue(frePprECnd.StExtraNumCode);
			this.nedStExtraNumCode.ExtEdit.Column	= frePprECnd.InputCharCnt;
			this.nedEdExtraNumCode.SetValue(frePprECnd.EdExtraNumCode);
			this.nedEdExtraNumCode.ExtEdit.Column	= frePprECnd.InputCharCnt;

			// ���o�����^�C�v(0:��v)�̎��͏I���������\��
			if (frePprECnd.ExtraConditionTypeCd == 0)
			{
				this.ulRange.Visible			= false;
				this.nedEdExtraNumCode.Visible	= false;
				this.Height						= 70;
			}

			// �K�{�����̔w�i�F��ݒ�i���ʎd�l�j
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.nedStExtraNumCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
				this.nedEdExtraNumCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
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
		#endregion
	}
}
