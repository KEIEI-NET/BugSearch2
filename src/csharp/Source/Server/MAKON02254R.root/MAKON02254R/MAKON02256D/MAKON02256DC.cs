using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockConfSlipTtlWork
	/// <summary>
	///                      �d���m�F�\(�`�[���v)�f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���m�F�\(�`�[���v)�f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>-
	/// <br>Genarated Date   :   2009/01/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/06/30  �c��</br>
	/// <br>                 :   Partsman.NS�Ή�</br>
	/// <br>                 :   �E���_�K�C�h���́����_�K�C�h���̂ɕύX</br>
	/// <br>                 :   �E���Ӑ�R�[�h�E���́��d����R�[�h�E���̂ɕύX</br>
	/// <br>                 :   �E���|�敪�A�t�n�d���}�[�N�̒ǉ�</br>
    /// <br>Update Note      :   2020/02/27 3H ����</br>
    /// <br>                 :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Update Note      : 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j </br>
    /// <br>Date             : 2022/09/28</br>
    /// <br>                 : ���O </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockConfSlipTtlWork
	{
		/// <summary>���_�R�[�h</summary>
		/// <remarks>�c�Ə��R�[�h</remarks>
        private string _stockSectionCd = "";

		/// <summary>���_�K�C�h����</summary>
		/// <remarks>���[�󎚗p</remarks>
		private string _sectionGuideSnm = "";

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>���͓�</summary>
		/// <remarks>���͓��t</remarks>
		private Int32 _inputDay;

		/// <summary>���ד�</summary>
		/// <remarks>�`�[���t</remarks>
        private Int32 _arrivalGoodsDay;

		/// <summary>�d����</summary>
		/// <remarks>�`�[���t</remarks>
		private DateTime _stockDate;

		/// <summary>�d���`��</summary>
		/// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d���`�[�ԍ�</summary>
		/// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�@���d��SEQ</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>�����`�[�ԍ�</summary>
		/// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>�d���`�[�敪</summary>
		/// <remarks>10:�d��,20:�ԕi</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>�d�����z�v�i�ō��݁j</summary>
		/// <remarks>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</remarks>
		private Int64 _stockTtlPricTaxInc;

		/// <summary>�d�����z�v�i�Ŕ����j</summary>
		/// <remarks>�d�����z</remarks>
		private Int64 _stockTtlPricTaxExc;

		/// <summary>�d�����z����Ŋz</summary>
		/// <remarks>�����</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>�d�����i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>���|�敪</summary>
		/// <remarks>0:���|�Ȃ�,1:���|</remarks>
		private Int32 _accPayDivCd;

		/// <summary>�t�n�d���}�[�N�P</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>�t�n�d���}�[�N�Q</summary>
		private string _uoeRemark2 = "";

		/// <summary>�d���摍�z�\�����@�敪</summary>
		/// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
		private Int32 _suppTtlAmntDspWayCd;

		/// <summary>�d�������œ]�ŕ����R�[�h</summary>
		/// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
		private Int32 _suppCTaxLayCd;

		/// <summary>�d�����z����Ŋz�i���Łj</summary>
		/// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
		private Int64 _stckPrcConsTaxInclu;

		/// <summary>�d���l������Ŋz�i���Łj</summary>
		/// <remarks>���ŏ��i�l���̏���Ŋz</remarks>
		private Int64 _stckDisTtlTaxInclu;

		/// <summary>�d���l������Ŋz�i�O�Łj</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
		private Int64 _stockDisOutTax;

		/// <summary>�d���l�����z�v�i�Ŕ����j</summary>
		/// <remarks>�d���l���O�őΏۊz���v+�d���l�����őΏۊz���v+�d���l����ېőΏۊz���v</remarks>
		private Int64 _stckDisTtlTaxExc;

        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary>�d�������Őŗ�</summary>
        private Double _supplierConsTaxRate;

        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        /// <summary>�d�����z��ې�</summary>
        private Int64 _stockPriceTaxFreeCrf;

        /// <summary>�d�����׉ېő��݃t���O</summary>
        private bool _taxRateExistFlag;

        /// <summary>�d�����ה�ېő��݃t���O</summary>
        private bool _taxFreeExistFlag;
        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<


        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>�d�������Őŗ��v���p�e�B</summary>
        /// <value>�d�������Őŗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

        /// public propaty name  :  StockSectionCd
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>�c�Ə��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string StockSectionCd
		{
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
		}

		/// public propaty name  :  SectionGuideSnm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// <value>���[�󎚗p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideSnm
		{
			get{return _sectionGuideSnm;}
			set{_sectionGuideSnm = value;}
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

		/// public propaty name  :  InputDay
		/// <summary>���͓��v���p�e�B</summary>
		/// <value>���͓��t</value>
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

		/// public propaty name  :  ArrivalGoodsDay
		/// <summary>���ד��v���p�e�B</summary>
		/// <value>�`�[���t</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ד��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 ArrivalGoodsDay
		{
			get{return _arrivalGoodsDay;}
			set{_arrivalGoodsDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>�d�����v���p�e�B</summary>
		/// <value>�`�[���t</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StockDate
		{
			get{return _stockDate;}
			set{_stockDate = value;}
		}

		/// public propaty name  :  SupplierFormal
		/// <summary>�d���`���v���p�e�B</summary>
		/// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierFormal
		{
			get{return _supplierFormal;}
			set{_supplierFormal = value;}
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>�d���`�[�ԍ��v���p�e�B</summary>
		/// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�@���d��SEQ</value>
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

		/// public propaty name  :  StockTotalPrice
		/// <summary>�d�����z���v�v���p�e�B</summary>
		/// <value>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockTotalPrice
		{
			get{return _stockTotalPrice;}
			set{_stockTotalPrice = value;}
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
		/// <value>�d�����z</value>
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

		/// public propaty name  :  StockPriceConsTax
		/// <summary>�d�����z����Ŋz�v���p�e�B</summary>
		/// <value>�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>�d�����i�敪�v���p�e�B</summary>
		/// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</value>
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

		/// public propaty name  :  AccPayDivCd
		/// <summary>���|�敪�v���p�e�B</summary>
		/// <value>0:���|�Ȃ�,1:���|</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���|�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AccPayDivCd
		{
			get{return _accPayDivCd;}
			set{_accPayDivCd = value;}
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

		/// public propaty name  :  SuppTtlAmntDspWayCd
		/// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
		/// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SuppTtlAmntDspWayCd
		{
			get{return _suppTtlAmntDspWayCd;}
			set{_suppTtlAmntDspWayCd = value;}
		}

		/// public propaty name  :  SuppCTaxLayCd
		/// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
		/// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SuppCTaxLayCd
		{
			get{return _suppCTaxLayCd;}
			set{_suppCTaxLayCd = value;}
		}

		/// public propaty name  :  StckPrcConsTaxInclu
		/// <summary>�d�����z����Ŋz�i���Łj�v���p�e�B</summary>
		/// <value>�l���O�̓��ŏ��i�̏����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z����Ŋz�i���Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StckPrcConsTaxInclu
		{
			get{return _stckPrcConsTaxInclu;}
			set{_stckPrcConsTaxInclu = value;}
		}

		/// public propaty name  :  StckDisTtlTaxInclu
		/// <summary>�d���l������Ŋz�i���Łj�v���p�e�B</summary>
		/// <value>���ŏ��i�l���̏���Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���l������Ŋz�i���Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StckDisTtlTaxInclu
		{
			get{return _stckDisTtlTaxInclu;}
			set{_stckDisTtlTaxInclu = value;}
		}

        /// public propaty name  :  StockDisOutTax
		/// <summary>�d���l������Ŋz�i�O�Łj�v���p�e�B</summary>
		/// <value>�l���O�̊O�ŏ��i�̏����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���l������Ŋz�i�O�Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int64 StockDisOutTax
		{
			get{return _stockDisOutTax;}
			set{_stockDisOutTax = value;}
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

        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        /// public propaty name  :  StockPriceTaxFreeCdrf
        /// <summary>�d�����z��ې�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z��ېŃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxFreeCrf
        {
            get { return _stockPriceTaxFreeCrf; }
            set { _stockPriceTaxFreeCrf = value; }
        }

        /// public propaty name  :  TaxRateExistFlag
        /// <summary>�d�����׉ېő��݃t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �d�����׉ېő��݃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TaxRateExistFlag
        {
            get { return _taxRateExistFlag; }
            set { _taxRateExistFlag = value; }
        }

        /// public propaty name  :  TaxFreeExistFlag
        /// <summary>�d�����ה�ېő��݃t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �d�����ה�ېő��݃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool TaxFreeExistFlag
        {
            get { return _taxFreeExistFlag; }
            set { _taxFreeExistFlag = value; }
        }
        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

		/// <summary>
		/// �d���m�F�\(�`�[���v)�f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockConfSlipTtlWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockConfSlipTtlWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockConfSlipTtlWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockConfSlipTtlWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockConfSlipTtlWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programer        :   2020/02/27 3H ����</br>
    /// </remarks>
    public class StockConfSlipTtlWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfSlipTtlWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockConfSlipTtlWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockConfSlipTtlWork || graph is ArrayList || graph is StockConfSlipTtlWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockConfSlipTtlWork).FullName));

            if (graph != null && graph is StockConfSlipTtlWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockConfSlipTtlWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockConfSlipTtlWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockConfSlipTtlWork[])graph).Length;
            }
            else if (graph is StockConfSlipTtlWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //�d�����z�v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //�d�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d�����z����Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
            //�d���l������Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu
            //�d���l������Ŋz�i�O�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StockDisOutTax
            //�d���l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc

            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            //�d�������Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            // --- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--------->>>>>>
            // �d�����z��ې�
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxFreeCdrf
            // �d�����׉ېő��݃t���O
            serInfo.MemberInfo.Add(typeof(Boolean)); //TaxRateExistFlag
            // �d�����ה�ېő��݃t���O
            serInfo.MemberInfo.Add(typeof(Boolean)); //TaxFreeExistFlag
            // --- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---------<<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is StockConfSlipTtlWork)
            {
                StockConfSlipTtlWork temp = (StockConfSlipTtlWork)graph;

                SetStockConfSlipTtlWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockConfSlipTtlWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockConfSlipTtlWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockConfSlipTtlWork temp in lst)
                {
                    SetStockConfSlipTtlWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockConfSlipTtlWork�����o��(public�v���p�e�B��)
        /// </summary>
        // private const int currentMemberCount = 26; // --- DEL 3H ���� 2020/02/27
        // --- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
        // private const int currentMemberCount = 27;    // --- ADD 3H ���� 2020/02/27
        private const int currentMemberCount = 30;
        // --- UPD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

        /// <summary>
        ///  StockConfSlipTtlWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfSlipTtlWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
        /// </remarks>
        private void SetStockConfSlipTtlWork(System.IO.BinaryWriter writer, StockConfSlipTtlWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.StockSectionCd);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���͓�
            writer.Write(temp.InputDay);
            //���ד�
            writer.Write(temp.ArrivalGoodsDay);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�d�����z���v
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v
            writer.Write(temp.StockSubttlPrice);
            //�d�����z�v�i�ō��݁j
            writer.Write(temp.StockTtlPricTaxInc);
            //�d�����z�v�i�Ŕ����j
            writer.Write(temp.StockTtlPricTaxExc);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //���|�敪
            writer.Write(temp.AccPayDivCd);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d�����z����Ŋz�i���Łj
            writer.Write(temp.StckPrcConsTaxInclu);
            //�d���l������Ŋz�i���Łj
            writer.Write(temp.StckDisTtlTaxInclu);
            //�d���l������Ŋz�i�O�Łj
            writer.Write(temp.StockDisOutTax);
            //�d���l�����z�v�i�Ŕ����j
            writer.Write(temp.StckDisTtlTaxExc);
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            //�d�������Őŗ�
            writer.Write(temp.SupplierConsTaxRate);
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            // --- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--------->>>>>>
            // �d�����z��ې�
            writer.Write(temp.StockPriceTaxFreeCrf);
            // �d�����׉ېő��݃t���O
            writer.Write(temp.TaxRateExistFlag);
            // �d�����ה�ېő��݃t���O
            writer.Write(temp.TaxFreeExistFlag);
            // --- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---------<<<<<<

        }

        /// <summary>
        ///  StockConfSlipTtlWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockConfSlipTtlWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfSlipTtlWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programer        :   2020/02/27 3H ����</br>
        /// </remarks>
        private StockConfSlipTtlWork GetStockConfSlipTtlWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockConfSlipTtlWork temp = new StockConfSlipTtlWork();

            //���_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���͓�
            temp.InputDay = reader.ReadInt32();
            //���ד�
            temp.ArrivalGoodsDay = reader.ReadInt32();
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�d�����z���v
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v
            temp.StockSubttlPrice = reader.ReadInt64();
            //�d�����z�v�i�ō��݁j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //�d�����z�v�i�Ŕ����j
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //���|�敪
            temp.AccPayDivCd = reader.ReadInt32();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d�����z����Ŋz�i���Łj
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //�d���l������Ŋz�i���Łj
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            //�d���l������Ŋz�i�O�Łj
            temp.StockDisOutTax = reader.ReadInt64();
            //�d���l�����z�v�i�Ŕ����j
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            //�d�������Őŗ�
            temp.SupplierConsTaxRate = reader.ReadDouble();
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            // --- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--------->>>>>>
            // �d�����z��ې�
            temp.StockPriceTaxFreeCrf = reader.ReadInt64();
            // �d�����׉ېő��݃t���O
            temp.TaxRateExistFlag = reader.ReadBoolean();
            // �d�����ה�ېő��݃t���O
            temp.TaxFreeExistFlag = reader.ReadBoolean();
            // --- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---------<<<<<

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
        /// <returns>StockConfSlipTtlWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockConfSlipTtlWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockConfSlipTtlWork temp = GetStockConfSlipTtlWork(reader, serInfo);
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
                    retValue = (StockConfSlipTtlWork[])lst.ToArray(typeof(StockConfSlipTtlWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
