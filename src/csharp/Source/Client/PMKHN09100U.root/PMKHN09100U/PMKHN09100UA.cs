//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ݒ�(�`�[�ݒ�)
// �v���O�����T�v   : ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�̓o�^�E�C���E�폜���s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ����
// �� �� ��  2008/06/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/09/11  �C�����e : �f�[�^�r���[�̗񕝂̎��������`�F�b�N�{�b�N�X�̃f�t�H���g�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/09/22  �C�����e : ���Ӑ�`�[�ԍ��w�b�_�A���Ӑ�`�[�ԍ��t�b�^���폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �s�V �m��
// �C �� ��  2008/10/06  �C�����e : �o�O�C���A��ʃ��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12695       �쐬�S�� : �H�� �b�D
// �C �� ��  2009/03/24  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/04/28  �C�����e : MANTIS�y13218�z�f�[�^�O���̐��퓮��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/19  �C�����e : MANTIS�y13561�z���o�敪���X�g�̕s��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �v��
// �C �� ��  2013/02/08  �C�����e : 2013/03/13�z�M�� 
//                                  Redmine#34616   No.1641���Ӑ�`�[�ԍ��`�F�b�N�̕s��C��
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�ݒ�(�`�[�ݒ�)
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�̓o�^�E�C���E�폜���s���܂��B</br>
    /// <br>				IMasterMaintenanceArrayType���������Ă��܂��B</br>
    /// <br>Programmer : 30416 ���� ����</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br>Update Note: 2007/19/11  30414 �E �K�j</br>
    /// <br>     		 �f�[�^�r���[�̗񕝂̎��������`�F�b�N�{�b�N�X�̃f�t�H���g�l�ύX</br>
    /// <br>Update Note: 2008/09/22 30452 ��� �r��</br>
    /// <br>             PM.NS�Ή�</br>
    /// <br>             �E���Ӑ�`�[�ԍ��w�b�_�A���Ӑ�`�[�ԍ��t�b�^���폜</br>
    /// <br>UpdateNote : 2008/10/06 30462 �s�V �m���@�o�O�C���A��ʃ��C�A�E�g�ύX</br>
    /// <br>UpdateNote : 2009/03/24 30434 �H�� �b�D�@�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���</br>
    /// <br>Update Note: 2013/02/08 �v��</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#34616 No.1641���Ӑ�`�[�ԍ��`�F�b�N�̕s��C��</br>
    /// </remarks>
    public partial class PMKHN09100UA : Form, IMasterMaintenanceArrayType
    {
        /// <summary>���C��</summary>
        public const string MAIN_TABLE = "CashRegisterNo";
        /// <summary>�ڍ�</summary>
        public const string DETAILS_TABLE = "SlipPrt";

        // �O���b�h�^�C�g��
        /// <summary>����</summary>
        public const string CUSTSLIPNOSET_GRID_TITLE = "���Ӑ�R�[�h";
        /// <summary>����</summary>
        public const string ADDUPYEARMONTH_GRID_TITLE = "�v��N��";

        private enum SlipOutputSetSearchMode
        {
            ///<summary>���[�J���c�a</summary>
            LocalDB = 0,
            ///<summary>�����[�g�c�a</summary>
            RemoteDB = 1
        }

        #region Private Members

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;

        // �^�C�g��
        private string _mainGridTitle;
        private string _secondGridTitle;

        // �A�C�R��
        private Image _mainGridIcon;
        private Image _secondGridIcon;

        // �I���f�[�^�C���f�b�N�X
        private int _mainDataIndex;
        private int _detailsDataIndex;

        // �A�v���P�[�V����
        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�A�N�Z�X�N���X
        private CustSlipNoSetAcs _custSlipNoSetAcs = null;

        private CustomerInfoAcs _customerInfoAcs = null;

        // �f�[�^�Z�b�g
        private DataSet _bindDataSet = null;

        private DateGetAcs _dateGetAcs = null; //ADD 2008/09/22

        // �]�ƈ�
        private Employee _employee = null;

        // ��ʃf�U�C���ύX�N���X
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �I�����̃`�F�b�N�p
        private DataTable _dataTableClone = null;

        // �����񌋍��p
        private StringBuilder _stringBuilder = null;

        //------------------
        // �R���{�{�b�N�X�p
        //------------------

        // �R���{�{�b�N�X�p
        private const string COMBO_CODE = "COMBO_CODE";
        private const string COMBO_NAME = "COMBO_NAME";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private const int BUTTON_LOCATION1_X = 132;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 261;     // �ۑ�/�����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 392;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 5;        // �{�^���ʒuY(����)

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMKHN09100U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        // ���o�敪
        private const string EXTRACTION_DIVISION1 = "�A��";
        private const string EXTRACTION_DIVISION2 = "����";
        private const string EXTRACTION_DIVISION3 = "����";

        #endregion

        #region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public PMKHN09100UA()
        {
            InitializeComponent();

            //====================================
            // �v���p�e�B�����l�ݒ�
            //====================================
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;

            this._mainGridTitle = CUSTSLIPNOSET_GRID_TITLE;
            this._secondGridTitle = ADDUPYEARMONTH_GRID_TITLE;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            //====================================
            // �ϐ�������
            //====================================
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �]�ƈ�
            this._employee = LoginInfoAcquisition.Employee;

            // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�A�N�Z�X�N���X
            this._custSlipNoSetAcs = new CustSlipNoSetAcs();

            this._customerInfoAcs = new CustomerInfoAcs();

            this._dateGetAcs = DateGetAcs.GetInstance(); //ADD 2008/09/22

            // �I�����̃`�F�b�N�p
            this._dataTableClone = new DataTable();

            // �e��C���f�b�N�X������
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;

            // �A�C�R���p
            this._mainGridIcon = null;
            this._secondGridIcon = null;

            // �f�[�^�Z�b�g����\�z����
            this._bindDataSet = new DataSet();
            DataSetColumnConstruction(ref this._bindDataSet);

            // �����񌋍��p
            this._stringBuilder = new StringBuilder();
        }
        #endregion

        # region Events�i��`�j
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09100UA());
        }
        # endregion

        # region �C���^�[�t�F�[�X��` Properties
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

        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
        #endregion

        #region �C���^�[�t�F�[�X��` Public Methods
        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { true, false }; // MOD 2008/03/24 �s��Ή�[12695]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� { false, true }��{ true, false }
            return logicalDelete;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _secondGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public System.Drawing.Image[] GetGridIconList()
        {
            System.Drawing.Image[] gridIcon = { _mainGridIcon, _secondGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            //bool[] defaultAutoFill = { true, true };
            bool[] defaultAutoFill = { false, false };
            // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<
            return defaultAutoFill;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;

            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, true };

            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                newButtonEnabled[1] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true };

            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                modifyButtonEnabled[1] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true };

            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                deleteButtonEnabled[1] = false;
            }
            return deleteButtonEnabled;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this._bindDataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = DETAILS_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����L�����A�̑S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string message;
            bool nextData;
            DataSet ds;

            //-------------------------------------------------------------------
            // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^���璊�o
            //-------------------------------------------------------------------
            status = this._custSlipNoSetAcs.SearchAll(out ds
                                                    , out totalCount
                                                    , out nextData
                                                    , this._enterpriseCode
                                                    , this._employee.BelongSectionCode
                                                    , out message);
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)      // DEL 2009/04/28
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&    // ADD 2009/04/28
                (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                }

                // �T�[�`
                TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrLvl,                           // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        //"�[���ʓ`�[�o�͐�ݒ�",             // �v���O��������     // DEL 2009/04/28
                        "���Ӑ�ݒ�(�`�[�ݒ�)",             // �v���O��������       // ADD 2009/04/28
                        "Search", 							// ��������
                        TMsgDisp.OPE_GET,                   // �I�y���[�V����
                        "�ǂݍ��݂Ɏ��s���܂����B\r\n" + message,  // �\�����郁�b�Z�[�W
                        status,                             // �X�e�[�^�X�l
                        this._custSlipNoSetAcs,    	        // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,               // �\������{�^��
                        MessageBoxDefaultButton.Button1);   // �����\���{�^��

                return status;
            }
            // ADD 2009/04/28 ------>>>
            else
            {
                // �e�[�u���ɂP���R�[�h�����݂��Ȃ��ꍇ�����퓮��Ƃ���
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ADD 2009/04/28 ------<<<
            
            this._bindDataSet.Tables[MAIN_TABLE].Rows.Clear();
            this._bindDataSet.Tables[DETAILS_TABLE].Rows.Clear();

            foreach (DataRow dr in ds.Tables[CustSlipNoSetAcs.MAIN_TABLE].Rows)
            {
                DataRow check = this._bindDataSet.Tables[MAIN_TABLE].Rows.Find(new object[] { dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] });

                if (check != null)
                {
                    // �o�^�ς݂Ȃ̂Ŏ���
                    continue;
                }

                // �f�[�^���o�^
                    
                // ���C���e�[�u���ւ̓o�^
                DataRow drMain = this._bindDataSet.Tables[MAIN_TABLE].NewRow();

                // ���Ӑ�R�[�h
                drMain[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                // ���Ӑ旪�́i�����ێ��p�j
                drMain[CustSlipNoSetAcs.CUSTOMERNAME_TITLE] = dr[CustSlipNoSetAcs.CUSTOMERNAME_TITLE];

                // �폜��
                // ADD 2008/03/24 �s��Ή�[12695]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
                drMain[CustSlipNoSetAcs.DELETE_DATE_TITLE] = GetDelateDate((int)drMain[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]);

                this._bindDataSet.Tables[MAIN_TABLE].Rows.Add(drMain);
            }

            return status;
        }

        // ADD 2009/03/24 �s��Ή�[12695]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        /// <summary>
        /// ���C���e�[�u���̍폜�����擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���C���e�[�u���̍폜���i�폜����ĂȂ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private string GetDelateDate(int customerCode)
        {
            DataRow[] foundDataRows = this._custSlipNoSetAcs.DtDetailsTable.Select(
                CustSlipNoSetAcs.CUSTOMERCODE_TITLE + "=" + customerCode.ToString()
            );
            if (foundDataRows.Length.Equals(0)) return string.Empty;

            // �폜�������W
            IList<DataRow> deletedRowList = new List<DataRow>();
            foreach (DataRow foundRow in foundDataRows)
            {
                if (!string.IsNullOrEmpty((string)foundRow[CustSlipNoSetAcs.DELETE_DATE_TITLE]))
                {
                    deletedRowList.Add(foundRow);
                }
            }

            // �T�u�e�[�u���̃��R�[�h���S�č폜�̏ꍇ�A�폜����Ԃ�
            if (deletedRowList.Count.Equals(foundDataRows.Length))
            {
                return (string)deletedRowList[0][CustSlipNoSetAcs.DELETE_DATE_TITLE];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// ���C���e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        private void SetMainTableDeleteDate()
        {
            foreach (DataRow mainRow in this._bindDataSet.Tables[MAIN_TABLE].Rows)
            {
                int customerCode = (int)mainRow[CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                mainRow[CustSlipNoSetAcs.DELETE_DATE_TITLE] = GetDelateDate(customerCode);
            }
        }
        // ADD 2009/03/24 �s��Ή�[12695]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ArrayType�ł͖�����</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �ڍ׌�������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if ((this._bindDataSet == null) || (this._mainDataIndex < 0))
            {
                return status;
            }

            this._bindDataSet.Tables[DETAILS_TABLE].Rows.Clear();

            // ADD 2009/03/24 �s��Ή�[12695]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;
            // ADD 2009/03/24 �s��Ή�[12695]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            int customerCode = int.Parse(this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE].ToString());

            DataTable sortTable = new DataTable();
            sortTable = this._custSlipNoSetAcs.DtDetailsTable.Clone();	// �ڍ׃e�[�u���̃J�����R�s�[

            // �r���[�f�[�^�擾
            DataView dView = this._custSlipNoSetAcs.DtDetailsTable.DefaultView;

            // ���R�[�h�����[�N�e�[�u���ɋl�ߑւ�
            foreach (DataRowView drv in dView)
            {
                sortTable.ImportRow(drv.Row);
            }

            // ��P�O���b�h���o���Ɋ��ɒ��o�ς݂̃e�[�u������\��
            foreach (DataRow dr in sortTable.Rows)
            {
                if (customerCode != (int)dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE])
                {
                    // �[���ԍ����s��v�̃f�[�^�͏��O
                    continue;
                }

                DataRow check = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Find(new object[] {	dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE],
				                                                                                    dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] });
                if (check != null)
                {
                    // �o�^�ς݂Ȃ̂Ŏ���
                    continue;
                }

                // �`�[����e�[�u���ւ̓o�^
                DataRow drDetails = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();

                // ���Ӑ�R�[�h
                drDetails[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                // �v��N��
                // DEL 2008/10/06 �s��Ή�[6262]��
                //drDetails[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE];
                // ---ADD 2008/10/06 �s��Ή�[6262] ------------------------------------------->>>>>
                if (dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].Equals(0))
                {
                    drDetails[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = " ";
                }
                else
                {
                    drDetails[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE];
                }
                // ---ADD 2008/10/06 �s��Ή�[6262] -------------------------------------------<<<<<

                // ���ݓ��Ӑ�`�[�ԍ�
                drDetails[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE] = dr[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE];
                // �J�n���Ӑ�`�[�ԍ�
                drDetails[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE] = dr[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE];
                // �I�����Ӑ�`�[�ԍ�
                drDetails[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE] = dr[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE];

                // --- DEL 2008/09/22 -------------------------------->>>>>
                //// ���Ӑ�`�[�ԍ��w�b�_
                //drDetails[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE] = dr[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE];
                //// ���Ӑ�`�[�ԍ��t�b�^
                //drDetails[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE] = dr[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE];
                // --- DEL 2008/09/22 --------------------------------<<<<<

                // �폜��
                drDetails[CustSlipNoSetAcs.DELETE_DATE_TITLE] = dr[CustSlipNoSetAcs.DELETE_DATE_TITLE];

                this._bindDataSet.Tables[DETAILS_TABLE].Rows.Add(drDetails);
            }

            totalCount = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ���C���e�[�u���̍폜����ݒ�
            SetMainTableDeleteDate();   // ADD 2008/03/24 �s��Ή�[12695]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ArrayType�ł͖�����</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �f�[�^�_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^��_���폜���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            switch (this._targetTableName)
            {
                // �[���ʓ`�[�o�͐�e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // �[���ʓ`�[�o�͐�_���폜����
                        status = LogicalDeleteSlipOutputSet();
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // ���C��
            Hashtable main = new Hashtable();

            // ADD 2008/03/24 �s��Ή�[12695]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));

            //main.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black)); //DEL 2008/09/22
            main.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "00000000", Color.Black)); //ADD 2008/09/22
            main.Add(CustSlipNoSetAcs.CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));

            // �ڍ�
            Hashtable details = new Hashtable();

            details.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));

            details.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            details.Add(CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // DEL 2008/12/02 �s��Ή�[8654] ---------->>>>>
            //details.Add(CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //details.Add(CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //details.Add(CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // DEL 2008/12/02 �s��Ή�[8654] ----------<<<<<

            // ADD 2008/12/02 �s��Ή�[8654] ---------->>>>>
            details.Add(CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000000", Color.Black));
            details.Add(CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000000", Color.Black));
            details.Add(CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000000", Color.Black));
            // ADD 2008/12/02 �s��Ή�[8654] ----------<<<<<

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //details.Add(CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //details.Add(CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/09/22 --------------------------------<<<<<

            _hashtable = new Hashtable[2];
            _hashtable[0] = main;
            _hashtable[1] = details;
        }
        #endregion

        #region �f�[�^�Z�b�g����\�z����
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //===============================
            // ���C���e�[�u����`�i�[���ԍ��j
            //===============================
            DataTable mainTable = new DataTable(MAIN_TABLE);

            // �폜��
            mainTable.Columns.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, typeof(string));  // ADD 2008/03/24 �s��Ή�[12695]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // ���Ӑ�R�[�h
            //mainTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, typeof(string)); //DEL 2008/09/22
            mainTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, typeof(Int32)); //ADD 2008/09/22
            // ���Ӑ旪�́i�����ێ��p�j
            mainTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERNAME_TITLE, typeof(string));


            DataColumn[] primaryKey1 = { mainTable.Columns[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] };
            mainTable.PrimaryKey = primaryKey1;

            this._bindDataSet.Tables.Add(mainTable);

            //============================
            // �ڍ׃e�[�u����`�i�`�[����j
            //============================
            DataTable detailsTable = new DataTable(DETAILS_TABLE);

            // �폜��
            detailsTable.Columns.Add(CustSlipNoSetAcs.DELETE_DATE_TITLE, typeof(string));

            // ���Ӑ�R�[�h
            detailsTable.Columns.Add(CustSlipNoSetAcs.CUSTOMERCODE_TITLE, typeof(Int32));
            // �v��N��
            // DEL 2008/10/06 �s��Ή�[6262]��
            //detailsTable.Columns.Add(CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE, typeof(Int32));
            detailsTable.Columns.Add(CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE, typeof(string));    // ADD 2008/10/06 �s��Ή�[6262]

            // ���ݓ��Ӑ�`�[�ԍ�
            detailsTable.Columns.Add(CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE, typeof(Int64));
            // �J�n���Ӑ�`�[�ԍ�
            detailsTable.Columns.Add(CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE, typeof(Int64));
            // �I�����Ӑ�`�[�ԍ�
            detailsTable.Columns.Add(CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE, typeof(Int64));

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// ���Ӑ�`�[�ԍ��w�b�_
            //detailsTable.Columns.Add(CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE, typeof(string));
            //// ���Ӑ�`�[�ԍ��t�b�^
            //detailsTable.Columns.Add(CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE, typeof(string));
            // --- DEL 2008/09/22 --------------------------------<<<<<

            DataColumn[] primaryKey2 = { detailsTable.Columns[CustSlipNoSetAcs.CUSTOMERCODE_TITLE],
										 detailsTable.Columns[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] };
            detailsTable.PrimaryKey = primaryKey2;

            this._bindDataSet.Tables.Add(detailsTable);
        }
        #endregion

        #region ��ʏ����ݒ菈��
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI��ʕ\�����̃`������}����ׂɁA�����ŃT�C�Y���ύX
            switch (this._targetTableName)
            {
                // �[���ԍ��e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �`�[����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // �V�K�̏ꍇ
                        if (this._detailsDataIndex < 0)
                        {
                            ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
                            break;
                        }
                        // �폜�̏ꍇ
                        if ((string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][CustSlipNoSetAcs.DELETE_DATE_TITLE] != "")
                        {
                            ScreenInputPermissionControl(5);                        // ��ʓ��͋�����
                            break;
                        }
                        // �X�V�̏ꍇ
                        else
                        {
                            ScreenInputPermissionControl(4);                        // ��ʓ��͋�����
                            break;
                        }
                    }
            }
        }
        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                // 0:���W-�V�K
                case 0:
                    {
                        break;
                    }
                // 1:���W-�X�V
                case 1:
                    {
                        break;
                    }
                // 2:���W-�폜
                case 2:
                    {
                        break;
                    }
                // 3:�`�[-�V�K
                case 3:
                    {
                        // ����
                        this.tComboEditor1.Enabled = true;

                        // --- ADD 2008/09/22 -------------------------------->>>>>
                        this.PresentCustSlipNo_tNedit.Enabled = true;
                        this.StartCustSlipNo_tNedit.Enabled = true;
                        this.EndCustSlipNo_tNedit.Enabled = true;
                        // --- ADD 2008/09/22 --------------------------------<<<<< 
                        
                        // �{�^��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;

                        break;
                    }
                // 4:�`�[-�X�V
                case 4:
                    {
                        // ����
                        this.tComboEditor1.Enabled = false;

                        this.tDateEdit1.Enabled = false;

                        // --- ADD 2008/09/22 -------------------------------->>>>>
                        this.PresentCustSlipNo_tNedit.Enabled = true;
                        this.StartCustSlipNo_tNedit.Enabled = true;
                        this.EndCustSlipNo_tNedit.Enabled = true;
                        // --- ADD 2008/09/22 --------------------------------<<<<< 

                        // �{�^��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        break;
                    }
                // 5:�`�[-�폜
                case 5:
                    {
                        // ����
                        this.tComboEditor1.Enabled = false;

                        this.tDateEdit1.Enabled = false;

                        // --- ADD 2008/09/22 -------------------------------->>>>>
                        this.PresentCustSlipNo_tNedit.Enabled = false;
                        this.StartCustSlipNo_tNedit.Enabled = false;
                        this.EndCustSlipNo_tNedit.Enabled = false;
                        // --- ADD 2008/09/22 --------------------------------<<<<< 

                        // �{�^��
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;

                        break;
                    }
            }
        }
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            // �{�^��
            this.Ok_Button.Visible = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
            this.Delete_Button.Visible = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible = true;  // �����{�^��
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
            this.Ok_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �ۑ��{�^���ʒu
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // ����{�^���ʒu

            // ����
            this.tDateEdit1.Clear();            // �v��N��
        }
        #endregion

        #region ��ʍč\�z����
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            switch (this._targetTableName)
            {
                // �[���ԍ��e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �`�[����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        DataRow dr;

                        // �V�K�̏ꍇ
                        if (this._detailsDataIndex < 0)
                        {
                            //---------------------------------------------------
                            // �L�[���ڐݒ�i�ȉ��͑S�ăL�[�Ȃ̂ŕK���ݒ肪�K�v�j
                            //---------------------------------------------------
                            dr = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();


                            // ���Ӑ�R�[�h
                            dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE];

                            // �v��N��
                            dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = CustSlipNoSetAcs.NullChgInt(this.tDateEdit1.GetDateTime());

                            // ��ʓW�J����
                            DataRowToScreen(dr);

                            //--------------------------------
                            // �R���{�{�b�N�X�f�t�H���g�l�ݒ�
                            //--------------------------------
                            this.tComboEditor1.SelectedIndex = 0;

                            //--------------------
                            // ��r�p�N���[���쐬
                            //--------------------
                            this._dataTableClone = this._bindDataSet.Tables[DETAILS_TABLE].Clone();
                            DataRow drClone = this._dataTableClone.NewRow();

                            // �A�C�e���R�s�[
                            for (int i = 0; i < dr.ItemArray.Length; i++)
                            {
                                drClone[i] = dr[i];
                            }
                            this._dataTableClone.Rows.Add(drClone);

                            // �t�H�[�J�X�ݒ�
                            this.tComboEditor1.Focus();

                            break;
                        }

                        //----- �X�V�f�[�^�擾 -----
                        dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

                        // �폜�̏ꍇ
                        if ((string)dr[CustSlipNoSetAcs.DELETE_DATE_TITLE] != "")
                        {
                            // �폜���[�h
                            this.Mode_Label.Text = DELETE_MODE;

                            // ��ʓW�J����
                            DataRowToScreen(dr);
                        }
                        // �X�V�̏ꍇ
                        else
                        {
                            // �X�V���[�h
                            this.Mode_Label.Text = UPDATE_MODE;

                            // ��ʓW�J����
                            DataRowToScreen(dr);

                            //--------------------
                            // ��r�p�N���[���쐬
                            //--------------------
                            this._dataTableClone = this._bindDataSet.Tables[DETAILS_TABLE].Clone();
                            DataRow drClone = this._dataTableClone.NewRow();

                            // �A�C�e���R�s�[
                            for (int i = 0; i < dr.ItemArray.Length; i++)
                            {
                                drClone[i] = dr[i];
                            }
                            this._dataTableClone.Rows.Add(drClone);

                            // �t�H�[�J�X�ݒ�
                            //this.SlipPrtKind_tComboEditor.Focus();
                        }
                    }
                    break;
            }
        }
        #endregion

        #region ��ʏ��ۑ�����
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="saveTarget">�ۑ��}�X�^ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private bool SaveProc(string saveTarget)
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message))
            {
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

            switch (saveTarget)
            {
                // �`�[����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // �X�V
                        if (!SaveCustSlipNoSet())
                        {
                            return false;
                        }
                        break;
                    }
            }
            return true;
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note	�@ : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// <br>Update Note: 2013/02/08 �v��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#34616 No.1641���Ӑ�`�[�ԍ��`�F�b�N�̕s��C��</br>
        /// </remarks>
        private bool 
            ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // ���Ӑ�R�[�h
            if (this.tNedit_CustomerCode.Text.Trim() == "")
            {
                message = this.CustomerCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.tNedit_CustomerCode;
                result = false;

                return result; // ADD 2008/09/26
            }

            // ���ݓ��ӓ`�[�ԍ�
            //if ((this.StartCustSlipNo_tNedit.GetInt() <= this.PresentCustSlipNo_tNedit.GetInt()) && (this.PresentCustSlipNo_tNedit.GetInt() <= this.EndCustSlipNo_tNedit.GetInt()))   // DEL �v�� 2013/02/08 FOR Redmine#34616
            if ((this.StartCustSlipNo_tNedit.GetInt() <= this.PresentCustSlipNo_tNedit.GetInt() + 1) && (this.PresentCustSlipNo_tNedit.GetInt() <= this.EndCustSlipNo_tNedit.GetInt())) // ADD �v�� 2013/02/08 FOR Redmine#34616
            {
                // --------------- ADD �v�� 2013/02/08 FOR Redmine#34616-------->>>> 
                if (this.StartCustSlipNo_tNedit.GetInt() > this.EndCustSlipNo_tNedit.GetInt())
                {
                    message = "���ݓ��Ӑ�`�[�ԍ����傫���ԍ�����͂��Ă��������B";
                    control = this.EndCustSlipNo_tNedit;
                    result = false;

                    return result;
                }
                // --------------- ADD �v�� 2013/02/08 FOR Redmine#34616--------<<<< 

                // OK
            }
            else
            {
                // ADD 2008/12/02 �s��Ή�[8566] ---------->>>>>
                if (this.PresentCustSlipNo_tNedit.GetInt() > this.EndCustSlipNo_tNedit.GetInt())
                {
                    //message = this.EndCustSlipNo_Title_Label.Text + "��͈͓��œ��͂��Ă��������B"; // DEL 2008/12/03 �s��Ή�[8566] 
                    message = "���ݓ��Ӑ�`�[�ԍ����傫���ԍ�����͂��Ă��������B";   // ADD 2008/12/03 �s��Ή�[8566] 
                    control = this.EndCustSlipNo_tNedit;
                    result = false;

                    return result; // ADD 2008/09/26
                }
                // ADD 2008/12/02 �s��Ή�[8566] ----------<<<<<
                message = this.PresentCustSlipNo_Title_Label.Text + "��͈͓��œ��͂��Ă��������B";
                control = this.PresentCustSlipNo_tNedit;
                result = false;

                return result; // ADD 2008/09/26
            }

            // �A�ԈȊO�̏ꍇ
            if (tComboEditor1.SelectedIndex != 0)
            {
                // --- DEL 2008/09/22 -------------------------------->>>>>
                //if (this.tDateEdit1.GetDateTime() == DateTime.MinValue)
                //{
                //    message = this.AddUpYearMonth_Title_Label.Text + "����͂��Ă��������B"; ;
                //    control = this.tDateEdit1;
                //    result = false;
                //}
                // --- DEL 2008/09/22 -------------------------------->>>>>
                // --- ADD 2008/09/22 -------------------------------->>>>>

                DateGetAcs.CheckDateResult checkDateResult = this._dateGetAcs.CheckDate(ref this.tDateEdit1, false);

                // --- ADD 2008/09/26 -------------------------------->>>>>
                if (checkDateResult == DateGetAcs.CheckDateResult.OK)
                {
                    // OK
                }
                else if (checkDateResult == DateGetAcs.CheckDateResult.ErrorOfNoInput)
                {
                    message = "�v��N���������͂ł��B";
                    control = this.tDateEdit1;
                    result = false;

                    return result;
                }
                else
                {
                    message = "�v��N�����s���ł��B";
                    control = this.tDateEdit1;
                    result = false;

                    return result;
                }
                // --- ADD 2008/09/26 --------------------------------<<<<<

                // --- DEL 2008/09/24 -------------------------------->>>>>
                //if (checkDateResult != DateGetAcs.CheckDateResult.OK)
                //{
                //    message = "�v��N�����s���ł��B";
                //    control = this.tDateEdit1;
                //    result = false;
                //}
                // --- DEL 2008/09/24 --------------------------------<<<<<
                // --- ADD 2008/09/22 --------------------------------<<<<<
            }

            return result;
        }

        /// <summary>
        /// ��ʏ��`�[�o�͐�ݒ�N���X�i�[����
        /// </summary>
        /// <param name="custSlipNoSet">�`�[�o�͐�ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�`�[�o�͐�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DispToCustSlipNoSet(ref CustSlipNoSet custSlipNoSet)
        {
            // ��ƃR�[�h
            custSlipNoSet.EnterpriseCode = this._enterpriseCode;

            switch (this._targetTableName)
            {
                // ���W�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �`�[����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        custSlipNoSet.CustomerCode = this.tNedit_CustomerCode.GetInt();

                        if (tComboEditor1.SelectedIndex == 0)
                        {
                            custSlipNoSet.AddUpYearMonth = 0;
                        }
                        else if (tComboEditor1.SelectedIndex == 1)
                        {
                            DateTime AddUpDate = this.tDateEdit1.GetDateTime();
                            string AddYear = AddUpDate.Year.ToString();
                            string AddMonth = AddUpDate.Month.ToString().PadLeft(2,'0');

                            custSlipNoSet.AddUpYearMonth = int.Parse(AddYear + AddMonth);
                        }
                        else
                        {
                            DateTime AddUpDate = this.tDateEdit1.GetDateTime();
                            string AddYear = AddUpDate.Year.ToString();

                            custSlipNoSet.AddUpYearMonth = int.Parse(AddYear);
                        }

                        custSlipNoSet.PresentCustSlipNo = CustSlipNoSetAcs.NullChgInt(this.PresentCustSlipNo_tNedit.Value);
                        custSlipNoSet.StartCustSlipNo = CustSlipNoSetAcs.NullChgInt(this.StartCustSlipNo_tNedit.Value);
                        custSlipNoSet.EndCustSlipNo = CustSlipNoSetAcs.NullChgInt(this.EndCustSlipNo_tNedit.Value);

                        //custSlipNoSet.CustSlipNoHeader = this.CustSlipNoHeader_tEdit.Text; //DEL 2008/09/22
                        //custSlipNoSet.CustSlipNoFooter = this.CustSlipNoFooter_tEdit.Text; //DEL 2008/09/22

                        break;
                    }
            }
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                if (TargetTableName == MAIN_TABLE)
                {
                    // �f�[�^�C���f�b�N�X������������
                    this._mainDataIndex = -1;
                }

                // �t���[���X�V�i�ǂݍ��݂����A�\�[�g�̂݁j
                int dataCnt = 0;
                DetailsDataSearch(ref dataCnt, 0);

                // ��ʃN���A����
                ScreenClear();
                // ��ʏ����ݒ菈��
                ScreenInitialSetting();
                // ��ʍč\�z����
                ScreenReconstruction();
            }
            else
            {
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
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;

            this._targetTableName = "";

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
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="control">�R���g���[��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
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

            switch (TargetTableName)
            {
                // �[���ԍ��e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �`�[����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        control = this.tComboEditor1;
                        break;
                    }
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
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
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
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
        }

        /// <summary>
        /// ��ʓ��͏��ۑ�����
        /// </summary>
        /// <returns></returns>
        private bool SaveCustSlipNoSet()
        {
            //==========================
            // �������ݏ���
            //==========================
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            CustSlipNoSet custSlipNoSet = new CustSlipNoSet();
            Control control = null;

            // ���׍���
            DispToCustSlipNoSet(ref custSlipNoSet);

            // ��������
            string message;

            // �X�V�̏ꍇ�쐬���t�ݒ�
            if (this.Mode_Label.Text == UPDATE_MODE)
            {
                // �ύX�O�X�V�f�[�^�擾
                DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];
                CustSlipNoSet custSlipNoSetPre = null;

                status = this._custSlipNoSetAcs.GetSlipOutputSet(CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                 CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                 out custSlipNoSetPre,
                                                                 out message);

                // �X�V�ɕK�v�ȏ���DataTable����ăZ�b�g
                custSlipNoSet.CreateDateTime = custSlipNoSetPre.CreateDateTime;
                custSlipNoSet.UpdateDateTime = custSlipNoSetPre.UpdateDateTime;
                custSlipNoSet.FileHeaderGuid = custSlipNoSetPre.FileHeaderGuid;
            }

            status = this._custSlipNoSetAcs.Write(ref custSlipNoSet, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash�X�V����
                        DetailsToDataSet(custSlipNoSet, this._detailsDataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �d������
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._custSlipNoSetAcs);
                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();
                        return false;
                    }
                default:
                    {
                        emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                        }

                        TMsgDisp.Show(this,                                // �e�E�B���h�E�t�H�[��
                                       emErrLvl,                            // �G���[���x��
                                       ASSEMBLY_ID,                       // �A�Z���u���h�c�܂��̓N���X�h�c
                                       //"�[���ʓ`�[�o�͐�ݒ�", 	            		    // �v���O��������   // DEL 2009/04/28
                                       "���Ӑ�ݒ�(�`�[�ݒ�)",             // �v���O��������       // ADD 2009/04/28
                                       "SaveDispData", 	                    // ��������
                                       TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                                       message,                             // �\�����郁�b�Z�[�W
                                       status,  							// �X�e�[�^�X�l
                                       this._custSlipNoSetAcs,               // �G���[�����������I�u�W�F�N�g
                                       MessageBoxButtons.OK,                // �\������{�^��
                                       MessageBoxDefaultButton.Button1);	// �����I���{�^��

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return false;
                    }
            }
            // �V�K�o�^������
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// �f�[�^�ύX�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N���ʁitrue:�ύX�L��, false:�ύX�����j</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ύX�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private bool CompareData()
        {
            bool retBool = false;
            int chkCnt = 0;
            DataRow dr = this._dataTableClone.Rows[0];

            chkCnt += CustSlipNoSetAcs.NullChgInt(this.PresentCustSlipNo_tNedit.Value)
                        == CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE]) ? 0 : 1;

            chkCnt += CustSlipNoSetAcs.NullChgInt(this.StartCustSlipNo_tNedit.Value)
                        == CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE]) ? 0 : 1;

            chkCnt += CustSlipNoSetAcs.NullChgInt(this.EndCustSlipNo_tNedit.Value)
                        == CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE]) ? 0 : 1;
            
            // --- DEL 2008/09/22 -------------------------------->>>>>
            //chkCnt += CustSlipNoSetAcs.NullChgStr(this.CustSlipNoHeader_tEdit.Value)
            //            == CustSlipNoSetAcs.NullChgStr(dr[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE]) ? 0 : 1;

            //chkCnt += CustSlipNoSetAcs.NullChgStr(this.CustSlipNoFooter_tEdit.Value)
            //            == CustSlipNoSetAcs.NullChgStr(dr[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE]) ? 0 : 1;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            // �ύX�L��
            if (chkCnt > 0)
            {
                retBool = true;
            }
            return retBool;
        }

        /// <summary>
        /// �R���{�{�b�N�X�p�f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <param name="wkTable">�f�[�^�e�[�u��</param>
        /// <br>Note       : �R���{�{�b�N�X�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataTblColumnComboInt(ref DataTable wkTable)
        {
            wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// �R�[�h
            wkTable.Columns.Add(COMBO_NAME, typeof(string));	// ����

            // �v���C�}���L�[�ݒ�
            wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
        }


        /// <summary>
        /// �R���{�{�b�N�X�p�f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <param name="wkTable">�f�[�^�e�[�u��</param>
        /// <br>Note       : �R���{�{�b�N�X�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataTblColumnComboStr(ref DataTable wkTable)
        {
            // �R���{�{�b�N�X�\������
            wkTable.Columns.Add(COMBO_CODE, typeof(string));	// �R�[�h
            wkTable.Columns.Add(COMBO_NAME, typeof(string));	// ����

            // �v���C�}���L�[�ݒ�
            wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
        }

        /// <summary>
        /// �R���{�{�b�N�X�f�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <param name="sList">�\�[�g���X�g</param>
        /// <param name="dataTable">�f�[�^�e�[�u��</param>
        /// <br>Note       : �R���{�{�b�N�X�f�[�^��ݒ肵�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void SetComboDataInt(ref SortedList sList, ref DataTable dataTable)
        {
            try
            {
                foreach (DictionaryEntry de in sList)
                {
                    DataRow dr = dataTable.NewRow();

                    dr[COMBO_CODE] = (Int32)de.Key;
                    dr[COMBO_NAME] = de.Value.ToString();

                    dataTable.Rows.Add(dr);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// �R���{�{�b�N�X�o�C���h
        /// </summary>
        /// <remarks>
        /// <param name="tCombo">TComboEditor</param>
        /// <param name="dataTable">�f�[�^�e�[�u��</param>
        /// <br>Note       : �R���{�{�b�N�X�Ƀo�C���h���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
        {
            tCombo.DisplayMember = COMBO_NAME;
            tCombo.DataSource = dataTable.DefaultView;
        }

        #endregion

        #region Events
        /// <summary>
        /// �t�H�[�����[�h�E�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMKHN09100UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Delete_Button.ImageList = imageList25;
            this.Ok_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.tComboEditor1.Items.Clear();   // ADD 2009/06/19
            this.tComboEditor1.Items.Add(0, EXTRACTION_DIVISION1);
            this.tComboEditor1.Items.Add(0, EXTRACTION_DIVISION2);
            this.tComboEditor1.Items.Add(0, EXTRACTION_DIVISION3);
            this.tComboEditor1.SelectedIndex = 0;
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)(SF100%���p)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B</br>
        ///	<br>             ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��</br>
        ///	<br>             �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(MAKHN09810UA)(SF100%���p)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void PMKHN09100UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // ��ʃN���A
            ScreenClear();

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �폜�m�F
            DialogResult result = TMsgDisp.Show(
                                       this,                                // �e�E�B���h�E�t�H�[��
                                       emErrorLevel.ERR_LEVEL_EXCLAMATION,  // �G���[���x��
                                       ASSEMBLY_ID,                       // �A�Z���u���h�c�܂��̓N���X�h�c
                                       "�f�[�^���폜���܂��B" + "\r\n" +
                                       "��낵���ł����H",                  // �\�����郁�b�Z�[�W
                                       0, 									// �X�e�[�^�X�l
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxDefaultButton.Button2);	// �\������{�^��
            if (result != DialogResult.OK)
            {
                // OK�ȊO�̎��͏I��
                this.Delete_Button.Focus();
                return;
            }

            //==========================
            // �ȍ~�폜����
            //==========================
            if (result == DialogResult.OK)
            {
                switch (this._targetTableName)
                {
                    // ����e�[�u���̏ꍇ
                    case MAIN_TABLE:
                        {
                            break;
                        }
                    // �[���ʓ`�[�o�͐�e�[�u���̏ꍇ
                    case DETAILS_TABLE:
                        {
                            // ���啨���폜
                            PhysicalDeleteSlipOutputSet();
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // ADD 2008/12/02 �s��Ή�[8565] ---------->>>>>
            // ����
            DialogResult result = TMsgDisp.Show(
                                       this,                                // �e�E�B���h�E�t�H�[��
                                       emErrorLevel.ERR_LEVEL_EXCLAMATION,  // �G���[���x��
                                       ASSEMBLY_ID,                       // �A�Z���u���h�c�܂��̓N���X�h�c
                                       "���ݕ\�����̓��Ӑ�𕜊����܂��B" + "\r\n" +
                                       "��낵���ł����H",
                                       0, 									// �X�e�[�^�X�l
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxDefaultButton.Button2);	// �\������{�^��
            if (result != DialogResult.OK)
            {
                // OK�ȊO�̎��͏I��
                this.Revive_Button.Focus();
                return;
            }
            // ADD 2008/12/02 �s��Ή�[8565] ----------<<<<<

            ReviveCustSlipNoSet();
        }

        /// <summary>
        /// Control.Click �C�x���g(OK_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // �V�K�͕K���ۑ��������s��
                flag = true;
            }
            else
            {
                // �X�V���͕ύX�_������Εۑ��������s��
                flag = CompareData();
            }

            if (flag == true)
            {
                SaveProc(this._targetTableName);
            }
            else
            {
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
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //============================
            // �ۑ��m�F
            //============================
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                bool change = false;

                // �폜���[�h�ȊO�̎��́A�ۑ��m�F
                if (_targetTableName == MAIN_TABLE)
                {
                    // ��MAIN_TABLE�̍X�V�͖�����
                }
                else
                {
                    // �ύX�_��r
                    change = CompareData();
                }

                if (change)
                {
                    // �ύX���� -> �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                                           this, 								// �e�E�B���h�E�t�H�[��
                                           emErrorLevel.ERR_LEVEL_SAVECONFIRM,  // �G���[���x��
                                           ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                           null, 								// �\�����郁�b�Z�[�W
                                           0, 									// �X�e�[�^�X�l
                                           MessageBoxButtons.YesNoCancel);	    // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc(this._targetTableName))
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                Cancel_Button.Focus();
                                return;
                            }
                    }
                }
            }

            //============================
            // ��ʃN���[�Y(��\��)
            //============================
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
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
        /// Form.Closing �C�x���g(PMKHN09100UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void PMKHN09100UA_Closing(object sender, FormClosingEventArgs e)
        {
            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        #endregion

        #region ���Ӑ�ݒ�(�`�[�ݒ�)�N���X��ʓW�J����
        /// <summary>
        /// ���Ӑ�ݒ�(�`�[�ݒ�)�N���X��ʓW�J����
        /// </summary>
        /// <param name="row">�f�[�^���E</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataRowToScreen(DataRow row)
        {
            //-----------------------------------------------
            // Main�����Second�O���b�h����擾
            //-----------------------------------------------
            // ���Ӑ�R�[�h
            //this.tNedit_CustomerCode.Text = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE].ToString(); //DEL 2008/09/22
            this.tNedit_CustomerCode.SetInt((int)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERCODE_TITLE]); //ADD 2008/09/22 
            // ���Ӑ旪��
            this.uLabel_CustomerName.Text = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][CustSlipNoSetAcs.CUSTOMERNAME_TITLE].ToString();

            //-----------------------------------------------
            // ��ʓ��͂���擾
            //-----------------------------------------------

            if (CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]) == 0)
            {
                this.tComboEditor1.Text = EXTRACTION_DIVISION1;
            }
            else if (CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]) > 0 && CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]) < 10000)
            {
                this.tComboEditor1.Text = EXTRACTION_DIVISION3;

                this.tDateEdit1.LongDate = int.Parse(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].ToString().PadRight(8,'0'));
            }
            else
            {
                this.tComboEditor1.Text = EXTRACTION_DIVISION2;

                tDateEdit1.LongDate = int.Parse(row[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].ToString().PadRight(8,'0'));

            }
            // DEL 2008/12/02 �s��Ή�[8654] ---------->>>>>
            //// ���ݓ��Ӑ�`�[�ԍ�
            //this.PresentCustSlipNo_tNedit.Value = CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE]);
            //// �J�n���Ӑ�`�[�ԍ�
            //this.StartCustSlipNo_tNedit.Value = CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE]);
            //// �I�����Ӑ�`�[�ԍ�
            //this.EndCustSlipNo_tNedit.Value = CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE]);
            // DEL 2008/12/02 �s��Ή�[8654] ----------<<<<<

            // ADD 2008/12/02 �s��Ή�[8654] ---------->>>>>
            // ���ݓ��Ӑ�`�[�ԍ�
            this.PresentCustSlipNo_tNedit.SetInt(CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE]));
            // �J�n���Ӑ�`�[�ԍ�
            this.StartCustSlipNo_tNedit.SetInt(CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE]));
            // �I�����Ӑ�`�[�ԍ�
            this.EndCustSlipNo_tNedit.SetInt(CustSlipNoSetAcs.NullChgInt(row[CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE]));
            // ADD 2008/12/02 �s��Ή�[8654] ----------<<<<<

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// ���Ӑ�`�[�ԍ��w�b�_
            //this.CustSlipNoHeader_tEdit.Value = CustSlipNoSetAcs.NullChgStr(row[CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE]);
            //// ���Ӑ�`�[�ԍ��t�b�^
            //this.CustSlipNoFooter_tEdit.Value = CustSlipNoSetAcs.NullChgStr(row[CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE]);
            // --- DEL 2008/09/22 --------------------------------<<<<<

        }
        #endregion

        #region �f�[�^�Z�b�g�X�V
        /// <summary>
        /// �f�[�^�Z�b�g�X�V�����i�c�a�X�V��\�����e�ɔ��f������j
        /// </summary>
        /// <param name="slipOutputSet">�`�[����ݒ�N���X</param>
        /// <param name="index">�C���f�b�N�X</param>
        private void DetailsToDataSet(CustSlipNoSet custSlipNoSet, int index)
        {
            if ((index < 0) || (this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this._bindDataSet.Tables[DETAILS_TABLE].NewRow();

                //--------------
                // �L�[���ڐݒ�
                //--------------
                // �[���ԍ�
                dataRow[CustSlipNoSetAcs.CUSTOMERCODE_TITLE] = custSlipNoSet.CustomerCode;
                // �f�[�^���̓V�X�e��
                dataRow[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = custSlipNoSet.AddUpYearMonth;

                this._bindDataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (custSlipNoSet.LogicalDeleteCode == 0)
            {
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.DELETE_DATE_TITLE] = "";
            }
            else
            {
                this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.DELETE_DATE_TITLE] = custSlipNoSet.UpdateDateTimeJpInFormal;
            }


            // �[���ԍ�
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE] = custSlipNoSet.AddUpYearMonth;

            // �q�ɃR�[�h
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.PRESENTCUSTSLIPNO_TITLE] = custSlipNoSet.PresentCustSlipNo;
            // �q�ɖ���
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.STARTCUSTSLIPNO_TITLE] = custSlipNoSet.StartCustSlipNo;
            // �`�[������
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.ENDCUSTSLIPNO_TITLE] = custSlipNoSet.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// �`�[����ݒ�p���[ID
            //this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.CUSTSLIPNOHEADER_TITLE] = custSlipNoSet.CustSlipNoHeader;
            //// �v�����^�Ǘ�No
            //this._bindDataSet.Tables[DETAILS_TABLE].Rows[index][CustSlipNoSetAcs.CUSTSLIPNOFOOTER_TITLE] = custSlipNoSet.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

        }

        /// <summary>
        /// �f�[�^�Z�b�g�폜�����i�c�a�X�V��\�����e�ɔ��f������j
        /// </summary>
        /// <param name="slipOutputSet">�`�[����ݒ�N���X</param>
        /// <param name="index">�C���f�b�N�X</param>
        private void DeleteFromDataSet(CustSlipNoSet custSlipNoSet, int index)
        {
            // �f�[�^�Z�b�g����s�폜���܂�
            this._bindDataSet.Tables[DETAILS_TABLE].Rows[index].Delete();
        }
        #endregion

        #region LogicalDelete
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int LogicalDeleteSlipOutputSet()
        {
            CustSlipNoSet custSlipNoSet;
            string message;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //================================
            // �폜���\���ŏI�m�F
            //================================
            if (this._detailsDataIndex < 0)
            {
                // ���I��
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // �폜�\��f�[�^�擾
            DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

            status = this._custSlipNoSetAcs.GetSlipOutputSet(   CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                out custSlipNoSet,
                                                                out message);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // PG�~�X
                TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                               emErrorLevel.ERR_LEVEL_INFO,     	// �G���[���x��
                               ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                               "���׍��ڂ��q�b�g���܂���B",        // �\�����郁�b�Z�[�W
                               0, 		                            // �X�e�[�^�X�l
                               MessageBoxButtons.OK, 				// �\������{�^��
                               MessageBoxDefaultButton.Button1);	// �����\���{�^��

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //==========================
            // �I���f�[�^���폜
            //==========================
            status = this._custSlipNoSetAcs.LogicalDelete(ref custSlipNoSet, out message);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�e�[�u���č\�z
                DetailsToDataSet(custSlipNoSet, this._detailsDataIndex);
            }

            return status;
        }
        #endregion

        #region PhysicalDelete
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int PhysicalDeleteSlipOutputSet()
        {
            CustSlipNoSet custSlipNoSet;
            string message;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //================================
            // �폜���\���ŏI�m�F
            //================================
            if (this._detailsDataIndex < 0)
            {
                // ���I��
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // �폜�\��f�[�^�擾
            DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

            status = this._custSlipNoSetAcs.GetSlipOutputSet(   CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                out custSlipNoSet,
                                                                out message);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // PG�~�X
                TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                               emErrorLevel.ERR_LEVEL_INFO,     	// �G���[���x��
                               ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                               "���׍��ڂ��q�b�g���܂���B",        // �\�����郁�b�Z�[�W
                               0, 		                            // �X�e�[�^�X�l
                               MessageBoxButtons.OK, 				// �\������{�^��
                               MessageBoxDefaultButton.Button1);	// �����\���{�^��

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //==========================
            // �I���f�[�^���폜
            //==========================
            status = this._custSlipNoSetAcs.Delete(ref custSlipNoSet, out message);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�e�[�u���č\�z
                DeleteFromDataSet(custSlipNoSet, this._detailsDataIndex);
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
            return status;
        }
        #endregion

        #region Revive
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int ReviveCustSlipNoSet()
        {
            int status = 0;
            CustSlipNoSet custSlipNoSet;
            string message;

            // �����Ώێ擾
            DataRow dr = this._bindDataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex];

            status = this._custSlipNoSetAcs.GetSlipOutputSet(   CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.CUSTOMERCODE_TITLE]),
                                                                CustSlipNoSetAcs.NullChgInt(dr[CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE]),
                                                                out custSlipNoSet,
                                                                out message);
            // ����
            status = this._custSlipNoSetAcs.Revival(ref custSlipNoSet, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        DetailsToDataSet(custSlipNoSet, this._detailsDataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._detailsDataIndex);
                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ReviveSlipOutputSet",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._custSlipNoSetAcs,    			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
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
            return status;
        }
        #endregion

        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {

                case "tNedit_CustomerCode":
                    {
                        if (tNedit_CustomerCode.GetInt() == 0) return;

                        CustomerInfo customerInfo;

                        int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, tNedit_CustomerCode.GetInt(), true, out customerInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �e���𔻒肵�A�q�̏ꍇ�͗^�M�z�E�x���^�M�z�E���ݔ��|�c���͓��͕s��
                            if (customerInfo.ClaimCode != tNedit_CustomerCode.GetInt())
                            {
                                this.PresentCustSlipNo_tNedit.Enabled = false;
                                this.StartCustSlipNo_tNedit.Enabled = false;
                                this.EndCustSlipNo_tNedit.Enabled = false;
                            }
                            else
                            {
                                this.PresentCustSlipNo_tNedit.Enabled = true;
                                this.StartCustSlipNo_tNedit.Enabled = true;
                                this.EndCustSlipNo_tNedit.Enabled = true;
                            }
                            this.PresentCustSlipNo_tNedit.Text = "0";
                            this.StartCustSlipNo_tNedit.Text = "0";
                            this.EndCustSlipNo_tNedit.Text = "0";
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                                status,
                                MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        else
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_STOPDISP,
                                          this.Name,
                                          "���Ӑ���̎擾�Ɏ��s���܂����B",
                                          status,
                                          MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }

                        this.tNedit_CustomerCode.Text = customerInfo.CustomerCode.ToString().Trim();
                        this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // ����
                        break;
                    }
            }

            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "PresentCustSlipNo_tNedit":    // ���ݓ��Ӑ�`�[�ԍ�
                case "StartCustSlipNo_tNedit":      // �J�n���Ӑ�`�[�ԍ�
                case "EndCustSlipNo_tNedit":        // �I�����Ӑ�`�[�ԍ�
                    {
                        if (this._detailsDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tComboEditor1;

                            }
                        }
                        break;
                    }
            }
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        /// <summary>
        /// ���o�敪�I��ύX���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���o�敪��ύX���ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private void tComboEditor1_SelectionChanged(object sender, EventArgs e)
        {
            if (tComboEditor1.SelectedIndex == 0)
            {
                this.tDateEdit1.Clear();

                this.tDateEdit1.Enabled = false;
            }
            else if (tComboEditor1.SelectedIndex == 1)
            {
                this.tDateEdit1.Clear();

                this.tDateEdit1.DateFormat = emDateFormat.df4Y2M;

                if (this.tComboEditor1.Enabled == true)
                {
                    this.tDateEdit1.Enabled = true;
                }
            }
            else if (tComboEditor1.SelectedIndex == 2)
            {
                this.tDateEdit1.Clear();

                this.tDateEdit1.DateFormat = emDateFormat.df4Y;

                if (this.tComboEditor1.Enabled == true)
                {
                    this.tDateEdit1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// �v��N��Leave���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �v��N������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void tDateEdit1_Leave(object sender, EventArgs e)
        {
            if (tDateEdit1.DateFormat == emDateFormat.df4Y2M)
            {
                this.tDateEdit1.LongDate += 1;
            }
            else if (tDateEdit1.DateFormat == emDateFormat.df4Y)
            {
                this.tDateEdit1.LongDate += 101; 
            }
        }

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����(���Ӑ��)
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���o�敪
            int selIdx = tComboEditor1.SelectedIndex;
            // ���Ӑ�R�[�h
            int customerCode = tNedit_CustomerCode.GetInt();
            // �v��N��
            int addUpDate = 0;
            if (selIdx != 0)
            {
                if (selIdx == 1)
                {
                    addUpDate = (tDateEdit1.GetDateYear() * 100) + tDateEdit1.GetDateMonth();
                }
                else if (selIdx == 2)
                {
                    addUpDate = tDateEdit1.GetDateYear();
                }

                if (addUpDate == 0)
                {
                    // �v��N����������
                    return false;
                }
            }

            for (int i = 0; i < this._bindDataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCustomerCode = (int)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][CustSlipNoSetAcs.CUSTOMERCODE_TITLE];
                int dsAddUpDate = 0;
                string strAddUpDate = this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][CustSlipNoSetAcs.ADDUPYEARMONTH_TITLE].ToString().Trim();
                if (strAddUpDate != string.Empty)
                {
                    dsAddUpDate = int.Parse(strAddUpDate);
                }
                if ((customerCode == dsCustomerCode) &&
                    (addUpDate == dsAddUpDate))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._bindDataSet.Tables[DETAILS_TABLE].Rows[i][CustSlipNoSetAcs.DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓��Ӑ�`�[�ԍ����͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���o�敪�A�v��N���̃N���A
                        tComboEditor1.SelectedIndex = 0;
                        tDateEdit1.DateFormat = emDateFormat.df4Y2M;
                        tDateEdit1.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̓��Ӑ�`�[�ԍ���񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���o�敪�A�v��N���̃N���A
                                tComboEditor1.SelectedIndex = 0;
                                tDateEdit1.DateFormat = emDateFormat.df4Y2M;
                                tDateEdit1.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // DEL 2008/12/03 �s��Ή�[8563] ---------->>>>>
        //// ADD 2008/12/02 �s��Ή�[8563] ---------->>>>>
        //private void tDateEdit1_ValueChanged(object sender, EventArgs e)
        //{
        //    //if (this.tDateEdit1.GetDateDay() != 0)
        //    //{
        //    //    //this.tDateEdit1.SetLongDate(Int32.Parse(this.tDateEdit1.GetLongDate().ToString().Substring(0, 6) + "00"));
        //    //    this.PresentCustSlipNo_tNedit.Focus();
        //    //}
        //}
        //// ADD 2008/12/02 �s��Ή�[8563] ----------<<<<<
        // DEL 2008/12/03 �s��Ή�[8563] ----------<<<<<

    }
}