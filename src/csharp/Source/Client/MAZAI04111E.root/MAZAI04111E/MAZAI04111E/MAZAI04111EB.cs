// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
/*
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockEachWarehouse
	/// <summary>
	///                      �݌Ƀ}�X�^(�q�ɖ�)
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ƀ}�X�^(�q�ɖ�)�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/07/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockEachWarehouse
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

		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>���i�R�[�h</summary>
		private string _goodsCode = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>�d���P��</summary>
		private Int64 _stockUnitPrice;

		/// <summary>�d���݌ɐ�</summary>
		/// <remarks>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
		private Double _supplierStock;

		/// <summary>�����</summary>
		/// <remarks>������Ă���݌ɐ��i���Ѝ݌Ɂj</remarks>
		private Double _trustCount;

		/// <summary>�\��</summary>
		/// <remarks>�\�񂵂Ă��鐔�ʁi�\����͂ŉ��Z�j</remarks>
		private Int32 _reservedCount;

		/// <summary>�����݌ɐ�</summary>
		/// <remarks>�\��A���ώ��Ɉ����݌ɐ������Z</remarks>
		private Double _allowStockCnt;

		/// <summary>�󒍐�</summary>
		private Double _acpOdrCount;

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�d���݌ɕ��ϑ���</summary>
		/// <remarks>�ϑ����Ă���݌ɐ��i���Ѝ݌Ɂj</remarks>
		private Double _entrustCnt;

		/// <summary>������ϑ���</summary>
		/// <remarks>�ϑ����Ă���݌ɐ��i����݌ɕ��j</remarks>
		private Double _trustEntrustCnt;

		/// <summary>���ؐ�</summary>
		private Double _soldCnt;

		/// <summary>�ړ����d���݌ɐ�</summary>
		/// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
		private Double _movingSupliStock;

		/// <summary>�ړ�������݌ɐ�</summary>
		/// <remarks>�@�@�V</remarks>
		private Double _movingTrustStock;

		/// <summary>�o�׉\��</summary>
		/// <remarks>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�����݌ɐ�</remarks>
		private Double _shipmentPosCnt;

		/// <summary>�݌ɕۗL���z</summary>
		/// <remarks>�l���܂�</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>���ԊǗ��敪</summary>
		/// <remarks>0:��,1:�L</remarks>
		private Int32 _prdNumMngDiv;

		/// <summary>�ŏI�d���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

		/// <summary>�ŏI�����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>�ŏI�I���X�V��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastInventoryUpdate;

		/// <summary>�@��R�[�h</summary>
		private string _cellphoneModelCode = "";

		/// <summary>�@�햼��</summary>
		private string _cellphoneModelName = "";

		/// <summary>�L�����A�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�,900�`:���[�U�[�o�^</remarks>
		private Int32 _carrierCode;

		/// <summary>�L�����A����</summary>
		private string _carrierName = "";

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>�n���F�R�[�h</summary>
		private Int32 _systematicColorCd;

		/// <summary>�n���F����</summary>
		private string _systematicColorNm = "";

		/// <summary>���i�敪�O���[�v�R�[�h</summary>
		/// <remarks>���F���i�啪�ރR�[�h</remarks>
		private string _largeGoodsGanreCode = "";

		/// <summary>���i�敪�R�[�h</summary>
		/// <remarks>���F���i�����ރR�[�h</remarks>
		private string _mediumGoodsGanreCode = "";

		/// <summary>�Œ�݌ɐ�</summary>
		private Double _minimumStockCnt;

		/// <summary>�ō��݌ɐ�</summary>
		private Double _maximumStockCnt;

		/// <summary>�������</summary>
		private Double _nmlSalOdrCount;

		/// <summary>�����P��</summary>
		/// <remarks>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</remarks>
		private Int32 _salOdrLot;

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>���i�敪�O���[�v����</summary>
		/// <remarks>���F���i�啪�ޖ���</remarks>
		private string _largeGoodsGanreName = "";

		/// <summary>���i�敪����</summary>
		/// <remarks>���F���i�����ޖ���</remarks>
		private string _mediumGoodsGanreName = "";


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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsCode
		/// <summary>���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsCode
		{
			get{return _goodsCode;}
			set{_goodsCode = value;}
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

		/// public propaty name  :  StockUnitPrice
		/// <summary>�d���P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockUnitPrice
		{
			get{return _stockUnitPrice;}
			set{_stockUnitPrice = value;}
		}

		/// public propaty name  :  SupplierStock
		/// <summary>�d���݌ɐ��v���p�e�B</summary>
		/// <value>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SupplierStock
		{
			get{return _supplierStock;}
			set{_supplierStock = value;}
		}

		/// public propaty name  :  TrustCount
		/// <summary>������v���p�e�B</summary>
		/// <value>������Ă���݌ɐ��i���Ѝ݌Ɂj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double TrustCount
		{
			get{return _trustCount;}
			set{_trustCount = value;}
		}

		/// public propaty name  :  ReservedCount
		/// <summary>�\�񐔃v���p�e�B</summary>
		/// <value>�\�񂵂Ă��鐔�ʁi�\����͂ŉ��Z�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�񐔃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ReservedCount
		{
			get{return _reservedCount;}
			set{_reservedCount = value;}
		}

		/// public propaty name  :  AllowStockCnt
		/// <summary>�����݌ɐ��v���p�e�B</summary>
		/// <value>�\��A���ώ��Ɉ����݌ɐ������Z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double AllowStockCnt
		{
			get{return _allowStockCnt;}
			set{_allowStockCnt = value;}
		}

		/// public propaty name  :  AcpOdrCount
		/// <summary>�󒍐��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍐��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double AcpOdrCount
		{
			get{return _acpOdrCount;}
			set{_acpOdrCount = value;}
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

		/// public propaty name  :  EntrustCnt
		/// <summary>�d���݌ɕ��ϑ����v���p�e�B</summary>
		/// <value>�ϑ����Ă���݌ɐ��i���Ѝ݌Ɂj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���݌ɕ��ϑ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double EntrustCnt
		{
			get{return _entrustCnt;}
			set{_entrustCnt = value;}
		}

		/// public propaty name  :  TrustEntrustCnt
		/// <summary>������ϑ����v���p�e�B</summary>
		/// <value>�ϑ����Ă���݌ɐ��i����݌ɕ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ϑ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double TrustEntrustCnt
		{
			get{return _trustEntrustCnt;}
			set{_trustEntrustCnt = value;}
		}

		/// public propaty name  :  SoldCnt
		/// <summary>���ؐ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ؐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SoldCnt
		{
			get{return _soldCnt;}
			set{_soldCnt = value;}
		}

		/// public propaty name  :  MovingSupliStock
		/// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
		/// <value>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ����d���݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double MovingSupliStock
		{
			get{return _movingSupliStock;}
			set{_movingSupliStock = value;}
		}

		/// public propaty name  :  MovingTrustStock
		/// <summary>�ړ�������݌ɐ��v���p�e�B</summary>
		/// <value>�@�@�V</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ړ�������݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double MovingTrustStock
		{
			get{return _movingTrustStock;}
			set{_movingTrustStock = value;}
		}

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>�o�׉\���v���p�e�B</summary>
		/// <value>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�����݌ɐ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�׉\���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentPosCnt
		{
			get{return _shipmentPosCnt;}
			set{_shipmentPosCnt = value;}
		}

		/// public propaty name  :  StockTotalPrice
		/// <summary>�݌ɕۗL���z�v���p�e�B</summary>
		/// <value>�l���܂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɕۗL���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTotalPrice
		{
			get{return _stockTotalPrice;}
			set{_stockTotalPrice = value;}
		}

		/// public propaty name  :  PrdNumMngDiv
		/// <summary>���ԊǗ��敪�v���p�e�B</summary>
		/// <value>0:��,1:�L</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ԊǗ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrdNumMngDiv
		{
			get{return _prdNumMngDiv;}
			set{_prdNumMngDiv = value;}
		}

		/// public propaty name  :  LastStockDate
		/// <summary>�ŏI�d���N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�d���N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LastStockDate
		{
			get{return _lastStockDate;}
			set{_lastStockDate = value;}
		}

		/// public propaty name  :  LastStockDateJpFormal
		/// <summary>�ŏI�d���N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�d���N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastStockDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastStockDateJpInFormal
		/// <summary>�ŏI�d���N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�d���N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastStockDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastStockDateAdFormal
		/// <summary>�ŏI�d���N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�d���N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastStockDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastStockDateAdInFormal
		/// <summary>�ŏI�d���N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�d���N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastStockDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastStockDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDate
		/// <summary>�ŏI������v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LastSalesDate
		{
			get{return _lastSalesDate;}
			set{_lastSalesDate = value;}
		}

		/// public propaty name  :  LastSalesDateJpFormal
		/// <summary>�ŏI����� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI����� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastSalesDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDateJpInFormal
		/// <summary>�ŏI����� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI����� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastSalesDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDateAdFormal
		/// <summary>�ŏI����� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI����� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastSalesDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastSalesDateAdInFormal
		/// <summary>�ŏI����� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI����� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastSalesDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastSalesDate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdate
		/// <summary>�ŏI�I���X�V���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime LastInventoryUpdate
		{
			get{return _lastInventoryUpdate;}
			set{_lastInventoryUpdate = value;}
		}

		/// public propaty name  :  LastInventoryUpdateJpFormal
		/// <summary>�ŏI�I���X�V�� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastInventoryUpdateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdateJpInFormal
		/// <summary>�ŏI�I���X�V�� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastInventoryUpdateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdateAdFormal
		/// <summary>�ŏI�I���X�V�� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastInventoryUpdateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  LastInventoryUpdateAdInFormal
		/// <summary>�ŏI�I���X�V�� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LastInventoryUpdateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _lastInventoryUpdate);}
			set{}
		}

		/// public propaty name  :  CellphoneModelCode
		/// <summary>�@��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �@��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CellphoneModelCode
		{
			get{return _cellphoneModelCode;}
			set{_cellphoneModelCode = value;}
		}

		/// public propaty name  :  CellphoneModelName
		/// <summary>�@�햼�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �@�햼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CellphoneModelName
		{
			get{return _cellphoneModelName;}
			set{_cellphoneModelName = value;}
		}

		/// public propaty name  :  CarrierCode
		/// <summary>�L�����A�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�,900�`:���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarrierCode
		{
			get{return _carrierCode;}
			set{_carrierCode = value;}
		}

		/// public propaty name  :  CarrierName
		/// <summary>�L�����A���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����A���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarrierName
		{
			get{return _carrierName;}
			set{_carrierName = value;}
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

		/// public propaty name  :  SystematicColorCd
		/// <summary>�n���F�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n���F�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SystematicColorCd
		{
			get{return _systematicColorCd;}
			set{_systematicColorCd = value;}
		}

		/// public propaty name  :  SystematicColorNm
		/// <summary>�n���F���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n���F���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SystematicColorNm
		{
			get{return _systematicColorNm;}
			set{_systematicColorNm = value;}
		}

		/// public propaty name  :  LargeGoodsGanreCode
		/// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���F���i�啪�ރR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LargeGoodsGanreCode
		{
			get{return _largeGoodsGanreCode;}
			set{_largeGoodsGanreCode = value;}
		}

		/// public propaty name  :  MediumGoodsGanreCode
		/// <summary>���i�敪�R�[�h�v���p�e�B</summary>
		/// <value>���F���i�����ރR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MediumGoodsGanreCode
		{
			get{return _mediumGoodsGanreCode;}
			set{_mediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  MinimumStockCnt
		/// <summary>�Œ�݌ɐ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Œ�݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double MinimumStockCnt
		{
			get{return _minimumStockCnt;}
			set{_minimumStockCnt = value;}
		}

		/// public propaty name  :  MaximumStockCnt
		/// <summary>�ō��݌ɐ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ō��݌ɐ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double MaximumStockCnt
		{
			get{return _maximumStockCnt;}
			set{_maximumStockCnt = value;}
		}

		/// public propaty name  :  NmlSalOdrCount
		/// <summary>��������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double NmlSalOdrCount
		{
			get{return _nmlSalOdrCount;}
			set{_nmlSalOdrCount = value;}
		}

		/// public propaty name  :  SalOdrLot
		/// <summary>�����P�ʃv���p�e�B</summary>
		/// <value>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalOdrLot
		{
			get{return _salOdrLot;}
			set{_salOdrLot = value;}
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

		/// public propaty name  :  LargeGoodsGanreName
		/// <summary>���i�敪�O���[�v���̃v���p�e�B</summary>
		/// <value>���F���i�啪�ޖ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�O���[�v���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LargeGoodsGanreName
		{
			get{return _largeGoodsGanreName;}
			set{_largeGoodsGanreName = value;}
		}

		/// public propaty name  :  MediumGoodsGanreName
		/// <summary>���i�敪���̃v���p�e�B</summary>
		/// <value>���F���i�����ޖ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MediumGoodsGanreName
		{
			get{return _mediumGoodsGanreName;}
			set{_mediumGoodsGanreName = value;}
		}


		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)�R���X�g���N�^
		/// </summary>
		/// <returns>StockEachWarehouse�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockEachWarehouse�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockEachWarehouse()
		{
		}

		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)�R���X�g���N�^
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
		/// <param name="GoodsMakerCd">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
		/// <param name="goodsCode">���i�R�[�h</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="stockUnitPrice">�d���P��</param>
		/// <param name="supplierStock">�d���݌ɐ�(��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj)</param>
		/// <param name="trustCount">�����(������Ă���݌ɐ��i���Ѝ݌Ɂj)</param>
		/// <param name="reservedCount">�\��(�\�񂵂Ă��鐔�ʁi�\����͂ŉ��Z�j)</param>
		/// <param name="allowStockCnt">�����݌ɐ�(�\��A���ώ��Ɉ����݌ɐ������Z)</param>
		/// <param name="acpOdrCount">�󒍐�</param>
		/// <param name="salesOrderCount">������</param>
		/// <param name="entrustCnt">�d���݌ɕ��ϑ���(�ϑ����Ă���݌ɐ��i���Ѝ݌Ɂj)</param>
		/// <param name="trustEntrustCnt">������ϑ���(�ϑ����Ă���݌ɐ��i����݌ɕ��j)</param>
		/// <param name="soldCnt">���ؐ�</param>
		/// <param name="movingSupliStock">�ړ����d���݌ɐ�(�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B)</param>
		/// <param name="movingTrustStock">�ړ�������݌ɐ�(�@�@�V)</param>
		/// <param name="shipmentPosCnt">�o�׉\��(�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�����݌ɐ�)</param>
		/// <param name="stockTotalPrice">�݌ɕۗL���z(�l���܂�)</param>
		/// <param name="prdNumMngDiv">���ԊǗ��敪(0:��,1:�L)</param>
		/// <param name="lastStockDate">�ŏI�d���N����(YYYYMMDD)</param>
		/// <param name="lastSalesDate">�ŏI�����(YYYYMMDD)</param>
		/// <param name="lastInventoryUpdate">�ŏI�I���X�V��(YYYYMMDD)</param>
		/// <param name="cellphoneModelCode">�@��R�[�h</param>
		/// <param name="cellphoneModelName">�@�햼��</param>
		/// <param name="carrierCode">�L�����A�R�[�h(1�`899:�񋟕�,900�`:���[�U�[�o�^)</param>
		/// <param name="carrierName">�L�����A����</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="systematicColorCd">�n���F�R�[�h</param>
		/// <param name="systematicColorNm">�n���F����</param>
		/// <param name="largeGoodsGanreCode">���i�敪�O���[�v�R�[�h(���F���i�啪�ރR�[�h)</param>
		/// <param name="mediumGoodsGanreCode">���i�敪�R�[�h(���F���i�����ރR�[�h)</param>
		/// <param name="minimumStockCnt">�Œ�݌ɐ�</param>
		/// <param name="maximumStockCnt">�ō��݌ɐ�</param>
		/// <param name="nmlSalOdrCount">�������</param>
		/// <param name="salOdrLot">�����P��(��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j)</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="largeGoodsGanreName">���i�敪�O���[�v����(���F���i�啪�ޖ���)</param>
		/// <param name="mediumGoodsGanreName">���i�敪����(���F���i�����ޖ���)</param>
		/// <returns>StockEachWarehouse�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockEachWarehouse�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockEachWarehouse(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 GoodsMakerCd,string goodsCode,string goodsName,Int64 stockUnitPrice,Double supplierStock,Double trustCount,Int32 reservedCount,Double allowStockCnt,Double acpOdrCount,Double salesOrderCount,Double entrustCnt,Double trustEntrustCnt,Double soldCnt,Double movingSupliStock,Double movingTrustStock,Double shipmentPosCnt,Int64 stockTotalPrice,Int32 prdNumMngDiv,DateTime lastStockDate,DateTime lastSalesDate,DateTime lastInventoryUpdate,string cellphoneModelCode,string cellphoneModelName,Int32 carrierCode,string carrierName,string makerName,Int32 systematicColorCd,string systematicColorNm,string largeGoodsGanreCode,string mediumGoodsGanreCode,Double minimumStockCnt,Double maximumStockCnt,Double nmlSalOdrCount,Int32 salOdrLot,string warehouseCode,string warehouseName,string enterpriseName,string updEmployeeName,string largeGoodsGanreName,string mediumGoodsGanreName)
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
			this._goodsMakerCd = GoodsMakerCd;
			this._goodsCode = goodsCode;
			this._goodsName = goodsName;
			this._stockUnitPrice = stockUnitPrice;
			this._supplierStock = supplierStock;
			this._trustCount = trustCount;
			this._reservedCount = reservedCount;
			this._allowStockCnt = allowStockCnt;
			this._acpOdrCount = acpOdrCount;
			this._salesOrderCount = salesOrderCount;
			this._entrustCnt = entrustCnt;
			this._trustEntrustCnt = trustEntrustCnt;
			this._soldCnt = soldCnt;
			this._movingSupliStock = movingSupliStock;
			this._movingTrustStock = movingTrustStock;
			this._shipmentPosCnt = shipmentPosCnt;
			this._stockTotalPrice = stockTotalPrice;
			this._prdNumMngDiv = prdNumMngDiv;
			this.LastStockDate = lastStockDate;
			this.LastSalesDate = lastSalesDate;
			this.LastInventoryUpdate = lastInventoryUpdate;
			this._cellphoneModelCode = cellphoneModelCode;
			this._cellphoneModelName = cellphoneModelName;
			this._carrierCode = carrierCode;
			this._carrierName = carrierName;
			this._makerName = makerName;
			this._systematicColorCd = systematicColorCd;
			this._systematicColorNm = systematicColorNm;
			this._largeGoodsGanreCode = largeGoodsGanreCode;
			this._mediumGoodsGanreCode = mediumGoodsGanreCode;
			this._minimumStockCnt = minimumStockCnt;
			this._maximumStockCnt = maximumStockCnt;
			this._nmlSalOdrCount = nmlSalOdrCount;
			this._salOdrLot = salOdrLot;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._largeGoodsGanreName = largeGoodsGanreName;
			this._mediumGoodsGanreName = mediumGoodsGanreName;

		}

		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)��������
		/// </summary>
		/// <returns>StockEachWarehouse�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockEachWarehouse�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockEachWarehouse Clone()
		{
			return new StockEachWarehouse(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._goodsMakerCd,this._goodsCode,this._goodsName,this._stockUnitPrice,this._supplierStock,this._trustCount,this._reservedCount,this._allowStockCnt,this._acpOdrCount,this._salesOrderCount,this._entrustCnt,this._trustEntrustCnt,this._soldCnt,this._movingSupliStock,this._movingTrustStock,this._shipmentPosCnt,this._stockTotalPrice,this._prdNumMngDiv,this._lastStockDate,this._lastSalesDate,this._lastInventoryUpdate,this._cellphoneModelCode,this._cellphoneModelName,this._carrierCode,this._carrierName,this._makerName,this._systematicColorCd,this._systematicColorNm,this._largeGoodsGanreCode,this._mediumGoodsGanreCode,this._minimumStockCnt,this._maximumStockCnt,this._nmlSalOdrCount,this._salOdrLot,this._warehouseCode,this._warehouseName,this._enterpriseName,this._updEmployeeName,this._largeGoodsGanreName,this._mediumGoodsGanreName);
		}

		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockEachWarehouse�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockEachWarehouse�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockEachWarehouse target)
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
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsCode == target.GoodsCode)
				 && (this.GoodsName == target.GoodsName)
				 && (this.StockUnitPrice == target.StockUnitPrice)
				 && (this.SupplierStock == target.SupplierStock)
				 && (this.TrustCount == target.TrustCount)
				 && (this.ReservedCount == target.ReservedCount)
				 && (this.AllowStockCnt == target.AllowStockCnt)
				 && (this.AcpOdrCount == target.AcpOdrCount)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.EntrustCnt == target.EntrustCnt)
				 && (this.TrustEntrustCnt == target.TrustEntrustCnt)
				 && (this.SoldCnt == target.SoldCnt)
				 && (this.MovingSupliStock == target.MovingSupliStock)
				 && (this.MovingTrustStock == target.MovingTrustStock)
				 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
				 && (this.StockTotalPrice == target.StockTotalPrice)
				 && (this.PrdNumMngDiv == target.PrdNumMngDiv)
				 && (this.LastStockDate == target.LastStockDate)
				 && (this.LastSalesDate == target.LastSalesDate)
				 && (this.LastInventoryUpdate == target.LastInventoryUpdate)
				 && (this.CellphoneModelCode == target.CellphoneModelCode)
				 && (this.CellphoneModelName == target.CellphoneModelName)
				 && (this.CarrierCode == target.CarrierCode)
				 && (this.CarrierName == target.CarrierName)
				 && (this.MakerName == target.MakerName)
				 && (this.SystematicColorCd == target.SystematicColorCd)
				 && (this.SystematicColorNm == target.SystematicColorNm)
				 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
				 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
				 && (this.MinimumStockCnt == target.MinimumStockCnt)
				 && (this.MaximumStockCnt == target.MaximumStockCnt)
				 && (this.NmlSalOdrCount == target.NmlSalOdrCount)
				 && (this.SalOdrLot == target.SalOdrLot)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
				 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName));
		}

		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)��r����
		/// </summary>
		/// <param name="stockEachWarehouse1">
		///                    ��r����StockEachWarehouse�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockEachWarehouse2">��r����StockEachWarehouse�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockEachWarehouse�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockEachWarehouse stockEachWarehouse1, StockEachWarehouse stockEachWarehouse2)
		{
			return ((stockEachWarehouse1.CreateDateTime == stockEachWarehouse2.CreateDateTime)
				 && (stockEachWarehouse1.UpdateDateTime == stockEachWarehouse2.UpdateDateTime)
				 && (stockEachWarehouse1.EnterpriseCode == stockEachWarehouse2.EnterpriseCode)
				 && (stockEachWarehouse1.FileHeaderGuid == stockEachWarehouse2.FileHeaderGuid)
				 && (stockEachWarehouse1.UpdEmployeeCode == stockEachWarehouse2.UpdEmployeeCode)
				 && (stockEachWarehouse1.UpdAssemblyId1 == stockEachWarehouse2.UpdAssemblyId1)
				 && (stockEachWarehouse1.UpdAssemblyId2 == stockEachWarehouse2.UpdAssemblyId2)
				 && (stockEachWarehouse1.LogicalDeleteCode == stockEachWarehouse2.LogicalDeleteCode)
				 && (stockEachWarehouse1.SectionCode == stockEachWarehouse2.SectionCode)
				 && (stockEachWarehouse1.GoodsMakerCd == stockEachWarehouse2.GoodsMakerCd)
				 && (stockEachWarehouse1.GoodsCode == stockEachWarehouse2.GoodsCode)
				 && (stockEachWarehouse1.GoodsName == stockEachWarehouse2.GoodsName)
				 && (stockEachWarehouse1.StockUnitPrice == stockEachWarehouse2.StockUnitPrice)
				 && (stockEachWarehouse1.SupplierStock == stockEachWarehouse2.SupplierStock)
				 && (stockEachWarehouse1.TrustCount == stockEachWarehouse2.TrustCount)
				 && (stockEachWarehouse1.ReservedCount == stockEachWarehouse2.ReservedCount)
				 && (stockEachWarehouse1.AllowStockCnt == stockEachWarehouse2.AllowStockCnt)
				 && (stockEachWarehouse1.AcpOdrCount == stockEachWarehouse2.AcpOdrCount)
				 && (stockEachWarehouse1.SalesOrderCount == stockEachWarehouse2.SalesOrderCount)
				 && (stockEachWarehouse1.EntrustCnt == stockEachWarehouse2.EntrustCnt)
				 && (stockEachWarehouse1.TrustEntrustCnt == stockEachWarehouse2.TrustEntrustCnt)
				 && (stockEachWarehouse1.SoldCnt == stockEachWarehouse2.SoldCnt)
				 && (stockEachWarehouse1.MovingSupliStock == stockEachWarehouse2.MovingSupliStock)
				 && (stockEachWarehouse1.MovingTrustStock == stockEachWarehouse2.MovingTrustStock)
				 && (stockEachWarehouse1.ShipmentPosCnt == stockEachWarehouse2.ShipmentPosCnt)
				 && (stockEachWarehouse1.StockTotalPrice == stockEachWarehouse2.StockTotalPrice)
				 && (stockEachWarehouse1.PrdNumMngDiv == stockEachWarehouse2.PrdNumMngDiv)
				 && (stockEachWarehouse1.LastStockDate == stockEachWarehouse2.LastStockDate)
				 && (stockEachWarehouse1.LastSalesDate == stockEachWarehouse2.LastSalesDate)
				 && (stockEachWarehouse1.LastInventoryUpdate == stockEachWarehouse2.LastInventoryUpdate)
				 && (stockEachWarehouse1.CellphoneModelCode == stockEachWarehouse2.CellphoneModelCode)
				 && (stockEachWarehouse1.CellphoneModelName == stockEachWarehouse2.CellphoneModelName)
				 && (stockEachWarehouse1.CarrierCode == stockEachWarehouse2.CarrierCode)
				 && (stockEachWarehouse1.CarrierName == stockEachWarehouse2.CarrierName)
				 && (stockEachWarehouse1.MakerName == stockEachWarehouse2.MakerName)
				 && (stockEachWarehouse1.SystematicColorCd == stockEachWarehouse2.SystematicColorCd)
				 && (stockEachWarehouse1.SystematicColorNm == stockEachWarehouse2.SystematicColorNm)
				 && (stockEachWarehouse1.LargeGoodsGanreCode == stockEachWarehouse2.LargeGoodsGanreCode)
				 && (stockEachWarehouse1.MediumGoodsGanreCode == stockEachWarehouse2.MediumGoodsGanreCode)
				 && (stockEachWarehouse1.MinimumStockCnt == stockEachWarehouse2.MinimumStockCnt)
				 && (stockEachWarehouse1.MaximumStockCnt == stockEachWarehouse2.MaximumStockCnt)
				 && (stockEachWarehouse1.NmlSalOdrCount == stockEachWarehouse2.NmlSalOdrCount)
				 && (stockEachWarehouse1.SalOdrLot == stockEachWarehouse2.SalOdrLot)
				 && (stockEachWarehouse1.WarehouseCode == stockEachWarehouse2.WarehouseCode)
				 && (stockEachWarehouse1.WarehouseName == stockEachWarehouse2.WarehouseName)
				 && (stockEachWarehouse1.EnterpriseName == stockEachWarehouse2.EnterpriseName)
				 && (stockEachWarehouse1.UpdEmployeeName == stockEachWarehouse2.UpdEmployeeName)
				 && (stockEachWarehouse1.LargeGoodsGanreName == stockEachWarehouse2.LargeGoodsGanreName)
				 && (stockEachWarehouse1.MediumGoodsGanreName == stockEachWarehouse2.MediumGoodsGanreName));
		}
		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockEachWarehouse�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockEachWarehouse�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockEachWarehouse target)
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
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsCode != target.GoodsCode)resList.Add("GoodsCode");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.StockUnitPrice != target.StockUnitPrice)resList.Add("StockUnitPrice");
			if(this.SupplierStock != target.SupplierStock)resList.Add("SupplierStock");
			if(this.TrustCount != target.TrustCount)resList.Add("TrustCount");
			if(this.ReservedCount != target.ReservedCount)resList.Add("ReservedCount");
			if(this.AllowStockCnt != target.AllowStockCnt)resList.Add("AllowStockCnt");
			if(this.AcpOdrCount != target.AcpOdrCount)resList.Add("AcpOdrCount");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.EntrustCnt != target.EntrustCnt)resList.Add("EntrustCnt");
			if(this.TrustEntrustCnt != target.TrustEntrustCnt)resList.Add("TrustEntrustCnt");
			if(this.SoldCnt != target.SoldCnt)resList.Add("SoldCnt");
			if(this.MovingSupliStock != target.MovingSupliStock)resList.Add("MovingSupliStock");
			if(this.MovingTrustStock != target.MovingTrustStock)resList.Add("MovingTrustStock");
			if(this.ShipmentPosCnt != target.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(this.StockTotalPrice != target.StockTotalPrice)resList.Add("StockTotalPrice");
			if(this.PrdNumMngDiv != target.PrdNumMngDiv)resList.Add("PrdNumMngDiv");
			if(this.LastStockDate != target.LastStockDate)resList.Add("LastStockDate");
			if(this.LastSalesDate != target.LastSalesDate)resList.Add("LastSalesDate");
			if(this.LastInventoryUpdate != target.LastInventoryUpdate)resList.Add("LastInventoryUpdate");
			if(this.CellphoneModelCode != target.CellphoneModelCode)resList.Add("CellphoneModelCode");
			if(this.CellphoneModelName != target.CellphoneModelName)resList.Add("CellphoneModelName");
			if(this.CarrierCode != target.CarrierCode)resList.Add("CarrierCode");
			if(this.CarrierName != target.CarrierName)resList.Add("CarrierName");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.SystematicColorCd != target.SystematicColorCd)resList.Add("SystematicColorCd");
			if(this.SystematicColorNm != target.SystematicColorNm)resList.Add("SystematicColorNm");
			if(this.LargeGoodsGanreCode != target.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(this.MediumGoodsGanreCode != target.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(this.MinimumStockCnt != target.MinimumStockCnt)resList.Add("MinimumStockCnt");
			if(this.MaximumStockCnt != target.MaximumStockCnt)resList.Add("MaximumStockCnt");
			if(this.NmlSalOdrCount != target.NmlSalOdrCount)resList.Add("NmlSalOdrCount");
			if(this.SalOdrLot != target.SalOdrLot)resList.Add("SalOdrLot");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.LargeGoodsGanreName != target.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(this.MediumGoodsGanreName != target.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");

			return resList;
		}

		/// <summary>
		/// �݌Ƀ}�X�^(�q�ɖ�)��r����
		/// </summary>
		/// <param name="stockEachWarehouse1">��r����StockEachWarehouse�N���X�̃C���X�^���X</param>
		/// <param name="stockEachWarehouse2">��r����StockEachWarehouse�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockEachWarehouse�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockEachWarehouse stockEachWarehouse1, StockEachWarehouse stockEachWarehouse2)
		{
			ArrayList resList = new ArrayList();
			if(stockEachWarehouse1.CreateDateTime != stockEachWarehouse2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockEachWarehouse1.UpdateDateTime != stockEachWarehouse2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockEachWarehouse1.EnterpriseCode != stockEachWarehouse2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockEachWarehouse1.FileHeaderGuid != stockEachWarehouse2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockEachWarehouse1.UpdEmployeeCode != stockEachWarehouse2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockEachWarehouse1.UpdAssemblyId1 != stockEachWarehouse2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockEachWarehouse1.UpdAssemblyId2 != stockEachWarehouse2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockEachWarehouse1.LogicalDeleteCode != stockEachWarehouse2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockEachWarehouse1.SectionCode != stockEachWarehouse2.SectionCode)resList.Add("SectionCode");
			if(stockEachWarehouse1.GoodsMakerCd != stockEachWarehouse2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockEachWarehouse1.GoodsCode != stockEachWarehouse2.GoodsCode)resList.Add("GoodsCode");
			if(stockEachWarehouse1.GoodsName != stockEachWarehouse2.GoodsName)resList.Add("GoodsName");
			if(stockEachWarehouse1.StockUnitPrice != stockEachWarehouse2.StockUnitPrice)resList.Add("StockUnitPrice");
			if(stockEachWarehouse1.SupplierStock != stockEachWarehouse2.SupplierStock)resList.Add("SupplierStock");
			if(stockEachWarehouse1.TrustCount != stockEachWarehouse2.TrustCount)resList.Add("TrustCount");
			if(stockEachWarehouse1.ReservedCount != stockEachWarehouse2.ReservedCount)resList.Add("ReservedCount");
			if(stockEachWarehouse1.AllowStockCnt != stockEachWarehouse2.AllowStockCnt)resList.Add("AllowStockCnt");
			if(stockEachWarehouse1.AcpOdrCount != stockEachWarehouse2.AcpOdrCount)resList.Add("AcpOdrCount");
			if(stockEachWarehouse1.SalesOrderCount != stockEachWarehouse2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(stockEachWarehouse1.EntrustCnt != stockEachWarehouse2.EntrustCnt)resList.Add("EntrustCnt");
			if(stockEachWarehouse1.TrustEntrustCnt != stockEachWarehouse2.TrustEntrustCnt)resList.Add("TrustEntrustCnt");
			if(stockEachWarehouse1.SoldCnt != stockEachWarehouse2.SoldCnt)resList.Add("SoldCnt");
			if(stockEachWarehouse1.MovingSupliStock != stockEachWarehouse2.MovingSupliStock)resList.Add("MovingSupliStock");
			if(stockEachWarehouse1.MovingTrustStock != stockEachWarehouse2.MovingTrustStock)resList.Add("MovingTrustStock");
			if(stockEachWarehouse1.ShipmentPosCnt != stockEachWarehouse2.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(stockEachWarehouse1.StockTotalPrice != stockEachWarehouse2.StockTotalPrice)resList.Add("StockTotalPrice");
			if(stockEachWarehouse1.PrdNumMngDiv != stockEachWarehouse2.PrdNumMngDiv)resList.Add("PrdNumMngDiv");
			if(stockEachWarehouse1.LastStockDate != stockEachWarehouse2.LastStockDate)resList.Add("LastStockDate");
			if(stockEachWarehouse1.LastSalesDate != stockEachWarehouse2.LastSalesDate)resList.Add("LastSalesDate");
			if(stockEachWarehouse1.LastInventoryUpdate != stockEachWarehouse2.LastInventoryUpdate)resList.Add("LastInventoryUpdate");
			if(stockEachWarehouse1.CellphoneModelCode != stockEachWarehouse2.CellphoneModelCode)resList.Add("CellphoneModelCode");
			if(stockEachWarehouse1.CellphoneModelName != stockEachWarehouse2.CellphoneModelName)resList.Add("CellphoneModelName");
			if(stockEachWarehouse1.CarrierCode != stockEachWarehouse2.CarrierCode)resList.Add("CarrierCode");
			if(stockEachWarehouse1.CarrierName != stockEachWarehouse2.CarrierName)resList.Add("CarrierName");
			if(stockEachWarehouse1.MakerName != stockEachWarehouse2.MakerName)resList.Add("MakerName");
			if(stockEachWarehouse1.SystematicColorCd != stockEachWarehouse2.SystematicColorCd)resList.Add("SystematicColorCd");
			if(stockEachWarehouse1.SystematicColorNm != stockEachWarehouse2.SystematicColorNm)resList.Add("SystematicColorNm");
			if(stockEachWarehouse1.LargeGoodsGanreCode != stockEachWarehouse2.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(stockEachWarehouse1.MediumGoodsGanreCode != stockEachWarehouse2.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(stockEachWarehouse1.MinimumStockCnt != stockEachWarehouse2.MinimumStockCnt)resList.Add("MinimumStockCnt");
			if(stockEachWarehouse1.MaximumStockCnt != stockEachWarehouse2.MaximumStockCnt)resList.Add("MaximumStockCnt");
			if(stockEachWarehouse1.NmlSalOdrCount != stockEachWarehouse2.NmlSalOdrCount)resList.Add("NmlSalOdrCount");
			if(stockEachWarehouse1.SalOdrLot != stockEachWarehouse2.SalOdrLot)resList.Add("SalOdrLot");
			if(stockEachWarehouse1.WarehouseCode != stockEachWarehouse2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockEachWarehouse1.WarehouseName != stockEachWarehouse2.WarehouseName)resList.Add("WarehouseName");
			if(stockEachWarehouse1.EnterpriseName != stockEachWarehouse2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockEachWarehouse1.UpdEmployeeName != stockEachWarehouse2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockEachWarehouse1.LargeGoodsGanreName != stockEachWarehouse2.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(stockEachWarehouse1.MediumGoodsGanreName != stockEachWarehouse2.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");

			return resList;
		}
	}
}
*/
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki