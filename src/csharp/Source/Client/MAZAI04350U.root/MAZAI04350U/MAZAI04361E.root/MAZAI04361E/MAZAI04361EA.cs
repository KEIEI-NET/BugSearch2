using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAdjust
	/// <summary>
	///                      �݌ɒ����f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɒ����f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/08/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/20  ����</br>
	/// <br>                 :   �󕥌��`�[�敪,�󕥌�����敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v�ǉ�</br>
	/// <br>Update Note      :   2008/6/30  ����</br>
	/// <br>                 :   �󕥌�����敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v�폜</br>
	/// <br>Update Note      :   2008/8/22  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �@���͒S���҃R�[�h</br>
	/// <br>                 :   �@���͒S���Җ���</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �@�d�����_�R�[�h</br>
	/// <br>                 :   �@�d�����͎҃R�[�h</br>
	/// <br>                 :   �@�d�����͎Җ���</br>
	/// <br>                 :   �@�d���S���҃R�[�h</br>
	/// <br>                 :   �@�d���S���Җ���</br>
	/// <br>                 :   �@�d�����z���v</br>
	/// </remarks>
	public class StockAdjust
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

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�݌ɒ����`�[�ԍ�</summary>
		private Int32 _stockAdjustSlipNo;

		/// <summary>�󕥌��`�[�敪</summary>
		/// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>�󕥌�����敪</summary>
		/// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</remarks>
		private Int32 _acPayTransCd;

		/// <summary>�������t</summary>
		private DateTime _adjustDate;

		/// <summary>���͓��t</summary>
		private DateTime _inputDay;

		/// <summary>�d�����_�R�[�h</summary>
		private string _stockSectionCd = "";

		/// <summary>�d�����͎҃R�[�h</summary>
		private string _stockInputCode = "";

		/// <summary>�d�����͎Җ���</summary>
		private string _stockInputName = "";

		/// <summary>�d���S���҃R�[�h</summary>
		private string _stockAgentCode = "";

		/// <summary>�d���S���Җ���</summary>
		private string _stockAgentName = "";

		/// <summary>�d�����z���v</summary>
		private Int64 _stockSubttlPrice;

		/// <summary>�`�[���l</summary>
		private string _slipNote = "";

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>�d�����_����</summary>
		private string _stockSectionNm = "";


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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  StockAdjustSlipNo
		/// <summary>�݌ɒ����`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɒ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockAdjustSlipNo
		{
			get{return _stockAdjustSlipNo;}
			set{_stockAdjustSlipNo = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
		/// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>�󕥌�����敪�v���p�e�B</summary>
		/// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AdjustDate
		/// <summary>�������t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AdjustDate
		{
			get{return _adjustDate;}
			set{_adjustDate = value;}
		}

		/// public propaty name  :  AdjustDateJpFormal
		/// <summary>�������t �a��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������t �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AdjustDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateJpInFormal
		/// <summary>�������t �a��(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������t �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AdjustDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateAdFormal
		/// <summary>�������t ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������t ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AdjustDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateAdInFormal
		/// <summary>�������t ����(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������t ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AdjustDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  InputDay
		/// <summary>���͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  InputDayJpFormal
		/// <summary>���͓��t �a��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayJpInFormal
		/// <summary>���͓��t �a��(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdFormal
		/// <summary>���͓��t ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdInFormal
		/// <summary>���͓��t ����(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InputDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  StockSectionCd
		/// <summary>�d�����_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockSectionCd
		{
			get{return _stockSectionCd;}
			set{_stockSectionCd = value;}
		}

		/// public propaty name  :  StockInputCode
		/// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  StockInputName
		/// <summary>�d�����͎Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockInputName
		{
			get{return _stockInputName;}
			set{_stockInputName = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>�d���S���Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  StockSubttlPrice
		/// <summary>�d�����z���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockSubttlPrice
		{
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
		}

		/// public propaty name  :  SlipNote
		/// <summary>�`�[���l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
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

		/// public propaty name  :  StockSectionNm
		/// <summary>�d�����_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockSectionNm
		{
			get{return _stockSectionNm;}
			set{_stockSectionNm = value;}
		}


		/// <summary>
		/// �݌ɒ����f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>StockAdjust�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjust�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjust()
		{
		}

		/// <summary>
		/// �݌ɒ����f�[�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="stockAdjustSlipNo">�݌ɒ����`�[�ԍ�</param>
		/// <param name="acPaySlipCd">�󕥌��`�[�敪(10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��)</param>
		/// <param name="acPayTransCd">�󕥌�����敪(10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���)</param>
		/// <param name="adjustDate">�������t</param>
		/// <param name="inputDay">���͓��t</param>
		/// <param name="stockSectionCd">�d�����_�R�[�h</param>
		/// <param name="stockInputCode">�d�����͎҃R�[�h</param>
		/// <param name="stockInputName">�d�����͎Җ���</param>
		/// <param name="stockAgentCode">�d���S���҃R�[�h</param>
		/// <param name="stockAgentName">�d���S���Җ���</param>
		/// <param name="stockSubttlPrice">�d�����z���v</param>
		/// <param name="slipNote">�`�[���l</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="stockSectionNm">�d�����_����</param>
		/// <returns>StockAdjust�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjust�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjust(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 stockAdjustSlipNo,Int32 acPaySlipCd,Int32 acPayTransCd,DateTime adjustDate,DateTime inputDay,string stockSectionCd,string stockInputCode,string stockInputName,string stockAgentCode,string stockAgentName,Int64 stockSubttlPrice,string slipNote,string enterpriseName,string updEmployeeName,string stockSectionNm)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._stockAdjustSlipNo = stockAdjustSlipNo;
			this._acPaySlipCd = acPaySlipCd;
			this._acPayTransCd = acPayTransCd;
			this.AdjustDate = adjustDate;
			this.InputDay = inputDay;
			this._stockSectionCd = stockSectionCd;
			this._stockInputCode = stockInputCode;
			this._stockInputName = stockInputName;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._stockSubttlPrice = stockSubttlPrice;
			this._slipNote = slipNote;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._stockSectionNm = stockSectionNm;

		}

		/// <summary>
		/// �݌ɒ����f�[�^��������
		/// </summary>
		/// <returns>StockAdjust�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockAdjust�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjust Clone()
		{
			return new StockAdjust(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._stockAdjustSlipNo,this._acPaySlipCd,this._acPayTransCd,this._adjustDate,this._inputDay,this._stockSectionCd,this._stockInputCode,this._stockInputName,this._stockAgentCode,this._stockAgentName,this._stockSubttlPrice,this._slipNote,this._enterpriseName,this._updEmployeeName,this._stockSectionNm);
		}

		/// <summary>
		/// �݌ɒ����f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockAdjust�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjust�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockAdjust target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.StockAdjustSlipNo == target.StockAdjustSlipNo)
				 && (this.AcPaySlipCd == target.AcPaySlipCd)
				 && (this.AcPayTransCd == target.AcPayTransCd)
				 && (this.AdjustDate == target.AdjustDate)
				 && (this.InputDay == target.InputDay)
				 && (this.StockSectionCd == target.StockSectionCd)
				 && (this.StockInputCode == target.StockInputCode)
				 && (this.StockInputName == target.StockInputName)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.StockSubttlPrice == target.StockSubttlPrice)
				 && (this.SlipNote == target.SlipNote)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.StockSectionNm == target.StockSectionNm));
		}

		/// <summary>
		/// �݌ɒ����f�[�^��r����
		/// </summary>
		/// <param name="stockAdjust1">
		///                    ��r����StockAdjust�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockAdjust2">��r����StockAdjust�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjust�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockAdjust stockAdjust1, StockAdjust stockAdjust2)
		{
			return ((stockAdjust1.CreateDateTime == stockAdjust2.CreateDateTime)
				 && (stockAdjust1.UpdateDateTime == stockAdjust2.UpdateDateTime)
				 && (stockAdjust1.EnterpriseCode == stockAdjust2.EnterpriseCode)
				 && (stockAdjust1.FileHeaderGuid == stockAdjust2.FileHeaderGuid)
				 && (stockAdjust1.UpdEmployeeCode == stockAdjust2.UpdEmployeeCode)
				 && (stockAdjust1.UpdAssemblyId1 == stockAdjust2.UpdAssemblyId1)
				 && (stockAdjust1.UpdAssemblyId2 == stockAdjust2.UpdAssemblyId2)
				 && (stockAdjust1.LogicalDeleteCode == stockAdjust2.LogicalDeleteCode)
				 && (stockAdjust1.SectionCode == stockAdjust2.SectionCode)
				 && (stockAdjust1.StockAdjustSlipNo == stockAdjust2.StockAdjustSlipNo)
				 && (stockAdjust1.AcPaySlipCd == stockAdjust2.AcPaySlipCd)
				 && (stockAdjust1.AcPayTransCd == stockAdjust2.AcPayTransCd)
				 && (stockAdjust1.AdjustDate == stockAdjust2.AdjustDate)
				 && (stockAdjust1.InputDay == stockAdjust2.InputDay)
				 && (stockAdjust1.StockSectionCd == stockAdjust2.StockSectionCd)
				 && (stockAdjust1.StockInputCode == stockAdjust2.StockInputCode)
				 && (stockAdjust1.StockInputName == stockAdjust2.StockInputName)
				 && (stockAdjust1.StockAgentCode == stockAdjust2.StockAgentCode)
				 && (stockAdjust1.StockAgentName == stockAdjust2.StockAgentName)
				 && (stockAdjust1.StockSubttlPrice == stockAdjust2.StockSubttlPrice)
				 && (stockAdjust1.SlipNote == stockAdjust2.SlipNote)
				 && (stockAdjust1.EnterpriseName == stockAdjust2.EnterpriseName)
				 && (stockAdjust1.UpdEmployeeName == stockAdjust2.UpdEmployeeName)
				 && (stockAdjust1.StockSectionNm == stockAdjust2.StockSectionNm));
		}
		/// <summary>
		/// �݌ɒ����f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockAdjust�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjust�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockAdjust target)
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
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.StockAdjustSlipNo != target.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(this.AcPaySlipCd != target.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(this.AcPayTransCd != target.AcPayTransCd)resList.Add("AcPayTransCd");
			if(this.AdjustDate != target.AdjustDate)resList.Add("AdjustDate");
			if(this.InputDay != target.InputDay)resList.Add("InputDay");
			if(this.StockSectionCd != target.StockSectionCd)resList.Add("StockSectionCd");
			if(this.StockInputCode != target.StockInputCode)resList.Add("StockInputCode");
			if(this.StockInputName != target.StockInputName)resList.Add("StockInputName");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.StockSubttlPrice != target.StockSubttlPrice)resList.Add("StockSubttlPrice");
			if(this.SlipNote != target.SlipNote)resList.Add("SlipNote");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.StockSectionNm != target.StockSectionNm)resList.Add("StockSectionNm");

			return resList;
		}

		/// <summary>
		/// �݌ɒ����f�[�^��r����
		/// </summary>
		/// <param name="stockAdjust1">��r����StockAdjust�N���X�̃C���X�^���X</param>
		/// <param name="stockAdjust2">��r����StockAdjust�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjust�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockAdjust stockAdjust1, StockAdjust stockAdjust2)
		{
			ArrayList resList = new ArrayList();
			if(stockAdjust1.CreateDateTime != stockAdjust2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockAdjust1.UpdateDateTime != stockAdjust2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockAdjust1.EnterpriseCode != stockAdjust2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockAdjust1.FileHeaderGuid != stockAdjust2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockAdjust1.UpdEmployeeCode != stockAdjust2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockAdjust1.UpdAssemblyId1 != stockAdjust2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockAdjust1.UpdAssemblyId2 != stockAdjust2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockAdjust1.LogicalDeleteCode != stockAdjust2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockAdjust1.SectionCode != stockAdjust2.SectionCode)resList.Add("SectionCode");
			if(stockAdjust1.StockAdjustSlipNo != stockAdjust2.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(stockAdjust1.AcPaySlipCd != stockAdjust2.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(stockAdjust1.AcPayTransCd != stockAdjust2.AcPayTransCd)resList.Add("AcPayTransCd");
			if(stockAdjust1.AdjustDate != stockAdjust2.AdjustDate)resList.Add("AdjustDate");
			if(stockAdjust1.InputDay != stockAdjust2.InputDay)resList.Add("InputDay");
			if(stockAdjust1.StockSectionCd != stockAdjust2.StockSectionCd)resList.Add("StockSectionCd");
			if(stockAdjust1.StockInputCode != stockAdjust2.StockInputCode)resList.Add("StockInputCode");
			if(stockAdjust1.StockInputName != stockAdjust2.StockInputName)resList.Add("StockInputName");
			if(stockAdjust1.StockAgentCode != stockAdjust2.StockAgentCode)resList.Add("StockAgentCode");
			if(stockAdjust1.StockAgentName != stockAdjust2.StockAgentName)resList.Add("StockAgentName");
			if(stockAdjust1.StockSubttlPrice != stockAdjust2.StockSubttlPrice)resList.Add("StockSubttlPrice");
			if(stockAdjust1.SlipNote != stockAdjust2.SlipNote)resList.Add("SlipNote");
			if(stockAdjust1.EnterpriseName != stockAdjust2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockAdjust1.UpdEmployeeName != stockAdjust2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockAdjust1.StockSectionNm != stockAdjust2.StockSectionNm)resList.Add("StockSectionNm");

			return resList;
		}
	}
}
