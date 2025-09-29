using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OrderPointOrderCndtnWork
	/// <summary>
	///                      �����_�������o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����_�������o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008.12.10  �a�J�@���</br>
    /// <br>                 :   ���[�^�C�v�敪�ǉ�</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OrderPointOrderCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h�i�����w��j</summary>
		private string[] _sectionCodes;

		/// <summary>�J�n�q�ɃR�[�h</summary>
		private string _st_WarehouseCode = "";

		/// <summary>�I���q�ɃR�[�h</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>�q�Ɏw��i�����w��j</summary>
		/// <remarks>null�̏ꍇ�́A�J�n�I���͈͎w����g�p</remarks>
		private string[] _warehouseCodes;

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _st_SupplierCode;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _ed_SupplierCode;

		/// <summary>�d����w��i�����w��</summary>
		/// <remarks>null�̏ꍇ�́A�J�n�I���͈͎w����g�p</remarks>
		private Int32[] _supplierCodes;

		/// <summary>����݌ɋ敪</summary>
		/// <remarks>0:�����ΏۂƂ��Ȃ�,1:�����ΏۂƂ���</remarks>
		private Int32 _trustStockDiv;

		/// <summary>�Ώۋ敪</summary>
		/// <remarks>0:�S��,1:UOE������,2:UOE�����ȊO</remarks>
		private Int32 _objDiv;

		/// <summary>UOE�ȊO�����c�X�V</summary>
		/// <remarks>0:����,���Ȃ�</remarks>
		private Int32 _orderRemainUpDate;

		/// <summary>���݌ɐ��</summary>
        /// <remarks>0:ϲŽ�;�ۂŌv�Z,1:ϲŽ���܂߂Čv�Z</remarks>
        private Int32 _stkCntStandard;

        /// <summary>�����</summary>
        /// <remarks>0:�Œ�݌�,1:�ō��݌�</remarks>
        private Int32 _orderStandard;
        
        /// <summary>�ݏo���v�Z</summary>
		/// <remarks>0:����,���Ȃ�</remarks>
		private Int32 _lendCntCalc;

        /// <summary>���[�^�C�v�敪</summary>
        /// <remarks>0:�����ꗗ�\,1:�����c�ꗗ�\</remarks>
        private Int32 _prtPaperTypeDiv;

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

		/// public propaty name  :  St_WarehouseCode
		/// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  WarehouseCodes
		/// <summary>�q�Ɏw��i�����w��j�v���p�e�B</summary>
		/// <value>null�̏ꍇ�́A�J�n�I���͈͎w����g�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�Ɏw��i�����w��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] WarehouseCodes
		{
			get{return _warehouseCodes;}
			set{_warehouseCodes = value;}
		}

		/// public propaty name  :  St_SupplierCode
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_SupplierCode
		{
			get{return _st_SupplierCode;}
			set{_st_SupplierCode = value;}
		}

		/// public propaty name  :  Ed_SupplierCode
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_SupplierCode
		{
			get{return _ed_SupplierCode;}
			set{_ed_SupplierCode = value;}
		}

		/// public propaty name  :  SupplierCodes
		/// <summary>�d����w��i�����w��v���p�e�B</summary>
		/// <value>null�̏ꍇ�́A�J�n�I���͈͎w����g�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����w��i�����w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] SupplierCodes
		{
			get{return _supplierCodes;}
			set{_supplierCodes = value;}
		}

		/// public propaty name  :  TrustStockDiv
		/// <summary>����݌ɋ敪�v���p�e�B</summary>
		/// <value>0:�����ΏۂƂ��Ȃ�,1:�����ΏۂƂ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����݌ɋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TrustStockDiv
		{
			get{return _trustStockDiv;}
			set{_trustStockDiv = value;}
		}

		/// public propaty name  :  ObjDiv
		/// <summary>�Ώۋ敪�v���p�e�B</summary>
		/// <value>0:�S��,1:UOE������,2:UOE�����ȊO</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ώۋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ObjDiv
		{
			get{return _objDiv;}
			set{_objDiv = value;}
		}

		/// public propaty name  :  OrderRemainUpDate
		/// <summary>UOE�ȊO�����c�X�V�v���p�e�B</summary>
		/// <value>0:����,���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE�ȊO�����c�X�V�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderRemainUpDate
		{
			get{return _orderRemainUpDate;}
			set{_orderRemainUpDate = value;}
		}

        /// public propaty name  :  OrderStandard
        /// <summary>���݌ɐ���v���p�e�B</summary>
        /// <value>0:ϲŽ�;�ۂŌv�Z,1:ϲŽ���܂߂Čv�Z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StkCntStandard
        {
            get { return _stkCntStandard; }
            set { _stkCntStandard = value; }
        }

        /// public propaty name  :  OrderStandard
		/// <summary>������v���p�e�B</summary>
		/// <value>0:�Œ�݌�,1:�ō��݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderStandard
		{
			get{return _orderStandard;}
			set{_orderStandard = value;}
		}

        /// public propaty name  :  LendCntCalc
		/// <summary>�ݏo���v�Z�v���p�e�B</summary>
		/// <value>0:����,���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݏo���v�Z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LendCntCalc
		{
			get{return _lendCntCalc;}
			set{_lendCntCalc = value;}
		}

        /// public propaty name  :  PrtPaperTypeDiv
        /// <summary>���[�^�C�v�敪�v���p�e�B</summary>
        /// <value>0:�����ꗗ�\,1:�����c�ꗗ�\</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtPaperTypeDiv
        {
            get { return _prtPaperTypeDiv; }
            set { _prtPaperTypeDiv = value; }
        }


		/// <summary>
		/// �����_�������o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>OrderPointOrderCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderPointOrderCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderPointOrderCndtnWork()
		{
		}

	}
}




