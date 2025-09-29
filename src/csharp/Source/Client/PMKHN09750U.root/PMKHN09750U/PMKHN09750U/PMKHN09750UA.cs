//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �D��q�Ƀ}�X�^
// �v���O�����T�v   : �D��q�ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : huangt
// �� �� ��  K2013/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : huangt
// �C �� ��  K2013/10/08  �C�����e : #40626 �t�^�o_�V�X�e����Q�ɂ���
//                                   No.82 �����t�H�[�J�X�̉��C
//                                   No.83 �s�폜�`�F�b�N�̉��C
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
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �D��q�Ƀ}�X�^UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �D��q�Ƀ}�X�^��UI�ݒ���s���܂��B</br>
    /// <br>Programmer	: huangt</br>
    /// <br>Date		: K2013/09/10</br>
    /// </remarks>
    public partial class PMKHN09750UA : Form, IMasterMaintenanceArrayType
    {
        #region �� Constants

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKHN09750U";

        // �e�[�u������
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // �f�[�^�r���[�^�C�g��
        private const string GRIDTITLE_SECTION = "���_";
        private const string GRIDTITLE_WAREHOUSE = "�q��";

        // �f�[�^�r���[�\���p
        private const string MAIN_DELETEDATE = "�폜��";
        private const string MAIN_SECTIONCODE = "���_�R�[�h";
        private const string MAIN_SECTIONGUID = "���_���GUID";
        private const string MAIN_SECTIONNAME = "���_����";

        private const string DETAIL_DELETEDATE = "�폜��";
        private const string DETAIL_WAREHOUSECODE = "�q�ɃR�[�h";
        private const string DETAIL_WAREHOUSENAME = "�q�ɖ���";
        private const string DETAIL_WAREHOUSEGUID = "�q�ɏ��GUID";
        private const string DETAIL_UPDATETIME = "�X�V����";
        private const string DETAIL_WAREHPROTYODR = "�D�揇��";

        // �O���b�h�p�f�[�^�e�[�u��
        private const string TABLE_WAREHOUSEGRID = "WarehouseGrid";

        // �O���b�h��^�C�g��
        private const string COLUMN_WAREHPROTYODR = "WarehProtyOdr";
        private const string COLUMN_WAREHOUSECODE = "WarehouseCode";
        private const string COLUMN_WAREHOUSEGUIDE = "WarehouseGuide";
        private const string COLUMN_WAREHOUSENAME = "WarehouseName";
        private const string COLUMN_UPDATETIME = "UpdateTime";
        private const string COLUMN_SCREENID = "ScreenId";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        #endregion �� Constants

        #region �� Private Members

        // �v���p�e�B�p
        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;
        private MGridDisplayLayout _defaultGridDisplayLayout;

        // �I���f�[�^�C���f�b�N�X
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailDataIndex;

        // UI�O���b�h�p�f�[�^�e�[�u��
        private DataTable _bindTable;

        // Grid��IndexBuffer�i�[�p�ϐ�
        private int _mainIndexBuffer;
        private int _detailsIndexBuffer;
        private string _targetTableBuffer;

        // Grid�ύX�t���O
        private bool _gridUpdFlg = true;

        // ��ƃR�[�h
        private string _enterpriseCode;
        private Hashtable _mainTable;
        private Hashtable _detailTable;
        private Hashtable _detailCloneTable;

        // ���_���擾�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        // �q�ɃK�C�h
        private WarehouseAcs _warehouseGuideAcs = null;

        // �D��q�Ƀ}�X�^�@�A�N�Z�X�N���X
        private ProtyWarehouseAcs _protyWarehouseAcs;

        private Dictionary<string , SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Warehouse> _warehouseInfoDic;

        private ControlScreenSkin _controlScreenSkin;            // ��ʃf�U�C���ύX�N���X
        private ProtyWarehouse[] _protyWarehouseListClone;       // �D��q�Ƀ}�X�^���X�gClone

        private bool _canChangeMode = false;

        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// �D��q�Ƀ}�X�^�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �D��q�Ƀ}�X�^UI�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        public PMKHN09750UA()
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

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseGuideAcs = new WarehouseAcs();

            this._protyWarehouseAcs = new ProtyWarehouseAcs();

            this._controlScreenSkin = new ControlScreenSkin();
            this._protyWarehouseListClone = new ProtyWarehouse[1];

            // DataSet����\�z
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();

            this._mainTable = new Hashtable();
            this._detailTable = new Hashtable();
            this._detailCloneTable = new Hashtable();

            this._bindTable = new DataTable(TABLE_WAREHOUSEGRID);

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

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
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SECTION, GRIDTITLE_WAREHOUSE };
            return gridTitle;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList logDelList = new ArrayList();
            ProtyWarehouse protyWarehouse = new ProtyWarehouse();

            int maxRow = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[i][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();
                logDelList.Add(protyWarehouse);
            }

            status = this._protyWarehouseAcs.LogicalDelete(ref logDelList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);
                        return status;
                    }
                case -2:
                    {
                        //���Ɛݒ�Ŏg�p��
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        // �_���폜�����̎��s
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Delete",
                                       "�_���폜���s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            int index = 0;
            int logDelCnt = 0;         // 0�̓��C��Grid���A0�ȊO�͏ڍ�Grid���
            // �_���폜���R�[�h��DataSet�ɔ��f
            foreach (ProtyWarehouse wkPartsPosCodeU in logDelList)
            {
                if (logDelCnt == 0)
                {
                    index = this._mainDataIndex;
                    MainToDataSet(wkPartsPosCodeU.Clone(), index);
                }

                DetailToDataSet(wkPartsPosCodeU.Clone(), logDelCnt++);
            }
            return status;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // ���C��
            //==============================
            Hashtable main = new Hashtable();
            // �폜��
            main.Add(MAIN_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���_�R�[�h
            main.Add(MAIN_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
            main.Add(MAIN_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_���GUID
            main.Add(MAIN_SECTIONGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // �ڍ�
            //==============================
            Hashtable detail = new Hashtable();

            // �폜��
            detail.Add(DETAIL_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // �D�揇��
            detail.Add(DETAIL_WAREHPROTYODR, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �q�ɃR�[�h
            detail.Add(DETAIL_WAREHOUSECODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �q�ɖ���
            detail.Add(DETAIL_WAREHOUSENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �q�ɏ��GUID
            detail.Add(DETAIL_WAREHOUSEGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // �X�V����
            detail.Add(DETAIL_UPDATETIME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = main;
            appearanceTable[1] = detail;
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList retList;

            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();
            this._detailTable.Clear();

            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;

            // �I������Ă���f�[�^���擾����
            string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][MAIN_SECTIONCODE];

            // ���������i�_���폜�܂ށj
            int status = this._protyWarehouseAcs.Read(out retList, this._enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�����N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (ProtyWarehouse protyWarehouse in retList)
                        {
                            // DataSet�W�J����
                            DetailToDataSet(protyWarehouse, index);
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

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            ArrayList protyWarehouseList;

            int status = this._protyWarehouseAcs.Search(out protyWarehouseList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        List<string> sectionCodeList = new List<string>();
                        int index = 0;

                        // �o�b�t�@�ێ�
                        foreach (ProtyWarehouse protyWarehouse in protyWarehouseList)
                        {
                            if (!sectionCodeList.Contains(protyWarehouse.SectionCode.Trim()))
                            {
                                sectionCodeList.Add(protyWarehouse.SectionCode.Trim());
                                // �D��q�ɐݒ���N���X�̃f�[�^�Z�b�g�W�J����
                                MainToDataSet(protyWarehouse.Clone(), index);
                                ++index;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
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

            totalCount = this._mainTable.Count;

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // ������
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public int Print()
        {
            // ������
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            ArrayList secInfoList;

            if (this._secInfoSetAcs == null)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }

            // ���_�����擾
            int status = this._secInfoSetAcs.SearchAll(out secInfoList, this._enterpriseCode);

            if (status == 0)
            {
                foreach (SecInfoSet secInfoSet in secInfoList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            else
            {

                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_STOPDISP,
                this.Name,
                "���_���擾�Ɏ��s���܂����B",
                status,
                MessageBoxButtons.OK);
   
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// �q�ɖ��̎擾����
        /// </summary>
        /// <param name="warehousecode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void ReadWarehouseInfo()
        {
            this._warehouseInfoDic = new Dictionary<string, Warehouse>();

            ArrayList warehouseList;

            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // �q�ɏ��擾
            int status = this._warehouseGuideAcs.Search(out warehouseList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (Warehouse warehouse in warehouseList)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        this._warehouseInfoDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                    }
                }
            }
            else
            {

                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_STOPDISP,
                this.Name,
                "�q�ɏ��擾�Ɏ��s���܂����B",
                status,
                MessageBoxButtons.OK);
   
            }
        }

        /// <summary>
        /// �q�ɖ��擾����
        /// </summary>
        /// <param name="customerCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ�</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseInfoDic.ContainsKey(warehouseCode.PadLeft(4, '0')))
            {
                warehouseName = this._warehouseInfoDic[warehouseCode.PadLeft(4, '0')].WarehouseName.Trim();
            }

            return warehouseName;
        }

        /// <summary>
        /// �q�ɗD�揇���ݒ肳�ꂽ�̏ꍇ
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <br>Note       : �`�F�b�N�����s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private bool CheckMainIndex()
        { 
            bool checkFlg = false;

            int totalCount = 0;
            // �Č���
            Search(ref totalCount, 0);

            if (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count > 0)
            {
                int count = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count;
                for (int index = 0; index < count; index++)
                {
                    // �q�ɗD�揇���ݒ肳�ꂽ�̏ꍇ�A�V�K�{�^���N���b�N�s��
                    string deleteDate = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_DELETEDATE];
                    string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONCODE];
                    if (string.IsNullOrEmpty(deleteDate))
                    {
                        checkFlg = true;
                        if (this.tEdit_SectionCode.DataText.Trim() != "" && this.tEdit_SectionCode.DataText.Trim().Equals(sectionCode))
                        {
                            checkFlg = false;
                        }
                    }
                }
            }

            if (checkFlg)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                  "�����o�^�ł��܂���B�C�����́A�폜��ɓo�^���ĉ������B",
                                  0,
                                  MessageBoxButtons.OK,
                                  MessageBoxDefaultButton.Button1);

                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                    UnDisplaying(this, me);
                }

                this.DialogResult = DialogResult.Cancel;

                // Grid��IndexBuffer�i�[�p�ϐ�������
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;
                this._targetTableBuffer = "";

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

            return true;
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���_
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            // Grid�s�̃N���A
            this._bindTable.Rows.Clear();
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �}�X�^�Ǎ�
            ReadSecInfoSet();

            ReadWarehouseInfo();

            // �X�L�[�}�̐ݒ� 
            DataTableSchemaSetting();

            // GRID�̏����ݒ�
            GridInitialSetting();
        }

        /// <summary>
        /// �O���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private void DataTableSchemaSetting()
        {
            _bindTable.Columns.Clear();

            // �X�L�[�}�̐ݒ�
            _bindTable.Columns.Add(COLUMN_SCREENID, typeof(int));
            _bindTable.Columns.Add(COLUMN_WAREHPROTYODR, typeof(string));
            _bindTable.Columns.Add(COLUMN_WAREHOUSECODE, typeof(string));
            _bindTable.Columns.Add(COLUMN_WAREHOUSEGUIDE, typeof(Guid));
            _bindTable.Columns.Add(COLUMN_WAREHOUSENAME, typeof(string));
            _bindTable.Columns[COLUMN_WAREHOUSEGUIDE].Caption = "";

        }

        /// <summary>
        ///	UI��ʂ�GRID�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // �f�[�^�\�[�X�֒ǉ�
            this.uGrid_ProtyWarehouse.DataSource = _bindTable;

            // GRID����
            // �O���b�h�̔w�i
            AppearanceBase appearance = this.uGrid_ProtyWarehouse.DisplayLayout.Appearance;
            // �^�C�g���̊O��
            AppearanceBase headerAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.HeaderAppearance;
            // �I���s�̊O��
            AppearanceBase selectedRowAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.SelectedRowAppearance;
            // �A�N�e�B�u�s�̊O��
            AppearanceBase activeRowAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.ActiveRowAppearance;
            // �s�Z���N�^�̊O��
            AppearanceBase rowSelectorAppearance = this.uGrid_ProtyWarehouse.DisplayLayout.Override.RowSelectorAppearance;
            // ���ʑ���
            UltraGridOverride ultraGridOverride = this.uGrid_ProtyWarehouse.DisplayLayout.Override;
            // �O���b�h��
            ColumnsCollection columns = this.uGrid_ProtyWarehouse.DisplayLayout.Bands[0].Columns;
            
            // �O���b�h�̔w�i�F
            appearance.BackColor = Color.White;
            appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // �r���̐F��ύX
            appearance.BorderColor = Color.FromArgb(1, 68, 208);

            // �s�̒ǉ��s��
            ultraGridOverride.AllowAddNew = AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            ultraGridOverride.RowSizing = RowSizing.Fixed;
            // �s�̍폜��
            ultraGridOverride.AllowDelete = DefaultableBoolean.True;
            // ��̈ړ��s��
            ultraGridOverride.AllowColMoving = AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            ultraGridOverride.AllowColSizing = AllowColSizing.None;
            // ��̌����s��
            ultraGridOverride.AllowColSwapping = AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            ultraGridOverride.AllowRowFiltering = DefaultableBoolean.False;

            // �^�C�g���̊O�ϐݒ�
            headerAppearance.BackColor = Color.FromArgb(89, 135, 214);
            headerAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            headerAppearance.BackGradientStyle = GradientStyle.Vertical;
            headerAppearance.ForeColor = Color.White;
            headerAppearance.ThemedElementAlpha = Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            ultraGridOverride.SelectTypeCol = SelectType.None;
            ultraGridOverride.SelectTypeRow = SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            ultraGridOverride.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\������
            ultraGridOverride.RowSelectors = DefaultableBoolean.True;

            ultraGridOverride.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            ultraGridOverride.ActiveCellAppearance.TextVAlign = VAlign.Middle;
            ultraGridOverride.EditCellAppearance.TextVAlign = VAlign.Middle;
            ultraGridOverride.CellAppearance.TextVAlign = VAlign.Middle;

            // �I���s�̊O�ϐݒ�
            selectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            selectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            selectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            selectedRowAppearance.ForeColor = Color.Black;
            selectedRowAppearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
            selectedRowAppearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�
            activeRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            activeRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            activeRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            activeRowAppearance.ForeColor = Color.Black;
            activeRowAppearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
            activeRowAppearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);

            // �s�Z���N�^�̊O�ϐݒ�
            rowSelectorAppearance.BackColor = Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            rowSelectorAppearance.BackColor2 = Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            rowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �w�b�_�[�L���v�V����
            columns[COLUMN_WAREHPROTYODR].Header.Caption = "�D�揇��";
            columns[COLUMN_WAREHOUSECODE].Header.Caption = "�q�ɃR�[�h";
            columns[COLUMN_WAREHOUSEGUIDE].Header.Caption = "";
            columns[COLUMN_WAREHOUSENAME].Header.Caption = "�q�ɖ���";

            // �q�ɗD�揇�ʗ�̐ݒ�
            columns[COLUMN_WAREHPROTYODR].CellActivation = Activation.AllowEdit;
            columns[COLUMN_WAREHPROTYODR].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_WAREHPROTYODR].TabStop = true;

            // �q�ɃR�[�h��̐ݒ�
            columns[COLUMN_WAREHOUSECODE].CellActivation = Activation.AllowEdit;
            columns[COLUMN_WAREHOUSECODE].TabStop = true;

            // �K�C�h�{�^���̐ݒ�
            columns[COLUMN_WAREHOUSEGUIDE].CellActivation = Activation.NoEdit;
            columns[COLUMN_WAREHOUSEGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COLUMN_WAREHOUSEGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COLUMN_WAREHOUSEGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columns[COLUMN_WAREHOUSEGUIDE].TabStop = true;

            // �q�ɖ��̗�̐ݒ�
            columns[COLUMN_WAREHOUSENAME].CellActivation = Activation.NoEdit;
            columns[COLUMN_WAREHOUSENAME].TabStop = false;

            //�������\����
            columns[COLUMN_SCREENID].Hidden = true;

            // �Z���̕��̐ݒ�
            columns[COLUMN_WAREHPROTYODR].Width = 60;
            columns[COLUMN_WAREHOUSECODE].Width = 100;
            columns[COLUMN_WAREHOUSEGUIDE].Width = 20;
            columns[COLUMN_WAREHOUSENAME].Width = 370;

            // MaxLength
            columns[COLUMN_WAREHPROTYODR].MaxLength = 2;
            columns[COLUMN_WAREHOUSECODE].MaxLength = 4;
            columns[COLUMN_WAREHOUSENAME].MaxLength = 20;

        }

        /// <summary>
        ///	Grid �V�K�s�̒ǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�ɐV�K�s��ǉ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void AddBindTableRow()
        {
            if (this._bindTable.Rows.Count == 99)
            {
                // MAX99�s�Ƃ���
                return;
            }

            // �K�C�h�őI�������q�ɃR�[�h��ǉ�
            DataRow bindRow;

            bindRow = this._bindTable.NewRow();

            // �q�ɏ���Grid�ɒǉ�
            bindRow[COLUMN_SCREENID] = this._bindTable.Rows.Count + 1;
            bindRow[COLUMN_WAREHPROTYODR] = "";
            bindRow[COLUMN_WAREHOUSECODE] = "";
            bindRow[COLUMN_WAREHOUSENAME] = "";

            this._bindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// DataSet�W�J����(���C���e�[�u��)
        /// </summary>
        /// <param name="protyWarehouse">�D��q�Ƀ}�X�^</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �D��q�Ƀ}�X�^��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void MainToDataSet(ProtyWarehouse protyWarehouse, int index)
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
            if (protyWarehouse.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_DELETEDATE] = protyWarehouse.UpdateDateTimeJpInFormal;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONCODE] = protyWarehouse.SectionCode.Trim();
            // ���_����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONNAME] = protyWarehouse.SectionName.Trim();

            // ���_���GUID
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][MAIN_SECTIONGUID] = protyWarehouse.SectionCode.Trim();

            if (this._mainTable.ContainsKey(protyWarehouse.SectionCode.Trim()))
            {
                this._mainTable.Remove(protyWarehouse.SectionCode.Trim());
            }
            this._mainTable.Add(protyWarehouse.SectionCode.Trim(), protyWarehouse);
        }

        /// <summary>
        /// DataSet�W�J����(�ڍ׃e�[�u��)
        /// </summary>
        /// <param name="protyWarehouse">�D��q�Ƀ}�X�^</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �D��q�Ƀ}�X�^��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void DetailToDataSet(ProtyWarehouse protyWarehouse, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // �X�V����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_UPDATETIME] = DateTime.MinValue;
            // �폜��
            if (protyWarehouse.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_DELETEDATE] = "";
                // �X�V����
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_UPDATETIME] = protyWarehouse.UpdateDateTime;
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_DELETEDATE] = protyWarehouse.UpdateDateTimeJpInFormal;
            }

            // �D�揇��
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHPROTYODR] = protyWarehouse.WarehProtyOdr.ToString();
            // �q�ɃR�[�h
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHOUSECODE] = protyWarehouse.WarehouseCode;
            // �q�ɖ���
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHOUSENAME] = protyWarehouse.WarehouseName;
            // �q�ɏ��GUID
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][DETAIL_WAREHOUSEGUID] = protyWarehouse.FileHeaderGuid;

            // �n�b�V�������p��GUID�Z�b�g
            if (this._detailTable.ContainsKey(protyWarehouse.FileHeaderGuid) == true)
            {
                this._detailTable.Remove(protyWarehouse.FileHeaderGuid);
            }

            this._detailTable.Add(protyWarehouse.FileHeaderGuid, protyWarehouse);
        }

        /// <summary>
        /// �D��q�Ƀ}�X�^ �N���X��ʓW�J����
        /// </summary>
        /// <param name="protyWarehouse">�Ώۑq�ɐݒ� �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �D��q�Ƀ}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// <br></br>
        /// </remarks>
        private void ProtyWarehouseToScreen(ProtyWarehouse[] protyWarehouse)
        {
            int i = 0;
            int maxRow = protyWarehouse.Length;
            DataRow bindRow;

            // ���_�R�[�h
            this.tEdit_SectionCode.Text = protyWarehouse[i].SectionCode;
            // ���_����
            this.tEdit_SectionName.Text = GetSectionName(protyWarehouse[i].SectionCode.Trim());

            // �q�ɏ��
            for (; i < maxRow; i++)
            {
                bindRow = this._bindTable.NewRow();

                bindRow[COLUMN_SCREENID] = i + 1;                                                                              // Grid��ID(��\��)
                bindRow[COLUMN_WAREHPROTYODR] = protyWarehouse[i].WarehProtyOdr.ToString().Trim();      // �\������
                bindRow[COLUMN_WAREHOUSECODE] = protyWarehouse[i].WarehouseCode.Trim();                                   // �q�ɃR�[�h
                bindRow[COLUMN_WAREHOUSENAME] = GetWarehouseName(protyWarehouse[i].WarehouseCode.Trim());                 // �q�ɖ�

                this._bindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// DataSet����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet������\�z���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // ���C��
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);
            mainTable.Columns.Add(MAIN_DELETEDATE, typeof(string));       // �폜��
            mainTable.Columns.Add(MAIN_SECTIONCODE, typeof(string));      // ���_�R�[�h
            mainTable.Columns.Add(MAIN_SECTIONNAME, typeof(string));      // ���_����
            mainTable.Columns.Add(MAIN_SECTIONGUID, typeof(string));      // ���_���GUID

            //==============================
            // �ڍ�
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(DETAIL_DELETEDATE, typeof(string));             // �폜��
            detailTable.Columns.Add(DETAIL_WAREHPROTYODR, typeof(string)); // �D�揇��
            detailTable.Columns.Add(DETAIL_WAREHOUSECODE, typeof(string));          // �q�ɃR�[�h
            detailTable.Columns.Add(DETAIL_WAREHOUSENAME, typeof(string));          // �q�ɖ���
            detailTable.Columns.Add(DETAIL_WAREHOUSEGUID, typeof(Guid));            // �q�ɏ��GUID
            detailTable.Columns.Add(DETAIL_UPDATETIME, typeof(DateTime));           // �X�V����

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._mainDataIndex < 0)
            {
                //------------------------------
                // �V�K���[�h
                //------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋�����
                ScreenPermissionControl(INSERT_MODE);

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = this._detailDataIndex;
                this._targetTableBuffer = this._targetTableName;

                // �N���[���쐬
                ProtyWarehouse protyWarehouse = new ProtyWarehouse();
                this._protyWarehouseListClone = new ProtyWarehouse[1];
                this._protyWarehouseListClone[0] = protyWarehouse.Clone();

                // �O���b�h�s��ǉ�
                this.AddBindTableRow();

                // �V�K�\���`�F�b�N 
                if (!CheckMainIndex())
                {
                    return;
                }

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                 // �ڍ�Grid�̍s�����擾
                int rowCnt = 0;         // �s���J�E���^
                int maxRow = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count;
                ProtyWarehouse[] protyWarehouseList = new ProtyWarehouse[maxRow];

                // �I�����_�̑q�ɏ����擾
                for (; rowCnt < maxRow; rowCnt++)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[rowCnt][DETAIL_WAREHOUSEGUID];
                    protyWarehouseList[rowCnt] = (ProtyWarehouse)this._detailTable[guid];
                }

                if (protyWarehouseList[0].LogicalDeleteCode == 0)
                {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ��ʓ��͋����䏈��
                        ScreenPermissionControl(UPDATE_MODE);

                        // ��ʓW�J����
                        ProtyWarehouseToScreen(protyWarehouseList);

                        AddBindTableRow();

                        //�N���[���쐬
                        this._protyWarehouseListClone = new ProtyWarehouse[maxRow];
                        for (int i = 0; i < maxRow; i++)
                        {
                            this._protyWarehouseListClone[i] = protyWarehouseList[i].Clone();
                        }
                        
                        // �t�H�[�J�X�ݒ�
                        //this.Cancel_Button.Focus();      // DEL huangt K2013/10/08 No.82 �����t�H�[�J�X�̉��C
                        // --- ADD huangt K2013/10/08 No.82 �����t�H�[�J�X�̉��C ---------- >>>>>
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        // --- ADD huangt K2013/10/08 No.82 �����t�H�[�J�X�̉��C ---------- <<<<<
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    ProtyWarehouseToScreen(protyWarehouseList);

                    this.uGrid_ProtyWarehouse.Rows[0].Selected = false;
                    this.uGrid_ProtyWarehouse.ActiveCell = null;
                    this.uGrid_ProtyWarehouse.ActiveRow = null;
                    
                    //�N���[���쐬
                    this._protyWarehouseListClone = new ProtyWarehouse[maxRow];
                    for (int i = 0; i < maxRow; i++)
                    {
                        this._protyWarehouseListClone[i] = protyWarehouseList[i].Clone();
                    }

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._detailsIndexBuffer = this._detailDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɂ���ĉ�ʂ̓��͋�������s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // �V�K
            if (screenMode.Equals(INSERT_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.ultraButton_SectionGuide.Visible = true;
                this.ultraButton_SectionGuide.Enabled = true;
                this.DeleteRow_Button.Enabled = true;
                this.uGrid_ProtyWarehouse.Enabled = true;

                // ���͐ݒ�
                this.tEdit_SectionCode.Enabled = true;
                this.tEdit_SectionName.Enabled = false;
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.ultraButton_SectionGuide.Visible = true;
                this.ultraButton_SectionGuide.Enabled = false;
                this.DeleteRow_Button.Enabled = true;
                this.uGrid_ProtyWarehouse.Enabled = true;

                // ���͐ݒ�
                this.tEdit_SectionCode.Enabled = false;
                this.tEdit_SectionName.Enabled = false;
            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.Renewal_Button.Visible = false;
                this.ultraButton_SectionGuide.Visible = true;
                this.ultraButton_SectionGuide.Enabled = false;

                // ���͐ݒ�
                this.tEdit_SectionCode.Enabled = false;
                this.tEdit_SectionName.Enabled = false;
                this.DeleteRow_Button.Enabled = false;
                this.uGrid_ProtyWarehouse.Enabled = false;

            }
        }

        /// <summary>
        /// ��ʏ��D��q�� �N���X�i�[����
        /// </summary>
        /// <param name="protyWarehouseList">�D��q�� �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�D��q�� �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// <br></br>
        /// </remarks>
        private void DispToProtyWarehouse(ref ArrayList protyWarehouseList)
        {
            int index;
            int rowCnt = this._bindTable.Rows.Count;

            ProtyWarehouse protyWarehouse;
            protyWarehouseList = new ArrayList();

            for (index = 0; index < rowCnt; index++)
            {
                protyWarehouse = new ProtyWarehouse();

                protyWarehouse.EnterpriseCode = this._enterpriseCode;                                 // ��ƃR�[�h
                protyWarehouse.SectionCode = this.tEdit_SectionCode.Text;                             // ���_�R�[�h

                // �����͂̑q�ɂ�SKIP
                string warehouseCode = (string)this._bindTable.Rows[index][COLUMN_WAREHOUSECODE];
                string warehProtyOdr = (string)this._bindTable.Rows[index][COLUMN_WAREHPROTYODR];
                if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                {
                    continue;
                }

                // ����Grid�p�̏��擾
                protyWarehouse.WarehouseCode = warehouseCode;                                      // ���_�R�[�h
                if (!string.IsNullOrEmpty(warehProtyOdr))
                {
                    protyWarehouse.WarehProtyOdr = Int32.Parse(warehProtyOdr);                     // �D�揇��
                }

                protyWarehouseList.Add(protyWarehouse);
            }
        }

        /// <summary>
        /// �V�K���[�h�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�V�K���[�h�ł��B<br/>
        /// <c>false</c>:�V�K���[�h�ł͂���܂���B
        /// </returns>
        private bool IsInsertMode()
        {
            return this.Mode_Label.Text.Equals(INSERT_MODE);
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string message = string.Empty;
            string loginID = string.Empty;

            ArrayList updateList = new ArrayList();
            ArrayList deleteList = new ArrayList();

            if (this._mainDataIndex < 0)
            {
                if (!CheckMainIndex())
                    return false;
            }

            // ��ʓ��̓`�F�b�N
            if (!ScreenDataCheck())
            {
                return false;
            }

            if (this._mainDataIndex >= 0)
            {
                // �X�V���́A�X�V�Ώۂƍ폜�Ώۂ��擾
                this.UpdateCompare(out updateList, out deleteList);

                // �폜�Ώۂ�����ΊY�����R�[�h���폜
                if (deleteList.Count != 0)
                {
                    status = this._protyWarehouseAcs.Delete(deleteList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            {
                                // �r������
                                ExclusiveTransaction(status);
                                return false;
                            }
                    }
                }
            }
            else
            {
                //�V�K�̏ꍇ�A��ʏ��������N���X�ɐݒ�
                this.DispToProtyWarehouse(ref updateList);
            }

            // �o�^�^�X�V����
            if (updateList.Count != 0 && status == 0)
            {
                status = this._protyWarehouseAcs.Write(ref updateList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
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

                            return false;
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

            int totalCount = 0;

            // �Č���
            Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return true;
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �����폜�������s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
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
            ProtyWarehouse protyWarehouse = new ProtyWarehouse();

            // Form ����Grid�̏����擾
            int maxRow = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[i][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();
                deleteList.Add(protyWarehouse);
            }

            // �폜����
            int status = this._protyWarehouseAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex].Delete();
                        this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

                        // ���C��Grid�Ɩ���Grid�̃e�[�u�����폜
                        int delCnt = 0;
                        foreach (ProtyWarehouse wkProtyWarehouse in deleteList)
                        {
                            if (delCnt == 0)
                            {
                                // ���C��Grid�̃e�[�u��
                                this._mainTable.Remove(wkProtyWarehouse.SectionCode.Trim());
                                delCnt++;
                            }

                            // ����Grid�̃e�[�u��
                            this._detailTable.Remove(wkProtyWarehouse.FileHeaderGuid);
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        int totalCount = 0;

                        // �Č���
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

                        return false;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "DeleteProc",
                                       "�폜�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return false;
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
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // �������X�g�擾
            ArrayList reviveList = new ArrayList();
            foreach (ProtyWarehouse protyWarehouse in this._protyWarehouseListClone)
            {
                reviveList.Add(protyWarehouse.Clone());
            }

            // ��������
            int status = this._protyWarehouseAcs.Revival(ref reviveList);
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
                        
                        int totalCount = 0;
                        // �Č���
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
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck()
        {
            // ����Flag
            bool inputFlg = false;
            string message = string.Empty;

            // ���_�R�[�h
            if (this.tEdit_SectionCode.Text.Trim() == "" || this.tEdit_SectionName.Text.Trim() == "")
            {
                message = this.section_ultraLabel.Text + "�R�[�h����͂��ĉ������B";
                ShowCheckMsg(message);
                this.tEdit_SectionCode.Focus();
                return false;
            }
            else if (GetSectionName(this.tEdit_SectionCode.Text.Trim()) == "")
            {
                message = "���_�R�[�h���o�^����Ă��܂���B";
                ShowCheckMsg(message);
                this.tEdit_SectionCode.Focus();
                return false;
            }

            // Grid
            if (this._bindTable.Rows.Count == 0)
            {
                message = "�q�ɃR�[�h���P���ȏ�o�^���ĉ������B";
                ShowCheckMsg(message);
                this.uGrid_ProtyWarehouse.Focus();
                return false;
            }
            else if (this._bindTable.Rows.Count > 0)
            {
                for (int i = 0; i < this._bindTable.Rows.Count; i++)
                {
                    string code = (string)this._bindTable.Rows[i][COLUMN_WAREHOUSECODE];
                    string order = (string)this._bindTable.Rows[i][COLUMN_WAREHPROTYODR];

                    // �����͂̍s��SKIP
                    if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(order))
                    {
                        continue;
                    }

                    inputFlg = true;

                    if (string.IsNullOrEmpty(order) && !string.IsNullOrEmpty(code))
                    {
                        message = "�D�揇�ʂ���͂��ĉ������B";
                        ShowCheckMsg(message);
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[i].Cells[COLUMN_WAREHPROTYODR].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    else if (!string.IsNullOrEmpty(order) && string.IsNullOrEmpty(code))
                    {
                        message = "�q�ɃR�[�h����͂��ĉ������B";
                        ShowCheckMsg(message);
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[i].Cells[COLUMN_WAREHOUSECODE].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }

                    if (GetWarehouseName(code.Trim()) == "")
                    {
                        message = "�q�ɃR�[�h���o�^����Ă��܂���B";
                        ShowCheckMsg(message);
                        this.uGrid_ProtyWarehouse.Focus();
                        this.uGrid_ProtyWarehouse.Rows[i].Cells[COLUMN_WAREHOUSECODE].Activate();
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            if (!inputFlg)
            {
                message = "�q�ɃR�[�h���P���ȏ�o�^���ĉ������B";
                ShowCheckMsg(message);
                this.uGrid_ProtyWarehouse.Focus();
                // --- ADD huangt K2013/10/08 No.82 �����t�H�[�J�X�̉��C ---------- >>>>>
                this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                // --- ADD huangt K2013/10/08 No.82 �����t�H�[�J�X�̉��C ---------- <<<<<
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W��\�����܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void ShowCheckMsg(string message)
        {
            if (message.Length > 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               message,
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
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
                                         this._protyWarehouseAcs,		// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�ύX�������s���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            // ���_�R�[�h
            string sectionCode = this.tEdit_SectionCode.Text.Trim();

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][MAIN_SECTIONCODE];
                if (sectionCode.Equals(dsSectionCode))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][MAIN_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̗D��q�Ƀ}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���̂̃N���A
                        this.tEdit_SectionCode.Clear();
                        this.tEdit_SectionName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̗D��q�Ƀ}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // �ꎞ�I�ɏڍ׃e�[�u�����X�V
                                int selectedMainDataIndex = GetSelectedMainDataIndex();

                                this._mainDataIndex = i;
                                this._detailDataIndex = 0;
                                int dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // ��ʍĕ`��
                                ScreenClear();
                                ScreenReconstruction();

                                // �ڍ׃e�[�u�������ɖ߂�
                                this._mainDataIndex = selectedMainDataIndex;
                                dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // ���[�h�ύX�\�t���O�𗎂Ƃ�
                                CanChangeMode = false;
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�A���̂̃N���A
                                this.tEdit_SectionCode.Clear();
                                this.tEdit_SectionName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���݁A�I������Ă��郁�C���f�[�^�̃C���f�b�N�X���擾���܂��B
        /// </summary>
        /// <returns>���݁A�I������Ă��郁�C���f�[�^�̃C���f�b�N�X</returns>
        /// <remarks>
        /// <br>Note       : ���݁A�I������Ă��郁�C���f�[�^�̃C���f�b�N�X���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private int GetSelectedMainDataIndex()
        {
            // ���C���f�[�^�̐��ʂ�0�̏ꍇ
            if (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count.Equals(0))
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[0][DETAIL_WAREHOUSEGUID];
            ProtyWarehouse protyWarehouse = (ProtyWarehouse)this._detailTable[guid];

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                string sectionCode = this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][MAIN_SECTIONCODE].ToString();
                if (protyWarehouse.SectionCode.Equals(sectionCode.Trim()))
                {
                    return i;
                }
            }
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// �X�V�O��̃f�[�^��r�ƍX�V�Ώۊi�[����
        /// </summary>
        /// <param name="updateList">�X�V�Ώۃ��R�[�h���i�[</param>
        /// <param name="deleteList">�폜�Ώۃ��R�[�h���i�[</param>
        /// <remarks>
        /// <br>Note       : �X�V�O��̃f�[�^���r���čX�V�^�폜�Ώۃf�[�^���i�[���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void UpdateCompare(out ArrayList updateList, out ArrayList deleteList)
        {
            updateList = new ArrayList();
            deleteList = new ArrayList();
            ArrayList tempList = new ArrayList();
            // �X�V����(�r���p)
            Dictionary<string, DateTime> maxUpdateDic = new Dictionary<string,DateTime>();

            // �ύXflag
            bool deleteFlg;
            bool insertFlg;

            // �ŐV�X�V����
            DateTime maxUpdateDateTime = DateTime.MinValue;

            ProtyWarehouse protyWarehouse;

            // Form ����Grid����UI��ʂ�Grid���擾���Ĕ�r
            int detailRowCnt = this._detailTable.Count;             // ����Grid�̍s��
            int uiGridRowCnt = this._bindTable.Rows.Count;          // UI��ʂ�Grid�s��

            // �ŐV�X�V�������擾
            for (int detailIndex = 0; detailIndex < detailRowCnt; detailIndex++)
            {
                // ����Grid�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[detailIndex][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();
 
                if (protyWarehouse.UpdateDateTime > maxUpdateDateTime)
                {
                    maxUpdateDateTime = protyWarehouse.UpdateDateTime;
                }

                if (!maxUpdateDic.ContainsKey(protyWarehouse.WarehouseCode.Trim()))
                {
                    maxUpdateDic.Add(protyWarehouse.WarehouseCode.Trim(), protyWarehouse.UpdateDateTime);
                }

            }

            // ����Grid���̍s�������r
            for (int detailIndex = 0; detailIndex < detailRowCnt; detailIndex++)
            {
                deleteFlg = true;
                // ����Grid�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[detailIndex][DETAIL_WAREHOUSEGUID];
                protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();

                for (int gridIndex = 0; gridIndex < uiGridRowCnt; gridIndex++)
                {
                    // UI��ʂ�Grid��������擾
                    string warehouseCode = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHOUSECODE];
                    string warehProtyOdr = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHPROTYODR];

                    // �����͂̍s��SKIP
                    if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                    {
                        continue;
                    }

                    if (warehouseCode.Equals(protyWarehouse.WarehouseCode.Trim()))
                    {
                        deleteFlg = false;
                        // �D�揇�ʖ��ύX
                        if (warehProtyOdr.Equals(protyWarehouse.WarehProtyOdr.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            //�D�揇�ʂ��ς��̂ŁAUI��ʂ�Grid���͐V�K�ǉ��ƂȂ�
                            ProtyWarehouse updateProtyWarehouse = new ProtyWarehouse();
                            updateProtyWarehouse.EnterpriseCode = this._enterpriseCode;                            // ��ƃR�[�h
                            updateProtyWarehouse.SectionCode = this.tEdit_SectionCode.Text;                        // ���_�R�[�h
                            updateProtyWarehouse.WarehouseCode = warehouseCode;                                    // �q�ɃR�[�h
                            updateProtyWarehouse.UpdateDateTime = protyWarehouse.UpdateDateTime;                   // �X�V����
                            updateProtyWarehouse.FileHeaderGuid = protyWarehouse.FileHeaderGuid;                   // GUID
                            if (!string.IsNullOrEmpty(warehProtyOdr))
                            {
                                updateProtyWarehouse.WarehProtyOdr = int.Parse(warehProtyOdr);                         // �D�揇��
                            }
                            tempList.Add(updateProtyWarehouse);
                        }
                    }
                }

                if (deleteFlg)
                {
                    protyWarehouse.MaxUpdateDateTime = maxUpdateDateTime;
                    maxUpdateDic.Remove(protyWarehouse.WarehouseCode.Trim());
                    deleteList.Add(protyWarehouse);
                }
            }

            // �V�K�ǉ��f�[�^���擾
            for (int gridIndex = 0; gridIndex < uiGridRowCnt; gridIndex++)
            {
                insertFlg = true;
                // UI��ʂ�Grid��������擾
                string warehouseCode = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHOUSECODE];
                string warehProtyOdr = (string)this._bindTable.Rows[gridIndex][COLUMN_WAREHPROTYODR];

                // �����͂̍s��SKIP
                if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                {
                    continue;
                }

                for (int detailIndex = 0; detailIndex < detailRowCnt; detailIndex++)
                {
                    // ����Grid�����擾
                    Guid guid = (Guid)this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[detailIndex][DETAIL_WAREHOUSEGUID];
                    protyWarehouse = ((ProtyWarehouse)this._detailTable[guid]).Clone();

                    if (protyWarehouse.WarehouseCode.Trim().Equals(warehouseCode.Trim()))
                    {
                        insertFlg = false;
                    }
                }

                // �q�ɃR�[�h���s��v�̏ꍇ�A�V�K�ǉ��Ƃ��čX�V�Ώۂɒǉ�
                if (insertFlg)
                {
                    ProtyWarehouse insertProtyWarehouse = new ProtyWarehouse();
                    insertProtyWarehouse.EnterpriseCode = this._enterpriseCode;                            // ��ƃR�[�h
                    insertProtyWarehouse.SectionCode = this.tEdit_SectionCode.Text;                        // ���_�R�[�h
                    insertProtyWarehouse.WarehouseCode = warehouseCode;                                    // �q�ɃR�[�h
                    if (!string.IsNullOrEmpty(warehProtyOdr))
                    {
                        insertProtyWarehouse.WarehProtyOdr = int.Parse(warehProtyOdr);                         // �D�揇��
                    }
                    tempList.Add(insertProtyWarehouse);
                }
            }
 
            if (tempList.Count != 0)
            {
                DateTime maxUpdate = DateTime.MinValue;
                foreach (DateTime updateTime in maxUpdateDic.Values)
                {
                    // �ŐV�X�V�������擾
                    if (updateTime > maxUpdate)
                    {
                        maxUpdate = updateTime;
                    }
                }

                foreach (ProtyWarehouse writeProtyWarehouse in tempList)
                {
                    writeProtyWarehouse.MaxUpdateDateTime = maxUpdate;
                    updateList.Add(writeProtyWarehouse);
                }
            }
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
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
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

        #endregion �� Private Methods

        #region �� Control Events
        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[����Load���ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void PMKHN09750UA_Load(object sender, EventArgs e)
        {
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
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.ultraButton_SectionGuide.ImageList = imageList16;
            this.ultraButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;

            // ��ʏ����ݒ�
            ScreenInitialSetting();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void PMKHN09750UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

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
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void PMKHN09750UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            if (this._targetTableName == TABLE_DETAIL)
            {
                if (this._detailsIndexBuffer == this._detailDataIndex)
                {
                    return;
                }
            }
            else
            {
                if (this._mainIndexBuffer == this._mainDataIndex)
                {
                    return;
                }
            }

            // ��ʃN���A
            ScreenClear();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click �C�x���g(�ۑ��{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �ۑ�����
            SaveProc();
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �X�V�L���t���O
            bool isUpdate = false;

            // UI��ʂ�Grid�s�����擾
            int maxRow = this._bindTable.Rows.Count;

            //�ۑ��m�F
            if (this._mainDataIndex >= 0)
            {
                // �X�V���[�h
                if (maxRow > 0)
                {
                    // UI��ʂ�Grid��1���ȏ�o�^����Ă��邱��
                    ArrayList updateList = new ArrayList();
                    ArrayList deleteList = new ArrayList();

                    // �X�V�f�[�^�̗L�����m�F
                    UpdateCompare(out updateList, out deleteList);

                    if ((updateList.Count != 0) || (deleteList.Count != 0))
                    {
                        // �X�V�^�폜���R�[�h���L��
                        isUpdate = true;
                    }
                }
            }
            else
            {
                // �V�K���[�h
                ArrayList partsList = new ArrayList();
                // ��ʏ����擾
                this.DispToProtyWarehouse(ref partsList);
                if (partsList.Count > 0)
                {
                    // �q�ɂ̐ݒ�L
                    isUpdate = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
                    {
                        isUpdate = true;
                    }
                }
            }

            //�ŏ��Ɏ擾������ʏ��Ɣ�r
            if (isUpdate)
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                // �ۑ��m�F
                DialogResult res = TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                    ASSEMBLY_ID,       					// �A�Z���u���h�c�܂��̓N���X�h�c
                    null, 								// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);	    // �\������{�^��
                
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (!SaveProc())
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

            int totalCount = 0;

            // �Č���
            Search(ref totalCount, 0);

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
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
        /// Button_Click �C�x���g(�폜�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �폜�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
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

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuffer = -2;

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
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // �����\���`�F�b�N
            if (!CheckMainIndex())
            {
                return;
            }

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
        /// �ŐV��񏈗�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ŐV���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // �ŐV���擾
            ReadSecInfoSet();
            ReadWarehouseInfo();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        /// <summary>
        /// ���_�R�[�h�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���_�R�[�h�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>                                        
        /// </remarks>
        private void ultraButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet = null;

                // �K�C�h�N��
                int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // ���ʃZ�b�g
                    this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    if (ModeChangeProc())
                    {
                        this.tEdit_SectionCode.Focus();
                    }
                    else
                    {
                        // ���t�H�[�J�X
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Control.VisibleChange �C�x���g(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private void uGrid_ProtyWarehouse_VisibleChanged(object sender, System.EventArgs e)
        {
            // �A�N�e�B�u�Z���E�A�N�e�B�u�s�𖳌�
            this.uGrid_ProtyWarehouse.ActiveCell = null;
        }

        /// <summary>
        /// Control.KeyDown �C�x���g (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private void uGrid_ProtyWarehouse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                if (this.uGrid_ProtyWarehouse.ActiveRow != null)
                {
                    this.uGrid_ProtyWarehouse.Rows[this.uGrid_ProtyWarehouse.ActiveRow.Index].Cells[COLUMN_WAREHOUSECODE].Activate();
                    this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                }
                return;
            }

            // �O���b�h��Ԏ擾()
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ���L�[
                    case Keys.Up:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Down:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MovePreCell();
                            e.Handled = true;

                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveNextCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid_ProtyWarehouse.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_ProtyWarehouse_ClickCellButton(sender, cellEventArgs);
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
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private void uGrid_ProtyWarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_ProtyWarehouse.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_ProtyWarehouse.ActiveCell;

            // �D�揇�ʂ̓��͌����`�F�b�N
            if (cell.Column.Key == COLUMN_WAREHOUSECODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (cell.Column.Key == COLUMN_WAREHPROTYODR)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer  : huangt</br>                                    
        /// <br>Date        : K2013/09/11</br>       
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // �ŉ��i�Z���̎�
            if ((status & UltraGridState.RowLast) == UltraGridState.RowLast)
            {
                // �ۑ��{�^���ֈړ�
                return this.Renewal_Button;
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.uGrid_ProtyWarehouse.ActiveCell.Column.Index;
                int prevRow = this.uGrid_ProtyWarehouse.ActiveCell.Row.Index;

                // ���̃Z���Ɉړ�
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.BelowCell);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.uGrid_ProtyWarehouse.ActiveCell.Column.Index) &&
                    (prevRow == this.uGrid_ProtyWarehouse.ActiveCell.Row.Index))
                {
                    // �ۑ��{�^���ֈړ�
                    return this.Renewal_Button;
                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // �ŏ�i�Z���̎�
            if ((status & UltraGridState.RowFirst) == UltraGridState.RowFirst)
            {
                return this.DeleteRow_Button;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                        (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                    {
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�����̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private Control MovePreCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // �ŏ�i�Z���̎�
            if (((status & UltraGridState.RowFirst) == UltraGridState.RowFirst) && ((status & UltraGridState.CellFirst) == UltraGridState.CellFirst))
            {
                return this.Delete_Button;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.PrevCell);
                if (performActionResult)
                {
                    if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                        (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                    {
                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�����E�̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private Control MoveNextCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_ProtyWarehouse.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

            // �ŉ��i�Z���̎�
            if (((status & UltraGridState.RowLast) == UltraGridState.RowLast) && ((status & UltraGridState.CellLast) == UltraGridState.CellLast))
            {
                // �ۑ��{�^���ֈړ�
                return this.Renewal_Button;
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.uGrid_ProtyWarehouse.ActiveCell.Column.Index;
                int prevRow = this.uGrid_ProtyWarehouse.ActiveCell.Row.Index;

                // �E�̃Z���Ɉړ�
                performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.NextCell);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.uGrid_ProtyWarehouse.ActiveCell.Column.Index) &&
                    (prevRow == this.uGrid_ProtyWarehouse.ActiveCell.Row.Index))
                {
                    // �ۑ��{�^���ֈړ�
                    return this.Renewal_Button;
                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_ProtyWarehouse.ActiveCell != null))
            {
                if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
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
                this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_ProtyWarehouse.ActiveCell != null))
            {
                if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_ProtyWarehouse.ActiveCell.Activation == Activation.AllowEdit) &&
                            (this.uGrid_ProtyWarehouse.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
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
                this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	ultraGrid.Click �C�x���g(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID��Cell Button���N���b�N�C�x���g�����B</br>
        /// <br>Programmer  : huangt</br>
        /// <br>Date        : K2013/09/11</br>
        /// </remarks>
        private void uGrid_ProtyWarehouse_ClickCellButton(object sender, CellEventArgs e)
        {
            int status = 0;

            Warehouse warehouseData = null;

            // �q�ɃK�C�h�N��
            status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode);

            if (status == 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._bindTable.Rows.Count;

                // �q�ɃR�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string warehouseCode = (string)this._bindTable.Rows[i][COLUMN_WAREHOUSECODE];
                    if (warehouseCode == "")
                    {
                        continue;
                    }
                    if (warehouseCode.Equals(warehouseData.WarehouseCode.Trim()))
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // �I����������Cell�ɐݒ�
                    e.Cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = warehouseData.WarehouseCode.Trim();                    // �q�ɃR�[�h
                    e.Cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = warehouseData.WarehouseName.Trim();                    // �q�ɖ�

                    if ((int)e.Cell.Row.Cells[COLUMN_SCREENID].Value == this._bindTable.Rows.Count)
                    {
                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                        this.AddBindTableRow();
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // �d���G���[��\��
                    TMsgDisp.Show(
                        this,								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                        ASSEMBLY_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�I�������q�ɃR�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{�^��

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void uGrid_ProtyWarehouse_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_ProtyWarehouse.ActiveCell == null) return;

            UltraGridCell cell = this.uGrid_ProtyWarehouse.ActiveCell;

            switch (cell.Column.Key)
            {
                // �q�ɃR�[�h
                case COLUMN_WAREHOUSECODE:
                    {
                        string warehouseCode = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        this._gridUpdFlg = true;

                        if (warehouseCode != "")
                        {
                            // ���͗L
                            string warehouseName = GetWarehouseName(warehouseCode);

                            if (warehouseName != "")
                            {
                                bool AddFlg = true;     // �ǉ��t���O
                                int maxRow = this._bindTable.Rows.Count;

                                // �q�ɃR�[�h�̏d���`�F�b�N
                                for (int i = 0; i < maxRow; i++)
                                {
                                    if (cell.Row.Index == i)
                                    {
                                        // �����s����SKIP
                                        continue;
                                    }

                                    string wkWarehouseCode = this._bindTable.Rows[i][COLUMN_WAREHOUSECODE].ToString();
                                    if ((!string.IsNullOrEmpty(wkWarehouseCode)) && (wkWarehouseCode.Trim().Equals(warehouseCode.Trim().PadLeft(4, '0'))))
                                    {
                                        // �d���R�[�h�L
                                        AddFlg = false;
                                        break;
                                    }
                                }

                                if (AddFlg)
                                {
                                    // �q�ɃR�[�h�̒ǉ�
                                    // �I����������Cell�ɐݒ�
                                    cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = warehouseCode.PadLeft(4, '0');     // �q�ɃR�[�h
                                    cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = warehouseName;                     // �q�ɖ�

                                    if ((int)cell.Row.Cells[COLUMN_SCREENID].Value == this._bindTable.Rows.Count)
                                    {
                                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                                        this.AddBindTableRow();
                                    }
                                }
                                else
                                {
                                    // �d���G���[��\��
                                    TMsgDisp.Show(
                                        this,								    // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                                        ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                                        "���͂����q�ɃR�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                        0,									    // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);				    // �\������{�^��

                                    // �q�ɃR�[�h�A�q�ɖ����N���A
                                    cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = "";     // �q�ɃR�[�h
                                    cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = "";     // �q�ɖ�

                                    // Grid�ύX�Ȃ�
                                    this._gridUpdFlg = false;
                                }
                            }
                            else
                            {
                                // �_���폜�f�[�^�͐ݒ�s��
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�q�ɃR�[�h���o�^����Ă��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                // �q�ɃR�[�h�A�q�ɖ����N���A
                                cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = "";     // �q�ɃR�[�h
                                cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = "";     // �q�ɖ�

                                // Grid�ύX�Ȃ�
                                this._gridUpdFlg = false;
                            }
                        }
                        else
                        {
                            // ������
                            // �q�ɃR�[�h�A�q�ɖ����N���A
                            cell.Row.Cells[COLUMN_WAREHOUSECODE].Value = "";     // �q�ɃR�[�h
                            cell.Row.Cells[COLUMN_WAREHOUSENAME].Value = "";     // �q�ɖ�
                        }
                    }
                    break;
                case COLUMN_WAREHPROTYODR:
                    {
                        string priorityOrder = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        this._gridUpdFlg = true;

                        Regex r = new Regex(@"^[0-9]*$");
                        // ���_
                        if (!String.IsNullOrEmpty(priorityOrder) && !r.IsMatch(priorityOrder))
                        {
                            cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // �D�揇��
                            return;
                        }

                        if ((!string.IsNullOrEmpty(priorityOrder)) && (int.Parse(priorityOrder) != 0))
                        {
                            int warehProtyOdr = int.Parse(priorityOrder);
                            int maxRow = this._bindTable.Rows.Count;   // GRID�̍s��

                            for (int i = 0; i < maxRow; i++)
                            {
                                if (cell.Row.Index == i)
                                {
                                    // �����s����SKIP
                                    continue;
                                }

                                string wkPriorityOrder = (string)this._bindTable.Rows[i][COLUMN_WAREHPROTYODR];
                                if ((!string.IsNullOrEmpty(wkPriorityOrder)) && (int.Parse(wkPriorityOrder) == warehProtyOdr))
                                {
                                    // �d�����ʗL

                                    // �d���G���[��\��
                                    TMsgDisp.Show(
                                        this,								    // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                                        ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                                        "���͂����q�ɗD�揇���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                                        0,									    // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);				    // �\������{�^��

                                    // �D�揇�ʂ��N���A
                                    cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // �D�揇��

                                    // Grid�ύX�Ȃ�
                                    this._gridUpdFlg = false;
                                    break;
                                }
                                else if (string.IsNullOrEmpty(priorityOrder))
                                {
                                    cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // �D�揇��
                                }
                                cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = warehProtyOdr.ToString();
                            }
                        }
                        else
                        {
                            // ������
                            cell.Row.Cells[COLUMN_WAREHPROTYODR].Value = "";    // �D�揇��
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.uGrid_ProtyWarehouse.Rows.Count < 1)
            {
                // �f�o�b�O�p
                this.AddBindTableRow();
            }

            if (this.uGrid_ProtyWarehouse.ActiveRow == null)
            {
                // �폜����s�����I��
                message = "�폜����q�ɃR�[�h��I�����ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      					// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.uGrid_ProtyWarehouse.Focus();
            }
            //else if (this.uGrid_ProtyWarehouse.Rows.Count == 1)  // DEL huangt K2013/10/08 No.83 �s�폜�`�F�b�N�̉��C
            else if (!CheckDeleteRow())    // ADD huangt K2013/10/08 No.83 �s�폜�`�F�b�N�̉��C
            {
                // Grid�̍s����1�s�̏ꍇ�͍폜�s��
                message = "�S�Ă̑q�ɂ��폜�͂ł��܂���";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.uGrid_ProtyWarehouse.Focus();
            }
            else
            {
                // UI��ʂ�Grid����I���s���폜
                // �I���s��index���擾
                int delIndex = (int)this.uGrid_ProtyWarehouse.ActiveRow.Cells[COLUMN_SCREENID].Value - 1;

                // �I���s�̍폜
                this.uGrid_ProtyWarehouse.ActiveRow.Delete();

                // �폜���Grid�s�����擾
                int maxRow = this._bindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // �폜�����s�ȍ~�̕\�����ʂ��X�V����
                    this._bindTable.Rows[index][COLUMN_SCREENID] = index + 1;
                }
            }
        }

        // --- ADD huangt K2013/10/08 No.83 �s�폜�`�F�b�N�̉��C ----- >>>>>
        /// <summary>
        /// Grid�̍s�폜�`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note : Grid�̍s�폜�`�F�b�N���s���B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/10/08</br>
        /// </remarks>
        private bool CheckDeleteRow()
        {
            bool checkFlg = true;
            // UI��ʂ�Grid�s��
            int uiGridRowCnt = this._bindTable.Rows.Count;
            // �L���s��
            int validRowCnt = 0;
            int activeRowIndex = this.uGrid_ProtyWarehouse.ActiveRow.Index;
            // Active�s�̑q�ɃR�[�h
            string activeRowWarehouseCode = (string)this._bindTable.Rows[activeRowIndex][COLUMN_WAREHOUSECODE];
            // Active�s�̑q�ɗD�揇��
            string activeRowWarehProtyOdr = (string)this._bindTable.Rows[activeRowIndex][COLUMN_WAREHPROTYODR];

            for (int index = 0; index < uiGridRowCnt; index++)
            {
                if (index == activeRowIndex) continue;

                // UI��ʂ�Grid��������擾
                string warehouseCode = (string)this._bindTable.Rows[index][COLUMN_WAREHOUSECODE];
                string warehProtyOdr = (string)this._bindTable.Rows[index][COLUMN_WAREHPROTYODR];

                // �����͂̍s��SKIP
                if (string.IsNullOrEmpty(warehouseCode) && string.IsNullOrEmpty(warehProtyOdr))
                {
                    continue;
                }
                else
                {
                    validRowCnt++;
                }
            }

            // �L���s����0�s�̏ꍇ�͍폜�s��
            if (validRowCnt == 0 && this.uGrid_ProtyWarehouse.Rows.Count > 0)
            {
                checkFlg = false;
                if (string.IsNullOrEmpty(activeRowWarehouseCode) && string.IsNullOrEmpty(activeRowWarehProtyOdr) && (this.uGrid_ProtyWarehouse.Rows.Count) > 1)
                {
                    checkFlg = true;
                }
            }

            return checkFlg;
        }
        // --- ADD huangt K2013/10/08 No.83 �s�폜�`�F�b�N�̉��C ----- <<<<<

        /// <summary>
        /// Timer_Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂������ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();

            // ���[�h�ύX�\�t���O��ݒ�
            CanChangeMode = IsInsertMode();
        }

        /// <summary>���[�h�ύX�\�t���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool CanChangeMode
        {
            get { return _canChangeMode; }
            set { _canChangeMode = value; }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �A�N�e�B�u�R���g���[�����ς�������ɔ������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date	   : K2013/09/10</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":         // ���_�R�[�h
                    {
                        string wkSectionCode = this.tEdit_SectionCode.Text.Trim();
                        string sectionName = "";

                        if (!string.IsNullOrEmpty(wkSectionCode))
                        {
                            string sectionCode = wkSectionCode.PadLeft(2, '0');
                            // ���_���̂̎擾
                            sectionName = GetSectionName(sectionCode);

                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                this.tEdit_SectionName.Text = sectionName;

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                    {
                                        // �J�[�\������
                                        // GRID�̗D�揇�ʂփt�H�[�J�X����
                                        this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                                        this.uGrid_ProtyWarehouse.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�R�[�h���o�^����Ă��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                                // ���_�̃N���A
                                this.tEdit_SectionCode.Text = "";
                                this.tEdit_SectionName.Text = "";

                                // �J�[�\������
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            // ���_�̃N���A
                            this.tEdit_SectionCode.Text = "";
                            this.tEdit_SectionName.Text = "";
                        }

                        break;
                    }
                case "DeleteRow_Button":            // GRID�폜�{�^��
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRID�̗D�揇�ʂփt�H�[�J�X����
                                        this.uGrid_ProtyWarehouse.Rows[0].Cells[COLUMN_WAREHPROTYODR].Activate();
                                        this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uGrid_ProtyWarehouse":      // �O���b�h
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �K�C�h�{�^���Ƀt�H�[�J�X������
                                        if (this.uGrid_ProtyWarehouse.ActiveCell != null)
                                        {
                                            UltraGridState status = this.uGrid_ProtyWarehouse.CurrentState;

                                            if ((this.uGrid_ProtyWarehouse.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // �Z���̃X�^�C�����{�^���ŁA�Z���̍ŏI�s�̏ꍇ
                                                if (((int)this.uGrid_ProtyWarehouse.ActiveCell.Row.Cells[COLUMN_SCREENID].Value == this._bindTable.Rows.Count)
                                                    && (!string.IsNullOrEmpty((string)this.uGrid_ProtyWarehouse.ActiveCell.Row.Cells[COLUMN_WAREHOUSECODE].Value)))
                                                {
                                                    // �ŏI�s�̏ꍇ�A�s��ǉ�
                                                    this.AddBindTableRow();
                                                }
                                            }
                                        }

                                        // ���̃Z���ֈړ�
                                        bool moveFlg = this.MoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        if (!this._gridUpdFlg)
                                        {
                                            this.MovePrevAllowEditCell(false);
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
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.MovePrevAllowEditCell(false))
                                        {
                                            // �O���b�h���̃t�H�[�J�X����
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.DeleteRow_Button;
                                        }

                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "Renewal_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // GRID�̗D�揇�ʂփt�H�[�J�X����
                                        int rowIdx = this.uGrid_ProtyWarehouse.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.uGrid_ProtyWarehouse.ActiveRow = this.uGrid_ProtyWarehouse.Rows[rowIdx];
                                        // �A�N�e�B�u�Z����D�揇�ʂɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.uGrid_ProtyWarehouse.ActiveCell = this.uGrid_ProtyWarehouse.Rows[rowIdx].Cells[COLUMN_WAREHPROTYODR];
                                        // �D�揇�ʂ�ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][COLUMN_WAREHPROTYODR].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
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
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRID�̗D�揇�ʂփt�H�[�J�X����
                                        int rowIdx = this.uGrid_ProtyWarehouse.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.uGrid_ProtyWarehouse.ActiveRow = this.uGrid_ProtyWarehouse.Rows[rowIdx];
                                        // �A�N�e�B�u�Z����D�揇�ʂɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.uGrid_ProtyWarehouse.ActiveCell = this.uGrid_ProtyWarehouse.Rows[rowIdx].Cells[COLUMN_WAREHOUSECODE];
                                        // �D�揇�ʂ�ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][COLUMN_WAREHPROTYODR].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.uGrid_ProtyWarehouse.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "uGrid_ProtyWarehouse":      // �O���b�h
                        {
                            if ((this._mainDataIndex < 0) || (this._detailDataIndex < 0))
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                            break;
                        }
                }
            }

            string currentCampaignCode = this.tEdit_SectionCode.Text.Trim();

            if (CanChangeMode)
            {
                // �V�K���[�h�̏ꍇ�̂�
                if ((this._mainDataIndex < 0) || (this._detailDataIndex < 0))
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = this.tEdit_SectionCode;
                    }
                }
            }
        }
        #endregion �� Control Events
    }
}