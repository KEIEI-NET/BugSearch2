//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �FPCC�L�����y�[���ݒ�}�X�^�����e
// �v���O�����T�v   �FPCC�L�����y�[���ݒ�}�X�^�o�^�E�C���E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2011 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/08/10  �C�����e : �V�K�쐬       
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����H
// �� �� ��  2011/11/25  �C�����e : Redmain#8077 ����߰ݕ\���ݒ�Ͻ�/�ُ�G���[       
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2012/10/11  �C�����e : 2012/11/14�z�M�� SCM��Q��10298 �x�[�X�ݒ�𖳎�
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC�L�����y�[���ݒ�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^���s���܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.10</br>
    /// </remarks>
    public partial class PMPCC09060UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Constructor

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public PMPCC09060UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint                  = false;
            this._canClose                  = true;
            this._canNew                    = true;
            this._canDelete                 = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //���O�C���S���҂̋��_ 
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // �ϐ�������
            this._pccCpMsgStAcs = new PccCpMsgStAcs(); 

            this._detailsTable = new Hashtable();
            //���Ӑ�R�[�h�O���b�h
            this._customerBindTable = new DataTable(MY_SCREEN_TABLE);
            //�i�ڐݒ�p�f�[�^�e�[�u��
            this._itemBindTable = new DataTable(PCCITEMST_TABLE);
            this._allSearchHash = new Hashtable();
            //GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._detailsIndexBuf = -2;
            this._customerInfoAcs = new CustomerInfoAcs();
            //�L�����y�[���ݒ�
            this._campaignStAcs = new CampaignStAcs();
            //�L�����y�[���֘A
            this._campaignLinkAcs = new CampaignLinkAcs();

            _bLGoodsCdAcs = new BLGoodsCdAcs();
           //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
            _scmEpCnectAcs = new ScmEpCnectAcs();
            this._scmEpScCntAcs = new ScmEpScCntAcs();

            // ��ʏ����ݒ菈��
            CustomerScreenInitialSetting();
            ItemScreenInitialSetting();
            //�S��BLCode���擾
            this._pccCpMsgStAcs.GetAllBLGoodsCdUMnt();
            this._bLCodeTable = this._pccCpMsgStAcs.BLCodeTable;
            // ���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
            this._pccCpMsgStAcs.GetCustomerHTable();
            this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            //�S�Đڑ���񂪐ݒ�Hashtable���擾
            this._pccCpMsgStAcs.GetAllScmEpScCnt();
            this._scmEpScCntTable = this._pccCpMsgStAcs.ScmEpScCntTable;
        }

        # endregion

        #region IMasterMaintenanceMultiType �����o

        # region ��Properties
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

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

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        # endregion ��Properties

        # region ��Public Methods

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(CAMPAIGNCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CAMPAIGNNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(PCCMSGDOCCNTS_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CAMPAIGNOBJDIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(APPLYSTADATE_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(APPLYENDDATE_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            return appearanceTable;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }

        # endregion ��Public Methods

        # region ��Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion

        #region Private Menbers

        private PccCpMsgStAcs _pccCpMsgStAcs;     // PCC�L�����y�[���ݒ�}�X�^�p�A�N�Z�X�N���X

        private string _enterpriseCode;         // ��ƃR�[�h
        private string _loginSectionCode;
        private Hashtable _detailsTable;        // PCC�L�����y�[���ݒ�}�X�^�p�n�b�V���e�[�u��
        private Hashtable _allSearchHash;       // �S���R�[�h�m�ۗp

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
            
        //_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _detailsIndexBuf;
        //���Ӑ�O���b�h�p�f�[�^�e�[�u��
        private DataTable _customerBindTable;
        //�i�ڐݒ�p�f�[�^�e�[�u��
        private DataTable _itemBindTable;

       
        //PCC�L�����y�[���Ώېݒ�f�B�N�V���i���[
        Dictionary<string, Dictionary<string, PccCpTgtSt>> _pccCpTgtStDicDic = null;
        Dictionary<string, PccCpTgtSt> _pccCpTgtStDicClone = null;
        Dictionary<string, PccCpTgtSt> _pccCpTgtStDicCloneInsert = null;
        //PCC�L�����y�[���i�ڐݒ�f�[�^�f�B�N�V���i���[
        Dictionary<string, Dictionary<string, PccCpItmSt>> _pccCpItmStDicDic = null;
        Dictionary<string, PccCpItmSt> _pccCpItmStDicClone = null;
        Dictionary<string, PccCpItmSt> _pccCpItmStDicCloneInsert = null;
        // ���Ӑ�e�[�v��
        private Dictionary<int, PccCmpnySt> _customerHTable;
        // Grid�ύX�t���O
        private bool _customerGridUpdFlg = true;
        private bool _ItemGridUpdFlg = true;
        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ���A�N�Z�X�N���X
        // ���Ӑ���_�C�A���O
        private int _customerCode;
        private string _customerName;
        //�⍇������ƃR�[�h
        private string _inqOriginalEpCd;
        //�⍇�������_�R�[�h
        private string _inqOriginalSecCd;
        //BLCODE�A�N�Z�X�N���X
        private BLGoodsCdAcs _bLGoodsCdAcs;
        private CampaignStAcs _campaignStAcs;
        private CampaignLinkAcs _campaignLinkAcs = null;
        /// <summary>
        /// ��BL�R�[�h
        /// </summary>
        private int _beforeBLGoodsCode = 0;
        //�i��BL�R�[�h���Hashtable
        private Hashtable _bLCodeTable;
        //�ڑ���񂪐ݒ�Hashtable
        private Hashtable _scmEpScCntTable = null;
        //���t�擾���i
        private DateGetAcs _dateGet;
        //SCM�ڑ��ݒ�}�X�^
        private ScmEpCnectAcs _scmEpCnectAcs;
        private ScmEpScCntAcs _scmEpScCntAcs;
        #endregion

        # region ��Consts
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private PccCpMsgSt _pccCpMsgSt;
        private PccCpMsgSt _pccCpMsgStInsert;
        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE = "�폜��";
        private const string CAMPAIGNCODE_TITLE = "�L�����y�[���R�[�h";
        private const string CAMPAIGNNAME_TITLE = "�L�����y�[������";

        private const string PCCMSGDOCCNTS_TITLE = "PCC���b�Z�[�W";

        private const string CAMPAIGNOBJDIV_TITLE = "�L�����y�[���Ώۋ敪";
        private const string APPLYSTADATE_DATE = "�K�p�J�n��";
        private const string APPLYENDDATE_DATE = "�K�p�I����";
        
        // �e�[�u������
        private const string DETAILS_TABLE = "PccCpMsgStRF";  

        // �K�C�h�L�[
        private const string DETAILS_GUID_KEY = "FileHeaderGuid";

        private const string DATEFORMAT = "YYYY/MM/DD";

        // ���Ӑ��Grid�\���p
        private const string MY_SCREEN_CUSTOMER_CODE = "���Ӑ�R�[�h";
        private const string MY_SCREEN_CUSTOMER_NAME = "���Ӑ於";
        private const string MY_SCREEN_ODER = "No.";
        private const string MY_SCREEN_GUID = "MY_SCREEN_GUID";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string MY_INQORIGINALEPCD = "�⍇������ƃR�[�h";
        private const string MY_INQORIGINALSECCD = "�⍇�������_�R�[�h";

        //�i�ڐݒ�Grid�\���p
        private const string BLTIEM_ODER = "No.";
        private const string PCCITEMST_TABLE = "PCCITEMST_TABLE";
        private const string BLGOODSCODE_TITLE = "BL�R�[�h";
        /// <summary>�K�C�h�{�^����</summary>
        private const string BLGUID_TITLE = "GUID";
        private const string BLGOODSNAME_TITLE = "BLNAME";
        private const string BLGOODSQTY_TITLE = "BLCODE";
        private const string BLGRIDNO_TITLE = "GRIDNO";

        private const string BLGOODSCODE_NAME = "BL�R�[�h";
        /// <summary>�K�C�h�{�^����</summary>
        private const string BLGUID_NAME = "";
        private const string BLGOODSNAME_NAME = "�i��";
        private const string BLGOODSQTY_NAME = "����";

        // ��ʃ��C�A�E�g�p�萔
        private const int BUTTON_LOCATION1_X = 6;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 133;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 262;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 8;        // �{�^���ʒuY(����)

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMPCC09060U";
        //private const string PROGRAM_NAME = "PCC�L�����y�[���ݒ�"; //DEL BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PROGRAM_NAME = "BL�߰µ��ް����߰ݕ\���ݒ�";  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        #endregion

        # region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMPCC09060UA());
        }
        # endregion

        # region Properties

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        # endregion

        # region Public Methods

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // �N���A
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                this._detailsTable.Clear();
                //PCC�L�����y�[�����b�Z�[�W�ݒ胊�X�g
                List<PccCpMsgSt> retPccCpMsgStList = null;
                PccCpMsgSt parsePccCpMsgSt = new PccCpMsgSt();
                parsePccCpMsgSt.InqOtherEpCd = this._enterpriseCode;
                parsePccCpMsgSt.InqOtherSecCd = this._loginSectionCode;
                //PCC�L�����y�[���Ώېݒ�
                PccCpTgtSt parsePccCpTgtSt = new PccCpTgtSt();
                parsePccCpTgtSt.InqOtherEpCd = this._enterpriseCode;
                parsePccCpTgtSt.InqOtherSecCd = this._loginSectionCode;
                //PCC�L�����y�[���i�ڐݒ�
                PccCpItmSt parsePccCpItmSt = new PccCpItmSt();
                parsePccCpItmSt.InqOtherEpCd = this._enterpriseCode;
                parsePccCpItmSt.InqOtherSecCd = this._loginSectionCode;
                status = this._pccCpMsgStAcs.Search(out retPccCpMsgStList, out this._pccCpTgtStDicDic, out this._pccCpItmStDicDic, parsePccCpMsgSt, parsePccCpTgtSt,parsePccCpItmSt, 0, ConstantManagement.LogicalMode.GetData01);
                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (retPccCpMsgStList == null || retPccCpMsgStList.Count == 0)
                    {
                        return status;
                    }
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PccCpMsgSt pccCpMsgSt in retPccCpMsgStList)
                        {
                            // GUID
                            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
           
                            if (pccCpMsgSt.LogicalDeleteCode > 1)
                            {
                                continue;
                            }
                            if (this._detailsTable.ContainsKey(guid) == false)
                            {
                                DetailsToDataSet(pccCpMsgSt.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retPccCpMsgStList.Count;
                        
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
				    default:
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        PROGRAM_NAME, 			            // �v���O��������
                        "Search", 					        // ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
                        ERR_READ_MSG, 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._pccCpMsgStAcs, 		// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
                }
            }
            catch (Exception)
            {
                // �T�[�`
                TMsgDisp.Show(
                    this,								  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                    ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text,							  // �v���O��������
                    "Search",							  // ��������
                    TMsgDisp.OPE_GET,					  // �I�y���[�V����
                    ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                    status,								  // �X�e�[�^�X�l
                    this._pccCpMsgStAcs,		  // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,				  // �\������{�^��
                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = LogicalDeletePccCpMsgSt();
            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="commColumn">PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DetailsToDataSet(PccCpMsgSt pccCpMsgSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (pccCpMsgSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
               
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pccCpMsgSt.UpdateDateTimeJpInFormal;
            }

            // �L�����y�[���R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CAMPAIGNCODE_TITLE] = pccCpMsgSt.CampaignCode.ToString().PadLeft(6, '0');

            // �L�����y�[������
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CAMPAIGNNAME_TITLE] = pccCpMsgSt.CampaignName;

            // PCC���b�Z�[�W
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCMSGDOCCNTS_TITLE] = pccCpMsgSt.PccMsgDocCnts;

           // �K�p�J�n��
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][APPLYSTADATE_DATE] = TDateTime.LongDateToString(DATEFORMAT, pccCpMsgSt.ApplyStaDate);
            // �K�p�I����
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][APPLYENDDATE_DATE] = TDateTime.LongDateToString(DATEFORMAT, pccCpMsgSt.ApplyEndDate);
            
            // RC���[�J�[�ʎ擾���̐ݒ�
            string campaignObjDivName = string.Empty;
            if (pccCpMsgSt.CampaignObjDiv == 0)
            {
                campaignObjDivName = "�S���Ӑ�";
            }
            else if (pccCpMsgSt.CampaignObjDiv == 1)
            {
                campaignObjDivName = "�Ώۓ��Ӑ�";
            }

            // �L�����y�[���Ώۋ敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CAMPAIGNOBJDIV_TITLE] = pccCpMsgSt.CampaignObjDiv;

            // GUID
            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = guid;

            // �n�b�V���e�[�u���X�V
            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
            this._detailsTable.Add(guid, pccCpMsgSt);
        }

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�폜����
        /// </summary>
        /// <param name="commColumn">PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�폜���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DeleteFromDataSet(PccCpMsgSt pccCpMsgSt, int index)
        {
            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
            
            // �f�[�^�Z�b�g����s�폜���܂�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // �n�b�V���e�[�u������폜���܂�
            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable = new DataTable(DETAILS_TABLE); // PCC�L�����y�[���ݒ�}�X�^

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(CAMPAIGNCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(CAMPAIGNNAME_TITLE, typeof(string));
            detailsTable.Columns.Add(PCCMSGDOCCNTS_TITLE, typeof(string));
            detailsTable.Columns.Add(CAMPAIGNOBJDIV_TITLE, typeof(string));
            detailsTable.Columns.Add(APPLYSTADATE_DATE, typeof(string));
            detailsTable.Columns.Add(APPLYENDDATE_DATE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(string));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;
            this.tNedit_CampaignCode.SetInt(0);                 // �L�����y�[���R�[�h
            this.tEdit_CampaignName.DataText = string.Empty;                  // �L�����y�[������
            this.tEdit_PccCampaignName.DataText = string.Empty;                  // �L�����y�[������
            this.tEdit_Message.DataText = string.Empty;                  // �L�����y�[������
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;     // �L�����y�[���Ώۋ敪
            this.ApplyStaDate_TDateEdit.Clear();                    // �K�p�J�n��
            this.ApplyEndDate_TDateEdit.Clear();                    // �K�p�I����
            this._customerBindTable.Clear();
            this._itemBindTable.Clear();

            // �{�^��
            this.Renewal_Button.Visible = true;  // �ŐV���{�^��
            this.Delete_Button.Visible  = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible  = true;  // �����{�^��
            this.Ok_Button.Visible      = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                // �V�K
                case INSERT_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;
                    this.uButton_CampaignGuide.Enabled = true;
                    this.tEdit_PccCampaignName.Enabled = true;
                    this.tEdit_Message.Enabled = true;
                    this.CampaignObjDiv_tComboEditor.Enabled = true;
                    this.ApplyStaDate_TDateEdit.Enabled = true;
                    this.ApplyEndDate_TDateEdit.Enabled = true;
                    this.DeleteCustomerRow_Button.Enabled = true;
                    this.CustomerGuid_Button.Enabled = true;

                    this.DeleteBlCodeRow_Button.Enabled = true;
                    this.BlCodeGuid_Button.Enabled = true;
                    //�L�����y�[���ݒ�捞�݃{�^��
                    this.Insert_Button.Enabled = false;
                    // �V�K���[�h
                    this.tNedit_CampaignCode.Enabled = true;
                    this.UGrid_Customer.Enabled = true;
                    this.UGrid_ItmSt.Enabled = true;
                    break;
                // �X�V
                case UPDATE_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;
                    this.uButton_CampaignGuide.Enabled = false;
                    this.tEdit_PccCampaignName.Enabled = true;
                    this.tEdit_Message.Enabled = true;
                    this.CampaignObjDiv_tComboEditor.Enabled = true;
                    this.ApplyStaDate_TDateEdit.Enabled = true;
                    this.ApplyEndDate_TDateEdit.Enabled = true;

                    this.DeleteCustomerRow_Button.Enabled = true;
                    this.CustomerGuid_Button.Enabled = true;

                    this.DeleteBlCodeRow_Button.Enabled = true;
                    this.BlCodeGuid_Button.Enabled = true;
                    //�L�����y�[���ݒ�捞�݃{�^��
                    this.Insert_Button.Enabled = true;
                    // �X�V���[�h
                    this.tNedit_CampaignCode.Enabled = false;
                    this.UGrid_Customer.Enabled = true;
                    this.UGrid_ItmSt.Enabled = true;
                    break;
                // �폜
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.uButton_CampaignGuide.Enabled = false;
                    this.tEdit_PccCampaignName.Enabled = false;
                    this.tEdit_Message.Enabled = false;
                    this.CampaignObjDiv_tComboEditor.Enabled = false;
                    this.ApplyStaDate_TDateEdit.Enabled = false;
                    this.ApplyEndDate_TDateEdit.Enabled = false;

                    this.DeleteCustomerRow_Button.Enabled = false;
                    this.CustomerGuid_Button.Enabled = false;

                    this.DeleteBlCodeRow_Button.Enabled = false;
                    this.BlCodeGuid_Button.Enabled = false;
                    this.tNedit_CampaignCode.Enabled = false;
                    this.UGrid_Customer.Enabled = false;
                    this.UGrid_ItmSt.Enabled = false;
                    //�L�����y�[���ݒ�捞�݃{�^��
                    this.Insert_Button.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // �N���[���쐬
                this._pccCpMsgSt = pccCpMsgSt.Clone();
                this._pccCpTgtStDicClone = null;
                this._pccCpItmStDicClone = null;
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                ScreenClear();
                DispToPccCpMsgSt(ref this._pccCpMsgSt, out this._pccCpTgtStDicClone, out this._pccCpItmStDicClone);
                this._pccCpMsgStInsert = this._pccCpMsgSt;
                this._pccCpTgtStDicCloneInsert = this._pccCpTgtStDicClone;
                this._pccCpItmStDicCloneInsert = this._pccCpItmStDicClone;
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);
               
                this.DeleteCustomerRow_Button.Enabled = false;
                this.CustomerGuid_Button.Enabled = false;
                
                this.ItemGrid_AddRow();
                this.UGrid_ItmSt.Rows[0].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                // �t�H�[�J�X�ݒ�
                this.tNedit_CampaignCode.Focus();
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // �폜���[�h
                this.Mode_Label.Text = DELETE_MODE;

                // �\�����擾
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCpMsgSt = (PccCpMsgSt)this._detailsTable[guid];
                
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(DELETE_MODE);

                // �t�H�[�J�X�ݒ�
                this.Delete_Button.Focus();

                // ��ʓW�J����
                PccCpMsgStToScreen(pccCpMsgSt);
            }
            // �X�V�̏ꍇ
            else
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;

                // �\�����擾
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCpMsgSt = (PccCpMsgSt)this._detailsTable[guid];
                
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(UPDATE_MODE);

                // ��ʓW�J����
                PccCpMsgStToScreen(pccCpMsgSt);
                if (pccCpMsgSt.CampaignObjDiv == 1)
                {
                    this.CustomerGrid_AddRow();
                    this.DeleteCustomerRow_Button.Enabled = true;
                    this.CustomerGuid_Button.Enabled = true;
                }
                else
                {
                    this.DeleteCustomerRow_Button.Enabled = false;
                    this.CustomerGuid_Button.Enabled = false;
                }
                this.ItemGrid_AddRow();
                this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count -1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                // �N���[���쐬
                this._pccCpMsgSt = pccCpMsgSt.Clone();
                
                DispToPccCpMsgSt(ref this._pccCpMsgSt, out this._pccCpTgtStDicClone, out this._pccCpItmStDicClone);
                this._pccCpMsgStInsert = this._pccCpMsgSt;
                this._pccCpTgtStDicCloneInsert = this._pccCpTgtStDicClone;
                this._pccCpItmStDicCloneInsert = this._pccCpItmStDicClone;
                // �t�H�[�J�X�ݒ�
                this.tEdit_PccCampaignName.Focus();
            }

            //_GridIndex�o�b�t�@�ێ�
            this._detailsIndexBuf = this._dataIndex;
        }

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="commColumn">PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PccCpMsgStToScreen(PccCpMsgSt pccCpMsgSt)
        {
            this.tNedit_CampaignCode.SetInt(pccCpMsgSt.CampaignCode);
            this.tEdit_PccCampaignName.Text = pccCpMsgSt.CampaignName;
            // �L�����y�[�����̂̎擾
            CampaignSt campaignSt = null;
            // �L�����y�[�����̂̎擾
            campaignSt = this._pccCpMsgStAcs.GetCampaignSt(pccCpMsgSt.CampaignCode);
            if (campaignSt != null)
            {
                this.tEdit_CampaignName.Text = campaignSt.CampaignName;
            }
            this.tEdit_Message.Text = pccCpMsgSt.PccMsgDocCnts;
            this.CampaignObjDiv_tComboEditor.Value = pccCpMsgSt.CampaignObjDiv;
            this.ApplyStaDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyStaDate);
            this.ApplyEndDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyEndDate);

            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd()
                + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
            if (pccCpMsgSt.CampaignObjDiv == 1)
            {
                //PCC�L�����y�[���Ώېݒ胊�X�g�擾
                Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
                this._customerBindTable.Clear();
            
                GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);
                if (pccCpTgtStDic != null)
                {
                    List<PccCpTgtSt> pccCpTgtStList = new List<PccCpTgtSt>(pccCpTgtStDic.Values);

                    InitCustomerGridDate(pccCpTgtStList);
                }
            }
            //PCC�L�����y�[���i�ڐݒ胊�X�g�擾
            List<PccCpItmSt> pccCpItmStList = null;
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            this._itemBindTable.Clear();
            
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            if (pccCpItmStDic != null)
            {
                pccCpItmStList = new List<PccCpItmSt>(pccCpItmStDic.Values);
                InitItemGridDate(pccCpItmStList);
            }
        }

        /// <summary>
        /// ���Ӑ�O���b�h��ʓW�J����
        /// </summary>
        /// <param name="pccCpTgtStList"PCC�L�����y�[���i�ڐݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void InitCustomerGridDate(List<PccCpTgtSt> pccCpTgtStList)
        {
           DataRow bindRow;
           PccCpTgtSt pccCpTgtSt = null;
           this._customerBindTable.Clear();
           for (int i = 0; i < pccCpTgtStList.Count; i++)
           {
                pccCpTgtSt = pccCpTgtStList[i];
                bindRow = this._customerBindTable.NewRow();
                bindRow[MY_SCREEN_ODER] = this._customerBindTable.Rows.Count + 1;
                if (pccCpTgtSt.CustomerCode == 0)
                {
                    continue;
                }
                bindRow[MY_SCREEN_CUSTOMER_CODE] = pccCpTgtSt.CustomerCode;
                bindRow[MY_SCREEN_CUSTOMER_NAME] = pccCpTgtSt.CustomerName;
                bindRow[MY_INQORIGINALEPCD] = pccCpTgtSt.InqOriginalEpCd.Trim();//@@@@20230303
                bindRow[MY_INQORIGINALSECCD] = pccCpTgtSt.InqOriginalSecCd;
                this._customerBindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// �i�ڃO���b�h��ʓW�J�����O���b�h��ʓW�J����
        /// </summary>
        /// <param name="pccCpItmStList">PCC�L�����y�[���i�ڐݒ胊�X�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void InitItemGridDate(List<PccCpItmSt> pccCpItmStList)
        {
            DataRow bindRow;
            PccCpItmSt pccCpItmSt = null;
            this._itemBindTable.Clear();
            for (int i = 0; i < pccCpItmStList.Count; i++)
            {
                pccCpItmSt = pccCpItmStList[i];
                bindRow = this._itemBindTable.NewRow();
                bindRow[BLTIEM_ODER] = this._itemBindTable.Rows.Count + 1;
                bindRow[BLGOODSCODE_TITLE] = pccCpItmSt.BLGoodsCode;
                bindRow[BLGOODSNAME_TITLE] = pccCpItmSt.GoodsNameKana;
                if (pccCpItmSt.ItemQty == 0)
                {
                    bindRow[BLGOODSQTY_TITLE] = 1;
                }
                else
                {
                    bindRow[BLGOODSQTY_TITLE] = pccCpItmSt.ItemQty;
                }
                
                bindRow[BLGRIDNO_TITLE] = 0;
                this._itemBindTable.Rows.Add(bindRow);
                if (pccCpItmSt.BLGoodsCode == 0)
                {
                    this.UGrid_ItmSt.Rows[i].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                }
                else
                {
                    this.UGrid_ItmSt.Rows[i].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                }
            }
        }

        /// <summary>
        /// Value�`�F�b�N�����istring�j
        /// </summary>
        /// <param name="sorce">tCombo��Value</param>
        /// <returns>�`�F�b�N��̒l</returns>
        /// <remarks>
        /// <br>Note		: tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private string ValueToString(object sorce)
        {
            string dest = null;
            try
            {
                dest = Convert.ToString(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// Value�`�F�b�N�����idouble�j
        /// </summary>
        /// <param name="sorce">tCombo��Value</param>
        /// <returns>�`�F�b�N��̒l</returns>
        /// <remarks>
        /// <br>Note		: tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private double ValueToDouble(object sorce)
        {
            double dest = 0;
            try
            {
                dest = Convert.ToDouble(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// Value�`�F�b�N�����iint�j
        /// </summary>
        /// <param name="sorce">tCombo��Value</param>
        /// <returns>�`�F�b�N��̒l</returns>
        /// <remarks>
        /// <br>Note		: tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// BLCode���擾
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <remarks>
        /// <returns>BLCode���</returns>
        /// <br>Note       : LCode�����擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private BLGoodsCdUMnt GetBLGoodsCdUMnt(int blCode)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = null;
            if (_bLCodeTable != null && _bLCodeTable.ContainsKey(blCode))
            {
                bLGoodsCdUMnt = _bLCodeTable[blCode] as BLGoodsCdUMnt;
            }
            return bLGoodsCdUMnt;
        }

        /// <summary>
        /// BLCode���i���̃J�i���擾
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <remarks>
        /// <returns>���i���̃J�i</returns>
        /// <br>Note       : BLCode���i���̃J�i�����擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private string GetBLGoodsName(int blCode)
        {
            string goodsName = string.Empty;
            BLGoodsCdUMnt bLGoodsCdUMnt = GetBLGoodsCdUMnt(blCode);
            if (bLGoodsCdUMnt != null )
            {
                goodsName = bLGoodsCdUMnt.BLGoodsHalfName;
            }
            return goodsName;
        }

        /// <summary>
        /// ��ʏ��PCC�L�����y�[���ݒ�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="pccCpMsgSt">PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="pccCpTgtStDic">���Ӑ�O���b�h�f�[�^</param>
        /// <param name="pccCpItmStDic">BL�R�[�h�O���b�h�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂畔��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DispToPccCpMsgSt(ref PccCpMsgSt pccCpMsgSt, out Dictionary<string, PccCpTgtSt> pccCpTgtStDic,
            out Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            //��ʂ̓��Ӑ�O���b�h�f�[�^���i�[
            pccCpTgtStDic = null;
            //��ʂ�BL�R�[�h�O���b�h�f�[�^���i�[
            pccCpItmStDic = null;
            DispayToPccCpMsgSt(ref pccCpMsgSt);
            if (pccCpMsgSt.CampaignObjDiv == 1)
            {
                CustomerGridToTgtst(pccCpMsgSt, out pccCpTgtStDic);
            }
            else
            {
                GetPccCpTgtStDicFromCmpnySt(out pccCpTgtStDic);
            }
            ItemGridToTgtst(pccCpMsgSt, out pccCpItmStDic);
        }

        /// <summary>
        /// ��ʏ��PCC�L�����y�[���}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="pccCpMsgSt">PCC�L�����y�[���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ��PCC�L�����y�[���}�X�^�N���X���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DispayToPccCpMsgSt(ref PccCpMsgSt pccCpMsgSt)
        {
            if (pccCpMsgSt == null)
            {
                pccCpMsgSt = new PccCpMsgSt();
            }
            pccCpMsgSt.InqOtherEpCd = this._enterpriseCode;
            pccCpMsgSt.InqOtherSecCd = this._loginSectionCode;
            pccCpMsgSt.CampaignCode = this.tNedit_CampaignCode.GetInt();
            pccCpMsgSt.CampaignName = this.tEdit_PccCampaignName.DataText.TrimEnd();
            pccCpMsgSt.PccMsgDocCnts = this.tEdit_Message.DataText.TrimEnd();
            pccCpMsgSt.CampaignObjDiv = (int)CampaignObjDiv_tComboEditor.Value;
            pccCpMsgSt.ApplyStaDate = ApplyStaDate_TDateEdit.GetLongDate();
            pccCpMsgSt.ApplyEndDate = ApplyEndDate_TDateEdit.GetLongDate();
        }

        /// <summary>
        /// ��ʏ�񓾈Ӑ�O���b�h�i�[����
        /// </summary>
        /// <param name="pccCpMsgSt">PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="pccCpTgtStDic">���Ӑ�O���b�h�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񓾈Ӑ�O���b�h���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGridToTgtst(PccCpMsgSt pccCpMsgSt, out Dictionary<string, PccCpTgtSt> pccCpTgtStDic)
        {
            pccCpTgtStDic = null;
            if (this.UGrid_Customer != null && this.UGrid_Customer.Rows.Count > 0)
            {
                pccCpTgtStDic = new Dictionary<string, PccCpTgtSt>();
                for (int i = 0; i < this.UGrid_Customer.Rows.Count; i++)
                {
                    UltraGridRow ultraGridEach = this.UGrid_Customer.Rows[i];
                    PccCpTgtSt pccCpTgtSt = new PccCpTgtSt();
                    pccCpTgtSt.InqOtherEpCd = pccCpMsgSt.InqOtherEpCd;
                    pccCpTgtSt.InqOtherSecCd = pccCpMsgSt.InqOtherSecCd;
                    if (ultraGridEach.Cells[MY_SCREEN_CUSTOMER_CODE].Value == DBNull.Value)
                    {
                        continue;
                    }
                    //�⍇������ƃR�[�h
                    pccCpTgtSt.InqOriginalEpCd = ((string)ultraGridEach.Cells[MY_INQORIGINALEPCD].Value).Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    pccCpTgtSt.InqOriginalSecCd = (string)ultraGridEach.Cells[MY_INQORIGINALSECCD].Value;
                    //�L�����y�[���R�[�h
                    pccCpTgtSt.CampaignCode = pccCpMsgSt.CampaignCode;
                    //���Ӑ�R�[�h
                    pccCpTgtSt.CustomerCode = (int)ultraGridEach.Cells[MY_SCREEN_CUSTOMER_CODE].Value;
                    pccCpTgtSt.CustomerName = (string)ultraGridEach.Cells[MY_SCREEN_CUSTOMER_NAME].Value;
                    string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6,' ') + pccCpTgtSt.InqOriginalEpCd.Trim() + pccCpTgtSt.InqOriginalSecCd.TrimEnd();//@@@@20230303
                    //���Аݒ�}�X�^�ɓ��Ӑ摶�݂��Ȃ��ꍇ�A�폜���܂��B
                    if (this._customerHTable != null && this._customerHTable.Count > 0)
                    {
                        if (this._customerHTable.ContainsKey(pccCpTgtSt.CustomerCode))
                        {
                            if (!pccCpTgtStDic.ContainsKey(guid))
                            {
                                pccCpTgtStDic.Add(guid, pccCpTgtSt);
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// ��ʏ��BLCODE�O���b�h�i�[����
        /// </summary>
        /// <param name="pccCpMsgSt">PCC�L�����y�[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="pccCpTgtStDic">BLCODE�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʏ��BLCODE�O���b�h���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ItemGridToTgtst(PccCpMsgSt pccCpMsgSt, out Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            pccCpItmStDic = null;
            if (this.UGrid_ItmSt != null && this.UGrid_ItmSt.Rows.Count > 0)
            {
                pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
                for (int i = 0; i < this.UGrid_ItmSt.Rows.Count; i++)
                {
                    UltraGridRow ultraGridRow = this.UGrid_ItmSt.Rows[i];
                    PccCpItmSt pccCpItmSt = new PccCpItmSt();
                    pccCpItmSt.InqOtherEpCd = pccCpMsgSt.InqOtherEpCd;
                    pccCpItmSt.InqOtherSecCd = pccCpMsgSt.InqOtherSecCd;
                     //�L�����y�[���R�[�h
                    pccCpItmSt.CampaignCode = pccCpMsgSt.CampaignCode;
                    //�L�����y�[���ݒ�敪 0:BL�R�[�h
                    pccCpItmSt.CampStDiv = 0;
                    if (ultraGridRow.Cells[BLGOODSCODE_TITLE].Value == DBNull.Value)
                    {
                        continue;
                    }
                    pccCpItmSt.BLGoodsCode = (int)ultraGridRow.Cells[BLGOODSCODE_TITLE].Value;
                    pccCpItmSt.GoodsNameKana = (string)ultraGridRow.Cells[BLGOODSNAME_TITLE].Value;
                    if (ultraGridRow.Cells[BLGOODSQTY_TITLE].Value == DBNull.Value || (int)ultraGridRow.Cells[BLGOODSQTY_TITLE].Value == 0)
                    {
                        pccCpItmSt.ItemQty = 1;
                    }
                    else
                    {
                        pccCpItmSt.ItemQty = (int)ultraGridRow.Cells[BLGOODSQTY_TITLE].Value;
                    }
                    BLGoodsCdUMnt bLGoodsCdUMnt = GetBLGoodsCdUMnt(pccCpItmSt.BLGoodsCode);
                    //���i�ԍ�
                    pccCpItmSt.GoodsNo = "0";
                    //���i���[�J�[�R�[�h
                    pccCpItmSt.GoodsMakerCd = 0;
                    //���i���̃J�i
                    if (bLGoodsCdUMnt != null)
                    {
                        //pccCpItmSt.GoodsName = bLGoodsCdUMnt.BLGoodsName; //delete by lingxiaoqing on 2011.10.11 for #Redmine25789
                        pccCpItmSt.GoodsName = bLGoodsCdUMnt.BLGoodsFullName;//add by lingxiaoqing on 2011.10.11 for #Redmine25789
                        pccCpItmSt.GoodsNameKana = bLGoodsCdUMnt.BLGoodsHalfName;//add by lingxiaoqing on 2011.10.11 for #Redmine25789
                    }
                    string guid = pccCpItmSt.InqOtherEpCd.TrimEnd() + pccCpItmSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ')+ pccCpItmSt.CampStDiv.ToString().PadRight(2, ' ') +
                        pccCpItmSt.BLGoodsCode.ToString().PadRight(8, ' ') + pccCpItmSt.GoodsNo.PadRight(40, ' ')
                        + pccCpItmSt.GoodsMakerCd.ToString().PadRight(4, ' ');
                    if (!pccCpItmStDic.ContainsKey(guid))
                    {
                        pccCpItmStDic.Add(guid, pccCpItmSt);
                    }
                }
            }
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
            message = string.Empty;
            // PCC�L�����y�[���ݒ�}�X�^�R�[�h
            if (this.tNedit_CampaignCode.GetInt() == 0)
            {
                control = this.tNedit_CampaignCode;
                message = "�L�����y�[���R�[�h����͂��ĉ������B";
                result = false;
                return result;
            }
            result = ScreenInputDateCheck(out message, ref control);
            if (!result)
            {
                return result;
            }
            if ((int)CampaignObjDiv_tComboEditor.Value == 1)
            {
                if (this.UGrid_Customer == null || this.UGrid_Customer.Rows.Count == 0)
                {
                    control = this.UGrid_Customer;
                    message = "���Ӑ�R�[�h���P���ȏ�o�^���ĉ������B";
                    return false;
                }
                else
                {
                    int code = 0;
                    int count = 0;
                    for (int i = 0; i < this.UGrid_Customer.Rows.Count; i++)
                    {
                        if (this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value != DBNull.Value)
                        {
                            code = (int)this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value;
                        }
                        if (code != 0)
                        {
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        control = this.UGrid_Customer;
                        message = "���Ӑ�R�[�h���o�^����Ă��܂���B";
                        return false;
                    }
                }
            }

            if (this.UGrid_ItmSt == null || this.UGrid_ItmSt.Rows.Count == 0)
            {
                control = this.UGrid_Customer;
                message = "BLCODE�R�[�h���P���ȏ�o�^���ĉ������B";
                return false;
            }
            else
            {
                int count = 0;
                int code = 0;
                for (int i = 0; i < this.UGrid_ItmSt.Rows.Count; i++)
                {
                    if (this.UGrid_ItmSt.Rows[i].Cells[BLGOODSCODE_TITLE].Value != DBNull.Value)
                    {
                        count = (int)this.UGrid_ItmSt.Rows[i].Cells[BLGOODSCODE_TITLE].Value;
                    }
                    if (code != 0)
                    {
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    control = this.UGrid_ItmSt;
                    message = "BL�R�[�h���o�^����Ă��܂���B";
                    return false;
                }
            }
            if ((int)CampaignObjDiv_tComboEditor.Value == 1 && this.UGrid_Customer != null && this.UGrid_Customer.Rows.Count > 0)
            {

                //�ڑ���񂪐ݒ�`�F�b�N
                int customerCode = 0;
                string inqOriginalEpCd = string.Empty;
                string inqOriginalSecCd = string.Empty;
                string guidKey = string.Empty;
                string customerMess = string.Empty;
                for (int i = 0; i < this.UGrid_Customer.Rows.Count; i++)
                {
                    customerCode = 0;
                    if (this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value != DBNull.Value)
                    {
                        customerCode = (int)this.UGrid_Customer.Rows[i].Cells[MY_SCREEN_CUSTOMER_CODE].Value;
                        //�⍇������ƃR�[�h
                        inqOriginalEpCd = ((string)this.UGrid_Customer.Rows[i].Cells[MY_INQORIGINALEPCD].Value).Trim();	//@@@@20230303
                        //�⍇�������_�R�[�h
                        inqOriginalSecCd = (string)this.UGrid_Customer.Rows[i].Cells[MY_INQORIGINALSECCD].Value;
                        guidKey = inqOriginalEpCd.Trim() + inqOriginalSecCd.TrimEnd() + this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd();//@@@@20230303
                    }
                    if (customerCode != 0)
                    {
                        if (this._scmEpScCntTable != null && this._scmEpScCntTable.Count > 0 && this._scmEpScCntTable.ContainsKey(guidKey))
                        {
                            continue;
                        }
                        else
                        {
                            customerMess = customerMess + customerCode.ToString("D8") + "\r\n";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(customerMess))
                {
                    control = this.UGrid_Customer;
                    message = "�ڑ���񂪐ݒ肳��Ă��Ȃ����߂��̓��Ӑ�͐ݒ�ł��܂���B" + "\r\n" +customerMess;
                    return false;
                }
            }
            return result;
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ScreenInputDateCheck(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;
            //�G���[�������b�Z�[�W
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            const string ct_InputPlease = "����͂��Ă��������B";
            //���Y���t�͈̓`�F�b�N
            DateGetAcs.CheckDateRangeResult cdrResult;

            if (CallCheckDateRange(out cdrResult, ref ApplyStaDate_TDateEdit, ref ApplyEndDate_TDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n��{0}", ct_InputError);
                            errControl = this.ApplyStaDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("�J�n��{0}", ct_InputPlease);
                            errControl = this.ApplyStaDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I����{0}", ct_InputError);
                            errControl = this.ApplyEndDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("�I����{0}", ct_InputPlease);
                            errControl = this.ApplyEndDate_TDateEdit;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("���t{0}", ct_RangeError);
                            errControl = this.ApplyEndDate_TDateEdit;
                            result = false;
                        }
                        break;
                }
                return result;
            }
            return true;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo���i�����͑ΏۊO�j
        /// </summary>
        /// <param name="cdrResult">���t�`�F�b�N����</param>
        /// <param name="tde_St_Date">���t�J�n</param>
        /// <param name="tde_Ed_Date">���t�I��</param>
        /// <returns>���t�`�F�b�N����</returns>
        ///<remarks>
        /// <br>Note       : ���t�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_Date, ref TDateEdit tde_Ed_Date)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_Date, ref tde_Ed_Date, false);

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
       
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="saveTarget">�ۑ��}�X�^ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : PCC�L�����y�[���ݒ�}�X�^�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            // PCC�L�����y�[���ݒ�}�X�^�X�V
            if (!SavePccCpMsgSt())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^�e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : PccCpMsgSt�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool SavePccCpMsgSt()
        {
            Control control = null;
            PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();

            // �o�^���R�[�h���擾
            string guid = string.Empty;
            if (this._detailsIndexBuf >= 0)
            {
                guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            }
            else
            {
                guid = this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd() + this.tNedit_CampaignCode.GetInt().ToString().PadRight(6, ' ');
                pccCpMsgSt.InqOtherEpCd = this._enterpriseCode;
                pccCpMsgSt.InqOtherSecCd = this._loginSectionCode;
            }
            List<PccCpMsgSt> pccCpMsgStListNew;
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic;
            //PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[
            Dictionary<string, PccCpItmSt> pccCpItmStDic;
            GetWriteLists(ref pccCpMsgSt, out pccCpMsgStListNew, out pccCpTgtStDic, out pccCpItmStDic);
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            status = this._pccCpMsgStAcs.Write(ref pccCpMsgStListNew, ref pccCpTgtStDic, ref pccCpItmStDic);

            // �G���[����
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash�X�V����
                    DetailsToDataSet(pccCpMsgStListNew[0], this._detailsIndexBuf);
                    //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.Count > 0)
                    {
                        if (this._pccCpTgtStDicDic.ContainsKey(guid))
                        {
                            this._pccCpTgtStDicDic.Remove(guid);
                        }
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }
                    else
                    {
                        this._pccCpTgtStDicDic = new Dictionary<string, Dictionary<string, PccCpTgtSt>>();
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }
                    //PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.Count > 0)
                    {
                        if (this._pccCpItmStDicDic.ContainsKey(guid))
                        {
                            this._pccCpItmStDicDic.Remove(guid);
                        }
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    else
                    {
                        this._pccCpItmStDicDic = new Dictionary<string, Dictionary<string, PccCpItmSt>>();
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �d������
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCpMsgStAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();
                    return false;
                default:
                    // �o�^���s
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "SavePccCpMsgSt",			// ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCpMsgStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return false;
            }

            // �V�K�o�^������
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// ��ʃL�����y�[�����ڂ̊i�[����
        /// </summary>
        /// <param name="pccCpMsgSt">�L�����y�[���}�X�^</param>
        /// <param name="pccCpMsgStListNew">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStDic">PCC�L�����y�[���Ώېݒ�f�[�^�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       :  ��ʃL�����y�[�����ڂ��i�[�������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetWriteLists(ref PccCpMsgSt pccCpMsgSt, out List<PccCpMsgSt> pccCpMsgStListNew,
            out Dictionary<string, PccCpTgtSt> pccCpTgtStDic, out Dictionary<string, PccCpItmSt> pccCpItmStDic)
        {
            // PccCpMsgSt�N���X���A�N�Z�X�N���X�ɓn���ēo�^�E�X�V
            //PCC�L�����y�[���Ώېݒ胊�X�g�擾
            string guid = pccCpMsgSt.InqOtherEpCd.TrimEnd() + pccCpMsgSt.InqOtherSecCd.TrimEnd() + pccCpMsgSt.CampaignCode.ToString().PadRight(6, ' ');
           
            Dictionary<string, PccCpTgtSt> pccCpTgtStDicOld = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDicOld, guid);

            //PCC�L�����y�[���i�ڐݒ胊�X�g�擾
            Dictionary<string, PccCpItmSt> pccCpItmStDicOld = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDicOld, guid);

            //��ʂ̓��Ӑ�O���b�h�f�[�^���i�[
            pccCpTgtStDic = null;
            //��ʂ�BL�R�[�h�O���b�h�f�[�^���i�[
            pccCpItmStDic = null;
            DispToPccCpMsgSt(ref pccCpMsgSt, out pccCpTgtStDic, out pccCpItmStDic);

            pccCpMsgStListNew = new List<PccCpMsgSt>();
            // PccCpMsgSt�N���X�Ƀf�[�^���i�[
            pccCpMsgStListNew.Add(pccCpMsgSt);

           
           //�V����PCC�L�����y�[���Ώېݒ胊�X�g�擾
            if (pccCpTgtStDicOld != null && pccCpTgtStDicOld.Count > 0)
            {
                foreach(KeyValuePair<string, PccCpTgtSt> pccCpTgtStPair in pccCpTgtStDicOld)
                {
                    PccCpTgtSt pccCpTgtStOld = pccCpTgtStPair.Value;
                    if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0)
                    {
                        if (pccCpTgtStDic.ContainsKey(pccCpTgtStPair.Key))
                        {
                            PccCpTgtSt pccCpTgtStNew = pccCpTgtStDic[pccCpTgtStPair.Key];
                            pccCpTgtStNew.CreateDateTime = pccCpTgtStOld.UpdateDateTime;
                            pccCpTgtStNew.UpdateDateTime = pccCpTgtStOld.UpdateDateTime;
                            pccCpTgtStNew.LogicalDeleteCode = pccCpTgtStOld.LogicalDeleteCode;
                            //�X�V�敪= 1:�X�V
                            pccCpTgtStNew.UpdateFlag = pccCpTgtStOld.UpdateFlag;
                            pccCpTgtStDic.Remove(pccCpTgtStPair.Key);
                            pccCpTgtStDic.Add(pccCpTgtStPair.Key, pccCpTgtStNew);
                        }
                        else
                        {
                            PccCpTgtSt pccCpTgtStNew = pccCpTgtStOld;
                            //�X�V�敪= 2:�폜
                            pccCpTgtStNew.UpdateFlag = 2;
                            pccCpTgtStDic.Add(pccCpTgtStPair.Key, pccCpTgtStNew);
                        }
                    }
                    else
                    {
                        pccCpTgtStDic = new Dictionary<string, PccCpTgtSt>();
                        PccCpTgtSt pccCpTgtStNew = pccCpTgtStOld;
                        //�X�V�敪= 2:�폜
                        pccCpTgtStNew.UpdateFlag = 2;
                        pccCpTgtStDic.Add(pccCpTgtStPair.Key, pccCpTgtStNew);
                    }

                }
            }
            

            //�V����PCC�L�����y�[���i�ڐݒ胊�X�g�擾
            if (pccCpItmStDicOld != null && pccCpItmStDicOld.Count > 0)
            {
                foreach (KeyValuePair<string, PccCpItmSt> pccCpItmStPair in pccCpItmStDicOld)
                {
                    PccCpItmSt pccCpItmStOld = pccCpItmStPair.Value;
                    if (pccCpItmStDic != null && pccCpItmStDic.Count > 0)
                    {
                        if (pccCpItmStDic.ContainsKey(pccCpItmStPair.Key))
                        {
                            PccCpItmSt pccCpItmStNew = pccCpItmStDic[pccCpItmStPair.Key];
                            pccCpItmStNew.CreateDateTime = pccCpItmStOld.UpdateDateTime;
                            pccCpItmStNew.UpdateDateTime = pccCpItmStOld.UpdateDateTime;
                            pccCpItmStNew.LogicalDeleteCode = pccCpItmStOld.LogicalDeleteCode;
                            pccCpItmStNew.GoodsName = pccCpItmStOld.GoodsName;
                            pccCpItmStNew.GoodsNo = pccCpItmStOld.GoodsNo;
                            pccCpItmStNew.GoodsMakerCd = pccCpItmStOld.GoodsMakerCd;
                            pccCpItmStNew.CampStDiv = pccCpItmStOld.CampStDiv;
                            //�X�V�敪= 1:�X�V
                            pccCpItmStNew.UpdateFlag = pccCpItmStOld.UpdateFlag;
                            pccCpItmStDic.Remove(pccCpItmStPair.Key);
                            pccCpItmStDic.Add(pccCpItmStPair.Key, pccCpItmStNew);
                        }
                        else
                        {
                            PccCpItmSt pccCpItmStNew = pccCpItmStOld;
                            //�X�V�敪= 2:�폜
                            pccCpItmStNew.UpdateFlag = 2;
                            pccCpItmStDic.Add(pccCpItmStPair.Key, pccCpItmStNew);
                        }
                    }
                    else
                    {
                        pccCpItmStDic = new Dictionary<string, PccCpItmSt>();
                        PccCpItmSt pccCpItmStNew = pccCpItmStOld;
                        //�X�V�敪= 2:�폜
                        pccCpItmStNew.UpdateFlag = 2;
                        pccCpItmStDic.Add(pccCpItmStPair.Key, pccCpItmStNew);
                    }

                }
            }
           
            
        }

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^ �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int LogicalDeletePccCpMsgSt()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �폜�Ώ�PCC�L�����y�[���ݒ�}�X�^�擾
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCpMsgSt pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            //PCC�L�����y�[�����b�Z�[�W�ݒ胊�X�g�擾
            List<PccCpMsgSt> pccCpMsgStList = new List<PccCpMsgSt>();
            pccCpMsgStList.Add(pccCpMsgSt);
            //PCC�L�����y�[���Ώېݒ�f�B�N�V���i���[�擾
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);

            //PCC�L�����y�[���i�ڐݒ�f�B�N�V���i���[�擾
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            status = this._pccCpMsgStAcs.LogicalDelete(ref pccCpMsgStList, ref pccCpTgtStDic, ref pccCpItmStDic);
            pccCpMsgSt = pccCpMsgStList[0] as PccCpMsgSt;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DetailsToDataSet(pccCpMsgSt, _dataIndex);
                    //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.Count > 0)
                    {
                        if (this._pccCpTgtStDicDic.ContainsKey(guid))
                        {
                            this._pccCpTgtStDicDic.Remove(guid);
                        }
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }

                    //PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.Count > 0)
                    {
                        if (this._pccCpItmStDicDic.ContainsKey(guid))
                        {
                            this._pccCpItmStDicDic.Remove(guid);
                        }
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    Initial_Timer.Enabled = true;
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pccCpMsgStAcs);
                    // �t���[���X�V
                    DetailsToDataSet(pccCpMsgStList[0], _dataIndex);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "LogicalDeletesharedPartsAddInfo",	// ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCpMsgStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // �t���[���X�V
                    DetailsToDataSet(pccCpMsgSt, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ胊�X�g�擾����
        /// </summary>
        /// <param name="pccCpTgtStDic">PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="guid">PCC�L�����y�[�����b�Z�[�W�ݒ�KEY</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetPccCpTgtStDicFromGuid(out  Dictionary<string, PccCpTgtSt> pccCpTgtStDic, string guid)
        {
             pccCpTgtStDic = null;
            if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.ContainsKey(guid))
            {
                pccCpTgtStDic = this._pccCpTgtStDicDic[guid];
            }
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ胊�X�g�擾����
        /// </summary>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^�f�B�N�V���i���[</param>
        /// <param name="guid">PCC�L�����y�[�����b�Z�[�W�ݒ�KEY</param>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetPccCpItmStDicFromGuid(out   Dictionary<string, PccCpItmSt> pccCpItmStDic, string guid)
        {
            pccCpItmStDic = null;
            if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.ContainsKey(guid))
            {
                pccCpItmStDic = this._pccCpItmStDicDic[guid];
               
            }
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ胊�X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���Ώېݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void GetPccCpTgtStDicFromCmpnySt(out   Dictionary<string, PccCpTgtSt> pccCpTgtStDic)
        {
            pccCpTgtStDic = null;
            if (this._customerHTable == null)
            {
                this._pccCpMsgStAcs.GetCustomerHTable();
                this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            }
            else
            {
                if (this._customerHTable != null && this._customerHTable.Count > 0)
                {
                    pccCpTgtStDic = new Dictionary<string, PccCpTgtSt>();
                    foreach (KeyValuePair<int, PccCmpnySt> keyValuePair in this._customerHTable)
                    {
                        PccCpTgtSt pccCpTgtSt = new PccCpTgtSt();
                        PccCmpnySt pccCmpnyStPair = keyValuePair.Value;

                        // --- ADD 2012/10/11 �O�� 2012/11/14�z�M�� SCM��Q��10298 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        if (pccCmpnyStPair.PccCompanyCode == 0) continue;�@//PCC���Аݒ�̃x�[�X�͖�������
                        // --- ADD 2012/10/11 �O�� 2012/11/14�z�M�� SCM��Q��10298 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        string guidKey = this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd()
                            + this.tNedit_CampaignCode.GetInt().ToString().PadRight(6, ' ')
                            + pccCmpnyStPair.InqOriginalEpCd.Trim() //@@@@20230303
                            + pccCmpnyStPair.InqOriginalSecCd.TrimEnd();
                        //�⍇������ƃR�[�h
                        pccCpTgtSt.InqOriginalEpCd = pccCmpnyStPair.InqOriginalEpCd.Trim();//@@@@20230303
                        //�⍇�������_�R�[�h
                        pccCpTgtSt.InqOriginalSecCd = pccCmpnyStPair.InqOriginalSecCd;
                        pccCpTgtSt.InqOtherEpCd = this._enterpriseCode;
                        pccCpTgtSt.InqOtherSecCd = this._loginSectionCode;
                        //�L�����y�[���R�[�h
                        pccCpTgtSt.CampaignCode = this.tNedit_CampaignCode.GetInt();
                        pccCpTgtStDic.Add(guidKey, pccCpTgtSt);
                    }
                }
            }
        }
       
        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^ �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int PhysicalDeleteCampaignRate()
        {
            int status = 0;
            
            // �폜�Ώ�PCC�L�����y�[���ݒ�}�X�^�擾
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCpMsgSt pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            List<PccCpMsgSt> pccCpMsgStList = new List<PccCpMsgSt>();
            pccCpMsgStList.Add(pccCpMsgSt);
            //PCC�L�����y�[���Ώېݒ�f�B�N�V���i���[�擾
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);

            //PCC�L�����y�[���i�ڐݒ�f�B�N�V���i���[�擾
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            // �����폜
            status = this._pccCpMsgStAcs.Delete(ref pccCpMsgStList, ref pccCpTgtStDic, ref pccCpItmStDic);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DeleteFromDataSet(pccCpMsgStList[0], _dataIndex);
                    //PCC�L�����y�[���Ώېݒ�f�B�N�V���i���[�X�V
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.ContainsKey(guid))
                    {
                        this._pccCpTgtStDicDic.Remove(guid);
                    }
                    //PCC�L�����y�[���i�ڐݒ�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.ContainsKey(guid))
                    {
                        this._pccCpItmStDicDic.Remove(guid);
                    }
                    //TODO
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccCpMsgStAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "PhysicalDeleteCampaignRate",	// ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCpMsgStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���ݒ�}�X�^ ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int ReviveCampaignRate()
        {
            int status = 0;
            

            // �����Ώ�PCC�L�����y�[���ݒ�}�X�^�擾
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCpMsgSt pccCpMsgSt = ((PccCpMsgSt)this._detailsTable[guid]).Clone();
            List<PccCpMsgSt> pccCpMsgStList = new List<PccCpMsgSt>();
            pccCpMsgStList.Add(pccCpMsgSt);
            //PCC�L�����y�[���Ώېݒ胊�X�g�擾
            //PCC�L�����y�[���Ώېݒ�f�B�N�V���i���[�擾
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic = null;
            GetPccCpTgtStDicFromGuid(out pccCpTgtStDic, guid);

            //PCC�L�����y�[���i�ڐݒ�f�B�N�V���i���[�擾
            Dictionary<string, PccCpItmSt> pccCpItmStDic = null;
            GetPccCpItmStDicFromGuid(out pccCpItmStDic, guid);
            // ����
            status = this._pccCpMsgStAcs.RevivalLogicalDelete(ref pccCpMsgStList, ref pccCpTgtStDic, ref pccCpItmStDic);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�W�J����
                    DetailsToDataSet(pccCpMsgStList[0], this._dataIndex);
                    //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpTgtStDicDic != null && this._pccCpTgtStDicDic.Count > 0)
                    {
                        if (this._pccCpTgtStDicDic.ContainsKey(guid))
                        {
                            this._pccCpTgtStDicDic.Remove(guid);
                        }
                        this._pccCpTgtStDicDic.Add(guid, pccCpTgtStDic);
                    }
                    
                    //PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[�X�V
                    if (this._pccCpItmStDicDic != null && this._pccCpItmStDicDic.Count > 0)
                    {
                        if (this._pccCpItmStDicDic.ContainsKey(guid))
                        {
                            this._pccCpItmStDicDic.Remove(guid);
                        }
                        this._pccCpItmStDicDic.Add(guid, pccCpItmStDic);
                    }
                    
                    Initial_Timer.Enabled = true;
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCpMsgStAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ReviveSharedPartsAddInfo",			// ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCpMsgStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    return status;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                // ��ʃN���A����
                ScreenClear();
                // ��ʍč\�z����
                ScreenReconstruction();
            }
            else {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;

                if (CanClose == true) {
                    this.Close();
                }
                else {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="control">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                ERR_DPR_MSG, 	                    // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            control = this.tNedit_CampaignCode;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ExclusiveTransaction",				// ��������
                        operation,							// �I�y���[�V����
                        ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        erObject,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ExclusiveTransaction",				// ��������
                        operation,							// �I�y���[�V����
                        ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        erObject,							// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    break;
            }
        }

        /// <summary>
        /// ���Ӑ�O���b�h�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// <br></br>
        /// </remarks>
        private void CustomerScreenInitialSetting()
        {
            // ���Ӑ�X�L�[�}�̐ݒ�
            CustomerDataTableSchemaSetting();

            // ���Ӑ�GRID�̏����ݒ�
            CustomerGridInitialSetting();
        }

        /// <summary>
        /// �i�ڃO���b�h�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ItemScreenInitialSetting()
        {
            // �X�L�[�}�̐ݒ�
            ItemDataTableSchemaSetting();

            // GRID�̏����ݒ�
            ItemGridInitialSetting();
        }

        /// <summary>
        /// ���Ӑ�O���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerDataTableSchemaSetting()
        {
            _customerBindTable.Columns.Clear();

            // �X�L�[�}�̐ݒ�
            _customerBindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
            _customerBindTable.Columns.Add(MY_SCREEN_CUSTOMER_CODE, typeof(int));
            _customerBindTable.Columns.Add(MY_SCREEN_GUID, typeof(Button));
            _customerBindTable.Columns.Add(MY_SCREEN_CUSTOMER_NAME, typeof(string));
            _customerBindTable.Columns.Add(MY_INQORIGINALEPCD, typeof(string));
            _customerBindTable.Columns.Add(MY_INQORIGINALSECCD, typeof(string));
        }

        /// <summary>
        ///	���Ӑ��GRID�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGridInitialSetting()
        {
            // ���Ӑ�f�[�^�\�[�X�֒ǉ�
            this.UGrid_Customer.DataSource = _customerBindTable;

            // �O���b�h�̔w�i�F
            this.UGrid_Customer.DisplayLayout.Appearance.BackColor = Color.White;
            this.UGrid_Customer.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.UGrid_Customer.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�̒ǉ��s��
            this.UGrid_Customer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            this.UGrid_Customer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // �s�̍폜�s��
            this.UGrid_Customer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // ��̈ړ��s��
            this.UGrid_Customer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.UGrid_Customer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // ��̌����s��
            this.UGrid_Customer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.UGrid_Customer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �^�C�g���̊O�ϐݒ�
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.UGrid_Customer.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            this.UGrid_Customer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UGrid_Customer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.UGrid_Customer.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\������
            this.UGrid_Customer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.UGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.UGrid_Customer.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_Customer.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_Customer.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ���Ӑ�R�[�h��̐ݒ�
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellActivation = Activation.AllowEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].TabStop = true;

            // �K�C�h�{�^���̐ݒ�
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL�i����̐ݒ�
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].CellActivation = Activation.NoEdit;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].TabStop = true;

            //�������\����
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_INQORIGINALEPCD].Hidden = true;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_INQORIGINALSECCD].Hidden = true;

            // �Z���̕��̐ݒ�
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 30;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Width = 100;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].Width = 255;
            //Format
            this.UGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Format = "D8";
            // �I���s�̊O�ϐݒ�
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �s�Z���N�^�̊O�ϐݒ�
            this.UGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.UGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.UGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �r���̐F��ύX
            this.UGrid_Customer.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
            UltraGridBand editBand = this.UGrid_Customer.DisplayLayout.Bands[0];
            // �O���[�v�w�b�_�̂ݕ\������悤�ɂ���
            editBand.ColHeadersVisible = false;
            editBand.GroupHeadersVisible = true;

            //BLNo.

            //���Ӑ於��
            UltraGridGroup ultraGridGroup = editBand.Groups.Add(MY_SCREEN_ODER, editBand.Columns[MY_SCREEN_ODER].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_ODER]);
            //���Ӑ�R�[�h�O���[�v
            ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[MY_SCREEN_CUSTOMER_CODE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_CUSTOMER_CODE]);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_GUID]);
            //���Ӑ於��
            ultraGridGroup = editBand.Groups.Add(BLGOODSNAME_TITLE, editBand.Columns[MY_SCREEN_CUSTOMER_NAME].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[MY_SCREEN_CUSTOMER_NAME]);
            

        }

        /// <summary>
        /// �i�ڃO���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ItemDataTableSchemaSetting()
        {
            _itemBindTable.Columns.Clear();

            // �X�L�[�}�̐ݒ�
            _itemBindTable.Columns.Add(BLTIEM_ODER, typeof(int));
            _itemBindTable.Columns.Add(BLGOODSCODE_TITLE, typeof(int));
            _itemBindTable.Columns.Add(BLGUID_TITLE, typeof(string));
            _itemBindTable.Columns.Add(BLGOODSNAME_TITLE, typeof(string));
            _itemBindTable.Columns.Add(BLGOODSQTY_TITLE, typeof(int));
            _itemBindTable.Columns.Add(BLGRIDNO_TITLE, typeof(int));
        }

        /// <summary>
        /// �i�ڃO���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�ڃO���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ItemGridInitialSetting()
        {


            // �O���b�h�̏����ݒ菈��
            // �O���b�h�փo�C���h

            this.UGrid_ItmSt.DataSource = _itemBindTable;
            // �s�̒ǉ��s��
            this.UGrid_ItmSt.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            this.UGrid_ItmSt.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // �s�̍폜�s��
            this.UGrid_ItmSt.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // ��̈ړ��s��
            this.UGrid_ItmSt.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.UGrid_ItmSt.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // ��̌����s��
            this.UGrid_ItmSt.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.UGrid_ItmSt.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �^�C�g���̊O�ϐݒ�
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.UGrid_ItmSt.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            this.UGrid_ItmSt.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UGrid_ItmSt.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.UGrid_ItmSt.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\������
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.UGrid_ItmSt.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_ItmSt.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.UGrid_ItmSt.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Bands[0].Columns[BLTIEM_ODER].CellAppearance.ForeColor = Color.White;

            UltraGridBand editBand = this.UGrid_ItmSt.DisplayLayout.Bands[PCCITEMST_TABLE];

            // �I���s�̊O�ϐݒ�	
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�	
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.UGrid_ItmSt.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �s�Z���N�^�̊O�ϐݒ�	
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.UGrid_ItmSt.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //��̕\��Style�ݒ�
            editBand.Columns[BLTIEM_ODER].Header.Caption = BLTIEM_ODER;
            editBand.Columns[BLGOODSCODE_TITLE].Header.Caption = BLGOODSCODE_NAME;
            editBand.Columns[BLGUID_TITLE].Header.Caption = BLGUID_TITLE;
            editBand.Columns[BLGOODSNAME_TITLE].Header.Caption = BLGOODSNAME_NAME;
            editBand.Columns[BLGOODSQTY_TITLE].Header.Caption = BLGOODSQTY_NAME;
            editBand.Columns[BLGRIDNO_TITLE].Header.Caption = BLGRIDNO_TITLE;
            editBand.Columns[BLTIEM_ODER].TabStop = false;
            editBand.Columns[BLGOODSCODE_TITLE].TabStop = true;
            editBand.Columns[BLGUID_TITLE].TabStop = true;
            editBand.Columns[BLGOODSNAME_TITLE].TabStop = true;
            editBand.Columns[BLGOODSQTY_TITLE].TabStop = true;
            editBand.Columns[BLGRIDNO_TITLE].TabStop = false;

            //�O���b�h�^�C�v
            editBand.Columns[BLGUID_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            //
            editBand.Columns[BLTIEM_ODER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLGOODSCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[BLGUID_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[BLGOODSNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[BLGOODSQTY_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[BLGRIDNO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[BLGOODSNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[BLGUID_TITLE].CellActivation = Activation.NoEdit;

            //�������l�̐ݒ�
            editBand.Columns[BLTIEM_ODER].DefaultCellValue = 0;
            editBand.Columns[BLGOODSCODE_TITLE].DefaultCellValue = DBNull.Value;
            editBand.Columns[BLGOODSNAME_TITLE].DefaultCellValue = string.Empty;
            editBand.Columns[BLGOODSQTY_TITLE].DefaultCellValue = DBNull.Value;
            editBand.Columns[BLGRIDNO_TITLE].DefaultCellValue = 0;

            //�ҏW�O���b�h�O���[�v�ݒ�
            if (editBand == null)
            {
                return;
            }

            editBand.Groups.Clear();
            // �O���[�v�w�b�_�̂ݕ\������悤�ɂ���
            editBand.ColHeadersVisible = false;
            editBand.GroupHeadersVisible = true;

            //BLNo.
            UltraGridGroup ultraGridGroup = editBand.Groups.Add(BLTIEM_ODER, editBand.Columns[BLTIEM_ODER].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLTIEM_ODER]);
            //BL�R�[�h�O���[�v
            ultraGridGroup = editBand.Groups.Add(BLGOODSCODE_TITLE, editBand.Columns[BLGOODSCODE_TITLE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSCODE_TITLE]);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGUID_TITLE]);
            //BL����
            ultraGridGroup = editBand.Groups.Add(BLGOODSNAME_TITLE, editBand.Columns[BLGOODSNAME_TITLE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSNAME_TITLE]);
            //BL����
            ultraGridGroup = editBand.Groups.Add(BLGOODSQTY_TITLE, editBand.Columns[BLGOODSQTY_TITLE].Header.Caption);
            ultraGridGroup.Columns.Add(editBand.Columns[BLGOODSQTY_TITLE]);

            editBand.Columns[BLGRIDNO_TITLE].Hidden = true;

            // �{�^���̃X�^�C����ݒ肷��
            ImageList imageList16 = IconResourceManagement.ImageList16;
            editBand.Columns[BLGUID_TITLE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            editBand.Columns[BLGUID_TITLE].CellButtonAppearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[BLGUID_TITLE].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;

            editBand.Columns[BLTIEM_ODER].Width = 30;
            editBand.Columns[BLGOODSCODE_TITLE].Width = 100;
            editBand.Columns[BLGUID_TITLE].Width = 20;
            editBand.Columns[BLGOODSNAME_TITLE].Width = 205;
            editBand.Columns[BLGOODSQTY_TITLE].Width = 50;
            this.UGrid_ItmSt.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

            //Format
            editBand.Columns[BLGOODSCODE_TITLE].Format = "D8";
        }

        /// <summary>
        ///	Grid �V�K�s�̒ǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�ɐV�K�s��ǉ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGrid_AddRow()
        {
            if (this._customerBindTable.Rows.Count == 99)
            {
                // MAX99�s�Ƃ���
                return;
            }

            // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
            DataRow bindRow;

            bindRow = this._customerBindTable.NewRow();

            // ���Ӑ����Grid�ɒǉ�
            bindRow[MY_SCREEN_ODER] = this._customerBindTable.Rows.Count + 1;
            bindRow[MY_SCREEN_CUSTOMER_CODE] = DBNull.Value;
            bindRow[MY_SCREEN_CUSTOMER_NAME] = "";
            bindRow[MY_INQORIGINALEPCD] = "";
            bindRow[MY_INQORIGINALSECCD] = "";
            this._customerBindTable.Rows.Add(bindRow);
        }

        /// <summary>
        ///	�i�ڐݒ�Grid �V�K�s�̒ǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�ɐV�K�s��ǉ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void ItemGrid_AddRow()
        {
            if (this._itemBindTable.Rows.Count == 99)
            {
                // MAX99�s�Ƃ���
                return;
            }

            // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
            DataRow bindRow;

            bindRow = this._itemBindTable.NewRow();

            // ���Ӑ����Grid�ɒǉ�
            bindRow[BLTIEM_ODER] = this._itemBindTable.Rows.Count + 1;
            bindRow[BLGOODSCODE_TITLE] = DBNull.Value;
            bindRow[BLGOODSNAME_TITLE] = string.Empty;
            bindRow[BLGOODSQTY_TITLE] = DBNull.Value;
            bindRow[BLGRIDNO_TITLE] = 0;
            this._itemBindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// ��������������̔��f
        /// </summary>
        /// <param name="inputStr">�`�F�b�N����</param>
        /// <returns>true:�������������� false:��������������܂���</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public bool IsNumber(string inputStr)
        {
            string reg = "^[0-9]*$";
            Regex regex = new Regex(reg);
            return regex.IsMatch(inputStr);
        }

        /// <summary>
        /// ���Ӑ於�̂��擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <remarks>
        /// <returns>PCC���Аݒ�f�[�^</returns>
        /// <br>Note       :���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private PccCmpnySt GetCustomerName(int customerCode)
        {
            PccCmpnySt pccCmpnySt = null;
            if (this._customerHTable == null || this._customerHTable.Count == 0)
            {
                this._pccCpMsgStAcs.GetCustomerHTable();
                this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            }
            if (this._customerHTable != null && this._customerHTable.Count > 0)
            {
               if(this._customerHTable.ContainsKey(customerCode))
               {
                   pccCmpnySt = this._customerHTable[customerCode];
               }
            }

            return pccCmpnySt;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            _customerCode = 0;
            _customerName = "";
            _inqOriginalEpCd = "";
            _inqOriginalSecCd = "";
            if (customerSearchRet == null)
            {
                return;
            }

            // ���Ӑ�R�[�h
            _customerCode = customerSearchRet.CustomerCode;

            // ���Ӑ於��
            _customerName = customerSearchRet.Snm.Trim();
            //�⍇������ƃR�[�h
            this._inqOriginalEpCd = customerSearchRet.CustomerEpCode.Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            this._inqOriginalSecCd = customerSearchRet.CustomerSecCode;
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// Note			:	�����ꂽ�L�[�����l�̂ݗL���ɂ��鏈�����s���܂��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                // �����_�ȉ�������0���H
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart) + key
                       + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���������f
        /// </summary>
        /// <param name="str">������</param>
        /// <param name="charCount">������ʐ�</param>
        /// <returns>True:����; False:�񐔎�</returns>
        /// <remarks>
        /// <br>Note       : ���������f�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool IsDigitAdd(String str, int charCount)
        {

            string regex1 = "^[0-9]{0," + charCount + "}$";
            Regex objRegex = new Regex(regex1);
            return objRegex.IsMatch(str);
        }

        /// <summary>
        /// �L�����y�[���ݒ�捞�݃{�^���N���b�N�C�x���g����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[���ݒ�捞�݃{�^���N���b�N�ŏ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Insert_ButtonProc()
        {
            int campaignCode = this.tNedit_CampaignCode.GetInt();
            //��ʊ֘A�̏��̃N���A
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;     // �L�����y�[���Ώۋ敪
            this.ApplyStaDate_TDateEdit.Clear();                    // �K�p�J�n��
            this.ApplyEndDate_TDateEdit.Clear();                    // �K�p�I����
            this._customerBindTable.Clear();
            this._itemBindTable.Clear();
            //�L�����y�[�����̎擾
            PccCpMsgSt pccCpMsgSt = null;
            List<PccCpTgtSt> pccCpTgtStList = null;
            List<PccCpItmSt> pccCpItmStList = null;
            this._pccCpMsgStAcs.GetCampaignInfo(campaignCode, out pccCpMsgSt, out pccCpTgtStList, out pccCpItmStList);

            if (pccCpMsgSt != null)
            {
                CampaignObjDiv_tComboEditor.Value = pccCpMsgSt.CampaignObjDiv;
                ApplyStaDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyStaDate);
                ApplyEndDate_TDateEdit.SetLongDate(pccCpMsgSt.ApplyEndDate);

                //���Ӑ�O���b�h�̐ݒ�
                if (pccCpMsgSt.CampaignObjDiv == 1)
                {

                    if (pccCpTgtStList != null && pccCpTgtStList.Count > 0)
                    {
                        InitCustomerGridDate(pccCpTgtStList);
                    }
                    else
                    {
                        this._customerBindTable.Clear();
                    }
                }
                //BL�R�[�h�O���b�h�̐ݒ�
                if (pccCpItmStList != null && pccCpItmStList.Count > 0)
                {
                    InitItemGridDate(pccCpItmStList);

                }
                else
                {
                    this._itemBindTable.Clear();
                }
            }
            if ((int)CampaignObjDiv_tComboEditor.Value == 1)
            {
                this.CustomerGrid_AddRow();
            }
            this.ItemGrid_AddRow();
            this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count - 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
        }

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(PMPCC09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PMPCC09060UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;
            this.SetIconImage(this.uButton_CampaignGuide, Size16_Index.STAR1);
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMPCC09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PMPCC09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMPCC09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void PMPCC09060UA_VisibleChanged(object sender, System.EventArgs e)
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
            if (this._detailsIndexBuf == this._dataIndex)
            {
                return;
            }


            //this.Owner.Activate();

            //// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            //if ( this.Visible == false ) {
            //    return;
            //}

            // ��ʃN���A����
            ScreenClear();

            // ��ʍč\�z����
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^����
            SaveProc();
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ( this.Mode_Label.Text != DELETE_MODE ) {
                // ���݂̉�ʏ����擾
                PccCpMsgSt pccCpMsgSt = new PccCpMsgSt();
                pccCpMsgSt = this._pccCpMsgSt.Clone();

                //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[
                Dictionary<string, PccCpTgtSt> pccCpTgtStDic;
                //PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[
                Dictionary<string, PccCpItmSt> pccCpItmStDic;
                DispToPccCpMsgSt(ref pccCpMsgSt, out pccCpTgtStDic, out pccCpItmStDic);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this.ListCompare(pccCpMsgSt, pccCpTgtStDic, pccCpItmStDic, this._pccCpMsgSt, this._pccCpTgtStDicClone, this._pccCpItmStDicClone);

                if ( !( cloneFlg ) ) {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch ( res ) {
                        case DialogResult.Yes:
                            if (SaveProc()) {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else {
                                return;
                            }
                        case DialogResult.No: 
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            if (_modeFlg)
                            {
                                this.tNedit_CampaignCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            return;
                    }
                }
            }

            if ( UnDisplaying != null ) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if ( CanClose == true ) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

         /// <summary>
        /// ���PCC�i�ڃO���[�v�N���X��r
        /// </summary>
        /// <param name="pccCpMsgSt">�L�����y�[���}�X�^New</param>
        /// <param name="pccCpTgtStDic">PCC�L�����y�[���Ώېݒ�f�[�^�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpItmStDic">PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[</param>
        /// <param name="pccCpMsgStOld">�L�����y�[���}�X�^Old</param>
        /// <param name="pccCpTgtStDicOld">PCC�L�����y�[���Ώېݒ�f�[�^�f�[�^�f�B�N�V���i���[Old</param>
        /// <param name="pccCpItmStDicOld">PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[Old</param>
        /// <remarks>
        /// <br>Note       : ���PCC�i�ڃO���[�v�N���X���r���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ListCompare(PccCpMsgSt pccCpMsgSt, Dictionary<string, PccCpTgtSt> pccCpTgtStDic, Dictionary<string, PccCpItmSt> pccCpItmStDic, PccCpMsgSt pccCpMsgStOld, Dictionary<string, PccCpTgtSt> pccCpTgtStDicOld, Dictionary<string, PccCpItmSt> pccCpItmStDicOld)
        {
            bool isEqualsValue = true;
            if (this.Mode_Label.Text.Equals(INSERT_MODE) || this.Mode_Label.Text.Equals(UPDATE_MODE))
            {
                if (!pccCpMsgSt.Equals(pccCpMsgStOld))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (pccCpTgtStDic == null && pccCpTgtStDicOld != null && pccCpTgtStDicOld.Count > 0)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }

                if (pccCpTgtStDic != null && pccCpTgtStDic.Count > 0 && pccCpTgtStDicOld == null)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (pccCpTgtStDic != null && pccCpTgtStDicOld != null)
                {
                    if (pccCpTgtStDic.Count != pccCpTgtStDicOld.Count)
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }
                    foreach (KeyValuePair<string, PccCpTgtSt> pccCpTgtStPair in pccCpTgtStDic)
                    {
                        if (pccCpTgtStDicOld.ContainsKey(pccCpTgtStPair.Key))
                        {
                            if (!pccCpTgtStPair.Value.Equals(pccCpTgtStDicOld[pccCpTgtStPair.Key]))
                            {
                                isEqualsValue = false;
                                return isEqualsValue;
                            }
                        }
                        else
                        {
                            isEqualsValue = false;
                            return isEqualsValue;
                        }
                    }
                }
                if (pccCpItmStDic == null && pccCpItmStDicOld != null && pccCpItmStDicOld.Count > 0)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }

                if (pccCpItmStDic != null && pccCpItmStDic.Count > 0 && pccCpItmStDicOld == null)
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (pccCpItmStDic != null && pccCpItmStDicOld != null)
                {
                    if (pccCpItmStDic.Count != pccCpItmStDicOld.Count)
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }


                    foreach (KeyValuePair<string, PccCpItmSt> pccCpItmStPair in pccCpItmStDic)
                    {
                        if (pccCpItmStDicOld.ContainsKey(pccCpItmStPair.Key))
                        {
                            if (!pccCpItmStPair.Value.Equals(pccCpItmStDicOld[pccCpItmStPair.Key]))
                            {
                                isEqualsValue = false;
                                return isEqualsValue;
                            }
                        }
                        else
                        {
                            isEqualsValue = false;
                            return isEqualsValue;
                        }
                    }
                }
            }
            return isEqualsValue;
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                //MessageBoxButtons.OKCancel,
                //MessageBoxDefaultButton.Button2);	// �\������{�^��
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if ( result == DialogResult.Yes ) {
                // PCC�L�����y�[���ݒ�}�X�^�����폜
                PhysicalDeleteCampaignRate();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveCampaignRate();
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					 �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Insert_Button_Click.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �L�����y�[���ݒ�捞�݃{�^���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Insert_Button_Click(object sender, EventArgs e)
        {
            PccCpMsgSt pccCpMsgStNew = this._pccCpMsgSt.Clone();
            //PCC�L�����y�[���Ώېݒ�f�[�^�f�B�N�V���i���[
            Dictionary<string, PccCpTgtSt> pccCpTgtStDic;
            //PCC�L�����y�[���i�ڐݒ�f�[�^�f�[�^�f�B�N�V���i���[
            Dictionary<string, PccCpItmSt> pccCpItmStDic;
           DispToPccCpMsgSt(ref pccCpMsgStNew, out pccCpTgtStDic, out pccCpItmStDic);
            // �ŏ��Ɏ擾������ʏ��Ɣ�r
           bool cloneFlg = this.ListCompare(pccCpMsgStNew, pccCpTgtStDic, pccCpItmStDic, this._pccCpMsgStInsert,  this._pccCpTgtStDicCloneInsert, this._pccCpItmStDicCloneInsert);

            if (!cloneFlg)
            {
                DialogResult res = TMsgDisp.Show(
                       this,                                   // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                       ASSEMBLY_ID,                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                    //"���͂��ꂽ�R�[�h�̃L�����y�[���֘A�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W  // DEL 2011/05/06
                       "���݁A�ҏW���̃f�[�^�����݂��܂��p�����Ă���낵���ł����H",   // �\�����郁�b�Z�[�W            // ADD 2011/05/06
                       0,                                      // �X�e�[�^�X�l
                       MessageBoxButtons.YesNo);               // �\������{�^��
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            Insert_ButtonProc();
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                }
            }
            else
            {
                Insert_ButtonProc();
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            _modeFlg = false;
            int campaignCode = this.tNedit_CampaignCode.GetInt();
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CampaignCode":
                    // PCC�L�����y�[���ݒ�}�X�^�����e�R�[�h�R�[�h�Ƀt�H�[�J�X������ꍇ
                   if (campaignCode != 0)
                    {
                        if(ModeChangeProc())
                        {
                            if (this.tNedit_CampaignCode.GetInt() == 0)
                            {
                                e.NextCtrl = tNedit_CampaignCode;
                            }
                            return;
                        }
                        // �L�����y�[�����̂̎擾
                        CampaignSt campaignSt = null;
                        // �L�����y�[�����̂̎擾

                        //campaignSt = this._pccCpMsgStAcs.GetCampaignSt(campaignCode);               //DEL 2011/11/25 redmain#8077 
                        try{campaignSt = this._pccCpMsgStAcs.GetCampaignSt(campaignCode);}catch { } //ADD 2011/11/25 redmain#8077 
                        if (campaignSt != null)
                        {
                            if ("00".Equals(campaignSt.SectionCode.TrimEnd()) || string.IsNullOrEmpty(campaignSt.SectionCode.TrimEnd()) || this._loginSectionCode.Equals(campaignSt.SectionCode))
                            {
                                this.tEdit_CampaignName.Text = campaignSt.CampaignName;
                                //�L�����y�[���ݒ�捞�݃{�^��
                                this.Insert_Button.Enabled = true;
                                DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                                //e.NextCtrl = null;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���_�͑ΏۊO�̂��߁A���̃L�����y�[���͑I���ł��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                // ���Ӑ�̃N���A
                                this.tNedit_CampaignCode.Clear();
                                this.tEdit_CampaignName.Text = "";
                                this.Insert_Button.Enabled = false;
                                DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                                
                                // �J�[�\������
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�L�����y�[�����̃}�X�^�ɖ��o�^�ł��B",
                            -1,
                            MessageBoxButtons.OK);

                            // ���Ӑ�̃N���A
                            this.tNedit_CampaignCode.Clear();
                            this.tEdit_CampaignName.Text = "";
                            this.Insert_Button.Enabled = false;
                            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                            
                            // �J�[�\������
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    else
                    {
                        // ������
                        // �L�����y�[���̃N���A
                        this.tNedit_CampaignCode.Clear();
                        this.tEdit_CampaignName.Text = "";
                        DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                        
                        this.Insert_Button.Enabled = false;
                    }

                    break;
                //�K�p�I����
                case "ApplyEndDate_TDateEdit":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        if ((int)CampaignObjDiv_tComboEditor.Value == 0)
                                        {
                                            e.NextCtrl = DeleteBlCodeRow_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = CustomerGuid_Button;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "DeleteBlCodeRow_Button":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if ((int)CampaignObjDiv_tComboEditor.Value == 0)
                                        {
                                            e.NextCtrl = ApplyEndDate_TDateEdit;
                                        }
                                        break;
                                    }
                            }
                        }
                        else if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        this.UGrid_ItmSt.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "DeleteCustomerRow_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        this.UGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "CustomerGuid_Button":            // GRID�폜�{�^��
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        this.UGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "BlCodeGuid_Button":            // GRID�폜�{�^��
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        this.UGrid_ItmSt.Rows[0].Cells[BLGOODSCODE_TITLE].Activate();
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "UGrid_ItmSt":      // �O���b�h
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �K�C�h�{�^���Ƀt�H�[�J�X������
                                        if (this.UGrid_ItmSt.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;
                                            string columnKey = this.UGrid_ItmSt.ActiveCell.Column.Key;
                                            int numLen = 0;
                                            if (BLGOODSCODE_TITLE.Equals(columnKey))
                                            {
                                                numLen = 8;
                                            }
                                            else if (BLGOODSQTY_TITLE.Equals(columnKey))
                                            {
                                                numLen = 3;
                                            }
                                            if (this.UGrid_ItmSt.ActiveCell.Column.DataType == typeof(Int32) && this.UGrid_ItmSt.ActiveCell.Activation == Activation.AllowEdit)
                                            {
                                                Infragistics.Win.EmbeddableEditorBase editorBase = this.UGrid_ItmSt.ActiveCell.EditorResolved;
                                                string currentEditText = editorBase.CurrentEditText;
                                                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                                                if (!checkNumber)
                                                {
                                                    if (BLGOODSCODE_TITLE.Equals(columnKey))
                                                    {
                                                        this.UGrid_ItmSt.ActiveCell.Value = DBNull.Value;
                                                    }
                                                    else if (BLGOODSQTY_TITLE.Equals(columnKey))
                                                    {
                                                        this.UGrid_ItmSt.ActiveCell.Value = 0;
                                                    }
                                                }

                                            }
                                            if ((this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                               
                                                // �Z���̃X�^�C�����{�^���ŁA�Z���̍ŏI�s�̏ꍇ
                                                if ((int)this.UGrid_ItmSt.ActiveCell.Row.Cells[BLTIEM_ODER].Value == this._itemBindTable.Rows.Count)
                                                {
                                                    //�ŏI�s�����͂̏ꍇ�A�V�K�s��ǉ�
                                                    if (this.UGrid_ItmSt.ActiveCell.Row.Cells[BLGOODSCODE_TITLE].Value != DBNull.Value && (int)this.UGrid_ItmSt.ActiveCell.Row.Cells[BLGOODSCODE_TITLE].Value != 0)
                                                    {
                                                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                                                        this.ItemGrid_AddRow();
                                                        this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count - 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                                                    }
                                                }
                                            }
                                        }

                                        // ���̃Z���ֈړ�
                                        bool moveFlg = this.ItmStMoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._ItemGridUpdFlg)
                                        {
                                            this.ItmStMovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.ItmStMovePrevAllowEditCell(false))
                                        {
                                            // �O���b�h���̃t�H�[�J�X����
                                            e.NextCtrl = null;
                                        }
                                       
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "UGrid_Customer":      // �O���b�h
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �K�C�h�{�^���Ƀt�H�[�J�X������
                                        if (this.UGrid_Customer.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

                                            string columnKey = this.UGrid_Customer.ActiveCell.Column.Key;
                                            int numLen = 0;
                                            if (MY_SCREEN_CUSTOMER_CODE.Equals(columnKey))
                                            {
                                                numLen = 8;
                                            }

                                            if (this.UGrid_Customer.ActiveCell.Column.DataType == typeof(Int32) && columnKey.Equals(MY_SCREEN_CUSTOMER_CODE))
                                            {
                                                Infragistics.Win.EmbeddableEditorBase editorBase = this.UGrid_Customer.ActiveCell.EditorResolved;
                                                string currentEditText = editorBase.CurrentEditText;
                                                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                                                if (!checkNumber)
                                                {
                                                    this.UGrid_Customer.ActiveCell.Value = DBNull.Value;
                                                }

                                            }
                                            if ((this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // �Z���̃X�^�C�����{�^���ŁA�Z���̍ŏI�s�̏ꍇ
                                                if ((int)this.UGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._customerBindTable.Rows.Count)
                                                {
                                                    //�ŏI�s�����͂̏ꍇ�A�V�K�s��ǉ�
                                                    if (this.UGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value != DBNull.Value && (int)this.UGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value != 0)
                                                    {
                                                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                                                        this.CustomerGrid_AddRow();
                                                    }
                                                }
                                            }
                                        }

                                        // ���̃Z���ֈړ�
                                        bool moveFlg = this.CustomerMoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._customerGridUpdFlg)
                                        {
                                            this.CustomerMovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.CustomerMovePrevAllowEditCell(false))
                                        {
                                            // �O���b�h���̃t�H�[�J�X����
                                            e.NextCtrl = null;
                                        }
                                       
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                //case "Ok_Button":
                case "Renewal_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        int rowIdx = this.UGrid_ItmSt.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.UGrid_ItmSt.ActiveRow = this.UGrid_ItmSt.Rows[rowIdx];
                                        // �A�N�e�B�u�Z���𓾈Ӑ�R�[�h�ɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.UGrid_ItmSt.ActiveCell = this.UGrid_ItmSt.Rows[rowIdx].Cells[BLGOODSCODE_TITLE];
                                        // ���Ӑ�R�[�h��ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._itemBindTable.Rows[rowIdx][BLGOODSCODE_TITLE].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        int rowIdx = this.UGrid_ItmSt.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.UGrid_ItmSt.ActiveRow = this.UGrid_ItmSt.Rows[rowIdx];
                                        // �A�N�e�B�u�Z���𓾈Ӑ�R�[�h�ɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.UGrid_ItmSt.ActiveCell = this.UGrid_ItmSt.Rows[rowIdx].Cells[BLGOODSCODE_TITLE];
                                        // ���Ӑ�R�[�h��ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._itemBindTable.Rows[rowIdx][BLGOODSCODE_TITLE].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary> 
        /// <remarks>
        /// <br>Note       :  ���[�h�ύX�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            // �L�����y�[���R�[�h
            int campaignCode = tNedit_CampaignCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCampaignCode = 0;
                string dsCampaignCodeStr = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][CAMPAIGNCODE_TITLE];
                Int32.TryParse(dsCampaignCodeStr, out dsCampaignCode);
                if (campaignCode == dsCampaignCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            //"���͂��ꂽ�R�[�h�̃L�����y�[���֘A�}�X�^���͊��ɍ폜����Ă��܂��B", // �\�����郁�b�Z�[�W   // DEL 2011/05/06
                          "���͂��ꂽ�R�[�h�̃L�����y�[���ݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W   // ADD 2011/05/06
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �L�����y�[���R�[�h�A���̂̃N���A
                        tNedit_CampaignCode.Clear();
                        tEdit_CampaignName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                        //"���͂��ꂽ�R�[�h�̃L�����y�[���֘A�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W  // DEL 2011/05/06
                        "���͂��ꂽ�R�[�h�̃L�����y�[���}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W            // ADD 2011/05/06
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // �ꎞ�I�ɏڍ׃e�[�u�����X�V
                                this._dataIndex = i;
                                // ��ʍĕ`��
                                ScreenClear();
                                ScreenReconstruction();

                                // �ڍ׃e�[�u�������ɖ߂�
                                break;
                            }   
                        case DialogResult.No:
                            {
                                // �L�����y�[���R�[�h�A���̂̃N���A
                                tNedit_CampaignCode.Clear();
                                tEdit_CampaignName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Control.VisibleChange �C�x���g(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_VisibleChanged(object sender, System.EventArgs e)
        {
            // �A�N�e�B�u�Z���E�A�N�e�B�u�s�𖳌�
            this.UGrid_Customer.ActiveCell = null;
        }

        /// <summary>
        /// Control.KeyDown �C�x���g (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void UGrid_Customer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return;
            }

            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ���L�[
                    case Keys.Up:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = CustomerMoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Down:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = CustomerMoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = CustomerMoveLeftCell();
                            e.Handled = true;

                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = CustomerMoveRightCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.UGrid_Customer.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                UGrid_Customer_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        /// Control.KeyDown �C�x���g (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return;
            }

            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;

            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ���L�[
                    case Keys.Up:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = ItmStMoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Down:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = ItmStMoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            //// ��̃Z���ֈړ�
                            nextControl = ItmStMoveLeftCell();
                            e.Handled = true;

                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            //// ���̃Z���ֈړ�
                            nextControl = ItmStMoveRightCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.UGrid_ItmSt.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                UGrid_ItmSt_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃L�[�����C�x���g�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.UGrid_Customer.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.UGrid_Customer.ActiveCell;

            // ���Ӑ�R�[�h�̓��͌����`�F�b�N
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃L�[�����C�x���g�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.UGrid_ItmSt.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.UGrid_ItmSt.ActiveCell;

            // BL�R�[�h�̓��͌����`�F�b�N
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // BLQTY
            if (cell.Column.Key == BLGOODSQTY_TITLE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃Z���ҏW�I���C�x���g�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.UGrid_Customer.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.UGrid_Customer.ActiveCell;

            // ���Ӑ�R�[�h
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                int code = 0;
                if (cell.Value == DBNull.Value || cell.Value == null)
                {
                    code = 0;
                }
                else
                {
                    code = (int)cell.Value;
                }
                this._customerGridUpdFlg = true;

                if (code !=0)
                {
                   
                    // ���͗L
                    int customerCode = code;
                    PccCmpnySt pccCmpnyStGuid = null;
                    string customerName = string.Empty;
                    if(_customerHTable != null && _customerHTable.ContainsKey(customerCode))
                    {
                        pccCmpnyStGuid = _customerHTable[customerCode];
                        customerName = pccCmpnyStGuid.PccCompanyName;
                        this._inqOriginalEpCd = pccCmpnyStGuid.InqOriginalEpCd.Trim();//@@@@20230303
                        this._inqOriginalSecCd = pccCmpnyStGuid.InqOriginalSecCd;
                        bool AddFlg = true;     // �ǉ��t���O
                        int maxRow = this._customerBindTable.Rows.Count;

                        // ���Ӑ�R�[�h�̏d���`�F�b�N
                        for (int i = 0; i < maxRow; i++)
                        {
                            if (cell.Row.Index == i)
                            {
                                // �����s����SKIP
                                continue;
                            }
                            if (this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] != DBNull.Value)
                            {
                                int wkTbsPartsCode = (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                                if ((wkTbsPartsCode != 0) && (wkTbsPartsCode == customerCode))
                                {
                                    // �d���R�[�h�L
                                    AddFlg = false;
                                    break;
                                }
                            }
                        }

                        if (AddFlg)
                        {
                            // ���Ӑ�R�[�h�̒ǉ�
                            // �I����������Cell�ɐݒ�
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = customerCode;   // ���Ӑ�R�[�h
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = customerName;                   // ���Ӑ�i��
                            cell.Row.Cells[MY_INQORIGINALEPCD].Value = _inqOriginalEpCd.Trim();                   // �⍇������ƃR�[�h//@@@@20230303
                            cell.Row.Cells[MY_INQORIGINALSECCD].Value = _inqOriginalSecCd;                   // �⍇�������_�R�[�h
                            if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._customerBindTable.Rows.Count)
                            {
                                // �ŏI�s�̏ꍇ�A�s��ǉ�
                                this.CustomerGrid_AddRow();
                            }
                        }
                        else
                        {
                            // �d���G���[��\��
                            TMsgDisp.Show(
                                this,								    // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                                ASSEMBLY_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�I���������Ӑ�R�[�h���d�����Ă��܂��B",	    // �\�����郁�b�Z�[�W 
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				    // �\������{�^��

                            // ���Ӑ�R�[�h�A���Ӑ於���N���A
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = DBNull.Value;     // ���Ӑ�R�[�h
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於
                            cell.Row.Cells[MY_INQORIGINALEPCD].Value = "";                   // �⍇������ƃR�[�h
                            cell.Row.Cells[MY_INQORIGINALSECCD].Value = "";                   // �⍇�������_�R�[�h
                            // Grid�ύX�Ȃ�
                            this._customerGridUpdFlg = false;
                            this._inqOriginalEpCd = string.Empty;
                            this._inqOriginalSecCd = string.Empty;
                        }
                    }
                    else
                    {
                        // �_���폜�f�[�^�͐ݒ�s��
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            //"PCC���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n[" + customerCode.ToString("d08") + "]", //DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                            "BL�߰µ��ް���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n[" + customerCode.ToString("d08") + "]", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                            -1,
                            MessageBoxButtons.OK);

                        // ���Ӑ�R�[�h�A���Ӑ於���N���A
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = DBNull.Value;      // ���Ӑ�R�[�h
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於
                        cell.Row.Cells[MY_INQORIGINALEPCD].Value = "";                   // �⍇������ƃR�[�h
                        cell.Row.Cells[MY_INQORIGINALSECCD].Value = "";                   // �⍇�������_�R�[�h
                        // Grid�ύX�Ȃ�
                        this._customerGridUpdFlg = false;
                        this._inqOriginalEpCd = string.Empty;
                        this._inqOriginalSecCd = string.Empty;
                    }
                }
                else
                {
                    // ������
                    // ���Ӑ�R�[�h�A���Ӑ於���N���A
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = DBNull.Value;     // ���Ӑ�R�[�h
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於
                    cell.Row.Cells[MY_INQORIGINALEPCD].Value = "";                   // �⍇������ƃR�[�h
                    cell.Row.Cells[MY_INQORIGINALSECCD].Value = "";                   // �⍇�������_�R�[�h
                    this._inqOriginalEpCd = string.Empty;
                    this._inqOriginalSecCd = string.Empty;
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃Z���ҏW�I���C�x���g�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_AfterExitEditMode(object sender, EventArgs e)
        {

            UltraGrid ultraGrid = (UltraGrid)sender;

            if (ultraGrid.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = ultraGrid.ActiveCell;

            int rowIndex = cell.Row.Index;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            if (cell.Column.Key == BLGOODSCODE_TITLE)
            {
                int blCode = 0;
                if (cell.Value != DBNull.Value && cell.Value != null)
                {
                    blCode = (int)cell.Value;
                }
                this._ItemGridUpdFlg = true;
                if (blCode != 0)
                {

                    bool AddFlg = true;
                    if (this._bLCodeTable != null && this._bLCodeTable.ContainsKey(blCode))
                    {
                        // ���Ӑ�R�[�h�̏d���`�F�b�N
                        for (int i = 0; i < this._itemBindTable.Rows.Count; i++)
                        {
                            if (rowIndex == i)
                            {
                                // �����s����SKIP
                                continue;
                            }
                            if (this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == DBNull.Value || (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == 0)
                            {
                                continue;
                            }
                            int bLGoodsCode = (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE];

                            if (bLGoodsCode == blCode)
                            {
                                // �d���R�[�h�L
                                AddFlg = false;
                                break;
                            }
                        }

                        if (AddFlg)
                        {
                            // �I����������Cell�ɐݒ�
                            bLGoodsCdUMnt = this._bLCodeTable[blCode] as BLGoodsCdUMnt;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = bLGoodsCdUMnt.BLGoodsHalfName;
                            if (ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == DBNull.Value || (int)ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == 0)
                            {
                                ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = 1;
                            }
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                            if ((int)ultraGrid.Rows[rowIndex].Cells[BLTIEM_ODER].Value == this._itemBindTable.Rows.Count)
                            {
                                // �ŏI�s�̏ꍇ�A�s��ǉ�
                                this.ItemGrid_AddRow();
                                ultraGrid.Rows[rowIndex + 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;

                            }

                           
                        }
                        else
                        {
                            // �d���G���[��\��
                            TMsgDisp.Show(
                                this,								    // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                                ASSEMBLY_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�I������BL�R�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				    // �\������{�^��
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value = DBNull.Value;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                            ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                            this.UGrid_ItmSt.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                            this._beforeBLGoodsCode = 0;
                            this._ItemGridUpdFlg = false;
                        }


                    }
                    else
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BL�R�[�h [" + blCode.ToString() + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        // BL�R�[�h�����ɖ߂�
                        //cell.Value = this._beforeBLGoodsCode;
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSCODE_TITLE].Value = DBNull.Value;
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                        ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                        this.UGrid_ItmSt.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                        this._beforeBLGoodsCode = 0;
                        this._ItemGridUpdFlg = false;
                    }


                }
                else
                {
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSNAME_TITLE].Value = string.Empty;
                    ultraGrid.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = DBNull.Value;
                    this.UGrid_ItmSt.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                    this._beforeBLGoodsCode = 0;
                }
            }
           
        }
       
        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

            // �ŉ��i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // �ۑ��{�^���ֈړ�
                return this.Renewal_Button;
                
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.UGrid_Customer.ActiveCell.Column.Index;
                int prevRow = this.UGrid_Customer.ActiveCell.Row.Index;

                // ���̃Z���Ɉړ�
                performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.UGrid_Customer.ActiveCell.Column.Index) &&
                    (prevRow == this.UGrid_Customer.ActiveCell.Row.Index))
                {
                    // �ۑ��{�^���ֈړ�
                    return this.Renewal_Button;
                   
                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_Customer.CurrentState;

            // �ŏ�i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // �ړ����Ȃ�
                // �L�����y�[���R�[�h�ֈړ�
                return this.DeleteCustomerRow_Button;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveLeftCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �ō��i�Z���̎�
            if (this.UGrid_Customer.ActiveCell.Column.Key.Equals(MY_SCREEN_CUSTOMER_CODE))
            {  // �ړ����Ȃ�
                return null;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                if (performActionResult)
                {
                    if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
               
                return null;

            }
        }

        /// <summary>
        /// �E�̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control CustomerMoveRightCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            // �A�N�e�B�u�Z����null
            if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_Customer.ActiveCell == null && this.UGrid_Customer.ActiveRow != null)
            {
                this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }
            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                this.UGrid_Customer.BeginUpdate();

                // �ŉE�i�Z���̎�
                if (this.UGrid_Customer.ActiveCell.Column.Key.Equals(MY_SCREEN_CUSTOMER_NAME))
                {
                    // �ۑ��{�^���ֈړ�
                    return null;

                }
                // �ŉ��i�Z���łȂ���
                else
                {
                    // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                    int prevCol = this.UGrid_Customer.ActiveCell.Column.Index;
                    int prevRow = this.UGrid_Customer.ActiveCell.Row.Index;

                    // ���̃Z���Ɉړ�UltraGridAction
                    performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }

                    return null;

                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.UGrid_Customer.EndUpdate();
            }
        }

        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            // �A�N�e�B�u�Z����null
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;

            // �ŉ��i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // �ۑ��{�^���ֈړ�
                return this.Renewal_Button;
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.UGrid_ItmSt.ActiveCell.Column.Index;
                int prevRow = this.UGrid_ItmSt.ActiveCell.Row.Index;

                // ���̃Z���Ɉړ�
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.UGrid_ItmSt.ActiveCell.Column.Index) &&
                    (prevRow == this.UGrid_ItmSt.ActiveCell.Row.Index))
                {
                    // �ۑ��{�^���ֈړ�
                   return this.Renewal_Button;
                    
                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.UGrid_ItmSt.CurrentState;

            // �ŏ�i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // �ړ����Ȃ�
                // �L�����y�[���R�[�h�ֈړ�
                return this.DeleteBlCodeRow_Button;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveLeftCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            // �A�N�e�B�u�Z����null
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �ō��i�Z���̎�
            if (this.UGrid_ItmSt.ActiveCell.Column.Key.Equals(BLGOODSCODE_TITLE))
            {
                return null;
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.UGrid_ItmSt.ActiveCell.Column.Index;
                int prevRow = this.UGrid_ItmSt.ActiveCell.Row.Index;

                // ���̃Z���Ɉړ�
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.UGrid_ItmSt.ActiveCell.Column.Index) &&
                    (prevRow == this.UGrid_ItmSt.ActiveCell.Row.Index))
                {
                    return null;

                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private Control ItmStMoveRightCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow == null)
            {
                return null;
            }
            else if (this.UGrid_ItmSt.ActiveCell == null && this.UGrid_ItmSt.ActiveRow != null)
            {
                this.UGrid_ItmSt.ActiveRow.Cells[BLGOODSCODE_TITLE].Activate();
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                return null;
            }

            // �ŉE�i�Z���̎�
            if (this.UGrid_ItmSt.ActiveCell.Column.Key.Equals(BLGOODSQTY_TITLE))
            {
                // �ړ����Ȃ�
                return null;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                if (performActionResult)
                {
                    if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool CustomerMoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_Customer.ActiveCell != null))
            {
                if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ItmStMoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_ItmSt.ActiveCell != null))
            {
                if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Prev�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Prev�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	�O�̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool CustomerMovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_Customer.ActiveCell != null))
            {
                if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.UGrid_Customer.ActiveCell.Row.Index;
                            if (this._customerBindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE] == DBNull.Value)
                            {
                                // ���Ӑ�R�[�h�������͂̏ꍇ
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Prev�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Prev�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	�O�̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private bool ItmStMovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.UGrid_ItmSt.ActiveCell != null))
            {
                if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.UGrid_ItmSt.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.UGrid_ItmSt.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.UGrid_ItmSt.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.UGrid_ItmSt.ActiveCell.Row.Index;
                            if (this._itemBindTable.Rows[rowIdx][BLTIEM_ODER] == DBNull.Value)
                            {
                                // ���Ӑ�R�[�h�������͂̏ꍇ
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.UGrid_ItmSt.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	ultraGrid.Click �C�x���g(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID��Cell Button���N���b�N�C�x���g�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_Customer_ClickCellButton(object sender, CellEventArgs e)
        {

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._customerBindTable.Rows.Count;
                int doubleIndex = -1;
                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                   if (this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] == DBNull.Value || (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] == 0)
                    {
                        continue;
                    }
                    int customerCode = (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                    
                    if (customerCode == _customerCode)
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        doubleIndex = i;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // �I����������Cell�ɐݒ�
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = _customerCode;    // ���Ӑ�R�[�h
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = _customerName;                    // ���Ӑ於
                    e.Cell.Row.Cells[MY_INQORIGINALEPCD].Value = _inqOriginalEpCd.Trim();                    // �⍇������ƃR�[�h//@@@@20230303
                    e.Cell.Row.Cells[MY_INQORIGINALSECCD].Value = _inqOriginalSecCd;                    // �⍇�������_�R�[�h

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._customerBindTable.Rows.Count)
                    {
                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                        this.CustomerGrid_AddRow();
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.CustomerMoveNextAllowEditCell(false);
                }
                else
                {
                    if (doubleIndex != e.Cell.Row.Index)
                    {
                        // �d���G���[��\��
                        TMsgDisp.Show(
                            this,								    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                            ASSEMBLY_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            "�I���������Ӑ�R�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				    // �\������{�^��

                        ((Control)sender).Focus();
                    }
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �{�^�����N���b�N���ꂽ�ۂ̃C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_ItmSt_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid ug = (UltraGrid)sender;
            UltraGridRow activeRow = ug.ActiveRow;

            //BL�R�[�h�K�C�h
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            //BL�R�[�h�K�C�h�N��
            int status = _bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                ((Control)sender).Focus();
                return;
            }
            else
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._itemBindTable.Rows.Count;
                _beforeBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                int doubleIndex = -1;
                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    if (this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == DBNull.Value || (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] == 0)
                    {
                        continue;
                    }
                    int bLGoodsCode = (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE];

                    if (bLGoodsCode == _beforeBLGoodsCode)
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        doubleIndex = i;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // �I����������Cell�ɐݒ�
                    activeRow.Cells[BLGOODSCODE_TITLE].Value = bLGoodsCdUMnt.BLGoodsCode;
                    activeRow.Cells[BLGOODSNAME_TITLE].Value = bLGoodsCdUMnt.BLGoodsHalfName;
                    int rowIndex = activeRow.Index;
                    ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                    if (ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == DBNull.Value || (int)ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value == 0)
                    {
                        ug.Rows[rowIndex].Cells[BLGOODSQTY_TITLE].Value = 1;
                    }
                    if ((int)activeRow.Cells[BLTIEM_ODER].Value == this._itemBindTable.Rows.Count)
                    {
                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                        this.ItemGrid_AddRow();
                        ug.Rows[rowIndex + 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.ItmStMoveNextAllowEditCell(false);
                }
                else
                {
                    if (doubleIndex != e.Cell.Row.Index)
                    {
                        // �d���G���[��\��
                        TMsgDisp.Show(
                            this,								    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                            ASSEMBLY_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            "�I������BL�R�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				    // �\������{�^��

                        ((Control)sender).Focus();
                    }
                }
            }
           
        }

        /// <summary>
        /// Control.Click �C�x���g(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerDeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.UGrid_Customer.Rows.Count < 1)
            {
                // �f�o�b�O�p
                this.CustomerGrid_AddRow();
            }

            if (this.UGrid_Customer.ActiveRow == null)
            {
                // �폜����s�����I��
                message = "�폜���链�Ӑ�R�[�h��I�����ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UGrid_Customer.Focus();
            }
            else if (this.UGrid_Customer.Rows.Count == 1)
            {
                // Grid�̍s����1�s�̏ꍇ�͍폜�s��
                message = "�S�Ă̓��Ӑ���폜�͂ł��܂���";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UGrid_Customer.Focus();
            }
            else
            {
                // UI��ʂ�Grid����I���s���폜
                // �I���s��index���擾
                int delIndex = (int)this.UGrid_Customer.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // �I���s�̍폜
                this.UGrid_Customer.ActiveRow.Delete();

                // �폜���Grid�s�����擾
                int maxRow = this._customerBindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // �폜�����s�ȍ~�̕\�����ʂ��X�V����
                    this._customerBindTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
                if (delIndex > 0)
                {
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void DeleteBlCodeRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.UGrid_ItmSt.Rows.Count < 1)
            {
                // �f�o�b�O�p
                this.ItemGrid_AddRow();
                this.UGrid_ItmSt.Rows[0].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
            }

            if (this.UGrid_ItmSt.ActiveRow == null)
            {
                // �폜����s�����I��
                message = "�폜����BL���i�R�[�h��I�����ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UGrid_ItmSt.Focus();
            }
            else if (this.UGrid_ItmSt.Rows.Count == 1)
            {
                // Grid�̍s����1�s�̏ꍇ�͍폜�s��
                message = "�S�Ă�BL���i�R�[�h���폜�͂ł��܂���";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UGrid_ItmSt.Focus();
            }
            else
            {
                // UI��ʂ�Grid����I���s���폜
                // �I���s��index���擾
                int delIndex = (int)this.UGrid_ItmSt.ActiveRow.Cells[BLTIEM_ODER].Value - 1;

                // �I���s�̍폜
                this.UGrid_ItmSt.ActiveRow.Delete();

                // �폜���Grid�s�����擾
                int maxRow = this._itemBindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // �폜�����s�ȍ~�̕\�����ʂ��X�V����
                    this._itemBindTable.Rows[index][BLTIEM_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Guid_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CustomerGuid_Button_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._customerBindTable.Rows.Count;

                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    if (this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE] != DBNull.Value)
                    {
                        int code = (int)this._customerBindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                        if ((code != 0) && (code == _customerCode))
                        {
                            // �d���R�[�h�L
                            AddFlg = false;
                            break;
                        }
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._customerBindTable.Rows.Count - 1;

                    if (this._customerBindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] == DBNull.Value)
                    {
                        // �ŏI�s����
                        this._customerBindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] = _customerCode;
                        this._customerBindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_NAME] = _customerName;
                        this._customerBindTable.Rows[lastRow][MY_INQORIGINALEPCD] = _inqOriginalEpCd.Trim();//@@@@20230303
                        this._customerBindTable.Rows[lastRow][MY_INQORIGINALSECCD] = _inqOriginalSecCd;
                    }
                    else
                    {
                        // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
                        DataRow bindRow;

                        bindRow = this._customerBindTable.NewRow();

                        // ���Ӑ����Grid�ɒǉ�
                        bindRow[MY_SCREEN_ODER] = this._customerBindTable.Rows.Count + 1;
                        bindRow[MY_SCREEN_CUSTOMER_CODE] = _customerCode;
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _customerName;
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _inqOriginalEpCd.Trim();//@@@@20230303
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _inqOriginalSecCd;

                        this._customerBindTable.Rows.Add(bindRow);
                    }

                    // �V�K�s��ǉ�
                    this.CustomerGrid_AddRow();
                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // �d���G���[��\��
                    string message = "�I���������Ӑ�R�[�h�͑I���ςł��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Guid_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void BlCodeGuid_Button_Click(object sender, EventArgs e)
        {
            //BL�R�[�h�K�C�h
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            //BL�R�[�h�K�C�h�N��
            int status = _bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }
            else
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._itemBindTable.Rows.Count;
                int blCode = bLGoodsCdUMnt.BLGoodsCode;
                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    if (this._itemBindTable.Rows[i][BLGOODSCODE_TITLE] != DBNull.Value)
                    {
                        int code = (int)this._itemBindTable.Rows[i][BLGOODSCODE_TITLE];
                        if ((code != 0) && (code == blCode))
                        {
                            // �d���R�[�h�L
                            AddFlg = false;
                            break;
                        }
                    }
                }
                if (AddFlg)
                {
                    int lastRow = this._itemBindTable.Rows.Count - 1;

                    if (this._itemBindTable.Rows[lastRow][BLGOODSCODE_TITLE] == DBNull.Value)
                    {
                        // �ŏI�s����
                        this._itemBindTable.Rows[lastRow][BLGOODSCODE_TITLE] = bLGoodsCdUMnt.BLGoodsCode;
                        this._itemBindTable.Rows[lastRow][BLGOODSNAME_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName; 
                        this.UGrid_ItmSt.Rows[lastRow].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        this.UGrid_ItmSt.Rows[lastRow].Cells[BLGOODSQTY_TITLE].Value = 1;
                    }
                    else
                    {
                        // �K�C�h�őI������BL�R�[�h��ǉ�
                        DataRow bindRow;

                        bindRow = this._itemBindTable.NewRow();

                        // ���Ӑ����Grid�ɒǉ�
                        bindRow[BLTIEM_ODER] = this._itemBindTable.Rows.Count + 1;
                        bindRow[BLGOODSCODE_TITLE] = bLGoodsCdUMnt.BLGoodsCode;
                        bindRow[BLGOODSNAME_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;
                        this._itemBindTable.Rows.Add(bindRow);
                        this.UGrid_ItmSt.Rows[lastRow + 1].Cells[BLGOODSQTY_TITLE].Activation = Activation.AllowEdit;
                        this.UGrid_ItmSt.Rows[lastRow + 1].Cells[BLGOODSQTY_TITLE].Value = 1;
                       
                    }

                    // �V�K�s��ǉ�
                    this.ItemGrid_AddRow();
                    this.UGrid_ItmSt.Rows[UGrid_ItmSt.Rows.Count -1 ].Cells[BLGOODSQTY_TITLE].Activation = Activation.NoEdit;
                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // �d���G���[��\��
                    string message = "�I������BL�R�[�h�͑I���ςł��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    ((Control)sender).Focus();
                }


               
            }


           
        }

        /// <summary>
        /// �ŐV��񏈗�
        /// </summary>
        /// <remarks>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <br>Note       : �ŐV��񏈗����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // �ŐV���擾
            this._pccCpMsgStAcs.Renewal();
            this._customerHTable = this._pccCpMsgStAcs.CustomerHTable;
            this._bLCodeTable = this._pccCpMsgStAcs.BLCodeTable;
            this._scmEpScCntTable = this._pccCpMsgStAcs.ScmEpScCntTable;
            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010.11.20</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        #endregion

        /// <summary>
        /// �L�����y�[�� �K�C�h�N��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[�� �K�C�h�N���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void uButton_CampaignGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignStOld;
                CampaignSt campaignSt;

                // �K�C�h�N��
                int status = _campaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignStOld);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    campaignSt = this._pccCpMsgStAcs.GetCampaignSt(campaignStOld.CampaignCode);
                    if (campaignSt != null)
                    {
                        if ("00".Equals(campaignSt.SectionCode.TrimEnd()) || string.IsNullOrEmpty(campaignSt.SectionCode.TrimEnd()) || this._loginSectionCode.Equals(campaignSt.SectionCode))
                        {
                            // ���ʃZ�b�g
                            this.tNedit_CampaignCode.SetInt(campaignSt.CampaignCode);
                            this.tEdit_CampaignName.Text = campaignSt.CampaignName;
                            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                            this.Insert_Button.Enabled = true;
                            // ���t�H�[�J�X
                            this.SelectNextControl((Control)sender, true, true, true, true);
                        }
                        else
                        {
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���_�͑ΏۊO�̂��߁A���̃L�����y�[���͑I���ł��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                            // ���Ӑ�̃N���A
                            this.tNedit_CampaignCode.Clear();
                            this.tEdit_CampaignName.Text = "";
                            this.Insert_Button.Enabled = false;
                            DispToPccCpMsgSt(ref this._pccCpMsgStInsert, out this._pccCpTgtStDicCloneInsert, out this._pccCpItmStDicCloneInsert);
                        }
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �Ώۓ��Ӑ�敪�ύX����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ώۓ��Ӑ�敪�ύX�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void CampaignObjDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            int campaignObjDiv = (int)CampaignObjDiv_tComboEditor.Value;
            if (campaignObjDiv == 0)
            {
                //�S���Ӑ�̏ꍇ�́A���Ӑ�R�[�h���ו�����͕s�Ƃ���B
                this._customerBindTable.Clear();
                this.DeleteCustomerRow_Button.Enabled = false;
                this.CustomerGuid_Button.Enabled = false;
            }
            else if(campaignObjDiv == 1)
            {
                this.DeleteCustomerRow_Button.Enabled = true;
                this.CustomerGuid_Button.Enabled = true;
                this.CustomerGrid_AddRow();
            }
        }

        /// <summary>
        ///  �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {

            UltraGrid ultraGrid = (UltraGrid)sender;

            if (ultraGrid.ActiveCell == null)
            {
                return;
            }
            string columnKey = ultraGrid.ActiveCell.Column.Key;
            int numLen = 0;
            //
            if (BLGOODSCODE_TITLE.Equals(columnKey))
            {
                //BL�R�[�h
                numLen = 8;
            }
            else if (BLGOODSQTY_TITLE.Equals(columnKey))
            {
                //BL����
                numLen = 3;
            }
            else if (MY_SCREEN_CUSTOMER_CODE.Equals(columnKey))
            {
                //���Ӑ�R�[�h
                numLen = 8;
            }
            if (ultraGrid.ActiveCell.Column.DataType == typeof(Int32))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = ultraGrid.ActiveCell.EditorResolved;
                string currentEditText = editorBase.CurrentEditText;
                bool checkNumber = IsDigitAdd(currentEditText, numLen);
                if (!checkNumber)
                {
                    if (BLGOODSQTY_TITLE.Equals(columnKey))
                    {
                        ultraGrid.ActiveCell.Value = 0;
                    }
                    else
                    {
                        ultraGrid.ActiveCell.Value = DBNull.Value;
                    }
                }

            }
            e.RaiseErrorEvent = false;   // �G���[�C�x���g�͔��������Ȃ�
            e.RestoreOriginalValue = false;  // �Z���̒l�����ɖ߂��Ȃ� 
            e.StayInEditMode = false;   // �ҏW���[�h�͔�����
        }

        /// <summary>
        /// �O���b�h�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�V���������㎞�ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private void UGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    UltraGridCell ugCell = ultraGrid.ActiveCell;
                    if ((ugCell != null) &&
                        (ugCell.Column.CellActivation == Activation.AllowEdit) &&
                        (ugCell.Activation == Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (ultraGrid.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (ultraGrid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if ((ultraGrid.ActiveCell.Value is System.DBNull) ||
                                            (ultraGrid.ActiveCell.Value == DBNull.Value))
                                        {
                                        }
                                        else
                                        {
                                            if (ultraGrid.ActiveCell.IsInEditMode)
                                            {
                                                // �S�I��
                                                ultraGrid.ActiveCell.SelectAll();
                                            }
                                        }
                                    }
                                    break;
                                }
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Button:
                                {
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    ultraGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
        
        # endregion
    }
}
