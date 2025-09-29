using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMovePrtWork
    /// <summary>
    ///                      �݌Ɉړ��d�q���������������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɉړ��d�q���������������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMovePrtWork
    {
        /// <summary>�������</summary>
		/// <remarks>���������+1���Z�b�g</remarks>
		private Int64 _searchCnt;
        
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

        /// <summary>�o�͋敪</summary>
        private Int32 _outputDiv;

        /// <summary>���͋��_�R�[�h</summary>
        private string _inputSectionCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode;

        /// <summary>�J�n�o�ד�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_Date;

        /// <summary>�I���o�ד�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_Date;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>�݌Ɉړ��m��敪</remarks>
        private string _salesSlipNum = "";

        /// <summary>�J�n���͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_AddUpADate;

        /// <summary>�I�����͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_AddUpADate;

        /// <summary>�S����</summary>
        /// <remarks>�̔��]�ƈ��R�[�h</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�d����</summary>
        /// <remarks>�d����R�[�h</remarks>
        private Int32 _supplierCd;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>���i���[�J�[�R�[�h</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>�a�k�R�[�h</summary>
        /// <remarks>BL���i�R�[�h</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>�i��</summary>
        /// <remarks>���i�ԍ�</remarks>
        private string _goodsNo = "";

        /// <summary>�i��</summary>
        /// <remarks>���i����</remarks>
        private string _goodsName = "";

        /// <summary>�q�ɒI��[����]</summary>
        private string _warehouseShelfNo = "";

        /// <summary>���苒�_</summary>
        /// <remarks>��t�]�ƈ��R�[�h</remarks>
        private string _afSectionCode = "";

        /// <summary>����q��</summary>
        /// <remarks>������͎҃R�[�h</remarks>
        private string _afEnterWarehCode = "";

        /// <summary>���׋敪</summary>
        private Int32 _arrivalGoodsFlag;

        /// <summary>���l�P</summary>
        /// <remarks>�`�[���l</remarks>
        private string _slipNote = "";

        /// <summary>�폜�w��敪</summary>
        /// <remarks>�ԑ�ԍ��i�����p�j</remarks>
        private Int32 _deleteFlag;

        /// <summary>�݌Ɉړ��m��敪</summary>
        private Int32 _stockMoveFixCode;

        /// <remarks>�`�[�敪</remarks>
        private Int32 _salesSlipDiv;


		/// public propaty name  :  SearchCnt
		/// <summary>��������v���p�e�B</summary>
		/// <value>���������+1���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SearchCnt
		{
			get{return _searchCnt;}
			set{_searchCnt = value;}
		}

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

        /// public propaty name  :  InputSectionCode
        /// <summary>�o�͋敪�v���p�e�B</summary>
        /// <value>�o�͋敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>  
        public Int32 OutputDiv
        {
            get { return _outputDiv; }
            set { _outputDiv = value; }
        }

        /// public propaty name  :  InputSectionCode
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// <value>���͋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>  
        public string InputSectionCode
        {
            get { return _inputSectionCode; }
            set { _inputSectionCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>  
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
 
        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q�ɃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _outputDiv;}
			set{_outputDiv = value;}
		}

		/// public propaty name  :  ArrivalGoodsFlag
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ArrivalGoodsFlag
		{
			get{return _arrivalGoodsFlag;}
			set{_arrivalGoodsFlag = value;}
		}

		/// public propaty name  :  St_Date
		/// <summary>�J�n������t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_Date
		{
			get{return _st_Date;}
			set{_st_Date = value;}
		}

		/// public propaty name  :  Ed_Date
		/// <summary>�I��������t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_Date
		{
			get{return _ed_Date;}
			set{_ed_Date = value;}
		}

		/// public propaty name  :  St_AddUpADate
		/// <summary>�J�n���͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddUpADate
		/// <summary>�I�����͓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_AddUpADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>�`�[�ԍ��v���p�e�B</summary>
		/// <value>�݌Ɉړ��m��敪</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesEmployeeCd
		/// <summary>�S���҃v���p�e�B</summary>
		/// <value>�̔��]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���҃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeCd
		{
			get{return _salesEmployeeCd;}
			set{_salesEmployeeCd = value;}
		}

		/// public propaty name  :  AfSectionCode
		/// <summary>���苒�_�v���p�e�B</summary>
		/// <value>��t�]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���苒�_�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfSectionCode
		{
			get{return _afSectionCode;}
			set{_afSectionCode = value;}
		}

		/// public propaty name  :  AfEnterWarehCode
		/// <summary>����q�Ƀv���p�e�B</summary>
		/// <value>������͎҃R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����q�Ƀv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AfEnterWarehCode
		{
			get{return _afEnterWarehCode;}
			set{_afEnterWarehCode = value;}
		}

		/// public propaty name  :  DeleteFlag
		/// <summary>�폜�w��敪�v���p�e�B</summary>
        /// <value>�폜�w��敪�i�����p�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �폜�w��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DeleteFlag
		{
			get{return _deleteFlag;}
			set{_deleteFlag = value;}
		}

       	/// public propaty name  :  SlipNote
		/// <summary>���l�P�v���p�e�B</summary>
		/// <value>�`�[���l</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>�a�k�R�[�h�v���p�e�B</summary>
		/// <value>BL���i�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>�i���v���p�e�B</summary>
		/// <value>���i����</value>
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

		/// public propaty name  :  GoodsNo
		/// <summary>�i�ԃv���p�e�B</summary>
		/// <value>���i�ԍ�</value>
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>���i���[�J�[�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����v���p�e�B</summary>
		/// <value>�d����R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>�q�ɒI��[����]�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI��[����]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

        /// public propaty name  :  StockMoveFixCode
        /// <summary>�݌Ɉړ��m��敪�v���p�e�B</summary>
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

        /// public propaty name  :  SalesSlipDiv
        /// <summary>�`�[�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipDiv
        {
            get { return _salesSlipDiv; }
            set { _salesSlipDiv = value; }
        }

        /// <summary>
        /// �݌Ɉړ��d�q������������(�c���E�`�[�E����)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMovePrtWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMovePrtWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMovePrtWork()
        {
        }

    }

}