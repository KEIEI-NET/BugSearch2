using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Microsoft.VisualBasic;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BL�O���[�v�}�X�^�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: BL�O���[�v�}�X�^�̐ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/06/11</br>
    /// <br>UpdateNote   : 2008/10/07 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2008/10/20       �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// </remarks>
    public partial class PMKHN09060UA : Form, IMasterMaintenanceMultiType
    {
        #region Constants

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �e�[�u������
        private const string BLGROUPU_TABLE = "BLGroupU";

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE      = "�폜��";
        private const string BLGROUPCODE_TITLE      = "��ٰ�ߺ���";
        private const string BLGROUPNAME_TITLE      = "��ٰ�ߺ��ޖ�";
        private const string BLGROUPHALFNAME_TITLE  = "��ٰ�ߺ��ޖ�(��)";
        private const string GOODSLGROUPCODE_TITLE  = "���i�啪�ރR�[�h";
        private const string GOODSLGROUPNAME_TITLE  = "���i�啪�ޖ�";
        private const string GOODSMGROUPCODE_TITLE  = "���i�����ރR�[�h";
        private const string GOODSMGROUPNAME_TITLE  = "���i�����ޖ�";
        private const string SALESCODE_TITLE        = "�̔��敪�R�[�h";
        private const string SALESCODENAME_TITLE    = "�̔��敪��";
        private const string DIVISION_TITLE         = "�f�[�^�敪�R�[�h";
        private const string DIVISIONNAME_TITLE     = "�f�[�^�敪";
        private const string GUID_TITLE             = "Guid";

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKHN09060U";

        //�f�[�^�敪
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;

        #endregion Constants

        #region Private Members

        // �v���p�e�B�p
        private int _dataIndex;
        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // ��ƃR�[�h
        private string _enterpriseCode;

        // BL�O���[�v�}�X�^�A�N�Z�X�N���X
        private BLGroupUAcs _bLGroupUAcs;

        // ���[�U�[�K�C�h�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;

        private Hashtable _bLGroupUTable;

        private int _indexBuf;

        // �f�[�^�敪(0:���[�U�[ 1:��)
        private int _offerDataDiv;

        // �I�����̕ҏW�`�F�b�N�p
        private BLGroupU _bLGroupUClone;

        private GoodsGroupUAcs _goodsGroupUAcs;

        private Dictionary<int, UserGdBd> _goodsLGroupDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupDic;
        private Dictionary<int, UserGdBd> _salesCodeDic;

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		
        #endregion Private Members

        #region Constructor

        /// <summary>
        /// BL�O���[�v�}�X�^�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public PMKHN09060UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._dataIndex = -1;
            this._canClose = false;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canSpecificationSearch = false;
            this._defaultAutoFillToColumn = false;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._bLGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._bLGroupUTable = new Hashtable();

            // GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            this._goodsGroupUAcs = new GoodsGroupUAcs();

            // �e��}�X�^�Ǎ�
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSalesCode();
        }

        #endregion Constructor

        #region IMasterMaintenanceMultiType �����o

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

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
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

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(BLGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(BLGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(BLGROUPHALFNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GOODSLGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSLGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GOODSMGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SALESCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(SALESCODENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = BLGROUPU_TABLE;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̂��ߖ�����
            return 0;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int Delete()
        {
            // DEL 2008/10/07 �s��Ή�[6307] ---------->>>>>
            //if (this._offerDataDiv == DIVISION_OFR)
            //{
            //    // �񋟃f�[�^�폜�s��
            //    TMsgDisp.Show(
            //        this, 								// �e�E�B���h�E�t�H�[��
            //        emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
            //        ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
            //        "�񋟃f�[�^�͍폜�ł��܂���B", 	// �\�����郁�b�Z�[�W
            //        0, 									// �X�e�[�^�X�l
            //        MessageBoxButtons.OK);				// �\������{�^��
            //    return 0;
            //}
            // DEL 2008/10/07 �s��Ή�[6307] ----------<<<<<

            // �n�b�V���L�[�쐬
            string hashKey = CreateHashKey(this._dataIndex);

            BLGroupU blGroupU = new BLGroupU();
            blGroupU = (BLGroupU)this._bLGroupUTable[hashKey];

            //--- ADD 2008/10/20 ���s�[6307]�̖߂�Ή�----------------------------->>>>>
            // �񋟃f�[�^�̍폜�͕s��
            if (blGroupU.OfferDataDiv == DIVISION_OFR)
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
                    ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�񋟃f�[�^�͍폜�ł��܂���B", 	// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                return 0;
            }
            //--- ADD 2008/10/20 -----------------------------------------------------<<<<<

            // �_���폜����
            int status = this._bLGroupUAcs.LogicalDelete(ref blGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �f�[�^�Z�b�g�W�J
                        BLGroupUToDataSet(blGroupU.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, false);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�_���폜�Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._bLGroupUAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// BL�O���[�v��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = -1;
            totalCount = 0;

            try
            {
                // �N���A
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Clear();
                this._bLGroupUTable.Clear();

                ArrayList retList = new ArrayList();

                // ��������
                status = this._bLGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        int index = 0;
                        foreach (BLGroupU bLGroupU in retList)
                        {
                            // �n�b�V���L�[�쐬
                            string hashKey = CreateHashKey(bLGroupU);

                            if (this._bLGroupUTable.ContainsKey(hashKey) == false)
                            {
                                // �f�[�^�Z�b�g�W�J
                                BLGroupUToDataSet(bLGroupU.Clone(), index);
                                ++index;
                            }
                        }

                        totalCount = retList.Count;

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 					        // �v���O��������
                            "Search", 					        // ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._bLGroupUAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

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
                    "�ǂݍ��݂Ɏ��s���܂����B",			  // �\�����郁�b�Z�[�W 
                    status,								  // �X�e�[�^�X�l
                    this._bLGroupUAcs,				      // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,				  // �\������{�^��
                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                status = -1;
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
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 0;
        }

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        #endregion

        #region Private Methods

        /// <summary>
        /// HashTable�pKey�쐬����
        /// </summary>
        /// <param name="blGroupU">BL�O���[�v�}�X�^�I�u�W�F�N�g</param>
        /// <returns>�L�[</returns>
        /// <remarks>
        /// <br>Note       : �n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string CreateHashKey(BLGroupU blGroupU)
        {
            string hashKey = blGroupU.BLGroupCode.ToString().PadLeft(5, '0') + blGroupU.OfferDataDiv.ToString();

            return hashKey;
        }

        /// <summary>
        /// HashTable�pKey�쐬����
        /// </summary>
        /// <param name="dataIndex">�O���b�h�C���f�b�N�X</param>
        /// <returns>�L�[</returns>
        /// <remarks>
        /// <br>Note       : �n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string CreateHashKey(int dataIndex)
        {
            int bLGroupCode = int.Parse((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[dataIndex][BLGROUPCODE_TITLE]);
            int divisionCode = (int)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[dataIndex][DIVISION_TITLE];
            string hashKey = bLGroupCode.ToString().PadLeft(5, '0') + divisionCode.ToString();

            return hashKey;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable dataTable = new DataTable(BLGROUPU_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dataTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            dataTable.Columns.Add(BLGROUPCODE_TITLE, typeof(string));
            dataTable.Columns.Add(BLGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(BLGROUPHALFNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSLGROUPCODE_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSLGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSMGROUPCODE_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSMGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(SALESCODE_TITLE, typeof(string));
            dataTable.Columns.Add(SALESCODENAME_TITLE, typeof(string));
            dataTable.Columns.Add(DIVISION_TITLE, typeof(int));
            dataTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private int ShowUserGuide(out UserGdBd userGdBd, int userGuideDivCd)
        {
            int status;
            UserGdHd userGdHd = new UserGdHd();

            userGdBd = new UserGdBd();

            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, userGuideDivCd);

            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
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
        /// ���i�啪�ޓǍ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�啪�ވꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ReadGoodsLGroup()
        {
            this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

            ArrayList retList;

            // ���[�U�[�K�C�h�f�[�^�擾(���i�啪��)
            int status = GetUserGuideBd(out retList, 70);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// ���i�啪�ޖ��̎擾����
        /// </summary>
        /// <param name="goodsLGroupCode">���i�啪�ރR�[�h</param>
        /// <remarks>
        /// <br>Note       : ���i�啪�ޖ��̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string GetGoodsLGroupName(int goodsLGroupCode)
        {
            string goodsLGroupName = "";

            if (this._goodsLGroupDic.ContainsKey(goodsLGroupCode))
            {
                goodsLGroupName = this._goodsLGroupDic[goodsLGroupCode].GuideName.Trim();
            }

            return goodsLGroupName;
        }

        /// <summary>
        /// ���i�����ޓǍ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�����ވꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ReadGoodsMGroup()
        {
            this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

            ArrayList retList;

            int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (GoodsGroupU goodsGroupU in retList)
                {
                    if (goodsGroupU.LogicalDeleteCode == 0)
                    {
                        this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// ���i�����ޖ��̎擾����
        /// </summary>
        /// <param name="goodsMGroupCode">���i�����ރR�[�h</param>
        /// <remarks>
        /// <br>Note       : ���i�����ޖ��̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode)
        {
            string goodsMGroupName = "";

            if (this._goodsGroupDic.ContainsKey(goodsMGroupCode))
            {
                goodsMGroupName = this._goodsGroupDic[goodsMGroupCode].GoodsMGroupName.Trim();
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// �̔��敪�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �̔��敪�ꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ReadSalesCode()
        {
            this._salesCodeDic = new Dictionary<int, UserGdBd>();

            ArrayList retList;

            // ���[�U�[�K�C�h�f�[�^�擾(�̔��敪)
            int status = GetUserGuideBd(out retList, 71);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// �̔��敪���̎擾����
        /// </summary>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �̔��敪���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode)
        {
            string salesCodeName = "";

            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].GuideName.Trim();
            }

            return salesCodeName;
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_BLGloupCode.Size = new Size(52, 24);
            this.BLGroupName_tEdit.Size = new Size(337, 24);
            this.BLGroupHalfName_tEdit.Size = new Size(337, 24);
            this.tNedit_GoodsLGroup.Size = new Size(52, 24);
            this.GoodsLGroupName_tEdit.Size = new Size(337, 24);
            this.tNedit_GoodsMGroup.Size = new Size(52, 24);
            this.GoodsMGroupName_tEdit.Size = new Size(337, 24);
            this.tNedit_SalesCode.Size = new Size(52, 24);
            this.SalesCodeName_tEdit.Size = new Size(337, 24);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j/br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = "";

            this.tNedit_BLGloupCode.Clear();
            this.BLGroupName_tEdit.Clear();
            this.tNedit_GoodsLGroup.Clear();
            this.GoodsLGroupName_tEdit.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.GoodsMGroupName_tEdit.Clear();
            this.tNedit_SalesCode.Clear();
            this.SalesCodeName_tEdit.Clear();
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h(INSERT_MODE�F�V�K�@UPDATE_MODE�F�X�V�@REFER_MODE�F�Q�Ɓ@DELETE_MODE�F�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string editMode)
        {
            switch (editMode)
            {
                // �V�K���[�h
                case INSERT_MODE:

                    this.tNedit_BLGloupCode.Enabled = true;
                    this.BLGroupName_tEdit.Enabled = true;
                    this.BLGroupHalfName_tEdit.Enabled = true;      // ADD 2008/10/07 �s��Ή�[6306]
                    this.tNedit_GoodsLGroup.Enabled = true;
                    this.tNedit_GoodsMGroup.Enabled = true;
                    this.tNedit_SalesCode.Enabled = true;

                    this.GoodsLGroupGuide_Button.Enabled = true;
                    this.GoodsMGroupGuide_Button.Enabled = true;
                    this.SalesCodeGuide_Button.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Renewal_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // �X�V���[�h
                case UPDATE_MODE:

                    this.tNedit_BLGloupCode.Enabled = false;
                    this.BLGroupName_tEdit.Enabled = true;
                    this.BLGroupHalfName_tEdit.Enabled = true;      // ADD 2008/10/07 �s��Ή�[6306]
                    this.tNedit_GoodsLGroup.Enabled = true;
                    this.tNedit_GoodsMGroup.Enabled = true;
                    this.tNedit_SalesCode.Enabled = true;

                    this.GoodsLGroupGuide_Button.Enabled = true;
                    this.GoodsMGroupGuide_Button.Enabled = true;
                    this.SalesCodeGuide_Button.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Renewal_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // �폜���[�h
                case DELETE_MODE:

                    this.tNedit_BLGloupCode.Enabled = false;
                    this.BLGroupName_tEdit.Enabled = false;
                    this.BLGroupHalfName_tEdit.Enabled = false;      // ADD 2008/10/07 �s��Ή�[6306]
                    this.tNedit_GoodsLGroup.Enabled = false;
                    this.tNedit_GoodsMGroup.Enabled = false;
                    this.tNedit_SalesCode.Enabled = false;

                    this.GoodsLGroupGuide_Button.Enabled = false;
                    this.GoodsMGroupGuide_Button.Enabled = false;
                    this.SalesCodeGuide_Button.Enabled = false;

                    this.Ok_Button.Enabled = false;
                    this.Renewal_Button.Enabled = false;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = true;
                    this.Delete_Button.Enabled = true;

                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Delete_Button.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "ExclusiveTransaction", 			// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._bLGroupUAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "ExclusiveTransaction", 			// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._bLGroupUAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// BL�O���[�v�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void BLGroupUToDataSet(BLGroupU bLGroupU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[BLGROUPU_TABLE].NewRow();
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (bLGroupU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = bLGroupU.UpdateDateTimeJpInFormal;
            }

            // BL��ٰ�ߺ���
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][BLGROUPCODE_TITLE] = bLGroupU.BLGroupCode.ToString("00000");

            // BL�O���[�v����
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][BLGROUPNAME_TITLE] = bLGroupU.BLGroupName;

            // BL�O���[�v����(�J�i)
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][BLGROUPHALFNAME_TITLE] = bLGroupU.BLGroupKanaName;

            // ���i�啪�ރR�[�h
            if (bLGroupU.GoodsLGroup == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSLGROUPCODE_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSLGROUPCODE_TITLE] = bLGroupU.GoodsLGroup.ToString("0000");
            }

            // ���i�啪�ޖ���
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSLGROUPNAME_TITLE] = GetGoodsLGroupName(bLGroupU.GoodsLGroup);

            // ���i�����ރR�[�h
            if (bLGroupU.GoodsMGroup == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSMGROUPCODE_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSMGROUPCODE_TITLE] = bLGroupU.GoodsMGroup.ToString("0000");
            }

            // ���i�����ޖ���
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GOODSMGROUPNAME_TITLE] = GetGoodsMGroupName(bLGroupU.GoodsMGroup);

            // �̔��敪�R�[�h
            if (bLGroupU.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][SALESCODE_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][SALESCODE_TITLE] = bLGroupU.SalesCode.ToString("0000");
            }

            // �̔��敪����
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][SALESCODENAME_TITLE] = GetSalesCodeName(bLGroupU.SalesCode);
            // �f�[�^�敪�R�[�h
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DIVISION_TITLE] = bLGroupU.OfferDataDiv;

            // �f�[�^�敪����
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][DIVISIONNAME_TITLE] = bLGroupU.OfferDataDivName;
            
            // GUID
            this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[index][GUID_TITLE] = bLGroupU.FileHeaderGuid;

            // �n�b�V���L�[�쐬
            string hashKey = CreateHashKey(bLGroupU);

            // �n�b�V���e�[�u���X�V
            if (this._bLGroupUTable.ContainsKey(hashKey) == true)
            {
                this._bLGroupUTable.Remove(hashKey);
            }
            this._bLGroupUTable.Add(hashKey, bLGroupU);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j/br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            BLGroupU blGroupU = new BLGroupU();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // �f�[�^�敪
                this._offerDataDiv = DIVISION_USR;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // ��ʓW�J����
                BLGroupUToScreen(blGroupU);

                // �N���[���쐬
                this._bLGroupUClone = blGroupU.Clone();

                // ��ʏ��i�[����
                ScreenToBLGroupU(ref this._bLGroupUClone);

                // �t�H�[�J�X�ݒ�
                this.tNedit_BLGloupCode.Focus();
            }
            else
            {
                // �n�b�V���L�[�쐬
                string hashKey = CreateHashKey(this._dataIndex);

                blGroupU = (BLGroupU)this._bLGroupUTable[hashKey];

                // �f�[�^�敪
                this._offerDataDiv = blGroupU.OfferDataDiv;

                // �폜�̏ꍇ
                if ((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    BLGroupUToScreen(blGroupU);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }
                // �X�V�̏ꍇ
                else
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // ��ʓW�J����
                    BLGroupUToScreen(blGroupU);

                    // �N���[���쐬
                    this._bLGroupUClone = blGroupU.Clone();

                    // ��ʏ��i�[����
                    ScreenToBLGroupU(ref this._bLGroupUClone);

                    // �t�H�[�J�X�ݒ�
                    this.BLGroupName_tEdit.Focus();
                }
            }

            // _indexBuf�o�b�t�@�ێ�
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// BL�O���[�v�ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="blGroupU">BL�O���[�v�ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void BLGroupUToScreen(BLGroupU blGroupU)
        {
            // BL��ٰ�ߺ���
            if (blGroupU.BLGroupCode == 0)
            {
                this.tNedit_BLGloupCode.Clear();
            }
            else
            {
                this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);
            }

            // BL�O���[�v����
            this.BLGroupName_tEdit.DataText = blGroupU.BLGroupName.Trim();

            // BL�O���[�v����(�J�i)
            this.BLGroupHalfName_tEdit.DataText = blGroupU.BLGroupKanaName.Trim();

            // ���i�啪�ރR�[�h
            if (blGroupU.GoodsLGroup == 0)
            {
                this.tNedit_GoodsLGroup.Clear();
            }
            else
            {
                this.tNedit_GoodsLGroup.SetInt(blGroupU.GoodsLGroup);
            }

            // ���i�啪�ޖ���
            this.GoodsLGroupName_tEdit.DataText = GetGoodsLGroupName(blGroupU.GoodsLGroup);

            // ���i�����ރR�[�h
            if (blGroupU.GoodsMGroup == 0)
            {
                this.tNedit_GoodsMGroup.Clear();
            }
            else
            {
                this.tNedit_GoodsMGroup.SetInt(blGroupU.GoodsMGroup);
            }

            // ���i�����ޖ���
            this.GoodsMGroupName_tEdit.DataText = GetGoodsMGroupName(blGroupU.GoodsMGroup);

            // �̔��敪�R�[�h
            if (blGroupU.SalesCode == 0)
            {
                this.tNedit_SalesCode.Clear();
            }
            else
            {
                this.tNedit_SalesCode.SetInt(blGroupU.SalesCode);
            }

            // �̔��敪����
            this.SalesCodeName_tEdit.DataText = GetSalesCodeName(blGroupU.SalesCode);
        }

        /// <summary>
        /// ��ʏ��BL�O���[�v�ݒ�N���X�i�[����
        /// </summary>
        /// <param name="blGroupU">BL�O���[�v�ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�BL�O���[�v�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenToBLGroupU(ref BLGroupU blGroupU)
        {
            // ��ƃR�[�h
            blGroupU.EnterpriseCode = this._enterpriseCode;

            // BL��ٰ�ߺ���
            blGroupU.BLGroupCode = this.tNedit_BLGloupCode.GetInt();

            // BL�O���[�v����
            blGroupU.BLGroupName = this.BLGroupName_tEdit.DataText.Trim();

            // BL�O���[�v����(�J�i)
            blGroupU.BLGroupKanaName = this.BLGroupHalfName_tEdit.DataText.Trim();

            // ���i�啪�ރR�[�h
            blGroupU.GoodsLGroup = this.tNedit_GoodsLGroup.GetInt();

            // ���i�����ރR�[�h
            blGroupU.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();

            // �̔��敪�R�[�h
            blGroupU.SalesCode = this.tNedit_SalesCode.GetInt();
        }

        /// <summary>
        /// BL�O���[�v�ݒ�}�X�^�ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�ݒ�}�X�^��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool SaveProc()
        {
            // ���̓f�[�^�`�F�b�N
            if (CheckScreenInput() != true)
            {
                return (false);
            }

            BLGroupU bLGroupU = new BLGroupU();

            // �o�^���R�[�h���擾
            if (this._indexBuf >= 0)
            {
                // �n�b�V���L�[�쐬
                string hashKey = CreateHashKey(this._dataIndex);

                bLGroupU = ((BLGroupU)this._bLGroupUTable[hashKey]).Clone();
            }

            // ��ʏ��i�[
            ScreenToBLGroupU(ref bLGroupU);

            // �ۑ�����
            int status = this._bLGroupUAcs.Write(ref bLGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash�X�V����
                        BLGroupUToDataSet(bLGroupU, this._indexBuf);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                        this, 										        // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 				        // �G���[���x��
                        ASSEMBLY_ID, 								        // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���̸�ٰ�ߺ��ނ͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                        0, 											        // �X�e�[�^�X�l
                        MessageBoxButtons.OK);						        // �\������{�^��

                        this.tNedit_BLGloupCode.Focus();

                        return (false);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, false);

                        break;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SaveWarehouse",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._bLGroupUAcs,				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

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

            return (true);
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // BL��ٰ�ߺ���
                if ((this.tNedit_BLGloupCode.DataText == "") || (this.tNedit_BLGloupCode.GetInt() == 0))
                {
                    errMsg = "��ٰ�ߺ��ނ���͂��Ă��������B";
                    this.tNedit_BLGloupCode.Focus();
                    return (false);
                }
                if (this._offerDataDiv == DIVISION_USR)
                {
                    // ���[�U�[�f�[�^�̏ꍇ�̂�9000�ȏォ�ǂ����`�F�b�N
                    if (this.tNedit_BLGloupCode.GetInt() < 9000)
                    {
                        errMsg = "��ٰ�ߺ��ނ�9000�ȏ�̐��l����͂��Ă��������B";
                        this.tNedit_BLGloupCode.Focus();
                        return (false);
                    }
                }

                // BL�O���[�v����
                if (this.BLGroupName_tEdit.DataText.Trim() == "")
                {
                    errMsg = "��ٰ�ߺ��ޖ�����͂��Ă��������B";
                    this.BLGroupName_tEdit.Focus();
                    return (false);
                }

                // BL�O���[�v����(�J�i)
                if (this.BLGroupHalfName_tEdit.DataText.Trim() == "")
                {
                    errMsg = "��ٰ�ߺ��ޖ�(��)����͂��Ă��������B";
                    this.BLGroupHalfName_tEdit.Focus();
                    return (false);
                }

                // ���i�啪��
                if (this.tNedit_GoodsLGroup.DataText != "")
                {
                    if (GetGoodsLGroupName(this.tNedit_GoodsLGroup.GetInt()) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        this.tNedit_GoodsLGroup.Focus();
                        return (false);
                    }
                }

                // ���i������
                if (this.tNedit_GoodsMGroup.DataText != "")
                {
                    if (GetGoodsMGroupName(this.tNedit_GoodsMGroup.GetInt()) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        this.tNedit_GoodsMGroup.Focus();
                        return (false);
                    }
                }

                // �̔��敪
                if (this.tNedit_SalesCode.DataText != "")
                {
                    if (GetSalesCodeName(this.tNedit_SalesCode.GetInt()) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        this.tNedit_SalesCode.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
                    ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    errMsg, 	                        // �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̔�r���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            BLGroupU bLGroupU = new BLGroupU();
            bLGroupU = this._bLGroupUClone.Clone();

            // ��ʏ��擾
            ScreenToBLGroupU(ref bLGroupU);

            // �ŏ��Ɏ擾������ʏ��Ɣ�r
            if (!(this._bLGroupUClone.Equals(bLGroupU)))
            {
                //��ʏ�񂪕ύX����Ă����ꍇ
                return (false);
            }

            return (true);
        }

        #endregion Private Methods

        #region Control Events

        /// <summary>
        /// Form.Load �C�x���g(PMKHN09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09060UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.Revive_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.REVIVAL];
            this.Delete_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.DELETE];
            this.GoodsLGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesCodeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Renewal_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.RENEWAL];

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMKHN09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09060UA_VisibleChanged(object sender, EventArgs e)
        {
            this.Owner.Activate();

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMKHN09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09060UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
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
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // �e��}�X�^�Ǎ�
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSalesCode();

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if ((this._offerDataDiv == DIVISION_OFR) && (CompareOriginalScreen() == true))
            {
                // �񋟃f�[�^�@���@��ʏ�񖢕ύX�̏ꍇ
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
            }
            else
            {
                // �ۑ�����
                SaveProc();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʏ���r
                if (!CompareOriginalScreen())
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
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
                                // �ۑ�����
                                if (SaveProc() != true)
                                {
                                    return;
                                }

                                this.DialogResult = DialogResult.OK;

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;

                                break;
                            }
                        default:
                            {
                                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tNedit_BLGloupCode.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �n�b�V���L�[�쐬
            string hashKey = CreateHashKey(this._dataIndex);

            BLGroupU bLGroupU = ((BLGroupU)this._bLGroupUTable[hashKey]).Clone();

            // ��������
            status = this._bLGroupUAcs.Revival(ref bLGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        BLGroupUToDataSet(bLGroupU, this._dataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r��
                        ExclusiveTransaction(status, false);

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Revive_Button_Click",				  // ��������
                            TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                            "�����Ɏ��s���܂����B",				�@// �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._bLGroupUAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        return;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

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
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2);						// �����\���{�^��


            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �n�b�V���L�[�쐬
            string hashKey = CreateHashKey(this._dataIndex);

            BLGroupU bLGroupU = ((BLGroupU)this._bLGroupUTable[hashKey]).Clone();

            // �����폜����
            status = this._bLGroupUAcs.Delete(bLGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[this._dataIndex].Delete();

                        this._bLGroupUTable.Remove(hashKey);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, false);

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Delete_Button_Click",				  // ��������
                            TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                            "�폜�Ɏ��s���܂����B",				  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._bLGroupUAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        return;
                    }
            }

            int totalCount = 0;

            // �Č�������
            status = Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

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
        /// Control.Click �C�x���g(GoodsLGroupGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �啪�ރK�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                UserGdBd userGdBd = new UserGdBd();

                status = ShowUserGuide(out userGdBd, 70);
                if (status == 0)
                {
                    this.tNedit_GoodsLGroup.SetInt(userGdBd.GuideCode);
                    this.GoodsLGroupName_tEdit.DataText = userGdBd.GuideName.Trim();

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_GoodsMGroup.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(GoodsMGroupGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����ރK�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsMGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();
                GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();

                status = goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
                if (status == 0)
                {
                    this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                    this.GoodsMGroupName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_SalesCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(SalesCodeGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �̔��敪�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void SalesCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                UserGdBd userGdBd = new UserGdBd();

                status = ShowUserGuide(out userGdBd, 71);
                if (status == 0)
                {
                    this.tNedit_SalesCode.SetInt(userGdBd.GuideCode);
                    this.SalesCodeName_tEdit.DataText = userGdBd.GuideName.Trim();

                    // �t�H�[�J�X�ݒ�
                    //this.Ok_Button.Focus();
                    this.Renewal_Button.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "BLGroupHalfName_tEdit":
                    // BL�O���[�v���̂Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // ���i�啪�ރR�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = tNedit_GoodsLGroup;
                    }
                    break;
                case "Ok_Button":
                case "Cancel_Button":
                    // �ۑ��{�^���A����{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // �̔��敪�K�C�h�{�^���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = SalesCodeGuide_Button;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ValueChanged �C�x���g(��ٰ�ߺ��ޖ���)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̒l���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void BLGroupName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.BLGroupName_tEdit.DataText.Equals(""))
            {
                this.BLGroupHalfName_tEdit.Clear();
                return;
            }
        }

        /// <summary>
        /// ValueChanged �C�x���g(��ٰ�ߺ��ޖ���(��))
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̒l���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void BLGroupHalfName_tEdit_ValueChanged(object sender, EventArgs e)
        {
            // �����̸�ٰ�ߺ��ޖ���(��)�擾
            TEdit tEdit = (TEdit)sender;

            // ���p�ɕϊ�
            tEdit.Text = Strings.StrConv(tEdit.Text.Trim(), VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/11</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                case "tNedit_BLGloupCode":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tNedit_BLGloupCode;
                            }
                        }
                        break;
                    }
                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                case "tNedit_GoodsLGroup":
                    if ((this.tNedit_GoodsLGroup.DataText == "") || (this.tNedit_GoodsLGroup.GetInt() == 0))
                    {
                        this.GoodsLGroupName_tEdit.DataText = "";
                        return;
                    }

                    // ���i�啪�ރR�[�h�擾
                    int goodsLGroupCode = this.tNedit_GoodsLGroup.GetInt();

                    // ���i�啪�ޖ��̎擾
                    this.GoodsLGroupName_tEdit.DataText = GetGoodsLGroupName(goodsLGroupCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.GoodsLGroupName_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        }
                    }
                    break;
                case "tNedit_GoodsMGroup":
                    if ((this.tNedit_GoodsMGroup.DataText == "") || (this.tNedit_GoodsMGroup.GetInt() == 0))
                    {
                        this.GoodsMGroupName_tEdit.DataText = "";
                        return;
                    }

                    // ���i�����ރR�[�h�擾
                    int goodsMGroupCode = this.tNedit_GoodsMGroup.GetInt();

                    // ���i�����ޖ��̎擾
                    this.GoodsMGroupName_tEdit.DataText = GetGoodsMGroupName(goodsMGroupCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.GoodsMGroupName_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_SalesCode;
                        }
                    }
                    break;
                case "tNedit_SalesCode":
                    if ((this.tNedit_SalesCode.DataText == "") || (this.tNedit_SalesCode.GetInt() == 0))
                    {
                        this.SalesCodeName_tEdit.DataText = "";
                        return;
                    }

                    // �̔��敪�R�[�h�擾
                    int salesCode = this.tNedit_SalesCode.GetInt();

                    // �̔��敪���̎擾
                    this.SalesCodeName_tEdit.DataText = GetSalesCodeName(salesCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.SalesCodeName_tEdit.DataText.Trim() != "")
                        {
                            //e.NextCtrl = this.Ok_Button;
                            e.NextCtrl = this.Renewal_Button;
                        }
                    }
                    break;
                case "BLGroupHalfName_tEdit":
                    // BL�O���[�v���̂Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // ���i�啪�ރR�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = tNedit_GoodsLGroup;
                    }
                    break;
                case "Ok_Button":
                case "Cancel_Button":
                    // �ۑ��{�^���A����{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // �̔��敪�K�C�h�{�^���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = SalesCodeGuide_Button;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion Control Events

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSalesCode();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "PMKHN09060U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �O���[�v�R�[�h
            int blGloupCode = tNedit_BLGloupCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsBLGloupCode = int.Parse((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[i][BLGROUPCODE_TITLE]);
                if (blGloupCode == dsBLGloupCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[BLGROUPU_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̃O���[�v�R�[�h�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �O���[�v�R�[�h�̃N���A
                        tNedit_BLGloupCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̃O���[�v�R�[�h�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // �O���[�v�R�[�h�̃N���A
                                tNedit_BLGloupCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}