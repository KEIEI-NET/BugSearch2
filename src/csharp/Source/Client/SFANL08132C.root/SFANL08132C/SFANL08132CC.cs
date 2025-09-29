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
	/// ���o�������͉�ʁi�����^�j
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o��������͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CC : Panel, IFreePrintUserControl
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08132CC()
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

			string startCode	= this.tedStExtraCharCode.Text;
			string endCode		= this.tedEdExtraCharCode.Text;

			// �K�{���ڃ`�F�b�N
			if (isNecessaryExtraCondCheck)
			{
				if (this.tedEdExtraCharCode.Visible)
				{
					if (string.IsNullOrEmpty(startCode) && string.IsNullOrEmpty(endCode))
					{
						message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
						control = this.tedStExtraCharCode;
						return false;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(startCode))
					{
						message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
						control = this.tedStExtraCharCode;
						return false;
					}
				}
			}

			// �召�`�F�b�N
			if (this.tedEdExtraCharCode.Visible)
			{
				if (!startCode.Equals(string.Empty) && !endCode.Equals(string.Empty))
				{
					if (string.Compare(startCode, endCode) > 0)
					{
						message = this.ulExtraConditionTitle.Text + "�͈͎̔w�肪�s���ł��B";
						control = this.tedStExtraCharCode;
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
		/// <returns>�X�e�[�^�X</returns>
		public void GetFrePprECndInfo(ref Broadleaf.Application.UIData.FrePprECnd frePprECnd)
		{
			frePprECnd.StExtraCharCode = this.tedStExtraCharCode.Text;
			if (this.tedEdExtraCharCode.Visible)
				frePprECnd.EdExtraCharCode = this.tedEdExtraCharCode.Text;
			else
				frePprECnd.EdExtraCharCode = string.Empty;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// �f�[�^�̐ݒ�
			this.ulExtraConditionTitle.Text			= frePprECnd.ExtraConditionTitle;
			this.tedStExtraCharCode.Text			= frePprECnd.StExtraCharCode;
			this.tedStExtraCharCode.ExtEdit.Column	= frePprECnd.InputCharCnt;
			this.tedEdExtraCharCode.Text			= frePprECnd.EdExtraCharCode;
			this.tedEdExtraCharCode.ExtEdit.Column	= frePprECnd.InputCharCnt;
			// ���o�����敪(2:�����^�i���p�j,3:�����^�i�S�p�j)
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 2:
				{
					this.tedStExtraCharCode.ImeMode			= ImeMode.Off;
					this.tedStExtraCharCode.CharacterCasing	= CharacterCasing.Upper;
					this.tedStExtraCharCode.ExtEdit.EnableChars.Word = false;
					this.tedEdExtraCharCode.ImeMode			= ImeMode.Off;
					this.tedEdExtraCharCode.CharacterCasing	= CharacterCasing.Upper;
					this.tedEdExtraCharCode.ExtEdit.EnableChars.Word = false;
					break;
				}
				case 3:
				{
					this.tedStExtraCharCode.ImeMode			= ImeMode.Katakana;
					this.tedStExtraCharCode.CharacterCasing	= CharacterCasing.Normal;
					this.tedStExtraCharCode.ExtEdit.EnableChars.Word = true;
					this.tedEdExtraCharCode.ImeMode			= ImeMode.Katakana;
					this.tedEdExtraCharCode.CharacterCasing	= CharacterCasing.Normal;
					this.tedEdExtraCharCode.ExtEdit.EnableChars.Word = true;
					break;
				}
			}

			// ���o�����^�C�v(1:�͈�)�ȊO�̎��͏I���������\��
			if (frePprECnd.ExtraConditionTypeCd != 1)
			{
				this.ulRange.Visible			= false;
				this.tedEdExtraCharCode.Visible	= false;
				this.Height						= 70;
			}

			// �K�{�����̔w�i�F��ݒ�i���ʎd�l�j
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.tedStExtraCharCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
				this.tedEdExtraCharCode.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
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
