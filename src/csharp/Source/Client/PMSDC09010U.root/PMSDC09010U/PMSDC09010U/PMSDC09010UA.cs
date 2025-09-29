//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00 �쐬�S�� : �c����
// �� �� ��  2019/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00 �쐬�S�� : ����
// �� �� ��  2020/02/04  �C�����e : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ڑ�����ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �ڑ�����ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2019/12/03</br>
    /// <br>�Ǘ��ԍ�    : 11570219-00</br>
    /// <br></br>
    /// <br>Update Note : 2020/02/04 ���� ���</br>
    /// <br>�Ǘ��ԍ�    : 11570219-00</br>
    /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
    /// </remarks>
    public partial class PMSDC09010UA : Form,IMasterMaintenanceMultiType
    {
        #region �R���X�g���N�^
        /// <summary>
        /// PMSDC09010U�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ڑ�����ݒ�t�H�[���N���X�R���X�g���N�^�ł�</br>
        /// <br>Programer	: �c����</br>
        /// <br>Date		: 2019/12/03</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// </remarks>
        public PMSDC09010UA()
        {
            InitializeComponent();

            // DataSet����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            // ConnectInfoWork�N���X
            this._connectInfoWork = new SalCprtConnectInfoWork();
            this._connectInfoWorkClone = new SalCprtConnectInfoWork();

            // connectInfoWorkAcs�N���X�A�N�Z�X�N���X
            this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();

            this._customerInfoAcs = new CustomerInfoAcs();

            this._connectInfoWorkTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._supplierAcs = new SupplierAcs();
            this._indexBuf = -2;
            this._supplierDic = new Dictionary<int, Supplier>();
            this._posTerminalMgAcs = new PosTerminalMgAcs();

            this._controlScreenSkin = new ControlScreenSkin();                                //�X�L�������[�h
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �[���Ǘ��ݒ�擾
            this.GetPosTerminalMgCache();

            // ���Ӑ於�̃��X�g�擾
            this.GetCustomerNameList();
        }

        #endregion

        #region Private Member
        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool _isError = false;

        // �d����
        private SupplierAcs _supplierAcs;
        private Dictionary<int, Supplier> _supplierDic;

        private SalCprtConnectInfoWork _connectInfoWork;
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs;
        private CustomerInfoAcs _customerInfoAcs;

        // �ۑ���r�pClone
        private SalCprtConnectInfoWork _connectInfoWorkClone;
        private ControlScreenSkin _controlScreenSkin;                           // �X�L���ݒ�p�N���X

        // HashTable
        private Hashtable _connectInfoWorkTable;

        // �[���Ǘ����L���b�V��
        private Dictionary<int, PosTerminalMg> _posTerminalMgDic;
        private PosTerminalMgAcs _posTerminalMgAcs = null;  // �[���Ǘ��ݒ�A�N�Z�X�N���X

        // ���Ӑ���L���b�V��
        private ArrayList _customerList;

        private int _indexBuf;
        private string _enterpriseCode;
        private bool _cusotmerGuideSelected;

        private const string ASSEMBLY_ID            = "PMSDC09010U";
        private const int SUPPLIERCODE              = 0;     
        private const string MAXHOUR                = "24";
        private const string MINMINUTE              = "00";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE            = "�폜��";
        private const string VIEW_SECTIONCD         = "���_";
        private const string VIEW_CUSTOMERCD        = "���Ӑ�";
        private const string VIEW_AUTOSENDDIV       = "�������M�敪";
        private const string VIEW_BOOTTIME          = "�������M���ԑсi�N���j";
        private const string VIEW_ENDTIME           = "�������M���ԑсi�I���j";
        private const string VIEW_EXECINTERVAL      = "���s�Ԋu";
        private const string VIEW_CNECTSENDDIV      = "�����ڑ����M�敪";
        private const string CASH_REGISTER_NO       = "�������M�N���[��";
        private const string VIEW_SENDMACHINENAME   = "�������M�N���[������";
        private const string VIEW_SENDMACHINEIPADDR = "IP�A�h���X";
        // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
        private const string VIEW_NOTE1SETDIV       = "���l�P";
        private const string VIEW_NOTE2SETDIV       = "���l�Q";
        private const string VIEW_NOTE3SETDIV       = "���l�R";
        // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
        private const string VIEW_CONNECTUSERID     = "���[�U�[�R�[�h";
        private const string VIEW_CONNECTPASSWORD   = "�p�X���[�h";
        private const string VIEW_DOMAIN            = "�h���C��";
        private const string VIEW_CPRTURL           = "�A�h���X";
        private const string VIEW_TIMEOUT           = "�^�C���A�E�g";
        private const string VIEW_RETRYCNT          = "���g���C��";
        private const string VIEW_CNECTFILEID       = "�ڑ��t�@�C��ID";
        private const string VIEW_FRSTSENDDATE      = "���񑗐M���";
        private const string VIEW_LTATSADDATETIME   = "�O�񎩓����M����";
        //GUID
        private const string VIEW_FILEHEADERGUID    = "Guid";

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE             = "VIEW_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE            = "�V�K���[�h";
        private const string UPDATE_MODE            = "�X�V���[�h";
        private const string DELETE_MODE            = "�폜���[�h";
        #endregion

        #region Main Entry Point
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMSDC09010UA());
        }
        #endregion

        #region IMasterMaintenanceMultiType �����o
        /*----------------------------------------------------------------------------------*/
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾���܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }


        /*----------------------------------------------------------------------------------*/
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            SalCprtConnectInfoWork connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // �ڑ�����ݒ�}�X�^���_���폜����
            status = this._connectInfoWorkAcs.LogicalDelete(ref connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
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
                            this._connectInfoWorkAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.YesNo, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // �ڑ�����ݒ�}�X�^�f�[�^�Z�b�g�W�J����
            ConnectInfoWorkToDataSet(connectInfoWork, this.DataIndex);
            return 0;
        }


        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">TATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    ASSEMBLY_ID,							// �A�Z���u��ID
                    "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // ���_
            appearanceTable.Add(VIEW_SECTIONCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // ���Ӑ�
            appearanceTable.Add(VIEW_CUSTOMERCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // �������M���ԑсi�N���j
            appearanceTable.Add(VIEW_BOOTTIME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �������M���ԑсi�I���j
            appearanceTable.Add(VIEW_ENDTIME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���s�Ԋu
            appearanceTable.Add(VIEW_EXECINTERVAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����ڑ����M�敪
            appearanceTable.Add(VIEW_CNECTSENDDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[���ԍ�
            appearanceTable.Add(CASH_REGISTER_NO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00#", Color.Black));
            // ���M�[��
            appearanceTable.Add(VIEW_SENDMACHINENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[��IP�A�h���X
            appearanceTable.Add(VIEW_SENDMACHINEIPADDR, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            // �o�͐ݒ���l�P
            appearanceTable.Add(VIEW_NOTE1SETDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �o�͐ݒ���l�Q
            appearanceTable.Add(VIEW_NOTE2SETDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �o�͐ݒ���l�R
            appearanceTable.Add(VIEW_NOTE3SETDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            // ���[�U�[�R�[�h
            appearanceTable.Add(VIEW_CONNECTUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �p�X���[�h
            appearanceTable.Add(VIEW_CONNECTPASSWORD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �h���C��
            appearanceTable.Add(VIEW_DOMAIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �A�h���X
            appearanceTable.Add(VIEW_CPRTURL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �������M�敪
            appearanceTable.Add(VIEW_AUTOSENDDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �^�C���A�E�g
            appearanceTable.Add(VIEW_TIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���g���C��
            appearanceTable.Add(VIEW_RETRYCNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �ڑ��t�@�C��ID
            appearanceTable.Add(VIEW_CNECTFILEID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���񑗐M���
            appearanceTable.Add(VIEW_FRSTSENDDATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �O�񎩓����M����
            appearanceTable.Add(VIEW_LTATSADDATETIME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programer	: �c����</br>
        /// <br>Date		: 2019/12/03</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            int status = 0;
            ArrayList connectInfoWorkAcsList = null;
      
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._connectInfoWorkTable.Clear();
            // �S����
            status = this._connectInfoWorkAcs.SearchAll(out connectInfoWorkAcsList, this._enterpriseCode);
            if (connectInfoWorkAcsList != null)
            {
                totalCount = connectInfoWorkAcsList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SalCprtConnectInfoWork connectInfoWork in connectInfoWorkAcsList)
                        {

                            // �I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
                            ConnectInfoWorkToDataSet(connectInfoWork, index);
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
                            "PMSDC09010UA",							// �A�Z���u��ID
                            "�I�[�g�o�b�N�X�ݒ�",              �@�@   // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._connectInfoWorkAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �ڑ�����ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�}�X�^�����e�i���X�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void ConnectInfoWorkToDataSet(SalCprtConnectInfoWork connectInfoWork, int index)
        {
            // index�̒l��DataSet�̊����s�������Ă��Ȃ�������
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // index�ɍs�̍ŏI�s�ԍ����Z�b�g����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            // �폜��
            if (connectInfoWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = TDateTime.DateTimeToString("ggYY/MM/DD", connectInfoWork.UpdateDateTime);
            }
            // �������M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSENDDIV] = (connectInfoWork.AutoSendDiv == 0) ? "����" : "���Ȃ�";
            //���_
            if (connectInfoWork.SectionCode == "0")
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCD] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCD] = connectInfoWork.SectionCode.PadLeft(2, '0');
            }
            //���Ӑ�
            if (connectInfoWork.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCD] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMERCD] = connectInfoWork.CustomerCode.ToString().PadLeft(8, '0');
            }

            //�������M���ԑсi�N���j
            if (connectInfoWork.BootTime == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BOOTTIME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BOOTTIME] = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(0, 2) + ":" + connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(2, 2);
            }
            //�������M���ԑсi�I���j
            if (connectInfoWork.EndTime == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENDTIME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ENDTIME] = connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(0, 2) + ":" + connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(2, 2);
            }

            //���s�Ԋu
            if (connectInfoWork.ExecInterval == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXECINTERVAL] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_EXECINTERVAL] = connectInfoWork.ExecInterval;
            }
            // �����ڑ����M�敪
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTSENDDIV] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTSENDDIV] = (connectInfoWork.CnectSendDiv == 2) ? "�S��" : "�����M";
            }
            //���񑗐M���
            if (connectInfoWork.FrstSendDate == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRSTSENDDATE] = string.Empty;
            }
            else
            {
                DateTime dt = DateTime.ParseExact(connectInfoWork.FrstSendDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRSTSENDDATE] = dt.ToString("yyyy�NM��d��");
 
            }
            //�O�񎩓����M����
            if (connectInfoWork.LtAtSadDateTime == DateTime.MinValue)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LTATSADDATETIME] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LTATSADDATETIME] = connectInfoWork.LtAtSadDateTime.ToString("yyyy�NM��d��H��m��s�b");
            }

            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            // �o�͐ݒ���l�P�@�f�t�H���g�l���l�P�̂���else�ɔz�u
            if (connectInfoWork.Note1SetDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1SETDIV] = "�w�����ԍ�";
            }
            else if (connectInfoWork.Note1SetDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1SETDIV] = "���M���Ȃ�";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE1SETDIV] = "���l�P";
            }

            // �o�͐ݒ���l�Q�@�f�t�H���g�l���l�Q�̂���else�ɔz�u
            if (connectInfoWork.Note2SetDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2SETDIV] = "�w�����ԍ�";
            }
            else if (connectInfoWork.Note2SetDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2SETDIV] = "���M���Ȃ�";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE2SETDIV] = "���l�Q";
            }

            // �o�͐ݒ���l�R�@�f�t�H���g�l���l�R�̂���else�ɔz�u
            if (connectInfoWork.Note3SetDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3SETDIV] = "�w�����ԍ�";
            }
            else if (connectInfoWork.Note3SetDiv == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3SETDIV] = "���M���Ȃ�";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NOTE3SETDIV] = "���l�R";
            }
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<

            // ���[�U�[�R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTUSERID] = connectInfoWork.SendCcnctUserid;
            // �p�X���[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTPASSWORD] = connectInfoWork.SendCcnctPass;
            // �h���C��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DOMAIN] = connectInfoWork.CprtDomain;
            // �A�h���X
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CPRTURL] = connectInfoWork.CprtUrl;
            // �^�C���A�E�g
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIMEOUT] = connectInfoWork.LoginTimeoutVal;
            // ���g���C��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RETRYCNT] = connectInfoWork.RetryCnt;
            // �ڑ��t�@�C��ID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNECTFILEID] = connectInfoWork.CnectFileId;
            // �[���ԍ�
            if (connectInfoWork.AutoSendDiv != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CASH_REGISTER_NO] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][CASH_REGISTER_NO] = connectInfoWork.CashregiSterno;
            }
            // �[����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDMACHINENAME] = connectInfoWork.SendMachineName;
            // �[��IP�A�h���X
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDMACHINEIPADDR] = connectInfoWork.SendMachineIpAddr;
            // GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = connectInfoWork.FileHeaderGuid;
            // �C���X�^���X�e�[�u���ɂ��Z�b�g����
            if (this._connectInfoWorkTable.ContainsKey(connectInfoWork.FileHeaderGuid) == true)
            {
                this._connectInfoWorkTable.Remove(connectInfoWork.FileHeaderGuid);
            }
            
            this._connectInfoWorkTable.Add(connectInfoWork.FileHeaderGuid, connectInfoWork);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }
        #endregion

        #region ----- �C�x���g -----
        /// <summary>
        /// UnDisplaying
        /// </summary>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion ----- �C�x���g -----

        #region ----- �I�t���C����ԃ`�F�b�N���� -----
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ----- Private Method -----
        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�V�K, 1:�X�V, 2:�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                default:
                // 0:�V�K
                case 0:
                    // ��ʏ����� �Ɖ�ʓ��͋����䏈��
                    ScreenClear();
                    break;

                // 1:�X�V
                case 1:

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;

                    // �p�l��
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerGuide_Button.Enabled = false;
                    this.AutoSendDiv_tCmbEdit.Enabled = true;
                    this.HourSt_tNedit.Enabled = true;
                    this.MinuteSt_tNedit.Enabled = true;
                    this.HourEd_tNedit.Enabled = true;
                    this.MinuteEd_tNedit.Enabled = true;
                    this.tNedit_ExecInterval.Enabled = true;
                    this.CnectSendDiv_tCmbEdit.Enabled = true;
                    this.tNedit_CashRegisterNo.Enabled = true;
                    // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
                    this.Note1SetDiv_tCmbEdit.Enabled = true;
                    this.Note2SetDiv_tCmbEdit.Enabled = true;
                    this.Note3SetDiv_tCmbEdit.Enabled = true;
                    // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
                    this.ConnectUserId_tEdit.Enabled = true;
                    this.ConnectPassword_tEdit.Enabled = true;
                    this.Domain_tEdit.Enabled = true;
                    this.OrderAddress_tEdit.Enabled = true;
                    this.TimeOut_tNedit.Enabled = true;
                    this.RetryCnt_tNedit.Enabled = true;
                    this.CnectFileId_tEdit.Enabled = true;
                    this.tNedit_FrstSendDateYear.Enabled = true;
                    this.tNedit_FrstSendDateMonth.Enabled = true;
                    this.tNedit_FrstSendDateDay.Enabled = true;
                    this.tNedit_LtAtSadDateTimeYear.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMonth.Enabled = false;
                    this.tNedit_LtAtSadDateTimeDay.Enabled = false;
                    this.tNedit_LtAtSadDateTimeHour.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMinute.Enabled = false;
                    this.tNedit_LtAtSadDateTimeSecond.Enabled = false;

                    break;

                // 2:�폜
                case 2:

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // �p�l��
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerGuide_Button.Enabled = false;
                    this.AutoSendDiv_tCmbEdit.Enabled = false;
                    this.HourSt_tNedit.Enabled = false;
                    this.MinuteSt_tNedit.Enabled = false;
                    this.HourEd_tNedit.Enabled = false;
                    this.MinuteEd_tNedit.Enabled = false;
                    this.tNedit_ExecInterval.Enabled = false;
                    this.CnectSendDiv_tCmbEdit.Enabled = false;
                    this.tNedit_CashRegisterNo.Enabled = false;
                    // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
                    this.Note1SetDiv_tCmbEdit.Enabled = false;
                    this.Note2SetDiv_tCmbEdit.Enabled = false;
                    this.Note3SetDiv_tCmbEdit.Enabled = false;
                    // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
                    this.ConnectUserId_tEdit.Enabled = false;
                    this.ConnectPassword_tEdit.Enabled = false;
                    this.Domain_tEdit.Enabled = false;
                    this.OrderAddress_tEdit.Enabled = false;
                    this.TimeOut_tNedit.Enabled = false;
                    this.RetryCnt_tNedit.Enabled = false;
                    this.CnectFileId_tEdit.Enabled = false;
                    this.tNedit_FrstSendDateYear.Enabled = false;
                    this.tNedit_FrstSendDateMonth.Enabled = false;
                    this.tNedit_FrstSendDateDay.Enabled = false;
                    this.tNedit_LtAtSadDateTimeYear.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMonth.Enabled = false;
                    this.tNedit_LtAtSadDateTimeDay.Enabled = false;
                    this.tNedit_LtAtSadDateTimeHour.Enabled = false;
                    this.tNedit_LtAtSadDateTimeMinute.Enabled = false;
                    this.tNedit_LtAtSadDateTimeSecond.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programer  : �c����</br>
        /// <br>Date	   : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable connectInfoWorkTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            connectInfoWorkTable.Columns.Add(DELETE_DATE, typeof(string));                 //�폜��
            connectInfoWorkTable.Columns.Add(VIEW_SECTIONCD, typeof(string));                //���_
            connectInfoWorkTable.Columns.Add(VIEW_CUSTOMERCD, typeof(string));               //���Ӑ�
            connectInfoWorkTable.Columns.Add(VIEW_AUTOSENDDIV, typeof(string));            //�������M�敪
            connectInfoWorkTable.Columns.Add(VIEW_BOOTTIME, typeof(string));                 //�������M���ԑсi�N���j
            connectInfoWorkTable.Columns.Add(VIEW_ENDTIME, typeof(string));                  //�������M���ԑсi�I���j
            connectInfoWorkTable.Columns.Add(VIEW_EXECINTERVAL, typeof(string));             //���s�Ԋu
            connectInfoWorkTable.Columns.Add(VIEW_CNECTSENDDIV, typeof(string));           //�����ڑ����M�敪
            connectInfoWorkTable.Columns.Add(CASH_REGISTER_NO, typeof(string));            //�[���ԍ�
            connectInfoWorkTable.Columns.Add(VIEW_SENDMACHINENAME, typeof(string));        //���M�[��
            connectInfoWorkTable.Columns.Add(VIEW_SENDMACHINEIPADDR, typeof(string));      //�[��IP�A�h���X
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            connectInfoWorkTable.Columns.Add(VIEW_NOTE1SETDIV, typeof(string));           //�o�͐ݒ���l�P
            connectInfoWorkTable.Columns.Add(VIEW_NOTE2SETDIV, typeof(string));           //�o�͐ݒ���l�Q
            connectInfoWorkTable.Columns.Add(VIEW_NOTE3SETDIV, typeof(string));           //�o�͐ݒ���l�R
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTUSERID, typeof(string));          //���[�U�[�R�[�h
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTPASSWORD, typeof(string));        //�p�X���[�h
            connectInfoWorkTable.Columns.Add(VIEW_DOMAIN, typeof(string));                 //�h���C��
            connectInfoWorkTable.Columns.Add(VIEW_CPRTURL, typeof(string));                 //�A�h���X
            connectInfoWorkTable.Columns.Add(VIEW_TIMEOUT, typeof(string));                //�^�C���A�E�g
            connectInfoWorkTable.Columns.Add(VIEW_RETRYCNT, typeof(string));               //���g���C��
            connectInfoWorkTable.Columns.Add(VIEW_CNECTFILEID, typeof(string));            //�ڑ��t�@�C��ID
            connectInfoWorkTable.Columns.Add(VIEW_FRSTSENDDATE, typeof(string));            //���񑗐M���
            connectInfoWorkTable.Columns.Add(VIEW_LTATSADDATETIME, typeof(string));         //�O�񎩓����M����
            connectInfoWorkTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));           //GUID

            this.Bind_DataSet.Tables.Add(connectInfoWorkTable);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // �V�K�̏ꍇ
            if (this.DataIndex < 0)
            {
                SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();
                this._connectInfoWorkClone = connectInfoWork.Clone();
                this._indexBuf = this._dataIndex;
                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToConnectInfoWork(ref this._connectInfoWorkClone);

                //�@�V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                SalCprtConnectInfoWork connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];
                // ���[�N�č\�z����
                WorkReconstruction(ref connectInfoWork);
                // ��ʓW�J����
                RecordToScreen(connectInfoWork);

                if (connectInfoWork.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(1);

                    // �N���[���쐬
                    this._connectInfoWorkClone = connectInfoWork;

                    this.AutoSendDiv_tCmbEdit.Focus();
                    AutoSendDivtEditValueChanged(connectInfoWork);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(2);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }
                
            }
        }

        /// <summary>
        /// ���[�N�č\�z����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�N�č\�z����</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void AutoSendDivtEditValueChanged(SalCprtConnectInfoWork connectInfoWork)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                this.HourSt_tNedit.Enabled = true;
                this.MinuteSt_tNedit.Enabled = true;
                this.HourEd_tNedit.Enabled = true;
                this.MinuteEd_tNedit.Enabled = true;
                this.tNedit_ExecInterval.Enabled = true;
                this.CnectSendDiv_tCmbEdit.Enabled = true;
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = connectInfoWork.CnectObjectDiv;
                if (connectInfoWork.CnectSendDiv == 2)
                {
                    this.CnectSendDiv_tCmbEdit.SelectedIndex = 0;
                }
                else
                {
                    this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
                }

                this.tNedit_CashRegisterNo.Enabled = true;
            }
            else if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // �N���A
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = -1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = -1;

                this.HourSt_tNedit.Enabled = false;
                this.MinuteSt_tNedit.Enabled = false;
                this.HourEd_tNedit.Enabled = false;
                this.MinuteEd_tNedit.Enabled = false;
                this.tNedit_ExecInterval.Enabled = false;
                this.CnectObjectDiv_tCmbEdit.Enabled = false;
                this.CnectSendDiv_tCmbEdit.Enabled = false;
                this.tNedit_CashRegisterNo.Enabled = false;
            }
        }

        /// <summary>
        /// ���[�N�č\�z����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�N�č\�z����</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void WorkReconstruction(ref SalCprtConnectInfoWork connectInfoWork)
        {
            connectInfoWork.CnectFileId = connectInfoWork.CnectFileId.Trim();
            connectInfoWork.SendMachineName = connectInfoWork.SendMachineName.Trim();
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionCode.Text = string.Empty;
            this.tEdit_SectionName.Text = string.Empty;
            this.tNedit_CustomerCode.Text = string.Empty;
            this.CustomerName_tEdit.Text = string.Empty;
            this.AutoSendDiv_tCmbEdit.SelectedIndex = 0;
            this.CnectObjectDiv_tCmbEdit.SelectedIndex = 1;
            this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
            this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex = 1;
            this.HourSt_tNedit.Text = string.Empty;
            this.MinuteSt_tNedit.Text = string.Empty;
            this.HourEd_tNedit.Text = string.Empty;
            this.MinuteEd_tNedit.Text = string.Empty;
            this.tNedit_ExecInterval.Text = string.Empty;
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            this.Note1SetDiv_tCmbEdit.SelectedIndex = 0;
            this.Note2SetDiv_tCmbEdit.SelectedIndex = 0;
            this.Note3SetDiv_tCmbEdit.SelectedIndex = 0;
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            this.ConnectUserId_tEdit.Text = string.Empty;
            this.ConnectPassword_tEdit.Text = string.Empty;
            this.Domain_tEdit.Text = string.Empty;
            this.OrderAddress_tEdit.Text = string.Empty;
            this.TimeOut_tNedit.Text = string.Empty;
            this.RetryCnt_tNedit.Text = string.Empty;
            this.CnectFileId_tEdit.Text = string.Empty;
            this.tNedit_CashRegisterNo.Text = string.Empty;
            this.SendMachineName_tEdit.Text = string.Empty;
            this.tNedit_IPNO1.Text = string.Empty;
            this.tNedit_IPNO2.Text = string.Empty;
            this.tNedit_IPNO3.Text = string.Empty;
            this.tNedit_IPNO4.Text = string.Empty;

            //���񑗐M���
            String dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.tNedit_FrstSendDateYear.Text = dateStr.Substring(0, 4);
            this.tNedit_FrstSendDateMonth.Text = dateStr.Substring(4, 2);
            this.tNedit_FrstSendDateDay.Text = dateStr.Substring(6, 2);

            this.tNedit_LtAtSadDateTimeYear.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeMonth.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeDay.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeHour.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeMinute.Text = string.Empty;
            this.tNedit_LtAtSadDateTimeSecond.Text = string.Empty;

            // �{�^��
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;

            // �p�l��
            this.tEdit_SectionCode.Enabled = true;
            this.SectionGuide_Button.Enabled = true;
            this.tNedit_CustomerCode.Enabled = true;
            this.CustomerGuide_Button.Enabled = true;
            this.AutoSendDiv_tCmbEdit.Enabled = true;
            this.HourSt_tNedit.Enabled = true;
            this.MinuteSt_tNedit.Enabled = true;
            this.HourEd_tNedit.Enabled = true;
            this.MinuteEd_tNedit.Enabled = true;
            this.tNedit_ExecInterval.Enabled = true;
            this.CnectSendDiv_tCmbEdit.Enabled = true;
            this.tNedit_CashRegisterNo.Enabled = true;
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            this.Note1SetDiv_tCmbEdit.Enabled = true;
            this.Note2SetDiv_tCmbEdit.Enabled = true;
            this.Note3SetDiv_tCmbEdit.Enabled = true;
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            this.ConnectUserId_tEdit.Enabled = true;
            this.ConnectPassword_tEdit.Enabled = true;
            this.Domain_tEdit.Enabled = true;
            this.OrderAddress_tEdit.Enabled = true;
            this.TimeOut_tNedit.Enabled = true;
            this.RetryCnt_tNedit.Enabled = true;
            this.CnectFileId_tEdit.Enabled = true;
            this.tNedit_FrstSendDateYear.Enabled = true;
            this.tNedit_FrstSendDateMonth.Enabled = true;
            this.tNedit_FrstSendDateDay.Enabled = true;
            this.tNedit_LtAtSadDateTimeYear.Enabled = false;
            this.tNedit_LtAtSadDateTimeMonth.Enabled = false;
            this.tNedit_LtAtSadDateTimeDay.Enabled = false;
            this.tNedit_LtAtSadDateTimeHour.Enabled = false;
            this.tNedit_LtAtSadDateTimeMinute.Enabled = false;
            this.tNedit_LtAtSadDateTimeSecond.Enabled = false;
        }

        /// <summary>
        /// �ڑ�����ݒ�}�X�^��ʓW�J����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void RecordToScreen(SalCprtConnectInfoWork connectInfoWork)
        {
            //���_
            if (connectInfoWork.SectionCode == "0")
            {
                this.tEdit_SectionCode.Text = string.Empty;
                this.tEdit_SectionName.Text = string.Empty;
            }
            else
            {
                this.tEdit_SectionCode.Text = connectInfoWork.SectionCode.PadLeft(2, '0');
                this.tEdit_SectionName.Text = GetSectionName(connectInfoWork.SectionCode);
            }

            //���Ӑ�
            if (connectInfoWork.CustomerCode == 0)
            {
                this.tNedit_CustomerCode.Text = string.Empty;
                this.CustomerName_tEdit.Text = string.Empty;
            }
            else
            {
                this.tNedit_CustomerCode.Text = connectInfoWork.CustomerCode.ToString().PadLeft(8, '0');
                this.CustomerName_tEdit.Text = GetCustomerName(connectInfoWork.CustomerCode);
            }

            //�������M�敪
            this.AutoSendDiv_tCmbEdit.SelectedIndex = connectInfoWork.AutoSendDiv;

            //�������M���ԑсi�N���j
            if (connectInfoWork.BootTime != 0)
            {
                this.HourSt_tNedit.Text = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(0, 2);
                this.MinuteSt_tNedit.Text = connectInfoWork.BootTime.ToString().PadLeft(4, '0').Substring(2, 2); ;
            }
            else
            {
                if (connectInfoWork.AutoSendDiv == 1)
                {
                    this.HourSt_tNedit.Text = string.Empty;
                    this.MinuteSt_tNedit.Text = string.Empty;
                }
                else
                {
                    this.HourSt_tNedit.Text = "00";
                    this.MinuteSt_tNedit.Text = "00";
                }
            }
            //�������M���ԑсi�I���j
            if (connectInfoWork.EndTime != 0)
            {
                this.HourEd_tNedit.Text = connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(0, 2);
                this.MinuteEd_tNedit.Text = connectInfoWork.EndTime.ToString().PadLeft(4, '0').Substring(2, 2); ;
            }
            else
            {
                if (connectInfoWork.AutoSendDiv == 1)
                {
                    this.HourEd_tNedit.Text = string.Empty;
                    this.MinuteEd_tNedit.Text = string.Empty;
                }
                else
                {
                    this.HourEd_tNedit.Text = "00";
                    this.MinuteEd_tNedit.Text = "00";
                }
            }
            //���s�Ԋu
            if (connectInfoWork.ExecInterval != 0)
            {
                this.tNedit_ExecInterval.Text = connectInfoWork.ExecInterval.ToString();
            }
            //�����ڑ����M�敪
            if (connectInfoWork.CnectSendDiv == 2)
            {
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 0;
            }
            else
            {
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;
            }
            //�������M�N���[��
            this.tNedit_CashRegisterNo.SetInt(connectInfoWork.CashregiSterno);
            // �[����
            this.SendMachineName_tEdit.Text = connectInfoWork.SendMachineName;          
            // �[��IP�A�h���X
            if (!string.IsNullOrEmpty(connectInfoWork.SendMachineIpAddr))
            {
                string[] ipAddr = connectInfoWork.SendMachineIpAddr.ToString().Trim().Split('.');
                this.tNedit_IPNO1.Text = ipAddr[0];
                this.tNedit_IPNO2.Text = ipAddr[1];
                this.tNedit_IPNO3.Text = ipAddr[2];
                this.tNedit_IPNO4.Text = ipAddr[3];
            }
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            //�o�͐ݒ���l�P
            this.Note1SetDiv_tCmbEdit.Text = connectInfoWork.Note1SetDiv.ToString().Trim();
            //�o�͐ݒ���l�Q
            this.Note2SetDiv_tCmbEdit.Text = connectInfoWork.Note2SetDiv.ToString().Trim();
            //�o�͐ݒ���l�R
            this.Note3SetDiv_tCmbEdit.Text = connectInfoWork.Note3SetDiv.ToString().Trim();
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            //���[�U�[�R�[�h
            this.ConnectUserId_tEdit.Text = connectInfoWork.SendCcnctUserid.ToString().Trim();
            //�p�X���[�h
            this.ConnectPassword_tEdit.Text = connectInfoWork.SendCcnctPass.ToString().Trim();
            //�h���C��
            this.Domain_tEdit.Text = connectInfoWork.CprtDomain;
            //�A�h���X
            this.OrderAddress_tEdit.Text = connectInfoWork.CprtUrl;
            //�^�C���A�E�g
            this.TimeOut_tNedit.Text = connectInfoWork.LoginTimeoutVal.ToString();
            //���g���C��
            this.RetryCnt_tNedit.Text = connectInfoWork.RetryCnt.ToString();
            //�ڑ��t�@�C��ID
            this.CnectFileId_tEdit.Text = connectInfoWork.CnectFileId;
            //���񑗐M���
            if (connectInfoWork.FrstSendDate== 0)
            {
                this.tNedit_FrstSendDateYear.Text = string.Empty;
                this.tNedit_FrstSendDateMonth.Text = string.Empty;
                this.tNedit_FrstSendDateDay.Text = string.Empty;

            }
            else
            {
                this.tNedit_FrstSendDateYear.Text = connectInfoWork.FrstSendDate.ToString().PadLeft(6, '0').Substring(0, 4);
                this.tNedit_FrstSendDateMonth.Text = connectInfoWork.FrstSendDate.ToString().PadLeft(6, '0').Substring(4, 2);
                this.tNedit_FrstSendDateDay.Text = connectInfoWork.FrstSendDate.ToString().PadLeft(6, '0').Substring(6, 2);
 
            }
            //�O�񎩓����M����
            if (connectInfoWork.LtAtSadDateTime == DateTime.MinValue)
            {
                this.tNedit_LtAtSadDateTimeYear.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeMonth.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeDay.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeHour.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeMinute.Text = string.Empty;
                this.tNedit_LtAtSadDateTimeSecond.Text = string.Empty;
            }
            else
            {
                List<string> dateList = this.GetLtAtSadDateTimeList(connectInfoWork.LtAtSadDateTime);

                this.tNedit_LtAtSadDateTimeYear.Text = dateList[0];
                this.tNedit_LtAtSadDateTimeMonth.Text = dateList[1];
                this.tNedit_LtAtSadDateTimeDay.Text = dateList[2];
                this.tNedit_LtAtSadDateTimeHour.Text = dateList[3];
                this.tNedit_LtAtSadDateTimeMinute.Text = dateList[4];
                this.tNedit_LtAtSadDateTimeSecond.Text = dateList[5];
 
            }
        }

        /// <summary>
        /// �O�񎩓����M������Convert����(ToArrayList)
        /// </summary>
        /// <param name="ltAtSadDateTime">�O�񎩓����M����</param>
        /// <remarks>
        /// <br>Note        : �O�񎩓����M������Convert�������s���B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private List<string> GetLtAtSadDateTimeList(DateTime ltAtSadDateTime)
        {
            List<string> ltAtSadDateTimList = new List<string>();

            String dateStr = ltAtSadDateTime.ToString("yyyyMMddHHmmss");
            ltAtSadDateTimList.Add(dateStr.Substring(0, 4));
            ltAtSadDateTimList.Add(dateStr.Substring(4, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(6, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(8, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(10, 2));
            ltAtSadDateTimList.Add(dateStr.Substring(12, 2));

            return ltAtSadDateTimList;
        }

        /// <summary>
        /// �ۑ�����(SaveSalCprtConnectInfoWork())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// </remarks>
        private bool SaveSalCprtConnectInfoWork()
        {
            bool result = false;

            if (this.tNedit_CashRegisterNo.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_CashRegisterNo, this.tNedit_CashRegisterNo);
                this.tRetKeyControl1_ChangeFocus(this, eArgs);
                if (this._isError)
                {
                    this._isError = false;
                    return result;
                }
            }

            //��ʃf�[�^���̓`�F�b�N����
            bool chkSt = ScreenDataCheck();
            if (!chkSt)
            {
                return chkSt;
            }

            SalCprtConnectInfoWork connectInfoWork = null;
            SalCprtConnectInfoWork connectInfoWorkPre = new SalCprtConnectInfoWork();

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];
                connectInfoWorkPre = connectInfoWork.Clone();
            }

            // ��ʂɃf�[�^���擾
            ScreenToConnectInfoWork(ref connectInfoWork);


            // �N�����ԁA�I�����ԁA���s�Ԋu���ύX���邩
            int flag = 0;
            if (!((connectInfoWorkPre.BootTime == connectInfoWork.BootTime)
               && (connectInfoWorkPre.EndTime == connectInfoWork.EndTime)
               && (connectInfoWorkPre.ExecInterval == connectInfoWork.ExecInterval)))
            {
                flag = 1;
            }

            // �ۑ�����
            int status = this._connectInfoWorkAcs.Write(ref connectInfoWork, flag);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        this.Close();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								       // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,        // �G���[���x��
                            ASSEMBLY_ID,						       // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",// �\�����郁�b�Z�[�W
                            0, 									       // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				       // �\������{�^��
                        this.AutoSendDiv_tCmbEdit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

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
                            "PrcPrSt",  �@�@                        // �v���O��������
                            "SalCprtConnectInfoWork",               // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._connectInfoWorkAcs,				    	// �G���[�����������I�u�W�F�N�g
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

            // ��ʃf�[�^�X�V

            int totalCount = 0;
            if (flag == 1)
            {
                Search(ref totalCount, 0);
            }
            else
            {
                ConnectInfoWorkToDataSet(connectInfoWork, this.DataIndex);
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // �V�K�o�^�����Ȃ��̏ꍇ
            if (this.Mode_Label.Text.Equals(UPDATE_MODE))
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
            // �V�K�o�^��
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                this.ScreenClear();
            }
            result = true;
            return result;
        }

        /// <summary>
        /// ��ʓ��͏��s�����̃G���[����
        /// </summary>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ��ʓ��͏��s�����̃G���[�������s���܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// </remarks>
        private bool ScreenDataCheck()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message, 							// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                    TimeOut_tNedit.Leave -= new EventHandler(TimeOut_tNedit_Leave);
                    RetryCnt_tNedit.Leave -= new EventHandler(RetryCnt_tNedit_Leave);
                    HourSt_tNedit.Leave -= new EventHandler(Hour_tNedit_Leave);
                    MinuteSt_tNedit.Leave -= new EventHandler(Minute_tNedit_Leave);
                    HourEd_tNedit.Leave -= new EventHandler(HourEd_tNedit_Leave);
                    MinuteEd_tNedit.Leave -= new EventHandler(MinuteEd_tNedit_Leave);
                    tNedit_FrstSendDateYear.Leave -= new EventHandler(tNedit_FrstSendDateYear_Leave);
                    tNedit_FrstSendDateMonth.Leave -= new EventHandler(tNedit_FrstSendDateMonth_Leave);
                    tNedit_FrstSendDateDay.Leave -= new EventHandler(tNedit_FrstSendDateDay_Leave);
                    control.Focus();
                    TimeOut_tNedit.Leave += new EventHandler(TimeOut_tNedit_Leave);
                    RetryCnt_tNedit.Leave += new EventHandler(RetryCnt_tNedit_Leave);
                    HourSt_tNedit.Leave += new EventHandler(Hour_tNedit_Leave);
                    MinuteSt_tNedit.Leave += new EventHandler(Minute_tNedit_Leave);
                    HourEd_tNedit.Leave += new EventHandler(HourEd_tNedit_Leave);
                    MinuteEd_tNedit.Leave += new EventHandler(MinuteEd_tNedit_Leave);
                    tNedit_FrstSendDateYear.Leave += new EventHandler(tNedit_FrstSendDateYear_Leave);
                    tNedit_FrstSendDateMonth.Leave += new EventHandler(tNedit_FrstSendDateMonth_Leave);
                    tNedit_FrstSendDateDay.Leave += new EventHandler(tNedit_FrstSendDateDay_Leave);

                }
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note	�@ : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // 
            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
            {
                control = this.tEdit_SectionCode;
                message = "���_�A���Ӑ�̂����ꂩ����͂��Ă��������B";
                return (false);
            }

            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                // �������M���ԑсi�N���j ��
                if (string.IsNullOrEmpty(this.HourSt_tNedit.Text.Trim()))
                {
                    control = this.HourSt_tNedit;
                    message = "�������M���ԑт���͂��ĉ������B";
                    return (false);
                }

                if (int.Parse(this.HourSt_tNedit.Text) < 0 || int.Parse(this.HourSt_tNedit.Text) > 23)
                {
                    control = this.HourSt_tNedit;
                    message = "��������͂��Ă��������B";
                    return (false);
                }

                // �������M���ԑсi�N���j ��
                if (string.IsNullOrEmpty(this.MinuteSt_tNedit.Text.Trim()))
                {
                    control = this.MinuteSt_tNedit;
                    message = "�������M���ԑт���͂��ĉ������B";
                    return (false);
                }

                if (int.Parse(this.MinuteSt_tNedit.Text) < 0 || int.Parse(this.MinuteSt_tNedit.Text) > 59)
                {
                    control = this.MinuteSt_tNedit;
                    message = "��������͂��Ă��������B";
                    return (false);
                }
                // �������M���ԑсi�I���j ��
                if (string.IsNullOrEmpty(this.HourEd_tNedit.Text.Trim()))
                {
                    control = this.HourEd_tNedit;
                    message = "�������M���ԑт���͂��ĉ������B";
                    return (false);
                }

                if (int.Parse(this.HourEd_tNedit.Text) < 0 || int.Parse(this.HourEd_tNedit.Text) > 23)
                {
                    control = this.HourEd_tNedit;
                    message = "��������͂��Ă��������B";
                    return (false);
                }

                // �������M���ԑсi�I���j ��
                if (string.IsNullOrEmpty(this.MinuteEd_tNedit.Text.Trim()))
                {
                    control = this.MinuteEd_tNedit;
                    message = "�������M���ԑт���͂��ĉ������B";
                    return (false);
                }

                if (int.Parse(this.MinuteEd_tNedit.Text) < 0 || int.Parse(this.MinuteEd_tNedit.Text) > 59)
                {
                    control = this.MinuteEd_tNedit;
                    message = "��������͂��Ă��������B";
                    return (false);
                }

                // �������M���ԑсi�N���j > �������M���ԑсi�I���j�̏ꍇ�A�G���[�Ƃ���
                if (this.HourSt_tNedit.GetInt() > this.HourEd_tNedit.GetInt())
                {
                    control = this.HourSt_tNedit;
                    message = "�J�n���Ԉȍ~�̎��Ԃ���͂��Ă��������B";
                    return (false);
                }

                if ((this.HourSt_tNedit.GetInt() == this.HourEd_tNedit.GetInt()) &&
                    (this.MinuteSt_tNedit.GetInt() > this.MinuteEd_tNedit.GetInt()))
                {
                    control = this.MinuteSt_tNedit;
                    message = "�J�n���Ԉȍ~�̎��Ԃ���͂��Ă��������B";
                    return (false);
                }

                // ���s�Ԋu
                if (string.IsNullOrEmpty(this.tNedit_ExecInterval.Text.Trim()))
                {
                    control = this.tNedit_ExecInterval;
                    message = "���s�Ԋu��ݒ肵�ĉ������B";
                    return (false);
                }

                if (int.Parse(this.tNedit_ExecInterval.Text) < 15)
                {
                    control = this.tNedit_ExecInterval;
                    message = "15���ȏ����͂��Ă��������B";
                    return (false);
                }


                // �[���ԍ��}�X�^�`�F�b�N
                if (this.tNedit_CashRegisterNo.GetInt() == 0)
                {
                    control = this.tNedit_CashRegisterNo;
                    message = "�������M�N���[����ݒ肵�ĉ������B";
                    return false;
                }
            }

            // ���[�U�[�R�[�h
            if (string.IsNullOrEmpty(this.ConnectUserId_tEdit.Text.Trim()))
            {
                control = this.ConnectUserId_tEdit;
                message = "���[�U�[�R�[�h����͂��Ă��������B";
                return (false);
            }

            // �p�X���[�h
            if (string.IsNullOrEmpty(this.ConnectPassword_tEdit.Text.Trim()))
            {
                control = this.ConnectPassword_tEdit;
                message = "�p�X���[�h����͂��Ă��������B";
                return (false);
            }

            // �����p�A�h���X
            if (string.IsNullOrEmpty(this.OrderAddress_tEdit.Text.Trim()))
            {
                control = this.OrderAddress_tEdit;
                message = "�����p�A�h���X����͂��Ă��������B";
                return (false);
            }

            // �^�C���A�E�g
            if (string.IsNullOrEmpty(this.TimeOut_tNedit.Text.Trim()))
            {
                control = this.TimeOut_tNedit;
                message = "�^�C���A�E�g����͂��Ă��������B";
                return (false);
            }

            if (int.Parse(this.TimeOut_tNedit.Text) < 0 || int.Parse(this.TimeOut_tNedit.Text) > 3600)
            {
                control = this.TimeOut_tNedit;
                message = "3600�b�ȉ�����͂��Ă��������B";
                return (false);
            }
            this.TimeOut_tNedit.Text = int.Parse(this.TimeOut_tNedit.Text).ToString();

            // ���g���C��
            if (string.IsNullOrEmpty(this.RetryCnt_tNedit.Text.Trim()))
            {
                control = this.RetryCnt_tNedit;
                message = "���g���C�񐔂���͂��Ă��������B";
                return (false);
            }


            if (int.Parse(this.RetryCnt_tNedit.Text) < 0 || int.Parse(this.RetryCnt_tNedit.Text) > 5)
            {
                control = this.RetryCnt_tNedit;
                message = "5��ȉ�����͂��Ă��������B";
                return (false);
            }

            // �ڑ��t�@�C��ID
            if (string.IsNullOrEmpty(this.CnectFileId_tEdit.Text.Trim()))
            {
                control = this.CnectFileId_tEdit;
                message = "�ڑ��t�@�C��ID����͂��Ă��������B";
                return (false);
            }

            // ���񑗐M���
            if (this.tNedit_FrstSendDateYear.DataText.Trim() == string.Empty
                || this.tNedit_FrstSendDateMonth.DataText.Trim() == string.Empty
                || this.tNedit_FrstSendDateDay.DataText.Trim() == string.Empty)
            {
                control = this.tNedit_FrstSendDateYear;
                message = "���񑗐M�����ݒ肵�ĉ������B";
                return (false);
            }

            int frstSendDate = GetFrstSendDate();
            if (frstSendDate != 0)
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(frstSendDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    control = this.tNedit_FrstSendDateYear;
                    message = "���t����͂��Ă��������B";
                    return (false);
                }
            }

            return true;
        }

        /// <summary>
        /// �ڑ�����ݒ�N���X�i�[����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�ڑ�����ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void ScreenToConnectInfoWork(ref SalCprtConnectInfoWork connectInfoWork)
        {
            if (connectInfoWork == null)
            {
                connectInfoWork = new SalCprtConnectInfoWork();
            }
            // ��ƃR�[�h
            connectInfoWork.EnterpriseCode = this._enterpriseCode;
            // �d����R�[�h    
            connectInfoWork.SupplierCd = SUPPLIERCODE;
            // ���_
            if (tEdit_SectionCode.Text.Trim().Equals(""))
            {
                connectInfoWork.SectionCode = "0";
            }
            else
            {
                connectInfoWork.SectionCode = tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
            }
            
            // ���Ӑ�
            connectInfoWork.CustomerCode = tNedit_CustomerCode.GetInt();
            //�������M�敪
            connectInfoWork.AutoSendDiv = AutoSendDiv_tCmbEdit.SelectedIndex;
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // �������M�Ώ�
                connectInfoWork.CnectObjectDiv = -1;
                // �����ڑ����M�敪
                connectInfoWork.CnectSendDiv = -1;
            }
            else
            {
                // �������M�Ώ�
                connectInfoWork.CnectObjectDiv = this.CnectObjectDiv_tCmbEdit.SelectedIndex;
                // �����ڑ����M�敪
                if (this.CnectSendDiv_tCmbEdit.SelectedIndex == 0)
                {
                    // DB�ɁA2�F���ׂ�
                    connectInfoWork.CnectSendDiv = 2;
                }
                else
                {
                    // DB�ɁA0�F�����M
                    connectInfoWork.CnectSendDiv = 0;
                }
            }

            // �������M���ԑсi�N���j
            if (!string.IsNullOrEmpty(this.HourSt_tNedit.Text) && !string.IsNullOrEmpty(this.MinuteSt_tNedit.Text))
            {
                connectInfoWork.BootTime = int.Parse(this.HourSt_tNedit.Text + this.MinuteSt_tNedit.Text);
            }
            // �������M���ԑсi�I���j
            if (!string.IsNullOrEmpty(this.HourEd_tNedit.Text) && !string.IsNullOrEmpty(this.MinuteEd_tNedit.Text))
            {
                connectInfoWork.EndTime = int.Parse(this.HourEd_tNedit.Text + this.MinuteEd_tNedit.Text);
            }
            //���s�Ԋu
            connectInfoWork.ExecInterval = tNedit_ExecInterval.GetInt();
            // �[���ԍ�
            connectInfoWork.CashregiSterno = this.tNedit_CashRegisterNo.GetInt();
            // ���M�[��
            connectInfoWork.SendMachineName = this.SendMachineName_tEdit.Text.Trim();
            // �ڑ��v���O�����^�C�v�u1:S&E�v�Œ�ŃZ�b�g
            connectInfoWork.CnectProgramType = 1;
            // ���񑗐M���
            connectInfoWork.FrstSendDate = this.GetFrstSendDate();
            // �O�񎩓����M����
            connectInfoWork.LtAtSadDateTime = this.GetLtAtSadDateTime();
            // �������M�敪
            connectInfoWork.AutoSendDiv = this.AutoSendDiv_tCmbEdit.SelectedIndex;
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
            // �o�͐ݒ���l�P
            connectInfoWork.Note1SetDiv = this.Note1SetDiv_tCmbEdit.SelectedIndex;
            // �o�͐ݒ���l�Q
            connectInfoWork.Note2SetDiv = this.Note2SetDiv_tCmbEdit.SelectedIndex;
            // �o�͐ݒ���l�R
            connectInfoWork.Note3SetDiv = this.Note3SetDiv_tCmbEdit.SelectedIndex;
            // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            // ���[�U�[�R�[�h
            connectInfoWork.SendCcnctUserid = this.ConnectUserId_tEdit.Text;
            // �p�X���[�h
            connectInfoWork.SendCcnctPass = this.ConnectPassword_tEdit.Text;
            // �v���g�R��
            connectInfoWork.Protocol = this.DaihatsuOrdreDiv_tCmbEdit.SelectedIndex;
            // �h���C��
            connectInfoWork.CprtDomain = this.Domain_tEdit.Text;
            // �����p�A�h���X
            connectInfoWork.CprtUrl = this.OrderAddress_tEdit.Text;
            // �ڑ��t�@�C��ID
            connectInfoWork.CnectFileId = this.CnectFileId_tEdit.Text.Trim();
            // �^�C���A�E�g
            if (!string.IsNullOrEmpty(this.TimeOut_tNedit.Text))
            {
                connectInfoWork.LoginTimeoutVal = int.Parse(this.TimeOut_tNedit.Text);
            }
            // ���g���C��
            if (!string.IsNullOrEmpty(this.RetryCnt_tNedit.Text))
            {
                connectInfoWork.RetryCnt = int.Parse(this.RetryCnt_tNedit.Text); 
            }
            string ipst1 = this.tNedit_IPNO1.Text;
            string ipst2 = this.tNedit_IPNO2.Text;
            string ipst3 = this.tNedit_IPNO3.Text;
            string ipst4 = this.tNedit_IPNO4.Text;
            if (string.IsNullOrEmpty(ipst1) && string.IsNullOrEmpty(ipst2) && string.IsNullOrEmpty(ipst3) && string.IsNullOrEmpty(ipst4))
            {
                connectInfoWork.SendMachineIpAddr = string.Empty;
            }
            else
            {
                connectInfoWork.SendMachineIpAddr = this.tNedit_IPNO1.GetInt().ToString().Trim() + "." + this.tNedit_IPNO2.GetInt().ToString().Trim() + "." + this.tNedit_IPNO3.GetInt().ToString().Trim() + "." + this.tNedit_IPNO4.GetInt().ToString().Trim();
            }
        }

        /// <summary>
        /// ���񑗐M�����conver����(ToDateTime)
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ���񑗐M�����conver�������s���܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private int GetFrstSendDate()
        {
            StringBuilder frstSendDateBuf = new StringBuilder();
            int frstSendDateInt = 0;
            frstSendDateBuf.Append(this.tNedit_FrstSendDateYear.Value);
            frstSendDateBuf.Append(this.tNedit_FrstSendDateMonth.Value);
            frstSendDateBuf.Append(this.tNedit_FrstSendDateDay.Value);
            if (!string.IsNullOrEmpty(frstSendDateBuf.ToString()))
            {
                frstSendDateInt = Convert.ToInt32(frstSendDateBuf.ToString());
            }

            return frstSendDateInt;
        }

        /// <summary>
        /// �O�񎩓����M������conver����(ToDateTime)
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �O�񎩓����M������conver�������s���܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private DateTime GetLtAtSadDateTime()
        {
            StringBuilder syncExecDateBuf = new StringBuilder();
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeYear.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeMonth.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeDay.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeHour.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeMinute.Value);
            syncExecDateBuf.Append(this.tNedit_LtAtSadDateTimeSecond.Value);

            DateTime syncExecDate = new DateTime();
            try
            {
                syncExecDate = string.IsNullOrEmpty(syncExecDateBuf.ToString())
                    ? DateTime.MinValue
                    : new DateTime(
                    this.tNedit_LtAtSadDateTimeYear.GetInt(),
                    this.tNedit_LtAtSadDateTimeMonth.GetInt(),
                    this.tNedit_LtAtSadDateTimeDay.GetInt(),
                    Convert.ToInt32(this.tNedit_LtAtSadDateTimeHour.DataText),
                    Convert.ToInt32(this.tNedit_LtAtSadDateTimeMinute.DataText),
                    Convert.ToInt32(this.tNedit_LtAtSadDateTimeSecond.DataText),
                    0);
            }
            catch
            {
                syncExecDate = DateTime.MinValue;
            }

            return syncExecDate;
            
        }

        /// <summary>
        /// FormClose �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : FormClose �C�x���g</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSDC09010UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ChangeFocus �C�x���g</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            this._isError = false;
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CashRegisterNo":
                    {
                        if (tNedit_CashRegisterNo.GetInt() == 0)
                        {
                            tNedit_CashRegisterNo.Clear();
                            SendMachineName_tEdit.Clear();
                            this.tNedit_IPNO1.Clear();
                            this.tNedit_IPNO2.Clear();
                            this.tNedit_IPNO3.Clear();
                            this.tNedit_IPNO4.Clear();
                            return;
                        }

                        // �[���Ǘ��ݒ�}�X�^���疼�̂��擾
                        PosTerminalMg posTerminalMg = GetPosTerminalMg(tNedit_CashRegisterNo.GetInt());
                        if ((posTerminalMg != null) &&
                            (posTerminalMg.LogicalDeleteCode == 0))
                        {
                            SendMachineName_tEdit.Text = posTerminalMg.MachineName;
                            if (!string.IsNullOrEmpty(posTerminalMg.MachineIpAddr))
                            {
                                string[] ipAddr = posTerminalMg.MachineIpAddr.Trim().Split('.');
                                this.tNedit_IPNO1.Text = ipAddr[0];
                                this.tNedit_IPNO2.Text = ipAddr[1];
                                this.tNedit_IPNO3.Text = ipAddr[2];
                                this.tNedit_IPNO4.Text = ipAddr[3];
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Y������[���ԍ������݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            this._isError = true;
                            tNedit_CashRegisterNo.Clear();
                            SendMachineName_tEdit.Clear();
                            this.tNedit_IPNO1.Clear();
                            this.tNedit_IPNO2.Clear();
                            this.tNedit_IPNO3.Clear();
                            this.tNedit_IPNO4.Clear();

                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "tEdit_SectionCode":
                    {
                        string sectionCode = this.tEdit_SectionCode.DataText;

                        if (sectionCode.Trim().Equals(""))
                        {
                            this.tEdit_SectionName.DataText = string.Empty;
                            return;
                        }

                        // ���_���̎擾
                        string sectionName = GetSectionName(sectionCode);

                        if (sectionName.Trim() != string.Empty)
                        {
                            this.tEdit_SectionName.DataText = sectionName;
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_CustomerCode;
                                }
                            }
                                
                    
                        }
                        else
                        {
                            TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            "���_�����݂��܂���B",	                // �\�����郁�b�Z�[�W
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                            this._isError = true;
                            this.tEdit_SectionName.Clear();
                            this.tEdit_SectionCode.Clear();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (this.ModeChangeProc())
                        {
                            return;
                        }

                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tNedit_CustomerCode.Clear();
                            this.CustomerName_tEdit.Clear();
                            return;
                        }

                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        // ���Ӑ於�̎擾
                        string customerName = GetCustomerName(customerCode);

                        if (customerName.Trim() != string.Empty)
                        {
                            this.CustomerName_tEdit.DataText = customerName;
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.AutoSendDiv_tCmbEdit;
                                }
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            "���Ӑ悪���݂��܂���B",	            // �\�����郁�b�Z�[�W
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                            this._isError = true;
                            this.tNedit_CustomerCode.Clear();
                            this.CustomerName_tEdit.Clear();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
            }

            // ��ʂ����̏ꍇ�@�d���於�̎擾���Ȃ�
            if (e.PrevCtrl == null || e.NextCtrl.Name == "Cancel_Button")
            {
                return;
            }
            if (e.PrevCtrl.Name == this.AutoSendDiv_tCmbEdit.Name && e.Key == Keys.Down)
            {
                if (this.HourSt_tNedit.Enabled)
                {
                    e.NextCtrl = this.HourSt_tNedit;
                }
                else
                {
                    e.NextCtrl = this.ConnectUserId_tEdit;
                }
            }
            if ((e.PrevCtrl.Name == this.Delete_Button.Name || e.PrevCtrl.Name == this.Ok_Button.Name || e.PrevCtrl.Name == this.Revive_Button.Name || e.PrevCtrl.Name == this.Cancel_Button.Name) && (e.Key == Keys.Up))
            {
                e.NextCtrl = this.CnectFileId_tEdit;
            }
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            int status;
            CustomerInfo customerInfo = new CustomerInfo();

            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        customerName = customerSearchRet.Name.Trim() + customerSearchRet.Name2.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                    }
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
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
            else
            {
                int status = this._posTerminalMgAcs.Read(out posTerminalMg, this._enterpriseCode, cashRegisterNo);
                if (status != 0)
                {
                    posTerminalMg = null;
                }
            }

            return posTerminalMg;
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.tNedit_CustomerCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._cusotmerGuideSelected == true)
                {
                    ModeChangeProc();
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
        /// <br>Note        : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
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
            this.CustomerName_tEdit.DataText = customerSearchRet.Name.Trim();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            string customerCode = string.Empty;
            string sectionCode = string.Empty;
            // ���Ӑ�
            if (tNedit_CustomerCode.Text!="")
            {
                customerCode = tNedit_CustomerCode.Text.PadLeft(8, '0');
            }
            // ���_
            if (tEdit_SectionCode.Text != "")
            {
                sectionCode = tEdit_SectionCode.Text.PadLeft(2, '0');
            }

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSectionCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCD];
                string dsCustomerCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMERCD];
                if ((dsSectionCode == sectionCode) && (dsCustomerCode == customerCode))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̔���A�g�ڑ��}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �O���[�v�R�[�h�̃N���A
                        tNedit_CustomerCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̔���A�g�ڑ��}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // ���Ӑ�̃N���A
                                tNedit_CustomerCode.Clear();
                                CustomerName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            this.AutoSendDiv_tCmbEdit.Focus();
            return false;
        }

        /// <summary>
        /// ���Ӑ於�̃��X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂̃��X�g���擾���܂��B</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // �_���폜�f�[�^�͓ǂݍ��܂Ȃ�
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }
        #endregion ----- Private Method -----

        #region ----- Control Events -----
        /// <summary>
        ///	Form.Load �C�x���g(PMSDC09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSDC09010UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSDC09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void PMSDC09010UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕۑ������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!SaveSalCprtConnectInfoWork())
            {
                return;
            }
            else
            {
                this.AutoSendDiv_tCmbEdit.Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            int status = 0;

            SalCprtConnectInfoWork connectInfoWork = null;
            // �����Ώۃf�[�^�擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];

            // ����
            status = this._connectInfoWorkAcs.Revival(ref connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        ConnectInfoWorkToDataSet(connectInfoWork, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._connectInfoWorkAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
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
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʊ��S�폜�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, �@ // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }

            SalCprtConnectInfoWork connectInfoWork = null;
            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (SalCprtConnectInfoWork)this._connectInfoWorkTable[guid];


            // �d������_���폜����
            int status = this._connectInfoWorkAcs.Delete(connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._connectInfoWorkTable.Remove(connectInfoWork.FileHeaderGuid);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
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
                            this._connectInfoWorkAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
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
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();

                ScreenToConnectInfoWork(ref connectInfoWork);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if (!((this._connectInfoWorkClone.SendCcnctUserid.Trim() == connectInfoWork.SendCcnctUserid.Trim())
                   && (this._connectInfoWorkClone.SendCcnctPass.Trim() == connectInfoWork.SendCcnctPass.Trim())
                   && (this._connectInfoWorkClone.CprtUrl == connectInfoWork.CprtUrl)
                   && (this._connectInfoWorkClone.LoginTimeoutVal == connectInfoWork.LoginTimeoutVal)
                   && (this._connectInfoWorkClone.AutoSendDiv == connectInfoWork.AutoSendDiv)
                   && (this._connectInfoWorkClone.BootTime == connectInfoWork.BootTime)
                   && (this._connectInfoWorkClone.CnectObjectDiv == connectInfoWork.CnectObjectDiv)
                   && (this._connectInfoWorkClone.CnectSendDiv == connectInfoWork.CnectSendDiv)
                   && (this._connectInfoWorkClone.CnectFileId == connectInfoWork.CnectFileId)
                   && (this._connectInfoWorkClone.CashregiSterno == connectInfoWork.CashregiSterno)
                   && (this._connectInfoWorkClone.RetryCnt == connectInfoWork.RetryCnt)
                   && (this._connectInfoWorkClone.SectionCode == connectInfoWork.SectionCode)
                   && (this._connectInfoWorkClone.CustomerCode == connectInfoWork.CustomerCode)
                   && (this._connectInfoWorkClone.EndTime == connectInfoWork.EndTime)
                   && (this._connectInfoWorkClone.ExecInterval == connectInfoWork.ExecInterval)
                    // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
                   && (this._connectInfoWorkClone.Note1SetDiv == connectInfoWork.Note1SetDiv)
                   && (this._connectInfoWorkClone.Note2SetDiv == connectInfoWork.Note2SetDiv)
                   && (this._connectInfoWorkClone.Note3SetDiv == connectInfoWork.Note3SetDiv)
                    // --- ADD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
                   && (this._connectInfoWorkClone.FrstSendDate == connectInfoWork.FrstSendDate)
                   && (this._connectInfoWorkClone.LtAtSadDateTime.ToString("yyyyMMddhhmmss") == connectInfoWork.LtAtSadDateTime.ToString("yyyyMMddhhmmss"))
                   && (this._connectInfoWorkClone.SupplierCd == connectInfoWork.SupplierCd)))                  
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_QUESTION,
                       this.Name,
                       "�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                       "�o�^���Ă��悢�ł����H",
                       0,
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxDefaultButton.Button1);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSalCprtConnectInfoWork())
                                {
                                    return;
                                }
                                else
                                {
                                    this.AutoSendDiv_tCmbEdit.Focus();
                                }
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
        /// �������M�敪���ω����̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[�����̒l���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void AutoSendDiv_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 0)
            {
                this.HourSt_tNedit.Enabled = true;
                this.MinuteSt_tNedit.Enabled = true;
                this.HourEd_tNedit.Enabled = true;
                this.MinuteEd_tNedit.Enabled = true;
                this.tNedit_ExecInterval.Enabled = true;
                this.CnectObjectDiv_tCmbEdit.Enabled = true;
                this.CnectSendDiv_tCmbEdit.Enabled = true;

                this.CnectObjectDiv_tCmbEdit.SelectedIndex = 1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = 1;

                this.tNedit_CashRegisterNo.Enabled = true;
            }
            else if (this.AutoSendDiv_tCmbEdit.SelectedIndex == 1)
            {
                // �N���A
                this.CnectObjectDiv_tCmbEdit.SelectedIndex = -1;
                this.CnectSendDiv_tCmbEdit.SelectedIndex = -1;

                this.HourSt_tNedit.Enabled = false;
                this.MinuteSt_tNedit.Enabled = false;
                this.HourEd_tNedit.Enabled = false;
                this.MinuteEd_tNedit.Enabled = false;
                this.tNedit_ExecInterval.Enabled = false;
                this.CnectObjectDiv_tCmbEdit.Enabled = false;
                this.CnectSendDiv_tCmbEdit.Enabled = false;

                this.tNedit_CashRegisterNo.Clear();
                this.tNedit_CashRegisterNo.Enabled = false;
                this.SendMachineName_tEdit.Clear();
                this.tNedit_IPNO1.Clear();
                this.tNedit_IPNO2.Clear();
                this.tNedit_IPNO3.Clear();
                this.tNedit_IPNO4.Clear();

            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void Hour_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.HourSt_tNedit.Text))
            {
                try
                {
                    int hour = int.Parse(this.HourSt_tNedit.Text.Trim());
                }
                catch
                {
                    this.HourSt_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.HourSt_tNedit);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void Minute_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MinuteSt_tNedit.Text))
            {
                try
                {
                    int minite = int.Parse(this.MinuteSt_tNedit.Text.Trim());
                }
                catch
                {
                    this.MinuteSt_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.MinuteSt_tNedit);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void TimeOut_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TimeOut_tNedit.Text))
            {
                try
                {
                    int retryCnt = int.Parse(this.TimeOut_tNedit.Text.Trim());
                }
                catch
                {
                    this.TimeOut_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.TimeOut_tNedit);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void RetryCnt_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.RetryCnt_tNedit.Text))
            {
                try
                {
                    int retryCnt = int.Parse(this.RetryCnt_tNedit.Text.Trim());
                }
                catch
                {
                    this.RetryCnt_tNedit.Clear();
                    return;
                }
                ScreenSingleDataCheck(this.RetryCnt_tNedit);
            }
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note	�@ : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenSingleDataCheck(Control control)
        {
            string message = string.Empty;
            // �������M�N������
            if (control.Name == this.HourSt_tNedit.Name)
            {
                if (int.Parse(this.HourSt_tNedit.Text) < 0 || int.Parse(this.HourSt_tNedit.Text) > 23)
                {
                    control = this.HourSt_tNedit;
                    message = "��������͂��Ă��������B";
                }
            }
            // �������M�N������
            if (control.Name == this.MinuteSt_tNedit.Name)
            {
                if (int.Parse(this.MinuteSt_tNedit.Text) < 0 || int.Parse(this.MinuteSt_tNedit.Text) > 59)
                {
                    control = this.MinuteSt_tNedit;
                    message = "��������͂��Ă��������B";
                }
            }

            // �������M�I������
            if (control.Name == this.HourEd_tNedit.Name)
            {
                if (int.Parse(this.HourEd_tNedit.Text) < 0 || int.Parse(this.HourEd_tNedit.Text) > 23)
                {
                    control = this.HourEd_tNedit;
                    message = "��������͂��Ă��������B";
                }
            }
            // �������M�I������
            if (control.Name == this.MinuteEd_tNedit.Name)
            {
                if (int.Parse(this.MinuteEd_tNedit.Text) < 0 || int.Parse(this.MinuteEd_tNedit.Text) > 59)
                {
                    control = this.MinuteEd_tNedit;
                    message = "��������͂��Ă��������B";
                }
            }
            // �^�C���A�E�g
            if (control.Name == this.TimeOut_tNedit.Name)
            {
                if (int.Parse(this.TimeOut_tNedit.Text) < 0 || int.Parse(this.TimeOut_tNedit.Text) > 3600)
                {
                    control = this.TimeOut_tNedit;
                    message = "3600�b�ȉ�����͂��Ă��������B";
                }
                this.TimeOut_tNedit.Text = int.Parse(this.TimeOut_tNedit.Text).ToString();
            }
            // ���g���C��
            if (control.Name == this.RetryCnt_tNedit.Name)
            {
                if (int.Parse(this.RetryCnt_tNedit.Text) < 0 || int.Parse(this.RetryCnt_tNedit.Text) > 5)
                {
                    control = this.RetryCnt_tNedit;
                    message = "5��ȉ�����͂��Ă��������B";
                }
            }

            // ���񑗐M���
            int frstSendDate = GetFrstSendDate();
            if (frstSendDate != 0)
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(frstSendDate.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    control = this.tNedit_FrstSendDateYear;
                    message = "���t����͂��Ă��������B";
                }
            }

            if (!string.IsNullOrEmpty(message))
            {
                control.Focus();
                TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message, 							// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void HourEd_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.HourEd_tNedit.Text))
            {
                try
                {
                    int hour = int.Parse(this.HourEd_tNedit.Text.Trim());
                }
                catch
                {
                    this.HourEd_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.HourEd_tNedit);
            }

        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void MinuteEd_tNedit_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MinuteEd_tNedit.Text))
            {
                try
                {
                    int minute = int.Parse(this.MinuteEd_tNedit.Text.Trim());
                }
                catch
                {
                    this.MinuteEd_tNedit.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.MinuteEd_tNedit);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_ExecInterval_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_ExecInterval.Text))
            {
                try
                {
                    int execInterval = int.Parse(this.tNedit_ExecInterval.Text.Trim());
                }
                catch
                {
                    this.tNedit_ExecInterval.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_ExecInterval);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_FrstSendDateYear_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_FrstSendDateYear.Text))
            {
                try
                {
                    int year = int.Parse(this.tNedit_FrstSendDateYear.Text.Trim());
                }
                catch
                {
                    this.tNedit_FrstSendDateYear.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_FrstSendDateYear);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_FrstSendDateMonth_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_FrstSendDateMonth.Text))
            {
                try
                {
                    int mouth = int.Parse(this.tNedit_FrstSendDateMonth.Text.Trim());
                }
                catch
                {
                    this.tNedit_FrstSendDateMonth.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_FrstSendDateMonth);
            }
        }

        /// <summary>
        /// �t�H�[�J�X��Leave���̃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		 : �R���g���[���t�H�[�J�X���ύX����ꍇ�ɔ������܂��B</br>
        /// <br>Programmer	 : �c����</br>
        /// <br>Date		 : 2019/12/03</br>
        /// </remarks>
        private void tNedit_FrstSendDateDay_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tNedit_FrstSendDateDay.Text))
            {
                try
                {
                    int day = int.Parse(this.tNedit_FrstSendDateDay.Text.Trim());
                }
                catch
                {
                    this.tNedit_FrstSendDateDay.Clear();
                    return;
                }

                ScreenSingleDataCheck(this.tNedit_FrstSendDateDay);
            }
        }

       #endregion ----- Control Events -----
        

    }
}

