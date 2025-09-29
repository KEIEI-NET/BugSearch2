//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �I�[�g�o�b�N�X�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/07/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �C �� ��  2012/12/07  �C�����e : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��Y
// �C �� ��  2014/05/16  �C�����e : �r���d�u���[�L�`�a���i�R�[�h�̏����l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����`
// �C �� ��  2018/07/20  �C�����e : �r���d�u���[�L��Ɩ��̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O
// �C �� ��  2025/03/04  �C�����e : PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Infragistics.Win.Misc;
using Broadleaf.Application.Resources; // ADD 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �I�[�g�o�b�N�X�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �I�[�g�o�b�N�X�ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: ������</br>
    /// <br>Date		: 2009.07.30</br>
    /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
    /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
    /// <br>UpdateNote  : 2014/05/16 ���� ��Y</br>
    /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̏����l�ύX</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSAE09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �I�[�g�o�b�N�X�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public PMSAE09010UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �C���^�[�t�F�[�X������
            this._makerAcs = new MakerAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._sAndESettingAcs = new SAndESettingAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            // �ϐ�������
            this._dataIndex = -1;
            this._totalCount = 0;
            this._sAndESettingTable = new Hashtable();
            this.flg = true;
            this._preControl = null;
            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;
        }

        #endregion

        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        /*----------------------------------------------------------------------------------*/
        private SAndESettingAcs _sAndESettingAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _sAndESettingTable;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �ۑ���r�pClone
        private SAndESetting _sAndESettingClone;
        // �߂��r�pClone
        private SAndESetting _sAndESettingInit;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private const int MAKER_COUNT = 15;

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_SECTION_CODE_TITLE = "���_����";
        private const string VIEW_SECTION_NAME_TITLE = "���_����";
        private const string VIEW_CUSTOMER_CODE_TITLE = "���Ӑ溰��";
        private const string VIEW_CUSTOMER_NAME_TITLE = "���Ӑ旪��";
        private const string VIEW_ADDRESSEESHOP_CODE_TITLE = "�[�i��X�ܺ���";
        private const string VIEW_SANDEMNG_CODE_TITLE = "S&E�Ǘ�����";
        private const string VIEW_EXPENSEDIV_CODE_TITLE = "�o��敪";
        private const string VIEW_DIRECTSENDING_CODE_TITLE = "�����敪";
        private const string VIEW_ACPTANORDERDIV_TITLE = "�󒍋敪";
        private const string VIEW_DELIVERER_CODE_TITLE = "�[���Һ���";
        private const string VIEW_DELIVERER_NAME_TITLE = "�[���Җ�";
        private const string VIEW_DELIVERERADDRESS_TITLE = "�[���ҏZ��";
        private const string VIEW_DELIVERERPHONENUM_TITLE = "�[����TEL";
        private const string VIEW_TRADCOMP_NAME_TITLE = "���i����";
        private const string VIEW_TRADCOMPSECT_NAME_TITLE = "���i�����_��";
        private const string VIEW_PURETRADCOMP_CODE_TITLE = "���i�����ށi�����j";
        private const string VIEW_PURETRADCOMPRATE_TITLE = "���i���d�ؗ��i�����j";
        private const string VIEW_PRITRADCOMP_CODE_TITLE = "���i�����ށi�D�ǁj";
        private const string VIEW_PRITRADCOMPRATE_TITLE = "���i���d�ؗ��i�D�ǁj";
        private const string VIEW_ABGOODS_CODE_TITLE = "���i����";
        private const string VIEW_COMMENTRESERVEDDIV_TITLE = "7�s�ڃR�����g�w��";
        private const string VIEW_GOODSMAKER_CODE1_TITLE = "�����Ή����[�J�[�P";
        private const string VIEW_GOODSMAKER_CODE2_TITLE = "�����Ή����[�J�[�Q";
        private const string VIEW_GOODSMAKER_CODE3_TITLE = "�����Ή����[�J�[�R";
        private const string VIEW_GOODSMAKER_CODE4_TITLE = "�����Ή����[�J�[�S";
        private const string VIEW_GOODSMAKER_CODE5_TITLE = "�����Ή����[�J�[�T";
        private const string VIEW_GOODSMAKER_CODE6_TITLE = "�����Ή����[�J�[�U";
        private const string VIEW_GOODSMAKER_CODE7_TITLE = "�����Ή����[�J�[�V";
        private const string VIEW_GOODSMAKER_CODE8_TITLE = "�����Ή����[�J�[�W";
        private const string VIEW_GOODSMAKER_CODE9_TITLE = "�����Ή����[�J�[�X";
        private const string VIEW_GOODSMAKER_CODE10_TITLE = "�����Ή����[�J�[�P�O";
        private const string VIEW_GOODSMAKER_CODE11_TITLE = "�����Ή����[�J�[�P�P";
        private const string VIEW_GOODSMAKER_CODE12_TITLE = "�����Ή����[�J�[�P�Q";
        private const string VIEW_GOODSMAKER_CODE13_TITLE = "�����Ή����[�J�[�P�R";
        private const string VIEW_GOODSMAKER_CODE14_TITLE = "�����Ή����[�J�[�P�S";
        private const string VIEW_GOODSMAKER_CODE15_TITLE = "�����Ή����[�J�[�P�T";
        private const string VIEW_PARTSOEMDIV_TITLE = "OEM�敪";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // �G���[���b�Z�[�W
        private string ct_DupliInput = "���d�����Ă��܂��B";
        private string ct_SetError = "�͐ݒ�ł��܂���B";
        private string ct_NoInput = "��ݒ肵�ĉ������B";

        //�ݒ�XML�t�@�C����
        private const string XML_FILE_NAME = "SANDESETTING.XML"; // ADD 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private string _tmpSectionCode;
        private string _tmpSectionName;
        private int _tmpCustomerCode;
        private string _tmpCustomerName;
        private int _prevMakerCode1;
        private int _prevMakerCode2;
        private int _prevMakerCode3;
        private int _prevMakerCode4;
        private int _prevMakerCode5;
        private int _prevMakerCode6;
        private int _prevMakerCode7;
        private int _prevMakerCode8;
        private int _prevMakerCode9;
        private int _prevMakerCode10;
        private int _prevMakerCode11;
        private int _prevMakerCode12;
        private int _prevMakerCode13;
        private int _prevMakerCode14;
        private int _prevMakerCode15;

        // ���[�J�[���
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        // ���_���
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        // ���Ӑ���
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        // �C���^�[�t�F�[�X
        private MakerAcs _makerAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private SecInfoAcs _secInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;

        // �ۑ��O�Ƀ}�X�^�`�F�b�N
        private bool flg;
        private Control _preControl;

        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        # endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            int status = 0;
            ArrayList sAndESettings = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._sAndESettingTable.Clear();

            // �S����
            status = this._sAndESettingAcs.SearchAll(out sAndESettings, this._enterpriseCode);
            this._totalCount = sAndESettings.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SAndESetting sAndESetting in sAndESettings)
                        {
                            // �I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
                            SAndESettingToDataSet(sAndESetting.Clone(), index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            "PMSAE09010U",							// �A�Z���u��ID
                            "�I�[�g�o�b�N�X�ݒ�",              �@�@   // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._sAndESettingAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B(������)</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public int Delete()
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʍ폜�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SAndESetting sAndESetting = (SAndESetting)this._sAndESettingTable[guid];

            int status;

            // ��ƃR�[�h�ݒ���_���폜����
            status = this._sAndESettingAcs.LogicalDelete(ref sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMSAE09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._sAndESettingAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // ��ƃR�[�h�ݒ���N���X�f�[�^�Z�b�g�W�J����
            SAndESettingToDataSet(sAndESetting.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {

            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_�R�[�h
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ӑ�R�[�h
            appearanceTable.Add(VIEW_CUSTOMER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Ӑ旪��
            appearanceTable.Add(VIEW_CUSTOMER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[�i��X�܃R�[�h
            appearanceTable.Add(VIEW_ADDRESSEESHOP_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // S&E�Ǘ��R�[�h
            appearanceTable.Add(VIEW_SANDEMNG_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �o��敪
            appearanceTable.Add(VIEW_EXPENSEDIV_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����敪
            appearanceTable.Add(VIEW_DIRECTSENDING_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �󒍋敪
            appearanceTable.Add(VIEW_ACPTANORDERDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �[�i�҃R�[�h
            appearanceTable.Add(VIEW_DELIVERER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[�i�Җ�
            appearanceTable.Add(VIEW_DELIVERER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[�i�ҏZ��
            appearanceTable.Add(VIEW_DELIVERERADDRESS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[�i��TEL
            appearanceTable.Add(VIEW_DELIVERERPHONENUM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���i����
            appearanceTable.Add(VIEW_TRADCOMP_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���i�����_��
            appearanceTable.Add(VIEW_TRADCOMPSECT_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���i���R�[�h�i�����j
            appearanceTable.Add(VIEW_PURETRADCOMP_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���i���d�ؗ��i�����j
            appearanceTable.Add(VIEW_PURETRADCOMPRATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���i���R�[�h�i�D�ǁj
            appearanceTable.Add(VIEW_PRITRADCOMP_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���i���d�ؗ��i�D�ǁj
            appearanceTable.Add(VIEW_PRITRADCOMPRATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���i�R�[�h
            appearanceTable.Add(VIEW_ABGOODS_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // OEM�敪
            appearanceTable.Add(VIEW_PARTSOEMDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 7�s�ڃR�����g�w��
            appearanceTable.Add(VIEW_COMMENTRESERVEDDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �����Ή����[�J�P�`�P�T
            appearanceTable.Add(VIEW_GOODSMAKER_CODE1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE7_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE8_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE9_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE10_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE11_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE12_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE13_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE14_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE15_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --

        /// <summary>
        /// ������ComboEditor
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ComboEditor���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.30</br>
        /// </remarks>
        private void InitComboEditor()
        {
            tComboEditor_PartsOEMDiv.Items.Clear();
            tComboEditor_PartsOEMDiv.Items.Add(0, "������Ȃ�");
            tComboEditor_PartsOEMDiv.Items.Add(1, "�������");

            tComboEditor_CommentReservedDiv.Items.Clear();
            tComboEditor_CommentReservedDiv.Items.Add(0, "����");
            tComboEditor_CommentReservedDiv.Items.Add(1, "���l");
            tComboEditor_CommentReservedDiv.Items.Add(2, "�ޕʌ^���{�^���Ԏ햼");
            tComboEditor_CommentReservedDiv.Items.Add(3, "�ޕʁ{�Ԏ햼�{���l");
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SAndESetting sAndESetting = new SAndESetting();


                //�N���[���쐬
                this._sAndESettingClone = sAndESetting.Clone();

                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSAndESetting(ref this._sAndESettingClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SAndESetting sAndESetting = (SAndESetting)this._sAndESettingTable[guid];

                if (sAndESetting.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_AddresseeShopCd.Focus();

                    // �I�[�g�o�b�N�X�ݒ�}�X�^���N���X��ʓW�J����
                    SAndESettingToScreen(sAndESetting);

                    // �N���[���쐬
                    this._sAndESettingClone = sAndESetting.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                    ScreenToSAndESetting(ref this._sAndESettingClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();

                    // �I�[�g�o�b�N�X�ݒ�}�X�^���N���X��ʓW�J����
                    SAndESettingToScreen(sAndESetting);

                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Renewal_Button.Visible = true;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    if (mode == INSERT_MODE)
                    {
                        // �V�K���[�h
                        this.tEdit_SectionCode.Enabled = true;
                        this.uButton_SectionGuide.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tEdit_AddresseeShopCd.Enabled = true;
                        this.tEdit_SAndEMngCode.Enabled = true;
                        this.tNedit_ExpenseDivCd.Enabled = true;
                        this.tNedit_DirectSendingCd.Enabled = true;
                        this.tNedit_AcptAnOrderDiv.Enabled = true;
                        this.tEdit_DelivererCd.Enabled = true;
                        this.tEdit_DelivererNm.Enabled = true;
                        this.tEdit_DelivererPhoneNum.Enabled = true;
                        this.tEdit_DelivererAddress.Enabled = true;
                        this.tEdit_TradCompName.Enabled = true;
                        this.tEdit_TradCompSectName.Enabled = true;
                        this.tEdit_PureTradCompCd.Enabled = true;
                        this.tNedit_PureTradCompRate.Enabled = true;
                        this.tEdit_PriTradCompCd.Enabled = true;
                        this.tNedit_PriTradCompRate.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                        this.tComboEditor_CommentReservedDiv.Enabled = true;
                        this.tComboEditor_PartsOEMDiv.Enabled = true;
                        this.tNedit_GoodsMakerCd1.Enabled = true;
                        this.tNedit_GoodsMakerCd2.Enabled = true;
                        this.tNedit_GoodsMakerCd3.Enabled = true;
                        this.tNedit_GoodsMakerCd4.Enabled = true;
                        this.tNedit_GoodsMakerCd5.Enabled = true;
                        this.tNedit_GoodsMakerCd6.Enabled = true;
                        this.tNedit_GoodsMakerCd7.Enabled = true;
                        this.tNedit_GoodsMakerCd8.Enabled = true;
                        this.tNedit_GoodsMakerCd9.Enabled = true;
                        this.tNedit_GoodsMakerCd10.Enabled = true;
                        this.tNedit_GoodsMakerCd11.Enabled = true;
                        this.tNedit_GoodsMakerCd12.Enabled = true;
                        this.tNedit_GoodsMakerCd13.Enabled = true;
                        this.tNedit_GoodsMakerCd14.Enabled = true;
                        this.tNedit_GoodsMakerCd15.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;

                        // ��ʏ�����
                        ScreenClear();
                    }
                    else
                    {
                        // �X�V���[�h
                        this.tEdit_SectionCode.Enabled = false;
                        this.uButton_SectionGuide.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tEdit_AddresseeShopCd.Enabled = true;
                        this.tEdit_SAndEMngCode.Enabled = true;
                        this.tNedit_ExpenseDivCd.Enabled = true;
                        this.tNedit_DirectSendingCd.Enabled = true;
                        this.tNedit_AcptAnOrderDiv.Enabled = true;
                        this.tEdit_DelivererCd.Enabled = true;
                        this.tEdit_DelivererNm.Enabled = true;
                        this.tEdit_DelivererPhoneNum.Enabled = true;
                        this.tEdit_DelivererAddress.Enabled = true;
                        this.tEdit_TradCompName.Enabled = true;
                        this.tEdit_TradCompSectName.Enabled = true;
                        this.tEdit_PureTradCompCd.Enabled = true;
                        this.tNedit_PureTradCompRate.Enabled = true;
                        this.tEdit_PriTradCompCd.Enabled = true;
                        this.tNedit_PriTradCompRate.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                        this.tComboEditor_CommentReservedDiv.Enabled = true;
                        this.tComboEditor_PartsOEMDiv.Enabled = true;
                        this.tNedit_GoodsMakerCd1.Enabled = true;
                        this.tNedit_GoodsMakerCd2.Enabled = true;
                        this.tNedit_GoodsMakerCd3.Enabled = true;
                        this.tNedit_GoodsMakerCd4.Enabled = true;
                        this.tNedit_GoodsMakerCd5.Enabled = true;
                        this.tNedit_GoodsMakerCd6.Enabled = true;
                        this.tNedit_GoodsMakerCd7.Enabled = true;
                        this.tNedit_GoodsMakerCd8.Enabled = true;
                        this.tNedit_GoodsMakerCd9.Enabled = true;
                        this.tNedit_GoodsMakerCd10.Enabled = true;
                        this.tNedit_GoodsMakerCd11.Enabled = true;
                        this.tNedit_GoodsMakerCd12.Enabled = true;
                        this.tNedit_GoodsMakerCd13.Enabled = true;
                        this.tNedit_GoodsMakerCd14.Enabled = true;
                        this.tNedit_GoodsMakerCd15.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;

                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tEdit_SectionCode.Enabled = false;
                    this.uButton_SectionGuide.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.tEdit_AddresseeShopCd.Enabled = false;
                    this.tEdit_SAndEMngCode.Enabled = false;
                    this.tNedit_ExpenseDivCd.Enabled = false;
                    this.tNedit_DirectSendingCd.Enabled = false;
                    this.tNedit_AcptAnOrderDiv.Enabled = false;
                    this.tEdit_DelivererCd.Enabled = false;
                    this.tEdit_DelivererNm.Enabled = false;
                    this.tEdit_DelivererPhoneNum.Enabled = false;
                    this.tEdit_DelivererAddress.Enabled = false;
                    this.tEdit_TradCompName.Enabled = false;
                    this.tEdit_TradCompSectName.Enabled = false;
                    this.tEdit_PureTradCompCd.Enabled = false;
                    this.tNedit_PureTradCompRate.Enabled = false;
                    this.tEdit_PriTradCompCd.Enabled = false;
                    this.tNedit_PriTradCompRate.Enabled = false;
                    this.tEdit_ABGoodsCode.Enabled = false;
                    this.tComboEditor_CommentReservedDiv.Enabled = false;
                    this.tComboEditor_PartsOEMDiv.Enabled = false;
                    this.tNedit_GoodsMakerCd1.Enabled = false;
                    this.tNedit_GoodsMakerCd2.Enabled = false;
                    this.tNedit_GoodsMakerCd3.Enabled = false;
                    this.tNedit_GoodsMakerCd4.Enabled = false;
                    this.tNedit_GoodsMakerCd5.Enabled = false;
                    this.tNedit_GoodsMakerCd6.Enabled = false;
                    this.tNedit_GoodsMakerCd7.Enabled = false;
                    this.tNedit_GoodsMakerCd8.Enabled = false;
                    this.tNedit_GoodsMakerCd9.Enabled = false;
                    this.tNedit_GoodsMakerCd10.Enabled = false;
                    this.tNedit_GoodsMakerCd11.Enabled = false;
                    this.tNedit_GoodsMakerCd12.Enabled = false;
                    this.tNedit_GoodsMakerCd13.Enabled = false;
                    this.tNedit_GoodsMakerCd14.Enabled = false;
                    this.tNedit_GoodsMakerCd15.Enabled = false;
                    this.uButton_GoodsMakerGuid.Enabled = false;
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ��I�[�g�o�b�N�X�ݒ�N���X�i�[����
        /// </summary>
        /// <param name="sAndESetting">�I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.07.30</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// </remarks>
        private void ScreenToSAndESetting(ref SAndESetting sAndESetting)
        {
            if (sAndESetting == null)
            {
                // �V�K�̏ꍇ
                sAndESetting = new SAndESetting();
            }

            //��ƃR�[�h
            sAndESetting.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            sAndESetting.SectionCode = this.tEdit_SectionCode.DataText.PadLeft(2,'0');
            // ���_����
            sAndESetting.SectionName = this.tEdit_SectionName.DataText;
            // ���Ӑ�R�[�h
            sAndESetting.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // ���Ӑ旪��
            sAndESetting.CustomerName = this.tEdit_CustomerName.DataText;
            // �[�i��X�܃R�[�h
            sAndESetting.AddresseeShopCd = this.tEdit_AddresseeShopCd.DataText.PadLeft(6,'0');
            // S&E�Ǘ��R�[�h
            sAndESetting.SAndEMngCode = this.tEdit_SAndEMngCode.DataText.PadLeft(6, '0');
            // �o��敪
            sAndESetting.ExpenseDivCd = this.tNedit_ExpenseDivCd.GetInt();
            // �����敪
            sAndESetting.DirectSendingCd = this.tNedit_DirectSendingCd.GetInt();
            // �󒍋敪
            sAndESetting.AcptAnOrderDiv = this.tNedit_AcptAnOrderDiv.GetInt();
            // �[�i�҃R�[�h
            sAndESetting.DelivererCd = this.tEdit_DelivererCd.DataText.PadLeft(6, '0');
            // �[�i�Җ�
            sAndESetting.DelivererNm = this.tEdit_DelivererNm.DataText;
            // �[�i�ҏZ��
            sAndESetting.DelivererAddress = this.tEdit_DelivererAddress.DataText;
            // �[�i��TEL
            sAndESetting.DelivererPhoneNum = this.tEdit_DelivererPhoneNum.DataText;
            // ���i����
            sAndESetting.TradCompName = this.tEdit_TradCompName.DataText;
            // ���i�����_��
            sAndESetting.TradCompSectName = this.tEdit_TradCompSectName.DataText;
            // ���i���R�[�h�i�����j
            sAndESetting.PureTradCompCd = this.tEdit_PureTradCompCd.DataText.PadLeft(6, '0');
            // ���i���d�ؗ��i�����j
            sAndESetting.PureTradCompRate = Convert.ToDouble(this.tNedit_PureTradCompRate.DataText);
            // ���i���R�[�h�i�D�ǁj
            sAndESetting.PriTradCompCd = this.tEdit_PriTradCompCd.DataText.PadLeft(6, '0');
            // ���i���d�ؗ��i�D�ǁj
            sAndESetting.PriTradCompRate = Convert.ToDouble(this.tNedit_PriTradCompRate.DataText);
            // ���i�R�[�h
            //sAndESetting.ABGoodsCode = this.tEdit_ABGoodsCode.DataText.PadLeft(6, '0');// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            sAndESetting.ABGoodsCode = this.tEdit_ABGoodsCode.DataText.PadLeft(8, '0');// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            // 7�s�ڃR�����g�w��
            sAndESetting.CommentReservedDiv = this.tComboEditor_CommentReservedDiv.SelectedIndex;
            // OEM�敪
            sAndESetting.PartsOEMDiv = this.tComboEditor_PartsOEMDiv.SelectedIndex;
            // �����Ή����[�J�[�P
            sAndESetting.GoodsMakerCd1 = this.tNedit_GoodsMakerCd1.GetInt();
            // �����Ή����[�J�[�Q
            sAndESetting.GoodsMakerCd2 = this.tNedit_GoodsMakerCd2.GetInt();
            // �����Ή����[�J�[�R
            sAndESetting.GoodsMakerCd3 = this.tNedit_GoodsMakerCd3.GetInt();
            // �����Ή����[�J�[�S
            sAndESetting.GoodsMakerCd4 = this.tNedit_GoodsMakerCd4.GetInt();
            // �����Ή����[�J�[�T
            sAndESetting.GoodsMakerCd5 = this.tNedit_GoodsMakerCd5.GetInt();
            // �����Ή����[�J�[�U
            sAndESetting.GoodsMakerCd6 = this.tNedit_GoodsMakerCd6.GetInt();
            // �����Ή����[�J�[�V
            sAndESetting.GoodsMakerCd7 = this.tNedit_GoodsMakerCd7.GetInt();
            // �����Ή����[�J�[�W
            sAndESetting.GoodsMakerCd8 = this.tNedit_GoodsMakerCd8.GetInt();
            // �����Ή����[�J�[�X
            sAndESetting.GoodsMakerCd9 = this.tNedit_GoodsMakerCd9.GetInt();
            // �����Ή����[�J�[�P�O
            sAndESetting.GoodsMakerCd10 = this.tNedit_GoodsMakerCd10.GetInt();
            // �����Ή����[�J�[�P�P
            sAndESetting.GoodsMakerCd11 = this.tNedit_GoodsMakerCd11.GetInt();
            // �����Ή����[�J�[�P�Q
            sAndESetting.GoodsMakerCd12 = this.tNedit_GoodsMakerCd12.GetInt();
            // �����Ή����[�J�[�P�R
            sAndESetting.GoodsMakerCd13 = this.tNedit_GoodsMakerCd13.GetInt();
            // �����Ή����[�J�[�P�S
            sAndESetting.GoodsMakerCd14 = this.tNedit_GoodsMakerCd14.GetInt();
            // �����Ή����[�J�[�P�T
            sAndESetting.GoodsMakerCd15 = this.tNedit_GoodsMakerCd15.GetInt();

        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string str = "";
            LoadCustomerSearchRet(false);
            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    str = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
            }
            catch
            {
                str = "";
            }
            return str;

        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void LoadMakerUMnt( bool flg)
        {
            if (flg == false && _makerUMntDic != null)
            {
                return;
            }
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            try
            {
                ArrayList retList;

                // ���[�J�[����
                int status = _makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            // �ۑ����[�J�[
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : ���_�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void LoadSecInfoSet(bool flg)
        {
            if (flg == false && _secInfoSetDic != null)
            {
                return;
            }
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            _secInfoAcs.ResetSectionInfo();
            try
            {
                // ���_���̎擾
                foreach (SecInfoSet set in _secInfoAcs.SecInfoSetList)
                {
                    if (set.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(set.SectionCode.Trim(), set);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : ���Ӑ�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void LoadCustomerSearchRet(bool flg)
        {
            if (flg == false && _customerSearchRetDic != null)
            {
                return;
            }

            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            try
            {
                CustomerSearchRet[] retArray;
                CustomerSearchPara paraRec = new CustomerSearchPara();
                paraRec.EnterpriseCode = this._enterpriseCode;


                // ���Ӑ�}�X�^��񌟍�
                if (_customerSearchAcs.Serch(out retArray, paraRec) == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            // �ۑ����Ӑ�}�X�^���
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

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string str = "";
            // �擾���_���
            LoadSecInfoSet(false);
            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode))
                {
                    str = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
                }
            }
            catch
            {
                str = "";
            }
            return str;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.07.30</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// �폜��
            allDefSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMER_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMER_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ADDRESSEESHOP_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SANDEMNG_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_EXPENSEDIV_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DIRECTSENDING_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ACPTANORDERDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERER_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERER_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERERADDRESS_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DELIVERERPHONENUM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_TRADCOMP_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_TRADCOMPSECT_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PURETRADCOMP_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PURETRADCOMPRATE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PRITRADCOMP_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PRITRADCOMPRATE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ABGOODS_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PARTSOEMDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_COMMENTRESERVEDDIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE1_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE2_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE3_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE4_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE5_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE6_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE7_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE8_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE9_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE10_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE11_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE12_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE13_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE14_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE15_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(allDefSetTable);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date	    : 2009.07.31</br>
        /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
        /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// <br>UpdateNote  : 2014/05/16 ���� ��Y</br>
        /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̏����l�ύX</br>
        /// <br>Date        : 2025/03/04 ���O</br>
        /// <br>Update Note : PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�</br>
        /// </remarks>
        private void ScreenClear()
        {
            // �V�K��ʂ�߂�
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tEdit_CustomerName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_AddresseeShopCd.Clear();
            this.tEdit_SAndEMngCode.Clear();
            // --- ADD 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------>>>>>
            SAndEConst sAndeSetting = new SAndEConst();
            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                sAndeSetting = UserSettingController.DeserializeUserSetting<SAndEConst>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                this.tNedit_ExpenseDivCd.SetInt(sAndeSetting.ExpenseDivCd);
                this.tNedit_DirectSendingCd.SetInt(sAndeSetting.DirectSendingCd);
                this.tNedit_AcptAnOrderDiv.SetInt(sAndeSetting.AcptAnOrderDiv);
                this.tEdit_DelivererCd.DataText = sAndeSetting.DelivererCd;
                this.tEdit_DelivererNm.DataText = sAndeSetting.DelivererNm;
                this.tEdit_DelivererPhoneNum.DataText = sAndeSetting.DelivererPhoneNum;
                this.tEdit_DelivererAddress.DataText = sAndeSetting.DelivererAddress;
                this.tNedit_PureTradCompRate.SetValue(sAndeSetting.PureTradCompRate);
                this.tNedit_PriTradCompRate.SetValue(sAndeSetting.PriTradCompRate);
                this.tEdit_ABGoodsCode.DataText = sAndeSetting.ABGoodsCode;
                this.tComboEditor_CommentReservedDiv.SelectedIndex = sAndeSetting.CommentReservedDiv;
                this.tComboEditor_PartsOEMDiv.SelectedIndex = sAndeSetting.PartsOEMDiv;
            }
            else 
            {
                this.tNedit_ExpenseDivCd.SetInt(1);
                this.tNedit_DirectSendingCd.SetInt(1);
                this.tNedit_AcptAnOrderDiv.SetInt(10);
                this.tEdit_DelivererCd.DataText = "913011";
                this.tEdit_DelivererNm.DataText = "�i���j�A�h���B�b�N�X�Z�[���X";
                this.tEdit_DelivererPhoneNum.DataText = "05030944299";
                this.tEdit_DelivererAddress.DataText = "���m�����J�s���a��2-1";
                this.tNedit_PureTradCompRate.SetValue(98.0);
                this.tNedit_PriTradCompRate.SetValue(95.0);
                this.tEdit_ABGoodsCode.DataText = "00790322";
                this.tComboEditor_CommentReservedDiv.SelectedIndex = 0;
                this.tComboEditor_PartsOEMDiv.SelectedIndex = 0;
            }
            // --- ADD 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------<<<<<
            // --- DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------>>>>>
            //this.tNedit_ExpenseDivCd.SetInt(1);
            //this.tNedit_DirectSendingCd.SetInt(1);
            //this.tNedit_AcptAnOrderDiv.SetInt(10);
            //this.tEdit_DelivererCd.DataText = "913011";
            // --- DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------<<<<<
            // --- UPD �����` 2018/07/20 �r���d��Ɩ��̕ύX ---------->>>>>
            //this.tEdit_DelivererNm.DataText = "�r���d�u���[�L�i���j";
            //this.tEdit_DelivererPhoneNum.DataText = "072-771-0591";
            //this.tEdit_DelivererAddress.DataText = "���Ɍ��ɒO�s���z�k�P�|�P�|�P";
            // --- DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------>>>>>
            //this.tEdit_DelivererNm.DataText = "�i���j�A�h���B�b�N�X�Z�[���X";
            //this.tEdit_DelivererPhoneNum.DataText = "03-3454-7640";
            //this.tEdit_DelivererAddress.DataText = "�����s�`��O�c�R�|�P�P�|�R�S�|�X�e";
            // --- DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------<<<<<
            // --- UPD �����` 2018/07/20 �r���d��Ɩ��̕ύX ----------<<<<<
            this.tEdit_TradCompName.Clear();
            this.tEdit_TradCompSectName.Clear();
            this.tEdit_PureTradCompCd.Clear();
            //this.tNedit_PureTradCompRate.SetValue(98.0);// DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�
            this.tEdit_PriTradCompCd.Clear();
            //this.tNedit_PriTradCompRate.SetValue(95.0); // DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�
            //this.tEdit_ABGoodsCode.DataText = "790304";// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            // --- UPD �����Y 2014/05/16 �`�a���i�R�[�h�̏����l�ύX ---------->>>>>
            //this.tEdit_ABGoodsCode.DataText = "00790304";// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            //this.tEdit_ABGoodsCode.DataText = "00790322"; // DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�
            // --- UPD �����Y 2014/05/16 �`�a���i�R�[�h�̏����l�ύX ----------<<<<<
            this.tNedit_GoodsMakerCd1.Clear();
            this.tNedit_GoodsMakerCd2.Clear();
            this.tNedit_GoodsMakerCd3.Clear();
            this.tNedit_GoodsMakerCd4.Clear();
            this.tNedit_GoodsMakerCd5.Clear();
            this.tNedit_GoodsMakerCd6.Clear();
            this.tNedit_GoodsMakerCd7.Clear();
            this.tNedit_GoodsMakerCd8.Clear();
            this.tNedit_GoodsMakerCd9.Clear();
            this.tNedit_GoodsMakerCd10.Clear();
            this.tNedit_GoodsMakerCd11.Clear();
            this.tNedit_GoodsMakerCd12.Clear();
            this.tNedit_GoodsMakerCd13.Clear();
            this.tNedit_GoodsMakerCd14.Clear();
            this.tNedit_GoodsMakerCd15.Clear();
            // --- DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------>>>>>
            //this.tComboEditor_CommentReservedDiv.SelectedIndex = 0;
            //this.tComboEditor_PartsOEMDiv.SelectedIndex = 0;
            // --- DEL 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------<<<<<
            this._tmpSectionCode = string.Empty;
            this._tmpSectionName = string.Empty;
            this._tmpCustomerName = string.Empty;
            this._tmpCustomerCode = 0;
            this._prevMakerCode1 = 0;
            this._prevMakerCode2 = 0;
            this._prevMakerCode3 = 0;
            this._prevMakerCode4 = 0;
            this._prevMakerCode5 = 0;
            this._prevMakerCode6 = 0;
            this._prevMakerCode7 = 0;
            this._prevMakerCode8 = 0;
            this._prevMakerCode9 = 0;
            this._prevMakerCode10 = 0;
            this._prevMakerCode11 = 0;
            this._prevMakerCode12 = 0;
            this._prevMakerCode13 = 0;
            this._prevMakerCode14 = 0;
            this._prevMakerCode15 = 0;

            ScreenToSAndESetting( ref _sAndESettingInit);


        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="sAndESetting">�I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.07.31</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// </remarks>
        private void SAndESettingToScreen(SAndESetting sAndESetting)
        {
            // ���_�R�[�h
            this.tEdit_SectionCode.DataText = sAndESetting.SectionCode.Trim();
            // ���_����
            this.tEdit_SectionName.DataText = sAndESetting.SectionName.Trim();
            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(sAndESetting.CustomerCode);
            // ���Ӑ旪��
            this.tEdit_CustomerName.DataText = sAndESetting.CustomerName.Trim();
            // �[�i��X�܃R�[�h
            this.tEdit_AddresseeShopCd.DataText = sAndESetting.AddresseeShopCd.Trim();
            // S&E�Ǘ��R�[�h
            this.tEdit_SAndEMngCode.DataText = sAndESetting.SAndEMngCode.Trim();
            // �o��敪
            this.tNedit_ExpenseDivCd.SetInt(sAndESetting.ExpenseDivCd);
            // �����敪
            this.tNedit_DirectSendingCd.SetInt(sAndESetting.DirectSendingCd);
            // �󒍋敪
            this.tNedit_AcptAnOrderDiv.SetInt(sAndESetting.AcptAnOrderDiv);
            // �[�i�҃R�[�h
            this.tEdit_DelivererCd.DataText = sAndESetting.DelivererCd.Trim();
            // �[�i�Җ�
            this.tEdit_DelivererNm.DataText = sAndESetting.DelivererNm.Trim();
            // �[�i�ҏZ��
            this.tEdit_DelivererAddress.DataText = sAndESetting.DelivererAddress.Trim();
            // �[�i��TEL
            this.tEdit_DelivererPhoneNum.DataText = sAndESetting.DelivererPhoneNum.Trim();
            // ���i����
            this.tEdit_TradCompName.DataText = sAndESetting.TradCompName.Trim();
            // ���i�����_��
            this.tEdit_TradCompSectName.DataText = sAndESetting.TradCompSectName.Trim();
            // ���i���R�[�h�i�����j
            this.tEdit_PureTradCompCd.Text = sAndESetting.PureTradCompCd.Trim();
            // ���i���d�ؗ��i�����j
            this.tNedit_PureTradCompRate.SetValue(sAndESetting.PureTradCompRate);
            // ���i���R�[�h�i�D�ǁj
            this.tEdit_PriTradCompCd.Text = sAndESetting.PriTradCompCd.Trim();
            // ���i���d�ؗ��i�D�ǁj
            this.tNedit_PriTradCompRate.SetValue(sAndESetting.PriTradCompRate);
            // ���i�R�[�h
            //this.tEdit_ABGoodsCode.Text = sAndESetting.ABGoodsCode.Trim();// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            this.tEdit_ABGoodsCode.Text = sAndESetting.ABGoodsCode.Trim().PadLeft(8, '0');// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            // 7�s�ڃR�����g�w��
            this.tComboEditor_CommentReservedDiv.SelectedIndex = sAndESetting.CommentReservedDiv;
            // OEM�敪
            this.tComboEditor_PartsOEMDiv.SelectedIndex = sAndESetting.PartsOEMDiv;
            // �����Ή����[�J�[�P
            this.tNedit_GoodsMakerCd1.SetInt(sAndESetting.GoodsMakerCd1);
            // �����Ή����[�J�[�Q
            this.tNedit_GoodsMakerCd2.SetInt(sAndESetting.GoodsMakerCd2);
            // �����Ή����[�J�[�R
            this.tNedit_GoodsMakerCd3.SetInt(sAndESetting.GoodsMakerCd3);
            // �����Ή����[�J�[�S
            this.tNedit_GoodsMakerCd4.SetInt(sAndESetting.GoodsMakerCd4);
            // �����Ή����[�J�[�T
            this.tNedit_GoodsMakerCd5.SetInt(sAndESetting.GoodsMakerCd5);
            // �����Ή����[�J�[�U
            this.tNedit_GoodsMakerCd6.SetInt(sAndESetting.GoodsMakerCd6);
            // �����Ή����[�J�[�V
            this.tNedit_GoodsMakerCd7.SetInt(sAndESetting.GoodsMakerCd7);
            // �����Ή����[�J�[�W
            this.tNedit_GoodsMakerCd8.SetInt(sAndESetting.GoodsMakerCd8);
            // �����Ή����[�J�[�X
            this.tNedit_GoodsMakerCd9.SetInt(sAndESetting.GoodsMakerCd9);
            // �����Ή����[�J�[�P�O
            this.tNedit_GoodsMakerCd10.SetInt(sAndESetting.GoodsMakerCd10);
            // �����Ή����[�J�[�P�P
            this.tNedit_GoodsMakerCd11.SetInt(sAndESetting.GoodsMakerCd11);
            // �����Ή����[�J�[�P�Q
            this.tNedit_GoodsMakerCd12.SetInt(sAndESetting.GoodsMakerCd12);
            // �����Ή����[�J�[�P�R
            this.tNedit_GoodsMakerCd13.SetInt(sAndESetting.GoodsMakerCd13);
            // �����Ή����[�J�[�P�S
            this.tNedit_GoodsMakerCd14.SetInt(sAndESetting.GoodsMakerCd14);
            // �����Ή����[�J�[�P�T
            this.tNedit_GoodsMakerCd15.SetInt(sAndESetting.GoodsMakerCd15);
            // �ۑ��O�񃁁[�J�[
            this._prevMakerCode1 = sAndESetting.GoodsMakerCd1;
            this._prevMakerCode2 = sAndESetting.GoodsMakerCd2;
            this._prevMakerCode3 = sAndESetting.GoodsMakerCd3;
            this._prevMakerCode4 = sAndESetting.GoodsMakerCd4;
            this._prevMakerCode5 = sAndESetting.GoodsMakerCd5;
            this._prevMakerCode6 = sAndESetting.GoodsMakerCd6;
            this._prevMakerCode7 = sAndESetting.GoodsMakerCd7;
            this._prevMakerCode8 = sAndESetting.GoodsMakerCd8;
            this._prevMakerCode9 = sAndESetting.GoodsMakerCd9;
            this._prevMakerCode10 = sAndESetting.GoodsMakerCd10;
            this._prevMakerCode11 = sAndESetting.GoodsMakerCd11;
            this._prevMakerCode12 = sAndESetting.GoodsMakerCd12;
            this._prevMakerCode13 = sAndESetting.GoodsMakerCd13;
            this._prevMakerCode14 = sAndESetting.GoodsMakerCd14;
            this._prevMakerCode15 = sAndESetting.GoodsMakerCd15;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	��ƃR�[�h�ݒ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note	   : ��ƃR�[�h�ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.07.31</br>
        /// </remarks>
        private bool CheckDisplay()
        {
            bool status = true;
            string checkMessage = string.Empty;
            try
            {
                // ���_�R�[�h
                if (this.tEdit_SectionCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("���_{0}", ct_NoInput);
                    tEdit_SectionCode.Focus();
                    status = false;
                }
                // ���Ӑ�R�[�h
                else if (this.tNedit_CustomerCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("���Ӑ�{0}", ct_NoInput);
                    tNedit_CustomerCode.Focus();
                    status = false;
                }
                // �[�i��X�܃R�[�h
                else if (this.tEdit_AddresseeShopCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("�[�i��X�ܺ���{0}", ct_NoInput);
                    tEdit_AddresseeShopCd.Focus();
                    status = false;
                }
                // S&E�Ǘ�����
                else if (this.tEdit_SAndEMngCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("S&E�Ǘ�����{0}", ct_NoInput);
                    tEdit_SAndEMngCode.Focus();
                    status = false;
                }
                // �[���Һ���
                else if (this.tEdit_DelivererCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("�[���Һ���{0}", ct_NoInput);
                    tEdit_DelivererCd.Focus();
                    status = false;
                }
                // ���i������(����)
                else if (this.tEdit_PureTradCompCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("���i������(����){0}", ct_NoInput);
                    tEdit_PureTradCompCd.Focus();
                    status = false;
                }
                // ���i������(�D��)
                else if (this.tEdit_PriTradCompCd.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("���i������(�D��){0}", ct_NoInput);
                    tEdit_PriTradCompCd.Focus();
                    status = false;
                }
                // ���i����
                else if (this.tEdit_ABGoodsCode.DataText.Trim() == string.Empty)
                {
                    checkMessage = string.Format("���i����{0}", ct_NoInput);
                    tEdit_ABGoodsCode.Focus();
                    status = false;
                }
            }
            finally
            {
                if (checkMessage.Length > 0)
                {
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "PMSAE09010U",							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                }
            }
            return status;
        }

        /// <summary>
        ///	���[�J�[�`�F�b�N����
        /// </summary>
        /// <param name="flg">1�`99�����̓`�F�b�Nflg</param>
        /// <returns>�`�F�b�N���</returns>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�`�F�b�N���������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.07.31</br>
        /// </remarks>
        private bool MakerInputCheck(ref bool flg)
        {
            ArrayList makerList = new ArrayList();

            // ���͂������[�J�[���̕ۑ�
            makerList.Add(tNedit_GoodsMakerCd1.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd2.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd3.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd4.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd5.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd6.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd7.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd8.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd9.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd10.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd11.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd12.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd13.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd14.DataText.Trim());
            makerList.Add(tNedit_GoodsMakerCd15.DataText.Trim());

            // 1�`99�����͂��ꂽ�`�F�b�N
            for (int i = 0; i < MAKER_COUNT; i++)
            {
                if (string.IsNullOrEmpty(makerList[i].ToString().Trim()))
                {
                    continue;
                }
                else
                {
                    int maker = Convert.ToInt32(makerList[i].ToString().Trim());
                    if (maker.CompareTo(0) > 0 && maker.CompareTo(99) <= 0)
                    {
                        flg = false;
                        return (false);

                    }
                }
            }
            // ���[�J�[�R�[�h���d������Ă���ꍇ�̓G���[
            for (int i = 1; i <= MAKER_COUNT; i++)
            {
                string maker = makerList[i - 1].ToString();
                if (string.IsNullOrEmpty(maker))
                {
                    continue;
                }
                else
                {
                    for (int j = i+1; j < 16; j++)
                    {
                        string tempMaker = makerList[j - 1].ToString().PadLeft(4, '0');
                        if (maker.PadLeft(4, '0').Equals(tempMaker))
                        {
                            return (false);
                        }
                    }
                }
            }
            return true;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@�ۑ�����(SaveSAndESetting())
        /// </summary>
        /// <returns>�ۑ��������</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date	    : 2009.07.31</br>
        /// </remarks>
        private bool SaveSAndESetting()
        {
            bool result = false;
            Control control = null;

            // ��ʃt�H�[�J�X���擾����
            GetCurrentFocus();

            //�uAlt+S�v�`�F�b�N(�}�X�^�ƃ��[�J�[�̃`�F�b�N)
            ChangeFocusEventArgs e2 = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._preControl, this._preControl);
            this.tRetKeyControl1_ChangeFocus(this, e2);
            if (this.flg == false)
            {
                return false;
            }

            //��ʃf�[�^���̓`�F�b�N����
            bool chkSt = CheckDisplay();
            if (!chkSt)
            {
                return chkSt;
            }

            SAndESetting sAndESetting = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                sAndESetting = ((SAndESetting)this._sAndESettingTable[guid]).Clone();
            }

            ScreenToSAndESetting(ref sAndESetting);

            int status = this._sAndESettingAcs.Write(ref sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        this.tEdit_SectionCode.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            "PMSAE09010U",							// �A�Z���u��ID
                            "�I�[�g�o�b�N�X�ݒ�",  �@�@                 // �v���O��������
                            "SaveSAndESetting",                       // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._sAndESettingAcs,				    	// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,			  		// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
            }

            SAndESettingToDataSet(sAndESetting, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // �V�K�o�^��
            if (this.Mode_Label.Text.Equals(UPDATE_MODE))
            {
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            result = true;
            return result;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="sAndESetting">�I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.07.30</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// </remarks>
        private void SAndESettingToDataSet(SAndESetting sAndESetting, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (sAndESetting.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = sAndESetting.UpdateDateTimeJpInFormal;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = sAndESetting.SectionCode;
            // ���_����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sAndESetting.SectionName;
            //���Ӑ�R�[�h
            if (sAndESetting.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = sAndESetting.CustomerCode.ToString("D8");
            }
            //���Ӑ旪��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = sAndESetting.CustomerName;
            // �[�i��X�܃R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADDRESSEESHOP_CODE_TITLE] = sAndESetting.AddresseeShopCd;
            // S&E�Ǘ��R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SANDEMNG_CODE_TITLE] = sAndESetting.SAndEMngCode;
            //�o��敪
            if (sAndESetting.ExpenseDivCd == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXPENSEDIV_CODE_TITLE] =string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXPENSEDIV_CODE_TITLE] = sAndESetting.ExpenseDivCd;
 
            }
            //�����敪
            if (sAndESetting.DirectSendingCd == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DIRECTSENDING_CODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DIRECTSENDING_CODE_TITLE] = sAndESetting.DirectSendingCd;

            }
            // �󒍋敪
            if (sAndESetting.AcptAnOrderDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANORDERDIV_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANORDERDIV_TITLE] = sAndESetting.AcptAnOrderDiv.ToString("D2");

            }
            // �[�i�҃R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERER_CODE_TITLE] = sAndESetting.DelivererCd;
            // �[�i�Җ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERER_NAME_TITLE] = sAndESetting.DelivererNm;
            // �[�i�ҏZ��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERERADDRESS_TITLE] = sAndESetting.DelivererAddress;
            // �[�i��TEL
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVERERPHONENUM_TITLE] = sAndESetting.DelivererPhoneNum;
            // ���i����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TRADCOMP_NAME_TITLE] = sAndESetting.TradCompName;
            // ���i�����_��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TRADCOMPSECT_NAME_TITLE] = sAndESetting.TradCompSectName;
            // ���i���R�[�h�i�����j
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PURETRADCOMP_CODE_TITLE] = sAndESetting.PureTradCompCd;
            // ���i���d�ؗ��i�����j
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PURETRADCOMPRATE_TITLE] = sAndESetting.PureTradCompRate.ToString("F1");
            // ���i���R�[�h�i�D�ǁj
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRITRADCOMP_CODE_TITLE] = sAndESetting.PriTradCompCd;
            // ���i���d�ؗ��i�D�ǁj
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRITRADCOMPRATE_TITLE] = sAndESetting.PriTradCompRate.ToString("F1");
            // ���i�R�[�h
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODS_CODE_TITLE] = sAndESetting.ABGoodsCode;// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODS_CODE_TITLE] = sAndESetting.ABGoodsCode.PadLeft(8, '0');// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C

            // 7�s�ڃR�����g�w��
            if (sAndESetting.CommentReservedDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "����";
            }
            else if (sAndESetting.CommentReservedDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "���l";
            }
            else if (sAndESetting.CommentReservedDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "�ޕʌ^���{�^���Ԏ햼";
            }
            else if (sAndESetting.CommentReservedDiv == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMENTRESERVEDDIV_TITLE] = "�ޕʁ{�Ԏ햼�{���l";
            }

            // OEM�敪
            if (sAndESetting.PartsOEMDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PARTSOEMDIV_TITLE] = "������Ȃ�";
            }
            else if (sAndESetting.PartsOEMDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PARTSOEMDIV_TITLE] = "�������";
            }
            // �����Ή����[�J�[�P
            if (sAndESetting.GoodsMakerCd1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE1_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE1_TITLE] = sAndESetting.GoodsMakerCd1.ToString("D4");
            }
            // �����Ή����[�J�[�Q
            if (sAndESetting.GoodsMakerCd2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE2_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE2_TITLE] = sAndESetting.GoodsMakerCd2.ToString("D4");
            }
            // �����Ή����[�J�[�R
            if (sAndESetting.GoodsMakerCd3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE3_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE3_TITLE] = sAndESetting.GoodsMakerCd3.ToString("D4");
            }
            // �����Ή����[�J�[�S
            if (sAndESetting.GoodsMakerCd4 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE4_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE4_TITLE] = sAndESetting.GoodsMakerCd4.ToString("D4");
            }
            // �����Ή����[�J�[�T
            if (sAndESetting.GoodsMakerCd5 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE5_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE5_TITLE] = sAndESetting.GoodsMakerCd5.ToString("D4");
            }
            // �����Ή����[�J�[�U
            if (sAndESetting.GoodsMakerCd6 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE6_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE6_TITLE] = sAndESetting.GoodsMakerCd6.ToString("D4");
            }
            // �����Ή����[�J�[�V
            if (sAndESetting.GoodsMakerCd7 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE7_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE7_TITLE] = sAndESetting.GoodsMakerCd7.ToString("D4");
            }
            // �����Ή����[�J�[�W
            if (sAndESetting.GoodsMakerCd8 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE8_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE8_TITLE] = sAndESetting.GoodsMakerCd8.ToString("D4");
            }
            // �����Ή����[�J�[�X
            if (sAndESetting.GoodsMakerCd9 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE9_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE9_TITLE] = sAndESetting.GoodsMakerCd9.ToString("D4");
            }
            // �����Ή����[�J�[�P�O
            if (sAndESetting.GoodsMakerCd10 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE10_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE10_TITLE] = sAndESetting.GoodsMakerCd10.ToString("D4");
            }
            // �����Ή����[�J�[�P�P
            if (sAndESetting.GoodsMakerCd11 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE11_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE11_TITLE] = sAndESetting.GoodsMakerCd11.ToString("D4");
            } 
            // �����Ή����[�J�[�P�Q
            if (sAndESetting.GoodsMakerCd12 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE12_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE12_TITLE] = sAndESetting.GoodsMakerCd12.ToString("D4");
            }
            // �����Ή����[�J�[�P�R
            if (sAndESetting.GoodsMakerCd13 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE13_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE13_TITLE] = sAndESetting.GoodsMakerCd13.ToString("D4");
            }
            // �����Ή����[�J�[�P�S
            if (sAndESetting.GoodsMakerCd14 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE14_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE14_TITLE] = sAndESetting.GoodsMakerCd14.ToString("D4");
            } 
            // �����Ή����[�J�[�P�T
            if (sAndESetting.GoodsMakerCd15 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE15_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE15_TITLE] = sAndESetting.GoodsMakerCd15.ToString("D4");
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sAndESetting.FileHeaderGuid;

            if (this._sAndESettingTable.ContainsKey(sAndESetting.FileHeaderGuid) == true)
            {
                this._sAndESettingTable.Remove(sAndESetting.FileHeaderGuid);
            }
            this._sAndESettingTable.Add(sAndESetting.FileHeaderGuid, sAndESetting);
        }

        /// <summary>
        /// ����f�[�^�̃��b�Z�[�W
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ���ɋ��_�Ǘ��ݒ�}�X�^�ɓ���f�[�^����ꍇ�A���b�Z�[�W������B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date	    : 2009.07.30</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "PMSAE09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�����ɑ��݂��Ă��܂��B", // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            tEdit_SectionCode.Focus();

            control = tEdit_SectionCode;
        }

/*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMSAE09010U",							// �A�Z���u��ID
                    "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
        }

        /// <summary>
        /// ���͂��ꂽ�R�[�h�̃I�[�g�o�b�N�X�ݒ�}�X�^���̑��݃`�F�b�N����
        /// </summary>
        /// <returns>���݂̔��f</returns>
        /// <remarks>
        /// <br>Note       : ���͂��ꂽ�R�[�h�̃I�[�g�o�b�N�X�ݒ�}�X�^���̑��݃`�F�b�N�������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "���͂��ꂽ�R�[�h�̃I�[�g�o�b�N�X�ݒ�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";
            string currSectionCode = this.tEdit_SectionCode.DataText;
            int currCustomerCode = this.tNedit_CustomerCode.GetInt();
            if (string.IsNullOrEmpty(currSectionCode) || currCustomerCode == 0)
            {
                return true;
            }
            // �V�K���[�h�����_�Ɠ��Ӑ�̓��͓��e���I�[�g�o�b�N�X�ݒ�}�X�^�ɑ��݃`�F�b�N����
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string sectionCode = this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE].ToString().Trim();
                string customerCode = this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMER_CODE_TITLE].ToString().Trim();
                if (string.IsNullOrEmpty(sectionCode) || string.IsNullOrEmpty(customerCode))
                {
                    continue;
                }

                int intCustomerCode = Int32.Parse(customerCode);
                // �I�[�g�o�b�N�X�ݒ�}�X�^�ɑ��݂���ꍇ
                if (currSectionCode.Equals(sectionCode) && currCustomerCode == intCustomerCode)
                {
                    // �I�������̃f�[�^�͍폜�����ꍇ
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09010U", "���͂��ꂽ�R�[�h�̃I�[�g�o�b�N�X�ݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                        this.tEdit_SectionCode.Clear();
                        this.tEdit_SectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        _tmpSectionCode = string.Empty;
                        _tmpCustomerCode = 0;
                        _tmpCustomerName = string.Empty;
                        _tmpSectionName = string.Empty;
                        return false;
                    }
                    // �I�������̃f�[�^�͍폜���Ȃ��ꍇ
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09010U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            // this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:
                            this.tEdit_SectionCode.Clear();
                            this.tEdit_SectionName.Clear();
                            this.tNedit_CustomerCode.Clear();
                            this.tEdit_CustomerName.Clear();
                            _tmpSectionCode = string.Empty;
                            _tmpCustomerCode = 0;
                            _tmpCustomerName = string.Empty;
                            _tmpSectionName = string.Empty;
                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// �����𔻒f����
        /// </summary>
        /// <param name="str">������</param>
        /// <returns>���f����</returns>
        /// <remarks>
        /// <br>Note		: �����𔻒f�������s��</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private static bool NumberCheck(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]*$");
            bool flg = false;
            if (regex.Match(str).Success)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }

        /// <summary>
        /// �S�p�𔻒f����
        /// </summary>
        /// <param name="str">������</param>
        /// <returns>���f����</returns>
        /// <remarks>
        /// <br>Note		: �S�p�𔻒f�������s��</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private static bool FullCheck(string str)
        {
            bool isFull = true;
            if (str.Length < 0)
            {
                return true;
            }
            for (int i = 0; i < str.Length; i++)
            {
                String cutStr = str.Substring(i, 1);
                // �S�p�ł͂Ȃ��ꍇ
                if (ASCIIEncoding.Default.GetByteCount(cutStr) != 2)
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        /// <summary>
        /// TEL�𔻒f����
        /// </summary>
        /// <param name="str">������</param>
        /// <returns>���f����</returns>
        /// <remarks>
        /// <br>Note		: TEL�𔻒f�������s��</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.08.03</br>
        /// </remarks>
        private static bool TelCheck(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([0-9]|[-])*$");
            bool flg = false;
            if (regex.Match(str).Success)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
            return flg;
        }

        /// <summary>
        /// ���[�J�[���݃`�F�b�N����
        /// </summary>
        /// <param name="prev">prev</param>
        /// <param name="tNedit_GoodsMakerCd">���ptNedit</param>
        /// <param name="next">next</param>
        /// <param name="prevMakerCode">�ۑ��������ptNedit�l</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���[�J�[���݃`�F�b�N�������s��</br> 
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void CheckExistMaker(Object prev, TNedit tNedit_GoodsMakerCd, Object next, ref int prevMakerCode, ChangeFocusEventArgs e)
        {
            TNedit nextGoodsMakerCd;
            UltraButton button;
            TComboEditor tComboEditor;

            if (tNedit_GoodsMakerCd.GetInt() == 0)
            {
                prevMakerCode = 0;
                tNedit_GoodsMakerCd.DataText = string.Empty;
                return;

            }

            // ���[�J�[�擾
            int makerCode = tNedit_GoodsMakerCd.GetInt();

            // ���[�J�[�R�[�h�}�X�^�̌���
            if (this._makerUMntDic == null)
            {
                // ���[�J�[�}�X�^�Ǎ�����
                LoadMakerUMnt(false);
            }
            // ���[�J�[�R�[�h�}�X�^�`�F�b�NOK�̏ꍇ
            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                bool status = true;
                // 1�`99���̓`�F�b�N�Əd���`�F�b�N
                this.tNedit_GoodsMakerCd1_Leave(tNedit_GoodsMakerCd, out status);
                // 1�`99���̓`�F�b�N�Əd���`�F�b�NNG�ꍇ
                if (status == false)
                {
                    this.flg = false;
                    e.NextCtrl = e.PrevCtrl;
                }
                // 1�`99���̓`�F�b�N�Əd���`�F�b�NOK�ꍇ
                else
                {
                    this.flg = true;
                    if (e.ShiftKey == false)
                    {
                        //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down) // DEL 2009/09/04 WUYX PVCS422
                        if (e.Key == Keys.Return || e.Key == Keys.Tab) // ADD 2009/09/04 WUYX PVCS422
                        {
                            if (next is TNedit)
                            {
                                nextGoodsMakerCd = next as TNedit;
                                e.NextCtrl = nextGoodsMakerCd;
                            }
                            else if (next is UltraButton)
                            {
                                button = next as UltraButton;
                                e.NextCtrl = button;
                            }

                        }
                    }
                    // [Shift+Tab]�̏ꍇ
                    else if (e.ShiftKey == true)
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (prev is TNedit)
                            {
                                nextGoodsMakerCd = prev as TNedit;
                                e.NextCtrl = nextGoodsMakerCd;
                            }
                            else if (prev is TComboEditor)
                            {
                                tComboEditor = prev as TComboEditor;
                                e.NextCtrl = tComboEditor;
                            }
                        }
                    }
                }
            }
            else
            {
                // �O����͒l��ݒ�
                tNedit_GoodsMakerCd.SetInt(prevMakerCode);
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                    "PMSAE09010U",							// �A�Z���u��ID
                    "���[�J�[�����݂��܂���B",	                // �\�����郁�b�Z�[�W
                    0,									    // �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��

                e.NextCtrl = e.PrevCtrl;
                this.flg = false;

            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�I��������ݒ胁�[�J�[�l����
        /// </summary>
        /// <param name="tNedit_GoodsMakerCd">���ptNedit</param>
        /// <param name="next">NEXT</param>
        /// <param name="prevMakerCode">�ۑ��������ptNedit�l</param>
        /// <param name="makerUMnt">makerUMnt</param>
        /// <remarks> 
        /// <br>Note       : ���[�J�[�K�C�h�I��������ݒ胁�[�J�[�l�������s��</br> 
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void SetGoodsMakerValue(TNedit tNedit_GoodsMakerCd, Object next, ref int prevMakerCode, MakerUMnt makerUMnt)
        {

            TNedit nextGoodsMakerCd;
            UltraButton button;

            string checkMessage = string.Empty;
            bool flg = true;

            tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
            // 1�`99�����͂��ꂽ�`�F�b�N�ƃ��[�J�[�R�[�h���d������Ă���ꍇ�`�F�b�N
            if (!MakerInputCheck(ref flg))
            {
                // �O�񃁁[�J�[�̎擾
                tNedit_GoodsMakerCd.SetInt(prevMakerCode);
                if (flg == false)
                {
                    checkMessage = string.Format("�������[�J�[{0}", ct_SetError);
                }
                else
                {
                    checkMessage = string.Format("���[�J�[{0}", ct_DupliInput);
                }
                tNedit_GoodsMakerCd.Focus();
            }
            else
            {
                // �ۑ����͂������[�J�[�P
                prevMakerCode = makerUMnt.GoodsMakerCd;
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                if (next is TNedit)
                {
                    nextGoodsMakerCd = next as TNedit;
                    nextGoodsMakerCd.Focus();
                }
                else if (next is UltraButton)
                {
                    button = next as UltraButton;
                    button.Focus();
                }
            }

            if (checkMessage.Length > 0)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMSAE09010U",							// �A�Z���u��ID
                    checkMessage,	                        // �\�����郁�b�Z�[�W
                    0,									    // �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }

        }

        /// <summary>
        /// �G���[�������Đݒ胁�[�J�[�l����
        /// </summary>
        /// <param name="tNedit_GoodsMakerCd">���ptNedit</param>
        /// <remarks> 
        /// <br>Note       : �G���[�������Đݒ胁�[�J�[�l�������s��</br> 
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void ResetGoodsMaker(TNedit tNedit_GoodsMakerCd)
        {
            // ���[�J�[�P
            if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd1)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode1);
            }
            // ���[�J�[�Q
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd2)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode2);
            }
            // ���[�J�[�R
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd3)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode3);
            }
            // ���[�J�[�S
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd4)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode4);
            }
            // ���[�J�[�T
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd5)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode5);
            }
            // ���[�J�[�U
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd6)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode6);
            }
            // ���[�J�[�V
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd7)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode7);
            }
            // ���[�J�[�W
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd8)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode8);
            }
            // ���[�J�[�X
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd9)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode9);
            }
            // ���[�J�[�P�O
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd10)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode10);
            }
            // ���[�J�[�P�P
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd11)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode11);
            }
            // ���[�J�[�P�Q
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd12)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode12);
            }
            // ���[�J�[�P�R
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd13)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode13);
            }
            // ���[�J�[�P�S
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd14)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode14);
            }
            // ���[�J�[�P�T
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd15)
            {
                tNedit_GoodsMakerCd.SetInt(this._prevMakerCode15);
            }
        }

        /// <summary>
        /// ���񃁁[�J�[�l�ۑ�����
        /// </summary>
        /// <param name="tNedit_GoodsMakerCd">���ptNedit</param>
        /// <remarks> 
        /// <br>Note       : ���񃁁[�J�[�l�ۑ��������s��</br> 
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void SaveGoodsMaker(TNedit tNedit_GoodsMakerCd)
        {
            // ���[�J�[�P
            if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd1)
            {
                this._prevMakerCode1 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�Q
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd2)
            {
                this._prevMakerCode2 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�R
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd3)
            {
                this._prevMakerCode3 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�S
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd4)
            {
                this._prevMakerCode4 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�T
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd5)
            {
                this._prevMakerCode5 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�U
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd6)
            {
                this._prevMakerCode6 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�V
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd7)
            {
                this._prevMakerCode7 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�W
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd8)
            {
                this._prevMakerCode8 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�X
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd9)
            {
                this._prevMakerCode9 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�P�O
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd10)
            {
                this._prevMakerCode10 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�P�P
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd11)
            {
                this._prevMakerCode11 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�P�Q
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd12)
            {
                this._prevMakerCode12 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�P�R
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd13)
            {
                this._prevMakerCode13 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�P�S
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd14)
            {
                this._prevMakerCode14 = tNedit_GoodsMakerCd.GetInt();
            }
            // ���[�J�[�P�T
            else if (tNedit_GoodsMakerCd == this.tNedit_GoodsMakerCd15)
            {
                this._prevMakerCode15 = tNedit_GoodsMakerCd.GetInt();
            }
        }

        /// <summary>
        /// ��ʃt�H�[�J�X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃt�H�[�J�X�擾���s��</br> 
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void GetCurrentFocus()
        {
            // ��ʃt�H�[�J�X���f�A��ʃt�H�[�J�X���擾����
            if (this.tEdit_SectionCode.Focused)
            {
                // ���_
                this._preControl = this.tEdit_SectionCode;
            }
            else if (this.tNedit_CustomerCode.Focused)
            {
                // ���Ӑ�
                this._preControl = this.tNedit_CustomerCode;
            }
            else if (this.tNedit_GoodsMakerCd1.Focused)
            {
                // ���[�J�[�P
                this._preControl = this.tNedit_GoodsMakerCd1;
            }
            else if (this.tNedit_GoodsMakerCd2.Focused)
            {
                // ���[�J�[�Q
                this._preControl = this.tNedit_GoodsMakerCd2;
            }
            else if (this.tNedit_GoodsMakerCd3.Focused)
            {
                // ���[�J�[�R
                this._preControl = this.tNedit_GoodsMakerCd3;
            }
            else if (this.tNedit_GoodsMakerCd4.Focused)
            {
                // ���[�J�[�S
                this._preControl = this.tNedit_GoodsMakerCd4;
            }
            else if (this.tNedit_GoodsMakerCd5.Focused)
            {
                // ���[�J�[�T
                this._preControl = this.tNedit_GoodsMakerCd5;
            }
            else if (this.tNedit_GoodsMakerCd6.Focused)
            {
                // ���[�J�[�U
                this._preControl = this.tNedit_GoodsMakerCd6;
            }
            else if (this.tNedit_GoodsMakerCd7.Focused)
            {
                // ���[�J�[�V
                this._preControl = this.tNedit_GoodsMakerCd7;
            }
            else if (this.tNedit_GoodsMakerCd8.Focused)
            {
                // ���[�J�[�W
                this._preControl = this.tNedit_GoodsMakerCd8;
            }
            else if (this.tNedit_GoodsMakerCd9.Focused)
            {
                // ���[�J�[�X
                this._preControl = this.tNedit_GoodsMakerCd9;
            }
            else if (this.tNedit_GoodsMakerCd10.Focused)
            {
                // ���[�J�[�P�O
                this._preControl = this.tNedit_GoodsMakerCd10;
            }
            else if (this.tNedit_GoodsMakerCd11.Focused)
            {
                // ���[�J�[�P�P
                this._preControl = this.tNedit_GoodsMakerCd11;
            }
            else if (this.tNedit_GoodsMakerCd12.Focused)
            {
                // ���[�J�[�P�Q
                this._preControl = this.tNedit_GoodsMakerCd12;
            }
            else if (this.tNedit_GoodsMakerCd13.Focused)
            {
                // ���[�J�[�P�R
                this._preControl = this.tNedit_GoodsMakerCd13;
            }
            else if (this.tNedit_GoodsMakerCd14.Focused)
            {
                // ���[�J�[�P�S
                this._preControl = this.tNedit_GoodsMakerCd14;
            }
            else if (this.tNedit_GoodsMakerCd15.Focused)
            {
                // ���[�J�[�P�T
                this._preControl = this.tNedit_GoodsMakerCd15;
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load �C�x���g(PMSAE09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void PMSAE09010UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uButton_SectionGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerGuid.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            InitComboEditor();

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing �C�x���g(PMSAE09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void PMSAE09010UA_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSAE09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void PMSAE09010UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }
            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            ScreenClear();

            Timer.Enabled = true;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕۑ������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!SaveSAndESetting())
            {
                return;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SAndESetting compareSAndESetting = new SAndESetting();

                compareSAndESetting = this._sAndESettingClone.Clone();
                ScreenToSAndESetting(ref compareSAndESetting);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if (!(this._sAndESettingClone.Equals(compareSAndESetting) || this._sAndESettingInit.Equals(compareSAndESetting)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        "PMSAE09010U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSAndESetting())
                                {
                                    return;
                                }
                                return;
                            }

                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }

                        default:
                            {
                                this.Cancel_Button.Focus();
                                return;
                            }
                    }

                }

            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.08.03</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                    // �ݒ�l��ۑ�
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                    this._tmpSectionName = secInfoSet.SectionGuideNm.Trim();
                    if (this.ModeChangeProc())
                    {
                        this.tNedit_CustomerCode.Focus();
                    }
                    else
                    {
                        this.tEdit_SectionCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʊ��S�폜�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                "PMSAE09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SAndESetting sAndESetting = (SAndESetting)this._sAndESettingTable[guid];

            // ���_���_���폜����
            int status = this._sAndESettingAcs.Delete(sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._sAndESettingTable.Remove(sAndESetting.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMSAE09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._sAndESettingAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // ���������m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                "PMSAE09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���ݕ\�����̃I�[�g�o�b�N�X�ݒ�}�X�^�𕜊����܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SAndESetting sAndESetting = ((SAndESetting)this._sAndESettingTable[guid]).Clone();

            // ����
            status = this._sAndESettingAcs.Revival(ref sAndESetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        SAndESettingToDataSet(sAndESetting, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            "PMSAE09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._sAndESettingAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Renewal_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ŐV���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            LoadMakerUMnt(true);
            LoadSecInfoSet(true);
            LoadCustomerSearchRet(true);
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09010U", "�ŐV�����擾���܂����B", 0, MessageBoxButtons.OK);

        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���[�J�[�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void uButton_GoodsMakerGuid_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MakerUMnt makerUMnt = new MakerUMnt();

                // ���[�J�[�K�C�h�\��
                status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    // ���[�J�[1
                    if (this.tNedit_GoodsMakerCd1.GetInt() == 0)
                    {

                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd1, this.tNedit_GoodsMakerCd2, ref this._prevMakerCode1, makerUMnt);

                    }
                    // ���[�J�[2
                    else if (this.tNedit_GoodsMakerCd2.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd2, this.tNedit_GoodsMakerCd3, ref this._prevMakerCode2, makerUMnt);
                    }
                    // ���[�J�[3
                    else if (this.tNedit_GoodsMakerCd3.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd3, this.tNedit_GoodsMakerCd4, ref this._prevMakerCode3, makerUMnt);
                    }
                    // ���[�J�[4
                    else if (this.tNedit_GoodsMakerCd4.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd4, this.tNedit_GoodsMakerCd5, ref this._prevMakerCode4, makerUMnt);
                    }
                    // ���[�J�[5
                    else if (this.tNedit_GoodsMakerCd5.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd5, this.tNedit_GoodsMakerCd6, ref this._prevMakerCode5, makerUMnt);
                    }
                    // ���[�J�[6
                    else if (this.tNedit_GoodsMakerCd6.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd6, this.tNedit_GoodsMakerCd7, ref this._prevMakerCode6, makerUMnt);
                    }
                    // ���[�J�[7
                    else if (this.tNedit_GoodsMakerCd7.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd7, this.tNedit_GoodsMakerCd8, ref this._prevMakerCode7, makerUMnt);

                    }
                    // ���[�J�[8
                    else if (this.tNedit_GoodsMakerCd8.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd8, this.tNedit_GoodsMakerCd9, ref this._prevMakerCode8, makerUMnt);

                    }

                    // ���[�J�[9
                    else if (this.tNedit_GoodsMakerCd9.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd9, this.tNedit_GoodsMakerCd10, ref this._prevMakerCode9, makerUMnt);

                    }
                    // ���[�J�[10
                    else if (this.tNedit_GoodsMakerCd10.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd10, this.tNedit_GoodsMakerCd11, ref this._prevMakerCode10, makerUMnt);

                    }
                    // ���[�J�[11
                    else if (this.tNedit_GoodsMakerCd11.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd11, this.tNedit_GoodsMakerCd12, ref this._prevMakerCode11, makerUMnt);
                    }
                    // ���[�J�[12
                    else if (this.tNedit_GoodsMakerCd12.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd12, this.tNedit_GoodsMakerCd13, ref this._prevMakerCode12, makerUMnt);

                    }
                    // ���[�J�[13
                    else if (this.tNedit_GoodsMakerCd13.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd13, this.tNedit_GoodsMakerCd14, ref this._prevMakerCode13, makerUMnt);

                    }
                    // ���[�J�[14
                    else if (this.tNedit_GoodsMakerCd14.GetInt() == 0)
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd14, this.tNedit_GoodsMakerCd15, ref this._prevMakerCode14, makerUMnt);

                    }
                    // ���[�J�[15
                    else
                    {
                        SetGoodsMakerValue(this.tNedit_GoodsMakerCd15, this.Renewal_Button, ref this._prevMakerCode15, makerUMnt);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (this.ModeChangeProc())
                {
                    this.tEdit_AddresseeShopCd.Focus();
                }
                else
                {
                    this.tEdit_SectionCode.Focus();
                }
            }

        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �K�C�h�N��
            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;
            // ���ڂɓW�J
            if (_customerGuideSender == this.uButton_CustomerGuide)
            {
                this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                this.tEdit_CustomerName.Text = customerInfo.CustomerSnm;

                // �ݒ�l��ۑ�
                this._tmpCustomerCode = this.tNedit_CustomerCode.GetInt();
                this._tmpCustomerName = this.tEdit_CustomerName.DataText;
            }

            _customerGuideOK = true;
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks> 
        /// <br>Note       : ChangeFocus �C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._preControl = e.NextCtrl;
            this.flg = true;

            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�h
                case "tEdit_SectionCode":
                    {
                        // ���͖���
                        if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.Trim()))
                        {
                            _tmpSectionCode = string.Empty;
                            _tmpSectionName = string.Empty;
                            this.tEdit_SectionName.DataText = string.Empty;

                            break;
                        }

                        // ���_�R�[�h�擾
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                        // ���_���̎擾
                        string sectionName = GetSectionName(sectionCode);
                        if (!string.IsNullOrEmpty(sectionName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_SectionCode.Text = sectionCode;
                            this.tEdit_SectionName.DataText = sectionName;

                            // �ݒ�l��ۑ�
                            this._tmpSectionCode = sectionCode;
                            this._tmpSectionName = sectionName;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tEdit_SectionCode.Text = this._tmpSectionCode;
                            this.tEdit_SectionName.DataText = this._tmpSectionName;
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                "PMSAE09010U",							// �A�Z���u��ID
                                "���_�����݂��܂���B",	                // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }
                        if (ModeChangeProc())
                        {
                            if (e.ShiftKey == false)
                            {
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)  // DEL 2009/09/04 WUYX PVCS422
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)  // ADD 2009/09/04 WUYX PVCS422
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                }
                            }
                            // [Shift+Tab]
                            else if (e.ShiftKey == true)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.Cancel_Button;
                                }
                            }
                        }
                        else
                        {
                            // --- DEL 2009/09/04 WUYX PVCS422 ----->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            //{
                            //    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            //    e.NextCtrl = this.tEdit_SectionCode;
                            //    this.tEdit_SectionCode.Focus();
                            //    this.flg = false;
                            //}
                            // --- DEL 2009/09/04 WUYX PVCS422 -----<<<<<

                            // --- ADD 2009/09/04 WUYX PVCS422 ----->>>>>
                            e.NextCtrl = this.tEdit_SectionCode;
                            this.tEdit_SectionCode.Focus();
                            this.flg = false;
                            // --- ADD 2009/09/04 WUYX PVCS422 -----<<<<<
                        }
                        break;
                    }
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        // ���͖���
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            _tmpCustomerCode = 0;
                            this.tNedit_CustomerCode.DataText = string.Empty;
                            this.tEdit_CustomerName.DataText = string.Empty;

                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();
                        // ���Ӑ於�̎擾
                        string customerName = GetCustomerName(customerCode);

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_CustomerCode.SetInt(customerCode);
                            this.tEdit_CustomerName.DataText = customerName;

                            // �ݒ�l��ۑ�
                            this._tmpCustomerCode = customerCode;
                            this._tmpCustomerName = customerName;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_CustomerCode.SetInt(_tmpCustomerCode);
                            this.tEdit_CustomerName.DataText = _tmpCustomerName;

                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                "PMSAE09010U",							// �A�Z���u��ID
                                "���Ӑ悪���݂��܂���B",	                // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }
                        if (ModeChangeProc())
                        {
                            if (e.ShiftKey == false)
                            {
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)  // DEL 2009/09/04 WUYX PVCS422
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)  // ADD 2009/09/04 WUYX PVCS422
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_AddresseeShopCd;
                                }
                            }
                            // [Shift+Tab]
                            else if (e.ShiftKey == true)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        else
                        {
                            // --- DEL 2009/09/04 WUYX PVCS422 ----->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            //{
                            //    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            //    e.NextCtrl = this.tEdit_SectionCode;
                            //    this.tEdit_SectionCode.Focus();
                            //    this.flg = false;
                            //}
                            // --- DEL 2009/09/04 WUYX PVCS422 -----<<<<<

                            // --- ADD 2009/09/04 WUYX PVCS422 ----->>>>>
                            e.NextCtrl = this.tEdit_SectionCode;
                            this.tEdit_SectionCode.Focus();
                            this.flg = false;
                            // --- ADD 2009/09/04 WUYX PVCS422 -----<<<<<

                        }
                        break;
                    }
                // �[�i��X�܃R�[�h
                case "tEdit_AddresseeShopCd":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!NumberCheck(this.tEdit_AddresseeShopCd.Text))
                        {
                            this.tEdit_AddresseeShopCd.Text = string.Empty;
                        }
                        break;
                    }
                // S&E�Ǘ��R�[�h
                case "tEdit_SAndEMngCode":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!NumberCheck(this.tEdit_SAndEMngCode.Text))
                        {
                            this.tEdit_SAndEMngCode.Text = string.Empty;
                        }
                        break;
                    }
                // �o��敪
                case "tNedit_ExpenseDivCd":
                    {
                        // �R�s�[���������`�F�b�N
                        if (this.tNedit_ExpenseDivCd.GetInt() == 0)
                        {
                            this.tNedit_ExpenseDivCd.DataText = string.Empty;
                        }
                        break;
                    }
                // �����敪
                case "tNedit_DirectSendingCd":
                    {
                        // �R�s�[���������`�F�b�N
                        if (this.tNedit_DirectSendingCd.GetInt() == 0)
                        {
                            this.tNedit_DirectSendingCd.DataText = string.Empty;
                        }
                        break;
                    }
                // �󒍋敪
                case "tNedit_AcptAnOrderDiv":
                    {
                        // �R�s�[���������`�F�b�N
                        if (this.tNedit_AcptAnOrderDiv.GetInt() == 0)
                        {
                            this.tNedit_AcptAnOrderDiv.DataText = string.Empty;
                        }
                        break;
                    }
                // �[���҃R�[�h
                case "tEdit_DelivererCd":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!NumberCheck(this.tEdit_DelivererCd.Text))
                        {
                            this.tEdit_DelivererCd.Text = string.Empty;
                        }
                        break;
                    }
                // �[���Җ�
                case "tEdit_DelivererNm":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!FullCheck(this.tEdit_DelivererNm.Text))
                        {
                            this.tEdit_DelivererNm.Text = string.Empty;
                        }
                        break;
                    }
                // �[���ҏZ��
                case "tEdit_DelivererAddress":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!FullCheck(this.tEdit_DelivererAddress.Text))
                        {
                            this.tEdit_DelivererAddress.Text = string.Empty;
                        }
                        break;
                    }
                // �[����TEL
                case "tEdit_DelivererPhoneNum":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!TelCheck(this.tEdit_DelivererPhoneNum.Text))
                        {
                            this.tEdit_DelivererPhoneNum.Text = string.Empty;
                        }
                        break;
                    }
                // ���i����
                case "tEdit_TradCompName":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!FullCheck(this.tEdit_TradCompName.Text))
                        {
                            this.tEdit_TradCompName.Text = string.Empty;
                        }
                        break;
                    }
                // ���i���R�[�h(����)
                case "tEdit_PureTradCompCd":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!NumberCheck(this.tEdit_PureTradCompCd.Text))
                        {
                            this.tEdit_PureTradCompCd.Text = string.Empty;
                        }
                        break;
                    }
                // ���i���d�ؗ�(����)
                case "tNedit_PureTradCompRate":
                    {
                        // �R�s�[���������`�F�b�N
                        try
                        {
                            Double value = 0;
                            value = Convert.ToDouble(this.tNedit_PureTradCompRate.DataText);
                        }
                        catch
                        {
                            tNedit_PureTradCompRate.DataText = "0.0";
                        }
                        break;
                    }
                // ���i���R�[�h(�D��)
                case "tEdit_PriTradCompCd":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!NumberCheck(this.tEdit_PriTradCompCd.Text))
                        {
                            this.tEdit_PriTradCompCd.Text = string.Empty;
                        }
                        break;
                    }
                // ���i���d�ؗ�(�D��)
                case "tNedit_PriTradCompRate":
                    {
                        // �R�s�[���������`�F�b�N
                        try
                        {
                            Double value = 0;
                            value = Convert.ToDouble(this.tNedit_PriTradCompRate.DataText);
                        }
                        catch
                        {
                            tNedit_PriTradCompRate.DataText = "0.0";
                        }
                        break;
                    }
                // ���i�R�[�h
                case "tEdit_ABGoodsCode":
                    {
                        // �R�s�[���������`�F�b�N
                        if (!NumberCheck(this.tEdit_ABGoodsCode.Text))
                        {
                            this.tEdit_ABGoodsCode.Text = string.Empty;
                        }
                        break;
                    }
                // ���[�J�[�R�[�h1
                case "tNedit_GoodsMakerCd1":
                    {
                        CheckExistMaker(this.tComboEditor_CommentReservedDiv, this.tNedit_GoodsMakerCd1, this.tNedit_GoodsMakerCd2, ref this._prevMakerCode1, e);
                        break;
                    }
                // ���[�J�[�R�[�h2
                case "tNedit_GoodsMakerCd2":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd1, this.tNedit_GoodsMakerCd2, this.tNedit_GoodsMakerCd3, ref this._prevMakerCode2, e);
                        break;
                    }
                // ���[�J�[�R�[�h3
                case "tNedit_GoodsMakerCd3":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd2, this.tNedit_GoodsMakerCd3, this.tNedit_GoodsMakerCd4, ref this._prevMakerCode3, e);
                        break;
                    }
                // ���[�J�[�R�[�h4
                case "tNedit_GoodsMakerCd4":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd3, this.tNedit_GoodsMakerCd4, this.tNedit_GoodsMakerCd5, ref this._prevMakerCode4, e);
                        break;
                    }
                // ���[�J�[�R�[�h5
                case "tNedit_GoodsMakerCd5":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd4, this.tNedit_GoodsMakerCd5, this.tNedit_GoodsMakerCd6, ref this._prevMakerCode5, e);
                        break;
                    }
                // ���[�J�[�R�[�h6
                case "tNedit_GoodsMakerCd6":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd5, this.tNedit_GoodsMakerCd6, this.tNedit_GoodsMakerCd7, ref this._prevMakerCode6, e);
                        break;
                    }
                // ���[�J�[�R�[�h7
                case "tNedit_GoodsMakerCd7":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd6, this.tNedit_GoodsMakerCd7, this.tNedit_GoodsMakerCd8, ref this._prevMakerCode7, e);
                        break;
                    }
                // ���[�J�[�R�[�h8
                case "tNedit_GoodsMakerCd8":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd7, this.tNedit_GoodsMakerCd8, this.tNedit_GoodsMakerCd9, ref this._prevMakerCode8, e);
                        break;
                    }
                // ���[�J�[�R�[�h9
                case "tNedit_GoodsMakerCd9":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd8, this.tNedit_GoodsMakerCd9, this.tNedit_GoodsMakerCd10, ref this._prevMakerCode9, e);
                        break;
                    }
                // ���[�J�[�R�[�h10
                case "tNedit_GoodsMakerCd10":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd9, this.tNedit_GoodsMakerCd10, this.tNedit_GoodsMakerCd11, ref this._prevMakerCode10, e);
                        break;
                    }
                // ���[�J�[�R�[�h11
                case "tNedit_GoodsMakerCd11":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd10, this.tNedit_GoodsMakerCd11, this.tNedit_GoodsMakerCd12, ref this._prevMakerCode11, e);
                        break;
                    }
                // ���[�J�[�R�[�h12
                case "tNedit_GoodsMakerCd12":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd11, this.tNedit_GoodsMakerCd12, this.tNedit_GoodsMakerCd13, ref this._prevMakerCode12, e);
                        break;
                    }
                // ���[�J�[�R�[�h13
                case "tNedit_GoodsMakerCd13":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd12, this.tNedit_GoodsMakerCd13, this.tNedit_GoodsMakerCd14, ref this._prevMakerCode13, e);
                        break;
                    }
                // ���[�J�[�R�[�h14
                case "tNedit_GoodsMakerCd14":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd13, this.tNedit_GoodsMakerCd14, this.tNedit_GoodsMakerCd15, ref this._prevMakerCode14, e);
                        break;
                    }
                // ���[�J�[�R�[�h15
                case "tNedit_GoodsMakerCd15":
                    {
                        CheckExistMaker(this.tNedit_GoodsMakerCd14, this.tNedit_GoodsMakerCd15, this.Renewal_Button, ref this._prevMakerCode15, e);
                        break;
                    }
            }
        }

        /// <summary>
        /// tNedit_GoodsMakerCd1_Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="status">status</param>
        /// <returns>status</returns>
        /// <remarks> 
        /// <br>Note       : tNedit_GoodsMakerCd1_Leave�C�x���g���s��</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.07.31</br> 
        /// </remarks>
        private bool tNedit_GoodsMakerCd1_Leave(object sender, out bool status)
        {
            status = true;
            // �G���[
            string checkMessage = string.Empty;
            bool flg = true;
            TNedit currentTNedit = (TNedit)sender;
            try
            {
                if (!MakerInputCheck(ref flg))
                {
                    if (flg == false)
                    {
                        checkMessage = string.Format("�������[�J�[{0}", ct_SetError);
                        status = false;
                    }
                    else
                    {
                        checkMessage = string.Format("���[�J�[{0}", ct_DupliInput);
                        status = false;
                    }
                }
                else
                {
                    status = true;
                }

                return status;
            }
            finally
            {
                if (checkMessage.Length > 0)
                {
                    // �O�񃁁[�J�[�l��߂�
                    ResetGoodsMaker(currentTNedit);
                    currentTNedit.Focus();
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "PMSAE09010U",							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                }
                else
                {
                    // ���񃁁[�J�[�l��ۑ�����
                    SaveGoodsMaker(currentTNedit);
                }
            }
         }

        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
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
            }
            return true;
        }

        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
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

    }
    // --- ADD 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------>>>>>
    [Serializable]
    /// <summary>
    /// SAndEConst
    /// </summary>
    /// <remarks>
    /// <br>Date         : 2025/03/04</br>
    /// <br>Update Note  : PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή�</br>
    /// <br>Programmer   : ���O</br>
    /// </remarks>
    public struct SAndEConst
    { 
        /// <summary>�o��敪</summary>
		private Int32 _expenseDivCd;

		/// <summary>�����敪</summary>
		private Int32 _directSendingCd;

		/// <summary>�󒍋敪</summary>
		private Int32 _acptAnOrderDiv;

		/// <summary>�[�i�҃R�[�h</summary>
        private string _delivererCd;

		/// <summary>�[�i�Җ�</summary>
        private string _delivererNm;

		/// <summary>�[�i�ҏZ��</summary>
        private string _delivererAddress;

		/// <summary>�[�i�҂s�d�k</summary>
        private string _delivererPhoneNum;

		/// <summary>���i���d�ؗ��i�����j</summary>
		private Double _pureTradCompRate;

		/// <summary>���i���d�ؗ��i�D�ǁj</summary>
		private Double _priTradCompRate;

		/// <summary>AB���i�R�[�h</summary>
        private string _aBGoodsCode;

		/// <summary>�R�����g�w��敪</summary>
		private Int32 _commentReservedDiv;

		/// <summary>���i�n�d�l�敪</summary>
		private Int32 _partsOEMDiv;


		/// public propaty name  :  ExpenseDivCd
		/// <summary>�o��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExpenseDivCd
		{
			get{return _expenseDivCd;}
			set{_expenseDivCd = value;}
		}

		/// public propaty name  :  DirectSendingCd
		/// <summary>�����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DirectSendingCd
		{
			get{return _directSendingCd;}
			set{_directSendingCd = value;}
		}

		/// public propaty name  :  AcptAnOrderDiv
		/// <summary>�󒍋敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOrderDiv
		{
			get{return _acptAnOrderDiv;}
			set{_acptAnOrderDiv = value;}
		}

		/// public propaty name  :  DelivererCd
		/// <summary>�[�i�҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DelivererCd
		{
			get{return _delivererCd;}
			set{_delivererCd = value;}
		}

		/// public propaty name  :  DelivererNm
		/// <summary>�[�i�Җ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�Җ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DelivererNm
		{
			get{return _delivererNm;}
			set{_delivererNm = value;}
		}

		/// public propaty name  :  DelivererAddress
		/// <summary>�[�i�ҏZ���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�ҏZ���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DelivererAddress
		{
			get{return _delivererAddress;}
			set{_delivererAddress = value;}
		}

		/// public propaty name  :  DelivererPhoneNum
		/// <summary>�[�i�҂s�d�k�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�҂s�d�k�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DelivererPhoneNum
		{
			get{return _delivererPhoneNum;}
			set{_delivererPhoneNum = value;}
		}

		/// public propaty name  :  PureTradCompRate
		/// <summary>���i���d�ؗ��i�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���d�ؗ��i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PureTradCompRate
		{
			get{return _pureTradCompRate;}
			set{_pureTradCompRate = value;}
		}

		/// public propaty name  :  PriTradCompRate
		/// <summary>���i���d�ؗ��i�D�ǁj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���d�ؗ��i�D�ǁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PriTradCompRate
		{
			get{return _priTradCompRate;}
			set{_priTradCompRate = value;}
		}

		/// public propaty name  :  ABGoodsCode
		/// <summary>AB���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   AB���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ABGoodsCode
		{
			get{return _aBGoodsCode;}
			set{_aBGoodsCode = value;}
		}

		/// public propaty name  :  CommentReservedDiv
		/// <summary>�R�����g�w��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �R�����g�w��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CommentReservedDiv
		{
			get{return _commentReservedDiv;}
			set{_commentReservedDiv = value;}
		}

		/// public propaty name  :  PartsOEMDiv
		/// <summary>���i�n�d�l�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�n�d�l�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsOEMDiv
		{
			get{return _partsOEMDiv;}
			set{_partsOEMDiv = value;}
		}
    }
    // --- ADD 2025/03/04 ���O PMKOBETSU-4374 �r���d�u���[�L�I�v�V�����ύX�Ή� ------<<<<<

}
