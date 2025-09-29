using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�����ސݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���i�����ނ̐ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/06/11</br>
    /// <br>UpdateNote   : 2008/10/07 30462 �s�V �m���@�o�O�C��</br>
    /// <br>Update Note : 2012/11/08 �c����</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 20130116�z�M��</br>
    /// <br>              Redmine#33228 �񋟕��f�[�^�u2000�v�u3000�v�u4000�v�Ȃǂ��\������Ȃ��C��</br>
    /// </remarks>
    public partial class PMKHN09070UA : Form, IMasterMaintenanceMultiType
    {
        #region Constants

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �e�[�u������
        private const string GOODSGROUPU_TABLE = "GoodsGroupU";

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE      = "�폜��";
        private const string GOODSMGROUPCODE_TITLE  = "���i�����ރR�[�h";
        // DEL 2008/10/07 �s��Ή�[6314] ��
        //private const string GOODSMGROUPNAME_TITLE  = "���i�����ޖ���";
        private const string GOODSMGROUPNAME_TITLE  = "���i�����ޖ�";     // ADD 2008/10/07 �s��Ή�[6314]
        private const string DIVISION_TITLE         = "�f�[�^�敪�R�[�h";
        private const string DIVISIONNAME_TITLE     = "�f�[�^�敪";
        private const string GUID_TITLE             = "Guid";

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKHN09070U";

        //�f�[�^�敪
        private const int DIVISION_USR = 0;         // ���[�U�[�f�[�^
        private const int DIVISION_OFR = 1;         // �񋟃f�[�^

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

        // ���i�����ރ}�X�^�A�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs;

        // ���[�U�[�K�C�h�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;

        private Hashtable _goodsGroupUTable;

        private int _indexBuf;

        // �f�[�^�敪(0:���[�U�[ 1:��)
        private int _divisionCode;

        // �I�����̕ҏW�`�F�b�N�p
        private GoodsGroupU _goodsGroupUClone;

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		
        #endregion Private Members

        #region Constructor

        /// <summary>
        /// ���i�����ސݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public PMKHN09070UA()
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
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsGroupUTable = new Hashtable();

            // GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;
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
            // DEL 2008/10/07 �s��Ή�[6311] ��
            //appearanceTable.Add(GOODSMGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMGROUPCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "0000", Color.Black));    // ADD 2008/10/07 �s��Ή�[6311]
            appearanceTable.Add(GOODSMGROUPNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); 
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
            tableName = GOODSGROUPU_TABLE;
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
        /// <br>Update Note: 2012/11/08 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20130116�z�M��</br>
        /// <br>             Redmine#33228��#3 �񋟃f�[�^���폜�ł�����A���[�U�[���f�[�^���폜�ł��Ȃ������肷�錻�ۂ̏C��</br>
        /// </remarks>
        public int Delete()
        {
            //----- ADD 2012/11/08 �c���� Redmine#33228 ---------------------------->>>>>
            // �n�b�V���L�[�쐬
            string hashKey = CreateHashKey(this._dataIndex);

            GoodsGroupU goodsGroupU = new GoodsGroupU();
            goodsGroupU = (GoodsGroupU)this._goodsGroupUTable[hashKey];
            //----- ADD 2012/11/08 �c���� Redmine#33228 ----------------------------<<<<<

            //if (this._divisionCode == DIVISION_OFR) // DEL 2012/11/08 �c���� Redmine#33228
            if (goodsGroupU.DivisionCode == DIVISION_OFR) // ADD 2012/11/08 �c���� Redmine#33228
            {
                // �񋟃f�[�^�폜�s��
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
                    ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�񋟃f�[�^�͍폜�ł��܂���B", 	// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                return 0;
            }

            //----- DEL 2012/11/08 �c���� Redmine#33228 ---------------------------->>>>>
            //// �n�b�V���L�[�쐬
            //string hashKey = CreateHashKey(this._dataIndex);

            //GoodsGroupU goodsGroupU = new GoodsGroupU();
            //goodsGroupU = (GoodsGroupU)this._goodsGroupUTable[hashKey];
            //----- DEL 2012/11/08 �c���� Redmine#33228 ----------------------------<<<<<

            // �_���폜����
            int status = this._goodsGroupUAcs.LogicalDelete(ref goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �f�[�^�Z�b�g�W�J
                        GoodsGroupUToDataSet(goodsGroupU.Clone(), this._dataIndex);
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
                            this._goodsGroupUAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// ���i�����ތ�������
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
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Clear();
                this._goodsGroupUTable.Clear();

                ArrayList retList = new ArrayList();

                // ��������
                status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        int index = 0;
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            // �n�b�V���L�[�쐬
                            string hashKey = CreateHashKey(goodsGroupU);

                            if (this._goodsGroupUTable.ContainsKey(hashKey) == false)
                            {
                                // �f�[�^�Z�b�g�W�J
                                GoodsGroupUToDataSet(goodsGroupU.Clone(), index);
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
                            this._goodsGroupUAcs, 				// �G���[�����������I�u�W�F�N�g
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
                    this._goodsGroupUAcs,				  // �G���[�����������I�u�W�F�N�g
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
        /// <param name="goodsGroupU">���i�����ރ}�X�^�I�u�W�F�N�g</param>
        /// <returns>�L�[</returns>
        /// <remarks>
        /// <br>Note       : �n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// <br>Update Note: 2012/11/08 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20130116�z�M��</br>
        /// <br>             Redmine#33228 �񋟕��f�[�^�u2000�v�u3000�v�u4000�v�Ȃǂ��\������Ȃ��C��</br>
        /// </remarks>
        private string CreateHashKey(GoodsGroupU goodsGroupU)
        {
            //string hashKey = goodsGroupU.GoodsMGroup.ToString().PadRight(4, '0') + goodsGroupU.DivisionCode.ToString(); // DEL 2012/11/08 �c���� Redmine#33228
            string hashKey = goodsGroupU.GoodsMGroup.ToString().PadLeft(4, '0') + goodsGroupU.DivisionCode.ToString(); // ADD 2012/11/08 �c���� Redmine#33228

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
        /// <br>Update Note: 2012/11/08 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20130116�z�M��</br>
        /// <br>             Redmine#33228 �񋟕��f�[�^�u2000�v�u3000�v�u4000�v�Ȃǂ��\������Ȃ��C��</br>
        /// </remarks>
        private string CreateHashKey(int dataIndex)
        {
            int goodsGroupCode = (int)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[dataIndex][GOODSMGROUPCODE_TITLE];
            int divisionCode = (int)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[dataIndex][DIVISION_TITLE];
            //string hashKey = goodsGroupCode.ToString().PadRight(4, '0') + divisionCode.ToString(); // DEL 2012/11/08 �c���� Redmine#33228
            string hashKey = goodsGroupCode.ToString().PadLeft(4, '0') + divisionCode.ToString(); // ADD 2012/11/08 �c���� Redmine#33228

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
            DataTable dataTable = new DataTable(GOODSGROUPU_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dataTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            dataTable.Columns.Add(GOODSMGROUPCODE_TITLE, typeof(int));
            dataTable.Columns.Add(GOODSMGROUPNAME_TITLE, typeof(string));
            dataTable.Columns.Add(DIVISION_TITLE, typeof(int));
            dataTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));
            dataTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(dataTable);
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
            this.tNedit_GoodsMGroup.Size = new Size(52, 24);
            this.GoodsMGroupName_tEdit.Size = new Size(330, 24);
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

            this.tNedit_GoodsMGroup.Clear();
            this.GoodsMGroupName_tEdit.Clear();
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

                    this.tNedit_GoodsMGroup.Enabled = true;
                    this.GoodsMGroupName_tEdit.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // �X�V���[�h
                case UPDATE_MODE:

                    this.tNedit_GoodsMGroup.Enabled = false;
                    this.GoodsMGroupName_tEdit.Enabled = true;

                    this.Ok_Button.Enabled = true;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = false;
                    this.Delete_Button.Enabled = false;

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    break;
                // �폜���[�h
                case DELETE_MODE:

                    this.tNedit_GoodsMGroup.Enabled = false;
                    this.GoodsMGroupName_tEdit.Enabled = false;

                    this.Ok_Button.Enabled = false;
                    this.Cancel_Button.Enabled = true;
                    this.Revive_Button.Enabled = true;
                    this.Delete_Button.Enabled = true;

                    this.Ok_Button.Visible = false;
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
                            this._goodsGroupUAcs, 				// �G���[�����������I�u�W�F�N�g
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
                            this._goodsGroupUAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// ���i�����ސݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="goodsGroupU">���i�����ސݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���i�����ސݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsGroupUToDataSet(GoodsGroupU goodsGroupU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].NewRow();
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (goodsGroupU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DELETE_DATE_TITLE] = goodsGroupU.UpdateDateTimeJpInFormal;
            }

            // ���i�����ރR�[�h
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][GOODSMGROUPCODE_TITLE] = goodsGroupU.GoodsMGroup;

            // ���i�����ޖ���
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][GOODSMGROUPNAME_TITLE] = goodsGroupU.GoodsMGroupName.Trim();

            // �f�[�^�敪�R�[�h
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DIVISION_TITLE] = goodsGroupU.DivisionCode;

            // �f�[�^�敪����
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][DIVISIONNAME_TITLE] = goodsGroupU.DivisionName;

            // GUID
            this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[index][GUID_TITLE] = goodsGroupU.FileHeaderGuid;

            // �n�b�V���L�[�쐬
            string hashKey = CreateHashKey(goodsGroupU);

            // �n�b�V���e�[�u���X�V
            if (this._goodsGroupUTable.ContainsKey(hashKey) == true)
            {
                this._goodsGroupUTable.Remove(hashKey);
            }
            this._goodsGroupUTable.Add(hashKey, goodsGroupU);
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
            GoodsGroupU goodsGroupU = new GoodsGroupU();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // �f�[�^�敪
                this._divisionCode = DIVISION_USR;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // ��ʓW�J����
                GoodsGroupUToScreen(goodsGroupU);

                // �N���[���쐬
                this._goodsGroupUClone = goodsGroupU.Clone();

                // ��ʏ��i�[����
                ScreenToGoodsGroupU(ref this._goodsGroupUClone);

                // �t�H�[�J�X�ݒ�
                this.tNedit_GoodsMGroup.Focus();
            }
            else
            {
                // �n�b�V���L�[�쐬
                string hashKey = CreateHashKey(this._dataIndex);

                goodsGroupU = (GoodsGroupU)this._goodsGroupUTable[hashKey];

                // �f�[�^�敪
                this._divisionCode = goodsGroupU.DivisionCode;

                // �폜�̏ꍇ
                if ((string)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    GoodsGroupUToScreen(goodsGroupU);

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
                    GoodsGroupUToScreen(goodsGroupU);

                    // �N���[���쐬
                    this._goodsGroupUClone = goodsGroupU.Clone();

                    // ��ʏ��i�[����
                    ScreenToGoodsGroupU(ref this._goodsGroupUClone);

                    // �t�H�[�J�X�ݒ�
                    this.GoodsMGroupName_tEdit.Focus();
                }
            }

            // _indexBuf�o�b�t�@�ێ�
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// ���i�����ސݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="goodsGroupU">���i�����ސݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void GoodsGroupUToScreen(GoodsGroupU goodsGroupU)
        {
            // ���i�����ރR�[�h
            if (goodsGroupU.GoodsMGroup == 0)
            {
                this.tNedit_GoodsMGroup.Clear();
            }
            else
            {
                this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            }

            // ���i�����ޖ���
            this.GoodsMGroupName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();
        }

        /// <summary>
        /// ��ʏ�񏤕i�����ސݒ�N���X�i�[����
        /// </summary>
        /// <param name="goodsGroupU">���i�����ސݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂珤�i�����ސݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ScreenToGoodsGroupU(ref GoodsGroupU goodsGroupU)
        {
            // ��ƃR�[�h
            goodsGroupU.EnterpriseCode = this._enterpriseCode;

            // ���i�����ރR�[�h
            goodsGroupU.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();

            // ���i�����ޖ���
            goodsGroupU.GoodsMGroupName = this.GoodsMGroupName_tEdit.DataText.Trim();
        }

        /// <summary>
        /// ���i�����ސݒ�}�X�^�ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�����ސݒ�}�X�^��ۑ����܂��B</br>
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

            GoodsGroupU goodsGroupU = new GoodsGroupU();

            // �o�^���R�[�h���擾
            if (this._indexBuf >= 0)
            {
                // �n�b�V���L�[�쐬
                string hashKey = CreateHashKey(this._dataIndex);

                goodsGroupU = ((GoodsGroupU)this._goodsGroupUTable[hashKey]).Clone();
            }

            // ��ʏ��i�[
            ScreenToGoodsGroupU(ref goodsGroupU);

            // �ۑ�����
            int status = this._goodsGroupUAcs.Write(ref goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash�X�V����
                        GoodsGroupUToDataSet(goodsGroupU, this._indexBuf);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                        this, 										        // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 				        // �G���[���x��
                        ASSEMBLY_ID, 								        // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���̏��i�����ރR�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                        0, 											        // �X�e�[�^�X�l
                        MessageBoxButtons.OK);						        // �\������{�^��

                        this.tNedit_GoodsMGroup.Focus();

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
                            this._goodsGroupUAcs,				// �G���[�����������I�u�W�F�N�g
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
                // ���i�����ރR�[�h
                if (this.tNedit_GoodsMGroup.DataText == "")
                {
                    errMsg = "���i�����ރR�[�h����͂��Ă��������B";
                    this.tNedit_GoodsMGroup.Focus();
                    return (false);
                }
                if (this._divisionCode == DIVISION_USR)
                {
                    // ���[�U�[�f�[�^�̏ꍇ�̂�9000�ȏォ�ǂ����`�F�b�N
                    if (this.tNedit_GoodsMGroup.GetInt() < 9000)
                    {
                        errMsg = "���i�����ރR�[�h��9000�ȏ�̐��l����͂��Ă��������B";
                        this.tNedit_GoodsMGroup.Focus();
                        return (false);
                    }
                }

                //  ���i�����ޖ���
                if (this.GoodsMGroupName_tEdit.DataText == "")
                {
                    errMsg = "���i�����ޖ��̂���͂��Ă��������B";
                    this.GoodsMGroupName_tEdit.Focus();
                    return (false);
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
            GoodsGroupU goodsGroupU = new GoodsGroupU();
            goodsGroupU = this._goodsGroupUClone.Clone();

            // ��ʏ��擾
            ScreenToGoodsGroupU(ref goodsGroupU);

            // �ŏ��Ɏ擾������ʏ��Ɣ�r
            if (!(this._goodsGroupUClone.Equals(goodsGroupU)))
            {
                //��ʏ�񂪕ύX����Ă����ꍇ
                return (false);
            }

            return (true);
        }

        #endregion Private Methods

        #region Control Events

        /// <summary>
        /// Form.Load �C�x���g(PMKHN09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09070UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.Revive_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.REVIVAL];
            this.Delete_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.DELETE];

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMKHN09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09070UA_VisibleChanged(object sender, EventArgs e)
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
        /// Form.Closing �C�x���g(PMKHN09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void PMKHN09070UA_FormClosing(object sender, FormClosingEventArgs e)
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
            if ((this._divisionCode == DIVISION_OFR) && (CompareOriginalScreen() == true))
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
                                    tNedit_GoodsMGroup.Focus();
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

            GoodsGroupU goodsGroupU = ((GoodsGroupU)this._goodsGroupUTable[hashKey]).Clone();

            // �����폜����
            status = this._goodsGroupUAcs.Delete(goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[this._dataIndex].Delete();

                        this._goodsGroupUTable.Remove(hashKey);

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
                            this._goodsGroupUAcs,				  // �G���[�����������I�u�W�F�N�g
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

            GoodsGroupU goodsGroupU = ((GoodsGroupU)this._goodsGroupUTable[hashKey]).Clone();

            // ��������
            status = this._goodsGroupUAcs.Revival(ref goodsGroupU);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        GoodsGroupUToDataSet(goodsGroupU, this._dataIndex);

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
                            this._goodsGroupUAcs,				  // �G���[�����������I�u�W�F�N�g
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

        #endregion Control Events

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// tRetKeyControl1_ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMGroup":
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
                                e.NextCtrl = tNedit_GoodsMGroup;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���i�����ރR�[�h
            int goodsMGroup = tNedit_GoodsMGroup.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsGoodsMGroup = (int)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[i][GOODSMGROUPCODE_TITLE];
                if (goodsMGroup == dsGoodsMGroup)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[GOODSGROUPU_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̏��i�����ރ}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���i�����ރR�[�h�̃N���A
                        tNedit_GoodsMGroup.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̏��i�����ރ}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // ���i�����ރR�[�h�̃N���A
                                tNedit_GoodsMGroup.Clear();
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