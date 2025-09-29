//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �`�[�ݒ�}�X�^
// �v���O�����T�v   : �`�[�ݒ�}�X�^�̓o�^�E�X�V�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2008/04/24  �C�����e : PM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2008/06/20  �C�����e : PM.NS�Ή�(���_�R�[�h��ǉ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �s�V�m��
// �� �� ��  2008/10/06  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/01  �C�����e : ��QID:13412�A13413�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�̐ݒ���s���܂��B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br>Update Note: 2008.03.17  30167 ���@�O�M</br>
	/// <br>             �E�f�[�^���̓V�X�e�����\��
	///					 �E�`�[�����ʃ��[�N�V�[�g, �{�f�B���@�}�폜</br>
	/// <br>Update Note: 2008.03.28  30167 ���@�O�M</br>
	/// <br>             �E�[���f�[�^���\������Ȃ��s��C��</br>
	/// <br>Update Note : 2008.03.31 30167 ���@�O�M</br>
	///	<br>			�E���Ӑ�R�[�h�A�N�e�B�u���̕\���s��C��</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 ���n ���</br>
    ///	<br>			�EPM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
    /// <br>Update Note : 2008.06.20 30413 ����</br>
    /// <br>              �EPM.NS�Ή�(���_�R�[�h��ǉ�)</br>
    /// <br>UpdateNote : 2008/10/06 30462 �s�V �m���@�o�O�C��</br>
    /// </remarks>
	public partial class DCKHN09130UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
		/// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public DCKHN09130UA()
		{
			InitializeComponent();

			// �v���p�e�B�����l
			this._canClose = false;     // ����@�\(false�Œ�)
			this._canDelete = true;     // �폜�@�\
			this._canLogicalDeleteDataExtraction = true;     // �_���폜�f�[�^�\���@�\
			this._canNew = true;                             // �V�K�쐬�@�\
			this._canPrint = false;                          // ����@�\
			this._canSpecificationSearch = false;            // �����w�茟���@�\
			this._defaultAutoFillToColumn = true;            // ��T�C�Y���������@�\

            // 2008.06.20 30413 ���� ���_�R�[�h�K�C�h�{�^���̉摜�C���[�W�ǉ� >>>>>>START
            this.uButton_SectionGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // 2008.06.20 30413 ���� ���_�R�[�h�K�C�h�{�^���̉摜�C���[�W�ǉ� <<<<<<END

			this.uButton_CustomerGuide.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// ��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �C���X�^���X������
			this._custSlipMngAcs = new CustSlipMngAcs();

            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

			this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24

			// �O���b�h�I���C���f�b�N�X
			this._dataIndex = -1;
			this._indexBuf = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

		private string _enterpriseCode = "";           // ��ƃR�[�h

		private CustSlipMngAcs _custSlipMngAcs = null;

        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
        private SecInfoSetAcs _secInfoSetAcs = null;
        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

		private CustomerInfoAcs _customerInfoAcs = null;
        private SupplierAcs _supplierAcs = null; // ADD 2008.04.24

		// ���C���p�N���[���I�u�W�F�N�g
		private CustSlipMng _custSlipMngClone = null;

		// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _dataIndex;
		private int _indexBuf;

		//----- h.ueno add ---------- start 2008.03.17
		private int _slipPrtKind_tComboEditorValue = -1;	// �`�[�����ʃR���{�{�b�N�X�f�[�^���[�N

        // 2008.06.20 30413 ���� ���_�R�[�h�i���[�N�j�ǉ� >>>>>>START
        private int _sectionCodeWork = 0;
        // 2008.06.20 30413 ���� ���_�R�[�h�i���[�N�j�ǉ� <<<<<<END

		// ���Ӑ�R�[�h�i���[�N�j
		private int _customerCodeWork = 0;
		//----- h.ueno add ---------- end 2008.03.17

		// �v���p�e�B�p
		private bool _canClose;
		private bool _canDelete;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canNew;
		private bool _canPrint;
		private bool _canSpecificationSearch;
		private bool _defaultAutoFillToColumn;

		// �ҏW���[�h
		private int _editingMode = 0;
		private const int CT_EMODE_INSERT = -1;           // �V�K���[�h
		private const int CT_EMODE_UPDATE = 0;            // �X�V���[�h
		private const int CT_EMODE_DELETE = 1;            // �폜���[�h
		private const int CT_EMODE_REFER = 2;            // �Q�ƃ��[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";
		private const string REFER_MODE = "�Q�ƃ��[�h";

		// ��ʃ��C�A�E�g�p�萔
		private const int BUTTON_LOCATION1_X = 67;        // ���S�폜�{�^���ʒuX
		private const int BUTTON_LOCATION2_X = 194;      // �����{�^���ʒuX
		private const int BUTTON_LOCATION3_X = 321;      // �ۑ��{�^���ʒuX
		private const int BUTTON_LOCATION4_X = 448;      // ����{�^���ʒuX
		private const int BUTTON_LOCATION_Y = 9;        // �{�^���ʒuY(����)

		// PG���
		private const string CT_PGID = "DCKHN09130U";
		//private const string CT_PGNAME = "���Ӑ�}�X�^(�`�[�Ǘ�)";
		private const string CT_CLASSNAME = "DCKHN09130UA";

		// Message�֘A��`
		private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂��B";
		private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂��B";
		private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂��B";

        //----- h.ueno add ---------- start 2008.03.17
		private const string CUSTOMER_COMMON = "����";
		//----- h.ueno add ---------- end 2008.03.17

        // �S�Ћ��ʂ̋��_�R�[�h
        private const string SECTION_COMMON_CODE = "00";    // ADD 2009/06/01

        // 2008.09.29 30413 ���� �S�Ћ��ʂ�ǉ� >>>>>>START
        private const string SECTION_COMMON = "�S�Ћ���";
        // 2008.09.29 30413 ���� �S�Ћ��ʂ�ǉ� <<<<<<END

		#endregion

		//----- h.ueno upd ---------- start 2008.03.17
		#region enum
		/// <summary>
		/// ���̓G���[�`�F�b�N�X�e�[�^�X
		/// </summary>
		private enum InputChkStatus
		{
			// ������
			NotInput = -1,
			// ���݂��Ȃ�
			NotExist = -2,
			// ���̓~�X
			InputErr = -3,
			// ����
			Normal = 0,
			// �L�����Z��
			Cancel = 1,
			// �قȂ�
			Different
		}

		/// <summary>
		/// ��ʃf�[�^�ݒ�X�e�[�^�X
		/// </summary>
		private enum DispSetStatus
		{
			// �N���A
			Clear = 0,
			// �X�V
			Update = 1,
			// ���ɖ߂�
			Back = 2
		}
		#endregion enum
		//----- h.ueno add---------- end 2008.03.17

		// --------------------------------------------------
		#region Events

		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ������ɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

		#endregion

		// --------------------------------------------------
		#region Delegate

		/// <summary>
		/// �O���b�h�p�񓯊��f���Q�[�g
		/// </summary>
		/// <param name="rowIndex">�s�C���f�b�N�X</param>
		/// <param name="columnName">�J������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�ɂ�����񓯊����s�Ɏg�p����f���Q�[�g�ł��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private delegate void GridMethodInvoker(int rowIndex, string columnName);

		#endregion

		// --------------------------------------------------
		#region Properties

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

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
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

		/// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>������\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
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

		#endregion

		// --------------------------------------------------
		#region Frame Methods

		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u����</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this._custSlipMngAcs.BindDataSet;
			tableName = CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̊e��̊O�ς�ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// �폜��
			appearanceTable.Add(CustSlipMngAcs.COL_DELETEDATE_TITLE,
				new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

			//----- h.ueno upd ---------- start 2008.03.17 ��\���ɂ���
			// �f�[�^���̓V�X�e��
			appearanceTable.Add(CustSlipMngAcs.COL_DATAINPUTSYSTEM_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// �f�[�^���̓V�X�e������
			appearanceTable.Add(CustSlipMngAcs.COL_DATAINPUTSYSTEMNAME_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- h.ueno upd ---------- end 2008.03.17

			// �`�[�����ʃR�[�h
			appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTKIND_TITLE,
				new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// �`�[�����ʖ���
			appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTKINDNAME_TITLE,
				new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            // ���_�R�[�h
            appearanceTable.Add(CustSlipMngAcs.COL_SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CustSlipMngAcs.COL_SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
			// ���Ӑ�R�[�h
			appearanceTable.Add(CustSlipMngAcs.COL_CUSTOMERCODE_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// ���Ӑ於��
			appearanceTable.Add(CustSlipMngAcs.COL_CUSTOMERNAME_TITLE,
				new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// ���[ID
            // DEL 2008/10/06 �s��Ή�[6222] ---------->>>>>              
            //appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTSETPAPERID_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/10/06 �s��Ή�[6222] ----------<<<<<
            // ADD 2008/10/06 �s��Ή�[6222] ---------->>>>>
            appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTSETPAPERID_TITLE,
                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[ID(���́j                          
            appearanceTable.Add(CustSlipMngAcs.COL_SLIPPRTSETPAPERNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2008/10/06 �s��Ή�[6222] ----------<<<<<

			// GUID
			appearanceTable.Add(CustSlipMngAcs.COL_GUID_TITLE,
				new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			return appearanceTable;
		}

		#endregion

		// --------------------------------------------------
		#region DataAccess Methods

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			// ���擾����
			return this.SearchProc(ref totalCount, readCount);
		}

		/// <summary>
		/// Next�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : Next�f�[�^�̌����������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// ������
			return (int)ConstantManagement.DB_Status.ctDB_EOF;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�̌������s�����o���ʂ�DataSet�Ɋi�[���A�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private int SearchProc(ref int totalCount, int readCount)
		{
			const string ctPROCNM = "SearchProc";
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;

			// �������s
			status = this._custSlipMngAcs.SearchAll(out totalCount, this._enterpriseCode);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						break;
					}
				default:
					{
						// �T�[�`
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //CT_PGNAME,                          // �v���O��������
                            this.Name,                          // �v���O��������
							ctPROCNM,                           // ��������
							TMsgDisp.OPE_GET,                   // �I�y���[�V����
							ERR_READ_MSG,                       // �\�����郁�b�Z�[�W
							status,                             // �X�e�[�^�X�l
							this._custSlipMngAcs,               // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,               // �\������{�^��
							MessageBoxDefaultButton.Button1);  // �����\���{�^��
						break;
					}
			}

			return status;
		}

		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �}�X�^���̕ۑ��������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private bool SaveProc()
		{
			const string ctPROCNM = "SaveProc";
			bool result = false;

			// ���̓`�F�b�N
			Control control = null;
			string message = null;
			if (this.ScreenDataCheck(ref control, ref message) == false)
			{
				// ���̓`�F�b�N
				TMsgDisp.Show(
					this,                               // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
					message,                            // �\�����郁�b�Z�[�W
					0,                                  // �X�e�[�^�X�l
					MessageBoxButtons.OK);             // �\������{�^��

				if (control != null)
				{
					control.Focus();
					if (control is TEdit)
					{
						((TEdit)control).SelectAll();
					}
					else if (control is TNedit)
					{
						((TNedit)control).SelectAll();
					}
				}
				return result;
			}

			// ��ʃf�[�^�擾
			CustSlipMng custSlipMng = new CustSlipMng();
			this.DispToCustSlipMng(ref custSlipMng);

			// �������ݏ���
			int status = 0;
			status = this._custSlipMngAcs.Write(custSlipMng);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						result = true;
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
						// �R�[�h�d��
						TMsgDisp.Show(
							this,                           // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
							CT_PGID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
							ERR_DPR_MSG,                    // �\�����郁�b�Z�[�W
							0,                              // �X�e�[�^�X�l
							MessageBoxButtons.OK);         // �\������{�^��
						
						// �`�[�����ʂɃt�H�[�J�X�Z�b�g
						this.SlipPrtKind_tComboEditor.Focus();

						//----- h.ueno add ---------- start 2008.03.31
						// ���_�R�[�h�̐擪�[���l�߂��폜
						this.tNedit_CustomerCode.Text = GetZeroPadCanceledTextProc(this.tNedit_CustomerCode.Text);
						//----- h.ueno add ---------- end 2008.03.31

						return result;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						this.ExclusiveTransaction(status, true);
						break;
					}
				default:
					{
						// �o�^���s
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //CT_PGNAME,                          // �v���O��������
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
							TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
							ERR_UPDT_MSG,                       // �\�����郁�b�Z�[�W
							status,                             // �X�e�[�^�X�l
							this._custSlipMngAcs,               // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,               // �\������{�^��
							MessageBoxDefaultButton.Button1);  // �����\���{�^��
						this.CloseForm(DialogResult.Cancel);

						//----- h.ueno add ---------- start 2008.03.31
						// ���_�R�[�h�̐擪�[���l�߂��폜
						this.tNedit_CustomerCode.Text = GetZeroPadCanceledTextProc(this.tNedit_CustomerCode.Text);
						//----- h.ueno add ---------- end 2008.03.31

						return result;
					}
			}

			return result;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃��R�[�h�̍폜���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int Delete()
		{
			return this.LogicalDeleteProc();
		}

		/// <summary>
		/// �_���폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �}�X�^���̘_���폜�������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private int LogicalDeleteProc()
		{
			const string ctPROCNM = "LogicalDeleteProc";
			int status = 0;

			DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if ((this._dataIndex < 0) ||
				(this._dataIndex >= dt.Rows.Count))
			{
				return status;
			}

            // 2008.09.22 30413 ���� ���_���S�Аݒ�̃f�[�^�͍폜�s�� >>>>>>START
            string sectionCode = (string)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_SECTIONCODE_TITLE];
            int customerCode = (int)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];
            //if ((sectionCode.TrimEnd() == "0") && (customerCode == 0))    // DEL 2009/06/01
            if ((sectionCode.TrimEnd() == SECTION_COMMON_CODE) && (customerCode == 0))  // ADD 2009/06/01
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    CT_PGID,
                    "�S�Аݒ�̃��R�[�h�͍폜�ł��܂���",
                    status,
                    MessageBoxButtons.OK);
                this.Hide();

                return -2;
            }

			// �I���f�[�^�擾
			Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE]; // GUID

			// �_���폜���s
			status = this._custSlipMngAcs.LogicalDelete(fileHeaderGuid);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				// �r������
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status, false);
						return status;
					}
				default:
					{
						// �����폜
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //CT_PGNAME,                          // �v���O��������
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
							TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
							ERR_RDEL_MSG,                       // �\�����郁�b�Z�[�W
							status,                             // �X�e�[�^�X�l
							this._custSlipMngAcs,               // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,               // �\������{�^��
							MessageBoxDefaultButton.Button1);   // �����\���{�^��
						return status;
					}
			}
			return status;
		}

		/// <summary>
		/// �_���폜��������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�����������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private int RevivalProc()
		{
			const string ctPROCNM = "RevivalProc";
			int status = 0;

			DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if ((this._indexBuf < 0) ||
				(this._indexBuf >= dt.Rows.Count))
			{
				this.CloseForm(DialogResult.Cancel);
				return -1;
			}

			// �I���f�[�^�擾
			Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE]; // GUID

			// �_���폜�������s
			status = this._custSlipMngAcs.Revival(fileHeaderGuid);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				// �r������
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status, true);
						return status;
					}
				default:
					{
						// �����폜
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //CT_PGNAME,                          // �v���O��������
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
							TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
							ERR_RVV_MSG,                        // �\�����郁�b�Z�[�W
							status,                             // �X�e�[�^�X�l
							this._custSlipMngAcs,               // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,               // �\������{�^��
							MessageBoxDefaultButton.Button1);  // �����\���{�^��
						return status;
					}
			}

			return status;
		}

		/// <summary>
		/// �����폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����폜�������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private int PhysicalDeleteProc()
		{
			const string ctPROCNM = "PhysicalDeleteProc";
			int status = 0;

			DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if ((this._indexBuf < 0) ||
				(this._indexBuf >= dt.Rows.Count))
			{
				this.CloseForm(DialogResult.Cancel);
				return -1;
			}

			// �I���f�[�^�擾
			Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE]; // GUID

			// �����폜���s
			status = this._custSlipMngAcs.Delete(fileHeaderGuid);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				// �r������
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status, true);
						return status;
					}
				default:
					{
						// �����폜
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //CT_PGNAME,                          // �v���O��������
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
							TMsgDisp.OPE_DELETE,                // �I�y���[�V����
							ERR_RDEL_MSG,                       // �\�����郁�b�Z�[�W
							status,                             // �X�e�[�^�X�l
							this._custSlipMngAcs,               // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,               // �\������{�^��
							MessageBoxDefaultButton.Button1);  // �����\���{�^��
						return status;
					}
			}

			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����(������)
			return 0;
		}

		#endregion

		// --------------------------------------------------
		#region MemberCopy Methods

		/// <summary>
		/// �}�X�^����ʓW�J����
		/// </summary>
		/// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �}�X�^������ʂɓW�J���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void CustSlipMngToScreen(CustSlipMng custSlipMng)
		{
			// �V�K���[�h�̏ꍇ
			if (this._editingMode == CT_EMODE_INSERT)
			{
				this.DataInputSystemt_ComboEditor.SelectedIndex = 0; // �V�X�e���^�C�v(����)
				
				//----- h.ueno upd ---------- start 2008.03.17
				//this.SlipPrtKind_tComboEditor.Clear();               // �`�[�����ʃR�[�h
				this.SlipPrtKind_tComboEditor.SelectedIndex = 0;

				// �R���{�{�b�N�X�t�B���^�[�ݒ�i�`�[����ݒ�p���[ID�ݒ�j
				if (this.SlipPrtKind_tComboEditor.Value != null)
				{
					SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
				}

                // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
                this.SetKind_tComboEditor.Value = 0;
                // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END
            
                // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                this.tEdit_SectionCodeAllowZero.Clear();            // ���_�R�[�h
                this.SectionCodeNm_tEdit.Clear();                   // ���_����
                // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

				this.tNedit_CustomerCode.Clear();                   // ���Ӑ�R�[�h
				this.CustomerCodeNm_tEdit.Clear();                  // ���Ӑ於��
				//----- h.ueno upd ---------- end 2008.03.17
			}
			// �V�K���[�h�ȊO�̏ꍇ
			else
			{
				this.DataInputSystemt_ComboEditor.Value = custSlipMng.DataInputSystem;// �V�X�e���^�C�v 
				this.SlipPrtKind_tComboEditor.Value = custSlipMng.SlipPrtKind;        // �`�[�����ʃR�[�h

				//----- h.ueno upd ---------- start 2008.03.17
				// �R���{�{�b�N�X�t�B���^�[�ݒ�i�`�[����ݒ�p���[ID�ݒ�j�����������̂ōX�V�f�[�^�̐ݒ�͂��̌�ɍs��
				SlipPrtKindVisibleChange(custSlipMng.SlipPrtKind);

                // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
                if (custSlipMng.CustomerCode == 0)
                {
                    // ���Ӑ�R�[�h�̐ݒ薳
                    this.SetKind_tComboEditor.Value = 0;

                    // ���_
                    if (int.Parse(custSlipMng.SectionCode) == 0)
                    {
                        //this.tEdit_SectionCodeAllowZero.Text = "00";      // DEL 2009/06/01
                        this.tEdit_SectionCodeAllowZero.Text = SECTION_COMMON_CODE;     // ADD 2009/06/01
                        this.SectionCodeNm_tEdit.Text = SECTION_COMMON;
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero.Text = custSlipMng.SectionCode;             // ���_�R�[�h
                        this.SectionCodeNm_tEdit.Text = GetSectionName(custSlipMng.SectionCode);    // ���_����
                    }

                    // ���Ӑ�͖��ݒ�Ƃ���
                    this.tNedit_CustomerCode.Clear();                   // ���Ӑ�R�[�h
                    this.CustomerCodeNm_tEdit.Clear();                  // ���Ӑ於��
                }
                else
                {
                    // ���Ӑ�R�[�h�̐ݒ薳
                    this.SetKind_tComboEditor.Value = 1;

                    // ���_�͖��ݒ�Ƃ���
                    this.tEdit_SectionCodeAllowZero.Clear();            // ���_�R�[�h
                    this.SectionCodeNm_tEdit.Clear();                   // ���_����

                    // ���Ӑ�
                    this.tNedit_CustomerCode.SetInt(custSlipMng.CustomerCode);					// ���Ӑ�R�[�h
                    this.CustomerCodeNm_tEdit.Text = custSlipMng.CustomerSnm;					// ���Ӑ於��
                }
                // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END

                // 2008.09.22 30413 ���� ���̏����ǉ��ŃR�����g >>>>>>START
                //// 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                //if (custSlipMng.SectionCode.TrimEnd().Equals("0"))
                //{
                //    this.tEdit_SectionCodeAllowZero.Text = "";
                //    this.SectionCodeNm_tEdit.Text = "";
                //}
                //else
                //{
                //    this.tEdit_SectionCodeAllowZero.Text = custSlipMng.SectionCode;             // ���_�R�[�h
                //    this.SectionCodeNm_tEdit.Text = GetSectionName(custSlipMng.SectionCode);    // ���_����
                //}
                //// 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

                //this.tNedit_CustomerCode.SetInt(custSlipMng.CustomerCode);					// ���Ӑ�R�[�h
                //this.CustomerCodeNm_tEdit.Text = custSlipMng.CustomerSnm;					// ���Ӑ於��
                // 2008.09.22 30413 ���� ���̏����ǉ��ŃR�����g <<<<<<END

                this.SlipPrtSetPaperId_tComboEditor.Value = custSlipMng.SlipPrtSetPaperId;	// ���[ID
				//----- h.ueno upd ---------- end 2008.03.17
			}
			//----- h.ueno mov ---------- start 2008.03.17
			//this.SlipPrtSetPaperId_tEdit.Text = custSlipMng.SlipPrtSetPaperId;        // ���[ID
			//----- h.ueno mov ---------- end 2008.03.17
		}

		/// <summary>
		/// ��ʃf�[�^�擾����
		/// </summary>
		/// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʃf�[�^�̎擾���s���܂�</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DispToCustSlipMng(ref CustSlipMng custSlipMng)
		{
			// �X�V���[�h�̏ꍇ
			if (this._editingMode == CT_EMODE_UPDATE)
			{
				// Guid
				DataTable dt = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE];
				custSlipMng.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustSlipMngAcs.COL_GUID_TITLE];
			}

			// ��ƃR�[�h
			custSlipMng.EnterpriseCode = this._enterpriseCode;
			// �V�X�e���^�C�v
			if (this.DataInputSystemt_ComboEditor.SelectedIndex != -1)
			{
				custSlipMng.DataInputSystem = (int)this.DataInputSystemt_ComboEditor.Value;
			}
			// �`�[�����ʃR�[�h
			if (this.SlipPrtKind_tComboEditor.SelectedIndex != -1)
			{
				custSlipMng.SlipPrtKind = (int)this.SlipPrtKind_tComboEditor.Value;
			}

            // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                // ���_�P��
                // ���_�R�[�h
                //if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd() == "00")
                if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') == SECTION_COMMON_CODE)
                {
                    // �S�Аݒ�
                    //custSlipMng.SectionCode = "0";    // DEL 2009/06/01
                    custSlipMng.SectionCode = SECTION_COMMON_CODE;  // ADD 2009/06/01
                }
                else
                {
                    // �S�Аݒ�ȊO
                    //custSlipMng.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();     // DEL 2009/06/01
                    custSlipMng.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');   // ADD 2009/06/01
                }

                // ���Ӑ�R�[�h
                custSlipMng.CustomerCode = 0;
            }
            else
            {
                // ���_�R�[�h
                custSlipMng.SectionCode = "0";

                // ���Ӑ�R�[�h
                custSlipMng.CustomerCode = this.tNedit_CustomerCode.GetInt();

                // ADD 2008/10/07 �s��Ή�[6221] ---------->>>>>
                // ���Ӑ於�̂�ݒ�
                custSlipMng.CustomerSnm = this.CustomerCodeNm_tEdit.Text;
                // ADD 2008/10/07 �s��Ή�[6221] ----------<<<<<

            }
            // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END

            // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ��ŃR�����g >>>>>>START
            //// 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            //// ���_�R�[�h
            //if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd().Equals(""))
            //{
            //    custSlipMng.SectionCode = "0";
            //}
            //else
            //{
            //    custSlipMng.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
            //}
            //// 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

            ////----- h.ueno upd ---------- start 2008.03.17
            //// ���Ӑ�R�[�h
            //custSlipMng.CustomerCode = this.tNedit_CustomerCode.GetInt();
            //// ���Ӑ於��
            //custSlipMng.CustomerSnm = this.CustomerCodeNm_tEdit.Text.TrimEnd();
            // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ��ŃR�����g <<<<<<END
            
            // ���[ID
			custSlipMng.SlipPrtSetPaperId = (string)this.SlipPrtSetPaperId_tComboEditor.Value;
			//----- h.ueno upd ---------- end 2008.03.17
		}

		#endregion

		// --------------------------------------------------
		#region Screen Methods

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̃N���A���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.DataInputSystemt_ComboEditor.SelectedIndex = -1;   // �V�X�e���^�C�v
			this.SlipPrtKind_tComboEditor.SelectedIndex = -1;       // �`�[���

            // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
            this.SetKind_tComboEditor.Value = 0;
            // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END
            
            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            this.tEdit_SectionCodeAllowZero.Clear();                // ���_�R�[�h
            this.SectionCodeNm_tEdit.Clear();                       // ���_����
            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

			this.tNedit_CustomerCode.Clear();                       // ���Ӑ�
			//----- h.ueno upd ---------- start 2008.03.17
			this.CustomerCodeNm_tEdit.Clear();                      // ���Ӑ於 
			this.SlipPrtSetPaperId_tComboEditor.SelectedIndex = 0;	// ���[ID
			_slipPrtKind_tComboEditorValue = -1;	                // �`�[�����ʃR���{�{�b�N�X�f�[�^���[�N
			//----- h.ueno upd ---------- end 2008.03.17
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̍č\�z�������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			CustSlipMng custSlipMng = new CustSlipMng();

			//----- h.ueno add ---------- start 2008.03.17				
			// �`�[����ݒ�p���[ID�ݒ�
			foreach (DictionaryEntry de in this._custSlipMngAcs._slipPrtSetPaperIdList)
			{
				SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;
				this.SlipPrtSetPaperId_tComboEditor.Items.Add(slipPrtSetWk.SlipPrtSetPaperId, slipPrtSetWk.SlipComment);
			}
			//----- h.ueno add ---------- end 2008.03.17

			// �V�K�̎�
			if (this._dataIndex < 0)
			{
				// �V�K���[�h�ɐݒ�
				this._editingMode = CT_EMODE_INSERT;
				this.Mode_Label.Text = INSERT_MODE;

				// ��ʂɓW�J
				this.CustSlipMngToScreen(custSlipMng);
				
				// �N���[���쐬
				this._custSlipMngClone = new CustSlipMng();
				this.DispToCustSlipMng(ref this._custSlipMngClone);

				// ��ʓ��͋�����ݒ�
				this.ScreenInputPermissionControl(this._editingMode);

                // 2009.02.04 30413 ���� �����t�H�[�J�X��ݒ��ʂɐݒ� >>>>>>START
                this.SetKind_tComboEditor.Focus();
                // 2009.02.04 30413 ���� �����t�H�[�J�X��ݒ��ʂɐݒ� <<<<<<END
            }
			else
			{
				// �t���[���őI������Ă��郌�R�[�h�̃I�u�W�F�N�g���擾
				DataRowView dr = this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[this._dataIndex];

				if ((string)dr[CustSlipMngAcs.COL_DELETEDATE_TITLE] != "") // �폜��
				{
					custSlipMng.LogicalDeleteCode = 1;
				}
				custSlipMng.DataInputSystem = (int)dr[CustSlipMngAcs.COL_DATAINPUTSYSTEM_TITLE];        // �V�X�e���^�C�v
				custSlipMng.SlipPrtKind = (int)dr[CustSlipMngAcs.COL_SLIPPRTKIND_TITLE];                // �`�[�����ʃR�[�h

                // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                custSlipMng.SectionCode = (string)dr[CustSlipMngAcs.COL_SECTIONCODE_TITLE];             // ���_�R�[�h
                // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

				custSlipMng.CustomerCode = (int)dr[CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];              // ���Ӑ�R�[�h
				custSlipMng.CustomerSnm = (string)dr[CustSlipMngAcs.COL_CUSTOMERNAME_TITLE];            // ���Ӑ於
				custSlipMng.SlipPrtSetPaperId = (string)dr[CustSlipMngAcs.COL_SLIPPRTSETPAPERID_TITLE]; // ���[ID

				// �X�V���[�h
				if (custSlipMng.LogicalDeleteCode == 0)
				{
					// �X�V���[�h�ɐݒ�
					this._editingMode = CT_EMODE_UPDATE;
					this.Mode_Label.Text = UPDATE_MODE;
				}
				// �폜���[�h
				else
				{
					// �폜���[�h�ɐݒ�
					this._editingMode = CT_EMODE_DELETE;
					this.Mode_Label.Text = DELETE_MODE;
				}

				// ��ʂɓW�J
				this.CustSlipMngToScreen(custSlipMng);

				// �N���[���쐬
				this._custSlipMngClone = new CustSlipMng();
				this.DispToCustSlipMng(ref this._custSlipMngClone);

				// ��ʓ��͋�����ݒ�
				this.ScreenInputPermissionControl(this._editingMode);
			}

			// GridIndex�o�b�t�@�ێ�
			this._indexBuf = this._dataIndex;
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="editingMode">�ҏW���[�h</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ScreenInputPermissionControl(int editingMode)
		{
			switch (editingMode)
			{
				// �V�K���[�h
				case CT_EMODE_INSERT:
					{
						// �\���ݒ�
						this.Delete_Button.Visible = false;		// ���S�폜�{�^��
						this.Revive_Button.Visible = false;		// �����{�^��
						this.Ok_Button.Visible = true;			// �ۑ��{�^��
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// ����{�^��

						// ���͋��ݒ�
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = true;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
                        this.SetKind_tComboEditor.Enabled = true;
                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END
                        
						this.SlipPrtKind_tComboEditor.Enabled = true;		// �`�[�����ʃR�[�h

                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = true;              // ���_�R�[�h
                        this.uButton_SectionGuide.Enabled = true;           // ���_�K�C�h
                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

						this.tNedit_CustomerCode.Enabled = true;			// ���Ӑ�R�[�h

						//----- h.ueno upd ---------- start 2008.03.17
						this.uButton_CustomerGuide.Enabled = true;			// ���Ӑ�K�C�h
						this.SlipPrtSetPaperId_tComboEditor.Enabled = true;	// ���[ID
						//----- h.ueno upd ---------- end 2008.03.17

						// �����t�H�[�J�X�ݒ�
						this.DataInputSystemt_ComboEditor.Focus();
						this.DataInputSystemt_ComboEditor.SelectAll();
						break;
					}
				// �X�V���[�h
				case CT_EMODE_UPDATE:
					{
						// �\���ݒ�
						this.Delete_Button.Visible = false;		// ���S�폜�{�^��
						this.Revive_Button.Visible = false;		// �����{�^��
						this.Ok_Button.Visible = true;			// �ۑ��{�^��
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = true;
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// ����{�^��

						// ���͋��ݒ�
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = true;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
                        this.SetKind_tComboEditor.Enabled = false;
                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END
                        
						//----- h.ueno upd ---------- start 2008.03.17
						this.SlipPrtKind_tComboEditor.Enabled = false;		// �`�[�����ʃR�[�h

                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = false;             // ���_�R�[�h
                        this.uButton_SectionGuide.Enabled = false;          // ���_�K�C�h
                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

						this.tNedit_CustomerCode.Enabled = false;			// ���Ӑ�R�[�h
						this.uButton_CustomerGuide.Enabled = false;			// ���Ӑ�K�C�h
						this.SlipPrtSetPaperId_tComboEditor.Enabled = true;	// ���[ID
						//----- h.ueno upd ---------- end 2008.03.17

						// �����t�H�[�J�X�ݒ�
						//----- h.ueno upd ---------- start 2008.03.17
						this.SlipPrtSetPaperId_tComboEditor.Focus();
						//----- h.ueno upd ---------- end 2008.03.17
						break;
					}
				// �폜���[�h
				case CT_EMODE_DELETE:
					{
						// �\���ݒ�
						this.Ok_Button.Visible = false;			// �ۑ��{�^��
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// ����{�^��

						this.Delete_Button.Visible = true;		// ���S�폜�{�^��
						this.Revive_Button.Visible = true;		// �����{�^��
						this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu�V�t�g
						this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu�V�t�g

						// ���͋��ݒ�
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = false;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
                        this.SetKind_tComboEditor.Enabled = false;
                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END
                        
						this.SlipPrtKind_tComboEditor.Enabled = false;			// �`�[�����ʃR�[�h

                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = false;                 // ���_�R�[�h
                        this.uButton_SectionGuide.Enabled = false;              // ���_�K�C�h
                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

						this.tNedit_CustomerCode.Enabled = false;				// ���Ӑ�R�[�h

						//----- h.ueno upd ---------- start 2008.03.17
						this.uButton_CustomerGuide.Enabled = false;				// ���Ӑ�K�C�h
						this.SlipPrtSetPaperId_tComboEditor.Enabled = false;	// ���[ID
						//----- h.ueno upd ---------- end 2008.03.17

						// �����t�H�[�J�X�ݒ�
						this.Delete_Button.Focus();
						break;
					}
				// �Q�ƃ��[�h
				case CT_EMODE_REFER:
					{
						// �\���ݒ�
						this.Ok_Button.Visible = false;			// �ۑ��{�^��
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                        this.Renewal_Button.Visible = false;
                        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                        this.Cancel_Button.Visible = true;		// ����{�^��
						this.Revive_Button.Visible = false;		// �����{�^��
						this.Delete_Button.Visible = false;		// ���S�폜�{�^��

						// ���͋��ݒ�
						//----- h.ueno del ---------- start 2008.03.17
						//this.DataInputSystemt_ComboEditor.Enabled = false;
						//----- h.ueno del ---------- end 2008.03.17

                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� >>>>>>START
                        this.SetKind_tComboEditor.Enabled = false;
                        // 2008.09.22 30413 ���� �ݒ��ʂ̒ǉ� <<<<<<END
                        
						this.SlipPrtKind_tComboEditor.Enabled = false;			// �`�[�����ʃR�[�h

                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                        this.tEdit_SectionCodeAllowZero.Enabled = false;                 // ���_�R�[�h
                        this.uButton_SectionGuide.Enabled = false;              // ���_�K�C�h
                        // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

						this.tNedit_CustomerCode.Enabled = false;				// ���Ӑ�R�[�h

						//----- h.ueno del ---------- start 2008.03.17
						this.uButton_CustomerGuide.Enabled = false;				// ���Ӑ�K�C�h
						this.SlipPrtSetPaperId_tComboEditor.Enabled = false;	// ���[ID
						//----- h.ueno del ---------- end 2008.03.17

						// �����t�H�[�J�X�ݒ�
						this.Cancel_Button.Focus();
						break;
					}
			}
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
		/// <remarks>
		/// <br>Note       : �r���������s���܂�</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void ExclusiveTransaction(int status, bool hide)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					{
						// ���[���X�V
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
							ERR_800_MSG,                        // �\�����郁�b�Z�[�W
							0,                                  // �X�e�[�^�X�l
							MessageBoxButtons.OK);             // �\������{�^��
						if (hide == true)
						{
							this.CloseForm(DialogResult.Cancel);
						}
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// ���[���폜
						TMsgDisp.Show(
							this,                               // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
							CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
							ERR_801_MSG,                        // �\�����郁�b�Z�[�W
							0,                                  // �X�e�[�^�X�l
							MessageBoxButtons.OK);             // �\������{�^��
						if (hide == true)
						{
							this.CloseForm(DialogResult.Cancel);
						}
						break;
					}
			}
		}

		/// <summary>
		/// �t�H�[���N���[�Y����
		/// </summary>
		/// <param name="dialogResult">�_�C�A���O����</param>
		/// <remarks>
		/// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void CloseForm(DialogResult dialogResult)
		{
			// ��ʔ�\���C�x���g
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = dialogResult;

			// GridIndex�o�b�t�@������
			this._indexBuf = -2;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
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
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N����[true: OK, false: NG]</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>   
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			//----- h.ueno del ---------- start 2008.03.17
			//if (this.SlipPrtSetPaperId_tEdit.Text.TrimEnd() == "")
			//{
			//    message = this.SlipPrtSetPaperId_Title_Label.Text + "����͂��Ă��������B";
			//    control = this.SlipPrtSetPaperId_tEdit;
			//    result = false;
			//}
			//// �`�[����ݒ�
			//else if (this.SlipPrtKind_tComboEditor.SelectedIndex == -1)
			//{
			//    message = this.SlipPrtKind_Title_Label.Text + "��I�����ĉ������B";
			//    control = this.SlipPrtKind_tComboEditor;
			//    result = false;
			//}
			//else if (this.DataInputSystemt_ComboEditor.SelectedIndex == -1)
			//{
			//    message = this.ultraLabel1.Text + "��I�����ĉ������B";
			//    control = this.DataInputSystemt_ComboEditor;
			//    result = false;
			//}
			//----- h.ueno del ---------- end 2008.03.17

			//----- ueno add---------- start 2008.03.17
            // 2009.02.04 30413 ���� ���_�Ɠ��Ӑ�̓��̓`�F�b�N���C�� >>>>>>START
            //DispSetStatus dispSetStatus = DispSetStatus.Clear;

            //bool canChangeFocus = true;	// �����ł͖��g�p
            // 2009.02.04 30413 ���� ���_�Ɠ��Ӑ�̓��̓`�F�b�N���C�� <<<<<<END
            
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = null;

            // 2008.09.22 30413 ���� ���_�Ɠ��Ӑ�̃`�F�b�N��ύX >>>>>>START
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                // ���_�P��
                if (this.tEdit_SectionCodeAllowZero.Enabled == true)
                {
                    // �����ݒ�N���A
                    inParamObj = null;
                    outParamObj = null;

                    // 2009.02.04 30413 ���� ���_�̓��̓`�F�b�N���C�� >>>>>>START
                    //// ���_�������͂܂��́u0�v�̏ꍇ
                    //if ((this.tEdit_SectionCodeAllowZero.Text.Equals("")) || (this.tEdit_SectionCodeAllowZero.Text == "00"))
                    //{
                    //    this.tEdit_SectionCodeAllowZero.Text = "00";
                    //    //sectionCodeFlg = false;
                    //}
                    //else
                    //{
                    //    // �����ݒ�
                    //    inParamObj = this.tEdit_SectionCodeAllowZero.Text;

                    //    // ���_���̎擾
                    //    outParamObj = GetSectionName((string)inParamObj);

                    //    // ���_���̂̑��݃`�F�b�N
                    //    if (outParamObj.Equals(""))
                    //    {
                    //        message = "�w�肳�ꂽ�����ŁA���_�R�[�h�͑��݂��܂���ł����B";
                    //        control = this.tEdit_SectionCodeAllowZero;
                    //        this.tEdit_SectionCodeAllowZero.Text = this._sectionCodeWork.ToString();
                    //        return false;
                    //    }

                    //    // �f�[�^�ݒ�
                    //    this.SectionCodeNm_tEdit.Text = (string)outParamObj;
                    //}
                    // 2009.04.02 30413 ���� �S�Аݒ�̃`�F�b�N�C�� >>>>>>START
                    //if (this.tEdit_SectionCodeAllowZero.Text.Equals(""))
                    if ((this.tEdit_SectionCodeAllowZero.Text.Equals("")) ||
                        //(this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') == "00"))     // DEL 2009/06/01
                        (this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') == SECTION_COMMON_CODE))    // ADD 2009/06/01
                    // 2009.04.02 30413 ���� �S�Аݒ�̃`�F�b�N�C�� <<<<<<END
                    {
                        // �����͎��͑S�Аݒ�
                        //this.tEdit_SectionCodeAllowZero.Text = "00";      // DEL 2009/06/01
                        this.tEdit_SectionCodeAllowZero.Text = SECTION_COMMON_CODE;     // ADD 2009/06/01
                        this.SectionCodeNm_tEdit.Text = SECTION_COMMON;
                    }
                    else
                    {
                        // �����ݒ�
                        inParamObj = this.tEdit_SectionCodeAllowZero.Text;

                        // ���_���̎擾
                        outParamObj = GetSectionName((string)inParamObj);

                        // ���_���̂̑��݃`�F�b�N
                        if (outParamObj.Equals(""))
                        {
                            message = "���_�R�[�h�����݂��܂���B";
                            control = this.tEdit_SectionCodeAllowZero;
                            return false;
                        }
                    }
                    // 2009.02.04 30413 ���� ���_�̓��̓`�F�b�N���C�� <<<<<<END
                }
            }
            else
            {
                // ���Ӑ�P��
                if (this.tNedit_CustomerCode.Enabled == true)
                {
                    // �����ݒ�N���A
                    inParamObj = null;
                    outParamObj = null;
                    inParamList = new ArrayList();

                    // 2009.02.04 30413 ���� ���Ӑ�̓��̓`�F�b�N���C�� >>>>>>START
                    //dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

                    // �����ݒ�
                    inParamObj = this.tNedit_CustomerCode.GetInt();

                    // �T�[�`���[�h����(�`�[�����ʂɂ��ω�)
                    int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
                    if (this.SlipPrtKind_tComboEditor.Value != null)
                    {
                        searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
                    }

                    //if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                    //{
                    //    // ���݃`�F�b�N
                    //    switch (CheckCustomerCode(inParamObj, out outParamObj))
                    //    {
                    //        case (int)InputChkStatus.Normal:
                    //            {
                    //                dispSetStatus = DispSetStatus.Update;
                    //                break;
                    //            }
                    //        case (int)InputChkStatus.NotInput:
                    //            {
                    //                message = "���Ӑ�R�[�h����͂��Ă��������B";
                    //                dispSetStatus = DispSetStatus.Clear;
                    //                break;
                    //            }
                    //        default:
                    //            {
                    //                message = "�w�肳�ꂽ�����ŁA���Ӑ�R�[�h�͑��݂��܂���ł����B";

                    //                // ���ʃR�[�h������
                    //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                    //                {
                    //                    dispSetStatus = DispSetStatus.Back;
                    //                }
                    //                else
                    //                {
                    //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                    //                }
                    //                break;
                    //            }
                    //    }
                    //}
                    //else
                    //{
                    //    // ���݃`�F�b�N
                    //    switch (CheckSupplierCode(inParamObj, out outParamObj))
                    //    {
                    //        case (int)InputChkStatus.Normal:
                    //            {
                    //                dispSetStatus = DispSetStatus.Update;
                    //                break;
                    //            }
                    //        case (int)InputChkStatus.NotInput:
                    //            {
                    //                message = "�d����R�[�h����͂��Ă��������B";
                    //                dispSetStatus = DispSetStatus.Clear;
                    //                break;
                    //            }
                    //        default:
                    //            {
                    //                message = "�w�肳�ꂽ�����ŁA�d����R�[�h�͑��݂��܂���ł����B";

                    //                // ���ʃR�[�h������
                    //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                    //                {
                    //                    dispSetStatus = DispSetStatus.Back;
                    //                }
                    //                else
                    //                {
                    //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                    //                }
                    //                break;
                    //            }
                    //    }
                    //}


                    //// �f�[�^�ݒ�
                    //DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

                    //if (dispSetStatus != DispSetStatus.Update)
                    //{
                    //    control = this.tNedit_CustomerCode;
                    //    return false;
                    //}

                    if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                    {
                        this.CheckCustomerCode(inParamObj, out outParamObj);
                    }
                    else
                    {
                        this.CheckSupplierCode(inParamObj, out outParamObj);
                    }
                    // ���Ӑ於�̐ݒ�
                    if ((outParamObj != null) &&
                        (((ArrayList)outParamObj).Count == 2) &&
                        (((ArrayList)outParamObj)[1] is string))
                    {
                        ;
                    }
                    else
                    {
                        message = "���Ӑ�R�[�h�����݂��܂���B";
                        control = this.tNedit_CustomerCode;
                        return false;
                    }
                    // 2009.02.04 30413 ���� ���Ӑ�̓��̓`�F�b�N���C�� <<<<<<END
                }
            }
            // 2008.09.22 30413 ���� ���_�Ɠ��Ӑ�̃`�F�b�N��ύX <<<<<<END
            
            // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            //bool sectionCodeFlg = true;

            //// ���_�R�[�h
            //if (this.tEdit_SectionCodeAllowZero.Enabled == true)
            //{
            //    // �����ݒ�N���A
            //    inParamObj = null;
            //    outParamObj = null;

            //    // ���_�������͂܂��́u0�v�̏ꍇ
            //    if ((this.tEdit_SectionCodeAllowZero.Text.Equals("")) || (this.tEdit_SectionCodeAllowZero.Text.Equals("0")))
            //    {
            //        sectionCodeFlg = false;
            //    }
            //    else
            //    {
            //        // �����ݒ�
            //        inParamObj = this.tEdit_SectionCodeAllowZero.Text;

            //        // ���_���̎擾
            //        outParamObj = GetSectionName((string)inParamObj);

            //        // ���_���̂̑��݃`�F�b�N
            //        if (outParamObj.Equals(""))
            //        {
            //            message = "�w�肳�ꂽ�����ŁA���_�R�[�h�͑��݂��܂���ł����B";
            //            control = this.tEdit_SectionCodeAllowZero;
            //            this.tEdit_SectionCodeAllowZero.Text = this._sectionCodeWork.ToString();
            //            return false;
            //        }

            //        // �f�[�^�ݒ�
            //        this.SectionCodeNm_tEdit.Text = (string)outParamObj;
            //    }
            //}
            //// 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

            ////------------------------
            //// ���Ӑ�R�[�h�`�F�b�N
            ////------------------------
            //// 2008.06.20 30413 ���� ���_�R�[�h�`�F�b�N�Ƃ̊֘A��ǉ� >>>>>>START
            //if (this.tNedit_CustomerCode.Enabled == true)
            //{
            //    // �����ݒ�N���A
            //    inParamObj = null;
            //    outParamObj = null;
            //    inParamList = new ArrayList();

            //    dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                
            //    // ���_�R�[�h�������͂̏ꍇ�̓`�F�b�N���s��
            //    if (sectionCodeFlg == false)
            //    {
            //        // �u0�v�̏ꍇ�A���ʂƂ���
            //        if ((this.tNedit_CustomerCode.Text != "") && (this.tNedit_CustomerCode.GetInt() == 0))
            //        {
            //            // 2008.06.20 30413 ���� ���Ӑ於�̂ւ�"����"�̐ݒ�R�����g >>>>>>START
            //            //this.CustomerCodeNm_tEdit.Text = CUSTOMER_COMMON;
            //            // 2008.06.20 30413 ���� ���Ӑ於�̂ւ�"����"�̐ݒ�R�����g <<<<<<END
            //            this._customerCodeWork = 0;

            //            return true;
            //        }

            //        // �����ݒ�
            //        inParamObj = this.tNedit_CustomerCode.GetInt();

            //        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //        //// ���݃`�F�b�N
            //        //switch (CheckCustomerSupplierCode(inParamObj, out outParamObj))
            //        //{
            //        //    case (int)InputChkStatus.Normal:
            //        //        {
            //        //            dispSetStatus = DispSetStatus.Update;
            //        //            break;
            //        //        }
            //        //    case (int)InputChkStatus.NotInput:
            //        //        {
            //        //            message = "���Ӑ�R�[�h����͂��Ă��������B";
            //        //            dispSetStatus = DispSetStatus.Clear;
            //        //            break;
            //        //        }
            //        //    default:
            //        //        {
            //        //            message = "�w�肳�ꂽ�����ŁA���Ӑ�R�[�h�͑��݂��܂���ł����B";

            //        //            //----- h.ueno add---------- start 2008.03.31
            //        //            // ���ʃR�[�h������
            //        //            if ((this._customerCodeWork == 0)&&(this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
            //        //            {
            //        //                dispSetStatus = DispSetStatus.Back;
            //        //            }
            //        //            else
            //        //            {
            //        //                dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
            //        //            }
            //        //            //----- h.ueno add---------- end 2008.03.31

            //        //            break;
            //        //        }
            //        //}


            //        // �T�[�`���[�h����(�`�[�����ʂɂ��ω�)
            //        // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
            //        //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
            //        int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
            //        // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
            //        if (this.SlipPrtKind_tComboEditor.Value != null) searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);

            //        // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
            //        //if (searchMode == PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY)
            //        if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
            //        // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
            //        {
            //            // ���݃`�F�b�N
            //            switch (CheckCustomerCode(inParamObj, out outParamObj))
            //            {
            //                case (int)InputChkStatus.Normal:
            //                    {
            //                        dispSetStatus = DispSetStatus.Update;
            //                        break;
            //                    }
            //                case (int)InputChkStatus.NotInput:
            //                    {
            //                        message = "���Ӑ�R�[�h����͂��Ă��������B";
            //                        dispSetStatus = DispSetStatus.Clear;
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        message = "�w�肳�ꂽ�����ŁA���Ӑ�R�[�h�͑��݂��܂���ł����B";

            //                        // ���ʃR�[�h������
            //                        if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
            //                        {
            //                            dispSetStatus = DispSetStatus.Back;
            //                        }
            //                        else
            //                        {
            //                            dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
            //                        }
            //                        break;
            //                    }
            //            }
            //        }
            //        else
            //        {
            //            // ���݃`�F�b�N
            //            switch (CheckSupplierCode(inParamObj, out outParamObj))
            //            {
            //                case (int)InputChkStatus.Normal:
            //                    {
            //                        dispSetStatus = DispSetStatus.Update;
            //                        break;
            //                    }
            //                case (int)InputChkStatus.NotInput:
            //                    {
            //                        message = "�d����R�[�h����͂��Ă��������B";
            //                        dispSetStatus = DispSetStatus.Clear;
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        message = "�w�肳�ꂽ�����ŁA�d����R�[�h�͑��݂��܂���ł����B";

            //                        // ���ʃR�[�h������
            //                        if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
            //                        {
            //                            dispSetStatus = DispSetStatus.Back;
            //                        }
            //                        else
            //                        {
            //                            dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
            //                        }
            //                        break;
            //                    }
            //            }
            //        }

            //        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //        // �f�[�^�ݒ�
            //        DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

            //        if (dispSetStatus != DispSetStatus.Update)
            //        {
            //            control = this.tNedit_CustomerCode;
            //            return false;
            //        }
            //    }
            //    // ���_�R�[�h�����͂���Ă���ꍇ�́A���Ӑ悪�����͂��`�F�b�N���s��
            //    else
            //    {
            //        if (!this.tNedit_CustomerCode.Text.Equals(""))
            //        {
            //            message = "���_�R�[�h�����͂���Ă���ꍇ�A���Ӑ�R�[�h�͓��͂ł��܂���B";
            //            control = this.tNedit_CustomerCode;
            //        }
            //    }
            //}
            // 2008.06.20 30413 ���� ���_�R�[�h�`�F�b�N�Ƃ̊֘A��ǉ� <<<<<<END
			
			//------------------------------
			// �`�[����ݒ�p���[ID�`�F�b�N
			//------------------------------
			if(this.SlipPrtSetPaperId_tComboEditor.SelectedIndex == -1)
			{
				if (this.SlipPrtSetPaperId_tComboEditor.Items.Count > 0)
				{
					message = "�`�[����ݒ�p���[ID���I������Ă��܂���B";
				}
				else
				{
					message = "�`�[����ݒ�p���[ID�����݂��܂���B" +
								"\n\n�`�[����ݒ��ʂŃf�[�^��ǉ����Ă��������B";
				}
				control = this.SlipPrtSetPaperId_tComboEditor;
				return false;
			}
			//----- ueno add---------- end 2008.03.17
			
			return result;
		}

		//----- h.ueno upd ---------- start 2008.03.17
		#region SlipPrtKindVisibleChange
		/// <summary>
		/// �`�[�����ʕ\���ύX
		/// </summary>
		/// <param name="slipPrtKind">�`�[������</param>
		/// <remarks>
		/// <br>Note�@     : �`�[�����ʂ̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>			 �`�[�����ʂ̒l�ɂ���ē`�[����ݒ�p���[ID�R���{�{�b�N�X�\���𐧌䂵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private void SlipPrtKindVisibleChange(int slipPrtKind)
		{
			try
			{
				if (this._slipPrtKind_tComboEditorValue == slipPrtKind) return;

				//-------------------------------------------------
				// ���Ӑ�R�[�h����i�d����or���Ӑ�j
				// �i���Ӑ�R�[�h�͓`�[�����ʂɂ���Č��܂邽�߁j
				//-------------------------------------------------
				// ���[�N�f�[�^�ƌ��ݑI�𒆂̃f�[�^���������[�h���`�F�b�N
				int workSearch = JudgeCallCustmerGuide(this._slipPrtKind_tComboEditorValue);
				int search = JudgeCallCustmerGuide(slipPrtKind);
				
				if (workSearch != search)
				{
					this.tNedit_CustomerCode.Clear();	// ���Ӑ�R�[�h
					this.CustomerCodeNm_tEdit.Clear();	// ���Ӑ於��
				}
				
				//--------------------------
				// �`�[����ݒ�p���[ID�ݒ�
				//--------------------------
				this.SlipPrtSetPaperId_tComboEditor.BeginUpdate();

				// �R���{�{�b�N�X�A�C�e���N���A
				this.SlipPrtSetPaperId_tComboEditor.Items.Clear();	// ��x�N���A����

				// �`�[����ݒ�p���[ID�Đݒ�
				foreach (DictionaryEntry de in this._custSlipMngAcs._slipPrtSetPaperIdList)
				{
					SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;
					
					if (slipPrtSetWk.SlipPrtKind == slipPrtKind)
					{
						this.SlipPrtSetPaperId_tComboEditor.Items.Add(slipPrtSetWk.SlipPrtSetPaperId, slipPrtSetWk.SlipComment);
					}
				}

				// �擪�f�[�^��\������
				if (this.SlipPrtSetPaperId_tComboEditor.Items.Count > 0)
				{
					this.SlipPrtSetPaperId_tComboEditor.Value = this.SlipPrtSetPaperId_tComboEditor.Items[0].DataValue;
				}
				this.SlipPrtSetPaperId_tComboEditor.EndUpdate();

				// �I�������ԍ���ێ�
				this._slipPrtKind_tComboEditorValue = slipPrtKind;
			}
			catch
			{
			}
		}
		#endregion SlipPrtKindVisibleChange

		#region ���Ӑ�E�d����R�[�h�G���[�`�F�b�N����
        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���Ӑ�E�d����R�[�h�G���[�`�F�b�N����
        ///// </summary>
        ///// <param name="inParamObj">�����I�u�W�F�N�g</param>
        ///// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        ///// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        ///// <remarks>
        ///// <br>Note       : ���Ӑ�E�d����R�[�h�G���[�`�F�b�N���s���܂��B
        /////					 �����I�u�W�F�N�g:���Ӑ�R�[�h
        /////					 ���ʃI�u�W�F�N�g:���Ӑ�}�X�^�������ʃX�e�[�^�X, ���Ӑ於��</br>
        ///// <br>Programmer : 30167 ���@�O�M</br>
        ///// <br>Date       : 2008.03.17</br>
        ///// </remarks>
        //private int CheckCustomerCode(object inParamObj, out object outParamObj)
        //{
        //    outParamObj = null;
        //    ArrayList outParamList = new ArrayList();
        //    int ret = (int)InputChkStatus.NotInput;
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

        //    try
        //    {
        //        //------------------
        //        // �K�{���̓`�F�b�N
        //        //------------------
        //        if (inParamObj == null) return ret;
        //        if ((inParamObj is int) == false) return ret;
        //        if ((int)inParamObj == 0) return ret;

        //        //--------------
        //        // ���݃`�F�b�N
        //        //--------------
        //        CustomerInfo customerInfo = null;

        //        this.Cursor = Cursors.WaitCursor;
        //        ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
        //        this.Cursor = Cursors.Default;

        //        outParamList.Add(status);	// ���Ӑ�}�X�^�X�e�[�^�X�ݒ�

        //        // ���̓f�[�^����
        //        if (customerInfo != null)
        //        {
        //            //----------------------------------------
        //            // �`�[�����ʂɂ���ē��Ӑ�A�d���攻��
        //            //----------------------------------------
        //            int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;	// ���Ӑ�ݒ�
					
        //            // �`�[�����ʂɂ���ČĂяo���𕪂���
        //            if (this.SlipPrtKind_tComboEditor.Value != null)
        //            {
        //                // ���Ӑ�K�C�h�Ăяo������
        //                searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
        //            }
					
        //            // ���Ӑ惂�[�h�̏ꍇ
        //            if (searchMode == SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY)
        //            {
        //                // �I���f�[�^�����Ӑ�łȂ��ꍇ
        //                if (customerInfo.IsCustomer == false)
        //                {
        //                    TMsgDisp.Show(
        //                            this, 													// �e�E�B���h�E�t�H�[��
        //                            emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
        //                            this.Name,												// �A�Z���u��ID
        //                            "���Ӑ�f�[�^����͂��Ă��������B",						// �\�����郁�b�Z�[�W
        //                            0,														// �X�e�[�^�X�l
        //                            MessageBoxButtons.OK);									// �\������{�^��

        //                    ret = (int)InputChkStatus.Different;

        //                    return ret;
        //                }
        //            }
        //            // �d���惂�[�h�ŃK�C�h���N�������ꍇ
        //            else
        //            {
        //                // �I���f�[�^���d����łȂ��ꍇ
        //                if (customerInfo.IsSupplier == false)
        //                {
        //                    TMsgDisp.Show(
        //                            this, 													// �e�E�B���h�E�t�H�[��
        //                            emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
        //                            this.Name,												// �A�Z���u��ID
        //                            "�d����f�[�^����͂��Ă��������B",							// �\�����郁�b�Z�[�W
        //                            0,														// �X�e�[�^�X�l
        //                            MessageBoxButtons.OK);									// �\������{�^��
							
        //                    ret = (int)InputChkStatus.Different;

        //                    return ret;
        //                }
        //            }
					
        //            ret = (int)InputChkStatus.Normal;
        //            outParamList.Add(customerInfo.CustomerSnm);	// ���Ӑ旪�̐ݒ�
        //        }
        //        else
        //        {
        //            ret = (int)InputChkStatus.NotExist;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    outParamObj = outParamList;

        //    return ret;
        //}

        /// <summary>
        /// ���Ӑ�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:���� 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�G���[�`�F�b�N���s���܂��B</br>
        ///	<br>			 �����I�u�W�F�N�g:���Ӑ�R�[�h</br>
        ///	<br>			 ���ʃI�u�W�F�N�g:���Ӑ�}�X�^�������ʃX�e�[�^�X, ���Ӑ於��</br>
        /// </remarks>
        private int CheckCustomerCode(object inParamObj, out object outParamObj)
        {
            //-------------------------------------------------------------
            // �����l�ݒ�
            //-------------------------------------------------------------
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //-------------------------------------------------------------
                // ���s�`�F�b�N
                //-------------------------------------------------------------
                if (inParamObj == null) return ret;             // ���͂Ȃ�
                if ((inParamObj is int) == false) return ret;   // ���͒l�h�����ȊO
                if ((int)inParamObj == 0) return ret;           // ���͒l�[��

                //-------------------------------------------------------------
                // ���Ӑ�}�X�^�Ǎ�
                //-------------------------------------------------------------
                CustomerInfo customerInfo = null;
                this.Cursor = Cursors.WaitCursor;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���Ӑ�}�X�^�X�e�[�^�X�ݒ�

                //-------------------------------------------------------------
                // ���Ӑ���ݒ�
                //-------------------------------------------------------------
                if (customerInfo != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.CustomerSnm);	// ���Ӑ旪�̐ݒ�
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d����R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:���� 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�G���[�`�F�b�N���s���܂��B</br>
        ///	<br>			 �����I�u�W�F�N�g:�d����R�[�h</br>
        ///	<br>			 ���ʃI�u�W�F�N�g:�d����}�X�^�������ʃX�e�[�^�X, �d���於��</br>
        /// </remarks>
        private int CheckSupplierCode(object inParamObj, out object outParamObj)
        {
            //-------------------------------------------------------------
            // �����l�ݒ�
            //-------------------------------------------------------------
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //-------------------------------------------------------------
                // ���s�`�F�b�N
                //-------------------------------------------------------------
                if (inParamObj == null) return ret;             // ���͂Ȃ�
                if ((inParamObj is int) == false) return ret;   // ���͒l�h�����ȊO
                if ((int)inParamObj == 0) return ret;           // ���͒l�[��

                //-------------------------------------------------------------
                // �d����}�X�^�Ǎ�
                //-------------------------------------------------------------
                Supplier supplier = null;
                this.Cursor = Cursors.WaitCursor;
                ret = this._supplierAcs.Read(out supplier, this._enterpriseCode, (int)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);

                //-------------------------------------------------------------
                // �d������ݒ�
                //-------------------------------------------------------------
                if (supplier != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(supplier.SupplierSnm);	// �d���旪�̐ݒ�
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#endregion ���Ӑ�E�d����R�[�h�G���[�`�F�b�N����

		#region ���Ӑ�R�[�h�ݒ菈��
		/// <summary>
		/// ���Ӑ�R�[�h�ݒ菈��
		/// </summary>
		/// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
		/// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h����ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// �f�[�^�N���A
						{
							this.tNedit_CustomerCode.Clear();
							this.CustomerCodeNm_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._customerCodeWork = 0;

							// �t�H�[�J�X
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							break;
						}
					case DispSetStatus.Back:	// ���ɖ߂�
						{
							this.tNedit_CustomerCode.SetInt(this._customerCodeWork);

							// �t�H�[�J�X�ړ����Ȃ�
							canChangeFocus = false;
							break;
						}
					case DispSetStatus.Update:	// �X�V
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

									// ���݃f�[�^�ۑ�
									this._customerCodeWork = this.tNedit_CustomerCode.GetInt();

                                    // 2008.06.20 30413 ���� ���_�̓��͏��N���A��ǉ� >>>>>>START
                                    // ���_�̓��͏��̓N���A����
                                    this.tEdit_SectionCodeAllowZero.Clear();
                                    this.SectionCodeNm_tEdit.Clear();
                                    // 2008.06.20 30413 ���� ���_�̓��͏��N���A��ǉ� <<<<<<END
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion ���Ӑ�R�[�h�ݒ菈��

		#region ���Ӑ�K�C�h�Ăяo������
		/// <summary>
		/// ���Ӑ�K�C�h�Ăяo������
		/// </summary>
		/// <param name="slipPrtKind">�`�[������</param>
		/// <returns>�T�[�`���[�h�i1:�d����, 3:���Ӑ�j</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�K�C�h�̌Ăяo���i�d����or���Ӑ�j�𔻒肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private int JudgeCallCustmerGuide(int slipPrtKind)
		{
            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
            //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
            int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
			
			switch (slipPrtKind)
			{
				case 10:	// ���Ϗ�
				case 20:	// �w����
				case 21:	// ���菑
				case 30:	// �[�i��
					{
                        // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
                        //searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
                        searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
                        // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
						break;
					}
				case 40:	// �ԕi�`�[
					{
                        // 2008.06.20 30413 ���� SEARCHMODE_SUPPLIER���Ȃ��̂�SEARCHMODE_RECEIVER >>>>>>START
                        //searchMode = PMKHN04001UA.SEARCHMODE_SUPPLIER;
                        searchMode = PMKHN04005UA.SEARCHMODE_RECEIVER;
                        // 2008.06.20 30413 ���� SEARCHMODE_SUPPLIER���Ȃ��̂�SEARCHMODE_RECEIVER <<<<<<END
						break;
					}
			}
			return searchMode;
		}
		#endregion ���Ӑ�K�C�h�Ăяo������
		//----- h.ueno upd ---------- end 2008.03.17
		
		#endregion

        // --------------------------------------------------
        #region Private Methods

        /// <summary>
        /// ���_�K�C�h�N������
        /// </summary>
        /// <param name="secInfoSet">���_�}�X�^�I�u�W�F�N�g</param>
        /// <returns>����(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�̋N�����s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        private int ShowSecInfoGuide(out SecInfoSet secInfoSet)
        {
            secInfoSet = new SecInfoSet();
            return this._secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/20</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        this._sectionCodeWork = int.Parse(sectionCode);
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        #endregion
        
		// --------------------------------------------------
		#region Control Events

		/// <summary>
		/// Form.Load �C�x���g (DCKHN09130UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DCKHN09130UA_Load(object sender, EventArgs e)
		{
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;    // �ۑ��{�^��
			this.Cancel_Button.ImageList = imageList24;    // ����{�^��
			this.Revive_Button.ImageList = imageList24;    // �����{�^��
			this.Delete_Button.ImageList = imageList24;    // ���S�폜�{�^��

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;       // �ۑ��{�^��
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;      // ����{�^��
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;    // �����{�^��
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;     // ���S�폜�{�^��

            // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
        }

		/// <summary>
		/// Form.FormClosing �C�x���g (DCKHN09130UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DCKHN09130UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// GridIndex�ێ��p�o�b�t�@����������
			this._indexBuf = -2;

			if (this._canClose == false)
			{
				if (e.CloseReason == CloseReason.UserClosing)
				{
					e.Cancel = true;
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Form.VisibleChanged �C�x���g (DCKHN09130UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���̕\����Ԃ��ω��������ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DCKHN09130UA_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
			if (this._dataIndex == this._indexBuf)
			{
				return;
			}

			this.Initial_Timer.Enabled = true;
			this.ScreenClear();
		}

		/// <summary>
		/// Timer.Tick �C�x���g (Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂������ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// ��ʍč\�z����
			this.ScreenReconstruction();
		}

		//----- h.ueno add ---------- start 2008.03.31
		/// <summary>
		/// �[�����߃L�����Z����e�L�X�g�擾��������
		/// </summary>
		/// <param name="fullText">���͍ς݃e�L�X�g</param>
		/// <returns>�[�����߃L�����Z�������e�L�X�g</returns>
		/// <br>Note       : �����񂩂�[�����폜���܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.31</br>
		private static string GetZeroPadCanceledTextProc(string fullText)
		{
			if (fullText.Trim() != string.Empty)
			{
				int cnt = 0;
				string wkStr = fullText;
				
				// �擪�̃[���l�߂��폜
				while (fullText.StartsWith("0"))
				{
					fullText = fullText.Substring(1, fullText.Length - 1);
					cnt++;
				}
					
				// �I�[���[���͋��ʃR�[�h
				if (cnt == wkStr.Length)
				{
					fullText = "0";
				}
				return fullText;
			}
			else
			{
				return string.Empty;
			}
		}
		//----- h.ueno add ---------- end 2008.03.31

		/// <summary>
		/// UltraButton.Click �C�x���g (Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, EventArgs e)
		{
			// �o�^����
			if (this.SaveProc() == false)
			{
				return;
			}

			// �C�x���g����
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			// �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
			if (this._editingMode == CT_EMODE_INSERT)
			{
				// ��ʂ�������
				this.ScreenClear();

				// �V�K���[�h�ɐݒ�
				this._editingMode = CT_EMODE_INSERT;
				this.Mode_Label.Text = INSERT_MODE;

				CustSlipMng newCustSlipMng = new CustSlipMng();

				// ��ʂɓW�J
				this.CustSlipMngToScreen(newCustSlipMng);

				// �N���[���쐬
				this._custSlipMngClone = new CustSlipMng();
				this.DispToCustSlipMng(ref this._custSlipMngClone);

				// GridIndex�o�b�t�@������
				this._indexBuf = -2;

				// ��ʓ��͋��ݒ�
				this.ScreenInputPermissionControl(this._editingMode);
			}
			else
			{
				this.DialogResult = DialogResult.OK;

				// GridIndex�o�b�t�@������
				this._indexBuf = -2;

				if (this._canClose == true)
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
		/// UltraButton.Click �C�x���g (Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if ((this._editingMode != CT_EMODE_DELETE) &&
				(this._editingMode != CT_EMODE_REFER))
			{
				// ���݂̉�ʏ����擾����
				CustSlipMng compareCustSlipMng = this._custSlipMngClone.Clone();
				this.DispToCustSlipMng(ref compareCustSlipMng);

				// �ŏ��Ɏ擾������ʂƔ�r
				if (this._custSlipMngClone.Equals(compareCustSlipMng) == false)
				{
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������B
					DialogResult res = TMsgDisp.Show(
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
						null,                               // �\�����郁�b�Z�[�W
						0,                                  // �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);    // �\������{�^��
					switch (res)
					{
						case DialogResult.Yes:
							{
								if (this.SaveProc() == false)
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
								this.Cancel_Button.Focus();
								return;
							}
					}
				}
			}

			// �C�x���g����
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// GridIndex�o�b�t�@������
			this._indexBuf = -2;

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
		/// UltraButton.Click �C�x���g (Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, EventArgs e)
		{
			if (this.RevivalProc() != 0)
			{
				return;
			}

			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// GridIndex�o�b�t�@������
			this._indexBuf = -2;

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
		/// UltraButton.Click �C�x���g (Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���S�폜�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, EventArgs e)
		{
			// ���S�폜�m�F
			DialogResult result = TMsgDisp.Show(
				this,                               // �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
				CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" +
				"��낵���ł����H",                 // �\�����郁�b�Z�[�W
				0,                                  // �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,         // �\������{�^��
				MessageBoxDefaultButton.Button2);  // �����\���{�^��

			if (result == DialogResult.OK)
			{
				if (this.PhysicalDeleteProc() != 0)
				{
					return;
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				this.UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// GridIndex�o�b�t�@������
			this._indexBuf = -2;

			if (this._canClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		#endregion

		// --------------------------------------------------
		#region RetKeyControl Events

		/// <summary>
		/// ���^�[���L�[�ړ��C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���^�[���L�[�������̐�����s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			//----- ueno add---------- start 2008.03.17
			bool canChangeFocus = true;
            // 2009.02.04 30413 ���� ���g�p�̂��߁A�R�����g�� >>>>>>START
            DispSetStatus dispSetStatus = DispSetStatus.Clear;
            // 2009.02.04 30413 ���� ���g�p�̂��߁A�R�����g�� <<<<<<END
            
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			//----- ueno add---------- end 2008.03.17
			
			switch (e.PrevCtrl.Name)
			{
                // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                case "tEdit_SectionCodeAllowZero":
                    {
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;

                        if ((this.tEdit_SectionCodeAllowZero.Text == "") || (int.Parse(this.tEdit_SectionCodeAllowZero.DataText) == 0))
                        {
                            // 2009.02.04 30413 ���� �����͎��́A�K�C�h�{�^���փt�H�[�J�X���� >>>>>>START
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionCodeAllowZero.Text == "")
                                {
                                    // �����͎�
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    // "0"�܂���"00"���͎�
                                    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                                }
                            }
                            // 2009.02.04 30413 ���� �����͎��́A�K�C�h�{�^���փt�H�[�J�X���� <<<<<<END
                            
                            // �����́A�܂��̓[���̏ꍇ�͑S�Аݒ舵��
                            //this.tEdit_SectionCodeAllowZero.Text = "00";  // DEL 2009/06/01
                            this.tEdit_SectionCodeAllowZero.Text = SECTION_COMMON_CODE; // ADD 2009/06/01
                            this.SectionCodeNm_tEdit.Text = SECTION_COMMON;
                            this._sectionCodeWork = 0;
                            // 2009.02.04 30413 ���� �����͎��́A�K�C�h�{�^���փt�H�[�J�X���� >>>>>>START
                            //// 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
                            //if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            //{
                            //    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                            //}
                            //// 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END
                            // 2009.02.04 30413 ���� �����͎��́A�K�C�h�{�^���փt�H�[�J�X���� <<<<<<END
                            
                        }
                        else if (e.NextCtrl == this.Cancel_Button)
                        {
                            // �J�ڐ�̃t�H�[�J�X������{�^���̎��̓`�F�b�N���Ȃ�
                            ;
                        }
                        else
                        {
                            // �����ݒ�
                            inParamObj = this.tEdit_SectionCodeAllowZero.Text;

                            // ���_���̎擾
                            outParamObj = GetSectionName((string)inParamObj);

                            // 2009.02.04 30413 ���� ���_�̃`�F�b�N�͓o�^�ɕύX >>>>>>START
                            //// ���_���̂̑��݃`�F�b�N
                            //if (outParamObj.Equals(""))
                            //{
                            //    TMsgDisp.Show(
                            //        this, 													// �e�E�B���h�E�t�H�[��
                            //        emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
                            //        this.Name,												// �A�Z���u��ID
                            //        "�w�肳�ꂽ�����ŁA���_�R�[�h�͑��݂��܂���ł����B",	// �\�����郁�b�Z�[�W
                            //        0,														// �X�e�[�^�X�l
                            //        MessageBoxButtons.OK);									// �\������{�^��

                            //    // 2008.09.29 30413 ����  >>>>>>START
                            //    //this.tEdit_SectionCodeAllowZero.Clear();
                            //    //this.SectionCodeNm_tEdit.Clear();
                            //    this.tEdit_SectionCodeAllowZero.Text = this._sectionCodeWork.ToString("d02");                                
                            //}
                            //else
                            //{
                            //    // ���_���̐ݒ�
                            //    this.SectionCodeNm_tEdit.Text = (string)outParamObj;
                            //    // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
                            //    if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            //    {
                            //        e.NextCtrl = this.SlipPrtKind_tComboEditor;
                            //    }
                            //    // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END
                            //    //// ���Ӑ�̓��͏��̓N���A����
                            //    //this.tNedit_CustomerCode.Clear();
                            //    //this.CustomerCodeNm_tEdit.Clear();
                            //}
                            // ���_���̐ݒ�
                            this.SectionCodeNm_tEdit.Text = (string)outParamObj;
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                                }
                            }
                            // 2009.02.04 30413 ���� ���_�̃`�F�b�N�͓o�^�ɕύX <<<<<<END
                        }
                        break;
                    }
                // 2008.06.20 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
                case "tNedit_CustomerCode":
					{
                        // 2008.06.20 30413 ���� �����ݒ�ϐ��̃N���A >>>>>>START
                        // �����ݒ�N���A
                        inParamObj = null;
                        outParamObj = null;
                        // 2008.06.20 30413 ���� �����ݒ�ϐ��̃N���A <<<<<<END

						//----- ueno add ---------- start 2008.03.17
						// �u0�v�̏ꍇ�A���ʂƂ���
						if ((this.tNedit_CustomerCode.Text != "")&&(this.tNedit_CustomerCode.GetInt() == 0))
						{
                            // 2008.06.20 30413 ���� ���Ӑ於�̂ւ�"����"�̐ݒ�R�����g >>>>>>START
							//this.CustomerCodeNm_tEdit.Text = CUSTOMER_COMMON;
                            this.CustomerCodeNm_tEdit.Text = "";
                            // 2008.06.20 30413 ���� ���Ӑ於�̂ւ�"����"�̐ݒ�R�����g <<<<<<END
							this._customerCodeWork = 0;
							break;
						}
                        else if (e.NextCtrl == this.Cancel_Button)
                        {
                            // �J�ڐ�̃t�H�[�J�X������{�^���̎��̓`�F�b�N���Ȃ�
                            ;
                        }
                        else
                        {
                            // �����ݒ�
                            inParamObj = this.tNedit_CustomerCode.GetInt();

                            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// ���݃`�F�b�N
                            //switch (CheckCustomerCode(inParamObj, out outParamObj))
                            //{
                            //    case (int)InputChkStatus.Normal:
                            //        {
                            //            dispSetStatus = DispSetStatus.Update;
                            //            break;
                            //        }
                            //    case (int)InputChkStatus.NotInput:
                            //        {
                            //            dispSetStatus = DispSetStatus.Clear;
                            //            break;
                            //        }
                            //    case (int)InputChkStatus.Different:
                            //        {
                            //            // �G���[���b�Z�[�W�̓`�F�b�N�̓����ōs���Ă���

                            //            //----- h.ueno add---------- start 2008.03.31
                            //            // ���ʃR�[�h������
                            //            if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //            {
                            //                dispSetStatus = DispSetStatus.Back;
                            //            }
                            //            else
                            //            {
                            //                dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //            }
                            //            //----- h.ueno add---------- end 2008.03.31
                            //            break;
                            //        }
                            //    default:
                            //        {
                            //            TMsgDisp.Show(
                            //                    this, 													// �e�E�B���h�E�t�H�[��
                            //                    emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
                            //                    this.Name,												// �A�Z���u��ID
                            //                    "�w�肳�ꂽ�����ŁA���Ӑ�R�[�h�͑��݂��܂���ł����B",	// �\�����郁�b�Z�[�W
                            //                    0,														// �X�e�[�^�X�l
                            //                    MessageBoxButtons.OK);									// �\������{�^��

                            //            //----- h.ueno add---------- start 2008.03.31
                            //            // ���ʃR�[�h������
                            //            if ((this._customerCodeWork == 0)&&(this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //            {
                            //                dispSetStatus = DispSetStatus.Back;
                            //            }
                            //            else
                            //            {
                            //                dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //            }
                            //            //----- h.ueno add---------- end 2008.03.31

                            //            break;
                            //        }
                            //}

                            // �T�[�`���[�h����(�`�[�����ʂɂ��ω�)
                            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
                            //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
                            int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
                            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
                            if (this.SlipPrtKind_tComboEditor.Value != null) searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);

                            // 2009.02.04 30413 ���� ���Ӑ�̃`�F�b�N�͓o�^�ɕύX >>>>>>START
                            //// 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
                            ////if (searchMode == PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY)
                            //if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                            //// 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
                            //{
                            //    // ���݃`�F�b�N
                            //    switch (this.CheckCustomerCode(inParamObj, out outParamObj))
                            //    {
                            //        case (int)InputChkStatus.Normal:
                            //            {
                            //                dispSetStatus = DispSetStatus.Update;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.NotInput:
                            //            {
                            //                dispSetStatus = DispSetStatus.Clear;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.Different:
                            //            {
                            //                // �G���[���b�Z�[�W�̓`�F�b�N�̓����ōs���Ă���

                            //                // ���ʃR�[�h������
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //        default:
                            //            {
                            //                TMsgDisp.Show(
                            //                        this, 													// �e�E�B���h�E�t�H�[��
                            //                        emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
                            //                        this.Name,												// �A�Z���u��ID
                            //                        "�w�肳�ꂽ�����ŁA���Ӑ�R�[�h�͑��݂��܂���ł����B",	// �\�����郁�b�Z�[�W
                            //                        0,														// �X�e�[�^�X�l
                            //                        MessageBoxButtons.OK);									// �\������{�^��

                            //                // ���ʃR�[�h������
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //    }
                            //}
                            //else
                            //{
                            //    // ���݃`�F�b�N
                            //    switch (this.CheckSupplierCode(inParamObj, out outParamObj))
                            //    {
                            //        case (int)InputChkStatus.Normal:
                            //            {
                            //                dispSetStatus = DispSetStatus.Update;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.NotInput:
                            //            {
                            //                dispSetStatus = DispSetStatus.Clear;
                            //                break;
                            //            }
                            //        case (int)InputChkStatus.Different:
                            //            {
                            //                // �G���[���b�Z�[�W�̓`�F�b�N�̓����ōs���Ă���

                            //                // ���ʃR�[�h������
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //        default:
                            //            {
                            //                TMsgDisp.Show(
                            //                        this, 													// �e�E�B���h�E�t�H�[��
                            //                        emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
                            //                        this.Name,												// �A�Z���u��ID
                            //                        "�w�肳�ꂽ�����ŁA�d����R�[�h�͑��݂��܂���ł����B",	// �\�����郁�b�Z�[�W
                            //                        0,														// �X�e�[�^�X�l
                            //                        MessageBoxButtons.OK);									// �\������{�^��

                            //                // ���ʃR�[�h������
                            //                if ((this._customerCodeWork == 0) && (this.CustomerCodeNm_tEdit.Text == CUSTOMER_COMMON))
                            //                {
                            //                    dispSetStatus = DispSetStatus.Back;
                            //                }
                            //                else
                            //                {
                            //                    dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                            //                }
                            //                break;
                            //            }
                            //    }
                            //}
                            //// UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //// �f�[�^�ݒ�
                            //DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            //----- ueno add ---------- end 2008.03.17

                            // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
                            //if ((dispSetStatus == DispSetStatus.Update) && ((e.Key == Keys.Return) || (e.Key == Keys.Tab)))
                            //{
                            //    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                            //}
                            // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END

                            if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
                            {
                                this.CheckCustomerCode(inParamObj, out outParamObj);
                            }
                            else
                            {
                                this.CheckSupplierCode(inParamObj, out outParamObj);
                            }
                            // ���Ӑ於�̐ݒ�
                            if ((outParamObj != null) &&
                                (((ArrayList)outParamObj).Count == 2) &&
                                (((ArrayList)outParamObj)[1] is string))
                            {
                                this.CustomerCodeNm_tEdit.Text = (string)((ArrayList)outParamObj)[1];
                            }
                            else
                            {
                                this.CustomerCodeNm_tEdit.Text = "";
                            }
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.SlipPrtKind_tComboEditor;
                                }
                            }
                            // 2009.02.04 30413 ���� ���Ӑ�̃`�F�b�N�͓o�^�ɕύX <<<<<<END
                        }
                        #region del 2008.03.17
						//----- h.ueno del ---------- start 2008.03.17
						//if (CustomerCode0_tNedit.GetInt() == 0)
						//{
						//    this.uLabel_CustomerName.Text = "����"; // ����
						//    return;
						//}

						//CustomerInfo customerInfo;
						//int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, CustomerCode0_tNedit.GetInt(), true, out customerInfo);

						//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						//{
						//}
						//else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						//{
						//    TMsgDisp.Show(
						//        this,
						//        emErrorLevel.ERR_LEVEL_EXCLAMATION,
						//        this.Name,
						//        "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
						//        status,
						//        MessageBoxButtons.OK);
						//    return;
						//}
						//else
						//{
						//    TMsgDisp.Show(this,
						//                  emErrorLevel.ERR_LEVEL_STOPDISP,
						//                  this.Name,
						//                  "���Ӑ���̎擾�Ɏ��s���܂����B",
						//                  status,
						//                  MessageBoxButtons.OK);
						//    return;
						//}

						//this.CustomerCode0_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
						//this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // ����
						//----- h.ueno del ---------- end 2008.03.17
						#endregion del 2008.03.17

						break;
					}
				//----- h.ueno add---------- start 2008.03.17
				case "SlipPrtKind_tComboEditor":
					{
						if (this.SlipPrtKind_tComboEditor.Value != null)
						{
							SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
						}
						break;
					}
				//----- h.ueno add---------- end 2008.03.17
			}

			//----- h.ueno add ---------- start 2008.03.17
			// �t�H�[�J�X����
			if (canChangeFocus == false)
			{
				e.NextCtrl = e.PrevCtrl;

				// ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
				e.NextCtrl.Select();
			}
			//----- h.ueno add ---------- end 2008.03.17

            // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "SlipPrtSetPaperId_tComboEditor":      // ����ݒ�p���[ID
                case "Ok_Button":
                    {
                        if (this._dataIndex < 0)
                        {
                            if (SetKind_tComboEditor.SelectedIndex == 0)
                            {
                                if (ModeChangeProcSection())
                                {
                                    e.NextCtrl = tEdit_SectionCodeAllowZero;
                                }
                            }
                            else
                            {
                                if (ModeChangeProcCustomer())
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                        }
                        break;
                    }
            }
            // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		}

		#endregion

		private void uButton_CustomerGuide_Click(object sender, EventArgs e)
		{

			// UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���Ӑ�K�C�h
            ////----- ueno upd ---------- start 2008.03.17
            //int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;	// ���Ӑ�ݒ�

            //// �`�[�����ʂɂ���ČĂяo���𕪂���
            //if (this.SlipPrtKind_tComboEditor.Value != null)
            //{
            //    // ���Ӑ�K�C�h�Ăяo������
            //    searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
            //}
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(searchMode, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            ////----- ueno upd ---------- end 2008.03.17
			
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode.GetInt();
            // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END
                            
            // �T�[�`���[�h����(�`�[�����ʂɂ��ω�)
            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
            //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;
            int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;
            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
            if (this.SlipPrtKind_tComboEditor.Value != null) searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);

            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
            //if (searchMode == PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY)
            if (searchMode == PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY)
            // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
            {
                //-----------------------------------------
                // ���Ӑ�
                //-----------------------------------------
                // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
                //PMKHN04001UA customerSearchForm = new PMKHN04001UA(searchMode, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
                //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END
                customerSearchForm.ShowDialog(this);
            }
            else
            {
                //-----------------------------------------
                // �d����
                //-----------------------------------------
                Supplier supplier;
                this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                this.SupplierSearchForm_SupplierSelect(supplier);
            }
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode.GetInt())) && (this.tNedit_CustomerCode.Text != "") 
                && (this.CustomerCodeNm_tEdit.Text != ""))
            {
                // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.09.22 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END
        }

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>���Ӑ�I���������C�x���g</summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;

        //    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        //----- ueno add ---------- start 2008.03.17
        //        //--------------------------
        //        // ���Ӑ�K�C�h�Ăяo������
        //        //--------------------------
        //        int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;	// ���Ӑ�ݒ�

        //        // �`�[�����ʂɂ���ČĂяo���𕪂���
        //        if (this.SlipPrtKind_tComboEditor.Value != null)
        //        {
        //            // ���Ӑ�K�C�h�Ăяo������
        //            searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
        //        }

        //        // ���Ӑ惂�[�h�ŃK�C�h���N�������ꍇ
        //        if (searchMode == SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY)
        //        {
        //            // �I���f�[�^�����Ӑ�łȂ��ꍇ
        //            if (customerInfo.IsCustomer == false)
        //            {
        //                // �G���[
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                    this.Name,
        //                    "���Ӑ�f�[�^�ł͂���܂���B",
        //                    status,
        //                    MessageBoxButtons.OK);
						
        //                return;
        //            }
        //        }
        //        // �d���惂�[�h�ŃK�C�h���N�������ꍇ
        //        else
        //        {
        //            // �I���f�[�^���d����łȂ��ꍇ
        //            if (customerInfo.IsSupplier == false)
        //            {
        //                // �G���[
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                    this.Name,
        //                    "�d����f�[�^�ł͂���܂���B",
        //                    status,
        //                    MessageBoxButtons.OK);
						
        //                return;
        //            }
        //        }
        //        //----- ueno add ---------- end 2008.03.17
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      "���Ӑ���̎擾�Ɏ��s���܂����B",
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    //----- h.ueno upd ---------- start 2008.03.17
        //    this.CustomerCode_tNedit.SetInt(customerInfo.CustomerCode);
        //    this.CustomerCodeNm_tEdit.Text = customerInfo.CustomerSnm;  // ����
        //    this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
        //    //----- h.ueno upd ---------- end 2008.03.17
        //}

        ///// <summary>���Ӑ�I���������C�x���g</summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //--------------------------
                // ���Ӑ�K�C�h�Ăяo������
                //--------------------------
                // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX >>>>>>START
                //int searchMode = PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY;	// ���Ӑ�ݒ�
                int searchMode = PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY;	// ���Ӑ�ݒ�
                // 2008.06.20 30413 ���� ���Ӑ�K�C�h�\���̃A�Z���u���Q�Ƃ�ύX <<<<<<END

                // �`�[�����ʂɂ���ČĂяo���𕪂���
                if (this.SlipPrtKind_tComboEditor.Value != null)
                {
                    // ���Ӑ�K�C�h�Ăяo������
                    searchMode = JudgeCallCustmerGuide((Int32)this.SlipPrtKind_tComboEditor.Value);
                }
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

                return;
            }

            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.CustomerCodeNm_tEdit.Text = customerInfo.CustomerSnm;  // ����
            this._customerCodeWork = this.tNedit_CustomerCode.GetInt();

            // 2008.06.20 30413 ���� ���_�̓��͏��̓N���A >>>>>>START
            this.tEdit_SectionCodeAllowZero.Clear();
            this.SectionCodeNm_tEdit.Clear();
            // 2008.06.20 30413 ���� ���_�̓��͏��̓N���A <<<<<<END
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d������ݒ菈��
        /// </summary>
        /// <param name="supplier">�d������</param>
        private void SupplierSearchForm_SupplierSelect(Supplier supplier)
        {
            //---------------------------------------------
            // �ݒ�`�F�b�N
            //---------------------------------------------
            if (supplier == null) return;                                           // null�̏ꍇ�A�����Ȃ�

            //---------------------------------------------
            // �d������ēǍ�
            //---------------------------------------------
            Supplier tempSupplier;
            // �d������Ǎ�
            int status = this._supplierAcs.Read(out tempSupplier, this._enterpriseCode, supplier.SupplierCd);

            //---------------------------------------------
            // �`�F�b�N����
            //---------------------------------------------
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I�������d����͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "�d������̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);
                return;
            }

            //---------------------------------------------
            // �d������ݒ�
            //---------------------------------------------
            this.tNedit_CustomerCode.SetInt(tempSupplier.SupplierCd);
            this.CustomerCodeNm_tEdit.Text = tempSupplier.SupplierSnm;  // ����
            this._customerCodeWork = this.tNedit_CustomerCode.GetInt();

        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//----- h.ueno upd ---------- start 2008.03.17
		/// <summary>
		/// SlipPrtKind_tComboEditor_SelectionChangeCommitted �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �`�[�����ʂ��ω������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.03.17</br>
		/// </remarks>
		private void SlipPrtKind_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.SlipPrtKind_tComboEditor.Value != null)
			{
				SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
			}
		}

		//----- h.ueno upd ---------- end 2008.03.17

		//----- h.ueno add ---------- start 2008.03.17
		/// <summary>
		/// CustomerCode_tNedit_Leave �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X���������Ƃ��ɔ���</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.03.28</br>
		/// </remarks>
		private void CustomerCode_tNedit_Leave(object sender, EventArgs e)
		{
			// ���Ӑ�R�[�h���󔒂Ȃ�Ή������Ȃ�
			if (this.tNedit_CustomerCode.Text == "")
			{
				this.tNedit_CustomerCode.Clear();
				this.CustomerCodeNm_tEdit.Clear();
			}
		}

		//----- h.ueno add ---------- end 2008.03.17

		//----- h.ueno add ---------- start 2008.03.31
		/// <summary>
		/// CustomerCode_tNedit_BeforeEnterEditMode
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
		/// <br>Programmer  : 30167 ���@�O�M</br>
		/// <br>Date        : 2008.03.31</br>
		/// </remarks>
		private void CustomerCode_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ChangeFocus�C�x���g�ꎞ��~
			this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

			// �擪�̃[���l�߂��폜
			this.tNedit_CustomerCode.Text = GetZeroPadCanceledTextProc(this.tNedit_CustomerCode.Text);

			// ChangeFocus�C�x���g�ĊJ
			this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
		}
		//----- h.ueno add ---------- end 2008.03.31

        /// <summary>
        /// ���_�K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^���������̏������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet = null;
            int status = this.ShowSecInfoGuide(out secInfoSet);
            if (status == 0)
            {
                // �I�����������擾
                this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode;
                this.SectionCodeNm_tEdit.Text = secInfoSet.SectionGuideNm;

                // ���Ӑ�̓��͏��̓N���A����
                this.tNedit_CustomerCode.Clear();
                this.CustomerCodeNm_tEdit.Clear();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Tedit_SectionCode_Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X���������Ƃ��ɔ���</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        private void Tedit_SectionCode_Leave(object sender, EventArgs e)
        {
            // ���_�R�[�h���󔒂Ȃ�Ή������Ȃ�
            if (this.tEdit_SectionCodeAllowZero.Text.Equals(""))
            {
                this.tEdit_SectionCodeAllowZero.Clear();
                this.SectionCodeNm_tEdit.Clear();
            }
        }

        /// <summary>
        /// Tedit_SectionCode_BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.06.20</br>
        /// </remarks>
        private void Tedit_SectionCode_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // ChangeFocus�C�x���g�ꎞ��~
            this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

            // �擪�̃[���l�߂��폜
            this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text.TrimEnd());

            // ChangeFocus�C�x���g�ĊJ
            this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        }

        /// <summary>
        /// �ݒ��ʕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ݒ��ʂ̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/09/22</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = sender as TComboEditor;
            Point point = new Point();
            point.X = 3;
            point.Y = 81;

            if (tComboEditor.SelectedIndex == 0)
            {
                // ���_�P��
                this.panel_Section.Visible = true;
                this.panel_Customer.Visible = false;
                // 2009.02.04 30413 ���� ���_�P�ʂ̏ꍇ�͓��Ӑ�����N���A >>>>>>START
                // ���Ӑ�̏��N���A
                this.tNedit_CustomerCode.Clear();
                this.CustomerCodeNm_tEdit.Clear();
                // 2009.02.04 30413 ���� ���_�P�ʂ̏ꍇ�͓��Ӑ�����N���A <<<<<<END
            }
            else
            {
                // ���Ӑ�P��
                this.panel_Section.Visible = false;
                this.panel_Customer.Visible = true;
                this.panel_Customer.Location = point;
                // 2009.02.04 30413 ���� ���Ӑ�P�ʂ̏ꍇ�͋��_�����N���A >>>>>>START
                // ���_�̏��N���A
                this.tEdit_SectionCodeAllowZero.Clear();
                this.SectionCodeNm_tEdit.Clear();
                // 2009.02.04 30413 ���� ���Ӑ�P�ʂ̏ꍇ�͋��_�����N���A <<<<<<END
            }
        }

        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            string msg;
            int totalCount;
            int status = this._custSlipMngAcs.Search(out totalCount, this._enterpriseCode);
            if (status == 0)
            {
                _slipPrtKind_tComboEditorValue = -1;

                string index = (string)this.SlipPrtSetPaperId_tComboEditor.Value;
                this.SlipPrtSetPaperId_tComboEditor.Items.Clear();
                SlipPrtKind_tComboEditor_SelectionChangeCommitted(SlipPrtKind_tComboEditor, new EventArgs());
                this.SlipPrtSetPaperId_tComboEditor.Value = index;
                msg = "�ŐV�����擾���܂����B";
            }
            else
            {
                msg = "�ŐV���̎擾�Ɏ��s���܂����B";
            }

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          this.Name,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          msg, 			                        // �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/26 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����(���_��)
        /// </summary>
        private bool ModeChangeProcSection()
        {
            string msg = "���͂��ꂽ�R�[�h�̓`�[�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');
            // �`�[������
            int slipPrtKind = (int)SlipPrtKind_tComboEditor.SelectedItem.DataValue;

            for (int i = 0; i < this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_SECTIONCODE_TITLE];
                int dsSlipPrtKind = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_SLIPPRTKIND_TITLE];
                int dsCustomerCode = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (slipPrtKind == dsSlipPrtKind) &&
                    (dsCustomerCode == 0))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓`�[�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A�`�[�����ʂ̃N���A
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionCodeNm_tEdit.Clear();
                        this._slipPrtKind_tComboEditorValue = -1;
                        SlipPrtKind_tComboEditor.SelectedIndex = 0;
                        SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                        return true;
                    }

                    //if (sectionCd == "00")    // DEL 2009/06/01
                    if (sectionCd == SECTION_COMMON_CODE)   // ADD 2009/06/01
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̓`�[�ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
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
                                // ���_�R�[�h�A�`�[�����ʂ̃N���A
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionCodeNm_tEdit.Clear();
                                this._slipPrtKind_tComboEditorValue = -1;
                                SlipPrtKind_tComboEditor.SelectedIndex = 0;
                                SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���[�h�ύX����(���Ӑ��)
        /// </summary>
        private bool ModeChangeProcCustomer()
        {
            // ���Ӑ�R�[�h
            int customerCode = tNedit_CustomerCode.GetInt();
            // �`�[������
            int slipPrtKind = (int)SlipPrtKind_tComboEditor.SelectedItem.DataValue;

            for (int i = 0; i < this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCustomerCode = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_CUSTOMERCODE_TITLE];
                int dsSlipPrtKind = (int)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_SLIPPRTKIND_TITLE];
                if ((customerCode == dsCustomerCode) &&
                    (slipPrtKind == dsSlipPrtKind))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._custSlipMngAcs.BindDataSet.Tables[CustSlipMngAcs.TBL_CUSTSLIPMNG_TITLE].DefaultView[i][CustSlipMngAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓`�[�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ӑ�R�[�h�A�`�[�����ʂ̃N���A
                        tNedit_CustomerCode.Clear();
                        CustomerCodeNm_tEdit.Clear();
                        this._slipPrtKind_tComboEditorValue = -1;
                        SlipPrtKind_tComboEditor.SelectedIndex = 0;
                        SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̓`�[�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // ���Ӑ�R�[�h�A�`�[�����ʂ̃N���A
                                tNedit_CustomerCode.Clear();
                                CustomerCodeNm_tEdit.Clear();
                                this._slipPrtKind_tComboEditorValue = -1;
                                SlipPrtKind_tComboEditor.SelectedIndex = 0;
                                SlipPrtKindVisibleChange((Int32)this.SlipPrtKind_tComboEditor.Value);
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}