using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RatePrtReqWork
	/// <summary>
	///                      �|��������o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �|��������o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RatePrtReqWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���null</remarks>
		private string[] _sectionCode;

		/// <summary>�P�����</summary>
		/// <remarks>1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���</remarks>
		private Int32 _unitPriceKind;

		/// <summary>�ݒ���@</summary>
		/// <remarks>1:�P�i�ݒ� 0:�O���[�v�ݒ�</remarks>
		private Int32 _rateMngGoodsCdKind;

		/// <summary>�J�n�|���ݒ�敪</summary>
		/// <remarks>A1,A2��</remarks>
		private string _rateSettingDivideSt = "";

		/// <summary>�I���|���ݒ�敪</summary>
		/// <remarks>A1,A2��</remarks>
		private string _rateSettingDivideEd = "";

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _customerCodeSt;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _customerCodeEd;

		/// <summary>�J�n���Ӑ�|���O���[�v�R�[�h</summary>
		private Int32 _custRateGrpCodeSt;

		/// <summary>�I�����Ӑ�|���O���[�v�R�[�h</summary>
		private Int32 _custRateGrpCodeEd;

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _supplierCdSt;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _supplierCdEd;

		/// <summary>�J�n���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCdSt;

		/// <summary>�I�����i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCdEd;

		/// <summary>�J�n���i�|�������N</summary>
		/// <remarks>�w��</remarks>
		private string _goodsRateRankSt = "";

		/// <summary>�I�����i�|�������N</summary>
		/// <remarks>�w��</remarks>
		private string _goodsRateRankEd = "";

		/// <summary>�J�n���i�|���O���[�v�R�[�h</summary>
		private Int32 _goodsRateGrpCodeSt;

		/// <summary>�I�����i�|���O���[�v�R�[�h</summary>
		private Int32 _goodsRateGrpCodeEd;

		/// <summary>�J�nBL�O���[�v�R�[�h</summary>
		private Int32 _bLGroupCodeSt;

		/// <summary>�I��BL�O���[�v�R�[�h</summary>
		private Int32 _bLGroupCodeEd;

		/// <summary>�J�nBL���i�R�[�h</summary>
		private Int32 _bLGoodsCodeSt;

		/// <summary>�I��BL���i�R�[�h</summary>
		private Int32 _bLGoodsCodeEd;

		/// <summary>�J�n���i�ԍ�</summary>
		private string _goodsNoSt = "";

		/// <summary>�I�����i�ԍ�</summary>
		private string _goodsNoEd = "";


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
		/// <value>(�z��)�@�S�Ўw���null</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  UnitPriceKind
		/// <summary>�P����ރv���p�e�B</summary>
		/// <value>1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P����ރv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnitPriceKind
		{
			get{return _unitPriceKind;}
			set{_unitPriceKind = value;}
		}

		/// public propaty name  :  RateMngGoodsCdKind
		/// <summary>�ݒ���@�v���p�e�B</summary>
		/// <value>1:�P�i�ݒ� 0:�O���[�v�ݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݒ���@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RateMngGoodsCdKind
		{
			get{return _rateMngGoodsCdKind;}
			set{_rateMngGoodsCdKind = value;}
		}

		/// public propaty name  :  RateSettingDivideSt
		/// <summary>�J�n�|���ݒ�敪�v���p�e�B</summary>
		/// <value>A1,A2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�|���ݒ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateSettingDivideSt
		{
			get{return _rateSettingDivideSt;}
			set{_rateSettingDivideSt = value;}
		}

		/// public propaty name  :  RateSettingDivideEd
		/// <summary>�I���|���ݒ�敪�v���p�e�B</summary>
		/// <value>A1,A2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���|���ݒ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RateSettingDivideEd
		{
			get{return _rateSettingDivideEd;}
			set{_rateSettingDivideEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

		/// public propaty name  :  CustRateGrpCodeSt
		/// <summary>�J�n���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustRateGrpCodeSt
		{
			get{return _custRateGrpCodeSt;}
			set{_custRateGrpCodeSt = value;}
		}

		/// public propaty name  :  CustRateGrpCodeEd
		/// <summary>�I�����Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustRateGrpCodeEd
		{
			get{return _custRateGrpCodeEd;}
			set{_custRateGrpCodeEd = value;}
		}

		/// public propaty name  :  SupplierCdSt
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdSt
		{
			get{return _supplierCdSt;}
			set{_supplierCdSt = value;}
		}

		/// public propaty name  :  SupplierCdEd
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdEd
		{
			get{return _supplierCdEd;}
			set{_supplierCdEd = value;}
		}

		/// public propaty name  :  GoodsMakerCdSt
		/// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCdSt
		{
			get{return _goodsMakerCdSt;}
			set{_goodsMakerCdSt = value;}
		}

		/// public propaty name  :  GoodsMakerCdEd
		/// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCdEd
		{
			get{return _goodsMakerCdEd;}
			set{_goodsMakerCdEd = value;}
		}

		/// public propaty name  :  GoodsRateRankSt
		/// <summary>�J�n���i�|�������N�v���p�e�B</summary>
		/// <value>�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�|�������N�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsRateRankSt
		{
			get{return _goodsRateRankSt;}
			set{_goodsRateRankSt = value;}
		}

		/// public propaty name  :  GoodsRateRankEd
		/// <summary>�I�����i�|�������N�v���p�e�B</summary>
		/// <value>�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�|�������N�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsRateRankEd
		{
			get{return _goodsRateRankEd;}
			set{_goodsRateRankEd = value;}
		}

		/// public propaty name  :  GoodsRateGrpCodeSt
		/// <summary>�J�n���i�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsRateGrpCodeSt
		{
			get{return _goodsRateGrpCodeSt;}
			set{_goodsRateGrpCodeSt = value;}
		}

		/// public propaty name  :  GoodsRateGrpCodeEd
		/// <summary>�I�����i�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsRateGrpCodeEd
		{
			get{return _goodsRateGrpCodeEd;}
			set{_goodsRateGrpCodeEd = value;}
		}

		/// public propaty name  :  BLGroupCodeSt
		/// <summary>�J�nBL�O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�nBL�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGroupCodeSt
		{
			get{return _bLGroupCodeSt;}
			set{_bLGroupCodeSt = value;}
		}

		/// public propaty name  :  BLGroupCodeEd
		/// <summary>�I��BL�O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��BL�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGroupCodeEd
		{
			get{return _bLGroupCodeEd;}
			set{_bLGroupCodeEd = value;}
		}

		/// public propaty name  :  BLGoodsCodeSt
		/// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCodeSt
		{
			get{return _bLGoodsCodeSt;}
			set{_bLGoodsCodeSt = value;}
		}

		/// public propaty name  :  BLGoodsCodeEd
		/// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCodeEd
		{
			get{return _bLGoodsCodeEd;}
			set{_bLGoodsCodeEd = value;}
		}

		/// public propaty name  :  GoodsNoSt
		/// <summary>�J�n���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNoSt
		{
			get{return _goodsNoSt;}
			set{_goodsNoSt = value;}
		}

		/// public propaty name  :  GoodsNoEd
		/// <summary>�I�����i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNoEd
		{
			get{return _goodsNoEd;}
			set{_goodsNoEd = value;}
		}


		/// <summary>
		/// �|��������o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>RatePrtReqWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RatePrtReqWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RatePrtReqWork()
		{
		}

	}
}
