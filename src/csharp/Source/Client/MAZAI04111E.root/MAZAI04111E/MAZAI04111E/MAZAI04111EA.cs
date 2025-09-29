using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockSearchPara
	/// <summary>
	///                      �݌Ɍ������o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɍ������o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockSearchPara
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>�i��</summary>
		private string _goodsNo = "";

		/// <summary>�i�Ԍ����^�C�v</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
		private Int32 _goodsNoSrchTyp;

		/// <summary>�i��</summary>
		private string _goodsName = "";

		/// <summary>�i�������^�C�v</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
		private Int32 _goodsNameSrchTyp;

		/// <summary>�i���J�i</summary>
		private string _goodsNameKana = "";

		/// <summary>�i�������^�C�v</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
		private Int32 _goodsNameKanaSrchTyp;

		/// <summary>���Е��ރR�[�h</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�[���݌ɕ\���敪</summary>
		/// <remarks>0:����,1:���Ȃ�</remarks>
		private Int32 _zeroStckDsp;

		/// <summary>���i�ԍ�(����)</summary>
		/// <remarks>(�z��)�������i�ԍ��w�莞�Ɏg�p</remarks>
		private string[] _goodsNos;

		/// <summary>���[�J�[�R�[�h(����)</summary>
		/// <remarks>(�z��)�������[�J�[�R�[�h�w�莞�Ɏg�p</remarks>
		private Int32[] _goodsMakerCds;

		/// <summary>�q�ɃR�[�h(����)</summary>
		/// <remarks>(�z��)�����q�ɃR�[�h�w�莞�Ɏg�p</remarks>
		private string[] _warehouseCodes;

		/// <summary>�q�ɒI��</summary>
		private string _warehouseShelfNo = "";

		/// <summary>�q�ɒI�Ԍ����^�C�v</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
		private Int32 _warehouseShelfNoSrchTyp;

		/// <summary>�Ώۓ��t�敪</summary>
		/// <remarks>0:�X�V���t�A1:�o�^���t</remarks>
		private Int32 _dateDiv;

		/// <summary>�J�n�Ώۓ��t</summary>
		private Int32 _st_Date;

		/// <summary>�I���Ώۓ��t</summary>
		private Int32 _ed_Date;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

        private Int32 _supplierCd;

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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
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

		/// public propaty name  :  GoodsNo
		/// <summary>�i�ԃv���p�e�B</summary>
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

		/// public propaty name  :  GoodsNameKana
		/// <summary>�i���J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i���J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  GoodsNameKanaSrchTyp
		/// <summary>�i�������^�C�v�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i�������^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNameKanaSrchTyp
		{
			get{return _goodsNameKanaSrchTyp;}
			set{_goodsNameKanaSrchTyp = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�v���p�e�B</summary>
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

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
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

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
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

		/// public propaty name  :  ZeroStckDsp
		/// <summary>�[���݌ɕ\���敪�v���p�e�B</summary>
		/// <value>0:����,1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[���݌ɕ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ZeroStckDsp
		{
			get{return _zeroStckDsp;}
			set{_zeroStckDsp = value;}
		}

		/// public propaty name  :  GoodsNos
		/// <summary>���i�ԍ�(����)�v���p�e�B</summary>
		/// <value>(�z��)�������i�ԍ��w�莞�Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ�(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] GoodsNos
		{
			get{return _goodsNos;}
			set{_goodsNos = value;}
		}

		/// public propaty name  :  GoodsMakerCds
		/// <summary>���[�J�[�R�[�h(����)�v���p�e�B</summary>
		/// <value>(�z��)�������[�J�[�R�[�h�w�莞�Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] GoodsMakerCds
		{
			get{return _goodsMakerCds;}
			set{_goodsMakerCds = value;}
		}

		/// public propaty name  :  WarehouseCodes
		/// <summary>�q�ɃR�[�h(����)�v���p�e�B</summary>
		/// <value>(�z��)�����q�ɃR�[�h�w�莞�Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] WarehouseCodes
		{
			get{return _warehouseCodes;}
			set{_warehouseCodes = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>�q�ɒI�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  WarehouseShelfNoSrchTyp
		/// <summary>�q�ɒI�Ԍ����^�C�v�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI�Ԍ����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 WarehouseShelfNoSrchTyp
		{
			get{return _warehouseShelfNoSrchTyp;}
			set{_warehouseShelfNoSrchTyp = value;}
		}

		/// public propaty name  :  DateDiv
		/// <summary>�Ώۓ��t�敪�v���p�e�B</summary>
		/// <value>0:�X�V���t�A1:�o�^���t</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ώۓ��t�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DateDiv
		{
			get{return _dateDiv;}
			set{_dateDiv = value;}
		}

		/// public propaty name  :  St_Date
		/// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_Date
		{
			get{return _st_Date;}
			set{_st_Date = value;}
		}

		/// public propaty name  :  Ed_Date
		/// <summary>�I���Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_Date
		{
			get{return _ed_Date;}
			set{_ed_Date = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>�q�ɖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

		/// <summary>
		/// �݌Ɍ������o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>StockSearchPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSearchPara()
		{
		}

		/// <summary>
		/// �݌Ɍ������o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
		/// <param name="goodsNo">�i��</param>
		/// <param name="goodsNoSrchTyp">�i�Ԍ����^�C�v(0:���S��v,1:�O����v����,2:�����v����,3:�B������)</param>
		/// <param name="goodsName">�i��</param>
		/// <param name="goodsNameSrchTyp">�i�������^�C�v(0:���S��v,1:�O����v����,2:�����v����,3:�B������)</param>
		/// <param name="goodsNameKana">�i���J�i</param>
		/// <param name="goodsNameKanaSrchTyp">�i�������^�C�v(0:���S��v,1:�O����v����,2:�����v����,3:�B������)</param>
		/// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="warehouseCode">�q�ɃR�[�h</param>
		/// <param name="zeroStckDsp">�[���݌ɕ\���敪(0:����,1:���Ȃ�)</param>
		/// <param name="goodsNos">���i�ԍ�(����)((�z��)�������i�ԍ��w�莞�Ɏg�p)</param>
		/// <param name="goodsMakerCds">���[�J�[�R�[�h(����)((�z��)�������[�J�[�R�[�h�w�莞�Ɏg�p)</param>
		/// <param name="warehouseCodes">�q�ɃR�[�h(����)((�z��)�����q�ɃR�[�h�w�莞�Ɏg�p)</param>
		/// <param name="warehouseShelfNo">�q�ɒI��</param>
		/// <param name="warehouseShelfNoSrchTyp">�q�ɒI�Ԍ����^�C�v(0:���S��v,1:�O����v����,2:�����v����,3:�B������)</param>
		/// <param name="dateDiv">�Ώۓ��t�敪(0:�X�V���t�A1:�o�^���t)</param>
		/// <param name="st_Date">�J�n�Ώۓ��t</param>
		/// <param name="ed_Date">�I���Ώۓ��t</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="supplierCd">�d����R�[�h</param>
		/// <returns>StockSearchPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSearchPara(string enterpriseCode,string sectionCode,Int32 goodsMakerCd,string goodsNo,Int32 goodsNoSrchTyp,string goodsName,Int32 goodsNameSrchTyp,string goodsNameKana,Int32 goodsNameKanaSrchTyp,Int32 enterpriseGanreCode,Int32 bLGoodsCode,string warehouseCode,Int32 zeroStckDsp,string[] goodsNos,Int32[] goodsMakerCds,string[] warehouseCodes,string warehouseShelfNo,Int32 warehouseShelfNoSrchTyp,Int32 dateDiv,Int32 st_Date,Int32 ed_Date,string enterpriseName,string bLGoodsName,string warehouseName, Int32 supplierCd)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsNo = goodsNo;
			this._goodsNoSrchTyp = goodsNoSrchTyp;
			this._goodsName = goodsName;
			this._goodsNameSrchTyp = goodsNameSrchTyp;
			this._goodsNameKana = goodsNameKana;
			this._goodsNameKanaSrchTyp = goodsNameKanaSrchTyp;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._bLGoodsCode = bLGoodsCode;
			this._warehouseCode = warehouseCode;
			this._zeroStckDsp = zeroStckDsp;
			this._goodsNos = goodsNos;
			this._goodsMakerCds = goodsMakerCds;
			this._warehouseCodes = warehouseCodes;
			this._warehouseShelfNo = warehouseShelfNo;
			this._warehouseShelfNoSrchTyp = warehouseShelfNoSrchTyp;
			this._dateDiv = dateDiv;
			this._st_Date = st_Date;
			this._ed_Date = ed_Date;
			this._enterpriseName = enterpriseName;
			this._bLGoodsName = bLGoodsName;
			this._warehouseName = warehouseName;
            this._supplierCd = supplierCd;
		}

		/// <summary>
		/// �݌Ɍ������o�����N���X��������
		/// </summary>
		/// <returns>StockSearchPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockSearchPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSearchPara Clone()
		{
			return new StockSearchPara(this._enterpriseCode,this._sectionCode,this._goodsMakerCd,this._goodsNo,this._goodsNoSrchTyp,this._goodsName,this._goodsNameSrchTyp,this._goodsNameKana,this._goodsNameKanaSrchTyp,this._enterpriseGanreCode,this._bLGoodsCode,this._warehouseCode,this._zeroStckDsp,this._goodsNos,this._goodsMakerCds,this._warehouseCodes,this._warehouseShelfNo,this._warehouseShelfNoSrchTyp,this._dateDiv,this._st_Date,this._ed_Date,this._enterpriseName,this._bLGoodsName,this._warehouseName, this._supplierCd);
		}

		/// <summary>
		/// �݌Ɍ������o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(StockSearchPara target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameSrchTyp == target.GoodsNameSrchTyp)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.GoodsNameKanaSrchTyp == target.GoodsNameKanaSrchTyp)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.ZeroStckDsp == target.ZeroStckDsp)
				 && (this.GoodsNos == target.GoodsNos)
				 && (this.GoodsMakerCds == target.GoodsMakerCds)
				 && (this.WarehouseCodes == target.WarehouseCodes)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.WarehouseShelfNoSrchTyp == target.WarehouseShelfNoSrchTyp)
				 && (this.DateDiv == target.DateDiv)
				 && (this.St_Date == target.St_Date)
				 && (this.Ed_Date == target.Ed_Date)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.SupplierCd == target.SupplierCd)
                 );
		}

		/// <summary>
		/// �݌Ɍ������o�����N���X��r����
		/// </summary>
		/// <param name="stockSearchPara1">
		///                    ��r����StockSearchPara�N���X�̃C���X�^���X
		/// </param>
		/// <param name="stockSearchPara2">��r����StockSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2)
		{
			return ((stockSearchPara1.EnterpriseCode == stockSearchPara2.EnterpriseCode)
				 && (stockSearchPara1.SectionCode == stockSearchPara2.SectionCode)
				 && (stockSearchPara1.GoodsMakerCd == stockSearchPara2.GoodsMakerCd)
				 && (stockSearchPara1.GoodsNo == stockSearchPara2.GoodsNo)
				 && (stockSearchPara1.GoodsNoSrchTyp == stockSearchPara2.GoodsNoSrchTyp)
				 && (stockSearchPara1.GoodsName == stockSearchPara2.GoodsName)
				 && (stockSearchPara1.GoodsNameSrchTyp == stockSearchPara2.GoodsNameSrchTyp)
				 && (stockSearchPara1.GoodsNameKana == stockSearchPara2.GoodsNameKana)
				 && (stockSearchPara1.GoodsNameKanaSrchTyp == stockSearchPara2.GoodsNameKanaSrchTyp)
				 && (stockSearchPara1.EnterpriseGanreCode == stockSearchPara2.EnterpriseGanreCode)
				 && (stockSearchPara1.BLGoodsCode == stockSearchPara2.BLGoodsCode)
				 && (stockSearchPara1.WarehouseCode == stockSearchPara2.WarehouseCode)
				 && (stockSearchPara1.ZeroStckDsp == stockSearchPara2.ZeroStckDsp)
				 && (stockSearchPara1.GoodsNos == stockSearchPara2.GoodsNos)
				 && (stockSearchPara1.GoodsMakerCds == stockSearchPara2.GoodsMakerCds)
				 && (stockSearchPara1.WarehouseCodes == stockSearchPara2.WarehouseCodes)
				 && (stockSearchPara1.WarehouseShelfNo == stockSearchPara2.WarehouseShelfNo)
				 && (stockSearchPara1.WarehouseShelfNoSrchTyp == stockSearchPara2.WarehouseShelfNoSrchTyp)
				 && (stockSearchPara1.DateDiv == stockSearchPara2.DateDiv)
				 && (stockSearchPara1.St_Date == stockSearchPara2.St_Date)
				 && (stockSearchPara1.Ed_Date == stockSearchPara2.Ed_Date)
				 && (stockSearchPara1.EnterpriseName == stockSearchPara2.EnterpriseName)
				 && (stockSearchPara1.BLGoodsName == stockSearchPara2.BLGoodsName)
                 && (stockSearchPara1.WarehouseName == stockSearchPara2.WarehouseName)
                 && (stockSearchPara1.SupplierCd == stockSearchPara2.SupplierCd)
                 );
		}
		/// <summary>
		/// �݌Ɍ������o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�StockSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(StockSearchPara target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsNoSrchTyp != target.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameSrchTyp != target.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.GoodsNameKanaSrchTyp != target.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.ZeroStckDsp != target.ZeroStckDsp)resList.Add("ZeroStckDsp");
			if(this.GoodsNos != target.GoodsNos)resList.Add("GoodsNos");
			if(this.GoodsMakerCds != target.GoodsMakerCds)resList.Add("GoodsMakerCds");
			if(this.WarehouseCodes != target.WarehouseCodes)resList.Add("WarehouseCodes");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.WarehouseShelfNoSrchTyp != target.WarehouseShelfNoSrchTyp)resList.Add("WarehouseShelfNoSrchTyp");
			if(this.DateDiv != target.DateDiv)resList.Add("DateDiv");
			if(this.St_Date != target.St_Date)resList.Add("St_Date");
			if(this.Ed_Date != target.Ed_Date)resList.Add("Ed_Date");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");

            // ���i�R�[�h(�����w��)
            if (this.GoodsNos.Length != target.GoodsNos.Length)
            {
                resList.Add("GoodsNos");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in target.GoodsNos)
                {
                    isExsist = false;
                    foreach (string wk2 in this.GoodsNos)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsNos");
                        break;
                    }
                }
            }

            // ���[�J�[�R�[�h(�����w��)
            if (this.GoodsMakerCds.Length != target.GoodsMakerCds.Length)
            {
                resList.Add("GoodsMakerCds");
            }
            else
            {
                bool isExsist = false;

                foreach (int wk1 in target.GoodsMakerCds)
                {
                    isExsist = false;
                    foreach (int wk2 in this.GoodsMakerCds)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsMakerCds");
                        break;
                    }
                }
            }

            // �q�ɃR�[�h(�����w��)
            if (this.WarehouseCodes.Length != target.WarehouseCodes.Length)
            {
                resList.Add("WarehouseCodes");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in target.WarehouseCodes)
                {
                    isExsist = false;
                    foreach (string wk2 in this.WarehouseCodes)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("WarehouseCodes");
                        break;
                    }
                }
            }
			return resList;
		}

		/// <summary>
		/// �݌Ɍ������o�����N���X��r����
		/// </summary>
		/// <param name="stockSearchPara1">��r����StockSearchPara�N���X�̃C���X�^���X</param>
		/// <param name="stockSearchPara2">��r����StockSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2)
		{
			ArrayList resList = new ArrayList();
			if(stockSearchPara1.EnterpriseCode != stockSearchPara2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockSearchPara1.SectionCode != stockSearchPara2.SectionCode)resList.Add("SectionCode");
			if(stockSearchPara1.GoodsMakerCd != stockSearchPara2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockSearchPara1.GoodsNo != stockSearchPara2.GoodsNo)resList.Add("GoodsNo");
			if(stockSearchPara1.GoodsNoSrchTyp != stockSearchPara2.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(stockSearchPara1.GoodsName != stockSearchPara2.GoodsName)resList.Add("GoodsName");
			if(stockSearchPara1.GoodsNameSrchTyp != stockSearchPara2.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(stockSearchPara1.GoodsNameKana != stockSearchPara2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(stockSearchPara1.GoodsNameKanaSrchTyp != stockSearchPara2.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(stockSearchPara1.EnterpriseGanreCode != stockSearchPara2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(stockSearchPara1.BLGoodsCode != stockSearchPara2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockSearchPara1.WarehouseCode != stockSearchPara2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockSearchPara1.ZeroStckDsp != stockSearchPara2.ZeroStckDsp)resList.Add("ZeroStckDsp");
			if(stockSearchPara1.GoodsNos != stockSearchPara2.GoodsNos)resList.Add("GoodsNos");
			if(stockSearchPara1.GoodsMakerCds != stockSearchPara2.GoodsMakerCds)resList.Add("GoodsMakerCds");
			if(stockSearchPara1.WarehouseCodes != stockSearchPara2.WarehouseCodes)resList.Add("WarehouseCodes");
			if(stockSearchPara1.WarehouseShelfNo != stockSearchPara2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(stockSearchPara1.WarehouseShelfNoSrchTyp != stockSearchPara2.WarehouseShelfNoSrchTyp)resList.Add("WarehouseShelfNoSrchTyp");
			if(stockSearchPara1.DateDiv != stockSearchPara2.DateDiv)resList.Add("DateDiv");
			if(stockSearchPara1.St_Date != stockSearchPara2.St_Date)resList.Add("St_Date");
			if(stockSearchPara1.Ed_Date != stockSearchPara2.Ed_Date)resList.Add("Ed_Date");
			if(stockSearchPara1.EnterpriseName != stockSearchPara2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockSearchPara1.BLGoodsName != stockSearchPara2.BLGoodsName)resList.Add("BLGoodsName");
            if (stockSearchPara1.WarehouseName != stockSearchPara2.WarehouseName) resList.Add("WarehouseName");
            if (stockSearchPara1.SupplierCd != stockSearchPara2.SupplierCd) resList.Add("SupplierCd");

            // ���i�R�[�h(�����w��)
            if (stockSearchPara1.GoodsNos.Length != stockSearchPara2.GoodsNos.Length)
            {
                resList.Add("GoodsNos");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in stockSearchPara2.GoodsNos)
                {
                    isExsist = false;
                    foreach (string wk2 in stockSearchPara1.GoodsNos)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsNos");
                        break;
                    }
                }
            }

            // ���[�J�[�R�[�h(�����w��)
            if (stockSearchPara1.GoodsMakerCds.Length != stockSearchPara2.GoodsMakerCds.Length)
            {
                resList.Add("GoodsMakerCds");
            }
            else
            {
                bool isExsist = false;

                foreach (int wk1 in stockSearchPara2.GoodsMakerCds)
                {
                    isExsist = false;
                    foreach (int wk2 in stockSearchPara1.GoodsMakerCds)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsMakerCds");
                        break;
                    }
                }
            }

            // �q�ɃR�[�h(�����w��)
            if (stockSearchPara1.WarehouseCodes.Length != stockSearchPara2.WarehouseCodes.Length)
            {
                resList.Add("WarehouseCodes");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in stockSearchPara2.WarehouseCodes)
                {
                    isExsist = false;
                    foreach (string wk2 in stockSearchPara1.WarehouseCodes)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("WarehouseCodes");
                        break;
                    }
                }
            }
			return resList;
		}
	}
}


