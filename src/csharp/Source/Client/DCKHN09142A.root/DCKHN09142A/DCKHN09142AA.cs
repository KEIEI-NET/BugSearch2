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

namespace Broadleaf.Application.Controller
{
	/// <summary>
    ///���Ӑ�}�X�^(�ϓ����)�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2007.09.18</br>
    /// <br>Update     : 2008/10/16 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>             2008/12/03 �Ɠc �M�u�@�o�O�C��</br>
    /// <br>             2008/12/10 �Ɠc �M�u�@�f�[�^�[�r���[�ɘ_���폜���ꂽ���Ӑ��\�����Ȃ��悤�ɏC��</br>
    /// <br>             2009/02/09 �E �K�j�@��QID:9239,10981�Ή�</br>
	/// </remarks>
	public class CustomerChangeAcs : IGeneralGuideData
	{
		// --------------------------------------------------
		#region Private Members

        // ��ƃR�[�h
        private string          _enterpriseCode = "";

        /// <summary>���Ӑ�}�X�^(�ϓ����)�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ICustomerChangeDB _iCustomerChangeDB = null;

        // �f�[�^�Z�b�g
        private DataSet   _bindDataSet = null;
        private DataTable _customerchangeTable = null;

        // �}�X�^�N���X�i�[���X�g
        private Dictionary<Guid, CustomerChangeWork> _customerchangeDic = null;  // ���Ӑ�}�X�^(�ϓ����)�i�[�p

        // �}�X�^�擾�p���X�g
        private ArrayList       _customerChangeList     = null;                  // ���Ӑ�}�X�^(�ϓ����)�擾�p

        // ���Ӑ�}�X�^�A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs = null;                    //ADD 2008/12/10 �s��Ή�[8897][8901]

        // --- ADD 2009/02/09 ��QID:10981�Ή�------------------------------------------------------>>>>>
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        // --- ADD 2009/02/09 ��QID:10981�Ή�------------------------------------------------------<<<<<

        // �K�C�h�p
        private const string GUIDE_XML_FILENAME = "CUSTOMERCHANGEGUIDEPARENT.XML";  // XML�t�@�C����
        private const string GUIDE_ENTERPRISECODE_TITLE  = "EnterpriseCode";        // ��ƃR�[�h
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";             // ���Ӑ�R�[�h
        private const string GUIDE_CUSTOMERSNM_TITLE = "CustomerSnm";          // ���Ӑ旪��
        private const string GUIDE_CREDITMONEY_TITLE = "CreditMoney";               // �^�M�z
        private const string GUIDE_WARNINGCREDITMONEY_TITLE = "WarningCreditMoney"; // �x���^�M�z
        #endregion

        // --------------------------------------------------
        #region Public Members
        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        public static readonly string TBL_CUSTOMERCHANGE_TITLE = "CUSTOMERCHANGE_TABLE";
        public static readonly string COL_DELETEDATE_TITLE = "�폜��";
        public static readonly string COL_CUSTOMERCODE_TITLE = "���Ӑ�R�[�h";
        public static readonly string COL_CUSTOMERSNM_TITLE = "���Ӑ旪��";
        public static readonly string COL_CREDITMONEY_TITLE = "�^�M�z";
        public static readonly string COL_WARNINGCREDITMONEY_TITLE = "�x���^�M�z";
        public static readonly string COL_PRSNTACCRECBALANCE_TITLE = "���ݔ��|�c��";
        public static readonly string COL_PRESENTCUSTSLIPNO_TITLE = "���ݓ��Ӑ�`�[�ԍ�";
        public static readonly string COL_STARTCUSTSLIPNO_TITLE = "�J�n���Ӑ�`�[�ԍ�";
        public static readonly string COL_ENDCUSTSLIPNO_TITLE = "�I�����Ӑ�`�[�ԍ�";
        public static readonly string COL_NOCHARCTERCOUNT_TITLE = "�ԍ�����";
        public static readonly string COL_CUSTSLIPNOHEADER_TITLE = "���Ӑ�`�[�ԍ��w�b�_";
        public static readonly string COL_CUSTSLIPNOFOOTER_TITLE = "���Ӑ�`�[�ԍ��t�b�^";
        public static readonly string COL_GUID_TITLE = "GUID";
        #endregion        
        // --------------------------------------------------
		#region Constructor

