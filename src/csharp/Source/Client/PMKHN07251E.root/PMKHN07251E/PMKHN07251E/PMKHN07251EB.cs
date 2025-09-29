//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �݌Ƀ}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Stock
	/// <summary>
	///                      �݌Ƀ}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ƀ}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/19</br>
	/// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/7/8  ����</br>
	/// <br>                 :   �o�׉\���̕⑫�C��</br>
	/// </remarks>
	public class StockSetExp
	{
		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>�d���P���i�Ŕ�,�����j</summary>
		/// <remarks>���݌ɕ]���P��</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>�d���݌ɐ�</summary>
		/// <remarks>��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj</remarks>
		private Double _supplierStock;

		/// <summary>�󒍐�</summary>
		private Double _acpOdrCount;

		/// <summary>M/O������</summary>
		private Double _monthOrderCount;

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�݌ɋ敪</summary>
		/// <remarks>0:����,1:���</remarks>
		private Int32 _stockDiv;

		/// <summary>�ړ����d���݌ɐ�</summary>
		/// <remarks>�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B</remarks>
		private Double _movingSupliStock;

		/// <summary>�o�׉\��</summary>
		/// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
		private Double _shipmentPosCnt;

		/// <summary>�݌ɕۗL���z</summary>
		private Int64 _stockTotalPrice;

		/// <summary>�ŏI�d���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastStockDate;

		/// <summary>�ŏI�����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastSalesDate;

		/// <summary>�ŏI�I���X�V��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _lastInventoryUpdate;

		/// <summary>�Œ�݌ɐ�</summary>
		private Double _minimumStockCnt;

		/// <summary>�ō��݌ɐ�</summary>
		private Double _maximumStockCnt;

		/// <summary>�������</summary>
		private Double _nmlSalOdrCount;

		/// <summary>�����P��</summary>
		/// <remarks>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</remarks>
		private Int32 _salesOrderUnit;

		/// <summary>�݌ɔ�����R�[�h</summary>
		/// <remarks>�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j</remarks>
		private Int32 _stockSupplierCode;

		/// <summary>�n�C�t�������i�ԍ�</summary>
		private string _goodsNoNoneHyphen = "";

		/// <summary>�q�ɒI��</summary>
		private string _warehouseShelfNo = "";

		/// <summary>�d���I�ԂP</summary>
		private string _duplicationShelfNo1 = "";

		/// <summary>�d���I�ԂQ</summary>
		private string _duplicationShelfNo2 = "";

		/// <summary>���i�Ǘ��敪�P</summary>
		private string _partsManagementDivide1 = "";

		/// <summary>���i�Ǘ��敪�Q</summary>
		private string _partsManagementDivide2 = "";

		/// <summary>�d�����l1</summary>
		/// <remarks>�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@</remarks>
		private string _stockNote1 = "";

		/// <summary>�d�����l2</summary>
		private string _stockNote2 = "";

		/// <summary>�o�א��i���v��j</summary>
		/// <remarks>�ݏo�A�o�ׂƓ���</remarks>
		private Double _shipmentCnt;

		/// <summary>���א��i���v��j</summary>
		/// <remarks>����</remarks>
		private Double _arrivalCnt;

		/// <summary>�݌ɓo�^��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _stockCreateDate;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _updateDate;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

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

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
		/// <value>���݌ɕ]���P��</value>
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

		/// public propaty name  :  MonthOrderCount
		/// <summary>M/O�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   M/O�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double MonthOrderCount
		{
			get{return _monthOrderCount;}
			set{_monthOrderCount = value;}
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

		/// public propaty name  :  StockDiv
		/// <summary>�݌ɋ敪�v���p�e�B</summary>
		/// <value>0:����,1:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
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

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>�o�׉\���v���p�e�B</summary>
		/// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
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

		/// public propaty name  :  SalesOrderUnit
		/// <summary>�����P�ʃv���p�e�B</summary>
		/// <value>��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesOrderUnit
		{
			get{return _salesOrderUnit;}
			set{_salesOrderUnit = value;}
		}

		/// public propaty name  :  StockSupplierCode
		/// <summary>�݌ɔ�����R�[�h�v���p�e�B</summary>
		/// <value>�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɔ�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockSupplierCode
		{
			get{return _stockSupplierCode;}
			set{_stockSupplierCode = value;}
		}

		/// public propaty name  :  GoodsNoNoneHyphen
		/// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNoNoneHyphen
		{
			get{return _goodsNoNoneHyphen;}
			set{_goodsNoNoneHyphen = value;}
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

		/// public propaty name  :  DuplicationShelfNo1
		/// <summary>�d���I�ԂP�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���I�ԂP�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DuplicationShelfNo1
		{
			get{return _duplicationShelfNo1;}
			set{_duplicationShelfNo1 = value;}
		}

		/// public propaty name  :  DuplicationShelfNo2
		/// <summary>�d���I�ԂQ�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DuplicationShelfNo2
		{
			get{return _duplicationShelfNo2;}
			set{_duplicationShelfNo2 = value;}
		}

		/// public propaty name  :  PartsManagementDivide1
		/// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartsManagementDivide1
		{
			get{return _partsManagementDivide1;}
			set{_partsManagementDivide1 = value;}
		}

		/// public propaty name  :  PartsManagementDivide2
		/// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartsManagementDivide2
		{
			get{return _partsManagementDivide2;}
			set{_partsManagementDivide2 = value;}
		}

		/// public propaty name  :  StockNote1
		/// <summary>�d�����l1�v���p�e�B</summary>
		/// <value>�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����l1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockNote1
		{
			get{return _stockNote1;}
			set{_stockNote1 = value;}
		}

		/// public propaty name  :  StockNote2
		/// <summary>�d�����l2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����l2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockNote2
		{
			get{return _stockNote2;}
			set{_stockNote2 = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>�o�א��i���v��j�v���p�e�B</summary>
		/// <value>�ݏo�A�o�ׂƓ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�א��i���v��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  ArrivalCnt
		/// <summary>���א��i���v��j�v���p�e�B</summary>
		/// <value>����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���א��i���v��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ArrivalCnt
		{
			get{return _arrivalCnt;}
			set{_arrivalCnt = value;}
		}

		/// public propaty name  :  StockCreateDate
		/// <summary>�݌ɓo�^���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɓo�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCreateDate
		{
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
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
		/// �݌Ƀ}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>Stock�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSetExp()
		{
		}

		/// <summary>
		/// �݌Ƀ}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="stockUnitPriceFl">�d���P���i�Ŕ�,�����j(���݌ɕ]���P��)</param>
		/// <param name="supplierStock">�d���݌ɐ�(��������܂܂Ȃ��݌ɐ��i���Ѝ݌Ɂj)</param>
		/// <param name="acpOdrCount">�󒍐�</param>
		/// <param name="monthOrderCount">M/O������</param>
		/// <param name="salesOrderCount">������</param>
		/// <param name="stockDiv">�݌ɋ敪(0:����,1:���)</param>
		/// <param name="movingSupliStock">�ړ����d���݌ɐ�(�݌Ɉړ���A���ړ��悪���ׂ���O�܂ł̊ԂɗL���l������B)</param>
		/// <param name="shipmentPosCnt">�o�׉\��(�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�)</param>
		/// <param name="stockTotalPrice">�݌ɕۗL���z</param>
		/// <param name="lastStockDate">�ŏI�d���N����(YYYYMMDD)</param>
		/// <param name="lastSalesDate">�ŏI�����(YYYYMMDD)</param>
		/// <param name="lastInventoryUpdate">�ŏI�I���X�V��(YYYYMMDD)</param>
		/// <param name="minimumStockCnt">�Œ�݌ɐ�</param>
		/// <param name="maximumStockCnt">�ō��݌ɐ�</param>
		/// <param name="nmlSalOdrCount">�������</param>
		/// <param name="salesOrderUnit">�����P��(��������P�ʂ̐��ʁi�P�O�A�Q�O�P�ʓ��j)</param>
		/// <param name="stockSupplierCode">�݌ɔ�����R�[�h(�݌ɔ�������ꍇ�̔�����i���i�̔�����Ƃ͕ʊǗ��j)</param>
		/// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
		/// <param name="warehouseShelfNo">�q�ɒI��</param>
		/// <param name="duplicationShelfNo1">�d���I�ԂP</param>
		/// <param name="duplicationShelfNo2">�d���I�ԂQ</param>
		/// <param name="partsManagementDivide1">���i�Ǘ��敪�P</param>
		/// <param name="partsManagementDivide2">���i�Ǘ��敪�Q</param>
		/// <param name="stockNote1">�d�����l1(�����̎d�����킩����e��ݒ肷��@��j�ԗ��d���ł���ΎԎ햼�@)</param>
		/// <param name="stockNote2">�d�����l2</param>
		/// <param name="shipmentCnt">�o�א��i���v��j(�ݏo�A�o�ׂƓ���)</param>
		/// <param name="arrivalCnt">���א��i���v��j(����)</param>
		/// <param name="stockCreateDate">�݌ɓo�^��(YYYYMMDD)</param>
		/// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>Stock�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Stock�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSetExp(string sectionCode,string warehouseCode,Int32 goodsMakerCd,string goodsNo,Double stockUnitPriceFl,Double supplierStock,Double acpOdrCount,Double monthOrderCount,Double salesOrderCount,Int32 stockDiv,Double movingSupliStock,Double shipmentPosCnt,Int64 stockTotalPrice,DateTime lastStockDate,DateTime lastSalesDate,DateTime lastInventoryUpdate,Double minimumStockCnt,Double maximumStockCnt,Double nmlSalOdrCount,Int32 salesOrderUnit,Int32 stockSupplierCode,string goodsNoNoneHyphen,string warehouseShelfNo,string duplicationShelfNo1,string duplicationShelfNo2,string partsManagementDivide1,string partsManagementDivide2,string stockNote1,string stockNote2,Double shipmentCnt,Double arrivalCnt,Int32 stockCreateDate,Int32 updateDate,string enterpriseName,string updEmployeeName)
		{
			this._sectionCode = sectionCode;
			this._warehouseCode = warehouseCode;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsNo = goodsNo;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this._supplierStock = supplierStock;
			this._acpOdrCount = acpOdrCount;
			this._monthOrderCount = monthOrderCount;
			this._salesOrderCount = salesOrderCount;
			this._stockDiv = stockDiv;
			this._movingSupliStock = movingSupliStock;
			this._shipmentPosCnt = shipmentPosCnt;
			this._stockTotalPrice = stockTotalPrice;
			this.LastStockDate = lastStockDate;
			this.LastSalesDate = lastSalesDate;
			this.LastInventoryUpdate = lastInventoryUpdate;
			this._minimumStockCnt = minimumStockCnt;
			this._maximumStockCnt = maximumStockCnt;
			this._nmlSalOdrCount = nmlSalOdrCount;
			this._salesOrderUnit = salesOrderUnit;
			this._stockSupplierCode = stockSupplierCode;
			this._goodsNoNoneHyphen = goodsNoNoneHyphen;
			this._warehouseShelfNo = warehouseShelfNo;
			this._duplicationShelfNo1 = duplicationShelfNo1;
			this._duplicationShelfNo2 = duplicationShelfNo2;
			this._partsManagementDivide1 = partsManagementDivide1;
			this._partsManagementDivide2 = partsManagementDivide2;
			this._stockNote1 = stockNote1;
			this._stockNote2 = stockNote2;
			this._shipmentCnt = shipmentCnt;
			this._arrivalCnt = arrivalCnt;
			this._stockCreateDate = stockCreateDate;
			this._updateDate = updateDate;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// �݌Ƀ}�X�^��������
		/// </summary>
		/// <returns>Stock�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Stock�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public StockSetExp Clone()
		{
            return new StockSetExp(this._sectionCode, this._warehouseCode, this._goodsMakerCd, this._goodsNo, this._stockUnitPriceFl, this._supplierStock, this._acpOdrCount, this._monthOrderCount, this._salesOrderCount, this._stockDiv, this._movingSupliStock, this._shipmentPosCnt, this._stockTotalPrice, this._lastStockDate, this._lastSalesDate, this._lastInventoryUpdate, this._minimumStockCnt, this._maximumStockCnt, this._nmlSalOdrCount, this._salesOrderUnit, this._stockSupplierCode, this._goodsNoNoneHyphen, this._warehouseShelfNo, this._duplicationShelfNo1, this._duplicationShelfNo2, this._partsManagementDivide1, this._partsManagementDivide2, this._stockNote1, this._stockNote2, this._shipmentCnt, this._arrivalCnt, this._stockCreateDate, this._updateDate, this._enterpriseName, this._updEmployeeName);
		}

    }
}