//using System;
//using System.Collections;

//namespace Broadleaf.Application.UIData
//{
//    /// public class name:   StockSearchPara
//    /// <summary>
//    ///                      �݌Ɍ������o�������[�N
//    /// </summary>
//    /// <remarks>
//    /// <br>note             :   �݌Ɍ������o�������[�N�w�b�_�t�@�C��</br>
//    /// <br>Programmer       :   ��������</br>
//    /// <br>Date             :   </br>
//    /// <br>Genarated Date   :   2007/09/07  (CSharp File Generated Date)</br>
//    /// <br></br>
//    /// <br>Update Note      :   2007/09/07 ��ؐ��b</br>
//    /// <br>                 :   ����.NS�p�ɍ쐬�B�z�񍀖ڂ̓c�[����Ή��̈�,��ŏC���B</br>
//    /// </remarks>
//    public class StockSearchPara
//    {
//        /// <summary>��ƃR�[�h</summary>
//        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
//        private string _enterpriseCode = "";

//        /// <summary>���_�R�[�h</summary>
//        private string _sectionCode = "";

//        /// <summary>���[�J�[�R�[�h</summary>
//        private Int32 _goodsMakerCd;

//        /// <summary>���[�J�[����</summary>
//        private string _makerName = "";

//        /// <summary>���i�R�[�h</summary>
//        private string _goodsNo = "";

