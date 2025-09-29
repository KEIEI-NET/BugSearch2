using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

/// public class name:   StockSalesResultInfoWork
	/// <summary>
	///                      �d��������ѕ\���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d��������ѕ\���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2009/06/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSalesResultInfoWork 
	{
		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���͓�</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
		private Int32 _inputDay;

		/// <summary>�d����</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _stockDate;

		/// <summary>���_�K�C�h����</summary>
		/// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
		private string _sectionGuideNm = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ於��</summary>
		private string _customerName = "";

		/// <summary>������t</summary>
		/// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
		private Int32 _salesDate;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>�d���S���Җ���</summary>
		/// <remarks>�����҂��Z�b�g</remarks>
		private string _stockAgentName = "";

		/// <summary>��t�]�ƈ�����</summary>
		private string _frontEmployeeNm = "";

		/// <summary>������͎Җ���</summary>
		private string _salesInputName = "";

		/// <summary>�t�n�d���}�[�N�P</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>�t�n�d���}�[�N�Q</summary>
		private string _uoeRemark2 = "";

		/// <summary>�`�[���l</summary>
		private string _slipNote = "";

		/// <summary>�`�[���l�Q</summary>
		private string _slipNote2 = "";

		/// <summary>�`�[���l�R</summary>
		private string _slipNote3 = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>�d���݌Ɏ�񂹋敪</summary>
		/// <remarks>0:���,1:�݌�</remarks>
		private Int32 _stockOrderDivCd;

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>�艿�i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>�d����</summary>
		private Double _stockCount;

		/// <summary>����P���i�Ŕ��C�����j</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>������z�i�Ŕ����j</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>�d�����z�i�Ŕ����j</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>�d���P���i�Ŕ��C�����j</summary>
		/// <remarks>�Ŕ���</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�����`�[�ԍ�</summary>
		/// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>�d���`�[�敪�i���ׁj</summary>
		/// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
		private Int32 _stockSlipCdDtl;

		/// <summary>����`�[�敪�i���ׁj</summary>
		/// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>�d���`�[���l1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>�d���`�[�ԍ�</summary>
		/// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>�d���`�[�敪</summary>
		/// <remarks>10:�d��,20:�ԕi</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>����`�[�敪</summary>
		/// <remarks>0:����,1:�ԕi</remarks>
		private Int32 _salesSlipCd;

		/// <summary>����`�[���v�i�Ŕ����j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
		private Int64 _salesTotalTaxExc;

		/// <summary>����l�����z�v�i�Ŕ����j</summary>
		/// <remarks>����l���O�őΏۊz���v+����l�����őΏۊz���v</remarks>
		private Int64 _salesDisTtlTaxExc;

		/// <summary>����`�[���v�i�ō��݁j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>����l������Ŋz�i�O�Łj</summary>
		/// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
		private Int64 _salesDisOutTax;

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>�d�����z�v�i�ō��݁j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>�d�����z�v�i�Ŕ����j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>�d���l�����z�v�i�Ŕ����j</summary>
		/// <remarks>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</remarks>
		private Int64 _stckDisTtlTaxExc;

		/// <summary>�o�א�</summary>
		private Double _shipmentCnt;

		/// <summary>�d���s�ԍ�</summary>
		private Int32 _stockRowNo;

		/// <summary>�d�����i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</remarks>
		private Int32 _stockGoodsCd;


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

		/// public propaty name  :  InputDay
		/// <summary>���͓��v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>�d�����v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 StockDate
		{
			get{return _stockDate;}
			set{_stockDate = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
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

		/// public propaty name  :  CustomerName
		/// <summary>���Ӑ於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  SalesDate
		/// <summary>������t�v���p�e�B</summary>
		/// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesDate
		{
			get{return _salesDate;}
			set{_salesDate = value;}
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
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>�d���S���Җ��̃v���p�e�B</summary>
		/// <value>�����҂��Z�b�g</value>
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

		/// public propaty name  :  FrontEmployeeNm
		/// <summary>��t�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrontEmployeeNm
		{
			get{return _frontEmployeeNm;}
			set{_frontEmployeeNm = value;}
		}

		/// public propaty name  :  SalesInputName
		/// <summary>������͎Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������͎Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesInputName
		{
			get{return _salesInputName;}
			set{_salesInputName = value;}
		}

		/// public propaty name  :  UoeRemark1
		/// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
		/// <value>UserOrderEntory</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UoeRemark1
		{
			get{return _uoeRemark1;}
			set{_uoeRemark1 = value;}
		}

		/// public propaty name  :  UoeRemark2
		/// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UoeRemark2
		{
			get{return _uoeRemark2;}
			set{_uoeRemark2 = value;}
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

		/// public propaty name  :  SlipNote2
		/// <summary>�`�[���l�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���l�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipNote2
		{
			get{return _slipNote2;}
			set{_slipNote2 = value;}
		}

		/// public propaty name  :  SlipNote3
		/// <summary>�`�[���l�R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���l�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipNote3
		{
			get{return _slipNote3;}
			set{_slipNote3 = value;}
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

		/// public propaty name  :  StockOrderDivCd
		/// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
		/// <value>0:���,1:�݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockOrderDivCd
		{
			get{return _stockOrderDivCd;}
			set{_stockOrderDivCd = value;}
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

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
		/// <value>�Ŕ���</value>
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

		/// public propaty name  :  StockCount
		/// <summary>�d�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockCount
		{
			get{return _stockCount;}
			set{_stockCount = value;}
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

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
		/// <value>�Ŕ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
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

		/// public propaty name  :  PartySaleSlipNum
		/// <summary>�����`�[�ԍ��v���p�e�B</summary>
		/// <value>�d����`�[�ԍ��Ɏg�p����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartySaleSlipNum
		{
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
		}

		/// public propaty name  :  StockSlipCdDtl
		/// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
		/// <value>0:�d��,1:�ԕi,2:�l��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockSlipCdDtl
		{
			get{return _stockSlipCdDtl;}
			set{_stockSlipCdDtl = value;}
		}

		/// public propaty name  :  SalesSlipCdDtl
		/// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCdDtl
		{
			get{return _salesSlipCdDtl;}
			set{_salesSlipCdDtl = value;}
		}

		/// public propaty name  :  SupplierSlipNote1
		/// <summary>�d���`�[���l1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[���l1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSlipNote1
		{
			get{return _supplierSlipNote1;}
			set{_supplierSlipNote1 = value;}
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>�d���`�[�ԍ��v���p�e�B</summary>
		/// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get{return _supplierSlipNo;}
			set{_supplierSlipNo = value;}
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>�d���`�[�敪�v���p�e�B</summary>
		/// <value>10:�d��,20:�ԕi</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
		}

		/// public propaty name  :  SalesSlipCd
		/// <summary>����`�[�敪�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
		}

		/// public propaty name  :  SalesTotalTaxExc
		/// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
		/// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTotalTaxExc
		{
			get{return _salesTotalTaxExc;}
			set{_salesTotalTaxExc = value;}
		}

		/// public propaty name  :  SalesDisTtlTaxExc
		/// <summary>����l�����z�v�i�Ŕ����j�v���p�e�B</summary>
		/// <value>����l���O�őΏۊz���v+����l�����őΏۊz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l�����z�v�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesDisTtlTaxExc
		{
			get{return _salesDisTtlTaxExc;}
			set{_salesDisTtlTaxExc = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
		/// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  SalesDisOutTax
		/// <summary>����l������Ŋz�i�O�Łj�v���p�e�B</summary>
		/// <value>�O�ŏ��i�l���̏���Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����l������Ŋz�i�O�Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesDisOutTax
		{
			get{return _salesDisOutTax;}
			set{_salesDisOutTax = value;}
		}

		/// public propaty name  :  StockSubttlPrice
		/// <summary>�d�����z���v�v���p�e�B</summary>
		/// <value>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</value>
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

		/// public propaty name  :  StockTtlPricTaxInc
		/// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
		/// <value>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtlPricTaxInc
		{
			get{return _stockTtlPricTaxInc;}
			set{_stockTtlPricTaxInc = value;}
		}

		/// public propaty name  :  StockTtlPricTaxExc
		/// <summary>�d�����z�v�i�Ŕ����j�v���p�e�B</summary>
		/// <value>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z�v�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTtlPricTaxExc
		{
			get{return _stockTtlPricTaxExc;}
			set{_stockTtlPricTaxExc = value;}
		}

		/// public propaty name  :  StckDisTtlTaxExc
		/// <summary>�d���l�����z�v�i�Ŕ����j�v���p�e�B</summary>
		/// <value>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���l�����z�v�i�Ŕ����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StckDisTtlTaxExc
		{
			get{return _stckDisTtlTaxExc;}
			set{_stckDisTtlTaxExc = value;}
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

		/// public propaty name  :  StockRowNo
		/// <summary>�d���s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockRowNo
		{
			get{return _stockRowNo;}
			set{_stockRowNo = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>�d�����i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockGoodsCd
		{
			get{return _stockGoodsCd;}
			set{_stockGoodsCd = value;}
		}


		/// <summary>
		/// �d��������ѕ\���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockSalesResultInfoWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSalesResultInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSalesResultInfoWork()
		{
		}

	}

    /// <summary>
///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
/// </summary>
/// <returns>StockSalesResultInfoWork�N���X�̃C���X�^���X(object)</returns>
/// <remarks>
/// <br>Note�@�@�@�@�@�@ :   StockSalesResultInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
/// <br>Programer        :   ��������</br>
/// </remarks>
public class StockSalesResultInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
	#region ICustomSerializationSurrogate �����o
	
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	/// </summary>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   StockSalesResultInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  StockSalesResultInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is StockSalesResultInfoWork || graph is ArrayList || graph is StockSalesResultInfoWork[]) )
			throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockSalesResultInfoWork).FullName ) );

		if( graph != null && graph is StockSalesResultInfoWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSalesResultInfoWork" );

		//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is StockSalesResultInfoWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((StockSalesResultInfoWork[])graph).Length;
		}
		else if( graph is StockSalesResultInfoWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		//���_�R�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
		//���͓�
		serInfo.MemberInfo.Add( typeof(Int32) ); //InputDay
		//�d����
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockDate
		//���_�K�C�h����
		serInfo.MemberInfo.Add( typeof(string) ); //SectionGuideNm
		//���Ӑ�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		//���Ӑ於��
		serInfo.MemberInfo.Add( typeof(string) ); //CustomerName
		//������t
		serInfo.MemberInfo.Add( typeof(Int32) ); //SalesDate
		//����`�[�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //SalesSlipNum
		//�d���S���Җ���
		serInfo.MemberInfo.Add( typeof(string) ); //StockAgentName
		//��t�]�ƈ�����
		serInfo.MemberInfo.Add( typeof(string) ); //FrontEmployeeNm
		//������͎Җ���
		serInfo.MemberInfo.Add( typeof(string) ); //SalesInputName
		//�t�n�d���}�[�N�P
		serInfo.MemberInfo.Add( typeof(string) ); //UoeRemark1
		//�t�n�d���}�[�N�Q
		serInfo.MemberInfo.Add( typeof(string) ); //UoeRemark2
		//�`�[���l
		serInfo.MemberInfo.Add( typeof(string) ); //SlipNote
		//�`�[���l�Q
		serInfo.MemberInfo.Add( typeof(string) ); //SlipNote2
		//�`�[���l�R
		serInfo.MemberInfo.Add( typeof(string) ); //SlipNote3
		//���i�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsNo
		//�d���݌Ɏ�񂹋敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockOrderDivCd
		//���i����
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsName
		//�艿�i�Ŕ��C�����j
		serInfo.MemberInfo.Add( typeof(Double) ); //ListPriceTaxExcFl
		//�d����
		serInfo.MemberInfo.Add( typeof(Double) ); //StockCount
		//����P���i�Ŕ��C�����j
		serInfo.MemberInfo.Add( typeof(Double) ); //SalesUnPrcTaxExcFl
		//������z�i�Ŕ����j
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesMoneyTaxExc
		//�d�����z�i�Ŕ����j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockPriceTaxExc
		//�d���P���i�Ŕ��C�����j
		serInfo.MemberInfo.Add( typeof(Double) ); //StockUnitPriceFl
		//�d����R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierCd
		//�����`�[�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //PartySaleSlipNum
		//�d���`�[�敪�i���ׁj
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockSlipCdDtl
		//����`�[�敪�i���ׁj
		serInfo.MemberInfo.Add( typeof(Int32) ); //SalesSlipCdDtl
		//�d���`�[���l1
		serInfo.MemberInfo.Add( typeof(string) ); //SupplierSlipNote1
		//�d���`�[�ԍ�
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierSlipNo
		//�d���`�[�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //SupplierSlipCd
		//����`�[�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //SalesSlipCd
		//����`�[���v�i�Ŕ����j
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesTotalTaxExc
		//����l�����z�v�i�Ŕ����j
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesDisTtlTaxExc
		//����`�[���v�i�ō��݁j
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesTotalTaxInc
		//����l������Ŋz�i�O�Łj
		serInfo.MemberInfo.Add( typeof(Int64) ); //SalesDisOutTax
		//�d�����z���v
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockSubttlPrice
		//�d�����z�v�i�ō��݁j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtlPricTaxInc
		//�d�����z�v�i�Ŕ����j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StockTtlPricTaxExc
		//�d���l�����z�v�i�Ŕ����j
		serInfo.MemberInfo.Add( typeof(Int64) ); //StckDisTtlTaxExc
		//�o�א�
		serInfo.MemberInfo.Add( typeof(Double) ); //ShipmentCnt
		//�d���s�ԍ�
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockRowNo
		//�d�����i�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //StockGoodsCd

			
		serInfo.Serialize( writer, serInfo );
		if( graph is StockSalesResultInfoWork )
		{
			StockSalesResultInfoWork temp = (StockSalesResultInfoWork)graph;

			SetStockSalesResultInfoWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is StockSalesResultInfoWork[])
			{
				lst = new ArrayList();
				lst.AddRange((StockSalesResultInfoWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(StockSalesResultInfoWork temp in lst)
			{
				SetStockSalesResultInfoWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// StockSalesResultInfoWork�����o��(public�v���p�e�B��)
	/// </summary>
	private const int currentMemberCount = 44;
		
	/// <summary>
	///  StockSalesResultInfoWork�C���X�^���X��������
	/// </summary>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   StockSalesResultInfoWork�̃C���X�^���X����������</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	private void SetStockSalesResultInfoWork( System.IO.BinaryWriter writer, StockSalesResultInfoWork temp )
	{
		//���_�R�[�h
		writer.Write( temp.SectionCode );
		//���͓�
		writer.Write( temp.InputDay );
		//�d����
		writer.Write( temp.StockDate);
		//���_�K�C�h����
		writer.Write( temp.SectionGuideNm );
		//���Ӑ�R�[�h
		writer.Write( temp.CustomerCode );
		//���Ӑ於��
		writer.Write( temp.CustomerName );
		//������t
		writer.Write( temp.SalesDate );
		//����`�[�ԍ�
		writer.Write( temp.SalesSlipNum );
		//�d���S���Җ���
		writer.Write( temp.StockAgentName );
		//��t�]�ƈ�����
		writer.Write( temp.FrontEmployeeNm );
		//������͎Җ���
		writer.Write( temp.SalesInputName );
		//�t�n�d���}�[�N�P
		writer.Write( temp.UoeRemark1 );
		//�t�n�d���}�[�N�Q
		writer.Write( temp.UoeRemark2 );
		//�`�[���l
		writer.Write( temp.SlipNote );
		//�`�[���l�Q
		writer.Write( temp.SlipNote2 );
		//�`�[���l�R
		writer.Write( temp.SlipNote3 );
		//���i�ԍ�
		writer.Write( temp.GoodsNo );
		//�d���݌Ɏ�񂹋敪
		writer.Write( temp.StockOrderDivCd );
		//���i����
		writer.Write( temp.GoodsName );
		//�艿�i�Ŕ��C�����j
		writer.Write( temp.ListPriceTaxExcFl );
		//�d����
		writer.Write( temp.StockCount );
		//����P���i�Ŕ��C�����j
		writer.Write( temp.SalesUnPrcTaxExcFl );
		//������z�i�Ŕ����j
		writer.Write( temp.SalesMoneyTaxExc );
		//�d�����z�i�Ŕ����j
		writer.Write( temp.StockPriceTaxExc );
		//�d���P���i�Ŕ��C�����j
		writer.Write( temp.StockUnitPriceFl );
		//�d����R�[�h
		writer.Write( temp.SupplierCd );
		//�����`�[�ԍ�
		writer.Write( temp.PartySaleSlipNum );
		//�d���`�[�敪�i���ׁj
		writer.Write( temp.StockSlipCdDtl );
		//����`�[�敪�i���ׁj
		writer.Write( temp.SalesSlipCdDtl );
		//�d���`�[���l1
		writer.Write( temp.SupplierSlipNote1 );
		//�d���`�[�ԍ�
		writer.Write( temp.SupplierSlipNo );
		//�d���`�[�敪
		writer.Write( temp.SupplierSlipCd );
		//����`�[�敪
		writer.Write( temp.SalesSlipCd );
		//����`�[���v�i�Ŕ����j
		writer.Write( temp.SalesTotalTaxExc );
		//����l�����z�v�i�Ŕ����j
		writer.Write( temp.SalesDisTtlTaxExc );
		//����`�[���v�i�ō��݁j
		writer.Write( temp.SalesTotalTaxInc );
		//����l������Ŋz�i�O�Łj
		writer.Write( temp.SalesDisOutTax );
		//�d�����z���v
		writer.Write( temp.StockSubttlPrice );
		//�d�����z�v�i�ō��݁j
		writer.Write( temp.StockTtlPricTaxInc );
		//�d�����z�v�i�Ŕ����j
		writer.Write( temp.StockTtlPricTaxExc );
		//�d���l�����z�v�i�Ŕ����j
		writer.Write( temp.StckDisTtlTaxExc );
		//�o�א�
		writer.Write( temp.ShipmentCnt );
		//�d���s�ԍ�
		writer.Write( temp.StockRowNo );
		//�d�����i�敪
		writer.Write( temp.StockGoodsCd );

	}

	/// <summary>
	///  StockSalesResultInfoWork�C���X�^���X�擾
	/// </summary>
	/// <returns>StockSalesResultInfoWork�N���X�̃C���X�^���X</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   StockSalesResultInfoWork�̃C���X�^���X���擾���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	private StockSalesResultInfoWork GetStockSalesResultInfoWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		// serInfo.MemberInfo.Count < currentMemberCount
		// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		StockSalesResultInfoWork temp = new StockSalesResultInfoWork();

		//���_�R�[�h
		temp.SectionCode = reader.ReadString();
		//���͓�
		temp.InputDay = reader.ReadInt32();
		//�d����
		temp.StockDate = reader.ReadInt32();
		//���_�K�C�h����
		temp.SectionGuideNm = reader.ReadString();
		//���Ӑ�R�[�h
		temp.CustomerCode = reader.ReadInt32();
		//���Ӑ於��
		temp.CustomerName = reader.ReadString();
		//������t
		temp.SalesDate = reader.ReadInt32();
		//����`�[�ԍ�
		temp.SalesSlipNum = reader.ReadString();
		//�d���S���Җ���
		temp.StockAgentName = reader.ReadString();
		//��t�]�ƈ�����
		temp.FrontEmployeeNm = reader.ReadString();
		//������͎Җ���
		temp.SalesInputName = reader.ReadString();
		//�t�n�d���}�[�N�P
		temp.UoeRemark1 = reader.ReadString();
		//�t�n�d���}�[�N�Q
		temp.UoeRemark2 = reader.ReadString();
		//�`�[���l
		temp.SlipNote = reader.ReadString();
		//�`�[���l�Q
		temp.SlipNote2 = reader.ReadString();
		//�`�[���l�R
		temp.SlipNote3 = reader.ReadString();
		//���i�ԍ�
		temp.GoodsNo = reader.ReadString();
		//�d���݌Ɏ�񂹋敪
		temp.StockOrderDivCd = reader.ReadInt32();
		//���i����
		temp.GoodsName = reader.ReadString();
		//�艿�i�Ŕ��C�����j
		temp.ListPriceTaxExcFl = reader.ReadDouble();
		//�d����
		temp.StockCount = reader.ReadDouble();
		//����P���i�Ŕ��C�����j
		temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
		//������z�i�Ŕ����j
		temp.SalesMoneyTaxExc = reader.ReadInt64();
		//�d�����z�i�Ŕ����j
		temp.StockPriceTaxExc = reader.ReadInt64();
		//�d���P���i�Ŕ��C�����j
		temp.StockUnitPriceFl = reader.ReadDouble();
		//�d����R�[�h
		temp.SupplierCd = reader.ReadInt32();
		//�����`�[�ԍ�
		temp.PartySaleSlipNum = reader.ReadString();
		//�d���`�[�敪�i���ׁj
		temp.StockSlipCdDtl = reader.ReadInt32();
		//����`�[�敪�i���ׁj
		temp.SalesSlipCdDtl = reader.ReadInt32();
		//�d���`�[���l1
		temp.SupplierSlipNote1 = reader.ReadString();
		//�d���`�[�ԍ�
		temp.SupplierSlipNo = reader.ReadInt32();
		//�d���`�[�敪
		temp.SupplierSlipCd = reader.ReadInt32();
		//����`�[�敪
		temp.SalesSlipCd = reader.ReadInt32();
		//����`�[���v�i�Ŕ����j
		temp.SalesTotalTaxExc = reader.ReadInt64();
		//����l�����z�v�i�Ŕ����j
		temp.SalesDisTtlTaxExc = reader.ReadInt64();
		//����`�[���v�i�ō��݁j
		temp.SalesTotalTaxInc = reader.ReadInt64();
		//����l������Ŋz�i�O�Łj
		temp.SalesDisOutTax = reader.ReadInt64();
		//�d�����z���v
		temp.StockSubttlPrice = reader.ReadInt64();
		//�d�����z�v�i�ō��݁j
		temp.StockTtlPricTaxInc = reader.ReadInt64();
		//�d�����z�v�i�Ŕ����j
		temp.StockTtlPricTaxExc = reader.ReadInt64();
		//�d���l�����z�v�i�Ŕ����j
		temp.StckDisTtlTaxExc = reader.ReadInt64();
		//�o�א�
		temp.ShipmentCnt = reader.ReadDouble();
		//�d���s�ԍ�
		temp.StockRowNo = reader.ReadInt32();
		//�d�����i�敪
		temp.StockGoodsCd = reader.ReadInt32();

			
		//�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			//�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			//�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			//�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
			{
				Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
			}
		}
		return temp;
	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
	/// </summary>
	/// <returns>StockSalesResultInfoWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   StockSalesResultInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			StockSalesResultInfoWork temp = GetStockSalesResultInfoWork( reader, serInfo );
			lst.Add( temp );
		}
		switch(serInfo.RetTypeInfo)
		{
			case 0:
				retValue = lst;
				break;
			case 1:
				retValue = lst[0];
				break;
			case 2:
				retValue = (StockSalesResultInfoWork[])lst.ToArray(typeof(StockSalesResultInfoWork));
				break;
		}
		return retValue;
	}

	#endregion
}




}
