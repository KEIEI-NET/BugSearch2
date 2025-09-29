using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
	/// �摜���}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �摜���}�X�^�̐ݒ���s���܂��B</br>
	/// <br>Programmer : 22022 �i�� �m�q</br>
	/// <br>Date       : 2007.05.16</br>
    /// <br>UpdateNote : 2008/10/29 �Ɠc �M�u �o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>           : 2008/11/07           ��L�C�����ɍ�荞�񂾃o�O���C��</br>
	/// </remarks>
	public partial class MAKHN09630UA : Form, IMasterMaintenanceMultiType
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
        /// �摜���}�X�^�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �摜���}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public MAKHN09630UA()
		{
			InitializeComponent();

			// �v���p�e�B�����l
			this._canClose                          = false;    // ����@�\(false�Œ�)
            this._canDelete                         = true;     // �폜�@�\
			this._canLogicalDeleteDataExtraction    = true;     // �_���폜�f�[�^�\���@�\
            this._canNew                            = true;     // �V�K�쐬�@�\
			this._canPrint                          = false;    // ����@�\
			this._canSpecificationSearch            = false;    // �����w�茟���@�\
			this._defaultAutoFillToColumn           = true;     // ��T�C�Y���������@�\

			// ��ƃR�[�h�擾
			this._enterpriseCode                    = LoginInfoAcquisition.EnterpriseCode;

			// �C���X�^���X������
            this._imageInfoAcs                      = new ImageInfoAcs();

			// �O���b�h�I���C���f�b�N�X
			this._dataIndex                         = -1;
			this._indexBuf                          = -2;
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

        private string                  _enterpriseCode = "";           // ��ƃR�[�h

        private ImageInfoAcs            _imageInfoAcs   = null;

		// ���C���p�N���[���I�u�W�F�N�g
        private ImageInfo               _imageInfoClone = null;

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

        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

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
        private const int               BUTTON_LOCATION1_X  = 204;      // ���S�폜�{�^���ʒuX
        private const int               BUTTON_LOCATION2_X  = 331;      // �����{�^���ʒuX
        private const int               BUTTON_LOCATION3_X  = 458;      // �ۑ��{�^���ʒuX
        private const int               BUTTON_LOCATION4_X  = 585;      // ����{�^���ʒuX
        private const int               BUTTON_LOCATION_Y   = 9;        // �{�^���ʒuY(����)

		// PG���
		private const string            CT_PGID        = "MAKHN09630UA";
		private const string            CT_PGNAME      = "�摜���}�X�^";
		private const string            CT_CLASSNAME   = "MAKHN09630UA";

        // Message�֘A��`
        private const string            ERR_READ_MSG   = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string            ERR_DPR_MSG    = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string            ERR_RDEL_MSG   = "�폜�Ɏ��s���܂����B";
        private const string            ERR_UPDT_MSG   = "�o�^�Ɏ��s���܂����B";
        private const string            ERR_RVV_MSG    = "�����Ɏ��s���܂����B";
        private const string            ERR_800_MSG    = "���ɑ��[�����X�V����Ă��܂��B";
        private const string            ERR_801_MSG    = "���ɑ��[�����폜����Ă��܂��B";
        private const string            SDC_RDEL_MSG   = "�}�X�^����폜����Ă��܂��B";
        private const string            SDC_NFND_MSG   = "�}�X�^�ɓo�^����Ă��܂���B";

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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet		= this._imageInfoAcs.BindDataSet;
			tableName		= ImageInfoAcs.TBL_IMAGEINFO_TITLE;
		}
        
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
        /// <br>Note       : �O���b�h�̊e��̊O�ς�ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// �폜��
            appearanceTable.Add( ImageInfoAcs.COL_DELETEDATE_TITLE, 
                new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) );
            // �摜���敪�R�[�h
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFODIVCODE_TITLE, 
				new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            // �摜���敪����
            /* --- DEL 2008/10/29 �o�^��ʂɖ������ڂׁ̈A�O���b�h�ɕ\�������Ȃ� ----------------------------->>>>>
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFODIVNAME_TITLE, 
                new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
               --- DEL 2008/10/29 ----------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/29 ---------------------------------------------------------------------------->>>>>
            appearanceTable.Add(ImageInfoAcs.COL_IMAGEINFODIVNAME_TITLE,
                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/10/29 ----------------------------------------------------------------------------<<<<<
            // �摜���R�[�h
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFOCODE_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black ) );
            // �摜���\������
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFONAME_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // �摜���t�@�C���^�C�v
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFOFLTYPE_TITLE, 
				new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // �摜���f�[�^
            appearanceTable.Add( ImageInfoAcs.COL_IMAGEINFODATA_TITLE, 
				new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // GUID
            appearanceTable.Add( ImageInfoAcs.COL_GUID_TITLE, 
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		public int Search( ref int totalCount, int readCount )
		{
            // �摜���擾����
            return this.SearchProc(ref totalCount, readCount);
		}

		/// <summary>
		/// Next�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : Next�f�[�^�̌����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
		{
            const string ctPROCNM = "SearchProc";
			int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

			totalCount = 0;
			
			// �������s
			status = this._imageInfoAcs.SearchAll( out totalCount, this._enterpriseCode );
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
						this._imageInfoAcs,                 // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
            ImageInfo imageInfo = new ImageInfo();
			this.DispToImageInfo( ref imageInfo );

			// �������ݏ���
			int status = 0;
			status = this._imageInfoAcs.Write( imageInfo );

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

                    this.ImageInfoCode_tNedit.Focus();
                    this.ImageInfoCode_tNedit.SelectAll();

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
						this._imageInfoAcs,                 // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private int LogicalDeleteProc()
        {
            const string ctPROCNM = "LogicalDeleteProc";
            int status = 0;

            DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];

            // �O���b�h���I������Ă��Ȃ���
            if ((this._dataIndex < 0) ||
                (this._dataIndex >= dt.Rows.Count))
            {
                return status;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE]; // GUID

            // �_���폜���s
            status = this._imageInfoAcs.LogicalDelete(fileHeaderGuid);

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
                            this._imageInfoAcs,                 // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private int RevivalProc()
		{
			const string ctPROCNM = "RevivalProc";
			int status = 0;

            DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
			}

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE]; // GUID

			// �_���폜�������s
            status = this._imageInfoAcs.Revival(fileHeaderGuid);

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
						this._imageInfoAcs,                 // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private int PhysicalDeleteProc()
		{
			const string ctPROCNM = "PhysicalDeleteProc";
			int status = 0;

            DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];

			// �O���b�h���I������Ă��Ȃ���
			if( ( this._indexBuf < 0 ) || 
				( this._indexBuf >= dt.Rows.Count ) ) {
				this.CloseForm( DialogResult.Cancel );
				return -1;
            }

            // �I���f�[�^�擾
            Guid fileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE]; // GUID

			// �����폜���s
            status = this._imageInfoAcs.Delete(fileHeaderGuid);

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
						this._imageInfoAcs,                 // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// �f�[�^�Z�b�g���擾����
        /// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�擾�Ώۍs</param>
		/// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g����̏��擾���s���܂�</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void CopyToImageInfoFromDataSet(ref ImageInfo imageInfo, int index)
        {
            // �t���[���őI������Ă��郌�R�[�h�̃I�u�W�F�N�g���擾
            DataRowView dr = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView[index];

            if ((string)dr[ImageInfoAcs.COL_DELETEDATE_TITLE] != "") // �폜��
            {
                imageInfo.LogicalDeleteCode = 1;    // �_���폜�敪
            }
            imageInfo.ImageInfoDiv      = (int   )dr[ImageInfoAcs.COL_IMAGEINFODIVCODE_TITLE];  // �摜���敪
            //imageInfo.ImageInfoCode     = (int   )dr[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE];     // �摜���R�[�h                 //DEL 2008/11/07 ��O�G���[�ŗ������
            imageInfo.ImageInfoCode     = int.Parse(dr[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE].ToString());     // �摜���R�[�h     //ADD 2008/11/07
            imageInfo.ImageInfoName     = (string)dr[ImageInfoAcs.COL_IMAGEINFONAME_TITLE];     // �摜���\������
            imageInfo.ImageInfoFlType   = (string)dr[ImageInfoAcs.COL_IMAGEINFOFLTYPE_TITLE];   // �摜���t�@�C���^�C�v
            imageInfo.ImageInfoData     = (Byte[])dr[ImageInfoAcs.COL_IMAGEINFODATA_TITLE];     // �摜���f�[�^
            imageInfo.FileHeaderGuid    = (Guid  )dr[ImageInfoAcs.COL_GUID_TITLE];              // GUID
        }

		/// <summary>
        /// �}�X�^����ʓW�J����
        /// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �}�X�^������ʂɓW�J���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void ImageInfoToScreen(ImageInfo imageInfo)
        {
            // DEL 2008/10/01 �s��Ή�[5962]��
            //this.ImageInfoDiv_tComboEditor.Value        = imageInfo.ImageInfoDiv;               // �摜���敪

            // �摜���R�[�h
            if (imageInfo.ImageInfoCode != 0)
            {
                //this.ImageInfoCode_tNedit.Value         = imageInfo.ImageInfoCode;                //DEL 2008/11/07 �[���l��
                this.ImageInfoCode_tNedit.Text = imageInfo.ImageInfoCode.ToString("000000000");     //ADD 2008/11/07
            }
            this.ImageInfoName_tEdit.Text               = imageInfo.ImageInfoName;              // �摜���\������
            this.ImageInfoFlType_tEdit.Text             = imageInfo.ImageInfoFlType;            // �摜���t�@�C���^�C�v
            // �摜���f�[�^
            MemoryStream mem = new MemoryStream(imageInfo.ImageInfoData);
            mem.Position = 0;
            this.ImageInfoData_UltraPictureBox.Image = Image.FromStream(mem);
        }
        
		/// <summary>
		/// ��ʃf�[�^�擾����
		/// </summary>
        /// <param name="imageInfo">�摜���}�X�^�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʃf�[�^�̎擾���s���܂�</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private void DispToImageInfo(ref ImageInfo imageInfo)
        {
            // �X�V���[�h�̏ꍇ
            if (this._editingMode == CT_EMODE_UPDATE)
            {
                // Guid
                DataTable dt = this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];
                imageInfo.FileHeaderGuid = (Guid)dt.DefaultView[this._dataIndex][ImageInfoAcs.COL_GUID_TITLE];
            }

            // DEL 2008/10/01 �s��Ή�[5962]---------->>>>>
            //// �摜���敪
            //if (this.ImageInfoDiv_tComboEditor.SelectedIndex >= 0)
            //{
            //    imageInfo.ImageInfoDiv = (int)this.ImageInfoDiv_tComboEditor.Value;
            //}
            // DEL 2008/10/01 �s��Ή�[5962]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5962]��
            imageInfo.ImageInfoDiv      = ImageInfo.CONST_IMAGEINFODIV_COM;         // �摜���敪�i���Љ摜�j
            imageInfo.EnterpriseCode    = this._enterpriseCode;                     // ��ƃR�[�h
            imageInfo.ImageInfoCode     = this.ImageInfoCode_tNedit.GetInt();       // �摜���R�[�h
            imageInfo.ImageInfoName     = this.ImageInfoName_tEdit.Text.TrimEnd();  // �摜���\������
            imageInfo.ImageInfoFlType   = this.ImageInfoFlType_tEdit.Text;          // �摜���t�@�C���^�C�v
            // �摜���f�[�^
            if (this.ImageInfoData_UltraPictureBox.Image != null)
            {
                imageInfo.ImageInfoData = null;
                MemoryStream mem = new MemoryStream();
                Image img = (Image)this.ImageInfoData_UltraPictureBox.Image;
                img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                imageInfo.ImageInfoData = mem.ToArray();
            }
        }

        #endregion

        // --------------------------------------------------
        #region Screen Methods
        
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��ʂ̃N���A���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ScreenClear()
        {
            // DEL 2008/10/01 �s��Ή�[5962]---------->>>>>
            // �R���{�{�b�N�X�Z�b�g����
            //this.SetComboEditor();

            //this.ImageInfoDiv_tComboEditor.Value = ImageInfo.CONST_IMAGEINFODIV_COM;    // �摜���敪
            // DEL 2008/10/01 �s��Ή�[5962]----------<<<<<

            this.ImageInfoCode_tNedit.Clear();                                          // �摜���R�[�h
            this.ImageInfoName_tEdit.Clear();                                           // �摜���\������
            this.ImageInfoFlType_tEdit.Clear();                                         // �摜���t�@�C���^�C�v
            this.ImageInfoData_UltraPictureBox.Image = null;                            // �摜���f�[�^
            this.ImageInfoData_OpenFileDialog.FileName = "";
        }

        // DEL 2008/10/01 �s��Ή�[5962]---------->>>>>
        ///// <summary>
        ///// �R���{�{�b�N�X�Z�b�g����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : �R���{�{�b�N�X���Z�b�g���܂��B</br>
        ///// <br>Programmer : 22022 �i�� �m�q</br>
        ///// <br>Date       : 2007.05.16</br>
        ///// </remarks>
        //public void SetComboEditor()
        //{
        //    ImageInfo imageInfo = new ImageInfo();

        //    // �摜���敪
        //    this.ImageInfoDiv_tComboEditor.Items.Clear();
        //    foreach (int code in ImageInfo.ImageInfoDivCodes)
        //    {
        //        this.ImageInfoDiv_tComboEditor.Items.Add(code, imageInfo.GetImageInfoDivName(code));
        //    }
        //}
        // DEL 2008/10/01 �s��Ή�[5962]----------<<<<<

        /// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��ʂ̍č\�z�������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ScreenReconstruction()
        {
            ImageInfo imageInfo = new ImageInfo();

			// �V�K�̎�
            if (this._dataIndex < 0)
            {
                // �V�K���[�h�ɐݒ�
                this._editingMode = CT_EMODE_INSERT;
                this.Mode_Label.Text = INSERT_MODE;

                // �N���[���쐬
                this._imageInfoClone = new ImageInfo();
                this.DispToImageInfo(ref this._imageInfoClone);

                // ��ʓ��͋�����ݒ�
                this.ScreenInputPermissionControl(this._editingMode);
            }
            else
            {
                // �t���[���őI������Ă��郌�R�[�h�̃I�u�W�F�N�g���擾
                CopyToImageInfoFromDataSet(ref imageInfo, this._dataIndex);

                // �X�V���[�h
                if (imageInfo.LogicalDeleteCode == 0)
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
                this.ImageInfoToScreen(imageInfo);

                // �N���[���쐬
                this._imageInfoClone = new ImageInfo();
                this.DispToImageInfo(ref this._imageInfoClone);

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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void ScreenInputPermissionControl( int editingMode )
		{
			switch( editingMode ) {
				// �V�K���[�h
				case CT_EMODE_INSERT:
				{
					// �\���ݒ�
					this.Delete_Button.Visible              = false;    // ���S�폜�{�^��
					this.Revive_Button.Visible              = false;    // �����{�^��
					this.Ok_Button.Visible                  = true;     // �ۑ��{�^��
					this.Cancel_Button.Visible              = true;     // ����{�^��

                    // ���͋��ݒ�
                    // DEL 2008/10/01 �s��Ή�[5962]��
                    //this.ImageInfoDiv_tComboEditor.Enabled  = true;     // �摜���敪
                    this.ImageInfoCode_tNedit.Enabled       = true;     // �摜���R�[�h
					this.ImageInfoName_tEdit.Enabled        = true;     // �摜���\������
                    this.ImageInfoDataGuide_Button.Enabled  = true;     // �摜���K�C�h�{�^��
                    this.ImageInfoDataDelete_Button.Enabled = true;     // �摜���폜�{�^��

					// �����t�H�[�J�X�ݒ�
                    // DEL 2008/10/01 �s��Ή�[5962]��
                    //this.ImageInfoDiv_tComboEditor.Focus();
                    // DEL 2008/10/01 �s��Ή�[5009]��
                    //this.ImageInfoDiv_tComboEditor.SelectAll();
                    ImageInfoCode_tNedit.Focus();   // ADD 2008/09/30 �s��Ή�[5962]
					break;
				}
				// �X�V���[�h
				case CT_EMODE_UPDATE:
				{
					// �\���ݒ�
					this.Delete_Button.Visible              = false;    // ���S�폜�{�^��
					this.Revive_Button.Visible              = false;    // �����{�^��
					this.Ok_Button.Visible                  = true;     // �ۑ��{�^��
					this.Cancel_Button.Visible              = true;     // ����{�^��

                    // ���͋��ݒ�
                    // DEL 2008/10/01 �s��Ή�[5962]��
                    //this.ImageInfoDiv_tComboEditor.Enabled  = false;    // �摜���敪
                    this.ImageInfoCode_tNedit.Enabled       = false;    // �摜���R�[�h
                    this.ImageInfoName_tEdit.Enabled        = true;     // �摜���\������
                    this.ImageInfoDataGuide_Button.Enabled  = true;     // �摜���K�C�h�{�^��
                    this.ImageInfoDataDelete_Button.Enabled = true;     // �摜���폜�{�^��

					// �����t�H�[�J�X�ݒ�
					this.ImageInfoName_tEdit.Focus();
					this.ImageInfoName_tEdit.SelectAll();
					break;
				}
				// �폜���[�h
				case CT_EMODE_DELETE:
				{
					// �\���ݒ�
					this.Ok_Button.Visible      = false;    // �ۑ��{�^��
					this.Cancel_Button.Visible  = true;     // ����{�^��
                    this.Delete_Button.Visible  = true;     // ���S�폜�{�^��
                    this.Revive_Button.Visible  = true;     // �����{�^��
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu�V�t�g
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu�V�t�g

                    // ���͋��ݒ�
                    // DEL 2008/10/01 �s��Ή�[5962]��
                    //this.ImageInfoDiv_tComboEditor.Enabled  = false;    // �摜���敪
                    this.ImageInfoCode_tNedit.Enabled       = false;    // �摜���R�[�h
                    this.ImageInfoName_tEdit.Enabled        = false;    // �摜���\������
                    this.ImageInfoDataGuide_Button.Enabled  = false;    // �摜���K�C�h�{�^��
                    this.ImageInfoDataDelete_Button.Enabled = false;    // �摜���폜�{�^��

					// �����t�H�[�J�X�ݒ�
					this.Delete_Button.Focus();
					break;
				}
				// �Q�ƃ��[�h
				case CT_EMODE_REFER:
				{
					// �\���ݒ�
					this.Ok_Button.Visible                  = false;    // �ۑ��{�^��
					this.Cancel_Button.Visible              = true;     // ����{�^��
					this.Revive_Button.Visible              = false;    // �����{�^��
					this.Delete_Button.Visible              = false;    // ���S�폜�{�^��

					// ���͋��ݒ�
                    // DEL 2008/10/01 �s��Ή�[5962]��
                    //this.ImageInfoDiv_tComboEditor.Enabled  = false;    // �摜���敪
                    this.ImageInfoCode_tNedit.Enabled       = false;    // �摜���R�[�h
                    this.ImageInfoName_tEdit.Enabled        = false;    // �摜���\������
                    this.ImageInfoDataGuide_Button.Enabled  = false;    // �摜���K�C�h�{�^��
                    this.ImageInfoDataDelete_Button.Enabled = false;    // �摜���폜�{�^��

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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // �摜���R�[�h��������
            if (this.ImageInfoCode_tNedit.GetInt() == 0)
            {
                message = this.ImageInfoCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.ImageInfoCode_tNedit;
                result = false;
            }
            // �摜���\�����̂�������
            else if (this.ImageInfoName_tEdit.Text.TrimEnd() == "")
            {
                message = this.ImageInfoName_Title_Label.Text + "����͂��Ă��������B";
                control = this.ImageInfoName_tEdit;
                result = false;
            }
            // �摜���f�[�^�����ݒ�
            else if (this.ImageInfoData_UltraPictureBox.Image == null)
            {
                message = this.ImageInfoData_Title_Label.Text + "��ݒ肵�Ă��������B";
                control = this.ImageInfoDataGuide_Button;
                result = false;
            }

            return result;
        }

        #endregion

        // --------------------------------------------------
		#region Control Events

		/// <summary>
		/// Form.Load �C�x���g (MAGRP09120UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void MAGRP09120UA_Load( object sender, EventArgs e )
		{
			ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList                    = imageList24;   // �ۑ��{�^��
			this.Cancel_Button.ImageList                = imageList24;   // ����{�^��
			this.Revive_Button.ImageList                = imageList24;   // �����{�^��
			this.Delete_Button.ImageList                = imageList24;   // ���S�폜�{�^��
            this.ImageInfoDataGuide_Button.ImageList    = imageList16;   // �摜���K�C�h�{�^��

			this.Ok_Button.Appearance.Image                 = Size24_Index.SAVE;      // �ۑ��{�^��
			this.Cancel_Button.Appearance.Image             = Size24_Index.CLOSE;     // ����{�^��
			this.Revive_Button.Appearance.Image             = Size24_Index.REVIVAL;   // �����{�^��
			this.Delete_Button.Appearance.Image             = Size24_Index.DELETE;    // ���S�폜�{�^��
            this.ImageInfoDataGuide_Button.Appearance.Image = Size16_Index.STAR1;     // �摜���K�C�h�{�^��
		}

		/// <summary>
        /// Form.FormClosing �C�x���g (MAGRP09120UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void MAGRP09120UA_FormClosing( object sender, FormClosingEventArgs e )
		{
			// GridIndex�ێ��p�o�b�t�@����������
			this._indexBuf = -2;
			
			if( this._canClose == false ) {
				if( e.CloseReason == CloseReason.UserClosing ) {
					e.Cancel = true;
					this.Hide();
				}
			}
		}

		/// <summary>
        /// Form.VisibleChanged �C�x���g (MAGRP09120UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ω��������ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void MAGRP09120UA_VisibleChanged( object sender, EventArgs e )
		{
			if( this.Visible == false ) {
				this.Owner.Activate();
				return;
			}

			// GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
			if( this._dataIndex == this._indexBuf ) {
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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

                ImageInfo newImageInfo = new ImageInfo();

				// �N���[���쐬
                this._imageInfoClone = new ImageInfo();
				this.DispToImageInfo( ref this._imageInfoClone );

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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if( ( this._editingMode != CT_EMODE_DELETE ) && 
				( this._editingMode != CT_EMODE_REFER  ) ) {
				// ���݂̉�ʏ����擾����
                ImageInfo compareImageInfo = this._imageInfoClone.Clone();
				this.DispToImageInfo( ref compareImageInfo );

				// �ŏ��Ɏ擾������ʂƔ�r
				if( this._imageInfoClone.Equals( compareImageInfo ) == false ) {
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
                            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                ImageInfoCode_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
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
        /// Control.Click �C�x���g(ImageInfoDataGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �捞�摜�I���K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private void ImageInfoDataGuide_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = this.ImageInfoData_OpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ImageInfoFlType_tEdit.DataText = Path.GetExtension(this.ImageInfoData_OpenFileDialog.FileName).TrimStart('.');

                // --- ADD 2008/10/29 --------------------------------------------------------------------------------->>>>>
                // ���͂��ꂽ�t�@�C���̌`����"bmp"�A"jpg"�A"jpeg"���ǂ����̃`�F�b�N���s��

                // ���͕����񂩂画��
                if ((this.ImageInfoFlType_tEdit.DataText.ToUpper() != "BMP") &&
                    (this.ImageInfoFlType_tEdit.DataText.ToUpper() != "JPG") &&
                    (this.ImageInfoFlType_tEdit.DataText.ToUpper() != "JPEG"))
                {
                    TMsgDisp.Show(
                        this,                               // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                        CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�t�@�C���`���Ɍ�肪����܂��B",   // �\�����郁�b�Z�[�W
                        0,                                  // �X�e�[�^�X�l
                        MessageBoxButtons.OK);              // �\������{�^��
                    return;
                }

                // �f�[�^����摜�`���𔻒�
                try
                {
                    Bitmap bmp = new Bitmap(this.ImageInfoData_OpenFileDialog.FileName);

                    // bmp �̉摜�`���𕶎���Ŏ擾
                    string format = bmp.RawFormat.ToString();

                    // �摜�̊g���q�����߂�
                    string ext =                                
                        (format.IndexOf("b96b3cab-0728-11d3-9d7b-0000f81ef32e") != -1) ? "bmp" :
                        (format.IndexOf("b96b3caf-0728-11d3-9d7b-0000f81ef32e") != -1) ? "jpg" :
                        (format.IndexOf("b96b3cae-0728-11d3-9d7b-0000f81ef32e") != -1) ? "jpeg" :
                        "xxx";

                    if (ext == "xxx")
                    {
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            "�t�@�C���`���Ɍ�肪����܂��B",   // �\�����郁�b�Z�[�W
                            0,                                  // �X�e�[�^�X�l
                            MessageBoxButtons.OK);              // �\������{�^��
                        return;
                    }
                }
                catch
                {
                    // ���̓`�F�b�N
                    TMsgDisp.Show(
                        this,                               // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                        CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�t�@�C���`���Ɍ�肪����܂��B",   // �\�����郁�b�Z�[�W
                        0,                                  // �X�e�[�^�X�l
                        MessageBoxButtons.OK);              // �\������{�^��
                    return;
                }
                // --- ADD 2008/10/29 --------------------------------------------------------------------------------->>>>>

                this.ImageInfoData_UltraPictureBox.Image = Image.FromFile(this.ImageInfoData_OpenFileDialog.FileName);
                // ���_�I�����̓t�H�[�J�X�����ֈړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(ImageInfoDataDelete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �捞�摜�폜�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        private void ImageInfoDataDelete_Button_Click(object sender, EventArgs e)
        {
            this.ImageInfoData_UltraPictureBox.Image = null;
            this.ImageInfoFlType_tEdit.Clear();
            this.ImageInfoData_OpenFileDialog.FileName = "";
        }

		#endregion

		// --------------------------------------------------
		#region RetKeyControl Events

		/// <summary>
		/// ���^�[���L�[�ړ��C�x���g
		/// </summary>
		/// <remarks>
        /// <br>Note		: ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2007.05.16</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
		{
			if( e.PrevCtrl == null ) {
				return;
			}

            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            
            switch (e.PrevCtrl.Name)
            {
                case "ImageInfoCode_tNedit":
                    {
                        // �摜���R�[�h
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = ImageInfoCode_tNedit;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		}

		#endregion

        // --- ADD 2008/10/29 --------------------------------------------------------------------------->>>>>
        // �t�H�[�J�X�J�ڎ�
        private void ImageInfoCode_tNedit_Leave(object sender, EventArgs e)
        {
            // 0���͎��͋�ɂ���
            if (this.ImageInfoCode_tNedit.GetInt() == 0)
            {
                this.ImageInfoCode_tNedit.Text = string.Empty;
                return;
            }

            // 0�l��
            this.ImageInfoCode_tNedit.Text = this.ImageInfoCode_tNedit.GetInt().ToString("000000000");
        }
        // �t�H�[�J�X�擾��
        private void ImageInfoCode_tNedit_Enter(object sender, EventArgs e)
        {
            // 0�̎��͉����\�����Ȃ�
            if (this.ImageInfoCode_tNedit.GetInt() == 0)
            {
                return;
            }

            // 0�l�߂��Ȃ�
            this.ImageInfoCode_tNedit.Text = this.ImageInfoCode_tNedit.GetInt().ToString();
        }
        // --- ADD 2008/10/29 ---------------------------------------------------------------------------<<<<<

        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �摜���R�[�h
            int imageInfoCode = ImageInfoCode_tNedit.GetInt();

            for (int i = 0; i < this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsImageInfoCode = int.Parse(this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView[i][ImageInfoAcs.COL_IMAGEINFOCODE_TITLE].ToString());
                if (imageInfoCode == dsImageInfoCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._imageInfoAcs.BindDataSet.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE].DefaultView[i][ImageInfoAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̉摜�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �摜���R�[�h�̃N���A
                        ImageInfoCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̉摜�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // �摜���R�[�h�̃N���A
                                ImageInfoCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}