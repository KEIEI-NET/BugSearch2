//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�֘A�f�[�^�f�[�^�p�����[�^
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SCMAcOdrDtCarWork
	/// <summary>
	///                      SCM�󒍃f�[�^(�ԗ����)���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍃f�[�^(�ԗ����)���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/05/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �⍇����</br>
	/// <br>                 :   �⍇���]�ƈ��R�[�h</br>
	/// <br>                 :   �⍇���]�ƈ�����</br>
	/// <br>                 :   ������</br>
	/// <br>                 :   �����ҏ]�ƈ��R�[�h</br>
	/// <br>                 :   �����ҏ]�ƈ�����</br>
	/// <br>Update Note      :   2009/06/17  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �󒍃X�e�[�^�X</br>
	/// <br>                 :   ����`�[�ԍ�</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,10,11��3,9,10,11,37,38</br>
	/// <br>Update Note      :   2011/8/18  ���n</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ��39�`��40</br>
	/// <br>Update Note      :   2011/8/24  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �~�b�V��������</br>
	/// <br>                 :   �V�t�g����</br>
    /// <br>Update Note      :   2012/05/31  30744 ���� ����q</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���N�x�iNUM�^�C�v�j</br>
    /// <br>                 :   �ԗ��t�����I�u�W�F�N�g</br>
    /// <br>                 :   �������i�I�u�W�F�N�g</br>
    /// <br>Update Note      :   2013/04/19  30744 ���� ����q</br>
    /// <br>                 :   SCM��Q��10521�Ή�</br>
    /// <br>                 :   �ԗ��Ǘ��R�[�h�ǉ�</br>
    /// <br>Update Note      :   2013/05/09  30747 �O�� �L��</br>
    /// <br>                 :   SCM��Q��10384�Ή�</br>
    /// <br>                 :   ���ɗ\����ǉ�</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDtCarWork : IFileHeader
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
		private Byte[] _equipObj = new Byte[0];

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

		/// <summary>����</summary>
		private string _carNo = "";

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>�O���[�h����</summary>
		private string _gradeName = "";

		/// <summary>�{�f�B�[����</summary>
		private string _bodyName = "";

		/// <summary>�h�A��</summary>
		private Int32 _doorCount;

		/// <summary>�G���W���^������</summary>
		/// <remarks>�^���ɂ��ϓ�</remarks>
		private string _engineModelNm = "";

		/// <summary>�ʏ̔r�C��</summary>
		/// <remarks>1600,2000��</remarks>
		private Int32 _cmnNmEngineDisPlace;

		/// <summary>�����@�^���i�G���W���j</summary>
		/// <remarks>�Ԍ��؋L�ڌ����@�^��</remarks>
		private string _engineModel = "";

		/// <summary>�ϑ��i��</summary>
		/// <remarks>2:2��,3:3�����,6:6��</remarks>
		private Int32 _numberOfGear;

		/// <summary>�ϑ��@����</summary>
		private string _gearNm = "";

		/// <summary>E�敪����</summary>
		/// <remarks>�^���ɂ��ϓ�</remarks>
		private string _eDivNm = "";

		/// <summary>�~�b�V��������</summary>
		private string _transmissionNm = "";

		/// <summary>�V�t�g����</summary>
		private string _shiftNm = "";

        // ADD 2012/05/31 ----------------------------------------------------->>>>>
        /// <summary>���N�x�iNUM�^�C�v�j</summary>
        private Int32 _firstEntryDateNumTyp;

        /// <summary>�ԗ��t�����I�u�W�F�N�g</summary>
        private Byte[] _carAddInf = new Byte[0];

        /// <summary>�������i�I�u�W�F�N�g</summary>
        private Byte[] _equipPrtsObj = new Byte[0];
        // ADD 2012/05/31 -----------------------------------------------------<<<<<

        // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
        /// <summary>�ԗ��Ǘ��R�[�h</summary>
        private string _carMngCode = "";
        // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// <summary>���ɗ\���</summary>
        private Int32 _expectedCeDate;
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

		/// public propaty name  :  CarNo
		/// <summary>���ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarNo
		{
			get{return _carNo;}
			set{_carNo = value;}
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

		/// public propaty name  :  GradeName
		/// <summary>�O���[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O���[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GradeName
		{
			get{return _gradeName;}
			set{_gradeName = value;}
		}

		/// public propaty name  :  BodyName
		/// <summary>�{�f�B�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �{�f�B�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BodyName
		{
			get{return _bodyName;}
			set{_bodyName = value;}
		}

		/// public propaty name  :  DoorCount
		/// <summary>�h�A���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �h�A���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DoorCount
		{
			get{return _doorCount;}
			set{_doorCount = value;}
		}

		/// public propaty name  :  EngineModelNm
		/// <summary>�G���W���^�����̃v���p�e�B</summary>
		/// <value>�^���ɂ��ϓ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �G���W���^�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EngineModelNm
		{
			get{return _engineModelNm;}
			set{_engineModelNm = value;}
		}

		/// public propaty name  :  CmnNmEngineDisPlace
		/// <summary>�ʏ̔r�C�ʃv���p�e�B</summary>
		/// <value>1600,2000��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʏ̔r�C�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CmnNmEngineDisPlace
		{
			get{return _cmnNmEngineDisPlace;}
			set{_cmnNmEngineDisPlace = value;}
		}

		/// public propaty name  :  EngineModel
		/// <summary>�����@�^���i�G���W���j�v���p�e�B</summary>
		/// <value>�Ԍ��؋L�ڌ����@�^��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����@�^���i�G���W���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EngineModel
		{
			get{return _engineModel;}
			set{_engineModel = value;}
		}

		/// public propaty name  :  NumberOfGear
		/// <summary>�ϑ��i���v���p�e�B</summary>
		/// <value>2:2��,3:3�����,6:6��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ϑ��i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberOfGear
		{
			get{return _numberOfGear;}
			set{_numberOfGear = value;}
		}

		/// public propaty name  :  GearNm
		/// <summary>�ϑ��@���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ϑ��@���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GearNm
		{
			get{return _gearNm;}
			set{_gearNm = value;}
		}

		/// public propaty name  :  EDivNm
		/// <summary>E�敪���̃v���p�e�B</summary>
		/// <value>�^���ɂ��ϓ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   E�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EDivNm
		{
			get{return _eDivNm;}
			set{_eDivNm = value;}
		}

		/// public propaty name  :  TransmissionNm
		/// <summary>�~�b�V�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �~�b�V�������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TransmissionNm
		{
			get{return _transmissionNm;}
			set{_transmissionNm = value;}
		}

		/// public propaty name  :  ShiftNm
		/// <summary>�V�t�g���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�t�g���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ShiftNm
		{
			get{return _shiftNm;}
			set{_shiftNm = value;}
		}

        // ADD 2012/05/31 ----------------------------------------------------->>>>>
        /// public propaty name  :  FirstEntryDateNumTyp
        /// <summary>���N�x�iNUM�^�C�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�iNUM�^�C�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDateNumTyp
        {
            get { return _firstEntryDateNumTyp; }
            set { _firstEntryDateNumTyp = value; }
        }

        /// public propaty name  :  CarAddInf
        /// <summary>�ԗ��t�����I�u�W�F�N�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��t�����I�u�W�F�N�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] CarAddInf
        {
            get { return _carAddInf; }
            set { _carAddInf = value; }
        }

        /// public propaty name  :  EquipPrtsObj
        /// <summary>�������i�I�u�W�F�N�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i�I�u�W�F�N�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] EquipPrtsObj
        {
            get { return _equipPrtsObj; }
            set { _equipPrtsObj = value; }
        }

        // ADD 2012/05/31 -----------------------------------------------------<<<<<

        // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
        /// public propaty name  :  CarMngCode
        /// <summary>�ԗ��Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }
        // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// public propaty name  :  ExpectedCeDate
        /// <summary>���ɗ\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɗ\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExpectedCeDate
        {
            get { return _expectedCeDate; }
            set { _expectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

		/// <summary>
		/// SCM�󒍃f�[�^(�ԗ����)���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrDtCarWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCarWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDtCarWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMAcOdrDtCarWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCarWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMAcOdrDtCarWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCarWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAcOdrDtCarWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAcOdrDtCarWork || graph is ArrayList || graph is SCMAcOdrDtCarWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAcOdrDtCarWork).FullName));

            if (graph != null && graph is SCMAcOdrDtCarWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAcOdrDtCarWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAcOdrDtCarWork[])graph).Length;
            }
            else if (graph is SCMAcOdrDtCarWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //���^�������ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
            //���^�����ǖ���
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //�ԗ��o�^�ԍ��i��ʁj
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //�ԗ��o�^�ԍ��i�J�i�j
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //�Ԏ햼
            serInfo.MemberInfo.Add(typeof(string)); //ModelName
            //�Ԍ��،^��
            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //�ԑ�^��
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //�V���V�[No
            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
            //�ԗ��ŗL�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
            //���Y�N���iNUM�^�C�v�j
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
            //�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //Comment
            //���y�A�J���[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
            //�J���[����1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //�g�����R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //�g��������
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //�ԗ����s����
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //�����I�u�W�F�N�g
            serInfo.MemberInfo.Add(typeof(Byte[])); //EquipObj
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
    		//����
    		serInfo.MemberInfo.Add( typeof(string) ); //CarNo
    		//���[�J�[����
    		serInfo.MemberInfo.Add( typeof(string) ); //MakerName
    		//�O���[�h����
    		serInfo.MemberInfo.Add( typeof(string) ); //GradeName
    		//�{�f�B�[����
    		serInfo.MemberInfo.Add( typeof(string) ); //BodyName
    		//�h�A��
    		serInfo.MemberInfo.Add( typeof(Int32) ); //DoorCount
    		//�G���W���^������
    		serInfo.MemberInfo.Add( typeof(string) ); //EngineModelNm
    		//�ʏ̔r�C��
    		serInfo.MemberInfo.Add( typeof(Int32) ); //CmnNmEngineDisPlace
    		//�����@�^���i�G���W���j
    		serInfo.MemberInfo.Add( typeof(string) ); //EngineModel
    		//�ϑ��i��
    		serInfo.MemberInfo.Add( typeof(Int32) ); //NumberOfGear
    		//�ϑ��@����
    		serInfo.MemberInfo.Add( typeof(string) ); //GearNm
    		//E�敪����
    		serInfo.MemberInfo.Add( typeof(string) ); //EDivNm
    		//�~�b�V��������
    		serInfo.MemberInfo.Add( typeof(string) ); //TransmissionNm
    		//�V�t�g����
    		serInfo.MemberInfo.Add( typeof(string) ); //ShiftNm
            // ADD 2012/05/31 ----------------------------------------------------->>>>>
            //���N�x�iNUM�^�C�v�j
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDateNumTyp
            //�ԗ��t�����I�u�W�F�N�g
            serInfo.MemberInfo.Add(typeof(Byte[])); //CarAddInf
            //�������i�I�u�W�F�N�g
            serInfo.MemberInfo.Add(typeof(Byte[])); //EquipPrtsObj
            // ADD 2012/05/31 -----------------------------------------------------<<<<<

            // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
            //�ԗ��Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<

            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            //���ɗ\���
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectedCeDate
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAcOdrDtCarWork)
            {
                SCMAcOdrDtCarWork temp = (SCMAcOdrDtCarWork)graph;

                SetSCMAcOdrDtCarWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAcOdrDtCarWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAcOdrDtCarWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAcOdrDtCarWork temp in lst)
                {
                    SetSCMAcOdrDtCarWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAcOdrDtCarWork�����o��(public�v���p�e�B��)
        /// </summary>
        // UPD 2012/05/31 ---------------------------------->>>>>
        //private const int currentMemberCount = 51;
        // UPD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
        //private const int currentMemberCount = 54;
        // UPD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        //private const int currentMemberCount = 55;
        private const int currentMemberCount = 56;
        // UPD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        // UPD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<
        // UPD 2012/05/31 ----------------------------------<<<<<

        /// <summary>
        ///  SCMAcOdrDtCarWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCarWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMAcOdrDtCarWork(System.IO.BinaryWriter writer, SCMAcOdrDtCarWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //���^�������ԍ�
            writer.Write(temp.NumberPlate1Code);
            //���^�����ǖ���
            writer.Write(temp.NumberPlate1Name);
            //�ԗ��o�^�ԍ��i��ʁj
            writer.Write(temp.NumberPlate2);
            //�ԗ��o�^�ԍ��i�J�i�j
            writer.Write(temp.NumberPlate3);
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            writer.Write(temp.NumberPlate4);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //�Ԏ�R�[�h
            writer.Write(temp.ModelCode);
            //�Ԏ�T�u�R�[�h
            writer.Write(temp.ModelSubCode);
            //�Ԏ햼
            writer.Write(temp.ModelName);
            //�Ԍ��،^��
            writer.Write(temp.CarInspectCertModel);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�ԑ�ԍ�
            writer.Write(temp.FrameNo);
            //�ԑ�^��
            writer.Write(temp.FrameModel);
            //�V���V�[No
            writer.Write(temp.ChassisNo);
            //�ԗ��ŗL�ԍ�
            writer.Write(temp.CarProperNo);
            //���Y�N���iNUM�^�C�v�j
            writer.Write(temp.ProduceTypeOfYearNum);
            //�R�����g
            writer.Write(temp.Comment);
            //���y�A�J���[�R�[�h
            writer.Write(temp.RpColorCode);
            //�J���[����1
            writer.Write(temp.ColorName1);
            //�g�����R�[�h
            writer.Write(temp.TrimCode);
            //�g��������
            writer.Write(temp.TrimName);
            //�ԗ����s����
            writer.Write(temp.Mileage);
            //�����I�u�W�F�N�g
            writer.Write(temp.EquipObj.Length);
            writer.Write(temp.EquipObj);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
    		//����
    		writer.Write( temp.CarNo );
    		//���[�J�[����
    		writer.Write( temp.MakerName );
    		//�O���[�h����
    		writer.Write( temp.GradeName );
    		//�{�f�B�[����
    		writer.Write( temp.BodyName );
    		//�h�A��
    		writer.Write( temp.DoorCount );
    		//�G���W���^������
    		writer.Write( temp.EngineModelNm );
    		//�ʏ̔r�C��
    		writer.Write( temp.CmnNmEngineDisPlace );
    		//�����@�^���i�G���W���j
    		writer.Write( temp.EngineModel );
    		//�ϑ��i��
    		writer.Write( temp.NumberOfGear );
    		//�ϑ��@����
    		writer.Write( temp.GearNm );
    		//E�敪����
    		writer.Write( temp.EDivNm );
    		//�~�b�V��������
    		writer.Write( temp.TransmissionNm );
    		//�V�t�g����
    		writer.Write( temp.ShiftNm );
            // ADD 2012/05/31 ----------------------------------------------------->>>>>
            //���N�x�iNUM�^�C�v�j
            writer.Write(temp.FirstEntryDateNumTyp);
            //�ԗ��t�����I�u�W�F�N�g
            writer.Write(temp.CarAddInf.Length);
            writer.Write(temp.CarAddInf);
            //�������i�I�u�W�F�N�g
            writer.Write(temp.EquipPrtsObj.Length);
            writer.Write(temp.EquipPrtsObj);
            // ADD 2012/05/31 -----------------------------------------------------<<<<<
            // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
            //�ԗ��Ǘ��R�[�h
            writer.Write(temp.CarMngCode);
            // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            //���ɗ\���
            writer.Write(temp.ExpectedCeDate);
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        }

        /// <summary>
        ///  SCMAcOdrDtCarWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMAcOdrDtCarWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCarWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMAcOdrDtCarWork GetSCMAcOdrDtCarWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMAcOdrDtCarWork temp = new SCMAcOdrDtCarWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //���^�������ԍ�
            temp.NumberPlate1Code = reader.ReadInt32();
            //���^�����ǖ���
            temp.NumberPlate1Name = reader.ReadString();
            //�ԗ��o�^�ԍ��i��ʁj
            temp.NumberPlate2 = reader.ReadString();
            //�ԗ��o�^�ԍ��i�J�i�j
            temp.NumberPlate3 = reader.ReadString();
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            temp.NumberPlate4 = reader.ReadInt32();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�Ԏ햼
            temp.ModelName = reader.ReadString();
            //�Ԍ��،^��
            temp.CarInspectCertModel = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�ԑ�ԍ�
            temp.FrameNo = reader.ReadString();
            //�ԑ�^��
            temp.FrameModel = reader.ReadString();
            //�V���V�[No
            temp.ChassisNo = reader.ReadString();
            //�ԗ��ŗL�ԍ�
            temp.CarProperNo = reader.ReadInt32();
            //���Y�N���iNUM�^�C�v�j
            temp.ProduceTypeOfYearNum = reader.ReadInt32();
            //�R�����g
            temp.Comment = reader.ReadString();
            //���y�A�J���[�R�[�h
            temp.RpColorCode = reader.ReadString();
            //�J���[����1
            temp.ColorName1 = reader.ReadString();
            //�g�����R�[�h
            temp.TrimCode = reader.ReadString();
            //�g��������
            temp.TrimName = reader.ReadString();
            //�ԗ����s����
            temp.Mileage = reader.ReadInt32();
            //�����I�u�W�F�N�g
            int equipObjLength = reader.ReadInt32();
            temp.EquipObj = reader.ReadBytes(equipObjLength);
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
			//����
    		temp.CarNo = reader.ReadString();
    		//���[�J�[����
    		temp.MakerName = reader.ReadString();
    		//�O���[�h����
    		temp.GradeName = reader.ReadString();
    		//�{�f�B�[����
    		temp.BodyName = reader.ReadString();
    		//�h�A��
    		temp.DoorCount = reader.ReadInt32();
    		//�G���W���^������
    		temp.EngineModelNm = reader.ReadString();
    		//�ʏ̔r�C��
    		temp.CmnNmEngineDisPlace = reader.ReadInt32();
    		//�����@�^���i�G���W���j
    		temp.EngineModel = reader.ReadString();
    		//�ϑ��i��
    		temp.NumberOfGear = reader.ReadInt32();
    		//�ϑ��@����
    		temp.GearNm = reader.ReadString();
    		//E�敪����
    		temp.EDivNm = reader.ReadString();
    		//�~�b�V��������
    		temp.TransmissionNm = reader.ReadString();
    		//�V�t�g����
    		temp.ShiftNm = reader.ReadString();
            // ADD 2012/05/31 ----------------------------------------------------->>>>>
            //���N�x�iNUM�^�C�v�j
            temp.FirstEntryDateNumTyp = reader.ReadInt32();
            //�ԗ��t�����I�u�W�F�N�g
            int carAddInfLength = reader.ReadInt32();
            temp.CarAddInf = reader.ReadBytes(carAddInfLength);
            //�������i�I�u�W�F�N�g
            int equipPrtsObjLength = reader.ReadInt32();
            temp.EquipPrtsObj = reader.ReadBytes(equipPrtsObjLength);
            // ADD 2012/05/31 -----------------------------------------------------<<<<<

            // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
            //�ԗ��Ǘ��R�[�h
            temp.CarMngCode = reader.ReadString();
            // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<

            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            //���ɗ\���
            temp.ExpectedCeDate = reader.ReadInt32();
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SCMAcOdrDtCarWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtCarWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAcOdrDtCarWork temp = GetSCMAcOdrDtCarWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMAcOdrDtCarWork[])lst.ToArray(typeof(SCMAcOdrDtCarWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
