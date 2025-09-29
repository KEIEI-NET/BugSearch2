using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockAcPayHistWork
	/// <summary>
	///                      �݌Ɏ󕥗����f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɏ󕥗����f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2010/02/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/30  ����</br>
	/// <br>                 :   �c�c���C��</br>
	/// <br>                 :   BL���i�R�[�h���́i�S�p�j</br>
	/// <br>                 :   BLGoodsFullName �� BLGoodsFullNameRF</br>
	/// <br>Update Note      :   2008/6/30  ����</br>
	/// <br>                 :   �󕥌�����敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v�ǉ�</br>
	/// <br>Update Note      :   2008/8/22  ����</br>
	/// <br>                 :   �󕥌��`�[�敪�̕⑫��</br>
	/// <br>                 :   �u13:�݌Ɏd���v�ǉ�</br>
	/// <br>Update Note      :   2008/10/09  ����</br>
	/// <br>                 :   �󕥌��`�[�敪�̕⑫��</br>
	/// <br>                 :   �u60:�g��,61:����,70:��[�v�ǉ�</br>
	/// <br>Update Note      :   2008/10/14  ����</br>
	/// <br>                 :   �󕥌��`�[�敪�̕⑫�ύX</br>
	/// <br>                 :   �u70:��[�v�ˁu70:��[����,70:��[�o�Ɂv</br>
	/// <br>Update Note      :   2008/10/30  ����</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,11,12,13,14 �� 3,11,12,13,14,24,26,32</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockAcPayHistWork
	{
		/// <summary>���o�ד�</summary>
        private DateTime _ioGoodsDay;

		/// <summary>�v����t</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpADate;

		/// <summary>���i���[�J�[�R�[�h</summary>
		/// <remarks>�񋟔͈͂̓v���_�N�g���Œ�`</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>�q�ɃR�[�h</summary>
		/// <remarks>�o�ׁA���ׂ���������q��</remarks>
		private string _warehouseCode = "";

		/// <summary>���א�</summary>
		/// <remarks>�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g</remarks>
		private Double _arrivalCnt;

		/// <summary>�o�א�</summary>
		/// <remarks>������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g</remarks>
		private Double _shipmentCnt;

		/// public propaty name  :  IoGoodsDay
		/// <summary>���o�ד��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�ד��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime IoGoodsDay
		{
			get{return _ioGoodsDay;}
			set{_ioGoodsDay = value;}
		}

		/// public propaty name  :  AddUpADate
		/// <summary>�v����t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v����t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>�񋟔͈͂̓v���_�N�g���Œ�`</value>
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

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
		/// <value>�o�ׁA���ׂ���������q��</value>
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

		/// public propaty name  :  ArrivalCnt
		/// <summary>���א��v���p�e�B</summary>
		/// <value>�d�����́A�݌Ɉړ��i���ׁj�A�݌ɒ����A�I�������ɃZ�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���א��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ArrivalCnt
		{
			get{return _arrivalCnt;}
			set{_arrivalCnt = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>�o�א��v���p�e�B</summary>
		/// <value>������́A�݌Ɉړ��i�o�ׁj���ɃZ�b�g</value>
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

		/// <summary>
		/// �݌Ɏ󕥗����f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockAcPayHistWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAcPayHistWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAcPayHistWork()
		{
		}

	}
}
