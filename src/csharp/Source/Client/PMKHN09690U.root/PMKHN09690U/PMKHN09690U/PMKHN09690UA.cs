//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : BL�R�[�h�ϊ��}�X�^ ���̓t�H�[���N���X
// �v���O�����T�v   : BL�R�[�h�ϊ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F�� 30745
// �� �� ��  2012/08/01  �C�����e : �V�K�쐬
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
    /// BL�R�[�h�ϊ��}�X�^�\���ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�ϊ��}�X�^���̐ݒ�̐ݒ���s���܂��B</br>
    /// <br>Programmer : �g�� �F�� 30745</br>
    /// <br>Date       : 2012/08/01</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09690UA : Form, IMasterMaintenanceMultiType
    {
        #region Constructor

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�ϊ��}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09690UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h 00�F�S�ЌŒ�
            this._sectionCode = "00";
            _blCodeChangeAcs = new BLGoodsCdChgUAcs();
            this._blCodeChangeTable = new Hashtable();

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
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
        }

        #endregion

        #region Private Members
        private const string BLGOODSCDCHGU_TABLE = "BLGOODSCDCHGU";
        private Hashtable _blCodeChangeTable;
        private bool _modeFlg = false;
        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string UPDATEDATETIME_DATE = "�X�V��";
        private const string DELETE_DATE = "�폜��";
        private const string CUSTOMER_CODE_TITLE = "���Ӑ�R�[�h";
        private const string CUSTOMER_NAME_TITLE = "���Ӑ於��";
        private const string PMBL_CODE_TITLE = "PM��BL�R�[�h";
        private const string SFBL_CODE_TITLE = "SF��BL�R�[�h";
        private const string GUID_TITLE = "GUID";

        // �ҏW���[�h
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string INSERT_MODE = "�V�K���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // Message�֘A��`
        private const string CT_PGID = "PMKHN09690U";
        private const string CT_PGNM = "���Аݒ�";
        private const string ASSEMBLY_ID = "PMKHN09690U";
        private const string ERR_SEAR_TIME_MSG = "�������Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�������s�Ȃ��Ă��������B";
        private const string ERR_WRITE_TIME_MSG = "�X�V���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string ERR_DEL_TIME_MSG = "�폜���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string SECTION_00_MES = "�S��";
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";


        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^ �A�N�Z�X�N���X
        /// </summary>
        private BLGoodsCdChgUAcs _blCodeChangeAcs = null;
        private BLGoodsCdChgU _blCodeChangeU = null;

        /// <summary>
        /// ���Ӑ���A�N�Z�X�N���X
        /// </summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>
        /// BL���i�R�[�h�A�N�Z�X�N���X
        /// </summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        // ��r�p�N���[��
        private BLGoodsCdChgU _blGoodsCdChgUClone;   // ��r�p�S�̍��ڕ\�����̃N���X
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
        private Hashtable _customerTb = null;

        /// <summary>
        /// �OPM��BL�R�[�h
        /// </summary>
        private int _pmBLCdPre = 0;
        /// <summary>
        /// �OSF��BL�R�[�h
        /// </summary>
        private int _sfBLCdPre = 0;
        /// <summary>
        /// �O���Ӑ�R�[�h
        /// </summary>
        private int _customerCodePre = -1;
        /// <summary>
        /// �O���Ӑ於��
        /// </summary>
        private string _customerNamePre = string.Empty;
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        private string _enterpriseCode = string.Empty;
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        private string _sectionCode = string.Empty;
        /// <summary>
        /// BL���i�R�[�h���́i�S�p�j�i�ۑ��O�̃`�F�b�N�Ɏg�p�j
        /// </summary>
        private string _pmBLCdGoodsFullName = string.Empty;

        /// <summary>
        /// SF��BL�R�[�h�@�ҏW�񐔁i�ۑ��O�̃`�F�b�N�Ɏg�p�j
        /// </summary>
        private int _sfBLCdEditCnt = 0;
        /// <summary>
        /// SF��BL�R�[�h�@BL���i�R�[�h���́i�ۑ��O�̃`�F�b�N�Ɏg�p�j
        /// </summary>
        private string _sfBLCdGoodsFullName = string.Empty;

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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���Ӑ�R�[�h
            appearanceTable.Add(CUSTOMER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ӑ於��
            appearanceTable.Add(CUSTOMER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // PM��BL�R�[�h
            appearanceTable.Add(PMBL_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // SF��BL�R�[�h
            appearanceTable.Add(SFBL_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = BLGOODSCDCHGU_TABLE;
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
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30745 �g��</br>
        /// <br>Date       : 2012/08/01 </br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            const string ctPROCNM = "Search";
            BLGoodsCdChgU parseblCodeChange = newBLGoodsCdChgU();
            List<BLGoodsCdChgU> blCodeChangeList = null;

            if (this._blCodeChangeTable.Count == 0)
            {
                status = this._blCodeChangeAcs.Search(ref blCodeChangeList, parseblCodeChange, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.totalCount = blCodeChangeList.Count;
                            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Clear();
                            this._blCodeChangeTable.Clear();

                            //BL�R�[�h�ϊ��}�X�^�N���X���f�[�^�Z�b�g�֓W�J����
                            int index = 0;
                            foreach (BLGoodsCdChgU blCodeChange in blCodeChangeList)
                            {
                                if (this._blCodeChangeTable.ContainsKey(blCodeChange.FileHeaderGuid) == false)
                                {
                                    BLGoodsCdChgUToDataSet(blCodeChange.Clone(), index);
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
                                this._blCodeChangeAcs,                // �G���[�����������I�u�W�F�N�g
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
                this.totalCount = this._blCodeChangeTable.Count;
                SortedList sortedList = new SortedList();

                //BL�R�[�h�ϊ��}�X�^�N���X���f�[�^�Z�b�g�֓W�J����
                int index = 0;
                foreach (BLGoodsCdChgU blCodeChange in sortedList.Values)
                {
                    BLGoodsCdChgUToDataSet(blCodeChange.Clone(), index);
                    ++index;
                }
            }
            // �߂�l�Z�b�g
            totalCount = this.totalCount;

            return status;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Delete()
        {

            const string ctPROCNM = "LogicalDelete";
            BLGoodsCdChgU blCodeChange = null;

            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex][GUID_TITLE];
            blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];

            int status;
            int dummy = 0;
            //BL�R�[�h�ϊ��}�X�^�_���폜����
            status = this._blCodeChangeAcs.LogicalDelete(ref blCodeChange);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BLGoodsCdChgUToDataSet(blCodeChange.Clone(), this.DataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        //BL�R�[�h�ϊ��}�X�^�N���X�f�[�^�Z�b�g�W�J����
                        this._blCodeChangeTable.Clear();
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
                            this._blCodeChangeAcs,                // �G���[�����������I�u�W�F�N�g
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
                            this._blCodeChangeAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        //BL�R�[�h�ϊ��}�X�^�N���X�f�[�^�Z�b�g�W�J����
                        this._blCodeChangeTable.Clear();
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
        /// <br>Programmer	: �g�� �F�� 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>
        private void PMKHN09690UA_Load(object sender, EventArgs e)
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

            this.uButton_CustomerGuide.ImageList = imageList16;
            this.uButton_PMBLCdGuid.ImageList = imageList16;
            this.uButton_SFBLCdGuid.ImageList = imageList16;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;     // �ۑ��{�^��
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // ����{�^��
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;  //�����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;   //���S�폜�{�^��
            this.uButton_CustomerGuide.Appearance.Image = Size16_Index.STAR1;//�K�C�h�{�^��
            this.uButton_PMBLCdGuid.Appearance.Image = Size16_Index.STAR1;//�K�C�h�{�^��
            this.uButton_SFBLCdGuid.Appearance.Image = Size16_Index.STAR1;//�K�C�h�{�^��

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Form.FormClosing �C�x���g (PMKHN09690UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[������邽�тɁA�t�H�[����������O�A����ѕ��闝�R���w�肷��O�ɔ������܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void PMKHN09690UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._detailsIndexBuf = -2;
            // �`�F�b�N�p�N���[��������
            this._blGoodsCdChgUClone = null;

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
        /// Form.VisibleChanged �C�x���g (PMKHN09690UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void PMKHN09690UA_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                BLGoodsCdChgU compareBLGoodsCdChgU = new BLGoodsCdChgU();
                compareBLGoodsCdChgU = this._blGoodsCdChgUClone.Clone();
                this._detailsIndexBuf = this._dataIndex;

                //���݂̉�ʏ����擾����
                DispToBLGoodsCdChgU(ref compareBLGoodsCdChgU);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._blGoodsCdChgUClone.Equals(compareBLGoodsCdChgU)))
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
                                    this.tNedit_CustomerCd.Focus();
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
        /// <br>Programmer	: �g�� �F�� 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>
        private void uButtonCustomerGuid_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog(this);

            //-----------------------------------------------------------------------------
            //if (this._customerInfoAcs == null)
            //{
            //    this._customerInfoAcs = new EmployeeAcs();
            //}

            //Employee employee;
            //int status = this._customerInfoAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    tNedit_CustomerCd.Value = employee.EmployeeCode.TrimEnd();
            //    uLabel_CustomerName.Text = employee.Name;
            //    _prePMBLCd = tNedit_CustomerCd.GetInt(); //ADD by huanghx for Redmine24889 on 20110914
            //}

        }

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� </br>
        /// <br>Date       : 2012/08/01 </br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }


            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }

            // ���Ӑ����UI�ɐݒ�
            this.tNedit_CustomerCd.SetInt(customerInfo.CustomerCode);
            this.uLabel_CustomerNm.Text = customerInfo.CustomerSnm.TrimEnd();
            this.tNedit_CustomerCd.Enabled = true;
            this.uButton_CustomerGuide.Enabled = true;
        }
        #endregion


        /// <summary>
        /// ChangeFocus �C�x���g(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �g�� �F�� 30745</br>
        /// <br>Date        : 2012/08/01</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {

                case "tNedit_CustomerCd":   // ���Ӑ�R�[�h
                    #region ���Ӑ�R�[�h����̃t�H�[�J�X�J��
                    int customerCode = this.tNedit_CustomerCd.GetInt();
                    if (_customerCodePre != customerCode)
                    {
                        if (customerCode != 0)
                        {
                            #region ���Ӑ�R�[�h���͗L��
                            if (e.NextCtrl.Name == "Cancel_Button")
                            {
                                // �J�ڐ悪����{�^��
                                _modeFlg = true;
                            }
                            else
                            {
                                //���Ӑ�����擾
                                CustomerInfo customerInfo;
                                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerCode);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                                {
                                    // ���[�h�ύX�@���łɓo�^�ς݁i�_���폜�A�ҏW�j���ۂ��𔻒�
                                    if (ModeChangeProc(customerInfo.CustomerCode, tNedit_PMBLCd.GetInt()))
                                    {
                                        if (this._dataIndex < 0)
                                        {
                                            e.NextCtrl = tNedit_CustomerCd;
                                        }
                                    }
                                    else
                                    {
                                        this.uLabel_CustomerNm.Text = customerInfo.CustomerSnm.TrimEnd();
                                        //�O���Ӑ�R�[�h
                                        this._customerCodePre = customerCode;
                                        //�O���Ӑ於��
                                        this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                         this, 								    // �e�E�B���h�E�t�H�[��
                                         emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                                         ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                         "���Ӑ�}�X�^�ɓo�^����Ă��܂���B", 	// �\�����郁�b�Z�[�W
                                         0, 									// �X�e�[�^�X�l
                                         MessageBoxButtons.OK);				    // �\������{�^��
                                    e.NextCtrl = tNedit_CustomerCd;
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            #region ���Ӑ�R�[�h���͖���
                            //���Ӑ於�̃N���A
                            this.uLabel_CustomerNm.Text = string.Empty;
                            //���Ӑ�����擾
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.CustomerSnm = CUSTOMEMPTY_BASE;
                            customerInfo.CustomerEpCode = string.Empty;
                            customerInfo.CustomerSecCode = string.Empty;
                            customerInfo.CustomerCode = 0;

                            // ���[�h�ύX�@���łɓo�^�ς݁i�_���폜�A�ҏW�j���ۂ��𔻒�
                            if (ModeChangeProc(customerInfo.CustomerCode, tNedit_PMBLCd.GetInt()))
                            {
                                if (this._dataIndex < 0)
                                {
                                    e.NextCtrl = tNedit_CustomerCd;
                                }
                            }
                            else
                            {
                                //�O���Ӑ�R�[�h
                                this._customerCodePre = customerCode;
                                //�O���Ӑ於��
                                this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                            }
                            #endregion
                        }
                    }
                    break;
                    #endregion
                case "tNedit_PMBLCd":           // PM��BL�R�[�h
                    FocusMoveBLGoodsCode(tNedit_PMBLCd,e);
                    break;
                case "tNedit_SFBLCd":           // SF��BL�R�[�h
                    FocusMoveBLGoodsCode(tNedit_SFBLCd, e);

                    // SF��BL�R�[�h�̕ύX���J�E���g
                    if (isBLCodeChange(tNedit_SFBLCd.Name, tNedit_SFBLCd.GetInt()))
                    {
                        _sfBLCdEditCnt++;
                    }
                    break;
                case "uButton_CustomerGuide":   // ���Ӑ�K�C�h
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = uButton_CustomerGuide;
                    }
                    break;
                case "uButton_PMBLCdGuid":      // PM��BL�R�[�h�K�C�h
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = uButton_PMBLCdGuid;
                    }
                    break;
                case "uButton_SFBLCdGuid":      // SF��BL�R�[�h�K�C�h
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = uButton_SFBLCdGuid;
                    }
                    break;
            }
        }

        /// <summary>
        /// PM��BL�R�[�h�ASF��BL�R�[�h�p
        /// �t�H�[�J�X�J�ڎ�����
        /// </summary>
        /// <param name="target">�ΏۃR���g���[��</param>
        private void FocusMoveBLGoodsCode(TNedit target, ChangeFocusEventArgs e)
        {
            int blCode = target.GetInt();
            // BL�R�[�h���ύX����Ă��邩
            if (isBLCodeChange(target.Name,blCode))
            {
                if (blCode != 0)
                {
                    #region PM��BL���i�R�[�h���͗L��
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else
                    {
                        //BL���i�����擾
                        BLGoodsCdUMnt bLGoodsCdUMnt;
                        int status = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, blCode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ���[�h�ύX�@���łɓo�^�ς݁i�_���폜�A�ҏW�j���ۂ��𔻒�
                            if (target.Name == tNedit_PMBLCd.Name && ModeChangeProc(tNedit_CustomerCd.GetInt(), blCode))
                            {
                                if (this._dataIndex < 0)
                                {
                                    e.NextCtrl = tNedit_CustomerCd;
                                }
                            }
                            else
                            {
                                if (target.Name == tNedit_PMBLCd.Name)
                                {
                                    //�OPM��BL���i�R�[�h
                                    this._pmBLCdPre = blCode;
                                    //BL���i�R�[�h����
                                    this._pmBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
                                }
                                else
                                {
                                    //SF��BL�R�[�h�@BL���i�R�[�h����
                                    this._sfBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
                                }
                            }
                        }
                        else
                        {
                            string msg = string.Empty;
                            if (target.Name == tNedit_PMBLCd.Name)
                            {
                                msg = "PM��BL�R�[�h���}�X�^�ɓo�^����Ă��܂���B";
                            }
                            else
                            {
                                msg = "SF��BL�R�[�h���}�X�^�ɓo�^����Ă��܂���B";
                            }

                            TMsgDisp.Show(
                                 this, 								    // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                                 ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                 msg, 		                            // �\�����郁�b�Z�[�W
                                 0, 									// �X�e�[�^�X�l
                                 MessageBoxButtons.OK);				    // �\������{�^��
                            e.NextCtrl = target;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region BL�R�[�h���͖���
                    if (target.Name == tNedit_PMBLCd.Name)
                    {
                        this._pmBLCdGoodsFullName = string.Empty;
                        //�OPM��BL���i�R�[�h
                        this._pmBLCdPre = blCode;
                    }
                    else
                    {
                        this._sfBLCdGoodsFullName = string.Empty;
                    }

                    //// ���[�h�ύX�@���łɓo�^�ς݁i�_���폜�A�ҏW�j���ۂ��𔻒�
                    //if (ModeChangeProc(tNedit_CustomerCd.GetInt(), blCode))
                    //{
                    //    if (this._dataIndex < 0)
                    //    {
                    //        e.NextCtrl = tNedit_CustomerCd;
                    //    }
                    //}
                    //else
                    //{
                    //    //�OPM��BL���i�R�[�h
                    //    this._pmBLCdPre = blCode;
                    //}
                    #endregion
                }
            }

        }

        /// <summary>
        /// BL�R�[�h���ύX�ɂȂ��Ă��邩�ۂ�
        /// </summary>
        /// <param name="name">�I�u�W�F�N�g����</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <returns>
        /// true:�ύX���ꂽ�@false:�ύX����Ă��Ȃ�
        /// </returns>
        private bool isBLCodeChange(string name, int blCode)
        {
            if (name == tNedit_PMBLCd.Name)
            {
                // PM��BL�R�[�h
                return !blCode.Equals(this._pmBLCdPre);
            }
            else
            {
                // SF��BL�R�[�h
                return !blCode.Equals(this._sfBLCdPre);
            }
        }

        /// <summary>
        /// Delete_Button_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: �g�� �F�� 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "Delete";
            BLGoodsCdChgU blCodeChange = newBLGoodsCdChgU();

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
                Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex][GUID_TITLE];
                blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];
                //BL�R�[�h�ϊ��}�X�^�_���폜����
                int status = this._blCodeChangeAcs.Delete(ref blCodeChange);

                int dummy = 0;

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex].Delete();
                            this._blCodeChangeTable.Remove(blCodeChange.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, true);

                            //BL�R�[�h�ϊ��}�X�^�N���X�f�[�^�Z�b�g�W�J����
                            this._blCodeChangeTable.Clear();
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
                               status,            					// �X�e�[�^�X�l
                               this._blCodeChangeAcs, 				// �G���[�����������I�u�W�F�N�g
                               MessageBoxButtons.OK, 				// �\������{�^��
                               MessageBoxDefaultButton.Button1);	// �����\���{�^��
                            return;
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
                                this._blCodeChangeAcs, 				// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK, 				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��

                            // BL�R�[�h�ϊ��}�X�^�N���X�f�[�^�Z�b�g�W�J����
                            this._blCodeChangeTable.Clear();
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
        /// <br>Programmer	: �g�� �F�� 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks> 
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "RevivalProc";
            BLGoodsCdChgU blCodeChange = null;

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
            Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this.DataIndex][GUID_TITLE];
            blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];

            // BL�R�[�h�ϊ��}�X�^�o�^�E�X�V����
            int status = this._blCodeChangeAcs.RevivalLogicalDelete(ref blCodeChange);
            int dummy = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //�N���X�f�[�^�Z�b�g�W�J����
                        BLGoodsCdChgUToDataSet(blCodeChange, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._blCodeChangeTable.Clear();
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
                            this._blCodeChangeAcs,              // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return;

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
                            this._blCodeChangeAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��                      
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._blCodeChangeTable.Clear();
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
        /// <br>Programmer	: �g�� �F�� 30745</br>
        /// <br>Date		: 2012/08/01</br>
        /// </remarks>  
        private bool ModeChangeProc(int customerCd, int pMBLGoodsCode)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCustomerCd = 0;
                int dsPMBLGoodsCode = 0;
                int.TryParse(this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[i][CUSTOMER_CODE_TITLE].ToString().Trim(), out dsCustomerCd);
                int.TryParse(this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[i][PMBL_CODE_TITLE].ToString().Trim(), out dsPMBLGoodsCode);

                if (customerCd.Equals(dsCustomerCd) && pMBLGoodsCode.Equals(dsPMBLGoodsCode))
                {
                    // ���Ӑ�R�[�h�APM��BL���i�R�[�h���A�f�[�^�Z�b�g��v�����ꍇ
                    if ((string)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��BL�R�[�h�ϊ��}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ӑ�R�[�h�̃N���A
                        tNedit_CustomerCd.Clear();
                        uLabel_CustomerNm.Text = string.Empty;
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��BL�R�[�h�ϊ��}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // �e���ڃN���A
                                tNedit_CustomerCd.Clear();
                                uLabel_CustomerNm.Text = string.Empty;
                                tNedit_PMBLCd.Clear();
                                tNedit_SFBLCd.Clear();
                                this._customerCodePre = 0;
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
        /// <param name="setType">�ݒ�^�C�v �V�K, �X�V, �폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string setType)
        {
            switch (setType)
            {

                // �V�K
                case INSERT_MODE:

                    this.tNedit_CustomerCd.Enabled = true;
                    this.uButton_CustomerGuide.Enabled = true;

                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // �X�V
                case UPDATE_MODE:
                    // �\������
                    this.tNedit_CustomerCd.Enabled = false;
                    this.uButton_CustomerGuide.Enabled = false;
                    this.tNedit_PMBLCd.Enabled = false;
                    this.uButton_PMBLCdGuid.Enabled = false;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // �폜
                case DELETE_MODE:
                    // �\������
                    this.uButton_CustomerGuide.Enabled = false;
                    this.tNedit_CustomerCd.Enabled = false;
                    this.tNedit_PMBLCd.Enabled = false;
                    this.uButton_PMBLCdGuid.Enabled = false;
                    this.tNedit_SFBLCd.Enabled = false;
                    this.uButton_SFBLCdGuid.Enabled = false;

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// ��ʏ��i�[����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�BL�R�[�h�ϊ��}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// <br></br>
        /// </remarks>
        private void DispToBLGoodsCdChgU(ref BLGoodsCdChgU blCodeChange)
        {
            if (blCodeChange == null)
            {
                // �V�K�̏ꍇ
                blCodeChange = newBLGoodsCdChgU();
            }

            blCodeChange.CustomerCode = tNedit_CustomerCd.GetInt();
            blCodeChange.PMBLGoodsCode = tNedit_PMBLCd.GetInt();
            blCodeChange.SFBLGoodsCode = tNedit_SFBLCd.GetInt();
            // ����A���̂̐ݒ�͕s�v�i�V�K�쐬���j
            blCodeChange.BLGoodsFullName = string.Empty;
            blCodeChange.BLGoodsHalfName = string.Empty;
        }

        /// <summary>
        /// ��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�̍��ڕ\�����̃N���X�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void AlItmDspNmToScreen()
        {
            this.tNedit_CustomerCd.Text = _blCodeChangeU.CustomerCode.ToString();
            this.tNedit_PMBLCd.Text = _blCodeChangeU.PMBLGoodsCode.ToString();
            this.tNedit_SFBLCd.Text = _blCodeChangeU.SFBLGoodsCode.ToString();
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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

            // ���Ӑ�
            this.tNedit_CustomerCd.Clear();
            this.uLabel_CustomerNm.Text = "";
            this.tNedit_CustomerCd.Enabled = true;
            this.uButton_CustomerGuide.Enabled = true;
            this._customerCodePre = -1;
            this._customerNamePre = string.Empty;

            // PM��BL���i�R�[�h
            this.tNedit_PMBLCd.Clear();
            this.tNedit_PMBLCd.Enabled = true;
            this.uButton_PMBLCdGuid.Enabled = true;
            this._pmBLCdPre = -1;
            this._pmBLCdGoodsFullName = string.Empty;

            // SF��BL���i�R�[�h
            this.tNedit_SFBLCd.Clear();
            this.tNedit_SFBLCd.Enabled = true;
            this.uButton_SFBLCdGuid.Enabled = true;
            this._sfBLCdPre = -1;
            this._sfBLCdEditCnt = 0;
            this._sfBLCdGoodsFullName = string.Empty;
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            this._blCodeChangeU = newBLGoodsCdChgU();
            BLGoodsCdChgU blCodeChange = newBLGoodsCdChgU();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                BLGoodsCdChgUToScreen(blCodeChange);
                // ��ʃN���A
                this.ScreenClear();
                // �N���[���쐬
                this._blGoodsCdChgUClone = blCodeChange.Clone();

                // �t�H�[�J�X�ݒ�
                this.tNedit_CustomerCd.Focus();
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);
                // ��ʓW�J����
                DispToBLGoodsCdChgU(ref this._blGoodsCdChgUClone);
            }
            // �폜�@���́@�X�V�@�̏ꍇ
            else
            {
                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                blCodeChange = (BLGoodsCdChgU)this._blCodeChangeTable[guid];

                // ��ʓW�J����
                BLGoodsCdChgUToScreen(blCodeChange);
                // �X�V�̏ꍇ
                if (blCodeChange.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    //�N���[���쐬
                    this._blGoodsCdChgUClone = blCodeChange.Clone();

                    // ��ʓW�J����
                    DispToBLGoodsCdChgU(ref this._blGoodsCdChgUClone);
                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    this.tNedit_SFBLCd.SelectAll();

                    this._pmBLCdPre = blCodeChange.PMBLGoodsCode;
                    this._sfBLCdPre = blCodeChange.PMBLGoodsCode;
                    this._pmBLCdGoodsFullName = blCodeChange.BLGoodsFullName;
                }
                // �폜�̏ꍇ
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓW�J����
                    BLGoodsCdChgUToScreen(blCodeChange);
                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);
                    this.Delete_Button.Focus();
                }

                this._detailsIndexBuf = this._dataIndex;
            }
        }

        /// <summary>
        ///  BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j�̏������@
        /// �i�Œ�l��ݒ�j
        /// </summary>
        /// <returns></returns>
        private BLGoodsCdChgU newBLGoodsCdChgU()
        {
            BLGoodsCdChgU work = new BLGoodsCdChgU();
            work.EnterpriseCode = this._enterpriseCode;
            work.SectionCode = this._sectionCode;
            work.PMBLGoodsCodeDerivNo = 0;
            work.SFBLGoodsCodeDerivNo = 0;
            return work;
        }


        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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
            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                _blCodeChangeU = (BLGoodsCdChgU)this._blCodeChangeTable[guid];
            }
            // ��ʂ���S�̍��ڕ\�����̂̃f�[�^���擾
            DispToBLGoodsCdChgU(ref this._blCodeChangeU);

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = this._blCodeChangeAcs.Write(ref this._blCodeChangeU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BLGoodsCdChgUToDataSet(_blCodeChangeU.Clone(), this.DataIndex);
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
                            this._blCodeChangeAcs,                // �G���[�����������I�u�W�F�N�g
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
                            this._blCodeChangeAcs,                    // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
            // ���Ӑ�
            if (this.tNedit_CustomerCd.Text == string.Empty)
            {
                control = this.tNedit_CustomerCd;
                message = "���Ӑ�R�[�h����͂��ĉ������B";
                result = false;
            }
            else if (this.uLabel_CustomerNm.Text.Trim() == string.Empty)
            {
                control = this.tNedit_CustomerCd;
                message = "���Ӑ�R�[�h���}�X�^�ɓo�^����Ă��܂���B";
                result = false;
            }

            // PM��BL�R�[�h
            else if (this.tNedit_PMBLCd.Text == string.Empty)
            {
                control = this.tNedit_PMBLCd;
                message = "PM��BL�R�[�h����͂��ĉ������B";
                result = false;
            }
            else if (this._pmBLCdGoodsFullName.Trim() == string.Empty)
            {
                control = this.tNedit_PMBLCd;
                message = "PM��BL�R�[�h�}�X�^�ɓo�^����Ă��܂���B";
                result = false;
            }

            // SF��BL�R�[�h
            else if (this.tNedit_SFBLCd.Text == string.Empty)
            {
                control = this.tNedit_SFBLCd;
                message = "SF��BL�R�[�h����͂��ĉ������B";
                result = false;
            }
            else if (this._sfBLCdGoodsFullName.Trim() == string.Empty)
            {
                // �X�V���[�h�ŁA�ҏW�񐔂��O��̏ꍇ�͏���
                if (!(this.Mode_Label.Text.Trim() == UPDATE_MODE && this._sfBLCdEditCnt.Equals(0)))
                {
                    control = this.tNedit_SFBLCd;
                    message = "SF��BL�R�[�h�}�X�^�ɓo�^����Ă��܂���B";
                    result = false;
                }
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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
            this._blGoodsCdChgUClone = null;

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
        /// ���Ӑ於�̂̎擾
        /// </summary>
        /// <param name="customerCode"> ���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private string GetCustomerNm(int customerCode)
        {

            string customerNm = string.Empty;
            if (_customerTb == null)
            {
                GetAllCustomerNm();
            }
            if (_customerTb != null && _customerTb.ContainsKey(customerCode))
            {
                customerNm = (string)_customerTb[customerCode];
            }
            return customerNm;
        }

        /// <summary>
        /// ���Ӑ於�̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂̎擾���s���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void GetAllCustomerNm()
        {
            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            if (this._customerTb == null)
            {
                _customerTb = new Hashtable();
            }
            else
            {
                _customerTb.Clear();
            }


            List<CustomerInfo> customerList;

            int status = this._customerInfoAcs.Search(this._enterpriseCode, true, true, out customerList);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (CustomerInfo customer in customerList)
                {
                    if (customer.LogicalDeleteCode == 0)
                    {
                        _customerTb.Add(customer.CustomerCode, customer.CustomerSnm);
                    }
                }
            }
        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�W�J����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�ϊ��}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void BLGoodsCdChgUToDataSet(BLGoodsCdChgU blCodeChange, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].NewRow();
                this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (blCodeChange.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][DELETE_DATE] = blCodeChange.UpdateDateTimeJpInFormal;
            }

            // ���Ӑ�R�[�h
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][CUSTOMER_CODE_TITLE] = blCodeChange.CustomerCode;
            // ���Ӑ於��
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][CUSTOMER_NAME_TITLE] = GetCustomerNm(blCodeChange.CustomerCode);
            // PM��BL�R�[�h
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][PMBL_CODE_TITLE] = blCodeChange.PMBLGoodsCode;
            // SF��BL�R�[�h
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][SFBL_CODE_TITLE] = blCodeChange.SFBLGoodsCode;

            // GUID
            this.Bind_DataSet.Tables[BLGOODSCDCHGU_TABLE].Rows[index][GUID_TITLE] = blCodeChange.FileHeaderGuid;

            if (this._blCodeChangeTable.ContainsKey(blCodeChange.FileHeaderGuid))
            {
                this._blCodeChangeTable.Remove(blCodeChange.FileHeaderGuid);
            }
            this._blCodeChangeTable.Add(blCodeChange.FileHeaderGuid, blCodeChange);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable blCodeChangeTable = new DataTable(BLGOODSCDCHGU_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            blCodeChangeTable.Columns.Add(DELETE_DATE, typeof(string));                     // �폜��       
            blCodeChangeTable.Columns.Add(CUSTOMER_CODE_TITLE, typeof(int));			    // ���Ӑ�R�[�h
            blCodeChangeTable.Columns.Add(CUSTOMER_NAME_TITLE, typeof(string));            // ���Ӑ於��
            blCodeChangeTable.Columns.Add(PMBL_CODE_TITLE, typeof(int));			    // PM��BL�R�[�h
            blCodeChangeTable.Columns.Add(SFBL_CODE_TITLE, typeof(int));			    // SF��BL�R�[�h

            blCodeChangeTable.Columns.Add(GUID_TITLE, typeof(Guid));
            this.Bind_DataSet.Tables.Add(blCodeChangeTable);
        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C���N���X��ʓW�J����
        /// </summary>
        /// <param name="blCodeChange">BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C���I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void BLGoodsCdChgUToScreen(BLGoodsCdChgU blCodeChange)
        {
            //���Ӑ�R�[�h
            this.tNedit_CustomerCd.Text = blCodeChange.CustomerCode.ToString();
            //���Ӑ於��
            this.uLabel_CustomerNm.Text = GetCustomerNm(blCodeChange.CustomerCode);
            //PM��BL�R�[�h
            this.tNedit_PMBLCd.Text = blCodeChange.PMBLGoodsCode.ToString();
            //SF��BL�R�[�h
            this.tNedit_SFBLCd.Text = blCodeChange.SFBLGoodsCode.ToString();
        }

        #endregion

        /// <summary>
        /// PM��BL�R�[�h�@�K�C�h�{�^���N���b�N
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <br>Note        : </br>
        /// <br>Programmer  : 30745 �g�� �F��</br>
        /// <br>Date        : 2012/08/01</br>
        /// </remarks>
        private void uButton_PMBLCdGuid_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            // �K�C�h�N��
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_PMBLCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this._pmBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;

                // ���t�H�[�J�X
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// SF��BL�R�[�h�@�K�C�h�{�^���N���b�N
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <br>Note        : </br>
        /// <br>Programmer  : 30745 �g�� �F��</br>
        /// <br>Date        : 2012/08/01</br>
        /// </remarks>
        private void uButton_SFBLCdGuid_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            // �K�C�h�N��
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �J�n
                tNedit_SFBLCd.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this._sfBLCdGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;

                // ���t�H�[�J�X
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }
}

