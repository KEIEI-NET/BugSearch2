using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData.StubDB
{
	/// public class name:   SCMAcOdrDtCar
	/// <summary>
	///                      SCM�󒍃f�[�^(�ԗ����)
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍃f�[�^(�ԗ����)�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �⍇����</br>
	/// <br>                 :   �⍇���]�ƈ��R�[�h</br>
	/// <br>                 :   �⍇���]�ƈ�����</br>
	/// <br>                 :   ������</br>
	/// <br>                 :   �����ҏ]�ƈ��R�[�h</br>
	/// <br>                 :   �����ҏ]�ƈ�����</br>
	/// </remarks>
	public class SCMAcOdrDtCar
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

		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇���ԍ�</summary>
		private Int64 _inquiryNumber;

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

		/// <summary>�^���w��ԍ�</summary>
		private Int32 _modelDesignationNo;

		/// <summary>�ޕʔԍ�</summary>
		private Int32 _categoryNo;

		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>�Ԏ�R�[�h</summary>
		/// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _modelCode;

		/// <summary>�Ԏ�T�u�R�[�h</summary>
		/// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
		private Int32 _modelSubCode;

		/// <summary>�Ԏ햼</summary>
		private string _modelName = "";

		/// <summary>�Ԍ��،^��</summary>
		private string _carInspectCertModel = "";

		/// <summary>�^���i�t���^�j</summary>
		/// <remarks>�t���^��(44���p)</remarks>
		private string _fullModel = "";

		/// <summary>�ԑ�ԍ�</summary>
		private string _frameNo = "";

		/// <summary>�ԑ�^��</summary>
		private string _frameModel = "";

		/// <summary>�V���V�[No</summary>
		private string _chassisNo = "";

		/// <summary>�ԗ��ŗL�ԍ�</summary>
		/// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
		private Int32 _carProperNo;

		/// <summary>���Y�N���iNUM�^�C�v�j</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _produceTypeOfYearNum;

		/// <summary>�R�����g</summary>
		/// <remarks>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</remarks>
		private string _comment = "";

		/// <summary>���y�A�J���[�R�[�h</summary>
		/// <remarks>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</remarks>
		private string _rpColorCode = "";

		/// <summary>�J���[����1</summary>
		/// <remarks>��ʕ\���p��������</remarks>
		private string _colorName1 = "";

		/// <summary>�g�����R�[�h</summary>
		private string _trimCode = "";

		/// <summary>�g��������</summary>
		private string _trimName = "";

		/// <summary>�ԗ����s����</summary>
		private Int32 _mileage;

		/// <summary>�����I�u�W�F�N�g</summary>
		private Byte[] _equipObj;

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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
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

		/// public propaty name  :  ModelDesignationNo
		/// <summary>�^���w��ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^���w��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get{return _modelDesignationNo;}
			set{_modelDesignationNo = value;}
		}

		/// public propaty name  :  CategoryNo
		/// <summary>�ޕʔԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ޕʔԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get{return _categoryNo;}
			set{_categoryNo = value;}
		}

		/// public propaty name  :  MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get{return _makerCode;}
			set{_makerCode = value;}
		}

		/// public propaty name  :  ModelCode
		/// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
		/// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get{return _modelCode;}
			set{_modelCode = value;}
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
		/// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get{return _modelSubCode;}
			set{_modelSubCode = value;}
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

		/// public propaty name  :  CarInspectCertModel
		/// <summary>�Ԍ��،^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԍ��،^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarInspectCertModel
		{
			get{return _carInspectCertModel;}
			set{_carInspectCertModel = value;}
		}

		/// public propaty name  :  FullModel
		/// <summary>�^���i�t���^�j�v���p�e�B</summary>
		/// <value>�t���^��(44���p)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FullModel
		{
			get{return _fullModel;}
			set{_fullModel = value;}
		}

		/// public propaty name  :  FrameNo
		/// <summary>�ԑ�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameNo
		{
			get{return _frameNo;}
			set{_frameNo = value;}
		}

		/// public propaty name  :  FrameModel
		/// <summary>�ԑ�^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameModel
		{
			get{return _frameModel;}
			set{_frameModel = value;}
		}

		/// public propaty name  :  ChassisNo
		/// <summary>�V���V�[No�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V���V�[No�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ChassisNo
		{
			get{return _chassisNo;}
			set{_chassisNo = value;}
		}

		/// public propaty name  :  CarProperNo
		/// <summary>�ԗ��ŗL�ԍ��v���p�e�B</summary>
		/// <value>���j�[�N�ȌŒ�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��ŗL�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarProperNo
		{
			get{return _carProperNo;}
			set{_carProperNo = value;}
		}

		/// public propaty name  :  ProduceTypeOfYearNum
		/// <summary>���Y�N���iNUM�^�C�v�j�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Y�N���iNUM�^�C�v�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ProduceTypeOfYearNum
		{
			get{return _produceTypeOfYearNum;}
			set{_produceTypeOfYearNum = value;}
		}

		/// public propaty name  :  Comment
		/// <summary>�R�����g�v���p�e�B</summary>
		/// <value>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �R�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}

		/// public propaty name  :  RpColorCode
		/// <summary>���y�A�J���[�R�[�h�v���p�e�B</summary>
		/// <value>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���y�A�J���[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RpColorCode
		{
			get{return _rpColorCode;}
			set{_rpColorCode = value;}
		}

		/// public propaty name  :  ColorName1
		/// <summary>�J���[����1�v���p�e�B</summary>
		/// <value>��ʕ\���p��������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J���[����1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ColorName1
		{
			get{return _colorName1;}
			set{_colorName1 = value;}
		}

		/// public propaty name  :  TrimCode
		/// <summary>�g�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TrimCode
		{
			get{return _trimCode;}
			set{_trimCode = value;}
		}

		/// public propaty name  :  TrimName
		/// <summary>�g�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g�������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TrimName
		{
			get{return _trimName;}
			set{_trimName = value;}
		}

		/// public propaty name  :  Mileage
		/// <summary>�ԗ����s�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ����s�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Mileage
		{
			get{return _mileage;}
			set{_mileage = value;}
		}

		/// public propaty name  :  EquipObj
		/// <summary>�����I�u�W�F�N�g�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����I�u�W�F�N�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Byte[] EquipObj
		{
			get{return _equipObj;}
			set{_equipObj = value;}
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


		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrDtCar�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDtCar()
		{
		}

		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
		/// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
		/// <param name="inquiryNumber">�⍇���ԍ�</param>
		/// <param name="numberPlate1Code">���^�������ԍ�</param>
		/// <param name="numberPlate1Name">���^�����ǖ���</param>
		/// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
		/// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
		/// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
		/// <param name="modelDesignationNo">�^���w��ԍ�</param>
		/// <param name="categoryNo">�ޕʔԍ�</param>
		/// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
		/// <param name="modelCode">�Ԏ�R�[�h(�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
		/// <param name="modelSubCode">�Ԏ�T�u�R�[�h(0�`899:�񋟕�,900�`հ�ް�o�^)</param>
		/// <param name="modelName">�Ԏ햼</param>
		/// <param name="carInspectCertModel">�Ԍ��،^��</param>
		/// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
		/// <param name="frameNo">�ԑ�ԍ�</param>
		/// <param name="frameModel">�ԑ�^��</param>
		/// <param name="chassisNo">�V���V�[No</param>
		/// <param name="carProperNo">�ԗ��ŗL�ԍ�(���j�[�N�ȌŒ�ԍ�)</param>
		/// <param name="produceTypeOfYearNum">���Y�N���iNUM�^�C�v�j(YYYYMM)</param>
		/// <param name="comment">�R�����g(�J�^���O�̃R�����g��P�ʁE�J���[���i�[)</param>
		/// <param name="rpColorCode">���y�A�J���[�R�[�h(�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j)</param>
		/// <param name="colorName1">�J���[����1(��ʕ\���p��������)</param>
		/// <param name="trimCode">�g�����R�[�h</param>
		/// <param name="trimName">�g��������</param>
		/// <param name="mileage">�ԗ����s����</param>
		/// <param name="equipObj">�����I�u�W�F�N�g</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>SCMAcOdrDtCar�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDtCar(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string inqOriginalEpCd,string inqOriginalSecCd,Int64 inquiryNumber,Int32 numberPlate1Code,string numberPlate1Name,string numberPlate2,string numberPlate3,Int32 numberPlate4,Int32 modelDesignationNo,Int32 categoryNo,Int32 makerCode,Int32 modelCode,Int32 modelSubCode,string modelName,string carInspectCertModel,string fullModel,string frameNo,string frameModel,string chassisNo,Int32 carProperNo,Int32 produceTypeOfYearNum,string comment,string rpColorCode,string colorName1,string trimCode,string trimName,Int32 mileage,Byte[] equipObj,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inquiryNumber = inquiryNumber;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._modelDesignationNo = modelDesignationNo;
			this._categoryNo = categoryNo;
			this._makerCode = makerCode;
			this._modelCode = modelCode;
			this._modelSubCode = modelSubCode;
			this._modelName = modelName;
			this._carInspectCertModel = carInspectCertModel;
			this._fullModel = fullModel;
			this._frameNo = frameNo;
			this._frameModel = frameModel;
			this._chassisNo = chassisNo;
			this._carProperNo = carProperNo;
			this._produceTypeOfYearNum = produceTypeOfYearNum;
			this._comment = comment;
			this._rpColorCode = rpColorCode;
			this._colorName1 = colorName1;
			this._trimCode = trimCode;
			this._trimName = trimName;
			this._mileage = mileage;
			this._equipObj = equipObj;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)��������
		/// </summary>
		/// <returns>SCMAcOdrDtCar�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMAcOdrDtCar�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDtCar Clone()
		{
			return new SCMAcOdrDtCar(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inquiryNumber,this._numberPlate1Code,this._numberPlate1Name,this._numberPlate2,this._numberPlate3,this._numberPlate4,this._modelDesignationNo,this._categoryNo,this._makerCode,this._modelCode,this._modelSubCode,this._modelName,this._carInspectCertModel,this._fullModel,this._frameNo,this._frameModel,this._chassisNo,this._carProperNo,this._produceTypeOfYearNum,this._comment,this._rpColorCode,this._colorName1,this._trimCode,this._trimName,this._mileage,this._equipObj,this._enterpriseName,this._updEmployeeName);//@@@@20230303
		}

		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAcOdrDtCar�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCar�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SCMAcOdrDtCar target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.NumberPlate1Code == target.NumberPlate1Code)
				 && (this.NumberPlate1Name == target.NumberPlate1Name)
				 && (this.NumberPlate2 == target.NumberPlate2)
				 && (this.NumberPlate3 == target.NumberPlate3)
				 && (this.NumberPlate4 == target.NumberPlate4)
				 && (this.ModelDesignationNo == target.ModelDesignationNo)
				 && (this.CategoryNo == target.CategoryNo)
				 && (this.MakerCode == target.MakerCode)
				 && (this.ModelCode == target.ModelCode)
				 && (this.ModelSubCode == target.ModelSubCode)
				 && (this.ModelName == target.ModelName)
				 && (this.CarInspectCertModel == target.CarInspectCertModel)
				 && (this.FullModel == target.FullModel)
				 && (this.FrameNo == target.FrameNo)
				 && (this.FrameModel == target.FrameModel)
				 && (this.ChassisNo == target.ChassisNo)
				 && (this.CarProperNo == target.CarProperNo)
				 && (this.ProduceTypeOfYearNum == target.ProduceTypeOfYearNum)
				 && (this.Comment == target.Comment)
				 && (this.RpColorCode == target.RpColorCode)
				 && (this.ColorName1 == target.ColorName1)
				 && (this.TrimCode == target.TrimCode)
				 && (this.TrimName == target.TrimName)
				 && (this.Mileage == target.Mileage)
				 && (this.EquipObj == target.EquipObj)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)��r����
		/// </summary>
		/// <param name="sCMAcOdrDtCar1">
		///                    ��r����SCMAcOdrDtCar�N���X�̃C���X�^���X
		/// </param>
		/// <param name="sCMAcOdrDtCar2">��r����SCMAcOdrDtCar�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCar�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SCMAcOdrDtCar sCMAcOdrDtCar1, SCMAcOdrDtCar sCMAcOdrDtCar2)
		{
			return ((sCMAcOdrDtCar1.CreateDateTime == sCMAcOdrDtCar2.CreateDateTime)
				 && (sCMAcOdrDtCar1.UpdateDateTime == sCMAcOdrDtCar2.UpdateDateTime)
				 && (sCMAcOdrDtCar1.EnterpriseCode == sCMAcOdrDtCar2.EnterpriseCode)
				 && (sCMAcOdrDtCar1.FileHeaderGuid == sCMAcOdrDtCar2.FileHeaderGuid)
				 && (sCMAcOdrDtCar1.UpdEmployeeCode == sCMAcOdrDtCar2.UpdEmployeeCode)
				 && (sCMAcOdrDtCar1.UpdAssemblyId1 == sCMAcOdrDtCar2.UpdAssemblyId1)
				 && (sCMAcOdrDtCar1.UpdAssemblyId2 == sCMAcOdrDtCar2.UpdAssemblyId2)
				 && (sCMAcOdrDtCar1.LogicalDeleteCode == sCMAcOdrDtCar2.LogicalDeleteCode)
				 && (sCMAcOdrDtCar1.InqOriginalEpCd.Trim() == sCMAcOdrDtCar2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMAcOdrDtCar1.InqOriginalSecCd == sCMAcOdrDtCar2.InqOriginalSecCd)
				 && (sCMAcOdrDtCar1.InquiryNumber == sCMAcOdrDtCar2.InquiryNumber)
				 && (sCMAcOdrDtCar1.NumberPlate1Code == sCMAcOdrDtCar2.NumberPlate1Code)
				 && (sCMAcOdrDtCar1.NumberPlate1Name == sCMAcOdrDtCar2.NumberPlate1Name)
				 && (sCMAcOdrDtCar1.NumberPlate2 == sCMAcOdrDtCar2.NumberPlate2)
				 && (sCMAcOdrDtCar1.NumberPlate3 == sCMAcOdrDtCar2.NumberPlate3)
				 && (sCMAcOdrDtCar1.NumberPlate4 == sCMAcOdrDtCar2.NumberPlate4)
				 && (sCMAcOdrDtCar1.ModelDesignationNo == sCMAcOdrDtCar2.ModelDesignationNo)
				 && (sCMAcOdrDtCar1.CategoryNo == sCMAcOdrDtCar2.CategoryNo)
				 && (sCMAcOdrDtCar1.MakerCode == sCMAcOdrDtCar2.MakerCode)
				 && (sCMAcOdrDtCar1.ModelCode == sCMAcOdrDtCar2.ModelCode)
				 && (sCMAcOdrDtCar1.ModelSubCode == sCMAcOdrDtCar2.ModelSubCode)
				 && (sCMAcOdrDtCar1.ModelName == sCMAcOdrDtCar2.ModelName)
				 && (sCMAcOdrDtCar1.CarInspectCertModel == sCMAcOdrDtCar2.CarInspectCertModel)
				 && (sCMAcOdrDtCar1.FullModel == sCMAcOdrDtCar2.FullModel)
				 && (sCMAcOdrDtCar1.FrameNo == sCMAcOdrDtCar2.FrameNo)
				 && (sCMAcOdrDtCar1.FrameModel == sCMAcOdrDtCar2.FrameModel)
				 && (sCMAcOdrDtCar1.ChassisNo == sCMAcOdrDtCar2.ChassisNo)
				 && (sCMAcOdrDtCar1.CarProperNo == sCMAcOdrDtCar2.CarProperNo)
				 && (sCMAcOdrDtCar1.ProduceTypeOfYearNum == sCMAcOdrDtCar2.ProduceTypeOfYearNum)
				 && (sCMAcOdrDtCar1.Comment == sCMAcOdrDtCar2.Comment)
				 && (sCMAcOdrDtCar1.RpColorCode == sCMAcOdrDtCar2.RpColorCode)
				 && (sCMAcOdrDtCar1.ColorName1 == sCMAcOdrDtCar2.ColorName1)
				 && (sCMAcOdrDtCar1.TrimCode == sCMAcOdrDtCar2.TrimCode)
				 && (sCMAcOdrDtCar1.TrimName == sCMAcOdrDtCar2.TrimName)
				 && (sCMAcOdrDtCar1.Mileage == sCMAcOdrDtCar2.Mileage)
				 && (sCMAcOdrDtCar1.EquipObj == sCMAcOdrDtCar2.EquipObj)
				 && (sCMAcOdrDtCar1.EnterpriseName == sCMAcOdrDtCar2.EnterpriseName)
				 && (sCMAcOdrDtCar1.UpdEmployeeName == sCMAcOdrDtCar2.UpdEmployeeName));
		}
		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAcOdrDtCar�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCar�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SCMAcOdrDtCar target)
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
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.NumberPlate1Code != target.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(this.NumberPlate1Name != target.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(this.NumberPlate2 != target.NumberPlate2)resList.Add("NumberPlate2");
			if(this.NumberPlate3 != target.NumberPlate3)resList.Add("NumberPlate3");
			if(this.NumberPlate4 != target.NumberPlate4)resList.Add("NumberPlate4");
			if(this.ModelDesignationNo != target.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(this.CategoryNo != target.CategoryNo)resList.Add("CategoryNo");
			if(this.MakerCode != target.MakerCode)resList.Add("MakerCode");
			if(this.ModelCode != target.ModelCode)resList.Add("ModelCode");
			if(this.ModelSubCode != target.ModelSubCode)resList.Add("ModelSubCode");
			if(this.ModelName != target.ModelName)resList.Add("ModelName");
			if(this.CarInspectCertModel != target.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(this.FullModel != target.FullModel)resList.Add("FullModel");
			if(this.FrameNo != target.FrameNo)resList.Add("FrameNo");
			if(this.FrameModel != target.FrameModel)resList.Add("FrameModel");
			if(this.ChassisNo != target.ChassisNo)resList.Add("ChassisNo");
			if(this.CarProperNo != target.CarProperNo)resList.Add("CarProperNo");
			if(this.ProduceTypeOfYearNum != target.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(this.Comment != target.Comment)resList.Add("Comment");
			if(this.RpColorCode != target.RpColorCode)resList.Add("RpColorCode");
			if(this.ColorName1 != target.ColorName1)resList.Add("ColorName1");
			if(this.TrimCode != target.TrimCode)resList.Add("TrimCode");
			if(this.TrimName != target.TrimName)resList.Add("TrimName");
			if(this.Mileage != target.Mileage)resList.Add("Mileage");
			if(this.EquipObj != target.EquipObj)resList.Add("EquipObj");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)��r����
		/// </summary>
		/// <param name="sCMAcOdrDtCar1">��r����SCMAcOdrDtCar�N���X�̃C���X�^���X</param>
		/// <param name="sCMAcOdrDtCar2">��r����SCMAcOdrDtCar�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCar�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SCMAcOdrDtCar sCMAcOdrDtCar1, SCMAcOdrDtCar sCMAcOdrDtCar2)
		{
			ArrayList resList = new ArrayList();
			if(sCMAcOdrDtCar1.CreateDateTime != sCMAcOdrDtCar2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMAcOdrDtCar1.UpdateDateTime != sCMAcOdrDtCar2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMAcOdrDtCar1.EnterpriseCode != sCMAcOdrDtCar2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMAcOdrDtCar1.FileHeaderGuid != sCMAcOdrDtCar2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMAcOdrDtCar1.UpdEmployeeCode != sCMAcOdrDtCar2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMAcOdrDtCar1.UpdAssemblyId1 != sCMAcOdrDtCar2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMAcOdrDtCar1.UpdAssemblyId2 != sCMAcOdrDtCar2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMAcOdrDtCar1.LogicalDeleteCode != sCMAcOdrDtCar2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMAcOdrDtCar1.InqOriginalEpCd.Trim() != sCMAcOdrDtCar2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMAcOdrDtCar1.InqOriginalSecCd != sCMAcOdrDtCar2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMAcOdrDtCar1.InquiryNumber != sCMAcOdrDtCar2.InquiryNumber)resList.Add("InquiryNumber");
			if(sCMAcOdrDtCar1.NumberPlate1Code != sCMAcOdrDtCar2.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(sCMAcOdrDtCar1.NumberPlate1Name != sCMAcOdrDtCar2.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(sCMAcOdrDtCar1.NumberPlate2 != sCMAcOdrDtCar2.NumberPlate2)resList.Add("NumberPlate2");
			if(sCMAcOdrDtCar1.NumberPlate3 != sCMAcOdrDtCar2.NumberPlate3)resList.Add("NumberPlate3");
			if(sCMAcOdrDtCar1.NumberPlate4 != sCMAcOdrDtCar2.NumberPlate4)resList.Add("NumberPlate4");
			if(sCMAcOdrDtCar1.ModelDesignationNo != sCMAcOdrDtCar2.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(sCMAcOdrDtCar1.CategoryNo != sCMAcOdrDtCar2.CategoryNo)resList.Add("CategoryNo");
			if(sCMAcOdrDtCar1.MakerCode != sCMAcOdrDtCar2.MakerCode)resList.Add("MakerCode");
			if(sCMAcOdrDtCar1.ModelCode != sCMAcOdrDtCar2.ModelCode)resList.Add("ModelCode");
			if(sCMAcOdrDtCar1.ModelSubCode != sCMAcOdrDtCar2.ModelSubCode)resList.Add("ModelSubCode");
			if(sCMAcOdrDtCar1.ModelName != sCMAcOdrDtCar2.ModelName)resList.Add("ModelName");
			if(sCMAcOdrDtCar1.CarInspectCertModel != sCMAcOdrDtCar2.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(sCMAcOdrDtCar1.FullModel != sCMAcOdrDtCar2.FullModel)resList.Add("FullModel");
			if(sCMAcOdrDtCar1.FrameNo != sCMAcOdrDtCar2.FrameNo)resList.Add("FrameNo");
			if(sCMAcOdrDtCar1.FrameModel != sCMAcOdrDtCar2.FrameModel)resList.Add("FrameModel");
			if(sCMAcOdrDtCar1.ChassisNo != sCMAcOdrDtCar2.ChassisNo)resList.Add("ChassisNo");
			if(sCMAcOdrDtCar1.CarProperNo != sCMAcOdrDtCar2.CarProperNo)resList.Add("CarProperNo");
			if(sCMAcOdrDtCar1.ProduceTypeOfYearNum != sCMAcOdrDtCar2.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(sCMAcOdrDtCar1.Comment != sCMAcOdrDtCar2.Comment)resList.Add("Comment");
			if(sCMAcOdrDtCar1.RpColorCode != sCMAcOdrDtCar2.RpColorCode)resList.Add("RpColorCode");
			if(sCMAcOdrDtCar1.ColorName1 != sCMAcOdrDtCar2.ColorName1)resList.Add("ColorName1");
			if(sCMAcOdrDtCar1.TrimCode != sCMAcOdrDtCar2.TrimCode)resList.Add("TrimCode");
			if(sCMAcOdrDtCar1.TrimName != sCMAcOdrDtCar2.TrimName)resList.Add("TrimName");
			if(sCMAcOdrDtCar1.Mileage != sCMAcOdrDtCar2.Mileage)resList.Add("Mileage");
			if(sCMAcOdrDtCar1.EquipObj != sCMAcOdrDtCar2.EquipObj)resList.Add("EquipObj");
			if(sCMAcOdrDtCar1.EnterpriseName != sCMAcOdrDtCar2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMAcOdrDtCar1.UpdEmployeeName != sCMAcOdrDtCar2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