		/// <summary>
        ///���Ӑ�}�X�^(�ϓ����)�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public CustomerChangeAcs()
		{
			try {
				// ��ƃR�[�h�擾
				this._enterpriseCode    = LoginInfoAcquisition.EnterpriseCode;

				// �����[�g�I�u�W�F�N�g�擾
                this._iCustomerChangeDB = (ICustomerChangeDB)MediationCustomerChangeDB.GetCustomerChangeDB();

                // �}�X�^�N���X�i�[���X�g������
                this._customerchangeDic = new Dictionary<Guid, CustomerChangeWork>();

                // �}�X�^�擾�p���X�g������
                this._customerChangeList = new ArrayList();

                // �f�[�^�Z�b�g������
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();

                //���Ӑ�}�X�^�A�N�Z�X�N���X�C���X�^���X��
                this._customerSearchAcs = new CustomerSearchAcs();          //ADD 2008/12/10 �s��Ή�[8897][8901]

                // --- ADD 2009/02/09 ��QID:10981�Ή�------------------------------------------------------>>>>>
                ReadCustomerSearchRet();
                // --- ADD 2009/02/09 ��QID:10981�Ή�------------------------------------------------------<<<<<
            }
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
                this._iCustomerChangeDB = null;
			}
		}

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
			// ���Ӑ�}�X�^(�ϓ����)�e�[�u��
            this._customerchangeTable = new DataTable(TBL_CUSTOMERCHANGE_TITLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			this._customerchangeTable.Columns.Add( COL_DELETEDATE_TITLE , typeof( string ) );       // �폜��
            this._customerchangeTable.Columns.Add( COL_CUSTOMERCODE_TITLE , typeof(Int32));         // ���Ӑ�R�[�h
            this._customerchangeTable.Columns.Add( COL_CUSTOMERSNM_TITLE , typeof( string ) );      // ���Ӑ於��
            this._customerchangeTable.Columns.Add( COL_CREDITMONEY_TITLE , typeof(Int64));          // �^�M�z
            this._customerchangeTable.Columns.Add( COL_WARNINGCREDITMONEY_TITLE , typeof(Int64));   // �x���^�M�z
            this._customerchangeTable.Columns.Add( COL_PRSNTACCRECBALANCE_TITLE , typeof(Int64));   // ���ݔ��|�c��
            //--- DEL 2008/06/26 ---------->>>>>
            //this._customerchangeTable.Columns.Add(COL_PRESENTCUSTSLIPNO_TITLE, typeof(Int64));    // ���ݓ��Ӑ�`�[�ԍ�
            //this._customerchangeTable.Columns.Add(COL_STARTCUSTSLIPNO_TITLE, typeof(Int64));      // �J�n���Ӑ�`�[�ԍ�
            //this._customerchangeTable.Columns.Add(COL_ENDCUSTSLIPNO_TITLE, typeof(Int64));        // �I�����Ӑ�`�[�ԍ�
            //this._customerchangeTable.Columns.Add(COL_NOCHARCTERCOUNT_TITLE, typeof(Int32));      // �ԍ�����
            //this._customerchangeTable.Columns.Add(COL_CUSTSLIPNOHEADER_TITLE, typeof(string));    // ���Ӑ�`�[�ԍ��w�b�_
            //this._customerchangeTable.Columns.Add(COL_CUSTSLIPNOFOOTER_TITLE, typeof(string));    // ���Ӑ�`�[�ԍ��t�b�^
            //--- DEL 2008/06/26 ---------->>>>>
            this._customerchangeTable.Columns.Add(COL_GUID_TITLE, typeof(Guid));  // GUID
            // PrimaryKey�ݒ�
            this._customerchangeTable.PrimaryKey = new DataColumn[] { this._customerchangeTable.Columns[COL_CUSTOMERCODE_TITLE] };  // ���Ӑ�R�[�h
                                                                   
            this._bindDataSet.Tables.Add(this._customerchangeTable);
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
			if( this._iCustomerChangeDB == null ) {
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
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Read(out CustomerChange customerChange, string enterpriseCode, Int32 customerCode)
		{
            return this.ReadProc(out customerChange, enterpriseCode, customerCode);
		}

		/// <summary>
        ///���Ӑ�}�X�^(�ϓ����)�ǂݍ��ݏ���
		/// </summary>
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int ReadProc(out CustomerChange customerChange, string enterpriseCode, Int32 customerCode)
		{
            int status1 = 0;

            customerChange = null;

            try
            {
                // �L�[�����Z�b�g
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                customerChangeWork.EnterpriseCode = enterpriseCode;   // ��ƃR�[�h
                customerChangeWork.CustomerCode = customerCode;       // ���Ӑ�R�[�h

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(customerChangeWork);

                //���Ӑ�}�X�^(�ϓ����)�ǂݍ���
                status1 = this._iCustomerChangeDB.Read(ref parabyte, 0);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�V���A���C�Y����
                    customerChangeWork = (CustomerChangeWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustomerChangeWork));
                    // ���ʂ������o�R�s�[
                    customerChange = this.CopyToCustomerChangeFromCustomerChangeWork(customerChangeWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                customerChange = null;
                this._iCustomerChangeDB = null;

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
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Write(CustomerChange customerChange)
        {
            // ���Ӑ�}�X�^(�ϓ����)�X�V
            return this.WriteProc(customerChange);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�ϓ����)�������ݏ���
		/// </summary>
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int WriteProc(CustomerChange customerChange)
		{
			int status = 0;

			try {
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();

                // �ҏW�O���擾
                if (this._customerchangeDic.ContainsKey(customerChange.FileHeaderGuid) == true)
                {
                    customerChangeWork = (this._customerchangeDic[customerChange.FileHeaderGuid] as CustomerChangeWork);
                }

                // �ҏW���擾
                CopyToCustomerChangeWorkFromDispCustomerChange(ref customerChangeWork, customerChange);

                object retObj = (object)customerChangeWork;

                //���Ӑ�}�X�^(�ϓ����)��������
                status = this._iCustomerChangeDB.Write(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    customerChangeWork = (CustomerChangeWork)retArray[0];
                    this.CustomerChangeWorkToDataSet(customerChangeWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustomerChangeDB = null;

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
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�ϓ����)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // ���Ӑ�}�X�^(�ϓ����)�_���폜
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�ϓ����)�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�ϓ����)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

                object retObj = (object)customerChangeWork;

                //���Ӑ�}�X�^(�ϓ����)�_���폜
                status = this._iCustomerChangeDB.LogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    customerChangeWork = (CustomerChangeWork)retObj;
                    this.CustomerChangeWorkToDataSet(customerChangeWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustomerChangeDB = null;

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
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�ϓ����)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // ���Ӑ�}�X�^(�ϓ����)����
            return this.RevivalProc(fileHeaderGuid);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�ϓ����)�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�ϓ����)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

                object retObj = (object)customerChangeWork;

                //���Ӑ�}�X�^(�ϓ����)�_���폜����
                status = this._iCustomerChangeDB.RevivalLogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // �f�[�^�Z�b�g�ɒǉ�
                    customerChangeWork = (CustomerChangeWork)retObj;
                    this.CustomerChangeWorkToDataSet(customerChangeWork);
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustomerChangeDB = null;

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
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�ϓ����)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // ���Ӑ�}�X�^(�ϓ����)�����폜
            return this.DeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///���Ӑ�}�X�^(�ϓ����)�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ�}�X�^(�ϓ����)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // �ҏW�O���擾
                CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(customerChangeWork);

                //���Ӑ�}�X�^(�ϓ����)�����폜
                status = this._iCustomerChangeDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._customerchangeDic.Remove(customerChangeWork.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    DataRow dr = this._customerchangeTable.Rows.Find(customerChangeWork.CustomerCode);
                    
                    dr.Delete();
				}
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCustomerChangeDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Search Methods

		/// <summary>
		/// ��������(�_���폜����)�i�I�[�o�[���[�h)
		/// </summary>
		/// <param name="customerChangeList">���Ӑ�ϓ���񃊃X�g(ArrayList)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2007.01.17</br>
		/// </remarks>
		public int Search( out List<CustomerChange> customerChangeList, string enterpriseCode )
		{
			int totalCount;
			customerChangeList = new List<CustomerChange>();
			int status = this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (CustomerChangeWork customerChangeWork in (ArrayList)this._customerChangeList)
				{
					customerChangeList.Add(this.CopyToCustomerChangeFromCustomerChangeWork(customerChangeWork));
				}
			}

			return status;
		}

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
            // ���Ӑ�}�X�^(�ϓ����)����
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }

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
            // ���Ӑ�}�X�^(�ϓ����)����
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        // --- ADD 2009/02/09 ��QID:9239�Ή�------------------------------------------------------>>>>>
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">���Ӑ�}�X�^(�ϓ����)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            retList = new ArrayList();

