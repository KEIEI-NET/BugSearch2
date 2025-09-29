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
	/// ���o�������͉�ʁi�R���{�{�b�N�X�^�j
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o��������͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CF : Panel, IFreePrintUserControl
	{
		#region PrivateMember
		// ���R���[���o�������׃}�X�^���X�g
		private List<FrePExCndD> _frePExCndDList;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08132CF()
		{
			InitializeComponent();
		}
		#endregion

		#region IFreePrintUserControl �����o
		/// <summary>���R���[���o�������׃}�X�^���X�g</summary>
		public List<FrePExCndD> FrePExCndDList
		{
			set { _frePExCndDList = value; }
		}

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
			return true;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			try
			{
				frePprECnd.StExtraNumCode = (int)this.cmbExtraCondDtlGrpCd.Value;
			}
			catch (Exception)
			{
				frePprECnd.StExtraNumCode = 0;
			}
		}

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			// �����ݒ�
			if (_frePExCndDList != null && this.cmbExtraCondDtlGrpCd.Items.Count == 0)
			{
				this.cmbExtraCondDtlGrpCd.Items.Add(0, "�@");
				foreach (FrePExCndD frePExCndD in _frePExCndDList)
				{
					if (frePprECnd.ExtraCondDetailGrpCd == frePExCndD.ExtraCondDetailGrpCd)
						this.cmbExtraCondDtlGrpCd.Items.Add(frePExCndD.ExtraCondDetailCode, frePExCndD.ExtraCondDetailName);
				}
			}

			// �f�[�^�̐ݒ�
			this.ulExtraConditionTitle.Text = frePprECnd.ExtraConditionTitle;
			this.cmbExtraCondDtlGrpCd.Value = frePprECnd.StExtraNumCode;

			// �K�{�����̔w�i�F��ݒ�i���ʎd�l�j
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.cmbExtraCondDtlGrpCd.Appearance.BackColor = Color.FromArgb(179, 219, 231);
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
