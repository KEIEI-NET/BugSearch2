using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   LedgerStockSlipWork
	/// <summary>
	///                      �d���挳���i�d���`�[�j���o���ʃ��[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���挳���i�d���`�[�j���o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/07  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class LedgerStockSlipWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�d���`��</summary>
		/// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
		private Int32 _supplierFormal;

		/// <summary>�d���`�[�ԍ�</summary>
		/// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�ԓ`�敪</summary>
		/// <remarks>0:���`,1:�ԓ`,2:����</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>�ԍ��A���d���`�[�ԍ�</summary>
		private Int32 _debitNLnkSuppSlipNo;

		/// <summary>�d���`�[�敪</summary>
		/// <remarks>10:�d��,20:�ԕi</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>�d�����i�敪</summary>
		/// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>�d�����_�R�[�h</summary>
		/// <remarks>�����^ �������͂������_�R�[�h</remarks>
		private string _stockSectionCd = "";

		/// <summary>�d���v�㋒�_�R�[�h</summary>
		/// <remarks>�����^</remarks>
		private string _stockAddUpSectionCd = "";

		/// <summary>���͓�</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
		private DateTime _inputDay;

		/// <summary>���ד�</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _arrivalGoodsDay;

		/// <summary>�d����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockDate;

		/// <summary>�d���v����t</summary>
		/// <remarks>�d���v���</remarks>
		private DateTime _stockAddUpADate;

		/// <summary>�d�����͎҃R�[�h</summary>
		private string _stockInputCode = "";

		/// <summary>�d�����͎Җ���</summary>
		private string _stockInputName = "";

		/// <summary>�d���S���҃R�[�h</summary>
		/// <remarks>�����҂��Z�b�g</remarks>
		private string _stockAgentCode = "";

		/// <summary>�d���S���Җ���</summary>
		/// <remarks>�����҂��Z�b�g</remarks>
		private string _stockAgentName = "";

		/// <summary>�x����R�[�h</summary>
		/// <remarks>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</remarks>
		private Int32 _payeeCode;

		/// <summary>�x���旪��</summary>
		private string _payeeSnm = "";

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�d���於1</summary>
		private string _supplierNm1 = "";

		/// <summary>�d���於2</summary>
		private string _supplierNm2 = "";

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</remarks>
		private Int64 _stockTotalPrice;

		/// <summary>�d�����z���v</summary>
		/// <remarks>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
		private Int64 _stockSubttlPrice;

		/// <summary>�d�����z����Ŋz</summary>
		/// <remarks>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>�����`�[�ԍ�</summary>
		/// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>�d���`�[���l1</summary>
		private string _supplierSlipNote1 = "";

		/// <summary>�d���`�[���l2</summary>
		private string _supplierSlipNote2 = "";

		/// <summary>�t�n�d���}�[�N�P</summary>
		/// <remarks>UserOrderEntory</remarks>
		private string _uoeRemark1 = "";

		/// <summary>�t�n�d���}�[�N�Q</summary>
		private string _uoeRemark2 = "";


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

		/// public propaty name  :  DebitNoteDiv
		/// <summary>�ԓ`�敪�v���p�e�B</summary>
		/// <value>0:���`,1:�ԓ`,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԓ`�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  DebitNLnkSuppSlipNo
		/// <summary>�ԍ��A���d���`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��A���d���`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNLnkSuppSlipNo
		{
			get{return _debitNLnkSuppSlipNo;}
			set{_debitNLnkSuppSlipNo = value;}
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

		/// public propaty name  :  StockSectionCd
		/// <summary>�d�����_�R�[�h�v���p�e�B</summary>
		/// <value>�����^ �������͂������_�R�[�h</value>
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

		/// public propaty name  :  StockAddUpSectionCd
		/// <summary>�d���v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�����^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAddUpSectionCd
		{
			get{return _stockAddUpSectionCd;}
			set{_stockAddUpSectionCd = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>���͓��v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  ArrivalGoodsDay
		/// <summary>���ד��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ד��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ArrivalGoodsDay
		{
			get{return _arrivalGoodsDay;}
			set{_arrivalGoodsDay = value;}
		}

		/// public propaty name  :  StockDate
		/// <summary>�d�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
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

		/// public propaty name  :  StockAddUpADate
		/// <summary>�d���v����t�v���p�e�B</summary>
		/// <value>�d���v���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���v����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StockAddUpADate
		{
			get{return _stockAddUpADate;}
			set{_stockAddUpADate = value;}
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
		/// <value>�����҂��Z�b�g</value>
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

		/// public propaty name  :  PayeeCode
		/// <summary>�x����R�[�h�v���p�e�B</summary>
		/// <value>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  PayeeSnm
		/// <summary>�x���旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PayeeSnm
		{
			get{return _payeeSnm;}
			set{_payeeSnm = value;}
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

		/// public propaty name  :  SupplierNm1
		/// <summary>�d���於1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���於1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
		}

		/// public propaty name  :  SupplierNm2
		/// <summary>�d���於2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���於2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm2
		{
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
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

		/// public propaty name  :  StockPriceConsTax
		/// <summary>�d�����z����Ŋz�v���p�e�B</summary>
		/// <value>�d�����z����Ŋz�i�O�Łj+�d�����z����Ŋz�i���Łj</value>
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

		/// public propaty name  :  SupplierSlipNote2
		/// <summary>�d���`�[���l2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[���l2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSlipNote2
		{
			get{return _supplierSlipNote2;}
			set{_supplierSlipNote2 = value;}
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


		/// <summary>
		/// �d���挳���i�d���`�[�j���o���ʃ��[�N���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>LedgerStockSlipWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   LedgerStockSlipWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public LedgerStockSlipWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>LedgerStockSlipWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   LedgerStockSlipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class LedgerStockSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   LedgerStockSlipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  LedgerStockSlipWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is LedgerStockSlipWork || graph is ArrayList || graph is LedgerStockSlipWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(LedgerStockSlipWork).FullName));

            if (graph != null && graph is LedgerStockSlipWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.LedgerStockSlipWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is LedgerStockSlipWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((LedgerStockSlipWork[])graph).Length;
            }
            else if (graph is LedgerStockSlipWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�ԍ��A���d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkSuppSlipNo
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //�d���v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //�d�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //�d�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�d���`�[���l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //�d���`�[���l2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2


            serInfo.Serialize(writer, serInfo);
            if (graph is LedgerStockSlipWork)
            {
                LedgerStockSlipWork temp = (LedgerStockSlipWork)graph;

                SetLedgerStockSlipWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is LedgerStockSlipWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((LedgerStockSlipWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (LedgerStockSlipWork temp in lst)
                {
                    SetLedgerStockSlipWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// LedgerStockSlipWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  LedgerStockSlipWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   LedgerStockSlipWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetLedgerStockSlipWork(System.IO.BinaryWriter writer, LedgerStockSlipWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�ԍ��A���d���`�[�ԍ�
            writer.Write(temp.DebitNLnkSuppSlipNo);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);
            //�d���v�㋒�_�R�[�h
            writer.Write(temp.StockAddUpSectionCd);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //���ד�
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���v����t
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //�d�����͎҃R�[�h
            writer.Write(temp.StockInputCode);
            //�d�����͎Җ���
            writer.Write(temp.StockInputName);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�d�����z���v
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v
            writer.Write(temp.StockSubttlPrice);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�d���`�[���l1
            writer.Write(temp.SupplierSlipNote1);
            //�d���`�[���l2
            writer.Write(temp.SupplierSlipNote2);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);

        }

        /// <summary>
        ///  LedgerStockSlipWork�C���X�^���X�擾
        /// </summary>
        /// <returns>LedgerStockSlipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   LedgerStockSlipWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private LedgerStockSlipWork GetLedgerStockSlipWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            LedgerStockSlipWork temp = new LedgerStockSlipWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�ԍ��A���d���`�[�ԍ�
            temp.DebitNLnkSuppSlipNo = reader.ReadInt32();
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //�d���v�㋒�_�R�[�h
            temp.StockAddUpSectionCd = reader.ReadString();
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //���ד�
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���v����t
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //�d�����͎҃R�[�h
            temp.StockInputCode = reader.ReadString();
            //�d�����͎Җ���
            temp.StockInputName = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�d�����z���v
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v
            temp.StockSubttlPrice = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�d���`�[���l1
            temp.SupplierSlipNote1 = reader.ReadString();
            //�d���`�[���l2
            temp.SupplierSlipNote2 = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();


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
        /// <returns>LedgerStockSlipWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   LedgerStockSlipWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                LedgerStockSlipWork temp = GetLedgerStockSlipWork(reader, serInfo);
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
                    retValue = (LedgerStockSlipWork[])lst.ToArray(typeof(LedgerStockSlipWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
