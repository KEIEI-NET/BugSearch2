using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Collections;
using Broadleaf.Application.Resources;   // ADD ���ߋ� 2014/02/25

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�}�X�^(�����ݒ�)UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���Ӑ�}�X�^(�����ݒ�)��UI�ݒ���s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/10/29</br>
    /// <br></br>
    /// <br>Update Note: 2010/03/12  22018 ��� ���b</br>
    /// <br>           : (MANTIS:15154)���Ӑ�}�X�^�̐ݒ�Ɠ����������_�R�[�h�ȊO���͏o���Ȃ��悤�ύX�B</br>
    /// <br>Update Note: 2014/02/25  ���ߋ�</br>
    /// <br>�Ǘ��ԍ�   : 10970685-00</br>
    /// <br>           : �������Ӑ�A�������Ӑ�Ɏq�̓��Ӑ����͂ł���悤�ɂ���B</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09241UA : Form, IMasterMaintenanceArrayType
    {
        #region �� Constants

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKHN09241U";

        // �e�[�u������
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // �f�[�^�r���[�^�C�g��
        private const string GRIDTITLE_SUMCLAIMCUST = "�������Ӑ�";
        private const string GRIDTITLE_CUSTOMER = "�������Ӑ�";

        // �f�[�^�r���[�\���p
        private const string VIEW_SUMCLAIMCUSTCODE = "�������Ӑ�";
        private const string VIEW_SUMCLAIMCUSTNAME = "�������Ӑ於";
        private const string VIEW_DELETEDATE = "�폜��";
        private const string VIEW_DEMANDADDUPSECCD = "�������_";
        private const string VIEW_DEMANDADDUPSECNM = "�������_��";
        private const string VIEW_CUSTCODE = "�������Ӑ�";
        private const string VIEW_CUSTNAME = "�������Ӑ於";

        // �O���b�h��^�C�g��
        private const string COLUMN_NO = "No";
        private const string COLUMN_DEMANDADDUPSECCD = "DemandAddUpSecCd";
        private const string COLUMN_DEMANDADDUPSECNM = "DemandAddUpSecNm";
        private const string COLUMN_SECTIONGUIDE = "SectionGuide";
        private const string COLUMN_CUSTOMERCD = "CustomerCd";
        private const string COLUMN_CUSTOMERNM = "CustomerNm";
        private const string COLUMN_CUSTOMERGUIDE = "CustomerGuide";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

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

        private SumCustStAcs _sumCustStAcs;
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;

        private Dictionary<string , SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        private ControlScreenSkin _controlScreenSkin;           // ��ʃf�U�C���ύX�N���X
        private List<SumCustSt> _sumCustStListClone;            // ���Ӑ�}�X�^(�����ݒ�)���X�gClone
        private Dictionary<int, SumCustSt> _mainList;
        private List<SumCustSt> _detailList;

        private int _sumCustTotalDay;

        private bool _cusotmerGuideSelected;                    // ���Ӑ�K�C�h�I���t���O
        private bool _gridCustomerGuideFlg;
        private bool _checkSectionFlg;
        private bool _checkCustomerFlg;

        // --- ADD m.suzuki 2010/03/12 ---------->>>>>
        // �Z���ύX�O�lbackup
        private string _beforeCellText;
        // --- ADD m.suzuki 2010/03/12 ----------<<<<<
        private int _opt_KonMan;      // ADD ���ߋ� 2014/02/25
        
        #endregion �� Private Members


        #region �� Constructor
        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)UI�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public PMKHN09241UA()
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

            this._sumCustStAcs = new SumCustStAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadCustomerSearchRet();

            // DataSet����\�z
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            //�I�v�V�����L�[�̎擾�ƃ`�F�b�N
            CheckOptionKey();  �@�@//ADD ���ߋ� 2014/02/25
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // ���C��
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_SUMCLAIMCUSTCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            main.Add(VIEW_SUMCLAIMCUSTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // �ڍ�
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            detail.Add(VIEW_DEMANDADDUPSECCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_DEMANDADDUPSECNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_CUSTCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            detail.Add(VIEW_CUSTNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { false, true };
            return logicalDeleteButton;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SUMCLAIMCUST, GRIDTITLE_CUSTOMER };
            return gridTitle;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // �I������Ă���f�[�^���擾����
            int sumClaimCustCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMCLAIMCUSTCODE]);

            // ���������i�_���폜�܂ށj
            int status = this._sumCustStAcs.Search(out retList, this._enterpriseCode, sumClaimCustCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�����N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (SumCustSt sumCustSt in retList)
                        {
                            // DataSet�W�J����
                            DetailToDataSet(sumCustSt, index);
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
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<int, SumCustSt>();
            this._detailList = new List<SumCustSt>();

            ArrayList retList;

            int status = this._sumCustStAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �o�b�t�@�ێ�
                        foreach (SumCustSt sumCustSt in retList)
                        {
                            if (!this._mainList.ContainsKey(sumCustSt.SumClaimCustCode))
                            {
                                this._mainList.Add(sumCustSt.SumClaimCustCode, sumCustSt);
                            }

                            this._detailList.Add(sumCustSt);
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

            // �ǂݍ��񂾃C���X�^���X�̂��ꂼ����f�[�^�Z�b�g�ɓW�J
            int index = 0;
            foreach (SumCustSt sumCustSt in this._mainList.Values)
            {
                // DataSet�W�J����
                MainToDataSet(sumCustSt, index);
                index++;
            }

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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideSnm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// ���Ӑ���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�����擾���A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
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
                    foreach (CustomerSearchRet customerSearchRet in retArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(customerSearchRet.CustomerCode, customerSearchRet);
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
        /// ���Ӑ於�擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return customerName;
        }

        /// <summary>
        /// �����擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �������擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private int GetTotalDay(int customerCode)
        {
            int totalDay = 0;

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                totalDay = this._customerSearchRetDic[customerCode].TotalDay;
            }

            return totalDay;
        }

        /// <summary>
        /// ���Ӑ���擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ���</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private int GetCustomerInfo(int customerCode, out CustomerInfo customerInfo)
        {
            customerInfo = null;
            int status;

            try
            {
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status != 0)
                {
                    customerInfo = null;
                }
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }

            return status;
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���_
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();

            // �O���b�h
            for (int rowIndex = 0; rowIndex < this.uGrid_SumCustSt.Rows.Count; rowIndex++)
            {
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activation = Activation.AllowEdit;
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activation = Activation.AllowEdit;
            }

            this.uGrid_SumCustSt.ActiveCell = null;
            this.uGrid_SumCustSt.ActiveRow = null;
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �}�X�^�Ǎ�
            ReadSecInfoSet();
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

            // �O���b�h�\�z
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            dataTable.Columns.Add(COLUMN_DEMANDADDUPSECCD, typeof(string));
            dataTable.Columns.Add(COLUMN_DEMANDADDUPSECNM, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONGUIDE, typeof(string));
            dataTable.Columns.Add(COLUMN_CUSTOMERCD, typeof(string));
            dataTable.Columns.Add(COLUMN_CUSTOMERNM, typeof(string));
            dataTable.Columns.Add(COLUMN_CUSTOMERGUIDE, typeof(string));

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_NO] = rowIndex + 1;
                dataRow[COLUMN_DEMANDADDUPSECCD] = "";
                dataRow[COLUMN_DEMANDADDUPSECNM] = "";
                dataRow[COLUMN_SECTIONGUIDE] = "";
                dataRow[COLUMN_CUSTOMERCD] = "";
                dataRow[COLUMN_CUSTOMERNM] = "";
                dataRow[COLUMN_CUSTOMERGUIDE] = "";

                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_SumCustSt.DataSource = dataTable;

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = "";
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Tag = "";
            }

            ColumnsCollection columns = this.uGrid_SumCustSt.DisplayLayout.Bands[0].Columns;

            // �w�b�_�[�L���v�V����
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_DEMANDADDUPSECCD].Header.Caption = "�������_";
            columns[COLUMN_DEMANDADDUPSECNM].Header.Caption = "�������_��";
            columns[COLUMN_SECTIONGUIDE].Header.Caption = "";
            columns[COLUMN_CUSTOMERCD].Header.Caption = "�������Ӑ�";
            columns[COLUMN_CUSTOMERNM].Header.Caption = "�������Ӑ於";
            columns[COLUMN_CUSTOMERGUIDE].Header.Caption = "";
            // TextHAlign
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_DEMANDADDUPSECCD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_CUSTOMERCD].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_CUSTOMERNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_CUSTOMERGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            // TextVAlign
            columns[COLUMN_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_DEMANDADDUPSECCD].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERCD].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERNM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            // ���͐���
            columns[COLUMN_NO].CellActivation = Activation.Disabled;
            columns[COLUMN_DEMANDADDUPSECCD].CellActivation = Activation.AllowEdit;
            columns[COLUMN_DEMANDADDUPSECNM].CellActivation = Activation.Disabled;
            columns[COLUMN_SECTIONGUIDE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_CUSTOMERCD].CellActivation = Activation.AllowEdit;
            columns[COLUMN_CUSTOMERNM].CellActivation = Activation.Disabled;
            columns[COLUMN_CUSTOMERGUIDE].CellActivation = Activation.AllowEdit;
            // ��
            columns[COLUMN_NO].Width = 45;
            columns[COLUMN_DEMANDADDUPSECCD].Width = 90;
            columns[COLUMN_DEMANDADDUPSECNM].Width = 175;
            columns[COLUMN_SECTIONGUIDE].Width = 24;
            columns[COLUMN_CUSTOMERCD].Width = 100;
            columns[COLUMN_CUSTOMERNM].Width = 175;
            columns[COLUMN_CUSTOMERGUIDE].Width = 24;
            // �Z��Color
            columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
            columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_DEMANDADDUPSECNM].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_CUSTOMERNM].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_CUSTOMERNM].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_DEMANDADDUPSECCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            columns[COLUMN_CUSTOMERCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            // MaxLength
            columns[COLUMN_DEMANDADDUPSECCD].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_DEMANDADDUPSECCD);
            columns[COLUMN_CUSTOMERCD].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_CUSTOMERCD);
            columns[COLUMN_DEMANDADDUPSECNM].MaxLength = 10;
            columns[COLUMN_CUSTOMERNM].MaxLength = 10;
            // �Z���{�^��
            columns[COLUMN_SECTIONGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_SECTIONGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_SECTIONGUIDE].CellAppearance.Cursor = Cursors.Hand;
            columns[COLUMN_CUSTOMERGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_CUSTOMERGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_CUSTOMERGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_CUSTOMERGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_CUSTOMERGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_CUSTOMERGUIDE].CellAppearance.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// DataSet�W�J����(���C���e�[�u��)
        /// </summary>
        /// <param name="sumCustSt">���Ӑ�}�X�^(�����ݒ�)</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void MainToDataSet(SumCustSt sumCustSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // �������Ӑ�
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMCLAIMCUSTCODE] = sumCustSt.SumClaimCustCode.ToString("00000000");
            // �������Ӑ於
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMCLAIMCUSTNAME] = GetCustomerName(sumCustSt.SumClaimCustCode);
        }

        /// <summary>
        /// DataSet�W�J����(�ڍ׃e�[�u��)
        /// </summary>
        /// <param name="sumCustSt">���Ӑ�}�X�^(�����ݒ�)</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void DetailToDataSet(SumCustSt sumCustSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // �폜��
            if (sumCustSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = sumCustSt.UpdateDateTimeJpInFormal;
            }
            // �������_
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DEMANDADDUPSECCD] = sumCustSt.DemandAddUpSecCd.Trim();
            // �������_��
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DEMANDADDUPSECNM] = GetSectionName(sumCustSt.DemandAddUpSecCd.Trim());
            // �������Ӑ�
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_CUSTCODE] = sumCustSt.CustomerCode.ToString("00000000");
            // �������Ӑ於
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_CUSTNAME] = GetCustomerName(sumCustSt.CustomerCode);
        }

        /// <summary>
        /// DataSet����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet������\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // ���C��
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_SUMCLAIMCUSTCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMCLAIMCUSTNAME, typeof(string));

            //==============================
            // �ڍ�
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            detailTable.Columns.Add(VIEW_DEMANDADDUPSECCD, typeof(string));
            detailTable.Columns.Add(VIEW_DEMANDADDUPSECNM, typeof(string));
            detailTable.Columns.Add(VIEW_CUSTCODE, typeof(string));
            detailTable.Columns.Add(VIEW_CUSTNAME, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.uGrid_SumCustSt.Rows.Count > 25)
            {
                for (int index = this.uGrid_SumCustSt.Rows.Count - 1; index >= 25; index--)
                {
                    this.uGrid_SumCustSt.Rows[index].Delete(false);
                }
            }

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

                // �N���[���쐬
                this._sumCustStListClone = new List<SumCustSt>();

                // �t�H�[�J�X�ݒ�
                this.tNedit_CustomerCode.Focus();
            }
            else
            {
                // DataSet���瓾�Ӑ�R�[�h���擾
                int sumClaimCustCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMCLAIMCUSTCODE]);

                // ���Ӑ�R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
                List<SumCustSt> sumCustStList = this._detailList.FindAll(delegate(SumCustSt x)
                {
                    if (x.SumClaimCustCode == sumClaimCustCode)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                // �������Ӑ�̒����擾
                this._sumCustTotalDay = GetTotalDay(sumClaimCustCode);

                this._sumCustStListClone = new List<SumCustSt>();

                if (sumCustStList.Count == 0)
                {
                    SumCustSt sumCustSt = new SumCustSt();
                    sumCustSt.SumClaimCustCode = sumClaimCustCode;
                    sumCustStList.Add(sumCustSt);
                }
                else
                {
                    foreach (SumCustSt sumCustSt in sumCustStList)
                    {
                        this._sumCustStListClone.Add(sumCustSt.Clone());
                    }
                }

                // ��ʓW�J����
                SumCustStListToScreen(sumCustStList);

                if (sumCustStList[0].LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋�����
                    PermitScreenInput(UPDATE_MODE);

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // �t�H�[�J�X�ݒ�
                    this.uGrid_SumCustSt.Focus();
                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
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

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɂ���ĉ�ʂ̓��͋�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    {
                        // �V�K���[�h
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        this.uGrid_SumCustSt.Enabled = true;
                        break;
                    }
                case UPDATE_MODE:
                    {
                        // �X�V���[�h
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        this.uGrid_SumCustSt.Enabled = true;
                        break;
                    }
                case DELETE_MODE:
                    {
                        // �폜���[�h
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;

                        this.uGrid_SumCustSt.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)���X�g��ʓW�J����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void SumCustStListToScreen(List<SumCustSt> sumCustStList)
        {
            int rowIndex = 0;
            foreach (SumCustSt sumCustSt in sumCustStList)
            {
                // �������Ӑ�
                this.tNedit_CustomerCode.SetInt(sumCustSt.SumClaimCustCode);
                // �������Ӑ於
                this.tEdit_CustomerName.DataText = GetCustomerName(sumCustSt.SumClaimCustCode);

                if (rowIndex == this.uGrid_SumCustSt.Rows.Count)
                {
                    // �O���b�h�s�ǉ�
                    CreateNewRow(ref this.uGrid_SumCustSt);
                }

                // �������_
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = sumCustSt.DemandAddUpSecCd.Trim();
                // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sumCustSt.DemandAddUpSecCd.Trim();
                // --- ADD m.suzuki 2010/03/12 ----------<<<<<
                // �������_��
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName(sumCustSt.DemandAddUpSecCd.Trim());
                // �������Ӑ�
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = sumCustSt.CustomerCode.ToString("00000000");
                // �������Ӑ於
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = GetCustomerName(sumCustSt.CustomerCode);

                rowIndex++;
            }
        }

        /// <summary>
        /// �ۑ��f�[�^�擾����
        /// </summary>
        /// <returns>�ۑ��f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ��f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private List<SumCustSt> GetSaveSumCustStListFromScreen()
        {
            List<SumCustSt> sumCustStList = new List<SumCustSt>();

            for (int rowIndex = 0; rowIndex < this.uGrid_SumCustSt.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.uGrid_SumCustSt.Rows[rowIndex].Cells;

                // �������_�E�������Ӑ悪�󔒂̏ꍇ
                if ((CellTextToString(cells[COLUMN_DEMANDADDUPSECCD].Text) == "") &&
                    (CellTextToInt(cells[COLUMN_CUSTOMERCD].Text) == 0))
                {
                    continue;
                }
                //if ((cells[COLUMN_DEMANDADDUPSECCD].Value == DBNull.Value) ||
                //    (((string)cells[COLUMN_DEMANDADDUPSECCD].Value).Trim() == ""))
                //{
                //    continue;
                //}

                //// �������Ӑ悪�󔒂������͂O�̏ꍇ
                //if (CellTextToInt(cells[COLUMN_CUSTOMERCD].Text) == 0)
                //{
                //    continue;
                //}
                //if ((cells[COLUMN_CUSTOMERCD].Value == DBNull.Value) ||
                //    (((string)cells[COLUMN_CUSTOMERCD].Value).Trim() == "") ||
                //    (int.Parse(((string)cells[COLUMN_CUSTOMERCD].Value).Trim()) == 0))
                //{
                //    continue;
                //}

                SumCustSt SumCustSt = new SumCustSt();

                // ��ƃR�[�h
                SumCustSt.EnterpriseCode = this._enterpriseCode;
                // �����������Ӑ�R�[�h
                SumCustSt.SumClaimCustCode= this.tNedit_CustomerCode.GetInt();
                // �����v�㋒�_�R�[�h
                SumCustSt.DemandAddUpSecCd = CellTextToString(cells[COLUMN_DEMANDADDUPSECCD].Text);
                // ���Ӑ�R�[�h
                SumCustSt.CustomerCode = CellTextToInt(cells[COLUMN_CUSTOMERCD].Text);

                sumCustStList.Add(SumCustSt);
            }

            return sumCustStList;
        }

        /// <summary>
        /// �X�V�p���X�g�擾����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="deleteList">�폜���X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ����X�g�E�폜���X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // �ۑ��p�f�[�^�擾
            List<SumCustSt> saveSumCustStList = GetSaveSumCustStListFromScreen();

            // �폜���X�g�쐬
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                deleteList.Add(sumCustSt.Clone());
            }

            // �ۑ����X�g�쐬
            foreach (SumCustSt sumCustSt in saveSumCustStList)
            {
                saveList.Add(sumCustSt);
            }
        }

        /// <summary>
        /// Key�擾����
        /// </summary>
        /// <param name="sumCustSt">���Ӑ�}�X�^(�����ݒ�)�}�X�^</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)����Key���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private string GetKey(SumCustSt sumCustSt)
        {
            string key = "";

            // �����������Ӑ�R�[�h(8��)�{�������_�R�[�h(2��)�{���Ӑ�R�[�h(8��)
            key = sumCustSt.SumClaimCustCode.ToString("00000000") + sumCustSt.DemandAddUpSecCd.Trim() +
                  sumCustSt.CustomerCode.ToString("00000000");

            return key;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool SaveProc()
        {
            // ���̓`�F�b�N
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (false);
            }

            ArrayList saveList;
            ArrayList deleteList;

            // �X�V�p�f�[�^�擾
            GetUpdateList(out saveList, out deleteList);

            int status;

            if (deleteList.Count > 0)
            {
                // �폜����
                status = this._sumCustStAcs.Delete(deleteList);
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

            // �ۑ�����
            status = this._sumCustStAcs.Write(ref saveList);
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
        /// <br>Date	   : 2008/10/29</br>
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
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                deleteList.Add(sumCustSt.Clone());
            }

            // �폜����
            int status = this._sumCustStAcs.Delete(deleteList);
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSet���瑍���������Ӑ�R�[�h���擾
            int sumClaimCustCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMCLAIMCUSTCODE]);

            // �����������Ӑ�R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
            List<SumCustSt> sumCustStList = this._detailList.FindAll(delegate(SumCustSt x)
            {
                if (x.SumClaimCustCode == sumClaimCustCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (sumCustStList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�폜�Ώۃf�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }

            if (sumCustStList[0].LogicalDeleteCode != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂��B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (SumCustSt sumCustSt in sumCustStList)
            {
                logicalList.Add(sumCustSt.Clone());
            }

            // �_���폜����
            int status = this._sumCustStAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        string key;

                        foreach (SumCustSt sumCustSt in logicalList)
                        {
                            key = GetKey(sumCustSt);
                            int listIndex = this._detailList.FindIndex(delegate(SumCustSt x)
                            {
                                string key2 = GetKey(x);

                                if (key == key2)
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            if (listIndex >= 0)
                            {
                                // �o�b�t�@�X�V
                                this._detailList[listIndex] = sumCustSt.Clone();
                            }

                            // DataSet�W�J
                            DetailToDataSet(sumCustSt, index);
                            index++;
                        }

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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // �������X�g�擾
            ArrayList reviveList = new ArrayList();
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                reviveList.Add(sumCustSt.Clone());
            }

            // ��������
            int status = this._sumCustStAcs.Revival(ref reviveList);
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
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  ���ߋ�</br>
        /// <br>�Ǘ��ԍ�   : 10970685-00</br>
        /// <br>           : �������Ӑ�A�������Ӑ�Ɏq�̓��Ӑ����͂ł���悤�ɂ���B</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // �����������Ӑ�R�[�h
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "�������Ӑ�R�[�h����͂��Ă��������B";
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }
                int customerCode = this.tNedit_CustomerCode.GetInt();

                if (CheckSumClaimCustCode(customerCode) == false)
                {
                    this.tNedit_CustomerCode.Focus();
                    return (false);
                }

                // �����v�㋒�_�R�[�h
                bool inputFlg = false;

                for (int rowIndex = 0; rowIndex < this.uGrid_SumCustSt.Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this.uGrid_SumCustSt.Rows[rowIndex].Cells;

                    // ���_�R�[�h�擾
                    string sectionCode = CellTextToString(cells[COLUMN_DEMANDADDUPSECCD].Text);

                    if (sectionCode != "")
                    {
                        if (CheckSectionCode(sectionCode) == false)
                        {
                            this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                            this.uGrid_SumCustSt.Focus();
                            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                            this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                            return (false);
                        }
                    }

                    // ���Ӑ�R�[�h�擾
                    int custCode = CellTextToInt(cells[COLUMN_CUSTOMERCD].Text);

                    if (custCode != 0)
                    {
                        if (CheckCustomerCode(custCode, rowIndex) == false)
                        {
                            this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                            this.uGrid_SumCustSt.Focus();
                            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                            this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                            return (false);
                        }
                    }

                    if ((sectionCode == "") && (custCode == 0))
                    {
                        continue;
                    }

                    if (sectionCode == "")
                    {
                        this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        errMsg = "�����v�㋒�_�R�[�h����͂��Ă��������B"; 

                        this.uGrid_SumCustSt.Focus();
                        this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                        this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                        this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        return (false);
                    }

                    if (custCode == 0)
                    {
                        this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        errMsg = "���Ӑ�R�[�h����͂��Ă��������B";
                        this.uGrid_SumCustSt.Focus();
                        this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                        this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        return (false);
                    }

                    // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                    // �������_�̐������`�F�b�N
                    CustomerInfo customerInfo;
                    GetCustomerInfo( custCode, out customerInfo );


                    if (customerInfo != null)
                    {
                        // --- DEL ���ߋ� 2014/02/25 ---------->>>>>
                        //string claimSectionCode = customerInfo.ClaimSectionCode.Trim();
                                                   
                        //// �������_�`�F�b�N
                        //if (sectionCode != claimSectionCode)
                        //{
                        //    this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        //    errMsg = "�q���Ӑ�͓o�^�ł��܂���B";

                        //    this.uGrid_SumCustSt.Focus();
                        //    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        //    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                        //    this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        //    return (false);
                        //}
                        // --- DEL ���ߋ� 2014/02/25 ----------<<<<<
                        
                        // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                        if (this._opt_KonMan == (int)Option.ON)
                        {
                            // �������_�`�F�b�N
                            string tempSectionCode;
                            string errMsgT;

                            if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                            {
                                // �q���Ӑ�
                                tempSectionCode = customerInfo.MngSectionCode.Trim();
                                errMsgT = "���͂������_�͓��Ӑ�̊Ǘ����_�ł͂���܂���B";
                            }
                            else
                            {
                                // �e���Ӑ�
                                tempSectionCode = customerInfo.ClaimSectionCode.Trim();
                                errMsgT = "���͂������_�͐�����̐������_�ł͂���܂���B";
                            }

                            if (sectionCode != tempSectionCode)
                            {
                                this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;                              
                                
                                this.uGrid_SumCustSt.Focus();
                                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                                this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                                
                                errMsg = errMsgT;
                                return (false);
                            }
 
                        }
                        else
                        {
                            string claimSectionCode = customerInfo.ClaimSectionCode.Trim();

                            // �������_�`�F�b�N
                            if (sectionCode != claimSectionCode)
                            {
                                this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                                errMsg = "�q���Ӑ�͓o�^�ł��܂���B";

                                this.uGrid_SumCustSt.Focus();
                                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                                this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                                return (false);
                            }
                        }
                        // --- ADD ���ߋ� 2014/02/25 ----------<<<<<

                    }
                    else
                    {
                        // ���Ӑ�}�X�^���o�^
                        this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                        errMsg = "���Ӑ悪���o�^�ł��B";
                        this.uGrid_SumCustSt.Focus();
                        this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        this.uGrid_SumCustSt.PerformAction( UltraGridAction.EnterEditMode );

                        this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                        return (false);
                    }
                    // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                    inputFlg = true;
                }

                // �����v�㋒�_�R�[�h�E���Ӑ�R�[�h��1�������͂���Ă��Ȃ������ꍇ
                if (inputFlg == false)
                {
                    this.uGrid_SumCustSt.AfterExitEditMode -= uGrid_SumCustSt_AfterExitEditMode;

                    //errMsg = "�����v�㋒�_�R�[�h�A���Ӑ�R�[�h�̓o�^������܂���B";  // DEL ���ߋ� 2014/02/25
                    // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.ON)
                    {
                        errMsg = "���_�R�[�h�A���Ӑ�R�[�h�̓o�^������܂���B";
                    }
                    else
                    {
                        errMsg = "�����v�㋒�_�R�[�h�A���Ӑ�R�[�h�̓o�^������܂���B";
                    }
                    // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                    this.uGrid_SumCustSt.Focus();
                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);

                    this.uGrid_SumCustSt.AfterExitEditMode += uGrid_SumCustSt_AfterExitEditMode;
                    return (false);
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // �V�K�Ǎ����ɑ����������Ӑ�R�[�h�����͂���Ă����ꍇ
            if ((this._sumCustStListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            // �ۑ��f�[�^�擾
            List<SumCustSt> saveSumCustStList = new List<SumCustSt>();
            try
            {
                saveSumCustStList = GetSaveSumCustStListFromScreen();
            }
            catch
            {
                return (false);
            }

            // ��ʓǍ����ƕۑ��f�[�^�̌������Ⴄ�ꍇ
            if (this._sumCustStListClone.Count != saveSumCustStList.Count)
            {
                return (false);
            }

            string key;
            bool sameFlg = false;
            foreach (SumCustSt sumCustSt in this._sumCustStListClone)
            {
                // Key�擾
                key = GetKey(sumCustSt);

                // ��ʓǍ����̃f�[�^�������ꍇ
                foreach (SumCustSt saveSumCust in saveSumCustStList)
                {
                    string saveKey = GetKey(saveSumCust);
                    if (key == saveKey)
                    {
                        sameFlg = true;
                        break;
                    }
                }

                if (!sameFlg)
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// �������Ӑ�R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������Ӑ�R�[�h�Ƃ��ē��͂ł��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  ���ߋ�</br>
        /// <br>�Ǘ��ԍ�   : 10970685-00</br>
        /// <br>           : �������Ӑ�A�������Ӑ�Ɏq�̓��Ӑ����͂ł���悤�ɂ���B</br>
        /// </remarks>
        private bool CheckSumClaimCustCode(int customerCode)
        {
            string errMsg = "";

            try
            {
                //if (this.Mode_Label.Text == INSERT_MODE)
                //{
                //    if (this._mainList.ContainsKey(customerCode))
                //    {
                //        errMsg = "�������Ӑ�Ƃ��ēo�^����Ă��܂��B";
                //        return (false);
                //    }
                //}

                SumCustSt sumCustSt = this._detailList.Find(delegate(SumCustSt x)
                {
                    if (x.SumClaimCustCode != customerCode)
                    {
                        if (x.CustomerCode == customerCode)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                });
                if (sumCustSt != null)
                {
                    errMsg = "�ʂ̑������Ӑ�ɐ������Ӑ�Ƃ��ēo�^����Ă��܂��B";
                    return (false);
                }

                CustomerInfo customerInfo;
                int status = GetCustomerInfo(customerCode, out customerInfo);
                if (status != 0)
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }
                else
                {
                    // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.OFF)
                    {
                    // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                        if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                        {
                            errMsg = "�������Ӑ�ł͂���܂���B";
                            return (false);
                        }
                    }// ADD ���ߋ� 2014/02/25

                    if (customerInfo.AcceptWholeSale == 2)
                    {
                        errMsg = "�������Ӑ�ł͂���܂���B";
                        return (false);
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
        /// �������Ӑ�R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������Ӑ�R�[�h�Ƃ��ē��͂ł��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  ���ߋ�</br>
        /// <br>�Ǘ��ԍ�   : 10970685-00</br>
        /// <br>           : �������Ӑ�A�������Ӑ�Ɏq�̓��Ӑ����͂ł���悤�ɂ���B</br>
        /// </remarks>
        private bool CheckCustomerCode(int customerCode, int rowIndex)
        {
            string errMsg = "";

            try
            {
                //if (this.tNedit_CustomerCode.GetInt() == customerCode)
                //{
                //    errMsg = "�������Ӑ�͓o�^�ł��܂���B";
                //    return (false);
                //}

                //if (this._mainList.ContainsKey(customerCode))
                //{
                //    errMsg = "�������Ӑ�Ƃ��ēo�^����Ă��܂��B";
                //    return (false);
                //}

                // �������Ӑ�R�[�h�擾
                int sumClaimCustCode = this.tNedit_CustomerCode.GetInt();

                // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                if (_opt_KonMan == (int)Option.ON)
                {
                    SumCustSt custSt = this._detailList.Find(delegate(SumCustSt x)
                    {
                        // ���͂������Ӑ�R�[�h���������Ӑ�ꍇ
                        if (x.SumClaimCustCode == customerCode)
                        {
                            // �������Ӑ悪�����ꍇ�A�o�^�ɂ���
                            if (sumClaimCustCode == customerCode)
                            {
                                return (false);
                            }
                            // �������Ӑ悪���̓��Ӑ�ꍇ�A�o�^�s�ɂ���
                            else
                            {
                                return (true);
                            }
                        }
                        // ���͂������Ӑ�R�[�h���������Ӑ�ł͂Ȃ��ꍇ�A�o�^�ɂȂ�
                        else
                        {
                            return (false);
                        }
                    });
                    if (custSt != null)
                    {
                        errMsg = "�ʂ̑������Ӑ�ɑ������Ӑ�Ƃ��ēo�^����Ă��܂��B";
                        return (false);
                    }
                }
                // --- ADD ���ߋ� 2014/02/25 ----------<<<<<

                SumCustSt sumCustSt = this._detailList.Find(delegate(SumCustSt x)
                {
                    if (x.SumClaimCustCode == sumClaimCustCode)
                    {
                        return (false);
                    }
                    else
                    {
                        if (x.CustomerCode == customerCode)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                });
                if (sumCustSt != null)
                {
                    errMsg = "�ʂ̑������Ӑ�ɐ������Ӑ�Ƃ��ēo�^����Ă��܂��B";
                    return (false);
                }

                for (int index = 0; index < this.uGrid_SumCustSt.Rows.Count; index++)
                {
                    if (index == rowIndex)
                    {
                        continue;
                    }

                    // ���Ӑ�R�[�h�擾
                    int customerCd = StrObjectToInt(this.uGrid_SumCustSt.Rows[index].Cells[COLUMN_CUSTOMERCD].Value);

                    if (customerCd == customerCode)
                    {
                        errMsg = "�ʂ̍s�ɐ������Ӑ�Ƃ��ēo�^����Ă��܂��B";
                        return (false);
                    }
                }

                CustomerInfo customerInfo;
                int status = GetCustomerInfo(customerCode, out customerInfo);
                if (status != 0)
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }
                else
                {
                    if (this.tNedit_CustomerCode.GetInt() != 0)
                    {
                        if (customerInfo.TotalDay != this._sumCustTotalDay)
                        {
                            errMsg = "�������Ӑ�ƒ������قȂ�܂��B";
                            return (false);
                        }
                    }


                    if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                    {
                        // --- DEL ���ߋ� 2014/02/25 ---------->>>>>
                        //errMsg = "�������Ӑ�ł͂���܂���B";
                        //return (false);
                        // --- DEL ���ߋ� 2014/02/25 ----------<<<<<

                        // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                        if (_opt_KonMan == (int)Option.ON)
                        {
                            string sectionCd = StrObjectToString(this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value);
                            if (!string.IsNullOrEmpty(sectionCd) && !customerInfo.MngSectionCode.Trim().Equals(sectionCd))
                            {
                                errMsg = "���͂������_�͓��Ӑ�̊Ǘ����_�ł͂���܂���B";
                                return (false);
                            }
                        }
                        else
                        {
                            errMsg = "�������Ӑ�ł͂���܂���B";
                            return (false);
                        }
                        // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                    }


                    if (customerInfo.AcceptWholeSale == 2)
                    {
                        errMsg = "�������Ӑ�ł͂���܂���B";
                        return (false);
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
        /// ���_�R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���}�X�^�ɑ��݂��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private bool CheckSectionCode(string sectionCode)
        {
            string errMsg = "";

            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()) == false)
                {
                    errMsg = "���_���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
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
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
        /// <br>Date       : 2008/10/29</br>
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
                                         this._sumCustStAcs,			    // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        /// <summary>
        /// �s�N���A����
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �Ώۍs�̃f�[�^���N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = "";
            this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Tag = "";
        }

        /// <summary>
        /// �V�K�s�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɍs��ǉ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            // �s�ǉ�
            uGrid.DisplayLayout.Bands[0].AddNew();

            // �s�ԍ��ݒ�
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_NO].Value = uGrid.Rows.Count;

            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_DEMANDADDUPSECCD].Tag = "";
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_CUSTOMERCD].Tag = "";
        }

        /// <summary>
        /// �ϊ�����(object��string)
        /// </summary>
        /// <param name="targetValue">�ϊ��Ώ�object</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : object�^��string�ɕϊ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private string StrObjectToString(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == ""))
            {
                return "";
            }

            return (string)targetValue;
        }

        /// <summary>
        /// �ϊ�����(object��int)
        /// </summary>
        /// <param name="targetValue">�ϊ��Ώ�object</param>
        /// <returns>���l</returns>
        /// <remarks>
        /// <br>Note       : object�^��int�ɕϊ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/10/29</br>
        /// </remarks>
        private int StrObjectToInt(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == "") || (int.Parse((string)targetValue) == 0))
            {
                return 0;
            }

            return int.Parse((string)targetValue);
        }

        private string CellTextToString(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == ""))
            {
                return "";
            }

            return cellText.Trim().PadLeft(2, '0');
        }

        private int CellTextToInt(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == ""))
            {
                return 0;
            }

            return int.Parse(cellText.Trim());
        }

        /// <summary>
        /// NextFocus �ݒ菈��
        /// </summary>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����Enter�L�[���������ꂽ����NextFocus�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
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
                    uGrid.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
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

            // �ҏW���[�h�I��
            uGrid.PerformAction(UltraGridAction.ExitEditMode);

            e.NextCtrl = null;

            switch (columnIndex)
            {
                case 1:   // ���_�R�[�h
                    {
                        if (!this._checkSectionFlg)
                        {
                            // ���_�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // ���_���擾
                        string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value);

                        if (sectionName == "")
                        {
                            // ���_�K�C�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                        }
                        else
                        {
                            // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        }

                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 3:       // ���_�K�C�h
                    {
                        // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                        uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // ���Ӑ�R�[�h
                    {
                        if (!this._checkCustomerFlg)
                        {
                            // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // ���Ӑ於�擾
                        string customerName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value);

                        if (customerName == "")
                        {
                            // ���Ӑ�K�C�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERGUIDE].Activate();
                        }
                        else
                        {
                            if (rowIndex == uGrid.Rows.Count - 1)
                            {
                                // �ۑ��{�^���Ƀt�H�[�J�X
                                e.NextCtrl = this.Ok_Button;
                            }
                            else
                            {
                                // ���_�R�[�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }

                        return;
                    }
                case 6:      // ���Ӑ�K�C�h
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            // �ۑ��{�^���Ƀt�H�[�J�X
                            e.NextCtrl = this.Ok_Button;
                        }
                        else
                        {
                            // ���_�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex + 1].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
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
        /// <br>Date	   : 2008/10/29</br>
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

            // �ҏW���[�h�I��
            uGrid.PerformAction(UltraGridAction.ExitEditMode);

            e.NextCtrl = null;

            switch (columnIndex)
            {
                case 1:   // ���_�R�[�h
                    {
                        if (!this._checkSectionFlg)
                        {
                            // ���_�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        string customerName;

                        if (rowIndex == 0)
                        {
                            // ���Ӑ於�擾
                            customerName = this.tEdit_CustomerName.DataText.Trim();

                            if (customerName == "")
                            {
                                // ���Ӑ�K�C�h�Ƀt�H�[�J�X
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                                e.NextCtrl = this.tNedit_CustomerCode;
                            }
                        }
                        else
                        {
                            // ���Ӑ於�擾
                            customerName = StrObjectToString(uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTOMERNM].Value);

                            if (customerName == "")
                            {
                                // ���Ӑ�K�C�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTOMERGUIDE].Activate();
                            }
                            else
                            {
                                // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_CUSTOMERCD].Activate();
                            }

                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        return;
                    }
                case 3:       // ���_�K�C�h
                    {
                        // ���_�R�[�h�Ƀt�H�[�J�X
                        uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // ���Ӑ�R�[�h
                    {
                        if (!this._checkCustomerFlg)
                        {
                            // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // ���_���擾
                        string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value);

                        if (sectionName == "")
                        {
                            // ���_�K�C�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                        }
                        else
                        {
                            // ���_�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                        }

                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 6:      // ���Ӑ�K�C�h
                    {
                        // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                        uGrid.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
            }
        }

        // ADD ���ߋ� 2014/02/25 ------------------------------------->>>>>
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }

        /// <summary>
        /// �I�v�V�����L�[���`�F�b�N����
        /// </summary>
        private void CheckOptionKey()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KonmanGoodsMstCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_KonMan = (int)Option.ON;
            }
            else
            {
                this._opt_KonMan = (int)Option.OFF;
            }
            #endregion
        }
        // ADD ���ߋ� 2014/02/25 -------------------------------------<<<<<
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PMKHN09241UA_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            SetScreenInitialSetting();

            // ��ʃN���A
            ScreenClear();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PMKHN09241UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void PMKHN09241UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                
                // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                // ��ʃN���A
                ScreenClear();
                // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;
                this._gridCustomerGuideFlg = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    this.uGrid_SumCustSt.Focus();
                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                }
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
        /// <br>Date       : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  ���ߋ�</br>
        /// <br>�Ǘ��ԍ�   : 10970685-00</br>
        /// <br>           : �������Ӑ�A�������Ӑ�Ɏq�̓��Ӑ����͂ł���悤�ɂ���B</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            if (!this._gridCustomerGuideFlg)
            {
                bool bStatus = CheckSumClaimCustCode(customerSearchRet.CustomerCode);
                if (!bStatus)
                {
                    this._sumCustTotalDay = 0;
                    return;
                }

                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
                // ���Ӑ於��
                this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();
                // ����
                this._sumCustTotalDay = customerSearchRet.TotalDay;
            }
            else
            {
                bool bStatus = CheckCustomerCode(customerSearchRet.CustomerCode, this.uGrid_SumCustSt.ActiveCell.Row.Index);
                if (!bStatus)
                {
                    return;
                }

                int rowIndex = this.uGrid_SumCustSt.ActiveCell.Row.Index;

                // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                string sectionCode = string.Empty;

                // �������_�R�[�h�擾
                CustomerInfo customerInfo;
                GetCustomerInfo( customerSearchRet.CustomerCode, out customerInfo );
                if ( customerInfo != null )
                {
                    // sectionCode = customerInfo.ClaimSectionCode.Trim();  // DEL ���ߋ� 2014/02/25
                    
                    // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.ON)
                    {
                        if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                        {
                            sectionCode = customerInfo.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = customerInfo.ClaimSectionCode.Trim();
                        }
                    }
                    else
                    {
                        sectionCode = customerInfo.ClaimSectionCode.Trim();
                    }
                    // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                }

                string inputSectionCode = StrObjectToString( this.uGrid_SumCustSt.Rows[this.uGrid_SumCustSt.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value );
                if ( string.IsNullOrEmpty( inputSectionCode ) )
                {
                    // ���_�����͂Ȃ�ΐ������_�Z�b�g
                    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Value = sectionCode;
                    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sectionCode;
                    this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName( sectionCode );
                }
                else if ( sectionCode != inputSectionCode )
                {
                    // --- DEL ���ߋ� 2014/02/25 ---------->>>>>
                    // ���_���͍ς݂œ��Ӑ�}�X�^�̐������_�ƈقȂ�Ȃ�΁A�G���[�\��(���Ӑ���G���[��������)
                    //ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                    //               "�q���Ӑ�͓o�^�ł��܂���B",
                    //               -1,
                    //               MessageBoxButtons.OK,
                    //               MessageBoxDefaultButton.Button1);
                    // --- DEL ���ߋ� 2014/02/25 ----------<<<<<

                    // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                    if (_opt_KonMan == (int)Option.ON)
                    {
                        if (customerInfo.CustomerCode == customerInfo.ClaimCode)
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "���͂������_�͐�����̐������_�ł͂���܂���B",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "���͂������_�͓��Ӑ�̊Ǘ����_�ł͂���܂���B",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        //���_���͍ς݂œ��Ӑ�}�X�^�̐������_�ƈقȂ�Ȃ�΁A�G���[�\��(���Ӑ���G���[��������)
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "�q���Ӑ�͓o�^�ł��܂���B",
                                       -1,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                    }
                    // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                    return;
                }
                // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                // ���Ӑ�R�[�h
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Value = customerSearchRet.CustomerCode.ToString("00000000");
                // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERCD].Tag = customerSearchRet.CustomerCode.ToString( "00000000" );
                // --- ADD m.suzuki 2010/03/12 ----------<<<<<
                // ���Ӑ於��
                this.uGrid_SumCustSt.Rows[rowIndex].Cells[COLUMN_CUSTOMERNM].Value = customerSearchRet.Snm.Trim();
            }

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
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //if (this.uGrid_SumCustSt.ActiveCell != null)
                //{
                //    UltraGridCell uGrid = this.uGrid_SumCustSt.ActiveCell;

                //    this.uGrid_SumCustSt.PerformAction(UltraGridAction.ExitEditMode);
                //    if (uGrid.Column.Key == COLUMN_DEMANDADDUPSECCD)
                //    {
                //        if (this._checkSectionFlg == false)
                //        {
                //            this.uGrid_SumCustSt.ActiveCell = uGrid;
                //            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                //            return;
                //        }
                //    }
                //    else if (uGrid.Column.Key == COLUMN_CUSTOMERCD)
                //    {
                //        if (this._checkCustomerFlg == false)
                //        {
                //            this.uGrid_SumCustSt.ActiveCell = uGrid;
                //            this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                //            return;
                //        }
                //    }
                //}

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
                                this.Cancel_Button.Focus();
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
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Date	   : 2008/10/29</br>
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
        /// BeforeEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
            _beforeCellText = string.Empty;
            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }
            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
            // �O��l�ޔ�
            _beforeCellText = StrObjectToString( uGrid.ActiveCell.Value );
            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

            int custRateGroup = int.Parse((string)uGrid.ActiveCell.Value);

            // �[���l�߉���
            uGrid.ActiveCell.Value = custRateGroup.ToString();
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// <br>Update Note: 2014/02/25  ���ߋ�</br>
        /// <br>�Ǘ��ԍ�   : 10970685-00</br>
        /// <br>           : �������Ӑ�A�������Ӑ�Ɏq�̓��Ӑ����͂ł���悤�ɂ���B</br>
        /// </remarks>
        private void uGrid_SumCustSt_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            switch (uGrid.ActiveCell.Column.Key)
            {
                case COLUMN_DEMANDADDUPSECCD:
                    {
                        this._checkSectionFlg = true;

                        // �[���l��
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        // ���_�R�[�h�擾
                        string sectionCode = StrObjectToString(uGrid.ActiveCell.Value);

                        if (sectionCode == "")
                        {
                            if (StrObjectToString(uGrid.ActiveCell.Tag) != "")
                            {
                                // �s�N���A
                                ClearRow(uGrid_SumCustSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            // �O����͂���ŁA���ύX���ꂽ�ꍇ
                            if ( !string.IsNullOrEmpty( _beforeCellText ) && _beforeCellText != sectionCode )
                            {
                                // �������Ӑ�N���A
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = "";
                            }
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<


                            bool bStatus = CheckSectionCode(sectionCode);
                            if (!bStatus)
                            {
                                this._checkSectionFlg = false;
                                return;
                            }

                            // ���_���擾
                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName(sectionCode);

                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sectionCode;

                            if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s�ǉ�
                                CreateNewRow(ref uGrid);
                            }
                        }

                        break;
                    }
                case COLUMN_CUSTOMERCD:
                    {
                        this._checkCustomerFlg = true;
                        
                        // �[���l��
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        int customerCode = StrObjectToInt(uGrid.ActiveCell.Value);

                        if (customerCode == 0)
                        {
                            if (StrObjectToInt(uGrid.ActiveCell.Tag) != 0)
                            {
                                // �s�N���A
                                ClearRow(uGrid_SumCustSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            bool bStatus = CheckCustomerCode(customerCode, uGrid.ActiveCell.Row.Index);
                            if (!bStatus)
                            {
                                this._checkCustomerFlg = false;
                                return;
                            }

                            // ���Ӑ於�擾
                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = GetCustomerName(customerCode);

                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = customerCode.ToString("00000000");

                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            if ( _beforeCellText != customerCode.ToString( "00000000" ) )
                            {
                                string sectionCode = string.Empty;

                                // �������_�R�[�h�擾
                                CustomerInfo customerInfo;
                                GetCustomerInfo( customerCode, out customerInfo );
                                if ( customerInfo != null )
                                {
                                    // sectionCode = customerInfo.ClaimSectionCode.Trim();  // DEL ���ߋ� 2014/02/25

                                    // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                                    if (_opt_KonMan == (int)Option.ON)
                                    {
                                        if (customerInfo.CustomerCode != customerInfo.ClaimCode)
                                        {
                                            sectionCode = customerInfo.MngSectionCode.Trim();
                                        }
                                        else
                                        {
                                            sectionCode = customerInfo.ClaimSectionCode.Trim();
                                        }
                                    }
                                    else
                                    {
                                        sectionCode = customerInfo.ClaimSectionCode.Trim();
                                    }
                                    // --- ADD ���ߋ� 2014/02/25 ----------<<<<<
                                }

                                string inputSectionCode = StrObjectToString( uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value );
                                if ( string.IsNullOrEmpty( inputSectionCode ) )
                                {
                                    // ���_�����͂Ȃ�ΐ������_�Z�b�g
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value = sectionCode;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Tag = sectionCode;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName( sectionCode );
                                }
                                else if (sectionCode != inputSectionCode)
                                {
                                    // --- DEL ���ߋ� 2014/02/25 ---------->>>>>
                                    // ���_���͍ς݂œ��Ӑ�}�X�^�̐������_�ƈقȂ�Ȃ�΁A�G���[�\��(���Ӑ���G���[��������)
                                    //ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                    //               "�q���Ӑ�͓o�^�ł��܂���B",
                                    //               -1,
                                    //               MessageBoxButtons.OK,
                                    //               MessageBoxDefaultButton.Button1);
                                    // --- DEL ���ߋ� 2014/02/25 ----------<<<<<


                                    // --- ADD ���ߋ� 2014/02/25 ---------->>>>>
                                    if (_opt_KonMan == (int)Option.ON)
                                    {
                                        if (customerInfo.CustomerCode == customerInfo.ClaimCode)
                                        {
                                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                           "���͂������_�͐�����̐������_�ł͂���܂���B",
                                                           -1,
                                                           MessageBoxButtons.OK,
                                                           MessageBoxDefaultButton.Button1);
                                        }
                                        else
                                        {
                                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                           "���͂������_�͓��Ӑ�̊Ǘ����_�ł͂���܂���B",
                                                           -1,
                                                           MessageBoxButtons.OK,
                                                           MessageBoxDefaultButton.Button1);
                                        }
                                    }
                                    else
                                    {
                                        //���_���͍ς݂œ��Ӑ�}�X�^�̐������_�ƈقȂ�Ȃ�΁A�G���[�\��(���Ӑ���G���[��������)
                                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                       "�q���Ӑ�͓o�^�ł��܂���B",
                                                       -1,
                                                       MessageBoxButtons.OK,
                                                       MessageBoxDefaultButton.Button1);
                                    }
                                    // --- ADD ���ߋ� 2014/02/25 ----------<<<<<

                                    // ���Ӑ�N���A
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Value = string.Empty;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = string.Empty;
                                    uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = string.Empty;

                                    // �G���[���[�h
                                    this._checkCustomerFlg = false;
                                }
                            }
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                            if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s�ǉ�
                                CreateNewRow(ref uGrid);
                            }
                        }

                        break;
                    }
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

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

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;
                        
                        // �ҏW���[�h�I��
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if ((columnIndex == 1) && (this._checkSectionFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == 0)
                        {
                            // ���Ӑ�R�[�h�Ƀt�H�[�J�X
                            this.tNedit_CustomerCode.Focus();
                        }
                        else
                        {
                            uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        // �ҏW���[�h�I��
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if ((columnIndex == 1) && (this._checkSectionFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            // �ۑ��{�^���Ƀt�H�[�J�X
                            this.Ok_Button.Focus();
                        }
                        else
                        {
                            uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                // �ҏW���[�h�I��
                                uGrid.PerformAction(UltraGridAction.ExitEditMode);

                                if ((columnIndex == 1) && (this._checkSectionFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }

                                if ((columnIndex == 1) && (rowIndex == 0))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        else
                        {
                            uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            e.Handled = true;
                        }
                        return;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                // �ҏW���[�h�I��
                                uGrid.PerformAction(UltraGridAction.ExitEditMode);

                                if ((columnIndex == 1) && (this._checkSectionFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if ((columnIndex == 4) && (this._checkCustomerFlg == false))
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }

                                uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }
                        }
                        else
                        {
                            uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            e.Handled = true;
                        }
                        return;
                    }
                case Keys.Space:
                    {
                        e.Handled = true;

                        uGrid_SumCustSt_ClickCellButton(uGrid, new CellEventArgs(uGrid.ActiveCell));
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_Leave(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            uGrid.ActiveCell = null;
            uGrid.ActiveRow = null;
        }

        /// <summary>
        /// ClickCellButton �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void uGrid_SumCustSt_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int status;

            switch (e.Cell.Column.Key)
            {
                case COLUMN_SECTIONGUIDE:   // ���_�K�C�h�{�^��
                    {
                        // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                        // �K�C�h�O�̒l��ޔ�
                        string beforeSectionCode = StrObjectToString( uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value );
                        // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                        SecInfoSet secInfoSet;

                        status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                        if (status == 0)
                        {
                            // ���_�R�[�h
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Value = secInfoSet.SectionCode.Trim();
                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECCD].Tag = secInfoSet.SectionCode.Trim();
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<
                            // ���_��
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_DEMANDADDUPSECNM].Value = GetSectionName(secInfoSet.SectionCode.Trim());

                            // --- ADD m.suzuki 2010/03/12 ---------->>>>>
                            // �O����͂���ŁA���ύX���ꂽ�ꍇ
                            if ( !string.IsNullOrEmpty( beforeSectionCode ) && beforeSectionCode != secInfoSet.SectionCode.Trim() )
                            {
                                // �������Ӑ�N���A
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERNM].Value = "";
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_CUSTOMERCD].Tag = "";
                            }
                            // --- ADD m.suzuki 2010/03/12 ----------<<<<<

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s��ǉ�
                                CreateNewRow(ref uGrid);
                            }

                            // �t�H�[�J�X�ݒ�
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_CUSTOMERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case COLUMN_CUSTOMERGUIDE:  // ���Ӑ�K�C�h�{�^��
                    {
                        this._cusotmerGuideSelected = false;
                        this._gridCustomerGuideFlg = true;

                        // ���Ӑ�K�C�h
                        PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                        customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                        customerSearchForm.ShowDialog(this);

                        // �t�H�[�J�X�ݒ�
                        if (this._cusotmerGuideSelected == true)
                        {
                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s��ǉ�
                                CreateNewRow(ref uGrid);
                            }

                            uGrid.Rows[e.Cell.Row.Index + 1].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Timer_Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
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
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.Cancel_Button)
            {
                Cancel_Button_Click(this.Cancel_Button, new EventArgs());
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();
                            this._sumCustTotalDay = 0;
                            break;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        bool bStatus = CheckSumClaimCustCode(customerCode);
                        if (!bStatus)
                        {
                            e.NextCtrl = e.PrevCtrl;
                            this._sumCustTotalDay = 0;
                            this.tNedit_CustomerCode.SelectAll();
                            return;
                        }

                        // �����擾
                        this._sumCustTotalDay = this._customerSearchRetDic[customerCode].TotalDay;

                        // ���Ӑ於�擾
                        this.tEdit_CustomerName.DataText = this._customerSearchRetDic[customerCode].Snm.Trim();

                        if (this.tEdit_CustomerName.DataText.Trim() != "")
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                                    this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }

                        break;
                    }
                case "uGrid_SumCustSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_SumCustSt, ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                SetBeforeFocus(this.uGrid_SumCustSt, ref e);
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "uGrid_SumCustSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumCustSt.Rows[0].Cells[COLUMN_DEMANDADDUPSECCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumCustSt.Rows[this.uGrid_SumCustSt.Rows.Count - 1].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumCustSt.Rows[this.uGrid_SumCustSt.Rows.Count - 1].Cells[COLUMN_CUSTOMERCD].Activate();
                                this.uGrid_SumCustSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        break;
                    }
            }
        }
        #endregion �� Control Events
    }
}