            int totalCount;

            int status = this.SearchCustomerChangeProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList = (ArrayList)this._customerChangeList.Clone();
            }

            return (status);
        }
        // --- ADD 2009/02/09 ��QID:9239�Ή�------------------------------------------------------<<<<<

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

            // ���Ӑ�}�X�^(�ϓ����)����
            status1 = this.SearchCustomerChangeProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // �L���b�V������
            status2 = this.Cache(this._customerChangeList);
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

        /// <summary>
        ///���Ӑ�}�X�^(�ϓ����)��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�̌����������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private int SearchCustomerChangeProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._customerChangeList.Clear();

                // �L���b�V���p�e�[�u�����N���A
                this._customerchangeDic.Clear();

                // �L�[�����Z�b�g
                CustomerChangeWork paramCustomerChangeWork = new CustomerChangeWork();
                paramCustomerChangeWork.EnterpriseCode = enterpriseCode;    // ��ƃR�[�h

                object retobj = null;

                //���Ӑ�}�X�^(�ϓ����)����
                status = this._iCustomerChangeDB.Search(out retobj, paramCustomerChangeWork, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //this._customerChangeList = retobj as ArrayList;                       //DEL 2008/12/10 �s��Ή�[8897][8901]�@�_���폜���ꂽ���Ӑ�͑ΏۂƂ��Ȃ���
                    this._customerChangeList = this.CheckCustomerLogicalDelete(retobj);     //ADD 2008/12/10 �s��Ή�[8897][8901]

                    // �Y�������i�[
                    totalCount = this._customerChangeList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCustomerChangeDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        //--- ADD 2008/12/09 �s��Ή�[8897][8901] --------------------------------------------->>>>>
        /// <summary>
        /// ���Ӑ�R�[�h���݃`�F�b�N(���Ӑ�R�[�h���_���폜����Ă�����̂�NG�Ƃ���)
        /// </summary>
        /// <param name="obj">�Ώۃf�[�^</param>
        /// <returns>�_���폜���ꂽ���Ӑ悪�����ꂽ�f�[�^</returns>
        private ArrayList CheckCustomerLogicalDelete(object obj)
        {
            ArrayList arrayList = obj as ArrayList;             //�Ώۃf�[�^
            ArrayList retArrayList = new ArrayList();           //�u�_���폜���ꂽ���Ӑ�v�폜��f�[�^
            CustomerSearchPara customerSearchPara = null;       //���Ӑ�}�X�^���o����

            CustomerChangeWork data = null;
            for (int i = 0; i <= arrayList.Count - 1; i++)
            {
                data = (CustomerChangeWork)arrayList[i];
                if (data.CustomerCode == 0)
                {
                    continue;
                }

                // ���o����
                customerSearchPara = new CustomerSearchPara();
                customerSearchPara.EnterpriseCode = this._enterpriseCode;
                customerSearchPara.CustomerCode = data.CustomerCode;

                int logicalDeleteCode = this.GetCustomerLogicalDelete(customerSearchPara);
                if (logicalDeleteCode == 0)
                {
                    retArrayList.Add(data);
                }
            }
            return retArrayList;
        }

        /// <summary>
        /// ���Ӑ�_���폜�敪�擾
        /// </summary>
        /// <param name="customerSearchPara">���Ӑ撊�o����</param>
        /// <returns>�_���폜�敪</returns>
        public int GetCustomerLogicalDelete(CustomerSearchPara customerSearchPara)
        {
            int status = -1;

            // --- CHG 2009/02/09 ��QID:10981�Ή�------------------------------------------------------>>>>>
            //CustomerSearchRet[] customerSearchRetArray = null;

            //// ���Ӑ�}�X�^�擾
            //customerSearchRetArray = null;
            //status = this._customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            //if (status != 0)
            //{
            //    return status;
            //}
            //if (customerSearchRetArray.Length <= 0)
            //{
            //    return status;
            //}

            //foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
            //{
            //    status = customerSearchRet.LogicalDeleteCode;
            //    break;
            //}

            if (this._customerSearchRetDic.ContainsKey(customerSearchPara.CustomerCode))
            {
                status = this._customerSearchRetDic[customerSearchPara.CustomerCode].LogicalDeleteCode;
            }
            // --- CHG 2009/02/09 ��QID:10981�Ή�------------------------------------------------------<<<<<

            return status;
        }
        //--- ADD 2008/12/09 �s��Ή�[8897][8901] ---------------------------------------------<<<<<

        // --- ADD 2009/02/09 ��QID:10981�Ή�------------------------------------------------------>>>>>
        /// <summary>
        /// ���Ӑ�}�X�^�擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private int ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            CustomerSearchRet[] customerSearchRetArray;
            int status = this._customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet ret in customerSearchRetArray)
                {
                    this._customerSearchRetDic.Add(ret.CustomerCode, ret.Clone());
                }
            }

            return (status);
        }
        // --- ADD 2009/02/09 ��QID:10981�Ή�------------------------------------------------------<<<<<
        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// �}�X�^�L���b�V������
        /// </summary>
        /// <param name="customerChangeList">�`�[�Ǘ��}�X�^�擾���ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int Cache(ArrayList customerChangeList)
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._customerchangeTable.BeginLoadData();

                    // �e�[�u�����N���A
                    this._customerchangeTable.Clear();

                    // �`�[�Ǘ��f�[�^��DataSet�Ɋi�[
                    foreach (CustomerChangeWork customerChangeWork in customerChangeList)
                    {
                        // ���o�^�̎�
                        if (this._customerchangeDic.ContainsKey(customerChangeWork.FileHeaderGuid) == false)
                        {
                            // �f�[�^�Z�b�g�ɒǉ�
                            this.CustomerChangeWorkToDataSet(customerChangeWork);
                        }
                    }
                }
                finally
                {
                    // �X�V�����I��
                    this._customerchangeTable.EndLoadData();
                    
                    // �\�[�g
                    this._customerchangeTable.DefaultView.Sort = COL_CUSTOMERCODE_TITLE + " ASC";       // ���Ӑ�R�[�h
                    this._customerchangeTable.AcceptChanges();
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
        /// �N���X�����o�R�s�[���� (��ʕύX���Ӑ�}�X�^(�ϓ����)�N���X�˓��Ӑ�}�X�^(�ϓ����)���[�N�N���X)
        /// </summary>
        /// <param name="customerChangeWork">���Ӑ�}�X�^(�ϓ����)���[�N�N���X</param>
        /// <param name="customerChange">���Ӑ�}�X�^(�ϓ����)�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX���Ӑ�}�X�^(�ϓ����)�N���X����
        ///                  ���Ӑ�}�X�^(�ϓ����)���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void CopyToCustomerChangeWorkFromDispCustomerChange(ref CustomerChangeWork customerChangeWork, CustomerChange customerChange)
        {
            customerChangeWork.EnterpriseCode  = customerChange.EnterpriseCode;         // ��ƃR�[�h
            customerChangeWork.CustomerCode    = customerChange.CustomerCode;           // ���Ӑ�R�[�h
            //customerChangeWork.CustomerSnm    = customerChange.CustomerSnm;           // ���Ӑ旪��     // DEL 2008/06/23
            customerChangeWork.CreditMoney = customerChange.CreditMoney;
            customerChangeWork.WarningCreditMoney = customerChange.WarningCreditMoney;  // �x���^�M�z
            customerChangeWork.PrsntAccRecBalance = customerChange.PrsntAccRecBalance;  // ���ݔ��|�c��
            //--- DEL 2008/06/23 ---------->>>>>
            //customerChangeWork.PresentCustSlipNo = customerChange.PresentCustSlipNo;  // ���ݓ��Ӑ�`�[�ԍ�
            //customerChangeWork.StartCustSlipNo = customerChange.StartCustSlipNo;      // �J�n���Ӑ�`�[�ԍ�
            //customerChangeWork.EndCustSlipNo = customerChange.EndCustSlipNo;          // �I�����Ӑ�`�[�ԍ�
            //customerChangeWork.NoCharcterCount = customerChange.NoCharcterCount;      // �ԍ�����
            //customerChangeWork.CustSlipNoHeader = customerChange.CustSlipNoHeader;    // ���Ӑ�`�[�ԍ��w�b�_
            //customerChangeWork.CustSlipNoFooter = customerChange.CustSlipNoFooter;    // ���Ӑ�`�[�ԍ��t�b�^
            //--- DEL 2008/06/23 ----------<<<<<
        }

		/// <summary>
        /// �N���X�����o�R�s�[���� (���Ӑ�}�X�^(�ϓ����)���[�N�N���X�˓��Ӑ�}�X�^(�ϓ����)�N���X)
		/// </summary>
        /// <param name="customerChangeWork">���Ӑ�}�X�^(�ϓ����)���[�N�N���X</param>
        /// <returns>���Ӑ�}�X�^(�ϓ����)�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)���[�N�N���X����
        ///                  ���Ӑ�}�X�^(�ϓ����)�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private CustomerChange CopyToCustomerChangeFromCustomerChangeWork(CustomerChangeWork customerChangeWork)
        {
            CustomerChange customerChange = new CustomerChange();

            customerChange.CreateDateTime = customerChangeWork.CreateDateTime;        // �쐬����
            customerChange.UpdateDateTime = customerChangeWork.UpdateDateTime;        // �X�V����
            customerChange.EnterpriseCode = customerChangeWork.EnterpriseCode;        // ��ƃR�[�h
            customerChange.FileHeaderGuid = customerChangeWork.FileHeaderGuid;        // GUID
            customerChange.UpdEmployeeCode = customerChangeWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            customerChange.UpdAssemblyId1 = customerChangeWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            customerChange.UpdAssemblyId2 = customerChangeWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            customerChange.LogicalDeleteCode = customerChangeWork.LogicalDeleteCode;  // �_���폜�敪
            customerChange.CustomerCode = customerChangeWork.CustomerCode;            // ���Ӑ�R�[�h
            //customerChange.CustomerSnm = customerChangeWork.CustomerSnm;              // ���Ӑ旪��       // DEL 2008/06/23
            customerChange.CreditMoney = customerChangeWork.CreditMoney;              // �^�M�z 
            customerChange.WarningCreditMoney = customerChangeWork.WarningCreditMoney;// �x���^�M�z
            customerChange.PrsntAccRecBalance = customerChangeWork.PrsntAccRecBalance;// ���ݔ��|�c��
            //--- DEL 2008/06/23 ---------->>>>>
            //customerChange.PresentCustSlipNo = customerChangeWork.PresentCustSlipNo;  // ���ݓ��Ӑ�`�[�ԍ�
            //customerChange.StartCustSlipNo = customerChangeWork.StartCustSlipNo;      // �J�n���Ӑ�`�[�ԍ�
            //customerChange.EndCustSlipNo = customerChangeWork.EndCustSlipNo;          // �I�����Ӑ�`�[�ԍ�
            //customerChange.NoCharcterCount = customerChangeWork.NoCharcterCount;      // �ԍ�����
            //customerChange.CustSlipNoHeader = customerChangeWork.CustSlipNoHeader;    // ���Ӑ�`�[�ԍ��w�b�_
            //customerChange.CustSlipNoFooter = customerChangeWork.CustSlipNoFooter;    // ���Ӑ�`�[�ԍ��t�b�^
            //--- DEL 2008/06/23 ----------<<<<<

            // �e�[�u���X�V
            _customerchangeDic[customerChangeWork.FileHeaderGuid] = customerChangeWork;

            return customerChange;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g���C��DataSet�W�J����
        /// </summary>
        /// <param name="customerChangeWork">���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private void CustomerChangeWorkToDataSet(CustomerChangeWork customerChangeWork)
        {
            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            DataRow dr = this._customerchangeTable.Rows.Find(customerChangeWork.CustomerCode);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._customerchangeTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // �폜��
            if (customerChangeWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", customerChangeWork.UpdateDateTime);
            }

            // ���Ӑ�R�[�h
            dr[COL_CUSTOMERCODE_TITLE] = customerChangeWork.CustomerCode;
            // ���Ӑ旪��
            dr[COL_CUSTOMERSNM_TITLE] = GetCustomerName(customerChangeWork.CustomerCode);
            // �^�M�z
            dr[COL_CREDITMONEY_TITLE] = customerChangeWork.CreditMoney;
            // �x���^�M�z
            dr[COL_WARNINGCREDITMONEY_TITLE] = customerChangeWork.WarningCreditMoney;
            // ���ݔ��|�c��
            dr[COL_PRSNTACCRECBALANCE_TITLE] = customerChangeWork.PrsntAccRecBalance;

            //--- DEL 2008/06/23 ---------->>>>>
            //// ���ݓ��Ӑ�`�[�ԍ�
            //dr[COL_PRESENTCUSTSLIPNO_TITLE] = customerChangeWork.PresentCustSlipNo;
            //// �J�n���Ӑ�`�[�ԍ�
            //dr[COL_STARTCUSTSLIPNO_TITLE] = customerChangeWork.StartCustSlipNo;
            //// �I�����Ӑ�`�[�ԍ�
            //dr[COL_ENDCUSTSLIPNO_TITLE] = customerChangeWork.EndCustSlipNo;
            //// �ԍ�����
            //dr[COL_NOCHARCTERCOUNT_TITLE] = customerChangeWork.NoCharcterCount;
            //// ���Ӑ�`�[�ԍ��w�b�_
            //dr[COL_CUSTSLIPNOHEADER_TITLE] = customerChangeWork.CustSlipNoHeader;
            //// ���Ӑ�`�[�ԍ��t�b�^
            //dr[COL_CUSTSLIPNOFOOTER_TITLE] = customerChangeWork.CustSlipNoFooter;
            //--- DEL 2008/06/23 ----------<<<<<

            // GUID
            dr[COL_GUID_TITLE] = customerChangeWork.FileHeaderGuid;

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._customerchangeTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._customerchangeDic.ContainsKey(customerChangeWork.FileHeaderGuid) == true)
            {
                this._customerchangeDic.Remove(customerChangeWork.FileHeaderGuid);
            }
            this._customerchangeDic.Add(customerChangeWork.FileHeaderGuid, customerChangeWork);
        }
		#endregion

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerChange">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out CustomerChange customerChange)
        {
            int status = -1;
            customerChange = new CustomerChange();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add(GUIDE_ENTERPRISECODE_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                customerChange.CustomerCode = (Int32)retObj[GUIDE_CUSTOMERCODE_TITLE];               // ���Ӑ�R�[�h
                //customerChange.CustomerSnm = retObj[GUIDE_CUSTOMERSNM_TITLE].ToString();             // ���Ӑ旪��    // DEL 2008/06/23
                customerChange.CreditMoney = (Int64)retObj[GUIDE_CREDITMONEY_TITLE];                 // �^�M�z
                customerChange.WarningCreditMoney = (Int64)retObj[GUIDE_WARNINGCREDITMONEY_TITLE];   // �x���^�M�z

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
                            column.ColumnName = GUIDE_CUSTOMERCODE_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CUSTOMERSNM_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CREDITMONEY_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_WARNINGCREDITMONEY_TITLE;
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
                        while (dataCnt < this._customerchangeTable.Rows.Count)
                        {
                            // �_���폜�敪:�L��
                            if ((string)this._customerchangeTable.DefaultView[dataCnt][COL_DELETEDATE_TITLE] == "")
                            {
                                DataRow dr = retDataSet.Tables[0].NewRow();
                                // ���Ӑ�R�[�h
                                dr[GUIDE_CUSTOMERCODE_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_CUSTOMERCODE_TITLE];
                                // ���Ӑ於��
                                dr[GUIDE_CUSTOMERSNM_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_CUSTOMERSNM_TITLE];
                                // �^�M�z
                                dr[GUIDE_CREDITMONEY_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_CREDITMONEY_TITLE];
                                // �x���^�M�z
                                dr[GUIDE_WARNINGCREDITMONEY_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_WARNINGCREDITMONEY_TITLE];

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
        ///���Ӑ�}�X�^(�ϓ����)��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public class CustomerChangeCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>
            /// ��r�p���\�b�h
            /// </summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 20081 �D�c �E�l</br>
            /// <br>Date       : 2007.09.18</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustomerChange obj1 = x as CustomerChange;
                CustomerChange obj2 = y as CustomerChange;

                // ���Ӑ�R�[�h�Ŕ�r
                return obj1.CustomerCode.CompareTo(obj2.CustomerCode);
            }

            #endregion
        }

		#endregion

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

            // --- CHG 2009/02/09 ��QID:10981�Ή�------------------------------------------------------>>>>>
            //int status;

            //CustomerInfo customerInfo = new CustomerInfo();
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            //try
            //{
            //    status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

            //    if (status == 0)
            //    {
            //        customerName = customerInfo.CustomerSnm.Trim();
            //    }
            //}
            //catch
            //{
            //    customerName = "";
            //}
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
            }
            // --- CHG 2009/02/09 ��QID:10981�Ή�------------------------------------------------------<<<<<

            return customerName;
        }
        //--- ADD 2008/06/24 ----------<<<<<

        // --- ADD 2008/10/16 ------------------------------------------------------------------------------------------>>>>>
        /// <summary>
        /// �^�M�Ǘ��敪�擾����
        /// </summary>
        /// <param name="fileHeaderGuid">���Ӑ���擾�pKey</param>
        /// <param name="creditMngCode">�^�M�Ǘ��敪</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �^�M�Ǘ��敪���擾���܂��B</br>
        /// <br>Programmer :       �Ɠc �M�u</br>
        /// <br>Date       : 2008/10/16</br>
        /// </remarks>
        public bool GetCreditMngCode(Guid fileHeaderGuid, out int creditMngCode)
        {
            return this.GetCreditMngCodeProc(fileHeaderGuid, out creditMngCode);
        }
        private bool GetCreditMngCodeProc(Guid fileHeaderGuid, out int creditMngCode)
        {
            creditMngCode = 0;

            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            // ���Ӑ���擾
            CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

            //int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerChangeWork.CustomerCode, out customerInfo);     //DEL 2008/12/03 ���Ӑ悪�_���폜���ꂽ�ϓ����ɑ΂��č폜���s���ƃG���[�ƂȂ��
            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetDataAll, this._enterpriseCode, customerChangeWork.CustomerCode, out customerInfo);    //ADD 2008/12/03
            if (status == 0)
            {
                creditMngCode = customerInfo.CreditMngCode;     // �^�M�Ǘ��敪
                return true;
            }

            return false;
        }
        // --- ADD 2008/10/16 ------------------------------------------------------------------------------------------<<<<<
    }
}
