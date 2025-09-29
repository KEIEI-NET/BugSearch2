//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�e�L�X�g�ϊ��f�[�^�p�����[�^�N���X
// �v���O�����T�v   : ���i�e�L�X�g�ϊ����o���ʃ��[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00  �쐬�S�� : FSI���� �f��
// �� �� ��  K2012/05/28  �C�����e : �V�K�쐬 �R�`���i�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   GoodsUWork
	/// <summary>
	///                      ���i�e�L�X�g�ϊ����o���ʃ��[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���i�e�L�X�g�ϊ����o���ʃ��[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   K2012/05/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class GoodsUWork
	{
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>�d���f�[�^</remarks>
        private string _enterpriseCode = "";

        /// <summary>���O�C���]�ƈ��̋��_�R�[�h</summary>
        /// <remarks>���O�C���]�ƈ��̋��_�R�[�h</remarks>
        private string _loginsectionCode = "";

        /// <summary>���ݏ����N���x</summary>
        /// <remarks>���ݏ����N���x</remarks>
        private Int32 _addupyearmonthCd;

		/// <summary>���i�ԍ�</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private string _goodsName = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>BL���i�R�[�h</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _bLGoodsCode;

		/// <summary>�d����R�[�h</summary>
		/// <remarks>���i�Ǘ����}�X�^</remarks>
		private Int32 _supplierCd;

		/// <summary>�艿(����)[���݉��i]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _listPriceNow;

		/// <summary>�艿(����)[�V���i]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _listPriceNew;

		/// <summary>���i�J�n��[�V���i]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _priceStartDateNew;

		/// <summary>�d����[���݉��i]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _stockRateNow;

		/// <summary>�����P��[���݉��i]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _salesUnitCostNow;

        /// <summary>���i�|�������N(�w��)</summary>
        /// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
        private string _goodsRaterank;

		/// <summary>�������b�g</summary>
		/// <remarks>���i�Ǘ����}�X�^</remarks>
		private Int32 _supplierLot;

		/// <summary>���i�K�i�E���L����</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private string _goodsSpecialNote = "";

		/// <summary>���i����</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _goodsKindCode;

		/// <summary>���Е��ރR�[�h</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _enterpriseGanreCode;

		/// <summary>�ېŋ敪</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _taxationDivCd;

		/// <summary>���i���l�P</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private string _goodsNote1 = "";

		/// <summary>���i���l�Q</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private string _goodsNote2 = "";

		/// <summary>�񋟃f�[�^�敪</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _offerDataDiv;

		/// <summary>���i�J�n��[No.1]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _priceStartDate1;

		/// <summary>�艿(����)[No.1]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _listPrice1;

		/// <summary>�����P��[No.1]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _salesUnitCost1;

		/// <summary>�d����[No.1]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _stockRate1;

		/// <summary>�I�[�v�����i�敪[No.1]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _openPriceDiv1;

		/// <summary>�񋟓��t[No.1]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _offerDate1;

		/// <summary>���i�J�n��[No.2]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _priceStartDate2;

		/// <summary>�艿(����)[No.2]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _listPrice2;

		/// <summary>�����P��[No.2]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _salesUnitCost2;

		/// <summary>�d����[No.2]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _stockRate2;

		/// <summary>�I�[�v�����i�敪[No.2]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _openPriceDiv2;

		/// <summary>�񋟓��t[No.2]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _offerDate2;

		/// <summary>���i�J�n��[No.3]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _priceStartDate3;

		/// <summary>�艿(����)[No.3]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _listPrice3;

		/// <summary>�����P��[No.3]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _salesUnitCost3;

		/// <summary>�d����[No.3]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Double _stockRate3;

		/// <summary>�I�[�v�����i�敪[No.3]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _openPriceDiv3;

		/// <summary>�񋟓��t[No.3]</summary>
		/// <remarks>���i�}�X�^(���[�U�o�^��)</remarks>
		private Int32 _offerDate3;

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  LoginSectionCode
        /// <summary>���O�C���]�ƈ��̋��_�R�[�h�v���p�e�B</summary>
        /// <value>���O�C���]�ƈ��̋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���]�ƈ��̋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginSectionCode
        {
            get { return _loginsectionCode; }
            set { _loginsectionCode = value; }
        }

        /// public propaty name  :  AddUpYearMonthRFCd
        /// <summary>���ݏ����N���x</summary>
        /// <value>���ݏ����N���x</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݏ����N���x</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpYearMonthCd
        {
            get { return _addupyearmonthCd; }
            set { _addupyearmonthCd = value; }
        }

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// <value>���i�Ǘ����}�X�^</value>
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

		/// public propaty name  :  ListPriceNow
		/// <summary>�艿(����)[���݉��i]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿(����)[���݉��i]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceNow
		{
			get{return _listPriceNow;}
			set{_listPriceNow = value;}
		}

		/// public propaty name  :  ListPriceNew
		/// <summary>�艿(����)[�V���i]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿(����)[�V���i]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPriceNew
		{
			get{return _listPriceNew;}
			set{_listPriceNew = value;}
		}

		/// public propaty name  :  PriceStartDateNew
		/// <summary>���i�J�n��[�V���i]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n��[�V���i]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceStartDateNew
		{
			get{return _priceStartDateNew;}
			set{_priceStartDateNew = value;}
		}

		/// public propaty name  :  StockRateNow
		/// <summary>�d����[���݉��i]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����[���݉��i]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockRateNow
		{
			get{return _stockRateNow;}
			set{_stockRateNow = value;}
		}

		/// public propaty name  :  SalesUnitCostNow
		/// <summary>�����P��[���݉��i]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P��[���݉��i]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnitCostNow
		{
			get{return _salesUnitCostNow;}
			set{_salesUnitCostNow = value;}
		}

        /// public propaty name  :  GoodsRaterank
        /// <summary>���i�|�������N(�w��)�v���p�e�B</summary>
        /// <value>���i�|�������N(�w��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   ���i�|�������N(�w��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string GoodsRaterank
		{
            get { return _goodsRaterank; }
            set { _goodsRaterank = value; }
		}

		/// public propaty name  :  SupplierLot
		/// <summary>�������b�g�v���p�e�B</summary>
		/// <value>���i�Ǘ����}�X�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������b�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierLot
		{
			get{return _supplierLot;}
			set{_supplierLot = value;}
		}

		/// public propaty name  :  GoodsSpecialNote
		/// <summary>���i�K�i�E���L�����v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsSpecialNote
		{
			get{return _goodsSpecialNote;}
			set{_goodsSpecialNote = value;}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>���i�����v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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

		/// public propaty name  :  TaxationDivCd
		/// <summary>�ېŋ敪�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
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

		/// public propaty name  :  GoodsNote1
		/// <summary>���i���l�P�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���l�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNote1
		{
			get{return _goodsNote1;}
			set{_goodsNote1 = value;}
		}

		/// public propaty name  :  GoodsNote2
		/// <summary>���i���l�Q�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���l�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNote2
		{
			get{return _goodsNote2;}
			set{_goodsNote2 = value;}
		}

		/// public propaty name  :  OfferDataDiv
		/// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDataDiv
		{
			get{return _offerDataDiv;}
			set{_offerDataDiv = value;}
		}

		/// public propaty name  :  PriceStartDate1
		/// <summary>���i�J�n��[No.1]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n��[No.1]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceStartDate1
		{
			get{return _priceStartDate1;}
			set{_priceStartDate1 = value;}
		}

		/// public propaty name  :  ListPrice1
		/// <summary>�艿(����)[No.1]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿(����)[No.1]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPrice1
		{
			get{return _listPrice1;}
			set{_listPrice1 = value;}
		}

		/// public propaty name  :  SalesUnitCost1
		/// <summary>�����P��[No.1]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P��[No.1]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnitCost1
		{
			get{return _salesUnitCost1;}
			set{_salesUnitCost1 = value;}
		}

		/// public propaty name  :  StockRate1
		/// <summary>�d����[No.1]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����[No.1]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockRate1
		{
			get{return _stockRate1;}
			set{_stockRate1 = value;}
		}

		/// public propaty name  :  OpenPriceDiv1
		/// <summary>�I�[�v�����i�敪[No.1]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�[�v�����i�敪[No.1]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OpenPriceDiv1
		{
			get{return _openPriceDiv1;}
			set{_openPriceDiv1 = value;}
		}

		/// public propaty name  :  OfferDate1
		/// <summary>�񋟓��t[No.1]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟓��t[No.1]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDate1
		{
			get{return _offerDate1;}
			set{_offerDate1 = value;}
		}

		/// public propaty name  :  PriceStartDate2
		/// <summary>���i�J�n��[No.2]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n��[No.2]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceStartDate2
		{
			get{return _priceStartDate2;}
			set{_priceStartDate2 = value;}
		}

		/// public propaty name  :  ListPrice2
		/// <summary>�艿(����)[No.2]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿(����)[No.2]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPrice2
		{
			get{return _listPrice2;}
			set{_listPrice2 = value;}
		}

		/// public propaty name  :  SalesUnitCost2
		/// <summary>�����P��[No.2]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P��[No.2]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnitCost2
		{
			get{return _salesUnitCost2;}
			set{_salesUnitCost2 = value;}
		}

		/// public propaty name  :  StockRate2
		/// <summary>�d����[No.2]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����[No.2]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockRate2
		{
			get{return _stockRate2;}
			set{_stockRate2 = value;}
		}

		/// public propaty name  :  OpenPriceDiv2
		/// <summary>�I�[�v�����i�敪[No.2]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�[�v�����i�敪[No.2]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OpenPriceDiv2
		{
			get{return _openPriceDiv2;}
			set{_openPriceDiv2 = value;}
		}

		/// public propaty name  :  OfferDate2
		/// <summary>�񋟓��t[No.2]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟓��t[No.2]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDate2
		{
			get{return _offerDate2;}
			set{_offerDate2 = value;}
		}

		/// public propaty name  :  PriceStartDate3
		/// <summary>���i�J�n��[No.3]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n��[No.3]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceStartDate3
		{
			get{return _priceStartDate3;}
			set{_priceStartDate3 = value;}
		}

		/// public propaty name  :  ListPrice3
		/// <summary>�艿(����)[No.3]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿(����)[No.3]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ListPrice3
		{
			get{return _listPrice3;}
			set{_listPrice3 = value;}
		}

		/// public propaty name  :  SalesUnitCost3
		/// <summary>�����P��[No.3]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P��[No.3]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesUnitCost3
		{
			get{return _salesUnitCost3;}
			set{_salesUnitCost3 = value;}
		}

		/// public propaty name  :  StockRate3
		/// <summary>�d����[No.3]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����[No.3]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StockRate3
		{
			get{return _stockRate3;}
			set{_stockRate3 = value;}
		}

		/// public propaty name  :  OpenPriceDiv3
		/// <summary>�I�[�v�����i�敪[No.3]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�[�v�����i�敪[No.3]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OpenPriceDiv3
		{
			get{return _openPriceDiv3;}
			set{_openPriceDiv3 = value;}
		}

		/// public propaty name  :  OfferDate3
		/// <summary>�񋟓��t[No.3]�v���p�e�B</summary>
		/// <value>���i�}�X�^(���[�U�o�^��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟓��t[No.3]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDate3
		{
			get{return _offerDate3;}
			set{_offerDate3 = value;}
		}


		/// <summary>
		/// ���i�e�L�X�g�ϊ����o���ʃ��[�N�R���X�g���N�^
		/// </summary>
		/// <returns>GoodsUWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsUWork()
		{
		}

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GoodsUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUWork || graph is ArrayList || graph is GoodsUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsUWork).FullName));

            if (graph != null && graph is GoodsUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }else if (graph is GoodsUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUWork[])graph).Length;
            }
            else if (graph is GoodsUWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�艿(����)[���݉��i]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceNow
            //�艿(����)[�V���i]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceNew
            //���i�J�n��[�V���i]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDateNew
            //�d����[���݉��i]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRateNow
            //�����P��[���݉��i]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCostNow
            //���i�|�������N(�w��)
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRaterank
            //�������b�g
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierLot
            //���i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //���i���l�P
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //���i���l�Q
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //�񋟃f�[�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //���i�J�n��[No.1]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate1
            //�艿(����)[No.1]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice1
            //�����P��[No.1]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost1
            //�d����[No.1]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate1
            //�I�[�v�����i�敪[No.1]
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv1
            //�񋟓��t[No.1]
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate1
            //���i�J�n��[No.2]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate2
            //�艿(����)[No.2]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice2
            //�����P��[No.2]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost2
            //�d����[No.2]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate2
            //�I�[�v�����i�敪[No.2]
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv2
            //�񋟓��t[No.2]
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate2
            //���i�J�n��[No.3]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate3
            //�艿(����)[No.3]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice3
            //�����P��[No.3]
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost3
            //�d����[No.3]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate3
            //�I�[�v�����i�敪[No.3]
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv3
            //�񋟓��t[No.3]
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate3


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUWork)
            {
                GoodsUWork temp = (GoodsUWork)graph;

                SetGoodsUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUWork temp in lst)
                {
                    SetGoodsUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 38;

        /// <summary>
        ///  GoodsUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGoodsUWork(System.IO.BinaryWriter writer, GoodsUWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�艿(����)[���݉��i]
            writer.Write(temp.ListPriceNow);
            //�艿(����)[�V���i]
            writer.Write(temp.ListPriceNew);
            //���i�J�n��[�V���i]
            writer.Write(temp.PriceStartDateNew);
            //�d����[���݉��i]
            writer.Write(temp.StockRateNow);
            //�����P��[���݉��i]
            writer.Write(temp.SalesUnitCostNow);
            //���i�|�������N(�w��)
            writer.Write(temp.GoodsRaterank);
            //�������b�g
            writer.Write(temp.SupplierLot);
            //���i�K�i�E���L����
            writer.Write(temp.GoodsSpecialNote);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //���i���l�P
            writer.Write(temp.GoodsNote1);
            //���i���l�Q
            writer.Write(temp.GoodsNote2);
            //�񋟃f�[�^�敪
            writer.Write(temp.OfferDataDiv);
            //���i�J�n��[No.1]
            writer.Write(temp.PriceStartDate1);
            //�艿(����)[No.1]
            writer.Write(temp.ListPrice1);
            //�����P��[No.1]
            writer.Write(temp.SalesUnitCost1);
            //�d����[No.1]
            writer.Write(temp.StockRate1);
            //�I�[�v�����i�敪[No.1]
            writer.Write(temp.OpenPriceDiv1);
            //�񋟓��t[No.1]
            writer.Write(temp.OfferDate1);
            //���i�J�n��[No.2]
            writer.Write(temp.PriceStartDate2);
            //�艿(����)[No.2]
            writer.Write(temp.ListPrice2);
            //�����P��[No.2]
            writer.Write(temp.SalesUnitCost2);
            //�d����[No.2]
            writer.Write(temp.StockRate2);
            //�I�[�v�����i�敪[No.2]
            writer.Write(temp.OpenPriceDiv2);
            //�񋟓��t[No.2]
            writer.Write(temp.OfferDate2);
            //���i�J�n��[No.3]
            writer.Write(temp.PriceStartDate3);
            //�艿(����)[No.3]
            writer.Write(temp.ListPrice3);
            //�����P��[No.3]
            writer.Write(temp.SalesUnitCost3);
            //�d����[No.3]
            writer.Write(temp.StockRate3);
            //�I�[�v�����i�敪[No.3]
            writer.Write(temp.OpenPriceDiv3);
            //�񋟓��t[No.3]
            writer.Write(temp.OfferDate3);

        }

        /// <summary>
        ///  GoodsUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GoodsUWork GetGoodsUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsUWork temp = new GoodsUWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�艿(����)[���݉��i]
            temp.ListPriceNow = reader.ReadDouble();
            //�艿(����)[�V���i]
            temp.ListPriceNew = reader.ReadDouble();
            //���i�J�n��[�V���i]
            temp.PriceStartDateNew = reader.ReadInt32();
            //�d����[���݉��i]
            temp.StockRateNow = reader.ReadDouble();
            //�����P��[���݉��i]
            temp.SalesUnitCostNow = reader.ReadDouble();
            //�w�ʍX�V�敪
            temp.GoodsRaterank = reader.ReadString();
            //�������b�g
            temp.SupplierLot = reader.ReadInt32();
            //���i�K�i�E���L����
            temp.GoodsSpecialNote = reader.ReadString();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //���i���l�P
            temp.GoodsNote1 = reader.ReadString();
            //���i���l�Q
            temp.GoodsNote2 = reader.ReadString();
            //�񋟃f�[�^�敪
            temp.OfferDataDiv = reader.ReadInt32();
            //���i�J�n��[No.1]
            temp.PriceStartDate1 = reader.ReadInt32();
            //�艿(����)[No.1]
            temp.ListPrice1 = reader.ReadDouble();
            //�����P��[No.1]
            temp.SalesUnitCost1 = reader.ReadDouble();
            //�d����[No.1]
            temp.StockRate1 = reader.ReadDouble();
            //�I�[�v�����i�敪[No.1]
            temp.OpenPriceDiv1 = reader.ReadInt32();
            //�񋟓��t[No.1]
            temp.OfferDate1 = reader.ReadInt32();
            //���i�J�n��[No.2]
            temp.PriceStartDate2 = reader.ReadInt32();
            //�艿(����)[No.2]
            temp.ListPrice2 = reader.ReadDouble();
            //�����P��[No.2]
            temp.SalesUnitCost2 = reader.ReadDouble();
            //�d����[No.2]
            temp.StockRate2 = reader.ReadDouble();
            //�I�[�v�����i�敪[No.2]
            temp.OpenPriceDiv2 = reader.ReadInt32();
            //�񋟓��t[No.2]
            temp.OfferDate2 = reader.ReadInt32();
            //���i�J�n��[No.3]
            temp.PriceStartDate3 = reader.ReadInt32();
            //�艿(����)[No.3]
            temp.ListPrice3 = reader.ReadDouble();
            //�����P��[No.3]
            temp.SalesUnitCost3 = reader.ReadDouble();
            //�d����[No.3]
            temp.StockRate3 = reader.ReadDouble();
            //�I�[�v�����i�敪[No.3]
            temp.OpenPriceDiv3 = reader.ReadInt32();
            //�񋟓��t[No.3]
            temp.OfferDate3 = reader.ReadInt32();


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
        /// <returns>GoodsUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUWork temp = GetGoodsUWork(reader, serInfo);
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
                    retValue = (GoodsUWork[])lst.ToArray(typeof(GoodsUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
