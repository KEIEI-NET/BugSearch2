using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAdjustDtl
	/// <summary>
	///                      �݌ɒ������׃f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɒ������׃f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/08/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/20  ����</br>
	/// <br>                 :   �󕥌�����敪�A�󕥌��`�[�敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v��ǉ�</br>
	/// <br>Update Note      :   2008/6/30  ����</br>
	/// <br>                 :   �󕥌�����敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v�폜</br>
	/// <br>Update Note      :   2008/7/29  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �d���`���i���j</br>
	/// <br>                 :   �d�����גʔԁi���j</br>
	/// <br>Update Note      :   2008/8/22  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �@�d���݌ɐ�</br>
	/// <br>                 :   �@�����</br>
	/// <br>                 :   �@�ύX�O�݌ɏ��</br>
	/// <br>                 :   �@�݌ɋ敪</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �@BL���i�R�[�h����</br>
	/// <br>                 :   �@�I�[�v�����i�敪</br>
	/// <br>                 :   �@�d�����z�i�Ŕ����j</br>
	/// </remarks>
	public class StockAdjustDtl
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

		/// <summary>�݌ɒ����s�ԍ�</summary>
		private Int32 _stockAdjustRowNo;

		/// <summary>�d���`���i���j</summary>
		/// <remarks>0:�d��,1:����,2:����</remarks>
		private Int32 _supplierFormalSrc;

		/// <summary>�d�����גʔԁi���j</summary>
		/// <remarks>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</remarks>
		private Int64 _stockSlipDtlNumSrc;

		/// <summary>�󕥌��`�[�敪</summary>
		/// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>�󕥌�����敪</summary>
		/// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</remarks>
		private Int32 _acPayTransCd;

		/// <summary>�������t</summary>
		private DateTime _adjustDate;

		/// <summary>���͓��t</summary>
		private DateTime _inputDay;

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>�d���P���i�Ŕ�,�����j</summary>
		/// <remarks>�݌ɒ������́A�I���ߕs���X�V�̒P���ύX���ɃZ�b�g</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>�ύX�O�d���P���i�����j</summary>
		private Double _bfStockUnitPriceFl;

		/// <summary>������</summary>
		/// <remarks>�ύX�O�ƕύX��̎d���݌ɐ��̍���o�^����B</remarks>
		private Double _adjustCount;

		/// <summary>���ה��l</summary>
		private string _dtlNote = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�S�p�j</summary>
		private string _bLGoodsFullName = "";

		/// <summary>�q�ɒI��</summary>
		private string _warehouseShelfNo = "";

		/// <summary>�艿�i�����j</summary>
		private Double _listPriceFl;

		/// <summary>�I�[�v�����i�敪</summary>
		/// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
		private Int32 _openPriceDiv;

		/// <summary>�d�����z�i�Ŕ����j</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private String _supplierSnm;

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

		/// public propaty name  :  StockAdjustRowNo
		/// <summary>�݌ɒ����s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɒ����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockAdjustRowNo
		{
			get{return _stockAdjustRowNo;}
			set{_stockAdjustRowNo = value;}
		}

		/// public propaty name  :  SupplierFormalSrc
		/// <summary>�d���`���i���j�v���p�e�B</summary>
		/// <value>0:�d��,1:����,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`���i���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormalSrc
		{
			get{return _supplierFormalSrc;}
			set{_supplierFormalSrc = value;}
		}

		/// public propaty name  :  StockSlipDtlNumSrc
		/// <summary>�d�����גʔԁi���j�v���p�e�B</summary>
		/// <value>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����גʔԁi���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockSlipDtlNumSrc
		{
			get{return _stockSlipDtlNumSrc;}
			set{_stockSlipDtlNumSrc = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
		/// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</value>
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
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

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>���i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
		/// <value>�݌ɒ������́A�I���ߕs���X�V�̒P���ύX���ɃZ�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  BfStockUnitPriceFl
		/// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX�O�d���P���i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BfStockUnitPriceFl
		{
			get{return _bfStockUnitPriceFl;}
			set{_bfStockUnitPriceFl = value;}
		}

		/// public propaty name  :  AdjustCount
		/// <summary>�������v���p�e�B</summary>
		/// <value>�ύX�O�ƕύX��̎d���݌ɐ��̍���o�^����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double AdjustCount
		{
			get{return _adjustCount;}
			set{_adjustCount = value;}
		}

		/// public propaty name  :  DtlNote
		/// <summary>���ה��l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ה��l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DtlNote
		{
			get{return _dtlNote;}
			set{_dtlNote = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>�q�ɖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>�q�ɒI�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  ListPriceFl
		/// <summary>�艿�i�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceFl
		{
			get{return _listPriceFl;}
			set{_listPriceFl = value;}
		}

		/// public propaty name  :  OpenPriceDiv
		/// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
		/// <value>0:�ʏ�^1:�I�[�v�����i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OpenPriceDiv
		{
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
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

		/// public propaty name  :  BLGoodsName
		/// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }


		/// <summary>
		/// �݌ɒ������׃f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>StockAdjustDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjustDtl()
		{
		}

		/// <summary>
		/// �݌ɒ������׃f�[�^�R���X�g���N�^
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
		/// <param name="stockAdjustRowNo">�݌ɒ����s�ԍ�</param>
		/// <param name="supplierFormalSrc">�d���`���i���j(0:�d��,1:����,2:����)</param>
		/// <param name="stockSlipDtlNumSrc">�d�����גʔԁi���j(�v�㎞�̌��f�[�^���גʔԂ��Z�b�g)</param>
		/// <param name="acPaySlipCd">�󕥌��`�[�敪(10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��)</param>
		/// <param name="acPayTransCd">�󕥌�����敪(10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���)</param>
		/// <param name="adjustDate">�������t</param>
		/// <param name="inputDay">���͓��t</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="stockUnitPriceFl">�d���P���i�Ŕ�,�����j(�݌ɒ������́A�I���ߕs���X�V�̒P���ύX���ɃZ�b�g)</param>
		/// <param name="bfStockUnitPriceFl">�ύX�O�d���P���i�����j</param>
		/// <param name="adjustCount">������(�ύX�O�ƕύX��̎d���݌ɐ��̍���o�^����B)</param>
		/// <param name="dtlNote">���ה��l</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
		/// <param name="warehouseShelfNo">�q�ɒI��</param>
		/// <param name="listPriceFl">�艿�i�����j</param>
		/// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
		/// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
		/// <returns>StockAdjustDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjustDtl(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 stockAdjustSlipNo,Int32 stockAdjustRowNo,Int32 supplierFormalSrc,Int64 stockSlipDtlNumSrc,Int32 acPaySlipCd,Int32 acPayTransCd,DateTime adjustDate,DateTime inputDay,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,Double stockUnitPriceFl,Double bfStockUnitPriceFl,Double adjustCount,string dtlNote,string warehouseCode,string warehouseName,Int32 bLGoodsCode,string bLGoodsFullName,string warehouseShelfNo,Double listPriceFl,Int32 openPriceDiv,Int64 stockPriceTaxExc,string enterpriseName,string updEmployeeName,string bLGoodsName, Int32 supplierCd, String supplierSnm)
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
			this._stockAdjustRowNo = stockAdjustRowNo;
			this._supplierFormalSrc = supplierFormalSrc;
			this._stockSlipDtlNumSrc = stockSlipDtlNumSrc;
			this._acPaySlipCd = acPaySlipCd;
			this._acPayTransCd = acPayTransCd;
			this.AdjustDate = adjustDate;
			this.InputDay = inputDay;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this._bfStockUnitPriceFl = bfStockUnitPriceFl;
			this._adjustCount = adjustCount;
			this._dtlNote = dtlNote;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._listPriceFl = listPriceFl;
			this._openPriceDiv = openPriceDiv;
			this._stockPriceTaxExc = stockPriceTaxExc;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
		}

		/// <summary>
		/// �݌ɒ������׃f�[�^��������
		/// </summary>
		/// <returns>StockAdjustDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockAdjustDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjustDtl Clone()
		{
			return new StockAdjustDtl(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._stockAdjustSlipNo,this._stockAdjustRowNo,this._supplierFormalSrc,this._stockSlipDtlNumSrc,this._acPaySlipCd,this._acPayTransCd,this._adjustDate,this._inputDay,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._stockUnitPriceFl,this._bfStockUnitPriceFl,this._adjustCount,this._dtlNote,this._warehouseCode,this._warehouseName,this._bLGoodsCode,this._bLGoodsFullName,this._warehouseShelfNo,this._listPriceFl,this._openPriceDiv,this._stockPriceTaxExc,this._enterpriseName,this._updEmployeeName,this._bLGoodsName, this._supplierCd, this._supplierSnm);
		}

		/// <summary>
		/// �݌ɒ������׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockAdjustDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockAdjustDtl target)
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
				 && (this.StockAdjustRowNo == target.StockAdjustRowNo)
				 && (this.SupplierFormalSrc == target.SupplierFormalSrc)
				 && (this.StockSlipDtlNumSrc == target.StockSlipDtlNumSrc)
				 && (this.AcPaySlipCd == target.AcPaySlipCd)
				 && (this.AcPayTransCd == target.AcPayTransCd)
				 && (this.AdjustDate == target.AdjustDate)
				 && (this.InputDay == target.InputDay)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
				 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
				 && (this.AdjustCount == target.AdjustCount)
				 && (this.DtlNote == target.DtlNote)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.ListPriceFl == target.ListPriceFl)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 );
		}

		/// <summary>
		/// �݌ɒ������׃f�[�^��r����
		/// </summary>
		/// <param name="stockAdjustDtl1">
		///                    ��r����StockAdjustDtl�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockAdjustDtl2">��r����StockAdjustDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockAdjustDtl stockAdjustDtl1, StockAdjustDtl stockAdjustDtl2)
		{
			return ((stockAdjustDtl1.CreateDateTime == stockAdjustDtl2.CreateDateTime)
				 && (stockAdjustDtl1.UpdateDateTime == stockAdjustDtl2.UpdateDateTime)
				 && (stockAdjustDtl1.EnterpriseCode == stockAdjustDtl2.EnterpriseCode)
				 && (stockAdjustDtl1.FileHeaderGuid == stockAdjustDtl2.FileHeaderGuid)
				 && (stockAdjustDtl1.UpdEmployeeCode == stockAdjustDtl2.UpdEmployeeCode)
				 && (stockAdjustDtl1.UpdAssemblyId1 == stockAdjustDtl2.UpdAssemblyId1)
				 && (stockAdjustDtl1.UpdAssemblyId2 == stockAdjustDtl2.UpdAssemblyId2)
				 && (stockAdjustDtl1.LogicalDeleteCode == stockAdjustDtl2.LogicalDeleteCode)
				 && (stockAdjustDtl1.SectionCode == stockAdjustDtl2.SectionCode)
				 && (stockAdjustDtl1.StockAdjustSlipNo == stockAdjustDtl2.StockAdjustSlipNo)
				 && (stockAdjustDtl1.StockAdjustRowNo == stockAdjustDtl2.StockAdjustRowNo)
				 && (stockAdjustDtl1.SupplierFormalSrc == stockAdjustDtl2.SupplierFormalSrc)
				 && (stockAdjustDtl1.StockSlipDtlNumSrc == stockAdjustDtl2.StockSlipDtlNumSrc)
				 && (stockAdjustDtl1.AcPaySlipCd == stockAdjustDtl2.AcPaySlipCd)
				 && (stockAdjustDtl1.AcPayTransCd == stockAdjustDtl2.AcPayTransCd)
				 && (stockAdjustDtl1.AdjustDate == stockAdjustDtl2.AdjustDate)
				 && (stockAdjustDtl1.InputDay == stockAdjustDtl2.InputDay)
				 && (stockAdjustDtl1.GoodsMakerCd == stockAdjustDtl2.GoodsMakerCd)
				 && (stockAdjustDtl1.MakerName == stockAdjustDtl2.MakerName)
				 && (stockAdjustDtl1.GoodsNo == stockAdjustDtl2.GoodsNo)
				 && (stockAdjustDtl1.GoodsName == stockAdjustDtl2.GoodsName)
				 && (stockAdjustDtl1.StockUnitPriceFl == stockAdjustDtl2.StockUnitPriceFl)
				 && (stockAdjustDtl1.BfStockUnitPriceFl == stockAdjustDtl2.BfStockUnitPriceFl)
				 && (stockAdjustDtl1.AdjustCount == stockAdjustDtl2.AdjustCount)
				 && (stockAdjustDtl1.DtlNote == stockAdjustDtl2.DtlNote)
				 && (stockAdjustDtl1.WarehouseCode == stockAdjustDtl2.WarehouseCode)
				 && (stockAdjustDtl1.WarehouseName == stockAdjustDtl2.WarehouseName)
				 && (stockAdjustDtl1.BLGoodsCode == stockAdjustDtl2.BLGoodsCode)
				 && (stockAdjustDtl1.BLGoodsFullName == stockAdjustDtl2.BLGoodsFullName)
				 && (stockAdjustDtl1.WarehouseShelfNo == stockAdjustDtl2.WarehouseShelfNo)
				 && (stockAdjustDtl1.ListPriceFl == stockAdjustDtl2.ListPriceFl)
				 && (stockAdjustDtl1.OpenPriceDiv == stockAdjustDtl2.OpenPriceDiv)
				 && (stockAdjustDtl1.StockPriceTaxExc == stockAdjustDtl2.StockPriceTaxExc)
				 && (stockAdjustDtl1.EnterpriseName == stockAdjustDtl2.EnterpriseName)
				 && (stockAdjustDtl1.UpdEmployeeName == stockAdjustDtl2.UpdEmployeeName)
                 && (stockAdjustDtl1.BLGoodsName == stockAdjustDtl2.BLGoodsName)
                 && (stockAdjustDtl1.SupplierCd == stockAdjustDtl2.SupplierCd)
                 && (stockAdjustDtl1.SupplierSnm == stockAdjustDtl2.SupplierSnm)
                 );
		}
		/// <summary>
		/// �݌ɒ������׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockAdjustDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockAdjustDtl target)
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
			if(this.StockAdjustRowNo != target.StockAdjustRowNo)resList.Add("StockAdjustRowNo");
			if(this.SupplierFormalSrc != target.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(this.StockSlipDtlNumSrc != target.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(this.AcPaySlipCd != target.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(this.AcPayTransCd != target.AcPayTransCd)resList.Add("AcPayTransCd");
			if(this.AdjustDate != target.AdjustDate)resList.Add("AdjustDate");
			if(this.InputDay != target.InputDay)resList.Add("InputDay");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.StockUnitPriceFl != target.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(this.BfStockUnitPriceFl != target.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(this.AdjustCount != target.AdjustCount)resList.Add("AdjustCount");
			if(this.DtlNote != target.DtlNote)resList.Add("DtlNote");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.ListPriceFl != target.ListPriceFl)resList.Add("ListPriceFl");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.StockPriceTaxExc != target.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");

			return resList;
		}

		/// <summary>
		/// �݌ɒ������׃f�[�^��r����
		/// </summary>
		/// <param name="stockAdjustDtl1">��r����StockAdjustDtl�N���X�̃C���X�^���X</param>
		/// <param name="stockAdjustDtl2">��r����StockAdjustDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockAdjustDtl stockAdjustDtl1, StockAdjustDtl stockAdjustDtl2)
		{
			ArrayList resList = new ArrayList();
			if(stockAdjustDtl1.CreateDateTime != stockAdjustDtl2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockAdjustDtl1.UpdateDateTime != stockAdjustDtl2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockAdjustDtl1.EnterpriseCode != stockAdjustDtl2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockAdjustDtl1.FileHeaderGuid != stockAdjustDtl2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockAdjustDtl1.UpdEmployeeCode != stockAdjustDtl2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockAdjustDtl1.UpdAssemblyId1 != stockAdjustDtl2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockAdjustDtl1.UpdAssemblyId2 != stockAdjustDtl2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockAdjustDtl1.LogicalDeleteCode != stockAdjustDtl2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockAdjustDtl1.SectionCode != stockAdjustDtl2.SectionCode)resList.Add("SectionCode");
			if(stockAdjustDtl1.StockAdjustSlipNo != stockAdjustDtl2.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(stockAdjustDtl1.StockAdjustRowNo != stockAdjustDtl2.StockAdjustRowNo)resList.Add("StockAdjustRowNo");
			if(stockAdjustDtl1.SupplierFormalSrc != stockAdjustDtl2.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(stockAdjustDtl1.StockSlipDtlNumSrc != stockAdjustDtl2.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(stockAdjustDtl1.AcPaySlipCd != stockAdjustDtl2.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(stockAdjustDtl1.AcPayTransCd != stockAdjustDtl2.AcPayTransCd)resList.Add("AcPayTransCd");
			if(stockAdjustDtl1.AdjustDate != stockAdjustDtl2.AdjustDate)resList.Add("AdjustDate");
			if(stockAdjustDtl1.InputDay != stockAdjustDtl2.InputDay)resList.Add("InputDay");
			if(stockAdjustDtl1.GoodsMakerCd != stockAdjustDtl2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockAdjustDtl1.MakerName != stockAdjustDtl2.MakerName)resList.Add("MakerName");
			if(stockAdjustDtl1.GoodsNo != stockAdjustDtl2.GoodsNo)resList.Add("GoodsNo");
			if(stockAdjustDtl1.GoodsName != stockAdjustDtl2.GoodsName)resList.Add("GoodsName");
			if(stockAdjustDtl1.StockUnitPriceFl != stockAdjustDtl2.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(stockAdjustDtl1.BfStockUnitPriceFl != stockAdjustDtl2.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(stockAdjustDtl1.AdjustCount != stockAdjustDtl2.AdjustCount)resList.Add("AdjustCount");
			if(stockAdjustDtl1.DtlNote != stockAdjustDtl2.DtlNote)resList.Add("DtlNote");
			if(stockAdjustDtl1.WarehouseCode != stockAdjustDtl2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockAdjustDtl1.WarehouseName != stockAdjustDtl2.WarehouseName)resList.Add("WarehouseName");
			if(stockAdjustDtl1.BLGoodsCode != stockAdjustDtl2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockAdjustDtl1.BLGoodsFullName != stockAdjustDtl2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(stockAdjustDtl1.WarehouseShelfNo != stockAdjustDtl2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(stockAdjustDtl1.ListPriceFl != stockAdjustDtl2.ListPriceFl)resList.Add("ListPriceFl");
			if(stockAdjustDtl1.OpenPriceDiv != stockAdjustDtl2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(stockAdjustDtl1.StockPriceTaxExc != stockAdjustDtl2.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(stockAdjustDtl1.EnterpriseName != stockAdjustDtl2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockAdjustDtl1.UpdEmployeeName != stockAdjustDtl2.UpdEmployeeName)resList.Add("UpdEmployeeName");
            if (stockAdjustDtl1.BLGoodsName != stockAdjustDtl2.BLGoodsName) resList.Add("BLGoodsName");
            if (stockAdjustDtl1.SupplierCd != stockAdjustDtl2.SupplierCd) resList.Add("SupplierCd");
            if (stockAdjustDtl1.SupplierSnm != stockAdjustDtl2.SupplierSnm) resList.Add("SupplierSnm");

			return resList;
		}
	}
}
