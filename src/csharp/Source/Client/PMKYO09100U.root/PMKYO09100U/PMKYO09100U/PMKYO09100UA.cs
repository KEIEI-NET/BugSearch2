//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/23  �C�����e : Redmine #23764 ���_�Ǘ��ݒ� �C���˗��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011/09/15  �C�����e : Redmine #25098 �u�������M�敪�v���\���ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �C �� ��  2011/10/08  �C�����e : Redmine #25777 �u�������M�敪�v�𕜊��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �C �� ��  2011/10/08  �C�����e : Redmine #25776  ���M�拒�_���͂Ɏ����_�R�[�h���w��\�ɕύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �C �� ��  2011/10/08  �C�����e : Redmine#25781 ���_�Ǘ��ݒ�}�X�^�̕��������̃X�e�[�^�X�`�F�b�N�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : xupz
// �C �� ��  2011/11/10  �C�����e : Redmine #26228 �u���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//--------------------------------------------------------------------------
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���_�Ǘ��ݒ�}�X�^�����e�i���X�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�����e�i���X���s���܂��B</br>
    /// <br>             IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer : �����</br> 
    /// <br>Date       : 2009.03.25</br>
    /// <br></br>
    /// <br>Update Note: 2009/05/20 �����</br>
    /// <br>             PVCS#99�ɂ��āA�������̊m�F���b�Z�[�W���C�����܂��B</br>
    /// <br>Update Note: 2009/05/21 �����</br>
    /// <br>             PVCS#89�ɂ��āA����M�Ώۋ��_���͎��_�Ń`�F�b�N���s���l�ɕύX���܂��B</br>
    /// <br>Update Note: 2009/05/21 �����</br>
    /// <br>             PVCS#100�ɂ��āA���M�E��M�����݃`�F�b�N��ǉ����܂��B</br>
	/// <br>Update Note: 2011/07/21 ����</br>
	/// <br>             SCM�Ή��]���_�Ǘ��i10704767-00�j</br>
    /// <br>Update Note: 2011/10/08 yangmj</br>
    /// <br>             redmine#25776 ���M�拒�_���͂Ɏ����_�R�[�h���w��\�ɕύX�̑Ή�</br>
    /// <br>Update Note: 2011/10/08 tianjw</br>
    /// <br>             Redmine#25781 ���_�Ǘ��ݒ�}�X�^�̕��������̃X�e�[�^�X�`�F�b�N�̑Ή�</br>
    /// </remarks>
    public partial class PMKYO09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region -- Constructor --
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���_�Ǘ��ݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2009.03.25</br>
        /// </remarks>
        public PMKYO09100UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._secMngSetAcs = new SecMngSetAcs();
            this._secMngSetTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            this._preSectionCode = string.Empty;
			this._preSendSecCd = string.Empty;// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j
        }
        # endregion

        # region -- Private Members --
        private SecMngSetAcs _secMngSetAcs;
        private string _enterpriseCode;
        private Hashtable _secMngSetTable;

        // �ۑ���r�pClone
        private SecMngSet _secMngSetClone;

        private string _preSectionCode;
		private string _preSendSecCd;// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

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

        private const string ASSEMBLY_ID = "PMKYO09100U";

        private const string DELETE_DATE = "�폜��";
        private const string VIEW_KIND_TITLE = "���";
		private const string VIEW_RECEIVE_CONDITION_TITLE = "����M�敪";
		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		//private const string VIEW_SECTION_NAME_TITLE = "����M�Ώۋ��_";
		//private const string VIEW_SYNCEXEC_DATE_TITLE = "����M���s��";
		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		private const string VIEW_SECTION_NAME_TITLE = "���o�Ώۋ��_";
		private const string VIEW_SENDSEC_NAME_TITLE = "���M�拒�_";
		private const string VIEW_SYNCEXEC_DATE_TITLE = "���M���s��";
		private const string VIEW_AUTOSEND_DIV_TITLE = "�������M";
		private const string VIEW_SNDFINDATA_DIV_TITLE = "���M�σf�[�^�C���敪";
		private const string VIEW_SENDSEC_CODE_TITLE = "SendSecCode";
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";
        private const string VIEW_GUID_KEY_TITLE = "Guid";
        private const string VIEW_SECTION_CODE_TITLE = "SectionCode";
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private const string ALL_SECTIONCODE = "00";

        private const string KIND_TCOMEDITOR_VALUE0 = "�f�[�^";
        private const string KIND_TCOMEDITOR_VALUE1 = "�}�X�^";
        private const string RECEIVECONDITION_TCOMEDITOR_VALUE0 = "���M";
        private const string RECEIVECONDITION_TCOMEDITOR_VALUE1 = "��M";
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		private const string AUTOSENDDIV_TCOMEDITOR_VALUE0 = "����";
		private const string AUTOSENDDIV_TCOMEDITOR_VALUE1 = "���Ȃ�";
		private const string SNDFINDATADIV_TCOMEDITOR_VALUE0 = "�C����";
        //private const string SNDFINDATADIV_TCOMEDITOR_VALUE1 = "�C���s��"; //DEL 2011/11/10 xupz
        // ----- ADD 2011/11/10 xupz---------->>>>>
        private const string SNDFINDATADIV_TCOMEDITOR_VALUE1 = "�C���s�i���M���s���ȑO�j";
        private const string SNDFINDATADIV_TCOMEDITOR_VALUE2 = "�C���s�i�`�[���t�ȑO�j";
        // ----- ADD 2011/11/10 xupz----------<<<<<
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        # endregion

        # region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region -- Properties --
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
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
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

            ArrayList secMngSetList = new ArrayList();

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._secMngSetTable.Clear();

            status = this._secMngSetAcs.SearchAll(out secMngSetList, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SecMngSet secMngSet in secMngSetList)
                        {
                            // DataSet�W�J����
                            SecMngSetToDataSet(secMngSet, index);
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
                            this._secMngSetAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	    : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B(������)</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public int Delete()
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʍ폜�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SecMngSet secMngSet = (SecMngSet)this._secMngSetTable[guid];

			//if (secMngSet.SectionCode.Trim() == ALL_SECTIONCODE)
			//{
			//    TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
			//            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
			//            ASSEMBLY_ID,							// �A�Z���u��ID
			//            "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
			//            0,									    // �X�e�[�^�X�l
			//            MessageBoxButtons.OK);					// �\������{�^��
			//    return (0);
			//}

            int status = 0;

            // �S�̏����\���ݒ���_���폜����
            status = this._secMngSetAcs.LogicalDelete(ref secMngSet);

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
                            this._secMngSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // �S�̏����\���ݒ���N���X�f�[�^�Z�b�g�W�J����
            SecMngSetToDataSet(secMngSet.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���
            appearanceTable.Add(VIEW_KIND_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ����M�敪
			// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//appearanceTable.Add(VIEW_RECEIVE_CONDITION_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_RECEIVE_CONDITION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
			
			// ����M�ΏۃR�[�h
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			// ���M�拒�_
			appearanceTable.Add(VIEW_SENDSEC_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SENDSEC_CODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

			// ����M���s��
            appearanceTable.Add(VIEW_SYNCEXEC_DATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//appearanceTable.Add(VIEW_AUTOSEND_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));//DEL 2011/09/15 fengwx #25098
            //appearanceTable.Add(VIEW_AUTOSEND_DIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));//ADD 2011/09/15 fengwx #25098 //  DEL 2011/10/08  dingjx  #25777
            appearanceTable.Add(VIEW_AUTOSEND_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));   //  ADD 2011/10/08  dingjx  #25777
			appearanceTable.Add(VIEW_SNDFINDATA_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        # region -- Private Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date	   : 2009.03.27</br>
        /// </remarks>
        private void SecMngSetToDataSet(SecMngSet secMngSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (secMngSet.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = secMngSet.UpdateDateTimeJpInFormal;
            }

            // ���
            switch (secMngSet.Kind)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_KIND_TITLE] = KIND_TCOMEDITOR_VALUE0;
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_KIND_TITLE] = KIND_TCOMEDITOR_VALUE1;
                    break;
            }

            // ����M�敪
            switch (secMngSet.ReceiveCondition)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVE_CONDITION_TITLE] = RECEIVECONDITION_TCOMEDITOR_VALUE0;
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVE_CONDITION_TITLE] = RECEIVECONDITION_TCOMEDITOR_VALUE1;
                    break;
            }

            // ���_����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = secMngSet.SectionCode.Trim().PadLeft(2, '0');
            // UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = GetSectionName(secMngSet.SectionCode);
			if (secMngSet.Kind == 1)
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = string.Empty;
			}
			else
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = GetSectionName(secMngSet.SectionCode);
			}
			// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
			//// ����M���s��
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SYNCEXEC_DATE_TITLE] = secMngSet.SyncExecDate.ToString("yyyy�NM��d��H��m��s�b");

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			// ���M�拒�_
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDSEC_CODE_TITLE] = secMngSet.SendDestSecCode.Trim().PadLeft(2, '0');
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDSEC_NAME_TITLE] = GetSectionName(secMngSet.SendDestSecCode);

			// ����M���s��
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SYNCEXEC_DATE_TITLE] = secMngSet.SyncExecDate.ToString("yyyy�NM��d��H��m��s�b");

			// �������M
			switch (secMngSet.AutoSendDiv)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSEND_DIV_TITLE] = AUTOSENDDIV_TCOMEDITOR_VALUE0;
					break;
				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTOSEND_DIV_TITLE] = AUTOSENDDIV_TCOMEDITOR_VALUE1;
					break;
			}
			// ���M�ς݃f�[�^�C���敪
			if (secMngSet.Kind == 1)
			{
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = string.Empty;
			}
			else
			{
				switch (secMngSet.SndFinDataEdDiv)
				{
					case 0:
						this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = SNDFINDATADIV_TCOMEDITOR_VALUE0;
						break;
					case 1:
						this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = SNDFINDATADIV_TCOMEDITOR_VALUE1;
						break;
                    // ----- ADD 2011/11/10 xupz---------->>>>>
                    case 2:
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SNDFINDATA_DIV_TITLE] = SNDFINDATADIV_TCOMEDITOR_VALUE2;
                        break;
                    // ----- ADD 2011/11/10 xupz----------<<<<<
				}
			}
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = secMngSet.FileHeaderGuid;

            if (this._secMngSetTable.ContainsKey(secMngSet.FileHeaderGuid) == true)
            {
                this._secMngSetTable.Remove(secMngSet.FileHeaderGuid);
            }
            this._secMngSetTable.Add(secMngSet.FileHeaderGuid, secMngSet);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable secMngSetTable = new DataTable(VIEW_TABLE);

            // �폜��
            secMngSetTable.Columns.Add(DELETE_DATE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_KIND_TITLE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_RECEIVE_CONDITION_TITLE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));
            secMngSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
			//secMngSetTable.Columns.Add(VIEW_SYNCEXEC_DATE_TITLE, typeof(string));

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			// ���M�拒�_
			secMngSetTable.Columns.Add(VIEW_SENDSEC_CODE_TITLE, typeof(string));
			secMngSetTable.Columns.Add(VIEW_SENDSEC_NAME_TITLE, typeof(string));
			secMngSetTable.Columns.Add(VIEW_SYNCEXEC_DATE_TITLE, typeof(string));
			// �������M
			secMngSetTable.Columns.Add(VIEW_AUTOSEND_DIV_TITLE, typeof(string));
			// ���M�ς݃f�[�^�C���敪
			secMngSetTable.Columns.Add(VIEW_SNDFINDATA_DIV_TITLE, typeof(string));
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            secMngSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(secMngSetTable);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ���
            Kind_tComEditor.Items.Clear();
            Kind_tComEditor.Items.Add(0, KIND_TCOMEDITOR_VALUE0);
            Kind_tComEditor.Items.Add(1, KIND_TCOMEDITOR_VALUE1);
            Kind_tComEditor.MaxDropDownItems = Kind_tComEditor.Items.Count;

            // ����M�敪
            ReceiveCondition_tComEditor.Items.Clear();
            ReceiveCondition_tComEditor.Items.Add(0, RECEIVECONDITION_TCOMEDITOR_VALUE0);
            ReceiveCondition_tComEditor.Items.Add(1, RECEIVECONDITION_TCOMEDITOR_VALUE1);
            ReceiveCondition_tComEditor.MaxDropDownItems = ReceiveCondition_tComEditor.Items.Count;

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			// �������M
			auto_tComboEditor.Items.Clear();
			auto_tComboEditor.Items.Add(0, AUTOSENDDIV_TCOMEDITOR_VALUE0);
			auto_tComboEditor.Items.Add(1, AUTOSENDDIV_TCOMEDITOR_VALUE1);
			auto_tComboEditor.MaxDropDownItems = auto_tComboEditor.Items.Count;
			// ���M�ς݃f�[�^�C���敪
			sndFin_tComboEditor.Items.Clear();
			sndFin_tComboEditor.Items.Add(0, SNDFINDATADIV_TCOMEDITOR_VALUE0);
			sndFin_tComboEditor.Items.Add(1, SNDFINDATADIV_TCOMEDITOR_VALUE1);
            // ----- ADD 2011/11/10 xupz---------->>>>>
            sndFin_tComboEditor.Items.Add(2, SNDFINDATADIV_TCOMEDITOR_VALUE2);
            // ----- ADD 2011/11/10 xupz----------<<<<<
			sndFin_tComboEditor.MaxDropDownItems = sndFin_tComboEditor.Items.Count;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/26</br>
		/// <br>Update Note: 2011/07/21 ����</br>
		/// <br>             SCM�Ή��]���_�Ǘ��i10704767-00�j</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionName.Text = string.Empty;
			this.tEdit_SectionCode.Text = string.Empty;
            this._preSectionCode = string.Empty;
            this.Kind_tComEditor.SelectedIndex = 0;
            this.ReceiveCondition_tComEditor.SelectedIndex = 0;
            this.tNedit_SyncExecDateYear.Text = string.Empty;
            this.tNedit_SyncExecDateMonth.Text = string.Empty;
            this.tNedit_SyncExecDateDay.Text = string.Empty;
            this.tNedit_SyncExecDateHour.Text = string.Empty;
            this.tNedit_SyncExecDateMinute.Text = string.Empty;
            this.tNedit_SyncExecDateSecond.Text = string.Empty;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			this.tEdit_SendSecCd.Text = string.Empty;
			this.tEdit_SendSecName.Text = string.Empty;
			this.auto_tComboEditor.SelectedIndex = 0;
			this.sndFin_tComboEditor.SelectedIndex = 0;
			this._preSendSecCd = string.Empty;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/27</br>
        /// </remarks>
        private void SecMngSetToScreen(SecMngSet secMngSet)
        {
            // ���
            this.Kind_tComEditor.SelectedIndex = secMngSet.Kind;
            // ����M�敪
            this.ReceiveCondition_tComEditor.SelectedIndex = secMngSet.ReceiveCondition;
            // ���_�R�[�h
			this.tEdit_SectionCode.Text = secMngSet.SectionCode.Trim().PadLeft(2, '0');
            // ���_��
            this.tEdit_SectionName.Text = this.GetSectionName(secMngSet.SectionCode);
            // ����M���s��
            List<string> dateList = this.GetSyncExecDateList(secMngSet.SyncExecDate);

            this.tNedit_SyncExecDateYear.Text = dateList[0];
            this.tNedit_SyncExecDateMonth.Text = dateList[1];
            this.tNedit_SyncExecDateDay.Text = dateList[2];
            this.tNedit_SyncExecDateHour.Text = dateList[3];
            this.tNedit_SyncExecDateMinute.Text = dateList[4];
            this.tNedit_SyncExecDateSecond.Text = dateList[5];

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			this.tEdit_SendSecCd.Text = secMngSet.SendDestSecCode.Trim().PadLeft(2, '0');
			this.tEdit_SendSecName.Text = this.GetSectionName(secMngSet.SendDestSecCode);
			this.auto_tComboEditor.SelectedIndex = secMngSet.AutoSendDiv;
			this.sndFin_tComboEditor.SelectedIndex = secMngSet.SndFinDataEdDiv;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ�񋒓_�Ǘ��ݒ�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂狒�_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenToSecMngSet(ref SecMngSet secMngSet)
        {
            if (secMngSet == null)
            {
                // �V�K�̏ꍇ
                secMngSet = new SecMngSet();
            }
            //��ƃR�[�h
            secMngSet.EnterpriseCode = this._enterpriseCode;

            // ���
            secMngSet.Kind = (int)this.Kind_tComEditor.Value;
            // ��M��
			// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//secMngSet.ReceiveCondition = (int)this.ReceiveCondition_tComEditor.Value;
			secMngSet.ReceiveCondition = 0;
			// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
            // ���_�R�[�h
			secMngSet.SectionCode = this.tEdit_SectionCode.DataText.PadLeft(2, '0');
            // �V���N���s���t
            secMngSet.SyncExecDate = this.GetSyncExecDate();

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			// ���M�拒�_
			secMngSet.SendDestSecCode = this.tEdit_SendSecCd.DataText.Trim().PadLeft(2,'0');
			// �������M
			secMngSet.AutoSendDiv = (int)this.auto_tComboEditor.Value;
			// ���M�σf�[�^�C���敪
			secMngSet.SndFinDataEdDiv = (int)this.sndFin_tComboEditor.Value;
			// ��ʂ́u�}�X�^�v�̏ꍇ
			if ((int)this.Kind_tComEditor.Value == 1)
			{
				secMngSet.SectionCode = ALL_SECTIONCODE;
				secMngSet.SndFinDataEdDiv = 0;
			}

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SecMngSet secMngSet = new SecMngSet();
                //�N���[���쐬
                this._secMngSetClone = secMngSet.Clone();
                this._indexBuf = this._dataIndex;

                //// ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSecMngSet(ref this._secMngSetClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                //// �t�H�[�J�X�ݒ�
                this.Kind_tComEditor.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SecMngSet secMngSet = (SecMngSet)this._secMngSetTable[guid];

                // �S�̏����\�����N���X��ʓW�J����
                SecMngSetToScreen(secMngSet);

                if (secMngSet.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
					// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					//this.Kind_tComEditor.Focus();
					this.tNedit_SyncExecDateYear.Focus();
					// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                    // �N���[���쐬
                    this._secMngSetClone = secMngSet.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSecMngSet(ref this._secMngSetClone);
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // �{�^��
                    this.Save_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // ���͍���
                    this.Kind_tComEditor.Enabled = true;
                    this.ReceiveCondition_tComEditor.Enabled = true;
					this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.tNedit_SyncExecDateYear.Enabled = true;
                    this.tNedit_SyncExecDateMonth.Enabled = true;
                    this.tNedit_SyncExecDateDay.Enabled = true;
                    this.tNedit_SyncExecDateHour.Enabled = true;
                    this.tNedit_SyncExecDateMinute.Enabled = true;
                    this.tNedit_SyncExecDateSecond.Enabled = true;

					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					this.uLabel_ReceiveCondition.Visible = false;
					this.ReceiveCondition_tComEditor.Visible = false;
					this.tEdit_SendSecCd.Enabled = true;
					this.SendSecGuide_Button.Enabled = true;
					this.auto_tComboEditor.Enabled = true;
					this.sndFin_tComboEditor.Enabled = true;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                    break;
                case UPDATE_MODE:
                    // �{�^��
                    this.Save_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // ���͍���
                    this.Kind_tComEditor.Enabled = false;
                    this.ReceiveCondition_tComEditor.Enabled = false;
					this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_SyncExecDateYear.Enabled = true;
                    this.tNedit_SyncExecDateMonth.Enabled = true;
                    this.tNedit_SyncExecDateDay.Enabled = true;
                    this.tNedit_SyncExecDateHour.Enabled = true;
                    this.tNedit_SyncExecDateMinute.Enabled = true;
                    this.tNedit_SyncExecDateSecond.Enabled = true;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					this.uLabel_ReceiveCondition.Visible = false;
					this.ReceiveCondition_tComEditor.Visible = false;
					this.tEdit_SendSecCd.Enabled = false;
					this.SendSecGuide_Button.Enabled = false;
					this.auto_tComboEditor.Enabled = true;
					this.sndFin_tComboEditor.Enabled = true;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                    break;
                case DELETE_MODE:
                    // �{�^��
                    this.Save_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ���͍���
                    this.Kind_tComEditor.Enabled = false;
                    this.ReceiveCondition_tComEditor.Enabled = false;
					this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.tNedit_SyncExecDateYear.Enabled = false;
                    this.tNedit_SyncExecDateMonth.Enabled = false;
                    this.tNedit_SyncExecDateDay.Enabled = false;
                    this.tNedit_SyncExecDateHour.Enabled = false;
                    this.tNedit_SyncExecDateMinute.Enabled = false;
                    this.tNedit_SyncExecDateSecond.Enabled = false;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					this.uLabel_ReceiveCondition.Visible = false;
					this.ReceiveCondition_tComEditor.Visible = false;
					this.tEdit_SendSecCd.Enabled = false;
					this.SendSecGuide_Button.Enabled = false;
					this.auto_tComboEditor.Enabled = false;
					this.sndFin_tComboEditor.Enabled = false;
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/27</br>
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
        ///	���_�Ǘ��ݒ�}�X�^�����e�i���X��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note	    : ���_�Ǘ��ݒ�}�X�^�����e�i���X��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
				// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				//// ����M�Ώۋ��_�R�[�h�̕K�{���̓`�F�b�N
				//if (this.tEdit_SecCd.DataText.Trim() == string.Empty)
				//{
				//    checkMessage = "����M�Ώۋ��_���ݒ肳��Ă��܂���B";
				//    returnStatus = 10;
				//    return returnStatus;
				//}
				// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				if(this.Kind_tComEditor.SelectedIndex == 0)
				{
					// ���M�Ώۋ��_�R�[�h�̕K�{���̓`�F�b�N
					if (this.tEdit_SectionCode.DataText.Trim() == string.Empty)
					{
						//checkMessage = "����M�Ώۋ��_���ݒ肳��Ă��܂���B";
						checkMessage = "���o�Ώۋ��_�R�[�h���ݒ肳��Ă��܂���B";
						returnStatus = 10;
						return returnStatus;
					}
				}

				// ���M�拒�_�R�[�h�̕K�{���̓`�F�b�N
				if (this.tEdit_SendSecCd.DataText.Trim() == string.Empty)
				{
					checkMessage = "���M�拒�_���ݒ肳��Ă��܂���B";
					//returnStatus = 10;// DEL 2011.08.23
					returnStatus = 50;// ADD 2011.08.23
					return returnStatus;
				}
                // DEL 2011/10/08--------->>>>>>
                //// ADD 2011.08.23--------->>>>>>
                //// �����_�`�F�b�N
                //string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                //if (this.tEdit_SendSecCd.DataText.Trim().Equals(loginSectionCode.Trim()))
                //{
                //    checkMessage = "���M��Ɏ����_���o�^�ł��܂���B";
                //    returnStatus = 50;
                //    return returnStatus;
                //}
                //// ADD 2011.08.23---------<<<<<<
                // DEL 2011/10/08---------<<<<<<

				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                // ����M���s���̕K�{���̓`�F�b�N
                if (this.tNedit_SyncExecDateYear.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateMonth.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateDay.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateHour.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateMinute.DataText.Trim() == string.Empty
                    || this.tNedit_SyncExecDateSecond.DataText.Trim() == string.Empty)
                {
					//checkMessage = "����M���s�����ݒ肳��Ă��܂���B";
					checkMessage = "���M���s�����ݒ肳��Ă��܂���B";
                    returnStatus = 20;
                    return returnStatus;
                }

                if (GetSyncExecDate() == DateTime.MinValue)
                {
					//checkMessage = "����M���s�����s���ȓ����ł��B";
					checkMessage = "���M���s�����s���ȓ����ł��B";
                    returnStatus = 20;
                    return returnStatus;
                }

                returnStatus = this.CheckScreenCondtion(ref checkMessage);
                if (returnStatus != 0)
                {
                    if (returnStatus == 2)
                    {
                        // �V�K�o�^��
                        if (this.Mode_Label.Text.Equals(INSERT_MODE))
                        {
                            returnStatus = 20;
                            return returnStatus;
                        }
                        // �C����
                        else if (this.Mode_Label.Text.Equals(UPDATE_MODE))
                        {
                            DialogResult result = TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                checkMessage,
                                0, 									// �X�e�[�^�X�l
                                MessageBoxButtons.OKCancel,
                                MessageBoxDefaultButton.Button2);	// �\������{�^��

                            if (result == DialogResult.OK)
                            {
                                returnStatus = 0;
                                return returnStatus;
                            }
                            else
                            {
                                returnStatus = 40;
                                return returnStatus;
                            }
                        }
                        else
                        {
                            // �Ȃ�
                        }
                    }
					// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					//else if (returnStatus == 3 || returnStatus == 4)
					//{
					//    // �V�K�ꍇ
					//    if (this.Mode_Label.Text.Equals(INSERT_MODE))
					//    {
					//        returnStatus = 30;
					//        return returnStatus;
					//    }
					//    // ���̑��ꍇ
					//    else
					//    {
					//        returnStatus = 0;
					//        return returnStatus;
					//    }
					//}
					// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                }
            }
            finally
            {
                if (returnStatus == 10
                    || returnStatus == 20
                    || returnStatus == 30
					|| returnStatus == 50)// ADD 2011.08.23
                {
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ASSEMBLY_ID,							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                }

                //�G���[�X�e�[�^�X�ɍ��킹�ăt�H�[�J�X�Z�b�g
                switch (returnStatus)
                {
                    case 10:
                        {
							this.tEdit_SectionCode.Focus();
                            break;
                        }
                    case 20:
                    case 40:
                        {
                            this.tNedit_SyncExecDateYear.Focus();
                            break;
                        }
                    case 30:
                        {
                            this.Kind_tComEditor.Focus();
                            break;
                        }
					// ADD 2011.08.23------->>>>>
					case 50:
						{
							this.tEdit_SendSecCd.Focus();
							break;
						}
					// ADD 2011.08.23-------<<<<<
                }
            }

            return returnStatus;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	���̓`�F�b�N����(��ʂƑ���M�敪�`�F�b�N)
        /// </summary>
        /// <remarks>
        /// <br>Note	    : ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private int CheckScreenCondtion(ref string message)
        {
            int status = 0;

            // --- ADD 2009/05/21 ------------------------------->>>>>
            SecMngSet secMngSet = new SecMngSet();
            ScreenToSecMngSet(ref secMngSet);

            status = this._secMngSetAcs.CheckScreenData(ref secMngSet);

            switch (status)
            {
                // ����M���s���`�F�b�N
                case 2:
                    if (this.Mode_Label.Text.Equals(UPDATE_MODE))
                    {
                        message = "�O�񌎎��X�V���ȑO�ł�����낵���ł����H";
                    }
                    else
                    {
                        message = "�O�񌎎��X�V���ȑO�͐ݒ�ł��܂���B";
                    }
                    break;
				// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				//// ���M�̐ݒ�͕����ݒ�`�F�b�N
				//case 3:
				//    message = "���M�̐ݒ�͕����ݒ�ł��܂���B";
				//    break;

				//// �f�[�^�͑��M�E��M�̂ǂ��炩�̂ݐݒ�\�`�F�b�N
				//case 4:
				//    message = "�f�[�^�͑��M�E��M�̂ǂ��炩�̂ݐݒ�\�ł��B";
				//    break;
				// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
            }
            // --- ADD 2009/05/21 ------------------------------<<<<<

            // --- DEL 2009/05/21 ------------------------------->>>>>
            //if (this.Kind_tComEditor.SelectedIndex == 0
            //    && this.ReceiveCondition_tComEditor.SelectedIndex == 0)
            //{
            //    int totalNum = this._secMngSetAcs.CheckSearch(this._enterpriseCode);
            //    if (totalNum > 0)
            //    {
            //        checkResult = false;
            //    }
            //}
            // --- DEL 2009/05/21 ------------------------------<<<<<

            return status;
        }

        // --- ADD 2009/05/21 ------------------------------->>>>>
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@����M�Ώۋ��_�̑��݃`�F�b�N
        /// </summary>
        /// <param name="flag">0:���; 1:����M�敪; 2:����M�Ώۋ��_; 3:���M�拒�_</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����M�Ώۋ��_�̑��݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private bool ModeChangeProc(int flag)
        {
            bool status = false;

            if (this.DataIndex > 0 || this._indexBuf == -2)
            {
                return status;
            }

            string iMsg1 = "���͂��ꂽ�R�[�h�̋��_�Ǘ��ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";
            string iMsg2 = "���͂��ꂽ�R�[�h�̋��_�Ǘ��ݒ���͊��ɍ폜����Ă��܂��B";

            string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			string sSendSecCd =  this.tEdit_SendSecCd.DataText.Trim().PadLeft(2, '0');
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
            string sKind;
            if (this.Kind_tComEditor.SelectedIndex == 0)
            {
                sKind = KIND_TCOMEDITOR_VALUE0;
            }
            else
            {
                sKind = KIND_TCOMEDITOR_VALUE1;
            }

            string sReCondition;
            if (this.ReceiveCondition_tComEditor.SelectedIndex == 0)
            {
                sReCondition = RECEIVECONDITION_TCOMEDITOR_VALUE0;
            }
            else
            {
                sReCondition = RECEIVECONDITION_TCOMEDITOR_VALUE1;
            }

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string section = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                string kind = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_KIND_TITLE];
                string receiveCondition = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_RECEIVE_CONDITION_TITLE];
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				string sendSecCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SENDSEC_CODE_TITLE];
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                if (sectionCode.Equals(section.Trim().PadLeft(2, '0'))
                    && sKind.Equals(kind)
                    && sReCondition.Equals(receiveCondition)
					&& sSendSecCd.Equals(sendSecCode.Trim().PadLeft(2, '0'))// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j
					)
                {
                    // ���͂��ꂽ�R�[�h�͍폜��ԏꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != string.Empty)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg2, 0, MessageBoxButtons.OK);
                        if (flag == 0)
                        {
                            this.Kind_tComEditor.SelectedIndex = 0;
                        }
                        else if (flag == 1)
                        {
                            this.ReceiveCondition_tComEditor.SelectedIndex = 0;
                        }
						else if (flag == 2)
                        {
							this.tEdit_SectionCode.Clear();
                            this.tEdit_SectionName.Clear();
                        }
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
						else
						{
							this.tEdit_SendSecCd.Clear();
							this.tEdit_SendSecName.Clear();
						}
						// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                        return true;
                    }

                    // ���͂��ꂽ�R�[�h�����ݏꍇ
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg1, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this.DataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            break;

                        case DialogResult.No:
                            if (flag == 0)
                            {
                                this.Kind_tComEditor.SelectedIndex = 0;
                            }
                            else if (flag == 1)
                            {
                                this.ReceiveCondition_tComEditor.SelectedIndex = 0;
                            }
							else if (flag == 2)
                            {
								this.tEdit_SectionCode.Clear();
                                this.tEdit_SectionName.Clear();
                            }
							// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
							else
							{
								this.tEdit_SendSecCd.Clear();
								this.tEdit_SendSecName.Clear();
							}
							// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                            break;
                    }
                    return true;
                }
            }
            return status;
        }
        // --- ADD 2009/05/21 ------------------------------<<<<<

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@�ۑ�����(SaveSecMngSet())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private bool SaveSecMngSet()
        {
            bool result = false;
            Control control = null;

            //��ʃf�[�^���̓`�F�b�N����
            string checkMessage = "";
            int chkSt = CheckDisplay(ref checkMessage);

            if (chkSt != 0)
            {
                return result;
            }

            SecMngSet secMngSet = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                secMngSet = ((SecMngSet)this._secMngSetTable[guid]).Clone();
            }

            ScreenToSecMngSet(ref secMngSet);

            int status = this._secMngSetAcs.Write(ref secMngSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
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
                            this.Text,  �@�@                        // �v���O��������
                            "SaveSecMngSet",                        // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._secMngSetAcs,				    	// �G���[�����������I�u�W�F�N�g
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

            this.SecMngSetToDataSet(secMngSet, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // �V�K�o�^��
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

            result = true;

            return result;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/27</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

			//if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
			//{
			//    sectionName = "�S�Ћ���";
			//    return sectionName;
			//}

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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����M���s����conver����(ToDateTime)
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ����M���s����conver�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private DateTime GetSyncExecDate()
        {
            StringBuilder syncExecDateBuf = new StringBuilder();
            syncExecDateBuf.Append(this.tNedit_SyncExecDateYear.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateMonth.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateDay.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateHour.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateMinute.Value);
            syncExecDateBuf.Append(this.tNedit_SyncExecDateSecond.Value);

            DateTime syncExecDate = new DateTime();
            try
            {
                syncExecDate = string.IsNullOrEmpty(syncExecDateBuf.ToString())
                    ? DateTime.MaxValue
                    : new DateTime(
                    this.tNedit_SyncExecDateYear.GetInt(),
                    this.tNedit_SyncExecDateMonth.GetInt(),
                    this.tNedit_SyncExecDateDay.GetInt(),
                    Convert.ToInt32(this.tNedit_SyncExecDateHour.DataText),
                    Convert.ToInt32(this.tNedit_SyncExecDateMinute.DataText),
                    Convert.ToInt32(this.tNedit_SyncExecDateSecond.DataText),
                    0);
            }
            catch
            {
                syncExecDate = DateTime.MinValue;
            }

            return syncExecDate;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����M���s����conver����(ToArrayList)
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ����M���s����conver�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/26</br>
        /// </remarks>
        private List<string> GetSyncExecDateList(DateTime syncExecDate)
        {
            List<string> syncExecDateList = new List<string>();

            String dateStr = syncExecDate.ToString("yyyyMMddHHmmss");
            syncExecDateList.Add(dateStr.Substring(0, 4));
            syncExecDateList.Add(dateStr.Substring(4, 2));
            syncExecDateList.Add(dateStr.Substring(6, 2));
            syncExecDateList.Add(dateStr.Substring(8, 2));
            syncExecDateList.Add(dateStr.Substring(10, 2));
            syncExecDateList.Add(dateStr.Substring(12, 2));

            return syncExecDateList;
        }

        /// <summary>
        /// ����f�[�^�̃��b�Z�[�W
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ���ɋ��_�Ǘ��ݒ�}�X�^�ɓ���f�[�^����ꍇ�A���b�Z�[�W������B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/30</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^�����ɑ��݂��Ă��܂��B", 	// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
			this.tEdit_SectionCode.Focus();

			control = tEdit_SectionCode;
        }
        # endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load �C�x���g(PMKYO09100UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/03/25</br>
        /// </remarks>
        private void PMKYO09100UA_Load(object sender, EventArgs e)
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
            this.Save_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Save_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
			this.SendSecGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j


            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/03/25</br>
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
                    this._preSectionCode = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.ModeChangeProc(2);
					
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		/// <summary>
		/// Control.Click �C�x���g(SectionGuide_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011/07/21</br>
		/// </remarks>
		private void SendSecGuide_Button_Click(object sender, EventArgs e)
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
					bool chkFlg = CheckSection(secInfoSet.SectionCode.Trim());

					if (!chkFlg)
					{
						TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						"�w�肵�����M�拒�_�͊�Ɛݒ�ɓo�^����Ă��܂���B",	                // �\�����郁�b�Z�[�W
						0,									    // �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��

						this.tEdit_SendSecCd.DataText = this._preSendSecCd;
					}
					else
					{
						this.tEdit_SendSecCd.DataText = secInfoSet.SectionCode.Trim();
						this._preSendSecCd = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
						this.tEdit_SendSecName.DataText = secInfoSet.SectionGuideNm.Trim();
					}

					this.ModeChangeProc(3);
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/03/25</br>
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

            int status = 0;

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
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

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SecMngSet secMngSet = (SecMngSet)this._secMngSetTable[guid];

            // ���_���_���폜����
            status = this._secMngSetAcs.Delete(secMngSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._secMngSetTable.Remove(secMngSet.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

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
                            this._secMngSetAcs, 				// �G���[�����������I�u�W�F�N�g
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Save_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
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

            if (!SaveSecMngSet())
            {
                return;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/03/25</br>
        /// <br>Update Note: 2011/10/08 tianjw</br>
        /// <br>             Redmine#25781 ���_�Ǘ��ݒ�}�X�^�̕��������̃X�e�[�^�X�`�F�b�N�̑Ή�</br>
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

            // �m�F���b�Z�[�W
            DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,                       // �G���[���x��
                ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                //"���ݕ\���̋��_�Ǘ��ݒ�}�X�^�𕜊����܂��B"+ "\r\n"  //DEL 2009/05/20
                "���ݕ\�����̋��_�Ǘ��ݒ�}�X�^�𕜊����܂��B" + "\r\n"
                + "��낵���ł����H", 					              // �\�����郁�b�Z�[�W
                0, 					                                  // �X�e�[�^�X�l
                MessageBoxButtons.YesNo);	                          // �\������{�^��

            if (res != DialogResult.Yes)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            string msg = string.Empty;
            status = this.CheckScreenCondtion(ref msg);
            // ----- DEL 2011/10/08 -------------------->>>>>
            //if (status == 3 || status == 4)
            //{
            //    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
            //        ASSEMBLY_ID,							// �A�Z���u��ID
            //        msg,	                                // �\�����郁�b�Z�[�W
            //        0,									    // �X�e�[�^�X�l
            //        MessageBoxButtons.OK);					// �\������{�^��

            //    return;
            //}
            // ----- DEL 2011/10/08 --------------------<<<<<
            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SecMngSet secMngSet = ((SecMngSet)this._secMngSetTable[guid]).Clone();


            //  ���_�Ǘ��ݒ�}�X�^�_���폜��������
            status = this._secMngSetAcs.Revival(ref secMngSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        SecMngSetToDataSet(secMngSet, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);

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
                            this._secMngSetAcs,					// �G���[�����������I�u�W�F�N�g
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SecMngSet compareSecMngSet = new SecMngSet();

                compareSecMngSet = this._secMngSetClone.Clone();
                ScreenToSecMngSet(ref compareSecMngSet);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._secMngSetClone.Equals(compareSecMngSet))))
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
                                SaveSecMngSet();

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
            this._preSectionCode = string.Empty;

			this._preSendSecCd = string.Empty;// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X���[�X�g�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

			if (e.PrevCtrl == this.tEdit_SectionCode)
            {
                // --- ADD 2009/05/21 ------------------------------->>>>>
                // ����M�Ώۋ��_�̑��݃`�F�b�N
                if (this.ModeChangeProc(2))
                {
                    return;
                }
                // --- ADD 2009/05/21 ------------------------------<<<<<
                bool flag = true;
                try
                {
                    // ���_�R�[�h�擾
					string sectionCode = this.tEdit_SectionCode.DataText;
					if (sectionCode.Trim().Equals(ALL_SECTIONCODE) || sectionCode.Trim().Equals(""))
					{
						this.tEdit_SectionName.DataText = string.Empty;
						this._preSectionCode = string.Empty;
						flag = false;
						return;
					}

                    if (sectionCode.Trim().Equals(this._preSectionCode))
                    {
						this.tEdit_SectionCode.Text = sectionCode.Trim().PadLeft(2, '0');// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j
                        flag = true;
                        return;
                    }

                    // ���_���̎擾
                    string sectionName = GetSectionName(sectionCode);

                    if (sectionName.Trim() != string.Empty)
                    {
                        this._preSectionCode = sectionCode;
                        this.tEdit_SectionName.DataText = sectionName;
						this.tEdit_SectionCode.Text = sectionCode.Trim().PadLeft(2, '0');
                        flag = true;
                    }
                    else
                    {
                        TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ASSEMBLY_ID,							// �A�Z���u��ID
                        "�w�肵�����_�R�[�h�͑��݂��܂���B",	                // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��

						this.tEdit_SectionCode.DataText = this._preSectionCode;
                        flag = false;
                    }
                }
                finally
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (flag)
                            {
                                // �t�H�[�J�X�ݒ�
								e.NextCtrl = this.tEdit_SendSecCd;
                            }
                            else
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                        }
                    }
                }
            }

			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			if (e.PrevCtrl == this.tEdit_SendSecCd)
			{
				// --- ADD 2009/05/21 ------------------------------->>>>>
				// ����M�Ώۋ��_�̑��݃`�F�b�N
				if (this.ModeChangeProc(3))
				{
					return;
				}
				// --- ADD 2009/05/21 ------------------------------<<<<<
				bool flag = true;
				try
				{
					// ���_�R�[�h�擾
					string sendSecCd = this.tEdit_SendSecCd.DataText.Trim().PadLeft(2, '0');

					if (sendSecCd.Trim().Equals(ALL_SECTIONCODE) || sendSecCd.Trim().Equals(""))
					{
						this.tEdit_SendSecCd.Text = string.Empty;
						this.tEdit_SendSecName.DataText = string.Empty;
						this._preSendSecCd = string.Empty;
						flag = false;
						return;
					}

					if (sendSecCd.Trim().Equals(this._preSendSecCd))
					{
						this.tEdit_SendSecCd.Text = sendSecCd.Trim().PadLeft(2, '0');
						flag = true;
						return;
					}

					// ���_���̎擾
					string sectionName = GetSectionName(sendSecCd);

					if (sectionName.Trim() != string.Empty)
					{
						// ��Ɛݒ�ɓo�^���Ȃ����_�`�F�b�N
						bool checkFlg = CheckSection(sendSecCd);
						
						if (!checkFlg)
						{
							TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							ASSEMBLY_ID,							// �A�Z���u��ID
							"�w�肵�����M�拒�_�͊�Ɛݒ�ɓo�^����Ă��܂���B",	                // �\�����郁�b�Z�[�W
							0,									    // �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��

							this.tEdit_SendSecCd.DataText = this._preSendSecCd;
							flag = false;
							return;
						}
						else
						{
							this._preSendSecCd = sendSecCd;
							this.tEdit_SendSecName.DataText = sectionName;
							this.tEdit_SendSecCd.Text = sendSecCd.Trim().PadLeft(2, '0');
							flag = true;
						}
					}
					else
					{
						TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						"�w�肵�����_�R�[�h�͑��݂��܂���B",	                // �\�����郁�b�Z�[�W
						0,									    // �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��

						this.tEdit_SendSecCd.DataText = this._preSendSecCd;
						flag = false;
					}
				}
				finally
				{
					if (e.ShiftKey == false)
					{
						if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
						{
							if (flag)
							{
								// �t�H�[�J�X�ݒ�
								e.NextCtrl = this.tNedit_SyncExecDateYear;
							}
							else
							{
								// �t�H�[�J�X�ݒ�
								e.NextCtrl = this.SendSecGuide_Button;
							}
						}
					}
				}
			}
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMKYO09100UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void PMKYO09100UA_VisibleChanged(object sender, EventArgs e)
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing �C�x���g(PMKYO09100UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/03/25</br>
        /// </remarks>
        private void PMKYO09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            this._preSectionCode = string.Empty;
			this._preSendSecCd = string.Empty;// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_SyncExecDateYear)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateYear_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateYear.DataText.Length == tNedit_SyncExecDateYear.MaxLength)
            {
                tNedit_SyncExecDateMonth.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_SyncExecDateMonth)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateMonth_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateMonth.DataText.Length == this.tNedit_SyncExecDateMonth.MaxLength)
            {
                tNedit_SyncExecDateDay.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_SyncExecDateDay)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateDay_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateDay.DataText.Length == this.tNedit_SyncExecDateDay.MaxLength)
            {
                tNedit_SyncExecDateHour.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_SyncExecDateHour)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateHour_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateHour.DataText.Length == this.tNedit_SyncExecDateHour.MaxLength)
            {
                tNedit_SyncExecDateMinute.Focus();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_SyncExecDateMinute)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/16</br>
        /// </remarks>
        private void tNedit_SyncExecDateMinute_ValueChanged(object sender, EventArgs e)
        {
            if (this.tNedit_SyncExecDateMinute.DataText.Length == this.tNedit_SyncExecDateMinute.MaxLength)
            {
                tNedit_SyncExecDateSecond.Focus();
            }
        }

        // --- ADD 2009/05/21 ------------------------------->>>>>
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(ReceiveCondition_tComEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private void ReceiveCondition_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // ����M�Ώۋ��_�̑��݃`�F�b�N
            this.ModeChangeProc(1);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	ValueChanged�C�x���g(Kind_tComEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private void Kind_tComEditor_ValueChanged(object sender, EventArgs e)
        {
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			if (this.Kind_tComEditor.SelectedIndex == 1)
			{
				this.uLabel_SectionCode.Visible = false;
				this.tEdit_SectionCode.Visible = false;
				this.tEdit_SectionName.Visible = false;
				this.SectionGuide_Button.Visible = false;
				this.ultraLabel3.Visible = false;
				this.sndFin_tComboEditor.Visible = false;

				this.tEdit_SectionCode.Text = string.Empty;
				this.tEdit_SectionName.Text = string.Empty;
				this.sndFin_tComboEditor.SelectedIndex = 0;

			}
			else
			{
				this.uLabel_SectionCode.Visible = true;
				this.tEdit_SectionCode.Visible = true;
				this.tEdit_SectionName.Visible = true;
				this.SectionGuide_Button.Visible = true;
				this.ultraLabel3.Visible = true;
				this.sndFin_tComboEditor.Visible = true;
			}
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
            if (this._indexBuf == -2)
            {
                return;
            }
            // ����M�Ώۋ��_�̑��݃`�F�b�N
            this.ModeChangeProc(0);
        }
        // --- ADD 2009/05/21 ------------------------------<<<<<
        # endregion

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
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

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>				
		/// ��Ɛݒ�ɓo�^���Ȃ����_�`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
		private bool CheckSection(string sendSecCd)
		{
			// ��Ɛݒ�ɓo�^���Ȃ����_��ݒ肵���ꍇ
			EnterpriseSetAcs enterpriseSetAcs = new EnterpriseSetAcs();
			EnterpriseSet enterpriseSet = new EnterpriseSet();
			ArrayList enterpriseSetList = new ArrayList();
			enterpriseSetAcs.SearchAll(out enterpriseSetList, this._enterpriseCode);
			bool checkFlg = false;
			foreach (EnterpriseSet tmpEnterpriseSet in enterpriseSetList)
			{
				if (tmpEnterpriseSet.SectionCode.Trim().Equals(sendSecCd))
				{
					checkFlg = true;
				}
			}
			return checkFlg;
		}

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

    }
}