//        /// <summary>���i�R�[�h�����^�C�v</summary>
//        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
//        private Int32 _goodsNoSrchTyp;

//        /// <summary>���i����</summary>
//        private string _goodsName = "";

//        /// <summary>���i���̃J�i</summary>
//        private string _goodsNameKana = "";

//        /// <summary>���i�敪�O���[�v�R�[�h</summary>
//        /// <remarks>���F���i�啪�ރR�[�h</remarks>
//        private string _largeGoodsGanreCode = "";

//        /// <summary>���i�敪�O���[�v����</summary>
//        /// <remarks>���F���i�啪�ޖ���</remarks>
//        private string _largeGoodsGanreName = "";

//        /// <summary>���i�敪�R�[�h</summary>
//        /// <remarks>���F���i�����ރR�[�h</remarks>
//        private string _mediumGoodsGanreCode = "";

//        /// <summary>���i�敪����</summary>
//        /// <remarks>���F���i�����ޖ���</remarks>
//        private string _mediumGoodsGanreName = "";

//        /// <summary>���i�敪�ڍ׃R�[�h</summary>
//        private string _detailGoodsGanreCode = "";

//        /// <summary>���i�敪�ڍז���</summary>
//        private string _detailGoodsGanreName = "";

//        /// <summary>���Е��ރR�[�h</summary>
//        private Int32 _enterpriseGanreCode;

