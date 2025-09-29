//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�`�[�ݒ�}�X�^
// �v���O�����T�v   �F�`�[�ݒ�̓o�^�E�C���E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2008/06/04     �C�����e�FPartsman�p�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2008/08/07     �C�����e�F���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g�v���p�e�B�ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V �m��
// �C����    2008/10/06     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2009/02/04     �C�����e�F���Ӑ�}�X�^�i�`�[�Ǘ��j���̂ݎ擾����Search���\�b�h�ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/17     �C�����e�FMantis�y12829�z���x�A�b�v�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20056 ���n ���
// �C����    2009.07.13     �C�����e�F�R���X�g���N�^�I�[�o�[���[�h(���_�����擾���Ȃ�)
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2007.09.18</br>
	/// <br>Update Note: 2008.01.31 30167 ���@�O�M</br>
	/// <br>			 ���[�J���c�a�Ή�</br>
	/// <br>Update Note: 2008.03.17 30167 ���@�O�M</br>
	/// <br>			 ����ݒ�p���[�h�c�f�[�^�擾�ǉ�</br>
    /// <br>Update Note: 2008.06.04 30413 ����</br>
    /// <br>             PM.NS�Ή�(���_�R�[�h��ǉ�)</br>
    /// <br>Update Note: 2008.08.07 20056 ���n ���</br>
    /// <br>             ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g�v���p�e�B�ǉ�</br>
    /// <br>UpdateNote : 2008/10/06 30462 �s�V �m���@�o�O�C��</br>
    /// <br>Update Note: 2009.02.04 20056 ���n ���</br>
    /// <br>             ���Ӑ�}�X�^�i�`�[�Ǘ��j���̂ݎ擾����Search���\�b�h�ǉ�</br>
    /// <br>Update Note: 2009.07.13 20056 ���n ���</br>
    /// <br>             �R���X�g���N�^�I�[�o�[���[�h(���_�����擾���Ȃ�)</br>
    /// </remarks>
	public class CustSlipMngAcs : IGeneralGuideData
	{
		// --------------------------------------------------
		#region Private Members

        // ��ƃR�[�h
        private string          _enterpriseCode = "";

        /// <summary>���Ӑ�}�X�^(�`�[�Ǘ�)�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ICustSlipMngDB _iCustSlipMngDB = null;

        // �f�[�^�Z�b�g
        private DataSet   _bindDataSet = null;
        private DataTable _custslipmngTable = null;

        // �}�X�^�N���X�i�[���X�g
        private Dictionary<Guid, CustSlipMngWork> _custslipmngDic = null;     // ���Ӑ�}�X�^(�`�[�Ǘ�)�i�[�p

        // �}�X�^�擾�p���X�g
        private ArrayList _custslipmngWorkList = null;                  // ���Ӑ�}�X�^(�`�[�Ǘ�)�擾�p

        // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // �v���p�e�B�Z�b�g�p���X�g
        private ArrayList _custslipMngList = null;
        // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//----- ueno add ---------- start 2008.01.31
		// �`�[����ݒ�p�}�X�^�A�N�Z�X�N���X
		private SlipPrtSetAcs _slipPrtSetAcs = null;

		// ����ݒ�p���[�R���{�{�b�N�X�p
		public SortedList _slipPrtSetPaperIdList = null;

		// �����񌋍��p
		private StringBuilder _stringBuilder = null;
		//----- ueno add ---------- end 2008.01.31

        // ���_�}�X�^�A�N�Z�X�N���X
        SecInfoAcs _secInfoAcs;     // ADD 2009/04/17

        // �K�C�h�p
        private const string GUIDE_XML_FILENAME = "CUSTSLIPMNGGUIDEPARENT.XML";    // XML�t�@�C����
        private const string GUIDE_ENTERPRISECODE_TITLE  = "EnterpriseCode";       // ��ƃR�[�h
        private const string GUIDE_DATAINPUTSYSTEM_TITLE = "DataInputSystem";          // �f�[�^���̓V�X�e��
        private const string GUIDE_DATAINPUTSYSTEMNAME_TITLE = "DataInputSystemName";  // �f�[�^���̓V�X�e������
        private const string GUIDE_SLIPPRTKIND_TITLE = "SlipPrtKind";              // �`�[�����ʃR�[�h
        private const string GUIDE_SLIPPRTKINDNAME_TITLE = "SlipPrtKindName";      // �`�[�����ʖ���
        // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";               // ���_�R�[�h
        private const string GUIDE_SECTIONNAME_TITLE = "SectionName";               // ���_����
        // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";            // ���Ӑ�R�[�h
        private const string GUIDE_CUSTOMERNAME_TITLE = "CustomerName";            // ���Ӑ於��
        private const string GUIDE_SLIPPRTSETPAPERID_TITLE = "SlipPrtSetPaperId";  // �`�[����ݒ�p���[ID

		//----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		
		private CustSlipMngLcDB _custSlipMngLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        #endregion

        // --------------------------------------------------
        #region Public Members

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        public static readonly string TBL_CUSTSLIPMNG_TITLE = "CUSTSLIPMNG_TABLE";
        public static readonly string COL_DELETEDATE_TITLE = "�폜��";
        public static readonly string COL_DATAINPUTSYSTEM_TITLE = "�f�[�^���̓V�X�e��";
        public static readonly string COL_DATAINPUTSYSTEMNAME_TITLE = "�f�[�^���̓V�X�e������";
        public static readonly string COL_SLIPPRTKIND_TITLE = "�`�[������";
        // DEL 2008/10/06 �s��Ή�[6218]��
        //public static readonly string COL_SLIPPRTKINDNAME_TITLE = "�`�[�����ʖ���";
        public static readonly string COL_SLIPPRTKINDNAME_TITLE = "�`�[�����ʖ�";   // ADD 2008/10/06 �s��Ή�[6218]
        // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
        public static readonly string COL_SECTIONCODE_TITLE = "���_�R�[�h";
        // DEL 2008/10/06 �s��Ή�[6218]��
        //public static readonly string COL_SECTIONNAME_TITLE = "���_����";
        public static readonly string COL_SECTIONNAME_TITLE = "���_��";   // ADD 2008/10/06 �s��Ή�[6218]
        // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
        public static readonly string COL_CUSTOMERCODE_TITLE = "���Ӑ�R�[�h";
        // DEL 2008/10/06 �s��Ή�[6218]��
        //public static readonly string COL_CUSTOMERNAME_TITLE = "���Ӑ於��";
        public static readonly string COL_CUSTOMERNAME_TITLE = "���Ӑ於";   // ADD 2008/10/06 �s��Ή�[6218]

        // DEL 2008/10/06 �s��Ή�[6222]��
        //public static readonly string COL_SLIPPRTSETPAPERID_TITLE = "�`�[����ݒ�p���[ID";

        // ADD 2008/10/06 �s��Ή�[6222] ---------->>>>>
        public static readonly string COL_SLIPPRTSETPAPERID_TITLE = "�`�[����ݒ�p���[ID_Dmmy";
        public static readonly string COL_SLIPPRTSETPAPERNAME_TITLE = "�`�[����ݒ�p���[ID";
        // ADD 2008/10/06 �s��Ή�[6222] ----------<<<<<

        public static readonly string COL_GUID_TITLE = "GUID";

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public CustSlipMngAcs()
		{
			try {
				// ��ƃR�[�h�擾
				this._enterpriseCode    = LoginInfoAcquisition.EnterpriseCode;

				// �����[�g�I�u�W�F�N�g�擾
                this._iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();

                // �}�X�^�N���X�i�[���X�g������
                this._custslipmngDic = new Dictionary<Guid, CustSlipMngWork>();

                // �}�X�^�擾�p���X�g������
                this._custslipmngWorkList = new ArrayList();

                // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �v���p�e�B�Z�b�g�p���X�g
                this._custslipMngList = new ArrayList();
                // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // �f�[�^�Z�b�g������
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();

				//----- ueno add ---------- start 2008.01.31
				// �`�[����ݒ�
				this._slipPrtSetAcs = new SlipPrtSetAcs();
								
				// ����ݒ�p���[�R���{�{�b�N�X�p
				this._slipPrtSetPaperIdList = new SortedList();
				
				// �����񌋍��p
				this._stringBuilder = new StringBuilder();
				//----- ueno add ---------- end 2008.01.31

                this._secInfoAcs = new SecInfoAcs();    // ADD 2009/04/17
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
                this._iCustSlipMngDB = null;
			}

			//----- ueno add ---------- start 2008.01.31
			// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			this._custSlipMngLcDB = new CustSlipMngLcDB();
			//----- ueno add ---------- end 2008.01.31
		}

        // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="mode">�������[�h(0:�ʏ�(��̫�ĺݽ�׸��Ɠ��l) 1:���_���̎擾�Ȃ�)</param>
        public CustSlipMngAcs(int mode)
        {
            try
            {
                // ��ƃR�[�h�擾
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // �����[�g�I�u�W�F�N�g�擾
                this._iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();

                // �}�X�^�N���X�i�[���X�g������
                this._custslipmngDic = new Dictionary<Guid, CustSlipMngWork>();

                // �}�X�^�擾�p���X�g������
                this._custslipmngWorkList = new ArrayList();

                // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �v���p�e�B�Z�b�g�p���X�g
                this._custslipMngList = new ArrayList();
                // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // �f�[�^�Z�b�g������
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();

                //----- ueno add ---------- start 2008.01.31
                // �`�[����ݒ�
                this._slipPrtSetAcs = new SlipPrtSetAcs();

                // ����ݒ�p���[�R���{�{�b�N�X�p
                this._slipPrtSetPaperIdList = new SortedList();

                // �����񌋍��p
                this._stringBuilder = new StringBuilder();
                //----- ueno add ---------- end 2008.01.31

                switch (mode)
                {
                    case 0:
                        this._secInfoAcs = new SecInfoAcs();
                        break;
                    case 1:
                        this._secInfoAcs = null;
                        break;
                    default:
                        this._secInfoAcs = null;
                        break;
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCustSlipMngDB = null;
            }

            //----- ueno add ---------- start 2008.01.31
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._custSlipMngLcDB = new CustSlipMngLcDB();
            //----- ueno add ---------- end 2008.01.31
        }
        // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// �`�[�Ǘ��}�X�^�e�[�u��
            this._custslipmngTable = new DataTable(TBL_CUSTSLIPMNG_TITLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			this._custslipmngTable.Columns.Add( COL_DELETEDATE_TITLE      , typeof( string ) );      // �폜��
            this._custslipmngTable.Columns.Add( COL_DATAINPUTSYSTEM_TITLE, typeof(Int32));           // �f�[�^���̓V�X�e��
            this._custslipmngTable.Columns.Add( COL_DATAINPUTSYSTEMNAME_TITLE , typeof( string ) );  // �f�[�^���̓V�X�e������
            this._custslipmngTable.Columns.Add( COL_SLIPPRTKIND_TITLE     , typeof(Int32));          // �`�[������
            this._custslipmngTable.Columns.Add( COL_SLIPPRTKINDNAME_TITLE , typeof( string ) );      // �`�[�����ʖ���
            // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            this._custslipmngTable.Columns.Add(COL_SECTIONCODE_TITLE, typeof(string));              // ���_�R�[�h
            this._custslipmngTable.Columns.Add(COL_SECTIONNAME_TITLE, typeof(string));              // ���_����
            // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
            // 2008.06.04 30413 ���� ���Ӑ�R�[�h�̃R�����g�� >>>>>>START
            this._custslipmngTable.Columns.Add( COL_CUSTOMERCODE_TITLE    , typeof(Int32));          // ���Ӑ�R�[�h
            // 2008.06.04 30413 ���� ���Ӑ�R�[�h�̃R�����g�� <<<<<<END
            this._custslipmngTable.Columns.Add(COL_CUSTOMERNAME_TITLE, typeof(string));         // ���Ӑ於��
            this._custslipmngTable.Columns.Add( COL_SLIPPRTSETPAPERID_TITLE, typeof(string));        // ���[ID

            // ADD 2008/10/06 �s��Ή�[6222] ---------->>>>>
            this._custslipmngTable.Columns.Add(COL_SLIPPRTSETPAPERNAME_TITLE, typeof(string));        // ���[ID
            // ADD 2008/10/06 �s��Ή�[6222] ----------<<<<<

            // 2008.06.04 30413 ���� GUID�̃R�����g�� >>>>>>START
            this._custslipmngTable.Columns.Add( COL_GUID_TITLE            , typeof( Guid   ) );      // GUID
            // 2008.06.04 30413 ���� GUID�̃R�����g�� <<<<<<END

            this._custslipmngTable.PrimaryKey = new DataColumn[] { this._custslipmngTable.Columns[COL_GUID_TITLE] };

            this._bindDataSet.Tables.Add(this._custslipmngTable);
		}

		#endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>�f�[�^�Z�b�g�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g���擾���܂��B</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }
        // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g</summary>
        public ArrayList CustSlipMngList
        {
            get { return _custslipMngList; }
        }
        // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ���[�J���c�aRead���[�h
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		//----- ueno add ---------- end 2008.01.31

        #endregion

		// --------------------------------------------------
		#region GetOnlineMode

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// �I�����C�����[�h���擾
			if( this._iCustSlipMngDB == null ) {
				// �I�t���C��
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				// �I�����C��
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

		// --------------------------------------------------
		#region Read Methods

		/// <summary>
        ///�ǂݍ��ݏ���
		/// </summary>
        /// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>
        /// <param name="slipPrtKind">�`�[�����ʃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// <br>Update note: 2008.06.04 30413 ����</br>
        /// <br>             �EPM.NS�Ή�(���_�R�[�h��param�ɒǉ�)</br>
		/// </remarks>
        public int Read(out CustSlipMng custSlipMng, string enterpriseCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
		{
            return this.ReadProc(out custSlipMng, enterpriseCode, dataInputSystem, slipPrtKind, sectionCode, customerCode);
		}

		/// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)�ǂݍ��ݏ���
		/// </summary>
        /// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// <br>Update note: 2008.06.04 30413 ����</br>
        /// <br>             �EPM.NS�Ή�(���_�R�[�h��param�ɒǉ�)</br>
		/// </remarks>
        private int ReadProc(out CustSlipMng custSlipMng, string enterpriseCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
		{
            int status1 = 0;

            custSlipMng = null;

            try
            {
                // �L�[�����Z�b�g
                CustSlipMngWork custSlipMngWork = new CustSlipMngWork();
                custSlipMngWork.EnterpriseCode = enterpriseCode;   // ��ƃR�[�h
                custSlipMngWork.DataInputSystem = dataInputSystem; // �f�[�^���̓V�X�e��
                custSlipMngWork.SlipPrtKind = slipPrtKind;         // �`�[������
                // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                custSlipMngWork.SectionCode = sectionCode;          // ���_�R�[�h
                // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
                custSlipMngWork.CustomerCode = customerCode;       // ���Ӑ�R�[�h

				//----- ueno upd ---------- start 2008.01.31
				// ���[�J��
            	if (_isLocalDBRead)
				{
					status1 = this._custSlipMngLcDB.Read(ref custSlipMngWork, 0);
				}
            	// �����[�g
				else
				{
	                // XML�֕ϊ����A������̃o�C�i����
		            byte[] parabyte = XmlByteSerializer.Serialize(custSlipMngWork);

					//���Ӑ�}�X�^(�`�[�Ǘ�)�ǂݍ���
					status1 = this._iCustSlipMngDB.Read(ref parabyte, 0);

					if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// �f�V���A���C�Y����
						custSlipMngWork = (CustSlipMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSlipMngWork));
						// ���ʂ������o�R�s�[
						//custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
					}
				}

				if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���ʂ������o�R�s�[
					custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
				}
				//----- ueno upd ---------- emd 2008.01.31

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                custSlipMng = null;
                this._iCustSlipMngDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status1 = -1;
            }

			return status1;
		}

		#endregion

		// --------------------------------------------------
		#region Write Methods

		/// <summary>
        ///�������ݏ���
		/// </summary>
        /// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Write(CustSlipMng custSlipMng)
        {
            // ���Ӑ�}�X�^(�`�[�Ǘ�)�X�V
            return this.WriteProc(custSlipMng);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)�������ݏ���
		/// </summary>
        /// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int WriteProc(CustSlipMng custSlipMng)
		{
			int status = 0;

			try {
                CustSlipMngWork custSlipMngWork = new CustSlipMngWork();

                // �ҏW�O���擾
                if (this._custslipmngDic.ContainsKey(custSlipMng.FileHeaderGuid) == true)
                {
                    custSlipMngWork = (this._custslipmngDic[custSlipMng.FileHeaderGuid] as CustSlipMngWork);
                }

                // �ҏW���擾
                CopyToCustSlipMngWorkFromDispCustSlipMng(ref custSlipMngWork, custSlipMng);

                object retObj = (object)custSlipMngWork;

                //���Ӑ�}�X�^(�`�[�Ǘ�)��������
                status = this._iCustSlipMngDB.Write(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    custSlipMngWork = (CustSlipMngWork)retArray[0];
                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustSlipMngDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region LogicalDelete Methods

		/// <summary>
        ///�_���폜����
		/// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�`�[�Ǘ�)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // ���Ӑ�}�X�^(�`�[�Ǘ�)�_���폜
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�`�[�Ǘ�)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                CustSlipMngWork custSlipMngWork = (this._custslipmngDic[fileHeaderGuid] as CustSlipMngWork);

                object retObj = (object)custSlipMngWork;

                //���Ӑ�}�X�^(�`�[�Ǘ�)�_���폜
                status = this._iCustSlipMngDB.LogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    custSlipMngWork = (CustSlipMngWork)retObj;
                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustSlipMngDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
        }

		#endregion

		// --------------------------------------------------
		#region Revival Methods

		/// <summary>
        ///�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�`�[�Ǘ�)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // ���Ӑ�}�X�^(�`�[�Ǘ�)����
            return this.RevivalProc(fileHeaderGuid);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�`�[�Ǘ�)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                CustSlipMngWork custSlipMngWork = (this._custslipmngDic[fileHeaderGuid] as CustSlipMngWork);

                object retObj = (object)custSlipMngWork;

                //���Ӑ�}�X�^(�`�[�Ǘ�)�_���폜����
                status = this._iCustSlipMngDB.RevivalLogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    custSlipMngWork = (CustSlipMngWork)retObj;
                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustSlipMngDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Delete Methods

		/// <summary>
        ///�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�`�[�Ǘ�)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // ���Ӑ�}�X�^(�`�[�Ǘ�)�����폜
            return this.DeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�`�[�Ǘ�)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                CustSlipMngWork custSlipMngWork = (this._custslipmngDic[fileHeaderGuid] as CustSlipMngWork);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(custSlipMngWork);

                //���Ӑ�}�X�^(�`�[�Ǘ�)�����폜
                status = this._iCustSlipMngDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._custslipmngDic.Remove(custSlipMngWork.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    DataRow dr = this._custslipmngTable.Rows.Find(custSlipMngWork.FileHeaderGuid);
                    
                    dr.Delete();
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustSlipMngDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Search Methods

		/// <summary>
        ///��������(�_���폜����)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Search(out int totalCount, string enterpriseCode)
        {
            // ���Ӑ�}�X�^(�`�[�Ǘ�)����
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }

        // 2009.02.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���������i�_���폜�����ACustSlipMng�̂�Search�j
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        public int SearchOnlyCustSlipMng(out int totalCount, string enterpriseCode)
        {
            return this.SearchProcOnlyCustSlipMng(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2009.02.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///��������(�_���폜�܂�)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode)
        {
            // ���Ӑ�}�X�^(�`�[�Ǘ�)����
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        ///��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private int SearchProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

			//----- h.ueno add ---------- start 2008.03.17
			//============================
			// �`�[����ݒ�}�X�^�ǂݍ���
			//============================
			// �`�[����ݒ�p���[ID�S�擾
			ArrayList slipPrtRetList = null;

			// �`�[����ݒ�p���[�J���t���O�ݒ�
			this._slipPrtSetAcs.IsLocalDBRead = _isLocalDBRead;

			int status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, enterpriseCode);

			if ((status == 0) && (slipPrtRetList.Count > 0))
			{
                this._slipPrtSetPaperIdList = new SortedList();

				string key = "";

				foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
				{
					//--------------------------------------------------------------------
					// Key  �F�t�@�C�����C�A�E�g�̃L�[���ڂ���������
					//   �ް����ͼ���(2��) + �`�[������(4��)�{�`�[����ݒ�p���[ID(24��)
					// Value�F�`�[����ݒ�}�X�^�N���X
					//--------------------------------------------------------------------
					this._stringBuilder.Remove(0, this._stringBuilder.Length);
					this._stringBuilder.Append(slipPrtSet.DataInputSystem.ToString("d2"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtKind.ToString("d4"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtSetPaperId.TrimEnd());
					key = this._stringBuilder.ToString();

					this._slipPrtSetPaperIdList.Add(key, slipPrtSet);
				}
			}
			//----- h.ueno add ---------- end 2008.03.17

            // ���Ӑ�}�X�^(�`�[�Ǘ�)����
            status1 = this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // �L���b�V������
            status2 = this.Cache(this._custslipmngWorkList);
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }


            // �X�e�[�^�X���f
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status2 == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        // 2009.02.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j���������iCustSlipMng�̂�Search�j
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns></returns>
        private int SearchProcOnlyCustSlipMng(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            return this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, logicalMode);
        }
        // 2009.02.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�̌����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private int SearchSlipTypeMngProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._custslipmngWorkList.Clear();

                // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �v���p�e�B�Z�b�g�p���X�g
                this._custslipMngList.Clear();
                // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // �L���b�V���p�e�[�u�����N���A
                this._custslipmngDic.Clear();

                // �L�[�����Z�b�g
                CustSlipMngWork paramCustSlipMngWork = new CustSlipMngWork();
                paramCustSlipMngWork.EnterpriseCode = enterpriseCode;    // ��ƃR�[�h

                object retobj = null;

				//----- ueno upd ---------- start 2008.01.31
				// ���[�J��
				if (_isLocalDBRead)
				{
					List<CustSlipMngWork> custSlipMngWorkList = new List<CustSlipMngWork>();
					status = this._custSlipMngLcDB.Search(out custSlipMngWorkList, paramCustSlipMngWork, 0, logicalMode);
					
					if(status == 0)
					{
						ArrayList al = new ArrayList();
						al.AddRange(custSlipMngWorkList);
						retobj = (object)al;
					}
				}
				// �����[�g
				else
				{
					//���Ӑ�}�X�^(�`�[�Ǘ�)����
					status = this._iCustSlipMngDB.Search(out retobj, paramCustSlipMngWork, 0, logicalMode);
				}
				//----- ueno upd ---------- end 2008.01.31

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._custslipmngWorkList = retobj as ArrayList;

                    // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �v���p�e�B�Z�b�g�p���X�g�쐬
                    this._custslipMngList = this.CopyToCustSlipMngListFromCustSlipMngWorkList(this._custslipmngWorkList);
                    // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // �Y�������i�[
                    totalCount = this._custslipmngWorkList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCustSlipMngDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }
		#endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// �}�X�^�L���b�V������
        /// </summary>
        /// <param name="custSlipMngList">�`�[�Ǘ��}�X�^�擾���ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int Cache(ArrayList custSlipMngWorkList)
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._custslipmngTable.BeginLoadData();

                    // �e�[�u�����N���A
                    this._custslipmngTable.Clear();

                    // �Ǘ��f�[�^��DataSet�Ɋi�[
                    foreach (CustSlipMngWork custSlipMngWork in custSlipMngWorkList)
                    {
                        // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
                        // 2008.09.26 30413 ���� ���Ϗ��Ɣ[�i���̂ݒ��o >>>>>>START
                        //// 2008.09.22 30413 ���� ���o�^�ȊO���f�[�^�Z�b�g�֒ǉ�����悤�ɏC�� >>>>>>START
                        //// ���̏����ɗ���O�Ƀf�B�N�V���i���[�ւ̓o�^������Ă���̂Ō������ʂ�
                        //// �r���[�ɕ\���o���Ȃ���
                        ////// ���o�^�̎�
                        ////if (this._custslipmngDic.ContainsKey(custSlipMngWork.FileHeaderGuid) == false)
                        ////{
                        //    //// �f�[�^�Z�b�g�ɒǉ�
                        //    //this.CustSlipMngWorkToDataSet(custSlipMngWork);
                        ////}
                        //// �f�[�^�Z�b�g�ɒǉ�
                        //this.CustSlipMngWorkToDataSet(custSlipMngWork);
                        //// 2008.09.22 30413 ���� ���o�^�ȊO���f�[�^�Z�b�g�֒ǉ�����悤�ɏC�� <<<<<<END
                        //if ((custSlipMngWork.SlipPrtKind == 10) || (custSlipMngWork.SlipPrtKind == 30))
                        //{
                        //    this.CustSlipMngWorkToDataSet(custSlipMngWork);
                        //}
                        switch (custSlipMngWork.SlipPrtKind)
                        {
                            case 10:        // ���Ϗ�
                            case 30:        // ����`�[
                            case 120:       // �󒍓`�[
                            case 130:       // �ݏo�`�[
                            case 140:       // ���ϓ`�[
                            case 150:       // �݌Ɉړ��`�[
                            case 160:       // �t�n�d�`�[
                                {
                                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
                                    break;
                                }
                        }
                        // 2008.09.26 30413 ���� ���Ϗ��Ɣ[�i���̂ݒ��o <<<<<<END
                        // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END
                    }
                }
                finally
                {
                    // �X�V�����I��
                    this._custslipmngTable.EndLoadData();

                    // �\�[�g
                    this._custslipmngTable.DefaultView.Sort = COL_SLIPPRTKIND_TITLE + " ASC";           // �`�[�����ʃR�[�h
                    this._custslipmngTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�R�s�[���� (��ʕύX���Ӑ�}�X�^(�`�[�Ǘ�)�N���X�˓��Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X)
        /// </summary>
        /// <param name="custSlipMngWork">���Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X</param>
        /// <param name="custSlipMng">���Ӑ�}�X�^(�`�[�Ǘ�)�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX���Ӑ�}�X�^(�`�[�Ǘ�)�N���X����
        ///                  ���Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void CopyToCustSlipMngWorkFromDispCustSlipMng(ref CustSlipMngWork custSlipMngWork, CustSlipMng custSlipMng)
        {
            custSlipMngWork.EnterpriseCode   = custSlipMng.EnterpriseCode;         // ��ƃR�[�h
            custSlipMngWork.DataInputSystem = custSlipMng.DataInputSystem;         
            custSlipMngWork.SlipPrtKind    = custSlipMng.SlipPrtKind;              // �`�[������
            // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            custSlipMngWork.SectionCode = custSlipMng.SectionCode;                  // ���_�R�[�h
            // 2008.06.03 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
            custSlipMngWork.CustomerCode = custSlipMng.CustomerCode;            // ���Ӑ�R�[�h
            custSlipMngWork.CustomerSnm = custSlipMng.CustomerSnm;                 // ���Ӑ於��
            custSlipMngWork.SlipPrtSetPaperId = custSlipMng.SlipPrtSetPaperId;  // ���[ID
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (���Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X���X�g�˓��Ӑ�}�X�^(�`�[�Ǘ�)�N���X���X�g)
        /// </summary>
        /// <param name="custSlipMngWorkList"></param>
        /// <returns></returns>
        private ArrayList CopyToCustSlipMngListFromCustSlipMngWorkList(ArrayList custSlipMngWorkList)
        {
            ArrayList retList = new ArrayList();
            foreach (CustSlipMngWork custSlipMngWork in custSlipMngWorkList)
            {
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
                // 2008.09.29 30413 ���� ���Ϗ��Ɣ[�i���̂ݒ��o >>>>>>START
                //CustSlipMng custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
                //retList.Add(custSlipMng);
                //if ((custSlipMngWork.SlipPrtKind == 10) || (custSlipMngWork.SlipPrtKind == 30))
                //{
                //    CustSlipMng custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
                //    retList.Add(custSlipMng);
                //}
                switch (custSlipMngWork.SlipPrtKind)
                {
                    case 10:        // ���Ϗ�
                    case 30:        // ����`�[
                    case 120:       // �󒍓`�[
                    case 130:       // �ݏo�`�[
                    case 140:       // ���ϓ`�[
                    case 150:       // �݌Ɉړ��`�[
                    case 160:       // �t�n�d�`�[
                        {
                            CustSlipMng custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
                            retList.Add(custSlipMng);
                            break;
                        }
                }
                // 2008.09.29 30413 ���� ���Ϗ��Ɣ[�i���̂ݒ��o <<<<<<END
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END
            }
            return retList;
        }

		/// <summary>
        /// �N���X�����o�R�s�[���� (���Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X�˓��Ӑ�}�X�^(�`�[�Ǘ�)�N���X)
		/// </summary>
        /// <param name="custSlipMngWork">���Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X</param>
        /// <returns>���Ӑ�}�X�^(�`�[�Ǘ�)�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)���[�N�N���X����
        ///                  ���Ӑ�}�X�^(�`�[�Ǘ�)�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private CustSlipMng CopyToCustSlipMngFromCustSlipMngWork(CustSlipMngWork custSlipMngWork)
        {
            CustSlipMng custSlipMng = new CustSlipMng();

            custSlipMng.CreateDateTime = custSlipMngWork.CreateDateTime;        // �쐬����
            custSlipMng.UpdateDateTime = custSlipMngWork.UpdateDateTime;        // �X�V����
            custSlipMng.EnterpriseCode = custSlipMngWork.EnterpriseCode;        // ��ƃR�[�h
            custSlipMng.FileHeaderGuid = custSlipMngWork.FileHeaderGuid;        // GUID
            custSlipMng.UpdEmployeeCode = custSlipMngWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            custSlipMng.UpdAssemblyId1 = custSlipMngWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            custSlipMng.UpdAssemblyId2 = custSlipMngWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            custSlipMng.LogicalDeleteCode = custSlipMngWork.LogicalDeleteCode;  // �_���폜�敪
            custSlipMng.DataInputSystem = custSlipMngWork.DataInputSystem;      // �f�[�^���̓V�X�e��
            custSlipMng.SlipPrtKind = custSlipMngWork.SlipPrtKind;              // �`�[������
            // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            custSlipMng.SectionCode = custSlipMngWork.SectionCode;              // ���_�R�[�h
            // 2008.06.03 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
            custSlipMng.CustomerCode = custSlipMngWork.CustomerCode;            // ���Ӑ�R�[�h
            custSlipMng.CustomerSnm = custSlipMngWork.CustomerSnm;              // ���Ӑ於��
            custSlipMng.SlipPrtSetPaperId = custSlipMngWork.SlipPrtSetPaperId;  // ���[ID
            
            // �e�[�u���X�V
            _custslipmngDic[custSlipMngWork.FileHeaderGuid] = custSlipMngWork;

            return custSlipMng;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g���C��DataSet�W�J����
        /// </summary>
        /// <param name="custSlipMngWork">���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private void CustSlipMngWorkToDataSet(CustSlipMngWork custSlipMngWork)
        {
            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            DataRow dr = this._custslipmngTable.Rows.Find(custSlipMngWork.FileHeaderGuid);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._custslipmngTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // �폜��
            if (custSlipMngWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custSlipMngWork.UpdateDateTime);
            }

            // �f�[�^���̓V�X�e��
            dr[COL_DATAINPUTSYSTEM_TITLE] = custSlipMngWork.DataInputSystem;
            // �f�[�^���̓V�X�e������
            switch (custSlipMngWork.DataInputSystem)
            {
                case 0: 
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "����";
                    break;
                }
                case 1: 
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "����";
                    break;
                }
                case 2:
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "���";
                    break;
                }
                case 3:
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "�Ԕ�";
                    break;
                }
            }
            // �`�[������
            dr[COL_SLIPPRTKIND_TITLE] = custSlipMngWork.SlipPrtKind;
            // �`�[�����ʖ���
            switch (custSlipMngWork.SlipPrtKind)
            {
                case 10:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "���Ϗ�";
                        break;
                    }
                case 20:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "�w����(������)";
                        break;
                    }
                case 21:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "���菑";
                        break;
                    }
                case 30:
                    {
                        // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX >>>>>>START
                        //dr[COL_SLIPPRTKINDNAME_TITLE] = "�[�i��";
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "����`�[";
                        // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX <<<<<<END
                        break;
                    }
                case 40:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "�ԕi�`�[";
                        break;
                    }
				case 100:
					{
						dr[COL_SLIPPRTKINDNAME_TITLE] = "���[�N�V�[�g";
						break;
					}
				case 110:
					{
						dr[COL_SLIPPRTKINDNAME_TITLE] = "�{�f�B���@�}";
						break;
					}
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
                case 120:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "�󒍓`�[";
                        break;
                    }
                case 130:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "�ݏo�`�[";
                        break;
                    }
                case 140:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "���ϓ`�[";
                        break;
                    }
                case 150:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "�݌Ɉړ��`�[";
                        break;
                    }
                case 160:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "�t�n�d�`�[";
                        break;
                    }
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END
            }

            // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
            // ���_�R�[�h
            dr[COL_SECTIONCODE_TITLE] = custSlipMngWork.SectionCode;
            // ���_����
            // TODO ���̂������A�A
            //dr[COL_SECTIONNAME_TITLE] = custSlipMngWork.SectionName;
            if ((int.Parse(custSlipMngWork.SectionCode) == 0) && (custSlipMngWork.CustomerCode == 0))
            {
                // ���_�R�[�h���[���ŁA���Ӑ�R�[�h���ݒ肳��Ă��Ȃ�
                dr[COL_SECTIONNAME_TITLE] = "�S�Ћ���";
            }
            else
            {
                dr[COL_SECTIONNAME_TITLE] = GetSectionName(custSlipMngWork.SectionCode);
            }
            // 2008.06.03 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
            // ���Ӑ�R�[�h
            dr[COL_CUSTOMERCODE_TITLE] = custSlipMngWork.CustomerCode;
            // ���Ӑ於��
            dr[COL_CUSTOMERNAME_TITLE] = custSlipMngWork.CustomerSnm;
            // ���[ID
            dr[COL_SLIPPRTSETPAPERID_TITLE] = custSlipMngWork.SlipPrtSetPaperId;

            // ADD 2008/10/06 �s��Ή�[6222] ---------->>>>>
            // ���[����
            //dr[COL_SLIPPRTSETPAPERNAME_TITLE] = GetSlipPrtSetPaperName(custSlipMngWork.SlipPrtSetPaperId);    // DEL 2009/04/17
            dr[COL_SLIPPRTSETPAPERNAME_TITLE] = GetSlipPrtSetPaperName(custSlipMngWork);                        // ADD 2009/04/17
            // ADD 2008/10/06 �s��Ή�[6222] ----------<<<<<

            // GUID
            dr[COL_GUID_TITLE] = custSlipMngWork.FileHeaderGuid;

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._custslipmngTable.Rows.Add(dr);
            }


            // �e�[�u���Ɋi�[
            if (this._custslipmngDic.ContainsKey(custSlipMngWork.FileHeaderGuid) == true)
            {
                this._custslipmngDic.Remove(custSlipMngWork.FileHeaderGuid);
            }
            this._custslipmngDic.Add(custSlipMngWork.FileHeaderGuid, custSlipMngWork);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (this._secInfoAcs == null) return sectionName;
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            ArrayList retList = new ArrayList();
            //SecInfoAcs secInfoAcs = new SecInfoAcs();     // DEL 2009/04/17

            try
            {
                //foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)          // DEL 2009/04/17
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)      // ADD 2009/04/17
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
        /// ����ݒ�p���[���̖��̎擾����
        /// </summary>
        /// <param name="slipPrtSetPaperId">����ݒ�p���[ID</param>
        /// <returns>����ݒ�p���[����</returns>
        /// <remarks>
        /// <br>Note       : ����ݒ�p���[���̂��擾���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008/10/07</br>
        /// </remarks> 
        //private string GetSlipPrtSetPaperName(string slipPrtSetPaperId)           // DEL 2009/04/17
        private string GetSlipPrtSetPaperName(CustSlipMngWork custSlipMngWork)      // ADD 2009/04/17
        {
            string slipPrtSetPaperName = "";

            // DEL 2009/04/17 ------>>>
            //ArrayList slipPrtRetList = null;

            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //int status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, this._enterpriseCode);

            //if ((status == 0) && (slipPrtRetList.Count > 0))
            //{
            //    try
            //    {

            //        foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
            //        {
            //            if (slipPrtSetPaperId.Trim() == slipPrtSet.SlipPrtSetPaperId.Trim())
            //            {
            //                slipPrtSetPaperName = slipPrtSet.SlipComment.TrimEnd();
            //            }
            //        }                   
            //    }
            //    catch
            //    {
            //        slipPrtSetPaperName = "";
            //    }
            //}
            //else
            //{
            //    slipPrtSetPaperName = "";
            //}
            // DEL 2009/04/17 ------<<<

            // ADD 2009/04/17 ------>>>
            string key = "";
            this._stringBuilder.Remove(0, this._stringBuilder.Length);
            this._stringBuilder.Append(custSlipMngWork.DataInputSystem.ToString("d2"));
            this._stringBuilder.Append(custSlipMngWork.SlipPrtKind.ToString("d4"));
            this._stringBuilder.Append(custSlipMngWork.SlipPrtSetPaperId.TrimEnd());
            key = this._stringBuilder.ToString();

            if (this._slipPrtSetPaperIdList.ContainsKey(key))
            {
                SlipPrtSet slipPrtSet = (SlipPrtSet)this._slipPrtSetPaperIdList[key];
                slipPrtSetPaperName = slipPrtSet.SlipComment.TrimEnd();
            }
            // ADD 2009/04/17 ------<<<
            
            return slipPrtSetPaperName;

        }
		#endregion

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="custSlipMng">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out CustSlipMng custSlipMng)
        {
            int status = -1;
            custSlipMng = new CustSlipMng();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add(GUIDE_ENTERPRISECODE_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                custSlipMng.DataInputSystem = (int)retObj[GUIDE_DATAINPUTSYSTEM_TITLE];              // �f�[�^���̓V�X�e��
                custSlipMng.SlipPrtKind = (int)retObj[GUIDE_SLIPPRTKIND_TITLE];                      // �`�[������
                // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                custSlipMng.SectionCode = retObj[GUIDE_SECTIONCODE_TITLE].ToString();                 // ���_�R�[�h
                //custSlipMng.SectionCode = retObj[GUIDE_SECTIONNAME_TITLE].ToString();                 // ���_����
                // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
                custSlipMng.CustomerCode = (int)retObj[GUIDE_CUSTOMERCODE_TITLE];                    // ���Ӑ�R�[�h
                custSlipMng.CustomerSnm  = retObj[GUIDE_CUSTOMERNAME_TITLE].ToString();              // ���Ӑ於��
                custSlipMng.SlipPrtSetPaperId = retObj[GUIDE_SLIPPRTSETPAPERID_TITLE].ToString();    // ���[ID
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_TITLE))
            {
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_TITLE].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // �}�X�^�e�[�u���Ǎ���
            int iCnt = 0;
            status = Search(out iCnt, enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �K�C�h�����N�����̓J�����ݒ�������Ȃ�
                        if (guideList.Tables.Count == 0)
                        {
                            DataTable table = new DataTable();
                            DataColumn column;

                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_DATAINPUTSYSTEM_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_DATAINPUTSYSTEMNAME_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKIND_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKINDNAME_TITLE;
                            table.Columns.Add(column);

                            // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SECTIONCODE_TITLE;
                            table.Columns.Add(column);
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SECTIONNAME_TITLE;
                            table.Columns.Add(column);
                            // 2008.06.03 30413 ���� ���_�R�[�h�ǉ� <<<<<<END

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CUSTOMERCODE_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CUSTOMERNAME_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTSETPAPERID_TITLE;
                            table.Columns.Add(column);

                            guideList.Tables.Add(table.Clone());
                        }

                        // �K�C�h�p�f�[�^�Z�b�g�̍쐬
                        GetGuideDataSet(ref guideList, mode);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    {
                        status = -1;
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g�쐬����
        /// </summary>
        /// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
        /// <param name="mode">�ėp�K�C�h�\���ؑ�(0:�ʏ�\�� 5:�S���\��)</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, int mode)
        {
            int dataCnt = 0;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();
            switch (mode)
            {
                // �ʏ�\��
                case 0:
                // �S���\��
                case 5:
                    {
                        while (dataCnt < this._custslipmngTable.Rows.Count)
                        {
                            // �_���폜�敪:�L��
                            if ((string)this._custslipmngTable.DefaultView[dataCnt][COL_DELETEDATE_TITLE] == "")
                            {
                                DataRow dr = retDataSet.Tables[0].NewRow();
                                dr[GUIDE_DATAINPUTSYSTEM_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_DATAINPUTSYSTEM_TITLE];
                                dr[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_DATAINPUTSYSTEMNAME_TITLE];
                                // �`�[�����ʃR�[�h
                                dr[GUIDE_SLIPPRTKIND_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SLIPPRTKIND_TITLE];
                                // �`�[�����ʖ���
                                dr[GUIDE_SLIPPRTKINDNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SLIPPRTKINDNAME_TITLE];
                                // 2008.06.04 30413 ���� ���_�R�[�h�ǉ� >>>>>>START
                                dr[GUIDE_SECTIONCODE_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SECTIONCODE_TITLE];
                                dr[GUIDE_SECTIONNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SECTIONNAME_TITLE];
                                // 2008.06.03 30413 ���� ���_�R�[�h�ǉ� <<<<<<END
                                // ���Ӑ�R�[�h
                                dr[GUIDE_CUSTOMERCODE_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_CUSTOMERCODE_TITLE];
                                // ���Ӑ於��
                                dr[GUIDE_CUSTOMERNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_CUSTOMERNAME_TITLE];
                                // ���[ID
                                dr[GUIDE_SLIPPRTSETPAPERID_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SLIPPRTSETPAPERID_TITLE];

                                retDataSet.Tables[0].Rows.Add(dr);
                            }
                            dataCnt++;
                        }
                        break;
                    }
            }
            retDataSet.Tables[0].EndLoadData();
        }

        #endregion

		// --------------------------------------------------
		#region ��r�p�N���X

        /// <summary>
        ///���Ӑ�}�X�^(�`�[�Ǘ�)��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public class CustSlipMngCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>
            /// ��r�p���\�b�h
            /// </summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 20081 �D�c �E�l</br>
            /// <br>Date       : 2007.09.18</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustSlipMng obj1 = x as CustSlipMng;
                CustSlipMng obj2 = y as CustSlipMng;

                // �`�[�����ʂŔ�r
                return obj1.SlipPrtKind.CompareTo(obj2.SlipPrtKind);
            }

            #endregion
        }

		#endregion

	}
}
