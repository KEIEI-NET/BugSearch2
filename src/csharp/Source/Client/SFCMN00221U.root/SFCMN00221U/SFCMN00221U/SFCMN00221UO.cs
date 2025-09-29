using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �X�[�p�[�X���C�_�[�N���p�����[�^
	/// </summary>
	public class SFCMN00221UAParam
	{
		private int _supplierDiv = 0;
		private int _customerDefaultEditType = 0;
		private int _stockSlipDefaultEditType = 0;
		private bool _showCustomerList = false;
		private bool _showStockSlipList = false;
		private int _xmlNo = 0;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFCMN00221UAParam()
		{
			//
		}

		/// <summary>
		/// �X�[�p�[�X���C�_�[�N���p�����[�^�R���X�g���N�^
		/// </summary>
		/// <param name="supplierDiv">�d����敪</param>
		/// <param name="customerDefaultEditType">���Ӑ挟���������o�����^�C�v</param>
		/// <param name="stockSlipDefaultEditType">�d���`�[�����������o�����^�C�v</param>
		/// <param name="showCustomerList">�ŋߎQ�Ƃ������Ӑ�\��</param>
		/// <param name="showStockSlipList">�ŋߎQ�Ƃ����d���`�[�\��</param>
		/// <param name="xmlNo">XML�ԍ�</param>
		public SFCMN00221UAParam(int supplierDiv, int customerDefaultEditType, int stockSlipDefaultEditType, bool showCustomerList, bool showStockSlipList, int xmlNo)
		{
			this.SupplierDiv = supplierDiv;
			this.CustomerDefaultEditType = customerDefaultEditType;
			this.StockSlipDefaultEditType = stockSlipDefaultEditType;
			this.ShowCustomerList = showCustomerList;
			this.ShowStockSlipList = showStockSlipList;
			this.XmlNo = xmlNo;
		}

		/// <summary>
		/// �d���`�[�����������o�����^�C�v�v���p�e�B
		/// </summary>
		/// <remarks>
		/// <br>SFCMN00221UI.EDIT_TYPE_StockDate = 1;		// �d����</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_InputDay = 2;	// �v���</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_SupplierSlipNo = 3;	// �`�[�ԍ�</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_StockAgentCode = 4;	// �d���S��</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CustomerCode = 5;	// �d����R�[�h</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CarrierEpCode = 6;	// ���Ǝ҃R�[�h</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_WarehouseCode = 7;	// �q�ɃR�[�h</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_PartySaleSlipNum = 8;// �����`��</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_GoodsCode = 9;		// ���i�R�[�h</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_StockTelNo1 = 10;	// ���i�d�b�ԍ�</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_ProductNumber1 = 11;	// �����ԍ�</br>
		/// </remarks>
		public int StockSlipDefaultEditType
		{
			get { return _stockSlipDefaultEditType; }
			set { _stockSlipDefaultEditType = value; }
		}

		/// <summary>
		/// ���Ӑ挟���������o�����^�C�v�v���p�e�B
		/// </summary>
		/// <remarks>
		/// <br>SFCMN00221UI.EDIT_TYPE_Kana = 1;			// ���Ӑ�J�i</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CustomerCode = 2;	// ���Ӑ�R�[�h</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CustomerSubCode = 4;	// ���Ӑ�T�u�R�[�h</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_SearchTelNo = 6;		// �����d�b�ԍ�</br>
		/// </remarks>
		public int CustomerDefaultEditType
		{
			get { return _customerDefaultEditType; }
			set { _customerDefaultEditType = value; }
		}

		/// <summary>
		/// �d����敪
		/// </summary>
		/// <remarks>
		/// <br>0 : �d����ȊO</br>
		/// <br>1 : �d����</br>
		/// </remarks>
		public int SupplierDiv
		{
			get { return _supplierDiv; }
			set { _supplierDiv = value; }
		}

		/// <summary>
		/// XML�ԍ�
		/// </summary>
		public int XmlNo
		{
			get { return _xmlNo; }
			set { _xmlNo = value; }
		}

		/// <summary>
		/// �ŋߎQ�Ƃ������Ӑ�\���v���p�e�B
		/// </summary>
		public bool ShowCustomerList
		{
			get
			{
				return this._showCustomerList;
			}
			set
			{
				this._showCustomerList = value;
			}
		}

		/// <summary>
		/// �ŋߎQ�Ƃ����d���`�[�\���v���p�e�B
		/// </summary>
		public bool ShowStockSlipList
		{
			get
			{
				return this._showStockSlipList;
			}
			set
			{
				this._showStockSlipList = value;
			}
		}

		/// <summary>
		/// �X�[�p�[�X���C�_�[�N���p�����[�^��������
		/// </summary>
		/// <returns>�X�[�p�[�X���C�_�[�N���p�����[�^�N���X�̃C���X�^���X</returns>
		public SFCMN00221UAParam Clone()
		{
			return new SFCMN00221UAParam(this._supplierDiv, this._customerDefaultEditType, this._stockSlipDefaultEditType, this._showCustomerList, this._showStockSlipList, this._xmlNo);
		}
	}
}