//        /// <summary>���Е��ޖ���</summary>
//        private string _enterpriseGanreName = "";

//        /// <summary>BL���i�R�[�h</summary>
//        private Int32 _bLGoodsCode;

//        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
//        private string _bLGoodsFullName = "";

//        /// <summary>�q�ɃR�[�h</summary>
//        private string _warehouseCode;

//        /// <summary>�q�ɖ���</summary>
//        private string _warehouseName = "";

//        /// <summary>���Ӑ�R�[�h</summary>
//        private Int32 _customerCode;

//        /// <summary>���Ӑ於��</summary>
//        private string _customerName = "";

//        /// <summary>�[���݌ɕ\���敪</summary>
//        /// <remarks>0:����,1:���Ȃ�</remarks>
//        private Int32 _zeroStckDsp;

//        /// <summary>���i�ԍ�(����)</summary>
//        /// <remarks>(�z��)�������i�ԍ��w�莞�Ɏg�p</remarks>
//        private string[] _goodsNos;

//        /// <summary>���[�J�[�R�[�h(����)</summary>
//        /// <remarks>(�z��)�������[�J�[�R�[�h�w�莞�Ɏg�p</remarks>
//        private Int32[] _goodsMakerCds;

//        /// <summary>�q�ɃR�[�h(����)</summary>
//        /// <remarks>(�z��)�����q�ɃR�[�h�w�莞�Ɏg�p</remarks>
//        private string[] _warehouseCodes;

//        /// <summary>��Ɩ���</summary>
//        private string _enterpriseName = "";

//        /// <summary>BL���i�R�[�h����</summary>
//        private string _bLGoodsName = "";


//        /// public propaty name  :  EnterpriseCode
//        /// <summary>��ƃR�[�h�v���p�e�B</summary>
//        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string EnterpriseCode
//        {
//            get { return _enterpriseCode; }
//            set { _enterpriseCode = value; }
//        }

//        /// public propaty name  :  SectionCode
//        /// <summary>���_�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string SectionCode
//        {
//            get { return _sectionCode; }
//            set { _sectionCode = value; }
//        }

//        /// public propaty name  :  GoodsMakerCd
//        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsMakerCd
//        {
//            get { return _goodsMakerCd; }
//            set { _goodsMakerCd = value; }
//        }

//        /// public propaty name  :  MakerName
//        /// <summary>���[�J�[���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string MakerName
//        {
//            get { return _makerName; }
//            set { _makerName = value; }
//        }

//        /// public propaty name  :  GoodsNo
//        /// <summary>���i�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsNo
//        {
//            get { return _goodsNo; }
//            set { _goodsNo = value; }
//        }

//        /// public propaty name  :  GoodsNoSrchTyp
//        /// <summary>���i�R�[�h�����^�C�v�v���p�e�B</summary>
//        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�R�[�h�����^�C�v�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 GoodsNoSrchTyp
//        {
//            get { return _goodsNoSrchTyp; }
//            set { _goodsNoSrchTyp = value; }
//        }

//        /// public propaty name  :  GoodsName
//        /// <summary>���i���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsName
//        {
//            get { return _goodsName; }
//            set { _goodsName = value; }
//        }

//        /// public propaty name  :  GoodsNameKana
//        /// <summary>���i���̃J�i�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string GoodsNameKana
//        {
//            get { return _goodsNameKana; }
//            set { _goodsNameKana = value; }
//        }

//        /// public propaty name  :  LargeGoodsGanreCode
//        /// <summary>���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
//        /// <value>���F���i�啪�ރR�[�h</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�敪�O���[�v�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string LargeGoodsGanreCode
//        {
//            get { return _largeGoodsGanreCode; }
//            set { _largeGoodsGanreCode = value; }
//        }

//        /// public propaty name  :  LargeGoodsGanreName
//        /// <summary>���i�敪�O���[�v���̃v���p�e�B</summary>
//        /// <value>���F���i�啪�ޖ���</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�敪�O���[�v���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string LargeGoodsGanreName
//        {
//            get { return _largeGoodsGanreName; }
//            set { _largeGoodsGanreName = value; }
//        }

//        /// public propaty name  :  MediumGoodsGanreCode
//        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
//        /// <value>���F���i�����ރR�[�h</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string MediumGoodsGanreCode
//        {
//            get { return _mediumGoodsGanreCode; }
//            set { _mediumGoodsGanreCode = value; }
//        }

//        /// public propaty name  :  MediumGoodsGanreName
//        /// <summary>���i�敪���̃v���p�e�B</summary>
//        /// <value>���F���i�����ޖ���</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�敪���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string MediumGoodsGanreName
//        {
//            get { return _mediumGoodsGanreName; }
//            set { _mediumGoodsGanreName = value; }
//        }

//        /// public propaty name  :  DetailGoodsGanreCode
//        /// <summary>���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�敪�ڍ׃R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string DetailGoodsGanreCode
//        {
//            get { return _detailGoodsGanreCode; }
//            set { _detailGoodsGanreCode = value; }
//        }

