using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	public partial class EstimateInputInitDataAcs
	{
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ���O�C�����_�R�[�h
		private string _ownSectionCode = "";
		private string _ownSectionName = "";
		private List<string> _sectWarehouseCdList = new List<string>();
		private List<string> _sectWarehouseNmList = new List<string>();
		private static SecInfoAcs _secInfoAcs;													// ���_�A�N�Z�X�N���X
		private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		internal const string SECTIONCODE_ALL = "000000";
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

		/// <summary>
		/// ���_����A�N�Z�X�N���X�C���X�^���X������
		/// </summary>
		internal void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
			}

            // ���O�C���S�����_���̎擾
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

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
		/// �����_���̃v���p�e�B
		/// </summary>
		public string OwnSectionName
		{
			get
			{
				if (this._ownSectionName == "")
				{
					return this.GetOwnSectionName();
				}
				else
				{
					return this._ownSectionName;
				}
			}
		}

		/// <summary>
		/// �����_�q�ɃR�[�h�v���p�e�B
		/// </summary>
		public List<string> SectWarehouseCd
		{
			get
			{
				if (this._sectWarehouseCdList.Count == 0)
				{
					return this.GetSectWarehouseCd();
				}
				else
				{
					return this._sectWarehouseCdList;
				}
			}
		}

		/// <summary>
		/// �����_�q�ɖ��̃v���p�e�B
		/// </summary>
		public List<string> SectWarehouseNm
		{
			get
			{
				if (this._sectWarehouseNmList.Count == 0)
				{
					return this.GetSectWarehouseNm();
				}
				else
				{
					return this._sectWarehouseNmList;
				}
			}
		}

		/// <summary>
		/// ���_���擾����
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns></returns>
		public SecInfoSet GetSecInfo( string sectionCode )
		{
			SecInfoSet retSecInfoSet = null;

			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			if (_secInfoAcs.SecInfoSetList != null)
			{
				foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim())
					{
						retSecInfoSet = secInfoSet;
						break;
					}
				}
			}
			return retSecInfoSet;
		}

		/// <summary>
		/// �����_�R�[�h�擾����
		/// </summary>
		/// <returns>�����_�R�[�h</returns>
		private string GetOwnSectionCode()
		{
			this.GetOwnSectionInfo();

			return this._ownSectionCode;
		}

		/// <summary>
		/// �����_���̎擾����
		/// </summary>
		/// <returns>�����_�R�[�h</returns>
        //private string GetOwnSectionName() // 2009.05.26
   		public string GetOwnSectionName() // 2009.05.26
        {
			this.GetOwnSectionInfo();

			return this._ownSectionName;
		}

		/// <summary>
		/// �����_���擾����
		/// </summary>
		/// <returns></returns>
		private void GetOwnSectionInfo()
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			// �����_�̎擾
			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

			if (secInfoSet != null)
			{
				this._ownSectionCode = secInfoSet.SectionCode;
				this._ownSectionName = secInfoSet.SectionGuideNm;
			}
		}

		/// <summary>
		/// �����_�D��q�ɃR�[�h�擾����
		/// </summary>
		/// <returns>�����_�D��q�ɃR�[�h</returns>
		private List<string> GetSectWarehouseCd()
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
				_sectWarehouseCdList = new List<string>();
				_sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd1);
				_sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd2);
				_sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd3);
			}
			return this._sectWarehouseCdList;
		}

		/// <summary>
		/// �����_�D��q�ɖ��̎擾����
		/// </summary>
		/// <returns>�����_�D��q�ɖ���</returns>
		private List<string> GetSectWarehouseNm()
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
				_sectWarehouseNmList = new List<string>();
				_sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm1);
				_sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm2);
				_sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm3);
			}
			return this._sectWarehouseNmList;
		}


		/// <summary>
		/// �{�Ћ@�\�^���_�@�\�`�F�b�N����
		/// </summary>
		/// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
		public bool IsMainOfficeFunc()
		{
			bool isMainOfficeFunc = false;

			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

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
		/// ����@�\���_�擾����
		/// </summary>
		/// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
		/// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
		/// <param name="ctrlSectionName">�Ώې��䋒�_����</param>
		public int GetOwnSeCtrlCode(string sectionCode, out string ctrlSectionCode, out string ctrlSectionName)
		{
			// ���_����A�N�Z�X�N���X�C���X�^���X������
			this.CreateSecInfoAcs();

			// �Ώې��䋒�_�̏����l�̓��O�C���S�����_
			ctrlSectionCode = sectionCode.TrimEnd();
			ctrlSectionName = "";

			SecInfoSet secInfoSet;
			int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

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

        /// <summary>
        /// �t�n�d�K�C�h���̃}�X�^�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="uOEGuideDivCd">�t�n�d�K�C�h�敪</param>
        /// <param name="uOESupplierCd">�t�n�d������R�[�h</param>
        public void SetUOEGuideNameComboEditor(ref TComboEditor sender, int uOEGuideDivCd, int uOESupplierCd)
        {
            sender.Items.Clear();
            Infragistics.Win.ValueList valueList;
            this.SetUOEGuideNameComboEditor(out valueList, uOEGuideDivCd, uOESupplierCd);

            if (valueList != null)
            {
                for (int i = 0; i < valueList.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlItem = new Infragistics.Win.ValueListItem();
                    vlItem.Tag = valueList.ValueListItems[i].Tag;
                    vlItem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlItem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add(vlItem);
                }

                if (valueList.ValueListItems.Count > 0)
                {
                    sender.MaxDropDownItems = valueList.ValueListItems.Count;
                }
            }
        }

        /// <summary>
        /// �t�n�d�K�C�h���̃}�X�^�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uoeGuideDivCd">�t�n�d�K�C�h�敪</param>
        /// <param name="uoeSupplierCd">�t�n�d������R�[�h</param>
        public void SetUOEGuideNameComboEditor(out Infragistics.Win.ValueList sender, int uoeGuideDivCd, int uoeSupplierCd)
        {
            sender = new Infragistics.Win.ValueList();

            List<UOEGuideName> uoeGuideNameList = this.GetUOEGuideNameListFromCache(uoeGuideDivCd, uoeSupplierCd);

            foreach (UOEGuideName uoeGuideName in uoeGuideNameList)
            {
                Infragistics.Win.ValueListItem infoItem = new Infragistics.Win.ValueListItem();
                infoItem.Tag = uoeGuideName.UOEGuideCode;
                infoItem.DataValue = uoeGuideName.UOEGuideCode;
                infoItem.DisplayText = uoeGuideName.UOEGuideNm;
                sender.ValueListItems.Add(infoItem);
            }
        }
	}
}
