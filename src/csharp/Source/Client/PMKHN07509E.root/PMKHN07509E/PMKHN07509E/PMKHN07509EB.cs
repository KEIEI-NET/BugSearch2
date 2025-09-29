using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MailDefaultDetail
	/// <summary>
	///                      ���[�������l���׃f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�������l���׃f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2010/5/18</br>
	/// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class MailDefaultDetail
	{
		/// <summary>����s�ԍ�</summary>
		private Int32 _salesRowNo;

		/// <summary>����s�ԍ��}��</summary>
		/// <remarks>�������ς̑Δ�Ŏg�p����</remarks>
		private Int32 _salesRowDerivNo;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>�q��[��(YYYYMMDD)</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>���i����</summary>
		/// <remarks>0:���� 1:�D��</remarks>
		private Int32 _goodsKindCode;

		/// <summary>���i���[�J�[�R�[�h</summary>
		/// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�S�p�j</summary>
		private string _bLGoodsFullName = "";

		/// <summary>���Е��ރR�[�h</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>���Е��ޖ���</summary>
		private string _enterpriseGanreName = "";

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>�q�ɒI��</summary>
		private string _warehouseShelfNo = "";

		/// <summary>����݌Ɏ�񂹋敪</summary>
		/// <remarks>0:��񂹁C1:�݌�</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>�I�[�v�����i�敪</summary>
		/// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
		private Int32 _openPriceDiv;

		/// <summary>�艿��</summary>
		private Double _listPriceRate;

		/// <summary>�艿�i�ō��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _listPriceTaxIncFl;

		/// <summary>�艿�i�Ŕ��C�����j</summary>
		/// <remarks>�ō���</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>������</summary>
		private Double _salesRate;

		/// <summary>����P���i�ō��C�����j</summary>
		private Double _salesUnPrcTaxIncFl;

		/// <summary>����P���i�Ŕ��C�����j</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>�����P��</summary>
		private Double _salesUnitCost;

		/// <summary>BL���i�R�[�h�i����j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
		private Int32 _prtBLGoodsCode;

		/// <summary>BL���i�R�[�h���́i����j</summary>
		/// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
		private string _prtBLGoodsName = "";

		/// <summary>�̔��敪�R�[�h</summary>
		private Int32 _salesCode;

		/// <summary>�̔��敪����</summary>
		private string _salesCdNm = "";

		/// <summary>��ƍH��</summary>
		private Double _workManHour;

		/// <summary>�o�א�</summary>
		private Double _shipmentCnt;

		/// <summary>������z�i�ō��݁j</summary>
		private Int64 _salesMoneyTaxInc;

		/// <summary>������z�i�Ŕ����j</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>����</summary>
		private Int64 _cost;

		/// <summary>���㏤�i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</remarks>
		private Int32 _salesGoodsCd;

		/// <summary>������z����Ŋz</summary>
		/// <remarks>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</remarks>
		private Int64 _salesPriceConsTax;

		/// <summary>�ېŋ敪</summary>
		/// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
		private Int32 _taxationDivCd;

		/// <summary>�����`�[�ԍ��i���ׁj</summary>
		/// <remarks>���Ӑ撍���ԍ��i���`No�j</remarks>
		private string _partySlipNumDtl = "";

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�����ԍ�</summary>
		private string _orderNumber = "";

		/// <summary>�������@</summary>
		/// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</remarks>
		private Int32 _wayToOrder;

		/// <summary>����p�i��</summary>
		private string _prtGoodsNo = "";

		/// <summary>����p���[�J�[�R�[�h</summary>
		private Int32 _prtMakerCode;

		/// <summary>����p���[�J�[����</summary>
		private string _prtMakerName = "";

		/// <summary>�L�����y�[���R�[�h</summary>
		/// <remarks>���_�ƘA���ŃL�[�ƂȂ�̂Œ��Ӂi�Ǘ����_�R�[�h�j</remarks>
		private Int32 _campaignCode;

		/// <summary>�L�����y�[������</summary>
		private string _campaignName = "";

		/// <summary>���i���</summary>
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</remarks>
		private Int32 _goodsDivCd;

		/// <summary>�񓚔[��</summary>
		private string _answerDelivDate = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";


		/// public propaty name  :  SalesRowNo
		/// <summary>����s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesRowNo
		{
			get{return _salesRowNo;}
			set{_salesRowNo = value;}
		}

		/// public propaty name  :  SalesRowDerivNo
		/// <summary>����s�ԍ��}�ԃv���p�e�B</summary>
		/// <value>�������ς̑Δ�Ŏg�p����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����s�ԍ��}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesRowDerivNo
		{
			get{return _salesRowDerivNo;}
			set{_salesRowDerivNo = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>�q��[��(YYYYMMDD)</value>
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
		/// <value>�q��[��(YYYYMMDD)</value>
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
		/// <value>�q��[��(YYYYMMDD)</value>
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
		/// <value>�q��[��(YYYYMMDD)</value>
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
		/// <value>�q��[��(YYYYMMDD)</value>
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

		/// public propaty name  :  GoodsKindCode
		/// <summary>���i�����v���p�e�B</summary>
		/// <value>0:���� 1:�D��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreName
		/// <summary>���Е��ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseGanreName
		{
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
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

		/// public propaty name  :  SalesOrderDivCd
		/// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
		/// <value>0:��񂹁C1:�݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesOrderDivCd
		{
			get{return _salesOrderDivCd;}
			set{_salesOrderDivCd = value;}
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

		/// public propaty name  :  ListPriceRate
		/// <summary>�艿���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceRate
		{
			get{return _listPriceRate;}
			set{_listPriceRate = value;}
		}

		/// public propaty name  :  ListPriceTaxIncFl
		/// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
		/// <value>�Ŕ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceTaxIncFl
		{
			get{return _listPriceTaxIncFl;}
			set{_listPriceTaxIncFl = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
		/// <value>�ō���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  SalesRate
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesRate
		{
			get{return _salesRate;}
			set{_salesRate = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxIncFl
		/// <summary>����P���i�ō��C�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����P���i�ō��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnPrcTaxIncFl
		{
			get{return _salesUnPrcTaxIncFl;}
			set{_salesUnPrcTaxIncFl = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxExcFl
		/// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnPrcTaxExcFl
		{
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
		}

		/// public propaty name  :  SalesUnitCost
		/// <summary>�����P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnitCost
		{
			get{return _salesUnitCost;}
			set{_salesUnitCost = value;}
		}

		/// public propaty name  :  PrtBLGoodsCode
		/// <summary>BL���i�R�[�h�i����j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrtBLGoodsCode
		{
			get{return _prtBLGoodsCode;}
			set{_prtBLGoodsCode = value;}
		}

		/// public propaty name  :  PrtBLGoodsName
		/// <summary>BL���i�R�[�h���́i����j�v���p�e�B</summary>
		/// <value>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtBLGoodsName
		{
			get{return _prtBLGoodsName;}
			set{_prtBLGoodsName = value;}
		}

		/// public propaty name  :  SalesCode
		/// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesCode
		{
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCdNm
		/// <summary>�̔��敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesCdNm
		{
			get{return _salesCdNm;}
			set{_salesCdNm = value;}
		}

		/// public propaty name  :  WorkManHour
		/// <summary>��ƍH���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƍH���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double WorkManHour
		{
			get{return _workManHour;}
			set{_workManHour = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>�o�א��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  SalesMoneyTaxInc
		/// <summary>������z�i�ō��݁j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesMoneyTaxInc
		{
			get{return _salesMoneyTaxInc;}
			set{_salesMoneyTaxInc = value;}
		}

		/// public propaty name  :  SalesMoneyTaxExc
		/// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesMoneyTaxExc
		{
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
		}

		/// public propaty name  :  Cost
		/// <summary>�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 Cost
		{
			get{return _cost;}
			set{_cost = value;}
		}

		/// public propaty name  :  SalesGoodsCd
		/// <summary>���㏤�i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesGoodsCd
		{
			get{return _salesGoodsCd;}
			set{_salesGoodsCd = value;}
		}

		/// public propaty name  :  SalesPriceConsTax
		/// <summary>������z����Ŋz�v���p�e�B</summary>
		/// <value>������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z����Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesPriceConsTax
		{
			get{return _salesPriceConsTax;}
			set{_salesPriceConsTax = value;}
		}

		/// public propaty name  :  TaxationDivCd
		/// <summary>�ېŋ敪�v���p�e�B</summary>
		/// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ېŋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  PartySlipNumDtl
		/// <summary>�����`�[�ԍ��i���ׁj�v���p�e�B</summary>
		/// <value>���Ӑ撍���ԍ��i���`No�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��i���ׁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySlipNumDtl
		{
			get{return _partySlipNumDtl;}
			set{_partySlipNumDtl = value;}
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
			get{return _supplierCd;}
			set{_supplierCd = value;}
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
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>�����ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  WayToOrder
		/// <summary>�������@�v���p�e�B</summary>
		/// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
		}

		/// public propaty name  :  PrtGoodsNo
		/// <summary>����p�i�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p�i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtGoodsNo
		{
			get{return _prtGoodsNo;}
			set{_prtGoodsNo = value;}
		}

		/// public propaty name  :  PrtMakerCode
		/// <summary>����p���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrtMakerCode
		{
			get{return _prtMakerCode;}
			set{_prtMakerCode = value;}
		}

		/// public propaty name  :  PrtMakerName
		/// <summary>����p���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����p���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtMakerName
		{
			get{return _prtMakerName;}
			set{_prtMakerName = value;}
		}

		/// public propaty name  :  CampaignCode
		/// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
		/// <value>���_�ƘA���ŃL�[�ƂȂ�̂Œ��Ӂi�Ǘ����_�R�[�h�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  CampaignName
		/// <summary>�L�����y�[�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CampaignName
		{
			get{return _campaignName;}
			set{_campaignName = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  AnswerDelivDate
		/// <summary>�񓚔[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚔[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerDelivDate
		{
			get{return _answerDelivDate;}
			set{_answerDelivDate = value;}
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


		/// <summary>
		/// ���[�������l���׃f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>MailDefaultDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailDefaultDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailDefaultDetail()
		{
		}

		/// <summary>
		/// ���[�������l���׃f�[�^�R���X�g���N�^
		/// </summary>
		/// <param name="salesRowNo">����s�ԍ�</param>
		/// <param name="salesRowDerivNo">����s�ԍ��}��(�������ς̑Δ�Ŏg�p����)</param>
		/// <param name="deliGdsCmpltDueDate">�[�i�����\���(�q��[��(YYYYMMDD))</param>
		/// <param name="goodsKindCode">���i����(0:���� 1:�D��)</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h(�߯���ޖ���հ�ް�o�^�͈͂��قȂ�)</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
		/// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
		/// <param name="enterpriseGanreName">���Е��ޖ���</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="warehouseName">�q�ɖ���</param>
		/// <param name="warehouseShelfNo">�q�ɒI��</param>
		/// <param name="salesOrderDivCd">����݌Ɏ�񂹋敪(0:��񂹁C1:�݌�)</param>
		/// <param name="openPriceDiv">�I�[�v�����i�敪(0:�ʏ�^1:�I�[�v�����i)</param>
		/// <param name="listPriceRate">�艿��</param>
		/// <param name="listPriceTaxIncFl">�艿�i�ō��C�����j(�Ŕ���)</param>
		/// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�ō���)</param>
		/// <param name="salesRate">������</param>
		/// <param name="salesUnPrcTaxIncFl">����P���i�ō��C�����j</param>
		/// <param name="salesUnPrcTaxExcFl">����P���i�Ŕ��C�����j</param>
		/// <param name="salesUnitCost">�����P��</param>
		/// <param name="prtBLGoodsCode">BL���i�R�[�h�i����j(�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj)</param>
		/// <param name="prtBLGoodsName">BL���i�R�[�h���́i����j(�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj)</param>
		/// <param name="salesCode">�̔��敪�R�[�h</param>
		/// <param name="salesCdNm">�̔��敪����</param>
		/// <param name="workManHour">��ƍH��</param>
		/// <param name="shipmentCnt">�o�א�</param>
		/// <param name="salesMoneyTaxInc">������z�i�ō��݁j</param>
		/// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
		/// <param name="cost">����</param>
		/// <param name="salesGoodsCd">���㏤�i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����))</param>
		/// <param name="salesPriceConsTax">������z����Ŋz(������z�i�ō��݁j- ������z�i�Ŕ����j������Œ����z�����˂�)</param>
		/// <param name="taxationDivCd">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
		/// <param name="partySlipNumDtl">�����`�[�ԍ��i���ׁj(���Ӑ撍���ԍ��i���`No�j)</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="supplierSnm">�d���旪��</param>
		/// <param name="orderNumber">�����ԍ�</param>
		/// <param name="wayToOrder">�������@(0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^)</param>
		/// <param name="prtGoodsNo">����p�i��</param>
		/// <param name="prtMakerCode">����p���[�J�[�R�[�h</param>
		/// <param name="prtMakerName">����p���[�J�[����</param>
		/// <param name="campaignCode">�L�����y�[���R�[�h(���_�ƘA���ŃL�[�ƂȂ�̂Œ��Ӂi�Ǘ����_�R�[�h�j)</param>
		/// <param name="campaignName">�L�����y�[������</param>
		/// <param name="goodsDivCd">���i���(0:�������i 1:�D�Ǖ��i 2:���r���h 3:���� 4:���ϑ���)</param>
		/// <param name="answerDelivDate">�񓚔[��</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <returns>MailDefaultDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailDefaultDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailDefaultDetail(Int32 salesRowNo,Int32 salesRowDerivNo,DateTime deliGdsCmpltDueDate,Int32 goodsKindCode,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,Int32 bLGoodsCode,string bLGoodsFullName,Int32 enterpriseGanreCode,string enterpriseGanreName,string warehouseCode,string warehouseName,string warehouseShelfNo,Int32 salesOrderDivCd,Int32 openPriceDiv,Double listPriceRate,Double listPriceTaxIncFl,Double listPriceTaxExcFl,Double salesRate,Double salesUnPrcTaxIncFl,Double salesUnPrcTaxExcFl,Double salesUnitCost,Int32 prtBLGoodsCode,string prtBLGoodsName,Int32 salesCode,string salesCdNm,Double workManHour,Double shipmentCnt,Int64 salesMoneyTaxInc,Int64 salesMoneyTaxExc,Int64 cost,Int32 salesGoodsCd,Int64 salesPriceConsTax,Int32 taxationDivCd,string partySlipNumDtl,Int32 supplierCd,string supplierSnm,string orderNumber,Int32 wayToOrder,string prtGoodsNo,Int32 prtMakerCode,string prtMakerName,Int32 campaignCode,string campaignName,Int32 goodsDivCd,string answerDelivDate,string bLGoodsName)
		{
			this._salesRowNo = salesRowNo;
			this._salesRowDerivNo = salesRowDerivNo;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._goodsKindCode = goodsKindCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._salesOrderDivCd = salesOrderDivCd;
			this._openPriceDiv = openPriceDiv;
			this._listPriceRate = listPriceRate;
			this._listPriceTaxIncFl = listPriceTaxIncFl;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._salesRate = salesRate;
			this._salesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
			this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			this._salesUnitCost = salesUnitCost;
			this._prtBLGoodsCode = prtBLGoodsCode;
			this._prtBLGoodsName = prtBLGoodsName;
			this._salesCode = salesCode;
			this._salesCdNm = salesCdNm;
			this._workManHour = workManHour;
			this._shipmentCnt = shipmentCnt;
			this._salesMoneyTaxInc = salesMoneyTaxInc;
			this._salesMoneyTaxExc = salesMoneyTaxExc;
			this._cost = cost;
			this._salesGoodsCd = salesGoodsCd;
			this._salesPriceConsTax = salesPriceConsTax;
			this._taxationDivCd = taxationDivCd;
			this._partySlipNumDtl = partySlipNumDtl;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._orderNumber = orderNumber;
			this._wayToOrder = wayToOrder;
			this._prtGoodsNo = prtGoodsNo;
			this._prtMakerCode = prtMakerCode;
			this._prtMakerName = prtMakerName;
			this._campaignCode = campaignCode;
			this._campaignName = campaignName;
			this._goodsDivCd = goodsDivCd;
			this._answerDelivDate = answerDelivDate;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// ���[�������l���׃f�[�^��������
		/// </summary>
		/// <returns>MailDefaultDetail�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MailDefaultDetail�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailDefaultDetail Clone()
		{
			return new MailDefaultDetail(this._salesRowNo,this._salesRowDerivNo,this._deliGdsCmpltDueDate,this._goodsKindCode,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._bLGoodsCode,this._bLGoodsFullName,this._enterpriseGanreCode,this._enterpriseGanreName,this._warehouseCode,this._warehouseName,this._warehouseShelfNo,this._salesOrderDivCd,this._openPriceDiv,this._listPriceRate,this._listPriceTaxIncFl,this._listPriceTaxExcFl,this._salesRate,this._salesUnPrcTaxIncFl,this._salesUnPrcTaxExcFl,this._salesUnitCost,this._prtBLGoodsCode,this._prtBLGoodsName,this._salesCode,this._salesCdNm,this._workManHour,this._shipmentCnt,this._salesMoneyTaxInc,this._salesMoneyTaxExc,this._cost,this._salesGoodsCd,this._salesPriceConsTax,this._taxationDivCd,this._partySlipNumDtl,this._supplierCd,this._supplierSnm,this._orderNumber,this._wayToOrder,this._prtGoodsNo,this._prtMakerCode,this._prtMakerName,this._campaignCode,this._campaignName,this._goodsDivCd,this._answerDelivDate,this._bLGoodsName);
		}

		/// <summary>
		/// ���[�������l���׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MailDefaultDetail�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailDefaultDetail�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(MailDefaultDetail target)
		{
			return ((this.SalesRowNo == target.SalesRowNo)
				 && (this.SalesRowDerivNo == target.SalesRowDerivNo)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.ListPriceRate == target.ListPriceRate)
				 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.SalesRate == target.SalesRate)
				 && (this.SalesUnPrcTaxIncFl == target.SalesUnPrcTaxIncFl)
				 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
				 && (this.SalesUnitCost == target.SalesUnitCost)
				 && (this.PrtBLGoodsCode == target.PrtBLGoodsCode)
				 && (this.PrtBLGoodsName == target.PrtBLGoodsName)
				 && (this.SalesCode == target.SalesCode)
				 && (this.SalesCdNm == target.SalesCdNm)
				 && (this.WorkManHour == target.WorkManHour)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.SalesMoneyTaxInc == target.SalesMoneyTaxInc)
				 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
				 && (this.Cost == target.Cost)
				 && (this.SalesGoodsCd == target.SalesGoodsCd)
				 && (this.SalesPriceConsTax == target.SalesPriceConsTax)
				 && (this.TaxationDivCd == target.TaxationDivCd)
				 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.OrderNumber == target.OrderNumber)
				 && (this.WayToOrder == target.WayToOrder)
				 && (this.PrtGoodsNo == target.PrtGoodsNo)
				 && (this.PrtMakerCode == target.PrtMakerCode)
				 && (this.PrtMakerName == target.PrtMakerName)
				 && (this.CampaignCode == target.CampaignCode)
				 && (this.CampaignName == target.CampaignName)
				 && (this.GoodsDivCd == target.GoodsDivCd)
				 && (this.AnswerDelivDate == target.AnswerDelivDate)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// ���[�������l���׃f�[�^��r����
		/// </summary>
		/// <param name="mailDefaultDetail1">
		///                    ��r����MailDefaultDetail�N���X�̃C���X�^���X
		/// </param>
		/// <param name="mailDefaultDetail2">��r����MailDefaultDetail�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailDefaultDetail�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(MailDefaultDetail mailDefaultDetail1, MailDefaultDetail mailDefaultDetail2)
		{
			return ((mailDefaultDetail1.SalesRowNo == mailDefaultDetail2.SalesRowNo)
				 && (mailDefaultDetail1.SalesRowDerivNo == mailDefaultDetail2.SalesRowDerivNo)
				 && (mailDefaultDetail1.DeliGdsCmpltDueDate == mailDefaultDetail2.DeliGdsCmpltDueDate)
				 && (mailDefaultDetail1.GoodsKindCode == mailDefaultDetail2.GoodsKindCode)
				 && (mailDefaultDetail1.GoodsMakerCd == mailDefaultDetail2.GoodsMakerCd)
				 && (mailDefaultDetail1.MakerName == mailDefaultDetail2.MakerName)
				 && (mailDefaultDetail1.GoodsNo == mailDefaultDetail2.GoodsNo)
				 && (mailDefaultDetail1.GoodsName == mailDefaultDetail2.GoodsName)
				 && (mailDefaultDetail1.BLGoodsCode == mailDefaultDetail2.BLGoodsCode)
				 && (mailDefaultDetail1.BLGoodsFullName == mailDefaultDetail2.BLGoodsFullName)
				 && (mailDefaultDetail1.EnterpriseGanreCode == mailDefaultDetail2.EnterpriseGanreCode)
				 && (mailDefaultDetail1.EnterpriseGanreName == mailDefaultDetail2.EnterpriseGanreName)
				 && (mailDefaultDetail1.WarehouseCode == mailDefaultDetail2.WarehouseCode)
				 && (mailDefaultDetail1.WarehouseName == mailDefaultDetail2.WarehouseName)
				 && (mailDefaultDetail1.WarehouseShelfNo == mailDefaultDetail2.WarehouseShelfNo)
				 && (mailDefaultDetail1.SalesOrderDivCd == mailDefaultDetail2.SalesOrderDivCd)
				 && (mailDefaultDetail1.OpenPriceDiv == mailDefaultDetail2.OpenPriceDiv)
				 && (mailDefaultDetail1.ListPriceRate == mailDefaultDetail2.ListPriceRate)
				 && (mailDefaultDetail1.ListPriceTaxIncFl == mailDefaultDetail2.ListPriceTaxIncFl)
				 && (mailDefaultDetail1.ListPriceTaxExcFl == mailDefaultDetail2.ListPriceTaxExcFl)
				 && (mailDefaultDetail1.SalesRate == mailDefaultDetail2.SalesRate)
				 && (mailDefaultDetail1.SalesUnPrcTaxIncFl == mailDefaultDetail2.SalesUnPrcTaxIncFl)
				 && (mailDefaultDetail1.SalesUnPrcTaxExcFl == mailDefaultDetail2.SalesUnPrcTaxExcFl)
				 && (mailDefaultDetail1.SalesUnitCost == mailDefaultDetail2.SalesUnitCost)
				 && (mailDefaultDetail1.PrtBLGoodsCode == mailDefaultDetail2.PrtBLGoodsCode)
				 && (mailDefaultDetail1.PrtBLGoodsName == mailDefaultDetail2.PrtBLGoodsName)
				 && (mailDefaultDetail1.SalesCode == mailDefaultDetail2.SalesCode)
				 && (mailDefaultDetail1.SalesCdNm == mailDefaultDetail2.SalesCdNm)
				 && (mailDefaultDetail1.WorkManHour == mailDefaultDetail2.WorkManHour)
				 && (mailDefaultDetail1.ShipmentCnt == mailDefaultDetail2.ShipmentCnt)
				 && (mailDefaultDetail1.SalesMoneyTaxInc == mailDefaultDetail2.SalesMoneyTaxInc)
				 && (mailDefaultDetail1.SalesMoneyTaxExc == mailDefaultDetail2.SalesMoneyTaxExc)
				 && (mailDefaultDetail1.Cost == mailDefaultDetail2.Cost)
				 && (mailDefaultDetail1.SalesGoodsCd == mailDefaultDetail2.SalesGoodsCd)
				 && (mailDefaultDetail1.SalesPriceConsTax == mailDefaultDetail2.SalesPriceConsTax)
				 && (mailDefaultDetail1.TaxationDivCd == mailDefaultDetail2.TaxationDivCd)
				 && (mailDefaultDetail1.PartySlipNumDtl == mailDefaultDetail2.PartySlipNumDtl)
				 && (mailDefaultDetail1.SupplierCd == mailDefaultDetail2.SupplierCd)
				 && (mailDefaultDetail1.SupplierSnm == mailDefaultDetail2.SupplierSnm)
				 && (mailDefaultDetail1.OrderNumber == mailDefaultDetail2.OrderNumber)
				 && (mailDefaultDetail1.WayToOrder == mailDefaultDetail2.WayToOrder)
				 && (mailDefaultDetail1.PrtGoodsNo == mailDefaultDetail2.PrtGoodsNo)
				 && (mailDefaultDetail1.PrtMakerCode == mailDefaultDetail2.PrtMakerCode)
				 && (mailDefaultDetail1.PrtMakerName == mailDefaultDetail2.PrtMakerName)
				 && (mailDefaultDetail1.CampaignCode == mailDefaultDetail2.CampaignCode)
				 && (mailDefaultDetail1.CampaignName == mailDefaultDetail2.CampaignName)
				 && (mailDefaultDetail1.GoodsDivCd == mailDefaultDetail2.GoodsDivCd)
				 && (mailDefaultDetail1.AnswerDelivDate == mailDefaultDetail2.AnswerDelivDate)
				 && (mailDefaultDetail1.BLGoodsName == mailDefaultDetail2.BLGoodsName));
		}
		/// <summary>
		/// ���[�������l���׃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MailDefaultDetail�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailDefaultDetail�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(MailDefaultDetail target)
		{
			ArrayList resList = new ArrayList();
			if(this.SalesRowNo != target.SalesRowNo)resList.Add("SalesRowNo");
			if(this.SalesRowDerivNo != target.SalesRowDerivNo)resList.Add("SalesRowDerivNo");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.SalesOrderDivCd != target.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.ListPriceRate != target.ListPriceRate)resList.Add("ListPriceRate");
			if(this.ListPriceTaxIncFl != target.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.SalesRate != target.SalesRate)resList.Add("SalesRate");
			if(this.SalesUnPrcTaxIncFl != target.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(this.SalesUnitCost != target.SalesUnitCost)resList.Add("SalesUnitCost");
			if(this.PrtBLGoodsCode != target.PrtBLGoodsCode)resList.Add("PrtBLGoodsCode");
			if(this.PrtBLGoodsName != target.PrtBLGoodsName)resList.Add("PrtBLGoodsName");
			if(this.SalesCode != target.SalesCode)resList.Add("SalesCode");
			if(this.SalesCdNm != target.SalesCdNm)resList.Add("SalesCdNm");
			if(this.WorkManHour != target.WorkManHour)resList.Add("WorkManHour");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.SalesMoneyTaxInc != target.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(this.SalesMoneyTaxExc != target.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(this.Cost != target.Cost)resList.Add("Cost");
			if(this.SalesGoodsCd != target.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(this.SalesPriceConsTax != target.SalesPriceConsTax)resList.Add("SalesPriceConsTax");
			if(this.TaxationDivCd != target.TaxationDivCd)resList.Add("TaxationDivCd");
			if(this.PartySlipNumDtl != target.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.OrderNumber != target.OrderNumber)resList.Add("OrderNumber");
			if(this.WayToOrder != target.WayToOrder)resList.Add("WayToOrder");
			if(this.PrtGoodsNo != target.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(this.PrtMakerCode != target.PrtMakerCode)resList.Add("PrtMakerCode");
			if(this.PrtMakerName != target.PrtMakerName)resList.Add("PrtMakerName");
			if(this.CampaignCode != target.CampaignCode)resList.Add("CampaignCode");
			if(this.CampaignName != target.CampaignName)resList.Add("CampaignName");
			if(this.GoodsDivCd != target.GoodsDivCd)resList.Add("GoodsDivCd");
			if(this.AnswerDelivDate != target.AnswerDelivDate)resList.Add("AnswerDelivDate");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// ���[�������l���׃f�[�^��r����
		/// </summary>
		/// <param name="mailDefaultDetail1">��r����MailDefaultDetail�N���X�̃C���X�^���X</param>
		/// <param name="mailDefaultDetail2">��r����MailDefaultDetail�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailDefaultDetail�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(MailDefaultDetail mailDefaultDetail1, MailDefaultDetail mailDefaultDetail2)
		{
			ArrayList resList = new ArrayList();
			if(mailDefaultDetail1.SalesRowNo != mailDefaultDetail2.SalesRowNo)resList.Add("SalesRowNo");
			if(mailDefaultDetail1.SalesRowDerivNo != mailDefaultDetail2.SalesRowDerivNo)resList.Add("SalesRowDerivNo");
			if(mailDefaultDetail1.DeliGdsCmpltDueDate != mailDefaultDetail2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(mailDefaultDetail1.GoodsKindCode != mailDefaultDetail2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(mailDefaultDetail1.GoodsMakerCd != mailDefaultDetail2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(mailDefaultDetail1.MakerName != mailDefaultDetail2.MakerName)resList.Add("MakerName");
			if(mailDefaultDetail1.GoodsNo != mailDefaultDetail2.GoodsNo)resList.Add("GoodsNo");
			if(mailDefaultDetail1.GoodsName != mailDefaultDetail2.GoodsName)resList.Add("GoodsName");
			if(mailDefaultDetail1.BLGoodsCode != mailDefaultDetail2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(mailDefaultDetail1.BLGoodsFullName != mailDefaultDetail2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(mailDefaultDetail1.EnterpriseGanreCode != mailDefaultDetail2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(mailDefaultDetail1.EnterpriseGanreName != mailDefaultDetail2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(mailDefaultDetail1.WarehouseCode != mailDefaultDetail2.WarehouseCode)resList.Add("WarehouseCode");
			if(mailDefaultDetail1.WarehouseName != mailDefaultDetail2.WarehouseName)resList.Add("WarehouseName");
			if(mailDefaultDetail1.WarehouseShelfNo != mailDefaultDetail2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(mailDefaultDetail1.SalesOrderDivCd != mailDefaultDetail2.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(mailDefaultDetail1.OpenPriceDiv != mailDefaultDetail2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(mailDefaultDetail1.ListPriceRate != mailDefaultDetail2.ListPriceRate)resList.Add("ListPriceRate");
			if(mailDefaultDetail1.ListPriceTaxIncFl != mailDefaultDetail2.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(mailDefaultDetail1.ListPriceTaxExcFl != mailDefaultDetail2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(mailDefaultDetail1.SalesRate != mailDefaultDetail2.SalesRate)resList.Add("SalesRate");
			if(mailDefaultDetail1.SalesUnPrcTaxIncFl != mailDefaultDetail2.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(mailDefaultDetail1.SalesUnPrcTaxExcFl != mailDefaultDetail2.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(mailDefaultDetail1.SalesUnitCost != mailDefaultDetail2.SalesUnitCost)resList.Add("SalesUnitCost");
			if(mailDefaultDetail1.PrtBLGoodsCode != mailDefaultDetail2.PrtBLGoodsCode)resList.Add("PrtBLGoodsCode");
			if(mailDefaultDetail1.PrtBLGoodsName != mailDefaultDetail2.PrtBLGoodsName)resList.Add("PrtBLGoodsName");
			if(mailDefaultDetail1.SalesCode != mailDefaultDetail2.SalesCode)resList.Add("SalesCode");
			if(mailDefaultDetail1.SalesCdNm != mailDefaultDetail2.SalesCdNm)resList.Add("SalesCdNm");
			if(mailDefaultDetail1.WorkManHour != mailDefaultDetail2.WorkManHour)resList.Add("WorkManHour");
			if(mailDefaultDetail1.ShipmentCnt != mailDefaultDetail2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(mailDefaultDetail1.SalesMoneyTaxInc != mailDefaultDetail2.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(mailDefaultDetail1.SalesMoneyTaxExc != mailDefaultDetail2.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(mailDefaultDetail1.Cost != mailDefaultDetail2.Cost)resList.Add("Cost");
			if(mailDefaultDetail1.SalesGoodsCd != mailDefaultDetail2.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(mailDefaultDetail1.SalesPriceConsTax != mailDefaultDetail2.SalesPriceConsTax)resList.Add("SalesPriceConsTax");
			if(mailDefaultDetail1.TaxationDivCd != mailDefaultDetail2.TaxationDivCd)resList.Add("TaxationDivCd");
			if(mailDefaultDetail1.PartySlipNumDtl != mailDefaultDetail2.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(mailDefaultDetail1.SupplierCd != mailDefaultDetail2.SupplierCd)resList.Add("SupplierCd");
			if(mailDefaultDetail1.SupplierSnm != mailDefaultDetail2.SupplierSnm)resList.Add("SupplierSnm");
			if(mailDefaultDetail1.OrderNumber != mailDefaultDetail2.OrderNumber)resList.Add("OrderNumber");
			if(mailDefaultDetail1.WayToOrder != mailDefaultDetail2.WayToOrder)resList.Add("WayToOrder");
			if(mailDefaultDetail1.PrtGoodsNo != mailDefaultDetail2.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(mailDefaultDetail1.PrtMakerCode != mailDefaultDetail2.PrtMakerCode)resList.Add("PrtMakerCode");
			if(mailDefaultDetail1.PrtMakerName != mailDefaultDetail2.PrtMakerName)resList.Add("PrtMakerName");
			if(mailDefaultDetail1.CampaignCode != mailDefaultDetail2.CampaignCode)resList.Add("CampaignCode");
			if(mailDefaultDetail1.CampaignName != mailDefaultDetail2.CampaignName)resList.Add("CampaignName");
			if(mailDefaultDetail1.GoodsDivCd != mailDefaultDetail2.GoodsDivCd)resList.Add("GoodsDivCd");
			if(mailDefaultDetail1.AnswerDelivDate != mailDefaultDetail2.AnswerDelivDate)resList.Add("AnswerDelivDate");
			if(mailDefaultDetail1.BLGoodsName != mailDefaultDetail2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}
	}
}