//        /// public propaty name  :  DetailGoodsGanreName
//        /// <summary>���i�敪�ڍז��̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�敪�ڍז��̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string DetailGoodsGanreName
//        {
//            get { return _detailGoodsGanreName; }
//            set { _detailGoodsGanreName = value; }
//        }

//        /// public propaty name  :  EnterpriseGanreCode
//        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 EnterpriseGanreCode
//        {
//            get { return _enterpriseGanreCode; }
//            set { _enterpriseGanreCode = value; }
//        }

//        /// public propaty name  :  EnterpriseGanreName
//        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string EnterpriseGanreName
//        {
//            get { return _enterpriseGanreName; }
//            set { _enterpriseGanreName = value; }
//        }

//        /// public propaty name  :  BLGoodsCode
//        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 BLGoodsCode
//        {
//            get { return _bLGoodsCode; }
//            set { _bLGoodsCode = value; }
//        }

//        /// public propaty name  :  BLGoodsFullName
//        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string BLGoodsFullName
//        {
//            get { return _bLGoodsFullName; }
//            set { _bLGoodsFullName = value; }
//        }

//        /// public propaty name  :  WarehouseCode
//        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string WarehouseCode
//        {
//            get { return _warehouseCode; }
//            set { _warehouseCode = value; }
//        }

//        /// public propaty name  :  WarehouseName
//        /// <summary>�q�ɖ��̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string WarehouseName
//        {
//            get { return _warehouseName; }
//            set { _warehouseName = value; }
//        }

//        /// public propaty name  :  CustomerCode
//        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 CustomerCode
//        {
//            get { return _customerCode; }
//            set { _customerCode = value; }
//        }

//        /// public propaty name  :  CustomerName
//        /// <summary>���Ӑ於�̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string CustomerName
//        {
//            get { return _customerName; }
//            set { _customerName = value; }
//        }

//        /// public propaty name  :  ZeroStckDsp
//        /// <summary>�[���݌ɕ\���敪�v���p�e�B</summary>
//        /// <value>0:����,1:���Ȃ�</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �[���݌ɕ\���敪�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32 ZeroStckDsp
//        {
//            get { return _zeroStckDsp; }
//            set { _zeroStckDsp = value; }
//        }

//        /// public propaty name  :  GoodsNos
//        /// <summary>���i�ԍ�(����)�v���p�e�B</summary>
//        /// <value>(�z��)�������i�ԍ��w�莞�Ɏg�p</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���i�ԍ�(����)�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string[] GoodsNos
//        {
//            get { return _goodsNos; }
//            set { _goodsNos = value; }
//        }

//        /// public propaty name  :  GoodsMakerCds
//        /// <summary>���[�J�[�R�[�h(����)�v���p�e�B</summary>
//        /// <value>(�z��)�������[�J�[�R�[�h�w�莞�Ɏg�p</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ���[�J�[�R�[�h(����)�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public Int32[] GoodsMakerCds
//        {
//            get { return _goodsMakerCds; }
//            set { _goodsMakerCds = value; }
//        }

//        /// public propaty name  :  WarehouseCodes
//        /// <summary>�q�ɃR�[�h(����)�v���p�e�B</summary>
//        /// <value>(�z��)�����q�ɃR�[�h�w�莞�Ɏg�p</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   �q�ɃR�[�h(����)�v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string[] WarehouseCodes
//        {
//            get { return _warehouseCodes; }
//            set { _warehouseCodes = value; }
//        }

//        /// public propaty name  :  EnterpriseName
//        /// <summary>��Ɩ��̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string EnterpriseName
//        {
//            get { return _enterpriseName; }
//            set { _enterpriseName = value; }
//        }

//        /// public propaty name  :  BLGoodsName
//        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public string BLGoodsName
//        {
//            get { return _bLGoodsName; }
//            set { _bLGoodsName = value; }
//        }


//        /// <summary>
//        /// �݌Ɍ������o�������[�N�R���X�g���N�^
//        /// </summary>
//        /// <returns>StockSearchPara�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public StockSearchPara ()
//        {
//        }

//        /// <summary>
//        /// �݌Ɍ������o�������[�N�R���X�g���N�^
//        /// </summary>
//        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
//        /// <param name="sectionCode">���_�R�[�h</param>
//        /// <param name="GoodsMakerCd">���[�J�[�R�[�h</param>
//        /// <param name="makerName">���[�J�[����</param>
//        /// <param name="goodsNo">���i�R�[�h</param>
//        /// <param name="goodsNoSrchTyp">���i�R�[�h�����^�C�v(0:���S��v,1:�O����v����,2:�����v����,3:�B������)</param>
//        /// <param name="goodsName">���i����</param>
//        /// <param name="goodsNameKana">���i���̃J�i</param>
//        /// <param name="largeGoodsGanreCode">���i�敪�O���[�v�R�[�h(���F���i�啪�ރR�[�h)</param>
//        /// <param name="largeGoodsGanreName">���i�敪�O���[�v����(���F���i�啪�ޖ���)</param>
//        /// <param name="mediumGoodsGanreCode">���i�敪�R�[�h(���F���i�����ރR�[�h)</param>
//        /// <param name="mediumGoodsGanreName">���i�敪����(���F���i�����ޖ���)</param>
//        /// <param name="detailGoodsGanreCode">���i�敪�ڍ׃R�[�h</param>
//        /// <param name="detailGoodsGanreName">���i�敪�ڍז���</param>
//        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
//        /// <param name="enterpriseGanreName">���Е��ޖ���</param>
//        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
//        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
//        /// <param name="warehouseCode">�q�ɃR�[�h</param>
//        /// <param name="warehouseName">�q�ɖ���</param>
//        /// <param name="customerCode">���Ӑ�R�[�h</param>
//        /// <param name="customerName">���Ӑ於��</param>
//        /// <param name="zeroStckDsp">�[���݌ɕ\���敪(0:����,1:���Ȃ�)</param>
//        /// <param name="goodsNos">���i�ԍ�(����)((�z��)�������i�ԍ��w�莞�Ɏg�p)</param>
//        /// <param name="GoodsMakerCds">���[�J�[�R�[�h(����)((�z��)�������[�J�[�R�[�h�w�莞�Ɏg�p)</param>
//        /// <param name="warehouseCodes">�q�ɃR�[�h(����)((�z��)�����q�ɃR�[�h�w�莞�Ɏg�p)</param>
//        /// <param name="enterpriseName">��Ɩ���</param>
//        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
//        /// <returns>StockSearchPara�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public StockSearchPara ( string enterpriseCode, string sectionCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, string goodsNameKana, string largeGoodsGanreCode, string largeGoodsGanreName, string mediumGoodsGanreCode, string mediumGoodsGanreName, string detailGoodsGanreCode, string detailGoodsGanreName, Int32 enterpriseGanreCode, string enterpriseGanreName, Int32 bLGoodsCode, string bLGoodsFullName, string warehouseCode, string warehouseName, Int32 customerCode, string customerName, Int32 zeroStckDsp, string[] goodsNos, Int32[] goodsMakerCds, string[] warehouseCodes, string enterpriseName, string bLGoodsName )
//        {
//            this._enterpriseCode = enterpriseCode;
//            this._sectionCode = sectionCode;
//            this._goodsMakerCd = goodsMakerCd;
//            this._makerName = makerName;
//            this._goodsNo = goodsNo;
//            this._goodsNoSrchTyp = goodsNoSrchTyp;
//            this._goodsName = goodsName;
//            this._goodsNameKana = goodsNameKana;
//            this._largeGoodsGanreCode = largeGoodsGanreCode;
//            this._largeGoodsGanreName = largeGoodsGanreName;
//            this._mediumGoodsGanreCode = mediumGoodsGanreCode;
//            this._mediumGoodsGanreName = mediumGoodsGanreName;
//            this._detailGoodsGanreCode = detailGoodsGanreCode;
//            this._detailGoodsGanreName = detailGoodsGanreName;
//            this._enterpriseGanreCode = enterpriseGanreCode;
//            this._enterpriseGanreName = enterpriseGanreName;
//            this._bLGoodsCode = bLGoodsCode;
//            this._bLGoodsFullName = bLGoodsFullName;
//            this._warehouseCode = warehouseCode;
//            this._warehouseName = warehouseName;
//            this._customerCode = customerCode;
//            this._customerName = customerName;
//            this._zeroStckDsp = zeroStckDsp;
//            this._goodsNos = goodsNos;
//            this._goodsMakerCds = goodsMakerCds;
//            this._warehouseCodes = warehouseCodes;
//            this._enterpriseName = enterpriseName;
//            this._bLGoodsName = bLGoodsName;

