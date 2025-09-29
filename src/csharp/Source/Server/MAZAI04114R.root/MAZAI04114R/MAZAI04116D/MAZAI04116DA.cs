using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockSearchParaWork
	/// <summary>
	///                      �݌Ɍ������o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɍ������o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSearchParaWork
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
		private DateTime _st_Date;

		/// <summary>�I���Ώۓ��t</summary>
		private DateTime _ed_Date;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>�v����t</summary>
        private DateTime _pricestartdate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD


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
		public DateTime St_Date
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
		public DateTime Ed_Date
		{
			get{return _ed_Date;}
			set{_ed_Date = value;}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// public propaty name  :  pricestartdate
        /// <summary>�v��Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime pricestartdate
        {
            get { return _pricestartdate; }
            set { _pricestartdate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

		/// <summary>
		/// �݌Ɍ������o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockSearchParaWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockSearchParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockSearchParaWork()
		{
		}

	}
}
