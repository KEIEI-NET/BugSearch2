using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CompanyInf
	/// <summary>
	///                      ���Џ��
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Џ��w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/7/25</br>
	/// <br>Genarated Date   :   2008/01/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/01/09  ����</br>
	/// <br>                 :   �����Ǘ��敪�̒ǉ��i�S�̏����l�ݒ�}�X�^����ړ��j</br>
    /// <br>Update Note      :   2008/06/03  �E�@�K�j</br>
    /// <br>                 :   �����Ǘ��敪����u���_�{���{�ہv���폜</br>
    /// <br>Update Note      :   2011/07/14  LDNS wangqx</br>
    /// <br>                 :   �f�[�^�N���A�������s�N�����A�f�[�^�N���A�������s�����b�~���b��ǉ�</br>
	/// </remarks>
	public class CompanyInf
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>���ЃR�[�h</summary>
		private Int32 _companyCode;

		/// <summary>���В���</summary>
		/// <remarks>DD�@����N�������Z�o����閖�������ł��邱�Ɗ�����̓����z����l</remarks>
		private Int32 _companyTotalDay;

		/// <summary>��v�N�x</summary>
		/// <remarks>YYYY</remarks>
		private Int32 _financialYear;

		/// <summary>����</summary>
		/// <remarks>MM</remarks>
		private Int32 _companyBiginMonth;

		/// <summary>����2</summary>
		/// <remarks>MM</remarks>
		private Int32 _companyBiginMonth2;

		/// <summary>����N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _companyBiginDate;

		/// <summary>�J�n�N�敪</summary>
		/// <remarks>0:�O�N 1:���N</remarks>
		private Int32 _startYearDiv;

		/// <summary>�J�n���敪</summary>
		/// <remarks>0:�O�� 1:����</remarks>
		private Int32 _startMonthDiv;

		/// <summary>���Ж���1</summary>
		private string _companyName1 = "";

		/// <summary>���Ж���2</summary>
		private string _companyName2 = "";

		/// <summary>�X�֔ԍ�</summary>
		private string _postNo = "";

		/// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
		private string _address1 = "";

		/// <summary>�Z��2�i���ځj</summary>
		private Int32 _address2;

		/// <summary>�Z��3�i�Ԓn�j</summary>
		private string _address3 = "";

		/// <summary>�Z��4�i�A�p�[�g���́j</summary>
		private string _address4 = "";

		/// <summary>���Гd�b�ԍ�1</summary>
		private string _companyTelNo1 = "";

		/// <summary>���Гd�b�ԍ�2</summary>
		private string _companyTelNo2 = "";

		/// <summary>���Гd�b�ԍ�3</summary>
		private string _companyTelNo3 = "";

		/// <summary>���Гd�b�ԍ��^�C�g��1</summary>
		private string _companyTelTitle1 = "";

		/// <summary>���Гd�b�ԍ��^�C�g��2</summary>
		private string _companyTelTitle2 = "";

		/// <summary>���Гd�b�ԍ��^�C�g��3</summary>
		private string _companyTelTitle3 = "";

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
		/// <summary>�����Ǘ��敪</summary>
		/// <remarks>0:���_�@1:���_�{���@2:���_�{���{��</remarks>
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>�����Ǘ��敪</summary>
        /// <remarks>0:���_�@1:���_�{��</remarks>
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        private Int32 _secMngDiv;

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>�f�[�^�N���A�������s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataClrExecDate;

        /// <summary>�f�[�^�N���A�������s�����b�~���b</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _dataClrExecTime;
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>�f�[�^�ۑ�����</summary>
        private Int32 _dataSaveMonths;

        /// <summary>�f�[�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataCompressDt;

        /// <summary>���уf�[�^�ۑ�����</summary>
        private Int32 _resultDtSaveMonths;

        /// <summary>���уf�[�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _resultDtCompressDt;

        /// <summary>���q���i�f�[�^�ۑ�����</summary>
        private Int32 _caPrtsDtSaveMonths;

        /// <summary>���q���i�f�[�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _caPrtsDtCompressDt;

        /// <summary>�}�X�^�ۑ�����</summary>
        private Int32 _masterSaveMonths;

        /// <summary>�}�X�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _masterCompressDt;

		/// <summary>�|���D��敪</summary>
		/// <remarks>0:���_�D�� 1:�ݒ�敪�D��</remarks>
		private Int32 _ratePriorityDiv;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";


		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  CompanyCode
		/// <summary>���ЃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ЃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CompanyCode
		{
			get{return _companyCode;}
			set{_companyCode = value;}
		}

		/// public propaty name  :  CompanyTotalDay
		/// <summary>���В����v���p�e�B</summary>
		/// <value>DD�@����N�������Z�o����閖�������ł��邱�Ɗ�����̓����z����l</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���В����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CompanyTotalDay
		{
			get{return _companyTotalDay;}
			set{_companyTotalDay = value;}
		}

		/// public propaty name  :  FinancialYear
		/// <summary>��v�N�x�v���p�e�B</summary>
		/// <value>YYYY</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��v�N�x�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FinancialYear
		{
			get{return _financialYear;}
			set{_financialYear = value;}
		}

		/// public propaty name  :  CompanyBiginMonth
		/// <summary>���񌎃v���p�e�B</summary>
		/// <value>MM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���񌎃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CompanyBiginMonth
		{
			get{return _companyBiginMonth;}
			set{_companyBiginMonth = value;}
		}

		/// public propaty name  :  CompanyBiginMonth2
		/// <summary>����2�v���p�e�B</summary>
		/// <value>MM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CompanyBiginMonth2
		{
			get{return _companyBiginMonth2;}
			set{_companyBiginMonth2 = value;}
		}

		/// public propaty name  :  CompanyBiginDate
		/// <summary>����N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CompanyBiginDate
		{
			get{return _companyBiginDate;}
			set{_companyBiginDate = value;}
		}

		/// public propaty name  :  StartYearDiv
		/// <summary>�J�n�N�敪�v���p�e�B</summary>
		/// <value>0:�O�N 1:���N</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartYearDiv
		{
			get{return _startYearDiv;}
			set{_startYearDiv = value;}
		}

		/// public propaty name  :  StartMonthDiv
		/// <summary>�J�n���敪�v���p�e�B</summary>
		/// <value>0:�O�� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartMonthDiv
		{
			get{return _startMonthDiv;}
			set{_startMonthDiv = value;}
		}

		/// public propaty name  :  CompanyName1
		/// <summary>���Ж���1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ж���1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyName1
		{
			get{return _companyName1;}
			set{_companyName1 = value;}
		}

		/// public propaty name  :  CompanyName2
		/// <summary>���Ж���2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ж���2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyName2
		{
			get{return _companyName2;}
			set{_companyName2 = value;}
		}

		/// public propaty name  :  PostNo
		/// <summary>�X�֔ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�֔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PostNo
		{
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  Address1
		/// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address1
		{
			get{return _address1;}
			set{_address1 = value;}
		}

		/// public propaty name  :  Address2
		/// <summary>�Z��2�i���ځj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��2�i���ځj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Address2
		{
			get{return _address2;}
			set{_address2 = value;}
		}

		/// public propaty name  :  Address3
		/// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address3
		{
			get{return _address3;}
			set{_address3 = value;}
		}

		/// public propaty name  :  Address4
		/// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address4
		{
			get{return _address4;}
			set{_address4 = value;}
		}

		/// public propaty name  :  CompanyTelNo1
		/// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo1
		{
			get{return _companyTelNo1;}
			set{_companyTelNo1 = value;}
		}

		/// public propaty name  :  CompanyTelNo2
		/// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo2
		{
			get{return _companyTelNo2;}
			set{_companyTelNo2 = value;}
		}

		/// public propaty name  :  CompanyTelNo3
		/// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo3
		{
			get{return _companyTelNo3;}
			set{_companyTelNo3 = value;}
		}

		/// public propaty name  :  CompanyTelTitle1
		/// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelTitle1
		{
			get{return _companyTelTitle1;}
			set{_companyTelTitle1 = value;}
		}

		/// public propaty name  :  CompanyTelTitle2
		/// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelTitle2
		{
			get{return _companyTelTitle2;}
			set{_companyTelTitle2 = value;}
		}

		/// public propaty name  :  CompanyTelTitle3
		/// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelTitle3
		{
			get{return _companyTelTitle3;}
			set{_companyTelTitle3 = value;}
		}

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  SecMngDiv
		/// <summary>�����Ǘ��敪�v���p�e�B</summary>
		/// <value>0:���_�@1:���_�{���@2:���_�{���{��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Ǘ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  SecMngDiv
        /// <summary>�����Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���_�@1:���_�{��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        public Int32 SecMngDiv
		{
			get{return _secMngDiv;}
			set{_secMngDiv = value;}
		}

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DataClrExecDate
        /// <summary>�f�[�^�N���A�������s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�N���A�������s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataClrExecDate
        {
            get { return _dataClrExecDate; }
            set { _dataClrExecDate = value; }
        }

        /// public propaty name  :  DataClrExecTime
        /// <summary>�f�[�^�N���A�������s�����b�~���b�v���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�N���A�������s�����b�~���b�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataClrExecTime
        {
            get { return _dataClrExecTime; }
            set { _dataClrExecTime = value; }
        }
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        /// public propaty name  :  DataSaveMonths
        /// <summary>�f�[�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSaveMonths
        {
            get { return _dataSaveMonths; }
            set { _dataSaveMonths = value; }
        }

        /// public propaty name  :  DataCompressDt
        /// <summary>�f�[�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataCompressDt
        {
            get { return _dataCompressDt; }
            set { _dataCompressDt = value; }
        }

        /// public propaty name  :  ResultDtSaveMonths
        /// <summary>���уf�[�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���уf�[�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ResultDtSaveMonths
        {
            get { return _resultDtSaveMonths; }
            set { _resultDtSaveMonths = value; }
        }

        /// public propaty name  :  ResultDtCompressDt
        /// <summary>���уf�[�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���уf�[�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ResultDtCompressDt
        {
            get { return _resultDtCompressDt; }
            set { _resultDtCompressDt = value; }
        }

        /// public propaty name  :  CaPrtsDtSaveMonths
        /// <summary>���q���i�f�[�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���i�f�[�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CaPrtsDtSaveMonths
        {
            get { return _caPrtsDtSaveMonths; }
            set { _caPrtsDtSaveMonths = value; }
        }

        /// public propaty name  :  CaPrtsDtCompressDt
        /// <summary>���q���i�f�[�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���i�f�[�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CaPrtsDtCompressDt
        {
            get { return _caPrtsDtCompressDt; }
            set { _caPrtsDtCompressDt = value; }
        }

        /// public propaty name  :  MasterSaveMonths
        /// <summary>�}�X�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MasterSaveMonths
        {
            get { return _masterSaveMonths; }
            set { _masterSaveMonths = value; }
        }

        /// public propaty name  :  MasterCompressDt
        /// <summary>�}�X�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MasterCompressDt
        {
            get { return _masterCompressDt; }
            set { _masterCompressDt = value; }
        }

		/// public propaty name  :  RatePriorityDiv
		/// <summary>�|���D��敪�v���p�e�B</summary>
		/// <value>0:���_�D�� 1:�ݒ�敪�D��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���D��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RatePriorityDiv
		{
			get{return _ratePriorityDiv;}
			set{_ratePriorityDiv = value;}
		}

		/// <summary>
		/// ���Џ��R���X�g���N�^
		/// </summary>
		/// <returns>CompanyInf�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyInf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CompanyInf()
		{
		}

		/// <summary>
		/// ���Џ��R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="companyCode">���ЃR�[�h</param>
		/// <param name="companyTotalDay">���В���(DD�@����N�������Z�o����閖�������ł��邱�Ɗ�����̓����z����l)</param>
		/// <param name="financialYear">��v�N�x(YYYY)</param>
		/// <param name="companyBiginMonth">����(MM)</param>
		/// <param name="companyBiginMonth2">����2(MM)</param>
		/// <param name="companyBiginDate">����N����(YYYYMMDD)</param>
		/// <param name="startYearDiv">�J�n�N�敪(0:�O�N 1:���N)</param>
		/// <param name="startMonthDiv">�J�n���敪(0:�O�� 1:����)</param>
		/// <param name="companyName1">���Ж���1</param>
		/// <param name="companyName2">���Ж���2</param>
		/// <param name="postNo">�X�֔ԍ�</param>
		/// <param name="address1">�Z��1�i�s���{���s��S�E�����E���j</param>
		/// <param name="address2">�Z��2�i���ځj</param>
		/// <param name="address3">�Z��3�i�Ԓn�j</param>
		/// <param name="address4">�Z��4�i�A�p�[�g���́j</param>
		/// <param name="companyTelNo1">���Гd�b�ԍ�1</param>
		/// <param name="companyTelNo2">���Гd�b�ԍ�2</param>
		/// <param name="companyTelNo3">���Гd�b�ԍ�3</param>
		/// <param name="companyTelTitle1">���Гd�b�ԍ��^�C�g��1</param>
		/// <param name="companyTelTitle2">���Гd�b�ԍ��^�C�g��2</param>
		/// <param name="companyTelTitle3">���Гd�b�ԍ��^�C�g��3</param>
		/// <param name="secMngDiv">�����Ǘ��敪(0:���_�@1:���_�{��)</param>
        /// <param name="dataClrExecDate">�f�[�^�N���A�������s�N����</param>
        /// <param name="dataClrExecTime">�f�[�^�N���A�������s�����b�~���b</param>
        /// <param name="dataSaveMonths">�f�[�^�ۑ�����</param>
        /// <param name="dataCompressDt">�f�[�^���k��(YYYYMMDD)</param>
        /// <param name="resultDtSaveMonths">���уf�[�^�ۑ�����</param>
        /// <param name="resultDtCompressDt">���уf�[�^���k��(YYYYMMDD)</param>
        /// <param name="caPrtsDtSaveMonths">���q���i�f�[�^�ۑ�����</param>
        /// <param name="caPrtsDtCompressDt">���q���i�f�[�^���k��(YYYYMMDD)</param>
        /// <param name="masterSaveMonths">�}�X�^�ۑ�����</param>
        /// <param name="masterCompressDt">�}�X�^���k��(YYYYMMDD)</param>
		/// <param name="ratePriorityDiv">�|���D��敪(0:���_�D�� 1:�ݒ�敪�D��)</param>
		/// <returns>CompanyInf�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyInf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
		public CompanyInf(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 companyCode,Int32 companyTotalDay,Int32 financialYear,Int32 companyBiginMonth,Int32 companyBiginMonth2,Int32 companyBiginDate,Int32 startYearDiv,Int32 startMonthDiv,string companyName1,string companyName2,string postNo,string address1,Int32 address2,string address3,string address4,string companyTelNo1,string companyTelNo2,string companyTelNo3,string companyTelTitle1,string companyTelTitle2,string companyTelTitle3,Int32 secMngDiv)
		--- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        //public CompanyInf(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 companyCode, Int32 companyTotalDay, Int32 financialYear, Int32 companyBiginMonth, Int32 companyBiginMonth2, Int32 companyBiginDate, Int32 startYearDiv, Int32 startMonthDiv, string companyName1, string companyName2, string postNo, string address1, Int32 address2, string address3, string address4, string companyTelNo1, string companyTelNo2, string companyTelNo3, string companyTelTitle1, string companyTelTitle2, string companyTelTitle3, Int32 secMngDiv, Int32 dataClrExecDate, Int32 dataClrExecTime)
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
        public CompanyInf(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 companyCode, Int32 companyTotalDay, Int32 financialYear, Int32 companyBiginMonth, Int32 companyBiginMonth2, Int32 companyBiginDate, Int32 startYearDiv, Int32 startMonthDiv, string companyName1, string companyName2, string postNo, string address1, Int32 address2, string address3, string address4, string companyTelNo1, string companyTelNo2, string companyTelNo3, string companyTelTitle1, string companyTelTitle2, string companyTelTitle3, Int32 secMngDiv, Int32 dataClrExecDate, Int32 dataClrExecTime, Int32 dataSaveMonths, Int32 dataCompressDt, Int32 resultDtSaveMonths, Int32 resultDtCompressDt, Int32 caPrtsDtSaveMonths, Int32 caPrtsDtCompressDt, Int32 masterSaveMonths, Int32 masterCompressDt, Int32 ratePriorityDiv)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._companyCode = companyCode;
			this._companyTotalDay = companyTotalDay;
			this._financialYear = financialYear;
			this._companyBiginMonth = companyBiginMonth;
			this._companyBiginMonth2 = companyBiginMonth2;
			this._companyBiginDate = companyBiginDate;
			this._startYearDiv = startYearDiv;
			this._startMonthDiv = startMonthDiv;
			this._companyName1 = companyName1;
			this._companyName2 = companyName2;
			this._postNo = postNo;
			this._address1 = address1;
			this._address2 = address2;
			this._address3 = address3;
			this._address4 = address4;
			this._companyTelNo1 = companyTelNo1;
			this._companyTelNo2 = companyTelNo2;
			this._companyTelNo3 = companyTelNo3;
			this._companyTelTitle1 = companyTelTitle1;
			this._companyTelTitle2 = companyTelTitle2;
			this._companyTelTitle3 = companyTelTitle3;
			this._secMngDiv = secMngDiv;
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            this._dataClrExecDate = dataClrExecDate;
            this._dataClrExecTime = dataClrExecTime;
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            this._dataSaveMonths = dataSaveMonths;
            this._dataCompressDt = dataCompressDt;
            this._resultDtSaveMonths = resultDtSaveMonths;
            this._resultDtCompressDt = resultDtCompressDt;
            this._caPrtsDtSaveMonths = caPrtsDtSaveMonths;
            this._caPrtsDtCompressDt = caPrtsDtCompressDt;
            this._masterSaveMonths = masterSaveMonths;
            this._masterCompressDt = masterCompressDt;
			this._ratePriorityDiv = ratePriorityDiv;

		}

		/// <summary>
		/// ���Џ�񕡐�����
		/// </summary>
		/// <returns>CompanyInf�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CompanyInf�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CompanyInf Clone()
		{
            /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
            return new CompanyInf(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._companyCode,this._companyTotalDay,this._financialYear,this._companyBiginMonth,this._companyBiginMonth2,this._companyBiginDate,this._startYearDiv,this._startMonthDiv,this._companyName1,this._companyName2,this._postNo,this._address1,this._address2,this._address3,this._address4,this._companyTelNo1,this._companyTelNo2,this._companyTelNo3,this._companyTelTitle1,this._companyTelTitle2,this._companyTelTitle3,this._secMngDiv);
            --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //return new CompanyInf(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyCode, this._companyTotalDay, this._financialYear, this._companyBiginMonth, this._companyBiginMonth2, this._companyBiginDate, this._startYearDiv, this._startMonthDiv, this._companyName1, this._companyName2, this._postNo, this._address1, this._address2, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._secMngDiv, this._dataClrExecDate, this._dataClrExecTime);
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            return new CompanyInf(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyCode, this._companyTotalDay, this._financialYear, this._companyBiginMonth, this._companyBiginMonth2, this._companyBiginDate, this._startYearDiv, this._startMonthDiv, this._companyName1, this._companyName2, this._postNo, this._address1, this._address2, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._secMngDiv, this._dataClrExecDate, this._dataClrExecTime, this._dataSaveMonths, this._dataCompressDt, this._resultDtSaveMonths, this._resultDtCompressDt, this._caPrtsDtSaveMonths, this._caPrtsDtCompressDt, this._masterSaveMonths, this._masterCompressDt, this._ratePriorityDiv);
		}

		/// <summary>
		/// ���Џ���r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CompanyInf�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyInf�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CompanyInf target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CompanyCode == target.CompanyCode)
				 && (this.CompanyTotalDay == target.CompanyTotalDay)
				 && (this.FinancialYear == target.FinancialYear)
				 && (this.CompanyBiginMonth == target.CompanyBiginMonth)
				 && (this.CompanyBiginMonth2 == target.CompanyBiginMonth2)
				 && (this.CompanyBiginDate == target.CompanyBiginDate)
				 && (this.StartYearDiv == target.StartYearDiv)
				 && (this.StartMonthDiv == target.StartMonthDiv)
				 && (this.CompanyName1 == target.CompanyName1)
				 && (this.CompanyName2 == target.CompanyName2)
				 && (this.PostNo == target.PostNo)
				 && (this.Address1 == target.Address1)
				 && (this.Address2 == target.Address2)
				 && (this.Address3 == target.Address3)
				 && (this.Address4 == target.Address4)
				 && (this.CompanyTelNo1 == target.CompanyTelNo1)
				 && (this.CompanyTelNo2 == target.CompanyTelNo2)
				 && (this.CompanyTelNo3 == target.CompanyTelNo3)
				 && (this.CompanyTelTitle1 == target.CompanyTelTitle1)
				 && (this.CompanyTelTitle2 == target.CompanyTelTitle2)
				 && (this.CompanyTelTitle3 == target.CompanyTelTitle3)
                 /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
				 && (this.SecMngDiv == target.SecMngDiv));
                 --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
                // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
                && (this.SecMngDiv == target.SecMngDiv)
                && (this.DataClrExecDate == target.DataClrExecDate)
                && (this.DataClrExecTime == target.DataClrExecTime)
                // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
                 && (this.DataSaveMonths == target.DataSaveMonths)
                 && (this.DataCompressDt == target.DataCompressDt)
                 && (this.ResultDtSaveMonths == target.ResultDtSaveMonths)
                 && (this.ResultDtCompressDt == target.ResultDtCompressDt)
                 && (this.CaPrtsDtSaveMonths == target.CaPrtsDtSaveMonths)
                 && (this.CaPrtsDtCompressDt == target.CaPrtsDtCompressDt)
                 && (this.MasterSaveMonths == target.MasterSaveMonths)
                 && (this.MasterCompressDt == target.MasterCompressDt)
                 && (this.RatePriorityDiv == target.RatePriorityDiv));
		}

		/// <summary>
		/// ���Џ���r����
		/// </summary>
		/// <param name="companyInf1">
		///                    ��r����CompanyInf�N���X�̃C���X�^���X
		/// </param>
		/// <param name="companyInf2">��r����CompanyInf�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyInf�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CompanyInf companyInf1, CompanyInf companyInf2)
		{
			return ((companyInf1.CreateDateTime == companyInf2.CreateDateTime)
				 && (companyInf1.UpdateDateTime == companyInf2.UpdateDateTime)
				 && (companyInf1.EnterpriseCode == companyInf2.EnterpriseCode)
				 && (companyInf1.FileHeaderGuid == companyInf2.FileHeaderGuid)
				 && (companyInf1.UpdEmployeeCode == companyInf2.UpdEmployeeCode)
				 && (companyInf1.UpdAssemblyId1 == companyInf2.UpdAssemblyId1)
				 && (companyInf1.UpdAssemblyId2 == companyInf2.UpdAssemblyId2)
				 && (companyInf1.LogicalDeleteCode == companyInf2.LogicalDeleteCode)
				 && (companyInf1.CompanyCode == companyInf2.CompanyCode)
				 && (companyInf1.CompanyTotalDay == companyInf2.CompanyTotalDay)
				 && (companyInf1.FinancialYear == companyInf2.FinancialYear)
				 && (companyInf1.CompanyBiginMonth == companyInf2.CompanyBiginMonth)
				 && (companyInf1.CompanyBiginMonth2 == companyInf2.CompanyBiginMonth2)
				 && (companyInf1.CompanyBiginDate == companyInf2.CompanyBiginDate)
				 && (companyInf1.StartYearDiv == companyInf2.StartYearDiv)
				 && (companyInf1.StartMonthDiv == companyInf2.StartMonthDiv)
				 && (companyInf1.CompanyName1 == companyInf2.CompanyName1)
				 && (companyInf1.CompanyName2 == companyInf2.CompanyName2)
				 && (companyInf1.PostNo == companyInf2.PostNo)
				 && (companyInf1.Address1 == companyInf2.Address1)
				 && (companyInf1.Address2 == companyInf2.Address2)
				 && (companyInf1.Address3 == companyInf2.Address3)
				 && (companyInf1.Address4 == companyInf2.Address4)
				 && (companyInf1.CompanyTelNo1 == companyInf2.CompanyTelNo1)
				 && (companyInf1.CompanyTelNo2 == companyInf2.CompanyTelNo2)
				 && (companyInf1.CompanyTelNo3 == companyInf2.CompanyTelNo3)
				 && (companyInf1.CompanyTelTitle1 == companyInf2.CompanyTelTitle1)
				 && (companyInf1.CompanyTelTitle2 == companyInf2.CompanyTelTitle2)
				 && (companyInf1.CompanyTelTitle3 == companyInf2.CompanyTelTitle3)
                 /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
				 && (companyInf1.SecMngDiv == companyInf2.SecMngDiv));
                 --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
                // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
                && (companyInf1.SecMngDiv == companyInf2.SecMngDiv)
                && (companyInf1.DataClrExecDate == companyInf2.DataClrExecDate)
                && (companyInf1.DataClrExecTime == companyInf2.DataClrExecTime)
                // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
                 && (companyInf1.DataSaveMonths == companyInf2.DataSaveMonths)
                 && (companyInf1.DataCompressDt == companyInf2.DataCompressDt)
                 && (companyInf1.ResultDtSaveMonths == companyInf2.ResultDtSaveMonths)
                 && (companyInf1.ResultDtCompressDt == companyInf2.ResultDtCompressDt)
                 && (companyInf1.CaPrtsDtSaveMonths == companyInf2.CaPrtsDtSaveMonths)
                 && (companyInf1.CaPrtsDtCompressDt == companyInf2.CaPrtsDtCompressDt)
                 && (companyInf1.MasterSaveMonths == companyInf2.MasterSaveMonths)
                 && (companyInf1.MasterCompressDt == companyInf2.MasterCompressDt)
                 && (companyInf1.RatePriorityDiv == companyInf2.RatePriorityDiv));
		}
		/// <summary>
		/// ���Џ���r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CompanyInf�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyInf�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CompanyInf target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.CompanyCode != target.CompanyCode)resList.Add("CompanyCode");
			if(this.CompanyTotalDay != target.CompanyTotalDay)resList.Add("CompanyTotalDay");
			if(this.FinancialYear != target.FinancialYear)resList.Add("FinancialYear");
			if(this.CompanyBiginMonth != target.CompanyBiginMonth)resList.Add("CompanyBiginMonth");
			if(this.CompanyBiginMonth2 != target.CompanyBiginMonth2)resList.Add("CompanyBiginMonth2");
			if(this.CompanyBiginDate != target.CompanyBiginDate)resList.Add("CompanyBiginDate");
			if(this.StartYearDiv != target.StartYearDiv)resList.Add("StartYearDiv");
			if(this.StartMonthDiv != target.StartMonthDiv)resList.Add("StartMonthDiv");
			if(this.CompanyName1 != target.CompanyName1)resList.Add("CompanyName1");
			if(this.CompanyName2 != target.CompanyName2)resList.Add("CompanyName2");
			if(this.PostNo != target.PostNo)resList.Add("PostNo");
			if(this.Address1 != target.Address1)resList.Add("Address1");
			if(this.Address2 != target.Address2)resList.Add("Address2");
			if(this.Address3 != target.Address3)resList.Add("Address3");
			if(this.Address4 != target.Address4)resList.Add("Address4");
			if(this.CompanyTelNo1 != target.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(this.CompanyTelNo2 != target.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(this.CompanyTelNo3 != target.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(this.CompanyTelTitle1 != target.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(this.CompanyTelTitle2 != target.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(this.CompanyTelTitle3 != target.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(this.SecMngDiv != target.SecMngDiv)resList.Add("SecMngDiv");
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            if (this.DataClrExecDate != target.DataClrExecDate) resList.Add("DataClrExecDate");
            if (this.DataClrExecTime != target.DataClrExecTime) resList.Add("DataClrExecTime");
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            if (this.DataSaveMonths != target.DataSaveMonths) resList.Add("DataSaveMonths");
            if (this.DataCompressDt != target.DataCompressDt) resList.Add("DataCompressDt");
            if (this.ResultDtSaveMonths != target.ResultDtSaveMonths) resList.Add("ResultDtSaveMonths");
            if (this.ResultDtCompressDt != target.ResultDtCompressDt) resList.Add("ResultDtCompressDt");
            if (this.CaPrtsDtSaveMonths != target.CaPrtsDtSaveMonths) resList.Add("CaPrtsDtSaveMonths");
            if (this.CaPrtsDtCompressDt != target.CaPrtsDtCompressDt) resList.Add("CaPrtsDtCompressDt");
            if (this.MasterSaveMonths != target.MasterSaveMonths) resList.Add("MasterSaveMonths");
            if (this.MasterCompressDt != target.MasterCompressDt) resList.Add("MasterCompressDt");
            if (this.RatePriorityDiv != target.RatePriorityDiv) resList.Add("RatePriorityDiv");

			return resList;
		}

		/// <summary>
		/// ���Џ���r����
		/// </summary>
		/// <param name="companyInf1">��r����CompanyInf�N���X�̃C���X�^���X</param>
		/// <param name="companyInf2">��r����CompanyInf�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyInf�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CompanyInf companyInf1, CompanyInf companyInf2)
		{
			ArrayList resList = new ArrayList();
			if(companyInf1.CreateDateTime != companyInf2.CreateDateTime)resList.Add("CreateDateTime");
			if(companyInf1.UpdateDateTime != companyInf2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(companyInf1.EnterpriseCode != companyInf2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(companyInf1.FileHeaderGuid != companyInf2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(companyInf1.UpdEmployeeCode != companyInf2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(companyInf1.UpdAssemblyId1 != companyInf2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(companyInf1.UpdAssemblyId2 != companyInf2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(companyInf1.LogicalDeleteCode != companyInf2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(companyInf1.CompanyCode != companyInf2.CompanyCode)resList.Add("CompanyCode");
			if(companyInf1.CompanyTotalDay != companyInf2.CompanyTotalDay)resList.Add("CompanyTotalDay");
			if(companyInf1.FinancialYear != companyInf2.FinancialYear)resList.Add("FinancialYear");
			if(companyInf1.CompanyBiginMonth != companyInf2.CompanyBiginMonth)resList.Add("CompanyBiginMonth");
			if(companyInf1.CompanyBiginMonth2 != companyInf2.CompanyBiginMonth2)resList.Add("CompanyBiginMonth2");
			if(companyInf1.CompanyBiginDate != companyInf2.CompanyBiginDate)resList.Add("CompanyBiginDate");
			if(companyInf1.StartYearDiv != companyInf2.StartYearDiv)resList.Add("StartYearDiv");
			if(companyInf1.StartMonthDiv != companyInf2.StartMonthDiv)resList.Add("StartMonthDiv");
			if(companyInf1.CompanyName1 != companyInf2.CompanyName1)resList.Add("CompanyName1");
			if(companyInf1.CompanyName2 != companyInf2.CompanyName2)resList.Add("CompanyName2");
			if(companyInf1.PostNo != companyInf2.PostNo)resList.Add("PostNo");
			if(companyInf1.Address1 != companyInf2.Address1)resList.Add("Address1");
			if(companyInf1.Address2 != companyInf2.Address2)resList.Add("Address2");
			if(companyInf1.Address3 != companyInf2.Address3)resList.Add("Address3");
			if(companyInf1.Address4 != companyInf2.Address4)resList.Add("Address4");
			if(companyInf1.CompanyTelNo1 != companyInf2.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(companyInf1.CompanyTelNo2 != companyInf2.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(companyInf1.CompanyTelNo3 != companyInf2.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(companyInf1.CompanyTelTitle1 != companyInf2.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(companyInf1.CompanyTelTitle2 != companyInf2.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(companyInf1.CompanyTelTitle3 != companyInf2.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(companyInf1.SecMngDiv != companyInf2.SecMngDiv)resList.Add("SecMngDiv");
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            if (companyInf1.DataClrExecDate != companyInf2.DataClrExecDate) resList.Add("DataClrExecDate");
            if (companyInf1.DataClrExecTime != companyInf2.DataClrExecTime) resList.Add("DataClrExecTime");
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
            if (companyInf1.DataSaveMonths != companyInf2.DataSaveMonths) resList.Add("DataSaveMonths");
            if (companyInf1.DataCompressDt != companyInf2.DataCompressDt) resList.Add("DataCompressDt");
            if (companyInf1.ResultDtSaveMonths != companyInf2.ResultDtSaveMonths) resList.Add("ResultDtSaveMonths");
            if (companyInf1.ResultDtCompressDt != companyInf2.ResultDtCompressDt) resList.Add("ResultDtCompressDt");
            if (companyInf1.CaPrtsDtSaveMonths != companyInf2.CaPrtsDtSaveMonths) resList.Add("CaPrtsDtSaveMonths");
            if (companyInf1.CaPrtsDtCompressDt != companyInf2.CaPrtsDtCompressDt) resList.Add("CaPrtsDtCompressDt");
            if (companyInf1.MasterSaveMonths != companyInf2.MasterSaveMonths) resList.Add("MasterSaveMonths");
            if (companyInf1.MasterCompressDt != companyInf2.MasterCompressDt) resList.Add("MasterCompressDt");
            if (companyInf1.RatePriorityDiv != companyInf2.RatePriorityDiv) resList.Add("RatePriorityDiv");

			return resList;
		}
	}
}