//        }

//        /// <summary>
//        /// �݌Ɍ������o�������[�N��������
//        /// </summary>
//        /// <returns>StockSearchPara�N���X�̃C���X�^���X</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockSearchPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public StockSearchPara Clone ()
//        {
//            return new StockSearchPara(this._enterpriseCode, this._sectionCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameKana, this._largeGoodsGanreCode, this._largeGoodsGanreName, this._mediumGoodsGanreCode, this._mediumGoodsGanreName, this._detailGoodsGanreCode, this._detailGoodsGanreName, this._enterpriseGanreCode, this._enterpriseGanreName, this._bLGoodsCode, this._bLGoodsFullName, this._warehouseCode, this._warehouseName, this._customerCode, this._customerName, this._zeroStckDsp, this._goodsNos, this._goodsMakerCds, this._warehouseCodes, this._enterpriseName, this._bLGoodsName);
//        }

//        /// <summary>
//        /// �݌Ɍ������o�������[�N��r����
//        /// </summary>
//        /// <param name="target">��r�Ώۂ�StockSearchPara�N���X�̃C���X�^���X</param>
//        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public bool Equals ( StockSearchPara target )
//        {
//            bool equal = 
//                (this.EnterpriseCode == target.EnterpriseCode)
//                 && (this.SectionCode == target.SectionCode)
//                 && (this.GoodsMakerCd == target.GoodsMakerCd)
//                 && (this.MakerName == target.MakerName)
//                 && (this.GoodsNo == target.GoodsNo)
//                 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
//                 && (this.GoodsName == target.GoodsName)
//                 && (this.GoodsNameKana == target.GoodsNameKana)
//                 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
//                 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
//                 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
//                 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
//                 && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
//                 && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
//                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
//                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
//                 && (this.BLGoodsCode == target.BLGoodsCode)
//                 && (this.BLGoodsFullName == target.BLGoodsFullName)
//                 && (this.WarehouseCode == target.WarehouseCode)
//                 && (this.WarehouseName == target.WarehouseName)
//                 && (this.CustomerCode == target.CustomerCode)
//                 && (this.CustomerName == target.CustomerName)
//                 && (this.ZeroStckDsp == target.ZeroStckDsp)
//                 && (this.GoodsNos == target.GoodsNos)
//                 && (this.GoodsMakerCds == target.GoodsMakerCds)
//                 && (this.WarehouseCodes == target.WarehouseCodes)
//                 && (this.EnterpriseName == target.EnterpriseName)
//                 && (this.BLGoodsName == target.BLGoodsName);
//            if (!equal) return false;

//            bool isExist;

//            // ���i�R�[�h�i�����w��j
//            if ( this.GoodsNos.Length != target.GoodsNos.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in target.GoodsNos ) {
//                isExist = false;
//                foreach ( string wk2 in this.GoodsNos ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }
//            // ���[�J�[�R�[�h�i�����w��j
//            if ( this.GoodsMakerCds.Length != target.GoodsMakerCds.Length ) {
//                return false;
//            }

//            foreach ( int wk1 in target.GoodsMakerCds ) {
//                isExist = false;
//                foreach ( int wk2 in this.GoodsMakerCds ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            // �q�ɃR�[�h�i�����w��j
//            if ( this.WarehouseCodes.Length != target.WarehouseCodes.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in target.WarehouseCodes ) {
//                isExist = false;
//                foreach ( string wk2 in this.WarehouseCodes ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            return true;

//        }

