//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�������D��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �L�����y�[�������D��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���F����R
// �C����    2011/09/07     �C�����e�F��Q�� #24169�@���_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC��
// ---------------------------------------------------------------------//
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
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util; // ADD 2011/09/07

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[�������D��ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �L�����y�[�������D��ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer	: ���N�n��</br>
    /// <br>Date		: 2011/04/25</br>
    /// <br>Update Note : 2011/09/07 ����R</br>
    /// <br>              ��Q�� #24169 �S�Ћ��ʂ̕ҏW�@</br>   
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09611UA : Form,IMasterMaintenanceMultiType
    {
        #region �R���X�g���N�^
        /// <summary>
        /// PMKHN09611U�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[�������D��ݒ�t�H�[���N���X�R���X�g���N�^�ł�</br>
        /// <br>Programer	: ���N�n��</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public PMKHN09611UA()
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

            // CampaignPrcPrSt�N���X
            this._campaignPrcPrSt = new CampaignPrcPrSt();
            // CampaignPrcPrStAcs�N���X�A�N�Z�X�N���X
            this._campaignPrcPrStAcs = new CampaignPrcPrStAcs();

            this._campaignPrcPrStTable = new Hashtable();
  
            this._recordClone = new CampaignPrcPrSt();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();

            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            this._campaignPrcPrStCheckClone = new CampaignPrcPrSt();
            this._campaignPrcPrStClone = new CampaignPrcPrSt();
            this._campaignPrcPrStInit = new CampaignPrcPrSt();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._checkPrcPrSt=new ArrayList();
            this._checkPrcPrStNumber = new ArrayList();

            checkPrcPrStADD();
            this._indexBuf = -2;
            ReadSecInfoSet();
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
        private SecInfoSetAcs _secInfoSetAcs;
        // ���_���A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;
        // ���_���f�B�N�V���i��
        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private CampaignPrcPrSt _campaignPrcPrSt;
        private CampaignPrcPrStAcs _campaignPrcPrStAcs;

        // ��r�pClone
        private CampaignPrcPrSt _campaignPrcPrStCheckClone;
        // �ۑ���r�pClone
        private CampaignPrcPrSt _campaignPrcPrStClone;
        // �߂��r�pClone
        private CampaignPrcPrSt _campaignPrcPrStInit;

        //HashTable
        private Hashtable _campaignPrcPrStTable;
        // �I�����̕ҏW�`�F�b�N�p
        private CampaignPrcPrSt _recordClone;

        private ArrayList _checkPrcPrSt;

        private ArrayList _checkPrcPrStNumber;
        private int _indexBuf;
        private string _enterpriseCode;

        private const string ASSEMBLY_ID = "PMKHN09611U";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_SECTIONCODE = "���_�R�[�h";
        private const string VIEW_SECTIONNAME = "���_����";
        private const string VIEW_PRIORITYSETTINGCD1 = "�D��ݒ�P";
        private const string VIEW_PRIORITYSETTINGCD2 = "�D��ݒ�Q";
        private const string VIEW_PRIORITYSETTINGCD3 = "�D��ݒ�R";
        private const string VIEW_PRIORITYSETTINGCD4 = "�D��ݒ�S";
        private const string VIEW_PRIORITYSETTINGCD5 = "�D��ݒ�T";
        private const string VIEW_PRIORITYSETTINGCD6 = "�D��ݒ�U";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private bool isError = false; // ADD 2011/09/07

        #endregion

        #region Main Entry Point
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09611UA());
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
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            CampaignPrcPrSt campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (campaignPrcPrSt.SectionCode.Trim() == "00")
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMKHN09611U",							// �A�Z���u��ID
                    "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
                return status;
            }
            // �L�����y�[�������D��ݒ�}�X�^���_���폜����
            status = this._campaignPrcPrStAcs.LogicalDelete(ref campaignPrcPrSt);

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
                            this._campaignPrcPrStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.YesNo, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // �L�����y�[�������D��ݒ�}�X�^�f�[�^�Z�b�g�W�J����
            CampaignPrcPrStToDataSet(campaignPrcPrSt.Clone(), this.DataIndex);
            return 0;
        }


        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">TATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMKHN09611U",							// �A�Z���u��ID
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
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //�폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleCenter, "", Color.Red));
            // GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //���_�R�[�h
            appearanceTable.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���_����
            appearanceTable.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�D��ݒ�R�[�h�P
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�D��ݒ�R�[�h�Q
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�D��ݒ�R�[�h�R
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�D��ݒ�R�[�h�S
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�D��ݒ�R�[�h�T
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�D��ݒ�R�[�h�U
            appearanceTable.Add(VIEW_PRIORITYSETTINGCD6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
          

            return appearanceTable;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programer	: ���N�n��</br>
        /// <br>Date		: 2011/04/25</br>
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
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
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
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
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
            ArrayList campaignPrcPrStAcsList = null;
      
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._campaignPrcPrStTable.Clear();
            // �S����
            status = this._campaignPrcPrStAcs.SearchAll(out campaignPrcPrStAcsList, this._enterpriseCode);

            totalCount = campaignPrcPrStAcsList.Count;



            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (CampaignPrcPrSt campaignPrcPrSt in campaignPrcPrStAcsList)
                        {

                            // �I�[�g�o�b�N�X�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
                            CampaignPrcPrStToDataSet(campaignPrcPrSt.Clone(), index);
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
                            "PMKHN09611UA",							// �A�Z���u��ID
                            "�I�[�g�o�b�N�X�ݒ�",              �@�@   // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._campaignPrcPrStAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="campaignPrcPrSt">�L�����y�[�������D��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^�����e�i���X�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        private void CampaignPrcPrStToDataSet(CampaignPrcPrSt campaignPrcPrSt, int index)
        {
            string sectionName;

            // index�̒l��DataSet�̊����s�������Ă��Ȃ�������
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // index�ɍs�̍ŏI�s�ԍ����Z�b�g����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            if (campaignPrcPrSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = campaignPrcPrSt.UpdateDateTimeJpInFormal;
            }

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = campaignPrcPrSt.FileHeaderGuid;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCODE] = campaignPrcPrSt.SectionCode;
            
            GetSectionName(campaignPrcPrSt.SectionCode, out sectionName);

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = sectionName;
           
            #region PrioritySettingCd
            switch (campaignPrcPrSt.PrioritySettingCd1)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "Ұ��+�i��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "Ұ��+BL����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "Ұ��+��ٰ��";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "Ұ��";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "BL����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD1] = "�̔��敪";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd2)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "Ұ��+�i��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "Ұ��+BL����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "Ұ��+��ٰ��";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "Ұ��";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "BL����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD2] = "�̔��敪";
                        break;
                    }
            }


            switch (campaignPrcPrSt.PrioritySettingCd3)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "Ұ��+�i��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "Ұ��+BL����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "Ұ��+��ٰ��";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "Ұ��";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "BL����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD3] = "�̔��敪";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd4)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "Ұ��+�i��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "Ұ��+BL����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "Ұ��+��ٰ��";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "Ұ��";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "BL����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD4] = "�̔��敪";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd5)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "Ұ��+�i��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "Ұ��+BL����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "Ұ��+��ٰ��";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "Ұ��";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "BL����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD5] = "�̔��敪";
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd6)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "Ұ��+�i��";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "Ұ��+BL����";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "Ұ��+��ٰ��";
                        break;
                    }
                case 4:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "Ұ��";
                        break;
                    }
                case 5:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "BL����";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITYSETTINGCD6] = "�̔��敪";
                        break;
                    }
            }
            #endregion
            // �C���X�^���X�e�[�u���ɂ��Z�b�g����
            if (this._campaignPrcPrStTable.ContainsKey(campaignPrcPrSt.FileHeaderGuid) == true)
            {
                this._campaignPrcPrStTable.Remove(campaignPrcPrSt.FileHeaderGuid);
            }
            this._campaignPrcPrStTable.Add(campaignPrcPrSt.FileHeaderGuid, campaignPrcPrSt);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }

        #endregion

        #region ----- Event -----
        /// <summary>
        /// UnDisplaying
        /// </summary>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion ----- Event -----

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {

            switch (setType)
            {
                // 0:�V�K
                default:
                case 0:
                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    // �p�l��
                    this.panel_Section.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING1.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING2.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING3.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING4.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING5.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING6.Enabled = true;

                    // ��ʏ�����
                    ScreenClear();

                    break;
                // 1:�X�V
                case 1:

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    // �p�l��
                    this.panel_Section.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING1.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING2.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING3.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING4.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING5.Enabled = true;
                    this.tComboEditor_PRIORITYSETTING6.Enabled = true;

                    break;
                // 2:�폜
                case 2:

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    // �p�l��
                    this.panel_Section.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING1.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING2.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING3.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING4.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING5.Enabled = false;
                    this.tComboEditor_PRIORITYSETTING6.Enabled = false;

                    break;
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programer  : ���N�n��</br>
        /// <br>Date	   : 2011/04/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable campaignPrcPrStTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            campaignPrcPrStTable.Columns.Add(DELETE_DATE, typeof(string));               //�폜��
            campaignPrcPrStTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));       //BL �R�[�h
            campaignPrcPrStTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));          //BL�@�R�[�h��
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD1, typeof(string));          //�D��ݒ�R�[�h�P
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD2, typeof(string));           //�D��ݒ�R�[�h�Q
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD3, typeof(string));           //�D��ݒ�R�[�h�R
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD4, typeof(string));     //�D��ݒ�R�[�h�S
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD5, typeof(string));     //�D��ݒ�R�[�h�T
            campaignPrcPrStTable.Columns.Add(VIEW_PRIORITYSETTINGCD6, typeof(string));     //�D��ݒ�R�[�h�U

            campaignPrcPrStTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(campaignPrcPrStTable);
        }


        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                CampaignPrcPrSt campaignPrcPrSt = new CampaignPrcPrSt();

                // �N���[���쐬
                this._campaignPrcPrStClone = campaignPrcPrSt.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToCampaignPrcPrSt(ref this._campaignPrcPrStClone);

                //�@�V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                this.tEdit_SectionCodeAllowZero2.Focus();
                ScreenClear();

            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                CampaignPrcPrSt campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];
                campaignPrcPrSt.SectionCode = campaignPrcPrSt.SectionCode.Trim();
                //��ʓW�J����
                RecordToScreen(campaignPrcPrSt);

                if (campaignPrcPrSt.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(1);

                    // �N���[���쐬
                    this._campaignPrcPrStClone = campaignPrcPrSt.Clone();

                    this.tComboEditor_PRIORITYSETTING1.Focus();


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
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {

            this.tEdit_SectionCodeAllowZero2.Clear();
            this.tEdit_SectionGuideNm.Clear();
            this.tComboEditor_PRIORITYSETTING1.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING2.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING3.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING4.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING5.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING6.SelectedIndex = 0;
            this.tComboEditor_PRIORITYSETTING1.Enabled = true;
            this.tComboEditor_PRIORITYSETTING2.Enabled = true;
            this.tComboEditor_PRIORITYSETTING3.Enabled = true;
            this.tComboEditor_PRIORITYSETTING4.Enabled = true;
            this.tComboEditor_PRIORITYSETTING5.Enabled = true;
            this.tComboEditor_PRIORITYSETTING6.Enabled = true;
            this.panel_Section.Enabled = true;

            // �{�^��
            this.Ok_Button.Visible = true;
            this.Cancel_Button.Visible = true;
            this.Revive_Button.Visible = false;
            this.Delete_Button.Visible = false;
            this.Renewal_Button.Visible = true;
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��ʓW�J����
        /// </summary>
        /// <param name="campaignPrcPrSt">�L�����y�[�������D��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void RecordToScreen(CampaignPrcPrSt campaignPrcPrSt)
        {
            if (campaignPrcPrSt.SectionCode.Trim() == "00" || campaignPrcPrSt.SectionCode.Trim() == string.Empty)
            {
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero2.Text = "00";
                // ���_��
                this.tEdit_SectionGuideNm.Text = "�S�Ћ���";
            }
            else
            {
                this.tEdit_SectionCodeAllowZero2.Text = campaignPrcPrSt.SectionCode;

                //
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, campaignPrcPrSt.SectionCode);
                if (status == 0)
                {
                    this.tEdit_SectionGuideNm.Text = secInfoSet.SectionGuideNm;
                }
            }


            #region PrioritySettingCd
            switch (campaignPrcPrSt.PrioritySettingCd1)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING1.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd2)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING2.Value = 6;
                        break;
                    }
            }


            switch (campaignPrcPrSt.PrioritySettingCd3)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING3.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd4)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING4.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd5)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING5.Value = 6;
                        break;
                    }
            }

            switch (campaignPrcPrSt.PrioritySettingCd6)
            {
                case 0:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 0;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 1;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 2;
                        break;
                    }
                case 3:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 3;
                        break;
                    }
                case 4:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 4;
                        break;
                    }
                case 5:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 5;
                        break;
                    }
                default:
                    {
                        this.tComboEditor_PRIORITYSETTING6.Value = 6;
                        break;
                    }
            }
            #endregion
        }

        /// <summary>
        /// �ۑ�����(SaveCampaignPrcPrSt())
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private bool SaveCampaignPrcPrSt()
        {
            bool result = false;

            // ----- ADD 2011/09/07 ---------->>>>>
            // ���_
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                }
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            //��ʃf�[�^���̓`�F�b�N����
            bool chkSt = CheckDisplay();
            if (!chkSt)
            {
                return chkSt;
            }

            CampaignPrcPrSt campaignPrcPrSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];
            }

            ScreenToCampaignPrcPrSt(ref campaignPrcPrSt);

            int status = this._campaignPrcPrStAcs.Write(ref campaignPrcPrSt);

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
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "PMKHN09611U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (this.tEdit_SectionCodeAllowZero2.Enabled == true)
                        {
                            this.tEdit_SectionCodeAllowZero2.Focus();
                        }
                        else
                        {
                            this.tComboEditor_PRIORITYSETTING1.Focus();
                        }
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
                            "PMKHN09611U",							// �A�Z���u��ID
                            "PrcPrSt",  �@�@                 // �v���O��������
                            "CampaignPrcPrSt",                       // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._campaignPrcPrStAcs,				    	// �G���[�����������I�u�W�F�N�g
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

            CampaignPrcPrStToDataSet(campaignPrcPrSt, this.DataIndex);

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
        /// �L�����y�[�������D��ݒ�N���X�i�[����
        /// </summary>
        /// <param name="campaignPrcPrSt">�L�����y�[�������D��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�L�����y�[�������D��ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ScreenToCampaignPrcPrSt(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            if (campaignPrcPrSt == null)
            {
                // �V�K�̏ꍇ
                campaignPrcPrSt = new CampaignPrcPrSt();
            }

            // ��ƃR�[�h
            campaignPrcPrSt.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            campaignPrcPrSt.SectionCode = this.tEdit_SectionCodeAllowZero2.Text.Trim();

            campaignPrcPrSt.PrioritySettingCd1 = this.tComboEditor_PRIORITYSETTING1.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd2 = this.tComboEditor_PRIORITYSETTING2.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd3 = this.tComboEditor_PRIORITYSETTING3.SelectedIndex;

            campaignPrcPrSt.PrioritySettingCd4 = this.tComboEditor_PRIORITYSETTING4.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd5 = this.tComboEditor_PRIORITYSETTING5.SelectedIndex;
            campaignPrcPrSt.PrioritySettingCd6 = this.tComboEditor_PRIORITYSETTING6.SelectedIndex;
        }

        /// <summary>
        /// ��ʃf�[�^���̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃf�[�^���̓`�F�b�N����</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckDisplay()
        {
            bool status = true;
            string checkMessage = "�ݒ肪�d�����Ă��܂��B";
            int zeroCount = 0;
            ArrayList notZero = new ArrayList();

            if (this.tEdit_SectionCodeAllowZero2.Text.Trim() == string.Empty)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMKHN09611U",							// �A�Z���u��ID
                    "���_����͂��ĉ������B",	            // �\�����郁�b�Z�[�W
                    0,									    // �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��

                this.tEdit_SectionCodeAllowZero2.Focus();
                return false;
            }
            // --- ADD 2011/09/07 -------------------------------->>>>>
            // ���_�R�[�h�̑��݃`�F�b�N
            bool existCheck = false;
            // �S�Ћ��ʂ͋��_�}�X�^�ɓo�^����Ă��Ȃ����߁A�`�F�b�N�̑ΏۊO
            if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText) || this.tEdit_SectionCodeAllowZero2.DataText=="0")
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                    {
                        existCheck = true;
                        break;
                    }
                }
            }
            else
            {
                existCheck = true;
            }
            if (existCheck)
            {
                status = true;
            }
            else
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMKHN09611U",							// �A�Z���u��ID
                    "�w�肵�����_�R�[�h�͑��݂��܂���B",	// �\�����郁�b�Z�[�W
                    0,									    // �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<

            try
            {
                if (this.tComboEditor_PRIORITYSETTING1.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING1.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING1.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING1.Focus();
                    }

                }
                else
                {
                    zeroCount++;
                }
           
                if ((int)this.tComboEditor_PRIORITYSETTING2.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING2.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING2.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING2.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
           
                if ((int)this.tComboEditor_PRIORITYSETTING3.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING3.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING3.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING3.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
           
                if ((int)this.tComboEditor_PRIORITYSETTING4.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING4.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING4.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING4.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
        
                if ((int)this.tComboEditor_PRIORITYSETTING5.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING5.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING5.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING5.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
         
                if ((int)this.tComboEditor_PRIORITYSETTING6.SelectedIndex != 0)
                {
                    if (!notZero.Contains(this.tComboEditor_PRIORITYSETTING6.Value))
                    {
                        notZero.Add(this.tComboEditor_PRIORITYSETTING6.Value);
                    }
                    else
                    {
                        this.tComboEditor_PRIORITYSETTING6.Focus();
                    }
                }
                else
                {
                    zeroCount++;
                }
            }
            finally
            {
                if (notZero.Count < 6 - zeroCount)
                {
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "PMKHN09611U",							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                    status = false;
                }
            }
            return status;
        }

        private void PMKHN09611UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void uButton_Section_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                string name;
                string sectionMode = "";
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    if (this.tEdit_SectionCodeAllowZero2.DataText == "00" || this.tEdit_SectionCodeAllowZero2.DataText ==string.Empty)
                    {
                        this.tEdit_SectionGuideNm.DataText = "�S�Ћ���";
                        sectionMode = "1";
                    }
                    else
                    {
                       this.tEdit_SectionGuideNm.DataText = secInfoSet.SectionGuideNm.Trim();
                    }

                    if (GetSectionName(secInfoSet.SectionCode.Trim(), out name))
                    {
                        this.tEdit_SectionGuideNm.Text = name;

                        if (this._dataIndex < 0)
                        {
                            if (!this.ModeChangeProc(sectionMode, secInfoSet.SectionCode.Trim()))
                            {
                                this.tEdit_SectionCodeAllowZero2.Focus();
                            }
                            else
                            {
                                // ���t�H�[�J�X
                                this.SelectNextControl((Control)sender, true, true, true, true);
                            }
                        }
                    }
                }
                else if (status == 1)
                {
                    if (this.tEdit_SectionGuideNm.Text.Trim() == string.Empty)
                    {
                        this.tEdit_SectionCodeAllowZero2.Clear();
                    }
                    else
                    {
                        if (this._secInfoSetDic.ContainsKey(this.tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0')))
                        {
                            SecInfoSet secInfo = this._secInfoSetDic[this.tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0')];
                            if (this.tEdit_SectionGuideNm.Text.Trim() != secInfo.SectionGuideNm)
                            {
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.tEdit_SectionGuideNm.Clear();
                            }
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero2.Clear();
                            this.tEdit_SectionGuideNm.Clear();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl.Name == "uButton_Section")
            {
                return;
            }
            # region [��ʏ���]
            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�h
                //case "tEdit_SectionCodeAllowZero": // DEL 2011/09/07
                case "tEdit_SectionCodeAllowZero2": // ADD 2011/09/07
                    {

                        // --- ADD 2011/09/07 -------------------------------->>>>>
                        isError = false;
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_Section;
                                        }
                                        break;
                                    }
                                case Keys.Right:
                                    {
                                        e.NextCtrl = this.uButton_Section;
                                        break;
                                    }
                            }
                        }
                        if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                        {
                            this.tEdit_SectionGuideNm.Clear();
                            return;
                        }
                        // --- ADD 2011/09/07 --------------------------------<<<<<
                        string sectionCode = this.tEdit_SectionCodeAllowZero2.Text.Trim();
                        string sectionMode = "";
                        // ----- UPD 2011/09/07 --------------------->>>>>
                        //if (sectionCode == string.Empty || sectionCode == "00")
                        if (sectionCode == "0" || sectionCode == "00")
                        // ----- UPD 2011/09/07 ---------------------<<<<<
                        {
                            sectionCode = "00";
                            sectionMode = "1";
                            if (e.NextCtrl == this.Cancel_Button)
                            {
                                return;
                            }
                           
                        }
                        string name;
                        // ----- ADD 2011/09/07 --------------------->>>>>
                        if (!string.IsNullOrEmpty(sectionCode))
                        {
                            this.tEdit_SectionCodeAllowZero2.Text = sectionCode.PadLeft(2, '0');
                        }
                        // ----- ADD 2011/09/07 ---------------------<<<<<
                        if (GetSectionName(sectionCode, out name))
                        {
                            if (e.NextCtrl != this.Ok_Button)
                            {
                                this.tEdit_SectionCodeAllowZero2.Text = (Convert.ToInt32(sectionCode)).ToString("00");
                                this.tEdit_SectionGuideNm.Text = name;
                            }
                            if (this._dataIndex < 0)
                            {
                                if (!this.ModeChangeProc(sectionMode, sectionCode))
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                                }
                                else
                                {
                                    this.tEdit_SectionCodeAllowZero2.Text = (Convert.ToInt32(sectionCode)).ToString("00");
                                    this.tEdit_SectionGuideNm.Text = name;
                                    if (e.NextCtrl != null && this.Mode_Label.Text == INSERT_MODE)
                                    {
                                        if (e.Key == Keys.LButton && e.NextCtrl == this.Ok_Button)
                                        {
                                            //�ۑ��������s���B
                                        }
                                        else
                                        {
                                            // --- ADD 2011/09/07 ------------------->>>>>
                                            if (e.Key == Keys.Right)
                                            {
                                                e.NextCtrl = this.uButton_Section;
                                            }
                                            else
                                            {
                                            // --- ADD 2011/09/07 -------------------<<<<<
                                                e.NextCtrl = this.tComboEditor_PRIORITYSETTING1;
                                            }// ADD 2011/09/07
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_PRIORITYSETTING1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // �G���[���b�Z�[�W
                            TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                              ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                              "���_�����݂��܂���B", 			    // �\�����郁�b�Z�[�W
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK);				// �\������{�^��

                            isError = true; // ADD 2011/09/08
                            this.tEdit_SectionCodeAllowZero2.Text = string.Empty;
                            this.tEdit_SectionGuideNm.Text = string.Empty;
                            e.NextCtrl = this.tEdit_SectionGuideNm;
                        }

                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING1":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING1.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING1.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd1;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING1.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING1.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING1.Text);
                            }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING2":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING2.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING2.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd2;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING2.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING2.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING2.Text);
                            } 
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING3":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING3.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING3.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd3;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING3.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING3.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING3.Text);
                            }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING4":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING4.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING4.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd4;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING4.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING4.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING4.Text);
                            }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING5":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING5.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING5.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd5;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING5.Text))
                            {
                                this.tComboEditor_PRIORITYSETTING5.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING5.Text);
                            }
                        } 
                        PrcPrStADDValue();
                        break;
                    }
                case "tComboEditor_PRIORITYSETTING6":
                    {
                        if (!this._checkPrcPrSt.Contains(this.tComboEditor_PRIORITYSETTING6.Text))
                        {
                            this.tComboEditor_PRIORITYSETTING6.SelectedIndex = this._campaignPrcPrStCheckClone.PrioritySettingCd6;
                        }
                        else
                        {
                            if (this._checkPrcPrStNumber.Contains(this.tComboEditor_PRIORITYSETTING6.Text))
                             {
                                  this.tComboEditor_PRIORITYSETTING6.SelectedIndex = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING6.Text);
                             }
                        }
                        PrcPrStADDValue();
                        break;
                    }
                    
            }
            # endregion

        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">sectionName</param>
        /// <returns>���_���� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool GetSectionName(string sectionCode, out string sectionName)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                sectionName = "�S�Ћ���";
                return true;
            }
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                sectionName = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
                return true;
            }
            else
            {
                sectionName = string.Empty;
                return false;
            }
        }


        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_���}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs();
            }
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// �����D��ݒ�`�F�b�N���X�g
        /// </summary>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void checkPrcPrStADD()
        {
            for (int i = 0; i <= 6; i++)
            {
                string PrcPrSt_Number = i.ToString();
                this._checkPrcPrSt.Add(PrcPrSt_Number);
                this._checkPrcPrStNumber.Add(PrcPrSt_Number);
            }
            this._checkPrcPrSt.Add("0�F�Ȃ�");
            this._checkPrcPrSt.Add("1�FҰ��+�i��");
            this._checkPrcPrSt.Add("2�FҰ��+BL����");
            this._checkPrcPrSt.Add("3�FҰ��+��ٰ��");
            this._checkPrcPrSt.Add("4�FҰ��");
            this._checkPrcPrSt.Add("5�FBL����");
            this._checkPrcPrSt.Add("6�F�̔��敪");
        }

        /// <summary>
        /// �����D��ݒ�`�F�b�N���X�g
        /// </summary>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void PrcPrStADDValue()
        {
            this._campaignPrcPrStCheckClone.PrioritySettingCd1 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING1.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd2 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING2.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd3 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING3.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd4 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING4.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd5 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING5.SelectedIndex);
            this._campaignPrcPrStCheckClone.PrioritySettingCd6 = Convert.ToInt32(this.tComboEditor_PRIORITYSETTING6.SelectedIndex);
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc(string sectionMode, string theSectionCode)
        {
            string msg = "";

            if (sectionMode == "1")
            {
                msg = "���͂��ꂽ�L�����y�[�������D��ݒ���͊��ɓo�^����Ă��܂��B\n�u���_���́F�S�Ћ��ʁv\n�ҏW���s���܂����H";
            }
            else
            {
                msg = "���͂��ꂽ�L�����y�[�������D��ݒ���͊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";
            }
        
           
            // �L�����y�[���R�[�h
            int sectionCode = Convert.ToInt32(theSectionCode.ToString());

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsSectionCode = Convert.ToInt32(this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCODE]);
                if (sectionCode == dsSectionCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�L�����y�[�������D��ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        isError = true; // ADD 2011/09/08
                        // �L�����y�[���R�[�h�̃N���A
                        tEdit_SectionCodeAllowZero2.Clear();
                        this.tEdit_SectionGuideNm.Text = string.Empty;
                        return false;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    isError = true; // ADD 2011/09/08
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
                                // �L�����y�[���R�[�h�̃N���A
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.tEdit_SectionGuideNm.Text = string.Empty;
                                this.tEdit_SectionCodeAllowZero2.Focus();
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
        ///	Form.Load �C�x���g(PMKHN09611UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09611UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.uButton_Section.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
            PrcPrStADDValue();
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMKHN09611UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09611UA_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
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

            if (!SaveCampaignPrcPrSt())
            {
                return;
            }
            else
            {
                this.tEdit_SectionCodeAllowZero2.Focus();
            }

        }

        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // �ŐV���
            ReadSecInfoSet();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }


        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
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

            CampaignPrcPrSt campaignPrcPrSt = null;
            // �����Ώۃf�[�^�擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];

            // ����
            status = this._campaignPrcPrStAcs.Revival(ref campaignPrcPrSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        CampaignPrcPrStToDataSet(campaignPrcPrSt, this._dataIndex);
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
                            "PMKHN09611U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._campaignPrcPrStAcs,				// �G���[�����������I�u�W�F�N�g
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
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                "PMKHN09611U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }


            CampaignPrcPrSt campaignPrcPrSt = null;
            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            campaignPrcPrSt = (CampaignPrcPrSt)this._campaignPrcPrStTable[guid];


            // ���_���_���폜����
            int status = this._campaignPrcPrStAcs.Delete(campaignPrcPrSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._campaignPrcPrStTable.Remove(campaignPrcPrSt.FileHeaderGuid);

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
                            "PMKHN09611U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._campaignPrcPrStAcs, 				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                CampaignPrcPrSt campaignPrcPrSt = new CampaignPrcPrSt();

                campaignPrcPrSt = this._campaignPrcPrStClone.Clone();
                ScreenToCampaignPrcPrSt(ref campaignPrcPrSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                 
                 if ( !((this._campaignPrcPrStClone.PrioritySettingCd1 == campaignPrcPrSt.PrioritySettingCd1)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd2 == campaignPrcPrSt.PrioritySettingCd2)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd3 == campaignPrcPrSt.PrioritySettingCd3)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd4 == campaignPrcPrSt.PrioritySettingCd4)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd5 == campaignPrcPrSt.PrioritySettingCd5)
                    &&(this._campaignPrcPrStClone.PrioritySettingCd6 == campaignPrcPrSt.PrioritySettingCd6)
                    && (this._campaignPrcPrStClone.SectionCode == campaignPrcPrSt.SectionCode)))
                   
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
                                if (!SaveCampaignPrcPrSt())
                                {
                                    return;
                                }
                                else
                                {
                                    this.tEdit_SectionCodeAllowZero2.Focus();
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

       #endregion ----- Control Events -----

    }
}

