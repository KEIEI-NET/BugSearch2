//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����@���Ӑ���p�o�^
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/08/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/08/31  �C�����e : #14019�̂P�̑Ή�
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
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �P�i�����@���Ӑ���p�o�^UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �P�i�����@���Ӑ���p�o�^UI�t�H�[���N���X</br>
    /// <br>Programmer  : ���M</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>Update Note : 2010/08/31 �k���r #14019�̂P�̑Ή��B</br>
    /// <br>Update Note : 2010/09/06 ������ #14238�Ή�</br>
    /// </remarks>
    public partial class PMKHN09461UC : Form
    {
        #region �� Private Members
        private string _enterpriseCode;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// �K�C�h�{�^��

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private SecInfoAcs _secInfoAcs = null;                                 // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;                           // ���_���ݒ�A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs = null;   

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private string _OrigintmpSectionCode;
        private int _tmpCustomerCode;
        private string _tmpSectionCode;
        private int _tmpCustomerCode1;
        private int _tmpCustomerCode2;
        private int _tmpCustomerCode3;
        private int _tmpCustomerCode4;
        private int _tmpCustomerCode5;
        private object _preComboEditorValue;

        private bool _cusotmerGuideSelected;                // ���Ӑ�K�C�h�I���t���O

        private GoodsRateSetSearchParam _extrInfo;

        private string _customerTag;

        private const string CUSTOMERNOFOUND = "���o�^";

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
        private const string ctGUIDE_NAME_OriginSectionGuide = "OriginSectionGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_Customer1Guide = "Customer1Guide";
        private const string ctGUIDE_NAME_Customer2Guide = "Customer2Guide";
        private const string ctGUIDE_NAME_Customer3Guide = "Customer3Guide";
        private const string ctGUIDE_NAME_Customer4Guide = "Customer4Guide";
        private const string ctGUIDE_NAME_Customer5Guide = "Customer5Guide";

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
        public PMKHN09461UC(GoodsRateSetSearchParam extrInfo)
        {
            InitializeComponent();


            _extrInfo = extrInfo;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._goodsRateSetUpdateAcs = new CustomerCodeRateSetUpdateAcs();

            // �e��}�X�^�Ǎ�
            LoadSecInfoSet();
            LoadCustomerSearchRet();

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

            this._guideEnableControlDictionary.Add(this.tEdit_OriginSectionCodeAllowZero.Name, ctGUIDE_NAME_OriginSectionGuide);        // ���p���ݒ�.���_
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);                          // ���p���ݒ�.���Ӑ�R�[�h
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);                    // ���p��ݒ�.���_
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode1.Name, ctGUIDE_NAME_Customer1Guide);                        // ���p��ݒ�.���Ӑ�R�[�h1
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode2.Name, ctGUIDE_NAME_Customer2Guide);                        // ���p��ݒ�.���Ӑ�R�[�h2
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode3.Name, ctGUIDE_NAME_Customer3Guide);                        // ���p��ݒ�.���Ӑ�R�[�h3
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode4.Name, ctGUIDE_NAME_Customer4Guide);                        // ���p��ݒ�.���Ӑ�R�[�h4
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode5.Name, ctGUIDE_NAME_Customer5Guide);                        // ���p��ݒ�.���Ӑ�R�[�h5

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.OriginSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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

            this._OrigintmpSectionCode = "00";
            this.tEdit_OriginSectionCodeAllowZero.DataText = "00";
            this.tEdit_OriginSectionName.DataText = "�S��";

            // �敪
            this.tComboEditor_UpdateDiv.SelectedIndex = 0;
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
                    case ctGUIDE_NAME_CustomerGuide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
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
                }
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

            // ��ʏ��`�F�b�N
            bool bStatus = CheckSaveCondition();
            if (!bStatus)
            {
                return -1;
            }
            // ��ʏ��擾
            SetExtrInfo(ref this._extrInfo);

            // �X�V����
            status = this._goodsRateSetUpdateAcs.CustomerUpdate(this._extrInfo);

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
        /// <br>Update Note : 2010/08/31 �k���r #14019�̂P�̑Ή��B</br>
        /// </remarks>
        private bool CheckSaveCondition()
        {
            string errMsg = "";
            Control nextCtrl = null;

            try
            {
                // ���p���@���Ӑ�R�[�h
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "���p����񂪐ݒ肳��Ă܂���B";
                    this.tNedit_CustomerCode.Focus();
                    nextCtrl = this.tNedit_CustomerCode;
                    return (false);
                }

                // ���p��@���Ӑ�R�[�h
                //-----ADD 2010/08/31---------->>>>>
                if (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().Equals(this.tEdit_SectionCodeAllowZero.DataText.Trim()))
                {
                //-----ADD 2010/08/31----------<<<<<
                    if (this.tNedit_CustomerCode1.GetInt() == 0 && this.tNedit_CustomerCode2.GetInt() == 0
                        && this.tNedit_CustomerCode3.GetInt() == 0 && this.tNedit_CustomerCode4.GetInt() == 0
                        && this.tNedit_CustomerCode5.GetInt() == 0)
                    {
                        errMsg = "���p���񂪐ݒ肳��Ă܂���B";
                        this.tNedit_CustomerCode1.Focus();
                        nextCtrl = this.tNedit_CustomerCode1;
                        return (false);
                    }

                    if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode1.GetInt())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�ݒ肪�s���ł��B";
                        this.tNedit_CustomerCode1.Focus();
                        nextCtrl = this.tNedit_CustomerCode1;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode2.GetInt())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�ݒ肪�s���ł��B";
                        this.tNedit_CustomerCode2.Focus();
                        nextCtrl = this.tNedit_CustomerCode2;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode3.GetInt())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�ݒ肪�s���ł��B";
                        this.tNedit_CustomerCode3.Focus();
                        nextCtrl = this.tNedit_CustomerCode3;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode4.GetInt())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�ݒ肪�s���ł��B";
                        this.tNedit_CustomerCode4.Focus();
                        nextCtrl = this.tNedit_CustomerCode4;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode5.GetInt())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�ݒ肪�s���ł��B";
                        this.tNedit_CustomerCode5.Focus();
                        nextCtrl = this.tNedit_CustomerCode5;
                        return (false);
                    }
                //-----ADD 2010/08/31---------->>>>>
                }
                //-----ADD 2010/08/31----------<<<<<
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
            // ���p��.���_
            if ((this.tEdit_OriginSectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // �S�Ўw��
                para.SectionCode = null;
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            //���p��.���_�R�[�h
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // �S�Ўw��
                para.PrmSectionCode = null;
            }
            else
            {
                para.PrmSectionCode = new string[1];
                para.PrmSectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            //���p��.���Ӑ�
            para.CustomerCode = new int[6];

            para.CustomerCode[0] = tNedit_CustomerCode.GetInt();

            //���p��.���Ӑ�R�[�h1�`5
            para.CustomerCode[1] = tNedit_CustomerCode1.GetInt();
            para.CustomerCode[2] = tNedit_CustomerCode2.GetInt();
            para.CustomerCode[3] = tNedit_CustomerCode3.GetInt();
            para.CustomerCode[4] = tNedit_CustomerCode4.GetInt();
            para.CustomerCode[5] = tNedit_CustomerCode5.GetInt();

            //�X�V�敪
            para.ObjectDiv = this.tComboEditor_UpdateDiv.Value.ToString();

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
        /// <br>Update Note: 2010/09/06 ������ #14238�Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ���p���ݒ�.���_�R�[�h
                #region ���p���ݒ�.���_�R�[�h
                case "tEdit_OriginSectionCodeAllowZero":
                    {

                        if (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim() == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._OrigintmpSectionCode = string.Empty;
                            this.tEdit_OriginSectionName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().Equals(this._OrigintmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                }
                            }
                            else
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Tab)
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // �t�H�[�J�X�ړ�
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }

                            break;
                        }
                        else
                        {
                            // ���_�R�[�h�擾
                            string sectionCode = this.tEdit_OriginSectionCodeAllowZero.DataText.Trim();

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
                                this.tEdit_OriginSectionCodeAllowZero.DataText = _OrigintmpSectionCode;

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
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                }
                            }
                            else
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Tab)
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // �t�H�[�J�X�ړ�
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                        }

                        break;
                    }

                #endregion

                // ���p���ݒ�.���Ӑ�R�[�h
                #region ���p���ݒ�.���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode = 0;
                            this.tEdit_CustomerName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCode.GetInt() == this._tmpCustomerCode)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
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
                            int customerCode = this.tNedit_CustomerCode.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tEdit_CustomerName.DataText = customerName;

                                // �ݒ�l��ۑ�
                                this._tmpCustomerCode = customerCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_CustomerCode.SetInt(_tmpCustomerCode);

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
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
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
                                    e.NextCtrl = this.tNedit_CustomerCode1;
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
                                    e.NextCtrl = this.tNedit_CustomerCode1;
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
                case "tNedit_CustomerCode1":
                    {
                        if (tNedit_CustomerCode1.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode1 = 0;
                            this.tEdit_CustomerName1.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCode1.GetInt() == this._tmpCustomerCode1)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCode2;
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
                            int customerCode = this.tNedit_CustomerCode1.GetInt();

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
                                this.tNedit_CustomerCode1.SetInt(_tmpCustomerCode1);

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
                                    e.NextCtrl = this.tNedit_CustomerCode2;
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
                case "tNedit_CustomerCode2":
                    {
                        if (tNedit_CustomerCode2.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode2 = 0;
                            this.tEdit_CustomerName2.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCode2.GetInt() == this._tmpCustomerCode2)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCode3;
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
                            int customerCode = this.tNedit_CustomerCode2.GetInt();

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
                                this.tNedit_CustomerCode2.SetInt(_tmpCustomerCode2);

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
                                    e.NextCtrl = this.tNedit_CustomerCode3;
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
                case "tNedit_CustomerCode3":
                    {
                        if (tNedit_CustomerCode3.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode3 = 0;
                            this.tEdit_CustomerName3.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCode3.GetInt() == this._tmpCustomerCode3)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCode4;
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
                            int customerCode = this.tNedit_CustomerCode3.GetInt();

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
                                this.tNedit_CustomerCode3.SetInt(_tmpCustomerCode3);

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
                                    e.NextCtrl = this.tNedit_CustomerCode4;
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
                case "tNedit_CustomerCode4":
                    {
                        if (tNedit_CustomerCode4.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode4 = 0;
                            this.tEdit_CustomerName4.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCode4.GetInt() == this._tmpCustomerCode4)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCode5;
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
                            int customerCode = this.tNedit_CustomerCode4.GetInt();

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
                                this.tNedit_CustomerCode4.SetInt(_tmpCustomerCode4);

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
                                    e.NextCtrl = this.tNedit_CustomerCode5;
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
                case "tNedit_CustomerCode5":
                    {
                        if (tNedit_CustomerCode5.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode5 = 0;
                            this.tEdit_CustomerName5.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_CustomerCode5.GetInt() == this._tmpCustomerCode5)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tComboEditor_UpdateDiv;
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
                            int customerCode = this.tNedit_CustomerCode5.GetInt();

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
                                this.tNedit_CustomerCode5.SetInt(_tmpCustomerCode5);

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
                                    e.NextCtrl = this.tComboEditor_UpdateDiv;
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

                //���p��ݒ�.�X�V�敪
                #region ���p��ݒ�.�X�V�敪
                case "tComboEditor_UpdateDiv":
                    {
                        if (tComboEditor_UpdateDiv.Value == tComboEditor_UpdateDiv.Items[0].DataValue
                            || tComboEditor_UpdateDiv.Value == tComboEditor_UpdateDiv.Items[1].DataValue)
                        {
                            _preComboEditorValue = tComboEditor_UpdateDiv.Value;
                        }
                        else
                        {
                            tComboEditor_UpdateDiv.Value = _preComboEditorValue;
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
                                //e.NextCtrl = this.tEdit_OriginSectionCodeAllowZero;
                                e.NextCtrl = null;
                                //-----UPD 2010/09/06----------<<<<<
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                            //-----ADD 2010/09/06----------<<<<<
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
                        this.tEdit_OriginSectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_OriginSectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // �ݒ�l��ۑ�
                        this._OrigintmpSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustomerCode.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode);

                    }
                    //���p��ݒ�.���_�R�[�h
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // �ݒ�l��ۑ�
                        this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustomerCode1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode1);
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
                        this.tNedit_CustomerCode2.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode2);
                    }
                    else if (_customerTag.CompareTo("2") == 0)
                    {
                        this.tNedit_CustomerCode3.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode3);
                    }
                    else if (_customerTag.CompareTo("3") == 0)
                    {
                        this.tNedit_CustomerCode4.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode4);
                    }
                    else if (_customerTag.CompareTo("4") == 0)
                    {
                        this.tNedit_CustomerCode5.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode5);
                    }
                    else if (_customerTag.CompareTo("5") == 0)
                    {
                        this.tComboEditor_UpdateDiv.Focus();
                        this.SettingGuideButtonToolEnabled(this.tComboEditor_UpdateDiv);
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
            //���p���ݒ�.���Ӑ�
            if (_customerTag.CompareTo("0") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode ||
                    this.tEdit_CustomerName.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //���p��ݒ�.���Ӑ�1
            else if (_customerTag.CompareTo("1") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode1 ||
                    this.tEdit_CustomerName1.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode1 = customerSearchRet.CustomerCode;

                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCode1.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode2.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode3.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode4.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode5.SetInt(customerSearchRet.CustomerCode);

                    // ���Ӑ於��
                    this.tEdit_CustomerName5.DataText = customerSearchRet.Snm.Trim();
                }
            }

            this._cusotmerGuideSelected = true;
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
        private void PMKHN09461UC_FormClosing(object sender, FormClosingEventArgs e)
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
            this.tEdit_OriginSectionCodeAllowZero.Focus();

            this.SettingGuideButtonToolEnabled(this.tEdit_OriginSectionCodeAllowZero);

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
        private void PMKHN09461UC_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
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
        private void tComboEditor_UpdateDiv_SelectionChanged(object sender, EventArgs e)
        {
            //---UPD 2010/09/08------------------>>>>>
            //_preComboEditorValue = tComboEditor_UpdateDiv.Value;
            if (this.tComboEditor_UpdateDiv.Value != null)
            {
                _preComboEditorValue = tComboEditor_UpdateDiv.Value;
            }
            //---UPD 2010/09/08------------------<<<<<
        }

        #endregion �� Control Events

    }
}