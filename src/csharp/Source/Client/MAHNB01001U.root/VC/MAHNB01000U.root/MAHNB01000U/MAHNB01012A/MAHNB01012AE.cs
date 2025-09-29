using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 ���n ���  �V�K�쐬</br>
    /// <br></br>
    /// <br>Update Note: K2013/09/20 �{�{ ����</br>
    /// <br>             ���t�^�o�� �{�Бq�ɗD�揇�ʑΉ�</br>
    /// <br></br>
    /// <br>Update Note: K2013/10/04 �e�c ���V</br>
    /// <br>             ���t�^�o�� �{�Бq�ɗD�揇�ʑΉ�</br>
    /// <br>             �D��q�Ɏ擾���@���hSearch�h����hReadWithWarehouse�h�ɕύX</br>
    /// </remarks>
    public partial class SalesSlipInputInitDataAcs
    {
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ���O�C�����_�R�[�h
        private string _ownSectionCode = string.Empty;
        private string _ownSectionName = string.Empty;
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
        public void CreateSecInfoAcs()
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
                if (string.IsNullOrEmpty(this._ownSectionCode))
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
        /// �����_����d�v���p�e�B
        /// </summary>
        public string OwnSectionName
        {
            get
            {
                if (string.IsNullOrEmpty(this._ownSectionName))
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
        /// �����_�R�[�h�擾����
        /// </summary>
        /// <returns>�����_�R�[�h</returns>
        private string GetOwnSectionCode()
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // �����_�̎擾
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // �����_�R�[�h�̕ۑ�
                this._ownSectionCode = secInfoSet.SectionCode;
            }

            return this._ownSectionCode;
        }

        /// <summary>
        /// �����_���̎擾������
        /// </summary>
        /// <returns>�����_����</returns>
        public string GetOwnSectionName()
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // �����_�̎擾
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // �����_�R�[�h�̕ۑ�
                this._ownSectionName = secInfoSet.SectionGuideNm;
            }

            return this._ownSectionName;
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
                _sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd1.Trim());
                _sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd2.Trim());
                _sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd3.Trim());
            }
            return this._sectWarehouseCdList;
        }

        // 2009/09/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �����_�D��q�ɃR�[�h�擾����
        /// </summary>
        /// <returns>�����_�D��q�ɃR�[�h</returns>
        public List<string> GetSectWarehouseCd(string sectionCode)
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();
            List<string> retList = new List<string>();

            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(sectionCode.PadRight(6, ' '), out secInfoSet);

            if (secInfoSet != null)
            {
                retList.Add(secInfoSet.SectWarehouseCd1.Trim());
                retList.Add(secInfoSet.SectWarehouseCd2.Trim());
                retList.Add(secInfoSet.SectWarehouseCd3.Trim());
            }
            return retList;
        }
        // 2009/09/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<        

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
                _sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm1.TrimEnd());
                _sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm2.TrimEnd());
                _sectWarehouseNmList.Add(secInfoSet.SectWarehouseNm3.TrimEnd());
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
                    sender.Items.Add(valueList.ValueListItems[i]);
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
            ctrlSectionName = string.Empty;

            SecInfoSet secInfoSet;
            int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (secInfoSet != null)
                        {
                            //ctrlSectionCode = secInfoSet.SectionCode.Trim();
                            ctrlSectionCode = secInfoSet.SectionCode;
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
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        public SecInfoSet GetSecInfo(string sectionCode)
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

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �{�Ћ��_�`�F�b�N���� ���t�^�o�ʑΉ�
        /// </summary>
        public bool CheckMainSection(string enterpriseCode, string sectionCode)
        {
            bool retMainSection = false;

            //�w�苒�_�R�[�h�Ŗ{�ЊǗ��q�Ƀ}�X�^��ǂݍ��݁A���݂���ꍇ�͖{��
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ProtyWarehouseAcs protyWarehouseAcs = new ProtyWarehouseAcs();
            ArrayList warehouseList = new ArrayList();
            status = protyWarehouseAcs.ReadWithWarehouse(out warehouseList, enterpriseCode, sectionCode, "", ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMainSection = true;
            }
            return retMainSection;
        }

        /// <summary>
        /// �D��q�Ɏ擾���� ���t�^�o�ʑΉ�
        /// </summary>
        //public int GetPriorWarehouseInfo(string enterpriseCode, string sectionCode, out List<string> WarehouseCdList)
        public List<string> GetPriorWarehouseInfo(string enterpriseCode, string sectionCode)
        {
            List<string> WarehouseCdList = new List<string>();

            //�w�苒�_�R�[�h�Ŗ{�ЊǗ��q�Ƀ}�X�^��ǂݍ��݁A�D�揇�ɑq�ɃR�[�h���i�[
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ProtyWarehouseAcs protyWarehouseAcs = new ProtyWarehouseAcs();
            ArrayList warehouseList = new ArrayList();
            // --- UPD 2013/10/04 Y.Wakita ---------->>>>>
            //status = protyWarehouseAcs.Search(out warehouseList, enterpriseCode);
            status = protyWarehouseAcs.ReadWithWarehouse(out warehouseList, enterpriseCode, "", "", ConstantManagement.LogicalMode.GetData0);
            // --- UPD 2013/10/04 Y.Wakita ----------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ProtyWarehouse warehouse in warehouseList)
                {
                    WarehouseCdList.Add(warehouse.WarehouseCode.Trim());
                }
            }
            return WarehouseCdList;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
    }
}
