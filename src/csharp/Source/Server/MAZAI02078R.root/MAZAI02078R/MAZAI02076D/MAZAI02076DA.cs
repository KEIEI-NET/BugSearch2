using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockListCndtnWork
	/// <summary>
	///                      �݌Ɉꗗ�\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɉꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _depositStockSecCodeList;

		/// <summary>�݌ɓo�^��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>�݌ɓo�^�������t���O</summary>
		/// <remarks>0:�ȑO 1:�ȍ~</remarks>
		private Int32 _stockCreateDateFlg;

		/// <summary>�J�n�o�׉\��</summary>
		private Double _st_ShipmentPosCnt;

		/// <summary>�I���o�׉\��</summary>
		private Double _ed_ShipmentPosCnt;

		/// <summary>���i�Ǘ��敪�P</summary>
		private string[] _partsManagementDivide1;

		/// <summary>���i�Ǘ��敪�Q</summary>
		private string[] _partsManagementDivide2;

		/// <summary>�J�n�ŏI�d���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_LastStockDate;

		/// <summary>�I���ŏI�d���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_LastStockDate;

		/// <summary>�J�n�q�ɃR�[�h</summary>
		private string _st_WarehouseCode = "";

		/// <summary>�I���q�ɃR�[�h</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>�J�n�݌ɔ�����R�[�h</summary>
		private Int32 _st_StockSupplierCode;

		/// <summary>�I���݌ɔ�����R�[�h</summary>
		private Int32 _ed_StockSupplierCode;

		/// <summary>�J�n�q�ɒI��</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>�I���q�ɒI��</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>�J�n���[�J�[�R�[�h</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>�I�����[�J�[�R�[�h</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>�J�nBL���i�R�[�h</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>�I��BL���i�R�[�h</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>�J�n���i�ԍ�</summary>
		private string _st_GoodsNo = "";

		/// <summary>�I�����i�ԍ�</summary>
		private string _ed_GoodsNo = "";


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

		/// public propaty name  :  DepositStockSecCodeList
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] DepositStockSecCodeList
		{
			get{return _depositStockSecCodeList;}
			set{_depositStockSecCodeList = value;}
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

		/// public propaty name  :  StockCreateDateFlg
		/// <summary>�݌ɓo�^�������t���O�v���p�e�B</summary>
		/// <value>0:�ȑO 1:�ȍ~</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɓo�^�������t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCreateDateFlg
		{
			get{return _stockCreateDateFlg;}
			set{_stockCreateDateFlg = value;}
		}

		/// public propaty name  :  St_ShipmentPosCnt
		/// <summary>�J�n�o�׉\���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�o�׉\���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double St_ShipmentPosCnt
		{
			get{return _st_ShipmentPosCnt;}
			set{_st_ShipmentPosCnt = value;}
		}

		/// public propaty name  :  Ed_ShipmentPosCnt
		/// <summary>�I���o�׉\���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���o�׉\���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double Ed_ShipmentPosCnt
		{
			get{return _ed_ShipmentPosCnt;}
			set{_ed_ShipmentPosCnt = value;}
		}

		/// public propaty name  :  PartsManagementDivide1
		/// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] PartsManagementDivide1
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
		public string[] PartsManagementDivide2
		{
			get{return _partsManagementDivide2;}
			set{_partsManagementDivide2 = value;}
		}

		/// public propaty name  :  St_LastStockDate
		/// <summary>�J�n�ŏI�d���N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�ŏI�d���N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime St_LastStockDate
		{
			get{return _st_LastStockDate;}
			set{_st_LastStockDate = value;}
		}

		/// public propaty name  :  Ed_LastStockDate
		/// <summary>�I���ŏI�d���N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���ŏI�d���N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime Ed_LastStockDate
		{
			get{return _ed_LastStockDate;}
			set{_ed_LastStockDate = value;}
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

		/// public propaty name  :  St_StockSupplierCode
		/// <summary>�J�n�݌ɔ�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�݌ɔ�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_StockSupplierCode
		{
			get{return _st_StockSupplierCode;}
			set{_st_StockSupplierCode = value;}
		}

		/// public propaty name  :  Ed_StockSupplierCode
		/// <summary>�I���݌ɔ�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���݌ɔ�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_StockSupplierCode
		{
			get{return _ed_StockSupplierCode;}
			set{_ed_StockSupplierCode = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>�J�n�q�ɒI�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�q�ɒI�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>�I���q�ɒI�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���q�ɒI�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
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


		/// <summary>
		/// �݌Ɉꗗ�\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockListCndtnWork()
		{
		}

	}
}




