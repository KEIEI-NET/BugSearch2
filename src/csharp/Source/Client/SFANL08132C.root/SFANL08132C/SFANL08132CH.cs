using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���o�������͉�ʁi�`�F�b�N�{�b�N�X�^�j
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o��������͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.07.05</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CH : Panel, IFreePrintUserControl
	{
		#region PrivateMember
		// ���R���[���o�������׃}�X�^���X�g
		private List<FrePExCndD> _frePExCndDList;
		// �T�C�Y�ύX���t���O
		private bool _isNowSizeChange;
		#endregion

		#region Const
		// �`�F�b�N�{�b�N�XLocation��l
		private const int ctCheckEditorDefTop	= 6;
		private const int ctCheckEditorDefLeft	= 6;
		// �`�F�b�N����
		private const int ctCheckAreaWidth	= 30;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08132CH()
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
			frePprECnd.CheckItemCode1	= -1;
			frePprECnd.CheckItemCode2	= -1;
			frePprECnd.CheckItemCode3	= -1;
			frePprECnd.CheckItemCode4	= -1;
			frePprECnd.CheckItemCode5	= -1;
			frePprECnd.CheckItemCode6	= -1;
			frePprECnd.CheckItemCode7	= -1;
			frePprECnd.CheckItemCode8	= -1;
			frePprECnd.CheckItemCode9	= -1;
			frePprECnd.CheckItemCode10	= -1;

			foreach (Control control in this.ugbCheckBoxArea.Controls)
			{
				if (control is UltraCheckEditor)
				{
					UltraCheckEditor uceItem = (UltraCheckEditor)control;
					string propertyName = "CheckItemCode" + uceItem.TabIndex;
					PropertyInfo propertyInfo = typeof(FrePprECnd).GetProperty(propertyName);

					int extraCondDetailCode = -1;
					if (uceItem.Tag != null)
						int.TryParse(uceItem.Tag.ToString(), out extraCondDetailCode);

					if (propertyInfo != null && uceItem.Checked)
						propertyInfo.SetValue(frePprECnd, extraCondDetailCode, null);
					else
						propertyInfo.SetValue(frePprECnd, -1, null);
				}
			}
		}

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			this.ulExtraConditionTitle.Text = frePprECnd.ExtraConditionTitle;

			if (_frePExCndDList != null)
			{
				List<FrePExCndD> getFrePExCndDList
					= _frePExCndDList.FindAll(
						delegate(FrePExCndD frePExCndD)
						{
							if (frePExCndD.ExtraCondDetailGrpCd == frePprECnd.ExtraCondDetailGrpCd)
								return true;
							else
								return false;
						}
					);

				for (int ix = 1 ; ix <= getFrePExCndDList.Count ; ix++)
				{
					FrePExCndD frePExCndD = getFrePExCndDList[ix - 1];

					UltraCheckEditor uceItem = new UltraCheckEditor();
					uceItem.Style		= EditCheckStyle.Check;
					uceItem.Tag			= frePExCndD.ExtraCondDetailCode;
					uceItem.Text		= frePExCndD.ExtraCondDetailName;
					uceItem.Font		= this.Font;
					uceItem.TabIndex	= ix;
					uceItem.Width		= FrePrtSettingController.GetStringWidth(uceItem) + ctCheckAreaWidth;

					// �`�F�b�N�f�[�^���擾
					int checkItemCode = -1;
					string propertyName = "CheckItemCode" + ix;
					PropertyInfo propertyInfo = typeof(FrePprECnd).GetProperty(propertyName);
					if (propertyInfo != null) checkItemCode = (int)propertyInfo.GetValue(frePprECnd, null);
					if (checkItemCode >= 0)
						uceItem.Checked = true;
					else
						uceItem.Checked = false;
					
					this.ugbCheckBoxArea.Controls.Add(uceItem);
				}

				LayOutCheckEditor();
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �`�F�b�N�G�f�B�^�[�z�u����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���[�v�{�b�N�X�Ɋ܂܂��`�F�b�N�{�b�N�X��</br>
		/// <br>			: ��ʓ��Ɏ��܂�悤�ɔz�u���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void LayOutCheckEditor()
		{
			int defHeight = this.ugbCheckBoxArea.Height;

			Control prevControl = null;
			int itemMaxHeight = 0;
			foreach (Control control in this.ugbCheckBoxArea.Controls)
			{
				if (control is UltraCheckEditor)
				{
					UltraCheckEditor uceItem = (UltraCheckEditor)control;
					if (prevControl == null)
					{
						uceItem.Location	= new Point(ctCheckEditorDefLeft, ctCheckEditorDefTop);
					}
					else
					{
						int startLeft = prevControl.Left + prevControl.Width;
						if (startLeft + uceItem.Width < this.ugbCheckBoxArea.Width)
						{
							uceItem.Left	= startLeft;
							uceItem.Top		= prevControl.Top;
						}
						else
						{
							uceItem.Left	= ctCheckEditorDefLeft;
							uceItem.Top		= prevControl.Top + prevControl.Height;
						}
					}
					prevControl = uceItem;
					itemMaxHeight = Math.Max(itemMaxHeight, uceItem.Top + uceItem.Height);
				}
			}

			_isNowSizeChange = true;
			try
			{
				// �O���[�vBOX�̃��C���ɏd�Ȃ��ď�����ׁA������
				itemMaxHeight += 2;
				// �T�C�Y����
				if (defHeight > itemMaxHeight)
					this.Height -= defHeight - itemMaxHeight;
				else
					this.Height += itemMaxHeight - defHeight;
			}
			finally
			{
				_isNowSizeChange = false;
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
		private void ugbCheckBoxArea_SizeChanged(object sender, EventArgs e)
		{
			if (!_isNowSizeChange)
				LayOutCheckEditor();
		}

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
