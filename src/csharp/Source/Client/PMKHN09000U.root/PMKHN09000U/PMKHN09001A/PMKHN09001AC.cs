using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

using Broadleaf.Application.Remoting.ParamData; // 2010/07/06 Add
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ��ʗp���_���R���g���[���N���X
	/// </summary>
	/// <br>Note       : ���Ӑ��ʗp�ɋ��_�����R���g���[������N���X�ł��B</br>
	/// <br>Programer  : 980076  �Ȓ�  ����Y</br>
	/// <br>Date       : 2006.06.12</br>
	/// <br>Update Note: </br>
	/// <br>2006.06.12 men �V�K�쐬</br>
    /// <br>UpdateNote  : 2010/07/06 30517 �Ė� �x�� QR�R�[�h�g�у��[���Ή�</br>
    public class CustomerSectionInfoControl
	{
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ���O�C�����_�R�[�h
		private static SecInfoAcs _secInfoAcs;													// ���_�A�N�Z�X�N���X
		private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		private const string SECTIONCODE_ALL = "000000";
		private const string SECTIONNAME_ALL = "�S��";

		/// <summary>
		/// ���_�I�v�V���������`�F�b�N�v���p�e�B
		/// </summary>
		/// <returns>true:���� false:������</returns>
		public static bool IsSectionOptionIntroduce
		{
			get
			{
				// ���_�I�v�V�����`�F�b�N
				if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// �{�Ћ@�\�^���_�@�\�`�F�b�N����
		/// </summary>
		/// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
		public bool IsMainOfficeFunc()
		{
			bool isMainOfficeFunc = false;

			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ���O�C���S�����_���̎擾
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet != null)
			{
				// �{�Ћ@�\���H
				if (secInfoSet.MainOfficeFuncFlag == 1)
				{
					isMainOfficeFunc = true;
				}
			}
			else
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}

			return isMainOfficeFunc;
		}

		/// <summary>
		/// ���_���`�F�b�N����
		/// </summary>
		public void CheckSectionInfo()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ���O�C���S�����_���̎擾
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^���X�g�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�G�f�B�^</param>
		/// <param name="isAllSection">�S�Аݒ�t���O</param>
		public void SetSectionComboEditor(ref TComboEditor sender, bool isAllSection)
		{
			Infragistics.Win.ValueList valueList;
			this.SetSectionComboEditor(out valueList, isAllSection);

			if (valueList != null)
			{
				for (int i = 0; i < valueList.ValueListItems.Count; i++)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //sender.Items.Add(valueList.ValueListItems[i]);

                    Infragistics.Win.ValueListItem vlItem = new Infragistics.Win.ValueListItem();
                    vlItem.Tag = valueList.ValueListItems[i].Tag;
                    vlItem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlItem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				}

				sender.MaxDropDownItems = valueList.ValueListItems.Count;

				if (this.IsMainOfficeFunc())
				{
					sender.ReadOnly = false;
				}
				else
				{
					sender.ReadOnly = true;
				}
			}
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^���X�g�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
		/// <param name="isAllSection">�S�Аݒ�t���O</param>
		public void SetSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool isAllSection)
		{
			Infragistics.Win.ValueList valueList;
			this.SetSectionComboEditor(out valueList, isAllSection);

			if (valueList != null)
			{
				sender.ValueList = valueList;
				sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

				if (this.IsMainOfficeFunc())
				{
					sender.SharedProps.Enabled = true;
				}
				else
				{
					sender.SharedProps.Enabled = false;
				}
			}
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^���X�g�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
		/// <param name="isAllSection">�S�Аݒ�t���O</param>
		public void SetSectionComboEditor(out Infragistics.Win.ValueList sender, bool isAllSection)
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			sender = new Infragistics.Win.ValueList();

			// ���O�C���S�����_���̎擾
			SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

			if (secInfoSet != null)
			{
				if (isAllSection)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
					secInfoItem.DataValue = SECTIONCODE_ALL;
					secInfoItem.DisplayText = SECTIONNAME_ALL;
					sender.ValueListItems.Add(secInfoItem);
				}

				// ���_��񃊃X�g�̎擾
				if ((_secInfoAcs.SecInfoSetList != null) && (_secInfoAcs.SecInfoSetList.Length > 0))
				{
					foreach (SecInfoSet setSecInfoSet in _secInfoAcs.SecInfoSetList)
					{
						Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
						secInfoItem.DataValue = setSecInfoSet.SectionCode;
						secInfoItem.DisplayText = setSecInfoSet.SectionGuideNm;
						sender.ValueListItems.Add(secInfoItem);
					}
				}
			}
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^�I��l�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�G�f�B�^</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
		public bool SetSectionComboEditorValue(TComboEditor sender, string sectionCode)
		{
			bool isSetting = false;

			if (sender.Items.Count > 0)
			{
				// 1�̋��_�����Ȃ��ꍇ�͐擪��I��
				if (sender.Items.Count == 1)
				{
					sender.SelectedIndex = 0;
					isSetting = true;
				}
				else
				{
					for (int i = 0; i < sender.Items.Count; i++)
					{
						if (sender.Items[i].DataValue.ToString().Trim() == sectionCode.Trim())
						{
							sender.SelectedIndex = i;
							isSetting = true;
							break;
						}
					}
				}

				if (!isSetting)
				{
					for (int i = 0; i < sender.Items.Count; i++)
					{
						if (sender.Items[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim())
						{
							sender.SelectedIndex = i;
							isSetting = true;
							break;
						}
					}
				}
			}

			return isSetting;
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^�I��l�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
		public bool SetSectionComboEditorValue(Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode)
		{
			bool isSetting = false;

			if (sender.ValueList.ValueListItems.Count > 0)
			{
				sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

				// 1�̋��_�����Ȃ��ꍇ�͐擪��I��
				if (sender.ValueList.ValueListItems.Count == 1)
				{
					sender.SelectedIndex = 0;
					isSetting = true;
				}
				else
				{
					for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
					{
						if (sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == sectionCode.Trim())
						{
							sender.Value = sectionCode;
							isSetting = true;
							break;
						}
					}
				}

				if (!isSetting)
				{
					for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
					{
						if (sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim())
						{
							sender.Value = this._loginSectionCode;
							isSetting = true;
							break;
						}
					}
				}
			}

			return isSetting;
		}

        // 2010/07/06 Add >>>
        /// <summary>
        /// �g�у��[���I�v�V���������`�F�b�N�v���p�e�B
        /// </summary>
        /// <returns>true:���� false:������</returns>
        public static bool IsQRMailOptionIntroduce
        {
			get
			{
				// �g�у��[���I�v�V�����`�F�b�N
                if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_QRMail) == PurchaseStatus.Contract)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
        }
        // 2010/07/06 Add <<<
	}
}
