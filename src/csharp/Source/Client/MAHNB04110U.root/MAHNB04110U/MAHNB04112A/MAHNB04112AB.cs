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
    public partial class SalesSlipSearchAcs
    {
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ���O�C�����_�R�[�h
        private string _ownSectionCode = "";
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

            // �����_�R�[�h���擾
            SecInfoSet secInfoSet;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            this._ownSectionCode = secInfoSet.SectionCode.TrimEnd();

            //SecInfoSet secInfoSet;
            //_secInfoAcs.GetSecInfo(this._loginSectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
            //if (secInfoSet != null)
            //{
            //    // �����_�R�[�h�̕ۑ�
            //    this._ownSectionCode = secInfoSet.SectionCode;
            //}

            return this._ownSectionCode;
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
        /// �`�[�敪�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesFormalCode"></param>
        // --- CHG 2009/01/29 ��QID:7552�Ή�------------------------------------------------------>>>>>
        //public void SetSalesSlipCdComboEditor(ref TComboEditor sender, int salesFormalCode, ExtractSlipCdType extractSlipCdType)
        public void SetSalesSlipCdComboEditor(ref TComboEditor sender, int salesFormalCode, ExtractSlipCdType extractSlipCdType)
        // --- CHG 2009/01/29 ��QID:7552�Ή�------------------------------------------------------<<<<<
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

            Infragistics.Win.ValueListItem secInfoItemM1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem0 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem100 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem101 = new Infragistics.Win.ValueListItem();

            switch (salesFormalCode)
            {
                //10,15:����,16:��������,20:��,30:����,40:�ݏo
                case 10:
                case 15:
                    secInfoItemM1.DataValue = -1;
                    secInfoItemM1.DisplayText = "�S��";
                    valueList.ValueListItems.Add(secInfoItemM1);

                    if (extractSlipCdType != ExtractSlipCdType.Return)
                    {
                        //�|����
                        secInfoItem0.DataValue = 0;
                        secInfoItem0.DisplayText = "�|����";
                        valueList.ValueListItems.Add(secInfoItem0);
                        // 2008.11.27 add start [7876]
                        //��������
                        secInfoItem100.DataValue = 100;
                        secInfoItem100.DisplayText = "��������";
                        valueList.ValueListItems.Add(secInfoItem100);
                        // 2008.11.27 add end [7876]
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                case 16:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                    // 2008.11.18 modify start [7561]
                    ////�|����
                    //secInfoItem0.DataValue = 0;
                    //secInfoItem0.DisplayText = "�|����";
                    //valueList.ValueListItems.Add(secInfoItem0);
                    //�S��
                    secInfoItemM1.DataValue = -1;
                    secInfoItemM1.DisplayText = "�S��";
                    valueList.ValueListItems.Add(secInfoItemM1);
                    // 2008.11.18 modify end [7561]
                    break;
                case 20:
                case 30:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                default:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                    // 2008.11.18 add start [7561]
                    //�S��
                    secInfoItemM1.DataValue = -1;
                    secInfoItemM1.DisplayText = "�S��";
                    valueList.ValueListItems.Add(secInfoItemM1);
                    // 2008.11.18 add start [7561]

                    if (extractSlipCdType != ExtractSlipCdType.Return)
                    {
                        //�|����
                        secInfoItem0.DataValue = 0;
                        secInfoItem0.DisplayText = "�|����";
                        valueList.ValueListItems.Add(secInfoItem0);
                    }

                    if (extractSlipCdType != ExtractSlipCdType.Sales)
                    {
                        //�|�ԕi
                        secInfoItem1.DataValue = 1;
                        secInfoItem1.DisplayText = "�|�ԕi";
                        valueList.ValueListItems.Add(secInfoItem1);
                    }

                    if (extractSlipCdType != ExtractSlipCdType.Return)
                    {
                        //��������
                        secInfoItem100.DataValue = 100;
                        secInfoItem100.DisplayText = "��������";
                        valueList.ValueListItems.Add(secInfoItem100);
                    }

                    if (extractSlipCdType != ExtractSlipCdType.Sales)
                    {
                        //�����ԕi
                        secInfoItem101.DataValue = 101;
                        secInfoItem101.DisplayText = "�����ԕi";
                        valueList.ValueListItems.Add(secInfoItem101);
                    }
                    break;
                case 40:
                    // 2008.11.18 add start [7561]
                    //�S��
                    secInfoItemM1.DataValue = -1;
                    secInfoItemM1.DisplayText = "�S��";
                    valueList.ValueListItems.Add(secInfoItemM1);
                    // 2008.11.18 add start [7561]

                    if (extractSlipCdType != ExtractSlipCdType.Return)
                    {
                        //�|����
                        secInfoItem0.DataValue = 0;
                        secInfoItem0.DisplayText = "�|����";
                        valueList.ValueListItems.Add(secInfoItem0);
                    }

                    if (extractSlipCdType != ExtractSlipCdType.Sales)
                    {
                        //�|�ԕi
                        secInfoItem1.DataValue = 1;
                        secInfoItem1.DisplayText = "�|�ԕi";
                        valueList.ValueListItems.Add(secInfoItem1);
                    }

                    // 2008.11.27 add start [7876]

                    if (extractSlipCdType != ExtractSlipCdType.Return)
                    {
                        //��������
                        secInfoItem100.DataValue = 100;
                        secInfoItem100.DisplayText = "��������";
                        valueList.ValueListItems.Add(secInfoItem100);
                    }

                    if (extractSlipCdType != ExtractSlipCdType.Sales)
                    {
                        //�����ԕi
                        secInfoItem101.DataValue = 101;
                        secInfoItem101.DisplayText = "�����ԕi";
                        valueList.ValueListItems.Add(secInfoItem101);
                    }
                    // 2008.11.27 add end [7876]
                    break;
            }

            if ( valueList != null )
            {
                sender.Items.Clear();

                for ( int i = 0; i < valueList.ValueListItems.Count; i++ )
                {
                    //sender.Items.Add(valueList.ValueListItems[i]);

                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add( vlltem );
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //sender.MaxDropDownItems = valueList.ValueListItems.Count;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // 2008.11.18 modify start [7561]
                if (salesFormalCode == 16)
                {
                    sender.Value = -1;
                }
                else
                {
                    sender.Value = 0;
                }
                // 2008.11.18 modify end [7561]
            }
        }

        ///// <summary>
        ///// ���_�R���{�G�f�B�^���X�g�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        ///// <param name="isAllSection">�S�Аݒ�t���O</param>
        //public void SetSectionComboEditor(ref TComboEditor sender, bool isAllSection)
        //{
        //    Infragistics.Win.ValueList valueList;
        //    this.SetSectionComboEditor(out valueList, isAllSection);

        //    if (valueList != null)
        //    {
        //        for (int i = 0; i < valueList.ValueListItems.Count; i++)
        //        {
        //            //sender.Items.Add(valueList.ValueListItems[i]);

        //            Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
        //            vlltem.Tag = valueList.ValueListItems[i].Tag;
        //            vlltem.DataValue = valueList.ValueListItems[i].DataValue;
        //            vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
        //            sender.Items.Add(vlltem);

        //        }

        //        sender.MaxDropDownItems = valueList.ValueListItems.Count;

        //        if (this.IsMainOfficeFunc())
        //        {
        //            sender.ReadOnly = false;
        //        }
        //        else
        //        {
        //            sender.ReadOnly = true;
        //        }
        //    }
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^���X�g�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
        ///// <param name="isAllSection">�S�Аݒ�t���O</param>
        //public void SetSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool isAllSection)
        //{
        //    Infragistics.Win.ValueList valueList;
        //    this.SetSectionComboEditor(out valueList, isAllSection);

        //    if (valueList != null)
        //    {
        //        sender.ValueList = valueList;
        //        sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

        //        this.EnabledSettingSectionComboEditor(ref sender);
        //    }
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^Enabled�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
        //public void EnabledSettingSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender)
        //{
        //    if (this.IsMainOfficeFunc())
        //    {
        //        sender.SharedProps.Enabled = true;
        //    }
        //    else
        //    {
        //        sender.SharedProps.Enabled = false;
        //    }
        //}


        ///// <summary>
        ///// ���_�R���{�G�f�B�^Enabled�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
        ///// <param name="enabled">�ݒ�Enabled�l</param>
        //public void EnabledSettingSectionComboEditor(ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool enabled)
        //{
        //    if (this.IsMainOfficeFunc())
        //    {
        //        sender.SharedProps.Enabled = enabled;
        //    }
        //    else
        //    {
        //        sender.SharedProps.Enabled = false;
        //    }
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^���X�g�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
        ///// <param name="isAllSection">�S�Аݒ�t���O</param>
        //public void SetSectionComboEditor(out Infragistics.Win.ValueList sender, bool isAllSection)
        //{
        //    // ���_����A�N�Z�X�N���X�C���X�^���X������
        //    this.CreateSecInfoAcs();

        //    sender = new Infragistics.Win.ValueList();

        //    // ���O�C���S�����_���̎擾
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        if (isAllSection)
        //        {
        //            Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
        //            secInfoItem.DataValue = SECTIONCODE_ALL;
        //            secInfoItem.DisplayText = SECTIONNAME_ALL;
        //            sender.ValueListItems.Add(secInfoItem);
        //        }

        //        // ���_��񃊃X�g�̎擾
        //        if ((_secInfoAcs.SecInfoSetList != null) && (_secInfoAcs.SecInfoSetList.Length > 0))
        //        {
        //            foreach (SecInfoSet setSecInfoSet in _secInfoAcs.SecInfoSetList)
        //            {
        //                Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
        //                secInfoItem.DataValue = setSecInfoSet.SectionCode;
        //                secInfoItem.DisplayText = setSecInfoSet.SectionGuideNm;
        //                sender.ValueListItems.Add(secInfoItem);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        //public bool SetSectionComboEditorValue(TComboEditor sender, string sectionCode)
        //{
        //    bool isSetting = false;

        //    if (sender.Items.Count > 0)
        //    {
        //        // 1�̋��_�����Ȃ��ꍇ�͐擪��I��
        //        if (sender.Items.Count == 1)
        //        {
        //            sender.SelectedIndex = 0;
        //            isSetting = true;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < sender.Items.Count; i++)
        //            {
        //                if (sender.Items[i].DataValue.ToString().Trim() == sectionCode.Trim())
        //                {
        //                    sender.SelectedIndex = i;
        //                    isSetting = true;
        //                    break;
        //                }
        //            }
        //        }

        //        if (!isSetting)
        //        {
        //            for (int i = 0; i < sender.Items.Count; i++)
        //            {
        //                if (sender.Items[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim())
        //                {
        //                    sender.SelectedIndex = i;
        //                    isSetting = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return isSetting;
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        ///// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        ///// <br>�EOwnSecSetting = �����_�ݒ�</br>
        ///// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        ///// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        ///// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        ///// <br>�EBalanceDispSecCd = �c���\�����_</br>
        ///// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        ///// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        ///// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        ///// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        ///// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        //public bool SetSectionComboEditorValue(TComboEditor sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode)
        //{
        //    if (sectionCode.Trim() == SECTIONCODE_ALL)
        //    {
        //        return this.SetSectionComboEditorValue(sender, sectionCode);
        //    }
        //    else
        //    {
        //        string ctrlSectionCode;
        //        string ctrlSectionName;
        //        int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

        //        if (status == 0)
        //        {
        //            return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�{�b�N�X</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        //public bool SetSectionComboEditorValue(Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode)
        //{
        //    bool isSetting = false;

        //    if (sender.ValueList.ValueListItems.Count > 0)
        //    {
        //        sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

        //        // 1�̋��_�����Ȃ��ꍇ�͐擪��I��
        //        if (sender.ValueList.ValueListItems.Count == 1)
        //        {
        //            sender.SelectedIndex = 0;
        //            isSetting = true;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
        //            {
        //                if (sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == sectionCode.Trim())
        //                {
        //                    sender.Value = sectionCode;
        //                    isSetting = true;
        //                    break;
        //                }
        //            }
        //        }

        //        if (!isSetting)
        //        {
        //            for (int i = 0; i < sender.ValueList.ValueListItems.Count; i++)
        //            {
        //                if (sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim())
        //                {
        //                    sender.Value = this._loginSectionCode;
        //                    isSetting = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return isSetting;
        //}

        ///// <summary>
        ///// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        ///// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        ///// <br>�EOwnSecSetting = �����_�ݒ�</br>
        ///// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        ///// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        ///// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        ///// <br>�EBalanceDispSecCd = �c���\�����_</br>
        ///// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        ///// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        ///// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        ///// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        ///// </summary>
        ///// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        ///// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        //public bool SetSectionComboEditorValue(Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode)
        //{
        //    if (sectionCode.Trim() == SECTIONCODE_ALL)
        //    {
        //        return this.SetSectionComboEditorValue(sender, sectionCode);
        //    }
        //    else
        //    {
        //        string ctrlSectionCode;
        //        string ctrlSectionName;
        //        int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

        //        if (status == 0)
        //        {
        //            return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        ///// <summary>
        ///// ����@�\���_�擾����
        ///// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        ///// <br>�EOwnSecSetting = �����_�ݒ�</br>
        ///// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        ///// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        ///// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        ///// <br>�EBalanceDispSecCd = �c���\�����_</br>
        ///// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        ///// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        ///// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        ///// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        ///// </summary>
        ///// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        ///// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        ///// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        ///// <param name="ctrlSectionName">�Ώې��䋒�_����</param>
        //public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName)
        //{
        //    // ���_����A�N�Z�X�N���X�C���X�^���X������
        //    this.CreateSecInfoAcs();

        //    // �Ώې��䋒�_�̏����l�̓��O�C���S�����_
        //    ctrlSectionCode = sectionCode.TrimEnd();
        //    ctrlSectionName = "";

        //    SecInfoSet secInfoSet;
        //    int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);
        //    //int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);

        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //        {
        //            if (secInfoSet != null)
        //            {
        //                ctrlSectionCode = secInfoSet.SectionCode.Trim();
        //                ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
        //            }
        //            else
        //            {
        //                // ���_����ݒ肪����Ă��Ȃ�
        //                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //            }
        //            break;
        //        }
        //        default:
        //        {
        //            break;
        //        }
        //    }

        //    return status;
        //}
    }
}
