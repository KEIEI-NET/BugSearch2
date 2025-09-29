//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PCC�S�̐ݒ�
// �v���O�����T�v   : PCC�S�̐ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �t�I��
// �� �� ��  2011.08.01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �C �� ��  2011/09/17  �C�����e : �uPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C���@for redmine24899
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC�S�̐ݒ�}�X�^�\���ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�S�̐ݒ�}�X�^���̐ݒ�̐ݒ���s���܂��B</br>
    /// <br>Programmer : �t�I��</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: 2011/09/17 ���N�n��</br>
    /// <br>	         rPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C��</br>
    /// <br></br>
    /// </remarks>
    public partial class PMPCC09000UA : Form, IMasterMaintenanceMultiType
    {
        #region Constructor
      
        /// <summary>
        /// PCC�S�̐ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�S�̐ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br></br>
        /// <br>Update Note: 2011/09/17 ���N�n��</br>
        /// <br>	         rPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C��</br>
        /// <br></br>
        /// </remarks>
        public PMPCC09000UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //_sectionCode�擾
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            _pccTtlStAcs = new PccTtlStAcs();
            this._pccTtlStTable = new Hashtable();
            this._userGuideAcs = new UserGuideAcs(); // ADD 2011/09/17

            // �v���p�e�B�[�ϐ�������
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = true;
            this._dataIndex = -1;
            this._canSpecificationSearch = false;
            this.totalCount = 0;

        }
       
        #endregion

        #region Private Members
        private string _enterpriseCode;    // ��ƃR�[�h
        private string _sectionCode;      //���_�R�[�h
        private const string PCCTTLST_TABLE = "PCCTTLST";
        private Hashtable _pccTtlStTable;
        private Hashtable _userGdBdTb;// ADD 2011/09/17
        private UserGuideAcs _userGuideAcs;// ADD 2011/09/17
        private bool _modeFlg = false;
        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string UPDATEDATETIME_DATE = "�X�V��";
        private const string DELETE_DATE = "�폜��";
        private const string SECTIONCODE_TITLE = "���_�R�[�h";
        private const string SECTIONGUIDENM_TITLE = "���_����";
        private const string FRONTEMPLOYEECD_TITLE = "��t�]�ƈ��R�[�h";
        private const string FRONTEMPLOYEENM_TITLE = "��t�]�ƈ�����";
        private const string DELIVEREDGOODSDIV_TITLE = "�[�i�敪";
        private const string SALESSLIPPRTDIV_TITLE = "����`�[���s�敪";
        private const string ACPODRRSLIPPRTDIV_TITLE = "�󒍓`�[����敪";
        private const string GUID_TITLE = "GUID";

        // �ҏW���[�h
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string INSERT_MODE = "�V�K���[�h";
        private const string DELETE_MODE = "�폜���[�h";
      
        // Message�֘A��`
        private const string CT_PGID = "PMPCC09000U";
        private const string CT_PGNM = "���Аݒ�";
        private const string ASSEMBLY_ID = "PMPCC09000U";
        private const string ERR_SEAR_TIME_MSG = "�������Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�������s�Ȃ��Ă��������B";
        private const string ERR_WRITE_TIME_MSG = "�X�V���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string ERR_DEL_TIME_MSG = "�폜���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string SECTION_00_MES = "�S��";
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// ���Аݒ�}�X�^ �A�N�Z�X�N���X
        /// </summary>
        private PccTtlStAcs _pccTtlStAcs = null;
        private PccTtlSt _pccTtlSt = null;
        // ��r�p�N���[��
        private PccTtlSt _pccTtlSClone;   // ��r�p�S�̍��ڕ\�����̃N���X
        private int totalCount;
        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private int _detailsIndexBuf;
        // �K�C�h�n�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;
        private Hashtable _employeeTb = null;
        private SecInfoSetAcs _secInfoSetAcs;
        private Hashtable _sectionTb = null;
        /// <summary>
        /// �K�C�h�敪=48:�[�i�敪
        /// </summary>
        private const int USERGUIDEDIVCD = 48;      
        private int _preFrontEmployeeCd = 0;
        //�O�̋��_�R�[�h
        private int _preSectionCd = 0;//ADD by huanghx for Redmine24889 on 20110914 
        
        #endregion

        #region  Events
       
        /// <summary>
        /// ��ʔ�\���C�x���g
        /// </summary>
        /// <remarks>
        /// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
        /// </remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        # endregion

        #region Properties

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
       
        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;

            }
        }
      
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;

            }
        }
      
        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;

            }
        }
      
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;

            }
        }
      
        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get { return this._canSpecificationSearch; }
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
            get { return this._defaultAutoFillToColumn; }
        }


        #endregion

        #region Public Methods
      
        /// <summary>
        /// ��ʏ��S�̍��ڕ\�����̃N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̍��ڕ\�����̃N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
          
            // ���_�R�[�h
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // ���_����
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �]�ƈ�
            appearanceTable.Add(FRONTEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �]�ƈ�����
            appearanceTable.Add(FRONTEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // �[�i�敪
            appearanceTable.Add(DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ����`�[���s�敪
            appearanceTable.Add(SALESSLIPPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �󒍓`�[����敪
            appearanceTable.Add(ACPODRRSLIPPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
          
            //GUID_TITLE
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
      
        /// <summary>
        /// ��ʏ��S�̍��ڕ\�����̃N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <param name="tableName">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
        /// <param name="bindDataSet">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̍��ڕ\�����̃N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PCCTTLST_TABLE;
        }
     
        /// <summary>
        ///  Print
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            // ����A�Z���u�������[�h����i�������j
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
     
        /// <summary>
        /// ���_��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            const string ctPROCNM = "Search";
            PccTtlSt parsepccTtlSt = new PccTtlSt();
            List<PccTtlSt> pccTtlStList = null;
            parsepccTtlSt.EnterpriseCode = this._enterpriseCode;
            if (this._pccTtlStTable.Count == 0)
            {
                status = this._pccTtlStAcs.Search(ref pccTtlStList, parsepccTtlSt, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.totalCount = pccTtlStList.Count;                            
                            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Clear();
                            this._pccTtlStTable.Clear();
                           
                            //�S�̐ݒ�N���X���f�[�^�Z�b�g�֓W�J����
                            int index = 0;
                            foreach (PccTtlSt pccTtlSt in pccTtlStList)
                            {
                                if (this._pccTtlStTable.ContainsKey(pccTtlSt.FileHeaderGuid) == false)
                                {
                                    PccTtlStToDataSet(pccTtlSt.Clone(), index);
                                    ++index;
                                }
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // �T�[�`
                            TMsgDisp.Show(
                                this,                               // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                                CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Name,                          // �v���O��������
                                ctPROCNM,                           // ��������
                                TMsgDisp.OPE_GET,                   // �I�y���[�V����
                                ERR_SEAR_TIME_MSG,                  // �\�����郁�b�Z�[�W
                                status,                             // �X�e�[�^�X�l
                                this._pccTtlStAcs,                // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,               // �\������{�^��
                                MessageBoxDefaultButton.Button1);   // �����\���{�^��
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_STOPDISP,
                           this.Name,
                           "�ǂݍ��݂Ɏ��s���܂����B",
                           status,
                           MessageBoxButtons.OK);
                            break;
                        }
                }
            }

            else
            {
                this.totalCount = this._pccTtlStTable.Count;
                SortedList sortedList = new SortedList();

                //�S�̐ݒ�N���X���f�[�^�Z�b�g�֓W�J����
                int index = 0;
                foreach (PccTtlSt pccTtlSt in sortedList.Values)
                {
                    PccTtlStToDataSet(pccTtlSt.Clone(), index);
                    ++index;
                }
            }
            // �߂�l�Z�b�g
            totalCount = this.totalCount;

            return status;
        }
      
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }
     
        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Delete()
        {

            const string ctPROCNM = "LogicalDelete";
            PccTtlSt pccTtlSt = null;
  
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex][GUID_TITLE];
            pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];           

            int status;
            int dummy = 0;
            //�S�̐ݒ�_���폜����
            status = this._pccTtlStAcs.LogicalDelete(ref pccTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        PccTtlStToDataSet(pccTtlSt.Clone(), this.DataIndex);
                         
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        //�S�̐ݒ�N���X�f�[�^�Z�b�g�W�J����
                        this._pccTtlStTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_DEL_TIME_MSG,                   // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pccTtlStAcs,                // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            CT_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._pccTtlStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        //�S�̐ݒ�N���X�f�[�^�Z�b�g�W�J����
                        this._pccTtlStTable.Clear();
                        this.Search(ref dummy, 0);

                        return status;
                    }
            }
         
            return status;
        }
     
        # endregion Public Methods

        #region  Control Events
      
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �t�I��</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>
        private void PMPCC09000UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �v���p�e�B�̏����ݒ�
            this._canPrint = false;
            this._canClose = false;
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;           // �ۑ��{�^��
            this.Cancel_Button.ImageList = imageList24;           // ����{�^��
            this.Revive_Button.ImageList = imageList24;           //�����{�^��
            this.Delete_Button.ImageList = imageList24;           //���S�폜�{�^��

            this.uButtonFrontEmployeeCdGuid.ImageList = imageList16;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;     // �ۑ��{�^��
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // ����{�^��
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;  //�����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;   //���S�폜�{�^��
            this.uButtonFrontEmployeeCdGuid.Appearance.Image = Size16_Index.STAR1;//�K�C�h�{�^��
            this.SectionGuide_ultraButton1.ImageList = imageList16;
            this.SectionGuide_ultraButton1.Appearance.Image = Size16_Index.STAR1;//�K�C�h�{�^��
            this.Initial_Timer.Enabled = true;         
        }
      
        /// <summary>
        /// Form.FormClosing �C�x���g (PMPCC09000UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[������邽�тɁA�t�H�[����������O�A����ѕ��闝�R���w�肷��O�ɔ������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void PMPCC09000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._detailsIndexBuf = -2;
            // �`�F�b�N�p�N���[��������
            this._pccTtlSClone = null;

            // ���[�U�[�ɂ���ĕ�����ꍇ
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z�����ăt�H�[�����\��������B
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }
     
        /// <summary>
        /// Form.VisibleChanged �C�x���g (PMPCC09000UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void PMPCC09000UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            this.Initial_Timer.Enabled = true;
           
        }
      
        /// <summary>
        /// Timer.Tick �C�x���g (Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this.ScreenReconstruction();
        }
      
        /// <summary>
        /// Ok_Button_Click �C�x���g (Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // �t�H�[�������
            this.CloseForm(DialogResult.OK);

            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            // Grid��IndexBuffer�i�[�p�ϐ��̏�����
            this._detailsIndexBuf = -2;

        }
      
        /// <summary>
        /// Cancel_Button_Click �C�x���g (Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                PccTtlSt comparePccTtlSt = new PccTtlSt();
                comparePccTtlSt = this._pccTtlSClone.Clone();
                this._detailsIndexBuf = this._dataIndex;

                //���݂̉�ʏ����擾����
                DispToPccTtlSt(ref comparePccTtlSt);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._pccTtlSClone.Equals(comparePccTtlSt)))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    // �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                         this,								// �e�E�B���h�E�t�H�[��
                         emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                         ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                         "",									// �\�����郁�b�Z�[�W 
                         0,									// �X�e�[�^�X�l
                         MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // �o�^����
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;
                                break;
                            }
                        default:
                            {
                                if (_modeFlg)
                                {
                                    this.tEdit_FrontEmployeeCd.Focus();
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
            }
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            // Grid��IndexBuffer�i�[�p�ϐ��̏�����
            this._detailsIndexBuf = -2;

            this.DialogResult = DialogResult.Cancel;
            
            this.Close();  
        }
     
        /// <summary>
        /// uButtonFrontEmployeeCdGuid_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���o����͈͂��w�肷��B</br>
        /// <br>Programmer	: �t�I��</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>
        private void uButtonFrontEmployeeCdGuid_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                tEdit_FrontEmployeeCd.Value = employee.EmployeeCode.TrimEnd();
                tEdit_FrontEmployeeNm.Text = employee.Name;
                _preFrontEmployeeCd = tEdit_FrontEmployeeCd.GetInt(); //ADD by huanghx for Redmine24889 on 20110914
            }

        }
      
        /// <summary>
        /// ChangeFocus �C�x���g(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �t�I��</br>
        /// <br>Date        : 2011.08.01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_FrontEmployeeCd":
                    {
                        int frontEmployeeCd = tEdit_FrontEmployeeCd.GetInt();
                        if (frontEmployeeCd != 0)
                        {
                            if (frontEmployeeCd != _preFrontEmployeeCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }
                                string employeeNm = GetFrontEmployeeNm(frontEmployeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    // this.tEdit_FrontEmployeeNm.Clear();//DEL by huanghx for Redmine24889 on 20110914

                                    //  _preFrontEmployeeCd = 0;//DEL by huanghx for Redmine24889 on 20110914

                                    //-----ADD by huanghx for Redmine24889 on 20110914 ----->>>>>
                                    this.tEdit_FrontEmployeeCd.SetInt(_preFrontEmployeeCd);
                                    // ���̓`�F�b�N
                                    TMsgDisp.Show(
                                        this,                                  // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                                        CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                                        "�]�ƈ������݂��܂���B",                               // �\�����郁�b�Z�[�W
                                        0,                                     // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);                // �\������{�^��
                                    e.NextCtrl = tEdit_FrontEmployeeCd;
                                    return;
                                    //-----ADD by huanghx for Redmine24889 on 20110914 -----<<<<<
                                }
                                else
                                {
                                    this.tEdit_FrontEmployeeNm.Text = employeeNm;
                                    _preFrontEmployeeCd = frontEmployeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_FrontEmployeeNm.Text = string.Empty;
                            _preFrontEmployeeCd = 0;
                        }
                        //----ADD by huanghx for #24889 on 20110914 ----->>>>>
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(this.tEdit_FrontEmployeeNm.Text.TrimEnd()))
                                {
                                    e.NextCtrl = tComboEditor1;
                                }
                            }
                        }
                        else if (e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(tEdit_SectionName.Text.TrimEnd()))
                                {
                                    e.NextCtrl = tEdit_SectionCode;
                                }
                            }
                        }
                        //----ADD by huanghx for #24889 on 20110914 -----<<<<<
                        break;
                    }
                case "tEdit_SectionCode":
                    {
                        //-----DEL by huanghx for Redmine24889 on 20110914 ----->>>>>
                        //// ���_�R�[�h�������͂̏ꍇ
                        //                   if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.TrimEnd()))
                        //                   {
                        //                       this.tEdit_SectionName.DataText = string.Empty;
                        //                       return;
                        //                   }
                        //                   // ���_�R�[�h�擾
                        //                   string sectionCode = this.tEdit_SectionCode.GetInt().ToString().PadLeft(2, '0');

                        //                   // ���_���̎擾
                        //                   this.tEdit_SectionName.DataText = GetSectionName(sectionCode.TrimEnd());
                        //                   // ���_�R�[�h�Ƀt�H�[�J�X������ꍇ
                        //                   if (e.Key == Keys.Enter)
                        //                   {
                        //                       if (this.tEdit_SectionName.DataText != "")
                        //                       {
                        //                           // ���_�R�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        //                           e.NextCtrl = this.tEdit_FrontEmployeeCd;
                        //                       }

                        //                   }
                        //                   if (this._dataIndex < 0)
                        //                   {
                        //                       if (ModeChangeProc(sectionCode.TrimEnd()))
                        //                       {

                        //                           e.NextCtrl = tEdit_SectionCode;
                        //                       }
                        //                   }

                        //                   break;
                        //-----DEL by huanghx for Redmine24889 on 20110914 -----<<<<<
                        //-----ADD by huanghx for Redmine24889 on 20110914 ----->>>>>

                        // ���_�R�[�h�擾
                        string sectionCode = this.tEdit_SectionCode.GetInt().ToString().PadLeft(2, '0');
                        string sectionName = GetSectionName(sectionCode.TrimEnd());
                        if (string.IsNullOrEmpty(sectionName))
                        {
                            // ���̓`�F�b�N
                            TMsgDisp.Show(
                                this,                                  // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                                CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                                "���_�����݂��܂���B",                               // �\�����郁�b�Z�[�W
                                0,                                     // �X�e�[�^�X�l
                                MessageBoxButtons.OK);                // �\������{�^��
                            tEdit_SectionCode.Clear();
                            tEdit_SectionName.Clear();
                            return;
                        }
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc(sectionCode.TrimEnd()))
                            {
                                //e.NextCtrl = tEdit_SectionCode; 
                                return;
                            }
                            else
                            {
                                // ���_���̎擾
                                this.tEdit_SectionName.DataText = sectionName;
                            }
                        }
                        this._preSectionCd = tEdit_SectionCode.GetInt();
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (this.tEdit_SectionCode.GetInt() != 0)
                                {
                                    e.NextCtrl = tEdit_FrontEmployeeCd;
                                }
                            }
                        }
                        break;
                    }
                //add start by wujun for Redmine#24893 on 2011.09.13
                // ���_�R�[�h�K�C�h�Ƀt�H�[�J�X������ꍇ
                case "SectionGuide_ultraButton1":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = SectionGuide_ultraButton1;
                        }
                        break;
                    }
                //-----ADD by huanghx for Redmine24889 on 20110914 -----<<<<<
                // �󒍎҃K�C�h�Ƀt�H�[�J�X������ꍇ
                case "uButtonFrontEmployeeCdGuid":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = uButtonFrontEmployeeCdGuid;
                        }
                        break;
                    }
                // �[�i�敪�Ƀt�H�[�J�X������ꍇ
                case "tComboEditor1":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tComboEditor1;
                        }
                        else if (e.Key == Keys.Up)
                        {
                            e.NextCtrl = tEdit_FrontEmployeeCd;
                        }
                        else if (e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(tEdit_FrontEmployeeNm.Text.TrimEnd()))
                                {
                                    e.NextCtrl = tEdit_FrontEmployeeCd;
                                }
                            }
                        }
                        break;
                    }
                // ����`�[���s�敪�Ƀt�H�[�J�X������ꍇ
                case "tComboEditor_SalesSlipPrtDiv":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tComboEditor_SalesSlipPrtDiv;
                        }
                        break;
                    }
                // �󒍓`�[����敪�Ƀt�H�[�J�X������ꍇ
                case "tComboEditor_AcpOdrrSlipPrtDiv":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tComboEditor_AcpOdrrSlipPrtDiv;
                        }
                        break;
                    }
                //add end by wujun for Redmine#24893 on 2011.09.13
            }
        }
     
        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private void SectionGuide_ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this._secInfoSetAcs == null)
                {
                    this._secInfoSetAcs = new SecInfoSetAcs();
                }

                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (!ModeChangeProc(secInfoSet.SectionCode.ToString().TrimEnd()))
                    {
                        tEdit_SectionCode.Value = secInfoSet.SectionCode.Trim();
                        _preSectionCd = tEdit_SectionCode.GetInt();//ADD by huanghx for Redmine24889 on 20110914
                        tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                        this.Ok_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }      
      
        /// <summary>
        /// Delete_Button_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: �t�I��</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "Delete";
            PccTtlSt pccTtlSt = new PccTtlSt();

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(            
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                CT_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                 0, 									// �X�e�[�^�X�l
                 MessageBoxButtons.OKCancel, 		// �\������{�^��
                 MessageBoxDefaultButton.Button2);	// �����\���{�^��
            if (result == DialogResult.OK)
            {
                // �ێ����Ă���f�[�^�Z�b�g�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex][GUID_TITLE];
                pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];
                //PCC�S�̐ݒ�_���폜����
                int status = this._pccTtlStAcs.Delete(ref pccTtlSt);

                int dummy = 0;

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex].Delete();
                            this._pccTtlStTable.Remove(pccTtlSt.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, true);

                            //PCC�S�̐ݒ�N���X�f�[�^�Z�b�g�W�J����
                            this._pccTtlStTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();
                           
                            return;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // TIMEOUT
                            TMsgDisp.Show(
                               this, 								// �e�E�B���h�E�t�H�[��
                               emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                               CT_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                               this.Name,                           // �v���O��������
                               ctPROCNM,                            // ��������
                               TMsgDisp.OPE_UPDATE,                 // �I�y���[�V����
                               ERR_DEL_TIME_MSG,                    // �\�����郁�b�Z�[�W
                               status,            						// �X�e�[�^�X�l
                               this._pccTtlStAcs, 				    // �G���[�����������I�u�W�F�N�g
                               MessageBoxButtons.OK, 				// �\������{�^��
                               MessageBoxDefaultButton.Button1);	// �����\���{�^��
                            return ;
                        }
                    default:
                        {
                            // �����폜
                            TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                                CT_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                CT_PGNM, 				            // �v���O��������
                                "Delete_Button_Click", 				// ��������
                                TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                                "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                                status, 							// �X�e�[�^�X�l
                                this._pccTtlStAcs, 				    // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK, 				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��

                            // PCC�S�̐ݒ�N���X�f�[�^�Z�b�g�W�J����
                            this._pccTtlStTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();
                           
                            return;
                        }
                }

            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;


            // Grid��IndexBuffer�i�[�p�ϐ��̏�����
            this._detailsIndexBuf = -2;

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
        /// Revive_Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: �t�I��</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks> 
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "RevivalProc";
            PccTtlSt pccTtlSt = null;

            DialogResult res = TMsgDisp.Show(this,
                                             emErrorLevel.ERR_LEVEL_QUESTION,
                                             CT_PGID,
                                             "���ݕ\�����̃}�X�^�𕜊����܂��B" + "\r\n" + "��낵���ł����H",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this.DataIndex][GUID_TITLE];
            pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];

            // PCC�S�̐ݒ�o�^�E�X�V����
            int status = this._pccTtlStAcs.RevivalLogicalDelete(ref pccTtlSt);
            int dummy = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //�N���X�f�[�^�Z�b�g�W�J����
                        PccTtlStToDataSet(pccTtlSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pccTtlStTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();

                        return;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_WRITE_TIME_MSG,                 // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pccTtlStAcs,                // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return ;

                    }
                default:
                    {
                        // �������s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            CT_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM, 				            // �v���O��������
                            "Revive_Button_Click", 				// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._pccTtlStAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��                      
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pccTtlStTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();                       
                        break;
                    }
            }         
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;

            this._detailsIndexBuf = -2;

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
        /// ���[�h�ύX����
        /// </summary>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note		: ���[�h�ύX����</br>
        /// <br>Programmer	: �t�I��</br>
        /// <br>Date		: 2011.08.01</br>
        /// </remarks>  
        private bool ModeChangeProc(string sectionCd)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSectionCd = (string)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSectionCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̑S�̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�̃N���A
                        tEdit_SectionCode.Clear();
                        tEdit_SectionName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̑S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�̃N���A
                                tEdit_SectionCode.Clear();

                                tEdit_SectionName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region  Private Methods  
      
        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                
                // 0:���_-�V�K
                case 0:

                    this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_ultraButton1.Enabled = true;
                    this.tEdit_FrontEmployeeCd.Enabled = true;
                    this.uButtonFrontEmployeeCdGuid.Enabled = true;
                    this.tComboEditor1.Enabled = true;
                    this.tComboEditor_AcpOdrrSlipPrtDiv.Enabled = true;
                    this.tComboEditor_SalesSlipPrtDiv.Enabled = true;

                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 1:���_-�X�V
                case 1:
                    // �\������
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_ultraButton1.Enabled = false;
                    this.tEdit_FrontEmployeeCd.Enabled = true;
                    this.uButtonFrontEmployeeCdGuid.Enabled = true;
                    this.tComboEditor1.Enabled = true;
                    this.tComboEditor_AcpOdrrSlipPrtDiv.Enabled = true;
                    this.tComboEditor_SalesSlipPrtDiv.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                   
                    break;
                // 2:���_-�폜
                case 2:
                    // �\������
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_ultraButton1.Enabled = false;
                    this.uButtonFrontEmployeeCdGuid.Enabled = false;
                    this.tEdit_FrontEmployeeCd.Enabled = false;
                    this.tComboEditor1.Enabled = false;
                    this.tComboEditor_AcpOdrrSlipPrtDiv.Enabled = false;
                    this.tComboEditor_SalesSlipPrtDiv.Enabled = false;
                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;   
                    break;
            }
        }

        /// <summary>
        /// ��ʏ��S�̍��ڕ\�����̃N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <param name="pccTtlSt">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̍��ڕ\�����̃N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 ���N�n��</br>
        /// <br>	         rPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C��</br>
        /// <br></br>
        /// </remarks>
        private void DispToPccTtlSt(ref PccTtlSt pccTtlSt)
        {
            if (pccTtlSt == null)
            {
                // �V�K�̏ꍇ
                pccTtlSt = new PccTtlSt();
                pccTtlSt.EnterpriseCode = this._enterpriseCode;
            }
            //���_�R�[�h
            pccTtlSt.SectionCode = tEdit_SectionCode.GetInt().ToString().PadLeft(2, '0');
            //���_����
            pccTtlSt.SectionName = tEdit_SectionName.Text.TrimEnd();
            //��t�]�ƈ�       
            if (tEdit_FrontEmployeeCd.GetInt() == 0)
            {
                tEdit_FrontEmployeeCd.Text = "";
            }
            else
            {
                pccTtlSt.FrontEmployeeCd = tEdit_FrontEmployeeCd.GetInt().ToString().PadLeft(4, '0');
            }
            //��t�]�ƈ�����
            pccTtlSt.FrontEmployeeNm = tEdit_FrontEmployeeCd.Text.TrimEnd();

            //---UPD 2011/09/17 ------------------------>>>>>
            //�[�i�敪
            //pccTtlSt.DeliveredGoodsDiv = (int)tComboEditor1.Value;
            if (this.tComboEditor1.SelectedItem == null)
            {
                pccTtlSt.DeliveredGoodsDiv = 0;
            }
            else
            {
                if (this.tComboEditor1.SelectedItem.DataValue != string.Empty)
                {
                    pccTtlSt.DeliveredGoodsDiv = (int)this.tComboEditor1.SelectedItem.DataValue;
                }
            }
            //---UPD 2011/09/17 ------------------------<<<<<

            //����`�[���s�敪
            pccTtlSt.SalesSlipPrtDiv = (int)tComboEditor_SalesSlipPrtDiv.Value;

            //�󒍓`�[����敪
            pccTtlSt.AcpOdrrSlipPrtDiv = (int)tComboEditor_AcpOdrrSlipPrtDiv.Value;

        }
     
        /// <summary>
        /// ��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�̍��ڕ\�����̃N���X�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 ���N�n��</br>
        /// <br>	         rPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C��</br>
        /// <br></br>
        /// </remarks>
        private void AlItmDspNmToScreen()
        {


            //���_�R�[�h
            this.tEdit_SectionCode.Text = _pccTtlSt.SectionCode;

            //��t�]�ƈ�

            this.tEdit_FrontEmployeeCd.Text = _pccTtlSt.FrontEmployeeCd;

            //---UPD 2011/09/17 ---------------------->>>>>

            //�[�i�敪
            if (this._pccTtlSt.DeliveredGoodsDiv == 0)
            {
                this.tComboEditor1.SelectedItem.DisplayText = string.Empty;
            }
            else
            {
                this.tComboEditor1.SelectedItem.DisplayText = this.GetDeliveredName(this._pccTtlSt.DeliveredGoodsDiv);
            }
            ////�[�i�敪
            //this.tComboEditor1.Value = this._pccTtlSt.DeliveredGoodsDiv;
            //---UPD 2011/09/17 ----------------------<<<<<

            //����`�[���s�敪
            this.tComboEditor_SalesSlipPrtDiv.Value = this._pccTtlSt.SalesSlipPrtDiv;

            //�󒍓`�[����敪
            this.tComboEditor_AcpOdrrSlipPrtDiv.Value = this._pccTtlSt.AcpOdrrSlipPrtDiv;

        }
     
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void ScreenClear()
        {

            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;      
           
            // �{�^��
            this.Delete_Button.Visible = false;  // ���S�폜�{�^��
            this.Revive_Button.Visible = false;  // �����{�^��
            this.Ok_Button.Visible = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
         
            // ���_��
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Text = "";
            this.tEdit_SectionCode.Enabled = true; 
            this.SectionGuide_ultraButton1.Enabled = true;

            //��t�]�ƈ�
            this.tEdit_FrontEmployeeCd.Clear();
            this.tEdit_FrontEmployeeNm.Text="";
            this.tEdit_FrontEmployeeCd.Enabled = true;
            this.uButtonFrontEmployeeCdGuid.Enabled = true;
            this.tComboEditor_SalesSlipPrtDiv.SelectedIndex = 0;
            this.tComboEditor_AcpOdrrSlipPrtDiv.SelectedIndex = 0;
            this.tComboEditor1.SelectedIndex = 0;
            _preFrontEmployeeCd = 0;
            _preSectionCd = 0; //ADD by huanghx for Redmine24889 on 20110914 
        }
     
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 ���N�n��</br>
        /// <br>	         rPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C��</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
                      
            this._pccTtlSt = new PccTtlSt();
            PccTtlSt pccTtlSt = new PccTtlSt();
            this.SetDelivereds(this._enterpriseCode);// ADD 2011/09/17
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                PccTtlStToScreen(pccTtlSt);
                // ��ʃN���A
                this.ScreenClear();
                // �N���[���쐬
                this._pccTtlSClone = pccTtlSt.Clone();
              
                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCode.Focus();
                ScreenInputPermissionControl(0);
                // ��ʓW�J����
                DispToPccTtlSt(ref this._pccTtlSClone);       
            }
             else
            {
               
                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];

                // ��ʓW�J����
                PccTtlStToScreen(pccTtlSt);
                if (pccTtlSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    //�N���[���쐬
                    this._pccTtlSClone = pccTtlSt.Clone();

                    // ��ʓW�J����
                    DispToPccTtlSt(ref this._pccTtlSClone);
                    ScreenInputPermissionControl(1);
                    this.tEdit_FrontEmployeeCd.SelectAll();
                    //-----ADD by huanghx for Redmine25035 on 20110914 ----->>>>>
                    int sectionCode = 0;
                    Int32.TryParse(pccTtlSt.SectionCode.Trim(), out sectionCode);
                    this._preSectionCd = sectionCode;
                    int employeeCd = 0;
                    Int32.TryParse(pccTtlSt.FrontEmployeeCd.Trim(), out employeeCd);
                    this._preFrontEmployeeCd = employeeCd;
                    //-----ADD by huanghx for Redmine24889 on 20110914 -----<<<<<
                }
                // �폜�̏ꍇ
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓW�J����
                    PccTtlStToScreen(pccTtlSt);
                    ScreenInputPermissionControl(2);
                    this.Delete_Button.Focus();

                }  
           
                this._detailsIndexBuf = this._dataIndex;             
          }
     }
    
        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private bool SaveProc()
        {        
           
            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = null;

            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this,                                  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                    CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                               // �\�����郁�b�Z�[�W
                    0,                                     // �X�e�[�^�X�l
                    MessageBoxButtons.OK);                // �\������{�^��

                // �R���g���[����I��
                control.Focus();
               
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return false;
            }

            // �\�����擾
            if (this.DataIndex >= 0 )
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                _pccTtlSt = (PccTtlSt)this._pccTtlStTable[guid];
            }
            // ��ʂ���S�̍��ڕ\�����̂̃f�[�^���擾
            DispToPccTtlSt(ref this._pccTtlSt);

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = this._pccTtlStAcs.Write(ref this._pccTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        PccTtlStToDataSet(_pccTtlSt.Clone(), this.DataIndex);
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this,                                    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,             // �G���[���x��
                            CT_PGID,                                 // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                       // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                   // �\������{�^��

                        return result;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_WRITE_TIME_MSG,                 // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pccTtlStAcs,                // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                            CT_PGID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                              // �v���O��������
                            ctPROCNM,                             // ��������
                            TMsgDisp.OPE_READ,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                            status,                               // �X�e�[�^�X�l
                            this._pccTtlStAcs,                    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                 // �\������{�^��
                            MessageBoxDefaultButton.Button1);     // �����\���{�^��
                          this.CloseForm(DialogResult.Cancel);
                          return result;
                    }
            }

            return result;
        }
     
        /// <summary>
        /// ���Check
        /// </summary>
        /// <param name="control">STATUS</param>
        /// <param name="message">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : ���Check���s���܂�</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
            if (this.tEdit_SectionCode.Text == "")
            {
                control = this.tEdit_SectionCode;
                message = "���_�R�[�h����͂��ĉ������B";
                result = false;
            }
            else if (this.tEdit_SectionName.Text.Trim() == "")
            {
                control = this.tEdit_SectionCode;
                message = "�}�X�^�ɓo�^����Ă��܂���B";
                result = false;
            }
            else if (this.tEdit_FrontEmployeeCd.Text == "")
            {
                control = this.tEdit_FrontEmployeeCd;
                message = "�󒍎҂���͂��ĉ������B";
                result = false;
            }
            else if (this.tEdit_FrontEmployeeNm.Text.Trim() == "")
            {
                control = this.tEdit_FrontEmployeeCd;
                message = "�}�X�^�ɓo�^����Ă��܂���B";
                result = false;
            }
            return result;
        }
     
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this,                                  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                            CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                     // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                 // �\������{�^��
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this,                                  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                            CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                     // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                 // �\������{�^��
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }
     
        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // ��r�p�N���[���N���A
            this._pccTtlSClone = null;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }   
          
        /// <summary>
        /// ���_���̂̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;
            if (_sectionTb == null)
            {
                GetALLSectionName();
            }

            if (_sectionTb != null && _sectionTb.Count > 0 && _sectionTb.ContainsKey(sectionCode))
            {
                sectionName = (string)_sectionTb[sectionCode];
            }
            
            return sectionName;
        }

        /// <summary>
        /// ���_���̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void GetALLSectionName()
        {
            if (this._secInfoSetAcs == null)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }
            if (_sectionTb == null)
            {
                _sectionTb = new Hashtable();
            }
            else
            {
                _sectionTb.Clear();
            }

            _sectionTb.Add("00", SECTION_00_MES);
                ArrayList retList = null;
                int status = this._secInfoSetAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (secInfoSet.LogicalDeleteCode == 0)
                        {
                            _sectionTb.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideSnm.TrimEnd());
                        }
                    }
                }
        }
     
        /// <summary>
        /// ��t�]�ƈ����̂̎擾
        /// </summary>
        /// <param name="employeeCode"> ��t�]�ƈ��R�[�h</param>
        /// <returns>��t�]�ƈ�����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetFrontEmployeeNm(string employeeCode)
        {

            string frontEmployeeNm = string.Empty;
            if (_employeeTb == null)
            {
                GetAllEmployeeNm();
            }
            if (_employeeTb != null && _employeeTb.ContainsKey(employeeCode.PadLeft(4, '0').TrimEnd()))
            {
                frontEmployeeNm = (string)_employeeTb[employeeCode.PadLeft(4, '0').TrimEnd()];
            }
            return frontEmployeeNm;
        }
     
        /// <summary>
        /// ��t�]�ƈ����̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void GetAllEmployeeNm()
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            if (this._employeeTb == null)
            {
                _employeeTb = new Hashtable();
            }
            else
            {
                _employeeTb.Clear();
            }
            
            ArrayList employeeList;
            ArrayList employeeDtlList;
            int status = this._employeeAcs.SearchAll(out employeeList, out employeeDtlList, this._enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Employee employee in employeeList)
                {
                    if (employee.LogicalDeleteCode == 0)
                    {
                        _employeeTb.Add(employee.EmployeeCode.TrimEnd(), employee.Name);
                    }
                }
            }
        }

        /// <summary>
        /// �S�̐ݒ�}�X�^�W�J����
        /// </summary>
        /// <param name="pccTtlSt">�S�̐ݒ�}�X�^</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �S�̐ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void PccTtlStToDataSet(PccTtlSt pccTtlSt, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PCCTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (pccTtlSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][DELETE_DATE] = pccTtlSt.UpdateDateTimeJpInFormal;
            }          

            // ���_�R�[�h
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = pccTtlSt.SectionCode;

            // ���_����
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = GetSectionName(pccTtlSt.SectionCode.TrimEnd()); ;

            // �]�ƈ�
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][FRONTEMPLOYEECD_TITLE] = pccTtlSt.FrontEmployeeCd;

            // �]�ƈ�����
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][FRONTEMPLOYEENM_TITLE] = GetFrontEmployeeNm(pccTtlSt.FrontEmployeeCd);

            // �[�i�敪
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][DELIVEREDGOODSDIV_TITLE] = pccTtlSt.DeliveredGoodsNm;

            // ����`�[���s�敪
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][SALESSLIPPRTDIV_TITLE] = pccTtlSt.SalesSlipPrtNm;

            // �󒍓`�[����敪
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][ACPODRRSLIPPRTDIV_TITLE] = pccTtlSt.AcpOdrrSlipPrtNm;

            // GUID
            this.Bind_DataSet.Tables[PCCTTLST_TABLE].Rows[index][GUID_TITLE] = pccTtlSt.FileHeaderGuid;

            if (this._pccTtlStTable.ContainsKey(pccTtlSt.FileHeaderGuid) == true)
            {
                this._pccTtlStTable.Remove(pccTtlSt.FileHeaderGuid);
            }
            this._pccTtlStTable.Add(pccTtlSt.FileHeaderGuid, pccTtlSt);
        }
     
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable pccTtlStTable = new DataTable(PCCTTLST_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            pccTtlStTable.Columns.Add(DELETE_DATE, typeof(string));                     // �폜��       
            pccTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));			    // ���_�R�[�h
            pccTtlStTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));            // ���_����
            pccTtlStTable.Columns.Add(FRONTEMPLOYEECD_TITLE, typeof(string));	    //  �]�ƈ�
            pccTtlStTable.Columns.Add(FRONTEMPLOYEENM_TITLE, typeof(string));	    //  �]�ƈ�����
            pccTtlStTable.Columns.Add(DELIVEREDGOODSDIV_TITLE, typeof(string));	    // �[�i�敪
            pccTtlStTable.Columns.Add(SALESSLIPPRTDIV_TITLE, typeof(string));	// ����`�[���s�敪
            pccTtlStTable.Columns.Add(ACPODRRSLIPPRTDIV_TITLE, typeof(string));	// �󒍓`�[����敪
            pccTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));                
            this.Bind_DataSet.Tables.Add(pccTtlStTable);
        }
     
        /// <summary>
        /// ���_�N���X��ʓW�J����
        /// </summary>
        /// <param name="pccTtlSt">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 2011/09/17 ���N�n��</br>
        /// <br>	         rPCC-UOE(NS)�v�^pm�� PCC�S�̐ݒ�̏C��</br>
        /// <br></br>
        /// </remarks>
        private void PccTtlStToScreen(PccTtlSt pccTtlSt)
        {

            //���_�R�[�h
            this.tEdit_SectionCode.Text = pccTtlSt.SectionCode.Trim().PadLeft(2,'0');

            //���_����
            this.tEdit_SectionName.Text = GetSectionName(pccTtlSt.SectionCode.TrimEnd());

            //��t�]�ƈ��R�[�h
            this.tEdit_FrontEmployeeCd.Text = pccTtlSt.FrontEmployeeCd.Trim().PadLeft(4,'0');

            //��t�]�ƈ�����
            this.tEdit_FrontEmployeeNm.Text = GetFrontEmployeeNm(pccTtlSt.FrontEmployeeCd);

            //---UPD 2011/09/17 --------------------->>>>>
            //�[�i�敪
            //this.tComboEditor1.Value = pccTtlSt.DeliveredGoodsDiv;
            if (pccTtlSt.DeliveredGoodsDiv == 0)
            {
                this.tComboEditor1.SelectedIndex = 0;
            }
            else
            {
                this.tComboEditor1.Value = pccTtlSt.DeliveredGoodsDiv;
            }
            //---UPD 2011/09/17 ---------------------<<<<<

            //����`�[���s�敪
            this.tComboEditor_SalesSlipPrtDiv.Value = pccTtlSt.SalesSlipPrtDiv;

            //�󒍓`�[����敪
            this.tComboEditor_AcpOdrrSlipPrtDiv.Value = pccTtlSt.AcpOdrrSlipPrtDiv;

        }
        
        #endregion
        //---ADD 2011/09/17 --------------------------------->>>>>
        /// <summary>
        /// ���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> ��ƃR�[�h</param>
        /// <br>Note       : ���[�U�[�K�C�h�ݒ�̔[�i�敪���擾���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
            ArrayList userGuidList = null;
            //�[�i�敪�̍���
            int userGuideDivCd = 48;
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            tComboEditor1.Items.Clear();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {

                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                       tComboEditor1.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);
                       _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                    }
                }
            }
            if (this.tComboEditor1.SelectedItem == null && this.tComboEditor1.Items.Count == 0)
            {
                tComboEditor1.Items.Add(string.Empty, string.Empty);
                _userGdBdTb.Add(string.Empty, string.Empty);
            }
            this.tComboEditor1.SelectedIndex = 0;
       
        }
        /// <summary>
        /// �[�i�敪���̂̎擾
        /// </summary>
        /// <param name="deliveredGoodsDiv"> �[�i�敪</param>
        /// <remarks>
        /// <returns>�[�i�敪����</returns>
        /// <br>Note       : �[�i�敪���̂��擾���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        //---ADD 2011/09/17 ---------------------------------<<<<<

      }
    }

