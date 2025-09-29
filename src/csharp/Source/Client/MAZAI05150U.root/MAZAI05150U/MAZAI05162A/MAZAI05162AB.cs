using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	public partial class InventoryUpdateAcs
	{
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ���O�C�����_�R�[�h
		private string _ownSectionCode = "";
        
        private static SecInfoAcs _secInfoAcs;													// ���_�A�N�Z�X�N���X
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		internal const string SECTIONCODE_ALL = "000000";
		private const string SECTIONNAME_ALL = "�S��";
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/


        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
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
		/// ���_����A�N�Z�X�N���X�C���X�^���X������
		/// </summary>
		internal void CreateSecInfoAcs(ArrayList secInfoSetWorkArrayList, ArrayList secCtrlSetWorkArrayList, ArrayList companyNmWorkArrayList)
		{
			if ((secInfoSetWorkArrayList == null) || (secCtrlSetWorkArrayList == null) || (companyNmWorkArrayList == null))
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}

			SecInfoAcs.SetSecInfo(secInfoSetWorkArrayList, secCtrlSetWorkArrayList, companyNmWorkArrayList);

			this.CreateSecInfoAcs();
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// ���_����A�N�Z�X�N���X�C���X�^���X������
		/// </summary>
		internal void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs();
			}

			// ���O�C���S�����_���̎擾
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���_�ݒ�}�X�^�z��v���p�e�B
		/// </summary>
		internal SecInfoSet[] SecInfoSetArray
		{
			get
			{
				// ���_����A�N�Z�X�N���X�C���X�^���X������
				this.CreateSecInfoAcs();

				return _secInfoAcs.SecInfoSetList;
			}
        }
        
		/// <summary>
		/// �����_�R�[�h�v���p�e�B
		/// </summary>
		public string OwnSectionCode
		{
			get
			{
				if (this._ownSectionCode == "")
				{
					return this.GetOwnSectionCode();
				}
				else
				{
					return this._ownSectionCode;
				}
			}
		}
        
        /// <summary>
		/// �����_�R�[�h�擾����
		/// </summary>
		/// <returns>�����_�R�[�h</returns>
		private string GetOwnSectionCode()
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			// �����_�̎擾
			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
			if (secInfoSet != null)
			{
				// �����_�R�[�h�̕ۑ�
				this._ownSectionCode = secInfoSet.SectionCode;
			}

			return this._ownSectionCode;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region DEL 2008.12.25 [9572]
        ///// <summary>
        ///// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        ///// </summary>
        ///// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        //public bool IsMainOfficeFunc()
        //{
        //    bool isMainOfficeFunc = false;

        //    // ���_����A�N�Z�X�N���X�C���X�^���X������
        //    this.CreateSecInfoAcs();

        //    // ���O�C���S�����_���̎擾
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        // �{�Ћ@�\���H
        //        if (secInfoSet.MainOfficeFuncFlag == 1)
        //        {
        //            isMainOfficeFunc = true;
        //        }
        //    }
        //    else
        //    {
        //        throw new ApplicationException(MESSAGE_NONOWNSECTION);
        //    }

        //    return isMainOfficeFunc;
        //}
        #endregion // DEL 2008.12.25 [9572]

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
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
                    // 2008.03.26 �C�� >>>>>>>>>>>>>>>>>>>>
                    //sender.Items.Add(valueList.ValueListItems[i]);
                    Infragistics.Win.ValueListItem vlItem = new Infragistics.Win.ValueListItem();
                    vlItem.Tag         = valueList.ValueListItems[i].Tag;
                    vlItem.DataValue   = valueList.ValueListItems[i].DataValue;
                    vlItem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add(vlItem);
                    // 2008.03.26 �C�� <<<<<<<<<<<<<<<<<<<<
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

				this.EnabledSettingSectionComboEditor(ref sender);
			}
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^Enabled�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
		public void EnabledSettingSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender)
		{
			if (this.IsMainOfficeFunc())
			{
				sender.SharedProps.Enabled = true;
			}
			else
			{
				sender.SharedProps.Enabled = false;
			}
		}


		/// <summary>
		/// ���_�R���{�G�f�B�^Enabled�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
		/// <param name="enabled">�ݒ�Enabled�l</param>
		public void EnabledSettingSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool enabled)
		{
			if (this.IsMainOfficeFunc())
			{
				sender.SharedProps.Enabled = enabled;
			}
			else
			{
				sender.SharedProps.Enabled = false;
			}
		}

		/// <summary>
		/// ���_�R���{�G�f�B�^���X�g�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
		/// <param name="isAllSection">�S�Аݒ�t���O</param>
		public void SetSectionComboEditor(out Infragistics.Win.ValueList sender, bool isAllSection)
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

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
		/// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
		/// <br>�EOwnSecSetting = �����_�ݒ�</br>
		/// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
		/// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
		/// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
		/// <br>�EBalanceDispSecCd = �c���\�����_</br>
		/// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
		/// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
		/// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
		/// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
		/// </summary>
		/// <param name="sender">�ΏۃR���{�G�f�B�^</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
		/// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
		public bool SetSectionComboEditorValue(TComboEditor sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode)
		{
			if (sectionCode.Trim() == SECTIONCODE_ALL)
			{
				return this.SetSectionComboEditorValue(sender, sectionCode);
			}
			else
			{
				string ctrlSectionCode;
				string ctrlSectionName;
				int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

				if (status == 0)
				{
					return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
				}
				else
				{
					return false;
				}
			}
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

		/// <summary>
		/// ���_�R���{�G�f�B�^�I��l�ݒ菈��
		/// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
		/// <br>�EOwnSecSetting = �����_�ݒ�</br>
		/// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
		/// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
		/// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
		/// <br>�EBalanceDispSecCd = �c���\�����_</br>
		/// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
		/// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
		/// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
		/// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
		/// </summary>
		/// <param name="sender">�ΏۃR���{�G�f�B�^</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
		/// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
		public bool SetSectionComboEditorValue(Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode)
		{
			if (sectionCode.Trim() == SECTIONCODE_ALL)
			{
				return this.SetSectionComboEditorValue(sender, sectionCode);
			}
			else
			{
				string ctrlSectionCode;
				string ctrlSectionName;
				int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

				if (status == 0)
				{
					return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
				}
				else
				{
					return false;
				}
			}
		}

        /// <summary>
		/// ����@�\���_�擾����
		/// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
		/// <br>�EOwnSecSetting = �����_�ݒ�</br>
		/// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
		/// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
		/// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
		/// <br>�EBalanceDispSecCd = �c���\�����_</br>
		/// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
		/// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
		/// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
		/// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
		/// </summary>
		/// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
		/// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
		/// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
		/// <param name="ctrlSectionName">�Ώې��䋒�_����</param>
		public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName)
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			// �Ώې��䋒�_�̏����l�̓��O�C���S�����_
			ctrlSectionCode = sectionCode.TrimEnd();
			ctrlSectionName = "";

			SecInfoSet secInfoSet;
			int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if (secInfoSet != null)
					{
						ctrlSectionCode = secInfoSet.SectionCode.Trim();
						ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
					}
					else
					{
						// ���_����ݒ肪����Ă��Ȃ�
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				default:
				{
					break;
				}
			}

			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
    }
}
