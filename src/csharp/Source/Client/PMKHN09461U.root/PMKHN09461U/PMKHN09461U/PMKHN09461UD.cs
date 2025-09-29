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
// �C �� ��  2010/09/01  �C�����e : #14019�̑Ή�
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
//-----ADD 2010/09/01---------->>>>>
using System.IO;
using Broadleaf.Application.Resources;
//-----ADD 2010/09/01----------<<<<<
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �P�i�����@���Ӑ���p�o�^UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �P�i�����@���Ӑ���p�o�^UI�t�H�[���N���X</br>
    /// <br>Programmer  : ���M</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>Update Note : 2010/09/01 �k���r #14019�̑Ή��B</br>
    /// <br>Update Note : 2010/09/06 ������ #14238�Ή�</br>
    /// </remarks>
    public partial class PMKHN09461UD : Form
    {
        #region �� Private Members
        private string _enterpriseCode;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// �K�C�h�{�^��

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, string> _custRateGrpDic;
        private SecInfoAcs _secInfoAcs = null;                                 // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;                           // ���_���ݒ�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			                   // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs = null;
        private MakerAcs _makerAcs;                                            // ���[�J�[�A�N�Z�X�N���X
        private Dictionary<int, MakerUMnt> _makerDic;

        //-----ADD 2010/09/01---------->>>>>
        private GoodsRateSetUpdateFileConst _fileSetting;
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKHN09461U_Construction.XML";

        //-----ADD 2010/09/01----------<<<<<

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private string _OrigintmpSectionCode;
        private int _tmpCustomerCode = -1;
        private string _tmpSectionCode;
        private int _tmpCustomerCode1 = -1;
        private int _tmpCustomerCode2 = -1;
        private int _tmpCustomerCode3 = -1;
        private int _tmpCustomerCode4 = -1;
        private int _tmpCustomerCode5 = -1;
        private object _preComboEditorValue;

        // �O���b�h��
        public const string COLUMN_UPDATEDATETIME = "UpdateDateTime"; //�������t
        public const string COLUMN_SECTIONCODE = "SectionCode"; //���_
        public const string COLUMN_RATESETTINGDIVIDE = "RateSettingDivide";//�|���ݒ�敪
        public const string COLUMN_CUSTRATEGRPCODE = "CustRateGrpCode"; //���Ӑ�|���f
        public const string COLUMN_SUPPLIERCD = "SupplierCd";//�d����
        public const string COLUMN_GOODSMAKERCD = "GoodsMakerCd";//���[�J�[
        public const string COLUMN_GOODSMAKERNAME = "GoodsMakerName";//���[�J�[��
        public const string COLUMN_BLGOODSCODE = "BLGoodsCode";   // �a�k�R�[�h
        public const string COLUMN_GOODSNO = "GoodsNo";   // �i��
        public const string COLUMN_CONTENT = "Content";   // ���e

        /// <summary>�`�F�b�N�����b�Z�[�W�u�t�@�C���ւ̏o�͂Ɏ��s���܂����B�v</summary>
        private const string MSG_OUTPUTFILE_FAILED = "�t�@�C���ւ̏o�͂Ɏ��s���܂����B";
        //-----UPD 2010/09/01---------->>>>>
        ///// <summary>�e�L�X�g�G�N�X�|�[�g���������b�Z�[�W�u �s�̃f�[�^���t�@�C���֏o�͂��܂����B�v</summary>
        //private const string MSG_OUTPUTFILE_SUCCEEDED = "�s�̃f�[�^���t�@�C���֏o�͂��܂����B";
        /// <summary>�e�L�X�g�G�N�X�|�[�g���������b�Z�[�W�u �s�̃f�[�^���`�F�b�N���X�g�֏o�͂��܂����B�v</summary>
        private const string MSG_OUTPUTFILE_SUCCEEDED = "�s�̃f�[�^���`�F�b�N���X�g�֏o�͂��܂����B";
        //-----UPD 2010/09/01---------->>>>>

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

        DataTable _dataTable;

        //-----ADD 2010/09/01---------->>>>>
        #region �v���p�e�B
        public GoodsRateSetUpdateFileConst FileSetting
        {
            get { return this._fileSetting; }
        }
        #endregion �v���p�e�B
        //-----ADD 2010/09/01----------<<<<<
        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// �P�i�����@���Ӑ���p�o�^UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �P�i�����@���Ӑ���p�o�^UI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/01 �k���r #14019�̂R�̑Ή��B</br>
        /// </remarks>
        public PMKHN09461UD(GoodsRateSetSearchParam extrInfo)
        {
            InitializeComponent();


            _extrInfo = extrInfo;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            _goodsRateSetUpdateAcs = new CustomerCodeRateSetUpdateAcs();
            this._makerAcs = new MakerAcs();
            //-----ADD 2010/09/01---------->>>>>
            this._fileSetting = new GoodsRateSetUpdateFileConst();
            //-----ADD 2010/09/01----------<<<<<
            // �e��}�X�^�Ǎ�
            LoadSecInfoSet();
            GetCustRateGrp();
            ReadMakerUMnt();

            // ��ʏ����ݒ�
            SetInitialSetting();

            // ��ʃN���A
            ClearScreen();
            //-----ADD 2010/08/31---------->>>>>
            //-----UPD 2010/09/01---------->>>>>
            this._fileSetting = new GoodsRateSetUpdateFileConst();
            Deserialize();
            if (_fileSetting != null)
            {
                this.tEdit_SettingFileName.Text = _fileSetting.OutputFileName;
            }
            //if (!string.IsNullOrEmpty(_extrInfo.FileName))
            //{
            //    this.tEdit_SettingFileName.Text = _extrInfo.FileName;

            //}

            //-----UPD 2010/09/01----------<<<<<

            //-----ADD 2010/08/31----------<<<<<
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

            this._guideEnableControlDictionary.Add(this.tEdit_OriginSectionCodeAllowZeroG.Name, ctGUIDE_NAME_OriginSectionGuide);        // ���p���ݒ�.���_
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero.Name, ctGUIDE_NAME_CustomerGuide);                          // ���p���ݒ�.���Ӑ�R�[�h
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);                    // ���p��ݒ�.���_
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero1.Name, ctGUIDE_NAME_Customer1Guide);                        // ���p��ݒ�.���Ӑ�R�[�h1
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero2.Name, ctGUIDE_NAME_Customer2Guide);                        // ���p��ݒ�.���Ӑ�R�[�h2
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero3.Name, ctGUIDE_NAME_Customer3Guide);                        // ���p��ݒ�.���Ӑ�R�[�h3
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero4.Name, ctGUIDE_NAME_Customer4Guide);                        // ���p��ݒ�.���Ӑ�R�[�h4
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero5.Name, ctGUIDE_NAME_Customer5Guide);                        // ���p��ݒ�.���Ӑ�R�[�h5

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.OriginSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_FileSelect.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
            this._tmpSectionCode = "00";
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "�S��";

            this._OrigintmpSectionCode = "00";
            this.tEdit_OriginSectionCodeAllowZeroG.DataText = "00";
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

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�J�[�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerDic = new Dictionary<int, MakerUMnt>();
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

        /// <summary>
        /// ���[�J�[���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[��</returns>
        /// <remarks>
        /// <br>Note        : ���[�J�[�R�[�h�ɊY�����閼�̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            if (this._makerDic.ContainsKey(makerCode))
            {
                return this._makerDic[makerCode].MakerName.Trim();
            }

            return "";
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
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_SectionGuide:
                        {
                            this.OriginSectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer1Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide1, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer2Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide2, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer3Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide3, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer4Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide4, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer5Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide5, new EventArgs());
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
        /// <br>Update Note : 2010/09/01 �k���r #14019�̑Ή��B</br>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            List<GoodsRateSetSearchResult> rateSearchResultList;

            // ��ʏ��`�F�b�N
            bool bStatus = CheckSaveCondition();
            if (!bStatus)
            {
                return -1;
            }
            // ��ʏ��擾
            SetExtrInfo(ref this._extrInfo);

            // �X�V����
            status = this._goodsRateSetUpdateAcs.CustomerUpdateGrp(out rateSearchResultList,this._extrInfo);

            if (status == 0 && rateSearchResultList.Count != 0)
            {
                status = ExportIntoTextFile(rateSearchResultList);
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                   "���������ɊY������f�[�^�����݂��܂���B",
                   status,
                   MessageBoxButtons.OK,
                   MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.DialogResult = DialogResult.OK;
                //-----ADD 2010/09/01---------->>>>>
                _fileSetting.OutputFileName = this.tEdit_SettingFileName.Text.ToUpper();
                //-----ADD 2010/09/01----------<<<<<
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
        /// <br>Update Note : 2010/08/31 �k���r #14019�̂Q�̑Ή��B</br>
        /// </remarks>
        private bool CheckSaveCondition()
        {
            string errMsg = "";
            Control nextCtrl = null;

            try
            {
                // ���p���@���Ӑ�R�[�h
                if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero.Text.Trim()))
                {
                    errMsg = "���p����񂪐ݒ肳��Ă܂���B";
                    this.tNedit_CustRateGrpCodeZero.Focus();
                    nextCtrl = this.tNedit_CustRateGrpCodeZero;
                    return (false);
                }

                // ���p��@���Ӑ�R�[�h
                if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim()))
                {
                    errMsg = "���p���񂪐ݒ肳��Ă܂���B";
                    this.tNedit_CustRateGrpCodeZero1.Focus();
                    nextCtrl = this.tNedit_CustRateGrpCodeZero1;
                    return (false);
                }
                //-----ADD 2010/08/31---------->>>>>
                if (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().Equals(this.tEdit_SectionCodeAllowZero.DataText.Trim()))
                {
                //-----ADD 2010/08/31----------<<<<<
                    if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero1.Text.Trim())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�|���O���[�v�ݒ肪�s���ł��B";
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero1;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�|���O���[�v�ݒ肪�s���ł��B";
                        this.tNedit_CustRateGrpCodeZero2.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero2;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero3.Text.Trim())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�|���O���[�v�ݒ肪�s���ł��B";
                        this.tNedit_CustRateGrpCodeZero3.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero3;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�|���O���[�v�ݒ肪�s���ł��B";
                        this.tNedit_CustRateGrpCodeZero4.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero4;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero5.Text.Trim())
                    {
                        errMsg = "���p���A���p��̓��Ӑ�|���O���[�v�ݒ肪�s���ł��B";
                        this.tNedit_CustRateGrpCodeZero5.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero5;
                        return (false);
                    }
                //-----ADD 2010/08/31---------->>>>>
                }
                //-----ADD 2010/08/31----------<<<<<

                // ���p��@�t�@�C����
                if (this.tEdit_SettingFileName.DataText.Trim() == "")
                {
                    errMsg = "�t�@�C�������ݒ肳��Ă��܂���B";
                    this.tEdit_SettingFileName.Focus();
                    nextCtrl = this.tEdit_SettingFileName;
                    return (false);
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
            // ���p��.���_
            if ((this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim() == "") ||
                (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // �S�Ўw��
                para.SectionCode = null;
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().PadLeft(2, '0');
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

            //���p��.���Ӑ�|��
            para.CustRateGrpCode = new int[6];

            para.CustRateGrpCode[0] = tNedit_CustRateGrpCodeZero.GetInt();

            //���p��.���Ӑ�R�[�h1�`5
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

            //�X�V�敪
            para.ObjectDiv = this.tComboEditor_UpdateDiv.Value.ToString();

        }

        /// <summary>
        /// �e�L�X�g�o�͂��܂��B
        /// </summary>
        /// <br>Update Note : 2010/08/31 �k���r #14019�̂Q�̑Ή��B</br>
        private int ExportIntoTextFile(List<GoodsRateSetSearchResult> rateSearchResultList)
        {
            String typeStr = string.Empty;
            Char typeChar = new char();
            Byte typeByte = new byte();
            DateTime typeDate = new DateTime();
            Int16 typeInt16 = new short();
            Int32 typeInt32 = new int();
            Int64 typeInt64 = new long();
            Single typeSingle = new float();
            Double typeDouble = new double();
            Decimal typeDecimal = new decimal();

            FormattedTextWriter tw = new FormattedTextWriter();
            List<String> schemeList = new List<string>();
            schemeList.Add(COLUMN_UPDATEDATETIME);
            schemeList.Add(COLUMN_SECTIONCODE);
            schemeList.Add(COLUMN_RATESETTINGDIVIDE);
            schemeList.Add(COLUMN_CUSTRATEGRPCODE);
            schemeList.Add(COLUMN_SUPPLIERCD);
            schemeList.Add(COLUMN_GOODSMAKERCD);
            schemeList.Add(COLUMN_GOODSMAKERNAME);
            schemeList.Add(COLUMN_BLGOODSCODE);
            schemeList.Add(COLUMN_GOODSNO);
            schemeList.Add(COLUMN_CONTENT);

            // �o�͍��ږ�
            tw.SchemeList = schemeList;
            string content = string.Empty;
            _dataTable.Rows.Clear();

            foreach(GoodsRateSetSearchResult result in rateSearchResultList)
            {
                content = string.Empty;
                DataRow dataRow = _dataTable.NewRow();

                dataRow[COLUMN_UPDATEDATETIME] = TDateTime.DateTimeToString("YYYY/MM/DD",DateTime.Now) ;
                dataRow[COLUMN_SECTIONCODE] = result.SectionCode;
                dataRow[COLUMN_RATESETTINGDIVIDE] = result.RateSettingDivide;
                dataRow[COLUMN_CUSTRATEGRPCODE] = result.CustRateGrpCode.ToString("0000");

                dataRow[COLUMN_SUPPLIERCD] = result.SupplierCd.ToString("000000");
                dataRow[COLUMN_GOODSMAKERCD] = result.GoodsMakerCd.ToString("0000");
                dataRow[COLUMN_GOODSMAKERNAME] = GetMakerName(result.GoodsMakerCd);
                dataRow[COLUMN_BLGOODSCODE] = result.BLGoodsCode.ToString("00000");
                dataRow[COLUMN_GOODSNO] = result.GoodsNo;

                if (result.UpdateDiv == 1)
                {
                    content = "����ں��ނ͈��p���Ɠ��l�ő��݂��܂�";
                }
                else
                {
                    //�����z���ύX��
                    if (result.BfPriceFl != result.PriceFl)
                    {
                        content += "�����z��" + result.BfPriceFl.ToString("########0.00") + "��" + result.PriceFl.ToString("########0.00") ;
                    }
                    //���������ύX��
                    if (result.BfRateVal != result.RateVal)
                    {
                        if (!string .IsNullOrEmpty(content))
                        {
                            content += "�A";
                        }

                        content += "��������" + result.BfRateVal.ToString("##0.00") + "��" + result.RateVal.ToString("##0.00");
                    }
                    //����UP�����ύX��
                    if (result.BfUpRate != result.UpRate)
                    {
                        if (!string.IsNullOrEmpty(content))
                        {
                            content += "�A";
                        }
                        content += "����UP����" + result.BfUpRate.ToString("##0.00") + "��" + result.UpRate.ToString("##0.00");
                    }
                    //�e���m�ۗ����ύX��
                    if (result.BfGrsProfitSecureRate != result.GrsProfitSecureRate)
                    {
                        if (!string.IsNullOrEmpty(content))
                        {
                            content += "�A";
                        }
                        content += "�e���m�ۗ���" + result.BfGrsProfitSecureRate.ToString("#0.00") + "��" + result.GrsProfitSecureRate.ToString("#0.00");
                    }

                    if (!string.IsNullOrEmpty(content))
                    {
                        content += "�֍X�V����܂���";
                    }
                }
                dataRow[COLUMN_CONTENT] = content;

                if (!string.IsNullOrEmpty(content))
                {
                    _dataTable.Rows.Add(dataRow);
                }
            }

            if (_dataTable.Rows.Count == 0) return 0;

            // �f�[�^�\�[�X
            tw.DataSource = _dataTable.DefaultView;

            // �O���b�h�̃\�[�g����K�p����
            if (tw.DataSource is DataView)
            {
                (tw.DataSource as DataView).Sort = COLUMN_SECTIONCODE + "," + COLUMN_RATESETTINGDIVIDE + "," + COLUMN_CUSTRATEGRPCODE + "," + COLUMN_GOODSNO + "," + COLUMN_GOODSMAKERCD + " ASC";
            }

            #region �I�v�V�����Z�b�g
            // �t�@�C����
            tw.OutputFileName = tEdit_SettingFileName.Text;
            // ��؂蕶��
            tw.Splitter = ",";
            // ���ڊ��蕶��
            tw.Encloser = "\"";
            // �Œ蕝
            tw.FixedLength = false;
            // �^�C�g���s�o��
            //-----UPD 2010/08/31---------->>>>>
            if (System.IO.File.Exists(tEdit_SettingFileName.Text))
            {
                tw.CaptionOutput = false;
            }
            else
            {
                tw.CaptionOutput = true;
            }
            //tw.CaptionOutput = true;
            //-----UPD 2010/08/31----------<<<<<
            // �I�_�s�֒ǉ�����
            tw.OutputMode = true;
            // ���ڊ���K�p
            List<Type> enclosingList = new List<Type>();
            enclosingList.Add(typeInt16.GetType());
            enclosingList.Add(typeInt32.GetType());
            enclosingList.Add(typeInt64.GetType());
            enclosingList.Add(typeDouble.GetType());
            enclosingList.Add(typeDecimal.GetType());
            enclosingList.Add(typeSingle.GetType());
            enclosingList.Add(typeStr.GetType());
            enclosingList.Add(typeChar.GetType());
            enclosingList.Add(typeByte.GetType());
            enclosingList.Add(typeDate.GetType());
            tw.EnclosingTypeList = enclosingList;

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            if (status == 9)// �ُ�I��
            {
                // �o�͎��s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILE_FAILED, -1, MessageBoxButtons.OK);
            }
            else
            {
                // �o�͐���
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + MSG_OUTPUTFILE_SUCCEEDED, -1, MessageBoxButtons.OK);
            }

            return status;

            #endregion // �I�v�V����
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
                case "tEdit_OriginSectionCodeAllowZeroG":
                    {

                        if (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim() == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._OrigintmpSectionCode = string.Empty;
                            this.tEdit_OriginSectionName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().Equals(this._OrigintmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero;
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
                            string sectionCode = this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim();

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
                                this.tEdit_OriginSectionCodeAllowZeroG.DataText = _OrigintmpSectionCode;

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
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero;
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

                // ���p���ݒ�.���Ӑ�|���O���[�v�R�[�h
                #region ���p���ݒ�.���Ӑ�|���O���[�v�R�[�h
                case "tNedit_CustRateGrpCodeZero":
                    {
                        if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode = -1;
                            this.tEdit_CustomerGrpName.DataText = string.Empty;
                            this.tNedit_CustRateGrpCodeZero.Clear();

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustRateGrpCodeZero.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_CustomerGrpName.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero.DataText = customerCode.ToString("0000");

                            // �ݒ�l��ۑ�
                            this._tmpCustomerCode = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (_tmpCustomerCode == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero.SetInt(_tmpCustomerCode);
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

                //���p��ݒ�.���Ӑ�|���O���[�v�R�[�h1
                #region ���p��ݒ�.���Ӑ�|���O���[�v�R�[�h1
                case "tNedit_CustRateGrpCodeZero1":
                    {
                        if (this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == "")
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpCustomerCode1 = -1;
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
                            this._tmpCustomerCode1 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerCode1 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero1.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero1.SetInt(_tmpCustomerCode1);
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
                            this._tmpCustomerCode2 = -1;
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
                            this._tmpCustomerCode2 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerCode2 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero2.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero2.SetInt(_tmpCustomerCode2);
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
                            this._tmpCustomerCode3 = -1;
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
                            this._tmpCustomerCode3 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerCode3 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero3.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero3.SetInt(_tmpCustomerCode3);
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
                            this._tmpCustomerCode4 = -1;
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
                            this._tmpCustomerCode4 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerCode4 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero4.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero4.SetInt(_tmpCustomerCode4);
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
                            this._tmpCustomerCode5 = -1;
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
                            this._tmpCustomerCode5 = customerCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            if (this._tmpCustomerCode5 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero5.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero5.SetInt(_tmpCustomerCode5);
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
                                e.NextCtrl = this.tEdit_SettingFileName;
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

                //-----ADD 2010/09/06---------->>>>>
                //�`�F�b�N���X�g.�t�@�C����
                #region �`�F�b�N���X�g.�t�@�C����
                case "uButton_FileSelect":
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

                //�K�C�h�{�^�����灨�ŁA�ړ����Ȃ�
                #region �K�C�h�{�^
                case "OriginSectionGuide_Button":
                case "uButton_CustomerGrpGuide":
                case "SectionGuide_Button":
                case "uButton_CustomerGrpGuide1":
                case "uButton_CustomerGrpGuide2":
                case "uButton_CustomerGrpGuide3":
                case "uButton_CustomerGrpGuide4":
                case "uButton_CustomerGrpGuide5":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
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
                        this.tEdit_OriginSectionCodeAllowZeroG.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_OriginSectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // �ݒ�l��ۑ�
                        this._OrigintmpSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero);

                    }
                    //���p��ݒ�.���_�R�[�h
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // �ݒ�l��ۑ�
                        this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero1);
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
        /// Button_Click �C�x���g(CustRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�|���O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
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
                    //���p���ݒ�.���Ӑ�|���O���[�v
                    if (_customerTag.CompareTo("0") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode ||
                            this.tNedit_CustRateGrpCodeZero.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SettingGuideButtonToolEnabled(this.tEdit_SectionCodeAllowZero);
                    }
                    //���p��ݒ�.���Ӑ�|���O���[�v1
                    else if (_customerTag.CompareTo("1") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode1 ||
                            this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode1 = userGdBd.GuideCode;
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
                            this._tmpCustomerCode2 = userGdBd.GuideCode;
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
                            this._tmpCustomerCode3 = userGdBd.GuideCode;
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
                            this._tmpCustomerCode4 = userGdBd.GuideCode;
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
                            this._tmpCustomerCode5 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero5.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName5.DataText = userGdBd.GuideName.Trim();
                        // �t�H�[�J�X�ݒ�
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
        /// �t�H�[���N���[�W���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���[�W���O�C�x���g�ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/01 �k���r #14019�̂R�̑Ή��B</br>
        /// </remarks>
        private void PMKHN09461UD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
            //-----ADD 2010/09/01---------->>>>>
            else 
            {
                Serialize();
            }
            //-----ADD 2010/09/01----------<<<<<
        }

        //-----ADD 2010/09/01---------->>>>>
        /// <summary>
        ///  �P�i�����ݒ�ꊇ�o�^�E�C���̃V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       :  �P�i�����ݒ�ꊇ�o�^�E�C���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer :  �k���r</br>
        /// <br>Date       :  2010/09/01</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_fileSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C���̃f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �P�i�����ݒ�ꊇ�o�^�E�C���N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/09/01</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._fileSetting = UserSettingController.DeserializeUserSetting<GoodsRateSetUpdateFileConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                catch
                {
                    this._fileSetting = new GoodsRateSetUpdateFileConst();
                }
            }
        }
        //-----ADD 2010/09/01----------<<<<<

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
            this.tEdit_OriginSectionCodeAllowZeroG.Focus();

            this.SettingGuideButtonToolEnabled(this.tEdit_OriginSectionCodeAllowZeroG);

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
        private void PMKHN09461UD_Load(object sender, EventArgs e)
        {
            // �O���b�h�f�[�^�ݒ�
            CreateGrid();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �O���b�h�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <param name="displayList">�\���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�̗���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public void CreateGrid()
        {
            _dataTable = new DataTable();
            // �������t
            _dataTable.Columns.Add(COLUMN_UPDATEDATETIME, typeof(string));
            // ���_
            _dataTable.Columns.Add(COLUMN_SECTIONCODE, typeof(string));
            // �|���ݒ�敪
            _dataTable.Columns.Add(COLUMN_RATESETTINGDIVIDE, typeof(string));
            // ���Ӑ�|���f
            _dataTable.Columns.Add(COLUMN_CUSTRATEGRPCODE, typeof(string));
            // �d����
            _dataTable.Columns.Add(COLUMN_SUPPLIERCD, typeof(string));
            // ���[�J�[
            _dataTable.Columns.Add(COLUMN_GOODSMAKERCD, typeof(string));
            // ���[�J�[��
            _dataTable.Columns.Add(COLUMN_GOODSMAKERNAME, typeof(string));
            // �a�k�R�[�h
            _dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
            // �i��
            _dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // ���e
            _dataTable.Columns.Add(COLUMN_CONTENT, typeof(string));

            _dataTable.Columns[COLUMN_UPDATEDATETIME].Caption = "�������t";
            _dataTable.Columns[COLUMN_SECTIONCODE].Caption = "���_";
            _dataTable.Columns[COLUMN_RATESETTINGDIVIDE].Caption = "�|���ݒ�敪";
            _dataTable.Columns[COLUMN_CUSTRATEGRPCODE].Caption = "���Ӑ�|���f";
            _dataTable.Columns[COLUMN_SUPPLIERCD].Caption = "�d����";
            _dataTable.Columns[COLUMN_GOODSMAKERCD].Caption = "���[�J�[";
            _dataTable.Columns[COLUMN_GOODSMAKERNAME].Caption = "���[�J�[��";
            _dataTable.Columns[COLUMN_BLGOODSCODE].Caption = "�a�k�R�[�h";
            _dataTable.Columns[COLUMN_GOODSNO].Caption = "�i��";
            _dataTable.Columns[COLUMN_CONTENT].Caption = "���e";
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/08/31 �k���r #14019�̂Q�̑Ή��B</br>
        /// <br>Update Note : 2010/09/01 �k���r #14019�̂R�̑Ή��B</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            //-----UPD 2010/09/01---------->>>>>
            //if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text) && System.IO.File.Exists(tEdit_SettingFileName.Text))
            //-----UPD 2010/09/01----------<<<<<
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            //-----ADD 2010/08/31---------->>>>>
            //-----UPD 2010/09/01---------->>>>>
            string strPath = Environment.GetEnvironmentVariable("USERPROFILE");
            strPath += "\\My Documents";
            this.openFileDialog.InitialDirectory = strPath;
            //this.openFileDialog.Filter = string.Format("CSV(.CSV) | *.CSV; | �S�Ẵt�@�C��(.*) | *.*");
            //this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.Filter = string.Format("CSV�t�@�C��(*.CSV) | *.CSV; |���ׂẴt�@�C��(*.*) | *.*");
            string fileNameWithExt = Path.GetFileName(this.tEdit_SettingFileName.Text.ToUpper());
            this.openFileDialog.FilterIndex = GoodsRateSetUpdateFileConst.getExt(fileNameWithExt);
            //-----UPD 2010/09/01----------<<<<<
            //-----ADD 2010/08/31----------<<<<<

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
                //-----DEL 2010/09/01---------->>>>>
                ////-----ADD 2010/08/31---------->>>>>
                //_extrInfo.FileName = openFileDialog.FileName.ToUpper();
                ////-----ADD 2010/08/31----------<<<<<
                //-----DEL 2010/09/01----------<<<<<
            }
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
        private void tNedit_CustRateGrpCodeZero_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

            this.tNedit_CustRateGrpCodeZero.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero.SelectAll();
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
    //-----ADD 2010/09/01---------->>>>>
    /// <summary>
    /// �t�@�C�����ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�@�C�����ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date       : 2010/09/01</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsRateSetUpdateFileConst
    {

        # region �v���C�x�[�g�ϐ�

        // �o�̓t�@�C����
        private string _outputFileName;

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// �t�@�C�����ݒ���N���X
        /// </summary>
        public GoodsRateSetUpdateFileConst()
        {

        }

        # endregion // �R���X�g���N�^

        # region �v���p�e�B

        /// <summary>�o�̓t�@�C����</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        # endregion

        /// <summary>
        /// ���Ӑ�d�q�������[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>���Ӑ�d�q�������[�U�[�ݒ���N���X</returns>
        public GoodsRateSetUpdateFileConst Clone()
        {
            GoodsRateSetUpdateFileConst constObj = new GoodsRateSetUpdateFileConst();
            return constObj;
        }

        /// <summary>
        /// �t�@�C���g���q�擾����
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int getExt(string fileName)
        {
            int newExt = -1;
            if (string.IsNullOrEmpty(fileName))
            {
                newExt = 1;
            }
            else if (fileName.Contains("."))
            {
                string[] fileNameArr = fileName.Split(new Char[] { '.' });
                if ("CSV".Equals(fileNameArr[fileNameArr.Length - 1]))
                {
                    newExt = 1;
                }
                else
                {
                    newExt = 2;
                }
            }
            else
            {
                newExt = 2;
            }
            return newExt;
        }
    }
    //-----ADD 2010/09/01---------->>>>>
}