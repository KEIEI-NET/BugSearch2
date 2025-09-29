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
	/// �������i�}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �������i�}�X�^�̐ݒ���s���܂��B</br>
	/// <br>Programmer : 30416 ���� ����</br>
	/// <br>Date       : 2008.06.27</br>
    /// <br>UpdateNote : 2008/11/13 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>UpdateNote : 2009/02/05 �E �K�j�@��QID:11061�Ή�</br>
	/// </remarks>
	public partial class PMKHN09040UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
        /// �������i�}�X�^�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �������i�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>Update Note: 2008.09.25 30452 ��� �r��</br>
        /// <br>             PM.NS�Ή�(�s��Ή�)</br>
        /// <br>             �EchangeForcus�C�x���g�ǉ�</br>
        /// <br>             �E���[�J�[�K�C�h�폜</br>
        /// <br>             �E�O���b�h�ɋ��_���̒ǉ�</br>
		/// </remarks>
		public PMKHN09040UA()
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

            this.uButton_SectionGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // --- DEL 2008/09/25 -------------------------------->>>>>
            //this.uButton_MakerGuide.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // --- DEL 2008/09/25 --------------------------------<<<<<

			// ��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �C���X�^���X������
            this._isolIslandPrcAcs = new IsolIslandPrcAcs();

			// �O���b�h�I���C���f�b�N�X
			this._dataIndex                      = -1;
			this._indexBuf                       = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

        private string _enterpriseCode = "";           // ��ƃR�[�h

        private IsolIslandPrcAcs _isolIslandPrcAcs = null;

		// ���C���p�N���[���I�u�W�F�N�g
        private IsolIslandPrc _isolIslandPrcClone = null;

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
		private const string            CT_PGID        = "PMKHN09040U";
		private const string            CT_PGNAME      = "�������i�}�X�^";
		private const string            CT_CLASSNAME   = "PMKHN09040UA";

        // Message�֘A��`
        private const string            ERR_READ_MSG   = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string            ERR_DPR_MSG    = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string            ERR_RDEL_MSG   = "�폜�Ɏ��s���܂����B";
        private const string            ERR_UPDT_MSG   = "�o�^�Ɏ��s���܂����B";
        private const string            ERR_RVV_MSG    = "�����Ɏ��s���܂����B";
        private const string            ERR_800_MSG    = "���ɑ��[�����X�V����Ă��܂��B";
        private const string            ERR_801_MSG    = "���ɑ��[�����폜����Ă��܂��B";
        private const string            SDC_RDEL_MSG   = "�}�X�^����폜����Ă��܂��B";

        // �[�������敪
        /* --- DEL 2008/11/13 �\���ʒu�ύX�̈� ------------------------->>>>>
        private const string            FRACTIONPROCCD_KIND1 = "�l�̌ܓ�";
        private const string            FRACTIONPROCCD_KIND2 = "�؂�グ";
        private const string            FRACTIONPROCCD_KIND3 = "�؂�̂�";
           --- DEL 2008/11/13 ------------------------------------------<<<<< */
        // --- ADD 2008/11/13 ------------------------------------------>>>>>
        private const string FRACTIONPROCCD_KIND1 = "�؂�̂�";
        private const string FRACTIONPROCCD_KIND2 = "�l�̌ܓ�";
        private const string FRACTIONPROCCD_KIND3 = "�؂�グ";
        // --- ADD 2008/11/13 ------------------------------------------<<<<<
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
            bindDataSet = this._isolIslandPrcAcs.BindDataSet;
            tableName = IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE;
		}
        
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
        /// <br>Note       : �O���b�h�̊e��̊O�ς�ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// �폜��
            appearanceTable.Add(IsolIslandPrcAcs.COL_DELETEDATE_TITLE, 
                new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) );

            // ���_�R�[�h
            appearanceTable.Add(IsolIslandPrcAcs.COL_SECTIONCODE_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // --- ADD 2008/09/25 -------------------------------->>>>>
            // ���_����
            appearanceTable.Add(IsolIslandPrcAcs.COL_SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/09/25 --------------------------------<<<<<
            // ���[�J�[�R�[�h
            appearanceTable.Add(IsolIslandPrcAcs.COL_MAKERCODE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black)); // DEL 2008/09/24
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000", Color.Black)); // ADD 2008/09/24
            // ���[�J�[����
            appearanceTable.Add(IsolIslandPrcAcs.COL_MAKERNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ���i���
            appearanceTable.Add(IsolIslandPrcAcs.COL_UPPERLIMITPRICE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0", Color.Black));
            // ���iUP��
            appearanceTable.Add(IsolIslandPrcAcs.COL_UPRATE_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �[�������P��
            appearanceTable.Add(IsolIslandPrcAcs.COL_FRACTIONPROCUNIT_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0", Color.Black));
            // �[�������敪
            appearanceTable.Add(IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE,
                new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // GUID
            appearanceTable.Add(IsolIslandPrcAcs.COL_GUID_TITLE, 
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
		{
            const string ctPROCNM = "SearchProc";
			int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;
			
			// �������s
            status = this._isolIslandPrcAcs.SearchAll(out totalCount, this._enterpriseCode);
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
                        this._isolIslandPrcAcs,             // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private bool SaveProc()
        {
            const string ctPROCNM = "SaveProc";
            bool result = false;
            ArrayList isolIslandPrcArray = new ArrayList();

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
                    MessageBoxButtons.OK);              // �\������{�^��

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
            IsolIslandPrc isolIslandPrc = new IsolIslandPrc();
            this.DispToIsolIslandPrc(ref isolIslandPrc, 0);

            // �������ݏ���
            int status = 0;
            status = this._isolIslandPrcAcs.Write(isolIslandPrc);

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
                            MessageBoxButtons.OK);          // �\������{�^��

                        this.tEdit_SectionCode.Focus();
                        this.tEdit_SectionCode.SelectAll();

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
                            CT_PGNAME,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_UPDT_MSG,                       // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._isolIslandPrcAcs,             // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        this.CloseForm(DialogResult.Cancel);
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private int LogicalDeleteProc()
        {
            const string ctPROCNM = "LogicalDeleteProc";
            int status = 0;
            ArrayList fileHeaderGuidArray = new ArrayList();

            DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];

            // �O���b�h���I������Ă��Ȃ���
            if ((this._dataIndex < 0) ||
                (this._dataIndex >= dt.Rows.Count))
            {
                return status;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE]; // GUID


            // �_���폜���s
            status = this._isolIslandPrcAcs.LogicalDelete(fileHeaderGuid);

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
                            this._isolIslandPrcAcs,             // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private int RevivalProc()
        {
            const string ctPROCNM = "RevivalProc";
            int status = 0;
            ArrayList fileHeaderGuidArray = new ArrayList();

            DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];

            // �O���b�h���I������Ă��Ȃ���
            if ((this._indexBuf < 0) ||
                (this._indexBuf >= dt.Rows.Count))
            {
                this.CloseForm(DialogResult.Cancel);
                return -1;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE]; // GUID

            // �_���폜�������s
            status = this._isolIslandPrcAcs.Revival(fileHeaderGuid);

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
                            CT_PGNAME,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_RVV_MSG,                        // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._isolIslandPrcAcs,             // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private int PhysicalDeleteProc()
		{
			const string ctPROCNM = "PhysicalDeleteProc";
			int status = 0;

            DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE]; // GUID

            // �����폜���s
            status = this._isolIslandPrcAcs.Delete(fileHeaderGuid);

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
                        this._isolIslandPrcAcs,             // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <param name="isolIslandPrc">�������i�}�X�^�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �}�X�^������ʂɓW�J���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void IsolIslandPrcToScreen(IsolIslandPrc isolIslandPrc)
        {
            // �V�K���[�h�̏ꍇ
            if (this._editingMode == CT_EMODE_INSERT)
            {
                this.tEdit_SectionCode.Clear();        // ���_�R�[�h
                this.uLabel_SectionName.Text = "";      // ���_����
            }
            // �V�K���[�h�ȊO�̏ꍇ
            else
            {
                this.tEdit_SectionCode.Text = isolIslandPrc.SectionCode.ToString();                        // ���_�R�[�h
                this.uLabel_SectionName.Text = GetSectionName(isolIslandPrc.SectionCode.ToString());        // ���_����
                //this.tNedit_CarMakerCd.Text = isolIslandPrc.MakerCode.ToString();                            // ���[�J�[�R�[�h        //DEL 2008/11/13 3���[���l�߂̈�
                this.tNedit_CarMakerCd.Text = isolIslandPrc.MakerCode.ToString("000");                      // ���[�J�[�R�[�h           //ADD 2008/11/13
                this.uLabel_MakerName.Text = GetMakerName(isolIslandPrc.MakerCode);                         // ���[�J�[����
            }

            this.UpperLimitPrice_tNedit.SetValue(isolIslandPrc.UpperLimitPrice);                            // ���i���
            this.UpRate_tNedit.SetValue(isolIslandPrc.UpRate);                                              // ���iUP��
            this.FractionProcUnit_tNedit.SetValue(isolIslandPrc.FractionProcUnit);                          // �[�������P��
        }

		/// <summary>
		/// ��ʃf�[�^�擾����
		/// </summary>
        /// <param name="isolIslandPrc">�������i�}�X�^�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʃf�[�^�̎擾���s���܂�</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void DispToIsolIslandPrc(ref IsolIslandPrc isolIslandPrc, int getCnt)
        {
            // �X�V���[�h�̏ꍇ
            if (this._editingMode == CT_EMODE_UPDATE)
            {
                // Guid
                DataTable dt = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE];
                isolIslandPrc.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][IsolIslandPrcAcs.COL_GUID_TITLE];
            }

            // ��ƃR�[�h
            isolIslandPrc.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            isolIslandPrc.SectionCode = this.tEdit_SectionCode.Text;

            // ���[�J�[�R�[�h
            isolIslandPrc.MakerCode = IsolIslandPrcAcs.NullChgInt(this.tNedit_CarMakerCd.Text);

            // ���i���
            isolIslandPrc.UpperLimitPrice = this.UpperLimitPrice_tNedit.GetValue();
            // ���iUP��
            isolIslandPrc.UpRate = this.UpRate_tNedit.GetValue();
            // �[�������P��
            // --- CHG 2009/02/05 ��QID:11061�Ή�------------------------------------------------------>>>>>
            //isolIslandPrc.FractionProcUnit = this.FractionProcUnit_tNedit.GetValue();
            if (this.FractionProcUnit_tNedit.GetInt() != 0)
            {
                isolIslandPrc.FractionProcUnit = this.FractionProcUnit_tNedit.GetValue();
            }
            else
            {
                isolIslandPrc.FractionProcUnit = 1;
            }
            // --- CHG 2009/02/05 ��QID:11061�Ή�------------------------------------------------------<<<<<
            // �[�������敪
            //isolIslandPrc.FractionProcCd = this.FractionProcCd1_tEdittComboEditor.SelectedIndex;      //DEL 2008/11/13 �\���ʒu�ύX�̈�
            isolIslandPrc.FractionProcCd = (int)this.FractionProcCd1_tEdittComboEditor.Value;           //ADD 2008/11/13
        }

        #endregion

        // --------------------------------------------------
        #region Screen Methods
        
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��ʂ̃N���A���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void ScreenClear()
        {
            this.tEdit_SectionCode.Clear();                            // ���_�R�[�h
            this.tNedit_CarMakerCd.Clear();                              // ���[�J�[�R�[�h

            this.uLabel_SectionName.Text = "";                          // ���_����
            this.uLabel_MakerName.Text = "";                            // ���[�J�[����

            // --- CHG 2009/02/05 ��QID:11061�Ή�------------------------------------------------------>>>>>
            //this.UpperLimitPrice_tNedit.Clear();                        // ���i���
            //this.UpRate_tNedit.Clear();                                 // ���iUP��
            //this.FractionProcUnit_tNedit.Clear();                       // �[�������P��
            this.UpperLimitPrice_tNedit.SetInt(9999999);
            this.UpRate_tNedit.SetInt(100);                                 // ���iUP��
            this.FractionProcUnit_tNedit.SetInt(10);                       // �[�������P��
            // --- CHG 2009/02/05 ��QID:11061�Ή�------------------------------------------------------<<<<<
            //this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 0;   // �[�������敪       //DEL 2008/11/13 �\���ʒu�ύX�̈�
            this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 1;   // �[�������敪         //ADD 2008/11/13
        }
        
        /// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��ʂ̍č\�z�������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void ScreenReconstruction()
        {
            IsolIslandPrc isolIslandPrc = new IsolIslandPrc();

			// �V�K�̎�
            if (this._dataIndex < 0)
            {
                // �V�K���[�h�ɐݒ�
                this._editingMode = CT_EMODE_INSERT;
                this.Mode_Label.Text = INSERT_MODE;

                // --- DEL 2009/02/05 ��QID:11061�Ή�------------------------------------------------------>>>>>
                //// ��ʂɓW�J
                //this.IsolIslandPrcToScreen(isolIslandPrc);
                // --- DEL 2009/02/05 ��QID:11061�Ή�------------------------------------------------------<<<<<

                // �N���[���쐬
                this._isolIslandPrcClone = new IsolIslandPrc();
                this.DispToIsolIslandPrc(ref this._isolIslandPrcClone, 0);

                // ��ʓ��͋�����ݒ�
                this.ScreenInputPermissionControl(this._editingMode);

                this.Enabled = true;

                this.tEdit_SectionCode.Focus();
                this.tEdit_SectionCode.SelectAll();
            }
            else
            {
                // �t���[���őI������Ă��郌�R�[�h�̃I�u�W�F�N�g���擾
                DataRowView dr = this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[this._dataIndex];

                if ((string)dr[IsolIslandPrcAcs.COL_DELETEDATE_TITLE] != "") // �폜��
                {
                    isolIslandPrc.LogicalDeleteCode = 1;
                }

                isolIslandPrc.SectionCode = dr[IsolIslandPrcAcs.COL_SECTIONCODE_TITLE].ToString();    �@�@�@�@�@            // ���_�R�[�h

                isolIslandPrc.MakerCode = (int)dr[IsolIslandPrcAcs.COL_MAKERCODE_TITLE];       �@�@�@�@�@�@                 // ���[�J�[�R�[�h

                isolIslandPrc.UpperLimitPrice = (double)dr[IsolIslandPrcAcs.COL_UPPERLIMITPRICE_TITLE];�@                   // ���i���
                isolIslandPrc.UpRate = (double)dr[IsolIslandPrcAcs.COL_UPRATE_TITLE]; �@�@�@�@�@�@                          // ���iUP��
                isolIslandPrc.FractionProcUnit = (double)dr[IsolIslandPrcAcs.COL_FRACTIONPROCUNIT_TITLE];                   // �[�������P��

                //this.FractionProcCd1_tEdittComboEditor.Text = dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString();     // �[�������敪       //DEL 2008/11/13 �f�[�^���Â��ꍇ�ɒl�������ׁA�����l��\������
                // --- ADD 2008/11/13 ---------------------------------------------------------------------------------------->>>>>
                if ((string.IsNullOrEmpty(dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString())) ||
                    (dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString() == "0"))
                {
                    // �f�[�^���Â��ꍇ�A�l�������̂ŏ����l��\��                    
                    this.FractionProcCd1_tEdittComboEditor.Text = "2";
                }
                else
                {
                    this.FractionProcCd1_tEdittComboEditor.Text = dr[IsolIslandPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString();
                }
                // --- ADD 2008/11/13 ----------------------------------------------------------------------------------------<<<<<

                // �X�V���[�h
                if (isolIslandPrc.LogicalDeleteCode == 0)
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
                this.IsolIslandPrcToScreen(isolIslandPrc);

                // �N���[���쐬
                this._isolIslandPrcClone = new IsolIslandPrc();
                this.DispToIsolIslandPrc(ref this._isolIslandPrcClone, 0);

                // ��ʓ��͋�����ݒ�
                this.ScreenInputPermissionControl(this._editingMode);

                this.Enabled = true;

                if (this._editingMode == CT_EMODE_UPDATE)
                {
                    this.UpRate_tNedit.Focus();
                    this.UpRate_tNedit.SelectAll();
                }
                else
                {
                    this.Delete_Button.Focus();
                }
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
                    // ���_�R�[�h
                    this.tEdit_SectionCode.Enabled = true;
                    // ���_�K�C�h�{�^��
                    this.uButton_SectionGuide.Enabled = true;

                    // ���[�J�[�R�[�h
                    this.tNedit_CarMakerCd.Enabled = true;
                    // ���[�J�[�K�C�h�{�^��
                    //this.uButton_MakerGuide.Enabled = true; // DEL 2008/09/25
					
                    // ���i���
                    this.UpperLimitPrice_tNedit.Enabled = true;
                    // ���iUP��
                    this.UpRate_tNedit.Enabled = true;
                    // �[�������P��
                    this.FractionProcUnit_tNedit.Enabled = true;
                    // �[�������敪
                    this.FractionProcCd1_tEdittComboEditor.Enabled = true;

                    // �����t�H�[�J�X�ݒ�
                    this.tEdit_SectionCode.Focus();
                    this.tEdit_SectionCode.SelectAll();
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
                    // ���_�R�[�h
                    this.tEdit_SectionCode.Enabled = false;
                    // ���_�K�C�h�{�^��
                    this.uButton_SectionGuide.Enabled = false;

                    // ���[�J�[�R�[�h
                    this.tNedit_CarMakerCd.Enabled = false;
                    // ���[�J�[�K�C�h�{�^��
                    //this.uButton_MakerGuide.Enabled = false; // DEL 2008/09/25

                    // ���i���
                    this.UpperLimitPrice_tNedit.Enabled = false;

                    // ���iUP��
                    this.UpRate_tNedit.Enabled = true;
                    // �[�������P��
                    this.FractionProcUnit_tNedit.Enabled = true;
                    // �[�������敪
                    this.FractionProcCd1_tEdittComboEditor.Enabled = true;

  					// �����t�H�[�J�X�ݒ�
                    this.UpRate_tNedit.Focus();
                    this.UpRate_tNedit.SelectAll();
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
                    // ���_�R�[�h
                    this.tEdit_SectionCode.Enabled = false;
                    // ���_�K�C�h�{�^��
                    this.uButton_SectionGuide.Enabled = false;

                    // ���[�J�[�R�[�h
                    this.tNedit_CarMakerCd.Enabled = false;
                    // ���[�J�[�K�C�h�{�^��
                    //this.uButton_MakerGuide.Enabled = false; // DEL 2008/09/24

                    // ���i���
                    this.UpperLimitPrice_tNedit.Enabled = false;
                    // ���iUP��
                    this.UpRate_tNedit.Enabled = false;
                    // �[�������P��
                    this.FractionProcUnit_tNedit.Enabled = false;
                    // �[�������敪
                    this.FractionProcCd1_tEdittComboEditor.Enabled = false;

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
                    // ���_�R�[�h
                    this.tEdit_SectionCode.Enabled = false;
                    // ���_�K�C�h�{�^��
                    this.uButton_SectionGuide.Enabled = false;

                    // ���[�J�[�R�[�h
                    this.tNedit_CarMakerCd.Enabled = false;
                    // ���[�J�[�K�C�h�{�^��
                    //this.uButton_MakerGuide.Enabled = false; // DEL 2008/09/24

                    // ���i���
                    this.UpperLimitPrice_tNedit.Enabled = false;
                    // ���iUP��
                    this.UpRate_tNedit.Enabled = false;
                    // �[�������P��
                    this.FractionProcUnit_tNedit.Enabled = false;
                    // �[�������敪
                    this.FractionProcCd1_tEdittComboEditor.Enabled = false;
                    
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            // ���_�R�[�h
            if (this.tEdit_SectionCode.Text.Trim() == "")
            {
                message = this.SectionCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.tEdit_SectionCode;
                result = false;

                return result; // ADD 2008/09/24
            }

            // ���[�J�[�R�[�h
            if (this.tNedit_CarMakerCd.Text.Trim() == "")
            {
                message = this.MakerCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.tNedit_CarMakerCd;
                result = false;

                return result; // ADD 2008/09/24
            }
            // --- ADD 2008/09/25 -------------------------------->>>>>
            else if (this.GetMakerDataRow(this.tNedit_CarMakerCd.GetInt().ToString()) == null)
            {
                // �Y���̃��[�J�[�����݂��Ȃ��ꍇ�A�G���[
                message =  "���͂���" + this.MakerCode_Title_Label.Text + "�͑��݂��܂���B";
                control = this.tNedit_CarMakerCd;
                result = false;

                return result;
            }
            // --- ADD 2008/09/25 --------------------------------<<<<<
            // ���i���1
            if (this.UpperLimitPrice_tNedit.Text.Trim() == "")
            {
                message = this.UpperLimitPrice_Title_Label.Text + "����͂��Ă��������B";
                control = this.UpperLimitPrice_tNedit;
                result = false;

                return result; // ADD 2008/09/24
            }

            return result;
		}

        #endregion

        // --------------------------------------------------
		#region Control Events

		/// <summary>
        /// Form.Load �C�x���g (PMKHN09040UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void PMKHN09040UA_Load(object sender, EventArgs e)
        {
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;        // �ۑ��{�^��
            this.Cancel_Button.ImageList = imageList24;    // ����{�^��
            this.Revive_Button.ImageList = imageList24;    // �����{�^��
            this.Delete_Button.ImageList = imageList24;    // ���S�폜�{�^��

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;           // �ۑ��{�^��
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;      // ����{�^��
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;    // �����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;     // ���S�폜�{�^��

            // �[�������敪(No.1)
            /* --- DEL 2008/11/13 �\���ʒu�A�l�ύX�̈� ----------------------------->>>>>
            this.FractionProcCd1_tEdittComboEditor.Items.Add(0, FRACTIONPROCCD_KIND1);
            this.FractionProcCd1_tEdittComboEditor.Items.Add(0, FRACTIONPROCCD_KIND2);
            this.FractionProcCd1_tEdittComboEditor.Items.Add(0, FRACTIONPROCCD_KIND3);
            this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 0;
               --- DEL 2008/11/13 --------------------------------------------------<<<<< */
            // --- ADD 2008/11/13 -------------------------------------------------->>>>>
            this.FractionProcCd1_tEdittComboEditor.Items.Add(1, FRACTIONPROCCD_KIND1);      // �؂�̂�
            this.FractionProcCd1_tEdittComboEditor.Items.Add(2, FRACTIONPROCCD_KIND2);      // �l�̌ܓ�
            this.FractionProcCd1_tEdittComboEditor.Items.Add(3, FRACTIONPROCCD_KIND3);      // �؂�グ
            this.FractionProcCd1_tEdittComboEditor.SelectedIndex = 1;
            // --- ADD 2008/11/13 --------------------------------------------------<<<<<
        }

		/// <summary>
        /// Form.FormClosing �C�x���g (PMKHN09040UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void PMKHN09040UA_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Form.VisibleChanged �C�x���g (PMKHN09040UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ω��������ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
        private void PMKHN09040UA_VisibleChanged(object sender, EventArgs e)
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

            this.Enabled = false;

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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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

                IsolIslandPrc newIsolIslandPrc = new IsolIslandPrc();

				// ��ʂɓW�J
                this.IsolIslandPrcToScreen(newIsolIslandPrc);

				// �N���[���쐬
                this._isolIslandPrcClone = new IsolIslandPrc();
                this.DispToIsolIslandPrc(ref this._isolIslandPrcClone,0);

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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if( ( this._editingMode != CT_EMODE_DELETE ) && 
				( this._editingMode != CT_EMODE_REFER  ) ) {
				// ���݂̉�ʏ����擾����
                IsolIslandPrc compareIsolIslandPrc = this._isolIslandPrcClone.Clone();
                this.DispToIsolIslandPrc(ref compareIsolIslandPrc, 0);

				// �ŏ��Ɏ擾������ʂƔ�r
                if (this._isolIslandPrcClone.Equals(compareIsolIslandPrc) == false)
                {
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
							this.Cancel_Button.Focus();
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
		/// </remarks>
		private void Revive_Button_Click( object sender, EventArgs e )
		{
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
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

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void uButton_SelectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                secInfoAcs.ResetSectionInfo();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    this.tNedit_CarMakerCd.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.07.01</br>
        /// </remarks>
        private void uButton_MakerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerAcs makerAcs = new MakerAcs();
                MakerUMnt makerUMnt = new MakerUMnt();

                status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    this.tNedit_CarMakerCd.DataText = makerUMnt.GoodsMakerCd.ToString();
                    this.uLabel_MakerName.Text = makerUMnt.MakerName.Trim();

                    this.UpperLimitPrice_tNedit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // --- DEL 2008/09/25 -------------------------------->>>>>
        ///// <summary>
        ///// ���_�R�[�h Leave����
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���_���̕\������</br>
        ///// <br>Programmer : 30416 ���� ����</br>
        ///// <br>Date       : 2008.07.01</br>
        ///// </remarks>
        //private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        //{
        //    // ���_�R�[�h���͂���H
        //    if (this.tEdit_SectionCode.Text != "")
        //    {
        //        // ���_���̐ݒ�
        //        this.uLabel_SectionName.Text = GetSectionName(this.tEdit_SectionCode.Text.Trim());
        //    }
        //    else
        //    {
        //        // ���_���̃N���A
        //        this.uLabel_SectionName.Text = "";
        //    }
        //}

        ///// <summary>
        ///// ���[�J�[�R�[�h Leave����
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���[�J�[���̕\������</br>
        ///// <br>Programmer : 30416 ���� ����</br>
        ///// <br>Date       : 2008.07.01</br>
        ///// </remarks>
        //private void tNedit_CarMakerCd_Leave(object sender, EventArgs e)
        //{
        //    // ���[�J�[�R�[�h���͂���H
        //    if (this.tNedit_CarMakerCd.Text != "")
        //    {
        //        // ���[�J�[���̐ݒ�
        //        this.uLabel_MakerName.Text = GetMakerName(this.tNedit_CarMakerCd.GetInt());
        //    }
        //    else
        //    {
        //        // ���[�J�[���̃N���A
        //        this.uLabel_MakerName.Text = "";
        //    }
        //}
        // --- DEL 2008/09/25 --------------------------------<<<<<
		#endregion

        // --------------------------------------------------
        #region Private Methods
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
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

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;

            MakerUMnt makerUMnt = new MakerUMnt();
            MakerAcs makerAcs = new MakerAcs();

            try
            {
                status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);

                if (status == 0)
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }
        #endregion


        // --- ADD 2008/09/25 -------------------------------->>>>>
        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl.Name == "tEdit_SectionCode")
            {
                // ���͖����A�S�Ђ̏ꍇ�͏����Ȃ�
                if (this.tEdit_SectionCode.Text != "")
                {
                    bool exist = false;

                    SecInfoAcs secInfoAcs = new SecInfoAcs();
                    secInfoAcs.ResetSectionInfo();

                    foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                    {
                        if (secInfoSet.SectionCode.Trim() == this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0'))
                        {
                            // ���_���̂��Z�b�g
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                            // 2009.03.26 30413 ���� �t�H�[�J�X������C�� >>>>>>START
                            //// ���Ϗ����s�敪�Ƀt�H�[�J�X��ύX
                            //e.NextCtrl = this.tNedit_CarMakerCd;
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // ���݂���ꍇ�̓��[�J�[�R�[�h�Ƀt�H�[�J�X��ύX
                                    e.NextCtrl = this.tNedit_CarMakerCd;
                                }
                            }
                            // 2009.03.26 30413 ���� �t�H�[�J�X������C�� <<<<<<END
                            
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        // ���݂��Ȃ��ꍇ
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�w�肵�����_�R�[�h�͑��݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        // ���݂̓��͂��N���A
                        this.tEdit_SectionCode.DataText = "";
                        this.uLabel_SectionName.Text = "";

                        // 2009.03.26 30413 ���� �t�H�[�J�X������C�� >>>>>>START
                        //// ���݂��Ȃ��ꍇ�̓K�C�h�{�^���փt�H�[�J�X��ύX
                        //e.NextCtrl = this.uButton_SectionGuide;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���݂���ꍇ�̓��[�J�[�R�[�h�Ƀt�H�[�J�X��ύX
                                e.NextCtrl = this.uButton_SectionGuide;
                            }
                        }
                        // 2009.03.26 30413 ���� �t�H�[�J�X������C�� <<<<<<END
                    }
                }
                else
                {
                    // --- ADD 2008/09/30 -------------------------------->>>>>
                    // ���_���̂��N���A
                    this.uLabel_SectionName.Text = "";
                    // --- ADD 2008/09/30 --------------------------------<<<<<
                }
            }
            else if (e.PrevCtrl.Name == "tNedit_CarMakerCd")
            {
                DataRow dr = this.GetMakerDataRow(this.tNedit_CarMakerCd.GetInt().ToString());

                if (dr != null)
                {
                    // ���݂���ꍇ�A���̂��擾
                    this.uLabel_MakerName.Text = dr["MakerName"].ToString();
                }
                else
                {
                    // ���݂��Ȃ��ꍇ�N���A����
                    this.uLabel_MakerName.Text = "";
                }
            }

            // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "UpRate_tNedit":                       // ���iUP��
                case "FractionProcUnit_tNedit":             // �[�������P��
                case "FractionProcCd1_tEdittComboEditor":   // �[�������敪
                    {
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCode;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            return;
        }

        /// <summary>
        /// �w�肵�����[�J�[�R�[�h��DataRow���擾����B
        /// </summary>
        /// <returns></returns>
        private DataRow GetMakerDataRow(string makerCd)
        {
            int status;
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            Hashtable hash = new Hashtable();
            hash.Add("EnterpriseCode", this._enterpriseCode);

            DataSet ds = new DataSet();

            status = makerAcs.GetGuideData(0, hash, ref ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["GoodsMakerCd"].ToString() == makerCd)
                {
                    return ds.Tables[0].Rows[i];
                }
            }

            return null;
        }
        // --- ADD 2008/09/25 --------------------------------<<<<<

        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���_�R�[�h
            string secCd = tEdit_SectionCode.Text.TrimEnd().PadLeft(2, '0');
            // ���[�J�[�R�[�h
            int makerCd = tNedit_CarMakerCd.GetInt();
            // ������z
            double upperLimitPrice = UpperLimitPrice_tNedit.GetValue();

            for (int i = 0; i < this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_SECTIONCODE_TITLE];
                int dsMakerCd = (int)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_MAKERCODE_TITLE];
                double dsUpperLimitPrice = (double)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_UPPERLIMITPRICE_TITLE];
                if ((secCd.Equals(dsSecCd.TrimEnd())) &&
                    (makerCd == dsMakerCd) &&
                    (upperLimitPrice == dsUpperLimitPrice))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._isolIslandPrcAcs.BindDataSet.Tables[IsolIslandPrcAcs.TBL_ISOLISLANDPRC_TITLE].DefaultView[i][IsolIslandPrcAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̗������i�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���[�J�[�R�[�h�A������z�̃N���A
                        tEdit_SectionCode.Clear();
                        uLabel_SectionName.Text = "";
                        tNedit_CarMakerCd.Clear();
                        uLabel_MakerName.Text = "";
                        UpperLimitPrice_tNedit.SetInt(9999999);
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̗������i�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // ���_�R�[�h�A���[�J�[�R�[�h�A������z�̃N���A
                                tEdit_SectionCode.Clear();
                                uLabel_SectionName.Text = "";
                                tNedit_CarMakerCd.Clear();
                                uLabel_MakerName.Text = "";
                                UpperLimitPrice_tNedit.SetInt(9999999);
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