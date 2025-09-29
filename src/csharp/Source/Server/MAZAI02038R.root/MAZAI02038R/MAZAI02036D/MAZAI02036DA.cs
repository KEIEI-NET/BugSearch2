using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockMoveListCndtnWork
	/// <summary>
	///                      �݌ɁE�q�Ɉړ��m�F�\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɁE�q�Ɉړ��m�F�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockMoveListCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>����o�׋��_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _bfAfSectionCd;

		/// <summary>��J�n���o�בq�ɃR�[�h</summary>
		private string _st_MainBfAfEnterWarehCd = "";

		/// <summary>��I�����o�בq�ɃR�[�h</summary>
		private string _ed_MainBfAfEnterWarehCd = "";

		/// <summary>�݌Ɉړ��`��</summary>
		private Int32 _stockMoveFormalDiv;

		/// <summary>�J�n�`�[���t</summary>
		/// <remarks>1:�݌Ɉړ�,2:�q�Ɉړ�</remarks>
		private DateTime _st_ShipArrivalDate;

		/// <summary>�I���`�[���t</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ed_ShipArrivalDate;

		/// <summary>�J�n���͓��t</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_CreateDate;

		/// <summary>�I�����͓��t</summary>
		private DateTime _ed_CreateDate;

		/// <summary>�J�n���o�׋��_�R�[�h</summary>
		private string _st_ShipArrivalSectionCd = "";

		/// <summary>�I�����o�׋��_�R�[�h</summary>
		private string _ed_ShipArrivalSectionCd = "";

		/// <summary>�J�n���o�בq�ɃR�[�h</summary>
		private string _st_ShipArrivalEnterWarehCd = "";

		/// <summary>�I�����o�בq�ɃR�[�h</summary>
		private string _ed_ShipArrivalEnterWarehCd = "";

		/// <summary>�J�n�݌Ɉړ����͏]�ƈ��R�[�h</summary>
		private string _st_StockMvEmpCode = "";

		/// <summary>�I���݌Ɉړ����͏]�ƈ��R�[�h</summary>
		private string _ed_StockMvEmpCode = "";

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _st_SupplierCd;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _ed_SupplierCd;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:�o��,1:����,2�F�S��</remarks>
		private Int32 _printType;

		/// <summary>�o�͎w��</summary>
		/// <remarks>0:���o�͕�,1:�o�͍ϕ�,-1�F�S��</remarks>
		private Int32 _outputDesignat;

        /// <summary>�݌Ɉړ��m��敪</summary>
        /// <remarks>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </remarks>
        private Int32 _stockMoveFixCode;

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

		/// public propaty name  :  BfAfSectionCd
		/// <summary>����o�׋��_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����o�׋��_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] BfAfSectionCd
		{
			get{return _bfAfSectionCd;}
			set{_bfAfSectionCd = value;}
		}

		/// public propaty name  :  St_MainBfAfEnterWarehCd
		/// <summary>��J�n���o�בq�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��J�n���o�בq�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_MainBfAfEnterWarehCd
		{
			get{return _st_MainBfAfEnterWarehCd;}
			set{_st_MainBfAfEnterWarehCd = value;}
		}

		/// public propaty name  :  Ed_MainBfAfEnterWarehCd
		/// <summary>��I�����o�בq�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��I�����o�בq�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_MainBfAfEnterWarehCd
		{
			get{return _ed_MainBfAfEnterWarehCd;}
			set{_ed_MainBfAfEnterWarehCd = value;}
		}

		/// public propaty name  :  StockMoveFormalDiv
		/// <summary>�݌Ɉړ��`���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌Ɉړ��`���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockMoveFormalDiv
		{
			get{return _stockMoveFormalDiv;}
			set{_stockMoveFormalDiv = value;}
		}

		/// public propaty name  :  St_ShipArrivalDate
		/// <summary>�J�n�`�[���t�v���p�e�B</summary>
		/// <value>1:�݌Ɉړ�,2:�q�Ɉړ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�`�[���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_ShipArrivalDate
		{
			get{return _st_ShipArrivalDate;}
			set{_st_ShipArrivalDate = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalDate
		/// <summary>�I���`�[���t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���`�[���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_ShipArrivalDate
		{
			get{return _ed_ShipArrivalDate;}
			set{_ed_ShipArrivalDate = value;}
		}

		/// public propaty name  :  St_CreateDate
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_CreateDate
		{
			get{return _st_CreateDate;}
			set{_st_CreateDate = value;}
		}

		/// public propaty name  :  Ed_CreateDate
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_CreateDate
		{
			get{return _ed_CreateDate;}
			set{_ed_CreateDate = value;}
		}

		/// public propaty name  :  St_ShipArrivalSectionCd
		/// <summary>�J�n���o�׋��_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���o�׋��_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_ShipArrivalSectionCd
		{
			get{return _st_ShipArrivalSectionCd;}
			set{_st_ShipArrivalSectionCd = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalSectionCd
		/// <summary>�I�����o�׋��_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����o�׋��_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_ShipArrivalSectionCd
		{
			get{return _ed_ShipArrivalSectionCd;}
			set{_ed_ShipArrivalSectionCd = value;}
		}

		/// public propaty name  :  St_ShipArrivalEnterWarehCd
		/// <summary>�J�n���o�בq�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���o�בq�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_ShipArrivalEnterWarehCd
		{
			get{return _st_ShipArrivalEnterWarehCd;}
			set{_st_ShipArrivalEnterWarehCd = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalEnterWarehCd
		/// <summary>�I�����o�בq�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����o�בq�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_ShipArrivalEnterWarehCd
		{
			get{return _ed_ShipArrivalEnterWarehCd;}
			set{_ed_ShipArrivalEnterWarehCd = value;}
		}

		/// public propaty name  :  St_StockMvEmpCode
		/// <summary>�J�n�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_StockMvEmpCode
		{
			get{return _st_StockMvEmpCode;}
			set{_st_StockMvEmpCode = value;}
		}

		/// public propaty name  :  Ed_StockMvEmpCode
		/// <summary>�I���݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_StockMvEmpCode
		{
			get{return _ed_StockMvEmpCode;}
			set{_ed_StockMvEmpCode = value;}
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

		/// public propaty name  :  PrintType
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:�o��,1:����,2�F�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintType
		{
			get{return _printType;}
			set{_printType = value;}
		}

		/// public propaty name  :  OutputDesignat
		/// <summary>�o�͎w��v���p�e�B</summary>
		/// <value>0:���o�͕�,1:�o�͍ϕ�,-1�F�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͎w��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutputDesignat
		{
			get{return _outputDesignat;}
			set{_outputDesignat = value;}
		}

        /// public propaty name  :  StockMoveFixCode
        /// <summary>�݌Ɉړ��m��敪�v���p�e�B</summary>
        /// <value>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��m��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

		/// <summary>
		/// �݌ɁE�q�Ɉړ��m�F�\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockMoveListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMoveListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockMoveListCndtnWork()
		{
		}

	}

}




