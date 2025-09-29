using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�}�X�^(�|���O���[�v)UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���Ӑ�}�X�^(�|���O���[�v)��UI�ݒ���s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/10/03</br>
    /// <br>UpdateNote  : 2009/01/09 30414 �E �K�j ��QID:9806�Ή�</br>
    /// <br>UpdateNote  : 2009/03/10 30413 ����    ��QID:11417�Ή�</br>
    /// <br>            :  �ύX�_�����̂��߁A�ڍד��e�͏ȗ����܂�</br>
    /// <br>UpdateNote  : 2009/11/19 30434 �H��    3�����Ή� ���Ӑ�|���O���[�v����</br>
    /// <br>UpdateNote  : 2009/12/15 30434 �H��    3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^����</br>
    /// <br>UpdateNote  : 2010/07/15 22018 ��� ���b</br>
    /// <br>            :   ���ʕ������Q</br>
    /// <br>            :     �@���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���������ύX�B</br>
    /// <br>            :     �@�@�E����ALL��ݒ肷��ꍇ �� ����ALL�ȊO��CD=-1�͓o�^���Ȃ��B</br>
    /// <br>            :     �@�@�EҰ���ʂɐݒ肷��ꍇ �� ����ALL��CD=-1�͓o�^���Ȃ��B</br>
    /// <br>            :     �@�@�@�i���D�ǂ͗D��ALL�݂̂Ȃ̂ŁA�ύX�Ȃ��j</br>
    /// <br>            :     �A����ALL�Őݒ肳�ꂽ��Ԃłt�h�\�������Ƃ��A�O���b�h�̓��͉ۏ�Ԃ��X�V����Ȃ����̏C���B</br>
    /// </remarks>
    public partial class PMKHN09170UA : Form, IMasterMaintenanceArrayType
    {
        #region �� Constants

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKHN09170U";

        // �e�[�u������
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // �f�[�^�r���[�^�C�g��
        private const string GRIDTITLE_CUSTOMER = "���Ӑ�";
        private const string GRIDTITLE_CUSTRATEGROUP = "���Ӑ�|����ٰ��";

        // �f�[�^�r���[�\���p
        private const string VIEW_CUSTOMERCODE = "���Ӑ�";
        private const string VIEW_CUSTOMERNAME = "���Ӑ於";
        private const string VIEW_DELETEDATE = "�폜��";
        private const string VIEW_MAKERNAME = "���[�J�[";
        private const string VIEW_CUSTRATEGROUP = "���Ӑ�|����ٰ��";

        // �O���b�h��^�C�g��
        private const string COLUMN_MAKERCODE = "MakerCode";
        private const string COLUMN_MAKERNAME = "MakerName";
        private const string COLUMN_CUSTRATEGROUP = "CustRateGroup";
        private const string COLUMN_MAKERTITLE = "MakerTitle";
        private const string COLUMN_CUSTRATEGROUPTITLE = "CustRateGroupTitle";
        private const string COLUMN_CUSTRATEGROUPNAME = "CustRateGroupName";
        private const string COLUMN_CUSTRATEGROUPNAMETITLE = "CustRateGroupNameTitle";
        private const string COLUMN_CUSTRATEGROUPBUTTON = "CustRateGroupButton";
        private const string COLUMN_CUSTRATEGROUPBUTTONTITLE = "CustRateGroupButtonTitle";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �e�O���b�h�s��
        private const int ROWCOUNT = 18;

        #endregion �� Constants


        #region �� Private Members

        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;

        private MGridDisplayLayout _defaultGridDisplayLayout;

        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailDataIndex;

        private string _enterpriseCode;

        private CustRateGroupAcs _custRateGroupAcs;
        private MakerAcs _makerAcs;
        private CustomerSearchAcs _customerSearchAcs;

        // --- ADD 2009/01/09 ��QID:9806�Ή�------------------------------------------------------>>>>>
        private UserGuideAcs _userGuideAcs;
        private Dictionary<int, string> _custRateGrpDic;
        private bool _errFlg;
        private bool _cellUpdateFlg;
        // --- ADD 2009/01/09 ��QID:9806�Ή�------------------------------------------------------<<<<<

        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private ControlScreenSkin _controlScreenSkin;           // ��ʃf�U�C���ύX�N���X
        private List<CustRateGroup> _custRateGroupListClone;    // ���Ӑ�}�X�^(�|���O���[�v)���X�gClone
        private Dictionary<int, CustRateGroup> _mainList;
        private List<CustRateGroup> _detailList;
        private UltraGrid[] _custRateGroup_Grid;                // �O���b�h�p�z��
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        private bool _cusotmerGuideSelected;                    // ���Ӑ�K�C�h�I���t���O

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        #endregion �� Private Members


        #region �� Constructor
        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)UI�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public PMKHN09170UA()
        {
            InitializeComponent();

            this._canClose = true;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            // �e��C���f�b�N�X������
            this._mainDataIndex = -1;
            this._detailDataIndex = -1;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._custRateGroupAcs = new CustRateGroupAcs();
            this._makerAcs = new MakerAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            // --- ADD 2009/01/09 ��QID:9806�Ή�------------------------------------------------------>>>>>
            this._userGuideAcs = new UserGuideAcs();
            // --- ADD 2009/01/09 ��QID:9806�Ή�------------------------------------------------------<<<<<

            this._controlScreenSkin = new ControlScreenSkin();

            // �O���b�h��z��ɃZ�b�g
            //this._custRateGroup_Grid = new UltraGrid[3];
            this._custRateGroup_Grid = new UltraGrid[2];
            this._custRateGroup_Grid[0] = this.uGrid_CustRateGroup1;
            // ������Grid�����Q���P�֕ύX >>>>>>START
            //this._custRateGroup_Grid[1] = this.uGrid_CustRateGroup2;
            //this._custRateGroup_Grid[2] = this.uGrid_CustRateGroup3;
            this._custRateGroup_Grid[1] = this.uGrid_CustRateGroup3;
            // ������Grid�����Q���P�֕ύX <<<<<<END
            
            // DataSet����\�z
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            // ��ʏ����ݒ�
            SetScreenInitialSetting();
        }
        #endregion �� Constructor


        #region �� IMasterMaintenanceArrayType �����o

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return _canDelete; }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get { return _canNew; }
        }

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return _defaultGridDisplayLayout; }
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>����Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get
            {
                return _targetTableName;
            }
            set
            {
                _targetTableName = value;
            }
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // ���C��
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));    // ADD 2008/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(VIEW_CUSTOMERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(VIEW_CUSTOMERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // �ڍ�
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            detail.Add(VIEW_MAKERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            detail.Add(VIEW_CUSTRATEGROUP, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = main;
            appearanceTable[1] = detail;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // �O���b�h�\���p�f�[�^�Z�b�g��ݒ�
            bindDataSet = this.Bind_DataSet;

            // �Q�̃e�[�u�����̂̐ݒ�
            string[] strRet = { TABLE_MAIN, TABLE_DETAIL };
            tableName = strRet;
        }

        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { true, false };   // MOD 2009/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� { false, true }��{ true, false }
            return logicalDeleteButton;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButton = { true, false };
            return deleteButton;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { null, null };
            return gridIcon;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_CUSTOMER, GRIDTITLE_CUSTRATEGROUP };
            return gridTitle;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButton = { true, false };
            return modifyButton;
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButton = { true, false };
            return newButton;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailDataIndex = intVal[1];
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int Delete()
        {
            // �_���폜����
            bool bStatus = LogicalDeleteProc();
            if (!bStatus)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // ADD 2009/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;
            // ADD 2009/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // �I������Ă���f�[�^���擾����
            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_CUSTOMERCODE]);

            // ���������i�_���폜�܂ށj
            int status = this._custRateGroupAcs.Search(out retList, this._enterpriseCode, customerCode, ConstantManagement.LogicalMode.GetData01);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�����N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (CustRateGroup custRateGroup in retList)
                        {
                            // DataSet�W�J����
                            DetailToDataSet(custRateGroup, index);
                            index++;
                        }
                        totalCount = retList.Count;

                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DetailsDataSearch",
                                       "�ǂݍ��݂Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            return 0;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<int, CustRateGroup>();
            this._detailList = new List<CustRateGroup>();

            ArrayList retList;

            int status = this._custRateGroupAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetData01);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �o�b�t�@�ێ�
                        int index = 0;
                        string customerSnm;
                        foreach (CustRateGroup custRateGroup in retList)
                        {
                            this._detailList.Add(custRateGroup);

                            if (!this._mainList.ContainsKey(custRateGroup.CustomerCode))
                            {
                                this._mainList.Add(custRateGroup.CustomerCode, custRateGroup);

                                // ���Ӑ�}�X�^����_���폜����Ă������
                                customerSnm = GetCustomerName(custRateGroup.CustomerCode);
                                if (customerSnm == "")
                                {
                                    continue;
                                }

                                // DataSet�W�J����
                                MainToDataSet(custRateGroup, index, customerSnm);
                                index++;
                            }
                        }
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "�ǂݍ��݂Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            //// �ǂݍ��񂾃C���X�^���X�̂��ꂼ����f�[�^�Z�b�g�ɓW�J
            //int index = 0;
            //string customerSnm;
            //foreach (CustRateGroup cstRateGroup in this._mainList.Values)
            //{
            //    // ���Ӑ�}�X�^����_���폜����Ă������
            //    customerSnm = GetCustomerName(cstRateGroup.CustomerCode);
            //    if (customerSnm == "")
            //    {
            //        continue;
            //    }

            //    // DataSet�W�J����
            //    MainToDataSet(cstRateGroup, index, customerSnm);
            //    index++;
            //}

            totalCount = this._mainList.Count;

            return 0;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return 0;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // ������
            return 0;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        public int Print()
        {
            // ������
            return 0;
        }

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        #endregion �� IMasterMaintenanceArrayType �����o


        #region �� Private Methods
        /// <summary>
        /// ���Ӑ���Ǎ�����
        /// </summary>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
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

        // --- ADD 2009/01/09 ��QID:9806�Ή�------------------------------------------------------>>>>>
        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A���Ӑ�|���O���[�v�R�[�h���o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/09</br>
        /// </remarks>
        private void ReadUserGuide()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            try
            {
                int status;
                ArrayList retList;
                
                status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                 43, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            //this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                            // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                            // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            // MEMO:���Ӑ�|���O���[�v�R�[�h�͢-1:���ݒ�
                            string guideName = GetGuideNameIf(userGdBd);
                            this._custRateGrpDic.Add(userGdBd.GuideCode, guideName.Trim());
                            // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        }
                    }
                }
            }
            catch
            {
                this._custRateGrpDic = new Dictionary<int, string>();
            }
            // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            // MEMO:���Ӑ�|���O���[�v�R�[�h�͢-1:���ݒ�
            if (!this._custRateGrpDic.ContainsKey(NULL_CODE))
            {
                this._custRateGrpDic.Add(NULL_CODE, NULL_NAME);
            }
            // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
        }

        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        /// <summary>���ݒ�R�[�h</summary>
        private const int NULL_CODE = -1;
        /// <summary>���ݒ�R�[�h����</summary>
        private const string NULL_NAME = "���ݒ�";

        /// <summary>
        /// �K�C�h���̂��擾���܂��B
        /// </summary>
        /// <param name="userGuideBody">���[�U�[�K�C�h</param>
        /// <returns>
        /// �K�C�h����<br/>
        /// �K�C�h�R�[�h=-1 �c �K�C�h���̂�<c>string.Empty</c>�̏ꍇ�A"���ݒ�"��Ԃ��܂��B
        /// </returns>
        private static string GetGuideNameIf(UserGdBd userGuideBody)
        {
            if (userGuideBody == null) return string.Empty;

            if (userGuideBody.GuideCode.Equals(NULL_CODE))
            {
                return string.IsNullOrEmpty(userGuideBody.GuideName) ? NULL_NAME : userGuideBody.GuideName;
            }
            return userGuideBody.GuideName;
        }
        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

        /// <summary>
        /// ���Ӑ�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�R�[�h�ɊY�����链�Ӑ�|���O���[�v���̂��擾���܂��B�B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/09</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            string custRateGrpName = "";

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                custRateGrpName = this._custRateGrpDic[custRateGrpCode];
            }

            return custRateGrpName;
        }
        // --- ADD 2009/01/09 ��QID:9806�Ή�------------------------------------------------------<<<<<

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ���[�J�[���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[��</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// ���Ӑ於�擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                return this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return "";
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���_
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();

            // �O���b�h
            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                {
                    this._custRateGroup_Grid[index].AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Value = "0000";
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h��������
                    this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation = Activation.AllowEdit;

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(0);  // �|��G����
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h���̂�������
                    this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    this._custRateGroup_Grid[index].AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }

                this._custRateGroup_Grid[index].ActiveCell = null;
                this._custRateGroup_Grid[index].ActiveRow = null;
            }
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �}�X�^�Ǎ�
            ReadMakerUMnt();
            ReadUserGuide();
            ReadCustomerSearchRet();
            
            // �R���g���[���T�C�Y�ݒ�
            this.tNedit_CustomerCode.Size = new Size(76, 24);
            this.tEdit_CustomerName.Size = new Size(171, 24);

            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.CustomerGuide_Button.ImageList = imageList16;
            this.CustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // MEMO:�O���b�h�\�z
            int makerCode = 0;
            int rowCount;
            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                // ������Grid�����Q���P�֕ύX
                // �|��G���̂ƃK�C�h�{�^����ǉ�
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
                dataTable.Columns.Add(COLUMN_MAKERNAME, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUP, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPNAME, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPBUTTON, typeof(Button));
                dataTable.Columns.Add(COLUMN_MAKERTITLE, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPTITLE, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPNAMETITLE, typeof(string));
                dataTable.Columns.Add(COLUMN_CUSTRATEGROUPBUTTONTITLE, typeof(string));

                //if (index == 2)
                if (index == 1)
                {
                    // �D��
                    rowCount = 1;
                }
                else
                {
                    // ����
                    //rowCount = 13;
                    rowCount = 26;
                }

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    
                    //if (index == 2)
                    if (index == 1)
                    {
                        // �D��
                        dataRow[COLUMN_MAKERCODE] = "0000";
                        dataRow[COLUMN_MAKERNAME] = "�D��ALL";
                    }
                    else
                    {
                        // ����
                        dataRow[COLUMN_MAKERCODE] = makerCode.ToString("0000");

                        if (makerCode == 0)
                        {
                            dataRow[COLUMN_MAKERNAME] = "����ALL";
                        }
                        else
                        {
                            dataRow[COLUMN_MAKERNAME] = GetMakerName(makerCode);
                        }
                    }
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //dataRow[COLUMN_CUSTRATEGROUP] = "0000";
                    //dataRow[COLUMN_CUSTRATEGROUPNAME] = GetCustRateGrpName(0);
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h�͢-1:���ݒ�
                    dataRow[COLUMN_CUSTRATEGROUP] = string.Empty;
                    dataRow[COLUMN_CUSTRATEGROUPNAME] = GetCustRateGrpName(NULL_CODE);
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    dataRow[COLUMN_CUSTRATEGROUPBUTTON] = DBNull.Value;
                    dataRow[COLUMN_MAKERTITLE] = DBNull.Value;
                    dataRow[COLUMN_CUSTRATEGROUPTITLE] = DBNull.Value;
                    dataRow[COLUMN_CUSTRATEGROUPNAMETITLE] = DBNull.Value;
                    dataRow[COLUMN_CUSTRATEGROUPBUTTONTITLE] = DBNull.Value;
                    dataTable.Rows.Add(dataRow);

                    makerCode++;
                }

                this._custRateGroup_Grid[index].DataSource = dataTable;

                this._custRateGroup_Grid[index].Tag = index;

                // �s���C�A�E�g���[�h�L��
                this._custRateGroup_Grid[index].DisplayLayout.Bands[0].UseRowLayout = true;
                
                ColumnsCollection columns = this._custRateGroup_Grid[index].DisplayLayout.Bands[0].Columns;
                
                // ���x���X�^�C���ݒ�
                columns[COLUMN_MAKERCODE].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_MAKERNAME].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_CUSTRATEGROUP].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_CUSTRATEGROUPNAME].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_CUSTRATEGROUPBUTTON].RowLayoutColumnInfo.LabelPosition = LabelPosition.None;
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                // ���x���ʒu�ݒ�
                columns[COLUMN_MAKERCODE].RowLayoutColumnInfo.OriginX = 0;
                columns[COLUMN_MAKERNAME].RowLayoutColumnInfo.OriginX = 1;
                columns[COLUMN_CUSTRATEGROUP].RowLayoutColumnInfo.OriginX = 2;
                columns[COLUMN_CUSTRATEGROUPNAME].RowLayoutColumnInfo.OriginX = 3;
                columns[COLUMN_CUSTRATEGROUPBUTTON].RowLayoutColumnInfo.OriginX = 4;
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.OriginX = 0;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.OriginX = 2;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.OriginX = 3;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.OriginX = 4;
                // ���x���T�C�Y�ݒ�
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.LabelSpan = 2;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.LabelSpan = 1;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.LabelSpan = 1;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.LabelSpan = 1;
                // �Z���T�C�Y�ݒ�
                columns[COLUMN_MAKERCODE].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_MAKERNAME].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUP].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPNAME].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPBUTTON].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_MAKERTITLE].RowLayoutColumnInfo.SpanX = 2;
                columns[COLUMN_CUSTRATEGROUPTITLE].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].RowLayoutColumnInfo.SpanX = 1;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].RowLayoutColumnInfo.SpanX = 1;
                // �w�b�_�[�L���v�V����
                columns[COLUMN_MAKERTITLE].Header.Caption = "���[�J�[";
                columns[COLUMN_CUSTRATEGROUPTITLE].Header.Caption = "���Ӑ�|��G";
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].Header.Caption = "���Ӑ�|��G����";
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].Header.Caption = "";
                // TextHAlign
                columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_CUSTRATEGROUP].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.TextHAlign = HAlign.Left;
                // TextVAlign
                columns[COLUMN_MAKERCODE].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_MAKERNAME].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_CUSTRATEGROUP].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.TextVAlign = VAlign.Middle;
                // ���͐���
                columns[COLUMN_MAKERCODE].CellActivation = Activation.Disabled;
                columns[COLUMN_MAKERNAME].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUP].CellActivation = Activation.AllowEdit;
                columns[COLUMN_CUSTRATEGROUPNAME].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPBUTTON].CellActivation = Activation.NoEdit;
                columns[COLUMN_MAKERTITLE].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPTITLE].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPNAMETITLE].CellActivation = Activation.Disabled;
                columns[COLUMN_CUSTRATEGROUPBUTTONTITLE].CellActivation = Activation.Disabled;
                // ��
                columns[COLUMN_MAKERCODE].Width = 40;
                columns[COLUMN_MAKERNAME].Width = 150;
                columns[COLUMN_CUSTRATEGROUP].Width = 90;
                columns[COLUMN_CUSTRATEGROUPNAME].Width = 150;
                columns[COLUMN_CUSTRATEGROUPBUTTON].Width = 20;
                // �Z��Color
                columns[COLUMN_MAKERCODE].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
                columns[COLUMN_MAKERCODE].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[COLUMN_MAKERCODE].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_MAKERCODE].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_MAKERCODE].CellAppearance.ForeColor = Color.White;
                columns[COLUMN_MAKERCODE].CellAppearance.ForeColorDisabled = Color.White;
                columns[COLUMN_MAKERCODE].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[COLUMN_MAKERNAME].CellAppearance.BackColor = Color.Gainsboro;
                columns[COLUMN_MAKERNAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
                columns[COLUMN_CUSTRATEGROUP].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.BackColor = Color.Gainsboro;
                columns[COLUMN_CUSTRATEGROUPNAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
                // MaxLength
                columns[COLUMN_CUSTRATEGROUP].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_CUSTRATEGROUP);
                columns[COLUMN_MAKERNAME].MaxLength = 20;
                columns[COLUMN_CUSTRATEGROUPNAME].MaxLength = 20;
                // �K�C�h�{�^���̐ݒ�
                columns[COLUMN_CUSTRATEGROUPBUTTON].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                columns[COLUMN_CUSTRATEGROUPBUTTON].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                columns[COLUMN_CUSTRATEGROUPBUTTON].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                columns[COLUMN_CUSTRATEGROUPBUTTON].TabStop = true;
                // �s�̍���
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    this._custRateGroup_Grid[index].Rows[rowIndex].Height = 23;
                }
            }
        }

        /// <summary>
        /// DataSet�W�J����(���C���e�[�u��)
        /// </summary>
        /// <param name="custRateGroup">���Ӑ�}�X�^(�|���O���[�v)</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void MainToDataSet(CustRateGroup custRateGroup, int index, string customerSnm)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // ���Ӑ�R�[�h
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_CUSTOMERCODE] = custRateGroup.CustomerCode.ToString("00000000");
            // ���Ӑ於��
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_CUSTOMERNAME] = customerSnm;

            // ADD 2009/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // �폜��
            if (custRateGroup.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = custRateGroup.UpdateDateTimeJpInFormal;
            }
            // ADD 2009/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<
        }

        /// <summary>
        /// DataSet�W�J����(�ڍ׃e�[�u��)
        /// </summary>
        /// <param name="custRateGroup">���Ӑ�}�X�^(�|���O���[�v)</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void DetailToDataSet(CustRateGroup custRateGroup, int index)
        {
            // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ---------->>>>>
            // FIXME:���ݒ�(���Ӑ�|���O���[�v�R�[�h=-1)�̓t���[���ɕ\�����Ȃ�
            if (custRateGroup.CustRateGrpCode <= NULL_CODE) return;
            // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ----------<<<<<

            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // ���[�J�[
            if (custRateGroup.PureCode == 0)
            {
                // ����
                if (custRateGroup.GoodsMakerCd == 0)
                {
                    this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_MAKERNAME] = "����ALL";
                }
                else
                {
                    this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_MAKERNAME] = GetMakerName(custRateGroup.GoodsMakerCd);
                }
            }
            else
            {
                // �D��
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_MAKERNAME] = "�D��ALL";
            }
            // ���Ӑ�|���O���[�v
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_CUSTRATEGROUP] = custRateGroup.CustRateGrpCode.ToString("0000");
            // �폜��
            if (custRateGroup.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = custRateGroup.UpdateDateTimeJpInFormal;
            }
        }

        /// <summary>
        /// DataSet����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet������\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // ���C��
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_DELETEDATE, typeof(string)); // ADD 2008/03/23 �s��Ή�[7746]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            mainTable.Columns.Add(VIEW_CUSTOMERCODE, typeof(string));
            mainTable.Columns.Add(VIEW_CUSTOMERNAME, typeof(string));

            //==============================
            // �ڍ�
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            detailTable.Columns.Add(VIEW_MAKERNAME, typeof(string));
            detailTable.Columns.Add(VIEW_CUSTRATEGROUP, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ---------->>>>>
        /// <summary>��ʍč\�z���t���O</summary>
        private bool _reconstructing;
        /// <summary>��ʍč\�z���t���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool Reconstructing
        {
            get { return _reconstructing; }
            set { _reconstructing = value; }
        }
        // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ----------<<<<<

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ---------->>>>>
            Reconstructing = true;
            try
            {
            // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ----------<<<<<
                if (this._mainDataIndex < 0)
                {
                    //------------------------------
                    // �V�K���[�h
                    //------------------------------
                    this.Mode_Label.Text = INSERT_MODE;

                    // ��ʓ��͋�����
                    PermitScreenInput(INSERT_MODE);

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    // �N���[���쐬
                    this._custRateGroupListClone = new List<CustRateGroup>();

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_CustomerCode.Focus();
                }
                else
                {
                    // DataSet���瓾�Ӑ�R�[�h���擾
                    int customerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_CUSTOMERCODE]);

                    // ���Ӑ�R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
                    List<CustRateGroup> custRateGroupList = this._detailList.FindAll(delegate(CustRateGroup x)
                    {
                        if (x.CustomerCode == customerCode)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    this._custRateGroupListClone = new List<CustRateGroup>();

                    if (custRateGroupList.Count == 0)
                    {
                        CustRateGroup custRateGroup = new CustRateGroup();
                        custRateGroup.CustomerCode = customerCode;
                        custRateGroupList.Add(custRateGroup);
                    }
                    else
                    {
                        foreach (CustRateGroup custRateGroup in custRateGroupList)
                        {
                            this._custRateGroupListClone.Add(custRateGroup.Clone());
                        }
                    }

                    // ��ʓW�J����
                    CustRateGroupListToScreen(custRateGroupList);

                    if (custRateGroupList[0].LogicalDeleteCode == 0)
                    {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ��ʓ��͋�����
                        PermitScreenInput(UPDATE_MODE);

                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;

                        // �t�H�[�J�X�ݒ�
                        this._custRateGroup_Grid[0].Focus();
                        this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        // �폜���[�h
                        this.Mode_Label.Text = DELETE_MODE;

                        // ��ʓ��͋�����
                        PermitScreenInput(DELETE_MODE);

                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;

                        // �t�H�[�J�X�ݒ�
                        this.Delete_Button.Focus();
                    }
                }
            // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ---------->>>>>
            }
            finally
            {
                Reconstructing = false;
            }
            // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ----------<<<<<
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɂ���ĉ�ʂ̓��͋�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    {
                        // MEMO:�V�K���[�h
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                        {
                            this._custRateGroup_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case UPDATE_MODE:
                    {
                        // MEMO:�X�V���[�h
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                        {
                            this._custRateGroup_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case DELETE_MODE:
                    {
                        // MEMO:�폜���[�h
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                        {
                            this._custRateGroup_Grid[index].Enabled = false;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)���X�g��ʓW�J����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void CustRateGroupListToScreen(List<CustRateGroup> custRateGroupList)
        {
            bool pureFlg = false;

            foreach (CustRateGroup custRateGroup in custRateGroupList)
            {
                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.SetInt(custRateGroup.CustomerCode);
                // ���Ӑ於
                this.tEdit_CustomerName.DataText = GetCustomerName(custRateGroup.CustomerCode);

                if (custRateGroup.PureCode == 0)
                {
                    // ����
                    if ( custRateGroup.GoodsMakerCd == 0 )
                    {
                        pureFlg = true;
                    }
                    // --- ADD m.suzuki 2010/07/15 ---------->>>>>
                    else
                    {
                        // �s���f�[�^(����ALL=-1,����Ұ���ʐݒ肠��)���Ăяo�����ۂ�
                        // ����\���o����悤�C���B
                        pureFlg = false;
                    }
                    // --- ADD m.suzuki 2010/07/15 ----------<<<<<

                    //if (custRateGroup.GoodsMakerCd <= 12)
                    if (custRateGroup.GoodsMakerCd <= 25)
                    {
                        this.uGrid_CustRateGroup1.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        //this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                        //this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);   // �|��G����
                        // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        // MEMO:���Ӑ�|���O���[�v�R�[�h�͢-1:���ݒ�
                        if (custRateGroup.CustRateGrpCode >= 0)
                        {
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);   // �|��G����
                        }
                        else
                        {
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                            this.uGrid_CustRateGroup1.Rows[custRateGroup.GoodsMakerCd].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                        }
                        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                        this.uGrid_CustRateGroup1.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                        this._cellUpdateFlg = false;
                    }
                    #region �폜�R�[�h
                    //else
                    //{
                    //    this.uGrid_CustRateGroup2.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    //    this._cellUpdateFlg = true;
                    //    this.uGrid_CustRateGroup2.Rows[custRateGroup.GoodsMakerCd - 13].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                    //    this.uGrid_CustRateGroup2.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    //    this._cellUpdateFlg = false;
                    //}
                    #endregion
                }
                else
                {
                    // �D��
                    this.uGrid_CustRateGroup3.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                    //this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);    // �|��G����
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h�͢-1:���ݒ�
                    if (custRateGroup.CustRateGrpCode >= 0)
                    {
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value = custRateGroup.CustRateGrpCode.ToString("0000");
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup.CustRateGrpCode);    // �|��G����
                    }
                    else
                    {
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                        this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                    }
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    this.uGrid_CustRateGroup3.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }
            }

            // --- DEL m.suzuki 2010/07/15 ---------->>>>>
            //// FIXME:��ʍč\�z���̕\���͂����ŏI��
            //if (Reconstructing) return;
            // --- DEL m.suzuki 2010/07/15 ----------<<<<<

            if (pureFlg == true)
            {
                ChangeGridEnabled(false);
            }
        }

        /// <summary>
        /// �ۑ��f�[�^�擾����
        /// </summary>
        /// <returns>�ۑ��f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ��f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private Dictionary<string, CustRateGroup> GetSaveCustRateGroupDicFromScreen()
        {
            // --- ADD m.suzuki 2010/07/15 ---------->>>>>
            // ���������S�Ė����͏�ԂłȂ����A���O�Ɋm�F����B
            bool pureSettingByMakerExists = false;

            # region [pureSettingByMakerExists]
            // rowIndex = 0 �͏���ALL�Ȃ̂ŏ��O�B
            for ( int rowIndex = 1; rowIndex < this._custRateGroup_Grid[0].Rows.Count; rowIndex++ )
            {
                CellsCollection cells = this._custRateGroup_Grid[0].Rows[rowIndex].Cells;

                if ( (cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == "") )
                {
                }
                else
                {
                    // ���[�J�[�ʐݒ肪���͂���Ă���B
                    pureSettingByMakerExists = true;
                    break;
                }
            }
            # endregion
            // --- ADD m.suzuki 2010/07/15 ----------<<<<<

            Dictionary<string, CustRateGroup> custRateGroupDic = new Dictionary<string, CustRateGroup>();

            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h���󔒂̏ꍇ
                    //if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) || 
                    //    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == "") ||
                    //    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == "0000"))
                    //{
                    //    continue;
                    //}
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                        (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == ""))
                    {
                        // DEL 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ---------->>>>>
                        //continue;
                        // DEL 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ----------<<<<<
                        // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ---------->>>>>
                        // FIXME:���ݒ�(���Ӑ�|���O���[�v�R�[�h=-1)��DB�o�^����
                        if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value))
                        {
                            cells[COLUMN_CUSTRATEGROUP].Value = string.Empty;
                        }
                        // ADD 2009/12/15 3�����Ή� ���Ӑ�|���O���[�v����(�ǉ�):���Ӑ�|���O���[�v�R�[�h=-1��DB�o�^���� ----------<<<<<
                    }
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    CustRateGroup custRateGroup = new CustRateGroup();

                    // ��ƃR�[�h
                    custRateGroup.EnterpriseCode = this._enterpriseCode;
                    // ���Ӑ�R�[�h
                    custRateGroup.CustomerCode = this.tNedit_CustomerCode.GetInt();
                    // �����敪
                    //if (index == 2)
                    if (index == 1)
                    {
                        // �D��
                        custRateGroup.PureCode = 1;
                    }
                    else
                    {
                        // ����
                        custRateGroup.PureCode = 0;
                    }
                    // ���[�J�[�R�[�h
                    custRateGroup.GoodsMakerCd = int.Parse((string)cells[COLUMN_MAKERCODE].Value);

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //custRateGroup.CustRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // FIXME:�o�^���链�Ӑ�|���O���[�v�R�[�h��ݒ�@�����ݒ�(���Ӑ�|���O���[�v�R�[�h=-1)��DB�o�^����
                    Debug.WriteLine(((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim());
                    if (!string.IsNullOrEmpty(((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim()))
                    {
                        custRateGroup.CustRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                    }
                    else
                    {
                        // --- UPD m.suzuki 2010/07/15 ---------->>>>>
                        //custRateGroup.CustRateGrpCode = NULL_CODE;
                        if ( custRateGroup.PureCode == 0 )
                        {
                            // ����
                            if ( pureSettingByMakerExists )
                            {
                                // ���[�J�[�ʐݒ�̏ꍇ
                                if ( rowIndex == 0 )
                                {
                                    // ����ALL����GR�R�[�h=-1�̃��R�[�h���쐬���Ȃ��B
                                    continue;
                                }
                            }
                            else
                            {
                                // ����ALL�̂�
                                if ( rowIndex != 0 )
                                {
                                    // ���[�J�[�ʐݒ肩��GR�R�[�h=-1�̃��R�[�h���쐬���Ȃ��B
                                    continue;
                                }
                            }
                            custRateGroup.CustRateGrpCode = NULL_CODE;
                        }
                        else
                        {
                            // �D�ǁ˗D��ALL�݂̂Ȃ̂ŁA-1�̃��R�[�h���쐬����B
                            custRateGroup.CustRateGrpCode = NULL_CODE;
                        }
                        // --- UPD m.suzuki 2010/07/15 ----------<<<<<
                    }
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    custRateGroupDic.Add(GetKey(custRateGroup), custRateGroup);
                }
            }

            return custRateGroupDic;
        }

        /// <summary>
        /// �X�V�p���X�g�擾����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="deleteList">�폜���X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ����X�g�E�폜���X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // �ۑ��p�f�[�^�擾
            Dictionary<string, CustRateGroup> saveCustRateGroupDic = GetSaveCustRateGroupDicFromScreen();

            // �폜���X�g�쐬
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                deleteList.Add(custRateGroup.Clone());
            }

            // �ۑ����X�g�쐬
            foreach (CustRateGroup custRateGroup in saveCustRateGroupDic.Values)
            {
                saveList.Add(custRateGroup);
            }
        }

        /// <summary>
        /// Key�擾����
        /// </summary>
        /// <param name="custRateGroup">���Ӑ�}�X�^(�|���O���[�v)�}�X�^</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)����Key���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private string GetKey(CustRateGroup custRateGroup)
        {
            string key = "";

            // ���Ӑ�R�[�h(8��)�{���[�J�[�R�[�h(4��)�{�����敪(2��)
            key = custRateGroup.CustomerCode.ToString("00000000") + custRateGroup.GoodsMakerCd.ToString("0000") +
                  custRateGroup.PureCode.ToString("00");

            return key;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool SaveProc()
        {
            // ���̓`�F�b�N
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (false);
            }

            bool allNullFlg = false;
            for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //if ((cells[COLUMN_CUSTRATEGROUP].Value != DBNull.Value) &&
                    //    (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() != ""))
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:�S�Ė��ݒ�ł��邩����
                    if (cells[COLUMN_CUSTRATEGROUP].Value != DBNull.Value)
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    {
                        // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        //if (int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value) == 0)
                        // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        if (string.IsNullOrEmpty((string)cells[COLUMN_CUSTRATEGROUP].Value))
                        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        {
                            allNullFlg = true;
                        }
                        else
                        {
                            allNullFlg = false;
                            break;
                        }
                    }
                }

                if (!allNullFlg)
                {
                    break;
                }
            }

            ArrayList saveList;
            ArrayList deleteList;

            // �X�V�p�f�[�^�擾
            GetUpdateList(out saveList, out deleteList);

            int status;

            if (deleteList.Count > 0)
            {
                // �폜����
                status = this._custRateGroupAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "SaveProc",
                                       "�o�^�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }
            }

            // TODO:�ۑ�����
            if (!allNullFlg)
            {
                status = this._custRateGroupAcs.Write(ref saveList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            int totalCount = 0;

                            // �Č���
                            Search(ref totalCount, 0);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "���̋��_�R�[�h�͊��Ɏg�p����Ă��܂��B",
                                           status,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tNedit_CustomerCode.Focus();

                            return (false);
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // �r������
                            ExclusiveTransaction(status);
                            break;
                        }
                    default:
                        {
                            // �o�^���s
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                           "SaveProc",
                                           "�o�^�Ɏ��s���܂����B",
                                           status,
                                           MessageBoxButtons.OK);
                            break;
                        }
                }
            }
            else
            {
                int totalCount = 0;

                // �Č���
                Search(ref totalCount, 0);
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

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
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �����폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool DeleteProc()
        {
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);


            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return (false);
            }

            // �폜���X�g�擾
            ArrayList deleteList = new ArrayList();
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                deleteList.Add(custRateGroup.Clone());
            }

            // �폜����
            int status = this._custRateGroupAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "DeleteProc",
                                       "�폜�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSet���狒�_�R�[�h���擾
            int customerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_CUSTOMERCODE]);

            // ���_�R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
            List<CustRateGroup> custRateGroupList = this._detailList.FindAll(delegate(CustRateGroup x)
            {
                if (x.CustomerCode == customerCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (custRateGroupList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�폜�Ώۃf�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }

            if (custRateGroupList[0].LogicalDeleteCode != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂��B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (CustRateGroup custRateGroup in custRateGroupList)
            {
                logicalList.Add(custRateGroup.Clone());
            }

            // �_���폜����
            int status = this._custRateGroupAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //int index = 0;
                        //string key;

                        //foreach (CustRateGroup custRateGroup in logicalList)
                        //{
                        //    key = GetKey(custRateGroup);
                        //    int listIndex = this._detailList.FindIndex(delegate(CustRateGroup x)
                        //    {
                        //        string key2 = GetKey(x);

                        //        if (key == key2)
                        //        {
                        //            return (true);
                        //        }
                        //        else
                        //        {
                        //            return (false);
                        //        }
                        //    });

                        //    if (listIndex >= 0)
                        //    {
                        //        // �o�b�t�@�X�V
                        //        this._detailList[listIndex] = custRateGroup.Clone();
                        //    }

                        //    // DataSet�W�J
                        //    DetailToDataSet(custRateGroup, index);
                        //    index++;
                        //}

                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "LogicalDeleteProc",
                                       "�_���폜�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            return (true);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // �������X�g�擾
            ArrayList reviveList = new ArrayList();
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                reviveList.Add(custRateGroup.Clone());
            }

            // ��������
            int status = this._custRateGroupAcs.Revival(ref reviveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r��
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "RevivalProc",
                                       "�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// ���͏��`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���͏��̃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // ���Ӑ�R�[�h
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "���Ӑ�R�[�h����͂��Ă��������B";
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }
                int customerCode = this.tNedit_CustomerCode.GetInt();
                if (GetCustomerName(customerCode) == "")
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    foreach (CustRateGroup custRateGroup in this._detailList)
                    {
                        if (custRateGroup.CustomerCode == customerCode)
                        {
                            errMsg = "���̓��Ӑ�R�[�h�͊��Ɏg�p����Ă��܂��B";
                            this.tNedit_CustomerCode.Focus();
                            return (false);
                        }
                    }
                }

                // ���Ӑ�|���O���[�v�R�[�h
                bool inputFlg = false;

                for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                {
                    this._custRateGroup_Grid[index].AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;
                    this._custRateGroup_Grid[index].ActiveCell = null;
                    this._custRateGroup_Grid[index].AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;

                    for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                    {
                        CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                        // ���Ӑ�|���O���[�v�R�[�h���󔒂̏ꍇ
                        if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                            (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == ""))
                        {
                            continue;
                        }
                        
                        inputFlg = true;
                        break;
                    }
                }

                // ���Ӑ�|���O���[�v�R�[�h��1�������͂���Ă��Ȃ������ꍇ
                if (inputFlg == false)
                {
                    errMsg = "���Ӑ�|����ٰ�߂̓o�^������܂���B";
                    this._custRateGroup_Grid[0].Focus();
                    this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                    this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                for (int index = 0; index < this._custRateGroup_Grid.Length; index++)
                {
                    for (int rowIndex = 0; rowIndex < this._custRateGroup_Grid[index].Rows.Count; rowIndex++)
                    {
                        CellsCollection cells = this._custRateGroup_Grid[index].Rows[rowIndex].Cells;

                        // ���Ӑ�|���O���[�v�R�[�h���󔒂̏ꍇ
                        if ((cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                            (((string)cells[COLUMN_CUSTRATEGROUP].Value).Trim() == ""))
                        {
                            continue;
                        }

                        // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        // int custRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                        // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        int custRateGrpCode = NULL_CODE;
                        if (!string.IsNullOrEmpty((string)cells[COLUMN_CUSTRATEGROUP].Value))
                        {
                            custRateGrpCode = int.Parse((string)cells[COLUMN_CUSTRATEGROUP].Value);
                        }
                        // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                        if (GetCustRateGrpName(custRateGrpCode) == "")
                        {
                            errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                            this._custRateGroup_Grid[index].AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                            this._cellUpdateFlg = true;
                            this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Value = DBNull.Value;
                            this._custRateGroup_Grid[index].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                            this._custRateGroup_Grid[index].PerformAction(UltraGridAction.EnterEditMode);
                            this._custRateGroup_Grid[index].AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                            this._cellUpdateFlg = false;
                            return (false);
                        }
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓǍ����Ɖ�ʏI�����̃f�[�^���r���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // �V�K�Ǎ����ɓ��Ӑ�R�[�h�����͂���Ă����ꍇ
            if ((this._custRateGroupListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            // �ۑ��f�[�^�擾
            Dictionary<string, CustRateGroup> saveCustRateGroupDic = GetSaveCustRateGroupDicFromScreen();

            // ��ʓǍ����ƕۑ��f�[�^�̌������Ⴄ�ꍇ
            if (this._custRateGroupListClone.Count != saveCustRateGroupDic.Values.Count)
            {
                return (false);
            }

            string key;
            foreach (CustRateGroup custRateGroup in this._custRateGroupListClone)
            {
                // Key�擾
                key = GetKey(custRateGroup);

                // ��ʓǍ����̃f�[�^�������ꍇ
                if (!saveCustRateGroupDic.ContainsKey(key))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "���ɑ��[�����X�V����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "���ɑ��[�����폜����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                       // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._custRateGroupAcs,			// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        /// <summary>
        /// NextFocus �ݒ菈��
        /// </summary>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����Enter�L�[���������ꂽ����NextFocus�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void SetNextFocus(UltraGrid uGrid, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    e.NextCtrl = null;
                    uGrid.Focus();
                    uGrid.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 2;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            int gridIndex = (int)uGrid.Tag;
            switch (gridIndex)
            {
                case 0:
                    {
                        if ((uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP) && (uGrid.ActiveCell.Text.Trim() == ""))
                        {
                            // �|��G�R�[�h���󔒂̏ꍇ�A�K�C�h�{�^���֑J��
                            uGrid.Focus();
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                //if ((uGrid.ActiveCell.Text.Trim() == "") || (int.Parse(uGrid.ActiveCell.Text.Trim()) == 0))
                                // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                                // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                // MEMO:�擪�s(����ALL)�����ݒ莞�̃t�H�[�J�X�J��
                                if ((uGrid.ActiveCell.Text.Trim() == ""))
                                // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                                {
                                    uGrid.Focus();
                                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    //this._custRateGroup_Grid[2].Focus();
                                    //this._custRateGroup_Grid[2].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    //this._custRateGroup_Grid[2].PerformAction(UltraGridAction.EnterEditMode);
                                    this._custRateGroup_Grid[1].Focus();
                                    this._custRateGroup_Grid[1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (rowIndex == 25)
                            {
                                this._custRateGroup_Grid[gridIndex + 1].Focus();
                                this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                //case 1:
                //    {
                //        if (rowIndex == 12)
                //        {
                //            this._custRateGroup_Grid[gridIndex + 1].Focus();
                //            this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        else
                //        {
                //            uGrid.Focus();
                //            uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        break;
                //    }
                //case 2:
                case 1:
                    {
                        if ((uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP) && (uGrid.ActiveCell.Text.Trim() == ""))
                        {
                            // �|��G�R�[�h���󔒂̏ꍇ�A�K�C�h�{�^���֑J��
                            uGrid.Focus();
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                        }
                        else
                        {
                            // �D��
                            this.Renewal_Button.Focus();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// BeforeFocus �ݒ菈��
        /// </summary>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����Shift + Tab�L�[���������ꂽ����NextFocus�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void SetBeforeFocus(UltraGrid uGrid, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            int gridIndex = (int)uGrid.Tag;
            switch (gridIndex)
            {
                case 0:
                    {
                        if (rowIndex == 0)
                        {
                            if ((this.CustomerGuide_Button.Enabled) && (this.tNedit_CustomerCode.Enabled))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() == "")
                                {
                                    this.CustomerGuide_Button.Focus();
                                }
                                else
                                {
                                    this.tNedit_CustomerCode.Focus();
                                }
                            }
                            else
                            {
                                // ���Ӑ�R�[�h�ƃK�C�h�{�^���������̏ꍇ�́A����{�^���֑J��
                                this.Cancel_Button.Focus();
                            }
                        }
                        else
                        {
                            if ((uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP) &&
                                (uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Text.Trim() == ""))
                            {
                                // �|��G�R�[�h����
                                uGrid.Focus();
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                            }
                            else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                //case 1:
                //    {
                //        if (rowIndex == 0)
                //        {
                //            this._custRateGroup_Grid[gridIndex - 1].Focus();
                //            this._custRateGroup_Grid[gridIndex - 1].Rows[12].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            this._custRateGroup_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        else
                //        {
                //            uGrid.Focus();
                //            uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        break;
                //    }
                //case 2:
                case 1:
                    {
                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            if ((this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value == DBNull.Value) ||
                                ((string)this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value == "") ||
                                (int.Parse((string)this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Value) == 0))
                            {
                                //this._custRateGroup_Grid[gridIndex - 1].Focus();
                                //this._custRateGroup_Grid[gridIndex - 1].Rows[12].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                //this._custRateGroup_Grid[gridIndex - 1].Rows[25].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                //this._custRateGroup_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                this._custRateGroup_Grid[0].Focus();
                                if (this._custRateGroup_Grid[0].Rows[25].Cells[COLUMN_CUSTRATEGROUP].Text != "")
                                {
                                    this._custRateGroup_Grid[0].Rows[25].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    // �ŏI�s�̊|��G����
                                    this._custRateGroup_Grid[0].Rows[25].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                            }
                            else
                            {
                                this._custRateGroup_Grid[0].Focus();
                                this._custRateGroup_Grid[0].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            uGrid.Focus();
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �O���b�hEnabled���䏈��
        /// </summary>
        /// <param name="enabledFlg">���̓t���O</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̓��͐�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void ChangeGridEnabled(bool enabledFlg)
        {
            if (enabledFlg == true)
            {
                // ���[�J�[�R�[�h0001�`0025�ɒl����͉�
                for (int rowIndex = 1; rowIndex < this.uGrid_CustRateGroup1.Rows.Count; rowIndex++)
                {
                    UltraGridCell cell = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];
                    UltraGridCell cell2 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME];
                    UltraGridCell cell3 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON];

                    this.uGrid_CustRateGroup1.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;

                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //cell.Value = "0000";
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h�������N���A
                    cell.Value = string.Empty;
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    cell.Activation = Activation.AllowEdit;
                    
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //cell2.Value = GetCustRateGrpName(0);    // �|��G����
                    // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // MEMO:���Ӑ�|���O���[�v�R�[�h���̂������N���A
                    cell2.Value = GetCustRateGrpName(NULL_CODE);
                    // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    cell3.Activation = Activation.NoEdit;   // �K�C�h�{�^��
                    this.uGrid_CustRateGroup1.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }
                #region �폜�R�[�h
                //for (int rowIndex = 0; rowIndex < this.uGrid_CustRateGroup2.Rows.Count; rowIndex++)
                //{
                //    UltraGridCell cell = this.uGrid_CustRateGroup2.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];

                //    this.uGrid_CustRateGroup2.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = true;
                //    cell.Value = "0000";
                //    cell.Activation = Activation.AllowEdit;
                //    this.uGrid_CustRateGroup2.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = false;
                //}
                #endregion
            }
            else
            {
                // ���[�J�[�R�[�h0001�`0025�ɒl����͕s��
                for (int rowIndex = 1; rowIndex < this.uGrid_CustRateGroup1.Rows.Count; rowIndex++)
                {
                    UltraGridCell cell = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];
                    UltraGridCell cell2 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPNAME];
                    UltraGridCell cell3 = this.uGrid_CustRateGroup1.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON];

                    this.uGrid_CustRateGroup1.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = true;
                    cell.Value = "";
                    cell.Activation = Activation.Disabled;
                    cell2.Value = "";   // �|��G����
                    cell3.Activation = Activation.Disabled;     // �K�C�h�{�^��
                    this.uGrid_CustRateGroup1.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                    this._cellUpdateFlg = false;
                }
                #region �폜�R�[�h
                //for (int rowIndex = 0; rowIndex < this.uGrid_CustRateGroup2.Rows.Count; rowIndex++)
                //{
                //    UltraGridCell cell = this.uGrid_CustRateGroup2.Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP];

                //    this.uGrid_CustRateGroup2.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = true;
                //    cell.Value = "";
                //    cell.Activation = Activation.Disabled;
                //    this.uGrid_CustRateGroup2.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                //    this._cellUpdateFlg = false;
                //}
                #endregion
            }
        }

        #endregion �� Private Methods


        #region �� Control Events
        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[����Load���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PMKHN09170UA_Load(object sender, EventArgs e)
        {
            #region �폜�R�[�h
            //// ��ʏ����ݒ�
            //SetScreenInitialSetting();

            //// ��ʃN���A
            //ScreenClear();
            #endregion
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PMKHN09170UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// VisibleChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void PMKHN09170UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // ��ʃN���A
            ScreenClear();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click �C�x���g(���Ӑ�K�C�h�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    this.uGrid_CustRateGroup1.Focus();
                    this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                }

                // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                if (this._mainDataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Focus();
                    }
                }
                // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/03</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

            // ���Ӑ於��
            this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click �C�x���g(�ۑ��{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �ۑ�����
            SaveProc();
        }

        /// <summary>
        /// Button_Click �C�x���g(����{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
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
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                      "",
                                                      0,
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxDefaultButton.Button1);

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
                                // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tNedit_CustomerCode.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
        /// Button_Click �C�x���g(�폜�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �폜�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �����폜����
            bool bStatus = DeleteProc();
            if (!bStatus)
            {
                return;
            }

            int totalCount = 0;

            // �Č�������
            Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

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
        /// Button_Click �C�x���g(�����{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // ��������
            bool bStatus = RevivalProc();
            if (!bStatus)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

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
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
            }

            // �K�C�h�{�^���̒ǉ��ɂ�菈����ύX
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        #region �폜�R�[�h
                        //uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //e.Handled = true;

                        //if (!this._errFlg)
                        //{
                        //    if (rowIndex == 0)
                        //    {
                        //        this.tNedit_CustomerCode.Focus();
                        //    }
                        //    else
                        //    {
                        //        uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    }
                        //}
                        //else
                        //{
                        //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    this._errFlg = false;
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            // �|��G�R�[�h
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            e.Handled = true;

                            if (!this._errFlg)
                            {
                                if (rowIndex == 0)
                                {
                                    // ���Ӑ�R�[�h���L���̏ꍇ�͑J�ڂ���
                                    if (this.tNedit_CustomerCode.Enabled)
                                    {
                                        this.tNedit_CustomerCode.Focus();
                                    }
                                    else
                                    {
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    // ��s�֑J��
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // �K�C�h�{�^��
                            if (!this._errFlg)
                            {
                                if (rowIndex == 0)
                                {
                                    // ���Ӑ�R�[�h���L���̏ꍇ�͑J�ڂ���
                                    if (this.tNedit_CustomerCode.Enabled)
                                    {
                                        this.tNedit_CustomerCode.Focus();
                                    }
                                    else
                                    {
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    // ��s�֑J��
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        #region �폜�R�[�h

                        //uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //e.Handled = true;

                        //if (!this._errFlg)
                        //{
                        //    if (rowIndex == uGrid.Rows.Count - 1)
                        //    {
                        //        this.Ok_Button.Focus();
                        //    }
                        //    else
                        //    {
                        //        if (uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                        //        {
                        //            uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        }
                        //        else
                        //        {
                        //            this.Ok_Button.Focus();
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    this._errFlg = false;
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            // �|��G�R�[�h
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            e.Handled = true;

                            if (!this._errFlg)
                            {
                                if (rowIndex == uGrid.Rows.Count - 1)
                                {
                                    // �ŐV���{�^���֑J��
                                    this.Renewal_Button.Focus();
                                }
                                else
                                {
                                    if (uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                    {
                                        // ���s�֑J��
                                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        // �ŐV���{�^���֑J��
                                        this.Renewal_Button.Focus();
                                    }
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // �K�C�h�{�^��
                            if (!this._errFlg)
                            {
                                if (rowIndex == uGrid.Rows.Count - 1)
                                {
                                    // �ŐV���{�^���֑J��
                                    this.Renewal_Button.Focus();
                                }
                                else
                                {
                                    if (uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                    {
                                        // ���s�֑J��
                                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                    }
                                    else
                                    {
                                        // �ŐV���{�^���֑J��
                                        this.Renewal_Button.Focus();
                                    }
                                }
                            }
                            else
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        #region �폜�R�[�h
                        //if (uGrid.ActiveCell.SelStart == 0)
                        //{
                        //    int gridIndex = (int)uGrid.Tag;

                        //    uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //    e.Handled = true;

                        //    if (!this._errFlg)
                        //    {
                        //        if (gridIndex != 0)
                        //        {
                        //            if (this._custRateGroup_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                        //            {
                        //                this._custRateGroup_Grid[gridIndex - 1].Focus();
                        //                this._custRateGroup_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                this._custRateGroup_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                        //            }
                        //            else
                        //            {
                        //                this._custRateGroup_Grid[0].Focus();
                        //                this._custRateGroup_Grid[0].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        this._errFlg = false;
                        //    }
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            // �|��G�R�[�h
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                int gridIndex = (int)uGrid.Tag;

                                uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                e.Handled = true;

                                if (!this._errFlg)
                                {
                                    if (gridIndex != 0)
                                    {
                                        // �����̃K�C�h�{�^���֑J��
                                        this._custRateGroup_Grid[gridIndex - 1].Focus();
                                        this._custRateGroup_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                    }
                                    else
                                    {
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // �K�C�h�{�^��
                            int gridIndex = (int)uGrid.Tag;

                            if (!this._errFlg)
                            {
                                if (gridIndex != 0)
                                {
                                    if (this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                    {
                                        // �|��G�R�[�h�֑J��
                                        this._custRateGroup_Grid[gridIndex].Focus();
                                        this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                        this._custRateGroup_Grid[gridIndex].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        // �|��G�R�[�h�֑J��
                                        this._custRateGroup_Grid[0].Focus();
                                        this._custRateGroup_Grid[0].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                        this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    this._custRateGroup_Grid[0].Focus();
                                    this._custRateGroup_Grid[0].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                uGrid.ActiveCell.Activate();
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        #region �폜�R�[�h
                        //if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                        //{
                        //    int gridIndex = (int)uGrid.Tag;

                        //    uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //    e.Handled = true;

                        //    if (!this._errFlg)
                        //    {
                        //        switch (gridIndex)
                        //        {
                        //            case 0:
                        //                {
                        //                    if (this._custRateGroup_Grid[gridIndex + 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                        //                    {
                        //                        this._custRateGroup_Grid[gridIndex + 1].Focus();
                        //                        this._custRateGroup_Grid[gridIndex + 1].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                        this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                        //                    }
                        //                    else
                        //                    {
                        //                        this._custRateGroup_Grid[2].Focus();
                        //                        this._custRateGroup_Grid[2].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                        this._custRateGroup_Grid[2].PerformAction(UltraGridAction.EnterEditMode);
                        //                    }
                        //                    break;
                        //                }
                        //            case 1:
                        //                {
                        //                    this._custRateGroup_Grid[gridIndex + 1].Focus();
                        //                    this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                        //                    this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                        //                    break;
                        //                }
                        //            default:
                        //                {
                        //                    break;
                        //                }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        this._errFlg = false;
                        //    }
                        //}
                        #endregion

                        if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUP)
                        {
                            //�@�|��G�R�[�h
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                int gridIndex = (int)uGrid.Tag;

                                uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                e.Handled = true;

                                if (!this._errFlg)
                                {
                                    // �K�C�h�{�^���֑J��
                                    this._custRateGroup_Grid[gridIndex].Focus();
                                    this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else if (uGrid.ActiveCell.Column.Key == COLUMN_CUSTRATEGROUPBUTTON)
                        {
                            // �K�C�h�{�^��
                            int gridIndex = (int)uGrid.Tag;

                            if (!this._errFlg)
                            {
                                switch (gridIndex)
                                {
                                    case 0:
                                        {
                                            if (this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activation == Activation.AllowEdit)
                                            {
                                                // �|��G�R�[�h�֑J��
                                                this._custRateGroup_Grid[gridIndex + 1].Focus();
                                                this._custRateGroup_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                                this._custRateGroup_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            // �K�C�h�{�^���֑J��
                                            this._custRateGroup_Grid[gridIndex].Focus();
                                            this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                this._custRateGroup_Grid[gridIndex].Focus();
                                this._custRateGroup_Grid[gridIndex].Rows[rowIndex].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                this._errFlg = false;
                            }
                        }
                        break;
                    }
                // �K�C�h�{�^���̉���
                case Keys.Space:
                    {
                        if (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            UltraGridCell ultraGridCell = uGrid.ActiveCell;
                            CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                            uGrid_CustRateGroup1_ClickCellButton(sender, cellEventArgs);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.IsInEditMode)
            {
                // UI�ݒ���Q��
                if (this.uiSetControl1.CheckMatchingSet(uGrid.ActiveCell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// BeforeEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                // MEMO:���Ӑ�|���O���[�v�R�[�h�̃O���b�h�Z����""�ɕҏW���ꂽ�ꍇ
                return;
            }

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            // �[���l�߉���
            uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = true;
            uGrid.ActiveCell.Value = custRateGroup.ToString();
            uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = false;
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                // MEMO:���Ӑ�|���O���[�v�R�[�h�̃O���b�h�Z����""�ɕҏW���ꂽ�ꍇ
                return;
            }

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            // �[���l��
            uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = true;
            uGrid.ActiveCell.Value = custRateGroup.ToString("0000");
            uGrid.ActiveCell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(custRateGroup);     // �|��G����
            uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = false;
        }

        /// <summary>
        /// AfterCellUpdate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̒l���X�V���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this._cellUpdateFlg)
            {
                return;
            }

            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //uGrid.ActiveCell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = "";
                // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // MEMO:���Ӑ�|���O���[�v�R�[�h�̃O���b�h�Z����""�ɕҏW���ꂽ�ꍇ
                uGrid.ActiveCell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = GetCustRateGrpName(NULL_CODE);
                // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                return;
            }

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            if (GetCustRateGrpName(custRateGroup) == "")
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�}�X�^�ɓo�^����Ă��܂���B",
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                this._errFlg = true;

                uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = true;
                uGrid.ActiveCell.Value = DBNull.Value;
                uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = false;
                return;
            }

            // �[���l��
            uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = true;
            uGrid.ActiveCell.Value = custRateGroup.ToString("0000");
            uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
            this._cellUpdateFlg = false;
        }

        /// <summary>
        /// CellChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup1_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.Row.Index != 0)
            {
                return;
            }

            // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            //if ((uGrid.ActiveCell.Text.Trim() == "") || (int.Parse(uGrid.ActiveCell.Text.Trim()) == 0))
            // DEL 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            // MEMO:�擪�s�i����ALL�j�̏ꍇ�A�S�s�ɓW�J
            if (string.IsNullOrEmpty(uGrid.ActiveCell.Text))
            // ADD 2009/11/19 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            {
                ChangeGridEnabled(true);
            }
            else
            {
                ChangeGridEnabled(false);
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void uGrid_CustRateGroup_Leave(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            uGrid.ActiveCell = null;
            uGrid.ActiveRow = null;
        }

        /// <summary>
        /// Timer_Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �A�N�e�B�u�R���g���[�����ς�������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();

                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup1.Focus();
                                this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                            }

                            return;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        // ���Ӑ於�擾
                        this.tEdit_CustomerName.DataText = GetCustomerName(customerCode);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup1.Focus();
                                    this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup1.Focus();
                                this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }

                        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        if ((e.NextCtrl != null) && (e.NextCtrl.Name == "Cancel_Button"))
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._mainDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tNedit_CustomerCode;
                            }
                        }
                        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

                        break;
                    }
                case "CustomerGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup1.Focus();
                                this.uGrid_CustRateGroup1.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.Renewal_Button;
                            }
                        }
                        break;
                    }
                case "uGrid_CustRateGroup1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetNextFocus(this.uGrid_CustRateGroup1, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetBeforeFocus(this.uGrid_CustRateGroup1, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup1.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        break;
                    }
                //case "uGrid_CustRateGroup2":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                //            {
                //                this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.ExitEditMode);

                //                if (!this._errFlg)
                //                {
                //                    SetNextFocus(this.uGrid_CustRateGroup2, ref e);
                //                }
                //                else
                //                {
                //                    e.NextCtrl = null;
                //                    this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.EnterEditMode);
                //                    this._errFlg = false;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (e.Key == Keys.Tab)
                //            {
                //                this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.ExitEditMode);

                //                if (!this._errFlg)
                //                {
                //                    SetBeforeFocus(this.uGrid_CustRateGroup2, ref e);
                //                }
                //                else
                //                {
                //                    e.NextCtrl = null;
                //                    this.uGrid_CustRateGroup2.PerformAction(UltraGridAction.EnterEditMode);
                //                    this._errFlg = false;
                //                }
                //            }
                //        }
                //        break;
                //    }
                case "uGrid_CustRateGroup3":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetNextFocus(this.uGrid_CustRateGroup3, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.ExitEditMode);

                                if (!this._errFlg)
                                {
                                    SetBeforeFocus(this.uGrid_CustRateGroup3, ref e);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                    this._errFlg = false;
                                }
                            }
                        }
                        break;
                    }
                case "Ok_Button":
                case "Renewal_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup3.Focus();
                                this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (e.Key == Keys.Left)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup3.Focus();
                                //this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                //this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                if (this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Text != "")
                                {
                                    // �|��G�R�[�h�֑J��
                                    this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    // �K�C�h�{�^���֑J��
                                    this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUPBUTTON].Activate();
                                }
                            }
                        }
                        break;
                    }
                case "Cancel_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_CustRateGroup3.Focus();
                                this.uGrid_CustRateGroup3.Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this.uGrid_CustRateGroup3.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
            }
        }
        #endregion �� Control Events        

        /// <summary>
        /// ClickCellButton �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̃K�C�h�{�^�����N���b�N�����ۂ̃C�x���g�����B</br>
        /// </remarks>
        private void uGrid_CustRateGroup1_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int status = -1;

            // �K�C�h�N��
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);

            // ���ڂɓW�J
            if (status == 0)
            {
                uGrid.AfterCellUpdate -= uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = true;
                e.Cell.Row.Cells[COLUMN_CUSTRATEGROUP].Value = userGdBd.GuideCode.ToString("d04");      // ���Ӑ�|���f�R�[�h
                e.Cell.Row.Cells[COLUMN_CUSTRATEGROUPNAME].Value = userGdBd.GuideName;                  // ���Ӑ�|���f����
                uGrid.AfterCellUpdate += uGrid_CustRateGroup_AfterCellUpdate;
                this._cellUpdateFlg = false;

                int rowIndex = uGrid.ActiveCell.Row.Index;   

                switch (uGrid.Name)
                {
                    case "uGrid_CustRateGroup1":
                        {
                            if (rowIndex == 0)
                            {
                                string custRateGroup = e.Cell.Row.Cells[COLUMN_CUSTRATEGROUP].Text.Trim();
                                if ((custRateGroup == "") || (int.Parse(custRateGroup) == 0))
                                {
                                    ChangeGridEnabled(true);
                                    uGrid.Focus();
                                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    ChangeGridEnabled(false);
                                    this._custRateGroup_Grid[1].Focus();
                                    this._custRateGroup_Grid[1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                    this._custRateGroup_Grid[1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (rowIndex == 25)
                            {
                                this._custRateGroup_Grid[1].Focus();
                                this._custRateGroup_Grid[1].Rows[0].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                this._custRateGroup_Grid[1].PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Focus();
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_CUSTRATEGROUP].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case "uGrid_CustRateGroup3":
                        {
                            this.Renewal_Button.Focus();
                            break;
                        }
                }
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            ReadMakerUMnt();
            ReadUserGuide();
            ReadCustomerSearchRet();

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                           "�ŐV�����擾���܂����B",
                           0,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���Ӑ�R�[�h
            int customerCode = tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCustomerCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][VIEW_CUSTOMERCODE]);
                if (customerCode == dsCustomerCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][VIEW_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓��Ӑ�|���O���[�v���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ӑ�R�[�h�̃N���A
                        tNedit_CustomerCode.Clear();
                        tEdit_CustomerName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̓��Ӑ�|���O���[�v��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._mainDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���Ӑ�R�[�h�̃N���A
                                tNedit_CustomerCode.Clear();
                                tEdit_CustomerName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}