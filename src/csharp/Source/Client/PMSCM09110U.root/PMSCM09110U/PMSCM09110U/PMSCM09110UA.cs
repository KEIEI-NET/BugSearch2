//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������ԕ\���[���ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ������ԕ\���[���ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Util;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ������ԕ\���[���ݒ�}�X�^�����e�i���X�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�����e�i���X���s���܂��B</br>
    /// <br>             IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer : ����</br> 
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region -- Constructor --
        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ������ԕ\���[���ݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2014/08/18</br>
        /// </remarks>
        public PMSCM09110UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;
 
            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._checkFlag = true;
            this._secInfoAcs = new SecInfoAcs(1);
            this._syncStateDspTermStAcs = new SyncStateDspTermStAcs();
            this._posTerminalMgAcs = new PosTerminalMgAcs();
            this._syncStSetTable = new Hashtable();
            this._posList = new ArrayList();
            // �O����͒l
            this._tmpSectionCode = ALL_SECTIONCODE;
            this._tmpSectionName = ALL_SECTIONNAME;
            this._tmpCashRegisterNo = string.Empty;
            this._tmpMachineName = string.Empty;
            this._tmpMachineIpAddr = string.Empty;

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���_�K�C�h�̃t�H�[�J�X����
            _sectionGuideController = new GeneralGuideUIController(
                this.tNEdit_SectionCode,
                this.SectionGuide_Button,
                this.tNedit_CashRegisterNo
            );
            // �[���Ǘ��ݒ�擾
            this.GetPosTerminalMgCache();
        }
        # endregion

        # region -- Private Members --
        private SyncStateDspTermStAcs _syncStateDspTermStAcs;
        private SecInfoAcs _secInfoAcs;                     // ���_�}�X�^�A�N�Z�X�N���X
        private PosTerminalMgAcs _posTerminalMgAcs;  // �[���Ǘ��ݒ�A�N�Z�X�N���X
        private string _enterpriseCode;
        private Hashtable _syncStSetTable;
        private ArrayList _posList;
        // �O����͒l
        private string _tmpSectionCode;
        private string _tmpSectionName;
        private string _tmpCashRegisterNo;
        private string _tmpMachineName;
        private string _tmpMachineIpAddr;
        private bool _checkFlag;

        // �ۑ���r�pClone
        private SyncStateDspTermStWork _syncStateStClone;

        // �[���Ǘ����L���b�V��
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        private const string ASSEMBLY_ID = "PMSCM09110U";

        private const string DELETE_DATE = "�폜��";
        private const string VIEW_SECTIONCODE_TITLE = "���_�R�[�h";
        private const string VIEW_SECTION_NAME_TITLE = "���_��";
        private const string VIEW_CASHREGISTERNO_TITLE = "�[���ԍ�";
        private const string VIEW_MACHINE_NAME_TITLE = "�[����";
        private const string VIEW_MACHINEIPADDR_TITLE = "�[��IP�A�h���X";

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "SyncStateDspTermSt";
        private const string VIEW_GUID_KEY_TITLE = "Guid";
        private const string VIEW_SECTION_CODE_TITLE = "SectionCode";
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "�S�Ћ���";
        /// <summary>���_�K�C�h�̐���I�u�W�F�N�g</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// ���_�K�C�h�̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���_�K�C�h�̐���I�u�W�F�N�g</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        # endregion

        # region -- Events --
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region -- Properties --
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
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

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
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

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        # endregion

        # region -- Public Methods --
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList syncStSetList = new ArrayList();

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._syncStSetTable.Clear();

            status = this._syncStateDspTermStAcs.SearchAll(out syncStSetList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        int index = 0;

                        foreach (SyncStateDspTermStWork syncStateSt in syncStSetList)
                        {
                            // DataSet�W�J����
                            SyncStSetToDataSet(syncStateSt, index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            this.Text,                              // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._syncStateDspTermStAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	    : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/03/25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 0;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B(������)</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if ((this.DataIndex < 0) ||
                (this.DataIndex >= this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count))
            {
                return -1;
            }

            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SyncStateDspTermStWork syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();

            // ������ԕ\���[���ݒ肪���݂��Ă��Ȃ�
            if (syncStateSt == null)
            {
                return -1;
            }

            // �S�̏����\���ݒ���_���폜����
            status = this._syncStateDspTermStAcs.LogicalDelete(ref syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SyncStSetToDataSet(syncStateSt.Clone(), this.DataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._syncStateDspTermStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���_�R�[�h
            appearanceTable.Add(VIEW_SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_��
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[���ԍ�
            appearanceTable.Add(VIEW_CASHREGISTERNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00#", Color.Black));
            // �[����
            appearanceTable.Add(VIEW_MACHINE_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[��ID�A�h���X
            appearanceTable.Add(VIEW_MACHINEIPADDR_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        # region -- Private Methods --
        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="syncStateSt">������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2014.03.27</br>
        /// </remarks>
        private void SyncStSetToDataSet(SyncStateDspTermStWork syncStateSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (syncStateSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = syncStateSt.UpdateDateTime;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCODE_TITLE] = syncStateSt.SectionCode.Trim().PadLeft(2, '0');

            // ���_����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = GetSectionName(syncStateSt.SectionCode);

            // �[���ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO_TITLE] = syncStateSt.CashRegisterNo;

            PosTerminalMg posTerMg = GetPosTerminalMg(syncStateSt.CashRegisterNo);
            if (posTerMg != null && posTerMg.LogicalDeleteCode == 0)
            {
                // �[����
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = posTerMg.MachineName;

                // �[��ID�A�h���X
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINEIPADDR_TITLE] = posTerMg.MachineIpAddr;
            }
            else
            {
                // �[����
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = "";

                // �[��ID�A�h���X
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINEIPADDR_TITLE] = "";
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = syncStateSt.FileHeaderGuid;

            if (this._syncStSetTable.ContainsKey(syncStateSt.FileHeaderGuid) == true)
            {
                this._syncStSetTable.Remove(syncStateSt.FileHeaderGuid);
            }
            this._syncStSetTable.Add(syncStateSt.FileHeaderGuid, syncStateSt);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable syncStSetTable = new DataTable(VIEW_TABLE);

            // �폜��
            syncStSetTable.Columns.Add(DELETE_DATE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_SECTIONCODE_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_CASHREGISTERNO_TITLE, typeof(int));
            syncStSetTable.Columns.Add(VIEW_MACHINE_NAME_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_MACHINEIPADDR_TITLE, typeof(string));
            syncStSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid)); 

            this.Bind_DataSet.Tables.Add(syncStSetTable);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �V�K�̏ꍇ
            if (this.DataIndex < 0)
            {
                ScreenInputPermissionControl(INSERT_MODE);                        // ��ʓ��͋�����
            }
            else
            {
                // �폜�̏ꍇ
                if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][DELETE_DATE] != "")
                {
                    ScreenInputPermissionControl(DELETE_MODE);                        // ��ʓ��͋�����
                }
                // �X�V�̏ꍇ
                else
                {
                    ScreenInputPermissionControl(UPDATE_MODE);                        // ��ʓ��͋�����
                }
            }

        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionName.Text = string.Empty;
            this.tNEdit_SectionCode.Text = string.Empty;
            this.tNedit_CashRegisterNo.Text = string.Empty;
            this.tEdit_MachineName.Text = string.Empty;
            this.tEdit_MachineIpAddr.Text = string.Empty;
            this._tmpCashRegisterNo = string.Empty;
            this._tmpMachineName = string.Empty;
            this._tmpMachineIpAddr = string.Empty;
        }

        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="syncStateSt">������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void SyncStSetToScreen(SyncStateDspTermStWork syncStateSt)
        {
            // ���_�R�[�h
            this.tNEdit_SectionCode.Text = syncStateSt.SectionCode.TrimEnd();
            // ���_��
            this.tEdit_SectionName.Text = this.GetSectionName(syncStateSt.SectionCode);
            // �[���ԍ�
            this.tNedit_CashRegisterNo.SetInt(syncStateSt.CashRegisterNo);
            PosTerminalMg posTerminalMg = GetPosTerminalMg(syncStateSt.CashRegisterNo);
            if (posTerminalMg == null)
            {
                // �[����
                this.tEdit_MachineName.Text = "";
                // �[��ID�A�h���X
                this.tEdit_MachineIpAddr.Text = "";
            }
            else
            {
                // �[����
                this.tEdit_MachineName.Text = posTerminalMg.MachineName;
                // �[��ID�A�h���X
                this.tEdit_MachineIpAddr.Text = posTerminalMg.MachineIpAddr;
            }
        }

        /// <summary>
        /// ��ʏ�񓯊���ԕ\���[���ݒ�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="syncStateSt">������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂瓯����ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenToSyncStSet(ref SyncStateDspTermStWork syncStateSt)
        {
            if (syncStateSt == null)
            {
                // �V�K�̏ꍇ
                syncStateSt = new SyncStateDspTermStWork();
            }
            // ��ƃR�[�h
            syncStateSt.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            syncStateSt.SectionCode = this.tNEdit_SectionCode.Text;

            // �[���ԍ�
            if (this.tNedit_CashRegisterNo.GetInt() != 0)
            {
                syncStateSt.CashRegisterNo = Convert.ToInt32(this.tNedit_CashRegisterNo.Value);
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SyncStateDspTermStWork syncStateSt = new SyncStateDspTermStWork();
                // �S�̏����\�����N���X��ʓW�J����
                SyncStSetToScreen(syncStateSt);
                //�N���[���쐬
                this._syncStateStClone = syncStateSt.Clone();
                this._indexBuf = this._dataIndex;

                //// ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSyncStSet(ref this._syncStateStClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                //// �t�H�[�J�X�ݒ�
                this.tNEdit_SectionCode.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SyncStateDspTermStWork syncStateSt = (SyncStateDspTermStWork)this._syncStSetTable[guid];

                // �S�̏����\�����N���X��ʓW�J����
                SyncStSetToScreen(syncStateSt);

                if (syncStateSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Cancel_Button.Focus();

                    // �N���[���쐬
                    this._syncStateStClone = syncStateSt.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSyncStSet(ref this._syncStateStClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // �{�^��
                    this.Save_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // ���͍���
                    this.tNEdit_SectionCode.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.tNedit_CashRegisterNo.Enabled = true;
                    this.tEdit_MachineIpAddr.Enabled = false;

                    this.comment_label.Visible = true;
                    break;
                case UPDATE_MODE:
                    // �{�^��
                    this.Save_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // ���͍���
                    this.tNEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    this.tEdit_MachineIpAddr.Enabled = false;

                    this.comment_label.Visible = false;
                    break;
                case DELETE_MODE:
                    // �{�^��
                    this.Save_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = false;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ���͍���
                    this.tNEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    this.tEdit_MachineIpAddr.Enabled = false;

                    this.comment_label.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note        : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
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
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        ///�@�ۑ�����(SaveSyncStSet())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private bool SaveSyncStSet()
        {
            bool result = false;
            // ���̓`�F�b�N
            Control control = null;
            if (!ScreenDataCheck(ref control))
            {
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            SyncStateDspTermStWork syncStateSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();
            }

            ScreenToSyncStSet(ref syncStateSt);

            // �[���ԍ������݂��Ă��Ȃ��ꍇ�A�o�^���Ȃ��B
            PosTerminalMg posTerminalMg = GetPosTerminalMg(tNedit_CashRegisterNo.GetInt());
            if ((posTerminalMg != null) &&
                (posTerminalMg.LogicalDeleteCode == 0))
            { }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�Y������[���ԍ������݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                tNedit_CashRegisterNo.Text = _tmpCashRegisterNo;
                tEdit_MachineName.Text = _tmpMachineName;
                tEdit_MachineIpAddr.Text = _tmpMachineIpAddr;
                _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                tNedit_CashRegisterNo.Focus();
                return false;
            }

            int status = this._syncStateDspTermStAcs.Write(ref syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 			// �G���[���x��
                            ASSEMBLY_ID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                            0, 										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        this.tNEdit_SectionCode.Text = _tmpSectionCode;
                        this.tNEdit_SectionCode.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);


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
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            this.Text,  �@�@                        // �v���O��������
                            "SaveSyncStSet",                        // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�ۑ��Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._syncStateDspTermStAcs,				    	// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,			  		// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

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
                        return false;
                    }
            }

            this.SyncStSetToDataSet(syncStateSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // �V�K�o�^��
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }

            result = true;

            return result;
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ��r�p�N���[���N���A
            this._syncStateStClone = null;

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
        /// ���_�R�[�h�����݂��邩���肵�܂��B
        /// </summary>
        /// <returns><c>true</c> :���݂���B<br/><c>false</c>:���݂��Ȃ��B</returns>
        /// <remarks>
        /// <br>Note        : ���_�R�[�h�����݂��邩���肵�܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private bool ExistsCode()
        {
            // �S�Ћ��ʂ͋��_�}�X�^�ɓo�^����Ă��Ȃ����߁A�`�F�b�N�̑ΏۊO
            if (SectionUtil.IsAllSection(this.tNEdit_SectionCode.Text))
            {
                return true;
            }

            bool existsSectionCode = SectionUtil.ExistsCode(this.tNEdit_SectionCode.Text);
            if (!existsSectionCode)
            {
                this.tNEdit_SectionCode.Focus();
            }
            return existsSectionCode;
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͂̕s���`�F�b�N���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control)
        {
            // ���_�R�[�h�����݂��Ă��Ȃ��ꍇ�A�o�^���Ȃ��B
            if (!ExistsCode())
            {
                TMsgDisp.Show(
                    this, 								                    // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 		                                        // �v���O��������
                    MethodBase.GetCurrentMethod().Name, 					// ��������
                    TMsgDisp.OPE_UPDATE, 				                    // �I�y���[�V����
                    "���_�R�[�h�����݂��܂���B",                           // LITERAL:�\�����郁�b�Z�[�W
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				                    // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                this.tNEdit_SectionCode.Text = _tmpSectionCode;
                this.tEdit_SectionName.Text = _tmpSectionName;
                control = this.tNEdit_SectionCode;
                return false;
            }

            // �[���ԍ��}�X�^�`�F�b�N
            if (string.IsNullOrEmpty(this.tNedit_CashRegisterNo.Text))
            {
                TMsgDisp.Show(
                    this, 								                    // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 		                                        // �v���O��������
                    MethodBase.GetCurrentMethod().Name, 					// ��������
                    TMsgDisp.OPE_UPDATE, 				                    // �I�y���[�V����
                    "�[���ԍ���ݒ肵�ĉ������B",                           // LITERAL:�\�����郁�b�Z�[�W
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				                    // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                control = this.tNedit_CashRegisterNo;
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                this.tNEdit_SectionCode.Text = ALL_SECTIONCODE;
                sectionName = ALL_SECTIONNAME;
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = string.Empty;
            }

            return sectionName;
        }

        /// <summary>
        /// �[���Ǘ��ݒ�̃��[�J���L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��ݒ�̃��[�J���L���b�V�����쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GetPosTerminalMgCache()
        {
            int status;
            ArrayList retList;

            // �[���Ǘ��ݒ�̃��[�J���L���b�V�����N���A
            _posTerminalMgDic = new Dictionary<int, PosTerminalMg>();

            // �[���Ǘ��ݒ�̎擾
            status = this._posTerminalMgAcs.SearchServer(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PosTerminalMg wkPosTerminalMg in retList)
                {
                    if (wkPosTerminalMg.LogicalDeleteCode == 0)
                    {
                        int key = wkPosTerminalMg.CashRegisterNo;
                        if (_posTerminalMgDic.ContainsKey(key))
                        {
                            // ���ɃL���b�V���ɑ��݂��Ă���ꍇ�͍폜
                            _posTerminalMgDic.Remove(key);
                        }
                        _posTerminalMgDic.Add(key, wkPosTerminalMg);
                    }
                }
            }
        }

        /// <summary>
        /// �[���Ǘ��ݒ���擾���܂��B
        /// </summary>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <returns>�[���Ǘ��ݒ�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �[���ԍ�����[���Ǘ��ݒ�f�[�^�N���X���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMg GetPosTerminalMg(int cashRegisterNo)
        {
            PosTerminalMg posTerminalMg = null;

            if (_posTerminalMgDic.ContainsKey(cashRegisterNo))
            {
                posTerminalMg = _posTerminalMgDic[cashRegisterNo];
            }

            return posTerminalMg;
        }
        # endregion

        # region -- Control Events --
        /// <summary>
        ///	Form.Load �C�x���g(PMSCM09110UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void PMSCM09110UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Save_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.Save_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            // ���_�K�C�h�̃t�H�[�J�X����̊J�n
            SectionGuideController.StartControl();
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tNEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                    this._tmpSectionName = secInfoSet.SectionGuideNm.Trim();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SyncStateDspTermStWork syncStateSt = (SyncStateDspTermStWork)this._syncStSetTable[guid];

            // ���_���_���폜����
            status = this._syncStateDspTermStAcs.Delete(syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._syncStSetTable.Remove(syncStateSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._syncStateDspTermStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        /// Control.Click �C�x���g(Save_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (!_checkFlag)
            {
                _checkFlag = true;
                return;
            }

            if (!SaveSyncStSet())
            {
                return;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SyncStateDspTermStWork syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();


            //  ������ԕ\���[���ݒ�}�X�^�_���폜��������
            status = this._syncStateDspTermStAcs.Revival(ref syncStateSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        SyncStSetToDataSet(syncStateSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ReviveWarehouse",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._syncStateDspTermStAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();
            this.GetPosTerminalMgCache();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
            
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SyncStateDspTermStWork compareSyncStSet = new SyncStateDspTermStWork();

                compareSyncStSet = this._syncStateStClone.Clone();
                ScreenToSyncStSet(ref compareSyncStSet);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._syncStateStClone.Equals(compareSyncStSet))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SaveSyncStSet();

                                return;
                            }

                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

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
            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;
            this._tmpSectionCode = ALL_SECTIONCODE;
            this._tmpCashRegisterNo = string.Empty;

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
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X���[�X�g�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CashRegisterNo":
                    {
                        if (this.DataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = this.tNedit_CashRegisterNo;
                            }
                        }
                        break;
                    }
                case "tNEdit_SectionCode":
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = this.SectionGuide_Button;
                        break;
                    }
                    else
                    {
                        if (this.DataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = this.tNEdit_SectionCode;
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
            string msg = "���͂��ꂽ�R�[�h�̓�����ԕ\���[���ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = this.tNEdit_SectionCode.Text.TrimEnd().PadLeft(2, '0');
            // �[���ԍ�
            int cashRegisterNo = this.tNedit_CashRegisterNo.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {

                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCODE_TITLE];
                int dsCashRegisterNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CASHREGISTERNO_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (cashRegisterNo == dsCashRegisterNo))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓�����ԕ\���[���ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ��ʏ��̃N���A
                        ScreenClear();
                        this.tNEdit_SectionCode.Text = ALL_SECTIONCODE;
                        this.tEdit_SectionName.Text = ALL_SECTIONNAME;
                        this._tmpSectionCode = ALL_SECTIONCODE;
                        this._tmpSectionName = ALL_SECTIONNAME;
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̓�����ԕ\���[���ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this.DataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ��ʏ��̃N���A
                                ScreenClear();
                                this.tNEdit_SectionCode.Text = ALL_SECTIONCODE;
                                this.tEdit_SectionName.Text = ALL_SECTIONNAME;
                                this._tmpSectionCode = ALL_SECTIONCODE;
                                this._tmpSectionName = ALL_SECTIONNAME;
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���_�R�[�hEdit Leave����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_���̕\������</br>
        /// <br></br>
        /// </remarks>
        private void tNEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            if (tNEdit_SectionCode.Text == "")
            {
                // uiSetControl��"00"�ɕ␳����̂ŁA���_���̂͑S�Ћ��ʂ�ݒ�
                this.tNEdit_SectionCode.Text = "00";
                this.tEdit_SectionName.Text = SectionUtil.ALL_SECTION_NAME;
                _tmpSectionCode = "00";
                _tmpSectionName = SectionUtil.ALL_SECTION_NAME;
            }
            else if (tNEdit_SectionCode.GetInt() == 0)
            {
                tNEdit_SectionCode.Text = _tmpSectionCode;
                _checkFlag = false;
            }
            else
            {
                SyncStateDspTermStWork syncStateSt = null;

                if (this.DataIndex >= 0)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                    syncStateSt = ((SyncStateDspTermStWork)this._syncStSetTable[guid]).Clone();
                }

                ScreenToSyncStSet(ref syncStateSt);

                // ���_�R�[�h�܂������݂��Ă��Ȃ��ꍇ�A�o�^���Ȃ��B
                if (!ExistsCode())
                {
                    TMsgDisp.Show(
                        this, 								                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // �G���[���x��
                        AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text, 		                                        // �v���O��������
                        MethodBase.GetCurrentMethod().Name, 					// ��������
                        TMsgDisp.OPE_UPDATE, 				                    // �I�y���[�V����
                        "���_�R�[�h�����݂��܂���B",                           // LITERAL:�\�����郁�b�Z�[�W
                        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// �X�e�[�^�X�l
                        this,			                                        // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK, 				                    // �\������{�^��
                        MessageBoxDefaultButton.Button1                         // �����\���{�^��
                    );
                    this.tNEdit_SectionCode.Text = _tmpSectionCode;
                    this.tEdit_SectionName.Text = _tmpSectionName;
                    this.tNEdit_SectionCode.Focus();

                }
            }
            // ���_�R�[�h���͂���H
            if (this.tNEdit_SectionCode.Text != "")
            {
                // ���_�R�[�h���̐ݒ�
                this.tEdit_SectionName.Text = GetSectionName(this.tNEdit_SectionCode.Text.Trim());

                if (SectionUtil.IsAllSection(this.tNEdit_SectionCode.Text))
                {
                    this.tEdit_SectionName.Text = SectionUtil.ALL_SECTION_NAME;
                }
                _tmpSectionCode = this.tNEdit_SectionCode.Text;
                _tmpSectionName = this.tEdit_SectionName.Text;
            }          
        }

        /// <summary>
        /// �[���ԍ�Edit Leave����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �[���ԍ��\������</br>
        /// <br></br>
        /// </remarks>
        private void tNedit_CashRegisterNo_Leave(object sender, EventArgs e)
        {
            if (tNedit_CashRegisterNo.Text == "")
            {
                tEdit_MachineName.Text = string.Empty;
                tEdit_MachineIpAddr.Text = string.Empty;
            }
            else if (tNedit_CashRegisterNo.GetInt() == 0)
            {
                tEdit_MachineName.Text = _tmpMachineName;
                tEdit_MachineIpAddr.Text = _tmpMachineIpAddr;
                tNedit_CashRegisterNo.Text = _tmpCashRegisterNo;
                _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                _checkFlag = false;
            }
            else
            {
                // �[���Ǘ��ݒ�}�X�^���疼�̂��擾
                PosTerminalMg posTerminalMg = GetPosTerminalMg(tNedit_CashRegisterNo.GetInt());
                if ((posTerminalMg != null) &&
                    (posTerminalMg.LogicalDeleteCode == 0))
                {
                    tEdit_MachineName.Text = posTerminalMg.MachineName;
                    tEdit_MachineIpAddr.Text = posTerminalMg.MachineIpAddr;
                    _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                    _tmpMachineName = tEdit_MachineName.Text;
                    _tmpMachineIpAddr = tEdit_MachineIpAddr.Text;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�Y������[���ԍ������݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    tNedit_CashRegisterNo.Text = _tmpCashRegisterNo;
                    tEdit_MachineName.Text = _tmpMachineName;
                    tEdit_MachineIpAddr.Text = _tmpMachineIpAddr;
                    _tmpCashRegisterNo = tNedit_CashRegisterNo.Text;
                    tNedit_CashRegisterNo.Focus();
                }
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSCM09110UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void PMSCM09110UA_VisibleChanged(object sender, EventArgs e)
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
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        ///	Form.Closing �C�x���g(PMSCM09110UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2014/08/18</br>
        /// </remarks>
        private void PMSCM09110UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            this._tmpSectionCode = ALL_SECTIONCODE;
            this._tmpCashRegisterNo = string.Empty;
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        # endregion


        
    }
}