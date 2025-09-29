//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�@�t�H�[���N���X 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n��
// �� �� ��  2011/10/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n�� 							
// �C �� ��  2012/11/21  �C�����e : Redmine#33560�@ 							
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@TMY-ID�ɂ��Ă̎d�l�ύX	
//                                  �A�Ώۓ��t�͋L������悤�ɂ���d�l�ύX
//                                  �BF9�F����͌���v�]�ō폜����d�l�ύX
//                                  �CTMY-ID�Əo�̓t�H���_�ݒ�ւ̃t�H�[�J�X�ړ�������d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n�� 							
// �C �� ��  2012/11/27  �C�����e : �������M�̒ǉ��d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  �@�@�@�@�@  �쐬�S�� : ���N 							
// �C �� ��  2013/04/09  �C�����e : Redmine#35305 �C�����e�L�X�g�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  �@�@�@�@�@  �쐬�S�� : zhuhh 							
// �C �� ��  2013/04/18  �C�����e : Redmine#35368 �������M�敪�̋L����Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����f�[�^�e�L�X�g�o�́i�s�l�x�j�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�t�H�[���N���X</br>										
    /// <br>Programmer : ���N�n��</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>Update Note: 2012/11/21 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>             Redmine#33560</br>
    /// <br>             �@TMY-ID�ɂ��Ă̎d�l�ύX</br>
    /// <br>�@�@�@�@�@�@ �A�Ώۓ��t�͋L������悤�ɂ���d�l�ύX</br> 
    /// <br>�@�@�@�@�@�@ �BF9�F����͌���v�]�ō폜����d�l�ύX</br> 
    /// <br>�@�@�@�@�@�@ �CTMY-ID�Əo�̓t�H���_�ݒ�ւ̃t�H�[�J�X�ړ�������d�l�ύX</br> 
    /// <br>Update Note: 2012/11/27 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>             �������M�̒ǉ��d�l�ύX</br>
    /// <br>UpDate Note: 2013/04/09 ���N</br>
    /// <br>           : Redmine#35305 �C�����e�L�X�g�쐬</br>
    /// <br>UpDate Note: 2013/04/18 zhuhh</br>
    /// <br>           : Redmine#35368 �������M�敪�̋L����Ή�</br>
    /// </remarks>
    public partial class PMKHN07701UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�gConst
        // ===================================================================================== //
        # region Private Constant
        
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_EXTRACTTEXTBUTTON_KEY = "ButtonTool_ExtractText";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guid";
        //private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";//DEL�@���N�n���@2012/11/21 Redmine33560
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        // �K�C�h����
        private const string ctGUIDE_NAME_CarMngNo = "uButton_CarMngNoGuide";
        private const string ctGUIDE_NAME_Supplier = "uButton_SupplierGuide";
        private const string ctGUIDE_NAME_FileName = "ultraButton_FileName";

        //���̓��b�Z�[�W
        private const string MESSAGE_ApplyStaDate = "�J�n�Ώۓ��t����͂��ĉ������B";
        private const string MESSAGE_ApplyEndDate = "�I���Ώۓ��t����͂��ĉ������B";
        private const string MESSAGE_SendDiv = "�������M����͂��ĉ������B";//ADD�@���N�n���@2012/11/27
        private const string MESSAGE_Note = "���Ӑ敪�̓R�[�h����͂��ĉ������B";
        private const string MESSAGE_CarMngCode = "�Ǘ��ԍ�����͂��ĉ������B";
        private const string MESSAGE_SlipNote = "���l����͂��ĉ������B";
        private const string MESSAGE_SlipNote2 = "���l�Q����͂��ĉ������B";
        private const string MESSAGE_SlipNote3 = "���l�R����͂��ĉ������B";
        private const string MESSAGE_PartySaleSlipNum = "���`�ԍ�/�w����NO.����͂��ĉ������B";
        private const string MESSAGE_SupplierCd = "�d�������͂��ĉ������B";
        private const string MESSAGE_TMY_ID = "TMY-ID����͂��ĉ������B";
        private const string MESSAGE_FilePath = "�o�͐����͂��ĉ������B";

        // �N���X��
        private const string ct_PRINTNAME = "����f�[�^�e�L�X�g�o�́iTMY)";

        private const string ctSupprName = "���o�^";

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _extractTextButton;			// �e�L�X�g�o�̓{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;					// �K�C�h�{�^��
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// �N���A�{�^��		//DEL�@���N�n���@2012/11/21 Redmine33560			
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private CarMngInputAcs _carMngInputAcs;            // ���q�Ǘ��}�X�^�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;
        private string _enterpriseCode;                    // ��ƃR�[�h
        private string _loginSectionCode;                  // ���_
        private DateGetAcs _dateGetAcs = null;                    // ���t�擾���i
        private Dictionary<Int32, Supplier> _supInfoSetDic;
        private int _preSupprCode = -1;
        private string _fileName = string.Empty;

        //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
        private string _xmlfileName = string.Empty;�@�@�@�@//XML�t�@�C������ 
        private string _xmlfileDir = string.Empty;         //�t�@�C���p�X
        private string _fileNamePara = string.Empty;       //�t�@�C����
        //---ADD�@���N�n���@2012/11/27 ----------------<<<<<

        private Control _prevControl = null;									// ���݂̃R���g���[��
        private ControlScreenSkin _controlScreenSkin;                           // �X�L���ݒ�p�N���X

        private SalesSliptextAcs _salesSliptextAcs = null;
        private SalesSliptextCndtn _salesSliptextCndtn = null;
        private string _guideKey;
        private SFCMN00299CA msgForm = null;
        private FileInfo info = null;
        private FileStream f = null;
        private FormattedTextWriter _formattedTextWriter;

        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region�@Constructor

        /// <summary>
        /// ����f�[�^�e�L�X�g�o�́i�s�l�x�j�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ����f�[�^�e�L�X�g�o�́i�s�l�x�j�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : ���N�n��</br>										
        /// <br>Date        : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// <br>Update Note : 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// <br>              Redmine#33560</br>
        /// <br>              �@TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// <br>�@�@�@�@�@�@  �A�Ώۓ��t�͋L������悤�ɂ���d�l�ύX</br> 
        /// <br>�@�@�@�@�@�@  �BF9�F����͌���v�]�ō폜����d�l�ύX</br> 
        /// <br>Update Note: 2012/11/27 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ��d�l�ύX</br>
        /// </remarks>
        public PMKHN07701UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._extractTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_EXTRACTTEXTBUTTON_KEY];
            //this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];//DEL�@���N�n���@2012/11/21 Redmine33560
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                       //��ƃR�[�h
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;         //���_�R�[�h
            this._carMngInputAcs = new CarMngInputAcs();                                      //���q�Ǘ� �A�N�Z�X�N���X
            this._formattedTextWriter = new FormattedTextWriter();                            //CSV��������
            this._supplierAcs = new SupplierAcs();
            this._salesSliptextAcs = SalesSliptextAcs.GetInstance();                          //����f�[�^�e�L�X�g�o�́i�s�l�x�j�@�A�N�Z�X�N���X
            this._dateGetAcs = DateGetAcs.GetInstance();                                      //���t�`�F�b�N �A�N�Z�X�N���X
            this._controlScreenSkin = new ControlScreenSkin();                                //�X�L�������[�h
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tNedit_CustAnalysCode1); // ���Ӑ敪�̓R�[�h1
            ctrlList.Add(this.tNedit_CustAnalysCode2); // ���Ӑ敪�̓R�[�h2
            ctrlList.Add(this.tNedit_CustAnalysCode3); // ���Ӑ敪�̓R�[�h3
            ctrlList.Add(this.tNedit_CustAnalysCode4); // ���Ӑ敪�̓R�[�h4
            ctrlList.Add(this.tNedit_CustAnalysCode5); // ���Ӑ敪�̓R�[�h5
            ctrlList.Add(this.tNedit_CustAnalysCode6); // ���Ӑ敪�̓R�[�h6
            ctrlList.Add(this.tEdit_CarMngCode);       // �Ǘ��ԍ�
            ctrlList.Add(this.tEdit_SlipNote);         // ���l
            ctrlList.Add(this.tEdit_SlipNote2);        // ���l�Q
            ctrlList.Add(this.tEdit_SlipNote3);        // ���l�R
            ctrlList.Add(this.tEdit_PartySaleSlipNum); // ���`�ԍ�/�w������
            ctrlList.Add(this.tNedit_SupplierCd);      // �d����w��
            ctrlList.Add(this.uLabel_SupplierName);    // �d���於��
            //ctrlList.Add(this.tNedit_TMY_ID);        // TMY-ID //DEL�@���N�n���@2012/11/21 Redmine33560
            ctrlList.Add(this.tEdit_FilePath);         // �o�͐�	
            //---ADD�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
            ctrlList.Add(this.tEdit_TMY_ID);           // TMY-ID
            ctrlList.Add(this.ApplyStaDate_TDateEdit); // �J�n�Ώۓ��t
            ctrlList.Add(this.ApplyEndDate_TDateEdit); // �I���Ώۓ��t
            //---ADD�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<
            ctrlList.Add(this.uos_DataSendDiv);        //�������M�敪//ADD�@���N�n���@2012/11/27
            uiMemInput1.TargetControls = ctrlList;
            uiMemInput1.ReadOnLoad = false;

            // �d����}�X�^�Ǎ�
            ReadSupInfoSet();
        }

        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region�@Private Methods
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ʐݒ�</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpDate Note: 2013/04/09 ���N</br>
        /// <br>           : Redmine#35305 �C�����e�L�X�g�쐬</br>
        /// <br>UpDate Note: 2013/04/18 zhuhh</br>
        /// <br>           : Redmine#35368 �������M�敪�̋L����Ή�</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            this.uos_DataSendDiv.CheckedIndex = 1;// ADD zhuhh 2013/04/18 Redmine#35368
            this.ToolBarInitilSetting();       // �c�[���o�[�����ݒ菈��
            this.SetGuidButtonIcon();          // �{�^���A�C�R���ݒ�
            this.InitialScreenData();          //������ʃf�[�^�ݒ�
            this.uiMemInput1.ReadMemInput();   //�f�[�^�捞
            this.suppInit();                   //�d���揉�����
            //this.uos_DataSendDiv.CheckedIndex = 1;   // ��ʏ��������������M�敪�́u���Ȃ��v���Z�b�g����@// ADD ���N 2013/04/10 Redmine#35305 // DEL zhuhh 2013/04/18 Redmine#35368
        }

        /// <summary>
        /// �d���揉�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���揉�����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void suppInit()
        {
            string iniSupprName = "";
            if (this.tNedit_SupplierCd.GetInt() != 0)
            {
                iniSupprName = GetSupplierName(this.tNedit_SupplierCd.GetInt());
                this.uLabel_SupplierName.Text = iniSupprName;
            }
            else
            {
                this.uLabel_SupplierName.Text = string.Empty;
            }
        }

        #region �BF9�F����͌���v�]�ō폜����d�l�ύX
        //---DEL�@���N�n���@2012/11/21 Redmine33560 ------------------->>>>>
        ///// <summary>
        ///// ��ʏ�����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ��ʏ�����</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/10/31</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>Update Note: 2012/11/21 ���N�n��</br>
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             Redmine#33560</br>
        ///// <br>             �BF9�F����͌���v�]�ō폜����d�l�ύX</br>
        ///// </remarks>
        //private void Clear()
        //{
        //    this.InitialScreenData();                         //��ʏ�����
        //    this.tNedit_CustAnalysCode1.Text = string.Empty;  //���Ӑ敪�̓R�[�h1
        //    this.tNedit_CustAnalysCode2.Text = string.Empty;  //���Ӑ敪�̓R�[�h2
        //    this.tNedit_CustAnalysCode3.Text = string.Empty;  //���Ӑ敪�̓R�[�h3
        //    this.tNedit_CustAnalysCode4.Text = string.Empty;  //���Ӑ敪�̓R�[�h4
        //    this.tNedit_CustAnalysCode5.Text = string.Empty;  //���Ӑ敪�̓R�[�h5
        //    this.tNedit_CustAnalysCode6.Text = string.Empty;  //���Ӑ敪�̓R�[�h6
        //    this.tEdit_CarMngCode.Text = string.Empty;        // �Ǘ��ԍ�
        //    this.tEdit_SlipNote.Text = string.Empty;          // ���l
        //    this.tEdit_SlipNote2.Text = string.Empty;         // ���l�Q
        //    this.tEdit_SlipNote3.Text = string.Empty;         // ���l�R
        //    this.tEdit_PartySaleSlipNum.Text = string.Empty;  // ���`�ԍ�/�w������
        //    this.tNedit_SupplierCd.Text = string.Empty;       // �d����w��
        //    this.uLabel_SupplierName.Text = string.Empty;     // �d���於��
        //    this.tNedit_TMY_ID.Text = string.Empty;           // TMY-ID
        //    this.tEdit_FilePath.Text = string.Empty;          // �o�͐�	
        //    this.tEdit_ResultSlipCount.Text = "0";            //���o�`�[�����̏�����
        //    this.Initial_Timer.Enabled = true;
        //    this._preSupprCode = -1;
        //}
        //---DEL�@���N�n���@2012/11/21 Redmine33560 -------------------<<<<<
        #endregion

        /// <summary>
        /// ��ʂ̓��t�ƒ��o�`�[�����̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��t�ƒ��o�`�[�����̏�����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void InitialScreenData()
        {
            this.ApplyStaDate_TDateEdit.SetDateTime(DateTime.Now);  //�J�n�Ώۓ��t
            this.ApplyEndDate_TDateEdit.SetDateTime(DateTime.Now);  //�I���Ώۓ��t
            this.tEdit_ResultSlipCount.Text = "0";                  //���o�`�[�����̏�����
        }

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�����ݒ菈��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>�@�@�@�@�@�@ �BF9�F����͌���v�]�ō폜����d�l�ύX</br> 
        /// </remarks>
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            this._extractTextButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.GUIDE;
            //this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;//DEL�@���N�n���@2012/11/21 Redmine33560
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���̃A�C�R���ݒ菈��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            //�Ǘ��ԍ�
            this.uButton_CarMngNoGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //�d����w��
            this.uButton_SupplierGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //�d����p�X
            this.ultraButton_FileName.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note       : �{�^���c�[���L�������ݒ菈��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
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
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                //�Ȃ��B
            }

            if (targetControl.Name == "tEdit_CarMngCode"
                || targetControl.Name == "tNedit_SupplierCd")
            {
                this._guideButton.SharedProps.Enabled = true;
                this._guideKey = targetControl.Name;
            }
            else
            {
                this._guideButton.SharedProps.Enabled = false;
            }
        }

        /// <summary>
        /// �u�K�C�h�v����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �u�K�C�h�v����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void ExecuteGuide()
        {
            switch (this._guideKey)
            {
                // �Ǘ��ԍ�
                case "tEdit_CarMngCode":
                    {
                        this.uButton_CarMngNoGuide_Click(this.uButton_CarMngNoGuide, new EventArgs());
                        break;
                    }

                //�d����w��
                case "tNedit_SupplierCd":
                    {
                        this.uButton_SupplierGuide_Click(this.uButton_SupplierGuide, new EventArgs());
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʍX�V�O�`�F�b�N
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʍX�V�O�`�F�b�N</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560�@�C�����e�L�X�g��TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// </remarks>
        private bool BeforeSearchCheck()
        {
            // ���Ӑ敪�̓R�[�h1
            int inputNote1Value = 0;
            this.tNedit_CustAnalysCode1.Text = this.tNedit_CustAnalysCode1.GetInt().ToString();
            // ���Ӑ敪�̓R�[�h2
            int inputNote2Value = 0;
            this.tNedit_CustAnalysCode2.Text = this.tNedit_CustAnalysCode2.GetInt().ToString();
            // ���Ӑ敪�̓R�[�h3
            int inputNote3Value = 0;
            this.tNedit_CustAnalysCode3.Text = this.tNedit_CustAnalysCode3.GetInt().ToString();
            // ���Ӑ敪�̓R�[�h4
            int inputNote4Value = 0;
            this.tNedit_CustAnalysCode4.Text = this.tNedit_CustAnalysCode4.GetInt().ToString();
            // ���Ӑ敪�̓R�[�h5
            int inputNote5Value = 0;
            this.tNedit_CustAnalysCode5.Text = this.tNedit_CustAnalysCode5.GetInt().ToString();
            // ���Ӑ敪�̓R�[�h6
            int inputNote6Value = 0;
            this.tNedit_CustAnalysCode6.Text = this.tNedit_CustAnalysCode6.GetInt().ToString();
            //�d����R�[�h
            int inputSupplierCdValue = 0;
            int supprCode = this.tNedit_SupplierCd.GetInt();
            string supprName = string.Empty;
            //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
            //TMY_ID
            //int inputTmyidValue = 0;
            //this.tNedit_TMY_ID.Text = this.tNedit_TMY_ID.GetInt().ToString();
            //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<
            //�����`�[�ԍ�
            int inputPartySaleSlipNumValue = 0;
         
            //���Ӑ敪�̓R�[�h1F10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_CustAnalysCode1.Text.Trim(), out inputNote1Value))
            {
                if (inputNote1Value == 0)
                {
                    this.tNedit_CustAnalysCode1.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_CustAnalysCode1.Clear();
            }

            //���Ӑ敪�̓R�[�h2F10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_CustAnalysCode2.Text.Trim(), out inputNote2Value))
            {
                if (inputNote2Value == 0)
                {
                    this.tNedit_CustAnalysCode2.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_CustAnalysCode2.Clear();
            }


            //���Ӑ敪�̓R�[�h3F10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_CustAnalysCode3.Text.Trim(), out inputNote3Value))
            {
                if (inputNote3Value == 0)
                {
                    this.tNedit_CustAnalysCode3.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_CustAnalysCode3.Clear();
            }

            //���Ӑ敪�̓R�[�h4F10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_CustAnalysCode4.Text.Trim(), out inputNote4Value))
            {
                if (inputNote4Value == 0)
                {
                    this.tNedit_CustAnalysCode4.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_CustAnalysCode4.Clear();
            }

            //���Ӑ敪�̓R�[�h5F10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_CustAnalysCode5.Text.Trim(), out inputNote5Value))
            {
                if (inputNote5Value == 0)
                {
                    this.tNedit_CustAnalysCode5.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_CustAnalysCode5.Clear();
            }

            //���Ӑ敪�̓R�[�h6F10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_CustAnalysCode6.Text.Trim(), out inputNote6Value))
            {
                if (inputNote6Value == 0)
                {
                    this.tNedit_CustAnalysCode6.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_CustAnalysCode6.Clear();
            }

            //�d����R�[�hF10�̏ꍇ�̃`�F�b�N
            if (Int32.TryParse(this.tNedit_SupplierCd.Text.Trim(), out inputSupplierCdValue))
            {
                if (inputSupplierCdValue == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                }
                else
                {
                    //�Ȃ��B
                }
            }
            else
            {
                this.tNedit_SupplierCd.Clear();
            }
            if (supprCode != 0 && supprCode != _preSupprCode)
            {
                _preSupprCode = supprCode;
                supprName = GetSupplierName(supprCode);
                this.uLabel_SupplierName.Text = supprName;
            }
            else if (supprCode == 0)
            {
                _preSupprCode = supprCode; //ADD�@���N�n���@2012/11/21 Redmine33560
                this.uLabel_SupplierName.Text = string.Empty;
            }
            else
            {
                //�Ȃ��B
            }
            //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
            //TMY_IDF10�̏ꍇ�̃`�F�b�N
            //if (Int32.TryParse(this.tNedit_TMY_ID.Text.Trim(), out inputTmyidValue))
            //{
            //    if (inputTmyidValue == 0)
            //    {
            //        this.tNedit_TMY_ID.Clear();
            //    }
            //    else
            //    {
            //        //�Ȃ��B
            //    }
            //}
            //else
            //{
            //    this.tNedit_TMY_ID.Clear();

            //}
            //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<

            //�����`�[�ԍ�
            if (Int32.TryParse(this.tEdit_PartySaleSlipNum.Text.Trim(), out inputPartySaleSlipNumValue))
            {
                if (inputPartySaleSlipNumValue != 0 && this.tEdit_PartySaleSlipNum.Text.ToString().Trim().Length < 9)
                {
                    this.tEdit_PartySaleSlipNum.Text = Convert.ToInt32(this.tEdit_PartySaleSlipNum.Text.Trim()).ToString("000000000");
                }
                else
                {
                    this.tEdit_PartySaleSlipNum.Text = this.tEdit_PartySaleSlipNum.Text.Trim();
                }
            }
            else
            {
                this.tEdit_PartySaleSlipNum.Text = this.tEdit_PartySaleSlipNum.Text.Trim();
            }

            DateGetAcs.CheckDateResult cdResult;
            // �K�p�J�n��
            if (CallCheckDate(out cdResult, ref this.ApplyStaDate_TDateEdit) == false)
            {
                // ������
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // �s���l����͎��G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�J�n�Ώۓ��t�̓��͂��s���ł��B",                   // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                            // �t�H�[�J�X�ݒ�
                            this.ApplyStaDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // �����͂̏ꍇ�G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�J�n�Ώۓ��t����͂��Ă��������B",                 // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);
                            // �t�H�[�J�X�ݒ�
                            this.ApplyStaDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }
            else
            {
                //�Ȃ��B
            }

            // �K�p�I����
            if (CallCheckDate(out cdResult, ref this.ApplyEndDate_TDateEdit) == false)
            {
                // ������
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // �s���l����͎��G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�I���Ώۓ��t�̓��͂��s���ł��B",                   // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                           
                            // �t�H�[�J�X�ݒ�
                            this.ApplyEndDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // �����͂̏ꍇ�G��
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�I���Ώۓ��t����͂��Ă��������B",                 // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);

                            // �t�H�[�J�X�ݒ�
                            this.ApplyEndDate_TDateEdit.Focus();
                            this._prevControl = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }
            else
            {
                //�Ȃ��B
            }

            // �Ώۓ��t�̓���
            if (this.ApplyStaDate_TDateEdit.GetLongDate() > this.ApplyEndDate_TDateEdit.GetLongDate())
            {
                // �J�n���I��
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�Ώۓ��t�͈̔͂Ɍ�肪����܂��B",               �@// �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.ApplyStaDate_TDateEdit.Focus();
                this._prevControl = this.ApplyStaDate_TDateEdit;
                return false;
            }
            else
            {
                //�Ȃ��B
            }

            // �Ώۓ��t�͈̔�
            if (!(this.ApplyEndDate_TDateEdit.GetDateMonth() == this.ApplyStaDate_TDateEdit.GetDateMonth()
                && this.ApplyEndDate_TDateEdit.GetDateYear() == this.ApplyStaDate_TDateEdit.GetDateYear()))
            {
                //���͓��t�͈͓̔͂��ꌎ���ł͂Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���t�͈̔͂��Ⴂ�܂��B",    �@�@�@�@�@�@�@�@�@�@�@ // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.ApplyStaDate_TDateEdit.Focus();
                this._prevControl = this.ApplyStaDate_TDateEdit;
                return false;
            }
            else
            {
                //�Ȃ��B
            }

            if (string.IsNullOrEmpty(this.tNedit_CustAnalysCode1.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode2.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode3.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode4.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode5.Text.Trim())
               && string.IsNullOrEmpty(this.tNedit_CustAnalysCode6.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_CarMngCode.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_SlipNote2.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_SlipNote3.Text.Trim())
               && string.IsNullOrEmpty(this.tEdit_PartySaleSlipNum.Text.Trim()))
            {
            
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "���ڂ����ݒ�ł��B",    �@                         // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);
                // �t�H�[�J�X�ݒ�
                this.tNedit_CustAnalysCode1.Focus();
                this._prevControl = this.tNedit_CustAnalysCode1; 
                return false;
            }
            else
            {
                //�Ȃ��B
            }

            //if (string.IsNullOrEmpty(this.tNedit_TMY_ID.Text.Trim()))//DEL�@���N�n���@2012/11/21 Redmine33560
            if (string.IsNullOrEmpty(this.tEdit_TMY_ID.Text.Trim()))//ADD�@���N�n���@2012/11/21 Redmine33560
            {
            
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "TMY-ID����͂��Ă��������B",    �@                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                //---DEL�@���N�n���@2012/11/21 Redmine33560----->>>>>
                //this.tNedit_TMY_ID.Focus();
                //this._prevControl = this.tNedit_TMY_ID;
                //---DEL�@���N�n���@2012/11/21 Redmine33560-----<<<<<
                //---ADD�@���N�n���@2012/11/21 Redmine33560----->>>>>
                this.tEdit_TMY_ID.Focus();
                this._prevControl = this.tEdit_TMY_ID;
                //---ADD�@���N�n���@2012/11/21 Redmine33560-----<<<<<
                return false;
            }
            else
            {
                //�Ȃ��B
            }

            if(string.IsNullOrEmpty(this.tEdit_FilePath.Text.Trim()))
            {
            
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�o�͐����͂��Ă��������B",    �@                 // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);
                // �t�H�[�J�X�ݒ�
                this.tEdit_FilePath.Focus();
                this._prevControl = this.tEdit_FilePath;  
                return false;
            }
            else
            {
                //�Ȃ��B
            }
            return true;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdResult">cdResult</param>
        /// <param name="targetDateEdit">targetDateEdit</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���t�`�F�b�N�����Ăяo��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = this._dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// �d����}�X�^�Ǎ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�d����}�X�^�Ǎ�</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void ReadSupInfoSet()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            this._supInfoSetDic = new Dictionary<Int32, Supplier>();
            ArrayList suppList = null;
            status = this._supplierAcs.SearchAll(out suppList, this._enterpriseCode);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Supplier supplier in suppList)
                {
                    if (supplier.LogicalDeleteCode == 0)
                    {
                        this._supInfoSetDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            else
            {
                //�Ȃ��B
            }
        }


        #region[������@�o�C�g���w��؂蔲��]
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        /// <remarks>
        /// <br>Note       : ������@�o�C�g���w��؂蔲��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }
            else
            {
                //�Ȃ��B
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount)
                {
                    break;
                }
                else
                {
                    //�Ȃ��B
                } 
            }

            // �I�[�̋󔒂͍폜
            return resultString;

        }
        #endregion

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�\������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMKHN07701UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PRINTNAME,				        // �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        ///	Form.Load �C�x���g(PMKHN07701U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : Form.Load �C�x���g(PMKHN07701U)</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07701UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            InitialScreenSetting();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             �BF9�F����͌���v�]�ō폜����d�l�ύX</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // �I������
                        Close();
                        break;
                    }
                // CSV�o��
                case TOOLBAR_EXTRACTTEXTBUTTON_KEY:
                    {
                        this.ExtractText();
                        break;
                    }
                //---DEL�@���N�n���@2012/11/21 Redmine33560------>>>>>
                // �N���A
                //case TOOLBAR_CLEARBUTTON_KEY:
                //    {
                //        // �N���A����
                //        this.Clear();
                //        break;
                //    }
                //---DEL�@���N�n���@2012/11/21 Redmine33560------<<<<<
                // �K�C�h
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.ExecuteGuide();
                        break;
                    }
                  
            }
        }

        /// <summary>
        /// �f�[�^���o���āA�e�L�X�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^���o���āA�e�L�X�g����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560�@�C�����e�L�X�g��TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// <br>Update Note: 2012/11/27 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ��d�l�ύX</br>
        /// </remarks>
        private void ExtractText()
        {
             int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
             int _totalCount = 0;
             string ex = string.Empty;
             //---ADD�@���N�n���@2012/11/27 ------>>>>>
             int deleteFlag = -1;
             int insertFlag = -1;
             //---ADD�@���N�n���@2012/11/27 ------<<<<<
             

             // �I�t���C����ԃ`�F�b�N
             if (!CheckOnline())
             {
                 TMsgDisp.Show(
                     emErrorLevel.ERR_LEVEL_STOP,
                     this.Text,
                     this.Text + "��ʍX�V�����Ɏ��s���܂����B",
                     (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                 return;

             }
             else
             {
                 //�Ȃ��B
             } 

             // �`�F�b�N
             bool isUpdate = this.BeforeSearchCheck();
             if ((this._prevControl != null) && (this._prevControl.TabStop))
             {
                 this.SettingGuideButtonToolEnabled(this._prevControl);
                 this.StatusBarMessageSettingProc(this._prevControl);
             }
             else
             {
                 //�Ȃ��B
             } 

             if (!isUpdate)
             {
                 return;
             }
             else
             {
                 //�Ȃ��B
             } 

             //this._fileName = this.tEdit_FilePath.DataText.ToString().Trim() + "\\" + this.tNedit_TMY_ID.Text.Trim()//DEL�@���N�n���@2012/11/21 Redmine33560
             this._fileName = this.tEdit_FilePath.DataText.ToString().Trim() + "\\" + this.tEdit_TMY_ID.Text.Trim()//ADD�@���N�n���@2012/11/21 Redmine33560
              + ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00") + ".CSV";
             //---ADD�@���N�n���@2012/11/27  ------------->>>>>
             this._xmlfileName =  this.tEdit_FilePath.DataText.ToString().Trim() + "\\" + this.tEdit_TMY_ID.Text.Trim()
              + ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00") + ".XML";
             this._xmlfileDir = this.tEdit_FilePath.DataText.ToString().Trim();
             this._fileNamePara = this.tEdit_TMY_ID.Text.Trim()+ ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00");
             //---ADD�@���N�n���@2012/11/27  -------------<<<<<
             // ��ʁ����o�����N���X
             status = this.SetExtraInfoFromScreen();

             if (status != 0)
             {
                 return;
             }
             else
             {
                 //�Ȃ��B
             } 

             if (!Directory.Exists(System.IO.Path.GetDirectoryName(this._fileName)))
             {
                 TMsgDisp.Show(
                 this,
                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                 this.Name,
                  "CSV�t�@�C���p�X���s���ł��B",
                 status,
                 MessageBoxButtons.OK);
                 this._prevControl = this.tEdit_FilePath;
                 this.tEdit_FilePath.Focus();
                 this.SettingGuideButtonToolEnabled(this.tEdit_FilePath);
                 this.StatusBarMessageSettingProc(this.tEdit_FilePath);
                 return;
             }
             else
             {
                 //�Ȃ��B
             } 
             if (File.Exists(this._fileName))
             {
                 // �m�F���b�Z�[�W��\������B
                 DialogResult result = TMsgDisp.Show(
                             emErrorLevel.ERR_LEVEL_QUESTION,                               // �G���[���x��
                             "PMKHN07701UA",						                        // �A�Z���u���h�c�܂��̓N���X�h�c
                             ct_PRINTNAME,				                                    // �v���O��������
                             "", 								                            // ��������
                             "",									                        // �I�y���[�V����
                             "���ꖼ�̏o�̓t�@�C�������ɑ��݂��܂��B�����𑱍s���܂����H",	// �\�����郁�b�Z�[�W
                             -1, 							                                // �X�e�[�^�X�l
                             null, 								                            // �G���[�����������I�u�W�F�N�g
                             MessageBoxButtons.YesNo, 				                        // �\������{�^��
                             MessageBoxDefaultButton.Button1);	                            // �����\���{�^��
                 // ���͉�ʂ֖߂�B
                 if (result == DialogResult.No)
                 {
                     return;
                 }
                 else
                 {
                     //�Ȃ��B
                 } 
             }
             else
             {
                 //�Ȃ��B
             } 
             //CreateFile();//DEL�@���N�n���@2012/11/27
             int resultCount = 0;
             // ���o����ʕ��i�̃C���X�^���X���쐬
             msgForm = new SFCMN00299CA();
             msgForm.Title = "���o��";
             msgForm.Message = "���݁A�f�[�^���o���ł��B                  ��n���΂炭���҂���������";
             string messages = string.Empty;
             try
             {
                 msgForm.Show();
                 // ����
                 //status = this._salesSliptextAcs.SearchData(this._salesSliptextCndtn, this.tNedit_TMY_ID.Text.Trim(), ref resultCount, ref messages);//DEL�@���N�n���@2012/11/21 Redmine33560
                 status = this._salesSliptextAcs.SearchData(this._salesSliptextCndtn, this.tEdit_TMY_ID.Text.Trim(), ref resultCount, ref messages);//ADD�@���N�n���@2012/11/21 Redmine33560

                 msgForm.Close();
                 //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
                 deleteFlag = DeleteFile();
                 if (deleteFlag == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                 {
                     CreateFile();
                 }
                 else
                 {
                     //�Y���Ȃ��B
                 }
                 //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
                 switch (status)
                 {
                     case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                         //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
                         if (deleteFlag != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                         {
                             break;
                         }
                         else
                         {
                             if (resultCount != 0 && uos_DataSendDiv.CheckedIndex == 0)
                             {
                                 insertFlag = SaveNetSendSetting();
                                 if (insertFlag != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                 {
                                     break;
                                 }
                                 else
                                 {
                                     //�Y���Ȃ��B
                                 }
                             }
                             else
                             {
                                 //�Y���Ȃ��B
                             }
                         }
                         //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
                         this.tEdit_ResultSlipCount.DataText = string.Format("{0:###,###,##0}", resultCount);
                         SetFormattedTextWriter();
                         string resultMessage = "";
                         try
                         {
                             status = _formattedTextWriter.TextOut(out _totalCount);
                         }
                         catch
                         {
                             status = -1;
                         }
                         if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                         {
                             resultMessage = "CSV�f�[�^���쐬���܂����B";
                             MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, resultMessage, status);
                             //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
                             if (insertFlag == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                             {
                                 this._salesSliptextAcs.SendAndReceive(this._salesSliptextCndtn, this._xmlfileDir, this._fileNamePara);
                             }
                             //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
                         }
                         else
                         {
                             resultMessage = "�e�L�X�g�t�@�C���̏������݂Ɏ��s���܂����B";
                             MsgDispProc(emErrorLevel.ERR_LEVEL_STOP,resultMessage, 9);
                         }
                         break;

                     case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                         this.tEdit_ResultSlipCount.DataText = "0";
                         MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "���������ɊY������f�[�^�͑��݂��܂���B", (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                         break;

                     default:
                         if (string.IsNullOrEmpty(messages))
                         {
                             MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�����Ɏ��s���܂����B", -1);
                         }
                         else
                         {
                             MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, messages, status);
                         }
                         break;
                 }
             }
             finally
             {
                 //�Y���Ȃ��B
             } 
        }

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����ݒ菈��(��ʁ����o����)</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._salesSliptextCndtn = new SalesSliptextCndtn();
            try
            {
                // ��ƃR�[�h
                this._salesSliptextCndtn.EnterpriseCode = this._enterpriseCode;

                //�Ώۓ��̊J�n��
                this._salesSliptextCndtn.SalesDateSt = this.ApplyStaDate_TDateEdit.GetLongDate();

                //�Ώۓ��̏I����
                this._salesSliptextCndtn.SalesDateEd = this.ApplyEndDate_TDateEdit.GetLongDate();

                //���q�Ǘ��R�[�h
                this._salesSliptextCndtn.CarMngNo1 = this.tEdit_CarMngCode.Text.Trim();

                //�d����R�[�h
                this._salesSliptextCndtn.SupplierCd = this.tNedit_SupplierCd.GetInt();

                //�����`�[�ԍ�
                this._salesSliptextCndtn.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text.Trim();
               
                //���Ӑ敪�̓R�[�h1
                this._salesSliptextCndtn.CustAnalysCode1 = this.tNedit_CustAnalysCode1.GetInt();

                //���Ӑ敪�̓R�[�h2
                this._salesSliptextCndtn.CustAnalysCode2 = this.tNedit_CustAnalysCode2.GetInt();

                //���Ӑ敪�̓R�[�h3
                this._salesSliptextCndtn.CustAnalysCode3 = this.tNedit_CustAnalysCode3.GetInt();

                //���Ӑ敪�̓R�[�h4
                this._salesSliptextCndtn.CustAnalysCode4 = this.tNedit_CustAnalysCode4.GetInt();

                //���Ӑ敪�̓R�[�h5
                this._salesSliptextCndtn.CustAnalysCode5 = this.tNedit_CustAnalysCode5.GetInt();

                //���Ӑ敪�̓R�[�h6
                this._salesSliptextCndtn.CustAnalysCode6 = this.tNedit_CustAnalysCode6.GetInt();

                //�`�[���l
                this._salesSliptextCndtn.SlipNote = this.tEdit_SlipNote.Text.Trim();

                //�`�[���l�Q
                this._salesSliptextCndtn.SlipNote2 = this.tEdit_SlipNote2.Text.Trim();

                //�`�[���l�R
                this._salesSliptextCndtn.SlipNote3 = this.tEdit_SlipNote3.Text.Trim();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        # endregion
       
        /// <summary>
        /// CSV�������݃f�[�^�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : CSV�������݃f�[�^�擾</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560�@�C�����e�L�X�g��TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// </remarks>
        private void SetFormattedTextWriter()
        {
            List<string> schemeList = new List<string>();
            // �f�[�^�敪
            schemeList.Add("DATADIV");
            // TMY-ID
            schemeList.Add("TMYID");
            // ���Ӑ溰��
            schemeList.Add("CUSTOMERCODE");
            // ������t
            schemeList.Add("SALESDATE");
            // ����`�[�ԍ�
            schemeList.Add("SALESSLIPNUM");
            // ����s�ԍ�
            schemeList.Add("SALESROWNO");
            // ���i�ԍ�
            schemeList.Add("GOODSNO");
            // ���i���[�J�[�R�[�h
            schemeList.Add("GOODSMAKERCD");
            // BL���i�R�[�h
            schemeList.Add("BLGOODSCODE");
            // �o�א�
            schemeList.Add("SHIPMENTCNT");
            // �d����R�[�h
            schemeList.Add("SUPPLIERCD");
            
            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();

            // �f�[�^�敪
            maxLengthList.Add("DATADIV", 2);
            // TMY-ID
            maxLengthList.Add("TMYID", 7);
            // ���Ӑ溰��
            maxLengthList.Add("CUSTOMERCODE", 8);
            // ������t
            maxLengthList.Add("SALESDATE", 8);
            // ����`�[�ԍ�
            maxLengthList.Add("SALESSLIPNUM", 9);
            // ����s�ԍ�
            maxLengthList.Add("SALESROWNO", 2);
            // ���i�ԍ�
            maxLengthList.Add("GOODSNO", 20);
            // ���i���[�J�[�R�[�h
            maxLengthList.Add("GOODSMAKERCD", 4);
            // BL���i�R�[�h
            maxLengthList.Add("BLGOODSCODE", 5);
            // �o�א�
            maxLengthList.Add("SHIPMENTCNT", 8);
            // �d����R�[�h
            maxLengthList.Add("SUPPLIERCD", 6);

            _formattedTextWriter.DataSource = this._salesSliptextAcs.SalesSliptextCsv;
            _formattedTextWriter.DataMember = String.Empty;
            //_formattedTextWriter.OutputFileName = this.tEdit_FilePath.DataText.ToString() + "\\" + this.tNedit_TMY_ID.Text.Trim()//DEL�@���N�n���@2012/11/21 Redmine33560
            _formattedTextWriter.OutputFileName = this.tEdit_FilePath.DataText.ToString() + "\\" + this.tEdit_TMY_ID.Text.Trim()//ADD�@���N�n���@2012/11/21 Redmine33560
               + ApplyStaDate_TDateEdit.GetDateYear().ToString() + ApplyStaDate_TDateEdit.GetDateMonth().ToString("00") + ".CSV";
            //�e�L�X�g�o�͂��鍀�ږ��̃��X�g
            _formattedTextWriter.SchemeList = schemeList;
            _formattedTextWriter.Splitter = ",";
            _formattedTextWriter.Encloser = "\"";
            _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            _formattedTextWriter.FormatList = null;
            _formattedTextWriter.CaptionOutput = false;
            _formattedTextWriter.FixedLength = false;
            _formattedTextWriter.ReplaceList = null;
            _formattedTextWriter.MaxLengthList = maxLengthList;

        }

   
        /// <summary>
        /// �t�@�C���̍쐬
        /// </summary>
        /// <returns>�X�^�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C���̍쐬</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private int CreateFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // �t�@�C��
                info = new FileInfo(this._fileName);
                f = info.Create();
                //�������N���A
                f.Close();

            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ݒ�</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.ApplyStaDate_TDateEdit.Focus();
            this.SettingGuideButtonToolEnabled(this.ApplyStaDate_TDateEdit);
            this.StatusBarMessageSettingProc(this.ApplyStaDate_TDateEdit);
            this._guideKey = this.ApplyStaDate_TDateEdit.Name;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ChangeFocus �C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             �@TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// <br>�@�@�@�@�@�@ �CTMY-ID�Əo�̓t�H���_�ݒ�ւ̃t�H�[�J�X�ړ�������d�l�ύX</br> 
        /// <br>Update Note: 2012/11/27 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ��d�l�ύX</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }
            else
            {
                //�Ȃ��B
            }
            this._prevControl = e.NextCtrl;
            switch (e.PrevCtrl.Name)
            {
                // �Ώۓ��t�J�n
                case "ApplyStaDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ApplyEndDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                // �t�H�[�J�X�ݒ�
                                //this._prevControl = this.tNedit_CustAnalysCode1;//DEL�@���N�n���@2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//ADD�@���N�n���@2012/11/27
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        break;
                    }

                // �Ώۓ��t�I��  
                case "ApplyEndDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                //this._prevControl = this.tNedit_CustAnalysCode1;//DEL�@���N�n���@2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//ADD�@���N�n���@2012/11/27
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ApplyEndDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ApplyEndDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                // �t�H�[�J�X�ݒ�
                                //this._prevControl = this.tNedit_CustAnalysCode6;//DEL�@���N�n���@2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//DEL�@���N�n���@2012/11/27
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }
                //---ADD�@���N�n���@2012/11/27  ------------->>>>>
                // �������M  
                case "uos_DataSendDiv":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.uos_DataSendDiv;
                            }
                            else
                            {
                              //�Ȃ��B
                            }
                        }
                        else
                        {
                            //�Ȃ��B
                        }
                        break;
                    }
                //---ADD�@���N�n���@2012/11/27  ------------<<<<<
                //�@���Ӑ敪�̓R�[�h1
                case "tNedit_CustAnalysCode1":
                    {
                        this.tNedit_CustAnalysCode1.Text = this.tNedit_CustAnalysCode1.GetInt().ToString();
                        int inputNote1Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode1.Text.Trim(), out inputNote1Value))
                        {
                            if (inputNote1Value == 0)
                            {
                                this.tNedit_CustAnalysCode1.Clear();
                            }
                            else
                            {
                               //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode1.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode2;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                //this._prevControl = this.ApplyEndDate_TDateEdit;//DEL�@���N�n���@2012/11/27
                                this._prevControl = this.uos_DataSendDiv;//ADD�@���N�n���@2012/11/27
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���Ӑ敪�̓R�[�h2
                case "tNedit_CustAnalysCode2":
                    {
                        this.tNedit_CustAnalysCode2.Text = this.tNedit_CustAnalysCode2.GetInt().ToString();
                        int inputNote2Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode2.Text.Trim(), out inputNote2Value))
                        {
                            if (inputNote2Value == 0)
                            {
                                this.tNedit_CustAnalysCode2.Clear();
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode2.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode3;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode1;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���Ӑ敪�̓R�[�h3
                case "tNedit_CustAnalysCode3":
                    {
                        this.tNedit_CustAnalysCode3.Text = this.tNedit_CustAnalysCode3.GetInt().ToString();
                        int inputNote3Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode3.Text.Trim(), out inputNote3Value))
                        {
                            if (inputNote3Value == 0)
                            {
                                this.tNedit_CustAnalysCode3.Clear();
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode3.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode4;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode2;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���Ӑ敪�̓R�[�h4
                case "tNedit_CustAnalysCode4":
                    {
                        this.tNedit_CustAnalysCode4.Text = this.tNedit_CustAnalysCode4.GetInt().ToString();
                        int inputNote4Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode4.Text.Trim(), out inputNote4Value))
                        {
                            if (inputNote4Value == 0)
                            {
                                this.tNedit_CustAnalysCode4.Clear();
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode4.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode5;
                            }
                            if (e.Key == Keys.Down)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode3;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���Ӑ敪�̓R�[�h5
                case "tNedit_CustAnalysCode5":
                    {
                        this.tNedit_CustAnalysCode5.Text = this.tNedit_CustAnalysCode5.GetInt().ToString();
                        int inputNote5Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode5.Text.Trim(), out inputNote5Value))
                        {
                            if (inputNote5Value == 0)
                            {
                                this.tNedit_CustAnalysCode5.Clear();
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode5.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode6;
                            }
                            if (e.Key == Keys.Down)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode4;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }
                //�@���Ӑ敪�̓R�[�h6
                case "tNedit_CustAnalysCode6":
                    {
                        this.tNedit_CustAnalysCode6.Text = this.tNedit_CustAnalysCode6.GetInt().ToString();
                        int inputNote6Value = 0;
                        if (Int32.TryParse(this.tNedit_CustAnalysCode6.Text.Trim(), out inputNote6Value))
                        {
                            if (inputNote6Value == 0)
                            {
                                this.tNedit_CustAnalysCode6.Clear();
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_CustAnalysCode6.Clear();
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode6;
                            }
                            if (e.Key == Keys.Down)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            //---ADD�@���N�n���@2012/11/27 ---------->>>>>
                            if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.uos_DataSendDiv;
                            }
                            //---ADD�@���N�n���@2012/11/27 ----------<<<<<
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode5;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }
                //�@�Ǘ��ԍ�
                case "tEdit_CarMngCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (string.IsNullOrEmpty(this.tEdit_CarMngCode.Text.Trim()))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    this._prevControl = this.uButton_CarMngNoGuide;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    this._prevControl = this.tEdit_SlipNote;
                                }

                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.uButton_CarMngNoGuide;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode1;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_CustAnalysCode6;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@�Ǘ��ԍ��K�C�h
                case "uButton_CarMngNoGuide":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_SlipNote;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.uButton_CarMngNoGuide;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_CarMngCode;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                 //�@���l�@�i�擪��v�j
                case "tEdit_SlipNote":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_SlipNote2;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = tEdit_SlipNote;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = tEdit_CarMngCode;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.uButton_CarMngNoGuide;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���l�Q�i�擪��v�j
                case "tEdit_SlipNote2":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_SlipNote3;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = tEdit_SlipNote2;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_SlipNote;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���l�R�i�擪��v�j
                case "tEdit_SlipNote3":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = tEdit_SlipNote3;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_SlipNote2;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                //�@���`�ԍ�/�w������
                case "tEdit_PartySaleSlipNum":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_SupplierCd;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = tEdit_PartySaleSlipNum;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_SlipNote3;
                            }
                            else
                            {
                                //�Ȃ��B
                            }

                        }
                        break;
                    }

                 //�@�d����w��
                case "tNedit_SupplierCd":
                    {
                        int inputSupplierCdValue = 0;
                        if (Int32.TryParse(this.tNedit_SupplierCd.Text.Trim(), out inputSupplierCdValue))
                        {
                            if (inputSupplierCdValue == 0)
                            {
                                this.tNedit_SupplierCd.Clear();
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            this.tNedit_SupplierCd.Clear();
                        }

                        int supprCode = this.tNedit_SupplierCd.GetInt();
                        string supprName = string.Empty;


                        if (supprCode != 0 && supprCode != _preSupprCode)
                        {
                            _preSupprCode = supprCode;
                            supprName = GetSupplierName(supprCode);
                            this.uLabel_SupplierName.Text = supprName;
                        }
                        else if (supprCode == 0)
                        {
                            _preSupprCode = supprCode; //ADD�@���N�n���@2012/11/21 Redmine33560
                            this.uLabel_SupplierName.Text = string.Empty;
                        }
                        else
                        {
                            //�Ȃ��B
                        }

                        if (e.ShiftKey == false)
                        {
                            //if ((e.Key == Keys.Tab) ||( e.Key == Keys.Enter))//DEL�@���N�n���@2012/11/21 Redmine33560
                            if (e.Key == Keys.Tab)//ADD�@���N�n���@2012/11/21 Redmine33560
                            {
                                if (this.tNedit_SupplierCd.GetInt() == 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    this._prevControl = this.uButton_SupplierGuide;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    //this._prevControl = this.tNedit_TMY_ID;//DEL�@���N�n���@2012/11/21 Redmine33560
                                    this._prevControl = this.tEdit_TMY_ID;//ADD�@���N�n���@2012/11/21 Redmine33560
                                }
                            }
                            //---ADD�@���N�n���@2012/11/21 Redmine33560------>>>>>
                            else if (e.Key == Keys.Enter)
                            {
                                if (this.tNedit_SupplierCd.GetInt() == 0)
                                {
                                    // �t�H�[�J�X�ݒ�
                                    this._prevControl = this.uButton_SupplierGuide;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    this._prevControl = this.ApplyStaDate_TDateEdit;
                                }
                            }
                            //---ADD�@���N�n���@2012/11/21 Redmine33560------<<<<<
                            else if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.uButton_SupplierGuide;
                            }
                            else if (e.Key == Keys.Down) 
                            {
                                // �t�H�[�J�X�ݒ�
                                //this._prevControl = this.tNedit_TMY_ID;//DEL�@���N�n���@2012/11/21 Redmine33560
                                this._prevControl = this.ApplyStaDate_TDateEdit;//ADD�@���N�n���@2012/11/21 Redmine33560
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            else
                            {
                                //�Ȃ��B
                            } 

                        }
                        break;
                    }
                 //�@�d����w��K�C�h
                case "uButton_SupplierGuide":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_PartySaleSlipNum;
                            }
                            //---ADD�@���N�n���@2012/11/21 Redmine33560------>>>>>
                            else if ((e.Key == Keys.Enter) || (e.Key == Keys.Down) || (e.Key == Keys.Right))
                            {
                                this._prevControl = this.ApplyStaDate_TDateEdit;
                            }
                            //---ADD�@���N�n���@2012/11/21 Redmine33560------<<<<<
                            else if (e.Key == Keys.Left)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_SupplierCd;
                            }
                            //---DEL�@���N�n���@2012/11/21 Redmine33560------>>>>>
                            //else if (e.Key == Keys.Right)
                            //{
                            //    // �t�H�[�J�X�ݒ�
                            //    this._prevControl = this.uButton_SupplierGuide;
                            //}
                            //else if ((e.Key == Keys.Enter)|| (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            //{
                            //    // �t�H�[�J�X�ݒ�
                            //    //this._prevControl = this.tNedit_TMY_ID;//DEL�@���N�n���@2012/11/21 Redmine33560
                            //    this._prevControl = this.tEdit_TMY_ID;//DEL�@���N�n���@2012/11/21 Redmine33560
                            //}
                            //---DEL�@���N�n���@2012/11/21 Redmine33560------<<<<<
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        break;
                    }
                //�@TMY_ID
                //case "tNedit_TMY_ID"://DEL�@���N�n���@2012/11/21 Redmine33560
                case "tEdit_TMY_ID"://ADD�@���N�n���@2012/11/21 Redmine33560
                    {
                        //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
                        //this.tNedit_TMY_ID.Text = this.tNedit_TMY_ID.GetInt().ToString();
                        //int inputTmyidValue = 0;
                        //if (Int32.TryParse(this.tNedit_TMY_ID.Text.Trim(), out inputTmyidValue))  
                        //{
                        //    if (inputTmyidValue == 0)
                        //    {
                        //        this.tNedit_TMY_ID.Clear();
                        //    }
                        //    else
                        //    {
                        //        //�Ȃ��B
                        //    }
                        //}
                        //else
                        //{
                        //    this.tNedit_TMY_ID.Clear();

                        //}
                        //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Up) || (e.Key == Keys.Left))
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tNedit_SupplierCd;
                            }
                            if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                //this._prevControl = this.tNedit_TMY_ID;//DEL�@���N�n���@2012/11/21 Redmine33560
                                this._prevControl = this.tEdit_TMY_ID;//ADD�@���N�n���@2012/11/21 Redmine33560
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        break;
                    }
                //�@�o�͐�
                case "tEdit_FilePath":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.ultraButton_FileName;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        break;
                    }
                 //�@�o�͐�K�C�h
                case "ultraButton_FileName":
                      {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Left)
                            {
                                // �t�H�[�J�X�ݒ�
                                this._prevControl = this.tEdit_FilePath;
                            }
                            else
                            {
                                //�Ȃ��B
                            }
                        }
                        break;
                    }
                  
            }


            e.NextCtrl = this._prevControl;
            //�K�C�h�{�^���c�[���L�������ݒ菈��
            if ((this._prevControl != null) && (this._prevControl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(this._prevControl);
                this.StatusBarMessageSettingProc(this._prevControl);
            }
            else
            {
                //�Ȃ��B
            } 
        }

        # region �� StatusBar���b�Z�[�W�\������ ��
        /// <summary>
        /// StatusBar���b�Z�[�W�\������
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        /// <remarks>
        /// <br>Note		: ����f�[�^�e�L�X�g�o�́i�s�l�x�jStatusBar���b�Z�[�W�\������</br>
        /// <br>Programmer  : ���N�n��</br>										
        /// <br>Date        : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// <br>Update Note : 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// <br>              Redmine#33560�@�C�����e�L�X�g��TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// <br>Update Note : 2012/11/27 ���N�n��</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// <br>              �������M�̒ǉ��d�l�ύX</br>
        /// </remarks>
        private void StatusBarMessageSettingProc(Control nextControl)
        {
            string message = "";

            if (nextControl.Name == ApplyStaDate_TDateEdit.Name)
            {
                message = MESSAGE_ApplyStaDate;
            }
            else if (nextControl.Name == ApplyEndDate_TDateEdit.Name)
            {
                message = MESSAGE_ApplyEndDate;
            }
            //---ADD�@���N�n���@2012/11/27 ------------>>>>>
            else if (nextControl.Name == uos_DataSendDiv.Name)
            {
                message = MESSAGE_SendDiv;
            }
            //---ADD�@���N�n���@2012/11/27 ------------<<<<<
            else if (nextControl.Name == tNedit_CustAnalysCode1.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode2.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode3.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode4.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode5.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tNedit_CustAnalysCode6.Name)
            {
                message = MESSAGE_Note;
            }
            else if (nextControl.Name == tEdit_CarMngCode.Name)
            {
                message = MESSAGE_CarMngCode;
            }
            else if (nextControl.Name == tEdit_SlipNote.Name)
            {
                message = MESSAGE_SlipNote;
            }
            else if (nextControl.Name == tEdit_SlipNote2.Name)
            {
                message = MESSAGE_SlipNote2;
            }
            else if (nextControl.Name == tEdit_SlipNote3.Name)
            {
                message = MESSAGE_SlipNote3;
            }
            else if (nextControl.Name == tEdit_PartySaleSlipNum.Name)
            {
                message = MESSAGE_PartySaleSlipNum;
            }
            else if (nextControl.Name == tNedit_SupplierCd.Name)
            {
                message = MESSAGE_SupplierCd;
            }
            //else if (nextControl.Name == tNedit_TMY_ID.Name)//DEL�@���N�n���@2012/11/21 Redmine33560
            else if (nextControl.Name == tEdit_TMY_ID.Name)//ADD�@���N�n���@2012/11/21 Redmine33560
            {
                message = MESSAGE_TMY_ID;
            }
            else if (nextControl.Name == tEdit_FilePath.Name)
            {
                message = MESSAGE_FilePath;
            }
            else
            {
                message = "";
            }
            StockDetailInput_StatusBarMessageSetting(this, message);
        }
        # endregion ��  StatusBar���b�Z�[�W�\������ ��

        # region �� �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g ��
        /// <summary>
        /// �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: ����f�[�^�e�L�X�g�o�́i�s�l�x�j�X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g</br>
        /// <br>Programmer  : ���N�n��</br>										
        /// <br>Date        : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// </remarks>
        private void StockDetailInput_StatusBarMessageSetting(object sender, string message)
        {
            this.ultraStatusBar2.Panels[0].Text = message;
        }

        # endregion �� �X�e�[�^�X�o�[���b�Z�[�W�\���C�x���g ��

        /// <summary>
        /// �d���於�̎擾
        /// </summary>
        /// <param name="supprCode">�d����R�[�h</param>
        /// <returns>�d���於</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�d���於�̎擾</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private string GetSupplierName(int supprCode)
        {
            if (this._supInfoSetDic.ContainsKey(supprCode))
            {
                return SubStringOfByte(this._supInfoSetDic[supprCode].SupplierNm1, 20);
            }
            else
            {
                return ctSupprName;
            }
        }

        /// <summary>
        /// GroupCollapsing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : GroupCollapsing �C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
          if ((e.Group.Key == "ResultGroup") ||
            (e.Group.Key == "OutPutGroup") ||
            (e.Group.Key == "ResultConditionGroup") ||
            (e.Group.Key == "OutPutConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// GroupExpanding �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : GroupExpanding �C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
             if ((e.Group.Key == "ResultGroup") ||
                (e.Group.Key == "OutPutGroup") ||
                (e.Group.Key == "ResultConditionGroup") ||
                (e.Group.Key == "OutPutConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : Button_Click �C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FilePath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �Ǘ��ԍ��K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ǘ��ԍ��K�C�h�{�^���N���b�N�C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void uButton_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
            CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

            paramInfo.EnterpriseCode = this._enterpriseCode;

            // �K�C�h�C�x���g�t���O
            paramInfo.IsGuideClick = true;
            // �u�V�K�o�^�v�s�\���Ȃ�
            paramInfo.IsDispNewRow = false;
            // ���Ӑ�\���L��
            paramInfo.IsDispCustomerInfo = true;
            //���Ӑ�R�[�h�i�荞�݂Ȃ�
            paramInfo.IsCheckCustomerCode = false;
            // �Ǘ��ԍ��i�荞�ݖ���
            paramInfo.IsCheckCarMngCode = false;
            // ���q�Ǘ��敪�`�F�b�N�L��
            paramInfo.IsCheckCarMngDivCd = true;
            int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_CarMngCode.Text = selectedInfo.CarMngCode;
                this.tEdit_SlipNote.Focus();
                this.SettingGuideButtonToolEnabled(this.tEdit_SlipNote);
                this.StatusBarMessageSettingProc(this.tEdit_SlipNote);
            }
            else
            {
                //�Ȃ��B
            }
        }

        /// <summary>
        /// �d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����K�C�h�{�^���N���b�N�C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560�@�C�����e�L�X�g��TMY-ID�ɂ��Ă̎d�l�ύX</br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            Supplier retSupplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
            int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd.Text = retSupplier.SupplierCd.ToString("000000");
                this.uLabel_SupplierName.Text = SubStringOfByte(retSupplier.SupplierNm1, 20);
                //---DEL�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
                //this.tNedit_TMY_ID.Focus();
                //this.SettingGuideButtonToolEnabled(this.tNedit_TMY_ID);
                //this.StatusBarMessageSettingProc(this.tNedit_TMY_ID);
                //---DEL�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<
                //---ADD�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
                this.ApplyStaDate_TDateEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ApplyStaDate_TDateEdit);
                this.StatusBarMessageSettingProc(this.ApplyStaDate_TDateEdit);
                //---ADD�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<

            }
            else
            {
                //�Ȃ��B
            } 
        }
        # endregion

        // ===================================================================================== //
        // �I�t���C����ԃ`�F�b�N����
        // ===================================================================================== //
        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
                else
                {
                    //�Ȃ��B
                }
            }
            return true;
        }

        /// <summary>				
        /// �����[�g�ڑ��\����				
        /// </summary>				
        /// <returns>���茋��</returns>				
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���				
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        # region �������M�̒ǉ�
        //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
        /// <summary>
        /// �������MXML����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������MXML����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/11/27</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ��d�l�ύX</br>
        /// <br>UpDate Note: 2013/04/09 ���N</br>
        /// <br>           : Redmine#35305 �C�����e�L�X�g�쐬</br>
        /// </remarks>
        private int SaveNetSendSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            try
            {
                int rowsCount = this._salesSliptextAcs.SalesSliptextCsv.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // �f�[�^�敪������
                XmlElement dtkbn = null;
                // TMY-ID��������
                XmlElement pmwscd = null;
                // ���Ӑ溰�ޏ�����
                XmlElement kjcd = null;
                // ������t������
                XmlElement dndt = null;
                // ����`�[�ԍ�������
                XmlElement dnno = null;
                // ����s�ԍ�������
                XmlElement dngyno = null;
                // ���i�ԍ�������
                XmlElement pmncd = null;
                // ���i���[�J�[�R�[�h������
                XmlElement mkcd = null;
                // BL���i�R�[�h������
                XmlElement blcd = null;
                // �o�א�������
                XmlElement sksu = null;
                // �d����R�[�h������
                XmlElement psicd = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // �f�[�^�敪
                    dtkbn = xmldoc.CreateElement("DTKBN");
                    dtkbn.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["DATADIV"].ToString();
                    data.AppendChild(dtkbn);

                    // TMY-ID
                    pmwscd = xmldoc.CreateElement("PMWSCD");
                    pmwscd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["TMYID"].ToString();
                    data.AppendChild(pmwscd);

                    // ���Ӑ溰��
                    kjcd = xmldoc.CreateElement("KJCD");
                    //kjcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["CUSTOMERCODE"]).ToString(); // DEL ���N�@2013/04/09 Redmine#35305
                    kjcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["CUSTOMERCODE"]).ToString().PadLeft(8, '0');// ADD ���N�@2013/04/09 Redmine#35305
                    data.AppendChild(kjcd);

                    // ������t
                    dndt = xmldoc.CreateElement("DNDT");
                    dndt.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SALESDATE"].ToString();
                    data.AppendChild(dndt);

                    // ����`�[�ԍ�
                    dnno = xmldoc.CreateElement("DNNO");
                    dnno.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SALESSLIPNUM"].ToString();
                    data.AppendChild(dnno);

                    // ����s�ԍ�
                    dngyno = xmldoc.CreateElement("DNGYNO");
                    dngyno.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SALESROWNO"].ToString();
                    data.AppendChild(dngyno);

                    // ���i�ԍ�
                    pmncd = xmldoc.CreateElement("PHNCD");
                    pmncd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["GOODSNO"].ToString();
                    data.AppendChild(pmncd);

                    // ���i���[�J�[�R�[�h
                    mkcd = xmldoc.CreateElement("MKCD");
                    //mkcd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["GOODSMAKERCD"].ToString(); // DEL ���N�@2013/04/09 Redmine#35305
                    mkcd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["GOODSMAKERCD"].ToString().PadLeft(4, '0');// ADD ���N�@2013/04/09 Redmine#35305
                    data.AppendChild(mkcd);

                    // BL���i�R�[�h
                    blcd = xmldoc.CreateElement("BLCD");
                    if (this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["BLGOODSCODE"] == DBNull.Value)
                    {
                        blcd.InnerText = string.Empty;
                    }
                    else
                    {
                        //blcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["BLGOODSCODE"]).ToString(); // DEL ���N�@2013/04/09 Redmine#35305
                        blcd.InnerText = Convert.ToInt32(this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["BLGOODSCODE"]).ToString().PadLeft(5, '0');// ADD ���N�@2013/04/09 Redmine#35305
                    }
                    data.AppendChild(blcd);

                    // �o�א�
                    sksu = xmldoc.CreateElement("SKSU");
                    sksu.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SHIPMENTCNT"].ToString();
                    data.AppendChild(sksu);

                    // �d����R�[�h
                    psicd = xmldoc.CreateElement("PSICD");
                    psicd.InnerText = this._salesSliptextAcs.SalesSliptextCsv.Rows[i]["SUPPLIERCD"].ToString();
                    data.AppendChild(psicd);

                    root.AppendChild(data);
                }

                //XML��������
                xmldoc.Save(this._xmlfileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageIn = "XML�t�@�C���̏������݂Ɏ��s���܂����B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageIn, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

            return status;
        }

        /// <summary>
        /// XML�̍폜
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML�̍폜 </br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/11/27</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private int DeleteFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            ArrayList fileList = new ArrayList();

            try
            {
                // �t�@�C�����폜
                FileInfo info = new FileInfo(this._xmlfileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                resultMessageDe = "XML�t�@�C���̍폜�Ɏ��s���܂����B";
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, resultMessageDe, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            return status;
        }
        //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
        # endregion
    }
}