//        /// <summary>
//        /// �݌Ɍ������o�������[�N��r����
//        /// </summary>
//        /// <param name="stockSearchPara1">
//        ///                    ��r����StockSearchPara�N���X�̃C���X�^���X
//        /// </param>
//        /// <param name="stockSearchPara2">��r����StockSearchPara�N���X�̃C���X�^���X</param>
//        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public static bool Equals ( StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2 )
//        {
//            bool equal = ( ( stockSearchPara1.EnterpriseCode == stockSearchPara2.EnterpriseCode )
//                 && ( stockSearchPara1.SectionCode == stockSearchPara2.SectionCode )
//                 && ( stockSearchPara1.GoodsMakerCd == stockSearchPara2.GoodsMakerCd )
//                 && ( stockSearchPara1.MakerName == stockSearchPara2.MakerName )
//                 && ( stockSearchPara1.GoodsNo == stockSearchPara2.GoodsNo )
//                 && ( stockSearchPara1.GoodsNoSrchTyp == stockSearchPara2.GoodsNoSrchTyp )
//                 && ( stockSearchPara1.GoodsName == stockSearchPara2.GoodsName )
//                 && ( stockSearchPara1.GoodsNameKana == stockSearchPara2.GoodsNameKana )
//                 && ( stockSearchPara1.LargeGoodsGanreCode == stockSearchPara2.LargeGoodsGanreCode )
//                 && ( stockSearchPara1.LargeGoodsGanreName == stockSearchPara2.LargeGoodsGanreName )
//                 && ( stockSearchPara1.MediumGoodsGanreCode == stockSearchPara2.MediumGoodsGanreCode )
//                 && ( stockSearchPara1.MediumGoodsGanreName == stockSearchPara2.MediumGoodsGanreName )
//                 && ( stockSearchPara1.DetailGoodsGanreCode == stockSearchPara2.DetailGoodsGanreCode )
//                 && ( stockSearchPara1.DetailGoodsGanreName == stockSearchPara2.DetailGoodsGanreName )
//                 && ( stockSearchPara1.EnterpriseGanreCode == stockSearchPara2.EnterpriseGanreCode )
//                 && ( stockSearchPara1.EnterpriseGanreName == stockSearchPara2.EnterpriseGanreName )
//                 && ( stockSearchPara1.BLGoodsCode == stockSearchPara2.BLGoodsCode )
//                 && ( stockSearchPara1.BLGoodsFullName == stockSearchPara2.BLGoodsFullName )
//                 && ( stockSearchPara1.WarehouseCode == stockSearchPara2.WarehouseCode )
//                 && ( stockSearchPara1.WarehouseName == stockSearchPara2.WarehouseName )
//                 && ( stockSearchPara1.CustomerCode == stockSearchPara2.CustomerCode )
//                 && ( stockSearchPara1.CustomerName == stockSearchPara2.CustomerName )
//                 && ( stockSearchPara1.ZeroStckDsp == stockSearchPara2.ZeroStckDsp )
//                 && ( stockSearchPara1.GoodsNos == stockSearchPara2.GoodsNos )
//                 && ( stockSearchPara1.GoodsMakerCds == stockSearchPara2.GoodsMakerCds )
//                 && ( stockSearchPara1.WarehouseCodes == stockSearchPara2.WarehouseCodes )
//                 && ( stockSearchPara1.EnterpriseName == stockSearchPara2.EnterpriseName )
//                 && ( stockSearchPara1.BLGoodsName == stockSearchPara2.BLGoodsName ) );
//            if (!equal) return false;
//            bool isExist;

//            // ���i�R�[�h�i�����w��j
//            if ( stockSearchPara1.GoodsNos.Length != stockSearchPara2.GoodsNos.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in stockSearchPara2.GoodsNos ) {
//                isExist = false;
//                foreach ( string wk2 in stockSearchPara1.GoodsNos ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }
//            // ���[�J�[�R�[�h�i�����w��j
//            if ( stockSearchPara1.GoodsMakerCds.Length != stockSearchPara2.GoodsMakerCds.Length ) {
//                return false;
//            }

//            foreach ( int wk1 in stockSearchPara2.GoodsMakerCds ) {
//                isExist = false;
//                foreach ( int wk2 in stockSearchPara1.GoodsMakerCds ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            // �q�ɃR�[�h�i�����w��j
//            if ( stockSearchPara1.WarehouseCodes.Length != stockSearchPara2.WarehouseCodes.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in stockSearchPara2.WarehouseCodes ) {
//                isExist = false;
//                foreach ( string wk2 in stockSearchPara1.WarehouseCodes ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            return true;
//        }
//        /// <summary>
//        /// �݌Ɍ������o�������[�N��r����
//        /// </summary>
//        /// <param name="target">��r�Ώۂ�StockSearchPara�N���X�̃C���X�^���X</param>
//        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public ArrayList Compare ( StockSearchPara target )
//        {
//            ArrayList resList = new ArrayList();
//            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add("EnterpriseCode");
//            if ( this.SectionCode != target.SectionCode ) resList.Add("SectionCode");
//            if ( this.GoodsMakerCd != target.GoodsMakerCd ) resList.Add("GoodsMakerCd");
//            if ( this.MakerName != target.MakerName ) resList.Add("MakerName");
//            if ( this.GoodsNo != target.GoodsNo ) resList.Add("GoodsNo");
//            if ( this.GoodsNoSrchTyp != target.GoodsNoSrchTyp ) resList.Add("GoodsNoSrchTyp");
//            if ( this.GoodsName != target.GoodsName ) resList.Add("GoodsName");
//            if ( this.GoodsNameKana != target.GoodsNameKana ) resList.Add("GoodsNameKana");
//            if ( this.LargeGoodsGanreCode != target.LargeGoodsGanreCode ) resList.Add("LargeGoodsGanreCode");
//            if ( this.LargeGoodsGanreName != target.LargeGoodsGanreName ) resList.Add("LargeGoodsGanreName");
//            if ( this.MediumGoodsGanreCode != target.MediumGoodsGanreCode ) resList.Add("MediumGoodsGanreCode");
//            if ( this.MediumGoodsGanreName != target.MediumGoodsGanreName ) resList.Add("MediumGoodsGanreName");
//            if ( this.DetailGoodsGanreCode != target.DetailGoodsGanreCode ) resList.Add("DetailGoodsGanreCode");
//            if ( this.DetailGoodsGanreName != target.DetailGoodsGanreName ) resList.Add("DetailGoodsGanreName");
//            if ( this.EnterpriseGanreCode != target.EnterpriseGanreCode ) resList.Add("EnterpriseGanreCode");
//            if ( this.EnterpriseGanreName != target.EnterpriseGanreName ) resList.Add("EnterpriseGanreName");
//            if ( this.BLGoodsCode != target.BLGoodsCode ) resList.Add("BLGoodsCode");
//            if ( this.BLGoodsFullName != target.BLGoodsFullName ) resList.Add("BLGoodsFullName");
//            if ( this.WarehouseCode != target.WarehouseCode ) resList.Add("WarehouseCode");
//            if ( this.WarehouseName != target.WarehouseName ) resList.Add("WarehouseName");
//            if ( this.CustomerCode != target.CustomerCode ) resList.Add("CustomerCode");
//            if ( this.CustomerName != target.CustomerName ) resList.Add("CustomerName");
//            if ( this.ZeroStckDsp != target.ZeroStckDsp ) resList.Add("ZeroStckDsp");
//            if ( this.GoodsNos != target.GoodsNos ) resList.Add("GoodsNos");
//            if ( this.GoodsMakerCds != target.GoodsMakerCds ) resList.Add("GoodsMakerCds");
//            if ( this.WarehouseCodes != target.WarehouseCodes ) resList.Add("WarehouseCodes");
//            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add("EnterpriseName");
//            if ( this.BLGoodsName != target.BLGoodsName ) resList.Add("BLGoodsName");

//            // ���i�R�[�h(�����w��)
//            if ( this.GoodsNos.Length != target.GoodsNos.Length ) {
//                resList.Add("GoodsNos");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in target.GoodsNos ) {
//                    isExsist = false;
//                    foreach ( string wk2 in this.GoodsNos ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsNos");
//                        break;
//                    }
//                }
//            }

