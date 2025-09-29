//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�����e�i���X
// �v���O�����T�v   : �\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2009/11/11  �C�����e : Redmine#1223�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �C �� ��  2009/12/01  �C�����e : ���Ӑ�|���O���[�v����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{��
// �C �� ��  2012/04/23  �C�����e : �|��G���I���̒l��0�̂܂܁A���͋敪�ŋ����𕪊򂷂�悤�C���B
//                                  ���[�U�[���g���₷���悤�ɃL�[�d���`�F�b�N�^�C�~���O�������ǁB
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �\���敪�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �\���敪���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: ������</br>
    /// <br>Date		: 2009.10.15</br>
    /// <br></br>
    /// <br>Update Note  : 2009/11/11 ������</br>
    /// <br>               Redmine#1223�Ή�</br>
    /// </remarks>
    public partial class PMHNB09001UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\���敪�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �\���敪�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public PMHNB09001UA()
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
            // this._secInfoAcs = new SecInfoAcs();
            this._priceSelectSet = new PriceSelectSet();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._priceSelectSetAcs = new PriceSelectSetAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();

            // �ϐ�������
            this._dataIndex = -1;
            this._totalCount = 0;
            this._priceSelectSetTable = new Hashtable();
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
        private PriceSelectSetAcs _priceSelectSetAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _priceSelectSetTable;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �ۑ���r�pClone
        private PriceSelectSet _priceSelectSetClone;
        // �߂��r�pClone
        private PriceSelectSet _priceSelectSetInit;
        private PriceSelectSet _priceSelectSet;

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

        // tComboEditor�p
        private const string PRICESELECTPTN_VALUE0 = "Ұ�����ށEBL���ށE���Ӑ溰��";
        private const string PRICESELECTPTN_VALUE1 = "Ұ�����ށE���Ӑ溰��";
        private const string PRICESELECTPTN_VALUE2 = "BL���ށE���Ӑ溰��";
        private const string PRICESELECTPTN_VALUE3 = "Ұ�����ށEBL���ށE���Ӑ�|����ٰ��";
        private const string PRICESELECTPTN_VALUE4 = "Ұ�����ށE���Ӑ�|����ٰ��";
        private const string PRICESELECTPTN_VALUE5 = "BL���ށE���Ӑ�|����ٰ��";
        private const string PRICESELECTPTN_VALUE6 = "Ұ�����ށEBL����";
        private const string PRICESELECTPTN_VALUE7 = "Ұ������";
        // private const string PRICESELECTPTN_VALUE8 = "BL���"; // DEL 2009/11/11
        private const string PRICESELECTPTN_VALUE8 = "BL����"; // ADD 2009/11/11
        private const string PRICESELECTDIV_VALUE0 = "�D��";
        private const string PRICESELECTDIV_VALUE1 = "����";
        private const string PRICESELECTDIV_VALUE2 = "������(1:N)";
        private const string PRICESELECTDIV_VALUE3 = "������(1:1)";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_PRICESELECTPTN_TITLE = "���͋敪";
        private const string VIEW_MAKERCODE_TITLE = "���[�J�[�R�[�h";
        private const string VIEW_MAKERNAME_TITLE = "���[�J�[��";
        private const string VIEW_BLGOODSCODE_TITLE = "BL�R�[�h";
        private const string VIEW_BLGOODSNAME_TITLE = "BL�R�[�h��";
        private const string VIEW_CUSTRATEGRPCODE_TITLE = "���Ӑ�|���O���[�v";
        private const string VIEW_CUSTOMERCODE_TITLE = "���Ӑ�R�[�h";
        private const string VIEW_CUSTOMERNAME_TITLE = "���Ӑ於";
        private const string VIEW_PRICESELECTDIV_TITLE = "���i�\���敪";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        /// <summary>�N�����̓��Ӑ�|���R�[�h</summary>
        private const int INITIAL_CUST_RATE_GRP_CODE = -1;
        // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

        // �G���[���b�Z�[�W
        private string ct_NoInput = "��ݒ肵�ĉ������B";

        // ���Ӑ�K�C�h����OK�t���O
        //private bool _customerGuideOK; // DEL 2012/04/23

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private int _preMakerCode;
        private int _preCustomerCode;
        private int _preCustRateGrpCode;
        private int _preBLGoodsCode;
        private string _preMakerName;
        private string _preCustomerName;
        private string _preBLGoodsName;

        // ���[�J�[���
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        // ���_���
        //private Dictionary<string, SecInfoSet> _secInfoSetDic;
        // ���Ӑ���
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        // BL�R�[�h���
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, string> _custRateGrpDic;

        // �C���^�[�t�F�[�X
        private MakerAcs _makerAcs;
        private CustomerInfoAcs _customerInfoAcs;
        //private SecInfoAcs _secInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private UserGuideAcs _userGuideAcs;

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
        /// <br>Date		: 2009.10.15</br>
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
        /// <br>Date		: 2009.10.15</br>
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
            ArrayList priceSelectSets = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._priceSelectSetTable.Clear();

            // �S����
            status = this._priceSelectSetAcs.SearchAll(out priceSelectSets, this._enterpriseCode);
            this._totalCount = priceSelectSets.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (PriceSelectSet priceSelectSet in priceSelectSets)
                        {
                            // �\���敪�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
                            PriceSelectSetToDataSet(priceSelectSet.Clone(), index);
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
                            "PMHNB09001U",							// �A�Z���u��ID
                            "�\���敪",              �@�@   // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._priceSelectSetAcs,					    // �G���[�����������I�u�W�F�N�g
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
        /// <br>Date		: 2009.10.15</br>
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
        /// <br>Date		: 2009.10.15</br>
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
            PriceSelectSet priceSelectSet = (PriceSelectSet)this._priceSelectSetTable[guid];

            int status = 1;

            // ��ƃR�[�h�ݒ���_���폜����
            status = this._priceSelectSetAcs.LogicalDelete(ref priceSelectSet);

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
                            "PMHNB09001U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._priceSelectSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // ��ƃR�[�h�ݒ���N���X�f�[�^�Z�b�g�W�J����
            PriceSelectSetToDataSet(priceSelectSet.Clone(), this.DataIndex);

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
        /// <br>Date		: 2009.10.15</br>
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
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {

            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���̓p�^�[��
            appearanceTable.Add(VIEW_PRICESELECTPTN_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�J�[
            appearanceTable.Add(VIEW_MAKERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�J�[��
            appearanceTable.Add(VIEW_MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BL�R�[�h
            appearanceTable.Add(VIEW_BLGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BL�R�[�h��
            appearanceTable.Add(VIEW_BLGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ӑ�|���O���[�v
            appearanceTable.Add(VIEW_CUSTRATEGRPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ӑ�R�[�h
            appearanceTable.Add(VIEW_CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ӑ旪��
            appearanceTable.Add(VIEW_CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �\���敪
            appearanceTable.Add(VIEW_PRICESELECTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

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
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void InitComboEditor()
        {
            this.tComboEditor_PriceSelectPtn.Items.Clear();
            this.tComboEditor_PriceSelectPtn.Items.Add(0, PRICESELECTPTN_VALUE0);
            this.tComboEditor_PriceSelectPtn.Items.Add(1, PRICESELECTPTN_VALUE1);
            this.tComboEditor_PriceSelectPtn.Items.Add(2, PRICESELECTPTN_VALUE2);
            this.tComboEditor_PriceSelectPtn.Items.Add(3, PRICESELECTPTN_VALUE3);
            this.tComboEditor_PriceSelectPtn.Items.Add(4, PRICESELECTPTN_VALUE4);
            this.tComboEditor_PriceSelectPtn.Items.Add(5, PRICESELECTPTN_VALUE5);
            this.tComboEditor_PriceSelectPtn.Items.Add(6, PRICESELECTPTN_VALUE6);
            this.tComboEditor_PriceSelectPtn.Items.Add(7, PRICESELECTPTN_VALUE7);
            this.tComboEditor_PriceSelectPtn.Items.Add(8, PRICESELECTPTN_VALUE8);

            this.tComboEditor_PriceSelectDiv.Items.Clear();
            this.tComboEditor_PriceSelectDiv.Items.Add(0, PRICESELECTDIV_VALUE0);
            this.tComboEditor_PriceSelectDiv.Items.Add(1, PRICESELECTDIV_VALUE1);
            this.tComboEditor_PriceSelectDiv.Items.Add(2, PRICESELECTDIV_VALUE2);
            this.tComboEditor_PriceSelectDiv.Items.Add(3, PRICESELECTDIV_VALUE3);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                PriceSelectSet priceSelectSet = new PriceSelectSet();


                //�N���[���쐬
                this._priceSelectSetClone = priceSelectSet.Clone();

                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToPriceSelectSet(ref this._priceSelectSetClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tComboEditor_PriceSelectPtn.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                PriceSelectSet priceSelectSet = (PriceSelectSet)this._priceSelectSetTable[guid];
                
                if (priceSelectSet.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // �\���敪�}�X�^���N���X��ʓW�J����
                    PriceSelectSetToScreen(priceSelectSet);

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.tComboEditor_PriceSelectDiv.Focus();

                    // �N���[���쐬
                    this._priceSelectSetClone = priceSelectSet.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                    ScreenToPriceSelectSet(ref this._priceSelectSetClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // �\���敪�}�X�^���N���X��ʓW�J����
                    PriceSelectSetToScreen(priceSelectSet);

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();

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
        /// <br>Date		: 2009.10.15</br>
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
                        this.tComboEditor_PriceSelectPtn.Enabled = true;
                        this.tComboEditor_PriceSelectDiv.Enabled = true;
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tComboEditor_PriceSelectPtn.SelectedIndex = 0;
                        this.tComboEditor_PriceSelectDiv.SelectedIndex = 0;
                        // ��ʏ�����
                        ScreenClear();
                    }
                    else
                    {
                        // �X�V���[�h
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tComboEditor_PriceSelectPtn.Enabled = false;
                        this.tComboEditor_PriceSelectDiv.Enabled = true;
                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tNedit_GoodsMakerCd.Enabled = false;
                    this.tNedit_BLGoodsCode.Enabled = false;
                    this.CustRateGrpCodeAllowZero.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.uButton_BLGoodsGuide.Enabled = false;
                    this.uButton_CustRateGrpGuide.Enabled = false;
                    this.uButton_GoodsMakerGuid.Enabled = false;
                    this.tComboEditor_PriceSelectPtn.Enabled = false;
                    this.tComboEditor_PriceSelectDiv.Enabled = false;

                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ��\���敪�N���X�i�[����
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�\���敪�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.10.15</br>
        /// </remarks>
        private void ScreenToPriceSelectSet(ref PriceSelectSet priceSelectSet)
        {
            if (priceSelectSet == null)
            {
                // �V�K�̏ꍇ
                priceSelectSet = new PriceSelectSet();
            }

            //��ƃR�[�h
            priceSelectSet.EnterpriseCode = this._enterpriseCode;
            // ���̓p�^�[��
            priceSelectSet.PriceSelectPtn = this.tComboEditor_PriceSelectPtn.SelectedIndex;
            // ���[�J�[�R�[�h
            priceSelectSet.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // ���[�J�[��
            priceSelectSet.MakerName = this.tEdit_GoodsMakerName.DataText;
            // BL�R�[�h
            priceSelectSet.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            // BL�R�[�h��
            priceSelectSet.BLGoodsFullName = this.tEdit_BLGoodsName.DataText;
            // ���Ӑ�|���O���[�v
            priceSelectSet.CustRateGrpCode = this.CustRateGrpCodeAllowZero.GetInt();
            // ���Ӑ�R�[�h
            priceSelectSet.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // ���Ӑ於
            priceSelectSet.CustomerSnm = this.tEdit_CustomerName.DataText;
            // �\���敪
            priceSelectSet.PriceSelectDiv = this.tComboEditor_PriceSelectDiv.SelectedIndex;

        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
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
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";
            LoadMakerUMnt(false);
            try
            {
                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    makerName = this._makerUMntDic[makerCode].MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL�R�[�h����</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";
            LoadBLGoodsCdUMnt(false);
            try
            {
                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="flg">�Ǎ�DB�̃t���O</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
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
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : ���Ӑ�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
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
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <param name="flg">flg</param>
        /// <br>Note       : BL�R�[�h�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void LoadBLGoodsCdUMnt(bool flg)
        {
            if (flg == false && _blGoodsCdUMntDic != null)
            {
                return;
            }

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();
            ArrayList retList = new ArrayList();
            int status = this.GetUserGuideBd(out retList, 0x2b);
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
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="retList">���[�U�[�K�C�h�{�f�B�f�[�^���X�g</param>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// �폜��
            allDefSetTable.Columns.Add(VIEW_PRICESELECTPTN_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_MAKERCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_MAKERNAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_BLGOODSCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_BLGOODSNAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTRATEGRPCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMERCODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CUSTOMERNAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_PRICESELECTDIV_TITLE, typeof(string));
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
        /// <br>Date	    : 2009.10.15</br>
        /// </remarks>
        private void ScreenClear()
        {
            // �V�K��ʂ�߂�
            this.tComboEditor_PriceSelectPtn.SelectedIndex = 0;
            this.tComboEditor_PriceSelectDiv.SelectedIndex = 0;
            this.tNedit_GoodsMakerCd.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tNedit_CustomerCode.Clear();
            this.CustRateGrpCodeAllowZero.Clear();
            this.tEdit_BLGoodsName.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_GoodsMakerName.Clear();

            this._preCustomerCode = 0;
            this._preCustomerName = string.Empty;

            // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            //this._preCustRateGrpCode = 0;
            // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            this._preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
            // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

            this._preMakerCode = 0;
            this._preMakerName = string.Empty;
            this._preBLGoodsCode = 0;
            this._preBLGoodsName = string.Empty;

            ScreenToPriceSelectSet(ref _priceSelectSetInit);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\���敪�N���X��ʓW�J����
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �\���敪�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private void PriceSelectSetToScreen(PriceSelectSet priceSelectSet)
        {
            // ���̓p�^�[��
            this.tComboEditor_PriceSelectPtn.SelectedIndex = priceSelectSet.PriceSelectPtn;
            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.SetInt(priceSelectSet.GoodsMakerCd);
            // ���[�J�[��
            this.tEdit_GoodsMakerName.DataText = priceSelectSet.MakerName;
            // BL�R�[�h
            this.tNedit_BLGoodsCode.SetInt(priceSelectSet.BLGoodsCode);
            // BL�R�[�h��
            this.tEdit_BLGoodsName.DataText = priceSelectSet.BLGoodsFullName;
            // ���Ӑ�|���O���[�v
            // -- UPD 2012/04/23 -------------------------->>>>
            #region DEL ���͋敪�����Ŋ|��G�̕\�����@�𔻕ʂ���悤�C��
            //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
            //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            //if (priceSelectSet.CustRateGrpCode < 0)
            //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            //{
            //    // 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ�� 
            //    // 4:Ұ�����ށE���Ӑ�|����ٰ�� 
            //    // 5:BL���ށE���Ӑ�|����ٰ�� 
            //    if (this.tComboEditor_PriceSelectPtn.SelectedIndex == 3 || this.tComboEditor_PriceSelectPtn.SelectedIndex == 4 || this.tComboEditor_PriceSelectPtn.SelectedIndex == 5)
            //    {
            //        this.CustRateGrpCodeAllowZero.SetInt(priceSelectSet.CustRateGrpCode);
            //    }
            //    else
            //    {
            //        this.CustRateGrpCodeAllowZero.Clear();
            //    }
            //}
            //else
            //{
            //    this.CustRateGrpCodeAllowZero.SetInt(priceSelectSet.CustRateGrpCode);
            //}
            #endregion DEL ���͋敪�����Ŋ|��G�̕\�����@�𔻕ʂ���悤�C��
            if (this.tComboEditor_PriceSelectPtn.SelectedIndex == 3 || // 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                this.tComboEditor_PriceSelectPtn.SelectedIndex == 4 || // 4:Ұ�����ށE���Ӑ�|����ٰ�� 
                this.tComboEditor_PriceSelectPtn.SelectedIndex == 5)   // 5:BL���ށE���Ӑ�|����ٰ�� 
            {
                this.CustRateGrpCodeAllowZero.SetInt(priceSelectSet.CustRateGrpCode);
            }
            else
            {
                this.CustRateGrpCodeAllowZero.Clear();
            }
            // -- UPD 2012/04/23 --------------------------<<<<
            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(priceSelectSet.CustomerCode);
            // ���Ӑ於
            this.tEdit_CustomerName.DataText = priceSelectSet.CustomerSnm;
            // �\���敪
            this.tComboEditor_PriceSelectDiv.SelectedIndex = priceSelectSet.PriceSelectDiv;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	��ƃR�[�h�ݒ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note	   : ��ƃR�[�h�ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private bool CheckDisplay()
        {
            bool status = true;
            string checkMessage = string.Empty;
            try
            {
                // ���[�J�[�R�[�h
                if ((this.tNedit_GoodsMakerCd.GetInt() == 0) && (this.tNedit_GoodsMakerCd.Enabled == true))
                {
                    checkMessage = string.Format("���[�J�[{0}", ct_NoInput);
                    this.tNedit_GoodsMakerCd.Focus();
                    status = false;
                }
                // BL�R�[�h
                else if ((this.tNedit_BLGoodsCode.GetInt() == 0) && (this.tNedit_BLGoodsCode.Enabled == true))
                {
                    checkMessage = string.Format("BL�R�[�h{0}", ct_NoInput);
                    this.tNedit_BLGoodsCode.Focus();
                    status = false;
                }
                // ���Ӑ�|���O���[�v
                // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // TODO:else if ((this.tNedit_CustRateGrpCode.GetInt() == 0) && (this.tNedit_CustRateGrpCode.Enabled == true))
                // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // -- UPD 2012/04/23 --------------------------------->>>>
                //else if ((this.CustRateGrpCodeAllowZero.GetInt() < 0) && (this.CustRateGrpCodeAllowZero.Enabled == true))
                else if ((this.CustRateGrpCodeAllowZero.Text == "") && (this.CustRateGrpCodeAllowZero.Enabled == true))
                // -- UPD 2012/04/23 ---------------------------------<<<<
                // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                {
                    checkMessage = string.Format("���Ӑ�|���O���[�v{0}", ct_NoInput);
                    this.CustRateGrpCodeAllowZero.Focus();
                    status = false;
                }
                // ���Ӑ�R�[�h
                else if ((this.tNedit_CustomerCode.GetInt() == 0)&&(this.tNedit_CustomerCode.Enabled == true))
                {
                    checkMessage = string.Format("���Ӑ�R�[�h{0}", ct_NoInput);
                    this.tNedit_CustomerCode.Focus();
                    status = false;
                }
            }
            finally
            {
                if (checkMessage.Length > 0)
                {
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "PMHNB09001U",							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                }
            }
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@�ۑ�����(SavePriceSelectSet())
        /// </summary>
        /// <returns>�ۑ��������</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date	    : 2009.10.15</br>
        /// </remarks>
        private bool SavePriceSelectSet()
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

            PriceSelectSet priceSelectSet = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                priceSelectSet = ((PriceSelectSet)this._priceSelectSetTable[guid]).Clone();
            }

            ScreenToPriceSelectSet(ref priceSelectSet);

            int status = this._priceSelectSetAcs.Write(ref priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // -- UPD 2012/04/23 -------------------->>>>
                        //this.ScreenClear();
                        MessageBox.Show("�ۑ����܂����B", "�ۑ��m�F",
                                        MessageBoxButtons.OK, MessageBoxIcon.None);

                        //��r�p�N���[���ɃR�s�[
                        this._priceSelectSetClone = priceSelectSet.Clone();
                        // -- UPD 2012/04/23 --------------------<<<<

                        this.tComboEditor_PriceSelectPtn.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        //control.Focus();    // DEL 2012/04/23
                        
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
                            "PMHNB09001U",							// �A�Z���u��ID
                            "�\���敪",  �@�@                 // �v���O��������
                            "SavePriceSelectSet",                       // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._priceSelectSet,				    	// �G���[�����������I�u�W�F�N�g
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

            PriceSelectSetToDataSet(priceSelectSet, this.DataIndex);

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
        /// �\���敪�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �\���敪�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.10.15</br>
        /// </remarks>
        private void PriceSelectSetToDataSet(PriceSelectSet priceSelectSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (priceSelectSet.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = priceSelectSet.UpdateDateTimeJpInFormal;
            }

            // ���̓p�^�[��
            // 0:Ұ�����ށEBL���ށE���Ӑ溰��
            if (priceSelectSet.PriceSelectPtn == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE0;
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            //  1:Ұ�����ށE���Ӑ溰��
            else if (priceSelectSet.PriceSelectPtn == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE1;
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 2:BL���ށE���Ӑ溰��
            else if (priceSelectSet.PriceSelectPtn == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE2;
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
            else if (priceSelectSet.PriceSelectPtn == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE3;
                // ���Ӑ�|���O���[�v
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
            }
            // 4:Ұ�����ށE���Ӑ�|����ٰ��
            else if (priceSelectSet.PriceSelectPtn == 4)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE4;
                // ���Ӑ�|���O���[�v
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");

            }
            // 5:BL���ށE���Ӑ�|����ٰ��
            else if (priceSelectSet.PriceSelectPtn == 5)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE5;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
            }
            // 6:Ұ�����ށEBL����
            else if (priceSelectSet.PriceSelectPtn == 6)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE6;
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 7:Ұ������
            else if (priceSelectSet.PriceSelectPtn == 7)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE7;
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }
            // 8:BL����
            else if (priceSelectSet.PriceSelectPtn == 8)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTPTN_TITLE] = PRICESELECTPTN_VALUE8;
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 ------------------------->>>>
                #region DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //// TODO:if (priceSelectSet.CustRateGrpCode == 0)
                //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (priceSelectSet.CustRateGrpCode < 0)
                //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                //}
                //else
                //{
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = priceSelectSet.CustRateGrpCode.ToString("D4");
                //}
                #endregion DEL ���̓��̓p�^�[���̎��́A�Œ�ŋ󔒂ɂ���悤�ύX
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTRATEGRPCODE_TITLE] = string.Empty;
                // -- UPD 2012/04/23 -------------------------<<<<
            }

            // ���[�J�[�R�[�h
            if (priceSelectSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAKERCODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAKERCODE_TITLE] = priceSelectSet.GoodsMakerCd.ToString("D4");
            }

            //�@���[�J�[��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAKERNAME_TITLE] = priceSelectSet.MakerName;

            //�@BL�R�[�h
            if (priceSelectSet.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODSCODE_TITLE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODSCODE_TITLE] = priceSelectSet.BLGoodsCode.ToString("D5");
            }

            // BL�R�[�h��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODSNAME_TITLE] = priceSelectSet.BLGoodsFullName;

            //�@���Ӑ�R�[�h
            if (priceSelectSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCODE_TITLE] =string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCODE_TITLE] = priceSelectSet.CustomerCode.ToString("D8");
            }

            //�@���Ӑ於
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERNAME_TITLE] = priceSelectSet.CustomerSnm;

            // �\���敪
            if (priceSelectSet.PriceSelectDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE0;
            }
            else if (priceSelectSet.PriceSelectDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE1;
            }
            else if (priceSelectSet.PriceSelectDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE2;
            }
            else if (priceSelectSet.PriceSelectDiv == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRICESELECTDIV_TITLE] = PRICESELECTDIV_VALUE3;
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = priceSelectSet.FileHeaderGuid;

            if (this._priceSelectSetTable.ContainsKey(priceSelectSet.FileHeaderGuid) == true)
            {
                this._priceSelectSetTable.Remove(priceSelectSet.FileHeaderGuid);
            }

            this._priceSelectSetTable.Add(priceSelectSet.FileHeaderGuid, priceSelectSet);
        }

        /// <summary>
        /// ����f�[�^�̃��b�Z�[�W
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ���ɋ��_�Ǘ��ݒ�}�X�^�ɓ���f�[�^����ꍇ�A���b�Z�[�W������B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date	    : 2009.10.15</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "PMHNB09001U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�����ɑ��݂��Ă��܂��B", // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            // -- DEL 2012/04/23 ------------------------->>>>
            //this.tComboEditor_PriceSelectPtn.Focus();

            //control = tComboEditor_PriceSelectPtn;
            // -- DEL 2012/04/23 -------------------------<<<<
        }

/*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMHNB09001U",							// �A�Z���u��ID
                    "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
        }

        /// <summary>
        /// ���̓p�^�[������ʂ̏�Ԃ𔻒f
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���̓p�^�[������ʂ̏�Ԃ𔻒f���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private bool PriceSelectPtnCheck()
        {
            int currMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            int currCustomerCode = this.tNedit_CustomerCode.GetInt();
            int currBLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            string currustRateGrpCode = this.CustRateGrpCodeAllowZero.DataText;
            int number = this.tComboEditor_PriceSelectPtn.SelectedIndex;
            bool flg = true;
            switch (number)
            {
                case 0:// 0:Ұ�����ށEBL���ށE���Ӑ溰�� 
                    {
                        if ((currMakerCode == 0) || (currCustomerCode == 0) || (currBLGoodsCode == 0))
                        {
                            flg = false;
                        }
                        break;
                    }
                case 1:// 1:Ұ�����ށE���Ӑ溰�� 
                    {
                        if (currMakerCode == 0 || currCustomerCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 2:// 2:BL���ށE���Ӑ溰�� 
                    {
                        if (currCustomerCode == 0 || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 3:// 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ�� 
                    {
                        if (currMakerCode == 0 || string.IsNullOrEmpty(currustRateGrpCode) || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 4:// 4:Ұ�����ށE���Ӑ�|����ٰ�� 
                    {
                        if (currMakerCode == 0 || string.IsNullOrEmpty(currustRateGrpCode))
                        {
                            flg = false;
                        }
                        break;
                    }
                case 5:// 5:BL���ށE���Ӑ�|����ٰ�� 
                    {
                        if (string.IsNullOrEmpty(currustRateGrpCode) || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 6:// 6:Ұ�����ށEBL���� 
                    {
                        if (currMakerCode == 0 || currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 7:// 7:Ұ������ 
                    {
                        if (currMakerCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
                case 8:// 8:BL����
                    {
                        if (currBLGoodsCode == 0)
                        {
                            flg = false;
                        }
                        break;
                    }
            }
            return flg;
        }

        /// <summary>
        /// ���͂��ꂽ�R�[�h�̕\���敪�}�X�^���̑��݃`�F�b�N����
        /// </summary>
        /// <returns>���݂̔��f</returns>
        /// <remarks>
        /// <br>Note       : ���͂��ꂽ�R�[�h�̕\���敪�}�X�^���̑��݃`�F�b�N�������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "���͂��ꂽ�R�[�h�̕\���敪�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";
            if (!PriceSelectPtnCheck())
            {
                return true;
            }

            int currMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            int currCustomerCode = this.tNedit_CustomerCode.GetInt();
            int currBLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            int currCustRateGrpCode = this.CustRateGrpCodeAllowZero.GetInt();
            int currNumber = this.tComboEditor_PriceSelectPtn.SelectedIndex;


            // �V�K���[�h�����[�J�[�Ɠ��Ӑ�Ɠ��Ӑ�|���O���[�v��BL���i�R�[�h�̓��͓��e���\���敪�}�X�^�ɑ��݃`�F�b�N����
            int makerCode = 0;
            int BLGoodsCode = 0;
            int custRateGrpCode = 0;
            int customerCode = 0;
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                // ���[�J�[
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_MAKERCODE_TITLE].ToString().Trim()))
                {
                    makerCode = 0;
                }
                else
                {
                    makerCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_MAKERCODE_TITLE].ToString().Trim());
                }
                // BL���i�R�[�h
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_BLGOODSCODE_TITLE].ToString().Trim()))
                {
                    BLGoodsCode = 0;
                }
                else
                {
                    BLGoodsCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_BLGOODSCODE_TITLE].ToString().Trim());
                }
                // ���Ӑ�|���O���[�v
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTRATEGRPCODE_TITLE].ToString().Trim()))
                {
                    custRateGrpCode = 0;
                }
                else
                {
                    custRateGrpCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTRATEGRPCODE_TITLE].ToString().Trim());
                }
                // ���Ӑ�
                if (string.IsNullOrEmpty(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMERCODE_TITLE].ToString().Trim()))
                {
                    customerCode = 0;
                }
                else
                {
                    customerCode = Int32.Parse(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMERCODE_TITLE].ToString().Trim());
                }
                
                // �\���敪�}�X�^�ɑ��݂���ꍇ
                if ((currMakerCode == makerCode) && (currCustomerCode == customerCode) && (currBLGoodsCode == BLGoodsCode) && (currCustRateGrpCode == custRateGrpCode))
                {
                    // �I�������̃f�[�^�͍폜�����ꍇ
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMHNB09001U", "���͂��ꂽ�R�[�h�̕\���敪�}�X�^���͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                        this.tNedit_BLGoodsCode.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        _preCustomerCode = 0;
                        _preCustomerCode = 0;

                        // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        //_preCustRateGrpCode = 0;
                        // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        _preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
                        // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                        _preBLGoodsCode = 0;
                        _preBLGoodsName = string.Empty;
                        _preCustomerName = string.Empty;
                        _preMakerName = string.Empty;
                        return false;
                    }
                    // �I�������̃f�[�^�͍폜���Ȃ��ꍇ
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMHNB09001U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            // this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:

                            #region DEL 2012/04/23 �������I�����A��ʃN���A���Ȃ��悤�ύX
                            //this.tNedit_BLGoodsCode.Clear();
                            //this.CustRateGrpCodeAllowZero.Clear();
                            //this.tNedit_CustomerCode.Clear();
                            //this.tNedit_GoodsMakerCd.Clear();
                            //this.tEdit_BLGoodsName.Clear();
                            //this.tEdit_CustomerName.Clear();
                            //this.tEdit_GoodsMakerName.Clear();
                            //_preCustomerCode = 0;
                            //_preCustomerCode = 0;

                            //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            ////_preCustRateGrpCode = 0;
                            //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                            //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            //_preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
                            //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                            //_preBLGoodsCode = 0;
                            //_preBLGoodsName = string.Empty;
                            //_preCustomerName = string.Empty;
                            //_preMakerName = string.Empty;
                            #endregion DEL 2012/04/23 �������I�����A��ʃN���A���Ȃ��悤�ύX

                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// ��ʃt�H�[�J�X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃt�H�[�J�X�擾���s��</br> 
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void GetCurrentFocus()
        {
            // ��ʃt�H�[�J�X���f�A��ʃt�H�[�J�X���擾����
            if (this.tNedit_GoodsMakerCd.Focused)
            {
                // ���[�J�[
                this._preControl = this.tNedit_GoodsMakerCd;
            }
            else if (this.tNedit_CustomerCode.Focused)
            {
                // ���Ӑ�
                this._preControl = this.tNedit_CustomerCode;
            }
            else if (this.tNedit_BLGoodsCode.Focused)
            {
                // BL�R�[�h
                this._preControl = this.tNedit_BLGoodsCode;
            }
            else if (this.CustRateGrpCodeAllowZero.Focused)
            {
                // ���Ӑ�|���O���[�v
                this._preControl = this.CustRateGrpCodeAllowZero;
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load �C�x���g(PMHNB09001UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void PMHNB09001UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uButton_BLGoodsGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerGuid.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustRateGrpGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        ///	Form.Closing �C�x���g(PMHNB09001UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void PMHNB09001UA_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged �C�x���g(PMHNB09001UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void PMHNB09001UA_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Date        : 2009.10.15</br>
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

            if (!SavePriceSelectSet())
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
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                PriceSelectSet comparePriceSelectSet = new PriceSelectSet();

                comparePriceSelectSet = this._priceSelectSetClone.Clone();
                ScreenToPriceSelectSet(ref comparePriceSelectSet);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if (!(this._priceSelectSetClone.Equals(comparePriceSelectSet) || this._priceSelectSetInit.Equals(comparePriceSelectSet)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        "PMHNB09001U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SavePriceSelectSet())
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
        /// <br>Date        : 2009.10.15</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br>
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
                "PMHNB09001U",						// �A�Z���u���h�c�܂��̓N���X�h�c
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
            PriceSelectSet priceSelectSet = (PriceSelectSet)this._priceSelectSetTable[guid];

            // ���_���_���폜����
            int status = this._priceSelectSetAcs.Delete(priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._priceSelectSetTable.Remove(priceSelectSet.FileHeaderGuid);

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
                            "PMHNB09001U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._priceSelectSet, 				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Date       : 2009.10.15</br>
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
                "PMHNB09001U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���ݕ\�����̕\���敪�}�X�^�𕜊����܂��B" + "\r\n" +
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
            PriceSelectSet priceSelectSet = ((PriceSelectSet)this._priceSelectSetTable[guid]).Clone();
            // ����
            status = this._priceSelectSetAcs.Revival(ref priceSelectSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        PriceSelectSetToDataSet(priceSelectSet, this._dataIndex);
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
                            "PMHNB09001U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._priceSelectSet,				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            LoadMakerUMnt(true);
            LoadBLGoodsCdUMnt(true);
            LoadCustomerSearchRet(true);
            GetCustRateGrp();
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMHNB09001U", "�ŐV�����擾���܂����B", 0, MessageBoxButtons.OK);

        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���[�J�[�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.10.15</br> 
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
                    this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                    this.tEdit_GoodsMakerName.DataText = makerUMnt.MakerName;

                    // �ݒ�l��ۑ�
                    this._preMakerCode = makerUMnt.GoodsMakerCd;
                    this._preMakerName = makerUMnt.MakerName;

                    #region DEL 2012/04/23
                    // �\���敪�}�X�^�ɑ��݃`�F�b�N
                    //if (this.ModeChangeProc())
                    //{
                    //    // �t�H�[�J�X�ݒ�
                    //    if (this.tNedit_BLGoodsCode.Enabled == true)
                    //    {
                    //        this.tNedit_BLGoodsCode.Focus();
                    //    }
                    //    else if (this.CustRateGrpCodeAllowZero.Enabled == true)
                    //    {
                    //        this.CustRateGrpCodeAllowZero.Focus();
                    //    }
                    //    else if (this.tNedit_CustomerCode.Enabled == true)
                    //    {
                    //        this.tNedit_CustomerCode.Focus();
                    //    }
                    //    else
                    //    {
                    //        this.tComboEditor_PriceSelectDiv.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    SetModeChangeProcFocus();
                    //}
                    #endregion DEL 2012/04/23
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// BL���i�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : BL���i�R�[�h�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_BLGoodsGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BL�R�[�h�K�C�h�\��
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    // -- UPD 2012/04/23 ----------------------------------->>>>
                    //this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();
                    this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    // -- UPD 2012/04/23 -----------------------------------<<<<

                    // �ݒ�l��ۑ�
                    this._preBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                    // -- UPD 2012/04/23 ----------------------------------->>>>
                    //this._preBLGoodsName = blGoodsCdUMnt.BLGoodsFullName.ToString().Trim();
                    this._preBLGoodsName = blGoodsCdUMnt.BLGoodsHalfName.ToString().Trim();
                    // -- UPD 2012/04/23 -----------------------------------<<<<

                    #region DEL 2012/04/23
                    // �\���敪�}�X�^�ɑ��݃`�F�b�N
                    //if (this.ModeChangeProc())
                    //{
                    //    // �t�H�[�J�X�ݒ�
                    //    if (this.CustRateGrpCodeAllowZero.Enabled == true)
                    //    {
                    //        this.CustRateGrpCodeAllowZero.Focus();
                    //    }
                    //    else if (this.tNedit_CustomerCode.Enabled == true)
                    //    {
                    //        this.tNedit_CustomerCode.Focus();
                    //    }
                    //    else
                    //    {
                    //        this.tComboEditor_PriceSelectDiv.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    SetModeChangeProcFocus();
                    //}
                    #endregion DEL 2012/04/23
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// �}�X�^�`�F�b�N���ăt�H�[�J�X�ݒ�C�x���g
        /// </summary>
        /// <returns>TNedit</returns>
        /// <remarks> 
        /// <br>Note       : �}�X�^�`�F�b�N���ăt�H�[�J�X�ݒ�̏������s��</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private TNedit SetModeChangeProcFocus()
        {
            int num = this.tComboEditor_PriceSelectPtn.SelectedIndex;
            TNedit nextTNedit = new TNedit();
            switch (num)
            {
                case 0:// 0:Ұ�����ށEBL���ށE���Ӑ溰�� 
                case 1:// 1:Ұ�����ށE���Ӑ溰�� 
                case 3:// 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ�� 
                case 4:// 4:Ұ�����ށE���Ӑ�|����ٰ�� 
                case 6:// 6:Ұ�����ށEBL���� 
                case 7:// 7:Ұ������ 
                    {
                        nextTNedit = this.tNedit_GoodsMakerCd;
                        this.tNedit_GoodsMakerCd.Focus();
                        break;
                    }
                case 2:// 2:BL���ށE���Ӑ溰�� 
                case 5:// 5:BL���ށE���Ӑ�|����ٰ�� 
                case 8:// 8:BL����
                    {
                        nextTNedit = this.tNedit_BLGoodsCode;
                        this.tNedit_BLGoodsCode.Focus();
                        break;
                    }

            }
            return nextTNedit;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�|���O���[�v�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_CustRateGrpGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    this.CustRateGrpCodeAllowZero.DataText = userGdBd.GuideCode.ToString("D4");
                    // �ݒ�l��ۑ�
                    this._preCustRateGrpCode = userGdBd.GuideCode;

                    #region DEL 2012/04/23
                    // �\���敪�}�X�^�ɑ��݃`�F�b�N
                    //if (this.ModeChangeProc())
                    //{
                    //    // �t�H�[�J�X�ݒ�
                    //    if (this.tNedit_CustomerCode.Enabled == true)
                    //    {
                    //        this.tNedit_CustomerCode.Focus();
                    //    }
                    //    else
                    //    {
                    //        this.tComboEditor_PriceSelectDiv.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    SetModeChangeProcFocus();
                    //}
                    #endregion DEL 2012/04/23
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
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            //_customerGuideOK = false; // DEL 2012/04/23

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            #region DEL 2012/04/23
            //if (_customerGuideOK)
            //{
            //     �\���敪�}�X�^�ɑ��݃`�F�b�N
            //    if (this.ModeChangeProc())
            //    {
            //        this.tComboEditor_PriceSelectDiv.Focus();
            //    }
            //    else
            //    {
            //        SetModeChangeProcFocus();
            //    }
            //}
            #endregion DEL 2012/04/23

        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">customerSearchRet</param>
        /// <remarks> 
        /// <br>Note       : ���Ӑ�K�C�h���N���b�N����Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.10.15</br> 
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
                this._preCustomerCode = this.tNedit_CustomerCode.GetInt();
                this._preCustomerName = this.tEdit_CustomerName.DataText;
            }

            //_customerGuideOK = true; // DEL 2012/04/23
        }

        /// <summary>
        /// ���̓p�^�[��ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks> 
        /// <br>Note       : ���̓p�^�[��ValueChanged�Ƃ��ɔ�������</br> 
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2009.10.15</br> 
        /// </remarks>
        private void tComboEditor_PriceSelectPtn_ValueChanged(object sender, EventArgs e)
        {
            switch (this.tComboEditor_PriceSelectPtn.SelectedIndex)
            {
                case 0:// 0:Ұ�����ށEBL���ށE���Ӑ溰�� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 1:// 1:Ұ�����ށE���Ӑ溰�� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 2:// 2:BL���ށE���Ӑ溰�� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = true;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 3:// 3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ�� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 4:// 4:Ұ�����ށE���Ӑ�|����ٰ�� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 5:// 5:BL���ށE���Ӑ�|����ٰ�� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = true;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = true;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 6:// 6:Ұ�����ށEBL���� 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 7:// 7:Ұ������ 
                    {
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = true;
                        this.uButton_BLGoodsGuide.Enabled = false;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
                case 8:// 8:BL����
                    {
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustRateGrpCodeAllowZero.Enabled = false;
                        this.uButton_GoodsMakerGuid.Enabled = false;
                        this.uButton_BLGoodsGuide.Enabled = true;
                        this.uButton_CustRateGrpGuide.Enabled = false;
                        this.uButton_CustomerGuide.Enabled = false;
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_GoodsMakerName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.CustRateGrpCodeAllowZero.Clear();
                        break;
                    }
            }

        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks> 
        /// <br>Note       : ChangeFocus �C�x���g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.15</br> 
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
                // ���[�J�[
                case "tNedit_GoodsMakerCd":
                    {
                        // ���͖���
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            this._preMakerCode = 0;
                            this._preMakerName = string.Empty;
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tEdit_GoodsMakerName.Clear();
                            break;
                        }

                        // ���[�J�[���̎擾
                        string makerName = GetMakerName(this.tNedit_GoodsMakerCd.GetInt());
                        if (!string.IsNullOrEmpty(makerName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_GoodsMakerName.DataText = makerName;

                            // �ݒ�l��ۑ�
                            this._preMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                            this._preMakerName = makerName;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_GoodsMakerCd.SetInt(this._preMakerCode);
                            this.tEdit_GoodsMakerName.DataText = this._preMakerName;
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                "PMHNB09001U",							// �A�Z���u��ID
                                "���[�J�[�����݂��܂���B",	                // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�                          
                        //            if (this.tNedit_BLGoodsCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            }
                        //            else if (this.CustRateGrpCodeAllowZero.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.CustRateGrpCodeAllowZero;
                        //            }
                        //            else if (this.tNedit_CustomerCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_CustomerCode;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //            }
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();
                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        // ���͖���
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            this._preCustomerCode = 0;
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
                            this._preCustomerCode = customerCode;
                            this._preCustomerName = customerName;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_CustomerCode.SetInt(this._preCustomerCode);
                            this.tEdit_CustomerName.DataText = this._preCustomerName;

                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                "PMHNB09001U",							// �A�Z���u��ID
                                "���Ӑ悪���݂��܂���B",	                // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            if (this.CustRateGrpCodeAllowZero.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.CustRateGrpCodeAllowZero;
                        //            }
                        //            else if (this.tNedit_BLGoodsCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            }
                        //            else if (this.tNedit_GoodsMakerCd.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            }
                        //            else if (this.tComboEditor_PriceSelectPtn.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();

                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
                // BL�R�[�h
                case "tNedit_BLGoodsCode":
                    {
                        // ���͖���
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            this._preBLGoodsCode = 0;
                            this._preBLGoodsName = string.Empty;
                            this.tNedit_BLGoodsCode.DataText = string.Empty;
                            this.tEdit_BLGoodsName.DataText = string.Empty;
                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        // ���Ӑ於�̎擾
                        string bLGoodsName = GetBLGoodsName(bLGoodsCode);

                        if (!string.IsNullOrEmpty(bLGoodsName))
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_BLGoodsCode.SetInt(bLGoodsCode);
                            this.tEdit_BLGoodsName.DataText = bLGoodsName;

                            // �ݒ�l��ۑ�
                            this._preBLGoodsCode = bLGoodsCode;
                            this._preBLGoodsName = bLGoodsName;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_BLGoodsCode.SetInt(this._preBLGoodsCode);
                            this.tEdit_BLGoodsName.DataText = this._preBLGoodsName;

                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                "PMHNB09001U",							// �A�Z���u��ID
                                "BL�R�[�h�����݂��܂���B",	                // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            if (this.CustRateGrpCodeAllowZero.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.CustRateGrpCodeAllowZero;
                        //            }
                        //            else if (this.tNedit_CustomerCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_CustomerCode;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //            }
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            if (this.tNedit_GoodsMakerCd.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();
                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
                // ���Ӑ�|���O���[�v
                // -- UPD 2012/04/23 -------------------------->>>>
                //case "tNedit_CustRateGrpCode":
                case "CustRateGrpCodeAllowZero":
                // -- UPD 2012/04/23 -------------------------->>>>
                    {
                        // -- UPD 2012/04/23 ---------------------------->>>>
                        #region DEL -1�ł͂Ȃ��󔒂������ꍇ�ɖ����͂Ɣ��肷��
                        //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        //// TODO:if (this.tNedit_CustRateGrpCode.GetInt() == 0)
                        //// DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        //if (this.CustRateGrpCodeAllowZero.GetInt() < 0)
                        //// ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        #endregion DEL -1�ł͂Ȃ��󔒂������ꍇ�ɖ����͂Ɣ��肷��
                        if (this.CustRateGrpCodeAllowZero.Text == "")
                        // -- UPD 2012/04/23 ----------------------------<<<<
                        {
                            this.CustRateGrpCodeAllowZero.Clear();
                            // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            // this._preCustRateGrpCode = 0;
                            // DEL 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                            // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            this._preCustRateGrpCode = INITIAL_CUST_RATE_GRP_CODE;
                            // ADD 2009/12/01 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                            return;
                        }
                        int custRateGrpCode = this.CustRateGrpCodeAllowZero.GetInt();
                        // �}�X�^�̌���
                        if (this._custRateGrpDic == null)
                        {
                            // ���[�J�[�}�X�^�Ǎ�����
                            GetCustRateGrp();
                        }
                        if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
                        {
                            this._preCustRateGrpCode = custRateGrpCode;
                            this.CustRateGrpCodeAllowZero.SetInt(custRateGrpCode);
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            // -- UPD 2012/04/23 ------------------------------->>>>
                            //this.CustRateGrpCodeAllowZero.SetInt(this._preCustRateGrpCode);
                            if (this._preCustRateGrpCode != INITIAL_CUST_RATE_GRP_CODE)
                            {
                                this.CustRateGrpCodeAllowZero.SetInt(this._preCustRateGrpCode);
                            }
                            else
                            {
                                this.CustRateGrpCodeAllowZero.Text = "";
                            }
                            // -- UPD 2012/04/23 -------------------------------<<<<
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                "PMHNB09001U",							// �A�Z���u��ID
                                "���Ӑ�|���O���[�v�����݂��܂���B",	                // �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                            e.NextCtrl = e.PrevCtrl;
                            this.flg = false;

                            return;
                        }

                        #region DEL 2012/04/23
                        //if (ModeChangeProc())
                        //{
                        //    if (e.ShiftKey == false)
                        //    {
                        //        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            if (this.tNedit_CustomerCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_CustomerCode;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectDiv;
                        //            }
                        //        }
                        //    }
                        //    // [Shift+Tab]
                        //    else if (e.ShiftKey == true)
                        //    {
                        //        if (e.Key == Keys.Tab)
                        //        {
                        //            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                        //            if (this.tNedit_BLGoodsCode.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            }
                        //            else if (this.tNedit_GoodsMakerCd.Enabled == true)
                        //            {
                        //                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            }
                        //            else
                        //            {
                        //                e.NextCtrl = this.tComboEditor_PriceSelectPtn;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = SetModeChangeProcFocus();

                        //}
                        #endregion DEL 2012/04/23

                        break;
                    }
            }
            // -- ADD 2012/04/23 ------------------------------->>>>
            if ((e.PrevCtrl.Name == "tComboEditor_PriceSelectPtn") ||
                (e.PrevCtrl.Name == "tNedit_GoodsMakerCd") ||
                (e.PrevCtrl.Name == "tNedit_CustomerCode") ||
                (e.PrevCtrl.Name == "tNedit_BLGoodsCode") ||
                (e.PrevCtrl.Name == "CustRateGrpCodeAllowZero") ||
                (e.PrevCtrl.Name == "uButton_GoodsMakerGuid") ||
                (e.PrevCtrl.Name == "uButton_BLGoodsGuide") ||
                (e.PrevCtrl.Name == "uButton_CustRateGrpGuide") ||
                (e.PrevCtrl.Name == "uButton_CustomerGuide") ||
                (e.PrevCtrl.Name == "Cancel_Button"))
            {
                if ((e.NextCtrl.Name != "tComboEditor_PriceSelectPtn") &&
                    (e.NextCtrl.Name != "tNedit_GoodsMakerCd") &&
                    (e.NextCtrl.Name != "tNedit_CustomerCode") &&
                    (e.NextCtrl.Name != "tNedit_BLGoodsCode") &&
                    (e.NextCtrl.Name != "CustRateGrpCodeAllowZero") &&
                    (e.NextCtrl.Name != "uButton_GoodsMakerGuid") &&
                    (e.NextCtrl.Name != "uButton_BLGoodsGuide") &&
                    (e.NextCtrl.Name != "uButton_CustRateGrpGuide") &&
                    (e.NextCtrl.Name != "uButton_CustomerGuide") &&
                    (e.NextCtrl.Name != "Cancel_Button"))
                {
                    ModeChangeProc();
                }
            }
            // -- ADD 2012/04/23 -------------------------------<<<<
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
        /// <br>Date       : 2009.10.15</br>
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
        /// <br>Date       : 2009.10.15</br>
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
}
