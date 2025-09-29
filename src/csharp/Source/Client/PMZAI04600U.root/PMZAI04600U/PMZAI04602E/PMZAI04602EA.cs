//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q������������
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockMovePpr
	/// <summary>
	///                      �݌Ɉړ��d�q������������
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɉړ��d�q�������������w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// </remarks>
	public class StockMovePpr
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
		/// �݌Ɉړ��d�q�������������R���X�g���N�^
		/// </summary>
		/// <returns>StockMovePpr�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMovePpr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockMovePpr()
		{
           
		}

        /// <summary>
        /// �݌Ɉړ��d�q�������������R���X�g���N�^
        /// </summary>
        /// <param name="searchCnt">�������(���������+1���Z�b�g)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="outputDiv">�o�͋敪</param>
        /// <param name="inputSectionCode">���͋��_</param>
        /// <param name="sectionCode">���_</param>
        /// <param name="warehouseCode">�q��</param>
        /// <param name="st_Date">�J�n���ד��t(YYYYMMDD)</param>
        /// <param name="ed_Date">�I�����ד��t(YYYYMMDD)</param>
        /// <param name="salesSlipNum">�`�[�ԍ�(�݌Ɉړ��m��敪)</param>
        /// <param name="st_AddUpADate">�J�n���͓��t(YYYYMMDD)</param>
        /// <param name="ed_AddUpADate">�I�����͓��t(YYYYMMDD)</param>
        /// <param name="salesEmployeeCd">�S����(�̔��]�ƈ��R�[�h)</param>
        /// <param name="supplierCd">�d����(�d����R�[�h)</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h(���i���[�J�[�R�[�h)</param>
        /// <param name="bLGoodsCode">�a�k�R�[�h(BL���i�R�[�h)</param>
        /// <param name="goodsNo">�i��(���i�ԍ�)</param>
        /// <param name="goodsName">��(���i����)</param>
        /// <param name="warehouseShelfNo">�q�ɒI��[����]</param>
        /// <param name="afSectionCode">���苒�_(��t�]�ƈ��R�[�h)</param>
        /// <param name="afEnterWarehCode">����q��(������͎҃R�[�h)</param>
        /// <param name="arrivalGoodsFlag">���׋敪</param>
        /// <param name="slipNote">���l�P</param>
        /// <param name="deleteFlag">�폜�w��敪</param>
        /// <param name="stockMoveFixCode">�݌Ɉړ��m��敪</param>
        /// <param name="salesSlipDiv">�`�[�敪</param>
        public StockMovePpr(Int64 searchCnt, string enterpriseCode, Int32 outputDiv, string inputSectionCode, string sectionCode, string warehouseCode, DateTime st_Date, DateTime ed_Date, string salesSlipNum, DateTime st_AddUpADate, DateTime ed_AddUpADate, string salesEmployeeCd, Int32 supplierCd, Int32 goodsMakerCd, Int32 bLGoodsCode, string goodsNo, string goodsName, string warehouseShelfNo, string afSectionCode, string afEnterWarehCode, Int32 arrivalGoodsFlag, string slipNote, Int32 deleteFlag, Int32 stockMoveFixCode, Int32 salesSlipDiv)
        {
            this._searchCnt = searchCnt;
            this._enterpriseCode = enterpriseCode;
            this._outputDiv = outputDiv;
            this._inputSectionCode = inputSectionCode;
            this._sectionCode = sectionCode;
            this._warehouseCode = warehouseCode;
            this._st_Date = st_Date;
            this._ed_Date = ed_Date;
            this._salesSlipNum = salesSlipNum;
            this._st_AddUpADate = st_AddUpADate;
            this._ed_AddUpADate = ed_AddUpADate;
            this._salesEmployeeCd = salesEmployeeCd;
            this._supplierCd = supplierCd;
            this._goodsMakerCd = goodsMakerCd;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._afSectionCode = afSectionCode;
            this._afEnterWarehCode = afEnterWarehCode;
            this._arrivalGoodsFlag = arrivalGoodsFlag;
            this._slipNote = slipNote;
            this._deleteFlag = deleteFlag;
            this._stockMoveFixCode = stockMoveFixCode;
            this._salesSlipDiv = salesSlipDiv;
		}

		/// <summary>
		/// �݌Ɉړ��d�q��������������������
		/// </summary>
		/// <returns>StockMovePpr�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockMovePpr�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockMovePpr Clone()
		{
            return new StockMovePpr(_searchCnt, _enterpriseCode, _outputDiv, _inputSectionCode, _sectionCode, _warehouseCode, _st_Date, _ed_Date, _salesSlipNum, _st_AddUpADate, _ed_AddUpADate, _salesEmployeeCd, _supplierCd, _goodsMakerCd, _bLGoodsCode, _goodsNo, _goodsName, _warehouseShelfNo, _afSectionCode, _afEnterWarehCode, _arrivalGoodsFlag, _slipNote, _deleteFlag, _stockMoveFixCode, _salesSlipDiv);
		}

		/// <summary>
		/// �݌Ɉړ��d�q��������������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockMovePpr�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMovePpr�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockMovePpr target)
		{
            return ((this.SearchCnt == target.SearchCnt)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.OutputDiv == target.OutputDiv)
                && (this.InputSectionCode == target.InputSectionCode)
                && (this.SectionCode == target.SectionCode)
                && (this.WarehouseCode == target.WarehouseCode)
                && (this.St_Date == target.St_Date)
                && (this.Ed_Date == target.Ed_Date)
                && (this.SalesSlipNum == target.SalesSlipNum)
                && (this.St_AddUpADate == target.St_AddUpADate)
                && (this.Ed_AddUpADate == target.Ed_AddUpADate)
                && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                && (this.SupplierCd == target.SupplierCd)
                && (this.GoodsMakerCd == target.GoodsMakerCd)
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.GoodsNo == target.GoodsNo)
                && (this.GoodsName == target.GoodsName)
                && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                && (this.AfSectionCode == target.AfSectionCode)
                && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                && (this.ArrivalGoodsFlag == target.ArrivalGoodsFlag)
                && (this.SlipNote == target.SlipNote)
                && (this.DeleteFlag == target.DeleteFlag)
                && (this.StockMoveFixCode == target.StockMoveFixCode)
                && (this.SalesSlipDiv == target.SalesSlipDiv));
		}

		/// <summary>
		/// �݌Ɉړ��d�q��������������r����
		/// </summary>
		/// <param name="stockMovePpr1">
		///                    ��r����StockMovePpr�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockMovePpr2">��r����StockMovePpr�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMovePpr�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockMovePpr stockMovePpr1, StockMovePpr stockMovePpr2)
		{
            return ((stockMovePpr1.SearchCnt == stockMovePpr2.SearchCnt)
                && (stockMovePpr1.EnterpriseCode == stockMovePpr2.EnterpriseCode)
                && (stockMovePpr1.OutputDiv == stockMovePpr2.OutputDiv)
                && (stockMovePpr1.InputSectionCode == stockMovePpr2.InputSectionCode)
                && (stockMovePpr1.SectionCode == stockMovePpr2.SectionCode)
                && (stockMovePpr1.WarehouseCode == stockMovePpr2.WarehouseCode)
                && (stockMovePpr1.St_Date == stockMovePpr2.St_Date)
                && (stockMovePpr1.Ed_Date == stockMovePpr2.Ed_Date)
                && (stockMovePpr1.SalesSlipNum == stockMovePpr2.SalesSlipNum)
                && (stockMovePpr1.St_AddUpADate == stockMovePpr2.St_AddUpADate)
                && (stockMovePpr1.Ed_AddUpADate == stockMovePpr2.Ed_AddUpADate)
                && (stockMovePpr1.SalesEmployeeCd == stockMovePpr2.SalesEmployeeCd)
                && (stockMovePpr1.SupplierCd == stockMovePpr2.SupplierCd)
                && (stockMovePpr1.GoodsMakerCd == stockMovePpr2.GoodsMakerCd)
                && (stockMovePpr1.BLGoodsCode == stockMovePpr2.BLGoodsCode)
                && (stockMovePpr1.GoodsNo == stockMovePpr2.GoodsNo)
                && (stockMovePpr1.GoodsName == stockMovePpr2.GoodsName)
                && (stockMovePpr1.WarehouseShelfNo == stockMovePpr2.WarehouseShelfNo)
                && (stockMovePpr1.AfSectionCode == stockMovePpr2.AfSectionCode)
                && (stockMovePpr1.AfEnterWarehCode == stockMovePpr2.AfEnterWarehCode)
                && (stockMovePpr1.ArrivalGoodsFlag == stockMovePpr2.ArrivalGoodsFlag)
                && (stockMovePpr1.SlipNote == stockMovePpr2.SlipNote)
                && (stockMovePpr1.DeleteFlag == stockMovePpr2.DeleteFlag)
                && (stockMovePpr1.StockMoveFixCode == stockMovePpr2.StockMoveFixCode)
                && (stockMovePpr1.SalesSlipDiv == stockMovePpr2.SalesSlipDiv));
		}
		/// <summary>
		/// �݌Ɉړ��d�q��������������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockMovePpr�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMovePpr�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockMovePpr target)
		{
			ArrayList resList = new ArrayList();
            if (this.SearchCnt != target.SearchCnt) resList.Add("SearchCnt");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.OutputDiv != target.OutputDiv) resList.Add("OutputDiv");
            if (this.InputSectionCode != target.InputSectionCode) resList.Add("InputSectionCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.St_Date != target.St_Date) resList.Add("St_Date");
            if (this.Ed_Date != target.Ed_Date) resList.Add("Ed_Date");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.St_AddUpADate != target.St_AddUpADate) resList.Add("St_AddUpADate");
            if (this.Ed_AddUpADate != target.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.ArrivalGoodsFlag != target.ArrivalGoodsFlag) resList.Add("ArrivalGoodsFlag");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.DeleteFlag != target.DeleteFlag) resList.Add("DeleteFlag");
            if (this.StockMoveFixCode != target.StockMoveFixCode) resList.Add("StockMoveFixCode");
            if (this.SalesSlipDiv != target.SalesSlipDiv) resList.Add("SalesSlipDiv");

			return resList;
		}

		/// <summary>
		/// �݌Ɉړ��d�q��������������r����
		/// </summary>
		/// <param name="stockMovePpr1">��r����StockMovePpr�N���X�̃C���X�^���X</param>
		/// <param name="stockMovePpr2">��r����StockMovePpr�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMovePpr�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockMovePpr stockMovePpr1, StockMovePpr stockMovePpr2)
		{
			ArrayList resList = new ArrayList();
            if (stockMovePpr1.SearchCnt != stockMovePpr2.SearchCnt) resList.Add("SearchCnt");
            if (stockMovePpr1.EnterpriseCode != stockMovePpr2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMovePpr1.OutputDiv != stockMovePpr2.OutputDiv) resList.Add("OutputDiv");
            if (stockMovePpr1.InputSectionCode != stockMovePpr2.InputSectionCode) resList.Add("InputSectionCode");
            if (stockMovePpr1.SectionCode != stockMovePpr2.SectionCode) resList.Add("SectionCode");
            if (stockMovePpr1.WarehouseCode != stockMovePpr2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockMovePpr1.St_Date != stockMovePpr2.St_Date) resList.Add("St_Date");
            if (stockMovePpr1.Ed_Date != stockMovePpr2.Ed_Date) resList.Add("Ed_Date");
            if (stockMovePpr1.SalesSlipNum != stockMovePpr2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (stockMovePpr1.St_AddUpADate != stockMovePpr2.St_AddUpADate) resList.Add("St_AddUpADate");
            if (stockMovePpr1.Ed_AddUpADate != stockMovePpr2.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (stockMovePpr1.SalesEmployeeCd != stockMovePpr2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (stockMovePpr1.SupplierCd != stockMovePpr2.SupplierCd) resList.Add("SupplierCd");
            if (stockMovePpr1.GoodsMakerCd != stockMovePpr2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockMovePpr1.BLGoodsCode != stockMovePpr2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockMovePpr1.GoodsNo != stockMovePpr2.GoodsNo) resList.Add("GoodsNo");
            if (stockMovePpr1.GoodsName != stockMovePpr2.GoodsName) resList.Add("GoodsName");
            if (stockMovePpr1.WarehouseShelfNo != stockMovePpr2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockMovePpr1.AfSectionCode != stockMovePpr2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMovePpr1.AfEnterWarehCode != stockMovePpr2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMovePpr1.ArrivalGoodsFlag != stockMovePpr2.ArrivalGoodsFlag) resList.Add("ArrivalGoodsFlag");
            if (stockMovePpr1.SlipNote != stockMovePpr2.SlipNote) resList.Add("SlipNote");
            if (stockMovePpr1.DeleteFlag != stockMovePpr2.DeleteFlag) resList.Add("DeleteFlag");
            if (stockMovePpr1.StockMoveFixCode != stockMovePpr2.StockMoveFixCode) resList.Add("StockMoveFixCode");
            if (stockMovePpr1.SalesSlipDiv != stockMovePpr2.SalesSlipDiv) resList.Add("SalesSlipDiv"); return resList;
		}
	}
}
