using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockShipArrivalListCndtnWork
	/// <summary>
	///                      �݌ɓ��o�׈ꗗ�\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɓ��o�׈ꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockShipArrivalListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>�݌ɓo�^��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>�݌ɓo�^���w��敪</summary>
		/// <remarks>0:�ȑO 1:�ȍ~</remarks>
		private Int32 _stockCreateDateDiv;

		/// <summary>����^�C�v</summary>
		/// <remarks>0:�o�ׁ�����, 1:�o��, 2:����</remarks>
		private Int32 _shipArrivalPrintDiv;

		/// <summary>�o�א��w��敪</summary>
		/// <remarks>0:�o�ׁ�����, 1:�o��, 2:����</remarks>
		private Int32 _shipArrivalCntDiv;

		/// <summary>�J�n���o�א�</summary>
		/// <remarks>(�ȏ�)</remarks>
		private Int32 _st_ShipArrivalCnt;

		/// <summary>�I�����o�א�</summary>
		/// <remarks>(�ȉ�)</remarks>
		private Int32 _ed_ShipArrivalCnt;

		/// <summary>�J�n�N���x</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���N���x</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>�J�n�q�ɃR�[�h</summary>
		private string _st_WarehouseCode = "";

		/// <summary>�I���q�ɃR�[�h</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _st_SupplierCd;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _ed_SupplierCd;

		/// <summary>�J�n���i���[�J�[�R�[�h</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>�I�����i���[�J�[�R�[�h</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>�J�nBL���i�R�[�h</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>�I��BL���i�R�[�h</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>�J�n���i�ԍ�</summary>
		private string _st_GoodsNo = "";

		/// <summary>�I�����i�ԍ�</summary>
		private string _ed_GoodsNo = "";

		/// <summary>�J�n���i�敪</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>�I�����i�敪</summary>
		private Int32 _ed_EnterpriseGanreCode;

        /// <summary>�J�n���i�啪��</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>�I�����i�啪��</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>�J�n���i������</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>�I�����i������</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�I���O���[�v�R�[�h</summary>
        private Int32 _ed_BLGroupCode;


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
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  StockCreateDate
		/// <summary>�݌ɓo�^���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɓo�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StockCreateDate
		{
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  StockCreateDateDiv
		/// <summary>�݌ɓo�^���w��敪�v���p�e�B</summary>
		/// <value>0:�ȑO 1:�ȍ~</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɓo�^���w��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCreateDateDiv
		{
			get{return _stockCreateDateDiv;}
			set{_stockCreateDateDiv = value;}
		}

		/// public propaty name  :  ShipArrivalPrintDiv
		/// <summary>����^�C�v�v���p�e�B</summary>
		/// <value>0:�o�ׁ�����, 1:�o��, 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipArrivalPrintDiv
		{
			get{return _shipArrivalPrintDiv;}
			set{_shipArrivalPrintDiv = value;}
		}

		/// public propaty name  :  ShipArrivalCntDiv
		/// <summary>�o�א��w��敪�v���p�e�B</summary>
		/// <value>0:�o�ׁ�����, 1:�o��, 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�א��w��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipArrivalCntDiv
		{
			get{return _shipArrivalCntDiv;}
			set{_shipArrivalCntDiv = value;}
		}

		/// public propaty name  :  St_ShipArrivalCnt
		/// <summary>�J�n���o�א��v���p�e�B</summary>
		/// <value>(�ȏ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���o�א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_ShipArrivalCnt
		{
			get{return _st_ShipArrivalCnt;}
			set{_st_ShipArrivalCnt = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalCnt
		/// <summary>�I�����o�א��v���p�e�B</summary>
		/// <value>(�ȉ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����o�א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_ShipArrivalCnt
		{
			get{return _ed_ShipArrivalCnt;}
			set{_ed_ShipArrivalCnt = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�N���x�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�N���x�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>�I���N���x�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���N���x�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
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

		/// public propaty name  :  St_SupplierCd
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_SupplierCd
		{
			get{return _st_SupplierCd;}
			set{_st_SupplierCd = value;}
		}

		/// public propaty name  :  Ed_SupplierCd
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_SupplierCd
		{
			get{return _ed_SupplierCd;}
			set{_ed_SupplierCd = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>�J�n���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>�I�����i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>�J�n���i�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>�I�����i�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}


        /// public propaty name  :  St_GoodsLGroup
        /// <summary>�J�n���i�啪�ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�啪�ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsLGroup
        /// <summary>�I�����i�啪�ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�啪�ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>�J�n���i�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>�I�����i�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

		/// <summary>
		/// �݌ɓ��o�׈ꗗ�\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockShipArrivalListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockShipArrivalListCndtnWork()
		{
		}

	}
}