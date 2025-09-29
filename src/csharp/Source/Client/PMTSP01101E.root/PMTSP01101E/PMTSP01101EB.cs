using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Xml.Serialization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   TspSdRvDt
	/// <summary>
	///                      TSP����M�f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   TSP����M�f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2020/12/01</br>
	/// <br>Genarated Date   :   2020/12/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    [XmlInclude(typeof(TspSdRvDt))]
    public class TspSdRvDt
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

		/// <summary>PM��ƃR�[�h</summary>
		/// <remarks>���i���̊�ƃR�[�h</remarks>
		private string _pmEnterpriseCode = "";

		/// <summary>TSP�ʐM�ԍ�</summary>
		/// <remarks>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</remarks>
		private Int32 _tspCommNo;

		/// <summary>TSP�ʐM��</summary>
		/// <remarks>PM�����P�����ɑ΂��ĉ񓚂��s����</remarks>
		private Int32 _tspCommCount;

		/// <summary>�������e�敪</summary>
		/// <remarks>1:�ʏ픭��,2:���i�₢���킹,3:�݌ɖ₢���킹</remarks>
		private Int32 _orderContentsDivCd;

		/// <summary>�w�����ԍ��i������j</summary>
		/// <remarks>�����^</remarks>
		private string _instSlipNoStr = "";

		/// <summary>�󒍔ԍ�</summary>
		/// <remarks>������(SF�EBK)�̎󒍔ԍ�</remarks>
		private Int32 _acceptAnOrderNo;

		/// <summary>�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ́@�������̃f�[�^���̓V�X�e��</remarks>
		private Int32 _dataInputSystem;

		/// <summary>�`�[�ԍ�</summary>
		private string _slipNo = "";

		/// <summary>�`�[���</summary>
		/// <remarks>10:����,20:�w��,21:���菑,30:�[�i,40:���C</remarks>
		private Int32 _slipKind;

		/// <summary>�ʐM��ԋ敪</summary>
		/// <remarks>0:������,1:���M�ς�,2:������,9:�G���[</remarks>
		private Int32 _commConditionDivCd;

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
		/// <remarks>�Ԗ�����(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
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

		/// <summary>������</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _salesOrderDate;

		/// <summary>�����ҏ]�ƈ��R�[�h</summary>
		/// <remarks>���������]�ƈ��R�[�h</remarks>
		private string _salesOrderEmployeeCd = "";

		/// <summary>�����ҏ]�ƈ�����</summary>
		/// <remarks>���������]�ƈ�����</remarks>
		private string _salesOrderEmployeeNm = "";

		/// <summary>�������R�����g</summary>
		/// <remarks>��������ۂɓ��͂���R�����g</remarks>
		private string _salesOrderComment = "";

		/// <summary>�������V�X�e���o�[�W�����敪</summary>
		/// <remarks>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</remarks>
		private Int32 _orderSideSystemVerCd;

		/// <summary>TSP�񓚃f�[�^�Ǘ��ԍ�</summary>
		/// <remarks>�������A�ԍ��̔�</remarks>
		private Int32 _tspAnswerDataMngNo;

		/// <summary>TSP�`�[�^�C�v</summary>
		/// <remarks>0:�I�����C��������,1:�d�b������</remarks>
		private Int32 _tspSlipType;

		/// <summary>�󒍓�</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _acceptAnOrderDate;

		/// <summary>PM�`�[�ԍ�</summary>
		private Int32 _pmSlipNo;

		/// <summary>�󒍎Җ�</summary>
		/// <remarks>�󒍂����]�ƈ�����</remarks>
		private string _acceptAnOrderNm = "";

		/// <summary>TSP�`�[���v���z</summary>
		private Int64 _tspTotalSlipPrice;

		/// <summary>PM�R�����g</summary>
		private string _pmComment = "";

		/// <summary>PM�o�[�W����</summary>
		private string _pmVersion = "";

		/// <summary>PM���M��</summary>
		/// <remarks>PM�������M�������t YYYYMMDD</remarks>
		private DateTime _pmSendDate;

		/// <summary>PM�`�[���</summary>
		/// <remarks>10:����A20:�ԕi</remarks>
		private Int32 _pmSlipKind;

		/// <summary>PM�����`�[�ԍ�</summary>
		/// <remarks>�ԓ`�E�ԕi�̏ꍇ�Ɍ��̍��`�[�ԍ���ݒ�</remarks>
		private Int32 _pmOriginalSlipNo;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>�f�[�^���̓V�X�e������</summary>
		/// <remarks>����,����,���,�Ԕ�</remarks>
		private string _dataInputSystemName = "";


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

		/// public propaty name  :  PmEnterpriseCode
		/// <summary>PM��ƃR�[�h�v���p�e�B</summary>
		/// <value>���i���̊�ƃR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmEnterpriseCode
		{
			get{return _pmEnterpriseCode;}
			set{_pmEnterpriseCode = value;}
		}

		/// public propaty name  :  TspCommNo
		/// <summary>TSP�ʐM�ԍ��v���p�e�B</summary>
		/// <value>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP�ʐM�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TspCommNo
		{
			get{return _tspCommNo;}
			set{_tspCommNo = value;}
		}

		/// public propaty name  :  TspCommCount
		/// <summary>TSP�ʐM�񐔃v���p�e�B</summary>
		/// <value>PM�����P�����ɑ΂��ĉ񓚂��s����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP�ʐM�񐔃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TspCommCount
		{
			get{return _tspCommCount;}
			set{_tspCommCount = value;}
		}

		/// public propaty name  :  OrderContentsDivCd
		/// <summary>�������e�敪�v���p�e�B</summary>
		/// <value>1:�ʏ픭��,2:���i�₢���킹,3:�݌ɖ₢���킹</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������e�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderContentsDivCd
		{
			get{return _orderContentsDivCd;}
			set{_orderContentsDivCd = value;}
		}

		/// public propaty name  :  InstSlipNoStr
		/// <summary>�w�����ԍ��i������j�v���p�e�B</summary>
		/// <value>�����^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �w�����ԍ��i������j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InstSlipNoStr
		{
			get{return _instSlipNoStr;}
			set{_instSlipNoStr = value;}
		}

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>�󒍔ԍ��v���p�e�B</summary>
		/// <value>������(SF�EBK)�̎󒍔ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcceptAnOrderNo
		{
			get{return _acceptAnOrderNo;}
			set{_acceptAnOrderNo = value;}
		}

		/// public propaty name  :  DataInputSystem
		/// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
		/// <value>0:����,1:����,2:���,3:�Ԕ́@�������̃f�[�^���̓V�X�e��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get{return _dataInputSystem;}
			set{_dataInputSystem = value;}
		}

		/// public propaty name  :  SlipNo
		/// <summary>�`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipNo
		{
			get{return _slipNo;}
			set{_slipNo = value;}
		}

		/// public propaty name  :  SlipKind
		/// <summary>�`�[��ʃv���p�e�B</summary>
		/// <value>10:����,20:�w��,21:���菑,30:�[�i,40:���C</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipKind
		{
			get{return _slipKind;}
			set{_slipKind = value;}
		}

		/// public propaty name  :  CommConditionDivCd
		/// <summary>�ʐM��ԋ敪�v���p�e�B</summary>
		/// <value>0:������,1:���M�ς�,2:������,9:�G���[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʐM��ԋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CommConditionDivCd
		{
			get{return _commConditionDivCd;}
			set{_commConditionDivCd = value;}
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
		/// <value>�Ԗ�����(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
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

		/// public propaty name  :  SalesOrderDate
		/// <summary>�������v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime SalesOrderDate
		{
			get{return _salesOrderDate;}
			set{_salesOrderDate = value;}
		}

		/// public propaty name  :  SalesOrderEmployeeCd
		/// <summary>�����ҏ]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���������]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ҏ]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesOrderEmployeeCd
		{
			get{return _salesOrderEmployeeCd;}
			set{_salesOrderEmployeeCd = value;}
		}

		/// public propaty name  :  SalesOrderEmployeeNm
		/// <summary>�����ҏ]�ƈ����̃v���p�e�B</summary>
		/// <value>���������]�ƈ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ҏ]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesOrderEmployeeNm
		{
			get{return _salesOrderEmployeeNm;}
			set{_salesOrderEmployeeNm = value;}
		}

		/// public propaty name  :  SalesOrderComment
		/// <summary>�������R�����g�v���p�e�B</summary>
		/// <value>��������ۂɓ��͂���R�����g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������R�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesOrderComment
		{
			get{return _salesOrderComment;}
			set{_salesOrderComment = value;}
		}

		/// public propaty name  :  OrderSideSystemVerCd
		/// <summary>�������V�X�e���o�[�W�����敪�v���p�e�B</summary>
		/// <value>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������V�X�e���o�[�W�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderSideSystemVerCd
		{
			get{return _orderSideSystemVerCd;}
			set{_orderSideSystemVerCd = value;}
		}

		/// public propaty name  :  TspAnswerDataMngNo
		/// <summary>TSP�񓚃f�[�^�Ǘ��ԍ��v���p�e�B</summary>
		/// <value>�������A�ԍ��̔�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP�񓚃f�[�^�Ǘ��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TspAnswerDataMngNo
		{
			get{return _tspAnswerDataMngNo;}
			set{_tspAnswerDataMngNo = value;}
		}

		/// public propaty name  :  TspSlipType
		/// <summary>TSP�`�[�^�C�v�v���p�e�B</summary>
		/// <value>0:�I�����C��������,1:�d�b������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP�`�[�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TspSlipType
		{
			get{return _tspSlipType;}
			set{_tspSlipType = value;}
		}

		/// public propaty name  :  AcceptAnOrderDate
		/// <summary>�󒍓��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍓��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AcceptAnOrderDate
		{
			get{return _acceptAnOrderDate;}
			set{_acceptAnOrderDate = value;}
		}

		/// public propaty name  :  PmSlipNo
		/// <summary>PM�`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PmSlipNo
		{
			get{return _pmSlipNo;}
			set{_pmSlipNo = value;}
		}

		/// public propaty name  :  AcceptAnOrderNm
		/// <summary>�󒍎Җ��v���p�e�B</summary>
		/// <value>�󒍂����]�ƈ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍎Җ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AcceptAnOrderNm
		{
			get{return _acceptAnOrderNm;}
			set{_acceptAnOrderNm = value;}
		}

		/// public propaty name  :  TspTotalSlipPrice
		/// <summary>TSP�`�[���v���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP�`�[���v���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 TspTotalSlipPrice
		{
			get{return _tspTotalSlipPrice;}
			set{_tspTotalSlipPrice = value;}
		}

		/// public propaty name  :  PmComment
		/// <summary>PM�R�����g�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�R�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmComment
		{
			get{return _pmComment;}
			set{_pmComment = value;}
		}

		/// public propaty name  :  PmVersion
		/// <summary>PM�o�[�W�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�o�[�W�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmVersion
		{
			get{return _pmVersion;}
			set{_pmVersion = value;}
		}

		/// public propaty name  :  PmSendDate
		/// <summary>PM���M���v���p�e�B</summary>
		/// <value>PM�������M�������t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM���M���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PmSendDate
		{
			get{return _pmSendDate;}
			set{_pmSendDate = value;}
		}

		/// public propaty name  :  PmSlipKind
		/// <summary>PM�`�[��ʃv���p�e�B</summary>
		/// <value>10:����A20:�ԕi</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�`�[��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PmSlipKind
		{
			get{return _pmSlipKind;}
			set{_pmSlipKind = value;}
		}
        
		/// public propaty name  :  PmOriginalSlipNo
		/// <summary>PM�����`�[�ԍ��v���p�e�B</summary>
		/// <value>�ԓ`�E�ԕi�̏ꍇ�Ɍ��̍��`�[�ԍ���ݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PmOriginalSlipNo
		{
			get{return _pmOriginalSlipNo;}
			set{_pmOriginalSlipNo = value;}
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

		/// public propaty name  :  DataInputSystemName
		/// <summary>�f�[�^���̓V�X�e�����̃v���p�e�B</summary>
		/// <value>����,����,���,�Ԕ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^���̓V�X�e�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DataInputSystemName
		{
			get{return _dataInputSystemName;}
			set{_dataInputSystemName = value;}
		}

		/// <summary>
		/// TSP����M�f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>TspSdRvDt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TspSdRvDt()
		{

		}

		/// <summary>
		/// TSP����M�f�[�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="pmEnterpriseCode">PM��ƃR�[�h(���i���̊�ƃR�[�h)</param>
		/// <param name="tspCommNo">TSP�ʐM�ԍ�(�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�))</param>
		/// <param name="tspCommCount">TSP�ʐM��(PM�����P�����ɑ΂��ĉ񓚂��s����)</param>
		/// <param name="orderContentsDivCd">�������e�敪(1:�ʏ픭��,2:���i�₢���킹,3:�݌ɖ₢���킹)</param>
		/// <param name="instSlipNoStr">�w�����ԍ��i������j(�����^)</param>
		/// <param name="acceptAnOrderNo">�󒍔ԍ�(������(SF�EBK)�̎󒍔ԍ�)</param>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��(0:����,1:����,2:���,3:�Ԕ́@�������̃f�[�^���̓V�X�e��)</param>
		/// <param name="slipNo">�`�[�ԍ�</param>
		/// <param name="slipKind">�`�[���(10:����,20:�w��,21:���菑,30:�[�i,40:���C)</param>
		/// <param name="commConditionDivCd">�ʐM��ԋ敪(0:������,1:���M�ς�,2:������,9:�G���[)</param>
		/// <param name="numberPlate1Code">���^�������ԍ�</param>
		/// <param name="numberPlate1Name">���^�����ǖ���</param>
		/// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
		/// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
		/// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
		/// <param name="modelDesignationNo">�^���w��ԍ�</param>
		/// <param name="categoryNo">�ޕʔԍ�</param>
		/// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
		/// <param name="modelCode">�Ԏ�R�[�h(�Ԗ�����(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
		/// <param name="modelSubCode">�Ԏ�T�u�R�[�h(0�`899:�񋟕�,900�`հ�ް�o�^)</param>
		/// <param name="modelName">�Ԏ햼</param>
		/// <param name="carInspectCertModel">�Ԍ��،^��</param>
		/// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
		/// <param name="frameNo">�ԑ�ԍ�</param>
		/// <param name="frameModel">�ԑ�^��</param>
		/// <param name="chassisNo">�V���V�[No</param>
		/// <param name="carProperNo">�ԗ��ŗL�ԍ�(���j�[�N�ȌŒ�ԍ�)</param>
		/// <param name="produceTypeOfYearNum">���Y�N���iNUM�^�C�v�j(YYYYMM)</param>
		/// <param name="salesOrderDate">������(YYYYMMDD)</param>
		/// <param name="salesOrderEmployeeCd">�����ҏ]�ƈ��R�[�h(���������]�ƈ��R�[�h)</param>
		/// <param name="salesOrderEmployeeNm">�����ҏ]�ƈ�����(���������]�ƈ�����)</param>
		/// <param name="salesOrderComment">�������R�����g(��������ۂɓ��͂���R�����g)</param>
		/// <param name="orderSideSystemVerCd">�������V�X�e���o�[�W�����敪(0:SF.NS or BK.NS,1:Pegasus,2:Phoenix)</param>
		/// <param name="tspAnswerDataMngNo">TSP�񓚃f�[�^�Ǘ��ԍ�(�������A�ԍ��̔�)</param>
		/// <param name="tspSlipType">TSP�`�[�^�C�v(0:�I�����C��������,1:�d�b������)</param>
		/// <param name="acceptAnOrderDate">�󒍓�(YYYYMMDD)</param>
		/// <param name="pmSlipNo">PM�`�[�ԍ�</param>
		/// <param name="acceptAnOrderNm">�󒍎Җ�(�󒍂����]�ƈ�����)</param>
		/// <param name="tspTotalSlipPrice">TSP�`�[���v���z</param>
		/// <param name="pmComment">PM�R�����g</param>
		/// <param name="pmVersion">PM�o�[�W����</param>
		/// <param name="pmSendDate">PM���M��(PM�������M�������t YYYYMMDD)</param>
		/// <param name="pmSlipKind">PM�`�[���(10:����A20:�ԕi)</param>
		/// <param name="pmOriginalSlipNo">PM�����`�[�ԍ�(�ԓ`�E�ԕi�̏ꍇ�Ɍ��̍��`�[�ԍ���ݒ�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="dataInputSystemName">�f�[�^���̓V�X�e������(����,����,���,�Ԕ�)</param>
		/// <returns>TspSdRvDt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TspSdRvDt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string pmEnterpriseCode,Int32 tspCommNo,Int32 tspCommCount,Int32 orderContentsDivCd,string instSlipNoStr,Int32 acceptAnOrderNo,Int32 dataInputSystem,string slipNo,Int32 slipKind,Int32 commConditionDivCd,Int32 numberPlate1Code,string numberPlate1Name,string numberPlate2,string numberPlate3,Int32 numberPlate4,Int32 modelDesignationNo,Int32 categoryNo,Int32 makerCode,Int32 modelCode,Int32 modelSubCode,string modelName,string carInspectCertModel,string fullModel,string frameNo,string frameModel,string chassisNo,Int32 carProperNo,Int32 produceTypeOfYearNum,DateTime salesOrderDate,string salesOrderEmployeeCd,string salesOrderEmployeeNm,string salesOrderComment,Int32 orderSideSystemVerCd,Int32 tspAnswerDataMngNo,Int32 tspSlipType,DateTime acceptAnOrderDate,Int32 pmSlipNo,string acceptAnOrderNm,Int64 tspTotalSlipPrice,string pmComment,string pmVersion,DateTime pmSendDate,Int32 pmSlipKind,Int32 pmOriginalSlipNo,string enterpriseName,string updEmployeeName,string dataInputSystemName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._pmEnterpriseCode = pmEnterpriseCode;
			this._tspCommNo = tspCommNo;
			this._tspCommCount = tspCommCount;
			this._orderContentsDivCd = orderContentsDivCd;
			this._instSlipNoStr = instSlipNoStr;
			this._acceptAnOrderNo = acceptAnOrderNo;
			this._dataInputSystem = dataInputSystem;
			this._slipNo = slipNo;
			this._slipKind = slipKind;
			this._commConditionDivCd = commConditionDivCd;
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
			this.SalesOrderDate = salesOrderDate;
			this._salesOrderEmployeeCd = salesOrderEmployeeCd;
			this._salesOrderEmployeeNm = salesOrderEmployeeNm;
			this._salesOrderComment = salesOrderComment;
			this._orderSideSystemVerCd = orderSideSystemVerCd;
			this._tspAnswerDataMngNo = tspAnswerDataMngNo;
			this._tspSlipType = tspSlipType;
			this.AcceptAnOrderDate = acceptAnOrderDate;
			this._pmSlipNo = pmSlipNo;
			this._acceptAnOrderNm = acceptAnOrderNm;
			this._tspTotalSlipPrice = tspTotalSlipPrice;
			this._pmComment = pmComment;
			this._pmVersion = pmVersion;
			this.PmSendDate = pmSendDate;
			this._pmSlipKind = pmSlipKind;
			this._pmOriginalSlipNo = pmOriginalSlipNo;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._dataInputSystemName = dataInputSystemName;

            return;

		}

		/// <summary>
		/// TSP����M�f�[�^��������
		/// </summary>
		/// <returns>TspSdRvDt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TspSdRvDt�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TspSdRvDt Clone()
		{
			return new TspSdRvDt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._pmEnterpriseCode,this._tspCommNo,this._tspCommCount,this._orderContentsDivCd,this._instSlipNoStr,this._acceptAnOrderNo,this._dataInputSystem,this._slipNo,this._slipKind,this._commConditionDivCd,this._numberPlate1Code,this._numberPlate1Name,this._numberPlate2,this._numberPlate3,this._numberPlate4,this._modelDesignationNo,this._categoryNo,this._makerCode,this._modelCode,this._modelSubCode,this._modelName,this._carInspectCertModel,this._fullModel,this._frameNo,this._frameModel,this._chassisNo,this._carProperNo,this._produceTypeOfYearNum,this._salesOrderDate,this._salesOrderEmployeeCd,this._salesOrderEmployeeNm,this._salesOrderComment,this._orderSideSystemVerCd,this._tspAnswerDataMngNo,this._tspSlipType,this._acceptAnOrderDate,this._pmSlipNo,this._acceptAnOrderNm,this._tspTotalSlipPrice,this._pmComment,this._pmVersion,this._pmSendDate,this._pmSlipKind,this._pmOriginalSlipNo,this._enterpriseName,this._updEmployeeName,this._dataInputSystemName);
		}

		/// <summary>
		/// TSP����M�f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�TspSdRvDt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(TspSdRvDt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.PmEnterpriseCode == target.PmEnterpriseCode)
				 && (this.TspCommNo == target.TspCommNo)
				 && (this.TspCommCount == target.TspCommCount)
				 && (this.OrderContentsDivCd == target.OrderContentsDivCd)
				 && (this.InstSlipNoStr == target.InstSlipNoStr)
				 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
				 && (this.DataInputSystem == target.DataInputSystem)
				 && (this.SlipNo == target.SlipNo)
				 && (this.SlipKind == target.SlipKind)
				 && (this.CommConditionDivCd == target.CommConditionDivCd)
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
				 && (this.SalesOrderDate == target.SalesOrderDate)
				 && (this.SalesOrderEmployeeCd == target.SalesOrderEmployeeCd)
				 && (this.SalesOrderEmployeeNm == target.SalesOrderEmployeeNm)
				 && (this.SalesOrderComment == target.SalesOrderComment)
				 && (this.OrderSideSystemVerCd == target.OrderSideSystemVerCd)
				 && (this.TspAnswerDataMngNo == target.TspAnswerDataMngNo)
				 && (this.TspSlipType == target.TspSlipType)
				 && (this.AcceptAnOrderDate == target.AcceptAnOrderDate)
				 && (this.PmSlipNo == target.PmSlipNo)
				 && (this.AcceptAnOrderNm == target.AcceptAnOrderNm)
				 && (this.TspTotalSlipPrice == target.TspTotalSlipPrice)
				 && (this.PmComment == target.PmComment)
				 && (this.PmVersion == target.PmVersion)
				 && (this.PmSendDate == target.PmSendDate)
				 && (this.PmSlipKind == target.PmSlipKind)
				 && (this.PmOriginalSlipNo == target.PmOriginalSlipNo)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.DataInputSystemName == target.DataInputSystemName));
		}

		/// <summary>
		/// TSP����M�f�[�^��r����
		/// </summary>
		/// <param name="tspSdRvDt1">
		///                    ��r����TspSdRvDt�N���X�̃C���X�^���X
		/// </param>
		/// <param name="tspSdRvDt2">��r����TspSdRvDt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(TspSdRvDt tspSdRvDt1, TspSdRvDt tspSdRvDt2)
		{
			return ((tspSdRvDt1.CreateDateTime == tspSdRvDt2.CreateDateTime)
				 && (tspSdRvDt1.UpdateDateTime == tspSdRvDt2.UpdateDateTime)
				 && (tspSdRvDt1.EnterpriseCode == tspSdRvDt2.EnterpriseCode)
				 && (tspSdRvDt1.FileHeaderGuid == tspSdRvDt2.FileHeaderGuid)
				 && (tspSdRvDt1.UpdEmployeeCode == tspSdRvDt2.UpdEmployeeCode)
				 && (tspSdRvDt1.UpdAssemblyId1 == tspSdRvDt2.UpdAssemblyId1)
				 && (tspSdRvDt1.UpdAssemblyId2 == tspSdRvDt2.UpdAssemblyId2)
				 && (tspSdRvDt1.LogicalDeleteCode == tspSdRvDt2.LogicalDeleteCode)
				 && (tspSdRvDt1.PmEnterpriseCode == tspSdRvDt2.PmEnterpriseCode)
				 && (tspSdRvDt1.TspCommNo == tspSdRvDt2.TspCommNo)
				 && (tspSdRvDt1.TspCommCount == tspSdRvDt2.TspCommCount)
				 && (tspSdRvDt1.OrderContentsDivCd == tspSdRvDt2.OrderContentsDivCd)
				 && (tspSdRvDt1.InstSlipNoStr == tspSdRvDt2.InstSlipNoStr)
				 && (tspSdRvDt1.AcceptAnOrderNo == tspSdRvDt2.AcceptAnOrderNo)
				 && (tspSdRvDt1.DataInputSystem == tspSdRvDt2.DataInputSystem)
				 && (tspSdRvDt1.SlipNo == tspSdRvDt2.SlipNo)
				 && (tspSdRvDt1.SlipKind == tspSdRvDt2.SlipKind)
				 && (tspSdRvDt1.CommConditionDivCd == tspSdRvDt2.CommConditionDivCd)
				 && (tspSdRvDt1.NumberPlate1Code == tspSdRvDt2.NumberPlate1Code)
				 && (tspSdRvDt1.NumberPlate1Name == tspSdRvDt2.NumberPlate1Name)
				 && (tspSdRvDt1.NumberPlate2 == tspSdRvDt2.NumberPlate2)
				 && (tspSdRvDt1.NumberPlate3 == tspSdRvDt2.NumberPlate3)
				 && (tspSdRvDt1.NumberPlate4 == tspSdRvDt2.NumberPlate4)
				 && (tspSdRvDt1.ModelDesignationNo == tspSdRvDt2.ModelDesignationNo)
				 && (tspSdRvDt1.CategoryNo == tspSdRvDt2.CategoryNo)
				 && (tspSdRvDt1.MakerCode == tspSdRvDt2.MakerCode)
				 && (tspSdRvDt1.ModelCode == tspSdRvDt2.ModelCode)
				 && (tspSdRvDt1.ModelSubCode == tspSdRvDt2.ModelSubCode)
				 && (tspSdRvDt1.ModelName == tspSdRvDt2.ModelName)
				 && (tspSdRvDt1.CarInspectCertModel == tspSdRvDt2.CarInspectCertModel)
				 && (tspSdRvDt1.FullModel == tspSdRvDt2.FullModel)
				 && (tspSdRvDt1.FrameNo == tspSdRvDt2.FrameNo)
				 && (tspSdRvDt1.FrameModel == tspSdRvDt2.FrameModel)
				 && (tspSdRvDt1.ChassisNo == tspSdRvDt2.ChassisNo)
				 && (tspSdRvDt1.CarProperNo == tspSdRvDt2.CarProperNo)
				 && (tspSdRvDt1.ProduceTypeOfYearNum == tspSdRvDt2.ProduceTypeOfYearNum)
				 && (tspSdRvDt1.SalesOrderDate == tspSdRvDt2.SalesOrderDate)
				 && (tspSdRvDt1.SalesOrderEmployeeCd == tspSdRvDt2.SalesOrderEmployeeCd)
				 && (tspSdRvDt1.SalesOrderEmployeeNm == tspSdRvDt2.SalesOrderEmployeeNm)
				 && (tspSdRvDt1.SalesOrderComment == tspSdRvDt2.SalesOrderComment)
				 && (tspSdRvDt1.OrderSideSystemVerCd == tspSdRvDt2.OrderSideSystemVerCd)
				 && (tspSdRvDt1.TspAnswerDataMngNo == tspSdRvDt2.TspAnswerDataMngNo)
				 && (tspSdRvDt1.TspSlipType == tspSdRvDt2.TspSlipType)
				 && (tspSdRvDt1.AcceptAnOrderDate == tspSdRvDt2.AcceptAnOrderDate)
				 && (tspSdRvDt1.PmSlipNo == tspSdRvDt2.PmSlipNo)
				 && (tspSdRvDt1.AcceptAnOrderNm == tspSdRvDt2.AcceptAnOrderNm)
				 && (tspSdRvDt1.TspTotalSlipPrice == tspSdRvDt2.TspTotalSlipPrice)
				 && (tspSdRvDt1.PmComment == tspSdRvDt2.PmComment)
				 && (tspSdRvDt1.PmVersion == tspSdRvDt2.PmVersion)
				 && (tspSdRvDt1.PmSendDate == tspSdRvDt2.PmSendDate)
				 && (tspSdRvDt1.PmSlipKind == tspSdRvDt2.PmSlipKind)
				 && (tspSdRvDt1.PmOriginalSlipNo == tspSdRvDt2.PmOriginalSlipNo)
				 && (tspSdRvDt1.EnterpriseName == tspSdRvDt2.EnterpriseName)
				 && (tspSdRvDt1.UpdEmployeeName == tspSdRvDt2.UpdEmployeeName)
				 && (tspSdRvDt1.DataInputSystemName == tspSdRvDt2.DataInputSystemName));
		}
		/// <summary>
		/// TSP����M�f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�TspSdRvDt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(TspSdRvDt target)
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
			if(this.PmEnterpriseCode != target.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(this.TspCommNo != target.TspCommNo)resList.Add("TspCommNo");
			if(this.TspCommCount != target.TspCommCount)resList.Add("TspCommCount");
			if(this.OrderContentsDivCd != target.OrderContentsDivCd)resList.Add("OrderContentsDivCd");
			if(this.InstSlipNoStr != target.InstSlipNoStr)resList.Add("InstSlipNoStr");
			if(this.AcceptAnOrderNo != target.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(this.DataInputSystem != target.DataInputSystem)resList.Add("DataInputSystem");
			if(this.SlipNo != target.SlipNo)resList.Add("SlipNo");
			if(this.SlipKind != target.SlipKind)resList.Add("SlipKind");
			if(this.CommConditionDivCd != target.CommConditionDivCd)resList.Add("CommConditionDivCd");
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
			if(this.SalesOrderDate != target.SalesOrderDate)resList.Add("SalesOrderDate");
			if(this.SalesOrderEmployeeCd != target.SalesOrderEmployeeCd)resList.Add("SalesOrderEmployeeCd");
			if(this.SalesOrderEmployeeNm != target.SalesOrderEmployeeNm)resList.Add("SalesOrderEmployeeNm");
			if(this.SalesOrderComment != target.SalesOrderComment)resList.Add("SalesOrderComment");
			if(this.OrderSideSystemVerCd != target.OrderSideSystemVerCd)resList.Add("OrderSideSystemVerCd");
			if(this.TspAnswerDataMngNo != target.TspAnswerDataMngNo)resList.Add("TspAnswerDataMngNo");
			if(this.TspSlipType != target.TspSlipType)resList.Add("TspSlipType");
			if(this.AcceptAnOrderDate != target.AcceptAnOrderDate)resList.Add("AcceptAnOrderDate");
			if(this.PmSlipNo != target.PmSlipNo)resList.Add("PmSlipNo");
			if(this.AcceptAnOrderNm != target.AcceptAnOrderNm)resList.Add("AcceptAnOrderNm");
			if(this.TspTotalSlipPrice != target.TspTotalSlipPrice)resList.Add("TspTotalSlipPrice");
			if(this.PmComment != target.PmComment)resList.Add("PmComment");
			if(this.PmVersion != target.PmVersion)resList.Add("PmVersion");
			if(this.PmSendDate != target.PmSendDate)resList.Add("PmSendDate");
			if(this.PmSlipKind != target.PmSlipKind)resList.Add("PmSlipKind");
			if(this.PmOriginalSlipNo != target.PmOriginalSlipNo)resList.Add("PmOriginalSlipNo");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.DataInputSystemName != target.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}

		/// <summary>
		/// TSP����M�f�[�^��r����
		/// </summary>
		/// <param name="tspSdRvDt1">��r����TspSdRvDt�N���X�̃C���X�^���X</param>
		/// <param name="tspSdRvDt2">��r����TspSdRvDt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(TspSdRvDt tspSdRvDt1, TspSdRvDt tspSdRvDt2)
		{
			ArrayList resList = new ArrayList();
			if(tspSdRvDt1.CreateDateTime != tspSdRvDt2.CreateDateTime)resList.Add("CreateDateTime");
			if(tspSdRvDt1.UpdateDateTime != tspSdRvDt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(tspSdRvDt1.EnterpriseCode != tspSdRvDt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(tspSdRvDt1.FileHeaderGuid != tspSdRvDt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(tspSdRvDt1.UpdEmployeeCode != tspSdRvDt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(tspSdRvDt1.UpdAssemblyId1 != tspSdRvDt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(tspSdRvDt1.UpdAssemblyId2 != tspSdRvDt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(tspSdRvDt1.LogicalDeleteCode != tspSdRvDt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(tspSdRvDt1.PmEnterpriseCode != tspSdRvDt2.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(tspSdRvDt1.TspCommNo != tspSdRvDt2.TspCommNo)resList.Add("TspCommNo");
			if(tspSdRvDt1.TspCommCount != tspSdRvDt2.TspCommCount)resList.Add("TspCommCount");
			if(tspSdRvDt1.OrderContentsDivCd != tspSdRvDt2.OrderContentsDivCd)resList.Add("OrderContentsDivCd");
			if(tspSdRvDt1.InstSlipNoStr != tspSdRvDt2.InstSlipNoStr)resList.Add("InstSlipNoStr");
			if(tspSdRvDt1.AcceptAnOrderNo != tspSdRvDt2.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(tspSdRvDt1.DataInputSystem != tspSdRvDt2.DataInputSystem)resList.Add("DataInputSystem");
			if(tspSdRvDt1.SlipNo != tspSdRvDt2.SlipNo)resList.Add("SlipNo");
			if(tspSdRvDt1.SlipKind != tspSdRvDt2.SlipKind)resList.Add("SlipKind");
			if(tspSdRvDt1.CommConditionDivCd != tspSdRvDt2.CommConditionDivCd)resList.Add("CommConditionDivCd");
			if(tspSdRvDt1.NumberPlate1Code != tspSdRvDt2.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(tspSdRvDt1.NumberPlate1Name != tspSdRvDt2.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(tspSdRvDt1.NumberPlate2 != tspSdRvDt2.NumberPlate2)resList.Add("NumberPlate2");
			if(tspSdRvDt1.NumberPlate3 != tspSdRvDt2.NumberPlate3)resList.Add("NumberPlate3");
			if(tspSdRvDt1.NumberPlate4 != tspSdRvDt2.NumberPlate4)resList.Add("NumberPlate4");
			if(tspSdRvDt1.ModelDesignationNo != tspSdRvDt2.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(tspSdRvDt1.CategoryNo != tspSdRvDt2.CategoryNo)resList.Add("CategoryNo");
			if(tspSdRvDt1.MakerCode != tspSdRvDt2.MakerCode)resList.Add("MakerCode");
			if(tspSdRvDt1.ModelCode != tspSdRvDt2.ModelCode)resList.Add("ModelCode");
			if(tspSdRvDt1.ModelSubCode != tspSdRvDt2.ModelSubCode)resList.Add("ModelSubCode");
			if(tspSdRvDt1.ModelName != tspSdRvDt2.ModelName)resList.Add("ModelName");
			if(tspSdRvDt1.CarInspectCertModel != tspSdRvDt2.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(tspSdRvDt1.FullModel != tspSdRvDt2.FullModel)resList.Add("FullModel");
			if(tspSdRvDt1.FrameNo != tspSdRvDt2.FrameNo)resList.Add("FrameNo");
			if(tspSdRvDt1.FrameModel != tspSdRvDt2.FrameModel)resList.Add("FrameModel");
			if(tspSdRvDt1.ChassisNo != tspSdRvDt2.ChassisNo)resList.Add("ChassisNo");
			if(tspSdRvDt1.CarProperNo != tspSdRvDt2.CarProperNo)resList.Add("CarProperNo");
			if(tspSdRvDt1.ProduceTypeOfYearNum != tspSdRvDt2.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(tspSdRvDt1.SalesOrderDate != tspSdRvDt2.SalesOrderDate)resList.Add("SalesOrderDate");
			if(tspSdRvDt1.SalesOrderEmployeeCd != tspSdRvDt2.SalesOrderEmployeeCd)resList.Add("SalesOrderEmployeeCd");
			if(tspSdRvDt1.SalesOrderEmployeeNm != tspSdRvDt2.SalesOrderEmployeeNm)resList.Add("SalesOrderEmployeeNm");
			if(tspSdRvDt1.SalesOrderComment != tspSdRvDt2.SalesOrderComment)resList.Add("SalesOrderComment");
			if(tspSdRvDt1.OrderSideSystemVerCd != tspSdRvDt2.OrderSideSystemVerCd)resList.Add("OrderSideSystemVerCd");
			if(tspSdRvDt1.TspAnswerDataMngNo != tspSdRvDt2.TspAnswerDataMngNo)resList.Add("TspAnswerDataMngNo");
			if(tspSdRvDt1.TspSlipType != tspSdRvDt2.TspSlipType)resList.Add("TspSlipType");
			if(tspSdRvDt1.AcceptAnOrderDate != tspSdRvDt2.AcceptAnOrderDate)resList.Add("AcceptAnOrderDate");
			if(tspSdRvDt1.PmSlipNo != tspSdRvDt2.PmSlipNo)resList.Add("PmSlipNo");
			if(tspSdRvDt1.AcceptAnOrderNm != tspSdRvDt2.AcceptAnOrderNm)resList.Add("AcceptAnOrderNm");
			if(tspSdRvDt1.TspTotalSlipPrice != tspSdRvDt2.TspTotalSlipPrice)resList.Add("TspTotalSlipPrice");
			if(tspSdRvDt1.PmComment != tspSdRvDt2.PmComment)resList.Add("PmComment");
			if(tspSdRvDt1.PmVersion != tspSdRvDt2.PmVersion)resList.Add("PmVersion");
			if(tspSdRvDt1.PmSendDate != tspSdRvDt2.PmSendDate)resList.Add("PmSendDate");
			if(tspSdRvDt1.PmSlipKind != tspSdRvDt2.PmSlipKind)resList.Add("PmSlipKind");
			if(tspSdRvDt1.PmOriginalSlipNo != tspSdRvDt2.PmOriginalSlipNo)resList.Add("PmOriginalSlipNo");
			if(tspSdRvDt1.EnterpriseName != tspSdRvDt2.EnterpriseName)resList.Add("EnterpriseName");
			if(tspSdRvDt1.UpdEmployeeName != tspSdRvDt2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(tspSdRvDt1.DataInputSystemName != tspSdRvDt2.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}
	}
}
