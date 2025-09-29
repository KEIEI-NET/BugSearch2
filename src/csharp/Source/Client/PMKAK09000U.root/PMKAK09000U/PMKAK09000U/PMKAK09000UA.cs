//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d����}�X�^(�����ݒ�)
// �v���O�����T�v   : �d����}�X�^(�����ݒ�)��UI�ݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�֓� �a�G
// �� �� ��  2012/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d����}�X�^(�����ݒ�)UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �d����}�X�^(�����ݒ�)��UI�ݒ���s���܂��B</br>
    /// <br>Programmer	: FSI�֓� �a�G</br>
    /// <br>Date        : 2012/08/27</br>
    /// </remarks>
    public partial class PMKAK09000UA : Form, IMasterMaintenanceArrayType
    {
        #region �� Constants

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKAK09000U";

        // �e�[�u������
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        //// �f�[�^�r���[�^�C�g��
        private const string GRIDTITLE_SUMSUPPLIER = "�����d����";
        private const string GRIDTITLE_SUPPLIER = "�d����";

        //// �f�[�^�r���[�\���p
        private const string VIEW_SUMSECTIONCODE = "�������_�R�[�h";
        private const string VIEW_SUMSECTIONNAME = "�������_����";
        private const string VIEW_SUMSUPPLIERCODE = "�����d����R�[�h";
        private const string VIEW_SUMSUPPLIERNAME = "�����d���於��";

        private const string VIEW_DELETEDATE = "�폜��";
        private const string VIEW_SECTIONCODE = "���_�R�[�h";
        private const string VIEW_SECTIONNAME = "���_����";
        private const string VIEW_SUPPLIERCODE = "�d����R�[�h";
        private const string VIEW_SUPPLIERNAME = "�d���於��";

        // �O���b�h��^�C�g��
        private const string COLUMN_NO = "No";
        private const string COLUMN_SECTIONCODE = "SectionCode";
        private const string COLUMN_SECTIONNAME = "DemandAddUpSecNm";
        private const string COLUMN_SECTIONGUIDE = "SectionGuide";
        private const string COLUMN_SUPPLIERCD = "SupplierCd";
        private const string COLUMN_SUPPLIERNM = "SupplierNm";
        private const string COLUMN_SUPPLIERGUIDE = "SupplierGuide";

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

        private SumSuppStAcs _sumSuppStAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        private Dictionary<string , SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;

        private SupplierAcs _supplierAcs;

        private ControlScreenSkin _controlScreenSkin;       // ��ʃf�U�C���ύX�N���X
        private List<SumSuppSt> _sumSuppStListClone;        // �d����}�X�^(�����ݒ�)���X�gClone

        private Dictionary<string, List<int>> _mainList;    // ���C���O���b�h(�����ɕ\��)�������̂̃��X�g
        private List<SumSuppSt> _detailList;

        private string _sumSectionCode;                     // �������_�R�[�h
        private int    _sumSupplierCode;                    // �����d����R�[�h
        private int    _sumSuppTotalDay;                    // �����d����̒���            

        private bool _checkSectionFlg;
        private bool _checkSupplierFlg;
        
        // �ۑ����������ǂ����̃t���O(PU��d�\���Ή�)
        private bool _isSaveProcess;

        // �Z���ύX�O�lbackup
        private string _beforeCellText;

        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// �d����}�X�^(�����ݒ�)�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)UI�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        public PMKAK09000UA()
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

            // �e�}�X�^�ւ̃A�N�Z�X�N���X
            this._sumSuppStAcs = new SumSuppStAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadSupplier();

            // DataSet����\�z
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            this._isSaveProcess  = false;
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // ���C��
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, string.Empty, Color.Red));
            main.Add(VIEW_SUMSECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            main.Add(VIEW_SUMSECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            main.Add(VIEW_SUMSUPPLIERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            main.Add(VIEW_SUMSUPPLIERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            
            //==============================
            // �ڍ�
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, string.Empty, Color.Red));
            detail.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            detail.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            detail.Add(VIEW_SUPPLIERCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, string.Empty, Color.Black));
            detail.Add(VIEW_SUPPLIERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));

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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { true, false };
            return logicalDeleteButton;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SUMSUPPLIER, GRIDTITLE_SUPPLIER };
            return gridTitle;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // ���C���f�[�^���I������Ă���ꍇ
            if (this._mainDataIndex > -1)
            {
                // �I������Ă��郁�C���e�[�u���̋��_�R�[�h�E�d����R�[�h���擾
                string sumSecCode = this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSECTIONCODE].ToString().Trim();
                int sumSuppCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSUPPLIERCODE]);

                int status = -1;
                try
                {
                    // ���������i�_���폜�܂ށj
                    status = this._sumSuppStAcs.Search(out retList, this._enterpriseCode, sumSuppCode, sumSecCode, ConstantManagement.LogicalMode.GetDataAll);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                // �擾�����N���X���f�[�^�Z�b�g�֓W�J����
                                int index = 0;
                                foreach (SumSuppSt sumSuppSt in retList)
                                {
                                    // DataSet�W�J����
                                    DetailToDataSet(sumSuppSt, index);
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
                }
                catch
                {

                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                    "DetailsDataSearch",
                    "�ǂݍ��݂Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                    totalCount = 0;
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<string, List<int>>();
            this._detailList = new List<SumSuppSt>();

            ArrayList retList;

            int index = 0;

            int status = this._sumSuppStAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �o�b�t�@�ێ�
                        foreach (SumSuppSt sumSuppSt in retList)
                        {
                            // �������_�R�[�h���f�B�N�V���i���̃L�[�Ɋ܂܂�Ă邩
                            if (this._mainList.ContainsKey(sumSuppSt.SumSectionCd.Trim()))
                            {
                                if (!this._mainList[sumSuppSt.SumSectionCd.Trim()].Contains(sumSuppSt.SumSupplierCd))
                                {
                                    // �����d����R�[�h���܂܂�Ă��Ȃ��ꍇ
                                    // �������_�R�[�h�ɑ΂��鑍���d����R�[�h��ǉ�
                                    this._mainList[sumSuppSt.SumSectionCd.Trim()].Add(sumSuppSt.SumSupplierCd);
                                    MainToDataSet(sumSuppSt, index);
                                    index++;
                                }
                            }
                            else
                            {
                                // �������_�R�[�h���V�����R�[�h
                                List<int> templist = new List<int>();
                                templist.Add(sumSuppSt.SumSupplierCd);
                                this._mainList.Add(sumSuppSt.SumSectionCd.Trim(), templist);
                                MainToDataSet(sumSuppSt, index);
                                index++;
                            }

                            // ���_�R�[�h��Trim���Ă���detail���X�g��Add
                            sumSuppSt.SumSectionCd = sumSuppSt.SumSectionCd.Trim();
                            sumSuppSt.SectionCode  = sumSuppSt.SectionCode.Trim();
                            this._detailList.Add(sumSuppSt);
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

            totalCount = index;

            return 0;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            int status = -1;
            ArrayList retArray;

            try
            {
                status = this._secInfoSetAcs.Search(out retArray, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet retSecInfo in retArray)
                    {
                        this._secInfoSetDic.Add(retSecInfo.SectionCode.Trim(), retSecInfo);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideSnm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// �d������擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������擾���A�L���b�V���ɕێ����܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            int status = -1;
            try
            {
                ArrayList retArray;

                status = this._supplierAcs.Search(out retArray, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier retSupplierInfo in retArray)
                    {
                        this._supplierDic.Add(retSupplierInfo.SupplierCd, retSupplierInfo);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }

            return;

        }

        /// <summary>
        /// �d���於�擾����
        /// </summary>
        /// <param name="suppliercode">�d����R�[�h</param>
        /// <returns>�d���旪��</returns>
        /// <remarks>
        /// <br>Note       : �d���旪�̂��擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string GetSupplierSnm(int suppliercode)
        {
            string supplierSnm = string.Empty;

            if (this._supplierDic.ContainsKey(suppliercode))
            {
                supplierSnm = this._supplierDic[suppliercode].SupplierSnm.Trim();
            }

            return supplierSnm;
        }

        /// <summary>
        /// �����擾����
        /// </summary>
        /// <param name="suppliercode">�d����R�[�h</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �������擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private int GetTotalDay(int suppliercode)
        {
            int totalDay = 0;

            if (this._supplierDic.ContainsKey(suppliercode))
            {
                totalDay = this._supplierDic[suppliercode].PaymentTotalDay;
            }

            return totalDay;
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ScreenClear()
        {
            // �������_
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            // �����d����
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierSnm.Clear();

            // �O���b�h
            for (int rowIndex = 0; rowIndex < this.uGrid_SumSuppSt.Rows.Count; rowIndex++)
            {
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activation = Activation.AllowEdit;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activation = Activation.AllowEdit;
            }

            this.uGrid_SumSuppSt.ActiveCell = null;
            this.uGrid_SumSuppSt.ActiveRow = null;
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadSupplier();

            // �R���g���[���T�C�Y�ݒ�
            this.tEdit_SectionCode.Size = new Size(35, 24);
            this.tEdit_SectionName.Size = new Size(179, 24);

            this.tNedit_SupplierCd.Size = new Size(60, 24);
            this.tEdit_SupplierSnm.Size = new Size(179, 24);

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
            this.SumSectionGuide_Button.ImageList = imageList16;
            this.SumSectionGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.SumSuppGuide_Button.ImageList = imageList16;
            this.SumSuppGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // �O���b�h�\�z
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            dataTable.Columns.Add(COLUMN_SECTIONCODE, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONNAME, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONGUIDE, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERCD, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERNM, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERGUIDE, typeof(string));

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_NO] = rowIndex + 1;
                dataRow[COLUMN_SECTIONCODE] = string.Empty;
                dataRow[COLUMN_SECTIONNAME] = string.Empty;
                dataRow[COLUMN_SECTIONGUIDE] = string.Empty;
                dataRow[COLUMN_SUPPLIERCD] = string.Empty;
                dataRow[COLUMN_SUPPLIERNM] = string.Empty;
                dataRow[COLUMN_SUPPLIERGUIDE] = string.Empty;

                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_SumSuppSt.DataSource = dataTable;

            for (int rowIndex = 0; rowIndex < 25; rowIndex++)
            {
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Tag = string.Empty;
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
            }

            ColumnsCollection columns = this.uGrid_SumSuppSt.DisplayLayout.Bands[0].Columns;

            // �w�b�_�[�L���v�V����
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_SECTIONCODE].Header.Caption = "���_";
            columns[COLUMN_SECTIONNAME].Header.Caption = "���_��";
            columns[COLUMN_SECTIONGUIDE].Header.Caption = string.Empty;
            columns[COLUMN_SUPPLIERCD].Header.Caption = "�d����";
            columns[COLUMN_SUPPLIERNM].Header.Caption = "�d���於";
            columns[COLUMN_SUPPLIERGUIDE].Header.Caption = string.Empty;
            // TextHAlign
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SECTIONCODE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_SUPPLIERCD].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SUPPLIERNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SUPPLIERGUIDE].CellAppearance.TextHAlign = HAlign.Center;
            // TextVAlign
            columns[COLUMN_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONCODE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONNAME].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERCD].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERNM].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
            // ���͐���
            columns[COLUMN_NO].CellActivation = Activation.Disabled;
            columns[COLUMN_SECTIONCODE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_SECTIONNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_SECTIONGUIDE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_SUPPLIERCD].CellActivation = Activation.AllowEdit;
            columns[COLUMN_SUPPLIERNM].CellActivation = Activation.Disabled;
            columns[COLUMN_SUPPLIERGUIDE].CellActivation = Activation.AllowEdit;
            // ��
            columns[COLUMN_NO].Width = 45;
            columns[COLUMN_SECTIONCODE].Width = 90;
            columns[COLUMN_SECTIONNAME].Width = 175;
            columns[COLUMN_SECTIONGUIDE].Width = 24;
            columns[COLUMN_SUPPLIERCD].Width = 100;
            columns[COLUMN_SUPPLIERNM].Width = 175;
            columns[COLUMN_SUPPLIERGUIDE].Width = 24;
            // �Z��Color
            columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
            columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_SECTIONNAME].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_SECTIONNAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_SUPPLIERNM].CellAppearance.BackColor = Color.Gainsboro;
            columns[COLUMN_SUPPLIERNM].CellAppearance.BackColorDisabled = Color.Gainsboro;
            columns[COLUMN_SECTIONCODE].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            columns[COLUMN_SUPPLIERCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            // MaxLength
            columns[COLUMN_SECTIONCODE].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_SECTIONCODE);
            columns[COLUMN_SUPPLIERCD].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_SUPPLIERCD);
            columns[COLUMN_SECTIONNAME].MaxLength = 10;
            columns[COLUMN_SUPPLIERNM].MaxLength = 10;
            // �Z���{�^��
            columns[COLUMN_SECTIONGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_SECTIONGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_SECTIONGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_SECTIONGUIDE].CellAppearance.Cursor = Cursors.Hand;
            columns[COLUMN_SUPPLIERGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_SUPPLIERGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_SUPPLIERGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[COLUMN_SUPPLIERGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLIERGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_SUPPLIERGUIDE].CellAppearance.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// DataSet�W�J����(���C���e�[�u��)
        /// </summary>
        /// <param name="sumSuppSt">�d���摍���ݒ�R�[�h</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void MainToDataSet(SumSuppSt sumSuppSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // �폜��
            if (sumSuppSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = sumSuppSt.UpdateDateTimeJpInFormal;
            }

            // �������_�R�[�h
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSECTIONCODE] = sumSuppSt.SumSectionCd;
            // �������_����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSECTIONNAME] = GetSectionName(sumSuppSt.SumSectionCd);
            // �����d����R�[�h
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSUPPLIERCODE] = sumSuppSt.SumSupplierCd.ToString("000000");
            // �����d���於��
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SUMSUPPLIERNAME] = GetSupplierSnm(sumSuppSt.SumSupplierCd);

        }

        /// <summary>
        /// DataSet�W�J����(�ڍ׃e�[�u��)
        /// </summary>
        /// <param name="sumSuppSt">�d����}�X�^(�����ݒ�)</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void DetailToDataSet(SumSuppSt sumSuppSt, int index)
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
            if (sumSuppSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = sumSuppSt.UpdateDateTimeJpInFormal;
            }

            // ���_
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SECTIONCODE] = sumSuppSt.SectionCode.Trim();
            // ���_��
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SECTIONNAME] = GetSectionName(sumSuppSt.SectionCode.Trim());
            // �d����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SUPPLIERCODE] = sumSuppSt.SupplierCode.ToString("000000");
            // �d���於
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SUPPLIERNAME] = GetSupplierSnm(sumSuppSt.SupplierCode);
        }

        /// <summary>
        /// DataSet����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet������\�z���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // ���C��
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSECTIONCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSECTIONNAME, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSUPPLIERCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SUMSUPPLIERNAME, typeof(string));
            
            //==============================
            // �ڍ�
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));
            detailTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));
            detailTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));
            detailTable.Columns.Add(VIEW_SUPPLIERCODE, typeof(string));
            detailTable.Columns.Add(VIEW_SUPPLIERNAME, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.uGrid_SumSuppSt.Rows.Count > 25)
            {
                for (int index = this.uGrid_SumSuppSt.Rows.Count - 1; index >= 25; index--)
                {
                    this.uGrid_SumSuppSt.Rows[index].Delete(false);
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
                this._sumSuppStListClone = new List<SumSuppSt>();

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCode.Focus();

                // ��������������
                this._sumSectionCode = string.Empty;
                this._sumSupplierCode = 0;
                this._sumSuppTotalDay = 0;
            }
            else
            {
                //------------------------------
                // �X�V���[�hor�폜���[�h
                //------------------------------
                // DataSet���瑍�������擾
                this._sumSectionCode  = this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSECTIONCODE].ToString().Trim();
                this._sumSupplierCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSUPPLIERCODE]);
                this._sumSuppTotalDay = GetTotalDay(this._sumSupplierCode);

                // �������_�R�[�h�Ƒ����d����R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
                List<SumSuppSt> sumSuppStList = SearchDetailListFromSumCode(this._sumSectionCode, this._sumSupplierCode);

                this._sumSuppStListClone = new List<SumSuppSt>();

                if (sumSuppStList.Count == 0)
                {
                    // �����ɗ��邱�Ƃ͂Ȃ��͂�(�e�����݂��Ďq��0���̏ꍇ)
                    SumSuppSt sumSuppSt = new SumSuppSt();
                    sumSuppSt.SumSectionCd = this._sumSectionCode;
                    sumSuppSt.SumSupplierCd = this._sumSupplierCode;
                    sumSuppStList.Add(sumSuppSt);
                }
                else
                {
                    foreach (SumSuppSt sumSuppSt in sumSuppStList)
                    {
                        this._sumSuppStListClone.Add(sumSuppSt.Clone());
                    }
                }

                // ��ʓW�J����
                SumSuppStListToScreen(sumSuppStList);

                if (sumSuppStList[0].LogicalDeleteCode == 0)
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
                    this.uGrid_SumSuppSt.Focus();
                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    {
                        // �V�K���[�h
                        this.tEdit_SectionCode.Enabled = true;
                        this.SumSectionGuide_Button.Enabled = true;
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SumSuppGuide_Button.Enabled = true;

                        this.uGrid_SumSuppSt.Enabled = true;
                        break;
                    }
                case UPDATE_MODE:
                    {
                        // �X�V���[�h
                        this.tEdit_SectionCode.Enabled = false;
                        this.SumSectionGuide_Button.Enabled = false;
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SumSuppGuide_Button.Enabled = false;

                        this.uGrid_SumSuppSt.Enabled = true;
                        break;
                    }
                case DELETE_MODE:
                    {
                        // �폜���[�h
                        this.tEdit_SectionCode.Enabled = false;
                        this.SumSectionGuide_Button.Enabled = false;
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SumSuppGuide_Button.Enabled = false;

                        this.uGrid_SumSuppSt.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// �d����}�X�^(�����ݒ�)���X�g��ʓW�J����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void SumSuppStListToScreen(List<SumSuppSt> sumSuppStList)
        {
            int rowIndex = 0;

            // �������_�E�����d����͓����l�������Ă���̂Ń��[�v�O�Ɋi�[
            this.tEdit_SectionCode.Value = sumSuppStList[0].SumSectionCd.Trim();
            this.tEdit_SectionName.DataText = GetSectionName(sumSuppStList[0].SumSectionCd.Trim());
            this.tNedit_SupplierCd.Value = sumSuppStList[0].SumSupplierCd.ToString("000000");
            this.tEdit_SupplierSnm.DataText = GetSupplierSnm(sumSuppStList[0].SumSupplierCd);

            foreach (SumSuppSt sumSuppSt in sumSuppStList)
            {
                if (rowIndex == this.uGrid_SumSuppSt.Rows.Count)
                {
                    // �O���b�h�s�ǉ�
                    CreateNewRow(ref this.uGrid_SumSuppSt);
                }

                // ���_�R�[�h
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value = sumSuppSt.SectionCode.Trim();
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Tag = sumSuppSt.SectionCode.Trim();
                // ���_��
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(sumSuppSt.SectionCode.Trim());
                // �d����
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value = sumSuppSt.SupplierCode.ToString("000000");
                // �d���於
                this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = GetSupplierSnm(sumSuppSt.SupplierCode);

                rowIndex++;
            }
        }

        /// <summary>
        /// �ۑ��f�[�^�擾����
        /// </summary>
        /// <returns>�ۑ��f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ��f�[�^���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private List<SumSuppSt> GetSaveSumSuppStListFromScreen()
        {
            List<SumSuppSt> sumSuppStList = new List<SumSuppSt>();

            for (int rowIndex = 0; rowIndex < this.uGrid_SumSuppSt.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.uGrid_SumSuppSt.Rows[rowIndex].Cells;

                // ���_�R�[�h�E�d����R�[�h���󔒂̏ꍇ
                if ((CellTextToString(cells[COLUMN_SECTIONCODE].Text) == string.Empty) &&
                    (CellTextToInt(cells[COLUMN_SUPPLIERCD].Text) == 0))
                {
                    continue;
                }
                else
                {
                    SumSuppSt SumSuppSt = new SumSuppSt();

                    // ��ƃR�[�h
                    SumSuppSt.EnterpriseCode = this._enterpriseCode;
                    // �������_�R�[�h
                    SumSuppSt.SumSectionCd = this._sumSectionCode;
                    // �����d����R�[�h
                    SumSuppSt.SumSupplierCd = this._sumSupplierCode;
                    // ���_�R�[�h
                    SumSuppSt.SectionCode = CellTextToString(cells[COLUMN_SECTIONCODE].Text);
                    // �d����R�[�h
                    SumSuppSt.SupplierCode = CellTextToInt(cells[COLUMN_SUPPLIERCD].Text);

                    sumSuppStList.Add(SumSuppSt);
                }
            }

            return sumSuppStList;
        }

        /// <summary>
        /// �X�V�p���X�g�擾����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="deleteList">�폜���X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ����X�g�E�폜���X�g���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // �ۑ��p�f�[�^�擾
            List<SumSuppSt> saveSumSuppStList = GetSaveSumSuppStListFromScreen();

            // �폜���X�g�쐬
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                deleteList.Add(sumSuppSt.Clone());
            }

            // �ۑ����X�g�쐬
            foreach (SumSuppSt sumSuppSt in saveSumSuppStList)
            {
                saveList.Add(sumSuppSt);
            }
        }

        /// <summary>
        /// Key�擾����
        /// </summary>
        /// <param name="sumSuppSt">�d����}�X�^(�����ݒ�)�}�X�^</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)����Key���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string GetKey(SumSuppSt sumSuppSt)
        {
            string key = string.Empty;

            // �������_�R�[�h(2��)�{�����d����R�[�h(6��)�{���_�R�[�h(2��)�{�d����R�[�h(6��)
            key = sumSuppSt.SumSectionCd.Trim() +
                  sumSuppSt.SumSupplierCd.ToString("000000") +
                  sumSuppSt.SectionCode.Trim() +
                  sumSuppSt.SupplierCode.ToString("000000");

            return key;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private bool SaveProc()
        {
            this._isSaveProcess = true;

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
                status = this._sumSuppStAcs.Delete(deleteList);
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
            status = this._sumSuppStAcs.Write(ref saveList);
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

                        this.tEdit_SectionCode.Focus();

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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
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
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                deleteList.Add(sumSuppSt.Clone());
            }

            // �폜����
            int status = this._sumSuppStAcs.Delete(deleteList);
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSet���瑍�����_�E�d����R�[�h���擾
            string sumSecCode  = ((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSECTIONCODE]).Trim();
            int    sumSuppCode = int.Parse((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SUMSUPPLIERCODE]);

            // �������_�R�[�h�Ƒ����d����R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
            List<SumSuppSt> sumSuppStList = SearchDetailListFromSumCode(sumSecCode, sumSuppCode);

            if (sumSuppStList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�폜�Ώۃf�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }
            else if (sumSuppStList[0].LogicalDeleteCode != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂��B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (SumSuppSt sumSuppSt in sumSuppStList)
            {
                logicalList.Add(sumSuppSt.Clone());
            }

            // �_���폜����
            int status = this._sumSuppStAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        string key = string.Empty;

                        // mainDataSet�ɓW�J
                        SumSuppSt _sumSuppSt = logicalList[0] as SumSuppSt;
                        int mainListIndex = FindMainListIndex(_sumSuppSt);

                        MainToDataSet(_sumSuppSt, mainListIndex);

                        // detailList�ɓW�J
                        foreach (SumSuppSt sumSuppSt in logicalList)
                        {
                            key = GetKey(sumSuppSt);
                            int listIndex = this._detailList.FindIndex(delegate(SumSuppSt x)
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
                                this._detailList[listIndex] = sumSuppSt.Clone();
                            }
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
        /// �����ݒ��񂩂�MainList��Index���擾���܂�
        /// </summary>
        /// <param name="sumSuppSt">�d����}�X�^�i�����ݒ�j</param>
        /// <returns>MainList��Index</returns>
        /// <remarks>
        /// <br>Note        : �����ݒ��񂩂�MainList��Index���擾���܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private int FindMainListIndex(SumSuppSt sumSuppSt)
        {
            int index = 0;

            // mainList����sumSuppSt�ɍ��v���鑍������������
            foreach (KeyValuePair<string, List<int>> mainListInfo in this._mainList)
            {
                foreach (int sumSuppCode in mainListInfo.Value)
                {
                    if (mainListInfo.Key.Trim() == sumSuppSt.SumSectionCd.Trim() &&
                        sumSuppCode == sumSuppSt.SumSupplierCd)
                    {
                        return index;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// �����ݒ��񂩂�MainList��Index���擾���܂�(���b�p�[)
        /// </summary>
        /// <param name="sumSecCode">�������_�R�[�h</param>
        /// <param name="sumSuppCode">�����d����R�[�h</param>
        /// <returns>MainList��Index</returns>
        /// <remarks>
        /// <br>Note        : �����ݒ��񂩂�MainList��Index���擾���܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private int FindMainListIndex(string sumSecCode, int sumSuppCode)
        {
            SumSuppSt sumSuppSt = new SumSuppSt();

            sumSuppSt.SumSectionCd  = sumSecCode.Trim();
            sumSuppSt.SumSupplierCd = sumSuppCode;

            return FindMainListIndex(sumSuppSt);
        }

        /// <summary>
        /// �����ݒ���ɕR�Â�DetailList���擾���܂�
        /// </summary>
        /// <param name="sumSecCode">�������_�R�[�h</param>
        /// <param name="sumSuppCode">�����d����R�[�h</param>
        /// <returns>�������_�E�����d����̎qSumSuppSt��List</returns>
        /// <remarks>
        /// <br>Note        : �����ݒ���ɕR�Â�DetailList���擾���܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private List<SumSuppSt> SearchDetailListFromSumCode(string sumSecCode, int sumSuppCode)
        {
            List<SumSuppSt> sumSuppStList = this._detailList.FindAll(delegate(SumSuppSt x)
            {
                if (x.SumSectionCd == sumSecCode &&
                    x.SumSupplierCd == sumSuppCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            return sumSuppStList;
        }

        /// <summary>
        /// �q���ɕR�Â�DetailList���擾���܂�
        /// </summary>
        /// <param name="SecCode">�q���_�R�[�h</param>
        /// <param name="SuppCode">�q�d����R�[�h</param>
        /// <returns>�q���_�E�q�d�����SumSuppSt��List</returns>
        /// <remarks>
        /// <br>Note        : �q�̐ݒ���ɕR�Â�DetailList���擾���܂��B</br>
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private List<SumSuppSt> SearchDetailListFromChildCode(string SecCode, int SuppCode)
        {
            List<SumSuppSt> sumSuppStList = this._detailList.FindAll(delegate(SumSuppSt x)
            {
                if (x.SectionCode == SecCode &&
                    x.SupplierCode == SuppCode)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            return sumSuppStList;
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/8/27</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // �������X�g�擾
            ArrayList reviveList = new ArrayList();
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                reviveList.Add(sumSuppSt.Clone());
            }

            // ��������
            int status = this._sumSuppStAcs.Revival(ref reviveList);
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = string.Empty;
            bool errFlg = false;

            // �O���b�h���o�^�f�[�^�����邩�t���O
            bool inputFlg = false;

            // ��ʂ��瑍�����_�E�d����R�[�h�擾
            string sumSecCd = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSuppCd = this.tNedit_SupplierCd.GetInt();

            if (sumSecCd == "00") // �������_�R�[�h
            {
                errMsg = "�������_�R�[�h����͂��Ă��������B";
                errFlg = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (CheckSectionCode(sumSecCd) == false)
            {
                errMsg = "���_���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                errFlg = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (this.tEdit_SectionName.Text == string.Empty)
            {
                errMsg = "�������_�R�[�h����͂��Ă��������B";
                errFlg = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (sumSuppCd == 0) // �����d����R�[�h
            {
                errMsg = "�����d����R�[�h����͂��Ă��������B";
                errFlg = true;
                this.tNedit_SupplierCd.Focus();
            }
            else if (this._supplierDic.ContainsKey(sumSuppCd) == false)
            {
                errMsg = "�d����}�X�^�ɓo�^����Ă��܂���B";
                errFlg = true;
                this.tNedit_SupplierCd.Focus();
            }
            else // �������_�E�d������Ȃ�
            {
                for (int rowIndex = 0; rowIndex < this.uGrid_SumSuppSt.Rows.Count; rowIndex++)
                {
                    CellsCollection cells = this.uGrid_SumSuppSt.Rows[rowIndex].Cells;

                    // �`�F�b�N�s�̋��_�E�d����R�[�h�擾
                    string sectionCode = CellTextToString(cells[COLUMN_SECTIONCODE].Text);
                    int supplierCode = CellTextToInt(cells[COLUMN_SUPPLIERCD].Text);

                    if ((sectionCode == string.Empty) && (supplierCode == 0))
                    {
                        // ���ɋ󔒂̍s�̓`�F�b�N�Ȃ�
                        continue;
                    }
                    else if (sectionCode == string.Empty)
                    {
                        CheckError(rowIndex, COLUMN_SECTIONCODE);
                        errMsg = "���_�R�[�h����͂��Ă��������B";
                        errFlg = true;
                        break;
                    }
                    else if (CheckSectionCode(sectionCode) == false)
                    {
                        CheckError(rowIndex, COLUMN_SECTIONCODE);
                        errMsg = "���_���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                        errFlg = true;
                        break;
                    }
                    else if (supplierCode == 0)
                    {
                        CheckError(rowIndex, COLUMN_SUPPLIERCD);
                        errMsg = "�d����R�[�h����͂��Ă��������B";
                        errFlg = true;
                        break;
                    }
                    else if (CheckSupplierCode(supplierCode, rowIndex, ref errMsg) == false)
                    {
                        // �d����R�[�h�`�F�b�N
                        CheckError(rowIndex, COLUMN_SUPPLIERCD);
                        errFlg = true;
                        break;
                    }
                    else
                    {
                        // �G���[��
                        inputFlg = true; // ���̓f�[�^����ɃZ�b�g
                    }
                }
                if (!inputFlg && !errFlg)
                {
                    // 1�������͂���Ă��Ȃ������ꍇ
                    CheckError(0, COLUMN_SECTIONCODE);
                    errMsg = "���_�R�[�h�A�d����R�[�h�̓o�^������܂���B";
                    errFlg = true;
                }
            }

            if (errFlg)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               errMsg,
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                this._isSaveProcess = false;
                return true;
            }
        }

        /// <summary>
        /// �O���b�h���͏��G���[������
        /// </summary>
        /// <param name="index">�G���[�����s�ԍ�</param>
        /// <param name="columnName">�G���[������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h���͏��ɃG���[���������ꍇ�̏����B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void CheckError(int index, string columnName)
        {
            this.uGrid_SumSuppSt.AfterExitEditMode -= uGrid_SumSuppSt_AfterExitEditMode;
            this.uGrid_SumSuppSt.Focus();
            this.uGrid_SumSuppSt.Rows[index].Cells[columnName].Activate();
            this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
            this.uGrid_SumSuppSt.AfterExitEditMode += uGrid_SumSuppSt_AfterExitEditMode;
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓǍ����Ɖ�ʏI�����̃f�[�^���r���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // �V�K���[�h�ŋN�����ŏ�������͂����ꍇ
            if ((this._sumSuppStListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this._sumSectionCode != string.Empty &&
                    this._sumSupplierCode != 0)
                {
                    return (false);
                }
            }

            // �ۑ��f�[�^�擾
            List<SumSuppSt> saveSumSuppStList = new List<SumSuppSt>();
            try
            {
                saveSumSuppStList = GetSaveSumSuppStListFromScreen();
            }
            catch
            {
                return (false);
            }

            // ��ʓǍ����ƕۑ��f�[�^�̌������Ⴄ�ꍇ
            if (this._sumSuppStListClone.Count != saveSumSuppStList.Count)
            {
                return (false);
            }

            string key;
            bool sameFlg = false;
            foreach (SumSuppSt sumSuppSt in this._sumSuppStListClone)
            {
                // Key�擾
                key = GetKey(sumSuppSt);

                // ��ʓǍ����̃f�[�^�������ꍇ
                foreach (SumSuppSt saveSumSupp in saveSumSuppStList)
                {
                    string saveKey = GetKey(saveSumSupp);
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
        /// �d����R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="rowIndex">�O���b�h���s�ԍ�</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�Ƃ��ē��͂ł��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CheckSupplierCode(int supplierCode, int rowIndex, ref string errMsg)
        {
            // ���͂����d����R�[�h���}�X�^�ɑ��݂��邩
            if (!this._supplierDic.ContainsKey(supplierCode))
            {
                errMsg = "�d����}�X�^�ɓo�^����Ă��܂���B";
                return false;
            }

            // �����s�̋��_�R�[�h���擾
            string SectionCode = StrObjectToString(this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value);
            
            // �ҏW����ʂɓ����s�̃f�[�^�����݂��Ȃ���
            for (int index = 0; index < this.uGrid_SumSuppSt.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                // ���_�R�[�h�E�d����R�[�h�擾
                string _checkSecCode = StrObjectToString(this.uGrid_SumSuppSt.Rows[index].Cells[COLUMN_SECTIONCODE].Value);
                int _checkSuppCd = StrObjectToInt(this.uGrid_SumSuppSt.Rows[index].Cells[COLUMN_SUPPLIERCD].Value);

                if (SectionCode  == _checkSecCode &&
                    supplierCode == _checkSuppCd)
                {
                    errMsg = "���ɓo�^����Ă��܂��B";
                    return (false);
                }
            }

            // �����s�̋��_�R�[�h-���͂����d����R�[�h�̃y�A�����݂��Ă��Ȃ���
            // �������_�R�[�h�d������擾
            string sumSecCode = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSuppCode   = this.tNedit_SupplierCd.GetInt();
            this._sumSuppTotalDay = GetTotalDay(sumSuppCode);

            // �@�`�F�b�N���鋒�_-�d���悪�������_-�d����ƈ�v���Ă��邩�`�F�b�N
            if (!(sumSecCode == SectionCode && sumSuppCode == supplierCode))
            {
                // �e�Ɠ���Ŗ����ꍇ��
                // �A�`�F�b�N����l���q�̃f�[�^�ɑ��݂��邩�`�F�b�N
                List<SumSuppSt> sumSuppStList = SearchDetailListFromChildCode(SectionCode, supplierCode);

                if (sumSuppStList.Count > 1)
                {
                    // 2���ȏ㑶�݂��邱�Ƃ͂��蓾�Ȃ����ꉞ�G���[�n���h�����O����
                    errMsg = "���ɓo�^����Ă��܂��B";
                    return (false);
                }
                else if (sumSuppStList.Count == 1)
                {
                    // �q�̃f�[�^�ɑ��݂���
                    // �BHIT�����f�[�^�̐e�ƃ`�F�b�N�l�̐e���r
                    if ( !(sumSuppStList[0].SumSectionCd == sumSecCode &&
                        sumSuppStList[0].SumSupplierCd == sumSuppCode))
                    {
                        // ��v���Ȃ���Εʂ̎q�Ƃ��ēo�^����Ă���
                        errMsg = "���ɓo�^����Ă��܂��B";
                        return (false);
                    }
                }
                else
                {
                    // �q�ɂ͓����f�[�^���� �e������
                    int mainListIndex = FindMainListIndex(SectionCode, supplierCode);

                    if (mainListIndex != -1)
                    {
                        // �e�Ƃ��ēo�^����Ă���
                        errMsg = "���ɓo�^����Ă��܂��B";
                        return (false);
                    }
                }
            }

            // �d��������������d��������ƈ�v���Ă��邩
            int suppTotalDay = GetTotalDay(supplierCode);

            if (this._sumSuppTotalDay != 0 &&
                suppTotalDay != this._sumSuppTotalDay)
                {
                    errMsg = "�����d����ƒ������قȂ�܂��B";
                    return false;
                }

            return (true);
        }

        /// <summary>
        /// �O���b�h�̕ҏW�O����
        /// </summary>
        /// <returns>true:�O���b�h�ֈړ��� false:�O���b�h�ֈړ��s��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̕ҏW�O�����������s���܂��B</br>
        /// <br>             �����d����R�[�h����̃t�H�[�J�X�ړ����A </br>
        /// <br>             �����d����R�[�h�̃K�C�h���͎��ɌĂ΂�܂� </br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private bool CheckBeforeEnterGrid()
        {
            bool ret = false;

            // ��ʂ��瑍�����_�E�����d����R�[�h�擾
            string sumSectionCode = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSupplierCode = this.tNedit_SupplierCd.GetInt();

            // �������_�����͍ςł��肩�����̑������_�ł���ꍇ
            if (this.tEdit_SectionName.Text != string.Empty &&
                this._mainList.ContainsKey(sumSectionCode) &&
                this._mainList[sumSectionCode].Contains(sumSupplierCode))
            {
                // �����̑������_�E�����d���悪���͂��ꂽ�ꍇ�́A�ҏW�m�F���b�Z�[�W��\������
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                  "���͂��ꂽ�R�[�h�̎d���摍����񂪊��ɓo�^����Ă��܂�" + Environment.NewLine +
                                                  "�ҏW���s���܂����H",
                                                  0,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    // ��ʂ��瑍�����_�R�[�h�d����R�[�h���擾
                    this._sumSectionCode = sumSectionCode;
                    this._sumSupplierCode = sumSupplierCode;
                    this._sumSuppTotalDay = GetTotalDay(sumSupplierCode);

                    // �ҏW���[�h�ɂ���
                    this._mainDataIndex = FindMainListIndex(sumSectionCode, sumSupplierCode);
                    ScreenReconstruction();

                    ret = true;
                }
                else
                {
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    ret = false;
                }
            }
            else
            {
                // �����̑������_-�d����ȊO�����͂��ꂽ�ꍇ
                List<SumSuppSt> sumSuppStList = SearchDetailListFromChildCode(sumSectionCode, sumSupplierCode);

                if (sumSuppStList.Count > 0)
                {
                    // �e�ɓ��͂�����񂪎q�ɓo�^����Ă���ꍇ
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "���ɓo�^����Ă��܂��B",
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    ret = false;
                }
                else
                {
                    // �V�K���[�h
                    this._sumSectionCode = sumSectionCode;
                    this._sumSupplierCode = sumSupplierCode;
                    this._sumSuppTotalDay = GetTotalDay(sumSupplierCode);

                    // �������_�E�����d���悪�S�ē��͍ς݂�
                    // �O���b�h��1�s�ڂ���̏ꍇ
                    if ( !string.IsNullOrEmpty((string)this.tEdit_SectionCode.Value) &&
                         !string.IsNullOrEmpty((string)this.tEdit_SectionName.Value) &&
                         this._secInfoSetDic.ContainsKey((string)this.tEdit_SectionCode.Value) &&
                         !string.IsNullOrEmpty((string)this.tNedit_SupplierCd.Value) &&
                         this._supplierDic.ContainsKey(this.tNedit_SupplierCd.GetInt()) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Value) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONNAME].Value) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERCD].Value) &&
                         string.IsNullOrEmpty((string)this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERNM].Value))
                    {

                        // 1�s�ڂɑ������_�E�����d����Ɠ����R�[�h������
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Value = sumSectionCode;
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Tag   = sumSectionCode;
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(sumSectionCode);
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERCD].Value  = sumSupplierCode.ToString("000000");
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERCD].Tag    = sumSupplierCode.ToString("000000");
                        this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SUPPLIERNM].Value  = GetSupplierSnm(sumSupplierCode);
                    }
                    ret = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// ���_�R�[�h�`�F�b�N����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���}�X�^�ɑ��݂��邩�`�F�b�N���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private bool CheckSectionCode(string sectionCode)
        {
            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()) == false)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
                                         methodName,						// ��������
                                         string.Empty,					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._sumSuppStAcs,			    // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Tag = string.Empty;
            this.uGrid_SumSuppSt.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
        }

        /// <summary>
        /// �V�K�s�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɍs��ǉ����܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            // �s�ǉ�
            uGrid.DisplayLayout.Bands[0].AddNew();

            // �s�ԍ��ݒ�
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_NO].Value = uGrid.Rows.Count;

            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_SECTIONCODE].Tag = string.Empty;
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
        }

        /// <summary>
        /// �ϊ�����(object��string)
        /// </summary>
        /// <param name="targetValue">�ϊ��Ώ�object</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : object�^��string�ɕϊ����܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private string StrObjectToString(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == string.Empty))
            {
                return string.Empty;
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private int StrObjectToInt(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == string.Empty) || (int.Parse((string)targetValue) == 0))
            {
                return 0;
            }

            return int.Parse((string)targetValue);
        }

        private string CellTextToString(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == string.Empty))
            {
                return string.Empty;
            }

            return cellText.Trim().PadLeft(2, '0');
        }

        private int CellTextToInt(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == string.Empty))
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
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
                    uGrid.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
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
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value = (string)string.Empty;
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // ���_���擾
                            string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONNAME].Value);

                            if (sectionName == string.Empty)
                            {
                                // ���_�K�C�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                            }
                            else
                            {
                                // �d����R�[�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                            }
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                case 3:       // ���_�K�C�h
                    {
                        // �d����R�[�h�Ƀt�H�[�J�X
                        uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // �d����R�[�h
                    {
                        if (!this._checkSupplierFlg)
                        {
                            // �d����R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERNM].Value = (string)string.Empty;
                            uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // �d����R�[�h�擾
                            int supplierCd = StrObjectToInt(uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Value);

                            if (supplierCd == 0 || !this._supplierDic.ContainsKey(supplierCd))
                            {
                                // �d����K�C�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERGUIDE].Activate();
                            }
                            else
                            {

                                if (rowIndex == uGrid.Rows.Count - 1)
                                {
                                    // �ŏI�s�Ȃ�ۑ��{�^���Ƀt�H�[�J�X
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    // ���_�R�[�h�Ƀt�H�[�J�X
                                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_SECTIONCODE].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }

                        return;
                    }
                case 6:      // �d����K�C�h
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            // �ۑ��{�^���Ƀt�H�[�J�X
                            e.NextCtrl = this.Ok_Button;
                        }
                        else
                        {
                            // ���_�R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex + 1].Cells[COLUMN_SECTIONCODE].Activate();
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
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
                            uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    // �V�K���[�h���͑����d����R�[�h�Ƀt�H�[�J�X�Z�b�g
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                }
                                else
                                {
                                    // �X�V���[�h���͕���{�^���Ƀt�H�[�J�X�Z�b�g
                                    e.NextCtrl = this.Cancel_Button;
                                }
                            }
                            else
                            {
                                // �d����R�[�h�擾
                                int supplierCd = StrObjectToInt(uGrid.Rows[rowIndex - 1].Cells[COLUMN_SUPPLIERCD].Value);

                                if (supplierCd == 0 || !this._supplierDic.ContainsKey(supplierCd))
                                {
                                    // �d����K�C�h�Ƀt�H�[�J�X
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_SUPPLIERGUIDE].Activate();
                                }
                                else
                                {
                                    // �d����R�[�h�Ƀt�H�[�J�X
                                    uGrid.Rows[rowIndex - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                                }

                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }

                        return;
                    }
                case 3:       // ���_�K�C�h
                    {
                        // ���_�R�[�h�Ƀt�H�[�J�X
                        uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 4:         // �d����R�[�h
                    {
                        if (!this._checkSupplierFlg)
                        {
                            // �d����R�[�h�Ƀt�H�[�J�X
                            uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                        }
                        else
                        {
                            // ���_���擾
                            string sectionName = StrObjectToString(uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Value);

                            if (sectionName == string.Empty)
                            {
                                // ���_�K�C�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONGUIDE].Activate();
                            }
                            else
                            {
                                // ���_�R�[�h�Ƀt�H�[�J�X
                                uGrid.Rows[rowIndex].Cells[COLUMN_SECTIONCODE].Activate();
                            }
                        }

                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                case 6:      // �d����K�C�h
                    {
                        // �d����R�[�h�Ƀt�H�[�J�X
                        uGrid.Rows[rowIndex].Cells[COLUMN_SUPPLIERCD].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void PMKAK09000UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void PMKAK09000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �N���[�Y���ɃO���b�h��񂪎c���Ă���̂ŏ���
            this.ScreenClear();

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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void PMKAK09000UA_VisibleChanged(object sender, EventArgs e)
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
        /// Button_Click �C�x���g(�������_�K�C�h�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �������_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void SumSectionGuide_Button_Click(object sender, EventArgs e)
        {
            int status = -1;

            SecInfoSet secInfoSet;

            status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            if (status == 0)
            {
                // ���_�R�[�h
                this.tEdit_SectionCode.Value = secInfoSet.SectionCode.Trim();
                // ���_��
                this.tEdit_SectionName.Value = GetSectionName(secInfoSet.SectionCode.Trim());
            }

            this.tNedit_SupplierCd.Focus();
        }

        /// <summary>
        /// Button_Click �C�x���g(�����d����K�C�h�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void SumSuppGuide_Button_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �d����̃I�u�W�F�N�g
            Supplier SupplierInfo = new Supplier();

            // �d����K�C�h�N��
            status = this._supplierAcs.ExecuteGuid(out SupplierInfo, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �����d����R�[�h
                this.tNedit_SupplierCd.Value = (string)SupplierInfo.SupplierCd.ToString("000000");
                this.tEdit_SupplierSnm.Value = SupplierInfo.SupplierSnm.ToString();

                if (!CheckBeforeEnterGrid())
                {
                    this.tNedit_SupplierCd.Focus();
                }
                else
                {
                    // �t�H�[�J�X�ݒ�
                    this.uGrid_SumSuppSt.Focus();
                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(�ۑ��{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
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
                                                      string.Empty,
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
        /// <br>Programmer	: FSI�֓� �a�G</br>
        /// <br>Date        : 2012/08/27</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �����폜����
            bool bStatus = DeleteProc();
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
        /// Button_Click �C�x���g(�����{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            _beforeCellText = string.Empty;

            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == string.Empty))
            {
                return;
            }

            // �O��l�ޔ�
            _beforeCellText = StrObjectToString(uGrid.ActiveCell.Value);
            
            int suppValue = int.Parse((string)uGrid.ActiveCell.Value);

            // �[���l�߉���
            uGrid.ActiveCell.Value = suppValue.ToString();

        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            bool errFlg = false;
            string errMsg = string.Empty;

            switch (uGrid.ActiveCell.Column.Key)
            {
                case COLUMN_SECTIONCODE:
                    {
                        this._checkSectionFlg = true;

                        // �[���l��
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        // ���_�R�[�h�擾
                        string sectionCode = StrObjectToString(uGrid.ActiveCell.Value);

                        if (sectionCode == string.Empty)
                        {
                            if (StrObjectToString(uGrid.ActiveCell.Tag) != string.Empty)
                            {
                                // �s�N���A
                                ClearRow(uGrid_SumSuppSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            // �O����͂���ŁA���ύX���ꂽ�ꍇ
                            if (!string.IsNullOrEmpty(_beforeCellText) && _beforeCellText != sectionCode)
                            {
                                // �d����N���A
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
                            }

                            bool bStatus = CheckSectionCode(sectionCode);
                            if (!bStatus)
                            {
                                this._checkSectionFlg = false;
                                errFlg = true;
                                errMsg = "���_���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                            }

                            // ���_���擾
                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(sectionCode);

                            uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SECTIONCODE].Tag = sectionCode;

                            if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s�ǉ�
                                CreateNewRow(ref uGrid);
                            }
                        }

                        break;
                    }
                case COLUMN_SUPPLIERCD:
                    {
                        this._checkSupplierFlg = true;

                        // �[���l��
                        uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

                        int supplierCode = StrObjectToInt(uGrid.ActiveCell.Value);

                        if (supplierCode == 0)
                        {
                            if (StrObjectToInt(uGrid.ActiveCell.Tag) != 0)
                            {
                                // �s�N���A
                                ClearRow(uGrid_SumSuppSt.ActiveCell.Row.Index);
                            }
                        }
                        else
                        {
                            bool bStatus = CheckSupplierCode(supplierCode, uGrid.ActiveCell.Row.Index, ref errMsg);

                            if (!bStatus)
                            {
                                this._checkSupplierFlg = false;
                                errFlg = true;
                            }
                            else
                            {

                                // �d���於�擾
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = GetSupplierSnm(supplierCode);

                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Tag = supplierCode.ToString("000000");

                                if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
                                {
                                    // �ŏI�s�������ꍇ�A�s�ǉ�
                                    CreateNewRow(ref uGrid);
                                }
                            }
                        }

                        break;
                    }
            }

            if (errFlg)
            {
                if (!this._isSaveProcess)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            this._isSaveProcess = false;
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_KeyDown(object sender, KeyEventArgs e)
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
                        else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
                        {
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == 0)
                        {
                            // �����d����R�[�h�Ƀt�H�[�J�X
                            this.tNedit_SupplierCd.Focus();
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
                        else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
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
                                else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
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
                                else if ((columnIndex == 4) && (this._checkSupplierFlg == false))
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

                        uGrid_SumSuppSt_ClickCellButton(uGrid, new CellEventArgs(uGrid.ActiveCell));
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_Leave(object sender, EventArgs e)
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
        /// <br>Note       : �O���b�h���K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void uGrid_SumSuppSt_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int status;

            switch (e.Cell.Column.Key)
            {
                case COLUMN_SECTIONGUIDE:   // ���_�K�C�h�{�^��
                    {
                        // �K�C�h�O�̒l��ޔ�
                        string beforeSectionCode = StrObjectToString(uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Value);

                        SecInfoSet secInfoSet;

                        status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                        if (status == 0)
                        {
                            // ���_�R�[�h
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Value = secInfoSet.SectionCode.Trim();
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Tag = secInfoSet.SectionCode.Trim();
                            
                            // ���_��
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONNAME].Value = GetSectionName(secInfoSet.SectionCode.Trim());

                            // �O����͂���ŁA���ύX���ꂽ�ꍇ
                            if (!string.IsNullOrEmpty(beforeSectionCode) && beforeSectionCode != secInfoSet.SectionCode.Trim())
                            {
                                // �d����N���A
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = string.Empty;
                                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_SUPPLIERCD].Tag = string.Empty;
                            }

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s��ǉ�
                                CreateNewRow(ref uGrid);
                            }

                            // �t�H�[�J�X���E�ׂ̎d����ֈړ�
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SUPPLIERCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case COLUMN_SUPPLIERGUIDE:  // �d����K�C�h�{�^��
                    {
                        // �d����̃I�u�W�F�N�g
                        Supplier SupplierInfo = new Supplier();

                        // �d����K�C�h�N��
                        status = this._supplierAcs.ExecuteGuid(out SupplierInfo, this._enterpriseCode, string.Empty);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �d����R�[�h
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SUPPLIERCD].Value = SupplierInfo.SupplierCd.ToString("000000");
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SECTIONCODE].Tag = SupplierInfo.SupplierCd.ToString("000000");
                            
                            // �d���旪��
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_SUPPLIERNM].Value = SupplierInfo.SupplierSnm.ToString();

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // �ŏI�s�������ꍇ�A�s��ǉ�
                                CreateNewRow(ref uGrid);
                            }

                            // �t�H�[�J�X�����s�̋��_�R�[�h�ֈړ�
                            uGrid.Rows[e.Cell.Row.Index + 1].Cells[COLUMN_SECTIONCODE].Activate();
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/27</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.Cancel_Button &&
                e.Key != Keys.Tab &&
                e.Key != Keys.Enter &&
                e.Key != Keys.Up &&
                e.Key != Keys.Down &&
                e.Key != Keys.Left &&
                e.Key != Keys.Right)
            {
                e.NextCtrl = null;
                Cancel_Button_Click(this.Cancel_Button, new EventArgs());
                return;
            }

            // ��ʂ��瑍�����_�E�����d����R�[�h�擾
            string sumSectionCode = (string)this.tEdit_SectionCode.GetInt().ToString("00");
            int sumSupplierCode = this.tNedit_SupplierCd.GetInt();

            switch (e.PrevCtrl.Name)
            {
                #region ���������_�R�[�h
                case "tEdit_SectionCode":
                    {
                        if ( sumSectionCode != "00" &&
                            !this._secInfoSetDic.ContainsKey(sumSectionCode))
                        {
                            // ���͂���Ń}�X�^�o�^�Ȃ�
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "���_���ݒ�}�X�^�ɓo�^����Ă��܂���B",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tEdit_SectionCode.Clear();
                            this.tEdit_SectionName.Clear();
                            e.NextCtrl = this.tEdit_SectionCode;
                            break;
                        }
                        else if (this._secInfoSetDic.ContainsKey(sumSectionCode))
                        {
                            // �L���b�V���ɑ��݂���ꍇ�͖��̂��Z�b�g
                            this.tEdit_SectionName.Value = this._secInfoSetDic[sumSectionCode].SectionGuideSnm.ToString();
                        }

                        // �t�H�[�J�X����
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSectionCode == "00")
                                {
                                    this.tEdit_SectionCode.Clear();
                                    this.tEdit_SectionName.Clear();
                                    e.NextCtrl = this.SumSectionGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSectionCode == "00")
                                {
                                    this.tEdit_SectionCode.Clear();
                                    this.tEdit_SectionName.Clear();
                                }

                                // �V�t�g�L�[�������͕���{�^���փt�H�[�J�X�ړ�
                                e.NextCtrl = this.Cancel_Button;
                            }
                        }
                        break;
                    }
                #endregion

                #region �������d����R�[�h
                case "tNedit_SupplierCd":
                    {
                        if ( sumSupplierCode != 0 &&
                            !this._supplierDic.ContainsKey(sumSupplierCode))
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "�d����}�X�^�ɓo�^����Ă��܂���B",
                                           -1,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);

                            this.tNedit_SupplierCd.Clear();
                            this.tEdit_SupplierSnm.Clear();
                            e.NextCtrl = this.tNedit_SupplierCd;
                            break;
                        }
                        else if (this._supplierDic.ContainsKey(sumSupplierCode))
                        {
                            // �L���b�V���ɑ��݂���ꍇ�͖��̂��Z�b�g
                            this.tEdit_SupplierSnm.Value = this._supplierDic[sumSupplierCode].SupplierSnm.ToString();

                            // �O���b�h���͂��邽�߂̏�������
                            // �O���b�h�֑J�ڕs�̏ꍇ�̓t�H�[�J�X�𑍊��d����R�[�h�ɖ߂�
                            if (!CheckBeforeEnterGrid())
                            {
                                e.NextCtrl = this.tNedit_SupplierCd;
                                break;
                            }
                        }
                        // �t�H�[�J�X���ړ�
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSupplierCode == 0)
                                {
                                    this.tNedit_SupplierCd.Clear();
                                    this.tEdit_SupplierSnm.Clear();
                                    e.NextCtrl = this.SumSuppGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_SumSuppSt.Focus();
                                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (sumSupplierCode == 0)
                                {
                                    this.tNedit_SupplierCd.Clear();
                                    this.tEdit_SupplierSnm.Clear();
                                }

                                if (sumSectionCode == "00")
                                {
                                    e.NextCtrl = this.SumSectionGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���O���b�h��
                case "uGrid_SumSuppSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_SumSuppSt, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetBeforeFocus(this.uGrid_SumSuppSt, ref e);
                            }
                        }
                        break;
                    }
                #endregion

                #region ���ۑ��{�^��
                case "Ok_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Cancel_Button;
                            }
                        }
                        else
                        {
                            e.NextCtrl = null;
                            this.uGrid_SumSuppSt.Focus();
                            this.uGrid_SumSuppSt.Rows[this.uGrid_SumSuppSt.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                            this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                #endregion

                #region ������{�^��
                case "Cancel_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    e.NextCtrl = tEdit_SectionCode;
                                }
                                else if (this.Mode_Label.Text == UPDATE_MODE)
                                {
                                    // �X�V���[�h���̓O���b�h�ŏ�i�̋��_�R�[�h�Ƀt�H�[�J�X�Z�b�g
                                    e.NextCtrl = null;
                                    this.uGrid_SumSuppSt.Focus();
                                    this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                                    this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else if (this.Mode_Label.Text == DELETE_MODE)
                                {
                                    e.NextCtrl = Delete_Button;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.Mode_Label.Text == DELETE_MODE)
                                {
                                    e.NextCtrl = Revive_Button;
                                }
                                else
                                {
                                    e.NextCtrl = Ok_Button;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region �����S�폜�{�^��
                case "Delete_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Revive_Button;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Cancel_Button;
                            }
                        }
                        break;
                    }
                #endregion
                
                #region �������{�^��
                case "Revive_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Cancel_Button;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = Delete_Button;
                            }
                        }
                        break;
                    }
                #endregion
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            #region ��NextCtrl
            switch (e.NextCtrl.Name)
            {
                case "uGrid_SumSuppSt":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumSuppSt.Rows[0].Cells[COLUMN_SECTIONCODE].Activate();
                                this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumSuppSt.Rows[this.uGrid_SumSuppSt.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                                this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_SumSuppSt.Rows[this.uGrid_SumSuppSt.Rows.Count - 1].Cells[COLUMN_SUPPLIERCD].Activate();
                                this.uGrid_SumSuppSt.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        break;
                    }
            }
            #endregion
        }
        
        #endregion �� Control Events

    }
}