using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OrderListCndtnWork
	/// <summary>
	///                      �����c�Ɖ�o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����c�Ɖ�o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OrderListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h�i�����w��j</summary>
		/// <remarks>�i�z��j�i�d�����ׁj</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n�����f�[�^�쐬��</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j(�d������)</remarks>
		private DateTime _st_OrderDataCreateDate;

		/// <summary>�I�������f�[�^�쐬��</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j(�d������)</remarks>
        private DateTime _ed_OrderDataCreateDate;

		/// <summary>�J�n���͓�</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j(�d��)</remarks>
        private DateTime _st_InputDay;

		/// <summary>�I�����͓�</summary>
		/// <remarks>YYYYMMDD�@�i�X�V�N�����j(�d��)</remarks>
        private DateTime _ed_InputDay;

		/// <summary>�d���S���҃R�[�h</summary>
		/// <remarks>�i�d�����ׁj</remarks>
		private string _stockAgentCode = "";

		/// <summary>�d�����͎҃R�[�h</summary>
		/// <remarks>�i�d�����ׁj</remarks>
		private string _stockInputCode = "";

		/// <summary>�d����R�[�h</summary>
		/// <remarks>�i�d�����ׁj</remarks>
		private Int32 _supplierCd;

		/// <summary>�q�ɃR�[�h</summary>
		/// <remarks>�i�d�����ׁj</remarks>
		private string _warehouseCode = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		/// <remarks>�i�d�����ׁj</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>�����ԍ�</summary>
		private string _orderNumber = "";

		/// <summary>�v��c�敪</summary>
		/// <remarks>0:�S��,1:�c����,2:�v��ς�</remarks>
		private Int32 _addUpRemDiv;

		/// <summary>�i��</summary>
		/// <remarks>�i�d�����ׁj</remarks>
		private string _goodsNo = "";

		/// <summary>�i�Ԍ����^�C�v</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
		private Int32 _goodsNoSrchTyp;

		/// <summary>�i��</summary>
		private string _goodsName = "";

		/// <summary>�i�������^�C�v</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
		private Int32 _goodsNameSrchTyp;

        /// <summary>���o�Ώۋ敪</summary>
        /// <remarks>0:�S��,1:��I�����C���� �݌Ɏd�����͂���Ă΂ꂽ�ꍇ��1���w��</remarks>
        private Int32 _searchDiv;

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

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
		/// <value>�i�z��j�i�d�����ׁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_OrderDataCreateDate
		/// <summary>�J�n�����f�[�^�쐬���v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j(�d������)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����f�[�^�쐬���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime St_OrderDataCreateDate
		{
			get{return _st_OrderDataCreateDate;}
			set{_st_OrderDataCreateDate = value;}
		}

		/// public propaty name  :  Ed_OrderDataCreateDate
		/// <summary>�I�������f�[�^�쐬���v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j(�d������)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������f�[�^�쐬���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime Ed_OrderDataCreateDate
		{
			get{return _ed_OrderDataCreateDate;}
			set{_ed_OrderDataCreateDate = value;}
		}

		/// public propaty name  :  St_InputDay
		/// <summary>�J�n���͓��v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j(�d��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime St_InputDay
		{
			get{return _st_InputDay;}
			set{_st_InputDay = value;}
		}

		/// public propaty name  :  Ed_InputDay
		/// <summary>�I�����͓��v���p�e�B</summary>
		/// <value>YYYYMMDD�@�i�X�V�N�����j(�d��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime Ed_InputDay
		{
			get{return _ed_InputDay;}
			set{_ed_InputDay = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
		/// <value>�i�d�����ׁj</value>
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

		/// public propaty name  :  StockInputCode
		/// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
		/// <value>�i�d�����ׁj</value>
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

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// <value>�i�d�����ׁj</value>
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

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
		/// <value>�i�d�����ׁj</value>
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
		/// <value>�i�d�����ׁj</value>
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

		/// public propaty name  :  AddUpRemDiv
		/// <summary>�v��c�敪�v���p�e�B</summary>
		/// <value>0:�S��,1:�c����,2:�v��ς�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��c�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddUpRemDiv
		{
			get{return _addUpRemDiv;}
			set{_addUpRemDiv = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>�i�ԃv���p�e�B</summary>
		/// <value>�i�d�����ׁj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsNoSrchTyp
		/// <summary>�i�Ԍ����^�C�v�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i�Ԍ����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNoSrchTyp
		{
			get{return _goodsNoSrchTyp;}
			set{_goodsNoSrchTyp = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>�i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  GoodsNameSrchTyp
		/// <summary>�i�������^�C�v�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i�������^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNameSrchTyp
		{
			get{return _goodsNameSrchTyp;}
			set{_goodsNameSrchTyp = value;}
		}

        /// public propaty name  :  SearchDiv
        /// <summary>���o�Ώۋ敪�v���p�e�B</summary>
        /// <value>0:�S��,1:��I�����C���� �݌Ɏd�����͂���Ă΂ꂽ�ꍇ��1���w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

		/// <summary>
		/// �����c�Ɖ�o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>OrderListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderListCndtnWork()
		{
		}

	}
}