//            // ���[�J�[�R�[�h(�����w��)
//            if ( this.GoodsMakerCds.Length != target.GoodsMakerCds.Length ) {
//                resList.Add("GoodsMakerCds");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( int wk1 in target.GoodsMakerCds ) {
//                    isExsist = false;
//                    foreach ( int wk2 in this.GoodsMakerCds ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsMakerCds");
//                        break;
//                    }
//                }
//            }

//            // �q�ɃR�[�h(�����w��)
//            if ( this.WarehouseCodes.Length != target.WarehouseCodes.Length ) {
//                resList.Add("WarehouseCodes");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in target.WarehouseCodes ) {
//                    isExsist = false;
//                    foreach ( string wk2 in this.WarehouseCodes ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("WarehouseCodes");
//                        break;
//                    }
//                }
//            }


//            return resList;
//        }

//        /// <summary>
//        /// �݌Ɍ������o�������[�N��r����
//        /// </summary>
//        /// <param name="stockSearchPara1">��r����StockSearchPara�N���X�̃C���X�^���X</param>
//        /// <param name="stockSearchPara2">��r����StockSearchPara�N���X�̃C���X�^���X</param>
//        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
//        /// <remarks>
//        /// <br>Note�@�@�@�@�@�@ :   StockSearchPara�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
//        /// <br>Programer        :   ��������</br>
//        /// </remarks>
//        public static ArrayList Compare ( StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2 )
//        {
//            ArrayList resList = new ArrayList();
//            if ( stockSearchPara1.EnterpriseCode != stockSearchPara2.EnterpriseCode ) resList.Add("EnterpriseCode");
//            if ( stockSearchPara1.SectionCode != stockSearchPara2.SectionCode ) resList.Add("SectionCode");
//            if ( stockSearchPara1.GoodsMakerCd != stockSearchPara2.GoodsMakerCd ) resList.Add("GoodsMakerCd");
//            if ( stockSearchPara1.MakerName != stockSearchPara2.MakerName ) resList.Add("MakerName");
//            if ( stockSearchPara1.GoodsNo != stockSearchPara2.GoodsNo ) resList.Add("GoodsNo");
//            if ( stockSearchPara1.GoodsNoSrchTyp != stockSearchPara2.GoodsNoSrchTyp ) resList.Add("GoodsNoSrchTyp");
//            if ( stockSearchPara1.GoodsName != stockSearchPara2.GoodsName ) resList.Add("GoodsName");
//            if ( stockSearchPara1.GoodsNameKana != stockSearchPara2.GoodsNameKana ) resList.Add("GoodsNameKana");
//            if ( stockSearchPara1.LargeGoodsGanreCode != stockSearchPara2.LargeGoodsGanreCode ) resList.Add("LargeGoodsGanreCode");
//            if ( stockSearchPara1.LargeGoodsGanreName != stockSearchPara2.LargeGoodsGanreName ) resList.Add("LargeGoodsGanreName");
//            if ( stockSearchPara1.MediumGoodsGanreCode != stockSearchPara2.MediumGoodsGanreCode ) resList.Add("MediumGoodsGanreCode");
//            if ( stockSearchPara1.MediumGoodsGanreName != stockSearchPara2.MediumGoodsGanreName ) resList.Add("MediumGoodsGanreName");
//            if ( stockSearchPara1.DetailGoodsGanreCode != stockSearchPara2.DetailGoodsGanreCode ) resList.Add("DetailGoodsGanreCode");
//            if ( stockSearchPara1.DetailGoodsGanreName != stockSearchPara2.DetailGoodsGanreName ) resList.Add("DetailGoodsGanreName");
//            if ( stockSearchPara1.EnterpriseGanreCode != stockSearchPara2.EnterpriseGanreCode ) resList.Add("EnterpriseGanreCode");
//            if ( stockSearchPara1.EnterpriseGanreName != stockSearchPara2.EnterpriseGanreName ) resList.Add("EnterpriseGanreName");
//            if ( stockSearchPara1.BLGoodsCode != stockSearchPara2.BLGoodsCode ) resList.Add("BLGoodsCode");
//            if ( stockSearchPara1.BLGoodsFullName != stockSearchPara2.BLGoodsFullName ) resList.Add("BLGoodsFullName");
//            if ( stockSearchPara1.WarehouseCode != stockSearchPara2.WarehouseCode ) resList.Add("WarehouseCode");
//            if ( stockSearchPara1.WarehouseName != stockSearchPara2.WarehouseName ) resList.Add("WarehouseName");
//            if ( stockSearchPara1.CustomerCode != stockSearchPara2.CustomerCode ) resList.Add("CustomerCode");
//            if ( stockSearchPara1.CustomerName != stockSearchPara2.CustomerName ) resList.Add("CustomerName");
//            if ( stockSearchPara1.ZeroStckDsp != stockSearchPara2.ZeroStckDsp ) resList.Add("ZeroStckDsp");
//            if ( stockSearchPara1.GoodsNos != stockSearchPara2.GoodsNos ) resList.Add("GoodsNos");
//            if ( stockSearchPara1.GoodsMakerCds != stockSearchPara2.GoodsMakerCds ) resList.Add("GoodsMakerCds");
//            if ( stockSearchPara1.WarehouseCodes != stockSearchPara2.WarehouseCodes ) resList.Add("WarehouseCodes");
//            if ( stockSearchPara1.EnterpriseName != stockSearchPara2.EnterpriseName ) resList.Add("EnterpriseName");
//            if ( stockSearchPara1.BLGoodsName != stockSearchPara2.BLGoodsName ) resList.Add("BLGoodsName");

//            // ���i�R�[�h(�����w��)
//            if ( stockSearchPara1.GoodsNos.Length != stockSearchPara2.GoodsNos.Length ) {
//                resList.Add("GoodsNos");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in stockSearchPara2.GoodsNos ) {
//                    isExsist = false;
//                    foreach ( string wk2 in stockSearchPara1.GoodsNos ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsNos");
//                        break;
//                    }
//                }
//            }

//            // ���[�J�[�R�[�h(�����w��)
//            if ( stockSearchPara1.GoodsMakerCds.Length != stockSearchPara2.GoodsMakerCds.Length ) {
//                resList.Add("GoodsMakerCds");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( int wk1 in stockSearchPara2.GoodsMakerCds ) {
//                    isExsist = false;
//                    foreach ( int wk2 in stockSearchPara1.GoodsMakerCds ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsMakerCds");
//                        break;
//                    }
//                }
//            }

//            // �q�ɃR�[�h(�����w��)
//            if ( stockSearchPara1.WarehouseCodes.Length != stockSearchPara2.WarehouseCodes.Length ) {
//                resList.Add("WarehouseCodes");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in stockSearchPara2.WarehouseCodes ) {
//                    isExsist = false;
//                    foreach ( string wk2 in stockSearchPara1.WarehouseCodes ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("WarehouseCodes");
//                        break;
//                    }
//                }
//            }
//            return resList;
//        }
//    }
//}
