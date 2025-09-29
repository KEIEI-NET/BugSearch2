using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MailBackup
	/// <summary>
	///                      ���[���o�b�N�A�b�v�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[���o�b�N�A�b�v�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/9/29</br>
	/// <br>Genarated Date   :   2006/10/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class MailBackup
    {

        // ���������ȊO�̃v���p�e�B(�����Ȃ��ł�������)
        #region ���������ȊO�̃v���p�e�B(�����Ȃ��ł�������)


        /// <summary>
        /// ���[���X�e�[�^�X��` 0:�V�K
        /// </summary>
        public static int MailBackup_MailStatus_NEW = 0;

        /// <summary>
        /// ���[���X�e�[�^�X��` 5:�G���[�����M
        /// </summary>
        public static int MailBackup_MailStatus_ERROR = 5;


        #endregion


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

		/// <summary>���M���_�R�[�h</summary>
		private string _sendSectionCode = "";

		/// <summary>���[���Ǘ��A��</summary>
		private Int32 _mailManagementConsNo;

		/// <summary>���[���X�e�[�^�X</summary>
		/// <remarks>0:�V�K, 5:�G���[�����M</remarks>
		private Int32 _mailStatus;

		/// <summary>���M����</summary>
		/// <remarks>200601011212(������t�{�����j</remarks>
		private Int64 _sendDateTime;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>����2</summary>
		private string _name2 = "";

		/// <summary>�h��</summary>
		private string _honorificTitle = "";

		/// <summary>�J�i</summary>
		private string _kana = "";

		/// <summary>�ԗ��Ǘ��ԍ�</summary>
		private Int32 _carMngNo;

		/// <summary>���^�������ԍ�</summary>
		private Int32 _numberPlate1Code;

		/// <summary>���^�����ǖ���</summary>
		private string _numberPlate1Name = "";

		/// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
		private string _numberPlate2 = "";

		/// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
		private string _numberPlate3 = "";

		/// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
		private Int32 _numberPlate4;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>�Ԏ햼</summary>
		private string _modelName = "";

		/// <summary>���[���A�h���X</summary>
		/// <remarks>���[���̃��[���A�h���X</remarks>
		private string _mailAddress = "";

		/// <summary>���[���A�h���X��ʃR�[�h</summary>
		/// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
		private Int32 _mailAddrKindCode1;

		/// <summary>���[���A�h���X��ʖ���</summary>
		private string _mailAddrKindName1 = "";

		/// <summary>���[�����M�敪�R�[�h</summary>
		/// <remarks>0:�񑗐M,1:���M</remarks>
		private Int32 _mailSendCode1;

		/// <summary>���[���`��</summary>
		/// <remarks>0:Text,1:HTML</remarks>
		private Int32 _mailFormal;

		/// <summary>���o�A�Z���u���敪</summary>
		private string _extraAssemblyDivide = "";

		/// <summary>���[�������ԍ�</summary>
		private Int32 _mailDocumentNo;

		/// <summary>���[�������敪</summary>
		/// <remarks>0:���[������,1:�g�у��[������,2:����</remarks>
		private Int32 _mailDocCode;

		/// <summary>�_�����</summary>
		/// <remarks>1:�Ԍ�,2�@��,3:�V��,4:��ʓ_��,9:DM�敪</remarks>
		private Int32 _checkKindCode;

		/// <summary>�_���敪</summary>
		/// <remarks>0:���,3:3�_,6:6�_,12:12�_,24:24�_</remarks>
		private Int32 _checkDivCd;

		/// <summary>���[���^�C�g��</summary>
		/// <remarks>nvarchar(max)</remarks>
		private string _mailTitle;

		/// <summary>���[������</summary>
		/// <remarks>nvarchar(max)</remarks>
		private string _mailDocumentCnts;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

        /// <summary>���[���Ǘ�Guid</summary>
        /// <remarks>Guid</remarks>
        private Guid _mailMngGuid;

        /// <summary>CC</summary>
        private string _carbonCopy = "";

        /// <summary>�Y�t�t�@�C��</summary>
        private string _attachFile = "";

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

		/// public propaty name  :  SendSectionCode
		/// <summary>���M���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���M���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SendSectionCode
		{
			get{return _sendSectionCode;}
			set{_sendSectionCode = value;}
		}

		/// public propaty name  :  MailManagementConsNo
		/// <summary>���[���Ǘ��A�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���Ǘ��A�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailManagementConsNo
		{
			get{return _mailManagementConsNo;}
			set{_mailManagementConsNo = value;}
		}

		/// public propaty name  :  MailStatus
		/// <summary>���[���X�e�[�^�X�v���p�e�B</summary>
		/// <value>0:�V�K, 5:�G���[�����M</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailStatus
		{
			get{return _mailStatus;}
			set{_mailStatus = value;}
		}

		/// public propaty name  :  SendDateTime
		/// <summary>���M�����v���p�e�B</summary>
		/// <value>200601011212(������t�{�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���M�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SendDateTime
		{
			get{return _sendDateTime;}
			set{_sendDateTime = value;}
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

		/// public propaty name  :  Name
		/// <summary>���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>����2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

		/// public propaty name  :  HonorificTitle
		/// <summary>�h�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �h�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HonorificTitle
		{
			get{return _honorificTitle;}
			set{_honorificTitle = value;}
		}

		/// public propaty name  :  Kana
		/// <summary>�J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Kana
		{
			get{return _kana;}
			set{_kana = value;}
		}

		/// public propaty name  :  CarMngNo
		/// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarMngNo
		{
			get{return _carMngNo;}
			set{_carMngNo = value;}
		}

		/// public propaty name  :  NumberPlate1Code
		/// <summary>���^�������ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���^�������ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberPlate1Code
		{
			get{return _numberPlate1Code;}
			set{_numberPlate1Code = value;}
		}

		/// public propaty name  :  NumberPlate1Name
		/// <summary>���^�����ǖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate1Name
		{
			get{return _numberPlate1Name;}
			set{_numberPlate1Name = value;}
		}

		/// public propaty name  :  NumberPlate2
		/// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate2
		{
			get{return _numberPlate2;}
			set{_numberPlate2 = value;}
		}

		/// public propaty name  :  NumberPlate3
		/// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate3
		{
			get{return _numberPlate3;}
			set{_numberPlate3 = value;}
		}

		/// public propaty name  :  NumberPlate4
		/// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get{return _numberPlate4;}
			set{_numberPlate4 = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  ModelName
		/// <summary>�Ԏ햼�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ햼�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ModelName
		{
			get{return _modelName;}
			set{_modelName = value;}
		}

		/// public propaty name  :  MailAddress
		/// <summary>���[���A�h���X�v���p�e�B</summary>
		/// <value>���[���̃��[���A�h���X</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���A�h���X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MailAddress
		{
			get{return _mailAddress;}
			set{_mailAddress = value;}
		}

		/// public propaty name  :  MailAddrKindCode1
		/// <summary>���[���A�h���X��ʃR�[�h�v���p�e�B</summary>
		/// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���A�h���X��ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailAddrKindCode1
		{
			get{return _mailAddrKindCode1;}
			set{_mailAddrKindCode1 = value;}
		}

		/// public propaty name  :  MailAddrKindName1
		/// <summary>���[���A�h���X��ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���A�h���X��ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MailAddrKindName1
		{
			get{return _mailAddrKindName1;}
			set{_mailAddrKindName1 = value;}
		}

		/// public propaty name  :  MailSendCode1
		/// <summary>���[�����M�敪�R�[�h�v���p�e�B</summary>
		/// <value>0:�񑗐M,1:���M</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�����M�敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailSendCode1
		{
			get{return _mailSendCode1;}
			set{_mailSendCode1 = value;}
		}

		/// public propaty name  :  MailFormal
		/// <summary>���[���`���v���p�e�B</summary>
		/// <value>0:Text,1:HTML</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���`���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailFormal
		{
			get{return _mailFormal;}
			set{_mailFormal = value;}
		}

		/// public propaty name  :  ExtraAssemblyDivide
		/// <summary>���o�A�Z���u���敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�A�Z���u���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExtraAssemblyDivide
		{
			get{return _extraAssemblyDivide;}
			set{_extraAssemblyDivide = value;}
		}

		/// public propaty name  :  MailDocumentNo
		/// <summary>���[�������ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�������ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailDocumentNo
		{
			get{return _mailDocumentNo;}
			set{_mailDocumentNo = value;}
		}

		/// public propaty name  :  MailDocCode
		/// <summary>���[�������敪�v���p�e�B</summary>
		/// <value>0:���[������,1:�g�у��[������,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MailDocCode
		{
			get{return _mailDocCode;}
			set{_mailDocCode = value;}
		}

		/// public propaty name  :  CheckKindCode
		/// <summary>�_����ʃv���p�e�B</summary>
		/// <value>1:�Ԍ�,2�@��,3:�V��,4:��ʓ_��,9:DM�敪</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckKindCode
		{
			get{return _checkKindCode;}
			set{_checkKindCode = value;}
		}

		/// public propaty name  :  CheckDivCd
		/// <summary>�_���敪�v���p�e�B</summary>
		/// <value>0:���,3:3�_,6:6�_,12:12�_,24:24�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckDivCd
		{
			get{return _checkDivCd;}
			set{_checkDivCd = value;}
		}

		/// public propaty name  :  MailTitle
		/// <summary>���[���^�C�g���v���p�e�B</summary>
		/// <value>nvarchar(max)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���^�C�g���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MailTitle
		{
			get{return _mailTitle;}
			set{_mailTitle = value;}
		}

		/// public propaty name  :  MailDocumentCnts
		/// <summary>���[�������v���p�e�B</summary>
		/// <value>nvarchar(max)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MailDocumentCnts
		{
			get{return _mailDocumentCnts;}
			set{_mailDocumentCnts = value;}
		}

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

        /// public propaty name  :  MailMngGuid
        /// <summary>���[���Ǘ�Guid</summary>
        /// <value>Guid</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid MailMngGuid
        {
            get { return _mailMngGuid; }
            set { _mailMngGuid = value; }
        }

        /// <summary>CC</summary>
        /// public propaty name  :  CarbonCopy
        /// <summary>CC</summary>
        /// <value>string</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarbonCopy
        {
            get { return _carbonCopy; }
            set { _carbonCopy = value; }
        }

        /// <summary>�Y�t�t�@�C��</summary>
        /// public propaty name  :  AttachFile
        /// <summary>�Y�t�t�@�C��</summary>
        /// <value>string</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AttachFile
        {
            get { return _attachFile; }
            set { _attachFile = value; }
        }


		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>MailBackup�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailBackup()
		{


		}

		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="sendSectionCode">���M���_�R�[�h</param>
		/// <param name="mailManagementConsNo">���[���Ǘ��A��</param>
		/// <param name="mailStatus">���[���X�e�[�^�X(0:�V�K, 5:�G���[�����M)</param>
		/// <param name="sendDateTime">���M����(200601011212(������t�{�����j)</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="name">����</param>
		/// <param name="name2">����2</param>
		/// <param name="honorificTitle">�h��</param>
		/// <param name="kana">�J�i</param>
		/// <param name="carMngNo">�ԗ��Ǘ��ԍ�</param>
		/// <param name="numberPlate1Code">���^�������ԍ�</param>
		/// <param name="numberPlate1Name">���^�����ǖ���</param>
		/// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
		/// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
		/// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="modelName">�Ԏ햼</param>
		/// <param name="mailAddress">���[���A�h���X(���[���̃��[���A�h���X)</param>
		/// <param name="mailAddrKindCode1">���[���A�h���X��ʃR�[�h(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
		/// <param name="mailAddrKindName1">���[���A�h���X��ʖ���</param>
		/// <param name="mailSendCode1">���[�����M�敪�R�[�h(0:�񑗐M,1:���M)</param>
		/// <param name="mailFormal">���[���`��(0:Text,1:HTML)</param>
		/// <param name="extraAssemblyDivide">���o�A�Z���u���敪</param>
		/// <param name="mailDocumentNo">���[�������ԍ�</param>
		/// <param name="mailDocCode">���[�������敪(0:���[������,1:�g�у��[������,2:����)</param>
		/// <param name="checkKindCode">�_�����(1:�Ԍ�,2�@��,3:�V��,4:��ʓ_��,9:DM�敪)</param>
		/// <param name="checkDivCd">�_���敪(0:���,3:3�_,6:6�_,12:12�_,24:24�_)</param>
		/// <param name="mailTitle">���[���^�C�g��(nvarchar(max))</param>
		/// <param name="mailDocumentCnts">���[������(nvarchar(max))</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>MailBackup�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailBackup(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sendSectionCode,Int32 mailManagementConsNo,Int32 mailStatus,Int64 sendDateTime,Int32 customerCode,string name,string name2,string honorificTitle,string kana,Int32 carMngNo,Int32 numberPlate1Code,string numberPlate1Name,string numberPlate2,string numberPlate3,Int32 numberPlate4,string makerName,string modelName,string mailAddress,Int32 mailAddrKindCode1,string mailAddrKindName1,Int32 mailSendCode1,Int32 mailFormal,string extraAssemblyDivide,Int32 mailDocumentNo,Int32 mailDocCode,Int32 checkKindCode,Int32 checkDivCd,string mailTitle,string mailDocumentCnts,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sendSectionCode = sendSectionCode;
			this._mailManagementConsNo = mailManagementConsNo;
			this._mailStatus = mailStatus;
			this._sendDateTime = sendDateTime;
			this._customerCode = customerCode;
			this._name = name;
			this._name2 = name2;
			this._honorificTitle = honorificTitle;
			this._kana = kana;
			this._carMngNo = carMngNo;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._makerName = makerName;
			this._modelName = modelName;
			this._mailAddress = mailAddress;
			this._mailAddrKindCode1 = mailAddrKindCode1;
			this._mailAddrKindName1 = mailAddrKindName1;
			this._mailSendCode1 = mailSendCode1;
			this._mailFormal = mailFormal;
			this._extraAssemblyDivide = extraAssemblyDivide;
			this._mailDocumentNo = mailDocumentNo;
			this._mailDocCode = mailDocCode;
			this._checkKindCode = checkKindCode;
			this._checkDivCd = checkDivCd;
			this._mailTitle = mailTitle;
			this._mailDocumentCnts = mailDocumentCnts;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
		}


        // 2008.07.01 R.Sokei ADD >>>>
        /// <summary>
        /// ���[���o�b�N�A�b�v�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sendSectionCode">���M���_�R�[�h</param>
        /// <param name="mailManagementConsNo">���[���Ǘ��A��</param>
        /// <param name="mailStatus">���[���X�e�[�^�X(0:�V�K, 5:�G���[�����M)</param>
        /// <param name="sendDateTime">���M����(200601011212(������t�{�����j)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="name">����</param>
        /// <param name="name2">����2</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="kana">�J�i</param>
        /// <param name="carMngNo">�ԗ��Ǘ��ԍ�</param>
        /// <param name="numberPlate1Code">���^�������ԍ�</param>
        /// <param name="numberPlate1Name">���^�����ǖ���</param>
        /// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
        /// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
        /// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="modelName">�Ԏ햼</param>
        /// <param name="mailAddress">���[���A�h���X(���[���̃��[���A�h���X)</param>
        /// <param name="mailAddrKindCode1">���[���A�h���X��ʃR�[�h(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddrKindName1">���[���A�h���X��ʖ���</param>
        /// <param name="mailSendCode1">���[�����M�敪�R�[�h(0:�񑗐M,1:���M)</param>
        /// <param name="mailFormal">���[���`��(0:Text,1:HTML)</param>
        /// <param name="extraAssemblyDivide">���o�A�Z���u���敪</param>
        /// <param name="mailDocumentNo">���[�������ԍ�</param>
        /// <param name="mailDocCode">���[�������敪(0:���[������,1:�g�у��[������,2:����)</param>
        /// <param name="checkKindCode">�_�����(1:�Ԍ�,2�@��,3:�V��,4:��ʓ_��,9:DM�敪)</param>
        /// <param name="checkDivCd">�_���敪(0:���,3:3�_,6:6�_,12:12�_,24:24�_)</param>
        /// <param name="mailTitle">���[���^�C�g��(nvarchar(max))</param>
        /// <param name="mailDocumentCnts">���[������(nvarchar(max))</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="mailMngGuid">���[���Ǘ�Guid</param>
        /// <param name="carbonCopy">CC</param>
        /// <param name="attachFile">�Y�t�t�@�C��</param>
        /// <returns>MailBackup�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailBackup(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sendSectionCode, Int32 mailManagementConsNo, Int32 mailStatus, Int64 sendDateTime, Int32 customerCode, string name, string name2, string honorificTitle, string kana, Int32 carMngNo, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, string makerName, string modelName, string mailAddress, Int32 mailAddrKindCode1, string mailAddrKindName1, Int32 mailSendCode1, Int32 mailFormal, string extraAssemblyDivide, Int32 mailDocumentNo, Int32 mailDocCode, Int32 checkKindCode, Int32 checkDivCd, string mailTitle, string mailDocumentCnts, string enterpriseName, string updEmployeeName, Guid mailMngGuid, string carbonCopy, string attachFile)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sendSectionCode = sendSectionCode;
            this._mailManagementConsNo = mailManagementConsNo;
            this._mailStatus = mailStatus;
            this._sendDateTime = sendDateTime;
            this._customerCode = customerCode;
            this._name = name;
            this._name2 = name2;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._carMngNo = carMngNo;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this._makerName = makerName;
            this._modelName = modelName;
            this._mailAddress = mailAddress;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailSendCode1 = mailSendCode1;
            this._mailFormal = mailFormal;
            this._extraAssemblyDivide = extraAssemblyDivide;
            this._mailDocumentNo = mailDocumentNo;
            this._mailDocCode = mailDocCode;
            this._checkKindCode = checkKindCode;
            this._checkDivCd = checkDivCd;
            this._mailTitle = mailTitle;
            this._mailDocumentCnts = mailDocumentCnts;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._mailMngGuid = mailMngGuid;
            this._carbonCopy = carbonCopy;
            this._attachFile = attachFile;
        }
        // 2008.07.01 R.Sokei ADD <<<<



		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^��������
		/// </summary>
		/// <returns>MailBackup�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MailBackup�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public MailBackup Clone()
        {
            //			return new MailBackup(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sendSectionCode,this._mailManagementConsNo,this._mailStatus,this._sendDateTime,this._customerCode,this._name,this._name2,this._honorificTitle,this._kana,this._carMngNo,this._numberPlate1Code,this._numberPlate1Name,this._numberPlate2,this._numberPlate3,this._numberPlate4,this._makerName,this._modelName,this._mailAddress,this._mailAddrKindCode1,this._mailAddrKindName1,this._mailSendCode1,this._mailFormal,this._extraAssemblyDivide,this._mailDocumentNo,this._mailDocCode,this._checkKindCode,this._checkDivCd,this._mailTitle,this._mailDocumentCnts,this._enterpriseName,this._updEmployeeName,this._mailMngGuid);
            // 2008.07.01 R.Sokei ADD >>>>
            return new MailBackup(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sendSectionCode, this._mailManagementConsNo, this._mailStatus, this._sendDateTime, this._customerCode, this._name, this._name2, this._honorificTitle, this._kana, this._carMngNo, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._makerName, this._modelName, this._mailAddress, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailSendCode1, this._mailFormal, this._extraAssemblyDivide, this._mailDocumentNo, this._mailDocCode, this._checkKindCode, this._checkDivCd, this._mailTitle, this._mailDocumentCnts, this._enterpriseName, this._updEmployeeName, this._mailMngGuid, this._carbonCopy, this._attachFile);
            // 2008.07.01 R.Sokei ADD <<<<

        }

		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MailBackup�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public bool Equals(MailBackup target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SendSectionCode == target.SendSectionCode)
                 && (this.MailManagementConsNo == target.MailManagementConsNo)
                 && (this.MailStatus == target.MailStatus)
                 && (this.SendDateTime == target.SendDateTime)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.Name == target.Name)
                 && (this.Name2 == target.Name2)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.CarMngNo == target.CarMngNo)
                 && (this.NumberPlate1Code == target.NumberPlate1Code)
                 && (this.NumberPlate1Name == target.NumberPlate1Name)
                 && (this.NumberPlate2 == target.NumberPlate2)
                 && (this.NumberPlate3 == target.NumberPlate3)
                 && (this.NumberPlate4 == target.NumberPlate4)
                 && (this.MakerName == target.MakerName)
                 && (this.ModelName == target.ModelName)
                 && (this.MailAddress == target.MailAddress)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailFormal == target.MailFormal)
                 && (this.ExtraAssemblyDivide == target.ExtraAssemblyDivide)
                 && (this.MailDocumentNo == target.MailDocumentNo)
                 && (this.MailDocCode == target.MailDocCode)
                 && (this.CheckKindCode == target.CheckKindCode)
                 && (this.CheckDivCd == target.CheckDivCd)
                 && (this.MailTitle == target.MailTitle)
                 && (this.MailDocumentCnts == target.MailDocumentCnts)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 // 2008.07.01 R.Sokei ADD >>>>
                 && (this.MailMngGuid == target.MailMngGuid)
                 // 2008.07.01 R.Sokei ADD <<<<
                 && (this.CarbonCopy == target.CarbonCopy)
                 && (this.AttachFile == target.AttachFile));
        }

		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^��r����
		/// </summary>
		/// <param name="mailBackup1">
		///                    ��r����MailBackup�N���X�̃C���X�^���X
		/// </param>
		/// <param name="mailBackup2">��r����MailBackup�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static bool Equals(MailBackup mailBackup1, MailBackup mailBackup2)
        {
            return ((mailBackup1.CreateDateTime == mailBackup2.CreateDateTime)
                 && (mailBackup1.UpdateDateTime == mailBackup2.UpdateDateTime)
                 && (mailBackup1.EnterpriseCode == mailBackup2.EnterpriseCode)
                 && (mailBackup1.FileHeaderGuid == mailBackup2.FileHeaderGuid)
                 && (mailBackup1.UpdEmployeeCode == mailBackup2.UpdEmployeeCode)
                 && (mailBackup1.UpdAssemblyId1 == mailBackup2.UpdAssemblyId1)
                 && (mailBackup1.UpdAssemblyId2 == mailBackup2.UpdAssemblyId2)
                 && (mailBackup1.LogicalDeleteCode == mailBackup2.LogicalDeleteCode)
                 && (mailBackup1.SendSectionCode == mailBackup2.SendSectionCode)
                 && (mailBackup1.MailManagementConsNo == mailBackup2.MailManagementConsNo)
                 && (mailBackup1.MailStatus == mailBackup2.MailStatus)
                 && (mailBackup1.SendDateTime == mailBackup2.SendDateTime)
                 && (mailBackup1.CustomerCode == mailBackup2.CustomerCode)
                 && (mailBackup1.Name == mailBackup2.Name)
                 && (mailBackup1.Name2 == mailBackup2.Name2)
                 && (mailBackup1.HonorificTitle == mailBackup2.HonorificTitle)
                 && (mailBackup1.Kana == mailBackup2.Kana)
                 && (mailBackup1.CarMngNo == mailBackup2.CarMngNo)
                 && (mailBackup1.NumberPlate1Code == mailBackup2.NumberPlate1Code)
                 && (mailBackup1.NumberPlate1Name == mailBackup2.NumberPlate1Name)
                 && (mailBackup1.NumberPlate2 == mailBackup2.NumberPlate2)
                 && (mailBackup1.NumberPlate3 == mailBackup2.NumberPlate3)
                 && (mailBackup1.NumberPlate4 == mailBackup2.NumberPlate4)
                 && (mailBackup1.MakerName == mailBackup2.MakerName)
                 && (mailBackup1.ModelName == mailBackup2.ModelName)
                 && (mailBackup1.MailAddress == mailBackup2.MailAddress)
                 && (mailBackup1.MailAddrKindCode1 == mailBackup2.MailAddrKindCode1)
                 && (mailBackup1.MailAddrKindName1 == mailBackup2.MailAddrKindName1)
                 && (mailBackup1.MailSendCode1 == mailBackup2.MailSendCode1)
                 && (mailBackup1.MailFormal == mailBackup2.MailFormal)
                 && (mailBackup1.ExtraAssemblyDivide == mailBackup2.ExtraAssemblyDivide)
                 && (mailBackup1.MailDocumentNo == mailBackup2.MailDocumentNo)
                 && (mailBackup1.MailDocCode == mailBackup2.MailDocCode)
                 && (mailBackup1.CheckKindCode == mailBackup2.CheckKindCode)
                 && (mailBackup1.CheckDivCd == mailBackup2.CheckDivCd)
                 && (mailBackup1.MailTitle == mailBackup2.MailTitle)
                 && (mailBackup1.MailDocumentCnts == mailBackup2.MailDocumentCnts)
                 && (mailBackup1.EnterpriseName == mailBackup2.EnterpriseName)
                 && (mailBackup1.UpdEmployeeName == mailBackup2.UpdEmployeeName)
                 // 2008.07.01 R.Sokei ADD >>>>
                 && (mailBackup1.MailMngGuid == mailBackup2.MailMngGuid)
                 // 2008.07.01 R.Sokei ADD <<<<
                 && (mailBackup1.CarbonCopy == mailBackup2.CarbonCopy)
                 && (mailBackup1.AttachFile == mailBackup2.AttachFile));
        }


		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MailBackup�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(MailBackup target)
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
			if(this.SendSectionCode != target.SendSectionCode)resList.Add("SendSectionCode");
			if(this.MailManagementConsNo != target.MailManagementConsNo)resList.Add("MailManagementConsNo");
			if(this.MailStatus != target.MailStatus)resList.Add("MailStatus");
			if(this.SendDateTime != target.SendDateTime)resList.Add("SendDateTime");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.Name != target.Name)resList.Add("Name");
			if(this.Name2 != target.Name2)resList.Add("Name2");
			if(this.HonorificTitle != target.HonorificTitle)resList.Add("HonorificTitle");
			if(this.Kana != target.Kana)resList.Add("Kana");
			if(this.CarMngNo != target.CarMngNo)resList.Add("CarMngNo");
			if(this.NumberPlate1Code != target.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(this.NumberPlate1Name != target.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(this.NumberPlate2 != target.NumberPlate2)resList.Add("NumberPlate2");
			if(this.NumberPlate3 != target.NumberPlate3)resList.Add("NumberPlate3");
			if(this.NumberPlate4 != target.NumberPlate4)resList.Add("NumberPlate4");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.ModelName != target.ModelName)resList.Add("ModelName");
			if(this.MailAddress != target.MailAddress)resList.Add("MailAddress");
			if(this.MailAddrKindCode1 != target.MailAddrKindCode1)resList.Add("MailAddrKindCode1");
			if(this.MailAddrKindName1 != target.MailAddrKindName1)resList.Add("MailAddrKindName1");
			if(this.MailSendCode1 != target.MailSendCode1)resList.Add("MailSendCode1");
			if(this.MailFormal != target.MailFormal)resList.Add("MailFormal");
			if(this.ExtraAssemblyDivide != target.ExtraAssemblyDivide)resList.Add("ExtraAssemblyDivide");
			if(this.MailDocumentNo != target.MailDocumentNo)resList.Add("MailDocumentNo");
			if(this.MailDocCode != target.MailDocCode)resList.Add("MailDocCode");
			if(this.CheckKindCode != target.CheckKindCode)resList.Add("CheckKindCode");
			if(this.CheckDivCd != target.CheckDivCd)resList.Add("CheckDivCd");
			if(this.MailTitle != target.MailTitle)resList.Add("MailTitle");
			if(this.MailDocumentCnts != target.MailDocumentCnts)resList.Add("MailDocumentCnts");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            // 2008.07.01 R.Sokei ADD >>>>
            if (this.MailMngGuid != target.MailMngGuid) resList.Add("MailMngGuid");
            // 2008.07.01 R.Sokei ADD <<<<
            if (this.CarbonCopy != target.CarbonCopy) resList.Add("CarbonCopy");
            if (this.AttachFile != target.AttachFile) resList.Add("AttachFile");

			return resList;
		}

		/// <summary>
		/// ���[���o�b�N�A�b�v�}�X�^��r����
		/// </summary>
		/// <param name="mailBackup1">��r����MailBackup�N���X�̃C���X�^���X</param>
		/// <param name="mailBackup2">��r����MailBackup�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailBackup�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(MailBackup mailBackup1, MailBackup mailBackup2)
		{
			ArrayList resList = new ArrayList();
			if(mailBackup1.CreateDateTime != mailBackup2.CreateDateTime)resList.Add("CreateDateTime");
			if(mailBackup1.UpdateDateTime != mailBackup2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(mailBackup1.EnterpriseCode != mailBackup2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(mailBackup1.FileHeaderGuid != mailBackup2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(mailBackup1.UpdEmployeeCode != mailBackup2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(mailBackup1.UpdAssemblyId1 != mailBackup2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(mailBackup1.UpdAssemblyId2 != mailBackup2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(mailBackup1.LogicalDeleteCode != mailBackup2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(mailBackup1.SendSectionCode != mailBackup2.SendSectionCode)resList.Add("SendSectionCode");
			if(mailBackup1.MailManagementConsNo != mailBackup2.MailManagementConsNo)resList.Add("MailManagementConsNo");
			if(mailBackup1.MailStatus != mailBackup2.MailStatus)resList.Add("MailStatus");
			if(mailBackup1.SendDateTime != mailBackup2.SendDateTime)resList.Add("SendDateTime");
			if(mailBackup1.CustomerCode != mailBackup2.CustomerCode)resList.Add("CustomerCode");
			if(mailBackup1.Name != mailBackup2.Name)resList.Add("Name");
			if(mailBackup1.Name2 != mailBackup2.Name2)resList.Add("Name2");
			if(mailBackup1.HonorificTitle != mailBackup2.HonorificTitle)resList.Add("HonorificTitle");
			if(mailBackup1.Kana != mailBackup2.Kana)resList.Add("Kana");
			if(mailBackup1.CarMngNo != mailBackup2.CarMngNo)resList.Add("CarMngNo");
			if(mailBackup1.NumberPlate1Code != mailBackup2.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(mailBackup1.NumberPlate1Name != mailBackup2.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(mailBackup1.NumberPlate2 != mailBackup2.NumberPlate2)resList.Add("NumberPlate2");
			if(mailBackup1.NumberPlate3 != mailBackup2.NumberPlate3)resList.Add("NumberPlate3");
			if(mailBackup1.NumberPlate4 != mailBackup2.NumberPlate4)resList.Add("NumberPlate4");
			if(mailBackup1.MakerName != mailBackup2.MakerName)resList.Add("MakerName");
			if(mailBackup1.ModelName != mailBackup2.ModelName)resList.Add("ModelName");
			if(mailBackup1.MailAddress != mailBackup2.MailAddress)resList.Add("MailAddress");
			if(mailBackup1.MailAddrKindCode1 != mailBackup2.MailAddrKindCode1)resList.Add("MailAddrKindCode1");
			if(mailBackup1.MailAddrKindName1 != mailBackup2.MailAddrKindName1)resList.Add("MailAddrKindName1");
			if(mailBackup1.MailSendCode1 != mailBackup2.MailSendCode1)resList.Add("MailSendCode1");
			if(mailBackup1.MailFormal != mailBackup2.MailFormal)resList.Add("MailFormal");
			if(mailBackup1.ExtraAssemblyDivide != mailBackup2.ExtraAssemblyDivide)resList.Add("ExtraAssemblyDivide");
			if(mailBackup1.MailDocumentNo != mailBackup2.MailDocumentNo)resList.Add("MailDocumentNo");
			if(mailBackup1.MailDocCode != mailBackup2.MailDocCode)resList.Add("MailDocCode");
			if(mailBackup1.CheckKindCode != mailBackup2.CheckKindCode)resList.Add("CheckKindCode");
			if(mailBackup1.CheckDivCd != mailBackup2.CheckDivCd)resList.Add("CheckDivCd");
			if(mailBackup1.MailTitle != mailBackup2.MailTitle)resList.Add("MailTitle");
			if(mailBackup1.MailDocumentCnts != mailBackup2.MailDocumentCnts)resList.Add("MailDocumentCnts");
			if(mailBackup1.EnterpriseName != mailBackup2.EnterpriseName)resList.Add("EnterpriseName");
			if(mailBackup1.UpdEmployeeName != mailBackup2.UpdEmployeeName)resList.Add("UpdEmployeeName");
            // 2008.07.01 R.Sokei ADD >>>>
            if (mailBackup1.MailMngGuid != mailBackup2.MailMngGuid) resList.Add("MailMngGuid");
            // 2008.07.01 R.Sokei ADD <<<<
            if (mailBackup1.CarbonCopy != mailBackup2.CarbonCopy) resList.Add("CarbonCopy");
            if (mailBackup1.AttachFile != mailBackup2.AttachFile) resList.Add("AttachFile");

			return resList;
		}
	}
}
