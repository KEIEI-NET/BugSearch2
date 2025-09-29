using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerChange
	/// <summary>
	///                      ���Ӑ�}�X�^�i�ϓ����j
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�}�X�^�i�ϓ����j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustomerChange
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

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

        //--- DEL 2008/06/23 --------->>>>>
        ///// <summary>���Ӑ旪��</summary>
        //private string _customerSnm = "";
        //--- DEL 2008/06/23 ---------<<<<<

		/// <summary>�^�M�z</summary>
		private Int64 _creditMoney;

		/// <summary>�x���^�M�z</summary>
        private Int64 _warningCreditMoney;

		/// <summary>���ݔ��|�c��</summary>
		/// <remarks>�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V</remarks>
        private Int64 _prsntAccRecBalance;

        //--- DEL 2008/06/23 ---------->>>>>
        ///// <summary>���ݓ��Ӑ�`�[�ԍ�</summary>
        //private Int64 _presentCustSlipNo;

        ///// <summary>�J�n���Ӑ�`�[�ԍ�</summary>
        //private Int64 _startCustSlipNo;

        ///// <summary>�I�����Ӑ�`�[�ԍ�</summary>
        //private Int64 _endCustSlipNo;

        ///// <summary>�ԍ�����</summary>
        ///// <remarks>�ԍ��������i�I���ԍ������{�w�b�_�[�����{�t�b�^�[�����j�ł��邱�Ɓ@�ԍ�������MAX19��</remarks>
        //private Int32 _noCharcterCount;

        ///// <summary>���Ӑ�`�[�ԍ��w�b�_</summary>
        //private string _custSlipNoHeader = "";

        ///// <summary>���Ӑ�`�[�ԍ��t�b�^</summary>
        //private string _custSlipNoFooter = "";
        //--- DEL 2008/06/23 ----------<<<<<

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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

        //--- DEL 2008/06/23 ---------->>>>>
        ///// public propaty name  :  CustomerSnm
        ///// <summary>���Ӑ旪�̃v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustomerSnm
        //{
        //    get{return _customerSnm;}
        //    set{_customerSnm = value;}
        //}
        //--- DEL 2008/06/23 ----------<<<<<

		/// public propaty name  :  CreditMoney
		/// <summary>�^�M�z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^�M�z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 CreditMoney
		{
			get{return _creditMoney;}
			set{_creditMoney = value;}
		}

		/// public propaty name  :  WarningCreditMoney
		/// <summary>�x���^�M�z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���^�M�z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 WarningCreditMoney
		{
			get{return _warningCreditMoney;}
			set{_warningCreditMoney = value;}
		}

		/// public propaty name  :  PrsntAccRecBalance
		/// <summary>���ݔ��|�c���v���p�e�B</summary>
		/// <value>�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ݔ��|�c���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 PrsntAccRecBalance
		{
			get{return _prsntAccRecBalance;}
			set{_prsntAccRecBalance = value;}
		}

        //--- DEL 2008/06/23 ---------->>>>>
        ///// public propaty name  :  PresentCustSlipNo
        ///// <summary>���ݓ��Ӑ�`�[�ԍ��v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���ݓ��Ӑ�`�[�ԍ��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 PresentCustSlipNo
        //{
        //    get{return _presentCustSlipNo;}
        //    set{_presentCustSlipNo = value;}
        //}

        ///// public propaty name  :  StartCustSlipNo
        ///// <summary>�J�n���Ӑ�`�[�ԍ��v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n���Ӑ�`�[�ԍ��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 StartCustSlipNo
        //{
        //    get{return _startCustSlipNo;}
        //    set{_startCustSlipNo = value;}
        //}

        ///// public propaty name  :  EndCustSlipNo
        ///// <summary>�I�����Ӑ�`�[�ԍ��v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I�����Ӑ�`�[�ԍ��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 EndCustSlipNo
        //{
        //    get{return _endCustSlipNo;}
        //    set{_endCustSlipNo = value;}
        //}

        ///// public propaty name  :  NoCharcterCount
        ///// <summary>�ԍ������v���p�e�B</summary>
        ///// <value>�ԍ��������i�I���ԍ������{�w�b�_�[�����{�t�b�^�[�����j�ł��邱�Ɓ@�ԍ�������MAX19��</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �ԍ������v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 NoCharcterCount
        //{
        //    get{return _noCharcterCount;}
        //    set{_noCharcterCount = value;}
        //}

        ///// public propaty name  :  CustSlipNoHeader
        ///// <summary>���Ӑ�`�[�ԍ��w�b�_�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�`�[�ԍ��w�b�_�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustSlipNoHeader
        //{
        //    get{return _custSlipNoHeader;}
        //    set{_custSlipNoHeader = value;}
        //}

        ///// public propaty name  :  CustSlipNoFooter
        ///// <summary>���Ӑ�`�[�ԍ��t�b�^�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�`�[�ԍ��t�b�^�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustSlipNoFooter
        //{
        //    get{return _custSlipNoFooter;}
        //    set{_custSlipNoFooter = value;}
        //}
        //--- DEL 2008/06/23 ----------<<<<<

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j�R���X�g���N�^
		/// </summary>
		/// <returns>CustomerChange�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerChange�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerChange()
		{
		}

		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerSnm">���Ӑ旪��</param>
		/// <param name="creditMoney">�^�M�z</param>
		/// <param name="warningCreditMoney">�x���^�M�z</param>
		/// <param name="prsntAccRecBalance">���ݔ��|�c��(�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V)</param>
		/// <param name="presentCustSlipNo">���ݓ��Ӑ�`�[�ԍ�</param>
		/// <param name="startCustSlipNo">�J�n���Ӑ�`�[�ԍ�</param>
		/// <param name="endCustSlipNo">�I�����Ӑ�`�[�ԍ�</param>
		/// <param name="noCharcterCount">�ԍ�����(�ԍ��������i�I���ԍ������{�w�b�_�[�����{�t�b�^�[�����j�ł��邱�Ɓ@�ԍ�������MAX19��)</param>
		/// <param name="custSlipNoHeader">���Ӑ�`�[�ԍ��w�b�_</param>
		/// <param name="custSlipNoFooter">���Ӑ�`�[�ԍ��t�b�^</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>CustomerChange�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerChange�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        //public CustomerChange(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSnm, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, Int64 presentCustSlipNo, Int64 startCustSlipNo, Int64 endCustSlipNo, Int32 noCharcterCount, string custSlipNoHeader, string custSlipNoFooter, string enterpriseName, string updEmployeeName)    // DEL 2008/06/23
        public CustomerChange(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, string enterpriseName, string updEmployeeName)      // ADD 2008/06/23
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._customerCode = customerCode;
            //this._customerSnm = customerSnm;      // DEL 2008/06/23
			this._creditMoney = creditMoney;
			this._warningCreditMoney = warningCreditMoney;
			this._prsntAccRecBalance = prsntAccRecBalance;
            //--- DEL 2008/06/23 ---------->>>>>
            //this._presentCustSlipNo = presentCustSlipNo;
            //this._startCustSlipNo = startCustSlipNo;
            //this._endCustSlipNo = endCustSlipNo;
            //this._noCharcterCount = noCharcterCount;
            //this._custSlipNoHeader = custSlipNoHeader;
            //this._custSlipNoFooter = custSlipNoFooter;
            //--- DEL 2008/06/23 ----------<<<<<
            this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j��������
		/// </summary>
		/// <returns>CustomerChange�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerChange�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerChange Clone()
		{
            //return new CustomerChange(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSnm, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._presentCustSlipNo, this._startCustSlipNo, this._endCustSlipNo, this._noCharcterCount, this._custSlipNoHeader, this._custSlipNoFooter, this._enterpriseName, this._updEmployeeName);     // DEL 2008/06/23
            return new CustomerChange(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._enterpriseName, this._updEmployeeName);       // ADD 2008/06/23
        }

		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerChange�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerChange�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustomerChange target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CustomerCode == target.CustomerCode)
                 //&& (this.CustomerSnm == target.CustomerSnm)              // DEL 2008/06/23
				 && (this.CreditMoney == target.CreditMoney)
				 && (this.WarningCreditMoney == target.WarningCreditMoney)
				 && (this.PrsntAccRecBalance == target.PrsntAccRecBalance)
                 //--- DEL 2008/06/23 ---------->>>>>
                 //&& (this.PresentCustSlipNo == target.PresentCustSlipNo)
                 //&& (this.StartCustSlipNo == target.StartCustSlipNo)
                 //&& (this.EndCustSlipNo == target.EndCustSlipNo)
                 //&& (this.NoCharcterCount == target.NoCharcterCount)
                 //&& (this.CustSlipNoHeader == target.CustSlipNoHeader)
                 //&& (this.CustSlipNoFooter == target.CustSlipNoFooter)
                 //--- DEL 2008/06/23 ----------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j��r����
		/// </summary>
		/// <param name="customerChange1">
		///                    ��r����CustomerChange�N���X�̃C���X�^���X
		/// </param>
		/// <param name="customerChange2">��r����CustomerChange�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerChange�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustomerChange customerChange1, CustomerChange customerChange2)
		{
			return ((customerChange1.CreateDateTime == customerChange2.CreateDateTime)
				 && (customerChange1.UpdateDateTime == customerChange2.UpdateDateTime)
				 && (customerChange1.EnterpriseCode == customerChange2.EnterpriseCode)
				 && (customerChange1.FileHeaderGuid == customerChange2.FileHeaderGuid)
				 && (customerChange1.UpdEmployeeCode == customerChange2.UpdEmployeeCode)
				 && (customerChange1.UpdAssemblyId1 == customerChange2.UpdAssemblyId1)
				 && (customerChange1.UpdAssemblyId2 == customerChange2.UpdAssemblyId2)
				 && (customerChange1.LogicalDeleteCode == customerChange2.LogicalDeleteCode)
				 && (customerChange1.CustomerCode == customerChange2.CustomerCode)
                 //&& (customerChange1.CustomerSnm == customerChange2.CustomerSnm)              // DEL 2008/06/23
				 && (customerChange1.CreditMoney == customerChange2.CreditMoney)
				 && (customerChange1.WarningCreditMoney == customerChange2.WarningCreditMoney)
				 && (customerChange1.PrsntAccRecBalance == customerChange2.PrsntAccRecBalance)
                 //--- DEL 2008/06/23 ---------->>>>>
                 //&& (customerChange1.PresentCustSlipNo == customerChange2.PresentCustSlipNo)
                 //&& (customerChange1.StartCustSlipNo == customerChange2.StartCustSlipNo)
                 //&& (customerChange1.EndCustSlipNo == customerChange2.EndCustSlipNo)
                 //&& (customerChange1.NoCharcterCount == customerChange2.NoCharcterCount)
                 //&& (customerChange1.CustSlipNoHeader == customerChange2.CustSlipNoHeader)
                 //&& (customerChange1.CustSlipNoFooter == customerChange2.CustSlipNoFooter)
                 //--- DEL 2008/06/23 ----------<<<<<
                 && (customerChange1.EnterpriseName == customerChange2.EnterpriseName)
				 && (customerChange1.UpdEmployeeName == customerChange2.UpdEmployeeName));
		}
		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerChange�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerChange�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CustomerChange target)
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
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
            //if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");                 // DEL 2008/06/23
			if(this.CreditMoney != target.CreditMoney)resList.Add("CreditMoney");
			if(this.WarningCreditMoney != target.WarningCreditMoney)resList.Add("WarningCreditMoney");
			if(this.PrsntAccRecBalance != target.PrsntAccRecBalance)resList.Add("PrsntAccRecBalance");
            //--- DEL 2008/06/23 ---------->>>>>
            //if(this.PresentCustSlipNo != target.PresentCustSlipNo)resList.Add("PresentCustSlipNo");
            //if(this.StartCustSlipNo != target.StartCustSlipNo)resList.Add("StartCustSlipNo");
            //if(this.EndCustSlipNo != target.EndCustSlipNo)resList.Add("EndCustSlipNo");
            //if(this.NoCharcterCount != target.NoCharcterCount)resList.Add("NoCharcterCount");
            //if(this.CustSlipNoHeader != target.CustSlipNoHeader)resList.Add("CustSlipNoHeader");
            //if(this.CustSlipNoFooter != target.CustSlipNoFooter)resList.Add("CustSlipNoFooter");
            //--- DEL 2008/06/23 ----------<<<<<
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ���Ӑ�}�X�^�i�ϓ����j��r����
		/// </summary>
		/// <param name="customerChange1">��r����CustomerChange�N���X�̃C���X�^���X</param>
		/// <param name="customerChange2">��r����CustomerChange�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerChange�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CustomerChange customerChange1, CustomerChange customerChange2)
		{
			ArrayList resList = new ArrayList();
			if(customerChange1.CreateDateTime != customerChange2.CreateDateTime)resList.Add("CreateDateTime");
			if(customerChange1.UpdateDateTime != customerChange2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(customerChange1.EnterpriseCode != customerChange2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(customerChange1.FileHeaderGuid != customerChange2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(customerChange1.UpdEmployeeCode != customerChange2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(customerChange1.UpdAssemblyId1 != customerChange2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(customerChange1.UpdAssemblyId2 != customerChange2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(customerChange1.LogicalDeleteCode != customerChange2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(customerChange1.CustomerCode != customerChange2.CustomerCode)resList.Add("CustomerCode");
            //if(customerChange1.CustomerSnm != customerChange2.CustomerSnm)resList.Add("CustomerSnm");             // DEL 2008/06/23
			if(customerChange1.CreditMoney != customerChange2.CreditMoney)resList.Add("CreditMoney");
			if(customerChange1.WarningCreditMoney != customerChange2.WarningCreditMoney)resList.Add("WarningCreditMoney");
			if(customerChange1.PrsntAccRecBalance != customerChange2.PrsntAccRecBalance)resList.Add("PrsntAccRecBalance");
            //--- DEL 2008/06/23 ---------->>>>>
            //if (customerChange1.PresentCustSlipNo != customerChange2.PresentCustSlipNo) resList.Add("PresentCustSlipNo");
            //if(customerChange1.StartCustSlipNo != customerChange2.StartCustSlipNo)resList.Add("StartCustSlipNo");
            //if(customerChange1.EndCustSlipNo != customerChange2.EndCustSlipNo)resList.Add("EndCustSlipNo");
            //if(customerChange1.NoCharcterCount != customerChange2.NoCharcterCount)resList.Add("NoCharcterCount");
            //if(customerChange1.CustSlipNoHeader != customerChange2.CustSlipNoHeader)resList.Add("CustSlipNoHeader");
            //if(customerChange1.CustSlipNoFooter != customerChange2.CustSlipNoFooter)resList.Add("CustSlipNoFooter");
            //--- DEL 2008/06/23 ----------<<<<<
            if (customerChange1.EnterpriseName != customerChange2.EnterpriseName) resList.Add("EnterpriseName");
			if(customerChange1.UpdEmployeeName != customerChange2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
