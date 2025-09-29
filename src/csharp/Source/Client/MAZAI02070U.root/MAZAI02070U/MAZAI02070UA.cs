//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉꗗ�\
// �v���O�����T�v   :  �݌Ɉꗗ�\ �t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� �m
// �� �� ��  2007/03/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007/10/05  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/01/21  �C�����e : DC.NS�Ή��i�s��Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �D�c �E�l
// �C �� ��  2008/02/26  �C�����e : DC.NS�Ή��i���ʏC��:���t�`�F�b�N�A�O���ߑΉ��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/02/29  �C�����e : �s��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ����
// �C �� ��  2008/08/01  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/10/07  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/05  �C�����e : �s��Ή�[12173]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/25  �C�����e : �s��Ή�[12809]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/03  �C�����e : �s��Ή�[13000]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : �s��Ή�[13101]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/25  �C�����e : �s��Ή�[13586]
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 �s��Ή�[12894]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ɉꗗ�\ �t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉꗗ�\ �t�h�N���X�̏o�͏������͂��s���܂��B</br>
    /// <br>Programmer : 23010 ���� �m</br>
    /// <br>Date       : 2007.03.22</br>
    /// <br>Update Note: 2007.10.05 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.01.21 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή��i�s��Ή��j</br>
    /// <br>Update Note: 2008.02.26 20081 �D�c �E�l</br>
    /// <br>			 �EDC.NS�Ή��i���ʏC��:���t�`�F�b�N�A�O���ߑΉ��j</br>
    /// <br>Update Note: 2008.02.29 980035 ���� ��`</br>
    /// <br>			 �E�s��Ή�</br>
    /// <br>Update Note: 2008.08.01 30416 ���� ����</br>
    /// <br>Update Note: 2008/10/07       �Ɠc �M�u</br>
    /// <br>			 �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>           : 2009/03/05       �Ɠc �M�u�@�s��Ή�[12173]</br>
    /// <br>           : 2009/03/25       �Ɠc �M�u�@�s��Ή�[12809]</br>
    /// <br>           : 2009/04/03       �Ɠc �M�u�@�s��Ή�[13000]</br>
    /// <br>           : 2009/04/13       ��� �r���@�s��Ή�[13101]</br>
    /// <br>           : 2009/06/25       �Ɠc �M�u�@�s��Ή�[13586]</br>
    /// <br></br>
    /// </remarks>
    public partial class MAZAI02070UA : Form,
                                        IPrintConditionInpType,						// ���[����(�������̓^�C�v)
                                        IPrintConditionInpTypeSelectedSection,		// ���[�Ɩ�(��������)���_�I��
                                        IPrintConditionInpTypePdfCareer				// ���[�Ɩ�(��������)PDF�o�͗����Ǘ�
    {

        #region Constructor
        // <summary>
        /// �݌Ɉꗗ�\ �t�h�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɉꗗ�\ �t�h�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 23010 ���� �m</br>
        /// <br>Date       : 2007.03.22</br>
        /// <br></br>
        /// </remarks>
        public MAZAI02070UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�p��Hashtable�쐬
            this._hashSecList = new Hashtable();           
            //��ʃf�U�C���ύX�N���X
            this._controlScreenSkin = new ControlScreenSkin();
            //���O�C�����_�R�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();  // 2008.02.26 add
        }
        #endregion

        # region �G���g�� �|�C���g
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAZAI02070UA());
        }
        #endregion

        #region Events
        /// <summary>�t���[���c�[���o�[�ݒ�C�x���g</summary>
        public event Broadleaf.Application.Common.ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Private Members
        // ��ƃR�[�h
        private string _enterpriseCode = "";       
        // ���o�����N���X
        private StockListCndtn _stockListCndtn = new StockListCndtn();
        // �I�����_
        private Hashtable _hashSecList = null;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;   
        // ------------------------------
        // IPrintConditionInpType�̃v���p�e�B�p�ϐ�
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        // ------------------------------
        // IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ�
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L���v���p�e�B
        private bool _isOptSection = false;
        // �{�Ћ@�\�L���v���p�e�B
        private bool _isMainOfficeFunc = false;
        // �Ǘ��敪���X�g
        private Hashtable _duplicationShelfNoList1 = new Hashtable();
        // �Ǘ��敪���X�g
        private Hashtable _duplicationShelfNoList2 = new Hashtable();

        // ------------------------------
        // IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ�
        // ���[����
        private string _printName = "�݌Ɉꗗ�\";
        // ���[�L�[
        private string _printKey = "4231e013-16ce-4695-af71-a03ced02af56";      
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin;
        ///���[�J�[�}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;  
        ///���i�敪�O���[�v�}�X�^�A�N�Z�X�N���X
        //private LGoodsGanreAcs _lGoodsGanreAcs = null;    // DEL 2008.08.01
        ///���i�敪�}�X�^�A�N�Z�X�N���X
        //private MGoodsGanreAcs _mGoodsGanreAcs = null;    // DEL 2008.08.01
        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
        ////�L�����A�K�C�h
        //private CarrierOdrAcs _carrierOdrAcs = null;
        //���i�敪�ڍ׃}�X�^�A�N�Z�X�N���X
        //private DGoodsGanreAcs _dGoodsGanreAcs = null;    // DEL 2008.08.01
        //�q�ɃK�C�h
        private WarehouseAcs _warehouseGuideAcs = null;
        //�a�k���i�}�X�^�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs = null;
        //���[�U�[�K�C�h�}�X�^�A�N�Z�X�N���X�i���Е��ށj
        //private UserGuideGuide _userGuideGuide = null;    // DEL 2008.08.01
        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
        // ���t�擾���i
        private DateGetAcs _dateGet;  // 2008.02.26 add

        private UserGuideAcs _userGuideAcs = null;          //ADD 2009/06/25 �s��Ή�[13586]

        //--- ADD 20080/08/01 ---------->>>>>
        // �d����
        SupplierAcs _supplierAcs;
        //--- ADD 20080/08/01 ----------<<<<<

        // ADD 2009/03/31 �s��Ή�[12894]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
        /// <summary>���s�^�C�v���W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _publicationTypeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���s�^�C�v���W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���s�^�C�v���W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper PublicationTypeRadioKeyPressHelper
        {
            get { return _publicationTypeRadioKeyPressHelper; }
        }

        /// <summary>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _newPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }

        /// <summary>�o�͏����W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _changePageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// �o�͏����W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>�o�͏����W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper ChangePageDivRadioKeyPressHelper
        {
            get { return _changePageDivRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 �s��Ή�[12894]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<

        #endregion

        #region Private Constant
        // �N���XID
        private const string CT_CLASSID = "MAZAI02070UA";
        // �v���O����ID
        private const string CT_PGID = "MAZAI02070U";
        // �v���O��������
        private const string CT_PGNM = "�݌Ɉꗗ�\";      
                      
        #endregion
        
        #region Properties
        // ------------------------------
        // IPrintConditionInpType�̃v���p�e�B
        /// <summary>
        /// ���o�{�^����Ԏ擾�v���p�e�B
        /// </summary>
        public bool CanExtract
        {
            get
            {
                return this._canExtract;
            }
        }

        /// <summary>
        /// PDF�o�̓{�^����Ԏ擾�v���p�e�B
        /// </summary>
        public bool CanPdf
        {
            get
            {
                return this._canPdf;
            }
        }

        /// <summary>
        /// ����{�^����Ԏ擾�v���p�e�B
        /// </summary>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>
        /// ���o�{�^���\���L���v���p�e�B
        /// </summary>
        public bool VisibledExtractButton
        {
            get
            {
                return this._visibledExtractButton;
            }
        }

        /// <summary>
        /// PDF�o�̓{�^���\���L���v���p�e�B
        /// </summary>
        public bool VisibledPdfButton
        {
            get
            {
                return this._visibledPdfButton;
            }
        }

        /// <summary>
        /// ����{�^���\���L���v���p�e�B
        /// </summary>
        public bool VisibledPrintButton
        {
            get
            {
                return this._visibledPrintButton;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypeSelectedSection�̃v���p�e�B
        /// <summary>
        /// �v�㋒�_�I��\���擾�v���p�e�B
        /// </summary>
        public bool VisibledSelectAddUpCd
        {
            get
            {
                return this._visibledSelectAddUpCd;
            }
        }

        /// <summary>
        /// ���_�I�v�V�����L���v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get
            {
                return this._isOptSection;
            }
            set
            {
                this._isOptSection = value;
            }
        }

        /// <summary>
        /// �{�Ћ@�\�L���v���p�e�B
        /// </summary>
        public bool IsMainOfficeFunc
        {
            get
            {
                return this._isMainOfficeFunc;
            }
            set
            {
                this._isMainOfficeFunc = value;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ�
        /// <summary>
        /// ���[����
        /// </summary>
        public string PrintName
        {
            get
            {
                return this._printName;
            }
        }

        /// <summary>
        /// ���[�L�[
        /// </summary>
        public string PrintKey
        {
            get
            {
                return this._printKey;
            }
        }

        #endregion

        #region Public Methods

        // ------------------------------
        // IPrintConditionInpType�̃v���p�e�B
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">���[�ݒ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʕ\���������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void Show(object parameter)
        {                        
            this.Show();
        }

        /// <summary>
        /// ����O���̓`�F�b�N
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ����O���̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool result = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                result = false;
            }

            return result;
        }
      		
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">������p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = CT_PGID;// �N��PGID
                     
            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            if ((int)this.uos_PublicationType.Value == 0)
            {
                printInfo.PrintPaperSetCd = 10;
            }
            else
            {
                printInfo.PrintPaperSetCd = 20; 
            }

            // ��ʁ����o�����N���X
            int status = this.SetExtrInfoFromScreen(ref this._stockListCndtn);
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._stockListCndtn;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">������p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // ���o�����͖���
            return 0;
        }

        // ------------------------------
        // IPrintConditionInpTypeSelectedSection�̃v���p�e�B
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��
        /// </summary>
        /// <param name="addUpCd">�I�����_���</param>
        /// <remarks>
        /// <br>Note       : �I������Ă���v�㋒�_��ݒ肵�܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // ���g�p
        }

        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_</param>
        /// <param name="checkState"></param>
        /// <remarks>
        /// <br>Note       : ���_�I���������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, System.Windows.Forms.CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ��
                if (sectionCode == "0")
                {
                    // �I��I�����X�g���N���A
                    this._hashSecList.Clear();
                }

                // ���X�g�ɋ��_���ǉ�����Ă��Ȃ����A���_�̏�Ԃ�ǉ�
                if (this._hashSecList.ContainsKey(sectionCode) == false)
                {
                    this._hashSecList.Add(sectionCode, checkState);
                }           
            }
            // ���_�̑I��������������
            else if (checkState == CheckState.Unchecked)
            {
                // �I�����_���X�g����폜
                if (this._hashSecList.ContainsKey(sectionCode))
                {
                    this._hashSecList.Remove(sectionCode);
                }             
            }
        }       

        /// <summary>
        /// �v�㋒�_�I������
        /// </summary>
        /// <param name="addUpCd">�I�����_���</param>
        /// <remarks>
        /// <br>Note       : �v�㋒�_�I������</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // ���g�p
        }

        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �I������Ă��鋒�_��ݒ肵�܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            if (sectionCodeLst.Length == 0)
            {
                return;
            }

            this._hashSecList.Clear();
            for (int ix = 0; ix < sectionCodeLst.Length; ix++)
            {
                // �I�����_��ǉ�
                this._hashSecList.Add(sectionCodeLst[ix], CheckState.Checked);
            }
        }

        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">�����\���L���X�e�[�^�X</param>
        /// <returns>�ύX��\���L���X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�I���X���C�_�[�̕\���L���𔻒肵�܂��B</br>
        /// <br>           : ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            // �ύX���Ȃ�
            //return isDefaultState;            //DEL 2009/04/03 �s��Ή�[13000]
            return false;                       //ADD 2009/04/03 �s��Ή�[13000]
        }
        #endregion

        #region Private Methods

        #region ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏������������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�o�͏��R���{�{�b�N�X�̏����ݒ�(0:���[�J�[��,1:�L�����A��,2:�ŏI�d����,3:���i�O���[�v�E�敪,4:�@��,5:�o�׉\��)
            //this.ChangePageDiv_tComboEditor.Items.Add(0, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_MakerCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(1,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_CarrierCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(2,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_StockDate));
            //this.ChangePageDiv_tComboEditor.Items.Add(3,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_LargeMediumGoodsGanreCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(4,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_CellPhoneModeleCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(5,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_ShipmentPosCnt));
            //this.ChangePageDiv_tComboEditor.SelectedIndex = 0;

            //�o�͏��R���{�{�b�N�X�̏����ݒ�(0:�q�ɏ�,1:���[�J�[��,2:�ŏI�d����,3:�o�׉\��,4:���i�O���[�v�E�敪�E�敪�ڍ�,5:���Е���,6:�a�k�R�[�h)
            //--- DEL 2008/08/01 ---------->>>>>
            //this.ChangePageDiv_tComboEditor.Items.Add(0, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_WarehouseCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(1, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_MakerCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(2, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_StockDate));
            //this.ChangePageDiv_tComboEditor.Items.Add(3, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_ShipmentPosCnt));
            //this.ChangePageDiv_tComboEditor.Items.Add(4, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_LargeGoodsGanreCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(5, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_EnterpriseGanreCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(6, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_BLGoodsCode));
            //this.ChangePageDiv_tComboEditor.SelectedIndex = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            /* ---DEL 2009/03/05 �s��Ή�[12173] -------------------------------->>>>>
            DateTime thisMonth;
            _dateGet.GetThisYearMonth(out thisMonth);

            // �J�n�Ώۓ��t�����l�ݒ�
            this.tde_St_AddUpYearMonth.SetDateTime(thisMonth);
            // �I���Ώۓ��t�����l�ݒ�
            this.tde_Ed_AddUpYearMonth.SetDateTime(thisMonth);
               ---DEL 2009/03/05 �s��Ή�[12173] --------------------------------<<<<< */
            // ---ADD 2009/03/05 �s��Ή�[12173] -------------------------------->>>>>
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                // ���㍡�񌎎��X�V����ݒ�
                this.tde_St_AddUpYearMonth.SetDateTime(currentTotalMonth);
                this.tde_Ed_AddUpYearMonth.SetDateTime(currentTotalMonth);
            }
            else
            {
                // ������ݒ�
                DateTime nowYearMonth;
                this._dateGet.GetThisYearMonth(out nowYearMonth);

                this.tde_St_AddUpYearMonth.SetDateTime(nowYearMonth);
                this.tde_Ed_AddUpYearMonth.SetDateTime(nowYearMonth);
            }
            // ---ADD 2009/03/05 �s��Ή�[12173] --------------------------------<<<<<

            // �J�n�o�א��w��
            this.StartShipmentPosCnt_tNedit.SetInt(1);
            // �I���o�א��w��
            this.EndShipmentPosCnt_tNedit.SetInt(999999999);

            // �݌ɓo�^�������l�ݒ�
            this.tde_StockCreateDate.SetDateTime(TDateTime.GetSFDateNow());

            // ���s�^�C�v�����l�ݒ�
            this.uos_PublicationType.Value = 0;

            // ���ŏ����l�ݒ�
            this.uos_NewPageDiv.Value = 0;

            // �o�͏������l�ݒ�
            this.uos_ChangePageDiv.Value = 0;

            // �I�ԃu���C�N�����l�ݒ�
            this.ce_WarehouseShelfNoBreakDiv.Value = 0;
            //--- ADD 2008/08/01 ----------<<<<<
            // ---ADD 2009/03/25 �s��Ή�[12809] ------------------------------------------------>>>>>
            // �K�{�F�ݒ�
            this.tde_St_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
            this.tde_Ed_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
            this.tde_StockCreateDate.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
            this.ce_StockCreateDateDiv.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            this.ce_WarehouseShelfNoBreakDiv.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // ---ADD 2009/03/25 �s��Ή�[12809] ------------------------------------------------<<<<<
        }

        // ---ADD 2009/06/25 �s��Ή�[13586] -------------------------------->>>>>
        /// <summary>
        /// �Ǘ��敪���̐ݒ�
        /// </summary>
        /// <param name="control">�ΏۃR���g���[��</param>
        /// <param name="guideDivCode">�K�C�h�敪</param>
        private void SetDuplicationShelfNo(CheckedListBox control, int guideDivCode)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            //������
            for (int i = 0; i < 10; i++)
            {
                control.Items[i] = "���o�^";
            }

            //�ǂݍ���
            ArrayList arrayList = null;
            int status = this._userGuideAcs.SearchDivCodeBody(out arrayList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }
            if (arrayList == null)
            {
                return;
            }
            if (arrayList.Count == 0)
            {
                return;
            }

            //���̃Z�b�g
            UserGdBd userGdBd = null;
            for (int i = 0; i < arrayList.Count; i++)
            {
                userGdBd = (UserGdBd)arrayList[i];
                if ((0 <= userGdBd.GuideCode) || (userGdBd.GuideCode <= 9))
                {
                    control.Items[userGdBd.GuideCode] = userGdBd.GuideName;
                }
            }
        }
        // ---ADD 2009/06/25 �s��Ή�[13586] --------------------------------<<<<<

        #endregion

        #region ���o�����i�[����
        /// <summary>
        /// ���o����UI�N���X�f�[�^�i�[����(��ʏ��˒��o����UI�N���X)
        /// </summary>
        /// <param name="extraInfo">���o����UI�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���o�����ڍ׏�����ʂ���擾���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private int SetExtrInfoFromScreen(ref StockListCndtn extraInfo)
        {
            const string ctPROCNM = "SetExtrInfoFromScreen";
            int status = 0;

            if (extraInfo == null)
            {
                extraInfo = new StockListCndtn();
            }

            try
            {              
                // ���_�I�v�V����
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.IsOptSection = this._isOptSection;
                //// �I�v�V��������̂Ƃ�
                //if (this._isOptSection)
                //{
                //    ArrayList secList = new ArrayList();
                //    // �S�БI�����ǂ���
                //    if ((this._hashSecList.Count == 1) && (this._hashSecList.ContainsKey("0")))
                //    {                    
                //        extraInfo.DepositStockSecCodeList = new string[0];
                //    }
                //    else
                //    {
                //        foreach (DictionaryEntry dicEntry in this._hashSecList)
                //        {
                //            if ((CheckState)dicEntry.Value == CheckState.Checked)
                //            {
                //                secList.Add(dicEntry.Key);
                //            }
                //        }
                //        extraInfo.DepositStockSecCodeList = (string[])secList.ToArray(typeof(string));
                //    }
                //}
                // // ���_�I�v�V�����Ȃ��̎�
                //else
                //{
                //   extraInfo.DepositStockSecCodeList = new string[0];
                //}
                /* ---DEL 2009/04/03 �s��Ή�[13000] ------------------------------------------------>>>>>
                ArrayList secList = new ArrayList();
                // �S�БI�����ǂ���
                if ((this._hashSecList.Count == 1) && (this._hashSecList.ContainsKey("0")))
                {                    
                    extraInfo.DepositStockSecCodeList = new string[0];
                }
                else
                {
                    foreach (DictionaryEntry dicEntry in this._hashSecList)
                    {
                        if ((CheckState)dicEntry.Value == CheckState.Checked)
                        {
                            secList.Add(dicEntry.Key);
                        }
                    }
                    extraInfo.DepositStockSecCodeList = (string[])secList.ToArray(typeof(string));
                }
                   ---DEL 2009/04/03 �s��Ή�[13000] ------------------------------------------------<<<<< */
                extraInfo.DepositStockSecCodeList = new string[0];          //ADD 2009/04/03 �s��Ή�[13000] �S�ЌŒ�
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
               
                // ��ƃR�[�h
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.EnterPriseCode = this._enterpriseCode;
                extraInfo.EnterpriseCode = this._enterpriseCode;
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                ////��ʏ�񁨏����N���X                  

                // �o�͏�
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.ChangePageDiv = (int)this.ChangePageDiv_tComboEditor.Value;
                //extraInfo.ChangePageDivName = StockListCndtn.GetSortName((int)this.ChangePageDiv_tComboEditor.Value);
                //--- DEL 2008/08/01 ----------<<<<<
                //--- ADD 2008/08/01 ---------->>>>>
                extraInfo.ChangePageDiv = (int)this.uos_ChangePageDiv.Value;
                //--- ADD 2008/08/01 ---------->>>>>
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //// ���[�J�[�R�[�h
                //extraInfo.St_MakerCode = this.StartMakerCode_tNedit.GetInt();
                //extraInfo.Ed_MakerCode = this.EndMakerCode_tNedit.GetInt();
                //// ���i�R�[�h
                //extraInfo.St_GoodsCode = this.StartGoodsCode_tEdit.DataText;
                //extraInfo.Ed_GoodsCode = this.EndGoodsCode_tEdit.DataText;
                // ���[�J�[�R�[�h
                extraInfo.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                /* --- DEL 2008/10/07 To���󎚎��A""��ALL9�̋�ʂ�����K�v������ׁA�l�͂��̂܂ܓn�� ---------------------->>>>>
                // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_GoodsMakerCd = this.EndMakerCode_tNedit.GetInt();
                if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                {
                    //extraInfo.Ed_GoodsMakerCd = 999999;       //DEL 2008/10/07 �����ύX
                    extraInfo.Ed_GoodsMakerCd = 9999;           //ADD 2008/10/07
                }
                else
                {
                    extraInfo.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                }
                // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                   --- DEL 2008/10/07 ---------------------------------------------------------------------------------------<<<<< */
                extraInfo.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();       //ADD 2008/10/07

                // ���i�R�[�h
                extraInfo.St_GoodsNo = this.tEdit_GoodsNo_St.DataText;
                extraInfo.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.DataText;
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //// �L�����A�R�[�h
                //extraInfo.St_CarrierCode = this.StartCarrierCode_tNedit.GetInt();
                //extraInfo.Ed_CarrierCode = this.EndCarrierCode_tNedit.GetInt();
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                // ���i�敪�O���[�v�R�[�h
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_LargeGoodsGanreCode = this.StartLargeGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_LargeGoodsGanreCode = this.EndLargeGoodsGanreCode_tEdit.DataText;
                //--- DEL 2008/08/01 ----------<<<<<
                // ���i�敪�R�[�h
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_MediumGoodsGanreCode = this.StartMediumGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_MediumGoodsGanreCode = this.EndMediumGoodsGanreCode_tEdit.DataText;
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                // ���i�敪�ڍ׃R�[�h
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_DetailGoodsGanreCode = this.StartDetailGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_DetailGoodsGanreCode = this.EndDetailGoodsGanreCode_tEdit.DataText;
                //--- DEL 2008/08/01 ----------<<<<<
                // ���Е��ރR�[�h
                //extraInfo.St_EnterpriseGanreCode = this.StartEnterpriseGanreCode_tNedit.GetInt();     // DEL 2008.08.01
                // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
                //--- DEL 2008/08/01 ---------->>>>>
                //if (this.EndEnterpriseGanreCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = 9999;
                //}
                //else
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                // �a�k���i�R�[�h
                extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                /* --- DEL 2008/10/07 To���󎚎��A""��ALL9�̋�ʂ�����K�v������ׁA�l�͂��̂܂ܓn�� ---------------------->>>>>
                // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_BLGoodsCode = this.EndBLGoodsCode_tNedit.GetInt();
                if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                {
                    //extraInfo.Ed_BLGoodsCode = 99999999;      //DEL 2008/10/07 �����ύX
                    extraInfo.Ed_BLGoodsCode = 99999;           //ADD 2008/10/07
                }
                else
                {
                    extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                }
                // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                   --- DEL 2008/10/07 ---------------------------------------------------------------------------------------<<<<< */
                extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();         //ADD 2008/10/07

                // �q�ɃR�[�h
                extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;
                // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                // �݌ɋ敪
                //extraInfo.StockDiv = StockListCndtn.GetStockDiv(this.StockDiv_ultraOptionSet.CheckedIndex);
                // 2008.02.29 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.StockDiv = this.StockDiv_ultraOptionSet.CheckedIndex;
                //--- DEL 2008/08/01 ---------->>>>>
                //if (this.StockDiv_ultraOptionSet.CheckedIndex == 1)
                //{
                //    extraInfo.StockDiv = 2;
                //}
                //else
                //{
                //    extraInfo.StockDiv = this.StockDiv_ultraOptionSet.CheckedIndex;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2008.02.29 �C�� <<<<<<<<<<<<<<<<<<<<
                // �ŏI�d����
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_LastStockDate = this.StartDate_tDateEdit.GetDateTime();
                //extraInfo.Ed_LastStockDate = this.EndDate_tDateEdit.GetDateTime();
                //--- DEL 2008/08/01 ----------<<<<<
                // �J�n�o�׉\��
                extraInfo.St_ShipmentPosCnt = this.StartShipmentPosCnt_tNedit.GetValue();
                // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_ShipmentPosCnt = this.EndShipmentPosCnt_tNedit.GetValue();
                if (this.EndShipmentPosCnt_tNedit.GetValue() == 0)
                {
                    extraInfo.Ed_ShipmentPosCnt = 99999999;
                }
                else
                {
                    extraInfo.Ed_ShipmentPosCnt = this.EndShipmentPosCnt_tNedit.GetValue();
                }
                // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008.08.01 ---------->>>>>
                ////////////���\�����ځ�/////////////////////////////////////////////////////////////////////////////
                //// �d���݌ɐ�
                //extraInfo.St_SupplierStock = 0;
                //extraInfo.Ed_SupplierStock = 99999999;
                //// �����
                //extraInfo.St_TrustCount = 0;
                //extraInfo.Ed_TrustCount = 99999999;
                //// �ŏI�����
                //extraInfo.St_LastSalesDate = DateTime.MinValue;
                //extraInfo.Ed_LastSalesDate = DateTime.MinValue;
                //// �ŏI�I���X�V��
                //// 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.St_LastInventoryUpDate = DateTime.MinValue;
                ////extraInfo.Ed_LastInventoryUpDate = DateTime.MinValue;
                //extraInfo.St_LastInventoryUpdate = DateTime.MinValue;
                //extraInfo.Ed_LastInventoryUpdate = DateTime.MinValue;
                //// 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                //// 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                ////// �@��R�[�h
                ////extraInfo.St_CellphoneModelCode  = "";
                ////extraInfo.Ed_CellphoneModelCode  = "";
                //// 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                /////////////////////////////////////////////////////////////////////////////////////////////////////
                //--- DEL 2008.08.01 ----------<<<<<

                //--- ADD 2008/08/01 ---------->>>>>
                // �Ώ۔N��
                extraInfo.St_LastStockDate = this.tde_St_AddUpYearMonth.GetDateTime();
                // �Ώ۔N��
                extraInfo.Ed_LastStockDate = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // �݌ɓo�^��
                extraInfo.StockCreateDate = this.tde_StockCreateDate.GetDateTime();
                // �݌ɓo�^�������t���O
                extraInfo.StockCreateDateFlg = (StockListCndtn.StockCreateDateDivState)this.ce_StockCreateDateDiv.Value;
                // ���s�^�C�v
                extraInfo.PublicationType = (StockListCndtn.PublicationTypeState)this.uos_PublicationType.Value;
                // ���ŋ敪
                extraInfo.NewPageDiv = (StockListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;
                // ���i�Ǘ��敪�P
                this._duplicationShelfNoList1.Clear();
                for (int index = 0; index < this.clb_DuplicationShelfNo1.Items.Count; index++)
                {
                    // �`�F�b�N�L���擾
                    if (this.clb_DuplicationShelfNo1.GetItemChecked(index) == true)
                    {
                        this._duplicationShelfNoList1.Add(index.ToString(), index.ToString());
                    }
                }
                extraInfo.PartsManagementDivide1 = (string[])new ArrayList(this._duplicationShelfNoList1.Values).ToArray(typeof(string));

                // ���i�Ǘ��敪�Q
                this._duplicationShelfNoList2.Clear();
                for (int index = 0; index < this.clb_DuplicationShelfNo2.Items.Count; index++)
                {
                    // �`�F�b�N�L���擾
                    if (this.clb_DuplicationShelfNo2.GetItemChecked(index) == true)
                    {
                        this._duplicationShelfNoList2.Add(index.ToString(), index.ToString());
                    }
                }
                extraInfo.PartsManagementDivide2 = (string[])new ArrayList(this._duplicationShelfNoList2.Values).ToArray(typeof(string));

                // �J�n�d����R�[�h
                extraInfo.St_StockSupplierCode = this.tNedit_SupplierCd_St.GetInt();
                // �I���d����R�[�h
                /* --- DEL 2008/10/07 To���󎚎��A""��ALL9�̋�ʂ�����K�v������ׁA�l�͂��̂܂ܓn�� ---------------------->>>>>
                //extraInfo.Ed_StockSupplierCode = GetEndCode(this.tNedit_SupplierCd_Ed, 999999999);        //DEL 2008/10/07 �����ύX
                extraInfo.Ed_StockSupplierCode = GetEndCode(this.tNedit_SupplierCd_Ed, 999999);             //ADD 2008/10/07
                   --- DEL 2008/10/07 ---------------------------------------------------------------------------------------<<<<< */
                extraInfo.Ed_StockSupplierCode = this.tNedit_SupplierCd_Ed.GetInt();            //ADD 2008/10/07

                // �J�n�I��
                extraInfo.St_WarehouseShelfNo = tEdit_WarehouseShelfNo_St.Text;
                // �I���I��
                extraInfo.Ed_WarehouseShelfNo = tEdit_WarehouseShelfNo_Ed.Text;

                // �I�ԃu���C�N�敪
                extraInfo.WarehouseShelfNoBreakDiv = (StockListCndtn.WarehouseShelfNoBreakDivState)this.ce_WarehouseShelfNoBreakDiv.Value;
                //--- ADD 2008/08/01 ----------<<<<<
            }
            catch (Exception ex)
            {
                status = -1;
                MsgDispProc("���o�����̎擾�Ɏ��s���܂����B", status, ctPROCNM, ex);
            }

            return status;
        }
         
        #endregion

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        #region �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                CT_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                CT_PGNM,							// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2006.03.24</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                CT_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                CT_PGNM,							// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion       

        #region ��ʓ��̓`�F�b�N
        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�ΏۃR���g���[��</param>
        /// <returns>�`�F�b�N����(true/false)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���A�G���[���̓��b�Z�[�W�ƑΏۂ̃R���g���[����Ԃ��܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            // 2008.02.29 �C�� >>>>>>>>>>>>>>>>>>>>
            //bool result = false;
            bool result = true;
            // 2008.02.29 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 add start -------------------------------->>
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_NoInput = "����͂��ĉ�����";           // ADD 2008.08.01
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            const string ct_RangeError1 = "�͈͎̔w��Ɍ�肪����܂�(�P�Q�����ȓ��Őݒ肵�ĉ�����)";

            DateGetAcs.CheckDateRangeResult cdrResult;
            // 2008.02.26 add end ----------------------------------<<
            DateGetAcs.CheckDateResult cdResult;        // ADD 2008.08.01

            //���[�J�[�R�[�h
            if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") && (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
                {         
                    errMessage = "���[�J�[�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tNedit_GoodsMakerCd_St;
                    result = false;
                    return result;
                }
            }

            //���i�R�[�h
            if ((this.tEdit_GoodsNo_St.DataText.Trim() != "") && (this.tEdit_GoodsNo_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_GoodsNo_St.DataText.Trim().CompareTo(this.tEdit_GoodsNo_Ed.DataText.Trim()) > 0)
                {         
                    errMessage = "���i�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tEdit_GoodsNo_St;
                    result = false;
                    return result;
                }
            }

            //--- ADD 2008/08/01 ---------->>>>>
            // �Ώ۔N���i�J�n�`�I���j
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n�Ώ۔N��{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n�Ώ۔N��{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I���Ώ۔N��{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I���Ώ۔N��{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώ۔N��{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("�Ώ۔N��{0}", ct_RangeError1);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                result = false;
                return result;
            }

            // �݌ɓo�^��
            if (CallCheckDate(out cdResult, ref tde_StockCreateDate) == false)
            {
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("�݌ɓo�^��{0}", ct_NoInput);
                            errComponent = this.tde_StockCreateDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("�݌ɓo�^��{0}", ct_InputError);
                            errComponent = this.tde_StockCreateDate;
                        }
                        break;
                }
                result = false;
                return result;
            }
            //--- ADD 2008/08/01 ----------<<<<<

            // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�R�[�h
            //if ((this.StartCarrierCode_tNedit.DataText.Trim() != "") && (this.EndCarrierCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartCarrierCode_tNedit.GetInt() > this.EndCarrierCode_tNedit.GetInt())
            //    {         
            //        errMessage = "�L�����A�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartCarrierCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}
            // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 upd start -------------------------------------------->>
            //�o�͒��[�N���̃`�F�b�N1
            //result = DateCheck(this.StartDate_tDateEdit, this.EndDate_tDateEdit, ref errMessage, ref errComponent);
            //if (!result)
            //{
            //    return result;
            //}
            //--- DEL 2008/08/01 ---------->>>>>
            //// �ŏI�d�����i�J�n�`�I���j
            //if (CallCheckDateRange(out cdrResult, ref StartDate_tDateEdit, ref EndDate_tDateEdit) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("�ŏI�d���J�n��{0}", ct_InputError);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("�ŏI�d���J�n��{0}", ct_InputError);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("�ŏI�d���I����{0}", ct_InputError);
            //                errComponent = this.EndDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("�ŏI�d���I����{0}", ct_InputError);
            //                errComponent = this.EndDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("�ŏI�d����{0}", ct_RangeError);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format("�ŏI�d����{0}", ct_RangeError1);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //    }
            //    result = false;
            //    return result;
            //}
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.02.26 upd end ----------------------------------------------<<

             //���i�敪�O���[�v�R�[�h
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartLargeGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndLargeGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartLargeGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndLargeGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "���i�敪�O���[�v�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartLargeGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<
            
            //���i�敪�R�[�h
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartMediumGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndMediumGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartMediumGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndMediumGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "���i�敪�͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartMediumGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //���i�敪�ڍ׃R�[�h
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartDetailGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndDetailGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartDetailGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndDetailGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {
            //        errMessage = "���i�敪�ڍׂ͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartDetailGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            //���Е��ރR�[�h
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartEnterpriseGanreCode_tNedit.DataText.Trim() != "") && (this.EndEnterpriseGanreCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartEnterpriseGanreCode_tNedit.GetInt() > this.EndEnterpriseGanreCode_tNedit.GetInt())
            //    {
            //        errMessage = "���Е��ނ͈͎̔w��Ɍ�肪����܂��B";
            //        errComponent = this.StartEnterpriseGanreCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            //�a�k���i�R�[�h
            if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
                {
                    errMessage = "�a�k�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tNedit_BLGoodsCode_St;
                    result = false;
                    return result;
                }
            }

            //�q�ɃR�[�h
            if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseCode_St.DataText.Trim().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.Trim()) > 0)
                {
                    errMessage = "�q�ɂ͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tEdit_WarehouseCode_St;
                    result = false;
                    return result;
                }
            }
            // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

            //�o�׉\��
            if ((this.StartShipmentPosCnt_tNedit.DataText.Trim() != "") && (this.EndShipmentPosCnt_tNedit.DataText.Trim() != ""))
            {
                if (this.StartShipmentPosCnt_tNedit.GetInt() > this.EndShipmentPosCnt_tNedit.GetInt())
                {
                    errMessage = this.StartShipmentPosCnt_Title.Text + "�͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.StartShipmentPosCnt_tNedit;
                    result = false;
                    return result;
                }
            }

            //--- ADD 2008/08/01 ---------->>>>>
            // �d����i�J�n > �I�� �� NG�j
            //if (this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_St))       //DEL 2008/10/07 �`�F�b�N���s���Ȃ���
            if (this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_Ed))         //ADD 2008/10/07
            {
                errMessage = this.StockSupplierCode_Title.Text + "�͈͎̔w��Ɍ�肪����܂��B";
                errComponent = this.tNedit_SupplierCd_St;
                result = false;
                return result;
            }
            // �I��
            if (
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�I��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseShelfNo_St;
                result = false;
                return result;
            }
            //--- ADD 2008/08/01 ----------<<<<<

            return result;
        }
        #endregion      

        #endregion     

        #region ���t���̓`�F�b�N
        //--- ADD 2008.08.01 ---------->>>>>
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = _dateGet.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }
        //--- ADD 2008.08.01 ----------<<<<<

        // 2008.02.26 add start -------------------------------->>
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.02.26 add end ----------------------------------<<

        /// <summary>
        /// ���t���ړ��̓`�F�b�N�֐�
        /// </summary>
        /// <param name="startDateEdit">�J�n���t�R���|�[�l���g</param>
        /// <param name="endDateEdit">�I�����t�R���|�[�l���g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>   
        /// <param name="errComponent">���̓G���[�R���g���[��</param>
        /// <returns>true:���� false:�ُ�</returns>
        private bool DateCheck(TDateEdit startDateEdit, TDateEdit endDateEdit, ref string msg, ref Control errComponent)
        {
            bool status = true;

            if (IsErrorTDateEdit(startDateEdit, true))
            {
                msg += "�J�n���̓��t������������܂���B";
                errComponent = startDateEdit;
                status = false;
                return status;
            }

            if (IsErrorTDateEdit(endDateEdit, true))
            {
                msg += "�I�����̓��t������������܂���B";
                errComponent = endDateEdit;
                status = false;
                return status;
            }

            if ((startDateEdit.GetDateTime() != DateTime.MinValue) && (endDateEdit.GetDateTime() != DateTime.MinValue))
            {
                if (startDateEdit.GetLongDate() > endDateEdit.GetLongDate())
                {
                    msg += "�J�n�����I�����𒴂��Ă��܂��B";
                    errComponent = startDateEdit;
                    status = false;
                    return status;
                }
            }
            return status;
        }
        
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="canEmpty">�����̓t���O(true:�����͉�,false:�����͕s��)</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool canEmpty)
        {
            if (tDateEdit.CheckInputData() != null) return true;

            // ���t�𐔒l�^�Ŏ擾
            int date = tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // �����̓t���O�`�F�b�N
            if (canEmpty)
            {
                // �����͉Ŗ����͂̏ꍇ�͐���
                if (date == 0) return false;
            }

            // ���t�����̓`�F�b�N
            if (date == 0) return true;

            // �V�X�e���T�|�[�g�`�F�b�N
            if ((yy > 0) && (yy < 1900)) return true;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (tDateEdit.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    {
                        if (yy == 0 || mm == 0 || dd == 0) return true;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    {
                        if (yy == 0 || mm == 0) return true;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    {
                        if (yy == 0) return false;
                        // �P�����t�Ó����`�F�b�N
                        DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
                        break;
                    }
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    {
                        if (mm == 0 || dd == 0) return true;
                        break;
                    }
                // ��        �\����
                case emDateFormat.df2M:
                    {
                        if (mm == 0) return true;
                        break;
                    }
                // ��        �\����
                case emDateFormat.df2D:
                    {
                        if (dd == 0) return true;
                        break;
                    }
            }

            return false;
        }

        #endregion

        #region ControlEvent

        #region Form Load �C�x���g
        /// <summary>
        /// Form.Load �C�x���g (MAZAI02070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������߂ĕ\������钼�O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void SFDML06360UA_Load(object sender, EventArgs e)
        {
            //�A�C�R��(��) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
                   
            //���i�K�C�h
            this.St_GoodsGuide_Button.ImageList = imageList16;
            this.Ed_GoodsGuide_Button.ImageList = imageList16;
            this.St_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //���i�敪�O���[�v�K�C�h
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_LargeGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_LargeGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_LargeGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_LargeGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //���i�敪�K�C�h
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //���[�J�[�K�C�h
            this.St_MakerGuide_Button.ImageList = imageList16;
            this.Ed_MakerGuide_Button.ImageList = imageList16;
            this.St_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�K�C�h
            //this.St_CarrierGuide_Button.ImageList = imageList16;
            //this.Ed_CarrierGuide_Button.ImageList = imageList16;
            //this.St_CarrierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_CarrierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //���i�敪�ڍ׃K�C�h
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //���Е��ރK�C�h
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.Ed_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.St_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //�a�k���i�R�[�h�K�C�h
            this.St_BLGoodsGuide_Button.ImageList = imageList16;
            this.Ed_BLGoodsGuide_Button.ImageList = imageList16;
            this.St_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //�q�ɃK�C�h
            this.St_WarehouseGuide_Button.ImageList = imageList16;
            this.Ed_WarehouseGuide_Button.ImageList = imageList16;
            this.St_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            this.ub_St_CustomerCodeGuide.ImageList = imageList16;
            this.ub_Ed_CustomerCodeGuide.ImageList = imageList16;
            this.ub_St_CustomerCodeGuide.Appearance.Image = Size16_Index.STAR1;
            this.ub_Ed_CustomerCodeGuide.Appearance.Image = Size16_Index.STAR1;
            //--- ADD 2008/08/01 ----------<<<<<

            // --- ADD 2008/10/07 --------------->>>>>
            // ��\��(��ʃ��[�h���Ɉ�u������ׁA�R���g���[�����̂�False�ɂ��Ă���)
            this.St_GoodsGuide_Button.Visible = false;      // �i��From
            this.Ed_GoodsGuide_Button.Visible = false;      // �i��To
            // --- ADD 2008/10/07 ---------------<<<<<

            this.SetDuplicationShelfNo(clb_DuplicationShelfNo1, 72);        //ADD 2009/06/25 �s��Ή�[13586]
            this.SetDuplicationShelfNo(clb_DuplicationShelfNo2, 73);        //ADD 2009/06/25 �s��Ή�[13586]

            //��ʏ����ݒ�
            this.ScreenInitialSetting();

            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            if (this.ParentToolbarSettingEvent != null)
            {
                this.ParentToolbarSettingEvent(this);
            }

            // ADD 2009/03/31 �s��Ή�[12894]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
            PublicationTypeRadioKeyPressHelper.ControlList.Add(this.uos_PublicationType);
            PublicationTypeRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();

            ChangePageDivRadioKeyPressHelper.ControlList.Add(this.uos_ChangePageDiv);
            ChangePageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 �s��Ή�[12894]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<
        }
        #endregion

        #region Form VisibleChanged �C�x���g
        /// <summary>
        /// Form.VisibleChanged �C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2006.07.31</br>
        /// </remarks>    
        private void Main_UltraExplorerBar_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                // �����t�H�[�J�X�ݒ�
                //this.StartMakerCode_tNedit.Focus();       // DEL 2008.08.01
                this.tde_St_AddUpYearMonth.Focus();         // ADD 2008.08.01
            }
        }
        #endregion

        #region UltraExplorerBar �C�x���g
        /// <summary>
        /// UltraExplorerBar.GroupExpanding �C�x���g (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroup���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortGroap") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// UltraExplorerBar.GroupCollapsing �C�x���g (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroup���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortGroap") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region Control Leave �C�x���g
        /// <summary>
        /// Control.Leave �C�x���g (ShipmentPosCnt_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        /// <br>Programmer : 23010 ���� �m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void StartShipmentPosCnt_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // �󗓂�0�̎������l���Z�b�g
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                if (tNedit.Equals(this.StartShipmentPosCnt_tNedit))
                {
                    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(0);
                    tNedit.DataText = "";
                    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                }
                else if (tNedit.Equals(this.EndShipmentPosCnt_tNedit))
                {
                    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(99999999);
                    tNedit.DataText = "";
                    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                }
            }
        }

        /// <summary>
        /// Control.Leave �C�x���g (StartMakerCode_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        /// <br>Programmer : 23010 ���� �m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void StartMakerCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // �󗓂�0�̎������l���Z�b�g
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                if (tNedit.Equals(this.tNedit_GoodsMakerCd_St))
                {
                    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(0);
                    tNedit.DataText = "";
                    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                }
                else if (tNedit.Equals(this.tNedit_GoodsMakerCd_Ed))
                {
                    // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(999);
                    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(999999);
                    tNedit.DataText = "";
                    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                    // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                }
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //else if (tNedit.Equals(this.StartCarrierCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndCarrierCode_tNedit))
                //{
                //    tNedit.SetInt(999);
                //}
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //--- DEL 2008/08/01 ---------->>>>>
                //else if (tNedit.Equals(this.StartEnterpriseGanreCode_tNedit))
                //{
                //    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                //    //tNedit.SetInt(0);
                //    tNedit.DataText = "";
                //    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                //}
                //else if (tNedit.Equals(this.EndEnterpriseGanreCode_tNedit))
                //{
                //    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                //    //tNedit.SetInt(99);
                //    tNedit.DataText = "";
                //    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                else if (tNedit.Equals(this.tNedit_BLGoodsCode_St))
                {
                    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(0);
                    tNedit.DataText = "";
                    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                }
                else if (tNedit.Equals(this.tNedit_BLGoodsCode_Ed))
                {
                    // 2008.01.21 �C�� >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(99999999);
                    tNedit.DataText = "";
                    // 2008.01.21 �C�� <<<<<<<<<<<<<<<<<<<<
                }
                // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }           
        }
            
        #endregion

        #region �K�C�h�ďo������

        #region ���[�J�[�K�C�h
        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //Maker maker = null;
            MakerUMnt makerUMnt = null;
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();               
            }
            //���[�J�[�K�C�h�N��
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

            switch(status)
            {
                //�擾
                case 0:
                {
                    // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //if (maker != null)
                    if (makerUMnt != null)
                    // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    {
                        //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                        if((Infragistics.Win.Misc.UltraButton)sender == this.St_MakerGuide_Button)
                        {
                            //�J�n
                            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                            //this.StartMakerCode_tNedit.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                            //--- ADD 2008.08.01 ---------->>>>>
                            // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                            this.tNedit_GoodsMakerCd_Ed.Focus();
                            //--- ADD 2008.08.01 ----------<<<<<
                        }
                        else
                        {
                            //�I��
                            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                            //this.EndMakerCode_tNedit.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                            //--- ADD 2008.08.01 ---------->>>>>
                            // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                            this.tNedit_BLGoodsCode_St.Focus();
                            //--- ADD 2008.08.01 ----------<<<<<
                        }                                    
                    }           
                    break;
                }
                //�L�����Z��
                case 1:
                {
                    
                    break;
                }
            }

        }

        #endregion

        //--- DEL 2008/08/01 ---------->>>>>
        #region ���i�敪�O���[�v�K�C�h
        ///// <summary>
        ///// ���i�敪�O���[�v�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�敪�O���[�v�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.03.22</br>
        ///// </remarks>    
        //private void LargeGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    LGoodsGanre lGoodsGanre = null;
        //    if(this._lGoodsGanreAcs == null)
        //    {
        //        this._lGoodsGanreAcs = new LGoodsGanreAcs();               
        //    }
        //    //���i�敪�O���[�v�K�C�h
        //    int status = this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,out lGoodsGanre);

        //    switch(status)
        //    {
        //        //�擾
        //        case 0:
        //        {                  
        //            if(lGoodsGanre != null)
        //            {
        //                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_LargeGoodsGanreGuide_Button)
        //                {
        //                    //�J�n
        //                    this.StartLargeGoodsGanreCode_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();                           
        //                }
        //                else
        //                {
        //                    //�I��
        //                    this.EndLargeGoodsGanreCode_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();                       
        //                }           
                                  
        //            }
        //            break;
        //        }
        //        //�L�����Z��
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }
        //}
        #endregion
        //--- DEL 2008/08/01 ----------<<<<<

        //--- DEL 2008/08/01 ---------->>>>>
        #region ���i�敪�K�C�h
        ///// <summary>
        ///// ���i�敪�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�敪�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.03.22</br>
        ///// </remarks>    
        //private void MidiumGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    MGoodsGanre mGoodsGanre = null;
        //    if(this._mGoodsGanreAcs == null)
        //    {
        //        this._mGoodsGanreAcs = new MGoodsGanreAcs();               
        //    }

        //    //TODO:�����Ƃ��ď��i�敪�O���[�v���c���Ă���B�Ƃ肠�����󕶎����Œ�ŃZ�b�g���Ă���
        //    //���i�敪�K�C�h�N��
        //    // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //    //int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre);
        //    int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 1);
        //    // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

        //    switch(status)
        //    {
        //        //�擾
        //        case 0:
        //        {                  
        //            if(mGoodsGanre != null)
        //            {
        //                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_MidiumGoodsGanreGuide_Button)
        //                {
        //                    //�J�n
        //                    this.StartMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //�I��
        //                    this.EndMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }           
                                  
        //            }
        //            break;
        //        }
        //        //�L�����Z��
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }
        //}
        #endregion
        //--- DEL 2008/08/01 ----------<<<<<

        #region ���i�K�C�h
        /// <summary>
        /// ���i�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 23001 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        private void GoodsGuide_Button_Click(object sender, EventArgs e)
        {     
            GoodsUnitData goodsUnitData = null;
            MAKHN04110UA goodsGuide = new MAKHN04110UA();

            DialogResult ret = goodsGuide.ShowGuide(this,this._enterpriseCode,out goodsUnitData);

            if(ret == DialogResult.OK)
            {
                if(goodsUnitData != null)
                {
                    //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                    if((Infragistics.Win.Misc.UltraButton)sender == this.St_GoodsGuide_Button)
                    {
                        //�J�n
                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //this.StartGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
                        this.tEdit_GoodsNo_St.DataText = goodsUnitData.GoodsNo.TrimEnd();
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //--- ADD 2008.08.01 ---------->>>>>
                        // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                        this.tEdit_GoodsNo_Ed.Focus();
                        //--- ADD 2008.08.01 ----------<<<<<
                    }
                    else
                    {
                        //�I��
                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //this.EndGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
                        this.tEdit_GoodsNo_Ed.DataText = goodsUnitData.GoodsNo.TrimEnd();
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                    }           
                              
                }
            }
            else
            {
                //�L�����Z���Ȃ̂łȂɂ����Ȃ�
            }
        }

        #endregion

        //--- DEL 2008/08/01 ---------->>>>>
        // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
        #region ���i�敪�ڍ׃K�C�h
        ///// <summary>
        ///// ���i�敪�ڍ׃K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���i�敪�ڍ׃K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 980035 ����@��`</br>
        ///// <br>Date       : 2007.10.05</br>
        ///// </remarks>    
        //private void DetailGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    DGoodsGanre dGoodsGanre = null;
        //    if (this._dGoodsGanreAcs == null)
        //    {
        //        this._dGoodsGanreAcs = new DGoodsGanreAcs();
        //    }

        //    //TODO:�����Ƃ��ď��i�敪�O���[�v���c���Ă���B�Ƃ肠�����󕶎����Œ�ŃZ�b�g���Ă���
        //    //���i�敪�ڍ׃K�C�h�N��
        //    int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre);

        //    switch (status)
        //    {
        //        //�擾
        //        case 0:
        //            {
        //                if (dGoodsGanre != null)
        //                {
        //                    //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_DetailGoodsGanreGuide_Button)
        //                    {
        //                        //�J�n
        //                        this.StartDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }
        //                    else
        //                    {
        //                        //�I��
        //                        this.EndDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }

        //                }
        //                break;
        //            }
        //        //�L�����Z��
        //        case 1:
        //            {
        //                break;
        //            }
        //    }
        //}
        #endregion
        //--- DEL 2008/08/01 ----------<<<<<

        #region �a�k���i�K�C�h
        /// <summary>
        /// �a�k���i�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �a�k���i�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>    
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            // �a�k���i�K�C�h�N��
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            switch (status)
            {
                // �擾
                case 0:
                    {
                        if (blGoodsCdUMnt != null)
                        {
                            // �J�n�A�I���ǂ���̃{�^���������ꂽ���H
                            if ((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGoodsGuide_Button)
                            {
                                // �J�n
                                this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                //--- ADD 2008.08.01 ---------->>>>>
                                // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                                this.tNedit_BLGoodsCode_Ed.Focus();
                                //--- ADD 2008.08.01 ----------<<<<<
                            }
                            else
                            {
                                // �I��
                                this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                //--- ADD 2008.08.01 ---------->>>>>
                                // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                                this.tEdit_GoodsNo_St.Focus();
                                //--- ADD 2008.08.01 ----------<<<<<
                            }

                        }
                        break;
                    }
                // �L�����Z��
                case 1:
                    {
                        break;
                    }
            }
        }

        #endregion

        #region �q�ɃK�C�h
        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // �q�ɃK�C�h�N��
            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._loginSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    // �J�n�A�I���ǂ���̃{�^���������ꂽ���H
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_WarehouseGuide_Button)
                    {
                        // �J�n
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                        //--- ADD 2008.08.01 ---------->>>>>
                        // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                        this.tEdit_WarehouseCode_Ed.Focus();
                        //--- ADD 2008.08.01 ----------<<<<<
                    }
                    else
                    {
                        // �I��
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                        //--- ADD 2008.08.01 ---------->>>>>
                        // ���̃R���g���[���Ƀt�H�[�J�X�ړ�
                        this.tNedit_SupplierCd_St.Focus();
                        //--- ADD 2008.08.01 ----------<<<<<
                    }
                }
            }
            else
            {
                // �L�����Z���Ȃ̂łȂɂ����Ȃ�
            }

        }
        #endregion

        //--- ADD 2008/08/01 ---------->>>>>
        #region �d����K�C�h
        /// <summary>
        /// �d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_CustomerCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            Supplier supplier = new Supplier();

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status != 0) return;

            TEdit targetControl;
            Control nextControl = null;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SupplierCd_St;
                nextControl = this.tNedit_SupplierCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SupplierCd_Ed;
                nextControl = this.tEdit_WarehouseShelfNo_St;
            }
            else
            {
                return;
            }

            targetControl.DataText = supplier.SupplierCd.ToString();

            // �t�H�[�J�X�ړ�
            nextControl.Focus();

        }
        #endregion

        private void uos_ChangePageDiv_ValueChanged(object sender, EventArgs e)
        {
            // �I�ԏ����I������Ă��鎞�̂݁A�I�ԃu���C�N�敪����͉Ƃ���B
            if ((int)(sender as UltraOptionSet).Value == (int)StockListCndtn.PrintSortDivState.ByWarehouseShelfNo)
            {
                this.ce_WarehouseShelfNoBreakDiv.Enabled = true;
            }
            else
            {
                this.ce_WarehouseShelfNoBreakDiv.Enabled = false;
                this.ce_WarehouseShelfNoBreakDiv.Value = (int)StockListCndtn.WarehouseShelfNoBreakDivState.Length1;
            }
        }
        //--- ADD 2008/08/01 ----------<<<<<

        //--- DEL 2008/08/01 ---------->>>>>
        #region ���Е��ރK�C�h�i���[�U�[�K�C�h�j
        ///// <summary>
        ///// ���Е��ރK�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���Е��ރK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 980035 ����@��`</br>
        ///// <br>Date       : 2007.10.05</br>
        ///// </remarks>    
        //private void EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    UserGdBd userGdBd = null;
        //    if (this._userGuideGuide == null)
        //    {
        //        this._userGuideGuide = new UserGuideGuide();
        //    }

        //    //���[�U�[�K�C�h�N��
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(41, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        if (userGdBd != null)
        //        {
        //            //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //            if ((Infragistics.Win.Misc.UltraButton)sender == this.St_EnterpriseGanreGuide_Button)
        //            {
        //                //�J�n
        //                this.StartEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //            else
        //            {
        //                //�I��
        //                this.EndEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //        }
        //    }
        //}
        #endregion
        // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ----------<<<<<

        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        #region �L�����A�K�C�h
        ///// <summary>
        ///// �L�����A�K�C�h�{�^���N���b�N�C�x���g 
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �L�����A�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        ///// <br>Programmer : 23001 �����@�m</br>
        ///// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        //private void St_CarrierGuide_Button_Click(object sender, EventArgs e)
        //{
        //    Carrier carrier = null;        
        //    if(this._carrierOdrAcs == null)
        //    {
        //        this._carrierOdrAcs = new CarrierOdrAcs();               
        //    }
        //
        //    //�L�����A�K�C�h�N��
        //    int status = this._carrierOdrAcs.ExecuteGuid(this._enterpriseCode,this._loginSectionCode,out carrier);
        //  
        //    switch(status)
        //    {
        //        //�擾
        //        case 0:
        //        {                  
        //            if(carrier != null)
        //            {
        //                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_CarrierGuide_Button)
        //                {
        //                    //�J�n
        //                     this.StartCarrierCode_tNedit.SetInt(carrier.CarrierCode);
        //                }
        //                else
        //                {
        //                    //�I��
        //                    this.EndCarrierCode_tNedit.SetInt(carrier.CarrierCode);
        //                }                                    
        //            }           
        //            break;
        //        }
        //        //�L�����Z��
        //        case 1:
        //        {
        //            
        //            break;
        //        }
        //    }
        //}

        #endregion
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<

        #endregion

        #region �I��KeyPress�C�x���g
        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

        #endregion

        // --- ADD 2008/10/07 -------------------------------------->>>>>
        /// <summary>
        /// �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XEnter���A�I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_Enter(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                // �I�����
                ((ListBox)sender).SetSelected(0, true);
            }
        }

        /// <summary>
        /// �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XLeave���A�I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_Leave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // �I����ԉ���
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        // --- ADD 2008/10/07 --------------------------------------<<<<<
    }
}
