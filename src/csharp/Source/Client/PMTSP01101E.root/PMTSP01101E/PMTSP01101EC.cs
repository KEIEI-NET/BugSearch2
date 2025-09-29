using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   TspSdRvDtl
	/// <summary>
	///                      TSP����M���׃f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   TSP����M���׃f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2020/12/01</br>
	/// <br>Genarated Date   :   2020/12/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class TspSdRvDtl
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

		/// <summary>TSP�ʐM�s�ԍ�</summary>
		private Int32 _tspCommRowNo;

		/// <summary>�[�i�敪</summary>
		/// <remarks>0:�z��,1:����</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>�戵�敪</summary>
		/// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
		private Int32 _handleDivCode;

		/// <summary>���i�`��</summary>
		/// <remarks>1:���i,2:�p�i</remarks>
		private Int32 _partsShape;

		/// <summary>�[�i�m�F�敪</summary>
		/// <remarks>0:���m�F,1:�m�F</remarks>
		private Int32 _delivrdGdsConfCd;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>�[�i�\����t YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>�����i�R�[�h</summary>
		/// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
		private Int32 _tbsPartsCode;

		/// <summary>PM���i���i�J�i�j</summary>
		/// <remarks>PM���̕i��</remarks>
		private string _pmPartsNameKana = "";

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�[�i��</summary>
		private Double _deliveredGoodsCount;

		/// <summary>�n�C�t���t�i��</summary>
		private string _partsNoWithHyphen = "";

		/// <summary>PM���i���[�J�[�R�[�h</summary>
		/// <remarks>PM���̕��i���[�J�[�R�[�h</remarks>
		private Int32 _pmPartsMakerCode;

		/// <summary>�������i���[�J�[�R�[�h</summary>
		private Int32 _purePartsMakerCode;

		/// <summary>�����n�C�t���t�i��</summary>
		/// <remarks>SF�EBK�������́A�`�[���ׂ̃n�C�t���t�i�ԂƂȂ�</remarks>
		private string _purePrtsNoWithHyphen = "";

		/// <summary>�艿</summary>
		private Int64 _listPrice;

		/// <summary>�P��</summary>
		private Int64 _unitPrice;

		/// <summary>PM���׎捞�敪</summary>
		/// <remarks>0:�捞��,1:�捞�s��</remarks>
		private Int32 _pmDtlTakeinDivCd;

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

		/// public propaty name  :  TspCommRowNo
		/// <summary>TSP�ʐM�s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP�ʐM�s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TspCommRowNo
		{
			get{return _tspCommRowNo;}
			set{_tspCommRowNo = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>�[�i�敪�v���p�e�B</summary>
		/// <value>0:�z��,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DeliveredGoodsDiv
		{
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
		}

		/// public propaty name  :  HandleDivCode
		/// <summary>�戵�敪�v���p�e�B</summary>
		/// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �戵�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HandleDivCode
		{
			get{return _handleDivCode;}
			set{_handleDivCode = value;}
		}

		/// public propaty name  :  PartsShape
		/// <summary>���i�`�ԃv���p�e�B</summary>
		/// <value>1:���i,2:�p�i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�`�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsShape
		{
			get{return _partsShape;}
			set{_partsShape = value;}
		}

		/// public propaty name  :  DelivrdGdsConfCd
		/// <summary>�[�i�m�F�敪�v���p�e�B</summary>
		/// <value>0:���m�F,1:�m�F</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DelivrdGdsConfCd
		{
			get{return _delivrdGdsConfCd;}
			set{_delivrdGdsConfCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>�[�i�����\��� �a��v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>�[�i�����\��� �a��(��)�v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>�[�i�����\��� ����v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>�[�i�����\��� ����(��)�v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>�����i�R�[�h�v���p�e�B</summary>
		/// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get{return _tbsPartsCode;}
			set{_tbsPartsCode = value;}
		}

		/// public propaty name  :  PmPartsNameKana
		/// <summary>PM���i���i�J�i�j�v���p�e�B</summary>
		/// <value>PM���̕i��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM���i���i�J�i�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmPartsNameKana
		{
			get{return _pmPartsNameKana;}
			set{_pmPartsNameKana = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  DeliveredGoodsCount
		/// <summary>�[�i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double DeliveredGoodsCount
		{
			get{return _deliveredGoodsCount;}
			set{_deliveredGoodsCount = value;}
		}

		/// public propaty name  :  PartsNoWithHyphen
		/// <summary>�n�C�t���t�i�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n�C�t���t�i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartsNoWithHyphen
		{
			get{return _partsNoWithHyphen;}
			set{_partsNoWithHyphen = value;}
		}

		/// public propaty name  :  PmPartsMakerCode
		/// <summary>PM���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>PM���̕��i���[�J�[�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PmPartsMakerCode
		{
			get{return _pmPartsMakerCode;}
			set{_pmPartsMakerCode = value;}
		}

		/// public propaty name  :  PurePartsMakerCode
		/// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PurePartsMakerCode
		{
			get{return _purePartsMakerCode;}
			set{_purePartsMakerCode = value;}
		}

		/// public propaty name  :  PurePrtsNoWithHyphen
		/// <summary>�����n�C�t���t�i�ԃv���p�e�B</summary>
		/// <value>SF�EBK�������́A�`�[���ׂ̃n�C�t���t�i�ԂƂȂ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����n�C�t���t�i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PurePrtsNoWithHyphen
		{
			get{return _purePrtsNoWithHyphen;}
			set{_purePrtsNoWithHyphen = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>�艿�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>�P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  PmDtlTakeinDivCd
		/// <summary>PM���׎捞�敪�v���p�e�B</summary>
		/// <value>0:�捞��,1:�捞�s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM���׎捞�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PmDtlTakeinDivCd
		{
			get{return _pmDtlTakeinDivCd;}
			set{_pmDtlTakeinDivCd = value;}
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
		/// TSP����M���׃f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>TspSdRvDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TspSdRvDtl()
		{
		}

		/// <summary>
		/// TSP����M���׃f�[�^�R���X�g���N�^
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
		/// <param name="tspCommRowNo">TSP�ʐM�s�ԍ�</param>
		/// <param name="deliveredGoodsDiv">�[�i�敪(0:�z��,1:����)</param>
		/// <param name="handleDivCode">�戵�敪(0:��舵���i,1:�[���m�F��,2:����舵���i)</param>
		/// <param name="partsShape">���i�`��(1:���i,2:�p�i)</param>
		/// <param name="delivrdGdsConfCd">�[�i�m�F�敪(0:���m�F,1:�m�F)</param>
		/// <param name="deliGdsCmpltDueDate">�[�i�����\���(�[�i�\����t YYYYMMDD)</param>
		/// <param name="tbsPartsCode">�����i�R�[�h(1�`99999:�񋟕�,100000�`���[�U�[�o�^�p)</param>
		/// <param name="pmPartsNameKana">PM���i���i�J�i�j(PM���̕i��)</param>
		/// <param name="salesOrderCount">������</param>
		/// <param name="deliveredGoodsCount">�[�i��</param>
		/// <param name="partsNoWithHyphen">�n�C�t���t�i��</param>
		/// <param name="pmPartsMakerCode">PM���i���[�J�[�R�[�h(PM���̕��i���[�J�[�R�[�h)</param>
		/// <param name="purePartsMakerCode">�������i���[�J�[�R�[�h</param>
		/// <param name="purePrtsNoWithHyphen">�����n�C�t���t�i��(SF�EBK�������́A�`�[���ׂ̃n�C�t���t�i�ԂƂȂ�)</param>
		/// <param name="listPrice">�艿</param>
		/// <param name="unitPrice">�P��</param>
		/// <param name="pmDtlTakeinDivCd">PM���׎捞�敪(0:�捞��,1:�捞�s��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>TspSdRvDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TspSdRvDtl(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string pmEnterpriseCode,Int32 tspCommNo,Int32 tspCommCount,Int32 tspCommRowNo,Int32 deliveredGoodsDiv,Int32 handleDivCode,Int32 partsShape,Int32 delivrdGdsConfCd,DateTime deliGdsCmpltDueDate,Int32 tbsPartsCode,string pmPartsNameKana,Double salesOrderCount,Double deliveredGoodsCount,string partsNoWithHyphen,Int32 pmPartsMakerCode,Int32 purePartsMakerCode,string purePrtsNoWithHyphen,Int64 listPrice,Int64 unitPrice,Int32 pmDtlTakeinDivCd,string enterpriseName,string updEmployeeName)
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
			this._tspCommRowNo = tspCommRowNo;
			this._deliveredGoodsDiv = deliveredGoodsDiv;
			this._handleDivCode = handleDivCode;
			this._partsShape = partsShape;
			this._delivrdGdsConfCd = delivrdGdsConfCd;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._tbsPartsCode = tbsPartsCode;
			this._pmPartsNameKana = pmPartsNameKana;
			this._salesOrderCount = salesOrderCount;
			this._deliveredGoodsCount = deliveredGoodsCount;
			this._partsNoWithHyphen = partsNoWithHyphen;
			this._pmPartsMakerCode = pmPartsMakerCode;
			this._purePartsMakerCode = purePartsMakerCode;
			this._purePrtsNoWithHyphen = purePrtsNoWithHyphen;
			this._listPrice = listPrice;
			this._unitPrice = unitPrice;
			this._pmDtlTakeinDivCd = pmDtlTakeinDivCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// TSP����M���׃f�[�^��������
		/// </summary>
		/// <returns>TspSdRvDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TspSdRvDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TspSdRvDtl Clone()
		{
			return new TspSdRvDtl(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._pmEnterpriseCode,this._tspCommNo,this._tspCommCount,this._tspCommRowNo,this._deliveredGoodsDiv,this._handleDivCode,this._partsShape,this._delivrdGdsConfCd,this._deliGdsCmpltDueDate,this._tbsPartsCode,this._pmPartsNameKana,this._salesOrderCount,this._deliveredGoodsCount,this._partsNoWithHyphen,this._pmPartsMakerCode,this._purePartsMakerCode,this._purePrtsNoWithHyphen,this._listPrice,this._unitPrice,this._pmDtlTakeinDivCd,this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// TSP����M���׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�TspSdRvDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(TspSdRvDtl target)
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
				 && (this.TspCommRowNo == target.TspCommRowNo)
				 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
				 && (this.HandleDivCode == target.HandleDivCode)
				 && (this.PartsShape == target.PartsShape)
				 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.TbsPartsCode == target.TbsPartsCode)
				 && (this.PmPartsNameKana == target.PmPartsNameKana)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
				 && (this.PartsNoWithHyphen == target.PartsNoWithHyphen)
				 && (this.PmPartsMakerCode == target.PmPartsMakerCode)
				 && (this.PurePartsMakerCode == target.PurePartsMakerCode)
				 && (this.PurePrtsNoWithHyphen == target.PurePrtsNoWithHyphen)
				 && (this.ListPrice == target.ListPrice)
				 && (this.UnitPrice == target.UnitPrice)
				 && (this.PmDtlTakeinDivCd == target.PmDtlTakeinDivCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// TSP����M���׃f�[�^��r����
		/// </summary>
		/// <param name="tspSdRvDtl1">
		///                    ��r����TspSdRvDtl�N���X�̃C���X�^���X
		/// </param>
		/// <param name="tspSdRvDtl2">��r����TspSdRvDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(TspSdRvDtl tspSdRvDtl1, TspSdRvDtl tspSdRvDtl2)
		{
			return ((tspSdRvDtl1.CreateDateTime == tspSdRvDtl2.CreateDateTime)
				 && (tspSdRvDtl1.UpdateDateTime == tspSdRvDtl2.UpdateDateTime)
				 && (tspSdRvDtl1.EnterpriseCode == tspSdRvDtl2.EnterpriseCode)
				 && (tspSdRvDtl1.FileHeaderGuid == tspSdRvDtl2.FileHeaderGuid)
				 && (tspSdRvDtl1.UpdEmployeeCode == tspSdRvDtl2.UpdEmployeeCode)
				 && (tspSdRvDtl1.UpdAssemblyId1 == tspSdRvDtl2.UpdAssemblyId1)
				 && (tspSdRvDtl1.UpdAssemblyId2 == tspSdRvDtl2.UpdAssemblyId2)
				 && (tspSdRvDtl1.LogicalDeleteCode == tspSdRvDtl2.LogicalDeleteCode)
				 && (tspSdRvDtl1.PmEnterpriseCode == tspSdRvDtl2.PmEnterpriseCode)
				 && (tspSdRvDtl1.TspCommNo == tspSdRvDtl2.TspCommNo)
				 && (tspSdRvDtl1.TspCommCount == tspSdRvDtl2.TspCommCount)
				 && (tspSdRvDtl1.TspCommRowNo == tspSdRvDtl2.TspCommRowNo)
				 && (tspSdRvDtl1.DeliveredGoodsDiv == tspSdRvDtl2.DeliveredGoodsDiv)
				 && (tspSdRvDtl1.HandleDivCode == tspSdRvDtl2.HandleDivCode)
				 && (tspSdRvDtl1.PartsShape == tspSdRvDtl2.PartsShape)
				 && (tspSdRvDtl1.DelivrdGdsConfCd == tspSdRvDtl2.DelivrdGdsConfCd)
				 && (tspSdRvDtl1.DeliGdsCmpltDueDate == tspSdRvDtl2.DeliGdsCmpltDueDate)
				 && (tspSdRvDtl1.TbsPartsCode == tspSdRvDtl2.TbsPartsCode)
				 && (tspSdRvDtl1.PmPartsNameKana == tspSdRvDtl2.PmPartsNameKana)
				 && (tspSdRvDtl1.SalesOrderCount == tspSdRvDtl2.SalesOrderCount)
				 && (tspSdRvDtl1.DeliveredGoodsCount == tspSdRvDtl2.DeliveredGoodsCount)
				 && (tspSdRvDtl1.PartsNoWithHyphen == tspSdRvDtl2.PartsNoWithHyphen)
				 && (tspSdRvDtl1.PmPartsMakerCode == tspSdRvDtl2.PmPartsMakerCode)
				 && (tspSdRvDtl1.PurePartsMakerCode == tspSdRvDtl2.PurePartsMakerCode)
				 && (tspSdRvDtl1.PurePrtsNoWithHyphen == tspSdRvDtl2.PurePrtsNoWithHyphen)
				 && (tspSdRvDtl1.ListPrice == tspSdRvDtl2.ListPrice)
				 && (tspSdRvDtl1.UnitPrice == tspSdRvDtl2.UnitPrice)
				 && (tspSdRvDtl1.PmDtlTakeinDivCd == tspSdRvDtl2.PmDtlTakeinDivCd)
				 && (tspSdRvDtl1.EnterpriseName == tspSdRvDtl2.EnterpriseName)
				 && (tspSdRvDtl1.UpdEmployeeName == tspSdRvDtl2.UpdEmployeeName));
		}
		/// <summary>
		/// TSP����M���׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�TspSdRvDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(TspSdRvDtl target)
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
			if(this.TspCommRowNo != target.TspCommRowNo)resList.Add("TspCommRowNo");
			if(this.DeliveredGoodsDiv != target.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(this.HandleDivCode != target.HandleDivCode)resList.Add("HandleDivCode");
			if(this.PartsShape != target.PartsShape)resList.Add("PartsShape");
			if(this.DelivrdGdsConfCd != target.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.TbsPartsCode != target.TbsPartsCode)resList.Add("TbsPartsCode");
			if(this.PmPartsNameKana != target.PmPartsNameKana)resList.Add("PmPartsNameKana");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.DeliveredGoodsCount != target.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(this.PartsNoWithHyphen != target.PartsNoWithHyphen)resList.Add("PartsNoWithHyphen");
			if(this.PmPartsMakerCode != target.PmPartsMakerCode)resList.Add("PmPartsMakerCode");
			if(this.PurePartsMakerCode != target.PurePartsMakerCode)resList.Add("PurePartsMakerCode");
			if(this.PurePrtsNoWithHyphen != target.PurePrtsNoWithHyphen)resList.Add("PurePrtsNoWithHyphen");
			if(this.ListPrice != target.ListPrice)resList.Add("ListPrice");
			if(this.UnitPrice != target.UnitPrice)resList.Add("UnitPrice");
			if(this.PmDtlTakeinDivCd != target.PmDtlTakeinDivCd)resList.Add("PmDtlTakeinDivCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// TSP����M���׃f�[�^��r����
		/// </summary>
		/// <param name="tspSdRvDtl1">��r����TspSdRvDtl�N���X�̃C���X�^���X</param>
		/// <param name="tspSdRvDtl2">��r����TspSdRvDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TspSdRvDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(TspSdRvDtl tspSdRvDtl1, TspSdRvDtl tspSdRvDtl2)
		{
			ArrayList resList = new ArrayList();
			if(tspSdRvDtl1.CreateDateTime != tspSdRvDtl2.CreateDateTime)resList.Add("CreateDateTime");
			if(tspSdRvDtl1.UpdateDateTime != tspSdRvDtl2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(tspSdRvDtl1.EnterpriseCode != tspSdRvDtl2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(tspSdRvDtl1.FileHeaderGuid != tspSdRvDtl2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(tspSdRvDtl1.UpdEmployeeCode != tspSdRvDtl2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(tspSdRvDtl1.UpdAssemblyId1 != tspSdRvDtl2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(tspSdRvDtl1.UpdAssemblyId2 != tspSdRvDtl2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(tspSdRvDtl1.LogicalDeleteCode != tspSdRvDtl2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(tspSdRvDtl1.PmEnterpriseCode != tspSdRvDtl2.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(tspSdRvDtl1.TspCommNo != tspSdRvDtl2.TspCommNo)resList.Add("TspCommNo");
			if(tspSdRvDtl1.TspCommCount != tspSdRvDtl2.TspCommCount)resList.Add("TspCommCount");
			if(tspSdRvDtl1.TspCommRowNo != tspSdRvDtl2.TspCommRowNo)resList.Add("TspCommRowNo");
			if(tspSdRvDtl1.DeliveredGoodsDiv != tspSdRvDtl2.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(tspSdRvDtl1.HandleDivCode != tspSdRvDtl2.HandleDivCode)resList.Add("HandleDivCode");
			if(tspSdRvDtl1.PartsShape != tspSdRvDtl2.PartsShape)resList.Add("PartsShape");
			if(tspSdRvDtl1.DelivrdGdsConfCd != tspSdRvDtl2.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(tspSdRvDtl1.DeliGdsCmpltDueDate != tspSdRvDtl2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(tspSdRvDtl1.TbsPartsCode != tspSdRvDtl2.TbsPartsCode)resList.Add("TbsPartsCode");
			if(tspSdRvDtl1.PmPartsNameKana != tspSdRvDtl2.PmPartsNameKana)resList.Add("PmPartsNameKana");
			if(tspSdRvDtl1.SalesOrderCount != tspSdRvDtl2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(tspSdRvDtl1.DeliveredGoodsCount != tspSdRvDtl2.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(tspSdRvDtl1.PartsNoWithHyphen != tspSdRvDtl2.PartsNoWithHyphen)resList.Add("PartsNoWithHyphen");
			if(tspSdRvDtl1.PmPartsMakerCode != tspSdRvDtl2.PmPartsMakerCode)resList.Add("PmPartsMakerCode");
			if(tspSdRvDtl1.PurePartsMakerCode != tspSdRvDtl2.PurePartsMakerCode)resList.Add("PurePartsMakerCode");
			if(tspSdRvDtl1.PurePrtsNoWithHyphen != tspSdRvDtl2.PurePrtsNoWithHyphen)resList.Add("PurePrtsNoWithHyphen");
			if(tspSdRvDtl1.ListPrice != tspSdRvDtl2.ListPrice)resList.Add("ListPrice");
			if(tspSdRvDtl1.UnitPrice != tspSdRvDtl2.UnitPrice)resList.Add("UnitPrice");
			if(tspSdRvDtl1.PmDtlTakeinDivCd != tspSdRvDtl2.PmDtlTakeinDivCd)resList.Add("PmDtlTakeinDivCd");
			if(tspSdRvDtl1.EnterpriseName != tspSdRvDtl2.EnterpriseName)resList.Add("EnterpriseName");
			if(tspSdRvDtl1.UpdEmployeeName != tspSdRvDtl2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
