//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : �����M
// �� �� ��  2012/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// <br>Programmer	: �����M</br>
    /// <br>Date		: 2012/12/15</br>
    /// <br>�Ǘ��ԍ�    : 10805731-00</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09711UA : Form,IMasterMaintenanceMultiType
    {
        #region �R���X�g���N�^
        /// <summary>
        /// PMKHN09711U�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ڑ�����ݒ�t�H�[���N���X�R���X�g���N�^�ł�</br>
        /// <br>Programer	: �����M</br>
        /// <br>Date		: 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// </remarks>
        public PMKHN09711UA()
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
            this._connectInfoWork = new ConnectInfoWork();
            this._connectInfoWorkCheckClone = new ConnectInfoWork();
            this._connectInfoWorkClone = new ConnectInfoWork();

            // connectInfoWorkAcs�N���X�A�N�Z�X�N���X
            this._connectInfoWorkAcs = new ConnectInfoWorkAcs();

            this._connectInfoWorkTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._supplierAcs = new SupplierAcs();
            this._indexBuf = -2;
            this._supplierDic = new Dictionary<int, Supplier>();
            ReadSupplierName();

            this._controlScreenSkin = new ControlScreenSkin();                                //�X�L�������[�h
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
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

        // �d����
        private SupplierAcs _supplierAcs;
        private Dictionary<int, Supplier> _supplierDic;

        private ConnectInfoWork _connectInfoWork;
        private ConnectInfoWorkAcs _connectInfoWorkAcs;

        // ��r�pClone
        private ConnectInfoWork _connectInfoWorkCheckClone;
        // �ۑ���r�pClone
        private ConnectInfoWork _connectInfoWorkClone;
        private ControlScreenSkin _controlScreenSkin;                           // �X�L���ݒ�p�N���X

        // HashTable
        private Hashtable _connectInfoWorkTable;

        private int _indexBuf;
        private string _enterpriseCode;

        private const string ASSEMBLY_ID = "PMKHN09711U";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_SUPPLIERCD = "�d����R�[�h";
        private const string VIEW_SUPPLIERSNM = "�d���旪��";
        private const string VIEW_CONNECTUSERID = "���[�U�[�R�[�h";
        private const string VIEW_CONNECTPASSWORD = "�p�X���[�h";
        private const string VIEW_DOMAIN = "�h���C��";
        private const string VIEW_DAIHATSUORDREDIV = "�����p�A�h���X";
        private const string VIEW_PROTOCOL = "�v���g�R��";
        private const string VIEW_TIMEOUT = "�^�C���A�E�g";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        #endregion

        #region Main Entry Point
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09711UA());
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
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            ConnectInfoWork connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];

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
            connectInfoWorkToDataSet(connectInfoWork, this.DataIndex);
            return 0;
        }


        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">TATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
            else
            { 
                // �Ȃ�
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // �d����R�[�h
            appearanceTable.Add(VIEW_SUPPLIERCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �d���旪��
            appearanceTable.Add(VIEW_SUPPLIERSNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�U�[�R�[�h
            appearanceTable.Add(VIEW_CONNECTUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �p�X���[�h
            appearanceTable.Add(VIEW_CONNECTPASSWORD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �h���C��
            appearanceTable.Add(VIEW_DOMAIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �v���g�R��
            appearanceTable.Add(VIEW_PROTOCOL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �����p�A�h���X
            appearanceTable.Add(VIEW_DAIHATSUORDREDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �^�C���A�E�g
            appearanceTable.Add(VIEW_TIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));          

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
        /// <br>Programer	: �����M</br>
        /// <br>Date		: 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
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
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
            else
            {
                // �Ȃ�
            }

            int status = 0;
            ArrayList connectInfoWorkAcsList = null;
      
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._connectInfoWorkTable.Clear();
            // �S����
            status = this._connectInfoWorkAcs.SearchAll(out connectInfoWorkAcsList, this._enterpriseCode);
            totalCount = connectInfoWorkAcsList.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (ConnectInfoWork connectInfoWork in connectInfoWorkAcsList)
                        {

                            // �I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
                            connectInfoWorkToDataSet(connectInfoWork, index);
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
                            "PMKHN09711UA",							// �A�Z���u��ID
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
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void connectInfoWorkToDataSet(ConnectInfoWork connectInfoWork, int index)
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
            else
            {
                // �Ȃ�
            }
            if (connectInfoWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = TDateTime.DateTimeToString("ggYY/MM/DD", connectInfoWork.UpdateDateTime);
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = connectInfoWork.FileHeaderGuid;
            string supplierCdStr = Convert.ToString(connectInfoWork.SupplierCd);
            supplierCdStr = supplierCdStr.PadLeft(6,'0');
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERCD] = supplierCdStr;
            string supplierSnm = string.Empty;
            if (ReadSupplierName(connectInfoWork.SupplierCd, out supplierSnm))
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERSNM] = supplierSnm;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SUPPLIERSNM] = string.Empty;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTUSERID] = connectInfoWork.ConnectUserId;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CONNECTPASSWORD] = connectInfoWork.ConnectPassword;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DOMAIN] = connectInfoWork.OrderUrl;
            if (connectInfoWork.DaihatsuOrdreDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PROTOCOL] = "HTTP";
            }
            else if (connectInfoWork.DaihatsuOrdreDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PROTOCOL] = "HTTPS";
            }
            else
            {
                // �Ȃ�
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DAIHATSUORDREDIV] = connectInfoWork.StockCheckUrl;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TIMEOUT] = connectInfoWork.LoginTimeoutVal;

            // �C���X�^���X�e�[�u���ɂ��Z�b�g����
            if (this._connectInfoWorkTable.ContainsKey(connectInfoWork.FileHeaderGuid) == true)
            {
                this._connectInfoWorkTable.Remove(connectInfoWork.FileHeaderGuid);
            }
            else
            {
                // �Ȃ�
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
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
                else
                {
                    // �Ȃ�
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
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
                    this.tNedit_SupplierCd.Enabled = false;

                    // �p�l��
                    this.tNedit_SupplierCd.Enabled = false;
                    this.uButton_SupplierGuide.Enabled = false;
                    this.ConnectUserId_tEdit.Enabled = true;
                    this.ConnectPassword_tEdit.Enabled = true;
                    this.Protocol_tComboEditor.Enabled = true;
                    this.TimeOut_tEdit.Enabled = true;
                    this.Domain_tEdit.Enabled = true;
                    this.OrderAddress_tEdit.Enabled = true;
                    this.tEdit_SupplierSnm.Enabled = false;
                    break;

                // 2:�폜
                case 2:

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // �p�l��
                    this.tNedit_SupplierCd.Enabled = false;
                    this.uButton_SupplierGuide.Enabled = false;
                    this.ConnectUserId_tEdit.Enabled = false;
                    this.ConnectPassword_tEdit.Enabled = false;
                    this.Protocol_tComboEditor.Enabled = false;
                    this.TimeOut_tEdit.Enabled = false;
                    this.Domain_tEdit.Enabled = false;
                    this.OrderAddress_tEdit.Enabled = false;
                    this.tEdit_SupplierSnm.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programer  : �����M</br>
        /// <br>Date	   : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable connectInfoWorkTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            connectInfoWorkTable.Columns.Add(DELETE_DATE, typeof(string));                 //�폜��
            connectInfoWorkTable.Columns.Add(VIEW_SUPPLIERCD, typeof(string));             //�d����R�[�h
            connectInfoWorkTable.Columns.Add(VIEW_SUPPLIERSNM, typeof(string));            //�d���旪��
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTPASSWORD, typeof(string));        //�p�X���[�h
            connectInfoWorkTable.Columns.Add(VIEW_CONNECTUSERID, typeof(string));        �@//���[�U�[�R�[�h
            connectInfoWorkTable.Columns.Add(VIEW_PROTOCOL, typeof(string));               //�v���g�R��
            connectInfoWorkTable.Columns.Add(VIEW_TIMEOUT, typeof(string));                //�^�C���A�E�g
            connectInfoWorkTable.Columns.Add(VIEW_DOMAIN, typeof(string));                 //�h���C��
            connectInfoWorkTable.Columns.Add(VIEW_DAIHATSUORDREDIV, typeof(string));       //�����p�A�h���X

            connectInfoWorkTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));           //GUID

            this.Bind_DataSet.Tables.Add(connectInfoWorkTable);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                ConnectInfoWork connectInfoWork = new ConnectInfoWork();
                this._connectInfoWorkClone = connectInfoWork.Clone();
                this._indexBuf = this._dataIndex;
                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToconnectInfoWork(ref this._connectInfoWorkClone);

                //�@�V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                this.tNedit_SupplierCd.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                ConnectInfoWork connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];
                //��ʓW�J����
                RecordToScreen(connectInfoWork);

                if (connectInfoWork.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(1);

                    // �N���[���쐬
                    this._connectInfoWorkClone = connectInfoWork;

                    this.ConnectPassword_tEdit.Focus();
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
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_SupplierCd.Text = "";
            this.tEdit_SupplierSnm.Text = "";
            this.ConnectUserId_tEdit.Text = "";
            this.ConnectPassword_tEdit.Text = "";
            this.Protocol_tComboEditor.SelectedIndex = 0;
            this.TimeOut_tEdit.Text = "";
            this.Domain_tEdit.Text = "";
            this.OrderAddress_tEdit.Text = "";
            this.tNedit_SupplierCd.Focus();

            // �{�^��
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;

            // �p�l��
            this.tNedit_SupplierCd.Enabled = true;
            this.uButton_SupplierGuide.Enabled = true;
            this.ConnectUserId_tEdit.Enabled = true;
            this.ConnectPassword_tEdit.Enabled = true;
            this.Protocol_tComboEditor.Enabled = true;
            this.TimeOut_tEdit.Enabled = true;
            this.Domain_tEdit.Enabled = true;
            this.OrderAddress_tEdit.Enabled = true;
            this.tEdit_SupplierSnm.Enabled = false;
        }

        /// <summary>
        /// �ڑ�����ݒ�}�X�^��ʓW�J����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void RecordToScreen(ConnectInfoWork connectInfoWork)
        {
            string supplierCd = string.Empty;
            string supplierSnm = string.Empty;
            this.tNedit_SupplierCd.Text = Convert.ToString(connectInfoWork.SupplierCd);
            supplierCd = this.tNedit_SupplierCd.Text;
            if (!string.IsNullOrEmpty(supplierCd))
            {
                // �d���於�̂��擾
                if (ReadSupplierName(connectInfoWork.SupplierCd,out supplierSnm))
                {
                    this.tEdit_SupplierSnm.Text = supplierSnm;
                    this.ConnectPassword_tEdit.Focus();
                }
                else
                {
                    this.tNedit_SupplierCd.Text = string.Empty;
                    this.tEdit_SupplierSnm.Text = supplierSnm;
                    this.tNedit_SupplierCd.Focus();
                }
            }
            else
            { 
                //�Ȃ�
            }
            this.ConnectUserId_tEdit.Text = connectInfoWork.ConnectUserId;
            this.ConnectPassword_tEdit.Value = connectInfoWork.ConnectPassword;
            this.Protocol_tComboEditor.SelectedIndex = connectInfoWork.DaihatsuOrdreDiv;
            this.TimeOut_tEdit.Value = connectInfoWork.LoginTimeoutVal;
            this.Domain_tEdit.Value = connectInfoWork.OrderUrl;
            this.OrderAddress_tEdit.Value = connectInfoWork.StockCheckUrl;
        }

        /// <summary>
        /// �ۑ�����(SaveconnectInfoWork())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : �����M</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// </remarks>
        private bool SaveconnectInfoWork()
        {
            bool result = false;

            //��ʃf�[�^���̓`�F�b�N����
            bool chkSt = ScreenDataCheck();
            if (!chkSt)
            {
                return chkSt;
            }
            else
            {
                // �Ȃ�
            }

            ConnectInfoWork connectInfoWork = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];
            }
            else
            {
                // �Ȃ�
            }

            // ��ʂɃf�[�^���擾
            ScreenToconnectInfoWork(ref connectInfoWork);
            // �ۑ�����
            int status = this._connectInfoWorkAcs.Write(ref connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,  // �G���[���x��
                            ASSEMBLY_ID,						 // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",// �\�����郁�b�Z�[�W
                            0, 									 // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				 // �\������{�^��
                        this.tNedit_SupplierCd.Focus();
                        this.tNedit_SupplierCd.Clear();
                        this.tEdit_SupplierSnm.Clear();
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
                        else
                        {
                            // �Ȃ�
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
                            "PrcPrSt",  �@�@                 // �v���O��������
                            "ConnectInfoWork",                       // ��������
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
                        else
                        {
                            // �Ȃ�
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
            connectInfoWorkToDataSet(connectInfoWork, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            else
            {
                // �Ȃ�
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
            else
            {
                // �Ȃ�
            }
            // �V�K�o�^��
            if (this.Mode_Label.Text.Equals(INSERT_MODE))
            {
                this.ScreenClear();
            }
            else
            {
                // �Ȃ�
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
        /// <br>Programmer  : �����M</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
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

                    control.Focus();
                }
                else
                { 
                    // �Ȃ�
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // �d����R�[�h
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
            {
                control = this.tNedit_SupplierCd;
                message = "�d����R�[�h����͂��Ă��������B";
                return (false);
            }
            else
            {
                int supplierCd = this.tNedit_SupplierCd.GetInt();
                string supplierSnm = string.Empty;
                if (ReadSupplierName(supplierCd, out supplierSnm))
                {
                    this.tEdit_SupplierSnm.Text = supplierSnm;
                }
                else
                {
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    this.tNedit_SupplierCd.Focus();
                    TMsgDisp.Show(
                        this, 								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�Y������d����R�[�h�����݂��܂���B", // �\�����郁�b�Z�[�W
                        0, 									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{�^��
                    return (false);
                }
            }
            // �p�X���[�h
            if (string.IsNullOrEmpty(this.ConnectPassword_tEdit.Text.Trim()))
            {
                control = this.ConnectPassword_tEdit;
                message = "�p�X���[�h����͂��Ă��������B";
                return (false);
            }
            else
            {
                // �Ȃ�
            }
            // ���[�U�[�R�[�h
            if (string.IsNullOrEmpty(this.ConnectUserId_tEdit.Text.Trim()))
            {
                control = this.ConnectUserId_tEdit;
                message = "���[�U�[�R�[�h����͂��Ă��������B";
                return (false);
            }
            else
            {
                // �Ȃ�
            }
            // �^�C���A�E�g
            if (string.IsNullOrEmpty(this.TimeOut_tEdit.Text.Trim()))
            {
                control = this.TimeOut_tEdit;
                message = "�^�C���A�E�g����͂��Ă��������B";
                return (false);
            }
            else
            {
                // �Ȃ�
            }
            // �h���C��
            if (string.IsNullOrEmpty(this.Domain_tEdit.Text.Trim()))
            {
                control = this.Domain_tEdit;
                message = "�h���C������͂��Ă��������B";
                return (false);
            }
            else
            {
                // �Ȃ�
            }
            // �����p�A�h���X
            if (string.IsNullOrEmpty(this.OrderAddress_tEdit.Text.Trim()))
            {
                control = this.OrderAddress_tEdit;
                message = "�����p�A�h���X����͂��Ă��������B";
                return (false);
            }
            else
            {
                // �Ȃ�
            }
            return true;
        }

        /// <summary>
        /// �ڑ�����ݒ�N���X�i�[����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�ڑ�����ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToconnectInfoWork(ref ConnectInfoWork connectInfoWork)
        {
            if (connectInfoWork == null)
            {
                // �V�K�̏ꍇ
                connectInfoWork = new ConnectInfoWork();
            }
            else
            {
                // �Ȃ�
            }

            // ��ƃR�[�h
            connectInfoWork.EnterpriseCode = this._enterpriseCode;

            connectInfoWork.SupplierCd = this.tNedit_SupplierCd.GetInt();
            connectInfoWork.ConnectUserId = this.ConnectUserId_tEdit.Text;
            connectInfoWork.ConnectPassword = this.ConnectPassword_tEdit.Text;
            connectInfoWork.OrderUrl = this.Domain_tEdit.Text;
            connectInfoWork.DaihatsuOrdreDiv = this.Protocol_tComboEditor.SelectedIndex;
            connectInfoWork.StockCheckUrl = this.OrderAddress_tEdit.Text;
            // �^�C���A�E�g 
            int timeOut_tEdit = 0;
            int.TryParse(this.TimeOut_tEdit.Text.Trim(), out timeOut_tEdit);
            connectInfoWork.LoginTimeoutVal = timeOut_tEdit;
        }

        /// <summary>
        /// FormClose �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : FormClose �C�x���g</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09711UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                // �Ȃ�
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ChangeFocus �C�x���g</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ��ʂ����̏ꍇ�@�d���於�̎擾���Ȃ�
            if (e.PrevCtrl == null || e.NextCtrl.Name == "Cancel_Button")
            {
                return;
            }
            else if (e.PrevCtrl.Name == "tNedit_SupplierCd")
            {
                string supplierCd = this.tNedit_SupplierCd.Text.Trim();
                if (string.IsNullOrEmpty(supplierCd))
                {
                    this.tEdit_SupplierSnm.Clear();
                }
                else
                {
                    // �V�K
                    if (this._dataIndex < 0)
                    {
                        // ���[�h�ύX�ɂ���
                        if (!this.ModeChangeProc(supplierCd))
                        {
                            this.tNedit_SupplierCd.Text = "";
                            e.NextCtrl = this.tNedit_SupplierCd;
                        }
                        else
                        {
                            int supplierCdFN = this.tNedit_SupplierCd.GetInt();
                            string supplierSnm = string.Empty;

                            // �d���於�̂��擾
                            if (ReadSupplierName(supplierCdFN, out supplierSnm))
                            {
                                this.tEdit_SupplierSnm.Text = supplierSnm;
                                e.NextCtrl = this.ConnectPassword_tEdit;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this, 								    // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                    ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�Y������d����R�[�h�����݂��܂���B", // �\�����郁�b�Z�[�W
                                    0, 									    // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				    // �\������{�^��
                                this.tNedit_SupplierCd.Text = string.Empty;
                                this.tEdit_SupplierSnm.Text = supplierSnm;
                                e.NextCtrl = this.tNedit_SupplierCd;
                            }
                        }
                    }
                    else
                    {
                        // �Ȃ�
                    }
                }
                return;
            }
            else if (e.PrevCtrl.Name == "TimeOut_tEdit")
            {
                if (!string.IsNullOrEmpty(this.TimeOut_tEdit.Text))
                {
                    int timeOutInt = Convert.ToInt32(this.TimeOut_tEdit.Text);
                    this.TimeOut_tEdit.Text = Convert.ToString(timeOutInt);
                }
                else
                { 
                    //�@�Ȃ�
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// �d���於�̃f�B�N�V���i���擾
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d���於�̃f�B�N�V���i���擾</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void ReadSupplierName()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            ArrayList supplierLt = null;
            status = this._supplierAcs.SearchAll(out supplierLt, this._enterpriseCode);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Supplier supplierInfo in supplierLt)
                {
                    if (supplierInfo.LogicalDeleteCode == 0)
                    {
                        this._supplierDic.Add(supplierInfo.SupplierCd, supplierInfo);
                    }
                }
            }
            else
            {
                // �Ȃ�
            }
        }

        /// <summary>
        /// �d���於�̎擾
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���於��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d���於�̎擾</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSupplierName(int supplierCd, out string supplierSnm)
        {
            if (_supplierDic.ContainsKey(supplierCd))
            {
                supplierSnm = _supplierDic[supplierCd].SupplierSnm.Trim();
                return true;
            }
            else
            {
                supplierSnm = string.Empty;
                return false;
            }
        }
       
        /// <summary>
        /// �����D��ݒ�`�F�b�N���X�g
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����D��ݒ�`�F�b�N���X�g</br>
        /// <br>Programmer  : �����M</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// </remarks>
        private void PrcPrStADDValue()
        {
            this._connectInfoWorkCheckClone.SupplierCd = this.tNedit_SupplierCd.GetInt();
            this._connectInfoWorkCheckClone.ConnectPassword = this.ConnectPassword_tEdit.Text;
            this._connectInfoWorkCheckClone.ConnectUserId = this.ConnectUserId_tEdit.Text;
            this._connectInfoWorkCheckClone.OrderUrl = this.Domain_tEdit.Text;
            this._connectInfoWorkCheckClone.DaihatsuOrdreDiv = this.Protocol_tComboEditor.SelectedIndex;
            this._connectInfoWorkCheckClone.StockCheckUrl = this.OrderAddress_tEdit.Text;
            // �^�C���A�E�g 
            int timeOut_tEdit = 0;
            int.TryParse(this.TimeOut_tEdit.Text.Trim(), out timeOut_tEdit);
            this._connectInfoWorkCheckClone.LoginTimeoutVal = timeOut_tEdit;
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <param name="theSupplierCd">�d����R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���[�h�ύX����</br>
        /// <br>Programmer  : �����M</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// </remarks>
        private bool ModeChangeProc(string theSupplierCd)
        {
            string msg = "���͂��ꂽ�ڑ�����͊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";        
           
            // �d����R�[�h
            int supplierCd = Convert.ToInt32(theSupplierCd.ToString());

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsSupplierCd = Convert.ToInt32(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SUPPLIERCD]);
                if (supplierCd == dsSupplierCd)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if (!string.IsNullOrEmpty((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]))
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					    // �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                              ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                              "���͂��ꂽ�R�[�h�̐ڑ���ݒ���͊��ɍ폜����Ă��܂��B",// �\�����郁�b�Z�[�W
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK);				// �\������{�^��
                        this.tEdit_SupplierSnm.Text = string.Empty;
                        return false;
                    }
                    else
                    {
                        // �Ȃ�
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �L�����y�[���R�[�h�̃N���A
                                this.tNedit_SupplierCd.Clear();
                                this.tEdit_SupplierSnm.Text = string.Empty;
                                this.tNedit_SupplierCd.Focus();
                                return false;
                            }
                    }
                    return true;
                }
            }
            return true;
        }
        #endregion ----- Private Method -----

        #region ----- Control Events -----
        /// <summary>
        ///	Form.Load �C�x���g(PMKHN09711UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : �����M</br>
        /// <br>Date        : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�    : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09711UA_Load(object sender, EventArgs e)
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

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.uButton_SupplierGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
            PrcPrStADDValue();
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMKHN09711UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09711UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }
            else
            {
                // �Ȃ�
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }
            else
            {
                // �Ȃ�
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
            else
            {
                // �Ȃ�
            }

            if (!SaveconnectInfoWork())
            {
                return;
            }
            else
            {
                this.tNedit_SupplierCd.Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
            else
            {
                // �Ȃ�
            }

            int status = 0;

            ConnectInfoWork connectInfoWork = null;
            // �����Ώۃf�[�^�擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];

            // ����
            status = this._connectInfoWorkAcs.Revival(ref connectInfoWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        connectInfoWorkToDataSet(connectInfoWork, this._dataIndex);
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
            else
            {
                // �Ȃ�
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
            else
            {
                // �Ȃ�
            }


            ConnectInfoWork connectInfoWork = null;
            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            connectInfoWork = (ConnectInfoWork)this._connectInfoWorkTable[guid];


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
            else
            {
                // �Ȃ�
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                ConnectInfoWork connectInfoWork = new ConnectInfoWork();

                ScreenToconnectInfoWork(ref connectInfoWork);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if (!((this._connectInfoWorkClone.ConnectPassword == connectInfoWork.ConnectPassword)
                   && (this._connectInfoWorkClone.ConnectUserId == connectInfoWork.ConnectUserId)
                   && (this._connectInfoWorkClone.OrderUrl == connectInfoWork.OrderUrl)
                   && (this._connectInfoWorkClone.DaihatsuOrdreDiv == connectInfoWork.DaihatsuOrdreDiv)
                   && (this._connectInfoWorkClone.StockCheckUrl == connectInfoWork.StockCheckUrl)
                   && (this._connectInfoWorkClone.LoginTimeoutVal == connectInfoWork.LoginTimeoutVal)
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
                                if (!SaveconnectInfoWork())
                                {
                                    return;
                                }
                                else
                                {
                                    this.tNedit_SupplierCd.Focus();
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
        /// GuideClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : GuideClick �C�x���g</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // �d����K�C�h�\��
            int status = 0;
            Supplier supplierInfo;
            string sectionCd = string.Empty;
            string supplierCdBak = this.tNedit_SupplierCd.Text;
            string supplierNmBak = this.tEdit_SupplierSnm.Text;

            // �K�C�h�\��
            status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, sectionCd);
            if (status == 0)
            {
                string supplierCdStr = string.Empty;
                supplierCdStr = Convert.ToString(supplierInfo.SupplierCd);
                // ���[�h�ύX�ɂ���
                if (!this.ModeChangeProc(supplierCdStr))
                {
                    this.tNedit_SupplierCd.Text = "";
                    this.tNedit_SupplierCd.Focus();
                }
                else
                {
                    this.tEdit_SupplierSnm.Text = supplierInfo.SupplierSnm;
                    this.tNedit_SupplierCd.Text = Convert.ToString(supplierInfo.SupplierCd);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(supplierCdBak))
                {
                    this.tNedit_SupplierCd.Text = supplierCdBak;
                    this.tEdit_SupplierSnm.Text = supplierNmBak;
                }
                else
                {
                    this.tNedit_SupplierCd.Text = "";
                    this.tEdit_SupplierSnm.Text = "";
                }
                return;
            }
        }
       #endregion ----- Control Events -----
    }
}

