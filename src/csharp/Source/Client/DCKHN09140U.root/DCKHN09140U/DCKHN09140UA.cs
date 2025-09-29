//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�}�X�^(�ϓ����)
// �v���O�����T�v   : ���Ӑ�(�ϓ����)�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2008/09/16  �C�����e : ���Ӑ�R�[�h�̕\��������(�R���g���[������XML�ɍ��킹�C��)
//                                : ��ʖ���"���Ӑ�}�X�^(�ϓ����)"�ɕύX 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �s�V �m��
// �C �� ��  2008/10/06  �C�����e : �o�O�C���A��ʃ��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30307 �Ɠc �M�u
// �C �� ��  2008/11/20  �C�����e : �q�̓��Ӑ�Łu�^�M�Ǘ��F����v�̏ꍇ�͐ݒ�Ƃ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30307 �Ɠc �M�u
// �C �� ��  2008/12/03  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30307 �Ɠc �M�u
// �C �� ��  2008/12/10  �C�����e : �}�E�X�œo�^���A���Ӑ�̘_���폜�`�F�b�N���s���Ȃ��o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30307 �Ɠc �M�u
// �C �� ��  2008/12/25  �C�����e : �q�̓��Ӑ�͓o�^�A�X�V�s�Ƃ���(11/20�̏C���͊ԈႢ)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30307 �Ɠc �M�u
// �C �� ��  2009/01/23  �C�����e : �s��Ή�[9199]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �C �� ��  2009/02/10  �C�����e : �s��Ή�[11288] �^�M�z>0�̏ꍇ�̂݁A�^�M�z�ƌx���^�M�z�̃`�F�b�N���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/04/13  �C�����e : Mantis�y13175�z�^�M�z=0�̏ꍇ���G���[�`�F�b�N���s���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/04/14  �C�����e : Mantis�y13175�z��L�̏C����2009/02/10���_�̃`�F�b�N�ɖ߂�
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
	/// ���Ӑ�}�X�^(�ϓ����)�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̐ݒ���s���܂��B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.09.18</br>
    /// <br>Update Note: 2008.09.16 30452 ��� �r��</br>
    /// <br>             �E���Ӑ�R�[�h�̕\��������(�R���g���[������XML�ɍ��킹�C��)</br>
    /// <br>             �E��ʖ���"���Ӑ�}�X�^(�ϓ����)"�ɕύX</br>
    /// <br>UpdateNote : 2008/10/06 30462 �s�V �m���@�o�O�C���A��ʃ��C�A�E�g�ύX</br>
    /// <br>           : 2008/11/20       �Ɠc �M�u�@�q�̓��Ӑ�Łu�^�M�Ǘ��F����v�̏ꍇ�͐ݒ�Ƃ���</br>
    /// <br>           : 2008/12/03       �Ɠc �M�u�@�o�O�C��</br>
    /// <br>           : 2008/12/10       �Ɠc �M�u�@�}�E�X�œo�^���A���Ӑ�̘_���폜�`�F�b�N���s���Ȃ��o�O�C��</br>
    /// <br>           : 2008/12/25       �Ɠc �M�u�@�q�̓��Ӑ�͓o�^�A�X�V�s�Ƃ���(11/20�̏C���͊ԈႢ)</br>
    /// <br>           : 2009/01/23       �Ɠc �M�u�@�s��Ή�[9199]</br>
    /// <br>           : 2009/02/10       ��� �r���@�s��Ή�[11288] �^�M�z>0�̏ꍇ�̂݁A�^�M�z�ƌx���^�M�z�̃`�F�b�N���s��</br>
    /// </remarks>
	public partial class DCKHN09140UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
        /// ���Ӑ�}�X�^(�ϓ����)�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public DCKHN09140UA()
		{
			InitializeComponent();

			// �v���p�e�B�����l
			this._canClose = false;                          // ����@�\(false�Œ�)
            this._canDelete = true;                          // �폜�@�\
			this._canLogicalDeleteDataExtraction = true;     // �_���폜�f�[�^�\���@�\
            this._canNew = true;                             // �V�K�쐬�@�\
			this._canPrint = false;                          // ����@�\
			this._canSpecificationSearch = false;            // �����w�茟���@�\
			this._defaultAutoFillToColumn = true;            // ��T�C�Y���������@�\

            this.uButton_CustomerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// ��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �C���X�^���X������
            this._customerChangeAcs = new CustomerChangeAcs();

            this._customerInfoAcs = new CustomerInfoAcs();

			// �O���b�h�I���C���f�b�N�X
			this._dataIndex                      = -1;
			this._indexBuf                       = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

        private string _enterpriseCode = "";           // ��ƃR�[�h

        private CustomerChangeAcs _customerChangeAcs = null;

        private CustomerInfoAcs _customerInfoAcs = null;

		// ���C���p�N���[���I�u�W�F�N�g
        private CustomerChange _customerChangeClone = null;

		// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int                     _dataIndex;
		private int                     _indexBuf;

		// �v���p�e�B�p
		private bool                    _canClose;
		private bool                    _canDelete;
		private bool                    _canLogicalDeleteDataExtraction;
		private bool                    _canNew;
		private bool                    _canPrint;
		private bool                    _canSpecificationSearch;
		private bool                    _defaultAutoFillToColumn;

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		// �ҏW���[�h
		private int                     _editingMode    = 0;
		private const int               CT_EMODE_INSERT = -1;           // �V�K���[�h
		private const int               CT_EMODE_UPDATE = 0;            // �X�V���[�h
		private const int               CT_EMODE_DELETE = 1;            // �폜���[�h
		private const int               CT_EMODE_REFER  = 2;            // �Q�ƃ��[�h
		private const string            INSERT_MODE     = "�V�K���[�h";
		private const string            UPDATE_MODE     = "�X�V���[�h";
		private const string            DELETE_MODE     = "�폜���[�h";
		private const string            REFER_MODE      = "�Q�ƃ��[�h";

        // ��ʃ��C�A�E�g�p�萔
        private const int               BUTTON_LOCATION1_X  = 3;        // ���S�폜�{�^���ʒuX
        private const int               BUTTON_LOCATION2_X  = 130;      // �����{�^���ʒuX
        private const int               BUTTON_LOCATION3_X  = 257;      // �ۑ��{�^���ʒuX
        private const int               BUTTON_LOCATION4_X  = 384;      // ����{�^���ʒuX
        private const int               BUTTON_LOCATION_Y   = 9;        // �{�^���ʒuY(����)

		// PG���
		private const string            CT_PGID        = "DCKHN09140U";
		private const string            CT_PGNAME      = "���Ӑ�}�X�^(�ϓ����)";
		private const string            CT_CLASSNAME   = "DCKHN09140UA";

        // Message�֘A��`
        private const string            ERR_READ_MSG   = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string            ERR_DPR_MSG    = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string            ERR_RDEL_MSG   = "�폜�Ɏ��s���܂����B";
        private const string            ERR_UPDT_MSG   = "�o�^�Ɏ��s���܂����B";
        private const string            ERR_RVV_MSG    = "�����Ɏ��s���܂����B";
        private const string            ERR_800_MSG    = "���ɑ��[�����X�V����Ă��܂��B";
        private const string            ERR_801_MSG    = "���ɑ��[�����폜����Ă��܂��B";
        private const string            SDC_RDEL_MSG   = "�}�X�^����폜����Ă��܂��B";

		#endregion

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
		private delegate void GridMethodInvoker( int rowIndex, string columnName );

		#endregion

		// --------------------------------------------------
		#region Properties

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get {
				return this._canDelete;
			}
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get {
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get {
				return this._canNew;
			}
		}

		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>������\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get {
				return this._canPrint;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanSpecificationSearch
		{
			get {
				return this._canSpecificationSearch;
			}
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get {
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
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet	= this._customerChangeAcs.BindDataSet;
            tableName = CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE;
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
            appearanceTable.Add(CustomerChangeAcs.COL_DELETEDATE_TITLE, 
                new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) );
            // ���Ӑ�R�[�h
            //appearanceTable.Add(CustomerChangeAcs.COL_CUSTOMERCODE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)); // DEL 2008/10/06
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTOMERCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00000000", Color.Black)); // ADD 2008/10/06
            // ���Ӑ於��
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTOMERSNM_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // �^�M�z
            // DEL 2008/10/06 �s��Ή�[6231]��
            //appearanceTable.Add(CustomerChangeAcs.COL_CREDITMONEY_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ---ADD 2008/10/06 �s��Ή�[6231] ------------------------------------------->>>>>
            appearanceTable.Add(CustomerChangeAcs.COL_CREDITMONEY_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#,##0", Color.Black));
            // ---ADD 2008/10/06 �s��Ή�[6231] -------------------------------------------<<<<<
            
            // �x���^�M�z
            // DEL 2008/10/06 �s��Ή�[6231]��
            //appearanceTable.Add(CustomerChangeAcs.COL_WARNINGCREDITMONEY_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ---ADD 2008/10/06 �s��Ή�[6231] ------------------------------------------->>>>>
            appearanceTable.Add(CustomerChangeAcs.COL_WARNINGCREDITMONEY_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#,##0", Color.Black));
            // ---ADD 2008/10/06 �s��Ή�[6231] -------------------------------------------<<<<<
            // ���ݔ��|�c��
            // DEL 2008/10/06 �s��Ή�[6231]��
            //appearanceTable.Add(CustomerChangeAcs.COL_PRSNTACCRECBALANCE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ---ADD 2008/10/06 �s��Ή�[6231] ------------------------------------------->>>>>
            appearanceTable.Add(CustomerChangeAcs.COL_PRSNTACCRECBALANCE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#,##0", Color.Black));
            // ---ADD 2008/10/06 �s��Ή�[6231] -------------------------------------------<<<<<

            //--- DEL 2008/06/26 ---------->>>>>
            //// ���ݓ��Ӑ�`�[�ԍ�
            //appearanceTable.Add(CustomerChangeAcs.COL_PRESENTCUSTSLIPNO_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// �J�n���Ӑ�`�[�ԍ�
            //appearanceTable.Add(CustomerChangeAcs.COL_STARTCUSTSLIPNO_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// �I�����Ӑ�`�[�ԍ�
            //appearanceTable.Add(CustomerChangeAcs.COL_ENDCUSTSLIPNO_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// �ԍ�����
            //appearanceTable.Add(CustomerChangeAcs.COL_NOCHARCTERCOUNT_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //--- DEL 2008/06/26 ----------<<<<<
            // ���Ӑ�`�[�ԍ��w�b�_
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTSLIPNOHEADER_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ӑ�`�[�ԍ��t�b�^
            appearanceTable.Add(CustomerChangeAcs.COL_CUSTSLIPNOFOOTER_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // GUID
            appearanceTable.Add(CustomerChangeAcs.COL_GUID_TITLE, 
                new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            
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
		public int Search( ref int totalCount, int readCount )
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
		public int SearchNext( int readCount )
		{
			// ������
			return ( int )ConstantManagement.DB_Status.ctDB_EOF;
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
			int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;
			
			// �������s
			status = this._customerChangeAcs.SearchAll( out totalCount, this._enterpriseCode );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
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
						CT_PGNAME,                          // �v���O��������
						ctPROCNM,                           // ��������
						TMsgDisp.OPE_GET,                   // �I�y���[�V����
                        ERR_READ_MSG,                       // �\�����郁�b�Z�[�W
						status,                             // �X�e�[�^�X�l
						this._customerChangeAcs,            // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,               // �\������{�^��
						MessageBoxDefaultButton.Button1 );  // �����\���{�^��
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
			if( this.ScreenDataCheck( ref control, ref message ) == false ) {
				// ���̓`�F�b�N
				TMsgDisp.Show( 
					this,                               // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
					message,                            // �\�����郁�b�Z�[�W
					0,                                  // �X�e�[�^�X�l
					MessageBoxButtons.OK );             // �\������{�^��

				if( control != null ) {
					control.Focus();
					if( control is TEdit ) {
						( ( TEdit )control ).SelectAll();
					}
					else if( control is TNedit ) {
						( ( TNedit )control ).SelectAll();
					}
				}

				return result;
			}

            // ��ʃf�[�^�擾
            CustomerChange customerChange = new CustomerChange();
            this.DispToCustomerChange(ref customerChange);

			// �������ݏ���
			int status = 0;
			status = this._customerChangeAcs.Write( customerChange );

			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					result = true;
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// �R�[�h�d��
					TMsgDisp.Show(
						this,                           // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
						CT_PGID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                        ERR_DPR_MSG,                    // �\�����郁�b�Z�[�W
						0,                              // �X�e�[�^�X�l
						MessageBoxButtons.OK );         // �\������{�^��

                    this.tNedit_CustomerCode.Focus();
                    this.tNedit_CustomerCode.SelectAll();

					return result;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					this.ExclusiveTransaction( status, true );
					break;
				}
				default:
				{
					// �o�^���s
					TMsgDisp.Show(
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
						CT_PGNAME,                          // �v���O��������
						ctPROCNM,                           // ��������
						TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                        ERR_UPDT_MSG,                       // �\�����郁�b�Z�[�W
						status,                             // �X�e�[�^�X�l
						this._customerChangeAcs,            // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,               // �\������{�^��
						MessageBoxDefaultButton.Button1 );  // �����\���{�^��
					this.CloseForm( DialogResult.Cancel );
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

            DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];

            // �O���b�h���I������Ă��Ȃ���
            if ((this._dataIndex < 0) ||
                (this._dataIndex >= dt.Rows.Count))
            {
                return status;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE]; // GUID

            // --- ADD 2008/10/16 -------------------------------------------------------------------->>>>>
            // ���Ӑ�}�X�^�^�M�Ǘ��`�F�b�N
            int creditMngCode;
            if (this._customerChangeAcs.GetCreditMngCode(fileHeaderGuid, out creditMngCode) == false)
            {
                TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "���Ӑ���̎擾�Ɏ��s���܂����B",
                            status,
                            MessageBoxButtons.OK);
                return -1;
            }
            if (creditMngCode == 1)
            {
                TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            CT_PGID,
                            //"�^�M�Ǘ�����Ă��链�Ӑ�Ȃ̂ō폜�ł��܂���B�B",
                            "�^�M�Ǘ�����Ă��链�Ӑ�Ȃ̂ō폜�ł��܂���B",
                            0,
                            MessageBoxButtons.OK);
                return -1;
            }
            // --- ADD 2008/10/16 --------------------------------------------------------------------<<<<<

            // �_���폜���s
            status = this._customerChangeAcs.LogicalDelete(fileHeaderGuid);

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
                            CT_PGNAME,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_RDEL_MSG,                       // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._customerChangeAcs,            // �G���[�����������I�u�W�F�N�g
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

            DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
			}

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE]; // GUID

			// �_���폜�������s
            status = this._customerChangeAcs.Revival(fileHeaderGuid);

			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// �����폜
					TMsgDisp.Show( 
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
						CT_PGNAME,                          // �v���O��������
						ctPROCNM,                           // ��������
						TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                        ERR_RVV_MSG,                        // �\�����郁�b�Z�[�W
						status,                             // �X�e�[�^�X�l
						this._customerChangeAcs,            // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,               // �\������{�^��
						MessageBoxDefaultButton.Button1 );  // �����\���{�^��
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

            DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE]; // GUID

			// �����폜���s
            status = this._customerChangeAcs.Delete(fileHeaderGuid);

			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// �����폜
					TMsgDisp.Show( 
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
						CT_PGNAME,                          // �v���O��������
						ctPROCNM,                           // ��������
						TMsgDisp.OPE_DELETE,                // �I�y���[�V����
                        ERR_RDEL_MSG,                       // �\�����郁�b�Z�[�W
						status,                             // �X�e�[�^�X�l
						this._customerChangeAcs,            // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,               // �\������{�^��
						MessageBoxDefaultButton.Button1 );  // �����\���{�^��
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
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �}�X�^������ʂɓW�J���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void CustomerChangeToScreen(CustomerChange customerChange)
        {
            // �V�K���[�h�̏ꍇ
            if (this._editingMode == CT_EMODE_INSERT)
            {
                this.tNedit_CustomerCode.Clear();        // ���Ӑ�R�[�h
                this.uLabel_CustomerName.Text = "";      // ���Ӑ於��
            }
            // �V�K���[�h�ȊO�̏ꍇ
            else
            {
                // --- DEL 2008/09/16 -------------------------------->>>>>
                //this.tNedit_CustomerCode.Text = customerChange.CustomerCode.ToString(); 
                // --- DEL 2008/09/16 --------------------------------<<<<<
                // --- ADD 2008/09/16 -------------------------------->>>>>
                this.tNedit_CustomerCode.SetInt(customerChange.CustomerCode); // ���Ӑ�R�[�h
                // --- ADD 2008/09/16 --------------------------------<<<<<
                //this.uLabel_CustomerName.Text = customerChange.CustomerSnm;                              // ���Ӑ旪��  // DEL 2008/06/23
                this.uLabel_CustomerName.Text = GetCustomerName(customerChange.CustomerCode);              // ���Ӑ旪��  // ADD 2008/06/23
            }
            this.CreditMoney_tNedit.Text = customerChange.CreditMoney.ToString("#,##0");                   // �^�M�z
            this.WarningCreditMoney_tNedit.Text = customerChange.WarningCreditMoney.ToString("#,##0");     // �x���^�M�z
            this.PrsntAccRecBalance_tNedit.Text = customerChange.PrsntAccRecBalance.ToString("#,##0");     // ���ݔ��|�c��
            //--- DEL 2008/06/23 ---------->>>>>
            //this.PresentCustSlipNo_tN.Text = customerChange.PresentCustSlipNo.ToString();                // ���ݓ��Ӑ�`�[�ԍ�
            //this.StartCustSlipNo_tN.Text = customerChange.StartCustSlipNo.ToString();                    // �J�n���Ӑ�`�[�ԍ�
            //this.EndCustSlipNo_tN.Text = customerChange.EndCustSlipNo.ToString();                        // �I�����Ӑ�`�[�ԍ�
            //this.NoCharcterCount_tNedit.Text = customerChange.NoCharcterCount.ToString();                // �ԍ�����
            //this.CustSlipNoHeader_tEdit.Text = customerChange.CustSlipNoHeader;                          // ���Ӑ�`�[�ԍ��w�b�_
            //this.CustSlipNoFooter_tEdit.Text = customerChange.CustSlipNoFooter;                          // ���Ӑ�`�[�ԍ��t�b�^
            //--- DEL 2008/06/23 ----------<<<<<
        }
        
		/// <summary>
		/// ��ʃf�[�^�擾����
		/// </summary>
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʃf�[�^�̎擾���s���܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DispToCustomerChange(ref CustomerChange customerChange)
        {
            // �X�V���[�h�̏ꍇ
            if (this._editingMode == CT_EMODE_UPDATE)
            {
                // Guid
                DataTable dt = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE];
                customerChange.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][CustomerChangeAcs.COL_GUID_TITLE];
            }

            // ��ƃR�[�h
            customerChange.EnterpriseCode = this._enterpriseCode;
            // ���Ӑ�R�[�h
            customerChange.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // ���Ӑ於��
            //customerChange.CustomerSnm = this.uLabel_CustomerName.Text;       // DEL 2008/06/23
            // �^�M�z
            customerChange.CreditMoney = this.CreditMoney_tNedit.GetInt();
            // �x���^�M�z
            customerChange.WarningCreditMoney = this.WarningCreditMoney_tNedit.GetInt();
            // ���ݔ��|�c��
            customerChange.PrsntAccRecBalance = this.PrsntAccRecBalance_tNedit.GetInt();
            //--- DEL 2008/06/23 ---------->>>>>
            //// ���ݓ��Ӑ�`�[�ԍ�
            //customerChange.PresentCustSlipNo = this.PresentCustSlipNo_tN.GetInt();
            //// �J�n���Ӑ�`�[�ԍ�
            //customerChange.StartCustSlipNo = this.StartCustSlipNo_tN.GetInt();
            //// �I�����Ӑ�`�[�ԍ�
            //customerChange.EndCustSlipNo = this.EndCustSlipNo_tN.GetInt();
            //// �ԍ�����
            //customerChange.NoCharcterCount = this.NoCharcterCount_tNedit.GetInt();
            //// ���Ӑ�`�[�ԍ��w�b�_
            //customerChange.CustSlipNoHeader = this.CustSlipNoHeader_tEdit.Text;
            //// ���Ӑ�`�[�ԍ��t�b�^
            //customerChange.CustSlipNoFooter = this.CustSlipNoFooter_tEdit.Text;
            //--- DEL 2008/06/23 ----------<<<<<
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
            this.tNedit_CustomerCode.Clear();                     // ���Ӑ�
            //this.CustSlipNoFooter_tEdit.Clear();                 // ���[ID        // DEL 2008/06/23
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
            CustomerChange customerChange = new CustomerChange();

			// �V�K�̎�
            if (this._dataIndex < 0)
            {
                // �V�K���[�h�ɐݒ�
                this._editingMode = CT_EMODE_INSERT;
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʂɓW�J
                this.CustomerChangeToScreen(customerChange);

                // �N���[���쐬
                this._customerChangeClone = new CustomerChange();
                this.DispToCustomerChange(ref this._customerChangeClone);

                // ��ʓ��͋�����ݒ�
                this.ScreenInputPermissionControl(this._editingMode);

                //--- ADD 2008/06/24 ---------->>>>>
                this.Enabled = true;        

                this.tNedit_CustomerCode.Focus();
                this.tNedit_CustomerCode.SelectAll();
                //--- ADD 2008/06/24 ----------<<<<<
            }
            else
            {
                // �t���[���őI������Ă��郌�R�[�h�̃I�u�W�F�N�g���擾
                DataRowView dr = this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView[this._dataIndex];

                if ((string)dr[CustomerChangeAcs.COL_DELETEDATE_TITLE] != "") // �폜��
                {
                    customerChange.LogicalDeleteCode = 1;
                }

                customerChange.CustomerCode = (Int32)dr[CustomerChangeAcs.COL_CUSTOMERCODE_TITLE];    �@�@�@�@�@ // ���Ӑ�R�[�h
                //customerChange.CustomerSnm = (string)dr[CustomerChangeAcs.COL_CUSTOMERSNM_TITLE];   �@�@�@�@�@ // ���Ӑ旪��        // DEL 2008/06/23
                customerChange.CreditMoney = (long)dr[CustomerChangeAcs.COL_CREDITMONEY_TITLE];     �@�@�@�@�@�@ // �^�M�z
                customerChange.WarningCreditMoney = (long)dr[CustomerChangeAcs.COL_WARNINGCREDITMONEY_TITLE];    // �x���^�M�z
                customerChange.PrsntAccRecBalance = (long)dr[CustomerChangeAcs.COL_PRSNTACCRECBALANCE_TITLE];    // ���ݔ��|�c��
                //--- DEL 2008/06/24 ---------->>>>>
                //customerChange.PresentCustSlipNo = (long)dr[CustomerChangeAcs.COL_PRESENTCUSTSLIPNO_TITLE];      // ���ݓ��Ӑ�`�[�ԍ�
                //customerChange.StartCustSlipNo = (long)dr[CustomerChangeAcs.COL_STARTCUSTSLIPNO_TITLE];          // �J�n���Ӑ�`�[�ԍ�
                //customerChange.EndCustSlipNo = (long)dr[CustomerChangeAcs.COL_ENDCUSTSLIPNO_TITLE];              // �I�����Ӑ�`�[�ԍ�
                //customerChange.NoCharcterCount = (Int32)dr[CustomerChangeAcs.COL_NOCHARCTERCOUNT_TITLE];         // �ԍ�����
                //customerChange.CustSlipNoHeader = (string)dr[CustomerChangeAcs.COL_CUSTSLIPNOHEADER_TITLE];      // ���Ӑ�`�[�ԍ��w�b�_
                //customerChange.CustSlipNoFooter = (string)dr[CustomerChangeAcs.COL_CUSTSLIPNOFOOTER_TITLE];      // ���Ӑ�`�[�ԍ��t�b�^
                //--- DEL 2008/06/24 ----------<<<<<

                // �X�V���[�h
                if (customerChange.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h�ɐݒ�
                    this._editingMode = CT_EMODE_UPDATE;
                    this.Mode_Label.Text = UPDATE_MODE;

                    CustomerInfo customerInfo;
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerChange.CustomerCode, true, out customerInfo);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �e���𔻒肵�A�q�̏ꍇ�͗^�M�z�E�x���^�M�z�E���ݔ��|�c���͓��͕s��
                        if (customerInfo.ClaimCode != customerChange.CustomerCode)
                        {
                            /* --- DEL 2008/12/25 �s��Ή�[9454] ---------------------------->>>>>
                            // �q�̏ꍇ�A�^�M�Ǘ��u���Ȃ��v���̂ݓ��͕s��
                            if (customerInfo.CreditMngCode == 0)                    //ADD 2008/11/20
                            {                                                       //ADD 2008/11/20
                                this.CreditMoney_tNedit.Enabled = false;
                                this.WarningCreditMoney_tNedit.Enabled = false;
                                this.PrsntAccRecBalance_tNedit.Enabled = false;
                            }                                                       //ADD 2008/11/20
                            else                                                    //ADD 2008/11/20
                            {                                                       //ADD 2008/11/20
                                this.CreditMoney_tNedit.Enabled = true;             //ADD 2008/11/20
                                this.WarningCreditMoney_tNedit.Enabled = true;      //ADD 2008/11/20
                                this.PrsntAccRecBalance_tNedit.Enabled = true;      //ADD 2008/11/20
                            }                                                       //ADD 2008/11/20
                               --- DEL 2008/12/25 ---------------------------------------------<<<<< */
                            // --- ADD 2008/12/25 --------------------------------------------->>>>>
                            this.CreditMoney_tNedit.Enabled = false;
                            this.WarningCreditMoney_tNedit.Enabled = false;
                            this.PrsntAccRecBalance_tNedit.Enabled = false;
                            // --- ADD 2008/12/25 ---------------------------------------------<<<<<
                        }
                        else
                        {
                            this.CreditMoney_tNedit.Enabled = true;
                            this.WarningCreditMoney_tNedit.Enabled = true;
                            this.PrsntAccRecBalance_tNedit.Enabled = true;
                        }
                    }
                }
                // �폜���[�h
                else
                {
                    // �폜���[�h�ɐݒ�
                    this._editingMode = CT_EMODE_DELETE;
                    this.Mode_Label.Text = DELETE_MODE;
                }

                // ��ʂɓW�J
                this.CustomerChangeToScreen(customerChange);

                // �N���[���쐬
                this._customerChangeClone = new CustomerChange();
                this.DispToCustomerChange(ref this._customerChangeClone);

                // ��ʓ��͋�����ݒ�
                this.ScreenInputPermissionControl(this._editingMode);

                //--- ADD 2008/06/24 ---------->>>>>
                this.Enabled = true;        

                if (this._editingMode == CT_EMODE_UPDATE)
                {
                    this.CreditMoney_tNedit.Focus();
                    this.CreditMoney_tNedit.SelectAll();
                }
                else
                {
                    this.Delete_Button.Focus();
                }
                //--- ADD 2008/06/24 ----------<<<<<
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
		private void ScreenInputPermissionControl( int editingMode )
		{
			switch( editingMode ) {
				// �V�K���[�h
				case CT_EMODE_INSERT:
				{
					// �\���ݒ�
					this.Delete_Button.Visible                  = false;    // ���S�폜�{�^��
					this.Revive_Button.Visible                  = false;    // �����{�^��
					this.Ok_Button.Visible                      = true;     // �ۑ��{�^��
					this.Cancel_Button.Visible                  = true;     // ����{�^��

                    // ���͋��ݒ�
                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCode.Enabled = true;
                    // ���Ӑ�K�C�h�{�^��
                    this.uButton_CustomerGuide.Enabled = true;       
                    // �^�M�z
                    this.CreditMoney_tNedit.Enabled = true;
                    // �x���^�M�z
                    this.WarningCreditMoney_tNedit.Enabled = true;
                    // ���ݔ��|�c��
                    this.PrsntAccRecBalance_tNedit.Enabled = true;
                    //--- DEL 2008/06/23 ---------->>>>>
                    //// ���ݓ��Ӑ�`�[�ԍ�
                    //this.PresentCustSlipNo_tN.Enabled = true;
                    //// �J�n���Ӑ�`�[�ԍ�
                    //this.StartCustSlipNo_tN.Enabled = true;
                    //// �I�����Ӑ�`�[�ԍ�
                    //this.EndCustSlipNo_tN.Enabled = true;
                    //// �ԍ�����
                    //this.NoCharcterCount_tNedit.Enabled = true;
                    //// ���Ӑ�`�[�ԍ��w�b�_
                    //this.CustSlipNoHeader_tEdit.Enabled = true;
                    //// ���Ӑ�`�[�ԍ��t�b�^
                    //this.CustSlipNoFooter_tEdit.Enabled = true;
                    //--- DEL 2008/06/23 ----------<<<<<
					
					// �����t�H�[�J�X�ݒ�
                    this.tNedit_CustomerCode.Focus();
                    this.tNedit_CustomerCode.SelectAll();
					break;
				}
				// �X�V���[�h
				case CT_EMODE_UPDATE:
				{
					// �\���ݒ�
					this.Delete_Button.Visible                  = false;    // ���S�폜�{�^��
					this.Revive_Button.Visible                  = false;    // �����{�^��
					this.Ok_Button.Visible                      = true;     // �ۑ��{�^��
					this.Cancel_Button.Visible                  = true;     // ����{�^��

                    // ���͋��ݒ�
                    this.tNedit_CustomerCode.Enabled = false;         // ���Ӑ�R�[�h
                    this.uButton_CustomerGuide.Enabled = false;       // ���Ӑ�K�C�h�{�^��

                    //--- DEL 2008/06/23 ---------->>>>>
                    //// ���ݓ��Ӑ�`�[�ԍ�
                    //this.PresentCustSlipNo_tN.Enabled = true;
                    //// �J�n���Ӑ�`�[�ԍ�
                    //this.StartCustSlipNo_tN.Enabled = true;
                    //// �I�����Ӑ�`�[�ԍ�
                    //this.EndCustSlipNo_tN.Enabled = true;
                    //// �ԍ�����
                    //this.NoCharcterCount_tNedit.Enabled = true;
                    //// ���Ӑ�`�[�ԍ��w�b�_
                    //this.CustSlipNoHeader_tEdit.Enabled = true;
                    //// ���Ӑ�`�[�ԍ��t�b�^
                    //this.CustSlipNoFooter_tEdit.Enabled = true;
                    //--- DEL 2008/06/23 ----------<<<<<
                    
  					// �����t�H�[�J�X�ݒ�
                    this.CreditMoney_tNedit.Focus();
                    //this.CustSlipNoFooter_tEdit.SelectAll();      // DEL 2008/06/23
					break;
				}
				// �폜���[�h
				case CT_EMODE_DELETE:
				{
					// �\���ݒ�
					this.Ok_Button.Visible                      = false;    // �ۑ��{�^��
					this.Cancel_Button.Visible                  = true;     // ����{�^��
                    
                    this.Delete_Button.Visible                  = true;     // ���S�폜�{�^��
                    this.Revive_Button.Visible                  = true;     // �����{�^��
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu�V�t�g
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu�V�t�g

                    // ���͋��ݒ�
                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCode.Enabled = false;         
                    // ���Ӑ�K�C�h�{�^��
                    this.uButton_CustomerGuide.Enabled = false;
                    // �^�M�z
                    this.CreditMoney_tNedit.Enabled = false;
                    // �x���^�M�z
                    this.WarningCreditMoney_tNedit.Enabled = false;
                    // ���ݔ��|�c��
                    this.PrsntAccRecBalance_tNedit.Enabled = false;
                    //--- DEL 2008/06/23 ---------->>>>>
                    //// ���ݓ��Ӑ�`�[�ԍ�
                    //this.PresentCustSlipNo_tN.Enabled = false;
                    //// �J�n���Ӑ�`�[�ԍ�
                    //this.StartCustSlipNo_tN.Enabled = false;
                    //// �I�����Ӑ�`�[�ԍ�
                    //this.EndCustSlipNo_tN.Enabled = false;
                    //// �ԍ�����
                    //this.NoCharcterCount_tNedit.Enabled = false;
                    //// ���Ӑ�`�[�ԍ��w�b�_
                    //this.CustSlipNoHeader_tEdit.Enabled = false;
                    //this.CustSlipNoFooter_tEdit.Enabled = false;      // �t�b�^
                    //--- DEL 2008/06/23 ----------<<<<<
                    

					// �����t�H�[�J�X�ݒ�
					this.Delete_Button.Focus();
					break;
				}
				// �Q�ƃ��[�h
				case CT_EMODE_REFER:
				{
					// �\���ݒ�
					this.Ok_Button.Visible                      = false;    // �ۑ��{�^��
					this.Cancel_Button.Visible                  = true;     // ����{�^��
					this.Revive_Button.Visible                  = false;    // �����{�^��
					this.Delete_Button.Visible                  = false;    // ���S�폜�{�^��

					// ���͋��ݒ�
                    // ���Ӑ�R�[�h
                    this.tNedit_CustomerCode.Enabled = false;         
                    // ���Ӑ�K�C�h�{�^��
                    this.uButton_CustomerGuide.Enabled = false;
                    // �^�M�z
                    this.CreditMoney_tNedit.Enabled = false;
                    // �x���^�M�z
                    this.WarningCreditMoney_tNedit.Enabled = false;
                    // ���ݔ��|�c��
                    this.PrsntAccRecBalance_tNedit.Enabled = false;
                    //--- DEL 2008/06/23 ---------->>>>>
                    //// ���ݓ��Ӑ�`�[�ԍ�
                    //this.PresentCustSlipNo_tN.Enabled = false;
                    //// �J�n���Ӑ�`�[�ԍ�
                    //this.StartCustSlipNo_tN.Enabled = false;
                    //// �I�����Ӑ�`�[�ԍ�
                    //this.EndCustSlipNo_tN.Enabled = false;
                    //// �ԍ�����
                    //this.NoCharcterCount_tNedit.Enabled = false;
                    //// ���Ӑ�`�[�ԍ��w�b�_
                    //this.CustSlipNoHeader_tEdit.Enabled = false;
                    //this.CustSlipNoFooter_tEdit.Enabled = false;      // �t�b�^
                    //--- DEL 2008/06/23 ----------<<<<<
                    
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
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// ���[���X�V
					TMsgDisp.Show( 
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        ERR_800_MSG,                        // �\�����郁�b�Z�[�W
						0,                                  // �X�e�[�^�X�l
						MessageBoxButtons.OK );             // �\������{�^��
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// ���[���폜
					TMsgDisp.Show( 
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        ERR_801_MSG,                        // �\�����郁�b�Z�[�W
						0,                                  // �X�e�[�^�X�l
						MessageBoxButtons.OK );             // �\������{�^��
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
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
		private void CloseForm( DialogResult dialogResult )
		{
			// ��ʔ�\���C�x���g
			if ( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// GridIndex�o�b�t�@������
			this._indexBuf    = -2;
			
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if( this._canClose == true ) {
				this.Close();
			}
			else {
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
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            // ���Ӑ�R�[�h
            //if (this.tNedit_CustomerCode.Text.Trim() == "") {                                             //DEL 2008/12/03 �������y�[�X�g�����OK�ƂȂ�A0�œo�^������
            if ((this.tNedit_CustomerCode.Text.Trim() == "") || (this.tNedit_CustomerCode.GetInt() == 0))
            {  //ADD 2008/12/03
                message = this.CustomerCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.tNedit_CustomerCode;
                this.tNedit_CustomerCode.Clear();                                                           //ADD 2008/12/03
                result = false;
            }
            //--- ADD 2008/12/10 �s��Ή�[8901] �}�E�X�œo�^�N���b�N���A���Ӑ�R�[�h�_���폜�`�F�b�N���s���Ȃ���----->>>>>
            else
            {
                // ���Ӑ�R�[�h�_���폜�`�F�b�N
                CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                customerSearchPara.EnterpriseCode = this._enterpriseCode;
                customerSearchPara.CustomerCode = this.tNedit_CustomerCode.GetInt();
                int logicalDeleteCode = this._customerChangeAcs.GetCustomerLogicalDelete(customerSearchPara);                 //DEL 2008/12/25 �s��Ή�[9454]
                if (logicalDeleteCode != 0)                                                                                   //DEL 2008/12/25
                {
                    message = "�w�肵�����Ӑ�R�[�h�͑��݂��܂���B";
                    control = this.tNedit_CustomerCode;
                    this.tNedit_CustomerCode.Clear();
                    result = false;
                }
                // --- ADD 2008/12/25 �s��Ή�[9454] ---------------------------------------->>>>>
                else
                {
                    CustomerInfo customerInfo;
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, tNedit_CustomerCode.GetInt(), true, out customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �e���ǂ����𔻒�
                        if (customerInfo.ClaimCode != tNedit_CustomerCode.GetInt())
                        {
                            message = "�e�̓��Ӑ��ݒ肵�ĉ������B";

                            control = this.tNedit_CustomerCode;
                            this.tNedit_CustomerCode.Clear();
                            this.uLabel_CustomerName.Text = string.Empty;
                            return false;
                        }
                        // ---ADD 2009/01/23 �s��Ή�[9199] ----------------------------------------------------->>>>>
                        if (customerInfo.CreditMngCode == 0)
                        {
                            message = "�w�肵�����Ӑ�͗^�M�Ǘ����ݒ肳��Ă��܂���B";

                            control = this.tNedit_CustomerCode;
                            this.tNedit_CustomerCode.Clear();
                            this.uLabel_CustomerName.Text = string.Empty;
                            return false;
                        }
                        // ---ADD 2009/01/23 �s��Ή�[9199] -----------------------------------------------------<<<<<
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        message = "�w�肵�����Ӑ�R�[�h�͑��݂��܂���B";

                        control = this.tNedit_CustomerCode;
                        this.tNedit_CustomerCode.Clear();
                        this.uLabel_CustomerName.Text = string.Empty;
                        return false;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        message = "�w�肵�����Ӑ�R�[�h�͊��ɍ폜����Ă��܂��B";

                        control = this.tNedit_CustomerCode;
                        this.tNedit_CustomerCode.Clear();
                        this.uLabel_CustomerName.Text = string.Empty;
                        return false;
                    }

                }
                // --- ADD 2008/12/25 �s��Ή�[9454] ----------------------------------------<<<<<
            }
            //--- ADD 2008/12/10 �s��Ή�[8901] -----------------------------------------------------------------------<<<<<

            // �^�M�z���^�M�x���z�̓G���[�ɂ���
            //if ((this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt()) && (this.CreditMoney_tNedit.GetInt() != this.WarningCreditMoney_tNedit.GetInt())) // DEL 2009/02/10
            // DEL 2009/04/13 ------>>>
            //if ((this.CreditMoney_tNedit.GetInt() > 0)
            //    && (this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt())
            //    && (this.CreditMoney_tNedit.GetInt() != this.WarningCreditMoney_tNedit.GetInt())) // ADD 2009/02/10
            // DEL 2009/04/13 ------<<<
            // DEL 2009/04/14 ------>>>
            //// �^�M�z���^�M�x���z�̓G���[�ɂ���(�^�M�z�[����ΏۂɏC��)
            //if (this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt())     // ADD 2009/04/13             
            // DEL 2009/04/14 ------<<<
            // 2009/02/10�̃`�F�b�N�ɖ߂�
            if ((this.CreditMoney_tNedit.GetInt() > 0)
                && (this.CreditMoney_tNedit.GetInt() < this.WarningCreditMoney_tNedit.GetInt())
                && (this.CreditMoney_tNedit.GetInt() != this.WarningCreditMoney_tNedit.GetInt())) // ADD 2009/04/14
            {
                message = "�^�M�x���z���^�M�z���z���Ă��܂��B";
                control = this.CreditMoney_tNedit;
				result  = false;
            }
            //--- DEL 2008/06/23 ---------->>>>>
            //// �ԍ�����
            //if (this.NoCharcterCount_tNedit.GetInt() > 19)
            //{
            //    message = this.ultraLabel2.Text + "��19�܂ł̓��͂ɂ��Ă��������B";
            //    control = this.NoCharcterCount_tNedit;
            //    result = false;
            //}
            //// ���ݓ��ӓ`�[�ԍ�
            //if ((this.StartCustSlipNo_tN.GetInt() <= this.PresentCustSlipNo_tN.GetInt()) && (this.PresentCustSlipNo_tN.GetInt() <= this.EndCustSlipNo_tN.GetInt()))
            //{
            //    // OK
            //}
            //else
            //{
            //    message = this.ultraLabel5.Text + "��͈͓��œ��͂��Ă��������B";
            //    control = this.PresentCustSlipNo_tN;
            //    result = false;
            //}

            //// �ԍ��������O�̏ꍇ�͕s�v���ڂ̓N���A���A�����̃`�F�b�N���s��Ȃ�
            //if (this.NoCharcterCount_tNedit.GetInt() == 0)
            //{
            //    this.PresentCustSlipNo_tN.Clear();
            //    this.StartCustSlipNo_tN.Clear();
            //    this.EndCustSlipNo_tN.Clear();
            //    this.CustSlipNoHeader_tEdit.Clear();
            //    this.CustSlipNoFooter_tEdit.Clear();
            //    return result;
            //}

            //string endSlipNo = this.EndCustSlipNo_tN.GetInt().ToString();
            //string slipNoHeader = this.CustSlipNoHeader_tEdit.Text.Trim();
            //string slipNoFooter = this.CustSlipNoFooter_tEdit.Text.Trim();

            //int endSlipNoCount = endSlipNo.Length;
            //int slipNoHeaderCount = slipNoHeader.Length;
            //int slipNoFooterCount = slipNoFooter.Length;
            //int noCharcterCount = this.NoCharcterCount_tNedit.GetInt();

            //// �ԍ��������i�I���ԍ������{�w�b�_�[�����{�t�b�^�[�����j�ł��邱�Ɓ@�ԍ�������MAX19��
            //if (noCharcterCount >= endSlipNoCount + slipNoHeaderCount + slipNoFooterCount)
            //{
            //    // �������Ȃ�
            //}
            //else
            //{
            //    message = "�I���ԍ������{�w�b�_�[�����{�t�b�^�[�����͔ԍ������͈͓��œ��͂��Ă��������B";
            //    control = this.EndCustSlipNo_tN;
            //    result = false;
            //}
            //--- DEL 2008/06/23 ----------<<<<<

            return result;
		}

        #endregion

        // --------------------------------------------------
		#region Control Events

		/// <summary>
        /// Form.Load �C�x���g (DCKHN09140UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DCKHN09140UA_Load(object sender, EventArgs e)
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
        }


		/// <summary>
        /// Form.FormClosing �C�x���g (DCKHN09140UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DCKHN09140UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Form.VisibleChanged �C�x���g (DCKHN09140UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ω��������ɔ������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void DCKHN09140UA_VisibleChanged(object sender, EventArgs e)
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

            this.Enabled = false;           // ADD 2008/06/24

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
		private void Initial_Timer_Tick( object sender, EventArgs e )
		{
			this.Initial_Timer.Enabled = false;

			// ��ʍč\�z����
			this.ScreenReconstruction();
        }

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
		private void Ok_Button_Click( object sender, EventArgs e )
		{
			// �o�^����
			if( this.SaveProc() == false ) {
				return;
			}

			// �C�x���g����
			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

			// �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
			if( this._editingMode == CT_EMODE_INSERT ) {
				// ��ʂ�������
				this.ScreenClear();

				// �V�K���[�h�ɐݒ�
				this._editingMode    = CT_EMODE_INSERT;
				this.Mode_Label.Text = INSERT_MODE;

                CustomerChange newCustomerChange = new CustomerChange();

				// ��ʂɓW�J
                this.CustomerChangeToScreen(newCustomerChange);

				// �N���[���쐬
                this._customerChangeClone = new CustomerChange();
				this.DispToCustomerChange( ref this._customerChangeClone );

				// GridIndex�o�b�t�@������
				this._indexBuf    = -2;

				// ��ʓ��͋��ݒ�
                this.ScreenInputPermissionControl(this._editingMode);
			}
			else {
				this.DialogResult = DialogResult.OK;

				// GridIndex�o�b�t�@������
				this._indexBuf    = -2;

				if( this._canClose == true ) {
					this.Close();
				}
				else {
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
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if( ( this._editingMode != CT_EMODE_DELETE ) && 
				( this._editingMode != CT_EMODE_REFER  ) ) {
				// ���݂̉�ʏ����擾����
                CustomerChange compareCustomerChange = this._customerChangeClone.Clone();
                this.DispToCustomerChange(ref compareCustomerChange);

				// �ŏ��Ɏ擾������ʂƔ�r
				if( this._customerChangeClone.Equals( compareCustomerChange ) == false ) {
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������B
					DialogResult res = TMsgDisp.Show( 
						this,                               // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
						CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
						null,                               // �\�����郁�b�Z�[�W
						0,                                  // �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel );    // �\������{�^��
					switch( res ) {
						case DialogResult.Yes:
						{
							if( this.SaveProc() == false ) {
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
                            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tNedit_CustomerCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                                
							return;
						}
					}
				}
			}

			// �C�x���g����
			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.Cancel;

			// GridIndex�o�b�t�@������
			this._indexBuf    = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
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
		private void Revive_Button_Click( object sender, EventArgs e )
		{
            // --- ADD 2008/12/03 ------------------------------------------------------------------------->>>>>
            DialogResult dialogResult = TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "���ݕ\�����̓��Ӑ�ݒ�(�ϓ����)�𕜊����܂��B" + "\r\n" +
                                                    "��낵���ł����H",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button2);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            // --- ADD 2008/12/03 -------------------------------------------------------------------------<<<<<


			if( this.RevivalProc() != 0 ) {
				return;
			}

			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.OK;

			// GridIndex�o�b�t�@������
			this._indexBuf    = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
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
		private void Delete_Button_Click( object sender, EventArgs e )
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
				MessageBoxDefaultButton.Button2 );  // �����\���{�^��

			if( result == DialogResult.OK ) {
				if( this.PhysicalDeleteProc() != 0 ) {
					return;
				}
            }
            else {
				this.Delete_Button.Focus();
                return;
            }

			if( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				this.UnDisplaying( this, me );
			}

            this.DialogResult = DialogResult.OK;

			// GridIndex�o�b�t�@������
			this._indexBuf    = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
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
		private void tRetKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
		{
			if( e.PrevCtrl == null ) {
				return;
			}

            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            
            switch (e.PrevCtrl.Name)
            {

                case "tNedit_CustomerCode":
                    {
                        if (tNedit_CustomerCode.GetInt() == 0) return;

                        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                            return;
                        }
                        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                           
                        CustomerInfo customerInfo;

                        int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, tNedit_CustomerCode.GetInt(), true, out customerInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �e���𔻒肵�A�q�̏ꍇ�͗^�M�z�E�x���^�M�z�E���ݔ��|�c���͓��͕s��
                            if (customerInfo.ClaimCode != tNedit_CustomerCode.GetInt())
                            {
                                /* --- DEL 2008/12/25 �s��Ή�[9454] ------------------------------>>>>>
                                // �q�̏ꍇ�A�^�M�Ǘ��u���Ȃ��v���̂ݓ��͕s��
                                //if (customerInfo.CreditMngCode == 0)                    //ADD 2008/11/20 
                                //{                                                       //ADD 2008/11/20
                                    this.CreditMoney_tNedit.Enabled = false;
                                    this.WarningCreditMoney_tNedit.Enabled = false;
                                    this.PrsntAccRecBalance_tNedit.Enabled = false;
                                //}                                                       //ADD 2008/11/20
                                //else                                                    //ADD 2008/11/20
                                //{                                                       //ADD 2008/11/20
                                //    this.CreditMoney_tNedit.Enabled = true;             //ADD 2008/11/20
                                //    this.WarningCreditMoney_tNedit.Enabled = true;      //ADD 2008/11/20
                                //    this.PrsntAccRecBalance_tNedit.Enabled = true;      //ADD 2008/11/20
                                //}                                                       //ADD 2008/11/20
                                   --- DEL 2008/12/25 -----------------------------------------------<<<<< */
                                // --- ADD 2008/12/25 ----------------------------------------------->>>>>
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "�e�̓��Ӑ��ݒ肵�ĉ������B",
                                    status,
                                    MessageBoxButtons.OK);
                                this.tNedit_CustomerCode.Text = string.Empty;
                                this.uLabel_CustomerName.Text = string.Empty;

                                e.NextCtrl = e.PrevCtrl;
                                return;
                                // --- ADD 2008/12/25 -----------------------------------------------<<<<<
                            }
                            else
                            {
                                // ---ADD 2009/01/23 �s��Ή�[9199] ----------------------------------------------------->>>>>
                                if (customerInfo.CreditMngCode == 0)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "�w�肵�����Ӑ�͗^�M�Ǘ����ݒ肳��Ă��܂���B",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode.Text = string.Empty;
                                    this.uLabel_CustomerName.Text = string.Empty;

                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // ---ADD 2009/01/23 �s��Ή�[9199] -----------------------------------------------------<<<<<

                                this.CreditMoney_tNedit.Enabled = true;
                                this.WarningCreditMoney_tNedit.Enabled = true;
                                this.PrsntAccRecBalance_tNedit.Enabled = true;
                            }
                            this.CreditMoney_tNedit.Text = "0";
                            this.WarningCreditMoney_tNedit.Text = "0";
                            this.PrsntAccRecBalance_tNedit.Text = "0";

                            // --- ADD 2008/09/08 -------------------------------->>>>>
                            e.NextCtrl = CreditMoney_tNedit;
                            // --- ADD 2008/09/08 --------------------------------<<<<<

                            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            if (this._dataIndex < 0)
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                // --- DEL 2008/09/08 -------------------------------->>>>>
                                //"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                                // --- DEL 2008/09/08 --------------------------------<<<<<
                                // --- ADD 2008/09/08 -------------------------------->>>>>
                                "�w�肵�����Ӑ�R�[�h�͑��݂��܂���B",
                                // --- ADD 2008/09/08 --------------------------------<<<<<
                                status,
                                MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        // --- ADD 2008/09/08 -------------------------------->>>>>
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�w�肵�����Ӑ�R�[�h�͊��ɍ폜����Ă��܂��B",
                                status,
                                MessageBoxButtons.OK);
                            this.tNedit_CustomerCode.Text = string.Empty;
                            this.uLabel_CustomerName.Text = string.Empty;

                            return;
                        }
                        // --- ADD 2008/09/08 --------------------------------<<<<<
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
                        // --- DEL 2008/09/16 -------------------------------->>>>>
                        //this.tNedit_CustomerCode.Text = customerInfo.CustomerCode.ToString().Trim();
                        // --- DEL 2008/09/16 --------------------------------<<<<< 
                        // --- ADD 2008/09/16 -------------------------------->>>>>
                        this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                        // --- ADD 2008/09/16 --------------------------------<<<<<
                        this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // ����
                        break;
                    }
            }
		}

		#endregion

        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            // ---ADD 2008/12/25 �s��Ή�[9454] ------------------------------------------->>>>>
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode.Text))
            {
                return;
            }
            // ---ADD 2008/12/25 ------------------------------------------------------------<<<<<
            // ---ADD 2008/10/06 �s��Ή�[6229] ------------------------------------------->>>>>
            this.CreditMoney_tNedit.Focus();
            this.CreditMoney_tNedit.SelectAll();
            // ---ADD 2008/10/06 �s��Ή�[6229] -------------------------------------------<<<<<

            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            if (this._dataIndex < 0)
            {
                if (ModeChangeProc())
                {
                    ((Control)sender).Focus();
                }
            }
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        /// <summary>���Ӑ�I���������C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �e���𔻒肵�A�q�̏ꍇ�͗^�M�z�E�x���^�M�z�E���ݔ��|�c���͓��͕s��
                if (customerInfo.ClaimCode != customerSearchRet.CustomerCode)
                {
                    /* --- DEL 2008/12/25 �s��Ή�[9454] ------------------------------>>>>>
                    // �q�̏ꍇ�A�^�M�Ǘ��u���Ȃ��v���̂ݓ��͕s��
                    //if (customerInfo.CreditMngCode == 0)                    //ADD 2008/11/20
                    //{                                                       //ADD 2008/11/20
                        this.CreditMoney_tNedit.Enabled = false;
                        this.WarningCreditMoney_tNedit.Enabled = false;
                        this.PrsntAccRecBalance_tNedit.Enabled = false;
                    //}                                                       //ADD 2008/11/20
                    //else                                                    //ADD 2008/11/20
                    //{                                                       //ADD 2008/11/20
                    //    this.CreditMoney_tNedit.Enabled = true;             //ADD 2008/11/20
                    //    this.WarningCreditMoney_tNedit.Enabled = true;      //ADD 2008/11/20
                    //    this.PrsntAccRecBalance_tNedit.Enabled = true;      //ADD 2008/11/20
                    //}                                                       //ADD 2008/11/20
                       --- DEL 2008/12/25 -----------------------------------------------<<<<< */
                    // --- ADD 2008/12/25 ----------------------------------------------->>>>>
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�e�̓��Ӑ��ݒ肵�ĉ������B",
                        status,
                        MessageBoxButtons.OK);
                    this.tNedit_CustomerCode.Text = string.Empty;
                    this.uLabel_CustomerName.Text = string.Empty;

                    return;
                    // --- ADD 2008/12/25 -----------------------------------------------<<<<<
                }
                else
                {
                    this.CreditMoney_tNedit.Enabled = true;
                    this.WarningCreditMoney_tNedit.Enabled = true;
                    this.PrsntAccRecBalance_tNedit.Enabled = true;
                }
                this.CreditMoney_tNedit.Text = "0";
                this.WarningCreditMoney_tNedit.Text = "0";
                this.PrsntAccRecBalance_tNedit.Text = "0";
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    //"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",     // DEL 2008.08.29
                    "�����̓��Ӑ�R�[�h��ݒ肵�ĉ������B",         // ADD 2008.08.29
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

            // --- DEL 2008/09/16 -------------------------------->>>>>
            //this.tNedit_CustomerCode.Text = customerInfo.CustomerCode.ToString().Trim();
            // --- DEL 2008/09/16 --------------------------------<<<<<
            // --- ADD 2008/09/16 -------------------------------->>>>>
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            // --- ADD 2008/09/16 --------------------------------<<<<< 
            
            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm; // ����
        }

        //--- ADD 2008/06/24 ---------->>>>>
        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            int status;

            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            
            try
            {
                status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }
        //--- ADD 2008/06/24 ----------<<<<<

        // ---ADD 2008/10/06 �s��Ή�[6230] ------------------------------------------->>>>>
        /// <summary>Leave  �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �A�N�e�B�u�R���g���[���łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            if (this.tNedit_CustomerCode.Text.Trim().Length == 0)
            {
                this.uLabel_CustomerName.Text = "";
            }

        }
        // ---ADD 2008/10/06 �s��Ή�[6230] -------------------------------------------<<<<<

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���Ӑ�R�[�h
            int customerCode = tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCustomerCode = (int)this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView[i][CustomerChangeAcs.COL_CUSTOMERCODE_TITLE];
                if (customerCode == dsCustomerCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._customerChangeAcs.BindDataSet.Tables[CustomerChangeAcs.TBL_CUSTOMERCHANGE_TITLE].DefaultView[i][CustomerChangeAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓��Ӑ�ϓ����͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ӑ�R�[�h�̃N���A
                        tNedit_CustomerCode.Clear();
                        uLabel_CustomerName.Text = "";
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̓��Ӑ�ϓ���񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // ���Ӑ�R�[�h�̃N���A
                                tNedit_CustomerCode.Clear();
                                uLabel_CustomerName.Text = "";
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
	}
}