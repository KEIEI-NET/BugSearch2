//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/08/31  �C�����e : #13972�@�A�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/09/03  �C�����e : #13972��6�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/09/06  �C�����e : #14238�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/09/08  �C�����e : #14384�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �P�i�����@���Ӑ���p�o�^UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �P�i�����@���Ӑ���p�o�^UI�t�H�[���N���X</br>
    /// <br>Programmer  : ���M</br>
    /// <br>Date        : 2010/08/04</br>
    /// <br>Update Note : 2010/08/31 �k���r #13972�A�̑Ή��B</br>
    /// <br>Update Note : 2010/09/03 �k���r #13972�̂U�̑Ή�</br>
    /// <br>Update Note : 2010/09/06 ������ #14238�Ή�</br>
    /// </remarks>
    public partial class PMKHN09461UB : Form
    {
        #region �� Private Members
        private string _enterpriseCode;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// �K�C�h�{�^��

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, string> _custRateGrpDic;
        private SecInfoAcs _secInfoAcs = null;                                 // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;                           // ���_���ݒ�A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs = null;
        private UserGuideAcs _userGuideAcs = null;			                   // ���[�U�[�K�C�h�A�N�Z�X�N���X

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private string _OrigintmpSectionCode;
        private string _tmpSectionCode;
        private int _tmpCustomerCode1;
        private int _tmpCustomerCode2;
        private int _tmpCustomerCode3;
        private int _tmpCustomerCode4;
        private int _tmpCustomerCode5;
        private int _tmpCustomerGrpCode1 = -1;
        private int _tmpCustomerGrpCode2 = -1;
        private int _tmpCustomerGrpCode3 = -1;
        private int _tmpCustomerGrpCode4 = -1;
        private int _tmpCustomerGrpCode5 = -1;
        private object _preComboDeleteDivValue;
        private object _preComboSettingDivValue;

        private bool _cusotmerGuideSelected;                // ���Ӑ�K�C�h�I���t���O

        private GoodsRateSetSearchParam _extrInfo;

        private string _customerTag;

        private const string CUSTOMERNOFOUND = "���o�^";
        /// <summary>�m�F�p���b�Z�[�W</summary>
        private const string MSG_CONFIRM_SAVEDISP = "�ꊇ�폜�������J�n���Ă���낵���ł����H\r\n�ꊇ�폜���������s���܂��Ɗm��O�̔����ݒ�͔��f����܂���B";

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
        private const string ctGUIDE_NAME_OriginSectionGuide = "OriginSectionGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_Customer1Guide = "Customer1Guide";
        private const string ctGUIDE_NAME_Customer2Guide = "Customer2Guide";
        private const string ctGUIDE_NAME_Customer3Guide = "Customer3Guide";
        private const string ctGUIDE_NAME_Customer4Guide = "Customer4Guide";
        private const string ctGUIDE_NAME_Customer5Guide = "Customer5Guide";

        private const string ctGUIDE_NAME_CustomerGrp1Guide = "CustomerGrp1Guide";
        private const string ctGUIDE_NAME_CustomerGrp2Guide = "CustomerGrp2Guide";
        private const string ctGUIDE_NAME_CustomerGrp3Guide = "CustomerGrp3Guide";
        private const string ctGUIDE_NAME_CustomerGrp4Guide = "CustomerGrp4Guide";
        private const string ctGUIDE_NAME_CustomerGrp5Guide = "CustomerGrp5Guide";

        private CustomerCodeRateSetUpdateAcs _goodsRateSetUpdateAcs;           // �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X

        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// �P�i�����@���Ӑ���p�o�^UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �P�i�����@���Ӑ���p�o�^UI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public PMKHN09461UB(GoodsRateSetSearchParam extrInfo)
        {
            InitializeComponent();


            _extrInfo = extrInfo;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsRateSetUpdateAcs = new CustomerCodeRateSetUpdateAcs();

            // �e��}�X�^�Ǎ�
            LoadSecInfoSet();
            LoadCustomerSearchRet();
            GetCustRateGrp();

            // ��ʏ����ݒ�
            SetInitialSetting();

            // ��ʃN���A
            ClearScreen();
        }

        #endregion �� Constructor

        #region �� Private Methods

        #region �����ݒ�
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // �A�C�R���ݒ�
            //---------------------------------
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            _closeButton = (ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            _closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            _saveButton = (ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            _saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            _guideButton = (ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            _guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            this._guideEnableControlDictionary.Add(this.tEdit_OriginSectionCodeAllowZeroD.Name, ctGUIDE_NAME_OriginSectionGuide);        // ���p���ݒ�.���_
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);                    // ���p��ݒ�.���_
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD1.Name, ctGUIDE_NAME_Customer1Guide);                        // ���p��ݒ�.���Ӑ�R�[�h1
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD2.Name, ctGUIDE_NAME_Customer2Guide);                        // ���p��ݒ�.���Ӑ�R�[�h2
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD3.Name, ctGUIDE_NAME_Customer3Guide);                        // ���p��ݒ�.���Ӑ�R�[�h3
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD4.Name, ctGUIDE_NAME_Customer4Guide);                        // ���p��ݒ�.���Ӑ�R�[�h4
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD5.Name, ctGUIDE_NAME_Customer5Guide);                        // ���p��ݒ�.���Ӑ�R�[�h5

            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero1.Name, ctGUIDE_NAME_CustomerGrp1Guide);                 // ���p��ݒ�.���Ӑ�R�[�h1
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero2.Name, ctGUIDE_NAME_CustomerGrp2Guide);                 // ���p��ݒ�.���Ӑ�R�[�h2
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero3.Name, ctGUIDE_NAME_CustomerGrp3Guide);                 // ���p��ݒ�.���Ӑ�R�[�h3
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero4.Name, ctGUIDE_NAME_CustomerGrp4Guide);                 // ���p��ݒ�.���Ӑ�R�[�h4
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero5.Name, ctGUIDE_NAME_CustomerGrp5Guide);                 // ���p��ݒ�.���Ӑ�R�[�h5

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.OriginSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this.uButton_CustomerGrpGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }
        #endregion �����ݒ�

        #region �N���A����
        /// <summary>
        /// ��ʏ��N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void ClearScreen()
        {
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "�S��";
            this._tmpSectionCode = "00";


            this._OrigintmpSectionCode = "00";
            this.tEdit_OriginSectionCodeAllowZeroD.DataText = "00";
            this.tEdit_OriginSectionName.DataText = "�S��";

            // �敪
            this.tComboEditor_DeleteDiv.Value = 2;
            this.tComboEditor_SettingDiv.Value = 0;
        }

        #endregion �N���A����

        #region �}�X�^�Ǎ�
        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_���}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void LoadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���Ӑ挟���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���Ӑ挟�����}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void LoadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retList;

                int status = this._customerSearchAcs.Serch(out retList, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retList)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="retList">���[�U�[�K�C�h�{�f�B�f�[�^���X�g</param>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�����擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            int status;
            ArrayList retList = new ArrayList();

            // ���[�U�[�K�C�h�f�[�^�擾(���Ӑ�|���O���[�v)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                    }
                }
            }

            return status;
        }

        #endregion �}�X�^�Ǎ�

        #region ���̎擾
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note        : ���_�R�[�h�ɊY�����鋒�_���̂��擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "�S��";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }



        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       :  2010/08/10</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
                else
                {
                    customerName = CUSTOMERNOFOUND;
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// ���Ӑ�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            string custRateGrpName = "";

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                custRateGrpName = (string)this._custRateGrpDic[custRateGrpCode];
            }

            return custRateGrpName;
        }
        #endregion ���̎擾

        # region �K�C�h�N������
        /// <summary>
        /// �K�C�h�{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                        (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            // ���ו��Ƀt�H�[�J�X�����鎞�͖��׉�ʂɏ]���Đݒ肷��
            if (this._guideEnableControlDictionary.ContainsKey(targetControl.Name))
            {
                this._guideButton.SharedProps.Enabled = true;
                this._guideButton.SharedProps.Tag = this._guideEnableControlDictionary[targetControl.Name];
            }
            else
            {
                this._guideButton.SharedProps.Enabled = false;
                this._guideButton.SharedProps.Tag = string.Empty;
            }
        }

        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�N���������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void ExecuteGuide()
        {
            if (_guideButton.SharedProps.Tag != null)
            {
                switch (_guideButton.SharedProps.Tag.ToString())
                {
                    case ctGUIDE_NAME_OriginSectionGuide:
                        {
                            this.OriginSectionGuide_Button_Click(this.OriginSectionGuide_Button, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_SectionGuide:
                        {
                            this.OriginSectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer1Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide1, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer2Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide2, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer3Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide3, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer4Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide4, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer5Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide5, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp1Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide1, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp2Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide2, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp3Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide3, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp4Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide4, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp5Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide5, new EventArgs());
                            break;
                        }
                }
            }
        }

        /// <summary>
        ///���ݒ�c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        private void SettingUnSettingToolEnabled()
        {
            if (tComboEditor_DeleteDiv.Value == null || tComboEditor_SettingDiv.Value == null)
            {
                return;
            }
            if ((tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[0].DataValue || tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[2].DataValue)
                && tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
            {
                uCheckEditor_unSetting.Enabled = true;
            }
            else
            {
                uCheckEditor_unSetting.Checked = false;
                uCheckEditor_unSetting.Enabled = false;
            }
        }
        # endregion�@�K�C�h�N������

        #region �ۑ�
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �m�F�_�C�A���O
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                MSG_CONFIRM_SAVEDISP,
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return -1;
            }

            // ��ʏ��`�F�b�N
            bool bStatus = CheckSaveCondition();
            if (!bStatus)
            {
                return -1;
            }
            // ��ʏ��擾
            SetExtrInfo(ref this._extrInfo);

            // �X�V����
            status = this._goodsRateSetUpdateAcs.CustomerAllDelete(this._extrInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                   "���������ɊY������f�[�^�����݂��܂���B",
                   status,
                   MessageBoxButtons.OK,
                   MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }

            return (status);
        }

        /// <summary>
        /// �ۑ������`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �ۑ��������`�F�b�N���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/08/31 �k���r #13972�A�̑Ή��B</br>
        /// <br>Update Note : 2010/09/01 �k���r #13972�A�̑Ή��B</br>
        /// </remarks>
        private bool CheckSaveCondition()
        {
            string errMsg = "";
            Control nextCtrl = null;

            try
            {
                if ((int)this.tComboEditor_SettingDiv.Value == 0)
                {
                    // ���p��@���Ӑ�R�[�h
                    if (this.tNedit_CustomerCodeD1.GetInt() == 0 && this.tNedit_CustomerCodeD2.GetInt() == 0
                        && this.tNedit_CustomerCodeD3.GetInt() == 0 && this.tNedit_CustomerCodeD4.GetInt() == 0
                        && this.tNedit_CustomerCodeD5.GetInt() == 0)
                    {
                        errMsg = "���Ӑ����͂��ĉ������B";
                        this.tNedit_CustomerCodeD1.Focus();
                        nextCtrl = this.tNedit_CustomerCodeD1;
                        return (false);
                    }
                }
                else if ((int)this.tComboEditor_SettingDiv.Value == 1)
                {
                    // ���p��@���Ӑ�|���f�R�[�h
                    //-----ADD 2010/08/31---------->>>>>
                    //-----UPD 2010/09/01---------->>>>>
                    if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                        && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                        && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim())
                        && (((int)tComboEditor_DeleteDiv.Value == 2 && uCheckEditor_unSetting.Checked == false) 
                        || ((int)tComboEditor_DeleteDiv.Value == 0 && uCheckEditor_unSetting.Checked == false) 
                        || (int)tComboEditor_DeleteDiv.Value == 1))
                    //if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim()) 
                    //    && (((int)tComboEditor_DeleteDiv.Value == 2 && uCheckEditor_unSetting.Checked == false) || ((int)tComboEditor_DeleteDiv.Value == 0 || (int)tComboEditor_DeleteDiv.Value == 1)))
                    //-----UPD 2010/09/01----------<<<<<
                    //if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim()))
                    //-----ADD 2010/08/31----------<<<<<
                    {
                        errMsg = "���Ӑ�|���f����͂��ĉ������B";
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero1;
                        return (false);
                    }
                }

            }
            finally
            {
                this.SettingGuideButtonToolEnabled(nextCtrl);
                if (errMsg.Length > 0)
                {
                    DialogResult dResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
   
        }

        /// <summary>
        /// �ۑ����������ݒ菈��
        /// </summary>
        /// <param name="para">�ۑ���������</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂�ۑ�����������ݒ肵�܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void SetExtrInfo(ref GoodsRateSetSearchParam para)
        {
            //�폜�敪
            if ((int)tComboEditor_DeleteDiv.Value == 0)
            {
                para.RateMngGoodsCd = "0";
            }
            else if ((int)tComboEditor_DeleteDiv.Value == 1)
            {
                para.RateMngGoodsCd = "1";
            }
            else if ((int)tComboEditor_DeleteDiv.Value == 2)
            {
                para.RateMngGoodsCd = "2";
            }
            else
            {
                para.RateMngGoodsCd = "0";
            }
            
            //�w��敪
            if ((int)tComboEditor_SettingDiv.Value == 0)
            {
                para.RateMngCustCd = "0";
            }
            else if ((int)tComboEditor_SettingDiv.Value == 1)
            {
                para.RateMngCustCd = "1";
            }
            else
            {
                para.RateMngCustCd = "2";
            }

            if ((int)this.tComboEditor_SettingDiv.Value == 0)
            {
                //���Ӑ�R�[�h

                //���p��.���_�R�[�h
                if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                    (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
                {
                    // �S�Ўw��
                    para.SectionCode = null;
                }
                else
                {
                    para.SectionCode = new string[1];
                    para.SectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
                }

                //���p��.���Ӑ�
                para.CustomerCode = new int[6];

                //���p��.���Ӑ�R�[�h1�`5
                para.CustomerCode[1] = tNedit_CustomerCodeD1.GetInt();
                para.CustomerCode[2] = tNedit_CustomerCodeD2.GetInt();
                para.CustomerCode[3] = tNedit_CustomerCodeD3.GetInt();
                para.CustomerCode[4] = tNedit_CustomerCodeD4.GetInt();
                para.CustomerCode[5] = tNedit_CustomerCodeD5.GetInt();
            }
            else if ((int)this.tComboEditor_SettingDiv.Value == 1)
            {
                //���Ӑ�|���f�R�[�h

                // ���p��.���_
                if ((this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim() == "") ||
                    (this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim().PadLeft(2, '0') == "00"))
                {
                    // �S�Ўw��
                    para.SectionCode = null;
                }
                else
                {
                    para.SectionCode = new string[1];
                    para.SectionCode[0] = this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim().PadLeft(2, '0');
                }


                //���p��.���Ӑ�|���f
                para.CustRateGrpCode = new int[6];

                //���p��.���Ӑ�|���f�R�[�h1�`5
                if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero1.Text))
                {
                    para.CustRateGrpCode[1] = tNedit_CustRateGrpCodeZero1.GetInt();
                }
                else
                {
                    para.CustRateGrpCode[1] = -1;
                }

                if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero2.Text))
                {
                    para.CustRateGrpCode[2] = tNedit_CustRateGrpCodeZero2.GetInt();
                }
                else
                {
                    para.CustRateGrpCode[2] = -1;
                }

                if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero3.Text))
                {
                    para.CustRateGrpCode[3] = tNedit_CustRateGrpCodeZero3.GetInt();
                }
                else
                {
                    para.CustRateGrpCode[3] = -1;
                }

                if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero4.Text))
                {
                    para.CustRateGrpCode[4] = tNedit_CustRateGrpCodeZero4.GetInt();
                }
                else
                {
                    para.CustRateGrpCode[4] = -1;
                }

                if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero5.Text))
                {
                    para.CustRateGrpCode[5] = tNedit_CustRateGrpCodeZero5.GetInt();
                }
                else
                {
                    para.CustRateGrpCode[5] = -1;
                }
            }

            //���ݒ�
            //�폜�敪�u�P�i�ݒ�v�Ŋ��A�w��敪�u���Ӑ�|���f�v�Ŋ��A�u���ݒ�v�`�F�b�N�L��̏ꍇ
            if (((int)tComboEditor_DeleteDiv.Value == 2 || (int)tComboEditor_DeleteDiv.Value == 0) && (int)tComboEditor_SettingDiv.Value == 1 && uCheckEditor_unSetting.Checked == true)
            {
                para.UnSettingFlg = true;
            }
            else
            {
                para.UnSettingFlg = false;
            }

        }
        #endregion �ۑ�


        #endregion �� Private Methods

        #region �� Control Events
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃t�H�[�J�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2010/09/03 �k���r #13972�̂U�̑Ή�</br>
        /// <br>Update Note: 2010/09/06 ������ #14238�Ή�</br>
        /// <br>Update Note: 2010/09/08 �� �� #14384�Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // �폜�敪
                #region �폜�敪
                case "tComboEditor_DeleteDiv":
                    {
                        if (tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[0].DataValue
                            || tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[1].DataValue
                            || tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[2].DataValue)
                        {
                            _preComboDeleteDivValue = tComboEditor_DeleteDiv.Value;

                            SettingUnSettingToolEnabled();
                        }
                        else
                        {
                            tComboEditor_DeleteDiv.Value = _preComboDeleteDivValue;
                        }

                        //-----ADD 2010/09/06---------->>>>>
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        //-----ADD 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                // �w��敪
                #region �w��敪
                case "tComboEditor_SettingDiv":
                    {
                        if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[0].DataValue
                            || tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
                        {
                            _preComboSettingDivValue = tComboEditor_SettingDiv.Value;

                            if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[0].DataValue)
                            {
                                // ���Ӑ�
                                this.panel_Customer.Visible = true;
                                this.panel_CustRateGrp.Visible = false;
                                //---UPD 2010/09/08------------------>>>>>
                                //this.tEdit_SectionCodeAllowZero.Focus();
                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    }
                                }
                                //---UPD 2010/09/08------------------<<<<<
                            }
                            else if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
                            {
                                // ���Ӑ�|���f
                                this.panel_Customer.Visible = false;
                                this.panel_CustRateGrp.Visible = true;
                                //-----UPD 2010/09/03---------->>>>>
                                //this.tEdit_OriginSectionCodeAllowZeroD.Focus();
                                //e.NextCtrl = this.tEdit_OriginSectionCodeAllowZeroD;    // DEL 2010/09/06
                                //-----UPD 2010/09/03----------<<<<<

                                //-----ADD 2010/09/06---------->>>>>
                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                                    {
                                        e.NextCtrl = this.tEdit_OriginSectionCodeAllowZeroD;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    }
                                }
                                //-----ADD 2010/09/06----------<<<<<

                                SettingUnSettingToolEnabled();
                            }
                        }
                        else
                        {
                            tComboEditor_SettingDiv.Value = _preComboSettingDivValue;
                        }

                        //-----ADD 2010/09/06---------->>>>>
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                this.tComboEditor_SettingDiv.Focus();
                            }
                        }
                        //-----ADD 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                // ���p���ݒ�.���_�R�[�h
                #region ���p���ݒ�.���_�R�[�h
                case "tEdit_OriginSectionCodeAllowZeroD":
                    {

                        if (this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim() == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._OrigintmpSectionCode = string.Empty;
                            this.tEdit_OriginSectionName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim().Equals(this._OrigintmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero1;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���_�R�[�h�擾
                            string sectionCode = this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim();

                            string sectionName = GetSectionName(sectionCode).Trim();

                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_OriginSectionName.DataText = sectionName;

                                // �ݒ�l��ۑ�
                                this._OrigintmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tEdit_OriginSectionCodeAllowZeroD.DataText = _OrigintmpSectionCode;

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���_�����݂��܂���B",                             // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero1;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }

                        break;
                    }

                #endregion

                //���p��ݒ�.���_�R�[�h
                #region ���p��ݒ�.���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpSectionCode = string.Empty;
                            this.tEdit_SectionName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim().Equals(this._tmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD1;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���_�R�[�h�擾
                            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                            string sectionName = GetSectionName(sectionCode).Trim();

                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_SectionName.DataText = sectionName;

                                // �ݒ�l��ۑ�
                                this._tmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tEdit_SectionCodeAllowZero.DataText = _tmpSectionCode;

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���_�����݂��܂���B",                             // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD1;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }

                        break;
                    }

                #endregion

                //���p��ݒ�.���Ӑ�R�[�h1
                #region ���p��ݒ�.���Ӑ�R�[�h1
                case "tNedit_CustomerCodeD1":
                    {
                        if (tNedit_CustomerCodeD1.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode1 = 0;
                            this.tEdit_CustomerName1.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCodeD1.GetInt() == this._tmpCustomerCode1)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD2;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���Ӑ�R�[�h�擾
                            int customerCode = this.tNedit_CustomerCodeD1.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_CustomerName1.DataText = customerName;

                                // �ݒ�l��ۑ�
                                this._tmpCustomerCode1 = customerCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_CustomerCodeD1.SetInt(_tmpCustomerCode1);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���Ӑ悪���݂��܂���B",                           // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD2;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�R�[�h2
                #region ���p��ݒ�.���Ӑ�R�[�h2
                case "tNedit_CustomerCodeD2":
                    {
                        if (tNedit_CustomerCodeD2.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode2 = 0;
                            this.tEdit_CustomerName2.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCodeD2.GetInt() == this._tmpCustomerCode2)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD3;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���Ӑ�R�[�h�擾
                            int customerCode = this.tNedit_CustomerCodeD2.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_CustomerName2.DataText = customerName;

                                // �ݒ�l��ۑ�
                                this._tmpCustomerCode2 = customerCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_CustomerCodeD2.SetInt(_tmpCustomerCode2);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���Ӑ悪���݂��܂���B",                           // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD3;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�R�[�h3
                #region ���p��ݒ�.���Ӑ�R�[�h3
                case "tNedit_CustomerCodeD3":
                    {
                        if (tNedit_CustomerCodeD3.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode3 = 0;
                            this.tEdit_CustomerName3.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCodeD3.GetInt() == this._tmpCustomerCode3)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD4;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���Ӑ�R�[�h�擾
                            int customerCode = this.tNedit_CustomerCodeD3.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_CustomerName3.DataText = customerName;

                                // �ݒ�l��ۑ�
                                this._tmpCustomerCode3 = customerCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_CustomerCodeD3.SetInt(_tmpCustomerCode3);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���Ӑ悪���݂��܂���B",                           // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD4;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�R�[�h4
                #region ���p��ݒ�.���Ӑ�R�[�h4
                case "tNedit_CustomerCodeD4":
                    {
                        if (tNedit_CustomerCodeD4.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode4 = 0;
                            this.tEdit_CustomerName4.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCodeD4.GetInt() == this._tmpCustomerCode4)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD5;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���Ӑ�R�[�h�擾
                            int customerCode = this.tNedit_CustomerCodeD4.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_CustomerName4.DataText = customerName;

                                // �ݒ�l��ۑ�
                                this._tmpCustomerCode4 = customerCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_CustomerCodeD4.SetInt(_tmpCustomerCode4);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���Ӑ悪���݂��܂���B",                           // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCodeD5;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�R�[�h5
                #region ���p��ݒ�.���Ӑ�R�[�h5
                case "tNedit_CustomerCodeD5":
                    {
                        if (tNedit_CustomerCodeD5.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode5 = 0;
                            this.tEdit_CustomerName5.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCodeD5.GetInt() == this._tmpCustomerCode5)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    //-----UPD 2010/09/06---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    e.NextCtrl = null;
                                    //-----UPD 2010/09/06----------<<<<<
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // ���Ӑ�R�[�h�擾
                            int customerCode = this.tNedit_CustomerCodeD5.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_CustomerName5.DataText = customerName;

                                // �ݒ�l��ۑ�
                                this._tmpCustomerCode5 = customerCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_CustomerCodeD5.SetInt(_tmpCustomerCode5);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                    this.Name,											// �A�Z���u��ID
                                    "���Ӑ悪���݂��܂���B",                           // �\�����郁�b�Z�[�W
                                    -1,													// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);								// �\������{�^��

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    //-----UPD 2010/09/06---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    e.NextCtrl = null;
                                    //-----UPD 2010/09/06----------<<<<<
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // �t�H�[�J�X�ړ�
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�|���O���[�v�R�[�h1
                #region ���p��ݒ�.���Ӑ�|���O���[�v�R�[�h1
                case "tNedit_CustRateGrpCodeZero1":
                    {
                        if (this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerGrpCode1 = -1;
                            this.tEdit_CustomerGrpName1.DataText = string.Empty;

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustRateGrpCodeZero1.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_CustomerGrpName1.DataText = customerName;


                            this.tNedit_CustRateGrpCodeZero1.DataText = customerCode.ToString("0000");

                            // �ݒ�l��ۑ�
                            this._tmpCustomerGrpCode1 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerGrpCode1 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero1.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero1.SetInt(_tmpCustomerGrpCode1);
                            }

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���Ӑ�|���O���[�v�����݂��܂���B",               // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero2;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // �t�H�[�J�X�ړ�
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�|���O���[�v�R�[�h2
                #region ���p��ݒ�.���Ӑ�|���O���[�v�R�[�h2
                case "tNedit_CustRateGrpCodeZero2":
                    {
                        if (this.tNedit_CustRateGrpCodeZero2.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerGrpCode2 = -1;
                            this.tEdit_CustomerGrpName2.DataText = string.Empty;

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustRateGrpCodeZero2.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_CustomerGrpName2.DataText = customerName;


                            this.tNedit_CustRateGrpCodeZero2.DataText = customerCode.ToString("0000");

                            // �ݒ�l��ۑ�
                            this._tmpCustomerGrpCode2 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerGrpCode2 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero2.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero2.SetInt(_tmpCustomerGrpCode2);   
                            }

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���Ӑ�|���O���[�v�����݂��܂���B",               // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero3;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // �t�H�[�J�X�ړ�
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�|���O���[�v�R�[�h3
                #region ���p��ݒ�.���Ӑ�|���O���[�v�R�[�h3
                case "tNedit_CustRateGrpCodeZero3":
                    {
                        if (this.tNedit_CustRateGrpCodeZero3.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerGrpCode3 = -1;
                            this.tEdit_CustomerGrpName3.DataText = string.Empty;

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustRateGrpCodeZero3.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_CustomerGrpName3.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero3.DataText = customerCode.ToString("0000");

                            // �ݒ�l��ۑ�
                            this._tmpCustomerGrpCode3 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerGrpCode3 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero3.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero3.SetInt(_tmpCustomerGrpCode3);
                            }

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���Ӑ�|���O���[�v�����݂��܂���B",               // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero4;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // �t�H�[�J�X�ړ�
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�|���O���[�v�R�[�h4
                #region ���p��ݒ�.���Ӑ�|���O���[�v�R�[�h4
                case "tNedit_CustRateGrpCodeZero4":
                    {
                        if (this.tNedit_CustRateGrpCodeZero4.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerGrpCode4 = -1;
                            this.tEdit_CustomerGrpName4.DataText = string.Empty;

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustRateGrpCodeZero4.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_CustomerGrpName4.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero4.DataText = customerCode.ToString("0000");

                            // �ݒ�l��ۑ�
                            this._tmpCustomerGrpCode4 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (_tmpCustomerGrpCode4 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero4.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero4.SetInt(_tmpCustomerGrpCode4);
                            }
                            

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���Ӑ�|���O���[�v�����݂��܂���B",               // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero5;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // �t�H�[�J�X�ړ�
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�|���O���[�v�R�[�h5
                #region ���p��ݒ�.���Ӑ�|���O���[�v�R�[�h5
                case "tNedit_CustRateGrpCodeZero5":
                    {
                        if (this.tNedit_CustRateGrpCodeZero5.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerGrpCode5 = -1;
                            this.tEdit_CustomerGrpName5.DataText = string.Empty;

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustRateGrpCodeZero5.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_CustomerGrpName5.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero5.DataText = customerCode.ToString("0000");

                            // �ݒ�l��ۑ�
                            this._tmpCustomerGrpCode5 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerGrpCode5 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero5.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero5.SetInt(_tmpCustomerGrpCode5);
                            }

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 									// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���Ӑ�|���O���[�v�����݂��܂���B",               // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                if (uCheckEditor_unSetting.Enabled)
                                {
                                    e.NextCtrl = this.uCheckEditor_unSetting;
                                }
                                else
                                {
                                    //-----UPD 2010/09/06---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    e.NextCtrl = null;
                                    //-----UPD 2010/09/06----------<<<<<
                                }
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // �t�H�[�J�X�ړ�
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //-----ADD 2010/09/06---------->>>>>
                //���p��ݒ�.���Ӑ�K�C�h5
                #region ���p��ݒ�.���Ӑ�K�C�h5
                case "uButton_CustomerGuide5":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���ݒ�
                #region ���p��ݒ�.���ݒ�
                case "uCheckEditor_unSetting":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion

                //���p��ݒ�.���Ӑ�|���O���[�v�K�C�h5
                #region ���p��ݒ�.���Ӑ�|���O���[�v�K�C�h5
                case "uButton_CustomerGrpGuide5":
                    {
                        if (!this.uCheckEditor_unSetting.Enabled)
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                {
                                    e.NextCtrl = this.uCheckEditor_unSetting;
                                }
                            }
                        }
                        break;
                    }
                #endregion
                //-----ADD 2010/09/06----------<<<<<
            }

            //---------------------------------------------------------------
            // �{�^���c�[���L�������ݒ菈��
            //---------------------------------------------------------------
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void OriginSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    //���p���ݒ�.���_�R�[�h
                    if (((UltraButton)sender).Tag.ToString().CompareTo("0") == 0)
                    {
                        this.tEdit_OriginSectionCodeAllowZeroD.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_OriginSectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // �ݒ�l��ۑ�
                        this._OrigintmpSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero1);

                    }
                    //���p��ݒ�.���_�R�[�h
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // �ݒ�l��ۑ�
                        this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustomerCodeD1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD1);
                    }
                    else
                    {
                        return;
                    }

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _customerTag = ((UltraButton)sender).Tag.ToString();

                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

                customerSearchForm.ShowDialog(this);

                if (customerSearchForm.DialogResult == DialogResult.OK || customerSearchForm.DialogResult == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.Retry;
                }

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    if (_customerTag.CompareTo("0") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SettingGuideButtonToolEnabled(this.tEdit_SectionCodeAllowZero);
                    }
                    else if (_customerTag.CompareTo("1") == 0)
                    {
                        this.tNedit_CustomerCodeD2.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD2);
                    }
                    else if (_customerTag.CompareTo("2") == 0)
                    {
                        this.tNedit_CustomerCodeD3.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD3);
                    }
                    else if (_customerTag.CompareTo("3") == 0)
                    {
                        this.tNedit_CustomerCodeD4.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD4);
                    }
                    else if (_customerTag.CompareTo("4") == 0)
                    {
                        this.tNedit_CustomerCodeD5.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD5);
                    }
                    else if (_customerTag.CompareTo("5") == 0)
                    {
                        this.tComboEditor_DeleteDiv.Focus();
                        this.SettingGuideButtonToolEnabled(this.tComboEditor_DeleteDiv);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            //���p��ݒ�.���Ӑ�1
            if (_customerTag.CompareTo("1") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode1 ||
                    this.tEdit_CustomerName1.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode1 = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCodeD1.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName1.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //���p��ݒ�.���Ӑ�2
            else if (_customerTag.CompareTo("2") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode2 ||
                    this.tEdit_CustomerName2.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode2 = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCodeD2.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName2.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //���p��ݒ�.���Ӑ�3
            else if (_customerTag.CompareTo("3") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode3 ||
                    this.tEdit_CustomerName3.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode3 = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCodeD3.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName3.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //���p��ݒ�.���Ӑ�4
            else if (_customerTag.CompareTo("4") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode4 ||
                    this.tEdit_CustomerName4.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode4 = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCodeD4.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName4.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //���p��ݒ�.���Ӑ�5
            else if (_customerTag.CompareTo("5") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode5 ||
                    this.tEdit_CustomerName5.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode5 = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCodeD5.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName5.DataText = customerSearchRet.Snm.Trim();
                }
            }

            this._cusotmerGuideSelected = true;
        }


        /// <summary>
        /// Button_Click �C�x���g(CustRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�|���O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note: 2010/09/03 �k���r #13972�̂U�̑Ή�</br>
        /// </remarks>
        private void uButton_CustomerGrpGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _customerTag = ((UltraButton)sender).Tag.ToString();
                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                // ���Ӑ�|���O���[�v�K�C�h
                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);

                this.DialogResult = DialogResult.Retry;

                if (status == 0)
                {
                    //���p��ݒ�.���Ӑ�|���O���[�v1
                    if (_customerTag.CompareTo("1") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode1 ||
                            this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerGrpCode1 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero1.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName1.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero2.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero2);
                    }
                    //���p��ݒ�.���Ӑ�|���O���[�v2
                    else if (_customerTag.CompareTo("2") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode2 ||
                            this.tNedit_CustRateGrpCodeZero2.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerGrpCode2 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero2.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName2.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero3.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero3);
                    }
                    //���p��ݒ�.���Ӑ�|���O���[�v3
                    else if (_customerTag.CompareTo("3") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode3 ||
                            this.tNedit_CustRateGrpCodeZero3.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerGrpCode3 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero3.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName3.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero4.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero4);
                    }
                    //���p��ݒ�.���Ӑ�|���O���[�v4
                    else if (_customerTag.CompareTo("4") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode4 ||
                            this.tNedit_CustRateGrpCodeZero4.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerGrpCode4 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero4.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName4.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero5.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero5);
                    }
                    //���p��ݒ�.���Ӑ�|���O���[�v5
                    else if (_customerTag.CompareTo("5") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode5 ||
                            this.tNedit_CustRateGrpCodeZero5.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerGrpCode5 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero5.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName5.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tComboEditor_DeleteDiv.Focus();
                        //-----UPD 2010/09/03---------->>>>>
                        this.SettingGuideButtonToolEnabled(this.tComboEditor_DeleteDiv);
                        //-----UPD 2010/09/03----------<<<<<
                    }

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �t�H�[���N���[�W���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���[�W���O�C�x���g�ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09461UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ToolClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();

                        break;
                    }
                case "ButtonTool_Save":
                    {
                        Control nextControl = null;
                        Control preControl = null;
                        
                        ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GetActiveControl(), nextControl);
                        preControl = ex.PrevCtrl;
                        this.tRetKeyControl1_ChangeFocus(this, ex);
                        // �ۑ�����
                        if (preControl != ex.NextCtrl)
                        {
                            Save();
                        }
                        break;
                    }
                case "ButtonTool_Guide":
                    {
                        // �K�C�h�N������
                        this.ExecuteGuide();

                        break;
                    }
            }
        }

        /// <summary>
        /// �A�N�e�B�u�R���g���[���擾����
        /// </summary>
        /// <returns></returns>
        private Control GetActiveControl()
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                ctrl = this.GetParentControl(ctrl);
            }

            return ctrl;
        }

        /// <summary>
        /// �e�R���g���[���擾����
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private Control GetParentControl(Control ctrl)
        {
            Control retCtrl = ctrl;
            if (ctrl.Parent != null)
            {
                if ((ctrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    //retCtrl = ctrl.Parent;
                    retCtrl = GetParentControl(ctrl.Parent);
                }
            }

            return retCtrl;
        }

        /// <summary>
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ԋu���߂���x�Ɏ��ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tComboEditor_DeleteDiv.Focus();
            this.SettingGuideButtonToolEnabled(this.tComboEditor_DeleteDiv);

            this.panel_Customer.Visible = true;
            this.panel_CustRateGrp.Visible = false;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[����Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09461UB_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero1_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero1.GetInt();

            this.tNedit_CustRateGrpCodeZero1.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero1.SelectAll();
        }

        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero2_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero2.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero2.GetInt();

            this.tNedit_CustRateGrpCodeZero2.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero2.SelectAll();
        }

        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero3_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero3.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero3.GetInt();

            this.tNedit_CustRateGrpCodeZero3.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero3.SelectAll();
        }

        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero4_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero4.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero4.GetInt();

            this.tNedit_CustRateGrpCodeZero4.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero4.SelectAll();
        }

        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero5_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero5.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero5.GetInt();

            this.tNedit_CustRateGrpCodeZero5.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero5.SelectAll();
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ώۋ敪�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/08 �� �� #14384�Ή�</br>
        /// </remarks>
        private void tComboEditor_DeleteDiv_SelectionChanged(object sender, EventArgs e)
        {
            //---UPD 2010/09/08------------------>>>>> 
            //_preComboDeleteDivValue = tComboEditor_DeleteDiv.Value;
            if (this.tComboEditor_DeleteDiv.Value != null)
            {
                _preComboDeleteDivValue = tComboEditor_DeleteDiv.Value;
            }
            //---UPD 2010/09/08------------------<<<<<
            SettingUnSettingToolEnabled();
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ώۋ敪�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/08 �� �� #14384�Ή�</br>
        /// </remarks>
        private void tComboEditor_SettingDiv_SelectionChanged(object sender, EventArgs e)
        {
            //---UPD 2010/09/08------------------>>>>> 
            //_preComboSettingDivValue = tComboEditor_SettingDiv.Value;
            if (this.tComboEditor_SettingDiv.Value != null)
            {
                _preComboSettingDivValue = tComboEditor_SettingDiv.Value;
            }
            //---UPD 2010/09/08------------------<<<<<

            if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[0].DataValue)
            {
                // ���Ӑ�
                this.panel_Customer.Visible = true;
                this.panel_CustRateGrp.Visible = false;
            }
            else if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
            {
                // ���Ӑ�|���f
                this.panel_Customer.Visible = false;
                this.panel_CustRateGrp.Visible = true;
                SettingUnSettingToolEnabled();
            }
        }

        #endregion �� Control Events

    }
}